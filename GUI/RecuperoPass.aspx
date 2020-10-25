<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperoPass.aspx.cs" Inherits="GUI.NuevoRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="container-login">
                <div class="col-4">
                    <div class="row">
                        <div>
                            <h2>Nueva contraseña</h2>
                            <div class="card-body">
                                <h4>Ingrese su nueva contraseña</h4>
                                <div class="form-group">
                                    <label>Contraseña</label>
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="password" />
                                </div>
                                <div class="form-group">
                                    <label>Repetir Contraseña</label>
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="repetpass" />
                                </div>
                                <br />
                                <br />
                                <asp:Button runat="server" content="login" ID="sendconfirmar" CssClass="btn btn-primary btn-lg" Text="Confirmar" OnClick="sendconfirmar_Click" />
                                <asp:Button runat="server" content="login" ID="btncancelar" CssClass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click" />
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
