using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class AsignarDetenidoPI : System.Web.UI.Page
    {

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
                  
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                //IdOrden.Text = Session["ID_ORDEN"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                IdCarpeta.Text = Request.QueryString["ID_CARPETA"];
                LBLUSUARIO.Text = Session["Us"].ToString();

                cargarFecha();
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

        protected void cmdAsignar_Click(object sender, EventArgs e)
        {
            //Recorrer los Checbox de las filas del GridView
            foreach (GridViewRow row in gvAsignarPI.Rows)
            {
                CheckBox check = row.FindControl("ckboxPI") as CheckBox;
                if (check != null && check.Checked)
                {

                    PGJ.ActualizarIdCarpetaPersona(Convert.ToInt32(row.Cells[1].Text) , Convert.ToInt32(IdCarpeta.Text));
                    PGJ.ActualizarIdCarpetaDetencionPI(Convert.ToInt32(row.Cells[1].Text), Convert.ToInt32(IdCarpeta.Text));
                    PGJ.ActualizarIdCarpetaPDFDetencionPI(Convert.ToInt32(row.Cells[1].Text), Convert.ToInt32(IdCarpeta.Text));

                    Response.Redirect("NUC.aspx?ID_CARPETA=" + IdCarpeta.Text+"&ID_ESTADO_NUC=10");


                }
            }
        }
    }
}