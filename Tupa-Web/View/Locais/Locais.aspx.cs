using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Models;
using Tupa_Web.Common.Security;
using Tupa_Web.Model;

namespace Tupa_Web.View.Locais
{
    public partial class Locais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["token"];

            if (cookie == null) { Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
            }
            else
            {
                var resultTaskGet = Task.Run(() => GetHistoricoUsuarioWithPagination(1,
                            bearerToken: cookie.Values[0]));
                resultTaskGet.Wait();

                var resultGet = resultTaskGet.GetAwaiter().GetResult();

                if (resultGet.succeeded)
                {
                    var values = CreateDataSourceLocais(resultGet.data.items);
                    rep.DataSource = values;
                    rep.DataBind();

                }
            }
  
        }

        public class PositionDataLocais
        {

            private string intervaloDeTempo;
            private string distanciaPercurso;
            private string tempoTotal;
            private string eventos;
            private string enchentes;

            public PositionDataLocais(string intervaloDeTempo, string distanciaPercurso, string tempoTotal, string eventos, string enchentes)
            {
                this.intervaloDeTempo = intervaloDeTempo;
                this.distanciaPercurso = distanciaPercurso;
                this.tempoTotal = tempoTotal;
                this.eventos = eventos;
                this.enchentes = enchentes;


            }

            public string IntervaloDeTempo
            {
                get
                {
                    return intervaloDeTempo;
                }
            }

            public string DistanciaPercurso
            {
                get
                {
                    return distanciaPercurso;
                }
            }

            public string TempoTotal
            {
                get
                {
                    return tempoTotal;
                }
            }

            public string Eventos
            {
                get
                {
                    return eventos;
                }
            }

            public string Enchentes
            {
                get
                {
                    return enchentes;
                }
            }

            
        }

        private ICollection CreateDataSourceLocais(IList<HistoricoUsuario> listHist)
        {
            ArrayList values = new ArrayList();

            foreach (var hist in listHist)
            {
                values.Add(
                new PositionDataLocais(
                hist.tempoPartida.Hour + ":" + hist.tempoPartida.Minute + " - " + 
                hist.tempoChegada.Hour + ":" + hist.tempoChegada.Minute,
                hist.distanciaPercurso.ToString(),
                (hist.tempoChegada - hist.tempoPartida).ToString(),
                "1", "1"

                    ));
            }

            return values;
        }

        private async Task<Response<PaginatedList<HistoricoUsuario>>> GetHistoricoUsuarioWithPagination(
            int pageNumber, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/HistoricoUsuario/pagination")
                .SetQueryParams(new
                {
                    PageNumber = pageNumber,
                }); ;

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);


            var jsonResult = JsonSerializer.Deserialize<Response<PaginatedList<HistoricoUsuario>>>(stringResult);

            return jsonResult;
        }

        
    }
}