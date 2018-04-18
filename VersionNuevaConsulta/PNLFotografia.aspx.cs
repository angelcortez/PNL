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
    public partial class PNLFotografia : System.Web.UI.Page
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

                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();

                cargarFecha();



                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
              
               

                if (Session["op"].ToString() == "Agregar")
                {

                    lblOperacion.Text = "AGREGAR FOTOGRAFÍA";
                    //cargaCatalogos();

                    cargarOfendido();


                    ////Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    ////Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();


                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    Session["IDFOTOGRAFIA"] = Request.QueryString["IDFOTOGRAFIA"];
                    ID_FOTOGRAFIA.Text = Session["IDFOTOGRAFIA"].ToString();

                    lblOperacion.Text = "MODIFICAR FOTOGRAFÍA";
                    //CargarFoto();
                    Ifoto.Visible = true;
                    Ifoto.ImageUrl = "FotoPNL.ashx?Id=" + ID_FOTOGRAFIA.Text;
                    cargarOfendido();
                    cargarDatos();
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consultó la fotografía con IdFotografia=" + ID_FOTOGRAFIA.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));


                }
            }
        }

        void cargarDatos()
        {
            SqlCommand sql = new SqlCommand("SP_DatosFoto " + int.Parse(Session["IDFOTOGRAFIA"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();


                ddlOfendido.SelectedValue = dr["IdPersona"].ToString();
                txtDescripcion.Text = dr["Descripcion"].ToString();

            }
            dr.Close();

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


        void CargarFoto()
        {

            try
            {
                SqlCommand sql = new SqlCommand("PNL_ConsultarFotoInd " + int.Parse(Session["IDFOTOGRAFIA"].ToString()), Data.CnnCentral);
                SqlDataReader dr = sql.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();

                    txtDescripcion.Text = dr["Descripcion"].ToString();
                    
                }
                dr.Close();
            }
            catch (Exception ex)
            {

            }

        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            Byte[] foto;


            if (ddlOfendido.SelectedValue == "0")
            {
                lblEstatus.Text = "SELECCIONA PERSONA";
            }
            else
            {
                if (Session["op"].ToString() == "Agregar")
                {
                    try
                    {
                        // Comprobamos que existe IMAGEN y que no esta vacio
                        if ((ImagenFile.PostedFile != null) && (ImagenFile.PostedFile.ContentLength > 0))
                        {


                            //obtener archivos subidos
                            HttpPostedFile ImgFile = ImagenFile.PostedFile;
                            // crear el array
                            // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                            foto = new Byte[ImagenFile.PostedFile.ContentLength];
                            //cargado en una matriz de bytes
                            ImgFile.InputStream.Read(foto, 0, ImagenFile.PostedFile.ContentLength);
                        }
                        else
                        {
                            foto = new Byte[0];
                        }

                        PGJ.PNLInsertaFotografia(int.Parse(ID_CARPETA.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), foto, txtDescripcion.Text);
                        string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";


                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta fotografía con IdCarpeta= " + ID_CARPETA.Text + ", IdMunicipio " + Session["IdMunicipio"].ToString() + ", Descripción de foto= " + txtDescripcion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                



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
                        if ((ImagenFile.PostedFile != null) && (ImagenFile.PostedFile.ContentLength > 0))
                        {
                            Ifoto.Visible = true;
                           //obtener archivos subidos
                            HttpPostedFile ImgFile = ImagenFile.PostedFile;
                            // crear el array
                            // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                            foto = new Byte[ImagenFile.PostedFile.ContentLength];
                            //cargado en una matriz de bytes
                            ImgFile.InputStream.Read(foto, 0, ImagenFile.PostedFile.ContentLength);
                            PGJ.PNLActualizaFotografia(int.Parse(ID_FOTOGRAFIA.Text), foto);
                            //Muestra la Imagen recien Guardada
                            Ifoto.ImageUrl = "FotoPNL.ashx?Id=" + ID_FOTOGRAFIA.Text;
                        }
                        PGJ.PNLActualizaDescFoto(int.Parse(ID_FOTOGRAFIA.Text), txtDescripcion.Text);

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Modifica descripción de fotografía con IdFotografia= " + ID_FOTOGRAFIA.Text  + ", Descripción de foto= " + txtDescripcion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                

                        CargarFoto();
                        string script = @"<script type='text/javascript'>
                                alert('DATOS GUARDADOS');  </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                cmdGuardar.Enabled = false;
            }
        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("PNLDatosPrincipales.aspx?op=Modificar");

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde Fotografía", int.Parse(Session["IdModuloBitacora"].ToString()));
           

            Response.Redirect("PNLDatosPrincipales.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Modificar" + "&ID_MUNICIPIO_CARPETA=" + Session["ID_MUNICIPIO_CARPETA"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_DATOS_GENERALES=" + Session["ID_DATOS_GENERALES"].ToString() + "&ID_PERTENENCIA_SOCIAL=" + Session["ID_PERTENENCIA_SOCIAL"].ToString() + "&ID_INFO_FINANCIERA=" + Session["ID_INFO_FINANCIERA"].ToString() + "&ID_INFO_ODONTOLOGICA=" + Session["ID_INFO_ODONTOLOGICA"].ToString() + "&ID_DISCAPACIDADES=" + Session["ID_DISCAPACIDADES"].ToString() + "&ID_OTRA_INFO=" + Session["ID_OTRA_INFO"].ToString() + "&ID_CAUSALES=" + Session["ID_CAUSALES"].ToString());
       
        }








        }
    }
