<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafico-FOpinionPreg4.aspx.cs" Inherits="GUI.Grafico_FOpinionPreg4" %>

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
                url: "Grafico-FOpinionPreg4.aspx/GraficaBarras",
                dataType: "json",
                contentType: 'application/json',
                async: false,
                success: function (result) {
                    var data = new google.visualization.DataTable(result.d);
                    var options = {
                        title: '',
                        hAxis: {
                            title: '¿Qué tan probable es que nos recomiendes?'
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
            <a runat="server" href="InicioBackend.aspx">Volver</a>
        </div>
    </form>
</body>
</html>
