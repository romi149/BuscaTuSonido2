<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Remitos.aspx.cs" Inherits="GUI.Remitos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Remitos">
        <h3>Listado de Remitos</h3>
        <br />
        <div class="row">
            <div class="BuscadorDiv">
                <div class="input-group" id="BuscarControl">
                    <table>
                        <tr>
                            <td>
                                <label>Nro. Pedido</label>
                            </td>
                            <td>
                                <asp:TextBox ID="nroPedido" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <label>Nro. Factura</label>
                            </td>
                            <td>
                                <asp:TextBox ID="nroFactura" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <label>Fecha</label>
                            </td>
                            <td>
                                <asp:TextBox ID="fecha" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <label>Estado</label>
                            </td>
                            <td>
                                <asp:TextBox ID="estado" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="Buscar_Click" ></asp:Button>
            </div>
        </div>
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
      /*  .abmProductos {
            width: 80vw;
            margin: auto;
            margin-top: 15vh !important;
        }*/

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


/*        label {
            vertical-align: middle;
        }*/

        #BuscarControl{
            margin-left:20px;
        }

        .BtnBuscar{
            background-color:#0476C1;
        }
    </style>
</asp:Content>
