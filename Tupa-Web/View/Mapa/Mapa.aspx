<%@ Page Title="Mapa" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="Tupa_Web.View.Mapa.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Content/Css/mapa.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_wrapper">
        <div class="search">
            <label for="search">
                <span class="material-icons">
                search
                </span>
            </label>
                
            <input type="text" name="search" id="search" placeholder="Pesquisar..." class="card">
        </div>
    </div>        

    <div class="map">
        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d58523.45597178577!2d-46.589625000000005!3d-23.542715!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x8815f43931e081f7!2zQmVsw6lt!5e0!3m2!1spt-BR!2sbr!4v1629569434152!5m2!1spt-BR!2sbr" style="border:0;" height="100%" width="100%" allowfullscreen="" loading="lazy"></iframe>
    </div>
</asp:Content>
