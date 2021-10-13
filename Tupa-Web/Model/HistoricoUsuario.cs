using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Model
{
    public class HistoricoUsuario
    {
        public string id { get; set; }

        public Usuario usuario { get; set; }

        public Distrito distrito { get; set; }

        public DateTime tempoChegada { get; set; }

        public DateTime tempoPartida { get; set; }

        public double distanciaPercurso { get; set; }

        public string rota { get; set; }
    }
}