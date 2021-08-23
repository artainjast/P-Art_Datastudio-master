<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="SearchAllMediaPaging.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SearchAllMediaPaging" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>
    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />
    <link href="/Pages/P-Art/Styles/mynewstyesForNewPage.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <asp:HiddenField runat="server" ID="PageIndexHiddenField" />

    

    <div class="mytopbarfornavigat" >
        <div id="MediaTypes" class="mytopbarfornavigat-right">
          <div style="width: 90%;">
            <div class="mytopbarfornavigat-right-top">

               <div class="aaaa" id="mydivid1"  >
                          <input type="checkbox" id="NewsCheckBox" runat="server" class="CheckBox checkbox-input-hiddener" hidden  />
                    <label  for="NewsCheckBox" class="MediaCheckBoxLabel myboxlable">اخبار</label>
                   <svg class="FiterIcons" id="rss" xmlns="http://www.w3.org/2000/svg" width="35.769" height="35.769" viewBox="0 0 35.769 35.769">

                      <circle id="Ellipse_10" data-name="Ellipse 10" cx="5.11" cy="5.11" r="5.11" transform="translate(0 25.548)" fill="#ff9800"/>
                      <path id="Path_1215" data-name="Path 1215" d="M17.033,31.846h6.811A23.875,23.875,0,0,0,0,8v6.814A17.052,17.052,0,0,1,17.033,31.846Z" transform="translate(0 3.923)" fill="#ff9800"/>
                      <path id="Path_1216" data-name="Path 1216" d="M35.769,35.769A35.809,35.809,0,0,0,0,0V6.812A28.988,28.988,0,0,1,28.958,35.769Z" fill="#ff9800"/>
                   </svg>

                </div> 
               
                <div class="aaaa" id="mydivid2">
                        <input type="checkbox" id="TwitterCheckBox" runat="server" class="CheckBox checkbox-input-hiddener" hidden />
                    
                    <label for="TwitterCheckBox" class="MediaCheckBoxLabel myboxlable">توییتر</label>
                    <svg class="FiterIcons" xmlns="http://www.w3.org/2000/svg" width="44.023" height="35.769" viewBox="0 0 44.023 35.769">
                        <path id="twitter" d="M44.023,52.234a18.817,18.817,0,0,1-5.2,1.425,8.974,8.974,0,0,0,3.97-4.988,18.036,18.036,0,0,1-5.723,2.185,9.025,9.025,0,0,0-15.612,6.172,9.293,9.293,0,0,0,.209,2.058,25.546,25.546,0,0,1-18.6-9.44A9.028,9.028,0,0,0,5.839,61.708,8.913,8.913,0,0,1,1.761,60.6v.1a9.067,9.067,0,0,0,7.231,8.868,9.008,9.008,0,0,1-2.366.3,7.98,7.98,0,0,1-1.709-.154,9.111,9.111,0,0,0,8.433,6.287A18.134,18.134,0,0,1,2.16,79.843,16.9,16.9,0,0,1,0,79.719a25.408,25.408,0,0,0,13.845,4.05c16.608,0,25.688-13.757,25.688-25.682,0-.4-.014-.784-.033-1.167A18,18,0,0,0,44.023,52.234Z" transform="translate(0 -48)" fill="#505050"/>
                    </svg>
                    

                    
                </div>
                 <div class="aaaa" id="mydivid3">
                      <input type="checkbox" id="TelegramCheckBox" runat="server" class="CheckBox checkbox-input-hiddener" hidden />
                  
                    <label for="TelegramCheckBox" class="MediaCheckBoxLabel myboxlable">تلگرام</label>
                    <svg class="FiterIcons" xmlns="http://www.w3.org/2000/svg" width="42.921" height="35.769" viewBox="0 0 42.921 35.769">
                      <path id="telegram" d="M16.842,25.574l-.71,9.987a2.482,2.482,0,0,0,1.983-.96l4.763-4.552,9.869,7.227c1.81,1.009,3.085.478,3.573-1.665L42.8,5.257l0,0c.574-2.675-.968-3.722-2.731-3.065L1.992,16.767c-2.6,1.009-2.559,2.457-.442,3.114l9.734,3.028L33.9,8.761c1.064-.7,2.032-.315,1.236.39Z" transform="translate(0 -2)" fill="#505050"/>
                    </svg>

                </div>
                <div class="aaaa" id="mydivid4">
                       <input type="checkbox" id="InstagramCheckBox" runat="server" class="CheckBox checkbox-input-hiddener" hidden />
                   
                    <label for="InstagramCheckBox" class="MediaCheckBoxLabel myboxlable">اینستاگرام</label>
                     <svg class="FiterIcons" id="instagram" xmlns="http://www.w3.org/2000/svg" width="40.021" height="40.021" viewBox="0 0 40.021 40.021">
                      <path id="Path_1213" data-name="Path 1213" d="M27.514,0H12.506A12.508,12.508,0,0,0,0,12.506V27.514A12.508,12.508,0,0,0,12.506,40.021H27.514A12.508,12.508,0,0,0,40.021,27.514V12.506A12.508,12.508,0,0,0,27.514,0Zm8.754,27.514a8.764,8.764,0,0,1-8.754,8.754H12.506a8.764,8.764,0,0,1-8.754-8.754V12.506a8.764,8.764,0,0,1,8.754-8.754H27.514a8.764,8.764,0,0,1,8.754,8.754Z" fill="#505050"/>
                      <path id="Path_1214" data-name="Path 1214" d="M138.005,128a10.005,10.005,0,1,0,10.005,10.005A10.006,10.006,0,0,0,138.005,128Zm0,16.258a6.253,6.253,0,1,1,6.253-6.253A6.262,6.262,0,0,1,138.005,144.258Z" transform="translate(-117.995 -117.995)" fill="#505050"/>
                      <circle id="Ellipse_9" data-name="Ellipse 9" cx="1.333" cy="1.333" r="1.333" transform="translate(29.433 7.922)" fill="#505050"/>
                    </svg>                

                </div>
            </div>
            <div class="mytopbarfornavigat-right-bottom">
                <div class="mytopbarfornavigat-right-bottom-btn" id="mydivid5">
                         <input type="checkbox" id="MovieCheckBox" runat="server" class="CheckBox checkbox-input-hiddener"  hidden/>
                
                    <label for="MovieCheckBox" class="MediaCheckBoxLabel ">ویدیو</label>
                    <svg class="FiterIcons" id="Group_234" data-name="Group 234" xmlns="http://www.w3.org/2000/svg" width="36.603" height="34.316" viewBox="0 0 36.603 34.316">
                      <g id="Group_233" data-name="Group 233">
                        <path id="Path_1217" data-name="Path 1217" d="M33.386,24.578H16.156L21.3,17.714a1.072,1.072,0,0,0-1.715-1.286l-5.577,7.434L8.436,16.428A1.072,1.072,0,1,0,6.72,17.714l5.148,6.864H3.217A3.221,3.221,0,0,0,0,27.795V47.1a3.221,3.221,0,0,0,3.217,3.217H33.386A3.221,3.221,0,0,0,36.6,47.1v-19.3A3.221,3.221,0,0,0,33.386,24.578ZM25.88,44.953a1.072,1.072,0,0,1-1.072,1.072H5.362a1.072,1.072,0,0,1-1.072-1.072V29.94a1.072,1.072,0,0,1,1.072-1.072H24.807A1.072,1.072,0,0,1,25.88,29.94Zm4.289,1.072a2.145,2.145,0,1,1,2.145-2.145A2.148,2.148,0,0,1,30.169,46.025Zm1.072-6.434H29.1a1.072,1.072,0,1,1,0-2.145h2.145a1.072,1.072,0,0,1,0,2.145Zm0-4.289H29.1a1.072,1.072,0,1,1,0-2.145h2.145a1.072,1.072,0,0,1,0,2.145Zm0-4.289H29.1a1.072,1.072,0,1,1,0-2.145h2.145a1.072,1.072,0,0,1,0,2.145Z" transform="translate(0 -15.999)" fill="#505050"/>
                      </g>
                    </svg>


                </div>
           
                <div class="mytopbarfornavigat-right-bottom-btn" id="mydivid6" >
                         <input type="checkbox" id="Checkbox1" runat="server" class="CheckBox checkbox-input-hiddener"  hidden/>
                   
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
        <div class="mytopbarfornavigat-left ">

              <div class="Mydisplayerflex ">
                                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24" height="24" viewBox="0 0 24 24">
                  <image id="loupe" width="24" height="24" xlink:href="data:image/png;base64,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"/>
                </svg>
                <asp:TextBox ID="txt_search" runat="server" CssClass="textbox newinputstyle" Width="50%"  placeholder="برای جستجو کلید واژه مورد نظر خود را وارد کنید"/>
            </div>

            <div class="Mydisplayerflex secondflexrow">
                <div>
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
                </div>
                <div>
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
                </div>
            </div>
          
            <div class="Mydisplayerflex thirdflexrow">
                <div class="Mydisplayerflex">
                <label for="PageSizeDropDownList">تعداد نمایش در هر صفحه :  </label>

                <asp:DropDownList runat="server" ID="PageSizeDropDownList" CssClass="myselectorbtnnew" >
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" Selected="True" />
                    <asp:ListItem Text="50" Value="50" />
                    <asp:ListItem Text="100" Value="100" />
                </asp:DropDownList>
                </div>
                <div class="Mydisplayerflex mysearchinbtn ">
                     <asp:Button ID="btn_ShowNews" runat="server" CssClass="mynewbtncss" Text="شروع جستجو" OnClick="btn_ShowNews_Click" />
                </div>
            </div>

           

        </div>

    </div>


    <div id="mmd" class="PagingContainer persian" style="width: 103%;margin-right: -20px">
        <div id="topPagination" runat="server" style="font-family:'Conv_BTrafficBold'" class="PagingPagination persian mypagingstyle" ></div>

        <div id="pagingGrid" runat="server" class="pagingGrid">


            <asp:Repeater ID="pagingGridRepeater" runat="server">
                <HeaderTemplate>
                    <div class="pagingGridContainer mycontainerflex ">
                        <div class="pagingGridHeader mynewstyleeverynewscontainer">
                            <span class="HeaderMediaType">نوع</span>
                            <span class="HeaderTitleAllSearch">عنوان</span>
                            <span class="HeaderSite">منبع</span>
                            <span class="HeaderDateTime">زمان</span>
                        </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="GridContainer mynewstylenewscontainer" style=" background-color:transparent ;">
                        <div class="GridItem cardsstyles" style="width:100%  ; height: 300px; max-height:300px">
                            <div class="cardheader">
                                <span class="ItemMediaType" title="<%# Eval("MediaType") %>"style="width:30px;position: absolute;right: 5px;">
                                    <%# GetMediaTypeLogo( Convert.ToInt32(Eval("MediaTypeId")) )%>
                                   
                                     

                                </span>
                                <span class="ItemSite " style="font-size: 11px;margin-top: -5px;position: absolute;right: 32px;" title='<%# Eval("ReferenceTitle") %>'>
                                    <%# Eval("ReferenceTitle").ToString().Trim() %>
                                </span>
                            </div>
                             <div class="mynewimgdiv">
                                <img class="mynewimgfile" src='<%# Eval("MediaPicture") %>' alt="no photo" />
                                 <img class='playicon play_<%# Eval("MediaType") %>' src="" />
                            </div>
                            <span class="ItemTitleAllSearch textofnews" style="width: 90%;height: 30%;" title='<%# Eval("Title") %>' data-id='<%# Eval("Id") %>' data-typeid='<%# Eval("MediaTypeId") %>'>
                                <%# Eval("Title") %>
                            </span>
                           
                           <div class="Mydisplayerflex carddatebottom">
                                <div>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="14.242" height="14.242" viewBox="0 0 14.242 14.242">
                                      <g id="annual-calendar-page" opacity="0.44">
                                                <g id="Group_199" data-name="Group 199">
                                                  <path id="Path_1187" data-name="Path 1187" d="M12.3,0H1.942A1.945,1.945,0,0,0,0,1.942V12.3a1.945,1.945,0,0,0,1.942,1.942H12.3A1.945,1.945,0,0,0,14.242,12.3V1.942A1.945,1.945,0,0,0,12.3,0ZM13.6,12.3A1.3,1.3,0,0,1,12.3,13.6H1.942A1.3,1.3,0,0,1,.647,12.3V1.942A1.3,1.3,0,0,1,1.942.647H12.3A1.3,1.3,0,0,1,13.6,1.942Z" fill="#c60219"/>
                                                  <circle id="Ellipse_2" data-name="Ellipse 2" cx="0.549" cy="0.549" r="0.549" transform="translate(3.443 1.511)" fill="#c60219"/>
                                                  <circle id="Ellipse_3" data-name="Ellipse 3" cx="0.549" cy="0.549" r="0.549" transform="translate(6.572 1.511)" fill="#c60219"/>
                                                  <circle id="Ellipse_4" data-name="Ellipse 4" cx="0.549" cy="0.549" r="0.549" transform="translate(9.701 1.511)" fill="#c60219"/>
                                                  <rect id="Rectangle_448" data-name="Rectangle 448" width="1.984" height="1.764" transform="translate(4.805 5.568)" fill="#c60219"/>
                                                  <rect id="Rectangle_449" data-name="Rectangle 449" width="1.983" height="1.764" transform="translate(7.454 5.568)" fill="#c60219"/>
                                                  <rect id="Rectangle_450" data-name="Rectangle 450" width="1.984" height="1.764" transform="translate(10.101 5.568)" fill="#c60219"/>
                                                  <rect id="Rectangle_451" data-name="Rectangle 451" width="1.983" height="1.763" transform="translate(2.158 7.924)" fill="#c60219"/>
                                                  <rect id="Rectangle_452" data-name="Rectangle 452" width="1.984" height="1.763" transform="translate(4.805 7.924)" fill="#c60219"/>
                                                  <rect id="Rectangle_453" data-name="Rectangle 453" width="1.983" height="1.763" transform="translate(7.454 7.924)" fill="#c60219"/>
                                                  <rect id="Rectangle_454" data-name="Rectangle 454" width="1.984" height="1.763" transform="translate(10.101 7.924)" fill="#c60219"/>
                                                  <rect id="Rectangle_455" data-name="Rectangle 455" width="1.983" height="1.763" transform="translate(2.158 10.279)" fill="#c60219"/>
                                                  <rect id="Rectangle_456" data-name="Rectangle 456" width="1.984" height="1.763" transform="translate(4.805 10.279)" fill="#c60219"/>
                                                  <rect id="Rectangle_457" data-name="Rectangle 457" width="1.983" height="1.763" transform="translate(7.454 10.279)" fill="#c60219"/>
                                                  <rect id="Rectangle_458" data-name="Rectangle 458" width="1.984" height="1.763" transform="translate(10.101 10.279)" fill="#c60219"/>
                                                </g>
                                              </g>
                                    </svg>
                                     <span class="ItemDateTime" style="font-family:'Conv_BTrafficBold'" >  <%# Eval("Date") %> </span>
                                </div>
                                <div>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="14.242" height="14.242" viewBox="0 0 14.242 14.242">
                                        <path id="clock" d="M7.121,0a7.121,7.121,0,1,0,7.121,7.121A7.129,7.129,0,0,0,7.121,0Zm3.387,10.8a.593.593,0,0,1-.839,0L6.7,7.838a.591.591,0,0,1-.174-.42V3.561a.593.593,0,1,1,1.187,0V7.172l2.793,2.793a.593.593,0,0,1,0,.839Zm0,0" fill="#c60219" opacity="0.37"/>
                                    </svg>
                                     <span  class="ItemDateTime" style="font-family:'Conv_BTrafficBold'" >   <%# " " + Eval("Time") %></span>
                               </div>
                          </div>
                        </div>
                        <div>
                            
                         

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



        <div id="buttomPagination" style="font-family:'Conv_BTrafficBold'" runat="server" class="PagingPagination persian mypagingstyle">

        </div>
    </div>
  </div>
    <script>
        const mmd = document.getElementById("mmd");
        
        mmd.addEventListener("mouseenter", () => {
            const myposts = mmd.lastElementChild.firstElementChild.children;

            for (var i = 1; i < myposts.length - 1; i++) {
               // console.log(myposts[i].firstElementChild.children[2]);                    
                
                if (myposts[i].firstElementChild.children[1].firstElementChild.attributes[1].value === "" ) {
                    myposts[i].firstElementChild.children[1].firstElementChild.style.display = "none";
                    myposts[i].firstElementChild.children[2].style.top = "50px";
                  //  console.log("ss");
                }
            }
            const mycards = document.getElementById("cardsstyles");
            

        })

    </script>

    <script>

        const mydivid1 = document.getElementById("mydivid1");
        const mydivid2 = document.getElementById("mydivid2");
        const mydivid3 = document.getElementById("mydivid3");
        const mydivid4 = document.getElementById("mydivid4");

        console.log(mydivid1.firstElementChild);
        mydivid1.addEventListener("click", () => {
            //Rss
            
            if (mydivid1.firstElementChild.checked === false) {
                mydivid1.firstElementChild.checked = true;
                //mydivid1.style.borderColor = "#ee802f";
                mydivid1.style.backgroundColor = "#ff751361"
            }
            else {
                mydivid1.firstElementChild.checked = false;
                mydivid1.style.backgroundColor = "#EEEEEE";
                //mydivid1.style.borderColor = "#EEEEEE";
            }

        });
        mydivid2.addEventListener("click", () => {
            //tweeter
            if (mydivid2.firstElementChild.checked === false) {
                mydivid2.firstElementChild.checked = true;
                //mydivid2.style.borderColor = "#0088cc"; 
                mydivid2.style.backgroundColor = "#2ba1ea66"
            }
            else {
                mydivid2.firstElementChild.checked = false;
                //mydivid2.style.borderColor = "#EEEEEE";
                mydivid2.style.backgroundColor = "#EEEEEE"
            }

        });
        mydivid3.addEventListener("click", () => {
            //telegram
            if (mydivid3.firstElementChild.checked === false) {
                mydivid3.firstElementChild.checked = true;
                //mydivid3.style.borderColor = "#1DA1F2"; 
                mydivid3.style.backgroundColor = "#0349e65c"
            }
            else {
                mydivid3.firstElementChild.checked = false;
                //mydivid3.style.borderColor = "#EEEEEE";
                mydivid3.style.backgroundColor = "#EEEEEE"
            }


        });
        mydivid4.addEventListener("click", () => {
            //instagram
            if (mydivid4.firstElementChild.checked === false) {
                mydivid4.firstElementChild.checked = true;
                //mydivid4.style.borderColor = "#8a3ab9"; 
                mydivid4.style.backgroundColor = "#63049a54"
            }
            else {
                mydivid4.firstElementChild.checked = false;
                //mydivid4.style.borderColor = "#EEEEEE";
                mydivid4.style.backgroundColor = "#EEEEEE"
            }

        });
        mydivid5.addEventListener("click", () => {
            //video
            if (mydivid5.firstElementChild.checked === false) {
                mydivid5.firstElementChild.checked = true;
                //mydivid5.style.borderColor = "#ee802f";
                mydivid5.style.backgroundColor = "#f91f1fba"
            }
            else {
                mydivid5.firstElementChild.checked = false;
                //mydivid5.style.borderColor = "#EEEEEE";
                mydivid5.style.backgroundColor = "#EEEEEE"
            }

        });
        mydivid6.addEventListener("click", () => {
            //radio
            if (mydivid6.firstElementChild.checked === false) {
                mydivid6.firstElementChild.checked = true;
                //mydivid6.style.borderColor = "#ee802f";
                mydivid6.style.backgroundColor = "#8c2d0491"
            }
            else {
                mydivid6.firstElementChild.checked = false;
                //mydivid6.style.borderColor = "#EEEEEE";
                mydivid6.style.backgroundColor = "#EEEEEE"
            }

        });
    </script>
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

