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
    public partial class EliminarVideosPeritos : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {

            IdUsuario.Text = Session["IdUsuario"].ToString();
            IdMunicipio.Text = Session["IdMunicipio"].ToString();
            IdUnidad.Text = Session["IdUnidad"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            IdCarpeta.Text = Session["ID_CARPETA"].ToString();
            IdOrden.Text = Session["ID_SP"].ToString();

        }


        public void IBImage_Command(object sender, CommandEventArgs e)
        {

            //Se obtiene el nombre del Video para Eliminarlo
            PGJ.ConnectServer();
            string sql = "Select VIDEO From  PGJ_VIDEO_SOL_PERICIALES Where ID_VIDEO_SOL_PERICIALES = " + e.CommandArgument.ToString();
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

                gvVideos.DataSourceID = "dsCargarVideos";
                gvVideos.DataBind();

                File.Delete(archivo);

                Response.Redirect("EliminarVideosPeritos.aspx");

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
            Response.Redirect("CargarVideosPeritos.aspx");
        }



    }
}