using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WEstadistica : System.Web.UI.Page
    {
        private const string SCRIPT_DOFOCUS =
@"window.setTimeout('DoFocus()', 1);
                function DoFocus()
                {
                    try {
                        document.getElementById('REQUEST_LASTFOCUS').focus();
                    } catch (ex) {}
                }";

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
            }
        }

        protected void CmdEstadisticaEstados_Click(object sender, EventArgs e)
        {

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en el boton denuncias por estado", int.Parse(Session["IdModuloBitacora"].ToString()));
            Response.Redirect("WReporte2.aspx");
        }

        protected void CmdListadoPersona_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en el boton listado de personas", int.Parse(Session["IdModuloBitacora"].ToString()));
            Response.Redirect("WReporte7.aspx");
        }

        protected void CmdConteoPersona_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en el boton conteo de personas", int.Parse(Session["IdModuloBitacora"].ToString()));
            Response.Redirect("WReporte1.aspx");
        }

        protected void CmdAAnterior_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en el boton denuncias de años anteriores", int.Parse(Session["IdModuloBitacora"].ToString()));
            Response.Redirect("WReporte3.aspx");
        }

        protected void cmdMunicipioHecho_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en el boton por municipio de hechos", int.Parse(Session["IdModuloBitacora"].ToString()));
            Response.Redirect("WReporte4.aspx");
        }

        protected void CmdPorDelito_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en el boton denuncias por delito", int.Parse(Session["IdModuloBitacora"].ToString()));
            Response.Redirect("WReporte5.aspx");
        }


    }
}