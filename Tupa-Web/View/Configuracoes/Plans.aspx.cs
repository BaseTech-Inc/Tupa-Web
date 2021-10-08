using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Models;
using Tupa_Web.Model;

namespace Tupa_Web.View.Configuracoes
{
    public partial class Plans : System.Web.UI.Page
    {
        private static string tipoUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["token"];

            if (cookie == null)
            {
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
            }
            else
            {
                var resultTaskGet = Task.Run(() => GetBasicProfile(
                            bearerToken: cookie.Values[0]));
                resultTaskGet.Wait();

                var resultGet = resultTaskGet.GetAwaiter().GetResult();

                if (resultGet.succeeded)
                {
                    tipoUser = resultGet.data.TipoUsuario;
                }
            }
        }
        
        public static bool IsPremium()
        {
            if(tipoUser == "Premium")
            {
                return true;
            }
            return false;
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
    }
}