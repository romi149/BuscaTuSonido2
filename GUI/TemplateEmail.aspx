<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateEmail.aspx.cs" Inherits="GUI.TemplateEmail" %>

<!DOCTYPE html> 
<html lang='en'> 
<body style="width: 80%;"> 
	<div width='500px' style='width: 85%; display: flex; justify-content: center; margin: 10% auto; background-color:#F0195D;'> 
		<table align="center" >  
			<thead> 
				<tr> 
					<td>
						<font face="Mistral" size="30">Busca Tu Sonido</font>
					</td>
				</tr>
				<tr>
					<td>
						<h2>{texto}</h2>
					</td> 
				</tr> 
			</thead> 
			<TBody> 
				<tr> 
					<td colspan='3'>{mensaje}</td> 
				</tr> 
			</TBody> 
			<tr></tr>
			<tr>
			<tr></tr>
			</tr>
			<tr>
				<td>
				   <h3>Ante cualquier duda Contactanos:</h3>
					<p>Teléfono: <strong>116045-2099</strong><br />
						Email: info@buscatusonido.com <strong></p>
				</td>
			</tr>
		</table> 
	</div> 
</body>
</html>
