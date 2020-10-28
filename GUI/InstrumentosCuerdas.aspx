<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstrumentosCuerdas.aspx.cs" Inherits="GUI.InstrumentosCuerdas" %>

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
                    <br />
                    <br />
                    <%--<asp:Button runat="server" CssClass="btn btn-primary btn-md" Text="Comparar productos" OnClick="Comparar_Click" ></asp:Button>--%>
                  
                    <div class="compareBox-content">
                        <div class="compareBox gb--appear ">
                            <div class="compareBox-header">
                                <p class="compareBox-tittle">Comparador de productos <strong><span class="gb-product-counter">0</span>/4</strong></p>
                                <a class="gb-icon-simple-thin-arrow-top"></a>
                            </div>
                            <div class="compareBox-body">
                                <ul class="compare-item-list" id="compare_list">
                                    <li class="grey-object" id="object-1"></li>
                                    <li class="grey-object" id="object-2"></li>
                                    <li class="grey-object" id="object-3"></li>
                                    <li class="grey-object" id="object-4"></li>
                                </ul>
                                <div class="compareBox-actions">
                                    <asp:Button runat="server" id="compare_link" Cssclass="btn btn-primary btn-md" Text="Comparar" Onclick="Comparar_Click" ></asp:Button>
                                    <asp:Button runat="server" id="eliminar" Cssclass="btn btn-warning btn-md" Text="Eliminar todos" Onclick="Eliminar_Click" ></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
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
