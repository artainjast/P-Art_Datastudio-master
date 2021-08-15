<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="SocialAnalyz.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SocialAnalyz" %>

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

    <style>
        #list-news {
            width: 100%;
        }

        @media print {
            .topBar, #logoBox, .MainNav, #list-news .filter-box, .SwitchSelect, .result-title-social ul, .tagedit-list, .result-title-social .cricle, footer, .progressbar {
                display: none;
            }

            body {
                background: white;
            }
            /*#chart7 {
    border: 1px solid #cccccc;
    margin: 10px 10px 25px 10px;
    overflow: hidden;
    border-radius: 7px 7px 7px 7px;
    -moz-border-radius: 7px 7px 7px 7px;
    -webkit-border-radius: 7px 7px 7px 7px;
}*/

            #chart7 .highcharts-title tspan {
                font-size: 24px !important;
                font-family: "B Mitra","IranSans",tahoma, arial !important;
                font-weight: 500;
            }

            .wrapper {
                border: none;
                width: 95%;
            }

            .result-title-social h1 {
                text-align: center;
                font-size: 14px;
            }

            .page-break {
                display: block;
                page-break-before: always;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <div class="PageSubLink">
        <ul>
            <li><a href="/Twitter/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای توییتر</a></li>
            <li><a href="/TwitterKeywords/" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a href="/TwitterBultanArchive/" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
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

        <div id="report-result">
            <div id="box-waiting" class="alert alert-info" style="display: none">
                لطفا چند لحظه صبر کنید
            </div>
            <div id="keys-result">

                <div class="result-title-social chartContainer">
                    <span class="title">فراوانی کلید واژه ها در توییتر</span>

                    <div id="progress1" class="progressbar">
                    </div>
                    <div id="TwitterKeywordChart" class="ControlTopPadding"></div>
                </div>

                <div class="result-title-social chartContainer">
                    <span class="title">درصد فراوانی مطالب منتشر شده به تفکیک سو گيری در رسانه</span>

                    <div id="progress6" class="progressbar">
                    </div>
                    <div id="chart6" class="ControlTopPadding"></div>
                </div>

                <div class="page-break"></div>
                <div class="result-title-social chartContainer">
                    <span class="title">درصد فراوانی مطالب منتشر شده به تفکیک كاربران</span>
                 
                    <div id="progress7" class="progressbar">
                    </div>

                    <div id="chart7" class="ControlTopPadding"></div>
                </div>

<%--                <div class="page-break"></div>
                <div class="page-break"></div>
                <div class="result-title-social chartContainer">
                    <span class="title">جدول توزیع فراوانی تعداد کاربران</span>
                  
                    <div id="progress3" class="progressbar">
                    </div>
                    <table class="table-report3 tableStyle"
                        <thead>
                            <tr>
                                <th>كاربران</th>
                                <th>تعداد</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>

                <div class="page-break"></div>--%>

            </div>

        </div>
    </section>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".tag1").tagedit();
            $(".tag2").tagedit();

            Page_Init();

            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();
            TwitterKeywordCountChart(fromDate, toDate);
            analyz_LoadChart4_social(fromDate, toDate);
            analyz_LoadChartUsers_social(fromDate, toDate);
            analyz_LoadUsers_Social(fromDate, toDate);
        });
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

        }


        function TwitterKeywordCountChart(fromdate, todate, callback) {

            $.ajax({
                type: "POST",
                url: "/pages/P-Art/Pages/SocialAnalyz.aspx/TwitterKeywordCountChart",
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
                    $('#TwitterKeywordChart').highcharts({
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




    </script>

</asp:Content>
