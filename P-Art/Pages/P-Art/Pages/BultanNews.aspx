<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="BultanNews.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.BultanNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <script src="/Pages/P-Art/Scripts/jquery-1.8.1.min.js"></script>--%>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.carouFredSel-6.1.0-packed.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.mousewheel.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.touchSwipe.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.ba-throttle-debounce.min.js")%>'
        type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/jquery.qtip.js"></script>

    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>


    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
    <style type="text/css">
        .newsTags {
            font-size: 11px;
            padding-left: 0;
            padding: 0;
            margin: 0;
            font-weight: normal;
            font-family: tahoma;
            direction: rtl;
            float: right;
            max-width: 383px;
            white-space: nowrap;
            color: #666;
            margin-right: 30px;
        }

            .newsTags a {
                color: #999;
                margin-left: 5px;
                display: inline-block;
                padding: 2px 4px;
                background: rgba(245, 240, 240, 0.70);
                border-radius: 4px;
            }

                .newsTags a:hover {
                    color: #333;
                }

        .feederNews {
            background: #ca0707;
            color: #fff !important;
            font-size: 10px !important;
            border: 1px solid #ca0709;
            border-radius: 5px;
            padding: 2px 4px;
            line-height: 11px !important;
            /* font-size: 11px !important; */
            margin-right: 0 !important;
            margin-left: 2px !important;
            float: initial !important;
        }

        .feederContainer {
            padding: 3px 0px;
            /*width: 230px;*/
            display: inline-block;
        }

            .feederContainer div {
                float: right;
                margin: 0px 1px;
            }

        .feederCheckbox {
            cursor: pointer;
            -moz-transition: all 0.3s ease-in;
            -o-transition: all 0.3s ease-in;
            -webkit-transition: all 0.3s ease-in;
            transition: all 0.3s ease-in;
            border-bottom: 2px solid transparent;
        }

            .feederCheckbox input {
                padding: 2px;
                height: 14px;
                border: 1px solid #ccc;
                width: 14px;
                background: #fff;
                box-shadow: 0px 0px 3px #ccc;
                position: relative;
                top: 3px;
            }

            .feederCheckbox label {
                cursor: pointer;
            }

            .feederCheckbox.org {
                background-color: #94c8fb !important;
                color: #fff;
                padding: 4px 1px 6px 4px;
                border-radius: 2px;
            }

            .feederCheckbox.notorg {
                background-color: #c65556 !important;
                color: #fff;
                padding: 4px 1px 6px 4px;
                border-radius: 2px;
            }

            .feederCheckbox.org.active {
                border-bottom: 2px solid #333;
                background-color: #0a85b1 !important;
            }

            .feederCheckbox.notorg.active {
                border-bottom: 2px solid #333;
                background-color: #ca0709 !important;
            }

        .tagGroupContainer {
            float: right;
            border: 1px solid #ccc;
            padding: 0 6px;
            width: 33%;
            height: 140px;
            box-sizing: border-box;
            margin-top: 1px;
            margin-right: 1px;
            border-radius: 2px;
        }

        .keygroup {
            padding: 9px 0;
            margin: 0px;
            border-bottom: 1px solid #ccc;
        }

            .keygroup span {
            }

            .keygroup abbr, .keygroup label {
                font: bold 11px tahoma;
                line-height: 17px;
            }

        .groupItemList {
            padding: 8px;
        }

        .newsContainerLoader {
            z-index: 9998;
            position: fixed;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background: #111;
            opacity: 0.5;
        }

        .newsContainerLoaderText {
            z-index: 9999;
            position: fixed;
            text-align: center;
            left: 45%;
            top: 45%;
            width: 250px;
            background: #fff;
            padding: 20px 10px;
            border: 1px solid #ccc;
            margin: 0 auto;
            border-radius: 4px;
            font: normal 12px tahoma;
        }

            .newsContainerLoaderText img {
                text-align: center;
                margin: 0 auto;
            }

        .savebultan {
            float: left;
        }

            .savebultan a {
                display: inline-block;
                padding: 9px 12px;
                background: #ec750b;
                color: #fff;
                border-radius: 3px;
                border: 1px solid #d85105;
            }

                .savebultan a span {
                }


        .bultan_or_news_selected {
            width: 200px;
            height: 25px;
            background-color: #c65556;
            border-radius: 5px;
            float: right;
            margin-right: 5px;
            margin-top: 0px;
            padding-top: 5px;
        }

            .bultan_or_news_selected input {
            }

            .bultan_or_news_selected label {
                -webkit-user-select: none; /* Safari, iOS, and Android */
                -moz-user-select: none; /* Firefox */
                -ms-user-select: none; /* Internet Explorer/Edge */
                user-select: none; /* Non-prefixed version, currently
                                  supported by Chrome and Opera */
                line-height: 20px;
                color: #FFF;
                text-align: center;
                display: inline;
                background: transparent;
                border: none;
                padding: initial;
                float: none;
            }

        .news_list4 ol {
            padding: 0;
            margin: 0;
        }

            .news_list4 ol i.icon-move {
                /*background-image: url(/styles/img/glyphicons-halflings-white.png);*/
                background-image: url(/styles/img/glyphicons-halflings.png);
                background-position: -168px -72px;
                display: inline-block;
                width: 14px;
                height: 14px;
                line-height: 14px;
                vertical-align: text-top;
                /* background-image: url(../img/glyphicons-halflings.png); */
                /* background-position: 14px 14px; */
                background-repeat: no-repeat;
            }
    </style>
    <script>
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

        }
        $(function () {
            $(":checkbox[id=cbSelectAll]").click(function () {
                if ($(this).is(":checked")) {
                    $(":checkbox[id=check_SelectNews]").attr("checked", "checked");
                } else {
                    $(":checkbox[id=check_SelectNews]").removeAttr("checked");
                }
            });
            $(":checkbox[id*=check_SelectNews]").click(function () {
                if ($(":checkbox[id=check_SelectNews]").length == $(":checkbox[id*=check_SelectNews]:checked").length) {
                    $(":checkbox[id=cbSelectAll]").attr("checked", "checked");
                } else {
                    $(":checkbox[id=cbSelectAll]").removeAttr("checked");
                }
            });



        });
        $(".cbSelectAllGroupItem input").live('change', function () {

            var $this = $(this);
            var groupOrder = $this.parent().attr('data-grouporder');
            // alert(groupOrder);
            if ($this.is(":checked")) {
                $(".newsItemGroupOrder" + groupOrder).each(function () {
                    var $thisArticle = $(this);
                    //  console.log($thisArticle.attr('id'));
                    $thisArticle.find('#check_SelectNews').attr("checked", "checked");
                });
                // $("article[data-grouporder='" + groupOrder + "'] checkbox[id=check_SelectNews]").attr("checked", "checked");
            } else {
                // $("article[data-grouporder='" + groupOrder + "'] checkbox[id=check_SelectNews]").removeAttr("checked");
                // $(".newsItemGroupOrder" + groupOrder).each(function () {
                //  var $thisArticle = $(this);
                // console.log($thisArticle.attr('id'));
                // var $thisArticle = $(this);
                //    $thisArticle.find('#check_SelectNews').removeAttr("checked");
                // });
                $(":checkbox[id=check_SelectNews]").removeAttr("checked");
                $(":checkbox[id=check_SelectNews]").attr("checked", false);
                //  $(":checkbox[id*=check_SelectNews]").removeAttr("checked");
                $(".posts article").each(function () {
                    var postRow = $(this);
                    $(postRow).find("#check_SelectNews").attr('checked', false);
                    $(postRow).find("#check_SelectNews").removeAttr('checked');

                });
            }

            // e.preventDefault();
        });
        $(".chbSelectAllGroupItem input").live('change', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $(".cbSelectAllGroupItem input").attr("checked", "checked");

                $(".newsItemGroupOrder").each(function () {
                    var $thisArticle = $(this);

                    $thisArticle.find('#check_SelectNews').attr("checked", "checked");
                });
                // $('#check_SelectNews').attr("checked", "checked");


            } else {
                // $("article[data-grouporder='" + groupOrder + "'] checkbox[id=check_SelectNews]").removeAttr("checked");
                $(".cbSelectAllGroupItem input").removeAttr("checked");
                // $(".newsItemGroupOrder").each(function () {
                $(".newsItemGroupOrder").each(function () {
                    var $thisArticle = $(this);

                    $thisArticle.find('#check_SelectNews').removeAttr("checked");
                });
                //  $('#check_SelectNews').removeAttr("checked");
            }


        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--    <asp:UpdatePanel ID="updMain" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="UpdateProgressMain" AssociatedUpdatePanelID="updMain">
                <ProgressTemplate>
                    <div class="newsContainerLoader"></div>
                    <div class="newsContainerLoaderText">
                        <img src="/Pages/P-Art/Images/ajax-loader.gif" alt="loader" />
                        <br />
                        در حال دریافت اطلاعات،لطفا منتظر بمانید...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>

    <asp:HiddenField ID="hdfUserCustomSort" runat="server" />
    <asp:HiddenField ID="hdfUserID" runat="server" />
    <div class="tabbed">

        <ul>
            <li class="selected"><a href="~/news/Highlight" runat="server">در یک نگاه</a></li>
            <li class="selected"><a href="~/news/Latest" runat="server">تازه ها</a></li>
            <li class="selected"><a href="/Analysis" runat="server">تحلیل محتوا</a></li>
            <li class="selected"><a href="/KeywordAnalyse" runat="server">آنالیز کلیدواژه ها</a></li>
            <li class="selected"><a href="/News/BultanArchive" runat="server">آرشیو بولتن</a></li>

            <li class="selected"><a href="/addnews" runat="server">ثبت خبر</a></li>
            <li class="selected"><a href="/Pages/P-Art/Pages/SavedNews.aspx" runat="server">اخبار ذخیره شده</a></li>

        </ul>

        <a href="#" class="flat-gray-button" id="lnk_filter">
            <span class="fontawesome-filter"></span>
            فیلتر کردن
            
        </a>
        <%-- <a href="#" class="flat-gray-button" style="margin-left: 5px" id="lnk_bultan">
            <span class="fontawesome-book"></span>
            بولتن
        </a>--%>
        <a href="#" class="flat-gray-button" style="margin-left: 5px" id="lnk_category">
            <span class="fontawesome-list"></span>
            دسته بندی اخبار
        </a>
    </div>



    <section class="posts">

        <div class="control-box category">

            <asp:Repeater ID="rpt_Groups" runat="server" OnItemDataBound="rpt_Groups_ItemDataBound">
                <ItemTemplate>
                    <div id="group_item" class="group_item" runat="server">
                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                        <span id="color_span" runat="server">
                            <asp:CheckBox ID="check_selected_group" runat="server" />
                        </span>
                        <a href="#" data-id='<%# Eval("KeyId") %>' class="switchkeyword">
                            <label><%#  PArt.Pages.P_Art.Repository.Class_Static.PersianAlpha(Eval("KeywordName")) %></label>

                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal runat="server" ID="ltKeywords"></asp:Literal>
        </div>
        <div class="control-box filter">
            <table>
                <tr>
                    <td>از تاریخ :</td>
                    <td>
                        <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="margin: 0; width: 80px;" />
                        <span>از ساعت:</span>
                        <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" Style="direction: ltr; width: 50px; margin: 0; font-family: Tahoma;" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
                            ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>تا تاریخ :</td>
                    <td colspan="2">
                        <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 80px; margin: 0;" />
                        <span>تا ساعت:</span>
                        <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" Style="direction: ltr; width: 50px; margin: 0; font-family: Tahoma;" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour"
                            ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btn_ShowNews" runat="server" Style='padding: 5px 12px;' CssClass="BlueButton" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
                        <asp:Button ID="btnGetNewsDB" runat="server" CssClass="BlueButton" Width="70px" Text="خروجیDB" OnClick="btnGetNewsDB_Click" />
                    </td>

                </tr>
                <tr>
                    <td>کلید واژه :
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txt_search" runat="server" CssClass="textbox" Style="width: 182px; margin: 0;" />
                    </td>

                    <td>منبع خبری : 
                    </td>
                    <td>
                        <asp:DropDownList ID="drp_NewsSource" Width="95px" runat="server" CssClass="textbox" />
                    </td>
                    <td>ترتیب نمایش :
                    </td>
                    <td>
                        <asp:DropDownList ID="drp_sort" runat="server" CssClass="textbox">
                            <asp:ListItem Text="اولویت کلید واژه ها" Value="0" />
                            <asp:ListItem Text="ساعت خبر" Value="1" />
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan="7">

                        <a href="/News/Latest/?time=30" class="flat-gray-button time">30 دقیقه پیش
                        </a>
                        <a href="/News/Latest/?time=60" class="flat-gray-button time">1 ساعت پیش
                        </a>
                        <a href="/News/Latest/?time=180" class="flat-gray-button time">3 ساعت پیش
                        </a>
                        <a href="/News/Latest/?time=360" class="flat-gray-button time">6 ساعت پیش
                        </a>
                        <a href="/News/Latest/?time=720" class="flat-gray-button time">12 ساعت پیش
                        </a>
                        <a id="lnk_yesterday" runat="server" href="/News/Latest/?time=1440" class="flat-gray-button time">1 روز پیش
                        </a>

                    </td>
                </tr>

            </table>
        </div>
        <div class="control-box bultan">

            <table>
                <tr>
                    <td>
                        <a href="#" id="btn_SelectAll" class="flat-gray-button" style="float: right; height: 28px; margin-left: 5px; width: 11px; padding-right: 3px;"
                            title="انتخاب کلیه اخبار">
                            <span class="entypo-check"></span>
                        </a>
                        <asp:Button ID="btn_saveState" runat="server" Text="ذخیره وضعیت" CssClass="flat-gray-button" OnClick="btn_saveState_Click" />
                        <asp:LinkButton ID="btn_reset" runat="server" class="flat-gray-button" OnClick="btn_reset_Click" OnClientClick="return confirm('آیا برای ریست کردن تنظیمات اطمینان دارید ؟')">
                            حذف وضعیت
                        </asp:LinkButton>
                        <asp:Button ID="btn_exportWordTitr" runat="server" Text="Word تیتر" CssClass="flat-gray-button" OnClick="btn_exportWordTitr_Click" />
                        <asp:Button ID="btn_exportWordShort" runat="server" Text="Word خلاصه" CssClass="flat-gray-button" OnClick="btn_exportWordShort_Click" />
                        <asp:Button ID="btn_exportWord" runat="server" Text="خروجی Word" CssClass="flat-gray-button" OnClick="btn_exportWord_Click" />

                        <a id="btn_generateGroupHtml" runat="server" onclick="GetGroupHTMLBultan(this)" class="flat-gray-button">بولتن موضوعی</a>
                        <asp:Button ID="btn_generate" runat="server" Text="خروجی PDF" CssClass="flat-gray-button" />
                        <asp:Button ID="btn_PrintLead" runat="server" Text="خلاصه اخبار" CssClass="flat-gray-button" />
                        <%--   <asp:Button ID="btn_PrintLead" runat="server" Text="چاپ خلاصه اخبار" CssClass="flat-gray-button" OnClick="btn_PrintLead_Click" />--%>
                        <asp:Button ID="btn_printTitle" runat="server" Text="تیتر اخبار" CssClass="flat-gray-button" OnClick="btn_printTitle_Click" />
                        <asp:Button ID="btn_db" runat="server" Text="خروجی DB" CssClass="flat-gray-button" OnClick="btn_db_Click" />



                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:CheckBox ID="check_NewsPaper" runat="server" Text="روزنامه" />
                        <asp:CheckBox ID="check_highlight" runat="server" Text="هایلایت کلید واژه ها" />
                        <asp:CheckBox ID="check_related" runat="server" Text="شناسایی اخبار مرتبط" />
                        <asp:CheckBox ID="check_rujeld" Checked="true" runat="server" Text="رو جلد" />
                        <asp:CheckBox ID="check_ChartKhabar" runat="server" Text="نمودار" />
                        <asp:CheckBox ID="check_Arz" runat="server" Text="سکه و ارز" />
                        <asp:CheckBox ID="check_GalleryNewspaper" runat="server" Text="گالری روزنامه " />
                        <asp:CheckBox ID="check_Sima" runat="server" Text="صدا و سیما" />
                        <asp:CheckBox ID="check_addGroup" runat="server" Text="تفکیک" />
                        <asp:CheckBox ID="check_addArchive" runat="server" Text="اضافه کردن به آرشیو بولتن" />


                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            عنوان بولتن :
                        </label>
                        <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" Text="فاقد عنوان" />
                        <label>
                            قالب چاپی :
                        </label>
                        <asp:DropDownList ID="drp_template" runat="server" CssClass="textbox" Style="width: 102px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#" id="lnk_download" style="display: none">دریافت فایل
                        </a>
                    </td>
                </tr>
            </table>
            <div class="loader">
                <img src="/Pages/P-Art/Images/ajax-loader.gif" />
            </div>
        </div>
        <div class="userSorting clearfix">
            <%--  <h4 class="right">
                <span class="fontawesome-sort" style="font-size: 13px; color: #073cb9;"></span>
                مرتب سازی مطالب</h4>--%>
            <div class="feederContainer clearfix right">
                <div>
                    <asp:CheckBox runat="server" ID="chbOrgNews" ClientIDMode="Static" CssClass=" smallCheckBox feederCheckbox org active" Checked="true" Text="منابع رسمی" />
                </div>
                <div>
                    <asp:CheckBox runat="server" ID="chbNotOrgNews" ClientIDMode="Static" CssClass=" smallCheckBox feederCheckbox notorg active" Checked="true" Text="منابع غیر رسمی" />
                </div>
            </div>
            <ul class="left">
                <li class="selected" id="sortByKeyword">
                    <a class="sortByKeyword" href="#sortByKeyword">کلیدواژه</a>
                </li>
                <li id="sortByTimeSort">
                    <a class="sortByTimeSort" href="#sortByTimeSort">زمان انتشار</a>
                </li>
                <%--  <li id="sortByGroupName" style="width: 100px;">
                            <a class="sortByGroupName" href="#sortByGroupName">گروه بندی موضوعی</a>
                            <i></i>
                        </li>--%>
                <li id="sortBySite">
                    <a class="sortBySite" href="#sortBySite">نام رسانه</a>
                </li>
                <li id="sortByCustom" style="width: 90px;">
                    <a class="sortByCustom" href="#sortByCustom">اولویت سفارشی</a>
                    <i></i>
                </li>
                <li id="sortByTitle">
                    <a class="sortByTitle" href="#sortByTitle">عناوین</a>
                    <i></i>
                </li>


            </ul>

        </div>
        <script>
            $(document).ready(function () {
                $("#rbtCommonList").live('click', function () {
                    $(".newsMostRelatedSection").hide();
                    $(".newsRelatedSection").hide();
                    $(".newsGroupSection").hide();
                    $(".newsSection").show();
                    $('#rbtRelatedList').removeClass('active');
                    $('#rbtMostPublished').removeClass('active');
                });
                $("#rbtGroupList").live('click', function () {
                    $(".newsMostRelatedSection").hide();
                    $(".newsRelatedSection").hide();
                    $(".newsSection").hide();
                    $(".newsGroupSection").show();
                    $('#rbtRelatedList').removeClass('active');
                    $('#rbtMostPublished').removeClass('active');
                });
                $("#rbtRelatedList").live('click', function () {
                    // __doPostBack('DoRelateNews', '');
                    //$('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                    //$('#rbtRelatedList').removeClass('active');
                    //$('#rbtRelatedList').addClass('active');
                });
                $("#rbtMostPublished").live('click', function () {
                    // __doPostBack('DoRelateNews', '');
                    //$('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                    //$('#rbtMostPublished').removeClass('active');
                    //$('#rbtMostPublished').addClass('active');
                });
            });
            function DoRelateNews() {

                // __doPostBack('DoRelateNews', '');
                //  alert('DoRelateNews');
                $(".newsMostRelatedSection").hide();
                $(".newsSection").hide();
                $(".newsGroupSection").hide();
                $(".newsRelatedSection").show();


                $('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                $('#rbtRelatedList').removeClass('active');
                $('#rbtRelatedList').addClass('active');

            }
            function DoMostPublishNews() {
                //  __doPostBack('DoRelateNews', '');
                $(".newsRelatedSection").hide();
                $(".newsSection").hide();
                $(".newsGroupSection").hide();
                $(".newsMostRelatedSection").show();


                $('.list-type input[type="radio"]').each(function () { $(this).attr("checked", ""); $(this).removeAttr("checked", ""); });
                $('#rbtMostPublished').removeClass('active');
                $('#rbtMostPublished').addClass('active');

            }
        </script>
        <div class="list-type clearfix">
            <%-- <asp:RadioButton ID="rbtCommonList" runat="server" GroupName="news" Text="تمامی اخبار" />--%>
            <asp:RadioButton ID="rbtGroupList" runat="server" GroupName="news" Checked="true" Text="گروه بندی اخبار" />
            <%-- <asp:Button ID="rbtRelatedList" OnClick="rbtRelatedList_Click" runat="server" GroupName="news" Text="اخبار مرتبط" />
            <asp:Button ID="rbtMostPublished" OnClick="rbtMostPublished_Click" runat="server" GroupName="news" Text="تمرکز رسانه ها" />--%>
            <div class="bultan_or_news_selected">
                <input type="checkbox" checked="checked" id="chb_bultan_news_selected" /><label for="chb_bultan_news_selected">نمایش اخبار انتخاب شده و دیگر اخبار</label>
            </div>

            <div class="savebultan">
                <%-- <asp:LinkButton runat="server" ID="btnBultan" OnClick="btnBultan_Click">
                    <span>ذخیره وضعیت بولتن</span>
                </asp:LinkButton>--%>
                <a id="btnBultan" onclick="setBultanNewsIds()">
                    <span>ذخیره وضعیت بولتن</span>
                </a>
            </div>

        </div>
        <div class="clearfix"></div>

        <div class="newsSection" style="display: none;">
            <asp:Repeater ID="news_list" runat="server" OnItemDataBound="news_list_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list">
                </HeaderTemplate>
                <ItemTemplate>
                    <article data-id='<%# Eval("KeywordId") %>' data-groupname='<%# Eval("GroupOrder") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class="show">
                        <div class="post-content" id="news_row" runat="server">
                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                            <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                                <a title="ویرایش خبر" class="editNews" href='/addnews?Id=<%# Eval("NewsId") %>'>
                                    <img src="/Pages/P-Art/Images/editTag2.png" /></a>
                                <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsId") %>'>
                                    <img src="/Pages/P-Art/Images/del16.png" /></a>

                            </asp:PlaceHolder>

                            <asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />

                            <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>

                            <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                            <h2>

                                <%#  CheckIsNewsFeed(Eval("IsFeederNews"))  %>
                                <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                    runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                </a>
                            </h2>

                            <div class="news-desc">
                                <h2>
                                    <%#Eval("SiteTitle") %>
                              
                                </h2>
                                <span>
                                    <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                </span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="clearfix">
                                <div class="newsTags">
                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                </div>
                                <div class="newsrate" runat="server">

                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                </div>
                            </div>
                        </div>
                    </article>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="clearfix"></div>
        <div class="newsRelatedSection" style="display: none;">
            <asp:Repeater ID="rptRelatedNews_list" runat="server" OnItemDataBound="rptRelatedNews_list_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list2">
                </HeaderTemplate>
                <ItemTemplate>
                    <article data-id='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class="show">
                        <div class="post-content relation" id="news_row" runat="server">
                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                            <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                                <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsId") %>'>
                                    <img src="/Pages/P-Art/Images/del16.png" /></a>
                            </asp:PlaceHolder>

                            <asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />

                            <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>

                            <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                            <h2>

                                <%#  CheckIsNewsFeed(Eval("IsFeederNews"))  %>
                                <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                    runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                </a>
                            </h2>

                            <div class="news-desc">
                                <h2>
                                    <%#Eval("SiteTitle") %>
                              
                                </h2>
                                <span>
                                    <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                </span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="clearfix">
                                <div class="newsTags">
                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                </div>
                                <div class="newsrate" runat="server">

                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                </div>
                            </div>
                            <div class="RelatedBody">
                                <asp:Repeater ID="relatedNews" runat="server" OnItemDataBound="RelatedNews_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="body-item">
                                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                            <div class="Related-Item">
                                                <div class="right-side">
                                                    <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                                                    <img src="../../../Styles/img/left-pointer-red.png" width="10" height="10">
                                                    <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                                        runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                                    </a>
                                                </div>
                                                <div class="news-desc">
                                                    <h2>
                                                        <%#Eval("SiteTitle") %>
                              
                                                    </h2>
                                                    <span>
                                                        <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="clearfix">
                                                <div class="newsTags">
                                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                                </div>
                                                <div class="newsrate" runat="server">

                                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </article>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <div class="clearfix"></div>
        <div class="newsMostRelatedSection" style="display: none;">
            <asp:Repeater ID="rptMostRelatedNews_list" runat="server" OnItemDataBound="rptMostRelatedNews_list_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list3">
                </HeaderTemplate>
                <ItemTemplate>
                    <article data-id='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class="show">
                        <div class="post-content relation" id="news_row" runat="server">
                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                            <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                                <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsId") %>'>
                                    <img src="/Pages/P-Art/Images/del16.png" /></a>
                            </asp:PlaceHolder>

                            <asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />

                            <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>

                            <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                            <h2>

                                <%#  CheckIsNewsFeed(Eval("IsFeederNews"))  %>
                                <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                    runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),60) %>
                                </a>
                            </h2>
                            <span class="marja">(رسانه مرجع)</span>
                            <div class="news-desc">
                                <h2>
                                    <%#Eval("SiteTitle") %>
                              
                                </h2>

                                <span>
                                    <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                </span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="clearfix">
                                <div class="newsTags">
                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                </div>
                                <div class="newsrate" runat="server">

                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                </div>
                            </div>
                            <div class="RelatedBody">
                                <asp:Repeater ID="relatedNewsMost" runat="server" OnItemDataBound="relatedNewsMost_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="body-item">
                                            <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                                            <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                            <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                                            <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                                            <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                            <div class="Related-Item">
                                                <div class="right-side">
                                                    <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                                                    <img src="../../../Styles/img/left-pointer-red.png" width="10" height="10">
                                                    <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                                        runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                                    </a>
                                                </div>
                                                <div class="news-desc">
                                                    <h2>
                                                        <%#Eval("SiteTitle") %>
                              
                                                    </h2>
                                                    <span>
                                                        <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="clearfix">
                                                <div class="newsTags">
                                                    <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                                    <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                                </div>
                                                <div class="newsrate" runat="server">

                                                    <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                                    <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                                        style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                                    <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </article>
                </ItemTemplate>

                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="clearfix"></div>
        <div class="newsGroupSection" style="display: block;">
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfBultnArchiveID" />
            <asp:HiddenField runat="server" ID="hdfSelectedBultanNews" />
            <asp:Repeater ID="rptGroupNewKeyword" runat="server" OnItemDataBound="rptGroupNewKeyword_ItemDataBound">
                <HeaderTemplate>
                    <div class="news_list4">
                        <asp:CheckBox CssClass="chbSelectAllGroupItem" ID="chbSelectAllGroupItem" Text="انتخاب تمامی اخبار" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <section class="keyword-groups">
                        <asp:CheckBox ID='cbSelectAllGroupItem' ClientIDMode="AutoID" data-grouporder='<%# Eval("GroupOrder") %>' data-groupname='<%# Eval("GroupName") %>' runat="server" Text='<%# Eval("GroupName") %>'
                            CssClass="cbSelectAllGroupItem" />
                        <%-- <asp:Label ID="lblGroup" Text='<%# Eval("GroupName") %>' runat="server"></asp:Label>--%>
                    </section>
                    <div class="clearfix"></div>
                    <asp:Repeater ID="rptGroupNewsList" runat="server" OnItemDataBound="rptGroupNewsList_ItemDataBound">
                        <HeaderTemplate>
                            <ol>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="articleSetion groupOrderItem">
                                <article data-id='groupOrderItem_<%# Eval("NewsId") %>' data-grouporder='<%# Eval("GroupOrder") %>' data-groupname='<%# Eval("GroupName") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-feedernews='<%# Eval("IsFeederNews") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("NewsDate").ToString(),Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class='show newsItemGroupOrder  newsItemGroupOrder<%# Eval("GroupOrder") %>'>
                                    <div class="post-content" id="news_row" runat="server">
                                        <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                                        <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsID") %>' />
                                        <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />
                                        <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                                        <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                                            <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsID") %>'>
                                                <img src="/Pages/P-Art/Images/del16.png" /></a>
                                        </asp:PlaceHolder>

                                        <asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />

                                        <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>
                                        <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                                        <h2>
                                            <i class="icon-move"></i>
                                            <%#  CheckIsNewsFeed(Eval("IsFeederNews"))  %>
                                            <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsID")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>'
                                                runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                                            </a>
                                        </h2>

                                        <div class="news-desc">
                                            <h2>
                                                <%#Eval("SiteTitle") %>
                              
                                            </h2>
                                            <span>
                                                <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %>
                                            </span>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="clearfix">
                                            <div class="newsTags">
                                                <asp:Literal runat="server" ID="ltTags"></asp:Literal>
                                                <asp:HiddenField runat="server" ID="hdfNewsTags"></asp:HiddenField>

                                            </div>

                                            <div class="newsrate" runat="server">

                                                <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                                <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                                <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                                            </div>

                                            <div class="newsLocDiv">
                                                <a id='changeLoc_<%# Eval("NewsId") %>' data-newsid='<%# Eval("NewsId") %>' onclick="ChangeGroupOrder(this)" data-grouporder='<%# Eval("GroupOrder") %>' class="changeLoc"></a>
                                            </div>

                                        </div>
                                    </div>
                                </article>
                                <div class="clear" style="clear: both;"></div>
                                <div class="divSelectGroup clearfix" style="height: 0px;"></div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ol>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>

    <div style="display: none;">
        <input type="hidden" id="hddNewsIdGroup" name="hddNewsIdGroup" runat="server" />
    </div>
    <div class="keywordGroup" id="keywordGroup" style="display: none">
        <asp:RadioButtonList ID="rbtGroups" DataTextField="GroupName" DataValueField="GroupOrder"
            runat="server">
        </asp:RadioButtonList>
        <a onclick="DoFinalChangeLog(this)" class="btnSaveGroup">ثبت تغییرات</a>
    </div>

    <script>
        function ChangeGroupOrder(element) {

            var $divSelectGroup = $(element).parent().parent().parent().parent().parent().find('.divSelectGroup');
            if ($(element).attr('class').indexOf('active') > -1) {
                $divSelectGroup.html('');
                $divSelectGroup.animate({ 'height': 0 });
                $(element).removeClass('active');
                return;


            }
            $(element).addClass('active');

            var newsId = $(element).attr('data-newsid');

            var grouporder = $(element).attr('data-grouporder');

            $('#keywordGroup').attr('data-newsid', newsId);
            $('#keywordGroup').attr('data-grouporder', grouporder);



            $divSelectGroup.html('');
            var editDivHtml = $('#keywordGroup').html();
            editDivHtml = editDivHtml.replace('rbtGroups', 'rbtGroups_' + newsId);
            $divSelectGroup.html(editDivHtml);

            $('#rbtGroups_' + newsId + " input[value='" + grouporder + "']").prop("checked", true);

            $keywordGroupHeight = $('#keywordGroup').height();

            $divSelectGroup.animate({ 'height': $keywordGroupHeight + 60 });


            //   $('#keywordGroup').css({ 'top': $divSelectGroup.offset().top - ($keywordGroupHeight + 40) });
            //  $('#keywordGroup').css({ 'left': $divSelectGroup.offset().left + $divSelectGroup.width() });
            // $('#keywordGroup').fadeIn();

            //$("#divSelectGroup").slideToggle();
            //var offsetHeight = $('#keywordGroup').offsetHeight;
            //$('#divSelectGroup').style.height = offsetHeight + 'px';
            //var cont = $('#keywordGroup').html();
            //$('#divSelectGroup').append(cont);


        }
        function DoFinalChangeLog(element) {
            var newsId = $('#keywordGroup').attr('data-newsid');
            var old_grouporder = $('#keywordGroup').attr('data-grouporder');
            var news_grouporder = $("#rbtGroups_" + newsId).find(":checked").val();

            if (news_grouporder == null) {

                alert('لطفا گروه را انتخاب نمایید');
                return;
            }

            console.log(newsId);
            console.log(news_grouporder);
            //  alert(news_grouporder);
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/ajax.aspx/UpdateGroupOrderNews",
                data: "{'NewsId':'" + newsId + "','GroupOrder':'" + news_grouporder + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //   alert(data.d.length);
                    // alert(data.d);
                    if ((data.d + '').trim() == 'true') {
                        alert('انتقال انجام شد');
                        // $thisDiv.remove();
                        $('#keywordGroup').attr('data-grouporder', news_grouporder);
                        $('#changeLoc_' + newsId).attr('data-grouporder', news_grouporder);
                        //  $('#changeLoc_' + newsId).attr('data-newsid', newsId);
                    }
                    else {
                        alert('خطا در انتقال خبر');
                    }
                },
                error: function (msg) {
                    alert('ارور - خطا در انتقال خبر');
                }
            });

            //            e.preventDefault();
        }
    </script>

    <asp:GridView ID="grd_word" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>

            <asp:TemplateField>
                <ItemStyle Wrap="true" Width="595px" />
                <HeaderTemplate>
                    <div style="overflow-x: scroll; white-space: normal; width: 595px">
                </HeaderTemplate>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span style="direction: rtl; white-space: normal; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# (Eval("SiteTitle").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <span style="direction: rtl; white-space: normal; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p style="font-family: 'B Titr'; white-space: normal; font-size: 18px; direction: rtl; text-align: justify; margin-right: 20px; margin-left: 20px; width: 565px">

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#   (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p style="font-family: 'B Nazanin'; white-space: normal; font-size: 15px; text-align: justify; direction: rtl; margin-right: 20px; margin-left: 20px; width: 565px">

                        <asp:Literal runat="server" ID="ltLead" Text='<%#   (Eval("NewsLead").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p style="font-family: 'B Nazanin'; white-space: normal; break-all; font-size: 15px; text-align: justify; direction: rtl; margin-right: 20px; margin-left: 20px; width: 565px">

                        <asp:Literal runat="server" ID="ltBody" Text='<%#   (Eval("NewsBody").ToString()) %>'>

                        </asp:Literal>
                    </p>


                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:GridView ID="grd_word_short" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# Eval("SiteTitle").ToString() %>'>

                        </asp:Literal>

                    </span>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p style="font-family: 'B Titr'; font-size: 18px; direction: rtl; text-align: justify; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#  (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p style="font-family: 'B Nazanin'; font-size: 15px; text-align: justify; direction: rtl; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltLead" Text='<%#  (Eval("NewsLead").ToString()) %>'>

                        </asp:Literal>
                    </p>



                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:GridView ID="grv_word_titr" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# Eval("SiteTitle").ToString() %>'>

                        </asp:Literal>

                    </span>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p style="font-family: 'B Titr'; font-size: 18px; direction: rtl; text-align: justify; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#  (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>



                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <div class="shadowModal"></div>
    <div class="modalSiteSort">
        <div class="modalHeader"></div>
        <div class="modalContainer clearfix">
            <asp:Repeater runat="server" ID="rptSiteSort">
                <HeaderTemplate>
                    <div class="containerSiteSort right ">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="sortItem">

                        <%--  <asp:TextBox placeholder="اولویت نمایش" runat="server" ID="txtSortOrder" CssClass="numbericBox" Width="50px"></asp:TextBox>--%>

                        <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                        <i class="remove"></i>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <div class="containerSortSeleted">
                <h5 style="">سایت های موردنظر  خود را اینجا بیاورید</h5>
                <div class="selectedListItems">
                    <asp:Repeater runat="server" ID="rptSelectedSiteSort">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="selectedSiteItem">


                                <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                                <i class="remove"></i>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <div class="modalFooter">
            <a id="btnRegSiteSort" href="#regModel" class="regBtn">
                <span>ثبت</span>
            </a>
            <a id="btnCancelSiteSort" href="#closeModal" class="cancelBtn">
                <span>انصراف</span>
            </a>
        </div>
    </div>

    <%--  <script src="/Pages/P-Art/Scripts/tsort.min.js"></script>--%>
    <div class="loader_box">
        <img src="/Pages/P-Art/images/loading.gif" />
    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            Page_Init();
            if (window.location.pathname == "/tv") {
                $(".btn_tv").click();
            }


        });


        $('#sortByTimeSort a').live('click', function (e) {
            $(".news_list article").sort(sort_timesort) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTimeSort').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByCustom a').live('click', function (e) {
            $(".news_list article").sort(sort_custom) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByCustom').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByTitle a').live('click', function (e) {

            // $('.news_list>article').tableSort({ attr: 'data-title' });

            $(".news_list article").sort(sort_title) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTitle').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortBySite a').live('click', function (e) {
            $(".news_list article").sort(sort_site) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortBySite').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByKeyword a').live('click', function (e) {
            $(".news_list article").sort(sort_keyword) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByKeyword').addClass('selected');
            sortArticleIndex();
            e.preventDefault();
        });
        //$('#sortByGroupName a').live('click', function (e) {
        //    $(".news_list article").sort(sort_GroupName) // sort elements
        //        .appendTo('.news_list'); // append again to the list

        //    $('.userSorting ul li').removeClass('selected');
        //    $('#sortByGroupName').addClass('selected');
        //    sortArticleIndex();
        //    e.preventDefault();
        //});

        $('.userSorting li#sortByCustom i').live('click', function (e) {

            ShowShadowModal();
            ShowSiteSortModal();
        });
        $('.modalSiteSort .cancelBtn').live('click', function (e) {

            CloseShadowModal();
            CloseSiteSortModal();
        });


        $('.modalSiteSort .modalFooter .regBtn').live('click', function (e) {
            var fileOffset = $(this).offset();

            $('.loader_box').css({ 'left': fileOffset.left, 'top': fileOffset.top });
            $('.loader_box').fadeIn('fast');
            var siteIds = '';
            $('.modalSiteSort .selectedListItems  .selectedSiteItem').each(function (index) {

                var $this = $(this);
                var siteId = $this.find('span').attr('data-id');
                if (siteIds == '') {
                    siteIds = siteId;
                }
                else {
                    siteIds = siteIds + "," + siteId;
                }

            });

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/ajax.aspx/UpdateUserSortingOrder",
                data: "{'userId':'<%=hdfUserID.Value%>','siteIds':'" + siteIds + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //   alert(data.d.length);


                    $('.loader_box').fadeOut('fast');
                    CloseShadowModal();
                    CloseSiteSortModal();
                },
                error: function (msg) {
                    alert(msg.messege);
                    $('.loader_box').fadeOut('fast');
                    CloseShadowModal();
                    CloseSiteSortModal();
                    // alert(msg.responseText);
                }
            });

            e.preventDefault();

        });
        $('.modalSiteSort .modalContainer .containerSortSeleted .selectedSiteItem .remove').live('click', function () {
            $this = $(this);
            $this.parent().fadeOut().remove();
        });

        var $sitesSort = $(".containerSiteSort"),
             $selected = $(".selectedListItems");

        // let the gallery items be draggable
        $("div", $sitesSort).draggable({
            cancel: "a.ui-icon", // clicking an icon won't initiate dragging
            revert: "invalid", // when not dropped, the item will revert back to its initial position
            containment: "document",
            helper: "clone",
            cursor: "move"
        });

        // let the trash be droppable, accepting the gallery items
        $selected.droppable({
            accept: ".containerSiteSort > div",
            activeClass: "ui-state-highlight",
            drop: function (event, ui) {
                $selected.append("<div class='selectedSiteItem'>" + ui.draggable.html() + "</div>");
            }
        });
        $('.selectedListItems').sortable();
        $('.selectedListItems').disableSelection();


        function ShowShadowModal() {
            $('.shadowModal').fadeIn();
        }

        function CloseShadowModal() {
            $('.shadowModal').fadeOut();
        }
        function ShowSiteSortModal() {
            $('.modalSiteSort').fadeIn();
        }
        function CloseSiteSortModal() {
            $('.modalSiteSort').fadeOut();
        }
        $('#chbOrgNews').click(function () {

            $(this).parent().toggleClass('active');

            if ($("#chbOrgNews").is(':checked')) {
                $('.news_list article[data-feedernews="False"]').fadeIn();

            }
            else { $('.news_list article[data-feedernews="False"]').fadeOut(); }

        });
        $('#chbNotOrgNews').click(function () {

            $(this).parent().toggleClass('active');
            if ($("#chbNotOrgNews").is(':checked')) {
                $('.news_list article[data-feedernews="True"]').fadeIn();
            }
            else {
                $('.news_list article[data-feedernews="True"]').fadeOut();

            }
        });

        // sort function callback
        function sort_timesort(a, b) {
            return ($(b).data('timesort')) > ($(a).data('timesort')) ? 1 : -1;
        }
        function sort_site(a, b) {
            return ($(b).data('sitename')) < ($(a).data('sitename')) ? 1 : -1;
        }
        function sort_custom(a, b) {

            return ($(b).data('customsort')) < ($(a).data('customsort')) ? 1 : -1;

        }
        function sort_keyword(a, b) {
            return ($(b).data('keyword')) < ($(a).data('keyword')) ? 1 : -1;
        }
        function sort_GroupName(a, b) {
            return ($(b).data('groupName')) < ($(a).data('groupName')) ? 1 : -1;
        }
        function sort_title(a, b) {
            return ($(b).data('title')) < ($(a).data('title')) ? 1 : -1;
            return b - a;
            //var keyA = $(a).data('title');
            //var keyB = $('td:eq(0)',b).text();

            //    return (keyA< keyB) ? 1 : 0;


        }
        function sortArticleIndex() {
            var counter = 1;
            // alert('yes');
            $('.news_list article.show').each(function (index) {
                var $this = $(this);
                $this.find('.post-content').find('span.rowIndex').text(parseInt(counter) + ")");
                counter++;
            });
        }
        $('.delNews').live('click', function (e) {
            var $this = $(this);
            var newsID = $this.attr('data-id');
            $thisDiv = $this.parent().parent();

            var result = confirm("برای حذف خبر مطمئن هستید؟");
            if (result) {


                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/ajax.aspx/DeActiveNews",
                    data: "{'NewsId':'" + newsID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //   alert(data.d.length);

                        if (data.d == 'true') {
                            $thisDiv.remove();

                        }
                        else {
                            alert('حطا در حذف خبر');
                        }
                    },
                    error: function (msg) {
                        alert('حطا در حذف خبر');

                        // alert(msg.responseText);
                    }
                });
            }
            e.preventDefault();




        });


        $(window).load(function () {

            $(".news_list article").sort(sort_timesort) // sort elements
              .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTimeSort').addClass('selected');
            sortArticleIndex();
            //  e.preventDefault();

            var allText = "";
            // update control-box group_item
            $('.group_item').each(function () {
                var $this = $(this);


                allText += "," + $this.find('label').text().trim() + ",";
            });
            var lstAllGroupItem = $('.group_item label');
            $('.newsTags a').each(function () {
                var $this = $(this);
                var txt = "," + $this.text().trim() + ",";
                if (allText.indexOf(txt) == -1) {
                    allText += txt;

                    var data_keyid = $this.attr('data-keyid');
                    var data_color = $this.attr('data-color');
                    var data_text = $this.attr('data-text');

                    var html = "<div id='group_item' class='group_item'>" +
                        "<input type='hidden' name='ctl00$Content$rpt_Groups$ctl01$fld_color' id='fld_color' value='" + data_color + "'>" +
                        "<span id='color_span' style='background-color:" + data_color + ";'>" +
                            "<input id='check_selected_group' type='checkbox' name='ctl00$Content$rpt_Groups$ctl01$check_selected_group'>" +
                        "</span>" +
                        "<a href='#' data-id='" + data_keyid + "' class='switchkeyword'>" +
                            "<label>" + data_text + "</label>" +

                        "</a>" +
                    "</div>";

                    $('.control-box.category').append(html);
                }

            });


        });
    </script>
    <%--      </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="rbtRelatedList" />
            <asp:AsyncPostBackTrigger ControlID="rbtMostPublished" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">--%>
    <%--      <script src="/Scripts/jquery-sortable.js"></script>   <script src="https://code.jquery.com/jquery-1.12.4.js"></script>--%>
    <%--  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
    <link href="/Pages/P-Art/Styles/ui-lightness/jquery-ui-1.8.6.custom.css" rel="stylesheet" />
    <script src="/Pages/P-Art/Scripts/jquery-ui-1.8.6.custom.min.js"></script>
    <script type="text/javascript">


        $(function () {
            $(".news_list4 ol").sortable({
                // placeholder: "ui-state-highlight"
            });
            $(".news_list4 ol").disableSelection();
        });

        $(window).load(function () {

            //$(".news_list4 ol").sortable({
            //    group: 'no-drop',
            //    handle: 'i.icon-move',
            //    onDrop: function ($item, container, _super) {

            //    },

            //    // set $item relative to cursor position
            //    onDragStart: function ($item, container, _super) {

            //    },
            //    onDrag: function ($item, position) {

            //    }
            //});
        });
        function setBultanNewsIds() {
            var bultanId = $('#hdfBultnArchiveID').val();
            var counter = 0;
            var str = "";
            $('.newsItemGroupOrder').each(function () {
                var $this = $(this);

                
                var fld_newsId = $this.find('#fld_newsId').val();
                var txt_row_index = $this.find('#txt_row_index').val();
                var check_SelectNews = $this.find('#check_SelectNews');
                if (check_SelectNews.attr("checked") == "checked") {

                    if(txt_row_index==null || txt_row_index=='' || txt_row_index==undefined)
                    {
                        txt_row_index = "10000" + counter;
                        counter++;
                    }

                    str += ";" + fld_newsId + ":" + txt_row_index;
                    //if (check_SelectNews.attr('checked')==checked) {
                }
            });
           // alert(str)
            //if(str!='')
            //{
            //    str = str.substring(1);
            //}

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/ajax.aspx/UpdateBultanArchiveIds",
                data: "{'bultanId':" + bultanId + ",'newsIds':'" + str + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                     alert('عملیات با موفقیت انجام شد');

                  
                },
                error: function (msg) {
                  
                }
            });
        }
    </script>
</asp:Content>
