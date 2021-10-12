<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Tupa_Web.View.Dashboard.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Import Namespace="Tupa_Web.Common.Helpers" %>
<%@ Import Namespace="Tupa_Web.Common.Enumerations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/dashboard.css">
    <link rel="stylesheet" href="/Content/Css/loading.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanelSearch" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanelSearch_Load">
            <ContentTemplate>                
                <asp:Panel ID="SearchBar" CssClass="SeachBar" runat="server">
                    <div class="search">
                        <label for="search">
                            <span class="material-icons">
                            search
                            </span>
                        </label>
               
                        <asp:TextBox ID="txtSearch" type="text" runat="server" AutoPostBack="True" placeholder="Pesquisar por bairros..." CssClass="card" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>  
                    </div>
                    <asp:Panel ID="AutoCompleteList" Visible="false" runat="server" CssClass="autoCompleteList card">
                        <div>
                            <asp:Repeater ID="RepeaterAutoComplete" runat="server">
                                <ItemTemplate>
                                    <div class="suggestion">
                                        <span class="material-icons-outlined">
                                        search
                                        </span>
                                        <span><%# DataBinder.Eval(Container.DataItem, "Nome") %></span>
                                        <span></span>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>                        
                    </asp:Panel>
                </asp:Panel>            
            </ContentTemplate>
            <triggers>
                <asp:AsyncPostBackTrigger ControlID="txtSearch" EventName="TextChanged" />
            </triggers>
        </asp:UpdatePanel>

        <div class="dashboard">
            <div class="left">
                <div class="card forecast"> 
                    <%-- Update Panel Forecast --%>
                    <asp:UpdatePanel ID="UpdatePanelForecast" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanelForecast_Load">
                        <ContentTemplate>
                            <p class="tag_card">Atual</p>

                            <%-- Parte de carregamento enquanto o conteúdo é processado --%>
                            <asp:UpdateProgress ID="UpdateProgressForecast" runat="server">
                                <ProgressTemplate>
                                    <%-- Carregameto do esqueleto do conteúdo que será mostrado --%>
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

                            <%-- Conteúdo --%>
                            <asp:Repeater ID="RepeaterForecast" runat="server">
                                <ItemTemplate>
                                    <div class="atual">
                                        <div>
                                        <h2><%# DataBinder.Eval(Container.DataItem, "Locale") %></h2>
                                        <h1><%# DataBinder.Eval(Container.DataItem, "Temperature") %></h1>
                                        <span class="tag"><%# DataBinder.Eval(Container.DataItem, "Condition") %></span>  
                                        </div>
                                        
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "UrlImage") %>' />
                                    </div>                                    
                                </ItemTemplate>
                            </asp:Repeater>

                             <%-- LanLog --%>
                            <asp:HiddenField ID="queryStringLat" runat="server" />
                            <asp:HiddenField ID="queryStringLon" runat="server" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" />
                        </Triggers>
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
                        <canvas id="myChart" width="400" height="400"></canvas>

                        <asp:HiddenField ID="HiddenFieldGraphic" runat="server" />
                    </div>
                </div>
            </div>
            <div class="right">
                <div class="alertas card">
                    <p>Alertas</p>

                    <%-- Update Panel Alertas --%>
                    <asp:UpdatePanel ID="UpdatePanelAlertas" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanelAlertas_Load">
                        <ContentTemplate>
                            <div class="search">
                                <label for="search">
                                    <span class="material-icons">
                                    search
                                    </span>
                                </label>
                            
                                <asp:TextBox ID="txtSearchDate" type="date" runat="server" placeholder="Pesquisar..." CssClass="card" AutoPostBack="True" OnTextChanged="txtSearchDate_TextChanged"></asp:TextBox>
                            </div>
                            <div ID="listAlertas" onscroll="scrollAlertas(this)" runat="server" class="list">
                                <%-- Parte de carregamento enquanto o conteúdo é processado --%>
                                <asp:UpdateProgress ID="UpdateProgressAlertas" runat="server">
                                    <ProgressTemplate>
                                        <%-- Carregameto do esqueleto do conteúdo que será mostrado --%>
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
                                <%-- Conteúdo --%>
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
                                
                                <%-- Update Panel Alertas --%>
                                <asp:UpdatePanel ID="UpdatePanelAlertsMorePages" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanelAlertsMorePages_Load">
                                    <ContentTemplate>
                                        <%-- Conteúdo --%>
                                        <div ID="repeatersMorePages" runat="server"></div>

                                        <asp:UpdateProgress ID="UpdateProgressAlertasMorePages" runat="server">
                                            <ProgressTemplate>
                                                <img class="loading" src="https://c.tenor.com/I6kN-6X7nhAAAAAj/loading-buffering.gif" alt="loading" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>  

                                        <div ID="morePagesInformation" runat="server"></div>
                                    </ContentTemplate>                       
                                </asp:UpdatePanel>
                            </div>
                        </ContentTemplate>
                        <%-- Triggers --%>
                        <triggers>
                            <%-- Quando o conteúdo do TextBox for alterado executar o evento --%>
                            <asp:AsyncPostBackTrigger ControlID="txtSearchDate" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" />
                        </triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="error-message-absolute">
                <div ID="errorMessage" CssClass="error" runat="server"></div>
            </div>

            <asp:Timer ID="timer1" runat="server" Interval="1" OnTick="Timer1_Tick"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="https://cdn.jsdelivr.net/npm/chart.js@3.5.1/dist/chart.min.js"></script>
    <script type="text/javascript">
        navigator.geolocation.getCurrentPosition((position) => {

            var hiddenFieldLat = document.querySelector('#<%= queryStringLat.ClientID %>')
            var hiddenFieldLon = document.querySelector('#<%= queryStringLon.ClientID %>')

            hiddenFieldLat.value = position.coords.latitude
            hiddenFieldLon.value = position.coords.longitude

        }, (error) => {
            console.error(error)
        })        

        let value = true

        function pageLoad() {
            value = true
        }

        function scrollAlertas(element) {
            if (((element.scrollHeight - element.clientHeight) - 10) <= element.scrollTop) {

                if (value) {
                    value = false

                    __doPostBack('<%= UpdatePanelAlertsMorePages.ClientID %>', 'PageNumber')

                    setTimeout(() => { element.scrollBy(0, 100) }, 500)                    
                }  
            }
        }

        window.onload = () => {
            let documentGraphic = document.querySelector('#<%# HiddenFieldGraphic.ClientID %>')

            let json = JSON.parse(documentGraphic.value)

            let labels = []
            let data = []

            json.forEach((currentJson) => {
                labels.push(currentJson.X)
                data.push(currentJson.Y)
            })
            const dataConfig = {
                labels: labels,
                datasets: [{
                    label: 'My First dataset',
                    backgroundColor: 'rgb(36, 133, 243)',
                    borderColor: 'rgb(36, 133, 243)',
                    data: data,
                }]
            };
            const config = {
                type: 'line',
                data: dataConfig,
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            };
            var myChart = new Chart(
                document.getElementById('myChart'),
                config
            );
        }
    </script>
</asp:Content>
