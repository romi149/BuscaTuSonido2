<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="EditarEncuesta.aspx.cs" Inherits="GUI.EditarEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="col-4">
                <div class="row">
                    <h2>Editar Encuesta</h2>
                    <div class="row">
                        <div class="col-md-4 order-md-1 mb-4">
                            <div class="form-group">
                                <label>Id</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="id" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label>Pregunta</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombrePregunta" />
                            </div>
                            <div class="form-group">
                                <label>Fecha Inicio</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaInicio" />
                            </div>
                            <div class="form-group">
                                <label>Fecha Fin</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaFin" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Respuesta 1</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="respuesta1" />
                            </div>
                            <div class="form-group">
                                <label>Respuesta 2</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="respuesta2" />
                            </div>
                            <div class="form-group">
                                <label>Nombre Imagen 1</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="img1" />
                            </div>
                            <div class="form-group">
                                <label>Nombre Imagen 2</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="img2" />
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
