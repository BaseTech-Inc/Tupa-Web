<%@ Page Title="Inicío" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Tupa_Web.View.Home.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/intlTelInput.min.css">

    <link rel="stylesheet" href="/Content/Css/index.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_wrapper header">
        <div>
            <p class="caption">Condição atual / <span class="caption">Congelante</span></p>

            <h1>Previsões Meteorologicas</h1>

            <p>Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas.</p>

            <a href="#" class="secondary-button">Crie a sua conta</a>
        </div>

        <asp:Image ID="imgGlobe" runat="server" ImageUrl="~/Content/Images/globe.png" />
    </div>

    <div class="container_wrapper cards">
        <div class="card">
            <h3>Previsões Meteorologicas</h3>
            <p>Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas.</p>
        </div>
        <div class="card">
            <h3>Alertas de Enchentes</h3>
            <p>Alertas de enchentes em locais de risco e alterações climáticas, com monitoriamento da sua localização atual ou regiões salvadas como favoritas.</p>
        </div>
        <div class="card">
            <h3>Mapa Meteorologico</h3>
            <p>Mapa meteorologico com atualizações em tempo real, alertas de enchentes e alterações climáticas.</p>
        </div>
    </div>

    <div class="container_wrapper phone">
        <div class="card">
            <asp:Image ID="imgPhone" runat="server" ImageUrl="~/Content/Images/phone.png" />

            <div>
                <h1>Mapa meteorologico</h1>
                <p>Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas.Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas.</p>
                
                <div class="progress">
                    <div></div>
                    <div class="target"></div>
                    <div></div>
                    <div></div>
                </div>
            </div>
        </div>
    </div>

    <div class="comments">
        <div class="container_wrapper">
            <h1>Comentário de alguns usuários</h1>

            <div class="buttons">
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

        <div class="carousel-wrapper">
            <div class="carousel">
                <div class="card slide_inner">
                    <div class="title">
                        <div class="user">
                            <div class="img"></div>
                            <div class="perfil">
                                <h3>Gabriel Domingues Bouças</h3>
                                <p>São Paulo, SP</p>
                            </div>
                        </div>
                        <div class="social">
                            <asp:Image ID="imgTwitter" runat="server" ImageUrl="~/Content/Images/twitter-brands.svg" />
                        </div>
                    </div>
                    <div class="body">
                        <p>Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas...</p>
                    </div>
                </div>
                <div class="card slide_inner">
                    <div class="title">
                        <div class="user">
                            <div class="img"></div>
                            <div class="perfil">
                                <h3>Gabriel Domingues Bouças</h3>
                                <p>São Paulo, SP</p>
                            </div>
                        </div>
                        <div class="social">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/twitter-brands.svg" />
                        </div>
                    </div>
                    <div class="body">
                        <p>Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas...</p>
                    </div>
                </div>
                <div class="card slide_inner">
                    <div class="title">
                        <div class="user">
                            <div class="img"></div>
                            <div class="perfil">
                                <h3>Gabriel Domingues Bouças</h3>
                                <p>São Paulo, SP</p>
                            </div>
                        </div>
                        <div class="social">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Images/twitter-brands.svg" />
                        </div>
                    </div>
                    <div class="body">
                        <p>Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas...</p>
                    </div>
                </div>
                <div class="card slide_inner">
                    <div class="title">
                        <div class="user">
                            <div class="img"></div>
                            <div class="perfil">
                                <h3>Gabriel Domingues Bouças</h3>
                                <p>São Paulo, SP</p>
                            </div>
                        </div>
                        <div class="social">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Images/twitter-brands.svg" />
                        </div>
                    </div>
                    <div class="body">
                        <p>Previsões meteorologicas de até 5 dias baseadas na sua localização atual ou regiões buscadas...</p>
                    </div>
                </div>
            </div>
        </div>

        <div class="container_wrapper responsive">
            <div class="buttons">
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

    <div class="play_store">
        <div class="title">
            <h1>Receba Alertas e faça Monitoramentos de Onde Estiver</h1>
        </div> 
        <div class="input">
            <input type="tel" id="phone" placeholder="Coloque seu número de telefone" class="card">
            <a href="#" class="secondary-button">Enviar link</a>
        </div>
        <div class="download">
            <asp:Image ID="imgGooglePlayBadge" runat="server" ImageUrl="~/Content/Images/google-play-badge.png" />

            <div class="social">
                <div class="stars">
                    <span class="material-icons-outlined">
                        star
                    </span>
                    <span class="material-icons-outlined">
                        star
                    </span>
                    <span class="material-icons-outlined">
                        star
                    </span>
                    <span class="material-icons-outlined">
                        star
                    </span>
                    <span class="material-icons-outlined">
                        star
                    </span>
                </div> 

                <p class="caption">523k visualizações</p>
            </div>                               
        </div>
    </div>

    <script src="/Scripts/intlTelInput.min.js"></script>
    <script src="/Scripts/Carousel.js"></script>
    <script src="/Scripts/AudioHorn.js"></script>
    <script>
        Carousel.Setup(
            Carousel.types.Move, 
            false)

        var input = document.querySelector("#phone")

        window.intlTelInput(input, {
            // any initialisation options go here
        })

        let horn = document.querySelector('.PlayAudio')

        AudioHorn.Setup(horn)
    </script>
</asp:Content>
