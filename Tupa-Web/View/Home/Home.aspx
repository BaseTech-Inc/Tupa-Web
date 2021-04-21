<%@ Page Title="Home" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Tupa_Web.View.Home.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="container">
        <div>
            <h2></h2>
            <p></p>
            <asp:HyperLink ID="hlLink" runat="server" NavigateUrl="~/#">HyperLink</asp:HyperLink>
        </div>

        <asp:Image ID="imgTemperature" runat="server" ImageUrl="#" AlternateText="Temperature" />
    </main>
</asp:Content>
