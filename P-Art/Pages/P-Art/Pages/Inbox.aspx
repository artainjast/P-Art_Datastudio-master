<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.Inbox" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">

    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/calendar.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/Calender/jquery.ui.datepicker-cc-fa.js")%>'
        type="text/javascript"></script>

    <link href="/Pages/P-Art/Scripts/jquery.qtip.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <asp:HiddenField runat="server" ID="PageIndexHiddenField" />

    <div class="PageSubLink">
        <ul>
            <li><a href="/News/BultanArchive" target="_blank" runat="server"><span><i class="fas fa-archive"></i></span>آرشیو بولتن</a></li>
            <li><a href="#" id="lnk_bultan" class="flat-gray-button"><span><i class="fas fa-file-alt"></i></span>بولتن</a></li>
        </ul>
    </div>
    <div class="newsFilter persian">
        <div>
            <span>
                <label for="PageSizeDropDownList">تعداد در صفحه  </label>

                <asp:DropDownList runat="server" ID="PageSizeDropDownList" CssClass="btn btn-outline-info cur-p" Style="margin-left: 20px; height: 35px">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" Selected="True" />
                    <asp:ListItem Text="50" Value="50" />
                    <asp:ListItem Text="100" Value="100" />
                </asp:DropDownList>

            </span>
            <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
        </div>
    </div>
    <div class="newsBultan persian">
        <div>
            <asp:CheckBox ID="check_news" runat="server" Visible="false" CssClass="CheckBox" Text="اخبار" />
            <asp:CheckBox ID="check_NewsPaper" runat="server" Visible="false" CssClass="CheckBox" Text="روزنامه" />
            <asp:CheckBox ID="check_highlight" runat="server" CssClass="CheckBox" Text="هایلایت کلید واژه ها" />
            <asp:CheckBox ID="check_related" runat="server" CssClass="CheckBox" Text="شناسایی اخبار مرتبط" />
            <asp:CheckBox ID="check_rujeld" Checked="true" CssClass="CheckBox" runat="server" Text="رو جلد" />
            <asp:CheckBox ID="check_ChartKhabar" runat="server" Visible="false" CssClass="CheckBox" Text="نمودار" />
            <asp:CheckBox ID="check_Arz" runat="server" Visible="false" CssClass="CheckBox" Text="سکه و ارز" />
            <asp:CheckBox ID="check_GalleryNewspaper" Visible="false" CssClass="CheckBox" runat="server" Text="گالری روزنامه " />
            <asp:CheckBox ID="check_Sima" runat="server" Visible="false" CssClass="CheckBox" Text="صدا و سیما" />
            <asp:CheckBox ID="check_addGroup" runat="server" Visible="false" CssClass="CheckBox" Text="تفکیک" />
            <asp:CheckBox ID="check_addArchive" runat="server" CssClass="CheckBox" Text="اضافه کردن به آرشیو بولتن" />
            <asp:CheckBox ID="check_telegram" runat="server" Visible="false" CssClass="CheckBox" Text="تلگرام" />
            <asp:CheckBox ID="check_twitter" runat="server" Visible="false" CssClass="CheckBox" Text="توییتر" />
            <asp:CheckBox ID="check_instagram" runat="server" Visible="false" CssClass="CheckBox" Text="اینستاگرام" />
            <asp:CheckBox ID="check_newmedia" runat="server" Visible="false" CssClass="CheckBox" Text="سایر اخبار موضوعی" />
        </div>
        <br />
        <div>
            <span>عنوان بولتن</span>
            <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" placeholder="فاقد عنوان" />
            <span>قالب چاپی</span>
            <asp:DropDownList ID="drp_template" runat="server" CssClass="btn btn-outline-info cur-p dropdown dropdown-toggle" Width="200px" />
            <span><a id="btn_generateGroupHtml" runat="server" onclick="GetPagingHTMLBultan(this)" class="btn btn-success cur-p" style="width: 130px;">ساخت بولتن</a></span>
            <span>
                <asp:LinkButton ID="ClearAllButton" runat="server" class="btn btn-outline-secondary cur-p marginRight-10" OnClick="ClearAllButton_Click" OnClientClick="return confirm('آیا از حذف همه اینباکس مطمئن هستید؟ ؟')">حذف همه</asp:LinkButton></span>
        </div>

        <div style="display: none" class="loader">
            <img src="/Pages/P-Art/Images/ajax-loader.gif" />
        </div>
    </div>

    <div class="PagingContainer persian inboxpage">
        <div id="topPagination" runat="server" class="PagingPagination persian"></div>

        <div id="pagingGrid" runat="server" class="pagingGrid ">
            <asp:Repeater ID="pagingGridRepeater" runat="server">
                <HeaderTemplate>
                    <div class="filter-box-select">
                        <label for="cbSelectAll" class="all-select"><input id="cbSelectAll" type="checkbox" class="chSeleceAll" /> انتخاب همه</label>
                        <a onclick="deleteSelectedInbox(this)" class="deleteAll"  ><i class="fa fa-close">x</i><span>حذف </span></a>
                    </div> 
                    
                    <div id="sortable" class="pagingGridContainer">
                        <div class="pagingGridHeader">
                            <span class="HeaderSelection"><input id="cbSelectAll" type="checkbox" class="chSeleceAll" /> انتخاب همه</span>
                            <span class="HeaderTitle">عنوان</span>
                            <span class="HeaderSite">رسانه</span>
                            <span class="HeaderGroup">نوع رسانه</span>
                            <span class="HeaderDateTime">زمان</span>
                            <span class="HeaderCommand">دستورات</span>
                        </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="GridContainer" data-index="<%#Eval("Priority") %>" data-type='<%# Eval("MediaType") %>' data-media="<%#Eval("MediaId") %>">
                        <div class="GridItem">
                            <span class="ItemSelection">
                                <input id="NewsSelectCheckbox" value="<%#Eval("MediaId") %>-<%# Eval("MediaType") %>" type="checkbox" class="CheckBox" data-media='<%# Eval("MediaType") %>' data-id="<%#Eval("MediaId") %>"/>
                            </span>

                            <span class="ItemTitle" title='<%# Eval("MediaTitle") %>' data-id='<%# Eval("MediaId") %>'>
                              <%#PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("MediaTitle").ToString(),100) %>  
                            </span>

                            <span class="ItemSite" title='<%# Eval("MediaSource") %>'>
                                <%# Eval("MediaSource").ToString().Trim() %>
                            </span>
                            <span class="ItemGroup" title='<%# Eval("MediaType") %>'>
                                <%#  PArt.Pages.P_Art.Repository.Class_Static.GetMediaType(Eval("MediaType")) %>   
                            </span>
                            <span class="ItemDateTime" title='<%# Eval("Date") %> -  <%# Eval("Time") %>'><i class="fas fa-calendar-alt"></i><%#  PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToDateString(Eval("DateTimeIndex")) %>   <i class="fas fa-clock"></i><%#  PArt.Pages.P_Art.Repository.Class_Static.ConvertIndexDateTimeToTimeString(Eval("DateTimeIndex")) %></span>
                            <span class="ItemCommand">
                                <a data-id='<%# Eval("MediaId") %>' data-media='<%# Eval("MediaType") %>' style="display:none;" class="btn btn-sm btn-danger alertbtn" onclick="deleteInbox(this)"><i class="fa fa-times"></i></a>
                            </span>
                        </div>
                        <div id="GridItemDetail_<%# Eval("MediaId") %>" class="Detail">
                            <div class="DetailHeader">
                                <p>
                                    <span class="MatnKhabar">متن خبر:</span>
                                    <span class="ShowNewsLink">
                                        <a href="/ShowNews/<%#Eval("MediaId") %>" target="_blank">نمایش</a>
                                    </span>
                                    <span class="NewsUrl">
                                        <a href="<%#Eval("MediaUrl") %>" target="_blank" class="<%# Eval("UrlDisplayControl") %>">شاهد خبر</a>
                                    </span>
                                </p>

                            </div>
                            <div class="DetailContent"></div>
                        </div>
                    </div>
                </ItemTemplate>

                <FooterTemplate>
                    <div class="GridFooter">
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>


        <div id="buttomPagination" runat="server" class="PagingPagination persian">
        </div>
    </div>
    <script>
        $(function () {
            $("#sortable").sortable({
                update: function (event, ui) {
                    $('.GridContainer').each(function (i) {
                        $(this).data('index', i + 1);
                    }).filter(':first').trigger('listData');
                }
            });
            $('.GridContainer').on('listData', function () {
                var items = '';
                $('.GridContainer').each(function () {
                    items += $(this).data('media') + '-' + $(this).data('index') + '-' + $(this).data('type') + ',';
                    console.log(items);
                });


                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/Inbox.aspx/UpdatePriority",
                    data: "{'input':'" + items + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == 1) {
                        }
                    },
                    error: function (msg) {
                        alert('خطا');
                    }
                });

            });
            $("#sortable").disableSelection();
        });
    </script>
    <style>
        #sortable {
            list-style-type: none;
        }

            #sortable li {
                margin: 0 3px 3px 3px;
                padding: 0.4em;
                padding-left: 1.5em;
                font-size: 1.4em;
                height: 18px;
            }

                #sortable li span {
                    position: absolute;
                    margin-left: -1.3em;
                }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            Page_Init();

            $(":checkbox[id=cbSelectAll]").click(function () {
                if ($(this).is(":checked")) {
                    $(":checkbox[id=NewsSelectCheckbox]").attr("checked", "checked");
                } else {
                    $(":checkbox[id=NewsSelectCheckbox]").removeAttr("checked");
                }
            });
        });

        function Page_Init() {
        }

        function deleteInbox(element) {
            var MediaId = $(element).attr('data-id');
            var Mediatype = $(element).attr('data-media');
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/Inbox.aspx/DeleteInbox",
                data: "{'MediaId':'" + MediaId + "' , 'MediaType': " + Mediatype + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                        var linkUrl = window.location.protocol + "//" + window.location.hostname;
                        if (window.location.port != null && window.location.port != '') {
                            linkUrl += ":" + window.location.port;
                        }
                        linkUrl = linkUrl + "/Inbox";
                        window.location.href = linkUrl;
                    }
                },
                error: function (msg) {
                    alert('خطا');
                }
            });
        }

        function deleteSelectedInbox(element) {

            var sList = "";
            $(":checkbox[id=NewsSelectCheckbox]").each(function () {
                if (this.checked) {
                    console.log($(this).val());
                    var value = $(this).val();
                    sList += (sList == "" ? value : "_" + value);
                }
            });
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/Inbox.aspx/DeleteAllInbox",
                data: "{'codes':'" + sList + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                        var linkUrl = window.location.protocol + "//" + window.location.hostname;
                        if (window.location.port != null && window.location.port != '') {
                            linkUrl += ":" + window.location.port;
                        }
                        linkUrl = linkUrl + "/Inbox";
                        window.location.href = linkUrl;
                    }
                },
                error: function (msg) {
                    alert('خطا');
                }
            });
        }
    </script>

    <script>
        $("#lnk_filter").click(function (e) {

            $(".newsFilter").fadeToggle("slow", "linear");
            e.preventDefault();
        });
    </script>

    <script>
        $("#lnk_bultan").click(function (e) {

            $(".newsBultan").fadeToggle("slow", "linear");
            e.preventDefault();
        });
    </script>

    <script>

        function GetPagingHTMLBultan(element) {
            var $this = $(element);

            var checkNewsPaper = $('#check_NewsPaper').attr('checked') ? 'true' : 'false';
            var CheckChart = 'true';
            var checkAllowArchive = $('#check_addArchive').attr('checked') ? 'true' : 'false';
            var checkAllowHighlight = 'false';
            var checkAllowRelated = 'false';
            var bultanTitle = $("#txt_bultanTitle").val();
            var bultanTemplate = $("#drp_template").val();
            var checkAllowGroup = 'true';
            var checkAllowArz = $('#check_Arz').attr('checked') ? 'true' : 'false';
            var checkAllowSima = $('#check_Sima').attr('checked') ? 'true' : 'false';
            var checkAllowGalleryNewspaper = $('#check_GalleryNewspaper').attr('checked') ? 'true' : 'false';
            var checkRujeld = $('#check_rujeld').attr('checked') ? 'true' : 'false';

            var linkUrl = window.location.protocol + "//" + window.location.hostname;
            if (window.location.port != null && window.location.port != '') {
                linkUrl += ":" + window.location.port;
            }
            linkUrl = linkUrl + "/BultanPayeshMedia.aspx?ArchiveId=";
            //generate bultan archive
            $.ajax({
                type: "POST",
                url: "/pages/p-art/pages/Inbox.aspx/SetBultanArchiveMedia",
                data: "{'bultanTitle': '" + bultanTitle + "','allowNewspaper':'" + checkNewsPaper + "','galleryNewspaper':'" +
                    checkAllowGalleryNewspaper + "','arz':'" + checkAllowArz + "','sima':'" + checkAllowSima + "','highLight':'" +
                    checkAllowHighlight + "','allowGroup':'" + checkAllowGroup + "','related':'" + checkAllowRelated + "','selectedBultan':'" +
                    bultanTemplate + "','isArchive':'true','chart':'" + CheckChart + "','jeld':'" + checkRujeld + "','BultanType':'2','linkUrl':'" + linkUrl + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d == null || msg.d == '') return;
                    if (msg.d == 0) {
                        OpenAlert('خطا', 'خطا در ساخت گزارش');
                        return;
                    }
                    var finalLink = linkUrl + msg.d;
                    window.location.href = finalLink;
                }
            });
        }

    </script>

</asp:Content>
