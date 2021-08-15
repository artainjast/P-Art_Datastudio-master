<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="ShowImage.aspx.cs" Inherits="PArt.Pages.P_Art.Pages.ShowImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <section id="gallery">

        <div id="image_frame">

            <asp:Image ID="img_Plate" runat="server" CssClass="imagePlate" />

        </div>

        <section id="gallery-small">

            <asp:Repeater ID="lst_Gallery" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href='<%# String.Format("~/ShowImage/{0}", Eval("ImageId")) %>' runat="server"
                            target="_self">
                            <asp:Image runat="server" ID="img" ImageUrl='<%# String.Format("http://admin.cportalteam.com/resource/monitoring/images/{0}", Eval("SmallPath")) %>' />
                        </a>

                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

        </section>
    </section>


</asp:Content>
