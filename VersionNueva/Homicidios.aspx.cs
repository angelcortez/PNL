using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace AtencionTemprana
{
    public partial class Homicidios : System.Web.UI.Page
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


                lblArbol.Text = Session["lblArbol"].ToString();
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                //Session["op"] = Request.QueryString["op"];


               
              


                if (Session["op"].ToString() == "Agregar")
                {

                    try
                    {

                        ID_LUGAR_HECHOS.Text = Session["ID_LUGAR_HECHOS"].ToString();

                        cargarOfendido();
                        cargarImputado();
                        PGJ.CargaComboLugarHechos(ddlLugarHechos, IdCarpeta.Text);

                        ddlLugarHechos.SelectedValue = ID_LUGAR_HECHOS.Text;
                        ddlLugarHechos.Enabled = false;

                        //Datos del Delito
                        PGJ.CargaCombo(ddlSubDelito, "CAT_SUB_DELITO_HOMICIDIO", "ID_SUB_DELITO", "SUB_DELITO");
                        PGJ.CargaCombo(ddlSubModalidad, "CAT_SUB_MODALIDAD", "ID_SUB_MODALIDAD", "SUB_MODALIDAD");
                        PGJ.CargaCombo(ddlSituacion, "CAT_SITUACION_DELITO", "ID_SITUACION", "SITUACION_DELITO");

                        if (Session["ID_MODALIDAD"].ToString() == "2")
                        {
                            ddlSubDelito.Enabled = false;
                            ddlSubDelito.SelectedValue = "1";
                            ddlSubModalidad.Enabled = false;
                            ddlSubModalidad.SelectedValue = "2";
                            ddlOrganizacionDelictiva.Enabled = false;

                        }

                        //Datos perosna
                        PGJ.CargaCombo(ddlTipoPersonaOfendido, "CAT_TIPO_PERSONA", "ID_TIPO_PERSONA", "TIPO_PERSONA");
                        PGJ.CargaCombo(ddlTipoPersonaImputado, "CAT_TIPO_PERSONA", "ID_TIPO_PERSONA", "TIPO_PERSONA");
                        PGJ.CargaCombo(ddlOrganizacionDelictiva, "CAT_ORGANIZACION_CRIMINAL", "ID_ORGANIZACION", "ORGANIZACION_CRIMINAL");
                        //Cadaver
                        PGJ.CargaCombo(ddlViolencia, "CAT_VIOLENCIA", "ID_VIOLENCIA", "VIOLENCIA");
                        PGJ.CargaCombo(ddlCausaMuerte, "CAT_CADAVER_CAUSA", "ID_CDVR_CAUSA", "CDVR_CAUSA");
                        PGJ.CargaCombo(ddlMovil, "CAT_MOVIL", "ID_MOVIL", "MOVIL");
                        PGJ.CargaCombo(ddlCondicionCadaver, "CAT_CADAVER_CONSERVACION", "ID_CDVR_CNSRVCION", "CDVR_CNSRVCION");
                        PGJ.CargaCombo(ddlOrientacion, "CAT_CADAVER_ORIENTACION", "ID_CDVR_ORIENTCION", "CDVR_ORIENTCION");
                        PGJ.CargaCombo(ddlPosicion, "CAT_CADAVER_POSICION", "ID_CDVR_PSCION", "CDVR_PSCION");
                        PGJ.CargaCombo(ddlParentesco, "CAT_PARENTESCO_HOMICIDIO", "ID_PRNTSCO", "PRNTSCO");

                        //ddlParentesco.Items.Insert(0," -- SELECCIONE --");

                       

                        //Armas
                        PGJ.CargaCombo(ddlTipoArma, "CAT_ARMA_TIPO", "ID_ARMA_TPO", "ARMA_TPO");
                        PGJ.CargaCombo(ddlArma, "CAT_ARMA", "ID_ARMA", "ARMA");
                        PGJ.CargaCombo(ddlTamañoArma, "CAT_ARMAS_AA", "ID_ARMAS_AA", "ARMAS_AA");
                        PGJ.CargaCombo(ddlMarcaArma, "CAT_ARMA_MARCA", "ID_MARCA", "MARCA");
                        PGJ.CargaCombo(ddlCalibreArma, "CAT_ARMA_CALIBRE", "ID_CALIBRE", "CALIBRE");
                        PGJ.CargaCombo(ddlEstadoArma, "CAT_ARMA_ESTADO", "ID_ESTADO_ARMA", "ESTADO_ARMA");
                    }
                    catch (Exception ex)
                    {

                    }


                    cmdSiguiente.Enabled = false;
                    cmdNuevoReg.Enabled = false;
                }

                if (Session["op"].ToString() == "Modificar")
                {
                    

                    try
                    {


                        PanelModificarHomicidio.Visible = true;

                        if (ConsultarNumeroHomicidios() == 0)
                        {
                            gvModificarHomicidio.Visible = false;
                            cmdNuevoHomicidio.Visible = true;
                        }
                        else {

                            gvModificarHomicidio.Visible = true;
                            cmdNuevoHomicidio.Visible = true;
                        
                        }

                            
                            Panel1.Visible = false;
                            Panel3.Visible = false;
                            Panel5.Visible = false;
                            PanelDatosMensaje.Visible = false;
                            PanelArmas.Visible = false;
                            cmdGuardar.Visible = false;
                            cmdNuevoReg.Visible = false;
                            //cmdSiguiente.Visible = false;
                        

                        if (Request.QueryString["ID_HOMICIDIO"] != "" )
                        {
                            ID_HOMICIDIO.Text = Request.QueryString["ID_HOMICIDIO"];

                            if (ID_HOMICIDIO.Text != "")
                            {

                                ddlOfendido.Enabled = false;
                                ddlImputado.Enabled = false;
                                ddlLugarHechos.Enabled = false;


                                 PanelModificarHomicidio.Visible = false;
                                 Panel1.Visible = true;
                                 Panel3.Visible = true;
                                 Panel5.Visible = true;
                                 PanelDatosMensaje.Visible = true;
                                 PanelArmas.Visible = true;
                                 cmdGuardar.Visible = true;
                                
                                 cmdSiguiente.Visible = true;
                            }

                          

                            cargarOfendido();
                            cargarImputado();
                            PGJ.CargaComboLugarHechos(ddlLugarHechos, IdCarpeta.Text);


                            //Datos del Delito
                            PGJ.CargaCombo(ddlSubDelito, "CAT_SUB_DELITO_HOMICIDIO", "ID_SUB_DELITO", "SUB_DELITO");
                            PGJ.CargaCombo(ddlSubModalidad, "CAT_SUB_MODALIDAD", "ID_SUB_MODALIDAD", "SUB_MODALIDAD");
                            PGJ.CargaCombo(ddlSituacion, "CAT_SITUACION_DELITO", "ID_SITUACION", "SITUACION_DELITO");

                            //Datos perosna
                            PGJ.CargaCombo(ddlTipoPersonaOfendido, "CAT_TIPO_PERSONA", "ID_TIPO_PERSONA", "TIPO_PERSONA");
                            PGJ.CargaCombo(ddlTipoPersonaImputado, "CAT_TIPO_PERSONA", "ID_TIPO_PERSONA", "TIPO_PERSONA");
                            PGJ.CargaCombo(ddlOrganizacionDelictiva, "CAT_ORGANIZACION_CRIMINAL", "ID_ORGANIZACION", "ORGANIZACION_CRIMINAL");
                            //Cadaver
                            PGJ.CargaCombo(ddlViolencia, "CAT_VIOLENCIA", "ID_VIOLENCIA", "VIOLENCIA");
                            PGJ.CargaCombo(ddlCausaMuerte, "CAT_CADAVER_CAUSA", "ID_CDVR_CAUSA", "CDVR_CAUSA");
                            PGJ.CargaCombo(ddlMovil, "CAT_MOVIL", "ID_MOVIL", "MOVIL");
                            PGJ.CargaCombo(ddlCondicionCadaver, "CAT_CADAVER_CONSERVACION", "ID_CDVR_CNSRVCION", "CDVR_CNSRVCION");
                            PGJ.CargaCombo(ddlOrientacion, "CAT_CADAVER_ORIENTACION", "ID_CDVR_ORIENTCION", "CDVR_ORIENTCION");
                            PGJ.CargaCombo(ddlPosicion, "CAT_CADAVER_POSICION", "ID_CDVR_PSCION", "CDVR_PSCION");
                            PGJ.CargaCombo(ddlParentesco, "CAT_PARENTESCO_HOMICIDIO", "ID_PRNTSCO", "PRNTSCO");
                            //Armas
                            PGJ.CargaCombo(ddlTipoArma, "CAT_ARMA_TIPO", "ID_ARMA_TPO", "ARMA_TPO");
                            PGJ.CargaCombo(ddlArma, "CAT_ARMA", "ID_ARMA", "ARMA");
                            PGJ.CargaCombo(ddlTamañoArma, "CAT_ARMAS_AA", "ID_ARMAS_AA", "ARMAS_AA");
                            PGJ.CargaCombo(ddlMarcaArma, "CAT_ARMA_MARCA", "ID_MARCA", "MARCA");
                            PGJ.CargaCombo(ddlCalibreArma, "CAT_ARMA_CALIBRE", "ID_CALIBRE", "CALIBRE");
                            PGJ.CargaCombo(ddlEstadoArma, "CAT_ARMA_ESTADO", "ID_ESTADO_ARMA", "ESTADO_ARMA");

                            cargarHomicidio();
                            cargarCadaverHomicidio();
                            CargarMensajeHomicidio();

                        }


                    }
                    catch (Exception ex)
                    {

                    }


                    //PanelDatosMensaje.Visible = true;
                    //PanelArmas.Visible = true;

                }

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
        void cargarOfendido()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorOfendido(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.OFENDIDO };
            ddlOfendido.DataSource = im;
            ddlOfendido.DataValueField = "ID_PERSONA";
            ddlOfendido.DataTextField = "OFENDIDO";
            ddlOfendido.DataBind();
        }


        

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
              Byte[] fotoIdentifiacion;
              short fosa = 0;
            try
            {


                if (txtFechaMuerte.Text == "")
                {
                     txtFechaMuerte.Text = "01/01/1900 0:00:00";
                }

                if (txtFechaIdentificacion.Text == "")
                {
                    txtFechaIdentificacion.Text = "01/01/1900 0:00:00";
                }

                // INSERTAMOS LA INFORMACIÓN DEL CADAVER
                if (ddlCuerpoEntegado.SelectedValue == "1")
                {

                    if (txtFechaEntrega.Text == "")
                    {
                        txtFechaEntrega.Text = "01/01/1900 0:00:00";
                    }

                    fosa = 0;
                    txtResguardoCadaver.Text = "";
                    txtDescripcionCadaver.Text = "";
                    txtDatosFosa.Text = "";  
                }
                if (ddlCuerpoEntegado.SelectedValue == "2")
                {
                    fosa = 0;
                    txtNombreEntregaCuerpo.Text = "";
                    txtDescripcionCadaver.Text = "";
                    txtDatosFosa.Text = "";
                    txtFechaEntrega.Text = "01/01/1900 0:00:00";

                    
                }
                if (ddlCuerpoEntegado.SelectedValue == "3")
                {

                    if (txtFechaEntrega.Text == "")
                    {
                        txtFechaEntrega.Text = "01/01/1900 0:00:00";
                    }

                    fosa = 1;
                    txtNombreEntregaCuerpo.Text = "";    
                }

                if (Session["op"].ToString() == "Agregar")
                {
                   
                    lblEstatus.Text = "DATOS GUARDADOS";
                    PanelMsj.Visible = true;
                    cmdGuardar.Visible = false;

                    //INSERTAMOS EL HOMICIDIO

                    PGJ.InsertarHomicidio(int.Parse(IdCarpeta.Text), short.Parse(IdMunicipio.Text), int.Parse(ddlOfendido.SelectedValue), int.Parse(ddlImputado.SelectedValue), int.Parse(Session["ID_LUGAR_HECHOS"].ToString()), short.Parse(ddlTipoPersonaOfendido.SelectedValue), short.Parse(ddlTipoPersonaImputado.SelectedValue), short.Parse(ddlOrganizacionDelictiva.SelectedValue), short.Parse(ddlMovil.SelectedValue),short.Parse( ddlSubDelito.SelectedValue),short.Parse( ddlSituacion.SelectedValue),short.Parse(ddlSubModalidad.SelectedValue));


                    //CONSULTAMOS EL ID DEL HOMICIDIO
                    ConsultarIDHomicidio();

                  

                    // Comprobamos que existe IMAGEN y que no esta vacio
                    if ((imageID.PostedFile != null) && (imageID.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = imageID.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        fotoIdentifiacion = new Byte[imageID.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(fotoIdentifiacion, 0, imageID.PostedFile.ContentLength);
                    }
                    else
                    {
                        fotoIdentifiacion = new Byte[0];
                    }


                    PGJ.InsertarCadaverHomicidio(int.Parse(IdCarpeta.Text), short.Parse(IdMunicipio.Text), int.Parse(ddlOfendido.SelectedValue), short.Parse(ddlViolencia.SelectedValue), short.Parse(ddlCausaMuerte.SelectedValue), short.Parse(ddlCondicionCadaver.SelectedValue), short.Parse(ddlOrientacion.SelectedValue), short.Parse(ddlPosicion.SelectedValue),
                                                DateTime.Parse(txtFechaMuerte.Text), txtHoraMuerte.Text, DateTime.Parse(txtFechaIdentificacion.Text), txtHoraIdentificacion.Text, short.Parse(ddlCuerpoEntegado.SelectedValue), txtNombreEntregaCuerpo.Text, short.Parse(ddlParentesco.SelectedValue), fosa, txtDescripcionCadaver.Text, DateTime.Parse(txtFechaEntrega.Text), txtDatosFosa.Text, txtPartesCuerpo.Text, fotoIdentifiacion, txtResguardoCadaver.Text);


                }
                if (Session["op"].ToString() == "Modificar")
                {

                    lblEstatus.Text = "DATOS MODIFICADOS";

                    PGJ.ModificarHomicidio(int.Parse( ID_HOMICIDIO.Text), int.Parse(IdCarpeta.Text),  short.Parse(ddlTipoPersonaOfendido.SelectedValue), short.Parse(ddlTipoPersonaImputado.SelectedValue), short.Parse(ddlOrganizacionDelictiva.SelectedValue), short.Parse(ddlMovil.SelectedValue),short.Parse( ddlSubDelito.SelectedValue),short.Parse( ddlSituacion.SelectedValue),short.Parse(ddlSubModalidad.SelectedValue) );


                    PGJ.ModificarCadaverHomicidio(int.Parse(IdCarpeta.Text),int.Parse(ddlOfendido.SelectedValue), short.Parse(ddlViolencia.SelectedValue), short.Parse(ddlCausaMuerte.SelectedValue), short.Parse(ddlCondicionCadaver.SelectedValue), short.Parse(ddlOrientacion.SelectedValue), short.Parse(ddlPosicion.SelectedValue),
                                                DateTime.Parse(txtFechaMuerte.Text), txtHoraMuerte.Text, DateTime.Parse(txtFechaIdentificacion.Text), txtHoraIdentificacion.Text, short.Parse(ddlCuerpoEntegado.SelectedValue), txtNombreEntregaCuerpo.Text, short.Parse(ddlParentesco.SelectedValue), fosa, txtDescripcionCadaver.Text, DateTime.Parse(txtFechaEntrega.Text),txtDatosFosa.Text,txtPartesCuerpo.Text,txtResguardoCadaver.Text);



                    // Comprobamos que existe IMAGEN y que no esta vacio
                    if ((imageID.PostedFile != null) && (imageID.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = imageID.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        fotoIdentifiacion = new Byte[imageID.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(fotoIdentifiacion, 0, imageID.PostedFile.ContentLength);

                        PGJ.ModificarFotoIdentificacionHomicidio(int.Parse(IdCarpeta.Text), int.Parse(ddlOfendido.SelectedValue), fotoIdentifiacion);
                    }

                }

            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }

        }


        protected void ddlTipoArma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_TIPO_ARMA"] = ddlTipoArma.SelectedValue.ToString();
            PGJ.CargarArma(ddlArma, Session["ID_TIPO_ARMA"].ToString());
        }

       
        protected void btnAgregarArma_Click(object sender, EventArgs e)
        {
            try
            {
               
                    // insertamos el ARMA
                    PGJ.InsertarArma(int.Parse(IdCarpeta.Text), short.Parse(IdMunicipio.Text), short.Parse(ddlTipoArma.SelectedValue), short.Parse(ddlArma.SelectedValue), short.Parse(ddlTamañoArma.SelectedValue), short.Parse(ddlMarcaArma.SelectedValue), short.Parse(ddlCalibreArma.SelectedValue), short.Parse(ddlEstadoArma.SelectedValue), txtDescripcionArma.Text, txtMatricula.Text, txtSerie.Text);

                    //Consultamo el ID del ARMA
                    ConsultarIDArma();

                    //Insertamos el Arma relacionada con el Homicidio
                    PGJ.InsertarArmaHomicidio(int.Parse(IdCarpeta.Text), short.Parse(IdMunicipio.Text), short.Parse(ID_ARMA.Text), int.Parse(ID_HOMICIDIO.Text));
                

                //Mostramos el Arma en el Grid
                gvArmas.DataSourceID = "dsVerArmas";
                gvArmas.DataBind();

            }
            catch (Exception ex)
            {
                
                lblEstatus1.Text = ex.Message.ToString();
            }
        }

        protected void ddlCuerpoEntegado_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(ddlCuerpoEntegado.SelectedValue.ToString() == "1")
            {


                lblResguardoCadaver.Visible = false;
                txtResguardoCadaver.Visible = false;

                lblFechaNo.Visible = false;
                lblFechaEntrega.Visible = true;
                txtFechaEntrega.Visible = true;

                lblDatosFosa.Visible = false;
                txtDatosFosa.Visible = false;

                lblDescripcionVictima.Visible = false;
                txtDescripcionCadaver.Visible = false;

                lblNombreEntregaCuerpo.Visible = true;
                txtNombreEntregaCuerpo.Visible = true;

                lblParesntesco.Visible = true;
                ddlParentesco.Visible = true;

              
            }

            if (ddlCuerpoEntegado.SelectedValue.ToString() == "2")
            {

                lblResguardoCadaver.Visible = true;
                txtResguardoCadaver.Visible = true;

                lblFechaEntrega.Visible = false;
                lblFechaNo.Visible = false;
                txtFechaEntrega.Visible = false;

                lblDatosFosa.Visible = false;
                txtDatosFosa.Visible = false;

                lblDescripcionVictima.Visible = false;
                txtDescripcionCadaver.Visible = false;

                lblNombreEntregaCuerpo.Visible = false;
                txtNombreEntregaCuerpo.Visible = false;

                lblParesntesco.Visible = false;
                ddlParentesco.Visible = false;

              
            }

            if (ddlCuerpoEntegado.SelectedValue.ToString() == "3")
            {

                lblResguardoCadaver.Visible = false;
                txtResguardoCadaver.Visible = false;

                lblFechaEntrega.Visible = false;
                lblFechaNo.Visible = true;
                txtFechaEntrega.Visible = true;

                lblDatosFosa.Visible = true;
                txtDatosFosa.Visible = true;

                lblDescripcionVictima.Visible = true;
                txtDescripcionCadaver.Visible = true;

                lblNombreEntregaCuerpo.Visible = false;
                txtNombreEntregaCuerpo.Visible = false;

                lblParesntesco.Visible = false;
                ddlParentesco.Visible = false;


            }

        }

       

        protected void ImgSi1_Click(object sender, ImageClickEventArgs e)
        {
            UsarArmas.Visible = false;
            PanelArmas.Visible = true;
            cmdSiguiente.Enabled = true;
            cmdNuevoReg.Enabled = true;
        }

        protected void ImgNo1_Click(object sender, ImageClickEventArgs e)
        {
            UsarArmas.Visible = false;
            PanelArmas.Visible = false;
            cmdSiguiente.Enabled = true;
            cmdNuevoReg.Enabled = true;
        }

        public void ModificareButton_Command(object sender, CommandEventArgs e)
        {

            PanelModificarHomicidio.Visible = false;

            Response.Redirect("Homicidios.aspx?ID_HOMICIDIO=" + e.CommandArgument.ToString());

            //PGJ.EliminarPI_OrdenAsignada(Convert.ToInt32(IdOrden.Text), Convert.ToInt32(e.CommandArgument.ToString()));
            

        }


        public int ConsultarNumeroHomicidios()
        {

            int NUM_HOMICIDIO = 0;

            SqlCommand comm = new SqlCommand("SELECT COUNT(ID_HOMICIDIO) as ID_HOMICIDIO  FROM PGJ_HOMICIDIO WHERE ID_CARPETA = " + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NUM_HOMICIDIO = int.Parse(dr["ID_HOMICIDIO"].ToString());
                }
                dr.Close();
            }

            return NUM_HOMICIDIO;

        }
      


        public void ConsultarIDHomicidio(){


            SqlCommand comm = new SqlCommand("SELECT MAX(ID_HOMICIDIO) as ID_HOMICIDIO  FROM PGJ_HOMICIDIO WHERE ID_CARPETA = " + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ID_HOMICIDIO.Text = dr["ID_HOMICIDIO"].ToString();
                }
                dr.Close();
            }
        
        }


        public void ConsultarIDArma()
        {
            SqlCommand comm = new SqlCommand("SELECT MAX(ID_ARMA) as ID_ARMA  FROM PGJ_ARMA WHERE ID_CARPETA = " + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ID_ARMA.Text = dr["ID_ARMA"].ToString();
                }
                dr.Close();
            }

        }

        protected void cmdNuevoReg_Click(object sender, EventArgs e)
        {
            lblEstatus.Text = "";
            PanelArmas.Visible = false;
            PanelDatosMensaje.Visible = false;
            cmdGuardar.Visible = true;
            cmdNuevoReg.Enabled = false;

            LimpiarBotonesDetencion(); 


            if (Session["ID_MODALIDAD"].ToString() == "2")
            {
                //ddlSubDelito.Enabled = false;
                //ddlSubModalidad.Enabled = false;
                ddlSubDelito.SelectedValue = "1";
                ddlSubModalidad.SelectedValue = "2";
                //ddlOrganizacionDelictiva.Enabled = false;

            }

          
        }

        protected void CmdMensaje_Click(object sender, EventArgs e)
        {

            Byte[]  foto1, foto2, foto3, foto4;

            try
            {



                if (Session["op"].ToString() == "Agregar")
                {
                    lblEstatusMensaje.Text = "MENSAJE GUARDADO";
                    UsarArmas.Visible = true;
                    lblEstatus.Text = "";
                    CmdMensaje.Enabled = false;

                    //INSERTAMOS LA INFO DEL MENSAJE

                    // Comprobamos que existe IMAGEN 1 y que no esta vacio
                    if ((ImagenFile1.PostedFile != null) && (ImagenFile1.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile1.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto1 = new Byte[ImagenFile1.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto1, 0, ImagenFile1.PostedFile.ContentLength);
                    }
                    else
                    {
                        foto1 = new Byte[0];
                    }


                    // Comprobamos que existe IMAGEN 2 y que no esta vacio
                    if ((ImagenFile2.PostedFile != null) && (ImagenFile2.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile2.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto2 = new Byte[ImagenFile2.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto2, 0, ImagenFile2.PostedFile.ContentLength);
                    }
                    else
                    {
                        foto2 = new Byte[0];
                    }


                    // Comprobamos que existe IMAGEN 3 y que no esta vacio
                    if ((ImagenFile3.PostedFile != null) && (ImagenFile3.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile3.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto3 = new Byte[ImagenFile3.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto3, 0, ImagenFile3.PostedFile.ContentLength);
                    }
                    else
                    {
                        foto3 = new Byte[0];
                    }

                    // Comprobamos que existe IMAGEN 4 y que no esta vacio
                    if ((ImagenFile4.PostedFile != null) && (ImagenFile4.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile4.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto4 = new Byte[ImagenFile4.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto4, 0, ImagenFile4.PostedFile.ContentLength);
                    }
                    else
                    {
                        foto4 = new Byte[0];
                    }

                    PGJ.InsertarMensajeHomicidio(int.Parse(IdCarpeta.Text), short.Parse(IdMunicipio.Text), int.Parse(ID_HOMICIDIO.Text), txtMensaje.Text, foto1, foto2, foto3, foto4);
                }
                if (Session["op"].ToString() == "Modificar")
                {
                    lblEstatusMensaje.Text = "MENSAJE MODIFICADO";

                    PGJ.ModificarMensajeHomicidio(int.Parse(IdCarpeta.Text), int.Parse(ID_HOMICIDIO.Text), txtMensaje.Text);

                    // Comprobamos que existe IMAGEN 1 y que no esta vacio
                    if ((ImagenFile1.PostedFile != null) && (ImagenFile1.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile1.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto1 = new Byte[ImagenFile1.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto1, 0, ImagenFile1.PostedFile.ContentLength);

                        PGJ.ModificarFoto1MensajeHomicidio(int.Parse(IdCarpeta.Text), int.Parse(ID_HOMICIDIO.Text), foto1);

                    }


                    // Comprobamos que existe IMAGEN 2 y que no esta vacio
                    if ((ImagenFile2.PostedFile != null) && (ImagenFile2.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile2.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto2 = new Byte[ImagenFile2.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto2, 0, ImagenFile2.PostedFile.ContentLength);

                        PGJ.ModificarFoto2MensajeHomicidio(int.Parse(IdCarpeta.Text), int.Parse(ID_HOMICIDIO.Text), foto2);
                    }
 

                    // Comprobamos que existe IMAGEN 3 y que no esta vacio
                    if ((ImagenFile3.PostedFile != null) && (ImagenFile3.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile3.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto3 = new Byte[ImagenFile3.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto3, 0, ImagenFile3.PostedFile.ContentLength);

                        PGJ.ModificarFoto3MensajeHomicidio(int.Parse(IdCarpeta.Text), int.Parse(ID_HOMICIDIO.Text), foto3);

                    }


                    // Comprobamos que existe IMAGEN 4 y que no esta vacio
                    if ((ImagenFile4.PostedFile != null) && (ImagenFile4.PostedFile.ContentLength > 0))
                    {
                        //obtener archivos subidos
                        HttpPostedFile ImgFile = ImagenFile4.PostedFile;
                        // crear el array
                        // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                        foto4 = new Byte[ImagenFile4.PostedFile.ContentLength];
                        //cargado en una matriz de bytes
                        ImgFile.InputStream.Read(foto4, 0, ImagenFile4.PostedFile.ContentLength);

                        PGJ.ModificarFoto4MensajeHomicidio(int.Parse(IdCarpeta.Text), int.Parse(ID_HOMICIDIO.Text), foto4);

                    }

                }


            }
            catch (Exception ex)
            {
                lblEstatusMensaje.Text = ex.Message.ToString();
            }
        }

        protected void ImgMsjSI_Click(object sender, ImageClickEventArgs e)
        {

            PanelDatosMensaje.Visible = true;
            PanelMsj.Visible = false;
        }

        protected void ImgMsjNO_Click(object sender, ImageClickEventArgs e)
        {
            PanelDatosMensaje.Visible = false;
            PanelMsj.Visible = false;
            UsarArmas.Visible = true;
        }

        protected void cmdSiguiente_Click(object sender, EventArgs e)
        {
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
        }


        public void cargarHomicidio() 
        {

            SqlCommand sql1 = new SqlCommand("CargarHomicidio " + int.Parse(IdCarpeta.Text) + "," + int.Parse(ID_HOMICIDIO.Text), Data.CnnCentral);
            SqlDataReader dr1 = sql1.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();

               ddlSubDelito.SelectedValue = dr1["ID_SUB_DELITO"].ToString();
               ddlSubModalidad.SelectedValue = dr1["ID_SUB_MODALIDAD"].ToString();
               ddlSituacion.SelectedValue = dr1["ID_SITUACION"].ToString();

               ddlOfendido.SelectedValue = dr1["ID_PERSONA_OFENDIDO"].ToString();
               ddlTipoPersonaOfendido.SelectedValue = dr1["ID_TIPO_PERSONA_OFENDIDO"].ToString();
               
               ddlLugarHechos.SelectedValue = dr1["ID_LUGAR_HECHOS"].ToString();

               ddlImputado.SelectedValue = dr1["ID_PERSONA_IMPUTADO"].ToString();
               ddlTipoPersonaImputado.SelectedValue = dr1["ID_TIPO_PERSONA_IMPUTADO"].ToString();
               ddlOrganizacionDelictiva.SelectedValue = dr1["ID_ORGANIZACION_IMPUTADO"].ToString();
               ddlMovil.SelectedValue = dr1["ID_MOVIL"].ToString();
               

            }
            dr1.Close();
        }


        public void cargarCadaverHomicidio()
        {

            SqlCommand sql1 = new SqlCommand("CargarCadaverHomicidio " + int.Parse(IdCarpeta.Text) + "," + int.Parse(ddlOfendido.SelectedValue), Data.CnnCentral);
            SqlDataReader dr1 = sql1.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();

                ddlViolencia.SelectedValue = dr1["ID_VIOLENCIA"].ToString();
                ddlCausaMuerte.SelectedValue = dr1["ID_CDVR_CAUSA"].ToString();
                ddlCondicionCadaver.SelectedValue = dr1["ID_CDVR_CNSRVCION"].ToString();
                ddlOrientacion.SelectedValue = dr1["ID_CDVR_ORIENTACION"].ToString();
                ddlPosicion.SelectedValue = dr1["ID_CDVR_PSCION"].ToString();

                txtPartesCuerpo.Text = dr1["PARTES_CUERPO"].ToString();

                txtFechaMuerte.Text = dr1["FECHA_MUERTE"].ToString();
                txtHoraMuerte.Text = dr1["HORA_MUERTE"].ToString();
                txtFechaIdentificacion.Text = dr1["FECHA_IDENTIFICACION"].ToString();
                txtHoraIdentificacion.Text = dr1["HORA_IDENTIFIACION"].ToString();


                ddlCuerpoEntegado.SelectedValue = dr1["CUERPO_ENTREGADO"].ToString();
                
              

                if (dr1["CUERPO_ENTREGADO"].ToString() == "3")
                {


                    txtFechaEntrega.Text = dr1["FECHA_ENTREGA"].ToString();

                    ddlCuerpoEntegado.SelectedValue = "3";

                    lblDescripcionVictima.Visible = true;
                    txtDescripcionCadaver.Visible = true;
                    txtDescripcionCadaver.Text = dr1["DESCRIPCION_CADAVER"].ToString();


                    lblDatosFosa.Visible = true;
                    txtDatosFosa.Visible = true;
                    txtDatosFosa.Text = dr1["DATOS_FOSA"].ToString();

                    lblFechaEntrega.Visible = false;
                    lblFechaNo.Visible = true;
                    txtFechaEntrega.Visible = true;


                    lblNombreEntregaCuerpo.Visible = false;
                    txtNombreEntregaCuerpo.Visible = false;

                    lblParesntesco.Visible = false;
                    ddlParentesco.Visible = false;

                    


                }

                if (dr1["CUERPO_ENTREGADO"].ToString() == "2")
                {


                   

                    ddlCuerpoEntegado.SelectedValue = "2";

                    lblResguardoCadaver.Visible = true;
                    txtResguardoCadaver.Visible = true;
                    txtResguardoCadaver.Text = dr1["RESGUARDO_CADAVER"].ToString();
                    

                    txtFechaEntrega.Visible = false;
                    lblDescripcionVictima.Visible = false;
                    txtDescripcionCadaver.Visible = false;
                


                    lblDatosFosa.Visible = false;
                    txtDatosFosa.Visible = false;
                   

                    lblFechaEntrega.Visible = false;
                    lblFechaNo.Visible = false;
                    txtFechaEntrega.Visible = false;


                    lblNombreEntregaCuerpo.Visible = false;
                    txtNombreEntregaCuerpo.Visible = false;

                    lblParesntesco.Visible = false;
                    ddlParentesco.Visible = false;




                }


                if (dr1["CUERPO_ENTREGADO"].ToString() == "1")
                {


                    txtFechaEntrega.Text = dr1["FECHA_ENTREGA"].ToString();

                    ddlCuerpoEntegado.SelectedValue = "1";

                    lblNombreEntregaCuerpo.Visible = true;
                    txtNombreEntregaCuerpo.Visible = true;
                    txtNombreEntregaCuerpo.Text = dr1["NOMBRE_ENTREGA_CUERPO"].ToString();
                    
                    lblParesntesco.Visible = true;
                    ddlParentesco.Visible = true;
                    ddlParentesco.SelectedValue = dr1["PARENTESCO"].ToString();

                    lblFechaNo.Visible = false;
                    lblFechaEntrega.Visible = true;
                    txtFechaEntrega.Visible = true;

                    lblDescripcionVictima.Visible = false;
                    txtDescripcionCadaver.Visible = false;

                    lblDatosFosa.Visible = false;
                    txtDatosFosa.Visible = false;

                }

               
              
 
            }
            dr1.Close();

        }


        public void CargarMensajeHomicidio()
        {

            SqlCommand sql1 = new SqlCommand("CargarMensajeHomicidio " + int.Parse(IdCarpeta.Text) + "," + int.Parse(ID_HOMICIDIO.Text), Data.CnnCentral);
            SqlDataReader dr1 = sql1.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();

                txtMensaje.Text = dr1["MENSAJE"].ToString();
            }
            dr1.Close();

        }

        public void LimpiarBotonesDetencion() 
        {

          ddlOfendido.SelectedValue = "0";
          ddlImputado.SelectedValue = "0";
          ddlTipoPersonaOfendido.SelectedValue = "0";
          ddlTipoPersonaImputado.SelectedValue = "0";
          ddlOrganizacionDelictiva.SelectedValue = "0";
          ddlMovil.SelectedValue = "0";
          ddlSubDelito.SelectedValue = "0";
          ddlSituacion.SelectedValue = "0";


            //ddlOfendido.SelectedValue = "0";
            ddlViolencia.SelectedValue = "3";
            ddlCausaMuerte.SelectedValue = "0";
            ddlCondicionCadaver.SelectedValue = "0";
            ddlOrientacion.SelectedValue = "0";
            ddlPosicion.SelectedValue = "0";
            txtFechaMuerte.Text = "";
            txtHoraMuerte.Text = "00:00";
            txtFechaIdentificacion.Text = "";
            txtHoraIdentificacion.Text = "00:00";
                
            ddlCuerpoEntegado.SelectedValue = "0";

            txtPartesCuerpo.Text = "";

            ddlSubModalidad.SelectedValue = "0";

            lblFechaEntrega.Visible = false;
            lblFechaNo.Visible = false;
            lblNombreEntregaCuerpo.Visible = false;
            lblDescripcionVictima.Visible = false;
            lblParesntesco.Visible = false;


            lblDatosFosa.Visible = false;
            txtDatosFosa.Text = "";
            txtDatosFosa.Visible = false;

            ddlParentesco.SelectedValue = "0";
            ddlParentesco.Visible = false;

            txtNombreEntregaCuerpo.Text = "";
            txtNombreEntregaCuerpo.Visible = false;

            lblResguardoCadaver.Visible = false;
            txtResguardoCadaver.Text = "";
            txtResguardoCadaver.Visible = false;


            txtDescripcionCadaver.Text = "";
            txtDescripcionCadaver.Visible = false;

            txtFechaEntrega.Text = "";
            txtFechaEntrega.Visible = false;


            txtMensaje.Text = "";

            ValidationSummary2.Visible = false;


        }

        protected void cmdNuevoHomicidio_Click(object sender, EventArgs e)
        {
            Session["op"] = "Agregar";
            Response.Redirect("Homicidios.aspx");

        }

    }
}