using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class UnidadRAC : System.Web.UI.Page
    {
        Data PGJ = new Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

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

        protected void cmdNuc_Click(object sender, EventArgs e)
        {
            Session["INICIAR_CARPETA"] = "1";
            //Response.Redirect("FormaInicioRac.aspx");
            Response.Redirect("WTipoDQ.aspx");
        }

        protected void gvRAC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "TRAMITE")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[4].Text == "CANALIZADA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                if (e.Row.Cells[4].Text == "MEDIOS ALTERNATIVOS DE SOLUCION DE CONFLICTOS")
                {
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
                if (e.Row.Cells[4].Text == "DERIVADA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
                if (e.Row.Cells[4].Text == "RESUELTA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void cmdAc_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                GridPersona.Visible = false;
                gvRAC.Visible = true;
                gvRAC.DataSourceID = "dsBuscarRAc";
                gvRAC.DataBind();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 6, "Buscar RAC " + txtRAC.Text + " En: " + UNDD.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                GridPersona.Visible = false;
                gvRAC.Visible = true;
                gvRAC.DataSourceID = "dsFechaInicio";
                gvRAC.DataBind();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 6, "Buscar Fecha Inicio RAC Del: " + txtFechaInicio.Text + " Al: " + txtFechaFin.Text + " En: " + UNDD.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                GridPersona.Visible = false;
                gvRAC.Visible = true;
                gvRAC.DataSourceID = "dsDenunciante";
                gvRAC.DataBind();
            }
            if (ddlBuscar.SelectedValue == "4")
            {
                GridPersona.Visible = false;
                gvRAC.Visible = true;
                gvRAC.DataSourceID = "dsImputado";
                gvRAC.DataBind();
            }
            if (ddlBuscar.SelectedValue == "5")
            {
                GridPersona.Visible = true;
                gvRAC.Visible = false;
                GridPersona.DataSourceID = "dsPersona";
                GridPersona.DataBind();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 6, "Buscar Persona RAC Nombre: " + txtNombreIm.Text + " " + txtPaternoIm.Text + " " + txtMaternoIm.Text + " En: " + UNDD.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            }
        }

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvRAC.DataSourceID = "dsConsultaRAC";
                gvRAC.DataBind();
                gvRAC.Visible = true;

                txtRAC.Visible = false;
                txtFechaInicio.Visible = false;
                txtFechaFin.Visible = false;
                cmdAc.Visible = false;

                lblRac.Visible = false;
                lblFechaInicio.Visible = false;
                lblFechaFin.Visible = false;

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
                txtRAC.Visible = true;
                txtFechaInicio.Visible = false;
                txtFechaFin.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = true;
                lblFechaInicio.Visible = false;
                lblFechaFin.Visible = false;

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
                txtRAC.Visible = false;
                txtFechaInicio.Visible = true;
                txtFechaFin.Visible = true;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicio.Visible = true;
                lblFechaFin.Visible = true;

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
                txtRAC.Visible = false;
                txtFechaInicio.Visible = false;
                txtFechaFin.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicio.Visible = false;
                lblFechaFin.Visible = false;

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
                txtRAC.Visible = false;
                txtFechaInicio.Visible = false;
                txtFechaFin.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicio.Visible = false;
                lblFechaFin.Visible = false;

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
            }
            if (ddlBuscar.SelectedValue == "5")
            {
                txtRAC.Visible = false;
                txtFechaInicio.Visible = false;
                txtFechaFin.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicio.Visible = false;
                lblFechaFin.Visible = false;

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
            }
        }

        protected void GridPersona_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "TRAMITE")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[4].Text == "CANALIZADA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                if (e.Row.Cells[4].Text == "MEDIOS ALTERNATIVOS DE SOLUCION DE CONFLICTOS")
                {
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
                if (e.Row.Cells[4].Text == "DERIVADA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
                if (e.Row.Cells[4].Text == "RESUELTA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

    }
}