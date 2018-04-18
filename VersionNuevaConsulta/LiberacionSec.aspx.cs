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
    public partial class LiberacionSec : System.Web.UI.Page
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
                typeof(Datos),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                //---


                ////TRAER LOS ID QUE SE NECESITAN PARA ALMACENAR LA INFO EN LA TABLA//
                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];

                //TRAE EL USUARIO, PUESTO, UNIDAD Y LA OPERACIÓN. ADEMÁS DE CARGAR LA FECHA ACTUAL// 
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                lblArbol.Text = Session["lblArbol"].ToString();

                cargarFecha();
                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                if (Session["op"].ToString() == "Agregar")
                {

                    //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                    

                    //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();



                    lblOperacion.Text = "AGREGAR DATOS DE LA LIBERACIÓN";


                    //LLENAR COMBOS PARA INSERTAR POR PRIMERA VEZ
                    PGJ.CargaCombo(ddlCorporacionLib, "CAT_CORPORACION", "ID_CORPORACION", "CORPORACION");
                    PGJ.CargaCombo(ddlMetodoLiberacion, "CAT_METODO_LIBERACION", "ID_METODO_LIBERACION", "METODO_LIBERACION");
                    PGJ.CargaCombo(ddlCondicionesLocalizacion, "CAT_CONDICIONES_LOC", "ID_CONDICIONES_LOC", "CONDICIONES_LOC");
                    PGJ.CargaCombo(ddlLugarReferencia, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                    PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");

                    cargarOfendido();


                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DATOS DE LA LIBERACIÓN";

                    try
                    {
                        //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                        //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                        //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                        //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                        //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                        //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                        Session["ID_LIB_SEC"] = Request.QueryString["ID_LIB_SEC"];

                        PGJ.CargaCombo(ddlCorporacionLib, "CAT_CORPORACION", "ID_CORPORACION", "CORPORACION");
                        PGJ.CargaCombo(ddlMetodoLiberacion, "CAT_METODO_LIBERACION", "ID_METODO_LIBERACION", "METODO_LIBERACION");
                        PGJ.CargaCombo(ddlCondicionesLocalizacion, "CAT_CONDICIONES_LOC", "ID_CONDICIONES_LOC", "CONDICIONES_LOC");
                        PGJ.CargaCombo(ddlLugarReferencia, "CAT_LUGAR_TIPO", "ID_LGR_TPO", "LGR_TPO");
                        PGJ.CargaComboOrden(ddlPaisDom, "Cat_Pais", "Id_Pais", "Pais", "Orden, Pais");
                        cargarOfendido();
                        CargarLiberacionSec();

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


        void CargarLiberacionSec()
        {


            SqlCommand sql = new SqlCommand("CargarLiberacionSec " + int.Parse(Session["ID_LIB_SEC"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ddlOfendido.SelectedValue = dr["ID_PERSONA"].ToString();
                ddlVM.SelectedValue = dr["VIVO_O_MUERTO"].ToString();
                ddlCorporacionLib.SelectedValue = dr["ID_CORPORACION"].ToString();
                ddlMetodoLiberacion.SelectedValue = dr["ID_METODO_LIBERACION"].ToString();
                ddlCondicionesLocalizacion.SelectedValue = dr["ID_CONDICIONES_LOC"].ToString();
               
                ddlLugarReferencia.SelectedValue = dr["ID_LGR_TPO"].ToString();

                txtFechaLiberacion.Text = dr["FECHA_LIBERACION"].ToString();
                txtHoraLiberacion.Text = dr["HORA_LIBERACION"].ToString();
                txtDuracionSecuestro.Text = dr["DURACION_SEC"].ToString();
                txtNumero.Text = dr["NUMERO"].ToString();
                txtManzana.Text = dr["MANZANA"].ToString();
                txtLote.Text = dr["LOTE"].ToString();

                Session["ID_PAIS_DOM"] = dr["ID_PAIS"].ToString();
                ddlPaisDom.SelectedValue = Session["ID_PAIS_DOM"].ToString();
                consultaPaisEstadoDom();

                Session["ID_ESTADO_DOM"] = dr["ID_ESTADO"].ToString();
                ddlEstadoDom.SelectedValue = Session["ID_ESTADO_DOM"].ToString();
                consultaEstadoMunicipioDom();

                Session["ID_MUNICIPIO_DOM"] = dr["ID_MNCPIO"].ToString();
                ddlMunicipioDom.SelectedValue = Session["ID_MUNICIPIO_DOM"].ToString();
                consultaMunicipioLocalidad();

                Session["ID_LOCALIDAD"] = dr["ID_LCLDD"].ToString();
                ddlLocalidadDom.SelectedValue = Session["ID_LOCALIDAD"].ToString();

                ddlColonia.SelectedValue = dr["ID_CLNIA"].ToString();
                consultaLocalidadColonia();

                ddlCalle.SelectedValue = dr["ID_CLLE"].ToString();
                consultaLocalidadCalle();

                ddlEntreCalle.SelectedValue = dr["ID_ENTRE_CALLE"].ToString();
                consultaLocalidadEntreCalle();

                ddlYcalle.SelectedValue = dr["ID_Y_CALLE"].ToString();
                consultaLocalidadYCalle();           
                         
                          
                               
                


            }
            dr.Close();
        
        
        
        }
             
                
                

        //protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_PAIS"] = ddlPaisDom.SelectedValue.ToString();
        //    consultaPaisEstado();
        //}
        void consultaPaisEstado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS"].ToString()))
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
            ddlMunicipioDom.DataSource = municipio;
            ddlMunicipioDom.DataValueField = "ID_MNCPIO";
            ddlMunicipioDom.DataTextField = "MNCPIO";
            ddlMunicipioDom.DataBind();
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

        void DesactivarControles()
        {

            ddlCalle.Enabled = false;
            ddlColonia.Enabled = false;
            ddlCondicionesLocalizacion.Enabled = false;
            ddlCorporacionLib.Enabled = false;
            ddlEntreCalle.Enabled = false;
            ddlEstadoDom.Enabled = false;
            ddlLocalidadDom.Enabled = false;
            ddlLugarReferencia.Enabled = false;
            ddlMetodoLiberacion.Enabled = false;
            ddlMunicipioDom.Enabled = false;
            ddlVM.Enabled = false;
            ddlYcalle.Enabled = false;
            txtDuracionSecuestro.Enabled = false;
            txtFechaLiberacion.Enabled = false;
            txtHoraLiberacion.Enabled = false;
            txtLote.Enabled = false;
            txtManzana.Enabled = false;
            txtNumero.Enabled = false;
            
        
        
        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                try
                {
                    PGJ.InsertaLiberacionSec(int.Parse(ID_CARPETA.Text), int.Parse(ddlOfendido.SelectedValue.ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlCorporacionLib.SelectedValue), int.Parse(ddlMetodoLiberacion.SelectedValue), int.Parse(txtDuracionSecuestro.Text), DateTime.Parse(txtFechaLiberacion.Text), txtHoraLiberacion.Text, short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), short.Parse(ddlLocalidadDom.SelectedValue.ToString()), short.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, int.Parse(ddlLugarReferencia.SelectedValue.ToString()), short.Parse(ddlVM.SelectedValue.ToString()), int.Parse(ddlCondicionesLocalizacion.SelectedValue.ToString()));                        
                    cmdGu.Visible = false;
                    lblEstatus1.Text = "DATOS GUARDADOS";
                    DesactivarControles();



                }
                catch (Exception ex)
                {

                }


            }
            else if (Session["op"].ToString() == "Modificar")
            {
                try
                {
                    PGJ.ActualizaLiberacionSec(int.Parse(Session["ID_LIB_SEC"].ToString()), short.Parse(ddlCorporacionLib.SelectedValue), int.Parse(ddlMetodoLiberacion.SelectedValue), int.Parse(txtDuracionSecuestro.Text), DateTime.Parse(txtFechaLiberacion.Text), txtHoraLiberacion.Text, short.Parse(ddlPaisDom.SelectedValue.ToString()), short.Parse(ddlEstadoDom.SelectedValue.ToString()), short.Parse(ddlMunicipioDom.SelectedValue.ToString()), short.Parse(ddlLocalidadDom.SelectedValue.ToString()), short.Parse(ddlColonia.SelectedValue.ToString()), int.Parse(ddlCalle.SelectedValue.ToString()), int.Parse(ddlEntreCalle.SelectedValue.ToString()), int.Parse(ddlYcalle.SelectedValue.ToString()), txtNumero.Text, txtManzana.Text, txtLote.Text, int.Parse(ddlLugarReferencia.SelectedValue.ToString()), short.Parse(ddlVM.SelectedValue.ToString()), short.Parse(ddlCondicionesLocalizacion.SelectedValue.ToString())); 
                    cmdGu.Visible = false;
                    lblEstatus1.Text = "DATOS GUARDADOS";
                    DesactivarControles();



                }
                catch (Exception ex)
                {

                }


            }
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_SECUESTRO.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }
        }

        
    }
}