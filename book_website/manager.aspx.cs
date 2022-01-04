using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

public partial class manager : System.Web.UI.Page
{
    public string Link;
    public string userList;
    public string ages;
    protected void Page_Load(object sender, EventArgs e)
    {
        Link = Menue.CreateMenuLinks(Session["Suser"], Session["IsAdmin"]);
        string sql = "SELECT * FROM Register ORDER BY uname";
        DataTable table = MyAdoHelper.ExecuteDataTable("Database.mdf", sql);
        int length = table.Rows.Count;
        if (length > 0)
        {
            userList += "<table style='border:2px; align:center; text-align:center; direction:rtl'>";
            userList += "<tr>";
            userList += "<th> שם משתמש </th>";
            userList += "<th> סיסמא </th>";
            userList += "<th> שם פרטי </th>";
            userList += "<th> שם משפחה </th>";
            userList += "<th> אימייל </th>";
            userList += "<th> מגדר </th>";
            userList += "<th> תאריך לידה </th>";
            userList += "<th> מנהל </th>";
            userList += "<th> עדכן </th>";
            userList += "<th> מחק </th>";
            userList += "</tr>";
            for (int i = 0; i < length; i++)
            {
                userList += "<tr>";
                userList += "<form method='post' action='adminEditUser.aspx'>";
                userList += "<input type='hidden' name='uname' value='" + table.Rows[i]["uname"] + "'/>";
                userList += "<td>" + table.Rows[i]["uname"] + "</td>";
                userList += "<td>" + table.Rows[i]["pass"] + "</td>";
                userList += "<td><input type='text' name='fname' value='" + table.Rows[i]["fname"] + "'/></td>";
                userList += "<td><input type='text' name='lname' value='" + table.Rows[i]["lname"] + "'/></td>";
                userList += "<td><input type='text' name='email' value='" + table.Rows[i]["email"] + "'/></td>";
                userList += "<td><input type='text' name='gender' value='" + table.Rows[i]["gender"] + "'/></td>";
                userList += "<td><input type='text' name='Date' value='" + table.Rows[i]["Date"] + "'/></td>";
                string a = table.Rows[i]["IsAdmin"].ToString();
                userList += "<td><input type='text' size='4' name='IsAdmin' value='" + a + "'/></td>";
                userList += "<td><input type='submit' name='submit' value='עדכן' /></td>";
                userList += "<td><input type='button'  value='מחק' onclick='window.location.href=\"removeuser.aspx?uname=" + table.Rows[i]["uname"] + "\"'/></td>";
                userList += "</form>";
            }
            userList += "</tr>";
            userList += "</table>";
            if (Request.Form["submit"] != null)
            {
                string maxage = Request.Form["maxage"];
                string minage = Request.Form["minage"];
                string sqlages = "SELECT uname,age FROM Register  WHERE age<='" + maxage + "' AND age>= '" + minage + "'";
                DataTable agetable = MyAdoHelper.ExecuteDataTable("Database.mdf", sqlages);
                int lengthagetable = agetable.Rows.Count;
                if (lengthagetable > 0)
                {
                    ages += "<table style='border:2px; align:center; text-align:center; direction:rtl'>";
                    ages += "<tr>";
                    ages += "<th> שם משתמש </th>";
                    ages += "<th> גיל </th>";
                    ages += "</tr>";
                    for (int i = 0; i < lengthagetable; i++)
                    {
                        ages += "<tr>";
                        ages += "<td>" + agetable.Rows[i]["uname"] + "</td>";
                        ages += "<td>" + agetable.Rows[i]["age"] + "</td>";
                        ages += "</tr>";
                    }
                    ages += "</table>";
                }
            }

        }
    }
}