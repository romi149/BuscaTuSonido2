<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComparacionProductos.aspx.cs" Inherits="GUI.ComparacionProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" id="Productos">
        <%--Se CARGAN DINAMICAMENTE--%>

    </asp:Panel>
      <style>
        #productos {
            display: flex;
            justify-content: space-around;
        }

        .thumbnail {
            width: 20vw;
        }
    </style>
</asp:Content>
