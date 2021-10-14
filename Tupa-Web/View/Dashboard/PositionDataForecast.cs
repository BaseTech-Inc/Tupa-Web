using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.View.Dashboard
{
    public class PositionDataForecast
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
}