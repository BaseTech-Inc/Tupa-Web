using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Models;

namespace Tupa_Web.View.Login
{
    public partial class Login_Verify : System.Web.UI.Page
    {
        private string userId { get; set; }

        private string tokenEmail { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (
                !string.IsNullOrEmpty(Request.QueryString["userId"]) && 
                !string.IsNullOrEmpty(Request.QueryString["tokenEmail"]))
            {
                userId = Request.QueryString["userId"];
                tokenEmail = Request.QueryString["tokenEmail"];

                try
                {
                    var resultTask = Task.Run(() => PostVerifyEmail());
                    resultTask.Wait();

                    var result = resultTask.GetAwaiter().GetResult();

                    if (result.succeeded)
                    {
                        Response.Redirect("~/Login");
                    } else
                    {
                    }
                } catch (Exception) { }
            } else {
                Response.Redirect("~/");
            }
        }

        private async Task<Response<string>> PostVerifyEmail()
        {
            // criando a url para comunicar entre o servidor
            string url = "https://tupaserver.azurewebsites.net/api/Account/verify-email?userId=" + HttpUtility.UrlEncode(userId) + " &tokenEmail=" + HttpUtility.UrlEncode(tokenEmail);

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientPost(url);

            var jsonResult = JsonSerializer.Deserialize<Response<string>>(stringResult);

            return jsonResult;
        }
    }
}