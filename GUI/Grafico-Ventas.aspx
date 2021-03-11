<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Grafico-Ventas.aspx.cs" Inherits="GUI.Grafico_Ventas" %>--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafico-Ventas.aspx.cs" Inherits="GUI.Grafico_Ventas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TyroDeveloper</title>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">

        google.charts.load('current', { 'packages': ['corechart'] });

        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            //Lineas

            //Pastel
            $.ajax({
                type: 'POST',
                url: "Grafico-Ventas.aspx/GraficaBarras",
                dataType: "json",
                contentType: 'application/json',
                async: false,
                success: function (result) {
                    var data = new google.visualization.DataTable(result.d);
                    var options = {
                        title: '',
                        hAxis: {
                            title: 'Meses del Año'
                        },
                        vAxis: {
                            title: 'Total'
                        },
                        backgroundColor: { fill: 'transparent' },
                        'height': 300,
                        /*Los colores deben coincidir*/
                        colors: ['#FF0000', '#00CC00', '#9900CC']
                    };
                    target = document.getElementById('bar-chart');
                    var chart = new google.visualization.ColumnChart(target);
                    chart.draw(data, options);
                }
            });

        }
    </script>
    <style>
        body {
            font-family: Verdana;
        }
    </style>
</head>
<body>
    <form id="frmChart" runat="server">
        <div>
            <div id="bar-chart"></div>
        </div>
        <div>
            <a runat="server" href="ReporteVentas.aspx">Volver</a>
        </div>
    </form>
</body>
</html>



<%--<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>  

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="GraficoVentas">
        <h3>Ventas</h3>
        <br />
        <div class="row">
            <div class="BuscadorDiv">
                <div class="input-group" id="BuscarControl">
                    <table>
                        <tr>
                            <td>
                                <label>Año:</label>
                                <asp:TextBox ID="anio" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Button runat="server" CssClass="btn btn-primary btn-md" Height="35" Text="Filtrar" OnClick="Buscar_Click" ></asp:Button>
            </div>
        </div>
        <div>
    <div>  
       
    </div>  
        </div>
    </div>
</asp:Content>--%>


