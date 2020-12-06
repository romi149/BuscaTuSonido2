<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValoracionProducto.aspx.cs" Inherits="GUI.ValoracionProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="container-valoracion">
                <div class="col-6">
                    <div class="row">
                        <div>
                            <h2>Contanos tu opinión sobre nuestros productos</h2>
                            <br />
                            <div class="card-body">
                                <h4>¿Qué te pareció el producto?</h4>
                                <div class="form-group">
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" TextMode="MultiLine" ID="comentario" />
                                </div>
                                <br />
                                <h4>¿Qué puntaje le darías?</h4>
                                <div>
                                    <asp:RadioButton runat="server" ID="CheckPunt1" GroupName="Valoracion" />
                                    <label id="lbl1">Excelente</label>
                                </div>
                                <div>
                                    <asp:RadioButton runat="server" ID="CheckPunt2" GroupName="Valoracion" />
                                    <label id="lbl2">Muy bueno</label>
                                </div>
                                <div>
                                    <asp:RadioButton runat="server" ID="CheckPunt3" GroupName="Valoracion" />
                                    <label id="lbl3">Bueno</label>
                                </div>
                                <div>
                                    <asp:RadioButton runat="server" ID="CheckPunt4" GroupName="Valoracion" />
                                    <label id="lbl4">Malo</label>
                                </div>
                                <div>
                                    <asp:RadioButton runat="server" ID="CheckPunt5" GroupName="Valoracion" />
                                    <label id="lbl5">Muy malo</label>
                                </div>
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

    <style>
        .container-valoracion{
            width:60%;
            margin:auto;
            display:flex;
            justify-content:center;
            align-items:center;
            border-radius:15px;
            padding:2%;
        }

    </style>
</asp:Content>

