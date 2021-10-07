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
                <div class="card forecast"> 
                    <%-- FORECAST --%>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanel2_Load">
                        <ContentTemplate>
                            <p class="tag_card">Atual</p>

                            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                <ProgressTemplate>
                                    <asp:Panel ID="SkeletonLoadingPanelForecast" runat="server">
                                        <div class="loading">
                                            <div class="lines">
                                                <div class="line"></div>
                                                <div class="line"></div>
                                            </div>

                                            <div class="img"></div>
                                        </div>
                                    </asp:Panel>
                                </ProgressTemplate>
                            </asp:UpdateProgress>

                            <asp:Repeater ID="RepeaterForecast" runat="server">
                                <ItemTemplate>
                                    <div class="atual">
                                        <div>
                                        <h2><%# DataBinder.Eval(Container.DataItem, "Locale") %></h2>
                                        <h1><%# DataBinder.Eval(Container.DataItem, "Temperature") %></h1>
                                        <span class="tag"><%# DataBinder.Eval(Container.DataItem, "Condition") %></span>  
                                        </div>
                                        
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/day_cloudy.png" />
                                    </div>                                    
                                </ItemTemplate>
                            </asp:Repeater>

                            <asp:HiddenField ID="queryStringLat" runat="server" />
                            <asp:HiddenField ID="queryStringLon" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                            
                        <asp:TextBox ID="txtSearchDate" type="date" runat="server" placeholder="Pesquisar..." CssClass="card" AutoPostBack="True" OnTextChanged="txtSearchDate_TextChanged"></asp:TextBox>
                    </div>
                    <div class="list">
                        <%-- ALERTS --%>
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
                                        <asp:Panel ID="SkeletonLoadingPanel" runat="server">
                                            <div class="card loading">
                                                <div class="avatar"></div>

                                                <div class="lines">
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                </div>
                                            </div>
                                            <div class="card loading">
                                                <div class="avatar"></div>

                                                <div class="lines">
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                </div>
                                            </div>
                                            <div class="card loading">
                                                <div class="avatar"></div>

                                                <div class="lines">
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                </div>
                                            </div>
                                            <div class="card loading">
                                                <div class="avatar"></div>

                                                <div class="lines">
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                </div>
                                            </div>
                                            <div class="card loading">
                                                <div class="avatar"></div>

                                                <div class="lines">
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                    <div class="line"></div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="error-message-absolute">
                                    <div ID="errorMessage" CssClass="error" runat="server"></div>
                                </div>
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
                            <triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtSearchDate" EventName="TextChanged" />
                            </triggers>
                        </asp:UpdatePanel>
                    </div>                    
                </div>
            </div>
        </div>
    </div>

    <script>
        navigator.geolocation.getCurrentPosition((position) => {
            var hiddenFieldLat = document.querySelector('#<%= queryStringLat.ClientID %>')
            var hiddenFieldLon = document.querySelector('#<%= queryStringLon.ClientID %>')

            hiddenFieldLat.value = position.coords.latitude
            hiddenFieldLon.value = position.coords.longitude
        }, (error) => {
            console.error(error)
        })

        window.onload = () => {
            __doPostBack('<%= UpdatePanel2.ClientID %>')
        }
    </script>
</asp:Content>
