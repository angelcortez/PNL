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
    public partial class MediaFiliacionOfendido : System.Web.UI.Page
    {

        Data PGJ = new Data();
        Data CAT = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!Page.IsPostBack)
            {

                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                //ID_PERSONA.Text =  Session["ID_PERSONA"].ToString() ;
                lblArbol.Text = Session["lblArbol"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();


                if (Session["op"].ToString() != "Agregar")
                {
                    //IdDetencion.Text = Session["ID_DETENCION"].ToString();
                }
                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR MEDIA FILIACIÓN";
                    //IdDetencion.Text = Session["ID_DETENCION"].ToString();
                   
                    
                    cargarImputado();

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR MEDIA FILIACIÓN";

                    Session["IdMediaFiliacionDetSec"] = Request.QueryString["IdMediaFiliacionDetSec"];
                    ID_MEDIA_FILIACION.Text = Session["IdMediaFiliacionDetSec"].ToString();

                    
                    cargarMediaFiliacion();
                    cargarImputado();
                    //ddlImputado.Visible = false;

                }

                cargarFecha();

                CAT.ConnectCatalogosMediaFiliacion();

                CAT.CargaComboCatalogosMediaFiliacion(ddlComplecion, "CAT_COMPLEXION", "IdCompexion", "Complexion");
                //cargarComplexion();

                CAT.CargaComboCatalogosMediaFiliacion(ddlColorPiel, "CAT_COLOR_PIEL", "IdColorPiel", "ColorPiel");
                //cargarColorPiel();

                CAT.CargaComboCatalogosMediaFiliacion(ddlCara, "CAT_CARA", "IdCara", "Cara");
                //cargarCara();

                CAT.CargaComboCatalogosMediaFiliacion(ddlCantidadCabello, "CAT_CANT_CABELLO", "IdCantidadCabello", "CantidadCabello");
                //cargarCantidadCabello();

                CAT.CargaComboCatalogosMediaFiliacion(ddlColorCabello, "CAT_COLOR_CABELLO", "IdColorCabello", "ColorCabello");
                //cargarColorCabello();

                CAT.CargaComboCatalogosMediaFiliacion(ddlFormaCabello, "CAT_FORMA_CABELLO", "IdFormaCabello", "FormaCabello");
                //cargarFormaCabello();

                CAT.CargaComboCatalogosMediaFiliacion(ddlCalvicieCabello, "CAT_CALVICIE_CABELLO", "IdCalvicieCabello", "Calvicie");
                //cargarCalvicieCabello();

                CAT.CargaComboCatalogosMediaFiliacion(ddlImplantacionCabello, "CAT_IMPLANTACION_CABELLO", "IdImplantacionCabello", "ImplantacionCabello");
                //cargarImplantacionCabello();

                CAT.CargaComboCatalogosMediaFiliacion(ddlAlturaFrente, "CAT_ALTURA_FRENTE", "IdAlturaFrente", "AlturaFrente");
                //cargarAlturaFrente();

                CAT.CargaComboCatalogosMediaFiliacion(ddlInclinacionFrente, "CAT_INCLINACION_FRENTE", "IdIncilacionFrente", "InclinacionFrente");
                //cargarInclinacionFrente();

                CAT.CargaComboCatalogosMediaFiliacion(ddlAnchoFrente, "CAT_ANCHO_FRENTE", "IdAnchoFrente", "AnchoFrente");
                //cargarAnchoFrente();

                CAT.CargaComboCatalogosMediaFiliacion(ddlColorOjos, "CAT_COLOR_OJOS", "IdColorOjos", "ColorOjos");
                //cargarColorOjos();

                CAT.CargaComboCatalogosMediaFiliacion(ddlFormaOjos, "CAT_FORMA_OJOS", "IdFormaOjos", "FormaOjos");
                //cargarFormaOjos();

                CAT.CargaComboCatalogosMediaFiliacion(ddlTamañoOjos, "CAT_TAMAÑO_OJOS", "IdTamañoOjos", "TamañoOjos");
                //cargarTamañoOjos();

                CAT.CargaComboCatalogosMediaFiliacion(ddlDireccionCejas, "CAT_DIRECCION_CEJAS", "IdDireccionCeja", "DireccionCeja");
                //cargarDireccionCejas();

                CAT.CargaComboCatalogosMediaFiliacion(ddlImplantacionCejas, "CAT_IMPLANTACION_CEJAS", "IdImplantacionCeja", "ImplantacionCeja");
                //cargarImplantacionCejas();

                CAT.CargaComboCatalogosMediaFiliacion(ddlFormaCejas, "CAT_FORMA_CEJAS", "IdFormaCeja", "FormaCeja");
                //cargarFormaCejas();

                CAT.CargaComboCatalogosMediaFiliacion(ddlTamañoCejas, "CAT_TAMAÑO_CEJAS", "IdTamañoCeja", "TamañoCeja");
                //cargarTamañoCejas();

                CAT.CargaComboCatalogosMediaFiliacion(ddlTamañoBoca, "CAT_TAMAÑO_BOCA", "IdTamañoBoca", "TamañoBoca");
                //cargarTamañoBoca();

                CAT.CargaComboCatalogosMediaFiliacion(ddlComisurasBoca, "CAT_COMISURAS_BOCA", "IdComisurasBoca", "ComisurasBoca");
                //cargarComisurasBoca();

                CAT.CargaComboCatalogosMediaFiliacion(ddlAnteojos, "CAT_ANTEOJOS", "IdAnteojos", "Anteojos");
                //cargarAnteojos();

                CAT.CargaComboCatalogosMediaFiliacion(ddlEspesorLabios, "CAT_ESPESOR_LABIOS", "IdEspesorLabios", "EspesorLabios");
                //cargarEspesorlabio();

                CAT.CargaComboCatalogosMediaFiliacion(ddlNasoLabial, "CAT_NASO_LABIAL", "IdNasoLabial", "NasoLabial");
                //cargarNasoLabial();

                CAT.CargaComboCatalogosMediaFiliacion(ddlProminenciaLabial, "CAT_PROMINENCIA_LABIAL", "IdProminenciaLabial", "ProminenciaLabial");
                //cargarProminenciaLabial();

                CAT.CargaComboCatalogosMediaFiliacion(ddlTipoMenton, "CAT_TIPO_MENTON", "IdTipoMenton", "TipoMenton");
                //cargarTipoMenton();

                CAT.CargaComboCatalogosMediaFiliacion(ddlFormaMenton, "CAT_FORMA_MENTON", "IdFormaMenton", "FormaMenton");
                //cargarFormaMenton();

                CAT.CargaComboCatalogosMediaFiliacion(ddlInclinacionMenton, "CAT_INCLINACION_MENTON", "IdInclinacionMenton", "InclinacionMenton");
                //cargarInclinacionMenton();

                CAT.CargaComboCatalogosMediaFiliacion(ddlFormaOreja, "CAT_FORMA_OREJA", "IdFormaOreja", "FormaOreja");
                //cargarFormaOreja();

                CAT.CargaComboCatalogosMediaFiliacion(ddlOriginalOreja, "CAT_ORIGINAL_OREJA", "IdOriginalOreja", "OriginalOreja");
                //cargarOriginalOreja();

                CAT.CargaComboCatalogosMediaFiliacion(ddlSuperiorHelix, "CAT_SUPERIOR_HELIX", "IdSuperiorHelix", "SuperiorHelix");
                //cargarHelixSuperior();

                CAT.CargaComboCatalogosMediaFiliacion(ddlPosteriorHelix, "CAT_POSTERIOR_HELIX", "IdPosteriorHelix", "PosteriorHelix");
                //cargarHelixPosterior();

                CAT.CargaComboCatalogosMediaFiliacion(ddlAdherenciaHelix, "CAT_ADHERENCIA_HELIX", "IdAdherenciaHelix", "AdherenciaHelix");
                //cargarHelixAdherencia();

                CAT.CargaComboCatalogosMediaFiliacion(ddlContornoLobulo, "CAT_CONTORNO_LOBULO", "IdContornoLobulo", "ContornoLobulo");
                //cargarContornoLobulo();

                CAT.CargaComboCatalogosMediaFiliacion(ddlAdherenciaLobulo, "CAT_ADHERENCIA_LOBULO", "IdAdherenciaLobulo", "AdherenciaLobulo");
                //cargarAdherenciaLobulo();

                CAT.CargaComboCatalogosMediaFiliacion(ddlParticularidadLobulo, "CAT_PARTICULARIDAD_LOBULO", "IdParticularidadLobulo", "ParticularidadLobulo");
                //cargarPaticularidadLobulo();

                CAT.CargaComboCatalogosMediaFiliacion(ddlDimensionLobulo, "CAT_DIMENSION_LOBULO", "IdDimensionLobulo", "DimensionLobulo");
                //cargarDimencionLobulo();

                CAT.CargaComboCatalogosMediaFiliacion(ddlTipoSangre, "CAT_TIPO_SANGRE", "IdTipoSangre", "TipoSangre");
                //cargarTipoSangre();

                CAT.CargaComboCatalogosMediaFiliacion(ddlFactarSangre, "CAT_FACTOR_RH", "IdFactorRH", "FactorRH");
                //cargarFactorSangre();

                CAT.CargaComboCatalogosMediaFiliacion(ddlAlturaNariz, "CAT_ALTURA_NARIZ", "IdAlturaNariz", "AlturaNariz");
                // cargarAlturaNariz();

                 CAT.CargaComboCatalogosMediaFiliacion(ddlBaseNariz, "CAT_BASE_NARIZ", "IdBaseNariz", "BaseNariz");
                //cargarBaseNariz();

                CAT.CargaComboCatalogosMediaFiliacion(ddlAnchoNariz, "CAT_ANCHO_NARIZ", "IdAnchoNariz", "AnchoNariz");
                //cargarAnchoNariz();

                CAT.CargaComboCatalogosMediaFiliacion(ddlDorsoNariz, "CAT_DORSO_NARIZ", "IdDorsoNariz", "DorsoNariz");
                 //cargarDorzoNariz();

                 CAT.CargaComboCatalogosMediaFiliacion(ddlRaizNariz, "CAT_RAIZ_NARIZ", "IdRaizNariz", "RaizNariz");
                //cargarRaizNariz();

                

                

                
                 

                

            }
        }


        void cargarImputado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorImputado(int.Parse(IdCarpeta.Text))
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

                PGJ.agregarMediaFiliacion(int.Parse(ddlImputado.SelectedValue.ToString()), short.Parse(ddlComplecion.SelectedValue.ToString()), short.Parse(ddlColorPiel.SelectedValue.ToString()), short.Parse(ddlCara.SelectedValue.ToString()), short.Parse(ddlCantidadCabello.SelectedValue.ToString()), short.Parse(ddlColorCabello.SelectedValue.ToString()), short.Parse(ddlFormaCabello.SelectedValue.ToString()), short.Parse(ddlCalvicieCabello.SelectedValue.ToString()), short.Parse(ddlImplantacionCabello.SelectedValue.ToString()), short.Parse(ddlAlturaFrente.SelectedValue.ToString()), short.Parse(ddlInclinacionFrente.SelectedValue.ToString()), short.Parse(ddlAnchoFrente.SelectedValue.ToString()), short.Parse(ddlDireccionCejas.SelectedValue.ToString()), short.Parse(ddlImplantacionCejas.SelectedValue.ToString()), short.Parse(ddlFormaCejas.SelectedValue.ToString()), short.Parse(ddlTamañoCejas.SelectedValue.ToString()), short.Parse(ddlColorOjos.SelectedValue.ToString()), short.Parse(ddlFormaOjos.SelectedValue.ToString()), short.Parse(ddlTamañoOjos.SelectedValue.ToString()), short.Parse(ddlRaizNariz.SelectedValue.ToString()), short.Parse(ddlDorsoNariz.SelectedValue.ToString()), short.Parse(ddlAnchoNariz.SelectedValue.ToString()), short.Parse(ddlBaseNariz.SelectedValue.ToString()), short.Parse(ddlAlturaNariz.SelectedValue.ToString()), short.Parse(ddlTamañoBoca.SelectedValue.ToString()), short.Parse(ddlComisurasBoca.SelectedValue.ToString()), short.Parse(ddlEspesorLabios.SelectedValue.ToString()), short.Parse(ddlNasoLabial.SelectedValue.ToString()), short.Parse(ddlProminenciaLabial.SelectedValue.ToString()), short.Parse(ddlTipoMenton.SelectedValue.ToString()), short.Parse(ddlFormaMenton.SelectedValue.ToString()), short.Parse(ddlInclinacionMenton.SelectedValue.ToString()), short.Parse(ddlFormaOreja.SelectedValue.ToString()), short.Parse(ddlOriginalOreja.SelectedValue.ToString()), short.Parse(ddlSuperiorHelix.SelectedValue.ToString()), short.Parse(ddlPosteriorHelix.SelectedValue.ToString()), short.Parse(ddlAdherenciaHelix.SelectedValue.ToString()), short.Parse(ddlContornoLobulo.SelectedValue.ToString()), short.Parse(ddlAdherenciaLobulo.SelectedValue.ToString()), short.Parse(ddlParticularidadLobulo.SelectedValue.ToString()), short.Parse(ddlDimensionLobulo.SelectedValue.ToString()), short.Parse(ddlTipoSangre.SelectedValue.ToString()), short.Parse(ddlFactarSangre.SelectedValue.ToString()), short.Parse(ddlAnteojos.SelectedValue.ToString()), txtEstatura.Text, txtPeso.Text, short.Parse(Session["IdMunicipio"].ToString()), int.Parse(IdCarpeta.Text));
                string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";
                DesactivarControles();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                //Response.Redirect("RegistrarDetencion.aspx?op=Agregar");
            }
            else if (Session["op"].ToString() == "Modificar")
            {

                PGJ.modificarMediaFiliacion(int.Parse(ID_MEDIA_FILIACION.Text), short.Parse(ddlComplecion.SelectedValue.ToString()), short.Parse(ddlColorPiel.SelectedValue.ToString()), short.Parse(ddlCara.SelectedValue.ToString()), short.Parse(ddlCantidadCabello.SelectedValue.ToString()), short.Parse(ddlColorCabello.SelectedValue.ToString()), short.Parse(ddlFormaCabello.SelectedValue.ToString()), short.Parse(ddlCalvicieCabello.SelectedValue.ToString()), short.Parse(ddlImplantacionCabello.SelectedValue.ToString()), short.Parse(ddlAlturaFrente.SelectedValue.ToString()), short.Parse(ddlInclinacionFrente.SelectedValue.ToString()), short.Parse(ddlAnchoFrente.SelectedValue.ToString()), short.Parse(ddlDireccionCejas.SelectedValue.ToString()), short.Parse(ddlImplantacionCejas.SelectedValue.ToString()), short.Parse(ddlFormaCejas.SelectedValue.ToString()), short.Parse(ddlTamañoCejas.SelectedValue.ToString()), short.Parse(ddlColorOjos.SelectedValue.ToString()), short.Parse(ddlFormaOjos.SelectedValue.ToString()), short.Parse(ddlTamañoOjos.SelectedValue.ToString()), short.Parse(ddlRaizNariz.SelectedValue.ToString()), short.Parse(ddlDorsoNariz.SelectedValue.ToString()), short.Parse(ddlAnchoNariz.SelectedValue.ToString()), short.Parse(ddlBaseNariz.SelectedValue.ToString()), short.Parse(ddlAlturaNariz.SelectedValue.ToString()), short.Parse(ddlTamañoBoca.SelectedValue.ToString()), short.Parse(ddlComisurasBoca.SelectedValue.ToString()), short.Parse(ddlEspesorLabios.SelectedValue.ToString()), short.Parse(ddlNasoLabial.SelectedValue.ToString()), short.Parse(ddlProminenciaLabial.SelectedValue.ToString()), short.Parse(ddlTipoMenton.SelectedValue.ToString()), short.Parse(ddlFormaMenton.SelectedValue.ToString()), short.Parse(ddlInclinacionMenton.SelectedValue.ToString()), short.Parse(ddlFormaOreja.SelectedValue.ToString()), short.Parse(ddlOriginalOreja.SelectedValue.ToString()), short.Parse(ddlSuperiorHelix.SelectedValue.ToString()), short.Parse(ddlPosteriorHelix.SelectedValue.ToString()), short.Parse(ddlAdherenciaHelix.SelectedValue.ToString()), short.Parse(ddlContornoLobulo.SelectedValue.ToString()), short.Parse(ddlAdherenciaLobulo.SelectedValue.ToString()), short.Parse(ddlParticularidadLobulo.SelectedValue.ToString()), short.Parse(ddlDimensionLobulo.SelectedValue.ToString()), short.Parse(ddlTipoSangre.SelectedValue.ToString()), short.Parse(ddlFactarSangre.SelectedValue.ToString()), short.Parse(ddlAnteojos.SelectedValue.ToString()), txtEstatura.Text, txtPeso.Text);
                string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";
                DesactivarControles();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                
                //Response.Redirect("RegistrarDetencion.aspx?op=Modificar");
            }

        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_SECUESTRO.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }
        }

        void DesactivarControles()
        {
            ddlComplecion.Enabled = false;
            ddlColorPiel.Enabled = false;
            ddlCara.Enabled = false;
            ddlCantidadCabello.Enabled = false;
            ddlColorCabello.Enabled = false;
            ddlFormaCabello.Enabled = false;
            ddlCalvicieCabello.Enabled = false;
            ddlImplantacionCabello.Enabled = false;
            ddlAlturaFrente.Enabled = false;
            ddlInclinacionFrente.Enabled = false;
            ddlAnchoFrente.Enabled = false;
            ddlColorOjos.Enabled = false;
            ddlFormaOjos.Enabled = false;
            ddlTamañoOjos.Enabled = false;
            ddlDireccionCejas.Enabled = false;
            ddlImplantacionCejas.Enabled = false;
            ddlFormaCejas.Enabled = false;
            ddlTamañoCejas.Enabled = false;
            ddlRaizNariz.Enabled = false;
            ddlEspesorLabios.Enabled = false;
            ddlTamañoBoca.Enabled = false;
            ddlComisurasBoca.Enabled = false;
            ddlDorsoNariz.Enabled = false;
            ddlAnchoNariz.Enabled = false;
            ddlBaseNariz.Enabled = false;
            ddlAlturaNariz.Enabled = false;
            ddlNasoLabial.Enabled = false;
            ddlProminenciaLabial.Enabled = false;
            ddlTipoMenton.Enabled = false;
            ddlFormaMenton.Enabled = false;
            ddlInclinacionMenton.Enabled = false;
            ddlFormaOreja.Enabled = false;
            ddlOriginalOreja.Enabled = false;
            ddlSuperiorHelix.Enabled = false;
            ddlPosteriorHelix.Enabled = false;
            ddlAdherenciaHelix.Enabled = false;
            ddlContornoLobulo.Enabled = false;
            ddlAdherenciaLobulo.Enabled = false;
            ddlParticularidadLobulo.Enabled = false;
            ddlDimensionLobulo.Enabled = false;
            ddlTipoSangre.Enabled = false;
            ddlFactarSangre.Enabled = false;
            ddlAnteojos.Enabled = false;
            txtEstatura.Enabled = false;
            txtPeso.Enabled = false;
            cmdGuardar.Enabled = false;

        }



        void cargarMediaFiliacion()
        {


            SqlCommand sql = new SqlCommand("cargarMediaFiliacionDetenidoSec  " + ID_MEDIA_FILIACION.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {   
                dr.Read();
                ddlImputado.SelectedValue=dr["IdPersona"].ToString();
                ddlComplecion.SelectedValue = dr["IdCompexion"].ToString();
                ddlColorPiel.SelectedValue = dr["IdColorPiel"].ToString();
                ddlCara.SelectedValue = dr["IdCara"].ToString();
                ddlCantidadCabello.SelectedValue = dr["IdCantidadCabello"].ToString();
                ddlColorCabello.SelectedValue = dr["IdColorCabello"].ToString();
                ddlFormaCabello.SelectedValue = dr["IdFormaCabello"].ToString();
                ddlCalvicieCabello.SelectedValue = dr["IdCalvicieCabello"].ToString();
                ddlImplantacionCabello.SelectedValue = dr["IdImplantacionCabello"].ToString();
                ddlAlturaFrente.SelectedValue = dr["IdAlturaFrente"].ToString();
                ddlInclinacionFrente.SelectedValue = dr["IdIncilacionFrente"].ToString();
                ddlAnchoFrente.SelectedValue = dr["IdAnchoFrente"].ToString();
                ddlColorOjos.SelectedValue = dr["IdColorOjos"].ToString();
                ddlFormaOjos.SelectedValue = dr["IdFormaOjos"].ToString();
                ddlTamañoOjos.SelectedValue = dr["IdTamañoOjos"].ToString();
                ddlDireccionCejas.SelectedValue = dr["IdDireccionCeja"].ToString();
                ddlImplantacionCejas.SelectedValue = dr["IdImplantacionCeja"].ToString();
                ddlFormaCejas.SelectedValue = dr["IdFormaCeja"].ToString();
                ddlTamañoCejas.SelectedValue = dr["IdTamañoCeja"].ToString();

                ddlTamañoBoca.SelectedValue = dr["IdTamañoBoca"].ToString();
                ddlComisurasBoca.SelectedValue = dr["IdComisurasBoca"].ToString();
                ddlEspesorLabios.SelectedValue = dr["IdEspesorLabios"].ToString();
                ddlRaizNariz.SelectedValue =  dr["IdRaizNariz"].ToString();

                    ddlDorsoNariz.SelectedValue = dr["IdDorsoNariz"].ToString();
                    ddlAnchoNariz.SelectedValue = dr["IdAnchoNariz"].ToString();
                    ddlBaseNariz.SelectedValue = dr["IdBaseNariz"].ToString();
                    ddlAlturaNariz.SelectedValue = dr["IdAlturaNariz"].ToString();
                    ddlNasoLabial.SelectedValue = dr["IdNasoLabial"].ToString();
                    ddlProminenciaLabial.SelectedValue = dr["IdProminenciaLabial"].ToString();
                    ddlTipoMenton.SelectedValue = dr["IdTipoMenton"].ToString();
                    ddlFormaMenton.SelectedValue = dr["IdFormaMenton"].ToString();
                    ddlInclinacionMenton.SelectedValue = dr["IdInclinacionMenton"].ToString();
                    ddlFormaOreja.SelectedValue = dr["IdFormaOreja"].ToString();
                    ddlOriginalOreja.SelectedValue = dr["IdOriginalOreja"].ToString();
                    ddlSuperiorHelix.SelectedValue = dr["IdSuperiorHelix"].ToString();
                    ddlPosteriorHelix.SelectedValue = dr["IdPosteriorHelix"].ToString();
                    ddlAdherenciaHelix.SelectedValue = dr["IdAdherenciaHelix"].ToString();
                    ddlContornoLobulo.SelectedValue = dr["IdContornoLobulo"].ToString();
                    ddlAdherenciaLobulo.SelectedValue = dr["IdAdherenciaLobulo"].ToString();
                    ddlParticularidadLobulo.SelectedValue = dr["IdParticularidadLobulo"].ToString();
                    ddlDimensionLobulo.SelectedValue = dr["IdDimensionLobulo"].ToString();
                    ddlTipoSangre.SelectedValue = dr["IdTipoSangre"].ToString();
                    ddlFactarSangre.SelectedValue = dr["IdFactorRH"].ToString();
                    ddlAnteojos.SelectedValue = dr["IdAnteojos"].ToString();
                    txtEstatura.Text = dr["Estatura"].ToString();
                    txtPeso.Text = dr["Peso"].ToString();


            }
            dr.Close();
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

        
 
    }
}