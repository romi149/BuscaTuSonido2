<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABMC-Usuarios.aspx.cs" Inherits="GUI.ABMC_Usuarios" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ABMUser">
        <a href="AgregarUsuario.aspx" class="btn btn-primary btn lg">Agregar</a>
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="IdUsuario" HeaderText="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" Text="Editar" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="btnDelete" Text="Eliminar" runat="server" CssClass="btn btn-danger"
                            OnClick="btnDelete_Click" OnClientClick="return confirm('¿Está seguro que desea eliminar el registro?')" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <style>
        .abmUser{
            width:80vw;
            margin:auto;
            margin-top:5vh;
        }
    </style>
</asp:Content>
