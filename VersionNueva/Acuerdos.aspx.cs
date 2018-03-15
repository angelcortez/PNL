using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Acuerdos : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            PGJ.ConnectServer();
            cargarFecha();
            LBLUSUARIO.Text = Session["Us"].ToString();
            IdMunicipio.Text = Session["IdMunicipio"].ToString();
            lblIdUnidad.Text = Session["IdUnidad"].ToString();

            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();

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
                gvMediacion.DataSourceID = "dsConsultaSoliciudMediacion";
                gvMediacion.DataBind();
                gvMediacion.Visible = true;
                cmdAc.Visible = false;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                cmdAc.Visible = true;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                cmdAc.Visible = true;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                cmdAc.Visible = true;

                lblNUM.Visible = true;
                txtNUM.Visible = true;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
            }

            if (ddlBuscar.SelectedValue == "4")
            {
                cmdAc.Visible = true;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = true;
                txtFechaInicioNum.Visible = true;
                lblFechaFinNum.Visible = true;
                txtFechaFinNum.Visible = true;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "5")
            {
                cmdAc.Visible = true;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = true;
                txtNombre.Visible = true;
                lblPaterno.Visible = true;
                txtPaterno.Visible = true;
                lblMaterno.Visible = true;
                txtMaterno.Visible = true;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "6")
            {
                cmdAc.Visible = true;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "7")
            {
                cmdAc.Visible = true;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = true;
                txtNombreR.Visible = true;
                lblPaternoR.Visible = true;
                txtPaternoR.Visible = true;
                lblMaternoR.Visible = true;
                txtMaternoR.Visible = true;
            }

        }

        protected void cmdAc_Click(object sender, EventArgs e)
        {

            if (ddlBuscar.SelectedValue == "1")
            {
                gvMediacion.DataSourceID = "dsBuscarNUM";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "2")
            {
                gvMediacion.DataSourceID = "dsBuscarFechaInicioNUM";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "3")
            {
                gvMediacion.DataSourceID = "dsBuscarDenunciante";
                gvMediacion.DataBind();
            }

            else if (ddlBuscar.SelectedValue == "4")
            {
                gvMediacion.DataSourceID = "dsBuscarRequerido";
                gvMediacion.DataBind();
            }
        }




    }
}