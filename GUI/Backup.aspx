<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="GUI.Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row justify-content-center align-items-center" style="height: 100vh">
            <div class="ContenedorBackup ">
                <div class="centrarFormulario">
                     <h2>Generar Backup</h2>
                <div class="row">
                    <div class="col-md-12" >
                        <div class="card-body">
                            <div class="form-group">
                                <h4>Seleccione la ruta donde se guardará el backup</h4>
                                <br />
                                <asp:FileUpload ID="FileUpload" runat="server" ToolTip="Browse for files"></asp:FileUpload>
                                
                                <br />
                                <%--<asp:Button ID="UploadButton" Text="Subir Imagen" CssClass="btn btn-primary btn-md" 
                                    OnClick="UploadButton_Click" runat="server"></asp:Button>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                   <asp:Button runat="server" content="backup" ID="generar" CssClass="btn btn-primary btn-md" Text="Generar" OnClick="generar_Click" />
                </div>
              </div>
            </div>
        </div>
    </div>
    <style>
        .ContenedorBackup{
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
       
    </style>

</asp:Content>
