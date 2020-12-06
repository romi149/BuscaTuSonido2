<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarRemito.aspx.cs" Inherits="GUI.EditarRemito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h4>Actualizar Estado Remito</h4>
            <br />
            <div class="card-body">
                <div class="form-group">
                    <label>Descripcion</label>
                    <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="descripcion" />
                </div>
                <div class="form-group">
                    <label>Notas</label>
                    <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="notas" />
                </div>
                <div class="form-group">
                    <label>Estado</label>
                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="estado" />
                </div>
                <br />
                <br />
                <asp:Button runat="server" content="remitos" ID="btnConfirmar" CssClass="btn btn-primary btn-md" Text="Confirmar" OnClick="confirmar_Click" />
                <asp:Button runat="server" content="facturas" ID="btnCancelar" CssClass="btn btn-warning btn-md" Text="Cancelar" OnClick="cancelar_Click" />
            </div>
        </div>
    </form>
</body>
     <style>
        .container{
            width:60%;
            margin:auto;
            display:flex;
            justify-content:center;
            align-items:center;
            background-color:hsl(218, 74%, 60%, 0.171);
            border-radius:15px;
            padding:5%;
            margin-top:5%;
        }

        h2 {
            text-align: center;
            font-weight: bold;
        }


    </style>
</html>
