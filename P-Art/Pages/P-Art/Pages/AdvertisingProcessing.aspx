<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="AdvertisingProcessing.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.AdvertisingProcessing" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1" />


    <%--    <style>
        .dropdownAd {
        }

        a {
            width: 100%;
        }

        .dropdownAd button {
            width: 180px;
            font-size: 1em;
        }

            .dropdownAd button i {
                position: relative;
                top: 1px;
                color: rgba(0,0,0,0.3);
                float: left;
                font-size: 1.5em;
            }

        .containerAdvertizing {
            margin: 5%;
        }

        .dropdownSubAd .dropdownL2SubAd {
            display: none;
        }

        .dropdownSubAd a i {
            position: relative;
            top: 1px;
            color: rgba(0,0,0,0.3);
            float: left;
            font-size: 1.5em;
        }

        .dropdownRootMenuAd {
            display: none;
        }


        ul {
            background: #ffffff;
            border: 1px solid rgba(0,0,0,0.0625);
            border-radius: 7px;
            margin-top: 3px;
            max-width: 200px;
            transition: all .3s;
            -webkit-transition: all 1s;
            -moz-transition: all 1s;
            -ms-transition: all 1s;
            -o-transition: all 1s;
        }

            ul li {
                padding: 4px 25px;
                border-bottom: 1px solid rgba(0,0,0,0.0625);
                font-size: 1em;
                transition: all .3s;
                -webkit-transition: all .3s;
                -moz-transition: all .3s;
                -ms-transition: all .3s;
                -o-transition: all .3s;
            }


                ul li:hover {
                    background-color: rgba(232, 244, 252, 0.6);
                }

                ul li a {
                    color: #777777;
                }

                ul li .dropdownL2SubAd {
                    position: absolute;
                    margin-top: -32px;
                    margin-right: 175px;
                }
    </style>--%>
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <div class="welcomPageDataBox">
        <div class="TotalBox persian">
            <h3>پردازش تبلیغات</h3>
            <div  runat="server" id="accessEnvironmentAdvertise"  class="welcomeDataBox" style="background-color: #ffc107!important;">
                <span class="welcomeDataBoxHeader">تبلیغات محیطی</span>
                <span class="welcomeDataBoxContent"><a runat="server" id="accessEnvironmentAdvertiseUrl"   href="" ><i class="far fa-calendar	 fa-2x" ></i></a></span>
            </div>
            <div  runat="server" id="accessTvAdvertise"  class="welcomeDataBox" style="background-color: #ff6a00!important;">
                <span class="welcomeDataBoxHeader">تبلیغات تلویزیونی</span>
                <span class="welcomeDataBoxContent"><a  runat="server" id="accessTvAdvertiseUrl"   href="" target="_blank" ><i class="fas fa-tv fa-2x" ></i></a></span>
            </div>
            <div  runat="server" id="accessRadioAdvertise" class="welcomeDataBox" style="background-color: #17a2b8!important;">
                <span class="welcomeDataBoxHeader">تبلیغات رادیویی</span>
                <span class="welcomeDataBoxContent"><a runat="server" id="accessRadioAdvertiseUrl"  href="" target="_blank" ><i class="fas fa-microphone-alt fa-2x" ></i></a></span>
            </div>
            <div class="welcomeDataBox" style="background-color: #6c757d!important">
                <span class="welcomeDataBoxHeader">تبلیغات شبکه های اجتماعی</span>
                <span class="welcomeDataBoxContent"><a ><i class="fas fa-hashtag fa-2x" ></i></a></span>
            </div>
            <div class="welcomeDataBox" style="background-color: #dc3545!important">
                <span class="welcomeDataBoxHeader">تبلیغات مکتوب</span>
                <span class="welcomeDataBoxContent"><a  ><i class="far fa-newspaper fa-2x" ></i></a></span>
            </div>
            <div class="welcomeDataBox" style="background-color: #007bff !important;" disabled="disabled">
                <span class="welcomeDataBoxHeader">تبلیغات اینترنتی</span>
                <span class="welcomeDataBoxContent"><a  ><i class="far fa-internet-explorer fa-2x" ></i></a></span>
            </div>
            <div runat="server" id="topBrands" class="welcomeDataBox" style="background-color: #ff0000 !important;" >
                <span class="welcomeDataBoxHeader">Share of voice</span>
                <span class="welcomeDataBoxContent"><a runat="server" id="topBrandsUrl" href="" target="_blank" ><i class="	fas fa-store-alt fa-2x" ></i></a></span>
            </div>
        </div>
    </div>



    <%--    <div class="containerAdvertizing">

        <div class="dropdownAd">
            <button class="btn btn-default" type="button" data-toggle="dropdown">تبلیغات محیطی<i class="fas fa-caret-down"></i></button>
            <ul class="dropdownRootMenuAd">
                <li><a tabindex="-1" href="/AdvertisesList">نمایش تبلیغات</a></li>
                <li><a tabindex="-1" href="#">وضعیت اکران روزانه</a></li>
                <li><a tabindex="-1" href="#">گزارشات</a></li>
                <li class="dropdownSubAd">
                    <a class="test" tabindex="-1" href="#"><span>تبلیغات برند</span><i class="fas fa-caret-left"></i></a>
                    <ul class="dropdownL2SubAd">
                        <li><a tabindex="-1" href="#">اکران تهران</a></li>
                        <li><a tabindex="-1" href="#">اکران شهرستان ها</a></li>

                    </ul>
                </li>
                <li class="dropdownSubAd">
                    <a class="test" tabindex="-1" href="#"><span>تبلیغات رقبا</span><i class="fas fa-caret-left"></i></a>
                    <ul class="dropdownL2SubAd">
                        <li><a tabindex="-1" href="#">اکران تهران</a></li>
                        <li><a tabindex="-1" href="#">اکران شهرستان ها</a></li>

                    </ul>
                </li>
            </ul>
        </div>
    </div>

    <script>


        $(document).ready(function () {

            $('.dropdownSubAd a.test').on("click", function (e) {
                $(this).next('ul').toggle(100);
                e.stopPropagation();
            });
        });
    </script>




    <script>
        $(document).ready(function () {
            $('.dropdownAd').on("click", function (e) {
                $('.dropdownL2SubAd').each(function () {
                    $(this).fadeOut();
                });
                $('.dropdownRootMenuAd').toggle(100);
                e.stopPropagation();
            });
        });
    </script>--%>
</asp:Content>
