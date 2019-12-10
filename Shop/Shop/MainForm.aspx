<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Shop.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="style/style.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            height: 55px;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            text-align: center;
            height: 42px;
        }
        .menu{
    color:black;
    text-decoration:none;
    font-size:25px;
    margin:0px 30px;
    background-color: darkgray;
    border:none;
}
        .menu:hover {
        color: yellow;
        cursor: pointer;
    }
    </style>
</head>
<body style="background-color: darkgray">
    <form id="form1" runat="server" class="container">
        <div>
            <table align="center" class="auto-style1 " style="font-family: 'Adobe Fangsong Std R'; background-color: darkgray">
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Image ID="Image1" runat="server" Height="70px" ImageUrl="~/img/nutki.png" />
                        <asp:Label ID="lTitle" runat="server" CssClass="header" style="color: yellow" Font-Names="Adobe Fangsong Std R" Text="Sklep Muzyczny"></asp:Label>
                    </td>
                    <td class="auto-style2" colspan="1">
                        <asp:Button ID="btSignin" runat="server" OnClick="btSignin_Click" Text="Zaloguj" BorderStyle="None" CssClass="buttonMain" />
                        <asp:Button ID="btLogOut" runat="server" Text="Wyloguj" Visible="False" BorderStyle="None" CssClass="buttonMain" OnClick="btLogOut_Click" />
                        <br />
                        <asp:Label ID="lUserName" runat="server" Font-Names="Adobe Fangsong Std R" Font-Overline="False" Font-Size="Small" ForeColor="Black"></asp:Label>
                        <br />
                        <asp:ImageButton ID="btKoszyk" runat="server" Height="40px" ImageUrl="~/img/trolley.png" Visible="False" OnClick="btKoszyk_Click" />
                        <asp:ImageButton ID="imgTools" runat="server" Height="40px" ImageUrl="~/img/tools.png" OnClick="imgTools_Click" Visible="False" />
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="4" class="auto-style4">
                        <asp:Button ID="btMenu" runat="server" CssClass="menu" OnClick="btMenu_Click" Text="Home" />
                        <asp:Button ID="btAll" runat="server" CssClass="menu" Text="Wszystkie" OnClick="btAll_Click" />
                        <asp:Button ID="btSale" runat="server" CssClass="menu" Text="Wyprzedaż" OnClick="btSale_Click" />
                    </td>

                </tr>
                <tr>
                    <td colspan="4" class="auto-style4 polecane" style="color: black; border-radius: 50px 50px 50px 50px; background-color: yellow" >
                        <br />
                        <asp:Label ID="lPolecane" runat="server" Font-Size="X-Large" Text="Polecane"></asp:Label>
                        <br />
                        <br />
                    </td>

                </tr>
                <tr class="polecaneItems">
                    <td class="auto-style5">
                        <asp:Label ID="lPolTyt1" runat="server" Text="Label" CssClass="tytulPol"></asp:Label>
                        <br />
                        <asp:Image ID="iPol1" runat="server" />
                        <br />
                        <asp:Label ID="lPolWyk1" runat="server" Text="Label" ></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="lPolTyt2" runat="server" Text="Label" CssClass="tytulPol"></asp:Label>
                        <br />
                        <asp:Image ID="iPol2" runat="server" />
                        <br />
                        <asp:Label ID="lPolWyk2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="lPolTyt3" runat="server" Text="Label" CssClass="tytulPol"></asp:Label>
                        <br />
                        <asp:Image ID="iPol3" runat="server" />
                        <br />
                        <asp:Label ID="lPolWyk3" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="lPolTyt4" runat="server" Text="Label" CssClass="tytulPol"></asp:Label>
                        <br />
                        <asp:Image ID="iPol4" runat="server" />
                        <br />
                        <asp:Label ID="lPolWyk4" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
