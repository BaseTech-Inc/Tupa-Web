<%@ Page Title="Locais" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Locais.aspx.cs" Inherits="Tupa_Web.View.Locais.Locais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/locais.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_wrapper">
        <div class="search">
            <label for="search">
                <span class="material-icons">
                search
                </span>
            </label>
                
            <input type="text" name="search" id="search" placeholder="Pesquisar..." class="card">
        </div>

        <div class="content">
            <!-- Mais pesquisados -->
            <div class="more-search">
                <p>Mais pesquisados</p>

                <div class="list scroll">
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    schedule
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>Ermelino Matarazzo, São Paulo</h4>
                                <p>19º</p>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    schedule
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>Belém, São Paulo</h4>
                                <p>24º</p>
                            </div>
                        </div>
                    </div>
                </div>                   
            </div>

            <div class="week">
                <p>Esta semana</p>
                <div class="list">
                    <asp:Repeater ID="rep" runat="server">
                        <ItemTemplate>
                            <div class="card">
                                <div class="title">
                                    <div class="icon">
                                        <span class="material-icons-outlined">
                                            directions_car
                                        </span>
                                    </div>                                
    
                                    <div class="description">
                                        <h4><%# DataBinder.Eval(Container.DataItem, "Local") %></h4>
                                        <p><%# DataBinder.Eval(Container.DataItem, "IntervaloDeTempo") %> (
                                            <%# DataBinder.Eval(Container.DataItem, "DistanciaPercurso") %>)</p>
    
                                    </div>
                                </div>
                                <div class="body">
                                    <div class="map card">
                                        <iframe src='<%# DataBinder.Eval(Container.DataItem,"UrlMapas") %>' width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                                    </div>
                                </div>
                                <div class="footer">
                                    <div>
                                        <p><%# DataBinder.Eval(Container.DataItem, "Eventos") %></p>
                                        <p>Eventos</p>
                                    </div>
                                    <div>
                                        <p><%# DataBinder.Eval(Container.DataItem, "Enchentes") %></p>
                                        <p>Enchentes</p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <nav class="pagination">
            <ul>
                <li>
                    <a href="#" class="cta left">
                        <svg width="13px" height="10px" viewBox="0 0 13 10">
                            <path d="M1,5 L11,5"></path>
                            <polyline points="8 1 12 5 8 9"></polyline>
                        </svg>
                        <span>anterior</span>
                    </a>
                </li>
                <li class="current">
                    <a href="#">1</a>
                </li>
                <li>
                    <a href="#">2</a>
                </li>
                <li>
                    <a href="#">3</a>
                </li>
                <li>
                    <a href="#">4</a>
                </li>
                <li>
                    <a href="#" class="cta">
                        <span>próximo</span>
                        <svg width="13px" height="10px" viewBox="0 0 13 10">
                            <path d="M1,5 L11,5"></path>
                            <polyline points="8 1 12 5 8 9"></polyline>
                        </svg>
                    </a>
                </li>
            </ul>
        </nav>
    </div>
</asp:Content>
