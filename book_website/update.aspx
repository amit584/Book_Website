<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" type="text/css" href="Stylepages.css" />
        <link rel="stylesheet" type="text/css" href="Stylemain.css" />

</head>
<body >
      <%=Link %>
    <div style="background-image:url(images/books6.jpg);background-size:cover; margin-left:0; height:700px; width:1250px ">
    <h1>הכנס פרטים לעדכון:</h1>
    <form id="updatefrm" action="" method="post" style="font-size:larger; text-align:center">
    <div>
        הכנס שם משתמש:
        <input type="text" name="unameupdate" id="unameupdate" />
        <br />
        <br />
        הכנס ססמא נוכחית:
        <input type="password" name="oldpass" id="oldpass"/>
        <br />
        <br />
        הכנס ססמא חדשה:
        <input type="password" name="newpass" id="newpass" />
        <br />
        <br />
        <input type="submit" name="update" value="עדכן" />
    </div>
    </form>
                    <%=userMsg %>
    </div>

     <div id="footer">
            Copyright © AmitShavit
        </div>
</body>
</html>
