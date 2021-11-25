<%@ Page Title="Ajuda" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.Help" 
    MetaDescription="Você precisa de ajuda?" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <h1>Perguntas frequentes</h1>

    <hr />

    <details class="questions">
        <summary>
            <h3>Quem somos nós</h3>

            <span class="material-icons">
            navigate_next
            </span>
        </summary>

        <p>Você pode ver um pouco da nosso histórica clicando <asp:HyperLink runat="server" NavigateUrl="~/About" class="land__link">aqui</asp:HyperLink>.</p>
    </details>

    <details class="questions">
        <summary>
            <h3>Como posso me registrar?</h3>

            <span class="material-icons">
            navigate_next
            </span>
        </summary>

        <p>Você pode se registrar inserindo suas informações na <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%# Page.GetRouteUrl("Register", new { }) + "?ReturnUrl=" + HttpContext.Current.Request.Url.AbsoluteUri %>' class="land__link">página de registro</asp:HyperLink> e aceitando o e-mail que será enviado na sua caixa de mensagens.</p>
    </details>
    
    <details class="questions">
        <summary>
            <h3>Como posso entrar em contato</h3>

            <span class="material-icons">
            navigate_next
            </span>
        </summary>

        <p>Você pode entrar em contato conosco apartir desse email: faq@tupa.tech.</p>
    </details>
</asp:Content>
