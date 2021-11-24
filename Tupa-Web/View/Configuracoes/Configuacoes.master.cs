using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Models;
using Tupa_Web.Common.Security;

namespace Tupa_Web.View.Configuracoes
{
    public partial class Configuacoes : System.Web.UI.MasterPage
    {
        private string userName;
        public string UserName { 
            get 
            { 
                return userName; 
            } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            var cookie = Request.Cookies["token"];

            if (cookie != null)
            {
                try
                {
                    var resultTask = Task.Run(() => GetBasicProfile(cookie.Values[0]));
                    resultTask.Wait();

                    var result = resultTask.GetAwaiter().GetResult();

                    if (result.succeeded)
                    {
                        var basicProfile = result.data;

                        foreach (var info in basicProfile)
                        {
                            if (info.Key == "Nome")
                            {
                                userName = info.Value;
                            }
                        }
                    }
                } catch
                {

                }
            }
        }

        private async Task<Response<IDictionary<string, string>>> GetBasicProfile(
            string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/Account/basic-profile");

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<IDictionary<string, string>>>(stringResult);

            return jsonResult;
        }

        protected void TimerImage3_Tick(object sender, EventArgs e)
        {
            // Setup
            TimerImage3.Enabled = false;

            UpdatePanelImage3.Update();
        }

        protected void UpdatePanelImage3_Load(object sender, EventArgs e)
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

                            imgPictureHeader.ImageUrl = url;
                        }
                    }

                }
                catch (Exception) { }
            }
        }

        public static bool IsLoggedInGoogle()
        {
            var cookie = HttpContext.Current.Request.Cookies["google"];

            if (cookie == null)
            {
                return false;
            }

            return true;
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
    }
}