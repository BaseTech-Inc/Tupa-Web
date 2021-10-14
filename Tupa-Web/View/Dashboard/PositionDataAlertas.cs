using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.View.Dashboard
{
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
}