<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shop.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="style/style.css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
            text-align: center;
            height: 434px;
        }
        .auto-style20 {
            height: 26px;
            text-align: left;
            width: 390px;
        }
        .auto-style22 {
            text-align: left;
            width: 390px;
        }
        .auto-style23 {
            height: 26px;
            text-align: right;
            width: 285px;
        }
        .auto-style24 {
            text-align: right;
            width: 285px;
        }
        .auto-style29 {
            text-align: justify;
            width: 390px;
        }
        .auto-style30 {
            height: 26px;
            text-align: left;
            width: 285px;
        }
    </style>
</head>
<body class="loginBody">
    <form id="form1" runat="server" class="container">
        <div>
            <table align="center" class="auto-style1">
                <tr>

                    <td class="auto-style5" colspan="2">
                        <asp:Image ID="Image1" runat="server" Height="390px" ImageUrl="~/img/user.png" Width="374px" />
                    </td>

                </tr>
                <tr>
                  
                    <td>&nbsp;</td>
                    <td class="auto-style30" colspan="1">
                        <asp:Label ID="lLoginError" runat="server" CssClass="loginError" ForeColor="#CC3300"></asp:Label>
                        <br />
                    </td>
                   
                </tr>
                <tr>
                
                    <td class="auto-style23">
                        <asp:Label ID="lLogin" runat="server" Text="Login :"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="iLogin" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="iLogin" ErrorMessage="Login wymagany" ForeColor="#CC3300"  ValidationGroup='valGroup1'>*</asp:RequiredFieldValidator>
                    </td>
                   
                </tr>
                <tr>
                   
                    <td class="auto-style24">
                        <asp:Label ID="lPassword" runat="server" Text="Hasło :"></asp:Label>
                    </td>
                    <td class="auto-style22">
                        <asp:TextBox ID="iPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="iPassword" ErrorMessage="Hasło wymagane" ForeColor="#CC3300"  ValidationGroup='valGroup1'>*</asp:RequiredFieldValidator>
                    </td>
                   
                </tr>
                <tr>
                 
                    <td class="auto-style23">
                        <asp:Label ID="lMail" runat="server" Text="Email :" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:Button ID="btLogin" runat="server" Height="30px" OnClick="btLogin_Click" Text="Zaloguj" Width="165px"  ValidationGroup='valGroup1' />
                        <asp:TextBox ID="tbMail" runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMail" runat="server" ControlToValidate="tbMail" ErrorMessage="Email wymagany" ForeColor="#CC3300" Visible="False"  ValidationGroup='valGroup1'>*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMail" runat="server" ControlToValidate="tbMail" ErrorMessage="Błędny format email" ForeColor="Red"  ValidationGroup='valGroup1' ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Visible="False">*</asp:RegularExpressionValidator>
                    </td>
                   
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style29" colspan="1">
                        <asp:Button ID="btRegister" runat="server" Height="30px" OnClick="btRegister_Click" Text="Zarejstruj" Width="165px" />
                        <asp:Button ID="btRegister2" runat="server" Height="30px" OnClick="btRegister2_Click" Text="Zarejstruj" Visible="False" Width="165px"  ValidationGroup='valGroup1'/>
                        <br />
                        <br />
                        <asp:ValidationSummary ID="vs1" runat="server" ForeColor="Red"   ValidationGroup='valGroup1'/>
                    </td>
                
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
