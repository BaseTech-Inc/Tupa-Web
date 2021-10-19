using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Common.Helpers
{
    public class PopUpHelpers
    {
        public static string PopUp(string title, string[] descriptionBody, string button)
        {
            return String.Format(
                @"<div class=""popup_wrapper"" onclick=""OnClickPopUp(this, event);"">
                    <div class=""popup card"">
                        <div class=""title"">
                            <h2>{0}</h2>

                            <div class=""close_button""></div>
                        </div>
                        <div class=""body"">
                            <p>{1}</p>
                            <input type=""text""/>
                            <button>{3}</button>
                        </div>
                    </div>
                </div>",
                title,
                descriptionBody[0],
                button);
        }
    }
}