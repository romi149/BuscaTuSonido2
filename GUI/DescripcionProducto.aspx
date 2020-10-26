<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DescripcionProducto.aspx.cs" Inherits="GUI.DescripcionProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="containerProducto">
            <div class="row">
                <div class="col-lg-6 col-md-6">
                     <asp:Image CssClass="imgProducto" runat="server" ID="ImagenProducto" />
                </div>
                <div class="col-lg-4 col-md-6">
                    <h1><asp:Panel runat="server" ID="TxtNombre"></asp:Panel></h1>
                    <h2><asp:Panel runat="server" ID="TxtModelo"></asp:Panel></h2>
                    <h3><asp:Panel runat="server" ID="TxtPrecio"></asp:Panel></h3>
                    <p><asp:Panel runat="server" ID="TxtDescripcion"></asp:Panel></p>
                    <a href="#" class="btn btn-success btn-lg">Comprar</a>
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="row">
        <h3>Preguntas y Comentarios</h3>
        <br />
        <table>
            <tr>
                <td>
                <%--    <label>Preguntarle al vendedor</label>--%>
                   <asp:TextBox ID="pregunta" runat="server" type="text" TextMode="MultiLine" Width="420" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" content="pregunta" ID="btnPregunta" CssClass="btn btn-primary btn-md" Text="Preguntar" OnClick="sendPreguntar_Click" />
                </td>
            </tr>
        </table>
        
        </div>
    <style>
       .imgProducto{
            width:30vw;
            height:50vh;
        }
    </style>
</asp:Content>
