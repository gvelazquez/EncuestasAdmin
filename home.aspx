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
        
        var hotelValue = document.getElementById('txtHotel').value;
        var deptoValue = document.getElementById('txtDepartamento').value;
        var jefeValue = document.getElementById('txtJefe').value;
        
        if (hotelValue != '' && deptoValue != '' && jefeValue!=''){
            return true;
        }
        else{
            alert('Faltan campos por llenar');
            return false;
        }
        
    }
    

    function pageLoad()
    {
        $addHandler($get("btnHandler"), "click", ActionEvent);
         
        var callback = Function.createCallback(ActionEvent2, "An object");
         
        $addHandler($get("btnCallback"), "click", callback);
         
        var delegate = Function.createDelegate("An object", ActionEvent3);
         
        $addHandler($get("btnDelegate"), "click", delegate);
         
        $addHandlers($get("btnHandlers'), {click: ActionEvent4}, "An object");
    }
 
    function ActionEvent(event)
    {
        alert([this.id, event.type]);
    }
 
    function ActionEvent2(event, context)
    {
        alert([this.id, event.type, context]);
    }
 
    function ActionEvent3(event)
    {
        alert([this.id, event.type]);
    }
 
    function ActionEvent4(event)
    {
        alert([this.id, event.type]);
    }
 
</script>

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
                        <asp:DropDownList ID="ddlHotel" runat="server" Width="154px" AutoPostBack="True" ></asp:DropDownList>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td align="center" style="width:50%">
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px; height: 26px;">
                        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento:"></asp:Label>
                    </td>
                    <td align="center" style="width:50%; height: 26px;">
                        <asp:DropDownList ID="ddlDepartamento" runat="server" Width="154px" AutoPostBack="True" ></asp:DropDownList>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px; height: 28px;">
                        <asp:Label ID="lblPeriodo" runat="server" Text="Periodo"></asp:Label>
                    </td>
                    <td align="center" style="width:50%; height: 28px;">
                        <asp:TextBox ID="txtPeriodo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" style="width:191px">
                        <asp:Label ID="lblAnio" runat="server" Text="Año"></asp:Label>
                    </td>
                    <td align="center" style="width:50%">
                        <asp:TextBox ID="txtAnio" runat="server"></asp:TextBox>
                    </td>
                </tr>
                    <tr align="center" >
                        <td align="center" colspan="3">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClientClick="return ValidarCampos();" OnClick="btnAgregar_Click"/>
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
            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
            <input id="btnHandler" type="button" value="Handler" />
            <asp:ScriptManager ID="scriptManager" runat="server">
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>
