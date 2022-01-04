using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    public string Link = "";
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
    }
}