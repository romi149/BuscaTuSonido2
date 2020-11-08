<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComparacionProductos.aspx.cs" Inherits="GUI.ComparacionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Contenedor-productos">
     <asp:Panel runat="server" id="Productos">
        <%--Se CARGAN DINAMICAMENTE--%>

    </asp:Panel>
    </div>
      <style>
        #MainContent_Productos {
            display: flex;
            justify-content: space-around;
        }

        .thumbnail {
            width: 22vw;
            height:95vh;
        }
    </style>
</asp:Content>
