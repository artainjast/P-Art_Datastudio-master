<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.welcome" %>

<%@ Register Src="~/UserControls/UC_ChartWelcome.ascx" TagPrefix="uc1" TagName="UC_ChartWelcome" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/highcharts.js") %>'></script>
     <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>' type="text/javascript"></script>
 
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
  
    <uc1:UC_ChartWelcome runat="server" ID="UC_ChartWelcome" />
    
    
    
    <div style="display: none;">
        <asp:HiddenField ID="hddFrom" runat="server" />
        <asp:HiddenField ID="hddTo" runat="server" />
    </div>

   
</asp:Content>
