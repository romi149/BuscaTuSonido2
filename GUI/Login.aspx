<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <%-- <div>
        <h2>Iniciar Sesión</h2>
    </div>--%>
    <div class="container">
        <div class="row">
            <div class="container-login">
                <div class="col-4">
                    <div class="row">
                        <div>
                            <h2>Iniciar Sesión</h2>
                            <div class="card-body">
                                <div class="form-group">
                                    <label>Usuario</label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="username" />
                                </div>
                                <div class="form-group">
                                    <label>Contraseña</label>
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="password" />
                                </div>
                                <a href="RecuperarPass.aspx">Olvide mi contraseña</a> <a href="Registrarse.aspx">Registrarse</a>
                                <br />
                                <br />
                                <asp:Button runat="server" content="login" ID="sendlogin" CssClass="btn btn-primary btn-lg" Text="Ingresar" OnClick="sendlogin_Click" />
                                <asp:Button runat="server" content="login" ID="btnVolver" CssClass="btn btn-warning btn-lg" Text="Volver" OnClick="sendvolver_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <style>
        .container-login{
            width:60%;
            margin:auto;
            display:flex;
            justify-content:center;
            align-items:center;
            background-color:hsl(218, 74%, 60%, 0.171);
            border-radius:15px;
            padding:5%;
            margin-top:5%;
        }
    </style>
</asp:Content>
