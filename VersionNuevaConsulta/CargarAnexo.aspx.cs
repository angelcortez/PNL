using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;


namespace AtencionTemprana
{
    public partial class CargarAnexo : System.Web.UI.Page
    {


        Data PGJ = new Data();
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.docx";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblIdUsuario.Text = Session["IdUsuario"].ToString();
            IdMunicipio.Text = Session["IdMunicipio"].ToString();
            IdUnidad.Text = Session["IdUnidad"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            IdCarpeta.Text = Session["ID_CARPETA"].ToString();
            IdOrden.Text = Session["ID_ORDEN"].ToString();

            Session["ID_DOCUMENTO"] = Request.QueryString["ID_DOCUMENTO"];

        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            //Subir Archivo
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    PGJ.InsertarAnexosPI(int.Parse(IdCarpeta.Text), int.Parse(Session["ID_DOCUMENTO"].ToString()) ,Pdf );
                }

                //INSERTAMOS LA BITACORA DEL SISTEMA
                PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "El documento del Anexo fue guardado");

                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                            alert('EL ANEXO HA SIDO GUARADO CORRECTAMENTE.');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                Label3.Text = " *SELECCIONE UN ARCHIVO PDF";
            }
        }

        protected void IBOrden_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrdenPoliciaInvestigador.aspx");
        }




    }
}