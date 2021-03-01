<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABM-UsuariosRol.aspx.cs" Inherits="GUI.ABM_UsuariosRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ABMUsuarioRol">
        <h3>Listado de Usuarios con sus Roles</h3>
        <div class="row">
            <div class="BuscadorDiv">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Agregar</button>
                <div class="input-group" id="BuscarControl">
                </div>
            </div>
        </div>
        <div id="demo" class="collapse">
            <div class="container">
                <div class="row " style="height: 30vh">
                    <h3>Asignar Rol a Usuario</h3>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Nombre Rol</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="nombreRol" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="usuario" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <asp:Button runat="server" content="nuevaPub" ID="Asignar" CssClass="btn btn-primary btn-md" Text="Agregar" OnClick="sendAgregar_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:Button runat="server" content="nuevaPub" ID="cancelar" CssClass="btn btn-warning btn-md" Text="Cancelar" OnClick="sendcancelar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <br />
        <asp:GridView ID="gvUsuarioRol" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="Id Usuario" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="IdRol" HeaderText="Id Rol" />
                <asp:BoundField DataField="NombreRol" HeaderText="Nombre Rol" />
                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnDelete" Text="Desasignar" runat="server" CssClass="btn btn-danger"
                                OnClick="btnDelete_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?')" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

 <style>
        .abmUsuarioRol {
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

