using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace AtencionTemprana
{
    public partial class InicioProcesoNoAceptacion : System.Web.UI.Page
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

        protected void cmdAc_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvMediacion.DataSourceID = "dsBuscarRAC";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "2")
            {
                gvMediacion.DataSourceID = "dsBuscarFechaInicioRAC";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "3")
            {
                gvMediacion.DataSourceID = "dsBuscarNUM";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "4")
            {
                gvMediacion.DataSourceID = "dsBuscarFechaInicioNUM";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "5")
            {
                gvMediacion.DataSourceID = "dsBuscarDenunciante";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "6")
            {
                gvMediacion.DataSourceID = "dsBuscarNuc";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "7")
            {
                gvMediacion.DataSourceID = "dsBuscarRequerido";
                gvMediacion.DataBind();
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
                gvMediacion.DataSourceID = "dsConsultaSoliciudMediacion";
                gvMediacion.DataBind();
                gvMediacion.Visible = true;

                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = false;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;

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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                txtRac.Visible = true;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = true;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = true;
                txtFechaFinRac.Visible = true;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = true;
                lblFechaFinRac.Visible = true;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }

            if (ddlBuscar.SelectedValue == "4")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "5")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "6")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
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
                lblNuc.Visible = true;
                txtNuc.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "7")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
        }

        protected void gvMediacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[10].Text == "INICIADA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[10].Text == "PROCESO")
                {
                    e.Row.ForeColor = System.Drawing.Color.Orange;
                }
                if (e.Row.Cells[10].Text == "SUSPENDIDA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
                if (e.Row.Cells[10].Text == "REMITIDA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }

            }
        }
    }
}