<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="SearchAllMedia.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SearchAllMedia" %>

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
    <asp:HiddenField ID="ParminId" runat="server" Value='' />
    <div id="SocialKeyBox" class="SocialKeyBox DisplayBlock">
        <div id="MediaTypes" class="whichMediaTypeDoSearch">

            <input type="checkbox" id="NewsCheckBox" runat="server" class="CheckBox" checked="checked" />
            <label for="NewsCheckBox" class="MediaCheckBoxLabel">اخبار</label>
            <input type="checkbox" id="MovieCheckBox" runat="server" class="CheckBox" checked="checked" />
            <label for="MovieCheckBox" class="MediaCheckBoxLabel">ویدیو</label>
            <input type="checkbox" id="TelegramCheckBox" runat="server" class="CheckBox" checked="checked" />
            <label for="TelegramCheckBox" class="MediaCheckBoxLabel">تلگرام</label>
            <input type="checkbox" id="TwitterCheckBox" runat="server" class="CheckBox" checked="checked" />
            <label for="TwitterCheckBox" class="MediaCheckBoxLabel">توییتر</label>
            <input type="checkbox" id="InstagramCheckBox" runat="server" class="CheckBox" checked="checked" />
            <label for="InstagramCheckBox" class="MediaCheckBoxLabel">اینستاگرام</label>

        </div>
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



        <div class="SearchAllMedia persian">
            <asp:Repeater ID="SearchAllMediaRepeater" runat="server">
                <HeaderTemplate>
                    <div class="newsStream">
                        <div class="newsStreamHeader">
                            <%--                        <span class="TelegramSelectAllItem">
                            <input type="checkbox" name="TelegramSelectAllItem" class="CheckBox" />انتخاب همه
                        </span>--%>

                            <span>نتیجه جستجو</span>
                        </div>
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="showFehrest">
                        <article data-id="<%# Eval("id") %>">
                            <asp:HiddenField ID="ItemIdHiddenField" runat="server" Value='<%# Eval("id") %>' />
                            <asp:HiddenField ID="ItemTypeHiddenField" runat="server" Value='<%# Eval("MediaType") %>' />

                            <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>
                            <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="CheckBox telegramCheckbox" />
                            <a class="title" href='<%# FixItemShowNewsUrl(Eval("id").ToString(),Eval("MediaType").ToString()) %>' target="_blank"><span><%# Eval("Title") %></span></a>
                            <span class="mediaName"><%# GetMediaTypeLogo(Eval("MediaType").ToString()) %></span>
                            <span class="rowDateTime ">
                                <label id="date"><%# FixDateTimeString(Eval("DateTimeIndex").ToString()) %></label>
                            </span>
                        </article>
                        <div class="newsTags" style="display: none;" id='keyId<%# Eval("id") %>'>
                            کلید واژه
                        </div>
                    </div>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
