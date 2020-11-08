<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
body {font-family: Arial, Helvetica, sans-serif;}

/* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 100px; /* Location of the box */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}

/* Modal Content */
.modal-content {
  background-color: #fefefe;
  margin: auto;
  padding: 20px;
  border: 1px solid #888;
  width: 80%;
}

/* The Close Button */
.close {
  color: #aaaaaa;
  float: right;
  font-size: 28px;
  font-weight: bold;
}

.close:hover,
.close:focus {
  color: #000;
  text-decoration: none;
  cursor: pointer;
}
</style>
<%--<script>
        function abrir(url) {
        open(url,'','top=100,left=300,width=450,height=500') ;
        }
</script>--%>

  <%-- <div>
        <h2>Iniciar Sesión</h2>
    </div>--%>
    <div class="container">
        <div class="row">
            <div class="container-login">
                <div class="col-4">
                    <div class="row">
                        <div>
                            <h2>Iniciar Sesión</h2>
                            <div class="card-body">
                                <div class="form-group">
                                    <label>Usuario</label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="username" />
                                </div>
                                <div class="form-group">
                                    <label>Contraseña</label>
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="password" />
                                </div>
                                <%--<a href="javascript:abrir('RecuperarPass.aspx')">Olvide mi contraseña</a>--%> 
                                <a id="myBtn">Olvide mi Contraseña</a>
                                <a href="Registrarse.aspx">Registrarse</a>
                                <br />
                                <br />
                                <asp:Button runat="server" content="login" ID="sendlogin" CssClass="btn btn-primary btn-lg" Text="Ingresar" OnClick="sendlogin_Click" />
                                <asp:Button runat="server" content="login" ID="btnVolver" CssClass="btn btn-warning btn-lg" Text="Volver" OnClick="sendvolver_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- The Modal -->
    <div id="myModal" class="modal">

        <!-- Modal content -->
        <div class="modal-content">
            <span class="close">&times;</span>
            <div>
                <h2>Recuperar Contraseña</h2>
                <br />
                <div class="card-body">
                    <h4>Ingrese su usuario y un email a donde le enviaremos los datos para recuperar su contraseña</h4>
                    <br />
                    <div class="form-group">
                        <label>Usuario</label>
                        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="usuario" />
                    </div>
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="email" />
                    </div>
                    <br />
                    <br />
                    <asp:Button runat="server" content="login" ID="Button1" CssClass="btn btn-primary btn-lg" Text="Enviar" OnClick="sendemail_Click" />
                    <asp:Button runat="server" content="login" ID="btnCancelar" CssClass="btn btn-warning btn-lg" Text="Volver" OnClick="sendcancelar_Click" />
                </div>
            </div>
        </div>

    </div>

<script>
    // Get the modal
    var modal = document.getElementById("myModal");

    // Get the button that opens the modal
    var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks the button, open the modal 
    btn.onclick = function () {
        modal.style.display = "block";
    }

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
</script>
    <style>
        .container-login{
            width:60%;
            margin:auto;
            display:flex;
            justify-content:center;
            align-items:center;
            background-color:hsl(218, 74%, 60%, 0.171);
            border-radius:15px;
            padding:5%;
            margin-top:5%;
        }
        .modal-content{
            width:80%;
            margin:auto;
            /*background-color:hsla(218, 74%, 60%, 0.171);*/
            align-items:center;
            border-radius:15px;
       
        }
        h2 {
            text-align: center;
            font-weight: bold;
        }


    </style>
</asp:Content>
