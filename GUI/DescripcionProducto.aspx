<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DescripcionProducto.aspx.cs" Inherits="GUI.DescripcionProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="containerProducto">
            <div class="row">
                <div class="col-lg-6 col-md-6">
                    <img class="imgProducto" src="https://http2.mlstatic.com/D_NQ_NP_2X_706800-MLA42842125254_072020-F.webp" alt="">
                </div>
                <div class="col-lg-4 col-md-6">
                    <h1><asp:Panel runat="server" ID="TxtNombre"></asp:Panel></h1>
                    <h2><asp:Panel runat="server" ID="TxtModelo"></asp:Panel></h2>
                    <h3><asp:Panel runat="server" ID="TxtPrecio"></asp:Panel></h3>
                    <p><asp:Panel runat="server" ID="TxtDescripcion"></asp:Panel></p>
                    <a href="#" class="btn btn-success btn-lg">Comprar</a>
                </div>
            </div>
        </div>
    </div>

    <style>
        .imgProducto{
            width:100%;
            height:100%;
        }
    </style>
</asp:Content>
