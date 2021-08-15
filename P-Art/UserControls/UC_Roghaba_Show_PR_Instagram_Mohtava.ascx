<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Show_PR_Instagram_Mohtava.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Show_PR_Instagram_Mohtava" %>
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.theme.default.min.css">
<script src="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/owl.carousel.js"></script>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingall uc__Show_PR_Instagram_Mohtava showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
    <a id='instagram-close' style="display:none;" href="#Competitors_Instagram_Mohtava" class='instagram-close'><i class='fa fa-close'></i></a>
    <div id="Competitors_Show_PR_Instagram_Mohtava" style="display:none;" class="content_container_preload_detail_min">
    </div>
</figure>
<asp:HiddenField ID="hddParmin40" runat="server" />
<script type="text/javascript">

    function Load_Competitors_show_PR_Instagram_Mohtava() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin40.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Show_Instagram_Mohtava.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var html = '';
                    var htmlTab = '';
                    var htmlContent = '';
                    var htmlItem = '';
                    var htmlbodyInstagram = '';
                    htmlTab += "<ul id='tabsINS'>";

                    for (var i = 0; i < data.length; i++) {
                        htmlTab += "<li><a id=tabINSName" + data[i].KeywordID + ">" + data[i].Keyword + "</a></li>";
                        htmlItem = '';
                        htmlbodyInstagram += "<div class='shahed-instagram-body'><i class='fa fa-dot-circle-o' ></i><span>شاهد محتوای شبکه اجتماعی اینستاگرام</span>";
                        for (var j = 0; j < data[i].instagramList.length; j++) {
                            htmlItem += "<div class='item11'><div class='insta-image'><a href='" + data[i].instagramList[j].PostUrl +
                                "' ><img src='" + data[i].instagramList[j].DisplayUrl + "' /></a></div><div class='instagram-text'><a target='_blanck' href='#'><i class='fa fa-instagram instagramMaroon'></i><span>" +
                                data[i].instagramList[j].CaptionTextShort +
                                "</span></a></div><div class='instagram-icons'><span class='heart'><i class='fa fa-comment'></i>" + data[i].instagramList[j].CommentsCount +
                                "</span><span class='InstagramDate'>" + data[i].instagramList[j].Time + "|" + data[i].instagramList[j].Date + "<i class='fa fa-calendar'></i></span></div><div class='instagram-detail'><span class='username'><i class='fa fa-user'></i>" +
                                data[i].instagramList[j].UserName + "</span><span class='keyword'><i class='fa fa-key'></i>" + data[i].instagramList[j].keywordTitle +
                                "</span></div></div>";
                        }
                        htmlbodyInstagram += "</div>";
                        htmlContent += "<div class='container containerINS' id ='tabINSName" + data[i].KeywordID + "INS'>" + htmlbodyInstagram + "<div class='owl-carousel owl-carousel-instagram owl-theme'>" + htmlItem + "</div></div>";
                        htmlbodyInstagram = "";
                    }
                    htmlTab += "</ul>";


                    html = htmlContent + htmlTab;

                    $('#Competitors_Show_PR_Instagram_Mohtava').html(html);

                    $('#tabsINS li a:not(:first)').addClass('inactive');
                    $('.containerINS').hide();
                    $('.containerINS:first').show();

                    $('#tabsINS li a').click(function () {
                        var t = $(this).attr('id');
                        if ($(this).hasClass('inactive')) { //this is the start of our condition 
                            $('#tabsINS li a').addClass('inactive');
                            $(this).removeClass('inactive');

                            $('.containerINS').hide();
                            $('#' + t + 'INS').fadeIn('slow');
                        }
                    });
                    $('.owl-carousel-instagram').owlCarousel({
                        loop: true,
                        nav: false,
                        autoplay: true,
                        autoPlaySpeed: 5000,
                        items: 4,
                        itemsDesktop: [1199, 4], itemsDesktopSmall: [979, 4]
                    })
                    $('.uc__Show_PR_Instagram_Mohtava').removeClass('showing');
                }
            });
        }
        catch (ex) {


        }
    }

    $("#instagram-close").click(function () {

        $('#Competitors_Show_PR_Instagram_Mohtava').slideToggle()
        $('#instagram-close').css("display", "none");

        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Instagram_Mohtava").offset().top
        //}, 5000);
    });

</script>


