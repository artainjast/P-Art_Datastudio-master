<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Show_Ads_Radio_AllData.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Show_Ads_Radio_AllData" %>
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.theme.default.min.css">
<script src="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/owl.carousel.js"></script>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingall uc__Show_Ads_Radio_AllData showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
    <a id="radio-close" href="#Competitors_Ads_Radio_AllDataCount" class='radio-close'><i class='fa fa-close'></i></a>
    <div id="Competitors_Show_Ads_Radio_AllDataCount" style="display:none;" class="content_container_preload_detail_min"></div>
</figure>
<asp:HiddenField ID="hddParmin36" runat="server"  />
<script type="text/javascript">
    function Load_Competitors_Show_Ads_Radio_AllData() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin36.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Show_Ads_Radio_AllData.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                
                    var html = '';
                    var htmlTab = '';
                    var htmlContent = '';
                    var htmlItem = '';
                    var htmlbodyRadio = '';
                    htmlTab += "<ul id='tabsR'>";

                    for (var i = 0; i < data.length; i++) {
                        htmlTab += "<li><a id=tabRName" + data[i].ParminID + ">" + data[i].AgName + "</a></li>";
                        htmlItem = '';
                        htmlbodyRadio += "<div class='shahed-radio-body'><i class='fa fa-dot-circle-o' ></i><span>شاهد محتوای رادیویی</span>";
                        for (var j = 0; j < data[i].radioList.length; j++) {
                            htmlItem += "<div class='item11'><div class='radio-pic'><a target='_blanck' href='#'><img src='" + data[i].radioList[j].PosterPath +
                                "' /></a></div><div class='radio-content'><div class='radio-title'><i class='fa fa-paperclip'></i><a target='_blanck' href=''>" + data[i].radioList[j].Title +
                                "</a></div><div class='radio-detail'><span class='NetworkName'><i class='fa fa-tv'></i>" + data[i].radioList[j].Source +
                                "</span><span class='RadioDate'>" + data[i].radioList[j].TTime + "|" + data[i].radioList[j].DDate + "<i class='fa fa-calendar'></i></span></div></div></div>";
                        }
                        htmlbodyRadio += "</div>";
                        htmlContent += "<div class='container containerR' id ='tabRName" + data[i].ParminID + "R'>" + htmlbodyRadio + "<div class='owl-carousel owl-carousel-radio owl-theme'>" + htmlItem + "</div></div>";
                        htmlbodyRadio = "";
                    }
                    htmlTab += "</ul>";


                    html = htmlContent + htmlTab;

                    $('#Competitors_Show_Ads_Radio_AllDataCount').html(html);

                    $('#tabsR li a:not(:first)').addClass('inactive');
                    $('.containerR').hide();
                    $('.containerR:first').show();

                    $('#tabsR li a').click(function () {
                        var t = $(this).attr('id');
                        if ($(this).hasClass('inactive')) { //this is the start of our condition 
                            $('#tabsR li a').addClass('inactive');
                            $(this).removeClass('inactive');

                            $('.containerR').hide();
                            $('#' + t + 'R').fadeIn('slow');
                        }
                    });
                    $('.owl-carousel-radio').owlCarousel({
                        loop: false,
                        nav: false,
                        autoplay: true,
                        autoPlaySpeed: 5000,
                        items: 4,
                        itemsDesktop: [1199, 4], itemsDesktopSmall: [979, 4]
                    })

                    $('.uc__Show_Ads_Radio_AllData').removeClass('showing');
                }
            });
        }
        catch (ex) {


        }
    }
    $("#radio-close").click(function () {

        $('#Competitors_Show_Ads_Radio_AllDataCount').slideToggle()
        $('#radio-close').css("display", "none");

        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Ads_Radio_AllDataCount").offset().top
        //}, 5000);
    });
</script>


