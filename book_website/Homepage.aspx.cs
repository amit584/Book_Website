using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Homepage : System.Web.UI.Page
{
    public string Link="";
    public string Counter;
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
        
        if (Session["firstLog"]==null)
        {
            Application.Lock();
            if (Application["counter"] == null)
            {
                Application["counter"] = 0;
            }
            Application["counter"] = (int)Application["counter"] + 1;
            Application.UnLock();
            Session["firstLog"] = "No";
        }
        Counter = "<h3 style='color:Black' >" + "  מספר ביקורים באתר: " + Application["counter"] + "<h3>";
    }
}