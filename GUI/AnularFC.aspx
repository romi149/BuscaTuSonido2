<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnularFC.aspx.cs" Inherits="GUI.AnularFC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h4>Ingresar motivo de Anulación</h4>
            <br />
            <div class="card-body">
                <div class="form-group">
                    <label>Motivo</label>
                    <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="detalle" />
                </div>
                <div class="form-group">
                    <label>Detalle Nota de Crédito</label>
                    <asp:TextBox runat="server" type="text" TextMode="MultiLine" CssClass="form-control" ID="detalleNC" />
                </div>
                <br />
                <br />
                <asp:Button runat="server" content="facturas" ID="Button1" CssClass="btn btn-primary btn-md" Text="Confirmar" OnClick="confirmar_Click" />
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
