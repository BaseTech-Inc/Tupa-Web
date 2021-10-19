using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Common.Helpers
{
    public class PopUpHelpers
    {
        public static string PopUp(string title, string[] descriptionBody, string button, string nameEventClick)
        {
            return String.Format(
                @"<div class=""popup_wrapper"" onclick=""OnOuterClick_ClosePopUp(this, event);"">
                    <div class=""popup card"">
                        <div class=""title"">
                            <h2>{0}</h2>

                            <span class=""close_button"" onclick=""OnClick_ClosePopUp(this);"">
                                <span class=""material-icons"">
                                close
                                </span>
                            </span>
                        </div>
                        <div class=""body"">
                            <p>{1}</p>
                            <input type=""button"" class=""primary-button"" value=""{2}"" onclick=""{3}(this)"" />
                        </div>
                    </div>
                </div>",
                title,
                descriptionBody[0],
                button,
                nameEventClick);
        }
    }
}