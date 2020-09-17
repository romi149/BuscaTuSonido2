<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="InicioBackend.aspx.cs" Inherits="GUI.InicioBackend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <%--<meta http-equiv="X-UA-Compatible">--%>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap plantilla simple</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
  </head>
<body>
    <script src="js/bootstrap.min.js"></script>
      <div class="Inicio">
           <p style="text-align: center; "> <img src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt=""></p>
           
            <p style="text-align: center">
                Bienvenidos
            </p>
      </div>
</body>
</html>

<style>
    img {
            width: 900px; height: 200px;
        }

   </style>
</asp:Content>
