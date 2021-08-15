<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="True" CodeBehind="SocialKeywords.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SocialKeywords" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <div class="PageSubLink">
        <ul>
           <li><a href="/Twitter/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/TwitterAnalyze/" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای توییتر</a></li>
            <li><a style="color: #fec006" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a href="/TwitterBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
        </ul>
    </div>
    <div class="command PageSubLink" id="divCommand" runat="server">
        <span class="AspButtonIcon"><i class="far fa-calendar-plus"></i></span>
        <asp:Button ID="btn_new_group" OnClick="btn_new_group_Click" runat="server" CssClass="ButtonToSubLink" Text="افزودن گروه کلیدواژه" />
        <span class="AspButtonIcon"><i class="fas fa-plus-circle"></i></span>
        <asp:Button ID="btn_new_keyword" OnClick="btn_new_keyword_Click" runat="server" CssClass="ButtonToSubLink" Text="افزودن کلید واژه" />
<%--        <span class="AspButtonIcon"><i class="fas fa-reply" data-fa-transform="flip-h"></i></span>
        <a href="/Pages/P-Art/Pages/Social.aspx" class="ButtonToSubLink" title="بازگشت به صفحه توئیتر">بازگشت به صفحه توییتر</a>--%>
    </div>
    <div class="clearfix"></div>
    <div id="divKeywordList" runat="server" class="keywordlist persian">
        <asp:Repeater ID="rptKeyword" runat="server" OnItemCommand="rptKeyword_ItemCommand" OnItemDataBound="rptKeyword_ItemDataBound">
            <HeaderTemplate>
                <div class="Group_list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="keybox">
                    <div class="GroupItem">
                        <asp:LinkButton CssClass="GroupOrderLabel" CommandArgument='<%# Eval("GroupId") %>' CommandName="EditGroup" ID="lblGroupOrder"
                            Text='<%# Eval("GroupOrder") %>' runat="server"></asp:LinkButton>
                        <asp:LinkButton CommandArgument='<%# Eval("GroupId") %>' CommandName="EditGroup" ID="lblKeyGroup"
                            Text='<%# Eval("GroupName") %>' runat="server"></asp:LinkButton>
                    </div>
                    <%--<div class="clearfix"></div>--%>
                    <div class="KeywordList">

                        <asp:Repeater ID="rptKeywordItem" OnItemCommand="rptKeywordItem_ItemCommand" runat="server">
                            <ItemTemplate>
                                <div class="KeyItem">
                                    <asp:LinkButton CssClass="KeyOrderLabel" CommandArgument='<%# Eval("SocialMediaKeyID") %>' CommandName="EditKey" ID="lblOrderNumber"
                                        Text='<%# Eval("OrderNumber") %>' runat="server"></asp:LinkButton>
                                    <asp:LinkButton CommandArgument='<%# Eval("SocialMediaKeyID") %>' CommandName="EditKey"
                                        ID="lblKeyword" Text='<%# Eval("Title") %>' runat="server"></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="clearfix"></div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <div class="clearfix"></div>
    </div>

    <div id="divAddKeyword" runat="server">
        <div class="BoxPanelHeader">
            <span><i class="fas fa-plus-circle fa-lg"></i></span>
            افزودن کلید واژه
        </div>
        <div class="BoxPanelContent">
            <div class="ItemForm">
                <span class="Label">گروه:</span>
                <asp:DropDownList ID="lstGroup" runat="server" CssClass="btn btn-info dropdown-toggle dropdown" DataTextField="GroupName" DataValueField="GroupId" ></asp:DropDownList>
            </div>
            <div class="ItemForm">
                <span class="Label">کلمه کلیدی:</span>
                <asp:TextBox ID="txtKeywordTitle" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
            </div>
            <div class="ItemForm">
                <span class="Label">نباید ها:</span>
                <asp:TextBox ID="txtNotLike" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
                <span style="float: left; margin-left: 45px;">مانند: داعش-اروپا</span>
            </div>
            <div class="ItemForm">
                <span class="Label">اولویت:</span>
                <asp:TextBox ID="txtKeyOrder" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
                <asp:RangeValidator ValidationGroup="vkey" ID="RangeValidator1" runat="server" ControlToValidate="txtGroupOrder" Display="Dynamic"
                    ErrorMessage="فقط اعداد" ForeColor="Red" MinimumValue="0" MaximumValue="9999999" Type="Integer" CssClass="alert alert-danger"></asp:RangeValidator>
            </div>
            <div class="SocialKeywordAddGroupButton">
                <asp:Button runat="server" ValidationGroup="vkey" ID="btnSaveKey" CssClass="btn btn-success cur-p" OnClick="btnSaveKey_Click" Text="ذخیره" />
                <asp:Button runat="server" CausesValidation="false" ID="btnBackKey" CssClass="btn btn-danger cur-p" OnClick="btnBackKey_Click" Text="بازگشت" />
            </div>
        </div>
    </div>

    <div id="divAddGroup" runat="server">
        <div class="BoxPanelHeader">
            <span><i class="far fa-calendar-plus fa-lg"></i></span>
            افزودن گروه کلید واژه
        </div>
        <div class="BoxPanelContent">
            <div class="ItemForm">
                <div class="Label">نام گروه</div>
                <asp:TextBox ID="txtGroupName" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
            </div>
            <div class="ItemForm">
                <div class="Label">اولویت</div>
                <asp:TextBox ID="txtGroupOrder" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
                <asp:RangeValidator ValidationGroup="vgroup" ID="rvalidator" runat="server" ControlToValidate="txtGroupOrder" Display="Dynamic"
                    ErrorMessage="فقط اعداد" ForeColor="Red" MinimumValue="0" MaximumValue="9999999" Type="Integer" CssClass="alert alert-danger"></asp:RangeValidator>
            </div>
            <div class="SocialKeywordAddGroupButton">
                <asp:Button runat="server" ValidationGroup="vgroup" ID="btnSaveGroup" CssClass="btn btn-success cur-p" OnClick="btnSaveGroup_Click" Text="ذخیره" />
                <asp:Button runat="server" CausesValidation="false" ID="btnBackGroup" CssClass="btn btn-danger cur-p" OnClick="btnBackGroup_Click" Text="بازگشت" />
            </div>

        </div>
    </div>

</asp:Content>

