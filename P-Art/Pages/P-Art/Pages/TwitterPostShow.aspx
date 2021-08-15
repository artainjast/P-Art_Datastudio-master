<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="TwitterPostShow.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.TwitterPostShow" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <%--    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.zoom.js") %>' type="text/javascript"></script>--%>
    <style type="text/css">
        span.highlightOk, span.highlight {
            padding: 0 .3em;
            color: #111;
            background-color: #ff0;
            cursor: pointer;
            border-radius: .5em;
            -moz-border-radius: .5em;
            -webkit-border-radius: .5em;
            -oz-border-radius: .5em;
        }
    </style>
</asp:Content>
<asp:Content ID="post_details" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <asp:HiddenField ID="NewsIdHiddenField" runat="server" />
<%--    <div class="PageSubLink">
    </div>--%>
    <article>
        <div class="post_details persian">
            <div class="post-image">
                <asp:Image runat="server" ID="img_post" />

            </div>
            <div class="postDetailsText">

                <div class="post-body">
                    <p id="LblNewsBody" runat="server">
                    </p>
                </div>
                <div class="meta">
                    <br />
                    <hr />
                    <br />

                    <div class="spans">
                        <span class="newsMetaData"><i class="far fa-calendar-alt ControlLeftMinPadding"></i>زمان</span>
                        <asp:Label ID="lblNewsDate" runat="server" />
                    </div>

                    <div class="spans">
                        <span class="newsMetaData"><i class="fas fa-link ControlLeftMinPadding"></i>کاربر توییتر</span>
                        <asp:Label ID="UserLabel" runat="server" />
                    </div>

                    <div class="spans">
                        <span class="newsMetaData"><i class="fas fa-key ControlLeftMinPadding"></i>کلید واژه</span>
                        <asp:Label ID="KeywordTitle" runat="server" />
                    </div>

                    <div class="spans">
                        <span class="dark newsMetaData"><i class="fas fa-book ControlLeftMinPadding"></i>لینک منبع</span>
                        <a href="#" runat="server" target="_blank" id="lnk_news" rel="nofollow" class="btn btn-outline-success cur-p">لینک توییت</a>
                    </div>

                </div>
            </div>
        </div>
    </article>
    <script src="/Pages/P-Art/Scripts/highlight.js"></script>
    <script type="text/javascript">
        $(window).load(function () {

        });
    </script>
    <script>
        $('#EditNews').click(function () {
            $('div.newsInputForm').fadeToggle(500);
        });



    </script>
</asp:Content>

