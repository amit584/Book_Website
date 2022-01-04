<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>תגדירו ספר</title>
    <link rel="stylesheet" type="text/css" href="Stylemain.css" />
</head>
<body> 
        <%=Link%> <%=Counter%>
        <%  string status = Request.QueryString["status"];
            if (status != null)
                Response.Write(status);
        %>            
       <div id="section">
         <div style="background-image: url('images/books2.jpg'); background-size:cover;height:700px; width:1250px;margin-right:40px;margin-left:40px">
   <div style="text-align:center;font-size:100px;color:white;"><b>"תגדירו ספר"</b></div>
         <div style="text-align:center;font-size:30px;color:white"><h1 style="border:solid">המקום לבטא את עצמכם</h1></div>   
           </div>
       </div>
        <div id="footer">
            Copyright © AmitShavit
        </div>
</body>
</html>
