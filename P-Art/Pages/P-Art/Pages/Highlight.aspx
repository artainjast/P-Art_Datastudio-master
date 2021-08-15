<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Highlight.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Highlight" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tabbed {
            width: 100%;
        }
    </style>
    <script src="/Pages/P-Art/Scripts/isotope.pkgd.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.tinycarousel.min.js"></script>
    <script src="/Pages/P-Art/Scripts/jquery.fancybox.js"></script>
    <link href="/Pages/P-Art/Styles/jquery.fancybox.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="tabbed">

        <ul>
            <li class="selected"><a href="~/news/Highlight" runat="server">در یک نگاه</a></li>
            <li><a href="/news/Latest">تازه ها</a></li>
            <li><a href="/Analysis">تحلیل محتوا</a></li>
            <li class="selected"><a href="/News/BultanArchive" runat="server">آرشیو بولتن</a></li>
        </ul>

        <ul style="float: left">
            <li>
                <a href="#" id="lbl-sort-0">کلیه منابع
                </a>
            </li>

            <li>
                <a href="#" id="lbl-sort-1">خبرگزاری ها
                </a>
            </li>
            <li>
                <a href="#" id="lbl-sort-2">روزنامه ها
                </a>
            </li>

        </ul>
    </div>
    <div class="newspaper-box">
                <div class="carousel">
                    <a class="buttons prev" href="#">></a>
                    <div class="viewport">
                        <asp:Repeater ID="rpt_newspaper" runat="server">
                            <HeaderTemplate>
                                <ul class="overview">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <a href='<%# Eval("OriginalPath") %>' class="fancybox" rel="group">
                                        <img src='<%# Eval("previewPath") %>' />
                                        <span><%# Eval("Title") %></span>
                                    </a>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                    <a class="buttons next" href="#"><</a>
                </div>
            </div>
    <div class="highlight-box">

        <asp:Repeater ID="rpt_highlights" runat="server" OnItemDataBound="rpt_highlights_ItemDataBound">
            <ItemTemplate>
                <div class="hightItem" runat="server" id="hightItem" data-type='<%# Eval("SiteType") %>'>
                    <a href='<%# string.Format("/NewsList/?SiteId={0}&FromDate={1}&ToDate={2}",Eval("SiteId"),FromDate(),ToDate()) %>'>
                        <asp:HiddenField ID="fld_count" runat="server" Value='<%# Eval("CCount") %>' />
                        <asp:HiddenField ID="fld_siteId" runat="server" Value='<%# Eval("SiteId") %>' />
                        
                        <h1 runat="server" id="lblTime"></h1>
                        <span>
                            <%# Eval("SiteTitle") %>
                        </span>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <script>
        $(document).ready(function () {

            var $container = $('.highlight-box');
            // init
            $container.isotope({
                // options
                itemSelector: '.hightItem',
                layoutMode: 'fitRows'
            });


            $("#lbl-sort-1").click(function (e) {
                $container.isotope({
                    filter: function () {
                        var name = $(this).attr("data-type");
                        return name.match(/1/);
                    }
                })
                e.preventDefault();
            });


            $("#lbl-sort-2").click(function (e) {
                $container.isotope({
                    filter: function () {
                        var name = $(this).attr("data-type");
                        return name.match(/2/);
                    }
                })
                e.preventDefault();
            });

            $("#lbl-sort-0").click(function (e) {
                $container.isotope({ filter: '*' })
                e.preventDefault();
            });

            if ($('.carousel').length > 0) {
                $('.carousel').tinycarousel();
            }
            $(".fancybox").fancybox();
        });
    </script>
</asp:Content>
