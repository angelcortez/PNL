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
    public partial class PNLDonante : System.Web.UI.Page
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
                //TRAE EL USUARIO, PUESTO, UNIDAD Y LA OPERACIÓN. ADEMÁS DE CARGAR LA FECHA ACTUAL// 
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();

                cargarFecha();
                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                if (Session["op"].ToString() == "Agregar")
                {
                    cmdMuestra.Enabled = false;
                    //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];                  
                    //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();
                    ////Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();
                    cargarOfendido();

                    lblOperacion.Text = "AGREGAR DATOS DE LA LIBERACIÓN";


                    //LLENAR COMBOS PARA INSERTAR POR PRIMERA VEZ
                   
                    PGJ.CargaCombo(ddlParentesco, "CAT_PARENTESCO", "ID_PRNTSCO", "PRNTSCO");
                    PGJ.CargaCombo(ddlParentescoTutor, "CAT_PARENTESCO", "ID_PRNTSCO", "PRNTSCO");
                    PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                    PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                    PGJ.CargaCombo(ddlIdentificacionTutor, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                    PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");

                    cargarAgregarPersona();

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DATOS DE LA LIBERACIÓN";
                    cmdMuestra.Enabled = true;

                    try
                    {

                        ID_DONANTE.Text = Request.QueryString["ID_DONANTE"];
                        //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                        ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                        //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                        ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                        //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                        ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                        //Session["ID_DATOS_GENERALES"] = Request.QueryString["ID_DATOS_GENERALES"];
                        ID_DATOS_GENERALES.Text = Session["ID_DATOS_GENERALES"].ToString();

                        //Session["ID_PERTENENCIA_SOCIAL"] = Request.QueryString["ID_PERTENENCIA_SOCIAL"];
                        ID_PERTENENCIA_SOCIAL.Text = Session["ID_PERTENENCIA_SOCIAL"].ToString();

                        //Session["ID_INFO_FINANCIERA"] = Request.QueryString["ID_INFO_FINANCIERA"];
                        ID_INFO_FINANCIERA.Text = Session["ID_INFO_FINANCIERA"].ToString();

                        //Session["ID_INFO_ODONTOLOGICA"] = Request.QueryString["ID_INFO_ODONTOLOGICA"];
                        ID_INFO_ODONTOLOGICA.Text = Session["ID_INFO_ODONTOLOGICA"].ToString();

                        //Session["ID_DISCAPACIDADES"] = Request.QueryString["ID_DISCAPACIDADES"];
                        ID_DISCAPACIDADES.Text = Session["ID_DISCAPACIDADES"].ToString();

                        //Session["ID_OTRA_INFO"] = Request.QueryString["ID_OTRA_INFO"];
                        ID_OTRA_INFO.Text = Session["ID_OTRA_INFO"].ToString();

                       
                        PGJ.CargaCombo(ddlParentesco, "CAT_PARENTESCO", "ID_PRNTSCO", "PRNTSCO");
                        PGJ.CargaCombo(ddlParentescoTutor, "CAT_PARENTESCO", "ID_PRNTSCO", "PRNTSCO");
                        PGJ.CargaCombo(ddlSexo, "CAT_SEXO", "ID_SEXO", "SEXO");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        PGJ.CargaCombo(ddlIdentificacionTutor, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        ConsultaDonante();

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consultó Donante con IdDonante =" + ID_DONANTE.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));


                        cargarOfendido();

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

      
        void cargarAgregarPersona()
        {
            
            Session["ID_PAIS_DOM"] = 1;
            ddlPais.SelectedValue = Session["ID_PAIS_DOM"].ToString();
            consultaPaisEstadoDom();
            Session["ID_ESTADO_DOM"] = 28;
            ddlEntidad.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
            consultaEstadoMunicipioDom();
            Session["ID_MUNICIPIO_DOM"] = "3";
            ddlMunicipio.SelectedValue = Session["ID_MUNICIPIO_DOM"].ToString();
            consultaMunicipioLocalidad();
            Session["ID_LOCALIDAD"] = 19;
            ddlLocalidadDom.SelectedValue = "19";
            ddlColonia.SelectedValue = "2";
            consultaLocalidadColonia();
            ddlCalle.SelectedValue = "5";
            consultaLocalidadCalle();
            ddlEntreCalle.SelectedValue = "5";
            consultaLocalidadEntreCalle();
            ddlYcalle.SelectedValue = "5";
            consultaLocalidadYCalle();
            ddlSexo.SelectedValue = "0";

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






        //protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_PAIS"] = ddlPais.SelectedValue.ToString();
        //    consultaPaisEstado();
        //}

        void consultaPaisEstado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEntidad.DataSource = estado;
            ddlEntidad.DataValueField = "ID_ESTDO";
            ddlEntidad.DataTextField = "ESTDO";
            ddlEntidad.DataBind();
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

        protected void ddlPaisDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_PAIS_DOM"] = ddlPais.SelectedValue.ToString();
            consultaPaisEstadoDom();
        }
        void consultaPaisEstadoDom()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS_DOM"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEntidad.DataSource = estado;
            ddlEntidad.DataValueField = "ID_ESTDO";
            ddlEntidad.DataTextField = "ESTDO";
            ddlEntidad.DataBind();
        }

        protected void ddlEstadoDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO_DOM"] = ddlEntidad.SelectedValue.ToString();
            consultaEstadoMunicipioDom();
        }
        void consultaEstadoMunicipioDom()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS_DOM"].ToString()), short.Parse(Session["ID_ESTADO_DOM"].ToString()))
                            select new { c.ID_MNCPIO, c.MNCPIO };
            ddlMunicipio.DataSource = municipio;
            ddlMunicipio.DataValueField = "ID_MNCPIO";
            ddlMunicipio.DataTextField = "MNCPIO";
            ddlMunicipio.DataBind();
        }

        protected void ddlMunicipioDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MUNICIPIO_DOM"] = ddlMunicipio.SelectedValue.ToString();
            consultaMunicipioLocalidad();
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

        protected void ddlLocalidadDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_LOCALIDAD"] = ddlLocalidadDom.SelectedValue.ToString();
            consultaLocalidadColonia();
            consultaLocalidadCalle();
            consultaLocalidadEntreCalle();
            consultaLocalidadYCalle();
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



        protected void cmdMuestra_Click(object sender, EventArgs e)
        {
            Response.Redirect("PNLPeritoRecolector.aspx?op=Agregar" + "&ID_DONANTE=" + ID_DONANTE.Text);
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
                    PGJ.InsertaDonantes(int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()),
                     txtNombre.Text, txtPaterno.Text, txtMaterno.Text, short.Parse(ddlSexo.SelectedValue), short.Parse(ddlIdentificacion.SelectedValue),
                     txtFolioIdentificacion.Text, short.Parse(ddlParentesco.SelectedValue),
                    short.Parse(ddlPais.SelectedValue), short.Parse(ddlEntidad.SelectedValue), short.Parse(ddlMunicipio.SelectedValue), short.Parse(ddlLocalidadDom.SelectedValue),
                    short.Parse(ddlColonia.SelectedValue), int.Parse(ddlCalle.SelectedValue), int.Parse(ddlEntreCalle.SelectedValue), int.Parse(ddlYcalle.SelectedValue),
                    txtNumExt.Text, txtNumInt.Text, txtCP.Text, txtTelefono.Text,
                    txtTipoMuestra.Text, DateTime.Parse(txtFechaMuestra.Text), short.Parse(rbMenor.SelectedValue), txtNombreTutor.Text, txtPaternoTutor.Text,
                    txtMaternoTutor.Text, short.Parse(ddlParentescoTutor.SelectedValue), short.Parse(ddlIdentificacionTutor.SelectedValue),
                    txtFolioIdentificacionTutor.Text, short.Parse(rbTransfusion.SelectedValue), short.Parse(rbTransplante.SelectedValue),
                    short.Parse(rbEnfermedad.SelectedValue), txtCantidadDeMuestra.Text, txtAutoridadQueSolicitaTomaMuestra.Text, txtLugarRecoleccionIndicios.Text, txtHoraRecoleccion.Text);
                    DesactivarControles();
                    string query = @"select IdDonante=MAX(IdDonante) from PNL_DONANTES";
                    SqlCommand cmd = new SqlCommand(query, Data.CnnCentral);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        Session.Add("IdDonante", rd["IdDonante"].ToString());
                    }
                    rd.Close();


                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Donante con IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ddlOfendido.SelectedItem + ", Nombre donante= " + txtNombre.Text + ", Apellido paterno donante= " + txtPaterno.Text + ", Apellido materno donante= " + txtMaterno.Text + ", Sexo donante= " + ddlSexo.SelectedItem + ", Identificación donante= " +ddlIdentificacion.SelectedItem
                    + ", Folio identificación donante= " + txtFolioIdentificacion.Text + ", Parentesco del donante con ofendido= " +ddlParentesco.SelectedItem
                    + ",Originario y Domicilio. País= " + ddlPais.SelectedItem + ", Entidad= " + ddlEntidad.SelectedItem + ", Municipio= " + ddlMunicipio.SelectedItem + ", Localidad= " + ddlLocalidadDom.SelectedItem
                    + ", Colonia= " + ddlColonia.SelectedItem + ", Calle= " + ddlCalle.SelectedItem + ", Entre calle= " +ddlEntreCalle.SelectedItem + ", Y calle= " +ddlYcalle.SelectedItem
                    + ", N° exterior= " + txtNumExt.Text + ", N° interior= " + txtNumInt.Text + ", CP= " + txtCP.Text + ", Teléfono= " + txtTelefono.Text
                    + ", Tipo de muestra= " + txtTipoMuestra.Text + ", Fecha de muestra= " + txtFechaMuestra.Text + ", Donante menor de edad= " + rbMenor.SelectedItem + ", Nombre tutor= " + txtNombreTutor.Text + ", Paterno tutor= " + txtPaternoTutor.Text
                    + ", Materno tutor= " + txtMaternoTutor.Text + ", Parentesco del tutor= " +ddlParentescoTutor.SelectedItem + ", Identificación tutor= " +ddlIdentificacionTutor.SelectedItem
                    + ", Folio identificación tutor= " + txtFolioIdentificacionTutor.Text + ", Transfusión= " + rbTransfusion.SelectedValue + ", Transplante= " +rbTransplante.SelectedItem
                    + ", Enfermedad= "+ rbEnfermedad.SelectedItem + ", Cantidad de muestra= " + txtCantidadDeMuestra.Text + ", Autoridad que solicita muestra= " + txtAutoridadQueSolicitaTomaMuestra.Text + ", Lugar recolección indicios= " + txtLugarRecoleccionIndicios.Text + ", Hora recolección= " + txtHoraRecoleccion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    PGJ.ActualizaDonantes(int.Parse(ID_DONANTE.Text), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, short.Parse(ddlSexo.SelectedValue), short.Parse(ddlIdentificacion.SelectedValue),
                     txtFolioIdentificacion.Text, short.Parse(ddlParentesco.SelectedValue),
                    short.Parse(ddlPais.SelectedValue), short.Parse(ddlEntidad.SelectedValue), short.Parse(ddlMunicipio.SelectedValue), short.Parse(ddlLocalidadDom.SelectedValue),
                    short.Parse(ddlColonia.SelectedValue), int.Parse(ddlCalle.SelectedValue), int.Parse(ddlEntreCalle.SelectedValue), int.Parse(ddlYcalle.SelectedValue),
                    txtNumExt.Text, txtNumInt.Text, txtCP.Text, txtTelefono.Text,
                    txtTipoMuestra.Text, DateTime.Parse(txtFechaMuestra.Text), short.Parse(rbMenor.SelectedValue), txtNombreTutor.Text, txtPaternoTutor.Text,
                    txtMaternoTutor.Text, short.Parse(ddlParentescoTutor.SelectedValue), short.Parse(ddlIdentificacionTutor.SelectedValue),
                    txtFolioIdentificacionTutor.Text, short.Parse(rbTransfusion.SelectedValue), short.Parse(rbTransplante.SelectedValue),
                    short.Parse(rbEnfermedad.SelectedValue), txtCantidadDeMuestra.Text, txtAutoridadQueSolicitaTomaMuestra.Text, txtLugarRecoleccionIndicios.Text, txtHoraRecoleccion.Text);

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Donante con IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdDonante= " + ID_DONANTE.Text + ", Nombre donante= " + txtNombre.Text + ", Apellido paterno donante= " + txtPaterno.Text + ", Apellido materno donante= " + txtMaterno.Text + ", Sexo donante= " + ddlSexo.SelectedItem + ", Identificación donante= " + ddlIdentificacion.SelectedItem
                   + ", Folio identificación donante= " + txtFolioIdentificacion.Text + ", Parentesco del donante con ofendido= " + ddlParentesco.SelectedItem
                   + ",Originario y Domicilio. País= " + ddlPais.SelectedItem + ", Entidad= " + ddlEntidad.SelectedItem + ", Municipio= " + ddlMunicipio.SelectedItem + ", Localidad= " + ddlLocalidadDom.SelectedItem
                   + ", Colonia= " + ddlColonia.SelectedItem + ", Calle= " + ddlCalle.SelectedItem + ", Entre calle= " + ddlEntreCalle.SelectedItem + ", Y calle= " + ddlYcalle.SelectedItem
                   + ", N° exterior= " + txtNumExt.Text + ", N° interior= " + txtNumInt.Text + ", CP= " + txtCP.Text + ", Teléfono= " + txtTelefono.Text
                   + ", Tipo de muestra= " + txtTipoMuestra.Text + ", Fecha de muestra= " + txtFechaMuestra.Text + ", Donante menor de edad= " + rbMenor.SelectedItem + ", Nombre tutor= " + txtNombreTutor.Text + ", Paterno tutor= " + txtPaternoTutor.Text
                   + ", Materno tutor= " + txtMaternoTutor.Text + ", Parentesco del tutor= " + ddlParentescoTutor.SelectedItem + ", Identificación tutor= " + ddlIdentificacionTutor.SelectedItem
                   + ", Folio identificación tutor= " + txtFolioIdentificacionTutor.Text + ", Transfusión= " + rbTransfusion.SelectedValue + ", Transplante= " + rbTransplante.SelectedItem
                   + ", Enfermedad= " + rbEnfermedad.SelectedItem + ", Cantidad de muestra= " + txtCantidadDeMuestra.Text + ", Autoridad que solicita muestra= " + txtAutoridadQueSolicitaTomaMuestra.Text + ", Lugar recolección indicios= " + txtLugarRecoleccionIndicios.Text + ", Hora recolección= " + txtHoraRecoleccion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                

                }
                DesactivarControles();
                cmdGuardar.Visible = false;
                cmdMuestra.Enabled = true;
                string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }


        public void ConsultaDonante()
        {
            SqlCommand sql = new SqlCommand("PNL_CargaDonanteIndividual " + ID_DONANTE.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                ddlOfendido.SelectedValue = dr["IdPersona"].ToString();
                txtNombre.Text = dr["Nombre"].ToString();
                txtPaterno.Text = dr["Paterno"].ToString();
                txtMaterno.Text = dr["Materno"].ToString();
                ddlSexo.SelectedValue = dr["IdSexo"].ToString();
                ddlIdentificacion.SelectedValue = dr["IdIdentificacion"].ToString();
                txtFolioIdentificacion.Text = dr["FolioIdentificacion"].ToString();
                ddlParentesco.SelectedValue = dr["IdParentesco"].ToString();
                txtNumExt.Text = dr["NumeroExterior"].ToString();
                txtNumInt.Text = dr["NumeroInterior"].ToString();
                txtCP.Text = dr["CP"].ToString();
                txtTelefono.Text = dr["Telefono"].ToString();
                txtTipoMuestra.Text = dr["TipoMuestra"].ToString();
                txtFechaMuestra.Text = dr["FechaMuestra"].ToString();
                rbMenor.SelectedValue = dr["MenorEdad"].ToString();
                txtNombreTutor.Text = dr["NombreTutor"].ToString();
                txtPaternoTutor.Text = dr["PaternoTutor"].ToString();
                txtMaternoTutor.Text = dr["MaternoTutor"].ToString();
                ddlParentescoTutor.SelectedValue = dr["IdParentescoTutor"].ToString();
                ddlIdentificacionTutor.SelectedValue = dr["IdIdentificacionTutor"].ToString();
                txtFolioIdentificacionTutor.Text = dr["FolioIdentificacionTutor"].ToString();
                rbTransfusion.SelectedValue = dr["Trasfusion"].ToString();
                rbTransplante.SelectedValue = dr["Trasplante"].ToString();
                rbEnfermedad.SelectedValue = dr["EnfermedadInfecciosa"].ToString();
                txtCantidadDeMuestra.Text = dr["CantidadDeMuestra"].ToString();
                txtAutoridadQueSolicitaTomaMuestra.Text = dr["AutoridadQueSolicitaTomaMuestra"].ToString();
                txtLugarRecoleccionIndicios.Text = dr["LugarRecoleccionIndicios"].ToString();
                txtHoraRecoleccion.Text = dr["HoraRecoleccionMuestra"].ToString();

                Session["ID_PAIS_DOM"] = dr["IdPais"].ToString();
                ddlPais.SelectedValue = Session["ID_PAIS_DOM"].ToString();
                consultaPaisEstadoDom();

                Session["ID_ESTADO_DOM"] = dr["IdEntidad"].ToString();
                ddlEntidad.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
                consultaEstadoMunicipioDom();

                Session["ID_MUNICIPIO_DOM"] = dr["IdMunicipio"].ToString();
                ddlMunicipio.SelectedValue = Session["ID_MUNICIPIO_DOM"].ToString();
                consultaMunicipioLocalidad();

                Session["ID_LOCALIDAD"] = dr["Localidad"].ToString();
                ddlLocalidadDom.SelectedValue = Session["ID_LOCALIDAD"].ToString();

                ddlColonia.SelectedValue = dr["Colonia"].ToString();
                consultaLocalidadColonia();

                ddlCalle.SelectedValue = dr["Calle"].ToString();
                consultaLocalidadCalle();

                ddlEntreCalle.SelectedValue = dr["EntreCalle1"].ToString();
                consultaLocalidadEntreCalle();

                ddlYcalle.SelectedValue = dr["EntreCalle2"].ToString();
                consultaLocalidadYCalle();           
                         

               


            }
            dr.Close();
        }


        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("PNLDatosPrincipales.aspx?op=Modificar");


            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde Donante", int.Parse(Session["IdModuloBitacora"].ToString()));
            

            Response.Redirect("PNLDatosPrincipales.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Modificar" + "&ID_MUNICIPIO_CARPETA=" + Session["ID_MUNICIPIO_CARPETA"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_PERTENENCIA_SOCIAL=" + Session["ID_PERTENENCIA_SOCIAL"].ToString() + "&ID_INFO_FINANCIERA=" + Session["ID_INFO_FINANCIERA"].ToString() + "&ID_INFO_ODONTOLOGICA=" + Session["ID_INFO_ODONTOLOGICA"].ToString() + "&ID_DISCAPACIDADES=" + Session["ID_DISCAPACIDADES"].ToString() + "&ID_OTRA_INFO=" + Session["ID_OTRA_INFO"].ToString() + "&ID_CAUSALES=" + Session["ID_CAUSALES"].ToString());
       
        }

        void DesactivarControles()
        {

            Panel1.Enabled = false;
            Panel2.Enabled = false;
            Panel4.Enabled = false;
            Panel6.Enabled = false;
            
        
        }
    }
}