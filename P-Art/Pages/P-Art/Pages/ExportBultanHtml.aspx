<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportBultanHtml.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.ExportBultanHtml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @font-face {
            font-family: 'BYekan';
            src: url('/Styles/fonts/BYekan.eot?#') format('eot'), /* IE6–8 */
            url('/Styles/fonts/BYekan.woff') format('woff'), /* FF3.6+, IE9, Chrome6+, Saf5.1+*/
            url('/Styles/fonts/BYekan.ttf') format('truetype'); /* Saf3—5, Chrome4+, FF3.5, Opera 10+ */
        }

        @font-face {
            font-family: 'BMitra';
            src: url('/Styles/fonts/BMitra.eot?#') format('eot'), /* IE6–8 */
            url('/Styles/fonts/BMitra.woff') format('woff'), /* FF3.6+, IE9, Chrome6+, Saf5.1+*/
            url('/Styles/fonts/BMitra.ttf') format('truetype'); /* Saf3—5, Chrome4+, FF3.5, Opera 10+ */
        }

        @font-face {
            font-family: 'BTitr';
            src: url('/Styles/fonts/BTitrBold.eot?#') format('eot'), /* IE6–8 */
            url('/Styles/fonts/BTitrBold.woff') format('woff'), /* FF3.6+, IE9, Chrome6+, Saf5.1+*/
            url('/Styles/fonts/BTitrBold.ttf') format('truetype'); /* Saf3—5, Chrome4+, FF3.5, Opera 10+ */
        }

        @font-face {
            font-family: 'BNasim';
            src: url('/Styles/fonts/bbc-nassim-regular.eot?#') format('eot'), /* IE6–8 */
            url('/Styles/fonts/bbc-nassim-regular.woff') format('woff'), /* FF3.6+, IE9, Chrome6+, Saf5.1+*/
            url('/Styles/fonts/bbc-nassim-regular.ttf') format('truetype'); /* Saf3—5, Chrome4+, FF3.5, Opera 10+ */
        }

        @font-face {
            font-family: 'BNasimBold';
            src: url('/Styles/fonts/bbc-nassim-bold.eot?#') format('eot'), /* IE6–8 */
            url('/Styles/fonts/bbc-nassim-bold.woff') format('woff'),; /* FF3.6+, IE9, Chrome6+, Saf5.1+*/
        }

        body {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            background-color: #FAFAFA;
            font: 12pt "Tahoma";
        }

        .page {
            width: 210mm;
            min-height: 297mm;
            /*padding: 20mm;*/
            margin: 10mm auto;
            border: 1px #D3D3D3 solid;
            border-radius: 5px;
            background: white;
            display: block;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
            background-size: 100% auto !important;
            position: relative;
            text-align: right;
            direction: rtl;
        }

        #fehrestPage > .page, #fehrestPage > .page:after {
        background-color: #FFEFEF;
  }

        .fehrest {
            position: relative;
            
            padding: 40px 10px 10px 10px;
        }

            .fehrest .divHeader {
                position: absolute;
                background: #b97272;
                border-top: 5px solid #6f093e;
                height: 30px;
                top: 1%;
                left: 0;
                width: 100%;
            }

            .fehrest .divFooter {
                background: #8bb972;
                border-top: 2px solid #f00;
                height: 30px;
                position: absolute;
                bottom: 5%;
            }

            .fehrest h2 {
                font: normal 28px 'BMitra';
            }

            .fehrest ul {
            }

                .fehrest ul li {
                    font: normal 16px 'BMitra';
                }

        .page .footer {
            position: absolute;
            bottom: 25px;
            height: 15px;
            width: 100%;
            /*background: #117DB8;*/
            z-index: 9999999999999;
        }

            .page .footer span {
                direction: rtl;
                display: block;
                width: 60px;
                height: 15px;
                line-height: 15px;
                left: 47%;
                position: absolute;
                /*background: #fff;*/
                color: #fff;
                font: bold 11px tahoma;
                text-align: center;
            }

        span.noteNum {
            color: #f00;
            font-size: 18px;
        }

        .clearfix:after {
            clear: both;
            content: ' ';
            display: block;
            font-size: 0;
            line-height: 0;
            visibility: hidden;
            width: 0;
            height: 0;
        }

        .clear {
            clear: both;
        }

        .clearfix {
            display: inline-block;
        }

        * html .clearfix {
            height: 1%;
        }

        .clearfix {
            display: block;
        }

        @page {
            size: A4;
            margin: 0;
          
            @top-left {
                content: "Cascading Style Sheets";
            }

            h1;

        {
            string-set: header content();
        }

        @page :right {
            @top-right {
                content: string(header, first);
            }
        }

        @bottom-center {
            content: counter(page) "/" counter(pages);
        }
        /*@bottom-right {
padding-right:20px;
        content: "Page " counter(page);
      }*/
        }


        @media print {
            html, body {
                width: 210mm;
                height: 297mm;
                background: #fff;
            }

            .delete_chart {
                display: none;
            }

            .page {
                margin: 0;
                border: initial;
                border-radius: initial;
                width: initial;
                min-height: initial;
                box-shadow: initial;
                page-break-after: always;
                position: relative;
                /*height: 275mm;*/
                height: 296mm;
                top: 0px;
                padding: 0px;
            }

                .page:before {
                }

                .page:after {
                }

            .subPage {
            }


            .page .footer {
                position: absolute;
                bottom: 0px;
            }

                .page .footer span {
                    position: absolute;
                    bottom: 0px;
                }

            .fehrest {
                position: relative;
                padding-bottom: 5%;
                padding: 60px 10px 10px 10px;
            }

                .fehrest .divHeader {
                   
                   z-index:9999;
                }


                .fehrest .divFooter {
                    position: fixed;
                    bottom: 5%;
                }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="fehrestPage">
            <asp:Literal runat="server" ID="ltNewsFehrest"></asp:Literal>
          
        </div>
    </form>
</body>
</html>
