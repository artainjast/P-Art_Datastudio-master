<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/SiteV2.Master"
    AutoEventWireup="true" CodeBehind="NewsTimeLine.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.NewsTimeLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href='<%= ResolveUrl("~/Pages/P-Art/Styles/jquery-ui.css")%>' />
    <%-- <link href='<%= ResolveUrl("~/Pages/P-Art/Styles/owl.carousel.css")%>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/Pages/P-Art/Styles/owl.theme.default.css")%>' rel="stylesheet" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/owl.carousel.js")%>' type="text/javascript"></script>--%>
    <script src="/Pages/P-Art/owl.carousel.js"></script>
    <link href="/Pages/P-Art/Styles/owl.carousel.css" rel="stylesheet" />
    <link href="/Pages/P-Art/Styles/owl.theme.css" rel="stylesheet" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>
    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
    <style>
        .owl-carousel {
            direction: rtl !important;
        }
    </style>
    <script>
        $(document).ready(function () {

            $("#divTimeLineBody").owlCarousel({

                navigation: true, // Show next and prev buttons
                navigationText: [">", "<"],
                slideSpeed: 300,
                paginationSpeed: 400,
                autoPlay: 5000,
                paginationSpeed: 400,
                goToFirst: true,
                items: 5,
                margin: 10,
                rtl: true,
                itemsDesktop: false,
                itemsDesktopSmall: false,
                itemsTablet: false,
                itemsMobile: false

            });


            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

            $("#linkTimeLine").click(function () {
                $("#divEventFilter").slideUp();
                $("#divFilter").slideDown();
                $("#divReportCommands").slideUp();
            });

            $("#linkEvent").click(function () {
                $("#divFilter").slideUp();
                $("#divEventFilter").slideDown();
                $("#divReportCommands").slideUp();
            });
            $("#linkReport").click(function () {
                $("#divFilter").slideUp();
                $("#divEventFilter").slideUp();
                $("#divReportCommands").slideDown();
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:HiddenField ID="hdfUserCustomSort" runat="server" />
    <div class="newsStream">
        <div class="navTimeLine">
            <ul>
                <li>
                    <a runat="server" id="linkTimeLine">شناسایی جریان خبری</a>
                </li>
                <li>
                    <a runat="server" id="linkReleaseNews">سیر انتشار</a>
                </li>
                 <li style="display:none;">
                    <a runat="server" id="linkEvent">موضوع رویداد</a>
                </li>
                <li>
                    <a runat="server" id="linkReport">گزارشات</a>
                </li>
                  <li style="display:none;">
                    <a runat="server" id="linkImportData">ورود اطلاعات</a>
                </li>
            </ul>
        </div>
        <div id="divFilter" style="display: none;" class="filter-news">
            <span>از تاریخ :</span>
            <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="margin: 0; width: 120px;" />
            <span>از ساعت:</span>
            <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" Style="direction: ltr; width: 50px;" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour" Font-Size="25px"
                ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
            </asp:RegularExpressionValidator>
            <span>تا تاریخ :</span>
            <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 120px; margin: 0;" />
            <span>تا ساعت:</span>
            <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" Style="direction: ltr; width: 50px;" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour" Font-Size="25px"
                ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
            </asp:RegularExpressionValidator>
            <span>کلید واژه:</span>
            <asp:TextBox ID="txtSeacrh" runat="server" CssClass="textbox" />
            <asp:Button ID="btn_ShowNews" runat="server" Style='padding: 5px 12px;' CssClass="BlueButton" Text="جریان یابی" OnClick="btn_ShowNews_Click" />
        </div>
        <div id="divEventFilter" style="display: none;" class="filter-news">
            <span>موضوع :</span>
            <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Style="margin: 0; width: 220px;" />
            <span>از تاریخ :</span>
            <asp:TextBox ID="txtFromDate_Event" runat="server" CssClass="textbox" Style="margin: 0; width: 120px;" />
            <span>از ساعت:</span>
            <asp:TextBox ID="txtFromHour_Event" runat="server" CssClass="textbox" Style="direction: ltr; width: 50px; margin: 0; font-family: Tahoma;" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
                ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
            </asp:RegularExpressionValidator>
            <span>تا تاریخ :</span>
            <asp:TextBox ID="txtToDate_Event" runat="server" CssClass="textbox" Style="width: 120px; margin: 0;" />
            <span>تا ساعت:</span>
            <asp:TextBox ID="txtToHour_Event" runat="server" CssClass="textbox" Style="direction: ltr; width: 50px; margin: 0; font-family: Tahoma;" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour"
                ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
            </asp:RegularExpressionValidator>
            <asp:Button ID="btnShowEvent" runat="server" Style='padding: 5px 12px;' CssClass="BlueButton" Text="نمایش رویداد" OnClick="btnShowEvent_Click" />
        </div>
        <div id="divReportCommands" style="display: none;" runat="server" class="divReportCommands filter-news">
            <div class="divReportButton">
                <asp:Button Text="خروجی جریان خبری" ID="btnGetTimeLineReport" runat="server" OnClick="btnGetTimeLineReport_Click"
                    class="flat-gray-button" />
            </div>
            <div class="clearfix"></div>
            <div class="divReportOption">
                <asp:CheckBox ID="check_IsCover" Checked="true" runat="server" Text="رو جلد" />
                <asp:CheckBox ID="check_IsAboutPayesh" runat="server" Text="درباره پایش" />
                <asp:CheckBox ID="check_IsAboutProject" runat="server" Text="درباره پروژه" />
                <asp:CheckBox ID="check_IsFehrest" runat="server" Text="فهرست " />
                <asp:CheckBox ID="check_IsProjectSubject" runat="server" Text="موضوع پروژه" />
            </div>
            <div class="clearfix"></div>
            <div class="divReportDetail">
                <label>
                    عنوان گزارش :
                </label>
                <asp:TextBox ID="txt_reportTitle" runat="server" CssClass="textbox" Text="فاقد عنوان" />
                <label>
                    موضوع پروژه :
                </label>
                <asp:TextBox ID="txt_subjectProject" runat="server" Width="200px" CssClass="textbox" Text="فاقد عنوان" />
                <label>
                    درباره پروژه :
                </label>
                <asp:TextBox ID="txt_aboutProject" runat="server" Width="200px" CssClass="textbox" Text="فاقد عنوان" />
                <label>
                    قالب چاپی :
                </label>
                <asp:DropDownList ID="drp_template" runat="server" CssClass="textbox" Style="width: 102px;" />
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="timeLineSection">
            <div runat="server" id="divTimeLineBody" class="owl-carousel owl-theme">
                <asp:Repeater ID="rptTimeLine" runat="server" OnItemDataBound="rptTimeLine_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="show">
                            <div class="post-timeline relation" runat="server">
                                <asp:LinkButton data-newsid='<%# Eval("NewsId") %>' CommandArgument='<%# Eval("NewsId") %>' runat="server" ID="btnTreeLink" OnClick="btnTreeLink_Click">
                                    <img src='<%#Eval("NewsPicture") %>' />
                                    <h2><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),150) %></h2>
                                </asp:LinkButton>
                                <span class="number">
                                    <%# Container.ItemIndex + 1 %>
                                </span>
                                <span class="source">
                                    <%#Eval("SiteTitle") %>
                                </span>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div id="divFehrest" class="Fehrest" runat="server">
                <asp:Repeater ID="rptFehrest" runat="server" OnItemDataBound="rptFehrest_ItemDataBound">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hddRelated" runat="server" Value='<%# Eval("RelatedNewsStringIds") %>' />
                        <asp:HiddenField ID="hddNewsId" runat="server" Value='<%# Eval("NewsId") %>' />
                        <div class="showFehrest">
                            <div class="post-fehrest" runat="server">
                                <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                                <h2><a id='showLead_<%# Eval("NewsId") %>' data-lead='<%# Eval("NewsLead") %>' data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" class="detailLead"><i class="fa fa-plus"></i></a>
                                    <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                        runat="server"><span class="newsIndex"><%# Container.ItemIndex + 1 %></span><span class="newsIndex">-</span><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),120) %> </a>(<span><%# Eval("SiteTitle") %></span>)</h2>
                                <span class="site-count"><%# Eval("RelateListIdsCount").ToString() %></span>
                            </div>
                            <div><span class="site-title"><%# Eval("RelateListSites").ToString() %></span></div>
                            <div class="clearfix"></div>
                            <div id='divSelectLead_<%# Eval("NewsId") %>' class="divSelectLead clearfix" style="height: 0px;"></div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
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
                            <div class='newsItemBody <%# String.Format("newsItemBodyBg{0}", Eval("NewsValue")) %>'>
                                <span class="node"></span>
                                <div class="newsItemRelate">
                                    <b class="numberTree">
                                        <%# Container.ItemIndex + 1 %>
                                    </b>
                                    <img class="siteimg" src='<%# Eval("SiteLogo") %>' />
                                    <h2>
                                        <img class="bullet" src="/Pages/P-Art/Images/bl.gif" />
                                        <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                            runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),150) %> </a></h2>
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
            </div>
            <div class="loader-main" runat="server" id="divLoad">
                <div class="loader"></div>
                <span>جریان خبری را آغاز کنید</span>
            </div>
        </div>
        <div class="eventSection"></div>
        <div class="clearfix"></div>
    </div>
    <script>
        function ShowLead(element) {
            var newsId = $(element).attr('data-newsid');
            var $divSelectLead = $(element).parent().parent().parent().parent().parent().find('#divSelectLead_' + newsId);
            if ($(element).attr('class').indexOf('active') > -1) {
                $divSelectLead.html('');
                $divSelectLead.animate({ 'height': 0 });
                $(element).removeClass('active');
                return;


            }
            $(element).addClass('active');
            var lead = "<div id='divlead' ><p>" + $(element).attr('data-lead') + "</p></div>";

            $divSelectLead.html('');

            $divSelectLead.html(lead);

            $divSelectLead.animate({ 'height': $('#divlead').height() + 40 });

        }
    </script>
</asp:Content>





