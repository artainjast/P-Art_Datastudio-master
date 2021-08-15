var SelectedNews = "";
var speedy = "0";
var priority = "0";
var VideoSlideDown = false;
var MenuStatus = false;
var FilterStatus = false;

var exportType = "";
var audioElement;
var range_importance = 3;
var range_priority = 2;
var timer_tv;
var LastNewsTv = 0;
var LastOtherNews = 0;
var isControlBoxVisible = false;
var IsCheckAll = false;

$(document).ready(function () {

    //$(document).on('change', '.control-box .group_item span input[type=checkbox]', function (e) {


    //    var ids = ",";
    //    $('.control-box .group_item span input[type=checkbox]').each(function (index) {
    //        if ($(this).is(':checked')) {
    //            ids += $(this).parent().parent().find("a").attr("data-id") + ",";

    //        }
    //    });


    //    if (ids == ",") {
    //        $(".posts article").removeClass("hidden");
    //        $(".posts article").removeClass("show");
    //        $(".posts article").addClass("show");


    //    }
    //    else {


    //        $(".posts article").each(function (post) {

    //            $(this).removeClass("hidden");
    //            $(this).removeClass("show");

    //            var dataItem = $(this).attr("data-id");
    //            var dataItemKeys = $(this).find("#hdfNewsTags").val();


    //            var hasKey = false;
    //            $(ids.split(',')).each(function () {
    //                var sKey = this;

    //                if (sKey != '') {
    //                    if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
    //                        hasKey = true;
    //                    }
    //                }
    //            });

    //            if (hasKey) {
    //                $(this).addClass("show");
    //            }

    //            else {
    //                $(this).addClass("hidden");
    //            }

    //        });

    //    }
    //    sortArticleIndex();
    //});

    $(document).on('change', '.control-box .group_item span input[type=checkbox]', function (e) {
        var ids = ",";
        $('.control-box .group_item span input[type=checkbox]').each(function (index) {
            if ($(this).is(':checked')) {
                ids += $(this).parent().parent().find("a").attr("data-id") + ",";
            }
        });
        if (ids == ",") {
            $(".posts article").parent().removeClass("hidden");
            $(".posts article").parent().removeClass("show");
            $(".posts article").parent().addClass("show");
        }
        else {


            $(".posts article").each(function (post) {

                $(this).parent().removeClass("hidden");
                $(this).parent().removeClass("show");

                var dataItem = $(this).parent().attr("data-id");
                var dataItemKeys = $(this).parent().find("#hdfNewsTags").val();


                var hasKey = false;
                $(ids.split(',')).each(function () {
                    var sKey = this;

                    if (sKey != '') {
                        if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
                            hasKey = true;
                        }
                    }
                });

                if (hasKey) {
                    $(this).parent().addClass("show");
                }

                else {
                    $(this).parent().addClass("hidden");
                }

            });

        }

        sortArticleIndex();
    });


    $(document).on('change', '.control-box1 .group_item .ch input[type=checkbox]', function (e) {

        //alert('1');
        var ids = ",";
        $('.control-box1 .group_item .ch input[type=checkbox]').each(function (index) {
            //alert('1');
            if ($(this).is(':checked')) {
                ids += $(this).parent().parent().find("a").attr("data-id") + ",";
                // alert(ids);
            }
        });


        if (ids == ",") {
            // alert('2');
            $(".posts1 article").removeClass("hidden");
            $(".posts1 article").removeClass("show");
            $(".posts1 article").addClass("show");


        }
        else {

            // 
            $(".posts1 article").each(function (post) {
                //  alert('3');
                $(this).removeClass("hidden");
                $(this).removeClass("show");

                // var dataItem = $(this).attr("data-id");
                //alert(dataItem);
                var dataItemKeys = $(this).find("#hdfNewsTags").val();
                // alert(dataItemKeys);

                var hasKey = false;
                $(ids.split(',')).each(function () {
                    var sKey = this;

                    if (sKey != '') {
                        // alert(sKey);
                        if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
                            hasKey = true;
                            //alert(hasKey);
                        }
                    }
                });

                if (hasKey) {
                    //alert('1');
                    $(this).addClass("show");
                    // alert(  $(this).addClass("show"));
                }

                else {
                    $(this).addClass("hidden");
                }

            });

        }

        sortArticleIndex();
    });
    function sortArticleIndex() {
        var counter = 1;

        $('.news_list article.show').each(function (index) {
            // alert('yes');
            var $this = $(this);
            $this.find('.post-content').find('span.rowIndex').text(parseInt(counter) + ")");
            //alert($this.find('.post-content').find('span.rowIndex').text);
            counter++;
            //alert(counter);
        });
    }


    $(document).on('change', '.keygroup input[type=checkbox]', function (e) {


        var ids = ",";
        $('.control-box .group_item span input[type=checkbox]').each(function (index) {
            if ($(this).is(':checked')) {
                ids += $(this).parent().parent().find("a").attr("data-group") + ",";

            }
        });


        if (ids == ",") {
            $(".posts article").removeClass("hidden");
            $(".posts article").removeClass("show");
            $(".posts article").addClass("show");


        } else {


            $(".posts article").each(function (post) {

                $(this).removeClass("hidden");
                $(this).removeClass("show");

                var dataItem = $(this).attr("data-group");
                var dataItemKeys = $(this).find("#hdfNewsTags").val();

                //   alert(dataItem);

                var hasKey = false;
                $(ids.split(',')).each(function () {
                    var sKey = this;
                    //   alert(sKey);
                    if (sKey != '') {
                        if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
                            hasKey = true;
                        }
                    }
                });

                if (hasKey) {
                    $(this).addClass("show");
                }
                else {
                    $(this).addClass("hidden");
                }
            });

        }
        sortArticleIndex();
    });



    $(document).on('change', '.keygroup1 input[type=checkbox]', function (e) {


        var ids = ",";
        $('.control-box1 .group_item .ch input[type=checkbox]').each(function (index) {
            if ($(this).is(':checked')) {
                ids += $(this).parent().parent().find("a").attr("data-group") + ",";
                // alert(ids);
            }
        });


        if (ids == ",") {
            $(".posts1 article").removeClass("hidden");
            $(".posts1 article").removeClass("show");
            $(".posts1 article").addClass("show");


        } else {


            $(".posts1 article").each(function (post) {

                $(this).removeClass("hidden");
                $(this).removeClass("show");

                var dataItem = $(this).attr("data-group");
                var dataItemKeys = $(this).find("#hdfNewsTags").val();

                //   alert(dataItem);

                var hasKey = false;
                $(ids.split(',')).each(function () {
                    var sKey = this;
                    // alert(sKey);
                    if (sKey != '') {
                        if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
                            hasKey = true;
                        }
                    }
                });

                if (hasKey) {
                    $(this).addClass("show");
                }
                else {
                    $(this).addClass("hidden");
                }
            });

        }
        sortArticleIndex();
    });




    $(document).on('change', '.keygroup input[type=checkbox]', function (e) {


        var ids = ",";
        $('.control-box .group_item span input[type=checkbox]').each(function (index) {
            if ($(this).is(':checked')) {
                ids += $(this).parent().parent().find("a").attr("data-group") + ",";

            }
        });


        if (ids == ",") {
            $(".posts a").removeClass("hidden");
            $(".posts a").removeClass("show");
            $(".posts a").addClass("show");


        } else {


            $(".posts a").each(function (post) {

                $(this).removeClass("hidden");
                $(this).removeClass("show");

                var dataItem = $(this).attr("data-group");
                var dataItemKeys = $(this).find("#hdfNewsTags").val();

                //   alert(dataItem);

                var hasKey = false;
                $(ids.split(',')).each(function () {
                    var sKey = this;
                    //   alert(sKey);
                    if (sKey != '') {
                        if (dataItemKeys.indexOf("," + sKey + ",") > -1) {
                            hasKey = true;
                        }
                    }
                });

                if (hasKey) {
                    $(this).addClass("show");
                }
                else {
                    $(this).addClass("hidden");
                }
            });

        }
        sortArticleIndex();
    });



    $("#lnk_close_window").click(function (e) {
        CloseModal();

    });


    $(".closeSide").click(function (e) {

        $(".tv-group").css("height", "32px");
        $(".posts").addClass("large");
        $(".radio-group").css("display", "none");
    });

    $('.posts article input[type="checkbox"]').bind('change', function () {

        var newsId = $(this).parent().parent().find("#fld_newsId").val();
        var value = false;

        if ($(this).is(':checked')) {
            value = true;
        }
        else {
            value = false;
        }

        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/SetNewsSelect",
            data: "{'newsId':'" + newsId + "','value':'" + value + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {


            },
            error: function (msg) {

            }

        });
    });

    if ($(".control-box.category").length > 0) {
    }

    if (window.location.pathname.toString().toLowerCase().indexOf("showvideo") > 0) {
        PlayVideo(window.location.pathname.toString().toLowerCase().split('/')[2]);

    };
    $(".switchkeyword").click(function (e) {

        e.preventDefault();
    });


    $(".switchkeyword1").click(function (e) {

        e.preventDefault();
    });
    $(".check_SelectNews").click(function () {
    });
    $("#btn_SelectAll").click(function (e) {

        $(".posts article.show").each(function () {


            var postRow = $(this);

            //if ($(postRow).css("display") == "block") {


            //    
            //}
            if (IsCheckAll == true) {
                $(postRow).find("#check_SelectNews").attr('checked', false);
            } else {
                $(postRow).find("#check_SelectNews").attr('checked', true);
            }


        });


        if (IsCheckAll == true) {
            IsCheckAll = false;
        }
        else {
            IsCheckAll = true;
        }
        setTimeout(function () { GetSelectedNews(); }, 3000);



        e.preventDefault();

    });

    $("#btn_SelectAllInternational").click(function (e) {

        $(".Fehrest div.showFehrest").each(function () {


            var postRow = $(this);

            //if ($(postRow).css("display") == "block") {


            //    
            //}
            if (IsCheckAll == true) {

                $(postRow).find("#check_SelectNews").attr('checked', false);
            } else {

                $(postRow).find("#check_SelectNews").attr('checked', true);
            }


        });


        if (IsCheckAll == true) {
            IsCheckAll = false;
        }
        else {
            IsCheckAll = true;
        }
        setTimeout(function () { GetSelectedNews(); }, 3000);



        e.preventDefault();

    });



    $("#btn_SelectAllSocial").click(function (e) {

        $(".posts1 article.show").each(function () {

            //alert('1');
            var postRow = $(this);

            //if ($(postRow).css("display") == "block") {


            //    
            //}
            if (IsCheckAll == true) {

                $(postRow).find("#check_SelectNews").attr('checked', false);
            } else {

                $(postRow).find("#check_SelectNews").attr('checked', true);
            }


        });


        if (IsCheckAll == true) {
            IsCheckAll = false;
        }
        else {
            IsCheckAll = true;
        }
        setTimeout(function () { GetSelectedNews(); }, 3000);



        e.preventDefault();

    });



    $("#lnk_bultan").click(function (e) {

        if (isControlBoxVisible == true) {
            $(".control-box").slideUp(600, function () {

                $(".control-box.bultan").slideDown(600);
            });

        } else {
            $(".control-box.bultan").slideDown(600);
        }
        isControlBoxVisible = true;
        e.preventDefault();
    });

    $("#lnk_filter").click(function (e) {

        if (isControlBoxVisible == true) {
            $(".control-box").slideUp(600, function () {

                $(".control-box.filter").slideDown(600);
            });

        } else {
            $(".control-box.filter").slideDown(600);
        }
        isControlBoxVisible = true;
        e.preventDefault();
    });

    $("#lnk_category").click(function (e) {
        if (isControlBoxVisible == true) {
            $(".control-box").slideUp(600, function () {

                $(".control-box.category").slideDown(600);
            });

        } else {
            $(".control-box.category").slideDown(600);
        }
        isControlBoxVisible = true;
        e.preventDefault();
    });
    $('#drp_AllowTv').on("change", function () {

        var value = $(this).val();

        var itemId = $(this).attr("itemid");
        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/SetTvAllow",
            data: "{'newsId':'" + itemId + "','value':'" + value + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {


            },
            error: function (msg) {

            }

        });



    });

    $(".newsrate a").click(function (e) {

        var item = $(this);
        var boxDiv = $(this).parent();

        var id = $(item).attr("class");
        var newsId = $(item).attr("itemid");
        var newsValue = -1;
        switch (id) {

            case "btn_news_ok":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                newsValue = 1;
                break;
            case "btn_news_empty":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                newsValue = 0;
                break;
            case "btn_news_notok":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                newsValue = 2;
                break;
            case "btn_news_lowـcommunication":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                newsValue = 3;
                break;
            case "btn_news_irrelevant":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '1' }, 500);
                newsValue = 4;
                break;
            default:
                newsValue = -1;
                break;
        }
        try {
            $(boxDiv).find("#hdfNewsOrientation").val(newsValue);
        }
        catch (ex) {

        }
        if (newsValue != -1)
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/SetNewsValue",
                data: "{'NewsId':'" + newsId + "','value':'" + newsValue + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {


                },
                error: function (msg) {

                }

            });
        e.preventDefault();
    });

    $(".newsrate1 a").click(function (e) {

        var item = $(this);
        var boxDiv = $(this).parent();

        var id = $(item).attr("class");
        var newsId = $(item).attr("itemid");
        var newsValue = -1;
        switch (id) {

            case "btn_news_ok":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                newsValue = 1;
                break;
            case "btn_news_empty":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                newsValue = 0;
                break;
            case "btn_news_notok":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                newsValue = 2;
                break;
            case "btn_news_lowـcommunication":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                newsValue = 3;
                break;
            case "btn_news_irrelevant":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '1' }, 500);
                newsValue = 4;
                break;
            default:
                newsValue = -1;
                break;
        }
        try {
            $(boxDiv).find("#hdfNewsOrientation").val(newsValue);
        }
        catch (ex) {

        }
        if (newsValue != -1)
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/SetNewsValue1",
                data: "{'NewsId':'" + newsId + "','value':'" + newsValue + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {


                },
                error: function (msg) {

                }

            });
        e.preventDefault();
    });


    $(".newsRelatedSection.newsrate a").click(function (e) {

        var item = $(this);
        var boxDiv = $(this).parent();

        var id = $(item).attr("class");
        var newsId = $(item).attr("itemid");
        var newsValue = -1;
        switch (id) {


            case "btn_news_ok":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                newsValue = 1;
                break;
            case "btn_news_empty":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);

                newsValue = 0;
                break;
            case "btn_news_notok":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                newsValue = 2;
                break;
            case "btn_news_lowـcommunication":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '0.1' }, 500);
                newsValue = 3;
                break;
            case "btn_news_irrelevant":
                $(boxDiv).find(".btn_news_empty").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_notok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_ok").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_lowـcommunication").animate({ opacity: '0.1' }, 500);
                $(boxDiv).find(".btn_news_irrelevant").animate({ opacity: '1' }, 500);
                newsValue = 4;
                break;
            default:
                newsValue = -1;
                break;
        }
        try {
            $(boxDiv).find("#hdfNewsOrientation").val(newsValue);
        }
        catch (ex) {

        }
        if (newsValue != -1)
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/SetNewsValue",
                data: "{'NewsId':'" + newsId + "','value':'" + newsValue + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {


                },
                error: function (msg) {

                }

            });
        e.preventDefault();
    });

    $(".btn_SendSms,.btn_SendMail").click(function (e) {

        alert("این سیستم برای شما فعال نمی باشد");
        e.preventDefault();
    });

    $('.btn_RemoveNews').on('click', function (e) {
        var result = confirm("آیا مایل به حذف خبر مورد نظر هستید ؟");
        if (result == true) {
            var btn = $(this);
            $(btn).css("display", "none");

            var newsId = $(btn).attr("itemid");


            var img = $(this).parent().find("img");
            $(img).fadeIn(100);
            setTimeout(function () {

                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/DeleteNews",
                    data: "{'NewsId':'" + newsId + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {


                        window.location.reload();
                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }

                });

            }, 3000);
        }
        e.preventDefault();
    });

    if ($(".photo").length > 0) {
        $(".photo a").fancybox();
    };

    $("#cmb_Filter").click(function (e) {

        if (FilterStatus == false) {
            FilterStatus = true;

            $("#filterBox").animate({ height: 152, opacity: 1 }, 1000, 'easeInOutBack');

        } else {
            FilterStatus = false;
            $("#filterBox").animate({ height: 0, opacity: 0 }, 1000, 'easeInOutBack');


        }
        e.preventDefault();
    });

    if ($(".zoom").length > 0) {

        $('.zoom').zoom();
    }
    DoRange();


    if ($("#range_Importance").length > 0) {

        $("#range_Importance").slider({
            value: 3,
            min: 1,
            max: 5,
            step: 1,
            slide: function (event, ui) {
                range_importance = ui.value;
                DoRange();
                //alert(ui.value);
                //$("#amount").val("$" + ui.value);
            }
        });

    }

    if ($("#range_Priority").length > 0) {

        $("#range_Priority").slider({
            value: 2,
            min: 1,
            max: 5,
            step: 1,
            slide: function (event, ui) {
                range_priority = ui.value;
                //alert(ui.value);
                //$("#amount").val("$" + ui.value);
            }
        });

    }

    if ($("#slider .item figure").length > 0) {

        $("#slider .item figure").hover(function () {
            $(this).find("figcaption").fadeIn(300);
        }, function () {
            $(this).find("figcaption").fadeOut(300);

        });


    }
    if ($(".list_carousel1").length > 0) {
        $('.list_carousel1 ul').carouFredSel({
            width: 534,
            height: 'auto',
            prev: '.prev1',
            next: '.next1',
            auto: false
        });
    }

    if ($(".list_carousel2").length > 0) {
        $('.list_carousel2 ul').carouFredSel({
            width: 845,
            height: 'auto',
            prev: '.prev2',
            next: '.next2',
            auto: false
        });
    }
    if ($(".list_carousel3").length > 0) {
        $('.list_carousel3 ul').carouFredSel({
            width: 845,
            height: 'auto',
            prev: '.prev3',
            next: '.next3',
            auto: false
        });
    }

    if ($(".bar-tiny").length > 0) {
        $(".bar-tiny .social a").hover(function () {
            $(this).animate({ opacity: 1 }, 300);

        }, function () {
            $(this).animate({ opacity: 0.7 }, 300);
        });
    }

    if ($(".box-breakNews").length > 0) {
        $(".box-breakNews ul li:last-child").find(".cat_item").css("border", "none");
    }

    if ($("#cat_cinema").length > 0) {
        $("#cat_cinema").click(function (e) {
            e.preventDefault();

            //$("html, body").animate({ scrollTop: 0 }, "slow");
            $(".cat-action img").css("left", "94px");
            $(".category-Theater,.category-music").fadeOut(1, function () {

                $(".category-cinema").fadeIn(1);
            });

        });
    }
    if ($("#cat_theater").length > 0) {
        $("#cat_theater").click(function (e) {
            e.preventDefault();

            //$("html, body").animate({ scrollTop: 0 }, "slow");

            $(".cat-action img").css("left", "17px");

            $(".category-cinema,.category-music").fadeOut(1, function () {

                $(".category-Theater").fadeIn(1);
            });



        });
    }
    if ($("#cat_music").length > 0) {
        $("#cat_music").click(function (e) {
            e.preventDefault();

            //$("html, body").animate({ scrollTop: 0 }, "slow");

            $(".cat-action img").css("left", "-68px");

            $(".category-cinema,.category-Theater").fadeOut(1, function () {


                $(".category-music").fadeIn(1);
            });



        });
    }

    if ($(".cat_item").length > 0) {
        $(".cat_item a h4 span").hover(function () {

            $(this).css("background-color", "#EF4534");
            $(this).css("color", "white");
        }, function () {

            $(this).css("background-color", "#F9F9F9");
            $(this).css("color", "#6B6A6A");
        });
    }
    if ($(".paging").length > 0) {
        $(".paging a").hover(function () {
            $(this).find("img").animate({ opacity: 1 }, 600);
        }, function () {
            $(this).find("img").animate({ opacity: 0.4 }, 600);
        });
    }

    if ($(".tabbed").length > 0) {
        $(".tabbed ul li").removeClass("selected");


        if (window.location.pathname.toString().toLowerCase().indexOf("news/latest") > 0) {
            $(".tabbed ul li:nth-child(1)").addClass("selected");
        }

        else if (window.location.pathname.toString().toLowerCase().indexOf("news/update") > 0) {
            $(".tabbed ul li:nth-child(2)").addClass("selected");
        }
        else if (window.location.pathname.toString().toLowerCase().indexOf("news/archive") > 0) {
            $(".tabbed ul li:nth-child(3)").addClass("selected");
        }
        else if (window.location.pathname.toString().toLowerCase().indexOf("news/export") > 0) {
            $(".tabbed ul li:nth-child(4)").addClass("selected");
        }
    }

    $('.btn_SendGozideh').on('click', function (e) {


        var btn = $(this);
        var img = $(this).parent().find("img");

        $(img).fadeIn(100);
        setTimeout(function () {
            $(btn).animate({ opacity: 0 }, 300, function () {
                $(btn).css("display", "none");
            });
            $(img).fadeOut(100)
            //alert("hello");
        }, 3000);


        e.preventDefault();
    })

    $("#btn_exportReport").click(function (e) {

        e.preventDefault();

        if (SelectedNews == "") {

            alert("لطفا خبرهای مورد نظر را انتخاب کنید");
            return;
        }

        $("#boxPdfSetting #loading").fadeOut(100);
        $("#DownloadBox").fadeOut(100, function () {
            $("#boxPdfSetting").css("background-color", "#FBFCD5");
            $("#boxPdfSetting").slideDown(500);
            $("#boxPdfSetting #lst_checks").fadeIn(300);
        });
    });

    $("#btn_generate").click(function (e) {


        GetSelectedNews();
        var checkNewsPaper = $('#check_NewsPaper').attr('checked') ? 'true' : 'false';
        var CheckChart = $('#check_ChartKhabar').attr('checked') ? 'true' : 'false';
        var CheckCinema = $('#check_Sima').attr('checked') ? 'true' : 'false';
        var CheckGozideh = $('#check_gozideh').attr('checked') ? 'true' : 'false';
        var CheckMashrooh = $('#check_mashrooh').attr('checked') ? 'true' : 'false';
        var checkAllowArchive = $('#check_addArchive').attr('checked') ? 'true' : 'false';
        var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';
        var checkAllowRelated = $('#check_related').attr('checked') ? 'true' : 'false';
        var isFullBultan = "true";

        //var NewsType = $("#drp_newsSource").val();

        var fromDate = $('#txt_fromDate').val();
        var toDate = $('#txt_toDate').val();

        StartGenerate();

        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/GenerateReport",
            data: "{'NewsIds': '" + SelectedNews + "','fromDate':'" + $('#txt_fromDate').val() + "','toDate':'" + $('#txt_toDate').val() + "','AllowNewsPaper':" + checkNewsPaper + ",'AllowCharts':" + CheckChart + ",'Cinema':" + CheckCinema + ",'ExportType':'" + exportType + "','AllowGozideh':'" + CheckGozideh + "','AllowMashrooh':'" + CheckMashrooh + "','NewsType':'0','name':'" + $("#txt_bultanTitle").val() + "','AddArchive':'" + checkAllowArchive + "','bultanid':'" + $("#drp_template").val() + "','allowHighlight':'" + checkAllowHighlight + "','allowRelated':'" + checkAllowRelated + "','fullContentBultan':'" + isFullBultan + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                FinishGenerate(msg);


            },
            error: function (msg) {
                //alert("خطا در زمان ساخت بولتن لطفا صفحه را ریفرش کنید و دوباره امتحان کنید");
                alert(msg.responseText);
            }

        });
        e.preventDefault();
    });
    $("#btn_PrintLead").click(function (e) {


        GetSelectedNews();
        var checkNewsPaper = $('#check_NewsPaper').attr('checked') ? 'true' : 'false';
        var CheckChart = $('#check_ChartKhabar').attr('checked') ? 'true' : 'false';
        var CheckCinema = $('#check_Sima').attr('checked') ? 'true' : 'false';
        var CheckGozideh = $('#check_gozideh').attr('checked') ? 'true' : 'false';
        var CheckMashrooh = $('#check_mashrooh').attr('checked') ? 'true' : 'false';
        var checkAllowArchive = $('#check_addArchive').attr('checked') ? 'true' : 'false';
        var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';
        var checkAllowRelated = $('#check_related').attr('checked') ? 'true' : 'false';
        var isFullBultan = "false";

        //var NewsType = $("#drp_newsSource").val();


        StartGenerate();

        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/GenerateReport",
            data: "{'NewsIds': '" + SelectedNews + "','fromDate':'" + $('#txt_fromDate').val() + "','toDate':'" + $('#txt_toDate').val() + "','AllowNewsPaper':" + checkNewsPaper + ",'AllowCharts':" + CheckChart + ",'Cinema':" + CheckCinema + ",'ExportType':'" + exportType + "','AllowGozideh':'" + CheckGozideh + "','AllowMashrooh':'" + CheckMashrooh + "','NewsType':'0','name':'" + $("#txt_bultanTitle").val() + "','AddArchive':'" + checkAllowArchive + "','bultanid':'" + $("#drp_template").val() + "','allowHighlight':'" + checkAllowHighlight + "','allowRelated':'" + checkAllowRelated + "','fullContentBultan':'" + isFullBultan + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                FinishGenerate(msg);


            },
            error: function (msg) {
                //alert("خطا در زمان ساخت بولتن لطفا صفحه را ریفرش کنید و دوباره امتحان کنید");
                alert(msg.responseText);
            }

        });
        e.preventDefault();
    });

    $('#txt_Search,#txt_fromDate,#txt_toDate').on("keypress", function (e) {
        if (e.keyCode == 13) {
            $("#btn_Report").click();
            e.preventDefault();


        }


    });

    $('#txt_MainSearch').on("keypress", function (e) {
        if (e.keyCode == 13) {
            $("#btn_search").click();
            e.preventDefault();


        }


    });

    $("#btn_ShareNews").click(function (e) {

        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/SendMail",
            data: "{'NewsTitle':'','NewsBody':'','Speed':'','Source':''}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {


                alert("Send It");
            },
            error: function (msg) {
                alert(msg.responseText);
            }

        });

        e.preventDefault();
    });

    $("#grd_News tr td .check_news").click(function () {



        var item = $(this);

        var code = $(item).attr("data-id");

        if ($(item).attr('checked')) {

            SelectedNews = SelectedNews.replace(code, "");

            $(item).attr('checked', false);


        } else {


            SelectedNews += code + ",";
            $(item).attr('checked', true);

        }

    });

    $("#grd_News tr th:first input:checkbox").click(function () {
        var checkedStatus = this.checked;
        SelectedNews = "";
        $("#grd_News tbody tr td:first-child input:checkbox").each(function () {
            this.checked = checkedStatus;


            if (this.checked == true) {

                SelectedNews += $(this).parent().attr("data-id") + ",";
                $(this).parent().attr("checked", true);
            } else {


                SelectedNews = SelectedNews.replace($(this).parent().attr("data-id"), "");
                $(this).parent().attr("checked", false);
            }


        });


    });


    $("#grd_News tr td:first-child + td + td .lbl-title").click(function () {

        var tr = $(this).parent();

        if ($(tr).find("p").text().trim() == ".") return;

        $(this).parent().css("background-color", "#F3F3F3");

        $(tr).find("p").css("display", "block");


    });


    $('#Cmb_Switch').on("change", function () {

        var panelId = $(this).val();
        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/Switch",
            data: "{'PanelId': '" + panelId + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {


                location.reload(true);
            },
            error: function (msg) {
                alert(msg.responseText);
            }

        });

    });
    $('#drp_exportType').on("change", function () {

        exportType = $(this).val();


    });
    $('#drp_reportType').on("change", function () {

        var days;


        switch ($(this).val()) {

            case "0":
                days = 0;
                break;
            case "1":
                days = -7;
                break;

            case "2":
                days = -30;
                break;
            case "3":
                return;
                break;

        }

        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/CalculateDate",
            data: "{'fromDate': '" + $('#txt_fromDate').val() + "','ToDate':'" + $('#txt_toDate').val() + "','days':" + days + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#txt_fromDate').val(msg.d[0]);
                $('#txt_toDate').val(msg.d[1]);


            },
            error: function (msg) {
                alert(msg.responseText);
            }

        });



    });
    $(".PlaySound").click(function (e) {
        return;
        var movieId = $(this).attr("title");

        $('html, body').animate({ scrollTop: 0 }, 1000, function () {



            if (VideoSlideDown == false) {

                $("#videoPlayer").animate({ height: '350px' }, 1000, function () {
                    $.ajax({
                        type: "POST",
                        url: "/pages/p-art/pages/ajax.aspx/GetRadioById",
                        data: "{'SoundId': '" + movieId + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            $("#info-title").html(msg.d[0]);
                            $("#info-date").html(msg.d[1]);
                            $("#info-source").html(msg.d[5]);

                            $("#video-info a").attr("href", msg.d[6]);

                            setupAudioPlayer("PlayerElement", "", msg.d[6]);

                        },
                        error: function (msg) {
                            alert(msg.responseText);
                        }

                    });



                });
                VideoSlideDown = true;
            } else {
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/GetRadioById",
                    data: "{'SoundId': '" + movieId + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        $("#info-title").html(msg.d[0]);
                        $("#info-date").html(msg.d[1]);
                        $("#info-source").html(msg.d[5]);
                        $("#video-info a").attr("href", msg.d[6]);

                        setupAudioPlayer("PlayerElement", "", msg.d[6]);

                    },
                    error: function (msg) {
                        alert(msg.responseText);
                    }

                });
            }
        });

        e.preventDefault();
    });
    $(".ShowVideo").click(function (e) {
        var movieId = $(this).attr("title");

        PlayVideo(movieId);

        e.preventDefault();
    });


    if ($("#sectionMovie #toolbar").length > 0) {
        $("#sectionMovie #toolbar ul li").removeClass("currItem");


        if (window.location.pathname.toString().toLowerCase().indexOf("movies/latest") > 0) {
            $("#sectionMovie #toolbar ul li:nth-child(1)").addClass("currItem");
        }

        else if (window.location.pathname.toString().toLowerCase().indexOf("movies/update") > 0) {
            $("#sectionMovie #toolbar ul li:nth-child(2)").addClass("currItem");
        }
        else if (window.location.pathname.toString().toLowerCase().indexOf("movies/archive") > 0) {
            $("#sectionMovie #toolbar ul li:nth-child(3)").addClass("currItem");
        }
        else if (window.location.pathname.toString().toLowerCase().indexOf("movies/other") > 0) {
            $("#sectionMovie #toolbar ul li:nth-child(4)").addClass("currItem");
        }
    }

    $("#btn_setting").click(function (e) {

        if (MenuStatus == false) {
            $("#setting").css("display", "block");
            $("#setting").animate({ height: '80' }, 500);
            $("#setting ul").animate({ height: '80' }, 500);
            e.stopPropagation();
            MenuStatus = true;
        } else {

            MenuClose();
        }
        e.preventDefault();
    });

    $("#setting a").click(function (e) {


        MenuClose();
    });

    $('html').click(function (e) {

        MenuClose();
    });

    $(".btn_SendGozideh").click(function (e) {
        var newsId = $(this).attr("itemid");
        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/AddSelectionNews",
            data: "{'NewsId': '" + newsId + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {


            },
            error: function (msg) {
                alert(msg.responseText);
            }

        });

    });


    $("#btnShowTv").click(function (e) {
        ResetTv();

        $("#model_Tv").animate({ top: 0, left: 0, width: '100%', height: '100%', opacity: 1 }, 600, 'easeInOutCirc', function () {



            StartTv();


        });
        e.preventDefault();
    });

    $("#btn_close_tv").click(function (e) {
        clearInterval(timer_tv);
        $("#box-News").css("display", "none");


        $("#model_Tv").animate({ top: '50%', left: '50%', width: '0', height: '0', opacity: 0 }, 600, 'easeInOutCirc', function () {

            $("#model_Tv").css("top", "-10000px");
            $("#model_Tv").css("left", "-10000px");
        });
        e.preventDefault();
    });

    //function btn_ReportChart_Click() {
    //    $("#box-waiting").slideDown(700);
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadKeywords(fromDate, toDate, function () {
    //            analyz_LoadKeywords2(fromDate, toDate, function () {
    //                analyz_LoadChart1(fromDate, toDate, function () {
    //                    analyz_LoadChart2(fromDate, toDate, function () {
    //                        analyz_LoadChart3(fromDate, toDate, function () {
    //                            analyz_LoadChart4(fromDate, toDate, function () {
    //                                analyz_LoadChart5(fromDate, toDate, function () {
    //                                    analyz_LoadChart6(fromDate, toDate, function () {
    //                                        analyz_LoadChart9(fromDate, toDate, function () {
    //                                            analyz_LoadChart10(fromDate, toDate, function () {
    //                                                analyz_LoadChart12(fromDate, toDate, function () {
    //                                                    analyz_LoadKeywordsChart(fromDate, toDate, function () {
    //                                                        finishAnalyz();
    //                                                    });
    //                                                });
    //                                            });
    //                                        });
    //                                    });
    //                                });
    //                            });
    //                        })
    //                    });
    //                });
    //            });
    //        }

    //        );
    //    //e.preventDefault();
    //}




    $("#btn_SocialReportChart").click(function (e) {
        $("#box-waiting").slideDown(700);
        var fromDate = $("#txt_fromDate").val();
        var toDate = $("#txt_toDate").val();
        analyz_LoadChart4_social(fromDate, toDate, function () {
            analyz_LoadChartUsers_social(fromDate, toDate, function () {
                analyz_LoadUsers_Social(fromDate, toDate, function () {
                    finishAnalyz();
                });
            });
        });


        //analyz_LoadKeywords_Social(fromDate, toDate,
        //    function () {
        //        analyz_LoadKeywords2_social(fromDate, toDate, function () {
        //            analyz_LoadChart4_social(fromDate, toDate, function () {
        //                analyz_LoadChartUsers_social(fromDate, toDate, function () {
        //                    analyz_LoadKeywordsChartSocial(fromDate, toDate, function () {
        //                        finishAnalyz();
        //                    });
        //                });
        //            });
        //        });
        //    }
        //    );
        e.preventDefault();

    });


    

    //$("#resultTitleButton").click(function () {

    //        var fromDate = $("#txt_fromDate").val();
    //        var toDate = $("#txt_toDate").val();
    //        setTimeout(analyz_LoadKeywords(fromDate, toDate),1000);

       
    //});

    //$("#resultKeyCountNewsButton").click(function () {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadKeywords2(fromDate, toDate);
    //});


    //function resultTitleButton_Click() {

    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();
    //    setTimeout(analyz_LoadKeywords(fromDate, toDate), 1000);
    //}


    //function resultKeyCountNewsButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadKeywords2(fromDate, toDate);
    //}

    //function resultKeypPercentNewsButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart1(fromDate, toDate);
    //}

    //function FrequencyDistributionNewsButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart2(fromDate, toDate);
    //}

    //function FrqDistributionNewsPaperButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart3(fromDate, toDate);
    //}

    //function FrqDistributionNewsKeysButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadKeywordsChart(fromDate, toDatete);
    //}

    //function FrqDistributNewsOrientButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart4(fromDate, toDate);
    //}

    //function FrqDistributNewsStationOrientButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart5(toDate, fromDate);
    //}

    //function FrqDistributNewsPaperStationOrientButton_Click() {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart6(fromDate, toDate);
    //}

    //$("#PercentPeopleNewsButton").click(function () {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart9(fromDate, toDate);
    //});

    //$("#FrqDistributNewsProvinceButton").click(function () {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart10(fromDate, toDatee);
    //});

    //$("#FrqDistributNewsProvincePrButton").click(function () {
    //    var fromDate = $("#txt_fromDate").val();
    //    var toDate = $("#txt_toDate").val();

    //    analyz_LoadChart12(fromDate, toDate);
    //});

    //$(".result-title ul li a").click(function (e) {
    //    var link = $(this);
    //    var report = $(link).parent().parent().attr("class");
    //    var itemId = $(link).attr("class");
    //    var fromDate = $("#fld_today").val();

    //    var toDate = "";
    //    switch (report) {
    //        case "report1":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadKeywords(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadKeywords(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report2":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart1(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart1(toDate, fromDate);
    //                    break;
    //            }
    //            break;

    //        case "report3":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart2(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart2(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report4":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart3(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart3(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report5":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadKeywordsChart(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadKeywordsChart(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report6":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart4(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart4(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report7":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart5(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart5(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report8":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart6(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart6(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report9":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart9(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart9(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report10":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart10(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart10(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report11":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadKeywords2(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report12":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart12(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart12(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //    }
    //    e.preventDefault();
    //});

    //$(".result-title-social ul li a").click(function (e) {


    //    var link = $(this);
    //    var report = $(link).parent().parent().attr("class");
    //    var itemId = $(link).attr("class");
    //    var fromDate = $("#fld_today").val();

    //    var toDate = "";
    //    switch (report) {
    //        case "report1":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadKeywords_Social(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadKeywords_Social(toDate, fromDate);
    //                    break;
    //            }
    //            break;


    //        case "report5":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadKeywordsChartSocial(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadKeywordsChartSocial(toDate, fromDate);
    //                    break;
    //            }
    //            break;
    //        case "report6":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChart4_social(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChart4_social(toDate, fromDate);
    //                    break;
    //            }
    //            break;


    //        case "report7":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadChartUsers_social(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadChartUsers_social(toDate, fromDate);
    //                    break;
    //            }
    //            break;



    //        case "report11":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadKeywords2(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadKeywords2(toDate, fromDate);
    //                    break;
    //            }
    //            break;

    //        case "report12":
    //            switch (itemId) {
    //                case "lnk-0":
    //                    analyz_LoadUsers_Social(fromDate, fromDate);
    //                    break;
    //                case "lnk-1":
    //                    toDate = $("#fld_yestarday").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-2":
    //                    toDate = $("#fld_10day").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-3":
    //                    toDate = $("#fld_20day").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-4":
    //                    toDate = $("#fld_30day").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-5":
    //                    toDate = $("#fld_1month").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-6":
    //                    toDate = $("#fld_3month").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-7":
    //                    toDate = $("#fld_6month").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //                case "lnk-8":
    //                    toDate = $("#fld_1year").val();
    //                    analyz_LoadUsers_Social(toDate, fromDate);
    //                    break;
    //            }
    //            break;


    //    }
    //    e.preventDefault();

    //});

    $(window).scroll(function () {
        currentScrollTop = $(window).scrollTop();
        $("#setting").css("display", "none");
        $("#setting").css("height", "0");
        $("#setting").css("top", currentScrollTop + 40);


        if (currentScrollTop >= 160) {

            $("#header-links").fadeOut('fast', function () {


                $(".MainNavHeader").fadeIn('fast');

            });



        } else {
            $(".MainNavHeader").fadeOut('fast', function () {
                $("#header-links").fadeIn('fast');
            });


        }
    });

    setTimeout(function () { analyz_LoadDefaultKeywords(); }, 1000);

});


function playAlarm() {
    soundHandle = document.getElementById('soundHandle');
    soundHandle.play();
}

function MonitoringNews() {

    var count = $(".posts article").size() - 1;
    //$(".posts article:nth-child(" + count - 1 + ")").remove();
    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/MonitorNews",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d == null) return;
            var newsCount = msg.d.length;

            var html = "";
            if (newsCount == 0) return;

            if (count >= 10) {

                for (var i = count - newsCount; i <= count ; i++) {

                    $(".posts article:eq(" + (i + 1) + ")").remove();



                }
            }
            playAlarm();

            for (var i = 0; i <= newsCount - 1; i++) {
                var newsId = msg.d[i].toString().split("*SPLIT*")[0];
                var newsTitle = msg.d[i].toString().split("*SPLIT*")[1];
                var newsPicture = msg.d[i].toString().split("*SPLIT*")[2];
                var newsLead = msg.d[i].toString().split("*SPLIT*")[3];
                var newValue = msg.d[i].toString().split("*SPLIT*")[4];

                if (newsPicture == "") newsPicture = "../../Pages/P-Art/Images/noImage.gif";


                html = "<article class='monitorData'><figure><a href='../../ShowNews/" + newsId + "'><img id='img_post' src='" + newsPicture + "'></a><figcaption>جدید</figcaption></figure><div class='post-content'><h2><a href='../../ShowNews/" + newsId + "'>" + newsTitle + "</a></h2><p class='info'></p><p class='lead'>" + newsLead + "</p><div id='news_tools'><a class='btn_SendGozideh' href='#' title='ذخیره خبر' itemid='" + newsId + "'>ذخیره خبر</a><img src='../../Pages/P-Art/Images/ajax-loader.gif' /></div>   </div></article>";
                $(".posts").prepend(html);

                $(".monitorData").slideDown(500, function () {
                    $(".monitorData").animate({ 'background-color': 'white' }, 30000, function () {


                    });
                });


            }

        },
        error: function (msg) {
            //alert(msg.responseText);
        }

    });


}

function DoRange() {
    $("#check_FarsNews").attr('checked', false);
    $("#check_Mehr").attr('checked', false);
    $("#check_Isna").attr('checked', false);
    $("#check_KhabarOnline").attr('checked', false);
    $("#check_Ilna").attr('checked', false);

    switch (range_importance) {
        case 1:

            $("#check_Mehr").attr('checked', true);
            break;
        case 2:

            $("#check_Isna").attr('checked', true);
            $("#check_Mehr").attr('checked', true);
            break;

        case 3:

            $("#check_KhabarOnline").attr('checked', true);
            $("#check_Mehr").attr('checked', true);
            $("#check_Isna").attr('checked', true);
            break;
        case 4:

            $("#check_KhabarOnline").attr('checked', true);
            $("#check_Mehr").attr('checked', true);
            $("#check_Isna").attr('checked', true);
            $("#check_Ilna").attr('checked', true);
            break;
        case 5:

            $("#check_FarsNews").attr('checked', true);
            $("#check_Mehr").attr('checked', true);
            $("#check_Isna").attr('checked', true);
            $("#check_KhabarOnline").attr('checked', true);
            $("#check_Ilna").attr('checked', true);
            break;

    }
}
function StartGenerate() {
    $(".control-box.bultan .loader").slideDown(500);


}

function FinishGenerate(e) {


    $("#lnk_download").css("display", "block");
    $("#lnk_download").attr("href", "/pages/p-art/pages/Pdf/" + e.d[0]);
    $(".control-box.bultan .loader").slideUp(500);

    return;
    $("#boxPdfSetting #loading").fadeOut(200, function () {

        $("#DownloadBox").fadeIn(300);
        $("#lnkDownload").attr("href", "/pages/p-art/pages/Pdf/" + e.d[0]);
        $("#fileSize").html("حجم فایل : " + e.d[1] + " مگابایت ");
        $("#fileSize,#lnkDownload").fadeIn(500);
        $("#boxPdfSetting").css("background-color", "#E2FFCF");
    });


}
function PlayVideo(movieId) {
    $('html, body').animate({ scrollTop: 0 }, 1000, function () {



        if (VideoSlideDown == false) {

            $("#videoPlayer").animate({ height: '505px' }, 1000, function () {
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/GetMovieById",
                    data: "{'MovieId': '" + movieId + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        $("#info-title").html(msg.d[0]);
                        $("#info-date").html(msg.d[1]);
                        $("#info-source").html(msg.d[7]);
                        $("#video-info a").attr("href", msg.d[9]);

                        setupPlayer("PlayerElement", msg.d[10], msg.d[9]);

                    },
                    error: function (msg) {
                        //alert(msg.responseText);
                    }

                });



            });
            VideoSlideDown = true;
        } else {
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/GetMovieById",
                data: "{'MovieId': '" + movieId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#info-title").html(msg.d[0]);
                    $("#info-date").html(msg.d[1]);
                    $("#info-source").html(msg.d[7]);
                    $("#video-info a").attr("href", msg.d[9]);

                    setupPlayer("PlayerElement", msg.d[10], msg.d[9]);

                },
                error: function (msg) {
                    //alert(msg.responseText);
                }

            });
        }
    });
}

function setupPlayer(element, picture, videopath) {
    var elementName = "'#" + element + "'";
    //$('#divPoster').css("background", "url(" + picture + ") no-repeat");
    //$(elementName).html("");

    //document.getElementById(element).innerHTML = "";


    jwplayer(element).setup({
        file: videopath,
        image: picture,
        width: 1170,
        height: 505,
        autostart: 'false'
    });

}

function setupAudioPlayer(element, picture, videopath) {
    var elementName = "'#" + element + "'";

    //$(elementName).html("");

    //document.getElementById(element).innerHTML = "";


    jwplayer(element).setup({
        file: videopath,
        type: 'mp3',
        image: picture,
        width: 619,
        autostart: 'false'
    });

}
function StartTv() {

    var tvType = $('#rbtnTvOption').find(":checked").val();
    var keysShow = "";
    $('.onoffswitch').each(function () {
        var $this = $(this);
        if ($this.find('input:checked').length > 0) {
            keysShow += $this.find('input').val() + ",";
        }
    });
    timer_tv = setInterval(function () {
        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/GetLastNews",
            data: "{'lastRow': '" + LastNewsTv + "','lastRowOtherNews':'" + LastOtherNews + "','showType':'2','fromDate':'','toDate':'','TvSourceType':'" + tvType + "','KeysToShow':'" + keysShow + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                if (LastNewsTv == 0) {
                    $("#lblslogan span").css("display", "none");
                    $("#lblslogan").animate({ left: '20px', top: '65%', 'margin-left': 0, 'margin-top': 0, 'width': 151, 'height': 161 }, 1000, 'easeInOutCirc');
                    $(".box-News").fadeIn(300);
                    //$("#lblslogan").fadeOut(2000, function () {
                    ShowTvNews(msg.d);
                    LastNewsTv++;
                    LastOtherNews++;
                    return;
                    //});
                }
                ShowTvNews(msg.d);
                LastNewsTv++;
                LastOtherNews++;
            },
            error: function (msg) {
                if (msg.responseText == "reset1") {
                    LastNewsTv = 0;
                } else if (msg.responseText == "reset2") {
                    LastOtherNews = 0;
                }



            }
        });
    }, 30000);

}

function ShowTvNews(e) {

    if (e[12] == "") {
        $("#tv-lblNewsTitle").css("color", "white");

    } else if (e[12] == "1") {
        $("#tv-lblNewsTitle").css("color", "green");
    } else if (e[12] == "2") {
        $("#tv-lblNewsTitle").css("color", "red");
    }


    if (e[13] == "") {
        $("#tv-lblNewsTitle2").css("color", "white");
    } else if (e[13] == "1") {
        $("#tv-lblNewsTitle2").css("color", "green");

    } else if (e[13] == "2") {
        $("#tv-lblNewsTitle2").css("color", "red");
    }



    if (LastNewsTv == 0) {
        $("#tv-lblNewsTitle").html(e[1]);
        $("#tv-lblNewsLead").html(e[2]);
        $("#tv-lblNewsSource").html("منبع خبر : <span>" + e[4] + "</span>" + "زمان خبر : " + e[5]);

        if (e[3] == "") {
            //$(".box-News #img1").css("display", "none");
            $("#tv-lblNewsTitle,#tv-lblNewsLead,#tv-lblNewsSource").css("width", "97%");
        } else {
            $(".box-News #img1").attr("src", e[3]);
            $(".box-News #img1").css("display", "block");
            $("#tv-lblNewsTitle,#tv-lblNewsLead,#tv-lblNewsSource").css("width", "97%");
        }


    } else {


        $("#tv-lblNewsLead").fadeOut(1000, function () {
            $("#tv-lblNewsTitle").fadeOut(1000, function () {
                $("#tv-lblNewsSource").fadeOut(1000, function () {
                    $("#tv-lblNewsTitle").css("display", "none");
                    $("#tv-lblNewsLead").css("display", "none");
                    $("#tv-lblNewsSource").css("display", "none");

                    if (e[3] == "") {
                        //$(".box-News #img1").css("display", "none");
                        $("#tv-lblNewsTitle,#tv-lblNewsLead,#tv-lblNewsSource").css("width", "97%");
                    } else {

                        //$(".box-News #img1").attr("src", e[3]);
                        //$(".box-News #img1").css("display", "block");
                        $("#tv-lblNewsTitle,#tv-lblNewsLead,#tv-lblNewsSource").css("width", "97%");
                    }

                    $("#tv-lblNewsTitle").html(e[1]);
                    $("#tv-lblNewsLead").html(e[2]);
                    $("#tv-lblNewsSource").html("منبع خبر : <span>" + e[4] + "</span>" + "زمان خبر : " + e[5]);
                });


                //$("#box-News img").fadeOut(1000, function () {



                //});


            });
            setTimeout(function () {
                $("#tv-lblNewsSource").fadeIn(1000, function () {
                    $("#tv-lblNewsTitle").fadeIn(1000, function () {
                        $("#tv-lblNewsLead").fadeIn(1000);

                    });


                });
            }, 3000);
            //setTimeout(function () {



            //}, 1000);

        });
    }











    if (LastOtherNews == 0) {
        $("#tv-lblNewsTitle2").html(e[7]);
        $("#tv-lblNewsLead2").html(e[8]);
        $("#tv-lblNewsSource2").html("منبع خبر : <span>" + e[10] + "</span>" + "زمان خبر : " + e[11]);

        if (e[9] == "") {
            //$(".box-News #img2").css("display", "none");
            $("#tv-lblNewsTitle2,#tv-lblNewsLead2,#tv-lblNewsSource2").css("width", "97%");
        } else {
            //$(".box-News #img2").attr("src", e[9]);
            //$(".box-News #img2").css("display", "block");
            $("#tv-lblNewsTitle2,#tv-lblNewsLead2,#tv-lblNewsSource2").css("width", "97%");
        }


    } else {


        $("#tv-lblNewsLead2").fadeOut(1000, function () {
            $("#tv-lblNewsTitle2").fadeOut(1000, function () {
                $("#tv-lblNewsSource2").fadeOut(1000, function () {
                    $("#tv-lblNewsTitle2").css("display", "none");
                    $("#tv-lblNewsLead2").css("display", "none");
                    $("#tv-lblNewsSource2").css("display", "none");

                    if (e[9] == "") {
                        //$(".box-News #img2").css("display", "none");
                        $("#tv-lblNewsTitle2,#tv-lblNewsLead2,#tv-lblNewsSource2").css("width", "97%");
                    } else {

                        //$(".box-News #img2").attr("src", e[9]);
                        //$(".box-News #img2").css("display", "block");
                        $("#tv-lblNewsTitle2,#tv-lblNewsLead2,#tv-lblNewsSource2").css("width", "97%");
                    }

                    $("#tv-lblNewsTitle2").html(e[7]);
                    $("#tv-lblNewsLead2").html(e[8]);
                    $("#tv-lblNewsSource2").html("منبع خبر : <span>" + e[10] + "</span>" + "زمان خبر : " + e[11]);


                });


                //$("#box-News img").fadeOut(1000, function () {



                //});


            });
            setTimeout(function () {
                $("#tv-lblNewsSource2").fadeIn(1000, function () {
                    $("#tv-lblNewsTitle2").fadeIn(1000, function () {
                        $("#tv-lblNewsLead2").fadeIn(1000);

                    });


                });
            }, 3000);
            //setTimeout(function () {



            //}, 1000);

        });
    }


}
function ResetTVCount() {
    LastNewsTv = 0;


}
function ResetTv() {
    $("#model_Tv").css("top", "50%");
    $("#model_Tv").css("left", "50%");
    $("#lblslogan").css('display', 'block');
    $("#lblslogan").css("width", "232px");
    $("#lblslogan").css("height", "236px");
    $("#lblslogan").css("margin-left", "-122px");
    $("#lblslogan").css("margin-top", "-200px");
    $("#lblslogan").css("top", "50%");
    $("#lblslogan").css("left", "50%");
    $("#lblslogan span").css("display", "block");
    $("#box-News").css("display", "none");
    $("#lblslogan").css("opacity", "1");
    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/ResetTV",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {

        },
        error: function (msg) {
        }
    });
}
function GetSocialBultan(element) {

    var $this = $(element);
    var parmin = $this.attr('data-parmin');

    GetSocialSelectedNews();

    var fromDate = $('#txt_fromDate').val();

    var toDate = $('#txt_toDate').val();

    var bultanTitle = $("#txt_bultanTitle").val();
    var CheckChart = $('#check_ChartKhabar').attr('checked') ? 'true' : 'false';

    var linkUrl = window.location.protocol + "//" + window.location.hostname;
    if (window.location.port != null && window.location.port != '') {
        linkUrl += ":" + window.location.port;
    }
    // alert(linkUrl);
    //generate bultan archive
    $.ajax({

        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/SetBultanSocialArchive",
        data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','bultanTitle': '" +
            bultanTitle + "','SelectedNews': '" + SelectedNews + "','chart':'" + CheckChart + "','linkUrl': '" + linkUrl + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            //alert(msg);
            if (msg.d == null || msg.d == '') return;
            if (msg.d == 0) {
                alert('خطا در ساخت گزارش');
                return;
            }
            var finalLink = linkUrl + "/HtmlSocialNews.aspx?ArchiveId=" + msg.d;
            window.location.href = finalLink;
        }
    });


    //  alert(SelectedNews);
}


function GetGroupHTMLBultan(element) {
    var $this = $(element);
    var parmin = $this.attr('data-parmin');
    // alert($this.attr('data-parmin'));
    GetSelectedNews();
    var fromDate = $('#txt_fromDate').val();
    var toDate = $('#txt_toDate').val();
    var fromTime = $('#txt_fromHour').val();
    var toTime = $('#txt_toHour').val();
    var checkNewsPaper = $('#check_NewsPaper').attr('checked') ? 'true' : 'false';
    var CheckChart = $('#check_ChartKhabar').attr('checked') ? 'true' : 'false';
    var checkAllowArchive = $('#check_addArchive').attr('checked') ? 'true' : 'false';
    var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';
    var checkAllowRelated = $('#check_related').attr('checked') ? 'true' : 'false';
    var bultanTitle = $("#txt_bultanTitle").val();
    var bultanTemplate = $("#drp_template").val();
    var checkAllowGroup = $('#check_addGroup').attr('checked') ? 'true' : 'false';
    var checkAllowArz = $('#check_Arz').attr('checked') ? 'true' : 'false';
    var checkAllowSima = $('#check_Sima').attr('checked') ? 'true' : 'false';
    var checkAllowGalleryNewspaper = $('#check_GalleryNewspaper').attr('checked') ? 'true' : 'false';
    var checkRujeld = $('#check_rujeld').attr('checked') ? 'true' : 'false';

    var linkUrl = window.location.protocol + "//" + window.location.hostname;
    if (window.location.port != null && window.location.port != '') {
        linkUrl += ":" + window.location.port;
    }
    linkUrl = linkUrl + "/HtmlGroupNews.aspx?ArchiveId=";
    //generate bultan archive
    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/SetBultanArchive",
        data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','bultanTitle': '" +
            bultanTitle + "','SelectedNews': '" + SelectedNews + "','fromTime':'" + fromTime + "','toTime':'" +
            toTime + "','allowNewspaper':'" + checkNewsPaper + "','galleryNewspaper':'" +
            checkAllowGalleryNewspaper + "','arz':'" + checkAllowArz + "','sima':'" +
            checkAllowSima + "','highLight':'" + checkAllowHighlight + "','allowGroup':'" +
            checkAllowGroup + "','related':'" + checkAllowRelated + "','selectedBultan':'" +
            bultanTemplate + "','isArchive':'true','chart':'" + CheckChart + "','jeld':'" + checkRujeld + "','BultanType':'2','linkUrl':'" + linkUrl + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d == null || msg.d == '') return;
            if (msg.d == 0) {
                alert('خطا در ساخت گزارش');
                return;
            }
            var finalLink = linkUrl + msg.d;
            window.location.href = finalLink;
        }
    });

    //  alert(SelectedNews);
}
function GetInternationalHTMLBultan(element) {

    var $this = $(element);
    var parmin = $this.attr('data-parmin');
    GetSelectedInternationalNews();
    var fromDate = $('#txt_fromDate').val();

    var toDate = $('#txt_toDate').val();

    var fromTime = $('#txt_fromHour').val();
    var toTime = $('#txt_toHour').val();

    var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';

    var checkIsFehrest = $('#check_IsFehrest').attr('checked') ? 'true' : 'false';


    var bultanTitle = $("#txt_bultanTitle").val();



    var checkRujeld = $('#check_IsCover').attr('checked') ? 'true' : 'false';

    var linkUrl = window.location.protocol + "//" + window.location.hostname;

    if (window.location.port != null && window.location.port != '') {
        linkUrl += ":" + window.location.port;
    }

    //generate bultan archive
    $.ajax({

        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/SetBultanInternationalArchive",
        data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','bultanTitle': '" +
            bultanTitle + "','SelectedNews': '" + SelectedNews + "','fromTime':'" + fromTime + "','toTime':'" +
            toTime + "','highLight':'" + checkAllowHighlight + "','isArchive':'true','arz':'false','sima':'false','allowGroup':'false','jeld':'" + checkRujeld + "','BultanType':'4','linkUrl':'" + linkUrl + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {

            if (msg.d == null || msg.d == '') return;
            if (msg.d == 0) {
                alert('خطا در ساخت گزارش');
                return;
            }
            var finalLink = linkUrl + "/HtmlInternationalNews.aspx?ArchiveId=" + msg.d;

            window.location.href = finalLink;
        }
    });



}

function GetTamarkozHTMLBultan(element) {
    var $this = $(element);
    var parmin = $this.attr('data-parmin');
    // alert($this.attr('data-parmin'));
    GetSelectedTamarkozNews();
    var fromDate = $('#txt_fromDate').val();
    var toDate = $('#txt_toDate').val();
    var fromTime = $('#txt_fromHour').val();
    var toTime = $('#txt_toHour').val();
    var checkNewsPaper = $('#check_NewsPaper').attr('checked') ? 'true' : 'false';
    var CheckChart = $('#check_ChartKhabar').attr('checked') ? 'true' : 'false';
    var checkAllowArchive = $('#check_addArchive').attr('checked') ? 'true' : 'false';
    var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';
    var checkAllowRelated = $('#check_related').attr('checked') ? 'true' : 'false';
    var bultanTitle = $("#txt_bultanTitle").val();
    var bultanTemplate = $("#drp_template").val();
    var checkAllowGroup = $('#check_addGroup').attr('checked') ? 'true' : 'false';
    var checkAllowArz = $('#check_Arz').attr('checked') ? 'true' : 'false';
    var checkAllowSima = $('#check_Sima').attr('checked') ? 'true' : 'false';
    var checkAllowGalleryNewspaper = $('#check_GalleryNewspaper').attr('checked') ? 'true' : 'false';
    var checkRujeld = $('#check_rujeld').attr('checked') ? 'true' : 'false';

    var linkUrl = window.location.protocol + "//" + window.location.hostname;
    if (window.location.port != null && window.location.port != '') {
        linkUrl += ":" + window.location.port;
    }
    linkUrl = linkUrl + "/HtmlGroupNews.aspx?ArchiveId=";
    //generate bultan archive
    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/SetBultanArchive",
        data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','bultanTitle': '" +
            bultanTitle + "','SelectedNews': '" + SelectedNews + "','fromTime':'" + fromTime + "','toTime':'" +
            toTime + "','allowNewspaper':'" + checkNewsPaper + "','galleryNewspaper':'" +
            checkAllowGalleryNewspaper + "','arz':'" + checkAllowArz + "','sima':'" +
            checkAllowSima + "','highLight':'" + checkAllowHighlight + "','allowGroup':'" +
            checkAllowGroup + "','related':'" + checkAllowRelated + "','selectedBultan':'" +
            bultanTemplate + "','isArchive':'true','chart':'" + CheckChart + "','jeld':'" + checkRujeld + "','BultanType':'2','linkUrl':'" + linkUrl + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d == null || msg.d == '') return;
            if (msg.d == 0) {
                alert('خطا در ساخت گزارش');
                return;
            }
            var finalLink = linkUrl + msg.d;
            window.location.href = finalLink;
        }
    });

    //  alert(SelectedNews);
}


//
//function GetTamarkozHTMLBultan(element) {

//    var $this = $(element);
//    var parmin = $this.attr('data-parmin');
//    // alert($this.attr('data-parmin'));
    
//    GetSelectedTamarkozNews();
//    var fromDate = $('#txt_fromDate').val();
//    var toDate = $('#txt_toDate').val();
//    var fromTime = $('#txt_fromHour').val();
//    var toTime = $('#txt_toHour').val();

//    var checkNewsPaper = $('#check_NewsPaper').attr('checked') ? 'true' : 'false';
//    var CheckChart = $('#check_ChartKhabar').attr('checked') ? 'true' : 'false';
//    var checkAllowArchive = $('#check_addArchive').attr('checked') ? 'true' : 'false';
//    var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';
//    var checkAllowRelated = $('#check_related').attr('checked') ? 'true' : 'false';
//    var bultanTitle = $("#txt_bultanTitle").val();
//    var bultanTemplate = $("#drp_template").val();
//    var checkAllowGroup = $('#check_addGroup').attr('checked') ? 'true' : 'false';
//    var checkAllowArz = $('#check_Arz').attr('checked') ? 'true' : 'false';
//    var checkAllowSima = $('#check_Sima').attr('checked') ? 'true' : 'false';
//    var checkAllowGalleryNewspaper = $('#check_GalleryNewspaper').attr('checked') ? 'true' : 'false';
//    var checkRujeld = $('#check_rujeld').attr('checked') ? 'true' : 'false';

//    var linkUrl = window.location.protocol + "//" + window.location.hostname;
//    if (window.location.port != null && window.location.port != '') {
//        linkUrl += ":" + window.location.port;
//    }

//    //generate bultan archive
//    $.ajax({
//        type: "POST",
//        url: "/pages/p-art/pages/ajax.aspx/SetBultanArchive",
//        data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','bultanTitle': '" +
//            bultanTitle + "','SelectedNews': '" + SelectedNews + "','fromTime':'" + fromTime + "','toTime':'" +
//            toTime + "','allowNewspaper':'" + checkNewsPaper + "','galleryNewspaper':'" +
//            checkAllowGalleryNewspaper + "','arz':'" + checkAllowArz + "','sima':'" +
//            checkAllowSima + "','highLight':'" + checkAllowHighlight + "','allowGroup':'" +
//            checkAllowGroup + "','related':'" + checkAllowRelated + "','selectedBultan':'" +
//            bultanTemplate + "','isArchive':'true','chart':'" + CheckChart + "','jeld':'" + checkRujeld + "','BultanType':'3','linkUrl':'" + linkUrl + "'}",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (msg) {
//            if (msg.d == null || msg.d == '') return;
//            if (msg.d == 0) {
//                alert('خطا در ساخت گزارش');
//                return;
//            }
//            var finalLink = linkUrl + "/HtmlGroupNews.aspx?ArchiveId=" + msg.d;
//            window.location.href = finalLink;
//        }
//    });


//    //  alert(SelectedNews);
//}

function GetGroupInternationalTitrHTMLBultan(element) {
    var $this = $(element);
    var parmin = $this.attr('data-parmin');
    //alert($this.attr('data-parmin'));
    GetSelectedInternationalNews();
    var fromDate = $('#txt_fromDate').val();

    var toDate = $('#txt_toDate').val();

    var fromTime = $('#txt_fromHour').val();
    var toTime = $('#txt_toHour').val();

    var checkAllowHighlight = $('#check_highlight').attr('checked') ? 'true' : 'false';

    var checkIsFehrest = $('#check_IsFehrest').attr('checked') ? 'true' : 'false';


    var bultanTitle = $("#txt_bultanTitle").val();


    var linkUrl = window.location.protocol + "//" + window.location.hostname;
    if (window.location.port != null && window.location.port != '') {
        linkUrl += ":" + window.location.port;
    }

    //linkUrl = linkUrl + '/HtmlListNews.aspx?ArchiveId=';
    //alert(linkUrl);
    //generate bultan archive
    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/SetBultanInternationalArchive1",


        data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','bultanTitle': '" +
            bultanTitle + "','SelectedNews': '" + SelectedNews + "','fromTime':'" + fromTime + "','toTime':'" +
            toTime + "','highLight':'" + checkAllowHighlight + "','isArchive':'true','arz':'false','sima':'false','allowGroup':'false','BultanType':'4','linkUrl':'" + linkUrl + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d == null || msg.d == '') return;
            if (msg.d == 0) {
                alert('خطا در ساخت گزارش');
                return;
            }

            var finalLink = linkUrl + "/HtmlListNews.aspx?ArchiveId=" + msg.d;
            //var finalLink = linkUrl + msg.d;
            //alert(finalLink);
            window.location.href = finalLink;
        }
    });
}


function analyz_LoadDefaultKeywords() {
    try {
        $('.tagedit-listelement.tagedit-listelement-old').each(function (e) {
            $(this).remove();
        });
        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/GetKeywords",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                if (msg.d == null || msg.d == '') return;
                var result = msg.d.split('*.*');
                var keys = result[0].split(';');

                for (var i = 0; i <= keys.length - 1; i++) {

                    if (keys[i] != "") {
                        var li = "<li class='tagedit-listelement tagedit-listelement-old'><span dir='ltr'>" + keys[i] + "</span><input type='hidden' name='tag[]' value='" + keys[0] + "'><a class='tagedit-close' title='Remove from list.'>x</a></li>";

                        $(".keyword1 .tagedit-list").prepend(li);

                    }
                }

                keys = result[1].split(';');

                for (var i = 0; i <= keys.length - 1; i++) {

                    if (keys[i] != "") {
                        var li = "<li class='tagedit-listelement tagedit-listelement-old'><span dir='ltr'>" + keys[i] + "</span><input type='hidden' name='tag[]' value='" + keys[0] + "'><a class='tagedit-close' title='Remove from list.'>x</a></li>";

                        $(".keyword2 .tagedit-list").prepend(li);

                    }
                }

                //end chart
                //start analyz khabargozari

                //end analyz khabargozari
            }
        });
    }
    catch (e) { }
}
function showModal() {
    $(".bg-modal").css("display", "block");
}
function CloseModal() {
    $(".bg-modal").css("display", "none");
}
function analyz_LoadKeywords(fromdate, todate, callback) {

    
    var keyCount = $(".keyword1 .tagedit-list li").size();


    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        var percentMax = 0;
        percentMax = 100 / keyCount;

       
        var liCounter = 0;
        $('#keys-result .table-report1').css("display", "block");
        $('#keys-result .table-report1').attr('style', '');
        $('#keys-result .table-report1 tr').attr('style', '');
        $('#keys-result .table-report1 th').attr('style', '');
        $('#keys-result .table-report1 td').attr('style', '');

        $('#keys-result .table-report1 tr:not(:has(th))').remove();

        $("#progress1").animate({ width: 0 }, 400);
        var listIndex = 1;
        $(".keyword1 .tagedit-list li").each(function () {
            var keyWord = $(this).find("span").html();
            if (keyWord != null) {
                keywords += keyWord + "|";
                
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/AnalyzWords",
                    data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'0','index':'" + listIndex + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        liCounter++;
                        percentLoaded += percentMax;
                        //$('#keys-result .table-report1 > tbody:last').append();
                        $("#keys-result .table-report1 tbody").append("<tr><td>" + keyWord + "</td><td>" + msg.d[0] + "</td><td>" + msg.d[1] + "</td><td>" + msg.d[2] + "</td><td>" + (parseInt(msg.d[0]) + parseInt(msg.d[1]) + parseInt(msg.d[2])) + "</td></tr>");

                        $("#progress1").animate({ width: percentLoaded + '%' }, 400);
                        if (liCounter == keyCount) {
                            $('#keys-result .table-report1').tableSort({
                                animation: 'fade',
                                speed: 250,
                                delay: 25
                            });
                        }
                    }
                });

            }

            listIndex = listIndex + 1;
        });
        analyz_SaveKeywords();


    }
    if (callback) {
        callback();
    }
    //callback.call();
}
function analyz_LoadKeywords_Social(fromdate, todate, callback) {


    var keyCount = $(".keyword1 .tagedit-list li").size();


    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        var percentMax = 0;
        percentMax = 100 / keyCount;

        var liCounter = 0;
        $('#keys-result .table-report1').css("display", "block");
        $('#keys-result .table-report1').attr('style', '');
        $('#keys-result .table-report1 tr').attr('style', '');
        $('#keys-result .table-report1 th').attr('style', '');
        $('#keys-result .table-report1 td').attr('style', '');

        $('#keys-result .table-report1 tr:not(:has(th))').remove();

        $("#progress1").animate({ width: 0 }, 400);
        var listIndex = 1;
        $(".keyword1 .tagedit-list li").each(function () {
            var keyWord = $(this).find("span").html();
            if (keyWord != null) {
                keywords += keyWord + "|";
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/AnalyzWordsSocial",
                    data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'0','index':'" + listIndex + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        liCounter++;
                        percentLoaded += percentMax;
                        //$('#keys-result .table-report1 > tbody:last').append();
                        $("#keys-result .table-report1 tbody").append("<tr><td>" + keyWord + "</td><td>" + msg.d[0] + "</td></tr>");

                        $("#progress1").animate({ width: percentLoaded + '%' }, 400);
                        if (liCounter == keyCount) {
                            $('#keys-result .table-report1').tableSort({
                                animation: 'fade',
                                speed: 250,
                                delay: 25
                            });
                        }
                    }
                });

            }

            listIndex = listIndex + 1;
        });
        analyz_SaveKeywords();
        if (callback) {
            callback();
        }

    }
    //callback.call();
}
function analyz_LoadUsers_Social(fromdate, todate, callback) {
  
    var keyCount = $(".keyword1 .tagedit-list li").size();
    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        //var percentMax = 0;
        //percentMax = 100 / keyCount;
        var liCounter = 0;
        //$('#keys-result .table-report3').css("display", "block");

        $("#progress3").animate({ width: 0 }, 400);
        var listIndex = 1;

        $.ajax({
            type: "POST",
            url: "/pages/P-Art/Pages/SocialAnalyz.aspx/AnalyzUsersSocial",
            data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                newData = [];

                for (var i = 0; i < data.d.length; i++) {
                    newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);
                    $("#keys-result .table-report3 tbody").append("<tr><td>" + data.d[i].Name + "</td><td class=\"persian\">" + parseInt(data.d[i].Value) + "</td></tr>");
                }
                $("#progress3").animate({ width: percentLoaded + '%' }, 400);
                //if (liCounter == keyCount) {
                //    $('#keys-result .table-report3').tableSort({
                //        animation: 'fade',
                //        speed: 250,
                //        delay: 25
                //    });
                //}
            }
        });

        if (callback) {
            callback();
        }

    }
}
function analyz_LoadKeywords2(fromdate, todate, callback) {


    var keyCount = $(".keyword1 .tagedit-list li").size();


    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        var percentMax = 0;
        percentMax = 100 / keyCount;

        var liCounter = 0;

        //$('#keys-result .table-report2').css("display", "block");
        //$('#keys-result .table-report2').attr('style', '');
        //$('#keys-result .table-report2 tr').attr('style', '');
        //$('#keys-result .table-report2 th').attr('style', '');
        //$('#keys-result .table-report2 td').attr('style', '');

        //$('#keys-result .table-report2 tr:not(:has(th))').remove();
        $("#progress11").animate({ width: 0 }, 400);
        var listIndex = 1;

        $(".keyword1 .tagedit-list li").each(function () {
            var keyWord = $(this).find("span").html();

            if (keyWord != null) {
                keywords += keyWord + "|";
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/AnalyzWords",
                    data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'1','index':'" + listIndex + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        liCounter++;
                        percentLoaded += percentMax;
                        //$('#keys-result .table-report1 > tbody:last').append();

                        $("#keys-result .table-report2 tbody").append("<tr><td>" + keyWord + "</td><td>" + parseInt(msg.d[0]) + "</td></tr>");
                        $("#progress11").animate({ width: percentLoaded + '%' }, 400);
                        if (liCounter == keyCount) {

                            $('#keys-result .table-report2').tableSort({
                                animation: 'fade',
                                speed: 250,
                                delay: 25
                            });
                        }
                    }
                });

            }

            listIndex = listIndex + 1;
        });
        analyz_SaveKeywords();
        if (callback) {
            callback();
        }

    }
    //callback.call();
}
function analyz_LoadKeywords2_social(fromdate, todate, callback) {


    var keyCount = $(".keyword1 .tagedit-list li").size();


    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        var percentMax = 0;
        percentMax = 100 / keyCount;

        var liCounter = 0;

        $('#keys-result .table-report2').css("display", "block");
        $('#keys-result .table-report2').attr('style', '');
        $('#keys-result .table-report2 tr').attr('style', '');
        $('#keys-result .table-report2 th').attr('style', '');
        $('#keys-result .table-report2 td').attr('style', '');

        $('#keys-result .table-report2 tr:not(:has(th))').remove();
        $("#progress11").animate({ width: 0 }, 400);
        var listIndex = 1;

        $(".keyword1 .tagedit-list li").each(function () {
            var keyWord = $(this).find("span").html();

            if (keyWord != null) {
                keywords += keyWord + "|";
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/AnalyzWordsSocial",
                    data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'1','index':'" + listIndex + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        liCounter++;
                        percentLoaded += percentMax;
                        //$('#keys-result .table-report1 > tbody:last').append();

                        $("#keys-result .table-report2 tbody").append("<tr><td>" + keyWord + "</td><td>" + parseInt(msg.d[0]) + "</td></tr>");
                        $("#progress11").animate({ width: percentLoaded + '%' }, 400);
                        if (liCounter == keyCount) {

                            $('#keys-result .table-report2').tableSort({
                                animation: 'fade',
                                speed: 250,
                                delay: 25
                            });
                        }
                    }
                });

            }

            listIndex = listIndex + 1;
        });
        analyz_SaveKeywords();
        if (callback) {
            callback();
        }

    }
    //callback.call();
}
function analyz_SaveKeywords() {


    var keywords = "";
    $(".keyword1 .tagedit-list li").each(function () {
        if ($(this).find("span").html() != null) {
            keywords += $(this).find("span").html() + ";";
        }
    });
    keywords += "*.*";

    $(".keyword2 .tagedit-list li").each(function () {
        if ($(this).find("span").html() != null) {
            keywords += $(this).find("span").html() + ";";
        }
    });


    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/SaveKeywords",
        data: "{'keywords': '" + keywords + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {



            //end chart
            //start analyz khabargozari

            //end analyz khabargozari
        }
    });
}
function analyz_LoadChart1(fromdate, todate, callback) {

    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzKhabargozari",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            newData = [];
            //var dictionary = {};

            //var data = new google.visualization.DataTable();
            //data.addColumn('string', 'آرا');
            //data.addColumn('number', 'تعداد رای');
            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }

            $("#progress2").animate({ width: '100%' }, 400);
            //start chart
            $('#chart1').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a'
                    },
                    height: 400,
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    marginRight: 0,
                    marginTop: 0,
                    marginBottom: 0,
                    marginLeft: 0
                },
                title: {
                    text: ''
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {

                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',

                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: "{point.name}: {point.percentage:.1f} %"
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Browser share',

                    data: newData

                }]
            });

            if (callback) callback();
        }
    });
}
function analyz_LoadChart2(fromdate, todate, callback) {


    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzChartKhabargozari",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'1'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data2) {
            newData2 = [];

            for (var i = 0; i < data2.d.length; i++) {

                newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

            }
            $("#progress3").animate({ width: '100%' }, 400);
            $('#chart2').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a',
                    },
                    height: 900,
                    type: 'bar',
                    backgroundColor: 'transparent'
                },
                xAxis: {
                    type: 'category'
                },
                yAxis: {
                    title: {
                        text: ''
                    }
                },
                title: {
                    text: ''
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: "{point.name}: {point.percentage:.1f} %",
                            backgroundColor: 'transparent'
                        }
                    }
                },
                series: [{
                    type: 'bar',
                    name: '',

                    data: newData2

                }]
            });

            if (callback) callback();
        }
    });
}
function analyz_LoadChart3(fromdate, todate, callback) {
    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzChartKhabargozari",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'2'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data2) {
            newData2 = [];

            for (var i = 0; i < data2.d.length; i++) {

                newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);
            }
            $("#progress4").animate({ width: '100%' }, 400);
            $('#chart4').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a'
                    },
                    height: 900,
                    type: 'bar',
                    backgroundColor:'transparent'

                },
                xAxis: {
                    type: 'category'
                },
                yAxis: {
                    title: {
                        text: ''
                    }
                },
                title: {
                    text: ''
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: "{point.name}: {point.percentage:.1f} %"
                        }
                    }
                },
                series: [{
                    type: 'column',
                    name: 'Browser share',

                    data: newData2

                }]
            });

            if (callback) callback();
        }
    });
}
function analyz_LoadKeywordsChart(fromdate, todate, callback) {


    var keyCount = $(".keyword1 .tagedit-list li").size();
    newData2 = [];

    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        var percentMax = 0;
        percentMax = 100 / keyCount;

        var liCounter = 0;

        $("#progress1").animate({ width: 0 }, 400);
        $(".keyword1 .tagedit-list li").each(function (index) {
            var keyWord = $(this).find("span").html();
            if (keyWord != null) {
                keywords += keyWord + "|";
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/AnalyzWords",
                    data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'0','index':'0'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        liCounter++;
                        percentLoaded += percentMax;

                        $("#progress5").animate({ width: percentLoaded + '%' }, 400);

                        newData2.push([keyWord, parseInt(msg.d[2])]);

                        if (liCounter == keyCount) {
                            analyz_SaveKeywords();
                            $('#chart5').highcharts({
                                chart: {
                                    style: {
                                        fontFamily: 'Conv_BTrafficBold',
                                        color: '#72777a'
                                    },
                                    type: 'bar',
                                    backgroundColor: 'transparent'
                                },
                                xAxis: {
                                    type: 'category',
                                    rotation: -45
                                },
                                yAxis: {
                                    title: {
                                        text: ''
                                    }
                                },
                                title: {
                                    text: ''
                                },
                                legend: {
                                    enabled: false
                                },
                                tooltip: {
                                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                                },
                                plotOptions: {
                                    pie: {
                                        allowPointSelect: true,
                                        cursor: 'pointer',
                                        dataLabels: {
                                            enabled: true,
                                            rotation: -90,
                                            color: '#FFFFFF',
                                            align: 'right',
                                            x: 4,
                                            y: 10,
                                            style: {
                                                fontSize: '13px',
                                                fontFamily: 'Verdana, sans-serif',
                                                textShadow: '0 0 3px black'
                                            }
                                        }
                                    }
                                },
                                series: [{
                                    type: 'column',
                                    name: 'روابط عمومی استان ها',

                                    data: newData2

                                }]
                            });


                        }

                    }
                });

            }
        });


        if (callback) {
            callback();
        }

    }
    //callback.call();
}
function analyz_LoadKeywordsChartSocial(fromdate, todate, callback) {


    var keyCount = $(".keyword1 .tagedit-list li").size();
    newData2 = [];

    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        var percentMax = 0;
        percentMax = 100 / keyCount;

        var liCounter = 0;

        $("#progress1").animate({ width: 0 }, 400);
        $(".keyword1 .tagedit-list li").each(function (index) {
            var keyWord = $(this).find("span").html();
            if (keyWord != null) {
                keywords += keyWord + "|";
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/AnalyzWordsSocial",
                    data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'0','index':'0'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        liCounter++;
                        percentLoaded += percentMax;

                        $("#progress5").animate({ width: percentLoaded + '%' }, 400);

                        newData2.push([keyWord, parseInt(msg.d[2])]);

                        if (liCounter == keyCount) {
                            analyz_SaveKeywords();
                            $('#chart5').highcharts({
                                chart: {
                                    style: {
                                        fontFamily: 'Conv_BTrafficBold',
                                        color: '#72777a'
                                    },
                                    type: 'bar',
                                    backgroundColor: 'transparent'
                                },
                                xAxis: {
                                    type: 'category',
                                    rotation: -45
                                },
                                yAxis: {
                                    title: {
                                        text: ''
                                    }
                                },
                                title: {
                                    text: ''
                                },
                                legend: {
                                    enabled: false
                                },
                                tooltip: {
                                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                                },
                                plotOptions: {
                                    pie: {
                                        allowPointSelect: true,
                                        cursor: 'pointer',
                                        dataLabels: {
                                            enabled: true,
                                            rotation: -90,
                                            color: '#FFFFFF',
                                            align: 'right',
                                            x: 4,
                                            y: 10,
                                            style: {
                                                fontSize: '13px',
                                                fontFamily: 'Verdana, sans-serif',
                                                textShadow: '0 0 3px black'
                                            }
                                        }
                                    }
                                },
                                series: [{
                                    type: 'column',
                                    name: 'روابط عمومی استان ها',

                                    data: newData2

                                }]
                            });


                        }

                    }
                });

            }
        });


        if (callback) {
            callback();
        }

    }
    //callback.call();
}
function analyz_LoadChart4(fromdate, todate, callback) {

    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzNewsValue",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            newData = [];
            //var dictionary = {};

            //var data = new google.visualization.DataTable();
            //data.addColumn('string', 'آرا');
            //data.addColumn('number', 'تعداد رای');
            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }

            $("#progress6").animate({ width: '100%' }, 400);
            //start chart
            $('#chart6').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a'
                    },
                    backgroundColor:'transparent',
                    height:400,
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    marginRight: 0,
                    marginTop: 0,
                    marginBottom: 0,
                    marginLeft: 0
                },
                title: {
                    text: ''
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {

                        allowPointSelect: true,
                        cursor: 'pointer',

                        dataLabels: {

                            enabled: true,
                            color: '#000000',
                            connectorColor: '#000000',
                            format: "{point.name}: {point.percentage:.1f} %"
                        }
                    }
                },
                series: [{

                    type: 'pie',
                    name: 'Browser share',

                    data: newData

                }]
            });

            if (callback) callback();
        }
    });
}
function analyz_LoadChart4_social(fromdate, todate, callback) {

    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzNewsValueSocial",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            newData = [];
            //var dictionary = {};

            //var data = new google.visualization.DataTable();
            //data.addColumn('string', 'آرا');
            //data.addColumn('number', 'تعداد رای');
            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }

            $("#progress6").animate({ width: '100%' }, 400);
            //start chart
            $('#chart6').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a',

                    },
                    backgroundColor: 'transparent',
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: 800
                },
                xAxis: {
                    type: 'category',
                    rotation: -45
                },
                yAxis: {
                    title: {
                        text: ''
                    }
                },
                credits: { enabled: false },
                stackLabels: {
                    enabled: true,
                    style: {
                        fontWeight: 'bold',
                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                    }
                },
                title: {
                    text: '',
                    style:
                    {
                        color: '#72777a',
                        fontWeight: 'bold',
                        fontSize: '14px'
                    }
                },
                legend: {
                    enabled: true,
                    layout: 'vertical',
                    align: 'top',
                    itemWidth: 120,
                    padding: 10,
                    itemmargintop: 5,
                    itemmarginbottom: 5,
                    itemstyle:
                        {
                            lineheight: '14px'
                        },
                    useHTML: true,
                    labelFormatter: function () {
                        return '<div style="top:-4px; position:relative;">' + this.name + ' [ ' + this.y + ' عدد]</div>';
                    },

                },
                dataLabels: {

                },
                tooltip: {
                    pointFormat: '<b>{point.percentage:.1f}%</b>',
                    shared: true,
                    useHTML: true,


                },
                plotOptions: {
                    pie: {
                        size: '70%',
                        allowPointSelect: true,
                        cursor: 'pointer',
                        showInLegend: true,
                        dataLabels: {
                            enabled: true,
                            format: '<span>{point.percentage:.1f} %</span>',
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                fontWeight: '100',
                                fontSize: '14px'

                            },
                            x: 33,
                            distance: -30,
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
                    name: '',
                    data: newData,
                    stake: ''


                }]
            });

            if (callback) callback();
        }
    });
}
function analyz_LoadChartUsers_social(fromdate, todate, callback) {

    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzUsersValueSocial",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            newData = [];
            //var dictionary = {};

            //var data = new google.visualization.DataTable();
            //data.addColumn('string', 'آرا');
            //data.addColumn('number', 'تعداد رای');
            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }

            $("#progress7").animate({ width: '100%' }, 400);
            //start chart
            $('#chart7').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a',

                    },
                    backgroundColor: 'transparent',
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie',
                    height: 800
                },
                xAxis: {
                    type: 'category',
                    rotation: -45
                },
                yAxis: {
                    title: {
                        text: ''
                    }
                },
                credits: { enabled: false },
                stackLabels: {
                    enabled: true,
                    style: {
                        fontWeight: 'bold',
                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                    }
                },
                title: {
                    text: '',
                    style:
                    {
                        color: '#72777a',
                        fontWeight: 'bold',
                        fontSize: '14px'
                    }
                },
                legend: {
                    enabled: true,
                    layout: 'vertical',
                    align: 'top',
                    itemWidth: 120,
                    padding: 10,
                    itemmargintop: 5,
                    itemmarginbottom: 5,
                    itemstyle:
                        {
                            lineheight: '14px'
                        },
                    useHTML: true,
                    labelFormatter: function () {
                        return '<div style="top:-4px; position:relative;">[' + this.y +' ]  ' + this.name + '</div>';
                    },

                },
                dataLabels: {

                },
                tooltip: {
                    pointFormat: '<b>{point.percentage:.1f}%</b>',
                    shared: true,
                    useHTML: true,


                },
                plotOptions: {
                    pie: {
                        size: '70%',
                        allowPointSelect: true,
                        cursor: 'pointer',
                        showInLegend: true,
                        dataLabels: {
                            enabled: true,
                            format: '<span>{point.percentage:.1f} %</span>',
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                fontWeight: '100',
                                fontSize: '14px'

                            },
                            x: 33,
                            distance: -30,
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
                    name: '',
                    data: newData,
                    stake: ''


                }]
            });

            if (callback) callback();
        }
    });
}


function analyz_LoadChart5(fromdate, todate, callback) {
    newData = [];
    newData2 = [];

    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'1','newsValue':' = 1'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {


            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }


            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'1','newsValue':' = 2'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data2) {


                    for (var i = 0; i < data2.d.length; i++) {

                        newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

                    }
                    $("#progress7").animate({ width: '100%' }, 400);
                    $('#chart7').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a'
                            },
                            backgroundColor:'transparent',
                            height: 900,
                            type: 'bar'
                        },
                        xAxis: {
                            type: 'category',
                            rotation: -45
                        },
                        yAxis: {
                            title: {
                                text: ''
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
                            pointFormat: '<div style="direction:rtl;text-align:right"><span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/></div>',
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
                            type: 'column',
                            name: 'اخبار مثبت',
                            data: newData,
                            stake: 'اخبار مثبت'

                        }, {
                            type: 'column',
                            name: 'اخبار منفی',
                            data: newData2,
                            stake: 'اخبار منفی'

                        }]
                    });


                }
            });
            //$("#progress7").animate({ width: '100%' }, 400);
            //start chart


            if (callback) callback();
        }
    });
}
function analyz_LoadChart6(fromdate, todate, callback) {
    newData = [];
    newData2 = [];

    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'2','newsValue':' = 1'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {


            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }


            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/ChartNewsValue",
                data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','type':'2','newsValue':' = 2'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data2) {


                    for (var i = 0; i < data2.d.length; i++) {

                        newData2.push([data2.d[i].Name, parseInt(data2.d[i].Value)]);

                    }
                    $("#progress8").animate({ width: '100%' }, 400);
                    $('#chart8').highcharts({
                        chart: {
                            style: {
                                fontFamily: 'Conv_BTrafficBold',
                                color: '#72777a'
                            },
                            height: 900,
                            type: 'bar',
                            backgroundColor: 'transparent'
                        },
                        xAxis: {
                            type: 'category',
                            rotation: -45
                        },
                        yAxis: {
                            title: {
                                text: ''
                            }
                        },
                        title: {
                            text: ''
                        },
                        legend: {
                            enabled: false
                        },
                        tooltip: {
                            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                        },
                        plotOptions: {
                            pie: {
                                allowPointSelect: true,
                                cursor: 'pointer',
                                dataLabels: {
                                    enabled: true,
                                    rotation: -90,
                                    color: '#FFFFFF',
                                    align: 'right',
                                    x: 4,
                                    y: 10,
                                    style: {
                                        fontSize: '13px',
                                        fontFamily: 'Verdana, sans-serif',
                                        textShadow: '0 0 3px black'
                                    }
                                }
                            }
                        },
                        series: [{
                            type: 'column',
                            name: 'اخبار مثبت',

                            data: newData

                        }, {
                            type: 'column',
                            name: 'اخبار منفی',

                            data: newData2

                        }]
                    });


                }
            });
            //$("#progress7").animate({ width: '100%' }, 400);
            //start chart


            if (callback) callback();
        }
    });
}
function analyz_LoadChart9(fromdate, todate, callback) {


    var keyCount = $(".keyword2 .tagedit-list li").size();
    newData2 = [];

    var keywords = "";
    if (keyCount > 0) keyCount--;
    if (keyCount > 0) {
        var percentLoaded = 0;
        var percentMax = 0;
        percentMax = 100 / keyCount;

        var liCounter = 0;

        $("#progress9").animate({ width: 0 }, 400);
        $(".keyword2 .tagedit-list li").each(function (index) {
            var keyWord = $(this).find("span").html();
            if (keyWord != null) {
                keywords += keyWord + "|";
                $.ajax({
                    type: "POST",
                    url: "/pages/p-art/pages/ajax.aspx/AnalyzWords",
                    data: "{'word': '" + keyWord + "','fromDate':'" + fromdate + "','toDate':'" + todate + "','sourceType':'0','index':'0'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        liCounter++;
                        percentLoaded += percentMax;

                        $("#progress9").animate({ width: percentLoaded + '%' }, 400);

                        newData2.push([keyWord, parseInt(msg.d[2])]);

                        if (liCounter == keyCount) {
                            analyz_SaveKeywords();
                            $('#chart9').highcharts({
                                chart: {
                                    style: {
                                        fontFamily: 'Conv_BTrafficBold',
                                        color: '#72777a'
                                    },
                                    backgroundColor:'transparent',
                                    plotBackgroundColor: null,
                                    plotBorderWidth: null,
                                    plotShadow: false,
                                    marginRight: 0,
                                    marginTop: 0,
                                    marginBottom: 0,
                                    marginLeft: 0,
                                    height:600
                                },
                                title: {
                                    text: ''
                                },
                                tooltip: {
                                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                                },
                                plotOptions: {
                                    pie: {
                                        allowPointSelect: true,
                                        cursor: 'pointer',
                                        dataLabels: {
                                            enabled: true,
                                            color: '#000000',
                                            connectorColor: '#000000',
                                            format: "{point.name}: {point.percentage:.1f} %"
                                        }
                                    }
                                },
                                series: [{
                                    type: 'pie',
                                    name: 'Browser share',

                                    data: newData2

                                }]
                            });


                        }

                    }
                });

            }


        });



        if (callback) {
            callback();
        }

    }
    //callback.call();
}
function analyz_LoadChart10(fromdate, todate, callback) {
    newData = [];


    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzOstan",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "','keyword':'روابط عمومی'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {


            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }
            $("#progress10").animate({ width: '100%' }, 400);
            $('#chart10').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a'
                    },
                    height: 900,
                    type: 'bar',
                    backgroundColor: 'transparent'
                },
                xAxis: {
                    type: 'category',
                    rotation: -45
                },
                yAxis: {
                    title: {
                        text: ''
                    }
                },
                title: {
                    text: ''
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',

                        dataLabels: {
                            enabled: true,
                            rotation: -90,
                            color: '#FFFFFF',
                            align: 'right',
                            x: 4,
                            y: 10,
                            style: {
                                fontSize: '13px',
                                fontFamily: 'Verdana, sans-serif',
                                textShadow: '0 0 3px black'
                            }
                        }
                    }
                },
                series: [{
                    type: 'column',
                    name: 'روابط عمومی استان ها',

                    data: newData

                }]
            });
            //$("#progress7").animate({ width: '100%' }, 400);
            //start chart


            if (callback) callback();
        }
    });
}

function analyz_LoadChart12(fromdate, todate, callback) {
    newData = [];


    $.ajax({
        type: "POST",
        url: "/pages/p-art/pages/ajax.aspx/AnalyzOstanpr",
        data: "{'fromDate':'" + fromdate + "','toDate':'" + todate + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {


            for (var i = 0; i < data.d.length; i++) {

                newData.push([data.d[i].Name, parseInt(data.d[i].Value)]);

            }
            $("#progress12").animate({ width: '100%' }, 400);
            $('#chart12').highcharts({
                chart: {
                    style: {
                        fontFamily: 'Conv_BTrafficBold',
                        color: '#72777a'
                    },
                    height: 900,
                    type: 'bar',
                    backgroundColor: 'transparent'
                },
                xAxis: {
                    type: 'category',
                    rotation: -45
                },
                yAxis: {
                    title: {
                        text: ''
                    }
                },
                title: {
                    text: ''
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            rotation: -90,
                            color: '#FFFFFF',
                            align: 'right',
                            x: 4,
                            y: 10,
                            style: {
                                fontSize: '13px',
                                fontFamily: 'Verdana, sans-serif',
                                textShadow: '0 0 3px black'
                            }
                        }
                    }
                },
                series: [{
                    type: 'column',
                    name: 'استان ها',

                    data: newData

                }]
            });

            //$("#progress7").animate({ width: '100%' }, 400);
            //start chart


            if (callback) callback();
        }
    });
}
function finishAnalyz() {
    $("#box-waiting").slideUp(700);
}
function MenuClose() {


    $("#setting").animate({ height: '0' }, 500);
    $("#setting ul").animate({ height: '0' }, 500, function () {

        $("#setting").css("display", "none");
        MenuStatus = false;
    })
};
function SetOrder() {
    //alert('ok3');
    var lastIndex = 0;
    $(".switchkeyword").each(function (index, value) {

        var groupId = $(this).attr("data-id");



        $(".posts article[data-id='" + groupId + "']").each(function (index2, value2) {
            $(this).attr("data-order", lastIndex);
            lastIndex = lastIndex + 1;
        });


    });

    var $fields, $container, sorted, index;

    $container = $('.posts');
    $fields = $("article[data-order]", $container);
    sorted = [];
    $fields.detach().each(function () {
        sorted[parseInt(this.getAttribute("data-order"), 10)] = this;
    });
    for (index in sorted) {
        if (String(Number(index)) === index) {
            $container.append(sorted[index]);
        }
    }

}


function SetOrder1() {
    //alert('1');
    var lastIndex = 0;
    $(".switchkeyword1").each(function (index, value) {

        var groupId = $(this).attr("data-id");
        //alert(groupId);


        $(".posts1 article[data-id='" + groupId + "']").each(function (index2, value2) {
            //alert('2');
            $(this).attr("data-order", lastIndex);
            lastIndex = lastIndex + 1;
        });


    });

    var $fields, $container, sorted, index;

    $container = $('.posts1');
    $fields = $("article[data-order]", $container);
    sorted = [];
    $fields.detach().each(function () {
        //alert('3');
        sorted[parseInt(this.getAttribute("data-order"), 10)] = this;
    });
    for (index in sorted) {
        if (String(Number(index)) === index) {
            $container.append(sorted[index]);
        }
    }

}




function GetSocialSelectedNews() {

    SelectedNews = ",";
    $(".posts1 article.show").each(function () {


        var postRow = $(this);

        var newsId = $(postRow).find("#hddNewsId").val();
        var newsIndex = $(postRow).find("#txt_row_index").val();
        if (newsIndex == "") newsIndex = "1000";
        if ($(postRow).find("#check_SelectNews").attr("checked")) {


            SelectedNews += newsId + ";" + newsIndex + ",";

        }


    });


}



function GetSelectedNews() {
    SelectedNews = ",";
    $(".posts article.show").each(function () {

        var postRow = $(this);
        var newsId = $(postRow).find("#fld_newsId").val();
        var newsIndex = $(postRow).find("#txt_row_index").val();

        if (newsIndex == "") newsIndex = "1000";
        if ($(postRow).find("#check_SelectNews").attr('checked')) {
            SelectedNews += newsId + ";" + newsIndex + ",";
        }

    });
}
function GetSelectedInternationalNews() {
    SelectedNews = ",";
    $(".Fehrest div.showFehrest").each(function () {


        var postRow = $(this);
        //alert(postRow);
        var newsId = $(postRow).find("#hddNewsId").val();
        //alert(newsId);
        var newsIndex = $(postRow).find("#txt_row_index").val();

        if (newsIndex == "") newsIndex = "1000";
        if ($(postRow).find("#check_SelectNews").attr('checked')) {


            SelectedNews += newsId + ";" + newsIndex + ",";
            // alert(SelectedNews);
        }


    });


}
function GetSelectedTamarkozNews() {
    SelectedNews = ",";
    $(".posts article.show").each(function () {


        var postRow = $(this);
        var newsId = $(postRow).find("#fld_newsId").val();

        var newsIndex = $(postRow).find("#txt_row_index").val();

        if (newsIndex == "") newsIndex = "1000";
        if ($(postRow).find("#check_SelectNewsTamarkoz").attr('checked')) {


            SelectedNews += newsId + ";" + newsIndex + ",";


            $(".RelatedBody .body-item").each(function () {


                var postRow = $(this);
                var newsId = $(postRow).find("#fld_newsId").val();
                if ($(postRow).find("#check_SelectNewsTamarkoz").attr('checked')) {
                    SelectedNews += newsId + ";" + "1000" + ",";
                }
            });

        }
    });



}

function GetSelectedTamarkozNews1() {
    SelectedNews = ",";
    $(".posts  .showFehrest1").each(function () {

        //alert('ok');
        var postRow = $(this);
        var newsId = $(postRow).find("#hddNewsId").val();
        var newsIndex = $(postRow).find("#txt_row_index").val();

        if (newsIndex == "") newsIndex = "1000";
        if ($(postRow).find("#check_SelectNewsTamarkoz").attr('checked')) {

            // alert('ok2');
            SelectedNews += newsId + ";" + newsIndex + ",";


            $(".showFehrest1 .post-fehrest1").each(function () {

                // alert('ok3');
                var postRow = $(this);
                var newsId = $(postRow).find("#hddNewsId").val();
                if ($(postRow).find("#check_SelectNewsTamarkoz").attr('checked')) {
                    // alert('ok4');
                    SelectedNews += newsId + ";" + "1000" + ",";

                }
            });

        }
    });



}


function SetOrderIndexName() {
    //alert('okkk');
    var catIndex = 0;
    $(".group_item").each(function () {

        var currentCat = $(this);
        var catId = $(currentCat).find("a").attr("data-id");
        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/SetCategoryIndex",
            data: "{'catId':'" + catId + "','catIndex':'" + catIndex + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {


            },
            error: function (msg) {

            }

        });

        catIndex = catIndex + 1;

    });
    var index = 1;
    $(".post-content").each(function () {
        var postRow = $(this);
        var newsId = $(postRow).find("#fld_newsId").val();

        $(this).find("span:first").html(index + " )")

        index = index + 1;
    });
}


function SetOrderIndexName1() {
    var catIndex = 0;
    $(".control-box1 .group_item").each(function () {
        //alert('ok');
        var currentCat = $(this);
        var catId = $(currentCat).find("a").attr("data-id");
        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/SetCategoryIndex1",
            data: "{'catId':'" + catId + "','catIndex':'" + catIndex + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {


            },
            error: function (msg) {

            }

        });

        catIndex = catIndex + 1;

    });
    var index = 1;
    $(".post-content").each(function () {
        var postRow = $(this);
        var newsId = $(postRow).find("#hddNewsId").val();

        $(this).find("span:first").html(index + " )")

        index = index + 1;
    });
}



function SetSelectedNews(callback) {

    if (SelectedNews == "") return;

    $(".post-content").each(function () {
        var postRow = $(this);
        var newsId = $(postRow).find("#fld_newsId").val();

        if (SelectedNews.indexOf("," + newsId + ",") > -1) {
            $(postRow).find("#check_SelectNews").attr('checked', true);

        } else {
            $(postRow).find("#check_SelectNews").attr('checked', false);

        }




    });

    if (callback) {
        callback();
    }
}