<%@ Page Title="Login" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tupa_Web.View.Login.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/login.css">
    <link rel="stylesheet" href="/Content/Css/form.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login_content">
        <div class="login">
            <div class="menu">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/">
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
                <h1>Bem vindo, Bro!</h1>

                <div class="error disabled" runat="server" id="errorMessage">
                    <div class="error_wrapper">
                        <p runat="server" id="textErrorMessage" title="Incorrect username or password.">Error na criação do usuário</p>
                        <span class="close_button">
                            <span class="material-icons">
                            close
                            </span>
                        </span>
                    </div>                    
                </div>
                
                <div class="google_button button_icon_left">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Images/google.png" />
                    <input type="button" class="primary-button" value="Entre pelo Google">
                </div>
               
                <div class="line">
                    <div></div>
                    <p>ou entre usando email</p>
                </div>

                <div class="inputs">
                    <div class="input">
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                    </div>

                    <div class="input_icon_right input">
                        <label for="" onClick="PasswordEyes.PasswordEyesEvent(this)" >
                            <span class="material-icons-outlined">
                                visibility
                            </span>
                        </label>
                        <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" TextMode="Password"></asp:TextBox>
                    </div>                    
                </div>

                <p class="caption">Você tem <a href="./register.html" class="caption">Cadastro</a>?</p>
                
                <asp:Button 
                    ID="btnLogin"
                    Text="Entre Bro!"
                    OnClick="btnLogin_Click"
                    runat="server"
                    CssClass="button secondary-button"  />
            </div>            

            <div></div>
        </div>
        <div class="slider_content">
            <div class="bg"></div>            

            <div class="slider">
                <div class="carousel-wrapper">
                    <div class="carousel">
                        <div class="slide_inner initial">
                            <h1>Com Tupã você pode!</h1>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Images/clock_ilustraion_white_theme.svg" />
                            <h3>Previsões Meteorologicas</h3>
                            <p>Previsões de até 5 dias baseadas na sua localização ou regiões buscadas.</p>
                        </div>
                        <div class="slide_inner">
                            <h1>Com Tupã você pode!</h1>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Content/Images/cellphone_ilustraion_white_theme.svg" />
                            <h3>Alertas de Enchentes</h3>
                            <p>Alertas de enchentes em locais de risco, com monitoriamento da sua localização.</p>
                        </div>
                        <div class="slide_inner">
                            <h1>Com Tupã você pode!</h1>
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Content/Images/map_ilustration_white_theme.svg" />
                            <h3>Mapa Meteorologico</h3>
                            <p>Mapa meteorologico com atulizações em tempo real, com alertas de enchentes.</p>
                        </div>
                    </div>                    
                </div>

                <div class="slider_buttons">
                    <div class="slider_progress">
                    </div>
                    <div class="slider_arrows">
                        <div class="left slide__button--prev">
                            <div class="icon card">
                                <span class="material-icons-outlined">
                                    chevron_left
                                </span>
                            </div>  
                        </div>
                        <div class="right slide__button--next">
                            <div class="icon card">
                                <span class="material-icons-outlined">
                                    chevron_right
                                </span>
                            </div>  
                        </div>
                    </div>
                </div>                
            </div>            
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
    <script src="/Scripts/Carousel.js"></script>
    <script>
        Carousel.Setup(
            Carousel.types.Opacity, 
            true)

        let close_button = document.querySelector('.close_button')
        let errorMessage = document.querySelector('.error')

        console.log(errorMessage)

        close_button.addEventListener('click', () => {
            errorMessage.className += " disabled"
        })
    </script>
</asp:Content>
