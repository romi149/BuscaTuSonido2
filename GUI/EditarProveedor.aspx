<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="EditarProveedor.aspx.cs" Inherits="GUI.Editar_Proveedor" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="col-4">
                <div class="row">
                    <h2>Editar Proveedor</h2>
                    <div class="row">
                        <div class="col-md-4 order-md-1 mb-4">
                            <div class="form-group">
                                <label>Id</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="idProv" />
                            </div>
                            <div class="form-group">
                                <label>Cod. Proveedor</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="codProv" />
                            </div>
                            <div class="form-group">
                                <label>Nombre Empresa</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombreEmpresa" />
                            </div>
                            <div class="form-group">
                                <label>Razon Social</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="razonSocial" />
                            </div>
                            <div class="form-group">
                                <label>Domicilio</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="domicilio" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="email" />
                            </div>
                            <div class="form-group">
                                <label>Telefono</label>
                                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="telefono" />
                            </div>
                            <div class="form-group">
                                <label>Descripcion</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="descrip" />
                            </div>
                            <div class="form-group">
                                <label>CUIT</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="cuit" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Button runat="server" content="nuevoProveedor" ID="Editar" CssClass="btn btn-primary btn-lg" Text="Guardar" OnClick="sendEditar_Click" />
                        <asp:Button runat="server" content="nuevoProveedor" ID="cancelar" CssClass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>