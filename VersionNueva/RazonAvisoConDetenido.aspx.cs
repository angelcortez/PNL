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
    public partial class RazonAvisoConDetenido : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblArbol.Text = Session["lblArbol"].ToString();

                Session["op"] = Request.QueryString["op"];
                cargarFecha();
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();


                Session["ID_RAZON_AVISO_DETENIDO"] = Request.QueryString["ID_RAZON_AVISO_DETENIDO"];

                PGJ.CargaCombo(ddlClasificacion, "CAT_CLASIFICACION_CORPORACION", "ID_CLASIFICACION", "CLASIFICACION_CORPORACION");

                if (Session["ID_ESTADO_NUC"] == null)
                {
                    Session["ID_ESTADO_NUC"] = "";
                }
                if (Session["ID_ESTADO_RAC"] == null)
                {
                    Session["ID_ESTADO_RAC"] = "";
                }
                if (Session["ID_ESTADO_NAC"] == null)
                {
                    Session["ID_ESTADO_NAC"] = "";
                }
                if (Session["ID_ESTADO_NUM"] == null)
                {
                    Session["ID_ESTADO_NUM"] = "";
                }

                Session["ID_ESTADO_RAC"].ToString();
                Session["ID_ESTADO_NUC"].ToString();
                Session["ID_ESTADO_NAC"].ToString();
                Session["ID_ESTADO_NUM"].ToString();


                if (Session["op"].ToString() == "Agregar")
                {
                   lblOperacion.Text = "AGREGAR RAZON DE AVISO CON DETENIDO";
                   ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                   
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR RAZON DE AVISO CON DETENIDO";
                    cargarRazon();
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

               protected void cmdReg_Click(object sender, EventArgs e)
               {
                   if (lblArbol.Text == "2")
                   {

                       Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() + "&tab=0");
                   }

                   else if (lblArbol.Text == "3")
                   {
                       Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() + "&tab=0");
                   }

                   else if (lblArbol.Text == "4")
                   {
                       Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() + "&tab=0");
                   }
                   else if (lblArbol.Text == "5")
                   {
                       Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() + "&tab=0");
                   }

               }

               protected void cmdGuardar_Click(object sender, EventArgs e)
               {
                   
                   if (Session["op"].ToString() == "Agregar")
                   {

                       PGJ.InsertaRazonAvisoDetenido(int.Parse(ID_CARPETA.Text), short.Parse(ddlClasificacion.SelectedValue.ToString()), short.Parse(ddlCoorporacion.SelectedValue.ToString()), txtNumeroOf.Text, txtFolioIPH.Text, txtFechaOf.Text);
                       
                   }

                   else if (Session["op"].ToString() == "Modificar")
                   {
                       PGJ.ActualizaAvisoDetenido(short.Parse(ddlClasificacion.SelectedValue.ToString()), short.Parse(ddlCoorporacion.SelectedValue.ToString()), txtNumeroOf.Text, txtFolioIPH.Text, int.Parse(IdRazonAviso.Text), txtFechaOf.Text);
                     
                   }

                    lblEstatus.Text = "DATOS GUARDADOS";
                    cmdGuardar.Enabled = false;
                    desactivarBotones();
               }

               

               protected void ddlClasificacion_SelectedIndexChanged(object sender, EventArgs e)
               {
                   Session["ID_CLASIFICACION"] = ddlClasificacion.SelectedValue.ToString();
                   consultaClasificacionCorporacion();
               }

               void consultaClasificacionCorporacion()
               {
                   dcOrientacionDataContext dc = new dcOrientacionDataContext();
                   var estado = from c in dc.consultaClasificacionCorporacion(short.Parse(Session["ID_CLASIFICACION"].ToString()))
                                select new { c.ID_CORPORACION, c.CORPORACION };
                   ddlCoorporacion.DataSource = estado;
                   ddlCoorporacion.DataValueField = "ID_CORPORACION";
                   ddlCoorporacion.DataTextField = "CORPORACION";
                   ddlCoorporacion.DataBind();
               }

               void desactivarBotones()
               {
                   ddlClasificacion.Enabled = false;
                   ddlCoorporacion.Enabled = false;
                   txtNumeroOf.Enabled = false;
                   txtFechaOf.Enabled = false;
                   txtFolioIPH.Enabled = false;
                  
               }

               void cargarRazon()
               {
                   SqlCommand sql = new SqlCommand("cargarRazonAvisoDetenido " + int.Parse(Session["ID_RAZON_AVISO_DETENIDO"].ToString()), Data.CnnCentral);
                   SqlDataReader dr = sql.ExecuteReader();
                   if (dr.HasRows)
                   {
                       dr.Read();

                       IdRazonAviso.Text = dr["ID_RAZON_AVISO_DETENIDO"].ToString();


                       Session["ID_CLASIFICACION"] = dr["ID_CLASIFICA_CORPORACION"].ToString();
                       ddlClasificacion.SelectedValue = Session["ID_CLASIFICACION"].ToString();
                       consultaClasificacionCorporacion();


                       ddlCoorporacion.SelectedValue = dr["ID_CORPORACION"].ToString();



                       txtNumeroOf.Text = dr["NUMERO_OFICIO"].ToString();
                       txtFechaOf.Text = dr["FECHA_OFICIO"].ToString();
                       txtFolioIPH.Text = dr["FOLIO_IPH"].ToString();
                 
                   }
                   dr.Close();
               }

    }
}