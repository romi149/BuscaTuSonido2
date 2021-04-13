<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABMC-Encuestas.aspx.cs" Inherits="GUI.ABMC_Encuestas" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<script runat="server">

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        // Specify the path on the server to
        // save the uploaded file to.
        String savePath = @"C:\Users\romina\source\repos\BuscaTuSonido\GUI\img\";

        if (FileUpload.HasFile)
        {
            // Get the name of the file to upload.
            String fileName = FileUpload.FileName;

            savePath += fileName;

            FileUpload.SaveAs(savePath);

            //UploadStatusLabel.Text = "Las imágenes fueron guardadas";
        }
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "You did not specify a file to upload.";
        }

        if (FileUpload1.HasFile)
        {
            // Get the name of the file to upload.
            String fileName1 = FileUpload1.FileName;

            savePath += fileName1;

            FileUpload1.SaveAs(savePath);

            UploadStatusLabel.Text = "Las imágenes fueron guardadas";
        }
        else
        {
            // Notify the user that a file was not uploaded.
            UploadStatusLabel.Text = "You did not specify a file to upload.";
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head></head>
<body>
    <div class="ABMEncuesta">
        <h3>Listado de Encuestas</h3>
        <div class="row">
            <div class="BuscadorDiv">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Agregar</button>
            </div>
        </div>
        <div id="demo" class="collapse">
            <div class="container">
                <div class="row " style="height: 100vh">
                    <h3>Nueva Encuesta</h3>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Pregunta</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombrePregunta" />
                            </div>
                            <div class="form-group">
                                <label>Fecha Incio</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaInicio" />
                            </div>
                            <div class="form-group">
                                <label>Fecha Fin</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaFin" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Respuesta 1</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="opcion1" />
                            </div>
                            <div class="form-group">
                                <label>Respuesta 2</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="opcion2" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Nombre Imagen 1</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="img1" />
                                <asp:FileUpload ID="FileUpload" runat="server"></asp:FileUpload>
                            </div>
                            <div>
                              <%--<asp:Button ID="UploadButton1" Text="Subir Imagen" CssClass="btn btn-primary btn-md" OnClick="UploadButton_Click" runat="server"></asp:Button>--%>
                            </div>
                            <br />
                            <div class="form-group">
                                <label>Nombre Imagen 2</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="img2" />
                                <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                            </div>
                            <asp:Label ID="UploadStatusLabel"
                                runat="server">
                            </asp:Label>
                            <div>
                              <asp:Button ID="UploadButton" Text="Subir Imagen" CssClass="btn btn-primary btn-md" OnClick="UploadButton_Click" runat="server"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevaEncuesta" ID="Agregar" CssClass="btn btn-primary btn-md" Text="Agregar" OnClick="sendAgregar_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevaEncuesta" ID="cancelar" CssClass="btn btn-warning btn-md" Text="Cancelar" OnClick="sendcancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:GridView ID="gvEncuesta" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="NombrePregunta" HeaderText="Pregunta" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                <asp:BoundField DataField="Opcion1" HeaderText="Respuesta 1" />
                <asp:BoundField DataField="Opcion2" HeaderText="Respuesta 2" />
                <asp:BoundField DataField="UrlImagen1" HeaderText="Imagen 1" />
                <asp:BoundField DataField="UrlImagen2" HeaderText="Imagen 2" />
                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <div class="BtnGrid">
                            <asp:Button ID="btnEdit" Text="Editar" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="btnDelete" Text="Eliminar" runat="server" CssClass="btn btn-danger"
                                OnClick="btnDelete_Click" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?')" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</body>
</html>
    <style>
        .abmEncuesta {
            width: 80vw;
            margin: auto;
            margin-top: 15vh !important;
        }

        .BtnGrid {
            display: flex;
            justify-content: space-between;
        }

        .tamanoHeader {
            width: 200px;
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 8px;
            line-height: 1.42857143;
            vertical-align: middle;
            border-top: 1px solid #ddd;
        }

        .desc {
            width: 500px;
        }
        
        label {
            vertical-align: middle;
        }

    </style>
</asp:Content>