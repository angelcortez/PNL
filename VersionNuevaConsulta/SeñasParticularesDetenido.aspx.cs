using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtencionTemprana;
using System.Data.SqlClient;

namespace TarjetaInformativa
{
    public partial class SeñasParticularesOfendido : System.Web.UI.Page
    {
        Data PGJ = new Data();

        Data CAT = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                lblArbol.Text = Session["lblArbol"].ToString();
                CAT.ConnectCatalogosMediaFiliacion();

                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                //Session["IdSeñaParticular"] = Request.QueryString["IdSeñaParticular"];
                //Session["IdOfendido"] = Request.QueryString["IdOfendido"];

                Session["op"] = Request.QueryString["op"];
                //Session["Folio"] = Request.QueryString["Folio"];

                if (Session["op"].ToString() != "Agregar")
                {
                    //IdDetencion.Text = Session["ID_DETENCION"].ToString();
                    //txtId.Text = Session["IdSeñaParticular"].ToString();

                    //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                    
                }
                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR SEÑAS PARTICULARES";
                    //IdDetencion.Text = Session["ID_DETENCION"].ToString();
                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                    cargarImputado();
                  

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    //lblOperacion.Text = "MODIFICAR SEÑAS PARTICULARES";
                    //IdDetencion.Text = Session["ID_DETENCION"].ToString();

                    //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                    //IdMunicipio.Text = Session["IdMunicipio"].ToString();

                    //Session["IdPersona"] = Request.QueryString["IdPersona"];
                    //ID_PERSONA.Text = Session["IdPersona"].ToString();
                    ////cargarSeñasParticulares();

                    Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    cargarImputado();
                    cargarSeñasParticulares();

                }

                cargarFecha();

                CAT.CargaComboCatalogosMediaFiliacion(ddlTipoSeña, "CAT_TIPO_SEÑA", "IdTipoSeña", "TipoSeña");
                CAT.CargaComboCatalogosMediaFiliacion(ddlDescripcionSeña, "CAT_DESCRIPCION_SEÑA", "IdDescripcionSeña", "DescripcionSeña");
                CAT.CargaComboCatalogosMediaFiliacion(ddlVista, "CAT_VISTA", "IdVista", "Vista");
                CAT.CargaComboCatalogosMediaFiliacion(ddlLado, "CAT_LADO", "IdLado", "lado");
                CAT.CargaComboCatalogosMediaFiliacion(ddlCantidad, "CAT_CANTIDAD_REGION", "IdCantidadRegion", "CantidadRegion");
                CAT.CargaComboCatalogosMediaFiliacion(ddlRegion, "CAT_REGION", "IdRegion", "Region");
              
                

            }
        }

        void cargarImputado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorImputado(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.IMPUTADO };
            ddlImputado.DataSource = im;
            ddlImputado.DataValueField = "ID_PERSONA";
            ddlImputado.DataTextField = "IMPUTADO";
            ddlImputado.DataBind();
        }
        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                Response.Redirect("MediaFiliacionDetenido.aspx?op=Agregar");
            }
            else if (Session["op"].ToString() == "Modificar")
            { 
                Response.Redirect("MediaFiliacionDetenido.aspx?op=Modificar");
            }
        }

        protected void cmdregresar_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_SECUESTRO.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
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

        void cargarSeñasParticulares()
        {

            SqlCommand sql = new SqlCommand("cargaPGJSeñasParticularesDetSec  " + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();



                ddlImputado.SelectedValue = dr["IdPersona"].ToString();
                

            }
            dr.Close();
        }

        protected void btnAgregarSeña_Click1(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {

                PGJ.agregarPGJSeñas(int.Parse(ddlImputado.SelectedValue.ToString()), short.Parse(ddlTipoSeña.SelectedValue.ToString()), short.Parse(ddlDescripcionSeña.SelectedValue.ToString()), short.Parse(ddlVista.SelectedValue.ToString()), short.Parse(ddlLado.SelectedValue.ToString()), short.Parse(ddlRegion.SelectedValue.ToString()), short.Parse(ddlCantidad.SelectedValue.ToString()), txtObservaciones.Text, short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ID_CARPETA.Text));

                //Mostramos la Seña en el Grid
                gvSeñasParticulares.DataSourceID = "dsVerSeñas";
                gvSeñasParticulares.DataBind();

            }
            else if (Session["op"].ToString() == "Modificar")
            {

                PGJ.agregarPGJSeñas(int.Parse(ddlImputado.SelectedValue.ToString()), short.Parse(ddlTipoSeña.SelectedValue.ToString()), short.Parse(ddlDescripcionSeña.SelectedValue.ToString()), short.Parse(ddlVista.SelectedValue.ToString()), short.Parse(ddlLado.SelectedValue.ToString()), short.Parse(ddlRegion.SelectedValue.ToString()), short.Parse(ddlCantidad.SelectedValue.ToString()), txtObservaciones.Text, short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ID_CARPETA.Text));
                //Mostramos la Seña en el Grid
                gvSeñasParticulares.DataSourceID = "dsVerSeñas";
                gvSeñasParticulares.DataBind();

            }
        }

   
            
         
    }
}