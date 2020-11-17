<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DescripcionProducto.aspx.cs" Inherits="GUI.DescripcionProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="containerProducto">
            <div class="row">
                <div class="col-lg-6 col-md-6">
                     <asp:Image CssClass="imgProducto" runat="server" ID="ImagenProducto" />
                </div>
                <div class="col-lg-4 col-md-6">
                    <h1><asp:Panel runat="server" ID="TxtNombre"></asp:Panel></h1>
                    <h2><asp:Panel runat="server" ID="TxtModelo"></asp:Panel></h2>
                    <h3><asp:Panel runat="server" ID="TxtPrecio"></asp:Panel></h3>
                    <p><asp:Panel runat="server" ID="TxtDescripcion"></asp:Panel></p>
                    <a href="/FormularioDeCompra.aspx" class="btn btn-success btn-lg">Comprar</a>
                    <button id="btnCarrito" class="btn btn-warning btn-lg"><i class="glyphicon glyphicon-shopping-cart"></i>Agregar al Carrito</button>
                </div>
            </div>
        </div>
    </div>

    <hr />
    <div class="row">
        <div class="col-md-12">
            <h3>Preguntas y Respuestas</h3>
            <div id="PreguntasBox">
                <asp:TextBox ID="pregunta" runat="server" type="text" TextMode="MultiLine" Width="" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" content="pregunta" ID="btnPregunta" CssClass="btn btn-primary" Text="Preguntar" OnClick="sendPreguntar_Click" />
                <%--<asp:Label runat="server" Visible="false" ID="AvisoLog"  ForeColor="Red" Font-Bold="true"/>--%>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" id="peopleComment">
            
    </asp:Panel>
    <hr />
    <div class="row">
        <h3>Opiniones sobre el producto</h3>
        <div class="col-md-4 ">
            <div id="Puntuacion" class="text-center">
                <h1>4,1%
                </h1>
                <div class="progress">
                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="45"
                        aria-valuemin="0" aria-valuemax="100" style="width: 45%">
                        100%
                    </div>
                </div>

            </div>
        </div>
        <div class="col-md-8">
            <div class="col-md-4">
                <div class="progress">
                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="100"
                        aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                        100%
                    </div>
                </div>

                <div class="progress">
                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="80"
                        aria-valuemin="0" aria-valuemax="100" style="width: 80%">
                        80% 
                    </div>
                </div>

                <div class="progress">
                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="35"
                        aria-valuemin="0" aria-valuemax="100" style="width: 35%">
                        35% 
                    </div>
                </div>

                <div class="progress">
                    <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="25"
                        aria-valuemin="0" aria-valuemax="100" style="width: 25%">
                        25% 
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <div>
            <div class="panel panel-default">
                <div class="panel-heading">4.1-Nombre Usuario</div>
                <div class="panel-body">Opinion</div>
            </div>
        </div>
    </div>

    <style>
        .imgProducto {
            width: 30vw;
            height: 50vh;
        }

        #PreguntasBox {
            display: flex;
        }

        #pregunta {
            width: 30vw !important;
            max-width: 30vw !important;
        }

        .row {
            margin-top: 30px;
            margin-bottom: 30px
        }
    </style>
</asp:Content>
