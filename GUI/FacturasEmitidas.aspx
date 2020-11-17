<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="FacturasEmitidas.aspx.cs" Inherits="GUI.FacturasEmitidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="FacturasEmitidas">
        <h3>Facturas Emitidas</h3>
        
        <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="NroFactura" HeaderText="Nro Factura" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioTotal" HeaderText="Importe Total" />
                <asp:BoundField DataField="CodCliente" HeaderText="Cod Cliente" />
                <asp:BoundField DataField="NroPedido" HeaderText="NroPedido" />
                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnAnular" Text="Anular" runat="server" CssClass="btn btn-danger"
                                OnClick="btnAnular_Click" OnClientClick="return confirm('¿Esta seguro que desea anular la factura?')" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

 <style>
        .FacturasEmitidas {
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
                

        label {
            vertical-align: middle;
        }

    </style>
</asp:Content>

