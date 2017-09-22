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
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" align="center">
        <h2>Login de Usuarios</h2>
        <br>
        <strong>Usuario:</strong> <input type="text" id="usuario_txt"><br>
    </div>
    <div class="container" align="center">
        <br>
        <strong>Contraseña:</strong> <input type="text" id="pass_txt"><br>
    </div>
    <div class="container" align="center">
        <br>
        <asp:Button ID="BttnLogin" runat="server" Text="Login" OnClick="BttnLogin_Click" />
        <button id="ingresar_btn">Ingresar</button>
        <br>
    </div>
    </form>
</body>
</html>
