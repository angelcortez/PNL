using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class CoordPoliciaInvestigador_Estadistica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();

                //IDtIPOuNIDAD.Text = Session["ID_UNDD_TPO"].ToString();

                Session["ID_UNIDAD"] = Request.QueryString["ID_UNIDAD"];

            }

        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                EstadisticaPI.DataSourceID = "dsCargaTrabajo";
                EstadisticaPI.DataBind();
                EstadisticaPI.Visible = true;

                

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                

                cmdAceptar.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {


                lblFechaInicioOrden.Visible = true;
                txtFechaInicioOrden.Visible = true;
                lblFechaFinOrden.Visible = true;
                txtFechaFinOrden.Visible = true;

               

                cmdAceptar.Visible = true;
            }
           
        }

        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                EstadisticaPI.DataSourceID = "dsBusquedaCargaTrabajo";
                EstadisticaPI.DataBind();

                chIniciada.DataSourceID = "dsBusquedaCargaTrabajo";
                chIniciada.DataBind();

            }
        }

        public void EstadisticaPI_RowDataBound(object sender, GridViewRowEventArgs e)
        { 
        
        }

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CoordPoliciaInvestigador.aspx");
        }

        protected void ImageMisOrdenes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CoordPoliciaInvestigador_MisOrdenes.aspx");
        }

        protected void Image3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CoordPoliciaInvestigador_Estadistica.aspx");
        }


    }
}