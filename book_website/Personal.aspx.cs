using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

public partial class Personal : System.Web.UI.Page
{
    public string p= "";
    public string Link;
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["IsAdmin"] == null)
                Link = Menue.CreateMenuLinks(Session["Suser"], null);
            else
                Link = Menue.CreateMenuLinks(Session["Suser"], Session["IsAdmin"]);
            string uname = Session["Suser"].ToString();
            string sql = "SELECT * FROM Register WHERE uname='" + uname + "'";
            DataTable table = MyAdoHelper.ExecuteDataTable("Database.mdf", sql);
            p += "<div style='text-align:center'><table align:'center' style='border:2px; text-align:center; direction:rtl'>";
            p += "<tr>";
            p += "<th style='font-family: font-family:Choco;font-size:larger;'> שם פרטי </th>";
            p += "<td>" + table.Rows[0]["fname"] + "</td>";
            p += "</tr>";
            p += "<tr>";
            p += "<th style='font-family: font-family:Choco;font-size:larger;'> שם משפחה </th>";
            p += "<td>" + table.Rows[0]["lname"] + "</td>";
            p += "</tr>";
            p += "<tr>";
            p += "<th style='font-family: font-family:Choco;font-size:larger;'> שם משתמש </th>";
            p += "<td>" + table.Rows[0]["uname"] + "</td>";
            p += "</tr>";
            p += "<tr>";
            p += "<th style='font-family: font-family:Choco;font-size:larger;'> סיסמא </th>";
            p += "<td>" + table.Rows[0]["pass"] + "</td>";
            p += "</tr>";
            p += "<tr>";
            p += "<th style='font-family: font-family:Choco;font-size:larger;'> אימייל </th>";
            p += "<td>" + table.Rows[0]["email"] + "</td>";
            p += "</tr>";
            p += "<tr>";
            p += "<th style='font-family: font-family:Choco;font-size:larger;'> מגדר </th>";
            p += "<td>" + table.Rows[0]["gender"] + "</td>";
            p += "</tr>";
            p += "<tr>";
            p += "<th style='font-family: font-family:Choco;font-size:larger;'> תאריך לידה </th>";
            p += "<td>" + table.Rows[0]["date"] + "</td>";
            p += "</tr>";
            p += "</table></div>";

        if (filMyFile.PostedFile != null)
        {
            // Get a reference to PostedFile object
            HttpPostedFile myFile = filMyFile.PostedFile;

            string tags = Request.Form["textTags"];

            InsertUpdateData(myFile, tags);

            Response.Redirect("Gallery.aspx");
        }
    }
        private Boolean InsertUpdateData(HttpPostedFile postedFile, string tags)
        {

            string strQuery = "insert into Files (Name, ContentType, Size, Data, Uploader, Tags) values (@Name, @ContentType, @Size, @Data, @Uploader, @Tags)";

            SqlCommand cmd = new SqlCommand(strQuery);

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Path.GetFileName(postedFile.FileName);

            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = postedFile.ContentType;

            cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = postedFile.ContentLength;

            BinaryReader br = new BinaryReader(postedFile.InputStream);
            Byte[] bytes = br.ReadBytes(Convert.ToInt32(postedFile.ContentLength));
            br.Close();

            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;

            cmd.Parameters.Add("@Uploader", SqlDbType.NVarChar).Value = Session["Suser"].ToString();

            cmd.Parameters.Add("@Tags", SqlDbType.NVarChar).Value = tags;

            SqlConnection con = MyAdoHelper.ConnectToDb("Database.mdf");

            cmd.CommandType = CommandType.Text;

            cmd.Connection = con;

            try

            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
