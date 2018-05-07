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
    public partial class LugarHechos : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                HookOnFocus(this.Page as Control);
                ScriptManager.RegisterStartupScript(
                this,
                typeof(LugarHechos),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                //--------
                Session["ID_LUGAR_HECHOS"] = Request.QueryString["ID_LUGAR_HECHOS"];
               
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                lblArbol.Text = Session["lblArbol"].ToString();
                GMap1.Add(new GMapUI());

                GMapUIOptions options = new GMapUIOptions();
                options.maptypes_hybrid = false;
                options.keyboard = false;
                options.maptypes_physical = false;
                options.zoom_scrollwheel = false;

                GMap1.Add(new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl, new GControlPosition(GControlPosition.position.Top_Right)));
                GMap1.setCenter(new GLatLng(23.736819471992295, -99.14335536956787), 13);
                GMap1.enableGKeyboardHandler = true;

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
                if (Session["INICIAR_CARPETA"] == null)
                {
                    Session["INICIAR_CARPETA"] = "";
                }

                Session["ID_ESTADO_RAC"].ToString();
                Session["ID_ESTADO_NUC"].ToString();
                Session["ID_ESTADO_NAC"].ToString();
                Session["ID_ESTADO_NUM"].ToString();
                
                cargarFecha();
                //CARGAR FECHA DE INICIO Y HORA DE INICIO
                SqlCommand sqlFechaInicio = new SqlCommand("CargarFechaInicioExpedienteRobo ", Data.CnnCentral);
                sqlFechaInicio.CommandType = CommandType.StoredProcedure;
                sqlFechaInicio.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                sqlFechaInicio.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.Int);

                sqlFechaInicio.Parameters["@IdCarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
                sqlFechaInicio.Parameters["@IdMunicipioCarpeta"].Value = int.Parse(Session["IdMunicipio"].ToString());

                SqlDataReader drFechaInicio = sqlFechaInicio.ExecuteReader();
                if (drFechaInicio.HasRows)
                {
                    drFechaInicio.Read();
                    txtFechaInicio.Text = drFechaInicio["FechaInicio"].ToString();
                }
                drFechaInicio.Close();


                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR LUGAR DE LOS HECHOS";    
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    cmdDelito.Enabled = false;
                    try{
                    PGJ.CargaCombo(ddlTipoLugar, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                    PGJ.CargaComboFiltrado(ddlMunicipio, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=1 and Id_Estdo=28");
                    //cargarAgregarLugarHechos();
                    ddlTipoLugar.Items.Insert(0, "--SELECCIONE--");
                    ddlMunicipio.Items.Insert(0, "--SELECCIONE--");
                    ddlLocalidad.Items.Insert(0, "--SELECCIONE--");
                    ddlColonia.Items.Insert(0, "--SELECCIONE--");
                    ddlCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlYcalle.Items.Insert(0, "--SELECCIONE--");

                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("LugarHechos.aspx?&op=Agregar");
                    }
                }
                else if (Session["op"].ToString() == "Modificar")
                {

                    //El Policia Investigador no puede modificar
                    if (Session["ID_PUESTO"].ToString() == "16" || Session["ID_PUESTO"].ToString() == "8")
                    {
                        cmdGuardar.Visible = false;
                    }

                    lblOperacion.Text = "MODIFICAR LUGAR DE LOS HECHOS";
                    cmdDelito.Enabled = true;
                    //try
                    //{
                        PGJ.CargaCombo(ddlTipoLugar, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                        PGJ.CargaComboFiltrado(ddlMunicipio, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=1 and Id_Estdo=28");
                        cargarLugarHechos();
                        llamarMapa();

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Lugar de Hechos IdLugarHechos=" + ID_LUGAR_HECHOS.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                    //}
                    //catch (Exception ex)
                    //{
                    //    Response.Redirect("LugarHechos.aspx?ID_LUGAR_HECHOS=" + Session["ID_LUGAR_HECHOS"].ToString() + "&op=Modificar");
                    //}
                    
                    
                }

                if (Session["op"].ToString() == "Agregar" && Session["INICIAR_CARPETA"].ToString() == "1")
                {
                    //INICIO-ocultando el menu cuando inicia carpeta

                    HyperLink linkRac = this.Page.Master.FindControl("hRac") as HyperLink;
                    linkRac.Text = "";
                    linkRac.Visible = false;
                    linkRac.Enabled = false;
                    linkRac.NavigateUrl = "#";

                    HyperLink linkDerivada = this.Page.Master.FindControl("hDerivada") as HyperLink;
                    linkDerivada.Text = "";
                    linkDerivada.Visible = false;
                    linkDerivada.Enabled = false;
                    linkDerivada.NavigateUrl = "#";

                    HyperLink linkNuc = this.Page.Master.FindControl("hlSec") as HyperLink;
                    linkNuc.Text = "";
                    linkNuc.Visible = false;
                    linkNuc.Enabled = false;
                    linkNuc.NavigateUrl = "#";

                    HyperLink linkEstadistica = this.Page.Master.FindControl("hEstadistica") as HyperLink;
                    linkEstadistica.Text = "";
                    linkEstadistica.Visible = false;
                    linkEstadistica.Enabled = false;
                    linkEstadistica.NavigateUrl = "#";

                    HyperLink linkBusqueda = this.Page.Master.FindControl("hBusquedaPersonasNSJP") as HyperLink;
                    linkBusqueda.Text = "";
                    linkBusqueda.Visible = false;
                    linkBusqueda.Enabled = false;
                    linkBusqueda.NavigateUrl = "#";

                    HyperLink linkBusquedaPNL = this.Page.Master.FindControl("hBusquedaPNL") as HyperLink;
                    linkBusquedaPNL.Text = "";
                    linkBusquedaPNL.Visible = false;
                    linkBusquedaPNL.Enabled = false;
                    linkBusquedaPNL.NavigateUrl = "#";

                    HyperLink linkEstadisticaNUC = this.Page.Master.FindControl("hEstadisticaNUC") as HyperLink;
                    linkEstadisticaNUC.Text = "";
                    linkEstadisticaNUC.Visible = false;
                    linkEstadisticaNUC.Enabled = false;
                    linkEstadisticaNUC.NavigateUrl = "#";

                    HyperLink linkReportes = this.Page.Master.FindControl("HyperLinkEsta") as HyperLink;
                    linkReportes.Text = "";
                    linkReportes.Visible = false;
                    linkReportes.Enabled = false;
                    linkReportes.NavigateUrl = "#";

                    HyperLink linkCS = this.Page.Master.FindControl("hCerrarSesion") as HyperLink;
                    linkCS.Text = "";
                    linkCS.Visible = false;
                    linkCS.Enabled = false;
                    linkCS.NavigateUrl = "#";

                    //FIN-ocultando el menu cuando inicia carpeta
                }

            }

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
            try {
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            
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
            else if (lblArbol.Text == "7")
            {
                Response.Redirect("NUM_ACUERDOS.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
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

        string Valor;
        protected void cmdGuardar_Click(object sender, EventArgs e)
        {

            lblError.Text = "";

            //valida fecha de inicio y hechos
            SqlCommand sqlValidar = new SqlCommand("ValidarFechaVehiculo ", Data.CnnCentral);
            sqlValidar.CommandType = CommandType.StoredProcedure;
            sqlValidar.Parameters.Add("@FechaInicio", SqlDbType.DateTime);
            sqlValidar.Parameters.Add("@FechaHecho", SqlDbType.DateTime);

            sqlValidar.Parameters["@FechaInicio"].Value = DateTime.Parse(txtFechaInicio.Text);
            sqlValidar.Parameters["@FechaHecho"].Value = DateTime.Parse(txtFecha.Text);

            SqlDataReader drValida = sqlValidar.ExecuteReader();
            if (drValida.HasRows)
            {
                drValida.Read();
                Valor = drValida["Valor"].ToString();

            }
            drValida.Close();

            if (Valor == "0")
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('LA FECHA DE HECHOS NO PUEDE SER MAYOR A LA FECHA DE INICIO DE LA CARPETA.')", true);
            }

            if (ddlTipoLugar.SelectedValue.ToString() == "--SELECCIONE--") //TIPO DE LUGAR
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA TIPO DE LUGAR OBLIGATORIO.')", true);
            }
            if (ddlMunicipio.SelectedValue.ToString() == "--SELECCIONE--") //MUNICIPIO
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA MUNICIPIO OBLIGATORIO.')", true);
            }
            if (ddlLocalidad.SelectedValue.ToString() == "--SELECCIONE--") //LOCALIDAD
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA LOCALIDAD OBLIGATORIO.')", true);
            }
            if (ddlColonia.SelectedValue.ToString() == "--SELECCIONE--") //COLONIA
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA COLONIA OBLIGATORIO.')", true);
            }
            if (ddlCalle.SelectedValue.ToString() == "--SELECCIONE--") //CALLE
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CALLE OBLIGATORIO.')", true);
            }
            if (ddlEntreCalle.SelectedValue.ToString() == "--SELECCIONE--") //ENTRE CALLE
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA ENTRE CALLE OBLIGATORIO.')", true);
            }
            if (ddlYcalle.SelectedValue.ToString() == "--SELECCIONE--") //Y CALLE
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA Y CALLE OBLIGATORIO.')", true);
            }

            if (lblError.Text == "")
            {
                try
                {
                    if (Session["op"].ToString() == "Agregar")
                    {
                        PGJ.InsertaLugarhechos(int.Parse(IdCarpeta.Text), DateTime.Parse(txtFecha.Text), txtHora.Text, short.Parse(ddlTipoLugar.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), int.Parse(ddlLocalidad.SelectedValue.ToString()), int.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, txtLatitud.Text, txtLongitud.Text, txtReferencias.Text, short.Parse(Session["IdMunicipio"].ToString()));
                        consultaIdLugarHechos();
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Lugar de Hechos" + " IdCarpeta= " + IdCarpeta.Text + " IdLugarHechos=" + ID_LUGAR_HECHOS.Text + " Fecha de Hechos: " + txtFecha.Text + " Hora: " + txtHora.Text + " Tipo de Lugar: " + ddlTipoLugar.SelectedItem + " Municipio: " + ddlMunicipio.SelectedItem + " Localidad: " + ddlLocalidad.SelectedItem + " Colonia: " + ddlColonia.SelectedItem + " Calle: " + ddlCalle.SelectedItem + " Entre Calle: " + ddlEntreCalle.SelectedItem + " Y Calle: " + ddlYcalle.SelectedItem + " Numero: " + txtNumero.Text + " Manzana: " + txtManzana.Text + " Lote: " + txtLote.Text + " Lataitud: " + txtLatitud.Text + " Longitud: " + txtLongitud.Text + " Referencias: " + txtReferencias.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                        Response.Redirect("Delito.aspx?ID_LUGAR_HECHOS=" + ID_LUGAR_HECHOS.Text + "&op=Agregar");
                    }
                    else if (Session["op"].ToString() == "Modificar")
                    {
                        PGJ.ActualizaLugarhechos(int.Parse(ID_LUGAR_HECHOS.Text), DateTime.Parse(txtFecha.Text), txtHora.Text, short.Parse(ddlTipoLugar.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), int.Parse(ddlLocalidad.SelectedValue.ToString()), int.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, txtLatitud.Text, txtLongitud.Text, txtReferencias.Text);

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Lugar de Hechos" + " IdCarpeta= " + Session["ID_CARPETA"] + " IdLugarHechos=" + ID_LUGAR_HECHOS.Text + " Fecha de Hechos: " + txtFecha.Text + " Hora: " + txtHora.Text + " Tipo de Lugar: " + ddlTipoLugar.SelectedItem + " Municipio: " + ddlMunicipio.SelectedItem + " Localidad: " + ddlLocalidad.SelectedItem + " Colonia: " + ddlColonia.SelectedItem + " Calle: " + ddlCalle.SelectedItem + " Entre Calle: " + ddlEntreCalle.SelectedItem + " Y Calle: " + ddlYcalle.SelectedItem + " Numero: " + txtNumero.Text + " Manzana: " + txtManzana.Text + " Lote: " + txtLote.Text + " Lataitud: " + txtLatitud.Text + " Longitud: " + txtLongitud.Text + " Referencias: " + txtReferencias.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                    }


                    //string fulladdress = string.Format("{0}.{1}.{2}.{3}", ddlCalle.SelectedItem.Text, ddlMunicipio.SelectedItem.Text, "TAMAULIPAS", "MEXICO");
                    ////string skey = ConfigurationManager.AppSettings["googlemaps.subgurim.net"];
                    //GeoCode geocode;
                    //geocode = GMap1.getGeoCodeRequest(fulladdress);
                    //var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
                    //GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
                    //var oMarker = new Subgurim.Controles.GMarker(glatlng);
                    //GMap1.Add(oMarker);

                    //txtLongitud.Text = glatlng.lng.ToString();
                    //txtLatitud.Text = glatlng.lat.ToString();

                    lblEstatus.Text = "DATOS GUARDADOS";
                    cmdGuardar.Enabled = false;
                    cmdDelito.Enabled = true;
                    desactivarBotones();
                }
                catch (Exception ex)
                {
                    lblEstatus.Text = ex.Message;
                    lblEstatus1.Text = "INTENTELO NUEVAMENTE";
                }
            }

        }


        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlMunicipio.SelectedValue.ToString() == "--SELECCIONE--") //TIPO DE LUGAR
            {
             
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, "--SELECCIONE--");
                ddlLocalidad.DataBind();

                //DEBERIA LLENAR LOS OTROS COMBOS SOLAMENTE CON UN VALOR POR DEFAULT
                ddlColonia.Items.Clear();
                ddlColonia.Items.Insert(0, "--SELECCIONE--");
                ddlColonia.DataBind();

                ddlCalle.Items.Clear();
                ddlCalle.Items.Insert(0, "--SELECCIONE--");
                ddlCalle.DataBind();

                ddlEntreCalle.Items.Clear();
                ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                ddlEntreCalle.DataBind();

                ddlYcalle.Items.Clear();
                ddlYcalle.Items.Insert(0, "--SELECCIONE--");
                ddlYcalle.DataBind();
            }
            else
            {
                Session["ID_MUNICIPIO"] = ddlMunicipio.SelectedValue.ToString();
                consultaMunicipioLocalidad();


                //DEBERIA LLENAR LOS OTROS COMBOS SOLAMENTE CON UN VALOR POR DEFAULT
                ddlColonia.Items.Clear();
                ddlColonia.Items.Insert(0, "--SELECCIONE--");
                ddlColonia.DataBind();

                ddlCalle.Items.Clear();
                ddlCalle.Items.Insert(0, "--SELECCIONE--");
                ddlCalle.DataBind();

                ddlEntreCalle.Items.Clear();
                ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                ddlEntreCalle.DataBind();

                ddlYcalle.Items.Clear();
                ddlYcalle.Items.Insert(0, "--SELECCIONE--");
                ddlYcalle.DataBind();
            }
            //Session["ID_MUNICIPIO"] = ddlMunicipio.SelectedValue.ToString();
            //consultaMunicipioLocalidad();
            //PGJ.CargaComboFiltrado(ddlLocalidad, "Cat_Localidad", "Id_Lcldd", "Lcldd", "Id_Pais=1 and Id_Estdo=28" + " and Id_Mncpio=" + ddlMunicipio.SelectedValue.ToString());            
        }

        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlLocalidad.SelectedValue.ToString() == "--SELECCIONE--")
            {
                //ddlColonia.Items.Insert(0, "--SELECCIONE--");
                //ddlCalle.Items.Insert(0, "--SELECCIONE--");
                //ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                //ddlYcalle.Items.Insert(0, "--SELECCIONE--");

                //DEBERIA LLENAR LOS OTROS COMBOS SOLAMENTE CON UN VALOR POR DEFAULT
                ddlColonia.Items.Clear();
                ddlColonia.Items.Insert(0, "--SELECCIONE--");
                ddlColonia.DataBind();

                ddlCalle.Items.Clear();
                ddlCalle.Items.Insert(0, "--SELECCIONE--");
                ddlCalle.DataBind();

                ddlEntreCalle.Items.Clear();
                ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                ddlEntreCalle.DataBind();

                ddlYcalle.Items.Clear();
                ddlYcalle.Items.Insert(0, "--SELECCIONE--");
                ddlYcalle.DataBind();
            }
            else
            {
                Session["ID_LOCALIDAD"] = ddlLocalidad.SelectedValue.ToString();
                consultaLocalidadColonia();
                consultaLocalidadCalle();
                consultaLocalidadEntreCalle();
                consultaLocalidadYCalle();
            }

            //Session["ID_LOCALIDAD"] = ddlLocalidad.SelectedValue.ToString();
            //consultaLocalidadColonia();
            //consultaLocalidadCalle();
            //consultaLocalidadEntreCalle();
            //consultaLocalidadYCalle();

            //PGJ.CargaComboFiltrado(ddlColonia, "Cat_Colonia", "Id_Clnia", "Clnia", "Id_Pais=1 and Id_Estdo=28" + " and Id_Mncpio=" + ddlMunicipio.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidad.SelectedValue.ToString());
            //PGJ.CargaComboFiltrado(ddlCalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=1 and Id_Estdo=28" + " and Id_Mncpio=" + ddlMunicipio.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidad.SelectedValue.ToString());
            //PGJ.CargaComboFiltrado(ddlEntreCalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=1 and Id_Estdo=28" + " and Id_Mncpio=" + ddlMunicipio.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidad.SelectedValue.ToString());
            //PGJ.CargaComboFiltrado(ddlYcalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=1 and Id_Estdo=28" + " and Id_Mncpio=" + ddlMunicipio.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidad.SelectedValue.ToString());
        }

        void cargarAgregarLugarHechos()
        {

            Session["ID_MUNICIPIO"] = "41";
            ddlMunicipio.SelectedValue = Session["ID_MUNICIPIO"].ToString();
            consultaMunicipioLocalidad();
            Session["ID_LOCALIDAD"] = 388;
            ddlLocalidad.SelectedValue = "388";
            ddlColonia.SelectedValue = "153";
            consultaLocalidadColonia();
            ddlCalle.SelectedValue = "2874";
            consultaLocalidadCalle();
            ddlEntreCalle.SelectedValue = "2874";
            consultaLocalidadEntreCalle();
            ddlYcalle.SelectedValue = "2874";
            consultaLocalidadYCalle();
        }


        void cargarLugarHechos()
        {
            SqlCommand sql = new SqlCommand("cargarLugarHechos " + int.Parse(Session["ID_LUGAR_HECHOS"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_LUGAR_HECHOS.Text = dr["ID_LUGAR_HECHOS"].ToString();
               // Data.IdLugarHechos = Convert.ToInt32(ID_LUGAR_HECHOS.Text);

                txtFecha.Text = dr["FECHA_HECHOS"].ToString();
                txtHora.Text = dr["HORA_HECHOS"].ToString();
                ddlTipoLugar.SelectedValue = dr["ID_TIPO_LUGAR"].ToString();

                Session["ID_MUNICIPIO"] = dr["ID_MUNICIPIO"].ToString();
                ddlMunicipio.SelectedValue = Session["ID_MUNICIPIO"].ToString();
                consultaMunicipioLocalidad();


                Session["ID_LOCALIDAD"] = dr["ID_LOCALIDAD"].ToString();
                ddlLocalidad.SelectedValue = Session["ID_LOCALIDAD"].ToString();

                ddlColonia.SelectedValue = dr["ID_COLONIA"].ToString();
                consultaLocalidadColonia();

                ddlCalle.SelectedValue = dr["ID_CALLE"].ToString();
                consultaLocalidadCalle();

                ddlEntreCalle.SelectedValue = dr["ID_ENTRE_CALLE"].ToString();
                consultaLocalidadEntreCalle();

                ddlYcalle.SelectedValue = dr["ID_Y_CALLE"].ToString();
                consultaLocalidadYCalle();

                txtNumero.Text = dr["NO_EXTERIOR"].ToString();
                txtManzana.Text = dr["MANZANA"].ToString();
                txtLote.Text = dr["LOTE"].ToString();
                txtLatitud.Text = dr["LATITUD"].ToString();
                txtLongitud.Text = dr["LONGITUD"].ToString();
                txtReferencias.Text = dr["REFERENCIAS"].ToString();

            }
            dr.Close();
        }

        void consultaMunicipioLocalidad()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var localidad = from c in dc.consultaMunicipioLocalidad(1, 28, short.Parse(Session["ID_MUNICIPIO"].ToString()))
                            select new { c.ID_LCLDD, c.LCLDD };
            ddlLocalidad.DataSource = localidad;
            ddlLocalidad.DataValueField = "ID_LCLDD";
            ddlLocalidad.DataTextField = "LCLDD";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, "--SELECCIONE--");
        }

        void consultaLocalidadColonia()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var colonia = from c in dc.consultaLocalidadColonia(1, 28, short.Parse(Session["ID_MUNICIPIO"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                          select new { c.ID_CLNIA, c.CLNIA };
            ddlColonia.DataSource = colonia;
            ddlColonia.DataValueField = "ID_CLNIA";
            ddlColonia.DataTextField = "CLNIA";
            ddlColonia.DataBind();
            ddlColonia.Items.Insert(0, "--SELECCIONE--");
        }

        void consultaLocalidadCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(1, 28, short.Parse(Session["ID_MUNICIPIO"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlCalle.DataSource = calle;
            ddlCalle.DataValueField = "ID_CLLE";
            ddlCalle.DataTextField = "CLLE";
            ddlCalle.DataBind();
            ddlCalle.Items.Insert(0, "--SELECCIONE--");
        }

        void consultaLocalidadEntreCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(1, 28, short.Parse(Session["ID_MUNICIPIO"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlEntreCalle.DataSource = calle;
            ddlEntreCalle.DataValueField = "ID_CLLE";
            ddlEntreCalle.DataTextField = "CLLE";
            ddlEntreCalle.DataBind();
            ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
        }

        void consultaLocalidadYCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var calle = from c in dc.consultaLocalidadCalle(1, 28, short.Parse(Session["ID_MUNICIPIO"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
                        select new { c.ID_CLLE, c.CLLE };
            ddlYcalle.DataSource = calle;
            ddlYcalle.DataValueField = "ID_CLLE";
            ddlYcalle.DataTextField = "CLLE";
            ddlYcalle.DataBind();
            ddlYcalle.Items.Insert(0, "--SELECCIONE--");
        }

        void desactivarBotones()
        {
            txtFecha.Enabled = false;
            txtHora.Enabled = false;
            ddlTipoLugar.Enabled = false;
            ddlMunicipio.Enabled = false;
            ddlColonia.Enabled = false;
            //consultaLocalidadColonia();
            ddlLocalidad.Enabled = false;
            ddlCalle.Enabled = false;
            ddlEntreCalle.Enabled = false;
            ddlYcalle.Enabled = false;
           // consultaLocalidadYCalle();

            txtNumero.Enabled = false;
            txtManzana.Enabled = false;
            txtLote.Enabled = false;
            txtLatitud.Enabled = false;
            txtLongitud.Enabled = false;
            txtReferencias.Enabled = false;
        }



        protected void cmdMapa_Click(object sender, EventArgs e)
        {
            GMap1.Visible = true;
            lblMapa.Visible = true;
            GMap1.resetMarkers();
            //string fulladdress = string.Format("{0}.{1}.{2}.{3}", ddlCalle.SelectedItem.Text, ddlMunicipio.SelectedItem.Text, "TAMAULIPAS", "MEXICO");
            ////string skey = ConfigurationManager.AppSettings["googlemaps.subgurim.net"];
            //GeoCode geocode;
            //geocode = GMap1.getGeoCodeRequest(fulladdress);
            //var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
            //GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            //var oMarker = new Subgurim.Controles.GMarker(glatlng);
            //GMap1.Add(oMarker);


            var glatlng = new Subgurim.Controles.GLatLng(double.Parse(txtLatitud.Text), double.Parse(txtLongitud.Text));
            GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            var oMarker = new Subgurim.Controles.GMarker(glatlng);
            GMap1.Add(oMarker);

        }

        protected void cmdDelito_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Delito.aspx?ID_LUGAR_HECHOS=" + ID_LUGAR_HECHOS.Text + "&op=Agregar"); 
        }



        void consultaIdLugarHechos()
        {
            SqlCommand sql = new SqlCommand("consultaIdLugarHechos", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_LUGAR_HECHOS.Text = dr["ID_LUGAR_HECHOS"].ToString();
            //}
            dr.Close();
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

    }
}