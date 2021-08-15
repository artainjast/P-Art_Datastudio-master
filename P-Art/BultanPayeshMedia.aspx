<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BultanPayeshMedia.aspx.cs" Inherits="P_Art.BultanPayeshMedia" %>

<%@ Register Src="~/UserControls/UC_ChartWelcome_Bultan.ascx" TagPrefix="uc1" TagName="UC_ChartWelcome_Bultan" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <link href="/Pages/P-Art/Styles/PanelStyle.css" rel="stylesheet" />
    <link href="/Styles/BultanPayeshMedia.css?ver=1.3" rel="stylesheet" />
    <script src='/Pages/P-Art/Scripts/jquery.min.js' type="text/javascript"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/highcharts.js") %>'></script>
    <!-- cdnjs -->
    <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery.lazy/1.7.9/jquery.lazy.min.js"></script>
    <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery.lazy/1.7.9/jquery.lazy.plugins.min.js"></script>
    <meta charset="utf-8" />
    <%-- <link href="Pages/P-Art/Styles/MainStyle.css" rel="stylesheet" />--%>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no, width=device-width" />
    <meta http-equiv="Content-Security-Policy" />
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hdfAllowChart" />
        <asp:HiddenField runat="server" ID="hdfBultanArchiveID" />

        <div class="home">
            <div class="newsContainer">




                <div style="display: none;">
                    <asp:HiddenField ID="hddFrom" runat="server" />
                    <asp:HiddenField ID="hddTo" runat="server" />
                </div>
                <asp:Literal runat="server" ID="ltPostCoverHtml"></asp:Literal>
             <uc1:UC_ChartWelcome_Bultan runat="server" ID="UC_ChartWelcome_Bultan" />
                <asp:Literal runat="server" ID="ltPostHtml"></asp:Literal>
            </div>
        </div>
    </form>
    <%-- <script src="/Scripts/jquery-1.8.1.min.js"></script>--%>
    <script src="/Scripts/jquery.lazy.min.js"></script>
    <script src="/Scripts/localScroll.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.fancybox.js"></script>
    <link href="/Pages/P-Art/Styles/jquery.fancybox.css" rel="stylesheet" />

    <script>
        $(function () {
            $('.lazy').Lazy();
        });
    </script>
</body>
</html>
