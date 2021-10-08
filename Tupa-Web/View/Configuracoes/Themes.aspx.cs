using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Tupa_Web.Common.Enumerations;

namespace Tupa_Web.View.Configuracoes
{
    public partial class Themes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["theme"];
            var themeColor = "";

            if (!IsPostBack)
            {
                if (cookie != null)
                    themeColor = cookie.Value;
                else
                    themeColor = EnumColorTheme.white.ToString();

                if (themeColor == EnumColorTheme.white.ToString())
                    optWhite.Checked = true;

                if (themeColor == EnumColorTheme.dark.ToString())
                    optDark.Checked = true;

                if (themeColor == EnumColorTheme.dark_dimmed.ToString())
                    optDarkDimmed.Checked = true;
            }
        }

        protected void optWhite_CheckedChanged(Object sender, EventArgs e)
        {
            if (optWhite.Checked)
            {
                var previousPageMaster = Page.Master.Master;

                ((Site)previousPageMaster).BodyAttributes = EnumColorTheme.white.ToString();

                var cookie = Request.Cookies["theme"];

                if (cookie == null)
                {
                    cookie = new HttpCookie("theme", EnumColorTheme.white.ToString());
                    cookie.HttpOnly = true;
                    cookie.Expires = DateTime.MaxValue;

                    Response.Cookies.Add(cookie);
                } else
                {
                    cookie.Value = EnumColorTheme.white.ToString();

                    Response.Cookies.Add(cookie);
                }
            }
        }

        protected void optDark_CheckedChanged(Object sender, EventArgs e)
        {
            if (optDark.Checked)
            {
                var previousPageMaster = Page.Master.Master;

                ((Site)previousPageMaster).BodyAttributes = EnumColorTheme.dark.ToString();

                var cookie = Request.Cookies["theme"];

                if (cookie == null)
                {
                    cookie = new HttpCookie("theme", EnumColorTheme.dark.ToString());
                    cookie.HttpOnly = true;
                    cookie.Expires = DateTime.MaxValue;

                    Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Value = EnumColorTheme.dark.ToString();

                    Response.Cookies.Add(cookie);
                }
            }
        }

        protected void optDarkDimmed_CheckedChanged(Object sender, EventArgs e)
        {
            if (optDarkDimmed.Checked)
            {
                var previousPageMaster = Page.Master.Master;

                ((Site)previousPageMaster).BodyAttributes = EnumColorTheme.dark_dimmed.ToString();

                var cookie = Request.Cookies["theme"];

                if (cookie == null)
                {
                    cookie = new HttpCookie("theme", EnumColorTheme.dark_dimmed.ToString());
                    cookie.HttpOnly = true;
                    cookie.Expires = DateTime.MaxValue;

                    Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Value = EnumColorTheme.dark_dimmed.ToString();

                    Response.Cookies.Add(cookie);
                }
            }
        }
    }
}