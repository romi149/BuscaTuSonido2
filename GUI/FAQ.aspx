<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="GUI.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html>
  <head>
	<meta charset="UTF-8">
	<title>Didesweb - Efecto acordeón con jQuery</title>
	<style>
	*{margin: 0;}
		#acordeon_didesweb{ 
		width: 900px;
		list-style-type: none;
	}
	.menues { 
		background: #FFFFFF; 
		color: #444444; 
		/*border-bottom: 1px solid #333333;*/
		border-top: 1px solid #444444;
		cursor: pointer;
		margin-right: 10px;
		padding: 10px; 
	}
	.contenido_acordeon { 
		background: #FFFFFF; 
		line-height: 1.6em;
		padding: 10px;
		width: 850px;
		}
	.menues.desplegado, .menues:hover { 
		background: #FFFFFF;
		color:#D78500;
	}
	</style>
	<script src="https://code.jquery.com/jquery-latest.js"></script>
</head>
<body>
	<h2>Preguntas Frecuentes</h2>
	<br />
	<ul id="acordeon_didesweb">
		<h4 class="menues">¿Cómo puedo saber si un producto tiene stock?</h4>
		<li class="contenido_acordeon">
			Siempre que un producto esté disponible en la web, significa que tiene stock para su compra.
		</li>
		<h4 class="menues">¿Cómo me registro?</h4>
		<li class="contenido_acordeon">
			<div>
				<p>
					Formar parte de la comunidad de Busca Tu Sonido es muy fácil solo tenes que hacer clic 
					en la parte superior derecha del sitio en el botón “Registrarse”.
				</p>
				<%--<span class="chevron-down"></span>--%>
			</div>
		</li>
		<h4 class="menues">¿Cómo puedo editar mis datos personales y cambiar mi contraseña?</h4>
		<li class="contenido_acordeon">
			Una vez que iniciaste sesión en Mi Cuenta ingresa a la sección ‘Mis Datos’ y desde allí podrás 
			editar tus datos personales y generar una nueva contraseña para tu cuenta.
		</li>
		<h4 class="menues">¿Es seguro comprar en BuscaTuSonido.com?</h4>
		<li class="contenido_acordeon">
			Gracias al respaldo de SSL (Secure Socket Layer), el sistema de seguridad que utilizamos en 
			BuscaTuSonido.com, te aseguramos que tu información personal será cifrada y no podrá ser leída 
			ni utilizada por terceros mientras realices una compra. A su vez, Busca Tu Sonido te asegura que 
			dichos datos no saldrán de la compañía, manejándolos con total responsabilidad, de manera 
			absolutamente confidencial y conforme a lo dispuesto por la legislación vigente.
		</li>
		<h4 class="menues">Olvide mi Contraseña ¿Qué hago?</h4>
		<li class="contenido_acordeon">
			Para recuperar tu contraseña deberás ingresar a Iniciar Sesión y luego hacer clic en la opción 
			“Recuperar contraseña”
		</li>
		<h4 class="menues">Quiero anular una compra realizada en BuscaTuSonido.com</h4>
		<li class="contenido_acordeon">
			Si compraste por error dos veces el mismo producto o todavía no lo recibiste, podés solicitar la 
			anulación de tu compra envinado un correo a ventas@buscatusonido.com. 
			¡Tené en cuenta que este trámite puede demorar hasta 72 horas!
		</li>
		<h4 class="menues">Quiero solicitar el cambio de un producto</h4>
		<li class="contenido_acordeon">
			Para solicitar un cambio de producto envianos un correo a cambiosydevoluciones@buscatusonido.com. 
			Tené en cuenta que los cambios se encuentran sujetos a disponibilidad de stock y que para realizarlo 
			será necesario que el producto esté en el mismo estado que se entregó: embalaje en perfectas condiciones, 
			con accesorios y manuales completos.
		</li>
		<h4 class="menues">Los cambios y devoluciones ¿tienen algún costo adicional?</h4>
		<li class="contenido_acordeon">
			Los cambios y/o devoluciones no tienen costo. En el caso de un cambio por un producto de mayor valor, 
			se cobrará la diferencia.
		</li>
		<h4 class="menues">¿Existe un tiempo máximo para solicitar un cambio y/o devolución?</h4>
		<li class="contenido_acordeon">
			Una vez transcurridos los 10 días de haber recibido tu pedido, debés contactarte con la garantía 
			del mismo para efectuar la reparación o cambio del producto.
		</li>
		<h4 class="menues">Quiero modificar el domicilio de entrega</h4>
		<li class="contenido_acordeon">
			Para modificar el domicilio de entrega antes de realizar tu compra, debes ingresar a tu cuenta 
			y en los datos personales modificas el domicilio de entrega. Si ya realizaste la compra y 
			queres modificar el domicilio de entrega, comunícate con nosotros antes de los 
			3 días hábiles de realizada la compra.
		</li>
		<h4 class="menues">Inconvenientes con la entrega</h4>
		<li class="contenido_acordeon">
			En el caso que no podamos concretar la entrega te contactaremos para pactar una nueva visita.
			Recordá que si el producto no se encuentra en condiciones o no cumple con tus expectativas podés 
			rechazarlo en el momento de la entrega. En este caso deberás firmar el remito indicando los motivos 
			del rechazo y luego te contactaremos para coordinar una nueva entrega.
		</li>
		<h4 class="menues">Compré un producto en BuscaTuSonido.com y no lo recibí, ¿qué hago?</h4>
		<li class="contenido_acordeon">
			Si no recibiste tu producto en la fecha pactada envianos un correo a envios@buscatusonido.com 
			y te contactaremos en las próximas 48 horas para reprogramar el envío.
		</li>
	</ul>
	<script>
		$('#acordeon_didesweb .contenido_acordeon').not('.menues.desplegado + .contenido_acordeon').hide();
		$('#acordeon_didesweb .menues').click(function(){
			if ($(this).hasClass('desplegado')) {
				$(this).removeClass('desplegado');
				$(this).next().slideUp();
			} else {
				$('#acordeon_didesweb .menues').removeClass('desplegado');
				$(this).addClass('desplegado');
				$('#acordeon_didesweb .contenido_acordeon').slideUp();
				$(this).next().slideDown();
			}
		});
    </script>
</body>
</html>
</asp:Content>
