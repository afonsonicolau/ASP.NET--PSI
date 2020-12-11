<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Exemplo1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
        <asp:Button ID="btnHello" runat="server" OnClick="btnHello_Click" Text="Hello" />
        <p>
            <asp:Label ID="Label1" runat="server" Text="Write your name above."></asp:Label>
        </p>
    </form>
</body>
</html>
