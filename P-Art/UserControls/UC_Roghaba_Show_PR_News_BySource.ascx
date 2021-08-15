<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Show_PR_News_BySource.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Show_PR_News_BySource" %>
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.carousel.min.css">
<link rel="stylesheet" href="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/assets/owl.theme.default.min.css">
<script src="https://owlcarousel2.github.io/OwlCarousel2/assets/owlcarousel/owl.carousel.js"></script>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingall uc__Show_PR_News_BySource showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
    <a  id='newsbySource-close' style="display:none;" href="#Competitors_News_BySource" class='newsbySource-close'><i class='fa fa-close'></i></a>
    <div id="Competitors_Show_PR_News_BySource" style="display:none;" class="content_container_preload_detail_min">
    </div>
</figure>
<asp:HiddenField ID="hddParmin44" runat="server" />
<script type="text/javascript">

    function Load_Competitors_show_PR_News_BySource() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin44.ClientID %>").val();
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Show_News_BySource.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var html = '';
                    var htmlTab = '';
                    var htmlContent = '';
                    var htmlItem = '';
                    var htmlbodyNews = '';
                    htmlTab += "<ul id='tabsNWS'>";

                    for (var i = 0; i < data.length; i++) {
                        htmlTab += "<li><a id=tabNWSName" + data[i].KeywordID + ">" + data[i].Keyword + "</a></li>";
                        htmlItem = '';
                        htmlbodyNews += "<div class='shahed-news-bysource-body'><i class='fa fa-dot-circle-o' ></i><span>شاهد برترین رسانه های انتشار دهنده</span>";
                        for (var j = 0; j < data[i].newsList.length; j++) {
                            htmlItem += "<div class='item11'><div class='rss-icon' ><i class='fa fa-rss' ></i></div><div class='news-text'><a target='_blanck' href='" + data[i].newsList[j].NewsLink +"'><span>" +
                                data[i].newsList[j].NewsTitle +
                                "</span></a></div><div class='sitetitle'><span>" + data[i].newsList[j].SiteTitle + "</span></div></div>";
                        }
                            htmlbodyNews += "</div>";
                            htmlContent += "<div class='container containerNWS' id ='tabNWSName" + data[i].KeywordID + "NWS'>" + htmlbodyNews + "<div class='news-bysource'>" + htmlItem + "</div></div>";
                            htmlbodyNews = "";
                        
                    }
                    htmlTab += "</ul>";


                    html = htmlContent + htmlTab;

                    $('#Competitors_Show_PR_News_BySource').html(html);

                    $('#tabsNWS li a:not(:first)').addClass('inactive');
                    $('.containerNWS').hide();
                    $('.containerNWS:first').show();

                    $('#tabsNWS li a').click(function () {
                        var t = $(this).attr('id');
                        if ($(this).hasClass('inactive')) { //this is the start of our condition 
                            $('#tabsNWS li a').addClass('inactive');
                            $(this).removeClass('inactive');

                            $('.containerNWS').hide();
                            $('#' + t + 'NWS').fadeIn('slow');
                        }
                    });
                    $('.uc__Show_PR_News_BySource').removeClass('showing');
                }
            });
        }
        catch (ex) {


        }
    }
    $("#newsbySource-close").click(function () {

        $('#Competitors_Show_PR_News_BySource').slideUp()
        $('#newsbySource-close').css("display", "none");

       //$('html, body').animate({
       //     scrollTop: $("#Competitors_News_BySource").offset().top
       // }, 5000);
    });
</script>


