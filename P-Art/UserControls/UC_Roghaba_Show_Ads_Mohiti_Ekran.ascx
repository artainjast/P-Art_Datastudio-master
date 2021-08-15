<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_Show_Ads_Mohiti_Ekran.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_Show_Ads_Mohiti_Ekran" %>
<figure class="highcharts-figure chartRow container-fluid rtl">
    <div class="pageloadingall uc__Show_Ads_Mohiti_Ekran showing">
        <img src="/Pages/P-Art/Images/loadingcolor.gif" />
    </div>
    <div id="Competitors_Show_Ads_Mohiti_Ekran" class="content_container_preload_detail_min">
        <div>test for showing</div>
    </div>
</figure>
<asp:HiddenField ID="hddParmin39" runat="server" />
<script type="text/javascript">

    function Load_Competitors_show_Ads_Video_AllDataCount() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin39.ClientID %>").val();
           try {
               $.ajax({
                   type: "POST",
                   url: "/Services/Part_Competitors_Ads_Mohiti_Ekran.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                   data: "",

                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (data) {
                       var html = '';
                       var htmlTab = '';
                       var htmlContent = '';
                       var htmlCampain = '';
                       var htmlItem = '';
                     

                       $('.uc__Show_Ads_Mohiti_Ekran').removeClass('showing');
                   }
               });
           }
           catch (ex) {


           }
       }

</script>


