<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="MediaShahed.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.MediaShahed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='<%= ResolveUrl("~/Pages/P-Art/Styles/AnalyzeStyle.css")%>' rel="stylesheet" />

    <style>
        .PanelContentArea {
            direction:ltr;
        }

        /* [DOES NOT MATTER] */
        html, body {
            font-family: IRANSans, sans-serif;
        }
    </style>

    <script>
        $(window).load(function () {
            getNewsShahed($("#hddNewsId").val());
        });
    </script>
    <script>
        function getNewsShahed(id) {
            $("#divNewsShahed").css("display", "none");
            $("#imgLoadPage1").css("display", "block");
            var newsItems;
            var rightClass = "";
            $.ajax({
                type: "POST",
                url: "/Services/Part_MediaAnalyze_GetMediaShahed.ashx?id=" + id + "&t=1",
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    newsItems = "<div class='avtl'>";
                    for (var i = 0; i < data.NewsList.length; i++) {
                        if (i % 2 == 1)
                            rightClass = " shahedRight";
                        else
                            rightClass = "";
                        newsItems += "<div class='ewrap" + rightClass + "'>" +
                                        "<div class='event'>" +
                                            "<strong class='shahedSiteName'>" + data.NewsList[i].SiteTitle + "</strong><br />" +
                                            "<strong class='shahedDate'>" + data.NewsList[i].NewsDate + " | " + data.NewsList[i].NewsTime + "</strong>" +
                                            "<p class='shahedText'>" + data.NewsList[i].NewsTitle + "</p>" +
                                         "</div>" +
                                     "</div>";
                    }
                    newsItems += "</div>";
                    $("#divNewsShahed").html(newsItems);

                }
            });

            $("#divNewsShahed").css("display", "block");
            $("#imgLoadPage3").css("display", "none");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <div style="display: none;">
        <asp:HiddenField ID="hddNewsId" runat="server" />
        <asp:HiddenField ID="hddType" runat="server" />
    </div>
    <div class="shahed-main">
        <%--<img id="imgLoadPage1" style="text-align: center; margin: auto;" src="/Pages/P-Art/Images/analyze/loader_backinout.gif" />--%>
        <div id="divNewsShahed"></div>
    </div>
</asp:Content>
