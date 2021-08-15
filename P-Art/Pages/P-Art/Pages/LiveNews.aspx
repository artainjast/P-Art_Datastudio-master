<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="LiveNews.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.LiveNews" %>

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

    <asp:HiddenField ID="hdfUserCustomSort" runat="server" />
    <asp:HiddenField ID="hdfUserID" runat="server" />
    <asp:HiddenField ID="NewsIdParminId" runat="server" Value='' />
    <div class="PageSubLink">
        <ul>
            <li><a href="#" id="lnk_filter" class="flat-gray-button"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
            <li><a href="#" id="lnk_category" class="flat-gray-button"><span><i class="fas fa-cubes"></i></span>دسته بندی اخبار</a></li>
            <li><a href="#" id="SearchWithKeywords" class="flat-gray-button"><span><i class="fas fa-cubes"></i></span>آخرین اخبار</a></li>
            <li><a href="#" id="ShowAllKeywords"><span><i class="fas fa-ellipsis-h"></i></span>اطلاعات بیشتر</a></li>
        </ul>
    </div>

    <section class="posts">

        <div class="control-box category AllKeywordBox">
            <asp:Repeater ID="KeywordsRepeater" runat="server" OnItemDataBound="KeywordsRepeater_ItemDataBound">
                <ItemTemplate>
                    <div id="KeywordGroup" class="KeywordGroup" runat="server">
                        <asp:HiddenField ID="KeywordHiddenFieldColor" runat="server" Value='<%# Eval("Color") %>' />
                        <span id="CheckBoxColor" runat="server">
                            <input data-id='<%# Eval("KeyId")%>' type="checkbox" id="SelectCheckBox" runat="server" class="AspCheckBox" />
                        </span>
                        <a href="#" data-id='<%# Eval("KeyId") %>' class="KeywordTitle">
                            <label><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("KeywordName")) %></label>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <div class="ShowLiveNewsByKey  btn btn-info cur-p ">نمایش اخبار</div>
            <asp:Literal runat="server" ID="ltKeywords"></asp:Literal>
        </div>
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
            
        </div>
        <div class="control-box filter newsFilter persian">
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
                    <span>منبع خبری</span>
                    <asp:DropDownList ID="drp_NewsSource" Width="95px" runat="server" CssClass="btn btn-outline-info cur-p" Style="min-width: 200px" />
                </span>

            </div>

            <br />
            <div>
                <span>
                    <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
                </span>
            </div>
        </div>

        <div class="newsSection persian newsStream LiveNews">
            <asp:Repeater ID="news_list" runat="server" OnItemDataBound="news_list_ItemDataBound">

                <HeaderTemplate>
                    <div class="selectAllStreemNews">
                        <asp:CheckBox CssClass="selectAllStreemNewsCheckBox CheckBox" Text="انتخاب تمامی اخبار" runat="server" />
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="showFehrest">
                        <article data-id='<%# Eval("NewsId") %>'
                            data-keyword='<%# Eval("KeywordId") %>' data-title='<%# Eval("NewsTitle") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>'>
                            <div class="post-fehrest" runat="server" id="post">

                                <asp:HiddenField ID="hddNewsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                <span runat="server" id="ColorSpan" class="rightColorSpan"></span>
                                <span class="rowIndex newsRowIndex"><%# Container.ItemIndex + 1 %> )</span>
                                <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews CheckBox" />
                                <span class="iconNewsType"><i id="iconNewsType" class="<%# ChangeIcon(Eval("SiteType").ToString()) %> iconType"></i></span>
                                <h2>
                                    <a data-keyid='<%# Eval("KeywordName") %>' data-keyword='<%# Eval("KeywordName") %>' target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' runat="server">
                                        <%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),100) %></a>
                                </h2>
                                <span title='<%# Eval("SiteTitle") %>' class="siteTitle"><%# Eval("SiteTitle") %></span>

                                <span class="detailToggle"><i class="fas fa-bars detailLead" id='showLead_<%# Eval("NewsId") %>'
                                    data-newsid='<%# Eval("NewsId") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("KeywordName") %>'
                                    data-keyword='<%# Eval("KeywordName") %>'></i></span>
                                <%-- <div class="newsrate" runat="server">
                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                </div>--%>
                                <span class="rowDateTime ">
                                    <label id="date"><%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %></label>
                                </span>
                            </div>
                        </article>
                        <div class="newsTags" style="display: none;" id='selectedLead_<%# Eval("NewsId") %>'>
                            <asp:Literal runat="server" ID="ltTags" Text='<%# Eval("KeywordName") %>'></asp:Literal>
                            <br />
                            <asp:Literal runat="server" ID="Literal1" Text='<%# Eval("NewsLead") %>'></asp:Literal>
                            <asp:HiddenField runat="server" ID="hdfNewsTags" Value='<%# string.Format(",{0},", Eval("KeyIds")) %>'></asp:HiddenField>

                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate>
                    <div class="ShowLiveNewsButtonContainer">
                        <div class="ShowLiveNewsButton  btn btn-info cur-p ">نمایش اخبار انتخاب شده</div>
                    </div>

                </FooterTemplate>

            </asp:Repeater>
        </div>

    </section>

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

            $('.news_list article.show').each(function (index) {
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
            $('.newsTags a').each(function () {
                //alert('ok2');
                var $this = $(this);
                var txt = "," + $this.text().trim() + ",";
                //alert(allText.indexOf(txt));
                if (allText.indexOf(txt) == -1) {
                    //alert('ok3');
                    allText += txt;
                    // alet(allText);
                    var data_keyid = $this.attr('data-keyid');
                    // alert(data_keyid);
                    var data_color = $this.attr('data-color');
                    // alert(data_color);
                    var data_text = $this.attr('data-text');
                    //alert(data_text);

                    var html = "<div id='group_item' class='group_item'>" +
                        "<input type='hidden' name='ctl00$Content$rpt_Groups$ctl01$fld_color' id='fld_color' value='" + data_color + "'>" +
                        "<span id='color_span' style='background-color:" + data_color + ";'>" +
                            "<input id='check_selected_group' class='nonAspCheckBox' type='checkbox' name='ctl00$Content$rpt_Groups$ctl01$check_selected_group'>" +
                        "</span>" +
                        "<a href='#' data-id='" + data_keyid + "' class='switchkeyword'>" +
                            "<label>" + data_text + "</label>" +

                        "</a>" +
                    "</div>";

                    $('.control-box.category').append(html);
                }

            });


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

        $("#ShowAllKeywords").click(function () {
            $('.newsTags').fadeToggle(500);
        });


        $(".selectAllStreemNewsCheckBox input").click(function () {
            $(".check_SelectNews input").prop("checked", $(this).prop("checked"));
        });



        $(".ShowLiveNewsButton").click(function () {
            $('.LiveNewsContainer').fadeIn();

            var NewsIds = "";
            $("#check_SelectNews:checked").each(function () {
                NewsIds += "," + $(this).closest("article").attr("data-Id");
            });

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/LiveNews.aspx/ShowLiveNews",
                data: "{'NewsIds':'" + NewsIds + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var LiveNewshtml = "";
                    for (var i = 0; i < data.d.length; i++) {
                        LiveNewshtml += "<div class='mySlides fade'>";
                        LiveNewshtml += "<div class='MetaDataContainer'>";
                        LiveNewshtml += "<span class='DateTime'>" + data.d[i].MetaData + " </span><span class='SiteName'>" + data.d[i].SiteName + "</span>";
                        LiveNewshtml += "</div>";
                        LiveNewshtml += "<h1 class='Title'>" + data.d[i].Title + "</h1><br />";
                        LiveNewshtml += "<div class='Lead'>" + data.d[i].Lead + "</div><br />";
                        LiveNewshtml += "<div class='numbertext'>صفحه " + (i + 1).toString() + " از " + data.d.length + "</div>";
                        LiveNewshtml += "</div>"
                    }
                    $('.slideshow-container').empty();
                    $('.slideshow-container').append(LiveNewshtml);
                    setTimeout(showSlides, 5000);
                },
                error: function (msg) {

                    alert("خطا");
                }

            }
            );
            e.preventDefault();
        });


        var slideIndex = 0;


        function showSlides(n) {
            var i;
            var slides = $(document).find(".mySlides");
            if (n > slides.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) { slideIndex = 1 }
            slides[slideIndex - 1].style.display = "block";
            setTimeout(showSlides, 10000); // Change image every 2 seconds
        }


        $("#SearchWithKeywords").click(function () {
            $(".AllKeywordBox").toggleClass('show');
        });


      
        $(".ShowLiveNewsByKey").click(function () {
            $('.LiveNewsContainer').fadeIn();
            AutoUpdateSlides();
           
        });



        function AutoUpdateSlides()
        {
            var KeyIds = "";
            $("#CheckBoxColor input:checked").each(function () {
                KeyIds += "," + $(this).attr("data-Id");
            });

            var parmin = $("#NewsIdParminId").val();
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/LiveNews.aspx/ShowLiveNewsByKeyIDs",
                data: "{'parmin': '" + parmin + "','KeyIds':'" + KeyIds + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var LiveNewshtml = "";
                    for (var i = 0; i < data.d.length; i++) {
                        LiveNewshtml += "<div class='mySlides fade'>";
                        LiveNewshtml += "<div class='MetaDataContainer'>";
                        LiveNewshtml += "<span class='DateTime'>" + data.d[i].MetaData + " </span><span class='SiteName'>" + data.d[i].SiteName + "</span>";
                        LiveNewshtml += "</div>";
                        LiveNewshtml += "<h1 class='Title'>" + data.d[i].Title + "</h1><br />";
                        LiveNewshtml += "<div class='Lead'>" + data.d[i].Lead + "</div><br />";
                        LiveNewshtml += "<div class='numbertext'>صفحه " + (i + 1).toString() + " از " + data.d.length + "</div>";
                        LiveNewshtml += "</div>"
                    }
                    $('.slideshow-container').empty();
                    $('.slideshow-container').append(LiveNewshtml);
                    setTimeout(showSlidesKey, 5000);

                   

                },
                error: function (msg) {

                    alert("خطا");
                }

            }
            );

            e.preventDefault();
        }



        var slideIndexKey = 0;


        function showSlidesKey(n) {
            var i;
            var slides = $(document).find(".mySlides");
            if (n > slides.length) {
                slideIndexKey = 0;
                AutoUpdateSlides();
            }
            if (n < 1) { slideIndexKey = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndexKey++;
            if (slideIndexKey > slides.length) {
                slideIndexKey = 0
                AutoUpdateSlides();
            }
            slides[slideIndexKey - 1].style.display = "block";
            setTimeout(showSlidesKey, 10000); // Change image every 10 seconds
        }
    </script>
</asp:Content>
