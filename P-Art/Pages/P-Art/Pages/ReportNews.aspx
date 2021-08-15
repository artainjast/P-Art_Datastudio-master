<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="ReportNews.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.ReportNews"
    EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="tabbed">

        <ul>
            <li class="selected"><a href="~/news/Latest" runat="server">تازه ها</a></li>
            <li><a href="~/news/update" runat="server">خوانده نشده</a>

            </li>

            <li><a href="~/news/export" runat="server">ساخت بولتن</a></li>

        </ul>
    </div>

    <section id="list-news">
        <div id="outboxSearch">
            <span>جستجو اخبار
            </span>
        </div>
        <section class="filter-box">

            <div class="bar">


                <div class="styled-select">

                    <asp:DropDownList ID="drp_reportType" runat="server">
                        <asp:ListItem Text="امروز" Value="0" Selected="True" />
                        <asp:ListItem Text="یک هفته اخیر" Value="1" />
                        <asp:ListItem Text="یک ماه اخیر" Value="2" />
                        <asp:ListItem Text="ذخیره شده" Value="3" />
                    </asp:DropDownList>
                </div>
                <div class="styled-select">

                    <asp:DropDownList ID="drp_newsSource" runat="server">
                        <asp:ListItem Text="کلی" Value="0" Selected="True" />
                        <asp:ListItem Text="جراید" Value="1" />
                        <asp:ListItem Text="خبرگزاری ها" Value="2" />

                    </asp:DropDownList>
                </div>
                <div class="styled-select" runat="server" id="select_newSource2" visible="false">

                    <asp:DropDownList ID="drp_newsSource2" runat="server">
                        <asp:ListItem Text="اخبار امروز" Value="0" Selected="True" />
                        <asp:ListItem Text="اخبار یک هفته اخیر" Value="1" />
                        <asp:ListItem Text="اخبار یک ماه اخیر" Value="2" />
                    </asp:DropDownList>
                </div>

                <asp:LinkButton ID="btn_PrintTitle" CssClass="printbutton" runat="server"
                    ToolTip="چاپ عنوان اخبار" OnClick="btn_PrintTitle_Click">
                    <span class="fontawesome-print"></span>
                </asp:LinkButton>
                <asp:LinkButton ID="btn_PrintLead" CssClass="printbutton" runat="server" ToolTip="چاپ عنوان و خلاصه اخبار"
                    OnClick="btn_PrintLead_Click">
                    <span class="fontawesome-print"></span>
                </asp:LinkButton>

            </div>
            <div class="bar">
                <span>جستجو عبارت : 
                </span>
                <asp:TextBox ID="txt_Search" runat="server" CssClass="textbox" Style="width: 159px"
                    placeholder="متن جستجو ..." />

                <span>از تاریخ :
                </span>
                <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="width: 88px"
                    Text="1391/09/05" />
                <span>تا تاریخ :
                </span>
                <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 88px"
                    Text="1391/09/05" />

            </div>
            <div class="bar">
                <asp:Button ID="btn_Report" runat="server" Text="نمایش گزارش"
                    CssClass="BlueButton" OnClick="btn_Report_Click" />
                <div class="styled-select" style="margin: 0; margin-right: 6px;">

                    <asp:DropDownList ID="drp_exportType" runat="server">
                        <asp:ListItem Text="PDF" Value="0" Selected="True" />
                        <asp:ListItem Text="Word" Value="1" />

                    </asp:DropDownList>
                </div>

                <asp:Button ID="btn_exportReport" runat="server" Text="تهیه بولتن"
                    CssClass="BlueButton" OnClick="btn_exportReport_Click" />

            </div>


        </section>

        <div id="boxPdfSetting">
            <div id="lst_checks">
                <asp:CheckBox ID="check_NewsPaper" runat="server" Text=" " />
                <span>پیشخوان
                </span>
                <asp:CheckBox ID="check_ChartKhabar" runat="server" Text=" " />
                <span>نمودارها
                </span>

                <asp:CheckBox ID="check_Sima" runat="server" Text=" " />
                <span>صدا و سیما
                </span>
                <asp:CheckBox ID="check_gozideh" runat="server" Text=" " />
                <span runat="server" id="span_gozideh">ارسال به پنل گزیده اخبار
                </span>

                <asp:CheckBox ID="check_mashrooh" runat="server" Text=" " />
                <span runat="server" id="span_mashrooh">ارسال به پنل مشروح اخبار
                </span>


                <asp:Button runat="server" CssClass="BlueButton" Text="تایید" ID="btn_generate" />
            </div>

            <div id="loading">
                <img src="~/Pages/P-Art/Images/ajax-loader.gif" runat="server" />
            </div>

            <div id="DownloadBox">


                <span id="fileSize"></span>

                <a href="#" class="BlueButton" target="_blank" id="lnkDownload">دریافت فایل
                </a>
            </div>
        </div>
        <asp:GridView ID="grd_News" runat="server" AutoGenerateColumns="False"
            EnableViewState="true" OnRowDataBound="grd_News_RowDataBound" OnDataBound="grd_News_DataBound"
            OnRowCreated="grd_News_RowCreated">
            <Columns>
                <asp:TemplateField>

                    <HeaderTemplate>
                        <asp:CheckBox ID="Check_All" runat="server" />
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:HiddenField ID="fld_newsId" runat="server" Value='<%#Eval("NewsId") %>' />
                        <asp:CheckBox CssClass="check_news" ID="check_selected" runat="server" data-id='<%#Eval("NewsId") %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="20px" />
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="تاریخ خبر">
                    <ItemTemplate>
                        <span class="lbl-date">
                            <%# Eval("NewsDate") %>

                            <br />
                            <%# Eval("SiteTitle").ToString() %>
                            <br />
                               کد خبر : 
                            <%# Eval("NewsId") %>
                        </span>
                    </ItemTemplate>
                    <HeaderStyle Width="70px" />
                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="عنوان خبر">
                    <HeaderTemplate>
                        <asp:Label ID="NewsCount" runat="server">
                            تعداد اخبار 100
                        </asp:Label>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <span class="lbl-title">
                            <%# Eval("NewsTitle") %>
                        </span>
                        <p>
                            <span style="font-size: 27px; color: #DD0A0A; text-align: center;">.
                            </span>
                            <%# Eval("NewsLead") %>
                          
                         
                        </p>

                        <div class="newsrate" runat="server" visible='<%# IsNewsRateVisible() %>'>

                            <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                            <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                            <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'>
                            </a>
                          
                        </div>
                    </ItemTemplate>
                    <HeaderStyle Width="300px" />
                    <ItemStyle Width="300px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:GridView ID="grd_word" runat="server" AutoGenerateColumns="False" ShowHeader="False"
            BorderStyle="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black;
                            text-align: right; font-family: 'B Titr'; font-size: 15px;">

                            <%# Eval("SiteTitle").ToString() %>

                        </span>
                        <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black;
                            text-align: right; font-family: 'B Titr'; font-size: 15px;">

                            <%#  mirrorDate(Eval("NewsDate").ToString()) %>

                        </span>
                        <p style="font-family: 'B Titr'; font-size: 18px; direction: rtl; text-align: justify;
                            margin-right: 20px; margin-left: 20px">
                            <%#Eval("NewsTitle") %>
                        </p>

                        <p style="font-family: 'B Nazanin'; font-size: 15px; text-align: justify; direction: rtl;
                            margin-right: 20px; margin-left: 20px">
                            <%#Eval("NewsLead") %>
                        </p>

                        <p style="font-family: 'B Nazanin'; font-size: 15px; text-align: justify; direction: rtl;
                            margin-right: 20px; margin-left: 20px">
                            <%#Eval("NewsBody") %>
                        </p>


                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    </section>
</asp:Content>
