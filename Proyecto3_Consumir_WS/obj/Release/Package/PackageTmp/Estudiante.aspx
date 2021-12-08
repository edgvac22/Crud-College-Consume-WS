<%@ Page Title="Estudiante" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiante.aspx.vb" Inherits="Proyecto3_Consumir_WS.Estudiante" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
<p>
    <asp:Label ID="Label1" runat="server" Text="Cédula:"></asp:Label>
    <asp:TextBox ID="txt_Cedula" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="txt_Nombre" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label>
    <asp:TextBox ID="txt_Apellido" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label4" runat="server" Text="Dirección:"></asp:Label>
    <asp:TextBox ID="txt_Direccion" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label5" runat="server" Text="Celular:"></asp:Label>
    <asp:TextBox ID="txt_Celular" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label6" runat="server" Text="Correo:"></asp:Label>
    <asp:TextBox ID="txt_Correo" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label7" runat="server" Text="Facultad:"></asp:Label>
    <asp:DropDownList ID="ddl_Facultad" runat="server" Height="27px" Width="150px" Enabled="False">
    </asp:DropDownList>
</p>
<p>
    <asp:Label ID="Label8" runat="server" Text="Carrera:"></asp:Label>
    <asp:DropDownList ID="ddl_Carrera" runat="server" Height="27px" Width="150px" Enabled="False">
    </asp:DropDownList>
</p>
<p>
    <asp:Label ID="Label9" runat="server" Text="Índice:"></asp:Label>
    <asp:TextBox ID="txt_Indice" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label10" runat="server" Text="Sexo:"></asp:Label>
    <asp:TextBox ID="txt_Sexo" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label11" runat="server" Text="Estatus:"></asp:Label>
    <asp:TextBox ID="txt_Estatus" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>
    <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" />
    <asp:Button ID="btn_Limpiar" runat="server" Text="Limpiar" />
    <asp:Button ID="btn_Listar" runat="server" Text="Listar" />
    <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" Enabled="False" />
    <asp:Button ID="btn_Modificar" runat="server" Text="Modificar" Enabled="False" />
    <asp:Button ID="btn_Eliminar" runat="server" Text="Eliminar" Enabled="False" />
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="gv_Listar" runat="server">
        </asp:GridView>
</p>

</asp:Content>
