<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/View/Configuracoes/Configuacoes.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Tupa_Web.View.Configuracoes.WebForm1" 
    MetaDescription="Configure seu perfil no Tupã" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <div class="error error-message-absolute" runat="server" id="errorMessage">                
    <!-- ErrorMessageHelpers -->
    </div>

    <h1>Perfil</h1>
    <hr />

    <div class="perfil-section form">
        <div class="picture">
            <asp:Image ID="imgPicture" runat="server" ImageUrl="~/Content/Images/abraham.jpg" />

            <button type="button" class="secondary-button">Carregar nova imagem</button>
            <button type="button" class="primary-button">Deletar</button>            
        </div>
        <div class="form-group">
            <div class="input">
                <asp:Label ID="lblNome" runat="server" CssClass="label">Alterar Nome</asp:Label>
                <asp:TextBox ID="txtNome" runat="server" placeholder="Digite um novo nome" autocomplete="off"></asp:TextBox>
                <span class="caption">Seu nome é somente visto por você.</span>
            </div>
        </div>

        <asp:Button ID="btnAlterarNome" runat="server" Cssclass="secondary-button" Text="Atualizar Nome" OnClick="btnAlterarNome_Click"/>

        <div class="form-group">
            <div class="input">
                <asp:Label ID="Label1" runat="server" CssClass="label">Senha Antiga</asp:Label>
                <asp:TextBox ID="txtOld" name="txtSenha" runat="server" placeholder="*****" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="input">
                <asp:Label ID="Label2" runat="server" CssClass="label">Senha nova</asp:Label>
                <div class="input_icon_right input">
                    <label for="txtSenha" onClick="PasswordEyes.PasswordEyesEvent(this)" >
                        <span class="material-icons-outlined">
                            visibility
                        </span>
                    </label>
                    <asp:TextBox ID="txtSenha" name="txtSenha" runat="server" placeholder="*****" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        </div>

        <asp:Button ID="btnMudarSenha" runat="server" Cssclass="secondary-button" Text="Atualizar Senha" OnClick="btnMudarSenha_Click"/>
    </div>

    <h1 class="danger">Apagar conta</h1>
    <hr />

    <div class="delete-section form">

        <p>Excluir a sua conta e seus dados.</p>
        <asp:Button runat="server" ID="btnExcluir" Cssclass="primary-button danger" Text="Apagar"/>  
    </div>

    <script src="/Scripts/PasswordEyes.js"></script>
</asp:Content>
