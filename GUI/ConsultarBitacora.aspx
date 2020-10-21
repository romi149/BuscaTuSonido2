<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ConsultarBitacora.aspx.cs" Inherits="GUI.ConsultarBitacora" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ABMUser">
        <h3>Listado de Registros en Bitácora</h3>
        <br />
        <div class="row">
            <div class="BuscadorDiv">
                <div class="input-group" id="BuscarControl">
                    <table>
                        <tr>
                            <td>
                                <label>Tipo de Evento</label>
                                <asp:TextBox ID="tipoEvento" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <label>Entidad Involucrada</label>
                                <asp:TextBox ID="entidad" runat="server" type="text" CssClass="form-control"></asp:TextBox>
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
        
        <asp:GridView ID="gvBitacora" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="IdBitacora" HeaderText="Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="TipoEvento" HeaderText="Tipo de Evento" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="EntidadInvolucrada" HeaderText="Entidad Involucrada" />
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
