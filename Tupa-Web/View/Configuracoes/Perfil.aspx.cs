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

namespace Tupa_Web.View.Configuracoes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["token"];

            if (cookie == null)
            {
                Response.Redirect("~/");
            }
        }
        private async Task<Response<string>> postChangePassword(
            string oldPassword, string newPassword, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/change-password/id")
                .SetQueryParams(new
                {
                    newPassword = newPassword,
                    oldPassword = oldPassword
                }); ;

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url, bearerToken: bearerToken);
            

            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

            return jsonResult;
        }

        protected void btnAlterarNome_Click(object sender, EventArgs e)
        {

        }

        protected void btnMudarSenha_Click(object sender, EventArgs e)
        {

            if (!txtOld.Text.IsEmpty() && !txtSenha.Text.IsEmpty())
            {
                
                try{
                    var cookie = Request.Cookies["token"];
                    if (cookie != null)
                    {
                        var resultTask = Task.Run(() => postChangePassword(
                            txtOld.Text.ToString(), 
                            txtSenha.Text.ToString(), 
                            cookie.Values[0]));
                        resultTask.Wait();

                        var result = resultTask.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            // TODO ...
                            txtSenha.Text = "";
                            errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                              EnumTypeError.information,
                              "Sucesso, Bro!");
                        }
                        else
                        {
                            errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                              EnumTypeError.error,
                              result.message);
                        }
                    }
                    else
                    {
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(EnumTypeError.warning,
                            "Você não está autenticado, mané.");
                    }
                }
                catch (Exception)
                {
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                      EnumTypeError.warning,
                      "É, deu ruim, mais sorte na próxima, amigão");
                }
            }
            else
            {
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                      EnumTypeError.warning,
                      "Insira uma senha, bobão");
            }
        }
    }
}