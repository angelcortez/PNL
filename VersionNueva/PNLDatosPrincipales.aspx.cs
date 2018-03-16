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
using DevExpress.Web.ASPxTabControl;


namespace AtencionTemprana
{
    public partial class PNLDatosPrincipales : System.Web.UI.Page
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
                typeof(Datos),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                //---
                lblArbol.Text = Session["lblArbol"].ToString();

                //TRAE EL USUARIO, PUESTO, UNIDAD Y LA OPERACIÓN. ADEMÁS DE CARGAR LA FECHA ACTUAL// 
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();

                cargarFecha();
                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();
                if (Session["op"].ToString() == "Agregar")
                {
                    //TOMA LA SESIÓN DEL ID_CARPETA CREADA ANTERIORMENTE                  
                    //TOMA LA SESIÓN DEL ID_PERSONA CREADA ANTERIORMENTE                  
                    //TOMA LA SESIÓN DEL ID_MUNICIPIO_CARPETA CREADA ANTERIORMENTE                 
                    lblOperacion.Text = "COMPLEMENTAR DATOS DE LA PERSONA NO LOCALIZADA";
                    //LLENAR COMBOS PARA INSERTAR POR PRIMERA VEZ
                    PGJ.CargaCombo(ddlEtnia, "PNL_CAT_ETNIA", "IdEtniaNL", "EtniaNL");
                    PGJ.CargaCombo(ddlUltimaActividad, "PNL_CAT_ACTIVIDADES", "IdActividad", "Actividad");
                    PGJ.CargaCombo(ddlBanco, "PNL_CAT_BANCOS", "IdBanco", "Banco");
                    PGJ.CargaCombo(ddlBanco0, "PNL_CAT_BANCOS", "IdBanco", "Banco");
                    PGJ.CargaCombo(ddlBanco1, "PNL_CAT_BANCOS", "IdBanco", "Banco");
                    PGJ.CargaCombo(ddlDiscapacidadMental, "PNL_CAT_DISCAPACIDAD_MENTAL", "IdDiscapacidad", "DiscapacidadMental");
                    PGJ.CargaCombo(ddlDiscapacidadFisica, "PNL_CAT_DISCAPACIDAD_FISICA", "IdDiscapacidadFisica", "DiscapacidadFisica");
                    PGJ.CargaCombo(ddlTamDientes, "PNL_CAT_TAMANO_OJOS_Y_DIENTES", "IdTamaño", "Tamaño");
                    PGJ.CargaCombo(ddlProtesis, "PNL_CAT_PROTESIS", "IdProtesis", "Protesis");
                    PGJ.CargaCombo(ddlVestimenta, "CAT_VESTUARIO", "ID_VSTUARIO", "VSTUARIO");
                    PGJ.CargaCombo(rb_ddlTipo, "PNL_CAT_SUJETOS_CAUSALES", "IdTipoSujeto", "TipoSujeto");
                    cargarOfendido();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DATOS DE LA PERSONA NO LOCALIZADA";
                    try
                    {
                        //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                        //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                        Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                        ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                        Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                        ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                        Session["ID_DATOS_GENERALES"] = Request.QueryString["ID_DATOS_GENERALES"];
                        ID_DATOS_GENERALES.Text = Session["ID_DATOS_GENERALES"].ToString();

                        Session["ID_PERTENENCIA_SOCIAL"] = Request.QueryString["ID_PERTENENCIA_SOCIAL"];
                        ID_PERTENENCIA_SOCIAL.Text = Session["ID_PERTENENCIA_SOCIAL"].ToString();

                        Session["ID_INFO_FINANCIERA"] = Request.QueryString["ID_INFO_FINANCIERA"];
                        ID_INFO_FINANCIERA.Text = Session["ID_INFO_FINANCIERA"].ToString();

                        Session["ID_INFO_ODONTOLOGICA"] = Request.QueryString["ID_INFO_ODONTOLOGICA"];
                        ID_INFO_ODONTOLOGICA.Text = Session["ID_INFO_ODONTOLOGICA"].ToString();

                        Session["ID_DISCAPACIDADES"] = Request.QueryString["ID_DISCAPACIDADES"];
                        ID_DISCAPACIDADES.Text = Session["ID_DISCAPACIDADES"].ToString();

                        Session["ID_OTRA_INFO"] = Request.QueryString["ID_OTRA_INFO"];
                        ID_OTRA_INFO.Text = Session["ID_OTRA_INFO"].ToString();

                        Session["ID_CAUSALES"] = Request.QueryString["ID_CAUSALES"];
                        ID_CAUSALES.Text = Session["ID_CAUSALES"].ToString();

                        PGJ.CargaCombo(ddlEtnia, "PNL_CAT_ETNIA", "IdEtniaNL", "EtniaNL");
                        PGJ.CargaCombo(ddlUltimaActividad, "PNL_CAT_ACTIVIDADES", "IdActividad", "Actividad");
                        PGJ.CargaCombo(ddlBanco, "PNL_CAT_BANCOS", "IdBanco", "Banco");
                        PGJ.CargaCombo(ddlBanco0, "PNL_CAT_BANCOS", "IdBanco", "Banco");
                        PGJ.CargaCombo(ddlBanco1, "PNL_CAT_BANCOS", "IdBanco", "Banco");
                        PGJ.CargaCombo(ddlDiscapacidadMental, "PNL_CAT_DISCAPACIDAD_MENTAL", "IdDiscapacidad", "DiscapacidadMental");
                        PGJ.CargaCombo(ddlDiscapacidadFisica, "PNL_CAT_DISCAPACIDAD_FISICA", "IdDiscapacidadFisica", "DiscapacidadFisica");
                        PGJ.CargaCombo(ddlTamDientes, "PNL_CAT_TAMANO_OJOS_Y_DIENTES", "IdTamaño", "Tamaño");
                        PGJ.CargaCombo(ddlProtesis, "PNL_CAT_PROTESIS", "IdProtesis", "Protesis");
                        PGJ.CargaCombo(ddlVestimenta, "CAT_VESTUARIO", "ID_VSTUARIO", "VSTUARIO");
                        PGJ.CargaCombo(rb_ddlTipo, "PNL_CAT_SUJETOS_CAUSALES", "IdTipoSujeto", "TipoSujeto");

                        CargarPNL();
                        CargarPertenenciaSocial();
                        CargarInformacionFinanciera();
                        CargarDiscapacidades();
                        CargarInfoOdontologica();
                        CargarOtros();
                        CargarCausales();
                        cargarOfendido();


                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto PNL Datos Principales ID_DATOS_GENERALES=" + ID_DATOS_GENERALES.Text + " IdCarpeta=" + Session["ID_CARPETA"] + " IdPersona= " + ID_PERSONA.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                        btnMediaFiliacion.Visible = true;
                        btnSeniasParticulares.Visible = true;
                        btnAgregarDonante.Visible = true;
                        btnAgregarFotografia.Visible = true;
                        btnLocalizacion.Visible = true;
                        btnagregarVestimenta.Visible = true;
                    }

                    catch (Exception ex)
                    {


                    }


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

        void CargarPNL()
        {
            SqlCommand sql = new SqlCommand("PNL_CargarDatosGenerales  " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ddlEtnia.SelectedValue = dr["IdEtnia"].ToString();
                txtUltimoAvistamiento.Text = dr["FechaUltimoAvistamiento"].ToString();
                ddlUltimaActividad.SelectedValue = dr["IdActividad"].ToString();
                //  ddlOfendido.SelectedValue = dr["IdActividad"].ToString();
                ddlOfendido.SelectedValue = dr["IDPERSONA"].ToString();
            }
            dr.Close();

        }

        void CargarPertenenciaSocial()
        {
            SqlCommand sql = new SqlCommand("PNL_consultaPertenenciaSocial " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                txtONG.Text = dr["MiembroONG"].ToString();
                txtSindicalista.Text = dr["Sindicalista"].ToString();
                txtReinsertado.Text = dr["Reinsertado"].ToString();
                txtGrupoReligioso.Text = dr["GrupoReligioso"].ToString();
                txtOrgEstatal.Text = dr["OrganismoEstatal"].ToString();
                txtDH.Text = dr["GrupoDH"].ToString();
                txtOtros.Text = dr["Otros"].ToString();
            }
            dr.Close();

        }

        void CargarInformacionFinanciera()
        {
            SqlCommand sql = new SqlCommand("PNL_cargaInfoFinanciera " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

                ddlBanco.SelectedValue = dr["IdBanco"].ToString();
                txtNumCuenta.Text = dr["NumCuenta"].ToString();
                txtTipoCuenta.Text = dr["TipoCuenta"].ToString();
                ddlBanco0.SelectedValue = dr["TarjetaCredito"].ToString();
                txtNumTarjetaCredito.Text = dr["NumTarjetaCredito"].ToString();
                ddlBanco1.SelectedValue = dr["TarjetaDebito"].ToString();
                txtNumTarjetaDebito.Text = dr["NumTarjetaDebito"].ToString();
                txtTarjetaDepartamental.Text = dr["TarjetaDepartamental"].ToString();
                txtNumTarjetaDepartamental.Text = dr["NumTarjetaDepartamental"].ToString();

            }
            dr.Close();

        }

        void CargarDiscapacidades()
        {
            SqlCommand sql = new SqlCommand("PNL_ConsultaDiscapacidades " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

                ddlDiscapacidadMental.SelectedValue = dr["IdDiscapacidadMental"].ToString();
                txtDiscapacidadMental.Text = dr["OtraDiscapacidadMental"].ToString();
                ddlDiscapacidadFisica.SelectedValue = dr["IdDiscapacidadFisica"].ToString();
                txtDiscapacidadFisica.Text = dr["OtraDiscapacidadFisica"].ToString();
                txtPadecimientos.Text = dr["Padecimientos"].ToString();
                txtSistematicas.Text = dr["EnfermedadSistematica"].ToString();
                txtEnfermedadMental.Text = dr["EnfermedadMental"].ToString();
                txtEnfermedadPiel.Text = dr["EnfermedadPiel"].ToString();
                txtAdicciones.Text = dr["Adicciones"].ToString();
                txtMedicamentos.Text = dr["Medicamentos"].ToString();
                txtCirugias.Text = dr["Cirugias"].ToString();
                rbEmbarazo.SelectedValue = dr["Embarazo"].ToString();
                chCesarea.Checked = bool.Parse(dr["Cesarea"].ToString());
                chPartoNatural.Checked = bool.Parse(dr["PartoNatural"].ToString());
                chAborto.Checked = bool.Parse(dr["Aborto"].ToString());
                rbControlNatal.SelectedValue = dr["ControlNatal"].ToString();
                txtOtroControlNatal.Text = dr["OtroControlNatal"].ToString();

            }
            dr.Close();

        }

        void CargarInfoOdontologica()
        {
            SqlCommand sql = new SqlCommand("PNL_ConsultaInformacionOdontologica " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

                rbExpedienteDental.SelectedValue = dr["ExpedienteDental"].ToString();
                txtOdontologo.Text = dr["Odontologo"].ToString();
                ddlTamDientes.SelectedValue = dr["TamañoDientes"].ToString();
                rbCompletos.SelectedValue = dr["DientesCompletos"].ToString();
                rbSeparados.SelectedValue = dr["DientesSeparados"].ToString();
                rbGirados.SelectedValue = dr["DientesGirados"].ToString();
                rbApinonados.SelectedValue = dr["DientesApiñonados"].ToString();
                rbManchados.SelectedValue = dr["DientesManchados"].ToString();
                rbDesgaste.SelectedValue = dr["DientesDesgaste"].ToString();
                rbResinas.SelectedValue = dr["Resinas"].ToString();
                rbAmalgamas.SelectedValue = dr["Amalgamas"].ToString();
                rbCoronasMetalicas.SelectedValue = dr["CoronasMetalicas"].ToString();
                rbCoronasEsteticas.SelectedValue = dr["CoronasEsteticas"].ToString();
                rbEndodoncia.SelectedValue = dr["Endodoncia"].ToString();
                rbBlanqueamiento.SelectedValue = dr["Blanqueamiento"].ToString();
                rbIncrustacion.SelectedValue = dr["Incrustacion"].ToString();
                txtOtro.Text = dr["OtroTratamiento"].ToString();
                ddlProtesis.SelectedValue = dr["IdProtesis"].ToString();
                rbBraquets.SelectedValue = dr["Braquets"].ToString();
                rbRetenedores.SelectedValue = dr["Retenedores"].ToString();
                rbImplantes.SelectedValue = dr["Implantes"].ToString();
                txtAditamento.Text = dr["OtroAditamento"].ToString();
                rbPuesto.SelectedValue = dr["AditamentoEnDesaparicion"].ToString();
                txtAusenciasDentales.Text = dr["AusenciaDental"].ToString();
                txtHabitosDentales.Text = dr["HabitosDentales"].ToString();



            }
            dr.Close();
        }

        void CargarOtros()
        {
            SqlCommand sql = new SqlCommand("PNL_consultaOtraInformacion " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

                chbDetencion.Checked = bool.Parse(dr["Detencion"].ToString());
                chbAllamiento.Checked = bool.Parse(dr["Allanamiento"].ToString());
                chbHostigamiento.Checked = bool.Parse(dr["Hostigamiento"].ToString());
                chbAmenazas.Checked = bool.Parse(dr["Amenazas"].ToString());
                chbLesiones.Checked = bool.Parse(dr["Lesiones"].ToString());
                chbDisposicionDinero.Checked = bool.Parse(dr["DisposicionDinero"].ToString());
                chbProblemasVecinales.Checked = bool.Parse(dr["ProblemasVecinales"].ToString());
                chbProblemasFamiliares.Checked = bool.Parse(dr["ProblemasFamiliares"].ToString());
                chbActitudNerviosa.Checked = bool.Parse(dr["ActitudNerviosa"].ToString());
                chbMovimientosCB.Checked = bool.Parse(dr["MovimientoCuentaBancaria"].ToString());
                chbDesaparecido.Checked = bool.Parse(dr["ComunicacionDesaparecido"].ToString());
                chbCaptores.Checked = bool.Parse(dr["ComunicacionCaptores"].ToString());
                chbSolicitud.Checked = bool.Parse(dr["SolicitudParaDejarloLibre"].ToString());
                chbInternet.Checked = bool.Parse(dr["ComInternetParadero"].ToString());
                chbParadero.Checked = bool.Parse(dr["ComPersonasParadero"].ToString());

            }
            dr.Close();

        }

        /*void CargarCausales()
        {

            SqlCommand sql = new SqlCommand("PNL_ConsultaCausalesDesaparicion " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                chbPropiaVoluntad.Checked = bool.Parse(dr["PropiaVoluntad"].ToString());
                chbSustraccionMenores.Checked = bool.Parse(dr["SustraccionMenores"].ToString());
                chbSalud.Checked = bool.Parse(dr["Salud"].ToString());
                chbAdicciones.Checked = bool.Parse(dr["Adicciones"].ToString());
                chbMigracion.Checked = bool.Parse(dr["Migracion"].ToString());
                chbComisionDelito.Checked = bool.Parse(dr["ComisionDelito"].ToString());
                chbLevantons.Checked = bool.Parse(dr["Levanton"].ToString());
                chbDetenido.Checked = bool.Parse(dr["Detenido"].ToString());
                chbVictimaDelito.Checked = bool.Parse(dr["VictimaDelito"].ToString());
                chbAccidentes.Checked = bool.Parse(dr["Accidentes"].ToString());
                chbProblemasFamiliaresCausales.Checked = bool.Parse(dr["ProblemasFamiliares"].ToString());
                chbRelacionesPersonales.Checked = bool.Parse(dr["RelacionesPersonales"].ToString());
                chbMotivosLaborales.Checked = bool.Parse(dr["MotivosLaborales"].ToString());
                chbDesparicion.Checked = bool.Parse(dr["DesaparicionForzada"].ToString());
                if (dr["Levanton"].ToString()=="True")
                {
                    ddlTipo.Visible = true;
                }
                ddlTipo.SelectedValue = dr["IdTipoSujeto"].ToString();
                chbSeDesconoce.Checked = bool.Parse(dr["SeDesconoce"].ToString());
            }
            dr.Close();

        }*/


        void CargarCausales()
        {

            SqlCommand sql = new SqlCommand("PNL_ConsultaCausalesDesaparicion " + ID_CARPETA.Text + "," + ID_MUNICIPIO_CARPETA.Text + "," + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                rbPropiaVoluntad.Checked = bool.Parse(dr["PropiaVoluntad"].ToString());
                rbSustraccionMenores.Checked = bool.Parse(dr["SustraccionMenores"].ToString());
                rbSalud.Checked = bool.Parse(dr["Salud"].ToString());
                rbAddicciones.Checked = bool.Parse(dr["Adicciones"].ToString());
                rbMigracion.Checked = bool.Parse(dr["Migracion"].ToString());
                rbComisionDelito.Checked = bool.Parse(dr["ComisionDelito"].ToString());
                rbLevanton.Checked = bool.Parse(dr["Levanton"].ToString());
                rbDetenido.Checked = bool.Parse(dr["Detenido"].ToString());
                rbVictimaDelito.Checked = bool.Parse(dr["VictimaDelito"].ToString());
                rbAccidentes.Checked = bool.Parse(dr["Accidentes"].ToString());
                rbProblemasFamiliares.Checked = bool.Parse(dr["ProblemasFamiliares"].ToString());
                rbRelacionesPersonales.Checked = bool.Parse(dr["RelacionesPersonales"].ToString());
                rbMotivosLaborales.Checked = bool.Parse(dr["MotivosLaborales"].ToString());
                rbDesaparicionForzada.Checked = bool.Parse(dr["DesaparicionForzada"].ToString());
                if (dr["Levanton"].ToString() == "True")
                {
                    rb_ddlTipo.Visible = true;
                }
                rb_ddlTipo.SelectedValue = dr["IdTipoSujeto"].ToString();
                rbSeDesconoce.Checked = bool.Parse(dr["SeDesconoce"].ToString());
            }
            dr.Close();
        }





        protected void btnAgregarDonante_Click(object sender, EventArgs e)
        {
            Response.Redirect("PNLDonante.aspx?op=Agregar");
        }



        protected void btnAgregarFotografia_Click(object sender, EventArgs e)
        {
            Response.Redirect("PNLFotografia.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void btnLocalizacion_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("PNLLocalizacion.aspx?op=Agregar");
        }



        void CargarOfendidoParaComparar()
        {
            SqlCommand sql = new SqlCommand("SELECT IdPersona from PNL_DATOS_GENERALES where IdPersona= " + ddlOfendido.SelectedValue, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                //ddlEtnia.SelectedValue = dr["IdEtnia"].ToString();
                //txtUltimoAvistamiento.Text = dr["FechaUltimoAvistamiento"].ToString();
                //ddlUltimaActividad.SelectedValue = dr["IdActividad"].ToString();
                ////  ddlOfendido.SelectedValue = dr["IdActividad"].ToString();
                //ddlOfendido.SelectedValue = dr["IDPERSONA"].ToString();

                lbltrue.Text = dr["IdPersona"].ToString();

                //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                btnMediaFiliacion.Visible = false;
                btnSeniasParticulares.Visible = false;
                btnAgregarDonante.Visible = false;
                btnAgregarFotografia.Visible = false;
                btnLocalizacion.Visible = false;
                btnagregarVestimenta.Visible = false;



            }
            dr.Close();

        }

        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            lblError.Text = ""; 

            DateTime dt1 = new DateTime();
            dt1 = Convert.ToDateTime(txtUltimoAvistamiento.Text);
            if (dt1.Date > DateTime.Now.Date)
            {
                lblError.Text = "FECHA DE ULTIMO AVISTAMIENTO MAYOR A LA FECHA ACTUAL";
            }
            //MessageBox.Show("fecha mayor a hoY"); 
            //    else 
            //MessageBox.Show("fecha menor a hoY");
            if (lblError.Text == "")
            {

                if (Session["op"].ToString() == "Agregar")
                {

                    CargarOfendidoParaComparar();
                    if (ddlOfendido.SelectedValue == "0" || ddlOfendido.SelectedValue == lbltrue.Text)
                    {
                        string script = @"<script type='text/javascript'>
                                alert('YA EXISTE UN REGISTRO A NOMBRE DE LA PERSONA QUE DESEA INGRESAR, FAVOR DE EDITAR O COMPLEMENTAR EL EXISTENTE O BIEN, SELECCIONE UN OFENDIDO DISTINTO.');  </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        lblEstatus.Text = "INTENTELO NUEVEMENTE";
                    }



                    else
                    {

                        /*INSERTA LOS DATOS GENERALES*/
                        PGJ.PNL_InsertaDatosGenerales(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ddlEtnia.SelectedValue), DateTime.Parse(txtUltimoAvistamiento.Text), short.Parse(ddlUltimaActividad.SelectedValue));

                        /*INSERTA PERTENENCIA SOCIAL*/
                        PGJ.PNL_InsertaPertenenciaSocial(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), txtONG.Text, txtSindicalista.Text, txtReinsertado.Text, txtGrupoReligioso.Text, txtOrgEstatal.Text, txtDH.Text, txtOtros.Text);

                        /*INSERTA INFORMACIÓN FINANCIERA*/

                        PGJ.PNL_InsertaInfoFinanciera(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), short.Parse(ddlBanco.SelectedValue), txtNumCuenta.Text, txtTipoCuenta.Text, short.Parse(ddlBanco0.SelectedValue), txtNumTarjetaCredito.Text, short.Parse(ddlBanco1.SelectedValue), txtNumTarjetaDebito.Text, txtTarjetaDepartamental.Text, txtNumTarjetaDepartamental.Text);

                        /*INSERTA DISCAPACIDADES*/
                        PGJ.PNL_InsertaDiscapacidades(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), short.Parse(ddlDiscapacidadMental.SelectedValue), txtDiscapacidadMental.Text, short.Parse(ddlDiscapacidadFisica.SelectedValue), txtDiscapacidadFisica.Text, txtPadecimientos.Text, txtSistematicas.Text, txtEnfermedadMental.Text, txtEnfermedadPiel.Text, txtAdicciones.Text, txtMedicamentos.Text, txtCirugias.Text, short.Parse(rbEmbarazo.SelectedValue), chCesarea.Checked, chPartoNatural.Checked, chAborto.Checked, short.Parse(rbControlNatal.SelectedValue), txtOtroControlNatal.Text);

                        /*INSERTA INFORMACIÓN ODONTOLÓGICA*/
                        PGJ.PNL_InsertaInformacionOdontologica(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), short.Parse(rbExpedienteDental.SelectedValue), txtOdontologo.Text, short.Parse(ddlTamDientes.SelectedValue), short.Parse(rbCompletos.SelectedValue), short.Parse(rbSeparados.SelectedValue), short.Parse(rbGirados.SelectedValue), short.Parse(rbApinonados.SelectedValue), short.Parse(rbManchados.SelectedValue), short.Parse(rbDesgaste.SelectedValue), short.Parse(rbResinas.SelectedValue), short.Parse(rbAmalgamas.SelectedValue), short.Parse(rbCoronasMetalicas.SelectedValue), short.Parse(rbCoronasEsteticas.SelectedValue), short.Parse(rbEndodoncia.SelectedValue), short.Parse(rbBlanqueamiento.SelectedValue), short.Parse(rbIncrustacion.SelectedValue), txtOtro.Text, short.Parse(ddlProtesis.SelectedValue), short.Parse(rbBraquets.SelectedValue), short.Parse(rbRetenedores.SelectedValue), short.Parse(rbImplantes.SelectedValue), txtOtro.Text, short.Parse(rbPuesto.SelectedValue), txtAusenciasDentales.Text, txtHabitosDentales.Text);

                        /*INSERTA OTROS DATOS*/
                        PGJ.PNL_InsertaOtraInformacion(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), chbDetencion.Checked, chbAllamiento.Checked, chbHostigamiento.Checked, chbAmenazas.Checked, chbLesiones.Checked, chbDisposicionDinero.Checked, chbProblemasVecinales.Checked, chbProblemasFamiliares.Checked, chbActitudNerviosa.Checked, chbMovimientosCB.Checked, chbDesaparecido.Checked, chbCaptores.Checked, chbSolicitud.Checked, chbInternet.Checked, chbParadero.Checked);

                        /*INSERTA CAUSALES DE DESAPARICION*/
                        //PGJ.PNL_InsertaCausalesDesaparicion(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), chbPropiaVoluntad.Checked, chbSustraccionMenores.Checked, chbSalud.Checked, chbAdicciones.Checked, chbMigracion.Checked, chbComisionDelito.Checked, chbLevantons.Checked, chbDetenido.Checked, chbVictimaDelito.Checked, chbAccidentes.Checked, chbProblemasFamiliaresCausales.Checked, chbRelacionesPersonales.Checked, chbMotivosLaborales.Checked
                        //    , chbDesparicion.Checked, int.Parse(ddlTipo.SelectedValue), chbSeDesconoce.Checked);

                        PGJ.PNL_InsertaCausalesDesaparicion(0, int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()),
                             rbPropiaVoluntad.Checked, rbSustraccionMenores.Checked, rbSalud.Checked, rbAddicciones.Checked, rbMigracion.Checked, rbComisionDelito.Checked, rbLevanton.Checked, rbDetenido.Checked, rbVictimaDelito.Checked, rbAccidentes.Checked, rbProblemasFamiliares.Checked, rbRelacionesPersonales.Checked, rbMotivosLaborales.Checked, rbDesaparicionForzada.Checked, int.Parse(rb_ddlTipo.SelectedValue), rbSeDesconoce.Checked);

                        //string icausal = ""+(0 + int.Parse(ID_CARPETA.Text) + short.Parse(Session["IdMunicipio"].ToString()) + int.Parse(ddlOfendido.SelectedValue.ToString()) +
                        //     rbPropiaVoluntad.Checked + rbSustraccionMenores.Checked + rbSalud.Checked + rbAddicciones.Checked + rbMigracion.Checked + rbComisionDelito.Checked + rbLevanton.Checked + rbDetenido.Checked + rbVictimaDelito.Checked + rbAccidentes.Checked + rbProblemasFamiliares.Checked + rbRelacionesPersonales.Checked + rbMotivosLaborales.Checked + rbDesaparicionForzada.Checked + int.Parse(ddlTipo.SelectedValue) + rbSeDesconoce.Checked);

                        //lblEstatus.Text = icausal;
                        
                        

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2,
                        "Inserta DATOS GENERALES: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() +
                        ", IdPersona= " + ID_PERSONA.Text + ", Etnia= " + ddlEtnia.SelectedItem + ", Fecha ultimo avistamiento= " + txtUltimoAvistamiento.Text +
                        ", Ultima actividad= " + ddlUltimaActividad.SelectedItem + ",PERTENENCIA SOCIAL: ONG= " + txtONG.Text + ", Sindicalista= " + 
                        txtSindicalista.Text + ", Reinsertado= " + txtReinsertado.Text + ", Grupo religioso= " + txtGrupoReligioso.Text + ", Org estatal= " +
                        txtOrgEstatal.Text + ", Derechos humanos= " + txtDH.Text + ", Otros= " + txtOtros.Text + ", INFORMACIÓN FINANCIERA: Banco = " + ddlBanco.SelectedItem
                        + ", Num Cuenta = " + txtNumCuenta.Text + ", Tipo de cuenta = " + txtTipoCuenta.Text + ", Banco crédito = " + ddlBanco0.SelectedItem +
                        ", Num tarjeta crédito = " + txtNumTarjetaCredito.Text + ", Banco tarjeta crédito = " + ddlBanco1.SelectedItem + ", Tarjeta de débito = "
                        + txtNumTarjetaDebito.Text + ", Tarjeta departamental = " + txtTarjetaDepartamental.Text + ", Num tarjeta departamental = " + 
                        txtNumTarjetaDepartamental.Text + ", DISCAPACIDADES: Discapacidad mental= " + ddlDiscapacidadMental.SelectedItem + ", Discapacidad mental= " + 
                        txtDiscapacidadMental.Text + ", Discapacidad física= " + ddlDiscapacidadFisica.SelectedItem + ", Discapacidad física= " + 
                        txtDiscapacidadFisica.Text + ", Padecimientos= " + txtPadecimientos.Text + ", Enfermadades sistemáticas= " + txtSistematicas.Text + 
                        ", Enfermedad mental= " + txtEnfermedadMental.Text + ", Enfermedades piel= " + txtEnfermedadPiel.Text + ", Adicciones= " + txtAdicciones.Text + 
                        ", Medicamentos= " + txtMedicamentos.Text + ", Cirugias= " + txtCirugias.Text + ", Embarazo= " + rbEmbarazo.SelectedItem + ", Control natal= " 
                        + rbControlNatal.SelectedItem + ", Otro control natal= " + txtOtroControlNatal.Text + ", INFO ODNTOLOGICA: Odontólogo= " + txtOdontologo.Text + 
                        ", Tamaño dientes= " + ddlTamDientes.SelectedItem + ", Dientes completos= " + rbCompletos.SelectedValue + ", Dientes separados= " + 
                        rbSeparados.SelectedItem + ", Dientes girados= " + rbGirados.SelectedItem + ", Dientes apiñonados= " + rbApinonados.SelectedItem + 
                        ", Dientes manchados= " + rbManchados.SelectedItem + ", Dientes con desgaste= " + rbDesgaste.SelectedValue + ", Resinas= " + 
                        rbResinas.SelectedItem + ", Amalagamas= " + rbAmalgamas.SelectedItem + ", Coronas metálicas= " + rbCoronasMetalicas.SelectedItem + 
                        ", Coronas estéticas= " + rbCoronasEsteticas.SelectedItem + ", Endodoncia= " + rbEndodoncia.SelectedItem + ", Blanqueamiento= " + 
                        rbBlanqueamiento.SelectedItem + ", Incrustación= " + rbIncrustacion.SelectedItem + ", Otro= " + txtOtro.Text + ", Prótesis dental= " + 
                        ddlProtesis.SelectedItem + ", Braquets= " + rbBraquets.SelectedItem + ", Retenedores= " + rbRetenedores.SelectedItem + ", Implantes= " + 
                        rbImplantes.SelectedItem + ", Otro= " + txtOtro.Text + ", Llevaba puesto aditamento= " + rbPuesto.SelectedItem + ", Ausencias dentales= " + 
                        txtAusenciasDentales.Text + ", Hábitos dentales= " + txtHabitosDentales.Text, int.Parse(Session["IdModuloBitacora"].ToString()));


                        btnMediaFiliacion.Visible = true;
                        btnSeniasParticulares.Visible = true;
                        btnAgregarDonante.Visible = true;
                        btnAgregarFotografia.Visible = true;
                        btnLocalizacion.Visible = true;
                        btnagregarVestimenta.Visible = true;
                        lblEstatus.Text = "DATOS GUARDADOS";
                        Panel3.Enabled = false;
                        TabContainer1.Enabled = false;
                        Panel17.Enabled = false;
                        btnGuardarDatos.Enabled = false;


                    }
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    try
                    {

                        /*MODIFICA LOS DATOS GENERALES*/
                        PGJ.ActualizaDatosGenerales(int.Parse(ID_DATOS_GENERALES.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), int.Parse(ddlEtnia.SelectedValue), DateTime.Parse(txtUltimoAvistamiento.Text), short.Parse(ddlUltimaActividad.SelectedValue));

                        /*MODIFICA PERTENENCIA SOCIAL*/
                        PGJ.PNL_ActualizaPertenenciaSocial(int.Parse(ID_PERTENENCIA_SOCIAL.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), txtONG.Text, txtSindicalista.Text, txtReinsertado.Text, txtGrupoReligioso.Text, txtOrgEstatal.Text, txtDH.Text, txtOtros.Text);

                        /*MODIFICA INFORMACIÓN FINANCIERA*/

                        PGJ.PNL_ActualizaInfoFinanciera(int.Parse(ID_INFO_FINANCIERA.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), short.Parse(ddlBanco.SelectedValue), txtNumCuenta.Text, txtTipoCuenta.Text, short.Parse(ddlBanco0.SelectedValue), txtNumTarjetaCredito.Text, short.Parse(ddlBanco1.SelectedValue), txtNumTarjetaDebito.Text, txtTarjetaDepartamental.Text, txtNumTarjetaDepartamental.Text);

                        /*MODIFICA DISCAPACIDADES*/
                        PGJ.PNL_ActualizaDiscapacidades(int.Parse(ID_DISCAPACIDADES.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), short.Parse(ddlDiscapacidadMental.SelectedValue), txtDiscapacidadMental.Text, short.Parse(ddlDiscapacidadFisica.SelectedValue), txtDiscapacidadFisica.Text, txtPadecimientos.Text, txtSistematicas.Text, txtEnfermedadMental.Text, txtEnfermedadPiel.Text, txtAdicciones.Text, txtMedicamentos.Text, txtCirugias.Text, short.Parse(rbEmbarazo.SelectedValue), chCesarea.Checked, chPartoNatural.Checked, chAborto.Checked, short.Parse(rbControlNatal.SelectedValue), txtOtroControlNatal.Text);

                        /*MODIFICA INFORMACIÓN ODONTOLÓGICA*/
                        PGJ.PNL_ActualizaInformacionOdontologica(int.Parse(ID_INFO_ODONTOLOGICA.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), short.Parse(rbExpedienteDental.SelectedValue), txtOdontologo.Text, short.Parse(ddlTamDientes.SelectedValue), short.Parse(rbCompletos.SelectedValue), short.Parse(rbSeparados.SelectedValue), short.Parse(rbGirados.SelectedValue), short.Parse(rbApinonados.SelectedValue), short.Parse(rbManchados.SelectedValue), short.Parse(rbDesgaste.SelectedValue), short.Parse(rbResinas.SelectedValue), short.Parse(rbAmalgamas.SelectedValue), short.Parse(rbCoronasMetalicas.SelectedValue), short.Parse(rbCoronasEsteticas.SelectedValue), short.Parse(rbEndodoncia.SelectedValue), short.Parse(rbBlanqueamiento.SelectedValue), short.Parse(rbIncrustacion.SelectedValue), txtOtro.Text, short.Parse(ddlProtesis.SelectedValue), short.Parse(rbBraquets.SelectedValue), short.Parse(rbRetenedores.SelectedValue), short.Parse(rbImplantes.SelectedValue), txtOtro.Text, short.Parse(rbPuesto.SelectedValue), txtAusenciasDentales.Text, txtHabitosDentales.Text);

                        /*MODIFICA OTROS DATOS*/
                        PGJ.PNL_ActualizaOtraInformacion(int.Parse(ID_OTRA_INFO.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), chbDetencion.Checked, chbAllamiento.Checked, chbHostigamiento.Checked, chbAmenazas.Checked, chbLesiones.Checked, chbDisposicionDinero.Checked, chbProblemasVecinales.Checked, chbProblemasFamiliares.Checked, chbActitudNerviosa.Checked, chbMovimientosCB.Checked, chbDesaparecido.Checked, chbCaptores.Checked, chbSolicitud.Checked, chbInternet.Checked, chbParadero.Checked);

                        /*MODIFICA CAUSALES DESAPARICIÓN*/
                        //PGJ.PNL_ActualizaCausalesDesaparicion(int.Parse(ID_CAUSALES.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), chbPropiaVoluntad.Checked, chbSustraccionMenores.Checked, chbSalud.Checked, chbAdicciones.Checked, chbMigracion.Checked, chbComisionDelito.Checked, chbLevantons.Checked, chbDetenido.Checked, chbVictimaDelito.Checked, chbAccidentes.Checked, chbProblemasFamiliaresCausales.Checked, chbRelacionesPersonales.Checked, chbMotivosLaborales.Checked
                        //, chbDesparicion.Checked, int.Parse(ddlTipo.SelectedValue), chbSeDesconoce.Checked);

                        PGJ.PNL_ActualizaCausalesDesaparicion(int.Parse(ID_CAUSALES.Text), int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text),
                             rbPropiaVoluntad.Checked, rbSustraccionMenores.Checked, rbSalud.Checked, rbAddicciones.Checked, rbMigracion.Checked, rbComisionDelito.Checked, rbLevanton.Checked, rbDetenido.Checked, rbVictimaDelito.Checked, rbAccidentes.Checked, rbProblemasFamiliares.Checked, rbRelacionesPersonales.Checked, rbMotivosLaborales.Checked, rbDesaparicionForzada.Checked, int.Parse(rb_ddlTipo.SelectedValue), rbSeDesconoce.Checked);

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza DATOS GENERALES: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ID_PERSONA.Text + ", Etnia= " + ddlEtnia.SelectedItem + ", Fecha ultimo avistamiento= " + txtUltimoAvistamiento.Text + ", Ultima actividad= " + ddlUltimaActividad.SelectedItem + ",PERTENENCIA SOCIAL: ONG= " + txtONG.Text + ", Sindicalista= " + txtSindicalista.Text + ", Reinsertado= " + txtReinsertado.Text + ", Grupo religioso= " + txtGrupoReligioso.Text + ", Org estatal= " + txtOrgEstatal.Text + ", Derechos humanos= " + txtDH.Text + ", Otros= " + txtOtros.Text + ", INFORMACIÓN FINANCIERA: Banco = " + ddlBanco.SelectedItem + ", Num Cuenta = " + txtNumCuenta.Text + ", Tipo de cuenta = " + txtTipoCuenta.Text + ", Banco crédito = " + ddlBanco0.SelectedItem + ", Num tarjeta crédito = " + txtNumTarjetaCredito.Text + ", Banco tarjeta crédito = " + ddlBanco1.SelectedItem + ", Tarjeta de débito = " + txtNumTarjetaDebito.Text + ", Tarjeta departamental = " + txtTarjetaDepartamental.Text + ", Num tarjeta departamental = " + txtNumTarjetaDepartamental.Text + ", DISCAPACIDADES: Discapacidad mental= " + ddlDiscapacidadMental.SelectedItem + ", Discapacidad mental= " + txtDiscapacidadMental.Text + ", Discapacidad física= " + ddlDiscapacidadFisica.SelectedItem + ", Discapacidad física= " + txtDiscapacidadFisica.Text + ", Padecimientos= " + txtPadecimientos.Text + ", Enfermadades sistemáticas= " + txtSistematicas.Text + ", Enfermedad mental= " + txtEnfermedadMental.Text + ", Enfermedades piel= " + txtEnfermedadPiel.Text + ", Adicciones= " + txtAdicciones.Text + ", Medicamentos= " + txtMedicamentos.Text + ", Cirugias= " + txtCirugias.Text + ", Embarazo= " + rbEmbarazo.SelectedItem + ", Control natal= " + rbControlNatal.SelectedItem + ", Otro control natal= " + txtOtroControlNatal.Text + ", INFO ODNTOLOGICA: Odontólogo= " + txtOdontologo.Text + ", Tamaño dientes= " + ddlTamDientes.SelectedItem + ", Dientes completos= " + rbCompletos.SelectedValue + ", Dientes separados= " + rbSeparados.SelectedItem + ", Dientes girados= " + rbGirados.SelectedItem + ", Dientes apiñonados= " + rbApinonados.SelectedItem + ", Dientes manchados= " + rbManchados.SelectedItem + ", Dientes con desgaste= " + rbDesgaste.SelectedValue + ", Resinas= " + rbResinas.SelectedItem + ", Amalagamas= " + rbAmalgamas.SelectedItem + ", Coronas metálicas= " + rbCoronasMetalicas.SelectedItem + ", Coronas estéticas= " + rbCoronasEsteticas.SelectedItem + ", Endodoncia= " + rbEndodoncia.SelectedItem + ", Blanqueamiento= " + rbBlanqueamiento.SelectedItem + ", Incrustación= " + rbIncrustacion.SelectedItem + ", Otro= " + txtOtro.Text + ", Prótesis dental= " + ddlProtesis.SelectedItem + ", Braquets= " + rbBraquets.SelectedItem + ", Retenedores= " + rbRetenedores.SelectedItem + ", Implantes= " + rbImplantes.SelectedItem + ", Otro= " + txtOtro.Text + ", Llevaba puesto aditamento= " + rbPuesto.SelectedItem + ", Ausencias dentales= " + txtAusenciasDentales.Text + ", Hábitos dentales= " + txtHabitosDentales.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                        lblEstatus.Text = "DATOS GUARDADOS";
                        Panel3.Enabled = false;
                        TabContainer1.Enabled = false;
                        Panel17.Enabled = false;
                        btnGuardarDatos.Enabled = false;

                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
        }

        protected void rbControlNatal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbControlNatal.SelectedValue == "4")
            {
                txtOtroControlNatal.Visible = true;
                Label31.Visible = true;
                SetFocus(txtOtroControlNatal);
            }
            else
            {
                txtOtroControlNatal.Visible = false;
                Label31.Visible = false;
                SetFocus(rbControlNatal);
            }
        }

        protected void btnMediaFiliacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("PNLMediaFiliacion.aspx?op=Agregar");
        }

        protected void btnSeniasParticulares_Click(object sender, EventArgs e)
        {
            Response.Redirect("PNLSeniasParticulares.aspx?op=Agregar");
        }

        protected void btnagregarVestimenta_Click(object sender, EventArgs e)
        {
            if (ddlOfendido.SelectedValue == "0")
            {
                lblEstatus.Text = "SELECCIONA PERSONA";
            }
            else
            {


                if (Session["op"].ToString() == "Agregar")
                {

                    PGJ.PNL_InsertaVestimenta(int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ddlVestimenta.SelectedValue), txtDescVestimenta.Text);

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta DATOS GENERALES: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ID_PERSONA.Text+", Vestimenta seleccionada: "+ddlVestimenta.SelectedItem+", Descripción vestimenta: "+ txtDescVestimenta.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                


                    gvVestimenta.DataSourceID = "dsConsultaVestimenta";
                    gvVestimenta.DataBind();
                    txtDescVestimenta.Text = "";
                }


                else if (Session["op"].ToString() == "Modificar")
                {
                    try
                    {
                        PGJ.PNL_InsertaVestimenta(int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), int.Parse(ddlVestimenta.SelectedValue), txtDescVestimenta.Text);

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta DATOS GENERALES: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ID_PERSONA.Text + ", Vestimenta seleccionada: " + ddlVestimenta.SelectedItem + ", Descripción vestimenta: " + txtDescVestimenta.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                

                        gvVestimenta.DataSourceID = "dsConsultaVestimenta";
                        gvVestimenta.DataBind();
                        txtDescVestimenta.Text = "";
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
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
            
            
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde PNL Datos principales", int.Parse(Session["IdModuloBitacora"].ToString()));

            //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());

        }

        protected void chbLevantons_CheckedChanged(object sender, EventArgs e)
        {

            if (chbLevantons.Checked == true)
            {               
               
                lblTipo.Visible = true;
                ddlTipo.Visible = true;
            }
            else
            {

                lblTipo.Visible = false;
                ddlTipo.Visible = false;
            }
        }


        //evento del radiobutton7 para mostrar el combobox con el tipo de privacion
        protected void _CheckedChanged(object sender, EventArgs e)
        {
            if ( rbLevanton.Checked == true)
            {                
                rb_lblTipo.Visible = true;
                rb_ddlTipo.Visible = true;
            }
            else
            {
                rb_lblTipo.Visible = false;
                rb_ddlTipo.Visible = false;
            }
        }
    }
}