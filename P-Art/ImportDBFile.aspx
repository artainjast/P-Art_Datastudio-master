<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportDBFile.aspx.cs" Inherits="P_Art.ImportDBFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>فایل :</td>
                    <td>
                        <asp:FileUpload runat="server" ID="fupFile" />
                    </td>
                    <td>
                        <asp:LinkButton runat="server" ID="btnDo" OnClick="btnDo_Click">
                            ارسال اطلاعات
                        </asp:LinkButton>
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="ltCount"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
