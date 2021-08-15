<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Ads_Mohiti_Campain.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Ads_Mohiti_Campain" %>
<!-- Owl Stylesheets -->
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.theme.default.min.css">
<script src="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/owl.carousel.js"></script>

<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingcampain showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
     <a id='campain-close' style="display:none;" href="#Competitors_Ads_Mohiti_Ekran"  class='campain-close'><i class='fa fa-close'></i></a>
    <div id="Competitors_Ads_Advertise_Campain"  style="display:none;" class="content_container_preload_detail_min">
    </div>
</figure>
<asp:HiddenField ID="hddParmin34" runat="server" />
<script type="text/javascript">
    function Load_Competitors_Ads_Advertise_Campain() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin34.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Ads_Advertise_Campain.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    var html = '';
                    var htmlTab = '';
                    var htmlContent = '';
                    var htmlCampain = '';
                    var htmlItem = '';
                    htmlTab += "<ul id='tabs'>";

                    for (var i = 0; i < data.length; i++) {
                        htmlTab += "<li><a id=tab" + data[i].BrandId + ">" + data[i].Brand + "</a></li>";
                        htmlItem = '';
                        htmlCampain += "<div class='campain-body'><h4>کمپین تبلیغاتی رقبا در تبلیغات محیطی</h4>";
                        for (var j = 0; j < data[i].campains.length; j++) {
                            htmlItem += "<div class='item11'><img src='" + data[i].campains[j].ImageName + "' /></div>";
                        }
                        for (var k = 0; k < data[i].campainSubjects.length; k++) {
                            htmlCampain += "<li><i class='fa fa-circle'></i>" + data[i].campainSubjects[k].Title + "</li>";
                        }
                        htmlCampain += "</ul></div>";
                        htmlContent += "<div class='container' id ='tab" + data[i].BrandId + "C'>" + htmlCampain + "<div class='owl-carousel owl-carousel-campain owl-theme'>" + htmlItem + "</div></div>";
                        htmlCampain = "";
                    }
                    htmlTab += "</ul>";


                    html = htmlContent + htmlTab;
                    $('#Competitors_Ads_Advertise_Campain').html(html);

                    $('#tabs li a:not(:first)').addClass('inactive');
                    $('.container').hide();
                    $('.container:first').show();

                    $('#tabs li a').click(function () {
                        var t = $(this).attr('id');
                        if ($(this).hasClass('inactive')) { //this is the start of our condition 
                            $('#tabs li a').addClass('inactive');
                            $(this).removeClass('inactive');

                            $('.container').hide();
                            $('#' + t + 'C').fadeIn('slow');
                        }
                    });
                    $('.owl-carousel-campain').owlCarousel({
                        loop: true,
                        nav: false,
                        autoplay: true,
                        autoPlaySpeed: 5000,
                        items: 4,
                        itemsDesktop: [1199, 4], itemsDesktopSmall: [979, 4]
                    })

                    $('.pageloadingcampain').removeClass('showing');
                }
            });
        }
        catch (ex) {


        }
    }

    $("#campain-close").click(function () {

        $('#Competitors_Ads_Advertise_Campain').slideUp()
        $('#campain-close').css("display", "none");

        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Ads_Mohiti_Ekran").offset().top
        //}, 5000);
    });
</script>


