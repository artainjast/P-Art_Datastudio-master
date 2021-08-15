<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="BreakNews.aspx.cs" Inherits="PArt.Pages.P_Art.Pages.BreakNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="Pages/P-Art/Styles/style.css" />
    <link type="text/css" rel="stylesheet" href="Pages/P-Art/Styles/jquery.fancybox.css" />
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.isotope.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.fancybox.js") %>' type="text/javascript"></script>
    <script src="http://www.dynamicdrive.com/dynamicindex4/ddpowerzoomer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="noData" runat="server">
        متاسفانه هیچ اطلاعاتی در این بخش وجود ندارد با مدیر سیستم هماهنگ نمایید
    </div>

    <div style="float: right; margin: 0 auto; margin-top: 30px; width: 619px">

        <div style="padding-bottom: 10px;overflow: auto;border-bottom: 1px dotted rgb(201, 201, 201);">
         <span style="float:right">سال مورد نظر : </span>
                <div class="styled-select" style="margin-top:0">
                    <asp:DropDownList ID="drp_BreakDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_BreakDate_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
               
        </div>
        <div id="container" class="photos clearfix" style="width: 617px">

            <asp:Repeater ID="lst_image" runat="server">

                <ItemTemplate>
                    <div class="photo">

                        <a href='<%#  Eval("LargePath") %>' runat="server"
                            target="_blank">
                            <asp:Image runat="server" ImageUrl='<%#  GetNewsPicture(Eval("SmallPath") as string) %>' />
                            <span class="lblBreakSource"><%#Eval("Title") %></span>
                        </a>




                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>
    </div>
    <script>
        $(function () {

            //$('.fancybox-image').addpowerzoom()

            var $container = $('#container');
            $container.isotope({
                itemSelector: '.photo'

            });

            //$container.isotope({
            //    itemSelector: '.photo'
            //});


            $('#toggle-sizes').find('a').click(function () {
                $container
                  .toggleClass('variable-sizes')
                  .isotope('reLayout');
                return false;
            });

            $('img').load(function () {
                loadImages();
            });

            function loadImages() {

                $container
                      .toggleClass('variable-sizes')
                      .isotope('reLayout');
                return false;
            }

        });
    </script>
</asp:Content>
