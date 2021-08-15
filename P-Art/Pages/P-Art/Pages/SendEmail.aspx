<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="P_Art.Pages.P_Art.Pages.SendEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Pages/P-Art/Styles/MainStyle.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 303px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mail-box">
            <table>
                <tr>
                    <td>ایمیل گیرنده :</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_Mail" runat="server" CssClass="textbox" style="text-align:left" />
                    </td>
                </tr>
                <tr>
                    <td>نام فرستنده :</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_name" runat="server" CssClass="textbox" />
                    </td>
                </tr>
                <tr>
                    <td>عنوان خبر :</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_title" runat="server" CssClass="textbox" />
                    </td>
                </tr>
                <tr>
                    <td>خلاصه اخبار</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_lead" runat="server" CssClass="textbox" Height="150px" 
                            TextMode="MultiLine" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button CssClass="ButtonRed" ID="btn_Send" runat="server" Text="ارسال ایمیل" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
