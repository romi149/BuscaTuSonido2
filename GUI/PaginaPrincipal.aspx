<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="GUI.PaginaPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html lang="en">

    <head>

        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">

        <title>BUSCA TU SONIDO</title>

        <!-- Bootstrap core CSS -->
        <%--<link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">--%>

        <!-- Custom fonts for this template -->
        <link href="https://fonts.googleapis.com/css?family=Catamaran:100,200,300,400,500,600,700,800,900" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i" rel="stylesheet">

        <!-- Custom styles for this template -->
        <link href="css/one-page-wonder.min.css" rel="stylesheet">
        <link rel="stylesheet" href="./css/estilo.css">
    </head>

    <body>
        <header>
            <section class="textos-header">
                <h1>Busca Tu Sonido</h1>
                <br />
                <%--<h2>La Excelencia en Sonido</h2>--%>
            </section>
            <div class="wave" style="height: 150px; overflow: hidden;">
                <%--<h1 class="masthead-heading mb-0" style="color: brown">BUSCA TU SONIDO</h1>--%>
                <svg viewBox="0 0 500 150" preserveAspectRatio="none" style="height: 100%; width: 100%;">
                    <path d="M0.00,49.99 C150.00,150.00 349.21,-49.99 500.00,49.99 L500.00,150.00 L0.00,150.00 Z"
                        style="stroke: none; fill: rgb(255, 255, 255);">
                    </path>
                </svg>
            </div>
        </header>
        <%--<header class="masthead text-center text-white">
            <div class="masthead-content">
                <div class="container">
                    <h1 class="masthead-heading mb-0">BUSCA TU SONIDO</h1>
                    <h2 class="masthead-subheading mb-0"></h2>
                    <a href="/Default" class="btn btn-primary btn-xl rounded-pill mt-5">Nuestros productos</a>
                </div>
            </div>
        </header>--%>

        <section class="portafolio">
            <div class="contenedor">
                <h2 class="titulo">Nuestros Instrumentos</h2>
                <div class="galeria-port">
                    <div class="imagen-port">
                        <img src="./img/Guitarra7.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>
                    <div class="imagen-port">
                        <img src="./img/Guitarra8.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="" srcset="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>
                    <div class="imagen-port">
                        <img src="./img/Violin.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="" srcset="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>
                    <div class="imagen-port">
                        <img src="./img/bombos.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="" srcset="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>
                    <div class="imagen-port">
                        <img src="./img/Guitarra1.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="" srcset="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>
                    <div class="imagen-port">
                        <img src="./img/Guitarra4.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="" srcset="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>
                    <div class="imagen-port">
                        <img src="./img/Guitarra2.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="" srcset="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>
                    <div class="imagen-port">
                        <img src="./img/pexels.png" alt="">
                        <div class="hover-galeria">
                            <img src="./img/apuntar.svg" alt="" srcset="">
                            <%--<p>Nuestro Trabajo</p>--%>
                            <a class="portfolio" runat="server" href="~/Default">Productos</a>
                        </div>
                    </div>

                </div>

            </div>
        </section>

        <section>
            <div class="container" id="EncuestaSemana"
                 style="display: flex; flex-direction: column; align-items: center; width: 80%;">
            </div>
        </section>
        <br />
        <section>
            <div>
                <asp:AdRotator ID="pub" AdvertisementFile="~/Ads.xml"
                    BorderColor="Black"
                    BorderWith="1"
                    runat="server" />
            </div>
        </section>

        <footer>
            <hr />
            <div class="container-footer">
                <div class="row justify-content-left align-items-center">
                    <div class="contenedor-suscripcion">

                        <div class="row">
                            <div class="body-content-footer">
                                <div class="col-lg-3">
                                    <div class="title">
                                        <h4 style="color: white; font-weight: 400;">Contáctenos</h4>
                                    </div>
                                    <h5>Tel.: 116045-2099
                                    </h5>
                                    <h5>Email: info@buscatusonido.com
                                    </h5>

                                    <a href="TermyCond">Términos y Condiciones</a>
                                </div>

                                <div class="col-lg-6">
                                    <asp:Button runat="server" type="button" ID="suscrib" class="btn btn-info" data-toggle="collapse" data-target="#demo" OnClick="opcionSuscribirse_Click" Text="Suscribirse" />
                                    <asp:CheckBox ID="CheckOfertas" runat="server" AutoPostBack="true" Text="Ofertas" OnCheckedChanged="CheckOfertas_Clicked" Visible="false" />
                                    <asp:CheckBox ID="CheckEventos" runat="server" AutoPostBack="true" Text="Eventos" OnCheckedChanged="CheckEventos_Clicked" Visible="false" />
                                    <asp:CheckBox ID="CheckNoticias" runat="server" AutoPostBack="true" Text="Noticias" OnCheckedChanged="CheckNoticias_Clicked" Visible="false" />

                                    <div class="form-group">
                                        <label style="font-weight: 200">Email</label>
                                        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="email" Visible="false" />
                                    </div>
                                    <div>
                                        <asp:Button runat="server" content="suscribirse" ID="suscribirse" CssClass="btn btn-primary btn-md" Text="Confirmar" OnClick="sendSuscribirse_Click" Visible="false" />
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <asp:Button runat="server" type="button" ID="desuscrib" class="btn btn-info" data-toggle="collapse" data-target="#demo" OnClick="opcionDesuscribirse_Click" Text="Cancelar Suscripción" />
                                    <div>
                                        <label style="font-weight: 200">Motivo</label>
                                        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="motivo" Visible="false" />
                                    </div>
                                    <div>
                                        <asp:Button runat="server" content="suscribirse" ID="desuscribirse" CssClass="btn btn-primary btn-md" Text="Confirmar" OnClick="sendDesuscribirse_Click" Visible="false" />
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

            /*.hdPortada{
                text-align:left;
                color:beige;
                align-content:center;
                align-items:center !important;
            }*/

            header{
                background: url(img/b1.jpg) no-repeat center center fixed;
                background-size: cover;
            }

            .portfolio{
                color:white;
            }

            footer {
                /*      width:100vw !important*/
            }

            .container-footer {
                background-color: #222222;
                padding: 2%;
                /*margin:auto;*/
            }

            .contenedor-suscripcion {
                width: 80%;
                margin: auto;
            }

            .body-content-footer {
                color: #a6a6a6;
            }
        </style>

        <!-- Bootstrap core JavaScript -->
        <%--<script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>--%>

    </body>

    </html>


</asp:Content>
