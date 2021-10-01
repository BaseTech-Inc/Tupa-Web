<%@ Page Title="Plans" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Plans.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.Plans"
    MetaDescription="Atualize ou veja seu plano." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <%
        var cookie = Request.Cookies["token"];

        if (cookie != null)
        { 
    %>
    <h1>Plano atual</h1>

    <hr />

    <div class="plans-user-section form">
        <div class="card">
            <div class="title">
                <h2>Plano Based</h2>
            </div>
            
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
            <div class="price-section">
                <span class="currency">R$</span>
                <span class="money bold">FREE</span>
            </div>
        </div>
    </div>
    <%
        } 
    %>

    <h1>Planos</h1>

    <hr />

    <div class="plans-section form">
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
</asp:Content>
