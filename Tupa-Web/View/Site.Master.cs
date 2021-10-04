using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tupa_Web.View
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Page.Title) || Page.Title == "Untitled Page")
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath);

                Page.Title = fileName;
            }

            Page.DataBind();
        }

        public static bool IsLogged()
        {
            var cookie = HttpContext.Current.Request.Cookies["token"];

            if (cookie == null)
            {
                return false;
            }

            return true;
        }

        public static bool ContainsHeader()
        {
            Page page = HttpContext.Current.Handler as Page;

            if (page != null)
            {
                if (page.MetaKeywords != null)
                {
                    var keywords = page.MetaKeywords.Split(',');

                    foreach (var keyword in keywords)
                    {
                        if (keyword.Trim() == "NoHeader")
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool ContainsFooter()
        {
            Page page = HttpContext.Current.Handler as Page;

            if (page != null)
            {
                if (page.MetaKeywords != null)
                {
                    var keywords = page.MetaKeywords.Split(',');

                    foreach (var keyword in keywords)
                    {
                        if (keyword.Trim() == "NoFooter")
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}