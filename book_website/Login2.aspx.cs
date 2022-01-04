using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Login2 : System.Web.UI.Page
{
    public string Link="";
    protected void Page_Load(object sender, EventArgs e)
    {

        Link = Menue.CreateMenuLinks(null, null);

        if (Request.Form["submit"] != null)//שלחו נתונים
            {
                string uname = Request.Form["unamelogin"];
                string pass = Request.Form["passwordlogin"];
                string sql = "SELECT * FROM Register WHERE uname='" + uname + "' and pass='" + pass + "'";
                if (MyAdoHelper.IsExist("Database.mdf", sql))
                {
                    DataTable table = MyAdoHelper.ExecuteDataTable("Database.mdf", sql);
                    Session["uname"] = table.Rows[0]["uname"];
                    Session["Suser"] = Request.Form["unamelogin"];
                    Session["IsAdmin"] = null;
                    if ((bool)table.Rows[0]["IsAdmin"] == true)
                    {
                        Session["IsAdmin"] = "yes";
                    }
                    Response.Redirect("Homepage.aspx");
                    Response.End();
                }
            
            }
    }

}