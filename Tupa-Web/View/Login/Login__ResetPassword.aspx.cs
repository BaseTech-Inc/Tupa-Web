using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Helpers;
using Tupa_Web.Common.Models;

namespace Tupa_Web.View.Login
{
    public partial class Login__ResetPassword : System.Web.UI.Page
    {
        private string password { get; set; }

        private string confirmPassword { get; set; }

        private string email { get; set; }

        private string token { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            if (
                !string.IsNullOrEmpty(Request.QueryString["email"]) &&
                !string.IsNullOrEmpty(Request.QueryString["token"]))
            {
                email = Request.QueryString["email"];
                token = Request.QueryString["token"];

                password = txtSenha.Text.ToString();
                confirmPassword = txtConfirmarSenha.Text.ToString();

                if (password == confirmPassword)
                {
                    try
                    {
                        var resultTask = Task.Run(() => PostChangePassword());
                        resultTask.Wait();

                        var result = resultTask.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            // Redirect to verify email page
                            Response.Redirect("~/Login");
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
                Response.Redirect("~/");
            }
        }

        private async Task<Response<string>> PostChangePassword()
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/change-password")
                .SetQueryParams(new
                {
                    email = email,
                    token = token,
                    password = password
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);

            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

            return jsonResult;
        }
    }
}