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
    public partial class AcuerdoCumplimientoInmediato : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblArbol.Text = Session["lblArbol"].ToString();

                Session["ID_ACUERDO_INMEDIATO"] = Request.QueryString["ID_ACUERDO_INMEDIATO"];

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["op"] = Request.QueryString["op"];

                cargarFecha();

               // PGJ.CargaComboFiltrado(ddlSolicitante, " PGJ_PERSONA P INNER JOIN PGJ_CARPETA_PERSONA PC ON PC.ID_PERSONA=P.ID_PERSONA ", " P.ID_PERSONA ", " NOMBRE  + ' ' + PATERNO  + ' ' + MATERNO ", " PC.ID_ESTADO_CARPETA=7 AND PC.ID_CARPETA= " + Session["ID_CARPETA"].ToString() + " " );
                PGJ.CargaComboFiltrado(ddlUnidad3, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR ACUERDO DE CUMPLIMIENTO INMEDIATO";
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    cargarInvitado();
                    cargarSolicitante();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR ACUERDO DE CUMPLIMIENTO INMEDIATO";

                    cargarAcuerdo();
                    cargarInvitado();
                    cargarSolicitante();
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

        void cargarInvitado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.InvitadoNombreNUM (int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.INVITADO  };
            ddlInvitado.DataSource = im;
            ddlInvitado.DataValueField = "ID_PERSONA";
            ddlInvitado.DataTextField = "INVITADO";
            ddlInvitado.DataBind();
        }
        void cargarSolicitante()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.SolicitanteNombreNUM(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.SOLICITANTE  };
            ddlSolicitante.DataSource = im;
            ddlSolicitante.DataValueField = "ID_PERSONA";
            ddlSolicitante.DataTextField = "SOLICITANTE";
            ddlSolicitante.DataBind();
        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["op"].ToString() == "Agregar")
                {
                    PGJ.InsertaAcuerdoInmediato(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()),int.Parse(ddlSolicitante.SelectedValue.ToString()),int.Parse(ddlInvitado.SelectedValue.ToString()),short.Parse(ddlUnidad3.SelectedValue.ToString()),26, DateTime.Parse(txtFechaInmediato.Text), txtConcepto.Text, txtImporte.Text, short.Parse(Session["IdUsuario"].ToString()));
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    PGJ.ActualizaAcuerdoInmediato(int.Parse(ID_ACUERDO_INMEDIATO.Text), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlInvitado.SelectedValue.ToString()), short.Parse(ddlUnidad3.SelectedValue.ToString()), DateTime.Parse(txtFechaInmediato.Text), txtConcepto.Text, txtImporte.Text);
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

        void cargarAcuerdo()
        {
            SqlCommand sql = new SqlCommand("cargarAcuerdoInmediato " + int.Parse(Session["ID_ACUERDO_INMEDIATO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ID_ACUERDO_INMEDIATO.Text = dr["ID_ACUERDO_INMEDIATO"].ToString();
                // Data.IdPersona = Convert.ToInt32(ID_PERSONA.Text);
                IdCarpeta.Text = dr["ID_CARPETA"].ToString();
                txtConcepto.Text = dr["CONCEPTO"].ToString();
                txtImporte.Text = dr["IMPORTE"].ToString();
                txtFechaInmediato.Text = dr["FECHA_CUMPLIMIENTO"].ToString();
                ddlSolicitante.SelectedValue = dr["ID_SOLICITANTE"].ToString();
                ddlInvitado.SelectedValue=dr["ID_INVITADO"].ToString();
                ddlUnidad3.SelectedValue=dr["ID_UNIDAD_REMITE"].ToString(); 
               

            }
            dr.Close();
        }
    }
}