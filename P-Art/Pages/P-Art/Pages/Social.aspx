<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="Social.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Social" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.carouFredSel-6.1.0-packed.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.mousewheel.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.touchSwipe.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.ba-throttle-debounce.min.js")%>' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/jquery.qtip.js"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js"></script>
 
    <script type="text/javascript">
        $(document).ready(function () {

            Page_Init();
        });
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

        }
    </script>
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <div class="PageSubLink">
        <ul>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/TwitterAnalyze/" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای توییتر</a></li>
            <li><a href="/TwitterKeywords/" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a href="/TwitterBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a id="btnShowSocialKey"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
            <li><a id="btnShowBooltanKey"><span><i class="fas fa-file-alt"></i></span>بولتن موضوعی</a></li>
        </ul>
    </div>



    <div id="SocialKeyBox" class="SocialKeyBox">
        <asp:Repeater ID="SocialKeyCheckBox" runat="server" OnItemDataBound="SocialKey_ItemDataBound">
            <ItemTemplate>
                <div id="group_item" class="group_item" runat="server">
                    <span id="color_span" runat="server" class="ch">
                        <asp:CheckBox ID="check_selected_group" runat="server" />
                    </span>
                    <asp:HiddenField ID="hddsocialkeyid" Value='<%# Eval("SocialMediaKeyID") %>' runat="server" />
                    <a href="#" data-id='<%# Eval("SocialMediaKeyID") %>' class="switchkeyword1">
                        <label id="lable1" style="color: gray;" data-keyword='<%# Eval("Title") %>' runat="server"><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("Title")) %></label>

                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="SocialKeyBoxFooter">
            <span>از تاریخ</span>
            <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" />
            <span>تا تاریخ</span>
            <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" />
            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-primary cur-p" Text="نمایش پست ها" OnClick="btn_ShowNews_Click" />
        </div>
    </div>

    <div class="control-box1 category" style="border: 1px solid #68bfe0; padding: 5px; display: none;">

        <asp:Repeater ID="rpt_Groups" runat="server" OnItemDataBound="rpt_Groups_ItemDataBound">
            <ItemTemplate>
                <div id="group_item" class="group_item" runat="server">

                    <span id="color_span" runat="server" class="ch">
                        <asp:CheckBox ID="check_selected_group" runat="server" />
                    </span>
                    <asp:HiddenField ID="hddsocialkeyid" Value='<%# Eval("SocialMediaKeyID") %>' runat="server" />
                    <a href="#" data-id='<%# Eval("SocialMediaKeyID") %>' class="switchkeyword1">
                        <label id="lable1" data-keyword='<%# Eval("Title") %>' runat="server"><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("Title")) %></label>

                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Literal runat="server" ID="ltKeywords"></asp:Literal>
    </div>

    <div class="SocialFilter" style="position: relative;" runat="server" id="divFilter">
        <div class="ItemForm">
            <label style="display: inline-block; font-weight: bold;">عنوان بولتن</label>
            <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" placeholder="فاقد عنوان"/>
            <asp:CheckBox ID="check_ChartKhabar" runat="server" Text="نمودار" />
            <a id="btn_generateGroupHtml" class="btn btn-primary cur-p ControlRightMargin" runat="server" onclick="GetSocialBultan(this)"><i class="fas fa-file-alt ControlLeftMinPadding ControlShiftBottomMin"></i>بولتن موضوعی</a>
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

    <section class="posts1 socialTableRows">


        <div class="newsSection socialTableHeader">
            <asp:Repeater ID="news_list" runat="server" OnItemDataBound="news_list_ItemDataBound">

                <HeaderTemplate>
                    <table class="headtable">
                        <thead>
                            <tr style="width: 100%">
                                <%--<th style="width: 15px;">ردیف</th>--%>
                                <th style="width: 200px; cursor: pointer;">
                                    <asp:CheckBox ID="btn_SelectAllSocial" runat="server" Text="انتخاب تمامی اخبار" CssClass="socialTableHeaderButton" /></th>
                                <th style="width: calc(100% - 440px);">
                                    <asp:Button CssClass="socialTableHeaderButton" runat="server" ID="btnmatn" OnClick="btnmatn_Click" Text="متن" class="btnmatn" /></th>
                                <th style="width: 50px; text-align: right;">
                                    <asp:Button CssClass="socialTableHeaderButton"
                                        runat="server" Text="باز نشر" ID="Button3" OnClick="btnRetweet_Click"></asp:Button></th>

                                <th style="width: 44px;">
                                    <asp:Button CssClass="socialTableHeaderButton"   runat="server" Text="نظرات" ID="Button4" OnClick="btncm_Click" /></th>
                                <th style="width: 44px;">
                                    <asp:Button CssClass="socialTableHeaderButton"
                                        runat="server" Text="پسند" ID="Button5" OnClick="btnlike_Click" /></th>
                                <th style="width: 90px;">زمان</th>

                            </tr>
                        </thead>
                    </table>
                    </div>
                    <div class="news_list persian">
                </HeaderTemplate>
                <ItemTemplate>
                    <%--field-tip--%>
                    <article data-id='groupOrderItem_<%# Eval("SocialMediaPostID") %>' data-order="" class="show">
                        <%--<span class="tip-content"></span>--%>
                        <%--<span class="field-tip">--%>
                        <div runat="server" id="post">

                            <%--</span>--%>
                            <asp:HiddenField ID="hddNewsId" runat="server" Value='<%# Eval("SocialMediaPostID") %>' />
                            <asp:HiddenField ID="txt_row_index" runat="server" Value='<%# Eval("Row") %>' />

                            <%--<span class="tooltiptext">'<%# Eval("UserName") %>'</span>--%>

                            <div class="post-content" id="news_row" runat="server">
                                <span class="rowIndex"><%# Container.ItemIndex + 1 %>) </span>
                                <div class="check_SelectNews">
                                    <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                                    <%--  <i class="fa fa-twitter" aria-hidden="true" style="margin-top: -18px; margin-right: 27px;"></i>--%>
                                </div>


                                <h2>
                                    <span class="tooltip">
                                        <a target="_blank" href="<%# Eval("LinkUrl") %>">
                                            <%# Eval("Text") %>
                                            <span class="arrow_box english"><span><i class="far fa-user favIconLeft" data-fa-transform="shrink-8"></i></span><span style="top:-3px; position:relative"><%# Eval("UserName") %></span></span>
                                            <%--<%#PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("Text").ToString(),120) %>'<i class=" "></i>--%>
                                        </a>
                                    </span>
                                </h2>
                                <span class="RetweetCont persian"><i class="fas fa-retweet" aria-hidden="true"></i><%# Eval("RetweetCount") %></span>
                                <span class="CommentsCont persian"><i class="far fa-comments" aria-hidden="true"></i><%# Eval("CommentCount") %></span>
                                <span class="LikeCont persian"><i class="far fa-thumbs-up" aria-hidden="true"></i><%# Eval("LikeCount") %></span>
                                <span class="TweetDate persian">
                                    <label id="date" class="date"><%# DiffrentDate(Eval("PosteDateIndex").ToString()) %></label></span>
                                <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />

                                <div class="newsrate1 newsTags" style="display: none;" id='selectedLead_<%# Eval("NewsValue")%>'>
                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>
                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("SocialMediaPostID")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("SocialMediaPostID")%>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("SocialMediaPostID")%>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                </div>
                                <%-- <i class="fas fa-bars detailLead" id='showLead_<%# Eval("SocialMediaPostID") %>'
                                    data-newsid='<%# Eval("SocialMediaPostID") %>' onclick="ShowLead(this)" data-keyid='<%# Eval("SocialMediaKeyID_FK") %>'
                                    data-link='<%# Eval("LinkUrl")%>' data-keyword='<%# Eval("Title") %>'></i>--%>
                            </div>
                            <%--   <div class="newsTags" style="display: none;" id='selectedLead_<%# Eval("SocialMediaPostID") %>'>
                                <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                            </div>--%>
                        </div>
                    </article>

                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

            <%--       <div style="margin-top: 20px;">
                <table class="tblpaging">
                    <tr>

                        <td>
                            <asp:DataList ID="rptPaging" runat="server"
                                OnItemCommand="rptPaging_ItemCommand"
                                OnItemDataBound="rptPaging_ItemDataBound"
                                RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbPaging" runat="server"
                                        CommandArgument='<%# Eval("PageIndex") %>'
                                        CommandName="newPage"
                                        Text='<%# Eval("PageText") %> ' Width="20px">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>

                        <td>
                            <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                        </td>
                   </tr>
                </table>

            </div>--%>
        </div>
    </section>
    <script>
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

        function sort_timesort(a, b) {
            return ($(b).data('timesort')) > ($(a).data('timesort')) ? 1 : -1;
        }

        function sortArticleIndex() {
            var counter = 1;
            //alert('yes');
            $('.news_list article.show').each(function (index) {
                var $this = $(this);
                $this.find('.post-content').find('span.rowIndex').text(parseInt(counter) + ")");
                counter++;
            });
        }
        function GetSelectedNews() {
            SelectedNews = ",";
            $(".posts1 article.show").each(function () {
                var postRow = $(this);
                var newsId = $(postRow).find("#hddNewsId").val();
                var newsIndex = $(postRow).find("#txt_row_index").val();
                if (newsIndex == "") newsIndex = "1000";
                if ($(postRow).find("#check_SelectNews").attr('checked')) {
                    SelectedNews += newsId + ";" + newsIndex + ",";
                }
            });


        }
        //$(window).load(function () {
        //    //alert('1');
        //    $(".news_list article.show").sort(sort_timesort) // sort elements
        //          .appendTo('.news_list'); // append again to the list

        //    $('.userSorting ul li').removeClass('selected');
        //    $('#sortByTimeSort').addClass('selected');
        //    sortArticleIndex();
        //    //  e.preventDefault();
        //});

        $("#btnShowSocialKey").click(function () {
            $("#SocialKeyBox").fadeToggle(1000);
        });

        $("#btnShowBooltanKey").click(function () {
            $(".SocialFilter").fadeToggle(1000);
        });

        $("article input:checkbox").click(function () {
            $(this).parents("article").toggleClass("SetCeckedbackgroundColor");
        });

    </script>

</asp:Content>
