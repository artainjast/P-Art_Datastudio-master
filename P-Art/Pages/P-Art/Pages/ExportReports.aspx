<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="ExportReports.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.ExportReports" %>

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
    <%--    <div class="PageSubLink">
        <ul>
            <li><a href="/Telegram/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/TelegramAnalyze/" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای تلگرام</a></li>
            <li><a style="color: #fec006" href="" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a href="/TelegramBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
        </ul>
    </div>--%>
    <div class="command PageSubLink" id="divCommand" runat="server">
        <span class="AspButtonIcon"><i class="fas fa-plus-circle"></i></span>
        <a id="AddKeyword" class="ButtonToSubLink">افزودن کلید واژه</a>
    </div>


    <%-- باکس افزودن کلید واژه --%>
    <div id="divAddKeyword" runat="server">
        <div class="BoxPanelHeader">
            <span><i class="fas fa-plus-circle fa-lg"></i></span>
            افزودن کلید واژه
        </div>
        <div class="BoxPanelContent">
            <asp:HiddenField ID="SelectedKeywordIdHiddenField" runat="server" Value="" />
            <div class="ItemForm">
                <span class="Label">عبارت جستجو:</span>
                <asp:TextBox ID="txtKeywordTitle" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
            </div>

            <div class="ItemForm">
                <span class="Label">اولویت:</span>
                <asp:TextBox ID="txtKeyOrder" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
            </div>
            <div class="ItemForm">
                <span class="Label">نباید ها:</span>
                <asp:TextBox ID="NoWordOfTextbox" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
            </div>
            <div class="SocialKeywordAddGroupButton">
                <asp:Button runat="server" ValidationGroup="vkey" ID="saveKeyword" CssClass="btn btn-success cur-p" Text="ذخیره" OnClick="saveKeyword_Click" />
                <asp:Button runat="server" CausesValidation="false" ID="deleteKeyword" CssClass="btn btn-danger cur-p" Text="حذف" OnClientClick=" return confirm('آیا از حذف کلید واژه اطمینان دارید؟')" OnClick="deleteKeyword_Click" />
                <a id="closeAddKeywordButton" class="btn btn-warning cur-p">بازگشت</a>
            </div>
        </div>
    </div>


    <div class="clearfix"></div>

    <div id="divKeywordList" runat="server" class="keywordlist persian">
        <div class="keybox">
            <div class="GroupItem">
                <span class="keyGroupButton">لیست کلید واژه های جستجو</span>
            </div>
            <%--<div class="clearfix"></div>--%>
            <div class="KeywordList">
                <%-- ریپیتر مخصوص کلید واژه ها --%>
                <asp:Repeater ID="rptKeywordItem" runat="server">
                    <ItemTemplate>
                        <div class="KeyItem">
                            <a class="KeyOrderLabel"><%# Eval("KeyPriority") %></a>
                            <a class="keywordButton" data-keyid="<%# Eval("Id") %>"><%# Eval("Title") %></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="clearfix"></div>
        </div>
    </div>

    <div class="clearfix"></div>

    <div id="CommandButtonList" runat="server" class="keywordlist persian">
        <div class="keybox">
            <div class="GroupItem">
                <span class="keyGroupButton">ایجاد انواع گزارش</span>
            </div>
            <div class="KeywordList">
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
                <asp:Button ID="GenerateExcelReport" Text="ساخت گزارش اکسل" runat="server" CssClass="btn btn-success cur-p" OnClick="generateExcelReport_Click" />
                <asp:Button ID="GenerateExcelReportWithoutSearchKey" Text="ساخت گزارش اکسل بدون در نظر گرفتن عبارت جستجو" runat="server" CssClass="btn btn-success cur-p" OnClick="generateExcelReportWithoutKeySearch_Click" />
            </div>
            <div class="clearfix"></div>
        </div>
    </div>


    <script>
        // با لود صفحه باکس های افزودن گروه و کلیدواژه بسته می شوند
        $(document).ready(function () {
            $("#divAddGroup").fadeOut();
            $("#divAddKeyword").fadeOut();
        });
        // افزودن گروه
        $("#AddKeyGroup").click(function () {
            $("#divAddGroup").fadeIn(200);
            $("#txtGroupName").val("");
            $("#txtGroupOrder").val("");
            $("#SelectedGroupIdHiddenField").val("");
        });
        // بستن باکس افزودن گروه
        $("#closeAddGroupButton").click(function () {
            $("#divAddGroup").fadeOut(200);
            $("#txtGroupName").val("");
            $("#txtGroupOrder").val("");
            $("#SelectedGroupIdHiddenField").val("");
        });
        // افزودن کلید واژه
        $("#AddKeyword").click(function () {
            $("#divAddKeyword").fadeIn(200);
            $("#txtKeywordTitle").val("");
            $("#txtKeyOrder").val("");
        });
        // بستن باکس افزودن کلید واژه
        $("#closeAddKeywordButton").click(function () {
            $("#divAddKeyword").fadeOut(200);
            $("#txtKeywordTitle").val("");
            $("#txtKeyOrder").val("");
        });


        // درج اطلاعات  کلید واژه در باکس افزودن  کلید واژه
        $(".keywordButton").click(function (e) {
            $("#divAddKeyword").fadeIn(200);
            $("#txtKeywordTitle").val("");
            $("#txtKeyOrder").val("");
            $("#NoWordOfTextbox").val("");
            var keyId = $(this).attr("data-keyid");
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/ExportReports.aspx/GetExportSerachKeywordWithId",
                data: "{'KeyID':'" + keyId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#txtKeywordTitle").val(data.d.Title);
                    $("#NoWordOfTextbox").val(data.d.NoWordOf);
                    $("#txtKeyOrder").val(data.d.KeyPriority);
                    $("#SelectedKeywordIdHiddenField").val(data.d.Id);
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
