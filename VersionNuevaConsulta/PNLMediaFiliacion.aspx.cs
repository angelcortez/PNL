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
    public partial class PNLMediaFiliacion : System.Web.UI.Page
    {
        Data PGJ = new Data();
        Data CAT = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {

                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();


               
                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR MEDIA FILIACIÓN";

                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();
                   
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                    cargarOfendido();

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR MEDIA FILIACIÓN";
                    Session["IDMEDIAFILIACION"] = Request.QueryString["IDMEDIAFILIACION"];
                    ID_MEDIA_FILIACION.Text = Session["IDMEDIAFILIACION"].ToString();

                    cargarMediaFiliacion();
                    cargarOfendido();



                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Media filiación con IdMediaFiliacion =" + ID_MEDIA_FILIACION.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));

                        

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


                 CAT.CargaComboCatalogosMediaFiliacion(ddlPomulo, "cat_pomulos", "IdPomulo", "Pomulo");
                 CAT.CargaComboCatalogosMediaFiliacion(ddlTieneBarba,"cat_barba","IdBarba","Barba");
                 CAT.CargaComboCatalogosMediaFiliacion(ddlTipoBarba, "CAT_BARBA_TIPO", "IdTipoBarba", "TipoBarba");
                 CAT.CargaComboCatalogosMediaFiliacion(ddlColorBarba, "CAT_BARBA_COLOR", "IdColorBarba", "ColorBarba");
                 CAT.CargaComboCatalogosMediaFiliacion(ddlTieneBigote, "CAT_BIGOTE", "IdBigote", "Bigote");
                 CAT.CargaComboCatalogosMediaFiliacion(ddlTipoBigote,"CAT_BIGOTE_TIPO","IdTipoBigote","TipoBigote");
                 CAT.CargaComboCatalogosMediaFiliacion(ddlColorBigote,"CAT_BIGOTE_COLOR","IdColorBigote","ColorBigote");

                 if (ddlTieneBigote.SelectedItem.ToString() == "SI")
                 {
                     ddlColorBigote.Enabled = true;
                     ddlTipoBigote.Enabled = true;
                 }
                 else
                 {
                     ddlColorBigote.Enabled = false;
                     ddlTipoBigote.Enabled = false;
                 }

                 if (ddlTieneBarba.SelectedItem.ToString() == "SI")
                 {
                     ddlColorBarba.Enabled = true;
                     ddlTipoBarba.Enabled = true;
                 }
                 else
                 {
                     ddlColorBarba.Enabled = false;
                     ddlTipoBarba.Enabled = false;
                 }
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

                    PGJ.agregarMediaFiliacionPNL(int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), short.Parse(ddlComplecion.SelectedValue.ToString()), short.Parse(ddlColorPiel.SelectedValue.ToString()), short.Parse(ddlCara.SelectedValue.ToString()), short.Parse(ddlCantidadCabello.SelectedValue.ToString()), short.Parse(ddlColorCabello.SelectedValue.ToString()), short.Parse(ddlFormaCabello.SelectedValue.ToString()), short.Parse(ddlCalvicieCabello.SelectedValue.ToString()), short.Parse(ddlImplantacionCabello.SelectedValue.ToString()), short.Parse(ddlAlturaFrente.SelectedValue.ToString()), short.Parse(ddlInclinacionFrente.SelectedValue.ToString()), short.Parse(ddlAnchoFrente.SelectedValue.ToString()), short.Parse(ddlDireccionCejas.SelectedValue.ToString()), short.Parse(ddlImplantacionCejas.SelectedValue.ToString()), short.Parse(ddlFormaCejas.SelectedValue.ToString()), short.Parse(ddlTamañoCejas.SelectedValue.ToString()), short.Parse(ddlColorOjos.SelectedValue.ToString()), short.Parse(ddlFormaOjos.SelectedValue.ToString()), short.Parse(ddlTamañoOjos.SelectedValue.ToString()), short.Parse(ddlRaizNariz.SelectedValue.ToString()), short.Parse(ddlDorsoNariz.SelectedValue.ToString()), short.Parse(ddlAnchoNariz.SelectedValue.ToString()), short.Parse(ddlBaseNariz.SelectedValue.ToString()), short.Parse(ddlAlturaNariz.SelectedValue.ToString()), short.Parse(ddlTamañoBoca.SelectedValue.ToString()), short.Parse(ddlComisurasBoca.SelectedValue.ToString()), short.Parse(ddlEspesorLabios.SelectedValue.ToString()), short.Parse(ddlNasoLabial.SelectedValue.ToString()), short.Parse(ddlProminenciaLabial.SelectedValue.ToString()), short.Parse(ddlTipoMenton.SelectedValue.ToString()), short.Parse(ddlFormaMenton.SelectedValue.ToString()), short.Parse(ddlInclinacionMenton.SelectedValue.ToString()), short.Parse(ddlFormaOreja.SelectedValue.ToString()), short.Parse(ddlOriginalOreja.SelectedValue.ToString()), short.Parse(ddlSuperiorHelix.SelectedValue.ToString()), short.Parse(ddlPosteriorHelix.SelectedValue.ToString()), short.Parse(ddlAdherenciaHelix.SelectedValue.ToString()), short.Parse(ddlContornoLobulo.SelectedValue.ToString()), short.Parse(ddlAdherenciaLobulo.SelectedValue.ToString()), short.Parse(ddlParticularidadLobulo.SelectedValue.ToString()), short.Parse(ddlDimensionLobulo.SelectedValue.ToString()), short.Parse(ddlTipoSangre.SelectedValue.ToString()), short.Parse(ddlFactarSangre.SelectedValue.ToString()), short.Parse(ddlAnteojos.SelectedValue.ToString()), txtEstatura.Text, txtPeso.Text,
                        int.Parse(ddlTieneBigote.SelectedValue.ToString()), int.Parse(ddlColorBigote.SelectedValue.ToString()), int.Parse(ddlTipoBigote.SelectedValue.ToString()), int.Parse(ddlTieneBarba.SelectedValue.ToString()), int.Parse(ddlColorBarba.SelectedValue.ToString()), int.Parse(ddlTipoBarba.SelectedValue.ToString()), int.Parse(ddlPomulo.SelectedValue.ToString()));
                    string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Media filiación: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ddlOfendido.SelectedItem + ", Complexión= " + ddlComplecion.SelectedItem + ", Color de piel= " + ddlColorPiel.SelectedItem + ", Cara= " + ddlCara.SelectedItem + ", Cantidad de cabello= " + ddlCantidadCabello.SelectedItem + ", Color de cabello= " + ddlColorCabello.SelectedItem + ", Forma de cabello= " + ddlFormaCabello.SelectedItem + ", Calvicie= " + ddlCalvicieCabello.SelectedItem + ", Implantación de cabello= " + ddlImplantacionCabello.SelectedItem + ", Altura de frente= " + ddlAlturaFrente.SelectedItem + ", Inclinación de frente= " + ddlInclinacionFrente.SelectedItem + ", Ancho de frente= " + ddlAnchoFrente.SelectedItem + ", Dirección de cejas= " + ddlDireccionCejas.SelectedItem + ", Implantación de cejas= " + ddlImplantacionCejas.SelectedItem + ", Forma de cejas= " + ddlFormaCejas.SelectedItem + ", Tamaño de cejas= " + ddlTamañoCejas.SelectedItem + ", Color de ojos= " + ddlColorOjos.SelectedItem + ", Forma de ojos= " + ddlFormaOjos.SelectedItem + ", Tamaño de ojos= " + ddlTamañoOjos.SelectedItem + ", Raíz naríz= " + ddlRaizNariz.SelectedItem + ", Dorso naríz= " + ddlDorsoNariz.SelectedItem + ", Ancho naríz= " + ddlAnchoNariz.SelectedItem + ", Base naríz= " + ddlBaseNariz.SelectedItem + ", Altura naríz= " + ddlAlturaNariz.SelectedItem + ", Tamaño de boca= " + ddlTamañoBoca.SelectedItem + ", Comisuras boca= " + ddlComisurasBoca.SelectedItem + ", Espesor de labios= " + ddlEspesorLabios.SelectedItem + ", Naso labial= " + ddlNasoLabial.SelectedItem + ", Prominencia labial= " + ddlProminenciaLabial.SelectedItem + ", Tipo de mentón= " + ddlTipoMenton.SelectedItem + ", Forma de mentón= " + ddlFormaMenton.SelectedItem + ", Inclinación de mentón= " + ddlInclinacionMenton.SelectedItem + ", Forma de oreja= " + ddlFormaOreja.SelectedItem + ", Original oreja= " + ddlOriginalOreja.SelectedItem + ", Superior hélix= " + ddlSuperiorHelix.SelectedItem + ", Posterior hélix= " + ddlPosteriorHelix.SelectedItem + ", Adherencia hélix= " + ddlAdherenciaHelix.SelectedItem + ", Contorno lóbulo= " + ddlContornoLobulo.SelectedItem + ", Adherencia lóbulo= " + ddlAdherenciaLobulo.SelectedItem + ", Particularidad lóbulo= " + ddlParticularidadLobulo.SelectedItem + ", Dimensión lóbulo= " + ddlDimensionLobulo.SelectedItem + ", Tipo de sangre= " + ddlTipoSangre.SelectedItem + ", Etnia= " + ddlFactarSangre.SelectedItem + ", Anteojos= " + ddlAnteojos.SelectedItem + ", Estatura= " + txtEstatura.Text + ", Peso= " + txtPeso.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                
                    DesactivarControles();



                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                }
                else if (Session["op"].ToString() == "Modificar")
                {

                    PGJ.modificarMediaFiliacionPNL(int.Parse(ID_MEDIA_FILIACION.Text), short.Parse(ddlComplecion.SelectedValue.ToString()), short.Parse(ddlColorPiel.SelectedValue.ToString()), short.Parse(ddlCara.SelectedValue.ToString()), short.Parse(ddlCantidadCabello.SelectedValue.ToString()), short.Parse(ddlColorCabello.SelectedValue.ToString()), short.Parse(ddlFormaCabello.SelectedValue.ToString()), short.Parse(ddlCalvicieCabello.SelectedValue.ToString()), short.Parse(ddlImplantacionCabello.SelectedValue.ToString()), short.Parse(ddlAlturaFrente.SelectedValue.ToString()), short.Parse(ddlInclinacionFrente.SelectedValue.ToString()), short.Parse(ddlAnchoFrente.SelectedValue.ToString()), short.Parse(ddlDireccionCejas.SelectedValue.ToString()), short.Parse(ddlImplantacionCejas.SelectedValue.ToString()), short.Parse(ddlFormaCejas.SelectedValue.ToString()), short.Parse(ddlTamañoCejas.SelectedValue.ToString()), short.Parse(ddlColorOjos.SelectedValue.ToString()), short.Parse(ddlFormaOjos.SelectedValue.ToString()), short.Parse(ddlTamañoOjos.SelectedValue.ToString()), short.Parse(ddlRaizNariz.SelectedValue.ToString()), short.Parse(ddlDorsoNariz.SelectedValue.ToString()), short.Parse(ddlAnchoNariz.SelectedValue.ToString()), short.Parse(ddlBaseNariz.SelectedValue.ToString()), short.Parse(ddlAlturaNariz.SelectedValue.ToString()), short.Parse(ddlTamañoBoca.SelectedValue.ToString()), short.Parse(ddlComisurasBoca.SelectedValue.ToString()), short.Parse(ddlEspesorLabios.SelectedValue.ToString()), short.Parse(ddlNasoLabial.SelectedValue.ToString()), short.Parse(ddlProminenciaLabial.SelectedValue.ToString()), short.Parse(ddlTipoMenton.SelectedValue.ToString()), short.Parse(ddlFormaMenton.SelectedValue.ToString()), short.Parse(ddlInclinacionMenton.SelectedValue.ToString()), short.Parse(ddlFormaOreja.SelectedValue.ToString()), short.Parse(ddlOriginalOreja.SelectedValue.ToString()), short.Parse(ddlSuperiorHelix.SelectedValue.ToString()), short.Parse(ddlPosteriorHelix.SelectedValue.ToString()), short.Parse(ddlAdherenciaHelix.SelectedValue.ToString()), short.Parse(ddlContornoLobulo.SelectedValue.ToString()), short.Parse(ddlAdherenciaLobulo.SelectedValue.ToString()), short.Parse(ddlParticularidadLobulo.SelectedValue.ToString()), short.Parse(ddlDimensionLobulo.SelectedValue.ToString()), short.Parse(ddlTipoSangre.SelectedValue.ToString()), short.Parse(ddlFactarSangre.SelectedValue.ToString()), short.Parse(ddlAnteojos.SelectedValue.ToString()), txtEstatura.Text, txtPeso.Text,
                        int.Parse(ddlTieneBigote.SelectedValue.ToString()), int.Parse(ddlColorBigote.SelectedValue.ToString()), int.Parse(ddlTipoBigote.SelectedValue.ToString()), int.Parse(ddlTieneBarba.SelectedValue.ToString()), int.Parse(ddlColorBarba.SelectedValue.ToString()), int.Parse(ddlTipoBarba.SelectedValue.ToString()), int.Parse(ddlPomulo.SelectedValue.ToString()));
                    string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Inserta Media filiación: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdMediaFiliacion= " + ID_MEDIA_FILIACION.Text+ ", Complexión= " + ddlComplecion.SelectedItem + ", Color de piel= " + ddlColorPiel.SelectedItem + ", Cara= " + ddlCara.SelectedItem + ", Cantidad de cabello= " + ddlCantidadCabello.SelectedItem + ", Color de cabello= " + ddlColorCabello.SelectedItem + ", Forma de cabello= " + ddlFormaCabello.SelectedItem + ", Calvicie= " + ddlCalvicieCabello.SelectedItem + ", Implantación de cabello= " + ddlImplantacionCabello.SelectedItem + ", Altura de frente= " + ddlAlturaFrente.SelectedItem + ", Inclinación de frente= " + ddlInclinacionFrente.SelectedItem + ", Ancho de frente= " + ddlAnchoFrente.SelectedItem + ", Dirección de cejas= " + ddlDireccionCejas.SelectedItem + ", Implantación de cejas= " + ddlImplantacionCejas.SelectedItem + ", Forma de cejas= " + ddlFormaCejas.SelectedItem + ", Tamaño de cejas= " + ddlTamañoCejas.SelectedItem + ", Color de ojos= " + ddlColorOjos.SelectedItem + ", Forma de ojos= " + ddlFormaOjos.SelectedItem + ", Tamaño de ojos= " + ddlTamañoOjos.SelectedItem + ", Raíz naríz= " + ddlRaizNariz.SelectedItem + ", Dorso naríz= " + ddlDorsoNariz.SelectedItem + ", Ancho naríz= " + ddlAnchoNariz.SelectedItem + ", Base naríz= " + ddlBaseNariz.SelectedItem + ", Altura naríz= " + ddlAlturaNariz.SelectedItem + ", Tamaño de boca= " + ddlTamañoBoca.SelectedItem + ", Comisuras boca= " + ddlComisurasBoca.SelectedItem + ", Espesor de labios= " + ddlEspesorLabios.SelectedItem + ", Naso labial= " + ddlNasoLabial.SelectedItem + ", Prominencia labial= " + ddlProminenciaLabial.SelectedItem + ", Tipo de mentón= " + ddlTipoMenton.SelectedItem + ", Forma de mentón= " + ddlFormaMenton.SelectedItem + ", Inclinación de mentón= " + ddlInclinacionMenton.SelectedItem + ", Forma de oreja= " + ddlFormaOreja.SelectedItem + ", Original oreja= " + ddlOriginalOreja.SelectedItem + ", Superior hélix= " + ddlSuperiorHelix.SelectedItem + ", Posterior hélix= " + ddlPosteriorHelix.SelectedItem + ", Adherencia hélix= " + ddlAdherenciaHelix.SelectedItem + ", Contorno lóbulo= " + ddlContornoLobulo.SelectedItem + ", Adherencia lóbulo= " + ddlAdherenciaLobulo.SelectedItem + ", Particularidad lóbulo= " + ddlParticularidadLobulo.SelectedItem + ", Dimensión lóbulo= " + ddlDimensionLobulo.SelectedItem + ", Tipo de sangre= " + ddlTipoSangre.SelectedItem + ", Etnia= " + ddlFactarSangre.SelectedItem + ", Anteojos= " + ddlAnteojos.SelectedItem + ", Estatura= " + txtEstatura.Text + ", Peso= " + txtPeso.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                

                    DesactivarControles();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }

        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde Media filiación", int.Parse(Session["IdModuloBitacora"].ToString()));
            
           Response.Redirect("PNLDatosPrincipales.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Modificar" + "&ID_MUNICIPIO_CARPETA=" + Session["ID_MUNICIPIO_CARPETA"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_PERTENENCIA_SOCIAL=" + Session["ID_PERTENENCIA_SOCIAL"].ToString() + "&ID_INFO_FINANCIERA=" + Session["ID_INFO_FINANCIERA"].ToString() + "&ID_INFO_ODONTOLOGICA=" + Session["ID_INFO_ODONTOLOGICA"].ToString() + "&ID_DISCAPACIDADES=" + Session["ID_DISCAPACIDADES"].ToString() + "&ID_OTRA_INFO=" + Session["ID_OTRA_INFO"].ToString() + "&ID_CAUSALES=" + Session["ID_CAUSALES"].ToString());
            
        }




        void cargarMediaFiliacion()
        {


            SqlCommand sql = new SqlCommand("PNL_CargarMediaFiliacion  " + ID_MEDIA_FILIACION.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ddlOfendido.SelectedValue = dr["IdPersona"].ToString();
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
                ddlRaizNariz.SelectedValue = dr["IdRaizNariz"].ToString();
                ddlEspesorLabios.SelectedValue = dr["IdRaizNariz"].ToString();
                ddlTamañoBoca.SelectedValue = dr["IdTamañoBoca"].ToString();
                ddlComisurasBoca.SelectedValue = dr["IdComisurasBoca"].ToString();
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
                ddlTieneBigote.SelectedValue = dr["IdBigote"].ToString();

                ddlColorBigote.SelectedValue = dr["IdColorBigote"].ToString();
                ddlTipoBigote.SelectedValue = dr["IdTipoBigote"].ToString();

                ddlTieneBarba.SelectedValue = dr["IdBarba"].ToString();

                ddlColorBarba.SelectedValue = dr["IdColorBarba"].ToString();
                ddlTipoBarba.SelectedValue = dr["IdTipoBarba"].ToString();
                ddlPomulo.SelectedValue = dr["IdPomulo"].ToString();


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

        void DesactivarControles()
        {
            ddlComplecion.Enabled=false;
            ddlColorPiel.Enabled=false;
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
            ddlTieneBigote.Enabled = false;
            ddlTipoBigote.Enabled = false;
            ddlColorBigote.Enabled = false;
            ddlTieneBarba.Enabled = false;
            ddlColorBarba.Enabled = false;
            ddlTipoBarba.Enabled = false;
            ddlPomulo.Enabled = false;
            cmdGuardar.Enabled = false;
        
        }

        protected void ddlTieneBigote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTieneBigote.SelectedValue.ToString() == "1")
            {
                ddlColorBigote.Enabled = true;
                ddlTipoBigote.Enabled = true;
            }
            else {
                ddlColorBigote.Enabled = false;
                ddlTipoBigote.Enabled = false;
            }
        }

        protected void ddlTieneBarba_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTieneBarba.SelectedValue.ToString() == "1")
            {
                ddlColorBarba.Enabled = true;
                ddlTipoBarba.Enabled = true;
            }
            else
            {
                ddlColorBarba.Enabled = false;
                ddlTipoBarba.Enabled = false;
            }
        }
    }
}