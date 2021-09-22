using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Model
{
    public class Cidade
    {
        public string id { get; set; }

        public Estado estado { get; set; }

        public string nome { get; set; }
    }
}