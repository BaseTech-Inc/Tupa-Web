<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Tupa_Web.View.Dashboard.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/dashboard.css">
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

        <div class="dashboard">
            <div class="left">
                <div class="atual card">
                    <div>
                        <p>Atual</p>
                        <h2>Ermelino Matarazzo, São Paulo</h2>
                        <h1>19º</h1>
                        <span class="tag">Nublado</span>
                    </div>
                        
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/day_cloudy.png" />
                </div>
                <div class="previsao card">
                    <header>
                        <div>
                            <p>Previsão</p>
                        </div>
                        <div>
                            <ul class="navigation card">
                                <li class="target">
                                    <p>Ano</p>
                                </li>
                                <li>
                                    <p>Mês</p>
                                </li>
                                <li>
                                    <p>Dia</p>
                                </li>
                            </ul>
                        </div>
                        <div></div>
                    </header>   
                        
                    <div class="graphic">

                    </div>
                </div>
            </div>
            <div class="right">
                <div class="alertas card">
                    <p>Alertas</p>

                    <div class="search">
                        <label for="search">
                            <span class="material-icons">
                            search
                            </span>
                        </label>
                            
                        <input type="text" name="search" id="search" placeholder="Pesquisar..." class="card">
                    </div>

                    <div class="list">
                        <div class="card">
                            <div class="left">
                                <div class="icon">
                                    <span class="material-icons-outlined">
                                        schedule
                                    </span>
                                </div>  
                            </div>
                            <div class="right">
                                <div class="title">    
                                    <div class="description">
                                        <h4>Ermelino Matarazzo, São Paulo</h4>
                                        <p>19º</p>
                                    </div>  
                                </div>

                                <div class="line"></div>

                                <div class="body">
                                    <p>Avenida Antônio Munhoz Bonilha</p>
                                </div>
                            </div>

                            <div class="time">
                                <p>15:59 - 16:38</p>
                            </div>
                        </div>

                        <div class="card">
                            <div class="left">
                                <div class="icon">
                                    <span class="material-icons-outlined">
                                        schedule
                                    </span>
                                </div>  
                            </div>
                            <div class="right">
                                <div class="title">    
                                    <div class="description">
                                        <h4>Ermelino Matarazzo, São Paulo</h4>
                                        <p>19º</p>
                                    </div>  
                                </div>

                                <div class="line"></div>

                                <div class="body">
                                    <p>Avenida Antônio Munhoz Bonilha</p>
                                </div>
                            </div>

                            <div class="time">
                                <p>15:59 - 16:38</p>
                            </div>
                        </div>

                        <div class="card">
                            <div class="left">
                                <div class="icon">
                                    <span class="material-icons-outlined">
                                        schedule
                                    </span>
                                </div>  
                            </div>
                            <div class="right">
                                <div class="title">    
                                    <div class="description">
                                        <h4>Ermelino Matarazzo, São Paulo</h4>
                                        <p>19º</p>
                                    </div>  
                                </div>

                                <div class="line"></div>

                                <div class="body">
                                    <p>Avenida Antônio Munhoz Bonilha</p>
                                </div>
                            </div>

                            <div class="time">
                                <p>15:59 - 16:38</p>
                            </div>
                        </div>

                        <div class="card">
                            <div class="left">
                                <div class="icon">
                                    <span class="material-icons-outlined">
                                        schedule
                                    </span>
                                </div>  
                            </div>
                            <div class="right">
                                <div class="title">    
                                    <div class="description">
                                        <h4>Ermelino Matarazzo, São Paulo</h4>
                                        <p>19º</p>
                                    </div>  
                                </div>

                                <div class="line"></div>

                                <div class="body">
                                    <p>Avenida Antônio Munhoz Bonilha</p>
                                </div>
                            </div>

                            <div class="time">
                                <p>15:59 - 16:38</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
