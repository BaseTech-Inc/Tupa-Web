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

            if (cookie == null) 
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
            
            if (!IsPostBack)
            {
                LoadHistoricoUsuario();
            }
        }

        public class PositionDataLocais
        {
            private string intervaloDeTempo;
            private string distanciaPercurso;
            private string local;
            private string eventos;
            private string enchentes;
            private string urlMapas;

            public PositionDataLocais(string intervaloDeTempo, string distanciaPercurso, string local, string eventos, string enchentes, string urlMapas)
            {
                this.intervaloDeTempo = intervaloDeTempo;
                this.distanciaPercurso = distanciaPercurso;
                this.local = local;
                this.eventos = eventos;
                this.enchentes = enchentes;
                this.urlMapas = urlMapas;
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

            public string Local
            {
                get
                {
                    return local;
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

            public string UrlMapas
            {
                get
                {
                    return urlMapas;
                }
            }            
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
        
        private async Task<List<Ponto>> DecodeCoordinates(
            string encodedPoints, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/GooglePoints/decode-coordinates")
                .SetQueryParams(new
                {
                    encodedPoints = encodedPoints,
                }); ;

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);


            var jsonResult = JsonSerializer.Deserialize<List<Ponto>>(stringResult);

            return jsonResult;
        }        

        private void LoadHistoricoUsuario()
        {
            var cookie = Request.Cookies["token"];

            if (cookie != null)
            {
                var resultTaskGet = Task.Run(() => GetHistoricoUsuarioWithPagination(1,
                            bearerToken: cookie.Values[0]));
                resultTaskGet.Wait();

                var resultGet = resultTaskGet.GetAwaiter().GetResult();

                if (resultGet.succeeded)
                {
                    IList<PositionDataLocais> dataLocaisDay = new List<PositionDataLocais>();
                    IList<PositionDataLocais> dataLocaisMonth = new List<PositionDataLocais>();
                    IList<PositionDataLocais> dataLocaisYear = new List<PositionDataLocais>();

                    foreach (var item in resultGet.data.items)
                    {
                        var resultTaskDecode = Task.Run(() => DecodeCoordinates(item.rota,
                            bearerToken: cookie.Values[0]));
                        resultTaskDecode.Wait();

                        var resultDecode = resultTaskDecode.GetAwaiter().GetResult();

                        string googleUrl = $"https://www.google.com/maps/embed?pb=!1m11!4m9!3e0!4m3!3m2!1d{ resultDecode[0].latitude.ToString().Replace(",", ".") }!2d{ resultDecode[0].longitude.ToString().Replace(",", ".") }!4m3!3m2!1d{ resultDecode[resultDecode.Count - 1].latitude.ToString().Replace(",", ".") }!2d{ resultDecode[resultDecode.Count - 1].longitude.ToString().Replace(",", ".") }!5e0";

                        if (item.tempoPartida > DateTime.Now.AddDays(-7))
                        {
                            dataLocaisDay.Add(
                              new PositionDataLocais(
                              item.tempoPartida.Hour + ":" + item.tempoPartida.Minute + " - " +
                              item.tempoChegada.Hour + ":" + item.tempoChegada.Minute,
                              item.distanciaPercurso.ToString() + "km",
                              "Guilherme Ivo",
                              resultDecode.Count.ToString(),
                              "",
                              googleUrl
                              ));
                        } else if (item.tempoPartida > DateTime.Now.AddDays(-30))
                        {
                            dataLocaisMonth.Add(
                              new PositionDataLocais(
                              item.tempoPartida.Hour + ":" + item.tempoPartida.Minute + " - " +
                              item.tempoChegada.Hour + ":" + item.tempoChegada.Minute,
                              item.distanciaPercurso.ToString() + "km",
                              "Guilherme Ivo",
                              resultDecode.Count.ToString(),
                              "",
                              googleUrl
                              ));
                        } else
                        {
                            dataLocaisYear.Add(
                             new PositionDataLocais(
                             item.tempoPartida.Hour + ":" + item.tempoPartida.Minute + " - " +
                             item.tempoChegada.Hour + ":" + item.tempoChegada.Minute,
                             item.distanciaPercurso.ToString() + "km",
                             "Guilherme Ivo",
                             resultDecode.Count.ToString(),
                             "",
                             googleUrl
                             ));
                        }                        
                    }

                    rep.DataSource = dataLocaisDay;
                    rep.DataBind();
                    repMonth.DataSource = dataLocaisMonth;
                    rep.DataBind();
                    repYear.DataSource = dataLocaisYear;
                    rep.DataBind();
                }
            }                
        }
    }
}