<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmarRegistro.aspx.cs" Inherits="GUI.ConfirmarRegistro" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Confirmación</title>


</head>
<body>

    
    <script src="js/bootstrap.min.js"></script>

    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="ContenedorRegistro ">
                <div class="centrarFormulario">
                    <h1>¡Bienvenido!</h1>
                    <br />
                    <h3>Se ha registrado correctamente, inicie sesión para ingresar a su cuenta</h3>
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <p class="botones"><a href="Login.aspx" >Iniciar Sesión</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <style>
        .ContenedorRegistro {
            width: 80%;
            margin: auto;
            background-color: hsla(218, 74%, 60%, 0.171);
            border-radius: 15px;
        }

        .centrarFormulario {
            width: 80%;
            margin: auto;
            padding: 3%;
            margin-top: 2% !important;
        }

        h1 {
            text-align: center;
            font-weight: bold;
        }
        h3{
            text-align:center;
            color:navy;
        }

        .botones {
            text-align:center;
            color:red;
            font-size:larger;
            font-weight: bold;
            
        }
    </style>

  
</body>
</html>