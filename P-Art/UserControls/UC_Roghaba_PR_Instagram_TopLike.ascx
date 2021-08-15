<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Roghaba_PR_Instagram_TopLike.ascx.cs" Inherits="P_Art.UserControls.UC_Roghaba_PR_Instagram_TopLike" %>
  <figure class="highcharts-figure container-fluid all_rates chartRow instaleft">
                <span class="title2">تعداد کل لایک ها</span>
                <span class="count  " id="instagram_top_like">-</span>
                <div class="arrow">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="135.364" height="22.189" viewBox="0 0 135.364 22.189">
                        <defs>
                            <linearGradient id="linear-gradient" x1="0.5" y1="1.14" x2="0.5" y2="-0.14" gradientUnits="objectBoundingBox">
                                <stop offset="0" stop-color="#fe0000" />
                                <stop offset="1" stop-color="#e88d8d" />
                            </linearGradient>
                        </defs>
                        <path id="Gradient_Overlay" data-name="Gradient Overlay" d="M38.616,22.189a.994.994,0,0,1-.626-.231L27.237,13.206l-6.481,4.215a.959.959,0,0,1-1.164-.073l-5.011-4.132-12.913,8.8a.983.983,0,0,1-.552.174,1.093,1.093,0,0,1-.97-.679,1.494,1.494,0,0,1,.418-1.831l13.521-9.213a.972.972,0,0,1,1.184.062l5.022,4.14,6.479-4.213a.958.958,0,0,1,1.158.067L38.959,19.5h4.568l12.7-19a1.07,1.07,0,0,1,.785-.5,1,1,0,0,1,.84.344l5.85,6.4,2.561-2.43a.967.967,0,0,1,1.225-.123L85.547,16.014,96.285,12.47a.927.927,0,0,1,.726.056l9.657,4.828L117.8,12.5a.949.949,0,0,1,.382-.08h11.545a1.024,1.024,0,0,1,.789.394l4.517,5.421a1.541,1.541,0,0,1,0,1.9.988.988,0,0,1-1.58,0l-4.188-5.029H118.383l-11.362,4.951a.933.933,0,0,1-.811-.024l-9.7-4.852-10.8,3.566a.934.934,0,0,1-.832-.116L67.069,6.974,64.343,9.556A.979.979,0,0,1,62.9,9.5L57.227,3.3,44.935,21.687a1.064,1.064,0,0,1-.872.5Z" fill="url(#linear-gradient)" />
                    </svg>

                </div>
                <div class="arrow_zero">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="123" height="20" viewBox="0 0 123 20">
                        <defs>
                            <filter id="Path_17_zero" x="0" y="0" width="123" height="20" filterUnits="userSpaceOnUse">
                                <feOffset dy="3" input="SourceAlpha" />
                                <feGaussianBlur stdDeviation="3" result="blur" />
                                <feFlood flood-opacity="0" />
                                <feComposite operator="in" in2="blur" />
                                <feComposite in="SourceGraphic" />
                            </filter>
                        </defs>
                        <g transform="matrix(1, 0, 0, 1, 0, 0)" filter="url(#Path_17_zero)">
                            <path id="Path_17-2" data-name="Path 17" d="M0,0H103" transform="translate(10 7)" fill="none" stroke="#fe0000" stroke-linecap="round" stroke-width="2" />
                        </g>
                    </svg>
                </div>
            </figure>
<asp:HiddenField ID="hddParmin11" runat="server"  />
<script type="text/javascript">
    function LoadTop_Instagram_Like() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var p = $("#<%= hddParmin11.ClientID %>").val();
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_Competitors_Instagram_Mohtava_Like.ashx?f=" + fromDate + "&t=" + toDate + "&p=" + p,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data != null) {

                        if (data > 0) {
                            $('#instagram_top_like').parent().children('.arrow_zero').hide();
                            $('#instagram_top_like').parent().children('.arrow').show();

                        }
                        else {
                            $('#instagram_top_like').parent().children('.arrow').hide();
                            $('#instagram_top_like').parent().children('.arrow_zero').show();

                        }
                        $('#instagram_top_like').text(data);
                        $('#instagram_top_like').attr("class", "count animate__animated animate__heartBeat");
                    }
                    else {
                    }
                },
                error: function (msg) {

                }
            });
        }
        catch (ex) {

        }
    }
</script>


