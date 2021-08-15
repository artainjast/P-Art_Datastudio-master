<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="AnalyzeKeywords.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.AnalyzeKeywords" %>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <%--  <script src="/Pages/P-Art/Scripts/jquery-1.8.1.min.js"></script>--%>
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/ui-lightness/jquery-ui-1.8.6.custom.css" />
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery.tagedit.css" />
    <script src='/Pages/P-Art/Scripts/jquery.autoGrowInput.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery.tagedit.js' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/tsort.min.js"></script>

    <script src="/Pages/P-Art/Scripts/highcharts.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.highchartTable-min.js"></script>
    <script src="/Pages/P-Art/Scripts/data.js"></script>
    <script src="/Pages/P-Art/Scripts/exporting.js"></script>

</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <div class="PageSubLink">
        <ul>
            <li><a href="/News/Latest/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/Analysis" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوا</a></li>
            <li><a href="/keywords" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه</a></li>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="fab fa-keycdn"></i></span>آنالیز کلید واژه ها</a></li>
            <li><a href="/News/BultanArchive" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="/addnews" runat="server"><span><i class="fas fa-pen-square"></i></span>ثبت خبر</a></li>
            <li><a href="/Pages/P-Art/Pages/SavedNews.aspx" runat="server"><span><i class="fas fa-hdd"></i></span>اخبار ذخیره شده</a></li>
        </ul>
    </div>
    <cc1:JQLoader ID="DateLoader" runat="server" Theme="Blitzer" LoadJQScript="false" />

    <asp:ScriptManager ID="ScriptManager1" AsyncPostBackTimeout="300" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="updMain" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">

        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="updProgress">
                <ProgressTemplate>
                    <div class="loading">
                        <img src="/Pages/P-Art/Images/loading.gif" /><span>درحال دریافت اطلاعات ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <section class="filter-box" style="margin-top: 10px">

                <div class="bar">

                    <asp:DropDownList ID="drp_newsSource" runat="server" CssClass="btn btn-outline-info cur-p ControlLeftMargin" Width="140px"  >
                            <asp:ListItem Text="کلی" Value="0" Selected="True" />
                            <asp:ListItem Text="جراید" Value="1" />
                            <asp:ListItem Text="خبرگزاری ها" Value="2" />
                    </asp:DropDownList>
                    <span>از تاریخ</span>
                    <cc1:JQDatePicker ID="txt_fromDate" ShowSelectButton="false" Width="65px" runat="server" CssClass="textbox" DateFormat="YMD" Regional="fa">
                    </cc1:JQDatePicker>

                    <span>تا تاریخ</span>
                    <cc1:JQDatePicker ID="txt_toDate" ShowSelectButton="false" Width="65px" runat="server" CssClass="textbox" DateFormat="YMD" Regional="fa">
                    </cc1:JQDatePicker>
                    <div class="bar keyword1" style="text-align:right;">
                        <input type="text" name="tag[]" value="" class="tag1" />
                    </div>
                    <asp:HiddenField runat="server" ID="hdfKeys" />
                    <asp:Button ID="btn_ReportChart" OnClick="btn_ReportChart_Click" OnClientClick="OnReportClick();" runat="server" Text="نمایش گزارش"  CssClass="btn btn-info cur-p" />
                </div>
                <div>
                    <asp:GridView ID="grvData" Width="100%" Visible="false" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
                <div id="container">
                </div>
                <asp:Literal runat="server" ID="ltChart">
                        


                </asp:Literal>
                <div id="containerPie">
                </div>
                <asp:Literal runat="server" ID="ltPie">
                        


                </asp:Literal>
        </ContentTemplate>
        <Triggers>



            <asp:AsyncPostBackTrigger EventName="Click" ControlID="btn_ReportChart" />



        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".tag1").tagedit();


        });
        function OnReportClick() {
            var str = "";
            $('.tagedit-listelement.tagedit-listelement-old').each(function (e) {

                str += "," + $(this).find('span').text();
            });
            $('#<%= hdfKeys.ClientID %>').val(str);
            // alert(str);
            __doPostBack('<%= btn_ReportChart.UniqueID %>', '');
        }
        function ShowChart() {

            $('#container').highcharts({
                data: {
                    table: 'datatable'
                },
                chart: {
                    type: 'line',
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a'
                    },
                    height: 500
                },
                title: {
                    text: 'روند حرکتی کلیدواژه ها'
                },
                yAxis: {
                    allowDecimals: false,
                    title: {
                        text: 'تعداد'
                    }
                },
                tooltip: {
                    //formatter: function () {
                    //    return '<b>' + this.series.name + '</b><br/>' +
                    //        this.point.y + ' ' + this.point.name.toLowerCase();
                    //}
                    formatter: function () {
                        return '<b>' + this.y + '</b> ' + ' : ' + '<b>' + this.series.name + '</b>' + '<br/><br/>' + this.point.name.toLowerCase();
                    },
                    useHTML: true
                }
            });
            $('#datatable').fadeOut();
        }
        function ShowPie() {

            $('#containerPie').highcharts({
                data: {
                    table: 'datatablePie'
                },
                chart: {
                    type: 'pie',
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a'
                    },
                    height: 500
                },
                title: {
                    text: 'گراف فراوانی کلیدواژه ها'
                },
                yAxis: {
                    allowDecimals: false,
                    title: {
                        text: 'تعداد'
                    }
                },
                tooltip: {
                    //formatter: function () {
                    //    return '<b>' + this.series.name + '</b><br/>' +
                    //        this.point.y + ' ' + this.point.name.toLowerCase();
                    //}
                    formatter: function () {
                        return '<b>' + this.y + '</b> ' + ' : ' + this.point.name.toLowerCase();
                    },
                    useHTML: true
                }
            });

            $('#datatablePie').fadeOut();
        }
        if (typeof (Sys) != "undefined") {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        }
        function EndRequestHandler(sender, args) {
            $(".tag1").tagedit();

            // analyz_LoadDefaultKeywords();
        }

    </script>
</asp:Content>
