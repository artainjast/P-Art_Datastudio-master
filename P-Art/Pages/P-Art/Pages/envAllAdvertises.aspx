<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="envAllAdvertises.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.envAllAdvertises" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src='/Pages/P-Art/Scripts/kamadatepicker.min.js' type="text/javascript"></script>
    <link href="/Pages/P-Art/Styles/kamadatepicker.min.css" rel="stylesheet" />

    <style>
        .bd-main {
            right: calc(50% - 105px) !important;
            top: 44px !important;
        }

        .bd-title {
            display: inline-flex;
        }
    </style>
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <asp:HiddenField runat="server" ID="PageIndexHiddenField" />
    <asp:HiddenField runat="server" ID="CampainIDHiddenField" />
    <asp:HiddenField runat="server" ID="SelectedBrandIdHiddenField" />


    <div class="PageSubLink">
        <ul>
            <li style="color: #fec006"><a style="color: #fec006" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <%-- <li><a href="/Analysis" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوا</a></li>--%>
            <li><a href="/AdvertiseImagesList" class="flat-gray-button"><span><i class="fas fa-calendar-day fa-sm"></i></span>وضعیت اکران روزانه</a></li>
            <li><a class="flat-gray-button"><span><i class="fas fa-poll fa-sm"></i></span>تبلیغات رقبا</a></li>
            <li><a class="flat-gray-button"><span><i class="fas fa-bullseye fa-sm"></i></span>کمپین ها</a></li>
            <li><a href="#" id="lnk_filter" class="flat-gray-button"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
        </ul>
    </div>

    <div class="newsFilter persian">
        <div>
            <span>جستجو بر اساس زمان</span>
            <input type="checkbox" id="searchHasDateTime" class="CheckBox" runat="server" />
            <input
                runat="server"
                type="text"
                id="txt_fromDate"
                class="textbox"
                style="width: unset; margin: 5px; display: none"
                placeholder="از تاریخ"
                lang="fa"
                readonly="readonly" />

            <span id="fTimeLable" style="display: none">از ساعت</span>
            <input
                type="time"
                runat="server"
                id="txt_fromHour"
                class="textbox"
                style="width: unset; margin: 5px; display: none"
                lang="fa" />
            <input
                runat="server"
                type="text"
                id="txt_toDate"
                class="textbox"
                style="width: unset; margin: 5px; display: none"
                placeholder="تا تاریخ"
                lang="fa"
                readonly="readonly" />
            <span id="toTimeLable" style="display: none">تا ساعت</span>
            <input
                type="time"
                runat="server"
                id="txt_toHour"
                class="textbox"
                style="width: unset; margin: 5px; display: none"
                lang="fa" />

            <br />
            <p>
                <input type="text" runat="server" id="txt_search" class="textbox" placeholder="عبارت جستجو" style="margin: 5px; width: 300px" />
            </p>

            <span>
                <label for="PageSizeDropDownList">تعداد در صفحه  </label>

                <asp:DropDownList runat="server" ID="PageSizeDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" Selected="True" />
                    <asp:ListItem Text="50" Value="50" />
                    <asp:ListItem Text="100" Value="100" />
                </asp:DropDownList>

            </span>

            <span>
                <asp:DropDownList runat="server" ID="BrandsDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                </asp:DropDownList>
            </span>
            <span>
                <select id="CampainsDropDownList" class="btn btn-outline-info cur-p" style="margin-left: 20px; height: 35px"></select>
            </span>
            <span>
                <asp:DropDownList runat="server" ID="StructureTypeDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                </asp:DropDownList>
            </span>
            <span>
                <asp:DropDownList runat="server" ID="AddressTypeDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                </asp:DropDownList>
            </span>

            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش تبلیغات" OnClick="btn_ShowNews_Click" />

        </div>

    </div>

    <div class="PagingContainer persian">
        <div id="topPagination" runat="server" class="PagingPagination persian"></div>

        <div id="pagingGrid" runat="server" class="pagingGrid  AdvertisePostWraper ">


            <asp:Repeater ID="pagingGridRepeater" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="AdvertiseCard">
                        <div class="AdvertiseImageContainer">
                            <img class="AdvertiseImage" src="<%# Eval("LastImageName").ToString() %>" onerror="this.src='/Pages/P-Art/Images/newsPreview.jpg'" alt="" />
                        </div>

                        <div class="container">
                            <div class="brandPic">
                                <span>
                                    <img src="<%# Eval("BrandImageName").ToString() %>" onerror="this.src='/Pages/P-Art/Images/profile-insta.jpg'" />
                                </span>
                                <span class="fullName"><%# Eval("BrandName").ToString() %></span>
                            </div>


                            <h5 class="DateTime persian"><b><%# Eval("FarsiDateString").ToString() %></b></h5>
                            <p><%# Eval("Title").ToString() %></p>
                            <a class="showPost" href="/ShowAdvertise/<%# Eval("AdvertiseId").ToString() %>" target="_blank">نمایش تبلیغ</a>

                        </div>
                        <div class="postTag"><span><i class='fas fa-map-marker-alt'></i></span><%# " " + Eval("Address").ToString() %></div>
                    </div>
                </ItemTemplate>

                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>



        <div id="buttomPagination" runat="server" class="PagingPagination persian">
        </div>
    </div>

    <script>
        $("#lnk_filter").click(function (e) {

            $(".newsFilter").fadeToggle("slow", "linear");
            e.preventDefault();
        });
    </script>

    <script>
        var customOptions = {
            placeholder: "روز / ماه / سال"
            , twodigit: true
            , closeAfterSelect: true
            , nextButtonIcon: "fa fa-arrow-circle-right"
            , previousButtonIcon: "fa fa-arrow-circle-left"
            , buttonsColor: "blue"
            , forceFarsiDigits: true
            , markToday: true
            , markHolidays: true
            , highlightSelectedDay: true
            , sync: true
            , gotoToday: true
        }
        kamaDatepicker('txt_fromDate', customOptions);
    </script>


    <script>
        var customOptions = {
            placeholder: "روز / ماه / سال"
            , twodigit: true
            , closeAfterSelect: true
            , nextButtonIcon: "fa fa-arrow-circle-right"
            , previousButtonIcon: "fa fa-arrow-circle-left"
            , buttonsColor: "blue"
            , forceFarsiDigits: true
            , markToday: true
            , markHolidays: true
            , highlightSelectedDay: true
            , sync: true
            , gotoToday: true
        }
        kamaDatepicker('txt_toDate', customOptions);
    </script>

    <script>
        $(document).ready(function () {

            var selectedBrandId = $('#SelectedBrandIdHiddenField').val();
            //init campain comboBox
            CampainsComboboxLoad(selectedBrandId);



        });

    </script>

    <script>
        $(window).load(function () {
            setCampainComboBoxIndex();
        });
    </script>


    <script>
        $('#searchHasDateTime').on('change', function (e) {
            var $this = $(this);
            var searchHasDateTime = !!$this.attr('checked')
            if (searchHasDateTime) {
                $('#txt_fromDate').fadeIn(500);
                $('#fTimeLable').fadeIn(500);
                $('#txt_fromHour').fadeIn(500);

                $('#txt_toDate').fadeIn(500);
                $('#toTimeLable').fadeIn(500);
                $('#txt_toHour').fadeIn(500);
            }
            else {
                $('#txt_fromDate').fadeOut(500);
                $('#fTimeLable').fadeOut(500);
                $('#txt_fromHour').fadeOut(500);

                $('#txt_toDate').fadeOut(500);
                $('#toTimeLable').fadeOut(500);
                $('#txt_toHour').fadeOut(500);
            }
            e.preventDefault();
        });
    </script>

    <script>
        $('#BrandsDropDownList').on('change', function (e) {
            var $this = $(this);
            var brandId = $this.find(":selected").val();
            CampainsComboboxLoad(brandId);
            e.preventDefault();
        });
    </script>


    <script>
        function CampainsComboboxLoad(brandId) {
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/envAllAdvertises.aspx/LoadCampainsComboBox",
                data: "{'brandIdstring':'" + brandId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $('#CampainsDropDownList').find('option').remove().end();
                    $('#CampainsDropDownList').append($('<option>', {
                        value: '-1',
                        text: 'تمام کمپین ها'
                    }));
                    $.each(data.d, function (i, item) {
                        $('#CampainsDropDownList').append($('<option>', {
                            value: item.CampainId,
                            text: item.Title
                        }));
                    });
                },
                error: function (msg) {
                    alert('خطا');
                    console.log(msg)
                }
            });
        }
    </script>


    <script>
        $('#CampainsDropDownList').on('change', function (e) {
            var $this = $(this);
            var getCampainId = $this.find(":selected").val();
            $('#CampainIDHiddenField').val(getCampainId);
            e.preventDefault();
        });
    </script>


    <script>
        function setCampainComboBoxIndex() {
            var campainId = $('#CampainIDHiddenField').val();
            if (!!campainId) {
                $('#CampainsDropDownList').val(campainId);
            }
            else {
                $('#CampainsDropDownList').val('-1');
            }

        }
    </script>


</asp:Content>
