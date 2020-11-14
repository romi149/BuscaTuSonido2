<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioDeCompra.aspx.cs" Inherits="GUI.FormularioDeCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="creditCardForm">
    <div class="heading">
        <h1>Confirmar Compra</h1>
    </div>
    <div class="payment">
    
            <div class="form-group owner">
                <label for="owner">Nombre y Apellido</label>
                <input type="text" class="form-control" id="owner">
            </div>
            <div class="form-group CVV">
                <label for="cvv">CVV</label>
                <input type="text" class="form-control" id="cvv">
            </div>
            <div class="form-group" id="card-number-field">
                <label for="cardNumber">Numero de Tarjeta</label>
                <input type="text" class="form-control" id="cardNumber">
            </div>
            <div class="form-group" id="expiration-date">
                <label>Fecha de Vencimiento</label>
                <select>
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
                    <option value="20"> 2020</option>
                    <option value="21"> 2021</option>
                    <option value="22"> 2022</option>
                    <option value="23"> 2023</option>
                    <option value="24"> 2024</option>
                    <option value="25"> 2025</option>
                </select>
            </div>
            <div class="form-group" id="credit_cards">
                <img class="img-responsive" src="/img/visa.png" id="visa">
                <img class="img-responsive" src="/img/mastercard.png" id="mastercard">
                <img class="img-responsive" src="/img/american-express.png" id="amex">
            </div>
            <div class="form-group" id="pay-now">
                <button type="submit" class="btn btn-default" id="confirm-purchase">Confirmar</button>
            </div>
       
    </div>
</div>
    <style>
        .img-responsive{
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
                margin-top: 20px;
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
                width: 100%;
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
        var owner = $('#owner'),
            cardNumber = $('#cardNumber'),
            cardNumberField = $('#card-number-field'),
            CVV = $("#cvv"),
            mastercard = $("#mastercard"),
            confirmButton = $('#confirm-purchase'),
            visa = $("#visa"),
            amex = $("#amex");

        cardNumber.payform('formatCardNumber');
        CVV.payform('formatCardCVC');

        cardNumber.keyup(function () {
            amex.removeClass('transparent');
            visa.removeClass('transparent');
            mastercard.removeClass('transparent');

            if ($.payform.validateCardNumber(cardNumber.val()) == false) {
                cardNumberField.removeClass('has-success');
                cardNumberField.addClass('has-error');
            } else {
                cardNumberField.removeClass('has-error');
                cardNumberField.addClass('has-success');
            }

            if ($.payform.parseCardType(cardNumber.val()) == 'visa') {
                mastercard.addClass('transparent');
                amex.addClass('transparent');
            } else if ($.payform.parseCardType(cardNumber.val()) == 'amex') {
                mastercard.addClass('transparent');
                visa.addClass('transparent');
            } else if ($.payform.parseCardType(cardNumber.val()) == 'mastercard') {
                amex.addClass('transparent');
                visa.addClass('transparent');
            }
        });

        confirmButton.click(function (e) {
            e.preventDefault();

            var isCardValid = $.payform.validateCardNumber(cardNumber.val());
            var isCvvValid = $.payform.validateCardCVC(CVV.val());

            if (owner.val().length < 5) {
                alert("Wrong owner name");
            } else if (!isCardValid) {
                alert("Wrong card number");
            } else if (!isCvvValid) {
                alert("Wrong CVV");
            } else {
                // Everything is correct. Add your form submission code here.
                alert("Everything is correct");
            }
        });

    </script>

</asp:Content>
