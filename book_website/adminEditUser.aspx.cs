using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminEditUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Form["submit"] != null)
        {
            string uname = Request.Form["uname"];
            string IsAdmin = Request.Form["IsAdmin"];
            bool isadmin;
            string fname = Request.Form["fname"];
            string lname = Request.Form["lname"];
            string gender = Request.Form["gender"];
            string email = Request.Form["email"];
            string date = Request.Form["Date"];
            string sql = "UPDATE Register SET Date='" + date + "' ,fname=N'" + fname + "',lname=N'" + lname + "',gender=N'" + gender + "',email='" + email + "'";
            isadmin = ToBoolean(IsAdmin);
            sql += ",IsAdmin='" + isadmin + "'";
            sql += " WHERE uname=N'" + uname + "'";
            MyAdoHelper.DoQuery("Database.mdf", sql);
            Response.Redirect("manager.aspx");
        }
    }
    private bool ToBoolean(string st)
    {
        switch (st)
        {
            case "true":
                return true;
            case "True":
                return true;
            case "false":
                return false;
            case "False":
                return false;
            default:
                throw new InvalidCastException("You can't cast a weird value to a bool!");

        }
    }
}