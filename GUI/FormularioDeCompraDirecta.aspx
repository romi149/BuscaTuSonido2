<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioDeCompraDirecta.aspx.cs" Inherits="GUI.FormularioDeCompraDirecta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="creditCardForm">
            <div class="heading">
                <h1>Confirmar Compra</h1>
            </div>

             <div class="payment">
                <div class="form-group" id="card-precio">
                    <label for="precio">Importe Total</label>
                    <asp:TextBox ID="PrecioCompra" runat="server"  ReadOnly="true"></asp:TextBox>
                </div>
                 <div class="form-group"">
                    <label for="NC">Nota de Credito</label>
                     <asp:DropDownList runat="server" CssClass="form-control" ID="listNotaCred">
                     </asp:DropDownList>
                     <%--<asp:TextBox ID="notaCredito" runat="server"  ReadOnly="true" Visible="false" ></asp:TextBox>--%>
                </div>
                 <div class="form-group">
                    <label for="precioPagar" >Importe a Pagar con Descuento</label>
                    <asp:TextBox ID="precioAPagar" runat="server"  ReadOnly="true" Visible="true" ></asp:TextBox>
                </div>
                <div class="form-group owner">
                    <label for="owner">Nombre y Apellido</label>
                    <asp:TextBox ID="owner" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                </div>
                <div class="form-group CVV">
                    <label for="cvv">CVV</label>
                    <asp:TextBox ID="cvv" runat="server" CssClass="form-control" ></asp:TextBox>
                    <label  hidden="hidden"  id="AlertaCvv" class="alert alert-danger"  role="alert" >
                        Codigo Invalido 
                    </label>
                </div>
                <div class="form-group" id="card-number-field">
                    <label for="cardNumber">Numero de Tarjeta</label>
                    <asp:TextBox ID="cardNumber" runat="server" CssClass="form-control" ></asp:TextBox>
                    <label  hidden="hidden" class="alert alert-danger"  id="AlertaCard" role="alert" >
                        Tarjeta de Credito Invalida
                    </label>
                </div>
                <div class="form-group" id="expiration-date">
                    <label>Fecha de Vencimiento</label>
                    <select >
                        <option value="01">Enero</option>
                        <option value="02">Febrero </option>
                        <option value="03">Marzo</option>
                        <option value="04">Abril</option>
                        <option value="05">Mayo</option>
                        <option value="06">Junio</option>
                        <option value="07">Julio</option>
                        <option value="08">Agosto</option>
                        <option value="09">Septiembre</option>
                        <option value="10">Octubre</option>
                        <option value="11">Noviembre</option>
                        <option value="12">Diciembre</option>
                    </select>
                    <select>
                        <option value="21">2021</option>
                        <option value="22">2022</option>
                        <option value="23">2023</option>
                        <option value="24">2024</option>
                        <option value="25">2025</option>
                        <option value="25">2026</option>
                    </select>
                </div>
                <div class="form-group" id="credit_cards">
                    <img class="img-responsive" src="/img/visa.png" id="visa" />
                    <img class="img-responsive" src="/img/mastercard.png" id="mastercard" />
                    <img class="img-responsive" src="/img/american-express.png" id="amex" />
                </div>
                <div class="form-group" id="pay-now">
                    <button type="submit" class="btn btn-success" id="confirm-purchase">Confirmar</button>
                    <a href="Default.aspx" class="btn btn-danger" >Cancelar</a>
                </div>
                 <%--<asp:button id="aceptar" Visible="false" runat="server" OnClientClick="AsignarValor();" />--%>
            </div>
        </div>
        <style>
            .img-responsive {
                display: inline-block !important;
                max-width: 25% !important;
            }

            .creditCardForm {
                max-width: 700px;
                background-color: #fff;
                margin: 100px auto;
                overflow: hidden;
                padding: 25px;
                color: #4c4e56;
            }

                .creditCardForm label {
                    width: 100%;
                    margin-bottom: 10px;
                }

                .creditCardForm .heading h1 {
                    text-align: center;
                    font-family: 'Open Sans', sans-serif;
                    color: #4c4e56;
                }

                .creditCardForm .payment {
                    float: left;
                    font-size: 18px;
                    padding: 10px 25px;
                    margin-top: 5px;
                    position: relative;
                }

                    .creditCardForm .payment .form-group {
                        float: left;
                        margin-bottom: 15px;
                    }

                    .creditCardForm .payment .form-control {
                        line-height: 40px;
                        height: auto;
                        padding: 0 16px;
                    }

                .creditCardForm .owner {
                    width: 63%;
                    margin-right: 10px;
                }

                .creditCardForm .CVV {
                    width: 35%;
                }

                .creditCardForm #card-number-field {
                    width: 63%;
                }

                .creditCardForm #expiration-date {
                    width: 49%;
                }

                .creditCardForm #credit_cards {
                    width: 50%;
                    margin-top: 25px;
                    text-align: right;
                }

                .creditCardForm #pay-now {
                    width: 100%;
                    margin-top: 25px;
                }

                .creditCardForm .payment .btn {
                    width: 100%;
                    margin-top: 3px;
                    font-size: 24px;
                    background-color: #2ec4a5;
                    color: white;
                }

                .creditCardForm .payment select {
                    padding: 10px;
                    margin-right: 15px;
                }

            .transparent {
                opacity: 0.2;
            }

            @media(max-width: 650px) {
                .creditCardForm .owner,
                .creditCardForm .CVV,
                .creditCardForm #expiration-date,
                .creditCardForm #credit_cards {
                    width: 100%;
                }

                .creditCardForm #credit_cards {
                    text-align: left;
                }
            }
        </style>

         <script>
             window.onload = init

             function init() {
                 document.getElementById('cardNumber')?.addEventListener('focusout', validarTarjeta)
                 document.getElementById('cardNumber')?.addEventListener('cvv', validarcvv)
             }

             function validarcvv() {
                 if (document.getElementById('cardNumber').value != null ||
                     document.getElementById('cardNumber').value != '') {
                     validarTarjeta()
                 }
             }

             function validarTarjeta() {
                 let lblAlertCard = document.getElementById('AlertaCard')
                 let lblAlertCVV = document.getElementById('AlertaCvv')
                 lblAlertCard.hidden = true
                 lblAlertCVV.hidden = true
                 document.getElementById('cardNumber').style.borderColor = "gray"
                 document.getElementById('cvv').style.borderColor = "gray"
                 let numeroTarjeta = document.getElementById('cardNumber').value

                 //Verificar si es mastercard
                 if (numeroTarjeta.match(/^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$/)) {
                     let cvv = document.getElementById('cvv').value
                     if (cvv == null || cvv.length != 3) {
                         document.getElementById('cvv').style.borderColor = "red"
                         lblAlertCVV.hidden = false
                     }
                     return;
                 }

                 //verificar Visa
                 if (numeroTarjeta.match(/^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/)) {
                     let cvv = document.getElementById('cvv').value
                     if (cvv == null || cvv.length != 3) {
                         document.getElementById('cvv').style.borderColor = "red"
                         lblAlertCVV.hidden = false
                     }
                     return;
                 }

                 //verificar Amex
                 if (numeroTarjeta.match(/^3[47][0-9-]{16}$/)) {
                     let cvv = document.getElementById('cvv').value
                     if (cvv == null || cvv.length != 4) {
                         document.getElementById('cvv').style.borderColor = "red"
                         lblAlertCVV.hidden = false
                     }
                     return;
                 }

                 document.getElementById('cardNumber').style.borderColor = "red"
                 lblAlertCard.hidden = false

             }
             function codificaCadena() {
                 let cadenaOriginal = document.getElementById('cardNumber').value
                 let cadenaCodificada = ""
                 let longitudDeCadena = strlen(cadenaOriginal)
                 let caracter = ""
                 for (let i = 0; i < longitudDeCadena; i++) {
                     caracter = dechex(ord(substr(cadenaOriginal, i, 1)))
                 }
                 let cadenaCodificada = caracter
                 
                 return cadenaCodificada;
             }
             //function AsignarValor() {
             //    document.getElementById('hidtest').value = cadenaCodificada;
             //}

             function descodificaCadena() {
                 let cadenaOriginal = document.getElementById('cardNumber').value
                 let cadenaDescodificada = ""
                 let longitudDeCadena = strlen(cadenaOriginal)
                 let caracter = ""
                 for (leti = 0; i < longitudDeCadena; i += 2) {
                     caracter = chr(hexdec(substr(cadenaOriginal, i, 2)))
                 }
                 cadenaDescodificada = caracter
                 document.getElementById('hidtest2').value = cadenaDescodificada;
                 return cadenaDescodificada;
             }


         </script>
    </form>
</body>

</html>

