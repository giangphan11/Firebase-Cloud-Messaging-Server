<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FirebaseCMServer.form.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="Nhập tiêu đề:"></asp:Label>
            <br />
            <asp:TextBox ID="txtTieuDe" runat="server" Width="972px"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Nhập nội dung:"></asp:Label>
            <br />
            <asp:TextBox ID="txtNoiDung" runat="server" Height="233px" TextMode="MultiLine" Width="979px"></asp:TextBox>
            <br />
            <asp:Button ID="btnGui" runat="server" Text="Gửi thông báo" Height="43px" OnClick="btnGui_Click" Width="166px" />
            <br />
            <br />
            kết quả sau khi gửi thông báo:<br />
            <asp:TextBox ID="txtKQ" runat="server" Height="173px" TextMode="MultiLine" Width="986px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
