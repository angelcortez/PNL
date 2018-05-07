using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class CargarFotografiasPerito : System.Web.UI.Page
    {

        Data PGJ = new Data();


        protected void Page_Load(object sender, EventArgs e)
        {
            Ifoto.Visible = false;
            cargarFecha();
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            IdCarpeta.Text = Session["ID_CARPETA"].ToString();
            IdUsuario.Text = Session["IdUsuario"].ToString();
            IdSP.Text = Session["ID_SP"].ToString();


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

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            // Comprobamos que existe fichero y que no esta vacio
            if ((ImagenFile.PostedFile != null) && (ImagenFile.PostedFile.ContentLength > 0))
            {

                Ifoto.Visible = true;

                //obtener archivos subidos
                HttpPostedFile ImgFile = ImagenFile.PostedFile;
                // crear el array
                // Almacenamos la imagen en una variable para insertarla en la bd.//buscar la longitud y convertir en longitud byte
                Byte[] foto = new Byte[ImagenFile.PostedFile.ContentLength];
                //cargado en una matriz de bytes
                ImgFile.InputStream.Read(foto, 0, ImagenFile.PostedFile.ContentLength);

                PGJ.ConnectServer();
                PGJ.InsertarImagen_Perito(Convert.ToInt32(IdSP.Text),Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(IdUsuario.Text), foto, txtTitulo.Text, txtdescripcion.Text);

                //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
             //   PGJ.ModificarEstadoOrden_PI(Convert.ToInt32(IdOrden.Text), 3);
             //   PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

                PGJ.ConnectServer();
                SqlCommand SqlCom1 = new SqlCommand("Select MAX(ID_FOTO_SOL_PERICIALES) From PGJ_FOTO_SOL_PERICIALES", Data.CnnCentral);
                Session["lastID"] = SqlCom1.ExecuteScalar().ToString();

                Data.CnnCentral.Close();
               

                IBDelete.Visible = true;
                lblEliminar.Visible = true;

                //Muestra la Imagen recien Guardada
                Ifoto.ImageUrl = "fotosPericiales.ashx?Id=" + Session["lastID"].ToString();

            }


        }

        protected void IBOrden_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrdenPerito.aspx");
        }

        protected void IBDelete_Click(object sender, ImageClickEventArgs e)
        {

            PGJ.EliminarFotografiaSolicitudPe(Convert.ToInt32(Session["lastID"].ToString()));

            //Colocar Alerta 
            string script = @"<script type='text/javascript'>
                            alert('IMAGEN ELIMINADA.');
                                   </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            IBDelete.Visible = false;
            lblEliminar.Visible = false;

        }

        protected void IBEliminar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EliminarImagenesSolicitudPericiales.aspx");
        }




    }
}