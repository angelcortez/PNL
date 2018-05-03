using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization;
using System.Web.UI.Adapters;
using System.Text;

namespace AtencionTemprana
{
    public partial class Loguin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clicEnter(object sender, EventArgs e)
        {
            string user = usuarioLog.Text;
            string pass = passLog.Text;

            if ((user == "PNL") && (pass == "PNL"))
            {
                Response.Redirect("PNLUnidades.aspx");
            }
            else
            {
                msjError.Text = "Usuario y/o Contraseña Incorrecto";
            }
            
            
            }
        }
    }
