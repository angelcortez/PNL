using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class CoordPoliciaInvestigador_Ordenes : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();

                Session["ID_ORDEN"] = Request.QueryString["ID_ORDEN"];
                Session["ID_UNIDAD"] = Request.QueryString["ID_UNIDAD"];

                PGJ.CargaCombo(ddlTipoOrden, "CAT_TIPO_ORDEN", "IdTipoOrden", "TipoOrden");


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

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvNuc.DataSourceID = "dsConsultaOrden";
                gvNuc.DataBind();
                gvNuc.Visible = true;

                

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                cmdAceptar.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
               

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                cmdAceptar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
               

                lblTipo.Visible = true;
                ddlTipoOrden.Visible = true;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                cmdAceptar.Visible = true;
            }

            if (ddlBuscar.SelectedValue == "3")
            {
                
                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = true;
                txtFechaInicioOrden.Visible = true;
                lblFechaFinOrden.Visible = true;
                txtFechaFinOrden.Visible = true;

                cmdAceptar.Visible = true;
            }
        }


        protected void gvNuc_RowDataBound(object sender, GridViewRowEventArgs e)
        {




        }


        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvNuc.DataSourceID = "dsBusNuc";
                gvNuc.DataBind();

                btnMostrar.Visible = true;

            }
            if (ddlBuscar.SelectedValue == "2")
            {
                gvNuc.DataSourceID = "dsBuscarTipoOrdenPI";
                gvNuc.DataBind();

                btnMostrar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                gvNuc.DataSourceID = "dsBuscarFechaInicioOrdenPI";
                gvNuc.DataBind();

                btnMostrar.Visible = true;
            }

        }

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CoordPoliciaInvestigador.aspx");
        }


        protected void btnEnviada_Click(object sender, EventArgs e)
        {

            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Enviada";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;

        }

        protected void btnAsignada_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Asignada";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnProceso_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Proceso";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnCumplida_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Cumplida";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnConcluida_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Concluida";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsConsultaOrden";
            gvNuc.DataBind();

            lblBuscar.Visible = true;
            ddlBuscar.Visible = true;
            btnMostrar.Visible = false;

        }
    }
}