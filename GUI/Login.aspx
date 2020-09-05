<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height:100vh">
            <div class="col-4">
                <div class="card">
                    <div class="card-body">
                        
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="username"/>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" type="password" cssclass="form-control" id="password"/>
                            </div>
                            <asp:Button runat="server" content="login" id="sendlogin" cssclass="btn btn-primary" OnClick="sendlogin_Click"/>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
