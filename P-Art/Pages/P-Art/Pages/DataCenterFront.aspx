<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="DataCenterFront.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.DataCenterFront" %>

<%--<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>--%>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <%-- <script src="/Pages/P-Art/Scripts/jquery-1.8.1.min.js"></script>--%>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.carouFredSel-6.1.0-packed.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.mousewheel.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.touchSwipe.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.ba-throttle-debounce.min.js")%>'
        type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/jquery.qtip.js"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>

    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script>
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

        }
        $(function () {
            $(":checkbox[id=cbSelectAll]").click(function () {
                if ($(this).is(":checked")) {
                    $(":checkbox[id=check_SelectNews]").attr("checked", "checked");
                } else {
                    $(":checkbox[id=check_SelectNews]").removeAttr("checked");
                }
            });
            $(":checkbox[id*=check_SelectNews]").click(function () {
                if ($(":checkbox[id=check_SelectNews]").length == $(":checkbox[id*=check_SelectNews]:checked").length) {
                    $(":checkbox[id=cbSelectAll]").attr("checked", "checked");
                } else {
                    $(":checkbox[id=cbSelectAll]").removeAttr("checked");
                }
            });
        });
        $(".cbSelectAllGroupItem input").live('change', function () {

            var $this = $(this);
            var groupOrder = $this.parent().attr('data-grouporder');
            // alert(groupOrder);
            if ($this.is(":checked")) {
                $(".newsItemGroupOrder" + groupOrder).each(function () {
                    var $thisArticle = $(this);
                    //  console.log($thisArticle.attr('id'));
                    $thisArticle.find('#check_SelectNews').attr("checked", "checked");
                });
                // $("article[data-grouporder='" + groupOrder + "'] checkbox[id=check_SelectNews]").attr("checked", "checked");
            } else {
                // $("article[data-grouporder='" + groupOrder + "'] checkbox[id=check_SelectNews]").removeAttr("checked");
                // $(".newsItemGroupOrder" + groupOrder).each(function () {
                //  var $thisArticle = $(this);
                // console.log($thisArticle.attr('id'));
                // var $thisArticle = $(this);
                //    $thisArticle.find('#check_SelectNews').removeAttr("checked");
                // });
                $(":checkbox[id=check_SelectNews]").removeAttr("checked");
                $(":checkbox[id=check_SelectNews]").attr("checked", false);
                //  $(":checkbox[id*=check_SelectNews]").removeAttr("checked");
                $(".posts article").each(function () {
                    var postRow = $(this);
                    $(postRow).find("#check_SelectNews").attr('checked', false);
                    $(postRow).find("#check_SelectNews").removeAttr('checked');

                });
            }

            // e.preventDefault();
        });
        $(".chbSelectAllGroupItem input").live('change', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $(".cbSelectAllGroupItem input").attr("checked", "checked");

                $(".newsItemGroupOrder").each(function () {
                    var $thisArticle = $(this);

                    $thisArticle.find('#check_SelectNews').attr("checked", "checked");
                });
                // $('#check_SelectNews').attr("checked", "checked");


            } else {
                // $("article[data-grouporder='" + groupOrder + "'] checkbox[id=check_SelectNews]").removeAttr("checked");
                $(".cbSelectAllGroupItem input").removeAttr("checked");
                // $(".newsItemGroupOrder").each(function () {
                $(".newsItemGroupOrder").each(function () {
                    var $thisArticle = $(this);

                    $thisArticle.find('#check_SelectNews').removeAttr("checked");
                });
                //  $('#check_SelectNews').removeAttr("checked");
            }


        });


    </script>
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--    <asp:UpdatePanel ID="updMain" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="UpdateProgressMain" AssociatedUpdatePanelID="updMain">
                <ProgressTemplate>
                    <div class="newsContainerLoader"></div>
                    <div class="newsContainerLoaderText">
                        <img src="/Pages/P-Art/Images/ajax-loader.gif" alt="loader" />
                        <br />
                        در حال دریافت اطلاعات،لطفا منتظر بمانید...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>

    <asp:HiddenField ID="hdfUserCustomSort" runat="server" />
    <asp:HiddenField ID="hdfUserID" runat="server" />
    <div class="PageSubLink">
        <ul>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/keywords" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه</a></li>
            <li><a href="/News/BultanArchive" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="/Pages/P-Art/Pages/SiteSelection.aspx" runat="server"><span><i class="fab fa-osi"></i></span>انتخاب منابع</a></li>
            <li><a href="#" id="lnk_filter" class="flat-gray-button"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
            <li><a href="#" id="lnk_bultan" class="flat-gray-button"><span><i class="fas fa-file-alt"></i></span>بولتن</a></li>
            <li><a href="#" id="lnk_category" class="flat-gray-button"><span><i class="fas fa-cubes"></i></span>دسته بندی اخبار</a></li>
            <li><a href="#" id="SaveSelectedNewsButton" class="flat-gray-button"><span><i class="fas fa-cloud-download-alt"></i></span>ذخیره اخبار انتخاب شده</a></li>
            <li><a id="DataCenterArchiveNewsButton" runat="server" href="DataCenterNewsArchive.aspx"><span><i class="far fa-list-alt"></i></span>اخبار ذخیره شده</a></li>
            <li><a href="#" id="ShowAllKeywords"><span><i class="fas fa-ellipsis-h"></i></span>نمایش کلید واژه ها</a></li>

            
        </ul>
    </div>

    <section class="posts">
        <div class="control-box category NewsKeyBox">
            <asp:Repeater ID="rpt_Groups" runat="server" OnItemDataBound="rpt_Groups_ItemDataBound">
                <ItemTemplate>
                    <div id="group_item" class="group_item" runat="server">
                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                        <span id="color_span" runat="server">
                            <input type="checkbox" id="check_selected_group" runat="server" class="AspCheckBox" />
                        </span>
                        <a href="#" data-id='<%# Eval("KeyId") %>' class="switchkeyword">
                            <label><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("KeywordName")) %></label>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal runat="server" ID="ltKeywords"></asp:Literal>
        </div>
        <div class="control-box filter newsFilter persian">
            <div>
                <span>
                    <span>از تاریخ</span>
                    <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" style="width: 68px;"/>
                </span>
                <span>
                    <span>از ساعت</span>
                    <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align:center" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
                        ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                    </asp:RegularExpressionValidator>
                </span>
                <span>
                    <span>تا تاریخ</span>
                    <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" style="width: 68px;" />
                </span>
                <span>
                    <span>تا ساعت</span>
                    <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" placeholder="  :  "  Style="width: 25px; text-align:center" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour"
                        ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                    </asp:RegularExpressionValidator>
                </span>

            </div>
            <br />
            <div>
                <span>
                    <span>کلید واژه</span>
                    <asp:TextBox ID="txt_search" runat="server" CssClass="textbox" />
                </span>
                <span>
                    <span>منبع خبری</span>
                    <asp:DropDownList ID="drp_NewsSource" Width="95px" runat="server" CssClass="btn btn-outline-info cur-p" Style="min-width: 200px" />
                </span>
                <span>
                    <span>ترتیب نمایش</span>
                    <asp:DropDownList ID="drp_sort" runat="server" CssClass="btn btn-outline-info cur-p" Style="min-width: 200px">
                        <asp:ListItem Text="اولویت کلید واژه ها" Value="0" />
                        <asp:ListItem Text="ساعت خبر" Value="1" />
                    </asp:DropDownList>
                </span>
            </div>
            <br />
            <div>

                <a href="/News/Latest/?time=30" class="btn btn-outline-secondary cur-p">30 دقیقه پیش
                </a>
                <a href="/News/Latest/?time=60" class="btn btn-outline-secondary cur-p">1 ساعت پیش
                </a>
                <a href="/News/Latest/?time=180" class="btn btn-outline-secondary cur-p">3 ساعت پیش
                </a>
                <a href="/News/Latest/?time=360" class="btn btn-outline-secondary cur-p">6 ساعت پیش
                </a>
                <a href="/News/Latest/?time=720" class="btn btn-outline-secondary cur-p">12 ساعت پیش
                </a>
                <a id="lnk_yesterday" runat="server" href="/News/Latest/?time=1440" class="btn btn-outline-secondary cur-p">1 روز پیش
                </a>
                <span>
                    <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
                    <asp:Button ID="btnGetNewsDB" runat="server" CssClass="btn btn-danger cur-p" Text="خروجیDB" OnClick="btnGetNewsDB_Click" />
                </span>
            </div>
        </div>
        <div class="control-box bultan newsBultan">
            <div>
                <a href="#" id="btn_SelectAll" class="btn btn-outline-secondary cur-p" title="انتخاب کلیه اخبار"><span class="entypo-check"></span>انتخاب کلیه اخبار</a>
                <asp:Button ID="btn_saveState" runat="server" Text="ذخیره وضعیت" CssClass="btn btn-outline-secondary cur-p" OnClick="btn_saveState_Click" />
                <asp:LinkButton ID="btn_reset" runat="server" class="btn btn-outline-secondary cur-p" OnClick="btn_reset_Click" OnClientClick="return confirm('آیا برای ریست کردن تنظیمات اطمینان دارید ؟')">حذف وضعیت</asp:LinkButton>
                <asp:Button ID="btn_exportWordTitr" runat="server" Text="Word تیتر" CssClass="btn btn-outline-secondary cur-p" OnClick="btn_exportWordTitr_Click" />
                <asp:Button ID="btn_exportWordShort" runat="server" Text="Word خلاصه" CssClass="btn btn-outline-secondary cur-p" OnClick="btn_exportWordShort_Click" />
                <asp:Button ID="btn_exportWord" runat="server" Text="خروجی Word" CssClass="btn btn-outline-secondary cur-p" OnClick="btn_exportWord_Click" />

                <a id="btn_generateGroupHtml" runat="server" onclick="GetGroupHTMLBultan(this)" class="btn btn-outline-secondary cur-p">بولتن موضوعی</a>
                <asp:Button ID="btn_generate" runat="server" Text="خروجی PDF" CssClass="btn btn-outline-secondary cur-p" />
                <asp:Button ID="btn_PrintLead" runat="server" Text="خلاصه اخبار" CssClass="btn btn-outline-secondary cur-p" />
                <%--   <asp:Button ID="btn_PrintLead" runat="server" Text="چاپ خلاصه اخبار" CssClass="flat-gray-button" OnClick="btn_PrintLead_Click" />--%>
                <asp:Button ID="btn_printTitle" runat="server" Text="تیتر اخبار" CssClass="btn btn-outline-secondary cur-p" OnClick="btn_printTitle_Click" />
                <asp:Button ID="btn_db" runat="server" Text="خروجی DB" CssClass="btn btn-outline-secondary cur-p" OnClick="btn_db_Click" />
            </div>
            <br />
            <div>
                <a id="btn_generateTamarkozHtml" runat="server" onclick="GetTamarkozHTMLBultan(this)" class="btn btn-info cur-p">خروجی تمرکز رسانه</a>
                <asp:Button ID="btnExportTamarkozDB" runat="server" class="btn btn-danger cur-p" Text="خروجی DB تمرکز رسانه ها" OnClick="btnExportTamarkozDB_Click" />
                <a id="btn_generateGroupTitrHtml" runat="server" onclick="GetGroupTitrHTMLBultan(this)" class="btn btn-success cur-p">تیتر اخبار موضوعی</a>
            </div>
            <div>
                <asp:CheckBox ID="check_NewsPaper" runat="server" CssClass="CheckBox" Text="روزنامه" />
                <asp:CheckBox ID="check_highlight" runat="server" CssClass="CheckBox" Text="هایلایت کلید واژه ها" />
                <asp:CheckBox ID="check_related" runat="server" CssClass="CheckBox" Text="شناسایی اخبار مرتبط" />
                <asp:CheckBox ID="check_rujeld" Checked="true" CssClass="CheckBox" runat="server" Text="رو جلد" />
                <asp:CheckBox ID="check_ChartKhabar" runat="server" CssClass="CheckBox" Text="نمودار" />
                <asp:CheckBox ID="check_Arz" runat="server" CssClass="CheckBox" Text="سکه و ارز" />
                <asp:CheckBox ID="check_GalleryNewspaper" CssClass="CheckBox" runat="server" Text="گالری روزنامه " />
                <asp:CheckBox ID="check_Sima" runat="server" CssClass="CheckBox" Text="صدا و سیما" />
                <asp:CheckBox ID="check_addGroup" runat="server" CssClass="CheckBox" Text="تفکیک" />
                <asp:CheckBox ID="check_addArchive" runat="server" CssClass="CheckBox" Text="اضافه کردن به آرشیو بولتن" />
            </div>
            <div>
                <span>عنوان بولتن</span>
                <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" Text="فاقد عنوان" />
                <span>قالب چاپی</span>
                <asp:DropDownList ID="drp_template" runat="server" CssClass="btn btn-outline-info cur-p dropdown dropdown-toggle" Width="200px"/>
            </div>
            <div>
                <a href="#" id="lnk_download" style="display: none">دریافت فایل</a>
            </div>
            <div style="display: none" class="loader">
                <img src="/Pages/P-Art/Images/ajax-loader.gif" />
            </div>
        </div>
        <div class="userSorting clearfix">
            <%--  <h4 class="right">
                <span class="fontawesome-sort" style="font-size: 13px; color: #073cb9;"></span>
                مرتب سازی مطالب</h4>--%>
            <div class="feederContainer clearfix right">
                <div>
                    <asp:CheckBox runat="server" ID="chbOrgNews" ClientIDMode="Static" CssClass=" smallCheckBox feederCheckbox org active" Checked="true" Text="منابع رسمی" />
                </div>
                <div>
                    <asp:CheckBox runat="server" ID="chbNotOrgNews" ClientIDMode="Static" CssClass=" smallCheckBox feederCheckbox notorg active" Checked="true" Text="منابع غیر رسمی" />
                </div>
            </div>
            <ul class="left">
                <li class="selected" id="sortByKeyword">
                    <a class="sortByKeyword" href="#sortByKeyword">کلیدواژه</a>
                </li>
                <li id="sortByTimeSort">
                    <a class="sortByTimeSort" href="#sortByTimeSort">زمان انتشار</a>
                </li>
                <%--  <li id="sortByGroupName" style="width: 100px;">
                            <a class="sortByGroupName" href="#sortByGroupName">گروه بندی موضوعی</a>
                            <i></i>
                        </li>--%>
                <li id="sortBySite">
                    <a class="sortBySite" href="#sortBySite">نام رسانه</a>
                </li>
                <li id="sortByCustom" style="width: 90px;">
                    <a class="sortByCustom" href="#sortByCustom">اولویت سفارشی</a>
                    <i></i>
                </li>
                <li id="sortByTitle">
                    <a class="sortByTitle" href="#sortByTitle">عناوین</a>
                    <i></i>
                </li>


            </ul>

        </div>
        <script>
            $(document).ready(function () {
                $("#rbtCommonList").live('click', function () {
                    $(".newsMostRelatedSection").hide();
                    $(".newsRelatedSection").hide();
                    $(".newsGroupSection").hide();
                    $(".newsSection").show();
                    $('#rbtRelatedList').removeClass('active');
                    $('#rbtMostPublished').removeClass('active');
                });
                $("#rbtGroupList").live('click', function () {
                    $(".newsMostRelatedSection").hide();
                    $(".newsRelatedSection").hide();
                    $(".newsSection").hide();
                    $(".newsGroupSection").show();
                    $('#rbtRelatedList').removeClass('active');
                    $('#rbtMostPublished').removeClass('active');
                });
                $("#rbtRelatedList").live('click', function () {
                    // __doPostBack('DoRelateNews', '');
                    //$('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                    //$('#rbtRelatedList').removeClass('active');
                    //$('#rbtRelatedList').addClass('active');
                });
                $("#rbtMostPublished").live('click', function () {
                    // __doPostBack('DoRelateNews', '');
                    //$('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                    //$('#rbtMostPublished').removeClass('active');
                    //$('#rbtMostPublished').addClass('active');
                });
            });
            function DoRelateNews() {

                // __doPostBack('DoRelateNews', '');
                //  alert('DoRelateNews');
                $(".newsMostRelatedSection").hide();
                $(".newsSection").hide();
                $(".newsGroupSection").hide();
                $(".newsRelatedSection").show();


                $('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                $('#rbtRelatedList').removeClass('active');
                $('#rbtRelatedList').addClass('active');

            }
            function DoMostPublishNews() {
                //  __doPostBack('DoRelateNews', '');
                $(".newsRelatedSection").hide();
                $(".newsSection").hide();
                $(".newsGroupSection").hide();
                $(".newsMostRelatedSection").show();


                $('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                $('#rbtMostPublished').removeClass('active');
                $('#rbtMostPublished').addClass('active');

            }
        </script>
        <div class="list-type newsStreamHeaderOutOfBox">
            <asp:RadioButton ID="rbtCommonList" runat="server" GroupName="news" Checked="true" Text="تمامی اخبار" CssClass="groupingNewsRadioButton ControlRightMargin" />
            <asp:RadioButton ID="rbtGroupList" runat="server" GroupName="news" Text="گروه بندی اخبار" CssClass="groupingNewsRadioButton" />
            <asp:Button ID="rbtRelatedList" OnClick="rbtRelatedList_Click" runat="server" GroupName="news" Text="تمرکز رسانه ها" CssClass="mediaFocusButton" />
            <asp:Button Visible="false" ID="rbtMostPublished" OnClick="rbtMostPublished_Click" runat="server" GroupName="news" Text="جریان خبری" />
            <a id="btnBultan" href="#" onclick="setOrderNewsIds()" class="SaveListOrderButton"><span class="ControlLeftMinPadding"><i class="fas fa-save fa-lg"></i></span><span>ذخیره اولویت نمایش</span></a>
        </div>
        <div class="newsSection persian newsStream">
            <asp:Repeater ID="news_list" runat="server" OnItemDataBound="news_list_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="showFehrest">
                        <article data-id='groupOrderItem_<%# Eval("NewsId") %>' data-grouporder='<%# Eval("GroupOrder") %>'
                            data-groupname='<%# Eval("GroupName") %>' data-keyword='<%# Eval("KeywordId") %>'
                            data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>'
                            data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>'
                            data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>'
                            data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class='show newsItemGroupOrder  newsItemGroupOrder<%# Eval("GroupOrder") %>'>
                            <div class="post-fehrest" runat="server" id="post">
                                <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                                <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                <asp:HiddenField ID="hddNewsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
            <%--                    <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />--%>
                                <asp:HiddenField ID="txt_row_index" runat="server" Value='<%# Eval("SortOrder") %>' />
                                <span runat="server" id="ColorSpan" class="rightColorSpan"></span>
                                <span class="rowIndex newsRowIndex"><%# Container.ItemIndex + 1 %> )</span>
                                <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews CheckBox" />
                                <span class="iconNewsType"><i id="iconNewsType" class="<%# ChangeIcon(Eval("SiteType").ToString()) %> iconType"></i></span>
                                <h2>
                                    <a data-keyid='<%# Eval("KeywordName") %>' data-keyword='<%# Eval("KeywordName") %>' target="_blank" href='<%# String.Format("~/DataCenterShowNews/{0}", Eval("NewsId")) %>'  data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                        runat="server">
                                        <%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),100) %></a>
                                </h2>
                                <span title='<%# Eval("SiteTitle") %>' class="siteTitle"><%# Eval("SiteTitle") %></span>
                                <span class="isSaved"><i class="far fa-arrow-alt-circle-down fa-lg"></i></span>
                                <%--<img class="siteimg" -onerror="this.src='../Images/newsPreview.jpg'" title='<%# Eval("SiteTitle") %>' src='<%# Eval("SiteLogo") %>' />--%>
                                <span class="detailToggle"><i class="fas fa-bars detailLead" id='showLead_<%# Eval("NewsId") %>'
                                    data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("KeywordName") %>'
                                    data-link='<%# Eval("NewsLink")%>' data-keyword='<%# Eval("KeywordName") %>'></i></span>
                                <div class="newsrate" runat="server">
                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                </div>
                                <span class="rowDateTime ">
                                    <label id="date"><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %></label>
                                </span>
                            </div>
                        </article>
                        <div class="newsTags" style="display: none;" id='selectedLead_<%# Eval("NewsId") %>'>
                                <%# ShowKeywords(Eval("KeyIds").ToString()) %>
                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>

            </asp:Repeater>
        </div>
        <div class="newsRelatedSection persian newsStream" style="display: none;">
            <asp:Repeater ID="rptRelatedNews_list" runat="server" OnItemDataBound="rptRelatedNews_list_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list2">
                </HeaderTemplate>
                <ItemTemplate>
                    <article data-id='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class="show">
                        <div class="post-content relation" id="news_row" runat="server">
                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                            <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                                <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsId") %>'>
                                    <img src="/Pages/P-Art/Images/del16.png" /></a>
                            </asp:PlaceHolder>
                            <%--<asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />--%>
                            <span runat="server" id="ColorSpan" class="rightColorSpan"></span>
                            <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>
                            <asp:CheckBox ID="check_SelectNewsTamarkoz" runat="server" CssClass="check_SelectNews CheckBox" />
                            <h2>
                                <%#  CheckIsNewsFeed(Eval("IsFeederNews"))  %>
                                <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                    runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                </a>
                            </h2>
                            <span class="siteTitle"><%#Eval("SiteTitle") %></span>
<%--                            <div class="newsrate" runat="server">
                                <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                            </div>--%>
                            <span class="rowDateTime">
                                <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                            </span>
                        </div>

                        <div class="newsTags hidden">
                            <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                            <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                        </div>
                        <div class="RelatedBody">
                            <asp:Repeater ID="relatedNews" runat="server" OnItemDataBound="RelatedNews_ItemDataBound">
                                <ItemTemplate>
                                    <div class="body-item">
                                        <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                        <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                        <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                                        <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                        <div class="Related-Item">
                                            <asp:CheckBox ID="check_SelectNewsTamarkoz" runat="server" CssClass="check_SelectNews CheckBox" />
                                            <span class="relatedNewsIndent"><i class="far fa-caret-square-left fa-lg"></i></span>
                                            <h2>
                                                <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                                    runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                                </a>
                                            </h2>
                                            <span class="siteTitle"><%#Eval("SiteTitle") %></span>
                                            <span class="rowDateTime">
                                                <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                            </span>
<%--                                            <div class="newsrate" runat="server">
                                                <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                                <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                                <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                            </div>--%>
                                        </div>
                                        <div class="newsTags hidden">
                                            <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                            <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </article>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <div class="clearfix"></div>
        <div class="newsMostRelatedSection persian newsStream" style="display: none;">
            <asp:Repeater ID="rptMostRelatedNews_list" runat="server" OnItemDataBound="rptMostRelatedNews_list_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list3">
                </HeaderTemplate>
                <ItemTemplate>
                    <article data-id='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class="show">
                        <div class="post-content relation" id="news_row" runat="server">
                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                            <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                                <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsId") %>'>
                                    <img src="/Pages/P-Art/Images/del16.png" /></a>
                            </asp:PlaceHolder>

                            <asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />

                            <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>

                            <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                            <h2>

                                <%#  CheckIsNewsFeed(Eval("IsFeederNews"))  %>
                                <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                    runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),60) %>
                                </a>
                            </h2>
                            <%--  <span class="marja"></span>--%>
                            <div class="news-desc">
                                <h2>
                                    <%#Eval("SiteTitle") %>
                              
                                </h2>

                                <span>
                                    <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                </span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="clearfix">
                                <div class="newsTags">
                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                </div>
<%--                                <div class="newsrate" runat="server">

                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                </div>--%>
                            </div>
                            <div class="RelatedBody">
                                <asp:Repeater ID="relatedNewsMost" runat="server" OnItemDataBound="relatedNewsMost_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="body-item">
                                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                            <div class="Related-Item">
                                                <div class="right-side">
                                                    <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                                                    <img src="../../../Styles/img/left-pointer-red.png" width="10" height="10">
                                                    <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                                        runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                                    </a>
                                                </div>
                                                <div class="news-desc">
                                                    <h2>
                                                        <%#Eval("SiteTitle") %>
                              
                                                    </h2>
                                                    <span>
                                                        <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="clearfix">
                                                <div class="newsTags">
                                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                                </div>
<%--                                                <div class="newsrate" runat="server">

                                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                                </div>--%>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </article>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="clearfix"></div>
        <div class="newsGroupSection persian newsStream" style="display: none;">
            <asp:Repeater ID="rptGroupNewKeyword" runat="server" OnItemDataBound="rptGroupNewKeyword_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list4">
                        <asp:CheckBox CssClass="chbSelectAllGroupItem CheckBox" ID="chbSelectAllGroupItem" Text="انتخاب تمامی اخبار" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <section class="keyword-groups1">
                        <asp:CheckBox ID='cbSelectAllGroupItem' ClientIDMode="AutoID" data-grouporder='<%# Eval("GroupOrder") %>' data-groupname='<%# Eval("GroupName") %>' runat="server" Text='<%# Eval("GroupName") %>'
                            CssClass="cbSelectAllGroupItem CheckBox" />
                        <%-- <asp:Label ID="lblGroup" Text='<%# Eval("GroupName") %>' runat="server"></asp:Label>--%>
                    </section>
                    <div class="clearfix"></div>
                    <asp:Repeater ID="rptGroupNewsList" runat="server" OnItemDataBound="rptGroupNewsList_ItemDataBound">
                        <HeaderTemplate>
                            <ol class="ol">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="articleSetion groupOrderItem">
                                <article data-id='groupOrderItem_<%# Eval("NewsId") %>' data-grouporder='<%# Eval("GroupOrder") %>' data-groupname='<%# Eval("GroupName") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class='show newsItemGroupOrder  newsItemGroupOrder<%# Eval("GroupOrder") %>'>
                                    <div class="post-fehrest" runat="server" id="news_row">
                                        <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                        <asp:HiddenField ID="hddNewsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                        <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                        <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                                        <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                        <asp:HiddenField ID="HiddenField6" runat="server" Value='<%# Eval("SortOrder") %>' />
                                        <span runat="server" id="ColorSpan" class="rightColorSpan"></span>
                                        <span class="rowIndex newsRowIndex"><%# Container.ItemIndex + 1 %> )</span>
                                        <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews CheckBox" />
                                        <span class="iconNewsType"><i id="iconNewsType" class="<%# ChangeIcon(Eval("SiteType").ToString()) %> iconType"></i></span>

                                        <h2>
                                            <a data-keyid='<%# Eval("KeywordName") %>' data-keyword='<%# Eval("KeywordName") %>' target="_blank" href='<%# String.Format("~/DataCenterShowNews/{0}", Eval("NewsId")) %>'  data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                        runat="server">
                                        <%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),100) %></a>
                                </h2>
                                        <span title='<%# Eval("SiteTitle") %>' class="siteTitle"><%# Eval("SiteTitle") %></span>
                                        <%--<img class="siteimg" onerror="this.src='../Images/newsPreview.jpg'" title='<%# Eval("SiteTitle") %>' src='<%# Eval("SiteLogo") %>' />--%>
<%--                                        <div class="newsrate" runat="server">
                                            <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId")%>'
                                                style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                            <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId")%>'
                                                style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                            <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId")%>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                        </div>--%>
                                        <div class="newsLocDiv"><a id='changeLoc_<%# Eval("NewsId") %>' data-newsid='<%# Eval("NewsId") %>' onclick="ChangeGroupOrder(this)" data-grouporder='<%# Eval("GroupOrder") %>' class="changeLoc"><i class="fas fa-exchange-alt fa-lg"></i></a></div>
                                        <span class="detailToggle"><i class="fas fa-bars detailLead" id='showLead_<%# Eval("NewsId") %>' 
                                            data-newsid='<%# Eval("NewsId") %>' onclick="ShowLeadGroup(this)" data-keyid='<%# Eval("KeywordName") %>'
                                            data-link='<%# Eval("NewsLink")%>' data-keyword='<%# Eval("KeywordName") %>'></i></span>
                                        <span class="rowDateTime ">
                                            <label id="date"><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %></label>
                                        </span>
                                    </div>
                                </article>
                                <div class="newsTags" style="display: none;" id='selectedLeadGroup_<%# Eval("NewsId") %>'>
                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>
                                </div>
                                <div class="divSelectGroup clearfix" style="height: 0px;"></div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="display: none;">
            <input type="hidden" id="hddNewsIdGroup" name="hddNewsIdGroup" runat="server" />
        </div>
        <div class="keywordGroup" id="keywordGroup" style="display: none;">
            <asp:RadioButtonList ID="rbtGroups" DataTextField="GroupName" DataValueField="GroupOrder" Style="padding: 20px;"
                runat="server">
            </asp:RadioButtonList>
            <a onclick="DoFinalChangeLog(this)" style="float: left;" class="btn btn-success cur-p">ثبت تغییرات</a>
        </div>
    </section>
    <script>
        function ChangeGroupOrder(element) {
            var $divSelectGroup = $(element).parent().parent().parent().parent().find('.divSelectGroup');
            if ($(element).attr('class').indexOf('active') > -1) {
                $divSelectGroup.html('');
                $divSelectGroup.animate({ 'height': 0 });
                $(element).removeClass('active');
                return;
            }
            $(element).addClass('active');
            var newsId = $(element).attr('data-newsid');
            var grouporder = $(element).attr('data-grouporder');

            $('#keywordGroup').attr('data-newsid', newsId);
            $('#keywordGroup').attr('data-grouporder', grouporder);



            $divSelectGroup.html('');
            var editDivHtml = $('#keywordGroup').html();
            editDivHtml = editDivHtml.replace('rbtGroups', 'rbtGroups_' + newsId);
            $divSelectGroup.html(editDivHtml);

            $('#rbtGroups_' + newsId + " input[value='" + grouporder + "']").prop("checked", true);

            $keywordGroupHeight = $('#keywordGroup').height();

            $divSelectGroup.animate({ 'height': $keywordGroupHeight + 20 });


            //   $('#keywordGroup').css({ 'top': $divSelectGroup.offset().top - ($keywordGroupHeight + 40) });
            //  $('#keywordGroup').css({ 'left': $divSelectGroup.offset().left + $divSelectGroup.width() });
            // $('#keywordGroup').fadeIn();

            //$("#divSelectGroup").slideToggle();
            //var offsetHeight = $('#keywordGroup').offsetHeight;
            //$('#divSelectGroup').style.height = offsetHeight + 'px';
            //var cont = $('#keywordGroup').html();
            //$('#divSelectGroup').append(cont);


        }
        function DoFinalChangeLog(element) {
            var newsId = $('#keywordGroup').attr('data-newsid');
            var old_grouporder = $('#keywordGroup').attr('data-grouporder');
            var news_grouporder = $("#rbtGroups_" + newsId).find(":checked").val();

            if (news_grouporder == null) {

                alert('لطفا گروه را انتخاب نمایید');
                return;
            }

            console.log(newsId);
            console.log(news_grouporder);
            //  alert(news_grouporder);
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/UpdateGroupOrderNews",
                data: "{'NewsId':'" + newsId + "','GroupOrder':'" + news_grouporder + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //   alert(data.d.length);
                    // alert(data.d);
                    if ((data.d + '').trim() == 'true') {
                        alert('انتقال انجام شد');
                        // $thisDiv.remove();
                        $('#keywordGroup').attr('data-grouporder', news_grouporder);
                        $('#changeLoc_' + newsId).attr('data-grouporder', news_grouporder);
                        //  $('#changeLoc_' + newsId).attr('data-newsid', newsId);
                    }
                    else {
                        alert('خطا در انتقال خبر');
                    }
                },
                error: function (msg) {
                    alert('ارور - خطا در انتقال خبر');
                }
            });

            //            e.preventDefault();
        }
    </script>
    <asp:GridView ID="grd_word" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>

            <asp:TemplateField>
                <ItemStyle Wrap="true" Width="595px" />
                <HeaderTemplate>
                    <div style="overflow-x: scroll; white-space: normal; width: 595px">
                </HeaderTemplate>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span>

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# (Eval("SiteTitle").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <span>


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p>

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#   (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p>

                        <asp:Literal runat="server" ID="ltLead" Text='<%--<%#   (Eval("NewsLead").ToString()) %>--%>'>

                        </asp:Literal>
                    </p>

                    <p>

                        <asp:Literal runat="server" ID="ltBody" Text='<%#   (Eval("NewsBody").ToString()) %>'>

                        </asp:Literal>
                    </p>


                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:GridView ID="grd_word_short" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span>

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# Eval("SiteTitle").ToString() %>'>

                        </asp:Literal>

                    </span>
                    <span>


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p>

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#  (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p>

                        <asp:Literal runat="server" ID="ltLead" Text='<%--<%#  (Eval("NewsLead").ToString()) %>--%>'>

                        </asp:Literal>
                    </p>



                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:GridView ID="grv_word_titr" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span>

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# Eval("SiteTitle").ToString() %>'>

                        </asp:Literal>

                    </span>
                    <span>


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p>

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#  (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>



                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <div class="shadowModal"></div>
    <div class="modalSiteSort">
        <div class="modalHeader"></div>
        <div class="modalContainer clearfix">
            <asp:Repeater runat="server" ID="rptSiteSort">
                <HeaderTemplate>
                    <div class="containerSiteSort right ">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="sortItem">

                        <%--  <asp:TextBox placeholder="اولویت نمایش" runat="server" ID="txtSortOrder" CssClass="numbericBox" Width="50px"></asp:TextBox>--%>

                        <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                        <i class="remove"></i>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <div class="containerSortSeleted">
                <h5 style="">سایت های موردنظر  خود را اینجا بیاورید</h5>
                <div class="selectedListItems">
                    <asp:Repeater runat="server" ID="rptSelectedSiteSort">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="selectedSiteItem">


                                <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                                <i class="remove"></i>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <div class="modalFooter">
            <a id="btnRegSiteSort" href="#regModel" class="regBtn">
                <span>ثبت</span>
            </a>
            <a id="btnCancelSiteSort" href="#closeModal" class="cancelBtn">
                <span>انصراف</span>
            </a>
        </div>
    </div>
    <%--  <script src="/Pages/P-Art/Scripts/tsort.min.js"></script>--%>
    <div class="loader_box">
        <img src="/Pages/P-Art/images/loading.gif" />
    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            Page_Init();
            if (window.location.pathname == "/tv") {
                $(".btn_tv").click();
            }


        });


        $('#sortByTimeSort a').live('click', function (e) {
            $(".news_list article").sort(sort_timesort) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTimeSort').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByCustom a').live('click', function (e) {
            $(".news_list div.article").sort(sort_custom) // sort elements
                    .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByCustom').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByTitle a').live('click', function (e) {

            // $('.news_list>article').tableSort({ attr: 'data-title' });

            $(".news_list article").sort(sort_title) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTitle').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortBySite a').live('click', function (e) {
            $(".news_list article").sort(sort_site) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortBySite').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByKeyword a').live('click', function (e) {
            $(".news_list article").sort(sort_keyword) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByKeyword').addClass('selected');
            sortArticleIndex();
            e.preventDefault();
        });

        $('.userSorting li#sortByCustom i').live('click', function (e) {

            ShowShadowModal();
            ShowSiteSortModal();
        });
        $('.modalSiteSort .cancelBtn').live('click', function (e) {

            CloseShadowModal();
            CloseSiteSortModal();
        });


        $('.modalSiteSort .modalFooter .regBtn').live('click', function (e) {
            var fileOffset = $(this).offset();

            $('.loader_box').css({ 'left': fileOffset.left, 'top': fileOffset.top });
            $('.loader_box').fadeIn('fast');
            var siteIds = '';
            $('.modalSiteSort .selectedListItems  .selectedSiteItem').each(function (index) {

                var $this = $(this);
                var siteId = $this.find('span').attr('data-id');
                if (siteIds == '') {
                    siteIds = siteId;
                }
                else {
                    siteIds = siteIds + "," + siteId;
                }

            });

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/ajax.aspx/UpdateUserSortingOrder",
                data: "{'userId':'<%=hdfUserID.Value%>','siteIds':'" + siteIds + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //   alert(data.d.length);


                    $('.loader_box').fadeOut('fast');
                    CloseShadowModal();
                    CloseSiteSortModal();
                },
                error: function (msg) {
                    alert(msg.messege);
                    $('.loader_box').fadeOut('fast');
                    CloseShadowModal();
                    CloseSiteSortModal();
                    // alert(msg.responseText);
                }
            });

            e.preventDefault();

        });
        $('.modalSiteSort .modalContainer .containerSortSeleted .selectedSiteItem .remove').live('click', function () {
            $this = $(this);
            $this.parent().fadeOut().remove();
        });

        var $sitesSort = $(".containerSiteSort"),
             $selected = $(".selectedListItems");

        // let the gallery items be draggable
        $("div", $sitesSort).draggable({
            cancel: "a.ui-icon", // clicking an icon won't initiate dragging
            revert: "invalid", // when not dropped, the item will revert back to its initial position
            containment: "document",
            helper: "clone",
            cursor: "move"
        });

        // let the trash be droppable, accepting the gallery items
        $selected.droppable({
            accept: ".containerSiteSort > div",
            activeClass: "ui-state-highlight",
            drop: function (event, ui) {
                $selected.append("<div class='selectedSiteItem'>" + ui.draggable.html() + "</div>");
            }
        });
        $('.selectedListItems').sortable();
        $('.selectedListItems').disableSelection();


        function ShowShadowModal() {
            $('.shadowModal').fadeIn();
        }

        function CloseShadowModal() {
            $('.shadowModal').fadeOut();
        }
        function ShowSiteSortModal() {
            $('.modalSiteSort').fadeIn();
        }
        function CloseSiteSortModal() {
            $('.modalSiteSort').fadeOut();
        }
        $('#chbOrgNews').click(function () {

            $(this).parent().toggleClass('active');

            if ($("#chbOrgNews").is(':checked')) {
                $('.news_list article[data-feedernews="False"]').fadeIn();

            }
            else { $('.news_list article[data-feedernews="False"]').fadeOut(); }

        });
        $('#chbNotOrgNews').click(function () {

            $(this).parent().toggleClass('active');
            if ($("#chbNotOrgNews").is(':checked')) {
                $('.news_list article[data-feedernews="True"]').fadeIn();
            }
            else {
                $('.news_list article[data-feedernews="True"]').fadeOut();

            }
        });

        // sort function callback
        function sort_timesort(a, b) {
            return ($(b).data('timesort')) > ($(a).data('timesort')) ? 1 : -1;
        }
        function sort_site(a, b) {
            return ($(b).data('sitename')) < ($(a).data('sitename')) ? 1 : -1;
        }
        function sort_custom(a, b) {

            return ($(b).data('customsort')) < ($(a).data('customsort')) ? 1 : -1;

        }
        function sort_keyword(a, b) {
            return ($(b).data('keyword')) < ($(a).data('keyword')) ? 1 : -1;
        }
        function sort_GroupName(a, b) {
            return ($(b).data('groupName')) < ($(a).data('groupName')) ? 1 : -1;
        }
        function sort_title(a, b) {
            return ($(b).data('title')) < ($(a).data('title')) ? 1 : -1;
            return b - a;
        }
        function sortArticleIndex() {
            var counter = 1;

            $('.news_list article .show').each(function (index) {
                // alert('yes');
                var $this = $(this);
                $this.find('.post-content').find('span.rowIndex').text(parseInt(counter) + ")");
                counter++;
                //alert(counter);
            });
        }

        function sortArticleIndex1() {
            var counter = 1;

            $('.news_list div.showFehrest').each(function (index) {
                var $this = $(this);
                $this.find('.post-fehrest').find('span.rowIndex').text(parseInt(counter) + ")");
                counter++;
                // alert(counter);
            });
        }

        $('.delNews').live('click', function (e) {
            var $this = $(this);
            var newsID = $this.attr('data-id');
            $thisDiv = $this.parent().parent();

            var result = confirm("برای حذف خبر مطمئن هستید؟");
            if (result) {


                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/ajax.aspx/DeActiveNews",
                    data: "{'NewsId':'" + newsID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //   alert(data.d.length);

                        if (data.d == 'true') {
                            $thisDiv.remove();

                        }
                        else {
                            alert('حطا در حذف خبر');
                        }
                    },
                    error: function (msg) {
                        alert('حطا در حذف خبر');

                        // alert(msg.responseText);
                    }
                });
            }
            e.preventDefault();




        });

        $(window).load(function () {

            $(".news_list article").sort(sort_timesort) // sort elements
                  .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTimeSort').addClass('selected');
            sortArticleIndex1();
            //  e.preventDefault();

            var allText = "";
            // update control-box group_item
            $('.group_item').each(function () {
                //alert('ok');
                var $this = $(this);


                allText += "," + $this.find('label').text().trim() + ",";
                //alert(allText);
            });
            var lstAllGroupItem = $('.group_item label');
            //$('.newsTags a').each(function () {
            //    //alert('ok2');
            //    var $this = $(this);
            //    var txt = "," + $this.text().trim() + ",";
            //    //alert(allText.indexOf(txt));
            //    if (allText.indexOf(txt) == -1) {
            //        //alert('ok3');
            //        allText += txt;
            //        // alet(allText);
            //        var data_keyid = $this.attr('data-keyid');
            //        // alert(data_keyid);
            //        var data_color = $this.attr('data-color');
            //        // alert(data_color);
            //        var data_text = $this.attr('data-text');
            //        //alert(data_text);

            //        var html = "<div id='group_item' class='group_item'>" +
            //            "<input type='hidden' name='ctl00$Content$rpt_Groups$ctl01$fld_color' id='fld_color' value='" + data_color + "'>" +
            //            "<span id='color_span' style='background-color:" + data_color + ";'>" +
            //                "<input id='check_selected_group' class='nonAspCheckBox' type='checkbox' name='ctl00$Content$rpt_Groups$ctl01$check_selected_group'>" +
            //            "</span>" +
            //            "<a href='#' data-id='" + data_keyid + "' class='switchkeyword'>" +
            //                "<label>" + data_text + "</label>" +

            //            "</a>" +
            //        "</div>";

            //        $('.control-box.category').append(html);
            //    }

            //});


        });

    </script>
    <script type="text/javascript">


        $(function () {
            $(".news_list4 ol").sortable({
                // placeholder: "ui-state-highlight"
            });
            $(".news_list4 ol").disableSelection();
        });

        $(window).load(function () {
        });
        function setOrderNewsIds() {
            var counter = 0;
            var str = "";
            $('.newsItemGroupOrder').each(function () {
                var $this = $(this);

                var fld_newsId = $this.find('#fld_newsId').val();
                // var hddNewsId = $this.find('#hddNewsId').val();

                var txt_row_index = "10000" + counter;
                counter++;

                str += ";" + fld_newsId + ":" + txt_row_index;
                //alert(str);

                //var txt_row_index = $this.find('#txt_row_index').val();
                //var check_SelectNews = $this.find('#check_SelectNews');
                //// if (check_SelectNews.attr("checked") == "checked") {

                ////if (txt_row_index == null || txt_row_index == '' || txt_row_index == undefined) {
                //    txt_row_index = "10000" + counter;
                //    counter++;


                // str += ";" + fld_newsId + ":" + txt_row_index;
                //if (check_SelectNews.attr('checked')==checked) {
                //}
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
    </script>
    <script type="text/javascript">
        function ShowLeadGroup(element) {
            var newsId = $(element).attr('data-newsid');


            var $divSelectLead = $(element).parent().parent().parent().parent().parent().find('#selectedLeadGroup_' + newsId);

            $(element).addClass('active');


            var idDiv = '#selectedLeadGroup_' + newsId;
            $(idDiv).slideToggle();

        }
        function ShowLead(element) {
            var newsId = $(element).attr('data-newsid');


            var $divSelectLead = $(element).parent().parent().parent().parent().parent().find('#selectedLead_' + newsId);
            //if ($(element).attr('class').indexOf('active') > -1) {
            //    $divSelectLead.html('');
            //    $divSelectLead.animate({ 'height': 0 });
            //    $(element).removeClass('active');
            //    return;

            //}
            $(element).addClass('active');

            //<div class='newsrate' runat='server'><a href='#' class='btn_news_notok' title='خبر منفی' itemid=" + newsId + " ></a> <a href='#' class='btn_news_empty' title='خبر خنثی' itemid=" + newsId + " ></a><a href='#' class='btn_news_ok' title='خبر مثبت' itemid=" + newsId + "></a></div> </div></div>";
            //$divSelectLead.html('');

            //$divSelectLead.html(lead);
            var idDiv = '#selectedLead_' + newsId;
            $(idDiv).slideToggle();

            //   $divSelectLead.animate({ 'height': $(idDiv).height() });

        }

        //$('.NewsKeyBox input[type=checkbox]').on('change', function (e) {
        //    var ids = ",";
        //    $('.control-box .group_item span input[type=checkbox]').each(function (index) {
        //        if ($(this).is(':checked')) {
        //            ids += $(this).closest('#group_item').find("a").data("id") + ",";
        //        }
        //    });
        //    alert(ids)
        //    if (ids == ",") {
        //        $(".posts article").parent().removeClass("hidden");
        //        $(".posts article").parent().removeClass("show");
        //        $(".posts article").parent().addClass("show");


        //    }
        //    else {


        //        $(".posts article").each(function (post) {

        //            $(this).parent().removeClass("hidden");
        //            $(this).parent().removeClass("show");

        //            var dataItem = $(this).parent().attr("data-id");
        //            var dataItemKeys = $(this).parent().find("#hdfNewsTags").val();


        //            var hasKey = false;
        //            $(ids.split(',')).each(function () {
        //                var sKey = this;

        //                if (sKey != '') {
        //                    if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
        //                        hasKey = true;
        //                    }
        //                }
        //            });

        //            if (hasKey) {
        //                $(this).parent().addClass("show");
        //            }

        //            else {
        //                $(this).parent().addClass("hidden");
        //            }

        //        });

        //    }

        //    sortArticleIndex();
        //});

        //$('.NewsKeyBox input[type=checkbox]').on('change', function (e) {
            
        //    var ids = ",";
        //    $('.NewsKeyBox input[type=checkbox]').each(function () {
        //        if ($(this).is(':checked')) {
        //            ids += $(this).closest('#group_item').find("a").data("id") + ",";
        //        }
        //    });
            
        //    if (ids == ",") {
        //        $(".showFehrest").removeClass("hide");
        //        $(".showFehrest").removeClass("show");
        //        $(".showFehrest").addClass("show");
        //    }
        //    else {

        //        $each(".showFehrest",function () {
        //            $(this).removeClass("hide");
        //            $(this).removeClass("show");
                 
        //            var dataItemKeys = $(this).find("#hdfNewsTags").val();
        //            alert(dataItemKeys);
        //            var hasKey = false;

        //            $(ids.split(',')).each(function () {
        //                var sKey = $(this).val();
        //                if (sKey != '') {
        //                    if (dataItemKeys.indexOf(sKey) > -1) {
        //                        hasKey = true;
        //                    }
        //                }
        //            });

        //            if (hasKey) {
        //                $(this).closest('.showFehrest').addClass("show");
        //            }

        //            else {
        //                $(this).closest('.showFehrest').addClass("hide");
        //            }

        //        });

        //    }

        //    sortArticleIndex();
        //});

        $(document).on('change', '.control-box .group_item span input[type=checkbox]', function (e) {
            var ids = ",";
            $('.control-box .group_item span input[type=checkbox]').each(function (index) {
                if ($(this).is(':checked')) {
                    ids += $(this).parent().parent().find("a").attr("data-id") + ",";
                }
            });
            if (ids == ",") {
                $(".posts article").parent().removeClass("hidden");
                $(".posts article").parent().removeClass("show");
                $(".posts article").parent().addClass("show");
            }
            else {


                $(".posts article").each(function (post) {

                    $(this).parent().removeClass("hidden");
                    $(this).parent().removeClass("show");

                    var dataItem = $(this).parent().attr("data-id");
                    var dataItemKeys = $(this).parent().find("#hdfNewsTags").val();


                    var hasKey = false;
                    $(ids.split(',')).each(function () {
                        var sKey = this;

                        if (sKey != '') {
                            if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
                                hasKey = true;
                            }
                        }
                    });

                    if (hasKey) {
                        $(this).parent().addClass("show");
                    }

                    else {
                        $(this).parent().addClass("hidden");
                    }

                });

            }

            sortArticleIndex();
        });

        $(".showFehrest input:checkbox").click(function () {
            $(this).parents(".showFehrest").toggleClass("SetNewsCeckedbackground");
        });


        $(".newsGroupSection .articleSetion input:checkbox").click(function () {
            $(this).parents(".articleSetion").toggleClass("SetNewsCeckedbackground");
        });

        $("#SaveSelectedNewsButton").click(function (e) {
            const loader = document.getElementById('loader');
            setTimeout(() => {
                loader.classList.remove('fadeOut');
            }, 300);
            var NewsIdString = "";
            $('.newsStream #check_SelectNews').each(function () {
                if (this.checked) {
                    NewsIdString +="," + $(this).closest("div").find("#hddNewsId").val() ;
                }
            });
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/DataCenter.aspx/SaveDataCenterNews",
                data: "{'NewsIdString':'" + NewsIdString + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                    alert("اطلاعات ثبت گردید");
                },
                error: function (msg) {
                    setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                    alert("خطا در ثبت اطلاعات");
                }

            }
            );
            e.preventDefault();

        });
           
        $("#ShowAllKeywords").click(function () {
            $('.newsTags').fadeToggle(500);
        });

    </script>
</asp:Content>
