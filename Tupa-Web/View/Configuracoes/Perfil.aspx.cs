﻿using System;
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
using Tupa_Web.Model;

namespace Tupa_Web.View.Configuracoes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["token"];

            if (cookie == null)
            {
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
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

        private async Task<Response<Usuario>> GetBasicProfile(
              string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa 
              .AddPath("api/Account/basic-profile")
              .SetQueryParams(new
              {

              });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<Usuario>>(stringResult);

            return jsonResult;
        }
        private async Task<Response<String>> PutBasicProfile(
              string userName,
              string tipoUser,
              string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
              .AddPath("api/Account/basic-profile")
              .SetQueryParams(new
              {
                  UserName = userName,
                  TipoUsuario = tipoUser
              });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPut(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<String>>(stringResult);

            return jsonResult;
        }

        protected void btnAlterarNome_Click(object sender, EventArgs e)
        {
            if (!txtNome.Text.IsEmpty())
            {
                try
                {
                    var cookie = Request.Cookies["token"];
                    if (cookie != null)
                    {
                        var resultTaskGet = Task.Run(() => GetBasicProfile(
                            bearerToken: cookie.Values[0]));
                        resultTaskGet.Wait();

                        var resultGet = resultTaskGet.GetAwaiter().GetResult();
                        if (resultGet.succeeded)
                        {

                            var resultTask = Task.Run(() => PutBasicProfile(
                            txtNome.Text.ToString(), resultGet.data.TipoUsuario,
                            bearerToken: cookie.Values[0]));
                            resultTask.Wait();

                            var result = resultTaskGet.GetAwaiter().GetResult();
                            if (result.succeeded)
                            {
                                Response.Redirect("~/Settings/Perfil");
                            }
                        }
                        else
                        {
                            errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                      EnumTypeError.warning,
                      "Cu de pia");
                        }
                                                
                    }
                }
                catch (Exception)
                {
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                      EnumTypeError.warning,
                      "😥 Deu ruim, bro! Tente de novo");
                }
            }
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