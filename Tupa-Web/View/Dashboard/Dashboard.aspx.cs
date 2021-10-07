using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Helpers;
using Tupa_Web.Common.Models;
using Tupa_Web.Model;

namespace Tupa_Web.View.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateProgress2.AssociatedUpdatePanelID = UpdatePanel2.UniqueID;
            //UpdateProgress1.AssociatedUpdatePanelID = UpdatePanel1.UniqueID;

            // Post Back usando um evento Javascript
            ClientScript.GetPostBackEventReference(this, string.Empty);

            string targetCtrl = Page.Request.Params.Get("__EVENTTARGET");
            string parameter = Page.Request.Params.Get("__EVENTARGUMENT");

            if (targetCtrl != null && targetCtrl != string.Empty)
            {
                if (IsPostBack)
                {
                    UpdatePanel1.Update();
                    //UpdatePanel2.Update();
                }
            }

            var cookie = Request.Cookies["token"];

            if (cookie == null)
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
        }

        private async Task<Response<IList<Alertas>>> GetAlertas(
            string year,
            string month,
            string day,
            string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Alertas")
                .SetQueryParams(new
                {
                    year = year,
                    month = month,
                    day = day
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<IList<Alertas>>>(stringResult);

            return jsonResult;
        }

        ICollection CreateDataSourceAlertas(IList<Alertas> listAlertas)
        {
            ArrayList values = new ArrayList();

            foreach (var alertas in listAlertas)
            {
                values.Add(
                new PositionDataAlertas(
                    alertas.distrito.nome,
                    alertas.descricao,
                    String.Format("{0} - {1}",
                        alertas.tempoInicio.ToString(
                            "t",
                            CultureInfo.CreateSpecificCulture("de-DE")),
                        alertas.tempoFinal.ToString(
                            "t",
                            CultureInfo.CreateSpecificCulture("de-DE")))));
            }                

            return values;
        }

        public class PositionDataAlertas
        {
            private string locale;
            private string description;
            private string time;

            public PositionDataAlertas(
                string locale,
                string description,
                string time)
            {
                this.locale = locale;
                this.description = description;
                this.time = time;
            }

            public string Locale => locale;

            public string Description => description;

            public string Time => time;
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            LoadAlertas(DateTime.Now);
        }

        private void LoadAlertas(DateTime datetime)
        {
            if (IsPostBack)
            {
                try
                {
                    var cookie = Request.Cookies["token"];

                    if (cookie != null)
                    {
                        // Repeater Source
                        var resultTask = Task.Run(() => GetAlertas(
                            datetime.Year.ToString(),
                            datetime.Month.ToString(),
                            datetime.Day.ToString(),
                            cookie.Values[0]));
                        resultTask.Wait();

                        var result = resultTask.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            if (result.data.Count > 0)
                            {
                                RepeaterAlertas.DataSource = CreateDataSourceAlertas(result.data);

                                RepeaterAlertas.DataBind();
                            }
                            else
                            {
                                // Mostra uma mensagem de erro
                                errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                    EnumTypeError.warning,
                                    "Não foi possível encontrar nenhum alerta.");
                            }
                        }
                    } else
                    {
                        Response.Redirect("~/");
                    }
                } catch
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro, tente novamente mais tarde.");
                }                
            }
        }

        protected void txtSearchDate_TextChanged(object sender, EventArgs e)
        {
            var date = txtSearchDate.Text.Split('-');

            var dateTime = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));

            LoadAlertas(dateTime);
        }

        private async Task<Response<Forecast>> GetForecastByCoord(
            string lat,
            string lon,
            string bearerToken
            )
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Forecast/coord")
                .SetQueryParams(new
                {
                    lat = lat,
                    lon = lon
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<Forecast>>(stringResult);

            return jsonResult;
        }

        ICollection CreateDataSourceForecast(Forecast forecast)
        {
            ArrayList values = new ArrayList();

            values.Add(
            new PositionDataForecast(
                forecast.q,
                Math.Round(forecast.main.temp, 1).ToString() + "°",
                forecast.weather.description));

            return values;
        }

        public class PositionDataForecast
        {
            private string locale;
            private string temperature;
            private string condition;

            public PositionDataForecast(
                string locale,
                string temperature,
                string condition)
            {
                this.locale = locale;
                this.temperature = temperature;
                this.condition = condition;
            }

            public string Locale => locale;

            public string Temperature => temperature;

            public string Condition => condition;
        }

        protected void UpdatePanel2_Load(object sender, EventArgs e)
        {
            LoadForecast();
        }

        private void LoadForecast()
        {
            if (IsPostBack)
            {
                try
                {
                    var cookie = Request.Cookies["token"];

                    if (cookie != null)
                    {
                        string lat = queryStringLat.Value;
                        string lon = queryStringLon.Value;

                        var resultTask = Task.Run(() => GetForecastByCoord(
                            lat,
                            lon,
                            cookie.Values[0]));
                        resultTask.Wait();

                        var result = resultTask.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            RepeaterForecast.DataSource = CreateDataSourceForecast(result.data);

                            RepeaterForecast.DataBind();
                        } else
                        {
                            // Mostra uma mensagem de erro
                            errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                EnumTypeError.warning,
                                result.message);
                        }
                    } else
                    {
                        Response.Redirect("~/");
                    }
                } catch
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro, tente novamente mais tarde.");
                }                
            }
        }
    }
}