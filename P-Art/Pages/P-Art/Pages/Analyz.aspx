<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Analyz.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Analyz" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/ui-lightness/jquery-ui-1.8.6.custom.css" />
    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery.tagedit.css" />

    <%--    <script src='/Pages/P-Art/Scripts/jquery-ui-1.8.6.custom.min.js' type="text/javascript"></script>--%>

    <script src='/Pages/P-Art/Scripts/jquery.autoGrowInput.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/jquery.tagedit.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/highcharts.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/tsort.min.js'></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/exporting.js") %>'></script>

    <script src="/Pages/P-Art/Scripts/jquery.qtip.js"></script>
    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>' type="text/javascript"></script>

    

<%--    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>' type="text/javascript"></script>
    <script src="/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js"></script>--%>

</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
     <div class="PageSubLink">
        <ul>
            <li><a href="/News/Latest/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوا</a></li>
            <li><a href="/keywords" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه</a></li>
            <li><a href="/KeywordAnalyse" runat="server"><span><i class="fab fa-keycdn"></i></span>آنالیز کلید واژه ها</a></li>
            <li><a href="/News/BultanArchive" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="/addnews" runat="server"><span><i class="fas fa-pen-square"></i></span>ثبت خبر</a></li>
            <li><a href="/Pages/P-Art/Pages/SavedNews.aspx" runat="server"><span><i class="fas fa-hdd"></i></span>اخبار ذخیره شده</a></li>
         
        </ul>
    </div>
    <section id="list-news">
        <section class="filter-box">
            <asp:DropDownList ID="drp_newsSource" runat="server" CssClass="btn btn-outline-info cur-p dropdown" Style="width: 150px;">
                <asp:ListItem Text="کلی" Value="0" Selected="True" />
                <asp:ListItem Text="جراید" Value="1" />
                <asp:ListItem Text="خبرگزاری ها" Value="2" />
            </asp:DropDownList>
            <span>از تاریخ</span>
            <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="width: 65px" />
            <span>تا تاریخ</span>
            <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 65px" />
            <a id="btn_ReportChart" class="btn btn-info cur-p" onclick="btn_ReportChart_Click()">نمایش گزارش</a>
            <asp:Button ID="AnalayzNewsBultanButton" runat="server" Text="ایجاد بولتن" CssClass="btn btn-info cur-p" OnClick="AnalayzNewsBultanButton_Click" />
        </section>
<%--    <div class="filter-box" style="position: relative;" runat="server" id="divFilter">
        <div class="ItemForm">
            <label style="display: inline-block; font-weight: bold;">عنوان بولتن</label>
            <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" placeholder="فاقد عنوان"/>
            
          
        </div>
    </div>--%>
        <asp:HiddenField ID="fld_today" runat="server" Value="" />
        <asp:HiddenField ID="fld_yestarday" runat="server" Value="" />
        <asp:HiddenField ID="fld_10day" runat="server" Value="" />
        <asp:HiddenField ID="fld_20day" runat="server" Value="" />
        <asp:HiddenField ID="fld_30day" runat="server" Value="" />
        <asp:HiddenField ID="fld_1month" runat="server" Value="" />
        <asp:HiddenField ID="fld_3month" runat="server" Value="" />
        <asp:HiddenField ID="fld_6month" runat="server" Value="" />
        <asp:HiddenField ID="fld_1year" runat="server" Value="" />

        <div id="report-result">
            <div id="box-waiting" class="alert alert-info" style="display: none">
                لطفا چند لحظه صبر کنید
            </div>
            <div id="keys-result">

                <div class="result-title chartContainer">
                    <span class="title">جدول توزیع فراوانی تعداد تکرار کلید واژه ها</span>
                    <a id="resultTitleButton" class="btn btn-info cur-p" style="float:left;" onclick="resultTitleButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress1" class="progressbar">
                    </div>

                    <div class="bar keyword1">
                        <input type="text" name="tag[]" value="" class="tag1" />
                    </div>
                    <table class="table-report1 AnalizetableStyle persian">
                        <thead>
                            <tr>
                                <th>کلید واژه</th>
                                <th>عناوین اخبار</th>
                                <th>خلاصه اخبار</th>
                                <th>متن اخبار</th>
                                <th>مجموع</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">جدول توزيع فراوانی تعداد اخبار کليد واژه ها</span>
                    <a id="resultKeyCountNewsButton" class="btn btn-info cur-p" style="float:left;" onclick="resultKeyCountNewsButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress11" class="progressbar"></div>
                     <table class="table-report2 AnalizetableStyle">
                    <thead>
                        <tr>
                            <th>کلید واژه</th>
                            <th>مجموع</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">درصد فراوانی مطالب منتشر شده به تفکيک نوع رسانه</span>
                    <a id="resultKeypPercentNewsButton" class="btn btn-info cur-p" style="float:left;" onclick="resultKeypPercentNewsButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress2" class="progressbar"></div>
                    <div id="chart1">
                    </div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">نمودار توزيع فراوانی مطالب منتشره در پايگاه های خبری</span>
                    <a id="FrequencyDistributionNewsButton" class="btn btn-info cur-p" style="float:left;" onclick="FrequencyDistributionNewsButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress3" class="progressbar"></div>
                    <div id="chart2" ></div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">نمودار توزيع فراوانی مطالب منتشره در روزنامه ها</span>
                    <a id="FrqDistributionNewsPaperButton" class="btn btn-info cur-p" style="float:left;" onclick="FrqDistributionNewsPaperButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress4" class="progressbar"></div>
                    <div id="chart4"> </div>
                </div>
                <div class="result-title chartContainer">
                    <span class="title">نمودار توزيع فراوانی تعداد اخبار کليد واژه ها</span>
                    <a id="FrqDistributionNewsKeysButton" class="btn btn-info cur-p" style="float:left;" onclick="FrqDistributionNewsKeysButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress5" class="progressbar"></div>
                    <div id="chart5"></div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">درصد فراوانی مطالب منتشر شده به تفکيک سو گيری در رسانه</span>
                    <a id="FrqDistributNewsOrientButton" class="btn btn-info cur-p" style="float:left;" onclick="FrqDistributNewsOrientButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress6" class="progressbar"></div>
                    <div id="chart6"></div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">نمودار فراوانی مطالب منتشر شده به تفکيک سو گيری در پايکاه های خبری</span>
                    <a id="FrqDistributNewsStationOrientButton" class="btn btn-info cur-p" style="float:left;" onclick="FrqDistributNewsStationOrientButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress7" class="progressbar"></div>
                    <div id="chart7"></div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">نمودار فراوانی مطالب منتشر شده به تفکيک سو گيری در پايکاه های روزنامه ها</span>
                    <a id="FrqDistributNewsPaperStationOrientButton" class="btn btn-info cur-p" style="float:left;" onclick="FrqDistributNewsPaperStationOrientButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress8" class="progressbar"></div>
                    <div id="chart8"></div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">درصد مطالب منتشر شده ازاشخاص خبر ساز سازمان</span>
                    <a id="PercentPeopleNewsButton" class="btn btn-info cur-p" style="float:left;" onclick="PercentPeopleNewsButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress9" class="progressbar"></div>
                    <div class="bar keyword2">
                        <span>اشخاص خبر ساز:</span><input type="text" name="tag[]" value="" class="tag2" />
                    </div>
                    <div id="chart9"></div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">نمودار توزيع قراوانی اخبار در استان های کشور</span>
                    <a id="FrqDistributNewsProvinceButton" class="btn btn-info cur-p" style="float:left;" onclick="FrqDistributNewsProvinceButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress10" class="progressbar"></div>
                    <div id="chart10"></div>
                </div>

                <div class="result-title chartContainer">
                    <span class="title">نمودار توزيع فراوانی اخبار منتشره از سوی روابط عمومی های استان ها</span>
                    <a id="FrqDistributNewsProvincePrButton" class="btn btn-info cur-p" style="float:left;" onclick="FrqDistributNewsProvincePrButton_Click()">نمایش گزارش در بازه زمانی</a>
                    <div id="progress12" class="progressbar"></div>
                    <div id="chart12"></div>
                </div>
            </div>
        </div>
    </section>

    <script type="text/javascript">

        $(document).ready(function () {
            Page_Init();
            $(".tag1").tagedit();
            $(".tag2").tagedit();

           

            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

        });

        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
        }


        function btn_ReportChart_Click() {
            $("#box-waiting").slideDown(700);
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadKeywords(fromDate, toDate, function () {
                analyz_LoadKeywords2(fromDate, toDate, function () {
                    analyz_LoadChart1(fromDate, toDate, function () {
                        analyz_LoadChart2(fromDate, toDate, function () {
                            analyz_LoadChart3(fromDate, toDate, function () {
                                analyz_LoadChart4(fromDate, toDate, function () {
                                    analyz_LoadChart5(fromDate, toDate, function () {
                                        analyz_LoadChart6(fromDate, toDate, function () {
                                            analyz_LoadChart9(fromDate, toDate, function () {
                                                analyz_LoadChart10(fromDate, toDate, function () {
                                                    analyz_LoadChart12(fromDate, toDate, function () {
                                                        analyz_LoadKeywordsChart(fromDate, toDate, function () {
                                                            finishAnalyz();
                                                        });
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });
                            })
                        });
                    });
                });
            }

                );
            //e.preventDefault();
        }



        function resultTitleButton_Click() {

            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();
            setTimeout(analyz_LoadKeywords(fromDate, toDate), 2000);
        }


        function resultKeyCountNewsButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadKeywords2(fromDate, toDate);
        }

        function resultKeypPercentNewsButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadChart1(fromDate, toDate);
        }

        function FrequencyDistributionNewsButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadChart2(fromDate, toDate);
        }

        function FrqDistributionNewsPaperButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadChart3(fromDate, toDate);
        }

        function FrqDistributionNewsKeysButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadKeywordsChart(fromDate, toDatete);
        }

        function FrqDistributNewsOrientButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadChart4(fromDate, toDate);
        }

        function FrqDistributNewsStationOrientButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadChart5(toDate, fromDate);
        }

        function FrqDistributNewsPaperStationOrientButton_Click() {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadChart6(fromDate, toDate);
        }

        function PercentPeopleNewsButton_Click()
        {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();

            analyz_LoadChart9(fromDate, toDate);

        }
        function FrqDistributNewsProvinceButton_Click()
        {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();
            analyz_LoadChart10(fromDate, toDatee);
        }
        function FrqDistributNewsProvincePrButton_Click()
        {
            var fromDate = $("#txt_fromDate").val();
            var toDate = $("#txt_toDate").val();
            analyz_LoadChart12(fromDate, toDate);
        }

    </script>
</asp:Content>
