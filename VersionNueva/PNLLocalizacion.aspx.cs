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


namespace AtencionTemprana
{
    public partial class PNLLocalizacion : System.Web.UI.Page
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

               
                //Session["IdPNL"] = Request.QueryString["IdPNL"];
                //TRAER LOS ID QUE SE NECESITAN PARA ALMACENAR LA INFO EN LA TABLA//
                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                //TRAE EL USUARIO, PUESTO, UNIDAD Y LA OPERACIÓN. ADEMÁS DE CARGAR LA FECHA ACTUAL// 
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();

                cargarFecha();
                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
        

                if (Session["op"].ToString() == "Agregar")
                {
                    //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];                   
                    ////Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();
                    ////Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();
                    cargarOfendido();

                    lblOperacion.Text = "AGREGAR DATOS DEL LOCALIZADO";
                    PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                    PGJ.CargaCombo(ddlLugarHallazgo, "PNL_CAT_LUGAR_HALLAZGO", "IdLugarHallazgo", "LugarHallazgo");
                    PGJ.CargaCombo(ddlCondiciones, "PNL_CAT_CONDICION_LOCALIZACION", "IdCondicionLocalizacion", "CondicionLocalizacion");
                    PGJ.CargaCombo(ddlCausaFallecimiento, "PNL_CAT_CAUSA_FALLECIMIENTO", "IdCausasFallecimiento", "CausasFallecimiento");
                    PGJ.CargaCombo(ddlParentesco0, "CAT_PARENTESCO", "ID_PRNTSCO", "PRNTSCO");
                    
                    //agregado
                    ddlCondiciones.Items.Insert(0, "--SELECCIONE--");
                    //ddlPais.Items.Insert(0, "--SELECCIONE--");
                    ddlEntidad.Items.Insert(0, "--SELECCIONE--");
                    ddlMunicipio.Items.Insert(0, "--SELECCIONE--");
                    ddlLocalidadDom.Items.Insert(0, "--SELECCIONE--");
                    ddlCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlYcalle.Items.Insert(0, "--SELECCIONE--");
                    ddlColonia.Items.Insert(0, "--SELECCIONE--");
                    ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlLugarHallazgo.Items.Insert(0, "--SELECCIONE--");
                    ddlParentesco0.Items.Insert(0, "--SELECCIONE--");
                    ddlCausaFallecimiento.Items.Insert(0, "--SELECCIONE--");
                    //fin

                   // cargarAgregarPersona();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    Session["IdLocalizado"] = Request.QueryString["IdLocalizado"];
                    ID_LOCALIZADO.Text = Session["IdLocalizado"].ToString();

                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                    //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();
                   


                    lblOperacion.Text = "MODIFICAR  DATOS DEL LOCALIZADO";
                    PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                    PGJ.CargaCombo(ddlLugarHallazgo, "PNL_CAT_LUGAR_HALLAZGO", "IdLugarHallazgo", "LugarHallazgo");
                    PGJ.CargaCombo(ddlCondiciones, "PNL_CAT_CONDICION_LOCALIZACION", "IdCondicionLocalizacion", "CondicionLocalizacion");
                    PGJ.CargaCombo(ddlCausaFallecimiento, "PNL_CAT_CAUSA_FALLECIMIENTO", "IdCausasFallecimiento", "CausasFallecimiento");
                    PGJ.CargaCombo(ddlParentesco0, "CAT_PARENTESCO", "ID_PRNTSCO", "PRNTSCO");
                    cargarLocalizado();

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Datos localización con IdLocalización =" + ID_LOCALIZADO.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));


                    cargarOfendido();

                    if (rbEstatus.SelectedValue == "0")
                    {
                        Panel2.Visible = true;
                    }
                    else if (rbEstatus.SelectedValue == "1")
                    {
                        Panel2.Visible = false;
                    }
                }
                if (rbLocaliza.SelectedValue == "1")
                {
                    lblNombre.Visible = true;
                    txtNombreLocalizado.Visible = true;
                    lblPaterno.Visible = true;
                    txtPaterno.Visible = true;
                    lblMaterno.Visible = true;
                    txtMaterno.Visible = true;

                    lblInstitucion.Visible = false;
                    txtInstitucion.Visible = false;
                }
                else if (rbLocaliza.SelectedValue == "2")
                {
                    lblNombre.Visible = false;
                    txtNombreLocalizado.Visible = false;
                    lblPaterno.Visible = false;
                    txtPaterno.Visible = false;
                    lblMaterno.Visible = false;
                    txtMaterno.Visible = false;

                    lblInstitucion.Visible = true;
                    txtInstitucion.Visible = true;
                }
                else if (rbLocaliza.SelectedValue == "3")
                {
                    lblNombre.Visible = false;
                    txtNombreLocalizado.Visible = false;
                    lblPaterno.Visible = false;
                    txtPaterno.Visible = false;
                    lblMaterno.Visible = false;
                    txtMaterno.Visible = false;

                    lblInstitucion.Visible = false;
                    txtInstitucion.Visible = false;
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

        void cargarLocalizado()
        {

            SqlCommand sql = new SqlCommand("PNL_cargarDatosLocalizacion " + int.Parse(Session["IdLocalizado"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
           
                ID_LOCALIZADO.Text = dr["IdLocalizado"].ToString();
                ddlOfendido.SelectedValue = dr["IDPERSONA"].ToString();
                rbEstatus.SelectedValue = dr["EstatusPersona"].ToString();

                txtFechaLocalizacion.Text = dr["FechaLocalizacion"].ToString();
                txtHoraLocalizacion.Text = dr["HoraLocalizacion"].ToString();
                txtDesaparicion.Text = dr["PosibleCausaDesaparicion"].ToString();
                ddlCondiciones.SelectedValue = dr["IdCondicionLocalizacion"].ToString();
                ddlLugarHallazgo.SelectedValue = dr["IdLugarHallazgo"].ToString();
                                  
                txtNumExt0.Text = dr["NumeroExterior"].ToString();
                txtNumInt0.Text = dr["NumeroInterior"].ToString();
                txtCP0.Text = dr["CP"].ToString();

                txtFechaIngreso.Text = dr["FechaIngreso"].ToString();
                txtHoraIngreso.Text = dr["HoraIngreso"].ToString();
                ddlCausaFallecimiento.SelectedValue = dr["IdCausasFallecimiento"].ToString();

                txtIdentificacion.Text = dr["IdentificacionCadaver"].ToString();

                txtFechaEntrega.Text = dr["FechaEntregaCuerpo"].ToString();
                txtFechaProbable.Text = dr["FechaProbableFallecimiento"].ToString();
                rbLocaliza.SelectedValue = dr["EnteLocaliza"].ToString();
                txtNombreLocalizado.Text = dr["NombreEnte"].ToString();
                txtPaterno.Text = dr["PaternoEnte"].ToString();
                txtMaterno.Text = dr["MaternoEnte"].ToString();
                txtInstitucion.Text = dr["Institucion"].ToString();
                txtAutoridad.Text = dr["Autoridad"].ToString();
                txtNombreAutoridad.Text = dr["NombreAutoridad"].ToString();
                txtPaternoAutoridad.Text = dr["PaternoAutoridad"].ToString();
                txtMaternoAutoridad.Text = dr["MaternoAutoridad"].ToString();
                txtNombreReclama.Text = dr["NombreReclama"].ToString();
                txtPaternoReclama.Text = dr["PaternoReclama"].ToString();
                txtMaternoReclama.Text = dr["MaternoReclama"].ToString();
                ddlParentesco0.SelectedValue = dr["IdParentescoReclama"].ToString();

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
            

        }


        void consultaPaisEstado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEntidad.DataSource = estado;
            ddlEntidad.DataValueField = "ID_ESTDO";
            ddlEntidad.DataTextField = "ESTDO";
            ddlEntidad.DataBind();

            if (ddlEntidad.Items.Count == 0) {                
                ddlEntidad.Items.Insert(0,"ESTADO DESCONOCIDO");                
                ddlMunicipio.Items.Insert(0,"MUNICIPIO DESCONOCIDO");
                ddlLocalidadDom.Items.Insert(0, "LOCALIDAD DESCONOCIDO");
                ddlColonia.Items.Insert(0,"COLONIA DESCONOCIDA");
                ddlCalle.Items.Insert(0, "CALLE DESCONOCIDA");
                ddlEntreCalle.Items.Insert(0,"ENTRE CALLE DESCONOCIDA");
                ddlYcalle.Items.Insert(0,"Y CALLE DESCONOCIDA");
            }
        
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

            if (ddlMunicipio.Items.Count == 0) { ddlMunicipio.Items.Insert(0, "MUNICIPIO DESCONOCIDO"); }
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

            if (ddlEntidad.Items.Count == 0)
            {
                ddlEntidad.Items.Insert(0, "ESTADO DESCONOCIDO");
                Session["ID_ESTADO_DOM"] = "0";// ddlEntidad.SelectedValue.ToString();
                consultaEstadoMunicipioDom();
            }
            else
            {


                ddlMunicipio.Items.Clear();
                ddlLocalidadDom.Items.Clear();
                ddlCalle.Items.Clear();
                ddlEntreCalle.Items.Clear();
                ddlYcalle.Items.Clear();
                ddlColonia.Items.Clear();
                ddlEntreCalle.Items.Clear();

                ddlMunicipio.Items.Insert(0, "--SELECCIONE--");
                ddlLocalidadDom.Items.Insert(0, "--SELECCIONE--");
                ddlCalle.Items.Insert(0, "--SELECCIONE--");
                ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                ddlYcalle.Items.Insert(0, "--SELECCIONE--");
                ddlColonia.Items.Insert(0, "--SELECCIONE--");
                ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                //ddlMunicipio.Items.Insert(0, "--SELECCIONE--");
                //ddlLocalidadDom.Items.Insert(0, "--SELECCIONE--");
                //ddlCalle.Items.Insert(0, "--SELECCIONE--");
                //ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                //ddlYcalle.Items.Insert(0, "--SELECCIONE--");
                //ddlColonia.Items.Insert(0, "--SELECCIONE--");
                //ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
            }


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

            if (ddlMunicipio.Items.Count == 0) 
            { 
                ddlMunicipio.Items.Insert(0, "MUNICIPIO DESCONOCIDO");
                Session["ID_MUNICIPIO_DOM"] ="0";
                consultaMunicipioLocalidad();
            }

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

            if (ddlLocalidadDom.Items.Count == 0) 
            { 
                ddlLocalidadDom.Items.Insert(0,"LOCALIDAD DESCONOCIDA");
                Session["ID_LOCALIDAD"] = "0";
                consultaLocalidadColonia();
                consultaLocalidadCalle();
                consultaLocalidadEntreCalle();
                consultaLocalidadYCalle();
            }

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

            if (ddlColonia.Items.Count == 0) 
            { 
                ddlColonia.Items.Insert(0, "COLONIA DESCONOCIDA"); 
            }
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

            if (ddlCalle.Items.Count == 0) 
            { 
                ddlCalle.Items.Insert(0, "CALLE DESCONOCIDA"); 
            }
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

            if (ddlEntreCalle.Items.Count == 0) 
            { 
                ddlEntreCalle.Items.Insert(0, "ENTRE CALLE DESCONOCIDA"); 
            }
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

            if (ddlYcalle.Items.Count == 0) 
            { 
                ddlYcalle.Items.Insert(0, "Y CALLE DESCONOCIDA"); 
            }
        }

        protected void cmdGuardarCuerpo_Click(object sender, EventArgs e)
        {
            bool guardar = true;
            if (ddlOfendido.SelectedValue == "0")
            {
                lblEstatus.Text = "SELECCIONA PERSONA";
            }
            else
            {
                if (Session["op"].ToString() == "Agregar")
                {
                    /*ddlCondiciones.Items.Insert(0, "--SELECCIONE--");
                    ddlPais.Items.Insert(0, "--SELECCIONE--");
                    ddlEntidad.Items.Insert(0, "--SELECCIONE--");
                    ddlMunicipio.Items.Insert(0, "--SELECCIONE--");
                    ddlLocalidadDom.Items.Insert(0, "--SELECCIONE--");
                    ddlCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlYcalle.Items.Insert(0, "--SELECCIONE--");
                    ddlColonia.Items.Insert(0, "--SELECCIONE--");
                    ddlEntreCalle.Items.Insert(0, "--SELECCIONE--");
                    ddlLugarHallazgo.Items.Insert(0, "--SELECCIONE--");
                    ddlParentesco0.Items.Insert(0, "--SELECCIONA--");
                    ddlCausaFallecimiento.Items.Insert(0, "--SELECCIONE--");*/

                    if (ddlCondiciones.SelectedValue == "--SELECCIONE--") //CONDICIONES
                    {
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CONDICIONES OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA CONDICIONES OBLIGATORIO.";
                        
                    }
                    else if (ddlPais.SelectedValue.ToString() == "--SELECCIONA--") //PAIS
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA PAIS OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA PAIS OBLIGATORIO.";
                    }

                    else if (ddlEntidad.SelectedValue.ToString() == "--SELECCIONE--") //ESTADO
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA ESTADO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA ESTADO OBLIGATORIO.";
                    }

                    else if (ddlMunicipio.SelectedValue.ToString() == "--SELECCIONE--") //MUNICIPIO
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA MUNICIPIO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA MUNICIPIO OBLIGATORIO.";
                    }

                    else if (ddlLocalidadDom.SelectedValue.ToString() == "--SELECCIONE--") //LOCALIDAD
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA LOCALIDAD OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA LOCALIDAD OBLIGATORIO.";
                    }

                    else if (ddlCalle.SelectedValue.ToString() == "--SELECCIONE--") //CALLE
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CALLE OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA CALLE OBLIGATORIO.";
                    }

                    else if (ddlColonia.SelectedValue.ToString() == "--SELECCIONE--") //COLONIA
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA COLONIA OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA COLONIA OBLIGATORIO.";
                    }

                    else if (ddlEntreCalle.SelectedValue.ToString() == "--SELECCIONE--") //ENTRE CALLE
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA ENTRE CALLE OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA ENTRE CALLE OBLIGATORIO.";
                    }

                    else if (ddlYcalle.SelectedValue.ToString() == "--SELECCIONE--") //Y CALLE
                    {
                        lblEstatus.Text = "";
                        guardar=false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA Y CALLE OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA Y CALLE OBLIGATORIO.";
                    }
                    else if (ddlLugarHallazgo.SelectedValue.ToString() == "--SELECCIONE--" && rbEstatus.SelectedValue == "0") //LUGAR HALLAZGO
                    {
                        lblEstatus.Text = "";
                        guardar=false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA LUGAR HALLAZGO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA LUGAR HALLAZGO OBLIGATORIO.";
                    }
                    else if (ddlParentesco0.SelectedIndex == 0 && rbEstatus.SelectedValue == "0") //PARENTESCO
                    {
                        lblEstatus.Text = "";
                        guardar=false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA PARENTESCO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA PARENTESCO OBLIGATORIO.";
                    }
                    else if (ddlCausaFallecimiento.SelectedValue == "--SELECCIONE--" && rbEstatus.SelectedValue == "0") //CAUSA DE FALLECIMIENTO
                    {
                        lblEstatus.Text = "";
                        guardar=false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CAUSA DE FALLECIMIENTO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA CAUSA DE FALLECIMIENTO OBLIGATORIO.";
                    }else 
                    
                    if (guardar)
                    {
                        lblEstatus.Text = "";
                        try
                        {
                            PGJ.InsertaDatosLocalizacion(int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), short.Parse(rbEstatus.SelectedValue), DateTime.Parse(txtFechaLocalizacion.Text), txtHoraLocalizacion.Text, txtDesaparicion.Text, short.Parse(ddlCondiciones.SelectedValue), short.Parse(ddlLugarHallazgo.SelectedValue), short.Parse(ddlPais.SelectedValue), short.Parse(ddlEntidad.SelectedValue), short.Parse(ddlMunicipio.SelectedValue), short.Parse(ddlLocalidadDom.SelectedValue),
                              short.Parse(ddlColonia.SelectedValue), int.Parse(ddlCalle.SelectedValue), int.Parse(ddlEntreCalle.SelectedValue), int.Parse(ddlYcalle.SelectedValue),
                                 txtNumExt0.Text, txtNumInt0.Text, txtCP0.Text, txtFechaIngreso.Text, txtHoraIngreso.Text, short.Parse(ddlCausaFallecimiento.SelectedValue), txtIdentificacion.Text, txtFechaEntrega.Text, txtFechaProbable.Text, short.Parse(rbLocaliza.SelectedValue), txtNombreLocalizado.Text, txtPaterno.Text, txtMaterno.Text, txtInstitucion.Text, txtAutoridad.Text, txtNombreAutoridad.Text, txtPaternoAutoridad.Text, txtMaternoAutoridad.Text, txtNombreReclama.Text, txtPaternoReclama.Text, txtMaternoReclama.Text, short.Parse(ddlParentesco0.SelectedValue));
                                   string script = @"<script type='text/javascript'> alert('DATOS GUARDADOS');  </script>";


                            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Datos localización: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdPersona= " + ddlOfendido.SelectedItem + ", Estatus persona= " + rbEstatus.SelectedItem + ", Fecha localización= " + txtFechaLocalizacion.Text + ", Hora localización= " + txtHoraLocalizacion.Text + ", Posible causa desaparición= " + txtDesaparicion.Text + ", Condiciones localización= " + ddlCondiciones.SelectedItem + ", Lugar de hallazgo= " + ddlLugarHallazgo.SelectedItem + ", País localización= " + ddlPais.SelectedItem + ", Entidad= " + ddlEntidad.SelectedItem + ", Municipio= " + ddlMunicipio.SelectedItem + ", Localidad= " + ddlLocalidadDom.SelectedItem
                            + ", Colonia= " + ddlColonia.SelectedItem + ", Calle= " + ddlCalle.SelectedItem + ", Entre calle= " + ddlEntreCalle.SelectedItem + ", Y calle= " + ddlYcalle.SelectedItem
                            + ", N° exterior= " + txtNumExt0.Text + ", N° interrior= " + txtNumInt0.Text + ", CP= " + txtCP0.Text + ", Fecha de ingreso al SEMEFO= " + txtFechaIngreso.Text + ", Hora de ingreso= " + txtHoraIngreso.Text + ", Causa de fallecimiento= " + ddlCausaFallecimiento.SelectedItem + ", Identificación= " + txtIdentificacion.Text + ", Fecha de entrega del cuerpo= " + txtFechaEntrega.Text + ", Fecha probable de fallecimiento= " + txtFechaProbable.Text + ", Ente que localiza= " + rbLocaliza.SelectedItem + ", Nombre quien localiza= " + txtNombreLocalizado.Text + " " + txtPaterno.Text + " " + txtMaterno.Text + ", Institución que localiza= " + txtInstitucion.Text + ", Autoridad que localiza= " + txtAutoridad.Text + ", Nombre autoridad= " + txtNombreAutoridad.Text + " " + txtPaternoAutoridad.Text + " " + txtMaternoAutoridad.Text + ", Nombre quien reclama el cuerpo= " + txtNombreReclama.Text + " " + txtPaternoReclama.Text + " " + txtMaternoReclama.Text + ", Parentesco con el occiso= " + ddlParentesco0.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));


                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


                            lblEstatus.Text = "DATOS GUARDADOS";

                            cmdGuardarCuerpo.Visible = false;
                            DesactivarControles();
                            
                        }
                        catch (Exception ex)
                        {
                            lblEstatus.Text = ex.Message;
                            //lblEstatus1.Text = "INTENTELO NUEVAMENTE";
                        }
                    }
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    if (ddlCondiciones.SelectedValue == "--SELECCIONE--") //CONDICIONES
                    {
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CONDICIONES OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA CONDICIONES OBLIGATORIO.";

                    }
                    else if (ddlPais.SelectedValue == "-SELECCIONA--") //PAIS
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA PAIS OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA PAIS OBLIGATORIO.";
                    }

                    else if (ddlEntidad.SelectedValue == "--SELECCIONE--") //ESTADO
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA ESTADO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA ESTADO OBLIGATORIO.";
                    }

                    else if (ddlMunicipio.SelectedValue == "--SELECCIONE--") //MUNICIPIO
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA MUNICIPIO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA MUNICIPIO OBLIGATORIO.";
                    }

                    else if (ddlLocalidadDom.SelectedValue.ToString() == "--SELECCIONE--") //LOCALIDAD
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA LOCALIDAD OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA LOCALIDAD OBLIGATORIO.";
                    }

                    else if (ddlCalle.SelectedValue == "--SELECCIONE--") //CALLE
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CALLE OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA CALLE OBLIGATORIO.";
                    }

                    else if (ddlColonia.SelectedValue == "--SELECCIONE--") //COLONIA
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA COLONIA OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA COLONIA OBLIGATORIO.";
                    }

                    else if (ddlEntreCalle.SelectedValue == "--SELECCIONE--") //ENTRE CALLE
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA ENTRE CALLE OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA ENTRE CALLE OBLIGATORIO.";
                    }

                    else if (ddlYcalle.SelectedValue == "--SELECCIONE--") //Y CALLE
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA Y CALLE OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA Y CALLE OBLIGATORIO.";
                    }
                    else if (ddlLugarHallazgo.SelectedValue == "--SELECCIONE--" && rbEstatus.SelectedValue == "0") //LUGAR HALLAZGO
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA LUGAR HALLAZGO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA LUGAR HALLAZGO OBLIGATORIO.";
                    }
                    else if (ddlParentesco0.SelectedIndex == 0 && rbEstatus.SelectedValue == "0") //PARENTESCO
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA PARENTESCO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA PARENTESCO OBLIGATORIO.";
                    }
                    else if (ddlCausaFallecimiento.SelectedValue == "--SELECCIONE--" && rbEstatus.SelectedValue == "0") //CAUSA DE FALLECIMIENTO
                    {
                        lblEstatus.Text = "";
                        guardar = false;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CAUSA DE FALLECIMIENTO OBLIGATORIO.')", true);
                        lblEstatus.Text = "CAMPO DE CAPTURA CAUSA DE FALLECIMIENTO OBLIGATORIO.";
                    }else


                    if (guardar)
                    {
                        lblEstatus.Text = "";
                        try
                        {
                            PGJ.ActualizaDatosLocalizacion(int.Parse(ID_LOCALIZADO.Text), short.Parse(rbEstatus.SelectedValue), DateTime.Parse(txtFechaLocalizacion.Text), txtHoraLocalizacion.Text, txtDesaparicion.Text, short.Parse(ddlCondiciones.SelectedValue), short.Parse(ddlLugarHallazgo.SelectedValue), short.Parse(ddlPais.SelectedValue), short.Parse(ddlEntidad.SelectedValue), short.Parse(ddlMunicipio.SelectedValue), short.Parse(ddlLocalidadDom.SelectedValue),
                        short.Parse(ddlColonia.SelectedValue), int.Parse(ddlCalle.SelectedValue), int.Parse(ddlEntreCalle.SelectedValue), int.Parse(ddlYcalle.SelectedValue),
                        txtNumExt0.Text, txtNumInt0.Text, txtCP0.Text, txtFechaIngreso.Text, txtHoraIngreso.Text, short.Parse(ddlCausaFallecimiento.SelectedValue), txtIdentificacion.Text, txtFechaEntrega.Text, txtFechaProbable.Text, short.Parse(rbLocaliza.SelectedValue), txtNombreLocalizado.Text, txtPaterno.Text, txtMaterno.Text, txtInstitucion.Text, txtAutoridad.Text, txtNombreAutoridad.Text, txtPaternoAutoridad.Text, txtMaternoAutoridad.Text, txtNombreReclama.Text, txtPaternoReclama.Text, txtMaternoReclama.Text, short.Parse(ddlParentesco0.SelectedValue));
                            string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";


                            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Datos localización: IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", IdLocalizado= " + ID_LOCALIZADO.Text + ", Estatus persona= " + rbEstatus.SelectedItem + ", Fecha localización= " + txtFechaLocalizacion.Text + ", Hora localización= " + txtHoraLocalizacion.Text + ", Posible causa desaparición= " + txtDesaparicion.Text + ", Condiciones localización= " + ddlCondiciones.SelectedItem + ", Lugar de hallazgo= " + ddlLugarHallazgo.SelectedItem + ", País localización= " + ddlPais.SelectedItem + ", Entidad= " + ddlEntidad.SelectedItem + ", Municipio= " + ddlMunicipio.SelectedItem + ", Localidad= " + ddlLocalidadDom.SelectedItem
                        + ", Colonia= " + ddlColonia.SelectedItem + ", Calle= " + ddlCalle.SelectedItem + ", Entre calle= " + ddlEntreCalle.SelectedItem + ", Y calle= " + ddlYcalle.SelectedItem
                        + ", N° exterior= " + txtNumExt0.Text + ", N° interrior= " + txtNumInt0.Text + ", CP= " + txtCP0.Text + ", Fecha de ingreso al SEMEFO= " + txtFechaIngreso.Text + ", Hora de ingreso= " + txtHoraIngreso.Text + ", Causa de fallecimiento= " + ddlCausaFallecimiento.SelectedItem + ", Identificación= " + txtIdentificacion.Text + ", Fecha de entrega del cuerpo= " + txtFechaEntrega.Text + ", Fecha probable de fallecimiento= " + txtFechaProbable.Text + ", Ente que localiza= " + rbLocaliza.SelectedItem + ", Nombre quien localiza= " + txtNombreLocalizado.Text + " " + txtPaterno.Text + " " + txtMaterno.Text + ", Institución que localiza= " + txtInstitucion.Text + ", Autoridad que localiza= " + txtAutoridad.Text + ", Nombre autoridad= " + txtNombreAutoridad.Text + " " + txtPaternoAutoridad.Text + " " + txtMaternoAutoridad.Text + ", Nombre quien reclama el cuerpo= " + txtNombreReclama.Text + " " + txtPaternoReclama.Text + " " + txtMaternoReclama.Text + ", Parentesco con el occiso= " + ddlParentesco0.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));


                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                            cmdGuardarCuerpo.Visible = false;
                            DesactivarControles();

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                
            }
        }

        protected void rbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbEstatus.SelectedValue == "0")
            {
                Panel2.Visible = true;
            }
            else if (rbEstatus.SelectedValue == "1")
            {
                Panel2.Visible = false;
            }
        }

        protected void rbLocaliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbLocaliza.SelectedValue == "1")
            {
                lblNombre.Visible = true;
                txtNombreLocalizado.Visible = true;
                lblPaterno.Visible = true;
                txtPaterno.Visible = true;
                lblMaterno.Visible = true;
                txtMaterno.Visible = true;
                lblInstitucion.Visible = false;
                txtInstitucion.Visible = false;
            }
            else if (rbLocaliza.SelectedValue == "2")
            {
                lblNombre.Visible = false;
                txtNombreLocalizado.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblInstitucion.Visible = true;
                txtInstitucion.Visible = true;
            }
            else if (rbLocaliza.SelectedValue == "3")
            {
                lblNombre.Visible = false;
                txtNombreLocalizado.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblInstitucion.Visible = false;
                txtInstitucion.Visible = false;
            }
        }

        void DesactivarControles()
        {
            Panel7.Enabled = false;
            Panel2.Enabled = false;
            rbEstatus.Enabled = false;
            txtFechaLocalizacion.Enabled = false;
            txtHoraLocalizacion.Enabled = false;
            txtDesaparicion.Enabled = false;
            ddlCondiciones.Enabled = false;
            ddlLugarHallazgo.Enabled = false;

        
        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde Datos localización", int.Parse(Session["IdModuloBitacora"].ToString()));

                //Response.Redirect("PNLDatosPrincipales.aspx?op=Modificar");
                Response.Redirect("PNLDatosPrincipales.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Modificar" + "&ID_MUNICIPIO_CARPETA=" + Session["ID_MUNICIPIO_CARPETA"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_PERTENENCIA_SOCIAL=" + Session["ID_PERTENENCIA_SOCIAL"].ToString() + "&ID_INFO_FINANCIERA=" + Session["ID_INFO_FINANCIERA"].ToString() + "&ID_INFO_ODONTOLOGICA=" + Session["ID_INFO_ODONTOLOGICA"].ToString() + "&ID_DISCAPACIDADES=" + Session["ID_DISCAPACIDADES"].ToString() + "&ID_OTRA_INFO=" + Session["ID_OTRA_INFO"].ToString() + "&ID_CAUSALES=" + Session["ID_CAUSALES"].ToString());
            }
            catch (Exception ex) {  }
        }

    }
}