<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="InstagramPostShow.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.InstagramPostShow" %>

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
            <div class="instagramPostContainer">
                <div id="media" class="post-media" runat="server"></div>
                <div class="InstagramPostContents">
                    <div class="userProfilePic">
                        <span class="profileImage">
                            <img id="profilePic" runat="server" onerror="this.src='/Pages/P-Art/Images/profile-insta.jpg'">
                        </span>
                        <span class="fullName" id="fullName" runat="server"></span>
                    </div>
                    <div class="post-body">
                        <p id="LblNewsBody" runat="server">
                        </p>
                    </div>

                    <div class="InstaMetaTag">
                        <div class="spans">
                            <span class="InstaLikeTag"><i class="far fa-heart-o ControlLeftMinPadding"></i>تعداد پسندها</span>
                            <asp:Label ID="likesLabel" runat="server" />
                        </div>
                        <div class="spans">
                            <span class="InstaCommentTag"><i class="far fa-comment-o ControlLeftMinPadding"></i>تعداد نظرات</span>
                            <asp:Label ID="CommentsLabel" runat="server" />
                        </div>
                        <div class="spans">
                            <span class="InstaTimeTag"><i class="far fa-calendar-alt ControlLeftMinPadding"></i>زمان</span>
                            <asp:Label ID="lblNewsDate" runat="server" />
                        </div>

                        <div class="spans">
                            <span class="InstaProfileTag"><i class="fas fa-user-circle-o ControlLeftMinPadding"></i>کاربر اینستاگرام</span>
                            <asp:Label ID="UserLabel" runat="server" />
                        </div>

                        <div class="spans">
                            <span class="InstaKeyTag"><i class="fas fa-key ControlLeftMinPadding"></i>کلید واژه</span>
                            <asp:Label ID="KeywordTitle" runat="server" />
                        </div>

                        <div class="spans">
                            <span class="InstaLinkTag"><i class="fas fa-link ControlLeftMinPadding"></i>لینک</span>
                            <a href="#" runat="server" id="InstaLink" rel="nofollow" class="btn btn-outline-success cur-p" target="_blank">لینک اینستاگرام</a>
                        </div>

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


