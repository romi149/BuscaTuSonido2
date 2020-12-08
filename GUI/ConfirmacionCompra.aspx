<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionCompra.aspx.cs" Inherits="GUI.ConfirmacionCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 70vh; display: flex; align-items: center;">
        <div class="container">
            <img class="img-responsive" src="Imagenes/Graciasxtucompra2.jpg" style="margin: auto; height:90%; width: 70%;">
        </div>
    </div>
    <br />
    <div class="body-content">
        <h2>Queremos conocer tu opinión</h2>
        <br />
        <div class="row">
            <div class="col-md-6">
                <div>
                    <h4>¿Qué tan fácil te pareció el proceso de compra?</h4>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg1Punt1" GroupName="Pregunta1" />
                        <label id="lbl1">Muy fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg1Punt2" GroupName="Pregunta1" />
                        <label id="lbl2">Fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg1Punt3" GroupName="Pregunta1" />
                        <label id="lbl3">Algo fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg1Punt4" GroupName="Pregunta1" />
                        <label id="lbl4">Nada fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg1Punt5" GroupName="Pregunta1" />
                        <label id="lbl5">Difícil</label>
                    </div>
                </div>
                <br />
                <div>
                    <h4>¿Te resultó fácil encontrar el producto que buscabas?</h4>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg2Punt1" GroupName="Pregunta2" />
                        <label id="lbl6">Muy fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg2Punt2" GroupName="Pregunta2" />
                        <label id="lbl7">Fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg2Punt3" GroupName="Pregunta2" />
                        <label id="lbl8">Algo fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg2Punt4" GroupName="Pregunta2" />
                        <label id="lbl9">Nada fácil</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg2Punt5" GroupName="Pregunta2" />
                        <label id="lbl10">Difícil</label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div>
                    <h4>¿Qué tan satisfecho estás con la disponibilidad de los productos?</h4>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg3Punt1" GroupName="Pregunta3" />
                        <label id="lbl11">Muy satisfecho</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg3Punt2" GroupName="Pregunta3" />
                        <label id="lbl12">Satisfecho</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg3Punt3" GroupName="Pregunta3" />
                        <label id="lbl13">Algo satisfecho</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg3Punt4" GroupName="Pregunta3" />
                        <label id="lbl14">Neutro</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg3Punt5" GroupName="Pregunta3" />
                        <label id="lbl15">Nada satisfecho</label>
                    </div>
                </div>
                <br />
                <div>
                    <h4>¿Qué tan probable es que nos recomiendes?</h4>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg4Punt1" GroupName="Pregunta4" />
                        <label id="lbl16">Muy probable</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg4Punt2" GroupName="Pregunta4" />
                        <label id="lbl17">Probable</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg4Punt3" GroupName="Pregunta4" />
                        <label id="lbl18">Algo probable</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg4Punt4" GroupName="Pregunta4" />
                        <label id="lbl19">Nada probable</label>
                    </div>
                    <div>
                        <asp:RadioButton runat="server" ID="CheckPreg4Punt5" GroupName="Pregunta4" />
                        <label id="lbl20">No lo recomendaría</label>
                    </div>
                </div>
            </div>
        </div>
     </div>
        <br />
        <br />
        <div class="button">
            <asp:Button runat="server" ID="btnOpinar" CssClass="btn btn-info" Text="Enviar Opinión" Width="90%" OnClick="btnOpinar_Click" />
        </div>

<style>
    .body-content{
        text-align:left;
    }

    h4{
        color:darkblue;
        text-align:left;
    }
    h2{
        color:darkturquoise;
        text-align:center;
        
    }

    .button{
        text-align:center;
        width:100%;

    }
    

</style>    
</asp:Content>