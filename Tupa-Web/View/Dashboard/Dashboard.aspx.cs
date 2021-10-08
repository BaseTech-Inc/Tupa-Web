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
using System.Web.UI.WebControls;
using System.Web.WebPages;
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
            var cookie = Request.Cookies["token"];

            if (cookie == null)
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });

            UpdateProgressForecast.AssociatedUpdatePanelID = UpdatePanel1.UniqueID;
            UpdateProgressAlertas.AssociatedUpdatePanelID = UpdatePanel1.UniqueID;

            // Post Back usando um evento Javascript
            ClientScript.GetPostBackEventReference(this, string.Empty);

            string targetCtrl = Page.Request.Params.Get("__EVENTTARGET");
            string parameter = Page.Request.Params.Get("__EVENTARGUMENT");

            if (targetCtrl != null && targetCtrl != string.Empty)
            {
                if (IsPostBack)
                { }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            UpdatePanelForecast.Update();
            UpdatePanelAlertas.Update();

            UpdateProgressForecast.AssociatedUpdatePanelID = UpdatePanelForecast.UniqueID;
            UpdateProgressAlertas.AssociatedUpdatePanelID = UpdatePanelAlertas.UniqueID;
        }

        #region Alertas

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

                        var searchDate = txtSearchDate.Text;

                        if (!searchDate.IsEmpty())
                        {
                            var date = searchDate.Split('-');
                            dateTime = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
                        } else
                        {
                            dateTime = DateTime.Now;
                        }

                        // Repeater Source
                        var resultTask = Task.Run(() => GetAlertas(
                            dateTime.Year.ToString(),
                            dateTime.Month.ToString(),
                            dateTime.Day.ToString(),
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

        #region Forecast

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

        private ICollection CreateDataSourceForecast(Forecast forecast)
        {
            ArrayList values = new ArrayList();

            values.Add(
            new PositionDataForecast(
                forecast.q,
                Math.Round(forecast.main.temp, 1).ToString() + "°",
                forecast.weather.description));

            return values;
        }

        private class PositionDataForecast
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
                        }
                        else
                        {
                            // Mostra uma mensagem de erro
                            errorMessage.InnerHtml += ErrorMessageHelpers.ErrorMessage(
                                EnumTypeError.warning,
                                result.message);
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

        private static IList<Distrito> listDistritos = new List<Distrito>();

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
                        { }
                    }

                    if (!txtSearch.Text.IsEmpty())
                    {
                        var txtSearchDistrict = txtSearch.Text.ToString();

                        var listAutoComplete = listDistritos
                            .Where(x => x.nome.Contains(txtSearchDistrict) || x.nome.StartsWith(txtSearchDistrict) || x.nome.EndsWith(txtSearchDistrict))
                                .OrderBy(i => i.nome)
                                    .Take(5)
                                        .ToList();

                        AutoCompleteList.Visible = true;
                        SearchBar.CssClass += " autoCompleteActived";

                        RepeaterAutoComplete.DataSource = CreateDataSourceDistritos(listAutoComplete);

                        RepeaterAutoComplete.DataBind();
                    }
                }
                catch (Exception)
                { }
            }
        }

        private ICollection CreateDataSourceDistritos(IList<Distrito> distritos)
        {
            ArrayList values = new ArrayList();

            foreach (var distrito in distritos)
            {
                values.Add(
                    new PositionDataDistritos(
                        distrito.nome));
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

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdatePanelSearch.Update();
        }

        protected void UpdatePanelSearch_Load(object sender, EventArgs e)
        {
            LoadDistritos();
        }

        #endregion
    }
}