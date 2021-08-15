<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/PanelMasterPage.Master" AutoEventWireup="true" CodeBehind="DataCenterNewsArchive.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.DataCenterNewsArchive" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="PanelContent" ContentPlaceHolderID="PanelContentPlaceHolder" runat="server">
    <div class="PageSubLink">
        <ul>
            <li style="color: #fec006"><a style="color: #fec006" id="DataCenterArchiveNewsButton" runat="server"><span><i class="far fa-list-alt"></i></span>اخبار ذخیره شده</a></li>
            <li><a href="#" id="lnk_filter" class="flat-gray-button"><span><i class="fas fa-filter fa-sm"></i></span>فیلتر کردن</a></li>
            <li><a href="#" id="NewsPackageButton"><span><i class="fas fa-file-alt"></i></span>ایجاد بسته خبری</a></li>
        </ul>
    </div>

    <div class="control-box filter newsFilter persian">
            <div>
                <span>
                    <span>از تاریخ</span>
                    <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" style="width: 68px;"/>
                </span>
                <span>
                    <span>از ساعت</span>
                    <asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" placeholder="  :  " Style="width: 25px; text-align:center" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="00:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_fromHour"
                        ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                    </asp:RegularExpressionValidator>
                </span>
                <span>
                    <span>تا تاریخ</span>
                    <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" style="width: 68px;" />
                </span>
                <span>
                    <span>تا ساعت</span>
                    <asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" placeholder="  :  "  Style="width: 25px; text-align:center" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ErrorMessage="23:00" ForeColor="Red" Display="Dynamic" ControlToValidate="txt_toHour"
                        ValidationExpression="^(([0-1][0-9])|([2][0-3])):([0-5][0-9])$">
                    </asp:RegularExpressionValidator>
                </span>

            </div>
            <br />
            <div>
                <span>
                    <span>کلید واژه</span>
                    <asp:TextBox ID="txt_search" runat="server" CssClass="textbox" />
                </span>
                <span>
                    <span>منبع خبری</span>
                    <asp:DropDownList ID="drp_NewsSource" Width="95px" runat="server" CssClass="btn btn-outline-info cur-p" Style="min-width: 200px" />
                </span>
                <span>
                    <span>ترتیب نمایش</span>
                    <asp:DropDownList ID="drp_sort" runat="server" CssClass="btn btn-outline-info cur-p" Style="min-width: 200px">
                        <asp:ListItem Text="اولویت کلید واژه ها" Value="0" />
                        <asp:ListItem Text="ساعت خبر" Value="1" />
                    </asp:DropDownList>
                </span>
            </div>
            <br />
            <div>

                <a href="/News/Latest/?time=30" class="btn btn-outline-secondary cur-p">30 دقیقه پیش
                </a>
                <a href="/News/Latest/?time=60" class="btn btn-outline-secondary cur-p">1 ساعت پیش
                </a>
                <a href="/News/Latest/?time=180" class="btn btn-outline-secondary cur-p">3 ساعت پیش
                </a>
                <a href="/News/Latest/?time=360" class="btn btn-outline-secondary cur-p">6 ساعت پیش
                </a>
                <a href="/News/Latest/?time=720" class="btn btn-outline-secondary cur-p">12 ساعت پیش
                </a>
                <a id="lnk_yesterday" runat="server" href="/News/Latest/?time=1440" class="btn btn-outline-secondary cur-p">1 روز پیش
                </a>
                <span>
                    <asp:Button ID="btn_ShowNews" runat="server" CssClass="btn btn-info cur-p" Text="نمایش اخبار" />
                    <asp:Button ID="btnGetNewsDB" runat="server" CssClass="btn btn-danger cur-p" Text="خروجیDB"  />
                </span>
            </div>
        </div>
    <div class="newsBultan">

        <span>عنوان بولتن</span>
        <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" Text="فاقد عنوان" />
        <a id="HTMLDataCenterPackButton" runat="server"  class="btn btn-info cur-p">ساخت بسته خبری</a>
        <asp:HiddenField ID="NewsIdParminId" runat="server" Value='' />

    </div>

    <div class="DataCenterArchive persian">
        <asp:Repeater ID="dataCenterNewsArchiveRepeater" runat="server">
            <HeaderTemplate>
                <div class="newsStream">
                    <div class="newsStreamHeader">
                        <span>اخبار ذخیره شده در دیتا سنتر</span>
                    </div>
            </HeaderTemplate>

            <ItemTemplate>
                <div class="showFehrest">
                    <article>
                        <asp:HiddenField ID="NewsIdHiddenField" runat="server" Value='<%# Eval("NewsId") %>' />
                        <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>
                        <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="CheckBox" />
                        <a class="title" href='/DataCenterSavedNews/<%# Eval("NewsID") %>'><span><%# Eval("NewsTitle") %></span></a>
                        <span class="rowDateTime ">
                            <label id="date"><%# DiffrentDate(Eval("CreateDate"),"1",Eval("NewsTime").ToString(),Eval("NewsDate").ToString()) %></label>
                        </span>
                        <a class="deleteButton red" title="حذف خبر"><span><i class="fas fa-trash-alt"></i></span></a>
                    </article>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <script>

        $('.deleteButton').click(function (e) {

            const loader = document.getElementById('loader');
            setTimeout(() => {
                loader.classList.remove('fadeOut');
            }, 300);
            var newsID = $(this).closest('article').find('#NewsIdHiddenField').val();
            var result = confirm("برای حذف خبر مطمئن هستید؟");

            if (result) {
                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/DataCenterSavedNews.aspx/DeleteDataCenterNews",
                    data: "{'newsId':'" + newsID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                        alert('خبر با موفقیت حذف گردید.');
                        window.location.replace("/Pages/P-Art/Pages/DataCenterNewsArchive.aspx");
                    },
                    error: function (msg) {
                        setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                        alert('حطا در حذف خبر');
                    }
                });
            }
            e.preventDefault();
        });

        $('#NewsPackageButton').click(function () {
            $('.newsBultan').fadeToggle(1000);
        });

        $("#HTMLDataCenterPackButton").click(function () {
            var parmin = $('#NewsIdParminId').val();
            
            var NewsIdString = "";
            $('.newsStream #check_SelectNews').each(function () {
                if (this.checked) {
                    NewsIdString += "," + $(this).closest('article').find('#NewsIdHiddenField').val();
                }
            });
            var fromDate = "" + $('#txt_fromDate').val();
            var toDate = "" + $('#txt_toDate').val();
            var fromTime = "" + $('#txt_fromHour').val();
            var toTime = "" + $('#txt_toHour').val();
            var bultanTitle = "" + $('#txt_bultanTitle').val();
           
            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/DataCenterNewsArchive.aspx/SaveDataCenterPackArchive",
                data: "{'fromDate': '" + fromDate + "','toDate': '" + toDate + "','parmin': '" + parmin + "','bultanTitle': '" + bultanTitle + "','SelectedNews': '" + NewsIdString + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                    window.location.replace("/HTMLDataCenterPack.aspx?ArchiveId=" + data.d +"");
                },
                error: function (msg) {
                    setTimeout(() => { loader.classList.add('fadeOut'); }, 300);
                    alert("خطا در ثبت اطلاعات");
                }

            }
            );
            e.preventDefault();

        });


    </script>
</asp:Content>
