using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Models;
using Tupa_Web.Model;

namespace Tupa_Web.View.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

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

        ICollection CreateDataSource(IList<Alertas> listAlertas)
        {
            ArrayList values = new ArrayList();

            foreach (var alertas in listAlertas)
            {
                values.Add(
                new PositionData(
                    alertas.distrito.nome,
                    "12°C",
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

        public class PositionData
        {
            private string locale;
            private string temperature;
            private string description;
            private string time;

            public PositionData(
                string locale,
                string temperature,
                string description,
                string time)
            {
                this.locale = locale;
                this.temperature = temperature;
                this.description = description;
                this.time = time;
            }

            public string Locale => locale;

            public string Temperature => temperature;

            public string Description => description;

            public string Time => time;
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var cookie = Request.Cookies["token"];

                if (cookie != null)
                {
                    // Repeater Source

                    var resultTask = Task.Run(() => GetAlertas("2021", "01", "01", cookie.Values[0]));
                    resultTask.Wait();

                    var result = resultTask.GetAwaiter().GetResult();

                    if (result.succeeded)
                    {
                        RepeaterAlertas.DataSource = CreateDataSource(result.data);

                        SkeletonLoadingPanel.Visible = false;

                        RepeaterAlertas.DataBind();
                    }
                }
            }            
        }
    }
}