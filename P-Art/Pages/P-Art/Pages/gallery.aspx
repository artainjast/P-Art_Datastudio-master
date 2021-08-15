<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="gallery.aspx.cs" Inherits="PArt.Pages.P_Art.Pages.gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section id="gallery">

        <div id="noData" runat="server">
            متاسفانه هیچ اطلاعاتی در این بخش وجود ندارد با مدیر سیستم هماهنگ نمایید
        </div>

        <asp:Repeater ID="lst_Gallery" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' runat="server"
                        target="_blank">
                        <asp:Image runat="server" ID="img" ImageUrl='<%# String.Format("{0}", Eval("SmallPath")) %>' />
                    </a>

                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </section>
</asp:Content>
