<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Show_PR_Telegram_Mohtava.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Show_PR_Telegram_Mohtava" %>
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.theme.default.min.css">
<script src="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/owl.carousel.js"></script>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingall uc__Show_PR_Telegram_Mohtava showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
    <a id="telegram-close" href="#Competitors_Telegram_Mohtava" class='telegram-close'><i class='fa fa-close'></i></a>
    <div id="Competitors_Show_PR_Telegram_Mohtava" style="display:none;" class="content_container_preload_detail_min">
    </div>
</figure>
<asp:HiddenField ID="hddParmin41" runat="server" />
<script type="text/javascript">

    function Load_Competitors_show_PR_Telegram_Mohtava() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin41.ClientID %>").val();
           try {
               $.ajax({
                   type: "POST",
                   url: "/Services/Part_Competitors_Show_Telegram_Mohtava.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                   data: "",
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (data) {
                       var html = '';
                       var htmlTab = '';
                       var htmlContent = '';
                       var htmlItem = '';
                       var htmlbodyTelegram = '';
                       htmlTab += "<ul id='tabsTLG'>";

                       for (var i = 0; i < data.length; i++) {
                           htmlTab += "<li><a id=tabTLGName" + data[i].KeywordID + ">" + data[i].Keyword + "</a></li>";
                           htmlItem = '';
                           htmlbodyTelegram += "<div class='shahed-telegram-body'><i class='fa fa-dot-circle-o' ></i><span>شاهد محتوای شبکه اجتماعی تلگرام</span>";
                           for (var j = 0; j < data[i].telegramList.length; j++) {
                               htmlItem += "<div class='item11'><div class='telegram-text'><a target='_blanck' href='#'><i class='fa fa-telegram telegramBlue'></i><span>" +
                                   data[i].telegramList[j].MessageTextShort +
                                   "</span></a></div><div class='telegram-icons'><span class='heart'>" + data[i].telegramList[j].ViewCount +
                                   "<i class='fa fa-eye'></i></span></div><div class='telegram-detail'><span class='username'><i class='fa fa-user'></i>" +
                                   data[i].telegramList[j].ChannelTitle + "</span><span class='keyword'><i class='fa fa-key'></i>" + data[i].telegramList[j].keywordTitle +
                                   "</span><span class='TelegramDate'>" + data[i].telegramList[j].MessageTime + "|" + data[i].telegramList[j].MessageDate + "<i class='fa fa-calendar'></i></span></div></div>";
                           }
                           htmlbodyTelegram += "</div>";
                           htmlContent += "<div class='container containerTLG' id ='tabTLGName" + data[i].KeywordID + "TLG'>" + htmlbodyTelegram + "<div class='owl-carousel owl-carousel-telegram owl-theme'>" + htmlItem + "</div></div>";
                           htmlbodyTelegram = "";
                       }
                       htmlTab += "</ul>";


                       html = htmlContent + htmlTab;

                       $('#Competitors_Show_PR_Telegram_Mohtava').html(html);

                       $('#tabsTLG li a:not(:first)').addClass('inactive');
                       $('.containerTLG').hide();
                       $('.containerTLG:first').show();

                       $('#tabsTLG li a').click(function () {
                           var t = $(this).attr('id');
                           if ($(this).hasClass('inactive')) { //this is the start of our condition 
                               $('#tabsTLG li a').addClass('inactive');
                               $(this).removeClass('inactive');

                               $('.containerTLG').hide();
                               $('#' + t + 'TLG').fadeIn('slow');
                           }
                       });
                       $('.owl-carousel-telegram').owlCarousel({
                           loop: true,
                           nav: false,
                           items: 4,
                           autoplay: true,
                           autoPlaySpeed:4000,
                           itemsDesktop: [1199, 4], itemsDesktopSmall: [979, 4]
                       })
                       $('.uc__Show_PR_Telegram_Mohtava').removeClass('showing');
                   }
               });
           }
           catch (ex) {


           }
       }

    $("#telegram-close").click(function () {
        $('#Competitors_Show_PR_Telegram_Mohtava').slideToggle()
        $('#telegram-close').css("display", "none");

        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Telegram_Mohtava").offset().top
        //}, 5000);
    });
</script>


