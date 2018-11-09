<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LMS.aspx.cs" Inherits="LMSWeb.WebFormLMS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LMS</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size:larger">Hej och välkommen!!
        </div>
        <div>...</div>

        <%--@Html.ActionLink("Button name", "Stat", "StatisticsController") --%>
        
        <input type='button' value='Open LMS-Statistics' id='myButton' onclick='redirectOnClick()' />
        <script>
        function redirectOnClick(){
            document.location ='Statistics/Stat';
        }
        </script>
    </form>
</body>
</html>
