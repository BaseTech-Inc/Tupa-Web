﻿<%@ Page Title="Planos" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Register__Plan.aspx.cs" Inherits="Tupa_Web.View.Register.Register__Plan" 
    MetaKeywords="NoHeader, NoFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/login.css">
    <link rel="stylesheet" href="/Content/Css/form.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login_content">
        <div class="login">
            <div class="menu">
                <div></div>       

                <asp:Image ID="Image1" runat="server" CssClass="logo" ImageUrl='<%# "~/Content/Images/logo" + ColorTheme() + ".png" %>'/>

                <div></div>
            </div>   

            <div class="form">
                <div class="progress">
                    <div class="ball target card">
                        <h3>1</h3>
                    </div>
                    <div class="line target-full"></div>
                    <div class="ball  target card">
                        <h3>2</h3>
                    </div>
                    <div class="line target"></div>
                    <div class="ball card tooltip">
                        <h3>3</h3>
                        <span class="tooltiptext card">Verificar E-mail</span>
                    </div>
                </div>

                <h1>Escolha um plano</h1>

                <div class="error" runat="server" id="errorMessage">                  
                </div>
                
                <div class="radio-buttons">
                    <div>
                        <input type="radio" name="select" id="optBasic" checked>
                        <label for="optBasic" class="option">
                        <div class="description">
                            <h3>Based  <span class="tag">FREE</span></h3>
                            <p>Plano básico.</p>
                        </div>                        
                        
                        <div class="dot material-icons-outlined"></div>
                    </label>
                    </div>
                    <div>
                        <input type="radio" name="select" id="optPremium" disabled>
                    
                        <label for="optPremium" class="option">
                            <div class="description">
                                <h3>Poggers <span class="tag">R$ 99,00</span></h3>
                                <p>Plano feito e customizado para você.</p>
                            </div>                        
                        
                            <div class="dot material-icons-outlined"></div>
                        </label>
                    </div>                    
                </div>

                <asp:Button 
                    ID="btnContinuar"
                    Text="Continuar"
                    OnClick="btnContinuar_Click"
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
    </script>
</asp:Content>
