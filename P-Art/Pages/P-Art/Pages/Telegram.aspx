<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="Telegram.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Telegram" %>
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
            <li><a href="/TelegramKeywords/" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a href="/TelegramBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a id="ShowTelegramFilterButton"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
            <li><a id="ShowTelegramBooltanButton"><span><i class="fas fa-file-alt"></i></span>بولتن موضوعی</a></li>
            <li><a href="#" id="ShowAllKeywords"><span><i class="fas fa-ellipsis-h"></i></span>نمایش کلید واژه ها</a></li>
        </ul>
    </div>

    
    <div id="SocialKeyBox" class="SocialKeyBox">
        <asp:Repeater ID="SocialKeyCheckBox" runat="server" OnItemDataBound="SocialKey_ItemDataBound">
            <ItemTemplate>
                <div id="group_item" class="group_item" runat="server">
                    <span id="color_span" runat="server" class="ch">
                        <asp:CheckBox ID="check_selected_group" runat="server" />
                    </span>
                    <asp:HiddenField ID="hddsocialkeyid" Value='<%# Eval("Id") %>' runat="server" />
                    <a href="#" data-id='<%# Eval("Id") %>' class="switchkeyword1">
                        <label id="lable1" style="color: gray;" data-keyword='<%# Eval("SearchKeyWord") %>' runat="server"><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("SearchKeyWord")) %></label>
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
                    <article data-id="<%# Eval("Id") %>">
                        <asp:HiddenField ID="MassageIdHiddenField" runat="server" Value='<%# Eval("Id") %>' />
                        <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>
                        <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="CheckBox telegramCheckbox" />
                        <a class="title" href='/TelegramMessageShow/<%# Eval("Id") %>'><span><%# Eval("Message_Text") %></span></a>
                        <span class="telegramChannelName"><%# Eval("ChannelName") %></span>
                        <span class="rowDateTime ">
                            <label id="date"><%# Eval("DateTimeInsert") %></label>
                        </span>
                       
                    </article>
                    <div class="newsTags" style="display: none;" id='keyId<%# Eval("FK_Id_Tbl_SearchKeyWord") %>'>
                        <%# GetKeywordName(int.Parse(Eval("FK_Id_Tbl_SearchKeyWord").ToString())) %>
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
                url: "/Pages/P-Art/Pages/Telegram.aspx/CreateTelegramBultan",
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
</asp:Content>

