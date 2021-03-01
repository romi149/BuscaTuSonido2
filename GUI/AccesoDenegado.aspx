<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AccesoDenegado.aspx.cs" Inherits="GUI.AccesoDenegado" %>

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
           <p style="text-align: center; "> <img class="imglogo" src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt=""></p>
           
            <h2 style="color:red" class="h2">ACCESO DENEGADO</h2>
            <h3 style="text-align: center">Su usuario no tiene permiso para ver el contenido 
                de esta pagina</h3>
            <h3 style="text-align:center">Para mas información contactese con el administrador</h3>
            
      </div>
</body>
</html>

<style>
    .imglogo {
            width: 700px; height: 200px;
        }
    .h2{
        text-align:center;
      
    }

   </style>
</asp:Content>
