<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="SmsPanel.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SmsPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .formTable {
            font-size: 13px;
            margin: 10px auto;
      width: 100%;  }

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
                    max-width: 400px;
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
            left:50%;
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


        .smsNumb {
            position: relative;
            cursor: pointer;
        }

            .smsNumb span, .btnSaveSetting {
                width: 70px;
                height: 30px;
                line-height: 30px;
                background: #149adb;
                display: block;
                color: #fff;
                border-radius: 4px;
                border: 1px solid #0c81ba;
                text-align: center;
            }

            .smsNumb.active span {
                background: #0671a5;
                border: 1px solid #084462;
            }

            .smsNumb i {
                position: absolute;
                right: 6px;
                top: -3px;
                background: #bb1313;
                color: #fff;
                width: 12px;
                height: 12px;
                padding: 2px;
                font-style: normal;
                border-radius: 4px;
                line-height: 13px;
            }

            .smsNumb ul {
                display: none;
                position: absolute;
                top: 18px;
                right: 0px;
                background: #fff;
                border-radius: 4px;
                padding: 10px 20px;
                border: 1px solid #ADA3A3;
                z-index: 2;
            }

                .smsNumb ul li {
                    color: #111;
                    direction: ltr;
                    text-align: center;
                    list-style: none;
                    margin-bottom: 5px;
                }

        #updMain {
           
        }



        .smsParameters {
            margin:10px 0; 
        }

            .smsParameters span {
                background: #51A586;
                padding: 2px;
                margin-bottom: 2px;
                margin-top: 2px;
                display: inline-block;
                color: #fff;
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
            <div class="gridSetting clearfix" style="height: 160px; margin-bottom: 30px;">
                <fieldset>
                    <legend>تنظیمات پنل اس ام اس</legend>
                    <div class="right" style="width: 450px">
                        <span>فرمت ارسال پیام : </span>
                        <span>
                            <asp:TextBox CssClass="txtSmsFormat" runat="server" ID="txtSmsFormat" TextMode="MultiLine" Height="80px" Width="300px"></asp:TextBox></span>

                        <asp:Label runat="server" ID="lblMsg"> </asp:Label>
                    </div>
                    <div class="left " style="width: 500px">
                        <h5 style="padding: 0; margin: 0;">پارامترهای فرمت پیامک :</h5>
                        <div class="smsParameters">
                            <span>[عنوان رسانه]</span>
                            - 
                       <span>[عنوان خبر]</span>
                            - 
                        <span>[تاریخ خبر]</span>
                            - 
                        <span>[ساعت خبر]</span>
                            - 

                        <span>[شاهد خبر]</span>

                        </div>
                        <div>
                            <asp:LinkButton Width="90px" CausesValidation="false" CssClass="btnSaveSetting" runat="server" ID="btnRegSetting" OnClick="btnRegSetting_Click">
                                <span>ثبت تنظیمات</span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="gridSetting clearfix">
                <div class="right">
                    <span>جستجو : </span>
                    <span>
                        <asp:TextBox runat="server" OnTextChanged="txtSearch_TextChanged" ID="txtSearch" Width="300px"></asp:TextBox></span>
                </div>
                <div class="left">
                    <span>تعداد نمایش : </span>
                    <span>
                        <asp:DropDownList AutoPostBack="true" runat="server" OnSelectedIndexChanged="txtGridCount_SelectedIndexChanged" ID="txtGridCount" Width="50px">
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                            <asp:ListItem Value="20" Selected="True" Text="20"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50"></asp:ListItem>
                            <asp:ListItem Value="100" Text="100"></asp:ListItem>
                            <asp:ListItem Value="200" Text="200"></asp:ListItem>
                        </asp:DropDownList></span>

                </div>
            </div>
            <div class="clearfix">
                <asp:GridView runat="server" ID="grvSmsList" CssClass="formTable" AutoGenerateColumns="false" OnPageIndexChanging="grvSmsList_PageIndexChanging" AllowPaging="true" OnRowDataBound="rptSmsList_RowDataBound" PageIndex="0" PageSize="20">
                    <Columns>
                        <asp:TemplateField ItemStyle-CssClass="text"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="ردیف">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-CssClass="text" HeaderText="پیام ارسالی">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hdfID" Value='<%# Eval("NewsID") %>' />
                                <span title=' <%# Eval("SMSText") %>'><%# Eval("SMSText") %></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="ارسال شده به">
                            <ItemTemplate>

                                <div class="smsNumb">
                                    <span>نمایش</span><i class="count"><asp:Literal runat="server" ID="ltSmsNumberCount"></asp:Literal></i>
                                    <ul>
                                        <asp:Literal runat="server" ID="ltSmsNumbers"></asp:Literal>
                                    </ul>
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="تاریخ ارسال">
                            <ItemTemplate>
                                <%# Persia.Calendar.ConvertToPersian(Convert.ToDateTime( Eval("SmsDate"))).ToString() %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="ساعت ارسال">
                            <ItemTemplate>
                                <%# Persia.Calendar.ConvertToPersian(Convert.ToDateTime( Eval("SmsDate"))).ToString("H") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="وضعیت">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" Enabled="false" ID="ddlStatus">
                                    <asp:ListItem Selected="True" Text="ارسال شده" Value="false"></asp:ListItem>
                                    <asp:ListItem Text="عدم ارسال" Value="true"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="امکانات" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <a class="" href='/ShowNews/<%# Eval("NewsID") %>' target="_blank">نمایش خبر</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="gridPager" />
                    <PagerSettings Mode="NumericFirstLast" Position="Bottom" Visible="true" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtSearch" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnRegSetting" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

        $(function () {

            $('.smsNumb').live('click', function () {

                var $this = $(this);
                if ($this.hasClass('active')) {
                    $this.removeClass('active');
                    $this.find('ul').slideUp();
                }
                else {
                    $('.smsNumb').each(function (e) {
                        $(this).find('ul').hide();
                        $(this).removeClass('active');

                    });
                    $this.find('ul').slideDown();
                    $this.addClass('active');
                }
            });

        });
        //smsParameters
        $(".smsParameters span").draggable({ helper: "clone", revert: "invalid" });
        $(".txtSmsFormat").droppable({
            drop: function (event, ui) {
                $(".txtSmsFormat").val($(".txtSmsFormat").val() + ui.draggable.text());
                //return false;
            }
        });
    </script>
</asp:Content>
