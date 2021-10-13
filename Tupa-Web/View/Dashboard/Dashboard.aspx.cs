﻿using System;
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
    public partial class Dashboard : System.Web.UI.Page
    {
        private static string searchLocate { get; set; }

        private static string searchDate { get; set; } = String.Format("{0}", DateTime.Now.ToString("yyyy-MM-dd"));

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
                searchLocate = "";

                if (!searchDate.IsEmpty())
                    txtSearchDate.Text = searchDate;
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

        #region Alertas

        private static int PageNumberAlertas { get; set; } = 1;

        private static IList<Repeater> lastReapeater = new List<Repeater>();

        private async Task<Response<PaginatedList<Alertas>>> GetAlertasWithPagination(
            string year,
            string month,
            string day,
            int PageNumber,
            int PageSize,
            string bearerToken)
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

        private async Task<Response<IList<Alertas>>> GetAlertasByName(
           string year,
           string month,
           string day,
           string district,
           string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Alertas/Bairro")
                .SetQueryParams(new
                {
                    year,
                    month,
                    day,
                    district
                });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<IList<Alertas>>>(stringResult);

            return jsonResult;
        }

        private ICollection CreateDataSourceAlertas(IList<Alertas> listAlertas)
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

        private class PositionDataAlertas
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

        private void LoadAlertas()
        {
            if (IsPostBack)
            {
                try
                {
                    var cookie = Request.Cookies["token"];

                    if (cookie != null)
                    {
                        DateTime dateTime;

                        searchDate = txtSearchDate.Text;

                        if (!searchDate.IsEmpty())
                        {
                            var date = searchDate.Split('-');
                            dateTime = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                        } else
                        {
                            dateTime = DateTime.Now;
                        }

                        if (searchLocate.IsEmpty())
                        {
                            if (PageNumberAlertas == 1)
                            {
                                // Repeater Source
                                var resultTask = Task.Run(() => GetAlertasWithPagination(
                                    dateTime.Year.ToString(),
                                    dateTime.Month.ToString(),
                                    dateTime.Day.ToString(),
                                    PageNumberAlertas,
                                    6,
                                    cookie.Values[0]));
                                resultTask.Wait();

                                var result = resultTask.GetAwaiter().GetResult();

                                if (result.succeeded)
                                {
                                    if (result.data.items.Count > 0)
                                    {

                                        listAlertas.Attributes["class"] += " scroll";

                                        RepeaterAlertas.DataSource = CreateDataSourceAlertas(result.data.items);
                                        RepeaterAlertas.DataBind();
                                    }
                                    else
                                    {
                                        // Mostra uma mensagem de erro
                                        errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                            EnumTypeError.warning,
                                            "Não foi possível encontrar nenhum alerta nesse dia.");
                                    }
                                } else
                                {
                                    // Mostra uma mensagem de erro
                                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                        EnumTypeError.error,
                                        "Ocorreu um erro, tente novamente mais tarde.");
                                }
                            }
                            else
                            {
                                UpdatePanelAlertsMorePages.Update();
                            }
                        } else
                        {
                            // Repeater Source
                            var resultTask = Task.Run(() => GetAlertasByName(
                                dateTime.Year.ToString(),
                                dateTime.Month.ToString(),
                                dateTime.Day.ToString(),
                                searchLocate.Split(',')[0].Trim(),
                                cookie.Values[0]));
                            resultTask.Wait();

                            var result = resultTask.GetAwaiter().GetResult();

                            if (result.succeeded)
                            {
                                if (result.data.Count > 0)
                                {
                                    listAlertas.Attributes["class"] += " scroll";

                                    RepeaterAlertas.DataSource = CreateDataSourceAlertas(result.data);
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
                                    "Ocorreu um erro, tente novamente mais tarde.");
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/");
                    }
                }
                catch
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro, tente novamente mais tarde.");
                }
            }
        }

        protected void UpdatePanelAlertsMorePages_Load(object sender, EventArgs e)
        {
            LoadAlertsMorePages();
        }

        private void LoadAlertsMorePages()
        {
            if (IsPostBack)
            {
                try
                {
                    var cookie = Request.Cookies["token"];

                    if (cookie != null)
                    {
                        DateTime dateTime;

                        var searchDate = txtSearchDate.Text;

                        if (!searchDate.IsEmpty())
                        {
                            var date = searchDate.Split('-');
                            dateTime = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                        }
                        else
                        {
                            dateTime = DateTime.Now;
                        }

                        if (PageNumberAlertas > 1)
                        {
                            // Repeater Source
                            var resultTask = Task.Run(() => GetAlertasWithPagination(
                                dateTime.Year.ToString(),
                                dateTime.Month.ToString(),
                                dateTime.Day.ToString(),
                                PageNumberAlertas,
                                6,
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

                                    repeaterMorePages.DataSource = CreateDataSourceAlertas(result.data.items);
                                    repeaterMorePages.DataBind();
                                }
                                else
                                {
                                    morePagesInformation.InnerText = "Chegou no final da consulta!";

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
                    else
                    {
                        Response.Redirect("~/");
                    }
                }
                catch (Exception)
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro, tente novamente mais tarde.");
                }
            }
        }

        #endregion

        #region CurrentWeather

        private async Task<Response<CurrentWeather>> GetCurrentWeatherByCoord(
           string lat,
           string lon,
           string bearerToken
           )
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

        private async Task<Response<CurrentWeather>> GetCurrentWeatherByName(
           string district,
           string city,
           string state,
           string bearerToken
           )
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

        private ICollection CreateDataSourceForecast(CurrentWeather forecast)
        {
            ArrayList values = new ArrayList();

            string url = "~/Content/Images/";

            string getImageName(string iconNumber)
            {
                switch (iconNumber)
                {
                    case "01": return "clear_sky";
                    case "02": return "few_clouds";
                    case "03":
                    case "04":
                        return "scattered_clouds";
                    case "09":
                    case "10":
                        return "rain";
                    case "11": return "thunderstorm";
                    case "13": return "snow";
                    default: return "clear_sky";
                }
            }

            if (forecast.weather.icon.Contains("d"))
            {
                var name = getImageName(forecast.weather.icon.Split('d')[0]);

                url += name + "_day.png";
            } else if (forecast.weather.icon.Contains("n"))
            {
                var name = getImageName(forecast.weather.icon.Split('n')[0]);

                url += name + "_night.png";
            }

            values.Add(
                new PositionDataForecast(
                    forecast.q,
                    Math.Round(forecast.main.temp, 1).ToString() + "°",
                    forecast.weather.description,
                    url));

            return values;
        }

        private class PositionDataForecast
        {
            private string locale;
            private string temperature;
            private string condition;
            private string urlImage;

            public PositionDataForecast(
                string locale,
                string temperature,
                string condition,
                string urlImage)
            {
                this.locale = locale;
                this.temperature = temperature;
                this.condition = condition;
                this.urlImage = urlImage;
            }

            public string Locale => locale;

            public string Temperature => temperature;

            public string Condition => condition;

            public string UrlImage => urlImage;
        }

        protected void UpdatePanelForecast_Load(object sender, EventArgs e)
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
                        if (searchLocate.IsEmpty())
                        {
                            string lat = queryStringLat.Value;
                            string lon = queryStringLon.Value;

                            var resultTask = Task.Run(() => GetCurrentWeatherByCoord(
                                lat,
                                lon,
                                cookie.Values[0]));
                            resultTask.Wait();

                            var result = resultTask.GetAwaiter().GetResult();

                            if (result.succeeded)
                            {
                                RepeaterForecast.DataSource = CreateDataSourceForecast(result.data);

                                RepeaterForecast.DataBind();
                            }
                            else
                            {
                                // Mostra uma mensagem de erro
                                errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                    EnumTypeError.warning,
                                    result.message);
                            }
                        } else
                        {
                            var district = searchLocate.Split(',')[0].Trim();
                            var city = searchLocate.Split(',')[1].Split('-')[0].Trim();
                            var state = searchLocate.Split(',')[1].Split('-')[1].Trim();

                            var resultTask = Task.Run(() => GetCurrentWeatherByName(
                                district,
                                city,
                                state,
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
                        }                                                
                    }
                    else
                    {
                        Response.Redirect("~/");
                    }
                }
                catch
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro, tente novamente mais tarde.");
                }
            }
        }

        #endregion

        #region Search

        private static IList<Distrito> listDistritos = new List<Distrito>();

        private async Task<Response<IList<Distrito>>> GetDistritos(
            string bearerToken)
        {
            // criando a url para comunicar entre o servidor
            string url = HttpRequestUrl.baseUrlTupa
                .AddPath("api/v1/Distritos")
                .SetQueryParams(new
                { });

            // resultado da comunicação
            var stringResult = await HttpRequestUrl.ProcessHttpClientGet(url, bearerToken: bearerToken);

            var jsonResult = JsonSerializer.Deserialize<Response<IList<Distrito>>>(stringResult);

            return jsonResult;
        }

        private ICollection CreateDataSourceDistritos(IList<Distrito> distritos)
        {
            ArrayList values = new ArrayList();

            foreach (var distrito in distritos)
            {
                values.Add(
                    new PositionDataDistritos(
                        distrito.nome + ", " + distrito.cidade.nome + " - " + distrito.cidade.estado.nome));
            }

            return values;
        }

        private class PositionDataDistritos
        {
            private string nome;

            public PositionDataDistritos(
                string nome)
            {
                this.nome = nome;
            }

            public string Nome => nome;
        }

        private void LoadDistritos()
        {
            if (IsPostBack)
            {
                try
                {
                    var cookie = Request.Cookies["token"];

                    if (listDistritos.Count <= 0)
                    {
                        var resultTask = Task.Run(() => GetDistritos(
                            cookie.Values[0]));
                        resultTask.Wait();

                        var result = resultTask.GetAwaiter().GetResult();

                        if (result.succeeded)
                        {
                            listDistritos = result.data;
                        }
                        else
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
                        "Ocorreu um erro, tente novamente mais tarde.");
                }
            }
        }


        #endregion

        #region Chart

        private async Task<Response<Forecast>> GetForecastByName(
           string district,
           string city,
           string state,
           string bearerToken)
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

        private async Task<Response<Forecast>> GetForecastByCoord(
          string lat,
          string lon,
          string bearerToken)
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

        private void LoadGraphic()
        {
            if (IsPostBack)
            {
                try
                {
                    var cookie = Request.Cookies["token"];

                    if (cookie != null)
                    {
                        if (searchLocate.IsEmpty())
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
                                var valuesTemperatura = new ArrayList();

                                if (Page.RouteData.Values["interval"].ToString() == "Dia")
                                {
                                    foreach (var daily in result.data.Daily)
                                    {
                                        // Unix timestamp is seconds past epoch
                                        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                                        dateTime = dateTime.AddSeconds(daily.Dt).ToLocalTime();

                                        valuesTemperatura.Add(
                                            new PositionDataTemperatura(dateTime.ToString("s", CultureInfo.CreateSpecificCulture("en-US")), daily.Feels_like.Day));
                                    }
                                } else
                                {
                                    foreach (var hourly in result.data.Hourly)
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
                                    EnumTypeError.warning,
                                    result.message);
                            }
                        } else
                        {
                            var district = searchLocate.Split(',')[0].Trim();
                            var city = searchLocate.Split(',')[1].Split('-')[0].Trim();
                            var state = searchLocate.Split(',')[1].Split('-')[1].Trim();

                            var resultTask = Task.Run(() => GetForecastByName(
                                district,
                                city,
                                state,
                                cookie.Values[0]));
                            resultTask.Wait();

                            var result = resultTask.GetAwaiter().GetResult();

                            if (result.succeeded)
                            {
                                var valuesTemperatura = new ArrayList();

                                foreach (var hourly in result.data.Hourly)
                                {
                                    // Unix timestamp is seconds past epoch
                                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                                    dateTime = dateTime.AddSeconds(hourly.Dt).ToLocalTime();

                                    valuesTemperatura.Add(
                                        new PositionDataTemperatura(dateTime.ToString("s", CultureInfo.CreateSpecificCulture("en-US")), hourly.Temp));
                                }

                                string jsonStringTemperatura = JsonSerializer.Serialize(valuesTemperatura);

                                HiddenFieldGraphicTemperatura.Value = jsonStringTemperatura;
                            }
                            else
                            {
                                // Mostra uma mensagem de erro
                                errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                    EnumTypeError.warning,
                                    result.message);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/");
                    }
                }
                catch
                {
                    // Mostra uma mensagem de erro
                    errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                        EnumTypeError.error,
                        "Ocorreu um erro, tente novamente mais tarde.");
                }
            }
        }

        protected void UpdatePanelChart_Load(object sender, EventArgs e)
        {
            LoadGraphic();
        }

        private class PositionDataTemperatura
        {
            private string x;
            private float y;

            public PositionDataTemperatura(
                string x,
                float y)
            {
                this.x = x;
                this.y = y;
            }

            public string X => x;

            public float Y => y;
        }

        private class PositionDataUmidade
        {
            private string x;
            private int y;

            public PositionDataUmidade(
                string x,
                int y)
            {
                this.x = x;
                this.y = y;
            }

            public string X => x;

            public int Y => y;
        }

        #endregion
    }
}