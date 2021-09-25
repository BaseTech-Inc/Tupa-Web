<%@ Page Title="Configurações" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Configuracoes.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.Configuracoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/configuracoes.css" 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="configs-options">
        <%-- Opções de configuração --%>
        <ul>
            <li>
                <a href="Configuracoes.aspx"> Editar Usuário</a> 
            </li>
            <li>
                <a href="Register/Register.aspx"> Assinar Premium </a> 
            </li>
            <li>
                <a href="Dashboard/Dashboard.aspx"> Alertas na sua região </a> 
            </li>
            <li>
                <a href="Nos.aspx"> Sobre Nós </a> 
            </li>
            
        </ul>
    </div>
    <%--Aqui estará as configurações do usuario--%>
    <div class="container">
        <div class="user-foto">
            <img src="" class="user" /> <%--Aqui o usuario mudará a foto --%>
        </div>

        <asp:Label ID="Label1" runat="server" Text="Nome de Usuário"></asp:Label><br />
        <asp:TextBox ID="txtUsername" runat="server">Nome de Usuario</asp:TextBox><br /><br />

        <asp:Label ID="Label2" runat="server" Text="Mudar Senha"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Digite a Senha Atual"></asp:Label><br />
        <asp:TextBox ID="txtPassword" runat="server">Senha Atual </asp:TextBox><br /><br />
        <asp:Label ID="Label4" runat="server" Text="Digite a Senha Nova"></asp:Label><br />
        <asp:TextBox ID="txtNewPassword" runat="server">Nova Senha </asp:TextBox><br /><br />

        <asp:Button ID="salvalAlteracoes" runat="server" Text="Atualizar e Salvar" />
        
    </div>
</asp:Content>
