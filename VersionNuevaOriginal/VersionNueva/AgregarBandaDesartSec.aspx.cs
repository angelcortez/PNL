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
    public partial class AgregarBandaDesartSec : System.Web.UI.Page
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


                if (Session["op"].ToString() == "Agregar")
                {

                    //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                   

                    //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();



                    lblOperacion.Text = "AGREGAR DATOS DE LA BANDA";
                                     
                    

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DATOS DE LA BANDA";

                    try
                    {
                        //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                        Session["ID_BANDA_DES"] = Request.QueryString["ID_BANDA_DES"];
                        ID_BANDA.Text = Session["ID_BANDA_DES"].ToString();

                        

                        //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                        //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                        //Session["ID_BANDA_DES"] = Request.QueryString["ID_BANDA_DES"];

                       
                        CargarBanda();

                    }

                    catch (Exception ex)
                    {


                    }
                    

                }
                

            }
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

        void CargarBanda()
        {

            SqlCommand sql = new SqlCommand("CargarBanda " + int.Parse(Session["ID_BANDA_DES"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                
                txtNombreBanda.Text = dr["NOMBRE_BANDA"].ToString();
                txtBienesAsegurados.Text = dr["BIENES_ASEGURADOS"].ToString();
                
            }
            dr.Close();
        
        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                try
                {
                    PGJ.InsertaBandaSec(int.Parse(ID_CARPETA.Text), int.Parse(Session["IdMunicipio"].ToString()), txtNombreBanda.Text, txtBienesAsegurados.Text);
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
                    PGJ.ActualizaBandaSec(int.Parse(Session["ID_BANDA_DES"].ToString()), txtNombreBanda.Text, txtBienesAsegurados.Text);
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


        void DesactivarControles()
        {

            txtBienesAsegurados.Enabled = false;
            txtNombreBanda.Enabled = false;
        
        }





    }
}