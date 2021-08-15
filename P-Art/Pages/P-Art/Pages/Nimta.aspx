<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Nimta.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Nimta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            Page_Init();
        });

        function Page_Init() {
            $('#<%= txtDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
        }

        function SelectAllById(state, controlId) {
            $(':checkbox[id*=' + controlId + ']').each(function () { this.checked = state; });
        }

        function SetSelectAllControl(state, controlId) {
            if (state == false)
                $(':checkbox[id*=' + controlId + ']')[0].checked = false;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section class="posts">
        <div class="nimta-head">
            <div class="divTitle">
                <asp:CheckBox ID="cbSelectAll" runat="server" onclick="SelectAllById(this.checked, 'cbSelect')" />
                <span>عناوین روزنامه ها</span>
            </div>
            <div class="divDate">
                <span>تاریخ:</span>
                <asp:TextBox CssClass="textbox" ID="txtDate" runat="server"></asp:TextBox>
            </div>
            <div class="divBooltan">
                <asp:Button OnClick="btnNimtaBooltan_Click" runat="server" ID="btnNimtaBooltan" Text="دریافت بولتن" CssClass="flat-gray-button btnNimtaBooltan" />
            </div>

        </div>
        <%--'<%# String.Concat("title nimtaCheck-", Eval("SiteID_FK"))%>'--%>
        <%-- <a  onclick="$('*[data-group=<%# Eval("SiteID_FK") %>]').prop('checked', this.checked);">--%>
        <asp:Repeater runat="server" OnItemDataBound="rptNimta_ItemDataBound" ID="rptNimta">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="divNimta">

                    <img onclick=" $('input[data-group=<%# Eval("SiteID_FK") %>]').attr('checked', !$('input[data-group=<%# Eval("SiteID_FK") %>]').attr('checked'));" src='<%# Eval("Logo") %>' title='<%# Eval("Title") %>' alt='<%# Eval("Title") %>' />
                    <asp:CheckBox CssClass="title" ID="cbSelect" ClientIDMode="AutoID" runat="server"
                        Text='<%# Eval("Title") %>' />

                    <asp:Label CssClass="title" Visible="false" ID="lblSiteId" runat="server"
                        Text='<%# Eval("SiteID_FK") %>'></asp:Label>

                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clearfix"></div>

    </section>
</asp:Content>
