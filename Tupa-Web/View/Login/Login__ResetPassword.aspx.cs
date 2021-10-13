using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Helpers;
using Tupa_Web.Common.Models;

namespace Tupa_Web.View.Login
{
    public partial class Login__ResetPassword : System.Web.UI.Page
    {
        private string senha { get; set; }

        private string confirmarSenha { get; set; }

        private string email { get; set; }

        private string token { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrEmpty(Request.QueryString["email"]) &&
                !string.IsNullOrEmpty(Request.QueryString["token"]))
            {
                email = Request.QueryString["email"];
                token = Request.QueryString["token"];
            } else {
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            senha = txtSenha.Text.ToString();
            confirmarSenha = txtConfirmarSenha.Text.ToString();

            // verificação se os campos estão vazios
            if (!senha.IsEmpty() && !confirmarSenha.IsEmpty())
            {
                if (senha == confirmarSenha)
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
                    }
                    catch (Exception)
                    {
                        string url = "https://tupaserver.azurewebsites.net/api/Account/change-password?email=" + HttpUtility.UrlEncode(email) + " &token=" + HttpUtility.UrlEncode(token) + "&password=" + HttpUtility.UrlEncode(senha);

                        // Mostra uma mensagem de erro
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.error,
                            "Ocorreu um erro, tente novamente mais tarde." + url);
                    }
                }
                else
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.warning,
                        "Os valores dos campos de senha diferem.");
                }
            }
            else
            {
                // Mostra uma mensagem de erro
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                    EnumTypeError.warning,
                    "Insira os valores no campo");
            }
        }

        private async Task<Response<string>> PostChangePassword()
        {
            // criando a url para comunicar entre o servidor
            string url = "https://tupaserver.azurewebsites.net/api/Account/change-password?email=" + HttpUtility.UrlEncode(email) + " &token=" + HttpUtility.UrlEncode(token) + " &password=" + HttpUtility.UrlEncode(senha);

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