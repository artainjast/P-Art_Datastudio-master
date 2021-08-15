<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="DomesticNewsPaging.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.DomesticNewsPaging" %>



<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>
    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <asp:HiddenField runat="server" ID="PageIndexHiddenField" />
    <asp:HiddenField runat="server" ID="hddParmin" />
    <asp:HiddenField runat="server" ID="hddMember" />
    <div class="PageSubLink">
        <ul>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/News/BultanArchive" target="_blank" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="#" id="lnk_filter" class="flat-gray-button"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
            <li><a href="#" id="lnk_bultan" class="flat-gray-button"><span><i class="fas fa-file-alt"></i></span>بولتن</a></li>
            <li><a onclick="GotoInbox(this)" class="flat-gray-button"><span><i class="fas fa-inbox" aria-hidden="true"></i></span>اینباکس من</a></li>
        </ul>
    </div>

    <div class="newsFilter persian">
        <div>
            <span>
                <span>از تاریخ</span>
                <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="width: 68px;" />
            </span>
            <span>
                <span>از ساعت</span>
                <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align: center" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
                    ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                </asp:RegularExpressionValidator>
            </span>
            <span>
                <span>تا تاریخ</span>
                <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 68px;" />
            </span>
            <span>
                <span>تا ساعت</span>
                <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align: center" />
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
                <label for="PageSizeDropDownList">تعداد در صفحه  </label>

                <asp:DropDownList runat="server" ID="PageSizeDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" Selected="True" />
                    <asp:ListItem Text="50" Value="50" />
                    <asp:ListItem Text="100" Value="100" />
                </asp:DropDownList>

            </span>

            <span>
                <label for="PageSizeDropDownList">مخزن</label>

                <asp:DropDownList runat="server" ID="storageTypeDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                    <asp:ListItem Text="تمام اخبار" Value="1" Selected="True" />
                    <asp:ListItem Text="اخبار ذخیره شده" Value="2" />
                    <asp:ListItem Text="اخبار بولتن شده" Value="3" />
                </asp:DropDownList>

            </span>

        </div>
        <br />
        <div>
            <span>
                <span>منبع خبری</span>
                <asp:DropDownList ID="drp_NewsSource" Width="95px" runat="server" CssClass="btn btn-outline-info cur-p" Style="min-width: 200px" />
            </span>

            <span style="margin-right: 20px; margin-left: 20px">
                <input type="checkbox" id="HasDeletedKeyCheckBox" runat="server" class="CheckBox" />
                <label for="HasDeletedKeyCheckBox">کلیدواژه های حذف شده</label>
            </span>
            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
        </div>

    </div>

    <div class="newsBultan persian">
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
        <br />
        <div>
            <span>عنوان بولتن</span>
            <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" placeholder="فاقد عنوان" />
            <span>قالب چاپی</span>
            <asp:DropDownList ID="drp_template" runat="server" CssClass="btn btn-outline-info cur-p dropdown dropdown-toggle" Width="200px" />
            <span><a id="btn_generateGroupHtml" runat="server" onclick="GetPagingHTMLBultan(this)" class="btn btn-success cur-p" style="width: 130px;">ساخت بولتن</a></span>
            <span>
                <asp:LinkButton ID="ClearAllBultanSelectionButton" runat="server" class="btn btn-outline-secondary cur-p marginRight-10" OnClick="ClearAllBultanSelectionButton_Click" OnClientClick="return confirm('آیا از حذف انتخاب های بولتن مطمئن هستید؟ ؟')">حذف تمام انتخاب های بولتن</asp:LinkButton>
            </span>
        </div>

        <div style="display: none" class="loader">
            <img src="/Pages/P-Art/Images/ajax-loader.gif" />
        </div>
    </div>

    <div class="PagingContainer persian">
        <div id="topPagination" runat="server" class="PagingPagination persian"></div>
        <span class="selectAllContainer">
            <span class="selectAllNewsCheckBox"><i class="fas fa-check-circle"></i>انتخاب همه</span>
            <span class="unSelectAllNewsCheckBox"><i class="far fa-circle"></i>حذف انتخاب ها</span>
        </span>

        <div id="pagingGrid" runat="server" class="pagingGrid">

            <asp:Repeater ID="pagingGridRepeater" runat="server">
                <HeaderTemplate>
                    <div class="pagingGridContainer">
                        <div class="pagingGridHeader">
                            <span class="HeaderSelection">انتخاب</span>
                            <span class="HeaderTitle">عنوان خبر</span>
                            <span class="HeaderRepublish">باز نشر</span>
                            <span class="HeaderSite">رسانه</span>
                            <span class="HeaderValue">جهت گیری</span>
                            <span class="HeaderDateTime">زمان</span>
                            <span class="HeaderSeenOrNot"></span>
                        </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="GridContainer">
                        <div class="GridItem" data-id="<%#Eval("id") %>">
                            <div class="top-post">
                                <div class="first-row">
                                    <div class="image-site">
                                        <img src='<%# Eval("SiteLogo") %>' />
                                    </div>
                                    <i class="fa fa-"></i><span class="siteTitle"><%# Eval("SiteName") %></span>
                                    <div class="newsrate" runat="server">
                                        <a href="#" class="btn_news_notok" title="خبر منفی"
                                            itemid='<%# Eval("id") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                        <a href="#" class="btn_news_irrelevant" title="خبر بی ربط"
                                            itemid='<%# Eval("id") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"4") %>'></a>
                                        <a href="#" class="btn_news_empty" title="خبر خنثی"
                                            itemid='<%# Eval("id") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                        <a href="#" class="btn_news_lowـcommunication" title="خبر کم ارتباط"
                                            itemid='<%# Eval("id") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"3") %>'></a>
                                        <a href="#" class="btn_news_ok" title="خبر مثبت"
                                            itemid='<%# Eval("id") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                    </div>
                                </div>
                                <div style="display: none;" class="second-row">
                                    <span class="sitelink"><%#PArt.Pages.P_Art.Repository.Class_Static.GetDomainName(Eval("NewsLink").ToString()) %></span>
                                </div>
                                <div class="third-row">
                                    <div class="image-news">
                                        <img src='<%# Eval("NewsPicture") %>' />
                                    </div>
                                    <div class="newstitle-content"><a target="_blank" href='<%# String.Format("/ShowNews/{0}", Eval("id")) %>'><span class="newstitle"><%# Eval("Title") %></span></a></div>
                                    <div class="newslead-content">
                                        <p class="newslead"><%#PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsLead").ToString(),400) %></p>
                                    </div>
                                </div>
                                <div class="fourth-row">
                                    <span class="rowDateTime ">
                                        <i class="fa fa-calendar"></i>
                                        <label id="date"><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("Time").ToString(),Eval("Date").ToString()) %></label>
                                    </span>
                                </div>
                            </div>
                            <div class="bottom-post">
                                <asp:CheckBox ID="NewsSelectCheckbox" runat="server" CssClass="CheckBox SelectingRowCheckBox" />
                                <a data-id='<%# Eval("id") %>' class="cur-p add-inbox" onclick="addToInbox(this)"><span class="inb-title">افزودن به اینباکس</span></a>
                                <span class="divider">|</span>
                                <a class="cur-p shownews" target="_blank" href='<%# Eval("NewsLink")%>'><i class="fa fa-chain"></i><span class="inb-title">شاهد خبر</span></a>
                                <span class="divider">|</span>
                                <span class="HasItemSeenEverIcon"><i class="<%# CheckSeenOrNot(Convert.ToInt32(Eval("ViewCount"))) %> iconType"></i><span class="inb-title"><%# GetTextSeenOrNot(Convert.ToInt32(Eval("ViewCount"))) %></span></span>
                                <span class="ItemRepublish" title='<%#Eval("RelatedCount") %>' data-relatedlist='<%# Eval("RelatedNews") %>' data-id='<%# Eval("id") %>' data-count='<%#Eval("RelatedCount") %>'>
                                    <span>بازنشرها:</span>  <%#Eval("RelatedCount") %>  <i class="fa fa-retweet"></i>
                                </span>
                            </div>
                            <div style="display: none;">
                                <span class="ItemSelection">
                                    <input id="NewsSelectCheckbox" type="checkbox" class="CheckBox SelectingRowCheckBox" data-id="<%#Eval("id") %>" <%#Eval("BultanCheckBox") %> />
                                    <i id="iconNewsType" class="<%# ChangeIcon(Eval("SiteType").ToString()) %> iconType"></i>
                                </span>

                                <span class="ItemTitle" title='<%# Eval("Title") %>' data-id='<%# Eval("id") %>'>
                                    <%# Eval("Title") %>
                                </span>
                                <span class="ItemSite" title='<%# Eval("SiteName") %>'>
                                    <%# Eval("SiteName").ToString().Trim() %>
                                </span>
                                <span class="ItemValue">
                                    <div class="newsrate" runat="server">
                                    </div>
                                </span>
                                <span class="ItemDateTime" title='<%# Eval("Date") %> -  <%# Eval("Time") %>'><i class="fas fa-calendar-alt"></i><%# " "+ Eval("Date") %>   <i class="fas fa-clock"></i><%# " " + Eval("Time") %></span>
                                <span class="HasItemSeenEverIcon"><i class="<%# CheckSeenOrNot(Convert.ToInt32(Eval("ViewCount"))) %> iconType"></i></span>
                                <span class="add-inbox"><a data-id='<%# Eval("id") %>' class="cur-p" onclick="addToInbox(this)"><span><i class='far fa-save'></i></span></a></span>

                            </div>

                        </div>
                        <div id="GridItemDetail_<%# Eval("id") %>" class="Detail">
                            <div class="DetailHeader">
                                <p>
                                    <span class="MatnKhabar">متن خبر:</span>
                                    <span class="ShowNewsLink">
                                        <a href="/ShowNews/<%#Eval("id") %>" target="_blank">نمایش</a>
                                    </span>
                                    <span class="NewsUrl">
                                        <a href="<%#Eval("Url") %>" target="_blank" class="<%# Eval("UrlDisplayControl") %>">شاهد خبر</a>
                                    </span>
                                    <span class="SaveButton">

                                        <input id="SaveCheckBox" type="checkbox" class="CheckBox" data-id="<%#Eval("id") %>" title="ذخیره خبر" <%#Eval("SaveCheckBox") %> />
                                        <label for="SaveCheckBox">ذخیره خبر</label>
                                    </span>
                                </p>

                            </div>
                            <div class="DetailContent"></div>
                        </div>
                        <div id="GridItemRelatedNews_<%# Eval("id") %>" class="RelatedDetail">
                            <div class="DetailHeader">
                                <p>
                                    <span class="relatedIndex">ردیف</span>
                                    <span class="relatedSelection">انتخاب</span>
                                    <span class="relatedTitle">عناوین اخبار</span>
                                    <span class="relatedSiteName">نام رسانه</span>
                                    <span class="relatedDateTime">زمان</span>
                                </p>
                            </div>

                            <div class="RelatedDetailContent"></div>
                        </div>
                    </div>
                </ItemTemplate>

                <FooterTemplate>
                    <div class="GridFooter">
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div id="buttomPagination" runat="server" class="PagingPagination persian"> </div>
    </div>
        </div>

    <script type="text/javascript">
        $(document).ready(function () {

            Page_Init();
        });
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

        }
        function addToInbox(element) {
            var newsID = $(element).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/NewMediaNewsList.aspx/AddToInbox",
                data: "{'MediaId':'" + newsID + "' , 'MediaType': 1}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d !== 0) {
                        OpenAlert('افزودن به اینباکس', 'خبر انتخابی با موفقیت به اینباکس اضافه شد');
                    }
                },
                error: function (msg) {
                    OpenAlert('افزودن به اینباکس', 'خطای ناشناخته در افزودن به اینباکس');
                }
            });
        }

        $("#lnk_filter").click(function (e) {

            $(".newsFilter").fadeToggle("slow", "linear");
            e.preventDefault();
        });

        $("#lnk_bultan").click(function (e) {

            $(".newsBultan").fadeToggle("slow", "linear");
            e.preventDefault();
        });

        $('.ItemTitle').live('click', function (e) {

            var $this = $(this);
            var $thisSeenIcon = $this.parent().children(".HasItemSeenEverIcon");

            var newsID = $this.attr('data-id');
            var detailBoxId = "#GridItemDetail_" + newsID;
            $thisDiv = $(detailBoxId);
            $thisDivContent = $(detailBoxId + " .DetailContent");

            $thisDivContent.empty();
            $thisDivContent.append("<img id=\"imgLoadPage1\" style=\"text-align: center; margin: auto;  display:flex; max-width: 100px\" src=\"/Pages/P-Art/Images/loadingPaging.gif\">");

            $thisDiv.fadeToggle("slow", "linear");

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/DomesticNewsPaging.aspx/DetailShowNews",
                data: "{'NewsID':'" + newsID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != null) {
                        $thisDivContent.empty();
                        $thisDivContent.append(data.d.Body);
                        $thisDivContent.append(data.d.KeyTitles);

                        $thisSeenIcon.empty();
                        $thisSeenIcon.append('<i class="fas fa-folder-open opacity50 iconType"></i>');
                    }

                },
                error: function (msg) {
                    alert('خطا');
                }
            });

            e.preventDefault();
        });

        $('.ItemRepublish').live('click', function (e) {

            var $this = $(this);
            var newsID = $this.attr('data-id');
            var RelateCount = $this.attr('data-count');

            if (RelateCount !== "0") {
                var newsRelatedIDs = $this.attr('data-relatedlist');
                var detailBoxId = "#GridItemRelatedNews_" + newsID;
                $thisDiv = $(detailBoxId);
                $thisDivContent = $(detailBoxId + " .RelatedDetailContent");

                $thisDivContent.empty();
                $thisDivContent.append("<img id=\"imgLoadPage1\" style=\"text-align: center; margin: auto;  display:flex; max-width: 100px\" src=\"/Pages/P-Art/Images/loadingPaging.gif\">");

                $thisDiv.fadeToggle("slow", "linear");

                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/DomesticNewsPaging.aspx/GetRelatedNews",
                    data: "{'RelatedNewsIds':'" + newsRelatedIDs + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != null) {
                            $thisDivContent.empty();
                            $thisDivContent.append(data.d);
                        }
                    },
                    error: function (msg) {
                        alert('خطا');
                    }
                });

            }
            e.preventDefault();
        });

        $('#SaveCheckBox').live('change', function (e) {
            var $this = $(this);
            var newsID = $this.attr('data-id');
            var check = false;

            if ($this.is(':checked')) {
                check = true;
            }

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/DomesticNewsPaging.aspx/SaveNews",
                data: "{'newsID':" + newsID + ",'check':" + check + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                },
                error: function (msg) {
                    alert('خطا');
                    console.log(msg)
                }
            });

            e.preventDefault();
        });

        $('#NewsSelectCheckbox').live('change', function (e) {

            var $this = $(this);
            var newsID = $this.attr('data-id');
            var check = false;

            if ($this.is(':checked')) {
                check = true;
            }

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/DomesticNewsPaging.aspx/BultanMark",
                data: "{'newsID':" + newsID + ",'check':" + check + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                },
                error: function (msg) {
                    alert('خطا');
                    console.log(msg)
                }
            });

            e.preventDefault();
        });

        $('.selectAllNewsCheckBox').click(function (e) {
            $(":checkbox[id=NewsSelectCheckbox]").each(function () {
                this.checked = true;
            });
        });

        $('.unSelectAllNewsCheckBox').click(function (e) {
            $(":checkbox[id=NewsSelectCheckbox]").each(function () {
                this.checked = false;
            });
        });

        function GetPagingHTMLBultan(element) {
            var $this = $(element);
            var parmin = $("#<%= hddParmin.ClientID %>").val();
            var member = $("#<%= hddMember.ClientID %>").val();
            var fromDate = $('#txt_fromDate').val();
            var toDate = $('#txt_toDate').val();
            var fromTime = $('#txt_fromHour').val();
            var toTime = $('#txt_toHour').val();
            var checkNewsPaper = $('#check_NewsPaper').attr('checked') ? 'true' : 'false';
            var CheckChart = $('#check_ChartKhabar').attr('checked') ? 'true' : 'false';
            var checkAllowArchive = $('#check_addArchive').attr('checked') ? 'true' : 'false';
            var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';
            var checkAllowRelated = $('#check_related').attr('checked') ? 'true' : 'false';
            var bultanTitle = $("#txt_bultanTitle").val();
            var bultanTemplate = $("#drp_template").val();
            var checkAllowGroup = $('#check_addGroup').attr('checked') ? 'true' : 'false';
            var checkAllowArz = $('#check_Arz').attr('checked') ? 'true' : 'false';
            var checkAllowSima = $('#check_Sima').attr('checked') ? 'true' : 'false';
            var checkAllowGalleryNewspaper = $('#check_GalleryNewspaper').attr('checked') ? 'true' : 'false';
            var checkRujeld = $('#check_rujeld').attr('checked') ? 'true' : 'false';

            var linkUrl = window.location.protocol + "//" + window.location.hostname;
            if (window.location.port != null && window.location.port != '') {
                linkUrl += ":" + window.location.port;
            }
            linkUrl = linkUrl + "/HtmlGroupNews.aspx?ArchiveId=";
            $.ajax({
                type: "POST",
                url: "/Services/Part_SetBultanArchive.ashx?p=" + parmin + "&member=" + member + "&fromDate=" + fromDate + "&toDate=" + toDate + "&bultanTitle=" +
                    bultanTitle + "&fromTime=" + fromTime + "&toTime=" + toTime + "&allowNewspaper=" + checkNewsPaper + "&galleryNewspaper=" + checkAllowGalleryNewspaper +
                    "&arz=" + checkAllowArz + "&sima=" + checkAllowSima + "&highLight=" + checkAllowHighlight + "&allowGroup=" + checkAllowGroup +
                    "&related=" + checkAllowRelated + "&selectedBultan=" + bultanTemplate + "&isArchive=true&chart=" + CheckChart + "&jeld=" + checkRujeld +
                    "&BultanType=2&linkUrl=" + linkUrl,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    console.log(msg);
                    if (msg == null || msg == '') return;
                    if (msg == 0) {
                        alert('خطا در ساخت گزارش');
                        return;
                    }
                    var finalLink = linkUrl + msg;
                    window.location.href = finalLink;
                }
            });
        }

        function GotoInbox(element) {
            var linkUrl = window.location.protocol + "//" + window.location.hostname;
            if (window.location.port != null && window.location.port != '') {
                linkUrl += ":" + window.location.port;
            }
            linkUrl = linkUrl + "/Inbox";
            window.location.href = linkUrl;
        }
    </script>
</asp:Content>
