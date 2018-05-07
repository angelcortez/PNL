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
    public partial class AgregarProfugoSec : System.Web.UI.Page
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



                    lblOperacion.Text = "AGREGAR DATOS DEL PRÓFUGO";


                    




                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DATOS DEL PRÓFUGO";

                    
                        //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                        //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                        
                        //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                        //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                        Session["ID_PROFUGO_SEC"] = Request.QueryString["ID_PROFUGO_SEC"];

                        
                        CargarProfugo();

                   

                                                          
                                        
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

        void CargarProfugo()
        {
            SqlCommand sql = new SqlCommand("CargarProfugoIndividual " + int.Parse(Session["ID_PROFUGO_SEC"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)

           
            {
                dr.Read();


                

                txtNombre.Text = dr["NOMBRE"].ToString();
                txtPaterno.Text = dr["PATERNO"].ToString();
                txtMaterno.Text = dr["MATERNO"].ToString();
                txtAlias.Text = dr["ALIAS"].ToString();
                


            }
            dr.Close();

        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                try
                {
                    PGJ.InsertaProfugoSec(int.Parse(ID_CARPETA.Text), int.Parse(Session["IdMunicipio"].ToString()), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtAlias.Text);
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
                    PGJ.ActualizaProfugoSec(int.Parse(Session["ID_PROFUGO_SEC"].ToString()), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtAlias.Text);
                    cmdGu.Visible = false;
                    lblEstatus1.Text = "DATOS GUARDADOS";
                    DesactivarControles();



                }
                catch (Exception ex)
                {

                }


            }
        }

        void DesactivarControles()
        {

            txtNombre.Enabled = false;
            txtPaterno.Enabled = false;
            txtMaterno.Enabled = false;
            txtAlias.Enabled = false;
            



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