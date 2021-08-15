<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="TwitterBultanArchive.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.TwitterBultanArchive" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <div class="PageSubLink">
        <ul>
            <li><a href="/Twitter/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/TwitterAnalyze/" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوای توییتر</a></li>
            <li><a href="/TwitterKeywords/" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه ها</a></li>
            <li><a style="color: #fec006" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
        </ul>
    </div>

    <section class="posts">
        <div class="filter-box">
            <span>از تاریخ</span>
            <span>
                <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" /></span>
            <span>تا تاریخ</span>
            <span>
                <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" /></span>
            <span>
                <asp:Button ID="btn_Show" runat="server" CssClass="btn btn-primary" Text="نمایش گزارش" OnClick="btn_Show_Click" /></span>
        </div>
        <div class="bultanarchive persian">
            <div class="BoxPanelHeader">
                <span><i class="fas fa-archive fa-lg"></i></span>
                آرشیو بولتن
            </div>
            <div class="BoxPanelContent">
                <asp:Repeater ID="rpt_result" runat="server">
                    <HeaderTemplate>
                        <div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="BultanArchiveItem">
                            <asp:LinkButton ID="btn_remove" CssClass="ControlLeftMargin" style="top:8px;position:relative;" runat="server" CommandArgument='<%#Eval("ArchiveId") %>' OnClick="deleteBultanArchive" OnClientClick="return confirm('آیا از حذف بولتن انتخابی اطمینان دارید')">
                                <img src="/Pages/P-Art/Images/dialog_cancel.png" />
                            </asp:LinkButton>

                            <span class="ControlLeftMargin">

                            </span>
                            <span class="ControlLeftMargin">
                                <label>
                                    <%# Eval("NewsDateIndex").ToString().Insert(4,"/").Insert(7,"/") %>
                                </label>
                            </span>
                            <a class="ControlLeftMargin btn btn-success" id="lnk_download" href='<%# string.Format("/HTMLTwitterReport.aspx?ArchiveId={0}",Eval("ArchiveId")) %>' runat="server" target="_blank">مشاهده بولتن
                            </a>


                            <span>
                                <%#Eval("Name") %>
                            </span>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

        </div>
    </section>
</asp:Content>
