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
   
    public partial class Datos : System.Web.UI.Page
    {
        private const string SCRIPT_DOFOCUS =
           @"window.setTimeout('DoFocus()', 1);
                function DoFocus()
                {
                    try {
                        document.getElementById('REQUEST_LASTFOCUS').focus();
                    } catch (ex) {}
                }";
        Data PGJ = new Data();
        public static string tipoActor = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                HookOnFocus(this.Page as Control);
                
                ScriptManager.RegisterStartupScript(
                this,
                typeof(Datos),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                

                

                GMap1.Add(new GMapUI());

                GMapUIOptions options = new GMapUIOptions();
                options.maptypes_hybrid = false;
                options.keyboard = false;
                options.maptypes_physical = false;
                options.zoom_scrollwheel = false;

                GMap1.Add(new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl, new GControlPosition(GControlPosition.position.Top_Right)));
                GMap1.setCenter(new GLatLng(23.736819471992295, -99.14335536956787), 13);
                GMap1.enableGKeyboardHandler = true;


                lblArbol.Text = Session["lblArbol"].ToString();
                Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];              
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();               
                //consultaPusoDisposicion();
                cargarFecha();
                Panel2.Visible = false;

               

                if (Session["op"].ToString() == "Agregar")
                {
                    if (lblArbol.Text == "3")
                    {
                        lblOperacion.Text = "AGREGAR SOLICITANTE";
                    }

                    lblOperacion.Text = "AGREGAR DENUNCIANTE";
                    cmdAlias.Enabled = false;
                    cmdMedio.Enabled = false;

                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                    ID_TIPO_ACTOR.Text = Convert.ToString(1);

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
                    lblVivo.Visible = false;
                    rbVivo.Visible = false;
                    lblDecIm.Visible = false;
                    lblDecTes.Visible = false;
                    txtDeclaracion.Visible = false;
                    try
                    {
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        PGJ.CargaCombo(ddlPusoDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");
                        cargarAgregarPersona();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?&op=Agregar");
                    }
                }
                else if (Session["op"].ToString() == "Modificar")
                {

                    //El Policia Investigador no puede modificar
                    if (Session["ID_PUESTO"].ToString() == "16" || Session["ID_PUESTO"].ToString() == "8")
                    {
                        cmdGu.Visible = false;
                    }

                    if (lblArbol.Text == "3")
                    {
                        lblOperacion.Text = "CONSULTAR SOLICITANTE";
                    }

                    tipoActor = "denunciante";
                    lblOperacion.Text = "CONSULTAR DENUNCIANTE";
                    cmdAlias.Enabled = true;
                    cmdMedio.Enabled = true;                  
                    lblVivo.Visible = false;
                    rbVivo.Visible = false;
                    lblDecIm.Visible = false;
                    lblDecTes.Visible = false;
                    txtDeclaracion.Visible = false;
                    try
                    {
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        cargarPersona();
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto el Denunciante IdPersona=" + ID_PERSONA.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=Modificar");
                    }
                    
                }
                else if (Session["op"].ToString() == "AgregarOf")
                {
                    lblOperacion.Text = "AGREGAR OFENDIDO";
                    cmdAlias.Enabled = false;
                    cmdMedio.Enabled = false;
                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString(); 
                    ID_TIPO_ACTOR.Text = Convert.ToString(2);
                    lblVivo.Visible = true;
                    rbVivo.Visible = true;
                    lblDetenido.Visible = false;
                    rbDetenido.Visible = false;
                    lblDecIm.Visible = false;
                    lblDecTes.Visible = false;
                    txtDeclaracion.Visible = false;
                    try {
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                    PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                    PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                    PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                    PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                    PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                    cargarAgregarPersona();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?&op=AgregarOf");
                    }
                }
                else if (Session["op"].ToString() == "ModificarOf")
                {
                    lblOperacion.Text = "CONSULTAR OFENDIDO";
                    tipoActor = "ofendido";
                    cmdAlias.Enabled = true;
                    cmdMedio.Enabled = true;
                    
                    lblVivo.Visible = false;
                    rbVivo.Visible = false;
                    lblDetenido.Visible = false;
                    rbDetenido.Visible = false;
                    lblDecIm.Visible = false;
                    lblDecTes.Visible = false;
                    txtDeclaracion.Visible = false;
                    try
                    {
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        cargarPersona();
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto el Ofendido IdPersona=" + ID_PERSONA.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=ModificarOf");
                    }
                    
                }
                else if (Session["op"].ToString() == "AgregarPre")
                {
                    if (lblArbol.Text == "3")
                    {
                        lblOperacion.Text = "AGREGAR INVITADO";
                    }
                    lblOperacion.Text = "AGREGAR IMPUTADO";
                    cmdAlias.Enabled = false;
                    cmdMedio.Enabled = false;
                    lblDetenido.Visible = false;
                    rbDetenido.Visible = false;
                    
                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                    
                    ID_TIPO_ACTOR.Text = Convert.ToString(3);
                    lblVivo.Visible = true;
                    rbVivo.Visible = true;
                    lblDisposicion.Visible = true;
                    ddlPusoDisposicion.Visible = true;
                    lblDecIm.Visible = true;
                    lblDecTes.Visible = false;
                    txtDeclaracion.Visible = true;

                    if (Session["IdModulo"].ToString() == "2" || Session["IdModulo"].ToString() == "5" || lblArbol.Text == "2")
                    {
                        Paneldetenido.Visible = false;
                    }
                    else
                    {
                        Paneldetenido.Visible = true;
                    }

                   


                    try{
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        cargarAgregarPersona();

                        if (Session["IdModulo"].ToString() != "2" || Session["IdModulo"].ToString() != "5")
                        {
                            PGJ.CargaCombo(ddlEstadoDetenido, "CAT_ESTADO_DETENIDO", "ID_ESTDO_DTNDO", "ESTDO_DTNDO");
                            PGJ.CargaCombo(ddlPusoDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");
                            PGJ.CargaCombo(ddlTipoLugar, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                            PGJ.CargaComboFiltrado(ddlMunicipioLH, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=1 and Id_Estdo=28");
                            cargarAgregarLugarDetencion();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?&op=AgregarPre");
                    }
                }
                else if (Session["op"].ToString() == "ModificarPre")
                {
                    if (lblArbol.Text == "3")
                    {
                        lblOperacion.Text = "CONSULTAR INVITADO";
                    }


                    lblOperacion.Text = "CONSULTAR IMPUTADO";
                    tipoActor = "imputado";
                    cmdAlias.Enabled = true;
                    cmdMedio.Enabled = true;
                    lblDetenido.Visible = false;
                    rbDetenido.Visible = false;
                   
                    lblVivo.Visible = true;
                    rbVivo.Visible = true;
                    lblDisposicion.Visible = true;
                    lblDecIm.Visible = true;
                    lblDecTes.Visible = false;
                    txtDeclaracion.Visible = true;

                    Paneldetenido.Visible = false;
                   

                    try
                    {
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        ddlPusoDisposicion.Visible = true;
                        cargarPersona();

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto el Imputado IdPersona=" + ID_PERSONA.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            

                        if (rbDetenido.SelectedValue == "1")
                        {
                            PGJ.CargaCombo(ddlEstadoDetenido, "CAT_ESTADO_DETENIDO", "ID_ESTDO_DTNDO", "ESTDO_DTNDO");
                            PGJ.CargaCombo(ddlPusoDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");
                            PGJ.CargaCombo(ddlTipoLugar, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                            PGJ.CargaComboFiltrado(ddlMunicipioLH, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=1 and Id_Estdo=28");
                            consultaIdLugarDetencion();
                            cargarLugarDetencion();
                            CargarPersonaDetenidaPI();
                            consultaIDDetencion();
                            Ifoto.Visible=true;
                            Ifoto.ImageUrl = "fotoDetenido.ashx?Id=" + ID_PERSONA.Text;
                            //llamarMapa();
                           

                            PanelLugarDetencion.Visible = true;
                            PanelDetencion.Visible = true;
                        }


                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=ModificarPre");
                    }
                    
                }
                else if (Session["op"].ToString() == "AgregarTes")
                {
                    lblOperacion.Text = "AGREGAR TESTIGO";
                    cmdAlias.Enabled = false;
                    cmdMedio.Enabled = false;
                    lblDetenido.Visible = false;
                    rbDetenido.Visible = false;

                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                    ID_TIPO_ACTOR.Text = Convert.ToString(4);
                    lblVivo.Visible = true;
                    rbVivo.Visible = true;
                    lblDisposicion.Visible = false;
                    ddlPusoDisposicion.Visible = false;
                    lblDecIm.Visible = false;
                    lblDecTes.Visible = true;
                    txtDeclaracion.Visible = true;
                    try{
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                    PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                    PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                    PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                    PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                    PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                    cargarAgregarPersona();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?&op=AgregarTes");
                    }
                }
                else if (Session["op"].ToString() == "ModificarTes")
                {
                    lblOperacion.Text = "CONSULTAR TESTIGO";
                    tipoActor = "testigo";
                    cmdAlias.Enabled = true;
                    cmdMedio.Enabled = true;
                    lblDetenido.Visible = false;
                    rbDetenido.Visible = false;
                    
                    lblVivo.Visible = true;
                    rbVivo.Visible = true;
                    lblDisposicion.Visible = false;
                    ddlPusoDisposicion.Visible = false;
                    lblDecIm.Visible = false;
                    lblDecTes.Visible = true;
                    txtDeclaracion.Visible = true;
                    try
                    {
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        cargarPersona();
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto el Testigo IdPersona=" + ID_PERSONA.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=ModificarTes");
                    }
                    
                }
               
            }
        }

        // Paso 2 para evitar que se pierda el valor del tabindex de los controles despues de un postback
        private void HookOnFocus(Control CurrentControl)
        {

            if ((CurrentControl is TextBox) ||
                (CurrentControl is DropDownList) ||
                (CurrentControl is CheckBox) ||
                (CurrentControl is ListBox) ||
                (CurrentControl is Button) ||
                (CurrentControl is RadioButton))

                (CurrentControl as WebControl).Attributes.Add("onfocus", "try{document.getElementById('__LASTFOCUS').value=this.id}catch(e) {}");

            if (CurrentControl.HasControls())

                foreach (Control CurrentChildControl in CurrentControl.Controls)
                    HookOnFocus(CurrentChildControl);
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblArbol.Text == "2")
                {

                    Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString());
                }

                else if (lblArbol.Text == "3")
                {
                    Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
                }

                else if (lblArbol.Text == "8")
                {
                    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
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
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            
            //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
        }

        protected void cmdMedio_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("MedioContacto.aspx?ID_PERSONA=" + ID_PERSONA.Text + "&op=Agregar");      
        }

        protected void cmdAlias_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Alias.aspx?ID_PERSONA=" + ID_PERSONA.Text + "&op=Agregar" + "&tipoActor=" + tipoActor);
            //Response.Redirect("Alias.aspx?ID_PERSONA=" + ID_PERSONA.Text + "&op=Agregar");     
            
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


        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO"] = ddlEstado.SelectedValue.ToString();
            consultaEstadoMunicipio();
            //  PGJ.CargaComboFiltrado(ddlMunicipio, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=" + ddlPais.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstado.SelectedValue.ToString());
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            // PGJ.CargaComboFiltrado(ddlEstado, "Cat_Estado", "Id_Estdo", "Estdo", "Id_Pais=" + ddlPais.SelectedValue.ToString());
            Session["ID_PAIS"] = ddlPais.SelectedValue.ToString();
            consultaPaisEstado();

        }

        protected void ddlPaisDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_PAIS_DOM"] = ddlPaisDom.SelectedValue.ToString();
            consultaPaisEstadoDom();
            //PGJ.CargaComboFiltrado(ddlEstadoDom, "Cat_Estado", "Id_Estdo", "Estdo", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString());
        }

        protected void ddlEstadoDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO_DOM"] = ddlEstadoDom.SelectedValue.ToString();
            consultaEstadoMunicipioDom();
            //PGJ.CargaComboFiltrado(ddlMunicipioDom, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString());
        }

        protected void ddlMunicipioDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MUNICIPIO_DOM"] = ddlMunicipioDom.SelectedValue.ToString();
            consultaMunicipioLocalidad();
            // PGJ.CargaComboFiltrado(ddlLocalidadDom, "Cat_Localidad", "Id_Lcldd", "Lcldd", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString());
        }

        protected void ddlLocalidadDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_LOCALIDAD"] = ddlLocalidadDom.SelectedValue.ToString();
            consultaLocalidadColonia();
            consultaLocalidadCalle();
            consultaLocalidadEntreCalle();
            consultaLocalidadYCalle();
            //PGJ.CargaComboFiltrado(ddlColonia, "Cat_Colonia", "Id_Clnia", "Clnia", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
            //PGJ.CargaComboFiltrado(ddlCalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
            //PGJ.CargaComboFiltrado(ddlEntreCalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
            //PGJ.CargaComboFiltrado(ddlYcalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
        }

        void consultaIdPersonaMax()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var fecha = from c in dc.consultaIdPersonaMax(txtPaterno.Text, txtMaterno.Text, txtNombre.Text)
                        select c;
            foreach (var propiedad in fecha)
            {
                ID_PERSONA.Text = propiedad.ID_PERSONA.ToString();
            }
        }


        protected void cmdGu_Click(object sender, EventArgs e)
        {

            Byte[] foto;
            try
            {

                if (Session["op"].ToString() == "Agregar" || Session["op"].ToString() == "AgregarOf" || Session["op"].ToString() == "AgregarPre" || Session["op"].ToString() == "AgregarTes")
                {
                    PGJ.InsertaPersona(txtPaterno.Text, txtMaterno.Text, txtNombre.Text, short.Parse(ddlSexo.SelectedValue.ToString()), txtFecNaci.Text, short.Parse(ddlNacionalidad.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), txtRFC.Text, txtCurp.Text,txtDeclaracion.Text, short.Parse(Session["IdMunicipio"].ToString()));
                    consultaIdPersonaMax();

                    PGJ.InsertaPersonaDomicilio(int.Parse(ID_PERSONA.Text), short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), int.Parse(ddlLocalidadDom.SelectedValue.ToString()), int.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, short.Parse(Session["IdMunicipio"].ToString()));
                   
                  
                    PGJ.InsertaCarpetaPersona(int.Parse(ID_CARPETA.Text), int.Parse(ID_PERSONA.Text), short.Parse(ddlEstadoCivil.SelectedValue.ToString()), short.Parse(ddlEscolaridad.SelectedValue.ToString()), short.Parse(ddlOcupacion.SelectedValue.ToString()), short.Parse(ddlIdentificacion.SelectedValue.ToString()), txtFolio.Text, short.Parse(rbEscribir.SelectedValue.ToString()), short.Parse(rbVivo.SelectedValue.ToString()), short.Parse(rbDetenido.SelectedValue.ToString()), short.Parse(ID_TIPO_ACTOR.Text), short.Parse(Session["IdMunicipio"].ToString()), 0);

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Persona " + "IdCarpeta=" + ID_CARPETA.Text + " IdTipoActor=" + ID_TIPO_ACTOR.Text + " Nombre: " + txtNombre.Text + " Paterno: " + txtPaterno.Text + " Materno: " + txtMaterno.Text + " ORIGINARIO Nacionalidad: " + ddlNacionalidad.SelectedItem + " Pais: " + ddlPais.SelectedItem + " Estado: " + ddlEstado.SelectedItem + " Municipio: " + ddlMunicipio.SelectedItem + " DOMICILIO Pais: " + ddlPaisDom.SelectedItem + " Estado: " + ddlEstadoDom.SelectedItem + " Municipio: " + ddlMunicipioDom.SelectedItem + " Localidad: " + ddlLocalidadDom.SelectedItem + " Colonia: " + ddlColonia.SelectedItem + " Calle: " + ddlCalle.SelectedItem + " Entre Calle: " + ddlEntreCalle.SelectedItem + " Y Calle:" + ddlYcalle.SelectedItem + " Numero: " + txtNumero.Text + " Manzana: " + txtManzana.Text + " Lote: " + txtLote + " GENERALES " + " Sexo:" + ddlSexo.SelectedItem + " Fecha de Nacimiento: " + txtFecNaci.Text + " Estado Civil: " + ddlEstadoCivil.SelectedItem + " Sabe Leer y Escribir: " + rbEscribir.SelectedItem + " Escolaridad: " + ddlEscolaridad.SelectedItem + " Ocupacion:" + ddlOcupacion.SelectedItem + " Identificacion: " + ddlIdentificacion.SelectedItem + " Folio: " + txtFolio.Text + " Curp: " + txtCurp.Text + " Rfc: " + txtRFC.Text + " Vivo: " + rbVivo.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));
            

                    //INSERTAMOS LUGAR DE LA DETENCION Y DETENCION SI EXISTE DETENCION
                    if (rbDetenido.SelectedValue == "1")
                    {
                        PGJ.InsertaLugarDetencion(int.Parse(ID_CARPETA.Text), DateTime.Parse(txtFecha.Text), txtHora.Text, short.Parse(ddlTipoLugar.SelectedValue.ToString()), short.Parse(ddlMunicipioLH.SelectedValue.ToString()), int.Parse(ddlLocalidadLH.SelectedValue.ToString()), int.Parse(ddlColoniaLH.SelectedValue.ToString()), int.Parse(ddlCalleLH.SelectedValue.ToString()), int.Parse(ddlEntreCalleLH.SelectedValue.ToString()), int.Parse(ddlYcalleLH.SelectedValue.ToString()), txtNumeroLH.Text, txtManzanaLH.Text, txtLoteLH.Text, txtLatitud.Text, txtLongitud.Text, txtReferencias.Text, short.Parse(Session["IdMunicipio"].ToString()));
                        consultaIdLugarDetencion();

                        // Comprobamos que existe IMAGEN y que no esta vacio
                        if ((ImagenFile.PostedFile != null) && (ImagenFile.PostedFile.ContentLength > 0))
                        {
                            Ifoto.Visible = true;
                            //obtener archivos subidos
                            HttpPostedFile ImgFile = ImagenFile.PostedFile;
                            // crear el array
                            // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                            foto = new Byte[ImagenFile.PostedFile.ContentLength];
                            //cargado en una matriz de bytes
                            ImgFile.InputStream.Read(foto, 0, ImagenFile.PostedFile.ContentLength);
                        }
                        else
                        {
                            foto = new Byte[0];
                        }

                        if (OptProcedimientoDetencion.SelectedValue == "3")
                        {
                            OptSupuestoFlagrancia.SelectedValue = "1";
                        }
                        if (rbLibertadInvestigacion.SelectedValue == "0")
                        {
                            rbMotivoLiberacion.SelectedValue = "1";
                        }

                        //AQUI SE INSERTA LA INFORMACION DE LA DETENCION                                                     
                        PGJ.InsertarDetencionDatos(int.Parse(ID_PERSONA.Text), int.Parse(Session["IdUsuario"].ToString()), int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ID_LUGAR_DETENCION.Text), "", "", txtTiempoTraslado.Text, "", "", "", "", "", txtHora.Text, DateTime.Parse(txtFecha.Text), 0, short.Parse(ddlEstadoDetenido.SelectedValue), foto, "", "", "", 0, 0, "", txtDescripcionHechos.Text, "", short.Parse(ddlPusoDisposicion.SelectedValue), short.Parse(OptProcedimientoDetencion.SelectedValue), short.Parse(OptSupuestoFlagrancia.SelectedValue), short.Parse(rbLibertadInvestigacion.SelectedValue), short.Parse(rbMotivoLiberacion.SelectedValue));
                        consultaIDDetencion();

                        PGJ.ActualizaPusoDisposicionCarpetaPersona(short.Parse(ddlPusoDisposicion.SelectedValue), int.Parse(ID_PERSONA.Text));

                        //Muestra la Imagen recien Guardada
                        Ifoto.ImageUrl = "fotoDetenido.ashx?Id=" + ID_PERSONA.Text;
                    }


                }
                else if (Session["op"].ToString() == "Modificar" || Session["op"].ToString() == "ModificarOf" || Session["op"].ToString() == "ModificarPre" || Session["op"].ToString() == "ModificarTes")
                {
                    PGJ.ActualizaCarpetaPersona(int.Parse(ID_PERSONA.Text), short.Parse(ddlEstadoCivil.SelectedValue.ToString()), short.Parse(ddlEscolaridad.SelectedValue.ToString()), short.Parse(ddlOcupacion.SelectedValue.ToString()), short.Parse(ddlIdentificacion.SelectedValue.ToString()), txtFolio.Text, short.Parse(rbEscribir.SelectedValue.ToString()), short.Parse(rbVivo.SelectedValue.ToString()), short.Parse(rbDetenido.SelectedValue.ToString()),0);
                    PGJ.ActualizaPersona(int.Parse(ID_PERSONA.Text), txtPaterno.Text, txtMaterno.Text, txtNombre.Text, short.Parse(ddlSexo.SelectedValue.ToString()), txtFecNaci.Text, short.Parse(ddlNacionalidad.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), txtRFC.Text, txtCurp.Text,txtDeclaracion.Text);
                    PGJ.ActualizaPersonaDomicilio(int.Parse(ID_PERSONA.Text), short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), int.Parse(ddlLocalidadDom.SelectedValue.ToString()), int.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text);

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualizar Persona " + "IdCarpeta=" + Session["ID_CARPETA"] + " IdTipoActor=" + ID_TIPO_ACTOR.Text + " Nombre: " + txtNombre.Text + " Paterno: " + txtPaterno.Text + " Materno: " + txtMaterno.Text + " ORIGINARIO Nacionalidad: " + ddlNacionalidad.SelectedItem + " Pais: " + ddlPais.SelectedItem + " Estado: " + ddlEstado.SelectedItem + " Municipio: " + ddlMunicipio.SelectedItem + " DOMICILIO Pais: " + ddlPaisDom.SelectedItem + " Estado: " + ddlEstadoDom.SelectedItem + " Municipio: " + ddlMunicipioDom.SelectedItem + " Localidad: " + ddlLocalidadDom.SelectedItem + " Colonia: " + ddlColonia.SelectedItem + " Calle: " + ddlCalle.SelectedItem + " Entre Calle: " + ddlEntreCalle.SelectedItem + " Y Calle:" + ddlYcalle.SelectedItem + " Numero: " + txtNumero.Text + " Manzana: " + txtManzana.Text + " Lote: " + txtLote + " GENERALES " + " Sexo:" + ddlSexo.SelectedItem + " Fecha de Nacimiento: " + txtFecNaci.Text + " Estado Civil: " + ddlEstadoCivil.SelectedItem + " Sabe Leer y Escribir: " + rbEscribir.SelectedItem + " Escolaridad: " + ddlEscolaridad.SelectedItem + " Ocupacion:" + ddlOcupacion.SelectedItem + " Identificacion: " + ddlIdentificacion.SelectedItem + " Folio: " + txtFolio.Text + " Curp: " + txtCurp.Text + " Rfc: " + txtRFC.Text + " Vivo: " + rbVivo.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));
            

                    //AQUI SE ACTUALIZA LA INFORMACION DE LA DETENCION  y EL LUGAR DE LA DETENCION
                    if (rbDetenido.SelectedValue == "1")
                    {
                        PGJ.ActualizaLugarDetencion(int.Parse(ID_LUGAR_DETENCION.Text), DateTime.Parse(txtFecha.Text), txtHora.Text, short.Parse(ddlTipoLugar.SelectedValue.ToString()), short.Parse(ddlMunicipioLH.SelectedValue.ToString()), int.Parse(ddlLocalidadLH.SelectedValue.ToString()), int.Parse(ddlColoniaLH.SelectedValue.ToString()), int.Parse(ddlCalleLH.SelectedValue.ToString()), int.Parse(ddlEntreCalleLH.SelectedValue.ToString()), int.Parse(ddlYcalleLH.SelectedValue.ToString()), txtNumeroLH.Text, txtManzanaLH.Text, txtLoteLH.Text, txtLatitud.Text, txtLongitud.Text, txtReferencias.Text);


                        if (OptProcedimientoDetencion.SelectedValue == "3")
                        {
                            OptSupuestoFlagrancia.SelectedValue = "1";
                        }
                        if (rbLibertadInvestigacion.SelectedValue == "0")
                        {
                            rbMotivoLiberacion.SelectedValue = "1";
                        }


                        PGJ.ModificarDetencionDatos(int.Parse(Session["ID_DETENCION"].ToString()), "", txtTiempoTraslado.Text, "", "", "", "", "", txtHora.Text, DateTime.Parse(txtFecha.Text), 0, short.Parse(ddlEstadoDetenido.SelectedValue), "", "", "", 0, 0, "", txtDescripcionHechos.Text, "", short.Parse(ddlPusoDisposicion.SelectedValue), short.Parse(OptProcedimientoDetencion.SelectedValue), short.Parse(OptSupuestoFlagrancia.SelectedValue), short.Parse(rbLibertadInvestigacion.SelectedValue), short.Parse(rbMotivoLiberacion.SelectedValue));
                        PGJ.ActualizaPusoDisposicionCarpetaPersona(short.Parse(ddlPusoDisposicion.SelectedValue), int.Parse(ID_PERSONA.Text));

                        // Comprobamos que existe IMAGEN y que no esta vacio PARA MODIFICARLA
                        if ((ImagenFile.PostedFile != null) && (ImagenFile.PostedFile.ContentLength > 0))
                        {
                            Ifoto.Visible = true;
                            //obtener archivos subidos
                            HttpPostedFile ImgFile = ImagenFile.PostedFile;
                            // crear el array
                            // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                            foto = new Byte[ImagenFile.PostedFile.ContentLength];
                            //cargado en una matriz de bytes
                            ImgFile.InputStream.Read(foto, 0, ImagenFile.PostedFile.ContentLength);

                            PGJ.ActualizarImagenDetenidoPI(int.Parse(ID_PERSONA.Text), foto);

                            //Muestra la Imagen recien Guardada
                            Ifoto.ImageUrl = "fotoDetenido.ashx?Id=" + ID_PERSONA.Text;
                        }
                    }


                }
                lblEstatus.Text = "DATOS GUARDADOS";
                cmdGu.Enabled = false;

                cmdAlias.Enabled = true;
                cmdMedio.Enabled = true;
                desactivarBotones();

                if (Session["op"].ToString() == "Agregar")
                {
                    Panel2.Visible = true;
                    cmdReg.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        void cargarAgregarPersona()
        {
            ddlNacionalidad.SelectedValue = "31";
            Session["ID_PAIS"] = 1;
            ddlPais.SelectedValue = Session["ID_PAIS"].ToString();
            consultaPaisEstado();
            Session["ID_ESTADO"] = 28;
            ddlEstado.SelectedValue = Session["ID_ESTADO"].ToString();
            consultaEstadoMunicipio();
            ddlMunicipio.SelectedValue = "41";
            Session["ID_PAIS_DOM"] = 1;
            ddlPaisDom.SelectedValue = Session["ID_PAIS_DOM"].ToString();
            consultaPaisEstadoDom();
            Session["ID_ESTADO_DOM"] = 28;
            ddlEstadoDom.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
            consultaEstadoMunicipioDom();
            Session["ID_MUNICIPIO_DOM"] = "41";
            ddlMunicipioDom.SelectedValue = Session["ID_MUNICIPIO_DOM"].ToString();
            consultaMunicipioLocalidad();
            Session["ID_LOCALIDAD"] = 388;
            ddlLocalidadDom.SelectedValue = "388";
            ddlColonia.SelectedValue = "153";
            consultaLocalidadColonia();
            ddlCalle.SelectedValue = "2874";
            consultaLocalidadCalle();
            ddlEntreCalle.SelectedValue = "2874";
            consultaLocalidadEntreCalle();
            ddlYcalle.SelectedValue = "2874";
            consultaLocalidadYCalle();
            ddlSexo.SelectedValue = "0";
            ddlEstadoCivil.SelectedValue = "0";
            ddlEscolaridad.SelectedValue = "0";
            ddlOcupacion.SelectedValue = "0";
            ddlIdentificacion.SelectedValue = "0";
            rbEscribir.SelectedValue = "1";
            rbVivo.SelectedValue = "1";
            rbDetenido.SelectedValue = "0";
           
            
            ddlPusoDisposicion.SelectedValue = "0";

        }

        void cargarPersona()
        {
            SqlCommand sql = new SqlCommand("cargarPersona " + int.Parse(Session["ID_PERSONA"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_PERSONA.Text= dr["ID_PERSONA"].ToString();
               // Data.IdPersona = Convert.ToInt32(ID_PERSONA.Text);

                ID_TIPO_ACTOR.Text = dr["ID_TIPO_ACTOR"].ToString();

                txtNombre.Text = dr["NOMBRE"].ToString();
                txtPaterno.Text = dr["PATERNO"].ToString();
                txtMaterno.Text = dr["MATERNO"].ToString();
                txtDeclaracion.Text = dr["DECLARACION"].ToString();
                
                ddlNacionalidad.SelectedValue = dr["ID_NACIONALIDAD"].ToString();

                Session["ID_PAIS"] = dr["ID_PAIS"].ToString();
                ddlPais.SelectedValue = Session["ID_PAIS"].ToString();
                consultaPaisEstado();

                Session["ID_ESTADO"] = dr["ID_ESTADO"].ToString();
                ddlEstado.SelectedValue = Session["ID_ESTADO"].ToString();
                consultaEstadoMunicipio();
                ddlMunicipio.SelectedValue = dr["ID_MUNICIPIO"].ToString();

                Session["ID_PAIS_DOM"] = dr["ID_PAIS_DOM"].ToString();
                ddlPaisDom.SelectedValue = Session["ID_PAIS_DOM"].ToString();
                consultaPaisEstadoDom();

                Session["ID_ESTADO_DOM"] = dr["ID_ESTADO_DOM"].ToString();
                ddlEstadoDom.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
                consultaEstadoMunicipioDom();

                Session["ID_MUNICIPIO_DOM"] = dr["ID_MUNICIPIO_DOM"].ToString();
                ddlMunicipioDom.SelectedValue = Session["ID_MUNICIPIO_DOM"].ToString();
                consultaMunicipioLocalidad();

                Session["ID_LOCALIDAD"] = dr["ID_LOCALIDAD"].ToString();
                ddlLocalidadDom.SelectedValue = dr["ID_LOCALIDAD"].ToString();


                ddlColonia.SelectedValue = dr["ID_COLONIA"].ToString();
                consultaLocalidadColonia();

                ddlCalle.SelectedValue = dr["ID_CALLE"].ToString();
                consultaLocalidadCalle();

                ddlEntreCalle.SelectedValue = dr["ID_ENTRE_CALLE"].ToString();
                consultaLocalidadEntreCalle();

                ddlYcalle.SelectedValue = dr["ID_Y_CALLE"].ToString();
                consultaLocalidadYCalle();

                txtNumero.Text = dr["NUMERO"].ToString();
                txtManzana.Text = dr["MANZANA"].ToString();
                txtLote.Text = dr["LOTE"].ToString();
                txtRFC.Text = dr["RFC"].ToString();
                txtCurp.Text = dr["CURP"].ToString();
                ddlSexo.SelectedValue = dr["ID_SEXO"].ToString();
                txtFecNaci.Text = dr["FECHA_NACIMIENTO"].ToString();
                ddlEstadoCivil.SelectedValue = dr["ID_ESTADO_CIVIL"].ToString();
                ddlEscolaridad.SelectedValue = dr["ID_ESCOLARIDAD"].ToString();
                ddlOcupacion.SelectedValue = dr["ID_OCUPACION"].ToString();
                ddlIdentificacion.SelectedValue = dr["ID_IDENTIFICACION"].ToString();
                txtFolio.Text = dr["FOLIO"].ToString();
                txtCurp.Text = dr["CURP"].ToString();
                txtRFC.Text = dr["RFC"].ToString();

                rbEscribir.SelectedValue = dr["LEER_ESCRIBIR"].ToString();
                rbVivo.SelectedValue = dr["VIVO"].ToString();
                rbDetenido.SelectedValue = dr["DETENIDO"].ToString();
                ddlPusoDisposicion.SelectedValue = dr["ID_PUSO_DISPOSICION"].ToString();
            }
            dr.Close();
        }

      
        void consultaPaisEstado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEstado.DataSource = estado;
            ddlEstado.DataValueField = "ID_ESTDO";
            ddlEstado.DataTextField = "ESTDO";
            ddlEstado.DataBind();
        }

        void consultaPaisEstadoDom()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS_DOM"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEstadoDom.DataSource = estado;
            ddlEstadoDom.DataValueField = "ID_ESTDO";
            ddlEstadoDom.DataTextField = "ESTDO";
            ddlEstadoDom.DataBind();
        }

        void consultaEstadoMunicipio()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS"].ToString()), short.Parse(Session["ID_ESTADO"].ToString()))
                            select new { c.ID_MNCPIO, c.MNCPIO };
            ddlMunicipio.DataSource = municipio;
            ddlMunicipio.DataValueField = "ID_MNCPIO";
            ddlMunicipio.DataTextField = "MNCPIO";
            ddlMunicipio.DataBind();
        }

        void consultaEstadoMunicipioDom()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()))
                            select new { c.ID_MNCPIO, c.MNCPIO };
            ddlMunicipioDom.DataSource = municipio;
            ddlMunicipioDom.DataValueField = "ID_MNCPIO";
            ddlMunicipioDom.DataTextField = "MNCPIO";
            ddlMunicipioDom.DataBind();
        }

        void consultaMunicipioLocalidad()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var localidad = from c in dc.consultaMunicipioLocalidad(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()))
                            select new { c.ID_LCLDD, c.LCLDD };
            ddlLocalidadDom.DataSource = localidad;
            ddlLocalidadDom.DataValueField = "ID_LCLDD";
            ddlLocalidadDom.DataTextField = "LCLDD";
            ddlLocalidadDom.DataBind();
        }

        void consultaLocalidadColonia()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var colonia = from c in dc.consultaLocalidadColonia(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                          select new { c.ID_CLNIA, c.CLNIA };
            ddlColonia.DataSource = colonia;
            ddlColonia.DataValueField = "ID_CLNIA";
            ddlColonia.DataTextField = "CLNIA";
            ddlColonia.DataBind();
        }

        void consultaLocalidadCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlCalle.DataSource = calle;
            ddlCalle.DataValueField = "ID_CLLE";
            ddlCalle.DataTextField = "CLLE";
            ddlCalle.DataBind();
        }

        void consultaLocalidadEntreCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlEntreCalle.DataSource = calle;
            ddlEntreCalle.DataValueField = "ID_CLLE";
            ddlEntreCalle.DataTextField = "CLLE";
            ddlEntreCalle.DataBind();
        }

        void consultaLocalidadYCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlYcalle.DataSource = calle;
            ddlYcalle.DataValueField = "ID_CLLE";
            ddlYcalle.DataTextField = "CLLE";
            ddlYcalle.DataBind();
        }

        void desactivarBotones()
        {
            txtNombre.Enabled = false;
            txtPaterno.Enabled = false;
            txtMaterno.Enabled = false;
            ddlNacionalidad.Enabled = false;
            ddlPais.Enabled = false;
            ddlEstado.Enabled = false;
            ddlMunicipio.Enabled = false;
            ddlPaisDom.Enabled = false;
            ddlEstadoDom.Enabled = false;
            ddlMunicipioDom.Enabled = false;
            ddlLocalidadDom.Enabled = false;
            ddlColonia.Enabled = false;
            ddlCalle.Enabled = false;
            ddlEntreCalle.Enabled = false;
            ddlYcalle.Enabled = false;
            txtNumero.Enabled = false;
            txtManzana.Enabled = false;
            txtLote.Enabled = false;
            txtRFC.Enabled = false;
            txtCurp.Enabled = false;
            ddlSexo.Enabled = false;
            txtFecNaci.Enabled = false;
            ddlEstadoCivil.Enabled = false;
            ddlEscolaridad.Enabled = false;
            ddlOcupacion.Enabled = false;
            ddlIdentificacion.Enabled = false;
            txtFolio.Enabled = false;
            txtCurp.Enabled = false;
            txtRFC.Enabled = false;
            rbEscribir.Enabled = false;
            rbVivo.Enabled = false;
            rbDetenido.Enabled = false;


            //lugar detencion
            txtFecha.Enabled = false;
            txtHora.Enabled = false;
            ddlTipoLugar.Enabled = false;
            ddlMunicipioLH.Enabled = false;
            ddlLocalidadLH.Enabled = false;
            ddlColoniaLH.Enabled = false;
            ddlCalleLH.Enabled = false;
            ddlEntreCalleLH.Enabled = false;
            ddlYcalleLH.Enabled = false;
            txtNumeroLH.Enabled = false;
            txtManzanaLH.Enabled = false;
            txtLoteLH.Enabled = false;
            txtReferencias.Enabled = false;

            //Lugar Detencion
            ddlEstadoDetenido.Enabled = false;
            ddlPusoDisposicion.Enabled = false;
            txtTiempoTraslado.Enabled = false;
            OptProcedimientoDetencion.Enabled = false;
            OptSupuestoFlagrancia.Enabled = false;
            rbLibertadInvestigacion.Enabled = false;
            rbMotivoLiberacion.Enabled = false;
            txtDescripcionHechos.Enabled = false;

        }

        protected void ImgSi1_Click(object sender, ImageClickEventArgs e)
        {
            try 
            {
            if (Session["op"].ToString() == "Agregar")
            {
                PGJ.InsertaPersona(txtPaterno.Text, txtMaterno.Text, txtNombre.Text, short.Parse(ddlSexo.SelectedValue.ToString()), txtFecNaci.Text, short.Parse(ddlNacionalidad.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), txtRFC.Text, txtCurp.Text, txtDeclaracion.Text, short.Parse(Session["IdMunicipio"].ToString()));
                consultaIdPersonaMax();

                PGJ.InsertaPersonaDomicilio(int.Parse(ID_PERSONA.Text), short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), int.Parse(ddlLocalidadDom.SelectedValue.ToString()), int.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, short.Parse(Session["IdMunicipio"].ToString()));
                PGJ.InsertaCarpetaPersona(int.Parse(ID_CARPETA.Text), int.Parse(ID_PERSONA.Text), short.Parse(ddlEstadoCivil.SelectedValue.ToString()), short.Parse(ddlEscolaridad.SelectedValue.ToString()), short.Parse(ddlOcupacion.SelectedValue.ToString()), short.Parse(ddlIdentificacion.SelectedValue.ToString()), txtFolio.Text, short.Parse(rbEscribir.SelectedValue.ToString()), short.Parse(rbVivo.SelectedValue.ToString()), short.Parse(rbDetenido.SelectedValue.ToString()), 2, short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlPusoDisposicion.SelectedValue.ToString()));

                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Persona Denunciante igual que Ofendido " + "IdCarpeta=" + ID_CARPETA.Text + " IdTipoActor=" + ID_TIPO_ACTOR.Text + " Nombre: " + txtNombre.Text + " Paterno: " + txtPaterno.Text + " Materno: " + txtMaterno.Text + " ORIGINARIO Nacionalidad: " + ddlNacionalidad.SelectedItem + " Pais: " + ddlPais.SelectedItem + " Estado: " + ddlEstado.SelectedItem + " Municipio: " + ddlMunicipio.SelectedItem + " DOMICILIO Pais: " + ddlPaisDom.SelectedItem + " Estado: " + ddlEstadoDom.SelectedItem + " Municipio: " + ddlMunicipioDom.SelectedItem + " Localidad: " + ddlLocalidadDom.SelectedItem + " Colonia: " + ddlColonia.SelectedItem + " Calle: " + ddlCalle.SelectedItem + " Entre Calle: " + ddlEntreCalle.SelectedItem + " Y Calle:" + ddlYcalle.SelectedItem + " Numero: " + txtNumero.Text + " Manzana: " + txtManzana.Text + " Lote: " + txtLote + " GENERALES " + " Sexo:" + ddlSexo.SelectedItem + " Fecha de Nacimiento: " + txtFecNaci.Text + " Estado Civil: " + ddlEstadoCivil.SelectedItem + " Sabe Leer y Escribir: " + rbEscribir.SelectedItem + " Escolaridad: " + ddlEscolaridad.SelectedItem + " Ocupacion:" + ddlOcupacion.SelectedItem + " Identificacion: " + ddlIdentificacion.SelectedItem + " Folio: " + txtFolio.Text + " Curp: " + txtCurp.Text + " Rfc: " + txtRFC.Text + " Vivo: " + rbVivo.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            }

            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() );
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() );
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() );
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() );
            }

            else if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }

            Panel2.Visible = false;
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        protected void ImgNo1_Click(object sender, ImageClickEventArgs e)
        {
            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() );
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() );
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() );
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() );
            }

            else if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }
        }

        void consultaPusoDisposicion()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPusoDisposicion()
                         select new { c.ID_PUSO_DISPOSICION, c.PUSO_DISPOSICION };
            ddlPusoDisposicion.DataSource = estado;
            ddlPusoDisposicion.DataValueField = "ID_PUSO_DISPOSICION";
            ddlPusoDisposicion.DataTextField = "PUSO_DISPOSICION";
            ddlPusoDisposicion.DataBind();
        }

        protected void rbDetenido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDetenido.SelectedValue == "0")
            {
                PanelLugarDetencion.Visible = false;
                PanelDetencion.Visible = false;
            }
            if (rbDetenido.SelectedValue == "1")
            {
                PanelLugarDetencion.Visible = true;
                PanelDetencion.Visible = true;
            }
        }

        protected void OptProcedimientoDetencion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (OptProcedimientoDetencion.SelectedValue == "1")
            {
                lblSupuestoFlagrancia.Visible = true;
                OptSupuestoFlagrancia.Visible = true;
            }
            if (OptProcedimientoDetencion.SelectedValue == "3")
            {
                lblSupuestoFlagrancia.Visible = false;
                OptSupuestoFlagrancia.Visible = false;
            }

        }

        protected void rbLibertadInvestigacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbLibertadInvestigacion.SelectedValue == "0")
            {
                lblmotivoDetencion.Visible = false;
                rbMotivoLiberacion.Visible = false;
            }
            if (rbLibertadInvestigacion.SelectedValue == "1")
            {
                lblmotivoDetencion.Visible = true;
                rbMotivoLiberacion.Visible = true;
            }
        }

      

        
      
        //void consultaIdPersona()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdPersona", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_PERSONA.Text = dr["ID_PERSONA"].ToString();
        //    //}
        //    dr.Close();
        //}

        //void consultaIdCarpetaPersona()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdCarpetaPersona", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_PERSONA_CARPETA.Text = dr["ID_PERSONA_CARPETA"].ToString();
        //    //}
        //    dr.Close();
        //}

        //void consultaIdPersonaDomicilio()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdPersonaDomicilio", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_DOMICILIO.Text = dr["ID_DOMICILIO"].ToString();
        //    //}
        //    dr.Close();
        //}


        void consultaIdLugarDetencion()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(ID_LUGAR_DETENCION),1) as ID_LUGAR_DETENCION  From PGJ_LUGAR_DETENCION WHERE ID_CARPETA = " + Session["ID_CARPETA"].ToString(), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_LUGAR_DETENCION.Text = dr["ID_LUGAR_DETENCION"].ToString();
            Session["ID_LUGAR_DETENCION"] = ID_LUGAR_DETENCION.Text;

            //}
            dr.Close();
        }



        void cargarLugarDetencion()
        {
            SqlCommand sql = new SqlCommand("cargarLugarDetencion " + int.Parse(Session["ID_LUGAR_DETENCION"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_LUGAR_DETENCION.Text = dr["ID_LUGAR_DETENCION"].ToString();
                // Data.IdLugarHechos = Convert.ToInt32(ID_LUGAR_HECHOS.Text);

                txtFecha.Text = dr["FECHA_HECHOS"].ToString();
                txtHora.Text = dr["HORA_HECHOS"].ToString();
                ddlTipoLugar.SelectedValue = dr["ID_TIPO_LUGAR"].ToString();



                Session["ID_MUNICIPIO_LH"] = dr["ID_MUNICIPIO"].ToString();
                ddlMunicipioLH.SelectedValue = Session["ID_MUNICIPIO_LH"].ToString();
                consultaMunicipioLocalidadLH();


                Session["ID_LOCALIDAD_LH"] = dr["ID_LOCALIDAD"].ToString();
                ddlLocalidadLH.SelectedValue = Session["ID_LOCALIDAD_LH"].ToString();

                ddlColoniaLH.SelectedValue = dr["ID_COLONIA"].ToString();
                consultaLocalidadColoniaLH();

                ddlCalleLH.SelectedValue = dr["ID_CALLE"].ToString();
                consultaLocalidadCalleLH();

                ddlEntreCalleLH.SelectedValue = dr["ID_ENTRE_CALLE"].ToString();
                consultaLocalidadEntreCalleLH();

                ddlYcalleLH.SelectedValue = dr["ID_Y_CALLE"].ToString();
                consultaLocalidadYCalleLH();


                txtNumeroLH.Text = dr["NO_EXTERIOR"].ToString();
                txtManzanaLH.Text = dr["MANZANA"].ToString();
                txtLoteLH.Text = dr["LOTE"].ToString();
                txtLatitud.Text = dr["LATITUD"].ToString();
                txtLongitud.Text = dr["LONGITUD"].ToString();
                txtReferencias.Text = dr["REFERENCIAS"].ToString();

            }
            dr.Close();
        }


        public void llamarMapa()
        {
            double Longitud;
            //String x = txtLongitud.Text.ToString();
            // Longitud =  Convert.ToDouble(x);
            Longitud = double.Parse(txtLongitud.Text.ToString(), System.Globalization.NumberFormatInfo.InvariantInfo);
            // Longitud = double.Parse(txtLongitud.Text.ToString ());

            double Latitud;
            Latitud = double.Parse(txtLatitud.Text, System.Globalization.NumberFormatInfo.InvariantInfo);
            GMap1.Visible = true;
            lblMapa.Visible = true;
            GMap1.resetMarkers();



            if (Longitud > 0)
            {
                Longitud = Longitud * -1;
            }

            var glatlng = new Subgurim.Controles.GLatLng(Latitud, Longitud);
            GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            var oMarker = new Subgurim.Controles.GMarker(glatlng);
            GMap1.Add(oMarker);
        }

        void cargarAgregarLugarDetencion()
        {

            Session["ID_MUNICIPIO_LH"] = "41";
            ddlMunicipioLH.SelectedValue = Session["ID_MUNICIPIO_LH"].ToString();
            consultaMunicipioLocalidadLH();
            Session["ID_LOCALIDAD_LH"] = 388;
            ddlLocalidadLH.SelectedValue = "388";
            ddlColoniaLH.SelectedValue = "153";
            consultaLocalidadColoniaLH();
            ddlCalleLH.SelectedValue = "2874";
            consultaLocalidadCalleLH();
            ddlEntreCalleLH.SelectedValue = "2874";
            consultaLocalidadEntreCalleLH();
            ddlYcalleLH.SelectedValue = "2874";
            consultaLocalidadYCalleLH();
        }

      

        void consultaIDDetencion() 
        {
            //Seleccionamos el ID DETENCION
            PGJ.ConnectServer();
            SqlCommand comm1 = new SqlCommand("  SELECT MAX(ID_DETENCION) AS ID_DETENCION FROM PGJ_DETENCION WHERE ID_CARPETA =" + Session["ID_CARPETA"].ToString() , Data.CnnCentral);
            SqlDataReader dr1 = comm1.ExecuteReader();

            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    IdDetencion.Text = dr1["ID_DETENCION"].ToString();

                    Session["ID_DETENCION"] = IdDetencion.Text;
                }
                dr1.Close();
            }
        
        }

        protected string GMap1_Click(object s, GAjaxServerEventArgs e)
        {
            GMap1.resetMarkers();
            //Response.Write("Sus Coordenadas son: \r\n Latitud: " + e.point.lat + "\r\n" + "Logitud: " + e.point.lng);
            txtLongitud.Text = (string)e.point.lng.ToString();
            txtLatitud.Text = (string)e.point.lat.ToString();

            var glatlng = new Subgurim.Controles.GLatLng(double.Parse(txtLatitud.Text), double.Parse(txtLongitud.Text));
            GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            var oMarker = new Subgurim.Controles.GMarker(glatlng);
            GMap1.Add(oMarker);

            return default(string);
        }

        protected void cmdMapa_Click(object sender, EventArgs e)
        {
            GMap1.Visible = true;
            lblMapa.Visible = true;
            GMap1.resetMarkers();
        


            var glatlng = new Subgurim.Controles.GLatLng(double.Parse(txtLatitud.Text), double.Parse(txtLongitud.Text));
            GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            var oMarker = new Subgurim.Controles.GMarker(glatlng);
            GMap1.Add(oMarker);

        }

        protected void ddlMunicipioLH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MUNICIPIO_LH"] = ddlMunicipioLH.SelectedValue.ToString();
            consultaMunicipioLocalidadLH();
        }

        protected void ddlLocalidadLH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_LOCALIDAD_LH"] = ddlLocalidadLH.SelectedValue.ToString();
            consultaLocalidadColoniaLH();
            consultaLocalidadCalleLH();
            consultaLocalidadEntreCalleLH();
            consultaLocalidadYCalleLH();
        }
       

        void consultaMunicipioLocalidadLH()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var localidad = from c in dc.consultaMunicipioLocalidad(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()))
                            select new { c.ID_LCLDD, c.LCLDD };
            ddlLocalidadLH.DataSource = localidad;
            ddlLocalidadLH.DataValueField = "ID_LCLDD";
            ddlLocalidadLH.DataTextField = "LCLDD";
            ddlLocalidadLH.DataBind();
        }

        void consultaLocalidadColoniaLH()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var colonia = from c in dc.consultaLocalidadColonia(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
                          select new { c.ID_CLNIA, c.CLNIA };
            ddlColoniaLH.DataSource = colonia;
            ddlColoniaLH.DataValueField = "ID_CLNIA";
            ddlColoniaLH.DataTextField = "CLNIA";
            ddlColoniaLH.DataBind();
        }

        void consultaLocalidadCalleLH()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlCalleLH.DataSource = calle;
            ddlCalleLH.DataValueField = "ID_CLLE";
            ddlCalleLH.DataTextField = "CLLE";
            ddlCalleLH.DataBind();
        }

        void consultaLocalidadEntreCalleLH()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlEntreCalleLH.DataSource = calle;
            ddlEntreCalleLH.DataValueField = "ID_CLLE";
            ddlEntreCalleLH.DataTextField = "CLLE";
            ddlEntreCalleLH.DataBind();
        }

        void consultaLocalidadYCalleLH()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlYcalleLH.DataSource = calle;
            ddlYcalleLH.DataValueField = "ID_CLLE";
            ddlYcalleLH.DataTextField = "CLLE";
            ddlYcalleLH.DataBind();
        }

        protected void IBDetenidoSi_Click(object sender, ImageClickEventArgs e)
        {

                Paneldetenido.Visible = false;
                PanelLugarDetencion.Visible = true;
                PanelDetencion.Visible = true;
                rbDetenido.SelectedValue = "1";
            
        }

        protected void IBDetenidoNo_Click(object sender, ImageClickEventArgs e)
        {
                 Paneldetenido.Visible = false;
                PanelLugarDetencion.Visible = false;
                PanelDetencion.Visible = false;
                rbDetenido.SelectedValue = "0";
            
        }


        void CargarPersonaDetenidaPI()
        {
            SqlCommand sql1 = new SqlCommand("CargarPersonaDetenidaPI " + int.Parse(Session["ID_PERSONA"].ToString()), Data.CnnCentral);
            SqlDataReader dr1 = sql1.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();
                
                ddlEstadoDetenido.SelectedValue = dr1["ID_ESTADO_DETENIDO"].ToString();
                ddlPusoDisposicion.SelectedValue = dr1["DETENIDO_POR"].ToString();
                txtTiempoTraslado.Text = dr1["TIEMPO_TRANSLADO"].ToString();
                txtDescripcionHechos.Text = dr1["DESCRIPCION_HECHOS"].ToString();
                ddlEstadoDetenido.SelectedValue = dr1["ID_ESTADO_DETENIDO"].ToString();
                ddlPusoDisposicion.SelectedValue = dr1["DETENIDO_POR"].ToString();

                OptProcedimientoDetencion.SelectedValue = dr1["ID_PROCEDIMIENTO_DETENCION"].ToString();
                rbLibertadInvestigacion.SelectedValue = dr1["LIBERTAD_INVESTIGACION"].ToString();
               


                if (OptProcedimientoDetencion.SelectedValue == "1")
                {
                    lblSupuestoFlagrancia.Visible = true;
                    OptSupuestoFlagrancia.Visible = true;
                    OptSupuestoFlagrancia.SelectedValue = dr1["ID_SUPUESTO_FLAGRANCIA"].ToString();
                }
                if (OptProcedimientoDetencion.SelectedValue == "3")
                {
                    lblSupuestoFlagrancia.Visible = false;
                    OptSupuestoFlagrancia.Visible = false;
                    //OptSupuestoFlagrancia.SelectedValue = dr1["ID_SUPUESTO_FLAGRANCIA"].ToString();
                }


                if (rbLibertadInvestigacion.SelectedValue == "0")
                {
                    lblmotivoDetencion.Visible = false;
                    rbMotivoLiberacion.Visible = false;
                    //rbMotivoLiberacion.SelectedValue = dr1["ID_MOTIVO_LIBERACION"].ToString();
                }

                if (rbLibertadInvestigacion.SelectedValue == "1")
                {
                    lblmotivoDetencion.Visible = true;
                    rbMotivoLiberacion.Visible = true;
                    rbMotivoLiberacion.SelectedValue = dr1["ID_MOTIVO_LIBERACION"].ToString();
                }


                /*
                ddlPreferencia.SelectedValue = dr1["ID_PREFERENCIA_SEXUAL"].ToString();
                txtAsunto.Text = dr1["ASUNTO"].ToString();
                txtDirigidoA.Text = dr1["DIRIGIDO_A"].ToString();
                ddlParticipacion.SelectedValue = dr1["ID_PARTICIPACION"].ToString();
                ddlOperativo.SelectedValue = dr1["OPERATIVO"].ToString();
                txtAgentes.Text = dr1["AGENTES"].ToString();
                txtComandanteOperativo.Text = dr1["NOMBRE_COMANDANTE"].ToString();
                txtAutoridadDisp.Text = dr1["AUTORIDAD_PUESTO_DISPOSICION"].ToString();
                txtNombreRecibio.Text = dr1["NOMBRE_RECIBIO"].ToString();
                txtCargoRecibio.Text = dr1["CARGO_RECIBIO"].ToString();
                txtPuestaDisposicion.Text = dr1["LUGAR_PUESTA_DISPOSICION"].ToString();
                txtMotivoDetencion.Text = dr1["MOTIVO_DETENCION"].ToString();
                txtCausaNofirma.Text = dr1["CAUSA_NO_FIRMA"].ToString();
                 */
              

            }
            dr1.Close();
        }


    }
        
       
    
}