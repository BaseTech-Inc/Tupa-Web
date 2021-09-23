using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Helpers;
using Tupa_Web.Common.Models;
using Tupa_Web.Common.Security;

namespace Tupa_Web.View.Login
{
    public partial class Login : Page
    {
        private string email { get; set; }

        private string senha { get; set; }

        private string code { get; set; }

        private string idToken { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Post Back usando um evento Javascript
            ClientScript.GetPostBackEventReference(this, string.Empty);

            string targetCtrl = Page.Request.Params.Get("__EVENTTARGET");
            string parameter = Request["__EVENTARGUMENT"];

            if (targetCtrl != null && targetCtrl != string.Empty)
            {
                code = parameter;

                // Fire event
                btnRegisterGoogle2_Click(this, new EventArgs());
            }
        }

        protected void btnRegisterGoogle2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get code
                var resultGoogleTask = Task.Run(() => PostGetCode());
                resultGoogleTask.Wait();

                var resultGoogle = resultGoogleTask.GetAwaiter().GetResult();

                idToken = resultGoogle.id_token;

                // Registra a conta no servidor
                var resultLoginTask = Task.Run(() => PostRegisterGoogle());
                resultLoginTask.Wait();

                var resultLogin = resultLoginTask.GetAwaiter().GetResult();

                if (resultLogin.succeeded)
                {
                    var data = resultLogin.data;

                    // em caso de sucesso cria-se um Cookie com o access_token, token_type e expiration
                    var cookie = Request.Cookies["token"];

                    if (cookie == null)
                    {
                        cookie = new HttpCookie("token");

                        cookie.Values.Add("access_token", data.access_token);
                        cookie.Values.Add("token_type", data.token_type);
                        cookie.Values.Add("expiration", data.expiration.ToString());
                        cookie.HttpOnly = true;

                        this.Page.Response.AppendCookie(cookie);
                    }

                    Response.Redirect("~/");
                }
                else
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        resultLogin.message);
                }
            }
            catch
            {
                // Mostra uma mensagem de erro
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                    EnumTypeError.error,
                    "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        private async Task<GoogleResponse> PostGetCode()
        {
            var appSettings = WebConfigurationManager.AppSettings;

            var client_id = appSettings["client_id"];
            var client_secret = appSettings["client_secret"];
            var redirect_uri = appSettings["redirect_uri"];

            // https://developers.google.com/identity/protocols/oauth2/web-server#httprest_3
            // criando a url para comunicar entre o servidor
            string url = "https://oauth2.googleapis.com/token"
                .SetQueryParams(new
                {
                    code = code,
                    client_id = client_id,
                    client_secret = client_secret,
                    redirect_uri = HttpUtility.UrlEncode(redirect_uri),
                    grant_type = "authorization_code"
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url, mediaType: "application/x-www-form-urlencoded");
            var jsonResult = JsonSerializer.Deserialize<GoogleResponse>(stringResult);

            return jsonResult;
        }

        private async Task<Response<LoginResponse>> PostRegisterGoogle()
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/login-google")
                .SetQueryParams(new
                {
                    idToken = idToken
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);
            var jsonResult = JsonSerializer.Deserialize<Response<LoginResponse>>(stringResult);

            return jsonResult;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text.ToString();
            senha = txtSenha.Text.ToString();

            // verificação se os campos estão vazios
            if (!email.IsEmpty() && !senha.IsEmpty())
            {
                try
                {
                    var resultLogin = Task.Run(() => PostLogin());
                    resultLogin.Wait();

                    var result = resultLogin.GetAwaiter().GetResult();

                    if (result.succeeded)
                    {
                        var data = result.data;

                        // em caso de sucesso cria-se um Cookie com o access_token, token_type e expiration
                        var cookie = Request.Cookies["token"];

                        if (cookie == null)
                        {
                            cookie = new HttpCookie("token");

                            cookie.Values.Add("access_token", data.access_token);
                            cookie.Values.Add("token_type", data.token_type);
                            cookie.Values.Add("expiration", data.expiration.ToString());
                            cookie.HttpOnly = true;

                            this.Page.Response.AppendCookie(cookie);
                        }

                        Response.Redirect("~/");
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
                    "Insira os valores no campo");
            }
        }

        private async Task<Response<LoginResponse>> PostLogin()
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/login")
                .SetQueryParams(new
                {
                    email = email,
                    password = senha
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);

            var jsonResult = JsonSerializer.Deserialize<Response<LoginResponse>>(stringResult);

            return jsonResult;
        }
    }
}