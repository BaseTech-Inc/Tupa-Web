<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Tupa_Web.View.Dashboard.Dashboard" %>
<%@ Import Namespace="Tupa_Web.Common.Helpers" %>
<%@ Import Namespace="Tupa_Web.Common.Enumerations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/dashboard.css">
    <link rel="stylesheet" href="/Content/Css/loading.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanel2_Load">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                                    <ProgressTemplate>
                                        Atualizando localização
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:Repeater ID="RepeaterForecast" runat="server">
                                    <ItemTemplate>
                                        <p>Atual</p>
                                        <h2><%# DataBinder.Eval(Container, "Locate") %></h2>
                                        <h1><%# DataBinder.Eval(Container, "Temperature") %></h1>
                                        <span class="tag"><%# DataBinder.Eval(Container, "CurrentCondition") %></span>   
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:HiddenField ID="queryStringLat" runat="server" />
                                <asp:HiddenField ID="queryStringLon" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                        <asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server"></asp:ScriptManagerProxy>
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanel1_Load">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="error-message-absolute">
                                            <div class="error-message information" runat="server">
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
                                <div class="error-message-absolute">
                                    <div ID="errorMessage" CssClass="error" runat="server"></div>
                                </div>
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

        navigator.geolocation.getCurrentPosition((position) => {
            var hiddenFieldLat = document.querySelector('#<%= queryStringLat.ClientID %>')
            var hiddenFieldLon = document.querySelector('#<%= queryStringLon.ClientID %>')

            hiddenFieldLat.value = position.coords.latitude
            hiddenFieldLon.value = position.coords.longitude
        });
    </script>
</asp:Content>
