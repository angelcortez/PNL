using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Ordenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarFecha();
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
            }
        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            gvOrden.DataSourceID = "dsBuscarApllido";
            gvOrden.DataBind();
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

        protected void gvOrden_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[10].Text == "APREHENSION")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[10].Text == "COMPARECENCIA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                if (e.Row.Cells[10].Text == "REAPREHENSION")
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
               
            }
        }
    }
}