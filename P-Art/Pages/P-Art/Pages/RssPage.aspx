<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="RssPage.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.RssPage" %>

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
    <div class="PageSubLink">
        <ul>
            <li><a href="#" id="lnk_filter" class="flat-gray-button"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
        </ul>
    </div>
    <div class="newsFilter persian">
        <div>
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
                <label for="ddlSiteType">رسانه:</label>
                <asp:DropDownList runat="server" ID="ddlSiteType" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                    <asp:ListItem Text="تمام رسانه ها" Value="0" Selected="True" />
                    <asp:ListItem Text="خبرگزاری ها" Value="1" />
                    <asp:ListItem Text="روزنامه ها" Value="2" />
                </asp:DropDownList>
            </span>
            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
        </div>
    </div>

    <div class="PagingContainer persian">
        <div id="topPagination" runat="server" class="PagingPagination persian"></div>

        <div id="pagingGrid" runat="server" class="pagingGrid rss-news">


            <asp:Repeater ID="pagingGridRepeater" runat="server">
                <HeaderTemplate>
                    <div class="pagingGridContainer">
                        <div class="pagingGridHeader">
                            <span class="HeaderSelection">انتخاب</span>
                            <span class="HeaderTitle">عنوان خبر</span>
                            <span class="HeaderSite">رسانه</span>
                            <span class="HeaderDateTime">زمان</span>
                            <span class="HeaderCommand">آرشیو</span>
                        </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="GridContainer">
                        <div class="GridItem">
                            <span class="ItemSelection">
                                <input id="NewsSelectCheckbox" type="checkbox" class="CheckBox" data-id="<%#Eval("id") %>" />
                            </span>
                            <span class="ItemTitle" title='<%# Eval("Title") %>' data-id='<%# Eval("id") %>'>
                                <%# Eval("Title") %>
                            </span>
                            <span class="ItemSite" title='<%# Eval("SiteName") %>'>
                                <%# Eval("SiteName").ToString().Trim() %>
                            </span>
                            <span class="ItemDateTime" title='<%# Eval("Date") %> -  <%# Eval("Time") %>'><i class="fas fa-calendar-alt"></i><%#  PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToDateString(Eval("DateTimeIndex")) %>   <i class="fas fa-clock"></i><%#  PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToTimeString(Eval("DateTimeIndex")) %></span>
                            <a class="ItemSite" style="display: inline-block; text-align: center;" href='/RssShowNews?url=<%# Eval("SourceLink") %>' target="_blank"><i class="fa fa-eye"></i>شاهد خبر </a>
                        </div>
                        <div id="GridItemDetail_<%# Eval("id") %>" class="Detail">
                            <div class="DetailHeader">
                                <p>
                                    <span class="MatnKhabar">متن خبر:</span>
                                    <span class="ShowNewsLink">
                                        <a href='/RssShowNews?url=<%# Eval("SourceLink") %>' target="_blank">نمایش</a>
                                    </span>
                                    <span class="NewsUrl">
                                        <a href='/RssShowNews?url=<%# Eval("SourceLink") %>' target="_blank">شاهد خبر</a>
                                    </span>
                                </p>
                            </div>
                            <div class="DetailContent"></div>
                        </div>
                    </div>
                </ItemTemplate>

                <FooterTemplate>
                    <div class="GridFooter">
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div id="buttomPagination" runat="server" class="PagingPagination persian">
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
    </script>

    <script>
        $("#lnk_filter").click(function (e) {

            $(".newsFilter").fadeToggle("slow", "linear");
            e.preventDefault();
        });
    </script>
    <script>

        $('.ItemTitle').live('click', function (e) {

            var $this = $(this);


            var newsID = $this.attr('data-id');
            var detailBoxId = "#GridItemDetail_" + newsID;
            $thisDiv = $(detailBoxId);
            $thisDivContent = $(detailBoxId + " .DetailContent");

            $thisDivContent.empty();
            $thisDivContent.append("<img id=\"imgLoadPage1\" style=\"text-align: center; margin: auto;  display:flex; max-width: 100px\" src=\"/Pages/P-Art/Images/loadingPaging.gif\">");

            $thisDiv.fadeToggle("slow", "linear");

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/RssPage.aspx/DetailShowNews",
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
    </script>
</asp:Content>
