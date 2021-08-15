<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlGroupNews.aspx.cs" Inherits="P_Art.HtmlGroupNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/htmlGroupBultan.css?ver=10.8" rel="stylesheet" />
    <style type="text/css" media="print">
        .fixed-table-of-content {
            display: none !important;
        }

        #fixedheader {
            display: none !important;
        }
    </style>
    <style type="text/css">
        .home {
            color: #272727;
            background: #f9f9f9 url(/styles/img/bgFalat.jpg) center top no-repeat;
            background-size: 100%;
        }


    </style>
    <meta charset="utf-8" />
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no, width=device-width" />
    <meta http-equiv="Content-Security-Policy" />
    <link href="/Styles/WorkResponsive.css" rel="stylesheet" />
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
                <asp:HiddenField runat="server" ID="hdfDate" />
                <asp:HiddenField runat="server" ID="hdfToDate" />
                <asp:HiddenField runat="server" ID="hdfParmin" ClientIDMode="Static" />
                <asp:HiddenField runat="server" ID="hdfSelectedBultan" />
                <asp:HiddenField runat="server" ID="hdfBultanArchiveID" />
                <asp:HiddenField runat="server" ID="hdfSelectedNews" />
                <asp:HiddenField runat="server" ID="hdfAllowHighlight" />
                <asp:HiddenField runat="server" ID="hdfAllowGroup" />
                <asp:HiddenField runat="server" ID="hdfGalleryNewspaper" />
                <asp:HiddenField runat="server" ID="hdfArz" />
                <asp:HiddenField runat="server" ID="hdfSima" />
                <asp:HiddenField runat="server" ID="hdfAllowrelated" />
                <asp:HiddenField runat="server" ID="hdfAllowNewspaper" />
                <asp:HiddenField runat="server" ID="hdfBultanType" />
                <asp:HiddenField runat="server" ID="hdfAllowChart" />


                <div class="home">
                    <h5 id="loadingText " style="display: none;">در حال آماده سازی گزارش لطفا منتظر بمانید
                    </h5>
                    <div class="container " id="mapnaDiv" style="display: none;">
                        <header>
                            <div id="info">

                                <asp:Literal ID="ltIntroInfo" runat="server"></asp:Literal>

                            </div>
                        </header>
                        <!-- /header -->
                        <div class="main clearfix">
                            <nav id="menu" class="nav">
                                <ul>
                                    <li class="no-margin">
                                        <a href="#digitalbultan" id="digitalbultan" title="‌">
                                            <span class="icon">
                                                <div class="icons flash">
                                                    <img src="/Styles/img/browser.png" />
                                                </div>
                                            </span>
                                            <span>نسخه‌ بولتن دیجیتال</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#sedasima" id="sedasima" title="">
                                            <span class="icon">
                                                <div class="icons html">
                                                    <img src="/Styles/img/film.png" />
                                                </div>
                                            </span>
                                            <span>صدا و سیما</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#arzdolar" id="arzdolar" title="">
                                            <span class="icon">
                                                <div class="icons ">
                                                    <img src="/Styles/img/money.png" />
                                                </div>
                                            </span>
                                            <span>نرخ کالا و ارز</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#pishroozname" title="" id="pishroozname">
                                            <span class="icon">
                                                <div class="icons mobile">
                                                    <img src="/Styles/img/news.png" />
                                                </div>
                                            </span>
                                            <span>پیشخوان مطبوعات</span>
                                        </a>
                                    </li>
                                </ul>
                            </nav>
                            <!-- /menu -->
                        </div>
                        <!-- /main -->
                    </div>
                </div>

                <div class="home2">
                    <asp:HiddenField runat="server" ID="hdfGroups" />
                    <div class="newsContainer">
                        <asp:Literal runat="server" ID="ltNewsHtml"></asp:Literal>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="shadowMenu hidden"></div>
        <section class="fixed-table-of-content appear">
            <em><i class="icon-bookmark-2"></i><span>فهرست</span></em>
            <div>
            </div>
        </section>
    </form>
    <script src="/Scripts/jquery-1.8.1.min.js"></script>
    <script src="/Scripts/jquery.lazy.min.js"></script>
    <script src="/Scripts/localScroll.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.table-of-content, .fixed-table-of-content').localScroll(7000);
            $('.fixed-table-of-content a').click(function () {
                var links = $('.fixed-table-of-content a');
                links.removeClass('selected');
                $(this).addClass('selected');
            });
            $('.fixed-table-of-content em').click(function () {
                $('.shadowMenu').toggleClass('hidden');
                $('.fixed-table-of-content').toggleClass('reveal');
            });

            $('.newsLead').each(function (e) {
                var $this = $(this);
                if ($this.text().length < 1) {
                    $this.hide();
                }

            });
            $('.lazy').each(function (e) {
                //var $this = $(this);
                //if ($this.attr('data-src').length < 1) {
                //    $this.hide();
                //}
            });
            $('.shadowMenu').click(function () {
                $('.shadowMenu').toggleClass('hidden');


            });
            $('.bultanList a').live('click', function () {

                $('.home').hide();
                $('.home2').slideDown();

            });

        });
        $('.fehrestRow  a').click(function (e) {
            var $this = $(this);

            var $newsItem = $('.newsItem[data-id=' + $this.attr('data-newsid') + ']')
            $('html,body').animate({
                scrollTop: $newsItem.offset().top
            }, 800);
            e.preventDefault();
        });
        $(window).ready(function () {
            //اگر مپنا بود
            if ($('#hdfParmin').val() == '2221') {
                $('#loadingText').hide();
                $('#mapnaDiv').show();
            }
            else {
                $('#mapnaDiv').hide();
                $('#loadingText').show();
            }
        });
        $(window).load(function () {
            var elementExistsDivAllNewsPaper = document.getElementById("divAllNewsPaper");
            var elementExistsDivArz = document.getElementById("divArz");
            var elementExistsDivSima = document.getElementById("divSima");
            var elementExistsDivNewsPaper = document.getElementById("divNewsPaper");
            var elementExistsDivChart = document.getElementById("chart1");
            var finalLastList = "";
            var fehrestHtml = "";
            if (elementExistsDivAllNewsPaper != null) {
                fehrestHtml += "<a class='gallery' href='#divAllNewsPaper' >" + " پیشخوان مطبوعات" + "</a>";
            }
            if (elementExistsDivArz != null) {
                fehrestHtml += "<a class='arz' href='#divArz' >" + "نرخ ارز،سکه و طلا" + "</a>";
            }
            if (elementExistsDivSima != null) {
                fehrestHtml += "<a class='sima' href='#divSima' >" + "صدا و سیما" + "</a>";
            }
            if (elementExistsDivNewsPaper != null) {
                fehrestHtml += "<a class='roozname' href='#divNewsPaper' >" + "پیشخوان روزنامه ها" + "</a>";
            }
            if (elementExistsDivChart != null) {
                fehrestHtml += "<a class='roozname' href='#chart1' >" + "نمودار" + "</a>";
            }
            fehrestHtml += "<a class='fehrestRoute' href='#fehrestContainer' >" + "فهرست" + "</a>";

            var pageNumber = 0;
            $('.page footer').each(function () {
                pageNumber += 1;
                $(this).find('span').html(pageNumber);
            }).promise().done(function () {
                $('.fehrestRowLeft .pageNumber').each(function () {

                    var $this = $(this);
                    var thisPageNumber = $('.newsItem[data-id=' + $this.text() + ']').parent().children('footer').text();
                    // console.log($this.text() + "|" + thisPageNumber);
                    $this.html(thisPageNumber);
                });
            }).promise().done(function () {
                try {
                    var groups = $('#<%= hdfGroups.ClientID %>').val().split(',');
                    $.each(groups, function (i) {

                        var rawHtml = "";

                        var keywordNames = [];
                        $('.newsItem[data-group="' + groups[i] + '"]').each(function (i, elm) {

                            var $this = $(this);
                            var keyName = $this.find('.KeywordName').text();
                            var newsTitle = $this.find('.newsTitle').text();
                            var siteTitle = $this.find('.siteTitle').text();

                            var f_pageNumber = $this.parent().find('footer').text();


                            var $thisPageId = $this.attr('id');

                            rawHtml += " <li> <a href='#" + $this.attr('id') + "' rel='bookmark' title='" + newsTitle + " - " + siteTitle + "'>" + newsTitle + " - " + siteTitle + "</a> </li>";

                        }).promise().done(function () {

                            //if (groups[i] == undefined || groups[i] == "") {
                            //    groups[i] = "دیگر اخبار";
                            //}

                            finalLastList += "<h5 class='uncollapse'>" + groups[i] + " </h5><ul class='uncollapse' style='display: none;'>" + rawHtml + "</ul>";


                        });

                    });
                    $('.fixed-table-of-content div').append(fehrestHtml + finalLastList);
                }
                catch (ex) {

                }

            });

            //اگر مپنا بود
            if ($('#hdfParmin').val() == '2221') {

            }
            else {
                $('.home').hide();
                $('#fixedheader').fadeIn();
                $('.fixed-table-of-content').fadeIn();
                $('.home2').slideDown();
            }
            //  $('.home').hide();

            // $('#fixedheader').fadeIn();
            //  $('.fixed-table-of-content').fadeIn();

            //$('.home2').slideDown();

        });
        $('#digitalbultan').click(function () {
            $('.home').hide();
            $('#fixedheader').fadeIn();
            $('.fixed-table-of-content').fadeIn();
            $('.home2').slideDown();
            var $newsItem = $('#fixedheader')
            //var $newsItem = $('#fehrestContainer')
            $('html,body').animate({
                scrollTop: $newsItem.offset().top
            }, 800);
            e.preventDefault();
        });
        $('#sedasima').click(function () {
            $('.home').hide();
            $('#fixedheader').fadeIn();
            $('.fixed-table-of-content').fadeIn();
            $('.home2').slideDown();

            var $newsItem = $('#divSima')
            $('html,body').animate({
                scrollTop: $newsItem.offset().top
            }, 800);
            e.preventDefault();
        });
        $('#arzdolar').click(function () {
            $('.home').hide();
            $('#fixedheader').fadeIn();
            $('.fixed-table-of-content').fadeIn();
            $('.home2').slideDown();

            var $newsItem = $('#divArz')
            $('html,body').animate({
                scrollTop: $newsItem.offset().top
            }, 800);
            e.preventDefault();
        });
        $('#pishroozname').click(function () {
            $('.home').hide();
            $('#fixedheader').fadeIn();
            $('.fixed-table-of-content').fadeIn();
            $('.home2').slideDown();

            var $newsItem = $('#divAllNewsPaper')
            $('html,body').animate({
                scrollTop: $newsItem.offset().top
            }, 800);
            e.preventDefault();
        });
        $('.fixed-table-of-content  a').live('click', function () {
            var target = $(this).attr('href');
            $('.fixed-table-of-content a').removeClass('active');
            $(this).addClass('active');
            $('html,body').animate({
                scrollTop: $($.attr(this, 'href')).offset().top
            }, 800);

            return false;
        });
        $('.fixed-table-of-content h5').live('click', function () {
            var $this = $(this);
            $this.toggleClass("uncollapse");
            $this.next().toggleClass("uncollapse");
            $this.next().slideToggle();
        });
        //$(function () {
        //    $('.lazy').lazy({
        //        //   enableThrottle:false
        //        bind: "event",
        //        delay: 0
        //    });
        //});
        $(window).load(function () {
            $('.lazy').lazy({
                //   enableThrottle:false
                bind: "event",
                delay: 0
            });
        });
    </script>


    <script type="text/javascript">
        var flowVideoPlayer;

        function ResetTv() {
            try {
                flowVideoPlayer.stop();
                flowVideoPlayer.close();
            }
            catch (e) {

            }
        }
        function RunFlowPlayer(videoId) {
            try {

                flowplayer(videoId, "/Scripts/flow/flowplayer-3.2.16.swf", {




                    plugins: {


                        controls: {
                            backgroundGradient: 'none',
                            backgroundColor: '#0a0a0a',
                            scrubber: true,
                            mute: false,
                            autoplay: false,
                            height: 25,
                            fastBackward: false,
                            fastForward: false,
                            slowBackward: false,
                            slowForward: false
                        }
                    },

                    clip: {
                        autoPlay: false,

                        onCuepoint: [5000, function () {
                            var plugin = this.getPlugin("content");


                        }]
                    }
                });

                flowVideoPlayer = $f();

            }
            catch (e) {
            }
        }

        function SetupVideo(id, picture, videopath, width) {



            //id = "'#" + element + "'";

            //var newClip = { 'url': '' + videopath + '', 'autoplay': false };

            //flowVideoPlayer.play(newClip);

        }
        function PlayPlayer(element) {

            var videoID = $(element).attr('id');
            var video = $(element).attr('data-video');
            var videomp4 = $(element).attr('data-video');
            var preview = $(element).attr('data-preview');
            var width = $(element).width();
            var height = $(element).height();

            //jwplayer(videoID).setup({
            //    file: video,
            //    image: preview,
            //    width: width,
            //    height:height,
            //    autostart: 'true',

            //});

            jwplayer(videoID).setup({
                height: height,
                width: width,
                autostart: 'true',
                levels: [
                    { file: video },
                    { file: video },

                ],
                'modes': [
                    { type: 'html5' },
                    { type: 'flash', src: "jwplayer.flash.swf" },
                    { type: 'download' }
                ]
            });

        }



    </script>

    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script>
        function DeleteNewsFromBooltanArchieve(ArchiveId, NewsId) {
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/DeleteBultanArchive",
                data: "{'ArchiveId':'" + ArchiveId + "','NewsId':'" + NewsId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if ((data.d + '').trim() == 'true') {
                        // $('#news_' + NewsId).attr('style', 'display:none;');
                        alert('حذف خبر از بولتن با موفقیت انجام شد');
                        window.location.reload(true);
                    }
                    else {
                        alert('خطا در حذف خبر از بولتن');
                    }
                },
                error: function (msg) {
                    alert('ارور - خطا در حذف خبر');
                }
            });
        }
    </script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/highcharts.js") %>'></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/wordcloud.js") %>'></script>
    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.fancybox.js"></script>
    <link href="/Pages/P-Art/Styles/jquery.fancybox.css" rel="stylesheet" />
    <script type="text/javascript">
        $(".fancyboxGallery").fancybox();
    </script>

    <script>
        newData = [];
        $.ajax({
            type: "POST",
            url: "/Pages/P-Art/Pages/ajax.aspx/ChartBoultanSiteType",
            data: "{'ArchiveId':'" + $('#<%=hdfBultanArchiveID.ClientID%>').val() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                for (var i = 0; i < data.d.length; i++) {

                    newData.push([data.d[i].Name, parseFloat(data.d[i].Value)]);
                }

                Highcharts.chart('chart1', {
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: null,
                        plotShadow: false,
                        type: 'pie',
                        height: 300
                    },
                    xAxis: {
                        type: 'category',
                        rotation: -45
                    },
                    yAxis: {
                        title: {
                            text: 'درصد فراواني اخبار بولتن به تفکيک نوع رسانه'
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
                        text: 'درصد فراواني اخبار بولتن به تفکيک نوع رسانه'
                    },
                    legend: {
                        enabled: true,
                        layout: 'vertical',
                        align: 'top',
                        itemWidth: 120,
                        useHTML: true,
                        labelFormatter: function () {
                            return '<div style="text-align:unset !important;font-size:14px;font-family:B Mitra !important; width:130px;float:left;">' +
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
                                format: '<span style="color:#FFF;text-shadow:none;font-weight:normal;stroke: none;" >{point.percentage:.1f} %</span>',
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
                        name: 'درصد فراواني اخبار بولتن به تفکيک نوع رسانه',
                        data: newData,
                        stake: 'درصد فراواني اخبار بولتن به تفکيک نوع رسانه'

                    }]
                });
            }
        });

    </script>
    <script>
        newData1 = [];
        $.ajax({
            type: "POST",
            url: "/Pages/P-Art/Pages/ajax.aspx/ChartBoultanNews",
            data: "{'ArchiveId':'" + $('#<%=hdfBultanArchiveID.ClientID%>').val() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                for (var i = 0; i < data.d.length; i++) {

                    newData1.push([data.d[i].Name, parseFloat(data.d[i].Value)]);
                }

                Highcharts.chart('chart2', {
                    chart: {
                        type: 'column',
                        height: 350
                    },
                    xAxis: {
                        type: 'category',
                        rotation: -45
                    },
                    yAxis: {
                        title: {
                            text: ' پايگاه هاي خبری'
                        }
                    },
                    stackLabels: {
                        enabled: true,
                        style: {
                            fontWeight: 'bold',
                            color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                        }
                    },
                    title: {
                        text: 'نمودار توزيع فراواني مطالب منتشره در پايگاه هاي خبري'
                    },
                    legend: {
                        enabled: true
                    },
                    tooltip: {
                        pointFormat: '<div style="direction:rtl;text-align:right;min-width:150px;"> <b>{point.y}</b><br/></div>',
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            stacking: 'normal',
                            dataLabels: {
                                enabled: true,
                                color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                                style: {
                                    textShadow: '0 0 3px black, 0 0 3px black'
                                }
                            }
                        }
                    },
                    series: [{
                        type: 'column',
                        name: ' پايگاه هاي خبری',
                        data: newData1,
                        stake: ' پايگاه هاي خبری'

                    }]
                });

            }
        });

    </script>
    <script>
        newData2 = [];
        $.ajax({
            type: "POST",
            url: "/Pages/P-Art/Pages/ajax.aspx/ChartBoultanNewsPaper",
            data: "{'ArchiveId':'" + $('#<%=hdfBultanArchiveID.ClientID%>').val() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                for (var i = 0; i < data.d.length; i++) {

                    newData2.push([data.d[i].Name, parseFloat(data.d[i].Value)]);
                }

                Highcharts.chart('chart3', {
                    chart: {
                        type: 'column',
                        height: 350
                    },
                    xAxis: {
                        type: 'category',
                        rotation: -45
                    },
                    yAxis: {
                        title: {
                            text: ' روزنامه ها'
                        }
                    },
                    stackLabels: {
                        enabled: true,
                        style: {
                            fontWeight: 'bold',
                            color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                        }
                    },
                    title: {
                        text: 'نمودار توزيع فراواني مطالب منتشره در روزنامه ها'
                    },
                    legend: {
                        enabled: true
                    },
                    tooltip: {
                        pointFormat: '<div style="direction:rtl;text-align:right;min-width:150px;"></div>',
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            stacking: 'normal',
                            dataLabels: {
                                enabled: true,
                                color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                                style: {
                                    textShadow: '0 0 3px black, 0 0 3px black'
                                }
                            }
                        }
                    },
                    series: [{
                        type: 'column',
                        name: 'روزنامه ها',
                        data: newData2,
                        stake: 'روزنامه ها'

                    }]
                });

            }
        });

    </script>

</body>
</html>
