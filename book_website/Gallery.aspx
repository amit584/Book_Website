<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>גלריית סיפורים</title>
    <link rel="stylesheet" type="text/css" href="Stylepages.css" />
        <link rel="stylesheet" type="text/css" href="Stylemain.css" />
                <script type="text/javascript">
            function clearForm(oForm) {
                var elements = oForm.elements;

                oForm.reset();

                for (i = 0; i < elements.length; i++) {

                    if (elements[i].type.toLowerCase() == "text")
                        elements[i].value = "";
                }
            }
</script>	
</head>
    <style>
    td {
    border-bottom: 1px solid #ddd;
    }
    table {
    width: 100%;
}
    </style>
<body>
        <%=Link %>
    <br />
        <div style="background-image:url(images/ttt.jpg);background-size:cover;margin-right:40px;margin-left:40px; height:700px; width:1250px; font-size:medium;">
    <form id="filter_form" method="post" runat="server" enctype="multipart/form-data">
        זיהוי: <input id="id_filter" type ="text" runat="server" />
        מחבר: <input id="author_filter" type ="text" runat="server" />
        כותר: <input id="title_filter" type ="text" runat="server" />
        גודל מירבי: <input id="maxsize_filter" type ="text" runat="server" />
        תגית: <input id="tags_filter" type ="text" runat="server" />
        <input type="button" name="clear" value="נקה" onclick="clearForm(this.form);" />
        <input type="submit" name="submit" value="סנן" />
    </form>
       <%=gallery %>
        </div>
         <div id="footer">
            Copyright © AmitShavit
        </div>

</body>
</html>
