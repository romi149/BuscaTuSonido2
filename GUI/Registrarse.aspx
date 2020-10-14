<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="GUI.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script src='https://www.google.com/recaptcha/api.js'></script>

<div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="ContenedorRegistrase ">
                <div class="centrarFormulario">
                     <h2>Nueva Cuenta</h2>
                <div class="row">
                    <div class="col-md-6" >
                        <div class="card-body">
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="username" />
                            </div>
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox runat="server" type="password" CssClass="form-control" ID="password" />
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

                        <div class="g-recaptcha" data-sitekey="6LeXoNYZAAAAAPt4XnAqGRNOc50awLezbacv0X6Q"></div>

                    </div>
                </div>

                <div class="row">
                    <div class="terminos">
                         <asp:CheckBox runat="server" content="registrarse" ID="tyc" CssClass="" />
                         <a href="TermyCond.aspx">Acepto los Términos y Condiciones</a>
                    </div>
                  <br />
                    <div  class="terminosBtn">
                        <div>
                          <asp:Button runat="server" content="registrarse" ID="registrarse" CssClass="btn btn-primary btn-lg" Text="Registrarse" OnClick="sendregistrarse_Click" />
                        </div>
                        <div>
                            <asp:Button runat="server" content="registrarse" ID="cancelar" CssClass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click" />
                        </div>
                    </div>

                </div>
                </div>
               
            </div>
        </div>
    </div>
    <style>
        .ContenedorRegistrase{
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
       
    </style>
    <script src='https://www.google.com/recaptcha/api.js?hl=es'></script>
</asp:Content>
