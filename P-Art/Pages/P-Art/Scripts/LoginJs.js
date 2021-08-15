var isLeftOpen = false;
$(document).ready(function () {
    $("html").click(function () {

        $("#aboutBox").css("height", "0");
        $("#contactBox").css("height", "0");
    });
    $("#header-links a").click(function (e) {

        var href = $(this).attr("href");
        //alert(href);
        switch (href) {
            case "/about":
                $("#aboutBox").animate({ height: '220px' }, 500);
                break;
            case "/contact":
                $("#contactBox").animate({ height: '172px' }, 500);
                break;
        }
        e.preventDefault();

    });
    $("#rightMenu .navMenu ul li .navItem").hover(function (e) {
        $(this).animate({ 'backgroundColor': 'rgba(44, 44, 44, 0.70)' }, 300);

    }, function (e) {
        $(this).animate({ 'backgroundColor': 'rgba(44, 44, 44, 0)' }, 300);
    });

    $("#rightMenu .navMenu ul li .navItem > a").click(function (e) {
        var itemId = $(this).attr("itemid");
        var image = $(this).find("img").attr("src");


        if (isLeftOpen == true) {
            //$('#detailContent .ItemTitle').css("display", "none");
            //$("#detailContent").fadeOut(500, function () {

            //    $("#rightMenu").animate({ bottom: '42px' }, 1000, 'easeOutQuint', function () {



            //        $("#leftMenu").animate({ right: '-100%' }, 1500, 'easeOutQuint', function () {
            //            $("#leftMenu").animate({ right: '0%' }, 1500, 'easeOutQuint', function () {
            StartContent(itemId, image);
            //            });
            //            isLeftOpen = true;
            //        });
            //    });
            //});
        }
        else {
            $("#rightMenu").animate({ bottom: '42px' }, 1000, 'easeOutQuint', function () {

                $("#leftMenu").animate({ right: '0%' }, 1500, 'easeOutQuint', function () {
                    StartContent(itemId, image);

                });
            });
            isLeftOpen = true;

        }

        e.preventDefault();
    });

    $("#txt_UserName,#txt_Password").keypress(function (event) {
        if (event.which == 13) {
            $("#btn_Login").click();
        }
    });
    function StartContent(itemId, image) {


        //$('#detailContent .ItemTitle').unbind('marquee');

        //$('#detailContent .ItemTitle').css("left", "-1000px");

        $.ajax({
            type: "POST",
            url: "/pages/p-art/pages/ajax.aspx/GetLastPanelNews",
            data: "{'panelId':'" + itemId + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                $("#merqueeText").html(msg.d);
                //$('#detailContent .ItemTitle').css("display","block");

                $("#merqueeImage img").attr("src", image);

                document.getElementById("merqueeText").outerHTML = "<marquee onmouseover='this.stop();' onmouseout='this.start();' class='ItemTitle' scrollamount='8' id='merqueeText' behavior='scroll' direction='right'>" + msg.d + "</marquee>";
                $("#detailContent").fadeIn(500);
            },
            error: function (msg) {

            }

        });


    }

    $(".group-item").hover(function () {

        $(this).find(".img-front").stop().animate({ opacity: 0 }, 600);



    }, function () {

        $(this).find(".img-front").stop().animate({ opacity: 1 }, 600);


    });


});