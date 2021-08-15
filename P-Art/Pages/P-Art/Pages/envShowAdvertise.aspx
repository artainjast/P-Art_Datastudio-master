<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="envShowAdvertise.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.envShowAdvertise" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <div class="container-showAdvertiseTable persian">
        <div class="wrap-showAdvertiseTable">
            <div class="table">
                <div class="row">
                    <div class="cell">
                        برند
                    </div>
                    <div class="cell" runat="server" id="brandTitile">
                        -
                    </div>

                </div>
                <div class="row">
                    <div class="cell">
                        کمپین
                    </div>

                    <div class="cell" runat="server" id="campainTitle">
                        -
                    </div>

                </div>
                <div class="row">
                    <div class="cell">
                        نوع آدرس
                    </div>
                    <div class="cell" runat="server" id="addressTypeTitle">
                        -
                    </div>
                </div>
                <div class="row">
                    <div class="cell">
                        آدرس
                    </div>

                    <div class="cell" runat="server" id="addressTitle">
                        -
                    </div>

                </div>
                <div class="row">
                    <div class="cell">
                        نوع سازه
                    </div>
                    <div class="cell" runat="server" id="structureTypeTitle">
                        -
                    </div>

                </div>
                <div class="row">
                    <div class="cell">
                        مساحت
                    </div>
                    <div class="cell" runat="server" id="structureArea">
                        -
                    </div>

                </div>

                <div class="row">
                    <div class="cell">
                        تاریخ اکران
                    </div>

                    <div class="cell" runat="server" id="dateTime">
                        -
                    </div>

                </div>

            </div>
        </div>
    </div>

    <div id="imagesGalleryContainer" runat="server" class="imagesGalleryContainer persian ">


        <asp:Repeater ID="imagesGalleryRepeater" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="advertiseImageCard">
                    <div class="AdvertiseImageContainer">
                        <img class="AdvertiseImage" src="<%#  Eval("ImageName").ToString() %>" onerror="this.src='/Pages/P-Art/Images/newsPreview.jpg'" alt="" />
                    </div>

                    <div class="container">
                        <h5 class="DateTime persian"><b><%# Eval("FarsiDateString").ToString() %></b></h5>
                        <a class="showPost" href="<%# Eval("ImageName").ToString() %>" target="_blank">نمایش عکس</a>
                    </div>
                </div>
            </ItemTemplate>

            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

