<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ResponderConsultas.aspx.cs" Inherits="GUI.ResponderConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="col-4">
                <div class="row">
                    <h2>Responder Consultas de Clientes</h2>
                    <div class="row">
                        <div class="col-md-4 order-md-1 mb-4">
                            <div class="form-group">
                                <label>Id</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="id" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label>Nombre Producto</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombreProd" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label>Modelo</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="modelo" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="usuario" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Fecha Pregunta</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="fechaPregunta" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label>Pregunta</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="pregunta" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label>Respuesta</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="respuesta" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Button runat="server" content="nuevoUsuario" ID="Editar" CssClass="btn btn-primary btn-md" Text="Guardar" OnClick="sendEditar_Click" />
                        <asp:Button runat="server" content="nuevoUsuario" ID="cancelar" CssClass="btn btn-warning btn-md" Text="Cancelar" OnClick="sendcancelar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

