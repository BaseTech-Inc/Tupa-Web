using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
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

        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text.ToString();
            senha = txtSenha.Text.ToString();

            // verificação se os campos estão vazios
            if (!email.IsEmpty() && !senha.IsEmpty())
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