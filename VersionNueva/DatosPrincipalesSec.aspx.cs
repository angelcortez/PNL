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
    public partial class DatosPrincipalesSec : System.Web.UI.Page
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


                //TRAER LOS ID QUE SE NECESITAN PARA ALMACENAR LA INFO EN LA TABLA//
               // Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
               // Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
              //  Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];

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

                 //   Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                    //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                  //  Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                 //   Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();



                    lblOperacion.Text = "COMPLEMENTAR DATOS DEL SECUESTRO";


                    //LLENAR COMBOS PARA INSERTAR POR PRIMERA VEZ
                    PGJ.CargaCombo(ddlEstatusSecuestro, "CAT_ESTATUS_SECUESTRO", "ID_ESTATUS_SECUESTRO", "ESTATUS_SECUESTRO");
                    PGJ.CargaCombo(ddlEtapaAtencion, "CAT_ETAPA_ATENCION_SEC", "ID_ETAPA_ATENCION", "ETAPA_ATENCION");
                    PGJ.CargaCombo(ddlTipoSecuestro, "CAT_TIPO_SECUESTRO", "ID_TIPO_SECUESTRO", "TIPO_SECUESTRO");
                    cargarOfendido();
                   


                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DATOS DEL SECUESTRO";

                    try
                    {
                       // Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                      //  ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                      //  Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                      //  ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                      //  Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                      //  ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                        Session["ID_PRINC_SEC"] = Request.QueryString["ID_PRINC_SEC"];

                        PGJ.CargaCombo(ddlEstatusSecuestro, "CAT_ESTATUS_SECUESTRO", "ID_ESTATUS_SECUESTRO", "ESTATUS_SECUESTRO");
                        PGJ.CargaCombo(ddlEtapaAtencion, "CAT_ETAPA_ATENCION_SEC", "ID_ETAPA_ATENCION", "ETAPA_ATENCION");
                        PGJ.CargaCombo(ddlTipoSecuestro, "CAT_TIPO_SECUESTRO", "ID_TIPO_SECUESTRO", "TIPO_SECUESTRO");
                        
                        CargarDatosComplementarios();
                        cargarOfendido();
                        //ddlOfendido.Visible = false;

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

        void CargarDatosComplementarios()
        {

            SqlCommand sql = new SqlCommand("CargarDatosPrincSec " + int.Parse(Session["ID_PRINC_SEC"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_PRINC_SEC.Text = dr["ID_PRINC_SEC"].ToString();
                ddlOfendido.SelectedValue = dr["ID_PERSONA"].ToString(); 
                ddlEstatusSecuestro.SelectedValue = dr["ID_ESTATUS_SECUESTRO"].ToString();
                ddlEtapaAtencion.SelectedValue = dr["ID_ETAPA_ATENCION"].ToString();
                ddlTipoSecuestro.SelectedValue = dr["ID_TIPO_SECUESTRO"].ToString();

                txtFechaPrivacion.Text = dr["FECHA_PRIVACION"].ToString();
                txtHoraPrivacion.Text = dr["HORA_PRIVACION"].ToString();
                ddlAmenazaMuerte.SelectedValue = dr["AMENAZA_MUERTE"].ToString();
                chbAltoImpacto.Checked = bool.Parse(dr["ALTO_IMPACTO"].ToString());
                chbDelincuenciaOrganizada.Checked = bool.Parse(dr["DELINCUENCIA_ORG"].ToString());
                chbAniosAnteriores.Checked = bool.Parse(dr["ANIOS_ANTERIORES"].ToString());
                chbOtrosEstados.Checked = bool.Parse(dr["OTROS_ESTADOS"].ToString());
                chbMigrantes.Checked = bool.Parse(dr["MIGRANTES"].ToString());
                chbAutoSecuestro.Checked = bool.Parse(dr["AUTO_SECUESTRO"].ToString());
                chbRoboVehiculo.Checked = bool.Parse(dr["ROBO_VEHICULO"].ToString());
                chbPrivacionLibertad.Checked = bool.Parse(dr["PNL"].ToString());
                chbTentativa.Checked = bool.Parse(dr["SECUESTRO_TENTATIVA"].ToString());
                chbSubstraccionMenores.Checked = bool.Parse(dr["SUBSTRACCION_MENORES"].ToString());
                
               
                                          
            }
            dr.Close();
        
        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                try
                {
                    PGJ.InsertaDatosPrincSec(int.Parse(ID_CARPETA.Text), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlEtapaAtencion.SelectedValue), int.Parse(ddlEstatusSecuestro.SelectedValue), int.Parse(ddlTipoSecuestro.SelectedValue), DateTime.Parse(txtFechaPrivacion.Text), txtHoraPrivacion.Text, short.Parse(ddlAmenazaMuerte.SelectedValue.ToString()), chbAltoImpacto.Checked, chbDelincuenciaOrganizada.Checked, chbAniosAnteriores.Checked, chbOtrosEstados.Checked, chbMigrantes.Checked, chbAutoSecuestro.Checked, chbRoboVehiculo.Checked, chbPrivacionLibertad.Checked, chbTentativa.Checked, chbSubstraccionMenores.Checked);
                    cmdGu.Visible = false;
                    lblEstatus.Text = "DATOS GUARDADOS";
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
                    PGJ.ActualizaDatosPrincSec(int.Parse(Session["ID_PRINC_SEC"].ToString()), int.Parse(ddlEtapaAtencion.SelectedValue), int.Parse(ddlEstatusSecuestro.SelectedValue), int.Parse(ddlTipoSecuestro.SelectedValue), DateTime.Parse(txtFechaPrivacion.Text), txtHoraPrivacion.Text, short.Parse(ddlAmenazaMuerte.SelectedValue.ToString()), chbAltoImpacto.Checked, chbDelincuenciaOrganizada.Checked, chbAniosAnteriores.Checked, chbOtrosEstados.Checked, chbMigrantes.Checked, chbAutoSecuestro.Checked, chbRoboVehiculo.Checked, chbPrivacionLibertad.Checked, chbTentativa.Checked, chbSubstraccionMenores.Checked);
                    
                    cmdGu.Visible = false;
                    lblEstatus.Text = "DATOS GUARDADOS";
                    DesactivarControles();
                   


                }
                catch (Exception ex)
                {
                   
                }


            }
        }


        void DesactivarControles()
        {

            ddlEstatusSecuestro.Enabled = false;
            ddlEtapaAtencion.Enabled = false;
            ddlTipoSecuestro.Enabled = false;
            txtFechaPrivacion.Enabled = false;
            txtHoraPrivacion.Enabled = false;
            ddlAmenazaMuerte.Enabled = false;
            Panel9.Enabled = false;
        
        
        
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
          //  Response.Redirect("PruebaPantallas.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1");
              if (lblArbol.Text == "8")
                {
                    Response.Redirect("NUC_SECUESTRO.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                }
        }








    }
}