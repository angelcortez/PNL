using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class RazonAviso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarFecha();
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
            }
        }

        protected void cmdRazonConDet_Click(object sender, EventArgs e)
        {
            //Data.IdCarpetaInicio = 3;
            //Data.IdConDetenido = 1;
           // Data.IdCarpeta = 0;
            Response.Redirect("RazonAvisoConDetenido.aspx?" + "&op=Agregar");
        }

        protected void cmdRazonSinDet_Click(object sender, EventArgs e)
        {
            //Data.IdCarpetaInicio = 4;
            //Data.IdConDetenido = 0;
          //  Data.IdCarpeta = 0;
            Response.Redirect("RazonAvisoSinDetenido.aspx?" + "&op=Agregar");
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

    }
}