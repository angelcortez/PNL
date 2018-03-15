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
    public partial class Defensor : System.Web.UI.Page
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
                typeof(Defensor),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                //-----

                lblArbol.Text = Session["lblArbol"].ToString();
                Session["ID_DEFENSOR"] = Request.QueryString["ID_DEFENSOR"];
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                
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
                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR DEFENSOR";
               
                   // cmdMedio.Enabled = false;

                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                    ID_TIPO_ACTOR.Text = Convert.ToString(6);
                    try{
                    
                    PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                    PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                    PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                    PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                    cargarImputado();
                    cargarAgregarDefensor();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Defensor.aspx?&op=Agregar");
                    }
                    

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DEFENSOR";
                    ddlImputado.Visible = false;
                   // cmdMedio.Enabled = true;
                    try
                    {
                        PGJ.CargaComboOrden(ddlNacionalidad, "Cat_Nacionalidad", "Id_Ncionldd", "Ncionldd", "Orden, Ncionldd");
                        PGJ.CargaComboOrden(ddlPais, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        PGJ.CargaCombo(ddlIdentificacion, "CAT_IDENTIFICACION", "ID_IDNTFCCION", "IDNTFCCION");
                        cargarDefensor();
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Defensor IdDefensor=" + ID_DEFENSOR.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Defensor.aspx?ID_DEFENSOR=" + Session["ID_DEFENSOR"].ToString() + "&op=Modificar");
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

        void cargarImputado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.ConsultaImputadoDefensor(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.IMPUTADO };
            ddlImputado.DataSource = im;
            ddlImputado.DataValueField = "ID_PERSONA";
            ddlImputado.DataTextField = "IMPUTADO";
            ddlImputado.DataBind();
        }
       
        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try 
            {

                if (Session["op"].ToString() == "Agregar" )
                {
                    PGJ.InsertaDefensor(int.Parse(ID_CARPETA.Text), int.Parse(ddlImputado.SelectedValue.ToString()), txtPaterno.Text, txtMaterno.Text, txtNombre.Text, 1, 6, short.Parse(ddlIdentificacion.SelectedValue.ToString()), txtFolio.Text, txtTelefono.Text, short.Parse(ddlNacionalidad.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), int.Parse(ddlLocalidadDom.SelectedValue.ToString()), int.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, short.Parse(Session["IdMunicipio"].ToString()));
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Defensor " + "IdCarpeta=" + ID_CARPETA.Text + " IdTipoActor=" + 6 + " Nombre: " + txtNombre.Text + " Paterno: " + txtPaterno.Text + " Materno: " + txtMaterno.Text + ddlIdentificacion.SelectedItem + " Folio: " + txtFolio.Text + " Telefono: " + txtTelefono.Text + " ORIGINARIO Nacionalidad: " + ddlNacionalidad.SelectedItem + " Pais: " + ddlPais.SelectedItem + " Estado: " + ddlEstado.SelectedItem + " Municipio: " + ddlMunicipio.SelectedItem + " DOMICILIO Pais: " + ddlPaisDom.SelectedItem + " Estado: " + ddlEstadoDom.SelectedItem + " Municipio: " + ddlMunicipioDom.SelectedItem + " Localidad: " + ddlLocalidadDom.SelectedItem + " Colonia: " + ddlColonia.SelectedItem + " Calle: " + ddlCalle.SelectedItem + " Entre Calle: " + ddlEntreCalle.SelectedItem + " Y Calle:" + ddlYcalle.SelectedItem + " Numero: " + txtNumero.Text + " Manzana: " + txtManzana.Text + " Lote: " + txtLote, int.Parse(Session["IdModuloBitacora"].ToString()));
            
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    PGJ.ActualizaDefensor(int.Parse(ID_DEFENSOR.Text), txtPaterno.Text, txtMaterno.Text, txtNombre.Text, short.Parse(rbDefensor.SelectedValue.ToString()), short.Parse(ddlIdentificacion.SelectedValue.ToString()), txtFolio.Text, txtTelefono.Text, short.Parse(ddlNacionalidad.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlMunicipio.SelectedValue.ToString()), short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), int.Parse(ddlLocalidadDom.SelectedValue.ToString()), int.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text);

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Defensor " + "IdCarpeta=" + Session["ID_CARPETA"] + " IdTipoActor=" + 6 + " Nombre: " + txtNombre.Text + " Paterno: " + txtPaterno.Text + " Materno: " + txtMaterno.Text + ddlIdentificacion.SelectedItem + " Folio: " + txtFolio.Text + " Telefono: " + txtTelefono.Text + " ORIGINARIO Nacionalidad: " + ddlNacionalidad.SelectedItem + " Pais: " + ddlPais.SelectedItem + " Estado: " + ddlEstado.SelectedItem + " Municipio: " + ddlMunicipio.SelectedItem + " DOMICILIO Pais: " + ddlPaisDom.SelectedItem + " Estado: " + ddlEstadoDom.SelectedItem + " Municipio: " + ddlMunicipioDom.SelectedItem + " Localidad: " + ddlLocalidadDom.SelectedItem + " Colonia: " + ddlColonia.SelectedItem + " Calle: " + ddlCalle.SelectedItem + " Entre Calle: " + ddlEntreCalle.SelectedItem + " Y Calle:" + ddlYcalle.SelectedItem + " Numero: " + txtNumero.Text + " Manzana: " + txtManzana.Text + " Lote: " + txtLote, int.Parse(Session["IdModuloBitacora"].ToString()));
            
                }
                lblEstatus.Text = "DATOS GUARDADOS";
                cmdGuardar.Enabled = false;
            
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
            //cmdMedio.Enabled = true;
         

        }

        protected void cmdReg_Click1(object sender, EventArgs e)
        {
            try {

                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            

                if (lblArbol.Text == "2")
                {

                    Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() );
                }

                else if (lblArbol.Text == "3")
                {
                    Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString()  );
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
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

        void cargarAgregarDefensor()
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

            ddlIdentificacion.SelectedValue = "0";


        }

        void cargarDefensor()
        {
            SqlCommand sql = new SqlCommand("cargarDefensor " + int.Parse(Session["ID_DEFENSOR"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_DEFENSOR.Text = dr["ID_DEFENSOR"].ToString();

                // ddlImputado.SelectedValue = dr["ID_PERSONA"].ToString();

                txtNombre.Text = dr["NOMBRE"].ToString();
                txtPaterno.Text = dr["PATERNO"].ToString();
                txtMaterno.Text = dr["MATERNO"].ToString();
                LBLIMPUTADO.Text = dr["IMPUTADO"].ToString();
               rbDefensor.SelectedValue = dr["DEFENSOR_PUB_PRIV"].ToString();
               ddlNacionalidad.SelectedValue = dr["ID_NACIONALIDAD"].ToString();

               Session["ID_PAIS"] = dr["ID_PAIS_ORIGEN"].ToString();
               ddlPais.SelectedValue = Session["ID_PAIS"].ToString();
               consultaPaisEstado();

               Session["ID_ESTADO"] = dr["ID_ESTADO_ORIGEN"].ToString();
               ddlEstado.SelectedValue = Session["ID_ESTADO"].ToString();
               consultaEstadoMunicipio();
               ddlMunicipio.SelectedValue = dr["ID_MUNICIPIO_ORIGEN"].ToString();

               Session["ID_PAIS_DOM"] = dr["ID_PAIS"].ToString();
               ddlPaisDom.SelectedValue = Session["ID_PAIS_DOM"].ToString();
               consultaPaisEstadoDom();

               Session["ID_ESTADO_DOM"] = dr["ID_ESTADO"].ToString();
               ddlEstadoDom.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
               consultaEstadoMunicipioDom();

               Session["ID_MUNICIPIO_DOM"] = dr["ID_MUNICIPIO"].ToString();
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
               ddlIdentificacion.SelectedValue = dr["ID_IDENTIFICACION"].ToString();
               txtFolio.Text = dr["FOLIO"].ToString();
               txtTelefono.Text = dr["TELEFONO"].ToString();
               
            }
            dr.Close();
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_PAIS"] = ddlPais.SelectedValue.ToString();
            consultaPaisEstado();
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

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO"] = ddlEstado.SelectedValue.ToString();
            consultaEstadoMunicipio();
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
            Session["ID_PAIS_DOM"] = ddlPaisDom.SelectedValue.ToString();
            consultaPaisEstadoDom();
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

        protected void ddlEstadoDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO_DOM"] = ddlEstadoDom.SelectedValue.ToString();
            consultaEstadoMunicipioDom();
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

        protected void ddlMunicipioDom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MUNICIPIO_DOM"] = ddlMunicipioDom.SelectedValue.ToString();
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

    }
}