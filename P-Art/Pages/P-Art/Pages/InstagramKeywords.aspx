<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="InstagramKeywords.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.InstagramKeywords" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <div class="PageSubLink">
        <ul>
            <li><a href="/Instagram/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <%--<li><a href="/InstagramAnalyze/" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای اینستاگرام</a></li>--%>
            <li><a style="color: #fec006" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
<%--            <li><a href="/InstagramBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>--%>
        </ul>
    </div>
    <div class="command PageSubLink" id="divCommand" runat="server">
        <span class="AspButtonIcon"><i class="far fa-calendar-plus"></i></span>
        <a id="AddKeyGroup"  class="ButtonToSubLink">افزودن گروه کلیدواژه</a> 
        <span class="AspButtonIcon"><i class="fas fa-plus-circle"></i></span>
        <a id="AddKeyword"  class="ButtonToSubLink">افزودن کلید واژه</a>
    </div>
    <%-- باکس افزودن گروه کلید واژه --%>
    <div id="divAddGroup" runat="server">
        <div class="BoxPanelHeader">
            <span><i class="far fa-calendar-plus fa-lg"></i></span>
            افزودن گروه کلید واژه
        </div>
        <div class="BoxPanelContent">
            <asp:HiddenField ID="SelectedGroupIdHiddenField" runat="server" Value="" />
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
                <asp:Button runat="server" ValidationGroup="vgroup" ID="saveGroupButton" CssClass="btn btn-success cur-p"  Text="ذخیره" OnClick="saveGroupButton_Click" />
                <asp:Button runat="server" ValidationGroup="vgroup" ID="deleteGroupButton" CssClass="btn btn-danger cur-p"  Text="حذف" onClientClick=" return confirm('ابتدا تمام کلید واژه های گروه را حذف نمایید\n آیا از حذف گروه اطمینان دارید؟')" OnClick="deleteGroupButton_Click" />
                <a id="closeAddGroupButton" class="btn btn-warning cur-p" >بازگشت</a>
            </div>

        </div>
    </div>

    <%-- باکس افزودن کلید واژه --%>
    <div id="divAddKeyword" runat="server"  >
        <div class="BoxPanelHeader">
            <span><i class="fas fa-plus-circle fa-lg"></i></span>
            افزودن کلید واژه
        </div>
        <div class="BoxPanelContent">
            <asp:HiddenField ID="SelectedKeywordIdHiddenField" runat="server" Value="" />
            <div class="ItemForm">
                <span class="Label">گروه:</span>
                <asp:DropDownList ID="lstGroup" runat="server" CssClass="btn btn-info dropdown-toggle dropdown"></asp:DropDownList>
            </div>
            <div class="ItemForm">
                <span class="Label">کلمه کلیدی:</span>
                <asp:TextBox ID="txtKeywordTitle" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
            </div>
            <div class="ItemForm">
                <span class="Label">اولویت:</span>
                <asp:TextBox ID="txtKeyOrder" CssClass="textbox fillWidth" runat="server"></asp:TextBox>
                <asp:RangeValidator ValidationGroup="vkey" ID="RangeValidator1" runat="server" ControlToValidate="txtGroupOrder" Display="Dynamic"
                    ErrorMessage="فقط اعداد" ForeColor="Red" MinimumValue="0" MaximumValue="9999999" Type="Integer" CssClass="alert alert-danger"></asp:RangeValidator>
            </div>
                 <div class="ItemForm">
                <span class="Label">نوع کلیدواژه:</span>
                <asp:DropDownList runat="server" class="btn btn-info dropdown-toggle dropdown" ID="ddlType">
                    <asp:ListItem Text="فرعی" Value="1"></asp:ListItem>
                    <asp:ListItem Text="اصلی" Value="2"></asp:ListItem>
                    <asp:ListItem Text="رقبا" Value="3"></asp:ListItem>

                </asp:DropDownList>
            </div>
            <div class="SocialKeywordAddGroupButton">
                <asp:Button runat="server" ValidationGroup="vkey" ID="saveKeyword" CssClass="btn btn-success cur-p" Text="ذخیره" OnClick="saveKeyword_Click" />
                <asp:Button runat="server" CausesValidation="false" ID="deleteKeyword" CssClass="btn btn-danger cur-p" Text="حذف" onClientClick=" return confirm('آیا از حذف کلید واژه اطمینان دارید؟')" OnClick="deleteKeyword_Click" />
                <a id="closeAddKeywordButton" class="btn btn-warning cur-p" >بازگشت</a>
            </div>
        </div>
    </div>

    
    <div class="clearfix"></div>
    <%-- بخش نمایش گروه کلید واژه و کلید واژه ها --%>
    <div id="divKeywordList" runat="server" class="keywordlist persian">
        <%-- ریپیتر مخصوص گروه کلید واژه ها --%>
        <asp:Repeater ID="rptKeyword" runat="server" OnItemDataBound="OnItemDataBound">
            <HeaderTemplate>
                <div class="Group_list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="keybox">
                    <div class="GroupItem">
                        <a class="GroupOrderLabel" ><%# Eval("GroupOrder") %></a>
                        <a  class="keyGroupButton" data-groupid="<%# Eval("GroupId") %>"><%# Eval("GroupName") %></a>
                    </div>
                    <%--<div class="clearfix"></div>--%>
                    <div class="KeywordList">
                        <%-- نگهداری کلید کد گروه کلید واژه برای یافتن کلیدواژه های گروه --%>
                    <asp:HiddenField ID="GroupIdHiddenField" runat="server" Value='<%# Eval("GroupId") %>' />
                        <%-- ریپیتر مخصوص کلید واژه ها --%>
                        <asp:Repeater ID="rptKeywordItem" runat="server">
                            <ItemTemplate>
                                <div class="KeyItem">
                                    <a class="KeyOrderLabel"><%# Eval("Priority") %></a>
                                    <a class="keywordButton"   data-keyid="<%# Eval("ID") %>" ><%# Eval("Title") %></a>
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
            $("#divAddGroup").fadeOut(1000);
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
        
        // درج اطلاعات گروه کلید واژه در باکس افزودن گروه کلید واژه
        $(".keyGroupButton").click(function (e) {
            $("#divAddGroup").fadeIn(200);
            $("#txtGroupName").val("");
            $("#txtGroupOrder").val("");
            var KeyGroupID = $(this).attr("data-groupid");
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/InstagramKeywords.aspx/GetInstagramKeyGroupWithId",
                data: "{'GroupID':'" + KeyGroupID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   
                    $("#txtGroupName").val(data.d.GroupName);
                    $("#txtGroupOrder").val(data.d.GroupOrder);
                    $("#SelectedGroupIdHiddenField").val(data.d.GroupId);
                },
                error: function (msg) {
                        
                    alert("خطا");
                }

            }
            );
            e.preventDefault();

        });

        // درج اطلاعات  کلید واژه در باکس افزودن  کلید واژه
        $(".keywordButton").click(function (e) {
            $("#divAddKeyword").fadeIn(200);
            $("#txtKeywordTitle").val("");
            $("#txtKeyOrder").val("");
            var keyId = $(this).attr("data-keyid");
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/InstagramKeywords.aspx/GetInstagramKeywordWithId",
                data: "{'KeyID':'" + keyId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#lstGroup").val(data.d.KeysGroupID);
                    $("#ddlType").val(data.d.Type);
                    $("#txtKeywordTitle").val(data.d.Title);
                    $("#txtKeyOrder").val(data.d.Priority);
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