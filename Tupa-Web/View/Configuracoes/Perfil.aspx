﻿<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.WebForm1" 
    MetaDescription="Configure seu perfil no Tupã" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <h1>Perfil</h1>

    <hr />

    <div class="perfil-section form">
        <div class="picture">
            <asp:Image ID="imgPicture" runat="server" ImageUrl="~/Content/Images/abraham.jpg" />

            <button type="button" class="secondary-button">Carregar nova imagem</button>
            <button type="button" class="primary-button">Deletar</button>            
        </div>
        <div class="inputs">
            <div class="input">
                <asp:Label ID="lblNome" runat="server" >Nome</asp:Label>
                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox>
                <span class="caption">Seu nome é somente visto por você.</span>
            </div>
        </div>
            <asp:Button ID="btnAlterarNome" runat="server" Cssclass="secondary-button" Text="Atualizar Nome" OnClick="btnAlterarNome_Click"/>
        <div class="inputs">
            <div class="input">
                <asp:Label ID="lblEmail" runat="server" >Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                <span class="caption">Digite sua senha antiga para alterá-la</span>
            </div>
         </div>
        <asp:Button ID="btnMudarSenha" runat="server" Cssclass="secondary-button" Text="Atualizar Senha" OnClick="btnMudarSenha_Click"/>
    </div>
    <div class="error error-message-absolute" runat="server" id="errorMessage">                
  <!-- ErrorMessageHelpers -->
</div>
    <h1 class="danger">Apagar conta</h1>
    <hr />

    <div class="delete-section form">
        <p>Excluir a sua conta e seus dados.</p>
        <asp:Button runat="server" ID="btnExcluir" Cssclass="primary-button danger" Text="Apagar"/>        
    </div>
    
</asp:Content>
