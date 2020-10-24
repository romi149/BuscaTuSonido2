<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstrumentosElectronicos.aspx.cs" Inherits="GUI.InstrumentosElectronicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container">

        <div class="row">

            <div class="col-lg-3">
                <img id="logo" class="imglogo" src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt="">
                <%--<h1 class="my-4">BuscaTuSonido</h1>--%>
                <div class="list-group">
                    <a href="/InstrumentosCuerdas" class="list-group-item">Instrumentos de Cuerda</a>
                    <a href="/InstrumentosViento" class="list-group-item">Instrumentos de Viento</a>
                    <a href="/InstrumentosPercusion" class="list-group-item">Instrumentos de Percusión</a>
                    <a href="InstrumentosElectronicos" class="list-group-item">Instrumentos Electrónicos</a>
                    <a href="#" class="list-group-item">Instrumentos en Alquiler</a>
                </div>

            </div>
            <div class="col-lg-9">

                <asp:Panel runat="server" ID="contenedor">
                </asp:Panel>

            </div>
        </div>

    </div>

    <style>
        #logo {
            width: 20vw;
            height: 25vh;
        }
    </style>

</asp:Content>
