<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioDeCompra.aspx.cs" Inherits="GUI.FormularioDeCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="creditCardForm">
    <div class="heading">
        <h1>Confirmar Compra</h1>
    </div>

    <div class="payment">
            <div class="form-group" id="card-precio">
                <label for="precio">Importe Total</label>
                <asp:TextBox ID="PrecioCompra" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group owner">
                <label for="owner">Nombre y Apellido</label>
                <input type="text" class="form-control" required=true id="owner">
            </div>
            <div class="form-group CVV">
                <label for="cvv">CVV</label>
                <input type="text" class="form-control"  required=true id="cvv">
            </div>
            <div class="form-group" id="card-number-field">
                <label for="cardNumber">Numero de Tarjeta</label>
                <input type="text" class="form-control" required=true id="cardNumber">
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
                <label  hidden="true"  id="AlertaCompra" role="alert">
                     
                </label>
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

    </script>
   <script src="https://code.jquery.com/jquery-3.5.1.slim.js" integrity="sha256-DrT5NfxfbHvMHux31Lkhxg42LY6of8TaYyK50jnxRnM=" crossorigin="anonymous"></script>

</asp:Content>
