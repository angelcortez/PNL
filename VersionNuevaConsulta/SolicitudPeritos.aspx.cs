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
    public partial class SolicitudPeritos : System.Web.UI.Page
    {

        Data PGJ = new Data();
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.docx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                lblIdUsuario.Text = Session["IdUsuario"].ToString();
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                IdOrden.Text = Session["ID_ORDEN"].ToString();

                

                Label332.Visible = false;
                FileUpload1.Visible = false;
                cmdGuardar.Visible = false;
            }

        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {

            //Ejecutar un Data Source desde un boton 
            gvServicios.DataSourceID = "dsBuscarServicio";
            gvServicios.DataBind();  //Refresca los datos del GridView



        }

        protected void gvServicios_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void cmdAsignarPI_Click(object sender, EventArgs e)
        {
            string ids = "";
            int i = 1, ban = 0;

            int k = 1;

            //Recorrer los Checbox de las filas del GridView
            foreach (GridViewRow row in gvServicios.Rows)
            {

                CheckBox check = row.FindControl("cbxServicio") as CheckBox;
                TextBox txtDesc = row.FindControl("txtDescripcion") as TextBox;

                if (check != null && check.Checked)
                {
                    if (txtDesc != null && txtDesc.Text != "")
                    {
                        if ((i % 2) == 0)
                        {
                            row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF"); //Color Blanco de la filas
                        }
                        else
                        {
                            row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#CCFFCC"); //Color Verde de la filas
                        }

                        //Ingresar Temporalmente la informacion en una tabla
                        PGJ.SolicitarPeritoTemp(Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(row.Cells[2].Text), txtDesc.Text.ToUpper(), Convert.ToInt32(lblIdUsuario.Text));

                        //ids += "--" + IdCarpeta.Text + "--" + row.Cells[2].Text + "--" + txtDesc.Text;
                        ban = 1;

                    }
                    else
                    {
                        //Colocar Alerta 
                        string script = @"<script type='text/javascript'>
                            alert('ES NECESARIO INGRESAR UNA DESCRIPCIÓN DEL SERVICIO');
                                   </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                        row.Cells[4].BackColor = System.Drawing.Color.OrangeRed;
                        cmdGuardar.Visible = false;
                        i = 1;
                        ban = 0;
                        break;
                    }
                }
                i++;
            }
            //IdCbx.Text = ids;

            lblEstatus.Text = ban.ToString();

            if (ban == 1)
            {
                try
                {

                    FileUpload1.Visible = true;
                    cmdGuardar.Visible = true;
                    Session["ID_PLANTILLA"] = 63;
                    Archivos.IdPlantilla = int.Parse(Session["ID_PLANTILLA"].ToString());
                    LeerDeBD();

                    Label332.Visible = true;
                    FileUpload1.Visible = true;

                }
                catch (Exception ex)
                {
                    lblEstatus.Text = ex.Message;
                    cerrarWord();
                }
            }
            


        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            string ids = "";
            string[] ID_CARPETA = new string[50];
            string[] ID_SERVICIO = new string[50];
            string[] ESPECIFICACIONES = new string[50];
            string[] ID_USUARIO = new string[50];
            int i = 0;
            string ID_OFICIO = "";


            //Subir Archivo
            if (FileUpload1.HasFile)
            {
               // Label3.Text = "ARCHIVO PDF SELECCIONADO";

                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Archivos.InsertarSolPeritoPDF(int.Parse(IdCarpeta.Text), Pdf, "SOLICITUD DE SERVICIO PERICIAL", 63, 0, 0, 0, 0, 0, short.Parse(lblIdUsuario.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(IdUnidad.Text));
                }


                

                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SelecSolicPeritoTemp " + IdCarpeta.Text + "," + lblIdUsuario.Text, Data.CnnCentral);
                SqlDataReader dr = comm.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ID_CARPETA[i] = dr["ID_CARPETA"].ToString();
                        ID_SERVICIO[i] = dr["ID_SERVICIO"].ToString();
                        ESPECIFICACIONES[i] = dr["ESPECIFICACIONES"].ToString();
                        ID_USUARIO[i] = dr["ID_USUARIO"].ToString();

                       // ids += "--" + ID_CARPETA[i] + "--" + ID_SERVICIO[i] + "--" + ESPECIFICACIONES[i] + "--" + ID_USUARIO[i];
                        i++;
                    }
                    dr.Close();
                }


                //Seleccionamos el ID_OFICIO del archivo PDF recien guardado 
                PGJ.ConnectServer();
                SqlCommand comm1 = new SqlCommand("SELECT MAX(ID_PDF) AS ID_OFICIO_SOLICITUD FROM PGJ_PDF_POLICIA WHERE  ID_CARPETA =" + IdCarpeta.Text + " AND ID_PLANTILLA = 63", Data.CnnCentral);
                SqlDataReader dr1 = comm1.ExecuteReader();

                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        ID_OFICIO = dr1["ID_OFICIO_SOLICITUD"].ToString();
                    }
                    dr1.Close();
                }



                for (int j = 0; j < i; j++)
                {
                    //Insertar en la tabla Solicitar Perito                                                                                                                                  
                    PGJ.SolicitarPerito(Convert.ToInt32(ID_CARPETA[j]), Convert.ToInt32(IdUnidad.Text), Convert.ToInt32(ID_USUARIO[j]), Convert.ToInt32(ID_SERVICIO[j]), ESPECIFICACIONES[j], Convert.ToInt32(ID_OFICIO));

                    //Eliminar las Solicitudes Temporales
                    PGJ.EliminarSolicitudTemporal(Convert.ToInt32(ID_CARPETA[j]), Convert.ToInt32(ID_USUARIO[j]));
                }

                //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
                PGJ.ModificarEstadoOrden_PI(Convert.ToInt32(IdOrden.Text), 3);
                PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

                //INSERTAMOS LA BITACORA DEL SISTEMA
                PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Se realizo la solicitud de Peritos de la Carpeta  " + IdCarpeta.Text);
                
                
                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                            alert('LA SOLICITUD DE PERITOS HA SIDO ENVIADA CORRECTAMENTE.');
                                   </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                gvServicios.DataSourceID = "dsMostrarServicio";
                gvServicios.DataBind();  //Refresca los datos del GridView
                

               // Label3.Text = ids;
            }
            else
            {
                Label3.Text = " *SELECCIONE UN ARCHIVO PDF";
            }

            

        }

        protected void IBOrden_Click(object sender, ImageClickEventArgs e)
        {
            //Eliminar las Solicitudes Temporales
            PGJ.EliminarSolicitudTemporal(Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(lblIdUsuario.Text));

            Response.Redirect("OrdenPoliciaInvestigador.aspx");
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
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdCarpeta.Text;
                    }
                    /*if (drParametros["Parametro"].ToString() == "@IdDenunciante")
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


    }
}