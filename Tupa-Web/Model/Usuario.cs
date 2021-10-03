using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Model
{
    public class Usuario
    {
        public string UserName { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string EmailConfirmed { get; set; }

        public string TipoUsuario { get; set; }

    }
}