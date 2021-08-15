<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.AddNews" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="~/Pages/P-Art/Scripts/chosen.jquery.js"></script>
    <link href="~/Pages/P-Art/Styles/chosen.css" rel="stylesheet" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            Page_Init();
            DoDropDownAutoComplete();
        });
        function Page_Init() {
            $('#<%= txt_date.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
        }
        function DoDropDownAutoComplete() {
            try {

                $(".chzn-select").chosen();
                $(".chzn-select-deselect").chosen(
                    {
                        allow_single_deselect: true,

                        //   no_results_clear: 'موردی یافت شد',
                        //   no_results: 'موردی یافت شد',
                        //   default_single_text: 'لطفا یک گزینه انتخاب نمایید',
                        //   default_multiple_text: 'لطفا چند گزینه انتخاب نمایید',
                        //  default_no_result_text: 'موردی یافت شد',
                    });
            }
            catch (ex) {
            }
        }

        

    </script>
<script>
    function showSitesList()
    {
        document.getElementById("sitesUl").removeAttribute("style");
        document.getElementById("sitesUl").style.display = 'block';
    }

    function myFunction() {
        showSitesList();
      // Declare variables
      var input, filter, ul, li, a, i, txtValue;
      input = document.getElementById('SelectedSiteTextBox');
      filter = input.value.toUpperCase();
      ul = document.getElementById("sitesUl");
      li = ul.getElementsByTagName('li');

      // Loop through all list items, and hide those who don't match the search query
      for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
          li[i].style.display = "";
        } else {
          li[i].style.display = "none";
        }
      }
}
</script>



</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <asp:HiddenField ID="SelectedSiteIDHiddenField" runat="server" value="" />
    <section class="posts">
        <div class="PageSubLink">
            <ul>
                <li><a href="/News/Latest/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
                <li><a href="/Analysis" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوا</a></li>
                <li><a href="/keywords" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه</a></li>
                <li><a href="/KeywordAnalyse" runat="server"><span><i class="fab fa-keycdn"></i></span>آنالیز کلید واژه ها</a></li>
                <li><a href="/News/BultanArchive" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
                <li style="color: #fec006"><a style="color: #fec006"  runat="server"><span><i class="fas fa-pen-square"></i></span>ثبت خبر</a></li>
                <li><a href="/Pages/P-Art/Pages/SavedNews.aspx" runat="server"><span><i class="fas fa-hdd"></i></span>اخبار ذخیره شده</a></li>
            </ul>
        </div>

        <table class="table-new-news">
            <thead>
                <tr>
                    <th colspan="2">ثبت خبر</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="2" >
                        <br />
                    </td>
                    
                </tr>
                <tr>
                    <td style="vertical-align: top;padding-top: 10px;position: relative;">منبع خبر</td>
                    <td>

                        <%--<asp:DropDownList ID="drp_source" runat="server" CssClass="btn btn-outline-info cur-p dropdown" />--%>
                        <asp:TextBox ID="SelectedSiteTextBox" placeholder="منبع خبر را وارد کنید" autocomplete="off" CssClass="textbox" runat="server" onKeyUp="myFunction()"></asp:TextBox>
                        <%--<ul id="sitesUl" runat="server"></ul>--%>
                        <asp:ListView ID="SitesListView" runat="server">
                            <LayoutTemplate>
                                <ul id="sitesUl" runat="server">
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
                                </ul>                
                            </LayoutTemplate>
                                <ItemTemplate>
                                    <li class="siteItem"><a data-title='<%#Eval("SiteTitle")%>' data-siteid='<%#Eval("SiteID")%>'><%#Eval("SiteTitle")%></a></li>
                                </ItemTemplate>
                            <EmptyDataTemplate>
                              
                            </EmptyDataTemplate>
                        </asp:ListView>

                    </td>
                </tr>
                <tr>
                    <td>تاریخ خبر</td>
                    <td>
                        <asp:TextBox ID="txt_date" runat="server" CssClass="textbox" Width="70px" />
                    </td>
                </tr>
                <tr>
                    <td>ساعت خبر</td>
                    <td>
                        <asp:TextBox ID="txt_newsTime" runat="server" CssClass="textbox" placeholder="مثال : 12:00" Width="70px" />
                        <asp:RegularExpressionValidator ID="rqvalidator" ControlToValidate="txt_newsTime" Display="Dynamic"
                            ValidationExpression="([0-1][0-9]|2[0-3]):([0-5][0-9])" ErrorMessage="لطفا زمان خبر را به صورت صحیح وارد نمایید. مثال:12:00"
                            ForeColor="Red" Font-Size="11px" runat="server"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>عنوان خبر</td>
                    <td>
                        <asp:TextBox ID="txt_title" runat="server" CssClass="textbox" Style="width: calc(100% - 285px)" />
                        <br />
                        <asp:RequiredFieldValidator ID="txt_title_RequiredValidator" ControlToValidate="txt_title" Display="Static" ErrorMessage="        *عنوان خبر باید وارد شود" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">خلاصه اخبار</td>
                    <td>
                        <asp:TextBox ID="txt_lead" runat="server" TextMode="MultiLine" CssClass="textbox" Style="width: calc(100% - 185px); max-width: calc(100% - 185px); min-height: 150px" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">متن کامل خبر</td>
                    <td>
                        <asp:TextBox ID="txt_body" runat="server" CssClass="textbox" TextMode="MultiLine" Style="width: calc(100% - 185px); max-width: calc(100% - 185px); min-height: 200px" />
                        <br />
                        <asp:RequiredFieldValidator ID="txt_bodyـRequiredValidator" ControlToValidate="txt_body" Display="Static" ErrorMessage="        *متن خبر باید وارد شود" ForeColor="Red"  runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>کلید واژه</td>
                    <td>
                        <asp:DropDownList ID="ddlKeywordList" runat="server" CssClass="btn btn-outline-info cur-p dropdown chzn-select"  />
                    </td>
                </tr>
                <tr>
                    <td>لینک خبر</td>
                    <td>
                        <asp:TextBox ID="txt_link" runat="server" CssClass="textbox" Style="width: calc(100% - 285px)" />
                    </td>
                </tr>

                <tr>
                    <td>مسیر عکس خبر</td>
                    <td>
                        <asp:TextBox ID="txt_picture" runat="server" CssClass="textbox" Style="width: calc(100% - 285px)" />
                    </td>
                </tr>
                <tr>
                    <td>نوع نمایش خبر</td>
                    <td>
                        <asp:DropDownList ID="ddlNewsTypeShow" runat="server" CssClass="btn btn-outline-info cur-p dropdown">
                            <asp:ListItem Text="معمولی" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="بریده جراید و خبرگزاری ها" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btn_save" runat="server" CssClass="btn btn-success cur-p" Text="ذخیره خبر" OnClick="btn_save_Click" />
                    </td>
                </tr>

            </tbody>
        </table>
    </section>
    <script>
        function hideSitesList()
        {
            document.getElementById("sitesUl").removeAttribute("style");
            document.getElementById("sitesUl").style.display = 'none';
        }
        
        hideSitesList();
    </script>
    <script>
        $(".siteItem a").click(function () {

            $("#SelectedSiteTextBox").val($(this).data('title'));
            $("#SelectedSiteIDHiddenField").val($(this).data('siteid'));
            hideSitesList();
        });


        $("#SelectedSiteTextBox").blur(function () {
            if ($(this).attr($(this).data('siteid') == null))
            {
                $(this).val("");
            }
            hideSitesList();
        });

    </script>
    
</asp:Content>
