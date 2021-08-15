<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlSocialNews.aspx.cs" Inherits="P_Art.HtmlSocialNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/htmlSocialBultan.css?ver=10.8" rel="stylesheet" />
    <script src='/Pages/P-Art/Scripts/jquery.min.js' type="text/javascript"></script>
    <%--<script src="http://code.jquery.com/jquery-1.10.2.min.js"></script>--%>
    <script src="Pages/P-Art/Scripts/jquery-1.8.1.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <meta charset="utf-8" />
    <%-- <link href="Pages/P-Art/Styles/MainStyle.css" rel="stylesheet" />--%>
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no, width=device-width" />
    <meta http-equiv="Content-Security-Policy" />
    <style>
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Block" ChildrenAsTriggers="false" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel1" runat="server" ID="updProgress">
                    <ProgressTemplate>
                        <div class="shadow"></div>
                        <div class="loading">
                            <a>لطفا منتظر بمانید....</a>
                        </div>


                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:HiddenField runat="server" ID="hdfAllowChart" />
                <asp:HiddenField runat="server" ID="hdfBultanArchiveID" />

                <div class="home">
                    <div class="newsContainer">
                        <asp:Literal runat="server" ID="ltPostHtml"></asp:Literal>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="/Scripts/jquery-1.8.1.min.js"></script>
    <script src="/Scripts/jquery.lazy.min.js"></script>
    <script src="/Scripts/localScroll.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.fancybox.js"></script>
    <link href="/Pages/P-Art/Styles/jquery.fancybox.css" rel="stylesheet" />
    <script>
        $(window).load(function () {
            var elementExistsDivChart = document.getElementById("chart1");
            var fehrestHtml = "";
            if (elementExistsDivChart != null) {
                fehrestHtml += "<a class='roozname' href='#chart1' >" + "نمودار" + "</a>";
            }

        });
    </script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/highcharts.js") %>'></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/wordcloud.js") %>'></script>
    <script>

        $.ajax({
            type: "POST",
            url: "/Pages/P-Art/Pages/ajax.aspx/ChartBoultanSocial",
            data: "{'ArchiveId':'" + $('#<%=hdfBultanArchiveID.ClientID%>').val() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                newData = [];

                for (var i = 0; i < data.d.length; i++) {

                    newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                }


                //start chart

                Highcharts.chart('chart1', {
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: null,
                        plotShadow: false,
                        type: 'pie',
                        height: 400
                    },
                    xAxis: {
                        type: 'category',
                        rotation: -45
                    },
                    yAxis: {
                        title: {
                            text: 'نمودار توزیع فراوانی پست های منتشر شده از سوی کاربران'
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
                        text: 'نمودار توزیع فراوانی پست های منتشر شده از سوی کاربران'
                    },
                    legend: {
                        enabled: true,
                        layout: 'vertical',
                        align: 'top',
                        itemWidth: 120,

                        useHTML: true,
                        labelFormatter: function () {
                            return '<div style="text-align: left;font-size:10px;font-family:B Mitra !important; width:130px;float:left;">' +
                                this.name + '</div>';
                        }
                    },
                    dataLabels: {
                    },
                    tooltip: {
                        pointFormat: ''
                    },
                    plotOptions: {
                        pie: {
                            size: '100%',
                            allowPointSelect: true,
                            cursor: 'pointer',
                            showInLegend: true,
                            dataLabels: {
                                enabled: true,
                                format: '<span style="color:#FFF;text-shadow:none;font-weight:normal;stroke: none;font-family:B Mitra !important;font-size:18px;" >{point.percentage:.1f} %</span>',
                                distance: -50,
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
                        name: 'کاربران فعال',
                        data: newData,
                        stake: 'کاربران فعال'

                    }]
                });

            }
        });

    </script>
    <script>
        $('#keys-result .table-report3').css("display", "block");
        $('#keys-result .table-report3').attr('style', '');
        $('#keys-result .table-report3 tr').attr('style', '');
        $('#keys-result .table-report3 th').attr('style', '');
        $('#keys-result .table-report3 td').attr('style', '');

        $('#keys-result .table-report3 tr:not(:has(th))').remove();

        $.ajax({
            type: "POST",
            url: "/Pages/P-Art/Pages/ajax.aspx/ChartBoultanSocial",
            data: "{'ArchiveId':'" + $('#<%=hdfBultanArchiveID.ClientID%>').val() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                newData = [];

                for (var i = 0; i < data.d.length; i++) {
                    newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

                    $("#keys-result .table-report3 tbody").append("<tr><td>" + data.d[i].Name + "</td><td>" + parseInt(data.d[i].Value) + "</td>" + "</tr>");
                }
                // $("#progress3").animate({ width: percentLoaded + '%' }, 400);
                if (liCounter == keyCount) {
                    $('#keys-result .table-report3').tableSort({
                        animation: 'fade',
                        speed: 250,
                        delay: 25
                    });
                }
            }
         });

    </script>
</body>
</html>
