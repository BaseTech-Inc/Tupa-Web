using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Model
{
    public class Alertas
    {
        public string id { get; set; }

        public Ponto ponto { get; set; }

        public Distrito distrito { get; set; }

        public DateTime tempoInicio { get; set; }

        public DateTime tempoFinal { get; set; }

        public string descricao { get; set; }

        public bool transitividade { get; set; }

        public bool atividade { get; set; }

    }
}