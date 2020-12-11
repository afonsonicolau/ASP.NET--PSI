<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Tabuada.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1><asp:Label ID="Label1" runat="server" Text="Just Do It!"></asp:Label></h1>
    <form id="form1" runat="server">
        <asp:DropDownList ID="ddlNumbers" runat="server" Height="16px" Width="150px"></asp:DropDownList>
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
        <br />
        <asp:ListBox ID="lbTable" runat="server" Width="150px" Height="172px"></asp:ListBox>
        <br />
        <asp:Table ID="tblMultiplication" runat="server" BorderColor="#6699FF" BorderStyle="Groove" Visible="False">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Choosen Number</asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">Number</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server">Result</asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">1</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">2</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">3</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">4</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">5</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">6</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">7</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">8</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">9</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">x</asp:TableCell>
                <asp:TableCell runat="server">10</asp:TableCell>
                <asp:TableCell runat="server">=</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>                
            </asp:TableRow>
        </asp:Table>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
