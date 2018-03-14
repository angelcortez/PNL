using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace AtencionTemprana
{
    public partial class CargarVideo : System.Web.UI.Page
    {

        int varArchivo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


            cargarFecha();
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            IdCarpeta.Text = Session["ID_CARPETA"].ToString();
            IdUsuario.Text = Session["IdUsuario"].ToString();
            IdOrden.Text = Session["ID_ORDEN"].ToString();


            gvVideos.Visible = false;


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

     

        Data PGJ = new Data();

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (FileUpload1.HasFile)
                {
                    // Se verifica que la extensión sea de un formato válido
                    string ext = FileUpload1.PostedFile.FileName;
                    ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                    string[] formatos =
                    new string[] { "avi", "wmv", "mp4", "flv" };
                    if (Array.IndexOf(formatos, ext) < 0)
                    {
                        //Colocar Alerta 
                        string script = @"<script type='text/javascript'>
                             alert('ELIJA UN FORMATO DE VÍDEO VALIDO'); </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                    else
                    {
                        GuardarArchivo(FileUpload1.PostedFile);

                        if (varArchivo == 0)
                        {
                            PGJ.InsertarVideo_PI(Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(IdUsuario.Text), FileUpload1.PostedFile.FileName, txtTitulo.Text, txtDescripcion.Text);

                            //INSERTAMOS LA BITACORA DEL SISTEMA
                            PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "El Video '" + txtTitulo.Text + "' fue guardada por el Policias con ID" + IdUsuario.Text);

                            //Mostramos el video recien agegado
                            gvVideos.Visible = true;
                            gvVideos.DataSourceID = "dsCargarVideoReciente";
                            gvVideos.DataBind();
                        
                            //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
                            PGJ.ModificarEstadoOrden_PI(Convert.ToInt32(IdOrden.Text), 3);
                            PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

                            //Colocar Alerta 
                            string script = @"<script type='text/javascript'>
                                            alert('EL VÍDEO HA SIDO GUARDADO'); </script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        }
                    }
                }
                else
                {
                    Label1.Text = "SELECCIONE UN VÍDEO";
                }
            }
            catch{
                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                                        alert('NO ES POSIBLE SUBIR EL VÍDEO'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
                 
        }

        private void GuardarArchivo(HttpPostedFile file)
        {
            // Se carga la ruta donde se subira el archivo
            string ruta = Server.MapPath(".") + "\\VideosPI";

            

            string archivo = String.Format("{0}\\{1}", ruta, file.FileName);

            // Verificar que el archivo no exista
            if (File.Exists(archivo))
            {

                varArchivo = 1;

                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                                        alert('EL NOMBRE DEL ARCHIVO YA EXISTE, FAVOR DE CAMBIARLO');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                
            }
            else
            {
                file.SaveAs(archivo);

               
            }
        }

        public void IBImage_Command(object sender, CommandEventArgs e)
        {

            //Se obtiene el nombre del Video para Eliminarlo
            PGJ.ConnectServer();
            string sql = "Select VIDEO From  PGJ_VIDEO_ORDEN_PI Where ID_VIDEO_ORDEN_PI = " + e.CommandArgument.ToString();
            Data.CnnCentral.Close();

            SqlCommand SqlCom = new SqlCommand(sql, Data.CnnCentral);
            Data.CnnCentral.Open();
            string fileName = ((string)SqlCom.ExecuteScalar());

            // Se carga la ruta donde se ubica el archivo
            string ruta = Server.MapPath(".") + "\\VideosPI";
            string archivo = String.Format("{0}\\{1}", ruta, fileName);


            if (File.Exists(archivo))
            {

                PGJ.EliminarVideoPI(Convert.ToInt32(e.CommandArgument.ToString()));
                //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
                PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                            alert('VÍDEO ELIMINADO');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                gvVideos.DataSourceID = "dsCargarVideoReciente";
                gvVideos.DataBind();

                File.Delete(archivo);

                

            }
            else
            {
                //Colocar Alerta 
                string script1 = @"<script type='text/javascript'>
                            alert('NO ES POSIBLE ELIMINAR EL VÍDEO');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);

            }


        }
       

        

        protected void IBOrden_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrdenPoliciaInvestigador.aspx");
        }

        protected void IBEliminar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EliminarVideos.aspx");
        }


    }
}