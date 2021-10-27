<%@ Page Title="Login" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tupa_Web.View.Login.Login"
        MetaKeywords="NoHeader, NoFooter" %>
<%@ Import Namespace="System.Web.Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://apis.google.com/js/client:platform.js?onload=start" async defer>
    </script>

    <link rel="stylesheet" href="/Content/Css/login.css">
    <link rel="stylesheet" href="/Content/Css/form.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login_content">
        <div class="login">
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

                <asp:Image ID="Image1" runat="server" CssClass="logo" ImageUrl='<%# "~/Content/Images/logo" + ColorTheme() + ".png" %>'/>

                <div></div>
            </div>            


            <div class="form">
                <h1>Bem vindo, Bro!</h1>

                <div class="error" runat="server" id="errorMessage">                  
                </div>
                
                <div class="google_button button_icon_left">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Images/google.png" />
                    <button type="button" class="primary-button" id="signinButton">Entre pelo Google</button>
                </div>
               
                <div class="line">
                    <div></div>
                    <p>ou entre usando email</p>
                </div>

                <div class="inputs">
                    <div class="input">
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" autocomplete="off"></asp:TextBox>
                    </div>

                    <div class="input_icon_right input">
                        <label for="txtSenha" onClick="PasswordEyes.PasswordEyesEvent(this)" >
                            <span class="material-icons-outlined">
                                visibility
                            </span>
                        </label>
                        <asp:TextBox ID="txtSenha" name="txtSenha" runat="server" placeholder="Senha" TextMode="Password"></asp:TextBox>
                    </div>                    
                </div>

                <p class="caption">Esqueceu sua <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl='<%# Page.GetRouteUrl("Login_GeneratePasswordReset", new { }) + "?ReturnUrl=" + HttpContext.Current.Request.Url.AbsoluteUri %>' CssClass="caption land__link">Senha</asp:HyperLink>?</p>
                
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
    <script src="https://apis.google.com/js/platform.js?onload=onLoad" async defer></script>
    <script>
        Carousel.Setup(
            Carousel.types.Opacity, 
            true)

        let auth2;

        function start() {
            gapi.load('auth2', function () {
                auth2 = gapi.auth2.init({
                    client_id: '<% Response.Write(WebConfigurationManager.AppSettings["client_id"]); %>'
                    // Scopes to request in addition to 'profile' and 'email'
                    //scope: 'additional_scope'
                });
            });
        }

        let signinButton = document.querySelector('#signinButton')

        signinButton.addEventListener('click', () => {
            auth2.grantOfflineAccess().then(signInCallback);
        })

        function signInCallback(authResult) {
            if (authResult['code']) {
                DoPostBack('signinButton', authResult['code'])
            } else {
                // There was an error.
            }
        }

        function DoPostBack(obj, parameter = "") {
            __doPostBack(obj.id, parameter)
        }
    </script>
</asp:Content>
