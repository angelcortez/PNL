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
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Office.Interop.Word;
//using WordToPDF; 


namespace AtencionTemprana
{
    public partial class GenerarDocs : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.pdf";

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
            }
        }

        protected void txtPlantilla_TextChanged(object sender, EventArgs e)
        {
            gvDocs.DataBind();
        }

        //protected void ibtnDescargar_Click(object sender, ImageClickEventArgs e)
        //{
        //    Data.IdCarpeta = 1;
        //    Data.IdPersona = 1;
        //    LeerDeBD();
        //}

        protected void gvDocs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            foreach (object row in gvDocs.Rows)
            {
                Session["ID_PLANTILLA"] = e.CommandArgument;
                Archivos.IdPlantilla = int.Parse(Session["ID_PLANTILLA"].ToString());
                Data.IdCarpeta = 1;
                //Data.IdPersona = 1;
              
            }
            LeerDeBD();
           
        }

        //public void guardarDocumento() {
        //    fs = new FileStream("C:\\DocumentosGenerados\\tmp.doc",System.IO.FileMode.Open);
        //    Byte[] data = new byte[fs.Length];
        //    fs.Read(data,0,Convert.ToInt32(fs.Length));
        //    PGJ.ConnectServer();
        //    SqlCommand cmd = new SqlCommand("guardarDocumentos",Data.CnnCentral);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@idCarpeta",Data.IdCarpeta);
        //    cmd.Parameters.AddWithValue("@idPlantilla",Data.IdPlantilla);
        //    cmd.Parameters.AddWithValue("@documento",data);
        //    cmd.Parameters.AddWithValue("@idUsuarioEmision",Data.IdUsuario );
        //    cmd.ExecuteNonQuery();
        //    fs.Close();
        //}

        public void LeerDeBD()
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * FROM CAT_PLANTILLAS " + " WHERE ID_PLANTILLA = " + Archivos.IdPlantilla, Data.CnnCentral);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            //Creamos un array de bytes que contiene los bytes almacenados
            //en el campo Documento de la tabla
            byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
            //Vamos a guardar ese array de bytes como un fichero en el
            //disco duro, un fichero temporal que después se podrá descartar.
            string sFile = "tmp.doc";
            //Creamos un nuevo FileStream, que esta vez servirá para
            //crear un fichero con el nombre especificado
            fs = new FileStream(Server.MapPath(".") +
            @"\DocTmp\" + sFile, FileMode.Create);
            //Y escribimos en disco el array de bytes que conforman
            //el fichero Word 
            fs.Write(bits, 0, Convert.ToInt32(bits.Length));
            if (File.Exists((string)fs.Name))
            {
                object readOnly = true;
                object isVisible = true;
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = true;
                Documento = wordApp.Documents.Open(fs.Name, ref missing,
                ref readOnly, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref isVisible, ref missing, ref missing,
                ref missing, ref missing);
                fs.Close();
                Documento.Activate();
                //object saveChanges = true;
                //object FormatOriginal = true;
                traerMarcadoresProcedimientos(Archivos.IdPlantilla);
                Documento = wordApp.Documents["tmp.doc"] as Word.Document;
                Documento.Close(Word.WdSaveOptions.wdSaveChanges);
                //wordApp.Documents.Close();
                wordApp.Application.Quit();

                string script = "<script languaje='javascript'> ";
                script += "mostrarFichero('DocTmp/tmp.doc') ";
                script += "</script>" + Environment.NewLine;
                Page.RegisterStartupScript("mostrarFichero", script);
            }
          //  LeerPDF();

        }

        //public void LeerPDF()
        //{
        //    Word2Pdf objWorPdf = new Word2Pdf();
        //    string backfolder1 = "D:\\DocTmp\\";
        //    string strFileName = "tmp.docx";
        //    object FromLocation = backfolder1 + "\\" + strFileName;
        //    string FileExtension = Path.GetExtension(strFileName);
        //    string ChangeExtension = strFileName.Replace(FileExtension, ".pdf");
        //    if (FileExtension == ".doc" || FileExtension == ".docx")
        //    {
        //        object ToLocation = backfolder1 + "\\" + ChangeExtension;
        //        objWorPdf.InputLocation = FromLocation;
        //        objWorPdf.OutputLocation = ToLocation;
        //        objWorPdf.Word2PdfCOnversion();
        //    }
        //}

        public void LeerPDF()
        {

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            wordApp.Visible = false;

            // file from
            object filename = Server.MapPath("DocTmp/tmp.doc"); // input

            // file to
            object newFileName = Server.MapPath("DocTmp/tmp.pdf"); // output
            object missing = System.Type.Missing;

            // open document
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing);

            // formt to save the file, this case PDF
            object formatoArquivo = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;

            // save file
            doc.SaveAs(ref newFileName, ref formatoArquivo, ref missing, ref missing, ref missing, ref missing, ref missing,
                           ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            doc.Close(ref missing, ref missing, ref missing);

            wordApp.Quit(ref missing, ref missing, ref missing);

            string script = "<script languaje='javascript'> ";
            script += "mostrarFichero('DocTmp/tmp.pdf') ";
            script += "</script>" + Environment.NewLine;
            Page.RegisterStartupScript("mostrarFichero", script);
  

        }

        public void traerMarcadoresProcedimientos(int IDPLANTILLA) {
            SqlDataAdapter daPlantilla = new SqlDataAdapter("consultaCAT_PLANTILLAS_MARCADORES " + Convert.ToString(IDPLANTILLA), Data.CnnCentral);
            DataSet dsPlantilla = new DataSet();
            daPlantilla.Fill(dsPlantilla,"PLANTILLAS");
            foreach (DataRow drPlantilla in dsPlantilla.Tables["PLANTILLAS"].Rows) {
                object oBookMark = drPlantilla["ID_MARCADOR"].ToString();
                traerInformacionMarcador(drPlantilla["ID_PROCEDIMIENTO"].ToString());
                Documento.Bookmarks.get_Item(ref oBookMark).Range.Text = textoMarcador;
                //object marcador = "M_DENUNCIANTE";
                //Documento.Bookmarks.get_Item("M_DENUNCIANTE").Range.Text = txtDenunciante.Text;
            }
            dsPlantilla.Dispose();
            daPlantilla.Dispose();
        }

        public void traerInformacionMarcador(string idProcedimiento)
        {
            //string cad = idProcedimiento;
            textoMarcador = "VACIO";
            SqlDataAdapter daParametros = new SqlDataAdapter("PARAMETROS_SP '"+idProcedimiento+"'",Data.CnnCentral);
            DataSet dsParametros = new DataSet();
            daParametros.Fill(dsParametros, "Parametros");
            SqlCommand cmd = new SqlCommand(idProcedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;
            //if (dsParametros.Tables["Parametros"].Rows.Count != null )
            //{
                foreach (DataRow drParametros in dsParametros.Tables["Parametros"].Rows)
                {
                    if (drParametros["Parametro"].ToString() != "NULO")
                    {
                        if (drParametros["Parametro"].ToString() == "@IdCarpeta")
                        {
                            cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                            cmd.Parameters[drParametros["Parametro"].ToString()].Value = Data.IdCarpeta ;
                        }
                        if (drParametros["Parametro"].ToString() == "@IdPersona")
                        {
                            //cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                            //cmd.Parameters[drParametros["Parametro"].ToString()].Value = Data.IdPersona;
                        }
                        if (drParametros["Parametro"].ToString() == "@IdMunicipio")
                        {
                            cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                            cmd.Parameters[drParametros["Parametro"].ToString()].Value = Data.IdMunicipio ;
                        }
                        if (drParametros["Parametro"].ToString() == "@Fecha")
                        {
                            cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.DateTime);
                            cmd.Parameters[drParametros["Parametro"].ToString()].Value = Convert.ToDateTime(lblFecha.Text);
                        }
                    }
                //}
            }
            dsParametros.Dispose();
            daParametros.Dispose();
            SqlDataReader drTextoMarcador = cmd.ExecuteReader();
            if (drTextoMarcador.HasRows) {
                drTextoMarcador.Read();
                textoMarcador = drTextoMarcador["Marcador"].ToString();
            }
            cmd.Dispose();
            drTextoMarcador.Close();
            drTextoMarcador.Dispose();
        }

        public void cerrarWord() {
            foreach (Process p in System.Diagnostics.Process.GetProcessesByName("winword"))
            {
                try
                {
                    p.Kill();
                    p.WaitForExit(); // possibly with a timeout
                }
                catch (Win32Exception winException)
                {
                    // process was terminating or can't be terminated - deal with it
                }
                catch (InvalidOperationException invalidException)
                {
                    // process has already exited - might be able to let this one go
                }
            }
        }
        protected void txtBuscar_Click(object sender, EventArgs e)
        {
            gvDocs.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //guardarDocumento();
        }
    }
}