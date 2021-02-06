<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ReporteVentas.aspx.cs" Inherits="GUI.ReporteVentas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ReporteVentas">
        <h3>Listado de Ventas</h3>
        <br />
        <div class="row">
            <div class="BuscadorDiv">
                <div class="input-group" id="BuscarControl">
                    <table>
                        <tr>
                            <td>
                                <label>Nro Factura</label>
                                <asp:TextBox ID="nroFactura" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <label>Usuario</label>
                                <asp:TextBox ID="usuario" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <label>Fecha desde</label>
                                <asp:TextBox ID="desde" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <label>Fecha hasta</label>
                                <asp:TextBox ID="hasta" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="Buscar_Click" ></asp:Button>
            </div>
        </div>
        <br />
        
        <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="NroFactura" HeaderText="Nro Factura" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Cliente" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido Cliente" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Factura" />
                <asp:BoundField DataField="PrecioTotal" HeaderText="Total Factura" />
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

        #BuscarControl{
            margin-left:20px;
        }

        .BtnBuscar{
            background-color:#0476C1;
        }
    </style>
</asp:Content>

