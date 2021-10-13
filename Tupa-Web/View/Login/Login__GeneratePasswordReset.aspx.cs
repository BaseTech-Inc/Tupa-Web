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

namespace Tupa_Web.View.Login
{
    public partial class Login_GeneratePasswordReset : System.Web.UI.Page
    {
        private string email { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var ReturnUrl = Request.QueryString["ReturnUrl"];

            if (ReturnUrl != null)
            {
                btnReturn.NavigateUrl = ReturnUrl;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text.ToString();

            if (!email.IsEmpty())
            {
                try
                {
                    // Post Generate Password Reset
                    var resultTask = Task.Run(() => PostGeneratePasswordReset());
                    resultTask.Wait();

                    var result = resultTask.GetAwaiter().GetResult();

                    if (result.succeeded)
                    {
                        Response.Redirect("~/");
                    } else
                    {
                        // Mostra uma mensagem de erro
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.error,
                            result.message);
                    }
                }
                catch
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro, tente novamente mais tarde.");
                }
            } else
            {
                // Mostra uma mensagem de erro
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                    EnumTypeError.warning,
                    "Insira os valores no campo");
            }            
        }

        private async Task<Response<string>> PostGeneratePasswordReset()
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/generate-password-reset")
                .SetQueryParams(new
                {
                    email = email
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);
            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

            return jsonResult;
        }

        public static string ColorTheme()
        {
            var cookie = HttpContext.Current.Request.Cookies["theme"];

            if (cookie == null)
            {
                return "";
            }

            if (cookie.Value != "white")
            {
                return "-alternative";
            }

            return "";
        }
    }
}