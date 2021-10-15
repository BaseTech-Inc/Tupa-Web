using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Models;
using Tupa_Web.Common.Security;

namespace Tupa_Web.View
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string BodyAttributes
        {
            set
            {
                bodyElement.Attributes.Add("data-theme", value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Page.Title) || Page.Title == "Untitled Page")
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath);

                Page.Title = fileName;
            }

            var cookieTheme = Request.Cookies["theme"];

            if (cookieTheme != null)
            {
                BodyAttributes = cookieTheme.Value;
            }
            else
            {
                BodyAttributes = EnumColorTheme.white.ToString();
            }

            var Token = Request.Cookies["token"];
            var RefreshToken = Request.Cookies["refreshToken"];

            // Se não existir o Token, porém existir o RefreshToken então o token expirou
            if (Token == null && RefreshToken != null)
            {
                try
                {
                    var resultTask = Task.Run(() => RefreshTokenAccount(RefreshToken.Value));
                    resultTask.Wait();

                    var result = resultTask.GetAwaiter().GetResult();

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
                            cookie.Values.Add("expires", data.expiration.ToString());
                            cookie.HttpOnly = true;
                            cookie.Expires = data.expiration;

                            Response.Cookies.Add(cookie);
                        }

                        Response.Redirect("~/");
                    }
                } catch (Exception ex)
                {

                }
                
            }

            if (!IsPostBack)
            {
                // Setup
                UpdateProgressImage.AssociatedUpdatePanelID = UpdatePanelImage.UniqueID;
            }

            Page.DataBind();
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

        public static bool IsLogged()
        {
            var cookie = HttpContext.Current.Request.Cookies["token"];

            if (cookie == null)
            {
                return false;
            }

            return true;
        }

        public static bool ContainsHeader()
        {
            Page page = HttpContext.Current.Handler as Page;

            if (page != null)
            {
                if (page.MetaKeywords != null)
                {
                    var keywords = page.MetaKeywords.Split(',');

                    foreach (var keyword in keywords)
                    {
                        if (keyword.Trim() == "NoHeader")
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool ContainsFooter()
        {
            Page page = HttpContext.Current.Handler as Page;

            if (page != null)
            {
                if (page.MetaKeywords != null)
                {
                    var keywords = page.MetaKeywords.Split(',');

                    foreach (var keyword in keywords)
                    {
                        if (keyword.Trim() == "NoFooter")
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        protected void lbtnSair_Click(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["token"];

            if (cookie != null)
            {
                var resultTask = Task.Run(() => LogoutAccount());
                resultTask.Wait();

                var result = resultTask.GetAwaiter().GetResult();

                if (result.succeeded)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);

                    var cookieRefreshToken = Request.Cookies["refreshToken"];

                    if (cookieRefreshToken != null)
                    {
                        cookieRefreshToken.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookieRefreshToken);
                    }
                }
            }

            Response.Redirect("~/");
        }

        private async Task<Response<String>> LogoutAccount()
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
              .AddPath("api/Account/logout")
              .SetQueryParams(new
              {

              });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);

            var jsonResult = JsonSerializer.Deserialize<Response<String>>(stringResult);

            return jsonResult;
        }

        private async Task<Response<LoginResponse>> RefreshTokenAccount(
            string refreshToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
              .AddPath("api/Account/refresh-token")
              .SetQueryParams(new
              {

              });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url, refreshCookie: refreshToken, responsePage: Response);

            var jsonResult = JsonSerializer.Deserialize<Response<LoginResponse>>(stringResult);

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

        protected void UpdatePanelImage_Load(object sender, EventArgs e)
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

                            Image ImgUser = (Image)FindControl(imageUser.ClientID);

                            if (ImgUser != null)
                            {
                                ImgUser.ImageUrl = url;
                            }
                        }
                    }
                    
                } catch (Exception) { }                
            }
        }

        protected void TimerImage_Tick(object sender, EventArgs e)
        {
            // Setup
            TimerImage.Enabled = false;

            UpdatePanelImage.Update();
        }
    }
}