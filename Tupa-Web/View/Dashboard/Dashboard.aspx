<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Tupa_Web.View.Dashboard.Dashboard" %>
<%@ Import Namespace="Tupa_Web.Common.Helpers" %>
<%@ Import Namespace="Tupa_Web.Common.Enumerations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/dashboard.css">
    <link rel="stylesheet" href="/Content/Css/loading.css">
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

                    <%-- Search Bar --%>
                    <div class="search">
                        <label for="search">
                            <span class="material-icons">
                            search
                            </span>
                        </label>
                            
                        <input type="text" name="search" id="search" placeholder="Pesquisar..." class="card">
                    </div>

                     <%-- Lista de alertas --%>
                    <div class="list">
                        <%-- Template
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
                                        <h4>{ Localização }</h4>
                                        <p>{ Temperatura }</p>
                                    </div>  
                                </div>

                                <div class="line"></div>

                                <div class="body">
                                    <p>{ Descrição }</p>
                                </div>
                            </div>

                            <div class="time">
                                <p>{ Tempo }</p>
                            </div>
                        </div>
                        --%>
                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanel1_Load">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="error-message-absolute">
                                            <div class="error-message information" runat="server" id="errorMessage">
                                                <div class="error_wrapper">
                                                    <p id="textErrorMessage" title="Atualizando Alertas...">Atualizando Alertas...</p>
                                                    <span class="close_button">
                                                        <span class="material-icons">
                                                        close
                                                        </span>
                                                    </span>
                                                </div>
                                            </div>                                                                     
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:Panel ID="SkeletonLoadingPanel" runat="server">
                                    <div class="card loading">
                                        <div class="avatar"></div>

                                        <div class="lines">
                                            <div class="line"><!-- Locale --></div>
                                            <div class="line"><!-- Temperature --></div>
                                            <div class="line"><!-- Description --></div>
                                        </div>
                                    </div>
                                    <div class="card loading">
                                        <div class="avatar"></div>

                                        <div class="lines">
                                            <div class="line"><!-- Locale --></div>
                                            <div class="line"><!-- Temperature --></div>
                                            <div class="line"><!-- Description --></div>
                                        </div>
                                    </div>
                                    <div class="card loading">
                                        <div class="avatar"></div>

                                        <div class="lines">
                                            <div class="line"><!-- Locale --></div>
                                            <div class="line"><!-- Temperature --></div>
                                            <div class="line"><!-- Description --></div>
                                        </div>
                                    </div>
                                    <div class="card loading">
                                        <div class="avatar"></div>

                                        <div class="lines">
                                            <div class="line"><!-- Locale --></div>
                                            <div class="line"><!-- Temperature --></div>
                                            <div class="line"><!-- Description --></div>
                                        </div>
                                    </div>
                                    <div class="card loading">
                                        <div class="avatar"></div>

                                        <div class="lines">
                                            <div class="line"><!-- Locale --></div>
                                            <div class="line"><!-- Temperature --></div>
                                            <div class="line"><!-- Description --></div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Repeater ID="RepeaterAlertas" runat="server">
                                    <ItemTemplate>
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
                                                        <h4><%# DataBinder.Eval(Container.DataItem, "Locale") %></h4>
                                                        <p><%# DataBinder.Eval(Container.DataItem, "Temperature") %></p>
                                                    </div>  
                                                </div>

                                                <div class="line-hr"></div>

                                                <div class="body">
                                                    <p><%# DataBinder.Eval(Container.DataItem, "Description") %></p>
                                                </div>
                                            </div>

                                            <div class="time">
                                                <p><%# DataBinder.Eval(Container.DataItem, "Time") %></p>
                                            </div>
                                        </div>                               
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>                    
                </div>
            </div>
        </div>
    </div>

    <script>
        window.onload = function () {
            __doPostBack('<%=UpdatePanel1.ClientID %>');
        }
    </script>
</asp:Content>
