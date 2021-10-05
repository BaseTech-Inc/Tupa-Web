<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Login__GeneratePasswordReset.aspx.cs" Inherits="Tupa_Web.View.Login.Login_GeneratePasswordReset" 
    MetaKeywords="NoHeader, NoFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/login.css">
    <link rel="stylesheet" href="/Content/Css/form.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login_content">
        <div class="login full">
            <div class="menu">
                <asp:HyperLink ID="btnReturn" runat="server">
                    <div class="return">
                        <div class="icon card">
                            <span class="material-icons-outlined">
                                chevron_left
                            </span>
                        </div>  
                    </div>
                </asp:HyperLink>         

                <asp:Image ID="Image1" runat="server" CssClass="logo" ImageUrl="~/Content/Images/logo.png"/>

                <div></div>
            </div>           

            <div class="form">
                <h1>Enviar email para trocar senha!</h1>

                <div class="error" runat="server" id="errorMessage">                  
                </div>

                <div class="inputs">

                    <div class="input">
                        <asp:Label ID="lblEmail" runat="server" CssClass="label">Email</asp:Label>
                        <asp:TextBox ID="txtEmail" name="email" runat="server" placeholder="example@example.com"></asp:TextBox>
                    </div>   
                </div>
                
                <asp:Button 
                    ID="btnChangePassword"
                    Text="Enviar"
                    runat="server"
                    CssClass="button secondary-button"  />
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
