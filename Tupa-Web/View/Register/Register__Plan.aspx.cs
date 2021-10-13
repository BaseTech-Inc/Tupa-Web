using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tupa_Web.View.Register
{
    public partial class Register__Plan : System.Web.UI.Page
    {
        private string uid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
            {
                uid = Request.QueryString["uid"];

            } else
            {
                Response.RedirectToRoute("Error", new RouteValueDictionary { { "codStatus", "401" } });
            }                
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register/Verify?uid=" + uid);
        }

        public static string ColorTheme()
        {
            var cookie = HttpContext.Current.Request.Cookies["theme"];

            if (cookie == null)
            {
                return "";
            }

            if (cookie.Value != "white")
            {
                return "-alternative";
            }

            return "";
        }
    }
}