using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }
    }
}