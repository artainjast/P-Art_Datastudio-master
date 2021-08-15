<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportBultanStimul.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.ExportBultanStimul" %>

<%@ Register assembly="Stimulsoft.Report.Web, Version=2014.3.0.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" namespace="Stimulsoft.Report.Web" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
     
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div>

           <cc1:StiWebViewer ID="StiWebViewer1" runat="server" />

       </div>
    </form>
</body>
</html>
