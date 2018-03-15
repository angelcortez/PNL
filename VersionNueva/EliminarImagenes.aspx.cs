using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;

namespace AtencionTemprana
{
    public partial class EliminarImagenes : System.Web.UI.Page
    {

        Data PGJ = new Data();
        DataSet ds = new DataSet();
        DataTable dtArbol = new DataTable();
        int Id = 18;
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.pdf";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                IdUsuario.Text = Session["IdUsuario"].ToString();
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                IdOrden.Text = Session["ID_ORDEN"].ToString();

                Session["op"] = Request.QueryString["op"];
                Session["ID_FOTO"] = Request.QueryString["ID_FOTO"];

                if (Session["op"] == null)
                {
                    Session["op"] = "0";
                }


                if (Session["op"].ToString() == "Foto")
                {
                    CargarFoto(Session["ID_FOTO"].ToString());
                }


            }
        }

        protected void IBOrden_Click(object sender, ImageClickEventArgs e)
        {


            Response.Redirect("CargarFotografiasPI.aspx");
        }

        public void IBImage_Command(object sender, CommandEventArgs e)
        {

            PGJ.EliminarFotografiaPI(Convert.ToInt32(e.CommandArgument.ToString()));

            //INSERTAMOS LA BITACORA DEL SISTEMA
            PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Se elimino una Imagen de la Carpeta" + IdCarpeta.Text);

            //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
            PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

            //Colocar Alerta 
            string script = @"<script type='text/javascript'>
                            alert('IMAGEN ELIMINADA.');
                                   </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvImagenes.DataSourceID = "dsCargarImagenes";
            gvImagenes.DataBind();

            
 
            
            
        }

        private void CargarFoto(string ID_PDF)
        {
            byte[] bits;
            try
            {


                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SELECT * from PGJ_FOTO_ORDEN_PI  WHERE ID_FOTO_ORDEN_PI = " + ID_PDF, Data.CnnCentral);
                comm.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet("Binarios");
                da.Fill(ds);
                //Creamos un array de bytes que contiene los bytes almacenados
                //en el campo Documento de la tabla
                bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
                //Vamos a guardar ese array de bytes como un fichero en el
                //disco duro, un fichero temporal que después se podrá descartar.
                string sFile = "tmpImage.jpg";
                //Creamos un nuevo FileStream, que esta vez servirá para
                //crear un fichero con el nombre especificado
                fs = new FileStream(Server.MapPath(".") +
                @"\DocTmp\" + sFile, FileMode.Create);
                //Y escribimos en disco el array de bytes que conforman
                //el fichero Word 
                fs.Write(bits, 0, Convert.ToInt32(bits.Length));
                fs.Close();
                //Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
                //tecleo mi dominio o IP
                //String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
                //ruta_pdf = ruta_pdf.Replace("\\", "/");

                string script = "<script languaje='javascript'> ";
                script += "mostrarFichero('DocTmp/tmpImage.jpg') ";
                script += "</script>" + Environment.NewLine;
                Page.RegisterStartupScript("mostrarFichero", script);
            }
            catch (Exception ex)
            {
                //Mensajes mje = new Mensajes();
                //mje.alert(ex.Message);
                string script = @"<script type='text/javascript'>
                            alert('NO EXISTE DOCUMENTO');
                                   </script>";
                //script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }
        }

    }
}