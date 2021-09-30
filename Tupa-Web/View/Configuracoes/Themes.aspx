<%@ Page Title="Temas" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Themes.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.Themes"
    MetaDescription="Configure seu perfil no Tupã" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <h1>Preferências de tema</h1>

    <hr />
    
    <div class="form">
        <div class="radio-buttons">
            <div>
                <input type="radio" name="select" id="optWhite" checked>
                <label for="optWhite" class="option">
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
                <input type="radio" name="select" id="optDark">
                    
                <label for="optDark" class="option">
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
                <input type="radio" name="select" id="optDarkDimmed">
                    
                <label for="optDarkDimmed" class="option">
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
