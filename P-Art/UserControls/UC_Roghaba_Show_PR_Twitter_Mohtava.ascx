<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Show_PR_Twitter_Mohtava.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Show_PR_Twitter_Mohtava" %>
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.theme.default.min.css">
<script src="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/owl.carousel.js"></script>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingall uc__Show_PR_Twitter_Mohtava showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
    <a id="twitter-close" href="#Competitors_Twitter_Mohtava" class='twitter-close'><i class='fa fa-close'></i></a>
    <div id="Competitors_Show_PR_Twitter_Mohtava" style="display:none;" class="content_container_preload_detail_min">
        
    </div>
</figure>
<asp:HiddenField ID="hddParmin42" runat="server" />
<script type="text/javascript">

    function Load_Competitors_show_PR_Twitter_Mohtava() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin42.ClientID %>").val();
           try {
               $.ajax({
                   type: "POST",
                   url: "/Services/Part_Competitors_Show_Twitter_Mohtava.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                   data: "",

                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (data) {
                       var html = '';
                       var htmlTab = '';
                       var htmlContent = '';
                       var htmlItem = '';
                       var htmlbodyTwitter = '';
                       htmlTab += "<ul id='tabsTW'>";

                       for (var i = 0; i < data.length; i++) {
                           htmlTab += "<li><a id=tabTWName" + data[i].KeywordID + ">" + data[i].Keyword + "</a></li>";
                           htmlItem = '';
                           htmlbodyTwitter += "<div class='shahed-twitter-body'><i class='fa fa-dot-circle-o' ></i><span>شاهد محتوای شبکه اجتماعی توییتر</span>";
                           for (var j = 0; j < data[i].twitterList.length; j++) {
                               htmlItem += "<div class='item11'><div class='twitter-text'><a target='_blanck' href='#'><i class='fa fa-twitter twitterBlue'></i><span>" +
                                   data[i].twitterList[j].Text +
                                   "</span></a></div><div class='twitter-icons'><span class='heart'>" + data[i].twitterList[j].FavoriteCount +
                                   "<i class='fa fa-heart'></i></span></i><span class='retweet'>" + data[i].twitterList[j].RetweetCount +
                                   "<i class='fa fa-retweet'></i></span><span class='comment'>" + data[i].twitterList[j].ReplyCount +
                                   "<i class='fa fa-comment'></i></span></div><div class='twitter-detail'><span class='username'><i class='fa fa-user'></i>" +
                                   data[i].twitterList[j].UserName + "</span><span class='keyword'><i class='fa fa-key'></i>" + data[i].twitterList[j].keywordTitle +
                                   "</span><span class='TwitterDate'>" + data[i].twitterList[j].Time + "|" + data[i].twitterList[j].Date + "<i class='fa fa-calendar'></i></span></div></div>";
                           }
                           htmlbodyTwitter += "</div>";
                           htmlContent += "<div class='container containerTW' id ='tabTWName" + data[i].KeywordID + "TW'>" + htmlbodyTwitter + "<div class='owl-carousel owl-carousel-twitter owl-theme'>" + htmlItem + "</div></div>";
                           htmlbodyTwitter = "";
                       }
                       htmlTab += "</ul>";


                       html = htmlContent + htmlTab;

                       $('#Competitors_Show_PR_Twitter_Mohtava').html(html);

                       $('#tabsTW li a:not(:first)').addClass('inactive');
                       $('.containerTW').hide();
                       $('.containerTW:first').show();

                       $('#tabsTW li a').click(function () {
                           var t = $(this).attr('id');
                           if ($(this).hasClass('inactive')) { //this is the start of our condition 
                               $('#tabsTW li a').addClass('inactive');
                               $(this).removeClass('inactive');

                               $('.containerTW').hide();
                               $('#' + t + 'TW').fadeIn('slow');
                           }
                       });
                       $('.owl-carousel-twitter').owlCarousel({
                           loop: true,
                           nav: false,
                           autoplay: true,
                           autoPlaySpeed: 3000,
                           items: 4,
                           itemsDesktop: [1199, 4], itemsDesktopSmall: [979, 4]
                       })

                       $('.uc__Show_PR_Twitter_Mohtava').removeClass('showing');
                   }
               });
           }
           catch (ex) {


           }
       }

    $("#twitter-close").click(function () {
        $("#Competitors_Show_PR_Twitter_Mohtava").slideUp()
        $("#twitter-close").css("display", "none");

        //$('html, body').animate({
        //    scrollTop: $("#Competitors_Twitter_Mohtava").offset().top
        //}, 5000);
    });
</script>


