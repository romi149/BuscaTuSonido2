<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="GUI.Restore" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="ContenedorRestore ">
                <div class="centrarFormulario">
                     <h2>Generar Restore de la Base de Datos</h2>
                    <br />
                <div class="row">
                    <div class="col-md-12" >
                        <div class="card-body">
                            <div class="form-group">
                                <h4>Seleccione la base de datos a restaurar</h4>
                                <br />
                                <asp:FileUpload ID="btnFileUpload" runat="server"></asp:FileUpload>
                                <%--<input type="file" id="fileLoader" name="files" title="Load File" />--%>
                                <%--<input type="button" id="btnOpenFileDialog" value ="Buscar" onclick="openfileDialog();" />--%>
                                <br />
                                <%--<asp:Button ID="btnGuardar" Text="Guardar archivo" CssClass="btn btn-primary btn-md" 
                                    OnClick="btnGuardar_Click" runat="server"></asp:Button>--%>
                                <br />
                                <br />
                                <asp:Button ID="btnRestore" Text="Realizar Restore" CssClass="btn btn-primary btn-md" 
                                    OnClick="restore_Click" runat="server"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
            </div>
        </div>
    </div>

    <script>
        function openfileDialog() {
            $("#fileLoader").click();

        }
    </script>

    <style>
        .ContenedorRestore{
            width:80%;
            margin:auto;
            background-color:hsla(218, 74%, 60%, 0.171);
            border-radius:15px;
       
        }
        .centrarFormulario{
            width:80%;
            margin:auto;       
            padding:3%;        
            margin-top:2% !important;
           
        }
        h2{
            text-align:center;
            font-weight:bold;
        }

        .botones{
            margin-left:20px;
          }

        #fileLoader{
            display:none;
        }
       
    </style>

</asp:Content>
