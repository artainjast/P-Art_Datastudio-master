<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="SearchAllMediaPaging.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SearchAllMediaPaging" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>

    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
    <link href="../Styles/mynewstyesForNewPage.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <asp:HiddenField runat="server" ID="PageIndexHiddenField" />

    

    <div class="mytopbarfornavigat" >
        <div id="MediaTypes" class="mytopbarfornavigat-right">
          <div style="width: 90%;">
            <div class="mytopbarfornavigat-right-top">

               <div class="aaaa">
                    <input type="checkbox" id="NewsCheckBox" runat="server" class="CheckBox" />
                    <label  for="NewsCheckBox" class="MediaCheckBoxLabel myboxlable">اخبار</label>
                   <svg class="FiterIcons" id="rss" xmlns="http://www.w3.org/2000/svg" width="35.769" height="35.769" viewBox="0 0 35.769 35.769">
                      <circle id="Ellipse_10" data-name="Ellipse 10" cx="5.11" cy="5.11" r="5.11" transform="translate(0 25.548)" fill="#ff9800"/>
                      <path id="Path_1215" data-name="Path 1215" d="M17.033,31.846h6.811A23.875,23.875,0,0,0,0,8v6.814A17.052,17.052,0,0,1,17.033,31.846Z" transform="translate(0 3.923)" fill="#ff9800"/>
                      <path id="Path_1216" data-name="Path 1216" d="M35.769,35.769A35.809,35.809,0,0,0,0,0V6.812A28.988,28.988,0,0,1,28.958,35.769Z" fill="#ff9800"/>
                   </svg>

                </div> 
                <div class="aaaa">
                    <input type="checkbox" id="TelegramCheckBox" runat="server" class="CheckBox" />
                    <label for="TelegramCheckBox" class="MediaCheckBoxLabel myboxlable">تلگرام</label>
                    <svg class="FiterIcons" xmlns="http://www.w3.org/2000/svg" width="42.921" height="35.769" viewBox="0 0 42.921 35.769">
                      <path id="telegram" d="M16.842,25.574l-.71,9.987a2.482,2.482,0,0,0,1.983-.96l4.763-4.552,9.869,7.227c1.81,1.009,3.085.478,3.573-1.665L42.8,5.257l0,0c.574-2.675-.968-3.722-2.731-3.065L1.992,16.767c-2.6,1.009-2.559,2.457-.442,3.114l9.734,3.028L33.9,8.761c1.064-.7,2.032-.315,1.236.39Z" transform="translate(0 -2)" fill="#505050"/>
                    </svg>

                </div>
                <div class="aaaa">
                    <input type="checkbox" id="TwitterCheckBox" runat="server" class="CheckBox" />
                    <label for="TwitterCheckBox" class="MediaCheckBoxLabel myboxlable">توییتر</label>
                    <svg class="FiterIcons" xmlns="http://www.w3.org/2000/svg" width="44.023" height="35.769" viewBox="0 0 44.023 35.769">
                         <path id="twitter" d="M44.023,52.234a18.817,18.817,0,0,1-5.2,1.425,8.974,8.974,0,0,0,3.97-4.988,18.036,18.036,0,0,1-5.723,2.185,9.025,9.025,0,0,0-15.612,6.172,9.293,9.293,0,0,0,.209,2.058,25.546,25.546,0,0,1-18.6-9.44A9.028,9.028,0,0,0,5.839,61.708,8.913,8.913,0,0,1,1.761,60.6v.1a9.067,9.067,0,0,0,7.231,8.868,9.008,9.008,0,0,1-2.366.3,7.98,7.98,0,0,1-1.709-.154,9.111,9.111,0,0,0,8.433,6.287A18.134,18.134,0,0,1,2.16,79.843,16.9,16.9,0,0,1,0,79.719a25.408,25.408,0,0,0,13.845,4.05c16.608,0,25.688-13.757,25.688-25.682,0-.4-.014-.784-.033-1.167A18,18,0,0,0,44.023,52.234Z" transform="translate(0 -48)" fill="#505050"/>
                    </svg>

                </div>
                <div class="aaaa">
                    <input type="checkbox" id="InstagramCheckBox" runat="server" class="CheckBox" />
                    <label for="InstagramCheckBox" class="MediaCheckBoxLabel myboxlable">اینستاگرام</label>
                     <svg class="FiterIcons" id="instagram" xmlns="http://www.w3.org/2000/svg" width="40.021" height="40.021" viewBox="0 0 40.021 40.021">
                      <path id="Path_1213" data-name="Path 1213" d="M27.514,0H12.506A12.508,12.508,0,0,0,0,12.506V27.514A12.508,12.508,0,0,0,12.506,40.021H27.514A12.508,12.508,0,0,0,40.021,27.514V12.506A12.508,12.508,0,0,0,27.514,0Zm8.754,27.514a8.764,8.764,0,0,1-8.754,8.754H12.506a8.764,8.764,0,0,1-8.754-8.754V12.506a8.764,8.764,0,0,1,8.754-8.754H27.514a8.764,8.764,0,0,1,8.754,8.754Z" fill="#505050"/>
                      <path id="Path_1214" data-name="Path 1214" d="M138.005,128a10.005,10.005,0,1,0,10.005,10.005A10.006,10.006,0,0,0,138.005,128Zm0,16.258a6.253,6.253,0,1,1,6.253-6.253A6.262,6.262,0,0,1,138.005,144.258Z" transform="translate(-117.995 -117.995)" fill="#505050"/>
                      <circle id="Ellipse_9" data-name="Ellipse 9" cx="1.333" cy="1.333" r="1.333" transform="translate(29.433 7.922)" fill="#505050"/>
                    </svg>                

                </div>
            </div>
            <div class="mytopbarfornavigat-right-bottom">
                <div class="mytopbarfornavigat-right-bottom-btn">
                    <input type="checkbox" id="MovieCheckBox" runat="server" class="CheckBox" />
                    <label for="MovieCheckBox" class="MediaCheckBoxLabel ">ویدیو</label>
                    <svg class="FiterIcons" id="Group_234" data-name="Group 234" xmlns="http://www.w3.org/2000/svg" width="36.603" height="34.316" viewBox="0 0 36.603 34.316">
                      <g id="Group_233" data-name="Group 233">
                        <path id="Path_1217" data-name="Path 1217" d="M33.386,24.578H16.156L21.3,17.714a1.072,1.072,0,0,0-1.715-1.286l-5.577,7.434L8.436,16.428A1.072,1.072,0,1,0,6.72,17.714l5.148,6.864H3.217A3.221,3.221,0,0,0,0,27.795V47.1a3.221,3.221,0,0,0,3.217,3.217H33.386A3.221,3.221,0,0,0,36.6,47.1v-19.3A3.221,3.221,0,0,0,33.386,24.578ZM25.88,44.953a1.072,1.072,0,0,1-1.072,1.072H5.362a1.072,1.072,0,0,1-1.072-1.072V29.94a1.072,1.072,0,0,1,1.072-1.072H24.807A1.072,1.072,0,0,1,25.88,29.94Zm4.289,1.072a2.145,2.145,0,1,1,2.145-2.145A2.148,2.148,0,0,1,30.169,46.025Zm1.072-6.434H29.1a1.072,1.072,0,1,1,0-2.145h2.145a1.072,1.072,0,0,1,0,2.145Zm0-4.289H29.1a1.072,1.072,0,1,1,0-2.145h2.145a1.072,1.072,0,0,1,0,2.145Zm0-4.289H29.1a1.072,1.072,0,1,1,0-2.145h2.145a1.072,1.072,0,0,1,0,2.145Z" transform="translate(0 -15.999)" fill="#505050"/>
                      </g>
                    </svg>


                </div>
           
                <div class="mytopbarfornavigat-right-bottom-btn" >
                    <input type="checkbox" id="Checkbox1" runat="server" class="CheckBox" />
                    <label for="MovieCheckBox" class="MediaCheckBoxLabel ">رادیو</label>
                    <svg class="FiterIcons" xmlns="http://www.w3.org/2000/svg" width="37.506" height="34.316" viewBox="0 0 37.506 34.316">
                      <g id="vintage-radio-with-antenna-and-tuner" transform="translate(0 -12.853)">
                        <path id="Path_1218" data-name="Path 1218" d="M68.83,21.5l20.558-5.538-.037-.134a1.825,1.825,0,1,0-.41-1.143c0,.012,0,.022,0,.034L67.564,20.481A3.47,3.47,0,0,1,68.83,21.5Z" transform="translate(-59.18)" fill="#505050"/>
                        <path id="Path_1219" data-name="Path 1219" d="M30.615,76.119a2.854,2.854,0,0,0-3.037,2.12h6.075A2,2,0,0,0,33.11,77.1a3.153,3.153,0,0,0-1.542-.859A3.882,3.882,0,0,0,30.615,76.119Z" transform="translate(-24.156 -55.415)" fill="#505050"/>
                        <path id="Path_1220" data-name="Path 1220" d="M14.127,289.385h0Z" transform="translate(-12.373 -242.216)" fill="#505050"/>
                        <path id="Path_1221" data-name="Path 1221" d="M2.782,98.5H1.754C.88,98.5,0,101.6,0,103.022v12.913c0,1.623.936,5.6,1.754,5.6H35.176c.859,0,2.329-4.127,2.329-5.6V103.022c0-1.311-1.4-4.519-2.329-4.521H2.782Zm17.7,20.151a.7.7,0,0,1-1.4,0v-7.279a.7.7,0,0,1,1.4,0Zm3.29,0a.7.7,0,0,1-1.4,0v-7.279a.7.7,0,0,1,1.4,0Zm3.29,0a.7.7,0,0,1-1.4,0v-7.279a.7.7,0,0,1,1.4,0Zm3.29,0a.7.7,0,0,1-1.4,0v-7.279a.7.7,0,0,1,1.4,0Zm3.29,0a.7.7,0,0,1-1.4,0v-7.279a.7.7,0,0,1,1.4,0ZM17.766,101.943a1.468,1.468,0,0,1,1.468-1.468H32.748a1.468,1.468,0,0,1,1.468,1.468v4.3a1.468,1.468,0,0,1-1.468,1.468H19.234a1.468,1.468,0,0,1-1.468-1.468v-4.3Zm-6.719,3.314a2.8,2.8,0,1,1-2.8-2.8A2.8,2.8,0,0,1,11.046,105.257Z" transform="translate(0 -75.02)" fill="#505050"/>
                        <path id="Path_1222" data-name="Path 1222" d="M159.2,125.419l.013,2.511,1.316-.006-.014-2.507,2.505-.005v-.658l-2.508.005-.013-2.523-1.316.006.013,2.52-10.793.022,0,.658Z" transform="translate(-129.986 -95.808)" fill="#505050"/>
                      </g>
                    </svg>
                </div>
            </div>
          </div>  
        </div>
        <div class="mytopbarfornavigat-left">
            <span>
                <span>از تاریخ</span>
                <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="width: 68px;" />
            </span>
            <span>
                <span>از ساعت</span>
                <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align: center" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
                    ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                </asp:RegularExpressionValidator>
            </span>
            <span>
                <span>تا تاریخ</span>
                <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 68px;" />
            </span>
            <span>
                <span>تا ساعت</span>
                <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align: center" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour"
                    ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                </asp:RegularExpressionValidator>
            </span>
       
            <span>
                <span>کلید واژه</span>
                <asp:TextBox ID="txt_search" runat="server" CssClass="textbox" Width="200" />
            </span>
            <span>
                <label for="PageSizeDropDownList">تعداد در صفحه  </label>

                <asp:DropDownList runat="server" ID="PageSizeDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" Selected="True" />
                    <asp:ListItem Text="50" Value="50" />
                    <asp:ListItem Text="100" Value="100" />
                </asp:DropDownList>

            </span>

            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />

        </div>

    </div>


    <div class="PagingContainer persian">
        <div id="topPagination" runat="server" class="PagingPagination persian"></div>

        <div id="pagingGrid" runat="server" class="pagingGrid">


            <asp:Repeater ID="pagingGridRepeater" runat="server">
                <HeaderTemplate>
                    <div class="pagingGridContainer">
                        <div class="pagingGridHeader">
                            <span class="HeaderMediaType">نوع</span>
                            <span class="HeaderTitleAllSearch">عنوان</span>
                            <span class="HeaderSite">منبع</span>
                            <span class="HeaderDateTime">زمان</span>
                        </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="GridContainer">
                        <div class="GridItem">
                            <span class="ItemMediaType" title="<%# Eval("MediaType") %>">
                                <%# GetMediaTypeLogo( Convert.ToInt32(Eval("MediaTypeId")) )%>
                            </span>

                            <span class="ItemTitleAllSearch" title='<%# Eval("Title") %>' data-id='<%# Eval("Id") %>' data-typeid='<%# Eval("MediaTypeId") %>'>
                                <%# Eval("Title") %>
                            </span>

                            <span class="ItemSite" title='<%# Eval("ReferenceTitle") %>'>
                                <%# Eval("ReferenceTitle").ToString().Trim() %>
                            </span>

                            <span class="ItemDateTime" title='<%# Eval("Date") %> -  <%# Eval("Time") %>'><i class="fas fa-calendar-alt"></i><%#" " + Eval("Date")+" " %>   <i class="fas fa-clock"></i><%# " " + Eval("Time") %></span>
                        </div>
                        <div id="GridItemDetail_<%# Eval("id")+"_"+ Eval("MediaTypeId")%>" class="Detail">
                            <div class="DetailHeader">
                                <p>
                                    <span class="MatnKhabar">شرح:</span>

                                    <span class="ShowNewsLink">
                                        <a href="<%#Eval("PanelUrl") %>" class="<%# Eval("PanelUrlVisibility") %>" target="_blank">نمایش</a>
                                    </span>

                                    <span class="NewsUrl">
                                        <a href="<%#Eval("OrginalUrl") %>" target="_blank" class="<%# Eval("OrginalUrlVisibility") %>">شاهد خبر</a>
                                    </span>

                                </p>

                            </div>
                            <div class="DetailContent"></div>
                        </div>

                    </div>
                </ItemTemplate>

                <FooterTemplate>
                    <div class="GridFooter">
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>



        <div id="buttomPagination" runat="server" class="PagingPagination persian">
        </div>
    </div>
  </div>

    <script type="text/javascript">
        $(document).ready(function () {

            Page_Init();
        });
        function Page_Init() {
            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

        }
    </script>

    <script>
        $("#lnk_filter").click(function (e) {

            $(".newsFilter").fadeToggle("slow", "linear");
            e.preventDefault();
        });
    </script>



    <script>
        $("#lnk_bultan").click(function (e) {

            $(".newsBultan").fadeToggle("slow", "linear");
            e.preventDefault();
        });
    </script>
    <%-- by this button when user clicked on news  then shown more compelete information in row buttom box --%>
    <script>

        $('.ItemTitleAllSearch').live('click', function (e) {

            var $this = $(this);
            var itemID = $this.attr('data-id');
            var typeID = $this.attr('data-typeid');
            var detailBoxId = `#GridItemDetail_${itemID}_${typeID}`;

            $thisDiv = $(detailBoxId);
            $thisDivContent = $(detailBoxId + " .DetailContent");

            if ($thisDivContent.is(":visible")) {

                $thisDiv.fadeToggle("slow", "linear");
                $thisDivContent.empty();

            } else {
                $thisDivContent.empty();
                $thisDivContent.append("<img id=\"imgLoadPage1\" style=\"text-align: center; margin: auto;  display:flex; max-width: 100px\" src=\"/Pages/P-Art/Images/loadingPaging.gif\">");

                $thisDiv.fadeToggle("slow", "linear");

                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/SearchAllMediaPaging.aspx/DetailShowItem",
                    data: "{'itemId':'" + itemID + "' ,'typeID': '" + typeID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d != null) {
                            $thisDivContent.empty();
                            if (typeID == 5) {
                                $thisDivContent.css("display", "flex");
                                $thisDivContent.append(`<video width="320" height="240" controls><source src="${data.d.MediaUrl}" type="video/mp4"></video>`);
                            }
                            else {
                                $thisDivContent.append(data.d.Body);
                                $thisDivContent.append(data.d.KeyTitles);
                            }


                        }

                    },
                    error: function (msg) {
                        alert('خطا');
                    }
                });
            }




            e.preventDefault();
        });
    </script>


</asp:Content>

