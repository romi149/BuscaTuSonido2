<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABMC-Usuarios.aspx.cs" Inherits="GUI.ABMC_Usuarios" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ABMUser">
        <h3>Listado de Usuarios</h3>
        <div class="row">
            <div class="BuscadorDiv">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Agregar</button>
                <div class="input-group" id="BuscarControl">
                    <span class="input-group-addon">Buscar</span>
                    <asp:TextBox runat="server" type="text" CssClass="form-control"  />
                </div>
                <asp:Button runat="server" CssClass="btn btnBuscar" Text="Buscar" OnClick="Buscar_Click" ></asp:Button>
            </div>
        </div>
        <div id="demo" class="collapse">
            <div class="container">
                <div class="row " style="height: 100vh">
                    <h3>Nuevo Usuario</h3>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombre" />
                            </div>
                            <div class="form-group">
                                <label>Apellido</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="apellido" />
                            </div>
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="usuario" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="password" />
                            </div>
                            <div class="form-group">
                                <label>DNI</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="dni" />
                            </div>
                            <div class="form-group">
                                <label>Estado</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="estado" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevoUsuario" ID="Agregar" CssClass="btn btn-primary btn-lg" Text="Agregar" OnClick="sendAgregar_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevoUsuario" ID="cancelar" CssClass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Action">
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
