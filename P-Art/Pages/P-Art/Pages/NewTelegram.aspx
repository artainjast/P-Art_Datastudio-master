<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="NewTelegram.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.NewTelegram" %>
<%--<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>--%>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
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
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script>
        function Page_Init() {


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
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <style>
        .rowIndex {
            right:26px;
        }
    </style>
    <div class="DataCenterArchive persian">
        
                <div class="newsStream">
                    <div class="newsStreamHeader">
                        <span>تلگرام</span>
                    </div>
            
                <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl01$NewsIdHiddenField" id="NewsIdHiddenField" value="7375094">
                        <span class="rowIndex">۱ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl01$check_SelectNews"></span>
                        <a class="title" href="#"><span>بانك مركزي اعلام كرد:/پرداخت بيش از 50 هزار ميليارد ريال تسهيلات به شركت هاي دانش بنيان</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/24 - 10:44</label>
                        </span>
                    </article>
                </div>
            
                <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۲ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>عضو هيأت رئيسه كميسيون اقتصادي مجلس:/رئيس بانك مركزي تقويت پول ملي را دستور كار قرار دهد</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 11:21</label>
                        </span>
                    </article>
                </div>

                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۳ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>نخستين واكنش بانك مركزي تركيه به بحران ارزي</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 10:40</label>
                        </span>
                    </article>
                </div>

                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۴ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>درتامين ارزبانك مركزي كوتاهي شد/ثبت سفارش،ده برابر نياز كشور</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 11:21</label>
                        </span>
                    </article>
                </div>

                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۵ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>بانك صادرات در شاخص ارزش بازار در صدر گروه بانكي ها قرار گرفت</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 10:26</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۶ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>مدير شعب بانك كشاورزي خراسان جنوبي اعلام كرد؛/پرداخت بيش از 2 هزار ميليارد ريال تسهيلات به بخش كشاورزي</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 10:20</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۷ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>نمره قبولي در وصول مطالبات معوق بانك مسكن</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 10:19</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۸ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>مديرعامل بانك پارسيان:/بانك هاي خصوصي از افزايش نرخ سودبانكي استقبال نمي كنند</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 10:11</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۹ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>نسخه جديد موبايلت بانك سامان عرضه شد</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 10:08</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۱۰ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>تبريك بانك پاسارگاد به تيم ملي ووشوي جوانان ايران در برزيل</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 10:04</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۱۱ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>لغو برگزاري مجمع بانك گردشگري</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 09:35</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۱۲ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>با تسهيلات كارگشاي بانك آينده خريد كنيد</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 09:08</label>
                        </span>
                    </article>
                </div>


                                    <div class="showFehrest">
                    <article>
                        <input type="hidden" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$NewsIdHiddenField" id="NewsIdHiddenField" value="7375119">
                        <span class="rowIndex">۱۳ )</span>
                        <span class="CheckBox"><input id="check_SelectNews" type="checkbox" name="ctl00$PanelContentPlaceHolder$dataCenterNewsArchiveRepeater$ctl02$check_SelectNews"></span>
                        <a class="title" href="#"><span>آسمان بورس دوباره ابري شد</span></a>
                        <span class="rowDateTime ">
                            <label id="date">1397/05/23 - 08:20</label>
                        </span>
                    </article>
                </div>


            
                </div>
            
    </div>
</asp:Content>
