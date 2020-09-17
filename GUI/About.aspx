<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GUI.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
	<!-- CONTENIDO -->	
    <script src="js/bootstrap.min.js"></script>
<%--      <div class="page-header">
          <h1>Quienes Somos</h1>
      </div>--%>
      <div class="row">
          <div class="col-lg-6">
              <div class="About">
                  <h1>Quienos Somos</h1>
                  <p>
                      Somos una empresa dedicada a la comercialización y alquiler de instrumentos musicales 
                      contamos con especialistas en el rubro, como músicos de conservatorio, lutieres y técnicos 
                      electrónicos, que nos permiten garantizar la más alta calidad de los productos que ofrecemos. 
                      El objetivo principal de nuestra empresa es apoyar la actividad musical de artistas 
                      proveyéndoles una plataforma que les ayude a encontrar los instrumentos que mejor se adecúen 
                      a sus gustos y necesidades.
                  </p>
              </div>
          
          <div class="Mision">
              <h1>Nuestra Misión</h1>
              <p>
                  Nuestra misión es fabricar y vender instrumentos para todas aquellas personas que quieran 
              incursionar en el mundo de la música, ofreciéndoles productos de mayor calidad y fabricados 
              con las últimas tecnologías. 
              </p>
          </div>
          <div class="Vision">
              <h1>Nuestra Visión</h1>
              <p>
                  Ser la principal empresa de referencia para los músicos en todo el país, con respecto a la 
              venta y alquiler de instrumentos musicales de alta calidad.
              </p>
          </div>
              </div>
          <div class="col-lg-6">
              <%--<asp:Image runat="server" ID="img" ImageUrl="/imagenes/Portada/Guitarra1.png" />--%>
              <br />
              <img src="/imagenes/Portada/Guitarra5.png" />
             
          </div>
      </div>
      <br />
      <br />
      <br />

      <footer>
        <hr />
        <a href="TermyCond">Términos y Condiciones</a>
    </footer>
  </body>
</html>
   <style>
        img {
            width: 40vw; height: 30vw;
        }

    </style>


</asp:Content>