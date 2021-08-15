<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/P-Art/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="NewsMaster.aspx.cs" Inherits="PArt.Pages.P_Art.Pages.NewsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" EnableViewState="False">
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.carouFredSel-6.1.0-packed.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.mousewheel.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.touchSwipe.min.js")%>'
        type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/P-Art/Scripts/jquery.ba-throttle-debounce.min.js")%>'
        type="text/javascript"></script>

    <script src="/Scripts/jquery.qtip.js"></script>
    <link href="/Scripts/jquery.qtip.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <style>
        .time {
            margin-left: 5px;
            float: right;
        }

            .time:first-child {
                margin-right: 10px;
            }

        .flat-gray-button {
            font-family: Tahoma;
            font-size: 11px;
            cursor: pointer;
        }

        .userSorting {
        }

            .userSorting h4 {
                width: 170px;
                float: right;
                font: bold 13px tahoma;
            }

            .userSorting ul {
                width: 480px;
                float: left;
            }

            .userSorting li {
                float: left;
                list-style: none;
                width: 80px;
                text-align: center;
                background: #317ADB;
                padding: 7px 4px;
                color: #fff;
                border-right: 1px solid #fff;
                border: 1px solid #fff;
            }

                .userSorting li.selected {
                    background: #2db40d;
                }

                .userSorting li a {
                    color: #fff;
                    font: normal 11px tahoma;
                }

                    .userSorting li a:hover {
                        color: #000;
                    }

                .userSorting li#sortByCustom {
                    position: relative;
                    padding-left: 20px;
                }

                    .userSorting li#sortByCustom i {
                        content: "";
                        width: 16px;
                        height: 16px;
                        background: url(/Pages/P-Art/Images/editTag2.png) no-repeat;
                        position: absolute;
                        top: 6px;
                        left: 3px;
                        line-height: 30px;
                        display: block;
                    }

        .shadowModal {
            display: none;
            position: fixed;
            background: #000;
            opacity: 0.6;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            z-index: 9998;
        }

        .modalSiteSort {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            background: #fff;
            width: 600px;
            height: 600px;
            margin-top: -300px;
            margin-left: -300px;
            border-radius: 6px;
            border: 1px solid #ccc;
            z-index: 9999;
        }

            .modalSiteSort .modalHeader {
                height: 30px;
            }

            .modalSiteSort .modalContainer {
                padding: 10px;
                height: 480px;
            }

                .modalSiteSort .modalContainer .containerSiteSort {
                    height: 480px;
                    width: 250px;
                    -webkit-overflow-scrolling: touch;
                    -moz-overflow-scrolling: touch;
                    -o-overflow-scrolling: touch;
                    overflow: auto;
                }

                .modalSiteSort .modalContainer .containerSortSeleted {
                    height: 480px;
                    border: 1px solid #eee;
                    width: 250px;
                    float: left;
                    margin-left: 10px;
                    -webkit-overflow-scrolling: touch;
                    -moz-overflow-scrolling: touch;
                    -o-overflow-scrolling: touch;
                    overflow: auto;
                }

                .modalSiteSort .modalContainer .selectedListItems {
                    min-height: 400px;
                }

                .modalSiteSort .modalContainer .containerSortSeleted h5 {
                    text-align: center;
                    margin: 0px;
                    border-bottom: 2px solid #ccc;
                    padding: 10px 0;
                    background: #eee;
                }

                .modalSiteSort .modalContainer .containerSortSeleted .selectedSiteItem {
                    padding: 5px;
                    margin-bottom: 5px;
                    border-bottom: 1px dashed #ccc;
                    position: relative;
                }

                    .modalSiteSort .modalContainer .containerSortSeleted .selectedSiteItem .remove {
                        width: 16px;
                        height: 16px;
                        display: block;
                        background: url('/Pages/P-Art/Images/del16.png') no-repeat;
                        position: absolute;
                        left: 2px;
                        bottom: 2px;
                        cursor: pointer;
                    }

                    .modalSiteSort .modalContainer .containerSortSeleted .selectedSiteItem span {
                    }

                    .modalSiteSort .modalContainer .containerSortSeleted .selectedSiteItem input[type=text] {
                    }

                .modalSiteSort .modalContainer .containerSiteSort div {
                    margin-bottom: 5px;
                    border-bottom: 1px solid #eee;
                    padding-bottom: 5px;
                }

                    .modalSiteSort .modalContainer .containerSiteSort div input {
                        font: normal 11px tahoma;
                    }

                    .modalSiteSort .modalContainer .containerSiteSort div span {
                    }

            .modalSiteSort .modalFooter {
                height: 70px;
                position: relative;
            }

                .modalSiteSort .modalFooter .regBtn {
                    position: absolute;
                    right: 20px;
                    display: block;
                    width: 100px;
                    height: 30px;
                    line-height: 30px;
                    background: #317ADB;
                    bottom: 15px;
                    text-align: center;
                    color: #fff;
                    border-radius: 4px;
                }

                .modalSiteSort .modalFooter .cancelBtn {
                    position: absolute;
                    display: block;
                    width: 100px;
                    left: 20px;
                    height: 30px;
                    line-height: 30px;
                    background: #ff0000;
                    color: #fff;
                    bottom: 15px;
                    text-align: center;
                    border-radius: 4px;
                }

        .loader_box {
            display: none;
            position: absolute;
        }

            .loader_box img {
                width: 16px;
            }

        .delNews {
            float: right;
            display: block;
            line-height: 31px;
            width: 16px;
            height: 16px;
            padding: 0;
            margin: 6px 0;
        }

            .delNews img {
                width: 16px;
                height: 16px;
            }
    </style>
    <%--    <audio id="soundHandle" src="../../Pages/P-Art/Images/alarm.wav" style="display: none;"
        runat="server">
    </audio>--%>
    <asp:HiddenField ID="hdfMasterNewsTag" runat="server" />
    <asp:HiddenField ID="hdfUserCustomSort" runat="server" />
    <asp:HiddenField ID="hdfUserID" runat="server" />
    <div class="tabbed">

        <ul>
            <li class="selected"><a href="~/news/Highlight" runat="server">در یک نگاه</a></li>
            <li class="selected"><a href="~/news/Latest" runat="server">تازه ها</a></li>
            <li class="selected"><a href="/Analysis" runat="server">تحلیل محتوا</a></li>
            <li class="selected"><a href="/News/BultanArchive" runat="server">آرشیو بولتن</a></li>
            <li class="selected"><a href="/keywords" runat="server">کلیدواژه ها</a></li>
            <li class="selected"><a href="/addnews" runat="server">ثبت خبر</a></li>
        </ul>

        <a href="#" class="flat-gray-button" id="lnk_filter">
            <span class="fontawesome-filter"></span>
            فیلتر کردن
            
        </a>
        <a href="#" class="flat-gray-button" style="margin-left: 5px" id="lnk_bultan">
            <span class="fontawesome-book"></span>
            بولتن
        </a>
        <a href="#" class="flat-gray-button" style="margin-left: 5px" id="lnk_category">
            <span class="fontawesome-list"></span>
            دسته بندی اخبار
        </a>
    </div>



    <section class="posts">

        <div class="control-box category">

            <asp:Repeater ID="rpt_Groups" runat="server" OnItemDataBound="rpt_Groups_ItemDataBound">
                <ItemTemplate>
                    <div id="group_item" class="group_item" runat="server">
                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                        <span id="color_span" runat="server">
                            <asp:CheckBox ID="check_selected_group" runat="server" />
                        </span>
                        <a href="#" data-id='<%# Eval("KeyId") %>' class="switchkeyword">
                            <label><%#Eval("KeywordName") %></label>

                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="control-box filter">
            <table>
                <tr>
                    <td>از تاریخ :</td>
                    <td>
                        <asp:TextBox ID="txt_fromDate" runat="server" CssClass="textbox" Style="" />
                    </td>
                    <td>تا تاریخ :</td>
                    <td>
                        <asp:TextBox ID="txt_toDate" runat="server" CssClass="textbox" /></td>
                    <td>منبع خبری : 
                    </td>
                    <td>
                        <asp:DropDownList ID="drp_NewsSource" runat="server" CssClass="textbox" />
                    </td>
                    <td>
                        <asp:Button ID="btn_ShowNews" runat="server" CssClass="BlueButton" Text="نمایش اخبار" OnClick="btn_ShowNews_Click" />
                    </td>
                </tr>
                <tr>
                    <td>ترتیب نمایش :
                    </td>

                    <td>

                        <asp:DropDownList ID="drp_sort" runat="server" CssClass="textbox">
                            <asp:ListItem Text="اولویت کلید واژه ها" Value="0" />
                            <asp:ListItem Text="ساعت خبر" Value="1" />
                        </asp:DropDownList>

                        <%--<asp:TextBox ID="txt_fromHour" runat="server" CssClass="textbox" Text="00:00" Style="direction: ltr" />--%>
                    </td>
                    <td></td>
                    <td>
                        <%--<asp:TextBox ID="txt_toHour" runat="server" CssClass="textbox" Text="00:00" Style="direction: ltr" />--%>
                    </td>
                    <td>کلید واژه :
                    </td>
                    <td colspan="2">

                        <asp:TextBox ID="txt_search" runat="server" CssClass="textbox" Style="width: 221px" />
                    </td>
                </tr>

                <tr>
                    <td colspan="7">

                        <a href="/News/Latest/?time=30" class="flat-gray-button time">30 دقیقه پیش
                        </a>
                        <a href="/News/Latest/?time=60" class="flat-gray-button time">1 ساعت پیش
                        </a>
                        <a href="/News/Latest/?time=180" class="flat-gray-button time">3 ساعت پیش
                        </a>
                        <a href="/News/Latest/?time=360" class="flat-gray-button time">6 ساعت پیش
                        </a>
                        <a href="/News/Latest/?time=720" class="flat-gray-button time">12 ساعت پیش
                        </a>
                        <a id="lnk_yesterday" runat="server" href="/News/Latest/?time=1440" class="flat-gray-button time">1 روز پیش
                        </a>

                    </td>
                </tr>

            </table>
        </div>
        <div class="control-box bultan">

            <table>
                <tr>
                    <td>
                        <a href="#" id="btn_SelectAll" class="flat-gray-button" style="float: right; height: 28px; margin-left: 3px; width: 4px; padding-right: 5px;" title="انتخاب کلیه اخبار">
                            <span class="entypo-check"></span>
                        </a>
                        <asp:LinkButton ID="btn_reset" runat="server" class="flat-gray-button" OnClick="btn_reset_Click" OnClientClick="return confirm('آیا برای ریست کردن تنظیمات اطمینان دارید ؟')">
                            حذف تنظیمات
                        </asp:LinkButton>
                        <asp:Button ID="btn_exportWordShort" runat="server" Text="Word خلاصه" CssClass="flat-gray-button" OnClick="btn_exportWordShort_Click" />
                        <asp:Button ID="btn_exportWord" runat="server" Text="خروجی Word" CssClass="flat-gray-button" OnClick="btn_exportWord_Click" />

                        <asp:Button ID="btnProPDF" runat="server" Text="مستر PDF" OnClick="btnProPDF_Click" CssClass="flat-gray-button" />
                        <asp:Button ID="btn_generate" runat="server" Text="خروجی PDF" CssClass="flat-gray-button" />
                        <asp:Button ID="btn_PrintLead" runat="server" Text="چاپ خلاصه اخبار" CssClass="flat-gray-button" OnClick="btn_PrintLead_Click" />
                        <asp:Button ID="btn_printTitle" runat="server" Text="چاپ تیتر اخبار" CssClass="flat-gray-button" OnClick="btn_printTitle_Click" />
                        <asp:Button ID="btn_db" runat="server" Text="خروجی DB" CssClass="flat-gray-button" OnClick="btn_db_Click" />
                        <asp:Button ID="btn_saveState" runat="server" Text="ذخیره وضعیت" CssClass="flat-gray-button" OnClick="btn_saveState_Click" />



                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:CheckBox ID="check_NewsPaper" runat="server" Text="روزنامه" />
                        <asp:CheckBox ID="check_highlight" runat="server" Text="هایلایت کلید واژه ها" />
                        <asp:CheckBox ID="check_related" runat="server" Text="شناسایی اخبار مرتبط" />

                        <asp:CheckBox ID="check_ChartKhabar" runat="server" Text="نمودار" />
                        <asp:CheckBox ID="check_Sima" runat="server" Text="صداوسیما" />

                        <asp:CheckBox ID="check_gozideh" runat="server" Text="گزیده رسانه" />


                        <asp:CheckBox ID="check_mashrooh" runat="server" Text="مشروح اخبار" />
                        <asp:CheckBox ID="check_addArchive" runat="server" Text="اضافه کردن به آرشیو بولتن" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            عنوان بولتن :
                        </label>
                        <asp:TextBox ID="txt_bultanTitle" runat="server" CssClass="textbox" Text="فاقد عنوان" />
                        <label>
                            قالب چاپی :
                        </label>
                        <asp:DropDownList ID="drp_template" runat="server" CssClass="textbox" Style="width: 102px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="#" id="lnk_download" style="display: none">دریافت فایل
                        </a>
                    </td>
                </tr>
            </table>
            <div class="loader">
                <img src="/Pages/P-Art/Images/ajax-loader.gif" />
            </div>
        </div>
        <div class="userSorting clearfix">
            <h4 class="right">
                <span class="fontawesome-sort" style="font-size: 13px; color: #073cb9;"></span>
                مرتب سازی مطالب</h4>
            <ul class="left">
                <li class="selected" id="sortByKeyword">
                    <a class="sortByKeyword" href="#sortByKeyword">کلیدواژه</a>
                </li>
                <li id="sortByTimeSort">
                    <a class="sortByTimeSort" href="#sortByTimeSort">زمان انتشار</a>
                </li>
                <li id="sortBySite">
                    <a class="sortBySite" href="#sortBySite">نام رسانه</a>


                </li>
                <li id="sortByCustom">
                    <a class="sortByCustom" href="#sortByCustom">اولویت سفارشی</a>
                    <i></i>

                </li>
                <li id="sortByTitle">
                    <a class="sortByTitle" href="#sortByTitle">عناوین</a>
                    <i></i>

                </li>
            </ul>
        </div>
        <asp:Repeater ID="news_list" runat="server" OnItemDataBound="news_list_ItemDataBound">
            <HeaderTemplate>
                <div class="news_list">
            </HeaderTemplate>
            <ItemTemplate>
                <article data-id='<%# Eval("KeywordId") %>' data-keyword='<%# Eval("KeywordId") %>' data-customsort='<%# SetCustomSort(Eval("SiteID").ToString()) %>' data-title='<%# Eval("NewsTitle") %>' data-site='<%# Eval("SiteID") %>' data-sitename='<%# Eval("SiteTitle") %>' data-timesort='<%# GetNewsFullDateIndex(Eval("CreateDate").ToString(),Eval("NewsTime").ToString(),Eval("SiteType").ToString()) %>' data-order="" class="show">

                    <div class="post-content" id="news_row" runat="server">
                        <asp:HiddenField ID="fld_news_crc" runat="server" Value='<%# Eval("NewsLinkCRC") %>' />
                        <asp:HiddenField ID="fld_color" runat="server" Value='<%# Eval("Color") %>' />
                        <asp:HiddenField ID="fld_newsId" runat="server" Value='<%# Eval("NewsId") %>' />
                        <asp:HiddenField ID="hdfNewsOrientation" runat="server" Value='<%# Eval("NewsValue") %>' />
                        <asp:HiddenField ID="fld_IsSelected" runat="server" Value='<%# Eval("IsSelected") %>' />

                        <asp:PlaceHolder runat="server" ID="pc_DelNews" Visible="false">
                            <a title="حذف خبر" class="delNews" href="#delNews" data-id='<%# Eval("NewsId") %>'>
                                <img src="/Pages/P-Art/Images/del16.png" /></a></asp:PlaceHolder>

                        <asp:TextBox ID="txt_row_index" runat="server" Text='<%# Eval("SortOrder") %>' />

                        <span class="rowIndex"><%# Container.ItemIndex + 1 %> )</span>

                        <asp:CheckBox ID="check_SelectNews" runat="server" CssClass="check_SelectNews" />
                        <h2>

                            <a target="_blank" href='<%# String.Format("~/ShowNews/{0}", Eval("NewsId")) %>' title='<%# Eval("NewsTitle") %>' data-tooltip='<%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString()) %>'
                                runat="server"><%# PArt.Pages.P_Art.Repository.Class_Static.ShortTxt(Eval("NewsTitle").ToString(),80) %>
                            </a>
                        </h2>

                        <div class="news-desc">
                            <h2>
                                <%#Eval("SiteTitle") %>
                              
                            </h2>
                            <span>
                                <%# DiffrentDate(Eval("CreateDate"),Eval("SiteType").ToString(),Eval("NewsTime").ToString()) %>
                            </span>

                        </div>
                        <div class="clear"></div>
                        <div class="clearfix newsToolsSection">
                          <div class="newsrate" runat="server">

                                <a href="#" class="btn_news_notok" title="خبر منفی" itemid='<%# Eval("NewsId") %>'
                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"2") %>'></a>

                                <a href="#" class="btn_news_empty" title="خبر خنثی" itemid='<%# Eval("NewsId") %>'
                                    style='<%# NewsRateOpacity(Eval("NewsValue"),"0") %>'></a>
                                <a href="#" class="btn_news_ok" title="خبر مثبت" itemid='<%# Eval("NewsId") %>' style='<%# NewsRateOpacity(Eval("NewsValue"),"1") %>'></a>

                            </div>   <div class="masterTag">
                                <asp:DropDownList ID="ddlMasterTag" runat="server"></asp:DropDownList>
                            </div>
                           
                        </div>

                    </div>
                </article>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>


    </section>

    <asp:GridView ID="grd_word" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# Eval("SiteTitle").ToString() %>'>

                        </asp:Literal>

                    </span>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p style="font-family: 'B Titr'; font-size: 18px; direction: rtl; text-align: justify; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#  (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p style="font-family: 'B Nazanin'; font-size: 15px; text-align: justify; direction: rtl; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltLead" Text='<%#  (Eval("NewsLead").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p style="font-family: 'B Nazanin'; font-size: 15px; text-align: justify; direction: rtl; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltBody" Text='<%#  (Eval("NewsBody").ToString()) %>'>

                        </asp:Literal>
                    </p>


                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:GridView ID="grd_word_short" runat="server" OnRowDataBound="grd_word_RowDataBound" AutoGenerateColumns="False" ShowHeader="False"
        BorderStyle="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%-- <ItemStyle Wrap="True" />--%>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">

                        <asp:Literal runat="server" ID="ltSiteTitle" Text='<%# Eval("SiteTitle").ToString() %>'>

                        </asp:Literal>

                    </span>
                    <span style="direction: rtl; width: 160px; height: 100px; border: 1px solid black; text-align: right; font-family: 'B Titr'; font-size: 15px;">


                        <asp:Literal runat="server" ID="ltDate" Text='<%# mirrorDate(Eval("NewsDate").ToString()) %>'>

                        </asp:Literal>

                    </span>
                    <p style="font-family: 'B Titr'; font-size: 18px; direction: rtl; text-align: justify; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltTitle" Text='<%#  (Eval("NewsTitle").ToString()) %>'>

                        </asp:Literal>
                    </p>

                    <p style="font-family: 'B Nazanin'; font-size: 15px; text-align: justify; direction: rtl; margin-right: 20px; margin-left: 20px">

                        <asp:Literal runat="server" ID="ltLead" Text='<%#  (Eval("NewsLead").ToString()) %>'>

                        </asp:Literal>
                    </p>



                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <div class="shadowModal"></div>
    <div class="modalSiteSort">
        <div class="modalHeader"></div>
        <div class="modalContainer clearfix">
            <asp:Repeater runat="server" ID="rptSiteSort">
                <HeaderTemplate>
                    <div class="containerSiteSort right ">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="sortItem">

                        <%--  <asp:TextBox placeholder="اولویت نمایش" runat="server" ID="txtSortOrder" CssClass="numbericBox" Width="50px"></asp:TextBox>--%>

                        <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                        <i class="remove"></i>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <div class="containerSortSeleted">
                <h5 style="">سایت های موردنظر  خود را اینجا بیاورید</h5>
                <div class="selectedListItems">
                    <asp:Repeater runat="server" ID="rptSelectedSiteSort">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="selectedSiteItem">


                                <span data-id='<%# Eval("SiteID") %>'><%# Eval("SiteTitle") %></span>
                                <i class="remove"></i>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <div class="modalFooter">
            <a id="btnRegSiteSort" href="#regModel" class="regBtn">
                <span>ثبت</span>
            </a>
            <a id="btnCancelSiteSort" href="#closeModal" class="cancelBtn">
                <span>انصراف</span>
            </a>
        </div>
    </div>
    <%--  <script src="/Pages/P-Art/Scripts/tsort.min.js"></script>--%>
    <div class="loader_box">
        <img src="/Pages/P-Art/images/loading.gif" />
    </div>
    <script type="text/javascript">
        $(document).ready(function () {


            if (window.location.pathname == "/tv") {
                $(".btn_tv").click();
            }

        });


        $('#sortByTimeSort a').live('click', function (e) {
            $(".news_list article").sort(sort_timesort) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTimeSort').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByCustom a').live('click', function (e) {
            $(".news_list article").sort(sort_custom) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByCustom').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByTitle a').live('click', function (e) {

            // $('.news_list>article').tableSort({ attr: 'data-title' });

            $(".news_list article").sort(sort_title) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByTitle').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortBySite a').live('click', function (e) {
            $(".news_list article").sort(sort_site) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortBySite').addClass('selected');
            sortArticleIndex();
            e.preventDefault();

        });
        $('#sortByKeyword a').live('click', function (e) {
            $(".news_list article").sort(sort_keyword) // sort elements
                .appendTo('.news_list'); // append again to the list

            $('.userSorting ul li').removeClass('selected');
            $('#sortByKeyword').addClass('selected');
            sortArticleIndex();
            e.preventDefault();
        });
        $('.userSorting li#sortByCustom i').live('click', function (e) {

            ShowShadowModal();
            ShowSiteSortModal();
        });
        $('.modalFooter .cancelBtn').live('click', function (e) {

            CloseShadowModal();
            CloseSiteSortModal();
        });
        $('.modalFooter .regBtn').live('click', function (e) {


            var fileOffset = $(this).offset();

            $('.loader_box').css({ 'left': fileOffset.left, 'top': fileOffset.top });
            $('.loader_box').fadeIn('fast');
            var siteIds = '';
            $('.modalSiteSort .selectedListItems  .selectedSiteItem').each(function (index) {

                var $this = $(this);
                var siteId = $this.find('span').attr('data-id');
                if (siteIds == '') {
                    siteIds = siteId;
                }
                else {
                    siteIds = siteIds + "," + siteId;
                }

            });

            $.ajax({
                type: "POST",
                url: "/Pages/P-Art/Pages/ajax.aspx/UpdateUserSortingOrder",
                data: "{'userId':'<%=hdfUserID.Value%>','siteIds':'" + siteIds + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //   alert(data.d.length);


                    $('.loader_box').fadeOut('fast');
                    CloseShadowModal();
                    CloseSiteSortModal();
                },
                error: function (msg) {
                    alert(msg.messege);
                    $('.loader_box').fadeOut('fast');
                    CloseShadowModal();
                    CloseSiteSortModal();
                    // alert(msg.responseText);
                }
            });

            e.preventDefault();

        });
        $('.modalSiteSort .modalContainer .containerSortSeleted .selectedSiteItem .remove').live('click', function () {
            $this = $(this);
            $this.parent().fadeOut().remove();
        });

        var $sitesSort = $(".containerSiteSort"),
             $selected = $(".selectedListItems");

        // let the gallery items be draggable
        $("div", $sitesSort).draggable({
            cancel: "a.ui-icon", // clicking an icon won't initiate dragging
            revert: "invalid", // when not dropped, the item will revert back to its initial position
            containment: "document",
            helper: "clone",
            cursor: "move"
        });

        // let the trash be droppable, accepting the gallery items
        $selected.droppable({
            accept: ".containerSiteSort > div",
            activeClass: "ui-state-highlight",
            drop: function (event, ui) {
                $selected.append("<div class='selectedSiteItem'>" + ui.draggable.html() + "</div>");
            }
        });
        $('.selectedListItems').sortable();
        $('.selectedListItems').disableSelection();


        function ShowShadowModal() {
            $('.shadowModal').fadeIn();
        }
        function ShowSiteSortModal() {
            $('.modalSiteSort').fadeIn();
        }
        function CloseShadowModal() {
            $('.shadowModal').fadeOut();
        }
        function CloseSiteSortModal() {
            $('.modalSiteSort').fadeOut();
        }
        // sort function callback
        function sort_timesort(a, b) {
            return ($(b).data('timesort')) > ($(a).data('timesort')) ? 1 : -1;
        }
        function sort_site(a, b) {
            return ($(b).data('sitename')) < ($(a).data('sitename')) ? 1 : -1;
        }
        function sort_custom(a, b) {

            return ($(b).data('customsort')) < ($(a).data('customsort')) ? 1 : -1;

        }
        function sort_keyword(a, b) {
            return ($(b).data('keyword')) < ($(a).data('keyword')) ? 1 : -1;
        }
        function sort_title(a, b) {
            return ($(b).data('title')) < ($(a).data('title')) ? 1 : -1;
            return b - a;
            //var keyA = $(a).data('title');
            //var keyB = $('td:eq(0)',b).text();

            //    return (keyA< keyB) ? 1 : 0;


        }
        function sortArticleIndex() {
            var counter = 1;
            // alert('yes');
            $('.news_list article.show').each(function (index) {
                var $this = $(this);
                $this.find('.post-content').find('span.rowIndex').text(parseInt(counter) + ")");
                counter++;
            });
        }
        $('.delNews').live('click', function (e) {
            var $this = $(this);
            var newsID = $this.attr('data-id');
            $thisDiv = $this.parent().parent();

            var result = confirm("برای حذف خبر مطمئن هستید؟");
            if (result) {


                $.ajax({
                    type: "POST",
                    url: "/Pages/P-Art/Pages/ajax.aspx/DeleteNews",
                    data: "{'NewsId':'" + newsID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //   alert(data.d.length);


                        $thisDiv.remove();
                    },
                    error: function (msg) {
                        alert('حطا در حذف خبر');

                        // alert(msg.responseText);
                    }
                });
            }
            e.preventDefault();

        });
    </script>
</asp:Content>
