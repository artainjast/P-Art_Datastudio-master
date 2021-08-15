<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="TelegramAnalyzeNew.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.TelegramAnalyzeNew" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/ui-lightness/jquery-ui-1.8.6.custom.css" />
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery.tagedit.css" />


    <%--    <script src='/Pages/P-Art/Scripts/jquery-ui-1.8.6.custom.min.js' type="text/javascript"></script>--%>

    <script src='/Pages/P-Art/Scripts/jquery.autoGrowInput.js' type="text/javascript"></script>

    <script src='/Pages/P-Art/Scripts/jquery.tagedit.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/highcharts.js' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/tsort.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/exporting.js") %>'></script>

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
    
    <div class="PageSubLink">
        <ul>
            <li><a href="/Telegram/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای تلگرام</a></li>
            <li><a href="/TelegramKeywords/" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a href="/TelegramBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a id="ShowTelegramFilterButton"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
        </ul>
    </div>
    <div id="SocialKeyBox" class="SocialKeyBox">

        <div class="SocialKeyBoxFooter">
            <span>از تاریخ</span>
            <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" />
            <span>تا تاریخ</span>
            <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" />
            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-primary cur-p" Text="نمایش " OnClick="btn_ShowNews_Click"  />
        </div>
    </div>

    <div class="chartContainer">
        <div id="progress1" class="progressbar"></div>
        <span class="title">نمودار فراوانی کلید واژه ها در تلگرام</span>
        <div id="KeyWordCountChart" class="ControlTopPadding"></div>
    </div>

        <div  class="chartContainer">
        <div id="progress2" class="progressbar"></div>
        <span class="title">نمودار فراوانی کانال های تلگرام</span>
        <div id="ChannelsCountChart" class="ControlTopPadding"></div>
    </div>

       <script type="text/javascript">

        $(document).ready(function () {

            Page_Init();

            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();
            TelegramKeywordCountChart(fromDate, toDate);
            TelegramChannelsCountChart(fromDate, toDate);
            
        });
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

        }

        function TelegramKeywordCountChart(fromdate, todate, callback) {

            $.ajax({
                type: "POST",
                url: "/pages/P-Art/Pages/TelegramAnalyzeNew.aspx/TelegramKeywordCountChart",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    newData = [];
                    for (var i = 0; i < data.d.length; i++) {
                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);
                    }

                    $("#progress1").animate({ width: '100%' }, 400);
                    //start chart
                    $('#KeyWordCountChart').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a',

                            },
                            backgroundColor: 'transparent',
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie',
                            height: 800
                        },
                        xAxis: {
                            type: 'category',
                            rotation: -45
                        },
                        yAxis: {
                            title: {
                                text: ''
                            }
                        },
                        credits: { enabled: false },
                        stackLabels: {
                            enabled: true,
                            style: {
                                fontWeight: 'bold',
                                color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                            }
                        },
                        title: {
                            text: 'کلید واژه ها',
                            style:
                            {
                                color: '#72777a',
                                fontWeight: 'bold',
                                fontSize: '14px'
                            }
                        },
                        legend: {
                            enabled: true,
                            layout: 'vertical',
                            align: 'top',
                            itemWidth: 120,
                            padding: 10,
                            itemmargintop: 5,
                            itemmarginbottom: 5,
                            itemstyle:
                                {
                                    lineheight: '14px'
                                },
                            useHTML: true,
                            labelFormatter: function () {
                                return '<div style="top:-4px; position:relative;">' + this.name + ' [ ' + this.y + ' عدد]</div>';
                            },

                        },
                        dataLabels: {

                        },
                        tooltip: {
                            pointFormat: '<b>{point.percentage:.1f}%</b>',
                            shared: true,
                            useHTML: true,


                        },
                        plotOptions: {
                            pie: {
                                size: '70%',
                                allowPointSelect: true,
                                cursor: 'pointer',
                                showInLegend: true,
                                dataLabels: {
                                    enabled: true,
                                    format: '<span>{point.percentage:.1f} %</span>',
                                    style: {
                                        fontFamily: 'Conv_BTrafficBold',
                                        fontWeight: '100',
                                        fontSize: '14px'

                                    },
                                    x: 33,
                                    distance: -30,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 4
                                    }
                                }
                            }
                        },
                        series: [{
                            type: 'pie',
                            name: 'کلید واژه ها',
                            data: newData,
                            stake: 'کلید واژه ها'


                        }]
                    });

                    if (callback) callback();
                }
            });
        }

        function TelegramChannelsCountChart(fromdate, todate, callback) {

            $.ajax({
                type: "POST",
                url: "/pages/P-Art/Pages/TelegramAnalyzeNew.aspx/TelegramChannelsCountChart",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    newData = [];
                    for (var i = 0; i < data.d.length; i++) {
                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);
                    }

                    $("#progress2").animate({ width: '100%' }, 400);
                    //start chart
                    $('#ChannelsCountChart').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a',

                            },
                            backgroundColor: 'transparent',
                            plotBackgroundColor: null,
                            plotBorderWidth: null,
                            plotShadow: false,
                            type: 'pie',
                            height: 800
                        },
                        xAxis: {
                            type: 'category',
                            rotation: -45
                        },
                        yAxis: {
                            title: {
                                text: ''
                            }
                        },
                        credits: { enabled: false },
                        stackLabels: {
                            enabled: true,
                            style: {
                                fontWeight: 'bold',
                                color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                            }
                        },
                        title: {
                            text: 'کانال ها',
                            style:
                            {
                                color: '#72777a',
                                fontWeight: 'bold',
                                fontSize: '14px'
                            }
                        },
                        legend: {
                            enabled: true,
                            layout: 'vertical',
                            align: 'top',
                            itemWidth: 120,
                            padding: 10,
                            itemmargintop: 5,
                            itemmarginbottom: 5,
                            itemstyle:
                                {
                                    lineheight: '14px'
                                },
                            useHTML: true,
                            labelFormatter: function () {
                                return '<div style="top:-4px; position:relative;">' + this.name + ' [ ' + this.y + ' عدد]</div>';
                            },

                        },
                        dataLabels: {

                        },
                        tooltip: {
                            pointFormat: '<b>{point.percentage:.1f}%</b>',
                            shared: true,
                            useHTML: true,


                        },
                        plotOptions: {
                            pie: {
                                size: '70%',
                                allowPointSelect: true,
                                cursor: 'pointer',
                                showInLegend: true,
                                dataLabels: {
                                    enabled: true,
                                    format: '<span>{point.percentage:.1f} %</span>',
                                    style: {
                                        fontFamily: 'Conv_BTrafficBold',
                                        fontWeight: '100',
                                        fontSize: '14px'

                                    },
                                    x: 33,
                                    distance: -30,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 4
                                    }
                                }
                            }
                        },
                        series: [{
                            type: 'pie',
                            name: 'کانال ها',
                            data: newData,
                            stake: 'کانال ها'


                        }]
                    });

                    if (callback) callback();
                }
            });
        }


        $("#ShowTelegramFilterButton").click(function () {
            $(".SocialKeyBox").fadeToggle(1000);
        });

    </script>

</asp:Content>


