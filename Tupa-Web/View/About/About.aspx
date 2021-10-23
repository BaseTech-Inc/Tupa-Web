<%@ Page Title="Sobre nós" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Tupa_Web.View.About.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/about.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="about container_wrapper">
        <div class="container_wrapper">
            <h1 class="umbrella">☂️</h1>
            <h1>BaseTech Inc.</h1>

            <p>O inicio da história da <span class="bold">BaseTech Inc.</span> começou pela construção da identidade visual da empresa, teve como inspiração o <span class="bold">Rodrigo Kenji Sagara Nishimi</span>, em que a logomarca e o nome remete ao rosto e ao nome fictício do Rodrigo Kenji, <span class="bold">Base Forte.</span></p>
        </div>

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/logo_basetech.svg" />

        <div class="container_wrapper ">
            <h1>☂️ Tupã</h1>

            <p>O tema do projeto de TCC foi escolhido de forma democrática, sendo escolhido <span class="bold">meteorologia</span>.</p>
            <p>O nome do projeto a ser desenvolvido também escolhido de forma democrática, <span class="bold">Tupã</span>, com <span class="bold">"~"</span> (o <span class="bold">"~"</span> não foi escolhido de forma democrática).</p>
         </div>

        <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Images/logo_tupa.svg" />
    </div>    
</asp:Content>
