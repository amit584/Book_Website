using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class removeuseraspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["uname"] !=null)
        {
            string uname = Request.QueryString["uname"];
            string sql = "DELETE FROM Register WHERE uname='" + uname + "'";
            MyAdoHelper.DoQuery("Database.mdf", sql);
        }
        Response.Redirect("manager.aspx");
    }
}