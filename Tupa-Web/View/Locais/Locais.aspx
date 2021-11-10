<%@ Page Title="Locais" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Locais.aspx.cs" Inherits="Tupa_Web.View.Locais.Locais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/locais.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-message-absolute">
        <div ID="errorMessage" CssClass="error" runat="server"></div>
    </div>

    <div class="container_wrapper">
        <div class="input">
            <div class="search" id="searchBoxContainer">
                <label for="search">
                    <span class="material-icons">
                    search
                    </span>
                </label>
                
                <asp:TextBox ID="txtSearch" type="text" runat="server" placeholder="Pesquisar por bairros..." CssClass="card" OnTextChanged="txtSearch_TextChanged" ></asp:TextBox>  
            </div>            
        </div>

        <div class="content">
            <div class="moreSearch">
                <asp:Repeater ID="RepeaterMoreSearch" runat="server">
                    <HeaderTemplate>
                        <p>Mais pesquisados</p>

                        <div class="list scroll">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="card" onclick="OnClick_MoreSearchCard(this);">
                            <div class="title">
                                <div class="icon">
                                    <span class="material-icons-outlined">
                                        schedule
                                    </span>
                                </div>                                
    
                                <div class="description">
                                    <h4><%# DataBinder.Eval(Container.DataItem, "Local") %></h4>
                                    <p><%# DataBinder.Eval(Container.DataItem, "Estado") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                        <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="week">
                <asp:Repeater ID="rep" runat="server">
                    <HeaderTemplate>
                        <p>Esta semana</p>

                        <div class="list">
                    </HeaderTemplate>
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
                            </div>
                        </div>
                    </ItemTemplate>
                        <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="month">
                <asp:Repeater ID="repMonth" runat="server">
                    <HeaderTemplate>
                        <p>Este mês</p>

                        <div class="list">
                    </HeaderTemplate>
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
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>                
            </div>
            <div class="year">
                <asp:Repeater ID="repYear" runat="server">
                    <HeaderTemplate>
                        <p>Este ano</p>

                        <div class="list">
                    </HeaderTemplate>
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
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div ID="morePagesInformation" runat="server" class="morePagesInformation"></div>
        </div>

        <nav class="pagination">
            <ul>
                <li>
                    <asp:HyperLink ID="HyperLinkBack" runat="server" CssClass="cta left" onclick="BackClick(this)">
                        <svg width="13px" height="10px" viewBox="0 0 13 10">
                            <path d="M1,5 L11,5"></path>
                            <polyline points="8 1 12 5 8 9"></polyline>
                        </svg>
                        <span>anterior</span>
                    </asp:HyperLink>
                </li>
                <asp:Repeater ID="repeaterPagination" runat="server">
                    <ItemTemplate>
                        <li class="current">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Page.GetRouteUrl("Locate", new { pageNumber = DataBinder.Eval(Container.DataItem, "PageNumber") })%>'><%# DataBinder.Eval(Container.DataItem, "PageNumber") %></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <li>
                    <asp:HyperLink ID="HyperLinkNext" runat="server" CssClass="cta" onclick="NextClick(this)">
                        <span>próximo</span>
                        <svg width="13px" height="10px" viewBox="0 0 13 10">
                            <path d="M1,5 L11,5"></path>
                            <polyline points="8 1 12 5 8 9"></polyline>
                        </svg>
                    </asp:HyperLink>
                </li>
            </ul>
        </nav>
    </div>

    <script type='text/javascript' src='https://www.bing.com/api/maps/mapcontrol?callback=GetMap&key=Ari-cml8va4SytOAMFM4bXFT6r_AvY2Q9ueyPK2wh8SplYx5_4fpC0AtEN5Qpb21' async defer></script>

    <script type="text/javascript">
        function NextClick(element) {
            __doPostBack('<%= HyperLinkNext.ClientID %>', '')
        }

        function BackClick(element) {
            __doPostBack('<%= HyperLinkBack.ClientID %>', '')
        }

        const txtSearch = document.querySelector('#<%= txtSearch.ClientID %>')

        function GetMap() {
            Microsoft.Maps.loadModule('Microsoft.Maps.AutoSuggest', {
                callback: function () {
                    var manager = new Microsoft.Maps.AutosuggestManager({
                        placeSuggestions: false
                    })
                    manager.attachAutosuggest(txtSearch, '#searchBoxContainer', selectedSuggestion)
                },
                errorCallback: function (msg) {
                    alert(msg)
                }
            })
        }

        function selectedSuggestion(result) {
            //Populate the address textbox values.
            let address = result.address.addressLine || ''
            let city = result.address.locality || ''
            let county = result.address.district || ''
            let state = result.address.adminDistrict || ''
            let country = result.address.countryRegion || ''

            setTimeout(() => { txtSearch.value = `${ address }, ${ city } - ${ state }` }, 1)

            __doPostBack(txtSearch.id, `${address}, ${city} - ${state}`)
        }
    </script>
</asp:Content>