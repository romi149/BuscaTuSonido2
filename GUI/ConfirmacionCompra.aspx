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
                        <asp:CheckBox runat="server" ID="chkMucho" />
                        <label id="1">Muy fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="ChkPoco" />
                        <label id="2">Algo fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="chk" />
                        <label id="3">Fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox1" />
                        <label id="4">Nada fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox2" />
                        <label id="5">Difícil</label>
                    </div>
                </div>
                <br />
                <div>
                    <h4>¿Te resultó fácil encontrar el producto que buscabas?</h4>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox3" />
                        <label id="1">Muy fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox4" />
                        <label id="2">Algo fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox5" />
                        <label id="3">Fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox6" />
                        <label id="4">Nada fácil</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox7" />
                        <label id="5">Difícil</label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div>
                    <h4>¿Qué tan satisfecho estás con la disponibilidad de los productos?</h4>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox13" />
                        <label id="1">Muy satisfecho</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox14" />
                        <label id="2">Algo satisfecho</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox15" />
                        <label id="3">Satisfecho</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox16" />
                        <label id="4">Neutro</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox17" />
                        <label id="5">Nada satisfecho</label>
                    </div>
                </div>
                <br />
                <div>
                    <h4>¿Qué tan probable es que nos recomiendes?</h4>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox8" />
                        <label id="1">Muy probable</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox9" />
                        <label id="2">Algo probable</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox10" />
                        <label id="3">Probable</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox11" />
                        <label id="4">Nada probable</label>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBox12" />
                        <label id="5">No lo recomendaría</label>
                    </div>
                </div>
            </div>
        </div>
     </div>
        <br />
        <div>
            <asp:Button runat="server" ID="btnOpinar" CssClass="btn btn-info" Text="Enviar Opinión" Width="90%" />
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

    #btnOpinar{
        text-align:center;
    }
    

</style>    
</asp:Content>