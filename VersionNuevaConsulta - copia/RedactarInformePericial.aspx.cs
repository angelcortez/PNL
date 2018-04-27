using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;

namespace AtencionTemprana
{
    public partial class RedactarInformePericial : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs;
        private Microsoft.Office.Interop.Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.docx";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                IDtIPOuNIDAD.Text = Session["ID_UNDD_TPO"].ToString();
                IdSP.Text = Session["ID_SP"].ToString();

                //cargarImputado();
                //cargarOfendido();

                //Seleccionamos el texto almacenado en el Informe para comenzar
                //a modificar  
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("ConsultaDictamenPericiales " + IdSP.Text + "," + IdUsuario.Text, Data.CnnCentral);
                SqlDataReader dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtPeritajeSol.Text = dr["PERITAJE SOLICITADO"].ToString();
                        txtDpto.Text = dr["DEPARTAMENTO"].ToString();
                        txtEspeSP.Text = dr["ESPECIFICACIONES"].ToString();
                        txtAsigS.Text = dr["ASIGNADO"].ToString();
                        txtsolSP.Text = dr["SOLICITADO EL"].ToString();
                        txtasigEl.Text = dr["ASIGNADO EL"].ToString();
                        txtiniSp.Text = dr["INICIADO EL"].ToString();
                        txtterminadoel.Text = dr["TERMINADO EL"].ToString();
                        txtDictamen.Text = dr["DICTAMEN"].ToString();
                    }
                    dr.Close();
                }

                Label332.Visible = false;
                FileUpload1.Visible = false;
                cmdGuardar.Visible = false;
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

        /*
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
        */

        protected void cmdElaborarInforme_Click(object sender, EventArgs e)
        {

            tbl_informe.Visible = false;

            try
            {
                Session["ID_PLANTILLA"] = 104;
                Archivos.IdPlantilla = int.Parse(Session["ID_PLANTILLA"].ToString());
                LeerDeBD();
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                cerrarWord();
            }

            Label332.Visible = true;
            FileUpload1.Visible = true;
            cmdGuardar.Visible = true;
        }


        public void cmdGuardar_Click(object sender, EventArgs e)
        {

            //Subir Archivo
            if (FileUpload1.HasFile)
            {

                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Archivos.InsertaDocPeritosPDF(int.Parse(IdSP.Text), int.Parse(IdCarpeta.Text), Pdf, "DICTAMEN", 104, short.Parse(Session["IdMunicipio"].ToString()),short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdUnidad"].ToString()));
                    
                    Label332.Visible = false;
                    FileUpload1.Visible = false;
                    cmdGuardar.Visible = false;

                    tbl_informe.Visible = true;

                    //Colocar Alerta 
                    string script = @"<script type='text/javascript'>
                            alert('EL ARCHIVO HA SIDO GUARDADO CORRECTAMENTE');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }

                //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
              //  PGJ.ModificarEstadoOrden_PI(Convert.ToInt32(IdOrden.Text), 4);
                //PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

            }
            else
            {
                Label3.Text = " *SELECCIONE UN ARCHIVO PDF";
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
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
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
                Documento = wordApp.Documents["tmp.doc"] as Microsoft.Office.Interop.Word.Document;
                Documento.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdSaveChanges);
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

            foreach (DataRow drParametros in dsParametros.Tables["Parametros"].Rows)
            {
                if (drParametros["Parametro"].ToString() != "NULO")
                {

                    if (drParametros["Parametro"].ToString() == "@IdCarpeta")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdCarpeta.Text;
                    }

                    //if (drParametros["Parametro"].ToString() == "@IdOrden")
                    //{
                    //    cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                    //    cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdSP.Text;
                    //}
                    /*
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
                    */

                    if (drParametros["Parametro"].ToString() == "@IdSolicitud")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdSP.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@IdUsuario")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdUsuario.Text;
                    }
                    /*
                     if (drParametros["Parametro"].ToString() == "@IdMunicipio")
                     {
                         cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                         cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdMunicipio.Text;
                     }
                    
                     if (drParametros["Parametro"].ToString() == "@Fecha")
                     {
                         cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.DateTime);
                         cmd.Parameters[drParametros["Parametro"].ToString()].Value = Convert.ToDateTime(lblFecha.Text);
                     }*/

                }

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





        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrdenPerito.aspx");
        }

        protected void cmdInforme_Click(object sender, EventArgs e)
        {
            if (txtDictamen.Text != "")
            {
                //INSERTAMOS EL INFORME 
               PGJ.InsertarDictamenPericiales(Convert.ToInt32(IdSP.Text), Convert.ToInt32(IdUsuario.Text), txtDictamen.Text.ToUpper());
               // PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

                //Seleccionamos el texto almacenado en el Informe para comenzar
                //a modificar  
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("ConsultaDictamenPericiales " + IdSP.Text + "," + IdUsuario.Text, Data.CnnCentral);
                SqlDataReader dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtDictamen.Text = dr["DICTAMEN"].ToString();
                    }
                    dr.Close();
                }

                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                                        alert('INFORME GUARDADO CORRECTAMENTE');
                                               </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }






        }

        protected void gvAnexos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void cmdAnexos_Click(object sender, EventArgs e)
        {
            ////Recorrer los Checbox de las filas del GridView
            //foreach (GridViewRow row in gvAnexos.Rows)
            //{
            //    CheckBox check = row.FindControl("ckboxPI") as CheckBox;
            //    if (check != null && check.Checked)
            //    {
            //       // PGJ.InsertarAnexo(Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(row.Cells[1].Text));

            //    }
            //}

        }




    }
}