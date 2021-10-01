using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tupa_Web.View.Configuracoes
{
    public partial class Configuacoes : System.Web.UI.MasterPage
    {
        private string userName;
        public string UserName { 
            get 
            { 
                return userName; 
            } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}