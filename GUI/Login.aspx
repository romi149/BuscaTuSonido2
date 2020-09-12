<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <div>
        <h2>Iniciar Sesión</h2>
    </div>--%>
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height:100vh">
            <div class="col-4">
                <div class="row">
                    <div class="col-md-4 order-md-1 mb-4">
                        <h2>Iniciar Sesión</h2>
                    <div class="card-body">
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="username"/>
                            </div>
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox runat="server" type="password" cssclass="form-control" id="password"/>
                            </div>
                            <asp:HyperLink id="hyperlink1" Text="Olvide mi contraseña" Target="_new" runat="server"/>
                            <br />
                            <br />
                            <asp:Button runat="server" content="login" id="sendlogin" cssclass="btn btn-primary btn-lg" Text="Ingresar" OnClick="sendlogin_Click"/>
                            <asp:Button runat="server" content="login" id="btnVolver" cssclass="btn btn-warning btn-lg" Text="Volver" OnClick="sendlogin_Click"/>
                        </div>
                      </div>
                    <div class="col-md-4 order-md-2">
                        <h2>Registrarse</h2>
                      <div class="card-body">
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="user"/>
                            </div>
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox runat="server" type="password" cssclass="form-control" id="pass"/>
                            </div>
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="nombre"/>
                            </div>
                            <div class="form-group">
                                <label>Apellido</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="apellido"/>
                            </div>
                            <div class="form-group">
                                <label>Dni</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="dni"/>
                            </div>
                        </div>
                        <br />
                        <asp:CheckBox runat="server" content="login" id="tyc" CssClass="" />
                        <a href="TermyCond.aspx">Términos y Condiciones</a>
                        <br />
                        <br />
                        <asp:Button runat="server" content="login" id="registrarse" cssclass="btn btn-primary btn-lg" Text="Registrarse" OnClick="sendlogin_Click"/>
                        <asp:Button runat="server" content="login" id="cancelar" cssclass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendlogin_Click"/>
                    </div>
                    <div class="col-md-4 order-md-3">
                        <h2> </h2>
                        <br />
                        <br />
                        <div class="card-body">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="email"/>
                            </div>
                            <div class="form-group">
                                <label>Teléfono</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="telefono"/>
                            </div>
                            <div class="form-group">
                                <label>Domicilio de Entrega</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="domEntrega"/>
                            </div>
                            <div class="form-group">
                                <label>Domicilio de Facturación</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="domFactura"/>
                            </div>
                        </div>
                    </div>
                  </div>
                </div>
            </div>
    </div>
</asp:Content>
