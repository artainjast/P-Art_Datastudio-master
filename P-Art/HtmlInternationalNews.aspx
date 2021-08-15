<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlInternationalNews.aspx.cs" Inherits="P_Art.HtmlInternationalNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/htmlGroupBultan.css?ver=10.8" rel="stylesheet" />
    <style type="text/css" media="print">
        .fixed-table-of-content {
            display: none !important;
        }
        #fixedheader{
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
                    <%--  <asp:Repeater runat="server" ID="rptNimta">
                        <HeaderTemplate>
                            <div class="nimtaContainer">
                        </HeaderTemplate>
                        <ItemTemplate>

                            <div class="nimtaItem " id='nimta<%# Container.ItemIndex %>'>
                                <a href='<%# Eval("OriginalPath") %>' data-src='<%# Eval("OriginalPath") %>' class="fancybox" rel="group">
                                    <i class="">مشاهده کیفیت بالا</i>
                                    <img class="lazy" src="lazy.gif" data-src='<%# Eval("LargePath") %>' />

                                    <span class="nimtaText"><%# PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("Title")) %></span>
                                </a>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></div></FooterTemplate>
                    </asp:Repeater>--%>
                    <asp:HiddenField runat="server" ID="hdfGroups" />



                    <div class="newsContainer">
                        <asp:Literal runat="server" ID="ltNewsHtml"></asp:Literal>
                    </div>

                    <%--     <div class="videoContainer">



                        <asp:Repeater ID="rptVideo" runat="server">
                            <ItemTemplate>
                                <div class="videoSliderItem" id='videoItem<%# Container.ItemIndex %>'>
                                    <a class="videoPlayer" id='video<%# Container.ItemIndex %>' onclick='PlayPlayer(this)' href='#video' data-id='<%# Eval("MovieID") %>' data-video='<%#  Eval("VideoPath") %>' data-preview='<%#  Eval("PosterPath") %>'>
                                        <img class="videoPic" src="<%#  Eval("PosterPath") %>" />
                                        <img class="play" src="/playButton.png" />

                                    </a>
                                    <h6>
                                        <%# Eval("Title") %>
                                    </h6>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <a id="slider_prev"></a>
                        <a id="slider_next"></a>
                    </div>--%>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="shadowMenu hidden"></div>
        <section class="fixed-table-of-content appear">
            <em><i class="icon-bookmark-2"></i><span>فهرست</span></em>
            <div>
                <%--  <h5>پیشخوان روزنامه ها</h5>
                            <ul>
                                <li></li>
                            </ul>--%>
            </div>
        </section>
    </form>
    <script src="/Scripts/jquery-1.8.1.min.js"></script>
    <script src="/Scripts/jquery.lazy.min.js"></script>
    <script src="/Scripts/localScroll.js"></script>
    <%--  <script src="Scripts/flow/flowplayer-3.2.12.min.js"></script>--%>
    <%-- <script src="/Pages/P-Art/Scripts/jwplayer.js"></script>--%>
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

                            rawHtml += " <li> <a href='#" + $this.attr('id') + "' rel='bookmark' title='" + newsTitle + " - " + siteTitle + "'>" + newsTitle + " - " + siteTitle  + "</a> </li>";

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
    <%--  <script src="/Pages/P-Art/Scripts/jwplayer.js" type="text/javascript"></script>--%>

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
    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.fancybox.js"></script>
    <link href="/Pages/P-Art/Styles/jquery.fancybox.css" rel="stylesheet" />
    <script type="text/javascript">
        $(".fancyboxGallery").fancybox();
    </script>
</body>
</html>
