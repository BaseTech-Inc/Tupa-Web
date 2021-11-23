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

            if (!IsPostBack)
            {
                // Setup
                UpdateProgressImage2.AssociatedUpdatePanelID = UpdatePanelImage2.UniqueID;
            }

            // Post Back usando um evento Javascript
            ClientScript.GetPostBackEventReference(this, string.Empty);

            string targetCtrl = Page.Request.Params.Get("__EVENTTARGET");
            string parameter = Page.Request.Params.Get("__EVENTARGUMENT");

            if (targetCtrl != null && targetCtrl != string.Empty)
            {
                if (IsPostBack)
                {
                    if (targetCtrl == UpdatePanelPopUp.ClientID && parameter == "Close")
                    {
                        panelPopUp.InnerHtml = "";
                    }

                    if (targetCtrl == btnApagarConta.ClientID)
                    {
                        ApagarConta();
                    }
                }
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

        private async Task<Response<String>> DeleteAccount(
            string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
              .AddPath("api/Account")
              .SetQueryParams(new
              {
                  
              });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpDeleteAccount(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<String>>(stringResult);

            return jsonResult;
        }

        private async Task<Response<String>> PutImageProfile(
            string bearerToken,
            string strinContent = "")
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
              .AddPath("api/Account/image-profile")
              .SetQueryParams(new { });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPut(url, bearerToken: bearerToken, stringContent: strinContent);

            var jsonResult = JsonSerializer.Deserialize<Response<String>>(stringResult);

            return jsonResult;
        }

        private async Task<Response<string>> GetImageProfile(
            string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
              .AddPath("api/Account/image-profile")
              .SetQueryParams(new
              { });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

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
                              "Algo deu errado, tente novamente mais tarde.");
                        }
                                                
                    }
                }
                catch (Exception)
                {
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                      EnumTypeError.warning,
                      "Ocorreu um erro, tente novamente mais tarde.");
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
                      "Ocorreu um erro, tente novamente mais tarde.");
                }
            }
            else
            {
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                      EnumTypeError.warning,
                      "Insira uma senha, bobão");
            }
        }

        protected void btnApagarConta_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    panelPopUp.InnerHtml = PopUpHelpers.PopUp(
                        "Você tem certeza absoluta?",
                        new string[] { "Esta ação não pode ser desfeita. Isso excluirá permanentemente a sua conta, e todos os seus dados.", "Digite SUA_CONTA para confirmar." },
                        "Eu desejo excluir a conta",
                        "OnClick_ApagarConta");
                }
            }
            catch
            {
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                    EnumTypeError.warning,
                    "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        private void ApagarConta()
        {
            try
            {
                var cookie = Request.Cookies["token"];
                if (cookie != null)
                {
                    var resultTaskGet = Task.Run(() => DeleteAccount(
                                bearerToken: cookie.Values[0]));
                    resultTaskGet.Wait();

                    var resultGet = resultTaskGet.GetAwaiter().GetResult();
                    if (resultGet.succeeded)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);

                        var refreshToken = Request.Cookies["refreshToken"];
                        refreshToken.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(refreshToken);

                        Response.Redirect("~/");
                    }
                    else
                    {
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.error,
                            "🤑 não apagou, pena");
                    }
                }
            }
            catch (Exception)
            {
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                    EnumTypeError.warning,
                    "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        protected void txtDeletarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                var cookie = Request.Cookies["token"];
                if (cookie != null)
                {
                    var resultTaskGet = Task.Run(() => PutImageProfile(
                                bearerToken: cookie.Values[0]));
                    resultTaskGet.Wait();

                    var resultGet = resultTaskGet.GetAwaiter().GetResult();
                    if (resultGet.succeeded)
                    {
                        Response.Redirect("~/Settings");
                    }
                    else
                    {
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.error,
                            resultGet.message);
                    }
                }
            }
            catch (Exception)
            {
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                    EnumTypeError.error,
                    "Não foi possível apagar a sua foto, que pena vai continuar vendo ela");
            }
        }

        protected void btnCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Before attempting to save the file, verify
                // that the FileUpload control contains a file.
                if (selecaoarquivo.HasFile)
                {
                    // Call a helper method routine to save the file.
                    var message = SaveFile(selecaoarquivo.PostedFile);

                    if (message.IsEmpty())
                    {
                        System.IO.Stream fs = selecaoarquivo.PostedFile.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                        var cookie = Request.Cookies["token"];
                        if (cookie != null)
                        {
                            var resultTaskGet = Task.Run(() => PutImageProfile(
                                        bearerToken: cookie.Values[0],
                                        strinContent: base64String));
                            resultTaskGet.Wait();

                            var resultGet = resultTaskGet.GetAwaiter().GetResult();
                            if (resultGet.succeeded)
                            {
                                Response.Redirect("~/Settings");
                            }
                            else
                            {
                                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                                   EnumTypeError.error,
                                   resultGet.message);
                            }
                        }
                    } else
                    {
                        errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.error,
                            message);
                    }
                }            
            } catch (Exception)
            {
                errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                       EnumTypeError.warning,
                       "Ocorreu um erro, tente novamente mais tarde.");
            }
        }

        private string SaveFile(HttpPostedFile file)
        {
            // Save the uploaded file to an "Uploads" directory
            // that already exists in the file system of the 
            // currently executing ASP.NET application.  
            // Creating an "Uploads" directory isolates uploaded 
            // files in a separate directory. This helps prevent
            // users from overwriting existing application files by
            // uploading files with names like "Web.config".
            string saveDir = @"\temp\uploads\";

            // Get the physical file system path for the currently
            // executing application.
            string appPath = Request.PhysicalApplicationPath;

            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.
            if (selecaoarquivo.HasFile)
            {
                string savePath = appPath + saveDir +
                    Server.HtmlEncode(selecaoarquivo.FileName);

                // Get the name of the file to upload.
                string fileName = Server.HtmlEncode(selecaoarquivo.FileName);

                // Get the extension of the uploaded file.
                string extension = System.IO.Path.GetExtension(fileName);

                // Allow only files with .doc or .xls extensions
                // to be uploaded.
                if ((extension == ".png") || (extension == ".jpg") || (extension == ".jpeg"))
                {
                    // Append the name of the file to upload to the path.
                    savePath += fileName;

                    // Call the SaveAs method to save the 
                    // uploaded file to the specified path.
                    // This example does not perform all
                    // the necessary error checking.               
                    // If a file with the same name
                    // already exists in the specified path,  
                    // the uploaded file overwrites it.
                    selecaoarquivo.SaveAs(savePath);

                    // Notify the user that their file was successfully uploaded.
                    return "";
                }
                else
                {
                    // Notify the user why their file was not uploaded.
                    return "Seu arquivo não foi enviado porque não tem extensão .png, .jpg ou .jpeg. 📷";
                }
            }
            else
            {
                return "Você não especificou um arquivo para upload. 😥";
            }
        }

        protected void UpdatePanelImage2_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    // Verifica se o usuário está autenticado
                    var cookie = Request.Cookies["token"];

                    if (cookie != null)
                    {
                        var resultTask = Task.Run(() => GetImageProfile(cookie.Values[0]));
                        resultTask.Wait();

                        var result = resultTask.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            var url = "data:image/png;base64," + result.data;

                            imageUserTwo.ImageUrl = url;
                        }
                    }

                }
                catch (Exception) {
                    errorMessage.InnerHtml = ErrorMessageHelpers.ErrorMessage(
                      EnumTypeError.warning,
                      "Ocorreu um erro, tente novamente mais tarde.");
                }
            }
        }

        protected void TimerImage2_Tick(object sender, EventArgs e)
        {
            // Setup
            TimerImage2.Enabled = false;

            UpdatePanelImage2.Update();
        }
    }
}