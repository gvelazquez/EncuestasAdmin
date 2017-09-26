<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>.::Menu Principal::.</title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="right">
            <asp:Button ID="salirBtn" runat="server" Text="Salir" OnClick="salirBtn_Click"/>
        </div>
        <div align="center">
            <asp:Image id="img1" Height="200px" ImageUrl="https://media.licdn.com/mpr/mpr/shrink_200_200/AAEAAQAAAAAAAAdwAAAAJDExMjIwNTY0LTU5OGEtNDA1NS04Y2ZiLWIxMzhhZmNlY2FmZQ.png" runat="server" Width="200px" AlternateText="Imagen no disponible" ImageAlign="TextTop" /><br />
            <br/>
        </div>
        <div align="center">
            <h3>Agregar Nuevo</h3>
            <table cellpadding="2" cellspacing="2" style="border:10" width="50%">
                <tr align="center">
                    <td align="center" style="width:191px">
                        <asp:Label ID="lblHotel" runat="server" Text="Hotel:"></asp:Label>
                    </td>
                    <td align="center" style="width:50%">
                        <asp:TextBox ID="txtHotel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px">
                        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento:"></asp:Label>
                    </td>
                    <td align="center" style="width:50%">
                        <asp:TextBox ID="txtDepartamento" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px; height: 28px;">
                        <asp:Label ID="lblJefe" runat="server" Text="Jefe:"></asp:Label>
                    </td>
                    <td align="center" style="width:50%; height: 28px;">
                        <asp:TextBox ID="txtJefe" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    <tr align="center" >
                        <td align="center" colspan="3">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                        </td>
                    </tr>
            </table>
            <br />
            <br />
        </div>
        <div align="center">
            <h3>Listado de Jefes</h3>
            <asp:GridView ID="gvJefes" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
