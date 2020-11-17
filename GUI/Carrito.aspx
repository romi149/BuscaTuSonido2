<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="GUI.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
 
    <div class="container">
        <div class="row">
            <!-- Elementos generados a partir del JSON -->
            <main id="items" class="col-sm-8 row"></main>
            <!-- Carrito -->
            <aside class="col-sm-4">
                <h2>Carrito</h2>
                <!-- Elementos del carrito -->
                <ul id="carrito" class="list-group"></ul>
                <hr>
                <!-- Precio total -->
                <p class="text-right">Total: <span id="total"></span>$;</p>
                <button id="boton-vaciar" class="btn btn-danger">Vaciar</button>
                <button  id="btnComprar" class="btn btn-success">Comprar</button>
            </aside>
        </div>
    </div>
   <script>
       function getProductos(cadena) {
           let Productos = cadena.split('*')
           let ArrayProd = []
           for (var i = 0; i < Productos.length; i++) {
               ArrayProd.push(Productos[i])
           }
           return ArrayProd
       }
       function InicializarCarrito() {
           // Variables
           let baseDeDatos = getProductos(this.localStorage.getItem('Carrito'))
           let $items = document.querySelector('#items');
           let carrito = [];
           let total = 0;
           let $carrito = document.querySelector('#carrito');
           let $total = document.querySelector('#total');
           let $botonVaciar = document.querySelector('#boton-vaciar');
           let $botonComprar = document.querySelector('#btnComprar');
           $botonComprar.addEventListener('click', botonComprar)

           // Funciones
           function renderItems() {
               for (let info of baseDeDatos) {

                   info = JSON.parse(info)
                   // Estructura
                   let miNodo = document.createElement('div');
                   miNodo.classList.add('card', 'col-sm-4');
                   // Body
                   let miNodoCardBody = document.createElement('div');
                   miNodoCardBody.classList.add('card-body');
                   // Titulo
                   let miNodoTitle = document.createElement('h5');
                   miNodoTitle.classList.add('card-title');
                   miNodoTitle.textContent = info.Nombre;

                   // Precio
                   let miNodoPrecio = document.createElement('p');
                   miNodoPrecio.classList.add('card-text');
                   miNodoPrecio.textContent = '$' + info.Precio;

                   let miNodoBoton = document.createElement('button');
                   miNodoBoton.classList.add('btn', 'btn-primary');
                   miNodoBoton.textContent = '+';
                   miNodoBoton.setAttribute('marcador', info.Nombre);
                   miNodoBoton.setAttribute('marcadorPrecio', info.Precio);
                   miNodoBoton.addEventListener('click', anyadirCarrito);
                   // Insertamos
                   miNodoCardBody.appendChild(miNodoTitle);
                   miNodoCardBody.appendChild(miNodoPrecio);
                   miNodo.appendChild(miNodoCardBody);
                   miNodoCardBody.appendChild(miNodoBoton);
                   $items.appendChild(miNodo);

               }

           }

           function anyadirCarrito(e) {
               e.preventDefault()
               // Anyadimos el Nodo a nuestro carrito
               let Atributo = {
                   "Nombre": this.getAttribute('marcador'),
                   "Precio": this.getAttribute('marcadorPrecio')
               };
               carrito.push(Atributo)
               // Calculo el total
               // Renderizamos el carrito
               renderizarCarrito();
               calcularTotal()
           }

           function renderizarCarrito() {
               $carrito.innerHTML = "";
               for (var i = 0; i < carrito.length; i++) {

                   let miNodo = document.createElement('li');
                   miNodo.classList.add('list-group-item', 'text-right', 'mx-2');
                   miNodo.textContent = `${carrito[i].Nombre} -------->  $ ${carrito[i].Precio}`;
                   // Boton de borrar
                   let miBoton = document.createElement('button');
                   miBoton.classList.add('btn', 'btn-danger', 'mx-5');
                   miBoton.textContent = 'X';
                   miBoton.style.marginLeft = '1rem';
                   //miBoton.setAttribute('item', item);
                   miBoton.addEventListener('click', borrarItemCarrito);
                   // Mezclamos nodos
                   miNodo.appendChild(miBoton);
                   $carrito.appendChild(miNodo);
               }
           }

           function borrarItemCarrito() {
               console.log()
               // Obtenemos el producto ID que hay en el boton pulsado
               let id = this.getAttribute('item');
               // Borramos todos los productos
               carrito = carrito.filter(function (carritoId) {
                   return carritoId !== id;
               });
               // volvemos a renderizar
               renderizarCarrito();
               // Calculamos de nuevo el precio
               calcularTotal();
           }

           function calcularTotal() {
               // Limpiamos precio anterior
               total = 0;
               // Recorremos el array del carrito

               for (let item of carrito) {
                   for (var i = 0; i < baseDeDatos.length; i++) {

                       if (item.Nombre == JSON.parse(baseDeDatos[i]).Nombre) {
                           total += parseFloat(item.Precio)
                       }
                   }
               }

               // Formateamos el total para que solo tenga dos decimales
               let totalDosDecimales = total.toFixed(2);
               // Renderizamos el precio en el HTML
               $total.textContent = totalDosDecimales;
           }

           function vaciarCarrito() {
               // Limpiamos los productos guardados
               carrito = [];
               // Renderizamos los cambios
               renderizarCarrito();
               calcularTotal();
               localStorage.clear()
               Response.redirect('/Default.aspx')
           }

           // Eventos
           $botonVaciar.addEventListener('click', vaciarCarrito);

           // Inicio
           renderItems();
           function botonComprar(e) {
               e.preventDefault()
               let Nombre = ""

               for (var i = 0; i < carrito.length; i++) {
                   Nombre += carrito[i].Nombre + ','
               }
               location.href = `FormularioDeCompra.aspx?Nombre=${Nombre}&total=${total}`
           }
       }

       InicializarCarrito();
   </script>
</asp:Content>
