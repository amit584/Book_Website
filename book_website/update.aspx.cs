using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class update : System.Web.UI.Page
{
    public string Link;
    public string userMsg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] == null)
            Link = Menue.CreateMenuLinks(Session["Suser"], null);
        else
            Link = Menue.CreateMenuLinks(Session["Suser"], Session["IsAdmin"]);
        string fileName = "Database.mdf";
        string selectsql = "";
        string updatesql = "";
        string newpass = Request.Form["newpass"];
        string oldpass = Request.Form["oldpass"];
        string unameupdate = Request.Form["unameupdate"];
        if (Request.Form["update"] != null)
        {
            selectsql = "SELECT * FROM  Register WHERE uname='" + unameupdate + "' AND [Pass]='" + oldpass + "'";
            updatesql = "UPDATE Register SET [pass]='"+newpass +"'WHERE uname='" + unameupdate + "' AND [Pass]='" + oldpass + "'";
            if (MyAdoHelper.IsExist(fileName, selectsql))
            {
                MyAdoHelper.DoQuery(fileName, updatesql);
                userMsg = "עודכנו הפרטים";

            }
            else
            {
                userMsg = "סיסמא מקורית או שם המשתמש לא תקינים";
            }
        }
    }
}