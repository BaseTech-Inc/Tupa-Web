<%@ Page Title="Temas" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Themes.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.Themes"
    MetaDescription="Escolha um perfil que seja melhor para você." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <h1>Preferências de tema</h1>

    <hr />
    
    <div class="form">
        <div class="radio-buttons">
            <div>
                <asp:RadioButton ID="optWhite" runat="server" AutoPostBack="true" GroupName="ThemeMenu" OnCheckedChanged="optWhite_CheckedChanged" />
                <label for='<%# optWhite.ClientID %>' class="option">
                    <div class="img light"></div>
                    <main>
                        <div class="dot material-icons-outlined"></div>
                        <div class="description">
                            <p class="bold">Claro</p>
                        </div> 
                    </main>
                </label>
            </div>
            <div>
                <asp:RadioButton ID="optDark" runat="server" AutoPostBack="true" GroupName="ThemeMenu" OnCheckedChanged="optDark_CheckedChanged" />
                    
                <label for='<%# optDark.ClientID %>' class="option">
                    <div class="img dark"></div>
                    <main>
                        <div class="dot material-icons-outlined"></div>
                        <div class="description">
                            <p class="bold">Escuro </p>
                        </div>
                    </main>                
                </label>
            </div>     
            <div>
                <asp:RadioButton ID="optDarkDimmed" runat="server" AutoPostBack="true" GroupName="ThemeMenu" OnCheckedChanged="optDarkDimmed_CheckedChanged" />
                    
                <label for='<%# optDarkDimmed.ClientID %>' class="option">
                    <div class="img dark-dimmed"></div>
                    <main>
                        <div class="dot material-icons-outlined"></div>
                        <div class="description">
                            <p class="bold">Escuro claro</p>
                        </div>
                    </main>                
                </label>
            </div>    
        </div>
    </div>
</asp:Content>
