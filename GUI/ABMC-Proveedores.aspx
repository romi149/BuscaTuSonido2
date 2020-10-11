<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="ABMC-Proveedores.aspx.cs" Inherits="GUI.ABMC_Proveedor" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ABMProveedor">
        <h3>Listado de Proveedores</h3>
        <div class="row">
            <div class="BuscadorDiv">
                <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Agregar</button>
                <div class="input-group" id="BuscarControl">
                    <span class="input-group-addon">Buscar</span>
                    <asp:TextBox runat="server" type="text" CssClass="form-control"  />
                </div>
                <asp:Button runat="server" CssClass="btn btnBuscar" Text="Buscar" OnClick="Buscar_Click" ></asp:Button>
            </div>
        </div>
        <div id="demo" class="collapse">
            <div class="container">
                <div class="row " style="height: 100vh">
                    <h3>Nuevo Proveedor</h3>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Cod. Proveedor</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="codProv" />
                            </div>
                            <div class="form-group">
                                <label>Nombre Empresa</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="nombreEmp" />
                            </div>
                            <div class="form-group">
                                <label>Razon Social</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="razonSocial" />
                            </div>
                            <div class="form-group">
                                <label>Domicilio</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="domicilio" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="email" />
                            </div>
                            <div class="form-group">
                                <label>Telefono</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="tel" />
                            </div>
                            <div class="form-group">
                                <label>Descripcion</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="descripcion" />
                            </div>
                            <div class="form-group">
                                <label>CUIT</label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="cuit" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevoProveedor" ID="Agregar" CssClass="btn btn-primary btn-lg" Text="Agregar" OnClick="sendAgregar_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" content="nuevoProveedor" ID="cancelar" CssClass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="false" class="table table-striped"
            ClientIDMode="Static">
            <Columns>
                <asp:BoundField DataField="IdProveedor" HeaderText="Id" />
                <asp:BoundField DataField="CodProveedor" HeaderText="Cod Proveedor" />
                <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Empresa" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
                <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Cuit" HeaderText="CUIT" />
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

 <style>
        .abmProveedores {
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
    </style>
</asp:Content>