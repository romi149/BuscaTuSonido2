<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABMC-Marcas.aspx.cs" Inherits="GUI.ABMC_Marcas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ABMMarca">
        <h3>Listado de Marcas</h3>
        <div class="row">
            <div class="BuscadorDiv">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Agregar</button>
                <%--<div class="input-group" id="BuscarControl">
                </div>
                <asp:Button runat="server" CssClass="btn btn-primary btn-md" Text="Buscar" OnClick="Buscar_Click" ></asp:Button>--%>
            </div>
        </div>
        <div id="demo" class="collapse">
            <div class="container">
                <div class="row " style="height: 100vh">
                    <h3>Nueva Marca</h3>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombre" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Descripcion</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="descripcion" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevaMarca" ID="Agregar" CssClass="btn btn-primary btn-md" Text="Agregar" OnClick="sendAgregar_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevaMarca" ID="cancelar" CssClass="btn btn-warning btn-md" Text="Cancelar" OnClick="sendcancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <asp:GridView ID="gvMarca" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="IdMarca" HeaderText="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnEdit" Text="Editar" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="btnDelete" Text="Eliminar" runat="server" CssClass="btn btn-danger"
                                OnClick="btnDelete_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?')" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

 <style>
        .abmMarca {
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
