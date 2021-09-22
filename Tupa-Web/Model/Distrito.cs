using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Model
{
    public class Distrito
    {
        public string id { get; set; }

        public Cidade cidade { get; set; }

        public string nome { get; set; }
    }
}