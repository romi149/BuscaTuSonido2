<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABMC-Noticias.aspx.cs" Inherits="GUI.ABMC_Noticias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<script runat="server">

  protected void UploadButton_Click(object sender, EventArgs e)
  {
    // Specify the path on the server to
    // save the uploaded file to.
    String savePath = @"C:\Users\romina\source\repos\BuscaTuSonido\GUI\Imagenes\";
 
    if (FileUpload.HasFile)
    {
      // Get the name of the file to upload.
      String fileName = FileUpload.FileName;
      
      savePath += fileName;
      
      FileUpload.SaveAs(savePath);
      
      UploadStatusLabel.Text = "El archivo fue guardado con el nombre " + fileName;
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
<div class="AbmNoticas">
        <h3>Listado de Noticas y Eventos</h3>
        <div class="row">
            <div class="BuscadorDiv">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Agregar</button>
            </div>
        </div>
        <div id="demo" class="collapse">
            <div class="container">
                <div class="row " style="height: 100vh">
                    <h3>Nueva Noticia</h3>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Titulo1</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="titulo1" />
                            </div>
                            <div class="form-group">
                                <label>Texto1</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="texto1" />
                            </div>
                            <div class="form-group">
                                <label>Titulo2</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="titulo2" />
                            </div>
                            <div class="form-group">
                                <label>Texto2</label>
                                <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="texto2" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Fecha de Publicación</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaPub" />
                            </div>
                            <div class="form-group">
                                <label>Fecha de Finalización</label>
                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="fechaFin" />
                            </div>
                            <div class="form-group">
                                <label>Alto Imagen</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="altoImg" />
                            </div>
                            <div class="form-group">
                                <label>Ancho Imagen</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="anchoImg" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Nombre Imagen</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombreImg" />
                            </div>
                            <div class="form-group">
                                <label>Imagen</label>
                                <asp:FileUpload ID="FileUpload" runat="server"></asp:FileUpload>
                                <br />
                                <asp:Button ID="UploadButton" Text="Subir Imagen" CssClass="btn btn-primary btn-md" OnClick="UploadButton_Click" runat="server"></asp:Button>
                            </div>
                            <asp:Label ID="UploadStatusLabel"
                                runat="server">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevaNoticia" ID="Agregar" CssClass="btn btn-primary btn-md" Text="Agregar" OnClick="sendAgregar_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevaNoticia" ID="cancelar" CssClass="btn btn-warning btn-md" Text="Cancelar" OnClick="sendcancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:GridView ID="gvNoticias" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Titulo1" HeaderText="Titulo1" />
                <asp:BoundField DataField="Texto1" HeaderText="Texto1" />
                <asp:BoundField DataField="Titulo2" HeaderText="Titulo2" />
                <asp:BoundField DataField="Texto2" HeaderText="Texto2" />
                <asp:BoundField DataField="Img" HeaderText="Url Imagen" />
                <asp:BoundField DataField="AltoImg" HeaderText="Alto Img" />
                <asp:BoundField DataField="AnchoImg" HeaderText="Ancho Img" />
                <asp:BoundField DataField="FechaPublicacion" HeaderText="Fecha Publicación" />
                <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                <asp:TemplateField HeaderText="Action">
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
        .abmProductos {
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
         .BuscadorDiv{
             margin-bottom:10px;
         }
        .BuscadorDiv,
        .BuscadorDiv .controlBuscar {
            display: flex;
            align-content: center;
            vertical-align: middle;

        }


        label {
            vertical-align: middle;
        }

        #BuscarControl{
            margin-left:20px;
        }

        .BtnBuscar{
            background-color:#eeeeee;
        }

        .anchoCol{
            width: 150vw;
        }

    </style>
</asp:Content>
