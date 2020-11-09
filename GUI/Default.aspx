<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-lg-3">
                <img id="logo" class="imglogo" src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt="">
                
                    <asp:Panel runat="server" ID="contenedorMenu">
                    </asp:Panel>
            </div>
            <div class="col-lg-9">

                <asp:Panel runat="server" ID="contenedor">
                </asp:Panel>

            </div>
        </div>
    </div>
    <br />
    <br />

    
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
        
    </style>

</asp:Content>
