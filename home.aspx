<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>.::Menu Principal::.</title>
    
    
    <script type="text/javascript">
    function ValidarCampos(){
        // put your code here 
        var idhotelValue = document.getElementById('ddlHotel').value;
        var usuarioValue = document.getElementById('txtUsuario').value;
        var deptoValue = document.getElementById('ddlDepartamento').value;
        var periodoValue = document.getElementById('txtPeriodo').value;
        var anioValue = document.getElementById('txtAnio').value;
        
        if (idhotelValue == 'AAAAAAA'){
            alert('Captura un hotel');
            return false;
        }
        
        if (usuarioValue == ''){
            alert('Captura Usuario');
            return false;
        }
        
        if (deptoValue == '0'){
            alert('Captura Depto');
            return false;
        }
        
        if (periodoValue == ''){
            alert('Captura Periodo');
            return false;
        }
    }
    
    function confirmar(){
        var txt;
        var r = confirm("Seguro que desea salir?");
        if (r == true) {
            return true;
        } else {
            return false;
        }
    }

</script>

</head>
<body>
    <form id="form1" runat="server">
        <div align="right">
            <asp:Button ID="salirBtn" runat="server" Text="Salir" OnClientClick="return confirmar();" OnClick="salirBtn_Click"/>
            <div align="center">
            <asp:Image id="img1" Height="200px" ImageUrl="https://media.licdn.com/mpr/mpr/shrink_200_200/AAEAAQAAAAAAAAdwAAAAJDExMjIwNTY0LTU5OGEtNDA1NS04Y2ZiLWIxMzhhZmNlY2FmZQ.png" runat="server" Width="200px" AlternateText="Imagen no disponible" ImageAlign="TextTop" /><br />
            </div>
        </div>
        
        <div align="center">
            <h3>Agregar Nuevo</h3>
            <table cellpadding="2" cellspacing="2" style="border:10" width="50%">
                <tr align="center">
                    <td align="center" style="width:191px">
                        <asp:Label ID="lblHotel" runat="server" Text="Hotel:"></asp:Label>
                    </td>
                    <td align="center" style="width:50%">
                        <asp:DropDownList ID="ddlHotel" runat="server" Width="250px" AutoPostBack="True" ></asp:DropDownList>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>  
                    </td>
                    <td align="center" style="width:50%">
                        <asp:TextBox ID="txtUsuario" AutoPostBack="false" runat="server" Width="250px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_Jefe" 
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreJefeEncuestas"
                                    ServicePath="" 
                                    TargetControlID="txtUsuario" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="3" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                        
                        <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods = "true">
                        </asp:ScriptManager>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px; height: 26px;">
                        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento/Division/Direccion:"></asp:Label>
                    </td>
                    <td align="center" style="width:50%; height: 26px;">
                        <asp:DropDownList ID="ddlDepartamento" runat="server" Width="250px" AutoPostBack="True" ></asp:DropDownList>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px; height: 28px;">
                        <asp:Label ID="lblPeriodo" runat="server" Text="Periodo"></asp:Label>
                    </td>
                    <td align="center" style="width:50%; height: 28px;">
                        <asp:TextBox ID="txtPeriodo" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px">
                        <asp:Label ID="lblAnio" runat="server" Text="Año"></asp:Label>
                    </td>
                    <td align="center" style="width:50%">
                        <asp:TextBox ID="txtAnio" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                    <tr align="center" >
                        <td align="center" colspan="3">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClientClick="return ValidarCampos();" OnClick="btnAgregar_Click" />
                        </td>
                    </tr>
            </table>
            <br />
            <br />
        </div>
        <div align="center">
            <h3>Listado de Jefes</h3>
            <asp:GridView ID="gvJefes" runat="server" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:TemplateField HeaderText="Hotel">
                        <ItemTemplate>
                            &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Bind("hotel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Primer Apellido">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("appaterno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Segundo Apellido">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("apmaterno") %>'></asp:Label>
                        </ItemTemplate>
                  
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Departamento">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("departamento") %> '></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Division">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("division") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle ForeColor="#000066" />
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
