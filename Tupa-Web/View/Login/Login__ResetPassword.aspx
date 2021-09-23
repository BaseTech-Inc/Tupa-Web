<%@ Page Title="Trocar Senha" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Login__ResetPassword.aspx.cs" Inherits="Tupa_Web.View.Login.Login__ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/login.css">
    <link rel="stylesheet" href="/Content/Css/form.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login_content">
        <div class="login full">
            <div class="menu">
                <div></div>       

                <asp:Image ID="Image1" runat="server" CssClass="logo" ImageUrl="~/Content/Images/logo.png"/>

                <div></div>
            </div>           

            <div class="form">
                <h1>Escolha uma nova senha!</h1>

                <div class="error" runat="server" id="errorMessage">                  
                </div>

                <div class="inputs">

                    <div class="input_icon_right input">
                        <label for="txtSenha" onClick="PasswordEyes.PasswordEyesEvent(this)" >
                            <span class="material-icons-outlined">
                                visibility
                            </span>
                        </label>
                        <asp:TextBox ID="txtSenha" name="txtSenha" runat="server" placeholder="Senha" TextMode="Password"></asp:TextBox>
                    </div>    
                    
                    <div class="input_icon_right input">
                        <label for="txtSenha" onClick="PasswordEyes.PasswordEyesEvent(this)" >
                            <span class="material-icons-outlined">
                                visibility
                            </span>
                        </label>
                        <asp:TextBox ID="txtConfirmarSenha" name="txtSenha" runat="server" placeholder="Confimar Senha" TextMode="Password"></asp:TextBox>
                    </div>   
                </div>
                
                <asp:Button 
                    ID="btnChangePassword"
                    Text="Enviar"
                    runat="server"
                    CssClass="button secondary-button" OnClick="btnChangePassword_Click"  />
            </div>            

            <div></div>
        </div>
    </div>

    <footer class="container">
        <div class="container_wrapper">
            <p>© BaseTech, Inc</p>

            <ul>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Terms">Termos de serviço</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Privacy">Política de privacidade</asp:HyperLink>
                </li>
            </ul>
        </div>
    </footer>

    <script src="/Scripts/PasswordEyes.js"></script>
</asp:Content>
