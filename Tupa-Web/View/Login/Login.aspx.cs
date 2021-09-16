using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Tupa_Web.Common.Models;
using Tupa_Web.Common.Security;

namespace Tupa_Web.View.Login
{
    public partial class Login : Page
    {
        private readonly string baseUrl = "https://localhost:5001/";

        private string email { get; set; }
        private string senha { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Click += new EventHandler(this.btnLogin_Click);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text.ToString();
            senha = txtSenha.Text.ToString();

            if (!email.IsEmpty() && !senha.IsEmpty())
            {
                PostLogin().GetAwaiter().GetResult();
            }
        }

        private async Task PostLogin()
        {
            string url = baseUrl
                .AddPath("api/Account/login")
                .SetQueryParams(new
                {
                    email = email,
                    password = senha
                });

            var loginResult = await HttpRequestUrl.ProcessHttpClientPost(url);

            var jsonResult = JsonSerializer.Deserialize<Response<LoginResponse>>(loginResult);

            if (jsonResult.succeeded)
            {
                errorMessage.Attributes["class"] = errorMessage.Attributes["class"] + " disabled";

                var cookie = Request.Cookies["token"];

                if (cookie == null)
                {
                    cookie = new HttpCookie("token");

                    cookie.Values.Add("access_token", jsonResult.data.access_token);
                    cookie.Values.Add("token_type", jsonResult.data.token_type);
                    cookie.Values.Add("expiration", jsonResult.data.expiration.ToString());
                    cookie.HttpOnly = true;

                    this.Page.Response.AppendCookie(cookie);
                }

                Response.Redirect("~/");
            } else {
                errorMessage.Attributes["class"] = errorMessage.Attributes["class"].Replace("disabled", "").Trim();
                textErrorMessage.InnerText = jsonResult.message;
                textErrorMessage.Attributes["title"] = jsonResult.message;
            }
        }
    }
}