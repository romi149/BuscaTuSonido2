<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Envios.aspx.cs" Inherits="GUI.Envios" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script>
    function abrir(url) {
        open(url, '', 'top=100,left=300,width=450,height=500');
    }
</script>

    <div class="RemitosEmitidos">
        <h3>Remitos Emitidos</h3>
        <br />
        <asp:GridView ID="gvRemitos" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="NroRemito" HeaderText="N° Remito" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="NroPedido" HeaderText="N° Pedido" />
                <asp:BoundField DataField="NroFactura" HeaderText="N° Factura" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Notas" HeaderText="Notas" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnEditar" Text="Editar" runat="server" CssClass="btn btn-primary"
                                OnClick="editar_Click" OnClientClick="javascript:abrir('EditarRemito.aspx')"/>
                            <asp:Button ID="btnAnular" Text="Anular" runat="server" CssClass="btn btn-danger"
                                OnClick="anular_Click" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>



    <style>
        h4 {
            text-align: center;
            font-weight: bold;
        }

        .RemitosEmitidos {
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
                

        label {
            vertical-align: middle;
        }

    </style>
</asp:Content>
