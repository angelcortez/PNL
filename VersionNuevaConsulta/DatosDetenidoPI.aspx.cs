using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Subgurim.Controles;

namespace AtencionTemprana
{
    public partial class DatosDetenidoPI1 : System.Web.UI.Page
    {

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                lblArbol.Text = Session["lblArbol"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                //GMap1.Add(new GMapUI());

                //GMapUIOptions options = new GMapUIOptions();
                //options.maptypes_hybrid = false;
                //options.keyboard = false;
                //options.maptypes_physical = false;
                //options.zoom_scrollwheel = false;

                //GMap1.Add(new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl, new GControlPosition(GControlPosition.position.Top_Right)));
                //GMap1.setCenter(new GLatLng(23.736819471992295, -99.14335536956787), 13);
                //GMap1.enableGKeyboardHandler = true;

               
                cargarFecha();
                

                if (Session["op"].ToString() == "Agregar")
                {
                    

                    lblOperacion.Text = "AGREGAR DETENIDO";
                    //cmdAlias.Enabled = false;
                    //cmdMedio.Enabled = false;
                    cmdSiguiente.Enabled = false;

                   
                    cargarImputado();

                    ID_TIPO_ACTOR.Text = Convert.ToString(3);

                    

                    //lblVivo.Visible = false;
                    //rbVivo.Visible = false;
                    try
                    {

                        //PGJ.CargaCombo(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd");
                        //PGJ.CargaCombo(ddlPais, "Cat_Pais", "Id_Pais", "Pais");
                        //PGJ.CargaCombo(ddlEstado, "CAT_ESTADO", "ID_ESTDO", "ESTDO");
                        //PGJ.CargaCombo(ddlMunicipio, "CAT_MUNICIPIO", "ID_MNCPIO", "MNCPIO");

                        //PGJ.CargaCombo(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais");
                        //PGJ.CargaCombo(ddlEstadoDom, "CAT_ESTADO", "ID_ESTDO", "ESTDO");
                        //PGJ.CargaCombo(ddlMunicipioDom, "CAT_MUNICIPIO", "ID_MNCPIO", "MNCPIO");
                        //PGJ.CargaCombo(ddlLocalidadDom, "CAT_LOCALIDAD", "ID_LCLDD", "LCLDD");
                        //PGJ.CargaCombo(ddlColoniaDom, "CAT_COLONIA", "ID_CLNIA", "CLNIA");
                        //PGJ.CargaCombo(ddlCalleDom, "CAT_CALLE", "ID_CLLE", "CLLE");
                        //PGJ.CargaCombo(ddlEntreCalleDom, "CAT_CALLE", "ID_CLLE", "CLLE");
                        //PGJ.CargaCombo(ddlYcalleDom, "CAT_CALLE", "ID_CLLE", "CLLE");
                        //CargarInfoCombosDom();


                        ////PGJ.CargaCombo(ddlTipoLugar, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                        ////PGJ.CargaComboFiltrado(ddlMunicipioLH, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=1 and Id_Estdo=28");
                        //cargarAgregarLugarHechos();

                        //PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        //PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        //PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        //PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        //PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        //PGJ.CargaCombo(ddlPusoDisposicion, "CAT_CORPORACION", "ID_CORPORACION", "CORPORACION");

                        PGJ.CargaCombo(ddlEstadoDetenido, "CAT_ESTADO_DETENIDO", "ID_ESTDO_DTNDO", "ESTDO_DTNDO");
                        //PGJ.CargaCombo(ddlPreferencia, "CAT_PREFERENCIA_SEXUAL", "ID_PREFERENCIA_SEXUAL", "PREFERENCIA_SEXUAL");
                        PGJ.CargaCombo(ddlParticipacion, "CAT_PARTICIPACION", "ID_PARTICIPACION", "PARTICIPACION");


                    }
                    catch (Exception ex)
                    {
                        if (Session["ID_PUESTO"].ToString() == "16")
                        {
                            Response.Redirect("CoordPoliciaInvestigador.aspx");
                        }
                        else if (Session["ID_PUESTO"].ToString() == "8")
                        {
                            Response.Redirect("PoliciaInvestigador.aspx");
                        }
                    }




                }
                else if (Session["op"].ToString() == "Modificar")
                {

                   
                    lblOperacion.Text = "MODIFICAR DETENIDO";
                    //cmdAlias.Enabled = true;
                    //cmdMedio.Enabled = true;
                    Ifoto.Visible = true;
                    //lblVivo.Visible = false;
                    //rbVivo.Visible = false;
                    cargarImputado();

                  
                    try
                    {
                        //PGJ.CargaCombo(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd");
                        //PGJ.CargaCombo(ddlPais, "Cat_Pais", "Id_Pais", "Pais");
                        //PGJ.CargaCombo(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais");
                        //PGJ.CargaCombo(ddlEstadoCivil, "CAT_ESTADO_CIVIL", "ID_ESTDO_CVL", "ESTDO_CVL");
                        //PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        //PGJ.CargaCombo(ddlEscolaridad, "CAT_ESCOLARIDAD", "ID_ESCLRDD", "ESCLRDD");
                        //PGJ.CargaCombo(ddlOcupacion, "CAT_OCUPACION", "ID_OCPCION", "OCPCION");
                        //PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        //PGJ.CargaCombo(ddlPusoDisposicion, "CAT_CORPORACION", "ID_CORPORACION", "CORPORACION");

                        //PGJ.CargaCombo(ddlTipoLugar, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                        //PGJ.CargaComboFiltrado(ddlMunicipioLH, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=1 and Id_Estdo=28");
                        //cargarLugarHechos();
                        //llamarMapa();

                        PGJ.CargaCombo(ddlEstadoDetenido, "CAT_ESTADO_DETENIDO", "ID_ESTDO_DTNDO", "ESTDO_DTNDO");
                        //PGJ.CargaCombo(ddlPreferencia, "CAT_PREFERENCIA_SEXUAL", "ID_PREFERENCIA_SEXUAL", "PREFERENCIA_SEXUAL");
                        PGJ.CargaCombo(ddlParticipacion, "CAT_PARTICIPACION", "ID_PARTICIPACION", "PARTICIPACION");


                        //NoModificar();
                        cargarPersona();
                        Session["ID_DETENCION_SEC"] = Request.QueryString["ID_DETENCION_SEC"];
                        ID_DETENCION.Text = Session["ID_DETENCION_SEC"].ToString();
                        
                        //Muestra la Imagen recien Guardada
                        Ifoto.ImageUrl = "fotoDetenido.ashx?Id=" + ID_DETENCION.Text;

                        CargarPersonaDetenidaPI();

                    }
                    catch (Exception ex)
                    {
                        if (Session["ID_PUESTO"].ToString() == "16")
                        {
                            Response.Redirect("CoordPoliciaInvestigador.aspx");
                        }
                        else if (Session["ID_PUESTO"].ToString() == "8")
                        {
                            Response.Redirect("PoliciaInvestigador.aspx");
                        }
                    }
                    
                }
               

            }
        }

        void cargarLugarHechos()
        {
            //SqlCommand sql = new SqlCommand("cargarLugarHechos " + int.Parse(Session["ID_LUGAR_HECHOS"].ToString()), Data.CnnCentral);
            //SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    dr.Read();

            //    ID_LUGAR_HECHOS.Text = dr["ID_LUGAR_HECHOS"].ToString();
            //    // Data.IdLugarHechos = Convert.ToInt32(ID_LUGAR_HECHOS.Text);

            //    txtFecha.Text = dr["FECHA_HECHOS"].ToString();
            //    txtHora.Text = dr["HORA_HECHOS"].ToString();
            //    ddlTipoLugar.SelectedValue = dr["ID_TIPO_LUGAR"].ToString();


                
            //    Session["ID_MUNICIPIO_LH"] = dr["ID_MUNICIPIO"].ToString();
            //    ddlMunicipioLH.SelectedValue = Session["ID_MUNICIPIO_LH"].ToString();
            //    consultaMunicipioLocalidadLH();


            //    Session["ID_LOCALIDAD_LH"] = dr["ID_LOCALIDAD"].ToString();
            //    ddlLocalidadLH.SelectedValue = Session["ID_LOCALIDAD_LH"].ToString();

            //    ddlColoniaLH.SelectedValue = dr["ID_COLONIA"].ToString();
            //    consultaLocalidadColoniaLH();

            //    ddlCalleLH.SelectedValue = dr["ID_CALLE"].ToString();
            //    consultaLocalidadCalleLH();

            //    ddlEntreCalleLH.SelectedValue = dr["ID_ENTRE_CALLE"].ToString();
            //    consultaLocalidadEntreCalleLH();

            //    ddlYcalleLH.SelectedValue = dr["ID_Y_CALLE"].ToString();
            //    consultaLocalidadYCalleLH();
                 

            //    txtNumeroLH.Text = dr["NO_EXTERIOR"].ToString();
            //    txtManzanaLH.Text = dr["MANZANA"].ToString();
            //    txtLoteLH.Text = dr["LOTE"].ToString();
            //    txtLatitud.Text = dr["LATITUD"].ToString();
            //    txtLongitud.Text = dr["LONGITUD"].ToString();
            //    txtReferencias.Text = dr["REFERENCIAS"].ToString();

            //}
            //dr.Close();
        }


        public void llamarMapa()
        {
            //double Longitud;
            ////String x = txtLongitud.Text.ToString();
            //// Longitud =  Convert.ToDouble(x);
            //Longitud = double.Parse(txtLongitud.Text.ToString(), System.Globalization.NumberFormatInfo.InvariantInfo);
            //// Longitud = double.Parse(txtLongitud.Text.ToString ());

            //double Latitud;
            //Latitud = double.Parse(txtLatitud.Text, System.Globalization.NumberFormatInfo.InvariantInfo);
            //GMap1.Visible = true;
            //lblMapa.Visible = true;
            //GMap1.resetMarkers();



            //if (Longitud > 0)
            //{
            //    Longitud = Longitud * -1;
            //}

            //var glatlng = new Subgurim.Controles.GLatLng(Latitud, Longitud);
            //GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            //var oMarker = new Subgurim.Controles.GMarker(glatlng);
            //GMap1.Add(oMarker);
        }

        public void CargarInfoCombosDom()
        { 
             
            //ddlNacionalidad.SelectedValue = "31";
            //Session["ID_PAIS"] = 1;
            //ddlPais.SelectedValue = Session["ID_PAIS"].ToString();
            //consultaPaisEstado();
            //Session["ID_ESTADO"] = 28;
            //ddlEstado.SelectedValue = Session["ID_ESTADO"].ToString();
            //consultaEstadoMunicipio();
            //ddlMunicipio.SelectedValue = "41";
            //Session["ID_PAIS_DOM"] = 1;
            //ddlPaisDom.SelectedValue = Session["ID_PAIS_DOM"].ToString();
            //consultaPaisEstadoDom();
            //Session["ID_ESTADO_DOM"] = 28;
            //ddlEstadoDom.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
            //consultaEstadoMunicipioDom();


            //Session["ID_MUNICIPIO_DOM"] = "41";
            //ddlMunicipioDom.SelectedValue = Session["ID_MUNICIPIO_DOM"].ToString();
            //consultaMunicipioLocalidad();
            //Session["ID_LOCALIDAD"] = 388;
            //ddlLocalidadDom.SelectedValue = "388";
            //ddlColoniaDom.SelectedValue = "153";
            //consultaLocalidadColonia();
            //ddlCalleDom.SelectedValue = "2874";
            //consultaLocalidadCalle();
            //ddlEntreCalleDom.SelectedValue = "2874";
            //consultaLocalidadEntreCalle();
            //ddlYcalleDom.SelectedValue = "2874";
            //consultaLocalidadYCalle();
        
        }

        void cargarAgregarLugarHechos()
        {

            //Session["ID_MUNICIPIO_LH"] = "41";
            //ddlMunicipioLH.SelectedValue = Session["ID_MUNICIPIO_LH"].ToString();
            //consultaMunicipioLocalidadLH();
            //Session["ID_LOCALIDAD_LH"] = 388;
            //ddlLocalidadLH.SelectedValue = "388";
            //ddlColoniaLH.SelectedValue = "153";
            //consultaLocalidadColoniaLH();
            //ddlCalleLH.SelectedValue = "2874";
            //consultaLocalidadCalleLH();
            //ddlEntreCalleLH.SelectedValue = "2874";
            //consultaLocalidadEntreCalleLH();
            //ddlYcalleLH.SelectedValue = "2874";
            //consultaLocalidadYCalleLH();
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_SECUESTRO.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }
        }

        protected void cmdMedio_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("MedioContacto.aspx?ID_PERSONA=" + ID_PERSONA.Text + "&op=Agregar");
        }

        protected void cmdAlias_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Alias.aspx?ID_PERSONA=" + ID_PERSONA.Text + "&op=Agregar");

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


        //protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_ESTADO"] = ddlEstado.SelectedValue.ToString();
        //    consultaEstadoMunicipio();
        //    //  PGJ.CargaComboFiltrado(ddlMunicipio, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=" + ddlPais.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstado.SelectedValue.ToString());
        //}

        //protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // PGJ.CargaComboFiltrado(ddlEstado, "Cat_Estado", "Id_Estdo", "Estdo", "Id_Pais=" + ddlPais.SelectedValue.ToString());
        //    Session["ID_PAIS"] = ddlPais.SelectedValue.ToString();
        //    consultaPaisEstado();

        //}

        //protected void ddlPaisDom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_PAIS_DOM"] = ddlPaisDom.SelectedValue.ToString();
        //    consultaPaisEstadoDom();
        //    //PGJ.CargaComboFiltrado(ddlEstadoDom, "Cat_Estado", "Id_Estdo", "Estdo", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString());
        //}

        //protected void ddlEstadoDom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_ESTADO_DOM"] = ddlEstadoDom.SelectedValue.ToString();
        //    consultaEstadoMunicipioDom();
        //    //PGJ.CargaComboFiltrado(ddlMunicipioDom, "Cat_Municipio", "Id_Mncpio", "Mncpio", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString());
        //}

        //protected void ddlMunicipioDom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_MUNICIPIO_DOM"] = ddlMunicipioDom.SelectedValue.ToString();
        //    consultaMunicipioLocalidad();
        //    // PGJ.CargaComboFiltrado(ddlLocalidadDom, "Cat_Localidad", "Id_Lcldd", "Lcldd", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString());
        //}

        //protected void ddlLocalidadDom_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_LOCALIDAD"] = ddlLocalidadDom.SelectedValue.ToString();
        //    consultaLocalidadColonia();
        //    consultaLocalidadCalle();
        //    consultaLocalidadEntreCalle();
        //    consultaLocalidadYCalle();
        //    //PGJ.CargaComboFiltrado(ddlColonia, "Cat_Colonia", "Id_Clnia", "Clnia", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
        //    //PGJ.CargaComboFiltrado(ddlCalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
        //    //PGJ.CargaComboFiltrado(ddlEntreCalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
        //    //PGJ.CargaComboFiltrado(ddlYcalle, "Cat_Calle", "Id_Clle", "Clle", "Id_Pais=" + ddlPaisDom.SelectedValue.ToString() + " and Id_Estdo=" + ddlEstadoDom.SelectedValue.ToString() + " and Id_Mncpio=" + ddlMunicipioDom.SelectedValue.ToString() + " and Id_Lcldd=" + ddlLocalidadDom.SelectedValue.ToString());
        //}

        //void consultaIdPersonaMax()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var fecha = from c in dc.consultaIdPersonaMax(txtPaterno.Text, txtMaterno.Text, txtNombre.Text)
        //                select c;
        //    foreach (var propiedad in fecha)
        //    {
        //        ID_PERSONA.Text = propiedad.ID_PERSONA.ToString();
        //        Session["ID_PERSONA"] = ID_PERSONA.Text;
        //    }
        //}


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

        protected void cmdGu_Click(object sender, EventArgs e)
        {

            Byte[] foto;
            try
            {

                if (Session["op"].ToString() == "Agregar")
                {
                    //PGJ.InsertaDetenidoPI(txtPaterno.Text, txtMaterno.Text, txtNombre.Text, short.Parse(ddlSexo.SelectedValue.ToString()), txtFecNaci.Text, short.Parse(ddlNacionalidad.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), txtRFC.Text, txtCurp.Text, short.Parse(Session["IdMunicipio"].ToString()));
                    //consultaIdPersonaMax();
                    //PGJ.InsertaPersonaDomicilio(int.Parse(ID_PERSONA.Text), short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), int.Parse(ddlLocalidadDom.SelectedValue.ToString()), int.Parse(ddlColoniaDom.SelectedValue.ToString()), int.Parse(ddlCalleDom.SelectedValue.ToString()), int.Parse(ddlEntreCalleDom.SelectedValue.ToString()), int.Parse(ddlYcalleDom.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, short.Parse(Session["IdMunicipio"].ToString()));
                    //PGJ.InsertaCarpetaPersona(0, int.Parse(ID_PERSONA.Text), short.Parse(ddlEstadoCivil.SelectedValue.ToString()), short.Parse(ddlEscolaridad.SelectedValue.ToString()), short.Parse(ddlOcupacion.SelectedValue.ToString()), short.Parse(ddlIdentificacion.SelectedValue.ToString()), "0", short.Parse(rbEscribir.SelectedValue.ToString()), short.Parse(rbVivo.SelectedValue.ToString()), 1, short.Parse(ID_TIPO_ACTOR.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse("0"));

                    //LUGAR DE LA DETENCIÓN MÉTODO InsertaLugarhechos
                    //PGJ.InsertaLugarhechos(0, DateTime.Parse(txtFecha.Text), txtHora.Text, short.Parse(ddlTipoLugar.SelectedValue.ToString()), short.Parse(ddlMunicipioLH.SelectedValue.ToString()), int.Parse(ddlLocalidadLH.SelectedValue.ToString()), int.Parse(ddlColoniaLH.SelectedValue.ToString()), int.Parse(ddlCalleLH.SelectedValue.ToString()), int.Parse(ddlEntreCalleLH.SelectedValue.ToString()), int.Parse(ddlYcalleLH.SelectedValue.ToString()), txtNumeroLH.Text, txtManzanaLH.Text, txtLoteLH.Text, txtLatitud.Text, txtLongitud.Text, txtReferencias.Text, short.Parse(Session["IdMunicipio"].ToString()));
                    //consultaIdLugarHechos();

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
                    else{
                        foto = new Byte[0];
                    }
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    //cargarImputado();
                    //AQUI SE INSERTA LA INFORMACION DE LA DETENCION                                                     
                    PGJ.InsertarDetencion(int.Parse(ddlImputado.SelectedValue.ToString()), int.Parse(IdUsuario.Text), int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), txtMotivoDetencion.Text, txtTiempoTraslado.Text, txtPuestaDisposicion.Text, txtAutoridadDisp.Text, txtNombreRecibio.Text, txtCargoRecibio.Text, txtCausaNofirma.Text, txtHora.Text, DateTime.Parse(txtFecha.Text), short.Parse(ddlEstadoDetenido.SelectedValue), foto, txtAsunto.Text, txtDirigidoA.Text, txtAgentes.Text, short.Parse(ddlParticipacion.SelectedValue), short.Parse(ddlOperativo.SelectedValue), txtComandanteOperativo.Text, txtDescripcionHechos.Text, "", ddlDetenidoPor.SelectedValue);
                    //Muestra la Imagen recien Guardada
                    Ifoto.ImageUrl = "fotoDetenido.ashx?Id=" + ddlImputado.SelectedValue.ToString();

                    consultaIDDetencion();

                
                }
                else if (Session["op"].ToString() == "Modificar" )
                {


                    //PGJ.ActualizaCarpetaPersona(int.Parse(ID_PERSONA.Text), short.Parse(ddlEstadoCivil.SelectedValue.ToString()), short.Parse(ddlEscolaridad.SelectedValue.ToString()), short.Parse(ddlOcupacion.SelectedValue.ToString()), short.Parse(ddlIdentificacion.SelectedValue.ToString()), "0", short.Parse(rbEscribir.SelectedValue.ToString()), short.Parse(rbVivo.SelectedValue.ToString()), 1, 0);
                    //PGJ.ActualizaPersona(int.Parse(ID_PERSONA.Text), txtPaterno.Text, txtMaterno.Text, txtNombre.Text, short.Parse(ddlSexo.SelectedValue.ToString()), txtFecNaci.Text, short.Parse(ddlNacionalidad.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), txtRFC.Text, txtCurp.Text,"");
                    //PGJ.ActualizaPersonaDomicilio(int.Parse(ID_PERSONA.Text), short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), int.Parse(ddlLocalidadDom.SelectedValue.ToString()), int.Parse(ddlColoniaDom.SelectedValue.ToString()), int.Parse(ddlCalleDom.SelectedValue.ToString()), int.Parse(ddlEntreCalleDom.SelectedValue.ToString()), int.Parse(ddlYcalleDom.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text);
                    //PGJ.ActualizaLugarhechos(int.Parse(ID_LUGAR_HECHOS.Text), DateTime.Parse(txtFecha.Text), txtHora.Text, short.Parse(ddlTipoLugar.SelectedValue.ToString()), short.Parse(ddlMunicipioLH.SelectedValue.ToString()), int.Parse(ddlLocalidadLH.SelectedValue.ToString()), int.Parse(ddlColoniaLH.SelectedValue.ToString()), int.Parse(ddlCalleLH.SelectedValue.ToString()), int.Parse(ddlEntreCalleLH.SelectedValue.ToString()), int.Parse(ddlYcalleLH.SelectedValue.ToString()), txtNumeroLH.Text, txtManzanaLH.Text, txtLoteLH.Text, txtLatitud.Text, txtLongitud.Text, txtReferencias.Text);

                    //AQUI SE ACTUALIZA LA INFORMACION DE LA DETENCION                                                     
                    PGJ.ModificarDetencion(short.Parse(Session["ID_DETENCION_SEC"].ToString()), txtMotivoDetencion.Text, txtTiempoTraslado.Text, txtPuestaDisposicion.Text, txtAutoridadDisp.Text, txtNombreRecibio.Text, txtCargoRecibio.Text, txtCausaNofirma.Text, txtHora.Text, DateTime.Parse(txtFecha.Text), short.Parse(ddlEstadoDetenido.SelectedValue), txtAsunto.Text, txtDirigidoA.Text, txtAgentes.Text, short.Parse(ddlParticipacion.SelectedValue), short.Parse(ddlOperativo.SelectedValue), txtComandanteOperativo.Text, txtDescripcionHechos.Text, "", ddlDetenidoPor.SelectedValue);

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

                        PGJ.ActualizarImagenDetenidoPI(int.Parse(ID_DETENCION.Text), foto);

                        //Muestra la Imagen recien Guardada
                        Ifoto.ImageUrl = "fotoDetenido.ashx?Id=" + ID_DETENCION.Text;
                    }

                    //Colocar Alerta 
                    /*string script = @"<script type='text/javascript'>
                            alert('INFORMACIÓN MODIFICADA CORRECTAMENTE');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                     */ 

                }
                lblEstatus.Text = "DATOS GUARDADOS";
                cmdGu.Enabled = false;

                //cmdAlias.Enabled = true;
                //cmdMedio.Enabled = true;
                desactivarBotones();

                if (Session["op"].ToString() == "Agregar")
                {
                    cmdReg.Enabled = true;
                    cmdSiguiente.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        void cargarPersona()
        {
            //SqlCommand sql = new SqlCommand("cargarPersona " + int.Parse(Session["ID_PERSONA"].ToString()), Data.CnnCentral);
            //SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    dr.Read();

            //    ID_PERSONA.Text = dr["ID_PERSONA"].ToString();
            //    // Data.IdPersona = Convert.ToInt32(ID_PERSONA.Text);

            //    ID_TIPO_ACTOR.Text = dr["ID_TIPO_ACTOR"].ToString();

            //    txtNombre.Text = dr["NOMBRE"].ToString();
            //    txtPaterno.Text = dr["PATERNO"].ToString();
            //    txtMaterno.Text = dr["MATERNO"].ToString();
            //    ddlNacionalidad.SelectedValue = dr["ID_NACIONALIDAD"].ToString();

            //    Session["ID_PAIS"] = dr["ID_PAIS"].ToString();
            //    ddlPais.SelectedValue = Session["ID_PAIS"].ToString();
            //    consultaPaisEstado();

            //    Session["ID_ESTADO"] = dr["ID_ESTADO"].ToString();
            //    ddlEstado.SelectedValue = Session["ID_ESTADO"].ToString();
            //    consultaEstadoMunicipio();
            //    ddlMunicipio.SelectedValue = dr["ID_MUNICIPIO"].ToString();

            //    Session["ID_PAIS_DOM"] = dr["ID_PAIS_DOM"].ToString();
            //    ddlPaisDom.SelectedValue = Session["ID_PAIS_DOM"].ToString();
            //    consultaPaisEstadoDom();

            //    Session["ID_ESTADO_DOM"] = dr["ID_ESTADO_DOM"].ToString();
            //    ddlEstadoDom.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
            //    consultaEstadoMunicipioDom();

            //    Session["ID_MUNICIPIO_DOM"] = dr["ID_MUNICIPIO_DOM"].ToString();
            //    ddlMunicipioDom.SelectedValue = Session["ID_MUNICIPIO_DOM"].ToString();
            //    consultaMunicipioLocalidad();

            //    Session["ID_LOCALIDAD"] = dr["ID_LOCALIDAD"].ToString();
            //    ddlLocalidadDom.SelectedValue = dr["ID_LOCALIDAD"].ToString();


            //    ddlColoniaDom.SelectedValue = dr["ID_COLONIA"].ToString();
            //    consultaLocalidadColonia();

            //    ddlCalleDom.SelectedValue = dr["ID_CALLE"].ToString();
            //    consultaLocalidadCalle();

            //    ddlEntreCalleDom.SelectedValue = dr["ID_ENTRE_CALLE"].ToString();
            //    consultaLocalidadEntreCalle();

            //    ddlYcalleDom.SelectedValue = dr["ID_Y_CALLE"].ToString();
            //    consultaLocalidadYCalle();

            //    txtNumero.Text = dr["NUMERO"].ToString();
            //    txtManzana.Text = dr["MANZANA"].ToString();
            //    txtLote.Text = dr["LOTE"].ToString();
            //    txtRFC.Text = dr["RFC"].ToString();
            //    txtCurp.Text = dr["CURP"].ToString();
            //    ddlSexo.SelectedValue = dr["ID_SEXO"].ToString();
            //    txtFecNaci.Text = dr["FECHA_NACIMIENTO"].ToString();
            //    ddlEstadoCivil.SelectedValue = dr["ID_ESTADO_CIVIL"].ToString();
            //    ddlEscolaridad.SelectedValue = dr["ID_ESCOLARIDAD"].ToString();
            //    ddlOcupacion.SelectedValue = dr["ID_OCUPACION"].ToString();
            //    ddlIdentificacion.SelectedValue = dr["ID_IDENTIFICACION"].ToString();
            //    //txtFolio.Text = dr["FOLIO"].ToString();
            //    txtCurp.Text = dr["CURP"].ToString();
            //    txtRFC.Text = dr["RFC"].ToString();

            //    rbEscribir.SelectedValue = dr["LEER_ESCRIBIR"].ToString();
            //    rbVivo.SelectedValue = dr["VIVO"].ToString();
            //    rbDetenido.SelectedValue = dr["DETENIDO"].ToString();
            //   // ddlPusoDisposicion.SelectedValue = dr["ID_PUSO_DISPOSICION"].ToString();

               

            //}
            //dr.Close();

            // CargarPersonaDetenidaPI();
        }


        void CargarPersonaDetenidaPI()
        {
            SqlCommand sql1 = new SqlCommand("CargarPersonaDetenidaSec " + int.Parse(Session["ID_DETENCION_SEC"].ToString()), Data.CnnCentral);
            SqlDataReader dr1 = sql1.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();

               //ddlPreferencia.SelectedValue = dr1["ID_PREFERENCIA_SEXUAL"].ToString();

                ddlImputado.SelectedValue = dr1["ID_PERSONA"].ToString();
               ddlEstadoDetenido.SelectedValue = dr1["ID_ESTADO_DETENIDO"].ToString();
               ddlDetenidoPor.SelectedValue = dr1["DETENIDO_POR"].ToString();
               txtTiempoTraslado.Text = dr1["TIEMPO_TRANSLADO"].ToString();
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
               txtDescripcionHechos.Text = dr1["DESCRIPCION_HECHOS"].ToString();
               txtHora.Text = dr1["HORA_DETENCION"].ToString();
               txtFecha.Text = dr1["FECHA_DETENCION"].ToString();
               
                
            }
            dr1.Close();
        }

        //void consultaPaisEstado()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS"].ToString()))
        //                 select new { c.ID_ESTDO, c.ESTDO };
        //    ddlEstado.DataSource = estado;
        //    ddlEstado.DataValueField = "ID_ESTDO";
        //    ddlEstado.DataTextField = "ESTDO";
        //    ddlEstado.DataBind();
        //}

        //void consultaPaisEstadoDom()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS_DOM"].ToString()))
        //                 select new { c.ID_ESTDO, c.ESTDO };
        //    ddlEstadoDom.DataSource = estado;
        //    ddlEstadoDom.DataValueField = "ID_ESTDO";
        //    ddlEstadoDom.DataTextField = "ESTDO";
        //    ddlEstadoDom.DataBind();
        //}

        //void consultaEstadoMunicipio()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS"].ToString()), short.Parse(Session["ID_ESTADO"].ToString()))
        //                    select new { c.ID_MNCPIO, c.MNCPIO };
        //    ddlMunicipio.DataSource = municipio;
        //    ddlMunicipio.DataValueField = "ID_MNCPIO";
        //    ddlMunicipio.DataTextField = "MNCPIO";
        //    ddlMunicipio.DataBind();
        //}

        //void consultaEstadoMunicipioDom()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()))
        //                    select new { c.ID_MNCPIO, c.MNCPIO };
        //    ddlMunicipioDom.DataSource = municipio;
        //    ddlMunicipioDom.DataValueField = "ID_MNCPIO";
        //    ddlMunicipioDom.DataTextField = "MNCPIO";
        //    ddlMunicipioDom.DataBind();
        //}

        //void consultaMunicipioLocalidad()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var localidad = from c in dc.consultaMunicipioLocalidad(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()))
        //                    select new { c.ID_LCLDD, c.LCLDD };
        //    ddlLocalidadDom.DataSource = localidad;
        //    ddlLocalidadDom.DataValueField = "ID_LCLDD";
        //    ddlLocalidadDom.DataTextField = "LCLDD";
        //    ddlLocalidadDom.DataBind();
        //}

        //void consultaLocalidadColonia()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var colonia = from c in dc.consultaLocalidadColonia(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
        //                  select new { c.ID_CLNIA, c.CLNIA };
        //    ddlColoniaDom.DataSource = colonia;
        //    ddlColoniaDom.DataValueField = "ID_CLNIA";
        //    ddlColoniaDom.DataTextField = "CLNIA";
        //    ddlColoniaDom.DataBind();
        //}

        //void consultaLocalidadCalle()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var calle = from c in dc.consultaLocalidadCalle(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
        //                select new { c.ID_CLLE, c.CLLE };
        //    ddlCalleDom.DataSource = calle;
        //    ddlCalleDom.DataValueField = "ID_CLLE";
        //    ddlCalleDom.DataTextField = "CLLE";
        //    ddlCalleDom.DataBind();
        //}

        //void consultaLocalidadEntreCalle()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var calle = from c in dc.consultaLocalidadCalle(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
        //                select new { c.ID_CLLE, c.CLLE };
        //    ddlEntreCalleDom.DataSource = calle;
        //    ddlEntreCalleDom.DataValueField = "ID_CLLE";
        //    ddlEntreCalleDom.DataTextField = "CLLE";
        //    ddlEntreCalleDom.DataBind();
        //}

        //void consultaLocalidadYCalle()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var calle = from c in dc.consultaLocalidadCalle(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()), short.Parse(Session["ID_MUNICIPIO_DOM"].ToString()), short.Parse(Session["ID_LOCALIDAD"].ToString()))
        //                select new { c.ID_CLLE, c.CLLE };
        //    ddlYcalleDom.DataSource = calle;
        //    ddlYcalleDom.DataValueField = "ID_CLLE";
        //    ddlYcalleDom.DataTextField = "CLLE";
        //    ddlYcalleDom.DataBind();
        //}

        void desactivarBotones()
        {
            //txtNombre.Enabled = false;
            //txtPaterno.Enabled = false;
            //txtMaterno.Enabled = false;
            //ddlNacionalidad.Enabled = false;
            //ddlPais.Enabled = false;
            //ddlEstado.Enabled = false;
            //ddlMunicipio.Enabled = false;
            //ddlPaisDom.Enabled = false;
            //ddlEstadoDom.Enabled = false;
            //ddlMunicipioDom.Enabled = false;
            //ddlLocalidadDom.Enabled = false;
            //ddlColoniaDom.Enabled = false;
            //ddlCalleDom.Enabled = false;
            //ddlEntreCalleDom.Enabled = false;
            //ddlYcalleDom.Enabled = false;
            //txtNumero.Enabled = false;
            //txtManzana.Enabled = false;
            //txtLote.Enabled = false;
            //txtRFC.Enabled = false;
            //txtCurp.Enabled = false;
            //ddlSexo.Enabled = false;
            //txtFecNaci.Enabled = false;
            //ddlEstadoCivil.Enabled = false;
            //ddlEscolaridad.Enabled = false;
            //ddlOcupacion.Enabled = false;
            //ddlIdentificacion.Enabled = false;
            //txtFolio.Enabled = false;
            //txtCurp.Enabled = false;
            //txtRFC.Enabled = false;
            //rbEscribir.Enabled = false;
            //rbVivo.Enabled = false;
            //rbDetenido.Enabled = false;
            //ddlPreferencia.Enabled = false;


            //txtFechaDetencion.Enabled = false;
            //txtHoraDetencion.Enabled = false;
            ddlEstadoDetenido.Enabled = false;
            //ddlPusoDisposicion.Enabled = false;
            txtAsunto.Enabled = false;
            txtDirigidoA.Enabled = false;
            txtAgentes.Enabled = false;
            ddlParticipacion.Enabled = false;
            ddlOperativo.Enabled = false;
            txtComandanteOperativo.Enabled = false;
            txtAutoridadDisp.Enabled = false;
            txtNombreRecibio.Enabled = false;
            txtCargoRecibio.Enabled = false;
            txtMotivoDetencion.Enabled = false;
            txtPuestaDisposicion.Enabled = false;
            txtTiempoTraslado.Enabled = false;
            //txtLugarRef.Enabled = false;
            ddlDetenidoPor.Enabled = false;
            txtCausaNofirma.Enabled = false;
            txtDescripcionHechos.Enabled = false;

            ImagenFile.Enabled = false;
            txtFecha.Enabled = false;
            txtHora.Enabled = false;


            //txtFecha.Enabled = false;
            //txtHora.Enabled = false;
            //ddlTipoLugar.Enabled = false;
            //ddlMunicipioLH.Enabled = false;
            //ddlLocalidadLH.Enabled = false;
            //ddlColoniaLH.Enabled = false;
            //ddlCalleLH.Enabled = false;
            //ddlEntreCalleLH.Enabled = false;
            //ddlYcalleLH.Enabled = false;
            //txtNumeroLH.Enabled = false;
            //txtManzanaLH.Enabled = false;
            //txtLoteLH.Enabled = false;
            //txtLatitud.Enabled = false;
            //txtLongitud.Enabled = false;
            //txtReferencias.Enabled = false;

        }

        protected void cmdSiguiente_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {

                Response.Redirect("SeñasParticularesDetenido.aspx?op=Agregar");
                //Response.Redirect("RegistrarDetencion.aspx?op=Agregar");
            }

            if (Session["op"].ToString() == "Modificar")
            {

                Response.Redirect("SeñasParticularesDetenido.aspx?op=Modificar");
            }

            
        }

        void consultaIdLugarHechos()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(ID_LUGAR_HECHOS),1) as ID_LUGAR_HECHOS  From PGJ_LUGAR_HECHOS", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_LUGAR_HECHOS.Text = dr["ID_LUGAR_HECHOS"].ToString();
            Session["ID_LUGAR_HECHOS"] = ID_LUGAR_HECHOS.Text;

            //}
            dr.Close();
        }

        void consultaIDDetencion() 
        {
            //Seleccionamos el ID DETENCION
            PGJ.ConnectServer();
            SqlCommand comm1 = new SqlCommand("  SELECT MAX(ID_DETENCION) AS ID_DETENCION FROM PGJ_DETENCION WHERE ID_USUARIO =" + IdUsuario.Text, Data.CnnCentral);
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

        //protected string GMap1_Click(object s, GAjaxServerEventArgs e)
        //{
        //    GMap1.resetMarkers();
        //    //Response.Write("Sus Coordenadas son: \r\n Latitud: " + e.point.lat + "\r\n" + "Logitud: " + e.point.lng);
        //    txtLongitud.Text = (string)e.point.lng.ToString();
        //    txtLatitud.Text = (string)e.point.lat.ToString();

        //    var glatlng = new Subgurim.Controles.GLatLng(double.Parse(txtLatitud.Text), double.Parse(txtLongitud.Text));
        //    GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
        //    var oMarker = new Subgurim.Controles.GMarker(glatlng);
        //    GMap1.Add(oMarker);

        //    return default(string);
        //}

        //protected void cmdMapa_Click(object sender, EventArgs e)
        //{
        //    GMap1.Visible = true;
        //    lblMapa.Visible = true;
        //    GMap1.resetMarkers();
        


        //    var glatlng = new Subgurim.Controles.GLatLng(double.Parse(txtLatitud.Text), double.Parse(txtLongitud.Text));
        //    GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
        //    var oMarker = new Subgurim.Controles.GMarker(glatlng);
        //    GMap1.Add(oMarker);

        //}

        //protected void ddlMunicipioLH_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_MUNICIPIO_LH"] = ddlMunicipioLH.SelectedValue.ToString();
        //    consultaMunicipioLocalidadLH();
        //}

        //protected void ddlLocalidadLH_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_LOCALIDAD_LH"] = ddlLocalidadLH.SelectedValue.ToString();
        //    consultaLocalidadColoniaLH();
        //    consultaLocalidadCalleLH();
        //    consultaLocalidadEntreCalleLH();
        //    consultaLocalidadYCalleLH();
        //}
       

        //void consultaMunicipioLocalidadLH()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var localidad = from c in dc.consultaMunicipioLocalidad(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()))
        //                    select new { c.ID_LCLDD, c.LCLDD };
        //    ddlLocalidadLH.DataSource = localidad;
        //    ddlLocalidadLH.DataValueField = "ID_LCLDD";
        //    ddlLocalidadLH.DataTextField = "LCLDD";
        //    ddlLocalidadLH.DataBind();
        //}

        //void consultaLocalidadColoniaLH()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var colonia = from c in dc.consultaLocalidadColonia(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
        //                  select new { c.ID_CLNIA, c.CLNIA };
        //    ddlColoniaLH.DataSource = colonia;
        //    ddlColoniaLH.DataValueField = "ID_CLNIA";
        //    ddlColoniaLH.DataTextField = "CLNIA";
        //    ddlColoniaLH.DataBind();
        //}

        //void consultaLocalidadCalleLH()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var calle = from c in dc.consultaLocalidadCalle(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
        //                select new { c.ID_CLLE, c.CLLE };
        //    ddlCalleLH.DataSource = calle;
        //    ddlCalleLH.DataValueField = "ID_CLLE";
        //    ddlCalleLH.DataTextField = "CLLE";
        //    ddlCalleLH.DataBind();
        //}

        //void consultaLocalidadEntreCalleLH()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var calle = from c in dc.consultaLocalidadCalle(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
        //                select new { c.ID_CLLE, c.CLLE };
        //    ddlEntreCalleLH.DataSource = calle;
        //    ddlEntreCalleLH.DataValueField = "ID_CLLE";
        //    ddlEntreCalleLH.DataTextField = "CLLE";
        //    ddlEntreCalleLH.DataBind();
        //}

        //void consultaLocalidadYCalleLH()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var calle = from c in dc.consultaLocalidadCalle(short.Parse("1"), short.Parse("28"), short.Parse(Session["ID_MUNICIPIO_LH"].ToString()), short.Parse(Session["ID_LOCALIDAD_LH"].ToString()))
        //                select new { c.ID_CLLE, c.CLLE };
        //    ddlYcalleLH.DataSource = calle;
        //    ddlYcalleLH.DataValueField = "ID_CLLE";
        //    ddlYcalleLH.DataTextField = "CLLE";
        //    ddlYcalleLH.DataBind();
        //}

    }
}