using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Tupa_Web.Model;

namespace Tupa_Web.View.Dashboard
{
    public static class CreateDataSource
    {
        public static ICollection CreateDataSourceAlertas(IList<Alertas> listAlertas)
        {
            var values = new ArrayList();

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

        public static ICollection CreateDataSourceForecast(CurrentWeather forecast)
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
            }
            else if (forecast.weather.icon.Contains("n"))
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
    }
}