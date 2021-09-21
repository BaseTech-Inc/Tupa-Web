using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Helpers;
using Tupa_Web.Common.Models;
using Tupa_Web.Common.Security;

namespace Tupa_Web.View.Register
{
    public partial class Register : Page
    {
        private string nome { get; set; }

        private string email { get; set; }

        private string senha { get; set; }

        private string confirmarSenha { get; set; }

        private string idToken { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);

            string targetCtrl = Page.Request.Params.Get("__EVENTTARGET");
            string parameter = Request["__EVENTARGUMENT"];

            if (targetCtrl != null && targetCtrl != string.Empty)
            {
                idToken = parameter;

                // Fire event
                btnRegisterGoogle_Click(this, new EventArgs());
            }
        }

        protected void btnRegisterGoogle_Click(object sender, EventArgs e)
        {
            var resultLogin = Task.Run(() => PostGetCode());
            resultLogin.Wait();

            var result = resultLogin.GetAwaiter().GetResult();
        }

        private async Task<Response<string>> PostGetCode()
        {
            // https://developers.google.com/identity/protocols/oauth2/web-server#httprest_3
            // criando a url para comunicar entre o servidor
            string url = "https://oauth2.googleapis.com/token"
                .SetQueryParams(new
                {
                    code = idToken,
                    client_id = "924539222128-2dd6ug7m4g6b33v2sh1t6r9hghfegk5t.apps.googleusercontent.com",
                    client_secret = "NzP_mnOHogbb7I1yyWpUzQwK",
                    redirect_uri = "https%3A//localhost%3A44381/code&",
                    grant_type = "authorization_code"
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url, mediaType: "application/x-www-form-urlencoded");
            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

            return jsonResult;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            nome = txtUser.Text.ToString();
            email = txtEmail.Text.ToString();
            senha = txtSenha.Text.ToString();
            confirmarSenha = txtConfirmarSenha.Text.ToString();

            // verificação se os campos estão vazios
            if (!nome.IsEmpty() && !email.IsEmpty() && !senha.IsEmpty() && !confirmarSenha.IsEmpty())
            {
                if (confirmarSenha == senha)
                {
                    try
                    {
                        var resultLogin = Task.Run(() => PostRegister());
                        resultLogin.Wait();

                        var result = resultLogin.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            // Redirect to verify email page
                            Response.Redirect("~/Register/Plan?uid=" + result.data);
                        }
                        else
                        {
                            // Mostra uma mensagem de erro
                            errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                                EnumTypeError.error,
                                result.message);
                        }
                    } catch (Exception) {
                        // Mostra uma mensagem de erro
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.error,
                            "Ocorreu um erro, tente novamente mais tarde.");
                    }
                    
                } else {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.warning,
                        "Os valores dos campos de senha diferem.");
                }
            } else {
                // Mostra uma mensagem de erro
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                    EnumTypeError.warning,
                    "Insira os valores no campo");
            }
        }

        private async Task<Response<string>> PostRegister()
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/register")
                .SetQueryParams(new
                {
                    username = nome,
                    email = email,
                    password = senha
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);

            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

            return jsonResult;
        }
    }
}