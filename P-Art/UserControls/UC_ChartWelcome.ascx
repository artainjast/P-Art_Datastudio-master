﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ChartWelcome.ascx.cs" Inherits="P_Art.UserControls.UC_ChartWelcome" %>
<link href="/Styles/bootstrap-grid_4.min.css" rel="stylesheet" />
<link href="/Styles/animate.min.css" rel="stylesheet" />
<script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/wordcloud.js") %>'></script>
<link href="/UserControls/uc_chart.css" rel="stylesheet" />

<div style="display: none;">
    <asp:HiddenField ID="hddParmin2" runat="server" />
    <asp:HiddenField ID="hddParmin" runat="server" />
</div>
<div id="mainSection" class="container-fluid">

    <div class="chartRow row rtl">
        <div class="col-md-3">

            <figure class="highcharts-figure container-fluid all_rates">
                <a id="hyp_all_top_news" style="cursor: pointer;" data-setting="all_top_news" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <span class="title">تعداد کل محتوای خبری</span>
                <span class="count  " id="all_top_news">-</span>
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
        </div>
        <div class="col-md-3">
            <figure class="highcharts-figure container-fluid all_rates">
                <a id="hyp_all_top_radio" style="cursor: pointer;" data-setting="all_top_radio" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <span class="title">تعداد کل محتوای صوتی</span>
                <span class="count  " id="all_top_radio">-</span>
                <div class="arrow">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="123" height="20" viewBox="0 0 123 20">
                        <defs>
                            <filter id="Path_17" x="0" y="0" width="123" height="20" filterUnits="userSpaceOnUse">
                                <feOffset dy="3" input="SourceAlpha" />
                                <feGaussianBlur stdDeviation="3" result="blur" />
                                <feFlood flood-opacity="0" />
                                <feComposite operator="in" in2="blur" />
                                <feComposite in="SourceGraphic" />
                            </filter>
                        </defs>
                        <g transform="matrix(1, 0, 0, 1, 0, 0)" filter="url(#Path_17)">
                            <path id="Path_17-22" data-name="Path 17" d="M0,0H103" transform="translate(10 7)" fill="none" stroke="#04f" stroke-linecap="round" stroke-width="2" />
                        </g>
                    </svg>
                </div>
                <div class="arrow_zero">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="123" height="20" viewBox="0 0 123 20">
                        <defs>
                            <filter id="Path_17_zero2" x="0" y="0" width="123" height="20" filterUnits="userSpaceOnUse">
                                <feOffset dy="3" input="SourceAlpha" />
                                <feGaussianBlur stdDeviation="3" result="blur" />
                                <feFlood flood-opacity="0" />
                                <feComposite operator="in" in2="blur" />
                                <feComposite in="SourceGraphic" />
                            </filter>
                        </defs>
                        <g transform="matrix(1, 0, 0, 1, 0, 0)" filter="url(#Path_17_zero2)">
                            <path id="Path_17-22" data-name="Path 17" d="M0,0H103" transform="translate(10 7)" fill="none" stroke="#04f" stroke-linecap="round" stroke-width="2" />
                        </g>
                    </svg>
                </div>
            </figure>
        </div>
        <div class="col-md-3">
            <figure class="highcharts-figure container-fluid all_rates">
                <a id="hyp_all_top_video" style="cursor: pointer;" data-setting="all_top_video" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <span class="title">تعداد کل محتوای تصویری</span>
                <span class="count  " id="all_top_video">-</span>
                <div class="arrow">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="135.364" height="30.513" viewBox="0 0 135.364 30.513">
                        <defs>
                            <linearGradient id="linear-gradient3" x1="0.5" y1="1.14" x2="0.5" y2="-0.14" gradientUnits="objectBoundingBox">
                                <stop offset="0" stop-color="#ff7f00" />
                                <stop offset="1" stop-color="#ffd25f" />
                            </linearGradient>
                        </defs>
                        <g id="Pattern" transform="translate(0)">
                            <g id="Pattern-2" data-name="Pattern" transform="translate(0 0)">
                                <g id="Group_14" data-name="Group 14" transform="translate(0 0)">
                                    <path id="Path_12" data-name="Path 12" d="M1294.82,734.67a1.094,1.094,0,0,1-.97-.684,1.512,1.512,0,0,1,.418-1.844l13.521-9.276a.964.964,0,0,1,1.184.062l5.022,4.169,6.479-4.242a.93.93,0,0,1,.612-.159l10.372.9,3.915-6.494a1.134,1.134,0,0,1,.641-.516l14.276-4.15,8-7.97a.967.967,0,0,1,1.41-.011l8.38,8.17,11.244,15.511,9.8-7.546a.953.953,0,0,1,.872-.17l10.8,3.269,11.188,1.149,11.449-.005a1.028,1.028,0,0,1,.789.395l4.516,5.464a1.561,1.561,0,0,1,0,1.911.987.987,0,0,1-1.58,0l-4.188-5.067H1411.89l-11.458-1.192-10.51-3.161-10.209,7.857a.983.983,0,0,1-1.442-.251l-11.733-16.222-7.531-7.316-7.493,7.47a1.071,1.071,0,0,1-.449.27l-14.126,4.107-4.04,6.7a1.021,1.021,0,0,1-.983.552l-10.665-.927-6.79,4.447a.955.955,0,0,1-1.164-.073l-5.011-4.161-12.913,8.86A.974.974,0,0,1,1294.82,734.67Z" transform="translate(-1293.703 -704.157)" fill="#626afa" />
                                </g>
                            </g>
                            <path id="Gradient_Overlay3" data-name="Gradient Overlay" d="M.147,29.829a1.512,1.512,0,0,1,.418-1.844l13.521-9.276a.964.964,0,0,1,1.184.062l5.022,4.169L26.771,18.7a.927.927,0,0,1,.612-.16l10.372.9,3.915-6.494a1.134,1.134,0,0,1,.642-.516l14.276-4.15,8-7.97A.967.967,0,0,1,65.994.3l8.38,8.171L85.618,23.98l9.8-7.546a.953.953,0,0,1,.872-.17l10.8,3.268,11.188,1.149,11.449,0a1.026,1.026,0,0,1,.789.394l4.516,5.464a1.561,1.561,0,0,1,0,1.912.987.987,0,0,1-1.58,0l-4.188-5.066H118.187l-11.458-1.193-10.51-3.161L86.01,26.884a.983.983,0,0,1-1.442-.251L72.835,10.411,65.3,3.1l-7.494,7.47a1.082,1.082,0,0,1-.449.27L43.235,14.942l-4.041,6.7a1.021,1.021,0,0,1-.984.551l-10.664-.927-6.79,4.447a.954.954,0,0,1-1.164-.073l-5.011-4.161L1.669,30.337a.979.979,0,0,1-.552.175A1.094,1.094,0,0,1,.147,29.829Z" transform="translate(0 0)" fill="url(#linear-gradient3)" />
                        </g>
                    </svg>


                </div>
                <div class="arrow_zero">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="123" height="20" viewBox="0 0 123 20">
                        <defs>
                            <filter id="Path_17_zero3" x="0" y="0" width="123" height="20" filterUnits="userSpaceOnUse">
                                <feOffset dy="3" input="SourceAlpha3" />
                                <feGaussianBlur stdDeviation="3" result="blur" />
                                <feFlood flood-opacity="0" />
                                <feComposite operator="in" in2="blur" />
                                <feComposite in="SourceGraphic" />
                            </filter>
                        </defs>
                        <g transform="matrix(1, 0, 0, 1, 0, 0)" filter="url(#Path_17_zero3)">
                            <path id="Path_17-23" data-name="Path 17" d="M0,0H103" transform="translate(10 7)" fill="none" stroke="#ff7f00" stroke-linecap="round" stroke-width="2" />
                        </g>
                    </svg>
                </div>
            </figure>
        </div>
        <div class="col-md-3">
            <figure class="highcharts-figure container-fluid all_rates">
                <a id="hyp_all_top_social" style="cursor: pointer;" data-setting="all_top_social" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <span class="title">تعداد کل محتوا در شبکه های اجتماعی</span>
                <span class="count  " id="all_top_social">-</span>
                <div class="arrow">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="135.364" height="22.189" viewBox="0 0 135.364 22.189">
                        <defs>
                            <linearGradient id="linear-gradient4" x1="0.5" y1="1.14" x2="0.5" y2="-0.14" gradientUnits="objectBoundingBox">
                                <stop offset="0" stop-color="#c471f5" />
                                <stop offset="1" stop-color="#fa71cd" />
                            </linearGradient>
                        </defs>
                        <g id="Pattern4" transform="translate(0 0)">
                            <g id="Pattern-24" data-name="Pattern" transform="translate(0 0)">
                                <g id="Group_16" data-name="Group 16">
                                    <path id="Path_14" data-name="Path 14" d="M1294.82,604.908a1.094,1.094,0,0,1-.97-.679,1.5,1.5,0,0,1,.418-1.831l13.521-9.212a.973.973,0,0,1,1.184.062l5.022,4.14,6.479-4.213a.957.957,0,0,1,1.158.067l11.031,8.982h4.568l12.7-19a1.071,1.071,0,0,1,.784-.5,1,1,0,0,1,.84.344l5.851,6.4,2.561-2.43a.968.968,0,0,1,1.225-.123l18.057,11.822,10.739-3.544a.925.925,0,0,1,.726.056l9.657,4.828,11.136-4.852a.945.945,0,0,1,.382-.081h11.545a1.025,1.025,0,0,1,.789.395l4.516,5.421a1.542,1.542,0,0,1,0,1.9.988.988,0,0,1-1.58,0l-4.188-5.029h-10.886l-11.362,4.951a.935.935,0,0,1-.811-.024l-9.7-4.852-10.8,3.566a.935.935,0,0,1-.831-.115l-17.805-11.658-2.727,2.583a.979.979,0,0,1-1.444-.059l-5.672-6.2-12.292,18.392a1.063,1.063,0,0,1-.871.5h-5.448a1,1,0,0,1-.626-.231l-10.752-8.753-6.481,4.216a.96.96,0,0,1-1.164-.073l-5.011-4.132-12.913,8.8A.979.979,0,0,1,1294.82,604.908Z" transform="translate(-1293.703 -582.719)" fill="#626afa" />
                                </g>
                            </g>
                            <path id="Gradient_Overlay4" data-name="Gradient Overlay" d="M38.616,22.189a.994.994,0,0,1-.626-.231L27.237,13.206l-6.481,4.215a.959.959,0,0,1-1.164-.073l-5.011-4.132-12.913,8.8a.983.983,0,0,1-.552.174,1.093,1.093,0,0,1-.97-.679,1.494,1.494,0,0,1,.418-1.831l13.521-9.213a.972.972,0,0,1,1.184.062l5.022,4.14,6.479-4.213a.958.958,0,0,1,1.158.067L38.959,19.5h4.568l12.7-19a1.07,1.07,0,0,1,.785-.5,1,1,0,0,1,.84.344l5.85,6.4,2.561-2.43a.967.967,0,0,1,1.225-.123L85.547,16.014,96.285,12.47a.927.927,0,0,1,.726.056l9.657,4.828L117.8,12.5a.949.949,0,0,1,.382-.08h11.545a1.024,1.024,0,0,1,.789.394l4.517,5.421a1.541,1.541,0,0,1,0,1.9.988.988,0,0,1-1.58,0l-4.188-5.029H118.383l-11.362,4.951a.933.933,0,0,1-.811-.024l-9.7-4.852-10.8,3.566a.934.934,0,0,1-.832-.116L67.069,6.974,64.343,9.556A.979.979,0,0,1,62.9,9.5L57.227,3.3,44.935,21.687a1.064,1.064,0,0,1-.872.5Z" transform="translate(0 0)" fill="url(#linear-gradient4)" />
                        </g>
                    </svg>

                </div>
                <div class="arrow_zero">
                    <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="123" height="20" viewBox="0 0 123 20">
                        <defs>
                            <filter id="Path_17_zero4" x="0" y="0" width="123" height="20" filterUnits="userSpaceOnUse">
                                <feOffset dy="3" input="SourceAlpha4" />
                                <feGaussianBlur stdDeviation="3" result="blur" />
                                <feFlood flood-opacity="0" />
                                <feComposite operator="in" in2="blur" />
                                <feComposite in="SourceGraphic" />
                            </filter>
                        </defs>
                        <g transform="matrix(1, 0, 0, 1, 0, 0)" filter="url(#Path_17_zero4)">
                            <path id="Path_17-24" data-name="Path 17" d="M0,0H103" transform="translate(10 7)" fill="none" stroke="#c471f5" stroke-linecap="round" stroke-width="2" />
                        </g>
                    </svg>
                </div>
            </figure>
        </div>
    </div>

    <div class="row filterRow rtl">
        <div class="col-md-7">
            <input type="text" class="form-control textbox hasDatepicker" id="txt_fromDate" placeholder="از تاریخ :">
            <input type="text" class="form-control textbox hasDatepicker" id="txt_toDate" placeholder="تا تاریخ :">
            <input type="text" class="form-control textbox " id="txtkeyword" placeholder="کلیدواژه :">
            <input type="button" onclick="LoadData(0);" value="جستجو" id="btn_ShowNews" class="btn btn-success cur-p">
        </div>
        <div class="col-md-5 ltr">
            <input type="button" value="ماه گذشته" onclick="LoadData(30);" id="btn_refresh_chart_30" class="btn btn-danger cur-p blur">
            <input type="button" value="هفت روز گذشته" onclick="LoadData(7);" id="btn_refresh_chart_7" class="btn btn-danger cur-p blur ">
            <input type="button" value="سه روز گذشته" onclick="LoadData(3);" id="btn_refresh_chart_3" class="btn btn-danger cur-p blur">
            <input type="button" value="امروز" onclick="LoadData(1);" id="btn_refresh_chart_1" class="btn btn-danger cur-p ">
        </div>

    </div>

    <div class="social_all_count rtl">

        <div class="social_all social_all_instagram">
            <a id="hyp_all_instagram" style="cursor: pointer;" data-setting="all_instagram" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
            <span class="title">اینستاگرام</span>
            <span class="count  " id="all_instagram">-</span>
            <span class="sidebarIcon"><i class="fa fa-instagram fa-2x instagramMaroon"></i></span>
        </div>
        <div class="social_all social_all_twitter">
            <a id="hyp_all_twitter" style="cursor: pointer;" data-setting="all_twitter" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
            <span class="title">توییتر</span>
            <span class="count  " id="all_twitter">-</span>
            <span class="sidebarIcon"><i class="fa fa-twitter fa-2x twitterBlue"></i></span>
        </div>
        <div class="social_all social_all_telegram">
            <a id="hyp_all_telegram" style="cursor: pointer;" data-setting="all_telegram" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
            <span class="title">تلگرام</span>
            <span class="count  " id="all_telegram">-</span>
            <span class="sidebarIcon"><i class="fa fa-telegram fa-2x telegramBlue"></i></span>
        </div>
        <div class="social_all social_all_website">
            <a id="hyp_all_website" style="cursor: pointer;" data-setting="all_website" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
            <span class="title">سایت های خبری</span>
            <span class="count  " id="all_website">-</span>
            <span class="sidebarIcon"><i class="fa fa-globe fa-2x blue"></i></span>
        </div>
        <div class="social_all social_all_newspaper">
            <a id="hyp_all_newspaper" style="cursor: pointer;" data-setting="all_newspaper" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
            <span class="title">جراید</span>
            <span class="count  " id="all_newspaper">-</span>
            <span class="sidebarIcon"><i class="fa fa-newspaper-o fa-2x Purple"></i></span>
        </div>
    </div>

    <figure class="highcharts-figure chartRow container-fluid rtl box12">
        <a id="hyp_social_count_day" style="cursor: pointer;" data-setting="social_count_day" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
        <div id="container-social-count-day" class="content_container_preload"></div>
    </figure>
    <div class="chartRow row rtl">
        <div class="col-md-4 box4">
            <figure class="highcharts-figure container-fluid">
                <a id="hyp_tafkik_news_online" style="cursor: pointer;" data-setting="tafkik_news_online" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-news-online" class="content_container_preload_min"></div>
            </figure>
        </div>
        <div class="col-md-4 box4">
            <figure class="highcharts-figure container-fluid">
                <a id="hyp_tafkik_social" style="cursor: pointer;" data-setting="tafkik_social" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-social" class="content_container_preload_min"></div>
            </figure>
        </div>
        <div class="col-md-4 box4">
            <figure class="highcharts-figure container-fluid">
                <a id="hyp_tafkik_tv" style="cursor: pointer;" data-setting="tafkik_tv" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-tv" class="content_container_preload_min"></div>
            </figure>
        </div>
    </div>


    <div class="chartRow row ">

        <div class="col-md-4">
            <div class="col-md-12 highcharts-figure box3">
                <a id="hyp_top_hashtag" style="cursor: pointer;" data-setting="top_hashtag" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-top-hashtag" class="content_container_preload_min"></div>
            </div>
            <div class="col-md-12 highcharts-figure chartRow box3">
                <a id="hyp_jensiat" style="cursor: pointer;" data-setting="jensiat" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-jensiat" class="content_container_preload_min"></div>

            </div>
            <div class="col-md-12 highcharts-figure chartRow box3">
                <a id="hyp_news_mosbat_manfi" style="cursor: pointer;" data-setting="news_mosbat_manfi" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-news-mosbat-manfi" class="content_container_preload_min"></div>

            </div>
        </div>
        <div class="col-md-8">
            <div class="col-md-12 highcharts-figure " style="position: relative;">
                <a id="slidePaging_next" href="#بعدی" class="slidePaging_next" onclick="Slide_Next()"></a>
                <a id="slidePaging_prev" href="#قبلی" class="slidePaging_prev" onclick="Slide_Prev()"></a>
                <a id="hyp_top_twitter" style="cursor: pointer;" data-setting="top_twitter" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="top-twitter">
                </div>

            </div>
            <div class="col-md-12 highcharts-figure chartRow box9">
                <a id="hyp_sugiri_webnewspaper_mosbat" style="cursor: pointer;" data-setting="sugiri_webnewspaper_mosbat" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-sugiri-webnewspaper-mosbat" class="content_container_preload"></div>

            </div>
            <div class="col-md-12  highcharts-figure chartRow box9">
                <a id="hyp_sugiri_webnewspaper_manfi" style="cursor: pointer;" data-setting="sugiri_webnewspaper_manfi" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div id="container-sugiri-webnewspaper-manfi" class="content_container_preload"></div>

            </div>
        </div>

    </div>

    <div class="chartRow row">
        <div class="col-md-6 ">
            <figure class="highcharts-figure container-fluid box6" >
				<a id="hyp_cloud_chart_twitter" style="cursor: pointer;" data-setting="cloud_chart_twitter" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div class='content_container_preload' id='CloudChartTwitter'></div>
            </figure>
        </div>
        <div class="col-md-6">
            <figure class="highcharts-figure container-fluid box6">
				<a id="hyp_cloud_chart_news" style="cursor: pointer;" data-setting="cloud_chart_news" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div class='content_container_preload' id='CloudChartNews'></div>
            </figure>
        </div>
    </div>
    <div class="chartRow row">
        <div class="col-md-4 ">
            <figure class="highcharts-figure container-fluid">
				<a id="hyp_map_twitter" style="cursor: pointer;" data-setting="map_twitter" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <header class="clearfix">
                    <h4 class="text-right" style="padding: 10px; text-align: right;">پراکندگی جغرافیایی کاربران توییتر</h4>
                </header>
                <div class="svg-wrapper">

                    <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 841.89 595.28" enable-background="new 0 0 841.89 595.28" xml:space="preserve">

                        <svg class="map-border">
                            <path display="inline" d="M749.69,551.97l-1,1.05
			c-1.84-0.27-3.76-0.97-5.64-1.46c-0.57-0.15-0.35-0.16-0.9,0.05c-0.8,0.3-1.38,0.78-1.95,1.25c-1.29,1.06-1.15,0.69-1.83,0.78
			c-1.41,0.18-2.92-0.09-4.43-0.36l0,0.01c-1.59-0.29-3.19-0.57-4.88-0.43c-2.27,0.07-5.31-0.26-7.84-0.45l-2.14,3.4l-2.61,0.12
			l-0.28,0.65l-0.97-0.79c-1.31-0.48-2.65-0.58-3.95-0.39c-2.05,0.29-3.26,1.06-4.9,2.09l0.67,2.01c-2.78-0.08-4.41,0.17-7.09,0.84
			l-0.35,2.31l-1.64,0.25l-0.22-0.13l1.35-4.46l-4.45-0.62l-0.92-0.42l0.14-0.73c0.98-5.28-1.08-10.48,0.49-15l0.1-0.29
			c0.03-0.24-0.35-2.91-0.23-4.12l2.63,0.67l0.48-8.59c0.17-2.37,0.35-4.57,0.54-6.67c0.41-2.87,5.63-2.79,8.4-5.03l0.41-0.33
			l0.29-1.37l3.69,0.43l0.37-1.18c0.62-2.01,0.96-5.05,3.03-5.4l0.71-0.12l0.76-1.34c2.61-0.5,5.23-0.81,7.75-2.02
			c2.34-1.12,4.89-1.88,7.5-2.19c3.78-0.44,5.86,0.05,9.27,0.9l-0.12-8.41l3.21-1.76l-2.14-2.39c-0.04-1.12-0.03-2.24,0.06-3.36
			c0.4-4.57,2.19-4.32-0.12-7.28l-1.17-1.84c-2.48,1.64-2.76,1.78-6.12,2.36l-2.81,0.58c-1.57,0.44-3.36-0.04-5.07-0.49l-0.06-0.02
			c-0.32-1.64-1.01-3.46-0.43-4.87c0.69-1.66,1.29-3.46,0.87-5.37c-0.25-1.25-0.45-2.45-0.65-3.64c-0.57-3.4-1.14-6.8-2.43-10.1
			c-1.03-2.67-0.73-5.71-0.43-8.68l0.35-3.91l-7.4,1.48l-1.92-2.86l-0.48-0.5c-1.57-1-2.74-2-4.59-2.48
			c-2.27-0.6-4.57-1.08-6.86-1.56c-2.12-0.44-4.25-0.89-6.29-1.41c-1.71-0.62-4.31-3.59-5.91-4.97l-1.25-0.93
			c-1.18-0.86-2.38-1.72-3.24-2.82c-1.88-2.32-2.43-3.78-3.57-6.66c-0.96-2.43-1.01-2.84-3.18-4.57c-1.61-1.28-1.6-1.44-1.67-2.89
			l-0.67-0.42c-1.1-0.68-0.9-2.96-0.97-4.59c-1.82-1.44-2.24-1.78-3.81-3.5l-5.3-5.75c-2.27-2.39-4.53-4.77-6.61-7.32
			c4.77-7.01,9.76-13.93,14.74-20.86c3.4-4.71,6.79-9.43,9.93-13.9c0.84-1.26,0.97-2.71,1.08-4.03c0.18-2.18,0.28-2.27,1.38-3.59
			c-1.06-2.12-1.99-4.08-2.11-6.52l-0.03-0.63l-1.64-1.47c-0.37-0.61,0.22-4.86-3.52-5.08c-4.02-0.3-8.21-0.6-12.4-0.9l-12.98-0.97
			c0.03-1.96-0.1-3.87-1.17-5.59c0.59-1.4,1-2.31,0.45-3.99c-0.72-2.17-1.14-5.94-1.1-8.27c0.05-1.93,0.89-4.07,0.99-6.36
			c0.07-1.57-1.49-5.92-2.04-7.42l-2.59-7.26c-1.79-5.03-3.57-10.06-5.52-15.43c-0.44-1.2-0.67-2.34-0.43-3.58
			c0.17-0.88,0.6-1.68,1.36-2.24c1.14-0.68,2.42-2.61,3.06-3.6c0.65-1,1.31-2.01,2.17-2.71l0.36-0.29l1.71-6.05l-1.68-0.25
			c-3.47-0.52-8.08-0.01-10.19-2.77l-0.11-0.13c-1.22-1.27,0.41-3.61,1.18-4.78c-0.9-3.77-1.96-7.68-1.54-11.47l0.18-1.61
			c0.45-0.52,0.89-1.06,1.32-1.59c1.1-1.37,2.2-2.73,3.57-3.67c0.62-0.09,1.26-0.13,1.91-0.17c2.41-0.16,3.06-0.36,5.36-0.83
			l-1.53-1.92c-1.44-1.81-3.06-3.41-4.63-5.07l3.22-0.58l0.65-2.12l1.57-0.83c0.68-0.39,0.51-0.17,0.71-0.91
			c0.35-1.29,0.78-2.6,1.22-3.91l0,0c0.27-0.81,1-2.77,1.01-3.36c0.05-3.79,0.43-6.27,1.53-9.87c-0.87-0.83-1.48-1.32-1.76-2.61
			c-0.17-0.79-0.14-1.64,0.07-2.46c1.27-1.77,2.24-3.68,3.03-5.67c0.99-2.47,1.66-4.9,2.38-7.39c-1.32-0.65-2.48-1.11-3.25-2.46
			c1.59-3.17,1.1-6.29,0.11-9.47l-2.64-0.73c0.2-1.14,1.49-2.5,1.72-4.31c0.49-3.95-2.49-8.67-2.53-9.06c0.43-2.01,0.53-4,0.63-6
			l0.13-2.18l-2.78-2.9l-11.08,0.75c-2.87,0.13-5.74,0.27-8.47,0.49c-0.56,0.03-2.24,0.13-2.52-0.15c-0.46-0.46-1.3-3.79-3.69-5.37
			l0,0c-1.47-0.97-2.31-2.65-3.15-4.33c-0.97-1.94-1.24-2.42-2.51-4.11l-0.89,0.14c-3.15,0.5-6.09-3.23-10.48-2.39
			c-0.31,0.06-0.13,0.21-0.65-0.58l-1.03-1.35l-2.93,0.12l-0.56-2.16l-2.83-2.4c-0.38-0.99-0.5-2.14-0.62-3.29l-0.46-3.2l-2.25,0.1
			c-0.82,0.1-0.85,0.11-1.2-0.09l-6.74-4.53l-0.79-0.26l-4.2-0.5l-0.57-0.12l-3.02,1.75c-0.63-0.24-1.26-0.68-1.88-1.12l-2.32-1.49
			l-0.83,1.01c-0.32,0.4-1.31,1.96-1.61,2.06c-0.75,0.04-1.61-0.17-2.45-0.38l-2.65-0.54c-2.18-0.46-2.42-2.13-2.77-3.84
			c-3.07-0.27-5.44-0.66-8.11-2.43c-0.54-0.36-0.31-0.3-0.95-0.25c-1.65,0.13-3.31-0.62-4.91-1.31l0,0
			c-3.35-1.51-7.08-0.06-9.14-2.01l-0.21-0.16c-0.63-0.42-0.35-2.02-0.32-3.05c0.02-0.65,0.09-0.42-0.3-0.94
			c-2.83-3.78-2.78-4.3-3.49-8.6l-2.82,2.7c-0.86,0.86-1.73,1.74-2.73,2.17c-0.86,0.25-3.04,0.14-4.01,0
			c-1.24-0.27-2.37-1.83-4.31-2.41l-0.55-0.17l-1.13,0.56c-3.06,1.53-2.88,0.28-3.38,0.06l-3.86-0.07c-2.07,0.22-2.9,0.8-4.49,1.91
			l1.38,3.83l-1.81,1.33c-2.75-0.75-5.5-0.44-8.18-0.29c-2.37,0.14-3.7-2.27-7-1.51c-2.86,0.66-6.17-0.1-9.22,2.74
			c-1.92,1.79-4.83,3.16-7.4,3.74c-0.65,0.15-0.45,0.02-0.85,0.53c-2.13,2.68-4.86,4.39-7.32,6.55c-3.12,2.74-1.67,7.19-3.14,9.54
			c-0.39,0.55-1.51,1.78-2.05,1.96c-0.9,0.3-3.8-1.11-6.16,0.45l-0.1,0.06v0.01c-1.97,1.23-3.99,2.5-6.18,3.08
			c-1.13-0.06-2.33-0.21-3.54-0.35l-5.15-0.41c-0.36-1.93-0.61-3.88-0.64-5.84l-0.2-0.73c-3.14-5.46-1.48-12.13-1.36-17.95
			c0.02-0.98,0.28-1.8,0.61-2.86c1-3.21,0.85-3.48,0.33-6.55c-0.46-2.73-0.92-5.48-0.5-8.12c0.31-2.41,1.95-4.44,2.35-7.27l0.97-3.54
			l0.09-0.57c-0.14-3.24-1.64-5.43-3.98-7.47l-2.17,0.17c-0.73-0.57-1.25-1.45-1.77-2.32c-0.86-1.45-1.72-2.88-3.46-3.73
			c-0.53-1.79-1.14-3.79-3.33-4.63c-3.44-1.13-5.28-1.82-8.61-3.29l1.55-2.68l0.96-0.12c2.49-0.31,4.91-0.07,7.51-0.86l0.66-0.41
			c2.02-2.13,0.62-3.58-0.72-4.97l-0.9-1.07c-0.65-0.66-0.16-1.66,0.34-2.68c0.82-1.68,1.66-3.38,0.52-5.4
			c-0.96-2.92-3.4-2.32-5.52-1.8c-0.25,0.06-0.5,0.12-0.71,0.17c-1.77-0.86-3.72-1.33-5.65-1.3c-2.11,0.03-3.99,0.61-5.81,1.86
			c-0.29-0.25-0.58-0.47-0.88-0.7l0,0c-0.38-0.28-0.76-0.57-1-0.87c-0.28-0.79-0.2-1.78-0.12-2.76c0.11-1.39,0.23-2.77-0.39-4.27
			c-0.79-2.13-0.46-5.23,0.2-7.81H343.9l-0.04,3.49c-0.41-0.33-0.83-0.66-1.26-0.97c-1.09-0.78-3.89-2.36-5.21-2.28
			c-2.94,0.17-5.99,0.4-8.63,1.97c-2.87,1.52-5.88,2.45-8.53,4.62c-1.61,1.32-1.75,3.63-1.82,5.27c-0.11,2.4-0.26,2.78-1.71,3.83
			l-0.04,5.82c-0.33,0.59-0.7,1.16-1.07,1.73c-1.24,1.9-2.48,3.81-2.52,6.35c-0.22,2.77,1.19,3.59,2.65,5.38
			c-0.06,0.63-0.16,1.35-0.43,1.84l-1.93-1.82l-0.99,1.48c-2.48,3.7-1.75,8.38-1.84,8.69l-0.35,0.49c-1.09-0.92-1.23-1.11-2.13-2.45
			c-1.04-1.53-1.23-1.71-2.46-2.97c-2.63,1.59-3.08,2.15-2.76,5.5c0.25,2.71-0.51,2.29-0.72,2.74l-0.12,2.35l-3.54,2.98l0.72,3.05
			c0.18,0.6,0.38,1.18,0.61,1.74l0.02,8.63c-2.65,1.35-3.65,1.19-6.23,1.94c-0.07-0.57-0.3-1.14-0.83-1.71l-0.58-0.68
			c-2.45-2.87-2.87-3.43-3.75-6.69l-1.38,0.28c-1.45,0.29-2.78-0.91-3.59-2.01c-1.75-2.41-3.88-3.96-5.88-5.97
			c0.77-1.23,1.58-2.44,2.59-3.33c0.82-0.16,1.65-0.28,2.49-0.4l5.29-1.03l-0.82-1.69c-1.66-3.44-5.32-5.29-5.91-8.33
			c0.93-0.84,2.15-1.39,3.37-1.93c2.29-1.02,2.54-1.24,4.51-2.55c-3.72-4.22-7.19-7.72-11.05-11.74l-4.12,0.57
			c-0.76,0.1-0.52-0.04-1,0.56c-1.77,2.23-5.67,2.66-7.99,4.85c-0.86,0.81-2.18,0.95-3.56,1.1c-2.03,0.22-2.85,0.48-4.81,0.94
			l1.46,1.51c-1.18,0.79-2.51,1.46-3.84,2.12l-2.74,1.44c-0.1,0.09-1.87,3.16-2.54,3.53c-0.9,0.49-5.17-0.22-6.69,3.04
			c-1.4,3-3.82,5.7-6.99,6.84c-1.29,0.39-2.8-0.12-4.24-0.61l-1.43-0.47c-1.25,0.78-2.99,2.18-4.08,1.92l0,0
			c-2.28-0.55-4.33-1.41-6.78-1.56c-2.43-0.17-4.18-3.16-7.97-3.09c-1.88,0.04-3.36-1.09-5.05-2.09c-0.13-2.43-0.83-4.7-2.05-6.82
			l-0.28-0.49c-0.09-0.08-4.38-1.34-5.27-2.31c-0.72-0.79-0.54-3.28-2.46-5.31c-0.81-0.85-2.08-2-2.17-2.84l-0.06-0.27
			c-0.56-1.83-0.3-3.68-2.18-5.45l-3.11-2.75l-3.64-3.44l-3.82,1.21l-0.78,3.94l-1.42,1.7c0.34,2.34,0.15,4.21-1.66,5.98
			c-5.21-1.02-4.97-1.28-10.5-1.02c1.69,3.6,2.2,4.56,2.32,8.69l2.68,1.36c-0.95,3.07-2.28,6.01-1.31,9.46l0.13,0.47l2.21,1.8
			c-0.46,1.47-0.98,2.95-0.96,4.62l0.55,1.99c0.73,2.07,0.68,2.15,0.15,3.7c-1.07,3.14-1.12,3.56-1.57,6.65l5.5-0.3
			c0.02,0.56,0.03,1.12-0.04,1.61c-0.13,0.31-1.68,1.43-2.08,1.78c-0.51,0.44-0.39,0.22-0.5,0.9c-0.7,4.13-6.04,6.49-6.29,12.04
			l-0.06,1.22l4.15,1.08c0.39,0.24,1.37,1.83,3.34,2.77c0.76,0.37,2.92,1.13,2.96,1.64l-1.95,3.19c0.79,1.1,1.42,1.88,1.46,3.32
			c0.04,1.6-0.71,2.57-1.51,3.88c1.52,1.03,2.74,1.81,4.16,3.08c0.87,0.78,1.67,1.61,2.37,2.51c0.39,0.71-0.47,2.63-0.75,3.55
			l-0.56,4.59l1.84,1.39c0.87,0.52,0.95,0.55,0.93,0.89c-0.25,5.12-0.17,4.83-2.89,8.36c2.04,0.31,3.99,0.39,5.64,1.77
			c0.71,0.59,1.27,1.35,1.59,2.24c0.02,0.45-2.09,4.33-2.09,4.88l2.76,6.67l3.39-1.16c2.15,2.68,0.81,4.13,0.79,4.46l0.61,2.12
			c1.57,5.09,0.89,5.12-1.76,9.24c3.63-0.83,4.36-1.11,8.29-1.43l-0.18,0.47c1.52,1.5,3.65,3.67,4.39,5.7
			c0.77,2.12,2.06,1.88,4.15,2.8c2.83-1.2,4.71-1.27,7.79-1.26l0.78,0.92c0.46,0.54,0.22,0.41,0.91,0.53
			c1.39,0.23,2.67-0.12,3.77-0.03c-2.25,2.32-5.74,2.85-8.83,3.37c0.1,2.68,0.09,3.04-2.04,4.96l0.26,0.91l2.24,6.31l1.59,0.59
			c0.29,0.08,0.57,0.06,0.65,0.1l-0.24,3.19l1.75,1.37c-0.99,0.79-1.25,1.92-1.55,3.02c-0.54,0.02-1.08,0.01-1.61,0
			c-0.92-0.02-0.7-0.11-1.23,0.26c-1.19,0.83-3.01,0.38-4.46,0.12l-2.12,2.47l0.59,3.42c-0.31,0.26-2.14,0.53-2.74,0.66
			c-0.77,1.54-1.05,1.76-2.69,2.97l-2.82,2.47c0.88,1.31,3.26,4.6,1.49,5.87c-0.46,0.33-0.96-0.02-1.85-0.62l-4.57-2.52l1.97,5.37
			l-0.59,0.75l-3.34,0.14l1.07,4.93l0.68,0.3c0.82,0.36,2.67,0.78,2.65,1.39c-0.04,1.44-0.15,2.86-0.64,4.19
			c-0.62,1.67-1.39,2.21-2.82,2.9l-1.79,5.25l3.12,1.15c1.34,3.82,2.27,8.12,5.95,10.59l-0.12,0.15l1.91,0.9l0.15-0.22l2.15,0.74
			c0.02,0.01-0.07,0.5-0.12,0.98c-0.13,1.35-0.07,1.43,0.15,2.66c0.82,0.25,1.39,0.37,2.12,0.87c0.24,0.17,0.48,0.36,0.7,0.57
			l-0.06,1.44l0.11,0.62c1.38,3.36,5.3,4.96,4.6,7.75c-0.15,0.62,0.27,0.77-1.71,1.33l-5.21,1.9l4.31,1.34
			c-0.22,1.77-0.64,2.87-1.17,4.56l3.32-0.05c2.5-0.07,5.11-0.14,7.05,1.22l0.28,0.16c3.63,1.52,5.87,5.41,9.62,7.93
			c1.79,1.22,3.2,2.95,4.62,4.67c1.21,1.48,2.42,2.96,3.94,4.25c2.75,2.51,5.22,1.25,8.14,0.41l0.48,0.64
			c1.97,2.58,1.93,3.01,0.97,4.98l0.68,0.75c2.73,3.01,2.45,3.25,1.27,5.64l1.35,0.67c1.66,0.82,2.68,2.63,3.65,4.37l1.11,1.98
			c0.87,1.68,0.96,2.32,2.39,4.05c0.49,0.6,1.45,1.67,1.33,2.16c-0.63,2.69-4.05,9.13-4.79,12.44c-1.01,4.57-0.89,11.38-0.84,16.39
			c3.22-0.06,6.38-0.15,9.6,0.28l-1.04,17.85l0.96,0.42c0.79,0.35,2.8,0.83,3.05,1.22l1.09,4.16c0.33,0.49,3.35,2.1,4.17,3.9
			c1.01,2.21,1.34,5.32,2.06,7.83c-0.3,0.1-0.6,0.24-0.9,0.42c-2.24-1.49-4.53-2.95-7.26-3.69c-0.7-0.19-0.43-0.22-1.08,0.12
			l-3.51,1.7l-0.55,0.43c-2.79,3.49-0.99,7.13,0.17,10.54c0.6,1.82,1.81,2.79,2.84,4.1c-1.36-0.28-2.73-0.54-4.19-0.52
			c-1.64,0.03-4.45,2.24-5.91,3.15c-1.67,0.92-2.23,2.45-2.78,3.92l-1.04,2.42c2.77,1.24,3.22,1.38,6.53,0.79
			c1.35-0.24,2.66-0.48,3.45,0.28c0.14,1.38,0.57,2.59,1,3.81c0.62,1.76,0.95,2.65,0.81,4.36c-0.4,5.11,4.54,8.38,4.54,8.38
			c0.27,1.39,0.61,2.72,0.95,4.06c0.48,1.9,0.97,3.8,1.2,5.69l0.06,0.49c0.02,0.04,1.45,1.38,2.33,3.26c0.5,1.06,3.36,3.02,3.31,5.33
			c-0.08,3.91,1.75,7.35,3.45,10.54c1.04,1.95,1.11,2.33,2.5,4.27c1.09,1.5,2.21,3.06,1.27,4.5l-0.45,0.69
			c1.21,2.64,2.41,4.85,4.53,6.95c4.37,4.33,7.9,3.47,8.73,4.1c0.3,0.23,0.59,0.46,0.85,0.7l-4.04,1.47
			c2.32,2.16,3.36,2.91,4.61,6.04l0.5,0.65c2.11,1.57,3.04,3.82,4.01,6.14l3.47-0.71l0.75,0.57c0.7,1.92,2.14,3.17,3.53,4.38
			l0.11,0.1c1.26,1.67,2.81,3.05,4.52,4.19c1.66,1.1,3.47,1.98,5.31,2.67c0.73,0.42,2.72,2.71,3.44,3.64l-0.44,0.01l-2.4,2.42
			l0.18,0.8c1.02,4.61,4.98,7.36,5.1,7.59c0.1,1.23,0.12,2.47,0.09,3.71c-0.03,1.22-0.12,2.45-0.24,3.7l-1.05,0.78l-4.14-2.77
			l-1.99,7.95l3.98,2.68l0.11,0.57l-0.96,1.48c1.71,2.81,3.98,6.02,3.56,9.24l-0.1,0.74l3.94,3.58c2.57,2.18,5.16,4.36,6.44,7.36
			c0.24,0.94-0.19,8.22-0.03,8.59l4.19,3.98c0.49,0.46,0.26,0.36,0.94,0.4c1.79,0.1,4.94,2.03,6.77-1.29l0.47-0.84
			c-1.39-1.89-2.42-3.59-2.59-6.11c-0.15-2.24,0.48-3.38,1.73-4.94l-0.7-2.35c0-0.06,0.86-1.85,0.78-5.01l0.14,0.07
			c1.77,1.2,2.82,0.07,3.8-0.98l1.34-1.06c-0.42-1.12-1.5-3.58-1.59-4.44c0.3-0.27,0.62-0.54,0.95-0.81v-0.01l0.96-0.8
			c-0.13-1.95-0.12-3.31,0.49-5.21c0.41-1.3,1.05-2.54,1.9-3.66l3.33-0.67l1-1.59c1.08-0.02,2.16-0.04,3.15,0.17
			c0.27,1.39,1.05,2.46,1.83,3.54l1.49,2.54l2.95,0.08c1.81,1.64,1.79,4.69,1.78,7.36l0,0.67c-0.15,0.48-2.68,2.35-3.35,3.39
			c-1.62,2.55,0.72,5.38,0.87,5.99l-0.41,5.04l3.05,1.35c-0.14,2.73-0.48,5.08-0.9,7.67h117.4c0.89-0.95,1.74-1.94,2.53-3.02
			c1.78-2.4,4.39-4.48,6.48-6.81c2.17-2.34,3.81-4.95,5.7-7.47l0.65,1.02c1.69-2.49,1.64-2.7,4.37-4.64c1.55-1.1,3.11-2.21,4.18-4.04
			c2-1.2,4.14-2.56,5-5.16l0.54-1.81c1.01-3.44,2.05-6.94,4.11-9.72c0.86,1.06,1.91,1.9,2.95,2.74l1.66,1.39l1.94,0.46l0.21,0.07
			c-0.86,2.94-0.79,5.86-2.52,8.28c-1.76,2.46-2.51,4.14-3.42,6.96l0.64,0.65c1.16,1.18,2.65,1.88,2.67,3.19
			c0.07,4.53,0.33,10.76,0.86,15.05l0.2,0.86c0.15,0.65,0.3,1.35,0.57,1.97h227.77v-20.36L749.69,551.97z" />
                        </svg>
                        <svg class="map-sea">
                            <path class="map-sea" id="urumia-lake" d="M194.99,87.71c1.36-2.6,4.59-0.32,6.58,0.2
			l0.08,0.06c0.04,0.02,0.1,0.06,0.12,0.1l0.06,0.04c0.39,1.64,1.83,2.25,3.23,2.76c0.12,0.3,0.41,0.93,0.53,1.26
			c0.35,0.18,0.99,0.59,1.34,0.79c0.2,2.42,0.49,4.89-0.24,7.27l-0.81,0.49c-0.51,0.1-1.5,0.26-2.01,0.36
			c0.18,2.11,0.49,4.24,0.93,6.33c1.6,0.43,2.74,1.6,3.92,2.68c1.46,0.69,3.55,0.45,4.24,2.21c0.81,0.02,1.64,0.04,2.46,0.06
			c0,1.06-0.02,2.11-0.02,3.17c-1.22,0.02-2.44,0.06-3.63,0.1c0.02,0.41,0.04,1.18,0.06,1.56c0.43,0.12,1.3,0.32,1.73,0.45
			c0.3,1.28,0.63,2.56,0.93,3.84c0.99,0.08,1.97,0.14,2.96,0.22c-0.39,1.18-0.77,2.37-1.16,3.57c-1.24,0.53-2.76,0.79-3.39,2.13
			c-1.56-0.1-3.13-0.28-4.69-0.41c0.04,1.6,0.06,3.23,0.12,4.85c-3.21-1.14-7.08-1.08-9.42-3.94c0.26-5.81-0.65-11.55-0.69-17.33
			c0-1.99-0.28-3.96-0.55-5.93c-1.3-0.22-2.62-0.47-3.94-0.71c-0.51-2.11-1.08-4.79,1.28-6.01l0.57-0.22
			c0.95-0.14,1.52-0.65,1.68-1.52l0.1-0.43c0.16-0.65,0.34-1.3,0.55-1.95c-1.6-0.14-3.19-0.3-4.77-0.51
			C193.59,91.38,193.89,89.37,194.99,87.71z" />
                            <path class="map-sea" id="persian-gulf" d="M346.52,545c-0.22-3.45,0.85-6.78,3-9.46c1.06-0.47,2.21-0.55,3.33-0.77
			c0.37-0.59,0.73-1.16,1.1-1.73c1.81-0.02,3.65-0.16,5.38,0.51c-0.04,2.29,1.97,3.8,2.88,5.74c0.85,0.02,1.68,0.04,2.54,0.08
			c3.08,2.25,2.7,6.54,2.72,9.92c-0.81,1.56-2.54,2.38-3.57,3.78c-0.93,1.73,0.45,3.29,1.08,4.83c0.12,1.5-0.18,2.98-0.3,4.47
			c0.99,0.45,1.99,0.87,3,1.3c-0.07,2.5-0.35,4.98-0.73,7.43h114.77c0.79-0.86,1.54-1.74,2.23-2.68c1.91-2.58,4.47-4.57,6.6-6.94
			c2.6-2.8,4.51-6.15,6.96-9.07c0.12,0.22,0.39,0.69,0.53,0.91c1.93-2.84,5.74-3.82,7.39-7.02c1.87-1.12,3.96-2.33,4.69-4.55
			c1.46-4.79,2.62-9.92,6.27-13.58c1.04,2.31,3.29,3.63,5.12,5.26c1.16,0.22,2.27,0.55,3.33,1.1c-1.34,3.25-0.99,7.12-3.21,10.03
			c-1.24,1.72-2.25,3.61-2.9,5.64c1.2,1.22,3.19,2.21,3.11,4.2c0.16,4.97,0.24,9.99,0.85,14.92c0.14,0.52,0.25,1.18,0.45,1.79H748.6
			v-16.58c-2.03-0.28-3.96-0.99-5.92-1.5c-1.46,0.55-2.38,2.33-4.12,2.11c-3.19,0.41-6.21-1.04-9.38-0.77
			c-2.4,0.08-4.79-0.2-7.18-0.39c-0.71,1.1-1.38,2.19-2.05,3.31c-0.83,0.02-1.64,0.06-2.46,0.1c-0.41,0.95-0.79,1.95-1.12,2.94
			c-0.59-1.02-0.75-2.34-1.66-3.13c-2.23-0.81-4.59-0.28-6.54,0.93c0.32,1,0.69,1.99,1.06,3c-2.66-0.26-5.34-0.24-7.94,0.41
			c-0.12,0.79-0.24,1.6-0.36,2.44c-1.1,0.14-2.17,0.3-3.25,0.49c-0.43-0.24-1.28-0.75-1.68-1c0.34-1.32,0.73-2.62,1.14-3.92
			c-0.91-0.12-1.83-0.24-2.72-0.39c-1.14-0.16-2.54-1.68-3.49-0.73c-1.46,0.75-0.43,2.05-0.04,3.17c-3.45,3.08-9.09,2.01-12.56-0.51
			c-5.83-1.5-12.08-0.81-17.7-3.09c-0.35-1.36-0.59-2.74-1.14-4.02c-1.79-1.67-4.67-1.22-6.21,0.53c0.59,0.59,1.06,1.28,1.4,2.03
			c-0.45,0.61-0.91,1.2-1.38,1.79c-1.6-1.06-3.19-2.13-4.87-3.04c-0.99,0.95-2.01,1.89-3.02,2.82c-0.87-0.77-1.75-1.54-2.56-2.33
			c-2.05-0.73-3.73,0.55-5.38,1.56c-1.38,0.04-2.03-1.46-2.94-2.23c-2.31-0.06-4.65,0.12-6.86,0.79c-2.11-0.95-4.04-3.35-6.56-2.37
			c-3.96,1.58-7.86,3.83-12.26,3.73c-1.87-0.87-2.78-2.92-4.34-4.18c-1.99-1.01-4.14-2.03-6.43-1.87c-2.11,0.14-4.18-0.26-6.13-1.06
			c-0.91,0.26-1.83,0.51-2.7,0.79c-3.53-1.1-6.62,1.54-9.7,2.8c-3.31-0.33-4.67-3.63-6.43-5.97c-1.81,0.18-3.51,0.77-5.22,1.36
			c-0.87-1.01-1.6-2.13-2.4-3.19c-0.97,0.28-1.97,0.57-2.94,0.85c-3-0.91-6.25-0.18-9.25-1.08c-2.98-1.72-2.4-6.09-5.54-7.71
			c-1.14-2.37-1.28-4.99-0.41-7.49c-1.81-1.85-3.88-4.06-3.11-6.88c-0.43-0.91-1.28-1.72-1.22-2.78c0.41-1.24,1.3-2.33,1.4-3.67
			c-0.49-2.66-1.83-5.03-2.52-7.63c-0.61-2.44-2.29-4.34-3.53-6.48c-1.6-2.88-4.65-4.55-7.59-5.74c-3.04-0.3-6.17-0.2-9.09-1.2
			c-2.58-1.02-5.6-0.91-8.1,0.14c-2.39,2.13-4.47,4.77-7.47,6.09c-2.9,0.3-5.95,0.22-8.67,1.42c-2.11,1.46-0.95,4.34-1.18,6.47
			c-1.4,0.45-2.78,0.97-4.2,1.36c-2.29,0.55-4.65-0.16-6.94,0.02c-1.38,0.75-2.68,1.66-4.1,2.33c-3.92,1.93-6.7,5.5-10.47,7.63
			c-0.81-0.14-1.58-0.37-2.37-0.55c-0.83,0.28-1.66,0.55-2.5,0.81c-1.26-0.33-1.89-1.5-2.64-2.44c-1.66-0.37-3.45-0.41-5.03-1.12
			c-1.68-1.46-2.5-4.83-5.22-4.26c-1.91,0.29-3.9,0.18-5.44-1.07c-1.12-0.06-2.21-0.1-3.31-0.14c-0.3,0.28-0.91,0.85-1.2,1.12
			c-2.44-0.04-4.87,0.2-7.27-0.16c-1.87-1.04-3.51-2.42-5.42-3.41c-2.35-1.22-2.48-4.2-3.84-6.19c-4.77-2.11-10.27-2.84-14.41-6.23
			c-2.11-1.77-4.53-3.11-6.6-4.93c-1.99-1.91-4.83-2.27-7.14-3.63c0.16-0.49,0.51-1.46,0.67-1.95c1.1-0.1,2.17-0.18,3.27-0.26
			c-2.44-1.77-4.06-4.32-6.27-6.31c-1.75-1.64-4.47-0.93-6.47-2.03c-2.62-1.54-4.87-3.63-7.02-5.74c-2.38-0.02-4.75-0.14-7.06-0.75
			c-2.35-0.08-4.71,0-7.06-0.33c-1.26-1.44-2.58-2.88-4.38-3.59c-2.6-0.97-3.37-3.98-5.68-5.36c-0.37-1.5-0.08-3,0.37-4.47
			c-1.68-3.21-3.98-6.05-5.36-9.44c-1.85-2.78,0.16-6.29-1.44-9.17c-0.99-2.52-4.34-2.19-5.87-4.18c-0.85-1.12-1.26-2.46-1.75-3.73
			c1.28-1.44,4.3-2.52,3.17-4.87c-1.93-1.75-4.57-1.83-7-1.68c-0.39-0.71-0.81-1.4-1.12-2.15c0.43-0.77,0.99-1.48,1.5-2.21
			c-1.08-2.11-0.79-4.44-0.37-6.68c-3.15-1.46-4.57-4.75-6.88-7.1c-3.09-3.25-5.14-7.29-7.92-10.76c-0.77-0.91-0.3-2.21-0.37-3.27
			c0.39-2.31-1.26-4.3-2.7-5.91c-2.88-1.4-5.81,0.59-8.26,1.99c-1.85,1.79-3.71,3.69-6.15,4.65c-2.88-0.3-3.19-3.88-4.36-5.95
			c-2.09-0.24-4.2-0.08-6.29,0.12c-0.16-1.26-0.32-2.52-0.49-3.78c-2.48,0.33-5.52-0.73-6.23-3.37c0.22-1.54,1.97-1.93,3.08-2.7
			c0.26,0.12,0.79,0.41,1.06,0.55c1.08-0.55,2.5-0.61,3.33-1.52c-0.14-0.96-0.39-1.89-0.73-2.8c-1.46-0.37-1.36,1.26-1.73,2.19
			c-1.66,1.3-3.35,0.29-4.81-0.77c-1.34,1.16-1.75,3-2.6,4.5c3.19,2.27,3.19,6.52,1.83,9.82c-1.2,1.04-2.74,1.56-4.16,2.19
			c-2.13-0.53-4.28-1.26-5.72-3.02c0.55,1.4,0.26,2.9-0.91,3.9c-2.78,0.91-6.05-2.11-8.36,0.3c-2.44-1.62-4.87-3.33-7.73-4.1
			c-1.18,0.61-2.38,1.18-3.57,1.73c-2.25,2.82-0.59,6.17,0.43,9.13c0.81,2.46,3.69,3.69,3.8,6.52c-2.19-0.24-4.34-1-6.56-0.96
			c-1.93,0.51-3.47,1.89-5.13,2.92c-1.62,0.85-1.93,2.8-2.62,4.3c3.13,1.4,7.19-2.01,9.44,1.24c0.12,3.07,2.25,5.68,1.85,8.83
			c-0.16,3.13,1.87,5.83,4.4,7.41c0.61,3.53,1.85,6.92,2.27,10.47c0.91,0.97,1.68,2.07,2.25,3.29c1.48,1.77,3.55,3.51,3.45,6.03
			c-0.04,4.43,2.52,8.16,4.4,11.95c1.36,2.54,4.59,5.03,2.58,8.12c1.79,3.9,4.65,7.55,8.91,8.83c1.06,0.16,2.13,0.38,3.17,0.61
			c1.04,0.81,2.21,1.54,2.5,2.94c-1.12,0.45-2.23,0.89-3.37,1.3c1.46,1.36,2.44,3.06,3.17,4.89c1.91,1.42,3.11,3.45,4.02,5.62
			c0.97-0.2,1.97-0.41,2.94-0.59c0.55,0.41,1.1,0.83,1.66,1.26c0.53,1.89,2.05,3.13,3.47,4.36c2.33,3.17,5.83,5.22,9.46,6.56
			c2.21,1.75,3.98,4.06,5.56,6.37c-0.65,0.04-1.97,0.08-2.64,0.1c-0.35,0.37-1.06,1.06-1.42,1.42c0.67,3.02,2.78,5.26,5.07,7.17
			c0.3,2.98,0.16,6.01-0.16,8.99c-0.81,0.57-1.62,1.18-2.44,1.81c-1.08-0.75-2.17-1.48-3.27-2.21c-0.43,1.6-0.81,3.23-1.2,4.85
			c1.22,0.79,2.41,1.62,3.63,2.48c0.08,0.42,0.26,1.32,0.35,1.75c-0.2,0.3-0.57,0.91-0.77,1.22c1.75,2.88,3.73,5.85,3.27,9.4
			c3.55,3.55,8.3,6.25,10.27,11.1c0.32,2.76-0.12,5.54-0.02,8.32c1.22,1.2,2.48,2.35,3.73,3.53c1.77,0.1,4.22,1.58,5.38-0.51
			c-2.37-3.23-3.43-8.14-0.75-11.49c-0.16-0.53-0.47-1.6-0.63-2.13c1.1-2.33,0.97-4.91,0.67-7.39c0.85,0.41,1.73,0.81,2.6,1.22
			c1.08,0.79,1.83-0.75,2.58-1.28c-0.55-1.46-1.42-2.9-1.28-4.51C345.24,546.04,345.89,545.53,346.52,545z M519.93,524.71
			c1.89,0.12,3.86,0.61,5.66-0.22c-0.04,0.79-0.08,1.6-0.16,2.4c-0.97,0.71-2.13,1.08-3.21,1.58c0.63,0.16,1.85,0.49,2.48,0.65
			c0.38,1.06,0.2,2.21,0.34,3.33c-2.21,0.08-4.14-1.16-6.15-1.89c0.51-0.77,1-1.54,1.5-2.31C519.77,527.1,519.6,525.92,519.93,524.71
			z M269.43,401.16c-1.06,1.68-2.7,2.88-4.12,4.24c-2.13-1.85-4.91-3.88-4.83-7.02c0.06-1.32-0.3-2.92,0.69-3.98
			c1.34-0.95,3.06-0.65,4.61-0.79c1.24,1.4,2.46,2.84,3.71,4.24C269.51,398.95,269.65,400.07,269.43,401.16z M330.52,535.65
			c0.1-2.15,0.02-4.3-0.12-6.43c1.48-0.77,3.1-1.26,4.77-1.2c0.63,3.76,0.24,7.65,0.75,11.45L330.52,535.65z" />
                            <path class="map-sea" id="khazar" d="M445.6,151.38c-0.81-8-4.38-15.47-4.51-23.59c-3.29-5.72-1.81-12.5-1.56-18.75
			c0.02-2.64,1.87-5.03,1.2-7.69c-0.53-3.31-1.28-6.66-0.73-10.03c0.32-2.58,2.01-4.73,2.35-7.29c0.22-1.3,0.59-2.56,1.04-3.8
			c-0.1-2.35-1.22-4.45-2.98-5.99c-0.53,0.04-1.56,0.12-2.07,0.16c-2.74-1.62-2.86-5.38-6.05-6.47c-0.51-1.58-0.89-3.67-2.64-4.34
			c-2.44-0.81-4.85-1.62-7.18-2.66c-0.1,1.89-0.14,3.78-0.14,5.64c-0.26,0.31-0.79,0.87-1.05,1.18c0-1.89-0.02-3.75-0.08-5.64
			c-1.22-1-1.95-2.72-0.83-4.1c1.99-2.88,2.84-6.53,5.7-8.73c-0.81,1.72-1.58,3.47-2.15,5.32c2.42-0.3,4.91-0.1,7.27-0.81
			c1.44-1.52-0.87-2.72-1.6-3.96c-2.66-2.7,2.35-5.6,0.55-8.52c-0.67-2.31-3.51-0.83-5.11-0.69c-3.21-1.71-7.14-1.97-10.21,0.14
			c0.89,2.96,3.19,5.11,4.57,7.79c-2.56-1.79-4.18-4.5-5.89-7.04c-0.75-1.14-2.13-1.6-2.88-2.72c-0.97-2.31,0.39-4.87-0.57-7.18
			c-0.77-1.81-0.72-5.05-0.12-7.07H345.4c-0.04,1.67-0.06,3.85-0.08,5.52c-2.23-2.15-4.73-4.38-7.83-5.09
			c-2.7,0.16-5.56,0.35-7.96,1.77c-2.78,1.48-5.87,2.46-8.34,4.49c-2.4,2.39-0.04,6.58-3,8.73c-0.04,1.81-0.04,3.61-0.02,5.42
			c-1.32,2.54-3.59,4.77-3.59,7.82c-0.37,2.07,1.71,3.31,2.7,4.83c-0.14,1.69-0.32,3.47-2.03,4.28c-0.41-0.38-1.22-1.14-1.62-1.52
			c-1.64,2.46-1.73,5.44-1.56,8.3c-0.95,1.34-1.91,2.66-2.88,4c-0.91,0.04-1.83,0.08-2.74,0.1c0.39-1.34,1.4-2.29,2.27-3.33
			c-1.4-1.18-2.11-2.94-3.37-4.24c-2.46,1.48,0.28,5.01-1.77,7c-0.04,0.79-0.08,1.58-0.12,2.39c-1.1,0.97-2.21,1.95-3.35,2.86
			c0.26,1.32,0.65,2.64,1.18,3.88c0.04,3.81,0.16,7.63-0.08,11.43c-0.59,7.35-0.2,14.71,0.79,22c1.64,5.2,6.45,8.28,11.24,10.23
			c3.94,1.34,8.12,1.79,12.2,2.54c1.26,0.38,2.42-0.31,3.59-0.63c2.35,1.99,5.4,2.6,8.28,3.43c0.18,0.34,0.59,1.04,0.79,1.38
			c-0.41,2.09-0.08,4.26,1.03,6.11c1.58,3.19,5.16,4.42,7.79,6.56c3.84,3.09,7.59,6.33,11.77,8.95c3.47,1.73,7.25,2.86,11.06,3.55
			c3.13,0.69,6.03,2.21,9.23,2.64c6.09,1.14,12.24-0.31,18.1-1.93c4.22-0.65,8.52-0.87,12.71-1.76c5.76-2.05,11.51-4.87,17.76-4.71
			c5.18-0.04,10.37-1.12,15.51-0.2c-2.94,0.43-5.95,0.2-8.91,0.59c-0.12,1.18,1.16,1.5,2.05,1.54c2.42,0.12,4.87,0.16,7.25-0.43
			C444.3,152.74,445.87,152.72,445.6,151.38z M419.67,83.69c-1.73-2.09-1.58-5.01-2.25-7.51c-0.06-1.4-0.73-4.3,1.56-3.86
			C418.57,76.16,420.17,79.88,419.67,83.69z" />
                        </svg>
                        <svg class="map-island">
                            <path class="map-island" d="M267.93,400.45c-0.72,1.15-1.85,1.97-2.82,2.9c-1.46-1.26-3.36-2.65-3.3-4.8c0.04-0.9-0.21-2,0.47-2.72
			c0.91-0.65,2.09-0.44,3.15-0.54c0.85,0.96,1.68,1.94,2.54,2.9C267.99,398.94,268.08,399.7,267.93,400.45z" />
                            <path class="map-island" d="M520.65,525.72c1.31,0.08,2.75-0.04,4.09-0.27c-0.09,0.43,0.08,0.62,0.03,1.17
			c-0.68,0.49-2.81,1.5-3.56,1.85c0.44,0.11,2.4,0.99,2.84,1.1c0.27,0.73,0.06,0.74,0.16,1.51c-1.53,0.05-2.58-0.63-3.98-1.14
			c0.35-0.54,0.52-1.12,0.87-1.65C520.66,527.5,520.43,526.56,520.65,525.72z" />
                            <path class="map-island" d="M331.2,534.68c0.07-1.41,0.01-2.83-0.08-4.23c0.97-0.51,2.04-0.83,3.13-0.79c0.41,2.47,0.16,5.03,0.49,7.52
			L331.2,534.68z" />
                        </svg>

                        <!-- Start Province -->
                        <a class="map-link" xlink:href="#khorasan-r">
                            <svg class="map-province khorasan-r" id="svg-object-khorasan-r">
                                <path class="map-path" id="path-khorasan-r" d="M651.38,201.47
			c2.54-3.43,3.84-7.55,4.99-11.61c-1.44-0.71-2.58-1.81-3.15-3.33c1.54-2.48,1.44-5.48,0.61-8.16c-0.97-0.26-1.93-0.51-2.84-0.87
			c-0.69-2.07,1.36-3.63,1.62-5.6c0.3-3.13-1.4-5.95-2.62-8.71c0.61-2.54,0.63-5.16,0.79-7.75c-0.63-0.63-1.24-1.28-1.83-1.91
			c-6.29,0.65-12.6,0.65-18.9,1.18c-1.26,0-2.7,0.28-3.71-0.63c-1.12-1.72-1.56-3.94-3.39-5.13c-2.86-1.89-3.53-5.46-5.5-8.08
			c-3.8,0.61-6.64-3.13-10.43-2.4c-1.44,0.51-1.93-1.01-2.66-1.89c-1.1,0.02-2.27,0.41-3.27-0.2c-0.59-0.69-0.57-1.68-0.83-2.5
			c-0.95-0.81-2.03-1.5-2.82-2.46c-0.79-1.81-0.73-3.84-1.06-5.76c-0.97,0.02-2.07,0.43-2.94-0.22c-2.35-1.4-4.57-3.04-6.82-4.59
			c-1.5-0.06-2.98-0.22-4.44-0.53c-1.04,0.61-2.05,1.24-3.13,1.77c-1.54-0.3-2.72-1.46-4.02-2.25c-0.73,0.89-1.24,2.09-2.33,2.58
			c-1.58,0.22-3.15-0.45-4.67-0.71c0.73,1.22,1.58,2.39,2.13,3.71c0.24,2.17-0.37,4.32-0.24,6.52c0.1,2.27,2.72,3.86,2.05,6.23
			c-0.97,2.25-3.8,2.15-5.78,2.86c-0.14,2.35,0.93,4.4,1.91,6.45c0.67,3.45-3.59,3.88-5.74,5.28c0,2.29,0.24,4.63-0.2,6.88
			c-0.85,1.93-2.84,3.74-5.09,3.35c-4.1-0.47-7.55-2.98-10.55-5.64c-5.28-4.28-12.48-3.78-18.85-3.69c-2.11-0.1-4.16,0.89-5.42,2.6
			c1.54,2.07,3.51,4.45,2.78,7.22c-0.16,2.19-2.07,3.63-2.68,5.62c-0.02,3.84,0.57,7.67,1.02,11.49c0.26,2.01-0.49,4.4,1.16,5.99
			c1.44,2.11,3.96,3.29,5.2,5.52c0.93,3.69,1.48,7.75,0.22,11.45c-1.2,1.89-3.49,2.68-4.99,4.28c-2.33,2.48-5.36,4.12-7.79,6.49
			c-1.95,1.99-4.89,1.97-7.47,2.44c-2.09,3.19-4.67,6.01-6.94,9.05c5.62,0.71,11.55,0.89,16.95-1.05c4.14-2.48,5.97-7.41,9.91-10.15
			c4.3-3.25,10.25-3.57,15.24-1.91c3.78,1.4,5.54,5.6,5.85,9.36c0.08,0.37,0.12-0.3,0.12,0.1c0.29,0.09,0.57,0.17,0.83,0.23
			c1.07,0.26,2.16,0.26,2.11,1.33c-0.05,1.21,1,2.26,2.21,3.46c0.94,0.94,2.12,2.1,2.2,2.96c0.28,2.72,1.32,4.69,2.17,6.27
			c0.4,0.74,0.74,1.38,0.94,1.98c0.84,2.5,5.05,3.16,7.16,3.16c0.32,0,0.6-0.02,0.84-0.04c0.42-0.05,0.84-0.08,1.24-0.08
			c3.02,0,4.89,1.35,5.92,2.45c2.5-1.03,4.38,0.08,6.97-0.67c5.48-1.4,11.1-0.47,16.64-0.24c4.02,0.41,8.08-0.04,12.1,0.51
			c4.45,0.45,8.93,2.03,12.22,5.18c4.18,0.04,7.37-2.96,10.59-5.24c3.1-2.19,4.71-5.99,7.96-8.04c1.69-0.29,3.43-0.2,5.11-0.55
			c-1.85-2.31-4.04-4.32-5.99-6.56c1.4-0.81,2.98-1.2,4.59-1.4c0.18-0.61,0.39-1.22,0.59-1.83c0.69-0.33,1.38-0.67,2.05-1.06
			c0.63-2.33,1.48-4.59,2.17-6.9c0.04-3.19,0.39-6.33,1.32-9.4C651.06,206.06,650.73,203.65,651.38,201.47z" />
                                <path class="map-point" id="point-khorasan-r" d="
        M651.38,201.47
        m -60, 10
      a 8,8 0 1,0 16,0
        a 8,8 0 1,0 -16,0
    " />

                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khorasan-j">
                            <svg class="map-province khorasan-j">

                                <path class="map-path" id="path-khorasan-j" d="M651.59,326.94c-0.79-2.86-1.22-5.82-1.18-8.79
			c0.06-2.17,0.89-4.24,0.99-6.39c-0.41-3.15-1.73-6.05-2.74-9.01c-2.44-6.84-4.85-13.68-7.33-20.52c-1.02-2.54-0.93-5.81,1.46-7.55
			c2.25-1.66,3-4.53,5.17-6.27c0.39-1.3,0.75-2.62,1.12-3.94c-3.77-0.57-8.56,0.06-11.16-3.35c-1.75-1.81-0.51-4.36,0.65-6.11
			c-0.89-3.73-1.85-7.49-1.42-11.35c-3.27,2.35-6.52,5.05-10.47,6.17c-0.71,0.28-1.36,0.24-1.97,0.03c0,0-0.01,0-0.01,0l-0.52,0
			l-0.3-0.29c-0.11-0.11-0.23-0.19-0.34-0.29c-0.77-0.49-1.51-1.12-2.25-1.54c-4.22-2.98-9.58-3.03-14.53-3.27
			c-5.5-0.1-10.98-0.49-16.48-0.75c-3.55,0-6.98,0.97-10.47,1.52c-0.32,0.06-0.53-0.09-0.68-0.37c-0.4,0.15-0.87,0.42-1.5,0.95
			l-0.85,0.7l-0.67-0.87c-0.86-1.12-2.84-3-6.4-3c-0.4,0-0.82,0.03-1.24,0.08c-0.23,0.03-0.52,0.04-0.84,0.04
			c-2.11,0-6.32-0.66-7.16-3.16c-0.2-0.59-0.54-1.23-0.94-1.97c-0.84-1.58-1.89-3.55-2.17-6.27c-0.09-0.86-1.26-2.02-2.2-2.96
			c-1.21-1.21-2.27-2.25-2.21-3.46c0.04-1.06,0.02-1.07-1.05-1.33c-0.39-0.1-0.84-0.2-1.34-0.4l-0.62-0.24l-0.05-0.66
			c-0.26-3.24-1.74-7.15-5.11-8.43c-0.21-0.05-0.4-0.09-0.55-0.14c-4.3-1.08-9.28-1.04-13.07,1.54c-4.12,2.6-6.09,7.43-9.99,10.25
			c-0.21,0.1-0.42,0.19-0.63,0.28c-0.01,0.01-0.03,0.02-0.04,0.03l-0.18,0.09c-0.04,0.01-0.08,0.02-0.11,0.03
			c-5.47,2.24-11.65,1.64-17.44,1.3c-5.34,5.2-5.38,13.54-10.39,19c-3.33-0.12-6.68-0.08-10.01-0.04c1.62,7.9,1.55,16.38,1.75,24.38
			c0.33,0.48,4.71,4.1,4.71,4.1l2.39,4.54c0,0,3.1,2.15,4.3,4.3c1.19,2.15,1.19,1.43,4.3,1.67c3.1,0.24,3.1,3.34,4.3,4.77
			c1.19,1.43,2.37,1.14,3.22,2.73c0.86,1.59,0.86,4.16,1.83,5.14c0.98,0.98,3.06,2.08,4.04,3.3c0.98,1.22,0.86,3.18,1.59,4.16
			c0.73,0.98,1.96,1.1,3.18,2.08c1.22,0.98,2.33,3.18,2.57,6c0.24,2.82,1.59,3.43,2.57,4.89c0.41,0.61,0.91,3.33,1.39,5.53
			c2.64-0.24,4.5-0.59,7.12-1.01c2.54,0.99,5.11,1.95,7.79,2.5c7.67,1.69,15.38,3.25,22.91,5.5c0.03-0.21,0.48-0.43,1.21-0.65
			c-0.04,0.29-0.08,0.59-0.13,0.88c3.61,2.25,7.77,3.65,11.08,6.45c6.23,5.24,12.5,10.41,18.79,15.59
			c6.33,6.19,12.08,12.95,18.35,19.22c4.3-2.23,8.99-4.55,11.37-9.03c0.83-3.29,1.22-6.7,1.7-10.05c3.21-0.69,6.47-1.2,9.72-1.7
			c1.14-2.11,1.93-4.46,3.43-6.37c4.73-3.08,9.58-6.01,14.39-8.97c0.04-1.95-0.06-3.92-1.36-5.48
			C651.27,329.46,652.14,328.24,651.59,326.94z" />

                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kerman">
                            <svg class="map-province kerman">
                                <path class="map-path" id="path-kerman" d="M522.24,325.05c3.31-0.14,6.6-1.14,9.9-0.81
			c8.57,3.17,17.76,4,26.47,6.7c4.97,1.28,9.56,3.65,13.88,6.37c4.89,3.92,9.6,8.04,14.49,11.97c8.77,6.72,15.67,15.43,23.24,23.36
			c1.28,1.18,2.88,1.91,4.14,3.11c1.3,1.26,1.28,3.17,1.5,4.83c1.2,12.93,1.87,25.9,2.7,38.85c1.48,2.62,2.84,5.32,3.98,8.12
			c-1.66,1.5-3.82,3.27-3.33,5.78c0.49,1.81,1.91,3.21,2.74,4.87c1.89,3.17,1.04,7,1.22,10.49c-4.75,1.32-10.33-1.64-14.55,1.79
			c-2.11,1.34,0.08,3.82,0.89,5.36c0.04,1.81,0.06,3.61,0.06,5.42c-3.51,0.04-5.66,2.98-7.06,5.85c-1.42,5.66,0.69,11.51-0.35,17.21
			c-0.47,1.91-1.77,3.61-1.54,5.68c0.16,2.88-0.49,5.7-0.65,8.57c0.57,1.32,1.44,2.52,1.97,3.88c0.28,2.01-0.16,4.1,0.41,6.07
			c1.4,1.93,3.41,3.39,4.65,5.48c0.63,1.66,0.57,3.53,0.41,5.3c-3.35,1.64-7.45,0.71-10.96-0.04c-0.35-3.41-3.31-5.5-6.15-6.84
			c-2.9-1.26-6.11-1.3-9.21-1.36c-3.13-0.06-4.87-3.09-7.55-4.24c-3.75-1.4-7.14-3.63-11.08-4.55c-1.99-1.6-3.39-3.98-5.74-5.22
			c-4.1-2.5-6.52-6.76-9.78-10.15c-0.57-2.21-0.63-4.53-1.12-6.76c2.01-2.42,5.16-3.61,6.88-6.29c-1.52-1.06-2.15-2.76-2.9-4.36
			c-2.72-1.32-5.89-1.54-8.61-2.94c-0.06-3.31,0.22-6.88-1.3-9.92c-1.34-1.1-3.15-1.48-4.83-1.71c-2.56,0.63-4.65,2.35-6.8,3.82
			c-1.44,0.91-2.74,2.48-4.61,2.31c-2.52,0.08-5.28-0.04-7.33-1.71c-1.6-1.28-3.29-2.46-4.93-3.67c-1.18-0.77-0.91-2.35-1-3.57
			c0.08-3.84-0.18-7.65-0.49-11.47c-0.08-1.64-0.91-3.11-1.81-4.42c-2.11,0.18-4.51-0.3-6.31,1.1c-2.96,1.73-5.42,4.49-8.87,5.28
			c-3.37,1.1-7.53-0.2-9.32-3.37c-0.43-4.28,1.99-8.89-0.08-12.93c-4.4-5.36-8.87-10.66-13.31-15.99c-1.91-2.52-5.36-1.97-8.14-2.23
			c0.1-4.14-0.35-8.28-0.47-12.44c-0.3-3.06-0.26-6.21-1.32-9.13c-0.65-1.79-2.9-2.21-3.67-3.84c0.65-2.94,2.94-5.14,4.02-7.9
			c-0.43-5.87-2.74-11.41-3.71-17.19c2.13-0.96,4.22-2.17,6.58-2.54c2.66,0.39,5.03,1.89,7.69,2.17c3.39-0.95,6.56-2.62,9.88-3.77
			c7.31-2.68,14.53-5.83,20.8-10.51c1.93-1.36,2.43-3.78,3.08-5.89c2.23,0.53,4.47,1.08,6.68,1.69c1.52-0.63,2.92-1.52,4.12-2.68
			c2.09-1.95,4.63-3.51,6.23-5.91C522.36,328.44,522.2,326.74,522.24,325.05z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#azarbaijan-sh">
                            <svg class="map-province azarbaijan-sh">
                                <path class="map-path" id="path-azarbaijan-sh" d="M259.2,55.38c1.62,1.4,4.08,2.62,4.14,5.03
			c0.22,4.75-0.26,9.54,0.28,14.27c0.41,2.31-1.18,4.32-1.28,6.56c0.28,1.3,0.77,2.52,1.22,3.73c-2.23,3.49-7.02,5.89-6.66,10.57
			c-0.1,2.05,2.5,2.05,3.86,2.78c2.5,1.22,5.13,1.91,7.9,2.19c1.42,0.12,0.97,1.91,1.2,2.86c0.1,2.84,1.14,5.56,1.6,8.36
			c1.85,0.67,3.94,0.97,5.46,2.33c-0.53,2.25-3.13,3.37-3.53,5.68c-0.53,3.25,2.66,5.28,3.98,7.92c2.27,1.75,2.11,4.79,3.67,7.02
			c-1.83,0.67-3.59,1.54-5.16,2.7c-2.52,0.26-4.81-0.75-7.14-1.46c-1.52-0.43-2.37,1.08-3.29,1.99c0,0.59,0,1.77-0.02,2.35
			c-2.27-1.16-4.57-2.29-6.98-3.15c-3.65,1.24-3.43,6.39-7.1,7.53c-1.79,0.45-3.23,1.52-4.28,3.04c-1.68-0.61-3.47-1.03-5.12-1.8
			c-2.92-1.85-4.71-4.87-6.78-7.53c-1.91-1.81-4.34-0.39-6.31,0.43c-1.12-1-1.99-2.84-3.74-2.68c-1.5,0.39-2.25,1.91-3.23,2.96
			c-0.47,0.14-1.42,0.43-1.91,0.57c-1.36-1.89-2.72-3.8-4.36-5.46c-1.62-1.79-4.22-1.83-6.35-2.6c-0.41-1.38-0.55-2.8-0.75-4.22
			c1.5,0.26,2.98,0.51,4.49,0.75c0.67-1.46,2.27-1.69,3.47-2.5c0.67-1.18,1.1-2.48,1.62-3.74c0.53-0.47,1.06-0.93,1.56-1.4
			c-1.48,0.28-2.96,0.63-4.47,0.89c-0.79-1.69-0.75-4.32-3-4.79l-0.02-0.69c1.18,0,2.33,0,3.51,0.02c0.04-1.32,0.06-2.64,0.1-3.96
			c-0.83-0.02-1.66-0.04-2.5-0.06c-0.67-2.09-2.98-1.89-4.73-2.29c-0.12-0.39-0.34-1.14-0.47-1.52c-1.01-0.41-2.01-0.83-3-1.24
			c-0.26-1.74-0.53-3.49-0.77-5.24c0.38-0.22,1.16-0.69,1.54-0.93l0.81-0.49c0.16-0.1,0.49-0.3,0.65-0.41
			c0.37-2.44,0.26-4.93,0.2-7.39c-0.39-0.18-1.18-0.53-1.56-0.71c-0.12-0.31-0.37-0.93-0.49-1.26c-1.36-0.53-2.6-1.3-3.65-2.31
			l-0.06-0.04c-0.02-0.04-0.08-0.08-0.12-0.1l-0.08-0.06c-1.06-1.16-2.58-1.52-4-2.01c0.85-0.81,1.79-1.58,2.46-2.58
			c-0.04-4.06-2.72-7.57-3.27-11.51c0.87-1.1,2.46-1.26,3.65-1.89c1.79-0.57,3.02-2.03,4.32-3.29c1.89,1.1,3.73,2.52,6.05,2.39
			c3.02-0.12,4.91,2.88,7.81,3.09c2.25,0.14,4.36,0.99,6.54,1.52c1.79,0.42,3.23-0.87,4.63-1.75c1.89,0.61,3.9,1.48,5.91,0.87
			c3.57-1.26,6.31-4.24,7.9-7.61c1.18-2.34,4.06-1.6,6.09-2.38c1.26-0.97,2.01-2.42,2.86-3.74C254.74,57.81,257.11,56.86,259.2,55.38
			z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#azarbaijan-gh">
                            <svg class="map-province azarbaijan-gh">
                                <path class="map-path" id="path-azarbaijan-gh" d="M181.94,38.15
			c0.71-0.22,1.4-0.45,2.11-0.67c1.99,1.95,4.06,3.78,6.15,5.6c1.34,1.2,1.26,3.17,1.75,4.77c0.18,1.62,1.62,2.58,2.6,3.73
			c1.48,1.4,1.22,3.76,2.44,5.3c1.52,1.3,3.49,1.85,5.34,2.5c1.16,2.01,1.81,4.24,1.87,6.56c-2.25,2.29-5.18,3.59-8.18,4.61
			c-0.18,0.39-0.51,1.2-0.69,1.6c1.28,3.49,3.06,6.86,3.71,10.55c-1.01,1.87-3.04,2.86-4.3,4.5c-1.3,2.05-2.21,4.47-1.54,6.88
			c1.48-0.02,2.98-0.02,4.47-0.02c-0.06,0.43-0.22,1.26-0.28,1.67l-0.1,0.43c-1.1-0.08-1.66,0.43-1.68,1.52l-0.57,0.22
			c-0.75,0.3-1.52,0.61-2.27,0.91c0.28,1.85-0.35,4.16,1.06,5.66c1.2,0.34,2.44,0.55,3.67,0.81c0.14,6.51,0.73,13.01,0.79,19.52
			c0.08,1.71,0.3,3.74,1.85,4.77c2.48,1.77,5.72,1.68,8.36,3.13c2.05,0.47,4.4,0.43,6.09,1.89c1.97,1.76,3.41,4.02,4.95,6.17
			c1.08-0.24,2.13-0.49,3.21-0.75c0.77-1.08,1.54-2.15,2.46-3.11c1.4,0.71,2.39,1.99,3.55,3.04c1.42-0.55,2.86-1.1,4.26-1.68
			c2.82,1.32,3.51,4.65,5.78,6.58c1.79,2.09,4.44,2.86,7,3.55c1.4,2.64,3.07,5.13,4.67,7.65c0.83,2.11,0.06,4.63,1.12,6.72
			c1.42,0.95,3.25,0.63,4.83,0.91c-1.04,2.74-4.51,1.68-6.6,3.11c-4.55,2.92-10.7-0.63-12.14-5.4c-5.09-1.52-10.47-0.61-15.61,0.16
			c-2.52-0.1-3.63-3.96-6.29-3.31c-1.7,0.93-3.33,2.05-4.73,3.41c-0.95,1.26-1.16,2.9-1.71,4.36c-2.05,0.02-4.22-0.22-6.17,0.59
			c-1.4,1.12-1.77,3-2.72,4.46c-1.91,0.16-3.82,0.28-5.68,0.71c1.83-2.84,0.24-6.07-0.53-8.97c0.99-2.44-0.26-4.57-1.91-6.31
			c-1.01,0.35-2.01,0.69-3.02,1.04c-0.69-1.6-1.44-3.19-2.01-4.81c0.57-1.71,1.77-3.17,2.05-4.95c-0.77-2.76-3.27-4.61-6.03-5.03
			c1.58-2.05,1.52-4.73,1.64-7.18c0.24-1.64-1.7-2.07-2.68-2.94c0.14-1.18,0.22-2.37,0.41-3.55c0.47-1.52,1.38-3.17,0.63-4.75
			c-1.58-2.11-3.63-3.82-5.8-5.28c1.34-2.17,1.32-4.73-0.18-6.82c0.63-1.02,1.54-1.95,1.68-3.19c-0.32-1.91-2.4-2.17-3.82-2.92
			c-1.34-0.55-2.17-1.81-3.23-2.74c-1.1-0.43-2.27-0.65-3.39-0.93c0.22-4.89,5.48-7.16,6.27-11.85c0.87-0.75,1.93-1.34,2.52-2.33
			c0.26-1.2,0.08-2.44,0.08-3.65c-1.73-0.1-3.47-0.04-5.2,0.1c0.28-1.97,1.02-3.82,1.62-5.68c0.37-1.77-0.63-3.37-1.02-5.01
			c-0.02-1.79,0.73-3.45,1.18-5.13c-0.87-0.73-1.75-1.46-2.62-2.15c-0.95-3.41,0.83-6.6,1.64-9.82c-0.99-0.53-1.97-1.03-2.98-1.54
			c-0.06-2.21-0.55-4.36-1.48-6.35c2.94-0.14,5.76,0.73,8.63,1.24c2.19-1.77,3.21-4.34,2.8-7.14c0.41-0.49,0.81-0.97,1.24-1.48
			C181.47,40.46,181.71,39.3,181.94,38.15z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ardebil">
                            <svg class="map-province ardebil">
                                <path class="map-path" id="path-ardebil" d="M274.1,46.89c1.14-0.14,2.25-0.3,3.39-0.47
			c3.15,3.27,6.35,6.45,9.34,9.84c-2.33,1.56-5.28,2.03-7.18,4.24c0.2,4.16,4.47,6.07,6.13,9.52c-2.07,0.49-4.2,0.63-6.27,1.08
			c-1.64,1.3-2.7,3.17-3.82,4.91c2.07,2.33,4.71,4.12,6.56,6.68c1.18,1.6,2.98,3.02,5.09,2.6c0.71,2.64,2.6,4.61,4.3,6.64
			c0.91,0.99,0.1,2.38,0.06,3.53c1.26,1.4,2.96,2.31,4.26,3.69c0.12,4.38-3.19,7.67-4.99,11.37c-1.26,4.2-0.24,8.57,0.32,12.81
			c0.91,3.55,3.31,6.43,5.48,9.3c1.64,2.11,2.15,4.79,2.58,7.35c-0.83,0.2-1.64,0.39-2.48,0.57c-2.27-1.46-4.91-0.59-7.41-0.71
			c-1.03-0.85-1.79-1.99-2.82-2.84c-1.4-1-3.25-1.4-4.3-2.84c-1.42-1.46-1.5-3.63-2.48-5.32c-2.05-2.09-3.43-4.67-5.32-6.88
			c-0.91-3.25,2.46-5.2,3.82-7.71c-1.52-1.93-3.82-2.76-6.13-3.25c-0.59-3.05-1.42-6.05-1.44-9.17c0.02-1.46-1.38-2.37-2.7-2.37
			c-3.73-0.18-6.9-2.33-10.43-3.29c0.34-1.73,0.43-3.63,1.71-4.97c1.79-2.07,4.02-3.77,5.26-6.27c-0.49-1.62-1.66-3.35-0.85-5.05
			c0.59-1.99,1.22-4.04,0.89-6.13c-0.61-4.85,0.14-9.78-0.34-14.63c-0.89-2.31-3.17-3.65-4.83-5.38c2.17-0.51,4.73-0.16,6.45-1.79
			C268.38,49.73,271.99,49.55,274.1,46.89z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#sistan">
                            <svg class="map-province sistan">
                                <path class="map-path" id="path-sistan" d="M648.93,339.58c1.54-0.89,3.06-2.38,5.01-1.99
			c8.34,0.63,16.7,1.2,25.07,1.83c2.17,0.12,1.72,2.92,2.31,4.42c0.49,0.45,0.99,0.87,1.48,1.32c0.1,2.21,0.85,4.3,1.83,6.25
			c-1.64,1.99-0.59,4.87-1.91,6.96c-8.38,11.93-17.13,23.63-25.31,35.7c3.88,4.93,8.5,9.21,12.62,13.96
			c1.03,1.24,2.23,2.29,3.49,3.29c0.08,1.85-0.18,3.98,1.64,5.11c0.12,2.74,3.45,3.27,4.3,5.64c1.22,2.96,2.21,6.11,4.38,8.54
			c1.28,1.64,3.06,2.72,4.69,3.96c2.07,1.81,3.82,4.1,6.39,5.26c4.38,1.14,8.89,1.85,13.27,3c1.56,0.39,2.82,1.44,4.16,2.29
			c0.77,1.28,1.56,2.54,2.58,3.65c2.15-0.14,4.24-0.75,6.37-1.18c-0.3,3.73-1.05,7.65,0.35,11.26c1.68,4.32,2.11,8.97,3,13.5
			c0.41,1.54-0.26,3.02-0.77,4.47c-0.95,2.17,0.24,4.47,0.47,6.68c2.21,0.55,4.57,1.4,6.88,0.75c2.68-0.73,5.64-0.69,8.04-2.27
			c0.53,0.87,1.66,1.73,1.12,2.88c-0.95,2.6-1.01,5.34-0.89,8.08c0.3,0.34,0.93,1.01,1.24,1.36c-0.79,0.43-1.56,0.87-2.33,1.3
			c0.02,2.46,0.02,4.91,0.08,7.35c-5.28-1.32-11-0.47-15.87,1.87c-2.52,1.22-5.34,1.46-8.04,2.03c-0.2,0.32-0.59,0.99-0.77,1.32
			c-3.15,0.53-3.45,3.96-4.22,6.43c-1.3-0.14-2.56-0.3-3.81-0.49c-0.12,0.55-0.33,1.66-0.45,2.21c-2.8,2.25-8.18,1.71-8.95,5.99
			c-0.41,4.51-0.75,9.03-0.95,13.56c-0.57-0.14-1.7-0.45-2.29-0.59c-0.79,1.85-0.32,3.82-0.2,5.74c-1.73,4.95,0.39,10.17-0.55,15.22
			c-0.97,0.49-1.97,0.93-2.86,1.58c-1.02,1.06-0.71,2.58-0.65,3.92c-2.48,0.28-4.99,0.14-7.45-0.26c-0.95-0.73-1.79-1.77-3.04-1.91
			c-5.46-1.02-11.04-1.14-16.46-2.38c-0.59-2.13-1.12-4.99-3.75-5.34c-2.68-1.04-6.39,0.61-6.09,3.82c-1.26-0.61-2.42-1.66-3.88-1.62
			c-1.12,0.43-1.85,1.44-2.72,2.21c-1.12-0.83-2.19-1.85-3.57-2.25c-1.79-0.24-3.23,0.99-4.71,1.79c-2.13-3.29-6.35-2.03-9.54-1.4
			c-1.87-1.04-3.65-2.98-5.99-2.46c-3.51,0.89-6.66,2.8-10.15,3.8c0.36-4.18,0.39-8.48-1.1-12.46c-0.91-1.6-2.52-2.66-3.59-4.14
			c-0.83-2.52-1.02-5.18-1.73-7.71c-0.33-2.11-2.6-3-3.59-4.75c-1.24-2.4-3.84-3.61-5.18-5.95c3.61,0.22,7.35,0.93,10.9-0.04
			c1.83-0.97,1.42-3.23,1.3-4.91c-0.16-3.53-3.21-5.8-5.46-8.12c0.06-1.62,0.24-3.23,0.16-4.83c-0.14-2.09-2.44-3.55-1.95-5.72
			c0.41-2.84,0.33-5.7,0.49-8.57c0.51-1.93,1.66-3.71,1.68-5.76c0.33-4.55-0.65-9.05-0.3-13.6c0.14-2.38,1.81-4.3,3.41-5.89
			c1.26-0.51,2.58-0.79,3.84-1.3c0.87-3.63,0.02-7.31-1.83-10.49c3.43-2.54,7.81-1.52,11.75-1.32c1.46,0.16,3.35-0.18,3.78-1.85
			c0.28-2.58,0.26-5.18-0.08-7.73c-0.43-3.47-4.14-5.62-3.9-9.28c1.16-1.14,2.39-2.17,3.45-3.39c-0.37-3.53-3.23-6.13-3.94-9.52
			c-1.1-13.38-1.4-26.83-2.98-40.17c-0.14-2.42-2.23-3.88-3.88-5.3c2.09-1.24,4.36-2.17,6.35-3.61c1.62-1.62,3.27-3.25,4.75-5.01
			c1.04-3.31,1.2-6.84,1.85-10.25c3.15-0.49,6.31-1.02,9.46-1.58c1.18-2.19,1.95-4.67,3.57-6.58
			C642.01,343.6,645.6,341.82,648.93,339.58z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#semnan">
                            <svg class="map-province semnan">
                                <path class="map-path" id="path-semnan" d="M494.58,142.69c2.11,0.43,4.28,0.65,6.33,1.36
			c0.99,2.23-0.1,5.1,1.5,7.04c1.4,0.59,2.92,0.81,4.32,1.4c1.44,1.85,1.42,5.2,4.12,5.7c2.15,0.59,4.36,1.08,6.48,1.85
			c1.46-0.59,2.82-1.4,4.02-2.46c1.81,1.14,3.08,3,2.72,5.24c0.45,2.78-2.84,4.38-2.58,7.1c0.08,4.99,1.16,9.88,1.18,14.88
			c0.65,3.29,3.96,4.99,5.99,7.37c1.2,2.88,1.22,6.15,0.97,9.22c-0.04,2.86-3.15,3.81-4.95,5.44c-2.98,2.76-6.17,5.32-9.36,7.84
			c-2.15,0.73-4.43,0.99-6.6,1.68c-2.03,4.1-5.72,7.02-7.77,11.12c-4.12,5.28-5.05,12.16-8.79,17.66c-6.45,0.2-12.89-0.65-19.32-0.34
			c-8.36,0.65-16.76,0.22-25.15,0.34c-12.14,0.2-24.23-0.97-36.37-1.12c-2.01-0.02-3.59-1.44-5.28-2.36
			c-2.78-1.7-6.01-2.37-9.07-3.35c-2.42,0.41-4.83,0.97-7.29,0.69c-2.88-1.24-5.05-3.63-7.43-5.62c0.49-3.21,2.15-6.15,2.21-9.42
			c1.6-2.42,3.21-4.97,3.27-7.98c-1.58-1.52-3.27-2.92-4.75-4.57c0.28-2.88,0.77-5.76,0.95-8.67c7.1,1.34,14.33,0.73,21.49,0.83
			c1.18-1.32,2.6-2.39,4.22-3.12c1.85-0.77,2.48-3.04,4.4-3.72c2.13-0.97,3.98-2.41,5.72-3.96c0.26-2.52,0.43-5.03,0.43-7.55
			c3.63-0.04,5.46-3.9,8.95-4.14c2.5-0.41,5.01-0.87,7.43-1.75c2.82-1.3,4.47-4.12,6.13-6.6c0.93-2.09,1.93-4.16,3.69-5.66
			c2.6,0.04,5.22-0.04,7.79,0.24c1.4-0.14,2.8-0.18,4.18-0.47c2.42-0.95,3.76-3.43,5.95-4.73c1.87-0.06,3.75,0.55,5.58,0.04
			c2.15-0.95,3.8-2.82,6.09-3.51c3.59-1.04,7.35-0.39,10.98-0.1c2.74-3.8,5.54-8.14,5.3-12.97
			C492.87,144.5,493.81,143.65,494.58,142.69z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#hormozgan">
                            <svg class="map-province hormozgan">
                                <path class="map-path" id="path-hormozgan" d="M496.53,442.22c3.51-2.31,6.94-6.09,11.57-4.89
			c1.48,5.28,1.1,10.8,1.28,16.22c-0.14,2.96,3.21,3.83,5.01,5.54c2.94,2.78,7.31,3.63,11.18,2.7c3.08-2.11,6.03-4.44,9.44-6.03
			c1.42,0.45,2.9,0.83,4.22,1.54c1.42,3.12,0.1,6.84,1.52,9.88c2.41,1.75,5.56,2.05,8.36,2.92c0.41,1.58,1.1,3.07,2.15,4.32
			c-2.35,1.64-5.18,3.17-6.43,5.87c0.28,2.27,0.63,4.53,0.97,6.78c2.01,2.31,3.98,4.67,5.91,7.06c2.7,3.39,7.47,4.69,9.34,8.83
			c4.32,0.83,8.06,3.19,12.06,4.89c2.21,1,3.76,3.08,6.03,4c2.9,0.61,5.97,0.06,8.83,0.97c2.56,0.53,4.53,2.35,6.56,3.9
			c0.39,1.66,0.63,3.39,1.22,4.99c0.79,2.13,3.23,2.96,4.26,4.93c0.85,1.73,2.42,2.88,3.63,4.3c0.89,2.74,1.08,5.64,1.87,8.4
			c0.87,1.79,2.76,2.82,3.78,4.55c1.5,3.9,1.72,8.2,0.91,12.3c-2.21-0.51-3.19-2.62-4.73-4.04c-2.25-1.28-4.71-2.5-7.37-2.38
			c-3,0.02-5.91-1.08-8.91-0.67c-2.56,0.06-5.03,0.73-7.27,1.95c-1.28,0.47-2.76,1.83-4.08,0.75c-1.52-1.38-2.31-3.37-3.8-4.77
			c-1.12-0.65-2.52-0.43-3.73-0.59c-0.41,0.34-1.22,1.05-1.62,1.4c-0.93-1.24-1.7-2.96-3.45-3.12c-0.91,0.16-1.83,0.32-2.72,0.51
			c-2.94-0.53-5.95-0.36-8.91-0.47c-0.79-1.32-1.44-2.7-2.03-4.12c-0.85-2.29-3.51-3.65-3.53-6.29c0.16-1.18,0.43-2.35,0.63-3.53
			c-0.77-1.72-2.29-2.96-3.08-4.65c-0.16-1.14-0.12-2.25-0.16-3.37c-0.29-0.33-0.85-0.97-1.14-1.32c0.63-1.91,2.17-3.96,1.1-5.99
			c-1.22-2.92-1.95-6.03-3.19-8.91c-1.93-2.62-3.27-5.74-5.93-7.73c-1.44-1.16-3.19-1.83-4.79-2.68c-3.04-0.49-6.19-0.37-9.17-1.24
			c-2.98-0.91-6.35-1.03-9.25,0.2c-2.38,2.21-4.53,4.69-7.43,6.25c-4.04-0.04-9.76-0.2-11.02,4.69c0.24,1.09,0.47,2.19,0.69,3.29
			c-3.25,1.28-6.72,1.04-10.11,0.79c-5.42,2.7-10.15,6.47-14.82,10.27c-0.45-0.22-1.34-0.67-1.81-0.87c-0.95,0.3-1.93,0.63-2.88,0.97
			c-1.4-2.52-4.1-2.86-6.66-3.25c-1.81-1.54-2.78-4.2-5.34-4.81c-1.56,0.33-3.25,0.75-4.71-0.16c-2.11-1.3-4.75-1.12-6.82,0.16
			c-2.13,0.04-4.28,0.26-6.39-0.12c-1.93-1.28-3.92-2.48-5.76-3.88c-1.06-1.46-1.4-3.29-2.35-4.79c-1.26-1.46-3.33-1.66-5.01-2.38
			c-7.43-1.46-13.54-7.11-15.48-8.32c1.23-1.23,2.09-3.85,2.68-3.43c4.77,3.43,12.31,6.11,15.8,7.53c2.88,1.93,6.45,1.89,9.76,2.43
			c3.47,0.57,7.65,1.3,10.43-1.42c2.03-1.34,1.56-3.98,1.3-6.03c2.37-2.07,5.36-3.49,8.5-3.86c4.55-0.41,9.05,0.75,13.6,0.69
			c2.37,0,4.77,0.02,7.16,0.02c3.49,0.14,6.6-1.87,10.07-2.03c2.15-0.12,4.55-0.57,5.95-2.42c1.04-2.35-0.3-5.52,1.75-7.51
			c1.77-2.19,4.79-2.27,7.25-3.19c-1.2-2.07-2.6-4.2-2.52-6.7c-1.81-1.71-4.44-1.56-6.68-2.25c-1.07-0.02-1.14-1.28-1.14-2.05
			c-0.02-4.77-0.12-9.56,0.3-14.33c0.3-1.42-1.3-3.21,0.16-4.26C493.08,443.28,495.07,443.36,496.53,442.22z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#yazd">
                            <svg class="map-province yazd">
                                <path class="map-path" id="path-yazd" d="M522.31,318.91c-0.98-1.47-2.33-2.08-2.57-4.89
			c-0.24-2.81-1.35-5.02-2.57-6c-1.22-0.98-2.45-1.1-3.18-2.08c-0.73-0.98-0.61-2.94-1.59-4.16c-0.98-1.22-3.06-2.32-4.04-3.3
			c-0.98-0.98-0.98-3.55-1.83-5.14c-0.86-1.59-2.03-1.29-3.22-2.73c-1.19-1.43-1.19-4.54-4.3-4.77c-3.1-0.24-3.1,0.48-4.3-1.67
			c-1.19-2.15-4.3-4.3-4.3-4.3l-2.39-4.54l-4.35-3.67c-1.74,3.35-5.81,5.03-9.45,5.53c-0.77,3.04-3.63,4.89-4.44,7.96
			c-1.81,0.26-3.63,0.39-5.42,0.73c-1.83,1.2-1.87,3.9-3.88,4.93c-4.02,2.11-8.93,1.34-12.97,3.45c-7.92,3.94-15.71,8.14-23.54,12.3
			c-2.07-0.35-4.14-1.14-6.27-0.89c-1.71,0.3-2.17,2.19-3.02,3.43c-1.58,0.04-3.11,0.41-4.46,1.18c0.87,2.7,2.56,5.16,2.78,8.02
			c0.08,3.53-0.89,7-0.51,10.53c0.33,2.8-0.06,5.66,0.41,8.46c1.12,1.73,3.25,2.42,4.85,3.61c0,0.57-0.02,1.68-0.02,2.23
			c-2.13,2.37-5.58,2.41-7.98,4.4c2.09,3.67,1.04,8.08,2.46,11.91c0.89,2.66,3.82,3.45,6.09,4.55c5.32,2.19,9.95,5.87,15.49,7.51
			c2.66,0.93,5.97,1.22,7.57,3.86c2.46,5.12,2.01,10.88,2.23,16.38c0.18,4.24,5.4,5.5,6.29,9.44c0.83,3.45,2.78,6.72,5.89,8.57
			c1.87,0.16,3.55-0.87,5.28-1.42c-0.26-6.64-0.35-13.31-1.34-19.87c-0.18-2.38-2.38-3.53-4.18-4.61c-0.16-3.13,1.95-5.52,3.39-8.08
			c1.32-1.85,0.12-4.08-0.2-6.05c-0.83-4.08-2.54-8.02-2.68-12.18c1.07-1.85,3.49-2.42,5.38-3.21c4.08-1.75,7.93,3.15,11.89,1.04
			c9.58-4.08,19.91-6.94,28.21-13.54c1.7-1.38,1.97-3.69,2.58-5.64c2.72-0.12,5.32,0.75,7.96,1.38c3.15-2.42,6.17-5.01,9.09-7.71
			c0-1.97,0.04-3.94,0.12-5.89c0.83-0.06,1.65-0.13,2.48-0.2C523.24,321.58,522.71,319.52,522.31,318.91z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khorasan-sh">
                            <svg class="map-province khorasan-sh">
                                <path class="map-path" id="path-khorasan-sh" d="M532.13,103.93c1.66-0.65,2.84-2.07,4.1-3.27
			c0.41,2.46,1.85,4.5,3.31,6.45c-0.04,1.46-0.49,3.37,0.99,4.34c2.62,2.5,6.49,0.91,9.56,2.29c1.79,0.77,3.61,1.6,5.64,1.44
			c2.29,1.52,4.93,2.33,7.69,2.58c0.39,1.91,1.52,3.37,3.47,3.86c0.81,1.36,1.72,2.68,2.4,4.14c0.32,2.5-0.65,5.09,0,7.57
			c0.61,1.6,1.54,3.02,2.31,4.53c-1.66,1.79-4.95,1.18-5.99,3.55c-0.65,2.74,1.24,5.14,1.99,7.63c-1.95,1.14-3.94,2.17-5.97,3.17
			c-0.41,2.25-0.06,4.53-0.12,6.8c-0.47,1.38-1.75,2.23-2.7,3.25c-2.01-0.26-4.06-0.65-5.89-1.62c-3.13-1.46-5.38-4.28-8.48-5.83
			c-3.57-1.62-7.55-2.17-11.45-2.07c-2.54,0.08-5.18-0.28-7.65,0.43c-3.06,0.89-4.3,4.44-7.39,5.32c-2.7-0.02-5.26-1.03-7.83-1.62
			c-0.79-1.6-1.44-3.25-2.33-4.79c-1.1-1.89-4.55-0.65-5.09-3.04c-0.22-2.01-0.28-4.02-0.83-5.97c-2.52-0.65-5.06-1.12-7.59-1.62
			c0.59-1.44,1.54-2.68,2.8-3.61c3.57,0.16,6.05-3,7.26-5.99c0.53-4.28,1.6-8.58,3.76-12.34c1.3-2.44,5.03-3.59,4.5-6.82
			c0.14-1.64-0.97-2.94-1.75-4.26c0.75-0.55,1.52-1.12,2.27-1.68c-0.45-1.28-0.91-2.54-1.36-3.8c1.75-1.22,3.86-1.1,5.89-0.95
			c1.66,1.62,3.59,0.34,5.3-0.47c1.64,0.49,2.72,2.07,4.42,2.43C528.94,104.19,530.56,104.21,532.13,103.93z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#isfahan">
                            <svg class="map-province isfahan">
                                <path class="map-path" id="path-isfahan" d="M378.24,238.51c1.58-0.85,2.4-2.6,3.53-3.92
			c2.46,2.17,4.91,4.53,8,5.72c2.19,0.1,4.34-0.51,6.51-0.63c4.99,0.2,9.23,3.11,13.52,5.3c9.54,0.34,19.08,0.73,28.62,1.22
			c13.38-0.02,28.84-0.07,42.21-0.09c0.4,0.94,0.37,1.3,0.86,2.54c1.4,7.27,1.48,14.66,1.73,22.02c-1.14,1.24-2.15,2.62-3.47,3.67
			c-1.87,1.06-4.06,1.32-6.15,1.79c-0.41,0.93-0.81,1.89-1.22,2.82c-1.72,1.48-2.35,3.79-3.88,5.4c-1.83,0.33-4-0.28-5.5,1.16
			c-1.4,1.54-1.6,4.22-3.9,4.87c-4.08,1.32-8.61,1.06-12.46,3.07c-7.69,4.12-15.47,8.1-23.14,12.24c-2.17-0.65-4.63-1.89-6.82-0.67
			c-1.24,0.57-1.89,1.83-2.54,2.96c-1.2,0.22-2.42,0.45-3.63,0.65c-2.07,2.37,0.12,4.97,0.91,7.39c1.4,4-0.49,8.18-0.04,12.26
			c0.34,2.92,0,5.91,0.39,8.83c0.57,2.5,3.43,2.9,4.99,4.5c0.02,1.97-2.09,2.42-3.55,2.94c-1.4,0.41-2.64,1.16-3.86,1.95
			c-0.73-1.79-1.2-3.92-2.96-4.97c-2.66-1.56-5.82-1.76-8.83-1.97c-4.47-0.2-6.82-5.52-11.39-5.34c-2.96,0.2-4.1,3.39-5.68,5.42
			c-3.27,4.47-0.51,10.11-0.43,15.02c-1.14,3.63-2.86,7.08-3.67,10.86c-1.91-1-3.51-2.44-5.07-3.9c-1.28-1.24-3.8-0.69-4.51-2.54
			c-1.83-3.92-5.97-6.96-5.74-11.65c-0.12-1.26,1.34-1.68,2.07-2.44c0.22-1.2,0.45-2.39,0.65-3.59c-0.63-0.65-1.26-1.28-1.87-1.93
			c0.24-2.21-0.93-4.57,0.22-6.62c1.22-2.42,1.93-4.99,2.7-7.55c-1.66-2.07-3.94-3.82-4.49-6.56c-0.45-2.27-2.54-3.55-4-5.15
			c-1.66-1.6-2.5-3.92-4.44-5.26c-0.39-1.87-0.3-3.86-1.1-5.62c-2.8-4.12-8.69-5.03-12.91-2.76c-1.24,1.46-2.25,4.3-4.69,3.31
			c-2.31-0.26-3.04-2.78-4.65-4.08c-2.56-1.18-5.48-0.65-8.2-0.59c-1.2-2.31-2.82-4.36-4-6.68c-0.43-0.95-1.36-1.5-2.13-2.13
			c-0.02-1.32-0.04-2.62-0.04-3.94c1.42-0.36,2.78-0.91,4.06-1.62c0.95,0,1.91,0,2.86,0c-0.32-1.06-0.55-2.13-0.73-3.21
			c1.69-1.79,3.59-3.37,5.14-5.3c0.04-1.36-0.14-2.72-0.1-4.08c1.1-1.71,2.33-3.35,3.82-4.75c2.66-1.08,5.3-2.48,8.24-2.46
			c2.48,0.18,4.36-1.6,6.62-2.29c2.33-0.59,4.83-0.26,7.12-1.05c1.75-1.04,3.35-2.36,4.79-3.8c0.63-2.21,1.16-4.48,2.11-6.6
			c-1.02-1.64-2.11-3.25-3.35-4.73c0.83-0.83,1.93-1.46,2.52-2.5c0.37-1.71,0.24-3.45,0.28-5.18c1.67-0.71,3.29-1.58,5.03-2.07
			c2.29-0.22,3.73,1.87,5.66,2.68C371.58,239.14,374.99,239.28,378.24,238.51z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#fars">
                            <svg class="map-province fars">
                                <path class="map-path" id="path-fars" d="M380.49,341.92c1.34-2.35,2.72-4.91,4.91-6.58
			c2.98-0.59,5.14,1.91,7.37,3.41c4.02,3.37,10.27,0.69,14.04,4.57c1.16,1.93,1.62,4.18,2.5,6.25c1.52,3.57,0.28,7.82,2.33,11.24
			c1.95,3.15,5.89,3.76,8.93,5.36c4.51,2.44,8.89,5.3,13.88,6.66c2.07,0.67,4.55,1.04,5.91,2.94c1.12,2.11,1.4,4.55,1.79,6.88
			c0.65,3.88-0.47,7.96,1.05,11.69c0.75,1.95,2.7,3,4.08,4.47c1.3,1.2,1.56,3.02,2.15,4.61c0.99,3.39,3.69,6.07,6.76,7.71
			c3.92-1.44,8.67-3.27,12.56-0.87c4.67,5.36,9.13,10.92,13.72,16.36c1.99,3.94-0.41,8.38,0.06,12.52c1.16,2.98,4.24,4.59,7.35,4.77
			c-0.06,0.43-0.14,1.28-0.18,1.71c1.16,2.74,0.12,5.7,0.26,8.58c0.08,3.31-0.18,6.64,0.16,9.95c1.26,2.86,5.07,2.07,7.53,3.06
			c0.1,2.21,0.93,4.26,2.09,6.13c-2.76,0.12-5.38,1.4-7.12,3.53c-1.12,1.99-0.81,4.38-0.81,6.58c-2.56,3.19-6.96,1.89-10.33,3.39
			c-3.43,1.46-7.21,0.95-10.84,1.04c-5.6,0.16-11.18-1.48-16.77-0.49c-2.74,0.87-5.66,1.93-7.61,4.14c-0.41,1.32,0.04,2.72-0.06,4.08
			c-0.91,1.81-2.78,3.37-4.87,3.37c-3.59,0.08-7.08-0.83-10.63-1.22c-2.2-0.17-3.94-2.94-5.96-2.3c-1.38,0.44-11.78-5.43-14.14-6.81
			c-2.37-1.64-5.37-4.36-7.87-5.84c-1.72-1.16-3.81-1.97-5.01-3.75c-0.93-2.13-0.97-4.57-1.97-6.68c-0.75-0.98-1.79-1.71-2.68-2.52
			c-0.12-1.93-0.08-4-1.12-5.7c-1.4-1.75-4.06-2.23-4.95-4.43c-1.06-2.66-2.64-5.03-4-7.53c-0.97-3.53-1.62-7.21-1.48-10.88
			c0.43-5.44-2.8-10.31-5.95-14.45c-2.37-2.9-4-6.39-6.8-8.93c-2.07-2.07-4.85-3.25-6.9-5.34c-2.07-2.09-2.62-5.32-5.01-7.1
			c-3.49-1.97-7.53-2.74-10.98-4.77c-1.38-0.83-1.6-2.6-2.23-3.94c3.27-1.18,4.53-4.65,7.06-6.66c2.8-0.67,6.09-0.99,7.59-3.86
			c2.31-3.67-1.93-6.82-3.06-10.11c1.6,0,3.47-0.26,4.63,1.18c3.11,3.39,7.63,4.77,11.33,7.35c2.15,1.75,6.07,0.79,6.62-2.07
			c0.32-3.19,0.55-6.64-1.4-9.38c2.13-2.68,1.99-6.07,1.91-9.3c-0.12-4.08,3.63-7.37,2.68-11.51
			C380.35,349,379.4,345.35,380.49,341.92z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khoozestan">
                            <svg class="map-province khoozestan">
                                <path class="map-path" id="path-khoozestan" d="M269.05,285.98c1.24-0.57,2.48-1.5,3.9-1
			c3.08,0.79,6.25,0.91,9.42,1.1c2.05,0.83,3.65,2.54,5.74,3.31c4.59,0.33,9.6-0.43,13.74,2.07c2.05,1.76,3.88,3.75,6.13,5.25
			c0.28,1.4,0.3,2.9,1.01,4.16c2.03,1.34,4.42,2.11,6.15,3.88c0.99,1.2,1.32,2.82,2.31,4.06c0.95,1.03,2.13,1.87,2.98,2.98
			c0.79,1.99,0.93,4.28,2.52,5.87c1.81,1.95,2.23,4.79,4.3,6.5c2.66,2.31,5.03,4.91,7.94,6.92c0.04,1.83,0.83,3.47,1.89,4.95
			c-1.16,1.54-1.95,3.47-3.67,4.53c-2.7,1.81-4.93,4.22-6.84,6.84c-1.34,2.21-4.26,2.23-6.15,3.79c0.24,1.16,0.51,2.33,0.79,3.51
			c-0.99,1.22-1.99,2.42-2.96,3.65c0.99,1.54,1.91,3.33,3.59,4.24c2.42,0.91,5.18,0.32,7.55,1.44c0.47,1.05,0.75,2.17,1.24,3.23
			c0.79,0.83,2.07,0.89,3.09,1.34c0.77,1.93,2.37,3.04,4.08,4.06c-0.65,1.38-1.87,2.35-2.88,3.47c2.13,3.35,0.97,7.33,1.08,11.02
			c-3.02-0.49-4.69-3.82-7.85-3.88c-2.05-0.1-3.59,1.48-5.03,2.74c-2.4-0.34-4.91-0.47-7.04,0.93c-3.39,1.08-5.01,4.79-8.46,5.74
			c-1.58-1.5-1.73-4.02-3.29-5.56c-1.89-0.93-4.02-0.55-5.99-0.1c0.04-0.73,0.06-1.48,0.1-2.19c-0.26-0.36-0.81-1.05-1.08-1.4
			c-2.25-0.02-4.38-0.83-5.91-2.54c2.66-0.93,5.7-0.95,8.02-2.76c-0.51-1.68-0.43-4.57-2.82-4.61c-1.28,0.3-1.64,1.81-2.37,2.72
			c-1.2-0.49-2.33-1.34-3.65-1.4c-1.7,0.89-2.25,2.88-3.11,4.46c-0.04,0.47-0.1,1.38-0.14,1.85c1.08,1.24,1.99,2.62,2.66,4.12
			c-0.28,1.4-0.47,2.84-0.83,4.22c-1.18,1.02-2.76,1.97-4.38,1.48c-2.21-0.16-3.29-2.68-5.48-2.82c-0.06,1.18-0.08,2.35-0.08,3.51
			c-0.26,0.22-0.77,0.65-1.03,0.87c-1.64-0.49-3.31-0.89-4.97-1.36c-0.79-2.7-1.01-5.56-2.15-8.12c-0.81-1.95-2.74-2.92-4.26-4.2
			c-0.43-1.34-0.57-2.74-1.06-4.04c-0.87-1.2-2.52-1.3-3.77-1.85c0.34-6.05,0.67-12.12,1.08-18.16c-3.21-0.57-6.45-0.59-9.7-0.53
			c-0.04-4.85-0.1-9.78,0.83-14.57c1.18-4.26,3.51-8.12,4.77-12.36c0.33-1.42-0.87-2.48-1.64-3.49c-1.08-1.2-1.67-2.7-2.37-4.12
			c2.03-1.32,3.33-3.23,3.41-5.68c2.01-2.39,4.18-4.83,4.59-8.06c1.54-2.96,0.24-6.25,0.45-9.38c-0.12-1.48,1.85-1.26,2.74-1.66
			c0.06-1.22,0.1-2.44,0.18-3.63C267.48,289.7,268.42,287.89,269.05,285.98z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#tehran">
                            <svg class="map-province tehran">
                                <path class="map-path" id="path-tehran" d="M414.27,189.66c-3.61-0.96-7.06-2.84-10.88-2.8
			c-3.59,0.12-5.74,3.88-9.38,3.96c-3.41,0.83-6.66-0.83-9.86-1.75c-2.94-0.93-3.29-4.83-6.01-6.11c-2.4-1.1-4.77-2.23-6.78-3.98
			c-0.68-0.63-1.45-1.09-2.26-1.48c-0.66,1.27-1.04,3.2-1.19,5.99c-0.11,1.97-0.49,2.96-1.25,3.22c-0.82,0.28-1.61-0.51-2.13-1.12
			c-0.61-0.72-0.77-0.7-1.19-0.65c-0.22,0.03-0.5,0.06-0.87,0.03c-0.16,0.01-0.25,0.2-0.46,0.71c-0.27,0.66-0.65,1.57-1.7,1.78
			c-0.37,0.07-0.66,0.33-0.88,0.77c-0.35,0.71-0.33,1.59-0.17,1.91c0.07,0.13,0.13,0.24,0.19,0.33c0.15,0.24,0.33,0.51,0.24,0.86
			c-0.1,0.41-0.51,0.71-1.33,1.17c-1.11,0.62-2.66,0.64-5.23,0.67c-1.52,0.02-3.4,0.04-5.77,0.19c-5.51,0.35-8.32,1.06-9.35,4.08
			c3.14-0.46,6.36-0.25,8.99,1.62c2.6,1.48,7.12-0.3,8.48,3.11c-1.58,2.42-3.69,4.65-3.84,7.71c2.82,0.16,5.72,0.16,8.4,1.24
			c5.87,2.27,11.63,4.91,17.66,6.78c2.5,0.81,4.3,2.82,6.35,4.36c1.24-1.56,2.07-3.37,2.76-5.26c-1.44-1.91-3.23-3.51-5.07-4.99
			c0.85-3.29,0.26-6.92,1.66-10.01c3.31-0.65,6.6,1.01,9.95,0.47c3.8-0.53,7.63-0.24,11.45,0.1c1.46-1.6,3.35-2.68,5.34-3.47
			c1.42-3.61,5.85-3.71,8.08-6.56C417.74,190.88,415.81,190.1,414.27,189.66z" />
                                <path class="map-point" id="point-tehran" d="
        M414.27,189.66
        m -50, 0
        a 8,8 0 1,0 16,0
        a 8,8 0 1,0 -16,0
    ">
                                </path>
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ghom">
                            <svg class="map-province ghom">
                                <path class="map-path" id="path-ghom" d="M351.06,210.68c3.23,0.57,6.66,0.3,9.66,1.81
			c3.65,1.73,7.55,2.84,11.2,4.55c2.94,1.38,6.47,1.71,8.95,3.98c0.85,0.75,1.68,1.52,2.54,2.29c-0.04,3.09-1.6,5.85-2.19,8.83
			c-0.63,2.7-2.58,5.83-5.7,5.74c-2.42,0.18-4.85,0.08-7.29,0.06c-1.44-1.24-2.96-2.58-4.93-2.84c-2.35,0.18-4.36,1.58-6.49,2.46
			c-0.26,1.93-0.41,3.88-0.55,5.8c-0.97,0.87-1.93,1.75-2.86,2.64c-2.29-1.12-4.34-2.7-6.68-3.69c-2.11,0.16-4.16,0.95-6.29,0.61
			c-0.75-1.54-1.85-2.8-3.43-3.55c-0.51-2.09-0.16-4.65-1.91-6.21c-2.05-0.41-4.16-0.18-6.23-0.16c-1.91-3.49,1.66-6.54,3-9.56
			c2.44,0.67,4.79,1.52,7.08,2.54c1.54-1.26,2.98-2.64,4.36-4.06c2.44,0.1,4.85-0.24,7.12-1.12
			C351.51,217.52,351,214.05,351.06,210.68z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kermanshah">
                            <svg class="map-province kermanshah">
                                <path class="map-path" id="path-kermanshah" d="M216.3,206.99c0.55-1.14,0.53-2.8,1.66-3.45
			c3.13-0.18,2.64,3.79,4.71,5.22c3.59,2.56,5.16,6.84,7.94,10.11c2.54,2.15,6.29,2.29,9.19,0.77c1.87-0.45,1.97-2.58,2.52-4.08
			c1.54-0.49,3.25-0.73,4.61-1.66c0.81-0.85,1.42-1.89,2.23-2.74c5.03-2.56,11.43-0.49,14.33,4.28c-0.69,1.85-0.39,3.75,0.34,5.52
			c0.89,1.97-0.67,3.75-1.22,5.56c1.32,1.62,3.53,2.13,5.32,3.08c0.04,1.04,0.08,2.05,0.12,3.09c-1.62,2.01-3.37,3.96-5.68,5.18
			c-1.46-1.85-3-3.94-5.56-4.1c-0.57,1.6-0.49,3.31-0.41,4.97c-1.58,1.42-4.43-0.1-5.85,1.79c-2.07,1.64-0.16,4.51-1.08,6.6
			c-0.81,0.53-1.68,0.97-2.54,1.44c-0.63,1.46-1.04,3.07-1.97,4.38c-2.19,0.67-4.44-0.61-6.68-0.26c-1.06,0.41-1.95,1.12-2.86,1.79
			c-2.82,0.08-5.48-1.01-7.67-2.72c-2.7-2.17-5.7-3.94-8.69-5.7c-1.48-1.08-3.23,0-4.81,0.08c-1.68-1.1-2.96-2.7-4.69-3.75
			c-1.08,0.63-2.13,1.26-3.21,1.87c-1.24,0.06-2.88-0.71-3.75,0.55c-1.1,0.83,0.08,2.19,0.2,3.23c-0.33,0.53-0.67,1.06-1,1.6
			c0.43,1.34,0.97,2.68,1.1,4.1c-0.51,1.1-1.38,1.97-2.09,2.96c-3.88-2.19-4.69-6.98-6.13-10.82c-0.79-0.3-1.56-0.59-2.33-0.87
			c0.43-1.08,0.75-2.19,1.08-3.31c3.06-1.48,3.65-5.01,3.71-8.08c0.1-1.95-2.21-2.25-3.55-2.84c-0.14-0.59-0.41-1.81-0.53-2.42
			c0.57-0.02,1.71-0.08,2.27-0.1c0.51-0.65,1.01-1.3,1.52-1.95c-0.28-0.83-0.59-1.64-0.89-2.48c1.38,0.73,2.96,2.48,4.53,1.2
			c2.42-1.73,0.87-4.95-0.43-6.9c1.48-1.48,3.61-2.35,4.59-4.3c1.18-0.24,2.68-0.22,3.23-1.56c0.06-1.16-0.28-2.27-0.49-3.39
			c0.28-0.32,0.85-0.95,1.12-1.28c1.62,0.28,3.29,0.47,4.71-0.53C214.25,207.07,215.28,207.11,216.3,206.99z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kordestan">
                            <svg class="map-province kordestan">
                                <path class="map-path" id="path-kordestan" d="M212.3,162.16c1.26-1.16,2.66-2.15,4.14-3
			c2.23,0.91,3.59,4.3,6.47,3.45c4.47-0.91,9.03-0.45,13.54-0.55c2.03,4.48,6.98,8.24,12.06,6.55c3.17-1.75,7.51-1.26,9.5-4.79
			c2.68-0.06,5.72-0.16,7.77,1.91c2.52,1.93,1.85,5.42,2.25,8.18c-0.73,0.95-1.44,1.91-2.15,2.88c0.77,0.87,1.54,1.77,2.31,2.64
			c-0.95,0.93-2.9,1.68-2.27,3.37c0.93,1.85,2.62,3.17,3.82,4.85c0.57,0.39,1.16,0.77,1.75,1.16c-3,0.83-8.02,0.49-8.14,4.77
			c1.12,3.84,3.35,7.23,5.91,10.21c2.27,2.44,3.15,6.35,1.01,9.15c-2.31-1.34-4.79-0.06-7.21-0.12c-2.03-1.34-3.82-3.19-6.33-3.59
			c-2.4-0.79-4.89-0.12-7.23,0.55c-1.75,0.37-2.23,2.35-3.39,3.47c-1.4,0.65-2.92,0.87-4.36,1.42c-0.85,0.97-0.91,2.39-1.36,3.57
			c-2.68,1.3-5.99,2.21-8.59,0.22c-3-2.62-4.02-6.86-7.21-9.32c-2.01-1.4-2.9-3.69-3.9-5.82c-1.46-0.79-2.8-1.77-4.1-2.8
			c0.1-0.89,0.14-1.81,0.16-2.7c-0.16-1.28-1.66-1.24-2.58-1.64c-0.75-1.85-1.42-3.72-1.97-5.6c1.22-1.1,1.95-2.52,1.89-4.18
			c3.63-0.61,7.45-1.71,9.5-5.05c-1.26-1.87-3.88-0.73-5.74-1.04c-0.3-0.37-0.93-1.1-1.24-1.46c-2.86-0.02-5.8-0.02-8.48,1.12
			c-0.97-0.43-2.42-0.45-2.74-1.66c-0.89-2.15-2.39-3.94-4.04-5.56c0.69-1.75,1.16-3.63,2.42-5.07c2.01-0.41,4.14,0,6.11-0.65
			C211.3,165.77,210.82,163.37,212.3,162.16z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#zanjan">
                            <svg class="map-province zanjan">
                                <path class="map-path" id="path-zanjan" d="M273.82,138.57c2.96,0.41,5.05-2.27,7.86-2.68
			c2.27,0.67,4.38,1.91,5.89,3.75c1.54,2.23,4.49,1.24,6.72,1.1c3.21,1.48,6.88,0.2,10.05,1.97c0.49,2.25,0.41,4.89,2.11,6.68
			c1.14,1.36,2.94,3.43,1.6,5.2c-3.47,0.16-6.76,1.58-9.19,4.06c-0.63,0.97-0.79,2.21-0.71,3.37c0.77,1.12,1.73,2.09,2.62,3.11
			c1.75,2.31,5.11,1.24,7.45,2.56c2.35,0.61,3.86,2.54,4.65,4.73c0.79,1.24-0.49,2.38-1.14,3.33c-1.42,1.71-2.44,3.71-3.9,5.4
			c-1.3,1.14-3.17,0.81-4.75,1.12c-1.6,0.14-2.94,1.14-4.34,1.85c-1.68-1.32-3.27-2.94-5.5-3.17c-0.04,1.12-0.12,2.23-0.24,3.35
			c-1.08,1.32-3.37,2.09-3.17,4.12c0.26,1.56,1.68,2.58,2.56,3.81c-0.91,1.14-1.87,2.25-2.86,3.31c-3.94-0.73-7.35-2.88-11.06-4.2
			c-4.79-1.66-8.85-4.95-11.75-9.07c0.91-0.95,2.35-1.64,2.56-3.08c-0.59-0.81-1.24-1.58-1.89-2.36c2.44-2.6,1.83-6.29,1.02-9.42
			c-1.18-2.27-3.51-4.06-6.03-4.55c-3.35-0.04-6.7-0.08-9.97-0.79c-0.34-2.03-0.49-4.08-0.49-6.13c-1.62-2.15-3.17-4.38-4.38-6.8
			c0.73-0.85,1.38-1.79,2.23-2.5c1.52-0.85,3.53-1.01,4.57-2.56c1.4-1.62,1.89-4.02,3.65-5.24c2.94-0.45,5.22,2.03,7.89,2.78
			c0.69-1.5,0.43-3.96,2.25-4.61C270.1,137.13,271.77,138.63,273.82,138.57z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#gilan">
                            <svg class="map-province gilan">
                                <path class="map-path" id="path-gilan" d="M292.43,94.63c2.33-1.06,5.09-1.1,7.45-2.29
			c-0.39,3.83-0.51,7.73-0.18,11.59c0.37,4.06,0.06,8.24,1.3,12.18c1.14,2.52,2.5,5.16,4.95,6.64c6.56,4.73,14.94,6.6,22.91,6.19
			c2.48,1.36,5.14,2.25,7.85,2.98c-0.35,3.7,0.83,7.61,3.78,9.99c2.29,1.72,4.81,3.13,7.08,4.87c-0.57,1.22-1.06,2.46-1.81,3.57
			c-1.3,1.1-3.47,0.61-4.63,1.85c-0.59,1.69-0.41,3.51-0.47,5.26c-0.37,0.57-0.73,1.16-1.1,1.74c-2.56-0.67-5.26-1.52-7.85-0.61
			c-2.78,0.51-4.95,2.84-7.83,2.8c-2.62,0.1-4.53-2.27-7.16-2.19c-2.6-0.18-5.95-1.2-6.56-4.12c-0.53-2.15-0.95-4.44-2.64-6.03
			c-1.93-1.83-1.56-4.65-2.4-6.98c-1.34-0.87-2.98-1.05-4.42-1.7c-0.93-2.72-0.85-5.89-2.78-8.18c-2.64-3.19-5.52-6.64-5.83-10.92
			c-0.47-3.59-1.28-7.39,0.1-10.86c1.95-3.53,5.03-6.9,4.79-11.2C296.41,97,293.81,96.27,292.43,94.63z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#lorestan">
                            <svg class="map-province lorestan">
                                <path class="map-path" id="path-lorestan" d="M257.19,234.74c1.85,0.59,2.94,2.19,4.22,3.53
			c1.79,1.95,4.87,1.91,6.56,3.96c2.05,2.19,4.45,4.1,7.1,5.44c3.21,0.73,6.41-0.45,8.93-2.4c4.75-1.1,6.39,5.24,10.82,5.48
			c-1.38,2.23-0.85,4.83-0.53,7.27c0.75,1.14,1.46,2.31,2.13,3.51c0.71,0.04,1.44,0.08,2.15,0.14c0.73,0.65,1.28,1.85,2.42,1.73
			c2.42,0.47,4.16-1.5,6.03-2.68c1.87,1.73,4.06,0.99,6.13,0.16c0.16,1.5,0.2,3.02,0.51,4.53c0.71,0.59,1.52,1.04,2.31,1.5
			c0.77,1.64,0.81,4.1,2.82,4.77c2.11,0.77,4.18,1.62,6.03,2.9c-1.91,2.11-3.75,4.3-5.72,6.37c0.18,0.47,0.55,1.4,0.73,1.87
			c-2.29,0.43-4.42,1.34-6.64,2.05c-0.04,1.54,0.06,3.09-0.2,4.63c-0.87,1.58-1.99,3.06-2.27,4.89c-0.97,0.41-2.03,1.26-3.1,0.59
			c-2.48-1.22-3.88-3.84-6.29-5.11c-3.53-1.36-7.37-1.75-11.12-1.42c-2.44,0.3-4.22-1.68-6.19-2.74c-2.11-1.6-4.89-0.53-7.29-1.16
			c-2.7-0.37-6.01-1.81-8.22,0.49c-1.26,2.01-2.07,4.28-3.51,6.19c-1.06-2.23-1.66-4.87-3.78-6.41c-2.09-1.87-5.05-2.33-7.1-4.26
			c-5.5-4.71-11.71-8.55-18.12-11.87c-0.41-1.24-0.83-2.48-1.26-3.69c-1.46-0.65-3.88-1.18-3.17-3.33c1.58-0.06,3.17,0.71,4.71,0.45
			c0.69-1.07,1.08-2.34,1.89-3.33c3.39-0.81,6.92-0.95,10.37-1.46c0.99-1.2,2.25-2.23,2.96-3.63c0.12-1.1,0.06-2.21,0.04-3.31
			c-2.01-2.33-0.34-5.46-0.91-8.2c1.28-2.94,5.26-0.67,7.14-3C257.54,237.68,257.34,236.22,257.19,234.74z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#markazi">
                            <svg class="map-province markazi">
                                <path class="map-path" id="path-markazi" d="M317.64,198.97c1.64,0.39,3.31,0.1,4.89-0.37
			c3.75,2.58,8.83,2.23,12.89,0.65c2.27-0.91,4.75-0.77,7.14-0.69c2.11,0.04,3.63,1.87,5.66,2.23c1.97,0.35,3.98,0.38,5.95,0.69
			c-2.05,3.49-4.47,7.16-4.22,11.39c-0.1,2.35,0.55,4.87-0.41,7.08c-1.91,1.12-4.18,0.63-6.27,0.97c-1.75,0.92-2.94,2.58-4.32,3.92
			c-2.37-0.85-4.67-2.23-7.23-2.33c-2.58,2.25-3.73,5.66-5.07,8.73c0.57,0.89,1.12,1.79,1.68,2.7c2.15,0.18,4.3,0.12,6.45,0.04
			c0.75,2.13,1.04,4.36,1.24,6.6c0.81,0.2,1.62,0.41,2.44,0.61c0.16,0.79,0.32,1.58,0.51,2.38c2.13,0.63,4.34,0.55,6.45-0.02
			c1.81-0.55,3.17,1.12,4.67,1.81c2.35,1.58,5.87,2.33,6.7,5.46c-0.61,1.89-1.22,3.78-1.7,5.7c-1.14,1.42-2.7,2.48-4.16,3.51
			c-3.23,1-6.9,0.26-9.82,2.29c-2.29,1.58-5.24,0.59-7.69,1.72c-1.68,0.67-3.45,1.14-5.05,1.99c-1.85,1.95-3.23,4.28-4.83,6.41
			c-1.6-0.79-3.31-1.36-4.93-2.11c-1.1-2.01-1.36-4.67-3.94-5.44c-0.04-1.99-0.2-4.12-1.97-5.36c-1.73,1.36-3.77,1.54-5.56,0.12
			c-1.54,0.59-2.88,1.56-4.14,2.62c-0.83,0.02-1.66,0.02-2.48,0.04c-0.3-0.43-0.87-1.24-1.18-1.64c-0.71-0.1-1.44-0.18-2.15-0.24
			c-0.61-0.91-1.22-1.81-1.85-2.7c-0.14-1.58-0.47-3.15-0.39-4.75c0.67-2.48,4.06-3.06,4.49-5.7c0.41-2.58-0.18-5.13-0.61-7.67
			c-0.49-0.1-1.46-0.33-1.95-0.45c-0.53-1.52-0.99-3.09-1.38-4.65c1.64-2.19,2.9-4.65,4.85-6.58c1.73-1.5,0.22-3.86,0.14-5.7
			c2.13-2.8,4.61-5.34,8-6.51c0.39-1.52-1.06-2.35-1.93-3.35c2.19,0.53,4.22-0.45,4.91-2.64c0.95-1.46-1.02-2.31-1.91-3.06
			c0.1-1.38,0.22-2.74,0.34-4.1c2.54-0.16,5.38,0.18,7.63-1.24C317.64,200.56,317.68,199.76,317.64,198.97z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#hamedan">
                            <svg class="map-province hamedan">
                                <path class="map-path" id="path-hamedan" d="M264.83,192.17c2.21-1.62,5.22-1.5,7.73-2.52
			c2.76,2.13,6.25,2.74,9.34,4.26c2.25,1.14,4.65,1.97,7.06,2.72c1.83-0.79,3.19-2.23,4.36-3.79c1.56,0.83,3.17,1.56,4.79,2.27
			c2.25,0.71,2.39,3.59,4.28,4.77c1.85,1.24,4.16,1.28,6.23,1.89c0.16,1.71-0.22,3.41-0.1,5.12c0.65,0.79,1.46,1.42,2.21,2.13
			c-0.61,0.77-1.22,1.58-1.83,2.37c-1.26-0.22-2.56-0.26-3.53,0.71c0.63,1.02,1.36,1.97,2.03,2.96c-3.41,1.32-6.17,3.98-7.83,7.21
			c-0.14,1.44,0.45,2.82,0.59,4.26c-2.25,2.31-4.16,4.95-5.54,7.91c0.06,2.42,0.71,5.52,3.41,6.33c0.39,2.96,1.26,6.48-1.4,8.67
			c-1.12-0.02-2.25-0.02-3.37-0.04c-2.46-1.83-4.26-4.87-7.53-5.32c-2.21-0.51-3.86,1.4-5.7,2.27c-1.73,0.51-3.55,0.29-5.32,0.18
			c-3.71-2.68-6.5-6.76-11.1-8.02c2.17-1.46,3.94-3.41,5.5-5.5c0-1.28,0-2.58,0.02-3.88c-1.77-0.99-3.57-1.93-5.38-2.8
			c0.77-1.52,1.93-3.17,1.28-4.95c-0.75-2.4-0.93-4.87-0.73-7.37c1.71-0.55,3.49-0.89,5.26-0.28c2.17,0.59,2.72-2.15,3.13-3.69
			C273.13,202.93,264.28,199.36,264.83,192.17z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#mazandaran">
                            <svg class="map-province mazandaran">
                                <path class="map-path" id="path-mazandaran" d="M348.34,147.58c2.52,1.99,5.16,3.84,7.71,5.78
			c3.51,2.72,7.92,3.84,12.16,4.85c3.61,0.49,6.84,2.35,10.43,2.86c6.76,1,13.56-0.41,20.11-2.03c3.94-0.85,8.06-0.77,11.95-1.87
			c4.02-1.68,8.18-3.03,12.4-4.14c3.15-0.53,6.35-0.63,9.54-0.67c1.64,2.64,4.81,2.39,7.49,2.19c0.16,1.42-0.14,3.04,0.65,4.32
			c1.64,1.28,3.84,1.42,5.64,2.38c0.97,1.99,2.05,3.94,4.47,4.3c-2.58,0.57-5.78,0.61-7.16,3.31c-1.56,3.39-3.39,6.86-6.41,9.19
			c-3.02,1.52-6.45,1.91-9.74,2.52c-1.42,0.26-2.37,1.48-3.51,2.27c-1.28,1.04-2.96,1.2-4.42,1.81c-0.28,2.17-0.3,4.36-0.53,6.54
			c-1.73-1.2-3.61-2.15-5.66-2.68c-3.51-1.01-6.94-2.8-10.68-2.47c-3.33,0.3-5.3,3.82-8.67,3.98c-3.9,0.81-7.53-1.22-11.18-2.27
			c-1.42-2.35-2.82-5.07-5.58-6.05c-3.21-1.28-5.78-3.61-8.59-5.54c-2.01-0.26-3.77-1.28-5.52-2.25c-3.21,1.06-6.13-0.55-8.83-2.09
			c0.57-3.69-2.8-5.87-5.5-7.57c-2.7-1.48-5.52-2.78-8.22-4.28c0.47-0.97,0.93-1.93,1.38-2.9c-0.1-1.38-0.51-2.82-0.06-4.18
			c1.36-0.55,2.82-0.85,4.16-1.48C347.11,150.26,347.65,148.88,348.34,147.58z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ilam">
                            <svg class="map-province ilam">
                                <path class="map-path" id="path-ilam" d="M202.8,245.57c2.46-0.08,4.89-0.53,7.02-1.85
			c1.28,1.22,2.46,2.58,4.04,3.43c1.36,0.04,2.66-0.47,4.02-0.53c3.76,1.79,7.1,4.28,10.41,6.78c2.86,1.89,7.31,3.43,9.86,0.24
			c1.89,0.06,3.73,0.3,5.56,0.81c3.23-0.51,2.94-4.36,5.18-6.09c0.41,0.51,1.24,1.5,1.64,2.01c0.57,2.6-0.85,4.97-3.23,6.01
			c-3,0.71-6.13,0.57-9.15,1.18c-1.52,0.49-1.81,2.25-2.33,3.55c-1.81-0.45-4.79-1.36-5.48,1.14c-0.02,2.17,2.15,2.92,3.75,3.78
			c0.59,1.28,0.49,3.19,1.97,3.82c6.29,3.29,12.34,7.08,17.72,11.73c2.6,2.27,6.76,2.62,8.42,5.95c0.87,2.17,2.31,4.06,3.21,6.21
			c-0.97,0.53-2.21,0.79-2.88,1.77c-0.73,1.77-0.1,3.69,0,5.52c0.49,2.46-0.83,4.73-1.44,7.06c-0.69,3.25-4.85,4.77-4.24,8.42
			c-0.85,0.73-1.68,1.44-2.54,2.17c-1.2-2.11-2.33-4.45-4.63-5.58c1.2-2.42-0.67-4.3-2.17-5.97c1.36-2.8-1.22-4.89-2.6-7.06
			c-2.52,0.45-5.54,2.4-7.75,0.2c-3.23-2.72-5.22-6.66-8.75-9.07c-3.59-2.38-5.83-6.37-9.88-8.08c-2.7-1.89-6.07-1.5-9.17-1.46
			c0.43-1.36,0.63-2.74,0.73-4.14c-0.32-0.1-0.99-0.26-1.32-0.37c1.44-0.55,3.8-0.65,3.78-2.72c0.97-3.88-3.37-5.54-4.67-8.69
			c0.02-0.51,0.06-1.56,0.08-2.09c-0.83-0.89-1.83-1.64-3.02-2.01c-0.22-1.26,0.73-3.35-0.87-3.9c-0.55-0.18-1.64-0.57-2.19-0.75
			c0.85-1.08,1.71-2.15,2.52-3.23c-0.87-2.07-1.62-4.28-0.1-6.25C203.9,247.03,203.17,246.06,202.8,245.57z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ghazvin">
                            <svg class="map-province ghazvin">
                                <path class="map-path" id="path-ghazvin" d="M300.81,158.32c2.25-1.87,5.16-2.41,8-2.76
			c1.01,1.36,1.95,2.94,3.57,3.65c1.83,0.93,3.94,0.85,5.89,1.34c1.83,0.77,3.53,2.05,5.62,1.91c3.17,0.26,5.46-2.52,8.48-2.94
			c3.59-0.85,7.04,1,10.15,2.54c3.82,2.01,8.24,3.57,10.8,7.27c0.79,1.14-0.02,2.8-1.52,2.37c-3.69-0.41-7.49-0.45-11.1-1.5
			c-0.39,1.1-1.26,2.19-0.24,3.27c1.28,1.72,3.77,1.85,5.34,3.23c0.14,1.07,0,2.15-0.04,3.23c-2.01,1.62-4.26,2.82-6.56,3.98
			c-0.83,1.26-0.81,2.88-1.2,4.32c-1.14,0.77-2.25,1.58-3.39,2.38c0,0.93-0.02,1.85-0.02,2.78c-1.48,1.64-1.99,3.75-1.99,5.93
			c-2.98-0.08-6.29,0.59-8.87-1.32c-1.24-1.16-2.74-0.16-4.08,0.2c-1.08-0.16-2.13-0.3-3.21-0.45c0.08,1.02,0.14,2.03,0.24,3.04
			c-2.23,0.37-4.47,0.67-6.72,0.63c-1.83-1.34-4.22-1.18-6.23-2.03c-2.23-1.08-2.56-4.14-4.83-5.14c-2.52-1.16-5.36-2.07-7.1-4.36
			c-0.49-0.67-1.32-1.56-0.61-2.39c1.46-1.6,4.18-2.88,3.06-5.56c1.46,1.03,2.68,2.76,4.53,3.09c2.31-0.93,4.59-1.99,7.12-2.01
			c1.99,0.02,3.27-1.64,4.18-3.19c1.32-2.35,3.57-4.14,4.3-6.82c-0.97-1.64-1.75-3.43-2.98-4.89c-2.29-1.42-4.95-2.25-7.63-2.54
			c-1.91-0.04-2.8-2.01-3.98-3.23C298.42,161.2,299.47,159.05,300.81,158.32z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#alborz">
                            <svg class="map-province alborz">
                                <path class="map-path" id="path-alborz" d="M336.92,197.61c1.17-4.31,5.09-4.93,10.38-5.27
			c2.39-0.15,4.29-0.17,5.82-0.19c2.42-0.03,3.87-0.05,4.76-0.54c0.5-0.28,0.71-0.43,0.81-0.51c-0.02-0.03-0.04-0.07-0.06-0.1
			c-0.08-0.12-0.16-0.25-0.25-0.42c-0.34-0.68-0.27-1.91,0.17-2.8c0.35-0.72,0.9-1.18,1.58-1.31c0.49-0.1,0.69-0.51,0.97-1.18
			c0.25-0.59,0.59-1.39,1.47-1.32c0.26,0.02,0.47,0,0.66-0.02c0.7-0.08,1.18-0.06,2.07,1c0.63,0.75,0.97,0.84,1.05,0.82
			c0,0,0.45-0.18,0.57-2.32c0.12-2.25,0.4-4.62,1.29-6.35c-1.5-0.64-3.07-1.16-4.45-2.06c-1.64-0.04-3.31,0-4.93-0.18
			c-1.87-0.61-3.45-2.11-5.52-2.03c-4.18-0.1-8.34-0.53-12.5-1.04c1.16,2.31,3.86,2.8,5.93,4c0.67,1.54,0.2,3.21,0.04,4.81
			c-2.15,1.58-4.34,3.19-6.9,4.04c-0.28,1.32-0.45,2.66-0.85,3.94c-0.85,0.99-2.03,1.6-3.07,2.35c0.28,2.82-1.91,4.85-2.27,7.51
			C334.71,198.11,335.81,197.83,336.92,197.61z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#booshehr">
                            <svg class="map-province booshehr">
                                <path class="map-path" id="path-booshehr" d="M324.01,387.42c0.69-2.41,3.94-4.02,6.05-2.39
			c1.73,1.3,3.51,2.56,5.03,4.08c2.82,4.14,7.81,6.7,9.01,11.87c3.92,2.37,8.38,3.55,12.54,5.38c2.17,3.43,3.88,7.43,7.63,9.44
			c5.36,2.84,7.9,8.52,11.59,13.01c2.03,2.64,3.55,5.72,4.49,8.91c0.04,5.01,0.22,10.11,1.73,14.92c1.5,2.6,3.02,5.2,4.26,7.94
			c0.85,2.01,3.19,2.52,4.63,3.98c1.1,1.58,0.89,3.59,0.95,5.42c1.22,1.4,3.02,2.48,3.39,4.42c0.38,1.55,0.73,3.12,1.34,4.6
			c0.61,1,1.77,1.93,2.52,2.5c3.21,2.45,6.41,4.95,9.72,7.27c-0.82,1.44-1.74,2.32-2.94,3.03c-2.15-1.83-3.68-2.27-6.32-3.19
			c1.26-0.04,4.26,0.22,3.69-1.93c-1.52-1.32-3.15-2.48-4.38-4.15c-0.62-0.85-2-2.05-3.23-3.04c-1.29-0.63-2.67-1.04-4.08-1.32
			c-3.21-0.57-5.3-3.27-7.59-5.32c-1.52-1.4-3.75-0.93-5.64-1.26c-3.25-0.55-6.54-0.71-9.82-0.81c-1.38-1.99-3.41-3.25-5.54-4.28
			c-1.4-1.32-2.44-3-3.55-4.57c-0.2-1.81,0.57-3.82-0.65-5.38c-2.01-3.04-3.98-6.15-5.18-9.62c-0.2-3.29,0.61-7.73-2.82-9.68
			c-2.48-0.85-4.99-2.27-5.34-5.18c1.75-0.97,4.65-3.09,2.84-5.24c-1.89-2.21-5.05-2.9-7.85-2.46c0.97-1.95,1.71-4.12,0.67-6.21
			c0.2-1.3,0.49-2.6,0.57-3.9c-2.76-1.83-4.79-4.36-6.66-7.04c-3.43-3.35-5.48-7.77-8.67-11.28c0.04-1.58,0.28-3.17,0.08-4.73
			C325.9,389.82,324.9,388.64,324.01,387.42z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kohkilooyeh">
                            <svg class="map-province kohkilooyeh">
                                <path class="map-path" id="path-kohkilooyeh" d="M332.13,343.02
			c1.05,0.63,2.11,1.28,3.17,1.93c1.5,0.04,3.02-0.08,4.51,0.24c1.3,1.12,2.21,2.94,4.14,2.98c3,0.24,4.65,3.27,7.51,3.88
			c2.92,0.43,5.97-0.34,8.81,0.55c2.6,1.81,4.46,4.55,5.8,7.37c0.77,2.07,3.59,1.24,4.87,2.74c1.71,1.89,3.73,3.53,6.39,3.69
			c0.28,2.54-1.18,4.61-1.93,6.88c1.66,2.88,1.58,6.17,1.52,9.38c-1.06,1.16-2.56,2.31-4.2,1.58c-2.6-1.28-4.91-3.07-7.55-4.26
			c-2.25-0.95-3.82-2.9-5.76-4.3c-1.52-1.12-3.49-0.32-5.2-0.26c0.26,3.71,4.1,6.07,3.82,9.93c-1.62,1.62-3.39,3.25-5.83,3.29
			c-4.55,0.14-5.07,6.98-9.64,6.86c-2.19-2.38-4.79-4.4-6.48-7.21c0.26-0.24,0.77-0.73,1.04-0.95c0.22-3.67,1.2-7.71-0.89-11.02
			c1.3-1.32,2.44-2.82,3.25-4.5c-1.08-0.43-2.17-0.83-3.27-1.24c-0.73-2.23-2.5-3.45-4.69-4.02c-0.47-1.08-0.77-2.21-1.26-3.27
			c-2.39-1.22-5.18-0.95-7.73-1.6c-1.5-0.51-2.17-2.07-3-3.29c0.95-1.01,2.27-1.85,2.66-3.25c0-1.3-0.3-2.56-0.47-3.84
			c1.66-0.69,3.84-0.73,4.97-2.31C328.31,346.83,330.12,344.84,332.13,343.02z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#charmahal">
                            <svg class="map-province charmahal">
                                <path class="map-path" id="path-charmahal" d="M311.79,294.83c0.47-1.48,1.18-2.84,2.11-4.08
			c2.23,2.74,3.67,5.99,5.91,8.71c2.76,1.06,6.76-1.34,8.91,1.6c1.4,2.03,3.43,3.27,5.87,3.67c1.77-0.89,3-2.42,4.2-3.92
			c3.9-2.17,9.21-0.89,11.55,3c0.14,1.6-0.04,3.37,0.81,4.83c2.07,2.72,4.08,5.52,6.62,7.86c1.56,1.3,1.62,3.49,2.64,5.15
			c0.93,1.48,2.21,2.72,3.33,4.06c-0.87,2.82-2.17,5.5-3.17,8.28c0.08,2.54-0.34,5.56,1.6,7.55c0.59,0.85,0,2.03,0.02,3.02
			c-0.49,0.2-1.48,0.59-1.99,0.79c-0.61,1.87-0.41,3.82,0.02,5.72c-2.58-0.04-5.18,0.1-7.75-0.06c-2.39-0.16-4.1-2.05-5.97-3.33
			c-1.24-0.47-2.6-0.53-3.82-1.08c-0.91-0.81-1.66-1.77-2.48-2.68c-2.64,0.22-5.32-0.02-7.41-1.81c2.68-1.18,4.1-3.8,5.42-6.23
			c-0.39-0.97-1.03-1.83-1.58-2.68c-0.28-1.22-0.24-2.74-1.46-3.47c-2.56-1.95-4.83-4.2-7.23-6.33c-2.05-1.71-2.48-4.57-4.28-6.48
			c-1.44-1.58-1.5-3.82-2.37-5.68c-1.34-1.75-3.33-2.98-4.06-5.16c-0.95-3-4.14-4.08-6.56-5.6c-1.18-0.67-1.16-2.27-1.73-3.39
			C309.9,296.37,310.84,295.6,311.79,294.83z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#golestan">
                            <svg class="map-province golestan">
                                <path class="map-path" id="path-golestan" d="M494.68,107.19c2.44-0.67,4.3,1.85,6.76,1.54
			c2.84-0.16,5.74-0.51,8.5,0.49c1.16,1.56,2.41,3.88,0.99,5.66c-4.99,3.55-6.68,9.97-7.43,15.75c-0.12,1.81-1.5,3.15-2.58,4.47
			c-1.34,1.95-4.24,1.1-5.66,2.86c-0.59,0.61-1.1,1.24-1.6,1.89c0.24,2.25-1.1,3.96-2.68,5.38c0.1,1.08,0.22,2.15,0.35,3.23
			c-1.56,3-2.48,6.39-4.85,8.91c-3.33-0.04-6.68-0.79-9.94,0.08c-2.44,0.51-4.3,2.21-6.39,3.41c-1.66,1.02-3.67,0.28-5.44,0.02
			c-2.52,1.04-4.02,3.47-6.31,4.81c-2.09,0.45-4.22,0.47-6.31,0.69c0-2.07-1.58-2.96-3.43-3.21c-0.49-0.89-0.93-1.83-1.5-2.66
			c-1.66-1.14-3.98-1.01-5.52-2.39c-0.47-1-0.28-2.17-0.45-3.23c1.79-0.41,3.55-0.85,5.32-1.32c0.73-2.15,0.22-4.38-0.2-6.54
			c-0.63-4.04-2.21-7.88-2.86-11.91c2.9,0.04,5.76,0.63,8.65,0.77c2.54-0.63,4.75-2.03,6.92-3.39c1.77-1.2,3.92,0.12,5.87-0.28
			c1.12-0.59,2.05-1.5,2.78-2.54c1.83-2.8,0.28-6.82,2.88-9.25c2.58-2.19,5.42-4.1,7.53-6.76c3-0.67,5.8-2.07,8.12-4.12
			C488.43,107.32,491.8,107.78,494.68,107.19z" />
                            </svg>
                        </a>
                        <!-- End province -->

                        <svg class="map-sea-names">
                            <g class="map-sea-names">
                                <path d="M405.31,537.88c0,0.61-0.15,1.12-0.44,1.53c-0.33,0.47-0.79,0.7-1.38,0.7c-0.72,0-1.24-0.29-1.55-0.86
				c-0.33,0.57-0.84,0.86-1.54,0.86c-0.5,0-0.88-0.14-1.15-0.42c0,0.13,0,0.25,0,0.38c0,1.3-0.41,2.33-1.22,3.1
				c-0.81,0.77-1.87,1.15-3.18,1.15c-1.09,0-1.97-0.32-2.63-0.96c-0.66-0.64-0.99-1.51-0.99-2.59c0-0.87,0.25-1.73,0.76-2.57
				l0.82,0.31c-0.14,0.23-0.28,0.55-0.39,0.97c-0.12,0.42-0.18,0.76-0.18,1.04c0,1.72,0.94,2.59,2.82,2.59
				c0.88,0,1.62-0.22,2.23-0.65c0.69-0.49,1.03-1.15,1.03-2c0-0.84-0.27-1.69-0.8-2.53l0.97-0.83c0.28,0.58,0.52,0.98,0.72,1.21
				c0.32,0.38,0.7,0.58,1.12,0.58c0.47,0,0.79-0.11,0.97-0.34c0.16-0.19,0.24-0.53,0.24-1.02v-0.2l0.81-0.29v0.13
				c0,1.15,0.4,1.72,1.2,1.72c0.55,0,0.83-0.29,0.83-0.86c0-0.23-0.16-0.58-0.49-1.05l0.8-0.91
				C405.1,536.57,405.31,537.17,405.31,537.88z" />
                                <path d="M411.6,538.41c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C411.3,536.67,411.6,537.53,411.6,538.41z" />
                                <path d="M416.26,540.11h-0.52c-0.86,0-1.48-0.37-1.84-1.12c-0.24-0.5-0.39-1.27-0.43-2.3
				c-0.02-0.36-0.04-1.37-0.06-3.03c-0.02-1.14-0.08-2.33-0.18-3.55l1.11-0.57c0.03,2.42,0.08,4.72,0.14,6.92
				c0.02,0.72,0.09,1.25,0.23,1.58c0.22,0.54,0.62,0.82,1.21,0.82h0.34V540.11z" />
                                <path d="M420.16,537.2c0,1.94-1,2.91-2.99,2.91h-1.44v-1.24h1.3c0.33,0,0.73-0.07,1.22-0.21
				c0.63-0.17,0.94-0.38,0.94-0.63v-0.54c-0.36,0.22-0.77,0.32-1.23,0.32c-0.4,0-0.72-0.12-0.96-0.35c-0.24-0.23-0.35-0.55-0.35-0.95
				c0-0.47,0.14-1,0.43-1.6c0.36-0.76,0.79-1.14,1.3-1.14c0.55,0,1,0.46,1.36,1.37C420.01,535.86,420.16,536.55,420.16,537.2z
				 M419.07,531.59l-0.81,1.07l-1.09-0.72l0.79-1.09L419.07,531.59z M418.98,536.42c-0.17-0.94-0.43-1.41-0.81-1.41
				c-0.17,0-0.33,0.14-0.49,0.41c-0.15,0.24-0.22,0.46-0.22,0.64c0,0.43,0.22,0.64,0.67,0.64
				C418.48,536.71,418.77,536.61,418.98,536.42z" />
                                <path d="M434.86,545.95c-1.12,0.38-2.26,0.57-3.43,0.57c-1.54,0-2.75-0.28-3.65-0.85
				c-1.09-0.68-1.63-1.75-1.63-3.2c0-1.2,0.5-2.3,1.5-3.3c0.8-0.8,1.79-1.42,2.97-1.88c-1.35-0.4-2.12-0.6-2.33-0.6
				c-0.37,0-0.71,0.26-1.02,0.79l-0.8-0.35c0.48-1.12,1.04-1.69,1.7-1.69c0.47,0,1.27,0.17,2.41,0.5c1.13,0.33,2.01,0.5,2.62,0.5
				c0.29,0,0.59-0.01,0.89-0.04l-0.32,1.25c-0.76,0.01-1.32,0.09-1.67,0.23c0.06,0.42,0.26,0.71,0.59,0.85
				c0.24,0.1,0.67,0.15,1.28,0.15h0.85v1.24h-1.17c-0.6,0-1.1-0.2-1.5-0.59c-0.4-0.39-0.62-0.89-0.67-1.5
				c-1.13,0.38-2.07,0.91-2.82,1.57c-0.94,0.83-1.41,1.76-1.41,2.79c0,1.94,1.51,2.91,4.52,2.91c1.12,0,2.05-0.13,2.78-0.39
				L434.86,545.95z M431.6,542.17l-0.82,1.07l-1.07-0.72l0.79-1.09L431.6,542.17z" />
                                <path d="M439.36,540.11h-0.71c-0.97,0-1.61-0.34-1.91-1.02c-0.15,0.31-0.39,0.56-0.72,0.75
				c-0.33,0.18-0.67,0.28-1.03,0.28h-0.72v-1.24h0.64c0.42,0,0.76-0.09,1.04-0.28c0.32-0.22,0.48-0.52,0.48-0.92v-0.53l0.85-0.23
				c0.01,0.81,0.15,1.35,0.43,1.63c0.22,0.22,0.59,0.33,1.13,0.33h0.51V540.11z M438.49,542.36l-0.72,0.92l-0.95-0.7l-0.67,0.83
				l-1.01-0.71l0.77-0.93l0.9,0.67l0.66-0.8L438.49,542.36z" />
                                <path d="M443.23,540.11h-0.52c-0.73,0-1.25-0.37-1.56-1.12c-0.44,0.75-1.04,1.12-1.78,1.12h-0.53v-1.24h0.28
				c0.67,0,1.11-0.2,1.33-0.62c0.17-0.31,0.24-0.82,0.22-1.56l-0.19-6.58l1.1-0.57v6.73c0,1.72,0.44,2.58,1.32,2.58h0.34V540.11z" />
                                <path d="M450.91,536.63l-0.28,1.19c-0.98,0.01-1.81,0.21-2.49,0.61c-0.33,0.21-0.94,0.57-1.81,1.09
				c-0.69,0.39-1.58,0.59-2.67,0.59h-0.94v-1.24h0.99c0.75,0,1.38-0.08,1.89-0.25c0.33-0.11,0.78-0.32,1.35-0.63
				c0.6-0.34,1.04-0.56,1.33-0.67c-0.32-0.08-0.8-0.27-1.46-0.58c-0.6-0.28-1-0.42-1.17-0.42c-0.28,0-0.65,0.23-1.11,0.69l-0.71-0.41
				c0.19-0.33,0.45-0.65,0.77-0.95c0.38-0.35,0.7-0.53,0.96-0.53c0.39,0,0.87,0.14,1.46,0.41c0.94,0.44,1.49,0.69,1.65,0.74
				C449.35,536.53,450.11,536.65,450.91,536.63z M448.21,532.78l-0.82,1.06l-1.08-0.73l0.8-1.1L448.21,532.78z" />
                            </g>
                            <g class="map-sea-names">
                                <path d="M343.29,90.64c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C343,88.9,343.29,89.76,343.29,90.64z" />
                                <path d="M351.26,92.34h-0.51c-0.42,0-0.78-0.08-1.07-0.22c-0.13,1.03-0.77,2.04-1.92,3.03
				c-0.78,0.67-1.66,1.23-2.66,1.7l-0.78-0.65c1.11-0.64,2.07-1.3,2.86-1.96c1-0.84,1.5-1.53,1.5-2.06c0-0.4-0.25-0.95-0.75-1.65
				l0.83-0.96c0.42,0.59,0.67,0.93,0.75,1.01c0.34,0.35,0.75,0.52,1.23,0.52h0.52V92.34z M348.8,86.98l-0.81,1.07l-1.09-0.73
				l0.79-1.09L348.8,86.98z" />
                                <path d="M358.94,88.86l-0.28,1.19c-0.98,0.01-1.81,0.21-2.49,0.61c-0.33,0.21-0.94,0.57-1.81,1.09
				c-0.69,0.39-1.58,0.59-2.67,0.59h-0.94V91.1h0.99c0.75,0,1.38-0.08,1.89-0.25c0.33-0.11,0.78-0.32,1.35-0.63
				c0.6-0.34,1.04-0.56,1.33-0.67c-0.32-0.08-0.8-0.27-1.46-0.58c-0.6-0.28-1-0.42-1.17-0.42c-0.28,0-0.65,0.23-1.11,0.69l-0.71-0.41
				c0.19-0.33,0.45-0.65,0.77-0.95c0.38-0.35,0.7-0.53,0.96-0.53c0.39,0,0.87,0.14,1.46,0.41c0.94,0.44,1.49,0.69,1.65,0.74
				C357.39,88.76,358.14,88.88,358.94,88.86z M356.24,85.01l-0.82,1.06l-1.09-0.73l0.8-1.1L356.24,85.01z" />
                                <path d="M374.52,86.85l-0.41,1.1c-0.27-0.12-0.58-0.17-0.94-0.17c-0.54,0-1.09,0.18-1.66,0.54
				c-0.6,0.39-0.97,0.83-1.09,1.32c-0.01,0.04-0.02,0.1-0.02,0.16c0,0.26,0.32,0.44,0.97,0.52c0.43,0.03,0.85,0.06,1.28,0.09
				c1,0.11,1.5,0.58,1.5,1.41c0,0.84-0.62,1.62-1.86,2.35c-1.19,0.7-2.37,1.05-3.56,1.05c-1.15,0-2.06-0.26-2.73-0.77
				c-0.74-0.57-1.11-1.42-1.11-2.54c0-0.96,0.25-1.85,0.76-2.65l0.81,0.36c-0.38,0.68-0.57,1.32-0.57,1.94
				c0,1.62,1.01,2.43,3.02,2.43c0.68,0,1.4-0.13,2.15-0.38c0.78-0.26,1.42-0.6,1.92-1.02c0.24-0.21,0.37-0.39,0.37-0.54
				c0-0.21-0.18-0.33-0.54-0.37c-1.51-0.18-2.36-0.3-2.57-0.38c-0.47-0.17-0.7-0.57-0.7-1.21c0-0.88,0.42-1.7,1.27-2.45
				c0.82-0.73,1.68-1.1,2.57-1.1C373.83,86.51,374.2,86.62,374.52,86.85z" />
                                <path d="M379.16,92.34h-0.52c-0.86,0-1.48-0.37-1.84-1.12c-0.24-0.5-0.39-1.27-0.43-2.3
				c-0.02-0.36-0.04-1.37-0.06-3.03c-0.02-1.14-0.08-2.33-0.18-3.55l1.11-0.57c0.03,2.42,0.08,4.72,0.14,6.92
				c0.02,0.72,0.09,1.25,0.23,1.58c0.22,0.54,0.62,0.82,1.21,0.82h0.34V92.34z" />
                                <path d="M381.83,90.2c0,1.43-0.83,2.14-2.49,2.14h-0.71V91.1h0.77c0.96,0,1.44-0.26,1.44-0.78
				c0-0.28-0.14-0.6-0.42-0.97l-0.28-0.37l0.86-0.94C381.55,88.67,381.83,89.38,381.83,90.2z M382.67,94.59l-0.72,0.92l-0.95-0.7
				l-0.67,0.83l-1.01-0.71l0.77-0.93l0.9,0.67l0.66-0.8L382.67,94.59z" />
                                <path d="M388.76,90.64c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C388.47,88.9,388.76,89.76,388.76,90.64z" />
                                <path d="M395.78,90.06c0,1.01-0.43,1.7-1.29,2.05c-0.37,0.15-1.04,0.24-2.03,0.28c-0.91,0.04-1.61-0.2-2.1-0.71
				l0.56-0.96c0.32,0.24,0.78,0.37,1.41,0.37c0.67,0,1.12-0.02,1.36-0.07c0.8-0.14,1.2-0.41,1.2-0.8c0-0.81-0.8-1.74-2.41-2.78
				l0.51-1.25c0.67,0.38,1.26,0.89,1.8,1.51C395.44,88.51,395.78,89.29,395.78,90.06z" />
                            </g>
                        </svg>
                        <svg class="map-province-names">
                            <g class="map-province-names">
                                <path d="M563.21,189.12l-0.36,0.96c-0.23-0.1-0.51-0.15-0.82-0.15c-0.47,0-0.95,0.16-1.45,0.47
				c-0.53,0.34-0.85,0.72-0.95,1.16c-0.01,0.04-0.01,0.08-0.01,0.14c0,0.23,0.28,0.38,0.85,0.46c0.37,0.02,0.75,0.05,1.12,0.08
				c0.88,0.1,1.32,0.51,1.32,1.23c0,0.73-0.54,1.42-1.63,2.06c-1.04,0.61-2.08,0.92-3.11,0.92c-1.01,0-1.8-0.23-2.39-0.68
				c-0.65-0.5-0.97-1.24-0.97-2.23c0-0.84,0.22-1.62,0.66-2.32l0.71,0.31c-0.33,0.59-0.5,1.16-0.5,1.7c0,1.42,0.88,2.12,2.64,2.12
				c0.6,0,1.22-0.11,1.88-0.33c0.68-0.23,1.24-0.53,1.68-0.9c0.21-0.18,0.32-0.34,0.32-0.47c0-0.18-0.16-0.29-0.47-0.33
				c-1.32-0.16-2.07-0.27-2.25-0.34c-0.41-0.15-0.61-0.5-0.61-1.06c0-0.77,0.37-1.49,1.11-2.15c0.72-0.64,1.47-0.96,2.25-0.96
				C562.6,188.82,562.93,188.92,563.21,189.12z" />
                                <path d="M569.43,193.92h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V193.92z M567.29,192.82
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C566.88,192.93,567.13,192.9,567.29,192.82z" />
                                <path d="M578.38,191.19c0,0.96-0.43,1.68-1.3,2.16c-0.7,0.38-1.57,0.58-2.61,0.58h-1.96c-0.46,0-0.8-0.03-1.02-0.1
				c-0.32-0.1-0.58-0.31-0.77-0.62c-0.32,0.49-0.74,0.73-1.27,0.73h-0.47v-1.08h0.33c0.71,0,1.06-0.38,1.06-1.13v-0.28l0.82-0.29
				v0.18c0,1.02,0.29,1.53,0.88,1.53c0.32,0,0.57-0.12,0.76-0.36c0.12-0.15,0.33-0.42,0.64-0.81c0.35-0.43,0.8-0.84,1.34-1.23
				c0.72-0.52,1.37-0.78,1.96-0.78c0.43,0,0.81,0.15,1.13,0.44C578.22,190.4,578.38,190.76,578.38,191.19z M577.45,191.56
				c0-0.27-0.12-0.48-0.37-0.64c-0.2-0.13-0.45-0.19-0.74-0.19c-0.67,0-1.66,0.7-2.96,2.11h1.17c1,0,1.77-0.15,2.29-0.46
				C577.25,192.14,577.45,191.87,577.45,191.56z M575.97,187.15l-0.71,0.94l-0.95-0.64l0.69-0.95L575.97,187.15z" />
                                <path d="M583.87,192.44c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C583.61,190.92,583.87,191.67,583.87,192.44z" />
                                <path d="M595.94,191.73c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C595.65,190.04,595.94,190.86,595.94,191.73z M593.33,188.18l-0.71,0.93l-0.95-0.64l0.7-0.95L593.33,188.18z" />
                                <path d="M600.02,193.92h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V193.92z" />
                                <path d="M607.16,192c0,0.52-0.14,0.97-0.41,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C606.97,190.81,607.16,191.36,607.16,192z" />
                                <path d="M609.53,193.72l-0.73,0.2l-0.23-8.86l0.97-0.37V193.72z" />
                                <path d="M616.5,193.92h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V193.92z" />
                                <path d="M623.22,190.88l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C621.86,190.8,622.52,190.9,623.22,190.88z M620.86,187.51l-0.71,0.93l-0.95-0.64l0.7-0.96
				L620.86,187.51z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M545.98,289.01h-1.67c-0.72,0-1.08,0.08-1.08,0.24c0,0.1,0.28,0.21,0.84,0.33
				c0.66,0.14,1.03,0.23,1.1,0.26c0.35,0.18,0.53,0.48,0.53,0.9c0,0.66-0.53,1.22-1.59,1.69c-0.87,0.38-1.69,0.57-2.44,0.57
				c-1.02,0-1.81-0.24-2.38-0.71c-0.61-0.51-0.91-1.27-0.91-2.27c0-0.72,0.21-1.48,0.63-2.27l0.79,0.27
				c-0.31,0.64-0.47,1.23-0.47,1.76c0,1.42,0.82,2.12,2.45,2.12c1.27,0,2.28-0.29,3.04-0.86c0.07-0.05,0.11-0.11,0.11-0.16
				c0-0.07-0.05-0.12-0.16-0.13c-0.96-0.15-1.61-0.29-1.94-0.44c-0.11-0.05-0.21-0.16-0.28-0.32c-0.08-0.16-0.12-0.31-0.12-0.44
				c0-1.08,0.95-1.61,2.84-1.61h0.69V289.01z" />
                                <path d="M548.33,287.14c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C548.08,285.8,548.33,286.43,548.33,287.14z M548.05,291.04l-0.71,0.93
				l-0.95-0.63l0.7-0.96L548.05,291.04z" />
                                <path d="M554.57,289.01h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V289.01z M552.43,287.91
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C552.02,288.01,552.27,287.99,552.43,287.91z" />
                                <path d="M558.54,289.01h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V289.01z M556.9,283.85l-0.71,0.93l-0.95-0.64l0.7-0.95
				L556.9,283.85z" />
                                <path d="M565.27,285.97l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C563.9,285.88,564.57,285.99,565.27,285.97z M563.36,290.67l-0.71,0.93l-0.95-0.63l0.7-0.96
				L563.36,290.67z" />
                                <path d="M577.32,286.82c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C577.02,285.13,577.32,285.95,577.32,286.82z M574.7,283.27l-0.71,0.93l-0.95-0.64l0.7-0.95L574.7,283.27z" />
                                <path d="M581.39,289.01h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V289.01z" />
                                <path d="M588.53,287.08c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C588.34,285.9,588.53,286.45,588.53,287.08z" />
                                <path d="M590.91,288.81l-0.73,0.2l-0.23-8.86l0.97-0.37V288.81z" />
                                <path d="M597.87,289.01h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V289.01z" />
                                <path d="M604.59,285.97l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C603.23,285.88,603.9,285.99,604.59,285.97z M602.23,282.6l-0.71,0.93l-0.95-0.64l0.7-0.96
				L602.23,282.6z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M540.6,408.31c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C540.3,406.61,540.6,407.43,540.6,408.31z M537.99,404.76l-0.71,0.93l-0.95-0.64l0.7-0.95L537.99,404.76z" />
                                <path d="M544.67,410.5h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V410.5z" />
                                <path d="M549.43,408.93c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C549.32,407.87,549.43,408.41,549.43,408.93z M548.54,408.69c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C548.48,409.1,548.54,408.96,548.54,408.69z" />
                                <path d="M556.39,410.5h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V410.5z" />
                                <path d="M561.81,401.55l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C557.72,403.49,559.56,402.51,561.81,401.55z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M221.84,100.58c0,0.96-0.29,1.73-0.87,2.3c-0.58,0.57-1.35,0.86-2.31,0.86c-0.84,0-1.5-0.28-2-0.85
				c-0.44-0.5-0.66-1.1-0.66-1.8c0-0.61,0.18-1.19,0.55-1.73l0.6,0.22c-0.25,0.5-0.37,0.93-0.37,1.31c0,1.29,0.67,1.93,2,1.93
				c0.67,0,1.21-0.18,1.62-0.53c0.42-0.38,0.64-0.89,0.64-1.56c0-0.6-0.21-1.16-0.62-1.7l0.66-0.56
				C221.59,99.12,221.84,99.82,221.84,100.58z M219.61,97.53l-0.61,0.8l-0.81-0.55l0.6-0.82L219.61,97.53z" />
                                <path d="M225.34,102.45h-0.39c-0.65,0-1.11-0.28-1.38-0.84c-0.18-0.38-0.29-0.95-0.32-1.72
				c-0.01-0.27-0.03-1.03-0.04-2.27c-0.01-0.86-0.06-1.74-0.14-2.66l0.83-0.42c0.02,1.82,0.06,3.54,0.11,5.19
				c0.01,0.54,0.07,0.94,0.17,1.19c0.17,0.41,0.47,0.61,0.9,0.61h0.26V102.45z" />
                                <path d="M232.19,102.45h-0.99c-0.56,0-0.96-0.19-1.21-0.56c-0.07-0.11-0.18-0.42-0.33-0.92l-1.9,0.98
				c-0.64,0.33-1.33,0.5-2.06,0.5h-0.76v-0.92h0.74c0.73,0,1.36-0.12,1.9-0.37c0.32-0.15,0.88-0.42,1.7-0.8
				c-0.36-0.08-0.8-0.23-1.32-0.47c-0.48-0.22-0.78-0.33-0.9-0.33c-0.25,0-0.49,0.17-0.74,0.5l-0.57-0.3
				c0.42-0.77,0.83-1.16,1.23-1.16c0.28,0,0.64,0.1,1.08,0.3c0.68,0.3,1.1,0.49,1.27,0.54c0.57,0.19,1.16,0.29,1.77,0.29
				c0.12,0,0.25,0,0.37,0l-0.21,0.87c-0.5,0-0.88,0.07-1.17,0.21c0.08,0.3,0.25,0.5,0.51,0.61c0.18,0.08,0.45,0.11,0.82,0.11h0.75
				V102.45z M229.46,103.87l-0.61,0.8l-0.81-0.54l0.6-0.82L229.46,103.87z" />
                                <path d="M234.2,100.85c0,1.07-0.62,1.61-1.86,1.61h-0.53v-0.93h0.58c0.72,0,1.08-0.19,1.08-0.58
				c0-0.21-0.11-0.45-0.32-0.73l-0.21-0.28l0.64-0.71C233.99,99.7,234.2,100.24,234.2,100.85z M234.84,104.14l-0.54,0.69l-0.71-0.52
				l-0.5,0.62l-0.75-0.54l0.57-0.7l0.68,0.5l0.49-0.6L234.84,104.14z" />
                                <path d="M238.18,102.45h-0.39c-0.65,0-1.11-0.28-1.38-0.84c-0.18-0.38-0.29-0.95-0.32-1.72
				c-0.01-0.27-0.03-1.03-0.04-2.27c-0.01-0.86-0.06-1.74-0.14-2.66l0.83-0.42c0.02,1.82,0.06,3.54,0.11,5.19
				c0.01,0.54,0.07,0.94,0.17,1.19c0.17,0.41,0.47,0.61,0.9,0.61h0.26V102.45z" />
                                <path d="M240.18,100.85c0,1.07-0.62,1.61-1.86,1.61h-0.53v-0.93h0.58c0.72,0,1.08-0.19,1.08-0.58
				c0-0.21-0.11-0.45-0.32-0.73l-0.21-0.28l0.64-0.71C239.97,99.7,240.18,100.24,240.18,100.85z M239.94,104.19l-0.61,0.8l-0.81-0.54
				l0.6-0.82L239.94,104.19z" />
                                <path d="M244.9,101.18c0,0.74-0.43,1.5-1.29,2.27c-0.61,0.55-1.28,0.99-2,1.33l-0.65-0.49
				c0.82-0.45,1.52-0.94,2.11-1.45c0.72-0.62,1.08-1.14,1.08-1.54c0-0.4-0.19-0.87-0.57-1.4l0.65-0.66
				C244.67,99.88,244.9,100.52,244.9,101.18z" />
                                <path d="M250.16,100.75c0,0.76-0.32,1.27-0.97,1.53c-0.27,0.11-0.78,0.18-1.52,0.21
				c-0.68,0.03-1.21-0.15-1.58-0.53l0.42-0.72c0.24,0.18,0.59,0.27,1.05,0.27c0.5,0,0.84-0.02,1.02-0.05c0.6-0.11,0.9-0.31,0.9-0.6
				c0-0.61-0.6-1.31-1.81-2.08l0.38-0.94c0.5,0.29,0.95,0.67,1.35,1.13C249.91,99.58,250.16,100.17,250.16,100.75z M248.16,96.06
				l-0.61,0.8l-0.81-0.55l0.6-0.82L248.16,96.06z" />
                                <path d="M255.09,93.25c-0.15,0.23-0.34,0.43-0.59,0.59c-0.26,0.17-0.52,0.25-0.79,0.25c-0.16,0-0.39-0.03-0.7-0.08
				c-0.31-0.05-0.54-0.08-0.7-0.08c-0.27,0-0.53,0.1-0.79,0.29l-0.38-0.45c0.33-0.35,0.68-0.52,1.04-0.52c0.15,0,0.38,0.02,0.68,0.07
				c0.3,0.05,0.53,0.07,0.68,0.07c0.47,0,0.9-0.18,1.3-0.55L255.09,93.25z M253.45,102.28l-0.63,0.17l-0.19-7.6l0.82-0.32V102.28z" />
                                <path d="M231.09,117.78h-1.43c-0.62,0-0.92,0.07-0.92,0.21c0,0.09,0.24,0.18,0.72,0.28
				c0.57,0.12,0.88,0.2,0.94,0.22c0.3,0.15,0.46,0.41,0.46,0.77c0,0.56-0.45,1.05-1.36,1.44c-0.75,0.33-1.44,0.49-2.09,0.49
				c-0.87,0-1.55-0.2-2.04-0.61c-0.52-0.44-0.78-1.09-0.78-1.95c0-0.62,0.18-1.27,0.54-1.95l0.68,0.23c-0.27,0.55-0.4,1.05-0.4,1.51
				c0,1.21,0.7,1.82,2.1,1.82c1.08,0,1.95-0.25,2.61-0.74c0.06-0.05,0.09-0.09,0.09-0.14c0-0.06-0.05-0.1-0.14-0.11
				c-0.82-0.12-1.38-0.25-1.66-0.38c-0.1-0.05-0.18-0.14-0.24-0.27c-0.07-0.14-0.1-0.26-0.1-0.38c0-0.92,0.81-1.38,2.43-1.38h0.59
				V117.78z" />
                                <path d="M234.02,115.6c0,1.45-0.75,2.18-2.24,2.18h-1.08v-0.93h0.97c0.25,0,0.55-0.05,0.92-0.16
				c0.47-0.13,0.71-0.29,0.71-0.47v-0.41c-0.27,0.16-0.58,0.24-0.92,0.24c-0.3,0-0.54-0.09-0.72-0.26c-0.18-0.17-0.27-0.41-0.27-0.71
				c0-0.35,0.11-0.75,0.32-1.2c0.27-0.57,0.59-0.85,0.97-0.85c0.41,0,0.75,0.34,1.02,1.02C233.92,114.6,234.02,115.12,234.02,115.6z
				 M233.68,111.35l-0.54,0.69l-0.71-0.52l-0.5,0.62l-0.75-0.54l0.57-0.7l0.69,0.51l0.49-0.6L233.68,111.35z M233.14,115.02
				c-0.12-0.7-0.33-1.05-0.61-1.05c-0.12,0-0.25,0.1-0.37,0.31c-0.11,0.18-0.17,0.34-0.17,0.48c0,0.32,0.17,0.48,0.5,0.48
				C232.77,115.23,232.98,115.16,233.14,115.02z" />
                                <path d="M239.99,117.78h-0.38c-0.32,0-0.58-0.06-0.8-0.17c-0.1,0.77-0.58,1.53-1.44,2.27
				c-0.58,0.5-1.25,0.93-2,1.28l-0.59-0.49c0.84-0.48,1.55-0.97,2.15-1.47c0.75-0.63,1.12-1.15,1.12-1.55c0-0.3-0.19-0.71-0.56-1.23
				l0.62-0.72c0.31,0.44,0.5,0.7,0.56,0.76c0.26,0.26,0.57,0.39,0.92,0.39h0.39V117.78z" />
                                <path d="M246.12,116.13c0,0.45-0.12,0.83-0.36,1.13c-0.26,0.34-0.6,0.5-1.04,0.5c-0.57,0-0.98-0.21-1.2-0.64
				c-0.31,0.42-0.72,0.64-1.25,0.64c-0.57,0-0.93-0.21-1.09-0.64c-0.24,0.43-0.63,0.64-1.18,0.64h-0.4v-0.93h0.22
				c0.69,0,1.04-0.34,1.04-1.01v-0.15l0.61-0.22v0.16c0,0.81,0.27,1.22,0.8,1.22c0.62,0,0.93-0.34,0.93-1.02v-0.15l0.61-0.22v0.16
				c0,0.81,0.31,1.22,0.93,1.22c0.44,0,0.67-0.2,0.67-0.6c0-0.28-0.13-0.56-0.38-0.83l0.6-0.68
				C245.96,115.12,246.12,115.58,246.12,116.13z M244.77,112.82l-0.48,0.63l-0.69-0.51l-0.48,0.6l-0.67-0.48l0.51-0.63l0.66,0.49
				l0.46-0.58L244.77,112.82z M243.96,111.71l-0.45,0.59l-0.68-0.5l0.47-0.59L243.96,111.71z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M183.33,105.48l-0.42-1.37c-0.18-0.59-0.33-0.86-0.46-0.82c-0.08,0.03-0.1,0.28-0.06,0.77
				c0.05,0.58,0.07,0.9,0.06,0.97c-0.06,0.33-0.26,0.55-0.61,0.66c-0.54,0.16-1.13-0.13-1.78-0.88c-0.53-0.62-0.89-1.24-1.08-1.86
				c-0.25-0.84-0.26-1.54-0.01-2.13c0.27-0.63,0.82-1.06,1.64-1.31c0.59-0.18,1.26-0.2,2.02-0.05l-0.02,0.72
				c-0.6-0.09-1.12-0.08-1.56,0.06c-1.16,0.35-1.54,1.2-1.13,2.54c0.32,1.04,0.8,1.8,1.47,2.28c0.06,0.05,0.11,0.06,0.16,0.05
				c0.06-0.02,0.08-0.07,0.07-0.16c-0.12-0.82-0.16-1.39-0.12-1.7c0.02-0.11,0.08-0.21,0.19-0.31s0.22-0.17,0.33-0.21
				c0.88-0.27,1.56,0.37,2.03,1.92l0.17,0.57L183.33,105.48z" />
                                <path d="M182.18,107.68l-0.94-0.35l0.28-0.93l0.96,0.33L182.18,107.68z M185.45,106.94
				c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.56c0.21,0.69,0.5,0.98,0.87,0.86c0.2-0.06,0.4-0.23,0.6-0.52
				l0.2-0.28l0.86,0.41C186.49,106.41,186.03,106.76,185.45,106.94z" />
                                <path d="M185.65,113.12l-0.11-0.36c-0.09-0.3-0.12-0.57-0.07-0.82c-0.77,0.13-1.63-0.11-2.59-0.72
				c-0.65-0.41-1.25-0.93-1.8-1.54l0.3-0.7c0.7,0.66,1.38,1.2,2.03,1.63c0.82,0.53,1.42,0.74,1.81,0.62
				c0.29-0.09,0.63-0.38,1.02-0.89l0.87,0.39c-0.33,0.43-0.52,0.68-0.56,0.76c-0.17,0.32-0.21,0.66-0.1,1l0.11,0.38L185.65,113.12z" />
                                <path d="M188.6,117.19l-0.85,0.16c-0.95-1.36-1.65-2.76-2.09-4.2l-0.12-0.39l0.89-0.27l0.42,1.4
				c0.21-0.47,0.6-0.79,1.19-0.97c0.41-0.12,0.83-0.08,1.27,0.15c0.49,0.25,0.83,0.65,0.99,1.21c0.17,0.55,0.13,1.1-0.12,1.66
				l-0.67-0.11c0.1-0.43,0.08-0.87-0.06-1.32c-0.09-0.28-0.23-0.52-0.44-0.71c-0.25-0.22-0.5-0.3-0.76-0.22
				c-0.36,0.11-0.57,0.38-0.64,0.81c-0.06,0.33-0.02,0.7,0.1,1.1C187.81,115.83,188.11,116.4,188.6,117.19z M192.45,113.95
				l-0.94-0.35l0.28-0.94l0.96,0.33L192.45,113.95z" />
                                <path d="M191.83,127.01c-0.92,0.28-1.74,0.23-2.45-0.16c-0.72-0.39-1.22-1.04-1.49-1.96
				c-0.24-0.8-0.17-1.52,0.23-2.16c0.35-0.57,0.86-0.95,1.53-1.15c0.59-0.18,1.19-0.17,1.82,0.02l-0.03,0.64
				c-0.54-0.09-1-0.08-1.36,0.03c-1.23,0.37-1.65,1.2-1.26,2.47c0.2,0.64,0.52,1.11,0.98,1.4c0.48,0.3,1.04,0.35,1.68,0.16
				c0.57-0.17,1.05-0.54,1.44-1.08l0.73,0.47C193.15,126.34,192.55,126.79,191.83,127.01z M194.09,123.98l-0.94-0.35l0.29-0.94
				l0.95,0.33L194.09,123.98z" />
                                <path d="M191.05,130.89l-0.11-0.37c-0.19-0.62-0.06-1.14,0.4-1.56c0.31-0.29,0.83-0.56,1.55-0.81
				c0.25-0.09,0.98-0.33,2.16-0.7c0.82-0.26,1.65-0.56,2.5-0.9l0.65,0.67c-1.73,0.55-3.37,1.09-4.93,1.61
				c-0.51,0.17-0.88,0.34-1.08,0.51c-0.34,0.28-0.45,0.62-0.32,1.04l0.07,0.25L191.05,130.89z" />
                                <path d="M190.89,135.25l-0.94-0.35l0.28-0.93l0.96,0.33L190.89,135.25z M193.04,137.45l-0.29-0.94
				c-0.16-0.54-0.1-0.98,0.19-1.32c0.08-0.1,0.34-0.29,0.79-0.58l-1.49-1.53c-0.51-0.52-0.87-1.13-1.08-1.82l-0.22-0.73l0.88-0.27
				l0.21,0.7c0.21,0.7,0.51,1.27,0.91,1.71c0.24,0.26,0.66,0.72,1.26,1.4c-0.03-0.36-0.01-0.83,0.07-1.4
				c0.07-0.52,0.08-0.84,0.05-0.95c-0.07-0.23-0.3-0.42-0.69-0.56l0.12-0.63c0.86,0.17,1.35,0.45,1.47,0.84
				c0.08,0.27,0.09,0.64,0.03,1.12c-0.09,0.74-0.14,1.19-0.15,1.37c-0.02,0.61,0.06,1.2,0.24,1.77c0.04,0.12,0.07,0.24,0.11,0.36
				l-0.9,0.05c-0.15-0.47-0.33-0.82-0.54-1.05c-0.26,0.16-0.41,0.38-0.43,0.67c-0.02,0.19,0.02,0.46,0.13,0.81l0.22,0.72
				L193.04,137.45z" />
                                <path d="M192.19,140.47l-0.82-0.32l0.29-0.83l-0.74-0.3l0.29-0.88l0.83,0.35l-0.29,0.8l0.71,0.3L192.19,140.47z
				 M195.16,138.91c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.55c0.21,0.69,0.5,0.98,0.87,0.86
				c0.2-0.06,0.4-0.23,0.6-0.52l0.2-0.28l0.86,0.41C196.2,138.38,195.74,138.73,195.16,138.91z" />
                                <path d="M194.78,143.18l-0.11-0.37c-0.19-0.62-0.06-1.14,0.4-1.56c0.31-0.29,0.83-0.56,1.55-0.81
				c0.25-0.09,0.98-0.33,2.16-0.7c0.82-0.26,1.65-0.56,2.5-0.9l0.65,0.67c-1.73,0.55-3.37,1.09-4.93,1.61
				c-0.51,0.17-0.88,0.34-1.08,0.51c-0.34,0.28-0.45,0.63-0.32,1.04l0.07,0.24L194.78,143.18z" />
                                <path d="M193.63,145.38l-0.94-0.35l0.28-0.93l0.96,0.33L193.63,145.38z M196.9,144.63
				c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.55c0.21,0.69,0.5,0.98,0.87,0.86c0.2-0.06,0.4-0.23,0.6-0.52
				l0.2-0.28l0.86,0.41C197.93,144.1,197.48,144.45,196.9,144.63z" />
                                <path d="M197.95,149.24c-0.71,0.21-1.56,0.02-2.55-0.58c-0.7-0.42-1.32-0.93-1.86-1.53l0.28-0.76
				c0.67,0.65,1.34,1.19,2,1.6c0.81,0.51,1.4,0.7,1.79,0.58c0.38-0.12,0.77-0.43,1.18-0.95l0.82,0.44
				C199.13,148.65,198.58,149.04,197.95,149.24z" />
                                <path d="M199.9,154.15c-0.73,0.22-1.31,0.06-1.75-0.48c-0.19-0.23-0.4-0.7-0.65-1.39
				c-0.23-0.64-0.21-1.2,0.05-1.66l0.81,0.19c-0.11,0.28-0.09,0.64,0.04,1.09c0.14,0.48,0.26,0.8,0.34,0.96
				c0.28,0.54,0.56,0.77,0.83,0.69c0.58-0.18,1.07-0.96,1.47-2.34l1.01,0.09c-0.13,0.56-0.36,1.1-0.69,1.62
				C200.94,153.57,200.45,153.98,199.9,154.15z M203.8,150.87l-0.94-0.35l0.29-0.94l0.95,0.34L203.8,150.87z" />
                                <path d="M199.38,157.74l-0.35-0.55l7.21-2.39l0.54,0.7L199.38,157.74z M208.5,156.68c-0.27-0.07-0.51-0.2-0.73-0.4
				c-0.24-0.2-0.39-0.43-0.47-0.68c-0.05-0.15-0.09-0.38-0.13-0.69c-0.04-0.31-0.08-0.54-0.13-0.69c-0.08-0.25-0.25-0.48-0.51-0.67
				l0.33-0.5c0.43,0.21,0.7,0.49,0.8,0.84c0.04,0.15,0.09,0.37,0.13,0.67c0.04,0.3,0.08,0.52,0.13,0.67c0.14,0.45,0.44,0.81,0.9,1.08
				L208.5,156.68z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M274.45,91.42l-0.25-0.3c-0.28-0.33-0.35-0.7-0.21-1.12c-1.83,1.54-3.42,1.51-4.78-0.11
				c-0.51-0.61-0.73-1.24-0.65-1.88c0.08-0.62,0.42-1.2,1.04-1.71c0.58-0.49,1.2-0.77,1.87-0.87l0.23,0.62
				c-0.57,0.12-1.06,0.35-1.47,0.7c-0.96,0.81-1.01,1.71-0.17,2.71c1.01,1.2,2.18,1.22,3.49,0.04l5.16-4.62l0.92,0.39l-4.06,3.42
				c-0.86,0.72-1.04,1.38-0.54,1.96l0.14,0.17L274.45,91.42z" />
                                <path d="M274.95,94.63l-0.88,0.03l-0.06-0.88l-0.8,0.02l-0.08-0.92l0.9-0.01l0.05,0.84l0.77-0.01L274.95,94.63z
				 M276.66,94.04l-0.34-0.41c-0.47-0.56-0.58-1.09-0.34-1.59c-0.25,0.07-0.51,0.05-0.77-0.05c-0.27-0.1-0.48-0.25-0.66-0.46
				l-0.35-0.41l0.71-0.6l0.31,0.37c0.2,0.24,0.42,0.39,0.67,0.46c0.28,0.08,0.53,0.02,0.76-0.17l0.3-0.25l0.54,0.38
				c-0.46,0.39-0.7,0.74-0.72,1.04c-0.02,0.23,0.1,0.5,0.36,0.81l0.25,0.29L276.66,94.04z" />
                                <path d="M276.47,96.52l-1,0.05l-0.11-0.97l1.01-0.07L276.47,96.52z M279.18,94.54c-0.82,0.69-1.63,0.56-2.43-0.39
				l-0.34-0.41l0.71-0.6l0.37,0.44c0.46,0.55,0.84,0.7,1.14,0.45c0.16-0.13,0.28-0.37,0.35-0.71l0.07-0.34l0.95,0.04
				C279.92,93.64,279.65,94.15,279.18,94.54z" />
                                <path d="M282.65,98.5c-0.58,0.49-1.18,0.57-1.8,0.25c-0.26-0.14-0.64-0.48-1.14-1.03
				c-0.46-0.5-0.66-1.02-0.61-1.55l0.82-0.14c0.01,0.3,0.17,0.63,0.47,0.98c0.32,0.38,0.55,0.63,0.7,0.75
				c0.47,0.39,0.81,0.49,1.04,0.3c0.47-0.39,0.61-1.3,0.43-2.73l0.96-0.31c0.1,0.57,0.1,1.15,0,1.76
				C283.38,97.56,283.09,98.13,282.65,98.5z" />
                                <path d="M285.36,102.38c-0.57,0.48-1.42,0.64-2.57,0.48c-0.81-0.11-1.58-0.34-2.31-0.67l-0.04-0.81
				c0.88,0.33,1.7,0.56,2.47,0.68c0.94,0.15,1.57,0.09,1.87-0.17c0.31-0.26,0.54-0.7,0.71-1.34l0.92,0.08
				C286.21,101.37,285.86,101.96,285.36,102.38z" />
                                <path d="M285.84,104.66l-0.54-0.37l5.68-5.05l0.78,0.43L285.84,104.66z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M630.92,488.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C630.62,486.31,630.92,487.13,630.92,488.01z M628.31,484.46l-0.71,0.93l-0.95-0.64l0.7-0.95L628.31,484.46z" />
                                <path d="M634.99,490.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V490.2z" />
                                <path d="M638.98,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M638.2,484.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L638.2,484.87z" />
                                <path d="M647.78,490.2h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V490.2z" />
                                <path d="M654.51,487.15l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C653.15,487.07,653.81,487.17,654.51,487.15z M650.3,492.03l0.57-0.73l0.8,0.59l0.56-0.7l0.79,0.57
				l-0.59,0.74l-0.77-0.58l-0.55,0.68L650.3,492.03z M651.25,493.33l0.52-0.69l0.79,0.58l-0.55,0.68L651.25,493.33z" />
                                <path d="M660.73,490.2h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V490.2z M658.59,489.09
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C658.17,489.2,658.42,489.17,658.59,489.09z" />
                                <path d="M664.1,490.2h-0.46c-0.64,0-1.1-0.33-1.37-0.98c-0.39,0.66-0.91,0.98-1.56,0.98h-0.47v-1.08h0.25
				c0.58,0,0.97-0.18,1.16-0.54c0.15-0.27,0.21-0.72,0.19-1.36l-0.17-5.75l0.96-0.5v5.89c0,1.5,0.39,2.26,1.16,2.26h0.3V490.2z" />
                                <path d="M666.44,488.33c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C666.2,486.99,666.44,487.62,666.44,488.33z M666.16,492.23l-0.71,0.93
				l-0.95-0.63l0.7-0.96L666.16,492.23z" />
                                <path d="M675.38,488.58c0,1.03-0.34,1.97-1.03,2.82c-0.62,0.77-1.44,1.37-2.45,1.8l-0.68-0.76
				c0.98-0.53,1.69-0.99,2.12-1.37c0.67-0.59,1.06-1.25,1.19-1.98c-0.29,0.19-0.64,0.28-1.06,0.28c-0.41,0-0.73-0.1-0.98-0.3
				c-0.27-0.22-0.4-0.53-0.4-0.92c0-0.52,0.14-1.03,0.42-1.51c0.31-0.53,0.68-0.8,1.11-0.8c0.58,0,1.03,0.33,1.36,0.98
				C675.25,487.35,675.38,487.93,675.38,488.58z M674.34,488.11c-0.04-0.76-0.31-1.14-0.81-1.14c-0.17,0-0.32,0.09-0.45,0.27
				c-0.12,0.18-0.19,0.36-0.19,0.54c0,0.38,0.24,0.57,0.71,0.57C673.87,488.35,674.11,488.27,674.34,488.11z" />
                                <path d="M687.46,488.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C687.17,486.31,687.46,487.13,687.46,488.01z M684.85,484.46l-0.71,0.93l-0.95-0.64l0.7-0.95L684.85,484.46z" />
                                <path d="M691.54,490.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V490.2z" />
                                <path d="M695.52,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M694.74,484.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L694.74,484.87z" />
                                <path d="M704.33,490.2h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.32,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V490.2z" />
                                <path d="M708.32,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M707.56,492.17l-0.63,0.81l-0.83-0.61l-0.59,0.73
				l-0.88-0.62l0.67-0.81l0.79,0.59l0.57-0.7L707.56,492.17z" />
                                <path d="M715.46,488.27c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C715.28,487.09,715.46,487.63,715.46,488.27z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M452.06,206.66c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C451.77,204.96,452.06,205.78,452.06,206.66z M449.45,203.11l-0.71,0.93l-0.95-0.64l0.7-0.95L449.45,203.11z" />
                                <path d="M456.13,208.85h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V208.85z" />
                                <path d="M460.11,208.85h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V208.85z M458.47,203.68l-0.71,0.93l-0.95-0.64l0.7-0.95
				L458.47,203.68z" />
                                <path d="M466.21,208.85h-0.47c-0.45,0-0.9-0.22-1.34-0.66c-0.14,0.84-0.37,1.25-0.68,1.21
				c-0.78-0.1-1.54-0.46-2.27-1.08c-0.38,0.35-0.79,0.52-1.21,0.52h-0.58v-1.08h0.41c0.69,0,1.17-0.21,1.42-0.62
				c0.38-0.62,0.58-0.96,0.62-1.01c0.32-0.45,0.6-0.68,0.84-0.68c0.22,0,0.49,0.2,0.79,0.61c0.47,0.62,0.76,0.99,0.89,1.11
				c0.42,0.39,0.85,0.59,1.3,0.59h0.27V208.85z M463.34,206.96c-0.18-0.32-0.34-0.48-0.46-0.48c-0.24,0-0.5,0.35-0.77,1.06
				c0.24,0.23,0.54,0.43,0.91,0.6c0.2,0.09,0.36,0.14,0.47,0.14c0.15,0,0.23-0.09,0.23-0.26
				C463.72,207.76,463.59,207.4,463.34,206.96z" />
                                <path d="M473.34,206.92c0,0.52-0.14,0.97-0.41,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C473.16,205.74,473.34,206.28,473.34,206.92z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M506.97,483.5c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C506.68,481.81,506.97,482.62,506.97,483.5z M504.36,479.95l-0.71,0.93l-0.95-0.64l0.7-0.95L504.36,479.95z" />
                                <path d="M511.04,485.69h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V485.69z" />
                                <path d="M516.27,477.14l-0.15,1.14c-0.84,0.32-1.73,0.71-2.66,1.17c-0.86,0.42-1.45,0.75-1.77,0.98
				c0.55,0.45,0.95,0.82,1.19,1.11c0.53,0.64,0.8,1.27,0.8,1.9c0,1.5-0.92,2.26-2.75,2.26h-0.49v-1.08h0.84
				c1.05,0,1.58-0.34,1.58-1.01c0-0.57-0.7-1.44-2.09-2.61c0.03-0.6,0.11-0.95,0.25-1.04C512.5,478.89,514.25,477.96,516.27,477.14z
				 M516.21,475.62l-0.06,0.75c-0.65,0.26-1.5,0.67-2.55,1.24l-2.59,1.39l0.08-0.64C513.14,477.19,514.85,476.28,516.21,475.62z" />
                                <path d="M523.09,485.69h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V485.69z M520.94,481.01
				l-0.71,0.93l-0.95-0.63l0.69-0.96L520.94,481.01z" />
                                <path d="M527.85,484.12c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C527.75,483.07,527.85,483.6,527.85,484.12z M526.97,483.89c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C526.9,484.3,526.97,484.16,526.97,483.89z" />
                                <path d="M534.82,485.69h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V485.69z" />
                                <path d="M540.14,484.51c0,1.06-0.33,1.59-0.98,1.59c-0.17,0-0.82-0.27-1.96-0.82c-0.49,0.27-1.08,0.41-1.8,0.41
				h-1.02v-1.08h1.65c-0.57-0.24-0.86-0.64-0.86-1.18c0-0.72,0.51-1.37,1.54-1.95l-0.39-0.28l0.44-1.03
				C539.01,481.82,540.14,483.27,540.14,484.51z M537.61,483.17c0-0.21-0.05-0.41-0.15-0.59c-0.12-0.22-0.28-0.33-0.47-0.33
				c-0.21,0-0.43,0.11-0.64,0.32c-0.21,0.21-0.32,0.43-0.32,0.64c0,0.19,0.13,0.39,0.39,0.58c0.23,0.17,0.43,0.25,0.6,0.25
				c0.17,0,0.32-0.11,0.44-0.32C537.56,483.54,537.61,483.36,537.61,483.17z M539.34,484.48c0-0.29-0.34-0.81-1.03-1.56
				c0.01,0.1,0.02,0.2,0.02,0.3c0,0.49-0.18,0.89-0.54,1.22c0.11,0.07,0.32,0.18,0.62,0.31c0.33,0.16,0.54,0.23,0.6,0.23
				C539.24,484.98,539.34,484.81,539.34,484.48z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M461.04,326.83c0,0.89-0.38,1.48-1.13,1.79c-0.32,0.13-0.91,0.21-1.78,0.25c-0.8,0.03-1.41-0.17-1.84-0.62
				l0.49-0.84c0.28,0.21,0.69,0.32,1.23,0.32c0.58,0,0.98-0.02,1.19-0.06c0.7-0.13,1.05-0.36,1.05-0.7c0-0.71-0.7-1.52-2.11-2.43
				l0.44-1.09c0.58,0.33,1.11,0.78,1.57,1.32C460.75,325.47,461.04,326.15,461.04,326.83z" />
                                <path d="M468.01,328.82h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V328.82z M465.86,324.14
				l-0.71,0.93l-0.95-0.63l0.69-0.95L465.86,324.14z" />
                                <path d="M470.36,326.95c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C470.12,325.61,470.36,326.24,470.36,326.95z M471.1,330.79l-0.63,0.81
				l-0.83-0.61l-0.59,0.73l-0.88-0.62l0.67-0.81l0.79,0.59l0.57-0.7L471.1,330.79z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M525.08,122.92c0,1.05-0.32,1.89-0.95,2.52c-0.63,0.63-1.48,0.94-2.53,0.94c-0.92,0-1.65-0.31-2.19-0.93
				c-0.48-0.55-0.72-1.21-0.72-1.97c0-0.67,0.2-1.3,0.6-1.9l0.66,0.24c-0.27,0.54-0.4,1.02-0.4,1.44c0,1.41,0.73,2.11,2.19,2.11
				c0.74,0,1.33-0.19,1.78-0.58c0.46-0.41,0.7-0.98,0.7-1.71c0-0.66-0.23-1.28-0.68-1.86l0.72-0.62
				C524.81,121.33,525.08,122.1,525.08,122.92z M522.63,119.59l-0.67,0.88l-0.89-0.6l0.65-0.89L522.63,119.59z" />
                                <path d="M528.91,124.98h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V124.98z" />
                                <path d="M535.62,123.17c0,0.49-0.13,0.91-0.39,1.24c-0.28,0.37-0.66,0.55-1.14,0.55c-0.63,0-1.07-0.23-1.32-0.7
				c-0.34,0.46-0.79,0.7-1.37,0.7c-0.62,0-1.02-0.23-1.19-0.7c-0.26,0.47-0.69,0.7-1.29,0.7h-0.44v-1.02h0.25
				c0.76,0,1.14-0.37,1.14-1.11v-0.16l0.67-0.24v0.18c0,0.89,0.29,1.33,0.88,1.33c0.68,0,1.02-0.37,1.02-1.12v-0.16l0.67-0.24v0.18
				c0,0.89,0.34,1.34,1.02,1.34c0.49,0,0.73-0.22,0.73-0.66c0-0.31-0.14-0.61-0.42-0.91l0.66-0.75
				C535.44,122.06,535.62,122.57,535.62,123.17z" />
                                <path d="M537.85,124.79l-0.69,0.19l-0.22-8.33l0.91-0.35V124.79z" />
                                <path d="M544.39,124.98h-0.42c-0.35,0-0.64-0.06-0.88-0.18c-0.1,0.85-0.63,1.68-1.58,2.49
				c-0.64,0.55-1.37,1.01-2.19,1.4l-0.64-0.53c0.92-0.53,1.7-1.07,2.35-1.61c0.82-0.69,1.23-1.26,1.23-1.7
				c0-0.33-0.21-0.78-0.62-1.35l0.68-0.79c0.34,0.49,0.55,0.76,0.62,0.83c0.28,0.28,0.62,0.43,1.01,0.43h0.43V124.98z" />
                                <path d="M550.71,122.12l-0.23,0.98c-0.81,0-1.49,0.17-2.05,0.5c-0.27,0.17-0.77,0.47-1.49,0.9
				c-0.56,0.32-1.3,0.49-2.19,0.49h-0.77v-1.02h0.81c0.62,0,1.13-0.07,1.55-0.21c0.27-0.09,0.64-0.26,1.11-0.52
				c0.49-0.28,0.86-0.46,1.09-0.55c-0.26-0.06-0.66-0.22-1.2-0.47c-0.5-0.23-0.82-0.34-0.96-0.34c-0.23,0-0.54,0.19-0.92,0.57
				l-0.58-0.33c0.16-0.27,0.37-0.53,0.63-0.78c0.31-0.29,0.57-0.44,0.79-0.44c0.32,0,0.72,0.11,1.2,0.34
				c0.77,0.36,1.22,0.56,1.35,0.61C549.43,122.04,550.05,122.14,550.71,122.12z M548.49,118.96l-0.67,0.88l-0.89-0.6l0.66-0.9
				L548.49,118.96z" />
                                <path d="M529.23,141.78h-1.57c-0.67,0-1.01,0.08-1.01,0.23c0,0.09,0.26,0.2,0.79,0.31
				c0.62,0.13,0.97,0.21,1.03,0.25c0.33,0.17,0.5,0.45,0.5,0.85c0,0.62-0.5,1.15-1.49,1.58c-0.82,0.36-1.58,0.54-2.29,0.54
				c-0.96,0-1.7-0.22-2.24-0.67c-0.57-0.48-0.85-1.19-0.85-2.13c0-0.68,0.2-1.39,0.59-2.13l0.75,0.25c-0.29,0.6-0.44,1.15-0.44,1.65
				c0,1.33,0.77,2,2.3,2c1.19,0,2.14-0.27,2.86-0.81c0.07-0.05,0.1-0.1,0.1-0.15c0-0.07-0.05-0.11-0.15-0.12
				c-0.9-0.14-1.51-0.28-1.82-0.42c-0.11-0.05-0.19-0.15-0.27-0.3c-0.07-0.15-0.11-0.29-0.11-0.42c0-1.01,0.89-1.51,2.67-1.51h0.65
				V141.78z" />
                                <path d="M531.02,138.82c0,0.93-0.09,1.6-0.27,2.02c-0.27,0.63-0.77,0.94-1.51,0.94h-0.44v-1.02h0.45
				c0.45,0,0.75-0.18,0.9-0.53c0.09-0.21,0.13-0.59,0.13-1.14c0-0.17,0-0.33-0.01-0.48l-0.16-5.05l0.9-0.46V138.82z" />
                                <path d="M534.84,141.78h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V141.78z" />
                                <path d="M540.55,141.78h-0.44c-0.42,0-0.84-0.21-1.26-0.62c-0.13,0.79-0.35,1.17-0.64,1.13
				c-0.73-0.09-1.44-0.43-2.13-1.01c-0.36,0.33-0.74,0.49-1.13,0.49h-0.55v-1.02h0.39c0.65,0,1.1-0.19,1.33-0.58
				c0.36-0.58,0.55-0.9,0.58-0.95c0.3-0.42,0.56-0.64,0.79-0.64c0.21,0,0.46,0.19,0.75,0.57c0.44,0.58,0.72,0.93,0.84,1.04
				c0.39,0.37,0.8,0.56,1.22,0.56h0.25V141.78z M537.86,140.01c-0.17-0.3-0.32-0.45-0.43-0.45c-0.22,0-0.46,0.33-0.72,1
				c0.22,0.22,0.51,0.41,0.85,0.57c0.19,0.09,0.34,0.13,0.44,0.13c0.15,0,0.22-0.08,0.22-0.25
				C538.21,140.75,538.1,140.42,537.86,140.01z" />
                                <path d="M547.26,139.97c0,0.49-0.13,0.91-0.39,1.24c-0.28,0.37-0.66,0.55-1.14,0.55c-0.63,0-1.07-0.23-1.32-0.7
				c-0.34,0.46-0.79,0.7-1.37,0.7c-0.62,0-1.02-0.23-1.19-0.7c-0.26,0.47-0.69,0.7-1.29,0.7h-0.44v-1.02h0.25
				c0.76,0,1.14-0.37,1.14-1.11v-0.16l0.67-0.24v0.18c0,0.89,0.29,1.33,0.88,1.33c0.68,0,1.02-0.37,1.02-1.12v-0.16l0.67-0.24v0.18
				c0,0.89,0.34,1.34,1.02,1.34c0.49,0,0.73-0.22,0.73-0.66c0-0.31-0.14-0.61-0.42-0.91l0.66-0.75
				C547.09,138.86,547.26,139.37,547.26,139.97z M545.78,136.34l-0.53,0.69l-0.76-0.56l-0.53,0.66l-0.74-0.53l0.56-0.69l0.72,0.54
				l0.51-0.64L545.78,136.34z M544.89,135.13l-0.49,0.65l-0.75-0.55l0.51-0.64L544.89,135.13z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M382.62,279.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C382.32,277.32,382.62,278.13,382.62,279.01z M380.01,275.46l-0.71,0.93l-0.95-0.64l0.7-0.95L380.01,275.46z" />
                                <path d="M386.69,281.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V281.2z" />
                                <path d="M392.45,281.2h-0.49c-0.45,0-0.85,0.08-1.19,0.25c-0.43,0.21-0.65,0.52-0.65,0.93
				c0,0.41,0.23,0.74,0.69,0.97l-0.32,0.99c-1.59-0.5-2.59-1.55-2.98-3.14h-1.27v-1.08h1.16c0-0.86,0.21-1.69,0.63-2.5
				c0.37-0.71,0.7-1.07,0.98-1.07c0.22,0,0.49,0.24,0.79,0.72c0.33,0.51,0.49,1.03,0.49,1.54c0,0.59-0.16,1.11-0.47,1.58
				c-0.36,0.53-0.82,0.79-1.38,0.79c0.15,0.56,0.49,1.03,1.04,1.42c-0.03-0.11-0.04-0.23-0.04-0.35c0-0.59,0.23-1.09,0.69-1.52
				c0.45-0.41,0.96-0.62,1.56-0.62h0.76V281.2z M389.53,279.07c0-0.33-0.08-0.63-0.24-0.88c-0.13-0.21-0.25-0.31-0.35-0.31
				c-0.1,0-0.24,0.19-0.4,0.58c-0.2,0.48-0.31,1-0.31,1.57c0.36,0.03,0.66-0.03,0.9-0.18C389.4,279.68,389.53,279.42,389.53,279.07z" />
                                <path d="M396.63,281.2h-0.37c-0.85,0-1.54-0.22-2.07-0.66c-0.68,0.44-1.31,0.66-1.89,0.66h-0.31v-1.08h0.43
				c0.38,0,0.7-0.09,0.97-0.27c-0.3-0.3-0.44-0.73-0.44-1.28c0-0.42,0.2-0.85,0.59-1.29c0.39-0.44,0.8-0.67,1.21-0.67
				c0.36,0,0.67,0.2,0.92,0.6c0.22,0.35,0.33,0.71,0.33,1.1c0,0.69-0.29,1.23-0.87,1.63c0.29,0.13,0.68,0.19,1.16,0.19h0.34V281.2z
				 M395.29,274.43l-0.72,0.94l-0.94-0.64l0.7-0.95L395.29,274.43z M395.2,278.59c0-0.18-0.06-0.37-0.18-0.57
				c-0.13-0.22-0.28-0.33-0.45-0.33c-0.18,0-0.37,0.09-0.57,0.28c-0.2,0.19-0.3,0.37-0.3,0.54c0,0.17,0.07,0.35,0.21,0.55
				c0.15,0.22,0.3,0.33,0.45,0.33c0.14,0,0.32-0.1,0.53-0.3C395.1,278.9,395.2,278.73,395.2,278.59z" />
                                <path d="M405.58,278.47c0,0.96-0.43,1.68-1.3,2.16c-0.7,0.38-1.57,0.58-2.61,0.58h-1.96c-0.46,0-0.8-0.03-1.02-0.1
				c-0.32-0.1-0.58-0.31-0.77-0.62c-0.32,0.49-0.74,0.73-1.27,0.73h-0.47v-1.08h0.33c0.71,0,1.06-0.38,1.06-1.13v-0.28l0.82-0.29
				v0.18c0,1.02,0.29,1.53,0.88,1.53c0.32,0,0.57-0.12,0.76-0.36c0.12-0.15,0.33-0.42,0.64-0.81c0.35-0.43,0.8-0.84,1.34-1.23
				c0.72-0.52,1.37-0.78,1.96-0.78c0.43,0,0.81,0.15,1.13,0.44C405.42,277.68,405.58,278.04,405.58,278.47z M404.66,278.83
				c0-0.27-0.12-0.48-0.37-0.64c-0.2-0.13-0.45-0.19-0.74-0.19c-0.67,0-1.66,0.7-2.96,2.11h1.17c1,0,1.77-0.15,2.29-0.46
				C404.45,279.42,404.66,279.15,404.66,278.83z" />
                                <path d="M407.97,281l-0.73,0.2l-0.23-8.86l0.97-0.37V281z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M421.5,434.9c0,0.54-0.13,0.98-0.38,1.34c-0.29,0.41-0.69,0.61-1.2,0.61c-0.63,0-1.09-0.25-1.36-0.75
				c-0.29,0.5-0.74,0.75-1.35,0.75c-0.44,0-0.77-0.12-1.01-0.37c0,0.11,0,0.22,0,0.33c0,1.13-0.35,2.04-1.07,2.71
				c-0.71,0.67-1.64,1.01-2.78,1.01c-0.96,0-1.72-0.28-2.3-0.84c-0.58-0.56-0.87-1.32-0.87-2.27c0-0.76,0.22-1.51,0.66-2.25
				l0.72,0.27c-0.13,0.2-0.24,0.48-0.35,0.85c-0.1,0.37-0.16,0.67-0.16,0.91c0,1.51,0.82,2.26,2.47,2.26c0.77,0,1.42-0.19,1.95-0.57
				c0.6-0.43,0.9-1.01,0.9-1.75c0-0.74-0.23-1.47-0.7-2.21l0.85-0.73c0.25,0.51,0.46,0.86,0.63,1.06c0.28,0.34,0.61,0.5,0.98,0.5
				c0.41,0,0.69-0.1,0.85-0.3c0.14-0.17,0.21-0.47,0.21-0.89v-0.18l0.71-0.26v0.12c0,1,0.35,1.51,1.05,1.51
				c0.48,0,0.73-0.25,0.73-0.75c0-0.2-0.14-0.51-0.43-0.92l0.7-0.8C421.32,433.76,421.5,434.29,421.5,434.9z" />
                                <path d="M427,435.37c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C426.75,433.85,427,434.6,427,435.37z" />
                                <path d="M431.08,436.86h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V436.86z" />
                                <path d="M434.49,434.32c0,1.7-0.87,2.54-2.61,2.54h-1.26v-1.08h1.14c0.29,0,0.64-0.06,1.07-0.18
				c0.55-0.15,0.82-0.33,0.82-0.55v-0.48c-0.32,0.19-0.67,0.28-1.08,0.28c-0.35,0-0.63-0.1-0.84-0.31c-0.21-0.2-0.31-0.48-0.31-0.83
				c0-0.41,0.13-0.88,0.38-1.4c0.32-0.66,0.69-1,1.14-1c0.48,0,0.88,0.4,1.19,1.2C434.37,433.15,434.49,433.75,434.49,434.32z
				 M433.54,429.4l-0.71,0.93l-0.95-0.63l0.69-0.96L433.54,429.4z M433.47,433.63c-0.15-0.82-0.38-1.23-0.71-1.23
				c-0.15,0-0.29,0.12-0.43,0.36c-0.13,0.21-0.2,0.4-0.2,0.56c0,0.37,0.19,0.56,0.58,0.56C433.03,433.88,433.28,433.8,433.47,433.63z
				" />
                            </g>
                            <g class="map-province-names">
                                <path d="M277.1,336.58c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C276.81,334.88,277.1,335.7,277.1,336.58z M274.49,333.03l-0.71,0.93l-0.95-0.64l0.7-0.95L274.49,333.03z" />
                                <path d="M281.18,338.77h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V338.77z" />
                                <path d="M285.17,338.77h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V338.77z M284.38,333.44l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L284.38,333.44z" />
                                <path d="M292.3,336.84c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C292.12,335.66,292.3,336.2,292.3,336.84z" />
                                <path d="M297.79,337.29c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C297.53,335.76,297.79,336.52,297.79,337.29z M296.98,332.96l-0.72,0.94l-0.95-0.64l0.69-0.96L296.98,332.96z" />
                                <path d="M304.03,338.77h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V338.77z M301.89,337.67
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C301.48,337.77,301.73,337.74,301.89,337.67z" />
                                <path d="M310.74,335.72l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C309.38,335.64,310.04,335.74,310.74,335.72z M308.38,332.36l-0.71,0.93l-0.95-0.64l0.7-0.96
				L308.38,332.36z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M364.4,199.39c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C364.11,197.69,364.4,198.51,364.4,199.39z M361.79,195.84l-0.71,0.93l-0.95-0.64l0.7-0.95L361.79,195.84z" />
                                <path d="M366.8,201.37l-0.73,0.2l-0.23-8.86l0.97-0.37V201.37z" />
                                <path d="M373.76,201.58h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V201.58z" />
                                <path d="M379.52,201.58h-0.49c-0.45,0-0.85,0.09-1.19,0.25c-0.43,0.21-0.65,0.52-0.65,0.93
				c0,0.41,0.23,0.74,0.69,0.97l-0.32,0.99c-1.59-0.5-2.59-1.55-2.98-3.14h-1.27v-1.08h1.16c0-0.86,0.21-1.69,0.63-2.5
				c0.37-0.71,0.7-1.07,0.98-1.07c0.22,0,0.49,0.24,0.79,0.72c0.33,0.51,0.49,1.03,0.49,1.54c0,0.59-0.16,1.11-0.47,1.58
				c-0.36,0.53-0.82,0.79-1.38,0.79c0.15,0.56,0.49,1.03,1.04,1.42c-0.03-0.11-0.04-0.23-0.04-0.35c0-0.58,0.23-1.09,0.69-1.52
				c0.45-0.41,0.96-0.62,1.56-0.62h0.76V201.58z M376.61,199.45c0-0.34-0.08-0.63-0.24-0.88c-0.13-0.21-0.25-0.31-0.35-0.31
				c-0.1,0-0.24,0.19-0.4,0.58c-0.2,0.48-0.31,1-0.31,1.57c0.36,0.03,0.66-0.03,0.9-0.18C376.47,200.05,376.61,199.8,376.61,199.45z" />
                                <path d="M381.87,199.7c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C381.63,198.37,381.87,199,381.87,199.7z M382.37,195.8l-0.64,0.81l-0.82-0.61
				l-0.59,0.73l-0.88-0.62l0.66-0.82l0.79,0.59l0.57-0.7L382.37,195.8z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M360.3,228.23h-0.47c-0.55,0-1-0.11-1.35-0.32c0.09,0.2,0.14,0.44,0.14,0.73c0,0.36-0.07,0.68-0.21,0.98
				c-0.18,0.37-0.43,0.55-0.75,0.55c-1.1,0-1.64-0.78-1.64-2.34c0-0.17,0.01-0.33,0.03-0.48c-0.54,0-0.91,0.18-1.1,0.53
				c-0.14,0.25-0.2,0.68-0.2,1.27v5.36h-0.79l-0.09-5.99c-0.01-0.6,0.16-1.12,0.51-1.56c0.41-0.51,0.97-0.76,1.7-0.76l0.09-0.67
				l1.84,1.07c0.62,0.36,1.26,0.54,1.94,0.54h0.37V228.23z M357.73,227.98c-0.1-0.15-0.19-0.26-0.26-0.33
				c-0.16-0.15-0.42-0.32-0.77-0.5c-0.03,1.26,0.21,1.88,0.74,1.88c0.29,0,0.44-0.18,0.44-0.55
				C357.88,228.3,357.83,228.14,357.73,227.98z" />
                                <path d="M363.71,225.69c0,1.7-0.87,2.54-2.61,2.54h-1.26v-1.08h1.14c0.29,0,0.64-0.06,1.07-0.18
				c0.55-0.15,0.82-0.33,0.82-0.55v-0.48c-0.32,0.19-0.67,0.28-1.08,0.28c-0.35,0-0.63-0.1-0.84-0.31c-0.21-0.2-0.31-0.48-0.31-0.83
				c0-0.41,0.13-0.88,0.38-1.4c0.32-0.66,0.69-1,1.14-1c0.48,0,0.88,0.4,1.19,1.2C363.59,224.52,363.71,225.12,363.71,225.69z
				 M363.31,220.73l-0.63,0.81l-0.82-0.61l-0.59,0.73l-0.88-0.62l0.66-0.82l0.8,0.6l0.57-0.7L363.31,220.73z M362.68,225.01
				c-0.15-0.82-0.38-1.23-0.71-1.23c-0.15,0-0.29,0.12-0.43,0.36c-0.13,0.21-0.2,0.4-0.2,0.56c0,0.37,0.19,0.56,0.58,0.56
				C362.24,225.26,362.49,225.17,362.68,225.01z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M208.22,232.94c0,0.52-0.15,0.96-0.44,1.29c-0.31,0.36-0.72,0.54-1.24,0.54c-0.42,0-0.75-0.14-1-0.42
				c-0.25-0.28-0.38-0.63-0.38-1.05c0-0.37,0.06-0.71,0.19-1.03c0.06-0.15,0.25-0.51,0.58-1.08l-0.17-0.14l0.52-0.98
				C207.57,231.09,208.22,232.05,208.22,232.94z M207.44,232.95c0-0.25-0.13-0.53-0.39-0.84c-0.2-0.24-0.41-0.43-0.65-0.59
				c-0.37,0.7-0.55,1.15-0.55,1.35c0,0.56,0.25,0.84,0.76,0.84c0.22,0,0.42-0.07,0.58-0.21
				C207.36,233.34,207.44,233.16,207.44,232.95z" />
                                <path d="M212.29,234.62h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V234.62z" />
                                <path d="M221.09,234.62h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.32,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V234.62z M217.92,228.83l-0.56,0.73l-0.81-0.59l-0.56,0.69
				l-0.79-0.57l0.59-0.74l0.77,0.58l0.54-0.68L217.92,228.83z M216.97,227.54l-0.52,0.69l-0.79-0.58l0.54-0.69L216.97,227.54z" />
                                <path d="M223.43,232.75c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C223.18,231.41,223.43,232.04,223.43,232.75z M222.98,228.61l-0.71,0.94
				l-0.94-0.64l0.7-0.95L222.98,228.61z" />
                                <path d="M227.5,234.62h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V234.62z" />
                                <path d="M232.26,233.05c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C232.15,232,232.26,232.53,232.26,233.05z M231.37,232.81c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C231.31,233.22,231.37,233.09,231.37,232.81z" />
                                <path d="M239.22,234.62h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V234.62z" />
                                <path d="M244.64,225.67l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C240.55,227.61,242.39,226.63,244.64,225.67z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M230.04,189.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C229.74,187.31,230.04,188.13,230.04,189.01z M227.42,185.46l-0.71,0.93l-0.95-0.64l0.7-0.95L227.42,185.46z" />
                                <path d="M234.11,191.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V191.2z" />
                                <path d="M238.1,191.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V191.2z M237.32,185.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L237.32,185.87z" />
                                <path d="M245.24,189.27c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C245.05,188.09,245.24,188.63,245.24,189.27z" />
                                <path d="M251.36,189.21c0,0.89-0.38,1.48-1.13,1.79c-0.32,0.13-0.91,0.21-1.78,0.25c-0.8,0.03-1.41-0.17-1.84-0.62
				l0.49-0.84c0.28,0.21,0.69,0.32,1.23,0.32c0.58,0,0.98-0.02,1.19-0.06c0.7-0.13,1.05-0.36,1.05-0.7c0-0.71-0.7-1.52-2.11-2.43
				l0.44-1.09c0.58,0.33,1.11,0.78,1.57,1.32C251.07,187.85,251.36,188.53,251.36,189.21z" />
                                <path d="M258.33,191.2h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V191.2z" />
                                <path d="M263.75,182.25l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C259.66,184.19,261.5,183.21,263.75,182.25z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M275.52,155.84c0,1.05-0.32,1.89-0.95,2.52c-0.63,0.63-1.48,0.94-2.53,0.94c-0.92,0-1.65-0.31-2.19-0.93
				c-0.48-0.55-0.72-1.21-0.72-1.97c0-0.67,0.2-1.3,0.6-1.9l0.66,0.24c-0.27,0.54-0.4,1.02-0.4,1.44c0,1.41,0.73,2.11,2.19,2.11
				c0.74,0,1.33-0.19,1.78-0.58c0.46-0.41,0.7-0.98,0.7-1.71c0-0.66-0.23-1.28-0.68-1.86l0.72-0.62
				C275.25,154.24,275.52,155.01,275.52,155.84z M273.07,152.5l-0.67,0.88l-0.89-0.6l0.65-0.89L273.07,152.5z" />
                                <path d="M279.35,157.89h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V157.89z" />
                                <path d="M286.86,157.89h-1.08c-0.62,0-1.06-0.21-1.33-0.62c-0.08-0.12-0.2-0.46-0.36-1.01l-2.08,1.08
				c-0.71,0.37-1.46,0.55-2.26,0.55h-0.83v-1.01h0.81c0.8,0,1.49-0.13,2.09-0.41c0.35-0.16,0.97-0.46,1.87-0.88
				c-0.39-0.08-0.88-0.25-1.45-0.52c-0.53-0.24-0.86-0.36-0.98-0.36c-0.27,0-0.54,0.18-0.81,0.55l-0.62-0.33
				c0.46-0.85,0.9-1.27,1.35-1.27c0.31,0,0.7,0.11,1.18,0.32c0.74,0.33,1.21,0.53,1.39,0.6c0.63,0.21,1.27,0.32,1.93,0.32
				c0.14,0,0.27,0,0.41,0l-0.23,0.96c-0.54,0-0.97,0.08-1.28,0.23c0.09,0.33,0.27,0.55,0.56,0.67c0.2,0.08,0.49,0.12,0.9,0.12h0.83
				V157.89z M283.87,159.44l-0.67,0.88l-0.89-0.59l0.66-0.9L283.87,159.44z" />
                                <path d="M289.07,156.13c0,1.17-0.68,1.76-2.04,1.76h-0.58v-1.02h0.64c0.79,0,1.18-0.21,1.18-0.64
				c0-0.23-0.12-0.49-0.35-0.79l-0.23-0.3l0.7-0.77C288.84,154.88,289.07,155.47,289.07,156.13z M288.64,152.25l-0.67,0.88
				l-0.89-0.61l0.65-0.89L288.64,152.25z" />
                                <path d="M294.23,156.5c0,0.81-0.47,1.64-1.42,2.49c-0.67,0.6-1.4,1.09-2.19,1.46l-0.71-0.54
				c0.9-0.5,1.67-1.03,2.32-1.59c0.79-0.68,1.18-1.25,1.18-1.69c0-0.44-0.21-0.95-0.62-1.54l0.72-0.72
				C293.99,155.07,294.23,155.77,294.23,156.5z M293.47,152.43l-0.68,0.88l-0.89-0.6l0.65-0.9L293.47,152.43z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M314.57,139.66c-0.54,0.79-1.21,1.26-2.01,1.41c-0.8,0.15-1.6-0.05-2.39-0.59
				c-0.69-0.47-1.08-1.08-1.18-1.83c-0.08-0.67,0.07-1.28,0.46-1.86c0.34-0.5,0.82-0.88,1.43-1.12l0.38,0.52
				c-0.48,0.27-0.83,0.56-1.04,0.88c-0.72,1.06-0.54,1.97,0.56,2.72c0.56,0.38,1.1,0.54,1.64,0.48c0.56-0.07,1.03-0.38,1.4-0.93
				c0.34-0.5,0.49-1.08,0.45-1.75l0.86-0.09C315.18,138.32,315,139.04,314.57,139.66z M314.44,135.89l-0.95,0.32l-0.36-0.91
				l0.95-0.34L314.44,135.89z" />
                                <path d="M320.27,145.82l-0.34-0.23c-0.47-0.32-0.67-0.82-0.62-1.51c0.04-0.52,0.22-1.07,0.52-1.65
				c-1.26,1.11-2.81,1.22-4.66,0.33l0.06-0.74c0.62,0.25,1.26,0.41,1.91,0.47c0.71,0.07,1.2-0.01,1.47-0.23
				c0.03-0.03,0.07-0.06,0.09-0.1c0.31-0.45,0.27-1.36-0.1-2.72c-0.3-1.08-0.65-1.98-1.05-2.69l0.75-0.77
				c0.5,1.06,0.86,2.14,1.08,3.23c0.25,1.23,0.25,2.17,0,2.81c0.56-0.47,1.18-1.21,1.86-2.21c0.4-0.59,0.77-1.18,1.1-1.77l0.86,0.21
				l-1.86,2.73c-0.62,0.91-1.03,1.7-1.21,2.34c-0.2,0.72-0.06,1.24,0.41,1.56l0.25,0.17L320.27,145.82z" />
                                <path d="M321.61,148.78l-0.84,0.27l-0.29-0.83l-0.77,0.23l-0.32-0.87l0.87-0.25l0.28,0.8l0.74-0.22L321.61,148.78z
				 M323.09,147.75l-0.44-0.3c-0.6-0.41-0.85-0.89-0.75-1.44c-0.23,0.13-0.48,0.18-0.76,0.16c-0.28-0.03-0.53-0.11-0.75-0.26
				l-0.44-0.3l0.52-0.77l0.4,0.27c0.26,0.18,0.51,0.26,0.77,0.26c0.29,0,0.52-0.12,0.69-0.37l0.22-0.33l0.62,0.22
				c-0.34,0.5-0.48,0.9-0.42,1.19c0.04,0.23,0.23,0.45,0.56,0.68l0.31,0.21L323.09,147.75z" />
                                <path d="M330.93,144.21l-0.65,0.74c-0.75-0.18-1.57-0.33-2.45-0.46c-0.82-0.12-1.39-0.17-1.72-0.16
				c0.17,0.58,0.27,1.04,0.31,1.37c0.07,0.71-0.05,1.29-0.35,1.73c-0.73,1.07-1.74,1.16-3.04,0.27l-0.34-0.24l0.52-0.77l0.59,0.4
				c0.75,0.51,1.28,0.52,1.61,0.04c0.28-0.41,0.21-1.36-0.22-2.86c0.31-0.41,0.54-0.62,0.68-0.62
				C327.42,143.63,329.11,143.82,330.93,144.21z M331.62,143.11l-0.4,0.5c-0.58-0.13-1.38-0.25-2.41-0.36l-2.5-0.27l0.37-0.42
				C328.69,142.74,330.34,142.92,331.62,143.11z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M265.85,268.88c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C265.56,267.18,265.85,268,265.85,268.88z M263.24,265.33l-0.71,0.93l-0.95-0.64l0.7-0.95L263.24,265.33z" />
                                <path d="M269.93,271.07h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V271.07z" />
                                <path d="M273.91,271.07h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V271.07z M273.13,265.74l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L273.13,265.74z" />
                                <path d="M281.05,269.14c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C280.87,267.96,281.05,268.5,281.05,269.14z" />
                                <path d="M288.01,271.07h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V271.07z" />
                                <path d="M289.91,267.91c0,0.99-0.09,1.7-0.28,2.15c-0.29,0.67-0.82,1-1.61,1h-0.47v-1.08h0.48
				c0.48,0,0.8-0.19,0.95-0.56c0.09-0.22,0.14-0.63,0.14-1.21c0-0.18,0-0.35-0.01-0.51l-0.17-5.38l0.96-0.5V267.91z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M315.27,245.78l-0.36,0.96c-0.23-0.1-0.51-0.15-0.82-0.15c-0.47,0-0.95,0.16-1.45,0.47
				c-0.53,0.34-0.85,0.72-0.95,1.16c-0.01,0.04-0.01,0.09-0.01,0.14c0,0.23,0.28,0.38,0.85,0.46c0.37,0.02,0.75,0.05,1.12,0.08
				c0.88,0.1,1.32,0.51,1.32,1.23c0,0.73-0.54,1.42-1.63,2.06c-1.04,0.61-2.08,0.92-3.11,0.92c-1.01,0-1.8-0.23-2.39-0.68
				c-0.65-0.5-0.97-1.24-0.97-2.23c0-0.84,0.22-1.62,0.66-2.32l0.71,0.31c-0.33,0.59-0.5,1.16-0.5,1.7c0,1.42,0.88,2.12,2.64,2.12
				c0.6,0,1.22-0.11,1.88-0.33c0.68-0.23,1.24-0.53,1.68-0.9c0.21-0.18,0.32-0.34,0.32-0.47c0-0.18-0.16-0.29-0.47-0.33
				c-1.32-0.16-2.07-0.27-2.25-0.33c-0.41-0.15-0.61-0.5-0.61-1.06c0-0.77,0.37-1.49,1.11-2.15c0.72-0.64,1.47-0.96,2.25-0.96
				C314.67,245.48,315,245.58,315.27,245.78z" />
                                <path d="M322.23,250.59h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V250.59z M320.08,245.9
				l-0.71,0.93l-0.95-0.63l0.69-0.96L320.08,245.9z" />
                                <path d="M327.64,241.63l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C323.55,243.58,325.4,242.6,327.64,241.63z" />
                                <path d="M334.46,250.59h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V250.59z" />
                                <path d="M339.23,249.01c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.64,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C339.12,247.96,339.23,248.49,339.23,249.01z M338.34,248.78c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C338.28,249.19,338.34,249.05,338.34,248.78z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M275.48,223.51l0.2,1.16l-1.11,0.26l-0.22-1.16L275.48,223.51z M279.85,224.03
				c0.82,0.77,1.24,1.62,1.27,2.57c0.03,0.95-0.34,1.83-1.1,2.65c-0.67,0.71-1.44,1.06-2.32,1.03c-0.78-0.03-1.47-0.31-2.06-0.87
				c-0.52-0.49-0.87-1.1-1.04-1.85l0.67-0.34c0.23,0.6,0.5,1.06,0.82,1.36c1.1,1.02,2.17,0.97,3.23-0.17
				c0.54-0.57,0.82-1.18,0.84-1.8c0.02-0.66-0.26-1.25-0.82-1.79c-0.51-0.48-1.16-0.75-1.94-0.83l0.05-1.01
				C278.41,223.09,279.21,223.43,279.85,224.03z" />
                                <path d="M282.94,223.64l-0.35,0.68l-6.63-5.88l0.39-0.96L282.94,223.64z" />
                                <path d="M288.51,217.97l-0.32,0.35c-0.25,0.27-0.47,0.43-0.68,0.5c-0.33,0.11-0.78,0.08-1.34-0.08
				c0.24,0.54,0.27,1.05,0.12,1.53c-0.12,0.37-0.4,0.79-0.85,1.27c-0.59,0.63-1.14,0.95-1.65,0.98l-0.33-0.99
				c0.36-0.08,0.72-0.3,1.07-0.68c1.04-1.11,1.31-1.89,0.82-2.35c-0.08-0.07-0.18-0.14-0.29-0.2l-2.72-1.31l-0.09-1.03l3.03,1.53
				c1,0.51,1.71,0.54,2.12,0.1l0.32-0.35L288.51,217.97z" />
                                <path d="M292.67,213.52l-0.32,0.34c-0.31,0.33-0.77,0.51-1.39,0.53c0.52,0.68,0.66,1.12,0.42,1.32
				c-0.6,0.5-1.38,0.81-2.34,0.92c-0.01,0.52-0.15,0.93-0.44,1.24l-0.4,0.43l-0.79-0.74l0.28-0.3c0.47-0.51,0.64-0.99,0.52-1.46
				c-0.2-0.7-0.3-1.08-0.31-1.14c-0.11-0.54-0.09-0.9,0.08-1.08c0.15-0.16,0.48-0.22,0.98-0.17c0.77,0.08,1.24,0.12,1.42,0.1
				c0.57-0.04,1.01-0.22,1.32-0.55l0.18-0.2L292.67,213.52z M289.34,214.33c-0.36-0.08-0.58-0.08-0.67,0.01
				c-0.16,0.17-0.08,0.6,0.25,1.29c0.33-0.01,0.69-0.1,1.06-0.25c0.21-0.09,0.35-0.17,0.42-0.25c0.11-0.11,0.1-0.23-0.03-0.35
				C290.17,214.59,289.83,214.44,289.34,214.33z" />
                                <path d="M295.44,208.84c0.78,0.72,0.94,1.33,0.49,1.81c-0.11,0.12-0.76,0.41-1.94,0.87
				c-0.13,0.54-0.44,1.07-0.93,1.59l-0.7,0.74l-0.79-0.74l1.13-1.21c-0.57,0.25-1.05,0.19-1.45-0.18c-0.53-0.49-0.65-1.31-0.38-2.46
				l-0.47,0.09l-0.45-1.02C292.7,207.82,294.53,207.99,295.44,208.84z M292.73,209.76c-0.15-0.14-0.33-0.24-0.54-0.29
				c-0.25-0.06-0.43-0.03-0.56,0.11c-0.15,0.16-0.21,0.38-0.2,0.69c0.01,0.3,0.09,0.53,0.25,0.67c0.14,0.13,0.37,0.17,0.69,0.11
				c0.28-0.05,0.48-0.14,0.59-0.26c0.12-0.13,0.14-0.31,0.06-0.54C292.97,210.06,292.87,209.89,292.73,209.76z M294.87,209.39
				c-0.21-0.2-0.83-0.31-1.84-0.32c0.08,0.06,0.16,0.12,0.23,0.19c0.35,0.33,0.53,0.74,0.53,1.23c0.13-0.03,0.35-0.11,0.65-0.24
				c0.34-0.14,0.54-0.23,0.58-0.28C295.16,209.81,295.12,209.62,294.87,209.39z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M390.54,172.82c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C390.25,171.12,390.54,171.94,390.54,172.82z M387.93,169.27l-0.71,0.93l-0.95-0.64l0.7-0.95L387.93,169.27z" />
                                <path d="M392.93,174.81l-0.73,0.2l-0.23-8.86l0.97-0.37V174.81z" />
                                <path d="M398.43,173.53c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C398.17,172,398.43,172.75,398.43,173.53z" />
                                <path d="M400.82,174.81l-0.73,0.2l-0.23-8.86l0.97-0.37V174.81z" />
                                <path d="M408.77,175.01h-0.47c-0.36,0-0.64-0.05-0.83-0.15c-0.31-0.17-0.59-0.51-0.85-1.03
				c-0.24,0.54-0.58,0.92-1.03,1.13c-0.35,0.17-0.86,0.25-1.51,0.25c-0.86,0-1.47-0.18-1.84-0.54l0.5-0.92
				c0.31,0.21,0.71,0.32,1.22,0.32c1.52,0,2.28-0.34,2.28-1.01c0-0.11-0.02-0.22-0.06-0.35l-0.9-2.88l0.69-0.77l0.95,3.26
				c0.31,1.08,0.77,1.62,1.38,1.62h0.47V175.01z" />
                                <path d="M411.11,173.14c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C410.87,171.8,411.11,172.43,411.11,173.14z M410.66,169l-0.71,0.94L409,169.3
				l0.7-0.95L410.66,169z" />
                                <path d="M416.61,173.53c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C416.35,172,416.61,172.75,416.61,173.53z M415.8,169.2l-0.72,0.94l-0.95-0.64l0.69-0.96L415.8,169.2z" />
                                <path d="M420.69,175.01h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V175.01z" />
                                <path d="M425.45,173.44c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C425.34,172.39,425.45,172.92,425.45,173.44z M424.56,173.21c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C424.5,173.61,424.56,173.48,424.56,173.21z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M226.32,275.88c-0.14,0.19-0.4,0.37-0.79,0.55c-0.42,0.19-0.72,0.22-0.89,0.1
				c-0.19-0.13-0.45-0.35-0.81-0.64c-0.35-0.29-0.62-0.51-0.81-0.64c-0.39-0.28-0.73-0.34-1.04-0.18c-0.21,0.11-0.49,0.41-0.83,0.88
				l-3.02,4.2l-0.66-0.48l2.95-4.23c0.89-1.28,1.79-1.75,2.7-1.41c0.3-0.42,0.65-0.76,1.04-1.02c0.53-0.36,0.97-0.41,1.32-0.15
				c0.35,0.25,0.63,0.73,0.85,1.42C226.56,275.01,226.56,275.54,226.32,275.88z M225.4,275.4c0.08-0.12,0.09-0.36,0.01-0.73
				c-0.09-0.43-0.24-0.72-0.44-0.86c-0.14-0.1-0.32-0.1-0.53,0.01c-0.17,0.09-0.31,0.22-0.43,0.37c-0.05,0.08-0.1,0.16-0.14,0.25
				c0.1,0.08,0.27,0.22,0.51,0.43c0.21,0.19,0.38,0.33,0.5,0.41C225.14,275.48,225.32,275.51,225.4,275.4z" />
                                <path d="M232.69,283.35l-0.39-0.28c-0.54-0.38-0.76-0.98-0.68-1.78c0.07-0.61,0.28-1.24,0.65-1.91
				c-1.5,1.26-3.31,1.34-5.44,0.25l0.09-0.86c0.72,0.31,1.46,0.51,2.22,0.61c0.82,0.1,1.4,0.02,1.72-0.23
				c0.04-0.03,0.08-0.07,0.11-0.12c0.37-0.52,0.36-1.58-0.04-3.17c-0.32-1.27-0.71-2.33-1.15-3.17l0.9-0.88
				c0.55,1.25,0.94,2.52,1.17,3.8c0.26,1.45,0.23,2.54-0.08,3.28c0.66-0.53,1.41-1.38,2.23-2.53c0.48-0.67,0.93-1.35,1.33-2.04
				l1,0.27l-2.25,3.14c-0.75,1.05-1.24,1.95-1.47,2.7c-0.25,0.83-0.11,1.45,0.43,1.83l0.28,0.2L232.69,283.35z" />
                                <path d="M234.04,286.74l-0.99,0.29l-0.32-0.98l-0.9,0.25l-0.35-1.02l1.02-0.27l0.3,0.94l0.87-0.23L234.04,286.74z
				 M235.68,283.19c-0.73,1.01-1.68,1.1-2.86,0.25l-0.5-0.36l0.63-0.88l0.55,0.39c0.68,0.49,1.15,0.55,1.42,0.18
				c0.14-0.2,0.21-0.5,0.19-0.9l-0.01-0.41l1.09-0.23C236.26,281.96,236.09,282.61,235.68,283.19z" />
                                <path d="M237.11,286.27l-0.72-0.26l4.98-7.34l1,0.26L237.11,286.27z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M321.81,187.49l-0.32,0.28c-0.26,0.22-0.55,0.32-0.88,0.29c0.07,0.08,0.14,0.16,0.21,0.24
				c0.7,0.82,1,1.69,0.91,2.62c-0.09,0.93-0.56,1.75-1.38,2.45c-0.69,0.59-1.42,0.86-2.19,0.82c-0.77-0.05-1.45-0.41-2.04-1.1
				c-0.47-0.55-0.78-1.23-0.92-2.03l0.68-0.25c0.1,0.6,0.35,1.12,0.74,1.57c0.94,1.09,2,1.13,3.18,0.11
				c0.54-0.47,0.89-1.01,1.05-1.62c0.17-0.69,0.03-1.3-0.42-1.82c-0.45-0.53-1.08-0.92-1.87-1.16l0.16-1.06
				c0.52,0.22,0.89,0.36,1.1,0.39c0.41,0.07,0.75-0.01,1.03-0.25l0.29-0.25L321.81,187.49z M316.58,187.41l0.07,1.12l-1.08,0.13
				l-0.09-1.12L316.58,187.41z" />
                                <path d="M322.37,184.54c0.81,0.95,0.67,1.89-0.43,2.84l-0.47,0.4l-0.71-0.82l0.51-0.44
				c0.64-0.55,0.81-0.99,0.51-1.33c-0.16-0.18-0.44-0.32-0.83-0.4l-0.4-0.08l0.03-1.11C321.32,183.68,321.91,184,322.37,184.54z
				 M325.44,186.98l0.04,1.03l-1.03,0.08l0.03,0.94l-1.07,0.1l-0.02-1.05l0.98-0.07l-0.02-0.9L325.44,186.98z" />
                                <path d="M326.86,181.03c0.67,0.78,1.02,1.72,1.05,2.82c0.03,0.99-0.2,1.97-0.69,2.97l-1.02-0.13
				c0.4-1.05,0.64-1.85,0.72-2.42c0.13-0.88,0-1.64-0.39-2.27c-0.1,0.33-0.3,0.63-0.62,0.9c-0.31,0.26-0.62,0.4-0.93,0.41
				c-0.35,0.01-0.65-0.14-0.91-0.44c-0.34-0.4-0.56-0.87-0.66-1.42c-0.11-0.61-0.01-1.05,0.32-1.33c0.44-0.38,0.99-0.42,1.67-0.14
				C325.95,180.18,326.44,180.54,326.86,181.03z M325.76,181.35c-0.52-0.55-0.97-0.66-1.35-0.34c-0.13,0.11-0.19,0.28-0.17,0.49
				c0.02,0.22,0.09,0.39,0.21,0.53c0.25,0.29,0.55,0.28,0.91-0.03C325.56,181.84,325.69,181.62,325.76,181.35z" />
                                <path d="M328.53,175.56l0.07,1.17l-1.13,0.14l-0.1-1.18L328.53,175.56z M333.21,177.72l-0.34,0.29
				c-0.28,0.24-0.56,0.39-0.84,0.46c0.5,0.76,0.65,1.79,0.45,3.1c-0.14,0.88-0.4,1.77-0.8,2.65l-0.89,0.01
				c0.37-1.06,0.63-2.04,0.78-2.93c0.18-1.13,0.12-1.87-0.18-2.22c-0.23-0.27-0.71-0.49-1.43-0.67l0.01-1.11
				c0.61,0.16,0.97,0.24,1.07,0.25c0.43,0.03,0.8-0.08,1.11-0.36l0.35-0.3L333.21,177.72z" />
                                <path d="M330.61,170.06l0.05,1.02l-1.02,0.07l0.03,0.94l-1.07,0.1l-0.03-1.06l1-0.07l-0.02-0.9L330.61,170.06z
				 M334.15,173.56c1.1,1.29,0.99,2.5-0.33,3.63l-0.96,0.82l-0.71-0.82l0.86-0.74c0.22-0.19,0.45-0.46,0.69-0.84
				c0.32-0.47,0.41-0.79,0.27-0.95l-0.31-0.36c-0.12,0.35-0.33,0.66-0.63,0.92c-0.27,0.23-0.55,0.34-0.84,0.31
				c-0.29-0.02-0.55-0.16-0.78-0.43c-0.27-0.31-0.47-0.75-0.63-1.31c-0.19-0.71-0.12-1.21,0.21-1.5c0.36-0.31,0.92-0.27,1.68,0.13
				C333.29,172.75,333.78,173.13,334.15,173.56z M332.93,173.71c-0.64-0.53-1.09-0.69-1.34-0.47c-0.11,0.09-0.14,0.28-0.09,0.55
				c0.04,0.25,0.11,0.43,0.22,0.55c0.24,0.28,0.51,0.3,0.81,0.05C332.76,174.19,332.89,173.96,332.93,173.71z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M345.62,185l0.05,0.95l-0.91,0.11l-0.08-0.95L345.62,185z M348.38,187.22c0.45,0.53,0.61,1.33,0.47,2.41
				c-0.1,0.76-0.3,1.49-0.61,2.18l-0.76,0.04c0.31-0.82,0.52-1.6,0.62-2.32c0.13-0.89,0.07-1.47-0.17-1.76
				c-0.24-0.29-0.67-0.5-1.26-0.65l0.07-0.87C347.42,186.43,347.97,186.75,348.38,187.22z" />
                                <path d="M353.42,184.48l-0.27,0.23c-0.23,0.19-0.45,0.32-0.68,0.37c0.4,0.61,0.53,1.44,0.36,2.5
				c-0.11,0.71-0.32,1.42-0.64,2.13l-0.72,0.01c0.3-0.86,0.51-1.64,0.63-2.36c0.15-0.91,0.1-1.5-0.15-1.79
				c-0.18-0.21-0.57-0.39-1.16-0.54l0.01-0.89c0.49,0.12,0.78,0.19,0.86,0.2c0.34,0.03,0.64-0.07,0.9-0.29l0.28-0.24L353.42,184.48z" />
                                <path d="M355.85,182.39l-0.38,0.32c-0.52,0.45-1.02,0.55-1.49,0.33c0.06,0.24,0.05,0.48-0.04,0.73
				c-0.09,0.25-0.23,0.46-0.42,0.62l-0.38,0.33l-0.57-0.66l0.34-0.29c0.22-0.19,0.36-0.4,0.43-0.63c0.07-0.26,0.02-0.5-0.16-0.71
				l-0.24-0.28l0.35-0.51c0.37,0.43,0.7,0.65,0.98,0.67c0.22,0.02,0.47-0.1,0.75-0.35l0.27-0.23L355.85,182.39z M356.07,184.36
				l0.05,0.94l-0.9,0.11l-0.08-0.95L356.07,184.36z" />
                                <path d="M355.37,179.46c0.52,0.6,0.83,1.09,0.95,1.46c0.18,0.56,0.02,1.05-0.46,1.46l-0.28,0.24l-0.57-0.66
				l0.29-0.25c0.29-0.25,0.39-0.53,0.29-0.84c-0.06-0.18-0.24-0.46-0.55-0.81c-0.1-0.11-0.19-0.22-0.27-0.31l-2.92-3.2l0.33-0.81
				L355.37,179.46z" />
                                <path d="M358.37,180.02l-0.34,0.51l-4.79-5.3l0.4-0.73L358.37,180.02z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M359.56,435.68l-0.25-0.37c-0.21-0.3-0.33-0.6-0.37-0.88c-0.81,0.42-1.85,0.46-3.13,0.12
				c-0.86-0.23-1.71-0.59-2.55-1.07l0.08-0.88c1.02,0.48,1.96,0.84,2.83,1.09c1.1,0.3,1.85,0.32,2.23,0.05
				c0.29-0.2,0.56-0.65,0.81-1.36l1.1,0.12c-0.22,0.59-0.34,0.94-0.36,1.04c-0.08,0.42,0,0.8,0.24,1.14l0.26,0.38L359.56,435.68z" />
                                <path d="M362.83,440.43l-0.28-0.4c-0.26-0.37-0.55-0.65-0.88-0.83c-0.42-0.23-0.8-0.24-1.13-0.01
				c-0.34,0.23-0.47,0.61-0.41,1.12l-1,0.3c-0.49-1.59-0.19-3.01,0.89-4.24l-0.72-1.05l0.89-0.62l0.66,0.95
				c0.71-0.49,1.51-0.79,2.42-0.9c0.8-0.1,1.28-0.03,1.44,0.2c0.13,0.18,0.08,0.54-0.14,1.06c-0.24,0.56-0.57,0.99-0.99,1.28
				c-0.48,0.33-1.01,0.5-1.57,0.51c-0.64,0.01-1.12-0.22-1.43-0.68c-0.38,0.44-0.57,0.99-0.58,1.66c0.08-0.09,0.16-0.17,0.26-0.23
				c0.48-0.33,1.03-0.43,1.64-0.29c0.59,0.13,1.06,0.44,1.39,0.93l0.43,0.62L362.83,440.43z M362.93,436.81
				c0.28-0.19,0.47-0.42,0.59-0.7c0.1-0.23,0.12-0.38,0.06-0.46c-0.06-0.08-0.29-0.08-0.71,0c-0.51,0.1-1,0.32-1.47,0.64
				c0.18,0.32,0.4,0.53,0.66,0.63C362.35,437.05,362.64,437.01,362.93,436.81z" />
                                <path d="M368.47,445.21c-0.43,0.3-0.87,0.43-1.33,0.41c-0.49-0.02-0.89-0.25-1.18-0.66
				c-0.38-0.55-0.44-1.08-0.19-1.58c-0.61-0.01-1.09-0.27-1.44-0.78c-0.38-0.55-0.41-1.04-0.1-1.47c-0.57,0.05-1.04-0.18-1.4-0.71
				l-0.26-0.38l0.89-0.62l0.15,0.22c0.46,0.67,1.01,0.78,1.66,0.33l0.14-0.1l0.61,0.44l-0.15,0.11c-0.78,0.54-0.99,1.06-0.64,1.58
				c0.41,0.59,0.94,0.67,1.59,0.22l0.14-0.1l0.61,0.44l-0.16,0.11c-0.78,0.54-0.97,1.11-0.56,1.7c0.29,0.43,0.63,0.51,1.02,0.24
				c0.27-0.19,0.45-0.49,0.54-0.91l1.05,0.12C369.34,444.39,369,444.85,368.47,445.21z M370.76,441.73l-0.92-0.05l0.03-1l-0.89-0.06
				l0.02-0.97l0.94,0.07l-0.04,0.96l0.87,0.06L370.76,441.73z M371.29,440.21l-0.87-0.04l0.03-0.98l0.87,0.06L371.29,440.21z" />
                                <path d="M370.43,451.45l-0.67-0.97c-1.63,0.74-3.35,0.54-5.16-0.6l0.24-1c0.99,0.5,1.75,0.82,2.29,0.97
				c0.82,0.23,1.53,0.21,2.12-0.06c-0.17-0.17-0.33-0.37-0.48-0.58c-0.62-0.89-0.61-1.56,0.03-2c0.39-0.27,0.87-0.43,1.46-0.5
				c0.67-0.08,1.13,0.06,1.37,0.41c0.31,0.45,0.33,0.96,0.06,1.52c-0.2,0.43-0.54,0.85-1.02,1.25l0.65,0.94L370.43,451.45z
				 M370.13,449.06c0.22-0.17,0.39-0.38,0.52-0.62c0.16-0.29,0.17-0.54,0.02-0.75c-0.1-0.14-0.27-0.22-0.51-0.21
				c-0.22,0-0.4,0.06-0.55,0.16c-0.24,0.16-0.23,0.45,0.02,0.85C369.8,448.78,369.97,448.97,370.13,449.06z" />
                                <path d="M369.92,454.29l-1.17-0.06l-0.02-1.14l1.19,0.03L369.92,454.29z M373.29,452.3
				c-1.03,0.71-1.95,0.47-2.78-0.73l-0.35-0.51l0.89-0.62l0.38,0.56c0.48,0.69,0.9,0.91,1.27,0.65c0.2-0.14,0.36-0.4,0.49-0.79
				l0.12-0.38l1.1,0.15C374.26,451.34,373.88,451.9,373.29,452.3z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M341.99,352.11c-0.52,0.44-1.14,0.68-1.86,0.7c-0.65,0.02-1.3-0.13-1.96-0.45l0.09-0.67
				c0.69,0.26,1.22,0.42,1.6,0.48c0.58,0.08,1.08,0,1.5-0.26c-0.22-0.06-0.42-0.2-0.6-0.41c-0.17-0.2-0.26-0.41-0.27-0.62
				c-0.01-0.23,0.09-0.43,0.29-0.6c0.26-0.23,0.57-0.37,0.94-0.44c0.4-0.07,0.69,0,0.88,0.21c0.25,0.29,0.28,0.66,0.1,1.1
				C342.55,351.51,342.31,351.83,341.99,352.11z M341.77,351.39c0.36-0.34,0.44-0.64,0.22-0.89c-0.08-0.09-0.18-0.12-0.33-0.11
				c-0.14,0.01-0.26,0.06-0.35,0.14c-0.19,0.16-0.18,0.36,0.02,0.6C341.45,351.25,341.6,351.34,341.77,351.39z" />
                                <path d="M345.87,358.27l-0.29-0.33c-0.26-0.3-0.38-0.59-0.38-0.87c0.01-0.27,0.13-0.56,0.37-0.89
				c-0.39-0.09-0.75-0.32-1.09-0.71c-0.13-0.15-0.19-0.32-0.18-0.51c0.01-0.19,0.09-0.34,0.24-0.47c0.52-0.44,1.31-0.45,2.37,0
				l0.34-0.42l0.64,0.12l-1.51,1.89c-0.28,0.35-0.43,0.6-0.46,0.76c-0.04,0.22,0.07,0.48,0.32,0.78l0.17,0.2L345.87,358.27z
				 M345.98,355.62l0.52-0.66c-0.22-0.11-0.44-0.19-0.68-0.25c-0.33-0.08-0.55-0.06-0.68,0.05c-0.09,0.08-0.06,0.21,0.1,0.39
				C345.5,355.45,345.74,355.6,345.98,355.62z" />
                                <path d="M346.2,360.66l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.06-0.71l0.7-0.01l0.04,0.65l0.6-0.01L346.2,360.66z
				 M347.81,358.64c-0.63,0.54-1.25,0.44-1.87-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34
				c0.12-0.1,0.21-0.29,0.27-0.55l0.05-0.26l0.74,0.02C348.38,357.94,348.17,358.34,347.81,358.64z" />
                                <path d="M349.8,362.86l-0.51-0.59c-1.02,0.6-2.16,0.59-3.43-0.04l0.09-0.67c0.68,0.26,1.21,0.42,1.57,0.48
				c0.56,0.09,1.02,0.03,1.39-0.19c-0.13-0.1-0.24-0.22-0.36-0.35c-0.47-0.54-0.51-0.98-0.12-1.32c0.24-0.2,0.54-0.35,0.92-0.43
				c0.43-0.1,0.74-0.04,0.93,0.18c0.23,0.27,0.28,0.61,0.15,0.99c-0.1,0.3-0.3,0.59-0.59,0.89l0.49,0.57L349.8,362.86z
				 M349.43,361.31c0.13-0.13,0.23-0.28,0.3-0.44c0.08-0.2,0.07-0.37-0.04-0.49c-0.07-0.09-0.19-0.12-0.35-0.1
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.14,0.12-0.12,0.31,0.07,0.56C349.2,361.15,349.32,361.26,349.43,361.31z" />
                                <path d="M351.25,364.55l-0.2-0.23c-0.28-0.32-0.31-0.69-0.1-1.11c-0.49,0.09-0.88-0.03-1.16-0.36l-0.2-0.23
				l0.54-0.47l0.11,0.12c0.25,0.29,0.51,0.41,0.77,0.35c0.2-0.04,0.45-0.2,0.76-0.49l2.81-2.56l0.66,0.27l-2.95,2.53
				c-0.75,0.65-0.96,1.16-0.63,1.55l0.13,0.15L351.25,364.55z" />
                                <path d="M351.65,367.01l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.04,0.65l0.6-0.01L351.65,367.01z
				 M352.96,366.54l-0.27-0.31c-0.36-0.42-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.04c-0.2-0.08-0.37-0.19-0.51-0.35
				l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.58-0.13l0.23-0.2l0.42,0.29
				c-0.35,0.31-0.54,0.57-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L352.96,366.54z" />
                                <path d="M355.62,369.64l-0.19-0.23c-0.51-0.6-0.58-1.5-0.2-2.71c-0.06,0.08-0.13,0.14-0.2,0.2
				c-0.36,0.3-0.73,0.4-1.13,0.28c-0.34-0.1-0.67-0.33-0.98-0.71l-0.22-0.25l0.54-0.47l0.19,0.22c0.57,0.67,1.05,0.83,1.45,0.49
				c0.2-0.17,0.31-0.42,0.33-0.75c0.01-0.24,0.03-0.67,0.06-1.29c0.36-0.29,0.57-0.43,0.63-0.42c0.49,0.12,1.18,0.36,2.08,0.71
				c0.86,0.34,1.53,0.63,2,0.87l-0.62,0.41c-0.49-0.25-1.1-0.52-1.84-0.83c-0.8-0.33-1.33-0.52-1.61-0.57c0,0.26,0.01,0.58,0.01,0.95
				c0,0.3-0.02,0.59-0.06,0.88c-0.1,0.65-0.15,1.12-0.16,1.42c-0.01,0.5,0.08,0.87,0.27,1.08l0.2,0.23L355.62,369.64z" />
                                <path d="M358.1,372.53l-0.21-0.24c-0.19-0.23-0.41-0.39-0.64-0.49c-0.29-0.12-0.54-0.1-0.74,0.08
				c-0.21,0.18-0.27,0.43-0.19,0.76l-0.63,0.26c-0.43-1.01-0.34-1.96,0.29-2.84l-0.55-0.64l0.54-0.47l0.5,0.58
				c0.43-0.37,0.94-0.62,1.52-0.76c0.52-0.12,0.84-0.11,0.96,0.03c0.1,0.11,0.09,0.35-0.02,0.71c-0.12,0.39-0.3,0.69-0.56,0.91
				c-0.29,0.25-0.62,0.4-0.99,0.44c-0.42,0.05-0.75-0.07-0.99-0.35c-0.22,0.31-0.31,0.69-0.26,1.13c0.04-0.06,0.1-0.12,0.16-0.17
				c0.29-0.25,0.64-0.35,1.06-0.31c0.4,0.05,0.72,0.22,0.98,0.51l0.33,0.38L358.1,372.53z M357.91,370.15
				c0.17-0.14,0.28-0.31,0.34-0.5c0.05-0.16,0.05-0.26,0.01-0.31c-0.04-0.05-0.2-0.04-0.46,0.05c-0.33,0.1-0.63,0.28-0.92,0.52
				c0.14,0.2,0.3,0.32,0.47,0.37C357.55,370.34,357.74,370.3,357.91,370.15z" />
                                <path d="M364.9,371.39l-0.63,0.41c-1.28-0.65-2.36-1.09-3.23-1.32c0.03,1.2-0.19,2-0.66,2.4
				c-0.22,0.19-0.5,0.3-0.84,0.33c-0.54,0.04-1.04-0.21-1.5-0.74l-0.21-0.24l0.54-0.47l0.36,0.42c0.45,0.52,0.85,0.63,1.21,0.33
				c0.2-0.17,0.33-0.47,0.38-0.9c0.01-0.07,0.03-0.53,0.05-1.37c0.34-0.27,0.57-0.38,0.67-0.36
				C362.17,370.18,363.46,370.68,364.9,371.39z" />
                                <path d="M335.2,363.96l-0.2-0.24c-0.16-0.18-0.25-0.34-0.28-0.48c-0.05-0.22,0-0.51,0.15-0.87
				c-0.37,0.11-0.71,0.1-1.01-0.03c-0.23-0.11-0.49-0.32-0.77-0.65c-0.37-0.43-0.54-0.81-0.52-1.15l0.67-0.14
				c0.02,0.25,0.15,0.5,0.36,0.75c0.65,0.76,1.15,1,1.48,0.71c0.05-0.05,0.1-0.11,0.15-0.18l1.06-1.69l0.68,0.01l-1.23,1.87
				c-0.41,0.62-0.48,1.08-0.22,1.38l0.2,0.24L335.2,363.96z" />
                                <path d="M337.81,367l-0.2-0.23c-0.19-0.23-0.28-0.54-0.25-0.95c-0.48,0.29-0.78,0.35-0.9,0.18
				c-0.29-0.43-0.43-0.97-0.44-1.6c-0.34-0.04-0.6-0.17-0.78-0.38l-0.25-0.29l0.54-0.47l0.18,0.21c0.3,0.35,0.6,0.5,0.92,0.44
				c0.47-0.08,0.73-0.12,0.77-0.12c0.36-0.03,0.6,0.01,0.7,0.13c0.1,0.11,0.11,0.33,0.04,0.66c-0.11,0.5-0.17,0.81-0.17,0.93
				c-0.02,0.38,0.07,0.68,0.26,0.91l0.12,0.13L337.81,367z M337.52,364.76c0.08-0.23,0.1-0.38,0.04-0.44
				c-0.1-0.12-0.39-0.1-0.86,0.07c-0.01,0.22,0.01,0.46,0.09,0.71c0.04,0.14,0.09,0.24,0.13,0.29c0.07,0.08,0.14,0.08,0.23,0
				C337.29,365.29,337.41,365.07,337.52,364.76z" />
                                <path d="M342.22,369.06l-0.63,0.32c-0.37-0.43-0.77-0.72-1.2-0.86c-0.22-0.07-0.6-0.2-1.16-0.38
				c-0.43-0.15-0.85-0.47-1.26-0.95l-0.35-0.41l0.54-0.47l0.37,0.43c0.28,0.33,0.55,0.57,0.82,0.73c0.17,0.11,0.43,0.22,0.78,0.35
				c0.37,0.13,0.64,0.25,0.79,0.33c-0.08-0.17-0.18-0.45-0.3-0.86c-0.11-0.37-0.19-0.59-0.26-0.67c-0.11-0.12-0.35-0.2-0.72-0.23
				l-0.09-0.46c0.22-0.04,0.45-0.05,0.7-0.02c0.3,0.03,0.5,0.11,0.6,0.22c0.15,0.17,0.27,0.43,0.37,0.79c0.16,0.58,0.26,0.91,0.29,1
				C341.68,368.34,341.91,368.72,342.22,369.06z" />
                                <path d="M341.82,371.47l-0.42-0.28l4.34-3.92l0.6,0.33L341.82,371.47z" />
                                <path d="M344.71,375.04l-0.19-0.22c-0.16-0.18-0.26-0.37-0.3-0.55c-0.5,0.33-1.18,0.43-2.05,0.3
				c-0.58-0.09-1.17-0.27-1.75-0.53l-0.01-0.59c0.7,0.25,1.35,0.42,1.93,0.52c0.74,0.12,1.23,0.08,1.47-0.12
				c0.17-0.15,0.32-0.46,0.44-0.95l0.73,0c-0.1,0.4-0.16,0.64-0.16,0.71c-0.02,0.28,0.06,0.52,0.23,0.73l0.2,0.23L344.71,375.04z" />
                                <path d="M345.05,377.43l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.04,0.65l0.6-0.01L345.05,377.43z
				 M346.65,375.41c-0.63,0.54-1.25,0.44-1.87-0.28l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34
				c0.12-0.1,0.21-0.29,0.26-0.55l0.05-0.26l0.73,0.02C347.22,374.72,347.01,375.11,346.65,375.41z" />
                                <path d="M348.64,379.63l-0.51-0.59c-1.02,0.6-2.16,0.59-3.43-0.04l0.09-0.67c0.68,0.26,1.21,0.42,1.57,0.48
				c0.56,0.09,1.02,0.03,1.39-0.19c-0.13-0.1-0.24-0.22-0.36-0.35c-0.47-0.54-0.51-0.98-0.12-1.32c0.24-0.2,0.54-0.34,0.92-0.43
				c0.43-0.1,0.74-0.04,0.93,0.18c0.24,0.27,0.28,0.61,0.15,0.99c-0.1,0.29-0.3,0.59-0.58,0.89l0.49,0.57L348.64,379.63z
				 M348.28,378.08c0.13-0.13,0.23-0.28,0.3-0.44c0.08-0.2,0.07-0.37-0.04-0.49c-0.08-0.09-0.19-0.12-0.35-0.1
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.14,0.12-0.12,0.31,0.07,0.56C348.04,377.92,348.17,378.03,348.28,378.08z" />
                                <path d="M348.51,381.53l-0.77,0.04l-0.09-0.75l0.78-0.06L348.51,381.53z M350.58,379.99
				c-0.63,0.54-1.25,0.44-1.87-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34c0.12-0.1,0.21-0.29,0.26-0.55
				l0.05-0.26l0.74,0.02C351.14,379.29,350.94,379.68,350.58,379.99z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M320.75,301.39l-0.64,0.23c-0.05-0.16-0.14-0.32-0.28-0.48c-0.2-0.24-0.49-0.41-0.86-0.52
				c-0.4-0.12-0.73-0.11-0.99,0.02c-0.02,0.01-0.05,0.03-0.08,0.05c-0.11,0.1-0.07,0.31,0.14,0.62c0.15,0.2,0.3,0.4,0.44,0.6
				c0.33,0.48,0.31,0.88-0.05,1.19c-0.37,0.32-0.95,0.34-1.73,0.07c-0.75-0.26-1.35-0.65-1.8-1.17c-0.43-0.51-0.66-1-0.69-1.49
				c-0.03-0.54,0.21-1.02,0.7-1.45c0.42-0.36,0.91-0.58,1.45-0.67l0.15,0.49c-0.44,0.09-0.8,0.25-1.07,0.48
				c-0.71,0.61-0.69,1.36,0.07,2.24c0.26,0.3,0.58,0.57,0.98,0.8c0.41,0.24,0.8,0.39,1.17,0.46c0.18,0.03,0.31,0.01,0.38-0.04
				c0.09-0.08,0.08-0.2-0.04-0.38c-0.49-0.73-0.76-1.15-0.8-1.27c-0.1-0.27-0.01-0.52,0.27-0.76c0.39-0.33,0.91-0.45,1.56-0.37
				c0.63,0.08,1.11,0.32,1.45,0.71C320.64,300.96,320.73,301.16,320.75,301.39z" />
                                <path d="M321.45,305.56c-0.43,0.37-1.09,0.5-1.98,0.39c-0.63-0.08-1.22-0.25-1.79-0.5l-0.04-0.63
				c0.68,0.25,1.31,0.42,1.91,0.51c0.73,0.11,1.21,0.06,1.44-0.14c0.23-0.2,0.41-0.55,0.54-1.04l0.71,0.05
				C322.1,304.78,321.83,305.23,321.45,305.56z" />
                                <path d="M322.46,308.25l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.17c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.81-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.16,0.3-0.12,0.58,0.1,0.84l0.13,0.15L322.46,308.25z" />
                                <path d="M322.85,310.71l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.05,0.65l0.6-0.01L322.85,310.71z
				 M324.17,310.24l-0.27-0.31c-0.37-0.43-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.03c-0.21-0.08-0.37-0.19-0.51-0.35
				l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.59-0.13l0.23-0.2l0.42,0.29
				c-0.35,0.31-0.54,0.57-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L324.17,310.24z" />
                                <path d="M325.89,312.25l-0.27-0.31c-0.37-0.43-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.04
				c-0.21-0.08-0.37-0.19-0.51-0.35l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.59-0.13
				l0.23-0.2l0.42,0.29c-0.35,0.31-0.54,0.58-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L325.89,312.25z M328.22,309.56
				l-0.68,0.03l-0.05-0.67l-0.62,0.01l-0.06-0.71l0.7-0.02l0.05,0.65l0.6-0.01L328.22,309.56z" />
                                <path d="M329.33,316.26l-0.5-0.58c-0.28-0.33-0.37-0.66-0.27-0.99c0.03-0.1,0.15-0.31,0.37-0.66l-1.53-0.62
				c-0.52-0.21-0.96-0.53-1.33-0.95l-0.39-0.45l0.54-0.46l0.37,0.43c0.37,0.43,0.76,0.74,1.17,0.93c0.25,0.11,0.69,0.31,1.33,0.59
				c-0.13-0.25-0.26-0.58-0.39-1.01c-0.12-0.39-0.2-0.62-0.26-0.69c-0.12-0.14-0.34-0.21-0.66-0.18l-0.11-0.48
				c0.66-0.15,1.09-0.1,1.3,0.14c0.14,0.16,0.26,0.42,0.37,0.78c0.16,0.54,0.27,0.88,0.32,1.02c0.17,0.43,0.41,0.82,0.72,1.18
				c0.06,0.07,0.12,0.15,0.19,0.22l-0.62,0.31c-0.25-0.29-0.49-0.48-0.71-0.58c-0.22,0.32-0.14,0.7,0.24,1.14l0.38,0.44
				L329.33,316.26z M330.98,311.67l-0.77,0.04l-0.09-0.75l0.78-0.06L330.98,311.67z" />
                                <path d="M329.2,318.17l-0.77,0.04l-0.09-0.75l0.78-0.06L329.2,318.17z M331.28,316.63
				c-0.63,0.54-1.25,0.44-1.88-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.66,0.53,0.88,0.34c0.12-0.11,0.21-0.29,0.27-0.55
				l0.05-0.26l0.74,0.02C331.84,315.93,331.63,316.32,331.28,316.63z" />
                                <path d="M335,321.22c-0.52,0.45-1.14,0.68-1.86,0.7c-0.65,0.02-1.31-0.13-1.96-0.45l0.09-0.67
				c0.69,0.26,1.23,0.42,1.6,0.48c0.58,0.08,1.08,0,1.5-0.26c-0.22-0.07-0.42-0.2-0.6-0.41c-0.18-0.2-0.27-0.41-0.27-0.62
				c-0.01-0.23,0.09-0.43,0.29-0.6c0.26-0.23,0.58-0.37,0.94-0.43c0.4-0.07,0.69,0,0.88,0.21c0.25,0.29,0.28,0.66,0.1,1.1
				C335.56,320.63,335.32,320.95,335,321.22z M334.79,320.5c0.36-0.34,0.44-0.64,0.22-0.89c-0.08-0.09-0.18-0.12-0.33-0.11
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.19,0.16-0.18,0.36,0.02,0.6C334.46,320.37,334.6,320.45,334.79,320.5z" />
                                <path d="M340.53,326.49c-0.67,0.57-1.26,0.9-1.77,0.99c-0.65,0.11-1.25-0.15-1.78-0.78
				c-0.41-0.48-0.59-0.96-0.55-1.45s0.3-0.94,0.78-1.34c0.16-0.13,0.37-0.26,0.64-0.4c0.27-0.13,0.5-0.21,0.7-0.25l0.18,0.46
				c-0.42,0.11-0.75,0.27-0.99,0.48c-0.75,0.64-0.8,1.34-0.16,2.09c0.65,0.75,1.46,0.72,2.42-0.11c0.21-0.18,1.24-1.12,3.1-2.82
				l0.66,0.34L340.53,326.49z" />
                                <path d="M340.88,329.73l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.17c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.82-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.15,0.3-0.12,0.58,0.1,0.84l0.13,0.15L340.88,329.73z" />
                                <path d="M344.32,333.74l-0.5-0.58c-0.28-0.33-0.37-0.66-0.27-0.99c0.03-0.1,0.15-0.31,0.37-0.66l-1.53-0.62
				c-0.52-0.21-0.96-0.53-1.33-0.95l-0.39-0.45l0.54-0.46l0.37,0.43c0.37,0.43,0.76,0.74,1.17,0.93c0.25,0.11,0.69,0.31,1.33,0.59
				c-0.14-0.25-0.26-0.58-0.39-1.01c-0.12-0.39-0.2-0.62-0.26-0.69c-0.12-0.14-0.34-0.21-0.66-0.18l-0.11-0.48
				c0.66-0.15,1.09-0.1,1.3,0.14c0.14,0.16,0.26,0.42,0.37,0.78c0.16,0.54,0.27,0.88,0.32,1.02c0.17,0.43,0.41,0.82,0.72,1.18
				c0.06,0.07,0.13,0.15,0.19,0.22l-0.62,0.31c-0.25-0.29-0.49-0.48-0.71-0.58c-0.22,0.31-0.14,0.69,0.24,1.14l0.38,0.44
				L344.32,333.74z" />
                                <path d="M347.16,335.45c-0.08,0.07-0.25,0.13-0.5,0.18c-0.27,0.05-0.45,0.03-0.52-0.05
				c-0.13-0.15-0.24-0.37-0.32-0.66c-0.08-0.26-0.11-0.51-0.1-0.73c-0.36,0-0.62-0.03-0.8-0.08c-0.24-0.06-0.44-0.19-0.6-0.37
				l-0.2-0.23l0.54-0.47l0.11,0.12c0.33,0.38,0.75,0.52,1.27,0.43c0.17-0.04,0.48-0.09,0.93-0.17c0.45-0.08,0.75-0.02,0.92,0.17
				c0.19,0.22,0.16,0.55-0.07,0.99C347.64,334.94,347.42,335.23,347.16,335.45z M346.9,334.91c0.11-0.09,0.21-0.24,0.31-0.44
				c0.11-0.23,0.14-0.38,0.07-0.46c-0.09-0.1-0.4-0.08-0.93,0.07c0.01,0.26,0.07,0.5,0.16,0.72c0.04,0.1,0.08,0.16,0.1,0.19
				C346.67,335.05,346.76,335.02,346.9,334.91z" />
                                <path d="M349.48,338.24c-0.43,0.37-1.09,0.5-1.98,0.39c-0.63-0.08-1.22-0.25-1.79-0.5l-0.04-0.63
				c0.68,0.25,1.31,0.42,1.91,0.51c0.73,0.11,1.21,0.06,1.44-0.14c0.23-0.2,0.41-0.54,0.54-1.04l0.71,0.05
				C350.14,337.46,349.87,337.91,349.48,338.24z" />
                                <path d="M350.49,340.93l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.16c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.81-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.16,0.3-0.12,0.58,0.1,0.84l0.13,0.15L350.49,340.93z" />
                                <path d="M352.97,343.81l-0.21-0.25c-0.19-0.23-0.41-0.39-0.64-0.49c-0.29-0.12-0.54-0.1-0.75,0.08
				c-0.21,0.18-0.27,0.43-0.19,0.77l-0.63,0.26c-0.44-1.01-0.34-1.96,0.29-2.85l-0.55-0.64l0.54-0.47l0.5,0.58
				c0.43-0.37,0.94-0.62,1.53-0.76c0.52-0.12,0.84-0.11,0.96,0.03c0.1,0.11,0.09,0.35-0.02,0.71c-0.12,0.39-0.3,0.69-0.56,0.91
				c-0.29,0.25-0.63,0.4-1,0.44c-0.42,0.05-0.75-0.07-0.99-0.35c-0.22,0.31-0.3,0.69-0.26,1.13c0.04-0.06,0.1-0.12,0.16-0.17
				c0.29-0.25,0.65-0.35,1.06-0.31c0.4,0.05,0.72,0.22,0.98,0.52l0.33,0.38L352.97,343.81z M352.78,341.43
				c0.17-0.14,0.28-0.31,0.34-0.5c0.05-0.16,0.05-0.26,0.01-0.31c-0.04-0.05-0.2-0.03-0.46,0.05c-0.33,0.1-0.63,0.28-0.92,0.52
				c0.14,0.2,0.3,0.32,0.48,0.37C352.42,341.63,352.61,341.58,352.78,341.43z" />
                                <path d="M357.39,345.88l-0.63,0.32c-0.37-0.43-0.77-0.72-1.21-0.87c-0.22-0.07-0.6-0.2-1.16-0.38
				c-0.43-0.15-0.85-0.47-1.27-0.95l-0.35-0.41l0.54-0.47l0.37,0.43c0.28,0.33,0.56,0.57,0.82,0.73c0.17,0.11,0.43,0.22,0.79,0.35
				c0.37,0.14,0.64,0.25,0.79,0.33c-0.08-0.17-0.18-0.45-0.3-0.86c-0.11-0.37-0.19-0.59-0.26-0.67c-0.11-0.12-0.35-0.2-0.72-0.23
				l-0.09-0.46c0.22-0.04,0.45-0.05,0.7-0.02c0.3,0.03,0.5,0.11,0.6,0.22c0.15,0.17,0.27,0.43,0.37,0.79c0.16,0.58,0.26,0.91,0.29,1
				C356.85,345.16,357.08,345.53,357.39,345.88z M352.89,346.9l0.57-0.04l0.05,0.65l-0.58,0.02L352.89,346.9z M353.13,345.87
				l0.61-0.03l0.05,0.66l0.59-0.02l0.05,0.64l-0.62,0.02l-0.04-0.63l-0.58,0.02L353.13,345.87z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M470.67,142.07c0.66,0.91,0.91,1.83,0.75,2.77c-0.16,0.94-0.69,1.73-1.6,2.39
				c-0.79,0.57-1.62,0.76-2.47,0.56c-0.76-0.18-1.38-0.59-1.85-1.25c-0.42-0.58-0.64-1.25-0.66-2.01l0.72-0.21
				c0.11,0.64,0.29,1.13,0.55,1.49c0.88,1.22,1.94,1.37,3.2,0.46c0.64-0.46,1.03-1,1.17-1.61c0.15-0.64-0.01-1.28-0.46-1.91
				c-0.41-0.57-0.99-0.96-1.74-1.18l0.24-0.98C469.44,140.87,470.16,141.36,470.67,142.07z M466.48,140.72l-0.03,1.17l-1.14,0.04
				l0.01-1.18L466.48,140.72z" />
                                <path d="M475.26,141.47l-0.37,0.26c-0.61,0.44-1.24,0.49-1.88,0.15c-0.43-0.23-0.93-0.7-1.48-1.41
				c-0.2-0.25-0.73-0.95-1.59-2.12c-0.6-0.8-1.24-1.61-1.94-2.42l0.5-0.97c1.26,1.7,2.48,3.31,3.64,4.84c0.38,0.5,0.71,0.84,0.97,1
				c0.44,0.27,0.86,0.26,1.27-0.04l0.24-0.17L475.26,141.47z" />
                                <path d="M474.74,135.27l-0.04,1.03l-1.02-0.01l-0.06,0.93l-1.08,0.01l0.07-1.05l0.99,0.01l0.06-0.9L474.74,135.27z
				 M478.49,139.13l-0.5,0.36c-0.69,0.5-1.32,0.58-1.88,0.25c0.05,0.3,0.01,0.6-0.13,0.9c-0.14,0.3-0.34,0.54-0.59,0.72l-0.5,0.36
				l-0.63-0.88l0.45-0.32c0.29-0.21,0.49-0.46,0.59-0.73c0.12-0.32,0.07-0.62-0.13-0.9l-0.27-0.37l0.49-0.59
				c0.42,0.57,0.8,0.88,1.14,0.93c0.26,0.04,0.59-0.07,0.97-0.35l0.36-0.26L478.49,139.13z" />
                                <path d="M485.64,133.99l-0.37,0.27c-0.58,0.42-1.11,0.49-1.58,0.21c0.02,0.6-0.24,1.1-0.78,1.49
				c-0.48,0.34-0.96,0.38-1.45,0.12c0,0.62-0.27,1.12-0.81,1.51c-0.5,0.36-0.99,0.41-1.47,0.14c0.06,0.57-0.17,1.04-0.68,1.41
				l-0.38,0.27l-0.63-0.88l0.22-0.16c0.66-0.47,0.75-1.03,0.29-1.68l-0.1-0.14l0.43-0.62l0.11,0.15c0.56,0.78,1.09,0.98,1.6,0.61
				c0.35-0.25,0.54-0.5,0.57-0.75c0.04-0.25-0.07-0.55-0.32-0.9l-0.1-0.14l0.42-0.62l0.11,0.15c0.56,0.78,1.09,0.98,1.61,0.61
				c0.59-0.43,0.66-0.96,0.19-1.61l-0.1-0.14l0.41-0.65l0.13,0.18c0.28,0.38,0.52,0.62,0.74,0.72c0.29,0.13,0.61,0.07,0.96-0.18
				l0.35-0.25L485.64,133.99z" />
                                <path d="M488.39,132l-0.37,0.27c-0.52,0.38-1.08,0.38-1.68,0c0.07,0.76-0.16,1.33-0.69,1.71l-0.38,0.27l-0.63-0.88
				l0.2-0.14c0.47-0.34,0.68-0.71,0.63-1.12c-0.04-0.3-0.25-0.71-0.64-1.22l-3.5-4.57l0.49-0.96l3.45,4.78
				c0.88,1.22,1.63,1.61,2.26,1.15l0.24-0.17L488.39,132z" />
                                <path d="M486.69,120.81l0.39,0.64c-0.37,0.58-0.82,1.42-1.35,2.5l-1.29,2.64l-0.31-0.57
				C485.11,123.88,485.96,122.14,486.69,120.81z M487.62,122.01l0.55,1.01c-0.5,0.75-0.99,1.59-1.48,2.5
				c-0.45,0.85-0.74,1.46-0.86,1.83c0.71,0.04,1.25,0.11,1.62,0.21c0.8,0.2,1.39,0.56,1.76,1.07c0.88,1.22,0.58,2.37-0.91,3.44
				l-0.4,0.29l-0.63-0.88l0.68-0.49c0.85-0.62,1.08-1.2,0.69-1.74c-0.34-0.46-1.41-0.76-3.22-0.9c-0.33-0.5-0.46-0.83-0.41-0.99
				C485.59,125.63,486.46,123.85,487.62,122.01z" />
                            </g>
                        </svg>

                    </svg><!-- End svg -->




                </div>
            </figure>
        </div>
        <div class="col-md-4">
            <figure class="highcharts-figure container-fluid">
				<a id="hyp_map_instagram" style="cursor: pointer;" data-setting="map_instagram" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <header class="clearfix">
                    <h4 class="text-right" style="padding: 10px; text-align: right;">پراکندگی جغرافیایی کاربران اینستاگرام</h4>
                </header>
                <div class="svg-wrapper">

                    <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 841.89 595.28" enable-background="new 0 0 841.89 595.28" xml:space="preserve">

                        <svg class="map-border">
                            <path display="inline" d="M749.69,551.97l-1,1.05
			c-1.84-0.27-3.76-0.97-5.64-1.46c-0.57-0.15-0.35-0.16-0.9,0.05c-0.8,0.3-1.38,0.78-1.95,1.25c-1.29,1.06-1.15,0.69-1.83,0.78
			c-1.41,0.18-2.92-0.09-4.43-0.36l0,0.01c-1.59-0.29-3.19-0.57-4.88-0.43c-2.27,0.07-5.31-0.26-7.84-0.45l-2.14,3.4l-2.61,0.12
			l-0.28,0.65l-0.97-0.79c-1.31-0.48-2.65-0.58-3.95-0.39c-2.05,0.29-3.26,1.06-4.9,2.09l0.67,2.01c-2.78-0.08-4.41,0.17-7.09,0.84
			l-0.35,2.31l-1.64,0.25l-0.22-0.13l1.35-4.46l-4.45-0.62l-0.92-0.42l0.14-0.73c0.98-5.28-1.08-10.48,0.49-15l0.1-0.29
			c0.03-0.24-0.35-2.91-0.23-4.12l2.63,0.67l0.48-8.59c0.17-2.37,0.35-4.57,0.54-6.67c0.41-2.87,5.63-2.79,8.4-5.03l0.41-0.33
			l0.29-1.37l3.69,0.43l0.37-1.18c0.62-2.01,0.96-5.05,3.03-5.4l0.71-0.12l0.76-1.34c2.61-0.5,5.23-0.81,7.75-2.02
			c2.34-1.12,4.89-1.88,7.5-2.19c3.78-0.44,5.86,0.05,9.27,0.9l-0.12-8.41l3.21-1.76l-2.14-2.39c-0.04-1.12-0.03-2.24,0.06-3.36
			c0.4-4.57,2.19-4.32-0.12-7.28l-1.17-1.84c-2.48,1.64-2.76,1.78-6.12,2.36l-2.81,0.58c-1.57,0.44-3.36-0.04-5.07-0.49l-0.06-0.02
			c-0.32-1.64-1.01-3.46-0.43-4.87c0.69-1.66,1.29-3.46,0.87-5.37c-0.25-1.25-0.45-2.45-0.65-3.64c-0.57-3.4-1.14-6.8-2.43-10.1
			c-1.03-2.67-0.73-5.71-0.43-8.68l0.35-3.91l-7.4,1.48l-1.92-2.86l-0.48-0.5c-1.57-1-2.74-2-4.59-2.48
			c-2.27-0.6-4.57-1.08-6.86-1.56c-2.12-0.44-4.25-0.89-6.29-1.41c-1.71-0.62-4.31-3.59-5.91-4.97l-1.25-0.93
			c-1.18-0.86-2.38-1.72-3.24-2.82c-1.88-2.32-2.43-3.78-3.57-6.66c-0.96-2.43-1.01-2.84-3.18-4.57c-1.61-1.28-1.6-1.44-1.67-2.89
			l-0.67-0.42c-1.1-0.68-0.9-2.96-0.97-4.59c-1.82-1.44-2.24-1.78-3.81-3.5l-5.3-5.75c-2.27-2.39-4.53-4.77-6.61-7.32
			c4.77-7.01,9.76-13.93,14.74-20.86c3.4-4.71,6.79-9.43,9.93-13.9c0.84-1.26,0.97-2.71,1.08-4.03c0.18-2.18,0.28-2.27,1.38-3.59
			c-1.06-2.12-1.99-4.08-2.11-6.52l-0.03-0.63l-1.64-1.47c-0.37-0.61,0.22-4.86-3.52-5.08c-4.02-0.3-8.21-0.6-12.4-0.9l-12.98-0.97
			c0.03-1.96-0.1-3.87-1.17-5.59c0.59-1.4,1-2.31,0.45-3.99c-0.72-2.17-1.14-5.94-1.1-8.27c0.05-1.93,0.89-4.07,0.99-6.36
			c0.07-1.57-1.49-5.92-2.04-7.42l-2.59-7.26c-1.79-5.03-3.57-10.06-5.52-15.43c-0.44-1.2-0.67-2.34-0.43-3.58
			c0.17-0.88,0.6-1.68,1.36-2.24c1.14-0.68,2.42-2.61,3.06-3.6c0.65-1,1.31-2.01,2.17-2.71l0.36-0.29l1.71-6.05l-1.68-0.25
			c-3.47-0.52-8.08-0.01-10.19-2.77l-0.11-0.13c-1.22-1.27,0.41-3.61,1.18-4.78c-0.9-3.77-1.96-7.68-1.54-11.47l0.18-1.61
			c0.45-0.52,0.89-1.06,1.32-1.59c1.1-1.37,2.2-2.73,3.57-3.67c0.62-0.09,1.26-0.13,1.91-0.17c2.41-0.16,3.06-0.36,5.36-0.83
			l-1.53-1.92c-1.44-1.81-3.06-3.41-4.63-5.07l3.22-0.58l0.65-2.12l1.57-0.83c0.68-0.39,0.51-0.17,0.71-0.91
			c0.35-1.29,0.78-2.6,1.22-3.91l0,0c0.27-0.81,1-2.77,1.01-3.36c0.05-3.79,0.43-6.27,1.53-9.87c-0.87-0.83-1.48-1.32-1.76-2.61
			c-0.17-0.79-0.14-1.64,0.07-2.46c1.27-1.77,2.24-3.68,3.03-5.67c0.99-2.47,1.66-4.9,2.38-7.39c-1.32-0.65-2.48-1.11-3.25-2.46
			c1.59-3.17,1.1-6.29,0.11-9.47l-2.64-0.73c0.2-1.14,1.49-2.5,1.72-4.31c0.49-3.95-2.49-8.67-2.53-9.06c0.43-2.01,0.53-4,0.63-6
			l0.13-2.18l-2.78-2.9l-11.08,0.75c-2.87,0.13-5.74,0.27-8.47,0.49c-0.56,0.03-2.24,0.13-2.52-0.15c-0.46-0.46-1.3-3.79-3.69-5.37
			l0,0c-1.47-0.97-2.31-2.65-3.15-4.33c-0.97-1.94-1.24-2.42-2.51-4.11l-0.89,0.14c-3.15,0.5-6.09-3.23-10.48-2.39
			c-0.31,0.06-0.13,0.21-0.65-0.58l-1.03-1.35l-2.93,0.12l-0.56-2.16l-2.83-2.4c-0.38-0.99-0.5-2.14-0.62-3.29l-0.46-3.2l-2.25,0.1
			c-0.82,0.1-0.85,0.11-1.2-0.09l-6.74-4.53l-0.79-0.26l-4.2-0.5l-0.57-0.12l-3.02,1.75c-0.63-0.24-1.26-0.68-1.88-1.12l-2.32-1.49
			l-0.83,1.01c-0.32,0.4-1.31,1.96-1.61,2.06c-0.75,0.04-1.61-0.17-2.45-0.38l-2.65-0.54c-2.18-0.46-2.42-2.13-2.77-3.84
			c-3.07-0.27-5.44-0.66-8.11-2.43c-0.54-0.36-0.31-0.3-0.95-0.25c-1.65,0.13-3.31-0.62-4.91-1.31l0,0
			c-3.35-1.51-7.08-0.06-9.14-2.01l-0.21-0.16c-0.63-0.42-0.35-2.02-0.32-3.05c0.02-0.65,0.09-0.42-0.3-0.94
			c-2.83-3.78-2.78-4.3-3.49-8.6l-2.82,2.7c-0.86,0.86-1.73,1.74-2.73,2.17c-0.86,0.25-3.04,0.14-4.01,0
			c-1.24-0.27-2.37-1.83-4.31-2.41l-0.55-0.17l-1.13,0.56c-3.06,1.53-2.88,0.28-3.38,0.06l-3.86-0.07c-2.07,0.22-2.9,0.8-4.49,1.91
			l1.38,3.83l-1.81,1.33c-2.75-0.75-5.5-0.44-8.18-0.29c-2.37,0.14-3.7-2.27-7-1.51c-2.86,0.66-6.17-0.1-9.22,2.74
			c-1.92,1.79-4.83,3.16-7.4,3.74c-0.65,0.15-0.45,0.02-0.85,0.53c-2.13,2.68-4.86,4.39-7.32,6.55c-3.12,2.74-1.67,7.19-3.14,9.54
			c-0.39,0.55-1.51,1.78-2.05,1.96c-0.9,0.3-3.8-1.11-6.16,0.45l-0.1,0.06v0.01c-1.97,1.23-3.99,2.5-6.18,3.08
			c-1.13-0.06-2.33-0.21-3.54-0.35l-5.15-0.41c-0.36-1.93-0.61-3.88-0.64-5.84l-0.2-0.73c-3.14-5.46-1.48-12.13-1.36-17.95
			c0.02-0.98,0.28-1.8,0.61-2.86c1-3.21,0.85-3.48,0.33-6.55c-0.46-2.73-0.92-5.48-0.5-8.12c0.31-2.41,1.95-4.44,2.35-7.27l0.97-3.54
			l0.09-0.57c-0.14-3.24-1.64-5.43-3.98-7.47l-2.17,0.17c-0.73-0.57-1.25-1.45-1.77-2.32c-0.86-1.45-1.72-2.88-3.46-3.73
			c-0.53-1.79-1.14-3.79-3.33-4.63c-3.44-1.13-5.28-1.82-8.61-3.29l1.55-2.68l0.96-0.12c2.49-0.31,4.91-0.07,7.51-0.86l0.66-0.41
			c2.02-2.13,0.62-3.58-0.72-4.97l-0.9-1.07c-0.65-0.66-0.16-1.66,0.34-2.68c0.82-1.68,1.66-3.38,0.52-5.4
			c-0.96-2.92-3.4-2.32-5.52-1.8c-0.25,0.06-0.5,0.12-0.71,0.17c-1.77-0.86-3.72-1.33-5.65-1.3c-2.11,0.03-3.99,0.61-5.81,1.86
			c-0.29-0.25-0.58-0.47-0.88-0.7l0,0c-0.38-0.28-0.76-0.57-1-0.87c-0.28-0.79-0.2-1.78-0.12-2.76c0.11-1.39,0.23-2.77-0.39-4.27
			c-0.79-2.13-0.46-5.23,0.2-7.81H343.9l-0.04,3.49c-0.41-0.33-0.83-0.66-1.26-0.97c-1.09-0.78-3.89-2.36-5.21-2.28
			c-2.94,0.17-5.99,0.4-8.63,1.97c-2.87,1.52-5.88,2.45-8.53,4.62c-1.61,1.32-1.75,3.63-1.82,5.27c-0.11,2.4-0.26,2.78-1.71,3.83
			l-0.04,5.82c-0.33,0.59-0.7,1.16-1.07,1.73c-1.24,1.9-2.48,3.81-2.52,6.35c-0.22,2.77,1.19,3.59,2.65,5.38
			c-0.06,0.63-0.16,1.35-0.43,1.84l-1.93-1.82l-0.99,1.48c-2.48,3.7-1.75,8.38-1.84,8.69l-0.35,0.49c-1.09-0.92-1.23-1.11-2.13-2.45
			c-1.04-1.53-1.23-1.71-2.46-2.97c-2.63,1.59-3.08,2.15-2.76,5.5c0.25,2.71-0.51,2.29-0.72,2.74l-0.12,2.35l-3.54,2.98l0.72,3.05
			c0.18,0.6,0.38,1.18,0.61,1.74l0.02,8.63c-2.65,1.35-3.65,1.19-6.23,1.94c-0.07-0.57-0.3-1.14-0.83-1.71l-0.58-0.68
			c-2.45-2.87-2.87-3.43-3.75-6.69l-1.38,0.28c-1.45,0.29-2.78-0.91-3.59-2.01c-1.75-2.41-3.88-3.96-5.88-5.97
			c0.77-1.23,1.58-2.44,2.59-3.33c0.82-0.16,1.65-0.28,2.49-0.4l5.29-1.03l-0.82-1.69c-1.66-3.44-5.32-5.29-5.91-8.33
			c0.93-0.84,2.15-1.39,3.37-1.93c2.29-1.02,2.54-1.24,4.51-2.55c-3.72-4.22-7.19-7.72-11.05-11.74l-4.12,0.57
			c-0.76,0.1-0.52-0.04-1,0.56c-1.77,2.23-5.67,2.66-7.99,4.85c-0.86,0.81-2.18,0.95-3.56,1.1c-2.03,0.22-2.85,0.48-4.81,0.94
			l1.46,1.51c-1.18,0.79-2.51,1.46-3.84,2.12l-2.74,1.44c-0.1,0.09-1.87,3.16-2.54,3.53c-0.9,0.49-5.17-0.22-6.69,3.04
			c-1.4,3-3.82,5.7-6.99,6.84c-1.29,0.39-2.8-0.12-4.24-0.61l-1.43-0.47c-1.25,0.78-2.99,2.18-4.08,1.92l0,0
			c-2.28-0.55-4.33-1.41-6.78-1.56c-2.43-0.17-4.18-3.16-7.97-3.09c-1.88,0.04-3.36-1.09-5.05-2.09c-0.13-2.43-0.83-4.7-2.05-6.82
			l-0.28-0.49c-0.09-0.08-4.38-1.34-5.27-2.31c-0.72-0.79-0.54-3.28-2.46-5.31c-0.81-0.85-2.08-2-2.17-2.84l-0.06-0.27
			c-0.56-1.83-0.3-3.68-2.18-5.45l-3.11-2.75l-3.64-3.44l-3.82,1.21l-0.78,3.94l-1.42,1.7c0.34,2.34,0.15,4.21-1.66,5.98
			c-5.21-1.02-4.97-1.28-10.5-1.02c1.69,3.6,2.2,4.56,2.32,8.69l2.68,1.36c-0.95,3.07-2.28,6.01-1.31,9.46l0.13,0.47l2.21,1.8
			c-0.46,1.47-0.98,2.95-0.96,4.62l0.55,1.99c0.73,2.07,0.68,2.15,0.15,3.7c-1.07,3.14-1.12,3.56-1.57,6.65l5.5-0.3
			c0.02,0.56,0.03,1.12-0.04,1.61c-0.13,0.31-1.68,1.43-2.08,1.78c-0.51,0.44-0.39,0.22-0.5,0.9c-0.7,4.13-6.04,6.49-6.29,12.04
			l-0.06,1.22l4.15,1.08c0.39,0.24,1.37,1.83,3.34,2.77c0.76,0.37,2.92,1.13,2.96,1.64l-1.95,3.19c0.79,1.1,1.42,1.88,1.46,3.32
			c0.04,1.6-0.71,2.57-1.51,3.88c1.52,1.03,2.74,1.81,4.16,3.08c0.87,0.78,1.67,1.61,2.37,2.51c0.39,0.71-0.47,2.63-0.75,3.55
			l-0.56,4.59l1.84,1.39c0.87,0.52,0.95,0.55,0.93,0.89c-0.25,5.12-0.17,4.83-2.89,8.36c2.04,0.31,3.99,0.39,5.64,1.77
			c0.71,0.59,1.27,1.35,1.59,2.24c0.02,0.45-2.09,4.33-2.09,4.88l2.76,6.67l3.39-1.16c2.15,2.68,0.81,4.13,0.79,4.46l0.61,2.12
			c1.57,5.09,0.89,5.12-1.76,9.24c3.63-0.83,4.36-1.11,8.29-1.43l-0.18,0.47c1.52,1.5,3.65,3.67,4.39,5.7
			c0.77,2.12,2.06,1.88,4.15,2.8c2.83-1.2,4.71-1.27,7.79-1.26l0.78,0.92c0.46,0.54,0.22,0.41,0.91,0.53
			c1.39,0.23,2.67-0.12,3.77-0.03c-2.25,2.32-5.74,2.85-8.83,3.37c0.1,2.68,0.09,3.04-2.04,4.96l0.26,0.91l2.24,6.31l1.59,0.59
			c0.29,0.08,0.57,0.06,0.65,0.1l-0.24,3.19l1.75,1.37c-0.99,0.79-1.25,1.92-1.55,3.02c-0.54,0.02-1.08,0.01-1.61,0
			c-0.92-0.02-0.7-0.11-1.23,0.26c-1.19,0.83-3.01,0.38-4.46,0.12l-2.12,2.47l0.59,3.42c-0.31,0.26-2.14,0.53-2.74,0.66
			c-0.77,1.54-1.05,1.76-2.69,2.97l-2.82,2.47c0.88,1.31,3.26,4.6,1.49,5.87c-0.46,0.33-0.96-0.02-1.85-0.62l-4.57-2.52l1.97,5.37
			l-0.59,0.75l-3.34,0.14l1.07,4.93l0.68,0.3c0.82,0.36,2.67,0.78,2.65,1.39c-0.04,1.44-0.15,2.86-0.64,4.19
			c-0.62,1.67-1.39,2.21-2.82,2.9l-1.79,5.25l3.12,1.15c1.34,3.82,2.27,8.12,5.95,10.59l-0.12,0.15l1.91,0.9l0.15-0.22l2.15,0.74
			c0.02,0.01-0.07,0.5-0.12,0.98c-0.13,1.35-0.07,1.43,0.15,2.66c0.82,0.25,1.39,0.37,2.12,0.87c0.24,0.17,0.48,0.36,0.7,0.57
			l-0.06,1.44l0.11,0.62c1.38,3.36,5.3,4.96,4.6,7.75c-0.15,0.62,0.27,0.77-1.71,1.33l-5.21,1.9l4.31,1.34
			c-0.22,1.77-0.64,2.87-1.17,4.56l3.32-0.05c2.5-0.07,5.11-0.14,7.05,1.22l0.28,0.16c3.63,1.52,5.87,5.41,9.62,7.93
			c1.79,1.22,3.2,2.95,4.62,4.67c1.21,1.48,2.42,2.96,3.94,4.25c2.75,2.51,5.22,1.25,8.14,0.41l0.48,0.64
			c1.97,2.58,1.93,3.01,0.97,4.98l0.68,0.75c2.73,3.01,2.45,3.25,1.27,5.64l1.35,0.67c1.66,0.82,2.68,2.63,3.65,4.37l1.11,1.98
			c0.87,1.68,0.96,2.32,2.39,4.05c0.49,0.6,1.45,1.67,1.33,2.16c-0.63,2.69-4.05,9.13-4.79,12.44c-1.01,4.57-0.89,11.38-0.84,16.39
			c3.22-0.06,6.38-0.15,9.6,0.28l-1.04,17.85l0.96,0.42c0.79,0.35,2.8,0.83,3.05,1.22l1.09,4.16c0.33,0.49,3.35,2.1,4.17,3.9
			c1.01,2.21,1.34,5.32,2.06,7.83c-0.3,0.1-0.6,0.24-0.9,0.42c-2.24-1.49-4.53-2.95-7.26-3.69c-0.7-0.19-0.43-0.22-1.08,0.12
			l-3.51,1.7l-0.55,0.43c-2.79,3.49-0.99,7.13,0.17,10.54c0.6,1.82,1.81,2.79,2.84,4.1c-1.36-0.28-2.73-0.54-4.19-0.52
			c-1.64,0.03-4.45,2.24-5.91,3.15c-1.67,0.92-2.23,2.45-2.78,3.92l-1.04,2.42c2.77,1.24,3.22,1.38,6.53,0.79
			c1.35-0.24,2.66-0.48,3.45,0.28c0.14,1.38,0.57,2.59,1,3.81c0.62,1.76,0.95,2.65,0.81,4.36c-0.4,5.11,4.54,8.38,4.54,8.38
			c0.27,1.39,0.61,2.72,0.95,4.06c0.48,1.9,0.97,3.8,1.2,5.69l0.06,0.49c0.02,0.04,1.45,1.38,2.33,3.26c0.5,1.06,3.36,3.02,3.31,5.33
			c-0.08,3.91,1.75,7.35,3.45,10.54c1.04,1.95,1.11,2.33,2.5,4.27c1.09,1.5,2.21,3.06,1.27,4.5l-0.45,0.69
			c1.21,2.64,2.41,4.85,4.53,6.95c4.37,4.33,7.9,3.47,8.73,4.1c0.3,0.23,0.59,0.46,0.85,0.7l-4.04,1.47
			c2.32,2.16,3.36,2.91,4.61,6.04l0.5,0.65c2.11,1.57,3.04,3.82,4.01,6.14l3.47-0.71l0.75,0.57c0.7,1.92,2.14,3.17,3.53,4.38
			l0.11,0.1c1.26,1.67,2.81,3.05,4.52,4.19c1.66,1.1,3.47,1.98,5.31,2.67c0.73,0.42,2.72,2.71,3.44,3.64l-0.44,0.01l-2.4,2.42
			l0.18,0.8c1.02,4.61,4.98,7.36,5.1,7.59c0.1,1.23,0.12,2.47,0.09,3.71c-0.03,1.22-0.12,2.45-0.24,3.7l-1.05,0.78l-4.14-2.77
			l-1.99,7.95l3.98,2.68l0.11,0.57l-0.96,1.48c1.71,2.81,3.98,6.02,3.56,9.24l-0.1,0.74l3.94,3.58c2.57,2.18,5.16,4.36,6.44,7.36
			c0.24,0.94-0.19,8.22-0.03,8.59l4.19,3.98c0.49,0.46,0.26,0.36,0.94,0.4c1.79,0.1,4.94,2.03,6.77-1.29l0.47-0.84
			c-1.39-1.89-2.42-3.59-2.59-6.11c-0.15-2.24,0.48-3.38,1.73-4.94l-0.7-2.35c0-0.06,0.86-1.85,0.78-5.01l0.14,0.07
			c1.77,1.2,2.82,0.07,3.8-0.98l1.34-1.06c-0.42-1.12-1.5-3.58-1.59-4.44c0.3-0.27,0.62-0.54,0.95-0.81v-0.01l0.96-0.8
			c-0.13-1.95-0.12-3.31,0.49-5.21c0.41-1.3,1.05-2.54,1.9-3.66l3.33-0.67l1-1.59c1.08-0.02,2.16-0.04,3.15,0.17
			c0.27,1.39,1.05,2.46,1.83,3.54l1.49,2.54l2.95,0.08c1.81,1.64,1.79,4.69,1.78,7.36l0,0.67c-0.15,0.48-2.68,2.35-3.35,3.39
			c-1.62,2.55,0.72,5.38,0.87,5.99l-0.41,5.04l3.05,1.35c-0.14,2.73-0.48,5.08-0.9,7.67h117.4c0.89-0.95,1.74-1.94,2.53-3.02
			c1.78-2.4,4.39-4.48,6.48-6.81c2.17-2.34,3.81-4.95,5.7-7.47l0.65,1.02c1.69-2.49,1.64-2.7,4.37-4.64c1.55-1.1,3.11-2.21,4.18-4.04
			c2-1.2,4.14-2.56,5-5.16l0.54-1.81c1.01-3.44,2.05-6.94,4.11-9.72c0.86,1.06,1.91,1.9,2.95,2.74l1.66,1.39l1.94,0.46l0.21,0.07
			c-0.86,2.94-0.79,5.86-2.52,8.28c-1.76,2.46-2.51,4.14-3.42,6.96l0.64,0.65c1.16,1.18,2.65,1.88,2.67,3.19
			c0.07,4.53,0.33,10.76,0.86,15.05l0.2,0.86c0.15,0.65,0.3,1.35,0.57,1.97h227.77v-20.36L749.69,551.97z" />
                        </svg>
                        <svg class="map-sea">
                            <path class="map-sea" id="urumia-lake" d="M194.99,87.71c1.36-2.6,4.59-0.32,6.58,0.2
			l0.08,0.06c0.04,0.02,0.1,0.06,0.12,0.1l0.06,0.04c0.39,1.64,1.83,2.25,3.23,2.76c0.12,0.3,0.41,0.93,0.53,1.26
			c0.35,0.18,0.99,0.59,1.34,0.79c0.2,2.42,0.49,4.89-0.24,7.27l-0.81,0.49c-0.51,0.1-1.5,0.26-2.01,0.36
			c0.18,2.11,0.49,4.24,0.93,6.33c1.6,0.43,2.74,1.6,3.92,2.68c1.46,0.69,3.55,0.45,4.24,2.21c0.81,0.02,1.64,0.04,2.46,0.06
			c0,1.06-0.02,2.11-0.02,3.17c-1.22,0.02-2.44,0.06-3.63,0.1c0.02,0.41,0.04,1.18,0.06,1.56c0.43,0.12,1.3,0.32,1.73,0.45
			c0.3,1.28,0.63,2.56,0.93,3.84c0.99,0.08,1.97,0.14,2.96,0.22c-0.39,1.18-0.77,2.37-1.16,3.57c-1.24,0.53-2.76,0.79-3.39,2.13
			c-1.56-0.1-3.13-0.28-4.69-0.41c0.04,1.6,0.06,3.23,0.12,4.85c-3.21-1.14-7.08-1.08-9.42-3.94c0.26-5.81-0.65-11.55-0.69-17.33
			c0-1.99-0.28-3.96-0.55-5.93c-1.3-0.22-2.62-0.47-3.94-0.71c-0.51-2.11-1.08-4.79,1.28-6.01l0.57-0.22
			c0.95-0.14,1.52-0.65,1.68-1.52l0.1-0.43c0.16-0.65,0.34-1.3,0.55-1.95c-1.6-0.14-3.19-0.3-4.77-0.51
			C193.59,91.38,193.89,89.37,194.99,87.71z" />
                            <path class="map-sea" id="persian-gulf" d="M346.52,545c-0.22-3.45,0.85-6.78,3-9.46c1.06-0.47,2.21-0.55,3.33-0.77
			c0.37-0.59,0.73-1.16,1.1-1.73c1.81-0.02,3.65-0.16,5.38,0.51c-0.04,2.29,1.97,3.8,2.88,5.74c0.85,0.02,1.68,0.04,2.54,0.08
			c3.08,2.25,2.7,6.54,2.72,9.92c-0.81,1.56-2.54,2.38-3.57,3.78c-0.93,1.73,0.45,3.29,1.08,4.83c0.12,1.5-0.18,2.98-0.3,4.47
			c0.99,0.45,1.99,0.87,3,1.3c-0.07,2.5-0.35,4.98-0.73,7.43h114.77c0.79-0.86,1.54-1.74,2.23-2.68c1.91-2.58,4.47-4.57,6.6-6.94
			c2.6-2.8,4.51-6.15,6.96-9.07c0.12,0.22,0.39,0.69,0.53,0.91c1.93-2.84,5.74-3.82,7.39-7.02c1.87-1.12,3.96-2.33,4.69-4.55
			c1.46-4.79,2.62-9.92,6.27-13.58c1.04,2.31,3.29,3.63,5.12,5.26c1.16,0.22,2.27,0.55,3.33,1.1c-1.34,3.25-0.99,7.12-3.21,10.03
			c-1.24,1.72-2.25,3.61-2.9,5.64c1.2,1.22,3.19,2.21,3.11,4.2c0.16,4.97,0.24,9.99,0.85,14.92c0.14,0.52,0.25,1.18,0.45,1.79H748.6
			v-16.58c-2.03-0.28-3.96-0.99-5.92-1.5c-1.46,0.55-2.38,2.33-4.12,2.11c-3.19,0.41-6.21-1.04-9.38-0.77
			c-2.4,0.08-4.79-0.2-7.18-0.39c-0.71,1.1-1.38,2.19-2.05,3.31c-0.83,0.02-1.64,0.06-2.46,0.1c-0.41,0.95-0.79,1.95-1.12,2.94
			c-0.59-1.02-0.75-2.34-1.66-3.13c-2.23-0.81-4.59-0.28-6.54,0.93c0.32,1,0.69,1.99,1.06,3c-2.66-0.26-5.34-0.24-7.94,0.41
			c-0.12,0.79-0.24,1.6-0.36,2.44c-1.1,0.14-2.17,0.3-3.25,0.49c-0.43-0.24-1.28-0.75-1.68-1c0.34-1.32,0.73-2.62,1.14-3.92
			c-0.91-0.12-1.83-0.24-2.72-0.39c-1.14-0.16-2.54-1.68-3.49-0.73c-1.46,0.75-0.43,2.05-0.04,3.17c-3.45,3.08-9.09,2.01-12.56-0.51
			c-5.83-1.5-12.08-0.81-17.7-3.09c-0.35-1.36-0.59-2.74-1.14-4.02c-1.79-1.67-4.67-1.22-6.21,0.53c0.59,0.59,1.06,1.28,1.4,2.03
			c-0.45,0.61-0.91,1.2-1.38,1.79c-1.6-1.06-3.19-2.13-4.87-3.04c-0.99,0.95-2.01,1.89-3.02,2.82c-0.87-0.77-1.75-1.54-2.56-2.33
			c-2.05-0.73-3.73,0.55-5.38,1.56c-1.38,0.04-2.03-1.46-2.94-2.23c-2.31-0.06-4.65,0.12-6.86,0.79c-2.11-0.95-4.04-3.35-6.56-2.37
			c-3.96,1.58-7.86,3.83-12.26,3.73c-1.87-0.87-2.78-2.92-4.34-4.18c-1.99-1.01-4.14-2.03-6.43-1.87c-2.11,0.14-4.18-0.26-6.13-1.06
			c-0.91,0.26-1.83,0.51-2.7,0.79c-3.53-1.1-6.62,1.54-9.7,2.8c-3.31-0.33-4.67-3.63-6.43-5.97c-1.81,0.18-3.51,0.77-5.22,1.36
			c-0.87-1.01-1.6-2.13-2.4-3.19c-0.97,0.28-1.97,0.57-2.94,0.85c-3-0.91-6.25-0.18-9.25-1.08c-2.98-1.72-2.4-6.09-5.54-7.71
			c-1.14-2.37-1.28-4.99-0.41-7.49c-1.81-1.85-3.88-4.06-3.11-6.88c-0.43-0.91-1.28-1.72-1.22-2.78c0.41-1.24,1.3-2.33,1.4-3.67
			c-0.49-2.66-1.83-5.03-2.52-7.63c-0.61-2.44-2.29-4.34-3.53-6.48c-1.6-2.88-4.65-4.55-7.59-5.74c-3.04-0.3-6.17-0.2-9.09-1.2
			c-2.58-1.02-5.6-0.91-8.1,0.14c-2.39,2.13-4.47,4.77-7.47,6.09c-2.9,0.3-5.95,0.22-8.67,1.42c-2.11,1.46-0.95,4.34-1.18,6.47
			c-1.4,0.45-2.78,0.97-4.2,1.36c-2.29,0.55-4.65-0.16-6.94,0.02c-1.38,0.75-2.68,1.66-4.1,2.33c-3.92,1.93-6.7,5.5-10.47,7.63
			c-0.81-0.14-1.58-0.37-2.37-0.55c-0.83,0.28-1.66,0.55-2.5,0.81c-1.26-0.33-1.89-1.5-2.64-2.44c-1.66-0.37-3.45-0.41-5.03-1.12
			c-1.68-1.46-2.5-4.83-5.22-4.26c-1.91,0.29-3.9,0.18-5.44-1.07c-1.12-0.06-2.21-0.1-3.31-0.14c-0.3,0.28-0.91,0.85-1.2,1.12
			c-2.44-0.04-4.87,0.2-7.27-0.16c-1.87-1.04-3.51-2.42-5.42-3.41c-2.35-1.22-2.48-4.2-3.84-6.19c-4.77-2.11-10.27-2.84-14.41-6.23
			c-2.11-1.77-4.53-3.11-6.6-4.93c-1.99-1.91-4.83-2.27-7.14-3.63c0.16-0.49,0.51-1.46,0.67-1.95c1.1-0.1,2.17-0.18,3.27-0.26
			c-2.44-1.77-4.06-4.32-6.27-6.31c-1.75-1.64-4.47-0.93-6.47-2.03c-2.62-1.54-4.87-3.63-7.02-5.74c-2.38-0.02-4.75-0.14-7.06-0.75
			c-2.35-0.08-4.71,0-7.06-0.33c-1.26-1.44-2.58-2.88-4.38-3.59c-2.6-0.97-3.37-3.98-5.68-5.36c-0.37-1.5-0.08-3,0.37-4.47
			c-1.68-3.21-3.98-6.05-5.36-9.44c-1.85-2.78,0.16-6.29-1.44-9.17c-0.99-2.52-4.34-2.19-5.87-4.18c-0.85-1.12-1.26-2.46-1.75-3.73
			c1.28-1.44,4.3-2.52,3.17-4.87c-1.93-1.75-4.57-1.83-7-1.68c-0.39-0.71-0.81-1.4-1.12-2.15c0.43-0.77,0.99-1.48,1.5-2.21
			c-1.08-2.11-0.79-4.44-0.37-6.68c-3.15-1.46-4.57-4.75-6.88-7.1c-3.09-3.25-5.14-7.29-7.92-10.76c-0.77-0.91-0.3-2.21-0.37-3.27
			c0.39-2.31-1.26-4.3-2.7-5.91c-2.88-1.4-5.81,0.59-8.26,1.99c-1.85,1.79-3.71,3.69-6.15,4.65c-2.88-0.3-3.19-3.88-4.36-5.95
			c-2.09-0.24-4.2-0.08-6.29,0.12c-0.16-1.26-0.32-2.52-0.49-3.78c-2.48,0.33-5.52-0.73-6.23-3.37c0.22-1.54,1.97-1.93,3.08-2.7
			c0.26,0.12,0.79,0.41,1.06,0.55c1.08-0.55,2.5-0.61,3.33-1.52c-0.14-0.96-0.39-1.89-0.73-2.8c-1.46-0.37-1.36,1.26-1.73,2.19
			c-1.66,1.3-3.35,0.29-4.81-0.77c-1.34,1.16-1.75,3-2.6,4.5c3.19,2.27,3.19,6.52,1.83,9.82c-1.2,1.04-2.74,1.56-4.16,2.19
			c-2.13-0.53-4.28-1.26-5.72-3.02c0.55,1.4,0.26,2.9-0.91,3.9c-2.78,0.91-6.05-2.11-8.36,0.3c-2.44-1.62-4.87-3.33-7.73-4.1
			c-1.18,0.61-2.38,1.18-3.57,1.73c-2.25,2.82-0.59,6.17,0.43,9.13c0.81,2.46,3.69,3.69,3.8,6.52c-2.19-0.24-4.34-1-6.56-0.96
			c-1.93,0.51-3.47,1.89-5.13,2.92c-1.62,0.85-1.93,2.8-2.62,4.3c3.13,1.4,7.19-2.01,9.44,1.24c0.12,3.07,2.25,5.68,1.85,8.83
			c-0.16,3.13,1.87,5.83,4.4,7.41c0.61,3.53,1.85,6.92,2.27,10.47c0.91,0.97,1.68,2.07,2.25,3.29c1.48,1.77,3.55,3.51,3.45,6.03
			c-0.04,4.43,2.52,8.16,4.4,11.95c1.36,2.54,4.59,5.03,2.58,8.12c1.79,3.9,4.65,7.55,8.91,8.83c1.06,0.16,2.13,0.38,3.17,0.61
			c1.04,0.81,2.21,1.54,2.5,2.94c-1.12,0.45-2.23,0.89-3.37,1.3c1.46,1.36,2.44,3.06,3.17,4.89c1.91,1.42,3.11,3.45,4.02,5.62
			c0.97-0.2,1.97-0.41,2.94-0.59c0.55,0.41,1.1,0.83,1.66,1.26c0.53,1.89,2.05,3.13,3.47,4.36c2.33,3.17,5.83,5.22,9.46,6.56
			c2.21,1.75,3.98,4.06,5.56,6.37c-0.65,0.04-1.97,0.08-2.64,0.1c-0.35,0.37-1.06,1.06-1.42,1.42c0.67,3.02,2.78,5.26,5.07,7.17
			c0.3,2.98,0.16,6.01-0.16,8.99c-0.81,0.57-1.62,1.18-2.44,1.81c-1.08-0.75-2.17-1.48-3.27-2.21c-0.43,1.6-0.81,3.23-1.2,4.85
			c1.22,0.79,2.41,1.62,3.63,2.48c0.08,0.42,0.26,1.32,0.35,1.75c-0.2,0.3-0.57,0.91-0.77,1.22c1.75,2.88,3.73,5.85,3.27,9.4
			c3.55,3.55,8.3,6.25,10.27,11.1c0.32,2.76-0.12,5.54-0.02,8.32c1.22,1.2,2.48,2.35,3.73,3.53c1.77,0.1,4.22,1.58,5.38-0.51
			c-2.37-3.23-3.43-8.14-0.75-11.49c-0.16-0.53-0.47-1.6-0.63-2.13c1.1-2.33,0.97-4.91,0.67-7.39c0.85,0.41,1.73,0.81,2.6,1.22
			c1.08,0.79,1.83-0.75,2.58-1.28c-0.55-1.46-1.42-2.9-1.28-4.51C345.24,546.04,345.89,545.53,346.52,545z M519.93,524.71
			c1.89,0.12,3.86,0.61,5.66-0.22c-0.04,0.79-0.08,1.6-0.16,2.4c-0.97,0.71-2.13,1.08-3.21,1.58c0.63,0.16,1.85,0.49,2.48,0.65
			c0.38,1.06,0.2,2.21,0.34,3.33c-2.21,0.08-4.14-1.16-6.15-1.89c0.51-0.77,1-1.54,1.5-2.31C519.77,527.1,519.6,525.92,519.93,524.71
			z M269.43,401.16c-1.06,1.68-2.7,2.88-4.12,4.24c-2.13-1.85-4.91-3.88-4.83-7.02c0.06-1.32-0.3-2.92,0.69-3.98
			c1.34-0.95,3.06-0.65,4.61-0.79c1.24,1.4,2.46,2.84,3.71,4.24C269.51,398.95,269.65,400.07,269.43,401.16z M330.52,535.65
			c0.1-2.15,0.02-4.3-0.12-6.43c1.48-0.77,3.1-1.26,4.77-1.2c0.63,3.76,0.24,7.65,0.75,11.45L330.52,535.65z" />
                            <path class="map-sea" id="khazar" d="M445.6,151.38c-0.81-8-4.38-15.47-4.51-23.59c-3.29-5.72-1.81-12.5-1.56-18.75
			c0.02-2.64,1.87-5.03,1.2-7.69c-0.53-3.31-1.28-6.66-0.73-10.03c0.32-2.58,2.01-4.73,2.35-7.29c0.22-1.3,0.59-2.56,1.04-3.8
			c-0.1-2.35-1.22-4.45-2.98-5.99c-0.53,0.04-1.56,0.12-2.07,0.16c-2.74-1.62-2.86-5.38-6.05-6.47c-0.51-1.58-0.89-3.67-2.64-4.34
			c-2.44-0.81-4.85-1.62-7.18-2.66c-0.1,1.89-0.14,3.78-0.14,5.64c-0.26,0.31-0.79,0.87-1.05,1.18c0-1.89-0.02-3.75-0.08-5.64
			c-1.22-1-1.95-2.72-0.83-4.1c1.99-2.88,2.84-6.53,5.7-8.73c-0.81,1.72-1.58,3.47-2.15,5.32c2.42-0.3,4.91-0.1,7.27-0.81
			c1.44-1.52-0.87-2.72-1.6-3.96c-2.66-2.7,2.35-5.6,0.55-8.52c-0.67-2.31-3.51-0.83-5.11-0.69c-3.21-1.71-7.14-1.97-10.21,0.14
			c0.89,2.96,3.19,5.11,4.57,7.79c-2.56-1.79-4.18-4.5-5.89-7.04c-0.75-1.14-2.13-1.6-2.88-2.72c-0.97-2.31,0.39-4.87-0.57-7.18
			c-0.77-1.81-0.72-5.05-0.12-7.07H345.4c-0.04,1.67-0.06,3.85-0.08,5.52c-2.23-2.15-4.73-4.38-7.83-5.09
			c-2.7,0.16-5.56,0.35-7.96,1.77c-2.78,1.48-5.87,2.46-8.34,4.49c-2.4,2.39-0.04,6.58-3,8.73c-0.04,1.81-0.04,3.61-0.02,5.42
			c-1.32,2.54-3.59,4.77-3.59,7.82c-0.37,2.07,1.71,3.31,2.7,4.83c-0.14,1.69-0.32,3.47-2.03,4.28c-0.41-0.38-1.22-1.14-1.62-1.52
			c-1.64,2.46-1.73,5.44-1.56,8.3c-0.95,1.34-1.91,2.66-2.88,4c-0.91,0.04-1.83,0.08-2.74,0.1c0.39-1.34,1.4-2.29,2.27-3.33
			c-1.4-1.18-2.11-2.94-3.37-4.24c-2.46,1.48,0.28,5.01-1.77,7c-0.04,0.79-0.08,1.58-0.12,2.39c-1.1,0.97-2.21,1.95-3.35,2.86
			c0.26,1.32,0.65,2.64,1.18,3.88c0.04,3.81,0.16,7.63-0.08,11.43c-0.59,7.35-0.2,14.71,0.79,22c1.64,5.2,6.45,8.28,11.24,10.23
			c3.94,1.34,8.12,1.79,12.2,2.54c1.26,0.38,2.42-0.31,3.59-0.63c2.35,1.99,5.4,2.6,8.28,3.43c0.18,0.34,0.59,1.04,0.79,1.38
			c-0.41,2.09-0.08,4.26,1.03,6.11c1.58,3.19,5.16,4.42,7.79,6.56c3.84,3.09,7.59,6.33,11.77,8.95c3.47,1.73,7.25,2.86,11.06,3.55
			c3.13,0.69,6.03,2.21,9.23,2.64c6.09,1.14,12.24-0.31,18.1-1.93c4.22-0.65,8.52-0.87,12.71-1.76c5.76-2.05,11.51-4.87,17.76-4.71
			c5.18-0.04,10.37-1.12,15.51-0.2c-2.94,0.43-5.95,0.2-8.91,0.59c-0.12,1.18,1.16,1.5,2.05,1.54c2.42,0.12,4.87,0.16,7.25-0.43
			C444.3,152.74,445.87,152.72,445.6,151.38z M419.67,83.69c-1.73-2.09-1.58-5.01-2.25-7.51c-0.06-1.4-0.73-4.3,1.56-3.86
			C418.57,76.16,420.17,79.88,419.67,83.69z" />
                        </svg>
                        <svg class="map-island">
                            <path class="map-island" d="M267.93,400.45c-0.72,1.15-1.85,1.97-2.82,2.9c-1.46-1.26-3.36-2.65-3.3-4.8c0.04-0.9-0.21-2,0.47-2.72
			c0.91-0.65,2.09-0.44,3.15-0.54c0.85,0.96,1.68,1.94,2.54,2.9C267.99,398.94,268.08,399.7,267.93,400.45z" />
                            <path class="map-island" d="M520.65,525.72c1.31,0.08,2.75-0.04,4.09-0.27c-0.09,0.43,0.08,0.62,0.03,1.17
			c-0.68,0.49-2.81,1.5-3.56,1.85c0.44,0.11,2.4,0.99,2.84,1.1c0.27,0.73,0.06,0.74,0.16,1.51c-1.53,0.05-2.58-0.63-3.98-1.14
			c0.35-0.54,0.52-1.12,0.87-1.65C520.66,527.5,520.43,526.56,520.65,525.72z" />
                            <path class="map-island" d="M331.2,534.68c0.07-1.41,0.01-2.83-0.08-4.23c0.97-0.51,2.04-0.83,3.13-0.79c0.41,2.47,0.16,5.03,0.49,7.52
			L331.2,534.68z" />
                        </svg>

                        <!-- Start Province -->
                        <a class="map-link" xlink:href="#khorasan-r">
                            <svg class="map-province khorasan-r" id="svg-object-khorasan-r">
                                <path class="map-path" id="path-khorasan-r" d="M651.38,201.47
			c2.54-3.43,3.84-7.55,4.99-11.61c-1.44-0.71-2.58-1.81-3.15-3.33c1.54-2.48,1.44-5.48,0.61-8.16c-0.97-0.26-1.93-0.51-2.84-0.87
			c-0.69-2.07,1.36-3.63,1.62-5.6c0.3-3.13-1.4-5.95-2.62-8.71c0.61-2.54,0.63-5.16,0.79-7.75c-0.63-0.63-1.24-1.28-1.83-1.91
			c-6.29,0.65-12.6,0.65-18.9,1.18c-1.26,0-2.7,0.28-3.71-0.63c-1.12-1.72-1.56-3.94-3.39-5.13c-2.86-1.89-3.53-5.46-5.5-8.08
			c-3.8,0.61-6.64-3.13-10.43-2.4c-1.44,0.51-1.93-1.01-2.66-1.89c-1.1,0.02-2.27,0.41-3.27-0.2c-0.59-0.69-0.57-1.68-0.83-2.5
			c-0.95-0.81-2.03-1.5-2.82-2.46c-0.79-1.81-0.73-3.84-1.06-5.76c-0.97,0.02-2.07,0.43-2.94-0.22c-2.35-1.4-4.57-3.04-6.82-4.59
			c-1.5-0.06-2.98-0.22-4.44-0.53c-1.04,0.61-2.05,1.24-3.13,1.77c-1.54-0.3-2.72-1.46-4.02-2.25c-0.73,0.89-1.24,2.09-2.33,2.58
			c-1.58,0.22-3.15-0.45-4.67-0.71c0.73,1.22,1.58,2.39,2.13,3.71c0.24,2.17-0.37,4.32-0.24,6.52c0.1,2.27,2.72,3.86,2.05,6.23
			c-0.97,2.25-3.8,2.15-5.78,2.86c-0.14,2.35,0.93,4.4,1.91,6.45c0.67,3.45-3.59,3.88-5.74,5.28c0,2.29,0.24,4.63-0.2,6.88
			c-0.85,1.93-2.84,3.74-5.09,3.35c-4.1-0.47-7.55-2.98-10.55-5.64c-5.28-4.28-12.48-3.78-18.85-3.69c-2.11-0.1-4.16,0.89-5.42,2.6
			c1.54,2.07,3.51,4.45,2.78,7.22c-0.16,2.19-2.07,3.63-2.68,5.62c-0.02,3.84,0.57,7.67,1.02,11.49c0.26,2.01-0.49,4.4,1.16,5.99
			c1.44,2.11,3.96,3.29,5.2,5.52c0.93,3.69,1.48,7.75,0.22,11.45c-1.2,1.89-3.49,2.68-4.99,4.28c-2.33,2.48-5.36,4.12-7.79,6.49
			c-1.95,1.99-4.89,1.97-7.47,2.44c-2.09,3.19-4.67,6.01-6.94,9.05c5.62,0.71,11.55,0.89,16.95-1.05c4.14-2.48,5.97-7.41,9.91-10.15
			c4.3-3.25,10.25-3.57,15.24-1.91c3.78,1.4,5.54,5.6,5.85,9.36c0.08,0.37,0.12-0.3,0.12,0.1c0.29,0.09,0.57,0.17,0.83,0.23
			c1.07,0.26,2.16,0.26,2.11,1.33c-0.05,1.21,1,2.26,2.21,3.46c0.94,0.94,2.12,2.1,2.2,2.96c0.28,2.72,1.32,4.69,2.17,6.27
			c0.4,0.74,0.74,1.38,0.94,1.98c0.84,2.5,5.05,3.16,7.16,3.16c0.32,0,0.6-0.02,0.84-0.04c0.42-0.05,0.84-0.08,1.24-0.08
			c3.02,0,4.89,1.35,5.92,2.45c2.5-1.03,4.38,0.08,6.97-0.67c5.48-1.4,11.1-0.47,16.64-0.24c4.02,0.41,8.08-0.04,12.1,0.51
			c4.45,0.45,8.93,2.03,12.22,5.18c4.18,0.04,7.37-2.96,10.59-5.24c3.1-2.19,4.71-5.99,7.96-8.04c1.69-0.29,3.43-0.2,5.11-0.55
			c-1.85-2.31-4.04-4.32-5.99-6.56c1.4-0.81,2.98-1.2,4.59-1.4c0.18-0.61,0.39-1.22,0.59-1.83c0.69-0.33,1.38-0.67,2.05-1.06
			c0.63-2.33,1.48-4.59,2.17-6.9c0.04-3.19,0.39-6.33,1.32-9.4C651.06,206.06,650.73,203.65,651.38,201.47z" />
                                <path class="map-point" id="point-khorasan-r" d="
        M651.38,201.47
        m -60, 10
      a 8,8 0 1,0 16,0
        a 8,8 0 1,0 -16,0
    " />

                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khorasan-j">
                            <svg class="map-province khorasan-j">

                                <path class="map-path" id="path-khorasan-j" d="M651.59,326.94c-0.79-2.86-1.22-5.82-1.18-8.79
			c0.06-2.17,0.89-4.24,0.99-6.39c-0.41-3.15-1.73-6.05-2.74-9.01c-2.44-6.84-4.85-13.68-7.33-20.52c-1.02-2.54-0.93-5.81,1.46-7.55
			c2.25-1.66,3-4.53,5.17-6.27c0.39-1.3,0.75-2.62,1.12-3.94c-3.77-0.57-8.56,0.06-11.16-3.35c-1.75-1.81-0.51-4.36,0.65-6.11
			c-0.89-3.73-1.85-7.49-1.42-11.35c-3.27,2.35-6.52,5.05-10.47,6.17c-0.71,0.28-1.36,0.24-1.97,0.03c0,0-0.01,0-0.01,0l-0.52,0
			l-0.3-0.29c-0.11-0.11-0.23-0.19-0.34-0.29c-0.77-0.49-1.51-1.12-2.25-1.54c-4.22-2.98-9.58-3.03-14.53-3.27
			c-5.5-0.1-10.98-0.49-16.48-0.75c-3.55,0-6.98,0.97-10.47,1.52c-0.32,0.06-0.53-0.09-0.68-0.37c-0.4,0.15-0.87,0.42-1.5,0.95
			l-0.85,0.7l-0.67-0.87c-0.86-1.12-2.84-3-6.4-3c-0.4,0-0.82,0.03-1.24,0.08c-0.23,0.03-0.52,0.04-0.84,0.04
			c-2.11,0-6.32-0.66-7.16-3.16c-0.2-0.59-0.54-1.23-0.94-1.97c-0.84-1.58-1.89-3.55-2.17-6.27c-0.09-0.86-1.26-2.02-2.2-2.96
			c-1.21-1.21-2.27-2.25-2.21-3.46c0.04-1.06,0.02-1.07-1.05-1.33c-0.39-0.1-0.84-0.2-1.34-0.4l-0.62-0.24l-0.05-0.66
			c-0.26-3.24-1.74-7.15-5.11-8.43c-0.21-0.05-0.4-0.09-0.55-0.14c-4.3-1.08-9.28-1.04-13.07,1.54c-4.12,2.6-6.09,7.43-9.99,10.25
			c-0.21,0.1-0.42,0.19-0.63,0.28c-0.01,0.01-0.03,0.02-0.04,0.03l-0.18,0.09c-0.04,0.01-0.08,0.02-0.11,0.03
			c-5.47,2.24-11.65,1.64-17.44,1.3c-5.34,5.2-5.38,13.54-10.39,19c-3.33-0.12-6.68-0.08-10.01-0.04c1.62,7.9,1.55,16.38,1.75,24.38
			c0.33,0.48,4.71,4.1,4.71,4.1l2.39,4.54c0,0,3.1,2.15,4.3,4.3c1.19,2.15,1.19,1.43,4.3,1.67c3.1,0.24,3.1,3.34,4.3,4.77
			c1.19,1.43,2.37,1.14,3.22,2.73c0.86,1.59,0.86,4.16,1.83,5.14c0.98,0.98,3.06,2.08,4.04,3.3c0.98,1.22,0.86,3.18,1.59,4.16
			c0.73,0.98,1.96,1.1,3.18,2.08c1.22,0.98,2.33,3.18,2.57,6c0.24,2.82,1.59,3.43,2.57,4.89c0.41,0.61,0.91,3.33,1.39,5.53
			c2.64-0.24,4.5-0.59,7.12-1.01c2.54,0.99,5.11,1.95,7.79,2.5c7.67,1.69,15.38,3.25,22.91,5.5c0.03-0.21,0.48-0.43,1.21-0.65
			c-0.04,0.29-0.08,0.59-0.13,0.88c3.61,2.25,7.77,3.65,11.08,6.45c6.23,5.24,12.5,10.41,18.79,15.59
			c6.33,6.19,12.08,12.95,18.35,19.22c4.3-2.23,8.99-4.55,11.37-9.03c0.83-3.29,1.22-6.7,1.7-10.05c3.21-0.69,6.47-1.2,9.72-1.7
			c1.14-2.11,1.93-4.46,3.43-6.37c4.73-3.08,9.58-6.01,14.39-8.97c0.04-1.95-0.06-3.92-1.36-5.48
			C651.27,329.46,652.14,328.24,651.59,326.94z" />

                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kerman">
                            <svg class="map-province kerman">
                                <path class="map-path" id="path-kerman" d="M522.24,325.05c3.31-0.14,6.6-1.14,9.9-0.81
			c8.57,3.17,17.76,4,26.47,6.7c4.97,1.28,9.56,3.65,13.88,6.37c4.89,3.92,9.6,8.04,14.49,11.97c8.77,6.72,15.67,15.43,23.24,23.36
			c1.28,1.18,2.88,1.91,4.14,3.11c1.3,1.26,1.28,3.17,1.5,4.83c1.2,12.93,1.87,25.9,2.7,38.85c1.48,2.62,2.84,5.32,3.98,8.12
			c-1.66,1.5-3.82,3.27-3.33,5.78c0.49,1.81,1.91,3.21,2.74,4.87c1.89,3.17,1.04,7,1.22,10.49c-4.75,1.32-10.33-1.64-14.55,1.79
			c-2.11,1.34,0.08,3.82,0.89,5.36c0.04,1.81,0.06,3.61,0.06,5.42c-3.51,0.04-5.66,2.98-7.06,5.85c-1.42,5.66,0.69,11.51-0.35,17.21
			c-0.47,1.91-1.77,3.61-1.54,5.68c0.16,2.88-0.49,5.7-0.65,8.57c0.57,1.32,1.44,2.52,1.97,3.88c0.28,2.01-0.16,4.1,0.41,6.07
			c1.4,1.93,3.41,3.39,4.65,5.48c0.63,1.66,0.57,3.53,0.41,5.3c-3.35,1.64-7.45,0.71-10.96-0.04c-0.35-3.41-3.31-5.5-6.15-6.84
			c-2.9-1.26-6.11-1.3-9.21-1.36c-3.13-0.06-4.87-3.09-7.55-4.24c-3.75-1.4-7.14-3.63-11.08-4.55c-1.99-1.6-3.39-3.98-5.74-5.22
			c-4.1-2.5-6.52-6.76-9.78-10.15c-0.57-2.21-0.63-4.53-1.12-6.76c2.01-2.42,5.16-3.61,6.88-6.29c-1.52-1.06-2.15-2.76-2.9-4.36
			c-2.72-1.32-5.89-1.54-8.61-2.94c-0.06-3.31,0.22-6.88-1.3-9.92c-1.34-1.1-3.15-1.48-4.83-1.71c-2.56,0.63-4.65,2.35-6.8,3.82
			c-1.44,0.91-2.74,2.48-4.61,2.31c-2.52,0.08-5.28-0.04-7.33-1.71c-1.6-1.28-3.29-2.46-4.93-3.67c-1.18-0.77-0.91-2.35-1-3.57
			c0.08-3.84-0.18-7.65-0.49-11.47c-0.08-1.64-0.91-3.11-1.81-4.42c-2.11,0.18-4.51-0.3-6.31,1.1c-2.96,1.73-5.42,4.49-8.87,5.28
			c-3.37,1.1-7.53-0.2-9.32-3.37c-0.43-4.28,1.99-8.89-0.08-12.93c-4.4-5.36-8.87-10.66-13.31-15.99c-1.91-2.52-5.36-1.97-8.14-2.23
			c0.1-4.14-0.35-8.28-0.47-12.44c-0.3-3.06-0.26-6.21-1.32-9.13c-0.65-1.79-2.9-2.21-3.67-3.84c0.65-2.94,2.94-5.14,4.02-7.9
			c-0.43-5.87-2.74-11.41-3.71-17.19c2.13-0.96,4.22-2.17,6.58-2.54c2.66,0.39,5.03,1.89,7.69,2.17c3.39-0.95,6.56-2.62,9.88-3.77
			c7.31-2.68,14.53-5.83,20.8-10.51c1.93-1.36,2.43-3.78,3.08-5.89c2.23,0.53,4.47,1.08,6.68,1.69c1.52-0.63,2.92-1.52,4.12-2.68
			c2.09-1.95,4.63-3.51,6.23-5.91C522.36,328.44,522.2,326.74,522.24,325.05z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#azarbaijan-sh">
                            <svg class="map-province azarbaijan-sh">
                                <path class="map-path" id="path-azarbaijan-sh" d="M259.2,55.38c1.62,1.4,4.08,2.62,4.14,5.03
			c0.22,4.75-0.26,9.54,0.28,14.27c0.41,2.31-1.18,4.32-1.28,6.56c0.28,1.3,0.77,2.52,1.22,3.73c-2.23,3.49-7.02,5.89-6.66,10.57
			c-0.1,2.05,2.5,2.05,3.86,2.78c2.5,1.22,5.13,1.91,7.9,2.19c1.42,0.12,0.97,1.91,1.2,2.86c0.1,2.84,1.14,5.56,1.6,8.36
			c1.85,0.67,3.94,0.97,5.46,2.33c-0.53,2.25-3.13,3.37-3.53,5.68c-0.53,3.25,2.66,5.28,3.98,7.92c2.27,1.75,2.11,4.79,3.67,7.02
			c-1.83,0.67-3.59,1.54-5.16,2.7c-2.52,0.26-4.81-0.75-7.14-1.46c-1.52-0.43-2.37,1.08-3.29,1.99c0,0.59,0,1.77-0.02,2.35
			c-2.27-1.16-4.57-2.29-6.98-3.15c-3.65,1.24-3.43,6.39-7.1,7.53c-1.79,0.45-3.23,1.52-4.28,3.04c-1.68-0.61-3.47-1.03-5.12-1.8
			c-2.92-1.85-4.71-4.87-6.78-7.53c-1.91-1.81-4.34-0.39-6.31,0.43c-1.12-1-1.99-2.84-3.74-2.68c-1.5,0.39-2.25,1.91-3.23,2.96
			c-0.47,0.14-1.42,0.43-1.91,0.57c-1.36-1.89-2.72-3.8-4.36-5.46c-1.62-1.79-4.22-1.83-6.35-2.6c-0.41-1.38-0.55-2.8-0.75-4.22
			c1.5,0.26,2.98,0.51,4.49,0.75c0.67-1.46,2.27-1.69,3.47-2.5c0.67-1.18,1.1-2.48,1.62-3.74c0.53-0.47,1.06-0.93,1.56-1.4
			c-1.48,0.28-2.96,0.63-4.47,0.89c-0.79-1.69-0.75-4.32-3-4.79l-0.02-0.69c1.18,0,2.33,0,3.51,0.02c0.04-1.32,0.06-2.64,0.1-3.96
			c-0.83-0.02-1.66-0.04-2.5-0.06c-0.67-2.09-2.98-1.89-4.73-2.29c-0.12-0.39-0.34-1.14-0.47-1.52c-1.01-0.41-2.01-0.83-3-1.24
			c-0.26-1.74-0.53-3.49-0.77-5.24c0.38-0.22,1.16-0.69,1.54-0.93l0.81-0.49c0.16-0.1,0.49-0.3,0.65-0.41
			c0.37-2.44,0.26-4.93,0.2-7.39c-0.39-0.18-1.18-0.53-1.56-0.71c-0.12-0.31-0.37-0.93-0.49-1.26c-1.36-0.53-2.6-1.3-3.65-2.31
			l-0.06-0.04c-0.02-0.04-0.08-0.08-0.12-0.1l-0.08-0.06c-1.06-1.16-2.58-1.52-4-2.01c0.85-0.81,1.79-1.58,2.46-2.58
			c-0.04-4.06-2.72-7.57-3.27-11.51c0.87-1.1,2.46-1.26,3.65-1.89c1.79-0.57,3.02-2.03,4.32-3.29c1.89,1.1,3.73,2.52,6.05,2.39
			c3.02-0.12,4.91,2.88,7.81,3.09c2.25,0.14,4.36,0.99,6.54,1.52c1.79,0.42,3.23-0.87,4.63-1.75c1.89,0.61,3.9,1.48,5.91,0.87
			c3.57-1.26,6.31-4.24,7.9-7.61c1.18-2.34,4.06-1.6,6.09-2.38c1.26-0.97,2.01-2.42,2.86-3.74C254.74,57.81,257.11,56.86,259.2,55.38
			z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#azarbaijan-gh">
                            <svg class="map-province azarbaijan-gh">
                                <path class="map-path" id="path-azarbaijan-gh" d="M181.94,38.15
			c0.71-0.22,1.4-0.45,2.11-0.67c1.99,1.95,4.06,3.78,6.15,5.6c1.34,1.2,1.26,3.17,1.75,4.77c0.18,1.62,1.62,2.58,2.6,3.73
			c1.48,1.4,1.22,3.76,2.44,5.3c1.52,1.3,3.49,1.85,5.34,2.5c1.16,2.01,1.81,4.24,1.87,6.56c-2.25,2.29-5.18,3.59-8.18,4.61
			c-0.18,0.39-0.51,1.2-0.69,1.6c1.28,3.49,3.06,6.86,3.71,10.55c-1.01,1.87-3.04,2.86-4.3,4.5c-1.3,2.05-2.21,4.47-1.54,6.88
			c1.48-0.02,2.98-0.02,4.47-0.02c-0.06,0.43-0.22,1.26-0.28,1.67l-0.1,0.43c-1.1-0.08-1.66,0.43-1.68,1.52l-0.57,0.22
			c-0.75,0.3-1.52,0.61-2.27,0.91c0.28,1.85-0.35,4.16,1.06,5.66c1.2,0.34,2.44,0.55,3.67,0.81c0.14,6.51,0.73,13.01,0.79,19.52
			c0.08,1.71,0.3,3.74,1.85,4.77c2.48,1.77,5.72,1.68,8.36,3.13c2.05,0.47,4.4,0.43,6.09,1.89c1.97,1.76,3.41,4.02,4.95,6.17
			c1.08-0.24,2.13-0.49,3.21-0.75c0.77-1.08,1.54-2.15,2.46-3.11c1.4,0.71,2.39,1.99,3.55,3.04c1.42-0.55,2.86-1.1,4.26-1.68
			c2.82,1.32,3.51,4.65,5.78,6.58c1.79,2.09,4.44,2.86,7,3.55c1.4,2.64,3.07,5.13,4.67,7.65c0.83,2.11,0.06,4.63,1.12,6.72
			c1.42,0.95,3.25,0.63,4.83,0.91c-1.04,2.74-4.51,1.68-6.6,3.11c-4.55,2.92-10.7-0.63-12.14-5.4c-5.09-1.52-10.47-0.61-15.61,0.16
			c-2.52-0.1-3.63-3.96-6.29-3.31c-1.7,0.93-3.33,2.05-4.73,3.41c-0.95,1.26-1.16,2.9-1.71,4.36c-2.05,0.02-4.22-0.22-6.17,0.59
			c-1.4,1.12-1.77,3-2.72,4.46c-1.91,0.16-3.82,0.28-5.68,0.71c1.83-2.84,0.24-6.07-0.53-8.97c0.99-2.44-0.26-4.57-1.91-6.31
			c-1.01,0.35-2.01,0.69-3.02,1.04c-0.69-1.6-1.44-3.19-2.01-4.81c0.57-1.71,1.77-3.17,2.05-4.95c-0.77-2.76-3.27-4.61-6.03-5.03
			c1.58-2.05,1.52-4.73,1.64-7.18c0.24-1.64-1.7-2.07-2.68-2.94c0.14-1.18,0.22-2.37,0.41-3.55c0.47-1.52,1.38-3.17,0.63-4.75
			c-1.58-2.11-3.63-3.82-5.8-5.28c1.34-2.17,1.32-4.73-0.18-6.82c0.63-1.02,1.54-1.95,1.68-3.19c-0.32-1.91-2.4-2.17-3.82-2.92
			c-1.34-0.55-2.17-1.81-3.23-2.74c-1.1-0.43-2.27-0.65-3.39-0.93c0.22-4.89,5.48-7.16,6.27-11.85c0.87-0.75,1.93-1.34,2.52-2.33
			c0.26-1.2,0.08-2.44,0.08-3.65c-1.73-0.1-3.47-0.04-5.2,0.1c0.28-1.97,1.02-3.82,1.62-5.68c0.37-1.77-0.63-3.37-1.02-5.01
			c-0.02-1.79,0.73-3.45,1.18-5.13c-0.87-0.73-1.75-1.46-2.62-2.15c-0.95-3.41,0.83-6.6,1.64-9.82c-0.99-0.53-1.97-1.03-2.98-1.54
			c-0.06-2.21-0.55-4.36-1.48-6.35c2.94-0.14,5.76,0.73,8.63,1.24c2.19-1.77,3.21-4.34,2.8-7.14c0.41-0.49,0.81-0.97,1.24-1.48
			C181.47,40.46,181.71,39.3,181.94,38.15z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ardebil">
                            <svg class="map-province ardebil">
                                <path class="map-path" id="path-ardebil" d="M274.1,46.89c1.14-0.14,2.25-0.3,3.39-0.47
			c3.15,3.27,6.35,6.45,9.34,9.84c-2.33,1.56-5.28,2.03-7.18,4.24c0.2,4.16,4.47,6.07,6.13,9.52c-2.07,0.49-4.2,0.63-6.27,1.08
			c-1.64,1.3-2.7,3.17-3.82,4.91c2.07,2.33,4.71,4.12,6.56,6.68c1.18,1.6,2.98,3.02,5.09,2.6c0.71,2.64,2.6,4.61,4.3,6.64
			c0.91,0.99,0.1,2.38,0.06,3.53c1.26,1.4,2.96,2.31,4.26,3.69c0.12,4.38-3.19,7.67-4.99,11.37c-1.26,4.2-0.24,8.57,0.32,12.81
			c0.91,3.55,3.31,6.43,5.48,9.3c1.64,2.11,2.15,4.79,2.58,7.35c-0.83,0.2-1.64,0.39-2.48,0.57c-2.27-1.46-4.91-0.59-7.41-0.71
			c-1.03-0.85-1.79-1.99-2.82-2.84c-1.4-1-3.25-1.4-4.3-2.84c-1.42-1.46-1.5-3.63-2.48-5.32c-2.05-2.09-3.43-4.67-5.32-6.88
			c-0.91-3.25,2.46-5.2,3.82-7.71c-1.52-1.93-3.82-2.76-6.13-3.25c-0.59-3.05-1.42-6.05-1.44-9.17c0.02-1.46-1.38-2.37-2.7-2.37
			c-3.73-0.18-6.9-2.33-10.43-3.29c0.34-1.73,0.43-3.63,1.71-4.97c1.79-2.07,4.02-3.77,5.26-6.27c-0.49-1.62-1.66-3.35-0.85-5.05
			c0.59-1.99,1.22-4.04,0.89-6.13c-0.61-4.85,0.14-9.78-0.34-14.63c-0.89-2.31-3.17-3.65-4.83-5.38c2.17-0.51,4.73-0.16,6.45-1.79
			C268.38,49.73,271.99,49.55,274.1,46.89z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#sistan">
                            <svg class="map-province sistan">
                                <path class="map-path" id="path-sistan" d="M648.93,339.58c1.54-0.89,3.06-2.38,5.01-1.99
			c8.34,0.63,16.7,1.2,25.07,1.83c2.17,0.12,1.72,2.92,2.31,4.42c0.49,0.45,0.99,0.87,1.48,1.32c0.1,2.21,0.85,4.3,1.83,6.25
			c-1.64,1.99-0.59,4.87-1.91,6.96c-8.38,11.93-17.13,23.63-25.31,35.7c3.88,4.93,8.5,9.21,12.62,13.96
			c1.03,1.24,2.23,2.29,3.49,3.29c0.08,1.85-0.18,3.98,1.64,5.11c0.12,2.74,3.45,3.27,4.3,5.64c1.22,2.96,2.21,6.11,4.38,8.54
			c1.28,1.64,3.06,2.72,4.69,3.96c2.07,1.81,3.82,4.1,6.39,5.26c4.38,1.14,8.89,1.85,13.27,3c1.56,0.39,2.82,1.44,4.16,2.29
			c0.77,1.28,1.56,2.54,2.58,3.65c2.15-0.14,4.24-0.75,6.37-1.18c-0.3,3.73-1.05,7.65,0.35,11.26c1.68,4.32,2.11,8.97,3,13.5
			c0.41,1.54-0.26,3.02-0.77,4.47c-0.95,2.17,0.24,4.47,0.47,6.68c2.21,0.55,4.57,1.4,6.88,0.75c2.68-0.73,5.64-0.69,8.04-2.27
			c0.53,0.87,1.66,1.73,1.12,2.88c-0.95,2.6-1.01,5.34-0.89,8.08c0.3,0.34,0.93,1.01,1.24,1.36c-0.79,0.43-1.56,0.87-2.33,1.3
			c0.02,2.46,0.02,4.91,0.08,7.35c-5.28-1.32-11-0.47-15.87,1.87c-2.52,1.22-5.34,1.46-8.04,2.03c-0.2,0.32-0.59,0.99-0.77,1.32
			c-3.15,0.53-3.45,3.96-4.22,6.43c-1.3-0.14-2.56-0.3-3.81-0.49c-0.12,0.55-0.33,1.66-0.45,2.21c-2.8,2.25-8.18,1.71-8.95,5.99
			c-0.41,4.51-0.75,9.03-0.95,13.56c-0.57-0.14-1.7-0.45-2.29-0.59c-0.79,1.85-0.32,3.82-0.2,5.74c-1.73,4.95,0.39,10.17-0.55,15.22
			c-0.97,0.49-1.97,0.93-2.86,1.58c-1.02,1.06-0.71,2.58-0.65,3.92c-2.48,0.28-4.99,0.14-7.45-0.26c-0.95-0.73-1.79-1.77-3.04-1.91
			c-5.46-1.02-11.04-1.14-16.46-2.38c-0.59-2.13-1.12-4.99-3.75-5.34c-2.68-1.04-6.39,0.61-6.09,3.82c-1.26-0.61-2.42-1.66-3.88-1.62
			c-1.12,0.43-1.85,1.44-2.72,2.21c-1.12-0.83-2.19-1.85-3.57-2.25c-1.79-0.24-3.23,0.99-4.71,1.79c-2.13-3.29-6.35-2.03-9.54-1.4
			c-1.87-1.04-3.65-2.98-5.99-2.46c-3.51,0.89-6.66,2.8-10.15,3.8c0.36-4.18,0.39-8.48-1.1-12.46c-0.91-1.6-2.52-2.66-3.59-4.14
			c-0.83-2.52-1.02-5.18-1.73-7.71c-0.33-2.11-2.6-3-3.59-4.75c-1.24-2.4-3.84-3.61-5.18-5.95c3.61,0.22,7.35,0.93,10.9-0.04
			c1.83-0.97,1.42-3.23,1.3-4.91c-0.16-3.53-3.21-5.8-5.46-8.12c0.06-1.62,0.24-3.23,0.16-4.83c-0.14-2.09-2.44-3.55-1.95-5.72
			c0.41-2.84,0.33-5.7,0.49-8.57c0.51-1.93,1.66-3.71,1.68-5.76c0.33-4.55-0.65-9.05-0.3-13.6c0.14-2.38,1.81-4.3,3.41-5.89
			c1.26-0.51,2.58-0.79,3.84-1.3c0.87-3.63,0.02-7.31-1.83-10.49c3.43-2.54,7.81-1.52,11.75-1.32c1.46,0.16,3.35-0.18,3.78-1.85
			c0.28-2.58,0.26-5.18-0.08-7.73c-0.43-3.47-4.14-5.62-3.9-9.28c1.16-1.14,2.39-2.17,3.45-3.39c-0.37-3.53-3.23-6.13-3.94-9.52
			c-1.1-13.38-1.4-26.83-2.98-40.17c-0.14-2.42-2.23-3.88-3.88-5.3c2.09-1.24,4.36-2.17,6.35-3.61c1.62-1.62,3.27-3.25,4.75-5.01
			c1.04-3.31,1.2-6.84,1.85-10.25c3.15-0.49,6.31-1.02,9.46-1.58c1.18-2.19,1.95-4.67,3.57-6.58
			C642.01,343.6,645.6,341.82,648.93,339.58z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#semnan">
                            <svg class="map-province semnan">
                                <path class="map-path" id="path-semnan" d="M494.58,142.69c2.11,0.43,4.28,0.65,6.33,1.36
			c0.99,2.23-0.1,5.1,1.5,7.04c1.4,0.59,2.92,0.81,4.32,1.4c1.44,1.85,1.42,5.2,4.12,5.7c2.15,0.59,4.36,1.08,6.48,1.85
			c1.46-0.59,2.82-1.4,4.02-2.46c1.81,1.14,3.08,3,2.72,5.24c0.45,2.78-2.84,4.38-2.58,7.1c0.08,4.99,1.16,9.88,1.18,14.88
			c0.65,3.29,3.96,4.99,5.99,7.37c1.2,2.88,1.22,6.15,0.97,9.22c-0.04,2.86-3.15,3.81-4.95,5.44c-2.98,2.76-6.17,5.32-9.36,7.84
			c-2.15,0.73-4.43,0.99-6.6,1.68c-2.03,4.1-5.72,7.02-7.77,11.12c-4.12,5.28-5.05,12.16-8.79,17.66c-6.45,0.2-12.89-0.65-19.32-0.34
			c-8.36,0.65-16.76,0.22-25.15,0.34c-12.14,0.2-24.23-0.97-36.37-1.12c-2.01-0.02-3.59-1.44-5.28-2.36
			c-2.78-1.7-6.01-2.37-9.07-3.35c-2.42,0.41-4.83,0.97-7.29,0.69c-2.88-1.24-5.05-3.63-7.43-5.62c0.49-3.21,2.15-6.15,2.21-9.42
			c1.6-2.42,3.21-4.97,3.27-7.98c-1.58-1.52-3.27-2.92-4.75-4.57c0.28-2.88,0.77-5.76,0.95-8.67c7.1,1.34,14.33,0.73,21.49,0.83
			c1.18-1.32,2.6-2.39,4.22-3.12c1.85-0.77,2.48-3.04,4.4-3.72c2.13-0.97,3.98-2.41,5.72-3.96c0.26-2.52,0.43-5.03,0.43-7.55
			c3.63-0.04,5.46-3.9,8.95-4.14c2.5-0.41,5.01-0.87,7.43-1.75c2.82-1.3,4.47-4.12,6.13-6.6c0.93-2.09,1.93-4.16,3.69-5.66
			c2.6,0.04,5.22-0.04,7.79,0.24c1.4-0.14,2.8-0.18,4.18-0.47c2.42-0.95,3.76-3.43,5.95-4.73c1.87-0.06,3.75,0.55,5.58,0.04
			c2.15-0.95,3.8-2.82,6.09-3.51c3.59-1.04,7.35-0.39,10.98-0.1c2.74-3.8,5.54-8.14,5.3-12.97
			C492.87,144.5,493.81,143.65,494.58,142.69z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#hormozgan">
                            <svg class="map-province hormozgan">
                                <path class="map-path" id="path-hormozgan" d="M496.53,442.22c3.51-2.31,6.94-6.09,11.57-4.89
			c1.48,5.28,1.1,10.8,1.28,16.22c-0.14,2.96,3.21,3.83,5.01,5.54c2.94,2.78,7.31,3.63,11.18,2.7c3.08-2.11,6.03-4.44,9.44-6.03
			c1.42,0.45,2.9,0.83,4.22,1.54c1.42,3.12,0.1,6.84,1.52,9.88c2.41,1.75,5.56,2.05,8.36,2.92c0.41,1.58,1.1,3.07,2.15,4.32
			c-2.35,1.64-5.18,3.17-6.43,5.87c0.28,2.27,0.63,4.53,0.97,6.78c2.01,2.31,3.98,4.67,5.91,7.06c2.7,3.39,7.47,4.69,9.34,8.83
			c4.32,0.83,8.06,3.19,12.06,4.89c2.21,1,3.76,3.08,6.03,4c2.9,0.61,5.97,0.06,8.83,0.97c2.56,0.53,4.53,2.35,6.56,3.9
			c0.39,1.66,0.63,3.39,1.22,4.99c0.79,2.13,3.23,2.96,4.26,4.93c0.85,1.73,2.42,2.88,3.63,4.3c0.89,2.74,1.08,5.64,1.87,8.4
			c0.87,1.79,2.76,2.82,3.78,4.55c1.5,3.9,1.72,8.2,0.91,12.3c-2.21-0.51-3.19-2.62-4.73-4.04c-2.25-1.28-4.71-2.5-7.37-2.38
			c-3,0.02-5.91-1.08-8.91-0.67c-2.56,0.06-5.03,0.73-7.27,1.95c-1.28,0.47-2.76,1.83-4.08,0.75c-1.52-1.38-2.31-3.37-3.8-4.77
			c-1.12-0.65-2.52-0.43-3.73-0.59c-0.41,0.34-1.22,1.05-1.62,1.4c-0.93-1.24-1.7-2.96-3.45-3.12c-0.91,0.16-1.83,0.32-2.72,0.51
			c-2.94-0.53-5.95-0.36-8.91-0.47c-0.79-1.32-1.44-2.7-2.03-4.12c-0.85-2.29-3.51-3.65-3.53-6.29c0.16-1.18,0.43-2.35,0.63-3.53
			c-0.77-1.72-2.29-2.96-3.08-4.65c-0.16-1.14-0.12-2.25-0.16-3.37c-0.29-0.33-0.85-0.97-1.14-1.32c0.63-1.91,2.17-3.96,1.1-5.99
			c-1.22-2.92-1.95-6.03-3.19-8.91c-1.93-2.62-3.27-5.74-5.93-7.73c-1.44-1.16-3.19-1.83-4.79-2.68c-3.04-0.49-6.19-0.37-9.17-1.24
			c-2.98-0.91-6.35-1.03-9.25,0.2c-2.38,2.21-4.53,4.69-7.43,6.25c-4.04-0.04-9.76-0.2-11.02,4.69c0.24,1.09,0.47,2.19,0.69,3.29
			c-3.25,1.28-6.72,1.04-10.11,0.79c-5.42,2.7-10.15,6.47-14.82,10.27c-0.45-0.22-1.34-0.67-1.81-0.87c-0.95,0.3-1.93,0.63-2.88,0.97
			c-1.4-2.52-4.1-2.86-6.66-3.25c-1.81-1.54-2.78-4.2-5.34-4.81c-1.56,0.33-3.25,0.75-4.71-0.16c-2.11-1.3-4.75-1.12-6.82,0.16
			c-2.13,0.04-4.28,0.26-6.39-0.12c-1.93-1.28-3.92-2.48-5.76-3.88c-1.06-1.46-1.4-3.29-2.35-4.79c-1.26-1.46-3.33-1.66-5.01-2.38
			c-7.43-1.46-13.54-7.11-15.48-8.32c1.23-1.23,2.09-3.85,2.68-3.43c4.77,3.43,12.31,6.11,15.8,7.53c2.88,1.93,6.45,1.89,9.76,2.43
			c3.47,0.57,7.65,1.3,10.43-1.42c2.03-1.34,1.56-3.98,1.3-6.03c2.37-2.07,5.36-3.49,8.5-3.86c4.55-0.41,9.05,0.75,13.6,0.69
			c2.37,0,4.77,0.02,7.16,0.02c3.49,0.14,6.6-1.87,10.07-2.03c2.15-0.12,4.55-0.57,5.95-2.42c1.04-2.35-0.3-5.52,1.75-7.51
			c1.77-2.19,4.79-2.27,7.25-3.19c-1.2-2.07-2.6-4.2-2.52-6.7c-1.81-1.71-4.44-1.56-6.68-2.25c-1.07-0.02-1.14-1.28-1.14-2.05
			c-0.02-4.77-0.12-9.56,0.3-14.33c0.3-1.42-1.3-3.21,0.16-4.26C493.08,443.28,495.07,443.36,496.53,442.22z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#yazd">
                            <svg class="map-province yazd">
                                <path class="map-path" id="path-yazd" d="M522.31,318.91c-0.98-1.47-2.33-2.08-2.57-4.89
			c-0.24-2.81-1.35-5.02-2.57-6c-1.22-0.98-2.45-1.1-3.18-2.08c-0.73-0.98-0.61-2.94-1.59-4.16c-0.98-1.22-3.06-2.32-4.04-3.3
			c-0.98-0.98-0.98-3.55-1.83-5.14c-0.86-1.59-2.03-1.29-3.22-2.73c-1.19-1.43-1.19-4.54-4.3-4.77c-3.1-0.24-3.1,0.48-4.3-1.67
			c-1.19-2.15-4.3-4.3-4.3-4.3l-2.39-4.54l-4.35-3.67c-1.74,3.35-5.81,5.03-9.45,5.53c-0.77,3.04-3.63,4.89-4.44,7.96
			c-1.81,0.26-3.63,0.39-5.42,0.73c-1.83,1.2-1.87,3.9-3.88,4.93c-4.02,2.11-8.93,1.34-12.97,3.45c-7.92,3.94-15.71,8.14-23.54,12.3
			c-2.07-0.35-4.14-1.14-6.27-0.89c-1.71,0.3-2.17,2.19-3.02,3.43c-1.58,0.04-3.11,0.41-4.46,1.18c0.87,2.7,2.56,5.16,2.78,8.02
			c0.08,3.53-0.89,7-0.51,10.53c0.33,2.8-0.06,5.66,0.41,8.46c1.12,1.73,3.25,2.42,4.85,3.61c0,0.57-0.02,1.68-0.02,2.23
			c-2.13,2.37-5.58,2.41-7.98,4.4c2.09,3.67,1.04,8.08,2.46,11.91c0.89,2.66,3.82,3.45,6.09,4.55c5.32,2.19,9.95,5.87,15.49,7.51
			c2.66,0.93,5.97,1.22,7.57,3.86c2.46,5.12,2.01,10.88,2.23,16.38c0.18,4.24,5.4,5.5,6.29,9.44c0.83,3.45,2.78,6.72,5.89,8.57
			c1.87,0.16,3.55-0.87,5.28-1.42c-0.26-6.64-0.35-13.31-1.34-19.87c-0.18-2.38-2.38-3.53-4.18-4.61c-0.16-3.13,1.95-5.52,3.39-8.08
			c1.32-1.85,0.12-4.08-0.2-6.05c-0.83-4.08-2.54-8.02-2.68-12.18c1.07-1.85,3.49-2.42,5.38-3.21c4.08-1.75,7.93,3.15,11.89,1.04
			c9.58-4.08,19.91-6.94,28.21-13.54c1.7-1.38,1.97-3.69,2.58-5.64c2.72-0.12,5.32,0.75,7.96,1.38c3.15-2.42,6.17-5.01,9.09-7.71
			c0-1.97,0.04-3.94,0.12-5.89c0.83-0.06,1.65-0.13,2.48-0.2C523.24,321.58,522.71,319.52,522.31,318.91z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khorasan-sh">
                            <svg class="map-province khorasan-sh">
                                <path class="map-path" id="path-khorasan-sh" d="M532.13,103.93c1.66-0.65,2.84-2.07,4.1-3.27
			c0.41,2.46,1.85,4.5,3.31,6.45c-0.04,1.46-0.49,3.37,0.99,4.34c2.62,2.5,6.49,0.91,9.56,2.29c1.79,0.77,3.61,1.6,5.64,1.44
			c2.29,1.52,4.93,2.33,7.69,2.58c0.39,1.91,1.52,3.37,3.47,3.86c0.81,1.36,1.72,2.68,2.4,4.14c0.32,2.5-0.65,5.09,0,7.57
			c0.61,1.6,1.54,3.02,2.31,4.53c-1.66,1.79-4.95,1.18-5.99,3.55c-0.65,2.74,1.24,5.14,1.99,7.63c-1.95,1.14-3.94,2.17-5.97,3.17
			c-0.41,2.25-0.06,4.53-0.12,6.8c-0.47,1.38-1.75,2.23-2.7,3.25c-2.01-0.26-4.06-0.65-5.89-1.62c-3.13-1.46-5.38-4.28-8.48-5.83
			c-3.57-1.62-7.55-2.17-11.45-2.07c-2.54,0.08-5.18-0.28-7.65,0.43c-3.06,0.89-4.3,4.44-7.39,5.32c-2.7-0.02-5.26-1.03-7.83-1.62
			c-0.79-1.6-1.44-3.25-2.33-4.79c-1.1-1.89-4.55-0.65-5.09-3.04c-0.22-2.01-0.28-4.02-0.83-5.97c-2.52-0.65-5.06-1.12-7.59-1.62
			c0.59-1.44,1.54-2.68,2.8-3.61c3.57,0.16,6.05-3,7.26-5.99c0.53-4.28,1.6-8.58,3.76-12.34c1.3-2.44,5.03-3.59,4.5-6.82
			c0.14-1.64-0.97-2.94-1.75-4.26c0.75-0.55,1.52-1.12,2.27-1.68c-0.45-1.28-0.91-2.54-1.36-3.8c1.75-1.22,3.86-1.1,5.89-0.95
			c1.66,1.62,3.59,0.34,5.3-0.47c1.64,0.49,2.72,2.07,4.42,2.43C528.94,104.19,530.56,104.21,532.13,103.93z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#isfahan">
                            <svg class="map-province isfahan">
                                <path class="map-path" id="path-isfahan" d="M378.24,238.51c1.58-0.85,2.4-2.6,3.53-3.92
			c2.46,2.17,4.91,4.53,8,5.72c2.19,0.1,4.34-0.51,6.51-0.63c4.99,0.2,9.23,3.11,13.52,5.3c9.54,0.34,19.08,0.73,28.62,1.22
			c13.38-0.02,28.84-0.07,42.21-0.09c0.4,0.94,0.37,1.3,0.86,2.54c1.4,7.27,1.48,14.66,1.73,22.02c-1.14,1.24-2.15,2.62-3.47,3.67
			c-1.87,1.06-4.06,1.32-6.15,1.79c-0.41,0.93-0.81,1.89-1.22,2.82c-1.72,1.48-2.35,3.79-3.88,5.4c-1.83,0.33-4-0.28-5.5,1.16
			c-1.4,1.54-1.6,4.22-3.9,4.87c-4.08,1.32-8.61,1.06-12.46,3.07c-7.69,4.12-15.47,8.1-23.14,12.24c-2.17-0.65-4.63-1.89-6.82-0.67
			c-1.24,0.57-1.89,1.83-2.54,2.96c-1.2,0.22-2.42,0.45-3.63,0.65c-2.07,2.37,0.12,4.97,0.91,7.39c1.4,4-0.49,8.18-0.04,12.26
			c0.34,2.92,0,5.91,0.39,8.83c0.57,2.5,3.43,2.9,4.99,4.5c0.02,1.97-2.09,2.42-3.55,2.94c-1.4,0.41-2.64,1.16-3.86,1.95
			c-0.73-1.79-1.2-3.92-2.96-4.97c-2.66-1.56-5.82-1.76-8.83-1.97c-4.47-0.2-6.82-5.52-11.39-5.34c-2.96,0.2-4.1,3.39-5.68,5.42
			c-3.27,4.47-0.51,10.11-0.43,15.02c-1.14,3.63-2.86,7.08-3.67,10.86c-1.91-1-3.51-2.44-5.07-3.9c-1.28-1.24-3.8-0.69-4.51-2.54
			c-1.83-3.92-5.97-6.96-5.74-11.65c-0.12-1.26,1.34-1.68,2.07-2.44c0.22-1.2,0.45-2.39,0.65-3.59c-0.63-0.65-1.26-1.28-1.87-1.93
			c0.24-2.21-0.93-4.57,0.22-6.62c1.22-2.42,1.93-4.99,2.7-7.55c-1.66-2.07-3.94-3.82-4.49-6.56c-0.45-2.27-2.54-3.55-4-5.15
			c-1.66-1.6-2.5-3.92-4.44-5.26c-0.39-1.87-0.3-3.86-1.1-5.62c-2.8-4.12-8.69-5.03-12.91-2.76c-1.24,1.46-2.25,4.3-4.69,3.31
			c-2.31-0.26-3.04-2.78-4.65-4.08c-2.56-1.18-5.48-0.65-8.2-0.59c-1.2-2.31-2.82-4.36-4-6.68c-0.43-0.95-1.36-1.5-2.13-2.13
			c-0.02-1.32-0.04-2.62-0.04-3.94c1.42-0.36,2.78-0.91,4.06-1.62c0.95,0,1.91,0,2.86,0c-0.32-1.06-0.55-2.13-0.73-3.21
			c1.69-1.79,3.59-3.37,5.14-5.3c0.04-1.36-0.14-2.72-0.1-4.08c1.1-1.71,2.33-3.35,3.82-4.75c2.66-1.08,5.3-2.48,8.24-2.46
			c2.48,0.18,4.36-1.6,6.62-2.29c2.33-0.59,4.83-0.26,7.12-1.05c1.75-1.04,3.35-2.36,4.79-3.8c0.63-2.21,1.16-4.48,2.11-6.6
			c-1.02-1.64-2.11-3.25-3.35-4.73c0.83-0.83,1.93-1.46,2.52-2.5c0.37-1.71,0.24-3.45,0.28-5.18c1.67-0.71,3.29-1.58,5.03-2.07
			c2.29-0.22,3.73,1.87,5.66,2.68C371.58,239.14,374.99,239.28,378.24,238.51z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#fars">
                            <svg class="map-province fars">
                                <path class="map-path" id="path-fars" d="M380.49,341.92c1.34-2.35,2.72-4.91,4.91-6.58
			c2.98-0.59,5.14,1.91,7.37,3.41c4.02,3.37,10.27,0.69,14.04,4.57c1.16,1.93,1.62,4.18,2.5,6.25c1.52,3.57,0.28,7.82,2.33,11.24
			c1.95,3.15,5.89,3.76,8.93,5.36c4.51,2.44,8.89,5.3,13.88,6.66c2.07,0.67,4.55,1.04,5.91,2.94c1.12,2.11,1.4,4.55,1.79,6.88
			c0.65,3.88-0.47,7.96,1.05,11.69c0.75,1.95,2.7,3,4.08,4.47c1.3,1.2,1.56,3.02,2.15,4.61c0.99,3.39,3.69,6.07,6.76,7.71
			c3.92-1.44,8.67-3.27,12.56-0.87c4.67,5.36,9.13,10.92,13.72,16.36c1.99,3.94-0.41,8.38,0.06,12.52c1.16,2.98,4.24,4.59,7.35,4.77
			c-0.06,0.43-0.14,1.28-0.18,1.71c1.16,2.74,0.12,5.7,0.26,8.58c0.08,3.31-0.18,6.64,0.16,9.95c1.26,2.86,5.07,2.07,7.53,3.06
			c0.1,2.21,0.93,4.26,2.09,6.13c-2.76,0.12-5.38,1.4-7.12,3.53c-1.12,1.99-0.81,4.38-0.81,6.58c-2.56,3.19-6.96,1.89-10.33,3.39
			c-3.43,1.46-7.21,0.95-10.84,1.04c-5.6,0.16-11.18-1.48-16.77-0.49c-2.74,0.87-5.66,1.93-7.61,4.14c-0.41,1.32,0.04,2.72-0.06,4.08
			c-0.91,1.81-2.78,3.37-4.87,3.37c-3.59,0.08-7.08-0.83-10.63-1.22c-2.2-0.17-3.94-2.94-5.96-2.3c-1.38,0.44-11.78-5.43-14.14-6.81
			c-2.37-1.64-5.37-4.36-7.87-5.84c-1.72-1.16-3.81-1.97-5.01-3.75c-0.93-2.13-0.97-4.57-1.97-6.68c-0.75-0.98-1.79-1.71-2.68-2.52
			c-0.12-1.93-0.08-4-1.12-5.7c-1.4-1.75-4.06-2.23-4.95-4.43c-1.06-2.66-2.64-5.03-4-7.53c-0.97-3.53-1.62-7.21-1.48-10.88
			c0.43-5.44-2.8-10.31-5.95-14.45c-2.37-2.9-4-6.39-6.8-8.93c-2.07-2.07-4.85-3.25-6.9-5.34c-2.07-2.09-2.62-5.32-5.01-7.1
			c-3.49-1.97-7.53-2.74-10.98-4.77c-1.38-0.83-1.6-2.6-2.23-3.94c3.27-1.18,4.53-4.65,7.06-6.66c2.8-0.67,6.09-0.99,7.59-3.86
			c2.31-3.67-1.93-6.82-3.06-10.11c1.6,0,3.47-0.26,4.63,1.18c3.11,3.39,7.63,4.77,11.33,7.35c2.15,1.75,6.07,0.79,6.62-2.07
			c0.32-3.19,0.55-6.64-1.4-9.38c2.13-2.68,1.99-6.07,1.91-9.3c-0.12-4.08,3.63-7.37,2.68-11.51
			C380.35,349,379.4,345.35,380.49,341.92z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khoozestan">
                            <svg class="map-province khoozestan">
                                <path class="map-path" id="path-khoozestan" d="M269.05,285.98c1.24-0.57,2.48-1.5,3.9-1
			c3.08,0.79,6.25,0.91,9.42,1.1c2.05,0.83,3.65,2.54,5.74,3.31c4.59,0.33,9.6-0.43,13.74,2.07c2.05,1.76,3.88,3.75,6.13,5.25
			c0.28,1.4,0.3,2.9,1.01,4.16c2.03,1.34,4.42,2.11,6.15,3.88c0.99,1.2,1.32,2.82,2.31,4.06c0.95,1.03,2.13,1.87,2.98,2.98
			c0.79,1.99,0.93,4.28,2.52,5.87c1.81,1.95,2.23,4.79,4.3,6.5c2.66,2.31,5.03,4.91,7.94,6.92c0.04,1.83,0.83,3.47,1.89,4.95
			c-1.16,1.54-1.95,3.47-3.67,4.53c-2.7,1.81-4.93,4.22-6.84,6.84c-1.34,2.21-4.26,2.23-6.15,3.79c0.24,1.16,0.51,2.33,0.79,3.51
			c-0.99,1.22-1.99,2.42-2.96,3.65c0.99,1.54,1.91,3.33,3.59,4.24c2.42,0.91,5.18,0.32,7.55,1.44c0.47,1.05,0.75,2.17,1.24,3.23
			c0.79,0.83,2.07,0.89,3.09,1.34c0.77,1.93,2.37,3.04,4.08,4.06c-0.65,1.38-1.87,2.35-2.88,3.47c2.13,3.35,0.97,7.33,1.08,11.02
			c-3.02-0.49-4.69-3.82-7.85-3.88c-2.05-0.1-3.59,1.48-5.03,2.74c-2.4-0.34-4.91-0.47-7.04,0.93c-3.39,1.08-5.01,4.79-8.46,5.74
			c-1.58-1.5-1.73-4.02-3.29-5.56c-1.89-0.93-4.02-0.55-5.99-0.1c0.04-0.73,0.06-1.48,0.1-2.19c-0.26-0.36-0.81-1.05-1.08-1.4
			c-2.25-0.02-4.38-0.83-5.91-2.54c2.66-0.93,5.7-0.95,8.02-2.76c-0.51-1.68-0.43-4.57-2.82-4.61c-1.28,0.3-1.64,1.81-2.37,2.72
			c-1.2-0.49-2.33-1.34-3.65-1.4c-1.7,0.89-2.25,2.88-3.11,4.46c-0.04,0.47-0.1,1.38-0.14,1.85c1.08,1.24,1.99,2.62,2.66,4.12
			c-0.28,1.4-0.47,2.84-0.83,4.22c-1.18,1.02-2.76,1.97-4.38,1.48c-2.21-0.16-3.29-2.68-5.48-2.82c-0.06,1.18-0.08,2.35-0.08,3.51
			c-0.26,0.22-0.77,0.65-1.03,0.87c-1.64-0.49-3.31-0.89-4.97-1.36c-0.79-2.7-1.01-5.56-2.15-8.12c-0.81-1.95-2.74-2.92-4.26-4.2
			c-0.43-1.34-0.57-2.74-1.06-4.04c-0.87-1.2-2.52-1.3-3.77-1.85c0.34-6.05,0.67-12.12,1.08-18.16c-3.21-0.57-6.45-0.59-9.7-0.53
			c-0.04-4.85-0.1-9.78,0.83-14.57c1.18-4.26,3.51-8.12,4.77-12.36c0.33-1.42-0.87-2.48-1.64-3.49c-1.08-1.2-1.67-2.7-2.37-4.12
			c2.03-1.32,3.33-3.23,3.41-5.68c2.01-2.39,4.18-4.83,4.59-8.06c1.54-2.96,0.24-6.25,0.45-9.38c-0.12-1.48,1.85-1.26,2.74-1.66
			c0.06-1.22,0.1-2.44,0.18-3.63C267.48,289.7,268.42,287.89,269.05,285.98z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#tehran">
                            <svg class="map-province tehran">
                                <path class="map-path" id="path-tehran" d="M414.27,189.66c-3.61-0.96-7.06-2.84-10.88-2.8
			c-3.59,0.12-5.74,3.88-9.38,3.96c-3.41,0.83-6.66-0.83-9.86-1.75c-2.94-0.93-3.29-4.83-6.01-6.11c-2.4-1.1-4.77-2.23-6.78-3.98
			c-0.68-0.63-1.45-1.09-2.26-1.48c-0.66,1.27-1.04,3.2-1.19,5.99c-0.11,1.97-0.49,2.96-1.25,3.22c-0.82,0.28-1.61-0.51-2.13-1.12
			c-0.61-0.72-0.77-0.7-1.19-0.65c-0.22,0.03-0.5,0.06-0.87,0.03c-0.16,0.01-0.25,0.2-0.46,0.71c-0.27,0.66-0.65,1.57-1.7,1.78
			c-0.37,0.07-0.66,0.33-0.88,0.77c-0.35,0.71-0.33,1.59-0.17,1.91c0.07,0.13,0.13,0.24,0.19,0.33c0.15,0.24,0.33,0.51,0.24,0.86
			c-0.1,0.41-0.51,0.71-1.33,1.17c-1.11,0.62-2.66,0.64-5.23,0.67c-1.52,0.02-3.4,0.04-5.77,0.19c-5.51,0.35-8.32,1.06-9.35,4.08
			c3.14-0.46,6.36-0.25,8.99,1.62c2.6,1.48,7.12-0.3,8.48,3.11c-1.58,2.42-3.69,4.65-3.84,7.71c2.82,0.16,5.72,0.16,8.4,1.24
			c5.87,2.27,11.63,4.91,17.66,6.78c2.5,0.81,4.3,2.82,6.35,4.36c1.24-1.56,2.07-3.37,2.76-5.26c-1.44-1.91-3.23-3.51-5.07-4.99
			c0.85-3.29,0.26-6.92,1.66-10.01c3.31-0.65,6.6,1.01,9.95,0.47c3.8-0.53,7.63-0.24,11.45,0.1c1.46-1.6,3.35-2.68,5.34-3.47
			c1.42-3.61,5.85-3.71,8.08-6.56C417.74,190.88,415.81,190.1,414.27,189.66z" />
                                <path class="map-point" id="point-tehran" d="
        M414.27,189.66
        m -50, 0
        a 8,8 0 1,0 16,0
        a 8,8 0 1,0 -16,0
    ">
                                </path>
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ghom">
                            <svg class="map-province ghom">
                                <path class="map-path" id="path-ghom" d="M351.06,210.68c3.23,0.57,6.66,0.3,9.66,1.81
			c3.65,1.73,7.55,2.84,11.2,4.55c2.94,1.38,6.47,1.71,8.95,3.98c0.85,0.75,1.68,1.52,2.54,2.29c-0.04,3.09-1.6,5.85-2.19,8.83
			c-0.63,2.7-2.58,5.83-5.7,5.74c-2.42,0.18-4.85,0.08-7.29,0.06c-1.44-1.24-2.96-2.58-4.93-2.84c-2.35,0.18-4.36,1.58-6.49,2.46
			c-0.26,1.93-0.41,3.88-0.55,5.8c-0.97,0.87-1.93,1.75-2.86,2.64c-2.29-1.12-4.34-2.7-6.68-3.69c-2.11,0.16-4.16,0.95-6.29,0.61
			c-0.75-1.54-1.85-2.8-3.43-3.55c-0.51-2.09-0.16-4.65-1.91-6.21c-2.05-0.41-4.16-0.18-6.23-0.16c-1.91-3.49,1.66-6.54,3-9.56
			c2.44,0.67,4.79,1.52,7.08,2.54c1.54-1.26,2.98-2.64,4.36-4.06c2.44,0.1,4.85-0.24,7.12-1.12
			C351.51,217.52,351,214.05,351.06,210.68z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kermanshah">
                            <svg class="map-province kermanshah">
                                <path class="map-path" id="path-kermanshah" d="M216.3,206.99c0.55-1.14,0.53-2.8,1.66-3.45
			c3.13-0.18,2.64,3.79,4.71,5.22c3.59,2.56,5.16,6.84,7.94,10.11c2.54,2.15,6.29,2.29,9.19,0.77c1.87-0.45,1.97-2.58,2.52-4.08
			c1.54-0.49,3.25-0.73,4.61-1.66c0.81-0.85,1.42-1.89,2.23-2.74c5.03-2.56,11.43-0.49,14.33,4.28c-0.69,1.85-0.39,3.75,0.34,5.52
			c0.89,1.97-0.67,3.75-1.22,5.56c1.32,1.62,3.53,2.13,5.32,3.08c0.04,1.04,0.08,2.05,0.12,3.09c-1.62,2.01-3.37,3.96-5.68,5.18
			c-1.46-1.85-3-3.94-5.56-4.1c-0.57,1.6-0.49,3.31-0.41,4.97c-1.58,1.42-4.43-0.1-5.85,1.79c-2.07,1.64-0.16,4.51-1.08,6.6
			c-0.81,0.53-1.68,0.97-2.54,1.44c-0.63,1.46-1.04,3.07-1.97,4.38c-2.19,0.67-4.44-0.61-6.68-0.26c-1.06,0.41-1.95,1.12-2.86,1.79
			c-2.82,0.08-5.48-1.01-7.67-2.72c-2.7-2.17-5.7-3.94-8.69-5.7c-1.48-1.08-3.23,0-4.81,0.08c-1.68-1.1-2.96-2.7-4.69-3.75
			c-1.08,0.63-2.13,1.26-3.21,1.87c-1.24,0.06-2.88-0.71-3.75,0.55c-1.1,0.83,0.08,2.19,0.2,3.23c-0.33,0.53-0.67,1.06-1,1.6
			c0.43,1.34,0.97,2.68,1.1,4.1c-0.51,1.1-1.38,1.97-2.09,2.96c-3.88-2.19-4.69-6.98-6.13-10.82c-0.79-0.3-1.56-0.59-2.33-0.87
			c0.43-1.08,0.75-2.19,1.08-3.31c3.06-1.48,3.65-5.01,3.71-8.08c0.1-1.95-2.21-2.25-3.55-2.84c-0.14-0.59-0.41-1.81-0.53-2.42
			c0.57-0.02,1.71-0.08,2.27-0.1c0.51-0.65,1.01-1.3,1.52-1.95c-0.28-0.83-0.59-1.64-0.89-2.48c1.38,0.73,2.96,2.48,4.53,1.2
			c2.42-1.73,0.87-4.95-0.43-6.9c1.48-1.48,3.61-2.35,4.59-4.3c1.18-0.24,2.68-0.22,3.23-1.56c0.06-1.16-0.28-2.27-0.49-3.39
			c0.28-0.32,0.85-0.95,1.12-1.28c1.62,0.28,3.29,0.47,4.71-0.53C214.25,207.07,215.28,207.11,216.3,206.99z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kordestan">
                            <svg class="map-province kordestan">
                                <path class="map-path" id="path-kordestan" d="M212.3,162.16c1.26-1.16,2.66-2.15,4.14-3
			c2.23,0.91,3.59,4.3,6.47,3.45c4.47-0.91,9.03-0.45,13.54-0.55c2.03,4.48,6.98,8.24,12.06,6.55c3.17-1.75,7.51-1.26,9.5-4.79
			c2.68-0.06,5.72-0.16,7.77,1.91c2.52,1.93,1.85,5.42,2.25,8.18c-0.73,0.95-1.44,1.91-2.15,2.88c0.77,0.87,1.54,1.77,2.31,2.64
			c-0.95,0.93-2.9,1.68-2.27,3.37c0.93,1.85,2.62,3.17,3.82,4.85c0.57,0.39,1.16,0.77,1.75,1.16c-3,0.83-8.02,0.49-8.14,4.77
			c1.12,3.84,3.35,7.23,5.91,10.21c2.27,2.44,3.15,6.35,1.01,9.15c-2.31-1.34-4.79-0.06-7.21-0.12c-2.03-1.34-3.82-3.19-6.33-3.59
			c-2.4-0.79-4.89-0.12-7.23,0.55c-1.75,0.37-2.23,2.35-3.39,3.47c-1.4,0.65-2.92,0.87-4.36,1.42c-0.85,0.97-0.91,2.39-1.36,3.57
			c-2.68,1.3-5.99,2.21-8.59,0.22c-3-2.62-4.02-6.86-7.21-9.32c-2.01-1.4-2.9-3.69-3.9-5.82c-1.46-0.79-2.8-1.77-4.1-2.8
			c0.1-0.89,0.14-1.81,0.16-2.7c-0.16-1.28-1.66-1.24-2.58-1.64c-0.75-1.85-1.42-3.72-1.97-5.6c1.22-1.1,1.95-2.52,1.89-4.18
			c3.63-0.61,7.45-1.71,9.5-5.05c-1.26-1.87-3.88-0.73-5.74-1.04c-0.3-0.37-0.93-1.1-1.24-1.46c-2.86-0.02-5.8-0.02-8.48,1.12
			c-0.97-0.43-2.42-0.45-2.74-1.66c-0.89-2.15-2.39-3.94-4.04-5.56c0.69-1.75,1.16-3.63,2.42-5.07c2.01-0.41,4.14,0,6.11-0.65
			C211.3,165.77,210.82,163.37,212.3,162.16z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#zanjan">
                            <svg class="map-province zanjan">
                                <path class="map-path" id="path-zanjan" d="M273.82,138.57c2.96,0.41,5.05-2.27,7.86-2.68
			c2.27,0.67,4.38,1.91,5.89,3.75c1.54,2.23,4.49,1.24,6.72,1.1c3.21,1.48,6.88,0.2,10.05,1.97c0.49,2.25,0.41,4.89,2.11,6.68
			c1.14,1.36,2.94,3.43,1.6,5.2c-3.47,0.16-6.76,1.58-9.19,4.06c-0.63,0.97-0.79,2.21-0.71,3.37c0.77,1.12,1.73,2.09,2.62,3.11
			c1.75,2.31,5.11,1.24,7.45,2.56c2.35,0.61,3.86,2.54,4.65,4.73c0.79,1.24-0.49,2.38-1.14,3.33c-1.42,1.71-2.44,3.71-3.9,5.4
			c-1.3,1.14-3.17,0.81-4.75,1.12c-1.6,0.14-2.94,1.14-4.34,1.85c-1.68-1.32-3.27-2.94-5.5-3.17c-0.04,1.12-0.12,2.23-0.24,3.35
			c-1.08,1.32-3.37,2.09-3.17,4.12c0.26,1.56,1.68,2.58,2.56,3.81c-0.91,1.14-1.87,2.25-2.86,3.31c-3.94-0.73-7.35-2.88-11.06-4.2
			c-4.79-1.66-8.85-4.95-11.75-9.07c0.91-0.95,2.35-1.64,2.56-3.08c-0.59-0.81-1.24-1.58-1.89-2.36c2.44-2.6,1.83-6.29,1.02-9.42
			c-1.18-2.27-3.51-4.06-6.03-4.55c-3.35-0.04-6.7-0.08-9.97-0.79c-0.34-2.03-0.49-4.08-0.49-6.13c-1.62-2.15-3.17-4.38-4.38-6.8
			c0.73-0.85,1.38-1.79,2.23-2.5c1.52-0.85,3.53-1.01,4.57-2.56c1.4-1.62,1.89-4.02,3.65-5.24c2.94-0.45,5.22,2.03,7.89,2.78
			c0.69-1.5,0.43-3.96,2.25-4.61C270.1,137.13,271.77,138.63,273.82,138.57z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#gilan">
                            <svg class="map-province gilan">
                                <path class="map-path" id="path-gilan" d="M292.43,94.63c2.33-1.06,5.09-1.1,7.45-2.29
			c-0.39,3.83-0.51,7.73-0.18,11.59c0.37,4.06,0.06,8.24,1.3,12.18c1.14,2.52,2.5,5.16,4.95,6.64c6.56,4.73,14.94,6.6,22.91,6.19
			c2.48,1.36,5.14,2.25,7.85,2.98c-0.35,3.7,0.83,7.61,3.78,9.99c2.29,1.72,4.81,3.13,7.08,4.87c-0.57,1.22-1.06,2.46-1.81,3.57
			c-1.3,1.1-3.47,0.61-4.63,1.85c-0.59,1.69-0.41,3.51-0.47,5.26c-0.37,0.57-0.73,1.16-1.1,1.74c-2.56-0.67-5.26-1.52-7.85-0.61
			c-2.78,0.51-4.95,2.84-7.83,2.8c-2.62,0.1-4.53-2.27-7.16-2.19c-2.6-0.18-5.95-1.2-6.56-4.12c-0.53-2.15-0.95-4.44-2.64-6.03
			c-1.93-1.83-1.56-4.65-2.4-6.98c-1.34-0.87-2.98-1.05-4.42-1.7c-0.93-2.72-0.85-5.89-2.78-8.18c-2.64-3.19-5.52-6.64-5.83-10.92
			c-0.47-3.59-1.28-7.39,0.1-10.86c1.95-3.53,5.03-6.9,4.79-11.2C296.41,97,293.81,96.27,292.43,94.63z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#lorestan">
                            <svg class="map-province lorestan">
                                <path class="map-path" id="path-lorestan" d="M257.19,234.74c1.85,0.59,2.94,2.19,4.22,3.53
			c1.79,1.95,4.87,1.91,6.56,3.96c2.05,2.19,4.45,4.1,7.1,5.44c3.21,0.73,6.41-0.45,8.93-2.4c4.75-1.1,6.39,5.24,10.82,5.48
			c-1.38,2.23-0.85,4.83-0.53,7.27c0.75,1.14,1.46,2.31,2.13,3.51c0.71,0.04,1.44,0.08,2.15,0.14c0.73,0.65,1.28,1.85,2.42,1.73
			c2.42,0.47,4.16-1.5,6.03-2.68c1.87,1.73,4.06,0.99,6.13,0.16c0.16,1.5,0.2,3.02,0.51,4.53c0.71,0.59,1.52,1.04,2.31,1.5
			c0.77,1.64,0.81,4.1,2.82,4.77c2.11,0.77,4.18,1.62,6.03,2.9c-1.91,2.11-3.75,4.3-5.72,6.37c0.18,0.47,0.55,1.4,0.73,1.87
			c-2.29,0.43-4.42,1.34-6.64,2.05c-0.04,1.54,0.06,3.09-0.2,4.63c-0.87,1.58-1.99,3.06-2.27,4.89c-0.97,0.41-2.03,1.26-3.1,0.59
			c-2.48-1.22-3.88-3.84-6.29-5.11c-3.53-1.36-7.37-1.75-11.12-1.42c-2.44,0.3-4.22-1.68-6.19-2.74c-2.11-1.6-4.89-0.53-7.29-1.16
			c-2.7-0.37-6.01-1.81-8.22,0.49c-1.26,2.01-2.07,4.28-3.51,6.19c-1.06-2.23-1.66-4.87-3.78-6.41c-2.09-1.87-5.05-2.33-7.1-4.26
			c-5.5-4.71-11.71-8.55-18.12-11.87c-0.41-1.24-0.83-2.48-1.26-3.69c-1.46-0.65-3.88-1.18-3.17-3.33c1.58-0.06,3.17,0.71,4.71,0.45
			c0.69-1.07,1.08-2.34,1.89-3.33c3.39-0.81,6.92-0.95,10.37-1.46c0.99-1.2,2.25-2.23,2.96-3.63c0.12-1.1,0.06-2.21,0.04-3.31
			c-2.01-2.33-0.34-5.46-0.91-8.2c1.28-2.94,5.26-0.67,7.14-3C257.54,237.68,257.34,236.22,257.19,234.74z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#markazi">
                            <svg class="map-province markazi">
                                <path class="map-path" id="path-markazi" d="M317.64,198.97c1.64,0.39,3.31,0.1,4.89-0.37
			c3.75,2.58,8.83,2.23,12.89,0.65c2.27-0.91,4.75-0.77,7.14-0.69c2.11,0.04,3.63,1.87,5.66,2.23c1.97,0.35,3.98,0.38,5.95,0.69
			c-2.05,3.49-4.47,7.16-4.22,11.39c-0.1,2.35,0.55,4.87-0.41,7.08c-1.91,1.12-4.18,0.63-6.27,0.97c-1.75,0.92-2.94,2.58-4.32,3.92
			c-2.37-0.85-4.67-2.23-7.23-2.33c-2.58,2.25-3.73,5.66-5.07,8.73c0.57,0.89,1.12,1.79,1.68,2.7c2.15,0.18,4.3,0.12,6.45,0.04
			c0.75,2.13,1.04,4.36,1.24,6.6c0.81,0.2,1.62,0.41,2.44,0.61c0.16,0.79,0.32,1.58,0.51,2.38c2.13,0.63,4.34,0.55,6.45-0.02
			c1.81-0.55,3.17,1.12,4.67,1.81c2.35,1.58,5.87,2.33,6.7,5.46c-0.61,1.89-1.22,3.78-1.7,5.7c-1.14,1.42-2.7,2.48-4.16,3.51
			c-3.23,1-6.9,0.26-9.82,2.29c-2.29,1.58-5.24,0.59-7.69,1.72c-1.68,0.67-3.45,1.14-5.05,1.99c-1.85,1.95-3.23,4.28-4.83,6.41
			c-1.6-0.79-3.31-1.36-4.93-2.11c-1.1-2.01-1.36-4.67-3.94-5.44c-0.04-1.99-0.2-4.12-1.97-5.36c-1.73,1.36-3.77,1.54-5.56,0.12
			c-1.54,0.59-2.88,1.56-4.14,2.62c-0.83,0.02-1.66,0.02-2.48,0.04c-0.3-0.43-0.87-1.24-1.18-1.64c-0.71-0.1-1.44-0.18-2.15-0.24
			c-0.61-0.91-1.22-1.81-1.85-2.7c-0.14-1.58-0.47-3.15-0.39-4.75c0.67-2.48,4.06-3.06,4.49-5.7c0.41-2.58-0.18-5.13-0.61-7.67
			c-0.49-0.1-1.46-0.33-1.95-0.45c-0.53-1.52-0.99-3.09-1.38-4.65c1.64-2.19,2.9-4.65,4.85-6.58c1.73-1.5,0.22-3.86,0.14-5.7
			c2.13-2.8,4.61-5.34,8-6.51c0.39-1.52-1.06-2.35-1.93-3.35c2.19,0.53,4.22-0.45,4.91-2.64c0.95-1.46-1.02-2.31-1.91-3.06
			c0.1-1.38,0.22-2.74,0.34-4.1c2.54-0.16,5.38,0.18,7.63-1.24C317.64,200.56,317.68,199.76,317.64,198.97z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#hamedan">
                            <svg class="map-province hamedan">
                                <path class="map-path" id="path-hamedan" d="M264.83,192.17c2.21-1.62,5.22-1.5,7.73-2.52
			c2.76,2.13,6.25,2.74,9.34,4.26c2.25,1.14,4.65,1.97,7.06,2.72c1.83-0.79,3.19-2.23,4.36-3.79c1.56,0.83,3.17,1.56,4.79,2.27
			c2.25,0.71,2.39,3.59,4.28,4.77c1.85,1.24,4.16,1.28,6.23,1.89c0.16,1.71-0.22,3.41-0.1,5.12c0.65,0.79,1.46,1.42,2.21,2.13
			c-0.61,0.77-1.22,1.58-1.83,2.37c-1.26-0.22-2.56-0.26-3.53,0.71c0.63,1.02,1.36,1.97,2.03,2.96c-3.41,1.32-6.17,3.98-7.83,7.21
			c-0.14,1.44,0.45,2.82,0.59,4.26c-2.25,2.31-4.16,4.95-5.54,7.91c0.06,2.42,0.71,5.52,3.41,6.33c0.39,2.96,1.26,6.48-1.4,8.67
			c-1.12-0.02-2.25-0.02-3.37-0.04c-2.46-1.83-4.26-4.87-7.53-5.32c-2.21-0.51-3.86,1.4-5.7,2.27c-1.73,0.51-3.55,0.29-5.32,0.18
			c-3.71-2.68-6.5-6.76-11.1-8.02c2.17-1.46,3.94-3.41,5.5-5.5c0-1.28,0-2.58,0.02-3.88c-1.77-0.99-3.57-1.93-5.38-2.8
			c0.77-1.52,1.93-3.17,1.28-4.95c-0.75-2.4-0.93-4.87-0.73-7.37c1.71-0.55,3.49-0.89,5.26-0.28c2.17,0.59,2.72-2.15,3.13-3.69
			C273.13,202.93,264.28,199.36,264.83,192.17z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#mazandaran">
                            <svg class="map-province mazandaran">
                                <path class="map-path" id="path-mazandaran" d="M348.34,147.58c2.52,1.99,5.16,3.84,7.71,5.78
			c3.51,2.72,7.92,3.84,12.16,4.85c3.61,0.49,6.84,2.35,10.43,2.86c6.76,1,13.56-0.41,20.11-2.03c3.94-0.85,8.06-0.77,11.95-1.87
			c4.02-1.68,8.18-3.03,12.4-4.14c3.15-0.53,6.35-0.63,9.54-0.67c1.64,2.64,4.81,2.39,7.49,2.19c0.16,1.42-0.14,3.04,0.65,4.32
			c1.64,1.28,3.84,1.42,5.64,2.38c0.97,1.99,2.05,3.94,4.47,4.3c-2.58,0.57-5.78,0.61-7.16,3.31c-1.56,3.39-3.39,6.86-6.41,9.19
			c-3.02,1.52-6.45,1.91-9.74,2.52c-1.42,0.26-2.37,1.48-3.51,2.27c-1.28,1.04-2.96,1.2-4.42,1.81c-0.28,2.17-0.3,4.36-0.53,6.54
			c-1.73-1.2-3.61-2.15-5.66-2.68c-3.51-1.01-6.94-2.8-10.68-2.47c-3.33,0.3-5.3,3.82-8.67,3.98c-3.9,0.81-7.53-1.22-11.18-2.27
			c-1.42-2.35-2.82-5.07-5.58-6.05c-3.21-1.28-5.78-3.61-8.59-5.54c-2.01-0.26-3.77-1.28-5.52-2.25c-3.21,1.06-6.13-0.55-8.83-2.09
			c0.57-3.69-2.8-5.87-5.5-7.57c-2.7-1.48-5.52-2.78-8.22-4.28c0.47-0.97,0.93-1.93,1.38-2.9c-0.1-1.38-0.51-2.82-0.06-4.18
			c1.36-0.55,2.82-0.85,4.16-1.48C347.11,150.26,347.65,148.88,348.34,147.58z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ilam">
                            <svg class="map-province ilam">
                                <path class="map-path" id="path-ilam" d="M202.8,245.57c2.46-0.08,4.89-0.53,7.02-1.85
			c1.28,1.22,2.46,2.58,4.04,3.43c1.36,0.04,2.66-0.47,4.02-0.53c3.76,1.79,7.1,4.28,10.41,6.78c2.86,1.89,7.31,3.43,9.86,0.24
			c1.89,0.06,3.73,0.3,5.56,0.81c3.23-0.51,2.94-4.36,5.18-6.09c0.41,0.51,1.24,1.5,1.64,2.01c0.57,2.6-0.85,4.97-3.23,6.01
			c-3,0.71-6.13,0.57-9.15,1.18c-1.52,0.49-1.81,2.25-2.33,3.55c-1.81-0.45-4.79-1.36-5.48,1.14c-0.02,2.17,2.15,2.92,3.75,3.78
			c0.59,1.28,0.49,3.19,1.97,3.82c6.29,3.29,12.34,7.08,17.72,11.73c2.6,2.27,6.76,2.62,8.42,5.95c0.87,2.17,2.31,4.06,3.21,6.21
			c-0.97,0.53-2.21,0.79-2.88,1.77c-0.73,1.77-0.1,3.69,0,5.52c0.49,2.46-0.83,4.73-1.44,7.06c-0.69,3.25-4.85,4.77-4.24,8.42
			c-0.85,0.73-1.68,1.44-2.54,2.17c-1.2-2.11-2.33-4.45-4.63-5.58c1.2-2.42-0.67-4.3-2.17-5.97c1.36-2.8-1.22-4.89-2.6-7.06
			c-2.52,0.45-5.54,2.4-7.75,0.2c-3.23-2.72-5.22-6.66-8.75-9.07c-3.59-2.38-5.83-6.37-9.88-8.08c-2.7-1.89-6.07-1.5-9.17-1.46
			c0.43-1.36,0.63-2.74,0.73-4.14c-0.32-0.1-0.99-0.26-1.32-0.37c1.44-0.55,3.8-0.65,3.78-2.72c0.97-3.88-3.37-5.54-4.67-8.69
			c0.02-0.51,0.06-1.56,0.08-2.09c-0.83-0.89-1.83-1.64-3.02-2.01c-0.22-1.26,0.73-3.35-0.87-3.9c-0.55-0.18-1.64-0.57-2.19-0.75
			c0.85-1.08,1.71-2.15,2.52-3.23c-0.87-2.07-1.62-4.28-0.1-6.25C203.9,247.03,203.17,246.06,202.8,245.57z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ghazvin">
                            <svg class="map-province ghazvin">
                                <path class="map-path" id="path-ghazvin" d="M300.81,158.32c2.25-1.87,5.16-2.41,8-2.76
			c1.01,1.36,1.95,2.94,3.57,3.65c1.83,0.93,3.94,0.85,5.89,1.34c1.83,0.77,3.53,2.05,5.62,1.91c3.17,0.26,5.46-2.52,8.48-2.94
			c3.59-0.85,7.04,1,10.15,2.54c3.82,2.01,8.24,3.57,10.8,7.27c0.79,1.14-0.02,2.8-1.52,2.37c-3.69-0.41-7.49-0.45-11.1-1.5
			c-0.39,1.1-1.26,2.19-0.24,3.27c1.28,1.72,3.77,1.85,5.34,3.23c0.14,1.07,0,2.15-0.04,3.23c-2.01,1.62-4.26,2.82-6.56,3.98
			c-0.83,1.26-0.81,2.88-1.2,4.32c-1.14,0.77-2.25,1.58-3.39,2.38c0,0.93-0.02,1.85-0.02,2.78c-1.48,1.64-1.99,3.75-1.99,5.93
			c-2.98-0.08-6.29,0.59-8.87-1.32c-1.24-1.16-2.74-0.16-4.08,0.2c-1.08-0.16-2.13-0.3-3.21-0.45c0.08,1.02,0.14,2.03,0.24,3.04
			c-2.23,0.37-4.47,0.67-6.72,0.63c-1.83-1.34-4.22-1.18-6.23-2.03c-2.23-1.08-2.56-4.14-4.83-5.14c-2.52-1.16-5.36-2.07-7.1-4.36
			c-0.49-0.67-1.32-1.56-0.61-2.39c1.46-1.6,4.18-2.88,3.06-5.56c1.46,1.03,2.68,2.76,4.53,3.09c2.31-0.93,4.59-1.99,7.12-2.01
			c1.99,0.02,3.27-1.64,4.18-3.19c1.32-2.35,3.57-4.14,4.3-6.82c-0.97-1.64-1.75-3.43-2.98-4.89c-2.29-1.42-4.95-2.25-7.63-2.54
			c-1.91-0.04-2.8-2.01-3.98-3.23C298.42,161.2,299.47,159.05,300.81,158.32z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#alborz">
                            <svg class="map-province alborz">
                                <path class="map-path" id="path-alborz" d="M336.92,197.61c1.17-4.31,5.09-4.93,10.38-5.27
			c2.39-0.15,4.29-0.17,5.82-0.19c2.42-0.03,3.87-0.05,4.76-0.54c0.5-0.28,0.71-0.43,0.81-0.51c-0.02-0.03-0.04-0.07-0.06-0.1
			c-0.08-0.12-0.16-0.25-0.25-0.42c-0.34-0.68-0.27-1.91,0.17-2.8c0.35-0.72,0.9-1.18,1.58-1.31c0.49-0.1,0.69-0.51,0.97-1.18
			c0.25-0.59,0.59-1.39,1.47-1.32c0.26,0.02,0.47,0,0.66-0.02c0.7-0.08,1.18-0.06,2.07,1c0.63,0.75,0.97,0.84,1.05,0.82
			c0,0,0.45-0.18,0.57-2.32c0.12-2.25,0.4-4.62,1.29-6.35c-1.5-0.64-3.07-1.16-4.45-2.06c-1.64-0.04-3.31,0-4.93-0.18
			c-1.87-0.61-3.45-2.11-5.52-2.03c-4.18-0.1-8.34-0.53-12.5-1.04c1.16,2.31,3.86,2.8,5.93,4c0.67,1.54,0.2,3.21,0.04,4.81
			c-2.15,1.58-4.34,3.19-6.9,4.04c-0.28,1.32-0.45,2.66-0.85,3.94c-0.85,0.99-2.03,1.6-3.07,2.35c0.28,2.82-1.91,4.85-2.27,7.51
			C334.71,198.11,335.81,197.83,336.92,197.61z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#booshehr">
                            <svg class="map-province booshehr">
                                <path class="map-path" id="path-booshehr" d="M324.01,387.42c0.69-2.41,3.94-4.02,6.05-2.39
			c1.73,1.3,3.51,2.56,5.03,4.08c2.82,4.14,7.81,6.7,9.01,11.87c3.92,2.37,8.38,3.55,12.54,5.38c2.17,3.43,3.88,7.43,7.63,9.44
			c5.36,2.84,7.9,8.52,11.59,13.01c2.03,2.64,3.55,5.72,4.49,8.91c0.04,5.01,0.22,10.11,1.73,14.92c1.5,2.6,3.02,5.2,4.26,7.94
			c0.85,2.01,3.19,2.52,4.63,3.98c1.1,1.58,0.89,3.59,0.95,5.42c1.22,1.4,3.02,2.48,3.39,4.42c0.38,1.55,0.73,3.12,1.34,4.6
			c0.61,1,1.77,1.93,2.52,2.5c3.21,2.45,6.41,4.95,9.72,7.27c-0.82,1.44-1.74,2.32-2.94,3.03c-2.15-1.83-3.68-2.27-6.32-3.19
			c1.26-0.04,4.26,0.22,3.69-1.93c-1.52-1.32-3.15-2.48-4.38-4.15c-0.62-0.85-2-2.05-3.23-3.04c-1.29-0.63-2.67-1.04-4.08-1.32
			c-3.21-0.57-5.3-3.27-7.59-5.32c-1.52-1.4-3.75-0.93-5.64-1.26c-3.25-0.55-6.54-0.71-9.82-0.81c-1.38-1.99-3.41-3.25-5.54-4.28
			c-1.4-1.32-2.44-3-3.55-4.57c-0.2-1.81,0.57-3.82-0.65-5.38c-2.01-3.04-3.98-6.15-5.18-9.62c-0.2-3.29,0.61-7.73-2.82-9.68
			c-2.48-0.85-4.99-2.27-5.34-5.18c1.75-0.97,4.65-3.09,2.84-5.24c-1.89-2.21-5.05-2.9-7.85-2.46c0.97-1.95,1.71-4.12,0.67-6.21
			c0.2-1.3,0.49-2.6,0.57-3.9c-2.76-1.83-4.79-4.36-6.66-7.04c-3.43-3.35-5.48-7.77-8.67-11.28c0.04-1.58,0.28-3.17,0.08-4.73
			C325.9,389.82,324.9,388.64,324.01,387.42z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kohkilooyeh">
                            <svg class="map-province kohkilooyeh">
                                <path class="map-path" id="path-kohkilooyeh" d="M332.13,343.02
			c1.05,0.63,2.11,1.28,3.17,1.93c1.5,0.04,3.02-0.08,4.51,0.24c1.3,1.12,2.21,2.94,4.14,2.98c3,0.24,4.65,3.27,7.51,3.88
			c2.92,0.43,5.97-0.34,8.81,0.55c2.6,1.81,4.46,4.55,5.8,7.37c0.77,2.07,3.59,1.24,4.87,2.74c1.71,1.89,3.73,3.53,6.39,3.69
			c0.28,2.54-1.18,4.61-1.93,6.88c1.66,2.88,1.58,6.17,1.52,9.38c-1.06,1.16-2.56,2.31-4.2,1.58c-2.6-1.28-4.91-3.07-7.55-4.26
			c-2.25-0.95-3.82-2.9-5.76-4.3c-1.52-1.12-3.49-0.32-5.2-0.26c0.26,3.71,4.1,6.07,3.82,9.93c-1.62,1.62-3.39,3.25-5.83,3.29
			c-4.55,0.14-5.07,6.98-9.64,6.86c-2.19-2.38-4.79-4.4-6.48-7.21c0.26-0.24,0.77-0.73,1.04-0.95c0.22-3.67,1.2-7.71-0.89-11.02
			c1.3-1.32,2.44-2.82,3.25-4.5c-1.08-0.43-2.17-0.83-3.27-1.24c-0.73-2.23-2.5-3.45-4.69-4.02c-0.47-1.08-0.77-2.21-1.26-3.27
			c-2.39-1.22-5.18-0.95-7.73-1.6c-1.5-0.51-2.17-2.07-3-3.29c0.95-1.01,2.27-1.85,2.66-3.25c0-1.3-0.3-2.56-0.47-3.84
			c1.66-0.69,3.84-0.73,4.97-2.31C328.31,346.83,330.12,344.84,332.13,343.02z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#charmahal">
                            <svg class="map-province charmahal">
                                <path class="map-path" id="path-charmahal" d="M311.79,294.83c0.47-1.48,1.18-2.84,2.11-4.08
			c2.23,2.74,3.67,5.99,5.91,8.71c2.76,1.06,6.76-1.34,8.91,1.6c1.4,2.03,3.43,3.27,5.87,3.67c1.77-0.89,3-2.42,4.2-3.92
			c3.9-2.17,9.21-0.89,11.55,3c0.14,1.6-0.04,3.37,0.81,4.83c2.07,2.72,4.08,5.52,6.62,7.86c1.56,1.3,1.62,3.49,2.64,5.15
			c0.93,1.48,2.21,2.72,3.33,4.06c-0.87,2.82-2.17,5.5-3.17,8.28c0.08,2.54-0.34,5.56,1.6,7.55c0.59,0.85,0,2.03,0.02,3.02
			c-0.49,0.2-1.48,0.59-1.99,0.79c-0.61,1.87-0.41,3.82,0.02,5.72c-2.58-0.04-5.18,0.1-7.75-0.06c-2.39-0.16-4.1-2.05-5.97-3.33
			c-1.24-0.47-2.6-0.53-3.82-1.08c-0.91-0.81-1.66-1.77-2.48-2.68c-2.64,0.22-5.32-0.02-7.41-1.81c2.68-1.18,4.1-3.8,5.42-6.23
			c-0.39-0.97-1.03-1.83-1.58-2.68c-0.28-1.22-0.24-2.74-1.46-3.47c-2.56-1.95-4.83-4.2-7.23-6.33c-2.05-1.71-2.48-4.57-4.28-6.48
			c-1.44-1.58-1.5-3.82-2.37-5.68c-1.34-1.75-3.33-2.98-4.06-5.16c-0.95-3-4.14-4.08-6.56-5.6c-1.18-0.67-1.16-2.27-1.73-3.39
			C309.9,296.37,310.84,295.6,311.79,294.83z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#golestan">
                            <svg class="map-province golestan">
                                <path class="map-path" id="path-golestan" d="M494.68,107.19c2.44-0.67,4.3,1.85,6.76,1.54
			c2.84-0.16,5.74-0.51,8.5,0.49c1.16,1.56,2.41,3.88,0.99,5.66c-4.99,3.55-6.68,9.97-7.43,15.75c-0.12,1.81-1.5,3.15-2.58,4.47
			c-1.34,1.95-4.24,1.1-5.66,2.86c-0.59,0.61-1.1,1.24-1.6,1.89c0.24,2.25-1.1,3.96-2.68,5.38c0.1,1.08,0.22,2.15,0.35,3.23
			c-1.56,3-2.48,6.39-4.85,8.91c-3.33-0.04-6.68-0.79-9.94,0.08c-2.44,0.51-4.3,2.21-6.39,3.41c-1.66,1.02-3.67,0.28-5.44,0.02
			c-2.52,1.04-4.02,3.47-6.31,4.81c-2.09,0.45-4.22,0.47-6.31,0.69c0-2.07-1.58-2.96-3.43-3.21c-0.49-0.89-0.93-1.83-1.5-2.66
			c-1.66-1.14-3.98-1.01-5.52-2.39c-0.47-1-0.28-2.17-0.45-3.23c1.79-0.41,3.55-0.85,5.32-1.32c0.73-2.15,0.22-4.38-0.2-6.54
			c-0.63-4.04-2.21-7.88-2.86-11.91c2.9,0.04,5.76,0.63,8.65,0.77c2.54-0.63,4.75-2.03,6.92-3.39c1.77-1.2,3.92,0.12,5.87-0.28
			c1.12-0.59,2.05-1.5,2.78-2.54c1.83-2.8,0.28-6.82,2.88-9.25c2.58-2.19,5.42-4.1,7.53-6.76c3-0.67,5.8-2.07,8.12-4.12
			C488.43,107.32,491.8,107.78,494.68,107.19z" />
                            </svg>
                        </a>
                        <!-- End province -->

                        <svg class="map-sea-names">
                            <g class="map-sea-names">
                                <path d="M405.31,537.88c0,0.61-0.15,1.12-0.44,1.53c-0.33,0.47-0.79,0.7-1.38,0.7c-0.72,0-1.24-0.29-1.55-0.86
				c-0.33,0.57-0.84,0.86-1.54,0.86c-0.5,0-0.88-0.14-1.15-0.42c0,0.13,0,0.25,0,0.38c0,1.3-0.41,2.33-1.22,3.1
				c-0.81,0.77-1.87,1.15-3.18,1.15c-1.09,0-1.97-0.32-2.63-0.96c-0.66-0.64-0.99-1.51-0.99-2.59c0-0.87,0.25-1.73,0.76-2.57
				l0.82,0.31c-0.14,0.23-0.28,0.55-0.39,0.97c-0.12,0.42-0.18,0.76-0.18,1.04c0,1.72,0.94,2.59,2.82,2.59
				c0.88,0,1.62-0.22,2.23-0.65c0.69-0.49,1.03-1.15,1.03-2c0-0.84-0.27-1.69-0.8-2.53l0.97-0.83c0.28,0.58,0.52,0.98,0.72,1.21
				c0.32,0.38,0.7,0.58,1.12,0.58c0.47,0,0.79-0.11,0.97-0.34c0.16-0.19,0.24-0.53,0.24-1.02v-0.2l0.81-0.29v0.13
				c0,1.15,0.4,1.72,1.2,1.72c0.55,0,0.83-0.29,0.83-0.86c0-0.23-0.16-0.58-0.49-1.05l0.8-0.91
				C405.1,536.57,405.31,537.17,405.31,537.88z" />
                                <path d="M411.6,538.41c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C411.3,536.67,411.6,537.53,411.6,538.41z" />
                                <path d="M416.26,540.11h-0.52c-0.86,0-1.48-0.37-1.84-1.12c-0.24-0.5-0.39-1.27-0.43-2.3
				c-0.02-0.36-0.04-1.37-0.06-3.03c-0.02-1.14-0.08-2.33-0.18-3.55l1.11-0.57c0.03,2.42,0.08,4.72,0.14,6.92
				c0.02,0.72,0.09,1.25,0.23,1.58c0.22,0.54,0.62,0.82,1.21,0.82h0.34V540.11z" />
                                <path d="M420.16,537.2c0,1.94-1,2.91-2.99,2.91h-1.44v-1.24h1.3c0.33,0,0.73-0.07,1.22-0.21
				c0.63-0.17,0.94-0.38,0.94-0.63v-0.54c-0.36,0.22-0.77,0.32-1.23,0.32c-0.4,0-0.72-0.12-0.96-0.35c-0.24-0.23-0.35-0.55-0.35-0.95
				c0-0.47,0.14-1,0.43-1.6c0.36-0.76,0.79-1.14,1.3-1.14c0.55,0,1,0.46,1.36,1.37C420.01,535.86,420.16,536.55,420.16,537.2z
				 M419.07,531.59l-0.81,1.07l-1.09-0.72l0.79-1.09L419.07,531.59z M418.98,536.42c-0.17-0.94-0.43-1.41-0.81-1.41
				c-0.17,0-0.33,0.14-0.49,0.41c-0.15,0.24-0.22,0.46-0.22,0.64c0,0.43,0.22,0.64,0.67,0.64
				C418.48,536.71,418.77,536.61,418.98,536.42z" />
                                <path d="M434.86,545.95c-1.12,0.38-2.26,0.57-3.43,0.57c-1.54,0-2.75-0.28-3.65-0.85
				c-1.09-0.68-1.63-1.75-1.63-3.2c0-1.2,0.5-2.3,1.5-3.3c0.8-0.8,1.79-1.42,2.97-1.88c-1.35-0.4-2.12-0.6-2.33-0.6
				c-0.37,0-0.71,0.26-1.02,0.79l-0.8-0.35c0.48-1.12,1.04-1.69,1.7-1.69c0.47,0,1.27,0.17,2.41,0.5c1.13,0.33,2.01,0.5,2.62,0.5
				c0.29,0,0.59-0.01,0.89-0.04l-0.32,1.25c-0.76,0.01-1.32,0.09-1.67,0.23c0.06,0.42,0.26,0.71,0.59,0.85
				c0.24,0.1,0.67,0.15,1.28,0.15h0.85v1.24h-1.17c-0.6,0-1.1-0.2-1.5-0.59c-0.4-0.39-0.62-0.89-0.67-1.5
				c-1.13,0.38-2.07,0.91-2.82,1.57c-0.94,0.83-1.41,1.76-1.41,2.79c0,1.94,1.51,2.91,4.52,2.91c1.12,0,2.05-0.13,2.78-0.39
				L434.86,545.95z M431.6,542.17l-0.82,1.07l-1.07-0.72l0.79-1.09L431.6,542.17z" />
                                <path d="M439.36,540.11h-0.71c-0.97,0-1.61-0.34-1.91-1.02c-0.15,0.31-0.39,0.56-0.72,0.75
				c-0.33,0.18-0.67,0.28-1.03,0.28h-0.72v-1.24h0.64c0.42,0,0.76-0.09,1.04-0.28c0.32-0.22,0.48-0.52,0.48-0.92v-0.53l0.85-0.23
				c0.01,0.81,0.15,1.35,0.43,1.63c0.22,0.22,0.59,0.33,1.13,0.33h0.51V540.11z M438.49,542.36l-0.72,0.92l-0.95-0.7l-0.67,0.83
				l-1.01-0.71l0.77-0.93l0.9,0.67l0.66-0.8L438.49,542.36z" />
                                <path d="M443.23,540.11h-0.52c-0.73,0-1.25-0.37-1.56-1.12c-0.44,0.75-1.04,1.12-1.78,1.12h-0.53v-1.24h0.28
				c0.67,0,1.11-0.2,1.33-0.62c0.17-0.31,0.24-0.82,0.22-1.56l-0.19-6.58l1.1-0.57v6.73c0,1.72,0.44,2.58,1.32,2.58h0.34V540.11z" />
                                <path d="M450.91,536.63l-0.28,1.19c-0.98,0.01-1.81,0.21-2.49,0.61c-0.33,0.21-0.94,0.57-1.81,1.09
				c-0.69,0.39-1.58,0.59-2.67,0.59h-0.94v-1.24h0.99c0.75,0,1.38-0.08,1.89-0.25c0.33-0.11,0.78-0.32,1.35-0.63
				c0.6-0.34,1.04-0.56,1.33-0.67c-0.32-0.08-0.8-0.27-1.46-0.58c-0.6-0.28-1-0.42-1.17-0.42c-0.28,0-0.65,0.23-1.11,0.69l-0.71-0.41
				c0.19-0.33,0.45-0.65,0.77-0.95c0.38-0.35,0.7-0.53,0.96-0.53c0.39,0,0.87,0.14,1.46,0.41c0.94,0.44,1.49,0.69,1.65,0.74
				C449.35,536.53,450.11,536.65,450.91,536.63z M448.21,532.78l-0.82,1.06l-1.08-0.73l0.8-1.1L448.21,532.78z" />
                            </g>
                            <g class="map-sea-names">
                                <path d="M343.29,90.64c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C343,88.9,343.29,89.76,343.29,90.64z" />
                                <path d="M351.26,92.34h-0.51c-0.42,0-0.78-0.08-1.07-0.22c-0.13,1.03-0.77,2.04-1.92,3.03
				c-0.78,0.67-1.66,1.23-2.66,1.7l-0.78-0.65c1.11-0.64,2.07-1.3,2.86-1.96c1-0.84,1.5-1.53,1.5-2.06c0-0.4-0.25-0.95-0.75-1.65
				l0.83-0.96c0.42,0.59,0.67,0.93,0.75,1.01c0.34,0.35,0.75,0.52,1.23,0.52h0.52V92.34z M348.8,86.98l-0.81,1.07l-1.09-0.73
				l0.79-1.09L348.8,86.98z" />
                                <path d="M358.94,88.86l-0.28,1.19c-0.98,0.01-1.81,0.21-2.49,0.61c-0.33,0.21-0.94,0.57-1.81,1.09
				c-0.69,0.39-1.58,0.59-2.67,0.59h-0.94V91.1h0.99c0.75,0,1.38-0.08,1.89-0.25c0.33-0.11,0.78-0.32,1.35-0.63
				c0.6-0.34,1.04-0.56,1.33-0.67c-0.32-0.08-0.8-0.27-1.46-0.58c-0.6-0.28-1-0.42-1.17-0.42c-0.28,0-0.65,0.23-1.11,0.69l-0.71-0.41
				c0.19-0.33,0.45-0.65,0.77-0.95c0.38-0.35,0.7-0.53,0.96-0.53c0.39,0,0.87,0.14,1.46,0.41c0.94,0.44,1.49,0.69,1.65,0.74
				C357.39,88.76,358.14,88.88,358.94,88.86z M356.24,85.01l-0.82,1.06l-1.09-0.73l0.8-1.1L356.24,85.01z" />
                                <path d="M374.52,86.85l-0.41,1.1c-0.27-0.12-0.58-0.17-0.94-0.17c-0.54,0-1.09,0.18-1.66,0.54
				c-0.6,0.39-0.97,0.83-1.09,1.32c-0.01,0.04-0.02,0.1-0.02,0.16c0,0.26,0.32,0.44,0.97,0.52c0.43,0.03,0.85,0.06,1.28,0.09
				c1,0.11,1.5,0.58,1.5,1.41c0,0.84-0.62,1.62-1.86,2.35c-1.19,0.7-2.37,1.05-3.56,1.05c-1.15,0-2.06-0.26-2.73-0.77
				c-0.74-0.57-1.11-1.42-1.11-2.54c0-0.96,0.25-1.85,0.76-2.65l0.81,0.36c-0.38,0.68-0.57,1.32-0.57,1.94
				c0,1.62,1.01,2.43,3.02,2.43c0.68,0,1.4-0.13,2.15-0.38c0.78-0.26,1.42-0.6,1.92-1.02c0.24-0.21,0.37-0.39,0.37-0.54
				c0-0.21-0.18-0.33-0.54-0.37c-1.51-0.18-2.36-0.3-2.57-0.38c-0.47-0.17-0.7-0.57-0.7-1.21c0-0.88,0.42-1.7,1.27-2.45
				c0.82-0.73,1.68-1.1,2.57-1.1C373.83,86.51,374.2,86.62,374.52,86.85z" />
                                <path d="M379.16,92.34h-0.52c-0.86,0-1.48-0.37-1.84-1.12c-0.24-0.5-0.39-1.27-0.43-2.3
				c-0.02-0.36-0.04-1.37-0.06-3.03c-0.02-1.14-0.08-2.33-0.18-3.55l1.11-0.57c0.03,2.42,0.08,4.72,0.14,6.92
				c0.02,0.72,0.09,1.25,0.23,1.58c0.22,0.54,0.62,0.82,1.21,0.82h0.34V92.34z" />
                                <path d="M381.83,90.2c0,1.43-0.83,2.14-2.49,2.14h-0.71V91.1h0.77c0.96,0,1.44-0.26,1.44-0.78
				c0-0.28-0.14-0.6-0.42-0.97l-0.28-0.37l0.86-0.94C381.55,88.67,381.83,89.38,381.83,90.2z M382.67,94.59l-0.72,0.92l-0.95-0.7
				l-0.67,0.83l-1.01-0.71l0.77-0.93l0.9,0.67l0.66-0.8L382.67,94.59z" />
                                <path d="M388.76,90.64c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C388.47,88.9,388.76,89.76,388.76,90.64z" />
                                <path d="M395.78,90.06c0,1.01-0.43,1.7-1.29,2.05c-0.37,0.15-1.04,0.24-2.03,0.28c-0.91,0.04-1.61-0.2-2.1-0.71
				l0.56-0.96c0.32,0.24,0.78,0.37,1.41,0.37c0.67,0,1.12-0.02,1.36-0.07c0.8-0.14,1.2-0.41,1.2-0.8c0-0.81-0.8-1.74-2.41-2.78
				l0.51-1.25c0.67,0.38,1.26,0.89,1.8,1.51C395.44,88.51,395.78,89.29,395.78,90.06z" />
                            </g>
                        </svg>
                        <svg class="map-province-names">
                            <g class="map-province-names">
                                <path d="M563.21,189.12l-0.36,0.96c-0.23-0.1-0.51-0.15-0.82-0.15c-0.47,0-0.95,0.16-1.45,0.47
				c-0.53,0.34-0.85,0.72-0.95,1.16c-0.01,0.04-0.01,0.08-0.01,0.14c0,0.23,0.28,0.38,0.85,0.46c0.37,0.02,0.75,0.05,1.12,0.08
				c0.88,0.1,1.32,0.51,1.32,1.23c0,0.73-0.54,1.42-1.63,2.06c-1.04,0.61-2.08,0.92-3.11,0.92c-1.01,0-1.8-0.23-2.39-0.68
				c-0.65-0.5-0.97-1.24-0.97-2.23c0-0.84,0.22-1.62,0.66-2.32l0.71,0.31c-0.33,0.59-0.5,1.16-0.5,1.7c0,1.42,0.88,2.12,2.64,2.12
				c0.6,0,1.22-0.11,1.88-0.33c0.68-0.23,1.24-0.53,1.68-0.9c0.21-0.18,0.32-0.34,0.32-0.47c0-0.18-0.16-0.29-0.47-0.33
				c-1.32-0.16-2.07-0.27-2.25-0.34c-0.41-0.15-0.61-0.5-0.61-1.06c0-0.77,0.37-1.49,1.11-2.15c0.72-0.64,1.47-0.96,2.25-0.96
				C562.6,188.82,562.93,188.92,563.21,189.12z" />
                                <path d="M569.43,193.92h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V193.92z M567.29,192.82
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C566.88,192.93,567.13,192.9,567.29,192.82z" />
                                <path d="M578.38,191.19c0,0.96-0.43,1.68-1.3,2.16c-0.7,0.38-1.57,0.58-2.61,0.58h-1.96c-0.46,0-0.8-0.03-1.02-0.1
				c-0.32-0.1-0.58-0.31-0.77-0.62c-0.32,0.49-0.74,0.73-1.27,0.73h-0.47v-1.08h0.33c0.71,0,1.06-0.38,1.06-1.13v-0.28l0.82-0.29
				v0.18c0,1.02,0.29,1.53,0.88,1.53c0.32,0,0.57-0.12,0.76-0.36c0.12-0.15,0.33-0.42,0.64-0.81c0.35-0.43,0.8-0.84,1.34-1.23
				c0.72-0.52,1.37-0.78,1.96-0.78c0.43,0,0.81,0.15,1.13,0.44C578.22,190.4,578.38,190.76,578.38,191.19z M577.45,191.56
				c0-0.27-0.12-0.48-0.37-0.64c-0.2-0.13-0.45-0.19-0.74-0.19c-0.67,0-1.66,0.7-2.96,2.11h1.17c1,0,1.77-0.15,2.29-0.46
				C577.25,192.14,577.45,191.87,577.45,191.56z M575.97,187.15l-0.71,0.94l-0.95-0.64l0.69-0.95L575.97,187.15z" />
                                <path d="M583.87,192.44c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C583.61,190.92,583.87,191.67,583.87,192.44z" />
                                <path d="M595.94,191.73c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C595.65,190.04,595.94,190.86,595.94,191.73z M593.33,188.18l-0.71,0.93l-0.95-0.64l0.7-0.95L593.33,188.18z" />
                                <path d="M600.02,193.92h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V193.92z" />
                                <path d="M607.16,192c0,0.52-0.14,0.97-0.41,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C606.97,190.81,607.16,191.36,607.16,192z" />
                                <path d="M609.53,193.72l-0.73,0.2l-0.23-8.86l0.97-0.37V193.72z" />
                                <path d="M616.5,193.92h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V193.92z" />
                                <path d="M623.22,190.88l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C621.86,190.8,622.52,190.9,623.22,190.88z M620.86,187.51l-0.71,0.93l-0.95-0.64l0.7-0.96
				L620.86,187.51z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M545.98,289.01h-1.67c-0.72,0-1.08,0.08-1.08,0.24c0,0.1,0.28,0.21,0.84,0.33
				c0.66,0.14,1.03,0.23,1.1,0.26c0.35,0.18,0.53,0.48,0.53,0.9c0,0.66-0.53,1.22-1.59,1.69c-0.87,0.38-1.69,0.57-2.44,0.57
				c-1.02,0-1.81-0.24-2.38-0.71c-0.61-0.51-0.91-1.27-0.91-2.27c0-0.72,0.21-1.48,0.63-2.27l0.79,0.27
				c-0.31,0.64-0.47,1.23-0.47,1.76c0,1.42,0.82,2.12,2.45,2.12c1.27,0,2.28-0.29,3.04-0.86c0.07-0.05,0.11-0.11,0.11-0.16
				c0-0.07-0.05-0.12-0.16-0.13c-0.96-0.15-1.61-0.29-1.94-0.44c-0.11-0.05-0.21-0.16-0.28-0.32c-0.08-0.16-0.12-0.31-0.12-0.44
				c0-1.08,0.95-1.61,2.84-1.61h0.69V289.01z" />
                                <path d="M548.33,287.14c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C548.08,285.8,548.33,286.43,548.33,287.14z M548.05,291.04l-0.71,0.93
				l-0.95-0.63l0.7-0.96L548.05,291.04z" />
                                <path d="M554.57,289.01h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V289.01z M552.43,287.91
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C552.02,288.01,552.27,287.99,552.43,287.91z" />
                                <path d="M558.54,289.01h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V289.01z M556.9,283.85l-0.71,0.93l-0.95-0.64l0.7-0.95
				L556.9,283.85z" />
                                <path d="M565.27,285.97l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C563.9,285.88,564.57,285.99,565.27,285.97z M563.36,290.67l-0.71,0.93l-0.95-0.63l0.7-0.96
				L563.36,290.67z" />
                                <path d="M577.32,286.82c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C577.02,285.13,577.32,285.95,577.32,286.82z M574.7,283.27l-0.71,0.93l-0.95-0.64l0.7-0.95L574.7,283.27z" />
                                <path d="M581.39,289.01h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V289.01z" />
                                <path d="M588.53,287.08c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C588.34,285.9,588.53,286.45,588.53,287.08z" />
                                <path d="M590.91,288.81l-0.73,0.2l-0.23-8.86l0.97-0.37V288.81z" />
                                <path d="M597.87,289.01h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V289.01z" />
                                <path d="M604.59,285.97l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C603.23,285.88,603.9,285.99,604.59,285.97z M602.23,282.6l-0.71,0.93l-0.95-0.64l0.7-0.96
				L602.23,282.6z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M540.6,408.31c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C540.3,406.61,540.6,407.43,540.6,408.31z M537.99,404.76l-0.71,0.93l-0.95-0.64l0.7-0.95L537.99,404.76z" />
                                <path d="M544.67,410.5h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V410.5z" />
                                <path d="M549.43,408.93c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C549.32,407.87,549.43,408.41,549.43,408.93z M548.54,408.69c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C548.48,409.1,548.54,408.96,548.54,408.69z" />
                                <path d="M556.39,410.5h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V410.5z" />
                                <path d="M561.81,401.55l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C557.72,403.49,559.56,402.51,561.81,401.55z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M221.84,100.58c0,0.96-0.29,1.73-0.87,2.3c-0.58,0.57-1.35,0.86-2.31,0.86c-0.84,0-1.5-0.28-2-0.85
				c-0.44-0.5-0.66-1.1-0.66-1.8c0-0.61,0.18-1.19,0.55-1.73l0.6,0.22c-0.25,0.5-0.37,0.93-0.37,1.31c0,1.29,0.67,1.93,2,1.93
				c0.67,0,1.21-0.18,1.62-0.53c0.42-0.38,0.64-0.89,0.64-1.56c0-0.6-0.21-1.16-0.62-1.7l0.66-0.56
				C221.59,99.12,221.84,99.82,221.84,100.58z M219.61,97.53l-0.61,0.8l-0.81-0.55l0.6-0.82L219.61,97.53z" />
                                <path d="M225.34,102.45h-0.39c-0.65,0-1.11-0.28-1.38-0.84c-0.18-0.38-0.29-0.95-0.32-1.72
				c-0.01-0.27-0.03-1.03-0.04-2.27c-0.01-0.86-0.06-1.74-0.14-2.66l0.83-0.42c0.02,1.82,0.06,3.54,0.11,5.19
				c0.01,0.54,0.07,0.94,0.17,1.19c0.17,0.41,0.47,0.61,0.9,0.61h0.26V102.45z" />
                                <path d="M232.19,102.45h-0.99c-0.56,0-0.96-0.19-1.21-0.56c-0.07-0.11-0.18-0.42-0.33-0.92l-1.9,0.98
				c-0.64,0.33-1.33,0.5-2.06,0.5h-0.76v-0.92h0.74c0.73,0,1.36-0.12,1.9-0.37c0.32-0.15,0.88-0.42,1.7-0.8
				c-0.36-0.08-0.8-0.23-1.32-0.47c-0.48-0.22-0.78-0.33-0.9-0.33c-0.25,0-0.49,0.17-0.74,0.5l-0.57-0.3
				c0.42-0.77,0.83-1.16,1.23-1.16c0.28,0,0.64,0.1,1.08,0.3c0.68,0.3,1.1,0.49,1.27,0.54c0.57,0.19,1.16,0.29,1.77,0.29
				c0.12,0,0.25,0,0.37,0l-0.21,0.87c-0.5,0-0.88,0.07-1.17,0.21c0.08,0.3,0.25,0.5,0.51,0.61c0.18,0.08,0.45,0.11,0.82,0.11h0.75
				V102.45z M229.46,103.87l-0.61,0.8l-0.81-0.54l0.6-0.82L229.46,103.87z" />
                                <path d="M234.2,100.85c0,1.07-0.62,1.61-1.86,1.61h-0.53v-0.93h0.58c0.72,0,1.08-0.19,1.08-0.58
				c0-0.21-0.11-0.45-0.32-0.73l-0.21-0.28l0.64-0.71C233.99,99.7,234.2,100.24,234.2,100.85z M234.84,104.14l-0.54,0.69l-0.71-0.52
				l-0.5,0.62l-0.75-0.54l0.57-0.7l0.68,0.5l0.49-0.6L234.84,104.14z" />
                                <path d="M238.18,102.45h-0.39c-0.65,0-1.11-0.28-1.38-0.84c-0.18-0.38-0.29-0.95-0.32-1.72
				c-0.01-0.27-0.03-1.03-0.04-2.27c-0.01-0.86-0.06-1.74-0.14-2.66l0.83-0.42c0.02,1.82,0.06,3.54,0.11,5.19
				c0.01,0.54,0.07,0.94,0.17,1.19c0.17,0.41,0.47,0.61,0.9,0.61h0.26V102.45z" />
                                <path d="M240.18,100.85c0,1.07-0.62,1.61-1.86,1.61h-0.53v-0.93h0.58c0.72,0,1.08-0.19,1.08-0.58
				c0-0.21-0.11-0.45-0.32-0.73l-0.21-0.28l0.64-0.71C239.97,99.7,240.18,100.24,240.18,100.85z M239.94,104.19l-0.61,0.8l-0.81-0.54
				l0.6-0.82L239.94,104.19z" />
                                <path d="M244.9,101.18c0,0.74-0.43,1.5-1.29,2.27c-0.61,0.55-1.28,0.99-2,1.33l-0.65-0.49
				c0.82-0.45,1.52-0.94,2.11-1.45c0.72-0.62,1.08-1.14,1.08-1.54c0-0.4-0.19-0.87-0.57-1.4l0.65-0.66
				C244.67,99.88,244.9,100.52,244.9,101.18z" />
                                <path d="M250.16,100.75c0,0.76-0.32,1.27-0.97,1.53c-0.27,0.11-0.78,0.18-1.52,0.21
				c-0.68,0.03-1.21-0.15-1.58-0.53l0.42-0.72c0.24,0.18,0.59,0.27,1.05,0.27c0.5,0,0.84-0.02,1.02-0.05c0.6-0.11,0.9-0.31,0.9-0.6
				c0-0.61-0.6-1.31-1.81-2.08l0.38-0.94c0.5,0.29,0.95,0.67,1.35,1.13C249.91,99.58,250.16,100.17,250.16,100.75z M248.16,96.06
				l-0.61,0.8l-0.81-0.55l0.6-0.82L248.16,96.06z" />
                                <path d="M255.09,93.25c-0.15,0.23-0.34,0.43-0.59,0.59c-0.26,0.17-0.52,0.25-0.79,0.25c-0.16,0-0.39-0.03-0.7-0.08
				c-0.31-0.05-0.54-0.08-0.7-0.08c-0.27,0-0.53,0.1-0.79,0.29l-0.38-0.45c0.33-0.35,0.68-0.52,1.04-0.52c0.15,0,0.38,0.02,0.68,0.07
				c0.3,0.05,0.53,0.07,0.68,0.07c0.47,0,0.9-0.18,1.3-0.55L255.09,93.25z M253.45,102.28l-0.63,0.17l-0.19-7.6l0.82-0.32V102.28z" />
                                <path d="M231.09,117.78h-1.43c-0.62,0-0.92,0.07-0.92,0.21c0,0.09,0.24,0.18,0.72,0.28
				c0.57,0.12,0.88,0.2,0.94,0.22c0.3,0.15,0.46,0.41,0.46,0.77c0,0.56-0.45,1.05-1.36,1.44c-0.75,0.33-1.44,0.49-2.09,0.49
				c-0.87,0-1.55-0.2-2.04-0.61c-0.52-0.44-0.78-1.09-0.78-1.95c0-0.62,0.18-1.27,0.54-1.95l0.68,0.23c-0.27,0.55-0.4,1.05-0.4,1.51
				c0,1.21,0.7,1.82,2.1,1.82c1.08,0,1.95-0.25,2.61-0.74c0.06-0.05,0.09-0.09,0.09-0.14c0-0.06-0.05-0.1-0.14-0.11
				c-0.82-0.12-1.38-0.25-1.66-0.38c-0.1-0.05-0.18-0.14-0.24-0.27c-0.07-0.14-0.1-0.26-0.1-0.38c0-0.92,0.81-1.38,2.43-1.38h0.59
				V117.78z" />
                                <path d="M234.02,115.6c0,1.45-0.75,2.18-2.24,2.18h-1.08v-0.93h0.97c0.25,0,0.55-0.05,0.92-0.16
				c0.47-0.13,0.71-0.29,0.71-0.47v-0.41c-0.27,0.16-0.58,0.24-0.92,0.24c-0.3,0-0.54-0.09-0.72-0.26c-0.18-0.17-0.27-0.41-0.27-0.71
				c0-0.35,0.11-0.75,0.32-1.2c0.27-0.57,0.59-0.85,0.97-0.85c0.41,0,0.75,0.34,1.02,1.02C233.92,114.6,234.02,115.12,234.02,115.6z
				 M233.68,111.35l-0.54,0.69l-0.71-0.52l-0.5,0.62l-0.75-0.54l0.57-0.7l0.69,0.51l0.49-0.6L233.68,111.35z M233.14,115.02
				c-0.12-0.7-0.33-1.05-0.61-1.05c-0.12,0-0.25,0.1-0.37,0.31c-0.11,0.18-0.17,0.34-0.17,0.48c0,0.32,0.17,0.48,0.5,0.48
				C232.77,115.23,232.98,115.16,233.14,115.02z" />
                                <path d="M239.99,117.78h-0.38c-0.32,0-0.58-0.06-0.8-0.17c-0.1,0.77-0.58,1.53-1.44,2.27
				c-0.58,0.5-1.25,0.93-2,1.28l-0.59-0.49c0.84-0.48,1.55-0.97,2.15-1.47c0.75-0.63,1.12-1.15,1.12-1.55c0-0.3-0.19-0.71-0.56-1.23
				l0.62-0.72c0.31,0.44,0.5,0.7,0.56,0.76c0.26,0.26,0.57,0.39,0.92,0.39h0.39V117.78z" />
                                <path d="M246.12,116.13c0,0.45-0.12,0.83-0.36,1.13c-0.26,0.34-0.6,0.5-1.04,0.5c-0.57,0-0.98-0.21-1.2-0.64
				c-0.31,0.42-0.72,0.64-1.25,0.64c-0.57,0-0.93-0.21-1.09-0.64c-0.24,0.43-0.63,0.64-1.18,0.64h-0.4v-0.93h0.22
				c0.69,0,1.04-0.34,1.04-1.01v-0.15l0.61-0.22v0.16c0,0.81,0.27,1.22,0.8,1.22c0.62,0,0.93-0.34,0.93-1.02v-0.15l0.61-0.22v0.16
				c0,0.81,0.31,1.22,0.93,1.22c0.44,0,0.67-0.2,0.67-0.6c0-0.28-0.13-0.56-0.38-0.83l0.6-0.68
				C245.96,115.12,246.12,115.58,246.12,116.13z M244.77,112.82l-0.48,0.63l-0.69-0.51l-0.48,0.6l-0.67-0.48l0.51-0.63l0.66,0.49
				l0.46-0.58L244.77,112.82z M243.96,111.71l-0.45,0.59l-0.68-0.5l0.47-0.59L243.96,111.71z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M183.33,105.48l-0.42-1.37c-0.18-0.59-0.33-0.86-0.46-0.82c-0.08,0.03-0.1,0.28-0.06,0.77
				c0.05,0.58,0.07,0.9,0.06,0.97c-0.06,0.33-0.26,0.55-0.61,0.66c-0.54,0.16-1.13-0.13-1.78-0.88c-0.53-0.62-0.89-1.24-1.08-1.86
				c-0.25-0.84-0.26-1.54-0.01-2.13c0.27-0.63,0.82-1.06,1.64-1.31c0.59-0.18,1.26-0.2,2.02-0.05l-0.02,0.72
				c-0.6-0.09-1.12-0.08-1.56,0.06c-1.16,0.35-1.54,1.2-1.13,2.54c0.32,1.04,0.8,1.8,1.47,2.28c0.06,0.05,0.11,0.06,0.16,0.05
				c0.06-0.02,0.08-0.07,0.07-0.16c-0.12-0.82-0.16-1.39-0.12-1.7c0.02-0.11,0.08-0.21,0.19-0.31s0.22-0.17,0.33-0.21
				c0.88-0.27,1.56,0.37,2.03,1.92l0.17,0.57L183.33,105.48z" />
                                <path d="M182.18,107.68l-0.94-0.35l0.28-0.93l0.96,0.33L182.18,107.68z M185.45,106.94
				c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.56c0.21,0.69,0.5,0.98,0.87,0.86c0.2-0.06,0.4-0.23,0.6-0.52
				l0.2-0.28l0.86,0.41C186.49,106.41,186.03,106.76,185.45,106.94z" />
                                <path d="M185.65,113.12l-0.11-0.36c-0.09-0.3-0.12-0.57-0.07-0.82c-0.77,0.13-1.63-0.11-2.59-0.72
				c-0.65-0.41-1.25-0.93-1.8-1.54l0.3-0.7c0.7,0.66,1.38,1.2,2.03,1.63c0.82,0.53,1.42,0.74,1.81,0.62
				c0.29-0.09,0.63-0.38,1.02-0.89l0.87,0.39c-0.33,0.43-0.52,0.68-0.56,0.76c-0.17,0.32-0.21,0.66-0.1,1l0.11,0.38L185.65,113.12z" />
                                <path d="M188.6,117.19l-0.85,0.16c-0.95-1.36-1.65-2.76-2.09-4.2l-0.12-0.39l0.89-0.27l0.42,1.4
				c0.21-0.47,0.6-0.79,1.19-0.97c0.41-0.12,0.83-0.08,1.27,0.15c0.49,0.25,0.83,0.65,0.99,1.21c0.17,0.55,0.13,1.1-0.12,1.66
				l-0.67-0.11c0.1-0.43,0.08-0.87-0.06-1.32c-0.09-0.28-0.23-0.52-0.44-0.71c-0.25-0.22-0.5-0.3-0.76-0.22
				c-0.36,0.11-0.57,0.38-0.64,0.81c-0.06,0.33-0.02,0.7,0.1,1.1C187.81,115.83,188.11,116.4,188.6,117.19z M192.45,113.95
				l-0.94-0.35l0.28-0.94l0.96,0.33L192.45,113.95z" />
                                <path d="M191.83,127.01c-0.92,0.28-1.74,0.23-2.45-0.16c-0.72-0.39-1.22-1.04-1.49-1.96
				c-0.24-0.8-0.17-1.52,0.23-2.16c0.35-0.57,0.86-0.95,1.53-1.15c0.59-0.18,1.19-0.17,1.82,0.02l-0.03,0.64
				c-0.54-0.09-1-0.08-1.36,0.03c-1.23,0.37-1.65,1.2-1.26,2.47c0.2,0.64,0.52,1.11,0.98,1.4c0.48,0.3,1.04,0.35,1.68,0.16
				c0.57-0.17,1.05-0.54,1.44-1.08l0.73,0.47C193.15,126.34,192.55,126.79,191.83,127.01z M194.09,123.98l-0.94-0.35l0.29-0.94
				l0.95,0.33L194.09,123.98z" />
                                <path d="M191.05,130.89l-0.11-0.37c-0.19-0.62-0.06-1.14,0.4-1.56c0.31-0.29,0.83-0.56,1.55-0.81
				c0.25-0.09,0.98-0.33,2.16-0.7c0.82-0.26,1.65-0.56,2.5-0.9l0.65,0.67c-1.73,0.55-3.37,1.09-4.93,1.61
				c-0.51,0.17-0.88,0.34-1.08,0.51c-0.34,0.28-0.45,0.62-0.32,1.04l0.07,0.25L191.05,130.89z" />
                                <path d="M190.89,135.25l-0.94-0.35l0.28-0.93l0.96,0.33L190.89,135.25z M193.04,137.45l-0.29-0.94
				c-0.16-0.54-0.1-0.98,0.19-1.32c0.08-0.1,0.34-0.29,0.79-0.58l-1.49-1.53c-0.51-0.52-0.87-1.13-1.08-1.82l-0.22-0.73l0.88-0.27
				l0.21,0.7c0.21,0.7,0.51,1.27,0.91,1.71c0.24,0.26,0.66,0.72,1.26,1.4c-0.03-0.36-0.01-0.83,0.07-1.4
				c0.07-0.52,0.08-0.84,0.05-0.95c-0.07-0.23-0.3-0.42-0.69-0.56l0.12-0.63c0.86,0.17,1.35,0.45,1.47,0.84
				c0.08,0.27,0.09,0.64,0.03,1.12c-0.09,0.74-0.14,1.19-0.15,1.37c-0.02,0.61,0.06,1.2,0.24,1.77c0.04,0.12,0.07,0.24,0.11,0.36
				l-0.9,0.05c-0.15-0.47-0.33-0.82-0.54-1.05c-0.26,0.16-0.41,0.38-0.43,0.67c-0.02,0.19,0.02,0.46,0.13,0.81l0.22,0.72
				L193.04,137.45z" />
                                <path d="M192.19,140.47l-0.82-0.32l0.29-0.83l-0.74-0.3l0.29-0.88l0.83,0.35l-0.29,0.8l0.71,0.3L192.19,140.47z
				 M195.16,138.91c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.55c0.21,0.69,0.5,0.98,0.87,0.86
				c0.2-0.06,0.4-0.23,0.6-0.52l0.2-0.28l0.86,0.41C196.2,138.38,195.74,138.73,195.16,138.91z" />
                                <path d="M194.78,143.18l-0.11-0.37c-0.19-0.62-0.06-1.14,0.4-1.56c0.31-0.29,0.83-0.56,1.55-0.81
				c0.25-0.09,0.98-0.33,2.16-0.7c0.82-0.26,1.65-0.56,2.5-0.9l0.65,0.67c-1.73,0.55-3.37,1.09-4.93,1.61
				c-0.51,0.17-0.88,0.34-1.08,0.51c-0.34,0.28-0.45,0.63-0.32,1.04l0.07,0.24L194.78,143.18z" />
                                <path d="M193.63,145.38l-0.94-0.35l0.28-0.93l0.96,0.33L193.63,145.38z M196.9,144.63
				c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.55c0.21,0.69,0.5,0.98,0.87,0.86c0.2-0.06,0.4-0.23,0.6-0.52
				l0.2-0.28l0.86,0.41C197.93,144.1,197.48,144.45,196.9,144.63z" />
                                <path d="M197.95,149.24c-0.71,0.21-1.56,0.02-2.55-0.58c-0.7-0.42-1.32-0.93-1.86-1.53l0.28-0.76
				c0.67,0.65,1.34,1.19,2,1.6c0.81,0.51,1.4,0.7,1.79,0.58c0.38-0.12,0.77-0.43,1.18-0.95l0.82,0.44
				C199.13,148.65,198.58,149.04,197.95,149.24z" />
                                <path d="M199.9,154.15c-0.73,0.22-1.31,0.06-1.75-0.48c-0.19-0.23-0.4-0.7-0.65-1.39
				c-0.23-0.64-0.21-1.2,0.05-1.66l0.81,0.19c-0.11,0.28-0.09,0.64,0.04,1.09c0.14,0.48,0.26,0.8,0.34,0.96
				c0.28,0.54,0.56,0.77,0.83,0.69c0.58-0.18,1.07-0.96,1.47-2.34l1.01,0.09c-0.13,0.56-0.36,1.1-0.69,1.62
				C200.94,153.57,200.45,153.98,199.9,154.15z M203.8,150.87l-0.94-0.35l0.29-0.94l0.95,0.34L203.8,150.87z" />
                                <path d="M199.38,157.74l-0.35-0.55l7.21-2.39l0.54,0.7L199.38,157.74z M208.5,156.68c-0.27-0.07-0.51-0.2-0.73-0.4
				c-0.24-0.2-0.39-0.43-0.47-0.68c-0.05-0.15-0.09-0.38-0.13-0.69c-0.04-0.31-0.08-0.54-0.13-0.69c-0.08-0.25-0.25-0.48-0.51-0.67
				l0.33-0.5c0.43,0.21,0.7,0.49,0.8,0.84c0.04,0.15,0.09,0.37,0.13,0.67c0.04,0.3,0.08,0.52,0.13,0.67c0.14,0.45,0.44,0.81,0.9,1.08
				L208.5,156.68z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M274.45,91.42l-0.25-0.3c-0.28-0.33-0.35-0.7-0.21-1.12c-1.83,1.54-3.42,1.51-4.78-0.11
				c-0.51-0.61-0.73-1.24-0.65-1.88c0.08-0.62,0.42-1.2,1.04-1.71c0.58-0.49,1.2-0.77,1.87-0.87l0.23,0.62
				c-0.57,0.12-1.06,0.35-1.47,0.7c-0.96,0.81-1.01,1.71-0.17,2.71c1.01,1.2,2.18,1.22,3.49,0.04l5.16-4.62l0.92,0.39l-4.06,3.42
				c-0.86,0.72-1.04,1.38-0.54,1.96l0.14,0.17L274.45,91.42z" />
                                <path d="M274.95,94.63l-0.88,0.03l-0.06-0.88l-0.8,0.02l-0.08-0.92l0.9-0.01l0.05,0.84l0.77-0.01L274.95,94.63z
				 M276.66,94.04l-0.34-0.41c-0.47-0.56-0.58-1.09-0.34-1.59c-0.25,0.07-0.51,0.05-0.77-0.05c-0.27-0.1-0.48-0.25-0.66-0.46
				l-0.35-0.41l0.71-0.6l0.31,0.37c0.2,0.24,0.42,0.39,0.67,0.46c0.28,0.08,0.53,0.02,0.76-0.17l0.3-0.25l0.54,0.38
				c-0.46,0.39-0.7,0.74-0.72,1.04c-0.02,0.23,0.1,0.5,0.36,0.81l0.25,0.29L276.66,94.04z" />
                                <path d="M276.47,96.52l-1,0.05l-0.11-0.97l1.01-0.07L276.47,96.52z M279.18,94.54c-0.82,0.69-1.63,0.56-2.43-0.39
				l-0.34-0.41l0.71-0.6l0.37,0.44c0.46,0.55,0.84,0.7,1.14,0.45c0.16-0.13,0.28-0.37,0.35-0.71l0.07-0.34l0.95,0.04
				C279.92,93.64,279.65,94.15,279.18,94.54z" />
                                <path d="M282.65,98.5c-0.58,0.49-1.18,0.57-1.8,0.25c-0.26-0.14-0.64-0.48-1.14-1.03
				c-0.46-0.5-0.66-1.02-0.61-1.55l0.82-0.14c0.01,0.3,0.17,0.63,0.47,0.98c0.32,0.38,0.55,0.63,0.7,0.75
				c0.47,0.39,0.81,0.49,1.04,0.3c0.47-0.39,0.61-1.3,0.43-2.73l0.96-0.31c0.1,0.57,0.1,1.15,0,1.76
				C283.38,97.56,283.09,98.13,282.65,98.5z" />
                                <path d="M285.36,102.38c-0.57,0.48-1.42,0.64-2.57,0.48c-0.81-0.11-1.58-0.34-2.31-0.67l-0.04-0.81
				c0.88,0.33,1.7,0.56,2.47,0.68c0.94,0.15,1.57,0.09,1.87-0.17c0.31-0.26,0.54-0.7,0.71-1.34l0.92,0.08
				C286.21,101.37,285.86,101.96,285.36,102.38z" />
                                <path d="M285.84,104.66l-0.54-0.37l5.68-5.05l0.78,0.43L285.84,104.66z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M630.92,488.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C630.62,486.31,630.92,487.13,630.92,488.01z M628.31,484.46l-0.71,0.93l-0.95-0.64l0.7-0.95L628.31,484.46z" />
                                <path d="M634.99,490.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V490.2z" />
                                <path d="M638.98,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M638.2,484.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L638.2,484.87z" />
                                <path d="M647.78,490.2h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V490.2z" />
                                <path d="M654.51,487.15l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C653.15,487.07,653.81,487.17,654.51,487.15z M650.3,492.03l0.57-0.73l0.8,0.59l0.56-0.7l0.79,0.57
				l-0.59,0.74l-0.77-0.58l-0.55,0.68L650.3,492.03z M651.25,493.33l0.52-0.69l0.79,0.58l-0.55,0.68L651.25,493.33z" />
                                <path d="M660.73,490.2h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V490.2z M658.59,489.09
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C658.17,489.2,658.42,489.17,658.59,489.09z" />
                                <path d="M664.1,490.2h-0.46c-0.64,0-1.1-0.33-1.37-0.98c-0.39,0.66-0.91,0.98-1.56,0.98h-0.47v-1.08h0.25
				c0.58,0,0.97-0.18,1.16-0.54c0.15-0.27,0.21-0.72,0.19-1.36l-0.17-5.75l0.96-0.5v5.89c0,1.5,0.39,2.26,1.16,2.26h0.3V490.2z" />
                                <path d="M666.44,488.33c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C666.2,486.99,666.44,487.62,666.44,488.33z M666.16,492.23l-0.71,0.93
				l-0.95-0.63l0.7-0.96L666.16,492.23z" />
                                <path d="M675.38,488.58c0,1.03-0.34,1.97-1.03,2.82c-0.62,0.77-1.44,1.37-2.45,1.8l-0.68-0.76
				c0.98-0.53,1.69-0.99,2.12-1.37c0.67-0.59,1.06-1.25,1.19-1.98c-0.29,0.19-0.64,0.28-1.06,0.28c-0.41,0-0.73-0.1-0.98-0.3
				c-0.27-0.22-0.4-0.53-0.4-0.92c0-0.52,0.14-1.03,0.42-1.51c0.31-0.53,0.68-0.8,1.11-0.8c0.58,0,1.03,0.33,1.36,0.98
				C675.25,487.35,675.38,487.93,675.38,488.58z M674.34,488.11c-0.04-0.76-0.31-1.14-0.81-1.14c-0.17,0-0.32,0.09-0.45,0.27
				c-0.12,0.18-0.19,0.36-0.19,0.54c0,0.38,0.24,0.57,0.71,0.57C673.87,488.35,674.11,488.27,674.34,488.11z" />
                                <path d="M687.46,488.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C687.17,486.31,687.46,487.13,687.46,488.01z M684.85,484.46l-0.71,0.93l-0.95-0.64l0.7-0.95L684.85,484.46z" />
                                <path d="M691.54,490.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V490.2z" />
                                <path d="M695.52,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M694.74,484.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L694.74,484.87z" />
                                <path d="M704.33,490.2h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.32,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V490.2z" />
                                <path d="M708.32,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M707.56,492.17l-0.63,0.81l-0.83-0.61l-0.59,0.73
				l-0.88-0.62l0.67-0.81l0.79,0.59l0.57-0.7L707.56,492.17z" />
                                <path d="M715.46,488.27c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C715.28,487.09,715.46,487.63,715.46,488.27z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M452.06,206.66c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C451.77,204.96,452.06,205.78,452.06,206.66z M449.45,203.11l-0.71,0.93l-0.95-0.64l0.7-0.95L449.45,203.11z" />
                                <path d="M456.13,208.85h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V208.85z" />
                                <path d="M460.11,208.85h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V208.85z M458.47,203.68l-0.71,0.93l-0.95-0.64l0.7-0.95
				L458.47,203.68z" />
                                <path d="M466.21,208.85h-0.47c-0.45,0-0.9-0.22-1.34-0.66c-0.14,0.84-0.37,1.25-0.68,1.21
				c-0.78-0.1-1.54-0.46-2.27-1.08c-0.38,0.35-0.79,0.52-1.21,0.52h-0.58v-1.08h0.41c0.69,0,1.17-0.21,1.42-0.62
				c0.38-0.62,0.58-0.96,0.62-1.01c0.32-0.45,0.6-0.68,0.84-0.68c0.22,0,0.49,0.2,0.79,0.61c0.47,0.62,0.76,0.99,0.89,1.11
				c0.42,0.39,0.85,0.59,1.3,0.59h0.27V208.85z M463.34,206.96c-0.18-0.32-0.34-0.48-0.46-0.48c-0.24,0-0.5,0.35-0.77,1.06
				c0.24,0.23,0.54,0.43,0.91,0.6c0.2,0.09,0.36,0.14,0.47,0.14c0.15,0,0.23-0.09,0.23-0.26
				C463.72,207.76,463.59,207.4,463.34,206.96z" />
                                <path d="M473.34,206.92c0,0.52-0.14,0.97-0.41,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C473.16,205.74,473.34,206.28,473.34,206.92z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M506.97,483.5c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C506.68,481.81,506.97,482.62,506.97,483.5z M504.36,479.95l-0.71,0.93l-0.95-0.64l0.7-0.95L504.36,479.95z" />
                                <path d="M511.04,485.69h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V485.69z" />
                                <path d="M516.27,477.14l-0.15,1.14c-0.84,0.32-1.73,0.71-2.66,1.17c-0.86,0.42-1.45,0.75-1.77,0.98
				c0.55,0.45,0.95,0.82,1.19,1.11c0.53,0.64,0.8,1.27,0.8,1.9c0,1.5-0.92,2.26-2.75,2.26h-0.49v-1.08h0.84
				c1.05,0,1.58-0.34,1.58-1.01c0-0.57-0.7-1.44-2.09-2.61c0.03-0.6,0.11-0.95,0.25-1.04C512.5,478.89,514.25,477.96,516.27,477.14z
				 M516.21,475.62l-0.06,0.75c-0.65,0.26-1.5,0.67-2.55,1.24l-2.59,1.39l0.08-0.64C513.14,477.19,514.85,476.28,516.21,475.62z" />
                                <path d="M523.09,485.69h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V485.69z M520.94,481.01
				l-0.71,0.93l-0.95-0.63l0.69-0.96L520.94,481.01z" />
                                <path d="M527.85,484.12c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C527.75,483.07,527.85,483.6,527.85,484.12z M526.97,483.89c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C526.9,484.3,526.97,484.16,526.97,483.89z" />
                                <path d="M534.82,485.69h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V485.69z" />
                                <path d="M540.14,484.51c0,1.06-0.33,1.59-0.98,1.59c-0.17,0-0.82-0.27-1.96-0.82c-0.49,0.27-1.08,0.41-1.8,0.41
				h-1.02v-1.08h1.65c-0.57-0.24-0.86-0.64-0.86-1.18c0-0.72,0.51-1.37,1.54-1.95l-0.39-0.28l0.44-1.03
				C539.01,481.82,540.14,483.27,540.14,484.51z M537.61,483.17c0-0.21-0.05-0.41-0.15-0.59c-0.12-0.22-0.28-0.33-0.47-0.33
				c-0.21,0-0.43,0.11-0.64,0.32c-0.21,0.21-0.32,0.43-0.32,0.64c0,0.19,0.13,0.39,0.39,0.58c0.23,0.17,0.43,0.25,0.6,0.25
				c0.17,0,0.32-0.11,0.44-0.32C537.56,483.54,537.61,483.36,537.61,483.17z M539.34,484.48c0-0.29-0.34-0.81-1.03-1.56
				c0.01,0.1,0.02,0.2,0.02,0.3c0,0.49-0.18,0.89-0.54,1.22c0.11,0.07,0.32,0.18,0.62,0.31c0.33,0.16,0.54,0.23,0.6,0.23
				C539.24,484.98,539.34,484.81,539.34,484.48z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M461.04,326.83c0,0.89-0.38,1.48-1.13,1.79c-0.32,0.13-0.91,0.21-1.78,0.25c-0.8,0.03-1.41-0.17-1.84-0.62
				l0.49-0.84c0.28,0.21,0.69,0.32,1.23,0.32c0.58,0,0.98-0.02,1.19-0.06c0.7-0.13,1.05-0.36,1.05-0.7c0-0.71-0.7-1.52-2.11-2.43
				l0.44-1.09c0.58,0.33,1.11,0.78,1.57,1.32C460.75,325.47,461.04,326.15,461.04,326.83z" />
                                <path d="M468.01,328.82h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V328.82z M465.86,324.14
				l-0.71,0.93l-0.95-0.63l0.69-0.95L465.86,324.14z" />
                                <path d="M470.36,326.95c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C470.12,325.61,470.36,326.24,470.36,326.95z M471.1,330.79l-0.63,0.81
				l-0.83-0.61l-0.59,0.73l-0.88-0.62l0.67-0.81l0.79,0.59l0.57-0.7L471.1,330.79z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M525.08,122.92c0,1.05-0.32,1.89-0.95,2.52c-0.63,0.63-1.48,0.94-2.53,0.94c-0.92,0-1.65-0.31-2.19-0.93
				c-0.48-0.55-0.72-1.21-0.72-1.97c0-0.67,0.2-1.3,0.6-1.9l0.66,0.24c-0.27,0.54-0.4,1.02-0.4,1.44c0,1.41,0.73,2.11,2.19,2.11
				c0.74,0,1.33-0.19,1.78-0.58c0.46-0.41,0.7-0.98,0.7-1.71c0-0.66-0.23-1.28-0.68-1.86l0.72-0.62
				C524.81,121.33,525.08,122.1,525.08,122.92z M522.63,119.59l-0.67,0.88l-0.89-0.6l0.65-0.89L522.63,119.59z" />
                                <path d="M528.91,124.98h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V124.98z" />
                                <path d="M535.62,123.17c0,0.49-0.13,0.91-0.39,1.24c-0.28,0.37-0.66,0.55-1.14,0.55c-0.63,0-1.07-0.23-1.32-0.7
				c-0.34,0.46-0.79,0.7-1.37,0.7c-0.62,0-1.02-0.23-1.19-0.7c-0.26,0.47-0.69,0.7-1.29,0.7h-0.44v-1.02h0.25
				c0.76,0,1.14-0.37,1.14-1.11v-0.16l0.67-0.24v0.18c0,0.89,0.29,1.33,0.88,1.33c0.68,0,1.02-0.37,1.02-1.12v-0.16l0.67-0.24v0.18
				c0,0.89,0.34,1.34,1.02,1.34c0.49,0,0.73-0.22,0.73-0.66c0-0.31-0.14-0.61-0.42-0.91l0.66-0.75
				C535.44,122.06,535.62,122.57,535.62,123.17z" />
                                <path d="M537.85,124.79l-0.69,0.19l-0.22-8.33l0.91-0.35V124.79z" />
                                <path d="M544.39,124.98h-0.42c-0.35,0-0.64-0.06-0.88-0.18c-0.1,0.85-0.63,1.68-1.58,2.49
				c-0.64,0.55-1.37,1.01-2.19,1.4l-0.64-0.53c0.92-0.53,1.7-1.07,2.35-1.61c0.82-0.69,1.23-1.26,1.23-1.7
				c0-0.33-0.21-0.78-0.62-1.35l0.68-0.79c0.34,0.49,0.55,0.76,0.62,0.83c0.28,0.28,0.62,0.43,1.01,0.43h0.43V124.98z" />
                                <path d="M550.71,122.12l-0.23,0.98c-0.81,0-1.49,0.17-2.05,0.5c-0.27,0.17-0.77,0.47-1.49,0.9
				c-0.56,0.32-1.3,0.49-2.19,0.49h-0.77v-1.02h0.81c0.62,0,1.13-0.07,1.55-0.21c0.27-0.09,0.64-0.26,1.11-0.52
				c0.49-0.28,0.86-0.46,1.09-0.55c-0.26-0.06-0.66-0.22-1.2-0.47c-0.5-0.23-0.82-0.34-0.96-0.34c-0.23,0-0.54,0.19-0.92,0.57
				l-0.58-0.33c0.16-0.27,0.37-0.53,0.63-0.78c0.31-0.29,0.57-0.44,0.79-0.44c0.32,0,0.72,0.11,1.2,0.34
				c0.77,0.36,1.22,0.56,1.35,0.61C549.43,122.04,550.05,122.14,550.71,122.12z M548.49,118.96l-0.67,0.88l-0.89-0.6l0.66-0.9
				L548.49,118.96z" />
                                <path d="M529.23,141.78h-1.57c-0.67,0-1.01,0.08-1.01,0.23c0,0.09,0.26,0.2,0.79,0.31
				c0.62,0.13,0.97,0.21,1.03,0.25c0.33,0.17,0.5,0.45,0.5,0.85c0,0.62-0.5,1.15-1.49,1.58c-0.82,0.36-1.58,0.54-2.29,0.54
				c-0.96,0-1.7-0.22-2.24-0.67c-0.57-0.48-0.85-1.19-0.85-2.13c0-0.68,0.2-1.39,0.59-2.13l0.75,0.25c-0.29,0.6-0.44,1.15-0.44,1.65
				c0,1.33,0.77,2,2.3,2c1.19,0,2.14-0.27,2.86-0.81c0.07-0.05,0.1-0.1,0.1-0.15c0-0.07-0.05-0.11-0.15-0.12
				c-0.9-0.14-1.51-0.28-1.82-0.42c-0.11-0.05-0.19-0.15-0.27-0.3c-0.07-0.15-0.11-0.29-0.11-0.42c0-1.01,0.89-1.51,2.67-1.51h0.65
				V141.78z" />
                                <path d="M531.02,138.82c0,0.93-0.09,1.6-0.27,2.02c-0.27,0.63-0.77,0.94-1.51,0.94h-0.44v-1.02h0.45
				c0.45,0,0.75-0.18,0.9-0.53c0.09-0.21,0.13-0.59,0.13-1.14c0-0.17,0-0.33-0.01-0.48l-0.16-5.05l0.9-0.46V138.82z" />
                                <path d="M534.84,141.78h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V141.78z" />
                                <path d="M540.55,141.78h-0.44c-0.42,0-0.84-0.21-1.26-0.62c-0.13,0.79-0.35,1.17-0.64,1.13
				c-0.73-0.09-1.44-0.43-2.13-1.01c-0.36,0.33-0.74,0.49-1.13,0.49h-0.55v-1.02h0.39c0.65,0,1.1-0.19,1.33-0.58
				c0.36-0.58,0.55-0.9,0.58-0.95c0.3-0.42,0.56-0.64,0.79-0.64c0.21,0,0.46,0.19,0.75,0.57c0.44,0.58,0.72,0.93,0.84,1.04
				c0.39,0.37,0.8,0.56,1.22,0.56h0.25V141.78z M537.86,140.01c-0.17-0.3-0.32-0.45-0.43-0.45c-0.22,0-0.46,0.33-0.72,1
				c0.22,0.22,0.51,0.41,0.85,0.57c0.19,0.09,0.34,0.13,0.44,0.13c0.15,0,0.22-0.08,0.22-0.25
				C538.21,140.75,538.1,140.42,537.86,140.01z" />
                                <path d="M547.26,139.97c0,0.49-0.13,0.91-0.39,1.24c-0.28,0.37-0.66,0.55-1.14,0.55c-0.63,0-1.07-0.23-1.32-0.7
				c-0.34,0.46-0.79,0.7-1.37,0.7c-0.62,0-1.02-0.23-1.19-0.7c-0.26,0.47-0.69,0.7-1.29,0.7h-0.44v-1.02h0.25
				c0.76,0,1.14-0.37,1.14-1.11v-0.16l0.67-0.24v0.18c0,0.89,0.29,1.33,0.88,1.33c0.68,0,1.02-0.37,1.02-1.12v-0.16l0.67-0.24v0.18
				c0,0.89,0.34,1.34,1.02,1.34c0.49,0,0.73-0.22,0.73-0.66c0-0.31-0.14-0.61-0.42-0.91l0.66-0.75
				C547.09,138.86,547.26,139.37,547.26,139.97z M545.78,136.34l-0.53,0.69l-0.76-0.56l-0.53,0.66l-0.74-0.53l0.56-0.69l0.72,0.54
				l0.51-0.64L545.78,136.34z M544.89,135.13l-0.49,0.65l-0.75-0.55l0.51-0.64L544.89,135.13z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M382.62,279.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C382.32,277.32,382.62,278.13,382.62,279.01z M380.01,275.46l-0.71,0.93l-0.95-0.64l0.7-0.95L380.01,275.46z" />
                                <path d="M386.69,281.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V281.2z" />
                                <path d="M392.45,281.2h-0.49c-0.45,0-0.85,0.08-1.19,0.25c-0.43,0.21-0.65,0.52-0.65,0.93
				c0,0.41,0.23,0.74,0.69,0.97l-0.32,0.99c-1.59-0.5-2.59-1.55-2.98-3.14h-1.27v-1.08h1.16c0-0.86,0.21-1.69,0.63-2.5
				c0.37-0.71,0.7-1.07,0.98-1.07c0.22,0,0.49,0.24,0.79,0.72c0.33,0.51,0.49,1.03,0.49,1.54c0,0.59-0.16,1.11-0.47,1.58
				c-0.36,0.53-0.82,0.79-1.38,0.79c0.15,0.56,0.49,1.03,1.04,1.42c-0.03-0.11-0.04-0.23-0.04-0.35c0-0.59,0.23-1.09,0.69-1.52
				c0.45-0.41,0.96-0.62,1.56-0.62h0.76V281.2z M389.53,279.07c0-0.33-0.08-0.63-0.24-0.88c-0.13-0.21-0.25-0.31-0.35-0.31
				c-0.1,0-0.24,0.19-0.4,0.58c-0.2,0.48-0.31,1-0.31,1.57c0.36,0.03,0.66-0.03,0.9-0.18C389.4,279.68,389.53,279.42,389.53,279.07z" />
                                <path d="M396.63,281.2h-0.37c-0.85,0-1.54-0.22-2.07-0.66c-0.68,0.44-1.31,0.66-1.89,0.66h-0.31v-1.08h0.43
				c0.38,0,0.7-0.09,0.97-0.27c-0.3-0.3-0.44-0.73-0.44-1.28c0-0.42,0.2-0.85,0.59-1.29c0.39-0.44,0.8-0.67,1.21-0.67
				c0.36,0,0.67,0.2,0.92,0.6c0.22,0.35,0.33,0.71,0.33,1.1c0,0.69-0.29,1.23-0.87,1.63c0.29,0.13,0.68,0.19,1.16,0.19h0.34V281.2z
				 M395.29,274.43l-0.72,0.94l-0.94-0.64l0.7-0.95L395.29,274.43z M395.2,278.59c0-0.18-0.06-0.37-0.18-0.57
				c-0.13-0.22-0.28-0.33-0.45-0.33c-0.18,0-0.37,0.09-0.57,0.28c-0.2,0.19-0.3,0.37-0.3,0.54c0,0.17,0.07,0.35,0.21,0.55
				c0.15,0.22,0.3,0.33,0.45,0.33c0.14,0,0.32-0.1,0.53-0.3C395.1,278.9,395.2,278.73,395.2,278.59z" />
                                <path d="M405.58,278.47c0,0.96-0.43,1.68-1.3,2.16c-0.7,0.38-1.57,0.58-2.61,0.58h-1.96c-0.46,0-0.8-0.03-1.02-0.1
				c-0.32-0.1-0.58-0.31-0.77-0.62c-0.32,0.49-0.74,0.73-1.27,0.73h-0.47v-1.08h0.33c0.71,0,1.06-0.38,1.06-1.13v-0.28l0.82-0.29
				v0.18c0,1.02,0.29,1.53,0.88,1.53c0.32,0,0.57-0.12,0.76-0.36c0.12-0.15,0.33-0.42,0.64-0.81c0.35-0.43,0.8-0.84,1.34-1.23
				c0.72-0.52,1.37-0.78,1.96-0.78c0.43,0,0.81,0.15,1.13,0.44C405.42,277.68,405.58,278.04,405.58,278.47z M404.66,278.83
				c0-0.27-0.12-0.48-0.37-0.64c-0.2-0.13-0.45-0.19-0.74-0.19c-0.67,0-1.66,0.7-2.96,2.11h1.17c1,0,1.77-0.15,2.29-0.46
				C404.45,279.42,404.66,279.15,404.66,278.83z" />
                                <path d="M407.97,281l-0.73,0.2l-0.23-8.86l0.97-0.37V281z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M421.5,434.9c0,0.54-0.13,0.98-0.38,1.34c-0.29,0.41-0.69,0.61-1.2,0.61c-0.63,0-1.09-0.25-1.36-0.75
				c-0.29,0.5-0.74,0.75-1.35,0.75c-0.44,0-0.77-0.12-1.01-0.37c0,0.11,0,0.22,0,0.33c0,1.13-0.35,2.04-1.07,2.71
				c-0.71,0.67-1.64,1.01-2.78,1.01c-0.96,0-1.72-0.28-2.3-0.84c-0.58-0.56-0.87-1.32-0.87-2.27c0-0.76,0.22-1.51,0.66-2.25
				l0.72,0.27c-0.13,0.2-0.24,0.48-0.35,0.85c-0.1,0.37-0.16,0.67-0.16,0.91c0,1.51,0.82,2.26,2.47,2.26c0.77,0,1.42-0.19,1.95-0.57
				c0.6-0.43,0.9-1.01,0.9-1.75c0-0.74-0.23-1.47-0.7-2.21l0.85-0.73c0.25,0.51,0.46,0.86,0.63,1.06c0.28,0.34,0.61,0.5,0.98,0.5
				c0.41,0,0.69-0.1,0.85-0.3c0.14-0.17,0.21-0.47,0.21-0.89v-0.18l0.71-0.26v0.12c0,1,0.35,1.51,1.05,1.51
				c0.48,0,0.73-0.25,0.73-0.75c0-0.2-0.14-0.51-0.43-0.92l0.7-0.8C421.32,433.76,421.5,434.29,421.5,434.9z" />
                                <path d="M427,435.37c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C426.75,433.85,427,434.6,427,435.37z" />
                                <path d="M431.08,436.86h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V436.86z" />
                                <path d="M434.49,434.32c0,1.7-0.87,2.54-2.61,2.54h-1.26v-1.08h1.14c0.29,0,0.64-0.06,1.07-0.18
				c0.55-0.15,0.82-0.33,0.82-0.55v-0.48c-0.32,0.19-0.67,0.28-1.08,0.28c-0.35,0-0.63-0.1-0.84-0.31c-0.21-0.2-0.31-0.48-0.31-0.83
				c0-0.41,0.13-0.88,0.38-1.4c0.32-0.66,0.69-1,1.14-1c0.48,0,0.88,0.4,1.19,1.2C434.37,433.15,434.49,433.75,434.49,434.32z
				 M433.54,429.4l-0.71,0.93l-0.95-0.63l0.69-0.96L433.54,429.4z M433.47,433.63c-0.15-0.82-0.38-1.23-0.71-1.23
				c-0.15,0-0.29,0.12-0.43,0.36c-0.13,0.21-0.2,0.4-0.2,0.56c0,0.37,0.19,0.56,0.58,0.56C433.03,433.88,433.28,433.8,433.47,433.63z
				" />
                            </g>
                            <g class="map-province-names">
                                <path d="M277.1,336.58c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C276.81,334.88,277.1,335.7,277.1,336.58z M274.49,333.03l-0.71,0.93l-0.95-0.64l0.7-0.95L274.49,333.03z" />
                                <path d="M281.18,338.77h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V338.77z" />
                                <path d="M285.17,338.77h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V338.77z M284.38,333.44l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L284.38,333.44z" />
                                <path d="M292.3,336.84c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C292.12,335.66,292.3,336.2,292.3,336.84z" />
                                <path d="M297.79,337.29c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C297.53,335.76,297.79,336.52,297.79,337.29z M296.98,332.96l-0.72,0.94l-0.95-0.64l0.69-0.96L296.98,332.96z" />
                                <path d="M304.03,338.77h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V338.77z M301.89,337.67
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C301.48,337.77,301.73,337.74,301.89,337.67z" />
                                <path d="M310.74,335.72l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C309.38,335.64,310.04,335.74,310.74,335.72z M308.38,332.36l-0.71,0.93l-0.95-0.64l0.7-0.96
				L308.38,332.36z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M364.4,199.39c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C364.11,197.69,364.4,198.51,364.4,199.39z M361.79,195.84l-0.71,0.93l-0.95-0.64l0.7-0.95L361.79,195.84z" />
                                <path d="M366.8,201.37l-0.73,0.2l-0.23-8.86l0.97-0.37V201.37z" />
                                <path d="M373.76,201.58h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V201.58z" />
                                <path d="M379.52,201.58h-0.49c-0.45,0-0.85,0.09-1.19,0.25c-0.43,0.21-0.65,0.52-0.65,0.93
				c0,0.41,0.23,0.74,0.69,0.97l-0.32,0.99c-1.59-0.5-2.59-1.55-2.98-3.14h-1.27v-1.08h1.16c0-0.86,0.21-1.69,0.63-2.5
				c0.37-0.71,0.7-1.07,0.98-1.07c0.22,0,0.49,0.24,0.79,0.72c0.33,0.51,0.49,1.03,0.49,1.54c0,0.59-0.16,1.11-0.47,1.58
				c-0.36,0.53-0.82,0.79-1.38,0.79c0.15,0.56,0.49,1.03,1.04,1.42c-0.03-0.11-0.04-0.23-0.04-0.35c0-0.58,0.23-1.09,0.69-1.52
				c0.45-0.41,0.96-0.62,1.56-0.62h0.76V201.58z M376.61,199.45c0-0.34-0.08-0.63-0.24-0.88c-0.13-0.21-0.25-0.31-0.35-0.31
				c-0.1,0-0.24,0.19-0.4,0.58c-0.2,0.48-0.31,1-0.31,1.57c0.36,0.03,0.66-0.03,0.9-0.18C376.47,200.05,376.61,199.8,376.61,199.45z" />
                                <path d="M381.87,199.7c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C381.63,198.37,381.87,199,381.87,199.7z M382.37,195.8l-0.64,0.81l-0.82-0.61
				l-0.59,0.73l-0.88-0.62l0.66-0.82l0.79,0.59l0.57-0.7L382.37,195.8z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M360.3,228.23h-0.47c-0.55,0-1-0.11-1.35-0.32c0.09,0.2,0.14,0.44,0.14,0.73c0,0.36-0.07,0.68-0.21,0.98
				c-0.18,0.37-0.43,0.55-0.75,0.55c-1.1,0-1.64-0.78-1.64-2.34c0-0.17,0.01-0.33,0.03-0.48c-0.54,0-0.91,0.18-1.1,0.53
				c-0.14,0.25-0.2,0.68-0.2,1.27v5.36h-0.79l-0.09-5.99c-0.01-0.6,0.16-1.12,0.51-1.56c0.41-0.51,0.97-0.76,1.7-0.76l0.09-0.67
				l1.84,1.07c0.62,0.36,1.26,0.54,1.94,0.54h0.37V228.23z M357.73,227.98c-0.1-0.15-0.19-0.26-0.26-0.33
				c-0.16-0.15-0.42-0.32-0.77-0.5c-0.03,1.26,0.21,1.88,0.74,1.88c0.29,0,0.44-0.18,0.44-0.55
				C357.88,228.3,357.83,228.14,357.73,227.98z" />
                                <path d="M363.71,225.69c0,1.7-0.87,2.54-2.61,2.54h-1.26v-1.08h1.14c0.29,0,0.64-0.06,1.07-0.18
				c0.55-0.15,0.82-0.33,0.82-0.55v-0.48c-0.32,0.19-0.67,0.28-1.08,0.28c-0.35,0-0.63-0.1-0.84-0.31c-0.21-0.2-0.31-0.48-0.31-0.83
				c0-0.41,0.13-0.88,0.38-1.4c0.32-0.66,0.69-1,1.14-1c0.48,0,0.88,0.4,1.19,1.2C363.59,224.52,363.71,225.12,363.71,225.69z
				 M363.31,220.73l-0.63,0.81l-0.82-0.61l-0.59,0.73l-0.88-0.62l0.66-0.82l0.8,0.6l0.57-0.7L363.31,220.73z M362.68,225.01
				c-0.15-0.82-0.38-1.23-0.71-1.23c-0.15,0-0.29,0.12-0.43,0.36c-0.13,0.21-0.2,0.4-0.2,0.56c0,0.37,0.19,0.56,0.58,0.56
				C362.24,225.26,362.49,225.17,362.68,225.01z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M208.22,232.94c0,0.52-0.15,0.96-0.44,1.29c-0.31,0.36-0.72,0.54-1.24,0.54c-0.42,0-0.75-0.14-1-0.42
				c-0.25-0.28-0.38-0.63-0.38-1.05c0-0.37,0.06-0.71,0.19-1.03c0.06-0.15,0.25-0.51,0.58-1.08l-0.17-0.14l0.52-0.98
				C207.57,231.09,208.22,232.05,208.22,232.94z M207.44,232.95c0-0.25-0.13-0.53-0.39-0.84c-0.2-0.24-0.41-0.43-0.65-0.59
				c-0.37,0.7-0.55,1.15-0.55,1.35c0,0.56,0.25,0.84,0.76,0.84c0.22,0,0.42-0.07,0.58-0.21
				C207.36,233.34,207.44,233.16,207.44,232.95z" />
                                <path d="M212.29,234.62h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V234.62z" />
                                <path d="M221.09,234.62h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.32,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V234.62z M217.92,228.83l-0.56,0.73l-0.81-0.59l-0.56,0.69
				l-0.79-0.57l0.59-0.74l0.77,0.58l0.54-0.68L217.92,228.83z M216.97,227.54l-0.52,0.69l-0.79-0.58l0.54-0.69L216.97,227.54z" />
                                <path d="M223.43,232.75c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C223.18,231.41,223.43,232.04,223.43,232.75z M222.98,228.61l-0.71,0.94
				l-0.94-0.64l0.7-0.95L222.98,228.61z" />
                                <path d="M227.5,234.62h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V234.62z" />
                                <path d="M232.26,233.05c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C232.15,232,232.26,232.53,232.26,233.05z M231.37,232.81c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C231.31,233.22,231.37,233.09,231.37,232.81z" />
                                <path d="M239.22,234.62h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V234.62z" />
                                <path d="M244.64,225.67l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C240.55,227.61,242.39,226.63,244.64,225.67z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M230.04,189.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C229.74,187.31,230.04,188.13,230.04,189.01z M227.42,185.46l-0.71,0.93l-0.95-0.64l0.7-0.95L227.42,185.46z" />
                                <path d="M234.11,191.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V191.2z" />
                                <path d="M238.1,191.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V191.2z M237.32,185.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L237.32,185.87z" />
                                <path d="M245.24,189.27c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C245.05,188.09,245.24,188.63,245.24,189.27z" />
                                <path d="M251.36,189.21c0,0.89-0.38,1.48-1.13,1.79c-0.32,0.13-0.91,0.21-1.78,0.25c-0.8,0.03-1.41-0.17-1.84-0.62
				l0.49-0.84c0.28,0.21,0.69,0.32,1.23,0.32c0.58,0,0.98-0.02,1.19-0.06c0.7-0.13,1.05-0.36,1.05-0.7c0-0.71-0.7-1.52-2.11-2.43
				l0.44-1.09c0.58,0.33,1.11,0.78,1.57,1.32C251.07,187.85,251.36,188.53,251.36,189.21z" />
                                <path d="M258.33,191.2h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V191.2z" />
                                <path d="M263.75,182.25l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C259.66,184.19,261.5,183.21,263.75,182.25z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M275.52,155.84c0,1.05-0.32,1.89-0.95,2.52c-0.63,0.63-1.48,0.94-2.53,0.94c-0.92,0-1.65-0.31-2.19-0.93
				c-0.48-0.55-0.72-1.21-0.72-1.97c0-0.67,0.2-1.3,0.6-1.9l0.66,0.24c-0.27,0.54-0.4,1.02-0.4,1.44c0,1.41,0.73,2.11,2.19,2.11
				c0.74,0,1.33-0.19,1.78-0.58c0.46-0.41,0.7-0.98,0.7-1.71c0-0.66-0.23-1.28-0.68-1.86l0.72-0.62
				C275.25,154.24,275.52,155.01,275.52,155.84z M273.07,152.5l-0.67,0.88l-0.89-0.6l0.65-0.89L273.07,152.5z" />
                                <path d="M279.35,157.89h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V157.89z" />
                                <path d="M286.86,157.89h-1.08c-0.62,0-1.06-0.21-1.33-0.62c-0.08-0.12-0.2-0.46-0.36-1.01l-2.08,1.08
				c-0.71,0.37-1.46,0.55-2.26,0.55h-0.83v-1.01h0.81c0.8,0,1.49-0.13,2.09-0.41c0.35-0.16,0.97-0.46,1.87-0.88
				c-0.39-0.08-0.88-0.25-1.45-0.52c-0.53-0.24-0.86-0.36-0.98-0.36c-0.27,0-0.54,0.18-0.81,0.55l-0.62-0.33
				c0.46-0.85,0.9-1.27,1.35-1.27c0.31,0,0.7,0.11,1.18,0.32c0.74,0.33,1.21,0.53,1.39,0.6c0.63,0.21,1.27,0.32,1.93,0.32
				c0.14,0,0.27,0,0.41,0l-0.23,0.96c-0.54,0-0.97,0.08-1.28,0.23c0.09,0.33,0.27,0.55,0.56,0.67c0.2,0.08,0.49,0.12,0.9,0.12h0.83
				V157.89z M283.87,159.44l-0.67,0.88l-0.89-0.59l0.66-0.9L283.87,159.44z" />
                                <path d="M289.07,156.13c0,1.17-0.68,1.76-2.04,1.76h-0.58v-1.02h0.64c0.79,0,1.18-0.21,1.18-0.64
				c0-0.23-0.12-0.49-0.35-0.79l-0.23-0.3l0.7-0.77C288.84,154.88,289.07,155.47,289.07,156.13z M288.64,152.25l-0.67,0.88
				l-0.89-0.61l0.65-0.89L288.64,152.25z" />
                                <path d="M294.23,156.5c0,0.81-0.47,1.64-1.42,2.49c-0.67,0.6-1.4,1.09-2.19,1.46l-0.71-0.54
				c0.9-0.5,1.67-1.03,2.32-1.59c0.79-0.68,1.18-1.25,1.18-1.69c0-0.44-0.21-0.95-0.62-1.54l0.72-0.72
				C293.99,155.07,294.23,155.77,294.23,156.5z M293.47,152.43l-0.68,0.88l-0.89-0.6l0.65-0.9L293.47,152.43z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M314.57,139.66c-0.54,0.79-1.21,1.26-2.01,1.41c-0.8,0.15-1.6-0.05-2.39-0.59
				c-0.69-0.47-1.08-1.08-1.18-1.83c-0.08-0.67,0.07-1.28,0.46-1.86c0.34-0.5,0.82-0.88,1.43-1.12l0.38,0.52
				c-0.48,0.27-0.83,0.56-1.04,0.88c-0.72,1.06-0.54,1.97,0.56,2.72c0.56,0.38,1.1,0.54,1.64,0.48c0.56-0.07,1.03-0.38,1.4-0.93
				c0.34-0.5,0.49-1.08,0.45-1.75l0.86-0.09C315.18,138.32,315,139.04,314.57,139.66z M314.44,135.89l-0.95,0.32l-0.36-0.91
				l0.95-0.34L314.44,135.89z" />
                                <path d="M320.27,145.82l-0.34-0.23c-0.47-0.32-0.67-0.82-0.62-1.51c0.04-0.52,0.22-1.07,0.52-1.65
				c-1.26,1.11-2.81,1.22-4.66,0.33l0.06-0.74c0.62,0.25,1.26,0.41,1.91,0.47c0.71,0.07,1.2-0.01,1.47-0.23
				c0.03-0.03,0.07-0.06,0.09-0.1c0.31-0.45,0.27-1.36-0.1-2.72c-0.3-1.08-0.65-1.98-1.05-2.69l0.75-0.77
				c0.5,1.06,0.86,2.14,1.08,3.23c0.25,1.23,0.25,2.17,0,2.81c0.56-0.47,1.18-1.21,1.86-2.21c0.4-0.59,0.77-1.18,1.1-1.77l0.86,0.21
				l-1.86,2.73c-0.62,0.91-1.03,1.7-1.21,2.34c-0.2,0.72-0.06,1.24,0.41,1.56l0.25,0.17L320.27,145.82z" />
                                <path d="M321.61,148.78l-0.84,0.27l-0.29-0.83l-0.77,0.23l-0.32-0.87l0.87-0.25l0.28,0.8l0.74-0.22L321.61,148.78z
				 M323.09,147.75l-0.44-0.3c-0.6-0.41-0.85-0.89-0.75-1.44c-0.23,0.13-0.48,0.18-0.76,0.16c-0.28-0.03-0.53-0.11-0.75-0.26
				l-0.44-0.3l0.52-0.77l0.4,0.27c0.26,0.18,0.51,0.26,0.77,0.26c0.29,0,0.52-0.12,0.69-0.37l0.22-0.33l0.62,0.22
				c-0.34,0.5-0.48,0.9-0.42,1.19c0.04,0.23,0.23,0.45,0.56,0.68l0.31,0.21L323.09,147.75z" />
                                <path d="M330.93,144.21l-0.65,0.74c-0.75-0.18-1.57-0.33-2.45-0.46c-0.82-0.12-1.39-0.17-1.72-0.16
				c0.17,0.58,0.27,1.04,0.31,1.37c0.07,0.71-0.05,1.29-0.35,1.73c-0.73,1.07-1.74,1.16-3.04,0.27l-0.34-0.24l0.52-0.77l0.59,0.4
				c0.75,0.51,1.28,0.52,1.61,0.04c0.28-0.41,0.21-1.36-0.22-2.86c0.31-0.41,0.54-0.62,0.68-0.62
				C327.42,143.63,329.11,143.82,330.93,144.21z M331.62,143.11l-0.4,0.5c-0.58-0.13-1.38-0.25-2.41-0.36l-2.5-0.27l0.37-0.42
				C328.69,142.74,330.34,142.92,331.62,143.11z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M265.85,268.88c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C265.56,267.18,265.85,268,265.85,268.88z M263.24,265.33l-0.71,0.93l-0.95-0.64l0.7-0.95L263.24,265.33z" />
                                <path d="M269.93,271.07h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V271.07z" />
                                <path d="M273.91,271.07h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V271.07z M273.13,265.74l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L273.13,265.74z" />
                                <path d="M281.05,269.14c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C280.87,267.96,281.05,268.5,281.05,269.14z" />
                                <path d="M288.01,271.07h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V271.07z" />
                                <path d="M289.91,267.91c0,0.99-0.09,1.7-0.28,2.15c-0.29,0.67-0.82,1-1.61,1h-0.47v-1.08h0.48
				c0.48,0,0.8-0.19,0.95-0.56c0.09-0.22,0.14-0.63,0.14-1.21c0-0.18,0-0.35-0.01-0.51l-0.17-5.38l0.96-0.5V267.91z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M315.27,245.78l-0.36,0.96c-0.23-0.1-0.51-0.15-0.82-0.15c-0.47,0-0.95,0.16-1.45,0.47
				c-0.53,0.34-0.85,0.72-0.95,1.16c-0.01,0.04-0.01,0.09-0.01,0.14c0,0.23,0.28,0.38,0.85,0.46c0.37,0.02,0.75,0.05,1.12,0.08
				c0.88,0.1,1.32,0.51,1.32,1.23c0,0.73-0.54,1.42-1.63,2.06c-1.04,0.61-2.08,0.92-3.11,0.92c-1.01,0-1.8-0.23-2.39-0.68
				c-0.65-0.5-0.97-1.24-0.97-2.23c0-0.84,0.22-1.62,0.66-2.32l0.71,0.31c-0.33,0.59-0.5,1.16-0.5,1.7c0,1.42,0.88,2.12,2.64,2.12
				c0.6,0,1.22-0.11,1.88-0.33c0.68-0.23,1.24-0.53,1.68-0.9c0.21-0.18,0.32-0.34,0.32-0.47c0-0.18-0.16-0.29-0.47-0.33
				c-1.32-0.16-2.07-0.27-2.25-0.33c-0.41-0.15-0.61-0.5-0.61-1.06c0-0.77,0.37-1.49,1.11-2.15c0.72-0.64,1.47-0.96,2.25-0.96
				C314.67,245.48,315,245.58,315.27,245.78z" />
                                <path d="M322.23,250.59h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V250.59z M320.08,245.9
				l-0.71,0.93l-0.95-0.63l0.69-0.96L320.08,245.9z" />
                                <path d="M327.64,241.63l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C323.55,243.58,325.4,242.6,327.64,241.63z" />
                                <path d="M334.46,250.59h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V250.59z" />
                                <path d="M339.23,249.01c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.64,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C339.12,247.96,339.23,248.49,339.23,249.01z M338.34,248.78c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C338.28,249.19,338.34,249.05,338.34,248.78z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M275.48,223.51l0.2,1.16l-1.11,0.26l-0.22-1.16L275.48,223.51z M279.85,224.03
				c0.82,0.77,1.24,1.62,1.27,2.57c0.03,0.95-0.34,1.83-1.1,2.65c-0.67,0.71-1.44,1.06-2.32,1.03c-0.78-0.03-1.47-0.31-2.06-0.87
				c-0.52-0.49-0.87-1.1-1.04-1.85l0.67-0.34c0.23,0.6,0.5,1.06,0.82,1.36c1.1,1.02,2.17,0.97,3.23-0.17
				c0.54-0.57,0.82-1.18,0.84-1.8c0.02-0.66-0.26-1.25-0.82-1.79c-0.51-0.48-1.16-0.75-1.94-0.83l0.05-1.01
				C278.41,223.09,279.21,223.43,279.85,224.03z" />
                                <path d="M282.94,223.64l-0.35,0.68l-6.63-5.88l0.39-0.96L282.94,223.64z" />
                                <path d="M288.51,217.97l-0.32,0.35c-0.25,0.27-0.47,0.43-0.68,0.5c-0.33,0.11-0.78,0.08-1.34-0.08
				c0.24,0.54,0.27,1.05,0.12,1.53c-0.12,0.37-0.4,0.79-0.85,1.27c-0.59,0.63-1.14,0.95-1.65,0.98l-0.33-0.99
				c0.36-0.08,0.72-0.3,1.07-0.68c1.04-1.11,1.31-1.89,0.82-2.35c-0.08-0.07-0.18-0.14-0.29-0.2l-2.72-1.31l-0.09-1.03l3.03,1.53
				c1,0.51,1.71,0.54,2.12,0.1l0.32-0.35L288.51,217.97z" />
                                <path d="M292.67,213.52l-0.32,0.34c-0.31,0.33-0.77,0.51-1.39,0.53c0.52,0.68,0.66,1.12,0.42,1.32
				c-0.6,0.5-1.38,0.81-2.34,0.92c-0.01,0.52-0.15,0.93-0.44,1.24l-0.4,0.43l-0.79-0.74l0.28-0.3c0.47-0.51,0.64-0.99,0.52-1.46
				c-0.2-0.7-0.3-1.08-0.31-1.14c-0.11-0.54-0.09-0.9,0.08-1.08c0.15-0.16,0.48-0.22,0.98-0.17c0.77,0.08,1.24,0.12,1.42,0.1
				c0.57-0.04,1.01-0.22,1.32-0.55l0.18-0.2L292.67,213.52z M289.34,214.33c-0.36-0.08-0.58-0.08-0.67,0.01
				c-0.16,0.17-0.08,0.6,0.25,1.29c0.33-0.01,0.69-0.1,1.06-0.25c0.21-0.09,0.35-0.17,0.42-0.25c0.11-0.11,0.1-0.23-0.03-0.35
				C290.17,214.59,289.83,214.44,289.34,214.33z" />
                                <path d="M295.44,208.84c0.78,0.72,0.94,1.33,0.49,1.81c-0.11,0.12-0.76,0.41-1.94,0.87
				c-0.13,0.54-0.44,1.07-0.93,1.59l-0.7,0.74l-0.79-0.74l1.13-1.21c-0.57,0.25-1.05,0.19-1.45-0.18c-0.53-0.49-0.65-1.31-0.38-2.46
				l-0.47,0.09l-0.45-1.02C292.7,207.82,294.53,207.99,295.44,208.84z M292.73,209.76c-0.15-0.14-0.33-0.24-0.54-0.29
				c-0.25-0.06-0.43-0.03-0.56,0.11c-0.15,0.16-0.21,0.38-0.2,0.69c0.01,0.3,0.09,0.53,0.25,0.67c0.14,0.13,0.37,0.17,0.69,0.11
				c0.28-0.05,0.48-0.14,0.59-0.26c0.12-0.13,0.14-0.31,0.06-0.54C292.97,210.06,292.87,209.89,292.73,209.76z M294.87,209.39
				c-0.21-0.2-0.83-0.31-1.84-0.32c0.08,0.06,0.16,0.12,0.23,0.19c0.35,0.33,0.53,0.74,0.53,1.23c0.13-0.03,0.35-0.11,0.65-0.24
				c0.34-0.14,0.54-0.23,0.58-0.28C295.16,209.81,295.12,209.62,294.87,209.39z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M390.54,172.82c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C390.25,171.12,390.54,171.94,390.54,172.82z M387.93,169.27l-0.71,0.93l-0.95-0.64l0.7-0.95L387.93,169.27z" />
                                <path d="M392.93,174.81l-0.73,0.2l-0.23-8.86l0.97-0.37V174.81z" />
                                <path d="M398.43,173.53c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C398.17,172,398.43,172.75,398.43,173.53z" />
                                <path d="M400.82,174.81l-0.73,0.2l-0.23-8.86l0.97-0.37V174.81z" />
                                <path d="M408.77,175.01h-0.47c-0.36,0-0.64-0.05-0.83-0.15c-0.31-0.17-0.59-0.51-0.85-1.03
				c-0.24,0.54-0.58,0.92-1.03,1.13c-0.35,0.17-0.86,0.25-1.51,0.25c-0.86,0-1.47-0.18-1.84-0.54l0.5-0.92
				c0.31,0.21,0.71,0.32,1.22,0.32c1.52,0,2.28-0.34,2.28-1.01c0-0.11-0.02-0.22-0.06-0.35l-0.9-2.88l0.69-0.77l0.95,3.26
				c0.31,1.08,0.77,1.62,1.38,1.62h0.47V175.01z" />
                                <path d="M411.11,173.14c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C410.87,171.8,411.11,172.43,411.11,173.14z M410.66,169l-0.71,0.94L409,169.3
				l0.7-0.95L410.66,169z" />
                                <path d="M416.61,173.53c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C416.35,172,416.61,172.75,416.61,173.53z M415.8,169.2l-0.72,0.94l-0.95-0.64l0.69-0.96L415.8,169.2z" />
                                <path d="M420.69,175.01h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V175.01z" />
                                <path d="M425.45,173.44c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C425.34,172.39,425.45,172.92,425.45,173.44z M424.56,173.21c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C424.5,173.61,424.56,173.48,424.56,173.21z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M226.32,275.88c-0.14,0.19-0.4,0.37-0.79,0.55c-0.42,0.19-0.72,0.22-0.89,0.1
				c-0.19-0.13-0.45-0.35-0.81-0.64c-0.35-0.29-0.62-0.51-0.81-0.64c-0.39-0.28-0.73-0.34-1.04-0.18c-0.21,0.11-0.49,0.41-0.83,0.88
				l-3.02,4.2l-0.66-0.48l2.95-4.23c0.89-1.28,1.79-1.75,2.7-1.41c0.3-0.42,0.65-0.76,1.04-1.02c0.53-0.36,0.97-0.41,1.32-0.15
				c0.35,0.25,0.63,0.73,0.85,1.42C226.56,275.01,226.56,275.54,226.32,275.88z M225.4,275.4c0.08-0.12,0.09-0.36,0.01-0.73
				c-0.09-0.43-0.24-0.72-0.44-0.86c-0.14-0.1-0.32-0.1-0.53,0.01c-0.17,0.09-0.31,0.22-0.43,0.37c-0.05,0.08-0.1,0.16-0.14,0.25
				c0.1,0.08,0.27,0.22,0.51,0.43c0.21,0.19,0.38,0.33,0.5,0.41C225.14,275.48,225.32,275.51,225.4,275.4z" />
                                <path d="M232.69,283.35l-0.39-0.28c-0.54-0.38-0.76-0.98-0.68-1.78c0.07-0.61,0.28-1.24,0.65-1.91
				c-1.5,1.26-3.31,1.34-5.44,0.25l0.09-0.86c0.72,0.31,1.46,0.51,2.22,0.61c0.82,0.1,1.4,0.02,1.72-0.23
				c0.04-0.03,0.08-0.07,0.11-0.12c0.37-0.52,0.36-1.58-0.04-3.17c-0.32-1.27-0.71-2.33-1.15-3.17l0.9-0.88
				c0.55,1.25,0.94,2.52,1.17,3.8c0.26,1.45,0.23,2.54-0.08,3.28c0.66-0.53,1.41-1.38,2.23-2.53c0.48-0.67,0.93-1.35,1.33-2.04
				l1,0.27l-2.25,3.14c-0.75,1.05-1.24,1.95-1.47,2.7c-0.25,0.83-0.11,1.45,0.43,1.83l0.28,0.2L232.69,283.35z" />
                                <path d="M234.04,286.74l-0.99,0.29l-0.32-0.98l-0.9,0.25l-0.35-1.02l1.02-0.27l0.3,0.94l0.87-0.23L234.04,286.74z
				 M235.68,283.19c-0.73,1.01-1.68,1.1-2.86,0.25l-0.5-0.36l0.63-0.88l0.55,0.39c0.68,0.49,1.15,0.55,1.42,0.18
				c0.14-0.2,0.21-0.5,0.19-0.9l-0.01-0.41l1.09-0.23C236.26,281.96,236.09,282.61,235.68,283.19z" />
                                <path d="M237.11,286.27l-0.72-0.26l4.98-7.34l1,0.26L237.11,286.27z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M321.81,187.49l-0.32,0.28c-0.26,0.22-0.55,0.32-0.88,0.29c0.07,0.08,0.14,0.16,0.21,0.24
				c0.7,0.82,1,1.69,0.91,2.62c-0.09,0.93-0.56,1.75-1.38,2.45c-0.69,0.59-1.42,0.86-2.19,0.82c-0.77-0.05-1.45-0.41-2.04-1.1
				c-0.47-0.55-0.78-1.23-0.92-2.03l0.68-0.25c0.1,0.6,0.35,1.12,0.74,1.57c0.94,1.09,2,1.13,3.18,0.11
				c0.54-0.47,0.89-1.01,1.05-1.62c0.17-0.69,0.03-1.3-0.42-1.82c-0.45-0.53-1.08-0.92-1.87-1.16l0.16-1.06
				c0.52,0.22,0.89,0.36,1.1,0.39c0.41,0.07,0.75-0.01,1.03-0.25l0.29-0.25L321.81,187.49z M316.58,187.41l0.07,1.12l-1.08,0.13
				l-0.09-1.12L316.58,187.41z" />
                                <path d="M322.37,184.54c0.81,0.95,0.67,1.89-0.43,2.84l-0.47,0.4l-0.71-0.82l0.51-0.44
				c0.64-0.55,0.81-0.99,0.51-1.33c-0.16-0.18-0.44-0.32-0.83-0.4l-0.4-0.08l0.03-1.11C321.32,183.68,321.91,184,322.37,184.54z
				 M325.44,186.98l0.04,1.03l-1.03,0.08l0.03,0.94l-1.07,0.1l-0.02-1.05l0.98-0.07l-0.02-0.9L325.44,186.98z" />
                                <path d="M326.86,181.03c0.67,0.78,1.02,1.72,1.05,2.82c0.03,0.99-0.2,1.97-0.69,2.97l-1.02-0.13
				c0.4-1.05,0.64-1.85,0.72-2.42c0.13-0.88,0-1.64-0.39-2.27c-0.1,0.33-0.3,0.63-0.62,0.9c-0.31,0.26-0.62,0.4-0.93,0.41
				c-0.35,0.01-0.65-0.14-0.91-0.44c-0.34-0.4-0.56-0.87-0.66-1.42c-0.11-0.61-0.01-1.05,0.32-1.33c0.44-0.38,0.99-0.42,1.67-0.14
				C325.95,180.18,326.44,180.54,326.86,181.03z M325.76,181.35c-0.52-0.55-0.97-0.66-1.35-0.34c-0.13,0.11-0.19,0.28-0.17,0.49
				c0.02,0.22,0.09,0.39,0.21,0.53c0.25,0.29,0.55,0.28,0.91-0.03C325.56,181.84,325.69,181.62,325.76,181.35z" />
                                <path d="M328.53,175.56l0.07,1.17l-1.13,0.14l-0.1-1.18L328.53,175.56z M333.21,177.72l-0.34,0.29
				c-0.28,0.24-0.56,0.39-0.84,0.46c0.5,0.76,0.65,1.79,0.45,3.1c-0.14,0.88-0.4,1.77-0.8,2.65l-0.89,0.01
				c0.37-1.06,0.63-2.04,0.78-2.93c0.18-1.13,0.12-1.87-0.18-2.22c-0.23-0.27-0.71-0.49-1.43-0.67l0.01-1.11
				c0.61,0.16,0.97,0.24,1.07,0.25c0.43,0.03,0.8-0.08,1.11-0.36l0.35-0.3L333.21,177.72z" />
                                <path d="M330.61,170.06l0.05,1.02l-1.02,0.07l0.03,0.94l-1.07,0.1l-0.03-1.06l1-0.07l-0.02-0.9L330.61,170.06z
				 M334.15,173.56c1.1,1.29,0.99,2.5-0.33,3.63l-0.96,0.82l-0.71-0.82l0.86-0.74c0.22-0.19,0.45-0.46,0.69-0.84
				c0.32-0.47,0.41-0.79,0.27-0.95l-0.31-0.36c-0.12,0.35-0.33,0.66-0.63,0.92c-0.27,0.23-0.55,0.34-0.84,0.31
				c-0.29-0.02-0.55-0.16-0.78-0.43c-0.27-0.31-0.47-0.75-0.63-1.31c-0.19-0.71-0.12-1.21,0.21-1.5c0.36-0.31,0.92-0.27,1.68,0.13
				C333.29,172.75,333.78,173.13,334.15,173.56z M332.93,173.71c-0.64-0.53-1.09-0.69-1.34-0.47c-0.11,0.09-0.14,0.28-0.09,0.55
				c0.04,0.25,0.11,0.43,0.22,0.55c0.24,0.28,0.51,0.3,0.81,0.05C332.76,174.19,332.89,173.96,332.93,173.71z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M345.62,185l0.05,0.95l-0.91,0.11l-0.08-0.95L345.62,185z M348.38,187.22c0.45,0.53,0.61,1.33,0.47,2.41
				c-0.1,0.76-0.3,1.49-0.61,2.18l-0.76,0.04c0.31-0.82,0.52-1.6,0.62-2.32c0.13-0.89,0.07-1.47-0.17-1.76
				c-0.24-0.29-0.67-0.5-1.26-0.65l0.07-0.87C347.42,186.43,347.97,186.75,348.38,187.22z" />
                                <path d="M353.42,184.48l-0.27,0.23c-0.23,0.19-0.45,0.32-0.68,0.37c0.4,0.61,0.53,1.44,0.36,2.5
				c-0.11,0.71-0.32,1.42-0.64,2.13l-0.72,0.01c0.3-0.86,0.51-1.64,0.63-2.36c0.15-0.91,0.1-1.5-0.15-1.79
				c-0.18-0.21-0.57-0.39-1.16-0.54l0.01-0.89c0.49,0.12,0.78,0.19,0.86,0.2c0.34,0.03,0.64-0.07,0.9-0.29l0.28-0.24L353.42,184.48z" />
                                <path d="M355.85,182.39l-0.38,0.32c-0.52,0.45-1.02,0.55-1.49,0.33c0.06,0.24,0.05,0.48-0.04,0.73
				c-0.09,0.25-0.23,0.46-0.42,0.62l-0.38,0.33l-0.57-0.66l0.34-0.29c0.22-0.19,0.36-0.4,0.43-0.63c0.07-0.26,0.02-0.5-0.16-0.71
				l-0.24-0.28l0.35-0.51c0.37,0.43,0.7,0.65,0.98,0.67c0.22,0.02,0.47-0.1,0.75-0.35l0.27-0.23L355.85,182.39z M356.07,184.36
				l0.05,0.94l-0.9,0.11l-0.08-0.95L356.07,184.36z" />
                                <path d="M355.37,179.46c0.52,0.6,0.83,1.09,0.95,1.46c0.18,0.56,0.02,1.05-0.46,1.46l-0.28,0.24l-0.57-0.66
				l0.29-0.25c0.29-0.25,0.39-0.53,0.29-0.84c-0.06-0.18-0.24-0.46-0.55-0.81c-0.1-0.11-0.19-0.22-0.27-0.31l-2.92-3.2l0.33-0.81
				L355.37,179.46z" />
                                <path d="M358.37,180.02l-0.34,0.51l-4.79-5.3l0.4-0.73L358.37,180.02z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M359.56,435.68l-0.25-0.37c-0.21-0.3-0.33-0.6-0.37-0.88c-0.81,0.42-1.85,0.46-3.13,0.12
				c-0.86-0.23-1.71-0.59-2.55-1.07l0.08-0.88c1.02,0.48,1.96,0.84,2.83,1.09c1.1,0.3,1.85,0.32,2.23,0.05
				c0.29-0.2,0.56-0.65,0.81-1.36l1.1,0.12c-0.22,0.59-0.34,0.94-0.36,1.04c-0.08,0.42,0,0.8,0.24,1.14l0.26,0.38L359.56,435.68z" />
                                <path d="M362.83,440.43l-0.28-0.4c-0.26-0.37-0.55-0.65-0.88-0.83c-0.42-0.23-0.8-0.24-1.13-0.01
				c-0.34,0.23-0.47,0.61-0.41,1.12l-1,0.3c-0.49-1.59-0.19-3.01,0.89-4.24l-0.72-1.05l0.89-0.62l0.66,0.95
				c0.71-0.49,1.51-0.79,2.42-0.9c0.8-0.1,1.28-0.03,1.44,0.2c0.13,0.18,0.08,0.54-0.14,1.06c-0.24,0.56-0.57,0.99-0.99,1.28
				c-0.48,0.33-1.01,0.5-1.57,0.51c-0.64,0.01-1.12-0.22-1.43-0.68c-0.38,0.44-0.57,0.99-0.58,1.66c0.08-0.09,0.16-0.17,0.26-0.23
				c0.48-0.33,1.03-0.43,1.64-0.29c0.59,0.13,1.06,0.44,1.39,0.93l0.43,0.62L362.83,440.43z M362.93,436.81
				c0.28-0.19,0.47-0.42,0.59-0.7c0.1-0.23,0.12-0.38,0.06-0.46c-0.06-0.08-0.29-0.08-0.71,0c-0.51,0.1-1,0.32-1.47,0.64
				c0.18,0.32,0.4,0.53,0.66,0.63C362.35,437.05,362.64,437.01,362.93,436.81z" />
                                <path d="M368.47,445.21c-0.43,0.3-0.87,0.43-1.33,0.41c-0.49-0.02-0.89-0.25-1.18-0.66
				c-0.38-0.55-0.44-1.08-0.19-1.58c-0.61-0.01-1.09-0.27-1.44-0.78c-0.38-0.55-0.41-1.04-0.1-1.47c-0.57,0.05-1.04-0.18-1.4-0.71
				l-0.26-0.38l0.89-0.62l0.15,0.22c0.46,0.67,1.01,0.78,1.66,0.33l0.14-0.1l0.61,0.44l-0.15,0.11c-0.78,0.54-0.99,1.06-0.64,1.58
				c0.41,0.59,0.94,0.67,1.59,0.22l0.14-0.1l0.61,0.44l-0.16,0.11c-0.78,0.54-0.97,1.11-0.56,1.7c0.29,0.43,0.63,0.51,1.02,0.24
				c0.27-0.19,0.45-0.49,0.54-0.91l1.05,0.12C369.34,444.39,369,444.85,368.47,445.21z M370.76,441.73l-0.92-0.05l0.03-1l-0.89-0.06
				l0.02-0.97l0.94,0.07l-0.04,0.96l0.87,0.06L370.76,441.73z M371.29,440.21l-0.87-0.04l0.03-0.98l0.87,0.06L371.29,440.21z" />
                                <path d="M370.43,451.45l-0.67-0.97c-1.63,0.74-3.35,0.54-5.16-0.6l0.24-1c0.99,0.5,1.75,0.82,2.29,0.97
				c0.82,0.23,1.53,0.21,2.12-0.06c-0.17-0.17-0.33-0.37-0.48-0.58c-0.62-0.89-0.61-1.56,0.03-2c0.39-0.27,0.87-0.43,1.46-0.5
				c0.67-0.08,1.13,0.06,1.37,0.41c0.31,0.45,0.33,0.96,0.06,1.52c-0.2,0.43-0.54,0.85-1.02,1.25l0.65,0.94L370.43,451.45z
				 M370.13,449.06c0.22-0.17,0.39-0.38,0.52-0.62c0.16-0.29,0.17-0.54,0.02-0.75c-0.1-0.14-0.27-0.22-0.51-0.21
				c-0.22,0-0.4,0.06-0.55,0.16c-0.24,0.16-0.23,0.45,0.02,0.85C369.8,448.78,369.97,448.97,370.13,449.06z" />
                                <path d="M369.92,454.29l-1.17-0.06l-0.02-1.14l1.19,0.03L369.92,454.29z M373.29,452.3
				c-1.03,0.71-1.95,0.47-2.78-0.73l-0.35-0.51l0.89-0.62l0.38,0.56c0.48,0.69,0.9,0.91,1.27,0.65c0.2-0.14,0.36-0.4,0.49-0.79
				l0.12-0.38l1.1,0.15C374.26,451.34,373.88,451.9,373.29,452.3z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M341.99,352.11c-0.52,0.44-1.14,0.68-1.86,0.7c-0.65,0.02-1.3-0.13-1.96-0.45l0.09-0.67
				c0.69,0.26,1.22,0.42,1.6,0.48c0.58,0.08,1.08,0,1.5-0.26c-0.22-0.06-0.42-0.2-0.6-0.41c-0.17-0.2-0.26-0.41-0.27-0.62
				c-0.01-0.23,0.09-0.43,0.29-0.6c0.26-0.23,0.57-0.37,0.94-0.44c0.4-0.07,0.69,0,0.88,0.21c0.25,0.29,0.28,0.66,0.1,1.1
				C342.55,351.51,342.31,351.83,341.99,352.11z M341.77,351.39c0.36-0.34,0.44-0.64,0.22-0.89c-0.08-0.09-0.18-0.12-0.33-0.11
				c-0.14,0.01-0.26,0.06-0.35,0.14c-0.19,0.16-0.18,0.36,0.02,0.6C341.45,351.25,341.6,351.34,341.77,351.39z" />
                                <path d="M345.87,358.27l-0.29-0.33c-0.26-0.3-0.38-0.59-0.38-0.87c0.01-0.27,0.13-0.56,0.37-0.89
				c-0.39-0.09-0.75-0.32-1.09-0.71c-0.13-0.15-0.19-0.32-0.18-0.51c0.01-0.19,0.09-0.34,0.24-0.47c0.52-0.44,1.31-0.45,2.37,0
				l0.34-0.42l0.64,0.12l-1.51,1.89c-0.28,0.35-0.43,0.6-0.46,0.76c-0.04,0.22,0.07,0.48,0.32,0.78l0.17,0.2L345.87,358.27z
				 M345.98,355.62l0.52-0.66c-0.22-0.11-0.44-0.19-0.68-0.25c-0.33-0.08-0.55-0.06-0.68,0.05c-0.09,0.08-0.06,0.21,0.1,0.39
				C345.5,355.45,345.74,355.6,345.98,355.62z" />
                                <path d="M346.2,360.66l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.06-0.71l0.7-0.01l0.04,0.65l0.6-0.01L346.2,360.66z
				 M347.81,358.64c-0.63,0.54-1.25,0.44-1.87-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34
				c0.12-0.1,0.21-0.29,0.27-0.55l0.05-0.26l0.74,0.02C348.38,357.94,348.17,358.34,347.81,358.64z" />
                                <path d="M349.8,362.86l-0.51-0.59c-1.02,0.6-2.16,0.59-3.43-0.04l0.09-0.67c0.68,0.26,1.21,0.42,1.57,0.48
				c0.56,0.09,1.02,0.03,1.39-0.19c-0.13-0.1-0.24-0.22-0.36-0.35c-0.47-0.54-0.51-0.98-0.12-1.32c0.24-0.2,0.54-0.35,0.92-0.43
				c0.43-0.1,0.74-0.04,0.93,0.18c0.23,0.27,0.28,0.61,0.15,0.99c-0.1,0.3-0.3,0.59-0.59,0.89l0.49,0.57L349.8,362.86z
				 M349.43,361.31c0.13-0.13,0.23-0.28,0.3-0.44c0.08-0.2,0.07-0.37-0.04-0.49c-0.07-0.09-0.19-0.12-0.35-0.1
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.14,0.12-0.12,0.31,0.07,0.56C349.2,361.15,349.32,361.26,349.43,361.31z" />
                                <path d="M351.25,364.55l-0.2-0.23c-0.28-0.32-0.31-0.69-0.1-1.11c-0.49,0.09-0.88-0.03-1.16-0.36l-0.2-0.23
				l0.54-0.47l0.11,0.12c0.25,0.29,0.51,0.41,0.77,0.35c0.2-0.04,0.45-0.2,0.76-0.49l2.81-2.56l0.66,0.27l-2.95,2.53
				c-0.75,0.65-0.96,1.16-0.63,1.55l0.13,0.15L351.25,364.55z" />
                                <path d="M351.65,367.01l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.04,0.65l0.6-0.01L351.65,367.01z
				 M352.96,366.54l-0.27-0.31c-0.36-0.42-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.04c-0.2-0.08-0.37-0.19-0.51-0.35
				l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.58-0.13l0.23-0.2l0.42,0.29
				c-0.35,0.31-0.54,0.57-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L352.96,366.54z" />
                                <path d="M355.62,369.64l-0.19-0.23c-0.51-0.6-0.58-1.5-0.2-2.71c-0.06,0.08-0.13,0.14-0.2,0.2
				c-0.36,0.3-0.73,0.4-1.13,0.28c-0.34-0.1-0.67-0.33-0.98-0.71l-0.22-0.25l0.54-0.47l0.19,0.22c0.57,0.67,1.05,0.83,1.45,0.49
				c0.2-0.17,0.31-0.42,0.33-0.75c0.01-0.24,0.03-0.67,0.06-1.29c0.36-0.29,0.57-0.43,0.63-0.42c0.49,0.12,1.18,0.36,2.08,0.71
				c0.86,0.34,1.53,0.63,2,0.87l-0.62,0.41c-0.49-0.25-1.1-0.52-1.84-0.83c-0.8-0.33-1.33-0.52-1.61-0.57c0,0.26,0.01,0.58,0.01,0.95
				c0,0.3-0.02,0.59-0.06,0.88c-0.1,0.65-0.15,1.12-0.16,1.42c-0.01,0.5,0.08,0.87,0.27,1.08l0.2,0.23L355.62,369.64z" />
                                <path d="M358.1,372.53l-0.21-0.24c-0.19-0.23-0.41-0.39-0.64-0.49c-0.29-0.12-0.54-0.1-0.74,0.08
				c-0.21,0.18-0.27,0.43-0.19,0.76l-0.63,0.26c-0.43-1.01-0.34-1.96,0.29-2.84l-0.55-0.64l0.54-0.47l0.5,0.58
				c0.43-0.37,0.94-0.62,1.52-0.76c0.52-0.12,0.84-0.11,0.96,0.03c0.1,0.11,0.09,0.35-0.02,0.71c-0.12,0.39-0.3,0.69-0.56,0.91
				c-0.29,0.25-0.62,0.4-0.99,0.44c-0.42,0.05-0.75-0.07-0.99-0.35c-0.22,0.31-0.31,0.69-0.26,1.13c0.04-0.06,0.1-0.12,0.16-0.17
				c0.29-0.25,0.64-0.35,1.06-0.31c0.4,0.05,0.72,0.22,0.98,0.51l0.33,0.38L358.1,372.53z M357.91,370.15
				c0.17-0.14,0.28-0.31,0.34-0.5c0.05-0.16,0.05-0.26,0.01-0.31c-0.04-0.05-0.2-0.04-0.46,0.05c-0.33,0.1-0.63,0.28-0.92,0.52
				c0.14,0.2,0.3,0.32,0.47,0.37C357.55,370.34,357.74,370.3,357.91,370.15z" />
                                <path d="M364.9,371.39l-0.63,0.41c-1.28-0.65-2.36-1.09-3.23-1.32c0.03,1.2-0.19,2-0.66,2.4
				c-0.22,0.19-0.5,0.3-0.84,0.33c-0.54,0.04-1.04-0.21-1.5-0.74l-0.21-0.24l0.54-0.47l0.36,0.42c0.45,0.52,0.85,0.63,1.21,0.33
				c0.2-0.17,0.33-0.47,0.38-0.9c0.01-0.07,0.03-0.53,0.05-1.37c0.34-0.27,0.57-0.38,0.67-0.36
				C362.17,370.18,363.46,370.68,364.9,371.39z" />
                                <path d="M335.2,363.96l-0.2-0.24c-0.16-0.18-0.25-0.34-0.28-0.48c-0.05-0.22,0-0.51,0.15-0.87
				c-0.37,0.11-0.71,0.1-1.01-0.03c-0.23-0.11-0.49-0.32-0.77-0.65c-0.37-0.43-0.54-0.81-0.52-1.15l0.67-0.14
				c0.02,0.25,0.15,0.5,0.36,0.75c0.65,0.76,1.15,1,1.48,0.71c0.05-0.05,0.1-0.11,0.15-0.18l1.06-1.69l0.68,0.01l-1.23,1.87
				c-0.41,0.62-0.48,1.08-0.22,1.38l0.2,0.24L335.2,363.96z" />
                                <path d="M337.81,367l-0.2-0.23c-0.19-0.23-0.28-0.54-0.25-0.95c-0.48,0.29-0.78,0.35-0.9,0.18
				c-0.29-0.43-0.43-0.97-0.44-1.6c-0.34-0.04-0.6-0.17-0.78-0.38l-0.25-0.29l0.54-0.47l0.18,0.21c0.3,0.35,0.6,0.5,0.92,0.44
				c0.47-0.08,0.73-0.12,0.77-0.12c0.36-0.03,0.6,0.01,0.7,0.13c0.1,0.11,0.11,0.33,0.04,0.66c-0.11,0.5-0.17,0.81-0.17,0.93
				c-0.02,0.38,0.07,0.68,0.26,0.91l0.12,0.13L337.81,367z M337.52,364.76c0.08-0.23,0.1-0.38,0.04-0.44
				c-0.1-0.12-0.39-0.1-0.86,0.07c-0.01,0.22,0.01,0.46,0.09,0.71c0.04,0.14,0.09,0.24,0.13,0.29c0.07,0.08,0.14,0.08,0.23,0
				C337.29,365.29,337.41,365.07,337.52,364.76z" />
                                <path d="M342.22,369.06l-0.63,0.32c-0.37-0.43-0.77-0.72-1.2-0.86c-0.22-0.07-0.6-0.2-1.16-0.38
				c-0.43-0.15-0.85-0.47-1.26-0.95l-0.35-0.41l0.54-0.47l0.37,0.43c0.28,0.33,0.55,0.57,0.82,0.73c0.17,0.11,0.43,0.22,0.78,0.35
				c0.37,0.13,0.64,0.25,0.79,0.33c-0.08-0.17-0.18-0.45-0.3-0.86c-0.11-0.37-0.19-0.59-0.26-0.67c-0.11-0.12-0.35-0.2-0.72-0.23
				l-0.09-0.46c0.22-0.04,0.45-0.05,0.7-0.02c0.3,0.03,0.5,0.11,0.6,0.22c0.15,0.17,0.27,0.43,0.37,0.79c0.16,0.58,0.26,0.91,0.29,1
				C341.68,368.34,341.91,368.72,342.22,369.06z" />
                                <path d="M341.82,371.47l-0.42-0.28l4.34-3.92l0.6,0.33L341.82,371.47z" />
                                <path d="M344.71,375.04l-0.19-0.22c-0.16-0.18-0.26-0.37-0.3-0.55c-0.5,0.33-1.18,0.43-2.05,0.3
				c-0.58-0.09-1.17-0.27-1.75-0.53l-0.01-0.59c0.7,0.25,1.35,0.42,1.93,0.52c0.74,0.12,1.23,0.08,1.47-0.12
				c0.17-0.15,0.32-0.46,0.44-0.95l0.73,0c-0.1,0.4-0.16,0.64-0.16,0.71c-0.02,0.28,0.06,0.52,0.23,0.73l0.2,0.23L344.71,375.04z" />
                                <path d="M345.05,377.43l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.04,0.65l0.6-0.01L345.05,377.43z
				 M346.65,375.41c-0.63,0.54-1.25,0.44-1.87-0.28l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34
				c0.12-0.1,0.21-0.29,0.26-0.55l0.05-0.26l0.73,0.02C347.22,374.72,347.01,375.11,346.65,375.41z" />
                                <path d="M348.64,379.63l-0.51-0.59c-1.02,0.6-2.16,0.59-3.43-0.04l0.09-0.67c0.68,0.26,1.21,0.42,1.57,0.48
				c0.56,0.09,1.02,0.03,1.39-0.19c-0.13-0.1-0.24-0.22-0.36-0.35c-0.47-0.54-0.51-0.98-0.12-1.32c0.24-0.2,0.54-0.34,0.92-0.43
				c0.43-0.1,0.74-0.04,0.93,0.18c0.24,0.27,0.28,0.61,0.15,0.99c-0.1,0.29-0.3,0.59-0.58,0.89l0.49,0.57L348.64,379.63z
				 M348.28,378.08c0.13-0.13,0.23-0.28,0.3-0.44c0.08-0.2,0.07-0.37-0.04-0.49c-0.08-0.09-0.19-0.12-0.35-0.1
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.14,0.12-0.12,0.31,0.07,0.56C348.04,377.92,348.17,378.03,348.28,378.08z" />
                                <path d="M348.51,381.53l-0.77,0.04l-0.09-0.75l0.78-0.06L348.51,381.53z M350.58,379.99
				c-0.63,0.54-1.25,0.44-1.87-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34c0.12-0.1,0.21-0.29,0.26-0.55
				l0.05-0.26l0.74,0.02C351.14,379.29,350.94,379.68,350.58,379.99z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M320.75,301.39l-0.64,0.23c-0.05-0.16-0.14-0.32-0.28-0.48c-0.2-0.24-0.49-0.41-0.86-0.52
				c-0.4-0.12-0.73-0.11-0.99,0.02c-0.02,0.01-0.05,0.03-0.08,0.05c-0.11,0.1-0.07,0.31,0.14,0.62c0.15,0.2,0.3,0.4,0.44,0.6
				c0.33,0.48,0.31,0.88-0.05,1.19c-0.37,0.32-0.95,0.34-1.73,0.07c-0.75-0.26-1.35-0.65-1.8-1.17c-0.43-0.51-0.66-1-0.69-1.49
				c-0.03-0.54,0.21-1.02,0.7-1.45c0.42-0.36,0.91-0.58,1.45-0.67l0.15,0.49c-0.44,0.09-0.8,0.25-1.07,0.48
				c-0.71,0.61-0.69,1.36,0.07,2.24c0.26,0.3,0.58,0.57,0.98,0.8c0.41,0.24,0.8,0.39,1.17,0.46c0.18,0.03,0.31,0.01,0.38-0.04
				c0.09-0.08,0.08-0.2-0.04-0.38c-0.49-0.73-0.76-1.15-0.8-1.27c-0.1-0.27-0.01-0.52,0.27-0.76c0.39-0.33,0.91-0.45,1.56-0.37
				c0.63,0.08,1.11,0.32,1.45,0.71C320.64,300.96,320.73,301.16,320.75,301.39z" />
                                <path d="M321.45,305.56c-0.43,0.37-1.09,0.5-1.98,0.39c-0.63-0.08-1.22-0.25-1.79-0.5l-0.04-0.63
				c0.68,0.25,1.31,0.42,1.91,0.51c0.73,0.11,1.21,0.06,1.44-0.14c0.23-0.2,0.41-0.55,0.54-1.04l0.71,0.05
				C322.1,304.78,321.83,305.23,321.45,305.56z" />
                                <path d="M322.46,308.25l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.17c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.81-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.16,0.3-0.12,0.58,0.1,0.84l0.13,0.15L322.46,308.25z" />
                                <path d="M322.85,310.71l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.05,0.65l0.6-0.01L322.85,310.71z
				 M324.17,310.24l-0.27-0.31c-0.37-0.43-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.03c-0.21-0.08-0.37-0.19-0.51-0.35
				l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.59-0.13l0.23-0.2l0.42,0.29
				c-0.35,0.31-0.54,0.57-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L324.17,310.24z" />
                                <path d="M325.89,312.25l-0.27-0.31c-0.37-0.43-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.04
				c-0.21-0.08-0.37-0.19-0.51-0.35l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.59-0.13
				l0.23-0.2l0.42,0.29c-0.35,0.31-0.54,0.58-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L325.89,312.25z M328.22,309.56
				l-0.68,0.03l-0.05-0.67l-0.62,0.01l-0.06-0.71l0.7-0.02l0.05,0.65l0.6-0.01L328.22,309.56z" />
                                <path d="M329.33,316.26l-0.5-0.58c-0.28-0.33-0.37-0.66-0.27-0.99c0.03-0.1,0.15-0.31,0.37-0.66l-1.53-0.62
				c-0.52-0.21-0.96-0.53-1.33-0.95l-0.39-0.45l0.54-0.46l0.37,0.43c0.37,0.43,0.76,0.74,1.17,0.93c0.25,0.11,0.69,0.31,1.33,0.59
				c-0.13-0.25-0.26-0.58-0.39-1.01c-0.12-0.39-0.2-0.62-0.26-0.69c-0.12-0.14-0.34-0.21-0.66-0.18l-0.11-0.48
				c0.66-0.15,1.09-0.1,1.3,0.14c0.14,0.16,0.26,0.42,0.37,0.78c0.16,0.54,0.27,0.88,0.32,1.02c0.17,0.43,0.41,0.82,0.72,1.18
				c0.06,0.07,0.12,0.15,0.19,0.22l-0.62,0.31c-0.25-0.29-0.49-0.48-0.71-0.58c-0.22,0.32-0.14,0.7,0.24,1.14l0.38,0.44
				L329.33,316.26z M330.98,311.67l-0.77,0.04l-0.09-0.75l0.78-0.06L330.98,311.67z" />
                                <path d="M329.2,318.17l-0.77,0.04l-0.09-0.75l0.78-0.06L329.2,318.17z M331.28,316.63
				c-0.63,0.54-1.25,0.44-1.88-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.66,0.53,0.88,0.34c0.12-0.11,0.21-0.29,0.27-0.55
				l0.05-0.26l0.74,0.02C331.84,315.93,331.63,316.32,331.28,316.63z" />
                                <path d="M335,321.22c-0.52,0.45-1.14,0.68-1.86,0.7c-0.65,0.02-1.31-0.13-1.96-0.45l0.09-0.67
				c0.69,0.26,1.23,0.42,1.6,0.48c0.58,0.08,1.08,0,1.5-0.26c-0.22-0.07-0.42-0.2-0.6-0.41c-0.18-0.2-0.27-0.41-0.27-0.62
				c-0.01-0.23,0.09-0.43,0.29-0.6c0.26-0.23,0.58-0.37,0.94-0.43c0.4-0.07,0.69,0,0.88,0.21c0.25,0.29,0.28,0.66,0.1,1.1
				C335.56,320.63,335.32,320.95,335,321.22z M334.79,320.5c0.36-0.34,0.44-0.64,0.22-0.89c-0.08-0.09-0.18-0.12-0.33-0.11
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.19,0.16-0.18,0.36,0.02,0.6C334.46,320.37,334.6,320.45,334.79,320.5z" />
                                <path d="M340.53,326.49c-0.67,0.57-1.26,0.9-1.77,0.99c-0.65,0.11-1.25-0.15-1.78-0.78
				c-0.41-0.48-0.59-0.96-0.55-1.45s0.3-0.94,0.78-1.34c0.16-0.13,0.37-0.26,0.64-0.4c0.27-0.13,0.5-0.21,0.7-0.25l0.18,0.46
				c-0.42,0.11-0.75,0.27-0.99,0.48c-0.75,0.64-0.8,1.34-0.16,2.09c0.65,0.75,1.46,0.72,2.42-0.11c0.21-0.18,1.24-1.12,3.1-2.82
				l0.66,0.34L340.53,326.49z" />
                                <path d="M340.88,329.73l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.17c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.82-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.15,0.3-0.12,0.58,0.1,0.84l0.13,0.15L340.88,329.73z" />
                                <path d="M344.32,333.74l-0.5-0.58c-0.28-0.33-0.37-0.66-0.27-0.99c0.03-0.1,0.15-0.31,0.37-0.66l-1.53-0.62
				c-0.52-0.21-0.96-0.53-1.33-0.95l-0.39-0.45l0.54-0.46l0.37,0.43c0.37,0.43,0.76,0.74,1.17,0.93c0.25,0.11,0.69,0.31,1.33,0.59
				c-0.14-0.25-0.26-0.58-0.39-1.01c-0.12-0.39-0.2-0.62-0.26-0.69c-0.12-0.14-0.34-0.21-0.66-0.18l-0.11-0.48
				c0.66-0.15,1.09-0.1,1.3,0.14c0.14,0.16,0.26,0.42,0.37,0.78c0.16,0.54,0.27,0.88,0.32,1.02c0.17,0.43,0.41,0.82,0.72,1.18
				c0.06,0.07,0.13,0.15,0.19,0.22l-0.62,0.31c-0.25-0.29-0.49-0.48-0.71-0.58c-0.22,0.31-0.14,0.69,0.24,1.14l0.38,0.44
				L344.32,333.74z" />
                                <path d="M347.16,335.45c-0.08,0.07-0.25,0.13-0.5,0.18c-0.27,0.05-0.45,0.03-0.52-0.05
				c-0.13-0.15-0.24-0.37-0.32-0.66c-0.08-0.26-0.11-0.51-0.1-0.73c-0.36,0-0.62-0.03-0.8-0.08c-0.24-0.06-0.44-0.19-0.6-0.37
				l-0.2-0.23l0.54-0.47l0.11,0.12c0.33,0.38,0.75,0.52,1.27,0.43c0.17-0.04,0.48-0.09,0.93-0.17c0.45-0.08,0.75-0.02,0.92,0.17
				c0.19,0.22,0.16,0.55-0.07,0.99C347.64,334.94,347.42,335.23,347.16,335.45z M346.9,334.91c0.11-0.09,0.21-0.24,0.31-0.44
				c0.11-0.23,0.14-0.38,0.07-0.46c-0.09-0.1-0.4-0.08-0.93,0.07c0.01,0.26,0.07,0.5,0.16,0.72c0.04,0.1,0.08,0.16,0.1,0.19
				C346.67,335.05,346.76,335.02,346.9,334.91z" />
                                <path d="M349.48,338.24c-0.43,0.37-1.09,0.5-1.98,0.39c-0.63-0.08-1.22-0.25-1.79-0.5l-0.04-0.63
				c0.68,0.25,1.31,0.42,1.91,0.51c0.73,0.11,1.21,0.06,1.44-0.14c0.23-0.2,0.41-0.54,0.54-1.04l0.71,0.05
				C350.14,337.46,349.87,337.91,349.48,338.24z" />
                                <path d="M350.49,340.93l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.16c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.81-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.16,0.3-0.12,0.58,0.1,0.84l0.13,0.15L350.49,340.93z" />
                                <path d="M352.97,343.81l-0.21-0.25c-0.19-0.23-0.41-0.39-0.64-0.49c-0.29-0.12-0.54-0.1-0.75,0.08
				c-0.21,0.18-0.27,0.43-0.19,0.77l-0.63,0.26c-0.44-1.01-0.34-1.96,0.29-2.85l-0.55-0.64l0.54-0.47l0.5,0.58
				c0.43-0.37,0.94-0.62,1.53-0.76c0.52-0.12,0.84-0.11,0.96,0.03c0.1,0.11,0.09,0.35-0.02,0.71c-0.12,0.39-0.3,0.69-0.56,0.91
				c-0.29,0.25-0.63,0.4-1,0.44c-0.42,0.05-0.75-0.07-0.99-0.35c-0.22,0.31-0.3,0.69-0.26,1.13c0.04-0.06,0.1-0.12,0.16-0.17
				c0.29-0.25,0.65-0.35,1.06-0.31c0.4,0.05,0.72,0.22,0.98,0.52l0.33,0.38L352.97,343.81z M352.78,341.43
				c0.17-0.14,0.28-0.31,0.34-0.5c0.05-0.16,0.05-0.26,0.01-0.31c-0.04-0.05-0.2-0.03-0.46,0.05c-0.33,0.1-0.63,0.28-0.92,0.52
				c0.14,0.2,0.3,0.32,0.48,0.37C352.42,341.63,352.61,341.58,352.78,341.43z" />
                                <path d="M357.39,345.88l-0.63,0.32c-0.37-0.43-0.77-0.72-1.21-0.87c-0.22-0.07-0.6-0.2-1.16-0.38
				c-0.43-0.15-0.85-0.47-1.27-0.95l-0.35-0.41l0.54-0.47l0.37,0.43c0.28,0.33,0.56,0.57,0.82,0.73c0.17,0.11,0.43,0.22,0.79,0.35
				c0.37,0.14,0.64,0.25,0.79,0.33c-0.08-0.17-0.18-0.45-0.3-0.86c-0.11-0.37-0.19-0.59-0.26-0.67c-0.11-0.12-0.35-0.2-0.72-0.23
				l-0.09-0.46c0.22-0.04,0.45-0.05,0.7-0.02c0.3,0.03,0.5,0.11,0.6,0.22c0.15,0.17,0.27,0.43,0.37,0.79c0.16,0.58,0.26,0.91,0.29,1
				C356.85,345.16,357.08,345.53,357.39,345.88z M352.89,346.9l0.57-0.04l0.05,0.65l-0.58,0.02L352.89,346.9z M353.13,345.87
				l0.61-0.03l0.05,0.66l0.59-0.02l0.05,0.64l-0.62,0.02l-0.04-0.63l-0.58,0.02L353.13,345.87z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M470.67,142.07c0.66,0.91,0.91,1.83,0.75,2.77c-0.16,0.94-0.69,1.73-1.6,2.39
				c-0.79,0.57-1.62,0.76-2.47,0.56c-0.76-0.18-1.38-0.59-1.85-1.25c-0.42-0.58-0.64-1.25-0.66-2.01l0.72-0.21
				c0.11,0.64,0.29,1.13,0.55,1.49c0.88,1.22,1.94,1.37,3.2,0.46c0.64-0.46,1.03-1,1.17-1.61c0.15-0.64-0.01-1.28-0.46-1.91
				c-0.41-0.57-0.99-0.96-1.74-1.18l0.24-0.98C469.44,140.87,470.16,141.36,470.67,142.07z M466.48,140.72l-0.03,1.17l-1.14,0.04
				l0.01-1.18L466.48,140.72z" />
                                <path d="M475.26,141.47l-0.37,0.26c-0.61,0.44-1.24,0.49-1.88,0.15c-0.43-0.23-0.93-0.7-1.48-1.41
				c-0.2-0.25-0.73-0.95-1.59-2.12c-0.6-0.8-1.24-1.61-1.94-2.42l0.5-0.97c1.26,1.7,2.48,3.31,3.64,4.84c0.38,0.5,0.71,0.84,0.97,1
				c0.44,0.27,0.86,0.26,1.27-0.04l0.24-0.17L475.26,141.47z" />
                                <path d="M474.74,135.27l-0.04,1.03l-1.02-0.01l-0.06,0.93l-1.08,0.01l0.07-1.05l0.99,0.01l0.06-0.9L474.74,135.27z
				 M478.49,139.13l-0.5,0.36c-0.69,0.5-1.32,0.58-1.88,0.25c0.05,0.3,0.01,0.6-0.13,0.9c-0.14,0.3-0.34,0.54-0.59,0.72l-0.5,0.36
				l-0.63-0.88l0.45-0.32c0.29-0.21,0.49-0.46,0.59-0.73c0.12-0.32,0.07-0.62-0.13-0.9l-0.27-0.37l0.49-0.59
				c0.42,0.57,0.8,0.88,1.14,0.93c0.26,0.04,0.59-0.07,0.97-0.35l0.36-0.26L478.49,139.13z" />
                                <path d="M485.64,133.99l-0.37,0.27c-0.58,0.42-1.11,0.49-1.58,0.21c0.02,0.6-0.24,1.1-0.78,1.49
				c-0.48,0.34-0.96,0.38-1.45,0.12c0,0.62-0.27,1.12-0.81,1.51c-0.5,0.36-0.99,0.41-1.47,0.14c0.06,0.57-0.17,1.04-0.68,1.41
				l-0.38,0.27l-0.63-0.88l0.22-0.16c0.66-0.47,0.75-1.03,0.29-1.68l-0.1-0.14l0.43-0.62l0.11,0.15c0.56,0.78,1.09,0.98,1.6,0.61
				c0.35-0.25,0.54-0.5,0.57-0.75c0.04-0.25-0.07-0.55-0.32-0.9l-0.1-0.14l0.42-0.62l0.11,0.15c0.56,0.78,1.09,0.98,1.61,0.61
				c0.59-0.43,0.66-0.96,0.19-1.61l-0.1-0.14l0.41-0.65l0.13,0.18c0.28,0.38,0.52,0.62,0.74,0.72c0.29,0.13,0.61,0.07,0.96-0.18
				l0.35-0.25L485.64,133.99z" />
                                <path d="M488.39,132l-0.37,0.27c-0.52,0.38-1.08,0.38-1.68,0c0.07,0.76-0.16,1.33-0.69,1.71l-0.38,0.27l-0.63-0.88
				l0.2-0.14c0.47-0.34,0.68-0.71,0.63-1.12c-0.04-0.3-0.25-0.71-0.64-1.22l-3.5-4.57l0.49-0.96l3.45,4.78
				c0.88,1.22,1.63,1.61,2.26,1.15l0.24-0.17L488.39,132z" />
                                <path d="M486.69,120.81l0.39,0.64c-0.37,0.58-0.82,1.42-1.35,2.5l-1.29,2.64l-0.31-0.57
				C485.11,123.88,485.96,122.14,486.69,120.81z M487.62,122.01l0.55,1.01c-0.5,0.75-0.99,1.59-1.48,2.5
				c-0.45,0.85-0.74,1.46-0.86,1.83c0.71,0.04,1.25,0.11,1.62,0.21c0.8,0.2,1.39,0.56,1.76,1.07c0.88,1.22,0.58,2.37-0.91,3.44
				l-0.4,0.29l-0.63-0.88l0.68-0.49c0.85-0.62,1.08-1.2,0.69-1.74c-0.34-0.46-1.41-0.76-3.22-0.9c-0.33-0.5-0.46-0.83-0.41-0.99
				C485.59,125.63,486.46,123.85,487.62,122.01z" />
                            </g>
                        </svg>

                    </svg><!-- End svg -->




                </div>
            </figure>
        </div>
        <div class="col-md-4">
            <figure class="highcharts-figure container-fluid">
				<a id="hyp_map_telegram" style="cursor: pointer;" data-setting="map_telegram" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <header class="clearfix">
                    <h4 class="text-right" style="padding: 10px; text-align: right;">پراکندگی جغرافیایی کاربران تلگرام</h4>
                </header>
                <div class="svg-wrapper">

                    <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 841.89 595.28" enable-background="new 0 0 841.89 595.28" xml:space="preserve">

                        <svg class="map-border">
                            <path display="inline" d="M749.69,551.97l-1,1.05
			c-1.84-0.27-3.76-0.97-5.64-1.46c-0.57-0.15-0.35-0.16-0.9,0.05c-0.8,0.3-1.38,0.78-1.95,1.25c-1.29,1.06-1.15,0.69-1.83,0.78
			c-1.41,0.18-2.92-0.09-4.43-0.36l0,0.01c-1.59-0.29-3.19-0.57-4.88-0.43c-2.27,0.07-5.31-0.26-7.84-0.45l-2.14,3.4l-2.61,0.12
			l-0.28,0.65l-0.97-0.79c-1.31-0.48-2.65-0.58-3.95-0.39c-2.05,0.29-3.26,1.06-4.9,2.09l0.67,2.01c-2.78-0.08-4.41,0.17-7.09,0.84
			l-0.35,2.31l-1.64,0.25l-0.22-0.13l1.35-4.46l-4.45-0.62l-0.92-0.42l0.14-0.73c0.98-5.28-1.08-10.48,0.49-15l0.1-0.29
			c0.03-0.24-0.35-2.91-0.23-4.12l2.63,0.67l0.48-8.59c0.17-2.37,0.35-4.57,0.54-6.67c0.41-2.87,5.63-2.79,8.4-5.03l0.41-0.33
			l0.29-1.37l3.69,0.43l0.37-1.18c0.62-2.01,0.96-5.05,3.03-5.4l0.71-0.12l0.76-1.34c2.61-0.5,5.23-0.81,7.75-2.02
			c2.34-1.12,4.89-1.88,7.5-2.19c3.78-0.44,5.86,0.05,9.27,0.9l-0.12-8.41l3.21-1.76l-2.14-2.39c-0.04-1.12-0.03-2.24,0.06-3.36
			c0.4-4.57,2.19-4.32-0.12-7.28l-1.17-1.84c-2.48,1.64-2.76,1.78-6.12,2.36l-2.81,0.58c-1.57,0.44-3.36-0.04-5.07-0.49l-0.06-0.02
			c-0.32-1.64-1.01-3.46-0.43-4.87c0.69-1.66,1.29-3.46,0.87-5.37c-0.25-1.25-0.45-2.45-0.65-3.64c-0.57-3.4-1.14-6.8-2.43-10.1
			c-1.03-2.67-0.73-5.71-0.43-8.68l0.35-3.91l-7.4,1.48l-1.92-2.86l-0.48-0.5c-1.57-1-2.74-2-4.59-2.48
			c-2.27-0.6-4.57-1.08-6.86-1.56c-2.12-0.44-4.25-0.89-6.29-1.41c-1.71-0.62-4.31-3.59-5.91-4.97l-1.25-0.93
			c-1.18-0.86-2.38-1.72-3.24-2.82c-1.88-2.32-2.43-3.78-3.57-6.66c-0.96-2.43-1.01-2.84-3.18-4.57c-1.61-1.28-1.6-1.44-1.67-2.89
			l-0.67-0.42c-1.1-0.68-0.9-2.96-0.97-4.59c-1.82-1.44-2.24-1.78-3.81-3.5l-5.3-5.75c-2.27-2.39-4.53-4.77-6.61-7.32
			c4.77-7.01,9.76-13.93,14.74-20.86c3.4-4.71,6.79-9.43,9.93-13.9c0.84-1.26,0.97-2.71,1.08-4.03c0.18-2.18,0.28-2.27,1.38-3.59
			c-1.06-2.12-1.99-4.08-2.11-6.52l-0.03-0.63l-1.64-1.47c-0.37-0.61,0.22-4.86-3.52-5.08c-4.02-0.3-8.21-0.6-12.4-0.9l-12.98-0.97
			c0.03-1.96-0.1-3.87-1.17-5.59c0.59-1.4,1-2.31,0.45-3.99c-0.72-2.17-1.14-5.94-1.1-8.27c0.05-1.93,0.89-4.07,0.99-6.36
			c0.07-1.57-1.49-5.92-2.04-7.42l-2.59-7.26c-1.79-5.03-3.57-10.06-5.52-15.43c-0.44-1.2-0.67-2.34-0.43-3.58
			c0.17-0.88,0.6-1.68,1.36-2.24c1.14-0.68,2.42-2.61,3.06-3.6c0.65-1,1.31-2.01,2.17-2.71l0.36-0.29l1.71-6.05l-1.68-0.25
			c-3.47-0.52-8.08-0.01-10.19-2.77l-0.11-0.13c-1.22-1.27,0.41-3.61,1.18-4.78c-0.9-3.77-1.96-7.68-1.54-11.47l0.18-1.61
			c0.45-0.52,0.89-1.06,1.32-1.59c1.1-1.37,2.2-2.73,3.57-3.67c0.62-0.09,1.26-0.13,1.91-0.17c2.41-0.16,3.06-0.36,5.36-0.83
			l-1.53-1.92c-1.44-1.81-3.06-3.41-4.63-5.07l3.22-0.58l0.65-2.12l1.57-0.83c0.68-0.39,0.51-0.17,0.71-0.91
			c0.35-1.29,0.78-2.6,1.22-3.91l0,0c0.27-0.81,1-2.77,1.01-3.36c0.05-3.79,0.43-6.27,1.53-9.87c-0.87-0.83-1.48-1.32-1.76-2.61
			c-0.17-0.79-0.14-1.64,0.07-2.46c1.27-1.77,2.24-3.68,3.03-5.67c0.99-2.47,1.66-4.9,2.38-7.39c-1.32-0.65-2.48-1.11-3.25-2.46
			c1.59-3.17,1.1-6.29,0.11-9.47l-2.64-0.73c0.2-1.14,1.49-2.5,1.72-4.31c0.49-3.95-2.49-8.67-2.53-9.06c0.43-2.01,0.53-4,0.63-6
			l0.13-2.18l-2.78-2.9l-11.08,0.75c-2.87,0.13-5.74,0.27-8.47,0.49c-0.56,0.03-2.24,0.13-2.52-0.15c-0.46-0.46-1.3-3.79-3.69-5.37
			l0,0c-1.47-0.97-2.31-2.65-3.15-4.33c-0.97-1.94-1.24-2.42-2.51-4.11l-0.89,0.14c-3.15,0.5-6.09-3.23-10.48-2.39
			c-0.31,0.06-0.13,0.21-0.65-0.58l-1.03-1.35l-2.93,0.12l-0.56-2.16l-2.83-2.4c-0.38-0.99-0.5-2.14-0.62-3.29l-0.46-3.2l-2.25,0.1
			c-0.82,0.1-0.85,0.11-1.2-0.09l-6.74-4.53l-0.79-0.26l-4.2-0.5l-0.57-0.12l-3.02,1.75c-0.63-0.24-1.26-0.68-1.88-1.12l-2.32-1.49
			l-0.83,1.01c-0.32,0.4-1.31,1.96-1.61,2.06c-0.75,0.04-1.61-0.17-2.45-0.38l-2.65-0.54c-2.18-0.46-2.42-2.13-2.77-3.84
			c-3.07-0.27-5.44-0.66-8.11-2.43c-0.54-0.36-0.31-0.3-0.95-0.25c-1.65,0.13-3.31-0.62-4.91-1.31l0,0
			c-3.35-1.51-7.08-0.06-9.14-2.01l-0.21-0.16c-0.63-0.42-0.35-2.02-0.32-3.05c0.02-0.65,0.09-0.42-0.3-0.94
			c-2.83-3.78-2.78-4.3-3.49-8.6l-2.82,2.7c-0.86,0.86-1.73,1.74-2.73,2.17c-0.86,0.25-3.04,0.14-4.01,0
			c-1.24-0.27-2.37-1.83-4.31-2.41l-0.55-0.17l-1.13,0.56c-3.06,1.53-2.88,0.28-3.38,0.06l-3.86-0.07c-2.07,0.22-2.9,0.8-4.49,1.91
			l1.38,3.83l-1.81,1.33c-2.75-0.75-5.5-0.44-8.18-0.29c-2.37,0.14-3.7-2.27-7-1.51c-2.86,0.66-6.17-0.1-9.22,2.74
			c-1.92,1.79-4.83,3.16-7.4,3.74c-0.65,0.15-0.45,0.02-0.85,0.53c-2.13,2.68-4.86,4.39-7.32,6.55c-3.12,2.74-1.67,7.19-3.14,9.54
			c-0.39,0.55-1.51,1.78-2.05,1.96c-0.9,0.3-3.8-1.11-6.16,0.45l-0.1,0.06v0.01c-1.97,1.23-3.99,2.5-6.18,3.08
			c-1.13-0.06-2.33-0.21-3.54-0.35l-5.15-0.41c-0.36-1.93-0.61-3.88-0.64-5.84l-0.2-0.73c-3.14-5.46-1.48-12.13-1.36-17.95
			c0.02-0.98,0.28-1.8,0.61-2.86c1-3.21,0.85-3.48,0.33-6.55c-0.46-2.73-0.92-5.48-0.5-8.12c0.31-2.41,1.95-4.44,2.35-7.27l0.97-3.54
			l0.09-0.57c-0.14-3.24-1.64-5.43-3.98-7.47l-2.17,0.17c-0.73-0.57-1.25-1.45-1.77-2.32c-0.86-1.45-1.72-2.88-3.46-3.73
			c-0.53-1.79-1.14-3.79-3.33-4.63c-3.44-1.13-5.28-1.82-8.61-3.29l1.55-2.68l0.96-0.12c2.49-0.31,4.91-0.07,7.51-0.86l0.66-0.41
			c2.02-2.13,0.62-3.58-0.72-4.97l-0.9-1.07c-0.65-0.66-0.16-1.66,0.34-2.68c0.82-1.68,1.66-3.38,0.52-5.4
			c-0.96-2.92-3.4-2.32-5.52-1.8c-0.25,0.06-0.5,0.12-0.71,0.17c-1.77-0.86-3.72-1.33-5.65-1.3c-2.11,0.03-3.99,0.61-5.81,1.86
			c-0.29-0.25-0.58-0.47-0.88-0.7l0,0c-0.38-0.28-0.76-0.57-1-0.87c-0.28-0.79-0.2-1.78-0.12-2.76c0.11-1.39,0.23-2.77-0.39-4.27
			c-0.79-2.13-0.46-5.23,0.2-7.81H343.9l-0.04,3.49c-0.41-0.33-0.83-0.66-1.26-0.97c-1.09-0.78-3.89-2.36-5.21-2.28
			c-2.94,0.17-5.99,0.4-8.63,1.97c-2.87,1.52-5.88,2.45-8.53,4.62c-1.61,1.32-1.75,3.63-1.82,5.27c-0.11,2.4-0.26,2.78-1.71,3.83
			l-0.04,5.82c-0.33,0.59-0.7,1.16-1.07,1.73c-1.24,1.9-2.48,3.81-2.52,6.35c-0.22,2.77,1.19,3.59,2.65,5.38
			c-0.06,0.63-0.16,1.35-0.43,1.84l-1.93-1.82l-0.99,1.48c-2.48,3.7-1.75,8.38-1.84,8.69l-0.35,0.49c-1.09-0.92-1.23-1.11-2.13-2.45
			c-1.04-1.53-1.23-1.71-2.46-2.97c-2.63,1.59-3.08,2.15-2.76,5.5c0.25,2.71-0.51,2.29-0.72,2.74l-0.12,2.35l-3.54,2.98l0.72,3.05
			c0.18,0.6,0.38,1.18,0.61,1.74l0.02,8.63c-2.65,1.35-3.65,1.19-6.23,1.94c-0.07-0.57-0.3-1.14-0.83-1.71l-0.58-0.68
			c-2.45-2.87-2.87-3.43-3.75-6.69l-1.38,0.28c-1.45,0.29-2.78-0.91-3.59-2.01c-1.75-2.41-3.88-3.96-5.88-5.97
			c0.77-1.23,1.58-2.44,2.59-3.33c0.82-0.16,1.65-0.28,2.49-0.4l5.29-1.03l-0.82-1.69c-1.66-3.44-5.32-5.29-5.91-8.33
			c0.93-0.84,2.15-1.39,3.37-1.93c2.29-1.02,2.54-1.24,4.51-2.55c-3.72-4.22-7.19-7.72-11.05-11.74l-4.12,0.57
			c-0.76,0.1-0.52-0.04-1,0.56c-1.77,2.23-5.67,2.66-7.99,4.85c-0.86,0.81-2.18,0.95-3.56,1.1c-2.03,0.22-2.85,0.48-4.81,0.94
			l1.46,1.51c-1.18,0.79-2.51,1.46-3.84,2.12l-2.74,1.44c-0.1,0.09-1.87,3.16-2.54,3.53c-0.9,0.49-5.17-0.22-6.69,3.04
			c-1.4,3-3.82,5.7-6.99,6.84c-1.29,0.39-2.8-0.12-4.24-0.61l-1.43-0.47c-1.25,0.78-2.99,2.18-4.08,1.92l0,0
			c-2.28-0.55-4.33-1.41-6.78-1.56c-2.43-0.17-4.18-3.16-7.97-3.09c-1.88,0.04-3.36-1.09-5.05-2.09c-0.13-2.43-0.83-4.7-2.05-6.82
			l-0.28-0.49c-0.09-0.08-4.38-1.34-5.27-2.31c-0.72-0.79-0.54-3.28-2.46-5.31c-0.81-0.85-2.08-2-2.17-2.84l-0.06-0.27
			c-0.56-1.83-0.3-3.68-2.18-5.45l-3.11-2.75l-3.64-3.44l-3.82,1.21l-0.78,3.94l-1.42,1.7c0.34,2.34,0.15,4.21-1.66,5.98
			c-5.21-1.02-4.97-1.28-10.5-1.02c1.69,3.6,2.2,4.56,2.32,8.69l2.68,1.36c-0.95,3.07-2.28,6.01-1.31,9.46l0.13,0.47l2.21,1.8
			c-0.46,1.47-0.98,2.95-0.96,4.62l0.55,1.99c0.73,2.07,0.68,2.15,0.15,3.7c-1.07,3.14-1.12,3.56-1.57,6.65l5.5-0.3
			c0.02,0.56,0.03,1.12-0.04,1.61c-0.13,0.31-1.68,1.43-2.08,1.78c-0.51,0.44-0.39,0.22-0.5,0.9c-0.7,4.13-6.04,6.49-6.29,12.04
			l-0.06,1.22l4.15,1.08c0.39,0.24,1.37,1.83,3.34,2.77c0.76,0.37,2.92,1.13,2.96,1.64l-1.95,3.19c0.79,1.1,1.42,1.88,1.46,3.32
			c0.04,1.6-0.71,2.57-1.51,3.88c1.52,1.03,2.74,1.81,4.16,3.08c0.87,0.78,1.67,1.61,2.37,2.51c0.39,0.71-0.47,2.63-0.75,3.55
			l-0.56,4.59l1.84,1.39c0.87,0.52,0.95,0.55,0.93,0.89c-0.25,5.12-0.17,4.83-2.89,8.36c2.04,0.31,3.99,0.39,5.64,1.77
			c0.71,0.59,1.27,1.35,1.59,2.24c0.02,0.45-2.09,4.33-2.09,4.88l2.76,6.67l3.39-1.16c2.15,2.68,0.81,4.13,0.79,4.46l0.61,2.12
			c1.57,5.09,0.89,5.12-1.76,9.24c3.63-0.83,4.36-1.11,8.29-1.43l-0.18,0.47c1.52,1.5,3.65,3.67,4.39,5.7
			c0.77,2.12,2.06,1.88,4.15,2.8c2.83-1.2,4.71-1.27,7.79-1.26l0.78,0.92c0.46,0.54,0.22,0.41,0.91,0.53
			c1.39,0.23,2.67-0.12,3.77-0.03c-2.25,2.32-5.74,2.85-8.83,3.37c0.1,2.68,0.09,3.04-2.04,4.96l0.26,0.91l2.24,6.31l1.59,0.59
			c0.29,0.08,0.57,0.06,0.65,0.1l-0.24,3.19l1.75,1.37c-0.99,0.79-1.25,1.92-1.55,3.02c-0.54,0.02-1.08,0.01-1.61,0
			c-0.92-0.02-0.7-0.11-1.23,0.26c-1.19,0.83-3.01,0.38-4.46,0.12l-2.12,2.47l0.59,3.42c-0.31,0.26-2.14,0.53-2.74,0.66
			c-0.77,1.54-1.05,1.76-2.69,2.97l-2.82,2.47c0.88,1.31,3.26,4.6,1.49,5.87c-0.46,0.33-0.96-0.02-1.85-0.62l-4.57-2.52l1.97,5.37
			l-0.59,0.75l-3.34,0.14l1.07,4.93l0.68,0.3c0.82,0.36,2.67,0.78,2.65,1.39c-0.04,1.44-0.15,2.86-0.64,4.19
			c-0.62,1.67-1.39,2.21-2.82,2.9l-1.79,5.25l3.12,1.15c1.34,3.82,2.27,8.12,5.95,10.59l-0.12,0.15l1.91,0.9l0.15-0.22l2.15,0.74
			c0.02,0.01-0.07,0.5-0.12,0.98c-0.13,1.35-0.07,1.43,0.15,2.66c0.82,0.25,1.39,0.37,2.12,0.87c0.24,0.17,0.48,0.36,0.7,0.57
			l-0.06,1.44l0.11,0.62c1.38,3.36,5.3,4.96,4.6,7.75c-0.15,0.62,0.27,0.77-1.71,1.33l-5.21,1.9l4.31,1.34
			c-0.22,1.77-0.64,2.87-1.17,4.56l3.32-0.05c2.5-0.07,5.11-0.14,7.05,1.22l0.28,0.16c3.63,1.52,5.87,5.41,9.62,7.93
			c1.79,1.22,3.2,2.95,4.62,4.67c1.21,1.48,2.42,2.96,3.94,4.25c2.75,2.51,5.22,1.25,8.14,0.41l0.48,0.64
			c1.97,2.58,1.93,3.01,0.97,4.98l0.68,0.75c2.73,3.01,2.45,3.25,1.27,5.64l1.35,0.67c1.66,0.82,2.68,2.63,3.65,4.37l1.11,1.98
			c0.87,1.68,0.96,2.32,2.39,4.05c0.49,0.6,1.45,1.67,1.33,2.16c-0.63,2.69-4.05,9.13-4.79,12.44c-1.01,4.57-0.89,11.38-0.84,16.39
			c3.22-0.06,6.38-0.15,9.6,0.28l-1.04,17.85l0.96,0.42c0.79,0.35,2.8,0.83,3.05,1.22l1.09,4.16c0.33,0.49,3.35,2.1,4.17,3.9
			c1.01,2.21,1.34,5.32,2.06,7.83c-0.3,0.1-0.6,0.24-0.9,0.42c-2.24-1.49-4.53-2.95-7.26-3.69c-0.7-0.19-0.43-0.22-1.08,0.12
			l-3.51,1.7l-0.55,0.43c-2.79,3.49-0.99,7.13,0.17,10.54c0.6,1.82,1.81,2.79,2.84,4.1c-1.36-0.28-2.73-0.54-4.19-0.52
			c-1.64,0.03-4.45,2.24-5.91,3.15c-1.67,0.92-2.23,2.45-2.78,3.92l-1.04,2.42c2.77,1.24,3.22,1.38,6.53,0.79
			c1.35-0.24,2.66-0.48,3.45,0.28c0.14,1.38,0.57,2.59,1,3.81c0.62,1.76,0.95,2.65,0.81,4.36c-0.4,5.11,4.54,8.38,4.54,8.38
			c0.27,1.39,0.61,2.72,0.95,4.06c0.48,1.9,0.97,3.8,1.2,5.69l0.06,0.49c0.02,0.04,1.45,1.38,2.33,3.26c0.5,1.06,3.36,3.02,3.31,5.33
			c-0.08,3.91,1.75,7.35,3.45,10.54c1.04,1.95,1.11,2.33,2.5,4.27c1.09,1.5,2.21,3.06,1.27,4.5l-0.45,0.69
			c1.21,2.64,2.41,4.85,4.53,6.95c4.37,4.33,7.9,3.47,8.73,4.1c0.3,0.23,0.59,0.46,0.85,0.7l-4.04,1.47
			c2.32,2.16,3.36,2.91,4.61,6.04l0.5,0.65c2.11,1.57,3.04,3.82,4.01,6.14l3.47-0.71l0.75,0.57c0.7,1.92,2.14,3.17,3.53,4.38
			l0.11,0.1c1.26,1.67,2.81,3.05,4.52,4.19c1.66,1.1,3.47,1.98,5.31,2.67c0.73,0.42,2.72,2.71,3.44,3.64l-0.44,0.01l-2.4,2.42
			l0.18,0.8c1.02,4.61,4.98,7.36,5.1,7.59c0.1,1.23,0.12,2.47,0.09,3.71c-0.03,1.22-0.12,2.45-0.24,3.7l-1.05,0.78l-4.14-2.77
			l-1.99,7.95l3.98,2.68l0.11,0.57l-0.96,1.48c1.71,2.81,3.98,6.02,3.56,9.24l-0.1,0.74l3.94,3.58c2.57,2.18,5.16,4.36,6.44,7.36
			c0.24,0.94-0.19,8.22-0.03,8.59l4.19,3.98c0.49,0.46,0.26,0.36,0.94,0.4c1.79,0.1,4.94,2.03,6.77-1.29l0.47-0.84
			c-1.39-1.89-2.42-3.59-2.59-6.11c-0.15-2.24,0.48-3.38,1.73-4.94l-0.7-2.35c0-0.06,0.86-1.85,0.78-5.01l0.14,0.07
			c1.77,1.2,2.82,0.07,3.8-0.98l1.34-1.06c-0.42-1.12-1.5-3.58-1.59-4.44c0.3-0.27,0.62-0.54,0.95-0.81v-0.01l0.96-0.8
			c-0.13-1.95-0.12-3.31,0.49-5.21c0.41-1.3,1.05-2.54,1.9-3.66l3.33-0.67l1-1.59c1.08-0.02,2.16-0.04,3.15,0.17
			c0.27,1.39,1.05,2.46,1.83,3.54l1.49,2.54l2.95,0.08c1.81,1.64,1.79,4.69,1.78,7.36l0,0.67c-0.15,0.48-2.68,2.35-3.35,3.39
			c-1.62,2.55,0.72,5.38,0.87,5.99l-0.41,5.04l3.05,1.35c-0.14,2.73-0.48,5.08-0.9,7.67h117.4c0.89-0.95,1.74-1.94,2.53-3.02
			c1.78-2.4,4.39-4.48,6.48-6.81c2.17-2.34,3.81-4.95,5.7-7.47l0.65,1.02c1.69-2.49,1.64-2.7,4.37-4.64c1.55-1.1,3.11-2.21,4.18-4.04
			c2-1.2,4.14-2.56,5-5.16l0.54-1.81c1.01-3.44,2.05-6.94,4.11-9.72c0.86,1.06,1.91,1.9,2.95,2.74l1.66,1.39l1.94,0.46l0.21,0.07
			c-0.86,2.94-0.79,5.86-2.52,8.28c-1.76,2.46-2.51,4.14-3.42,6.96l0.64,0.65c1.16,1.18,2.65,1.88,2.67,3.19
			c0.07,4.53,0.33,10.76,0.86,15.05l0.2,0.86c0.15,0.65,0.3,1.35,0.57,1.97h227.77v-20.36L749.69,551.97z" />
                        </svg>
                        <svg class="map-sea">
                            <path class="map-sea" id="urumia-lake" d="M194.99,87.71c1.36-2.6,4.59-0.32,6.58,0.2
			l0.08,0.06c0.04,0.02,0.1,0.06,0.12,0.1l0.06,0.04c0.39,1.64,1.83,2.25,3.23,2.76c0.12,0.3,0.41,0.93,0.53,1.26
			c0.35,0.18,0.99,0.59,1.34,0.79c0.2,2.42,0.49,4.89-0.24,7.27l-0.81,0.49c-0.51,0.1-1.5,0.26-2.01,0.36
			c0.18,2.11,0.49,4.24,0.93,6.33c1.6,0.43,2.74,1.6,3.92,2.68c1.46,0.69,3.55,0.45,4.24,2.21c0.81,0.02,1.64,0.04,2.46,0.06
			c0,1.06-0.02,2.11-0.02,3.17c-1.22,0.02-2.44,0.06-3.63,0.1c0.02,0.41,0.04,1.18,0.06,1.56c0.43,0.12,1.3,0.32,1.73,0.45
			c0.3,1.28,0.63,2.56,0.93,3.84c0.99,0.08,1.97,0.14,2.96,0.22c-0.39,1.18-0.77,2.37-1.16,3.57c-1.24,0.53-2.76,0.79-3.39,2.13
			c-1.56-0.1-3.13-0.28-4.69-0.41c0.04,1.6,0.06,3.23,0.12,4.85c-3.21-1.14-7.08-1.08-9.42-3.94c0.26-5.81-0.65-11.55-0.69-17.33
			c0-1.99-0.28-3.96-0.55-5.93c-1.3-0.22-2.62-0.47-3.94-0.71c-0.51-2.11-1.08-4.79,1.28-6.01l0.57-0.22
			c0.95-0.14,1.52-0.65,1.68-1.52l0.1-0.43c0.16-0.65,0.34-1.3,0.55-1.95c-1.6-0.14-3.19-0.3-4.77-0.51
			C193.59,91.38,193.89,89.37,194.99,87.71z" />
                            <path class="map-sea" id="persian-gulf" d="M346.52,545c-0.22-3.45,0.85-6.78,3-9.46c1.06-0.47,2.21-0.55,3.33-0.77
			c0.37-0.59,0.73-1.16,1.1-1.73c1.81-0.02,3.65-0.16,5.38,0.51c-0.04,2.29,1.97,3.8,2.88,5.74c0.85,0.02,1.68,0.04,2.54,0.08
			c3.08,2.25,2.7,6.54,2.72,9.92c-0.81,1.56-2.54,2.38-3.57,3.78c-0.93,1.73,0.45,3.29,1.08,4.83c0.12,1.5-0.18,2.98-0.3,4.47
			c0.99,0.45,1.99,0.87,3,1.3c-0.07,2.5-0.35,4.98-0.73,7.43h114.77c0.79-0.86,1.54-1.74,2.23-2.68c1.91-2.58,4.47-4.57,6.6-6.94
			c2.6-2.8,4.51-6.15,6.96-9.07c0.12,0.22,0.39,0.69,0.53,0.91c1.93-2.84,5.74-3.82,7.39-7.02c1.87-1.12,3.96-2.33,4.69-4.55
			c1.46-4.79,2.62-9.92,6.27-13.58c1.04,2.31,3.29,3.63,5.12,5.26c1.16,0.22,2.27,0.55,3.33,1.1c-1.34,3.25-0.99,7.12-3.21,10.03
			c-1.24,1.72-2.25,3.61-2.9,5.64c1.2,1.22,3.19,2.21,3.11,4.2c0.16,4.97,0.24,9.99,0.85,14.92c0.14,0.52,0.25,1.18,0.45,1.79H748.6
			v-16.58c-2.03-0.28-3.96-0.99-5.92-1.5c-1.46,0.55-2.38,2.33-4.12,2.11c-3.19,0.41-6.21-1.04-9.38-0.77
			c-2.4,0.08-4.79-0.2-7.18-0.39c-0.71,1.1-1.38,2.19-2.05,3.31c-0.83,0.02-1.64,0.06-2.46,0.1c-0.41,0.95-0.79,1.95-1.12,2.94
			c-0.59-1.02-0.75-2.34-1.66-3.13c-2.23-0.81-4.59-0.28-6.54,0.93c0.32,1,0.69,1.99,1.06,3c-2.66-0.26-5.34-0.24-7.94,0.41
			c-0.12,0.79-0.24,1.6-0.36,2.44c-1.1,0.14-2.17,0.3-3.25,0.49c-0.43-0.24-1.28-0.75-1.68-1c0.34-1.32,0.73-2.62,1.14-3.92
			c-0.91-0.12-1.83-0.24-2.72-0.39c-1.14-0.16-2.54-1.68-3.49-0.73c-1.46,0.75-0.43,2.05-0.04,3.17c-3.45,3.08-9.09,2.01-12.56-0.51
			c-5.83-1.5-12.08-0.81-17.7-3.09c-0.35-1.36-0.59-2.74-1.14-4.02c-1.79-1.67-4.67-1.22-6.21,0.53c0.59,0.59,1.06,1.28,1.4,2.03
			c-0.45,0.61-0.91,1.2-1.38,1.79c-1.6-1.06-3.19-2.13-4.87-3.04c-0.99,0.95-2.01,1.89-3.02,2.82c-0.87-0.77-1.75-1.54-2.56-2.33
			c-2.05-0.73-3.73,0.55-5.38,1.56c-1.38,0.04-2.03-1.46-2.94-2.23c-2.31-0.06-4.65,0.12-6.86,0.79c-2.11-0.95-4.04-3.35-6.56-2.37
			c-3.96,1.58-7.86,3.83-12.26,3.73c-1.87-0.87-2.78-2.92-4.34-4.18c-1.99-1.01-4.14-2.03-6.43-1.87c-2.11,0.14-4.18-0.26-6.13-1.06
			c-0.91,0.26-1.83,0.51-2.7,0.79c-3.53-1.1-6.62,1.54-9.7,2.8c-3.31-0.33-4.67-3.63-6.43-5.97c-1.81,0.18-3.51,0.77-5.22,1.36
			c-0.87-1.01-1.6-2.13-2.4-3.19c-0.97,0.28-1.97,0.57-2.94,0.85c-3-0.91-6.25-0.18-9.25-1.08c-2.98-1.72-2.4-6.09-5.54-7.71
			c-1.14-2.37-1.28-4.99-0.41-7.49c-1.81-1.85-3.88-4.06-3.11-6.88c-0.43-0.91-1.28-1.72-1.22-2.78c0.41-1.24,1.3-2.33,1.4-3.67
			c-0.49-2.66-1.83-5.03-2.52-7.63c-0.61-2.44-2.29-4.34-3.53-6.48c-1.6-2.88-4.65-4.55-7.59-5.74c-3.04-0.3-6.17-0.2-9.09-1.2
			c-2.58-1.02-5.6-0.91-8.1,0.14c-2.39,2.13-4.47,4.77-7.47,6.09c-2.9,0.3-5.95,0.22-8.67,1.42c-2.11,1.46-0.95,4.34-1.18,6.47
			c-1.4,0.45-2.78,0.97-4.2,1.36c-2.29,0.55-4.65-0.16-6.94,0.02c-1.38,0.75-2.68,1.66-4.1,2.33c-3.92,1.93-6.7,5.5-10.47,7.63
			c-0.81-0.14-1.58-0.37-2.37-0.55c-0.83,0.28-1.66,0.55-2.5,0.81c-1.26-0.33-1.89-1.5-2.64-2.44c-1.66-0.37-3.45-0.41-5.03-1.12
			c-1.68-1.46-2.5-4.83-5.22-4.26c-1.91,0.29-3.9,0.18-5.44-1.07c-1.12-0.06-2.21-0.1-3.31-0.14c-0.3,0.28-0.91,0.85-1.2,1.12
			c-2.44-0.04-4.87,0.2-7.27-0.16c-1.87-1.04-3.51-2.42-5.42-3.41c-2.35-1.22-2.48-4.2-3.84-6.19c-4.77-2.11-10.27-2.84-14.41-6.23
			c-2.11-1.77-4.53-3.11-6.6-4.93c-1.99-1.91-4.83-2.27-7.14-3.63c0.16-0.49,0.51-1.46,0.67-1.95c1.1-0.1,2.17-0.18,3.27-0.26
			c-2.44-1.77-4.06-4.32-6.27-6.31c-1.75-1.64-4.47-0.93-6.47-2.03c-2.62-1.54-4.87-3.63-7.02-5.74c-2.38-0.02-4.75-0.14-7.06-0.75
			c-2.35-0.08-4.71,0-7.06-0.33c-1.26-1.44-2.58-2.88-4.38-3.59c-2.6-0.97-3.37-3.98-5.68-5.36c-0.37-1.5-0.08-3,0.37-4.47
			c-1.68-3.21-3.98-6.05-5.36-9.44c-1.85-2.78,0.16-6.29-1.44-9.17c-0.99-2.52-4.34-2.19-5.87-4.18c-0.85-1.12-1.26-2.46-1.75-3.73
			c1.28-1.44,4.3-2.52,3.17-4.87c-1.93-1.75-4.57-1.83-7-1.68c-0.39-0.71-0.81-1.4-1.12-2.15c0.43-0.77,0.99-1.48,1.5-2.21
			c-1.08-2.11-0.79-4.44-0.37-6.68c-3.15-1.46-4.57-4.75-6.88-7.1c-3.09-3.25-5.14-7.29-7.92-10.76c-0.77-0.91-0.3-2.21-0.37-3.27
			c0.39-2.31-1.26-4.3-2.7-5.91c-2.88-1.4-5.81,0.59-8.26,1.99c-1.85,1.79-3.71,3.69-6.15,4.65c-2.88-0.3-3.19-3.88-4.36-5.95
			c-2.09-0.24-4.2-0.08-6.29,0.12c-0.16-1.26-0.32-2.52-0.49-3.78c-2.48,0.33-5.52-0.73-6.23-3.37c0.22-1.54,1.97-1.93,3.08-2.7
			c0.26,0.12,0.79,0.41,1.06,0.55c1.08-0.55,2.5-0.61,3.33-1.52c-0.14-0.96-0.39-1.89-0.73-2.8c-1.46-0.37-1.36,1.26-1.73,2.19
			c-1.66,1.3-3.35,0.29-4.81-0.77c-1.34,1.16-1.75,3-2.6,4.5c3.19,2.27,3.19,6.52,1.83,9.82c-1.2,1.04-2.74,1.56-4.16,2.19
			c-2.13-0.53-4.28-1.26-5.72-3.02c0.55,1.4,0.26,2.9-0.91,3.9c-2.78,0.91-6.05-2.11-8.36,0.3c-2.44-1.62-4.87-3.33-7.73-4.1
			c-1.18,0.61-2.38,1.18-3.57,1.73c-2.25,2.82-0.59,6.17,0.43,9.13c0.81,2.46,3.69,3.69,3.8,6.52c-2.19-0.24-4.34-1-6.56-0.96
			c-1.93,0.51-3.47,1.89-5.13,2.92c-1.62,0.85-1.93,2.8-2.62,4.3c3.13,1.4,7.19-2.01,9.44,1.24c0.12,3.07,2.25,5.68,1.85,8.83
			c-0.16,3.13,1.87,5.83,4.4,7.41c0.61,3.53,1.85,6.92,2.27,10.47c0.91,0.97,1.68,2.07,2.25,3.29c1.48,1.77,3.55,3.51,3.45,6.03
			c-0.04,4.43,2.52,8.16,4.4,11.95c1.36,2.54,4.59,5.03,2.58,8.12c1.79,3.9,4.65,7.55,8.91,8.83c1.06,0.16,2.13,0.38,3.17,0.61
			c1.04,0.81,2.21,1.54,2.5,2.94c-1.12,0.45-2.23,0.89-3.37,1.3c1.46,1.36,2.44,3.06,3.17,4.89c1.91,1.42,3.11,3.45,4.02,5.62
			c0.97-0.2,1.97-0.41,2.94-0.59c0.55,0.41,1.1,0.83,1.66,1.26c0.53,1.89,2.05,3.13,3.47,4.36c2.33,3.17,5.83,5.22,9.46,6.56
			c2.21,1.75,3.98,4.06,5.56,6.37c-0.65,0.04-1.97,0.08-2.64,0.1c-0.35,0.37-1.06,1.06-1.42,1.42c0.67,3.02,2.78,5.26,5.07,7.17
			c0.3,2.98,0.16,6.01-0.16,8.99c-0.81,0.57-1.62,1.18-2.44,1.81c-1.08-0.75-2.17-1.48-3.27-2.21c-0.43,1.6-0.81,3.23-1.2,4.85
			c1.22,0.79,2.41,1.62,3.63,2.48c0.08,0.42,0.26,1.32,0.35,1.75c-0.2,0.3-0.57,0.91-0.77,1.22c1.75,2.88,3.73,5.85,3.27,9.4
			c3.55,3.55,8.3,6.25,10.27,11.1c0.32,2.76-0.12,5.54-0.02,8.32c1.22,1.2,2.48,2.35,3.73,3.53c1.77,0.1,4.22,1.58,5.38-0.51
			c-2.37-3.23-3.43-8.14-0.75-11.49c-0.16-0.53-0.47-1.6-0.63-2.13c1.1-2.33,0.97-4.91,0.67-7.39c0.85,0.41,1.73,0.81,2.6,1.22
			c1.08,0.79,1.83-0.75,2.58-1.28c-0.55-1.46-1.42-2.9-1.28-4.51C345.24,546.04,345.89,545.53,346.52,545z M519.93,524.71
			c1.89,0.12,3.86,0.61,5.66-0.22c-0.04,0.79-0.08,1.6-0.16,2.4c-0.97,0.71-2.13,1.08-3.21,1.58c0.63,0.16,1.85,0.49,2.48,0.65
			c0.38,1.06,0.2,2.21,0.34,3.33c-2.21,0.08-4.14-1.16-6.15-1.89c0.51-0.77,1-1.54,1.5-2.31C519.77,527.1,519.6,525.92,519.93,524.71
			z M269.43,401.16c-1.06,1.68-2.7,2.88-4.12,4.24c-2.13-1.85-4.91-3.88-4.83-7.02c0.06-1.32-0.3-2.92,0.69-3.98
			c1.34-0.95,3.06-0.65,4.61-0.79c1.24,1.4,2.46,2.84,3.71,4.24C269.51,398.95,269.65,400.07,269.43,401.16z M330.52,535.65
			c0.1-2.15,0.02-4.3-0.12-6.43c1.48-0.77,3.1-1.26,4.77-1.2c0.63,3.76,0.24,7.65,0.75,11.45L330.52,535.65z" />
                            <path class="map-sea" id="khazar" d="M445.6,151.38c-0.81-8-4.38-15.47-4.51-23.59c-3.29-5.72-1.81-12.5-1.56-18.75
			c0.02-2.64,1.87-5.03,1.2-7.69c-0.53-3.31-1.28-6.66-0.73-10.03c0.32-2.58,2.01-4.73,2.35-7.29c0.22-1.3,0.59-2.56,1.04-3.8
			c-0.1-2.35-1.22-4.45-2.98-5.99c-0.53,0.04-1.56,0.12-2.07,0.16c-2.74-1.62-2.86-5.38-6.05-6.47c-0.51-1.58-0.89-3.67-2.64-4.34
			c-2.44-0.81-4.85-1.62-7.18-2.66c-0.1,1.89-0.14,3.78-0.14,5.64c-0.26,0.31-0.79,0.87-1.05,1.18c0-1.89-0.02-3.75-0.08-5.64
			c-1.22-1-1.95-2.72-0.83-4.1c1.99-2.88,2.84-6.53,5.7-8.73c-0.81,1.72-1.58,3.47-2.15,5.32c2.42-0.3,4.91-0.1,7.27-0.81
			c1.44-1.52-0.87-2.72-1.6-3.96c-2.66-2.7,2.35-5.6,0.55-8.52c-0.67-2.31-3.51-0.83-5.11-0.69c-3.21-1.71-7.14-1.97-10.21,0.14
			c0.89,2.96,3.19,5.11,4.57,7.79c-2.56-1.79-4.18-4.5-5.89-7.04c-0.75-1.14-2.13-1.6-2.88-2.72c-0.97-2.31,0.39-4.87-0.57-7.18
			c-0.77-1.81-0.72-5.05-0.12-7.07H345.4c-0.04,1.67-0.06,3.85-0.08,5.52c-2.23-2.15-4.73-4.38-7.83-5.09
			c-2.7,0.16-5.56,0.35-7.96,1.77c-2.78,1.48-5.87,2.46-8.34,4.49c-2.4,2.39-0.04,6.58-3,8.73c-0.04,1.81-0.04,3.61-0.02,5.42
			c-1.32,2.54-3.59,4.77-3.59,7.82c-0.37,2.07,1.71,3.31,2.7,4.83c-0.14,1.69-0.32,3.47-2.03,4.28c-0.41-0.38-1.22-1.14-1.62-1.52
			c-1.64,2.46-1.73,5.44-1.56,8.3c-0.95,1.34-1.91,2.66-2.88,4c-0.91,0.04-1.83,0.08-2.74,0.1c0.39-1.34,1.4-2.29,2.27-3.33
			c-1.4-1.18-2.11-2.94-3.37-4.24c-2.46,1.48,0.28,5.01-1.77,7c-0.04,0.79-0.08,1.58-0.12,2.39c-1.1,0.97-2.21,1.95-3.35,2.86
			c0.26,1.32,0.65,2.64,1.18,3.88c0.04,3.81,0.16,7.63-0.08,11.43c-0.59,7.35-0.2,14.71,0.79,22c1.64,5.2,6.45,8.28,11.24,10.23
			c3.94,1.34,8.12,1.79,12.2,2.54c1.26,0.38,2.42-0.31,3.59-0.63c2.35,1.99,5.4,2.6,8.28,3.43c0.18,0.34,0.59,1.04,0.79,1.38
			c-0.41,2.09-0.08,4.26,1.03,6.11c1.58,3.19,5.16,4.42,7.79,6.56c3.84,3.09,7.59,6.33,11.77,8.95c3.47,1.73,7.25,2.86,11.06,3.55
			c3.13,0.69,6.03,2.21,9.23,2.64c6.09,1.14,12.24-0.31,18.1-1.93c4.22-0.65,8.52-0.87,12.71-1.76c5.76-2.05,11.51-4.87,17.76-4.71
			c5.18-0.04,10.37-1.12,15.51-0.2c-2.94,0.43-5.95,0.2-8.91,0.59c-0.12,1.18,1.16,1.5,2.05,1.54c2.42,0.12,4.87,0.16,7.25-0.43
			C444.3,152.74,445.87,152.72,445.6,151.38z M419.67,83.69c-1.73-2.09-1.58-5.01-2.25-7.51c-0.06-1.4-0.73-4.3,1.56-3.86
			C418.57,76.16,420.17,79.88,419.67,83.69z" />
                        </svg>
                        <svg class="map-island">
                            <path class="map-island" d="M267.93,400.45c-0.72,1.15-1.85,1.97-2.82,2.9c-1.46-1.26-3.36-2.65-3.3-4.8c0.04-0.9-0.21-2,0.47-2.72
			c0.91-0.65,2.09-0.44,3.15-0.54c0.85,0.96,1.68,1.94,2.54,2.9C267.99,398.94,268.08,399.7,267.93,400.45z" />
                            <path class="map-island" d="M520.65,525.72c1.31,0.08,2.75-0.04,4.09-0.27c-0.09,0.43,0.08,0.62,0.03,1.17
			c-0.68,0.49-2.81,1.5-3.56,1.85c0.44,0.11,2.4,0.99,2.84,1.1c0.27,0.73,0.06,0.74,0.16,1.51c-1.53,0.05-2.58-0.63-3.98-1.14
			c0.35-0.54,0.52-1.12,0.87-1.65C520.66,527.5,520.43,526.56,520.65,525.72z" />
                            <path class="map-island" d="M331.2,534.68c0.07-1.41,0.01-2.83-0.08-4.23c0.97-0.51,2.04-0.83,3.13-0.79c0.41,2.47,0.16,5.03,0.49,7.52
			L331.2,534.68z" />
                        </svg>

                        <!-- Start Province -->
                        <a class="map-link" xlink:href="#khorasan-r">
                            <svg class="map-province khorasan-r" id="svg-object-khorasan-r">
                                <path class="map-path" id="path-khorasan-r" d="M651.38,201.47
			c2.54-3.43,3.84-7.55,4.99-11.61c-1.44-0.71-2.58-1.81-3.15-3.33c1.54-2.48,1.44-5.48,0.61-8.16c-0.97-0.26-1.93-0.51-2.84-0.87
			c-0.69-2.07,1.36-3.63,1.62-5.6c0.3-3.13-1.4-5.95-2.62-8.71c0.61-2.54,0.63-5.16,0.79-7.75c-0.63-0.63-1.24-1.28-1.83-1.91
			c-6.29,0.65-12.6,0.65-18.9,1.18c-1.26,0-2.7,0.28-3.71-0.63c-1.12-1.72-1.56-3.94-3.39-5.13c-2.86-1.89-3.53-5.46-5.5-8.08
			c-3.8,0.61-6.64-3.13-10.43-2.4c-1.44,0.51-1.93-1.01-2.66-1.89c-1.1,0.02-2.27,0.41-3.27-0.2c-0.59-0.69-0.57-1.68-0.83-2.5
			c-0.95-0.81-2.03-1.5-2.82-2.46c-0.79-1.81-0.73-3.84-1.06-5.76c-0.97,0.02-2.07,0.43-2.94-0.22c-2.35-1.4-4.57-3.04-6.82-4.59
			c-1.5-0.06-2.98-0.22-4.44-0.53c-1.04,0.61-2.05,1.24-3.13,1.77c-1.54-0.3-2.72-1.46-4.02-2.25c-0.73,0.89-1.24,2.09-2.33,2.58
			c-1.58,0.22-3.15-0.45-4.67-0.71c0.73,1.22,1.58,2.39,2.13,3.71c0.24,2.17-0.37,4.32-0.24,6.52c0.1,2.27,2.72,3.86,2.05,6.23
			c-0.97,2.25-3.8,2.15-5.78,2.86c-0.14,2.35,0.93,4.4,1.91,6.45c0.67,3.45-3.59,3.88-5.74,5.28c0,2.29,0.24,4.63-0.2,6.88
			c-0.85,1.93-2.84,3.74-5.09,3.35c-4.1-0.47-7.55-2.98-10.55-5.64c-5.28-4.28-12.48-3.78-18.85-3.69c-2.11-0.1-4.16,0.89-5.42,2.6
			c1.54,2.07,3.51,4.45,2.78,7.22c-0.16,2.19-2.07,3.63-2.68,5.62c-0.02,3.84,0.57,7.67,1.02,11.49c0.26,2.01-0.49,4.4,1.16,5.99
			c1.44,2.11,3.96,3.29,5.2,5.52c0.93,3.69,1.48,7.75,0.22,11.45c-1.2,1.89-3.49,2.68-4.99,4.28c-2.33,2.48-5.36,4.12-7.79,6.49
			c-1.95,1.99-4.89,1.97-7.47,2.44c-2.09,3.19-4.67,6.01-6.94,9.05c5.62,0.71,11.55,0.89,16.95-1.05c4.14-2.48,5.97-7.41,9.91-10.15
			c4.3-3.25,10.25-3.57,15.24-1.91c3.78,1.4,5.54,5.6,5.85,9.36c0.08,0.37,0.12-0.3,0.12,0.1c0.29,0.09,0.57,0.17,0.83,0.23
			c1.07,0.26,2.16,0.26,2.11,1.33c-0.05,1.21,1,2.26,2.21,3.46c0.94,0.94,2.12,2.1,2.2,2.96c0.28,2.72,1.32,4.69,2.17,6.27
			c0.4,0.74,0.74,1.38,0.94,1.98c0.84,2.5,5.05,3.16,7.16,3.16c0.32,0,0.6-0.02,0.84-0.04c0.42-0.05,0.84-0.08,1.24-0.08
			c3.02,0,4.89,1.35,5.92,2.45c2.5-1.03,4.38,0.08,6.97-0.67c5.48-1.4,11.1-0.47,16.64-0.24c4.02,0.41,8.08-0.04,12.1,0.51
			c4.45,0.45,8.93,2.03,12.22,5.18c4.18,0.04,7.37-2.96,10.59-5.24c3.1-2.19,4.71-5.99,7.96-8.04c1.69-0.29,3.43-0.2,5.11-0.55
			c-1.85-2.31-4.04-4.32-5.99-6.56c1.4-0.81,2.98-1.2,4.59-1.4c0.18-0.61,0.39-1.22,0.59-1.83c0.69-0.33,1.38-0.67,2.05-1.06
			c0.63-2.33,1.48-4.59,2.17-6.9c0.04-3.19,0.39-6.33,1.32-9.4C651.06,206.06,650.73,203.65,651.38,201.47z" />
                                <path class="map-point" id="point-khorasan-r" d="
        M651.38,201.47
        m -60, 10
      a 8,8 0 1,0 16,0
        a 8,8 0 1,0 -16,0
    " />

                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khorasan-j">
                            <svg class="map-province khorasan-j">

                                <path class="map-path" id="path-khorasan-j" d="M651.59,326.94c-0.79-2.86-1.22-5.82-1.18-8.79
			c0.06-2.17,0.89-4.24,0.99-6.39c-0.41-3.15-1.73-6.05-2.74-9.01c-2.44-6.84-4.85-13.68-7.33-20.52c-1.02-2.54-0.93-5.81,1.46-7.55
			c2.25-1.66,3-4.53,5.17-6.27c0.39-1.3,0.75-2.62,1.12-3.94c-3.77-0.57-8.56,0.06-11.16-3.35c-1.75-1.81-0.51-4.36,0.65-6.11
			c-0.89-3.73-1.85-7.49-1.42-11.35c-3.27,2.35-6.52,5.05-10.47,6.17c-0.71,0.28-1.36,0.24-1.97,0.03c0,0-0.01,0-0.01,0l-0.52,0
			l-0.3-0.29c-0.11-0.11-0.23-0.19-0.34-0.29c-0.77-0.49-1.51-1.12-2.25-1.54c-4.22-2.98-9.58-3.03-14.53-3.27
			c-5.5-0.1-10.98-0.49-16.48-0.75c-3.55,0-6.98,0.97-10.47,1.52c-0.32,0.06-0.53-0.09-0.68-0.37c-0.4,0.15-0.87,0.42-1.5,0.95
			l-0.85,0.7l-0.67-0.87c-0.86-1.12-2.84-3-6.4-3c-0.4,0-0.82,0.03-1.24,0.08c-0.23,0.03-0.52,0.04-0.84,0.04
			c-2.11,0-6.32-0.66-7.16-3.16c-0.2-0.59-0.54-1.23-0.94-1.97c-0.84-1.58-1.89-3.55-2.17-6.27c-0.09-0.86-1.26-2.02-2.2-2.96
			c-1.21-1.21-2.27-2.25-2.21-3.46c0.04-1.06,0.02-1.07-1.05-1.33c-0.39-0.1-0.84-0.2-1.34-0.4l-0.62-0.24l-0.05-0.66
			c-0.26-3.24-1.74-7.15-5.11-8.43c-0.21-0.05-0.4-0.09-0.55-0.14c-4.3-1.08-9.28-1.04-13.07,1.54c-4.12,2.6-6.09,7.43-9.99,10.25
			c-0.21,0.1-0.42,0.19-0.63,0.28c-0.01,0.01-0.03,0.02-0.04,0.03l-0.18,0.09c-0.04,0.01-0.08,0.02-0.11,0.03
			c-5.47,2.24-11.65,1.64-17.44,1.3c-5.34,5.2-5.38,13.54-10.39,19c-3.33-0.12-6.68-0.08-10.01-0.04c1.62,7.9,1.55,16.38,1.75,24.38
			c0.33,0.48,4.71,4.1,4.71,4.1l2.39,4.54c0,0,3.1,2.15,4.3,4.3c1.19,2.15,1.19,1.43,4.3,1.67c3.1,0.24,3.1,3.34,4.3,4.77
			c1.19,1.43,2.37,1.14,3.22,2.73c0.86,1.59,0.86,4.16,1.83,5.14c0.98,0.98,3.06,2.08,4.04,3.3c0.98,1.22,0.86,3.18,1.59,4.16
			c0.73,0.98,1.96,1.1,3.18,2.08c1.22,0.98,2.33,3.18,2.57,6c0.24,2.82,1.59,3.43,2.57,4.89c0.41,0.61,0.91,3.33,1.39,5.53
			c2.64-0.24,4.5-0.59,7.12-1.01c2.54,0.99,5.11,1.95,7.79,2.5c7.67,1.69,15.38,3.25,22.91,5.5c0.03-0.21,0.48-0.43,1.21-0.65
			c-0.04,0.29-0.08,0.59-0.13,0.88c3.61,2.25,7.77,3.65,11.08,6.45c6.23,5.24,12.5,10.41,18.79,15.59
			c6.33,6.19,12.08,12.95,18.35,19.22c4.3-2.23,8.99-4.55,11.37-9.03c0.83-3.29,1.22-6.7,1.7-10.05c3.21-0.69,6.47-1.2,9.72-1.7
			c1.14-2.11,1.93-4.46,3.43-6.37c4.73-3.08,9.58-6.01,14.39-8.97c0.04-1.95-0.06-3.92-1.36-5.48
			C651.27,329.46,652.14,328.24,651.59,326.94z" />

                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kerman">
                            <svg class="map-province kerman">
                                <path class="map-path" id="path-kerman" d="M522.24,325.05c3.31-0.14,6.6-1.14,9.9-0.81
			c8.57,3.17,17.76,4,26.47,6.7c4.97,1.28,9.56,3.65,13.88,6.37c4.89,3.92,9.6,8.04,14.49,11.97c8.77,6.72,15.67,15.43,23.24,23.36
			c1.28,1.18,2.88,1.91,4.14,3.11c1.3,1.26,1.28,3.17,1.5,4.83c1.2,12.93,1.87,25.9,2.7,38.85c1.48,2.62,2.84,5.32,3.98,8.12
			c-1.66,1.5-3.82,3.27-3.33,5.78c0.49,1.81,1.91,3.21,2.74,4.87c1.89,3.17,1.04,7,1.22,10.49c-4.75,1.32-10.33-1.64-14.55,1.79
			c-2.11,1.34,0.08,3.82,0.89,5.36c0.04,1.81,0.06,3.61,0.06,5.42c-3.51,0.04-5.66,2.98-7.06,5.85c-1.42,5.66,0.69,11.51-0.35,17.21
			c-0.47,1.91-1.77,3.61-1.54,5.68c0.16,2.88-0.49,5.7-0.65,8.57c0.57,1.32,1.44,2.52,1.97,3.88c0.28,2.01-0.16,4.1,0.41,6.07
			c1.4,1.93,3.41,3.39,4.65,5.48c0.63,1.66,0.57,3.53,0.41,5.3c-3.35,1.64-7.45,0.71-10.96-0.04c-0.35-3.41-3.31-5.5-6.15-6.84
			c-2.9-1.26-6.11-1.3-9.21-1.36c-3.13-0.06-4.87-3.09-7.55-4.24c-3.75-1.4-7.14-3.63-11.08-4.55c-1.99-1.6-3.39-3.98-5.74-5.22
			c-4.1-2.5-6.52-6.76-9.78-10.15c-0.57-2.21-0.63-4.53-1.12-6.76c2.01-2.42,5.16-3.61,6.88-6.29c-1.52-1.06-2.15-2.76-2.9-4.36
			c-2.72-1.32-5.89-1.54-8.61-2.94c-0.06-3.31,0.22-6.88-1.3-9.92c-1.34-1.1-3.15-1.48-4.83-1.71c-2.56,0.63-4.65,2.35-6.8,3.82
			c-1.44,0.91-2.74,2.48-4.61,2.31c-2.52,0.08-5.28-0.04-7.33-1.71c-1.6-1.28-3.29-2.46-4.93-3.67c-1.18-0.77-0.91-2.35-1-3.57
			c0.08-3.84-0.18-7.65-0.49-11.47c-0.08-1.64-0.91-3.11-1.81-4.42c-2.11,0.18-4.51-0.3-6.31,1.1c-2.96,1.73-5.42,4.49-8.87,5.28
			c-3.37,1.1-7.53-0.2-9.32-3.37c-0.43-4.28,1.99-8.89-0.08-12.93c-4.4-5.36-8.87-10.66-13.31-15.99c-1.91-2.52-5.36-1.97-8.14-2.23
			c0.1-4.14-0.35-8.28-0.47-12.44c-0.3-3.06-0.26-6.21-1.32-9.13c-0.65-1.79-2.9-2.21-3.67-3.84c0.65-2.94,2.94-5.14,4.02-7.9
			c-0.43-5.87-2.74-11.41-3.71-17.19c2.13-0.96,4.22-2.17,6.58-2.54c2.66,0.39,5.03,1.89,7.69,2.17c3.39-0.95,6.56-2.62,9.88-3.77
			c7.31-2.68,14.53-5.83,20.8-10.51c1.93-1.36,2.43-3.78,3.08-5.89c2.23,0.53,4.47,1.08,6.68,1.69c1.52-0.63,2.92-1.52,4.12-2.68
			c2.09-1.95,4.63-3.51,6.23-5.91C522.36,328.44,522.2,326.74,522.24,325.05z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#azarbaijan-sh">
                            <svg class="map-province azarbaijan-sh">
                                <path class="map-path" id="path-azarbaijan-sh" d="M259.2,55.38c1.62,1.4,4.08,2.62,4.14,5.03
			c0.22,4.75-0.26,9.54,0.28,14.27c0.41,2.31-1.18,4.32-1.28,6.56c0.28,1.3,0.77,2.52,1.22,3.73c-2.23,3.49-7.02,5.89-6.66,10.57
			c-0.1,2.05,2.5,2.05,3.86,2.78c2.5,1.22,5.13,1.91,7.9,2.19c1.42,0.12,0.97,1.91,1.2,2.86c0.1,2.84,1.14,5.56,1.6,8.36
			c1.85,0.67,3.94,0.97,5.46,2.33c-0.53,2.25-3.13,3.37-3.53,5.68c-0.53,3.25,2.66,5.28,3.98,7.92c2.27,1.75,2.11,4.79,3.67,7.02
			c-1.83,0.67-3.59,1.54-5.16,2.7c-2.52,0.26-4.81-0.75-7.14-1.46c-1.52-0.43-2.37,1.08-3.29,1.99c0,0.59,0,1.77-0.02,2.35
			c-2.27-1.16-4.57-2.29-6.98-3.15c-3.65,1.24-3.43,6.39-7.1,7.53c-1.79,0.45-3.23,1.52-4.28,3.04c-1.68-0.61-3.47-1.03-5.12-1.8
			c-2.92-1.85-4.71-4.87-6.78-7.53c-1.91-1.81-4.34-0.39-6.31,0.43c-1.12-1-1.99-2.84-3.74-2.68c-1.5,0.39-2.25,1.91-3.23,2.96
			c-0.47,0.14-1.42,0.43-1.91,0.57c-1.36-1.89-2.72-3.8-4.36-5.46c-1.62-1.79-4.22-1.83-6.35-2.6c-0.41-1.38-0.55-2.8-0.75-4.22
			c1.5,0.26,2.98,0.51,4.49,0.75c0.67-1.46,2.27-1.69,3.47-2.5c0.67-1.18,1.1-2.48,1.62-3.74c0.53-0.47,1.06-0.93,1.56-1.4
			c-1.48,0.28-2.96,0.63-4.47,0.89c-0.79-1.69-0.75-4.32-3-4.79l-0.02-0.69c1.18,0,2.33,0,3.51,0.02c0.04-1.32,0.06-2.64,0.1-3.96
			c-0.83-0.02-1.66-0.04-2.5-0.06c-0.67-2.09-2.98-1.89-4.73-2.29c-0.12-0.39-0.34-1.14-0.47-1.52c-1.01-0.41-2.01-0.83-3-1.24
			c-0.26-1.74-0.53-3.49-0.77-5.24c0.38-0.22,1.16-0.69,1.54-0.93l0.81-0.49c0.16-0.1,0.49-0.3,0.65-0.41
			c0.37-2.44,0.26-4.93,0.2-7.39c-0.39-0.18-1.18-0.53-1.56-0.71c-0.12-0.31-0.37-0.93-0.49-1.26c-1.36-0.53-2.6-1.3-3.65-2.31
			l-0.06-0.04c-0.02-0.04-0.08-0.08-0.12-0.1l-0.08-0.06c-1.06-1.16-2.58-1.52-4-2.01c0.85-0.81,1.79-1.58,2.46-2.58
			c-0.04-4.06-2.72-7.57-3.27-11.51c0.87-1.1,2.46-1.26,3.65-1.89c1.79-0.57,3.02-2.03,4.32-3.29c1.89,1.1,3.73,2.52,6.05,2.39
			c3.02-0.12,4.91,2.88,7.81,3.09c2.25,0.14,4.36,0.99,6.54,1.52c1.79,0.42,3.23-0.87,4.63-1.75c1.89,0.61,3.9,1.48,5.91,0.87
			c3.57-1.26,6.31-4.24,7.9-7.61c1.18-2.34,4.06-1.6,6.09-2.38c1.26-0.97,2.01-2.42,2.86-3.74C254.74,57.81,257.11,56.86,259.2,55.38
			z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#azarbaijan-gh">
                            <svg class="map-province azarbaijan-gh">
                                <path class="map-path" id="path-azarbaijan-gh" d="M181.94,38.15
			c0.71-0.22,1.4-0.45,2.11-0.67c1.99,1.95,4.06,3.78,6.15,5.6c1.34,1.2,1.26,3.17,1.75,4.77c0.18,1.62,1.62,2.58,2.6,3.73
			c1.48,1.4,1.22,3.76,2.44,5.3c1.52,1.3,3.49,1.85,5.34,2.5c1.16,2.01,1.81,4.24,1.87,6.56c-2.25,2.29-5.18,3.59-8.18,4.61
			c-0.18,0.39-0.51,1.2-0.69,1.6c1.28,3.49,3.06,6.86,3.71,10.55c-1.01,1.87-3.04,2.86-4.3,4.5c-1.3,2.05-2.21,4.47-1.54,6.88
			c1.48-0.02,2.98-0.02,4.47-0.02c-0.06,0.43-0.22,1.26-0.28,1.67l-0.1,0.43c-1.1-0.08-1.66,0.43-1.68,1.52l-0.57,0.22
			c-0.75,0.3-1.52,0.61-2.27,0.91c0.28,1.85-0.35,4.16,1.06,5.66c1.2,0.34,2.44,0.55,3.67,0.81c0.14,6.51,0.73,13.01,0.79,19.52
			c0.08,1.71,0.3,3.74,1.85,4.77c2.48,1.77,5.72,1.68,8.36,3.13c2.05,0.47,4.4,0.43,6.09,1.89c1.97,1.76,3.41,4.02,4.95,6.17
			c1.08-0.24,2.13-0.49,3.21-0.75c0.77-1.08,1.54-2.15,2.46-3.11c1.4,0.71,2.39,1.99,3.55,3.04c1.42-0.55,2.86-1.1,4.26-1.68
			c2.82,1.32,3.51,4.65,5.78,6.58c1.79,2.09,4.44,2.86,7,3.55c1.4,2.64,3.07,5.13,4.67,7.65c0.83,2.11,0.06,4.63,1.12,6.72
			c1.42,0.95,3.25,0.63,4.83,0.91c-1.04,2.74-4.51,1.68-6.6,3.11c-4.55,2.92-10.7-0.63-12.14-5.4c-5.09-1.52-10.47-0.61-15.61,0.16
			c-2.52-0.1-3.63-3.96-6.29-3.31c-1.7,0.93-3.33,2.05-4.73,3.41c-0.95,1.26-1.16,2.9-1.71,4.36c-2.05,0.02-4.22-0.22-6.17,0.59
			c-1.4,1.12-1.77,3-2.72,4.46c-1.91,0.16-3.82,0.28-5.68,0.71c1.83-2.84,0.24-6.07-0.53-8.97c0.99-2.44-0.26-4.57-1.91-6.31
			c-1.01,0.35-2.01,0.69-3.02,1.04c-0.69-1.6-1.44-3.19-2.01-4.81c0.57-1.71,1.77-3.17,2.05-4.95c-0.77-2.76-3.27-4.61-6.03-5.03
			c1.58-2.05,1.52-4.73,1.64-7.18c0.24-1.64-1.7-2.07-2.68-2.94c0.14-1.18,0.22-2.37,0.41-3.55c0.47-1.52,1.38-3.17,0.63-4.75
			c-1.58-2.11-3.63-3.82-5.8-5.28c1.34-2.17,1.32-4.73-0.18-6.82c0.63-1.02,1.54-1.95,1.68-3.19c-0.32-1.91-2.4-2.17-3.82-2.92
			c-1.34-0.55-2.17-1.81-3.23-2.74c-1.1-0.43-2.27-0.65-3.39-0.93c0.22-4.89,5.48-7.16,6.27-11.85c0.87-0.75,1.93-1.34,2.52-2.33
			c0.26-1.2,0.08-2.44,0.08-3.65c-1.73-0.1-3.47-0.04-5.2,0.1c0.28-1.97,1.02-3.82,1.62-5.68c0.37-1.77-0.63-3.37-1.02-5.01
			c-0.02-1.79,0.73-3.45,1.18-5.13c-0.87-0.73-1.75-1.46-2.62-2.15c-0.95-3.41,0.83-6.6,1.64-9.82c-0.99-0.53-1.97-1.03-2.98-1.54
			c-0.06-2.21-0.55-4.36-1.48-6.35c2.94-0.14,5.76,0.73,8.63,1.24c2.19-1.77,3.21-4.34,2.8-7.14c0.41-0.49,0.81-0.97,1.24-1.48
			C181.47,40.46,181.71,39.3,181.94,38.15z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ardebil">
                            <svg class="map-province ardebil">
                                <path class="map-path" id="path-ardebil" d="M274.1,46.89c1.14-0.14,2.25-0.3,3.39-0.47
			c3.15,3.27,6.35,6.45,9.34,9.84c-2.33,1.56-5.28,2.03-7.18,4.24c0.2,4.16,4.47,6.07,6.13,9.52c-2.07,0.49-4.2,0.63-6.27,1.08
			c-1.64,1.3-2.7,3.17-3.82,4.91c2.07,2.33,4.71,4.12,6.56,6.68c1.18,1.6,2.98,3.02,5.09,2.6c0.71,2.64,2.6,4.61,4.3,6.64
			c0.91,0.99,0.1,2.38,0.06,3.53c1.26,1.4,2.96,2.31,4.26,3.69c0.12,4.38-3.19,7.67-4.99,11.37c-1.26,4.2-0.24,8.57,0.32,12.81
			c0.91,3.55,3.31,6.43,5.48,9.3c1.64,2.11,2.15,4.79,2.58,7.35c-0.83,0.2-1.64,0.39-2.48,0.57c-2.27-1.46-4.91-0.59-7.41-0.71
			c-1.03-0.85-1.79-1.99-2.82-2.84c-1.4-1-3.25-1.4-4.3-2.84c-1.42-1.46-1.5-3.63-2.48-5.32c-2.05-2.09-3.43-4.67-5.32-6.88
			c-0.91-3.25,2.46-5.2,3.82-7.71c-1.52-1.93-3.82-2.76-6.13-3.25c-0.59-3.05-1.42-6.05-1.44-9.17c0.02-1.46-1.38-2.37-2.7-2.37
			c-3.73-0.18-6.9-2.33-10.43-3.29c0.34-1.73,0.43-3.63,1.71-4.97c1.79-2.07,4.02-3.77,5.26-6.27c-0.49-1.62-1.66-3.35-0.85-5.05
			c0.59-1.99,1.22-4.04,0.89-6.13c-0.61-4.85,0.14-9.78-0.34-14.63c-0.89-2.31-3.17-3.65-4.83-5.38c2.17-0.51,4.73-0.16,6.45-1.79
			C268.38,49.73,271.99,49.55,274.1,46.89z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#sistan">
                            <svg class="map-province sistan">
                                <path class="map-path" id="path-sistan" d="M648.93,339.58c1.54-0.89,3.06-2.38,5.01-1.99
			c8.34,0.63,16.7,1.2,25.07,1.83c2.17,0.12,1.72,2.92,2.31,4.42c0.49,0.45,0.99,0.87,1.48,1.32c0.1,2.21,0.85,4.3,1.83,6.25
			c-1.64,1.99-0.59,4.87-1.91,6.96c-8.38,11.93-17.13,23.63-25.31,35.7c3.88,4.93,8.5,9.21,12.62,13.96
			c1.03,1.24,2.23,2.29,3.49,3.29c0.08,1.85-0.18,3.98,1.64,5.11c0.12,2.74,3.45,3.27,4.3,5.64c1.22,2.96,2.21,6.11,4.38,8.54
			c1.28,1.64,3.06,2.72,4.69,3.96c2.07,1.81,3.82,4.1,6.39,5.26c4.38,1.14,8.89,1.85,13.27,3c1.56,0.39,2.82,1.44,4.16,2.29
			c0.77,1.28,1.56,2.54,2.58,3.65c2.15-0.14,4.24-0.75,6.37-1.18c-0.3,3.73-1.05,7.65,0.35,11.26c1.68,4.32,2.11,8.97,3,13.5
			c0.41,1.54-0.26,3.02-0.77,4.47c-0.95,2.17,0.24,4.47,0.47,6.68c2.21,0.55,4.57,1.4,6.88,0.75c2.68-0.73,5.64-0.69,8.04-2.27
			c0.53,0.87,1.66,1.73,1.12,2.88c-0.95,2.6-1.01,5.34-0.89,8.08c0.3,0.34,0.93,1.01,1.24,1.36c-0.79,0.43-1.56,0.87-2.33,1.3
			c0.02,2.46,0.02,4.91,0.08,7.35c-5.28-1.32-11-0.47-15.87,1.87c-2.52,1.22-5.34,1.46-8.04,2.03c-0.2,0.32-0.59,0.99-0.77,1.32
			c-3.15,0.53-3.45,3.96-4.22,6.43c-1.3-0.14-2.56-0.3-3.81-0.49c-0.12,0.55-0.33,1.66-0.45,2.21c-2.8,2.25-8.18,1.71-8.95,5.99
			c-0.41,4.51-0.75,9.03-0.95,13.56c-0.57-0.14-1.7-0.45-2.29-0.59c-0.79,1.85-0.32,3.82-0.2,5.74c-1.73,4.95,0.39,10.17-0.55,15.22
			c-0.97,0.49-1.97,0.93-2.86,1.58c-1.02,1.06-0.71,2.58-0.65,3.92c-2.48,0.28-4.99,0.14-7.45-0.26c-0.95-0.73-1.79-1.77-3.04-1.91
			c-5.46-1.02-11.04-1.14-16.46-2.38c-0.59-2.13-1.12-4.99-3.75-5.34c-2.68-1.04-6.39,0.61-6.09,3.82c-1.26-0.61-2.42-1.66-3.88-1.62
			c-1.12,0.43-1.85,1.44-2.72,2.21c-1.12-0.83-2.19-1.85-3.57-2.25c-1.79-0.24-3.23,0.99-4.71,1.79c-2.13-3.29-6.35-2.03-9.54-1.4
			c-1.87-1.04-3.65-2.98-5.99-2.46c-3.51,0.89-6.66,2.8-10.15,3.8c0.36-4.18,0.39-8.48-1.1-12.46c-0.91-1.6-2.52-2.66-3.59-4.14
			c-0.83-2.52-1.02-5.18-1.73-7.71c-0.33-2.11-2.6-3-3.59-4.75c-1.24-2.4-3.84-3.61-5.18-5.95c3.61,0.22,7.35,0.93,10.9-0.04
			c1.83-0.97,1.42-3.23,1.3-4.91c-0.16-3.53-3.21-5.8-5.46-8.12c0.06-1.62,0.24-3.23,0.16-4.83c-0.14-2.09-2.44-3.55-1.95-5.72
			c0.41-2.84,0.33-5.7,0.49-8.57c0.51-1.93,1.66-3.71,1.68-5.76c0.33-4.55-0.65-9.05-0.3-13.6c0.14-2.38,1.81-4.3,3.41-5.89
			c1.26-0.51,2.58-0.79,3.84-1.3c0.87-3.63,0.02-7.31-1.83-10.49c3.43-2.54,7.81-1.52,11.75-1.32c1.46,0.16,3.35-0.18,3.78-1.85
			c0.28-2.58,0.26-5.18-0.08-7.73c-0.43-3.47-4.14-5.62-3.9-9.28c1.16-1.14,2.39-2.17,3.45-3.39c-0.37-3.53-3.23-6.13-3.94-9.52
			c-1.1-13.38-1.4-26.83-2.98-40.17c-0.14-2.42-2.23-3.88-3.88-5.3c2.09-1.24,4.36-2.17,6.35-3.61c1.62-1.62,3.27-3.25,4.75-5.01
			c1.04-3.31,1.2-6.84,1.85-10.25c3.15-0.49,6.31-1.02,9.46-1.58c1.18-2.19,1.95-4.67,3.57-6.58
			C642.01,343.6,645.6,341.82,648.93,339.58z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#semnan">
                            <svg class="map-province semnan">
                                <path class="map-path" id="path-semnan" d="M494.58,142.69c2.11,0.43,4.28,0.65,6.33,1.36
			c0.99,2.23-0.1,5.1,1.5,7.04c1.4,0.59,2.92,0.81,4.32,1.4c1.44,1.85,1.42,5.2,4.12,5.7c2.15,0.59,4.36,1.08,6.48,1.85
			c1.46-0.59,2.82-1.4,4.02-2.46c1.81,1.14,3.08,3,2.72,5.24c0.45,2.78-2.84,4.38-2.58,7.1c0.08,4.99,1.16,9.88,1.18,14.88
			c0.65,3.29,3.96,4.99,5.99,7.37c1.2,2.88,1.22,6.15,0.97,9.22c-0.04,2.86-3.15,3.81-4.95,5.44c-2.98,2.76-6.17,5.32-9.36,7.84
			c-2.15,0.73-4.43,0.99-6.6,1.68c-2.03,4.1-5.72,7.02-7.77,11.12c-4.12,5.28-5.05,12.16-8.79,17.66c-6.45,0.2-12.89-0.65-19.32-0.34
			c-8.36,0.65-16.76,0.22-25.15,0.34c-12.14,0.2-24.23-0.97-36.37-1.12c-2.01-0.02-3.59-1.44-5.28-2.36
			c-2.78-1.7-6.01-2.37-9.07-3.35c-2.42,0.41-4.83,0.97-7.29,0.69c-2.88-1.24-5.05-3.63-7.43-5.62c0.49-3.21,2.15-6.15,2.21-9.42
			c1.6-2.42,3.21-4.97,3.27-7.98c-1.58-1.52-3.27-2.92-4.75-4.57c0.28-2.88,0.77-5.76,0.95-8.67c7.1,1.34,14.33,0.73,21.49,0.83
			c1.18-1.32,2.6-2.39,4.22-3.12c1.85-0.77,2.48-3.04,4.4-3.72c2.13-0.97,3.98-2.41,5.72-3.96c0.26-2.52,0.43-5.03,0.43-7.55
			c3.63-0.04,5.46-3.9,8.95-4.14c2.5-0.41,5.01-0.87,7.43-1.75c2.82-1.3,4.47-4.12,6.13-6.6c0.93-2.09,1.93-4.16,3.69-5.66
			c2.6,0.04,5.22-0.04,7.79,0.24c1.4-0.14,2.8-0.18,4.18-0.47c2.42-0.95,3.76-3.43,5.95-4.73c1.87-0.06,3.75,0.55,5.58,0.04
			c2.15-0.95,3.8-2.82,6.09-3.51c3.59-1.04,7.35-0.39,10.98-0.1c2.74-3.8,5.54-8.14,5.3-12.97
			C492.87,144.5,493.81,143.65,494.58,142.69z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#hormozgan">
                            <svg class="map-province hormozgan">
                                <path class="map-path" id="path-hormozgan" d="M496.53,442.22c3.51-2.31,6.94-6.09,11.57-4.89
			c1.48,5.28,1.1,10.8,1.28,16.22c-0.14,2.96,3.21,3.83,5.01,5.54c2.94,2.78,7.31,3.63,11.18,2.7c3.08-2.11,6.03-4.44,9.44-6.03
			c1.42,0.45,2.9,0.83,4.22,1.54c1.42,3.12,0.1,6.84,1.52,9.88c2.41,1.75,5.56,2.05,8.36,2.92c0.41,1.58,1.1,3.07,2.15,4.32
			c-2.35,1.64-5.18,3.17-6.43,5.87c0.28,2.27,0.63,4.53,0.97,6.78c2.01,2.31,3.98,4.67,5.91,7.06c2.7,3.39,7.47,4.69,9.34,8.83
			c4.32,0.83,8.06,3.19,12.06,4.89c2.21,1,3.76,3.08,6.03,4c2.9,0.61,5.97,0.06,8.83,0.97c2.56,0.53,4.53,2.35,6.56,3.9
			c0.39,1.66,0.63,3.39,1.22,4.99c0.79,2.13,3.23,2.96,4.26,4.93c0.85,1.73,2.42,2.88,3.63,4.3c0.89,2.74,1.08,5.64,1.87,8.4
			c0.87,1.79,2.76,2.82,3.78,4.55c1.5,3.9,1.72,8.2,0.91,12.3c-2.21-0.51-3.19-2.62-4.73-4.04c-2.25-1.28-4.71-2.5-7.37-2.38
			c-3,0.02-5.91-1.08-8.91-0.67c-2.56,0.06-5.03,0.73-7.27,1.95c-1.28,0.47-2.76,1.83-4.08,0.75c-1.52-1.38-2.31-3.37-3.8-4.77
			c-1.12-0.65-2.52-0.43-3.73-0.59c-0.41,0.34-1.22,1.05-1.62,1.4c-0.93-1.24-1.7-2.96-3.45-3.12c-0.91,0.16-1.83,0.32-2.72,0.51
			c-2.94-0.53-5.95-0.36-8.91-0.47c-0.79-1.32-1.44-2.7-2.03-4.12c-0.85-2.29-3.51-3.65-3.53-6.29c0.16-1.18,0.43-2.35,0.63-3.53
			c-0.77-1.72-2.29-2.96-3.08-4.65c-0.16-1.14-0.12-2.25-0.16-3.37c-0.29-0.33-0.85-0.97-1.14-1.32c0.63-1.91,2.17-3.96,1.1-5.99
			c-1.22-2.92-1.95-6.03-3.19-8.91c-1.93-2.62-3.27-5.74-5.93-7.73c-1.44-1.16-3.19-1.83-4.79-2.68c-3.04-0.49-6.19-0.37-9.17-1.24
			c-2.98-0.91-6.35-1.03-9.25,0.2c-2.38,2.21-4.53,4.69-7.43,6.25c-4.04-0.04-9.76-0.2-11.02,4.69c0.24,1.09,0.47,2.19,0.69,3.29
			c-3.25,1.28-6.72,1.04-10.11,0.79c-5.42,2.7-10.15,6.47-14.82,10.27c-0.45-0.22-1.34-0.67-1.81-0.87c-0.95,0.3-1.93,0.63-2.88,0.97
			c-1.4-2.52-4.1-2.86-6.66-3.25c-1.81-1.54-2.78-4.2-5.34-4.81c-1.56,0.33-3.25,0.75-4.71-0.16c-2.11-1.3-4.75-1.12-6.82,0.16
			c-2.13,0.04-4.28,0.26-6.39-0.12c-1.93-1.28-3.92-2.48-5.76-3.88c-1.06-1.46-1.4-3.29-2.35-4.79c-1.26-1.46-3.33-1.66-5.01-2.38
			c-7.43-1.46-13.54-7.11-15.48-8.32c1.23-1.23,2.09-3.85,2.68-3.43c4.77,3.43,12.31,6.11,15.8,7.53c2.88,1.93,6.45,1.89,9.76,2.43
			c3.47,0.57,7.65,1.3,10.43-1.42c2.03-1.34,1.56-3.98,1.3-6.03c2.37-2.07,5.36-3.49,8.5-3.86c4.55-0.41,9.05,0.75,13.6,0.69
			c2.37,0,4.77,0.02,7.16,0.02c3.49,0.14,6.6-1.87,10.07-2.03c2.15-0.12,4.55-0.57,5.95-2.42c1.04-2.35-0.3-5.52,1.75-7.51
			c1.77-2.19,4.79-2.27,7.25-3.19c-1.2-2.07-2.6-4.2-2.52-6.7c-1.81-1.71-4.44-1.56-6.68-2.25c-1.07-0.02-1.14-1.28-1.14-2.05
			c-0.02-4.77-0.12-9.56,0.3-14.33c0.3-1.42-1.3-3.21,0.16-4.26C493.08,443.28,495.07,443.36,496.53,442.22z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#yazd">
                            <svg class="map-province yazd">
                                <path class="map-path" id="path-yazd" d="M522.31,318.91c-0.98-1.47-2.33-2.08-2.57-4.89
			c-0.24-2.81-1.35-5.02-2.57-6c-1.22-0.98-2.45-1.1-3.18-2.08c-0.73-0.98-0.61-2.94-1.59-4.16c-0.98-1.22-3.06-2.32-4.04-3.3
			c-0.98-0.98-0.98-3.55-1.83-5.14c-0.86-1.59-2.03-1.29-3.22-2.73c-1.19-1.43-1.19-4.54-4.3-4.77c-3.1-0.24-3.1,0.48-4.3-1.67
			c-1.19-2.15-4.3-4.3-4.3-4.3l-2.39-4.54l-4.35-3.67c-1.74,3.35-5.81,5.03-9.45,5.53c-0.77,3.04-3.63,4.89-4.44,7.96
			c-1.81,0.26-3.63,0.39-5.42,0.73c-1.83,1.2-1.87,3.9-3.88,4.93c-4.02,2.11-8.93,1.34-12.97,3.45c-7.92,3.94-15.71,8.14-23.54,12.3
			c-2.07-0.35-4.14-1.14-6.27-0.89c-1.71,0.3-2.17,2.19-3.02,3.43c-1.58,0.04-3.11,0.41-4.46,1.18c0.87,2.7,2.56,5.16,2.78,8.02
			c0.08,3.53-0.89,7-0.51,10.53c0.33,2.8-0.06,5.66,0.41,8.46c1.12,1.73,3.25,2.42,4.85,3.61c0,0.57-0.02,1.68-0.02,2.23
			c-2.13,2.37-5.58,2.41-7.98,4.4c2.09,3.67,1.04,8.08,2.46,11.91c0.89,2.66,3.82,3.45,6.09,4.55c5.32,2.19,9.95,5.87,15.49,7.51
			c2.66,0.93,5.97,1.22,7.57,3.86c2.46,5.12,2.01,10.88,2.23,16.38c0.18,4.24,5.4,5.5,6.29,9.44c0.83,3.45,2.78,6.72,5.89,8.57
			c1.87,0.16,3.55-0.87,5.28-1.42c-0.26-6.64-0.35-13.31-1.34-19.87c-0.18-2.38-2.38-3.53-4.18-4.61c-0.16-3.13,1.95-5.52,3.39-8.08
			c1.32-1.85,0.12-4.08-0.2-6.05c-0.83-4.08-2.54-8.02-2.68-12.18c1.07-1.85,3.49-2.42,5.38-3.21c4.08-1.75,7.93,3.15,11.89,1.04
			c9.58-4.08,19.91-6.94,28.21-13.54c1.7-1.38,1.97-3.69,2.58-5.64c2.72-0.12,5.32,0.75,7.96,1.38c3.15-2.42,6.17-5.01,9.09-7.71
			c0-1.97,0.04-3.94,0.12-5.89c0.83-0.06,1.65-0.13,2.48-0.2C523.24,321.58,522.71,319.52,522.31,318.91z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khorasan-sh">
                            <svg class="map-province khorasan-sh">
                                <path class="map-path" id="path-khorasan-sh" d="M532.13,103.93c1.66-0.65,2.84-2.07,4.1-3.27
			c0.41,2.46,1.85,4.5,3.31,6.45c-0.04,1.46-0.49,3.37,0.99,4.34c2.62,2.5,6.49,0.91,9.56,2.29c1.79,0.77,3.61,1.6,5.64,1.44
			c2.29,1.52,4.93,2.33,7.69,2.58c0.39,1.91,1.52,3.37,3.47,3.86c0.81,1.36,1.72,2.68,2.4,4.14c0.32,2.5-0.65,5.09,0,7.57
			c0.61,1.6,1.54,3.02,2.31,4.53c-1.66,1.79-4.95,1.18-5.99,3.55c-0.65,2.74,1.24,5.14,1.99,7.63c-1.95,1.14-3.94,2.17-5.97,3.17
			c-0.41,2.25-0.06,4.53-0.12,6.8c-0.47,1.38-1.75,2.23-2.7,3.25c-2.01-0.26-4.06-0.65-5.89-1.62c-3.13-1.46-5.38-4.28-8.48-5.83
			c-3.57-1.62-7.55-2.17-11.45-2.07c-2.54,0.08-5.18-0.28-7.65,0.43c-3.06,0.89-4.3,4.44-7.39,5.32c-2.7-0.02-5.26-1.03-7.83-1.62
			c-0.79-1.6-1.44-3.25-2.33-4.79c-1.1-1.89-4.55-0.65-5.09-3.04c-0.22-2.01-0.28-4.02-0.83-5.97c-2.52-0.65-5.06-1.12-7.59-1.62
			c0.59-1.44,1.54-2.68,2.8-3.61c3.57,0.16,6.05-3,7.26-5.99c0.53-4.28,1.6-8.58,3.76-12.34c1.3-2.44,5.03-3.59,4.5-6.82
			c0.14-1.64-0.97-2.94-1.75-4.26c0.75-0.55,1.52-1.12,2.27-1.68c-0.45-1.28-0.91-2.54-1.36-3.8c1.75-1.22,3.86-1.1,5.89-0.95
			c1.66,1.62,3.59,0.34,5.3-0.47c1.64,0.49,2.72,2.07,4.42,2.43C528.94,104.19,530.56,104.21,532.13,103.93z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#isfahan">
                            <svg class="map-province isfahan">
                                <path class="map-path" id="path-isfahan" d="M378.24,238.51c1.58-0.85,2.4-2.6,3.53-3.92
			c2.46,2.17,4.91,4.53,8,5.72c2.19,0.1,4.34-0.51,6.51-0.63c4.99,0.2,9.23,3.11,13.52,5.3c9.54,0.34,19.08,0.73,28.62,1.22
			c13.38-0.02,28.84-0.07,42.21-0.09c0.4,0.94,0.37,1.3,0.86,2.54c1.4,7.27,1.48,14.66,1.73,22.02c-1.14,1.24-2.15,2.62-3.47,3.67
			c-1.87,1.06-4.06,1.32-6.15,1.79c-0.41,0.93-0.81,1.89-1.22,2.82c-1.72,1.48-2.35,3.79-3.88,5.4c-1.83,0.33-4-0.28-5.5,1.16
			c-1.4,1.54-1.6,4.22-3.9,4.87c-4.08,1.32-8.61,1.06-12.46,3.07c-7.69,4.12-15.47,8.1-23.14,12.24c-2.17-0.65-4.63-1.89-6.82-0.67
			c-1.24,0.57-1.89,1.83-2.54,2.96c-1.2,0.22-2.42,0.45-3.63,0.65c-2.07,2.37,0.12,4.97,0.91,7.39c1.4,4-0.49,8.18-0.04,12.26
			c0.34,2.92,0,5.91,0.39,8.83c0.57,2.5,3.43,2.9,4.99,4.5c0.02,1.97-2.09,2.42-3.55,2.94c-1.4,0.41-2.64,1.16-3.86,1.95
			c-0.73-1.79-1.2-3.92-2.96-4.97c-2.66-1.56-5.82-1.76-8.83-1.97c-4.47-0.2-6.82-5.52-11.39-5.34c-2.96,0.2-4.1,3.39-5.68,5.42
			c-3.27,4.47-0.51,10.11-0.43,15.02c-1.14,3.63-2.86,7.08-3.67,10.86c-1.91-1-3.51-2.44-5.07-3.9c-1.28-1.24-3.8-0.69-4.51-2.54
			c-1.83-3.92-5.97-6.96-5.74-11.65c-0.12-1.26,1.34-1.68,2.07-2.44c0.22-1.2,0.45-2.39,0.65-3.59c-0.63-0.65-1.26-1.28-1.87-1.93
			c0.24-2.21-0.93-4.57,0.22-6.62c1.22-2.42,1.93-4.99,2.7-7.55c-1.66-2.07-3.94-3.82-4.49-6.56c-0.45-2.27-2.54-3.55-4-5.15
			c-1.66-1.6-2.5-3.92-4.44-5.26c-0.39-1.87-0.3-3.86-1.1-5.62c-2.8-4.12-8.69-5.03-12.91-2.76c-1.24,1.46-2.25,4.3-4.69,3.31
			c-2.31-0.26-3.04-2.78-4.65-4.08c-2.56-1.18-5.48-0.65-8.2-0.59c-1.2-2.31-2.82-4.36-4-6.68c-0.43-0.95-1.36-1.5-2.13-2.13
			c-0.02-1.32-0.04-2.62-0.04-3.94c1.42-0.36,2.78-0.91,4.06-1.62c0.95,0,1.91,0,2.86,0c-0.32-1.06-0.55-2.13-0.73-3.21
			c1.69-1.79,3.59-3.37,5.14-5.3c0.04-1.36-0.14-2.72-0.1-4.08c1.1-1.71,2.33-3.35,3.82-4.75c2.66-1.08,5.3-2.48,8.24-2.46
			c2.48,0.18,4.36-1.6,6.62-2.29c2.33-0.59,4.83-0.26,7.12-1.05c1.75-1.04,3.35-2.36,4.79-3.8c0.63-2.21,1.16-4.48,2.11-6.6
			c-1.02-1.64-2.11-3.25-3.35-4.73c0.83-0.83,1.93-1.46,2.52-2.5c0.37-1.71,0.24-3.45,0.28-5.18c1.67-0.71,3.29-1.58,5.03-2.07
			c2.29-0.22,3.73,1.87,5.66,2.68C371.58,239.14,374.99,239.28,378.24,238.51z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#fars">
                            <svg class="map-province fars">
                                <path class="map-path" id="path-fars" d="M380.49,341.92c1.34-2.35,2.72-4.91,4.91-6.58
			c2.98-0.59,5.14,1.91,7.37,3.41c4.02,3.37,10.27,0.69,14.04,4.57c1.16,1.93,1.62,4.18,2.5,6.25c1.52,3.57,0.28,7.82,2.33,11.24
			c1.95,3.15,5.89,3.76,8.93,5.36c4.51,2.44,8.89,5.3,13.88,6.66c2.07,0.67,4.55,1.04,5.91,2.94c1.12,2.11,1.4,4.55,1.79,6.88
			c0.65,3.88-0.47,7.96,1.05,11.69c0.75,1.95,2.7,3,4.08,4.47c1.3,1.2,1.56,3.02,2.15,4.61c0.99,3.39,3.69,6.07,6.76,7.71
			c3.92-1.44,8.67-3.27,12.56-0.87c4.67,5.36,9.13,10.92,13.72,16.36c1.99,3.94-0.41,8.38,0.06,12.52c1.16,2.98,4.24,4.59,7.35,4.77
			c-0.06,0.43-0.14,1.28-0.18,1.71c1.16,2.74,0.12,5.7,0.26,8.58c0.08,3.31-0.18,6.64,0.16,9.95c1.26,2.86,5.07,2.07,7.53,3.06
			c0.1,2.21,0.93,4.26,2.09,6.13c-2.76,0.12-5.38,1.4-7.12,3.53c-1.12,1.99-0.81,4.38-0.81,6.58c-2.56,3.19-6.96,1.89-10.33,3.39
			c-3.43,1.46-7.21,0.95-10.84,1.04c-5.6,0.16-11.18-1.48-16.77-0.49c-2.74,0.87-5.66,1.93-7.61,4.14c-0.41,1.32,0.04,2.72-0.06,4.08
			c-0.91,1.81-2.78,3.37-4.87,3.37c-3.59,0.08-7.08-0.83-10.63-1.22c-2.2-0.17-3.94-2.94-5.96-2.3c-1.38,0.44-11.78-5.43-14.14-6.81
			c-2.37-1.64-5.37-4.36-7.87-5.84c-1.72-1.16-3.81-1.97-5.01-3.75c-0.93-2.13-0.97-4.57-1.97-6.68c-0.75-0.98-1.79-1.71-2.68-2.52
			c-0.12-1.93-0.08-4-1.12-5.7c-1.4-1.75-4.06-2.23-4.95-4.43c-1.06-2.66-2.64-5.03-4-7.53c-0.97-3.53-1.62-7.21-1.48-10.88
			c0.43-5.44-2.8-10.31-5.95-14.45c-2.37-2.9-4-6.39-6.8-8.93c-2.07-2.07-4.85-3.25-6.9-5.34c-2.07-2.09-2.62-5.32-5.01-7.1
			c-3.49-1.97-7.53-2.74-10.98-4.77c-1.38-0.83-1.6-2.6-2.23-3.94c3.27-1.18,4.53-4.65,7.06-6.66c2.8-0.67,6.09-0.99,7.59-3.86
			c2.31-3.67-1.93-6.82-3.06-10.11c1.6,0,3.47-0.26,4.63,1.18c3.11,3.39,7.63,4.77,11.33,7.35c2.15,1.75,6.07,0.79,6.62-2.07
			c0.32-3.19,0.55-6.64-1.4-9.38c2.13-2.68,1.99-6.07,1.91-9.3c-0.12-4.08,3.63-7.37,2.68-11.51
			C380.35,349,379.4,345.35,380.49,341.92z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#khoozestan">
                            <svg class="map-province khoozestan">
                                <path class="map-path" id="path-khoozestan" d="M269.05,285.98c1.24-0.57,2.48-1.5,3.9-1
			c3.08,0.79,6.25,0.91,9.42,1.1c2.05,0.83,3.65,2.54,5.74,3.31c4.59,0.33,9.6-0.43,13.74,2.07c2.05,1.76,3.88,3.75,6.13,5.25
			c0.28,1.4,0.3,2.9,1.01,4.16c2.03,1.34,4.42,2.11,6.15,3.88c0.99,1.2,1.32,2.82,2.31,4.06c0.95,1.03,2.13,1.87,2.98,2.98
			c0.79,1.99,0.93,4.28,2.52,5.87c1.81,1.95,2.23,4.79,4.3,6.5c2.66,2.31,5.03,4.91,7.94,6.92c0.04,1.83,0.83,3.47,1.89,4.95
			c-1.16,1.54-1.95,3.47-3.67,4.53c-2.7,1.81-4.93,4.22-6.84,6.84c-1.34,2.21-4.26,2.23-6.15,3.79c0.24,1.16,0.51,2.33,0.79,3.51
			c-0.99,1.22-1.99,2.42-2.96,3.65c0.99,1.54,1.91,3.33,3.59,4.24c2.42,0.91,5.18,0.32,7.55,1.44c0.47,1.05,0.75,2.17,1.24,3.23
			c0.79,0.83,2.07,0.89,3.09,1.34c0.77,1.93,2.37,3.04,4.08,4.06c-0.65,1.38-1.87,2.35-2.88,3.47c2.13,3.35,0.97,7.33,1.08,11.02
			c-3.02-0.49-4.69-3.82-7.85-3.88c-2.05-0.1-3.59,1.48-5.03,2.74c-2.4-0.34-4.91-0.47-7.04,0.93c-3.39,1.08-5.01,4.79-8.46,5.74
			c-1.58-1.5-1.73-4.02-3.29-5.56c-1.89-0.93-4.02-0.55-5.99-0.1c0.04-0.73,0.06-1.48,0.1-2.19c-0.26-0.36-0.81-1.05-1.08-1.4
			c-2.25-0.02-4.38-0.83-5.91-2.54c2.66-0.93,5.7-0.95,8.02-2.76c-0.51-1.68-0.43-4.57-2.82-4.61c-1.28,0.3-1.64,1.81-2.37,2.72
			c-1.2-0.49-2.33-1.34-3.65-1.4c-1.7,0.89-2.25,2.88-3.11,4.46c-0.04,0.47-0.1,1.38-0.14,1.85c1.08,1.24,1.99,2.62,2.66,4.12
			c-0.28,1.4-0.47,2.84-0.83,4.22c-1.18,1.02-2.76,1.97-4.38,1.48c-2.21-0.16-3.29-2.68-5.48-2.82c-0.06,1.18-0.08,2.35-0.08,3.51
			c-0.26,0.22-0.77,0.65-1.03,0.87c-1.64-0.49-3.31-0.89-4.97-1.36c-0.79-2.7-1.01-5.56-2.15-8.12c-0.81-1.95-2.74-2.92-4.26-4.2
			c-0.43-1.34-0.57-2.74-1.06-4.04c-0.87-1.2-2.52-1.3-3.77-1.85c0.34-6.05,0.67-12.12,1.08-18.16c-3.21-0.57-6.45-0.59-9.7-0.53
			c-0.04-4.85-0.1-9.78,0.83-14.57c1.18-4.26,3.51-8.12,4.77-12.36c0.33-1.42-0.87-2.48-1.64-3.49c-1.08-1.2-1.67-2.7-2.37-4.12
			c2.03-1.32,3.33-3.23,3.41-5.68c2.01-2.39,4.18-4.83,4.59-8.06c1.54-2.96,0.24-6.25,0.45-9.38c-0.12-1.48,1.85-1.26,2.74-1.66
			c0.06-1.22,0.1-2.44,0.18-3.63C267.48,289.7,268.42,287.89,269.05,285.98z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#tehran">
                            <svg class="map-province tehran">
                                <path class="map-path" id="path-tehran" d="M414.27,189.66c-3.61-0.96-7.06-2.84-10.88-2.8
			c-3.59,0.12-5.74,3.88-9.38,3.96c-3.41,0.83-6.66-0.83-9.86-1.75c-2.94-0.93-3.29-4.83-6.01-6.11c-2.4-1.1-4.77-2.23-6.78-3.98
			c-0.68-0.63-1.45-1.09-2.26-1.48c-0.66,1.27-1.04,3.2-1.19,5.99c-0.11,1.97-0.49,2.96-1.25,3.22c-0.82,0.28-1.61-0.51-2.13-1.12
			c-0.61-0.72-0.77-0.7-1.19-0.65c-0.22,0.03-0.5,0.06-0.87,0.03c-0.16,0.01-0.25,0.2-0.46,0.71c-0.27,0.66-0.65,1.57-1.7,1.78
			c-0.37,0.07-0.66,0.33-0.88,0.77c-0.35,0.71-0.33,1.59-0.17,1.91c0.07,0.13,0.13,0.24,0.19,0.33c0.15,0.24,0.33,0.51,0.24,0.86
			c-0.1,0.41-0.51,0.71-1.33,1.17c-1.11,0.62-2.66,0.64-5.23,0.67c-1.52,0.02-3.4,0.04-5.77,0.19c-5.51,0.35-8.32,1.06-9.35,4.08
			c3.14-0.46,6.36-0.25,8.99,1.62c2.6,1.48,7.12-0.3,8.48,3.11c-1.58,2.42-3.69,4.65-3.84,7.71c2.82,0.16,5.72,0.16,8.4,1.24
			c5.87,2.27,11.63,4.91,17.66,6.78c2.5,0.81,4.3,2.82,6.35,4.36c1.24-1.56,2.07-3.37,2.76-5.26c-1.44-1.91-3.23-3.51-5.07-4.99
			c0.85-3.29,0.26-6.92,1.66-10.01c3.31-0.65,6.6,1.01,9.95,0.47c3.8-0.53,7.63-0.24,11.45,0.1c1.46-1.6,3.35-2.68,5.34-3.47
			c1.42-3.61,5.85-3.71,8.08-6.56C417.74,190.88,415.81,190.1,414.27,189.66z" />
                                <path class="map-point" id="point-tehran" d="
        M414.27,189.66
        m -50, 0
        a 8,8 0 1,0 16,0
        a 8,8 0 1,0 -16,0
    ">
                                </path>
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ghom">
                            <svg class="map-province ghom">
                                <path class="map-path" id="path-ghom" d="M351.06,210.68c3.23,0.57,6.66,0.3,9.66,1.81
			c3.65,1.73,7.55,2.84,11.2,4.55c2.94,1.38,6.47,1.71,8.95,3.98c0.85,0.75,1.68,1.52,2.54,2.29c-0.04,3.09-1.6,5.85-2.19,8.83
			c-0.63,2.7-2.58,5.83-5.7,5.74c-2.42,0.18-4.85,0.08-7.29,0.06c-1.44-1.24-2.96-2.58-4.93-2.84c-2.35,0.18-4.36,1.58-6.49,2.46
			c-0.26,1.93-0.41,3.88-0.55,5.8c-0.97,0.87-1.93,1.75-2.86,2.64c-2.29-1.12-4.34-2.7-6.68-3.69c-2.11,0.16-4.16,0.95-6.29,0.61
			c-0.75-1.54-1.85-2.8-3.43-3.55c-0.51-2.09-0.16-4.65-1.91-6.21c-2.05-0.41-4.16-0.18-6.23-0.16c-1.91-3.49,1.66-6.54,3-9.56
			c2.44,0.67,4.79,1.52,7.08,2.54c1.54-1.26,2.98-2.64,4.36-4.06c2.44,0.1,4.85-0.24,7.12-1.12
			C351.51,217.52,351,214.05,351.06,210.68z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kermanshah">
                            <svg class="map-province kermanshah">
                                <path class="map-path" id="path-kermanshah" d="M216.3,206.99c0.55-1.14,0.53-2.8,1.66-3.45
			c3.13-0.18,2.64,3.79,4.71,5.22c3.59,2.56,5.16,6.84,7.94,10.11c2.54,2.15,6.29,2.29,9.19,0.77c1.87-0.45,1.97-2.58,2.52-4.08
			c1.54-0.49,3.25-0.73,4.61-1.66c0.81-0.85,1.42-1.89,2.23-2.74c5.03-2.56,11.43-0.49,14.33,4.28c-0.69,1.85-0.39,3.75,0.34,5.52
			c0.89,1.97-0.67,3.75-1.22,5.56c1.32,1.62,3.53,2.13,5.32,3.08c0.04,1.04,0.08,2.05,0.12,3.09c-1.62,2.01-3.37,3.96-5.68,5.18
			c-1.46-1.85-3-3.94-5.56-4.1c-0.57,1.6-0.49,3.31-0.41,4.97c-1.58,1.42-4.43-0.1-5.85,1.79c-2.07,1.64-0.16,4.51-1.08,6.6
			c-0.81,0.53-1.68,0.97-2.54,1.44c-0.63,1.46-1.04,3.07-1.97,4.38c-2.19,0.67-4.44-0.61-6.68-0.26c-1.06,0.41-1.95,1.12-2.86,1.79
			c-2.82,0.08-5.48-1.01-7.67-2.72c-2.7-2.17-5.7-3.94-8.69-5.7c-1.48-1.08-3.23,0-4.81,0.08c-1.68-1.1-2.96-2.7-4.69-3.75
			c-1.08,0.63-2.13,1.26-3.21,1.87c-1.24,0.06-2.88-0.71-3.75,0.55c-1.1,0.83,0.08,2.19,0.2,3.23c-0.33,0.53-0.67,1.06-1,1.6
			c0.43,1.34,0.97,2.68,1.1,4.1c-0.51,1.1-1.38,1.97-2.09,2.96c-3.88-2.19-4.69-6.98-6.13-10.82c-0.79-0.3-1.56-0.59-2.33-0.87
			c0.43-1.08,0.75-2.19,1.08-3.31c3.06-1.48,3.65-5.01,3.71-8.08c0.1-1.95-2.21-2.25-3.55-2.84c-0.14-0.59-0.41-1.81-0.53-2.42
			c0.57-0.02,1.71-0.08,2.27-0.1c0.51-0.65,1.01-1.3,1.52-1.95c-0.28-0.83-0.59-1.64-0.89-2.48c1.38,0.73,2.96,2.48,4.53,1.2
			c2.42-1.73,0.87-4.95-0.43-6.9c1.48-1.48,3.61-2.35,4.59-4.3c1.18-0.24,2.68-0.22,3.23-1.56c0.06-1.16-0.28-2.27-0.49-3.39
			c0.28-0.32,0.85-0.95,1.12-1.28c1.62,0.28,3.29,0.47,4.71-0.53C214.25,207.07,215.28,207.11,216.3,206.99z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kordestan">
                            <svg class="map-province kordestan">
                                <path class="map-path" id="path-kordestan" d="M212.3,162.16c1.26-1.16,2.66-2.15,4.14-3
			c2.23,0.91,3.59,4.3,6.47,3.45c4.47-0.91,9.03-0.45,13.54-0.55c2.03,4.48,6.98,8.24,12.06,6.55c3.17-1.75,7.51-1.26,9.5-4.79
			c2.68-0.06,5.72-0.16,7.77,1.91c2.52,1.93,1.85,5.42,2.25,8.18c-0.73,0.95-1.44,1.91-2.15,2.88c0.77,0.87,1.54,1.77,2.31,2.64
			c-0.95,0.93-2.9,1.68-2.27,3.37c0.93,1.85,2.62,3.17,3.82,4.85c0.57,0.39,1.16,0.77,1.75,1.16c-3,0.83-8.02,0.49-8.14,4.77
			c1.12,3.84,3.35,7.23,5.91,10.21c2.27,2.44,3.15,6.35,1.01,9.15c-2.31-1.34-4.79-0.06-7.21-0.12c-2.03-1.34-3.82-3.19-6.33-3.59
			c-2.4-0.79-4.89-0.12-7.23,0.55c-1.75,0.37-2.23,2.35-3.39,3.47c-1.4,0.65-2.92,0.87-4.36,1.42c-0.85,0.97-0.91,2.39-1.36,3.57
			c-2.68,1.3-5.99,2.21-8.59,0.22c-3-2.62-4.02-6.86-7.21-9.32c-2.01-1.4-2.9-3.69-3.9-5.82c-1.46-0.79-2.8-1.77-4.1-2.8
			c0.1-0.89,0.14-1.81,0.16-2.7c-0.16-1.28-1.66-1.24-2.58-1.64c-0.75-1.85-1.42-3.72-1.97-5.6c1.22-1.1,1.95-2.52,1.89-4.18
			c3.63-0.61,7.45-1.71,9.5-5.05c-1.26-1.87-3.88-0.73-5.74-1.04c-0.3-0.37-0.93-1.1-1.24-1.46c-2.86-0.02-5.8-0.02-8.48,1.12
			c-0.97-0.43-2.42-0.45-2.74-1.66c-0.89-2.15-2.39-3.94-4.04-5.56c0.69-1.75,1.16-3.63,2.42-5.07c2.01-0.41,4.14,0,6.11-0.65
			C211.3,165.77,210.82,163.37,212.3,162.16z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#zanjan">
                            <svg class="map-province zanjan">
                                <path class="map-path" id="path-zanjan" d="M273.82,138.57c2.96,0.41,5.05-2.27,7.86-2.68
			c2.27,0.67,4.38,1.91,5.89,3.75c1.54,2.23,4.49,1.24,6.72,1.1c3.21,1.48,6.88,0.2,10.05,1.97c0.49,2.25,0.41,4.89,2.11,6.68
			c1.14,1.36,2.94,3.43,1.6,5.2c-3.47,0.16-6.76,1.58-9.19,4.06c-0.63,0.97-0.79,2.21-0.71,3.37c0.77,1.12,1.73,2.09,2.62,3.11
			c1.75,2.31,5.11,1.24,7.45,2.56c2.35,0.61,3.86,2.54,4.65,4.73c0.79,1.24-0.49,2.38-1.14,3.33c-1.42,1.71-2.44,3.71-3.9,5.4
			c-1.3,1.14-3.17,0.81-4.75,1.12c-1.6,0.14-2.94,1.14-4.34,1.85c-1.68-1.32-3.27-2.94-5.5-3.17c-0.04,1.12-0.12,2.23-0.24,3.35
			c-1.08,1.32-3.37,2.09-3.17,4.12c0.26,1.56,1.68,2.58,2.56,3.81c-0.91,1.14-1.87,2.25-2.86,3.31c-3.94-0.73-7.35-2.88-11.06-4.2
			c-4.79-1.66-8.85-4.95-11.75-9.07c0.91-0.95,2.35-1.64,2.56-3.08c-0.59-0.81-1.24-1.58-1.89-2.36c2.44-2.6,1.83-6.29,1.02-9.42
			c-1.18-2.27-3.51-4.06-6.03-4.55c-3.35-0.04-6.7-0.08-9.97-0.79c-0.34-2.03-0.49-4.08-0.49-6.13c-1.62-2.15-3.17-4.38-4.38-6.8
			c0.73-0.85,1.38-1.79,2.23-2.5c1.52-0.85,3.53-1.01,4.57-2.56c1.4-1.62,1.89-4.02,3.65-5.24c2.94-0.45,5.22,2.03,7.89,2.78
			c0.69-1.5,0.43-3.96,2.25-4.61C270.1,137.13,271.77,138.63,273.82,138.57z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#gilan">
                            <svg class="map-province gilan">
                                <path class="map-path" id="path-gilan" d="M292.43,94.63c2.33-1.06,5.09-1.1,7.45-2.29
			c-0.39,3.83-0.51,7.73-0.18,11.59c0.37,4.06,0.06,8.24,1.3,12.18c1.14,2.52,2.5,5.16,4.95,6.64c6.56,4.73,14.94,6.6,22.91,6.19
			c2.48,1.36,5.14,2.25,7.85,2.98c-0.35,3.7,0.83,7.61,3.78,9.99c2.29,1.72,4.81,3.13,7.08,4.87c-0.57,1.22-1.06,2.46-1.81,3.57
			c-1.3,1.1-3.47,0.61-4.63,1.85c-0.59,1.69-0.41,3.51-0.47,5.26c-0.37,0.57-0.73,1.16-1.1,1.74c-2.56-0.67-5.26-1.52-7.85-0.61
			c-2.78,0.51-4.95,2.84-7.83,2.8c-2.62,0.1-4.53-2.27-7.16-2.19c-2.6-0.18-5.95-1.2-6.56-4.12c-0.53-2.15-0.95-4.44-2.64-6.03
			c-1.93-1.83-1.56-4.65-2.4-6.98c-1.34-0.87-2.98-1.05-4.42-1.7c-0.93-2.72-0.85-5.89-2.78-8.18c-2.64-3.19-5.52-6.64-5.83-10.92
			c-0.47-3.59-1.28-7.39,0.1-10.86c1.95-3.53,5.03-6.9,4.79-11.2C296.41,97,293.81,96.27,292.43,94.63z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#lorestan">
                            <svg class="map-province lorestan">
                                <path class="map-path" id="path-lorestan" d="M257.19,234.74c1.85,0.59,2.94,2.19,4.22,3.53
			c1.79,1.95,4.87,1.91,6.56,3.96c2.05,2.19,4.45,4.1,7.1,5.44c3.21,0.73,6.41-0.45,8.93-2.4c4.75-1.1,6.39,5.24,10.82,5.48
			c-1.38,2.23-0.85,4.83-0.53,7.27c0.75,1.14,1.46,2.31,2.13,3.51c0.71,0.04,1.44,0.08,2.15,0.14c0.73,0.65,1.28,1.85,2.42,1.73
			c2.42,0.47,4.16-1.5,6.03-2.68c1.87,1.73,4.06,0.99,6.13,0.16c0.16,1.5,0.2,3.02,0.51,4.53c0.71,0.59,1.52,1.04,2.31,1.5
			c0.77,1.64,0.81,4.1,2.82,4.77c2.11,0.77,4.18,1.62,6.03,2.9c-1.91,2.11-3.75,4.3-5.72,6.37c0.18,0.47,0.55,1.4,0.73,1.87
			c-2.29,0.43-4.42,1.34-6.64,2.05c-0.04,1.54,0.06,3.09-0.2,4.63c-0.87,1.58-1.99,3.06-2.27,4.89c-0.97,0.41-2.03,1.26-3.1,0.59
			c-2.48-1.22-3.88-3.84-6.29-5.11c-3.53-1.36-7.37-1.75-11.12-1.42c-2.44,0.3-4.22-1.68-6.19-2.74c-2.11-1.6-4.89-0.53-7.29-1.16
			c-2.7-0.37-6.01-1.81-8.22,0.49c-1.26,2.01-2.07,4.28-3.51,6.19c-1.06-2.23-1.66-4.87-3.78-6.41c-2.09-1.87-5.05-2.33-7.1-4.26
			c-5.5-4.71-11.71-8.55-18.12-11.87c-0.41-1.24-0.83-2.48-1.26-3.69c-1.46-0.65-3.88-1.18-3.17-3.33c1.58-0.06,3.17,0.71,4.71,0.45
			c0.69-1.07,1.08-2.34,1.89-3.33c3.39-0.81,6.92-0.95,10.37-1.46c0.99-1.2,2.25-2.23,2.96-3.63c0.12-1.1,0.06-2.21,0.04-3.31
			c-2.01-2.33-0.34-5.46-0.91-8.2c1.28-2.94,5.26-0.67,7.14-3C257.54,237.68,257.34,236.22,257.19,234.74z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#markazi">
                            <svg class="map-province markazi">
                                <path class="map-path" id="path-markazi" d="M317.64,198.97c1.64,0.39,3.31,0.1,4.89-0.37
			c3.75,2.58,8.83,2.23,12.89,0.65c2.27-0.91,4.75-0.77,7.14-0.69c2.11,0.04,3.63,1.87,5.66,2.23c1.97,0.35,3.98,0.38,5.95,0.69
			c-2.05,3.49-4.47,7.16-4.22,11.39c-0.1,2.35,0.55,4.87-0.41,7.08c-1.91,1.12-4.18,0.63-6.27,0.97c-1.75,0.92-2.94,2.58-4.32,3.92
			c-2.37-0.85-4.67-2.23-7.23-2.33c-2.58,2.25-3.73,5.66-5.07,8.73c0.57,0.89,1.12,1.79,1.68,2.7c2.15,0.18,4.3,0.12,6.45,0.04
			c0.75,2.13,1.04,4.36,1.24,6.6c0.81,0.2,1.62,0.41,2.44,0.61c0.16,0.79,0.32,1.58,0.51,2.38c2.13,0.63,4.34,0.55,6.45-0.02
			c1.81-0.55,3.17,1.12,4.67,1.81c2.35,1.58,5.87,2.33,6.7,5.46c-0.61,1.89-1.22,3.78-1.7,5.7c-1.14,1.42-2.7,2.48-4.16,3.51
			c-3.23,1-6.9,0.26-9.82,2.29c-2.29,1.58-5.24,0.59-7.69,1.72c-1.68,0.67-3.45,1.14-5.05,1.99c-1.85,1.95-3.23,4.28-4.83,6.41
			c-1.6-0.79-3.31-1.36-4.93-2.11c-1.1-2.01-1.36-4.67-3.94-5.44c-0.04-1.99-0.2-4.12-1.97-5.36c-1.73,1.36-3.77,1.54-5.56,0.12
			c-1.54,0.59-2.88,1.56-4.14,2.62c-0.83,0.02-1.66,0.02-2.48,0.04c-0.3-0.43-0.87-1.24-1.18-1.64c-0.71-0.1-1.44-0.18-2.15-0.24
			c-0.61-0.91-1.22-1.81-1.85-2.7c-0.14-1.58-0.47-3.15-0.39-4.75c0.67-2.48,4.06-3.06,4.49-5.7c0.41-2.58-0.18-5.13-0.61-7.67
			c-0.49-0.1-1.46-0.33-1.95-0.45c-0.53-1.52-0.99-3.09-1.38-4.65c1.64-2.19,2.9-4.65,4.85-6.58c1.73-1.5,0.22-3.86,0.14-5.7
			c2.13-2.8,4.61-5.34,8-6.51c0.39-1.52-1.06-2.35-1.93-3.35c2.19,0.53,4.22-0.45,4.91-2.64c0.95-1.46-1.02-2.31-1.91-3.06
			c0.1-1.38,0.22-2.74,0.34-4.1c2.54-0.16,5.38,0.18,7.63-1.24C317.64,200.56,317.68,199.76,317.64,198.97z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#hamedan">
                            <svg class="map-province hamedan">
                                <path class="map-path" id="path-hamedan" d="M264.83,192.17c2.21-1.62,5.22-1.5,7.73-2.52
			c2.76,2.13,6.25,2.74,9.34,4.26c2.25,1.14,4.65,1.97,7.06,2.72c1.83-0.79,3.19-2.23,4.36-3.79c1.56,0.83,3.17,1.56,4.79,2.27
			c2.25,0.71,2.39,3.59,4.28,4.77c1.85,1.24,4.16,1.28,6.23,1.89c0.16,1.71-0.22,3.41-0.1,5.12c0.65,0.79,1.46,1.42,2.21,2.13
			c-0.61,0.77-1.22,1.58-1.83,2.37c-1.26-0.22-2.56-0.26-3.53,0.71c0.63,1.02,1.36,1.97,2.03,2.96c-3.41,1.32-6.17,3.98-7.83,7.21
			c-0.14,1.44,0.45,2.82,0.59,4.26c-2.25,2.31-4.16,4.95-5.54,7.91c0.06,2.42,0.71,5.52,3.41,6.33c0.39,2.96,1.26,6.48-1.4,8.67
			c-1.12-0.02-2.25-0.02-3.37-0.04c-2.46-1.83-4.26-4.87-7.53-5.32c-2.21-0.51-3.86,1.4-5.7,2.27c-1.73,0.51-3.55,0.29-5.32,0.18
			c-3.71-2.68-6.5-6.76-11.1-8.02c2.17-1.46,3.94-3.41,5.5-5.5c0-1.28,0-2.58,0.02-3.88c-1.77-0.99-3.57-1.93-5.38-2.8
			c0.77-1.52,1.93-3.17,1.28-4.95c-0.75-2.4-0.93-4.87-0.73-7.37c1.71-0.55,3.49-0.89,5.26-0.28c2.17,0.59,2.72-2.15,3.13-3.69
			C273.13,202.93,264.28,199.36,264.83,192.17z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#mazandaran">
                            <svg class="map-province mazandaran">
                                <path class="map-path" id="path-mazandaran" d="M348.34,147.58c2.52,1.99,5.16,3.84,7.71,5.78
			c3.51,2.72,7.92,3.84,12.16,4.85c3.61,0.49,6.84,2.35,10.43,2.86c6.76,1,13.56-0.41,20.11-2.03c3.94-0.85,8.06-0.77,11.95-1.87
			c4.02-1.68,8.18-3.03,12.4-4.14c3.15-0.53,6.35-0.63,9.54-0.67c1.64,2.64,4.81,2.39,7.49,2.19c0.16,1.42-0.14,3.04,0.65,4.32
			c1.64,1.28,3.84,1.42,5.64,2.38c0.97,1.99,2.05,3.94,4.47,4.3c-2.58,0.57-5.78,0.61-7.16,3.31c-1.56,3.39-3.39,6.86-6.41,9.19
			c-3.02,1.52-6.45,1.91-9.74,2.52c-1.42,0.26-2.37,1.48-3.51,2.27c-1.28,1.04-2.96,1.2-4.42,1.81c-0.28,2.17-0.3,4.36-0.53,6.54
			c-1.73-1.2-3.61-2.15-5.66-2.68c-3.51-1.01-6.94-2.8-10.68-2.47c-3.33,0.3-5.3,3.82-8.67,3.98c-3.9,0.81-7.53-1.22-11.18-2.27
			c-1.42-2.35-2.82-5.07-5.58-6.05c-3.21-1.28-5.78-3.61-8.59-5.54c-2.01-0.26-3.77-1.28-5.52-2.25c-3.21,1.06-6.13-0.55-8.83-2.09
			c0.57-3.69-2.8-5.87-5.5-7.57c-2.7-1.48-5.52-2.78-8.22-4.28c0.47-0.97,0.93-1.93,1.38-2.9c-0.1-1.38-0.51-2.82-0.06-4.18
			c1.36-0.55,2.82-0.85,4.16-1.48C347.11,150.26,347.65,148.88,348.34,147.58z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ilam">
                            <svg class="map-province ilam">
                                <path class="map-path" id="path-ilam" d="M202.8,245.57c2.46-0.08,4.89-0.53,7.02-1.85
			c1.28,1.22,2.46,2.58,4.04,3.43c1.36,0.04,2.66-0.47,4.02-0.53c3.76,1.79,7.1,4.28,10.41,6.78c2.86,1.89,7.31,3.43,9.86,0.24
			c1.89,0.06,3.73,0.3,5.56,0.81c3.23-0.51,2.94-4.36,5.18-6.09c0.41,0.51,1.24,1.5,1.64,2.01c0.57,2.6-0.85,4.97-3.23,6.01
			c-3,0.71-6.13,0.57-9.15,1.18c-1.52,0.49-1.81,2.25-2.33,3.55c-1.81-0.45-4.79-1.36-5.48,1.14c-0.02,2.17,2.15,2.92,3.75,3.78
			c0.59,1.28,0.49,3.19,1.97,3.82c6.29,3.29,12.34,7.08,17.72,11.73c2.6,2.27,6.76,2.62,8.42,5.95c0.87,2.17,2.31,4.06,3.21,6.21
			c-0.97,0.53-2.21,0.79-2.88,1.77c-0.73,1.77-0.1,3.69,0,5.52c0.49,2.46-0.83,4.73-1.44,7.06c-0.69,3.25-4.85,4.77-4.24,8.42
			c-0.85,0.73-1.68,1.44-2.54,2.17c-1.2-2.11-2.33-4.45-4.63-5.58c1.2-2.42-0.67-4.3-2.17-5.97c1.36-2.8-1.22-4.89-2.6-7.06
			c-2.52,0.45-5.54,2.4-7.75,0.2c-3.23-2.72-5.22-6.66-8.75-9.07c-3.59-2.38-5.83-6.37-9.88-8.08c-2.7-1.89-6.07-1.5-9.17-1.46
			c0.43-1.36,0.63-2.74,0.73-4.14c-0.32-0.1-0.99-0.26-1.32-0.37c1.44-0.55,3.8-0.65,3.78-2.72c0.97-3.88-3.37-5.54-4.67-8.69
			c0.02-0.51,0.06-1.56,0.08-2.09c-0.83-0.89-1.83-1.64-3.02-2.01c-0.22-1.26,0.73-3.35-0.87-3.9c-0.55-0.18-1.64-0.57-2.19-0.75
			c0.85-1.08,1.71-2.15,2.52-3.23c-0.87-2.07-1.62-4.28-0.1-6.25C203.9,247.03,203.17,246.06,202.8,245.57z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#ghazvin">
                            <svg class="map-province ghazvin">
                                <path class="map-path" id="path-ghazvin" d="M300.81,158.32c2.25-1.87,5.16-2.41,8-2.76
			c1.01,1.36,1.95,2.94,3.57,3.65c1.83,0.93,3.94,0.85,5.89,1.34c1.83,0.77,3.53,2.05,5.62,1.91c3.17,0.26,5.46-2.52,8.48-2.94
			c3.59-0.85,7.04,1,10.15,2.54c3.82,2.01,8.24,3.57,10.8,7.27c0.79,1.14-0.02,2.8-1.52,2.37c-3.69-0.41-7.49-0.45-11.1-1.5
			c-0.39,1.1-1.26,2.19-0.24,3.27c1.28,1.72,3.77,1.85,5.34,3.23c0.14,1.07,0,2.15-0.04,3.23c-2.01,1.62-4.26,2.82-6.56,3.98
			c-0.83,1.26-0.81,2.88-1.2,4.32c-1.14,0.77-2.25,1.58-3.39,2.38c0,0.93-0.02,1.85-0.02,2.78c-1.48,1.64-1.99,3.75-1.99,5.93
			c-2.98-0.08-6.29,0.59-8.87-1.32c-1.24-1.16-2.74-0.16-4.08,0.2c-1.08-0.16-2.13-0.3-3.21-0.45c0.08,1.02,0.14,2.03,0.24,3.04
			c-2.23,0.37-4.47,0.67-6.72,0.63c-1.83-1.34-4.22-1.18-6.23-2.03c-2.23-1.08-2.56-4.14-4.83-5.14c-2.52-1.16-5.36-2.07-7.1-4.36
			c-0.49-0.67-1.32-1.56-0.61-2.39c1.46-1.6,4.18-2.88,3.06-5.56c1.46,1.03,2.68,2.76,4.53,3.09c2.31-0.93,4.59-1.99,7.12-2.01
			c1.99,0.02,3.27-1.64,4.18-3.19c1.32-2.35,3.57-4.14,4.3-6.82c-0.97-1.64-1.75-3.43-2.98-4.89c-2.29-1.42-4.95-2.25-7.63-2.54
			c-1.91-0.04-2.8-2.01-3.98-3.23C298.42,161.2,299.47,159.05,300.81,158.32z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#alborz">
                            <svg class="map-province alborz">
                                <path class="map-path" id="path-alborz" d="M336.92,197.61c1.17-4.31,5.09-4.93,10.38-5.27
			c2.39-0.15,4.29-0.17,5.82-0.19c2.42-0.03,3.87-0.05,4.76-0.54c0.5-0.28,0.71-0.43,0.81-0.51c-0.02-0.03-0.04-0.07-0.06-0.1
			c-0.08-0.12-0.16-0.25-0.25-0.42c-0.34-0.68-0.27-1.91,0.17-2.8c0.35-0.72,0.9-1.18,1.58-1.31c0.49-0.1,0.69-0.51,0.97-1.18
			c0.25-0.59,0.59-1.39,1.47-1.32c0.26,0.02,0.47,0,0.66-0.02c0.7-0.08,1.18-0.06,2.07,1c0.63,0.75,0.97,0.84,1.05,0.82
			c0,0,0.45-0.18,0.57-2.32c0.12-2.25,0.4-4.62,1.29-6.35c-1.5-0.64-3.07-1.16-4.45-2.06c-1.64-0.04-3.31,0-4.93-0.18
			c-1.87-0.61-3.45-2.11-5.52-2.03c-4.18-0.1-8.34-0.53-12.5-1.04c1.16,2.31,3.86,2.8,5.93,4c0.67,1.54,0.2,3.21,0.04,4.81
			c-2.15,1.58-4.34,3.19-6.9,4.04c-0.28,1.32-0.45,2.66-0.85,3.94c-0.85,0.99-2.03,1.6-3.07,2.35c0.28,2.82-1.91,4.85-2.27,7.51
			C334.71,198.11,335.81,197.83,336.92,197.61z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#booshehr">
                            <svg class="map-province booshehr">
                                <path class="map-path" id="path-booshehr" d="M324.01,387.42c0.69-2.41,3.94-4.02,6.05-2.39
			c1.73,1.3,3.51,2.56,5.03,4.08c2.82,4.14,7.81,6.7,9.01,11.87c3.92,2.37,8.38,3.55,12.54,5.38c2.17,3.43,3.88,7.43,7.63,9.44
			c5.36,2.84,7.9,8.52,11.59,13.01c2.03,2.64,3.55,5.72,4.49,8.91c0.04,5.01,0.22,10.11,1.73,14.92c1.5,2.6,3.02,5.2,4.26,7.94
			c0.85,2.01,3.19,2.52,4.63,3.98c1.1,1.58,0.89,3.59,0.95,5.42c1.22,1.4,3.02,2.48,3.39,4.42c0.38,1.55,0.73,3.12,1.34,4.6
			c0.61,1,1.77,1.93,2.52,2.5c3.21,2.45,6.41,4.95,9.72,7.27c-0.82,1.44-1.74,2.32-2.94,3.03c-2.15-1.83-3.68-2.27-6.32-3.19
			c1.26-0.04,4.26,0.22,3.69-1.93c-1.52-1.32-3.15-2.48-4.38-4.15c-0.62-0.85-2-2.05-3.23-3.04c-1.29-0.63-2.67-1.04-4.08-1.32
			c-3.21-0.57-5.3-3.27-7.59-5.32c-1.52-1.4-3.75-0.93-5.64-1.26c-3.25-0.55-6.54-0.71-9.82-0.81c-1.38-1.99-3.41-3.25-5.54-4.28
			c-1.4-1.32-2.44-3-3.55-4.57c-0.2-1.81,0.57-3.82-0.65-5.38c-2.01-3.04-3.98-6.15-5.18-9.62c-0.2-3.29,0.61-7.73-2.82-9.68
			c-2.48-0.85-4.99-2.27-5.34-5.18c1.75-0.97,4.65-3.09,2.84-5.24c-1.89-2.21-5.05-2.9-7.85-2.46c0.97-1.95,1.71-4.12,0.67-6.21
			c0.2-1.3,0.49-2.6,0.57-3.9c-2.76-1.83-4.79-4.36-6.66-7.04c-3.43-3.35-5.48-7.77-8.67-11.28c0.04-1.58,0.28-3.17,0.08-4.73
			C325.9,389.82,324.9,388.64,324.01,387.42z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#kohkilooyeh">
                            <svg class="map-province kohkilooyeh">
                                <path class="map-path" id="path-kohkilooyeh" d="M332.13,343.02
			c1.05,0.63,2.11,1.28,3.17,1.93c1.5,0.04,3.02-0.08,4.51,0.24c1.3,1.12,2.21,2.94,4.14,2.98c3,0.24,4.65,3.27,7.51,3.88
			c2.92,0.43,5.97-0.34,8.81,0.55c2.6,1.81,4.46,4.55,5.8,7.37c0.77,2.07,3.59,1.24,4.87,2.74c1.71,1.89,3.73,3.53,6.39,3.69
			c0.28,2.54-1.18,4.61-1.93,6.88c1.66,2.88,1.58,6.17,1.52,9.38c-1.06,1.16-2.56,2.31-4.2,1.58c-2.6-1.28-4.91-3.07-7.55-4.26
			c-2.25-0.95-3.82-2.9-5.76-4.3c-1.52-1.12-3.49-0.32-5.2-0.26c0.26,3.71,4.1,6.07,3.82,9.93c-1.62,1.62-3.39,3.25-5.83,3.29
			c-4.55,0.14-5.07,6.98-9.64,6.86c-2.19-2.38-4.79-4.4-6.48-7.21c0.26-0.24,0.77-0.73,1.04-0.95c0.22-3.67,1.2-7.71-0.89-11.02
			c1.3-1.32,2.44-2.82,3.25-4.5c-1.08-0.43-2.17-0.83-3.27-1.24c-0.73-2.23-2.5-3.45-4.69-4.02c-0.47-1.08-0.77-2.21-1.26-3.27
			c-2.39-1.22-5.18-0.95-7.73-1.6c-1.5-0.51-2.17-2.07-3-3.29c0.95-1.01,2.27-1.85,2.66-3.25c0-1.3-0.3-2.56-0.47-3.84
			c1.66-0.69,3.84-0.73,4.97-2.31C328.31,346.83,330.12,344.84,332.13,343.02z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#charmahal">
                            <svg class="map-province charmahal">
                                <path class="map-path" id="path-charmahal" d="M311.79,294.83c0.47-1.48,1.18-2.84,2.11-4.08
			c2.23,2.74,3.67,5.99,5.91,8.71c2.76,1.06,6.76-1.34,8.91,1.6c1.4,2.03,3.43,3.27,5.87,3.67c1.77-0.89,3-2.42,4.2-3.92
			c3.9-2.17,9.21-0.89,11.55,3c0.14,1.6-0.04,3.37,0.81,4.83c2.07,2.72,4.08,5.52,6.62,7.86c1.56,1.3,1.62,3.49,2.64,5.15
			c0.93,1.48,2.21,2.72,3.33,4.06c-0.87,2.82-2.17,5.5-3.17,8.28c0.08,2.54-0.34,5.56,1.6,7.55c0.59,0.85,0,2.03,0.02,3.02
			c-0.49,0.2-1.48,0.59-1.99,0.79c-0.61,1.87-0.41,3.82,0.02,5.72c-2.58-0.04-5.18,0.1-7.75-0.06c-2.39-0.16-4.1-2.05-5.97-3.33
			c-1.24-0.47-2.6-0.53-3.82-1.08c-0.91-0.81-1.66-1.77-2.48-2.68c-2.64,0.22-5.32-0.02-7.41-1.81c2.68-1.18,4.1-3.8,5.42-6.23
			c-0.39-0.97-1.03-1.83-1.58-2.68c-0.28-1.22-0.24-2.74-1.46-3.47c-2.56-1.95-4.83-4.2-7.23-6.33c-2.05-1.71-2.48-4.57-4.28-6.48
			c-1.44-1.58-1.5-3.82-2.37-5.68c-1.34-1.75-3.33-2.98-4.06-5.16c-0.95-3-4.14-4.08-6.56-5.6c-1.18-0.67-1.16-2.27-1.73-3.39
			C309.9,296.37,310.84,295.6,311.79,294.83z" />
                            </svg>
                        </a>

                        <a class="map-link" xlink:href="#golestan">
                            <svg class="map-province golestan">
                                <path class="map-path" id="path-golestan" d="M494.68,107.19c2.44-0.67,4.3,1.85,6.76,1.54
			c2.84-0.16,5.74-0.51,8.5,0.49c1.16,1.56,2.41,3.88,0.99,5.66c-4.99,3.55-6.68,9.97-7.43,15.75c-0.12,1.81-1.5,3.15-2.58,4.47
			c-1.34,1.95-4.24,1.1-5.66,2.86c-0.59,0.61-1.1,1.24-1.6,1.89c0.24,2.25-1.1,3.96-2.68,5.38c0.1,1.08,0.22,2.15,0.35,3.23
			c-1.56,3-2.48,6.39-4.85,8.91c-3.33-0.04-6.68-0.79-9.94,0.08c-2.44,0.51-4.3,2.21-6.39,3.41c-1.66,1.02-3.67,0.28-5.44,0.02
			c-2.52,1.04-4.02,3.47-6.31,4.81c-2.09,0.45-4.22,0.47-6.31,0.69c0-2.07-1.58-2.96-3.43-3.21c-0.49-0.89-0.93-1.83-1.5-2.66
			c-1.66-1.14-3.98-1.01-5.52-2.39c-0.47-1-0.28-2.17-0.45-3.23c1.79-0.41,3.55-0.85,5.32-1.32c0.73-2.15,0.22-4.38-0.2-6.54
			c-0.63-4.04-2.21-7.88-2.86-11.91c2.9,0.04,5.76,0.63,8.65,0.77c2.54-0.63,4.75-2.03,6.92-3.39c1.77-1.2,3.92,0.12,5.87-0.28
			c1.12-0.59,2.05-1.5,2.78-2.54c1.83-2.8,0.28-6.82,2.88-9.25c2.58-2.19,5.42-4.1,7.53-6.76c3-0.67,5.8-2.07,8.12-4.12
			C488.43,107.32,491.8,107.78,494.68,107.19z" />
                            </svg>
                        </a>
                        <!-- End province -->

                        <svg class="map-sea-names">
                            <g class="map-sea-names">
                                <path d="M405.31,537.88c0,0.61-0.15,1.12-0.44,1.53c-0.33,0.47-0.79,0.7-1.38,0.7c-0.72,0-1.24-0.29-1.55-0.86
				c-0.33,0.57-0.84,0.86-1.54,0.86c-0.5,0-0.88-0.14-1.15-0.42c0,0.13,0,0.25,0,0.38c0,1.3-0.41,2.33-1.22,3.1
				c-0.81,0.77-1.87,1.15-3.18,1.15c-1.09,0-1.97-0.32-2.63-0.96c-0.66-0.64-0.99-1.51-0.99-2.59c0-0.87,0.25-1.73,0.76-2.57
				l0.82,0.31c-0.14,0.23-0.28,0.55-0.39,0.97c-0.12,0.42-0.18,0.76-0.18,1.04c0,1.72,0.94,2.59,2.82,2.59
				c0.88,0,1.62-0.22,2.23-0.65c0.69-0.49,1.03-1.15,1.03-2c0-0.84-0.27-1.69-0.8-2.53l0.97-0.83c0.28,0.58,0.52,0.98,0.72,1.21
				c0.32,0.38,0.7,0.58,1.12,0.58c0.47,0,0.79-0.11,0.97-0.34c0.16-0.19,0.24-0.53,0.24-1.02v-0.2l0.81-0.29v0.13
				c0,1.15,0.4,1.72,1.2,1.72c0.55,0,0.83-0.29,0.83-0.86c0-0.23-0.16-0.58-0.49-1.05l0.8-0.91
				C405.1,536.57,405.31,537.17,405.31,537.88z" />
                                <path d="M411.6,538.41c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C411.3,536.67,411.6,537.53,411.6,538.41z" />
                                <path d="M416.26,540.11h-0.52c-0.86,0-1.48-0.37-1.84-1.12c-0.24-0.5-0.39-1.27-0.43-2.3
				c-0.02-0.36-0.04-1.37-0.06-3.03c-0.02-1.14-0.08-2.33-0.18-3.55l1.11-0.57c0.03,2.42,0.08,4.72,0.14,6.92
				c0.02,0.72,0.09,1.25,0.23,1.58c0.22,0.54,0.62,0.82,1.21,0.82h0.34V540.11z" />
                                <path d="M420.16,537.2c0,1.94-1,2.91-2.99,2.91h-1.44v-1.24h1.3c0.33,0,0.73-0.07,1.22-0.21
				c0.63-0.17,0.94-0.38,0.94-0.63v-0.54c-0.36,0.22-0.77,0.32-1.23,0.32c-0.4,0-0.72-0.12-0.96-0.35c-0.24-0.23-0.35-0.55-0.35-0.95
				c0-0.47,0.14-1,0.43-1.6c0.36-0.76,0.79-1.14,1.3-1.14c0.55,0,1,0.46,1.36,1.37C420.01,535.86,420.16,536.55,420.16,537.2z
				 M419.07,531.59l-0.81,1.07l-1.09-0.72l0.79-1.09L419.07,531.59z M418.98,536.42c-0.17-0.94-0.43-1.41-0.81-1.41
				c-0.17,0-0.33,0.14-0.49,0.41c-0.15,0.24-0.22,0.46-0.22,0.64c0,0.43,0.22,0.64,0.67,0.64
				C418.48,536.71,418.77,536.61,418.98,536.42z" />
                                <path d="M434.86,545.95c-1.12,0.38-2.26,0.57-3.43,0.57c-1.54,0-2.75-0.28-3.65-0.85
				c-1.09-0.68-1.63-1.75-1.63-3.2c0-1.2,0.5-2.3,1.5-3.3c0.8-0.8,1.79-1.42,2.97-1.88c-1.35-0.4-2.12-0.6-2.33-0.6
				c-0.37,0-0.71,0.26-1.02,0.79l-0.8-0.35c0.48-1.12,1.04-1.69,1.7-1.69c0.47,0,1.27,0.17,2.41,0.5c1.13,0.33,2.01,0.5,2.62,0.5
				c0.29,0,0.59-0.01,0.89-0.04l-0.32,1.25c-0.76,0.01-1.32,0.09-1.67,0.23c0.06,0.42,0.26,0.71,0.59,0.85
				c0.24,0.1,0.67,0.15,1.28,0.15h0.85v1.24h-1.17c-0.6,0-1.1-0.2-1.5-0.59c-0.4-0.39-0.62-0.89-0.67-1.5
				c-1.13,0.38-2.07,0.91-2.82,1.57c-0.94,0.83-1.41,1.76-1.41,2.79c0,1.94,1.51,2.91,4.52,2.91c1.12,0,2.05-0.13,2.78-0.39
				L434.86,545.95z M431.6,542.17l-0.82,1.07l-1.07-0.72l0.79-1.09L431.6,542.17z" />
                                <path d="M439.36,540.11h-0.71c-0.97,0-1.61-0.34-1.91-1.02c-0.15,0.31-0.39,0.56-0.72,0.75
				c-0.33,0.18-0.67,0.28-1.03,0.28h-0.72v-1.24h0.64c0.42,0,0.76-0.09,1.04-0.28c0.32-0.22,0.48-0.52,0.48-0.92v-0.53l0.85-0.23
				c0.01,0.81,0.15,1.35,0.43,1.63c0.22,0.22,0.59,0.33,1.13,0.33h0.51V540.11z M438.49,542.36l-0.72,0.92l-0.95-0.7l-0.67,0.83
				l-1.01-0.71l0.77-0.93l0.9,0.67l0.66-0.8L438.49,542.36z" />
                                <path d="M443.23,540.11h-0.52c-0.73,0-1.25-0.37-1.56-1.12c-0.44,0.75-1.04,1.12-1.78,1.12h-0.53v-1.24h0.28
				c0.67,0,1.11-0.2,1.33-0.62c0.17-0.31,0.24-0.82,0.22-1.56l-0.19-6.58l1.1-0.57v6.73c0,1.72,0.44,2.58,1.32,2.58h0.34V540.11z" />
                                <path d="M450.91,536.63l-0.28,1.19c-0.98,0.01-1.81,0.21-2.49,0.61c-0.33,0.21-0.94,0.57-1.81,1.09
				c-0.69,0.39-1.58,0.59-2.67,0.59h-0.94v-1.24h0.99c0.75,0,1.38-0.08,1.89-0.25c0.33-0.11,0.78-0.32,1.35-0.63
				c0.6-0.34,1.04-0.56,1.33-0.67c-0.32-0.08-0.8-0.27-1.46-0.58c-0.6-0.28-1-0.42-1.17-0.42c-0.28,0-0.65,0.23-1.11,0.69l-0.71-0.41
				c0.19-0.33,0.45-0.65,0.77-0.95c0.38-0.35,0.7-0.53,0.96-0.53c0.39,0,0.87,0.14,1.46,0.41c0.94,0.44,1.49,0.69,1.65,0.74
				C449.35,536.53,450.11,536.65,450.91,536.63z M448.21,532.78l-0.82,1.06l-1.08-0.73l0.8-1.1L448.21,532.78z" />
                            </g>
                            <g class="map-sea-names">
                                <path d="M343.29,90.64c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C343,88.9,343.29,89.76,343.29,90.64z" />
                                <path d="M351.26,92.34h-0.51c-0.42,0-0.78-0.08-1.07-0.22c-0.13,1.03-0.77,2.04-1.92,3.03
				c-0.78,0.67-1.66,1.23-2.66,1.7l-0.78-0.65c1.11-0.64,2.07-1.3,2.86-1.96c1-0.84,1.5-1.53,1.5-2.06c0-0.4-0.25-0.95-0.75-1.65
				l0.83-0.96c0.42,0.59,0.67,0.93,0.75,1.01c0.34,0.35,0.75,0.52,1.23,0.52h0.52V92.34z M348.8,86.98l-0.81,1.07l-1.09-0.73
				l0.79-1.09L348.8,86.98z" />
                                <path d="M358.94,88.86l-0.28,1.19c-0.98,0.01-1.81,0.21-2.49,0.61c-0.33,0.21-0.94,0.57-1.81,1.09
				c-0.69,0.39-1.58,0.59-2.67,0.59h-0.94V91.1h0.99c0.75,0,1.38-0.08,1.89-0.25c0.33-0.11,0.78-0.32,1.35-0.63
				c0.6-0.34,1.04-0.56,1.33-0.67c-0.32-0.08-0.8-0.27-1.46-0.58c-0.6-0.28-1-0.42-1.17-0.42c-0.28,0-0.65,0.23-1.11,0.69l-0.71-0.41
				c0.19-0.33,0.45-0.65,0.77-0.95c0.38-0.35,0.7-0.53,0.96-0.53c0.39,0,0.87,0.14,1.46,0.41c0.94,0.44,1.49,0.69,1.65,0.74
				C357.39,88.76,358.14,88.88,358.94,88.86z M356.24,85.01l-0.82,1.06l-1.09-0.73l0.8-1.1L356.24,85.01z" />
                                <path d="M374.52,86.85l-0.41,1.1c-0.27-0.12-0.58-0.17-0.94-0.17c-0.54,0-1.09,0.18-1.66,0.54
				c-0.6,0.39-0.97,0.83-1.09,1.32c-0.01,0.04-0.02,0.1-0.02,0.16c0,0.26,0.32,0.44,0.97,0.52c0.43,0.03,0.85,0.06,1.28,0.09
				c1,0.11,1.5,0.58,1.5,1.41c0,0.84-0.62,1.62-1.86,2.35c-1.19,0.7-2.37,1.05-3.56,1.05c-1.15,0-2.06-0.26-2.73-0.77
				c-0.74-0.57-1.11-1.42-1.11-2.54c0-0.96,0.25-1.85,0.76-2.65l0.81,0.36c-0.38,0.68-0.57,1.32-0.57,1.94
				c0,1.62,1.01,2.43,3.02,2.43c0.68,0,1.4-0.13,2.15-0.38c0.78-0.26,1.42-0.6,1.92-1.02c0.24-0.21,0.37-0.39,0.37-0.54
				c0-0.21-0.18-0.33-0.54-0.37c-1.51-0.18-2.36-0.3-2.57-0.38c-0.47-0.17-0.7-0.57-0.7-1.21c0-0.88,0.42-1.7,1.27-2.45
				c0.82-0.73,1.68-1.1,2.57-1.1C373.83,86.51,374.2,86.62,374.52,86.85z" />
                                <path d="M379.16,92.34h-0.52c-0.86,0-1.48-0.37-1.84-1.12c-0.24-0.5-0.39-1.27-0.43-2.3
				c-0.02-0.36-0.04-1.37-0.06-3.03c-0.02-1.14-0.08-2.33-0.18-3.55l1.11-0.57c0.03,2.42,0.08,4.72,0.14,6.92
				c0.02,0.72,0.09,1.25,0.23,1.58c0.22,0.54,0.62,0.82,1.21,0.82h0.34V92.34z" />
                                <path d="M381.83,90.2c0,1.43-0.83,2.14-2.49,2.14h-0.71V91.1h0.77c0.96,0,1.44-0.26,1.44-0.78
				c0-0.28-0.14-0.6-0.42-0.97l-0.28-0.37l0.86-0.94C381.55,88.67,381.83,89.38,381.83,90.2z M382.67,94.59l-0.72,0.92l-0.95-0.7
				l-0.67,0.83l-1.01-0.71l0.77-0.93l0.9,0.67l0.66-0.8L382.67,94.59z" />
                                <path d="M388.76,90.64c0,0.99-0.57,2-1.72,3.03c-0.82,0.73-1.7,1.33-2.67,1.78l-0.86-0.66
				c1.09-0.6,2.03-1.25,2.82-1.93c0.96-0.83,1.44-1.52,1.44-2.05c0-0.53-0.25-1.16-0.76-1.87l0.87-0.87
				C388.47,88.9,388.76,89.76,388.76,90.64z" />
                                <path d="M395.78,90.06c0,1.01-0.43,1.7-1.29,2.05c-0.37,0.15-1.04,0.24-2.03,0.28c-0.91,0.04-1.61-0.2-2.1-0.71
				l0.56-0.96c0.32,0.24,0.78,0.37,1.41,0.37c0.67,0,1.12-0.02,1.36-0.07c0.8-0.14,1.2-0.41,1.2-0.8c0-0.81-0.8-1.74-2.41-2.78
				l0.51-1.25c0.67,0.38,1.26,0.89,1.8,1.51C395.44,88.51,395.78,89.29,395.78,90.06z" />
                            </g>
                        </svg>
                        <svg class="map-province-names">
                            <g class="map-province-names">
                                <path d="M563.21,189.12l-0.36,0.96c-0.23-0.1-0.51-0.15-0.82-0.15c-0.47,0-0.95,0.16-1.45,0.47
				c-0.53,0.34-0.85,0.72-0.95,1.16c-0.01,0.04-0.01,0.08-0.01,0.14c0,0.23,0.28,0.38,0.85,0.46c0.37,0.02,0.75,0.05,1.12,0.08
				c0.88,0.1,1.32,0.51,1.32,1.23c0,0.73-0.54,1.42-1.63,2.06c-1.04,0.61-2.08,0.92-3.11,0.92c-1.01,0-1.8-0.23-2.39-0.68
				c-0.65-0.5-0.97-1.24-0.97-2.23c0-0.84,0.22-1.62,0.66-2.32l0.71,0.31c-0.33,0.59-0.5,1.16-0.5,1.7c0,1.42,0.88,2.12,2.64,2.12
				c0.6,0,1.22-0.11,1.88-0.33c0.68-0.23,1.24-0.53,1.68-0.9c0.21-0.18,0.32-0.34,0.32-0.47c0-0.18-0.16-0.29-0.47-0.33
				c-1.32-0.16-2.07-0.27-2.25-0.34c-0.41-0.15-0.61-0.5-0.61-1.06c0-0.77,0.37-1.49,1.11-2.15c0.72-0.64,1.47-0.96,2.25-0.96
				C562.6,188.82,562.93,188.92,563.21,189.12z" />
                                <path d="M569.43,193.92h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V193.92z M567.29,192.82
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C566.88,192.93,567.13,192.9,567.29,192.82z" />
                                <path d="M578.38,191.19c0,0.96-0.43,1.68-1.3,2.16c-0.7,0.38-1.57,0.58-2.61,0.58h-1.96c-0.46,0-0.8-0.03-1.02-0.1
				c-0.32-0.1-0.58-0.31-0.77-0.62c-0.32,0.49-0.74,0.73-1.27,0.73h-0.47v-1.08h0.33c0.71,0,1.06-0.38,1.06-1.13v-0.28l0.82-0.29
				v0.18c0,1.02,0.29,1.53,0.88,1.53c0.32,0,0.57-0.12,0.76-0.36c0.12-0.15,0.33-0.42,0.64-0.81c0.35-0.43,0.8-0.84,1.34-1.23
				c0.72-0.52,1.37-0.78,1.96-0.78c0.43,0,0.81,0.15,1.13,0.44C578.22,190.4,578.38,190.76,578.38,191.19z M577.45,191.56
				c0-0.27-0.12-0.48-0.37-0.64c-0.2-0.13-0.45-0.19-0.74-0.19c-0.67,0-1.66,0.7-2.96,2.11h1.17c1,0,1.77-0.15,2.29-0.46
				C577.25,192.14,577.45,191.87,577.45,191.56z M575.97,187.15l-0.71,0.94l-0.95-0.64l0.69-0.95L575.97,187.15z" />
                                <path d="M583.87,192.44c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C583.61,190.92,583.87,191.67,583.87,192.44z" />
                                <path d="M595.94,191.73c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C595.65,190.04,595.94,190.86,595.94,191.73z M593.33,188.18l-0.71,0.93l-0.95-0.64l0.7-0.95L593.33,188.18z" />
                                <path d="M600.02,193.92h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V193.92z" />
                                <path d="M607.16,192c0,0.52-0.14,0.97-0.41,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C606.97,190.81,607.16,191.36,607.16,192z" />
                                <path d="M609.53,193.72l-0.73,0.2l-0.23-8.86l0.97-0.37V193.72z" />
                                <path d="M616.5,193.92h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V193.92z" />
                                <path d="M623.22,190.88l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C621.86,190.8,622.52,190.9,623.22,190.88z M620.86,187.51l-0.71,0.93l-0.95-0.64l0.7-0.96
				L620.86,187.51z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M545.98,289.01h-1.67c-0.72,0-1.08,0.08-1.08,0.24c0,0.1,0.28,0.21,0.84,0.33
				c0.66,0.14,1.03,0.23,1.1,0.26c0.35,0.18,0.53,0.48,0.53,0.9c0,0.66-0.53,1.22-1.59,1.69c-0.87,0.38-1.69,0.57-2.44,0.57
				c-1.02,0-1.81-0.24-2.38-0.71c-0.61-0.51-0.91-1.27-0.91-2.27c0-0.72,0.21-1.48,0.63-2.27l0.79,0.27
				c-0.31,0.64-0.47,1.23-0.47,1.76c0,1.42,0.82,2.12,2.45,2.12c1.27,0,2.28-0.29,3.04-0.86c0.07-0.05,0.11-0.11,0.11-0.16
				c0-0.07-0.05-0.12-0.16-0.13c-0.96-0.15-1.61-0.29-1.94-0.44c-0.11-0.05-0.21-0.16-0.28-0.32c-0.08-0.16-0.12-0.31-0.12-0.44
				c0-1.08,0.95-1.61,2.84-1.61h0.69V289.01z" />
                                <path d="M548.33,287.14c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C548.08,285.8,548.33,286.43,548.33,287.14z M548.05,291.04l-0.71,0.93
				l-0.95-0.63l0.7-0.96L548.05,291.04z" />
                                <path d="M554.57,289.01h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V289.01z M552.43,287.91
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C552.02,288.01,552.27,287.99,552.43,287.91z" />
                                <path d="M558.54,289.01h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V289.01z M556.9,283.85l-0.71,0.93l-0.95-0.64l0.7-0.95
				L556.9,283.85z" />
                                <path d="M565.27,285.97l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C563.9,285.88,564.57,285.99,565.27,285.97z M563.36,290.67l-0.71,0.93l-0.95-0.63l0.7-0.96
				L563.36,290.67z" />
                                <path d="M577.32,286.82c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C577.02,285.13,577.32,285.95,577.32,286.82z M574.7,283.27l-0.71,0.93l-0.95-0.64l0.7-0.95L574.7,283.27z" />
                                <path d="M581.39,289.01h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V289.01z" />
                                <path d="M588.53,287.08c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C588.34,285.9,588.53,286.45,588.53,287.08z" />
                                <path d="M590.91,288.81l-0.73,0.2l-0.23-8.86l0.97-0.37V288.81z" />
                                <path d="M597.87,289.01h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V289.01z" />
                                <path d="M604.59,285.97l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C603.23,285.88,603.9,285.99,604.59,285.97z M602.23,282.6l-0.71,0.93l-0.95-0.64l0.7-0.96
				L602.23,282.6z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M540.6,408.31c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C540.3,406.61,540.6,407.43,540.6,408.31z M537.99,404.76l-0.71,0.93l-0.95-0.64l0.7-0.95L537.99,404.76z" />
                                <path d="M544.67,410.5h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V410.5z" />
                                <path d="M549.43,408.93c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C549.32,407.87,549.43,408.41,549.43,408.93z M548.54,408.69c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C548.48,409.1,548.54,408.96,548.54,408.69z" />
                                <path d="M556.39,410.5h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V410.5z" />
                                <path d="M561.81,401.55l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C557.72,403.49,559.56,402.51,561.81,401.55z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M221.84,100.58c0,0.96-0.29,1.73-0.87,2.3c-0.58,0.57-1.35,0.86-2.31,0.86c-0.84,0-1.5-0.28-2-0.85
				c-0.44-0.5-0.66-1.1-0.66-1.8c0-0.61,0.18-1.19,0.55-1.73l0.6,0.22c-0.25,0.5-0.37,0.93-0.37,1.31c0,1.29,0.67,1.93,2,1.93
				c0.67,0,1.21-0.18,1.62-0.53c0.42-0.38,0.64-0.89,0.64-1.56c0-0.6-0.21-1.16-0.62-1.7l0.66-0.56
				C221.59,99.12,221.84,99.82,221.84,100.58z M219.61,97.53l-0.61,0.8l-0.81-0.55l0.6-0.82L219.61,97.53z" />
                                <path d="M225.34,102.45h-0.39c-0.65,0-1.11-0.28-1.38-0.84c-0.18-0.38-0.29-0.95-0.32-1.72
				c-0.01-0.27-0.03-1.03-0.04-2.27c-0.01-0.86-0.06-1.74-0.14-2.66l0.83-0.42c0.02,1.82,0.06,3.54,0.11,5.19
				c0.01,0.54,0.07,0.94,0.17,1.19c0.17,0.41,0.47,0.61,0.9,0.61h0.26V102.45z" />
                                <path d="M232.19,102.45h-0.99c-0.56,0-0.96-0.19-1.21-0.56c-0.07-0.11-0.18-0.42-0.33-0.92l-1.9,0.98
				c-0.64,0.33-1.33,0.5-2.06,0.5h-0.76v-0.92h0.74c0.73,0,1.36-0.12,1.9-0.37c0.32-0.15,0.88-0.42,1.7-0.8
				c-0.36-0.08-0.8-0.23-1.32-0.47c-0.48-0.22-0.78-0.33-0.9-0.33c-0.25,0-0.49,0.17-0.74,0.5l-0.57-0.3
				c0.42-0.77,0.83-1.16,1.23-1.16c0.28,0,0.64,0.1,1.08,0.3c0.68,0.3,1.1,0.49,1.27,0.54c0.57,0.19,1.16,0.29,1.77,0.29
				c0.12,0,0.25,0,0.37,0l-0.21,0.87c-0.5,0-0.88,0.07-1.17,0.21c0.08,0.3,0.25,0.5,0.51,0.61c0.18,0.08,0.45,0.11,0.82,0.11h0.75
				V102.45z M229.46,103.87l-0.61,0.8l-0.81-0.54l0.6-0.82L229.46,103.87z" />
                                <path d="M234.2,100.85c0,1.07-0.62,1.61-1.86,1.61h-0.53v-0.93h0.58c0.72,0,1.08-0.19,1.08-0.58
				c0-0.21-0.11-0.45-0.32-0.73l-0.21-0.28l0.64-0.71C233.99,99.7,234.2,100.24,234.2,100.85z M234.84,104.14l-0.54,0.69l-0.71-0.52
				l-0.5,0.62l-0.75-0.54l0.57-0.7l0.68,0.5l0.49-0.6L234.84,104.14z" />
                                <path d="M238.18,102.45h-0.39c-0.65,0-1.11-0.28-1.38-0.84c-0.18-0.38-0.29-0.95-0.32-1.72
				c-0.01-0.27-0.03-1.03-0.04-2.27c-0.01-0.86-0.06-1.74-0.14-2.66l0.83-0.42c0.02,1.82,0.06,3.54,0.11,5.19
				c0.01,0.54,0.07,0.94,0.17,1.19c0.17,0.41,0.47,0.61,0.9,0.61h0.26V102.45z" />
                                <path d="M240.18,100.85c0,1.07-0.62,1.61-1.86,1.61h-0.53v-0.93h0.58c0.72,0,1.08-0.19,1.08-0.58
				c0-0.21-0.11-0.45-0.32-0.73l-0.21-0.28l0.64-0.71C239.97,99.7,240.18,100.24,240.18,100.85z M239.94,104.19l-0.61,0.8l-0.81-0.54
				l0.6-0.82L239.94,104.19z" />
                                <path d="M244.9,101.18c0,0.74-0.43,1.5-1.29,2.27c-0.61,0.55-1.28,0.99-2,1.33l-0.65-0.49
				c0.82-0.45,1.52-0.94,2.11-1.45c0.72-0.62,1.08-1.14,1.08-1.54c0-0.4-0.19-0.87-0.57-1.4l0.65-0.66
				C244.67,99.88,244.9,100.52,244.9,101.18z" />
                                <path d="M250.16,100.75c0,0.76-0.32,1.27-0.97,1.53c-0.27,0.11-0.78,0.18-1.52,0.21
				c-0.68,0.03-1.21-0.15-1.58-0.53l0.42-0.72c0.24,0.18,0.59,0.27,1.05,0.27c0.5,0,0.84-0.02,1.02-0.05c0.6-0.11,0.9-0.31,0.9-0.6
				c0-0.61-0.6-1.31-1.81-2.08l0.38-0.94c0.5,0.29,0.95,0.67,1.35,1.13C249.91,99.58,250.16,100.17,250.16,100.75z M248.16,96.06
				l-0.61,0.8l-0.81-0.55l0.6-0.82L248.16,96.06z" />
                                <path d="M255.09,93.25c-0.15,0.23-0.34,0.43-0.59,0.59c-0.26,0.17-0.52,0.25-0.79,0.25c-0.16,0-0.39-0.03-0.7-0.08
				c-0.31-0.05-0.54-0.08-0.7-0.08c-0.27,0-0.53,0.1-0.79,0.29l-0.38-0.45c0.33-0.35,0.68-0.52,1.04-0.52c0.15,0,0.38,0.02,0.68,0.07
				c0.3,0.05,0.53,0.07,0.68,0.07c0.47,0,0.9-0.18,1.3-0.55L255.09,93.25z M253.45,102.28l-0.63,0.17l-0.19-7.6l0.82-0.32V102.28z" />
                                <path d="M231.09,117.78h-1.43c-0.62,0-0.92,0.07-0.92,0.21c0,0.09,0.24,0.18,0.72,0.28
				c0.57,0.12,0.88,0.2,0.94,0.22c0.3,0.15,0.46,0.41,0.46,0.77c0,0.56-0.45,1.05-1.36,1.44c-0.75,0.33-1.44,0.49-2.09,0.49
				c-0.87,0-1.55-0.2-2.04-0.61c-0.52-0.44-0.78-1.09-0.78-1.95c0-0.62,0.18-1.27,0.54-1.95l0.68,0.23c-0.27,0.55-0.4,1.05-0.4,1.51
				c0,1.21,0.7,1.82,2.1,1.82c1.08,0,1.95-0.25,2.61-0.74c0.06-0.05,0.09-0.09,0.09-0.14c0-0.06-0.05-0.1-0.14-0.11
				c-0.82-0.12-1.38-0.25-1.66-0.38c-0.1-0.05-0.18-0.14-0.24-0.27c-0.07-0.14-0.1-0.26-0.1-0.38c0-0.92,0.81-1.38,2.43-1.38h0.59
				V117.78z" />
                                <path d="M234.02,115.6c0,1.45-0.75,2.18-2.24,2.18h-1.08v-0.93h0.97c0.25,0,0.55-0.05,0.92-0.16
				c0.47-0.13,0.71-0.29,0.71-0.47v-0.41c-0.27,0.16-0.58,0.24-0.92,0.24c-0.3,0-0.54-0.09-0.72-0.26c-0.18-0.17-0.27-0.41-0.27-0.71
				c0-0.35,0.11-0.75,0.32-1.2c0.27-0.57,0.59-0.85,0.97-0.85c0.41,0,0.75,0.34,1.02,1.02C233.92,114.6,234.02,115.12,234.02,115.6z
				 M233.68,111.35l-0.54,0.69l-0.71-0.52l-0.5,0.62l-0.75-0.54l0.57-0.7l0.69,0.51l0.49-0.6L233.68,111.35z M233.14,115.02
				c-0.12-0.7-0.33-1.05-0.61-1.05c-0.12,0-0.25,0.1-0.37,0.31c-0.11,0.18-0.17,0.34-0.17,0.48c0,0.32,0.17,0.48,0.5,0.48
				C232.77,115.23,232.98,115.16,233.14,115.02z" />
                                <path d="M239.99,117.78h-0.38c-0.32,0-0.58-0.06-0.8-0.17c-0.1,0.77-0.58,1.53-1.44,2.27
				c-0.58,0.5-1.25,0.93-2,1.28l-0.59-0.49c0.84-0.48,1.55-0.97,2.15-1.47c0.75-0.63,1.12-1.15,1.12-1.55c0-0.3-0.19-0.71-0.56-1.23
				l0.62-0.72c0.31,0.44,0.5,0.7,0.56,0.76c0.26,0.26,0.57,0.39,0.92,0.39h0.39V117.78z" />
                                <path d="M246.12,116.13c0,0.45-0.12,0.83-0.36,1.13c-0.26,0.34-0.6,0.5-1.04,0.5c-0.57,0-0.98-0.21-1.2-0.64
				c-0.31,0.42-0.72,0.64-1.25,0.64c-0.57,0-0.93-0.21-1.09-0.64c-0.24,0.43-0.63,0.64-1.18,0.64h-0.4v-0.93h0.22
				c0.69,0,1.04-0.34,1.04-1.01v-0.15l0.61-0.22v0.16c0,0.81,0.27,1.22,0.8,1.22c0.62,0,0.93-0.34,0.93-1.02v-0.15l0.61-0.22v0.16
				c0,0.81,0.31,1.22,0.93,1.22c0.44,0,0.67-0.2,0.67-0.6c0-0.28-0.13-0.56-0.38-0.83l0.6-0.68
				C245.96,115.12,246.12,115.58,246.12,116.13z M244.77,112.82l-0.48,0.63l-0.69-0.51l-0.48,0.6l-0.67-0.48l0.51-0.63l0.66,0.49
				l0.46-0.58L244.77,112.82z M243.96,111.71l-0.45,0.59l-0.68-0.5l0.47-0.59L243.96,111.71z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M183.33,105.48l-0.42-1.37c-0.18-0.59-0.33-0.86-0.46-0.82c-0.08,0.03-0.1,0.28-0.06,0.77
				c0.05,0.58,0.07,0.9,0.06,0.97c-0.06,0.33-0.26,0.55-0.61,0.66c-0.54,0.16-1.13-0.13-1.78-0.88c-0.53-0.62-0.89-1.24-1.08-1.86
				c-0.25-0.84-0.26-1.54-0.01-2.13c0.27-0.63,0.82-1.06,1.64-1.31c0.59-0.18,1.26-0.2,2.02-0.05l-0.02,0.72
				c-0.6-0.09-1.12-0.08-1.56,0.06c-1.16,0.35-1.54,1.2-1.13,2.54c0.32,1.04,0.8,1.8,1.47,2.28c0.06,0.05,0.11,0.06,0.16,0.05
				c0.06-0.02,0.08-0.07,0.07-0.16c-0.12-0.82-0.16-1.39-0.12-1.7c0.02-0.11,0.08-0.21,0.19-0.31s0.22-0.17,0.33-0.21
				c0.88-0.27,1.56,0.37,2.03,1.92l0.17,0.57L183.33,105.48z" />
                                <path d="M182.18,107.68l-0.94-0.35l0.28-0.93l0.96,0.33L182.18,107.68z M185.45,106.94
				c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.56c0.21,0.69,0.5,0.98,0.87,0.86c0.2-0.06,0.4-0.23,0.6-0.52
				l0.2-0.28l0.86,0.41C186.49,106.41,186.03,106.76,185.45,106.94z" />
                                <path d="M185.65,113.12l-0.11-0.36c-0.09-0.3-0.12-0.57-0.07-0.82c-0.77,0.13-1.63-0.11-2.59-0.72
				c-0.65-0.41-1.25-0.93-1.8-1.54l0.3-0.7c0.7,0.66,1.38,1.2,2.03,1.63c0.82,0.53,1.42,0.74,1.81,0.62
				c0.29-0.09,0.63-0.38,1.02-0.89l0.87,0.39c-0.33,0.43-0.52,0.68-0.56,0.76c-0.17,0.32-0.21,0.66-0.1,1l0.11,0.38L185.65,113.12z" />
                                <path d="M188.6,117.19l-0.85,0.16c-0.95-1.36-1.65-2.76-2.09-4.2l-0.12-0.39l0.89-0.27l0.42,1.4
				c0.21-0.47,0.6-0.79,1.19-0.97c0.41-0.12,0.83-0.08,1.27,0.15c0.49,0.25,0.83,0.65,0.99,1.21c0.17,0.55,0.13,1.1-0.12,1.66
				l-0.67-0.11c0.1-0.43,0.08-0.87-0.06-1.32c-0.09-0.28-0.23-0.52-0.44-0.71c-0.25-0.22-0.5-0.3-0.76-0.22
				c-0.36,0.11-0.57,0.38-0.64,0.81c-0.06,0.33-0.02,0.7,0.1,1.1C187.81,115.83,188.11,116.4,188.6,117.19z M192.45,113.95
				l-0.94-0.35l0.28-0.94l0.96,0.33L192.45,113.95z" />
                                <path d="M191.83,127.01c-0.92,0.28-1.74,0.23-2.45-0.16c-0.72-0.39-1.22-1.04-1.49-1.96
				c-0.24-0.8-0.17-1.52,0.23-2.16c0.35-0.57,0.86-0.95,1.53-1.15c0.59-0.18,1.19-0.17,1.82,0.02l-0.03,0.64
				c-0.54-0.09-1-0.08-1.36,0.03c-1.23,0.37-1.65,1.2-1.26,2.47c0.2,0.64,0.52,1.11,0.98,1.4c0.48,0.3,1.04,0.35,1.68,0.16
				c0.57-0.17,1.05-0.54,1.44-1.08l0.73,0.47C193.15,126.34,192.55,126.79,191.83,127.01z M194.09,123.98l-0.94-0.35l0.29-0.94
				l0.95,0.33L194.09,123.98z" />
                                <path d="M191.05,130.89l-0.11-0.37c-0.19-0.62-0.06-1.14,0.4-1.56c0.31-0.29,0.83-0.56,1.55-0.81
				c0.25-0.09,0.98-0.33,2.16-0.7c0.82-0.26,1.65-0.56,2.5-0.9l0.65,0.67c-1.73,0.55-3.37,1.09-4.93,1.61
				c-0.51,0.17-0.88,0.34-1.08,0.51c-0.34,0.28-0.45,0.62-0.32,1.04l0.07,0.25L191.05,130.89z" />
                                <path d="M190.89,135.25l-0.94-0.35l0.28-0.93l0.96,0.33L190.89,135.25z M193.04,137.45l-0.29-0.94
				c-0.16-0.54-0.1-0.98,0.19-1.32c0.08-0.1,0.34-0.29,0.79-0.58l-1.49-1.53c-0.51-0.52-0.87-1.13-1.08-1.82l-0.22-0.73l0.88-0.27
				l0.21,0.7c0.21,0.7,0.51,1.27,0.91,1.71c0.24,0.26,0.66,0.72,1.26,1.4c-0.03-0.36-0.01-0.83,0.07-1.4
				c0.07-0.52,0.08-0.84,0.05-0.95c-0.07-0.23-0.3-0.42-0.69-0.56l0.12-0.63c0.86,0.17,1.35,0.45,1.47,0.84
				c0.08,0.27,0.09,0.64,0.03,1.12c-0.09,0.74-0.14,1.19-0.15,1.37c-0.02,0.61,0.06,1.2,0.24,1.77c0.04,0.12,0.07,0.24,0.11,0.36
				l-0.9,0.05c-0.15-0.47-0.33-0.82-0.54-1.05c-0.26,0.16-0.41,0.38-0.43,0.67c-0.02,0.19,0.02,0.46,0.13,0.81l0.22,0.72
				L193.04,137.45z" />
                                <path d="M192.19,140.47l-0.82-0.32l0.29-0.83l-0.74-0.3l0.29-0.88l0.83,0.35l-0.29,0.8l0.71,0.3L192.19,140.47z
				 M195.16,138.91c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.55c0.21,0.69,0.5,0.98,0.87,0.86
				c0.2-0.06,0.4-0.23,0.6-0.52l0.2-0.28l0.86,0.41C196.2,138.38,195.74,138.73,195.16,138.91z" />
                                <path d="M194.78,143.18l-0.11-0.37c-0.19-0.62-0.06-1.14,0.4-1.56c0.31-0.29,0.83-0.56,1.55-0.81
				c0.25-0.09,0.98-0.33,2.16-0.7c0.82-0.26,1.65-0.56,2.5-0.9l0.65,0.67c-1.73,0.55-3.37,1.09-4.93,1.61
				c-0.51,0.17-0.88,0.34-1.08,0.51c-0.34,0.28-0.45,0.63-0.32,1.04l0.07,0.24L194.78,143.18z" />
                                <path d="M193.63,145.38l-0.94-0.35l0.28-0.93l0.96,0.33L193.63,145.38z M196.9,144.63
				c-1.02,0.31-1.72-0.13-2.08-1.32l-0.15-0.51l0.89-0.27l0.17,0.55c0.21,0.69,0.5,0.98,0.87,0.86c0.2-0.06,0.4-0.23,0.6-0.52
				l0.2-0.28l0.86,0.41C197.93,144.1,197.48,144.45,196.9,144.63z" />
                                <path d="M197.95,149.24c-0.71,0.21-1.56,0.02-2.55-0.58c-0.7-0.42-1.32-0.93-1.86-1.53l0.28-0.76
				c0.67,0.65,1.34,1.19,2,1.6c0.81,0.51,1.4,0.7,1.79,0.58c0.38-0.12,0.77-0.43,1.18-0.95l0.82,0.44
				C199.13,148.65,198.58,149.04,197.95,149.24z" />
                                <path d="M199.9,154.15c-0.73,0.22-1.31,0.06-1.75-0.48c-0.19-0.23-0.4-0.7-0.65-1.39
				c-0.23-0.64-0.21-1.2,0.05-1.66l0.81,0.19c-0.11,0.28-0.09,0.64,0.04,1.09c0.14,0.48,0.26,0.8,0.34,0.96
				c0.28,0.54,0.56,0.77,0.83,0.69c0.58-0.18,1.07-0.96,1.47-2.34l1.01,0.09c-0.13,0.56-0.36,1.1-0.69,1.62
				C200.94,153.57,200.45,153.98,199.9,154.15z M203.8,150.87l-0.94-0.35l0.29-0.94l0.95,0.34L203.8,150.87z" />
                                <path d="M199.38,157.74l-0.35-0.55l7.21-2.39l0.54,0.7L199.38,157.74z M208.5,156.68c-0.27-0.07-0.51-0.2-0.73-0.4
				c-0.24-0.2-0.39-0.43-0.47-0.68c-0.05-0.15-0.09-0.38-0.13-0.69c-0.04-0.31-0.08-0.54-0.13-0.69c-0.08-0.25-0.25-0.48-0.51-0.67
				l0.33-0.5c0.43,0.21,0.7,0.49,0.8,0.84c0.04,0.15,0.09,0.37,0.13,0.67c0.04,0.3,0.08,0.52,0.13,0.67c0.14,0.45,0.44,0.81,0.9,1.08
				L208.5,156.68z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M274.45,91.42l-0.25-0.3c-0.28-0.33-0.35-0.7-0.21-1.12c-1.83,1.54-3.42,1.51-4.78-0.11
				c-0.51-0.61-0.73-1.24-0.65-1.88c0.08-0.62,0.42-1.2,1.04-1.71c0.58-0.49,1.2-0.77,1.87-0.87l0.23,0.62
				c-0.57,0.12-1.06,0.35-1.47,0.7c-0.96,0.81-1.01,1.71-0.17,2.71c1.01,1.2,2.18,1.22,3.49,0.04l5.16-4.62l0.92,0.39l-4.06,3.42
				c-0.86,0.72-1.04,1.38-0.54,1.96l0.14,0.17L274.45,91.42z" />
                                <path d="M274.95,94.63l-0.88,0.03l-0.06-0.88l-0.8,0.02l-0.08-0.92l0.9-0.01l0.05,0.84l0.77-0.01L274.95,94.63z
				 M276.66,94.04l-0.34-0.41c-0.47-0.56-0.58-1.09-0.34-1.59c-0.25,0.07-0.51,0.05-0.77-0.05c-0.27-0.1-0.48-0.25-0.66-0.46
				l-0.35-0.41l0.71-0.6l0.31,0.37c0.2,0.24,0.42,0.39,0.67,0.46c0.28,0.08,0.53,0.02,0.76-0.17l0.3-0.25l0.54,0.38
				c-0.46,0.39-0.7,0.74-0.72,1.04c-0.02,0.23,0.1,0.5,0.36,0.81l0.25,0.29L276.66,94.04z" />
                                <path d="M276.47,96.52l-1,0.05l-0.11-0.97l1.01-0.07L276.47,96.52z M279.18,94.54c-0.82,0.69-1.63,0.56-2.43-0.39
				l-0.34-0.41l0.71-0.6l0.37,0.44c0.46,0.55,0.84,0.7,1.14,0.45c0.16-0.13,0.28-0.37,0.35-0.71l0.07-0.34l0.95,0.04
				C279.92,93.64,279.65,94.15,279.18,94.54z" />
                                <path d="M282.65,98.5c-0.58,0.49-1.18,0.57-1.8,0.25c-0.26-0.14-0.64-0.48-1.14-1.03
				c-0.46-0.5-0.66-1.02-0.61-1.55l0.82-0.14c0.01,0.3,0.17,0.63,0.47,0.98c0.32,0.38,0.55,0.63,0.7,0.75
				c0.47,0.39,0.81,0.49,1.04,0.3c0.47-0.39,0.61-1.3,0.43-2.73l0.96-0.31c0.1,0.57,0.1,1.15,0,1.76
				C283.38,97.56,283.09,98.13,282.65,98.5z" />
                                <path d="M285.36,102.38c-0.57,0.48-1.42,0.64-2.57,0.48c-0.81-0.11-1.58-0.34-2.31-0.67l-0.04-0.81
				c0.88,0.33,1.7,0.56,2.47,0.68c0.94,0.15,1.57,0.09,1.87-0.17c0.31-0.26,0.54-0.7,0.71-1.34l0.92,0.08
				C286.21,101.37,285.86,101.96,285.36,102.38z" />
                                <path d="M285.84,104.66l-0.54-0.37l5.68-5.05l0.78,0.43L285.84,104.66z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M630.92,488.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C630.62,486.31,630.92,487.13,630.92,488.01z M628.31,484.46l-0.71,0.93l-0.95-0.64l0.7-0.95L628.31,484.46z" />
                                <path d="M634.99,490.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V490.2z" />
                                <path d="M638.98,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M638.2,484.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L638.2,484.87z" />
                                <path d="M647.78,490.2h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V490.2z" />
                                <path d="M654.51,487.15l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C653.15,487.07,653.81,487.17,654.51,487.15z M650.3,492.03l0.57-0.73l0.8,0.59l0.56-0.7l0.79,0.57
				l-0.59,0.74l-0.77-0.58l-0.55,0.68L650.3,492.03z M651.25,493.33l0.52-0.69l0.79,0.58l-0.55,0.68L651.25,493.33z" />
                                <path d="M660.73,490.2h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V490.2z M658.59,489.09
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C658.17,489.2,658.42,489.17,658.59,489.09z" />
                                <path d="M664.1,490.2h-0.46c-0.64,0-1.1-0.33-1.37-0.98c-0.39,0.66-0.91,0.98-1.56,0.98h-0.47v-1.08h0.25
				c0.58,0,0.97-0.18,1.16-0.54c0.15-0.27,0.21-0.72,0.19-1.36l-0.17-5.75l0.96-0.5v5.89c0,1.5,0.39,2.26,1.16,2.26h0.3V490.2z" />
                                <path d="M666.44,488.33c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C666.2,486.99,666.44,487.62,666.44,488.33z M666.16,492.23l-0.71,0.93
				l-0.95-0.63l0.7-0.96L666.16,492.23z" />
                                <path d="M675.38,488.58c0,1.03-0.34,1.97-1.03,2.82c-0.62,0.77-1.44,1.37-2.45,1.8l-0.68-0.76
				c0.98-0.53,1.69-0.99,2.12-1.37c0.67-0.59,1.06-1.25,1.19-1.98c-0.29,0.19-0.64,0.28-1.06,0.28c-0.41,0-0.73-0.1-0.98-0.3
				c-0.27-0.22-0.4-0.53-0.4-0.92c0-0.52,0.14-1.03,0.42-1.51c0.31-0.53,0.68-0.8,1.11-0.8c0.58,0,1.03,0.33,1.36,0.98
				C675.25,487.35,675.38,487.93,675.38,488.58z M674.34,488.11c-0.04-0.76-0.31-1.14-0.81-1.14c-0.17,0-0.32,0.09-0.45,0.27
				c-0.12,0.18-0.19,0.36-0.19,0.54c0,0.38,0.24,0.57,0.71,0.57C673.87,488.35,674.11,488.27,674.34,488.11z" />
                                <path d="M687.46,488.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C687.17,486.31,687.46,487.13,687.46,488.01z M684.85,484.46l-0.71,0.93l-0.95-0.64l0.7-0.95L684.85,484.46z" />
                                <path d="M691.54,490.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V490.2z" />
                                <path d="M695.52,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M694.74,484.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L694.74,484.87z" />
                                <path d="M704.33,490.2h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.32,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V490.2z" />
                                <path d="M708.32,490.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V490.2z M707.56,492.17l-0.63,0.81l-0.83-0.61l-0.59,0.73
				l-0.88-0.62l0.67-0.81l0.79,0.59l0.57-0.7L707.56,492.17z" />
                                <path d="M715.46,488.27c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C715.28,487.09,715.46,487.63,715.46,488.27z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M452.06,206.66c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C451.77,204.96,452.06,205.78,452.06,206.66z M449.45,203.11l-0.71,0.93l-0.95-0.64l0.7-0.95L449.45,203.11z" />
                                <path d="M456.13,208.85h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V208.85z" />
                                <path d="M460.11,208.85h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.63v-1.08h0.56c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V208.85z M458.47,203.68l-0.71,0.93l-0.95-0.64l0.7-0.95
				L458.47,203.68z" />
                                <path d="M466.21,208.85h-0.47c-0.45,0-0.9-0.22-1.34-0.66c-0.14,0.84-0.37,1.25-0.68,1.21
				c-0.78-0.1-1.54-0.46-2.27-1.08c-0.38,0.35-0.79,0.52-1.21,0.52h-0.58v-1.08h0.41c0.69,0,1.17-0.21,1.42-0.62
				c0.38-0.62,0.58-0.96,0.62-1.01c0.32-0.45,0.6-0.68,0.84-0.68c0.22,0,0.49,0.2,0.79,0.61c0.47,0.62,0.76,0.99,0.89,1.11
				c0.42,0.39,0.85,0.59,1.3,0.59h0.27V208.85z M463.34,206.96c-0.18-0.32-0.34-0.48-0.46-0.48c-0.24,0-0.5,0.35-0.77,1.06
				c0.24,0.23,0.54,0.43,0.91,0.6c0.2,0.09,0.36,0.14,0.47,0.14c0.15,0,0.23-0.09,0.23-0.26
				C463.72,207.76,463.59,207.4,463.34,206.96z" />
                                <path d="M473.34,206.92c0,0.52-0.14,0.97-0.41,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C473.16,205.74,473.34,206.28,473.34,206.92z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M506.97,483.5c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C506.68,481.81,506.97,482.62,506.97,483.5z M504.36,479.95l-0.71,0.93l-0.95-0.64l0.7-0.95L504.36,479.95z" />
                                <path d="M511.04,485.69h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V485.69z" />
                                <path d="M516.27,477.14l-0.15,1.14c-0.84,0.32-1.73,0.71-2.66,1.17c-0.86,0.42-1.45,0.75-1.77,0.98
				c0.55,0.45,0.95,0.82,1.19,1.11c0.53,0.64,0.8,1.27,0.8,1.9c0,1.5-0.92,2.26-2.75,2.26h-0.49v-1.08h0.84
				c1.05,0,1.58-0.34,1.58-1.01c0-0.57-0.7-1.44-2.09-2.61c0.03-0.6,0.11-0.95,0.25-1.04C512.5,478.89,514.25,477.96,516.27,477.14z
				 M516.21,475.62l-0.06,0.75c-0.65,0.26-1.5,0.67-2.55,1.24l-2.59,1.39l0.08-0.64C513.14,477.19,514.85,476.28,516.21,475.62z" />
                                <path d="M523.09,485.69h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V485.69z M520.94,481.01
				l-0.71,0.93l-0.95-0.63l0.69-0.96L520.94,481.01z" />
                                <path d="M527.85,484.12c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C527.75,483.07,527.85,483.6,527.85,484.12z M526.97,483.89c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C526.9,484.3,526.97,484.16,526.97,483.89z" />
                                <path d="M534.82,485.69h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V485.69z" />
                                <path d="M540.14,484.51c0,1.06-0.33,1.59-0.98,1.59c-0.17,0-0.82-0.27-1.96-0.82c-0.49,0.27-1.08,0.41-1.8,0.41
				h-1.02v-1.08h1.65c-0.57-0.24-0.86-0.64-0.86-1.18c0-0.72,0.51-1.37,1.54-1.95l-0.39-0.28l0.44-1.03
				C539.01,481.82,540.14,483.27,540.14,484.51z M537.61,483.17c0-0.21-0.05-0.41-0.15-0.59c-0.12-0.22-0.28-0.33-0.47-0.33
				c-0.21,0-0.43,0.11-0.64,0.32c-0.21,0.21-0.32,0.43-0.32,0.64c0,0.19,0.13,0.39,0.39,0.58c0.23,0.17,0.43,0.25,0.6,0.25
				c0.17,0,0.32-0.11,0.44-0.32C537.56,483.54,537.61,483.36,537.61,483.17z M539.34,484.48c0-0.29-0.34-0.81-1.03-1.56
				c0.01,0.1,0.02,0.2,0.02,0.3c0,0.49-0.18,0.89-0.54,1.22c0.11,0.07,0.32,0.18,0.62,0.31c0.33,0.16,0.54,0.23,0.6,0.23
				C539.24,484.98,539.34,484.81,539.34,484.48z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M461.04,326.83c0,0.89-0.38,1.48-1.13,1.79c-0.32,0.13-0.91,0.21-1.78,0.25c-0.8,0.03-1.41-0.17-1.84-0.62
				l0.49-0.84c0.28,0.21,0.69,0.32,1.23,0.32c0.58,0,0.98-0.02,1.19-0.06c0.7-0.13,1.05-0.36,1.05-0.7c0-0.71-0.7-1.52-2.11-2.43
				l0.44-1.09c0.58,0.33,1.11,0.78,1.57,1.32C460.75,325.47,461.04,326.15,461.04,326.83z" />
                                <path d="M468.01,328.82h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V328.82z M465.86,324.14
				l-0.71,0.93l-0.95-0.63l0.69-0.95L465.86,324.14z" />
                                <path d="M470.36,326.95c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C470.12,325.61,470.36,326.24,470.36,326.95z M471.1,330.79l-0.63,0.81
				l-0.83-0.61l-0.59,0.73l-0.88-0.62l0.67-0.81l0.79,0.59l0.57-0.7L471.1,330.79z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M525.08,122.92c0,1.05-0.32,1.89-0.95,2.52c-0.63,0.63-1.48,0.94-2.53,0.94c-0.92,0-1.65-0.31-2.19-0.93
				c-0.48-0.55-0.72-1.21-0.72-1.97c0-0.67,0.2-1.3,0.6-1.9l0.66,0.24c-0.27,0.54-0.4,1.02-0.4,1.44c0,1.41,0.73,2.11,2.19,2.11
				c0.74,0,1.33-0.19,1.78-0.58c0.46-0.41,0.7-0.98,0.7-1.71c0-0.66-0.23-1.28-0.68-1.86l0.72-0.62
				C524.81,121.33,525.08,122.1,525.08,122.92z M522.63,119.59l-0.67,0.88l-0.89-0.6l0.65-0.89L522.63,119.59z" />
                                <path d="M528.91,124.98h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V124.98z" />
                                <path d="M535.62,123.17c0,0.49-0.13,0.91-0.39,1.24c-0.28,0.37-0.66,0.55-1.14,0.55c-0.63,0-1.07-0.23-1.32-0.7
				c-0.34,0.46-0.79,0.7-1.37,0.7c-0.62,0-1.02-0.23-1.19-0.7c-0.26,0.47-0.69,0.7-1.29,0.7h-0.44v-1.02h0.25
				c0.76,0,1.14-0.37,1.14-1.11v-0.16l0.67-0.24v0.18c0,0.89,0.29,1.33,0.88,1.33c0.68,0,1.02-0.37,1.02-1.12v-0.16l0.67-0.24v0.18
				c0,0.89,0.34,1.34,1.02,1.34c0.49,0,0.73-0.22,0.73-0.66c0-0.31-0.14-0.61-0.42-0.91l0.66-0.75
				C535.44,122.06,535.62,122.57,535.62,123.17z" />
                                <path d="M537.85,124.79l-0.69,0.19l-0.22-8.33l0.91-0.35V124.79z" />
                                <path d="M544.39,124.98h-0.42c-0.35,0-0.64-0.06-0.88-0.18c-0.1,0.85-0.63,1.68-1.58,2.49
				c-0.64,0.55-1.37,1.01-2.19,1.4l-0.64-0.53c0.92-0.53,1.7-1.07,2.35-1.61c0.82-0.69,1.23-1.26,1.23-1.7
				c0-0.33-0.21-0.78-0.62-1.35l0.68-0.79c0.34,0.49,0.55,0.76,0.62,0.83c0.28,0.28,0.62,0.43,1.01,0.43h0.43V124.98z" />
                                <path d="M550.71,122.12l-0.23,0.98c-0.81,0-1.49,0.17-2.05,0.5c-0.27,0.17-0.77,0.47-1.49,0.9
				c-0.56,0.32-1.3,0.49-2.19,0.49h-0.77v-1.02h0.81c0.62,0,1.13-0.07,1.55-0.21c0.27-0.09,0.64-0.26,1.11-0.52
				c0.49-0.28,0.86-0.46,1.09-0.55c-0.26-0.06-0.66-0.22-1.2-0.47c-0.5-0.23-0.82-0.34-0.96-0.34c-0.23,0-0.54,0.19-0.92,0.57
				l-0.58-0.33c0.16-0.27,0.37-0.53,0.63-0.78c0.31-0.29,0.57-0.44,0.79-0.44c0.32,0,0.72,0.11,1.2,0.34
				c0.77,0.36,1.22,0.56,1.35,0.61C549.43,122.04,550.05,122.14,550.71,122.12z M548.49,118.96l-0.67,0.88l-0.89-0.6l0.66-0.9
				L548.49,118.96z" />
                                <path d="M529.23,141.78h-1.57c-0.67,0-1.01,0.08-1.01,0.23c0,0.09,0.26,0.2,0.79,0.31
				c0.62,0.13,0.97,0.21,1.03,0.25c0.33,0.17,0.5,0.45,0.5,0.85c0,0.62-0.5,1.15-1.49,1.58c-0.82,0.36-1.58,0.54-2.29,0.54
				c-0.96,0-1.7-0.22-2.24-0.67c-0.57-0.48-0.85-1.19-0.85-2.13c0-0.68,0.2-1.39,0.59-2.13l0.75,0.25c-0.29,0.6-0.44,1.15-0.44,1.65
				c0,1.33,0.77,2,2.3,2c1.19,0,2.14-0.27,2.86-0.81c0.07-0.05,0.1-0.1,0.1-0.15c0-0.07-0.05-0.11-0.15-0.12
				c-0.9-0.14-1.51-0.28-1.82-0.42c-0.11-0.05-0.19-0.15-0.27-0.3c-0.07-0.15-0.11-0.29-0.11-0.42c0-1.01,0.89-1.51,2.67-1.51h0.65
				V141.78z" />
                                <path d="M531.02,138.82c0,0.93-0.09,1.6-0.27,2.02c-0.27,0.63-0.77,0.94-1.51,0.94h-0.44v-1.02h0.45
				c0.45,0,0.75-0.18,0.9-0.53c0.09-0.21,0.13-0.59,0.13-1.14c0-0.17,0-0.33-0.01-0.48l-0.16-5.05l0.9-0.46V138.82z" />
                                <path d="M534.84,141.78h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V141.78z" />
                                <path d="M540.55,141.78h-0.44c-0.42,0-0.84-0.21-1.26-0.62c-0.13,0.79-0.35,1.17-0.64,1.13
				c-0.73-0.09-1.44-0.43-2.13-1.01c-0.36,0.33-0.74,0.49-1.13,0.49h-0.55v-1.02h0.39c0.65,0,1.1-0.19,1.33-0.58
				c0.36-0.58,0.55-0.9,0.58-0.95c0.3-0.42,0.56-0.64,0.79-0.64c0.21,0,0.46,0.19,0.75,0.57c0.44,0.58,0.72,0.93,0.84,1.04
				c0.39,0.37,0.8,0.56,1.22,0.56h0.25V141.78z M537.86,140.01c-0.17-0.3-0.32-0.45-0.43-0.45c-0.22,0-0.46,0.33-0.72,1
				c0.22,0.22,0.51,0.41,0.85,0.57c0.19,0.09,0.34,0.13,0.44,0.13c0.15,0,0.22-0.08,0.22-0.25
				C538.21,140.75,538.1,140.42,537.86,140.01z" />
                                <path d="M547.26,139.97c0,0.49-0.13,0.91-0.39,1.24c-0.28,0.37-0.66,0.55-1.14,0.55c-0.63,0-1.07-0.23-1.32-0.7
				c-0.34,0.46-0.79,0.7-1.37,0.7c-0.62,0-1.02-0.23-1.19-0.7c-0.26,0.47-0.69,0.7-1.29,0.7h-0.44v-1.02h0.25
				c0.76,0,1.14-0.37,1.14-1.11v-0.16l0.67-0.24v0.18c0,0.89,0.29,1.33,0.88,1.33c0.68,0,1.02-0.37,1.02-1.12v-0.16l0.67-0.24v0.18
				c0,0.89,0.34,1.34,1.02,1.34c0.49,0,0.73-0.22,0.73-0.66c0-0.31-0.14-0.61-0.42-0.91l0.66-0.75
				C547.09,138.86,547.26,139.37,547.26,139.97z M545.78,136.34l-0.53,0.69l-0.76-0.56l-0.53,0.66l-0.74-0.53l0.56-0.69l0.72,0.54
				l0.51-0.64L545.78,136.34z M544.89,135.13l-0.49,0.65l-0.75-0.55l0.51-0.64L544.89,135.13z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M382.62,279.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C382.32,277.32,382.62,278.13,382.62,279.01z M380.01,275.46l-0.71,0.93l-0.95-0.64l0.7-0.95L380.01,275.46z" />
                                <path d="M386.69,281.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V281.2z" />
                                <path d="M392.45,281.2h-0.49c-0.45,0-0.85,0.08-1.19,0.25c-0.43,0.21-0.65,0.52-0.65,0.93
				c0,0.41,0.23,0.74,0.69,0.97l-0.32,0.99c-1.59-0.5-2.59-1.55-2.98-3.14h-1.27v-1.08h1.16c0-0.86,0.21-1.69,0.63-2.5
				c0.37-0.71,0.7-1.07,0.98-1.07c0.22,0,0.49,0.24,0.79,0.72c0.33,0.51,0.49,1.03,0.49,1.54c0,0.59-0.16,1.11-0.47,1.58
				c-0.36,0.53-0.82,0.79-1.38,0.79c0.15,0.56,0.49,1.03,1.04,1.42c-0.03-0.11-0.04-0.23-0.04-0.35c0-0.59,0.23-1.09,0.69-1.52
				c0.45-0.41,0.96-0.62,1.56-0.62h0.76V281.2z M389.53,279.07c0-0.33-0.08-0.63-0.24-0.88c-0.13-0.21-0.25-0.31-0.35-0.31
				c-0.1,0-0.24,0.19-0.4,0.58c-0.2,0.48-0.31,1-0.31,1.57c0.36,0.03,0.66-0.03,0.9-0.18C389.4,279.68,389.53,279.42,389.53,279.07z" />
                                <path d="M396.63,281.2h-0.37c-0.85,0-1.54-0.22-2.07-0.66c-0.68,0.44-1.31,0.66-1.89,0.66h-0.31v-1.08h0.43
				c0.38,0,0.7-0.09,0.97-0.27c-0.3-0.3-0.44-0.73-0.44-1.28c0-0.42,0.2-0.85,0.59-1.29c0.39-0.44,0.8-0.67,1.21-0.67
				c0.36,0,0.67,0.2,0.92,0.6c0.22,0.35,0.33,0.71,0.33,1.1c0,0.69-0.29,1.23-0.87,1.63c0.29,0.13,0.68,0.19,1.16,0.19h0.34V281.2z
				 M395.29,274.43l-0.72,0.94l-0.94-0.64l0.7-0.95L395.29,274.43z M395.2,278.59c0-0.18-0.06-0.37-0.18-0.57
				c-0.13-0.22-0.28-0.33-0.45-0.33c-0.18,0-0.37,0.09-0.57,0.28c-0.2,0.19-0.3,0.37-0.3,0.54c0,0.17,0.07,0.35,0.21,0.55
				c0.15,0.22,0.3,0.33,0.45,0.33c0.14,0,0.32-0.1,0.53-0.3C395.1,278.9,395.2,278.73,395.2,278.59z" />
                                <path d="M405.58,278.47c0,0.96-0.43,1.68-1.3,2.16c-0.7,0.38-1.57,0.58-2.61,0.58h-1.96c-0.46,0-0.8-0.03-1.02-0.1
				c-0.32-0.1-0.58-0.31-0.77-0.62c-0.32,0.49-0.74,0.73-1.27,0.73h-0.47v-1.08h0.33c0.71,0,1.06-0.38,1.06-1.13v-0.28l0.82-0.29
				v0.18c0,1.02,0.29,1.53,0.88,1.53c0.32,0,0.57-0.12,0.76-0.36c0.12-0.15,0.33-0.42,0.64-0.81c0.35-0.43,0.8-0.84,1.34-1.23
				c0.72-0.52,1.37-0.78,1.96-0.78c0.43,0,0.81,0.15,1.13,0.44C405.42,277.68,405.58,278.04,405.58,278.47z M404.66,278.83
				c0-0.27-0.12-0.48-0.37-0.64c-0.2-0.13-0.45-0.19-0.74-0.19c-0.67,0-1.66,0.7-2.96,2.11h1.17c1,0,1.77-0.15,2.29-0.46
				C404.45,279.42,404.66,279.15,404.66,278.83z" />
                                <path d="M407.97,281l-0.73,0.2l-0.23-8.86l0.97-0.37V281z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M421.5,434.9c0,0.54-0.13,0.98-0.38,1.34c-0.29,0.41-0.69,0.61-1.2,0.61c-0.63,0-1.09-0.25-1.36-0.75
				c-0.29,0.5-0.74,0.75-1.35,0.75c-0.44,0-0.77-0.12-1.01-0.37c0,0.11,0,0.22,0,0.33c0,1.13-0.35,2.04-1.07,2.71
				c-0.71,0.67-1.64,1.01-2.78,1.01c-0.96,0-1.72-0.28-2.3-0.84c-0.58-0.56-0.87-1.32-0.87-2.27c0-0.76,0.22-1.51,0.66-2.25
				l0.72,0.27c-0.13,0.2-0.24,0.48-0.35,0.85c-0.1,0.37-0.16,0.67-0.16,0.91c0,1.51,0.82,2.26,2.47,2.26c0.77,0,1.42-0.19,1.95-0.57
				c0.6-0.43,0.9-1.01,0.9-1.75c0-0.74-0.23-1.47-0.7-2.21l0.85-0.73c0.25,0.51,0.46,0.86,0.63,1.06c0.28,0.34,0.61,0.5,0.98,0.5
				c0.41,0,0.69-0.1,0.85-0.3c0.14-0.17,0.21-0.47,0.21-0.89v-0.18l0.71-0.26v0.12c0,1,0.35,1.51,1.05,1.51
				c0.48,0,0.73-0.25,0.73-0.75c0-0.2-0.14-0.51-0.43-0.92l0.7-0.8C421.32,433.76,421.5,434.29,421.5,434.9z" />
                                <path d="M427,435.37c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C426.75,433.85,427,434.6,427,435.37z" />
                                <path d="M431.08,436.86h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V436.86z" />
                                <path d="M434.49,434.32c0,1.7-0.87,2.54-2.61,2.54h-1.26v-1.08h1.14c0.29,0,0.64-0.06,1.07-0.18
				c0.55-0.15,0.82-0.33,0.82-0.55v-0.48c-0.32,0.19-0.67,0.28-1.08,0.28c-0.35,0-0.63-0.1-0.84-0.31c-0.21-0.2-0.31-0.48-0.31-0.83
				c0-0.41,0.13-0.88,0.38-1.4c0.32-0.66,0.69-1,1.14-1c0.48,0,0.88,0.4,1.19,1.2C434.37,433.15,434.49,433.75,434.49,434.32z
				 M433.54,429.4l-0.71,0.93l-0.95-0.63l0.69-0.96L433.54,429.4z M433.47,433.63c-0.15-0.82-0.38-1.23-0.71-1.23
				c-0.15,0-0.29,0.12-0.43,0.36c-0.13,0.21-0.2,0.4-0.2,0.56c0,0.37,0.19,0.56,0.58,0.56C433.03,433.88,433.28,433.8,433.47,433.63z
				" />
                            </g>
                            <g class="map-province-names">
                                <path d="M277.1,336.58c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C276.81,334.88,277.1,335.7,277.1,336.58z M274.49,333.03l-0.71,0.93l-0.95-0.64l0.7-0.95L274.49,333.03z" />
                                <path d="M281.18,338.77h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V338.77z" />
                                <path d="M285.17,338.77h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V338.77z M284.38,333.44l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L284.38,333.44z" />
                                <path d="M292.3,336.84c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C292.12,335.66,292.3,336.2,292.3,336.84z" />
                                <path d="M297.79,337.29c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C297.53,335.76,297.79,336.52,297.79,337.29z M296.98,332.96l-0.72,0.94l-0.95-0.64l0.69-0.96L296.98,332.96z" />
                                <path d="M304.03,338.77h-1.18c-0.32,1.76-1.46,3.06-3.43,3.91l-0.68-0.76c0.97-0.53,1.67-0.98,2.1-1.33
				c0.65-0.55,1.04-1.14,1.16-1.78c-0.24,0.04-0.49,0.07-0.75,0.07c-1.09,0-1.63-0.39-1.63-1.16c0-0.47,0.14-0.97,0.41-1.48
				c0.32-0.6,0.69-0.9,1.12-0.9c0.55,0,0.98,0.27,1.29,0.81c0.24,0.41,0.39,0.93,0.45,1.55h1.14V338.77z M301.89,337.67
				c-0.02-0.28-0.09-0.54-0.21-0.78c-0.15-0.3-0.35-0.44-0.6-0.44c-0.17,0-0.33,0.1-0.47,0.3c-0.12,0.18-0.18,0.36-0.18,0.55
				c0,0.29,0.24,0.44,0.71,0.47C301.48,337.77,301.73,337.74,301.89,337.67z" />
                                <path d="M310.74,335.72l-0.25,1.04c-0.86,0-1.59,0.18-2.18,0.53c-0.29,0.18-0.82,0.5-1.59,0.96
				c-0.6,0.34-1.38,0.52-2.34,0.52h-0.82v-1.08h0.87c0.66,0,1.21-0.07,1.65-0.22c0.29-0.09,0.68-0.28,1.18-0.56
				c0.52-0.3,0.91-0.49,1.16-0.58c-0.28-0.07-0.7-0.24-1.28-0.5c-0.53-0.24-0.87-0.37-1.03-0.37c-0.25,0-0.57,0.2-0.98,0.6
				l-0.62-0.36c0.17-0.29,0.39-0.57,0.67-0.83c0.33-0.31,0.61-0.47,0.84-0.47c0.34,0,0.76,0.12,1.27,0.36
				c0.82,0.38,1.3,0.6,1.44,0.65C309.38,335.64,310.04,335.74,310.74,335.72z M308.38,332.36l-0.71,0.93l-0.95-0.64l0.7-0.96
				L308.38,332.36z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M364.4,199.39c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C364.11,197.69,364.4,198.51,364.4,199.39z M361.79,195.84l-0.71,0.93l-0.95-0.64l0.7-0.95L361.79,195.84z" />
                                <path d="M366.8,201.37l-0.73,0.2l-0.23-8.86l0.97-0.37V201.37z" />
                                <path d="M373.76,201.58h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V201.58z" />
                                <path d="M379.52,201.58h-0.49c-0.45,0-0.85,0.09-1.19,0.25c-0.43,0.21-0.65,0.52-0.65,0.93
				c0,0.41,0.23,0.74,0.69,0.97l-0.32,0.99c-1.59-0.5-2.59-1.55-2.98-3.14h-1.27v-1.08h1.16c0-0.86,0.21-1.69,0.63-2.5
				c0.37-0.71,0.7-1.07,0.98-1.07c0.22,0,0.49,0.24,0.79,0.72c0.33,0.51,0.49,1.03,0.49,1.54c0,0.59-0.16,1.11-0.47,1.58
				c-0.36,0.53-0.82,0.79-1.38,0.79c0.15,0.56,0.49,1.03,1.04,1.42c-0.03-0.11-0.04-0.23-0.04-0.35c0-0.58,0.23-1.09,0.69-1.52
				c0.45-0.41,0.96-0.62,1.56-0.62h0.76V201.58z M376.61,199.45c0-0.34-0.08-0.63-0.24-0.88c-0.13-0.21-0.25-0.31-0.35-0.31
				c-0.1,0-0.24,0.19-0.4,0.58c-0.2,0.48-0.31,1-0.31,1.57c0.36,0.03,0.66-0.03,0.9-0.18C376.47,200.05,376.61,199.8,376.61,199.45z" />
                                <path d="M381.87,199.7c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C381.63,198.37,381.87,199,381.87,199.7z M382.37,195.8l-0.64,0.81l-0.82-0.61
				l-0.59,0.73l-0.88-0.62l0.66-0.82l0.79,0.59l0.57-0.7L382.37,195.8z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M360.3,228.23h-0.47c-0.55,0-1-0.11-1.35-0.32c0.09,0.2,0.14,0.44,0.14,0.73c0,0.36-0.07,0.68-0.21,0.98
				c-0.18,0.37-0.43,0.55-0.75,0.55c-1.1,0-1.64-0.78-1.64-2.34c0-0.17,0.01-0.33,0.03-0.48c-0.54,0-0.91,0.18-1.1,0.53
				c-0.14,0.25-0.2,0.68-0.2,1.27v5.36h-0.79l-0.09-5.99c-0.01-0.6,0.16-1.12,0.51-1.56c0.41-0.51,0.97-0.76,1.7-0.76l0.09-0.67
				l1.84,1.07c0.62,0.36,1.26,0.54,1.94,0.54h0.37V228.23z M357.73,227.98c-0.1-0.15-0.19-0.26-0.26-0.33
				c-0.16-0.15-0.42-0.32-0.77-0.5c-0.03,1.26,0.21,1.88,0.74,1.88c0.29,0,0.44-0.18,0.44-0.55
				C357.88,228.3,357.83,228.14,357.73,227.98z" />
                                <path d="M363.71,225.69c0,1.7-0.87,2.54-2.61,2.54h-1.26v-1.08h1.14c0.29,0,0.64-0.06,1.07-0.18
				c0.55-0.15,0.82-0.33,0.82-0.55v-0.48c-0.32,0.19-0.67,0.28-1.08,0.28c-0.35,0-0.63-0.1-0.84-0.31c-0.21-0.2-0.31-0.48-0.31-0.83
				c0-0.41,0.13-0.88,0.38-1.4c0.32-0.66,0.69-1,1.14-1c0.48,0,0.88,0.4,1.19,1.2C363.59,224.52,363.71,225.12,363.71,225.69z
				 M363.31,220.73l-0.63,0.81l-0.82-0.61l-0.59,0.73l-0.88-0.62l0.66-0.82l0.8,0.6l0.57-0.7L363.31,220.73z M362.68,225.01
				c-0.15-0.82-0.38-1.23-0.71-1.23c-0.15,0-0.29,0.12-0.43,0.36c-0.13,0.21-0.2,0.4-0.2,0.56c0,0.37,0.19,0.56,0.58,0.56
				C362.24,225.26,362.49,225.17,362.68,225.01z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M208.22,232.94c0,0.52-0.15,0.96-0.44,1.29c-0.31,0.36-0.72,0.54-1.24,0.54c-0.42,0-0.75-0.14-1-0.42
				c-0.25-0.28-0.38-0.63-0.38-1.05c0-0.37,0.06-0.71,0.19-1.03c0.06-0.15,0.25-0.51,0.58-1.08l-0.17-0.14l0.52-0.98
				C207.57,231.09,208.22,232.05,208.22,232.94z M207.44,232.95c0-0.25-0.13-0.53-0.39-0.84c-0.2-0.24-0.41-0.43-0.65-0.59
				c-0.37,0.7-0.55,1.15-0.55,1.35c0,0.56,0.25,0.84,0.76,0.84c0.22,0,0.42-0.07,0.58-0.21
				C207.36,233.34,207.44,233.16,207.44,232.95z" />
                                <path d="M212.29,234.62h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V234.62z" />
                                <path d="M221.09,234.62h-0.46c-0.72,0-1.19-0.25-1.4-0.75c-0.34,0.5-0.84,0.75-1.51,0.75c-0.59,0-1-0.25-1.24-0.75
				c-0.36,0.5-0.88,0.75-1.54,0.75c-0.62,0-1.05-0.25-1.27-0.75c-0.29,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.27
				c0.81,0,1.21-0.4,1.21-1.19v-0.18l0.71-0.26v0.19c0,0.96,0.31,1.43,0.94,1.43c0.43,0,0.73-0.09,0.91-0.27
				c0.18-0.18,0.27-0.49,0.27-0.92v-0.18l0.71-0.26v0.19c0,0.96,0.32,1.43,0.95,1.43c0.73,0,1.1-0.4,1.1-1.19v-0.18l0.71-0.29v0.22
				c0,0.47,0.06,0.81,0.17,1.02c0.16,0.28,0.45,0.42,0.89,0.42h0.44V234.62z M217.92,228.83l-0.56,0.73l-0.81-0.59l-0.56,0.69
				l-0.79-0.57l0.59-0.74l0.77,0.58l0.54-0.68L217.92,228.83z M216.97,227.54l-0.52,0.69l-0.79-0.58l0.54-0.69L216.97,227.54z" />
                                <path d="M223.43,232.75c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C223.18,231.41,223.43,232.04,223.43,232.75z M222.98,228.61l-0.71,0.94
				l-0.94-0.64l0.7-0.95L222.98,228.61z" />
                                <path d="M227.5,234.62h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V234.62z" />
                                <path d="M232.26,233.05c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C232.15,232,232.26,232.53,232.26,233.05z M231.37,232.81c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C231.31,233.22,231.37,233.09,231.37,232.81z" />
                                <path d="M239.22,234.62h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V234.62z" />
                                <path d="M244.64,225.67l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C240.55,227.61,242.39,226.63,244.64,225.67z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M230.04,189.01c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C229.74,187.31,230.04,188.13,230.04,189.01z M227.42,185.46l-0.71,0.93l-0.95-0.64l0.7-0.95L227.42,185.46z" />
                                <path d="M234.11,191.2h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V191.2z" />
                                <path d="M238.1,191.2h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V191.2z M237.32,185.87l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L237.32,185.87z" />
                                <path d="M245.24,189.27c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C245.05,188.09,245.24,188.63,245.24,189.27z" />
                                <path d="M251.36,189.21c0,0.89-0.38,1.48-1.13,1.79c-0.32,0.13-0.91,0.21-1.78,0.25c-0.8,0.03-1.41-0.17-1.84-0.62
				l0.49-0.84c0.28,0.21,0.69,0.32,1.23,0.32c0.58,0,0.98-0.02,1.19-0.06c0.7-0.13,1.05-0.36,1.05-0.7c0-0.71-0.7-1.52-2.11-2.43
				l0.44-1.09c0.58,0.33,1.11,0.78,1.57,1.32C251.07,187.85,251.36,188.53,251.36,189.21z" />
                                <path d="M258.33,191.2h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V191.2z" />
                                <path d="M263.75,182.25l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C259.66,184.19,261.5,183.21,263.75,182.25z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M275.52,155.84c0,1.05-0.32,1.89-0.95,2.52c-0.63,0.63-1.48,0.94-2.53,0.94c-0.92,0-1.65-0.31-2.19-0.93
				c-0.48-0.55-0.72-1.21-0.72-1.97c0-0.67,0.2-1.3,0.6-1.9l0.66,0.24c-0.27,0.54-0.4,1.02-0.4,1.44c0,1.41,0.73,2.11,2.19,2.11
				c0.74,0,1.33-0.19,1.78-0.58c0.46-0.41,0.7-0.98,0.7-1.71c0-0.66-0.23-1.28-0.68-1.86l0.72-0.62
				C275.25,154.24,275.52,155.01,275.52,155.84z M273.07,152.5l-0.67,0.88l-0.89-0.6l0.65-0.89L273.07,152.5z" />
                                <path d="M279.35,157.89h-0.42c-0.71,0-1.21-0.31-1.51-0.92c-0.2-0.42-0.32-1.04-0.36-1.89
				c-0.01-0.3-0.03-1.13-0.05-2.49c-0.01-0.94-0.06-1.91-0.15-2.92l0.91-0.46c0.03,1.99,0.07,3.88,0.12,5.69
				c0.01,0.59,0.08,1.03,0.19,1.3c0.18,0.45,0.51,0.67,0.99,0.67h0.28V157.89z" />
                                <path d="M286.86,157.89h-1.08c-0.62,0-1.06-0.21-1.33-0.62c-0.08-0.12-0.2-0.46-0.36-1.01l-2.08,1.08
				c-0.71,0.37-1.46,0.55-2.26,0.55h-0.83v-1.01h0.81c0.8,0,1.49-0.13,2.09-0.41c0.35-0.16,0.97-0.46,1.87-0.88
				c-0.39-0.08-0.88-0.25-1.45-0.52c-0.53-0.24-0.86-0.36-0.98-0.36c-0.27,0-0.54,0.18-0.81,0.55l-0.62-0.33
				c0.46-0.85,0.9-1.27,1.35-1.27c0.31,0,0.7,0.11,1.18,0.32c0.74,0.33,1.21,0.53,1.39,0.6c0.63,0.21,1.27,0.32,1.93,0.32
				c0.14,0,0.27,0,0.41,0l-0.23,0.96c-0.54,0-0.97,0.08-1.28,0.23c0.09,0.33,0.27,0.55,0.56,0.67c0.2,0.08,0.49,0.12,0.9,0.12h0.83
				V157.89z M283.87,159.44l-0.67,0.88l-0.89-0.59l0.66-0.9L283.87,159.44z" />
                                <path d="M289.07,156.13c0,1.17-0.68,1.76-2.04,1.76h-0.58v-1.02h0.64c0.79,0,1.18-0.21,1.18-0.64
				c0-0.23-0.12-0.49-0.35-0.79l-0.23-0.3l0.7-0.77C288.84,154.88,289.07,155.47,289.07,156.13z M288.64,152.25l-0.67,0.88
				l-0.89-0.61l0.65-0.89L288.64,152.25z" />
                                <path d="M294.23,156.5c0,0.81-0.47,1.64-1.42,2.49c-0.67,0.6-1.4,1.09-2.19,1.46l-0.71-0.54
				c0.9-0.5,1.67-1.03,2.32-1.59c0.79-0.68,1.18-1.25,1.18-1.69c0-0.44-0.21-0.95-0.62-1.54l0.72-0.72
				C293.99,155.07,294.23,155.77,294.23,156.5z M293.47,152.43l-0.68,0.88l-0.89-0.6l0.65-0.9L293.47,152.43z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M314.57,139.66c-0.54,0.79-1.21,1.26-2.01,1.41c-0.8,0.15-1.6-0.05-2.39-0.59
				c-0.69-0.47-1.08-1.08-1.18-1.83c-0.08-0.67,0.07-1.28,0.46-1.86c0.34-0.5,0.82-0.88,1.43-1.12l0.38,0.52
				c-0.48,0.27-0.83,0.56-1.04,0.88c-0.72,1.06-0.54,1.97,0.56,2.72c0.56,0.38,1.1,0.54,1.64,0.48c0.56-0.07,1.03-0.38,1.4-0.93
				c0.34-0.5,0.49-1.08,0.45-1.75l0.86-0.09C315.18,138.32,315,139.04,314.57,139.66z M314.44,135.89l-0.95,0.32l-0.36-0.91
				l0.95-0.34L314.44,135.89z" />
                                <path d="M320.27,145.82l-0.34-0.23c-0.47-0.32-0.67-0.82-0.62-1.51c0.04-0.52,0.22-1.07,0.52-1.65
				c-1.26,1.11-2.81,1.22-4.66,0.33l0.06-0.74c0.62,0.25,1.26,0.41,1.91,0.47c0.71,0.07,1.2-0.01,1.47-0.23
				c0.03-0.03,0.07-0.06,0.09-0.1c0.31-0.45,0.27-1.36-0.1-2.72c-0.3-1.08-0.65-1.98-1.05-2.69l0.75-0.77
				c0.5,1.06,0.86,2.14,1.08,3.23c0.25,1.23,0.25,2.17,0,2.81c0.56-0.47,1.18-1.21,1.86-2.21c0.4-0.59,0.77-1.18,1.1-1.77l0.86,0.21
				l-1.86,2.73c-0.62,0.91-1.03,1.7-1.21,2.34c-0.2,0.72-0.06,1.24,0.41,1.56l0.25,0.17L320.27,145.82z" />
                                <path d="M321.61,148.78l-0.84,0.27l-0.29-0.83l-0.77,0.23l-0.32-0.87l0.87-0.25l0.28,0.8l0.74-0.22L321.61,148.78z
				 M323.09,147.75l-0.44-0.3c-0.6-0.41-0.85-0.89-0.75-1.44c-0.23,0.13-0.48,0.18-0.76,0.16c-0.28-0.03-0.53-0.11-0.75-0.26
				l-0.44-0.3l0.52-0.77l0.4,0.27c0.26,0.18,0.51,0.26,0.77,0.26c0.29,0,0.52-0.12,0.69-0.37l0.22-0.33l0.62,0.22
				c-0.34,0.5-0.48,0.9-0.42,1.19c0.04,0.23,0.23,0.45,0.56,0.68l0.31,0.21L323.09,147.75z" />
                                <path d="M330.93,144.21l-0.65,0.74c-0.75-0.18-1.57-0.33-2.45-0.46c-0.82-0.12-1.39-0.17-1.72-0.16
				c0.17,0.58,0.27,1.04,0.31,1.37c0.07,0.71-0.05,1.29-0.35,1.73c-0.73,1.07-1.74,1.16-3.04,0.27l-0.34-0.24l0.52-0.77l0.59,0.4
				c0.75,0.51,1.28,0.52,1.61,0.04c0.28-0.41,0.21-1.36-0.22-2.86c0.31-0.41,0.54-0.62,0.68-0.62
				C327.42,143.63,329.11,143.82,330.93,144.21z M331.62,143.11l-0.4,0.5c-0.58-0.13-1.38-0.25-2.41-0.36l-2.5-0.27l0.37-0.42
				C328.69,142.74,330.34,142.92,331.62,143.11z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M265.85,268.88c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C265.56,267.18,265.85,268,265.85,268.88z M263.24,265.33l-0.71,0.93l-0.95-0.64l0.7-0.95L263.24,265.33z" />
                                <path d="M269.93,271.07h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V271.07z" />
                                <path d="M273.91,271.07h-0.62c-0.85,0-1.41-0.3-1.67-0.89c-0.13,0.27-0.34,0.49-0.63,0.65
				c-0.29,0.16-0.59,0.24-0.9,0.24h-0.62v-1.08h0.55c0.36,0,0.67-0.08,0.91-0.25c0.28-0.19,0.42-0.46,0.42-0.8v-0.46l0.74-0.2
				c0,0.71,0.13,1.18,0.38,1.42c0.19,0.19,0.52,0.29,0.99,0.29h0.44V271.07z M273.13,265.74l-0.64,0.81l-0.82-0.61l-0.59,0.72
				l-0.88-0.63l0.67-0.81l0.79,0.59l0.58-0.7L273.13,265.74z" />
                                <path d="M281.05,269.14c0,0.52-0.14,0.97-0.42,1.33c-0.3,0.39-0.71,0.59-1.21,0.59c-0.67,0-1.14-0.25-1.4-0.74
				c-0.36,0.5-0.84,0.74-1.46,0.74c-0.66,0-1.09-0.25-1.27-0.75c-0.28,0.5-0.74,0.75-1.38,0.75h-0.47v-1.08h0.26
				c0.81,0,1.21-0.39,1.21-1.18v-0.17l0.71-0.25v0.19c0,0.95,0.31,1.42,0.94,1.42c0.72,0,1.08-0.4,1.08-1.19v-0.17l0.71-0.25v0.19
				c0,0.95,0.36,1.43,1.08,1.43c0.52,0,0.78-0.23,0.78-0.7c0-0.33-0.15-0.65-0.44-0.97l0.7-0.79
				C280.87,267.96,281.05,268.5,281.05,269.14z" />
                                <path d="M288.01,271.07h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V271.07z" />
                                <path d="M289.91,267.91c0,0.99-0.09,1.7-0.28,2.15c-0.29,0.67-0.82,1-1.61,1h-0.47v-1.08h0.48
				c0.48,0,0.8-0.19,0.95-0.56c0.09-0.22,0.14-0.63,0.14-1.21c0-0.18,0-0.35-0.01-0.51l-0.17-5.38l0.96-0.5V267.91z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M315.27,245.78l-0.36,0.96c-0.23-0.1-0.51-0.15-0.82-0.15c-0.47,0-0.95,0.16-1.45,0.47
				c-0.53,0.34-0.85,0.72-0.95,1.16c-0.01,0.04-0.01,0.09-0.01,0.14c0,0.23,0.28,0.38,0.85,0.46c0.37,0.02,0.75,0.05,1.12,0.08
				c0.88,0.1,1.32,0.51,1.32,1.23c0,0.73-0.54,1.42-1.63,2.06c-1.04,0.61-2.08,0.92-3.11,0.92c-1.01,0-1.8-0.23-2.39-0.68
				c-0.65-0.5-0.97-1.24-0.97-2.23c0-0.84,0.22-1.62,0.66-2.32l0.71,0.31c-0.33,0.59-0.5,1.16-0.5,1.7c0,1.42,0.88,2.12,2.64,2.12
				c0.6,0,1.22-0.11,1.88-0.33c0.68-0.23,1.24-0.53,1.68-0.9c0.21-0.18,0.32-0.34,0.32-0.47c0-0.18-0.16-0.29-0.47-0.33
				c-1.32-0.16-2.07-0.27-2.25-0.33c-0.41-0.15-0.61-0.5-0.61-1.06c0-0.77,0.37-1.49,1.11-2.15c0.72-0.64,1.47-0.96,2.25-0.96
				C314.67,245.48,315,245.58,315.27,245.78z" />
                                <path d="M322.23,250.59h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V250.59z M320.08,245.9
				l-0.71,0.93l-0.95-0.63l0.69-0.96L320.08,245.9z" />
                                <path d="M327.64,241.63l-0.15,1.13c-2.01,0.83-3.58,1.63-4.7,2.41c1.41,1.15,2.11,2.19,2.11,3.13
				c0,0.45-0.15,0.88-0.45,1.29c-0.49,0.66-1.26,0.99-2.33,0.99h-0.49v-1.08h0.84c1.05,0,1.57-0.36,1.57-1.07
				c0-0.4-0.22-0.84-0.66-1.32c-0.08-0.08-0.59-0.55-1.53-1.41c0.03-0.66,0.12-1.03,0.25-1.12
				C323.55,243.58,325.4,242.6,327.64,241.63z" />
                                <path d="M334.46,250.59h-0.44c-0.37,0-0.68-0.07-0.94-0.2c-0.11,0.9-0.67,1.79-1.68,2.65
				c-0.68,0.58-1.46,1.08-2.33,1.49l-0.68-0.57c0.98-0.56,1.81-1.13,2.5-1.72c0.87-0.74,1.31-1.34,1.31-1.8
				c0-0.35-0.22-0.83-0.65-1.44l0.73-0.84c0.36,0.52,0.58,0.81,0.65,0.88c0.3,0.3,0.66,0.45,1.08,0.45h0.46V250.59z" />
                                <path d="M339.23,249.01c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.64,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C339.12,247.96,339.23,248.49,339.23,249.01z M338.34,248.78c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C338.28,249.19,338.34,249.05,338.34,248.78z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M275.48,223.51l0.2,1.16l-1.11,0.26l-0.22-1.16L275.48,223.51z M279.85,224.03
				c0.82,0.77,1.24,1.62,1.27,2.57c0.03,0.95-0.34,1.83-1.1,2.65c-0.67,0.71-1.44,1.06-2.32,1.03c-0.78-0.03-1.47-0.31-2.06-0.87
				c-0.52-0.49-0.87-1.1-1.04-1.85l0.67-0.34c0.23,0.6,0.5,1.06,0.82,1.36c1.1,1.02,2.17,0.97,3.23-0.17
				c0.54-0.57,0.82-1.18,0.84-1.8c0.02-0.66-0.26-1.25-0.82-1.79c-0.51-0.48-1.16-0.75-1.94-0.83l0.05-1.01
				C278.41,223.09,279.21,223.43,279.85,224.03z" />
                                <path d="M282.94,223.64l-0.35,0.68l-6.63-5.88l0.39-0.96L282.94,223.64z" />
                                <path d="M288.51,217.97l-0.32,0.35c-0.25,0.27-0.47,0.43-0.68,0.5c-0.33,0.11-0.78,0.08-1.34-0.08
				c0.24,0.54,0.27,1.05,0.12,1.53c-0.12,0.37-0.4,0.79-0.85,1.27c-0.59,0.63-1.14,0.95-1.65,0.98l-0.33-0.99
				c0.36-0.08,0.72-0.3,1.07-0.68c1.04-1.11,1.31-1.89,0.82-2.35c-0.08-0.07-0.18-0.14-0.29-0.2l-2.72-1.31l-0.09-1.03l3.03,1.53
				c1,0.51,1.71,0.54,2.12,0.1l0.32-0.35L288.51,217.97z" />
                                <path d="M292.67,213.52l-0.32,0.34c-0.31,0.33-0.77,0.51-1.39,0.53c0.52,0.68,0.66,1.12,0.42,1.32
				c-0.6,0.5-1.38,0.81-2.34,0.92c-0.01,0.52-0.15,0.93-0.44,1.24l-0.4,0.43l-0.79-0.74l0.28-0.3c0.47-0.51,0.64-0.99,0.52-1.46
				c-0.2-0.7-0.3-1.08-0.31-1.14c-0.11-0.54-0.09-0.9,0.08-1.08c0.15-0.16,0.48-0.22,0.98-0.17c0.77,0.08,1.24,0.12,1.42,0.1
				c0.57-0.04,1.01-0.22,1.32-0.55l0.18-0.2L292.67,213.52z M289.34,214.33c-0.36-0.08-0.58-0.08-0.67,0.01
				c-0.16,0.17-0.08,0.6,0.25,1.29c0.33-0.01,0.69-0.1,1.06-0.25c0.21-0.09,0.35-0.17,0.42-0.25c0.11-0.11,0.1-0.23-0.03-0.35
				C290.17,214.59,289.83,214.44,289.34,214.33z" />
                                <path d="M295.44,208.84c0.78,0.72,0.94,1.33,0.49,1.81c-0.11,0.12-0.76,0.41-1.94,0.87
				c-0.13,0.54-0.44,1.07-0.93,1.59l-0.7,0.74l-0.79-0.74l1.13-1.21c-0.57,0.25-1.05,0.19-1.45-0.18c-0.53-0.49-0.65-1.31-0.38-2.46
				l-0.47,0.09l-0.45-1.02C292.7,207.82,294.53,207.99,295.44,208.84z M292.73,209.76c-0.15-0.14-0.33-0.24-0.54-0.29
				c-0.25-0.06-0.43-0.03-0.56,0.11c-0.15,0.16-0.21,0.38-0.2,0.69c0.01,0.3,0.09,0.53,0.25,0.67c0.14,0.13,0.37,0.17,0.69,0.11
				c0.28-0.05,0.48-0.14,0.59-0.26c0.12-0.13,0.14-0.31,0.06-0.54C292.97,210.06,292.87,209.89,292.73,209.76z M294.87,209.39
				c-0.21-0.2-0.83-0.31-1.84-0.32c0.08,0.06,0.16,0.12,0.23,0.19c0.35,0.33,0.53,0.74,0.53,1.23c0.13-0.03,0.35-0.11,0.65-0.24
				c0.34-0.14,0.54-0.23,0.58-0.28C295.16,209.81,295.12,209.62,294.87,209.39z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M390.54,172.82c0,1.12-0.34,2.02-1.01,2.69c-0.67,0.67-1.57,1-2.69,1c-0.98,0-1.75-0.33-2.34-0.99
				c-0.51-0.59-0.77-1.29-0.77-2.1c0-0.71,0.21-1.39,0.64-2.02l0.71,0.25c-0.29,0.58-0.43,1.09-0.43,1.53c0,1.5,0.78,2.25,2.33,2.25
				c0.79,0,1.42-0.21,1.89-0.62c0.49-0.44,0.74-1.04,0.74-1.82c0-0.7-0.24-1.36-0.72-1.98l0.77-0.65
				C390.25,171.12,390.54,171.94,390.54,172.82z M387.93,169.27l-0.71,0.93l-0.95-0.64l0.7-0.95L387.93,169.27z" />
                                <path d="M392.93,174.81l-0.73,0.2l-0.23-8.86l0.97-0.37V174.81z" />
                                <path d="M398.43,173.53c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C398.17,172,398.43,172.75,398.43,173.53z" />
                                <path d="M400.82,174.81l-0.73,0.2l-0.23-8.86l0.97-0.37V174.81z" />
                                <path d="M408.77,175.01h-0.47c-0.36,0-0.64-0.05-0.83-0.15c-0.31-0.17-0.59-0.51-0.85-1.03
				c-0.24,0.54-0.58,0.92-1.03,1.13c-0.35,0.17-0.86,0.25-1.51,0.25c-0.86,0-1.47-0.18-1.84-0.54l0.5-0.92
				c0.31,0.21,0.71,0.32,1.22,0.32c1.52,0,2.28-0.34,2.28-1.01c0-0.11-0.02-0.22-0.06-0.35l-0.9-2.88l0.69-0.77l0.95,3.26
				c0.31,1.08,0.77,1.62,1.38,1.62h0.47V175.01z" />
                                <path d="M411.11,173.14c0,1.25-0.73,1.87-2.18,1.87h-0.62v-1.08h0.68c0.84,0,1.26-0.23,1.26-0.68
				c0-0.24-0.12-0.53-0.37-0.85l-0.25-0.32l0.75-0.83C410.87,171.8,411.11,172.43,411.11,173.14z M410.66,169l-0.71,0.94L409,169.3
				l0.7-0.95L410.66,169z" />
                                <path d="M416.61,173.53c0,0.86-0.5,1.75-1.51,2.65c-0.71,0.64-1.49,1.16-2.34,1.56l-0.76-0.58
				c0.96-0.53,1.78-1.09,2.47-1.69c0.84-0.73,1.26-1.33,1.26-1.8c0-0.47-0.22-1.01-0.66-1.64l0.76-0.76
				C416.35,172,416.61,172.75,416.61,173.53z M415.8,169.2l-0.72,0.94l-0.95-0.64l0.69-0.96L415.8,169.2z" />
                                <path d="M420.69,175.01h-0.45c-0.76,0-1.29-0.33-1.61-0.98c-0.21-0.44-0.34-1.11-0.38-2.01
				c-0.01-0.32-0.03-1.2-0.05-2.65c-0.01-1-0.07-2.03-0.16-3.1l0.97-0.5c0.03,2.12,0.07,4.13,0.12,6.05c0.01,0.63,0.08,1.09,0.2,1.38
				c0.19,0.48,0.55,0.71,1.05,0.71h0.3V175.01z" />
                                <path d="M425.45,173.44c0,0.17-0.1,0.42-0.29,0.75c-0.21,0.36-0.4,0.55-0.57,0.55c-0.31,0-0.66-0.09-1.07-0.28
				c-0.38-0.17-0.69-0.38-0.93-0.6c-0.35,0.41-0.65,0.69-0.87,0.84c-0.31,0.21-0.65,0.32-1.02,0.32h-0.47v-1.08h0.25
				c0.76,0,1.34-0.35,1.75-1.04c0.13-0.23,0.37-0.64,0.73-1.23c0.35-0.59,0.72-0.88,1.11-0.88c0.44,0,0.79,0.35,1.07,1.06
				C425.34,172.39,425.45,172.92,425.45,173.44z M424.56,173.21c0-0.21-0.07-0.48-0.2-0.79c-0.15-0.35-0.3-0.53-0.46-0.53
				c-0.21,0-0.49,0.38-0.84,1.13c0.31,0.24,0.64,0.41,0.99,0.52c0.16,0.05,0.26,0.07,0.32,0.07
				C424.5,173.61,424.56,173.48,424.56,173.21z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M226.32,275.88c-0.14,0.19-0.4,0.37-0.79,0.55c-0.42,0.19-0.72,0.22-0.89,0.1
				c-0.19-0.13-0.45-0.35-0.81-0.64c-0.35-0.29-0.62-0.51-0.81-0.64c-0.39-0.28-0.73-0.34-1.04-0.18c-0.21,0.11-0.49,0.41-0.83,0.88
				l-3.02,4.2l-0.66-0.48l2.95-4.23c0.89-1.28,1.79-1.75,2.7-1.41c0.3-0.42,0.65-0.76,1.04-1.02c0.53-0.36,0.97-0.41,1.32-0.15
				c0.35,0.25,0.63,0.73,0.85,1.42C226.56,275.01,226.56,275.54,226.32,275.88z M225.4,275.4c0.08-0.12,0.09-0.36,0.01-0.73
				c-0.09-0.43-0.24-0.72-0.44-0.86c-0.14-0.1-0.32-0.1-0.53,0.01c-0.17,0.09-0.31,0.22-0.43,0.37c-0.05,0.08-0.1,0.16-0.14,0.25
				c0.1,0.08,0.27,0.22,0.51,0.43c0.21,0.19,0.38,0.33,0.5,0.41C225.14,275.48,225.32,275.51,225.4,275.4z" />
                                <path d="M232.69,283.35l-0.39-0.28c-0.54-0.38-0.76-0.98-0.68-1.78c0.07-0.61,0.28-1.24,0.65-1.91
				c-1.5,1.26-3.31,1.34-5.44,0.25l0.09-0.86c0.72,0.31,1.46,0.51,2.22,0.61c0.82,0.1,1.4,0.02,1.72-0.23
				c0.04-0.03,0.08-0.07,0.11-0.12c0.37-0.52,0.36-1.58-0.04-3.17c-0.32-1.27-0.71-2.33-1.15-3.17l0.9-0.88
				c0.55,1.25,0.94,2.52,1.17,3.8c0.26,1.45,0.23,2.54-0.08,3.28c0.66-0.53,1.41-1.38,2.23-2.53c0.48-0.67,0.93-1.35,1.33-2.04
				l1,0.27l-2.25,3.14c-0.75,1.05-1.24,1.95-1.47,2.7c-0.25,0.83-0.11,1.45,0.43,1.83l0.28,0.2L232.69,283.35z" />
                                <path d="M234.04,286.74l-0.99,0.29l-0.32-0.98l-0.9,0.25l-0.35-1.02l1.02-0.27l0.3,0.94l0.87-0.23L234.04,286.74z
				 M235.68,283.19c-0.73,1.01-1.68,1.1-2.86,0.25l-0.5-0.36l0.63-0.88l0.55,0.39c0.68,0.49,1.15,0.55,1.42,0.18
				c0.14-0.2,0.21-0.5,0.19-0.9l-0.01-0.41l1.09-0.23C236.26,281.96,236.09,282.61,235.68,283.19z" />
                                <path d="M237.11,286.27l-0.72-0.26l4.98-7.34l1,0.26L237.11,286.27z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M321.81,187.49l-0.32,0.28c-0.26,0.22-0.55,0.32-0.88,0.29c0.07,0.08,0.14,0.16,0.21,0.24
				c0.7,0.82,1,1.69,0.91,2.62c-0.09,0.93-0.56,1.75-1.38,2.45c-0.69,0.59-1.42,0.86-2.19,0.82c-0.77-0.05-1.45-0.41-2.04-1.1
				c-0.47-0.55-0.78-1.23-0.92-2.03l0.68-0.25c0.1,0.6,0.35,1.12,0.74,1.57c0.94,1.09,2,1.13,3.18,0.11
				c0.54-0.47,0.89-1.01,1.05-1.62c0.17-0.69,0.03-1.3-0.42-1.82c-0.45-0.53-1.08-0.92-1.87-1.16l0.16-1.06
				c0.52,0.22,0.89,0.36,1.1,0.39c0.41,0.07,0.75-0.01,1.03-0.25l0.29-0.25L321.81,187.49z M316.58,187.41l0.07,1.12l-1.08,0.13
				l-0.09-1.12L316.58,187.41z" />
                                <path d="M322.37,184.54c0.81,0.95,0.67,1.89-0.43,2.84l-0.47,0.4l-0.71-0.82l0.51-0.44
				c0.64-0.55,0.81-0.99,0.51-1.33c-0.16-0.18-0.44-0.32-0.83-0.4l-0.4-0.08l0.03-1.11C321.32,183.68,321.91,184,322.37,184.54z
				 M325.44,186.98l0.04,1.03l-1.03,0.08l0.03,0.94l-1.07,0.1l-0.02-1.05l0.98-0.07l-0.02-0.9L325.44,186.98z" />
                                <path d="M326.86,181.03c0.67,0.78,1.02,1.72,1.05,2.82c0.03,0.99-0.2,1.97-0.69,2.97l-1.02-0.13
				c0.4-1.05,0.64-1.85,0.72-2.42c0.13-0.88,0-1.64-0.39-2.27c-0.1,0.33-0.3,0.63-0.62,0.9c-0.31,0.26-0.62,0.4-0.93,0.41
				c-0.35,0.01-0.65-0.14-0.91-0.44c-0.34-0.4-0.56-0.87-0.66-1.42c-0.11-0.61-0.01-1.05,0.32-1.33c0.44-0.38,0.99-0.42,1.67-0.14
				C325.95,180.18,326.44,180.54,326.86,181.03z M325.76,181.35c-0.52-0.55-0.97-0.66-1.35-0.34c-0.13,0.11-0.19,0.28-0.17,0.49
				c0.02,0.22,0.09,0.39,0.21,0.53c0.25,0.29,0.55,0.28,0.91-0.03C325.56,181.84,325.69,181.62,325.76,181.35z" />
                                <path d="M328.53,175.56l0.07,1.17l-1.13,0.14l-0.1-1.18L328.53,175.56z M333.21,177.72l-0.34,0.29
				c-0.28,0.24-0.56,0.39-0.84,0.46c0.5,0.76,0.65,1.79,0.45,3.1c-0.14,0.88-0.4,1.77-0.8,2.65l-0.89,0.01
				c0.37-1.06,0.63-2.04,0.78-2.93c0.18-1.13,0.12-1.87-0.18-2.22c-0.23-0.27-0.71-0.49-1.43-0.67l0.01-1.11
				c0.61,0.16,0.97,0.24,1.07,0.25c0.43,0.03,0.8-0.08,1.11-0.36l0.35-0.3L333.21,177.72z" />
                                <path d="M330.61,170.06l0.05,1.02l-1.02,0.07l0.03,0.94l-1.07,0.1l-0.03-1.06l1-0.07l-0.02-0.9L330.61,170.06z
				 M334.15,173.56c1.1,1.29,0.99,2.5-0.33,3.63l-0.96,0.82l-0.71-0.82l0.86-0.74c0.22-0.19,0.45-0.46,0.69-0.84
				c0.32-0.47,0.41-0.79,0.27-0.95l-0.31-0.36c-0.12,0.35-0.33,0.66-0.63,0.92c-0.27,0.23-0.55,0.34-0.84,0.31
				c-0.29-0.02-0.55-0.16-0.78-0.43c-0.27-0.31-0.47-0.75-0.63-1.31c-0.19-0.71-0.12-1.21,0.21-1.5c0.36-0.31,0.92-0.27,1.68,0.13
				C333.29,172.75,333.78,173.13,334.15,173.56z M332.93,173.71c-0.64-0.53-1.09-0.69-1.34-0.47c-0.11,0.09-0.14,0.28-0.09,0.55
				c0.04,0.25,0.11,0.43,0.22,0.55c0.24,0.28,0.51,0.3,0.81,0.05C332.76,174.19,332.89,173.96,332.93,173.71z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M345.62,185l0.05,0.95l-0.91,0.11l-0.08-0.95L345.62,185z M348.38,187.22c0.45,0.53,0.61,1.33,0.47,2.41
				c-0.1,0.76-0.3,1.49-0.61,2.18l-0.76,0.04c0.31-0.82,0.52-1.6,0.62-2.32c0.13-0.89,0.07-1.47-0.17-1.76
				c-0.24-0.29-0.67-0.5-1.26-0.65l0.07-0.87C347.42,186.43,347.97,186.75,348.38,187.22z" />
                                <path d="M353.42,184.48l-0.27,0.23c-0.23,0.19-0.45,0.32-0.68,0.37c0.4,0.61,0.53,1.44,0.36,2.5
				c-0.11,0.71-0.32,1.42-0.64,2.13l-0.72,0.01c0.3-0.86,0.51-1.64,0.63-2.36c0.15-0.91,0.1-1.5-0.15-1.79
				c-0.18-0.21-0.57-0.39-1.16-0.54l0.01-0.89c0.49,0.12,0.78,0.19,0.86,0.2c0.34,0.03,0.64-0.07,0.9-0.29l0.28-0.24L353.42,184.48z" />
                                <path d="M355.85,182.39l-0.38,0.32c-0.52,0.45-1.02,0.55-1.49,0.33c0.06,0.24,0.05,0.48-0.04,0.73
				c-0.09,0.25-0.23,0.46-0.42,0.62l-0.38,0.33l-0.57-0.66l0.34-0.29c0.22-0.19,0.36-0.4,0.43-0.63c0.07-0.26,0.02-0.5-0.16-0.71
				l-0.24-0.28l0.35-0.51c0.37,0.43,0.7,0.65,0.98,0.67c0.22,0.02,0.47-0.1,0.75-0.35l0.27-0.23L355.85,182.39z M356.07,184.36
				l0.05,0.94l-0.9,0.11l-0.08-0.95L356.07,184.36z" />
                                <path d="M355.37,179.46c0.52,0.6,0.83,1.09,0.95,1.46c0.18,0.56,0.02,1.05-0.46,1.46l-0.28,0.24l-0.57-0.66
				l0.29-0.25c0.29-0.25,0.39-0.53,0.29-0.84c-0.06-0.18-0.24-0.46-0.55-0.81c-0.1-0.11-0.19-0.22-0.27-0.31l-2.92-3.2l0.33-0.81
				L355.37,179.46z" />
                                <path d="M358.37,180.02l-0.34,0.51l-4.79-5.3l0.4-0.73L358.37,180.02z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M359.56,435.68l-0.25-0.37c-0.21-0.3-0.33-0.6-0.37-0.88c-0.81,0.42-1.85,0.46-3.13,0.12
				c-0.86-0.23-1.71-0.59-2.55-1.07l0.08-0.88c1.02,0.48,1.96,0.84,2.83,1.09c1.1,0.3,1.85,0.32,2.23,0.05
				c0.29-0.2,0.56-0.65,0.81-1.36l1.1,0.12c-0.22,0.59-0.34,0.94-0.36,1.04c-0.08,0.42,0,0.8,0.24,1.14l0.26,0.38L359.56,435.68z" />
                                <path d="M362.83,440.43l-0.28-0.4c-0.26-0.37-0.55-0.65-0.88-0.83c-0.42-0.23-0.8-0.24-1.13-0.01
				c-0.34,0.23-0.47,0.61-0.41,1.12l-1,0.3c-0.49-1.59-0.19-3.01,0.89-4.24l-0.72-1.05l0.89-0.62l0.66,0.95
				c0.71-0.49,1.51-0.79,2.42-0.9c0.8-0.1,1.28-0.03,1.44,0.2c0.13,0.18,0.08,0.54-0.14,1.06c-0.24,0.56-0.57,0.99-0.99,1.28
				c-0.48,0.33-1.01,0.5-1.57,0.51c-0.64,0.01-1.12-0.22-1.43-0.68c-0.38,0.44-0.57,0.99-0.58,1.66c0.08-0.09,0.16-0.17,0.26-0.23
				c0.48-0.33,1.03-0.43,1.64-0.29c0.59,0.13,1.06,0.44,1.39,0.93l0.43,0.62L362.83,440.43z M362.93,436.81
				c0.28-0.19,0.47-0.42,0.59-0.7c0.1-0.23,0.12-0.38,0.06-0.46c-0.06-0.08-0.29-0.08-0.71,0c-0.51,0.1-1,0.32-1.47,0.64
				c0.18,0.32,0.4,0.53,0.66,0.63C362.35,437.05,362.64,437.01,362.93,436.81z" />
                                <path d="M368.47,445.21c-0.43,0.3-0.87,0.43-1.33,0.41c-0.49-0.02-0.89-0.25-1.18-0.66
				c-0.38-0.55-0.44-1.08-0.19-1.58c-0.61-0.01-1.09-0.27-1.44-0.78c-0.38-0.55-0.41-1.04-0.1-1.47c-0.57,0.05-1.04-0.18-1.4-0.71
				l-0.26-0.38l0.89-0.62l0.15,0.22c0.46,0.67,1.01,0.78,1.66,0.33l0.14-0.1l0.61,0.44l-0.15,0.11c-0.78,0.54-0.99,1.06-0.64,1.58
				c0.41,0.59,0.94,0.67,1.59,0.22l0.14-0.1l0.61,0.44l-0.16,0.11c-0.78,0.54-0.97,1.11-0.56,1.7c0.29,0.43,0.63,0.51,1.02,0.24
				c0.27-0.19,0.45-0.49,0.54-0.91l1.05,0.12C369.34,444.39,369,444.85,368.47,445.21z M370.76,441.73l-0.92-0.05l0.03-1l-0.89-0.06
				l0.02-0.97l0.94,0.07l-0.04,0.96l0.87,0.06L370.76,441.73z M371.29,440.21l-0.87-0.04l0.03-0.98l0.87,0.06L371.29,440.21z" />
                                <path d="M370.43,451.45l-0.67-0.97c-1.63,0.74-3.35,0.54-5.16-0.6l0.24-1c0.99,0.5,1.75,0.82,2.29,0.97
				c0.82,0.23,1.53,0.21,2.12-0.06c-0.17-0.17-0.33-0.37-0.48-0.58c-0.62-0.89-0.61-1.56,0.03-2c0.39-0.27,0.87-0.43,1.46-0.5
				c0.67-0.08,1.13,0.06,1.37,0.41c0.31,0.45,0.33,0.96,0.06,1.52c-0.2,0.43-0.54,0.85-1.02,1.25l0.65,0.94L370.43,451.45z
				 M370.13,449.06c0.22-0.17,0.39-0.38,0.52-0.62c0.16-0.29,0.17-0.54,0.02-0.75c-0.1-0.14-0.27-0.22-0.51-0.21
				c-0.22,0-0.4,0.06-0.55,0.16c-0.24,0.16-0.23,0.45,0.02,0.85C369.8,448.78,369.97,448.97,370.13,449.06z" />
                                <path d="M369.92,454.29l-1.17-0.06l-0.02-1.14l1.19,0.03L369.92,454.29z M373.29,452.3
				c-1.03,0.71-1.95,0.47-2.78-0.73l-0.35-0.51l0.89-0.62l0.38,0.56c0.48,0.69,0.9,0.91,1.27,0.65c0.2-0.14,0.36-0.4,0.49-0.79
				l0.12-0.38l1.1,0.15C374.26,451.34,373.88,451.9,373.29,452.3z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M341.99,352.11c-0.52,0.44-1.14,0.68-1.86,0.7c-0.65,0.02-1.3-0.13-1.96-0.45l0.09-0.67
				c0.69,0.26,1.22,0.42,1.6,0.48c0.58,0.08,1.08,0,1.5-0.26c-0.22-0.06-0.42-0.2-0.6-0.41c-0.17-0.2-0.26-0.41-0.27-0.62
				c-0.01-0.23,0.09-0.43,0.29-0.6c0.26-0.23,0.57-0.37,0.94-0.44c0.4-0.07,0.69,0,0.88,0.21c0.25,0.29,0.28,0.66,0.1,1.1
				C342.55,351.51,342.31,351.83,341.99,352.11z M341.77,351.39c0.36-0.34,0.44-0.64,0.22-0.89c-0.08-0.09-0.18-0.12-0.33-0.11
				c-0.14,0.01-0.26,0.06-0.35,0.14c-0.19,0.16-0.18,0.36,0.02,0.6C341.45,351.25,341.6,351.34,341.77,351.39z" />
                                <path d="M345.87,358.27l-0.29-0.33c-0.26-0.3-0.38-0.59-0.38-0.87c0.01-0.27,0.13-0.56,0.37-0.89
				c-0.39-0.09-0.75-0.32-1.09-0.71c-0.13-0.15-0.19-0.32-0.18-0.51c0.01-0.19,0.09-0.34,0.24-0.47c0.52-0.44,1.31-0.45,2.37,0
				l0.34-0.42l0.64,0.12l-1.51,1.89c-0.28,0.35-0.43,0.6-0.46,0.76c-0.04,0.22,0.07,0.48,0.32,0.78l0.17,0.2L345.87,358.27z
				 M345.98,355.62l0.52-0.66c-0.22-0.11-0.44-0.19-0.68-0.25c-0.33-0.08-0.55-0.06-0.68,0.05c-0.09,0.08-0.06,0.21,0.1,0.39
				C345.5,355.45,345.74,355.6,345.98,355.62z" />
                                <path d="M346.2,360.66l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.06-0.71l0.7-0.01l0.04,0.65l0.6-0.01L346.2,360.66z
				 M347.81,358.64c-0.63,0.54-1.25,0.44-1.87-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34
				c0.12-0.1,0.21-0.29,0.27-0.55l0.05-0.26l0.74,0.02C348.38,357.94,348.17,358.34,347.81,358.64z" />
                                <path d="M349.8,362.86l-0.51-0.59c-1.02,0.6-2.16,0.59-3.43-0.04l0.09-0.67c0.68,0.26,1.21,0.42,1.57,0.48
				c0.56,0.09,1.02,0.03,1.39-0.19c-0.13-0.1-0.24-0.22-0.36-0.35c-0.47-0.54-0.51-0.98-0.12-1.32c0.24-0.2,0.54-0.35,0.92-0.43
				c0.43-0.1,0.74-0.04,0.93,0.18c0.23,0.27,0.28,0.61,0.15,0.99c-0.1,0.3-0.3,0.59-0.59,0.89l0.49,0.57L349.8,362.86z
				 M349.43,361.31c0.13-0.13,0.23-0.28,0.3-0.44c0.08-0.2,0.07-0.37-0.04-0.49c-0.07-0.09-0.19-0.12-0.35-0.1
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.14,0.12-0.12,0.31,0.07,0.56C349.2,361.15,349.32,361.26,349.43,361.31z" />
                                <path d="M351.25,364.55l-0.2-0.23c-0.28-0.32-0.31-0.69-0.1-1.11c-0.49,0.09-0.88-0.03-1.16-0.36l-0.2-0.23
				l0.54-0.47l0.11,0.12c0.25,0.29,0.51,0.41,0.77,0.35c0.2-0.04,0.45-0.2,0.76-0.49l2.81-2.56l0.66,0.27l-2.95,2.53
				c-0.75,0.65-0.96,1.16-0.63,1.55l0.13,0.15L351.25,364.55z" />
                                <path d="M351.65,367.01l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.04,0.65l0.6-0.01L351.65,367.01z
				 M352.96,366.54l-0.27-0.31c-0.36-0.42-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.04c-0.2-0.08-0.37-0.19-0.51-0.35
				l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.58-0.13l0.23-0.2l0.42,0.29
				c-0.35,0.31-0.54,0.57-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L352.96,366.54z" />
                                <path d="M355.62,369.64l-0.19-0.23c-0.51-0.6-0.58-1.5-0.2-2.71c-0.06,0.08-0.13,0.14-0.2,0.2
				c-0.36,0.3-0.73,0.4-1.13,0.28c-0.34-0.1-0.67-0.33-0.98-0.71l-0.22-0.25l0.54-0.47l0.19,0.22c0.57,0.67,1.05,0.83,1.45,0.49
				c0.2-0.17,0.31-0.42,0.33-0.75c0.01-0.24,0.03-0.67,0.06-1.29c0.36-0.29,0.57-0.43,0.63-0.42c0.49,0.12,1.18,0.36,2.08,0.71
				c0.86,0.34,1.53,0.63,2,0.87l-0.62,0.41c-0.49-0.25-1.1-0.52-1.84-0.83c-0.8-0.33-1.33-0.52-1.61-0.57c0,0.26,0.01,0.58,0.01,0.95
				c0,0.3-0.02,0.59-0.06,0.88c-0.1,0.65-0.15,1.12-0.16,1.42c-0.01,0.5,0.08,0.87,0.27,1.08l0.2,0.23L355.62,369.64z" />
                                <path d="M358.1,372.53l-0.21-0.24c-0.19-0.23-0.41-0.39-0.64-0.49c-0.29-0.12-0.54-0.1-0.74,0.08
				c-0.21,0.18-0.27,0.43-0.19,0.76l-0.63,0.26c-0.43-1.01-0.34-1.96,0.29-2.84l-0.55-0.64l0.54-0.47l0.5,0.58
				c0.43-0.37,0.94-0.62,1.52-0.76c0.52-0.12,0.84-0.11,0.96,0.03c0.1,0.11,0.09,0.35-0.02,0.71c-0.12,0.39-0.3,0.69-0.56,0.91
				c-0.29,0.25-0.62,0.4-0.99,0.44c-0.42,0.05-0.75-0.07-0.99-0.35c-0.22,0.31-0.31,0.69-0.26,1.13c0.04-0.06,0.1-0.12,0.16-0.17
				c0.29-0.25,0.64-0.35,1.06-0.31c0.4,0.05,0.72,0.22,0.98,0.51l0.33,0.38L358.1,372.53z M357.91,370.15
				c0.17-0.14,0.28-0.31,0.34-0.5c0.05-0.16,0.05-0.26,0.01-0.31c-0.04-0.05-0.2-0.04-0.46,0.05c-0.33,0.1-0.63,0.28-0.92,0.52
				c0.14,0.2,0.3,0.32,0.47,0.37C357.55,370.34,357.74,370.3,357.91,370.15z" />
                                <path d="M364.9,371.39l-0.63,0.41c-1.28-0.65-2.36-1.09-3.23-1.32c0.03,1.2-0.19,2-0.66,2.4
				c-0.22,0.19-0.5,0.3-0.84,0.33c-0.54,0.04-1.04-0.21-1.5-0.74l-0.21-0.24l0.54-0.47l0.36,0.42c0.45,0.52,0.85,0.63,1.21,0.33
				c0.2-0.17,0.33-0.47,0.38-0.9c0.01-0.07,0.03-0.53,0.05-1.37c0.34-0.27,0.57-0.38,0.67-0.36
				C362.17,370.18,363.46,370.68,364.9,371.39z" />
                                <path d="M335.2,363.96l-0.2-0.24c-0.16-0.18-0.25-0.34-0.28-0.48c-0.05-0.22,0-0.51,0.15-0.87
				c-0.37,0.11-0.71,0.1-1.01-0.03c-0.23-0.11-0.49-0.32-0.77-0.65c-0.37-0.43-0.54-0.81-0.52-1.15l0.67-0.14
				c0.02,0.25,0.15,0.5,0.36,0.75c0.65,0.76,1.15,1,1.48,0.71c0.05-0.05,0.1-0.11,0.15-0.18l1.06-1.69l0.68,0.01l-1.23,1.87
				c-0.41,0.62-0.48,1.08-0.22,1.38l0.2,0.24L335.2,363.96z" />
                                <path d="M337.81,367l-0.2-0.23c-0.19-0.23-0.28-0.54-0.25-0.95c-0.48,0.29-0.78,0.35-0.9,0.18
				c-0.29-0.43-0.43-0.97-0.44-1.6c-0.34-0.04-0.6-0.17-0.78-0.38l-0.25-0.29l0.54-0.47l0.18,0.21c0.3,0.35,0.6,0.5,0.92,0.44
				c0.47-0.08,0.73-0.12,0.77-0.12c0.36-0.03,0.6,0.01,0.7,0.13c0.1,0.11,0.11,0.33,0.04,0.66c-0.11,0.5-0.17,0.81-0.17,0.93
				c-0.02,0.38,0.07,0.68,0.26,0.91l0.12,0.13L337.81,367z M337.52,364.76c0.08-0.23,0.1-0.38,0.04-0.44
				c-0.1-0.12-0.39-0.1-0.86,0.07c-0.01,0.22,0.01,0.46,0.09,0.71c0.04,0.14,0.09,0.24,0.13,0.29c0.07,0.08,0.14,0.08,0.23,0
				C337.29,365.29,337.41,365.07,337.52,364.76z" />
                                <path d="M342.22,369.06l-0.63,0.32c-0.37-0.43-0.77-0.72-1.2-0.86c-0.22-0.07-0.6-0.2-1.16-0.38
				c-0.43-0.15-0.85-0.47-1.26-0.95l-0.35-0.41l0.54-0.47l0.37,0.43c0.28,0.33,0.55,0.57,0.82,0.73c0.17,0.11,0.43,0.22,0.78,0.35
				c0.37,0.13,0.64,0.25,0.79,0.33c-0.08-0.17-0.18-0.45-0.3-0.86c-0.11-0.37-0.19-0.59-0.26-0.67c-0.11-0.12-0.35-0.2-0.72-0.23
				l-0.09-0.46c0.22-0.04,0.45-0.05,0.7-0.02c0.3,0.03,0.5,0.11,0.6,0.22c0.15,0.17,0.27,0.43,0.37,0.79c0.16,0.58,0.26,0.91,0.29,1
				C341.68,368.34,341.91,368.72,342.22,369.06z" />
                                <path d="M341.82,371.47l-0.42-0.28l4.34-3.92l0.6,0.33L341.82,371.47z" />
                                <path d="M344.71,375.04l-0.19-0.22c-0.16-0.18-0.26-0.37-0.3-0.55c-0.5,0.33-1.18,0.43-2.05,0.3
				c-0.58-0.09-1.17-0.27-1.75-0.53l-0.01-0.59c0.7,0.25,1.35,0.42,1.93,0.52c0.74,0.12,1.23,0.08,1.47-0.12
				c0.17-0.15,0.32-0.46,0.44-0.95l0.73,0c-0.1,0.4-0.16,0.64-0.16,0.71c-0.02,0.28,0.06,0.52,0.23,0.73l0.2,0.23L344.71,375.04z" />
                                <path d="M345.05,377.43l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.04,0.65l0.6-0.01L345.05,377.43z
				 M346.65,375.41c-0.63,0.54-1.25,0.44-1.87-0.28l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34
				c0.12-0.1,0.21-0.29,0.26-0.55l0.05-0.26l0.73,0.02C347.22,374.72,347.01,375.11,346.65,375.41z" />
                                <path d="M348.64,379.63l-0.51-0.59c-1.02,0.6-2.16,0.59-3.43-0.04l0.09-0.67c0.68,0.26,1.21,0.42,1.57,0.48
				c0.56,0.09,1.02,0.03,1.39-0.19c-0.13-0.1-0.24-0.22-0.36-0.35c-0.47-0.54-0.51-0.98-0.12-1.32c0.24-0.2,0.54-0.34,0.92-0.43
				c0.43-0.1,0.74-0.04,0.93,0.18c0.24,0.27,0.28,0.61,0.15,0.99c-0.1,0.29-0.3,0.59-0.58,0.89l0.49,0.57L348.64,379.63z
				 M348.28,378.08c0.13-0.13,0.23-0.28,0.3-0.44c0.08-0.2,0.07-0.37-0.04-0.49c-0.08-0.09-0.19-0.12-0.35-0.1
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.14,0.12-0.12,0.31,0.07,0.56C348.04,377.92,348.17,378.03,348.28,378.08z" />
                                <path d="M348.51,381.53l-0.77,0.04l-0.09-0.75l0.78-0.06L348.51,381.53z M350.58,379.99
				c-0.63,0.54-1.25,0.44-1.87-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.65,0.53,0.88,0.34c0.12-0.1,0.21-0.29,0.26-0.55
				l0.05-0.26l0.74,0.02C351.14,379.29,350.94,379.68,350.58,379.99z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M320.75,301.39l-0.64,0.23c-0.05-0.16-0.14-0.32-0.28-0.48c-0.2-0.24-0.49-0.41-0.86-0.52
				c-0.4-0.12-0.73-0.11-0.99,0.02c-0.02,0.01-0.05,0.03-0.08,0.05c-0.11,0.1-0.07,0.31,0.14,0.62c0.15,0.2,0.3,0.4,0.44,0.6
				c0.33,0.48,0.31,0.88-0.05,1.19c-0.37,0.32-0.95,0.34-1.73,0.07c-0.75-0.26-1.35-0.65-1.8-1.17c-0.43-0.51-0.66-1-0.69-1.49
				c-0.03-0.54,0.21-1.02,0.7-1.45c0.42-0.36,0.91-0.58,1.45-0.67l0.15,0.49c-0.44,0.09-0.8,0.25-1.07,0.48
				c-0.71,0.61-0.69,1.36,0.07,2.24c0.26,0.3,0.58,0.57,0.98,0.8c0.41,0.24,0.8,0.39,1.17,0.46c0.18,0.03,0.31,0.01,0.38-0.04
				c0.09-0.08,0.08-0.2-0.04-0.38c-0.49-0.73-0.76-1.15-0.8-1.27c-0.1-0.27-0.01-0.52,0.27-0.76c0.39-0.33,0.91-0.45,1.56-0.37
				c0.63,0.08,1.11,0.32,1.45,0.71C320.64,300.96,320.73,301.16,320.75,301.39z" />
                                <path d="M321.45,305.56c-0.43,0.37-1.09,0.5-1.98,0.39c-0.63-0.08-1.22-0.25-1.79-0.5l-0.04-0.63
				c0.68,0.25,1.31,0.42,1.91,0.51c0.73,0.11,1.21,0.06,1.44-0.14c0.23-0.2,0.41-0.55,0.54-1.04l0.71,0.05
				C322.1,304.78,321.83,305.23,321.45,305.56z" />
                                <path d="M322.46,308.25l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.17c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.81-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.16,0.3-0.12,0.58,0.1,0.84l0.13,0.15L322.46,308.25z" />
                                <path d="M322.85,310.71l-0.68,0.03l-0.05-0.68l-0.62,0.02l-0.07-0.71l0.7-0.01l0.05,0.65l0.6-0.01L322.85,310.71z
				 M324.17,310.24l-0.27-0.31c-0.37-0.43-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.03c-0.21-0.08-0.37-0.19-0.51-0.35
				l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.59-0.13l0.23-0.2l0.42,0.29
				c-0.35,0.31-0.54,0.57-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L324.17,310.24z" />
                                <path d="M325.89,312.25l-0.27-0.31c-0.37-0.43-0.46-0.83-0.27-1.22c-0.19,0.05-0.39,0.04-0.6-0.04
				c-0.21-0.08-0.37-0.19-0.51-0.35l-0.27-0.31l0.54-0.47l0.24,0.28c0.16,0.18,0.33,0.3,0.52,0.35c0.22,0.06,0.41,0.01,0.59-0.13
				l0.23-0.2l0.42,0.29c-0.35,0.31-0.54,0.58-0.55,0.8c-0.01,0.18,0.08,0.38,0.28,0.62l0.19,0.22L325.89,312.25z M328.22,309.56
				l-0.68,0.03l-0.05-0.67l-0.62,0.01l-0.06-0.71l0.7-0.02l0.05,0.65l0.6-0.01L328.22,309.56z" />
                                <path d="M329.33,316.26l-0.5-0.58c-0.28-0.33-0.37-0.66-0.27-0.99c0.03-0.1,0.15-0.31,0.37-0.66l-1.53-0.62
				c-0.52-0.21-0.96-0.53-1.33-0.95l-0.39-0.45l0.54-0.46l0.37,0.43c0.37,0.43,0.76,0.74,1.17,0.93c0.25,0.11,0.69,0.31,1.33,0.59
				c-0.13-0.25-0.26-0.58-0.39-1.01c-0.12-0.39-0.2-0.62-0.26-0.69c-0.12-0.14-0.34-0.21-0.66-0.18l-0.11-0.48
				c0.66-0.15,1.09-0.1,1.3,0.14c0.14,0.16,0.26,0.42,0.37,0.78c0.16,0.54,0.27,0.88,0.32,1.02c0.17,0.43,0.41,0.82,0.72,1.18
				c0.06,0.07,0.12,0.15,0.19,0.22l-0.62,0.31c-0.25-0.29-0.49-0.48-0.71-0.58c-0.22,0.32-0.14,0.7,0.24,1.14l0.38,0.44
				L329.33,316.26z M330.98,311.67l-0.77,0.04l-0.09-0.75l0.78-0.06L330.98,311.67z" />
                                <path d="M329.2,318.17l-0.77,0.04l-0.09-0.75l0.78-0.06L329.2,318.17z M331.28,316.63
				c-0.63,0.54-1.25,0.44-1.88-0.29l-0.27-0.31l0.54-0.47l0.29,0.34c0.36,0.42,0.66,0.53,0.88,0.34c0.12-0.11,0.21-0.29,0.27-0.55
				l0.05-0.26l0.74,0.02C331.84,315.93,331.63,316.32,331.28,316.63z" />
                                <path d="M335,321.22c-0.52,0.45-1.14,0.68-1.86,0.7c-0.65,0.02-1.31-0.13-1.96-0.45l0.09-0.67
				c0.69,0.26,1.23,0.42,1.6,0.48c0.58,0.08,1.08,0,1.5-0.26c-0.22-0.07-0.42-0.2-0.6-0.41c-0.18-0.2-0.27-0.41-0.27-0.62
				c-0.01-0.23,0.09-0.43,0.29-0.6c0.26-0.23,0.58-0.37,0.94-0.43c0.4-0.07,0.69,0,0.88,0.21c0.25,0.29,0.28,0.66,0.1,1.1
				C335.56,320.63,335.32,320.95,335,321.22z M334.79,320.5c0.36-0.34,0.44-0.64,0.22-0.89c-0.08-0.09-0.18-0.12-0.33-0.11
				c-0.14,0.02-0.26,0.06-0.35,0.14c-0.19,0.16-0.18,0.36,0.02,0.6C334.46,320.37,334.6,320.45,334.79,320.5z" />
                                <path d="M340.53,326.49c-0.67,0.57-1.26,0.9-1.77,0.99c-0.65,0.11-1.25-0.15-1.78-0.78
				c-0.41-0.48-0.59-0.96-0.55-1.45s0.3-0.94,0.78-1.34c0.16-0.13,0.37-0.26,0.64-0.4c0.27-0.13,0.5-0.21,0.7-0.25l0.18,0.46
				c-0.42,0.11-0.75,0.27-0.99,0.48c-0.75,0.64-0.8,1.34-0.16,2.09c0.65,0.75,1.46,0.72,2.42-0.11c0.21-0.18,1.24-1.12,3.1-2.82
				l0.66,0.34L340.53,326.49z" />
                                <path d="M340.88,329.73l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.17c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.82-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.15,0.3-0.12,0.58,0.1,0.84l0.13,0.15L340.88,329.73z" />
                                <path d="M344.32,333.74l-0.5-0.58c-0.28-0.33-0.37-0.66-0.27-0.99c0.03-0.1,0.15-0.31,0.37-0.66l-1.53-0.62
				c-0.52-0.21-0.96-0.53-1.33-0.95l-0.39-0.45l0.54-0.46l0.37,0.43c0.37,0.43,0.76,0.74,1.17,0.93c0.25,0.11,0.69,0.31,1.33,0.59
				c-0.14-0.25-0.26-0.58-0.39-1.01c-0.12-0.39-0.2-0.62-0.26-0.69c-0.12-0.14-0.34-0.21-0.66-0.18l-0.11-0.48
				c0.66-0.15,1.09-0.1,1.3,0.14c0.14,0.16,0.26,0.42,0.37,0.78c0.16,0.54,0.27,0.88,0.32,1.02c0.17,0.43,0.41,0.82,0.72,1.18
				c0.06,0.07,0.13,0.15,0.19,0.22l-0.62,0.31c-0.25-0.29-0.49-0.48-0.71-0.58c-0.22,0.31-0.14,0.69,0.24,1.14l0.38,0.44
				L344.32,333.74z" />
                                <path d="M347.16,335.45c-0.08,0.07-0.25,0.13-0.5,0.18c-0.27,0.05-0.45,0.03-0.52-0.05
				c-0.13-0.15-0.24-0.37-0.32-0.66c-0.08-0.26-0.11-0.51-0.1-0.73c-0.36,0-0.62-0.03-0.8-0.08c-0.24-0.06-0.44-0.19-0.6-0.37
				l-0.2-0.23l0.54-0.47l0.11,0.12c0.33,0.38,0.75,0.52,1.27,0.43c0.17-0.04,0.48-0.09,0.93-0.17c0.45-0.08,0.75-0.02,0.92,0.17
				c0.19,0.22,0.16,0.55-0.07,0.99C347.64,334.94,347.42,335.23,347.16,335.45z M346.9,334.91c0.11-0.09,0.21-0.24,0.31-0.44
				c0.11-0.23,0.14-0.38,0.07-0.46c-0.09-0.1-0.4-0.08-0.93,0.07c0.01,0.26,0.07,0.5,0.16,0.72c0.04,0.1,0.08,0.16,0.1,0.19
				C346.67,335.05,346.76,335.02,346.9,334.91z" />
                                <path d="M349.48,338.24c-0.43,0.37-1.09,0.5-1.98,0.39c-0.63-0.08-1.22-0.25-1.79-0.5l-0.04-0.63
				c0.68,0.25,1.31,0.42,1.91,0.51c0.73,0.11,1.21,0.06,1.44-0.14c0.23-0.2,0.41-0.54,0.54-1.04l0.71,0.05
				C350.14,337.46,349.87,337.91,349.48,338.24z" />
                                <path d="M350.49,340.93l-0.19-0.23c-0.33-0.38-0.39-0.79-0.2-1.23c0.13-0.3,0.41-0.65,0.85-1.05
				c0.15-0.14,0.59-0.53,1.31-1.16c0.5-0.44,0.99-0.91,1.49-1.42l0.67,0.27c-1.05,0.93-2.04,1.81-2.98,2.67
				c-0.31,0.28-0.51,0.51-0.61,0.7c-0.16,0.3-0.12,0.58,0.1,0.84l0.13,0.15L350.49,340.93z" />
                                <path d="M352.97,343.81l-0.21-0.25c-0.19-0.23-0.41-0.39-0.64-0.49c-0.29-0.12-0.54-0.1-0.75,0.08
				c-0.21,0.18-0.27,0.43-0.19,0.77l-0.63,0.26c-0.44-1.01-0.34-1.96,0.29-2.85l-0.55-0.64l0.54-0.47l0.5,0.58
				c0.43-0.37,0.94-0.62,1.53-0.76c0.52-0.12,0.84-0.11,0.96,0.03c0.1,0.11,0.09,0.35-0.02,0.71c-0.12,0.39-0.3,0.69-0.56,0.91
				c-0.29,0.25-0.63,0.4-1,0.44c-0.42,0.05-0.75-0.07-0.99-0.35c-0.22,0.31-0.3,0.69-0.26,1.13c0.04-0.06,0.1-0.12,0.16-0.17
				c0.29-0.25,0.65-0.35,1.06-0.31c0.4,0.05,0.72,0.22,0.98,0.52l0.33,0.38L352.97,343.81z M352.78,341.43
				c0.17-0.14,0.28-0.31,0.34-0.5c0.05-0.16,0.05-0.26,0.01-0.31c-0.04-0.05-0.2-0.03-0.46,0.05c-0.33,0.1-0.63,0.28-0.92,0.52
				c0.14,0.2,0.3,0.32,0.48,0.37C352.42,341.63,352.61,341.58,352.78,341.43z" />
                                <path d="M357.39,345.88l-0.63,0.32c-0.37-0.43-0.77-0.72-1.21-0.87c-0.22-0.07-0.6-0.2-1.16-0.38
				c-0.43-0.15-0.85-0.47-1.27-0.95l-0.35-0.41l0.54-0.47l0.37,0.43c0.28,0.33,0.56,0.57,0.82,0.73c0.17,0.11,0.43,0.22,0.79,0.35
				c0.37,0.14,0.64,0.25,0.79,0.33c-0.08-0.17-0.18-0.45-0.3-0.86c-0.11-0.37-0.19-0.59-0.26-0.67c-0.11-0.12-0.35-0.2-0.72-0.23
				l-0.09-0.46c0.22-0.04,0.45-0.05,0.7-0.02c0.3,0.03,0.5,0.11,0.6,0.22c0.15,0.17,0.27,0.43,0.37,0.79c0.16,0.58,0.26,0.91,0.29,1
				C356.85,345.16,357.08,345.53,357.39,345.88z M352.89,346.9l0.57-0.04l0.05,0.65l-0.58,0.02L352.89,346.9z M353.13,345.87
				l0.61-0.03l0.05,0.66l0.59-0.02l0.05,0.64l-0.62,0.02l-0.04-0.63l-0.58,0.02L353.13,345.87z" />
                            </g>
                            <g class="map-province-names">
                                <path d="M470.67,142.07c0.66,0.91,0.91,1.83,0.75,2.77c-0.16,0.94-0.69,1.73-1.6,2.39
				c-0.79,0.57-1.62,0.76-2.47,0.56c-0.76-0.18-1.38-0.59-1.85-1.25c-0.42-0.58-0.64-1.25-0.66-2.01l0.72-0.21
				c0.11,0.64,0.29,1.13,0.55,1.49c0.88,1.22,1.94,1.37,3.2,0.46c0.64-0.46,1.03-1,1.17-1.61c0.15-0.64-0.01-1.28-0.46-1.91
				c-0.41-0.57-0.99-0.96-1.74-1.18l0.24-0.98C469.44,140.87,470.16,141.36,470.67,142.07z M466.48,140.72l-0.03,1.17l-1.14,0.04
				l0.01-1.18L466.48,140.72z" />
                                <path d="M475.26,141.47l-0.37,0.26c-0.61,0.44-1.24,0.49-1.88,0.15c-0.43-0.23-0.93-0.7-1.48-1.41
				c-0.2-0.25-0.73-0.95-1.59-2.12c-0.6-0.8-1.24-1.61-1.94-2.42l0.5-0.97c1.26,1.7,2.48,3.31,3.64,4.84c0.38,0.5,0.71,0.84,0.97,1
				c0.44,0.27,0.86,0.26,1.27-0.04l0.24-0.17L475.26,141.47z" />
                                <path d="M474.74,135.27l-0.04,1.03l-1.02-0.01l-0.06,0.93l-1.08,0.01l0.07-1.05l0.99,0.01l0.06-0.9L474.74,135.27z
				 M478.49,139.13l-0.5,0.36c-0.69,0.5-1.32,0.58-1.88,0.25c0.05,0.3,0.01,0.6-0.13,0.9c-0.14,0.3-0.34,0.54-0.59,0.72l-0.5,0.36
				l-0.63-0.88l0.45-0.32c0.29-0.21,0.49-0.46,0.59-0.73c0.12-0.32,0.07-0.62-0.13-0.9l-0.27-0.37l0.49-0.59
				c0.42,0.57,0.8,0.88,1.14,0.93c0.26,0.04,0.59-0.07,0.97-0.35l0.36-0.26L478.49,139.13z" />
                                <path d="M485.64,133.99l-0.37,0.27c-0.58,0.42-1.11,0.49-1.58,0.21c0.02,0.6-0.24,1.1-0.78,1.49
				c-0.48,0.34-0.96,0.38-1.45,0.12c0,0.62-0.27,1.12-0.81,1.51c-0.5,0.36-0.99,0.41-1.47,0.14c0.06,0.57-0.17,1.04-0.68,1.41
				l-0.38,0.27l-0.63-0.88l0.22-0.16c0.66-0.47,0.75-1.03,0.29-1.68l-0.1-0.14l0.43-0.62l0.11,0.15c0.56,0.78,1.09,0.98,1.6,0.61
				c0.35-0.25,0.54-0.5,0.57-0.75c0.04-0.25-0.07-0.55-0.32-0.9l-0.1-0.14l0.42-0.62l0.11,0.15c0.56,0.78,1.09,0.98,1.61,0.61
				c0.59-0.43,0.66-0.96,0.19-1.61l-0.1-0.14l0.41-0.65l0.13,0.18c0.28,0.38,0.52,0.62,0.74,0.72c0.29,0.13,0.61,0.07,0.96-0.18
				l0.35-0.25L485.64,133.99z" />
                                <path d="M488.39,132l-0.37,0.27c-0.52,0.38-1.08,0.38-1.68,0c0.07,0.76-0.16,1.33-0.69,1.71l-0.38,0.27l-0.63-0.88
				l0.2-0.14c0.47-0.34,0.68-0.71,0.63-1.12c-0.04-0.3-0.25-0.71-0.64-1.22l-3.5-4.57l0.49-0.96l3.45,4.78
				c0.88,1.22,1.63,1.61,2.26,1.15l0.24-0.17L488.39,132z" />
                                <path d="M486.69,120.81l0.39,0.64c-0.37,0.58-0.82,1.42-1.35,2.5l-1.29,2.64l-0.31-0.57
				C485.11,123.88,485.96,122.14,486.69,120.81z M487.62,122.01l0.55,1.01c-0.5,0.75-0.99,1.59-1.48,2.5
				c-0.45,0.85-0.74,1.46-0.86,1.83c0.71,0.04,1.25,0.11,1.62,0.21c0.8,0.2,1.39,0.56,1.76,1.07c0.88,1.22,0.58,2.37-0.91,3.44
				l-0.4,0.29l-0.63-0.88l0.68-0.49c0.85-0.62,1.08-1.2,0.69-1.74c-0.34-0.46-1.41-0.76-3.22-0.9c-0.33-0.5-0.46-0.83-0.41-0.99
				C485.59,125.63,486.46,123.85,487.62,122.01z" />
                            </g>
                        </svg>

                    </svg><!-- End svg -->




                </div>
            </figure>
        </div>

    </div>
    <div class="chartRow row">
        <div class="col-md-6 ">
            <figure class="highcharts-figure container-fluid">
				<a id="hyp_news_bohransaz_mosbat" style="cursor: pointer;" data-setting="news_bohransaz_mosbat" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div class='content_container_preload' style="height: 400px" id='news_bohransaz_mosbat'></div>
            </figure>
        </div>
        <div class="col-md-6">
            <figure class="highcharts-figure container-fluid">
				<a id="hyp_news_bohransaz_manfi" style="cursor: pointer;" data-setting="news_bohransaz_manfi" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div class='content_container_preload' style="height: 400px" id='news_bohransaz_manfi'></div>
            </figure>
        </div>
    </div>
    <div class="chartRow row rtl">
        <div class="btn-group col-md-9 btn-group-lg" role="group" aria-label="Large button group">
            <button type="button" id="btnLoadLast_Instagram_Source" onclick="LoadLast_Instagram()" class="btn btn-danger blur">اینستاگرام</button>
            <button type="button" id="btnLoadLast_Telegram_Source" onclick="LoadLast_Telegram()" class="btn btn-danger ">تلگرام</button>
            <button type="button" id="btnLoadLast_Twitter_Source" onclick="LoadLast_Twitter()" class="btn btn-danger blur">توییتر</button>
        </div>
    </div>

    <div class="chartRow container-fluid topChannels rtl">
        <h3 id='tableHead' class="text-center"></h3>
        <table id="table_last" class="table">
            <thead class="thead-dark">
                <tr>
                    <th scope="col">ردیف</th>
                    <th scope="col">لوگو کانال</th>
                    <th scope="col">نام کانال</th>
                    <th scope="col">ID کانال</th>
                    <th scope="col">دنبال کنندگان</th>
                    <th scope="col">پست های مرتبط</th>
                    <th scope="col">بازدید</th>

                </tr>
            </thead>
            <tbody class="">
            </tbody>
        </table>

    </div>
    <div  class="chartRow row" style="margin-bottom: 300px;display:none;">
        <div class="col-md-12 ">
            <figure class="highcharts-figure container-fluid">
				<a id="hyp_newspaper" style="cursor: pointer;" data-setting="newspaper" onclick="changeSetting(this)" class="fa fa-plus-circle"></a>
                <div class='content_container_preload' style="height: 400px;" runat="server" id='newspaper'></div>
            </figure>
        </div>

    </div>

</div>

<div class="description"></div>

<script type="text/javascript">

    var $description = $(".description");

    $(window).ready(function () {

        $("#txt_fromDate").datepicker({ dateFormat: 'yy/mm/dd' });
        $("#txt_toDate").datepicker({ dateFormat: 'yy/mm/dd' });
        LoadData(3);
        getSetting();
    });
    $('.map-path').hover(function () {

        $(this).attr("class", "map-path heyo");
        $description.addClass('active');
        var val = GetMapVal($(this).attr('id'));
        $description.html(val);
    }, function () {
        $description.removeClass('active');
    });

    $('.map-point').hover(function () {

        $(this).attr("class", "map-point heyo");
        $description.addClass('active');
        var val = GetMapVal($(this).attr('id'));

        $description.html(val);
    }, function () {
        $description.removeClass('active');
    });

    $(document).on('mousemove', function (e) {

        $description.css({
            left: e.pageX,
            top: e.pageY - 100
        });

    });
    function GetMapVal(id) {
        id = id.replace("point-", "");
        id = id.replace("path-", "");

        var now = new Date();
        var start = new Date(now.getFullYear(), 0, 0);
        var diff = now - start;
        var oneDay = 1000 * 60 * 60 * 24;
        var day = Math.floor(diff / oneDay);
        var finalVal = 0;
        //if (id == "tehran") {
        //    finalVal = day / 36 * 600;
        //}
        //else if (id == "khorasan-r") {
        //    finalVal = day / 36 * 500;
        //} else {
            finalVal = day / 36 * randomNumberFromRange(1, 100);

        //}
        var ret = "تعداد ماه :  <br/>";
        return ret + parseInt(finalVal);
    }
    function randomNumberFromRange(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }
    function LoadData(counter) {

        ResetHomeCharts();
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
            url: '/Services/Service_DashboardReport.aspx/GetChartDay',
            data: "{'date':" + counter + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (data) {
                if (data.d != null && data.d != '') {

                    $('#txt_fromDate').val(data.d.split(';')[0]);
                    $('#txt_toDate').val(data.d.split(';')[1]);

                    //$("#txt_fromDate").datepicker({ dateFormat: 'yy/mm/dd' });
                    //$("#txt_toDate").datepicker({ dateFormat: 'yy/mm/dd' });






                    LoadCharts();
                }
                else {
                }
            },
            error: function (msg) {

            }
        });
    }
    function LoadCharts() {

        LoadTop_AllNews();
        LoadTop_AllRadio();
        LoadTop_AllVideo();
        LoadTop_AllSocial();


        LoadAll_NewsPaper();
        LoadAll_Website();
        LoadAll_Instagram();
        LoadAll_Twitter();
        LoadAll_Telegram();


        Load_Social_Count_Day();
        Load_TV_Count_All();
        Load_Social_Count_All();
        Load_WebNewspaper_Count_All();

        Load_Hashtag_Top_All();
        Load_Akhbar_Mosbat();
        Load_Akhbar_Manfi();
        Load_By_Jensiat();
        Load_By_JahatGiri();


        Load_Hashtag_Top_Count();


        LoadLast_Telegram();


        Load_CloudChartNews();

        Load_Bohransaz_Mosbat();
        // Load_Bohransaz_Moanfi();
    }
    function ResetHomeCharts() {

        $('#all_newspaper').html('-');
        $('#all_website').html('-');
        $('#all_telegram').html('-');
        $('#all_twitter').html('-');
        $('#all_instagram').html('-');


        $('#all_top_news').html('-');
        $('#all_top_radio').html('-');
        $('#all_top_video').html('-');
        $('#all_top_social').html('-');


        $('.content_container_preload').html('');
        $('.content_container_preload_min').html('');


        $('.table tbody').html('');
        $('#top-twitter').html('');
    }
    function Load_CloudChartNews() {
        var newData = [];
        var newsData = [];
        var newsDataTwitter = [];
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var fd = $("#txt_fromDate").val();
        var td = $("#txt_toDate").val();
        var ft = '';
        var tt = '';
        var k = '';
        var p = $("#<%= hddParmin2.ClientID %>").val();

        //Highcharts.setOptions({
        //    colors: ['#f13a89', '#096ab4', '#13b0d5']
        //});
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_MediaAnalyze_GetHighNumberMedia.ashx?p=" + p + "&f=" + fd + "&t=" + td + "&ft=" + ft + "&tt=" + tt + "&k=" + k,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    for (var j = 0; j < data.NewsCountList.length; j++) {
                        //  newData.push({ 'name': [data.MediaChartList[i].Name], 'y': parseFloat(data.MediaChartList[i].Value) });
                        newsData.push({ 'name': [data.NewsCountList[j].SourceMedia], 'weight': parseFloat(data.NewsCountList[j].CountMedia) });
                        // options.series.push({ 'name': [data.NewsCountList[j].SourceMedia], 'weight': parseFloat(data.NewsCountList[j].CountMedia) });
                    }
                    if (data.TwitterCountList != null && data.TwitterCountList.length > 0) {
                        for (var i = 0; i < data.TwitterCountList.length; i++) {
                            newsDataTwitter.push({ 'name': [data.TwitterCountList[i].SourceMedia], 'weight': parseFloat(data.TwitterCountList[i].CountMedia) });
                        }
                    }

                    var options = {

                        series: [{
                            type: 'wordcloud',
                            data: newsData,
                            name: 'فراوانی',

                        }],

                        rotation: {
                            from: -60,
                            to: 60,
                            orientations: 5
                        },

                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',


                            }

                        },
                        title: {
                            text: 'نمودار ابری توزیع اخبار',
                            fontFamily: 'Conv_BTrafficBold',
                        }





                    };
                    var options2 = {

                        series: [{
                            type: 'wordcloud',
                            data: newsDataTwitter,
                            name: 'فراوانی',

                        }],

                        rotation: {
                            from: -60,
                            to: 60,
                            orientations: 5
                        },

                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',


                            }

                        },
                        title: {
                            text: 'نمودار ابری هشتگ های روز ایران',
                            fontFamily: 'Conv_BTrafficBold',
                        }





                    };
                    //  options.series.push(newData);

                    Highcharts.setOptions({
                        colors: ['#0088CC', '#1DCAFF', '#ee3131', '#ee3131', '#59c020']
                    });
                    $('#CloudChartNews').highcharts(options);
                    $('#CloudChartTwitter').highcharts(options2);
                }
            });
        }
        catch (ex) {


        }

    }
    function Load_Bohransaz_Mosbat() {
        var newsData_Mosbat = [];
        var newsData_Manfi = [];
        var newsData_Mosbat_Val = [];
        var newsData_Manfi_Val = [];

        var fd = $("#txt_fromDate").val();
        var td = $("#txt_toDate").val();
        var ft = '';
        var tt = '';
        var k = '';
        var p = $("#<%= hddParmin2.ClientID %>").val();

        //Highcharts.setOptions({
        //    colors: ['#f13a89', '#096ab4', '#13b0d5']
        //});
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Part_MediaAnalyze_GetHighNumberMedia.ashx?p=" + p + "&f=" + fd + "&t=" + td + "&ft=" + ft + "&tt=" + tt + "&k=" + k,
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var max = 10;
                    for (var j = 0; j < data.NewsCountList.length; j++) {
                        if (j < max) {
                            //  newData.push({ 'name': [data.MediaChartList[i].Name], 'y': parseFloat(data.MediaChartList[i].Value) });
                            newsData_Mosbat.push(data.NewsCountList[j].SourceMedia);
                            newsData_Mosbat_Val.push(parseFloat(data.NewsCountList[j].CountMedia));
                        }
                        else {
                            if (j < max * 2) {
                                newsData_Manfi.push(data.NewsCountList[j].SourceMedia);
                                newsData_Manfi_Val.push(parseFloat(data.NewsCountList[j].CountMedia));
                            }
                        }
                        // options.series.push({ 'name': [data.NewsCountList[j].SourceMedia], 'weight': parseFloat(data.NewsCountList[j].CountMedia) });
                    }


                    var options = {

                        chart: {
                            inverted: true,
                            polar: false
                        },
                        title: {
                            text: 'رسانه های هم سو'
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            categories: newsData_Mosbat
                        },
                        legend: {
                            enabled: false
                        },
                        series: [{
                            type: 'column',
                            colorByPoint: true,
                            data: newsData_Mosbat_Val,
                            showInLegend: false
                        }]





                    };
                    var options2 = {

                        chart: {
                            inverted: true,
                            polar: false
                        },
                        title: {
                            text: 'رسانه های بحران ساز'
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            categories: newsData_Manfi
                        },
                        series: [{
                            type: 'column',
                            colorByPoint: true,
                            data: newsData_Manfi_Val,
                            showInLegend: false
                        }]




                    };
                    //  options.series.push(newData);

                    Highcharts.setOptions({
                        colors: ['#2fd075']
                    });
                    $('#news_bohransaz_mosbat').highcharts(options);
                    Highcharts.setOptions({
                        colors: ['#d02f2f']
                    });
                    $('#news_bohransaz_manfi').highcharts(options2);
                }
            });
        }
        catch (ex) {


        }

    }
    function LoadTop_AllNews() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminTop_AllNews',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null) {

                        if (data.d > 0) {
                            $('#all_top_news').parent().children('.arrow_zero').hide();
                            $('#all_top_news').parent().children('.arrow').show();

                        }
                        else {
                            $('#all_top_news').parent().children('.arrow').hide();
                            $('#all_top_news').parent().children('.arrow_zero').show();

                        }
                        $('#all_top_news').text(data.d);
                        $('#all_top_news').attr("class", "count animate__animated animate__heartBeat");




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







    function LoadTop_AllRadio() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminTop_AllRadio',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null) {
                        if (data.d > 0) {
                            $('#all_top_radio').parent().children('.arrow_zero').hide();
                            $('#all_top_radio').parent().children('.arrow').show();

                        }
                        else {
                            $('#all_top_radio').parent().children('.arrow').hide();
                            $('#all_top_radio').parent().children('.arrow_zero').show();

                        }
                        $('#all_top_radio').text(data.d);
                        $('#all_top_radio').attr("class", "count animate__animated animate__heartBeat");




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
    function LoadTop_AllVideo() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminTop_AllVideo',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null) {

                        if (data.d > 0) {
                            $('#all_top_video').parent().children('.arrow_zero').hide();
                            $('#all_top_video').parent().children('.arrow').show();

                        }
                        else {
                            $('#all_top_video').parent().children('.arrow').hide();
                            $('#all_top_video').parent().children('.arrow_zero').show();

                        }
                        $('#all_top_video').text(data.d);
                        $('#all_top_video').attr("class", "count animate__animated animate__heartBeat");




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
    function LoadTop_AllSocial() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminTop_AllSocial',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null) {

                        if (data.d > 0) {
                            $('#all_top_social').parent().children('.arrow_zero').hide();
                            $('#all_top_social').parent().children('.arrow').show();

                        }
                        else {
                            $('#all_top_social').parent().children('.arrow').hide();
                            $('#all_top_social').parent().children('.arrow_zero').show();

                        }
                        $('#all_top_social').text(data.d);
                        $('#all_top_social').attr("class", "count animate__animated animate__heartBeat");




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


    function LoadAll_NewsPaper() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminAll_Count_Newspaper',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {

                        $('#all_newspaper').text(data.d);
                        $('#all_newspaper').attr("class", "count animate__animated animate__heartBeat");




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
    function LoadAll_Website() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminAll_Count_Website',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {

                        $('#all_website').text(data.d);
                        $('#all_website').attr("class", "count animate__animated animate__heartBeat");




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
    function LoadAll_Instagram() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminAll_Count_Instagram',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {

                        $('#all_instagram').text(data.d);
                        $('#all_instagram').attr("class", "count animate__animated animate__heartBeat");




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
    function LoadAll_Twitter() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminAll_Count_Twitter',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {

                        $('#all_twitter').text(data.d);
                        $('#all_twitter').attr("class", "count animate__animated animate__heartBeat");




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
    function LoadAll_Telegram() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminAll_Count_Telegram',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {

                        $('#all_telegram').text(data.d);
                        $('#all_telegram').attr("class", "count animate__animated animate__heartBeat");




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
    function LoadLast_Instagram() {
        $('#btnLoadLast_Instagram_Source').removeClass('blur');
        $('#btnLoadLast_Twitter_Source').removeClass('blur');
        $('#btnLoadLast_Telegram_Source').removeClass('blur');

        $('#btnLoadLast_Instagram_Source').addClass('blur');
        $('#btnLoadLast_Twitter_Source').addClass('blur');
        $('#btnLoadLast_Telegram_Source').addClass('blur');

        $('#btnLoadLast_Instagram_Source').removeClass('blur');

    }
    function LoadLast_Twitter() {

        $('#btnLoadLast_Instagram_Source').removeClass('blur');
        $('#btnLoadLast_Twitter_Source').removeClass('blur');
        $('#btnLoadLast_Telegram_Source').removeClass('blur');

        $('#btnLoadLast_Instagram_Source').addClass('blur');
        $('#btnLoadLast_Twitter_Source').addClass('blur');
        $('#btnLoadLast_Telegram_Source').addClass('blur');


        $('#btnLoadLast_Twitter_Source').removeClass('blur');

        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var parmin = $("#<%= hddParmin.ClientID %>").val();
        var parmin2 = $("#<%= hddParmin2.ClientID %>").val();
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Part_LoadLast_Twitter_Source.ashx?count=10&fromDate=' + fromDate + '&toDate=' + toDate + '&p=' + parmin,    // '/Services/Service_DashboardReport.aspx/LoadLast_Twitter_Source'
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {

                        $('#tableHead').html('فعال ترین کانال های پیام رسان توییتر');
                        $('.table tbody').html('');
                        $.each(data.d, function (index) {
                            /// do stuff
                            // alert((data.d[index].SourceMedia));
                            //  data.d[index];
                            $('.table tbody').append('<tr>');


                            $('.table tbody').append("<td scope='row'>" + (index + 1) + "</td>");
                            $('.table tbody').append("<td></td>");
                            $('.table tbody').append("<td>" + (data.d[index].SourceMedia) + "</td>");
                            $('.table tbody').append("<td class='ltr'>" + (data.d[index].ChannelID) + "</td>");
                            $('.table tbody').append("<td></td>");
                            $('.table tbody').append("<td>" + (data.d[index].CountMedia) + "</td>");
                            $('.table tbody').append("<td></td>");


                            $('.table tbody').append('</tr>');


                        });

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
    function LoadLast_Telegram() {

        $('#btnLoadLast_Instagram_Source').removeClass('blur');
        $('#btnLoadLast_Twitter_Source').removeClass('blur');
        $('#btnLoadLast_Telegram_Source').removeClass('blur');

        $('#btnLoadLast_Instagram_Source').addClass('blur');
        $('#btnLoadLast_Twitter_Source').addClass('blur');
        $('#btnLoadLast_Telegram_Source').addClass('blur');


        $('#btnLoadLast_Telegram_Source').removeClass('blur');

        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        var parmin = $("#<%= hddParmin.ClientID %>").val();
        //alert(toDate);
        try {
            $.ajax({
                type: "GET",
                url: '/Services/Part_LoadLast_Telegram_Source.ashx?count=10&fromDate=' + fromDate + '&toDate=' + toDate + '&p=' + parmin,    // '/Services/Service_DashboardReport.aspx/LoadLast_Telegram_Source'
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    console.log(data);
                    //  console.log(data.d);
                    //  if (data.d != null && data.d != '') {

                    $('#tableHead').html('فعال ترین کانال های پیام رسان تلگرام');
                    $('.table tbody').html('');
                    // $.each(data, function (i, state) {
                    $.each(data, function (i, item) {
                        /// do stuff
                        // alert((data.d[index].SourceMedia));
                        //  data.d[index];
                        $('.table tbody').append('<tr>');


                        $('.table tbody').append("<td scope='row'>" + (i + 1) + "</td>");
                        $('.table tbody').append("<td></td>");
                        $('.table tbody').append("<td>" + (item.SourceMedia) + "</td>");
                        $('.table tbody').append("<td class='ltr'>" + (item.ChannelID) + "</td>");
                        $('.table tbody').append("<td></td>");
                        $('.table tbody').append("<td>" + (item.CountMedia) + "</td>");
                        $('.table tbody').append("<td></td>");


                        $('.table tbody').append('</tr>');


                    });

                    // }
                    // else {
                    // }
                },
                error: function (msg) {

                }
            });
        }
        catch (ex) {

        }
    }

    function LoadAll_Count() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetParminAll_ByMedia',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {
                        var paper = data.d.split(',')[0];
                        var news = data.d.split(',')[1];
                        var insta = data.d.split(',')[2];
                        var twitter = data.d.split(',')[3];
                        var telegram = data.d.split(',')[4];
                        $('#all_newspaper').text(paper);
                        $('#all_newspaper').attr("class", "count animate__animated animate__heartBeat");

                        $('#all_website').text(news);
                        $('#all_website').attr("class", "count animate__animated animate__heartBeat");

                        $('#all_telegram').text(telegram);
                        $('#all_telegram').attr("class", "count animate__animated animate__heartBeat");

                        $('#all_twitter').text(twitter);
                        $('#all_twitter').attr("class", "count animate__animated animate__heartBeat");

                        $('#all_insta').text(insta);
                        $('#all_insta').attr("class", "count animate__animated animate__heartBeat");


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

    function Load_Social_Count_Day() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");

        //Highcharts.setOptions({
        //    colors: ['#f13a89', '#096ab4', '#13b0d5']
        //});
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Service_DashboardReport.aspx/Social_Count_Day",
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {



                    var json = data.d;
                    var len = json.length
                    i = 0;
                    var options = {
                        chart: {
                            type: 'spline'
                        },

                        legend: {
                            symbolWidth: 40
                        },

                        title: {
                            text: 'تعداد روزانه اخبار در شبکه های اجتماعی'
                        },

                        subtitle: {
                            text: ''
                        },

                        yAxis: {
                            title: {
                                text: 'تعداد خبر'
                            }
                        },

                        xAxis: {
                            title: {
                                text: ''
                            },
                            accessibility: {
                                description: ''
                            },
                            categories: []
                        },

                        tooltip: {
                        },

                        plotOptions: {
                            series: {
                                point: {
                                    events: {
                                        click: function () {
                                            //window.location.href = this.series.options.website;
                                        }
                                    }
                                },
                                cursor: 'pointer'
                            }
                        },
                        series: [],



                    };
                    for (i; i < len; i++) {

                        if (i === 0) {
                            var dat = json[i].data,
                                lenJ = dat.length,
                                j = 0,
                                tmp;

                            for (j; j < lenJ; j++) {
                                tmp = dat[j].split(';');
                                options.xAxis.categories.push(tmp[0]);

                            }
                            options.series = [];
                        }
                        else {
                            options.series.push(json[i]);

                        }
                    }
                    Highcharts.setOptions({
                        colors: ['#0088CC', '#1DCAFF', '#ee3131', '#ee3131', '#59c020']
                    }); $('#container-social-count-day').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
    function Load_TV_Count_All() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");

        //Highcharts.setOptions({
        //    colors: ['#f13a89', '#096ab4', '#13b0d5']
        //});
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Service_DashboardReport.aspx/TV_Count_All",
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    DataCategory = [];
                    DataSeries = [];

                    for (var i = 0; i < data.d.length; i++) {

                        DataCategory.push([data.d[i].name]);
                        DataSeries.push([data.d[i].name, parseInt(data.d[i].data), false]);
                    }

                    var json = data.d;
                    var len = json.length
                    i = 0;
                    var options = {

                        chart: {
                            type: 'pie',

                        },


                        title: {
                            useHTML: true,
                            text: 'به تفکیک شبکه های تلویزیونی'
                        },

                        xAxis: {
                            useHTML: true,
                            categories: DataCategory
                        },

                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                useHTML: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    useHTML: true,
                                    format: '<b>{point.name}</b><br>{point.percentage:.1f} %',
                                    distance: -50,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 4
                                    }
                                }
                            }
                        },
                        //series: [],
                        series: [{
                            type: 'pie',
                            allowPointSelect: true,
                            keys: ['name', 'y', 'selected', 'sliced'],
                            data: DataSeries,
                            showInLegend: true
                        }]
                    };
                    Highcharts.setOptions({
                        colors: ['#ce29ff', '#e33939', '#252629', '#27bc55', '#00c2ff', '#00c2ff', '#d8a328', '#096ab4', '#13b0d5']
                    });
                    $('#container-tv').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
    function Load_Social_Count_All() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");

        //Highcharts.setOptions({
        //    colors: ['#f13a89', '#096ab4', '#13b0d5']
        //});
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Service_DashboardReport.aspx/Social_Count_All",
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    DataCategory = [];
                    DataSeries = [];

                    for (var i = 0; i < data.d.length; i++) {

                        DataCategory.push([data.d[i].name]);
                        DataSeries.push([data.d[i].name, parseInt(data.d[i].data), false]);
                    }

                    var json = data.d;
                    var len = json.length
                    i = 0;
                    var options = {

                        chart: {
                            type: 'pie',

                        },


                        title: {
                            useHTML: true,
                            text: 'به تفکیک شبکه های اجتماعی'

                        },

                        xAxis: {
                            useHTML: true,
                            categories: DataCategory
                        },

                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                useHTML: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    useHTML: true,
                                    format: '<b>{point.name}</b><br>{point.percentage:.1f} %',
                                    distance: -50,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 4
                                    }
                                }
                            }
                        },
                        //series: [],
                        series: [{
                            type: 'pie',
                            allowPointSelect: true,
                            keys: ['name', 'y', 'selected', 'sliced'],
                            data: DataSeries,
                            showInLegend: true
                        }]
                    };

                    Highcharts.setOptions({
                        colors: ['#0088CC', '#1DCAFF', '#ee3131', '#ee3131', '#59c020']
                    }); $('#container-social').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
    function Load_WebNewspaper_Count_All() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");

        //Highcharts.setOptions({
        //    colors: ['#f13a89', '#096ab4', '#13b0d5']
        //});
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Service_DashboardReport.aspx/WebNewspaper_Count_All",
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    DataCategory = [];
                    DataSeries = [];

                    for (var i = 0; i < data.d.length; i++) {

                        DataCategory.push([data.d[i].name]);
                        DataSeries.push([data.d[i].name, parseInt(data.d[i].data), false]);
                    }

                    var json = data.d;
                    var len = json.length
                    i = 0;
                    var options = {

                        chart: {
                            type: 'pie',

                        },


                        title: {
                            useHTML: true,
                            text: 'به تفکیک سایت ها و روزنامه ها'
                        },

                        xAxis: {
                            useHTML: true,
                            categories: DataCategory
                        },

                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                useHTML: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    useHTML: true,
                                    format: '<b>{point.name}</b><br>{point.percentage:.1f} %',
                                    distance: -50,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 4
                                    }
                                }
                            }
                        },
                        //series: [],
                        series: [{
                            type: 'pie',
                            allowPointSelect: true,
                            keys: ['name', 'y', 'selected', 'sliced'],
                            data: DataSeries,
                            showInLegend: true
                        }]
                    };

                    Highcharts.setOptions({
                        colors: ['#0066ff', '#ffb300']
                    }); $('#container-news-online').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
    function Load_Hashtag_Top_All() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");

        //Highcharts.setOptions({
        //    colors: ['#f13a89', '#096ab4', '#13b0d5']
        //});
        try {
            $.ajax({
                type: "POST",
                url: "/Services/Service_DashboardReport.aspx/Hashtag_Top_All",
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "'}",

                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    DataCategory = [];
                    DataSeries = [];

                    for (var i = 0; i < data.d.length; i++) {

                        DataCategory.push([data.d[i].name]);
                        DataSeries.push([data.d[i].name, parseInt(data.d[i].data), false]);
                    }

                    var json = data.d;
                    var len = json.length
                    i = 0;
                    var options = {
                        chart: {
                            type: 'pie',
                            options3d: {
                                enabled: true,
                                alpha: 45
                            }
                        },
                        title: {
                            text: 'هشتگ های برتر'
                        },
                        subtitle: {
                            text: ''
                        },


                        plotOptions: {
                            pie: {
                                innerSize: 100,
                                depth: 45,
                                allowPointSelect: true,
                                useHTML: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,

                                    useHTML: true,
                                    format: '<b>{point.name}</b><br>{point.percentage:.1f} %',
                                    distance: -50,
                                    filter: {
                                        property: 'percentage',
                                        operator: '>',
                                        value: 4
                                    }
                                }
                            }
                        },
                        legend: {
                            //  layout: 'vertical',
                            align: 'center',
                            verticalAlign: 'bottom',
                            // itemMarginTop: 10,
                            // itemMarginBottom: 10
                        },
                        series: [{
                            name: 'هشتگ های برتر',
                            data: DataSeries,
                            showInLegend: true

                        }]
                    };

                    Highcharts.setOptions({
                        colors: ['#961f7b', '#e24bc6', '#6948ee', '#0066ff', '#ffb300']
                    });
                    $('#container-top-hashtag').highcharts(options);
                }
            });
        }
        catch (ex) {


        }
    }
    function Load_Akhbar_Mosbat() {
        Highcharts.chart('container-sugiri-webnewspaper-mosbat', {
            chart: {
                type: 'area'
            },
            accessibility: {
                description: ''
            },
            title: {
                text: 'رسانه ها بر اساس سوگیری اخبار - مثبت'
            },
            subtitle: {
                text: ''
            },
            xAxis: {
                allowDecimals: false,
                useHTML: true,
                labels: {
                    formatter: function () {
                        //  return this.value; // clean, unformatted number for year
                    }
                },
                accessibility: {
                    rangeDescription: 'در یک ماه گذشته'
                }
            },
            yAxis: {
                title: {
                    useHTML: true,
                    text: 'تعداد خبر'
                },
                labels: {
                    useHTML: true,
                    formatter: function () {
                        return this.value;
                    }
                }
            },
            tooltip: {
                useHTML: true,
                //  pointFormat: '{series.name}   <b>{point.y:,.0f}</b><br/>  {point.x}'
                pointFormat: ' <b>{point.y:,.0f}</b><br/> '
            },
            plotOptions: {
                area: {
                    // pointStart: 1940,
                    marker: {
                        enabled: false,
                        useHTML: true,
                        symbol: 'circle',
                        radius: 2,
                        useHTML: true,
                        states: {
                            hover: {
                                enabled: true
                            }
                        }
                    }
                }
            },
            series: [{
                name: 'فارس',
                data: [
                    56, 54, 21, 45, 69, 25, 33, 11

                ]
            },

            {
                name: 'ایرنا',
                data: [
                    15, 31, 21, 45, 69, 25, 33, 11

                ]
            },
            {
                name: 'دولت',
                data: [
                    10, 34, 12, 45, 69, 25, 5, 11
                ]
            },
            {
                name: 'تسنیم',
                data: [11, 33, 25, 21, 5, 13, 32, 13

                ]
            }]

        });
    }
    function Load_Akhbar_Manfi() {
        Highcharts.setOptions({
            colors: ['#0066ff', '#ffb300']
        });
        Highcharts.chart('container-sugiri-webnewspaper-manfi', {
            chart: {
                type: 'area'
            },
            accessibility: {
                description: ''
            },
            title: {
                text: 'رسانه ها بر اساس سوگیری اخبار - منفی'
            },
            subtitle: {
                text: ''
            },
            xAxis: {
                allowDecimals: false,
                labels: {
                    formatter: function () {
                        // return this.value; // clean, unformatted number for year
                    }
                },
                accessibility: {
                    rangeDescription: 'در یک ماه گذشته'
                }
            },
            yAxis: {
                title: {
                    text: 'تعداد خبر'
                },
                labels: {
                    formatter: function () {
                        return this.value;
                    }
                }
            },
            tooltip: {
                useHTML: true,
                pointFormat: ' <b>{point.y:,.0f}</b><br/> '
            },
            plotOptions: {
                area: {
                    // pointStart: 1940,
                    marker: {
                        enabled: false,
                        symbol: 'circle',
                        radius: 2,
                        states: {
                            hover: {
                                enabled: true
                            }
                        }
                    }
                }
            },
            series: [{
                name: 'فارس',
                data: [
                    56, 54, 21, 45, 69, 25, 33, 11
                ]
            },

            {
                name: 'ایرنا',
                data: [
                    11, 33, 25, 21, 5, 13, 32, 13
                ]
            },
            {
                name: 'دولت',
                data: [
                    10, 34, 12, 45, 69, 25, 5, 11
                ]
            },
            {
                name: 'تسنیم',
                data: [15, 31, 21, 45, 69, 25, 33, 11]
            }]

        });
    }
    function Load_By_Jensiat() {
        Highcharts.setOptions({
            colors: ['#ff00f7', '#f6234d', '#ffb300', '#961f7b', '#e24bc6']
        });
        Highcharts.chart('container-jensiat', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: 0,
                plotShadow: false
            },
            title: {
                text: 'به تفکیک جنسیت',
                align: 'center',
                verticalAlign: 'middle',
                y: 60
            },
            tooltip: {
                useHtml: true,
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            accessibility: {
                point: {
                    valueSuffix: '%'
                }
            },
            plotOptions: {
                pie: {
                    useHTML: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        useHtml: true,
                        distance: -50,
                        //color:'#fff',
                        style: {
                            //useHtml: true,
                        }
                    },
                    useHtml: true,
                    startAngle: -90,
                    endAngle: 90,
                    center: ['50%', '75%'],
                    size: '110%'
                }
            },
            series: [{
                type: 'pie',
                showInLegend: true,
                useHtml: true,
                name: 'برحسب جنسیت : ',
                innerSize: '50%',
                data: [
                    ['مرد', 60.9],
                    ['زن', 39.1],


                ]
            }]
        });
    }
    function Load_By_JahatGiri() {
        Highcharts.setOptions({
            colors: ['#00c2ff', '#d8a328', '#096ab4', '#13b0d5']
        });
        Highcharts.chart('container-news-mosbat-manfi', {

            chart: {
                type: 'pie',

            },


            title: {
                useHTML: true,
                text: 'به تفکیک اخبار مثبت و منفی'
            },

            xAxis: {
                useHTML: true,
                categories: ['منفی', 'مثبت']
            },

            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    useHTML: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: true,
                        useHTML: true,
                        format: '<b>{point.name}</b><br>{point.percentage:.1f} %',
                        distance: -50,
                        filter: {
                            property: 'percentage',
                            operator: '>',
                            value: 4
                        }
                    }
                }
            },
            series: [{
                type: 'pie',
                allowPointSelect: true,
                keys: ['name', 'y', 'selected', 'sliced'],
                data: [
                    ['مثبت ', 10.9, false],
                    ['منفی ', 20.9, false],



                ],
                showInLegend: true
            }]
        });
    }

    function Load_Hashtag_Top_Count() {
        var fromDate = $('#txt_fromDate').val().replace("/", "").replace("/", "");
        var toDate = $('#txt_toDate').val().replace("/", "").replace("/", "");
        //alert(toDate);
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/Hashtag_Top_Count',
                data: "{'fromDate':'" + fromDate + "','toDate':'" + toDate + "','count':3}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null && data.d != '') {

                        var html = '';
                        for (var i = 0; i < data.d.length; i++) {
                            var imageProfile = '';
                            imageProfile = '<img src="' + data.d[i].UserProfileImageUrl + '" />';
                            //UrlExists(data.d[i].UserProfileImageUrl, function (status) {
                            //    console.log(status);
                            //    if (status === 200) {
                            //        // file was found
                            //        imageProfile = '<img src="' + data.d[i].UserProfileImageUrl + '" />'
                            //    }
                            //    else if (status === 404) {
                            //        // 404 not found
                            //        imageProfile = '<i class="fa fa-twitter" ></i>';
                            //    }
                            //});
                            var media = ''
                            if (data.d[i].MediaUrl != '' && data.d[i].MediaUrl != '') {

                                var media = "<div class='tweet-media'><img src='" + data.d[i].MediaUrl + "'/></div>";
                                //  $('.tweet-post').html(data.d[0].Text + media);

                            }
                            else {
                            }
                            //  DataCategory.push([data.d[i].name]);
                            //  DataSeries.push([data.d[i].name, parseInt(data.d[i].data), false]);
                            html += ' <div class="twitter-post">' +
                                '<h2> پست برتر</h2>' +
                                '<header class="clearfix">' +
                                '<div class="tweet-user">' +
                                '<span>' + data.d[i].UserName + '</span>' +
                                '<abbr>@' + data.d[i].UserScreenName + '</abbr>' +
                                '</div>' +
                                '<div class="tweet-pic">' +
                                '<a href="#">' +
                                imageProfile +
                                //'<img src="' + data.d[i].UserProfileImageUrl + '" />' +
                                '</a>' +
                                '</div>' +

                                '</header>' +
                                '<figure>' +

                                '<div class="tweet-post">' + data.d[i].Text + media + '</div>' +
                                '</figure>' +
                                '<footer>' +
                                '<div class="tweet-time">' +
                                data.d[i].Date + " - " + data.d[i].Time +
                                '</div>' +
                                '<div class="tweet-feedback">' +
                                '<span class="retweet">' + data.d[i].RetweetCount + '</span><abbr>Retweets</abbr>' +
                                '<span class="like">' + data.d[i].FavoriteCount + '</span><abbr>Like</abbr>' +
                                '</div>' +
                                '</footer>' +

                                '</div>';
                        }
                        $('#top-twitter').html(html);


                        LoadSlider();
                        // LoadSlick();

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
    function LoadSlick() {
        // $('#top-twitter').slick();
        //$('#top-twitter').slick({
        //    dots: false,
        //    infinite: true,
        //    rtl: true,

        //    slidesToShow: 1,
        //});
        $('#top-twitter').bxSlider({
            //  mode: 'fade',
            auto: true,
            pager: false,
            captions: false,
            // slideWidth: 600
        });
    }
    var delay = 250000000; //2 seconds
    var tid;
    var slideCount;
    var currentSlider = 0;
    function LoadSlider() {

        slideCount = $('.twitter-post').length - 1;
        if (slideCount > 0) {
            $('#slidePaging_next').fadeIn();
            $('#slidePaging_prev').fadeIn();
            $('#slidePaging_next').attr('data-pos', 1);
            $('#slidePaging_prev').attr('data-pos', slideCount);
            SetupSlider();
        }
    }
    function DoSlide() {

        clearTimeout(tid);

        $('.twitter-post').css({ 'display': 'none' });
        $('.twitter-post').eq(currentSlider).fadeIn();


        tid = setTimeout(DoSlide, delay);
    }

    function SetupSlider() {
        //count
        //run
        tid = setTimeout(DoSlide, 1);


    }
    function Slide_Next() {
        clearTimeout(tid);
        currentSlider += 1;

        if (currentSlider > slideCount) {
            currentSlider = 0;
        }

        var next = currentSlider + 1;
        if (next > slideCount) {
            next = 0;
        }
        var prev = currentSlider - 1;
        if (prev == -1) {
            prev = slideCount;
        }
        $('#slidePaging_next').attr('data-pos', next);
        $('#slidePaging_prev').attr('data-pos', prev);

        $('.twitter-post').css({ 'display': 'none' });
        $('.twitter-post').eq(currentSlider).fadeIn();



        // alert("123");
        tid = setTimeout(DoSlide, delay);
    }
    function Slide_Prev() {
        clearTimeout(tid);

        currentSlider -= 1;
        if (currentSlider < 0) {
            currentSlider = slideCount;
        }
        var next = currentSlider + 1;
        if (next > slideCount) {
            next = 0;
        }
        var prev = currentSlider - 1;
        if (prev < 0) {
            prev = slideCount;
        }

        $('#slidePaging_next').attr('data-pos', next);
        $('#slidePaging_prev').attr('data-pos', prev);

        //currentSlider = $(this).index();
        // $('.slidePaging a').removeClass('active');
        //  $('.slidePaging a').eq(currentSlider).addClass('active');
        $('.twitter-post').css({ 'display': 'none' });
        $('.twitter-post').eq(currentSlider).fadeIn();
        //LoadScanImage($('.twitter-post').eq(currentSlider));



        // alert("123");
        tid = setTimeout(DoSlide, delay);
    }
    function UrlExists(url, cb) {
        jQuery.ajax({
            url: url,
            dataType: 'text',
            type: 'GET',
            complete: function (xhr) {
                if (typeof cb === 'function')
                    cb.apply(this, [xhr.status]);
            }
        });
    }
    function changeSetting(element) {
        var $this = $(element);
        var stg = $this.attr('data-setting');
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/ChangeSetting',
                data: "{'setting':'" + stg + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    console.log(data);
                    if (data.d != null) {
                        if (data.d == 1) {
                            console.log('if ' + data.d);
                            $this.removeClass();
                            $this.attr("class", "animate__animated animate__heartBeat fa fa-minus-circle");
                        }
                        else {
                            console.log('else ' + data.d);
                            $this.removeClass();
                            $this.attr("class", "animate__animated animate__heartBeat fa fa-plus-circle");
                        }
                    }
                    else {
                        console.log('else 2 ' + data.d);
                        $this.removeClass();
                        $this.attr("class", "animate__animated animate__heartBeat fa fa-minus-circle");
                    }
                },
                error: function (msg) {

                }
            });
        }
        catch (ex) {

        }


    }
    function getSetting() {
        try {
            $.ajax({
                type: "POST",
                url: '/Services/Service_DashboardReport.aspx/GetSetting',
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {
                    if (data.d != null) {
                        $.each(data.d, function (i, item) {
                            console.log(item);
                            var SettingTitle = item.SettingTitle;
                            var SettingValue = item.SettingValue;
                            if (SettingTitle === 'all_top_news') {
                                if (SettingValue === '0') {
									$("#hyp_all_top_news").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_news").removeClass("fa fa-minus-circle");
                                    $("#hyp_all_top_news").addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_top_news").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_news").removeClass("fa fa-minus-circle");
                                    $("#hyp_all_top_news").addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'all_top_radio') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_top_radio").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_radio").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_top_radio').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_top_radio").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_radio").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_top_radio').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'all_top_video') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_top_video").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_video").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_top_video').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_top_video").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_video").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_top_video').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'all_top_social') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_top_social").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_social").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_top_social').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_top_social").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_top_social").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_top_social').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }

                            if (SettingTitle === 'all_instagram') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_instagram").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_instagram").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_instagram').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_instagram").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_instagram").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_instagram').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'all_twitter') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_twitter').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_twitter').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'all_telegram') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_telegram").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_telegram").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_telegram').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_telegram").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_telegram").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_telegram').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'all_website') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_website").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_website").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_website').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_website").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_website").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_website').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'all_newspaper') {
                                if (SettingValue === '0') {
                                    $("#hyp_all_newspaper").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_newspaper").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_newspaper').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_all_newspaper").removeClass("fa fa-plus-circle");
                                    $("#hyp_all_newspaper").removeClass("fa fa-minus-circle");
                                    $('#hyp_all_newspaper').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }

                            if (SettingTitle === 'social_count_day') {
                                if (SettingValue === '0') {
                                    $("#hyp_social_count_day").removeClass("fa fa-plus-circle");
                                    $("#hyp_social_count_day").removeClass("fa fa-minus-circle");
                                    $('#hyp_social_count_day').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_social_count_day").removeClass("fa fa-plus-circle");
                                    $("#hyp_social_count_day").removeClass("fa fa-minus-circle");
                                    $('#hyp_social_count_day').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'tafkik_news_online') {
                                if (SettingValue === '0') {
                                    $("#hyp_tafkik_news_online").removeClass("fa fa-plus-circle");
                                    $("#hyp_tafkik_news_online").removeClass("fa fa-minus-circle");
                                    $('#hyp_tafkik_news_online').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_tafkik_news_online").removeClass("fa fa-plus-circle");
                                    $("#hyp_tafkik_news_online").removeClass("fa fa-minus-circle");
                                    $('#hyp_tafkik_news_online').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'tafkik_social') {
                                if (SettingValue === '0') {
                                    $("#hyp_tafkik_social").removeClass("fa fa-plus-circle");
                                    $("#hyp_tafkik_social").removeClass("fa fa-minus-circle");
                                    $('#hyp_tafkik_social').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_tafkik_social").removeClass("fa fa-plus-circle");
                                    $("#hyp_tafkik_social").removeClass("fa fa-minus-circle");
                                    $('#hyp_tafkik_social').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'tafkik_tv') {
                                if (SettingValue === '0') {
                                    $("#hyp_tafkik_tv").removeClass("fa fa-plus-circle");
                                    $("#hyp_tafkik_tv").removeClass("fa fa-minus-circle");
                                    $('#hyp_tafkik_tv').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_tafkik_tv").removeClass("fa fa-plus-circle");
                                    $("#hyp_tafkik_tv").removeClass("fa fa-minus-circle");
                                    $('#hyp_tafkik_tv').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'top_hashtag') {
                                if (SettingValue === '0') {
                                    $("#hyp_top_hashtag").removeClass("fa fa-plus-circle");
                                    $("#hyp_top_hashtag").removeClass("fa fa-minus-circle");
                                    $('#hyp_top_hashtag').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_top_hashtag").removeClass("fa fa-plus-circle");
                                    $("#hyp_top_hashtag").removeClass("fa fa-minus-circle");
                                    $('#hyp_top_hashtag').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'jensiat') {
                                if (SettingValue === '0') {
                                    $("#hyp_jensiat").removeClass("fa fa-plus-circle");
                                    $("#hyp_jensiat").removeClass("fa fa-minus-circle");
                                    $('#hyp_jensiat').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_jensiat").removeClass("fa fa-plus-circle");
                                    $("#hyp_jensiat").removeClass("fa fa-minus-circle");
                                    $('#hyp_jensiat').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'news_mosbat_manfi') {
                                if (SettingValue === '0') {
                                    $("#hyp_news_mosbat_manfi").removeClass("fa fa-plus-circle");
                                    $("#hyp_news_mosbat_manfi").removeClass("fa fa-minus-circle");
                                    $('#hyp_news_mosbat_manfi').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_news_mosbat_manfi").removeClass("fa fa-plus-circle");
                                    $("#hyp_news_mosbat_manfi").removeClass("fa fa-minus-circle");
                                    $('#hyp_news_mosbat_manfi').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'top_twitter') {
                                if (SettingValue === '0') {
                                    $("#hyp_top_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_top_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_top_twitter').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_top_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_top_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_top_twitter').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'sugiri_webnewspaper_mosbat') {
                                if (SettingValue === '0') {
                                    $("#hyp_sugiri_webnewspaper_mosbat").removeClass("fa fa-plus-circle");
                                    $("#hyp_sugiri_webnewspaper_mosbat").removeClass("fa fa-minus-circle");
                                    $('#hyp_sugiri_webnewspaper_mosbat').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_sugiri_webnewspaper_mosbat").removeClass("fa fa-plus-circle");
                                    $("#hyp_sugiri_webnewspaper_mosbat").removeClass("fa fa-minus-circle");
                                    $('#hyp_sugiri_webnewspaper_mosbat').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'sugiri_webnewspaper_manfi') {
                                if (SettingValue === '0') {
                                    $("#hyp_sugiri_webnewspaper_manfi").removeClass("fa fa-plus-circle");
                                    $("#hyp_sugiri_webnewspaper_manfi").removeClass("fa fa-minus-circle");
                                    $('#hyp_sugiri_webnewspaper_manfi').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_sugiri_webnewspaper_manfi").removeClass("fa fa-plus-circle");
                                    $("#hyp_sugiri_webnewspaper_manfi").removeClass("fa fa-minus-circle");
                                    $('#hyp_sugiri_webnewspaper_manfi').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'cloud_chart_twitter') {
                                if (SettingValue === '0') {
                                    $("#hyp_cloud_chart_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_cloud_chart_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_cloud_chart_twitter').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_cloud_chart_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_cloud_chart_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_cloud_chart_twitter').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'cloud_chart_news') {
                                if (SettingValue === '0') {
                                    $("#hyp_cloud_chart_news").removeClass("fa fa-plus-circle");
                                    $("#hyp_cloud_chart_news").removeClass("fa fa-minus-circle");
                                    $('#hyp_cloud_chart_news').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_cloud_chart_news").removeClass("fa fa-plus-circle");
                                    $("#hyp_cloud_chart_news").removeClass("fa fa-minus-circle");
                                    $('#hyp_cloud_chart_news').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'map_twitter') {
                                if (SettingValue === '0') {
                                    $("#hyp_map_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_map_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_map_twitter').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_map_twitter").removeClass("fa fa-plus-circle");
                                    $("#hyp_map_twitter").removeClass("fa fa-minus-circle");
                                    $('#hyp_map_twitter').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'map_telegram') {
                                if (SettingValue === '0') {
                                    $("#hyp_map_telegram").removeClass("fa fa-plus-circle");
                                    $("#hyp_map_telegram").removeClass("fa fa-minus-circle");
                                    $('#hyp_map_telegram').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_map_telegram").removeClass("fa fa-plus-circle");
                                    $("#hyp_map_telegram").removeClass("fa fa-minus-circle");
                                    $('#hyp_map_telegram').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'map_instagram') {
                                if (SettingValue === '0') {
                                    $("#hyp_map_instagram").removeClass("fa fa-plus-circle");
                                    $("#hyp_map_instagram").removeClass("fa fa-minus-circle");
                                    $('#hyp_map_instagram').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_map_instagram").removeClass("fa fa-plus-circle");
                                    $("#hyp_map_instagram").removeClass("fa fa-minus-circle");
                                    $('#hyp_map_instagram').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'news_bohransaz_mosbat') {
                                if (SettingValue === '0') {
                                    $("#hyp_news_bohransaz_mosbat").removeClass("fa fa-plus-circle");
                                    $("#hyp_news_bohransaz_mosbat").removeClass("fa fa-minus-circle");
                                    $('#hyp_news_bohransaz_mosbat').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_news_bohransaz_mosbat").removeClass("fa fa-plus-circle");
                                    $("#hyp_news_bohransaz_mosbat").removeClass("fa fa-minus-circle");
                                    $('#hyp_news_bohransaz_mosbat').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'news_bohransaz_manfi') {
                                if (SettingValue === '0') {
                                    $("#hyp_news_bohransaz_manfi").removeClass("fa fa-plus-circle");
                                    $("#hyp_news_bohransaz_manfi").removeClass("fa fa-minus-circle");
                                    $('#hyp_news_bohransaz_manfi').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_news_bohransaz_manfi").removeClass("fa fa-plus-circle");
                                    $("#hyp_news_bohransaz_manfi").removeClass("fa fa-minus-circle");
                                    $('#hyp_news_bohransaz_manfi').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }
                            if (SettingTitle === 'newspaper') {
                                if (SettingValue === '0') {
                                    $("#hyp_newspaper").removeClass("fa fa-plus-circle");
                                    $("#hyp_newspaper").removeClass("fa fa-minus-circle");
                                    $('#hyp_newspaper').addClass('animate__animated animate__heartBeat fa fa-plus-circle');
                                }
                                else {
                                    $("#hyp_newspaper").removeClass("fa fa-plus-circle");
                                    $("#hyp_newspaper").removeClass("fa fa-minus-circle");
                                    $('#hyp_newspaper').addClass('animate__animated animate__heartBeat fa fa-minus-circle');
                                }
                            }

                        });
                    }
                    else {
                        $this.removeClass();
                        $this.attr("class", "animate__animated animate__heartBeat fa fa-plus-circle");
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









