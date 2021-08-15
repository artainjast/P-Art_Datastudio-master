<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlListNews.aspx.cs" Inherits="P_Art.HtmlListNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/htmlListBultan.css" rel="stylesheet" />
<%--    <link href="/Styles/htmlListBultan.css?ver=10.8" rel="stylesheet" />--%>
    <style type="text/css" media="print">
    </style>
    <meta charset="utf-8" />
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no, width=device-width" />
    <meta http-equiv="Content-Security-Policy" />
    <link href="/Styles/WorkResponsive.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.8.1.min.js"></script>
    <script src="/Scripts/jquery.lazy.min.js"></script>
    <script src="/Scripts/localScroll.js"></script>

    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.fancybox.js"></script>
    <link href="/Pages/P-Art/Styles/jquery.fancybox.css" rel="stylesheet" />
    <script type="text/javascript">
        $(".fancyboxGallery").fancybox();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: none;">
            <asp:HiddenField runat="server" ID="hdfDate" />
            <asp:HiddenField runat="server" ID="hdfToDate" />
            <asp:HiddenField runat="server" ID="hdfParmin" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hdfSelectedBultan" />
            <asp:HiddenField runat="server" ID="hdfBultanArchiveID" />
            <asp:HiddenField runat="server" ID="hdfSelectedNews" />
            <asp:HiddenField runat="server" ID="hdfAllowHighlight" />
            <asp:HiddenField runat="server" ID="hdfAllowGroup" />
            <asp:HiddenField runat="server" ID="hdfGalleryNewspaper" />
            <asp:HiddenField runat="server" ID="hdfArz" />
            <asp:HiddenField runat="server" ID="hdfSima" />
            <asp:HiddenField runat="server" ID="hdfAllowrelated" />
            <asp:HiddenField runat="server" ID="hdfAllowNewspaper" />
            <asp:HiddenField runat="server" ID="hdfBultanType" />
        </div>
        <div class="homeBody">
            <asp:HiddenField runat="server" ID="hdfGroups" />
            <div class="newsContainer">
                <asp:Literal runat="server" ID="ltNewsHtml"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
