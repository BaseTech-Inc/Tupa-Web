<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Tupa_Web.View.Error.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/error.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_wrapper flex">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/globe.png" />

            <div class="description">
                <h1>OPS!! PAGE NOT FOUND, BRO!!</h1>
                <p>Acho que você escolheu a página errada, porque eu não consegui dar uma olhada na que você está procurando.</p>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/" CssClass="primary-button">Voltar ao Inicío</asp:HyperLink>
            </div>
        </div>
</asp:Content>
