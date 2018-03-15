using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class DerivadasDeAtencion : System.Web.UI.Page
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

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvNAC.DataSourceID = "dsConsultaNAC";
                gvNAC.DataBind();
                gvNAC.Visible = true;

                txtNac.Visible = false;
                txtFechaInicioNac.Visible = false;
                txtFechaFinNac.Visible = false;
                cmdAceptar.Visible = false;

                lblRac.Visible = false;
                lblFechaInicioNac.Visible = false;
                lblFechaFinNac.Visible = false;

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
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                txtNac.Visible = true;
                txtFechaInicioNac.Visible = false;
                txtFechaFinNac.Visible = false;
                cmdAceptar.Visible = true;

                lblRac.Visible = true;
                lblFechaInicioNac.Visible = false;
                lblFechaFinNac.Visible = false;

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
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                txtNac.Visible = false;
                txtFechaInicioNac.Visible = true;
                txtFechaFinNac.Visible = true;
                cmdAceptar.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioNac.Visible = true;
                lblFechaFinNac.Visible = true;

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
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                txtNac.Visible = false;
                txtFechaInicioNac.Visible = false;
                txtFechaFinNac.Visible = false;
                cmdAceptar.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioNac.Visible = false;
                lblFechaFinNac.Visible = false;

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
            } 
            if (ddlBuscar.SelectedValue == "4")
            {
                txtNac.Visible = false;
                txtFechaInicioNac.Visible = false;
                txtFechaFinNac.Visible = false;
                cmdAceptar.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioNac.Visible = false;
                lblFechaFinNac.Visible = false;

                lblNombre.Visible = true;
                txtNombre.Visible = true;
                lblPaterno.Visible = true;
                txtPaterno.Visible = true;
                lblMaterno.Visible = true;
                txtMaterno.Visible = true;
                lblNombreIm.Visible = true;
                txtNombreIm.Visible = true;
                lblPaternoIm.Visible = true;
                txtPaternoIm.Visible = true;
                lblMaternoIm.Visible = true;
                txtMaternoIm.Visible = true;
            }
        }

        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvNAC.DataSourceID = "dsBuscarNAC";
                gvNAC.DataBind();
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                gvNAC.DataSourceID = "dsFechaInicio";
                gvNAC.DataBind();
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                gvNAC.DataSourceID = "dsDenunciante";
                gvNAC.DataBind();
            }
            if (ddlBuscar.SelectedValue == "4")
            {
                gvNAC.DataSourceID = "dsImputado";
                gvNAC.DataBind();
            }
        }
    }
}