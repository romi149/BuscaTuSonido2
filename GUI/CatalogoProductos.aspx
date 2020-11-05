<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoProductos.aspx.cs" Inherits="GUI.InstrumentosCuerdas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">

        <div class="row">

            <div class="col-lg-3">
                <img id="logo" class="imglogo" src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt="">
                <%--<h1 class="my-4">BuscaTuSonido</h1>--%>
                <div class="list-group">

                    <asp:Panel runat="server" ID="contenedorMenu">
                    </asp:Panel>
                    
                    <br />
                    <br />
                    <div class="compareBox-content">
                        <div class="compareBox gb--appear ">
                            <div class="compareBox-header">
                                <p class="compareBox-tittle">Comparador de productos <strong><span id="gb-product-counter">0</span>/4</strong></p>
                                <a class="gb-icon-simple-thin-arrow-top"></a>
                            </div>
                            <div class="compareBox-body">
                                <ul class="compare-item-list" id="compare_list">                                                                      
                                </ul>
                                <div class="compareBox-actions">
                                    <p id="compare_link" class="btn btn-primary btn-md" onclick="EnviarDatosAComparar()" >Comparar</p>
                                    <button id="eliminar" class="btn btn-warning btn-md" Onclick="Eliminar_Click()" >Eliminar Todos</button>
                                </div>
                                <p id="mensajeError"></p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-lg-9">

                <asp:Panel runat="server" ID="contenedor">
                    
                </asp:Panel>
            </div>
        </div>
    </div>

    <style>
        #logo {
            width: 20vw;
            height: 25vh;
        }
    </style>
    <script>
        function addComparacion(parametro) {  
            document.getElementById('mensajeError').innerHTML = ""
            if (document.getElementById('compare_list').children.length<4) {
                document.getElementById('compare_list').innerHTML += `<li>${parametro}</li>`  
            
            }
            document.getElementById('gb-product-counter').innerText =
                document.getElementById('compare_list').children.length
        }
        function Eliminar_Click(e) {
            e.preventDefault()
            document.getElementById('compare_list').innerHTML += ""
            document.getElementById('gb-product-counter').innerText =
                document.getElementById('compare_list').children.length
          
        }

        function EnviarDatosAComparar(e) {
            var Datos="";
            if (document.getElementById('compare_list').children.length <= 1) {
                document.getElementById('mensajeError').innerHTML=`<strong style='color:red'>Seleccione más de uno.</strong>`
                return;
            }
            for (var i = 0; i < document.getElementById('compare_list').children.length; i++) {
                Datos += `param${i+1}`+ '=' + document.getElementById('compare_list').children[i].innerText.trim() +'&'
            }    
            location.href='ComparacionProductos?'+Datos
        }
       
    </script>
</asp:Content>
