using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using iTextSharp.text.pdf;
using System.Linq;

namespace AtencionTemprana
{
    public partial class CarpetaPDF : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["ID_ESTADO_NUC"] == null)
                {
                    Session["ID_ESTADO_NUC"] = "";
                }
                if (Session["ID_ESTADO_RAC"] == null)
                {
                    Session["ID_ESTADO_RAC"] = "";
                }
                if (Session["ID_ESTADO_NAC"] == null)
                {
                    Session["ID_ESTADO_NAC"] = "";
                }
                if (Session["ID_ESTADO_NUM"] == null)
                {
                    Session["ID_ESTADO_NUM"] = "";
                }

                Session["ID_ESTADO_RAC"].ToString();
                Session["ID_ESTADO_NUC"].ToString();
                Session["ID_ESTADO_NAC"].ToString();
                Session["ID_ESTADO_NUM"].ToString();

                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                lblArbol.Text = Session["lblArbol"].ToString();

              //  ID_PLANTILLA.Text = Session["ID_PLANTILLA"].ToString();

                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR CARPETA PDF";
                    //consultaIdLugarHechos();
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();

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


        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                   // Archivos.InsertaCarpetaPDF(int.Parse(IdCarpeta.Text), Pdf, short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()) );
                }
            }

            lblEstatus.Text = "DATOS GUARDADOS";
            cmdGuardar.Enabled = false;

        }

        protected void cmdReg_Click1(object sender, EventArgs e)
        {
            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() );
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() );
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() );
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() );
            }
        }

        protected void cmdGeneraPdf_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formulario.pdf");
            FillPDF(Server.MapPath("OFICIO_PARA_SOLICITAR_PERITO QUMICO.pdf"), Response.OutputStream);
        }

        public void FillPDF(string template, Stream stream)
        {
            PdfReader reader = new PdfReader(template);
            PdfStamper stamp = new PdfStamper(reader, stream);
            stamp.AcroFields.SetField("TxtDelito", "DAÑO EN PROPIEDAD");
            stamp.AcroFields.SetField("TxtLugar", "ZONA CENTRO CALLE19");
            stamp.AcroFields.SetField("TxtCiudadano", "JOSE CARLOS HERNANDEZ");
            stamp.AcroFields.SetField("TxtAgente", "JUAN PEREZ LEON");
            stamp.AcroFields.SetField("TxtNoEmpleado", "12345");
            stamp.AcroFields.SetField("TxtAdscripcion", "UNIDAD 1");
            stamp.AcroFields.SetField("TxtDia", "28");
            stamp.AcroFields.SetField("TxtMes", "NOVIEMBRE");
            stamp.FormFlattening = true;
            stamp.Close();
        }
    }
}