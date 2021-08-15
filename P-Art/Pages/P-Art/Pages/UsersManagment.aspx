<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UsersManagment.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.UsersManagment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btn {
            width: 70px;
            height: 30px;
            line-height: 30px;
            display: inline-block;
            color: #fff;
            border-radius: 4px;
            text-align: center;
        }

        .btnBlue {
            border: 1px solid #0c81ba;
            background: #149adb;
        }

        .btnRed {
            background: #bb192d;
            border: 1px solid #8f0b1b;
        }

        .formTable {
            font-size: 13px;
            margin: 10px auto;
            width: 100%;
        }


            .formTable input, .formTable select, .gridSetting input, .gridSetting textarea {
                font-family: Tahoma;
            }

            .formTable th {
                font-weight: bold;
                background: #8fccb0;
                color: #fff;
                padding: 4px 6px;
            }

            .formTable tr {
            }

                .formTable tr td.text {
                    overflow: hidden;
                    text-overflow: ellipsis;
                    -ms-text-overflow: ellipsis;
                    -o-text-overflow: ellipsis;
                    direction: rtl;
                    white-space: nowrap;
                }

                .formTable tr td {
                    max-width: 220px;
                    padding: 4px 6px;
                    /*white-space:nowrap;*/
                }

                    .formTable tr td a {
                        color: #037fb6;
                    }

                    .formTable tr td span {
                    }

            .formTable .gridPager {
            }

                .formTable .gridPager td {
                }

                    .formTable .gridPager td span {
                    }

                    .formTable .gridPager td a {
                    }





        .gridSetting {
            margin: 12px auto;
            height: 20px;
        }

            .gridSetting input {
                border: 1px solid #ccc;
                border-radius: 4px;
                padding: 4px;
            }

            .gridSetting fieldset {
                border: 1px solid #999;
                border-radius: 4px;
                padding: 5px;
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
                box-sizing: border-box;
                margin-bottom: 20px;
            }

                .gridSetting fieldset span {
                    vertical-align: top;
                }

                .gridSetting fieldset legend {
                    padding: 2px 5px;
                    margin: 2px 5px;
                }


        .shadow {
            width: 100%;
            height: 100%;
            position: fixed;
            left: 0;
            top: 0;
            background: rgba(16, 15, 15, 0.70);
            z-index: 9998;
        }

        .loading {
            height: 60px;
            line-height: 100%;
            position: fixed;
            top: 50%;
            left: 50%;
            margin-left: -100px;
            margin-top: -30px;
            border: 1px solid #999;
            background: #fff;
            border-radius: 4px;
            padding: 10px;
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
            text-align: center;
            width: 200px;
            z-index: 9999;
        }

            .loading span {
                margin-top: 10px;
                display: block;
            }

        .tableList {
            font-size: 13px;
        }

            .tableList .label {
                background: #097285;
                color: #fff;
                padding: 4px;
            }

            .tableList .input {
                margin-left: 20px;
            }

                .tableList .input input {
                    border: 1px solid #ccc;
                    border-radius: 4px;
                    line-height: 24px;
                }

                    .tableList .input input[type=text] {
                        padding: 4px;
                    }

                    .tableList .input input[type=checkbox] {
                    }

        .ltr {
            direction: ltr;
            text-align: left;
        }

        .rtl {
            direction: rtl;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server" ID="scriptmanager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" ID="updMain" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="updProgress" AssociatedUpdatePanelID="updMain">
                <ProgressTemplate>
                    <div class="shadow"></div>
                    <div class="loading">
                        <span>در حال دریافت اطلاعات...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:HiddenField runat="server" ID="hdfUserID" />
            <asp:MultiView runat="server" ID="mutiview1" ActiveViewIndex="0">
                <asp:View runat="server" ID="view1">
                    <div class="clearfix" style="margin: 10px auto; text-align: center;">
                        <asp:LinkButton CssClass="btn btnBlue" Width="100px" runat="server" OnClick="btnAddUser_Click" ID="btnAddUser">
                        ثبت کاربر جدید
                        </asp:LinkButton>
                    </div>
                    <div class="clearfix">
                        <asp:GridView runat="server" ID="grvData" CssClass="formTable" AutoGenerateColumns="false" OnPageIndexChanging="grvData_PageIndexChanging" AllowPaging="true" OnRowDataBound="grvData_RowDataBound" PageIndex="0" PageSize="20">
                            <Columns>


                                <asp:TemplateField ItemStyle-CssClass="text" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="ردیف">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:HiddenField runat="server" ID="hdfMemberActive" Value='<%# Eval("Active") %>' />
                                        <asp:HiddenField runat="server" ID="hdfMemberID" Value='<%# Eval("MemberID") %>' />
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="text" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="نام کاربری">
                                    <ItemTemplate>
                                        <%# Eval("UserName") %>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="وضعیت">
                                    <ItemTemplate>
                                        <asp:DropDownList runat="server" Enabled="false" ID="ddlActive">
                                            <asp:ListItem Selected="True" Text="فعال" Value="true"></asp:ListItem>
                                            <asp:ListItem Text="غیر فعال" Value="false"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="text" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEditUser" CommandArgument='<%# Eval("MemberID") %>' OnClick="btnEditUser_Click">
                                            ویرایش کاربر

                                        </asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:View>
                <asp:View runat="server" ID="view2">
                    <h3>
                        <asp:Literal runat="server" ID="ltUserAddEdit"></asp:Literal></h3>
                    <div class="clearfix">
                        <table class="tableList">
                            <tr>
                                <td class="label">نام کاربری :</td>
                                <td class="input">
                                    <asp:TextBox runat="server" CssClass="ltr" ID="txtUserName"></asp:TextBox></td>
                                <td class="label">کلمه عبور :</td>
                                <td class="input">
                                    <asp:TextBox runat="server" CssClass="ltr" ID="txtPassword"></asp:TextBox></td>
                            </tr>

                            <tr>

                                <td class="label">شماره همراه :</td>
                                <td class="input">
                                    <asp:TextBox runat="server" CssClass="ltr" ID="txtUserMobile"></asp:TextBox></td>
                                <td class="label">وضعیت کاربر :</td>
                                <td class="input">
                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ID="rbtnUserActive">
                                        <asp:ListItem Text="فعال" Value="true"></asp:ListItem>
                                        <asp:ListItem Text="غیرفعال" Selected="True" Value="false"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </td>
                            </tr>
                            <tr>
                                <td class="label">کلیدواژه های دریافت پیامک :
                                </td>
                                <td class="input">
                                    <asp:CheckBoxList Height="300px" Width="300px" CssClass="chbParmins" Style='height: 300px; overflow: scroll;'
                                        RepeatDirection="Vertical" RepeatLayout="Flow" runat="server" ID="ddlUserSmsKeywords">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                        </table>
                        <div class="clearfix" style="margin: 10px auto; text-align: center;">
                            <asp:LinkButton CssClass="btn btnBlue" Width="100px" runat="server" OnClick="btnRegUserData_Click" ID="btnRegUserData">
                      ثبت اطلاعات
                            </asp:LinkButton>


                            <asp:LinkButton CssClass="btnRed btn" Width="100px" runat="server" OnClick="btnCancel_Click" ID="btnCancel">
                     برگشت
                            </asp:LinkButton>

                            <asp:Label runat="server" ID="lblRes"></asp:Label>
                        </div>
                    </div>

                </asp:View>
            </asp:MultiView>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
