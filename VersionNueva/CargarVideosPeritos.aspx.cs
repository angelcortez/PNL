using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace AtencionTemprana
{
    public partial class CargarVideosPeritos : System.Web.UI.Page

        
    {
        int varVideo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            cargarFecha();
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            IdCarpeta.Text = Session["ID_CARPETA"].ToString();
            IdUsuario.Text = Session["IdUsuario"].ToString();
            IdOrden.Text = Session["ID_SP"].ToString();

            gvVideosP.Visible = false;

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

                if (FileUpload.HasFile)
                {
                    // Se verifica que la extensión sea de un formato válido
                    
                    /////////////////////////////////////////////INTERNET EXPLORER////////////////////////////////////////////
                    // herramientas
                    //opciones de internet 
                    //seguridad
                    //nivel personalizado
                    //incluir la ruta de acceso al directorio local cuando se cargue los archivos al servidor
                    //desabilitar
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string ext = FileUpload.PostedFile.FileName;
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
                        GuardarArchivo(FileUpload.PostedFile);

                        if (varVideo == 0)
                        {

                        PGJ.InsertarVideo_Perito(Convert.ToInt32(IdOrden.Text),Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(IdUsuario.Text), FileUpload.PostedFile.FileName, txtTitulo.Text, txtDescripcion.Text);

                        //Mostramos el video recien agegado
                        gvVideosP.Visible = true;
                        gvVideosP.DataSourceID = "dsCargarVideoRecienteP";
                        gvVideosP.DataBind();

      

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
            catch
            {
                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                                        alert('NO ES POSIBLE SUBIR EL VÍDEO'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
             
             

        }

        private void GuardarArchivo(HttpPostedFile file)
        {
            // Se carga la ruta donde se subira el archivo
            string ruta = Server.MapPath(".") + "\\VideosPericiales";

            string archivo = String.Format("{0}\\{1}", ruta, file.FileName);

            // Verificar que el archivo no exista
            if (File.Exists(archivo))
            {
                varVideo = 1;
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
            string sql = "Select VIDEO From  PGJ_VIDEO_SOL_PERICIALES  Where ID_VIDEO_SOL_PERICIALES = " + e.CommandArgument.ToString();
            Data.CnnCentral.Close();

            SqlCommand SqlCom = new SqlCommand(sql, Data.CnnCentral);
            Data.CnnCentral.Open();
            string fileName = ((string)SqlCom.ExecuteScalar());

            // Se carga la ruta donde se ubica el archivo
            string ruta = Server.MapPath(".") + "\\VideosPericiales";
            string archivo = String.Format("{0}\\{1}", ruta, fileName);


            if (File.Exists(archivo))
            {

                PGJ.EliminarVideoPericiales(Convert.ToInt32(e.CommandArgument.ToString()));
                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                            alert('VÍDEO ELIMINADO');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                gvVideosP.DataSourceID = "dsCargarVideoRecienteP";
                gvVideosP.DataBind();

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
            Response.Redirect("OrdenPerito.aspx");
        }

        protected void IBEliminar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EliminarVideosPeritos.aspx");
        }


    }
}