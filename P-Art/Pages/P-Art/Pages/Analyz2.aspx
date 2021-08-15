<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Analyz2.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Analyz2" %>

<%@ Register Assembly="Highchart" Namespace="Highchart.UI" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #list-news
        {
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section id="list-news">
        <section class="filter-box" style="margin-top: 10px">

            <div class="bar" style="padding-top: 8px">
                <div class="styled-select" style="margin-top: 0">
                    <asp:DropDownList ID="drp_newsSource" runat="server">
                        <asp:ListItem Text="کلی" Value="0" Selected="True" />
                        <asp:ListItem Text="جراید" Value="1" />
                        <asp:ListItem Text="خبرگزاری ها" Value="2" />
                    </asp:DropDownList>
                </div>
                <span>از تاریخ :
                </span>
                <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="width: 88px"
                    Text="1391/09/05" />
                <span>تا تاریخ :
                </span>
                <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" Style="width: 88px"
                    Text="1391/09/05" />

                <asp:Button ID="Btn_Show" runat="server" Text="نمایش گزارش"
                    CssClass="BlueButton" OnClick="Btn_Show_Click"  />
                <div class="bar">
                    <input type="text" name="tag[]" value="" class="tag" id="txt_tags" runat="server" />
                </div>
            </div>

        </section>


        <div id="report-result">

            <div id="chart1-result">
                <cc1:ColumnChart ID="chart_bar_khabargozari" runat="server" RenderType="column" Width="910" Height="400" />
                
            </div>
            <div id="chart2-result">
                <cc1:ColumnChart ID="chart_bar_jarayed" runat="server" RenderType="column" Width="910" Height="400" />

            </div>
            <div id="chart3_result" runat="server">
                <%--<cc1:PieChart ID="chart_pie_compare1" runat="server" RenderType="pie" />--%>
                
            </div>
        </div>
    </section>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".tag").tagedit();
        });

    </script>
</asp:Content>
