using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WebEstadisticaNUC : System.Web.UI.Page
    {

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            //ReportViewer1.DataBind();
            }
           
        }

        protected void CmdFiltrar_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Se Realizo Una Busqueda de Carpetas Iniciadas NUC " + "con Fecha de Incio Del: " + TxtFecha1.Text + " Al: " + TxtFecha2.Text + " En:" + UNDD.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            ReportViewer1.LocalReport.Refresh();
        }

    }
}