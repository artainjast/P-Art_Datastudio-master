<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Show_Ads_Video_AllData.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Show_Ads_Video_AllData" %>

<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.theme.default.min.css">
<script src="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/owl.carousel.js"></script>

<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingall uc__Show_Ads_Video_AllData showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
    <a  id="video-close" href="#Competitors_Ads_Video_AllDataCount" class='video-close'><i class='fa fa-close'></i></a>
    <div id="Competitors_Show_Ads_Video_AllDataCount" style="display:none;" class="content_container_preload_detail_min">
    
    </div>
</figure>
<asp:HiddenField ID="hddParmin35" runat="server" />
<script type="text/javascript">

    function Load_Competitors_show_Ads_Video_AllDataCount() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin35.ClientID %>").val();
           try {
               $.ajax({
                   type: "POST",
                   url: "/Services/Part_Competitors_Show_Ads_Video_AllData.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                   data: "",

                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (data) {
                       var html = '';
                       var htmlTab = '';
                       var htmlContent = '';
                       var htmlItem = '';
                       var htmlbodyVideo = '';
                       htmlTab += "<ul id='tabsV'>";

                       for (var i = 0; i < data.length; i++) {
                           htmlTab += "<li><a id=tabVName" + data[i].ParminID + ">" + data[i].AgName + "</a></li>";
                           htmlItem = '';
                           htmlbodyVideo += "<div class='shahed-video-body'><i class='fa fa-dot-circle-o' ></i><span>شاهد محتوای تلویزیونی</span>";
                           for (var j = 0; j < data[i].videoList.length; j++) {
                               htmlItem += "<div class='item11'><div class='video-pic'><a target='_blanck' href='#'><img src='" + data[i].videoList[j].PosterPath +
                                   "' /></a></div><div class='video-content'><div class='video-title'><i class='fa fa-paperclip'></i><a target='_blanck' href=''>" + data[i].videoList[j].Title +
                                   "</a></div><div class='video-detail'><span class='NetworkName'><i class='fa fa-tv'></i>" + data[i].videoList[j].NetworkName +
                                   "</span><span class='VideoDate'>" + data[i].videoList[j].PlayTime + "|" + data[i].videoList[j].VideoDate+"<i class='fa fa-calendar'></i></span></div></div></div>";
                           }
                           htmlbodyVideo += "</div>";
                           htmlContent += "<div class='container containerV' id ='tabVName" + data[i].ParminID + "V'>" + htmlbodyVideo + "<div class='owl-carousel owl-carousel-video owl-theme'>" + htmlItem + "</div></div>";
                           htmlbodyVideo = "";
                       }
                       htmlTab += "</ul>";


                       html = htmlContent + htmlTab;

                       $('#Competitors_Show_Ads_Video_AllDataCount').html(html);

                       $('#tabsV li a:not(:first)').addClass('inactive');
                       $('.containerV').hide();
                       $('.containerV:first').show();

                       $('#tabsV li a').click(function () {
                           var t = $(this).attr('id');
                           if ($(this).hasClass('inactive')) { //this is the start of our condition 
                               $('#tabsV li a').addClass('inactive');
                               $(this).removeClass('inactive');

                               $('.containerV').hide();
                               $('#' + t + 'V').fadeIn('slow');
                           }
                       });
                       $('.owl-carousel-video').owlCarousel({
                           loop: true,
                           nav: false,
                           autoplay: true,
                           autoPlaySpeed: 5000,
                           items: 4,
                           itemsDesktop: [1199, 4], itemsDesktopSmall: [979, 4]
                       })

                       $('.uc__Show_Ads_Video_AllData').removeClass('showing');
                   }
               });
           }
           catch (ex) {


           }
       }
    $("#video-close").click(function () {
        $('#Competitors_Show_Ads_Video_AllDataCount').slideToggle()
        $('#video-close').css("display", "none");

        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Ads_Video_AllDataCount").offset().top
        //}, 5000);
    });
</script>


