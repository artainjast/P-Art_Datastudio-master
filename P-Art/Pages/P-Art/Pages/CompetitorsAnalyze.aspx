<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="CompetitorsAnalyze.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.CompetitorsAnalyze" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_AllDataByMedia.ascx" TagPrefix="uc1" TagName="UC_Roghaba_PR_AllDataByMedia" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_AllData.ascx" TagPrefix="uc2" TagName="UC_Roghaba_PR_AllData" %>



<%@ Register Src="~/UserControls/UC_Roghaba_Ads_Bilboard.ascx" TagPrefix="uc8" TagName="UC_Roghaba_Ads_Bilboard" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_AberPiade.ascx" TagPrefix="uc9" TagName="UC_Roghaba_Ads_AberPiade" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_EsteraBoard.ascx" TagPrefix="uc10" TagName="UC_Roghaba_Ads_EsteraBoard" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_LightBox.ascx" TagPrefix="uc11" TagName="UC_Roghaba_Ads_LightBox" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_Mohiti_Ekran.ascx" TagPrefix="uc12" TagName="UC_Roghaba_Ads_Mohiti_Ekran" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_Mohiti_Makan.ascx" TagPrefix="uc13" TagName="UC_Roghaba_Ads_Mohiti_Makan" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_Mohiti_Campain.ascx" TagPrefix="uc14" TagName="UC_Roghaba_Ads_Mohiti_Campain" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_OnlineBanner_AllData.ascx" TagPrefix="uc15" TagName="UC_Roghaba_Ads_OnlineBanner_AllData" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Ads_OnlineBanner_Safeyi.ascx" TagPrefix="uc16" TagName="UC_Roghaba_Ads_OnlineBanner_Safeyi" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_Instagram_TopLike.ascx" TagPrefix="uc18" TagName="UC_Roghaba_PR_Instagram_TopLike" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Instagram_TopComment.ascx" TagPrefix="uc19" TagName="UC_Roghaba_PR_Instagram_TopComment" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Instagram_TopContent.ascx" TagPrefix="uc20" TagName="UC_Roghaba_PR_Instagram_TopContent" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_Telegram_TopView.ascx" TagPrefix="uc22" TagName="UC_Roghaba_PR_Telegram_TopView" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Telegram_TopChannel.ascx" TagPrefix="uc23" TagName="UC_Roghaba_PR_Telegram_TopChannel" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Telegram_TopContent.ascx" TagPrefix="uc24" TagName="UC_Roghaba_PR_Telegram_TopContent" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_Twitter_TopRetwitte.ascx" TagPrefix="uc26" TagName="UC_Roghaba_PR_Twitter_TopRetwitte" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Twitter_TopFavorite.ascx" TagPrefix="uc27" TagName="UC_Roghaba_PR_Twitter_TopFavorite" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Twitter_TopAllContent.ascx" TagPrefix="uc28" TagName="UC_Roghaba_PR_Twitter_TopAllContent" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_SocialMedia_Hashtag.ascx" TagPrefix="uc29" TagName="UC_Roghaba_PR_SocialMedia_Hashtag" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Jensiat.ascx" TagPrefix="uc30" TagName="UC_Roghaba_PR_Jensiat" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Map_Location.ascx" TagPrefix="uc31" TagName="UC_Roghaba_PR_Map_Location" %>
<%@ Register Src="~/UserControls/UC_Roghaba_PR_Abri_ByMedia.ascx" TagPrefix="uc32" TagName="UC_Roghaba_PR_Abri_ByMedia" %>



<%@ Register Src="~/UserControls/UC_Roghaba_Ads_Video_AllData.ascx" TagPrefix="uc7" TagName="UC_Roghaba_Ads_Video_AllData" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Show_Ads_Video_AllData.ascx" TagPrefix="uc_sh_7" TagName="UC_Roghaba_Show_Ads_Video_AllData" %>

<%@ Register Src="~/UserControls/UC_Roghaba_Ads_Radio_AllData.ascx" TagPrefix="uc6" TagName="UC_Roghaba_Ads_Radio_AllData" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Show_Ads_Radio_AllData.ascx" TagPrefix="uc_sh_6" TagName="UC_Roghaba_Show_Ads_Radio_AllData" %>

<%@ Register Src="~/UserControls/UC_Roghaba_Ads_RadioVideo_AllData.ascx" TagPrefix="uc5" TagName="UC_Roghaba_Ads_RadioVideo_AllData" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_Twitter_Mohtava.ascx" TagPrefix="uc25" TagName="UC_Roghaba_PR_Twitter_Mohtava" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Show_PR_Twitter_Mohtava.ascx" TagPrefix="uc_sh_25" TagName="UC_Roghaba_Show_PR_Twitter_Mohtava" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_Telegram_Mohtava.ascx" TagPrefix="uc21" TagName="UC_Roghaba_PR_Telegram_Mohtava" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Show_PR_Telegram_Mohtava.ascx" TagPrefix="uc_sh_21" TagName="UC_Roghaba_Show_PR_Telegram_Mohtava" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_Instagram_Mohtava.ascx" TagPrefix="uc17" TagName="UC_Roghaba_PR_Instagram_Mohtava" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Show_PR_Instagram_Mohtava.ascx" TagPrefix="uc_sh_17" TagName="UC_Roghaba_Show_PR_Instagram_Mohtava" %>

<%@ Register Src="~/UserControls/UC_Roghaba_PR_News_BySource.ascx" TagPrefix="uc33" TagName="UC_Roghaba_PR_News_BySource" %>
<%@ Register Src="~/UserControls/UC_Roghaba_Show_PR_News_BySource.ascx" TagPrefix="uc_sh_33" TagName="UC_Roghaba_Show_PR_News_BySource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Styles/bootstrap-grid_4.min.css" rel="stylesheet" />
    <link href="/Styles/animate.min.css" rel="stylesheet" />
    <link href="/UserControls/uc_chart.css" rel="stylesheet" />

    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/wordcloud.js") %>'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <asp:HiddenField ID="hddParmin" runat="server" />
    <div class="pageloading">
        <img src="/Pages/P-Art/Images/pleasewait.gif" />
    </div>
    <div class="row filterRow rtl">
        <div class="col-md-7">
            <input type="text" class="form-control textbox hasDatepicker" name="txt_fromDate" id="txt_fromDate" placeholder="از تاریخ :">
            <input type="text" class="form-control textbox hasDatepicker" name="txt_toDate" id="txt_toDate" placeholder="تا تاریخ :">
            <input type="button" onclick="LoadData(0,1);" value="جستجو" id="btn_ShowNews" class="btn btn-success cur-p">
        </div>
        <div class="col-md-5 ltr">
            <input type="button" value="ماه گذشته" onclick="LoadData(30,1);" id="btn_refresh_chart_30" class="btn btn-danger cur-p blur">
            <input type="button" value="هفت روز گذشته" onclick="LoadData(7,1);" id="btn_refresh_chart_7" class="btn btn-danger cur-p blur ">
            <input type="button" value="سه روز گذشته" onclick="LoadData(3,1);" id="btn_refresh_chart_3" class="btn btn-danger cur-p blur">
            <input type="button" value="24 ساعت گذشته" onclick="LoadData(1,1);" id="btn_refresh_chart_1" class="btn btn-danger cur-p ">
        </div>

    </div>
    <div class="row">
        <div class="col-md-4 box4">
            <uc2:UC_Roghaba_PR_AllData runat="server" ID="UC_Roghaba_PR_AllData" />
        </div>
        <div class="col-md-8 box8">
            <uc1:UC_Roghaba_PR_AllDataByMedia runat="server" ID="UC_Roghaba_PR_AllDataByMedia" />
        </div>

    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-6 box3">
                    <uc6:UC_Roghaba_Ads_Radio_AllData runat="server" ID="UC_Roghaba_Ads_Radio_AllData" />
                </div>
                <div class="col-md-6 box3">
                    <uc7:UC_Roghaba_Ads_Video_AllData runat="server" ID="UC_Roghaba_Ads_Video_AllData" />
                </div>
            </div>
        </div>
        <div class="col-md-6 box6">
            <uc5:UC_Roghaba_Ads_RadioVideo_AllData runat="server" ID="UC_Roghaba_Ads_RadioVideo_AllData" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc12:UC_Roghaba_Ads_Mohiti_Ekran runat="server" ID="UC_Roghaba_Ads_Mohiti_Ekran" />
            <uc13:UC_Roghaba_Ads_Mohiti_Makan runat="server" ID="UC_Roghaba_Ads_Mohiti_Makan" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 box3">
            <uc8:UC_Roghaba_Ads_Bilboard runat="server" ID="UC_Roghaba_Ads_Bilboard" />
        </div>
        <div class="col-md-3 box3">
            <uc9:UC_Roghaba_Ads_AberPiade runat="server" ID="UC_Roghaba_Ads_AberPiade" />
        </div>
        <div class="col-md-3 box3">
            <uc10:UC_Roghaba_Ads_EsteraBoard runat="server" ID="UC_Roghaba_Ads_EsteraBoard" />
        </div>
        <div class="col-md-3 box3">
            <uc11:UC_Roghaba_Ads_LightBox runat="server" ID="UC_Roghaba_Ads_LightBox" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <uc14:UC_Roghaba_Ads_Mohiti_Campain runat="server" ID="UC_Roghaba_Ads_Mohiti_Campain" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 box6">
            <uc15:UC_Roghaba_Ads_OnlineBanner_AllData runat="server" ID="UC_Roghaba_Ads_OnlineBanner_AllData" />
        </div>
        <div class="col-md-6 box6">
            <uc16:UC_Roghaba_Ads_OnlineBanner_Safeyi runat="server" ID="UC_Roghaba_Ads_OnlineBanner_Safeyi" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-9 box9">
            <uc17:UC_Roghaba_PR_Instagram_Mohtava runat="server" ID="UC_Roghaba_PR_Instagram_Mohtava" />
        </div>
        <div class="col-md-3">
            <div class="row">
                <div class="col-md-12 box3">
                    <uc18:UC_Roghaba_PR_Instagram_TopLike runat="server" ID="UC_Roghaba_PR_Instagram_TopLike" />
                </div>
                <div class="col-md-12 box3">
                    <uc19:UC_Roghaba_PR_Instagram_TopComment runat="server" ID="UC_Roghaba_PR_Instagram_TopComment" />
                </div>
                <div class="col-md-12 box3">
                    <uc20:UC_Roghaba_PR_Instagram_TopContent runat="server" ID="UC_Roghaba_PR_Instagram_TopContent" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12 box6">
                    <uc21:UC_Roghaba_PR_Telegram_Mohtava runat="server" ID="UC_Roghaba_PR_Telegram_Mohtava" />
                </div>
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-4 box4">
                            <uc22:UC_Roghaba_PR_Telegram_TopView runat="server" ID="UC_Roghaba_PR_Telegram_TopView" />
                        </div>
                        <div class="col-md-4 box4">
                            <uc23:UC_Roghaba_PR_Telegram_TopChannel runat="server" ID="UC_Roghaba_PR_Telegram_TopChannel" />
                        </div>
                        <div class="col-md-4 box4">
                            <uc24:UC_Roghaba_PR_Telegram_TopContent runat="server" ID="UC_Roghaba_PR_Telegram_TopContent" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12 box6">
                    <uc25:UC_Roghaba_PR_Twitter_Mohtava runat="server" ID="UC_Roghaba_PR_Twitter_Mohtava" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-4 box4">
                            <uc26:UC_Roghaba_PR_Twitter_TopRetwitte runat="server" ID="UC_Roghaba_PR_Twitter_TopRetwitte" />
                        </div>
                        <div class="col-md-4 box4">
                            <uc27:UC_Roghaba_PR_Twitter_TopFavorite runat="server" ID="UC_Roghaba_PR_Twitter_TopFavorite" />
                        </div>
                        <div class="col-md-4 box4">
                            <uc28:UC_Roghaba_PR_Twitter_TopAllContent runat="server" ID="UC_Roghaba_PR_Twitter_TopAllContent" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12 box6">
                    <uc31:UC_Roghaba_PR_Map_Location runat="server" ID="UC_Roghaba_PR_Map_Location" />
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-6 box3">
                    <uc30:UC_Roghaba_PR_Jensiat runat="server" ID="UC_Roghaba_PR_Jensiat" />
                </div>
                <div class="col-md-6 box3">
                    <uc29:UC_Roghaba_PR_SocialMedia_Hashtag runat="server" ID="UC_Roghaba_PR_SocialMedia_Hashtag" />
                </div>
            </div>

        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc32:UC_Roghaba_PR_Abri_ByMedia runat="server" ID="UC_Roghaba_PR_Abri_ByMedia" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc33:UC_Roghaba_PR_News_BySource runat="server" ID="UC_Roghaba_PR_News_BySource" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc_sh_7:UC_Roghaba_Show_Ads_Video_AllData runat="server" ID="UC_Roghaba_Show_Ads_Video_AllData" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc_sh_6:UC_Roghaba_Show_Ads_Radio_AllData runat="server" ID="UC_Roghaba_Show_Ads_Radio_AllData" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc_sh_25:UC_Roghaba_Show_PR_Twitter_Mohtava runat="server" ID="UC_Roghaba_Show_PR_Twitter_Mohtava" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc_sh_21:UC_Roghaba_Show_PR_Telegram_Mohtava runat="server" ID="UC_Roghaba_Show_PR_Telegram_Mohtava" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 box12">
            <uc_sh_17:UC_Roghaba_Show_PR_Instagram_Mohtava runat="server" ID="UC_Roghaba_Show_PR_Instagram_Mohtava" />
        </div>
    </div>
        <div class="row">
        <div class="col-md-12 box12">
            <uc_sh_33:UC_Roghaba_Show_PR_News_BySource runat="server" ID="UC_Roghaba_Show_PR_News_BySource" />
        </div>
    </div>

    <script>

        $(document).ready(function () {
            try {
                $("#txt_fromDate").datepicker({ dateFormat: 'yy/mm/dd' });
                $("#txt_toDate").datepicker({ dateFormat: 'yy/mm/dd' });
                LoadData(7, 0);
            }
            catch (e) { }
        });
        //window.onload = function () {
       
        //}
        function LoadData(counter, calltype) {
            if (counter == 1) {
                $('#btn_refresh_chart_1').removeClass('blur');
                $('#btn_refresh_chart_3').removeClass('blur');
                $('#btn_refresh_chart_7').removeClass('blur');
                $('#btn_refresh_chart_30').removeClass('blur');

                $('#btn_refresh_chart_3').addClass('blur');
                $('#btn_refresh_chart_7').addClass('blur');
                $('#btn_refresh_chart_30').addClass('blur');


            }
            else if (counter == 3) {
                $('#btn_refresh_chart_1').removeClass('blur');
                $('#btn_refresh_chart_3').removeClass('blur');
                $('#btn_refresh_chart_7').removeClass('blur');
                $('#btn_refresh_chart_30').removeClass('blur');

                $('#btn_refresh_chart_1').addClass('blur');
                $('#btn_refresh_chart_7').addClass('blur');
                $('#btn_refresh_chart_30').addClass('blur');
            }
            else if (counter == 7) {
                $('#btn_refresh_chart_1').removeClass('blur');
                $('#btn_refresh_chart_3').removeClass('blur');
                $('#btn_refresh_chart_7').removeClass('blur');
                $('#btn_refresh_chart_30').removeClass('blur');

                $('#btn_refresh_chart_1').addClass('blur');
                $('#btn_refresh_chart_3').addClass('blur');
                $('#btn_refresh_chart_30').addClass('blur');
            }
            else if (counter == 30) {
                $('#btn_refresh_chart_1').removeClass('blur');
                $('#btn_refresh_chart_3').removeClass('blur');
                $('#btn_refresh_chart_7').removeClass('blur');
                $('#btn_refresh_chart_30').removeClass('blur');

                $('#btn_refresh_chart_1').addClass('blur');
                $('#btn_refresh_chart_7').addClass('blur');
                $('#btn_refresh_chart_3').addClass('blur');
            }
            else {
                $('#btn_refresh_chart_1').removeClass('blur');
                $('#btn_refresh_chart_3').removeClass('blur');
                $('#btn_refresh_chart_7').removeClass('blur');
                $('#btn_refresh_chart_30').removeClass('blur');


            }
            $.ajax({
                type: "POST",
                url: "/Services/Part_GetChartDay.ashx?date=" + counter,
                data: "",
                //url: '/Services/Service_Competitor.aspx/GetChartDay',
                //data: "{'date':" + counter + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data != null && data != '') {
                        $('#txt_fromDate').val(data.split(';')[0]);
                        $('#txt_toDate').val(data.split(';')[1]);
                        LoadCharts(calltype);
                    }
                    else {
                    }
                },
                error: function (msg) {

                }
            });
        }
        function LoadCharts(callingtype) {
            if (callingtype === 1) {
                $('.pageloading').addClass('showing');
            }

            Load_Competitors_AllDataCountWithMediaType();
            Load_Competitors_AllDataCount();
            Load_Competitors_Ads_Radio_AllDataCount();
            Load_Competitors_Ads_RadioVideo_AllDataCount();
            Load_Competitors_Ads_Video_AllDataCount();
            Load_Competitors_Ads_Bilboard();
            Load_Competitors_Ads_AberPiade();
            Load_Competitors_Ads_EsteraBoard();
            Load_Competitors_Ads_LightBox();
            Load_Competitors_Ads_Mohiti_Ekran();
            Load_Competitors_Ads_Mohiti_Makan();
            Load_Competitors_Ads_Advertise_Campain();
            Load_Competitors_OnlineBanner_AllData();
            Load_Competitors_OnlineBanner_Safeyi();
            Load_Competitors_Instagram_Mohtava();
            LoadTop_Instagram_Like();
            LoadTop_Instagram_Comment();
            LoadTop_Instagram_Content();
            Load_Competitors_Telegram_Mohtava();
            LoadTop_Telegram_View();
            LoadTop_Telegram_Channel();
            LoadTop_Telegram_Content();
            Load_Competitors_Twitter_Mohtava();
            LoadTop_Twitter_Favorite();
            LoadTop_Twitter_Retwitte();
            LoadTop_Twitter_AllContent();
            Load_Competitors_SocialMedia_Hashtag();
            Load_By_Jensiat();
            Load_Competitors_Abri_BySource();
            Load_Competitors_News_BySource();


            Load_Competitors_show_Ads_Video_AllDataCount();
            Load_Competitors_Show_Ads_Radio_AllData();
            Load_Competitors_show_PR_Twitter_Mohtava();
            Load_Competitors_show_PR_Telegram_Mohtava();
            Load_Competitors_show_PR_Instagram_Mohtava();
            Load_Competitors_show_PR_News_BySource();
        }
    </script>
</asp:Content>
