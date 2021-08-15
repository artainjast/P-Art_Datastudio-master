<%@ Page Title="سیستم پایش اخبار" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/LoginMaster.Master"
    AutoEventWireup="true" CodeBehind="LoginNamayandeh.aspx.cs" Inherits="P_Art.Pages.P_Art.LoginNamayandeh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Pages/P-Art/Styles/CssNamayandeh.css?v2" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="header_box">
        <div id="online_user">
            <img id="Img1" src="~/Pages/P-Art/Images/people.png" alt="افراد آنلاین در سیستم"
                runat="server" />
            کاربران آنلاین سیستم
              <span id="lblUserCount" runat="server">0
              </span>
        </div>
        <div id="lblDate" runat="server">
        </div>
    </div>

    <nav id="header-links">
        <ul>

            <li><a href="#">درباره ما</a>

            </li>
            <li class="Seprator">•</li>
            <li><a href="#">تماس با ما</a></li>
            <li class="Seprator">•</li>
            <li><a href="#">همکاری با ما</a></li>
        </ul>

    </nav>

    <div class="loginBox">
        <div class="logo">
            <img id="Img2" src="~/Pages/P-Art/Images/project-logo.png" alt=""
                runat="server" />
        </div>
        <table>
            <tr>
                <td>نام کاربری :
                </td>
                <td>
                    <asp:TextBox ID="txt_UserName" runat="server" CssClass="TextBox" />
                    <asp:RequiredFieldValidator Font-Names="tahoma" Font-Bold="true" ID="rq_UserName"
                        runat="server" ControlToValidate="txt_UserName" ErrorMessage="*" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td>رمز عبور : 
                </td>
                <td>
                    <asp:TextBox TextMode="Password" ID="txt_Password" runat="server" CssClass="TextBox" />
                    <asp:RequiredFieldValidator Font-Names="tahoma" Font-Bold="true" ID="rq_Password"
                        runat="server" ControlToValidate="txt_Password" ErrorMessage="*" ForeColor="Red" />
                </td>
            </tr>
            <tr style="display: none">


                <td colspan="2" style="text-align: left; padding-top: 40px;">
                    <asp:Button runat="server" ID="btn_Login" CssClass="BtnRed" Text="ورود"
                        OnClick="btn_Login_Click" />
                </td>
            </tr>
        </table>
    </div>


    <div id="rightMenu">
        <span class="titleSpan">آخرین بروز رسانی

        </span>
        <div class="navMenu">
            <ul>
                <asp:Repeater ID="rpt_menu" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="navItem">
                                <a href="#" itemid="<%#Eval("PanelId") %>">
                                    <img src='<%# string.Format("~/Pages/P-Art/Images/{0}",Eval("ImagePath")) %>' runat="server" />
                                    <span class="ItemTitle">
                                        <%#Eval("PanelName") %>
                                    </span>
                                    <span class="ItemDetail">
                                        <%#Eval("District") %>
                                    </span>
                                </a>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div id="leftMenu">
        <div id="detailContent">
            <div class="ItemImage" id="merqueeImage">

                <img src="~/Pages/P-Art/Images/azin.jpg" runat="server" />

            </div>
            <marquee onmouseover="this.stop();" onmouseout="this.start();" class="ItemTitle"
                scrollamount="8" id="merqueeText" behavior="scroll" direction="right">Your scrolling text goes here</marquee>

        </div>
    </div>

    <div style="display: none">

        <!-- Begin WebGozar.com Counter code -->
        <script type="text/javascript" language="javascript" src="http://www.webgozar.ir/c.aspx?Code=2136670&amp;t=counter"></script>
        <noscript>
                    <a href="http://www.webgozar.com/counter/stats.aspx?code=2136670" target="_blank">&#1570;&#1605;&#1575;&#1585;</a></noscript>
        <!-- End WebGozar.com Counter code -->

    </div>
</asp:Content>
