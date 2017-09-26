<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>.:: Herramienta Jefes ::.</title>
    
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: normal;
        }
        table th, table td
        {
            border: 1px solid #ccc;
        }
       
    </style>
    
    <script type="text/javascript">
    function SomeMethod(){
        // put your code here 
        
        var usuarioValue = document.getElementById('txtUsuario').value;
        var passwordValue = document.getElementById('TxtPwd').value;
        
        if (usuarioValue != '' && passwordValue != ''){
            return true;
        }
        else{
            alert('Usuario o contraseña incorrecto');
            return false;
        }
        
    }
</script>
</head>
<body>
<div align="left"><strong>SIEMBI</strong></div>
    <form id="form1" runat="server">
    <center>
    <h1>Login de Usuarios</h1>
    <h3>Hoteles MileniuM</h3>
    <table cellpadding="2" cellspacing="2" style="border:10" width="50%">
        <tr align="center" >
            <td align="center" style="width:50%">
                <asp:Label ID="LblUsuario" runat="server" Text="Usuario :"></asp:Label></td>
            <td align="center" style="width:50%">
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="validadorUsuario" runat="server" ErrorMessage="*" Visible="False"></asp:RequiredFieldValidator><br>
            </td>
        </tr> 
        <tr align="center" >
            <td align="center" style="width:50%">
                <asp:Label ID="LblPwd" runat="server" Text="Password :"></asp:Label></td>
            <td align="center" style="width:50%">
                <asp:TextBox ID="TxtPwd" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validatorPass" runat="server" ErrorMessage="*" Visible="False"></asp:RequiredFieldValidator><br>
            </td>
        </tr>  
        <tr align="center" >
            <td align="center" colspan="3">
                <asp:Label ID="lblAlert" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label></td>
        </tr>                 
    </table>
    <div class="container" align="center">
        <br>
        <asp:Button ID="BttnLogin" runat="server" Text="Login" OnClick="BttnLogin_Click" OnClientClick="return SomeMethod();" />
        <br>
    </div>
    </center>    
    </form>
</body>
</html>
