<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="GUI.MiCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="ContenedorMiCuenta ">
                <div class="centrarFormulario">
                     <h2>Mis Datos</h2>
                     <br />
                <div class="row">
                    <div class="col-md-6" >
                        <div class="card-body">
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
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="email" />
                            </div>
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="password" Visible="false" />
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Dni</label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="dni" />
                        </div>
                        <div class="form-group">
                            <label>Teléfono</label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="telefono" />
                        </div>
                        <div class="form-group">
                            <label>Domicilio de Entrega</label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="domEntrega" />
                        </div>
                        <div class="form-group">
                            <label>Domicilio de Facturación</label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="domFactura" />
                        </div>
                        <div class="form-group">
                                <label>Repetir Contraseña</label>
                                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="repeatPass" Visible="false" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="codCliente" Visible="false" />
                        </div>
                    </div>
                </div>
                  <br />
                    <div  class="terminosBtn">
                        <div>
                          <asp:Button runat="server" content="editarDatos" ID="editar" CssClass="btn btn-primary btn-md" Text="Editar Datos" OnClick="sendeditar_Click"
                              OnClientClick="return confirm('¿Esta seguro que desea editar los datos?')" />
                        </div>
                        <div>
                            <asp:Button runat="server" content="editarDatos" ID="cancelar" CssClass="btn btn-danger btn-md" Text="Cancelar" OnClick="sendcancelar_Click" />
                        </div>
                        <div>
                            <asp:Button runat="server" content="editarDatos" ID="pass" CssClass="btn btn-primary btn-md" Text="Modificar Contraseña" OnClick="sendcambiarPass_Click" />
                        </div>
                        <div>
                            <asp:Button runat="server" content="editarDatos" ID="confirmarPass" CssClass="btn btn-warning btn-md" Text="Confirmar" Visible="false" OnClick="confirmarCambioPass_Click"
                                OnClientClick="return confirm('¿Esta seguro que desea cambiar la contraseña?')" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <style>
        .ContenedorMiCuenta{
            width:80%;
            margin:auto;
            background-color:hsla(218, 74%, 60%, 0.171);
            border-radius:15px;
       
        }
        .centrarFormulario{
            width:80%;
            margin:auto;       
            padding:3%;        
            margin-top:2% !important;
           
        }
        h2{
            text-align:center;
            font-weight:bold;
        }

        .terminos{
            display:flex;
            justify-content:left;
        }
        .terminosBtn{
            display:flex;
            justify-content:space-around;
        }
        .botones{
            margin-left:20px;
         }

        h2 {
            text-align: center;
            font-weight: bold;
        }
       
    </style>

</asp:Content>
