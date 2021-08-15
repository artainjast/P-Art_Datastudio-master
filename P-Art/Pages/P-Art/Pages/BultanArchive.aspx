﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="BultanArchive.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.BultanArchive" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">

    <div class="PageSubLink">
        <ul>
            <li><a href="/News/Latest/" runat="server"><span><i class="far fa-window-restore"></i></span>تازه ها</a></li>
            <li><a href="/Analysis" runat="server"><span><i class="fas fa-chart-line"></i></span>تحلیل محتوا</a></li>
            <li><a href="/keywords" runat="server"><span><i class="fas fa-key"></i></span>کلید واژه</a></li>
            <li><a href="/KeywordAnalyse" runat="server"><span><i class="fab fa-keycdn"></i></span>آنالیز کلید واژه ها</a></li>
            <li style="color: #fec006"><a style="color: #fec006"  runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="/addnews" runat="server"><span><i class="fas fa-pen-square"></i></span>ثبت خبر</a></li>
            <li><a href="/Pages/P-Art/Pages/SavedNews.aspx" runat="server"><span><i class="fas fa-hdd"></i></span>اخبار ذخیره شده</a></li>
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
                            <asp:LinkButton ID="btn_remove" runat="server" CommandArgument='<%#Eval("ArchiveId") %>' OnClick="btn_remove_Click" OnClientClick="return confirm('آیا از حذف بولتن انتخابی اطمینان دارید')">
                                <img src="/Pages/P-Art/Images/dialog_cancel.png" />
                            </asp:LinkButton>

                            <span class="ControlLeftMargin"><%# FormatDate(Eval("NewsDateIndex")) %></span>
                            <span class="ControlLeftMargin">
                                <label>
                                    <%# GetBultanFileType(Eval("Path")+"") %>
                                </label>
                            </span>
                            <a class="ControlLeftMargin btn btn-success" id="lnk_download" href='<%# GetBultanFilePath(Eval("Path")+"") %>' runat="server">دریافت فایل
                            </a>

                            <%--<a href='<%# string.Format("/NewsList/?bultanarchive={0}",Eval("ArchiveId")) %>' runat="server" target="_blank">نمایش اخبار--%>
                            <a href='<%# string.Format("/Pages/P-Art/Pages/BultanNews.aspx?bultanarchive={0}",Eval("ArchiveId")) %>' runat="server" target="_blank">نمایش اخبار
                            </a>
                            <span>
                                <%#Eval("Name") %>
                            </span></div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
