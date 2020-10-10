<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Editar-Proveedor.aspx.cs" Inherits="GUI.Editar_Proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="col-4">
                <div class="row">
                    <h2>Editar Proveedor</h2>
                    <div class="row">
                        <div class="col-md-4 order-md-1 mb-4">
                            <div class="form-group">
                                <label>Id</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="Id" />
                            </div>
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="username" />
                            </div>
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombre" />
                            </div>
                            <div class="form-group">
                                <label>Apellido</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="apellido" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="password" />
                            </div>
                            <div class="form-group">
                                <label>Dni</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="dni" />
                            </div>
                            <div class="form-group">
                                <label>Estado</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="estado" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Button runat="server" content="nuevoUsuario" ID="Editar" CssClass="btn btn-primary btn-lg" Text="Guardar" OnClick="sendEditar_Click" />
                        <asp:Button runat="server" content="nuevoUsuario" ID="cancelar" CssClass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>