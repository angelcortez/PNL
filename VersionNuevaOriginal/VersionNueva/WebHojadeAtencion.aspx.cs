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
using System.IO;
using System.Text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;

using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace AtencionTemprana
{
    public partial class WebHojadeAtencion : System.Web.UI.Page
    {
        
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                lblArbol.Text = Session["lblArbol"].ToString();

                CargarDatosHoja("NUC", LblNUC);

                LblUnidad.Text = Session["UNDD_DSCRPCION"].ToString();

                CargarDatosHoja("Municipio", LblMunicipio);

                CargarDatosHoja("FechaNuc", LblFechaInicio);

                CargarDatosHoja("Persona 1, ", LblDenunciante);

                CargarDatosHoja("Persona 2, ", LblOfendido);

                CargarDatosHoja("Persona 3, ", LblImputado);

                CargarDatosHoja("Delito", LblDelito);

                LblUsuario.Text = Session["Us"].ToString() + "(" + Session["PUESTO"].ToString() + ")";

                CargarDatosHoja("Titular", LblTitular);

                if (lblArbol.Text == "4")
                {
                    LblExpediente.Text = "NUC:";
                    CargarDatosHoja("NUC", LblNUC);

                    CargarDatosHoja("FechaNuc", LblFechaInicio);
                }
                else if (lblArbol.Text == "2")
                {
                    LblExpediente.Text = "RAC:";
                    CargarDatosHoja("RAC", LblNUC);

                    CargarDatosHoja("FechaRAC", LblFechaInicio);
                }

                QRCodeEncoder encoder = new QRCodeEncoder();

                //Bitmap img = encoder.Encode(LblNUC.Text);
                Bitmap img = encoder.Encode("1343PGJTAM1766" + Session["ID_CARPETA"].ToString() + "M" + Session["IdMunicipio"].ToString());

                //img.Save("C:\\NSJP (Ultima version) (CODIGO QR)\\NSJP\\img.jpg", ImageFormat.Jpeg);
                //img.Save(Path.GetFullPath("\\NSJP\\img.jpg"), ImageFormat.Jpeg); 
                img.Save(Server.MapPath("") + "\\img.jpg",ImageFormat.Jpeg);

                QRImage.ImageUrl = "img.jpg";


            }
        }
        
        protected void CargarDatosHoja(string Carpeta, Label Etiqueta)
        {
            SqlDataAdapter daHoja = new SqlDataAdapter("DatosHoja" + Carpeta + " " + Session["ID_CARPETA"].ToString(), Data.CnnCentral);
            DataSet dsHoja = new DataSet();
            daHoja.Fill(dsHoja, "Hoja");
            foreach (DataRow drHoja in dsHoja.Tables["Hoja"].Rows)
            {
                Etiqueta.Text=drHoja["Dato"].ToString() + (Char)13;
            }
            daHoja.Dispose();
            dsHoja.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));

            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString());
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
            }

            //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
        }

       

    }
}