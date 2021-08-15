<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLDataCenterPack.aspx.cs" Inherits="P_Art.HTMLDataCenterPack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Panel style sheet class-->
    <link href="Pages/P-Art/Styles/PanelStyle.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>

    <style>
        body {
            background: rgb(204,204,204);
            font-family: Conv_BTrafficBold;
        }

        .page {
            background: white;
            display: block;
            margin: 0 auto;
            box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);
            overflow: hidden;
        }

        .cover {
            background-image: url("/Pages/P-Art/Images/Bulltin-Cover.jpg");
            background-size: 100%;
            background-repeat: no-repeat;
        }

        .pageCover {
            background-image: url("/Pages/P-Art/Images/Bulltin-Page.jpg");
            background-size: 21cm 29.7cm;
            background-repeat: no-repeat;
        }


        .A4 {
            display: block;
            width: 21cm;
            height: 29.7cm;
        }

            .A4 .portrait {
                width: 29.7cm;
                height: 21cm;
            }

        .A3 {
            width: 29.7cm;
            height: 42cm;
        }

        div .page .A3 .portrait {
            width: 42cm;
            height: 29.7cm;
        }

        .A5 {
            width: 14.8cm;
            height: 21cm;
        }

            .A5.portrait {
                width: 21cm;
                height: 14.8cm;
            }

        .printButton {
            padding: 7px 20px;
            position: fixed;
            right: 20px;
            top: 20px;
            background: #ffffff;
            border-radius: 5px 5px 5px 5px;
            -moz-border-radius: 5px 5px 5px 5px;
            -webkit-border-radius: 5px 5px 5px 5px;
            border: 1px solid rgba(0,0,0,0.0625);
            color: #333333;
            font-size: .8em;
            font-weight: bold;
        }

            .printButton i {
                padding-left: 4px;
            }

        .result-title {
            padding: 1.6cm;
            padding-top:3cm;
            height: 25.1cm;
            text-align: justify;
        }

        .title {
            font-weight: bold;
            font-size: 1.3em;
        }

        .image {
            width: 10cm;
            float: left;
            padding: 10px;
        }

        rect .highcharts-background {
            fill: transparent !important;
        }

        .BulltinTitle {
            position: relative;
            font-weight: bold;
            font-size: 1.5em;
            right: .5cm;
            top: 14cm;
            text-align: center;
        }

        .persianNum {
            font-family: Conv_BTrafficBold;
            font-size: .9em;
        }

        .pageNumber {
            font-family: Conv_BTrafficBold;
            font-size: .9em;
            position: relative;
            display: block;
            bottom: 2cm;
            margin-right: 19cm;
        }

        .pieChartBorder {
            border: 1px solid rgba(0,0,0,0.0625);
            padding: 10px;
            left: 1.1cm;
            position: relative;
        }

        .highcharts-legend-item rect {
            x: 26px !important;
            position: relative;
        }

        @media print {
            * {
                -webkit-print-color-adjust: exact;
            }

            body {
                margin: 0 0 0 0 !important;
                box-shadow: 0 0 0 0 !important;
            }

            .page {
                right: 0;
                text-align: center;
                margin: 0 0 0 0 !important;
                box-shadow: 0 0 0 0 !important;
                padding: 0;
            }


            .printButton {
                display: none;
            }

            @page {
                margin: 0 0 0 0;
            }


            .btn {
                display: none;
            }

            .tagedit-list {
                display: none;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="persian">

            <div class="page A4 cover">
                <div class="BulltinTitle">
                    <span>
                        <label id="CurrentUserLabel" runat="server"></label>
                    </span>
                    <br />
                    <span>
                        <asp:Label ID="FromDateLabel" runat="server" CssClass="persian persianNum"></asp:Label>
                        <asp:Label ID="ToDateLabel" runat="server" CssClass="persian persianNum"></asp:Label>
                    </span>
                </div>
            </div>
            <div id="DataCenterPackIndex" runat="server">
            </div>
            <div id="DataCenterPackBody" runat="server" class="NewsFull">
            </div>
            <a class="printButton" href="#"><i class="fas fa-print"></i>چاپ</a>
        </div>
    </form>
    <script src="Scripts/persianNum.jquery-2.min.js"></script>
    <script>
        $('.printButton').on('click', function () {
            window.print();
            return false; // why false?
        });
    </script>
</body>
</html>
