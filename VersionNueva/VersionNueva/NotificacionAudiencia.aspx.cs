using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AtencionTemprana
{
    public partial class NotificacionAudiencia : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs, fs1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();

                

                if (Request.QueryString["idNotificacionPDF"] != "")
                {
                    IdNotificacion.Text = Request.QueryString["idNotificacionPDF"];

                    if (IdNotificacion.Text == "")
                    {
                        
                    }
                    else 
                    {
                        CargarDocumento(IdNotificacion.Text, IdMunicipio.Text);
                    }

                }


               
            }
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


        private void CargarDocumento(string IdNotificacion, string IdMunicipio)
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * FROM TORRE.NSJP.STJ.NotificacionPDF WHERE idNotificacionPDF  = " + IdNotificacion + " and IdMunicipio = " + IdMunicipio  , Data.CnnCentral);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            //Creamos un array de bytes que contiene los bytes almacenados
            //en el campo Documento de la tabla
            byte[] bits;// = ((byte[])(ds.Tables[0].Rows[0].ItemArray[2]));

            if (ds.Tables[0].Rows[0].ItemArray[4].ToString() == "")
            { 
                bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[2]));
                lblAcuse.Visible = true;
                lblSelecciona.Visible = true;
                FileUpload1.Visible = true;
                cmdGuardar.Visible = true;
            }
            else
            {
                bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[4]));
                lblAcuse.Visible = false;
                lblSelecciona.Visible = false;
                FileUpload1.Visible = false;
                cmdGuardar.Visible = false;
            }
           

          
            //Vamos a guardar ese array de bytes como un fichero en el
            //disco duro, un fichero temporal que después se podrá descartar.
            string sFile = "tmp.pdf";
            //Creamos un nuevo FileStream, que esta vez servirá para
            //crear un fichero con el nombre especificado
            fs = new FileStream(Server.MapPath(".") +
            @"\DocTmp\" + sFile, FileMode.Create);
            //Y escribimos en disco el array de bytes que conforman
            //el fichero Word 
            fs.Write(bits, 0, Convert.ToInt32(bits.Length));
            fs.Close();
            //Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
            ///*tecleo mi dominio o IP*/
            //String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
            //ruta_pdf = ruta_pdf.Replace("\\", "/");
            string script = "<script languaje='javascript'> ";
            script += "mostrarFichero('DocTmp/tmp.pdf') ";
            script += "</script>" + Environment.NewLine;
            Page.RegisterStartupScript("mostrarFichero", script);

        }

        protected void gvNuc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == Request.QueryString["idNotificacionPDF"])
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Archivos.InsertarNotifiacionPersonalizadaAcuse(int.Parse(IdNotificacion.Text), int.Parse(IdMunicipio.Text), Pdf);
                }
            }

            cmdGuardar.Enabled = false;
            lblError.Text = "DOCUMENTO GUARDADO";
        }

      

    

    }
}