using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tupa_Web.Common.Enumerations;

namespace Tupa_Web.Common.Helpers
{
    public class ErrorMessageHelpers
    {
        public static string ErrorMessage(EnumTypeError typeError, string text)
        {
            return String.Format(
                @"<div class=""error-message {0}"" runat=""server"" id=""errorMessage"">
                    <div class=""error_wrapper"">
                        <p runat = ""server"" id=""textErrorMessage"" title=""{1}"">{1}</p>
                        <span class=""close_button"">
                            <span class=""material-icons"">
                            close
                            </span>
                        </span>
                    </div>
                </div>", 
                typeError.ToString(),
                text);
        }
    }
}