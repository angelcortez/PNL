using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class rpDenunciasViolencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
               

                cargarFecha();

            }
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

        protected void cmdGenerar_Click(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}