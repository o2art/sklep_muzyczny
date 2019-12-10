<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="Shop.Sale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


.container{
    width:80%;
    margin:0 auto;
    text-align:center;
}
*{
    margin:0 auto;
}
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            height: 55px;
        }
        .header{
    color:yellow;
    font-size:100px;
}
.buttonMain {
    background-color: white;

}
        .auto-style4 {
            text-align: center;
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
    .polecane {
    border-radius:50px 50px 50px 50px;
}
        .auto-style5 {
            text-align: center;
            height: 42px;
        }
    </style>
</head>
<body style="background-color: darkgray">
    <form id="form2" runat="server" class="container">
        <div>
            <table align="center" class="auto-style1 " style="font-family: 'Adobe Fangsong Std R'; background-color: darkgray">
                <tr>
                    <td class="auto-style2" colspan="3">
                        <asp:Image ID="Image1" runat="server" Height="70px" ImageUrl="~/img/nutki.png" />
                        <asp:Label ID="lTitle" runat="server" CssClass="header" Font-Names="Adobe Fangsong Std R" Text="Sklep Muzyczny"></asp:Label>
                    </td>
                    <td class="auto-style2" colspan="1">
                        <asp:Button ID="btSignin" runat="server" OnClick="btSignin_Click" Text="Zaloguj" BorderStyle="None" CssClass="buttonMain" />
                        <asp:Button ID="btLogOut" runat="server" Text="Wyloguj" Visible="False" BorderStyle="None" CssClass="buttonMain" OnClick="btLogOut_Click" />
                        <br />
                        <asp:Label ID="lUserName" runat="server" Font-Names="Adobe Fangsong Std R" Font-Overline="False" Font-Size="Small" ForeColor="Black"></asp:Label>
                        <br />
                        <asp:ImageButton ID="btKoszyk" runat="server" Height="40px" ImageUrl="~/img/trolley.png" Visible="False" OnClick="btKoszyk_Click" />
                        <asp:ImageButton ID="imgTools" runat="server" Height="40px" ImageUrl="~/img/tools.png" Visible="False" OnClick="imgTools_Click" />
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
                    <td colspan="4" class="auto-style4 polecane" style="color: #FFFFFF; background-color: #000000">
                        <br />
                        <asp:Label ID="lPolecane" runat="server" Font-Size="X-Large" Text="Na promocji (oferta obowiązuje tylko w sklepach stacjonarnych)"></asp:Label>
                        <br />
                        <br />
                    </td>

                </tr>
                <tr >
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <br />
                        </td>
                    <td class="auto-style5">
                        </td>
                    <td class="auto-style5">
                        </td>
                </tr>
                <tr>
                    <td colspan="4" id="produkty">
                        <asp:Panel ID="pItems" runat="server">
                        </asp:Panel>
                    </td>
                   
                </tr>
                <tr>
                    <td colspan ="3"></td>
                    <td>
                        <asp:Panel ID="pPaginacja" runat="server">
                        </asp:Panel>
                    </td>
                </tr>

            </table>
        </div>
    </form>

</body>
</html>
