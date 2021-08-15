<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Radio.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Radio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jwplayer.js") %>' type="text/javascript"></script>
    <style type="text/css">
         #movie-list{
     width:710px;
 }
  #movie-list article{
      margin-right:30px;
  }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <section id="sectionMovie">

        <div id="noData" runat="server">
            متاسفانه هیچ اطلاعاتی در این بخش وجود ندارد با مدیر سیستم هماهنگ نمایید
        </div>
        <div id="videoPlayer">
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
                        <td>تاریخ  :
                        </td>
                        <td>
                            <span id="info-date"></span>
                        </td>
                    </tr>
                    <tr>

                        <td>منبع :
                        </td>
                        <td>
                            <span id="info-source"></span>
                        </td>

                    </tr>
                </table>
                <%--<a href="#" class="ButtonRed">دریافت فایل
                </a>--%>
            </div>


        </div>
        <section id="movie-list">

            <asp:Repeater ID="lst_movies" runat="server">
                <ItemTemplate>
                    <article>
                        <a class="PlaySound" href="<%# Eval("SourcePath") %>" target="_blank" title="<%# Eval("SoundId") %>">

                            <figure>


                                <img runat="server" src="~/Pages/P-Art/Images/bgPlaying.png" alt="" />
                                <figcaption>

                                    <%# GetTitle(Eval("Title").ToString()) %>
                                </figcaption>
                            </figure>

                        </a>
                        <span class="lblRadioSource">


                            <%#Eval("Source") %>
                        </span>

                        <span class="lblVideoTime">
                            <%#Eval("DDate") %>

                            <%#Eval("SourceLength") %>
                        </span>
                        <%--<a href="<%# Eval("SourcePath") %>" class="lblDownloadVideo">دریافت</a>--%>
                    </article>
                </ItemTemplate>
            </asp:Repeater>


        </section>
        <div class="paging">
            <a href="#" runat="server" id="btn_PageNext">فایل های قدیمی تر
                    <img id="Img1" src="~/Pages/P-Art/Images/left-icon.png" runat="server" />
            </a>
            <a href="#" runat="server" id="btn_PageBack">
                <img id="Img2" src="~/Pages/P-Art/Images/right-icon.png" runat="server" />
                فایل های جدید تر
                    
            </a>
        </div>
    </section>
</asp:Content>
