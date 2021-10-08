using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Models;

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

            var cookie = Request.Cookies["theme"];

            if (cookie != null)
            {
                BodyAttributes = cookie.Value;
            }
            else
            {
                BodyAttributes = EnumColorTheme.white.ToString();
            }

            Page.DataBind();
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
    }
}