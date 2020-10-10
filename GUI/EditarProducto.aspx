<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="GUI.EditarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height:100vh">
            <div class="col-4">
                <div class="row">
                     <div class="col-md-4 order-md-1 mb-4">
                        <h2>Editar Producto</h2>
                        <div class="card-body">
                             <div class="form-group">
                                 <label>Id</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="Id"/>
                            </div>
                            <div class="form-group">
                                <label>UPC</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="upc"/>
                            </div>
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox runat="server" type="password" cssclass="form-control" id="nombre"/>
                            </div>
                            <div class="form-group">
                                 <label>Categoria</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="categoria"/>
                            </div>
                            <div class="form-group">
                                 <label>Tipo Instrumento</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="tipoInst"/>
                            </div>
                            <div class="form-group">
                                 <label>Id Marca</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="idMarca"/>
                            </div>
                            <div class="form-group">
                                 <label>Modelo</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="modelo"/>
                            </div>
                            <div class="form-group">
                                 <label>Cod Proveedor</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="codProv"/>
                            </div>
                            <div class="form-group">
                                 <label>Id Proveedor</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="idProv"/>
                            </div>
                            <div class="form-group">
                                 <label>Color</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="color"/>
                            </div>
                             <div class="form-group">
                                 <label>Estado</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="estado"/>
                            </div>
                            <div class="form-group">
                                 <label>Precio</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="precio"/>
                            </div>
                            <div class="form-group">
                                 <label>Descripcion</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="descripcion"/>
                            </div>
                           
                            <asp:Button runat="server" content="nuevoUsuario" id="Editar" cssclass="btn btn-primary btn-lg" Text="Guardar" OnClick="sendEditar_Click"/>
                            <asp:Button runat="server" content="nuevoUsuario" id="cancelar" cssclass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click"/>
                        </div>
                    </div>
              </div>
        </div>
    </div>
</div>
</asp:Content>

   