<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Shop.Admin" %>

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
    background-color: darkgray;
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
    background-color: darkgray;

}
        .auto-style4 {
            text-align: center;
        }
        .menu{
    color:black;
    text-decoration:none;
    font-size:25px;
    margin:0px 30px;
    background:darkgray;
    border:none;
}
        .menu:hover {
        color: yellow;
        cursor: pointer;
    }
    .polecane {
    border-radius:50px 50px 50px 50px;
}
        .auto-style8 {
            width: 565px;
            text-align: right;
        }
        .auto-style9 {
            text-align: left;
        }
        .auto-style10 {
            width: 571px;
            text-align: right;
        }
    </style>
</head>
<body style="background-color: darkgray">
  
    <form id="form2" runat="server" class="container" enctype="multipart/form-data">
        <div>
            <table align="center" class="auto-style1 " style="font-family: 'Adobe Fangsong Std R'; background-color: darkgray">
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="Image1" runat="server" Height="70px" ImageUrl="~/img/nutki.png" />
                        <asp:Label ID="lTitle" runat="server" CssClass="header" Font-Names="Adobe Fangsong Std R" Text="Sklep Muzyczny"></asp:Label>
                    </td>
                    <td class="auto-style2" colspan="1">
                        <asp:Button ID="btLogOut" runat="server" Text="Wyloguj" Visible="False" BorderStyle="None" CssClass="buttonMain" OnClick="btLogOut_Click" />
                        <br />
                        <asp:Label ID="lUserName" runat="server" Font-Names="Adobe Fangsong Std R" Font-Overline="False" Font-Size="Small" ForeColor="Black"></asp:Label>
                        <br />
                        <asp:ImageButton ID="imgTools" runat="server" Height="40px" ImageUrl="~/img/tools.png" OnClick="imgTools_Click" />
                    </td>
                   
                </tr>
                <tr>
                    <td colspan="2" class="auto-style4">
                        <asp:Button ID="btMenu" runat="server" CssClass="menu" OnClick="btMenu_Click" Text="Home" />
                        <asp:Button ID="btAll" runat="server" CssClass="menu" Text="Wszystkie" OnClick="btAll_Click" />
                        <asp:Button ID="btSale" runat="server" CssClass="menu" Text="Wyprzedaż" OnClick="btSale_Click" />
                    </td>

                </tr>
                <tr>
                    <td colspan="2" class="auto-style4 polecane" style="color: #FFFFFF; background-color: #000000">
                        <br />
                        <asp:Label ID="lPolecane" runat="server" Font-Size="X-Large" Text="Panel Administracyjny"></asp:Label>
                        <br />
                        <asp:Label ID="lId" runat="server" Text="Label" Visible="False"></asp:Label>
                        <br />
                    </td>

                </tr>
                <tr >
                    
                    
                    <td colspan="4">
                        <asp:Button ID="btnAdd" runat="server" Text="Dodaj produkt" OnClick="btnAdd_Click" />
                    </td>
                   

                  
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lInfoAlert" runat="server" ForeColor="Lime"></asp:Label>
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="valGroup1" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" id="produkty">
                        <asp:Panel ID="pAdd" runat="server" Visible="False">
                            <table style="width:100%;">
                                <tr>
                                    <td class="auto-style8" >
                                        <asp:Label ID="Label1" runat="server" Text="Tytuł :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbTyt" runat="server"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="auto-style8" >
                                        <asp:Label ID="Label2" runat="server" Text="Wykonawca :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbWyk" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                   <td class="auto-style8" >
                                       <asp:Label ID="Label3" runat="server" Text="Gatunek :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbGat" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style8" >
                                        <asp:Label ID="Label4" runat="server" Text="Cena :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbCen" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbCen" ErrorMessage="Zły format ceny" ForeColor="Red" ValidationExpression="[0-9]*[,|(0-9)][0-9]*" ValidationGroup="valGroup1">*</asp:RegularExpressionValidator>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="auto-style8" >
                                        <asp:Label ID="Label5" runat="server" Text="Okładka:"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:FileUpload ID="fuOkl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                   <td class="auto-style8" ></td>
                                    <td class="auto-style9">
                                        <asp:Button ID="btnZapiszAdd" runat="server" Text="Dodaj" Width="164px" OnClick="btnZapiszAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pDel" runat="server">
                        </asp:Panel>

                        <asp:Panel ID="pUpdate" runat="server" Visible="False">
                            <table style="width:100%;">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lUpdate" runat="server" Text="Update"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style8" >
                                        <asp:Label ID="lidU" runat="server" Text="lidU"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" Text="Tytuł :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbTytU" runat="server"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="auto-style8" >
                                        <asp:Label ID="Label7" runat="server" Text="Wykonawca :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbWykU" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                   <td class="auto-style8" >
                                       <asp:Label ID="Label8" runat="server" Text="Gatunek :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbGatU" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style8" >
                                        <asp:Label ID="Label9" runat="server" Text="Cena :"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="tbCenU" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbCenU" ErrorMessage="Zły format ceny" ForeColor="Red" ValidationExpression="[0-9]*[,|(0-9)][0-9]*" ValidationGroup="valGroup1">*</asp:RegularExpressionValidator>
                                    </td>
                                    
                                </tr>

                                <tr>
                                   <td class="auto-style8" ></td>
                                    <td class="auto-style9">
                                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="167px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                        <asp:Panel ID="pSale" runat="server" Visible="False">
                             <table style="width:100%;">
                                 
                             <tr>
                                 <td colspan="2">
                                     <asp:Label ID="Label10" runat="server" Text="Sale"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="auto-style10">
                                     <asp:Label ID="Label11" runat="server" Text="Cena :"></asp:Label>
                                 </td>
                                 <td class="auto-style9">
                                     <asp:Label ID="lCenaOld" runat="server" Text="Label"></asp:Label>
                                 </td>
                             </tr>
                                 <tr>
                                 <td class="auto-style10">
                                     <asp:Label ID="Label12" runat="server" Text="Obniżka (w zł):"></asp:Label>
                                     </td>
                                 <td class="auto-style9">
                                     <asp:TextBox ID="tbSale" runat="server"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbSale" ErrorMessage="Zły format ceny" ForeColor="Red" ValidationExpression="[0-9]*[,|(0-9)][0-9]*" ValidationGroup="valGroupS">*</asp:RegularExpressionValidator>
                                     </td>
                             </tr>
                                 <tr>
                                 <td class="auto-style10">
                                     <asp:Label ID="lIdSale" runat="server" Text="Label" Visible="False"></asp:Label>
                                     </td>
                                 <td class="auto-style9">
                                     <asp:Button ID="btSaleOk" runat="server" OnClick="btSaleOk_Click" Text="Zapisz" ValidationGroup="valGroupS" Width="165px" />
                                     </td>
                             </tr>
                             </table>
                        </asp:Panel>

                        <br />
                    </td>
                   
                </tr>

            </table>
        </div>
    </form>


</body>
</html>
