<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBultanNewsItem.aspx.cs" Inherits="P_Art.ShowBultanNewsItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/htmlGroupBultan.css?ver=4.9" rel="stylesheet" />
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no, width=device-width" />
    <meta http-equiv="Content-Security-Policy" />
    <style type="text/css" media="print">
        .fixed-table-of-content {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="newsContainer">
            <asp:Literal runat="server" ID="ltNews"></asp:Literal>
        </div>
    </form>
</body>
</html>
