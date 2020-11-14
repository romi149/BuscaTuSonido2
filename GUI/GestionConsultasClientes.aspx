<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="GestionConsultasClientes.aspx.cs" Inherits="GUI.GestionConsultasClientes" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="GestionConsultas">
        <h3>Listado de Consultas de Clientes</h3>
        <div class="row">
        </div>
                        
        <asp:GridView ID="gvConsultas" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="NombreProducto" HeaderText="Nombre Producto" />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" />
                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnEdit" Text="Responder" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-primary btn-md" />
                            <asp:Button ID="btnDelete" Text="Eliminar" runat="server" CssClass="btn btn-danger btn-md"
                                OnClick="btnDelete_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?')" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

 <style>
        .abmProductos {
            width: 80vw;
            margin: auto;
            margin-top: 15vh !important;
        }

        .BtnGrid {
            display: flex;
            justify-content: space-between;
        }

        .tamanoHeader {
            width: 200px;
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 8px;
            line-height: 1.42857143;
            vertical-align: middle;
            border-top: 1px solid #ddd;
        }

        .desc {
            width: 500px;
        }
         .BuscadorDiv{
             margin-bottom:10px;
         }
        .BuscadorDiv,
        .BuscadorDiv .controlBuscar {
            display: flex;
            align-content: center;
            vertical-align: middle;

        }


        label {
            vertical-align: middle;
        }

        #BuscarControl{
            margin-left:20px;
        }

        .BtnBuscar{
            background-color:#eeeeee;
        }
    </style>
</asp:Content>

