<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ASP___JS.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        var size = 16;

        function incText() {
            size += 1;

            document.getElementById("p1").style.fontSize = size + "px";
            document.getElementById("p2").style.fontSize = size + "px";
        }

        function decText() {
            size -= 1;

            document.getElementById("p1").style.fontSize = size + "px";
            document.getElementById("p2").style.fontSize = size + "px";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" onClick="incText()">Aumentar tamanho</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" onClick="decText()">Reduzir tamanho</asp:HyperLink>
        </div>
        <asp:Label ID="p1" runat="server" Text="Label">Exemplo de como alterar o tamanho da fonte de um parágrafo</asp:Label>
        <br />
        <asp:Label ID="p2" runat="server" Text="Label">PSI - Módulo 18</asp:Label>
    </form>
</body>
</html>
