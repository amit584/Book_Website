<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" type="text/css" href="Stylepages.css" />
        <link rel="stylesheet" type="text/css" href="Stylemain.css" />

</head>
<body>
    <%=Link %>
    <div style="background-image: url('images/books2.jpg'); background-size:cover; text-align:center; direction:rtl; align-content:center;margin-right:36px; margin-left:40px; height:700px; width:1250px">
    <h1> עדכון הרשומות שנמצאו</h1>
            <%=userList %>
        <h1>טווח גילאים</h1>
        <form id="ages" method="post" action="">
            גיל מקסימלי <input type="text" name="maxage" id="maxage" />
            גיל מינימלי <input type="text" name="minage" id="minage" />
            <input type="submit" name="submit" id="submit" value="הצג"/>
        </form>
            <%=ages %>
        </div>
     <div id="footer">
            Copyright © AmitShavit
        </div>
</body>
</html>
