using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WebEstadistica : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["op"] = Request.QueryString["op"];
            cargarFecha();
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
        }

        protected void CmdEstadisticaIniciadas_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebEstadisticaIniciadas.aspx");
        }

        protected void CmdEstadisticaEstados_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebEstadisticaEstados.aspx");
        }

        protected void CmdMapaDelincuencial_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebMapaDelincuencial.aspx");
        }

        protected void CmdEstadisticaDelitos_Click(object sender, EventArgs e)
        {
            LblMensaje.Visible = true;
        }

        void cargarFecha()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var fecha = from c in dc.fechaServidor()
                        select c;
            foreach (var propiedad in fecha)
            {
                lblFecha.Text = propiedad.FechaActual.ToString();
            }

        }

        protected void CmdCulposos_Click(object sender, EventArgs e)
        {
            Response.Redirect("rpDenunciasModalidad.aspx");
        }

        protected void cmdViolencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("rpDenunciasViolencia.aspx");
        }
    }
}