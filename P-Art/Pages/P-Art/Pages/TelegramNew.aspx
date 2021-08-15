<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="TelegramNew.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.TelegramNew" %>

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
            <li><a href="/TelegramAnalyze/" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای تلگرام</a></li>
            <li><a id="keywordPageButton" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a href="/TelegramBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a id="ShowTelegramFilterButton"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
            <li><a id="ShowTelegramBooltanButton"><span><i class="fas fa-file-alt"></i></span>بولتن موضوعی</a></li>
            <li><a href="#" id="ShowAllKeywords"><span><i class="fas fa-ellipsis-h"></i></span>نمایش کلید واژه ها</a></li>
            <li><a onclick="GotoInbox(this)" class="flat-gray-button"><span><i class="fas fa-inbox" aria-hidden="true"></i></span>اینباکس من</a></li>
        </ul>
    </div>


    <div id="SocialKeyBox" class="SocialKeyBox">
        <asp:Repeater ID="SocialKeyCheckBox" runat="server" OnItemDataBound="SocialKey_ItemDataBound">
            <ItemTemplate>
                <div id="group_item" class="group_item" runat="server">
                    <span id="color_span" runat="server" class="ch">
                        <asp:CheckBox ID="check_selected_group" runat="server" />
                    </span>
                    <asp:HiddenField ID="hddsocialkeyid" Value='<%# Eval("ID") %>' runat="server" />
                    <a href="#" data-id='<%# Eval("ID") %>' class="switchkeyword1">
                        <label id="lable1" style="color: gray;" data-keyword='<%# Eval("Title") %>' runat="server"><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("Title")) %></label>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="SocialKeyBoxFooter">

            <span>از تاریخ</span>
            <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" />
            <span>از ساعت</span>
            <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align: center" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
                ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
            </asp:RegularExpressionValidator>
            <br />
            <br />
            <span>تا تاریخ</span>
            <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" />
            <span>تا ساعت</span>
            <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align: center" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour"
                ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
            </asp:RegularExpressionValidator>


            <br />
            <br />
            <span>کلید واژه</span>
            <asp:TextBox ID="txt_search" runat="server" CssClass="textbox" />
            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-primary cur-p" Text="نمایش پست ها" OnClick="btn_ShowNews_Click" />
        </div>
    </div>
    <div class="newsBultan">

        <span>عنوان بولتن</span>
        <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" placeholder="فاقد عنوان" />
        <a id="HTMLTelegramButton" class="btn btn-info cur-p">ساخت بولتن</a>
        <asp:HiddenField ID="NewsIdParminId" runat="server" Value='' />

    </div>

    <div class="TelegramPage persian">
        <asp:Repeater ID="TelegramMassageRepeater" runat="server">
            <HeaderTemplate>
                <div class="newsStream">
                    <div class="newsStreamHeader">
                        <span class="TelegramSelectAllItem">
                            <input type="checkbox" name="TelegramSelectAllItem" class="CheckBox" />انتخاب همه
                        </span>

                        <span>پیام رسان تلگرام</span>
                    </div>
            </HeaderTemplate>

            <ItemTemplate>
                <div class="showFehrest">
                    <article data-id="<%# Eval("ID") %>">
                        <asp:HiddenField ID="MassageIdHiddenField" runat="server" Value='<%# Eval("ID") %>' />


                        <div class="top-post">
                            <div class="first-row">
                                <div style="display:none;" class="image-site">
                                    <img src='' />
                                </div>
                                <i class="fa fa-dot-circle"></i><span class="siteTitle"><%# GetChannelName(int.Parse(Eval("ChannelID").ToString())) %></span>

                                <div class="telegramNewsrate" runat="server">
                                    <a href="#" class="btn_news_notok" title="خبر منفی"
                                        itemid='<%# Eval("ID") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>
                                    <a href="#" class="btn_news_irrelevant" title="خبر بی ربط"
                                        itemid='<%# Eval("ID") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"4") %>'></a>
                                    <a href="#" class="btn_news_empty" title="خبر خنثی"
                                        itemid='<%# Eval("ID") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_lowـcommunication" title="خبر کم ارتباط"
                                        itemid='<%# Eval("ID") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"3") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت"
                                        itemid='<%# Eval("ID") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>
                                </div>
                            </div>
                            <div style="display:none;" class="second-row">
                                <span class="sitelink"></span>
                            </div>
                            <div class="third-row">
                                <div class="image-news">
                                    <img src='/Styles/img/telegram512.png' />
                                </div>
                                <div class="newslead-content">
                                    <p class="newslead"><%#PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("MessageText").ToString(),700) %></p>
                                </div>
                            </div>
                            <div class="fourth-row">
                                <i class="fa fa-calendar"></i>
                                <span class="rowDateTime ">
                                    <label id="date"><%# Eval("MessageDate") %></label>
                                    <label id="sep">-</label>
                                    <label id="Time"><%# Eval("MessageTime") %></label>
                                </span>
                            </div>
                        </div>
                        <div class="bottom-post">
                            <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="CheckBox telegramCheckbox" />
                            <a data-id='<%# Eval("ID") %>' class="cur-p add-inbox" onclick="addToInbox(this)"><span class="inb-title">افزودن به اینباکس</span></a>
                            <span class="divider">|</span>
                            <a class="cur-p shownews" target="_blank" href='/TelegramMessageShow/<%# Eval("ID") %>'><i class="fa fa-chain"></i><span class="inb-title">شاهد خبر</span></a>
                            <span class="TelegramViewCount persian"><i class="fas fa-eye" aria-hidden="true"></i><%# Eval("ViewCount") %></span>
                        </div>

                    </article>
                    <div class="newsTags" style="display: none;" id='keyId<%# Eval("KeywordID") %>'>
                        <%# GetKeywordName(int.Parse(Eval("KeywordID").ToString())) %>
                        <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>
                    </div>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <script>

        $(".TelegramSelectAllItem .CheckBox").click(function () {
            $(".telegramCheckbox input").prop("checked", $(this).prop("checked"));
        });


        $("#ShowTelegramFilterButton").click(function () {
            $(".SocialKeyBox").fadeToggle(1000);
        });

        $("#ShowTelegramBooltanButton").click(function () {
            $(".newsBultan").fadeToggle(1000);
        });

        $("article input:checkbox").click(function () {
            $(this).parents("article").toggleClass("SetCeckedbackgroundColor");
        });

        $("#ShowAllKeywords").click(function () {
            $('.newsTags').fadeToggle(500);
        });


        $("#HTMLTelegramButton").click(function () {

            var SelectedMessageIds = "";
            $("#check_SelectNews:checked").each(function () {
                SelectedMessageIds += "," + $(this).closest("article").attr("data-Id");
            });

            var fromDate = $('#txt_fromDate').val();
            var toDate = $('#txt_toDate').val();
            var bultanTitle = $("#txt_bultanTitle").val();
            var parmin = $("#NewsIdParminId").val();
            var linkUrl = window.location.protocol + "//" + window.location.hostname;
            if (window.location.port != null && window.location.port != '') {
                linkUrl += ":" + window.location.port;
            }
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/TelegramNew.aspx/CreateTelegramBultan",
                data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','SelectedMessageIds':'" + SelectedMessageIds + "','bultanTitle':'" + bultanTitle + "','linkUrl': '" + linkUrl + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    window.location.replace(data.d);
                },
                error: function (msg) {

                    alert("خطا");
                }

            }
            );
            e.preventDefault();
        });


    </script>

    <script>

        function addToInbox(element) {
            var newsID = $(element).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/NewMediaNewsList.aspx/AddToInbox",
                data: "{'MediaId':'" + newsID + "' , 'MediaType': 3}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d !== 0) {
                        OpenAlert('افزودن به اینباکس', 'پست تلگرام انتخابی با موفقیت به اینباکس اضافه شد');
                    }
                },
                error: function (msg) {
                    OpenAlert('افزودن به اینباکس', 'خطای ناشناخته در افزودن به اینباکس');
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

        $(".telegramNewsrate a").click(function (e) {

            var item = $(this);
            var boxDiv = $(this).parent();

            var id = $(item).attr("class");
            var newsId = $(item).attr("itemid");
            var newsValue = -1;
            switch (id) {

                case "btn_news_ok":
                    $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_ok").animate({ opacity: '1' }, 500);
                    $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                    newsValue = 1;
                    break;
                case "btn_news_empty":
                    $(boxDiv).find(".btn_news_empty").animate({ opacity: '1' }, 500);
                    $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                    newsValue = 0;
                    break;
                case "btn_news_notok":
                    $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_notok").animate({ opacity: '1' }, 500);
                    $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                    newsValue = 2;
                    break;
                case "btn_news_lowـcommunication":
                    $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '1' }, 500);
                    $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                    newsValue = 3;
                    break;
                case "btn_news_irrelevant":
                    $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                    $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '1' }, 500);
                    newsValue = 4;
                    break;
                default:
                    newsValue = -1;
                    break;
            }
            try {
                $(boxDiv).find("#hdfNewsOrientation").val(newsValue);
            }
            catch (ex) {

            }
            if (newsValue != -1)
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/TelegramNew.aspx/SetNewsValue",
                    data: "{'idString':'" + newsId + "','valueString':'" + newsValue + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {


                    },
                    error: function (msg) {

                    }

                });
            e.preventDefault();
        });
    </script>
</asp:Content>
