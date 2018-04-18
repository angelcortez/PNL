using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtencionTemprana;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class PNLSeniasParticulares : System.Web.UI.Page
    {
        Data PGJ = new Data();
        Data CAT = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                //LBLUSUARIO.Text = Session["New"].ToString();
                //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();


                

                Session["op"] = Request.QueryString["op"];
               

               
                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR SEÑAS PARTICULARES";
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();
                    //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();
                    cargarOfendido();


                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR SEÑAS PARTICULARES";

                    Session["ID_SENIA"] = Request.QueryString["ID_SENIA"];
                    ID_SENIAS_PARTICULARES.Text = Session["ID_SENIA"].ToString();
                    cargarSeñasParticulares();

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consultó Señas Particulares con IdSeña =" + ID_SENIAS_PARTICULARES.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
                    cargarOfendido();

                }

                cargarFecha();
                CAT.ConnectCatalogosMediaFiliacion();

                CAT.CargaComboCatalogosMediaFiliacion(ddlTipoSeña, "CAT_TIPO_SEÑA", "IdTipoSeña", "TipoSeña");
                // void cargarTipoSeña();
                CAT.CargaComboCatalogosMediaFiliacion(ddlDescripcionSeña, "CAT_DESCRIPCION_SEÑA", "IdDescripcionSeña", "DescripcionSeña");
                //cargarDescripcionSeña();
                CAT.CargaComboCatalogosMediaFiliacion(ddlVista, "CAT_VISTA", "IdVista", "Vista");
                //cargarVista();

                CAT.CargaComboCatalogosMediaFiliacion(ddlLado, "CAT_LADO", "IdLado", "lado");
                //cargarLado();

                CAT.CargaComboCatalogosMediaFiliacion(ddlCantidad, "CAT_CANTIDAD_REGION", "IdCantidadRegion", "CantidadRegion");
                //cargarCantidadRegion();

                CAT.CargaComboCatalogosMediaFiliacion(ddlRegion, "CAT_REGION", "IdRegion", "Region");
                //cargarNoRegion();


            }
        }

        void cargarOfendido()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorOfendido(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.OFENDIDO };
            ddlOfendido.DataSource = im;
            ddlOfendido.DataValueField = "ID_PERSONA";
            ddlOfendido.DataTextField = "OFENDIDO";
            ddlOfendido.DataBind();
        }
        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (ddlOfendido.SelectedValue == "0")
            {
                lblEstatus.Text = "SELECCIONA PERSONA";
            }
            else
            {

                if (Session["op"].ToString() == "Agregar")
                {

                    PGJ.agregarSeñasPNL(int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), short.Parse(ddlTipoSeña.SelectedValue.ToString()), short.Parse(ddlDescripcionSeña.SelectedValue.ToString()), short.Parse(ddlVista.SelectedValue.ToString()), short.Parse(ddlLado.SelectedValue.ToString()), short.Parse(ddlRegion.SelectedValue.ToString()), short.Parse(ddlCantidad.SelectedValue.ToString()), txtObservaciones.Text, short.Parse(Session["IdMunicipio"].ToString()));

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Seña Particular: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ddlOfendido.SelectedItem + ", Tipo de seña= " + ddlTipoSeña.SelectedItem + ", Descripción de seña= " + ddlDescripcionSeña.SelectedItem + ", Vista de seña= " + ddlVista.SelectedItem + ", Lado de seña= " + ddlLado.SelectedItem + ", Región de seña= " + ddlRegion.SelectedItem + ", Cantidad de seña= " + ddlCantidad.SelectedItem + ", Observaciones de seña= " + txtObservaciones.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                
                    
                    DesactivarControles();
                    string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


                }
                else if (Session["op"].ToString() == "Modificar")
                {

                    PGJ.modificarSeñasPNL(int.Parse(ID_SENIAS_PARTICULARES.Text), short.Parse(ddlTipoSeña.SelectedValue.ToString()), short.Parse(ddlDescripcionSeña.SelectedValue.ToString()), short.Parse(ddlVista.SelectedValue.ToString()), short.Parse(ddlLado.SelectedValue.ToString()), short.Parse(ddlRegion.SelectedValue.ToString()), short.Parse(ddlCantidad.SelectedValue.ToString()), txtObservaciones.Text);

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Seña Particular: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ddlOfendido.SelectedItem + ", Tipo de seña= " + ddlTipoSeña.SelectedItem + ", Descripción de seña= " + ddlDescripcionSeña.SelectedItem + ", Vista de seña= " + ddlVista.SelectedItem + ", Lado de seña= " + ddlLado.SelectedItem + ", Región de seña= " + ddlRegion.SelectedItem + ", Cantidad de seña= " + ddlCantidad.SelectedItem + ", Observaciones de seña= " + txtObservaciones.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                
                    
                    
                    DesactivarControles();
                    string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


                }

            }
        }

        protected void cmdregresar_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde Señas Particulares", int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("PNLDatosPrincipales.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Modificar" + "&ID_MUNICIPIO_CARPETA=" + Session["ID_MUNICIPIO_CARPETA"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_PERTENENCIA_SOCIAL=" + Session["ID_PERTENENCIA_SOCIAL"].ToString() + "&ID_INFO_FINANCIERA=" + Session["ID_INFO_FINANCIERA"].ToString() + "&ID_INFO_ODONTOLOGICA=" + Session["ID_INFO_ODONTOLOGICA"].ToString() + "&ID_DISCAPACIDADES=" + Session["ID_DISCAPACIDADES"].ToString() + "&ID_OTRA_INFO=" + Session["ID_OTRA_INFO"].ToString() + "&ID_CAUSALES=" + Session["ID_CAUSALES"].ToString());
       

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

        

        void cargarSeñasParticulares()
        {

            SqlCommand sql = new SqlCommand("PNL_ConsultaSenasInd  " + ID_SENIAS_PARTICULARES.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();


                ddlTipoSeña.SelectedValue = dr["IdTipoSena"].ToString();
                ddlDescripcionSeña.SelectedValue = dr["IdDescripcionSena"].ToString();

                ddlVista.SelectedValue = dr["IdVista"].ToString();
                ddlLado.SelectedValue = dr["IdLado"].ToString();
                ddlRegion.SelectedValue = dr["IdRegion"].ToString();

                ddlCantidad.SelectedValue = dr["IdCantidadRegion"].ToString();
                txtObservaciones.Text = dr["Descripcion"].ToString();
                ddlOfendido.SelectedValue = dr["IdPersona"].ToString();
            }
            dr.Close();
        }


        void DesactivarControles()
        {

            ddlCantidad.Enabled = false;
            ddlDescripcionSeña.Enabled = false;
            ddlLado.Enabled = false;
            ddlRegion.Enabled = false;
            ddlTipoSeña.Enabled = false;
            ddlVista.Enabled = false;
            txtObservaciones.Enabled = false;
            cmdGuardar.Enabled = false;

        
        }
    }
}