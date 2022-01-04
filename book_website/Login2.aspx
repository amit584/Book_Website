<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login2.aspx.cs" Inherits="Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" type="text/css" href="Stylemain.css" />
    <script type="text/javascript">
        var msg;
        function isEmpty(str) { //אמת אם מחרוזת ריקה
            if (str.length == 0)
                return true;
            else
                return false;
        }

        function checkLogIn() {
            msg = "";
            if (isEmpty(document.getElementById("unamelogin").value)) 
                msg += "<br/>  חובה להזין שם משתמש <br/>";
            if (isEmpty(document.getElementById("passwordlogin").value))
                msg += "<br/>  חובה להזין ססמא  <br/>";
            if (msg.length == 0)
            {
                return true;
            }
            else
            {
                document.getElementById('errors').innerHTML = msg;
                return false;
            }
        }
    </script>
</head>
<body>
   <%=Link %>
    <div style="background-image:url('images/books6.jpg'); background-size:cover;margin-right:40px;margin-left:40px; height:700px; width:1250px; margin-top: 28px;">
        <h4 id="errors"></h4>
          <form name="loginfrm" method="post" style="font-size:larger" action="Login2.aspx" onsubmit="return checkLogIn();">
            <h1 style="align-self:center">התחבר</h1>
            שם משתמש: <input type="text" name="unamelogin" id="unamelogin" maxlength="12" />
            <br />
            <br />
            סיסמא: <input type="password" name="passwordlogin" id="passwordlogin" />
            <br /><br />
            <input type="submit" name="submit" value="התחבר" />

            <h3>אין לך משתמש? <a href="Register.aspx" style="color:white"> הרשם כאן</a></h3>
        </form>
    </div>
        <div id="footer">
            Copyright © AmitShavit
        </div>
</body>
</html>
