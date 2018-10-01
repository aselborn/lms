<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FusionExample.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FusionCharts Integration in a Simple ASP.NET Web Aplication</title>
    <script src="Scripts/fusioncharts.js"></script>
    <script src="Scripts/fusioncharts.charts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <asp:Literal ID="chart" runat="server"></asp:Literal>
    </form>
</body>
</html>
