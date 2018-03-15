using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class AgenciaInvestigacion : System.Web.UI.Page
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
                gvNuc.DataSourceID = "dsBuscarNuc";
                gvNuc.DataBind();
            }
            if (ddlBuscar.SelectedValue == "4")
            {
                gvNuc.DataSourceID = "dsBuscarFechaInicioNuc";
                gvNuc.DataBind();
            }
            if (ddlBuscar.SelectedValue == "5")
            {
                gvNuc.DataSourceID = "dsBuscarDenunciante";
                gvNuc.DataBind();
            }
            if (ddlBuscar.SelectedValue == "6")
            {
                gvNuc.DataSourceID = "dsBuscarImputado";
                gvNuc.DataBind();
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
                gvNuc.DataSourceID = "dsConsultaNUC";
                gvNuc.DataBind();
                gvNuc.Visible = true;

                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
                lblFechaInicioNuc.Visible = false;
                txtFechaFinNuc.Visible = false;
                lblFechaFinNuc.Visible = false;
                txtFechaInicioNuc.Visible = false;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
                lblFechaInicioNuc.Visible = false;
                txtFechaFinNuc.Visible = false;
                lblFechaFinNuc.Visible = false;
                txtFechaInicioNuc.Visible = false;
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
                lblNuc.Visible = false;
                txtNuc.Visible = false;
                lblFechaInicioNuc.Visible = false;
                txtFechaFinNuc.Visible = false;
                lblFechaFinNuc.Visible = false;
                txtFechaInicioNuc.Visible = false;
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
                lblNuc.Visible = true;
                txtNuc.Visible = true;
                lblFechaInicioNuc.Visible = false;
                txtFechaFinNuc.Visible = false;
                lblFechaFinNuc.Visible = false;
                txtFechaInicioNuc.Visible = false;
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

            if (ddlBuscar.SelectedValue == "4")
            {
                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
                lblFechaInicioNuc.Visible = true;
                txtFechaFinNuc.Visible = true;
                lblFechaFinNuc.Visible = true;
                txtFechaInicioNuc.Visible = true;
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
            if (ddlBuscar.SelectedValue == "5")
            {
                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
                lblFechaInicioNuc.Visible = false;
                txtFechaFinNuc.Visible = false;
                lblFechaFinNuc.Visible = false;
                txtFechaInicioNuc.Visible = false;
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
            if (ddlBuscar.SelectedValue == "6")
            {
                lblRac.Visible = false;
                txtRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                txtFechaFinRac.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
                lblFechaInicioNuc.Visible = false;
                txtFechaFinNuc.Visible = false;
                lblFechaFinNuc.Visible = false;
                txtFechaInicioNuc.Visible = false;
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

        protected void cmdNuc_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormaInicioNuc.aspx");

                //PGJ.GenerarNC("NUC", short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));
                //PGJ.InsertaNUCUnidad(Data.NUC, 10, short.Parse(Session["IdUsuario"].ToString()));

                //gvNuc.DataBind();

                //string CAD;
                //CAD = "INSERT INTO PGJ_RAC_REMITIDA(ID_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD = CAD + "VALUES(" + Data.IdCarpeta + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

                //SqlCommand sqlGuardarRemitida = new SqlCommand(CAD, Data.CnnCentral);
                //SqlDataReader rdGuardaRemitida = sqlGuardarRemitida.ExecuteReader();


                //cmdNuc.Enabled = false;

        }

        protected void gvNuc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "TRAMITE")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[4].Text == "JUDICIALIZADA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
                if (e.Row.Cells[4].Text == "ARCHIVO TEMPORAL")
                {
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
                if (e.Row.Cells[4].Text == "NO EJERCICIO")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                if (e.Row.Cells[4].Text == "CRITERIO DE OPORTUNIDAD")
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
                if (e.Row.Cells[4].Text == "ACUERDO PARA ABSTENERSE DE INVESTIGAR")
                {
                    e.Row.ForeColor = System.Drawing.Color.Violet;
                }
                if (e.Row.Cells[4].Text == "INCOMPETENCIA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Teal;
                }
            }
        }
    }
}