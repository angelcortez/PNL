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
using System.Reflection;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Word;

using System.IO;

namespace AtencionTemprana
{
    public partial class Plantillas : System.Web.UI.Page
    {
        FileStream fs;
        private object filename;
        private Word.Document Documento;
        object missing = Missing.Value;
        Data PGJ = new Data();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PGJ.ConnectServer();
                SqlCommand cmd = new SqlCommand("SELECT  GETDATE()  as FechaActual", Data.CnnCentral);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    lblFecha.Text = rd["FechaActual"].ToString();
                    rd.Close();
                }
                
                LBLUSUARIO.Text = Session["Us"].ToString();
                PGJ.CargaCombo(ddlTipoPlantilla, "CAT_TIPO_PLANTILLA", "ID_TIPO_PLANTILLA", "TIPO_PLANTILLA");
            }
        }
        protected void GuardarFicheroBDD()
        {
            try
            {
                //fs = new FileStream("C:\\FINAL\\" + FileUpload1.FileName, System.IO.FileMode.Open);
                //Byte[] data = new byte[fs.Length];
                //fs.Read(data, 0, Convert.ToInt32(fs.Length));
                //PGJ.InsertaPlantilla(short.Parse(ddlTipoPlantilla.SelectedValue), FileUpload1.FileName, data, short.Parse((chbRAC.Checked == true ? "1" : "0")), short.Parse((chbNUM.Checked == true ? "1" : "0")), short.Parse((chbNUC.Checked == true ? "1" : "0")), short.Parse((chbComparecencia.Checked == true ? "1" : "0")), short.Parse((chbEscrito.Checked == true ? "1" : "0")), short.Parse((chbRazon.Checked == true ? "1" : "0")), short.Parse((chbConDetenido.Checked == true ? "1" : "0")), short.Parse(chbSinDetenido.Checked == true ? "1" : "0"));
                //Session["ID_PLANTILLA"] = Data.IdPlantilla;
                //fs.Close();
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] imagen = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Archivos.InsertaPlantilla(short.Parse(ddlTipoPlantilla.SelectedValue), FileUpload1.FileName, imagen, short.Parse((chbRAC.Checked == true ? "1" : "0")), short.Parse((chbNUM.Checked == true ? "1" : "0")), short.Parse((chbNUC.Checked == true ? "1" : "0")), short.Parse((chbComparecencia.Checked == true ? "1" : "0")), short.Parse((chbEscrito.Checked == true ? "1" : "0")), short.Parse((chbRazon.Checked == true ? "1" : "0")), short.Parse((chbConDetenido.Checked == true ? "1" : "0")), short.Parse(chbSinDetenido.Checked == true ? "1" : "0"));
                   
                }
            }catch(Exception e){
            }
        }

        protected void LeerDeBD()
        {
            try
            {
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SELECT * FROM CAT_PLANTILLAS " + " WHERE ID_PLANTILLA = " + Archivos.IdPlantilla, Data.CnnCentral);
                comm.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet("Binarios");
                da.Fill(ds);
                byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
                string sFile = "tmp.doc";
                fs = new FileStream(Server.MapPath(".") +
                @"\DocTmp\" + sFile, FileMode.Create);
                fs.Write(bits, 0, Convert.ToInt32(bits.Length));
                if (File.Exists((string)fs.Name))
                {
                    object readOnly = true;
                    object isVisible = true;
                    Word.Application wordApp = new Word.Application();
                    wordApp.Visible = false;
                    Documento = wordApp.Documents.Open(fs.Name, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);
                    Documento.Activate();
                    object saveChanges = false;
                    object FormatOriginal = false;
                    for (int i = 1; i <= Documento.Bookmarks.Count; i++)
                    {
                        string nameMarcador = Documento.Bookmarks[i].Name;
                        PGJ.InsertaPlantillasMarcadores( Archivos.IdPlantilla, nameMarcador, "MarcadorLLenar");
                    }
                    wordApp.Documents.Close();
                    wordApp.Application.Quit();
                }
                fs.Close();
            }
            catch (Exception e)
            {
                Literal1.Text = "Nombrde la Plantilla NO EXISTE";
            }
        }

        protected void btnAgregarProcedimiento_Click(object sender, EventArgs e)
        {
            PGJ.ModificaPlantillasMarcadores(Archivos.IdPlantilla,Label3.Text , ListBox1.SelectedItem.ToString());
            gvPlantillas.DataSourceID = "dsMarcadores";
            gvPlantillas.DataBind();
        }

        protected void gvPlantillas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            foreach (object row in gvPlantillas.Rows)
            {
                Session["ID_MARCADOR"] = e.CommandArgument;
                Label3.Text = Session["ID_MARCADOR"].ToString();
            }
        }

        protected void ibtnProcedimiento_Click(object sender, ImageClickEventArgs e)
        {
            Panel1_ModalPopupExtender.Show();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarFicheroBDD();
            LeerDeBD();
            Session["ID_PLANTILLA"] = Archivos.IdPlantilla;
            Literal1.Text = FileUpload1.FileName+" SE HA GUARDADO CORRECTAMENTE";
            gvPlantillas.DataBind();
            Panel2.Visible = false;
            Panel3.Visible = true;
            limpiarControles();
            btnNuevaPlantilla.Visible = true;
            
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text = ListBox1.SelectedValue;
            Panel1_ModalPopupExtender.Show();
        }
        protected void limpiarControles() {
            chbComparecencia.Checked = false;
            chbConDetenido.Checked = false;
            chbEscrito.Checked = false;
            chbNUC.Checked = false;
            chbNUM.Checked = false;
            chbRAC.Checked = false;
            chbRazon.Checked = false;
            chbSinDetenido.Checked = false;
        }
        protected void btnNuevaPlantilla_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            Literal1.Text = "";
            btnNuevaPlantilla.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenerarDocs.aspx");
        }
       
     
    }
}
