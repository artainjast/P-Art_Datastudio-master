<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSites.aspx.cs" Inherits="P_Art.Pages.P_Art.Admin.AdminSites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <title></title>
    <style type="text/css">
        body {
            background: #efefef;
            font: normal 13px tahoma;
        }

        td {
            padding: 10px 0px;
            text-align: right;
            margin-right: 0px;
            padding-right: 0px;
        }

        input, select {
            font: normal 13px tahoma !important;
        }

        .wrapper {
            background: #fff;
            border-radius: 4px;
            border: 1px solid #ccc;
            width: 980px;
            padding: 5px;
            margin: 0 auto;
        }

        .auto-style1 {
            border-bottom: 1px solid #ccc;
            padding-bottom: 5px;
            margin-bottom: 5px;
            width: 100%;
        }

        .grid {
            direction: rtl;
            text-align: right;
            border-bottom: 1px solid #ccc;
            padding-bottom: 5px;
            margin-bottom: 5px;
        }

            .grid #drpGridDate {
                line-height: 27px;
                height: 27px;
                margin-left: 10px;
                text-align: center;
            }

            .grid .btn {
                width: 100px;
                height: 27px;
                line-height: 27px;
                margin-right: 10px;
                padding: 4px;
                display: block;
            }

        .formTable {
            direction: rtl;
            font-family: 'BYekan',tahoma;
            font-size: 11px;
            border-collapse: collapse;
            margin: 0 auto;
            width: 100%;
            float: right;
            margin-top: 20px;
            background-color: white;
        }

            .formTable tr:nth-child(odd) {
                background-color: #FAFAFA;
            }

            .formTable tr {
                height: 30px;
            }

            .formTable th:first-child {
                text-align: center;
            }

            .formTable th {
                color: white;
                background-color: #32C8EE;
                text-align: right;
                font-size: 15px;
                border: 1px solid #F5F5F5;
                text-align: center;
            }

            .formTable tr td:first-child {
                width: 50px;
                text-align: center;
            }

            .formTable td:first-child {
                text-align: right;
                padding-right: 7px;
            }

            .formTable tr td {
                border-color: #F0F0F0;
                border-width: 1px;
                height: 30px;
                border-style: solid;
                padding: 5px;
                font-family: 'BYekan',Tahoma;
                font-size: 13px;
                -webkit-transition: all .2s linear;
                -moz-transition: all .2s linear;
                -o-transition: all .2s linear;
                transition: all .2s linear;
            }

                .formTable tr td a {
                    display: block;
                    width: 100px;
                    margin: 0 auto;
                    text-align: center;
                }

                .formTable tr td img {
                    width: 100px;
                    margin: 0 auto;
                    text-align: center;
                }

            .formTable td:last-child {
                text-align: left;
                width: 50px;
            }

                .formTable td:last-child span:before {
                    font-size: 20px;
                }

            .formTable tr:nth-child(odd) {
                background-color: #eee;
            }

            .formTable tr:nth-child(even) {
                background-color: #fff;
            }

            .formTable tr:hover {
                border-color: #fff;
            }

                .formTable tr:hover td {
                    border-right: 1px solid #fff;
                    border-left: 1px solid #fff;
                    /*border:2px solid gold;*/
                    background: #0aa108;
                    color: #fff;
                }

        .grid h3 {
            color: #0aa108;
            padding: 10px 0;
            font: bold 14px tahoma;
            border-bottom: 2px solid #0aa108;
        }

        .inputstyle {
            width: 496px;
            line-height: 27px;
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper ">
            <div class="grid">
                <h3>نمایش سایت ها</h3>
                <table>
                    <tr>
                        <td>جستجو بر کلمه</td>
                        <td>
                            <asp:DropDownList runat="server" Style="width: 500px !important; min-width: initial;"
                                CssClass="chzn-select rtl" ID="ddlParmins">
                            </asp:DropDownList>
                        </td>
                        <td class=""></td>
                    </tr>
                    <tr>
                        <td>فیلتر بر کلمه</td>
                        <td>
                            <asp:TextBox Style='width: 196px; line-height: 27px; height: 27px; margin: 0 10px;'
                                runat="server" ID="txtParminTag"></asp:TextBox>
                            &nbsp;</td>
                        <td class="">
                            <asp:Button runat="server" ID="btnShowAll" OnClick="btnShowAll_Click" Text="نمایش نتایج" CssClass="btn btnShow" /></td>

                    </tr>
                </table>
                <div style="clear: both;"></div>
                <asp:GridView AutoGenerateColumns="false" CssClass="formTable" runat="server" PageIndex="0" PageSize="10" OnPageIndexChanging="grvData_PageIndexChanging" OnRowDataBound="grvData_RowDataBound" AllowPaging="true" ID="grvData">
                    <Columns>
                        <asp:TemplateField HeaderText="ردیف">
                            <ItemStyle></ItemStyle>
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <asp:BoundField DataField="SiteID" HeaderText="کد سایت" />
                        <asp:BoundField DataField="SiteTitle" HeaderText="نام سایت" />
                        <asp:BoundField DataField="Interval" HeaderText="اهمیت پایش" />

                        <asp:TemplateField HeaderText="نوع سایت">
                            <ItemStyle></ItemStyle>
                            <ItemTemplate>
                                <asp:DropDownList runat="server" Enabled="false"
                                    Style="color: #666 !important; border-color: #ccc; font: normal 13px 'BYekan',tahoma; padding: 3px; width: 200px;"
                                    ID="ddlSiteType">
                                    <asp:ListItem Text="خبرگزاری - پایگاه خبری" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="روزنامه" Value="2"></asp:ListItem>

                                </asp:DropDownList>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="وضعیت پایش">
                            <ItemStyle></ItemStyle>
                            <ItemTemplate>
                                <asp:DropDownList runat="server" Enabled="false"
                                    Style="color: #666 !important; border-color: #ccc; font: normal 13px 'BYekan',tahoma; padding: 3px; width: 200px;"
                                    ID="ddlPayeshType">
                                    <asp:ListItem Text="فعال" Value="true"></asp:ListItem>
                                    <asp:ListItem Text="غیرفعال" Value="false"></asp:ListItem>

                                </asp:DropDownList>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="setting" HeaderText="">
                            <ItemStyle></ItemStyle>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnRemove" CommandArgument='<%# Eval("SiteID") %>'
                                    runat="server"
                                    CssClass="btn" OnClick="lbtnRemove_Click">
                                          <span class="fa fa-pencil green">حذف</span>
                                </asp:LinkButton>


                            </ItemTemplate>


                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div style="clear: both;"></div>
            </div>

            <div>
                <asp:Literal runat="server" ID="ltMsgRegBil"></asp:Literal>
            </div>
            <div class="grid">
                <h3>ثبت شرکت</h3>

                <table class="auto-style1">
                    <tr>
                        <td>کد سایت</td>
                        <td>
                            <asp:TextBox CssClass="inputstyle" runat="server" MaxLength="550" ID="txtSiteCode"></asp:TextBox>
                            <span>جهت ویرایش سایت
                            </span></td>
                    </tr>

                    <tr>
                        <td>نام سایت</td>
                        <td>
                            <asp:TextBox CssClass="inputstyle" runat="server" MaxLength="550" ID="txtParminName"></asp:TextBox>
                        </td>
                    </tr>


                    <tr>
                        <td>نوع سایت</td>
                        <td>
                            <asp:DropDownList runat="server"
                                ID="ddlSiteType" Width="400px">
                                <asp:ListItem Text="خبرگزاری - پایگاه خبری" Selected="True" Value="1"></asp:ListItem>
                                <asp:ListItem Text="روزنامه" Value="2"></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>اولویت پایش</td>
                        <td>
                            <asp:TextBox ID="txtInterval" CssClass="inputstyle" Text="300000" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="btnReg" OnClick="btnReg_Click" Text="ثبت شرکت" CssClass="btn" /></td>
                    </tr>
                </table>
            </div>

            <script src="../Scripts/chosen.jquery.js"></script>
            <link href="../Styles/chosen.css" rel="stylesheet" />

            <script type="text/javascript">
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
                $(".chzn-select").change(function () {

                    //  DoDropDownAutoComplete();
                });
            </script>
        </div>
    </form>
</body>
</html>
