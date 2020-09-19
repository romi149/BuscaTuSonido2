<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABMC-Productos.aspx.cs" Inherits="GUI.ABMC_Productos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="AbmProductos">
        <a href="AgregarProducto.aspx" class="btn btn-primary btn lg">Agregar</a>
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="Upc" HeaderText="UPC" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="TipoInstrumento" HeaderText="Tipo de Instrumento" />
                <asp:BoundField DataField="IdMarca" HeaderText="Id Marca" />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                <asp:BoundField DataField="CodProveedor" HeaderText="Cod Proveedor" />
                <asp:BoundField DataField="IdProveedor" HeaderText="Id Proveedor" />
                <asp:BoundField DataField="Color" HeaderText="Color" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" Text="Editar" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="btnDelete" Text="Eliminar" runat="server" CssClass="btn btn-danger"
                            OnClick="btnDelete_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?')" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <style>
        .abmProductos{
            width:80vw;
            margin:auto;
            margin-top:5vh;
        }
    </style>

</asp:Content>

