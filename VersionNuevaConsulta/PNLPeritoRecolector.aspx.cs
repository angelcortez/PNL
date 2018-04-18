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
    public partial class PNLPeritoRecolector : System.Web.UI.Page
    {
        Data PGJ = new Data();
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                
                //Session["IdPNL"] = Request.QueryString["IdPNL"];
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                
               


                Session["op"] = Request.QueryString["op"];


                LBLUSUARIO.Text = Session["Us"].ToString();
                cargaCatalogos();

                if (Session["op"].ToString() == "Agregar")
                {
                    ID_DONANTE.Text = Request.QueryString["ID_DONANTE"];
                    Session["IdColectorMuestra"] = Request.QueryString["IdColectorMuestra"];
                    lblOperacion.Text = "AGREGAR COLECTOR MUESTRA";
                    //cargaCatalogos();

                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                    //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();


                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    Session["IDCOLECTORMUESTRA"] = Request.QueryString["IDCOLECTORMUESTRA"];
                    lblOperacion.Text = "MODIFICAR COLECTOR MUESTRA";
                    cargarColector();

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consultó Perito recolector con  IdColectorMuestra=" + Session["IDCOLECTORMUESTRA"].ToString() + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));


                    //cargaCatalogos();
                }

            }
        }


        private void cargaCatalogos()
        {
            PGJ.CargaComboFiltrado(ddlMunicipio, "CAT_MUNICIPIO", "ID_MNCPIO", "MNCPIO", "ID_ESTDO = 28");
        }

        void cargarColector()
        {
            try
            {
                SqlCommand sql = new SqlCommand("PNL_CargaColector " + int.Parse(Session["IDCOLECTORMUESTRA"].ToString()), Data.CnnCentral);
                SqlDataReader dr = sql.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                   
                    ////txtIdPNL.Text = dr["IdPNL"].ToString();
                    //ID_DONANTE.Text = dr["IdDonante"].ToString();
                    //ID_COLECTOR_MUESTRA.Text = dr["IdColectorMuestra"].ToString();
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtPaterno.Text = dr["Paterno"].ToString();
                    txtMaterno.Text = dr["Materno"].ToString();
                    txtNumeroEempleado.Text = dr["NumeroEmpleado"].ToString();
                    txtInstitucion.Text = dr["Institucion"].ToString();
                    txtPuesto.Text = dr["Puesto"].ToString();
                    ddlMunicipio.SelectedValue = dr["IdMunicipio"].ToString();
                    txtDptoPericial.Text = dr["DptoPericial"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
               
            }


        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                try
                {
                    PGJ.InsertaColectorMuestra(int.Parse(ID_CARPETA.Text), short.Parse(ID_MUNICIPIO_CARPETA.Text), int.Parse(ID_PERSONA.Text), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtNumeroEempleado.Text, txtInstitucion.Text, int.Parse(ddlMunicipio.SelectedValue), txtPuesto.Text, int.Parse(ID_DONANTE.Text), txtDptoPericial.Text);
                    string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";



                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Perito recolector con IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + ID_MUNICIPIO_CARPETA.Text + ", Nombre perito= " + txtNombre.Text + ", Apellido paterno= " + txtPaterno.Text + ", Apellido materno= " + txtMaterno.Text + ", Número empleado= " + txtNumeroEempleado.Text + ", Institución= " + txtInstitucion.Text + ", Municipio= " + ddlMunicipio.SelectedItem + ", Puesto= " + txtPuesto.Text + ", Departamento pericial= " + txtDptoPericial.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                



                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                catch (Exception ex)
                {
                   
                }


            }
            else if (Session["op"].ToString() == "Modificar")
            {
                try
                {
                    PGJ.ActualizaColectorMuestra(int.Parse(Session["IDCOLECTORMUESTRA"].ToString()), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtNumeroEempleado.Text, txtInstitucion.Text, short.Parse(ddlMunicipio.SelectedValue), txtPuesto.Text, txtDptoPericial.Text);
                    string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";


                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Perito recolector con IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + ID_MUNICIPIO_CARPETA.Text +", IdColectorMuestra= "+ Session["IDCOLECTORMUESTRA"].ToString()+ ", Nombre perito= " + txtNombre.Text + ", Apellido paterno= " + txtPaterno.Text + ", Apellido materno= " + txtMaterno.Text + ", Número empleado= " + txtNumeroEempleado.Text + ", Institución= " + txtInstitucion.Text + ", Municipio= " + ddlMunicipio.SelectedItem + ", Puesto= " + txtPuesto.Text + ", Departamento pericial= " + txtDptoPericial.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                catch (Exception ex)
                {
                   
                }


            }
            DesactivarControles();
            cmdGuardar.Enabled = false;
            
        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
         //   Response.Redirect("PNLDatosPrincipales.aspx?op=Modificar");


            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde Perito recolector", int.Parse(Session["IdModuloBitacora"].ToString()));
            

            Response.Redirect("PNLDatosPrincipales.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Modificar" + "&ID_MUNICIPIO_CARPETA=" + Session["ID_MUNICIPIO_CARPETA"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_PERTENENCIA_SOCIAL=" + Session["ID_PERTENENCIA_SOCIAL"].ToString() + "&ID_INFO_FINANCIERA=" + Session["ID_INFO_FINANCIERA"].ToString() + "&ID_INFO_ODONTOLOGICA=" + Session["ID_INFO_ODONTOLOGICA"].ToString() + "&ID_DISCAPACIDADES=" + Session["ID_DISCAPACIDADES"].ToString() + "&ID_OTRA_INFO=" + Session["ID_OTRA_INFO"].ToString() + "&ID_CAUSALES=" + Session["ID_CAUSALES"].ToString());
       
        }

        void DesactivarControles()
        {
            txtDptoPericial.Enabled = false;
            txtInstitucion.Enabled = false;
            txtMaterno.Enabled = false;
            txtNombre.Enabled = false;
            txtNumeroEempleado.Enabled = false;
            txtPaterno.Enabled = false;
            txtPuesto.Enabled = false;
        
        }

    }
}