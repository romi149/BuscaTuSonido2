<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-lg-3">
                <img id="logo" class="imglogo" src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt="">
                <%--<h1 class="my-4">BuscaTuSonido</h1>--%>
                <%--<div class="list-group">--%>

                    <asp:Panel runat="server" ID="contenedorMenu">
                    </asp:Panel>

                    <%--<a href="/InstrumentosCuerdas" class="list-group-item" >Instrumentos de Cuerda</a>
                    <a href="/InstrumentosViento" class="list-group-item" >Instrumentos de Viento</a>
                    <a href="/InstrumentosPercusion" class="list-group-item" >Instrumentos de Percusión</a>
                    <a href="InstrumentosElectronicos" class="list-group-item" >Instrumentos Electrónicos</a>
                    <a href="#" class="list-group-item" id="5">Instrumentos en Alquiler</a>--%>
                <%--</div>--%>

            </div>
            <div class="col-lg-9">

                <asp:Panel runat="server" ID="contenedor">
                </asp:Panel>

            </div>
        </div>

    </div>
    <br />
    <br />

    <footer>
        <hr />
        <div class="container-footer">
            <div class="row justify-content-left align-items-center">
                <div class="contenedor-suscripcion">

                    <div class="row">
                        <div class="body-content">
                            <div class="col-lg-6">
                            <div class="title">
                                <h4 style="color: white; font-weight: 400;">Contáctenos</h4>
                            </div>
                                <h4>Tel.: 116045-2099
                                </h4>
                                <h4>Email: info@buscatusonido.com
                                </h4>

                                <a href="TermyCond">Términos y Condiciones</a>
                            </div>

                            <div class="col-lg-6">
                                <h4 style="color: white">Suscribirse al Newsletter</h4>
                                <div class="form-group">
                                    <label style="font-weight: 200">Nombre</label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombre" />
                                </div>
                                <div class="form-group">
                                    <label style="font-weight: 200">Email</label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="email" />
                                </div>
                                <div>
                                    <asp:Button runat="server" content="suscribirse" ID="suscribirse" CssClass="btn btn-primary btn-md" Text="Enviar" OnClick="sendSuscribirse_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <!-- /.container -->

    <style>
        img {
            width: 15vw;
            height: 200px;
        }

        #logo{
            width: 20vw;
            height: 25vh;
        }

        footer{
            width:100vw !important
        }
        @media (max-width: 700px) {
            img {
                width: 50vw;
            }

            .card {
                width: 50vw;
                margin: auto;
            }
        }

        .container-footer {
            background-color: #222222;
            padding:2%;
            /*margin:auto;*/
        }

        .contenedor-suscripcion {
            width: 80%;
            margin: auto;
        }

        .body-content {
            color: #a6a6a6;
        }
    </style>

</asp:Content>
