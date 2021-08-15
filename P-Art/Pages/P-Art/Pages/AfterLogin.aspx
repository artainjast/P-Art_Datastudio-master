<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfterLogin.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.AfterLogin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery-ui.css" />
    <link href="/Pages/P-Art/Styles/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/StyleV2.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <%--<script src="http://code.jquery.com/jquery-1.10.2.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <%-- <script src="https://code.jquery.com/jquery-migrate-1.4.1.js" type="text/javascript"></script>--%>
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/Pages/P-Art/Styles/bootstrap/js/bootstrap.min.js"></script>
    <script src="/Pages/P-Art/owl.carousel.js"></script>
    <link href="/Pages/P-Art/Styles/owl.carousel.css" rel="stylesheet" />
    <link href="/Pages/P-Art/Styles/owl.theme.css" rel="stylesheet" />

</head>
<body>
    <form runat="server">

        <script>
            $(document).ready(function () {

                $("#owl-demo").owlCarousel({

                    navigation: false, // Show next and prev buttons

                    slideSpeed: 300,
                    paginationSpeed: 400,
                    autoPlay: 3000,
                    paginationSpeed: 400,
                    goToFirst: true,
                    items: 1,
                    itemsDesktop: false,
                    itemsDesktopSmall: false,
                    itemsTablet: false,
                    itemsMobile: false

                });

                $("#owl-demoNimta").owlCarousel({

                    navigation: false, // Show next and prev buttons

                    slideSpeed: 400,
                    paginationSpeed: 400,
                    autoPlay: 4000,
                    paginationSpeed: 400,
                    goToFirst: true,
                    items: 1,
                    itemsDesktop: false,
                    itemsDesktopSmall: false,
                    itemsTablet: false,
                    itemsMobile: false

                });
                var canvas = document.getElementById("canvas");
                var ctx = canvas.getContext("2d");
                var radius = canvas.height / 2;
                ctx.translate(radius, radius);
                radius = radius * 0.90
                setInterval(drawClock, 1000);

                function drawClock() {
                    drawFace(ctx, radius);
                    drawNumbers(ctx, radius);
                    drawTime(ctx, radius);
                }

                function drawFace(ctx, radius) {
                    var grad;
                    ctx.beginPath();
                    ctx.arc(0, 0, radius, 0, 2 * Math.PI);
                    ctx.fillStyle = 'white';
                    ctx.fill();
                    grad = ctx.createRadialGradient(0, 0, radius * 0.95, 0, 0, radius * 1.05);
                    grad.addColorStop(0, '#333');
                    grad.addColorStop(0.5, 'white');
                    grad.addColorStop(1, '#333');
                    ctx.strokeStyle = grad;
                    ctx.lineWidth = radius * 0.1;
                    ctx.stroke();
                    ctx.beginPath();
                    ctx.arc(0, 0, radius * 0.1, 0, 2 * Math.PI);
                    ctx.fillStyle = '#333';
                    ctx.fill();
                }

                function drawNumbers(ctx, radius) {
                    var ang;
                    var num;
                    ctx.font = radius * 0.15 + "px arial";
                    ctx.textBaseline = "middle";
                    ctx.textAlign = "center";
                    for (num = 1; num < 13; num++) {
                        ang = num * Math.PI / 6;
                        ctx.rotate(ang);
                        ctx.translate(0, -radius * 0.85);
                        ctx.rotate(-ang);
                        ctx.fillText(num.toString(), 0, 0);
                        ctx.rotate(ang);
                        ctx.translate(0, radius * 0.85);
                        ctx.rotate(-ang);
                    }
                }

                function drawTime(ctx, radius) {
                    var now = new Date();
                    var hour = now.getHours();
                    var minute = now.getMinutes();
                    var second = now.getSeconds();
                    //hour
                    hour = hour % 12;
                    hour = (hour * Math.PI / 6) +
                    (minute * Math.PI / (6 * 60)) +
                    (second * Math.PI / (360 * 60));
                    drawHand(ctx, hour, radius * 0.5, radius * 0.07);
                    //minute
                    minute = (minute * Math.PI / 30) + (second * Math.PI / (30 * 60));
                    drawHand(ctx, minute, radius * 0.8, radius * 0.07);
                    // second
                    second = (second * Math.PI / 30);
                    drawHand(ctx, second, radius * 0.9, radius * 0.02);
                }

                function drawHand(ctx, pos, length, width) {
                    ctx.beginPath();
                    ctx.lineWidth = width;
                    ctx.lineCap = "round";
                    ctx.moveTo(0, 0);
                    ctx.rotate(pos);
                    ctx.lineTo(0, -length);
                    ctx.stroke();
                    ctx.rotate(-pos);
                }

            });
        </script>



        <div id="main-container" class="container">
            <div id="wrapper">
                <header>
                    <!-- ## start header ## -->
                    <div id="header">
                        <div class="row">
                            <div class="span12 col logo" style="top: 40px; left: 184.5px; position: static; opacity: 0.8;">
                                <div class="logotop">
                                    <img src="/Pages/P-Art/Images/payeshlogo.png" />
                                    <h1>پایش مدیا</h1>
                                </div>
                                <div class="logobottom">
                                    <p>آژانس تخصصی مدیا مانیتورینگ</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- ## end header ## -->
                </header>
                <section>
                    <div id="section">
                        <!-- ## start ROW 1 ## -->
                        --<div class="row row-style">
                            <div id="counter">
                                <div id="days" class="span2 col r1c2" style="top: 144px; left: 504.5px; position: static; opacity: 0.8;">
                                    <i class="fa fa-3x fa-calendar"></i>
                                    <span id="lblDate" runat="server">1396</span>
                                </div>
                                <div id="seconds" class="span2 col r1c5" style="top: 144px; left: 664.5px; position: static; opacity: 0.8;">
                                    <span>ارتباط با ما</span>
                                    <span>22676707<i class="fa fa-phone"></i></span>
                                    <span>22676708 <i class="fa fa-fax"></i></span>
                                </div>

                                <div id="minutes" class="span2 col r1c4" style="top: 144px; left: 824.5px; position: static; opacity: 0.8;">
                                    <canvas id="canvas" width="100" height="100"></canvas>
                                    <div><span id="lblToday" runat="server">شنبه</span></div>
                                    <div><span id="lblWeekdayMonth" runat="server">بیست و سوم اسفند</span></div>
                                </div>
                                <div id="hours" class="span2 col r1c3" style="top: 144px; left: 984.5px; position: static; opacity: 0.8;">
                                    <div class="currency-header">
                                        <h4>نرخ سکه و ارز (ریال)</h4>
                                    </div>
                                    <ul>
                                        <li><span class="currency">دلار</span><span class="currencyValue" id="lblDolar" runat="server">4250</span> </li>
                                        <li><span class="currency">یورو</span><span class="currencyValue" id="lblEuro" runat="server">4250</span></li>
                                        <li><span class="currency">سکه تمام</span><span class="currencyValue" id="lblSeke" runat="server">4250</span></li>
                                        <li><span class="currency">نیم سکه</span><span class="currencyValue" id="lblNim" runat="server">4250</span></li>
                                        <li><span class="currency">ربع سکه</span><span class="currencyValue" id="lblRob" runat="server">4250</span></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="span4 col r1c1" style="top: 144px; left: 184.5px; position: static; opacity: 0.8;">
                                <div id="owl-demoNimta" class="owl-carousel owl-theme slide">
                                    <asp:Repeater ID="rptNimta" runat="server">
                                        <ItemTemplate>
                                            <div class="item">
                                                <asp:Image ID="imgNimta" runat="server" ToolTip='<%#Eval("Title") %>' ImageUrl='<%#Eval("PreviewPath") %>' />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>

                        </div>
                        <!-- ## end ROW 1 ## -->

                        <!-- ## start ROW 2 ## -->
                        <div class="row row-style">
                            <!-- ## SUBSCRIBE TILE begins here ## -->
                            <div class="span8 col r2c1" style="top: 304px; left: 184.5px; position: static; opacity: 0.8;">
                                <div class="subscribe-container">
                                    <div class="row-fluid">
                                        <div class="span10 offset1">
                                            <form id="frm_subscribe" name="frm_subscribe" action="/" method="post" novalidate="novalidate">
                                                <div class="row-fluid">
                                                    <div class="control-group">
                                                        <label class="control-label" for="txtSubscribeEmail">جهت ارتباط با ما ایمیل خود را وارد کرده و دکمه ارسال را  بزنید. ما در اسرع وقت با شما در ارتباط خواهیم بود.</label>
                                                        <div class="controls">
                                                            <input class="span10 input-subscribe required email" id="txtSubscribeEmail" name="txtSubscribeEmail" placeholder="enter your e-mail to subscribe" type="text" />
                                                            <button id="btn_subscribe" class="btn btn-submit" type="button">ارسال</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- ## SUBSCRIBE TILE ends here ## -->

                            <!-- ## ABOUT US TILE begins here ## -->
                            <div class="span4 col r2c2" data-target="#about-modal" style="top: 304px; left: 824.5px; position: static; opacity: 0.8;">
                                <div class="about-us-after">
                                    <i class="fa fa-3x fa-user"></i>
                                    <div style="text-align: center"><span>خوش آمدید</span></div>
                                    <div style="text-align: center">
                                        <span id="lblUser" runat="server"></span>
                                    </div>
                                </div>
                            </div>
                            <!-- ## ABOUT US TILE ends here ## -->
                        </div>
                        <!-- ## end ROW 2 ## -->

                        <!-- ## start ROW 3 ## -->
                        <div class="row row-style">
                            <!-- ## PROGRESS TILE begins here ## -->
                            <div class="span4 col r3c1 fa fa-3x fa-youtube-play" style="top: 464px; left: 184.5px; position: static; opacity: 0.8;">
                                <a id="linkSima" runat="server" title="رسانه های دیداری و شنیداری">
                                    <span class="button-title">رسانه های دیداری و شنیداری </span>
                                </a>

                            </div>
                            <!-- ## PROGRESS TILE ends here ## -->

                            <!-- ## OUR TEAM TILE begins here ## -->
                            <div class="span4 col r3c2 fa fa-3x fa-newspaper-o" data-target="#our-team-modal" style="top: 464px; left: 504.5px; position: static; opacity: 0.8;">
                                <a id="linkNews" runat="server" title="مطبوعات و خبرگزاری ها">
                                    <span class="button-title">مطبوعات و خبرگزاری ها</span></a>
                            </div>
                            <!-- ## OUR TEAM TILE ends here ## -->

                            <!-- ## TEAM MEMBERS SLIDER TILE begins here ## -->
                            <div class="span2 col r3c3" style="top: 464px; left: 824.5px; position: static; opacity: 0.8;">
                                <div id="owl-demo" class="owl-carousel owl-theme slide">
                                    <div class="item">
                                        <img src="/Pages/P-Art/Images/ads/ads1.jpg" />

                                    </div>
                                    <div class="item">
                                        <img src="/Pages/P-Art/Images/ads/ads2.jpg" />
                                    </div>
                                    <div class="item">
                                        <img src="/Pages/P-Art/Images/ads/ads3.jpg" />
                                    </div>
                                </div>
                            </div>
                            <!-- ## TEAM MEMBERS SLIDER TILE ends here ## -->

                            <!-- ## CONTACT US TILE begins here ## -->
                            <div class="span2 col r3c4 fa fa-3x fa-globe" data-target="#contact-us-modal" style="top: 464px; left: 984.5px; position: static; opacity: 0.8;">
                                <a id="linkOtherNation" runat="server">
                                    <span class="button-title">رسانه های بین الملل </span></a>
                            </div>
                            <!-- ## CONTACT US TILE ends here ## -->
                        </div>
                        <!-- ## end ROW 3 ## -->

                        <!-- ## start ROW 4 ## -->
                        <div class="row row-style">
                            <div id="facebook-page" class="span2 col r4c1 pic-icon fa fa-3x fa-telegram" style="top: 624px; left: 184.5px; position: static; opacity: 0.8;">
                                <a id="linkTelegram" runat="server">
                                    <span class="button-title">تلگرام</span></a>
                            </div>
                            <div id="twitter-page" class="span2 col r4c2 pic-icon fa fa-3x fa-twitter" style="top: 624px; left: 344.5px; position: static; opacity: 0.8;">
                                <a id="linkTwitter" runat="server">
                                    <span class="button-title">توئیتر</span></a>
                            </div>
                            <div id="googleplus-page" class="span2 col r4c3 pic-icon fa fa-3x fa-sort-amount-desc" style="top: 624px; left: 504.5px; position: static; opacity: 0.8;">
                                <a id="linkTamarkoz" runat="server">
                                    <span class="button-title">تمرکز رسانه ها </span></a>
                            </div>
                            <div id="pinterest-page" class="span2 col r4c4 pic-icon fa fa-3x fa-sitemap" style="top: 624px; left: 664.5px; position: static; opacity: 0.8;">
                                <a id="linkJaryan" runat="server">
                                    <span class="button-title">شناسایی جریان های خبری</span></a>
                            </div>
                            <div id="youtube-page" class="span2 col r4c5 pic-icon fa fa-3x fa-pie-chart" style="top: 624px; left: 824.5px; position: static; opacity: 0.8;">
                                <a id="linkTahlil" runat="server" title="تحلیل محتوا">
                                    <span class="button-title">تحلیل محتوا</span></a>
                            </div>
                            <div id="vimeo-page" class="span2 col r4c6 pic-icon fa fa-3x fa-tv" style="top: 624px; left: 984.5px; position: static; opacity: 0.8;">
                                <a id="linkTv" runat="server">
                                    <span class="button-title">تلویزیون پایش</span></a>
                            </div>
                        </div>
                        <!-- ## end ROW 4 ## -->
                    </div>
                </section>
                <footer>
                    <!-- ## start footer ## -->
                    <div id="footer">
                        <div class="row">
                            <div class="span12 col" style="top: 794px; left: 184.5px; position: static; opacity: 0.8;">
                                © 2017 Payeshmedia.ir -  All rights reserved.
                            </div>
                        </div>
                    </div>
                    <!-- ## end footer ## -->
                </footer>
            </div>
        </div>


    </form>


</body>
</html>
