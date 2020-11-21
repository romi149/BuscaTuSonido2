<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="GUI.MisCompras" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="MisCompras">
        <h3>Listado de Compras Realizadas</h3>
        <br />
        <div class="row">
            <div class="BuscadorDiv">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Contactar al Vendedor</button>
            </div>
        </div>
        <div id="demo" class="collapse">
            <asp:Panel runat="server" id="peopleComment">
            </asp:Panel>

            <div class="container">
                <div class="row " style="height: 100vh">
                    <h4></h4>
                    <div id="PreguntasBox">
                        <asp:TextBox ID="pregunta" runat="server" type="text" TextMode="MultiLine" Width="" CssClass="form-control"></asp:TextBox>
                        <asp:Button runat="server" content="pregunta" ID="btnPregunta" CssClass="btn btn-primary" Text="Preguntar" OnClick="sendPreguntar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="NroFactura" HeaderText="Nro Factura" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioTotal" HeaderText="Importe Total" />
                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnTracking" Text="Seguir Envío" runat="server" OnClick="btnTracking_Click" CssClass="btn btn-primary" />
                            <%--<asp:Button ID="btnDelete" Text="Eliminar" runat="server" CssClass="btn btn-danger"
                                OnClick="btnDelete_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?')" />--%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

 <style>
        .MisCompras {
            width: 80vw;
            margin: auto;
            margin-top: 3vh !important;
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

         #PreguntasBox {
            display: flex;
        }

        #pregunta {
            width: 30vw !important;
            max-width: 30vw !important;
        }

    </style>
</asp:Content>
