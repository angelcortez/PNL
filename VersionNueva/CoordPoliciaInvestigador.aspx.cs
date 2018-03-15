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
using System.Net;


namespace AtencionTemprana
{
    public partial class OrdenInvestigacion : System.Web.UI.Page
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
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();

                Session["ID_ORDEN_TEMP"] = "";
                Session["ID_USUARIO_TEMP"] = ""; 

                //IDtIPOuNIDAD.Text = Session["ID_UNDD_TPO"].ToString();

                Session["ID_UNIDAD"] = Request.QueryString["ID_UNIDAD"];

                if (Request.QueryString["ID_ORDEN"] != "")
                {
                    IdOrden.Text = Request.QueryString["ID_ORDEN"];
                }
                if (Request.QueryString["NUC"] != "")
                {
                    lblNucPI.Text = Request.QueryString["NUC"];
                }
                if (Request.QueryString["ID_CARPETA"] != "")
                {
                    Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                    lblIdCarpeta.Text = Request.QueryString["ID_CARPETA"];
                }

                //Para Cagar Documentos
                Session["op"] = Request.QueryString["op"];
                Session["IdDoc"] = Request.QueryString["IdDoc"];
                if (Session["IdDoc"] == null)
                {
                    Session["IdDoc"] = "0";
                }
                if (Session["op"] == null)
                {
                    Session["op"] = "0";
                }

                if (Session["op"].ToString() == "Docs")
                {
                    CargarDocumento(Session["IdDoc"].ToString());
                }

                //Ocultar tablas de Asignar 
                tbl_asignarPI.Visible = false;
                tbl_verPI.Visible = false;

                if (Request.QueryString["btnAsignar"] == "1")
                {
                    Session["ASIGNADA"] = Request.QueryString["ASIGNADA"];
                    tbl_asignarPI.Visible = true;
                    tbl_verPI.Visible = false;
                }
                else if (Request.QueryString["btnVer"] == "1")
                {
                    tbl_asignarPI.Visible = false;
                    tbl_verPI.Visible = true;
                }


                PGJ.CargaCombo(ddlTipoOrden, "CAT_TIPO_ORDEN", "IdTipoOrden", "TipoOrden");

                //Obtenemos la URL de la pagina aspx
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                Session["PAGINA"] = path;

                // tenemos el nombre del equipo cliente
                string name = System.Net.Dns.GetHostName();
                Session["NOM_MAQUINA"] = name;

                IPAddress hostIPAddress1 = (Dns.Resolve(name)).AddressList[0];

                //string ip = System.Net.Dns.GetHostAddresses(name)[0].ToString();

                //Obtenemos la IP del CLIENTE 
                Session["IP_SERVER"] = hostIPAddress1.ToString();  //Request.ServerVariables["LOCAL_ADDR"];


                //Label2.Text = Session["USUARIO"].ToString() + "  " + Session["IP_SERVER"].ToString() + "  " + Session["NOM_MAQUINA"].ToString() + "  " + Session["PAGINA"].ToString() + "  " + "INICIO DE SESIÓN";

                PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), Session["PAGINA"].ToString(), "INICIO DE SESIÓN");


                Label332.Visible = false;
                FileUpload1.Visible = false;
                cmdGuardar.Visible = false;
            }
        }

        private void CargarDocumento(string ID_PDF)
        {
            byte[] bits;
            try
            {
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SELECT * from PGJ_PDF_POLICIA  WHERE ID_PDF = " + ID_PDF, Data.CnnCentral);
                comm.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet("Binarios");
                da.Fill(ds);
                //Creamos un array de bytes que contiene los bytes almacenados
                //en el campo Documento de la tabla
                bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[2]));
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
            catch (Exception ex)
            {
                //Mensajes mje = new Mensajes();
                //mje.alert(ex.Message);
                string script = @"<script type='text/javascript'>
                            alert('NO EXISTE DOCUMENTO');
                                   </script>";
                //script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

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

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvNuc.DataSourceID = "dsConsultaOrden";
                gvNuc.DataBind();
                gvNuc.Visible = true;

                lblNuc.Visible = false;
                txtNuc.Visible = false;

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                tbl_asignarPI.Visible = false;
                tbl_verPI.Visible = false;

                btnMostrar.Visible = false;

                cmdAceptar.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                lblNuc.Visible = true;
                txtNuc.Visible = true;

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                tbl_asignarPI.Visible = false;
                tbl_verPI.Visible = false;

                cmdAceptar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                lblNuc.Visible = false;
                txtNuc.Visible = false;

                lblTipo.Visible = true;
                ddlTipoOrden.Visible = true;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                gvAsignarPI.Visible = false;
                gvConsultarPI.Visible = false;

                cmdAceptar.Visible = true;
            }

            if (ddlBuscar.SelectedValue == "3")
            {
                lblNuc.Visible = false;
                txtNuc.Visible = false;

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = true;
                txtFechaInicioOrden.Visible = true;
                lblFechaFinOrden.Visible = true;
                txtFechaFinOrden.Visible = true;

                tbl_asignarPI.Visible = false;
                tbl_verPI.Visible = false;

                cmdAceptar.Visible = true;
            }  
        }

        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvNuc.DataSourceID = "dsBusNuc";
                gvNuc.DataBind();

                tbl_asignarPI.Visible = false;
                tbl_verPI.Visible = false;
                btnMostrar.Visible = true;

            }
            if (ddlBuscar.SelectedValue == "2")
            {
                gvNuc.DataSourceID = "dsBuscarTipoOrdenPI";
                gvNuc.DataBind();

                tbl_asignarPI.Visible = false;
                tbl_verPI.Visible = false;
                btnMostrar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                gvNuc.DataSourceID = "dsBuscarFechaInicioOrdenPI";
                gvNuc.DataBind();

                tbl_asignarPI.Visible = false;
                tbl_verPI.Visible = false;
                btnMostrar.Visible = true;
            }
            
        }

        protected void cmdAsignarPI_Click(object sender, EventArgs e)
        {
            tbl_asignarPI.Visible = true;
        }

        protected void cmdVerPI_Click(object sender, EventArgs e)
        {
            tbl_verPI.Visible = true;
        }

        protected void gvNuc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ( (Convert.ToInt32(e.Row.Cells[7].Text) >= 0 ) && (Convert.ToInt32(e.Row.Cells[7].Text) <= 7 ) )
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Green; ;
                }
                if ((Convert.ToInt32(e.Row.Cells[7].Text) >= 8) && (Convert.ToInt32(e.Row.Cells[7].Text) <= 15))
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.DodgerBlue;
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.DodgerBlue;
                }
                if ((Convert.ToInt32(e.Row.Cells[7].Text) > 15) )
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                }
                if ( e.Row.Cells[8].Text == "CUMPLIDA")
                {
                    e.Row.Cells[9].Text = "";
                    e.Row.Cells[10].Visible = true;
                }
            }

        }

        protected void gvAsignarPI_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvConsultarPI_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //ID ASIGNACION
                if (e.Row.Cells[4].Text == "0")
                {
                    e.Row.Cells[0].Text = "";
                }
                //ID INFORME
                if (e.Row.Cells[5].Text == "0")
                {
                    e.Row.Cells[1].Text = "";
                }
                //ESTADO DE LA ORDEN
                if (e.Row.Cells[8].Text == "CUMPLIDA")
                {
                    e.Row.Cells[10].Text = "";
                }
            }


        }

        protected void cmdAsignar_Click(object sender, EventArgs e)
        {
            //Recorrer los Checbox de las filas del GridView
            foreach (GridViewRow row in gvAsignarPI.Rows)
            {
                CheckBox check = row.FindControl("ckboxPI") as CheckBox;
                if (check != null && check.Checked)
                {

                    Session["ID_ORDEN_TEMP"] = IdOrden.Text;
                    Session["ID_USUARIO_TEMP"] = row.Cells[1].Text;

                    PGJ.AsignarOrden_PI_TEMP(Convert.ToInt32(IdOrden.Text), Convert.ToInt32(row.Cells[1].Text));

                    try
                    {
                        Session["ID_PLANTILLA"] = 61;
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
            }

            gvNuc.DataSourceID = "dsConsultaOrden";
            gvNuc.DataBind();
 
        }

        public void cmdGuardar_Click(object sender, EventArgs e) 
        {

            

            
            string ID_OFICIO = "";

            //Variables para asignar Orden a Policia
            string IdOr = "";
            string IdUser = "";

            

            //Subir Archivo
            if (FileUpload1.HasFile)
            {

                    //Seleccionamos los valores guardados temporalmente para 
                    //para guardarlos en la tabla principal
                    PGJ.ConnectServer();
                    SqlCommand comm = new SqlCommand("SELECT * FROM PGJ_ORDEN_ASIGNADA_PI_TEMP WHERE ID_ORDEN = " + IdOrden.Text, Data.CnnCentral);
                    SqlDataReader dr = comm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            IdOr = dr["ID_ORDEN"].ToString();
                            IdUser = dr["ID_USUARIO"].ToString();
                        }
                        dr.Close();
                    }

                    using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                    {
                        byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                        Archivos.InsertaPoliciaPDF(int.Parse(lblIdCarpeta.Text), Pdf, "ASIGNAR ORDEN A POLICIA INVESTIGADOR", 61, 0, 0, 0, 0, 0, short.Parse(IdUser), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));
                    }

                    
                    //Seleccionamos el ID_OFICIO del archivo PDF recien guardado 
                    PGJ.ConnectServer();
                    SqlCommand comm1 = new SqlCommand("SELECT MAX(ID_PDF) AS ID_OFICIO_SOLICITUD FROM PGJ_PDF_POLICIA WHERE  ID_CARPETA =" + lblIdCarpeta.Text + " AND ID_PLANTILLA = 61", Data.CnnCentral);
                    SqlDataReader dr1 = comm1.ExecuteReader();

                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            ID_OFICIO = dr1["ID_OFICIO_SOLICITUD"].ToString();
                        }
                        dr1.Close();
                    }

                    //Insertar en la tabla ASIGNAR ORDEN PI                                                                                                                                 
                    PGJ.AsignarOrden_PI(Convert.ToInt32(IdOr), Convert.ToInt32(IdUser), Convert.ToInt32(ID_OFICIO));
                    PGJ.ModificarEstadoOrden_PI(Convert.ToInt32(IdOrden.Text),2);
                    
                
                    //Eliminar las Ordenes Temporales
                    PGJ.EliminarOrdenTemporal(Convert.ToInt32(IdOr), Convert.ToInt32(IdUser));

                    //INSERTAMOS LA BITACORA DEL SISTEMA
                    PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Asignación de Policias Investigadores a la orden" + IdOr);


                    gvNuc.DataSourceID = "dsConsultaOrden";
                    gvNuc.DataBind();

                    gvAsignarPI.DataSourceID = "dsCargaTrabajo";
                    gvAsignarPI.DataBind();


                    //Colocar Alerta 
                    string script = @"<script type='text/javascript'>
                            alert('LA ORDEN HA SIDO ASIGNADA CORRECTAMENTE.');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }
            else 
            {
                Label3.Text = " *SELECCIONE UN ARCHIVO PDF";
            }


           

            Label332.Visible = false;
            FileUpload1.Visible = false;
            cmdGuardar.Visible = false;
        
        }

        public void ImageButton_Command(object sender, CommandEventArgs e)
        {

            string IdDocumento = "";

            //Seleccionamos el ID del OFICIO DE ASIGNACION DEL POLICIA para eliminarlo de la tabla  PG_
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT ID_OFICIO_SOLICITUD FROM PGJ_ORDEN_ASIGNADA_PI WHERE ID_ORDEN_PI = " + IdOrden.Text + "AND ID_USUARIO = " + e.CommandArgument.ToString(), Data.CnnCentral);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    IdDocumento = dr["ID_OFICIO_SOLICITUD"].ToString();
                }
                dr.Close();
            }

            //INSERTAMOS LA BITACORA DEL SISTEMA
            PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Eliminación del Policias con ID" + e.CommandArgument.ToString() + " de la orden" + IdOrden.Text);

            //Eliminación del oficio de Asignación del Policia que se eliminara de la Orden Asignada
            PGJ.EliminarDocumentoAsignacionPI(Convert.ToInt32(IdDocumento));


            PGJ.EliminarPI_OrdenAsignada(Convert.ToInt32(IdOrden.Text), Convert.ToInt32(e.CommandArgument.ToString()));
            gvConsultarPI.DataSourceID = "dsVerPolicia";
            gvConsultarPI.DataBind();
            
        }

        protected void btnEnviada_Click(object sender, EventArgs e)
        {

            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Enviada";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnAsignada_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Asignada";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnProceso_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Proceso";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnCumplida_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Cumplida";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnConcluida_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Concluida";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsConsultaOrden";
            gvNuc.DataBind();

            lblBuscar.Visible = true;
            ddlBuscar.Visible = true;
            btnMostrar.Visible = false;
            
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

            foreach (DataRow drParametros in dsParametros.Tables["Parametros"].Rows)
            {
                if (drParametros["Parametro"].ToString() != "NULO")
                {
                    
                    if (drParametros["Parametro"].ToString() == "@IdCarpeta")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = lblIdCarpeta.Text;
                    }
                    /*
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
                    if (drParametros["Parametro"].ToString() == "@IdUsuarioPI")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = Convert.ToInt32(Session["ID_USUARIO_TEMP"].ToString());
                    }
                    if (drParametros["Parametro"].ToString() == "@IdUsuario")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdUsuario.Text;
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

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["ID_ORDEN_TEMP"].ToString() != "" && Session["ID_USUARIO_TEMP"].ToString() != "")
            {
                PGJ.EliminarOrdenTemporal(Convert.ToInt32(Session["ID_ORDEN_TEMP"].ToString()), Convert.ToInt32(Session["ID_USUARIO_TEMP"].ToString()));
            }
            Response.Redirect("CoordPoliciaInvestigador.aspx");
        }

        protected void ImageMisOrdenes_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["ID_ORDEN_TEMP"].ToString() != "" && Session["ID_USUARIO_TEMP"].ToString() != "")
            {
                PGJ.EliminarOrdenTemporal(Convert.ToInt32(Session["ID_ORDEN_TEMP"].ToString()), Convert.ToInt32(Session["ID_USUARIO_TEMP"].ToString()));
            }
            Response.Redirect("CoordPoliciaInvestigador_MisOrdenes.aspx");
        }

        protected void Image3_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["ID_ORDEN_TEMP"].ToString() != "" && Session["ID_USUARIO_TEMP"].ToString() != "")
            {
                PGJ.EliminarOrdenTemporal(Convert.ToInt32(Session["ID_ORDEN_TEMP"].ToString()), Convert.ToInt32(Session["ID_USUARIO_TEMP"].ToString()));
            }
            Response.Redirect("CoordPoliciaInvestigador_Estadistica.aspx");
        }

        protected void ImageB_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DatosDetenidoPI.aspx?op=Agregar");
        }

    }
}