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

        }
        private async Task<Response<string>> postChangePassword(
            string email)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/generate-password-reset")
                .SetQueryParams(new
                {
                    email = email
                }); ;

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);

            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

            return jsonResult;
        }

        protected void btnAlterarNome_Click(object sender, EventArgs e)
        {

        }

        protected void btnMudarSenha_Click(object sender, EventArgs e)
        {
            if(!txtEmail.Text.IsEmpty())
            {
                
                try{
                    var resultTask = Task.Run(() => postChangePassword(txtEmail.Text.ToString()));
                    resultTask.Wait();

                    var result = resultTask.GetAwaiter().GetResult();

                    if (result.succeeded)
                    {
                        // TODO ...
                        txtEmail.Text = "";
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                          EnumTypeError.information,
                          "Confirmação de troca enviada ao email");
                    }
                    else
                    {
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                          EnumTypeError.error,
                          result.message);
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
                      "Insira um email, bobão");
            }
            
            
        }
    }
}