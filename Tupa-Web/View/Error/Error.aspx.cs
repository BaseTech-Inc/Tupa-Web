using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tupa_Web.View.Error
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var codStatus = Page.RouteData.Values["codStatus"];
            var codTitle = "";
            var codDescription = "";

            if (codStatus != null)
            {
                switch (codStatus.ToString())
                {
                    case "401":
                    case "403":
                        codDescription = "Acho que você tentou acessar uma página que você não tem permissão, dessa vez vou deixar passar, mas toma cuidado. 😎";
                        codTitle = "OPS!! SEM AUTORIZAÇÃO, BRO!!";

                        break;
                    case "404":
                    case "405":
                        codDescription = "Acho que você escolheu a página errada, porque eu não consegui dar uma olhada na que você está procurando.";
                        codTitle = "OPS!! PAGE NOT FOUND, BRO!!";

                        break;
                    case "500":
                    case "501":
                    case "502":
                    case "503":
                    case "504":
                        codDescription = "Desculpe, mas parece que aconteceu um erro ao executar a função, tente novamente mais tarde. 😥";
                        codTitle = "OPS!! SERVER ERROR, BRO!!";

                        break;
                    default:
                        codDescription = "Acho que você escolheu a página errada, porque eu não consegui dar uma olhada na que você está procurando.";
                        codTitle = "OPS!! PAGE NOT FOUND, BRO!!";

                        break;
                }
            } else
            {
                codDescription = "Acho que você escolheu a página errada, porque eu não consegui dar uma olhada na que você está procurando.";
                codTitle = "OPS!! PAGE NOT FOUND, BRO!!";
            }

            titleError.InnerText = codTitle.ToString();
            descriptionError.InnerText = codDescription.ToString();
        }
    }
}