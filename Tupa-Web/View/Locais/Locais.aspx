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

                <div class="list">
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
            <!-- Esta semana -->
            <!--<div class="week">
                <p>Esta semana</p>

                <div class="list">
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    directions_car
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>22 km</h4>
                                <p>09:55 - 11:05 (1h 9min)</p>
                            </div>
                        </div>
                        <div class="body">
                            <div class="map card">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7315.530739935054!2d-46.592731779951585!3d-23.54093991255083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5ed74407178f%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629536225465!5m2!1spt-BR!2sbr" width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                            </div>
                        </div>
                        <div class="footer">
                            <div>
                                <p>8</p>
                                <p>Eventos</p>
                            </div>
                            <div>
                                <p>2</p>
                                <p>Enchentes</p>
                            </div>
                        </div>
                    </div>
                </div>                   
            </div> -->
            <!-- Este mês -->
            <!--<div class="month">
                <p>Este mês</p>

                <div class="list">
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    directions_car
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>4 km</h4>
                                <p>01:16 - 01:21 (4min)</p>
                            </div>
                        </div>
                        <div class="body">
                            <div class="map card">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7315.530739935054!2d-46.592731779951585!3d-23.54093991255083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5ed74407178f%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629536225465!5m2!1spt-BR!2sbr" width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                            </div>
                        </div>
                        <div class="footer">
                            <div>
                                <p>2</p>
                                <p>Eventos</p>
                            </div>
                            <div>
                                <p>0</p>
                                <p>Enchentes</p>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    directions_car
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>4 km</h4>
                                <p>01:16 - 01:21 (4min)</p>
                            </div>
                        </div>
                        <div class="body">
                            <div class="map card">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7315.530739935054!2d-46.592731779951585!3d-23.54093991255083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5ed74407178f%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629536225465!5m2!1spt-BR!2sbr" width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                            </div>
                        </div>
                        <div class="footer">
                            <div>
                                <p>2</p>
                                <p>Eventos</p>
                            </div>
                            <div>
                                <p>0</p>
                                <p>Enchentes</p>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    directions_car
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>22 km</h4>
                                <p>09:55 - 11:05 (1h 9min)</p>
                            </div>
                        </div>
                        <div class="body">
                            <div class="map card">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7315.530739935054!2d-46.592731779951585!3d-23.54093991255083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5ed74407178f%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629536225465!5m2!1spt-BR!2sbr" width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                            </div>
                        </div>
                        <div class="footer">
                            <div>
                                <p>8</p>
                                <p>Eventos</p>
                            </div>
                            <div>
                                <p>2</p>
                                <p>Enchentes</p>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    directions_car
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>22 km</h4>
                                <p>09:55 - 11:05 (1h 9min)</p>
                            </div>
                        </div>
                        <div class="body">
                            <div class="map card">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7315.530739935054!2d-46.592731779951585!3d-23.54093991255083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5ed74407178f%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629536225465!5m2!1spt-BR!2sbr" width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                            </div>
                        </div>
                        <div class="footer">
                            <div>
                                <p>8</p>
                                <p>Eventos</p>
                            </div>
                            <div>
                                <p>2</p>
                                <p>Enchentes</p>
                            </div>
                        </div>
                    </div>
                </div>       
            </div> -->
            <!-- Este ano -->
            <!--<div class="year">
                <p>Este ano</p>

                <div class="list">
                    <div class="card">
                        <div class="title">
                            <div class="icon">
                                <span class="material-icons-outlined">
                                    directions_car
                                </span>
                            </div>                                
    
                            <div class="description">
                                <h4>22 km</h4>
                                <p>09:55 - 11:05 (1h 9min)</p>
                            </div>
                        </div>
                        <div class="body">
                            <div class="map card">
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7315.530739935054!2d-46.592731779951585!3d-23.54093991255083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5ed74407178f%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629536225465!5m2!1spt-BR!2sbr" width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
                            </div>
                        </div>
                        <div class="footer">
                            <div>
                                <p>8</p>
                                <p>Eventos</p>
                            </div>
                            <div>
                                <p>2</p>
                                <p>Enchentes</p>
                            </div>
                        </div>
                    </div>
                </div>      
            </div> -->
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
                                        <h4><%# DataBinder.Eval(Container.DataItem, "DistanciaPercurso") %></h4>
                                        <p><%# DataBinder.Eval(Container.DataItem, "IntervaloDeTempo") %> (
                                            <%# DataBinder.Eval(Container.DataItem, "TempoTotal") %>)</p>
    
                                    </div>
                                </div>
                                <div class="body">
                                    <div class="map card">
                                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7315.530739935054!2d-46.592731779951585!3d-23.54093991255083!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5ed74407178f%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629536225465!5m2!1spt-BR!2sbr" width="100%" height="100" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
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
    </div>
</asp:Content>
