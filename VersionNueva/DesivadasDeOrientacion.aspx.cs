using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class DesivadasDeOrientacion : System.Web.UI.Page
    {
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

        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvNuc.DataSourceID = "dsBuscarRac";
                gvNuc.DataBind();
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                gvNuc.DataSourceID = "dsBuscarFechaInicioRac";
                gvNuc.DataBind();
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                gvNuc.DataSourceID = "dsBuscarDenunciante";
                gvNuc.DataBind();
            }
            if (ddlBuscar.SelectedValue == "4")
            {
                gvNuc.DataSourceID = "dsBuscarImputado";
                gvNuc.DataBind();
            }
        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvNuc.DataSourceID = "dsConsultaNUC";
                gvNuc.DataBind();
                gvNuc.Visible = true;

                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreIm.Visible = false;
                txtNombreIm.Visible = false;
                lblPaternoIm.Visible = false;
                txtPaternoIm.Visible = false;
                lblMaternoIm.Visible = false;
                txtMaternoIm.Visible = false;
                cmdAceptar.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                lblRac.Visible = true;
                txtRac.Visible = true;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreIm.Visible = false;
                txtNombreIm.Visible = false;
                lblPaternoIm.Visible = false;
                txtPaternoIm.Visible = false;
                lblMaternoIm.Visible = false;
                txtMaternoIm.Visible = false;
                cmdAceptar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = true;
                txtFechaInicioRac.Visible = true;
                lblFechaFinRac.Visible = true;
                txtFechaFinRac.Visible = true;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreIm.Visible = false;
                txtNombreIm.Visible = false;
                lblPaternoIm.Visible = false;
                txtPaternoIm.Visible = false;
                lblMaternoIm.Visible = false;
                txtMaternoIm.Visible = false;
                cmdAceptar.Visible = true;
            }

            if (ddlBuscar.SelectedValue == "3")
            {
                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNombre.Visible = true;
                txtNombre.Visible = true;
                lblPaterno.Visible = true;
                txtPaterno.Visible = true;
                lblMaterno.Visible = true;
                txtMaterno.Visible = true;
                lblNombreIm.Visible = false;
                txtNombreIm.Visible = false;
                lblPaternoIm.Visible = false;
                txtPaternoIm.Visible = false;
                lblMaternoIm.Visible = false;
                txtMaternoIm.Visible = false;
                cmdAceptar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "4")
            {
                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreIm.Visible = true;
                txtNombreIm.Visible = true;
                lblPaternoIm.Visible = true;
                txtPaternoIm.Visible = true;
                lblMaternoIm.Visible = true;
                txtMaternoIm.Visible = true;
                cmdAceptar.Visible = true;
            }
        }
    }
    }
