<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-lg-3">
                <img id="logo" class="img-responsive" src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt="">

                <asp:Panel runat="server" ID="contenedorMenu">
                </asp:Panel>
                <div>
                    <label>Buscar por:</label>
                </div>
                <br />
                <div>
                    <asp:DropDownList runat="server" ID="listMarca" CssClass="form-control" >
                    </asp:DropDownList>
                </div>
                <br />
                <div>
                    <asp:DropDownList runat="server" ID="listCategoria" CssClass="form-control" >
                    </asp:DropDownList>
                </div>
                <br />
                <div>
                    <asp:Button runat="server" content="buscadormenu" ID="buscar" CssClass="btn btn-info btn-md" Text="Buscar" OnClick="Buscar_Click" />
                </div>
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
