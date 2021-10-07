using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tupa_Web.View.Locais
{
    public partial class Locais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["token"];

            if (cookie == null)
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
        }
    }
}