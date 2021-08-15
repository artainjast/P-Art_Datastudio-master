<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="TelegramMessageShow.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.TelegramMessageShow" %>
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
    <div class="PageSubLink">
<%--        <ul>
            <li><a id="EditNews" runat="server"><span><i class="fas fa-key"></i></span>ویرایش خبر</a></li>
            <li><a id="DeleteNews" runat="server" ><span><i class="fas fa-trash-alt"></i></span>حذف خبر</a></li>
            <li><a id="WordExportButton" runat="server" onserverclick="WordExport_click" ><span><i class="fas fa-file-word"></i></span>خروجی ورد</a></li>
            <li><a id="DataCenterArchiveNewsButton" runat="server" href="DataCenterNewsArchive.aspx"><span><i class="far fa-list-alt"></i></span>اخبار ذخیره شده</a></li>
        </ul>--%>
    </div>


    <article>
        <div class="post_details persian">
            <div class="post-image">
                <asp:Image runat="server" ID="img_post" />
                <%--                <span class="zoom">
                    <asp:Image runat="server" ID="img_post" />
                </span>--%>
            </div>
            <div class="postDetailsText">
<%--                <div class="post-title">
                    <h1>
                        <asp:Label ID="lblNewsTitle" runat="server" />
                    </h1>
                </div>
                <div class="post-lead">
                    <p id="lblNewsLead" runat="server"></p>
                </div>--%>
                <div class="post-body">
                    <p id="LblNewsBody" runat="server">
                    </p>
                </div>
                <div class="meta">
                    <br />
                    <hr />
                    <br />

<%--                    <div class="spans">
                        <span class="dark newsMetaData"><i class="fas fa-book ControlLeftMinPadding"></i>منبع خبر</span>
                        <asp:Label ID="lblSource" runat="server" />
                    </div>--%>
                    <div class="spans">
                        <span class="newsMetaData"><i class="far fa-calendar-alt ControlLeftMinPadding"></i>زمان</span>
                        <asp:Label ID="lblNewsDate" runat="server" />
                    </div>
<%--                    <div class="spans" style="display:none">
                        <span class="newsMetaData"><i class="far fa-user-circle ControlLeftMinPadding"></i>کاربر</span>
                        <asp:Label ID="lblNewsUser" runat="server" />
                    </div>--%>
                    <div class="spans">
                        <span class="newsMetaData"><i class="fas fa-link ControlLeftMinPadding"></i>کانال</span>
                        <asp:Label ID="ChannelLabel" runat="server" />
                    </div>
         <%--           <div class="spans" id="divKeyword" runat="server">
                        <span class="newsMetaData"><i class="fas fa-key ControlLeftMinPadding"></i>کلید واژه</span>
                        <asp:Label ID="lblKeywordName" runat="server" />
                    </div>
                    <div class="spans" id="div_manage" runat="server" style="display:none">
                        <span class="newsMetaData"><i class="icon-user icon-white ControlLeftMinPadding"></i>مدیریت :</span>
                        <asp:Button ID="btn_remove" runat="server" CssClass="ButtonRed" Text="حذف خبر" Style="float: right" OnClick="btn_remove_Click" />
                    </div>--%>
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



        $('#DeleteNews').click(function (e) {

            const loader = document.getElementById('loader');
            setTimeout(() => {
                loader.classList.remove('fadeOut');
            }, 300);
            var newsID =  $('#NewsIdHiddenField').val();
            var result = confirm("برای حذف خبر مطمئن هستید؟");

            if (result) {
                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/DataCenterSavedNews.aspx/DeleteDataCenterNews",
                    data: "{'newsId':'" + newsID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                        alert('خبر با موفقیت حذف گردید.');
                        window.location.replace("/Pages/P-Art/Pages/DataCenterNewsArchive.aspx");
                    },
                    error: function (msg) {
                        setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                        alert('حطا در حذف خبر');
                    }
                });
            }
            e.preventDefault();
        });
    </script>
</asp:Content>


