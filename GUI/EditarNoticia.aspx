<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="EditarNoticia.aspx.cs" Inherits="GUI.EditarNoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="col-4">
                <div class="row">
                    <h2>Editar Noticia</h2>
                    <div class="row">
                        <div class="col-md-4 order-md-1 mb-4">
                            <div class="form-group">
                                <label>Id</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="id" ReadOnly="true" />
                            </div>
                            <div class="form-group">
                                <label>Titulo1</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="titulo1" />
                            </div>
                            <div class="form-group">
                                <label>Texto1</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="texto1" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Titulo2</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="titulo2" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Fecha Publicación</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaPub" />
                            </div>
                            <div class="form-group">
                                <label>Fecha Fin</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaFin" />
                            </div>
                         </div>
                        </div>
                      </div>
                      <br />
                    <div>
                        <asp:Button runat="server" content="nuevoUsuario" ID="Editar" CssClass="btn btn-primary btn-lg" Text="Guardar" OnClick="sendEditar_Click" />
                        <asp:Button runat="server" content="nuevoUsuario" ID="cancelar" CssClass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click" />
                    </div>
            </div>
    </div>
</asp:Content>
