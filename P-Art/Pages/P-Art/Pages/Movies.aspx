<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Movies" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jwplayer.js") %>' type="text/javascript"></script>
    <%--    <link href='<%= ResolveUrl("~/Pages/P-Art/Styles/owl.carousel.css")%>' rel="stylesheet" />
    <link href='<%= ResolveUrl("~/Pages/P-Art/Styles/owl.theme.default.css")%>' rel="stylesheet" />--%>
    <%--  <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/owl.carousel.js")%>' type="text/javascript"></script>--%>
    <script src="/Pages/P-Art/owl.carousel.js"></script>
    <link href="/Pages/P-Art/Styles/owl.carousel.css" rel="stylesheet" />
    <link href="/Pages/P-Art/Styles/owl.theme.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" />

    <link type="text/css" rel="stylesheet" href="/Pages/P-Art/Styles/jquery-ui.css" />
    <%--    <script src="http://code.jquery.com/jquery-1.10.2.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-migrate-1.4.1.js" type="text/javascript"></script>
    <%--    <script src="http://code.jquery.com/ui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>--%>
    <script src='/Pages/P-Art/Scripts/jquery.easing.1.3.js' type="text/javascript"></script>
    <script src='/Pages/P-Art/Scripts/AppScripts.js?ver=13.0' type="text/javascript"></script>
        <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>


</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <style>
        /*.owl-pagination {
            display: none !important;
        }

        .owl-carousel .owl-wrapper, .owl-carousel .owl-item {
            margin: 10px;
        }

        #movie-list .owl-prev {
            position: relative;
            bottom: 190px;
            left: -635px;
            font-size: 36px;
            background: none !important;
        }

        #movie-list .owl-next {
            position: relative;
            bottom: 190px;
            right: -635px;
            font-size: 36px;
            background: none !important;
        }

        #movie-most-visit .owl-prev {
            position: relative;
            bottom: 140px;
            left: -635px;
            font-size: 36px;
            background: none !important;
        }

        #movie-most-visit .owl-next {
            position: relative;
            bottom: 140px;
            right: -635px;
            font-size: 36px;
            background: none !important;
        }

        #owl-carousel-2 {
            height: 215px !important;
        }*/
    </style>
    <script>
        $(document).ready(function () {

            $('#<%= txt_fromDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });
            $('#<%= txt_toDate.ClientID%>').datepicker({ dateFormat: 'yy/mm/dd' });

            setTimeout(PlayVideo($("#hddFirstMovie").val()), 3000);

            $("#owl-carousel-1").owlCarousel({

                navigation: true, // Show next and prev buttons
                navigationText: [">", "<"],
                paginationSpeed: 400,
                paginationSpeed: 400,
                goToFirst: true,
                items: 5,
                itemsDesktop: false,
                itemsDesktopSmall: false,
                itemsTablet: false,
                itemsMobile: false

            });


            $("#owl-carousel-2").owlCarousel({

                navigation: true, // Show next and prev buttons
                navigationText: [">", "<"],
                paginationSpeed: 400,
                paginationSpeed: 400,
                goToFirst: true,
                items: 5,
                itemsDesktop: false,
                itemsDesktopSmall: false,
                itemsTablet: false,
                itemsMobile: false

            });
        });
    </script>
    <section id="sectionMovie" class="persian">
        <div style="display: none">
            <asp:HiddenField ID="hddFirstMovie" runat="server" />
        </div>

        <div id="noData" runat="server">
            متاسفانه هیچ اطلاعاتی در این بخش وجود ندارد با مدیر سیستم هماهنگ نمایید
        </div>
        <div id="divMovieFilter" class="divMovieFilter container" style="display: none;">
            <asp:TextBox CssClass="txtSearch" placeholder="جستجوی ویدیو ..." runat="server" ID="txtKeyword"></asp:TextBox>
            <asp:DropDownList CssClass="ddlNetwork" runat="server" ID="ddlNetwork">
                <asp:ListItem Value="همه شبکه ها" Text="همه شبکه ها" Selected="True"></asp:ListItem>
                <asp:ListItem Value="شبکه 1" Text="شبکه یک"></asp:ListItem>
                <asp:ListItem Value="شبکه 2" Text="شبکه دو"></asp:ListItem>
                <asp:ListItem Value="شبکه 3" Text="شبکه سه"></asp:ListItem>
                <asp:ListItem Value="شبکه 5" Text="شبکه پنج"></asp:ListItem>
                <asp:ListItem Value="شبکه خبر" Text="شبکه خبر"></asp:ListItem>
                <asp:ListItem Value="شبکه منوتو" Text="شبکه منوتو"></asp:ListItem>
                <asp:ListItem Value="شبکه بي بي سي" Text="شبکه بي بي سي"></asp:ListItem>
                <asp:ListItem Value="شبکه ایران اینترنشنال" Text="شبکه ایران اینترنشنال"></asp:ListItem>
                <asp:ListItem Value="شبکه صدای آمریکا" Text="شبکه صدای آمریکا"></asp:ListItem>

            </asp:DropDownList>
            <asp:Button runat="server" OnClick="btnSearch_Click" CssClass="btnSearch" ID="btnSearch" Text="جستجو" />
        </div>
        <div id="divPoster">
            <div id="videoPlayer" class="container">
                <img id="logo" src="~/Pages/P-Art/Images/ajax-loader.gif" runat="server" />
                <div id="PlayerElement">
                </div>
                <div id="video-info">
                    <table>
                        <tr>
                            <td>عنوان : 
                            </td>
                            <td>
                                <span id="info-title"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>تاریخ ویدیو :
                            </td>
                            <td>
                                <span id="info-date"></span>
                            </td>
                        </tr>
                        <tr>

                            <td>منبع خبر :
                            </td>
                            <td>
                                <span id="info-source"></span>
                            </td>

                        </tr>
                    </table>
                    <a href="#" class="ButtonRed">دریافت ویدیو
                    </a>
                </div>
            </div>
        </div>
        <section id="movie-list">
            <div class="containerOut">
                <span>
                    <span>از تاریخ</span>
                    <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="width: 68px;" />
                </span>
                <span>
                    <span>تا تاریخ</span>
                    <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 68px;" />
                </span>
                <span>
                    <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
                </span>
                <div class="network-tools">
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=1&network=شبکه 1" title="شبکه 1">شبکه یک</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=1&network=شبکه 2" title="شبکه 2">شبکه دو</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=1&network=شبکه 3" title="شبکه 3">شبکه سه</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=1&network=شبکه 4" title="شبکه 4">شبکه چهار</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=1&network=شبکه 5" title="شبکه 5">شبکه پنج</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=1&network=شبکه خبر" title="شبکه خبر">شبکه خبر</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=2&network=شبکه منوتو" title="شبکه منوتو">شبکه منوتو</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=2&network=شبکه بي بي سي" title="شبکه بي بي سي">شبکه بی بی سی</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=2&network=شبکه ایران اینترنشنال" title="شبکه ایران اینترنشنال">شبکه ایران اینترنشنال</a>
                    <a class="btn btn-outline-secondary cur-p" href="/Movies/Latest?type=2&network=شبکه صدای آمریکا" title="شبکه صدای آمریکا">شبکه صدای آمریکا</a>
                </div>
                <div id="owl-carousel-1" class="owl-carousel owl-theme">
                    <asp:Repeater ID="lst_movies" runat="server">
                        <ItemTemplate>
                            <article>
                                <a class="ShowVideo" href="javascript:void(0)" title="<%# Eval("MovieId") %>">

                                    <figure>
                                        <img src="<%#Eval("PosterPath") %>" alt="" />
                                        <span class="networkName"><%#Eval("NetworkName") %></span>
                                        <figcaption>
                                            <span><%#Eval("VideoTime") %></span>
                                            <p title="<%# Eval("Title") %>"><%# GetTitle(Eval("Title").ToString()) %></p>

                                        </figcaption>
                                    </figure>

                                </a>
                                <span class="lblVideoTime">
                                    <%#Eval("PlayTime") %><span>
                                        <%# Eval("VideoDate") %>
                                    </span>
                                </span>
                                <a href="<%# Eval("VideoPath") %>" class="lblDownloadVideo btn btn-outline-success videoDownloadLink" download="<%# Eval("Title") %>">دریافت</a>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </section>
        <section id="movie-most-visit">
            <div class="containerOut">
                <div class="titr container">
                    <span class="fa fa-circle"></span>
                    <span>جدیدترین ویدیوها</span>
                </div>
                <div id="owl-carousel-2" class="owl-carousel owl-theme">
                    <asp:Repeater ID="rptMostView" runat="server">
                        <ItemTemplate>
                            <article>
                                <a class="ShowVideo" href="javascript:void(0)" title="<%# Eval("MovieId") %>">

                                    <figure>
                                        <img src="<%#Eval("PosterPath") %>" alt="<%# Eval("Title") %>" />
                                        <span class="networkName"><%#Eval("NetworkName") %></span>
                                        <figcaption>
                                            <span><%#Eval("VideoTime") %></span>
                                            <p title="<%# Eval("Title") %>"><%# GetTitle(Eval("Title").ToString()) %></p>


                                        </figcaption>

                                    </figure>
                                </a>
                                <span class="lblVideoTime">
                                    <%#Eval("PlayTime") %><span>
                                        <%# Eval("VideoDate") %>
                                    </span>
                                </span>
                                <a href="<%# Eval("VideoPath") %>" class="lblDownloadVideo btn btn-outline-success videoDownloadLink" download="<%# Eval("Title") %>">دریافت</a>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>

        <section id="movie-archive">
            <div class="container">
                <div class="titr">
                    <span class="fa fa-circle"></span>
                    <span>آرشیو ویدیوها</span>
                </div>

                <asp:Repeater ID="rptMovieArchive" runat="server">
                    <ItemTemplate>
                        <article>
                            <a class="ShowVideo" href="javascript:void(0)" title="<%# Eval("Title") %>">

                                <figure>
                                    <img src="<%#Eval("PosterPath") %>" alt="<%# Eval("Title") %>" />
                                    <span class="networkName"><%#Eval("NetworkName") %></span>
                                    <figcaption>
                                        <span><%#Eval("VideoTime") %></span>
                                        <p title="<%# Eval("Title") %>"><%# GetTitle(Eval("Title").ToString()) %> </p>

                                    </figcaption>
                                </figure>
                            </a>
                            <span class="lblVideoTime">
                                <%#Eval("PlayTime") %><span>
                                    <%# Eval("VideoDate") %>
                                </span>
                            </span>
                            <a href="<%# Eval("VideoPath") %>" class="lblDownloadVideo btn btn-outline-success videoDownloadLink" download="<%# Eval("Title") %>">دریافت</a>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>

    </section>
</asp:Content>
