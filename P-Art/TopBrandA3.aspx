<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopBrandA3.aspx.cs" Inherits="P_Art.TopBrandA3" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" media="screen"></style>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
   <%-- <script src="https://code.highcharts.com/modules/series-label.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>--%>
    <link href="/Styles/style.css" rel="stylesheet" />
    <style type="text/css" media="print">
        .Chap {
            display: none;
        }

        .Category {
            display: none;
        }

        .divFilter {
            display: none;
        }

        #language-fa {
            display: none;
        }

        #language-en {
            display: none;
        }

        #show-hide {
            display: none;
        }

        #hypSort {
            display: none;
        }

        .fixed-table-of-content {
            display: none;
        }

        .page.startchart:before {
            display: none;
            visibility: hidden;
            opacity: 0;
            background: none;
            z-index: 0;
            position: initial;
        }

        .page.lead {
            /*height: 237mm;*/
            background: #eee;
        }

        .page .icon {
            padding: 6cm 0 1cm 0;
            text-align: center;
        }

        .page .icon {
            margin: 0 auto;
        }

            .page .icon img {
            }

        .page div.title {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="show-hide" class=""><span>Show all</span></div>
        <div id="language-fa" class=""><span>FA</span></div>
        <div id="language-en" class=""><span>En</span></div>
        <div class=""><a id="hypSort" runat="server"></a></div>
        <div class="Category"><a id="hypCtg" runat="server">Category</a></div>
        <div class="Chap"><a id="hypPrint" onclick="window.print();" runat="server">Print</a></div>
        <section class="fixed-table-of-content appear">
            <em><i class="icon-bookmark-2"></i><span>Table Of Month</span></em>
            <div>

                <ul>
                    <asp:Literal runat="server" ID="ltMenu"></asp:Literal>

                </ul>
            </div>

        </section>
        <div class="divFilter container" id="divFilter" runat="server">
            <div class="divGroups">
                <a runat="server" id="hypGroup_All" class="Group">All</a>
                <a runat="server" id="hypGroup_FMCF" class="Group">FMCG</a>
                <a runat="server" id="hypGroup_Tele" class="Group">Telecommunication</a>
                <a runat="server" id="hypGroup_Auto" class="Group">Automative</a>
                <a runat="server" id="hypGroup_Service" class="Group">Services</a>
                <a runat="server" id="hypGroup_Elec" class="Group">Electronic</a>
            </div>
            <div class="divChilds">
                <asp:Repeater runat="server" ID="rptBrandChild" OnItemDataBound="rptBrandChild_ItemDataBound">
                    <ItemTemplate>
                        <asp:HyperLink class="child" ID="hypChilds" runat="server"><%# Eval("BrandChildName") %></asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div style="clear: both;"></div>
        <asp:Literal runat="server" ID="ltHtml"></asp:Literal>
        <div id="chart7" style="max-height: 800px;display:none;"> </div>

        <script src="/templates/js/jquery.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                analyz_LoadChart(718);


                $('.fixed-table-of-content em').click(function () {
                    $('.fixed-table-of-content').toggleClass('reveal');
                });

                $('#language-fa').click(function () {
                    $(".brand").addClass("brand-show");
                    $(".brand").removeClass("brand-hide");
                    $(".latinbrand").removeClass("latinbrand-show");
                    $(".latinbrand").addClass("latinbrand-hide");

                });

                $('#language-en').click(function () {
                    $(".brand").addClass("brand-hide");
                    $(".brand").removeClass("brand-show");
                    $(".latinbrand").removeClass("latinbrand-hide");
                    $(".latinbrand").addClass("latinbrand-show");

                });

                $('#hypCtg').click(function () {
                    $(".divFilter").slideToggle();
                });
            });

            $('.fixed-table-of-content h5').live('click', function () {
                var $this = $(this);
                $this.toggleClass("uncollapse");
                $this.next().toggleClass("uncollapse");
                $this.next().slideToggle();
            });
        </script>
        <script type="text/javascript">
            var BSB = {

                init: function () {
                    this.tiles();
                    this.init_show_hide();
                    //this.shareblock();
                    //this.init_gallery();
                    //this.init_superbox();
                    //this.init_downloads();
                },

                shareblock: function () {
                    jQuery('body#interviews .textblock').each(function () {
                        share_url = 'http://' + window.location.hostname + window.location.pathname + '#' + jQuery(this).find('h1').attr('id');
                        headline = jQuery(this).find('h1').text();
                        out = '';
                        out += '<div class="shareblock"><p>Share this:</p><div>';
                        out += '<a href="http://www.facebook.com/sharer.php?s=100&p[url]=' + share_url + '" target="_blank"><img src="/img/ui/facebook.png" title="Facebook"></a>';
                        out += '<a href=" https://twitter.com/intent/tweet?url=' + encodeURI(share_url) + '&hashtags=bestswissbrands&text=' + encodeURI(headline) + '" target="_blank"><img src="/img/ui/twitter.png" title="Twitter"></a>';
                        out += '<a href="http://www.linkedin.com/shareArticle?url=' + encodeURI(share_url) + '" target="_blank"><img src="/img/ui/linkedin.png" title="LinkedIn"></a>';
                        out += '<a href="mailto:?subject=Best Swiss Brands 2015: ' + headline + '&body=' + encodeURI('<' + share_url + '>') + '" target="_blank"><img src="/img/ui/mail.png" title="Mail"></a>';
                        out += '</div></div>';

                        jQuery(this).before(out);
                    });
                },

                tiles: function () {
                    jQuery('.tile').removeClass('reveal');
                    for (i = 0; i < 5 ; i++) {
                        random = (Math.random() * 9) + 1;
                        random = Math.round(random);
                        jQuery('.tile:nth-child(' + ((i * 10) + random) + ')').addClass('reveal');
                    }
                    tiletimer = window.setTimeout("BSB.tiles()", 2000);
                },

                init_downloads: function () {
                    jQuery('body#downloads .linkblock .whitepaper .col a').each(function () {
                        jQuery(this).click(function (event) {
                            event.preventDefault();
                            filename = jQuery(this).attr('href').split('/').pop().replace(/\./, '/');
                            BSB.download(filename);
                        });
                    });
                },

                download: function (filename) {
                    // alert( filename );
                    if (jQuery.cookie('BSB') && BSB.isEmail(jQuery.cookie('BSB'))) {
                        href = '/filedownload/' + encodeURI(jQuery.cookie('BSB').replace(/\@/, '/')) + '/' + encodeURI(filename);
                        // alert( href );
                        document.location.href = href;
                    } else {
                        BSB.superbox('<div class="download-wrapper"><h1>Download</h1><p>please insert a valid e-mail address and hit the download button to start the downloading the requested file</p><form id="download-form"><input type="email" id="download-email" placeholder="your.name@company.com"><input type="hidden" name="filename" id="download-filename" value="' + filename + '" ></form></div><div class="download-wrapper"><button id="download-button" disabled>Download</button></div>');
                        jQuery('#download-form').submit(function () {
                            event.preventDefault();
                            jQuery('#download-button').trigger('click');
                        });
                        jQuery('#download-email').keyup(function () {
                            if (BSB.isEmail(jQuery('#download-email').val())) {
                                jQuery('#download-button').attr('disabled', false);
                            } else {
                                jQuery('#download-button').attr('disabled', true);
                            }
                        });
                        jQuery('#download-button').click(function () {
                            if (BSB.isEmail(jQuery('#download-email').val())) {
                                href = '/filedownload/' + encodeURI(jQuery('#download-email').val().replace(/\@/, '/')) + '/' + encodeURI(jQuery('#download-filename').val());
                                // alert( href );
                                jQuery.cookie('BSB', jQuery('#download-email').val());
                                BSB.hide_superbox();
                                document.location.href = href;
                            }
                        });
                    }
                },

                isEmail: function (email) {
                    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                    return regex.test(email);
                },

                init_superbox: function () {
                    jQuery('body').prepend('<div id="overlay"></div>');
                    jQuery('body').prepend('<div id="superbox"><div id="superbox-containment"></div><div id="superbox-close"></div></div>');
                    jQuery('#overlay, #superbox-close').click(function () {
                        BSB.hide_superbox();
                    });
                },

                superbox: function (content) {
                    width = 290;
                    height = 187;
                    jQuery('#overlay').show();
                    jQuery('#superbox-containment').html(content).height(height).width(width);
                    jQuery('#superbox').height(height).width(width).show();
                    jQuery('#superbox .close').click(function () {
                        BSB.hide_superbox();
                    });
                    jQuery('#superbox .print').click(function () {
                        window.print();
                    });
                    jQuery('body').addClass('superbox');
                    BSB.update_superbox_pos();
                },

                hide_superbox: function () {
                    jQuery('body').removeClass('superbox');
                    jQuery('#overlay').hide();
                    jQuery('#superbox').hide();
                    jQuery('#superbox-containment').html('');
                },

                update_superbox_pos: function () {
                    pos = {};
                    pos.left = (jQuery('body').width() / 2) - (jQuery('#superbox').width() / 2);
                    jQuery('#superbox').offset(pos);
                },

                init_show_hide: function () {
                    jQuery('#show-hide').click(function () {
                        BSB.reveal_all_tiles();
                    });
                },

                reveal_all_tiles: function () {
                    if (jQuery('#show-hide.show').length) {
                        jQuery('#show-hide').removeClass('show');
                        jQuery('#show-hide span').text('Show all');
                        BSB.tiles();
                    } else {
                        jQuery('#show-hide').addClass('show');
                        jQuery('#show-hide span').text('Hide');
                        window.clearTimeout(tiletimer);
                        jQuery('.tile').addClass('reveal');

                    }
                },

                init_gallery: function () {
                    jQuery('.litebox').liteBox({
                        revealSpeed: 400,
                        background: 'rgba(0,0,0,.8)',
                        overlayClose: true,
                        escKey: true,
                        navKey: true,
                        callbackInit: function () { },
                        callbackBeforeOpen: function () { },
                        callbackAfterOpen: function () { },
                        callbackBeforeClose: function () { },
                        callbackAfterClose: function () { },
                        callbackError: function () { },
                        callbackPrev: function () { },
                        callbackNext: function () { },
                        errorMessage: 'Error loading content.'
                    });
                },



                copyright: function () {
                    alert('finq.net');
                }
            }

            jQuery(document).ready(function () {
                BSB.init();
            });
        </script>
        <script>
            function ShowBrandChild(element) {
                var groupId = $(element).attr('data-groupid');
            }
        </script>
    </form>

    <script>
        function analyz_LoadChart(brandid) {
            newData = [];
            newData2 = [];
            newData3 = [];
            $.ajax({
                type: "POST",
                url: "/ajax.aspx/ChartBrandCountValue",
                data: "{'BrandId':'" + brandid + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   
                    for (var i = 0; i < data.d.length; i++) {

                        newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);
                    }
                    $.ajax({
                        type: "POST",
                        url: "/ajax.aspx/ChartBrandTimeValue",
                        data: "{'BrandId':'" + brandid + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data2) {
                            for (var i = 0; i < data2.d.length; i++) {

                                newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);
                            }
                            $.ajax({
                                type: "POST",
                                url: "/ajax.aspx/ChartBrandRankValue",
                                data: "{'BrandId':'" + brandid + "'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data3) {
                                    for (var i = 0; i < data3.d.length; i++) {

                                        newData3.push([data3.d[i].Name, parseInt(data3.d[i].Value)]);
                                    }
                                    $("#chart7").slideToggle();
                                    $("#progress7").animate({ width: '100%' }, 400);
                                    Highcharts.chart('chart7', {
                                    //$('#chart7').highcharts({
                                        chart: {
                                            type: 'line'
                                        },
                                        xAxis: {
                                            type: 'category',
                                            rotation: -45
                                        },
                                        yAxis: {
                                            title: {
                                                text: 'TOP BRANDS CHART'
                                            }
                                        },
                                        stackLabels: {
                                            enabled: true,
                                            style: {
                                                fontWeight: 'bold',
                                                color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                                            }
                                        },
                                        title: {
                                            text: ''
                                        },
                                        legend: {
                                            enabled: true
                                        },
                                        tooltip: {
                                            pointFormat: '<div style="direction:rtl;text-align:right"><span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b><br/></div>',
                                            shared: true
                                        },
                                        plotOptions: {
                                            column: {
                                                stacking: 'normal',
                                                dataLabels: {
                                                    enabled: true,
                                                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                                                    style: {
                                                        textShadow: '0 0 3px black, 0 0 3px black'
                                                    }
                                                }
                                            }
                                        },
                                        series: [{
                                            type: 'line',
                                            name: 'SPOT',
                                            data: newData,
                                            stake: 'SPOT'

                                        }, {
                                            type: 'line',
                                            name: 'TIME',
                                            data: newData2,
                                            stake: 'TIME'

                                        }, {
                                            type: 'line',
                                            name: 'RANK',
                                            data: newData3,
                                            stake: 'RANK'

                                        }]
                                    });
                                }
                            });
                        }
                    });
                }
            });

            
        }
    </script>
</body>
</html>
