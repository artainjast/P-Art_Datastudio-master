<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="SiteSettings.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SiteSettings" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div runat="server" visible="false" class="PageSubLink">
        <asp:Button ID="btn_save" runat="server" OnClick="btn_save_Click" CssClass="btn btn-success cur-p" Text="ذخیره اطلاعات" />
    </div>
    <div class="group_site sitesetting">

        <div id="Khabargozari" class="tabcontent">
            <asp:Literal ID="lblKhabargozari" runat="server"></asp:Literal>
        </div>

        <div id="Rooznameh" class="tabcontent">
            <asp:Literal ID="lblRooznameh" runat="server"></asp:Literal>
        </div>

        <div id="PaygahKhabari" class="tabcontent">
            <asp:Literal ID="lblPayegah" runat="server"></asp:Literal>
        </div>

        <div id="Telegram" class="tabcontent">
            <asp:Literal ID="lblTelegram" runat="server"></asp:Literal>
        </div>
        <div>
            <a class="tablink" onclick="openTab('Khabargozari', this, 'orangered')" id="defaultOpen">خبرگزاری</a>
            <a class="tablink" onclick="openTab('Rooznameh', this, 'limegreen')">روزنامه</a>
            <a class="tablink" onclick="openTab('PaygahKhabari', this, 'orange')">پایگاه های خبری</a>
            <a class="tablink" onclick="openTab('Telegram', this, 'dodgerblue')">کانال های تلگرام</a>
        </div>



    </div>


    <asp:Repeater Visible="false" runat="server" ID="rptSiteGroup" OnItemDataBound="rptSiteGroup_ItemDataBound">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="group_item clearfix">
                <div class="groupNameDetails clearfix">
                    <span><%# Eval("SiteGroup") %></span>
                </div>
                <div>
                    <asp:Repeater runat="server" ID="rptSelectedSiteSort" OnItemDataBound="rptSelectedSiteSort_ItemDataBound">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="selectedSiteItem">
                                <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                                <asp:CheckBox ID="cbIsCheck" runat="server" />
                                <asp:HiddenField ID="hddSite" runat="server" Value='<%# Eval("SiteID") %>' />
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>

    <script>
        function openTab(siteGroupName, elmnt, color) {
            // Hide all elements with class="tabcontent" by default */
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }

            // Remove the background color of all tablinks/buttons
            tablinks = document.getElementsByClassName("tablink");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].style.backgroundColor = "";
            }

            // Show the specific tab content
            document.getElementById(siteGroupName).style.display = "block";

            // Add the specific color to the button used to open the tab content
            elmnt.style.backgroundColor = color;
        }

        // Get the element with id="defaultOpen" and click on it
        document.getElementById("defaultOpen").click();


        function updateSiteMember(s, t,p,m ,element) {
            var tagA = $(element);
            //var tagA = $(element).attr('data-newsid');
            var serviceURL = "/Services/Part_SiteMember_Update.ashx?s=" + s + "&t=" + t + "&p=" + p + "&m=" + m;
            $.ajax({
                type: "POST",
                url: serviceURL,
                data: param = "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: successFunc,
                error: errorFunc
            });

            function successFunc(data, status) {
                console.log(data);
                if (data === 0) {
                    if (t === 1) {
                        if (tagA.hasClass('selected'))
                            tagA.attr('class', 'link-site');
                        else
                            tagA.attr('class', 'link-site selected');
                    }
                    else {
                        if (tagA.hasClass('selected'))
                            tagA.attr('class', 'link-telegram');
                        else
                            tagA.attr('class', 'link-telegram selected');
                    }
                }
            }

            function errorFunc() {
                console.log(data);
            }
        }


    </script>
    <style>
        .group-header {
            text-align: right;
            height: 32px;
        }

        .title-link-site {
            background: #FFF;
            color: #000;
            padding: 5px;
            min-width: 23.5%;
            display: inline-block;
        }

        .group_site.sitesetting {
            height: 100%;
        }

        .tablink {
            background-color: #EEE;
            color: #333;
            float: right;
            border: none;
            outline: none;
            cursor: pointer;
            padding: 14px 16px;
            font-size: 11px;
            width: 21.24%;
            clear: none;
            text-align: center;
        }

            /* Change background color of buttons on hover */
            .tablink:hover {
                background-color: #777;
            }

        /* Set default styles for tab content */
        .tabcontent {
            color: white;
            display: none;
            padding: 10px;
            text-align: center;
            height: 60%;
            overflow-y: scroll;
        }

            .tabcontent a.selected {
                width: 11.8%;
                float: right;
                clear: none;
                border: 1px solid #FFF;
                margin: 0.2%;
                font-size: 10px;
                height: 30px;
                line-height: 30px;
                cursor: pointer;
                opacity: 1;
            }
            .tabcontent a.link-site.selected {
                opacity: 1;
            }
            .tabcontent a.link-site {
                width: 11.8%;
                float: right;
                clear: none;
                border: 1px solid #FFF;
                margin: 0.2%;
                font-size: 10px;
                height: 30px;
                line-height: 30px;
                cursor: pointer;
                opacity: 0.6;
            }
             .tabcontent a.link-telegram {
                width: 23.8%;
                float: right;
                clear: none;
                border: 1px solid #FFF;
                margin: 0.2%;
                font-size: 10px;
                height: 30px;
                line-height: 30px;
                cursor: pointer;
                opacity: 0.6;
            }
              .tabcontent a.link-telegram.selected {
                opacity: 1;
            }
        /* Style each tab content individually */
        #Khabargozari {
            background-color: orangered;
        }

        #Rooznameh {
            background-color: limegreen;
        }

        #PaygahKhabari {
            background-color: orange;
        }

        #Telegram {
            background-color: dodgerblue;
        }
    </style>
</asp:Content>
