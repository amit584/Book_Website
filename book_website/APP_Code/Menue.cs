using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Menue
{
    public static string CreateMenuLinks(Object suser, Object isAdmin)
    {
        string Link = "";
        if (suser == null)
        {
            Link += "<div id = 'header' style='margin-left:0;'>";
            Link += "<ul>";
            Link += "<li><a href ='Homepage.aspx'><h2> דף בית </h2></a ></li> &nbsp";
            Link += "<li><a href ='About.aspx' ><h2> על האתר </h2></a></li>";
            Link += "<li><a href ='Login2.aspx' ><h2> התחבר </h2></a></li>";
            Link += "<li><a href ='Gallery.aspx'><h2> גלריית סיפורים </h2></a></li>";
            Link += "</ul>";
            Link += "</div><br /><br />";

        }
        else
        {
            if (isAdmin != null)
            {
                Link += "<div id = 'header'>";
                Link += "<ul>";
                Link += "<li><a href='Homepage.aspx' ><h2> דף בית </h2></a></li> &nbsp";
                Link += "<li><a href='About.aspx' ><h2> על האתר </h2></a></li>";
                Link += "<li><a href='Gallery.aspx' ><h2> גלריית סיפורים </h2></a></li>";
                Link += "<li><a href='Personal.aspx' ><h2> אזור אישי </h2></a></li>";
                Link += "<li><a href='manager.aspx'><h2> מנהל </h2></a></li>";
                Link += "<li><a href='LogOut.aspx'><h2> התנתק </h2></a></li>";
                Link += "</ul>";
                Link += "</div><br /><br />";
            }
            else
            {
                Link += "<div id = 'header'>";
                Link += "<ul>";
                Link += "<li><a href='Homepage.aspx'><h2> דף בית </h2></a></li> &nbsp";
                Link += "<li><a href='About.aspx'><h2> על האתר </h2></a></li>";
                Link += "<li><a href='Gallery.aspx'  ><h2> גלריית סיפורים </h2></a></li>";
                Link += "<li><a href='Personal.aspx' ><h2> אזור אישי </h2></a></li>";
                Link += "<li><a href='LogOut.aspx' ><h2> התנתק </h2></a></li>";
                Link += "</ul>";
                Link += "</div><br /><br />";
            }

        }
        return Link;
    }
}