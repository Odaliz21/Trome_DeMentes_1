<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmServicio.aspx.cs" Inherits="Transporte_Trome.frmServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">
        <h2>Mantenimiento de la tabla Servicios </h2>
   
       
        <div class="form-group">
            <label for="txtdescripcion" class="control-label">Descripcion</label>
            <asp:RequiredFieldValidator ID="rvDescrpccion" runat="server" ControlToValidate="txtdescripcion" ErrorMessage="obligatorio descripcion" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rvEDescripcion" runat="server" ControlToValidate="txtdescripcion" ErrorMessage="obligatorio descripcion" ValidationGroup="Eliminar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtdescripcion" CssClass="form-control"></asp:TextBox>
        </div>
       <div class="form-group">
    <label for="txtTarifaBase" class="control-label">Tarifa Base<asp:RequiredFieldValidator ID="RVtarifa" runat="server" ControlToValidate="txtTarifaBase" ErrorMessage="obligatorio Tarifa Base" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
           </label>
    &nbsp;<asp:TextBox runat="server" ID="txtTarifaBase" CssClass="form-control"></asp:TextBox>
</div>
     
      
        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este cliente?');" ValidationGroup="Eliminar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Actualizar"/>
            <asp:ValidationSummary ID="vsAgregar" runat="server" ValidationGroup="Agregar" />
            <asp:ValidationSummary ID="vsEliminar" runat="server" ValidationGroup="Eliminar" />
            <asp:ValidationSummary ID="vsBuscar" runat="server" ValidationGroup="Buscar" />
            <br />
        </div>
        <div class="form-group">
            <asp:RequiredFieldValidator ID="rvBuscar" runat="server" ControlToValidate="txtBuscar" ErrorMessage="obligatorio descripccion" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Servicios" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        <div class="form-group">
            <asp:GridView runat="server" ID="gvServicio" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvServicio_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>
    </div>
</asp:Content>
