<%@ Page Title="" Language="C#"
    AutoEventWireup="true" CodeBehind="PrintLead.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.PrintLead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/MainStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <section id="print-news">
            <asp:Repeater ID="grd_news" runat="server" 
                OnItemDataBound="grd_news_ItemDataBound">

                <ItemTemplate>
                    <div class="print-row">
                        <h1>
                            <%#Eval("NewsTitle") %>
                        </h1>
                        <h2>
                            <%#Eval("SiteTitle") %>   <%#Eval("NewsDate") %>
                        </h2>
                        <h3 id="NewsLead" runat="server">
                            <%#Eval("NewsLead") %>
                        </h3>
                        
                    </div>
                </ItemTemplate>

            </asp:Repeater>
        </section>
    </form>
</body>
</html>

