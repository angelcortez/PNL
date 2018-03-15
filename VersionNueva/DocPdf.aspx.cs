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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.pdf";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["ID_PDF"] = Request.QueryString["ID_PDF"];
                lblArbol.Text = Session["lblArbol"].ToString();
                //  PGJ.CargaCombo(ddlPlantilla, "CAT_PLANTILLAS", "ID_PLANTILLA", "NOMBRE_PLANTILLA");
                //ocultarPanel();
                

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR DOCUMENTO PDF";
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    try{
                    PGJ.CargaComboNUC(ddlPlantilla);
                        cargarImputado();
                    cargarOfendido();
                    cargarDenunciante();
                    cargaTestigo();
                    cargaDefensor(); 
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("DocPdf.aspx?&op=Agregar");
                    }
                                      
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DOCUMENTO PDF";
                    try{
                    PGJ.CargaComboNUC(ddlPlantilla);
                    cargarCarpetaPDF();
                    ddlPlantilla.Enabled = false;
                    cargarImputado();
                    cargarOfendido();
                    cargarDenunciante();
                    cargaTestigo();
                    cargaDefensor();
                    //ddlPlanel();
                    CargarDocumento(IdPdf.Text);
                    cmdGeneraPdf.Visible = true;

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto PDF IdPdf=" + IdPdf.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("DocPdf.aspx?ID_PDF=" + Session["ID_PDF"].ToString() + "&op=Modificar");
                        // Datos.aspx?ID_PERSONA=' + CAST(CP.ID_PERSONA AS VARCHAR)  + '&op=Modificar'
                        //lblEstatus.Text = ex.Message;

                    }
                    
                }

                // MetodosCarga();
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
            var im = from c in dc.MarcadorImputado(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.IMPUTADO };
            ddlImputado.DataSource = im;
            ddlImputado.DataValueField = "ID_PERSONA";
            ddlImputado.DataTextField = "IMPUTADO";
            ddlImputado.DataBind();
        }
        void cargarOfendido()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorOfendido(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.OFENDIDO };
            ddlOfendido.DataSource = im;
            ddlOfendido.DataValueField = "ID_PERSONA";
            ddlOfendido.DataTextField = "OFENDIDO";
            ddlOfendido.DataBind();
        }
        void cargarDenunciante()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorDenunciante(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.DENUNCIANTE };
            ddlDenunciante.DataSource = im;
            ddlDenunciante.DataValueField = "ID_PERSONA";
            ddlDenunciante.DataTextField = "DENUNCIANTE";
            ddlDenunciante.DataBind();
        }
        void cargaTestigo()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorTestigo(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.TESTIGO };
            ddlTestigo.DataSource = im;
            ddlTestigo.DataValueField = "ID_PERSONA";
            ddlTestigo.DataTextField = "TESTIGO";
            ddlTestigo.DataBind();
        }
        void cargaDefensor()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorDefensor(int.Parse(IdCarpeta.Text))
                     select new { c.ID_DEFENSOR, c.DEFENSOR };
            ddlDefensor.DataSource = im;
            ddlDefensor.DataValueField = "ID_DEFENSOR";
            ddlDefensor.DataTextField = "DEFENSOR";
            ddlDefensor.DataBind();
        }

        private void CargarDocumento(string id_pdf)
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * from PGJ_CARPETA_PDF  WHERE id_pdf = " + id_pdf, Data.CnnCentral);
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


        #region Guardar
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


                        //Cuando se crea un nuevo Documento de Policia Investigador
                        //Se Inserta en la BD una nueva Orden
                        if (ddlPlantilla.SelectedValue == "31")
                        {
                          //  PGJ.OrdenContinuacion_MP_CoorPI(int.Parse(IdCarpeta.Text));
                        }


                        //Cuando se crea un nuevo Documento de Policia Investigador
                        //Se Inserta en la BD una nueva Orden
                        if (ddlPlantilla.SelectedValue == "32")
                        {
                            PGJ.AsignarOrden_MP_CoorPI(int.Parse(IdCarpeta.Text), 4);
                        }



                        if (ddlPlantilla.SelectedValue == "33")
                        {
                            if (FileUpload1.HasFile)
                            {
                                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                                {
                                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                                    Archivos.InsertaCarpetaPDF(int.Parse(IdCarpeta.Text), Pdf, txtOtroFormato.Text, short.Parse(ddlPlantilla.SelectedValue), int.Parse(ddlDenunciante.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ddlImputado.SelectedValue.ToString()), int.Parse(ddlTestigo.SelectedValue.ToString()), int.Parse(ddlDefensor.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));
                                }
                            }
                        }
                        if (FileUpload1.HasFile)
                        {
                            using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                            {
                                byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                                Archivos.InsertaCarpetaPDF(int.Parse(IdCarpeta.Text), Pdf, ddlPlantilla.SelectedItem.Text, short.Parse(ddlPlantilla.SelectedValue), int.Parse(ddlDenunciante.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ddlImputado.SelectedValue.ToString()), int.Parse(ddlTestigo.SelectedValue.ToString()), int.Parse(ddlDefensor.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));
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
                                Archivos.ActualizaCarpetaPDF(int.Parse(IdPdf.Text), Pdf, int.Parse(ddlDenunciante.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ddlImputado.SelectedValue.ToString()), int.Parse(ddlTestigo.SelectedValue.ToString()), int.Parse(ddlDefensor.SelectedValue.ToString()));

                            }
                        }
                    }
                    lblEstatus.Text = "DATOS GUARDADOS";
                    ddlPlantilla.Enabled = false;
                    cmdGeneraPdf.Enabled = false;
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

        #endregion

        void cargarCarpetaPDF()
        {
            SqlCommand sql = new SqlCommand("cargaCarpetaPDF " + int.Parse(Session["ID_PDF"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                IdPdf.Text = dr["ID_PDF"].ToString();
                IdCarpeta.Text = dr["ID_CARPETA"].ToString();
                ddlPlantilla.SelectedValue = dr["ID_PLANTILLA"].ToString();
                txtOtroFormato.Text = dr["DOCUMENTO"].ToString();
                ddlDenunciante.SelectedValue = dr["ID_DENCINCIANTE"].ToString();
                ddlOfendido.SelectedValue = dr["ID_OFENDIDO"].ToString();
                ddlImputado.SelectedValue = dr["ID_IMPUTADO"].ToString();
                ddlTestigo.SelectedValue = dr["ID_TESTIGO"].ToString();
                ddlDefensor.SelectedValue = dr["ID_DEFENSOR"].ToString();
            }
            dr.Close();
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            try
            {
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()),  Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            

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
            else if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

       

        #region ddlPlantilla
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
            cmdGeneraPdf.Visible = true ;
        }
        #endregion

        protected void cmdGeneraPdf_Click(object sender, EventArgs e)
        {
            try{
                Session["ID_PLANTILLA"] = ddlPlantilla.SelectedValue ;
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
            string sFile = "TMP" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".doc";
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
                Documento = wordApp.Documents[sFile] as Word.Document;
                Documento.Close(Word.WdSaveOptions.wdSaveChanges);
                //wordApp.Documents.Close();
                wordApp.Application.Quit();

                string script = "<script languaje='javascript'> ";
                script += "mostrarFichero('DocTmp/" + sFile + "') ";
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
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdCarpeta.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdDenunciante")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlDenunciante.SelectedValue;
                    }

                    if (drParametros["Parametro"].ToString() == "@ID_PERSONA")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlDenunciante.SelectedValue;
                    }

                    if (drParametros["Parametro"].ToString() == "@IdOfendido")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlOfendido.SelectedValue;
                    }

                    if (drParametros["Parametro"].ToString() == "@IdPersona")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlOfendido.SelectedValue;
                    }


                    if (drParametros["Parametro"].ToString() == "@IdImputado")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlImputado.SelectedValue;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdTestigo")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlTestigo.SelectedValue;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdDefensor")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = ddlDefensor.SelectedValue;
                    }
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

                    if (drParametros["Parametro"].ToString() == "@IdMunicipioCarpeta")
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
 //#region Procedimientos

        //void MarcadorPeritoQuimico()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito, "MarcadorDelito");
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido4, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad, "MarcadorUnidadInvestigadora");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCiudad3, "MarcadorMunicipioUnidad");
        //    Marcadores.MarcadorFechas(LblDia, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño10, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes, "MarcadorMesActual");
        //}

        //void MarcadorActaDenuncia()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC1, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad1, "MarcadorUnidadInvestigadora");
        //    Marcadores.MarcadorFechas(LblFechaOficio, "MarcadorFechaOficio");
        //    Marcadores.MarcadorFechas(LblHoraActual, "MarcadorHoraActual");
        //    //DENUNCIANTE
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), NombreDenunciante, "MarcadorDenuncianteNombre", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblDomicilioDenunciante, "MarcadorDomicilioDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOriginario, "MarcadorPaisOrigenDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOriginarioMunicipio, "MarcadorMumicipioOrigenDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOriginarioEstado, "MarcadorEstadoOrigenDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNacionalidad, "MarcadorNacionalidadDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOcupacion, "MarcadorOcupacionDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEsccolaridad, "MarcadorEscolaridadDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblSexo, "MarcadorSexoDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEstadoCivil, "MarcadorEdoCivilDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEdad, "MarcadorEdadDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFechaNacimiento, "MarcadorFechaNacDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelFijoDenunciante, "MarcadorTelParticularDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelMovilDenunciante, "MarcadorTelCelDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelNotificacionesDenunciante, "MarcadorTelNotificacionDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEmail, "MarcadorEmailDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFolioElector, "MarcadorIFE_Denunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblRFC, "MarcadorRFC_Denunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblLicenciaConducir, "MarcadorLicenciaManejoDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblPasaporte, "MarcadorPasaporteDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblCurp, "MarcadorCurpDenunciante", int.Parse(ddlDenunciante.SelectedValue));
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), lblNombreOfen, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblDomicilioOfendido, "MarcadorDomicilioOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOriginarioOfendido, "MarcadorPaisOrigenOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOriginarioMunicipioOfendido, "MarcadorMumicipioOrigenOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOriginarioEstadoOfendido, "MarcadorEstadoOrigenOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNacionalidadOfendido, "MarcadorNacionalidadOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOcupacionOfendido, "MarcadorOcupacionOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEsccolaridadOfendido, "MarcadorEscolaridadOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblSexoOfendido, "MarcadorSexoOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEstadoCivilOfendido, "MarcadorEdoCivilOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEdadOfendido, "MarcadorEdadOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFechaNacimientoOfendido, "MarcadorFechaNacOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelFijoOfendido, "MarcadorTelParticularOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelMovilOfendido, "MarcadorTelCelOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelNotificacionesOfendido, "MarcadorTelNotificacionOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEmailOfendido, "MarcadorEmailOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFolioElectorOfendido, "MarcadorIFE_Ofendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblRFCOfendido, "MarcadorRFC_Ofendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblLicenciaConducirOfendido, "MarcadorLicenciaManejoOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblPasaporteOfendido, "MarcadorPasaporteOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblCurpOfendido, "MarcadorCurpOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), lblNombreImputado, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), lblDomicilioImputado, "MarcadorDomicilioImputado", int.Parse(ddlImputado.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP1, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado1, "MarcadorNumeroEmpleadoMP");
        //    //DESCRIPCION HECHOS
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), lblNarracion, "MarcadorDescripcionHechos");
        //}

        //void cargarDatosEmpresa()
        //{
        //    SqlCommand sql = new SqlCommand("MarcadorEmpresa " + int.Parse(Session["ID_CARPETA"].ToString()), Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        dr.Read();
        //        lblDenominacion.Text = dr["NOMBRE"].ToString();
        //        lblRFCEmprresa.Text = dr["RFC"].ToString();
        //        lblDomicilioEmpresa.Text = dr["DOMICILIO"].ToString();
        //        lblEscritura.Text = dr["ESCRITURA_PRUBLICA"].ToString();
        //        lblNoEscritura.Text = dr["NO_ESCRITURA"].ToString();
        //        lblOtro.Text = dr["OTRO"].ToString();
        //        lblEspecificar.Text = dr["ESPECIFICAR"].ToString();
        //    }
        //    dr.Close();
        //}

        //void MacadorActaDerechosVictima()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC13, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad4, "MarcadorUnidadInvestigadora");
        //    Marcadores.MarcadorFechas(LblFechaOficio1, "MarcadorFechaOficio");
        //    Marcadores.MarcadorFechas(LblHoraActual1, "MarcadorHoraActual");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido1, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    //DEFENSOR
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblNombreDefensor1, "MarcadorDefensorNombre", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblIdentificacionDefensor1, "MarcadorIdentificacionDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblFolioDefensor1, "MarcadorFolioIdentificacionDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblDomicilioDefensor1, "MarcadorDomicilioDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblTelefonoDefensor1, "MarcadorTelDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP2, "MarcadorNombreMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCargoMP2, "MarcadorCargoMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado2, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCiudad5, "MarcadorMunicipioUnidad");
        //}

        //void MarcadorAcuerdoInicio()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC2, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad6, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito1, "MarcadorDelito");
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //DENUNCIANTE
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDenunciante1, "MarcadorDenuncianteNombre", int.Parse(ddlDenunciante.SelectedValue));
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP3, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado3, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCiudad4, "MarcadorMunicipioUnidad");
        //    Marcadores.MarcadorFechas(LblDia1, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño1, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes1, "MarcadorMesActual");
        //}

        //void MarcadorDeclaracionImputado()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC12, "MarcadorNUC");
        //    Marcadores.MarcadorFechas(LblFechaOficio4, "MarcadorFechaOficio");
        //    Marcadores.MarcadorFechas(LblHoraActual3, "MarcadorHoraActual");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito11, "MarcadorDelito");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblHoraDelito, "MarcadorHoraDelito");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblFechaLugarHechos1, "MarcadorFechaLugarHechos");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCiudad2, "MarcadorMunicipioUnidad");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblEntidad, "MarcadorEntidadUnidad");
        //    //DETENIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido3, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblIdentificacionDetenido, "MarcadorIdentificacionImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFolioIdentificacion, "MarcadorFolioIdentificacionImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblCiudadOrigenDetenido, "MarcadorMumicipioOrigenImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEstadoOrigenDetenido, "MarcadorEstadoOrigenImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEstadoCivil1, "MarcadorEdoCivilImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEdad1, "MarcadorEdadImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFechaNacimiento1, "MarcadorFechaNacImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblDomicilioDetenido, "MarcadorDomicilioImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelFijoDetenido, "MarcadorTelParticularImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelMovilDetenido, "MarcadorTelCelImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOcupacionDetenido, "MarcadorOcupacionImputado", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEmailDetenido, "MarcadorEmailDetenido", int.Parse(ddlImputado.SelectedValue));
        //    //DEFENSOR
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblNombreDefensor, "MarcadorDefensorNombre", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblIdentificacionDefensor, "MarcadorIdentificacionDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblFolioDefensor, "MarcadorFolioIdentificacionDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblNacionalidadDefensor, "MarcadorNacionalidadDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblCiudadOrigenDefensor, "MarcadorMumicipioOrigenDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblDomicilioDefensor, "MarcadorDomicilioDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    Marcadores.MarcadorComboDefensor(int.Parse(IdCarpeta.Text), LblTelefonoDefensor, "MarcadorTelDefensor", int.Parse(ddlDefensor.SelectedValue));
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));

        //}

        //void MarcadorDeclaracionTestimonial()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC11, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad15, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito10, "MarcadorDelito");
        //    Marcadores.MarcadorFechas(LblFechaOficio3, "MarcadorFechaOficio");
        //    Marcadores.MarcadorFechas(LblHoraActual2, "MarcadorHoraActual");
        //    //TESTIGO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreTestigo, "MarcadorTestigoNombre", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblDomicilioTestigo, "MarcadorDomicilioTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblMunicipioOrigenTestigo, "MarcadorMumicipioOrigenTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEstadoOrigenTestigo, "MarcadorEstadoOrigenTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNacionalidadTestigo, "MarcadorNacionalidadTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblOcupacionTestigo, "MarcadorOcupacionTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelFijoTestigo, "MarcadorTelParticularTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelMovilTestigo, "MarcadorTelCelTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblTelNotiTestigo, "MarcadorTelNotificacionTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEmailTestigo, "MarcadorEmailTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEscolaridadTestigo, "MarcadorEscolaridadTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblSexoTestigo, "MarcadorSexoTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFechaNaciTestigo, "MarcadorFechaNacTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblEstadoCiviliTestigo, "MarcadorEdoCivilTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblFolioTestigo, "MarcadorIFE_Testigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblRfcTestigo, "MarcadorRFC_Testigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblLicenciaTestigo, "MarcadorLicenciaManejoTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblPasaporteTestigo, "MarcadorPasaporteTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblCurpTestigo, "MarcadorCurpTestigo", int.Parse(ddlTestigo.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP12, "MarcadorNombreMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCargoMP12, "MarcadorCargoMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado12, "MarcadorNumeroEmpleadoMP");
        //}

        //void MarcadorOficioHechosTransito()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC3, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad7, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito2, "MarcadorDelito");
        //    Marcadores.MarcadorFechas(lblDir, "MarcadorDirectorPericiales");
        //    //LUGAR DE HECHOS
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblFechaLugarHechos, "MarcadorFechaLugarHechos");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos1, "MarcadorLugarHechos");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP4, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado4, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.MarcadorFechas(LblDia2, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño2, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes2, "MarcadorMesActual");
        //}

        //void MarcadorOficioExploracionDetenido()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC4, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad8, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito3, "MarcadorDelito");
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido2, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP5, "MarcadorNombreMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCargoMP5, "MarcadorCargoMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado5, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCiudad, "MarcadorMunicipioUnidad");
        //    Marcadores.MarcadorFechas(LblDia3, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño3, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes3, "MarcadorMesActual");
        //}

        //void MarcadorOficioInformeGenetica()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC5, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad9, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito4, "MarcadorDelito");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos2, "MarcadorLugarHechos");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP6, "MarcadorNombreMP");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCargoMP6, "MarcadorCargoMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado6, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.MarcadorFechas(LblDia4, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño4, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes4, "MarcadorMesActual");
        //}

        //void MarcadorOficioInformeLesionado()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC6, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad10, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito5, "MarcadorDelito");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos3, "MarcadorLugarHechos");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP7, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado7, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.MarcadorFechas(LblDia5, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño5, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes5, "MarcadorMesActual");
        //}

        //void MarcadorOficioValuadorFoto()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC7, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad11, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito6, "MarcadorDelito");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos4, "MarcadorLugarHechos");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP8, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado8, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.MarcadorFechas(LblDia6, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño6, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes6, "MarcadorMesActual");
        //}

        //void MarcadorOrdenContinuacionPM()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC8, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad12, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito7, "MarcadorDelito");
        //    Marcadores.MarcadorFechas(LblFechaOficio2, "MarcadorFechaOficio");
        //    //DENUNCIANTE
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDenunciante3, "MarcadorDenuncianteNombre", int.Parse(ddlDenunciante.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido6, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP9, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado9, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.MarcadorFechas(LblDia7, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño7, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes7, "MarcadorMesActual");
        //}

        //void MarcadorOrdenInvestigacionPM()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC9, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad13, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito8, "MarcadorDelito");
        //    //DENUNCIANTE
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDenunciante2, "MarcadorDenuncianteNombre", int.Parse(ddlDenunciante.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido5, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP10, "MarcadorNombreMP");
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNumeroEmpleado10, "MarcadorNumeroEmpleadoMP");
        //    Marcadores.MarcadorFechas(LblDia8, "MarcadorDiaActual");
        //    Marcadores.MarcadorFechas(LblAño8, "MarcadorAñoActual");
        //    Marcadores.MarcadorFechas(LblMes8, "MarcadorMesActual");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblCiudad1, "MarcadorMunicipioUnidad");
        //}

        //void MarcadorOficioSolicitarFotografia()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC14, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad16, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito12, "MarcadorDelito");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP13, "MarcadorNombreMP");
        //}

        //void MarcadorOficioInformePsicologicoMenor()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC15, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad17, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito13, "MarcadorDelito");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP14, "MarcadorNombreMP");
        //}

        //void MarcadorOficioInformePsicologico()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC16, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad18, "MarcadorUnidadInvestigadora");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito14, "MarcadorDelito");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP15, "MarcadorNombreMP");
        //}

        //void MarcadorOficioIncompetencia()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC23, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito19, "MarcadorDelito");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido5, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido12, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //LUGAR DE HECHOS
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos6, "MarcadorLugarHechos");
        //}

        //void MarcadorOficioEntregaCuerpo()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC29, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito19, "MarcadorDelito");
        //    //LUGAR DE HECHOS
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos9, "MarcadorLugarHechos");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblFechaLugarHechos4, "MarcadorFechaLugarHechos");
        //}

        //void MarcadorInejercicioPerdon()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC21, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito17, "MarcadorDelito");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido3, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido10, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP18, "MarcadorNombreMP");
        //}

        //void MarcadorOficioNotificarInejercicio()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC22, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito18, "MarcadorDelito");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido4, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido11, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP19, "MarcadorNombreMP");
        //}

        //void MarcadorOficioEvolutivoLesiones()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC24, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito20, "MarcadorDelito");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP20, "MarcadorNombreMP");
        //}

        //void MarcadorAucerdoAbstenerse()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC27, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), lblFechaNuc1, "MarcadorFechaNuc");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito23, "MarcadorDelito");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido7, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    //LUGAR DE HECHOS
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos7, "MarcadorLugarHechos");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblFechaLugarHechos2, "MarcadorFechaLugarHechos");
        //}

        //void MarcadorArchivoTemporal()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC30, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), lblFechaNuc, "MarcadorFechaNuc");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito25, "MarcadorDelito");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido9, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido15, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //}

        //void MarcadorExortoTestigo()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC26, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito22, "MarcadorDelito");
        //    //TESTIGO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreTestigo1, "MarcadorTestigoNombre", int.Parse(ddlTestigo.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblDomicilioTestigo1, "MarcadorDomicilioTestigo", int.Parse(ddlTestigo.SelectedValue));
        //}

        //void MarcadorExamenDetencion()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC20, "MarcadorNUC");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido2, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido9, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP17, "MarcadorNombreMP");
        //}

        //void MarcadorExortoImputado()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC25, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito21, "MarcadorDelito");
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido13, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), lblDomicilioImputado1, "MarcadorDomicilioImputado", int.Parse(ddlImputado.SelectedValue));
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido6, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //}

        //void MarcadorAucerdoIncompetencia()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC19, "MarcadorNUC");
        //    //LUGAR DE HECHOS
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos5, "MarcadorLugarHechos");
        //    //MP
        //    Marcadores.MarcadorMP(int.Parse(IdCarpeta.Text), short.Parse(Session["IdUsuario"].ToString()), LblNombreMP16, "MarcadorNombreMP");
        //}

        //void MarcadorOficioMediacion()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC17, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito15, "MarcadorDelito");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad19, "MarcadorUnidadInvestigadora");
        //    //DENUNCIANTE
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDenunciante4, "MarcadorDenuncianteNombre", int.Parse(ddlDenunciante.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido7, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //}

        //void MarcadorOficioInstitutoVictimas()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC18, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito16, "MarcadorDelito");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblUnidad20, "MarcadorUnidadInvestigadora");
        //    //DENUNCIANTE
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDenunciante5, "MarcadorDenuncianteNombre", int.Parse(ddlDenunciante.SelectedValue));
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido8, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //}

        //void MarcadorNotificarAcuerdoAbstenerse()
        //{
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblNUC28, "MarcadorNUC");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblDelito24, "MarcadorDelito");
        //    //OFENDIDO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreOfendido8, "MarcadorOfendidoNombre", int.Parse(ddlOfendido.SelectedValue));
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblDomicilioOfendido1, "MarcadorDomicilioOfendido", int.Parse(ddlOfendido.SelectedValue));
        //    //LUGAR DE HECHOS
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblLugarHechos8, "MarcadorLugarHechos");
        //    Marcadores.Marcador(int.Parse(IdCarpeta.Text), LblFechaLugarHechos3, "MarcadorFechaLugarHechos");
        //    //IMPUTADO
        //    Marcadores.MarcadorCombo(int.Parse(IdCarpeta.Text), LblNombreDetenido14, "MarcadorImputadoNombre", int.Parse(ddlImputado.SelectedValue));
        //}

        //#endregion

        //#region cmdGenerarPdf
        //protected void cmdGeneraPdf_Click(object sender, EventArgs e)
        //{
        //    if (ddlPlantilla.SelectedValue == "1")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ACTA DE DENUNCIA O QUERELLA.pdf");
        //        FillPDF_ACTA_DENUNCIA(Server.MapPath("PDF_NUC\\ACTA DE DENUNCIA O QUERELLA.pdf"), Response.OutputStream);

        //    }
            
        //    if (ddlPlantilla.SelectedValue == "3")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ACUERDO DE INICIO.pdf");
        //        FillPDF_ACUERDO_INICIO(Server.MapPath("PDF_NUC\\ACUERDO DE INICIO.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "4")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=DECLARACION DE IMPUTADO.pdf");
        //        FillPDF_DECLARACION_IMPUTADO(Server.MapPath("PDF_NUC\\DECLARACION DE IMPUTADO.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "5")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=DECLARACION TESTIMONIAL.pdf");
        //        FillPDF_DECLARACION_TESTIMONIAL(Server.MapPath("PDF_NUC\\DECLARACION TESTIMONIAL.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "6")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA QUE PERITO EN HECHOS DE TRANSITO SE IMPONGA DE ACTAS.pdf");
        //        FillPDF_OFICIO_PERITO_IMPONGA_ACTAS(Server.MapPath("PDF_NUC\\OFICIO PARA QUE PERITO EN HECHOS DE TRANSITO SE IMPONGA DE ACTAS.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "7")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR EXPLORACION FISICA DE DETENIDO.pdf");
        //        FillPDF_OFICIO_EXPLORACION_DETENIDO(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR EXPLORACION FISICA DE DETENIDO.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "8")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR INFORME EN MATERIA DE GENETICA.pdf");
        //        FillPDF_OFICIO_MATERIA_GENETICA(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR INFORME EN MATERIA DE GENETICA.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "9")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR INFORME MEDICO DE LESIONADO.pdf");
        //        FillPDF_OFICIO_INFORME_LESIONADO(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR INFORME MEDICO DE LESIONADO.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "10")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO_PARA_SOLICITAR_PERITO QUMICO.pdf");
        //        FillPDF_PERITO_QUIMICO(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR PERITO QUMICO.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "11")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR PERITO VALUADOR Y FOTOGRAFIA.pdf");
        //        FillPDF_OFICIO_VALUADOR_FOTOGRAFIA(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR PERITO VALUADOR Y FOTOGRAFIA.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "12")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ORDEN CONTINUACION DE INVESTIGACION A LA POLICIA MINISTERIAL.pdf");
        //        FillPDF_ORDEN_CONTINUACION_POLICIA_MINISTERIAL(Server.MapPath("PDF_NUC\\ORDEN CONTINUACION DE INVESTIGACION A LA POLICIA MINISTERIAL.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "13")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ORDEN DE INVESTIGACION A LA POLICIA MINISTERIAL.pdf");
        //        FillPDF_ORDEN_INVESTIGACION_POLICIA_MINISTERIAL(Server.MapPath("PDF_NUC\\ORDEN DE INVESTIGACION A LA POLICIA MINISTERIAL.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "14")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR FOTOGRAFIA.pdf");
        //        FillPDF_SOLICITAR_FOTOGRAFIA(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR FOTOGRAFIA.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "15")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ACTA DE LECTURA Y EXPLICACIÓN DE DERECHOS A LA VÍCTIMA.pdf");
        //        FillPDF_ACTA_LECTURA(Server.MapPath("PDF_NUC\\ACTA DE LECTURA Y EXPLICACIÓN DE DERECHOS A LA VÍCTIMA.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "16")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR INFORME PSICOLOGICO PARA MENOR.pdf");
        //        FillPDF_SOLICITAR_PSICOLOGICO_MENOR(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR INFORME PSICOLOGICO PARA MENOR.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "17")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR INFORME PSICOLOGICO.pdf");
        //        FillPDF_SOLICITAR_PSICOLOGICO(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR INFORME PSICOLOGICO.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "18")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO DE INCOMPETENCIA.pdf");
        //        FillPDF_OFICIO_INCOMPETENCIA(Server.MapPath("PDF_NUC\\OFICIO DE INCOMPETENCIA.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "19")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO DE ENTREGA DE CUERPO.pdf");
        //        FillPDF_OFICIO_ENTREGA_CUERPO(Server.MapPath("PDF_NUC\\OFICIO DE ENTREGA DE CUERPO.pdf"), Response.OutputStream);

        //    }
        //    if (ddlPlantilla.SelectedValue == "20")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=INEJERCICIO POR PERDON.pdf");
        //        FillPDF_INEJERCICIO_PERDON(Server.MapPath("PDF_NUC\\INEJERCICIO POR PERDON.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "21")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA NOTIFICAR INEJERCICIO.pdf");
        //        FillPDF_OFICIO_NOTIFICAR_INEJERCICIO(Server.MapPath("PDF_NUC\\OFICIO PARA NOTIFICAR INEJERCICIO.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "22")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR EVOLUTIVO DE LESIONES.pdf");
        //        FillPDF_OFICIO_EVOLUTIVO_LESIONES(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR EVOLUTIVO DE LESIONES.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "23")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ACUERDO PARA ABSTENERSE DE INVESTIGAR.pdf");
        //        FillPDF_ACUERDO_ABSTENERSE_INVESTIGAR(Server.MapPath("PDF_NUC\\ACUERDO PARA ABSTENERSE DE INVESTIGAR.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "24")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ARCHIVO TEMPORAL.pdf");
        //        FillPDF_ARCHIVO_TEMPORAL(Server.MapPath("PDF_NUC\\ARCHIVO TEMPORAL.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "25")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR EXHORTO (TESTIGO).pdf");
        //        FillPDF_OFICIO_EXORTO_TESTIGO(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR EXHORTO (TESTIGO).pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "26")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=EXAMEN DE LA DETENCION.pdf");
        //        FillPDF_EXAMEN_DETENCION(Server.MapPath("PDF_NUC\\EXAMEN DE LA DETENCION.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "27")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA SOLICITAR EXHORTO (IMPUTADO).pdf");
        //        FillPDF_OFICIO_EXORTO_IMPUTADO(Server.MapPath("PDF_NUC\\OFICIO PARA SOLICITAR EXHORTO (IMPUTADO).pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "28")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=ACUERDO DE INCOMPETENCIA.pdf");
        //        FillPDF_ACUERDO_INCOMPETENCIA(Server.MapPath("PDF_NUC\\ACUERDO DE INCOMPETENCIA.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "29")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA MEDIACION.pdf");
        //        FillPDF_OFICIO_MEDIACION(Server.MapPath("PDF_NUC\\OFICIO PARA MEDIACION.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "30")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA EL INSTITUTO DE VICTIMAS.pdf");
        //        FillPDF_OFICIO_INSTITUTO_VICTIMAS(Server.MapPath("PDF_NUC\\OFICIO PARA EL INSTITUTO DE VICTIMAS.pdf"), Response.OutputStream);
        //    }
        //    if (ddlPlantilla.SelectedValue == "31")
        //    {
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=OFICIO PARA NOTIFICAR ACUERDO PARA ABSTENERSE DE INVESTIGAR.pdf");
        //        FillPDF_OFICIO_ACUERDO_ABSTENERSE_INVESTIGAR(Server.MapPath("PDF_NUC\\OFICIO PARA NOTIFICAR ACUERDO PARA ABSTENERSE DE INVESTIGAR.pdf"), Response.OutputStream);
        //    }
        //    cmdGuardar.Enabled = true;
        //}
        //#endregion

        //#region Fill_PDF
        //public void FillPDF_PERITO_QUIMICO(string template, Stream stream)
        //{

        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad11.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtOficio.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);

        //    stamp.AcroFields.SetField("M_CIUDADANO", txtCiudadanoPeritoQuimico.Text);
        //    stamp.AcroFields.SetField("M_DETENIDO", LblNombreDetenido4.Text);

        //    stamp.AcroFields.SetField("M_AGENTE", LblNombreMP.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad3.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño10.Text);

        //    stamp.FormFlattening = true;
        //    stamp.Close();



        //}

        

        //public void FillPDF_ACUERDO_INICIO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_NUC4", LblNUC2.Text);
        //    //stamp.AcroFields.SetField("M_AÑO1", LblAño1.Text);
        //    // stamp.AcroFields.SetField("M_DELITO3", LblDelito1.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION2", LblUnidad6.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION3", LblUnidad6.Text);
        //    stamp.AcroFields.SetField("M_NUMDIA", LblDia1.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes1.Text);
        //    stamp.AcroFields.SetField("M_AÑO2", LblAño1.Text);
        //    stamp.AcroFields.SetField("M_HORA5", LblHoraActual3.Text);
        //    // stamp.AcroFields.SetField("M_NOMLIC", txtJuezCalificadorAcuerdoInicio.Text);
        //    stamp.AcroFields.SetField("M_DETENIDO", LblNombreDetenido.Text);
        //    stamp.AcroFields.SetField("M_DENUNCIANTE", LblNombreDenunciante1.Text);
        //    stamp.AcroFields.SetField("M_DELITO4", LblDelito1.Text);
        //    stamp.AcroFields.SetField("M_AMP7", LblNombreMP3.Text);
        //    stamp.AcroFields.SetField("M_NUMAMP6", LblNumeroEmpleado3.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION3", LblUnidad6.Text);
        //    stamp.AcroFields.SetField("M_DIA1", LblDia1.Text);
        //    stamp.AcroFields.SetField("M_MES1", LblMes1.Text);
        //    stamp.AcroFields.SetField("M_AÑO3", LblAño1.Text);
        //    stamp.AcroFields.SetField("M_CIUDAD", LblCiudad4.Text);
        //    stamp.AcroFields.SetField("M_CIUDAD2", LblCiudad4.Text);

        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_ACTA_LECTURA(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC13.Text);
        //    stamp.AcroFields.SetField("M_NOMUNIDAD2", LblUnidad4.Text);
        //    stamp.AcroFields.SetField("M_FECHA2", LblFechaOficio1.Text);
        //    stamp.AcroFields.SetField("M_NUMUNI2", LblUnidad4.Text);
        //    stamp.AcroFields.SetField("M_HORA2", LblHoraActual1.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido1.Text);
        //    stamp.AcroFields.SetField("M_NOMBRE_DEFENSOR", LblNombreDefensor1.Text);
        //    stamp.AcroFields.SetField("M_IDENTIFICACION", LblIdentificacionDefensor1.Text);
        //    stamp.AcroFields.SetField("M_FOLIO", LblFolioDefensor1.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_NOTIFICACIONES", LblDomicilioDefensor1.Text);
        //    stamp.AcroFields.SetField("TELEFONO_NOTIFICACIONES", LblTelefonoDefensor1.Text);
        //    stamp.AcroFields.SetField("M_NOMAMP1", LblNombreMP2.Text);
        //    stamp.AcroFields.SetField("M_NOMAMP3", LblNombreMP2.Text);
        //    stamp.AcroFields.SetField("M_NUMEMPLE3", LblNumeroEmpleado2.Text);
        //    stamp.AcroFields.SetField("M_NUMUNI3", LblUnidad4.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_PERITO_IMPONGA_ACTAS(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC3.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficioActas.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito2.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad7.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_1", LblUnidad7.Text);
        //    stamp.AcroFields.SetField("M_OFICIO_1", txtOficioConocimineto.Text);
        //    stamp.AcroFields.SetField("M_FECHA_OFICIO", txtFechaOficio3.Text);
        //    stamp.AcroFields.SetField("M_DIRECTOR", txtAutoridadRemite.Text);
        //    stamp.AcroFields.SetField("M_PARTE", txtNumeroParte.Text);
        //    stamp.AcroFields.SetField("M_FECHA_PARTE", txtFechaParte.Text);
        //    stamp.AcroFields.SetField("M_POLICIA", txtSignadoPolicia.Text);
        //    stamp.AcroFields.SetField("M_FECHA_HECHOS", LblFechaLugarHechos.Text);
        //    stamp.AcroFields.SetField("M_LUGAR_HECHOS", LblLugarHechos1.Text);
        //    stamp.AcroFields.SetField("M_VEHICULOS", txtVehiculos2.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP4.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado4.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia2.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes2.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño2.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_EXPLORACION_DETENIDO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC4.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtOficio2.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito3.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_1", LblUnidad8.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad8.Text);
        //    stamp.AcroFields.SetField("M_DETENIDO", LblNombreDetenido2.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_3", LblUnidad8.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP5.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado5.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_4", LblUnidad8.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad4.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia3.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes3.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño3.Text);

        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_MATERIA_GENETICA(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficioGenetica.Text);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC5.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad9.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito4.Text);
        //    stamp.AcroFields.SetField("M_LUGAR_HECHOS", LblLugarHechos2.Text);
        //    stamp.AcroFields.SetField("M_INDICIOS", txtIndicios.Text);
        //    stamp.AcroFields.SetField("M_OCCISO", txtNombreOccisoGenetica.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad9.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP6.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado6.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_3", LblUnidad9.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia4.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes4.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño4.Text);

        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_INFORME_LESIONADO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_NUC7", LblNUC6.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION7", LblUnidad10.Text);
        //    stamp.AcroFields.SetField("M_DELITO10", LblDelito5.Text);
        //    // stamp.AcroFields.SetField("M_LHECHOS2", LblLugarHechos3.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_NOMCIU", txtCiudadanoLesionado.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION8", LblUnidad10.Text);
        //    stamp.AcroFields.SetField("M_NOMAMP10", LblNombreMP7.Text);
        //    stamp.AcroFields.SetField("M_NUMEMPLE9", LblNumeroEmpleado7.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION9", LblUnidad10.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO5", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA8", LblDia5.Text);
        //    stamp.AcroFields.SetField("M_MES6", LblMes5.Text);
        //    stamp.AcroFields.SetField("M_AÑO7", LblAño5.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_VALUADOR_FOTOGRAFIA(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_AGEMP", LblUnidad11.Text);
        //    stamp.AcroFields.SetField("M_NUC8", LblNUC7.Text);
        //    stamp.AcroFields.SetField("M_DELITO12", LblDelito6.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtOficio1.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_LHECHOS4", LblLugarHechos4.Text);
        //    stamp.AcroFields.SetField("M_VEHICULOS1", txtVehiculos3.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION12", LblUnidad11.Text);
        //    stamp.AcroFields.SetField("M_NOMAMP12", LblNombreMP8.Text);
        //    stamp.AcroFields.SetField("M_NUMEROEMPLE11", LblNumeroEmpleado8.Text);
        //    stamp.AcroFields.SetField("M_ADSCRIPCION13", LblUnidad11.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO7", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA10", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES8", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO9", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_ORDEN_CONTINUACION_POLICIA_MINISTERIAL(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficioInvestigacion.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_1", LblUnidad12.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito7.Text);
        //    stamp.AcroFields.SetField("M_DELITO_2", LblDelito7.Text);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC8.Text);
        //    stamp.AcroFields.SetField("M_AGENTE", txtNombreAgentesPM.Text);
        //    stamp.AcroFields.SetField("M_DETENIDO", LblNombreDetenido6.Text);
        //    stamp.AcroFields.SetField("M_DENUNCIANTE", LblNombreDenunciante3.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP9.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado9.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad12.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia7.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes7.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño7.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_ORDEN_INVESTIGACION_POLICIA_MINISTERIAL(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficioPM.Text);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC9.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad13.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito8.Text);
        //    stamp.AcroFields.SetField("M_POLICIA", txtNombrePolicia.Text);
        //    stamp.AcroFields.SetField("M_DELITO_1", LblDelito8.Text);
        //    stamp.AcroFields.SetField("M_DENUNCIANTE", LblNombreDenunciante2.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido5.Text);
        //    stamp.AcroFields.SetField("M_AGENTE", LblNombreMP10.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado10.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad13.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia8.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes8.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño8.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_DECLARACION_TESTIMONIAL(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC11.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad15.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad15.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_3", LblUnidad15.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito10.Text);
        //    stamp.AcroFields.SetField("M_FECHA", LblFechaOficio3.Text);
        //    stamp.AcroFields.SetField("M_HORA_INICIO", LblHoraActual2.Text);
        //    stamp.AcroFields.SetField("M_TESTIGO", LblNombreTestigo.Text);
        //    stamp.AcroFields.SetField("M_PADRE", txtNombrePadreTutorTestigo.Text);
        //    stamp.AcroFields.SetField("M_MADRE", txtNombreMadreTestigo.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO", LblDomicilioTestigo.Text);
        //    stamp.AcroFields.SetField("M_ORIGEN", LblMunicipioOrigenTestigo.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblEstadoOrigenTestigo.Text);
        //    stamp.AcroFields.SetField("M_NACIONALIDAD", LblNacionalidadTestigo.Text);
        //    stamp.AcroFields.SetField("M_OCUPACION", LblOcupacionTestigo.Text);
        //    stamp.AcroFields.SetField("M_TEL_FIJO", LblTelFijoTestigo.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_LAB", txtDomicilioLaboralTestigo.Text);
        //    stamp.AcroFields.SetField("M_TEL_CEL", LblTelMovilTestigo.Text);
        //    stamp.AcroFields.SetField("M_RECIBE_RECADOS", txtTerceroRecibeRecadosTestigo.Text);
        //    stamp.AcroFields.SetField("M_TEL_NOTI", LblTelNotiTestigo.Text);
        //    stamp.AcroFields.SetField("M_ESCOLARIDAD", LblEscolaridadTestigo.Text);
        //    stamp.AcroFields.SetField("M_EMAIL", LblEmailTestigo.Text);
        //    stamp.AcroFields.SetField("M_SEXO", LblSexoTestigo.Text);
        //    stamp.AcroFields.SetField("M_FECHA_NACI", LblFechaNaciTestigo.Text);
        //    stamp.AcroFields.SetField("M_ESTADO_CIVIL", LblEstadoCiviliTestigo.Text);
        //    stamp.AcroFields.SetField("M_RELIGION", txtRegionTestigo.Text);
        //    stamp.AcroFields.SetField("M_CONYUGE", txtNombreConyugeTestigo.Text);
        //    stamp.AcroFields.SetField("M_ELECTOR", LblFolioTestigo.Text);
        //    stamp.AcroFields.SetField("M_RFC", LblRfcTestigo.Text);
        //    stamp.AcroFields.SetField("M_LICENCIA", LblLicenciaTestigo.Text);
        //    stamp.AcroFields.SetField("M_PASAPORTE", LblPasaporteTestigo.Text);
        //    stamp.AcroFields.SetField("M_SEGURO", txtNumeroSocialTestigo.Text);
        //    stamp.AcroFields.SetField("M_CURP", LblCurpTestigo.Text);
        //    stamp.AcroFields.SetField("M_OTRO", txtOtroTestigo.Text);
        //    stamp.AcroFields.SetField("M_TESTIGO_2", LblNombreTestigo.Text);
        //    stamp.AcroFields.SetField("M_ENTREVISTA", txtAreaRealizaEntrevistaTestigo.Text);
        //    stamp.AcroFields.SetField("M_HORA_TERMINO", txtHoraTerminoEntrevistaTestigo.Text);
        //    stamp.AcroFields.SetField("M_NEGAR", txtNegar.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP12.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado12.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_3", LblUnidad15.Text);

        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_DECLARACION_IMPUTADO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido3.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad2.Text);
        //    stamp.AcroFields.SetField("M_HORAS", LblHoraActual3.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia1.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes1.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño1.Text);
        //    stamp.AcroFields.SetField("M_DEFENSOR", LblNombreDefensor.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_1", LblNombreDetenido3.Text);
        //    stamp.AcroFields.SetField("M_IDENTIFICACION", LblIdentificacionDetenido.Text);
        //    stamp.AcroFields.SetField("M_FOLIO", LblFolioIdentificacion.Text);
        //    stamp.AcroFields.SetField("M_CIUDAD_ORIGEN", LblCiudadOrigenDetenido.Text);
        //    stamp.AcroFields.SetField("M_ESTADO_ORIGEN", LblEstadoOrigenDetenido.Text);
        //    stamp.AcroFields.SetField("M_ESTADO_CIVIL", LblEstadoCivil1.Text);
        //    stamp.AcroFields.SetField("M_AÑOS", LblEdad1.Text);
        //    stamp.AcroFields.SetField("M_FECHA_NACI", LblFechaNacimiento1.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_IMPUTADO", LblDomicilioDetenido.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_IMPUTADO_NOTI", txtDomicilioNotiDetenido.Text);
        //    stamp.AcroFields.SetField("M_OCUPACION", LblOcupacionDetenido.Text);
        //    stamp.AcroFields.SetField("M_INGRESO", txtingresoDetenido.Text);
        //    stamp.AcroFields.SetField("M_TEL_FIJO", LblTelFijoDetenido.Text);
        //    stamp.AcroFields.SetField("M_TEL_CEL", LblTelMovilDetenido.Text);

        //    stamp.AcroFields.SetField("M_PADRE", txtNombrePadreDetenido.Text);
        //    stamp.AcroFields.SetField("M_PADRE_VIVO", txtVivoPadreDet.Text);
        //    stamp.AcroFields.SetField("M_PADRE_MUERTO", txtFinadoPadreDet.Text);
        //    stamp.AcroFields.SetField("M_MADRE", txtNombreMadreDetenido.Text);
        //    stamp.AcroFields.SetField("M_MADRE_VIVO", txtVivoMadreDet.Text);
        //    stamp.AcroFields.SetField("M_MADRE_MUERTO", txtFinadoMadreDet.Text);
        //    stamp.AcroFields.SetField("M_DEPENDIENTES", txtDependientes.Text);
        //    stamp.AcroFields.SetField("M_EMAIL", LblEmailDetenido.Text);

        //    stamp.AcroFields.SetField("M_DEFENSOR_1", LblNombreDefensor.Text);
        //    stamp.AcroFields.SetField("M_DEFENSOR_IDENTIFICA", LblIdentificacionDefensor.Text);
        //    stamp.AcroFields.SetField("M_FOLIO_DEFENSOR", LblFolioDefensor.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_2", LblNombreDetenido3.Text);
        //    stamp.AcroFields.SetField("M_DEFENSOR_2", LblNombreDefensor.Text);
        //    stamp.AcroFields.SetField("M_ORIGEN_DEFENSOR", LblCiudadOrigenDefensor.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_DEFENSOR", LblDomicilioDefensor.Text);
        //    stamp.AcroFields.SetField("M_TEL_DEFENSOR", LblTelefonoDefensor.Text);
        //    stamp.AcroFields.SetField("M_DEFENSOR_3", LblNombreDefensor.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_3", LblNombreDetenido3.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito11.Text);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC12.Text);
        //    stamp.AcroFields.SetField("M_FECHA_HECHOS", LblFechaLugarHechos1.Text);
        //    stamp.AcroFields.SetField("M_HORA_HECHOS", LblHoraDelito.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido.Text);
        //    stamp.AcroFields.SetField("M_DECLARACION_OFENDIDO", txtDeclaracionOfendido.Text);
        //    stamp.AcroFields.SetField("M_DEFENSOR_4", LblNombreDefensor.Text);
        //    stamp.AcroFields.SetField("M_DECLARACION_DEFENSOR", txtDeclaracionDefensor.Text);
        //    stamp.AcroFields.SetField("M_DECLARACION_IMPUTADO", txtDeclaracionImputado.Text);
        //    stamp.AcroFields.SetField("M_HORA_FIN", txtHoraFin.Text);

        //    stamp.AcroFields.SetField("M_DEFENSOR_5", LblNombreDefensor.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_4", LblNombreDetenido3.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP3.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_ACTA_DENUNCIA(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);
        //    stamp.AcroFields.SetField("M_NUC", LblNUC1.Text);
        //    stamp.AcroFields.SetField("M_DENUNICIA", txtDenuncia.Text);
        //    stamp.AcroFields.SetField("M_PERSONA_FISICA", txtPersonaFisica.Text);
        //    stamp.AcroFields.SetField("M_REPRESENTANTE", txtRespresentante.Text);
        //    stamp.AcroFields.SetField("M_PERSONA_MORAL", txtPersonaMoral.Text);
        //    stamp.AcroFields.SetField("M_ACUDE", txtPropioDerecho.Text);
        //    stamp.AcroFields.SetField("M_PERSONA_FISICA2", txtPersonaFisica2.Text);
        //    stamp.AcroFields.SetField("PERSONA_MORAL2", txtPersonaMoral2.Text);

        //    stamp.AcroFields.SetField("M_NOMBRE_EMPRESA", lblDenominacion.Text);
        //    stamp.AcroFields.SetField("M_RFC_EMPRESA", lblRFCEmprresa.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_EMPRESA", lblDomicilioEmpresa.Text);
        //    stamp.AcroFields.SetField("M_ESCRITURA_PUBLICA", lblEscritura.Text);
        //    stamp.AcroFields.SetField("M_NO_ESCRITURA", lblNoEscritura.Text);
        //    stamp.AcroFields.SetField("M_OTRO", lblOtro.Text);
        //    stamp.AcroFields.SetField("M_ESPECIFICAR", lblEspecificar.Text);


        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad1.Text);
        //    stamp.AcroFields.SetField("M_NOMUNIDAD", LblUnidad1.Text);
        //    stamp.AcroFields.SetField("M_NUMUNIDAD2", LblUnidad1.Text);
        //    stamp.AcroFields.SetField("M_FECHA", LblFechaOficio.Text);
        //    stamp.AcroFields.SetField("M_HORA", LblHoraActual.Text);
        //    stamp.AcroFields.SetField("M_NOMDENUNCIANTE", NombreDenunciante.Text);
        //    stamp.AcroFields.SetField("M_NOMDENUNCIANTE1", NombreDenunciante.Text);
        //    stamp.AcroFields.SetField("M_NOMPADRE", txtNombrePadreDenuciante.Text);
        //    stamp.AcroFields.SetField("M_VIVO_PADRE", txtVivoPadre.Text);
        //    stamp.AcroFields.SetField("M_FINADO_PADRE", txtFinadoPadre.Text);
        //    stamp.AcroFields.SetField("M_NOMMADRE", txtNombreMadreDenunciante.Text);
        //    stamp.AcroFields.SetField("M_VIVO_MADRE", txtVivoMadre.Text);
        //    stamp.AcroFields.SetField("M_FINADO_MADRE", txtFinadoMadre.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO2", LblDomicilioDenunciante.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO3", txtDomicilioNotificacionesDenunciante.Text);
        //    stamp.AcroFields.SetField("M_ORIGINARIO", LblOriginario.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO3", LblOriginarioMunicipio.Text);
        //    stamp.AcroFields.SetField("M_ESTADO", LblOriginarioEstado.Text);
        //    stamp.AcroFields.SetField("M_NACIONALIDAD", LblNacionalidad.Text);
        //    stamp.AcroFields.SetField("M_TELEFONO", LblTelFijoDenunciante.Text);
        //    stamp.AcroFields.SetField("M_OCUPACION", LblOcupacion.Text);
        //    stamp.AcroFields.SetField("M_INGREMEN", txtIngresoMensual.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIOLAB", txtDomicilioLaboralDenunciante.Text);
        //    stamp.AcroFields.SetField("M_CELULAR", LblTelMovilDenunciante.Text);
        //    stamp.AcroFields.SetField("M_TELEFONO2", LblTelNotificacionesDenunciante.Text);
        //    stamp.AcroFields.SetField("M_ESCOLARIDAD", LblEsccolaridad.Text);
        //    stamp.AcroFields.SetField("M_EMAIL", LblEmail.Text);
        //    stamp.AcroFields.SetField("M_SEXO", LblSexo.Text);
        //    stamp.AcroFields.SetField("M_FECHANAC", LblFechaNacimiento.Text);
        //    stamp.AcroFields.SetField("M_EDOCIVIL", LblEstadoCivil.Text);
        //    stamp.AcroFields.SetField("M_RELIGION", txtRegionDenunciante.Text);
        //    stamp.AcroFields.SetField("M_NOMCONYUGE", txtNombreConyugeDenunciante.Text);
        //    stamp.AcroFields.SetField("M_FELECTOR", LblFolioElector.Text);
        //    stamp.AcroFields.SetField("M_RFC", LblRFC.Text);
        //    stamp.AcroFields.SetField("M_NUMLICCON", LblLicenciaConducir.Text);
        //    stamp.AcroFields.SetField("M_NPASAPORTE", LblPasaporte.Text);
        //    stamp.AcroFields.SetField("M_NUMSEGSOC", txtNumeroSocialDenunciante.Text);
        //    stamp.AcroFields.SetField("M_CURP", LblCurp.Text);
        //    stamp.AcroFields.SetField("M_DATOS_DENUNCIANTE", txtDatosDenunciante.Text);

        //    stamp.AcroFields.SetField("M_NOMBRE_IMPUTADO", lblNombreImputado.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_IMPUTADO", lblDomicilioImputado.Text);

        //    stamp.AcroFields.SetField("M_NOMBRE_OFENDIDO", lblNombreOfen.Text);
        //    stamp.AcroFields.SetField("M_PADRE_OFENDIDO", txtNombrePadreOfendido.Text);
        //    stamp.AcroFields.SetField("M_VIVO_PADRE_OFEN", txtVivoPadreOfendido.Text);
        //    stamp.AcroFields.SetField("M_FINADO_PADRE_OFEN", txtFinadoPadreOfendido.Text);
        //    stamp.AcroFields.SetField("M_MADRE_OFENDIDO", txtNombreMadreOfendido.Text);
        //    stamp.AcroFields.SetField("M_VIVO_MADRE_OFEN", txtVivoMadreOfendido.Text);
        //    stamp.AcroFields.SetField("M_FINADO_MADRE_OFEN", txtFinadoMadreOfendido.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_OFENDIDO", LblDomicilioOfendido.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_NOTI_OFENDIDO", txtDomicilioNotificacionesOfendido.Text);
        //    stamp.AcroFields.SetField("M_POBLACION_OFENDIDO", LblOriginarioOfendido.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO_OFENDIDO", LblOriginarioMunicipioOfendido.Text);
        //    stamp.AcroFields.SetField("M_ESTADO_OFENDIDO", LblOriginarioEstadoOfendido.Text);
        //    stamp.AcroFields.SetField("M_NACINALIDAD_OFENDIDO", LblNacionalidadOfendido.Text);
        //    stamp.AcroFields.SetField("M_TEL_FIJO_OFENDIDO", LblTelFijoOfendido.Text);
        //    stamp.AcroFields.SetField("M_OCUPACION_OFENDIDO", LblOcupacionOfendido.Text);
        //    stamp.AcroFields.SetField("M_INGRESO_OFENDIDO", txtIngresoMensualOfendido.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO_LABORAL_OFENDIDO", txtDomicilioLaboralDenuncianteOfendido.Text);
        //    stamp.AcroFields.SetField("M_TEL_MOVIL_OFENDIDO", LblTelMovilOfendido.Text);
        //    stamp.AcroFields.SetField("M_TEL_NOTI_OFENDIDO", LblTelNotificacionesOfendido.Text);
        //    stamp.AcroFields.SetField("M_ESCOLARIDAD_OFENDIDO", LblEsccolaridadOfendido.Text);
        //    stamp.AcroFields.SetField("M_EMAIL_OFENDIDO", LblEmailOfendido.Text);
        //    stamp.AcroFields.SetField("M_SEXO_OFENDIDO", LblSexoOfendido.Text);
        //    stamp.AcroFields.SetField("M_NACIMIENTO_OFENDIDO", LblFechaNacimientoOfendido.Text);
        //    stamp.AcroFields.SetField("M_ESTADO_CIVIL_OFENDIDO", LblEstadoCivilOfendido.Text);
        //    stamp.AcroFields.SetField("M_RELIGON_OFENDIDO", txtReligionOfendido.Text);
        //    stamp.AcroFields.SetField("M_CONYUGE_OFENDIDO", txtNombreConyugeOfendido.Text);
        //    stamp.AcroFields.SetField("M_ELECTOR_OFENDIDO", LblFolioElectorOfendido.Text);
        //    stamp.AcroFields.SetField("M_RFC_OFENDIDO", LblRFCOfendido.Text);
        //    stamp.AcroFields.SetField("M_CONDUCIR_OFENDIDO", LblLicenciaConducirOfendido.Text);
        //    stamp.AcroFields.SetField("M_PASAPORTE_OFENDIDO", LblPasaporteOfendido.Text);
        //    stamp.AcroFields.SetField("M_SEGURO_OFENDIDO", txtNumeroSocialOfendido.Text);
        //    stamp.AcroFields.SetField("M_CURP_OFENDIDO", LblCurpOfendido.Text);
        //    stamp.AcroFields.SetField("M_DATOS_OFENDIDO", txtDatosOfendido.Text);

        //    stamp.AcroFields.SetField("M_NARRACION", lblNarracion.Text);
        //    stamp.AcroFields.SetField("M_CALIFICACION", txtClasificacionInicial.Text);
        //    stamp.AcroFields.SetField("M_FUNDAMENTO", txtFundamento.Text);
        //    stamp.AcroFields.SetField("M_OTRAAUTO", txtAutoridad.Text);
        //    stamp.AcroFields.SetField("M_CONFLICTOS", txtConflictos.Text);
        //    stamp.AcroFields.SetField("M_OPORTUNIDAD", txtOportunidad.Text);
        //    stamp.AcroFields.SetField("M_OBSERVACIONES", txtObservaciones.Text);
        //    stamp.AcroFields.SetField("M_NOMBREAMP", LblNombreMP1.Text);
        //    stamp.AcroFields.SetField("M_NOMBREAMP_2", LblNombreMP1.Text);
        //    stamp.AcroFields.SetField("M_NUMEMPLE", LblNumeroEmpleado1.Text);

        //    stamp.FormFlattening = true;
        //    stamp.Close();
            
        //}
        //public void FillPDF_SOLICITAR_FOTOGRAFIA(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC14.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad16.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito12.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_CIUDADANO", txtCiudadano.Text);
        //    stamp.AcroFields.SetField("M_AGENTE", LblNombreMP13.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado8.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad11.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_SOLICITAR_PSICOLOGICO_MENOR(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC15.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad17.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito13.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio2.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_MENOR", txtNombreMenor.Text);
        //    stamp.AcroFields.SetField("M_DELITO_2", LblDelito13.Text);
        //    stamp.AcroFields.SetField("M_AGENTE", LblNombreMP14.Text);
        //    stamp.AcroFields.SetField("M_NUMERO", LblNumeroEmpleado8.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad17.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}
        //public void FillPDF_SOLICITAR_PSICOLOGICO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC16.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad18.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito14.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio3.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_CIUDADANO", txtCiudadano2.Text);
        //    stamp.AcroFields.SetField("M_DELITO_2", LblDelito14.Text);
        //    stamp.AcroFields.SetField("M_AGENTE", LblNombreMP15.Text);
        //    stamp.AcroFields.SetField("M_NUMERO", LblNumeroEmpleado8.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad17.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}
        //public void FillPDF_OFICIO_MEDIACION(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC17.Text);
        //    stamp.AcroFields.SetField("M_NUC_2", LblNUC17.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad19.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito15.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio4.Text);
        //    stamp.AcroFields.SetField("M_JEFE", txtJefeJusticia.Text);
        //    stamp.AcroFields.SetField("M_DENUNCIANTE", LblNombreDenunciante4.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido7.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP15.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}
        //public void FillPDF_OFICIO_INSTITUTO_VICTIMAS(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC18.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito16.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio5.Text);
        //    stamp.AcroFields.SetField("M_COMISIONADO", txtComisinado.Text);
        //    stamp.AcroFields.SetField("M_DENUNCIANTE", LblNombreDenunciante5.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido8.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP15.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO_2", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_ESTADO", LblEntidad.Text);
        //    stamp.AcroFields.SetField("M_VICTIMA", txtNombreVictima.Text);
        //    stamp.AcroFields.SetField("M_TELEFONO", txtTelefonoVictima.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO", txtDomicilioVictima.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_ACUERDO_INCOMPETENCIA(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC19.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD2", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio6.Text);
        //    stamp.AcroFields.SetField("M_FECHA_OFICIO", txtFechaOficio.Text);
        //    stamp.AcroFields.SetField("PERITO_QUIMICO", txtNombrePeritoQuimico.Text);
        //    stamp.AcroFields.SetField("M_DENUNCIANTE", txtNombrePeritoQuimico.Text);
        //    stamp.AcroFields.SetField("M_RESULTADOS", txtResultadoInforme.Text);

        //    stamp.AcroFields.SetField("M_CONCLUSIONES", txtConclusiones.Text);
        //    stamp.AcroFields.SetField("M_OCCISO", txtNombreOcciso.Text);
        //    stamp.AcroFields.SetField("M_HECHOS", LblLugarHechos5.Text);
        //    stamp.AcroFields.SetField("M_DISPOSICION", txtPuestoDisposicion.Text);
        //    stamp.AcroFields.SetField("M_VEHICULOS", txtVehiculos.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP16.Text);
        //    stamp.AcroFields.SetField("M_MP2", LblNombreMP16.Text);
        //    stamp.AcroFields.SetField("M_RECIDENCIA", txtResidencia.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_EXAMEN_DETENCION(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_HORAS", LblHoraActual1.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_JUEZ", txtJuezCalificador.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido9.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_1", LblNombreDetenido9.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_2", LblNombreDetenido9.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_3", LblNombreDetenido9.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_4", LblNombreDetenido9.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_5", LblNombreDetenido9.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_6", LblNombreDetenido9.Text);
        //    stamp.AcroFields.SetField("M_POLICIA", txtPoliciaDetencion.Text);
        //    stamp.AcroFields.SetField("M_POLICIA_1", txtPoliciaDetencion.Text);
        //    stamp.AcroFields.SetField("M_PARTE", txtParte.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido2.Text);

        //    stamp.AcroFields.SetField("M_HORA_PARTE", txtHoraParte.Text);
        //    stamp.AcroFields.SetField("M_HORA_RECIBIO_PARTE", txtHoraRecibeParte.Text);
        //    stamp.AcroFields.SetField("M_HECHOS", LblLugarHechos5.Text);
        //    stamp.AcroFields.SetField("M_DISPOSICION", txtPuestoDisposicion.Text);
        //    stamp.AcroFields.SetField("M_VEHICULOS", txtVehiculos.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP17.Text);
        //    stamp.AcroFields.SetField("M_MP2", LblNombreMP17.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_INEJERCICIO_PERDON(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC21.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito17.Text);
        //    stamp.AcroFields.SetField("M_DELITO_1", LblDelito17.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido10.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_1", LblNombreDetenido10.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_2", LblNombreDetenido10.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_3", LblNombreDetenido10.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido3.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_1", LblNombreOfendido3.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_2", LblNombreOfendido3.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_3", LblNombreOfendido3.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_4", LblNombreOfendido3.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_5", LblNombreOfendido3.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_6", LblNombreOfendido3.Text);

        //    stamp.AcroFields.SetField("M_ACTAS", txtActas.Text);
        //    stamp.AcroFields.SetField("M_FECHA_COMPARECENCIA", txtFechaComparecencia.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP18.Text);
        //    stamp.AcroFields.SetField("M_MP_2", LblNombreMP18.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_NOTIFICAR_INEJERCICIO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC22.Text);
        //    stamp.AcroFields.SetField("M_NUC_1", LblNUC22.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio7.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito18.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido11.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido4.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_2", LblNombreOfendido4.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_INCOMPETENCIA(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC23.Text);
        //    stamp.AcroFields.SetField("M_NUC_1", LblNUC23.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio8.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito19.Text);
        //    stamp.AcroFields.SetField("M_FOJAS", txtFojas.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido12.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido5.Text);
        //    stamp.AcroFields.SetField("M_LUGAR", LblLugarHechos6.Text);
        //    stamp.AcroFields.SetField("M_DISPOSICION", txtPuestoDisposicion1.Text);
        //    stamp.AcroFields.SetField("M_VEHICULOS", txtVehiculos1.Text);
        //    stamp.AcroFields.SetField("M_AGENTE_MP", txtAgenteMp.Text);
        //    stamp.AcroFields.SetField("M_RESIDENCIA", txtResidencia1.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_EVOLUTIVO_LESIONES(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC24.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio9.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito20.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_1", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_2", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_CIUDADANO", txtExaminarCiudadano.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);

        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado12.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}


        //public void FillPDF_OFICIO_EXORTO_IMPUTADO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC25.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio10.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito21.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido13.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO", lblDomicilioImputado1.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido6.Text);
        //    stamp.AcroFields.SetField("M_FECHA_CITA", txtFechaComparezca.Text);
        //    stamp.AcroFields.SetField("M_HORA_CITA", txtHoraComparezca.Text);
        //    stamp.AcroFields.SetField("M_RECABADA", txtRecabaSu.Text);
        //    stamp.AcroFields.SetField("M_MP_INVESTIGADOR", txtMpInvestigador.Text);
        //    stamp.AcroFields.SetField("M_RESIDENTE", txtMpResidente.Text);

        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);

        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado12.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_EXORTO_TESTIGO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC26.Text);
        //    stamp.AcroFields.SetField("M_NUC_2", LblNUC26.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio11.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito21.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_TESTIGO", LblNombreTestigo1.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO", LblDomicilioTestigo1.Text);
        //    stamp.AcroFields.SetField("M_FECHA_CITA", txtFechaComparezca1.Text);
        //    stamp.AcroFields.SetField("M_HORA_CITA", txtHoraComparezca1.Text);
        //    stamp.AcroFields.SetField("M_MP_INVESTIGADOR", txtMpInvestigador1.Text);
        //    stamp.AcroFields.SetField("M_RESIDENTE", txtMpResidente1.Text);

        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);

        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado12.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_ACUERDO_ABSTENERSE_INVESTIGAR(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC27.Text);
        //    stamp.AcroFields.SetField("FECHA_NUC", lblFechaNuc1.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito23.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido7.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_2", LblNombreOfendido7.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_3", LblNombreOfendido7.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_4", LblNombreOfendido7.Text);
        //    stamp.AcroFields.SetField("M_FECHA_HECHOS_1", LblFechaLugarHechos2.Text);
        //    stamp.AcroFields.SetField("M_LUGAR_HECHOS", LblLugarHechos7.Text);
        //    stamp.AcroFields.SetField("M_LUGAR_HECHOS_1", LblLugarHechos7.Text);
        //    stamp.AcroFields.SetField("M_LUGAR_HECHOS_2", LblLugarHechos7.Text);
        //    stamp.AcroFields.SetField("M_MOTIVO", txtDescribirActas.Text);
        //    stamp.AcroFields.SetField("M_NUMERO_PARTE", txtNumeroParte3.Text);
        //    stamp.AcroFields.SetField("M_CONCLUSIONES", txtConclucionPerito.Text);
        //    stamp.AcroFields.SetField("M_NUMERO_INFORME", txtOficioInforme.Text);
        //    stamp.AcroFields.SetField("M_FECHA_INFORME", txtFechaInforme.Text);
        //    stamp.AcroFields.SetField("M_PERITO", txtSignadoPerito.Text);
        //    stamp.AcroFields.SetField("M_CAUSAS_DETERMINANTES", txtCausasDeterminantes.Text);
        //    stamp.AcroFields.SetField("M_COINCIDENTE", txtInformeCoincidente.Text);
        //    stamp.AcroFields.SetField("M_OFICIO_EMITIDO", txtOficioEmitido.Text);
        //    stamp.AcroFields.SetField("M_VEHICULO", txtVehiculos4.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MP2", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_ACUERDO_ABSTENERSE_INVESTIGAR(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC28.Text);
        //    stamp.AcroFields.SetField("M_NUC_2", LblNUC28.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito24.Text);
        //    stamp.AcroFields.SetField("M_FECHA_ACUERDO", txtFechaAcuerdo.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido8.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_1", LblNombreOfendido8.Text);
        //    stamp.AcroFields.SetField("M_DOMICILIO", LblDomicilioOfendido1.Text);
        //    stamp.AcroFields.SetField("M_FECHA_HECHOS", LblFechaLugarHechos3.Text);
        //    stamp.AcroFields.SetField("M_LUGAR_HECHOS", LblLugarHechos8.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido14.Text);

        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_OFICIO_ENTREGA_CUERPO(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC29.Text);
        //    stamp.AcroFields.SetField("M_OFICIO", txtNumeroOficio12.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD_1", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_DIR_PERICIALES", lblDir.Text);
        //    stamp.AcroFields.SetField("M_OCCISO", txtNombreOcciso1.Text);
        //    stamp.AcroFields.SetField("M_FORENSE", txtFechaSemefo.Text);
        //    stamp.AcroFields.SetField("M_FECHA_HECHOS", LblFechaLugarHechos4.Text);
        //    stamp.AcroFields.SetField("M_LUGAR_HECHOS", LblLugarHechos9.Text);
        //    stamp.AcroFields.SetField("M_ENTREGA", txtEnregaCuerpo.Text);
        //    stamp.AcroFields.SetField("M_AGENTE", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_EMPLEADO", LblNumeroEmpleado12.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}

        //public void FillPDF_ARCHIVO_TEMPORAL(string template, Stream stream)
        //{
        //    PdfReader reader = new PdfReader(template);
        //    PdfStamper stamp = new PdfStamper(reader, stream);

        //    stamp.AcroFields.SetField("M_NUC", LblNUC30.Text);
        //    stamp.AcroFields.SetField("M_NUC_1", LblNUC30.Text);
        //    stamp.AcroFields.SetField("M_DELITO", LblDelito25.Text);
        //    stamp.AcroFields.SetField("M_DELITO_1", LblDelito25.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO", LblNombreOfendido9.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_1", LblNombreOfendido9.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_2", LblNombreOfendido9.Text);
        //    stamp.AcroFields.SetField("M_OFENDIDO_3", LblNombreOfendido9.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO", LblNombreDetenido15.Text);
        //    stamp.AcroFields.SetField("M_IMPUTADO_1", LblNombreDetenido15.Text);
        //    stamp.AcroFields.SetField("M_FECHA_NUC", lblFechaNuc.Text);
        //    stamp.AcroFields.SetField("M_MOTIVO", txtActas2.Text);
        //    stamp.AcroFields.SetField("M_INICIO", txtNucInicioPor.Text);
        //    stamp.AcroFields.SetField("M_ARCHIVANDO_CARPETA", txtArchivarCarpeta.Text);
        //    stamp.AcroFields.SetField("M_MP", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_MP_1", LblNombreMP19.Text);
        //    stamp.AcroFields.SetField("M_UNIDAD", LblUnidad20.Text);
        //    stamp.AcroFields.SetField("M_MUNICIPIO", LblCiudad.Text);
        //    stamp.AcroFields.SetField("M_DIA", LblDia6.Text);
        //    stamp.AcroFields.SetField("M_MES", LblMes6.Text);
        //    stamp.AcroFields.SetField("M_AÑO", LblAño6.Text);
        //    stamp.FormFlattening = true;
        //    stamp.Close();
        //}
        //#endregion


        //#region MetodosCarga
        //void MetodosCarga()
        //{
        //    MarcadorPeritoQuimico();
        //    MarcadorActaDenuncia();
        //    cargarDatosEmpresa();
        //    MacadorActaDerechosVictima();
        //    MarcadorAcuerdoInicio();
        //    MarcadorDeclaracionImputado();
        //    MarcadorDeclaracionTestimonial();
        //    MarcadorOficioHechosTransito();
        //    MarcadorOficioExploracionDetenido();
        //    MarcadorOficioInformeGenetica();
        //    MarcadorOficioInformeLesionado();
        //    MarcadorOficioValuadorFoto();
        //    MarcadorOrdenContinuacionPM();
        //    MarcadorOrdenInvestigacionPM();
        //    MarcadorOficioSolicitarFotografia();
        //    MarcadorOficioInformePsicologicoMenor();
        //    MarcadorOficioInformePsicologico();
        //    MarcadorOficioIncompetencia();
        //    MarcadorOficioEntregaCuerpo();
        //    MarcadorInejercicioPerdon();
        //    MarcadorOficioNotificarInejercicio();
        //    MarcadorOficioEvolutivoLesiones();
        //    MarcadorAucerdoAbstenerse();

        //    MarcadorArchivoTemporal();
        //    MarcadorExortoTestigo();
        //    MarcadorExamenDetencion();
        //    MarcadorExortoImputado();
        //    MarcadorAucerdoIncompetencia();
        //    MarcadorOficioMediacion();
        //    MarcadorOficioInstitutoVictimas();
        //    MarcadorNotificarAcuerdoAbstenerse();
        //}
        //#endregion

        //#region OcultarPanel
        //void ocultarPanel()
        //{
        //    Panel2.Visible = false;
        //    Panel3.Visible = false;
        //    Panel4.Visible = false;
        //    Panel5.Visible = false;
        //    Panel6.Visible = false;
        //    Panel7.Visible = false;
        //    Panel8.Visible = false;
        //    Panel9.Visible = false;
        //    Panel10.Visible = false;
        //    Panel1.Visible = false;
        //    Panel11.Visible = false;
        //    Panel12.Visible = false;
        //    Panel13.Visible = false;
        //    Panel14.Visible = false;
        //    Panel15.Visible = false;
        //    Panel16.Visible = false;
        //    Panel17.Visible = false;
        //    Panel18.Visible = false;
        //    Panel19.Visible = false;
        //    Panel20.Visible = false;
        //    Panel21.Visible = false;
        //    Panel22.Visible = false;
        //    Panel23.Visible = false;
        //    Panel24.Visible = false;
        //    Panel25.Visible = false;
        //    Panel26.Visible = false;
        //    Panel27.Visible = false;
        //    Panel28.Visible = false;
        //    Panel35.Visible = false;
        //    Panel36.Visible = false;
        //    Panel37.Visible = false;
        //    Panel38.Visible = false;
        //}
        //#endregion


        //#region ddlPlantilla2
        //void ddlPlanel()
        //{

        //    if (ddlPlantilla.SelectedValue == "0")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        cmdGeneraPdf.Visible = false;
        //    }
        //    if (ddlPlantilla.SelectedValue == "1")
        //    {
        //        Panel2.Visible = true;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "2")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = true;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "3")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = true;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "4")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = true;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "5")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = true;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "6")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = true;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "7")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = true;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "8")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = true;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "9")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = true;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel38.Visible = false;
        //        Panel37.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "10")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = true;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "11")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = true;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "12")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = true;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "13")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = true;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "14")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = true;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "15")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = true;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "16")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = true;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "17")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = true;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "18")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = true;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "19")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = true;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "20")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = true;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "21")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = true;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "22")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = true;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel38.Visible = false;
        //        Panel37.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "23")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = true;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "24")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = true;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "25")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = true;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "26")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = true;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "27")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = true;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "28")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = true;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "29")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = true;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "30")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = true;
        //        Panel37.Visible = false;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    }
        //    if (ddlPlantilla.SelectedValue == "31")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = true;
        //        Panel38.Visible = false;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = true;
        //    } if (ddlPlantilla.SelectedValue == "32")
        //    {
        //        Panel2.Visible = false;
        //        Panel3.Visible = false;
        //        Panel4.Visible = false;
        //        Panel5.Visible = false;
        //        Panel6.Visible = false;
        //        Panel7.Visible = false;
        //        Panel8.Visible = false;
        //        Panel9.Visible = false;
        //        Panel10.Visible = false;
        //        Panel1.Visible = false;
        //        Panel11.Visible = false;
        //        Panel12.Visible = false;
        //        Panel13.Visible = false;
        //        Panel14.Visible = false;
        //        Panel15.Visible = false;
        //        Panel16.Visible = false;
        //        Panel17.Visible = false;
        //        Panel18.Visible = false;
        //        Panel19.Visible = false;
        //        Panel20.Visible = false;
        //        Panel21.Visible = false;
        //        Panel22.Visible = false;
        //        Panel23.Visible = false;
        //        Panel24.Visible = false;
        //        Panel25.Visible = false;
        //        Panel26.Visible = false;
        //        Panel27.Visible = false;
        //        Panel28.Visible = false;
        //        Panel35.Visible = false;
        //        Panel36.Visible = false;
        //        Panel37.Visible = false;
        //        Panel38.Visible = true;
        //        MetodosCarga();
        //        cmdGeneraPdf.Visible = false;
        //    }
        //}
        //#endregion

    

      

    }




}