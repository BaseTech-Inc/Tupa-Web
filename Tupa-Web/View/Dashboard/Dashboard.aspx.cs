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
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Tupa_Web.Common.Enumerations;
using Tupa_Web.Common.Helpers;
using Tupa_Web.Common.Models;
using Tupa_Web.Common.Security;
using Tupa_Web.Model;

namespace Tupa_Web.View.Dashboard
{
    public partial class Dashboard : Page
    {
        private static string SearchLocate { get; set; }

        private static string SearchDate { get; set; } = String.Format("{0}", DateTime.Now.ToString("yyyy-MM-dd"));

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar se usuário está autenticado
            var cookie = Request.Cookies["token"];

            if (cookie == null)
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });

            if (!IsPostBack)
            {
                // Setup
                UpdateProgressForecast.AssociatedUpdatePanelID = UpdatePanel1.UniqueID;
                UpdateProgressAlertas.AssociatedUpdatePanelID = UpdatePanel1.UniqueID;
                UpdateProgressChart.AssociatedUpdatePanelID = UpdatePanel1.UniqueID;
                UpdateProgressAlertasMorePages.AssociatedUpdatePanelID = UpdatePanelAlertsMorePages.UniqueID;

                PageNumberAlertas = 1;

                if (!SearchDate.IsEmpty())
                    txtSearchDate.Text = SearchDate;
                if (!SearchLocate.IsEmpty())
                    txtSearch.Text = SearchLocate;
            } else
            {
                if (txtSearch.Text != SearchLocate)
                    PageNumberAlertas = 1;

                errorMessage.InnerHtml = "";
            }

            // Post Back usando um evento Javascript
            ClientScript.GetPostBackEventReference(this, string.Empty);

            string targetCtrl = Page.Request.Params.Get("__EVENTTARGET");
            string parameter = Page.Request.Params.Get("__EVENTARGUMENT");

            if (targetCtrl != null && targetCtrl != string.Empty)
            {
                if (IsPostBack)
                {
                    if (parameter == "PageNumber")
                    {
                        PageNumberAlertas++;

                        UpdatePanelAlertsMorePages.Update();
                    }
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            // Setup
            timer1.Enabled = false;

            UpdatePanelForecast.Update();
            UpdatePanelAlertas.Update();
            UpdatePanelChart.Update();

            UpdateProgressForecast.AssociatedUpdatePanelID = UpdatePanelForecast.UniqueID;
            UpdateProgressAlertas.AssociatedUpdatePanelID = UpdatePanelAlertas.UniqueID;
            UpdateProgressChart.AssociatedUpdatePanelID = UpdatePanelChart.UniqueID;
        }

        private (string district, string city, string state) GetLocale(string address)
        {
            SearchLocate = address;
            
            string district;
            string city = "";
            string state = "";

            if (SearchLocate.Contains(","))
            {
                district = SearchLocate.Split(',')[0].Trim();

                if (SearchLocate.Contains("-"))
                {
                    city = SearchLocate.Split(',')[1].Split('-')[0].Trim();

                    if (SearchLocate.Split(',')[1].Split('-').Length > 1)
                    {
                        state = SearchLocate.Split(',')[1].Split('-')[1].Trim();
                    }
                    
                } 
            }
            else
            {
                district = SearchLocate.Trim();
            }

            return (district, city, state);
        }

        private DateTime GetDate()
        {
            DateTime dateTime;

            SearchDate = txtSearchDate.Text;

            if (!SearchDate.IsEmpty())
            {
                var date = SearchDate.Split('-');
                dateTime = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
            }
            else
            {
                dateTime = DateTime.Now;
            }

            return dateTime;
        }

        private (string latitude, string longitude) GetCoordinates()
        {
            string lat = queryStringLat.Value;
            string lon = queryStringLon.Value;

            return (lat, lon);
        }

        #region Alertas

        private static int PageNumberAlertas { get; set; } = 1;

        private static IList<Repeater> lastReapeater = new List<Repeater>();

        private readonly int PAGE_SIZE_ALERTS = 6;

        // GET: api/v1/Alertas/Pagination
        private async Task<Response<PaginatedList<Alertas>>> GetAlertasWithPagination(
            string year, string month, string day, int PageNumber, int PageSize, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Alertas/Pagination")
                .SetQueryParams(new
                {
                    year,
                    month,
                    day,
                    PageNumber,
                    PageSize
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<PaginatedList<Alertas>>>(stringResult);

            return jsonResult;
        }

        // GET: api/v1/Alertas/Bairro/Paginatio
        private async Task<Response<PaginatedList<Alertas>>> GetAlertasByNameWithPagination(
            string year, string month, string day, int PageNumber, int PageSize, string district, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Alertas/Bairro/Pagination")
                .SetQueryParams(new
                {
                    year,
                    month,
                    day,
                    district,
                    PageNumber,
                    PageSize
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<PaginatedList<Alertas>>>(stringResult);

            return jsonResult;
        }

        // Events
        protected void UpdatePanelAlertas_Load(object sender, EventArgs e)
        {
            LoadAlertas();
        }

        protected void txtSearchDate_TextChanged(object sender, EventArgs e)
        {
            lastReapeater = new List<Repeater>();
            PageNumberAlertas = 1;

            UpdatePanelAlertas.Update();
        }

        protected void UpdatePanelAlertsMorePages_Load(object sender, EventArgs e)
        {
            LoadAlertsMorePages();
        }

        // Loads
        private void LoadAlertas()
        {
            if (IsPostBack)
            {
                try
                {
                    // Verifica se o usuário está autenticado
                    var cookie = Request.Cookies["token"];

                    if (cookie == null)
                        Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });

                    var dateTime = GetDate();
                    var (district, city, state) = GetLocale(txtSearch.Text);

                    Response<PaginatedList<Alertas>> resultAlertas = null;

                    if (PageNumberAlertas == 1)
                    {
                        // Pesquisa todos os alertas ou filtra pelo distrito
                        if (district.IsEmpty())
                        {
                            var resultTask = Task.Run(() => GetAlertasWithPagination(
                                dateTime.Year.ToString(),
                                dateTime.Month.ToString(),
                                dateTime.Day.ToString(),
                                PageNumberAlertas,
                                PAGE_SIZE_ALERTS,
                                cookie.Values[0]));
                            resultTask.Wait();

                            resultAlertas = resultTask.GetAwaiter().GetResult();
                        }
                        else
                        {
                            var resultTask = Task.Run(() => GetAlertasByNameWithPagination(
                                dateTime.Year.ToString(),
                                dateTime.Month.ToString(),
                                dateTime.Day.ToString(),
                                PageNumberAlertas,
                                PAGE_SIZE_ALERTS,
                                district,
                                cookie.Values[0]));
                            resultTask.Wait();

                            resultAlertas = resultTask.GetAwaiter().GetResult();
                        }

                        if (resultAlertas.succeeded)
                        {
                            var alertas = resultAlertas.data.items;

                            if (alertas.Count > 0)
                            {
                                listAlertas.Attributes["class"] += " scroll";

                                RepeaterAlertas.DataSource = CreateDataSource.CreateDataSourceAlertas(alertas);
                                RepeaterAlertas.DataBind();
                            }
                            else
                            {
                                // Mostra uma mensagem de erro
                                errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                    EnumTypeError.warning,
                                    "Não foi possível encontrar nenhum alerta nesse dia.");
                            }
                        }
                        else
                        {
                            // Mostra uma mensagem de erro
                            errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                EnumTypeError.error,
                                resultAlertas.message);
                        }
                    }
                    else
                    {
                        // Carrega as outras páginas da list de alertas
                        UpdatePanelAlertsMorePages.Update();
                    }
                }
                catch (Exception)
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro ao carregar os alertas, tente novamente mais tarde.");
                }
            }
        }

        private void LoadAlertsMorePages()
        {
            if (IsPostBack)
            {
                try
                {
                    // Verifica se o usuário está autenticado
                    var cookie = Request.Cookies["token"];

                    if (cookie == null)
                        Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });

                    var dateTime = GetDate();

                    if (PageNumberAlertas > 1)
                    {
                        // Repeater Source
                        var resultTask = Task.Run(() => GetAlertasWithPagination(
                            dateTime.Year.ToString(),
                            dateTime.Month.ToString(),
                            dateTime.Day.ToString(),
                            PageNumberAlertas,
                            PAGE_SIZE_ALERTS,
                            cookie.Values[0]));
                        resultTask.Wait();

                        var result = resultTask.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            foreach (var element in lastReapeater)
                            {
                                repeatersMorePages.Controls.Add(element);
                            }

                            if (result.data.totalPages >= PageNumberAlertas)
                            {
                                var repeaterMorePages = new Repeater()
                                {
                                    ID = $"RepeaterAlertas_Page{ PageNumberAlertas }",
                                    ItemTemplate = RepeaterAlertas.ItemTemplate
                                };

                                repeatersMorePages.Controls.Add(repeaterMorePages);

                                lastReapeater.Add(repeaterMorePages);

                                repeaterMorePages.DataSource = CreateDataSource.CreateDataSourceAlertas(result.data.items);
                                repeaterMorePages.DataBind();
                            }
                            else
                            {
                                morePagesInformation.InnerHtml = "<p>Chegou no final da consulta!</p>";

                                Thread.Sleep(2000);
                            }
                        } else
                        {
                            // Mostra uma mensagem de erro
                            errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                EnumTypeError.error,
                                result.message);
                        }
                    }
                }
                catch (Exception)
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro ao carregar os alertas, tente novamente mais tarde.");
                }
            }
        }

        #endregion

        #region CurrentWeather

        // GET: api/v1/CurrentWeather/coord
        private async Task<Response<CurrentWeather>> GetCurrentWeatherByCoord(
           string lat, string lon, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/CurrentWeather/coord")
                .SetQueryParams(new
                {
                    lat,
                    lon
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<CurrentWeather>>(stringResult);

            return jsonResult;
        }

        // GET: api/v1/CurrentWeather/name
        private async Task<Response<CurrentWeather>> GetCurrentWeatherByName(
           string district,string city, string state, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/CurrentWeather/name")
                .SetQueryParams(new
                {
                    district,
                    city,
                    state
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<CurrentWeather>>(stringResult);

            return jsonResult;
        }

        // Events
        protected void UpdatePanelForecast_Load(object sender, EventArgs e)
        {
            LoadForecast();
        }

        // Loads
        private void LoadForecast()
        {
            if (IsPostBack)
            {
                try { 
                    // Verifica se o usuário está autenticado
                    var cookie = Request.Cookies["token"];

                    if (cookie == null)
                        Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });

                    var (district, city, state) = GetLocale(txtSearch.Text);
                    Response<CurrentWeather> resultCurrentWeather = null;

                    if (district.IsEmpty())
                    {
                        var (lat, lon) = GetCoordinates();

                        var resultTask = Task.Run(() => GetCurrentWeatherByCoord(
                            lat,
                            lon,
                            cookie.Values[0]));
                        resultTask.Wait();

                        resultCurrentWeather = resultTask.GetAwaiter().GetResult();
                    } else
                    {
                        var resultTask = Task.Run(() => GetCurrentWeatherByName(
                            district,
                            city,
                            state,
                            cookie.Values[0]));
                        resultTask.Wait();

                        resultCurrentWeather = resultTask.GetAwaiter().GetResult();
                    }

                    if (resultCurrentWeather.succeeded)
                    {
                        RepeaterForecast.DataSource = CreateDataSource.CreateDataSourceForecast(resultCurrentWeather.data);

                        RepeaterForecast.DataBind();
                    }
                    else
                    {
                        // Mostra uma mensagem de erro
                        errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.warning,
                            resultCurrentWeather.message);
                    }
                }
                catch (Exception)
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro ao carregar as condições atuais, tente novamente mais tarde.");
                }
            }
        }

        #endregion

        #region Chart

        // GET: api/v1/Forecast/name
        private async Task<Response<Forecast>> GetForecastByName(
           string district, string city, string state, string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Forecast/name")
                .SetQueryParams(new
                {
                    district,
                    city,
                    state
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jsonResult = JsonSerializer.Deserialize<Response<Forecast>>(stringResult, options);

            return jsonResult;
        }

        // GET: api/v1/Forecast/coord
        private async Task<Response<Forecast>> GetForecastByCoord(
          string lat, string lon,  string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Forecast/coord")
                .SetQueryParams(new
                {
                    lat,
                    lon
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var jsonResult = JsonSerializer.Deserialize<Response<Forecast>>(stringResult, options);

            return jsonResult;
        }

        // Events
        protected void UpdatePanelChart_Load(object sender, EventArgs e)
        {
            LoadGraphic();
        }

        // Loads
        private void LoadGraphic()
        {
            if (IsPostBack)
            {
                try
                {
                    // Verifica se o usuário está autenticado
                    var cookie = Request.Cookies["token"];

                    if (cookie == null)
                        Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });

                    Response<Forecast> resultForecast = null;

                    var (district, city, state) = GetLocale(txtSearch.Text);

                    if (district.IsEmpty())
                    {
                        var (lat, lon) = GetCoordinates();

                        var resultTask = Task.Run(() => GetForecastByCoord(
                            lat,
                            lon,
                            cookie.Values[0]));
                        resultTask.Wait();

                        resultForecast = resultTask.GetAwaiter().GetResult();
                    } else
                    {
                        var resultTask = Task.Run(() => GetForecastByName(
                            district,
                            city,
                            state,
                            cookie.Values[0]));
                        resultTask.Wait();

                        resultForecast = resultTask.GetAwaiter().GetResult();
                    }

                    if (resultForecast.succeeded)
                    {
                        var valuesTemperatura = new ArrayList();

                        if (Page.RouteData.Values["interval"].ToString() == "Dia")
                        {
                            foreach (var daily in resultForecast.data.Daily)
                            {
                                // Unix timestamp is seconds past epoch
                                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                                dateTime = dateTime.AddSeconds(daily.Dt).ToLocalTime();

                                valuesTemperatura.Add(
                                    new PositionDataTemperatura(dateTime.ToString("s", CultureInfo.CreateSpecificCulture("en-US")), daily.Feels_like.Day));
                            }
                        }
                        else
                        {
                            foreach (var hourly in resultForecast.data.Hourly)
                            {
                                // Unix timestamp is seconds past epoch
                                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                                dateTime = dateTime.AddSeconds(hourly.Dt).ToLocalTime();

                                valuesTemperatura.Add(
                                    new PositionDataTemperatura(dateTime.ToString("s", CultureInfo.CreateSpecificCulture("en-US")), hourly.Temp));
                            }
                        }

                        string jsonStringTemperatura = JsonSerializer.Serialize(valuesTemperatura);

                        HiddenFieldGraphicTemperatura.Value = jsonStringTemperatura;
                    }
                    else
                    {
                        // Mostra uma mensagem de erro
                        errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                            EnumTypeError.error,
                            resultForecast.message);
                    }
                }
                catch (Exception)
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro ao carregar o gráfico, tente novamente mais tarde.");
                }
            }
        }

        #endregion
    }
}