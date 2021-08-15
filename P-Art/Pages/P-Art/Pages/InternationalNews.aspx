<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="InternationalNews.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.InternationalNews" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href='<%= ResolveUrl("~/Pages/P-Art/Styles/jquery-ui.css")%>' />
    <link href='<%= ResolveUrl("~/Pages/P-Art/Styles/owl.carousel.css")%>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/Pages/P-Art/Styles/owl.theme.default.css")%>' rel="stylesheet" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/owl.carousel.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.carouFredSel-6.1.0-packed.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.mousewheel.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.touchSwipe.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.ba-throttle-debounce.min.js")%>' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/jquery.qtip.js"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>' type="text/javascript"></script>
    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />

    <style type="text/css">
        .Fehrest i.icon-move {
            /*background-image: url(/styles/img/glyphicons-halflings-white.png);*/
            background-image: url(/styles/img/glyphicons-halflings.png);
            background-position: -168px -72px;
            display: inline-block;
            width: 14px;
            height: 14px;
            line-height: 14px;
            vertical-align: text-top;
            /* background-image: url(../img/glyphicons-halflings.png); */
            /* background-position: 14px 14px; */
            background-repeat: no-repeat;
        }


        body.dragging, body.dragging * {
            cursor: move !important;
        }

        .dragged {
            position: absolute;
            opacity: 0.5;
            z-index: 2000;
        }

        .newsTags a {
            color: #999;
            margin-left: 5px;
            display: inline-block;
            padding: 2px 4px;
            background: rgba(245, 240, 240, 0.70);
            border-radius: 4px;
            margin-bottom: 4px;
            /*font-size: 16px;
                font-weight: 500;
                margin-right: 102px;
                background: #ec5343;
                color: white;
                border: 1px solid;
                padding: 1px 10px;*/
        }

        ol.example li.placeholder {
            position: relative;
            /** More li styles **/
        }

            ol.example li.placeholder:before {
                position: absolute;
                /** Define arrowhead **/
            }
    </style>

    <script>

        $(function () {
            Page_Init();
        });
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

            $("#linkTimeLine").click(function () {
                $("#divFilter").fadeToggle(1000);
            });

            $("#linkEvent").click(function () {
                $("#divFilter").slideUp();
                $("#divEventFilter").slideDown();
                $("#divReportCommands").slideUp();
            });
            $("#linkReport").click(function () {
                $("#divReportCommands").fadeToggle(1000);
            });
            $('.owl-carousel').owlCarousel({
                autoPlay: 7000,
                speed: 4000,
                lazy: true,
                rtl: true,
                loop: false,
                margin: 10,
                nav: true,
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 3
                    },
                    1000: {
                        items: 5
                    }
                }
            })
        }


    </script>

</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <asp:HiddenField ID="hdfUserCustomSort" runat="server" />

    <div class="PageSubLink">
        <ul>
            <li><a runat="server" id="linkTimeLine"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a runat="server" id="linkReport"><span><i class="fas fa-file-alt"></i></span>گزارش ها</a></li>
        </ul>
    </div>
    <div id="divFilter" class="filterNewsInternational">
        <span>از تاریخ</span>
        <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="min-width: 65px; width: 10%;" />
        <span>ساعت</span>
        <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" Style="min-width: 40px; width: 6%;" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour" Font-Size="25px"
            ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
        </asp:RegularExpressionValidator>
        <span>تا تاریخ</span>
        <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="min-width: 65px; width: 10%;" />
        <span>ساعت</span>
        <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" Style="min-width: 40px; width: 6%;" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour" Font-Size="25px"
            ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
        </asp:RegularExpressionValidator>
        <br />
        <br />
        <span>کلید واژه</span>
        <asp:TextBox ID="txtSeacrh" runat="server" CssClass="textbox" Style="min-width: 100px; width: 15%;" />
        <span>نام منبع</span>
        <asp:DropDownList ID="drp_NewsSource" runat="server" CssClass="btn btn-outline-info cur-p dropdown" Style="min-width: 120px; width: 17%;" />
        <asp:Button ID="btn_ShowNews" runat="server" class="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
    </div>

    <div id="divEventFilter" class="filterNews" style="display: none">

        <span>از تاریخ</span>
        <asp:TextBox ID="txtFromDate_Event" runat="server" CssClass="textbox" Width="100px" />
        <span>ساعت</span>
        <asp:TextBox ID="txtFromHour_Event" runat="server" CssClass="textbox" Width="60px" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
            ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
            ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
        </asp:RegularExpressionValidator>
        <span>تا تاریخ</span>
        <asp:TextBox ID="txtToDate_Event" runat="server" CssClass="textbox" Width="100px" />
        <span>ساعت</span>
        <asp:TextBox ID="txtToHour_Event" runat="server" CssClass="textbox" Width="60px" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
            ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour"
            ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
        </asp:RegularExpressionValidator>
        <br />

        <span>موضوع</span>
        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="50%" />
        <asp:Button ID="btnShowEvent" runat="server" CssClass="btn btn-info cur-p" Text="نمایش رویداد" OnClick="btnShowEvent_Click" />
    </div>


    <div id="divReportCommands" runat="server" class="divReportCommands filterNews">
        <div class="divReportDetail">
            <label>عنوان بولتن</label>
            <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" placeholder="فاقد عنوان" />
            <asp:CheckBox ID="check_IsCover" Checked="true" runat="server" Text="رو جلد" CssClass="CheckBox" />
            <asp:CheckBox ID="check_IsFehrest" runat="server" Text="فهرست" CssClass="CheckBox" />
            <asp:CheckBox ID="check_highlight" runat="server" Text="هايلايت کليد واژه ها" CssClass="CheckBox" />

        </div>
        <br />
        <div class="divReportButton">
            <a id="btn_generateGroupHtml" runat="server" onclick="GetInternationalHTMLBultan(this)" class="btn btn-success cur-p">بولتن موضوعی</a>
            <a id="btn_generateGroupHtml1" runat="server" onclick="GetGroupInternationalTitrHTMLBultan(this)" class="btn btn-info cur-p">گزارش هفتگی</a>
            <%--  <a id="btn_generateGroupHtml3" runat="server" onclick="GetInternationalHTMLBultan(this)" class="btn btn-primary cur-p">تلگرام</a>--%>
        </div>
    </div>
    <div class="newsStream persian">
        <div class="divReportOption">
        </div>
        <div class="timeLineSection">
            <div id="divFehrest" class="Fehrest" runat="server">
                <asp:Repeater ID="rptFehrest" runat="server" OnItemCommand="rptFehrest_ItemCommand" OnItemDataBound="rptFehrest_ItemDataBound">
                    <HeaderTemplate>
                        <div class="news_list4">
                            <div class="newsStreamHeader">
                                <asp:CheckBox class="flat-gray-all-button selectAllCheckBox CheckBox" ID="btn_SelectAllInternational" Text="انتخاب تمامی اخبار" runat="server" />
                                <a id="btnBultan" href="#" runat="server" onclick="setOrderNewsIds()" class="flat-gray-top-button SaveListOrderButton"><span class="ControlLeftMinPadding"><i class="fas fa-save fa-lg"></i></span>ذخیره اولویت نمایش</a>
                            </div>
                            <ol>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="showFehrest">
                            <div class="post-fehrest" runat="server">
                                <asp:HiddenField ID="hddNewsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                <asp:HiddenField ID="txt_row_index" runat="server" Value='<%# Eval("SortOrder") %>' />
                                <span class="rowIndex internationalRowIndex"><%# Container.ItemIndex + 1 %> )</span>
                                <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews CheckBox" />
                                <span class="moveRow"><i class="icon-move fa-2x"></i></span>
                                <h2>

                                    <a data-lead='<%# Eval("NewsTitle") %>' data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("KeywordId") %>' data-link='<%# Eval("NewsLink2")%>' data-keyword='<%# Eval("KeywordName") %>' data-order="" class="detailLead">
                                        <%--<img class="siteimg" src='<%# Eval("SiteLogo") %>' />--%>
                                    </a>
                                    <a data-keyid='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordName") %>' target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                        runat="server">
                                        <%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),100) %></a>

                                </h2>
                                <span title='<%# Eval("SiteTitle") %>' class="siteTitle" style="left: 280px;"><%# Eval("SiteTitle") %></span>
                                <%--<img class="siteimg" title='<%# Eval("SiteTitle") %>' src='<%# Eval("SiteLogo") %>' />--%>
                                <%-- <img class="imglogo" src='<%#Eval("SiteLogo") %>' />--%>

                                <asp:ImageButton class="ImageButton" ID="btnSendTelegram" CommandName="sendTeleram" CommandArgument='<%# Eval("NewsId")%>' runat="server" ImageUrl="~/Pages/P-Art/Images/telegram-icon.png" ToolTip="ارسال به تلگرام" />
                                <span class="detailToggle"><i class="fa fa-bars detailLead" id='showLead_<%# Eval("NewsId") %>' data-lead='<%# Eval("NewsLead") %>' data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("KeywordName") %>'
                                    data-link='<%# Eval("NewsLink")%>' data-keyword='<%# Eval("KeywordName") %>'></i></span>
                                <div class="newsrate" runat="server">
                                    <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId")%>' style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId")%>' style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId")%>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                </div>
                                <span class="rowDateTime ">
                                    <label id="date"><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %></label>

                                </span>


                            </div>

                            <div class="clearfix"></div>
                            <div id='divSelectLead_<%# Eval("NewsId") %>' class="divSelectLead clearfix" style="height: 0px;"></div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ol>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div runat="server" visible="false" class="divTree" id="divTree">
                <asp:Repeater ID="rptTree" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="newsItemBody">
                                <span class="node"></span>
                                <div class="newsItemRelate">
                                    <b class="numberTree">
                                        <%# Container.ItemIndex + 1 %>
                                    </b>
                                    <%-- <img class="siteimg" src='<%# Eval("SiteLogo") %>' />--%>
                                    <h2>
                                        <img class="bullet" src="/Pages/P-Art/Images/bl.gif" />
                                        <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                            runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),100) %> </a></h2>
                                    <span><%# Eval("SiteTitle") %></span> <span><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString())  %></span>
                                </div>
                                <div class="newsrate" runat="server">

                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId")%>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                </div>
                                <div>
                                    <p><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsLead").ToString(),300) %></p>
                                </div>
                            </div>
                            <div style="height: 0px;" class="clearfix"></div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater runat="server" ID="rptSiteSort">
                    <HeaderTemplate>
                        <div class="containerSiteSort right ">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="sortItem">


                            <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                            <i class="remove"></i>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <%--<div class="loader-main" runat="server" id="divLoad">--%>
            <div class="loader2" id="divloader" runat="server">
                <div id="divFehrest1" class="Fehrest" runat="server">

                    <asp:Repeater ID="rptFehrest1" runat="server" OnItemCommand="rptFehrest_ItemCommand">

                        <HeaderTemplate>
                            <div class="news_list4">

                                <div class="newsStreamHeader">
                                    <asp:CheckBox class="flat-gray-all-button selectAllCheckBox CheckBox" ID="btn_SelectAllInternational" Text="انتخاب تمامی اخبار" runat="server" />
                                    <a id="btnBultan" href="#" runat="server" onclick="setOrderNewsIds()" class="flat-gray-top-button SaveListOrderButton"><span class="ControlLeftMinPadding"><i class="fas fa-save fa-lg"></i></span>ذخیره اولویت نمایش</a>
                                </div>

                                <ol>
                        </HeaderTemplate>
                        <ItemTemplate>


                            <div class="showFehrest">

                                <div class="post-fehrest" runat="server">

                                    <asp:HiddenField ID="hddNewsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                    <asp:HiddenField ID="txt_row_index" runat="server" Value='<%# Eval("SortOrder") %>' />
                                    <span class="rowIndex internationalRowIndex"><%# Container.ItemIndex + 1 %> )</span>
                                    <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews CheckBox" />
                                    <span class="moveRow"><i class="icon-move fa-2x"></i></span>
                                    <h2>
                                        <a data-lead='<%# Eval("NewsTitle") %>' data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("KeywordId") %>' data-link='<%# Eval("NewsLink2")%>' data-keyword='<%# Eval("KeywordName") %>' data-order="" class="detailLead">
                                            <%--<img class="siteimg" src='<%# Eval("SiteLogo") %>' />--%>
                                        </a>
                                        <a data-keyid='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordName") %>' target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                            runat="server">
                                            <%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),100) %></a>

                                    </h2>
                                    <span title='<%# Eval("SiteTitle") %>' class="siteTitle"><%# Eval("SiteTitle") %></span>
                                    <%--<img class="siteimg" title='<%# Eval("SiteTitle") %>' src='<%# Eval("SiteLogo") %>' />--%>
                                    <%-- <img class="imglogo" src='<%#Eval("SiteLogo") %>' />--%>
                                    <asp:ImageButton class="ImageButton" ID="btnSendTelegram" CommandName="sendTeleram" CommandArgument='<%# Eval("NewsId")%>' runat="server" ImageUrl="~/Pages/P-Art/Images/telegram-icon.png" ToolTip="ارسال به تلگرام" />
                                    <span class="detailToggle"><i class="fa fa-bars detailLead" id='showLead_<%# Eval("NewsId") %>' data-lead='<%# Eval("NewsLead") %>'
                                        data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("KeywordName") %>'
                                        data-link='<%# Eval("NewsLink")%>' data-keyword='<%# Eval("KeywordName") %>'></i></span>
                                    <div class="newsrate" runat="server">
                                        <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                        <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId")%>'
                                            style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                        <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId")%>'
                                            style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                        <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId")%>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>



                                    </div>
                                    <span class="rowDateTime">
                                        <label id="date"><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %></label></span>


                                </div>

                                <div></div>
                                <div class="clearfix"></div>
                                <div id='divSelectLead_<%# Eval("NewsId") %>' class="divSelectLead clearfix" style="height: 0px;"></div>

                            </div>

                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>

                    </asp:Repeater>

                </div>

            </div>
            <div class="message" runat="server" id="divmessage">
                <span class="alert" runat="server" id="spanalert">
                    <asp:Literal runat="server" ID="literalll"></asp:Literal></span>
            </div>
            <%-- </div>--%>
        </div>
        <div class="eventSection"></div>
        <div class="clearfix"></div>
    </div>
    <script>
        function ShowLead(element) {
            var newsId = $(element).attr('data-newsid');
            var keywordname = $(element).attr('data-keyword');
            var newslink = $(element).attr('data-link');
            var $divSelectLead = $(element).parent().parent().parent().parent().parent().find('#divSelectLead_' + newsId);
            if ($(element).attr('class').indexOf('active') > -1) {
                $divSelectLead.html('');
                $divSelectLead.animate({ 'height': 0 });
                $(element).removeClass('active');
                return;
            }
            $(element).addClass('active');
            var lead = "<div id='divlead' ><p><span style='' class='site-title rowLeadTage' >" + keywordname + "</span></div>";
            $divSelectLead.html('');
            $divSelectLead.html(lead);
            $divSelectLead.animate({ 'height': $('#divlead').height() });

        }
    </script>

    <script type="text/javascript">

        $(".news_list4 ol").sortable({

            // placeholder: "ui-state-highlight"
        });

        $(".news_list4 ol").disableSelection();


        $(window).load(function () {
        });
        function setOrderNewsIds() {
            var counter = 0;
            var str = "";
            $('.showFehrest').each(function () {

                var $this = $(this);


                var hddNewsId = $this.find('#hddNewsId').val();

                var txt_row_index = "10000" + counter;
                counter++;

                str += ";" + hddNewsId + ":" + txt_row_index;

            });

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/ajax.aspx/UpdateInternationalNewsOrders",
                data: "{'newsIds':'" + str + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert('عملیات با موفقیت انجام شد');


                },
                error: function (msg) {

                }
            });
        }

        $(".showFehrest input:checkbox").click(function () {
            $(this).parents(".showFehrest").toggleClass("SetInternationalCeckedbackground");
        });


    </script>
</asp:Content>





