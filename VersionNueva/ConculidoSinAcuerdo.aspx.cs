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
    public partial class ConculidoSinAcuerdo : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblArbol.Text = Session["lblArbol"].ToString();

                Session["ID_SIN_ACUERDO"] = Request.QueryString["ID_SIN_ACUERDO"];

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["op"] = Request.QueryString["op"];

                cargarFecha();
                PGJ.CargaComboFiltrado(ddlUnidad4, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR SIN ACUERDO";
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    cargarInvitado();
                    cargarSolicitante();
                  
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR SIN ACUERDO";

                    // PGJ.CargaComboFiltrado(ddlUnidad2, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());

                    cargarSinAcuerdo();
                    cargarInvitado();
                    cargarSolicitante();
                   
                }
            }
        }

        void cargarInvitado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.InvitadoNombreNUM(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.INVITADO };
            ddlInvitado.DataSource = im;
            ddlInvitado.DataValueField = "ID_PERSONA";
            ddlInvitado.DataTextField = "INVITADO";
            ddlInvitado.DataBind();
        }

        void cargarSolicitante()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.SolicitanteNombreNUM(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.SOLICITANTE };
            ddlSolicitante.DataSource = im;
            ddlSolicitante.DataValueField = "ID_PERSONA";
            ddlSolicitante.DataTextField = "SOLICITANTE";
            ddlSolicitante.DataBind();
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

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["op"].ToString() == "Agregar")
                {
                    PGJ.InsertaSinAcuerdo(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlInvitado.SelectedValue.ToString()), short.Parse(Session["IdUnidad"].ToString()),short.Parse(ddlUnidad4.SelectedValue.ToString()),DateTime.Parse(txtFechaSinAcuerdo.Text), short.Parse(Session["IdUsuario"].ToString()));
                    
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    PGJ.ActualizaSinAcuerdo(int.Parse(ID_SIN_ACUERDO.Text), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlInvitado.SelectedValue.ToString()),short.Parse(ddlUnidad4.SelectedValue.ToString()),DateTime.Parse(txtFechaSinAcuerdo.Text ));
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

        void cargarSinAcuerdo()
        {
            SqlCommand sql = new SqlCommand("cargaSinAcuerdo " + int.Parse(Session["ID_SIN_ACUERDO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_SIN_ACUERDO.Text = dr["ID_SIN_ACUERDO"].ToString();
                // Data.IdPersona = Convert.ToInt32(ID_PERSONA.Text);
                IdCarpeta.Text = dr["ID_CARPETA"].ToString();
                ddlSolicitante.SelectedValue = dr["ID_SOLICITANTE"].ToString();
                ddlInvitado.SelectedValue = dr["ID_INVITADO"].ToString();
                ddlUnidad4.SelectedValue = dr["ID_UNDD_REMITE"].ToString();
                txtFechaSinAcuerdo.Text = dr["FECHA_REMITE"].ToString();
            }
            dr.Close();
        }


    }
}