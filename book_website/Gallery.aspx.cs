using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Gallery : System.Web.UI.Page
{
    public string gallery;
    public string Link;
    public string filter;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Suser"] == null)
            Link = Menue.CreateMenuLinks(null, null);
        else
        {
            if (Session["IsAdmin"] == null)
                Link = Menue.CreateMenuLinks(Session["Suser"], null);
            else
                Link = Menue.CreateMenuLinks(Session["Suser"], Session["IsAdmin"]);
        }
        if (Request.Form["submit"] != null)
        { //שלחו נתונים) 
            filter = buildFilter(); // בנה פילטר מהטופס
        }
        string sql = "SELECT Id, Name, Size, Tags, Uploader FROM Files"
            + filter; // הצמד פילטר אם קיים

        DataTable table = MyAdoHelper.ExecuteDataTable("Database.mdf", sql);

        int length = table.Rows.Count;
        if (length > 0)
        {
            gallery += "<table style='border:2px; align:center; text-align:center; direction:rtl'>";
            gallery += "<tr>";
            gallery += "<th> מספר זיהוי </th>";
            gallery += "<th> כותר </th>";
            gallery += "<th> גודל </th>";
            gallery += "<th> תגיות </th>";
            gallery += "<th> סופר </th>";
            gallery += "</tr>";
            for (int i = 0; i < length; i++)
            {
                gallery += "<tr>";
                gallery += "<td><a style='color:white' href='Download.aspx?id=" + table.Rows[i]["Id"] + "'</a>" + table.Rows[i]["Id"] + "</td>";
                gallery += "<td>" + table.Rows[i]["Name"] + "</td>";
                gallery += "<td>" + table.Rows[i]["Size"] + "</td>";
                gallery += "<td>" + table.Rows[i]["Tags"] + "</td>";
                gallery += "<td>" + table.Rows[i]["Uploader"] + "</td>";
                gallery += "</tr>";
            }
            gallery += "</table>";
        }


    }
    // בנה פילטר לשאילתה עפ שדות הטופס
    private string buildFilter()
    {
        if (isValidFilterField("id_filter"))
        {
            filter += " where Id=N'" + Request.Form["id_filter"] + "'";
            return filter; // שדה ייחודי - שאר הפילטר לא משנה
        }
        if (isValidFilterField("author_filter"))
        {
            filter += getHibur(filter) + "Uploader=N'" + Request.Form["author_filter"] + "' ";
        }
        if (isValidFilterField("maxsize_filter"))
        {
            filter += getHibur(filter) + "Size<=N'" + Request.Form["maxsize_filter"] + "' ";
        }
        if (isValidFilterField("title_filter"))
        {
            filter += getHibur(filter) + "Name like N'%" + Request.Form["title_filter"] + "%'";
        }
        if (isValidFilterField("tags_filter"))
        {
            filter += getHibur(filter) + "Tags like N'%" + Request.Form["tags_filter"] + "%'";
        }
        return filter;
    }

    // החזר את מילת הקישור הנכונה לבניית הפילטר של השאילתה
    // אם ראשון - "where"
    // אחרת - " and "
    private string getHibur(string filter)
    {
        if (filter != null)
        {
            return " and ";
        }
        return " where ";
    }

    private bool isValidFilterField(string fieldName)
    {
        return Request.Form[fieldName] != null && Request.Form[fieldName] != "";
    }
}