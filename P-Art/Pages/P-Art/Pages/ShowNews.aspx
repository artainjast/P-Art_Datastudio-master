<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="ShowNews.aspx.cs" Inherits="PArt.Pages.P_Art.Pages.ShowNews"
    EnableViewState="false" %>

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
                        <a href="#" runat="server" id="lnk_news" rel="nofollow" class="btn btn-outline-success cur-p">لینک خبر</a>
                    </div>
                    <div class="spans" id="divKeyword" runat="server">
                        <span class="newsMetaData"><i class="fas fa-key ControlLeftMinPadding"></i>کلید واژه</span>
                        <asp:Label ID="lblKeywordName" runat="server" />
                    </div>
                    <div class="spans" id="div_manage" runat="server">
                        <span class="newsMetaData"><i class="icon-user icon-white ControlLeftMinPadding"></i>مدیریت :</span>
                        <%--<asp:Button ID="btn_remove" runat="server" CssClass="btn btn-outline-danger cur-p" Text="حذف خبر" Style="display:none;" OnClick="btn_remove_Click"/>--%>
                        <asp:Button ID="btn_remove" runat="server" CssClass="btn btn-outline-danger cur-p" Text="حذف خبر" Style="display:none;" />
                        <a id="EditNewsButton" runat="server" class="btn btn-outline-primary cur-p" target="_blank"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>ویرایش خبر</a>
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
</asp:Content>
