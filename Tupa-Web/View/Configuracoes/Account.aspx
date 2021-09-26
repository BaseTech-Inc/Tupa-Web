<%@ Page Title="Configurações da conta" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.Account"
    MetaDescription="Atualize seu email e gerencie a sua conta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <h1>Alterar email</h1>

    <hr />

    <div class="perfil-section form">
        <div class="inputs">
            <div class="input">
                <asp:Label ID="lblEmail" runat="server" >Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                <span class="caption">Alterar seu email pode ter efeitos colaterais indesejados.</span>
            </div>
        </div>
    </div>

    <h1 class="danger">Apagar conta</h1>

    <hr />

    <div class="delete-section form">
        <p>Excluir a sua conta e seus dados.</p>
        <button type="button" class="primary-button danger">Apagar</button>            
    </div>
</asp:Content>
