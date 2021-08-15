<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="DataCenterShowNews.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.DataCenterShowNews" %>

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
    
    <div class="PageSubLink">
        <ul>
            <li><a id="SaveNewsButton" href="#" runat="server" onserverclick="SaveNewsButton_click"><span><i class="fas fa-save"></i></span>ذخیره خبر</a></li>
            <li><a id="EditNews" runat="server"><span><i class="fas fa-key"></i></span>ویرایش خبر</a></li>
            <li><a id="DataCenterArchiveNewsButton" runat="server" href="DataCenterNewsArchive.aspx"><span><i class="far fa-list-alt"></i></span>اخبار ذخیره شده</a></li>
        </ul>
    </div>

    <div class="newsInputForm">
        <div class="title">
            <span>ویرایش خبر</span>
            <a id="inputFormCloseButton" href="#">
                <span class="red"><i class="far fa-times-circle fa-lg"></i></span>
            </a>
        </div>
        <div class="newsInputFormBody">
            <table>
                <tr>
                    <td>عنوان خبر</td>
                    <td>
                        <input type="text" id="NewsTitleText" class="textbox" runat="server"/></td>
                </tr>
                <tr>
                    <td>خلاصه خبر</td>
                    <td>
                        <textarea id="NewsLeadText" class="textbox" rows="5" runat="server"></textarea></td>
                </tr>
                <tr>
                    <td>متن خبر</td>
                    <td>
                        <textarea id="NewsBodyText" class="textbox" rows="10" runat="server"></textarea></td>
                </tr>

            </table>
            <button id="SaveNewsEditButton" runat="server" onserverclick="SaveNewsEditButton_click" class="btn btn-success cur-p" style="float:left;">ثبت ویرایش</button>
            <br />
        </div>



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
                <div class="post-title">
                    <h1>
                        <asp:Label ID="lblNewsTitle" runat="server" />
                    </h1>
                </div>
                <div class="post-lead">
                    <p id="lblNewsLead" runat="server"></p>
                </div>
                <div class="post-body">
                    <p id="LblNewsBody" runat="server">
                    </p>
                </div>
                <div class="meta">
                    <br />
                    <hr />
                    <br />

                    <div class="spans">
                        <span class="dark newsMetaData"><i class="fas fa-book ControlLeftMinPadding"></i>منبع خبر</span>
                        <asp:Label ID="lblSource" runat="server" />
                    </div>
                    <div class="spans">
                        <span class="newsMetaData"><i class="far fa-calendar-alt ControlLeftMinPadding"></i>زمان خبر</span>
                        <asp:Label ID="lblNewsDate" runat="server" />
                    </div>
                    <div class="spans">
                        <span class="newsMetaData"><i class="far fa-user-circle ControlLeftMinPadding"></i>کاربر</span>
                        <asp:Label ID="lblNewsUser" runat="server" />
                    </div>
                    <div class="spans">
                        <span class="newsMetaData"><i class="fas fa-link ControlLeftMinPadding"></i>لینک خبر</span>
                        <a href="#" runat="server" id="lnk_news" rel="nofollow">لینک خبر</a>
                    </div>
                    <div class="spans" id="divKeyword" runat="server">
                        <span class="newsMetaData"><i class="fas fa-key ControlLeftMinPadding"></i>کلید واژه</span>
                        <asp:Label ID="lblKeywordName" runat="server" />
                    </div>
                    <div class="spans" id="div_manage" runat="server">
                        <span class="newsMetaData"><i class="icon-user icon-white ControlLeftMinPadding"></i>مدیریت :</span>
                        <asp:Button ID="btn_remove" runat="server" CssClass="ButtonRed" Text="حذف خبر" Style="float: right" OnClick="btn_remove_Click" />
                    </div>
                </div>
            </div>
        </div>
    </article>
    <script src="/Pages/P-Art/Scripts/highlight.js"></script>
    <script type="text/javascript">
        $(window).load(function () {

            <%--  var txtData = $('#<%= lblKeywordName.ClientID %>').text();

            if (txtData != null && txtData !== "") {
                var tagList = txtData.split('/');
                $.each(tagList, function (index) {
                    var $this = tagList[index].trim();
                    if ($this != '') {   // alert($this);

                        var TableOfContentsSplit = $this.split('+');

                        $.each(TableOfContentsSplit, function (number) {
                            if (TableOfContentsSplit[number] == null || TableOfContentsSplit[number] == "")
                                return;


                            //newsMerge = newsMerge.Replace("-", " ");
                            //newsMerge = newsMerge.Replace(".", " . ");
                            //newsMerge = newsMerge.Replace(":", " : ");
                            //newsMerge = newsMerge.Replace("?", " ? ");
                            //newsMerge = newsMerge.Replace("!", " ! ");
                            //newsMerge = newsMerge.Replace("،", " ، ");
                            //newsMerge = newsMerge.Replace(",", " , ");

                            //newsMerge = " " + newsMerge + " ";


                          //  alert(TableOfContentsSplit[number]);
                            $('#<%= lblNewsTitle.ClientID %>').highlight(TableOfContentsSplit[number]);
                            $('#<%= lblNewsLead.ClientID %>').highlight(TableOfContentsSplit[number]);
                            $('#<%= LblNewsBody.ClientID %>').highlight(TableOfContentsSplit[number]);
                        })
                    }
                });
            }--%>

        });
    </script>
    <script>
        $('#EditNews').click(function () {
            $('div.newsInputForm').fadeToggle(500);
        });

        $('#inputFormCloseButton').click(function () {
            $('div.newsInputForm').fadeOut(500)
        });
    </script>
</asp:Content>
