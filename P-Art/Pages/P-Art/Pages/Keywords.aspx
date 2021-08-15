<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="Keywords.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Keywords" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <div class="PageSubLink">
        <ul>
            <li><a href="/News/Latest/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/Analysis" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوا</a></li>
            <li style="color: #fec006"><a style="color: #fec006"  runat="server"><span><i class="fas fa-key"></i></span>کلید واژه</a></li>
            <li><a href="/KeywordAnalyse" runat="server"><span><i class="fab fa-keycdn"></i></span>آنالیز کلید واژه ها</a></li>
            <li><a href="/News/BultanArchive" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="/addnews" runat="server"><span><i class="fas fa-pen-square"></i></span>ثبت خبر</a></li>
            <li><a href="/Pages/P-Art/Pages/SavedNews.aspx" runat="server"><span><i class="fas fa-hdd"></i></span>اخبار ذخیره شده</a></li>
        </ul>
    </div>
    <asp:ScriptManager ID="SManager" runat="server" />
    <div class="bg-modal">
        <div class="window">
            <div class="title">
                <span>مدیریت کلید واژه
                </span>

                <asp:UpdatePanel ID="panel_close" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <asp:LinkButton ID="lnk_close" runat="server" OnClick="lnk_close_Click">
                            <img src="/Pages/P-Art/Images/dialog_cancel.png" />
                        </asp:LinkButton>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnk_close" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>


            </div>
            <asp:UpdatePanel ID="panel_keywords" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>


                    <table>
                        <tr>
                            <td>گروه کلید واژه :
                            </td>
                            <td>
                                <%--   <asp:DropDownList runat="server" Width="300px"
                                    CssClass="chzn-select textbox rtl" ID="ddlKeyGroups">
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtGroupName" runat="server" CssClass="textbox" />
                            </td>
                        </tr>
                        <tr>
                            <td>اولویت گروه کلید واژه :
                            </td>
                            <td>
                                <%--   <asp:DropDownList runat="server" Width="300px"
                                    CssClass="chzn-select textbox rtl" ID="ddlKeyGroups">
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtGroupOrder" runat="server" CssClass="textbox" />
                            </td>
                        </tr>
                        <tr>
                            <td>عنوان کلید واژه :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_keywordTitle" runat="server" CssClass="textbox" />
                                <em>بطور مثال : پایش   و بصورت ترکیبی : پایش+اخبار
                                </em>
                            </td>
                        </tr>
                        <tr>
                            <td>نبایدها :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_notLike" runat="server" CssClass="textbox" />
                                <em>بطور مثال : داعش-اروپا
                                </em>
                            </td>
                        </tr>
                            <tr>
                            <td>نوع کلیدواژه :
                            </td>
                            <td>
                                <asp:DropDownList runat="server"  ID="ddlType">
                                    <asp:ListItem Text="اصلی" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="رقبا"  Value="3"></asp:ListItem>
                                    <asp:ListItem Text="فرعی"  Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>شماره دریافت پیامک :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_mobiles" runat="server" CssClass="textbox" />
                                <em>بطور مثال : 0912000000,09123000000
                                </em>
                            </td>
                        </tr>
                        <tr>
                            <td>اولویت :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_key_periority" TextMode="Number" runat="server" Text="0" CssClass="textbox" />
                            </td>
                        </tr>
                        <tr>
                            <td>دریافت پیامک :
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ID="rbtnSmsActive">
                                    <asp:ListItem Text="فعال" Value="true"></asp:ListItem>
                                    <asp:ListItem Text="غیرفعال" Selected="True" Value="false"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>دریافت پیام اپلیکیشن پایش :
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ID="rbtnNotificationActive">
                                    <asp:ListItem Text="فعال" Value="true"></asp:ListItem>
                                    <asp:ListItem Text="غیرفعال" Selected="True" Value="false"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>ارسال به تلگرام :
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ID="rbtnSendTelegram">
                                    <asp:ListItem Text="فعال" Value="true"></asp:ListItem>
                                    <asp:ListItem Text="غیرفعال" Selected="True" Value="false"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>رنگ پیش فرض :
                            </td>
                            <td>
                                <asp:TextBox ID="txt_color" Text="#ffffff" TextMode="Color" runat="server" style="width:25px" />
                            </td>
                        </tr>
                        <tr>
                            <td>تصویر :
                            </td>
                            <td>
                                <asp:FileUpload runat="server" ID="fupLogo"/>
                                <asp:Image runat="server" ID="imgLogo" Width="100px" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:UpdatePanel ID="panel_remove" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btn_remove" runat="server" Text="حذف" CssClass="btn btn-danger cur-p" OnClientClick="return confirm('آیا مطمئن به حذف کلیدواژه انتخابی هستید ؟');" Width="86" OnClick="btn_remove_Click" Style="float: right" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Button ID="btn_Save_keyword" runat="server" Text="ذخیره" CssClass=" btn btn-info cur-p " style="float:left;"  OnClick="btn_Save_keyword_Click" />
                            </td>
                        </tr>
                    </table>

                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_Save_keyword" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="lst_keywords persian">

        <div class="PageSubLink">
            <asp:Button ID="btn_save" runat="server" CssClass="btn btn-success cur-p" Text="ذخیره اطلاعات" OnClick="btn_save_Click" />
            <asp:UpdatePanel ID="panel_new" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btn_new_keyword" runat="server" CssClass="btn btn-info cur-p" Text="جدید" OnClick="btn_new_keyword_Click"  />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="panel_key" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Literal runat="server" ID="ltKeyGroups"></asp:Literal>
                <%--  <asp:Repeater ID="rpt_Groups" runat="server" OnItemDataBound="rpt_Groups_ItemDataBound">
                    <ItemTemplate>


                        <div id="group_item" class="group_item clearfix" runat="server">
                            <div class="groupNameDetails clearfix">
                                <label><%#Eval("GroupOrder") %></label>
                                <label><%#Eval("GroupName") %></label>

                            </div>
                            <div class="clearfix" style="padding: 3px;">


                                <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                <asp:HiddenField ID="fld_keyId" runat="server" Value='<%# Eval("KeyId") %>' />

                                <asp:TextBox TextMode="Color" ID="color_box" Text='<%# Eval("Color") %>' runat="server" />


                                <asp:TextBox ID="color_span" runat="server" Text='<%# Eval("OrderItem") %>' />

                                <asp:LinkButton ID="lnk_edit_key" runat="server" CommandArgument='<%# Eval("KeyId") %>' OnClick="lnk_edit_key_Click">
                                 <label><%#Eval("KeywordName") %></label>
                                </asp:LinkButton>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
                --%>
            </ContentTemplate>
            <Triggers>
                <%--   <asp:AsyncPostBackTrigger ControlID="lnk_edit_key" EventName="Click" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <script src="/Scripts/chosen.jquery.js" type="text/javascript"></script>

    <link href="/Styles/chosen.css" rel="stylesheet" />
    <script type="text/javascript">
        function ShowEditTagPopup(id) {
            __doPostBack('edit_key', '' + id + '');
            e.preventDefault();
        }
        $(function () { DoDropDownAutoComplete(); });
        function DoDropDownAutoComplete() {
            $(".chzn-select").chosen();
            $(".chzn-select-deselect").chosen(
                {
                    allow_single_deselect: true,

                    //   no_results_clear: 'موردی یافت شد',
                    //   no_results: 'موردی یافت شد',
                    //   default_single_text: 'لطفا یک گزینه انتخاب نمایید',
                    //   default_multiple_text: 'لطفا چند گزینه انتخاب نمایید',
                    //  default_no_result_text: 'موردی یافت شد',
                });
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (sender, e) {
            $(".chzn-select").each(function () {
                $(this).chosen();


            });
        });
        if (typeof (Sys) != "undefined") {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler(sender, args) {

        }
    </script>
</asp:Content>
