<%@ Page Title="Inicío" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Tupa_Web.View.Home.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/intlTelInput.min.css">

    <link rel="stylesheet" href="/Content/Css/index.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">
        <div class="container_wrapper">
            <div class="description">
                <div></div>

                <div>
                    <h1>Receba Alertas e Faça Monitoramentos de Onde e Quando Estiver</h1>
                    <p>Tupã facilita a sua busca por enchentes e previsões meteriologicas, garantidando a sua segurança.</p>
                    <asp:HyperLink ID="HyperLinkCta" runat="server" CssClass="cta" NavigateUrl="~/Register" >
                        <span>Torne-se um bro</span>
                        <svg width="13px" height="10px" viewBox="0 0 13 10">
                            <path d="M1,5 L11,5"></path>
                            <polyline points="8 1 12 5 8 9"></polyline>
                        </svg>
                    </asp:HyperLink>
                </div>
                    
                <div class="mouse">
                    <span class="material-icons-outlined">
                    mouse
                    </span>

                    <p>Scroll para mais</p>
                </div>
            </div>
            <div class="illustration">
                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="549" height="541" viewBox="0 0 549 541">
                    <defs>
                        <style>
                            .cls-1, .cls-10, .cls-11, .cls-7 {
                                fill: #fff;
                            }
                        
                            .cls-2 {
                                clip-path: url(#clip-path);
                            }
                        
                            .cls-3, .cls-4 {
                                fill: #eaf2fb;
                                stroke: rgba(0,0,0,0);
                                stroke-linecap: round;
                            }
                        
                            .cls-3 {
                                stroke-linejoin: round;
                            }
                        
                            .cls-4 {
                                stroke-linejoin: bevel;
                            }
                        
                            .cls-5, .cls-9 {
                                fill: #2485f3;
                            }
                        
                            .cls-13, .cls-6 {
                                fill: none;
                            }
                        
                            .cls-6 {
                                stroke: #2485f3;
                                stroke-width: 4px;
                            }
                        
                            .cls-7, .cls-9 {
                                stroke: rgba(0,0,0,0.14);
                            }
                        
                            .cls-8 {
                                fill: rgba(0,0,0,0.14);
                            }
                        
                            .cls-10 {
                                opacity: 0.89;
                            }
                        
                            .cls-11 {
                                opacity: 0.6;
                            }
                        
                            .cls-12 {
                                stroke: none;
                            }
                        
                            .cls-14 {
                                filter: url(#Retângulo_1108-2);
                            }
                        
                            .cls-15 {
                                filter: url(#Retângulo_1108);
                            }

                            #route {
                                stroke-dasharray: 450;
                                stroke-dashoffset: 450;
                                animation: dash 1s ease-in-out forwards;
                                animation-delay: .2s;
                            }

                            #point {
                                animation: opacity .2s ease-in-out forwards;
                                animation-delay: 1s;
                                opacity: 0;
                            }

                            #points {
                                animation: opacity .2s ease-in-out forwards;
                                opacity: 0;
                            }

                            #notification {
                                animation: opacity .4s ease-in-out forwards;
                                animation-delay: 1s;
                                opacity: 0;
                            }

                            #notification-2 {
                                animation: opacity .4s ease-in-out forwards;
                                animation-delay: .4s;
                                opacity: 0;
                            }

                            @keyframes opacity {
                                from {
                                    opacity: 0;
                                }
                                to {
                                    opacity: 1;
                                }
                            }

                            @keyframes dash {
                                from {
                                    stroke-dashoffset: 450;
                                }
                                to {
                                    stroke-dashoffset: 0;
                                }
                            }
                        </style>
                        <clipPath id="clip-path">
                            <rect id="Retângulo_1107" data-name="Retângulo 1107" class="cls-1" width="386" height="541" rx="48" transform="translate(518 325)"/>
                        </clipPath>
                        <filter id="Retângulo_1108" x="283" y="31" width="266" height="87" filterUnits="userSpaceOnUse">
                            <feOffset dy="3" input="SourceAlpha"/>
                            <feGaussianBlur stdDeviation="3" result="blur"/>
                            <feFlood flood-opacity="0.039"/>
                            <feComposite operator="in" in2="blur"/>
                            <feComposite in="SourceGraphic"/>
                        </filter>
                        <filter id="Retângulo_1108-2" x="0" y="339" width="266" height="87" filterUnits="userSpaceOnUse">
                            <feOffset dy="3" input="SourceAlpha"/>
                            <feGaussianBlur stdDeviation="3" result="blur-2"/>
                            <feFlood flood-opacity="0.039"/>
                            <feComposite operator="in" in2="blur-2"/>
                            <feComposite in="SourceGraphic"/>
                        </filter>
                    </defs>
                    <g id="illustration_map" transform="translate(-107 -69)">
                        <g id="map" class="cls-2" transform="translate(-320 -256)">
                            <path id="Caminho_5217" data-name="Caminho 5217" class="cls-3" d="M-2100.506,9418.391h52.2l57.133,32.659v84.994h-109.33Z" transform="translate(2619 -8944)"/>
                            <path id="Caminho_5218" data-name="Caminho 5218" class="cls-3" d="M-1971.715,9477.191v-22.164h82.322v22.164Z" transform="translate(2619 -8944)"/>
                            <path id="Caminho_5219" data-name="Caminho 5219" class="cls-3" d="M-1971.715,9477.191v-22.164h49.584v22.164Z" transform="translate(2720.782 -8943.975)"/>
                            <path id="Caminho_5220" data-name="Caminho 5220" class="cls-3" d="M-1971.715,9496.045v-41.018H-1820v20.694l-95.84,20.323Z" transform="translate(2619 -8904)"/>
                            <path id="Caminho_5221" data-name="Caminho 5221" class="cls-3" d="M-2910,9765.941h176.065v79.95h-83.556L-2910,9943.876Z" transform="translate(3428 -9155)"/>
                            <path id="Caminho_5222" data-name="Caminho 5222" class="cls-3" d="M-2910,9966.718h46.823v54.7H-2910Z" transform="translate(3428 -9155)"/>
                            <path id="Caminho_5223" data-name="Caminho 5223" class="cls-3" d="M-2843.34,10021.42v-73.938h-42.68l76.945-82.956H-2734v58.31h-75.075v19.837H-2734v78.748Z" transform="translate(3428 -9155)"/>
                            <path id="Caminho_5224" data-name="Caminho 5224" class="cls-3" d="M-2721.069,10021.42h197.041v-113.2h-86.854v35.166h-110.187Z" transform="translate(3428 -9155)"/>
                            <path id="Caminho_5225" data-name="Caminho 5225" class="cls-3" d="M-2611,9889.016h87v-54.557h-87Z" transform="translate(3428 -9155)"/>
                            <path id="Caminho_5226" data-name="Caminho 5226" class="cls-3" d="M-2611,9907.513h87v-73.055h-87Z" transform="translate(3428 -9247.262)"/>
                            <path id="Caminho_5227" data-name="Caminho 5227" class="cls-3" d="M-2611,9891.395h87v-56.937h-87Z" transform="translate(3428 -9323.405)"/>
                            <path id="Caminho_5228" data-name="Caminho 5228" class="cls-3" d="M-2611,9891.395h87v-96.013l-87,63.669Z" transform="translate(3428 -9399.55)"/>
                            <path id="Caminho_5229" data-name="Caminho 5229" class="cls-3" d="M-2611,9889.016h35.34v-90.437l-23.389,31.486H-2611Z" transform="translate(3318 -9121)"/>
                            <path id="Caminho_5230" data-name="Caminho 5230" class="cls-3" d="M-2611,9889.016h38.029V9725.638l-38.029,49.8Z" transform="translate(3371.622 -9121)"/>
                            <path id="Caminho_5231" data-name="Caminho 5231" class="cls-4" d="M-2716.109,9841.326l72.207-93.782-72.207,17.073Z" transform="translate(3428 -9155)"/>
                            <path id="Caminho_5232" data-name="Caminho 5232" class="cls-3" d="M-2910,9609.475h54.516l85.421-51.019H-2680V9647h50.83v-42.605l105.17-75.177v-48.764h-386Z" transform="translate(3428 -9155)"/>
                            <path id="Caminho_5233" data-name="Caminho 5233" class="cls-3" d="M-2698,9646.845v-70.735h-66.052l-72.352,43.8,48.126,26.932Z" transform="translate(3428 -9155)"/>
                        </g>
                        <circle id="point" class="cls-5" cx="6" cy="6" r="6" transform="translate(482.5 194)"/>
                        <path id="route" class="cls-6" d="M-3271,9649h107.425V9522.912l57.059-74.917V9326.652" transform="translate(3595 -9127)"/>
                        <g id="points">
                            <circle id="point-2" data-name="point" class="cls-5" cx="16" cy="16" r="16" transform="translate(296 506)"/>
                            <circle id="point-3" data-name="point" class="cls-1" cx="6" cy="6" r="6" transform="translate(306 516)"/>
                        </g>
                        <g id="notification" transform="translate(-584 -652)">
                            <g class="cls-15" transform="matrix(1, 0, 0, 1, 691, 721)">
                            <g id="Retângulo_1108-3" data-name="Retângulo 1108" class="cls-7" transform="translate(292 37)">
                                <rect class="cls-12" width="248" height="69" rx="32"/>
                                <rect class="cls-13" x="0.5" y="0.5" width="247" height="68" rx="31.5"/>
                            </g>
                            </g>
                            <rect id="Retângulo_1109" data-name="Retângulo 1109" class="cls-8" width="90" height="13" rx="6.5" transform="translate(1058 776)"/>
                            <rect id="Retângulo_1110" data-name="Retângulo 1110" class="cls-8" width="137" height="5" rx="2" transform="translate(1058 797)"/>
                            <circle id="Elipse_135" data-name="Elipse 135" class="cls-8" cx="19" cy="19" r="19" transform="translate(1007 773)"/>
                            <rect id="Retângulo_1112" data-name="Retângulo 1112" class="cls-8" width="50" height="5" rx="2" transform="translate(1058 808)"/>
                        </g>
                        <g id="notification-2" data-name="notification" transform="translate(-867 -344)">
                            <g class="cls-14" transform="matrix(1, 0, 0, 1, 974, 413)">
                            <g id="Retângulo_1108-4" data-name="Retângulo 1108" class="cls-9" transform="translate(9 345)">
                                <rect class="cls-12" width="248" height="69" rx="32"/>
                                <rect class="cls-13" x="0.5" y="0.5" width="247" height="68" rx="31.5"/>
                            </g>
                            </g>
                            <rect id="Retângulo_1109-2" data-name="Retângulo 1109" class="cls-10 " width="90" height="13" rx="6.5" transform="translate(1058 776)"/>
                            <rect id="Retângulo_1110-2" data-name="Retângulo 1110" class="cls-11 " width="137" height="5" rx="2" transform="translate(1058 797)"/>
                            <circle id="Elipse_135-2" data-name="Elipse 135" class="cls-8" cx="19" cy="19" r="19" transform="translate(1007 773)"/>
                            <rect id="Retângulo_1112-2" data-name="Retângulo 1112" class="cls-11 " width="50" height="5" rx="2" transform="translate(1058 808)"/>
                        </g>
                    </g>
                </svg>
            </div>
        </div>
    </div>  

    <div class="container_wrapper features">
        <div class="illustration">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Content/Images/features.svg" />
        </div>
        <div class="feature">
            <h1>Oferecemos muitos recursos que você pode aproveitar</h1>
            <p>Você pode explorar os recursos que oferecemos com diversão e ter suas próprias funções de cada recurso.</p>

            <ul>
                <li>
                    <div class="dot material-icons-outlined">
                        done
                    </div>
                    Mapas meteorologicos.</li>
                <li>
                    <div class="dot material-icons-outlined">
                        done
                    </div>
                    Alertas em tempo real.</li>
                <li>
                    <div class="dot material-icons-outlined">
                        done
                    </div>
                    Previsões meteorologicos.</li>
                <li>
                    <div class="dot material-icons-outlined">
                        done
                    </div>
                    Histórico de viagens.</li>
            </ul>
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

    <div class="container_wrapper plans">
        <h1>Escolha um plano</h1>
        <p>Atualize a qualquer momento, sem taxas surpresa. </p>

        <div class="cards">
            <div class="card">
                <div class="price">
                    <span class="currency">R$</span>
                    <span class="money bold">FREE</span>
                </div>
                <h2>Plano Based</h2>
                <p>Plano básico.</p>
                <div class="features">
                    <ul>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Mapas meteorologicos.</li>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Alertas em tempo real.</li>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Previsões meteorologicos.</li>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Histórico de viagens.</li>
                    </ul>
                </div>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="primary-button" NavigateUrl="~/Register">Assinar agora</asp:HyperLink>
            </div>
            <div class="card target">
                <div class="price">
                    <span class="currency">R$</span>
                    <span class="money bold">99</span>
                </div>
                <h2>Plano Poggers </h2>
                <p>Plano feito e customizado para você.</p>
                <div class="features">
                    <ul>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Mapas meteorologicos.</li>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Alertas em tempo real.</li>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Previsões meteorologicos.</li>
                        <li>
                            <div class="dot material-icons-outlined">
                                done
                            </div>
                            Histórico de viagens.</li>
                    </ul>
                </div>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="secondary-button" NavigateUrl="~/Register">Assinar agora</asp:HyperLink>
            </div>
        </div>
    </div>  

    <div class="container_wrapper comments">
        <h1>Comentários de alguns Bros</h1>

        <div class="layout-grid">
            <div class="quote-card offset-left">
                <div class="img-author"></div>
                <div class="comment-author">
                    <p>"A maior glória de viver não está em nunca cair, mas em nos levantar toda vez que caímos."</p>
                    <br />
                </div>
                <div class="card-author">
                    <p>- Nelson Mandela</p>
                </div>
            </div>
            <div class="quote-card offset-left">
                <div class="img-author"></div>
                <div class="comment-author">
                    <p>"No final das contas, não são os anos de sua vida que contam. É a vida em seus anos."</p>
                    <br />
                </div>
                <div class="card-author">
                    <p>- Abraham Lincoln</p>
                </div>
            </div>
            <div class="quote-card offset-right">
                <div class="img-author"></div>
                <div class="comment-author">
                    <p>"A maneira de começar é parar de falar e começar a fazer."</p>
                    <br />
                </div>
                <div class="card-author">
                    <p>- Walt Disney</p>
                </div>
            </div>
            <div class="quote-card offset-right">
                <div class="img-author"></div>
                <div class="comment-author">
                    <p>"Você sabe que está no caminho do sucesso se fizer o seu trabalho e não for pago por ele."</p>
                    <br />
                </div>
                <div class="card-author">
                    <p>- Oprah Winfrey</p>
                </div>
            </div>
        </div>
    </div>

    <div class="orbit">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/orbit.svg" />
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
    </div>

    <script src="/Scripts/intlTelInput.min.js"></script>
    <script src="/Scripts/AudioHorn.js"></script>
    <script>
        var input = document.querySelector("#phone")

        window.intlTelInput(input, {
            // any initialisation options go here
        })

        let horn = document.querySelector('.PlayAudio')

        AudioHorn.Setup(horn)
    </script>
</asp:Content>
