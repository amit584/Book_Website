<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personal.aspx.cs" Inherits="Personal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>אזור אישי</title>
    <link rel="stylesheet" type="text/css" href="Stylepages.css" />
        <link rel="stylesheet" type="text/css" href="Stylemain.css" />

</head>
<body >
     <%=Link %>
   <div style="background-image: url(images/books7.jpg); background-size: cover;margin-right:40px;margin-left:40px; height:700px; width:1250px ">
    <h1>הפרופיל שלי:</h1>
        <div style="align-self:center;align-items:center;text-align:center; height: 236px; width: 415px; margin-right: 462px;">
            <%=p %>
        </div>
       <br />
    <a href="update.aspx" style="color:white">עדכן פרטים</a>
    <h1>העלה סיפור:</h1>
    <form id="Form2" method="post" runat="server" enctype="multipart/form-data">
        <input id="filMyFile" type="file" runat="server" />
        תגיות: <input id="textTags" type ="text" runat="server" />
        <input type="submit" name="submit" value="send" />
    </form>
   </div>
     <div id="footer">
            Copyright © AmitShavit
        </div>
</body>
</html>
