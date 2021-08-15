<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="SavedNews.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SavedNews" %>

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
    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
    <%--   <style type="text/css">
        .newsTags {
            font-size: 11px;
            padding-left: 0;
            padding: 0;
            margin: 0;
            font-weight: normal;
            font-family: tahoma;
            direction: rtl;
            float: right;
            max-width: 383px;
            white-space: nowrap;
            color: #666;
            margin-right: 30px;
        }

            .newsTags a {
                color: #999;
                margin-left: 5px;
                display: inline-block;
                padding: 2px 4px;
                background: rgba(245, 240, 240, 0.70);
                border-radius: 4px;
            }

                .newsTags a:hover {
                    color: #333;
                }

        .feederNews {
            background: #ca0707;
            color: #fff !important;
            font-size: 10px !important;
            border: 1px solid #ca0709;
            border-radius: 5px;
            padding: 2px 4px;
            line-height: 11px !important;
            /* font-size: 11px !important; */
            margin-right: 0 !important;
            margin-left: 2px !important;
            float: initial !important;
        }

        .feederContainer {
            padding: 10px 1px;
        }

            .feederContainer div {
                float: right;
                margin-left: 10px;
            }

        .feederCheckbox {
            cursor: pointer;
            -moz-transition: all 0.3s ease-in;
            -o-transition: all 0.3s ease-in;
            -webkit-transition: all 0.3s ease-in;
            transition: all 0.3s ease-in;
            border-bottom: 2px solid transparent;
        }

            .feederCheckbox input {
                padding: 2px;
                height: 14px;
                border: 1px solid #ccc;
                width: 14px;
                background: #fff;
                box-shadow: 0px 0px 3px #ccc;
                position: relative;
                top: 3px;
            }

            .feederCheckbox label {
                cursor: pointer;
            }

            .feederCheckbox.org {
                background-color: #94c8fb !important;
                color: #fff;
                padding: 4px 1px 6px 4px;
                border-radius: 2px;
            }

            .feederCheckbox.notorg {
                background-color: #c65556 !important;
                color: #fff;
                padding: 4px 1px 6px 4px;
                border-radius: 2px;
            }

            .feederCheckbox.org.active {
                border-bottom: 2px solid #333;
                background-color: #0a85b1 !important;
            }

            .feederCheckbox.notorg.active {
                border-bottom: 2px solid #333;
                background-color: #ca0709 !important;
            }
    </style>--%>
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="display: none;" />
    <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="display: none;" />
    <asp:HiddenField ID="hdfUserCustomSort" runat="server" />
    <asp:HiddenField ID="hdfUserID" runat="server" />
    <div class="PageSubLink">
        <ul>
            <li><a href="/News/Latest/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/Analysis" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوا</a></li>
            <li><a href="/keywords" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه</a></li>
            <li><a href="/KeywordAnalyse" runat="server"><span><i class="fab fa-keycdn"></i></span>آنالیز کلید واژه ها</a></li>
            <li><a href="/News/BultanArchive" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="/addnews" runat="server"><span><i class="fas fa-pen-square"></i></span>ثبت خبر</a></li>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="fas fa-hdd"></i></span>اخبار ذخیره شده</a></li>
            <li><a href="#" id="lnk_bultan" class="flat-gray-button"><span><i class="fas fa-file-alt"></i></span>بولتن</a></li>
            <%--<li><a href="#" id="lnk_category" class="flat-gray-button"><span><i class="fas fa-cubes"></i></span>دسته بندی اخبار</a></li>--%>
        </ul>
    </div>


    <section class="posts">
        <div class="control-box category NewsKeyBox">
            <asp:Repeater ID="rpt_Groups" runat="server" OnItemDataBound="rpt_Groups_ItemDataBound">
                <ItemTemplate>
                    <div id="group_item" class="group_item" runat="server">
                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                        <span id="color_span" runat="server">
                            <asp:CheckBox ID="check_selected_group" runat="server" />
                        </span>
                        <a href="#" data-id='<%# Eval("KeyId") %>' class="switchkeyword">
                            <label><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("KeywordName")) %></label>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="control-box bultan newsBultan persian">

            <div>
                <div>
                    <a href="#" id="btn_SelectAll" class="btn btn-outline-dark cur-p" title="انتخاب کلیه اخبار"><span class="entypo-check">انتخاب کلیه اخبار</span></a>
                    <asp:LinkButton ID="btn_reset" runat="server" class="btn btn-outline-dark cur-p" OnClick="btn_reset_Click" OnClientClick="return confirm('آیا برای ریست کردن تنظیمات اطمینان دارید ؟')">
                            حذف تنظیمات
                    </asp:LinkButton>
                    <asp:Button ID="btn_exportWordTitr" runat="server" Text="Word تیتر" CssClass="btn btn-outline-dark cur-p" OnClick="btn_exportWordTitr_Click" />
                    <asp:Button ID="btn_exportWordShort" runat="server" Text="Word خلاصه" CssClass="btn btn-outline-dark cur-p" OnClick="btn_exportWordShort_Click" />
                    <asp:Button ID="btn_exportWord" runat="server" Text="خروجی Word" CssClass="btn btn-outline-dark cur-p" OnClick="btn_exportWord_Click" />
                    <asp:Button ID="btn_generate" runat="server" Text="خروجی PDF" CssClass="btn btn-outline-dark cur-p" />
                    <asp:Button ID="btn_PrintLead" runat="server" Text="چاپ خلاصه اخبار" CssClass="btn btn-outline-dark cur-p" />
                    <asp:Button ID="btn_printTitle" runat="server" Text="چاپ تیتر اخبار" CssClass="btn btn-outline-dark cur-p" OnClick="btn_printTitle_Click" />
                    <asp:Button ID="btn_db" runat="server" Text="خروجی DB" CssClass="btn btn-outline-dark cur-p" OnClick="btn_db_Click" />
                    <%-- <asp:Button ID="btn_saveState" runat="server" Text="ذخیره وضعیت" CssClass="flat-gray-button" OnClick="btn_saveState_Click" />--%>
                </div>
                <br />
                <div>
                    <asp:CheckBox ID="check_NewsPaper" runat="server" CssClass="CheckBox" Text="روزنامه" />
                    <asp:CheckBox ID="check_highlight" runat="server" CssClass="CheckBox" Text="هایلایت کلید واژه ها" />
                    <asp:CheckBox ID="check_related" runat="server" CssClass="CheckBox" Text="شناسایی اخبار مرتبط" />
                    <asp:CheckBox ID="check_ChartKhabar" runat="server" CssClass="CheckBox" Text="نمودار" />
                    <asp:CheckBox ID="check_Sima" runat="server" CssClass="CheckBox" Text="صداوسیما" />
                    <asp:CheckBox ID="check_gozideh" runat="server" CssClass="CheckBox" Text="گزیده رسانه" />
                    <asp:CheckBox ID="check_mashrooh" runat="server" CssClass="CheckBox" Text="مشروح اخبار" />
                    <asp:CheckBox ID="check_addArchive" runat="server" CssClass="CheckBox" Text="اضافه کردن به آرشیو بولتن" />

                </div>
                <br />
                <div>
                    <label>عنوان بولتن</label>
                    <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" Text="فاقد عنوان" />
                    <label>قالب چاپی</label>
                    <asp:DropDownList ID="drp_template" runat="server" CssClass="btn btn-outline-info cur-p dropdown dropdown-toggle" Width="200px" />
                </div>
                <div>
                    <a href="#" id="lnk_download" style="display: none">دریافت فایل</a>
                </div>
            </div>


            <div class="userSorting clearfix">
                <h4 class="right">
                    <span class="fontawesome-sort" style="font-size: 13px; color: #073cb9;"></span>
                    مرتب سازی مطالب</h4>
                <ul class="left">
                    <li class="selected" id="sortByKeyword">
                        <a class="sortByKeyword" href="#sortByKeyword">کلیدواژه</a>
                    </li>
                    <li id="sortByTimeSort">
                        <a class="sortByTimeSort" href="#sortByTimeSort">زمان انتشار</a>
                    </li>
                    <li id="sortBySite">
                        <a class="sortBySite" href="#sortBySite">نام رسانه</a>


                    </li>
                    <li id="sortByCustom">
                        <a class="sortByCustom" href="#sortByCustom">اولویت سفارشی</a>
                        <i></i>

                    </li>
                    <li id="sortByTitle">
                        <a class="sortByTitle" href="#sortByTitle">عناوین</a>
                        <i></i>

                    </li>


                </ul>

            </div>
        </div>

        <div class="feederContainer clearfix newsStreamHeaderOutOfBox">
            <div class="btn btn-info cur-p">
                <asp:CheckBox runat="server" ID="chbOrgNews" ClientIDMode="Static" CssClass=" smallCheckBox feederCheckbox org active CheckBox" Checked="true" Text="منابع رسمی" Style="height: 100%;" />
            </div>
            <div class="btn btn-danger cur-p">
                <asp:CheckBox runat="server" ID="chbNotOrgNews" ClientIDMode="Static" CssClass=" smallCheckBox feederCheckbox notorg active CheckBox" Checked="true" Text="منابع غیر رسمی" Style="height: 100%;" />
            </div>
        </div>
        <div class="saveNews persian newsStream">
            <asp:Repeater ID="news_list" runat="server" OnItemDataBound="news_list_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list">
                </HeaderTemplate>
                <ItemTemplate>
                    <article data-id='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class="show">
                        <div class="post-content" id="news_row" runat="server">
                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                            <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                                <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsId") %>'>
                                    <img src="/Pages/P-Art/Images/del16.png" /></a>
                            </asp:PlaceHolder>
                            <span runat="server" id="ColorSpan" class="rightColorSpan"></span>
                            <%--<asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />--%>
                            <span class="rowIndex newsRowIndex"><%# Container.ItemIndex + 1 %> )</span>
                            <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews CheckBox" />
                            <h2>
                                <%#  CheckIsNewsFeed(Eval("IsFeederNews"))  %>
                                <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                    runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                </a>
                            </h2>
                            <span title='<%# Eval("SiteTitle") %>' class="siteTitle"><%# Eval("SiteTitle") %></span>
                            <span class="detailToggle"><i class="fas fa-bars detailLead" id='showLead_<%# Eval("NewsId") %>' data-lead='<%# Eval("NewsLead") %>'
                                data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("KeywordName") %>'
                                data-link='<%# Eval("NewsLink")%>' data-keyword='<%# Eval("KeywordName") %>'></i></span>
                            <div class="newsrate" runat="server">
                                <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                            </div>

                            <span class="rowDateTime ">
                                <label id="date"><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %></label>
                            </span>
                        </div>
                        <div class="newsTags" style="display: none;" id='selectedLead_<%# Eval("NewsId") %>'>
                            <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                            <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                        </div>
                    </article>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

        </div>
    </section>

    <asp:GridView ID="grd_word" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>

            <asp:TemplateField>
                <ItemStyle Wrap="true" Width="595px" />
                <HeaderTemplate>
                    <div style="overflow-x: scroll; white-space: normal; width: 595px">
                </HeaderTemplate>
                <ItemTemplate>
                    <%--<ItemStyle Wrap="True" />--%>
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

                        <asp:Literal runat="server" ID="ltLead" Text='<%#   (Eval("NewsLead").ToString()) %>'>

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
                    <%--<ItemStyle Wrap="True" />--%>
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

                        <asp:Literal runat="server" ID="ltLead" Text='<%#  (Eval("NewsLead").ToString()) %>'>

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
                    <%--  <ItemStyle Wrap="True" />--%>
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

    <%--    <div class="shadowModal"></div>--%>
    <div class="modalSiteSort">
        <div class="modalHeader"></div>
        <div class="modalContainer clearfix">
            <asp:Repeater runat="server" ID="rptSiteSort">
                <HeaderTemplate>
                    <div class="containerSiteSort right ">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="sortItem">

                        <asp:TextBox placeholder="اولویت نمایش" runat="server" ID="txtSortOrder" CssClass="numbericBox" Width="50px"></asp:TextBox>

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
            $(".news_list article").sort(sort_custom) // sort elements
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
        function sort_title(a, b) {
            return ($(b).data('title')) < ($(a).data('title')) ? 1 : -1;
            return b - a;
            //var keyA = $(a).data('title');
            //var keyB = $('td:eq(0)',b).text();

            //    return (keyA< keyB) ? 1 : 0;


        }
        function sortArticleIndex() {
            var counter = 1;
            // alert('yes');
            $('.news_list article.show').each(function (index) {
                var $this = $(this);
                $this.find('.post-content').find('span.rowIndex').text(parseInt(counter) + ")");
                counter++;
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
            sortArticleIndex();
            //  e.preventDefault();

            var allText = "";
            // update control-box group_item
            $('.group_item').each(function () {
                var $this = $(this);


                allText += "," + $this.find('label').text().trim() + ",";
            });
            var lstAllGroupItem = $('.group_item label');
            $('.newsTags a').each(function () {
                var $this = $(this);
                var txt = "," + $this.text().trim() + ",";
                if (allText.indexOf(txt) == -1) {
                    allText += txt;

                    var data_keyid = $this.attr('data-keyid');
                    var data_color = $this.attr('data-color');
                    var data_text = $this.attr('data-text');

                    var html = "<div id='group_item' class='group_item'>" +
                        "<input type='hidden' name='ctl00$Content$rpt_Groups$ctl01$fld_color' id='fld_color' value='" + data_color + "'>" +
                        "<span id='color_span' style='background-color:" + data_color + ";'>" +
                            "<input id='check_selected_group' type='checkbox' name='ctl00$Content$rpt_Groups$ctl01$check_selected_group'>" +
                        "</span>" +
                        "<a href='#' data-id='" + data_keyid + "' class='switchkeyword'>" +
                            "<label>" + data_text + "</label>" +

                        "</a>" +
                    "</div>";

                    $('.control-box.category').append(html);
                }

            });


        });

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
    </script>
</asp:Content>
