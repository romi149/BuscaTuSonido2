<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeguimientoCompras.aspx.cs" Inherits="GUI.SeguimientoCompras" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Remitos">
        <h3>Seguimiento de Producto</h3>
        <br />
        
        <asp:Button runat="server" content="remitos" ID="btnVolver" CssClass="btn btn-warning btn-md" Text="Volver" 
               OnClick="btnVolver_Click" />
        <asp:Button ID="btnOpinion" Text="Valorar producto" runat="server" CssClass="btn btn-primary"
                                OnClick="btnOpinion_Click" Visible="false" />
        <br />
        <br />
        <asp:GridView ID="gvRemitos" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="NroRemito" HeaderText="Nro. Remito" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="NroPedido" HeaderText="Nro. Pedido" />
                <asp:BoundField DataField="NroFactura" HeaderText="Nro. Factura" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Notas" HeaderText="Notas" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>

 <style>

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
                      
    </style>
</asp:Content>
