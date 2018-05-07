using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;

namespace AtencionTemprana
{
    public partial class DocMediacion : System.Web.UI.Page
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
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["ID_PDF"] = Request.QueryString["ID_PDF"];
                lblArbol.Text = Session["lblArbol"].ToString();
                //  PGJ.CargaCombo(ddlPlantilla, "CAT_PLANTILLAS", "ID_PLANTILLA", "NOMBRE_PLANTILLA");

                PGJ.CargaComboFiltrado(ddlFacilitador, "CAT_AGENTES_MP", "ID_AGENTE", "NOMBRE", "ID_TIPO_UNIDAD=3 and ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());
                PGJ.CargaComboFiltrado(ddlMpPenal, "CAT_AGENTES_MP", "ID_AGENTE", "NOMBRE", "(ID_TIPO_UNIDAD=1  or ID_TIPO_UNIDAD=2) and ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());
                cargarFecha();
                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR DOCUMENTO PDF";
                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                    try
                    {
                        PGJ.CargaComboNUM(ddlPlantilla);
                        cargarImputado();
                        cargarOfendido();
                        cargarDenunciante();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("DocMediacion.aspx?&op=Agregar");
                    }

                    //cargaTestigo();
                    //cargaDefensor();

                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DOCUMENTO PDF";
                    try
                    {
                        PGJ.CargaComboNUM(ddlPlantilla);
                        cargarPDF();
                        CargarDocumento(IdPdf.Text);
                        cargarImputado();
                        cargarOfendido();
                        cargarDenunciante();
                        ddlPlantilla.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("DocMediacion.aspx?ID_PDF=" + Session["ID_PDF"].ToString() + "&op=Modificar");

                    }

                    //cargaTestigo();
                    //cargaDefensor();
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

        void cargarImputado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorImputado(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.IMPUTADO };
            ddlImputado.DataSource = im;
            ddlImputado.DataValueField = "ID_PERSONA";
            ddlImputado.DataTextField = "IMPUTADO";
            ddlImputado.DataBind();
        }
        void cargarOfendido()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorOfendido(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.OFENDIDO };
            ddlOfendido.DataSource = im;
            ddlOfendido.DataValueField = "ID_PERSONA";
            ddlOfendido.DataTextField = "OFENDIDO";
            ddlOfendido.DataBind();
        }
        void cargarDenunciante()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorDenunciante(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.DENUNCIANTE };
            ddlDenunciante.DataSource = im;
            ddlDenunciante.DataValueField = "ID_PERSONA";
            ddlDenunciante.DataTextField = "DENUNCIANTE";
            ddlDenunciante.DataBind();
        }
        //void cargaTestigo()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var im = from c in dc.MarcadorTestigo(int.Parse(ID_CARPETA.Text))
        //             select new { c.ID_PERSONA, c.TESTIGO };
        //    ddlTestigo.DataSource = im;
        //    ddlTestigo.DataValueField = "ID_PERSONA";
        //    ddlTestigo.DataTextField = "TESTIGO";
        //    ddlTestigo.DataBind();
        //}
        //void cargaDefensor()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var im = from c in dc.MarcadorDefensor(int.Parse(ID_CARPETA.Text))
        //             select new { c.ID_DEFENSOR, c.DEFENSOR };
        //    ddlDefensor.DataSource = im;
        //    ddlDefensor.DataValueField = "ID_DEFENSOR";
        //    ddlDefensor.DataTextField = "DEFENSOR";
        //    ddlDefensor.DataBind();
        //}

        private void CargarDocumento(string id_pdf)
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * from PGJ_PDF_MEDIACION  WHERE ID_PDF = " + id_pdf, Data.CnnCentral);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            //Creamos un array de bytes que contiene los bytes almacenados
            //en el campo Documento de la tabla
            byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[2]));
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

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPlantilla.SelectedValue == "0")
                {
                    lblEstatus.Text = "SELECCIONA EL TIPO DE DOCUMENTO";
                }
                else
                {
                    if (Session["op"].ToString() == "Agregar")
                    {
                        if (ddlPlantilla.SelectedValue == "33")
                        {
                            if (FileUpload1.HasFile)
                            {
                                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                                {
                                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                                    Archivos.InsertaPdfMediacion(int.Parse(ID_CARPETA.Text), Pdf, short.Parse(ddlPlantilla.SelectedValue.ToString()), int.Parse(ddlDenunciante.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ddlImputado.SelectedValue.ToString()), txtOtroFormato.Text, short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUsuario"].ToString()));
                                }
                            }
                        }
                        if (FileUpload1.HasFile)
                        {
                            using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                            {
                                byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                                Archivos.InsertaPdfMediacion(int.Parse(ID_CARPETA.Text), Pdf, short.Parse(ddlPlantilla.SelectedValue.ToString()), int.Parse(ddlDenunciante.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ddlImputado.SelectedValue.ToString()), ddlPlantilla.SelectedItem.Text, short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUsuario"].ToString()));
                            }
                        }

                    }
                    else if (Session["op"].ToString() == "Modificar")
                    {
                        if (FileUpload1.HasFile)
                        {
                            using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                            {
                                byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                                Archivos.ActualizaPdfMediacion(Pdf, int.Parse(IdPdf.Text));
                            }
                        }

                    }
                    lblEstatus.Text = "DATOS GUARDADOS";
                    cmdGuardar.Enabled = false;
                    FileUpload1.Enabled = false;
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
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }

        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            try
            {

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
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

        void cargarPDF()
        {
            SqlCommand sql = new SqlCommand("cargaPdfMediacion " + int.Parse(Session["ID_PDF"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                IdPdf.Text = dr["ID_PDF"].ToString();
                ID_CARPETA.Text = dr["ID_CARPETA"].ToString();
                ddlPlantilla.SelectedValue = dr["ID_PLANTILLA"].ToString();
                ddlDenunciante.SelectedValue = dr["ID_DENCINCIANTE"].ToString();
                ddlOfendido.SelectedValue = dr["ID_OFENDIDO"].ToString();
                ddlImputado.SelectedValue = dr["ID_IMPUTADO"].ToString();
            }
            dr.Close();
        }

        protected void cmdGeneraPdf_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ID_PLANTILLA"] = ddlPlantilla.SelectedValue;
                Archivos.IdPlantilla = int.Parse(Session["ID_PLANTILLA"].ToString());
                LeerDeBD();
                if (ddlPlantilla.SelectedValue == "33")
                {
                    cmdGeneraPdf.Visible = false;
                    Panel38.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
                cerrarWord();
            }
        }
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
                //traermarcadoresText(Archivos.IdPlantilla);
                Documento = wordApp.Documents["tmp.doc"] as Word.Document;
                Documento.Close(Word.WdSaveOptions.wdSaveChanges);
                //wordApp.Documents.Close();
                wordApp.Application.Quit();

                string script = "<script languaje='javascript'> ";
                script += "mostrarFichero('DocTmp/tmp.doc') ";
                script += "</script>" + Environment.NewLine;
                Page.RegisterStartupScript("mostrarFichero", script);
            }
            //LeerPDF();
        }

        public void traerMarcadoresProcedimientos(int IDPLANTILLA)
        {
            SqlDataAdapter daPlantilla = new SqlDataAdapter("consultaCAT_PLANTILLAS_MARCADORES " + Convert.ToString(IDPLANTILLA), Data.CnnCentral);
            DataSet dsPlantilla = new DataSet();
            daPlantilla.Fill(dsPlantilla, "PLANTILLAS");
            foreach (DataRow drPlantilla in dsPlantilla.Tables["PLANTILLAS"].Rows)
            {
                object oBookMark = drPlantilla["ID_MARCADOR"].ToString();
                traerInformacionMarcador(drPlantilla["ID_PROCEDIMIENTO"].ToString());
                Documento.Bookmarks.get_Item(ref oBookMark).Range.Text = textoMarcador;

            }
            dsPlantilla.Dispose();
            daPlantilla.Dispose();
        }

        public void traerInformacionMarcador(string idProcedimiento)
        {
            //string cad = idProcedimiento;
            textoMarcador = "VACIO";
            SqlDataAdapter daParametros = new SqlDataAdapter("PARAMETROS_SP '" + idProcedimiento + "'", Data.CnnCentral);
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
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ID_CARPETA.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdDenunciante")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlDenunciante.SelectedValue;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdOfendido")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlOfendido.SelectedValue;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdImputado")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlImputado.SelectedValue;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdFacilitador")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlFacilitador.SelectedValue;
                    }
                    //if (drParametros["Parametro"].ToString() == "@IdAgente")
                    //{
                    //    cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                    //    cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlMpOrientador.SelectedValue;
                    //}
                    if (drParametros["Parametro"].ToString() == "@IdAgentemMP")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlMpPenal.SelectedValue;
                    }
                    //if (drParametros["Parametro"].ToString() == "@IdTestigo")
                    //{
                    //    cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                    //    cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlTestigo.SelectedValue;
                    //}
                    //if (drParametros["Parametro"].ToString() == "@IdDefensor")
                    //{
                    //    cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                    //    cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlDefensor.SelectedValue;
                    //}
                    if (drParametros["Parametro"].ToString() == "@IdUsuario")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = Session["IdUsuario"].ToString();
                    }
                    if (drParametros["Parametro"].ToString() == "@IdMunicipio")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = Session["IdMunicipio"];
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
            if (drTextoMarcador.HasRows)
            {
                drTextoMarcador.Read();
                textoMarcador = drTextoMarcador["Marcador"].ToString();
            }
            cmd.Dispose();
            drTextoMarcador.Close();
            drTextoMarcador.Dispose();
        }

        public void cerrarWord()
        {
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

        protected void ddlPlantilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPlantilla.SelectedValue == "0")
            {
                cmdGeneraPdf.Visible = false;
            }
            if (ddlPlantilla.SelectedValue == "33")
            {
                cmdGeneraPdf.Visible = false;
                Panel38.Visible = true;
            }
            cmdGeneraPdf.Visible = true;
        }
    }
}