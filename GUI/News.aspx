<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="GUI.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
        <div class="containerProducto">
            <div class="row">
                <div class="col-lg-6 col-md-6">
                    <h1><asp:Panel runat="server" ID="TxtTitulo1"></asp:Panel></h1>
                    <h2><asp:Panel runat="server" ID="TxtTitulo2"></asp:Panel></h2>
                    <p><asp:Panel runat="server" ID="TxtTexto1"></asp:Panel></p>
                </div>
                <div class="col-lg-4 col-md-6">
                     <asp:Image CssClass="imgNoticia" runat="server" ID="ImagenNoticia" />
                    <asp:Panel runat="server" ID="contenedorImagen">
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

    <style>
        .imgNoticia {
            width: 40vw;
            height: 50vh;
            margin-top: 20px;
        }

        .row {
            margin-top: 20px;
            margin-bottom: 30px
        }
    </style>
</asp:Content>
