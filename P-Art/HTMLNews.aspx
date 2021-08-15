<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLNews.aspx.cs" Inherits="P_Art.HTMLNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/htmlBultan.css?ver=3.2" rel="stylesheet" />
    <style type="text/css" media="print">
        .fixed-table-of-content {
            display: none;
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
                <asp:HiddenField runat="server" ID="hdfParmin" />

                <div class="home">
                    <div class="logo">
                        <a class="">
                            <img src="/tg-logo.png" />
                        </a>
                    </div>
                    <h2>گروه مالی گردشگری در رسانه ها
                    </h2>
                    <h4>
                        <asp:Literal runat="server" ID="ltNewsDate"></asp:Literal></h4>
                    <h5>
                        <asp:Literal runat="server" ID="ltNewsDateFull"></asp:Literal></h5>
                    <div class="bultanList">
                        <ul>
                            <li>
                                <a href="#html">نسخه HTML</a></li>
                            <li>
                                <a href="#mobile">نسخه موبایل</a></li>
                        </ul>
                    </div>
                </div>


                <div class="home2">
                    <asp:Repeater runat="server" ID="rptNimta">
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
                    </asp:Repeater>
                    <asp:HiddenField runat="server" ID="hdfGroups" />
                    <asp:Repeater runat="server" ID="rptNews">
                        <HeaderTemplate>
                            <div class="newsContainer">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="newsItem " data-group='<%# Eval("GroupName") %>' id='news<%# Container.ItemIndex %>'>
                                <div class="GroupName"><%# PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("GroupName")) %></div>
                                <div class="newsTime">
                                    <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                </div>
                                <div class="KeywordName"><%# PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("KeywordName")) %></div>
                                <div class="siteTitle"><%# Eval("SiteTitle") %></div>
                                <div class="newsTitle"><a href='<%# (Eval("NewsLink")) %>' target="_blank"><%# PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("NewsTitle")) %></a></div>
                                <div class="newsPicture">
                                    <a>
                                        <img class="lazy" src="lazy.gif" data-src='<%# Eval("NewsPicture") %>' /></a>
                                </div>
                                <div class="newsLead"><%# PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("NewsLead")) %></div>
                                <div class="newsBody"><%# PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("NewsBody")) %></div>
                                <div class="newsLink">
                                    <a target="_blank" href='<%# (Eval("NewsLink")) %>'>شاهد خبر</a>

                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></div></FooterTemplate>
                    </asp:Repeater>

                    <div class="videoContainer">



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
                    </div>


                    <section class="fixed-table-of-content appear">
                        <em><i class="icon-bookmark-2"></i><span>فهرست</span></em>
                        <div>
                            <h5>پیشخوان روزنامه ها</h5>
                            <ul>
                                <li></li>
                            </ul>
                        </div>

                    </section>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="shadowMenu hidden"></div>

    </form>
    <script src="Scripts/jquery-1.8.1.min.js"></script>
    <script src="Scripts/jquery.lazy.min.js"></script>
    <script src="Scripts/localScroll.js"></script>
    <%--  <script src="Scripts/flow/flowplayer-3.2.12.min.js"></script>--%>
    <script src="/Pages/P-Art/Scripts/jwplayer.js"></script>
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
                var $this = $(this);
                if ($this.attr('data-src').length < 1) {
                    $this.hide();
                }
            });
            $('.shadowMenu').click(function () {
                $('.shadowMenu').toggleClass('hidden');
                $('.fixed-table-of-content').toggleClass('reveal');

            });
            $('.bultanList a').live('click', function () {

                $('.home').hide();
                $('.home2').slideDown();

            });
        });

        $('.fixed-table-of-content ul a').live('click', function () {
            var target = $(this).attr('href');
            $('.fixed-table-of-content ul a').removeClass('active');
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
        $(function () {
            $('.lazy').lazy();
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
        $(window).load(function () {


            //  SetChartCenter(DoCenterFinal)





            var nimtaHtml = "";
            $('.nimtaItem').each(function (i, elm) {
                var rawHtml = "";
                var $this = $(this);

                var $thisPageId = $this.attr('id');
                rawHtml = " <li> <a href='#" + $this.attr('id') + "' rel='bookmark' title='" + $this.find('.nimtaText').text() + "'>" + $this.find('.nimtaText').text() + "</a> </li>";
                nimtaHtml += rawHtml;


            }).promise().done(function () {
                var finalLastList = "";
                finalLastList += "<h5 class='uncollapse'>پیشخوان جراید </h5><ul class='uncollapse' style='display: none;'>" + nimtaHtml + "</ul>";

                $('.fixed-table-of-content div').html(finalLastList);


            });

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



                            var $thisPageId = $this.attr('id');

                            rawHtml += " <li> <a href='#" + $this.attr('id') + "' rel='bookmark' title='" + newsTitle + " - " + siteTitle + "'>" + newsTitle + " - " + siteTitle + "</a> </li>";


                        }).promise().done(function () {
                            var finalLastList = "";
                            if (groups[i] == undefined || groups[i] == "") {
                                groups[i] = "دیگر اخبار";
                            }
                            finalLastList += "<h5 class='uncollapse'>" + groups[i] + " </h5><ul class='uncollapse' style='display: none;'>" + rawHtml + "</ul>";

                            $('.fixed-table-of-content div').append(finalLastList);


                        });

                    });
                }
            catch (ex) {

            }
            rawHtml = "";
            try {
                $('.videoSliderItem').each(function (i, elm) {

                    var $this = $(this);

                    var title = $this.find('h6').text();
                    var pic = $this.attr('data-preview');
                    var video = $this.attr('data-video');
                    var width = $this.width();


                    var $thisPageId = $this.attr('id');

                    rawHtml += " <li> <a href='#" + $this.attr('id') + "' rel='bookmark' title='" + title + "'>" + title + "</a> </li>";
                    //SetupVideo($thisPageId, pic, video, width);

                }).promise().done(function () {
                    var finalLastList = "";

                    finalLastList += "<h5 class='uncollapse'>صداسیما</h5><ul class='uncollapse' style='display: none;'>" + rawHtml + "</ul>";

                    $('.fixed-table-of-content div').append(finalLastList);


                });
            }
            catch (e) {

            }

        });

            function DoCenterFinal() {

                $('.group-box').css({ 'display': 'block' });
            }
    </script>

    <script src="/Pages/P-Art/Scripts/jquery.mousewheel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.fancybox.js"></script>
    <link href="/Pages/P-Art/Styles/jquery.fancybox.css" rel="stylesheet" />
    <script type="text/javascript">
        $(".fancybox").fancybox();
    </script>

</body>
</html>
