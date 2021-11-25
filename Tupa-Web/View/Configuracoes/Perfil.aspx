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
            <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
            <asp:UpdatePanel ID="UpdatePanelImage2" UpdateMode="Conditional" runat="server" OnLoad="UpdatePanelImage2_Load">
                <ContentTemplate>
                    <%-- Parte de carregamento enquanto o conteúdo é processado --%>
                    <asp:UpdateProgress ID="UpdateProgressImage2" runat="server">
                        <ProgressTemplate>
                            <%-- Carregameto do esqueleto do conteúdo que será mostrado --%>
                            <div class="loading">
                                <div class="avatar"></div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <%-- Conteúdo --%>
                    <div class="img-wrapper">
                        <asp:Image ID="imageUserTwo" runat="server" border="0" />
                    </div>

                    <asp:Timer ID="TimerImage2" runat="server" Interval="1" OnTick="TimerImage2_Tick"></asp:Timer>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerImage2" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>

            <label for="<%# selecaoarquivo.ClientID %>" class="secondary-button">Selecionar um arquivo</label>
            <asp:FileUpload id="selecaoarquivo" runat="server" />            

            <asp:Button ID="btnCarregar" runat="server" CssClass="primary-button" Text="Carregar" OnClick="btnCarregar_Click" />

            <asp:Button ID="txtDeletarFoto" runat="server" CssClass="primary-button" Text="Deletar" OnClick="txtDeletarFoto_Click" />
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
                <asp:Label ID="Label3" runat="server" CssClass="label">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" disabled style="cursor: no-drop"></asp:TextBox>
            </div>
        </div>

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
        <asp:Button runat="server" ID="btnApagarConta" Cssclass="primary-button danger" Text="Apagar" OnClick="btnApagarConta_Click"/>  
    </div>

    <asp:ScriptManagerProxy ID="ScriptManagerProxy3" runat="server"></asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpdatePanelPopUp" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <%-- Conteúdo --%>
            <div ID="panelPopUp" runat="server">

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="/Scripts/PasswordEyes.js"></script>
    <script>

        function OnOuterClick_ClosePopUp(element, event) {
            if (!element.children[0].contains(event.target)) {
                OnClick_ClosePopUp(element)
            }
        }

        function OnClick_ClosePopUp(element) {
            element.classList.toggle('disabled')

            __doPostBack('<%= UpdatePanelPopUp.ClientID %>', 'Close')
        }

        function OnClick_ApagarConta(element) {
            __doPostBack('<%= btnApagarConta.ClientID %>', '')
        }
    </script>
</asp:Content>
