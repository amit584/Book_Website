using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    public string RegStatus = "";//משתנה גלובלי לשמירת הודעות שיוצגו בטופס ההרשמה או בדף הבית
    public string Link = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Link = Menue.CreateMenuLinks(null, null);
        if (Request.Form["submit"] != null)
        {

            string fname = Request.Form["fname"];
            string lname = Request.Form["lname"];
            string pass = Request.Form["pass"];
            string uname = Request.Form["uname"];
            string gender = Request.Form["gender"];
            string date = Request.Form["Date"];
            string email = Request.Form["email"];
            bool isAdmin = false;//  יכנס אוטומטית  שקר למשתמש רגיל שאינו מנהל
            string fileName = "Database.mdf"; //שם קובץ ה-data base
            string selectSql = "SELECT * FROM  Register WHERE uname='" + uname + "'";
            if (MyAdoHelper.IsExist(fileName, selectSql))
                RegStatus = "שם המשתמש קיים";
            else
            {
                string sql = "INSERT INTO Register(uname,fname,lname,pass,date,gender,email,isAdmin) VALUES('" + uname + "',N'" + fname + "',N'" + lname + "','" + pass + "','" + date + "',N'" + gender + "',N'"+email+"','" + isAdmin + "')";
                MyAdoHelper.DoQuery(fileName, sql);
                RegStatus = " ההרשמה בוצעה בהצלחה נא להתחבר";
                Response.Redirect("Homepage.aspx?status=" + RegStatus);
                Response.End();
            }
        }
    }
}