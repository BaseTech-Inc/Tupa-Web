<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.WebForm1" 
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
        <button type="button" class="secondary-button">Atualizar perfil</button>
    </div>
    
</asp:Content>
