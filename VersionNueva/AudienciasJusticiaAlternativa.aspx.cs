using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AtencionTemprana
{
    public partial class AudienciasJusticiaAlternativa : System.Web.UI.Page
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
                try
                {
                    PGJ.CargaComboFiltrado(ddlFacilitador, "CAT_AGENTES_MP", "ID_AGENTE", "NOMBRE", "(ID_tipo_unidad=3) and ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());

                }
                catch (Exception ex)
                {
                    Response.Redirect("AudienciasJusticiaAlternativa.aspx");
                }
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

                lblNum.Visible = false;
                txtNum.Visible = false;
                lblFechaInicio.Visible = false;
                txtFechaInicio.Visible = false;
                lblFechaFin.Visible = false;
                txtFechaFin.Visible = false;
                lblFacilitador.Visible = false;
                ddlFacilitador.Visible = false;
                cmdAceptar.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                lblNum.Visible = true;
                txtNum.Visible = true;
                lblFechaInicio.Visible = false;
                txtFechaInicio.Visible = false;
                lblFechaFin.Visible = false;
                txtFechaFin.Visible = false;
                lblFacilitador.Visible = false;
                ddlFacilitador.Visible = false;
                cmdAceptar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                lblNum.Visible = false;
                txtNum.Visible = false;
                lblFechaInicio.Visible = true;
                txtFechaInicio.Visible = true;
                lblFechaFin.Visible = true;
                txtFechaFin.Visible = true;
                lblFacilitador.Visible = false;
                ddlFacilitador.Visible = false;
                cmdAceptar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                lblNum.Visible = false;
                txtNum.Visible = false;
                lblFechaInicio.Visible = false;
                txtFechaInicio.Visible = false;
                lblFechaFin.Visible = false;
                txtFechaFin.Visible = false;
                lblFacilitador.Visible = true;
                ddlFacilitador.Visible = true;
                cmdAceptar.Visible = true;
            }
        }

        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvNuc.DataSourceID = "dsBuscarNum";
                gvNuc.DataBind();
                gvNuc1.DataSourceID = "dsBuscarNumMañana";
                gvNuc1.DataBind();
                gvNuc2.DataSourceID = "dsBuscarNumSiguiente";
                gvNuc2.DataBind();
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                gvNuc.DataSourceID = "dsBuscarFechas";
                gvNuc.DataBind();
                gvNuc1.DataSourceID = "dsBuscarFechasMañana";
                gvNuc1.DataBind();
                gvNuc2.DataSourceID = "dsBuscarFechasSiguiente";
                gvNuc2.DataBind();
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                gvNuc.DataSourceID = "dsBuscarFacilitador";
                gvNuc.DataBind();
                gvNuc1.DataSourceID = "dsBuscarFacilitadorMañana";
                gvNuc1.DataBind();
                gvNuc2.DataSourceID = "dsBuscarFacilitadorSiguiente";
                gvNuc2.DataBind();
            }
        }



        protected void gvNuc_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void cmdAsistieron_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvNuc.Rows)
                {

                    String ID_AUDIENCIA = row.Cells[1].Text;
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chbSelect");
                    if (cb.Checked == true)
                    {
                        SqlCommand Cmd = new SqlCommand("ActualizaEstatusAudienciaAsistencia", Data.CnnCentral);
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.Add("@ID_AUDIENCIA", SqlDbType.Int);
                        Cmd.Parameters["@ID_AUDIENCIA"].Value = ID_AUDIENCIA;
                        SqlDataReader DR = Cmd.ExecuteReader();
                        DR.Close();
                        string script = @"<script type='text/javascript'>
                            alert('Audiencia Registrada');
                                   </script>";
                        //script = string.Format(script, ex.Message);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        gvNuc.DataBind();
                    }

                }
            }
            catch (Exception es)
            {
                Label2.Text = es.Message;
            }
        }

        protected void cmdRep_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvNuc.Rows)
                {

                    String ID_AUDIENCIA = row.Cells[1].Text;
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chbSelect");
                    if (cb.Checked == true)
                    {
                        SqlCommand Cmd = new SqlCommand("ActualizaEstatusAudienciaReprogramacion", Data.CnnCentral);
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.Add("@ID_AUDIENCIA", SqlDbType.Int);
                        Cmd.Parameters["@ID_AUDIENCIA"].Value = ID_AUDIENCIA;
                        SqlDataReader DR = Cmd.ExecuteReader();
                        DR.Close();
                        string script = @"<script type='text/javascript'>
                            alert('Audiencia Registrada');
                                   </script>";
                        //script = string.Format(script, ex.Message);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        gvNuc.DataBind();
                    }

                }
            }
            catch (Exception es)
            {
                Label2.Text = es.Message;
            }
        }

        protected void cmdAudiencia_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvNuc.Rows)
                {

                    String ID_AUDIENCIA = row.Cells[1].Text;
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chbSelect");
                    if (cb.Checked == true)
                    {
                        SqlCommand Cmd = new SqlCommand("ActualizaEstatusOtraAudiencia", Data.CnnCentral);
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.Add("@ID_AUDIENCIA", SqlDbType.Int);
                        Cmd.Parameters["@ID_AUDIENCIA"].Value = ID_AUDIENCIA;
                        SqlDataReader DR = Cmd.ExecuteReader();
                        DR.Close();
                        string script = @"<script type='text/javascript'>
                            alert('Audiencia Registrada');
                                   </script>";
                        //script = string.Format(script, ex.Message);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        gvNuc.DataBind();
                    }

                }
            }
            catch (Exception es)
            {
                Label2.Text = es.Message;
            }
        }

        protected void cmdAcuerdo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvNuc.Rows)
                {

                    String ID_AUDIENCIA = row.Cells[1].Text;
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chbSelect");
                    if (cb.Checked == true)
                    {
                        SqlCommand Cmd = new SqlCommand("ActualizaEstatusAudienciaAcuerdo", Data.CnnCentral);
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.Add("@ID_AUDIENCIA", SqlDbType.Int);
                        Cmd.Parameters["@ID_AUDIENCIA"].Value = ID_AUDIENCIA;
                        SqlDataReader DR = Cmd.ExecuteReader();
                        DR.Close();
                        string script = @"<script type='text/javascript'>
                            alert('Audiencia Registrada');
                                   </script>";
                        //script = string.Format(script, ex.Message);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        gvNuc.DataBind();
                    }

                }
            }
            catch (Exception es)
            {
                Label2.Text = es.Message;
            }
        }
    }
}