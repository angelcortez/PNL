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
using Subgurim.Controles;

namespace AtencionTemprana
{
    public partial class AutoridadDenuncia : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                lblArbol.Text = Session["lblArbol"].ToString();
               
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
               
                Session["op"] = Request.QueryString["op"];

                cargarFecha();

                PGJ.CargaCombo(ddlPusoDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");

                if (Session["op"].ToString() == "Agregar")
                {
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();                            

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    Session["ID_DENUNCIANTE_AUTORIDAD"] = Request.QueryString["ID_DENUNCIANTE_AUTORIDAD"]; 

                    Panel1.Visible = true;
                    cmdSi.Visible = false;
                    cmdNo.Visible = false;
                    lblDenuncia.Visible = false;
                    cargarAutoridad();
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

        protected void cmdSi_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton PERSONA", int.Parse(Session["IdModuloBitacora"].ToString()));
            

            Response.Redirect("Datos.aspx?" + "&op=Agregar");
        }

        protected void cmdNo_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton AUTORIDAD Puesto a disposicion: " + ddlPusoDisposicion.SelectedItem + " Numero de Oficio o Parte: " + txtOficio.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            

            cmdSi.Visible = false;
            cmdNo.Visible = false;
            Panel1.Visible = true;
            lblDenuncia.Visible = false;
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            try
            {
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()),  Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            

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
                else if (lblArbol.Text == "6")
                {
                    if (Session["ID_PUESTO"].ToString() == "16")
                    {
                        Response.Redirect("OrdenCoordPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                    else if (Session["ID_PUESTO"].ToString() == "8")
                    {
                        Response.Redirect("OrdenPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                }

                else if (lblArbol.Text == "8")
                {
                    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                PGJ.InsertaDenuncianteAutoridad(int.Parse(Session["ID_CARPETA"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlPusoDisposicion.SelectedValue.ToString()), txtOficio.Text, short.Parse(Session["IdUsuario"].ToString()));

            }
            else if (Session["op"].ToString() == "Modificar")
            {

                PGJ.ActualizaDenuncianteAutoridad(int.Parse(ID_DENUNCIANTE_AUTORIDAD.Text), short.Parse(ddlPusoDisposicion.SelectedValue.ToString()), txtOficio.Text, short.Parse(Session["IdUsuario"].ToString()));
                 
            }

            lblEstatus.Text = "DATOS GUARDADOS";
            cmdGu.Enabled = false;
        }

        void cargarAutoridad()
        {
            SqlCommand sql = new SqlCommand("cargarDenuncianteAutoridad " + int.Parse(Session["ID_DENUNCIANTE_AUTORIDAD"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ID_DENUNCIANTE_AUTORIDAD.Text = dr["ID_DENUNCIANTE_AUTORIDAD"].ToString();
                // Data.IdPersona = Convert.ToInt32(ID_PERSONA.Text);
                ddlPusoDisposicion.SelectedValue = dr["ID_PUSO_DISPOSICION"].ToString();
                txtOficio.Text = dr["NUMERO_OFICIO"].ToString();  
            }
            dr.Close();
        }

    }
}