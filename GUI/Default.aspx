<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-lg-3">

                <h1 class="my-4">BuscaTuSonido</h1>
                <div class="list-group">
                    <a href="#" class="list-group-item">Category 1</a>
                    <a href="#" class="list-group-item">Category 2</a>
                    <a href="#" class="list-group-item">Category 3</a>
                </div>

            </div>
            <div class="col-lg-9">

                <asp:Panel runat="server" ID="contenedor">
                </asp:Panel>


            </div>


        </div>


    </div>


 
  <!-- /.container -->

     <style>
        img {
            width: 10vw;
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
    </style>

</asp:Content>