using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;

namespace AtencionTemprana
{
    public partial class JusticiaAlternativaAudiencia : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                lblArbol.Text = Session["lblArbol"].ToString();

                Session["ID_AUDIENCIA"] = Request.QueryString["ID_AUDIENCIA"];

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["op"] = Request.QueryString["op"];
               

                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR AUDIENCIA";
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    // articuloDelito();
                    //consultaIdDelito();
                    try
                    {
                        PGJ.CargaComboFiltrado(ddlMediador, "CAT_AGENTES_MP", "ID_AGENTE", "NOMBRE", "ID_TIPO_UNIDAD=3 and ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());
                        PGJ.CargaComboFiltrado(ddlSala, "CAT_SALA_AUDIENCIAS", "ID_SALA", "SALA", "ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("JusticiaAlternativaAudiencia.aspx?&op=Agregar");
                    }

                    cargarImputado();
                    cargarDenunciante();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR AUDIENCIA";
                    try
                    {
                        PGJ.CargaComboFiltrado(ddlMediador, "CAT_AGENTES_MP", "ID_AGENTE", "NOMBRE", "ID_TIPO_UNIDAD=3 and ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());
                        PGJ.CargaComboFiltrado(ddlSala, "CAT_SALA_AUDIENCIAS", "ID_SALA", "SALA", "ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());
                      
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("JusticiaAlternativaAudiencia.aspx?ID_AUDIENCIA=" + Session["ID_AUDIENCIA"].ToString() + "&op=Modificar");
                    }
                    cargarAudiencia();
                    cargarDenunciante();
                    cargarImputado();
                   
                }
            }
        }
        void cargarImputado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorImputado(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.IMPUTADO };
            ddlRequerido.DataSource = im;
            ddlRequerido.DataValueField = "ID_PERSONA";
            ddlRequerido.DataTextField = "IMPUTADO";
            ddlRequerido.DataBind();
        }
       
        void cargarDenunciante()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorDenunciante(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.DENUNCIANTE };
            ddlSolicitante.DataSource = im;
            ddlSolicitante.DataValueField = "ID_PERSONA";
            ddlSolicitante.DataTextField = "DENUNCIANTE";
            ddlSolicitante.DataBind();
        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
          try{
            if (Session["op"].ToString() == "Agregar")
            {
                if (rbTipo.SelectedValue == "1")
                {
                    PGJ.InsertaMediacionAudiencia(int.Parse(IdCarpeta.Text), DateTime.Parse(txtFechaAudiencia.Text), txtHora.Text, short.Parse(rbTipo.SelectedValue), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlRequerido.SelectedValue.ToString()), short.Parse(ddlMediador.SelectedValue.ToString()), short.Parse(ddlSala.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()));          
                }
                else if (rbTipo.SelectedValue == "2")
                {
                    PGJ.InsertaMediacionAudiencia(int.Parse(IdCarpeta.Text), DateTime.Parse(txtFechaAudiencia.Text), txtHora.Text, short.Parse(rbTipo.SelectedValue), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlRequerido.SelectedValue.ToString()), short.Parse(ddlMediador.SelectedValue.ToString()), short.Parse(ddlSala.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()));           
                }
                else if (rbTipo.SelectedValue == "3")
                {
                    PGJ.InsertaMediacionAudiencia(int.Parse(IdCarpeta.Text), DateTime.Parse(txtFechaAudiencia.Text), txtHora.Text, short.Parse(rbTipo.SelectedValue), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlRequerido.SelectedValue.ToString()), short.Parse(ddlMediador.SelectedValue.ToString()), short.Parse(ddlSala.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()));         
                }
             }
            else if (Session["op"].ToString() == "Modificar")
            {
                if (rbTipo.SelectedValue == "1")
                {
                    PGJ.ActualizaMediacionAudiencia(int.Parse(ID_AUDIENCIA.Text), DateTime.Parse(txtFechaAudiencia.Text), txtHora.Text, short.Parse(rbTipo.SelectedValue), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlRequerido.SelectedValue.ToString()), short.Parse(ddlMediador.SelectedValue.ToString()),short.Parse(ddlSala.SelectedValue.ToString()));
                }
                else if (rbTipo.SelectedValue == "2")
                {
                    PGJ.ActualizaMediacionAudiencia(int.Parse(ID_AUDIENCIA.Text), DateTime.Parse(txtFechaAudiencia.Text), txtHora.Text, short.Parse(rbTipo.SelectedValue), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlRequerido.SelectedValue.ToString()), short.Parse(ddlMediador.SelectedValue.ToString()), short.Parse(ddlSala.SelectedValue.ToString()));
                }
                else if (rbTipo.SelectedValue == "3")
                {
                    PGJ.ActualizaMediacionAudiencia(int.Parse(ID_AUDIENCIA.Text), DateTime.Parse(txtFechaAudiencia.Text), txtHora.Text, short.Parse(rbTipo.SelectedValue), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlRequerido.SelectedValue.ToString()), short.Parse(ddlMediador.SelectedValue.ToString()), short.Parse(ddlSala.SelectedValue.ToString()));
                }
               
            }

            lblEstatus.Text = "DATOS GUARDADOS";
            cmdGu.Enabled = false;
             }
             catch (Exception ex)
             {
                 lblEstatus.Text = ex.Message;
                 lblEstatus1.Text = "INTENTELO NUEVAMENTE";
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
        protected void cmdReg_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "2")
            {
                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString());
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
            }
        }

        void cargarAudiencia()
        {
            SqlCommand sql = new SqlCommand("cargarMediacionAudiencia " + int.Parse(Session["ID_AUDIENCIA"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                IdCarpeta.Text = dr["ID_CARPETA"].ToString();
                ID_AUDIENCIA.Text = dr["ID_AUDIENCIA"].ToString();
                txtFechaAudiencia.Text = dr["FECHA_AUDIENCIA"].ToString();
                txtHora.Text = dr["HORA_AUDIENCIA"].ToString();
                rbTipo.SelectedValue = dr["ID_TIPO_AUDIENCIA"].ToString();
                ddlSala.SelectedValue = dr["ID_SALA"].ToString();

                ddlRequerido.SelectedValue = dr["ID_IMPUTADO"].ToString();
                ddlSolicitante.SelectedValue = dr["ID_DENUNCIANTE"].ToString();
                ddlMediador.SelectedValue = dr["ID_MEDIADOR"].ToString();
                if (rbTipo.SelectedValue == "1")
                {
                    lblSolicitante.Visible = false;
                    ddlSolicitante.Visible = false;
                    lblRequerido.Visible = false;
                    ddlRequerido.Visible = false;
                }
                else if (rbTipo.SelectedValue == "2")
                {
                    lblSolicitante.Visible = true;
                    ddlSolicitante.Visible = true;
                    lblRequerido.Visible = false;
                    ddlRequerido.Visible = false;
                }
                else if (rbTipo.SelectedValue == "3")
                {
                    lblSolicitante.Visible = false;
                    ddlSolicitante.Visible = false;
                    lblRequerido.Visible = true;
                    ddlRequerido.Visible = true;
                }
                              
            }
            dr.Close();
        }

        protected void rbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbTipo.SelectedValue == "1")
            {
                lblSolicitante.Visible = false;
                ddlSolicitante.Visible = false;
                lblRequerido.Visible = false;
                ddlRequerido.Visible = false;
            }
            else if (rbTipo.SelectedValue == "2")
            {
                lblSolicitante.Visible = true;
                ddlSolicitante.Visible = true;
                lblRequerido.Visible = false;
                ddlRequerido.Visible = false;
            }
            else if (rbTipo.SelectedValue == "3")
            {
                lblSolicitante.Visible = false;
                ddlSolicitante.Visible = false;
                lblRequerido.Visible = true;
                ddlRequerido.Visible = true;
            }
        }

        
    }
}