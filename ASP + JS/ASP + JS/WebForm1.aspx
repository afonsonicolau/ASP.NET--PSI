<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASP___JS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function showMessage() {
            alert("Hello World!");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/use.jpg" onMouseOver="showMessage()"/>
        <p>
            <asp:Button ID="btnClick" runat="server" OnClick="btnClick_Click" OnClientClick="showMessage()" Text="Clique Aqui" />
        </p>
    </form>
</body>
</html>
