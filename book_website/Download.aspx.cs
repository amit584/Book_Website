using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];

        string strQuery = "select Name, ContentType, Data from Files where id=" + id;

        DataTable book = MyAdoHelper.ExecuteDataTable("Database.mdf", strQuery);

        download(book);

    }
    private void download(DataTable dt)

    {

        Byte[] bytes = (Byte[])dt.Rows[0]["Data"];

        Response.Buffer = true;

        Response.Charset = "";

        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = dt.Rows[0]["ContentType"].ToString();

        Response.AddHeader("content-disposition", "attachment;filename="

        + dt.Rows[0]["Name"].ToString());

        Response.BinaryWrite(bytes);

        Response.Flush();

        Response.End();

    }
}