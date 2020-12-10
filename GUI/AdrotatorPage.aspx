<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdrotatorPage.aspx.cs" Inherits="GUI.AdrotatorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Prueba Adrotator</title>
    <script runat="server">
        protected void SubmitBtn_Click(Object sender, EventArgs e)
        {
            Response.Write("Hola " + Nombre.Text + "has elegido: " + Categoria.SelectedItem.Text);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:AdRotator AdvertisementFile="~/Ads.xml" BorderColor="Black" BorderWith="1" runat="server" />
        <h3>
            Nombre:
            <asp:TextBox
                ID="Nombre"
                runat="server" />
        </h3>
        <h3>
            Categoría:
            <asp:DropDownList ID="Categoria" runat="server">
                <asp:ListItem>Motor</asp:ListItem>
                <asp:ListItem>Ciclismo</asp:ListItem>
                <asp:ListItem>Natación</asp:ListItem>
            </asp:DropDownList>
        </h3>
        <asp:Button Text="Enviar" OnClick="SubmitBtn_Click" runat="server" ID="Button1" />
        <div>
        </div>
    </form>
</body>
</html>
