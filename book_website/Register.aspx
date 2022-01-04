<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הרשם</title>
        <link rel="stylesheet" type="text/css" href="Stylemain.css" />

    <script type="text/javascript">
    var msg;
    function isEmpty(str) { //אמת אם מחרוזת ריקה
        if (str.length == 0)
            return true;
        else
            return false;
    }

    function isNumeric(str) {//אמת אם מורכב מספרות
        for (i=0; i<str.length; i++)
            if (!(str.charAt(i)>=0 && str.charAt(i)<=9))
                return false;
        return true;  
    }

    function isTavim(str) {//אמת אם מורכב מהא"ב
        for (i = 0; i < str.length; i++)
            if (!(str.charAt(i) >= 'à' && str.charAt(i) <= 'ú') )
                return false;
          
        return true;
    }

    function isValidString(str) { //אמת אם התווים במחרוזת חוקיים
        var quot = "\""; //התו גרשיים אסור
        var badCharStr = "$%^&*()_+[]{}<>&@"; //תווים אסורים
        for (var i = 0; i < str.length; i++) {
            for (var j = 0; j < badCharStr.length; j++) {
                if (str.charAt(i) == badCharStr.charAt(j)) {
                    return false;
                }
            }
        }
        if (str.indexOf(quot) != -1)
            return false;
        return true;
    }

    function checkForm() {
        msg = "";
        if (isEmpty(document.getElementById("fname").value))  //שם פרטי
            msg += "<br/>  חובה להזין שם פרטי  <br/>";
        
        if (isEmpty(document.getElementById("uname").value))             //שם משתמש
            msg += "<br/>  חובה להזין שם משתמש  <br/>";
        else
            if (document.getElementById("uname").value.length <4)
                msg += "<br/>  שם משתמש בעל 4 תווים לפחות  <br/>";
      
        if (isEmpty(document.getElementById("lname").value))         //שם משפחה
            msg += "<br/>  חובה להזין שם משפחה  <br/>";

        if (isEmpty(document.getElementById("pass").value))           //ססמא
            msg += "<br/>  חובה להזין ססמא  <br/>";
        
        else
          if (isValidString(document.getElementById("pass").value) == false)
              msg += "<br/>  הססמא מכילה תווים אסורים  <br/>";
      
        else
          if ((document.getElementById("pass").value.length < 4) || (document.getElementById("pass").value.length > 12))
              msg += "<br/>  הססמא חייבת להכיל 4-12 תווים  <br/>";
        
        if (document.getElementById("female").checked==false && document.getElementById("other").checked==false && document.getElementById("male").checked==false)   //áãé÷ú øùéîä ðâììú
            msg += "<br/>  יש לבחור מגדר  <br/>";
           
        if (msg.length == 0)
        {
            document.getElementById('errors').innerHTML = ("מולא כנדרש");
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
    <div style="background-image:url(images/books6.jpg);background-size:cover; margin-left:0; height:700px; width:1250px ">
           
            <h4 id="errors" ></h4>
            <%=RegStatus %>
        <br />
        <h1>הכנס פרטים על מנת להרשם:</h1>
        <form name="registerfrm" method="post" action="Register.aspx" style="font-size:larger" onsubmit="return checkForm();">
            שם פרטי: <input type="text" name="fname" id="fname"  />
            <br />
            שם משפחה: <input type="text" name="lname" id="lname" />
            <br />
            שם משתמש: <input type="text" name="uname" id="uname" maxlength="12" />
            <br />
            אימייל: <input type="text" name="email" id="email"  />
            <br />
            סיסמא: <input type="password" name="pass" id="pass"  />
            <br />
            <br />
            מגדר: <input type="radio" name="gender" id="male" value="זכר"/>זכר
            <input type="radio" name="gender" id="female" value="נקבה"/>נקבה
            <input type="radio" name="gender" id="other" value=" אחר"/>אחר
            <br />
            <br />
            תאריך לידה:
            <input type="date" name="Date" id="Date"/>
            <br />
            <br />
            <input type="submit" name="submit" value="שלח" />
            <br />
        </form>
       </div>
     <div id="footer">
            Copyright © AmitShavit
        </div>

</body>
</html>
