<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="NotasPedidoAFacturar.aspx.cs" Inherits="GUI.NotasPedidoAFacturar" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="NPSinFacturar">
        <h3>Notas de Pedido Pendientes de Facturación</h3>
        <br />
        <asp:GridView ID="gvNotasPedido" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="NroPedido" HeaderText="Nro Pedido" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="CodCliente" HeaderText="Cod Cliente" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="PrecioTotal" HeaderText="Importe Total" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="TipoOperacion" HeaderText="Tipo Operacion" />
                <asp:BoundField DataField="PeriodoAlquiler" HeaderText="Periodo Alquiler" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnFacturar" Text="Facturar" runat="server" CssClass="btn btn-primary"
                                OnClick="btnFacturar_Click" OnClientClick="return confirm('¿Esta seguro que desea generar la factura?')" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

 <style>
        .NPSinFacturar {
            width: 80vw;
            margin: auto;
            margin-top: 5vh !important;
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
         
        label {
            vertical-align: middle;
        }

    </style>
</asp:Content>
