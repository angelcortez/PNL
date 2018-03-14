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
    public partial class Registrardetenido : System.Web.UI.Page
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
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                //IdOrden.Text = Session["ID_ORDEN"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                //IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                lblArbol.Text = Session["lblArbol"].ToString();

                ////COMBOS DE LOS VEHICULOS
                //PGJ.CargaCombo(ddlMarca, "CAT_MARCA", "id_marca", "marca");
                //PGJ.CargaCombo(ddlModelo, "CAT_MODELO", "IdModelo", "Modelo");
                //PGJ.CargaCombo(ddlColor, "CAT_COLOR", "ID_CLR", "CLR");
                //PGJ.CargaCombo(ddlProcedencia, "CAT_PROCEDENCIA", "IdProcedencia", "Procedencia");
                //PGJ.CargaCombo(ddlTipoVehiculo, "CAT_TIPO_VEHICULO", "id_tipo_veh", "tipo_vehiculo");
                //PGJ.CargaCombo(ddlDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");
                //PGJ.CargaCombo(ddlAsegurado, "CAT_ASEGURADO", "IdAsegurado", "Asegurado");
                //PGJ.CargaCombo(ddlPlacasEstado, "CAT_ESTADO", "ID_ESTDO", "ESTDO");

                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                cargarImputado();

                //COMBOS DE LAS ARMAS
                PGJ.CargaCombo(ddlTipoArma, "CAT_ARMA_TIPO", "ID_ARMA_TPO", "ARMA_TPO");
                PGJ.CargaCombo(ddlArma, "CAT_ARMA", "ID_ARMA", "ARMA");
                PGJ.CargaCombo(ddlTamañoArma, "CAT_ARMAS_AA", "ID_ARMAS_AA", "ARMAS_AA");
                PGJ.CargaCombo(ddlMarcaArma, "CAT_ARMA_MARCA", "ID_MARCA", "MARCA");
                PGJ.CargaCombo(ddlCalibreArma, "CAT_ARMA_CALIBRE", "ID_CALIBRE", "CALIBRE");
                PGJ.CargaCombo(ddlEstadoArma, "CAT_ARMA_ESTADO", "ID_ESTADO_ARMA", "ESTADO_ARMA");



                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR REGISTRO DE DETENCIÓN";
                    //IdDetencion.Text = Session["ID_DETENCION"].ToString();





                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR REGISTRO DE DETENCIÓN";
                    //IdDetencion.Text = Session["ID_DETENCION"].ToString();

                    Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    cargarImputado();
                    CargarRegistrarDetencion();

                    gvConsultarObjetos.DataSourceID = "dsObjetosDetSec";
                    gvConsultarObjetos.DataBind();

                    gvArmas.DataSourceID = "dsVerArmas";
                    gvArmas.DataBind();

                    gvDroga.DataSourceID = "dsVerDroga";
                    gvDroga.DataBind();




                }

                Image1.Visible = false;
                lblMisOrdenes.Visible = false;
                Label332.Visible = false;
                FileUpload1.Visible = false;
                cmdGuardar.Visible = false;
            }

            cargarFecha();
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




        public void ConsultarIDObjetoDetencion()
        {
            SqlCommand comm = new SqlCommand("SELECT MAX(ID_OBJETO) as ID_OBJETO  FROM PGJ_OBJETO WHERE ID_CARPETA = 0 ", Data.CnnCentral);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["ID_OBJETO"] = dr["ID_OBJETO"].ToString();
                }
                dr.Close();
            }

        }


        void CargarRegistrarDetencion()
        {

            SqlCommand sql = new SqlCommand("cargarRegistrarDetencionSec  " + ID_PERSONA.Text, Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ddlImputado.SelectedValue = dr["ID_PERSONA"].ToString();



            }
            dr.Close();


        }




        protected void btnAgregarObj_Click1(object sender, EventArgs e)
        {
            if (txtCantidadObjeto.Text != "" && txtObj.Text != "" && txtDescObj.Text != "")
            {
                if (int.Parse(txtCantidadObjeto.Text) > 0)
                {

                    PGJ.InsertarObjeto(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), txtObj.Text, txtDescObj.Text, txtCantidadObjeto.Text);

                    consultaIDObjeto();
                    PGJ.InsertarDetencionObjeto(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ID_OBJETO.Text), int.Parse(ddlImputado.SelectedValue.ToString()));


                    limpiarValoresObjeto();

                    //ConsultarIDObjetoDetencion();
                    //PGJ.InsertarObjetoDetenidoPI(int.Parse(Session["ID_OBJETO"].ToString()),int.Parse(IdDetencion.Text));

                    // gvConsultarObjetos.DataSourceID = "dsVerObjetos";
                    // gvConsultarObjetos.DataBind();

                    string script3 = @"<script type='text/javascript'>
                            alert('OBJETO AGREGADO CORRECTAMENTE');
                                   </script>";
                    //script = string.Format(script, ex.Message);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script3, false);

                }
                else
                {
                    string script1 = @"<script type='text/javascript'>
                            alert('LA CANTIDAD DEBE SER MAYOR A 0');
                                   </script>";
                    //script = string.Format(script, ex.Message);

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);
                }
            }
            else
            {

                string script = @"<script type='text/javascript'>
                            alert('ES NECESARIO LLENAR TODOS LOS DATOS DEL OBJETO');
                                   </script>";
                //script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }


        void consultaIDObjeto()
        {

            PGJ.ConnectServer();
            SqlCommand comm1 = new SqlCommand("SELECT ISNULL( MAX(ID_OBJETO),1 ) as ID_OBJETO FROM PGJ_OBJETO WHERE ID_CARPETA =" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader dr1 = comm1.ExecuteReader();

            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    ID_OBJETO.Text = dr1["ID_OBJETO"].ToString();
                }
                dr1.Close();
            }

        }

        void consultaIDArma()
        {

            PGJ.ConnectServer();
            SqlCommand comm1 = new SqlCommand("SELECT ISNULL( MAX(ID_ARMA),1 )  as ID_ARMA FROM PGJ_ARMA WHERE ID_CARPETA = " + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader dr1 = comm1.ExecuteReader();

            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    ID_ARMA.Text = dr1["ID_ARMA"].ToString();
                }
                dr1.Close();
            }

        }

        void consultaIDDroga()
        {

            PGJ.ConnectServer();
            SqlCommand comm1 = new SqlCommand("SELECT ISNULL( MAX(ID_DROGA),1 )  as ID_DROGA FROM PGJ_DROGA WHERE ID_CARPETA = " + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader dr1 = comm1.ExecuteReader();

            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    ID_DROGA.Text = dr1["ID_DROGA"].ToString();
                }
                dr1.Close();
            }

        }

        void consultaIDVehiculo()
        {

            PGJ.ConnectServer();
            SqlCommand comm1 = new SqlCommand("SELECT ISNULL( MAX(ID_VEHICULO),1 )  as ID_VEHICULO FROM PGJ_VEHICULO WHERE ID_CARPETA = 0", Data.CnnCentral);
            SqlDataReader dr1 = comm1.ExecuteReader();

            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    ID_VEHICULO.Text = dr1["ID_VEHICULO"].ToString();
                }
                dr1.Close();
            }

        }


        protected void cmdElaborarDocumento_Click(object sender, EventArgs e)
        {
            try
            {

                //PGJ.ActualizarDelitoPI(int.Parse(IdDetencion.Text),txtCausaDetencion.Text,txtTiempoTraslado.Text,TxtPuestaDisposicion.Text,txtCircunstancia.Text);
                //Session["ID_PLANTILLA"] = 72;
                Session["ID_PLANTILLA"] = 106;


                Archivos.IdPlantilla = int.Parse(Session["ID_PLANTILLA"].ToString());
                LeerDeBD();
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                cerrarWord();
            }


            Image1.Visible = true;
            lblMisOrdenes.Visible = true;

            Label332.Visible = true;
            FileUpload1.Visible = true;
            cmdGuardar.Visible = true;
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            //Subir Archivo
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    //Archivos.InsertaPoliciaPDF(0, Pdf, "REGISTRO DE DETENCION",72, 0, 0, 0, 0, 0, short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));
                    Archivos.InsertarDetencionPDF(0, Pdf, 72, "REGISTRO DE  DETENCION", int.Parse(Session["IdMunicipio"].ToString()), int.Parse(Session["IdUsuario"].ToString()), int.Parse(Session["IdUnidad"].ToString()), int.Parse(IdDetencion.Text));
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

                //INSERTAMOS LA BITACORA DEL SISTEMA
                //PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"].ToString(), "Se elaboro un Informe Policial de la Carpeta" + IdCarpeta.Text);

            }
            else
            {
                Label3.Text = " *SELECCIONE UN ARCHIVO PDF";
            }
        }

        public void ImageButton_Command(object sender, CommandEventArgs e)
        {
            PGJ.EliminarObjetosDetencionPI(Convert.ToInt32(e.CommandArgument.ToString()));
            gvConsultarObjetos.DataSourceID = "dsVerObjetos";
            gvConsultarObjetos.DataBind();
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

            foreach (DataRow drParametros in dsParametros.Tables["Parametros"].Rows)
            {
                if (drParametros["Parametro"].ToString() != "NULO")
                {



                    if (drParametros["Parametro"].ToString() == "@ID_DETENCION")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdDetencion.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@Id_Detencion")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdDetencion.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@id_Detencion")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdDetencion.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@idDetencion")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdDetencion.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@id_detencion")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdDetencion.Text;
                    }
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
                    if (drParametros["Parametro"].ToString() == "@IdUsuario")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdUsuario.Text;
                    }
                    if (drParametros["Parametro"].ToString() == "@id_usuario")
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

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_SECUESTRO.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }
        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["ID_PUESTO"].ToString() == "8")
            {
                Response.Redirect("PoliciaInvestigador.aspx");
            }

            else if (Session["ID_PUESTO"].ToString() == "17")
            {
                Response.Redirect("CoordPoliciaInvestigador_MisOrdenes.aspx");
            }
        }

        //        protected void btnAgregarVeh_Click1(object sender, EventArgs e)
        //        {
        //             try
        //            {
        //                PGJ.InsertaVehiculoDetencion(0,0, short.Parse(ddlMarca.SelectedValue.ToString()), short.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text,txtNumMotor.Text,txtRegNiv.Text,txtEmpresa.Text,txtTipoCarga.Text,txtOrigen.Text,txtDestino.Text );


        //                //consultaIDVehiculo();
        //                //PGJ.InsertarDetencionVehiculo(int.Parse(ID_VEHICULO.Text), int.Parse(IdDetencion.Text));

        //                limpiarValoresVehiculo();

        //                //Modificar Para que Inserte en la Nueva Tabla 
        //                //PGJ.Insertar_VehiculoAseguradoPI(Convert.ToInt32(ddlCausaVeh.SelectedValue), Convert.ToInt32(IdCarpeta.Text));

        //                string script3 = @"<script type='text/javascript'>
        //                            alert('VEHICULO AGREGADO CORRECTAMENTE');
        //                                   </script>";
        //                //script = string.Format(script, ex.Message);

        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script3, false);


        //                //Modificar para que traiga la Info de PGJ_VEHICULOS
        //               // gvConsultarVehiculos.DataSourceID = "dsVerVehiculos";
        //               // gvConsultarVehiculos.DataBind();
        //            }
        //            catch (Exception ex)
        //            {
        //                //Colocar Alerta 
        //                string script1 = @"<script type='text/javascript'>
        //                            alert('NO ES POSIBLE REGISTAR EL VEHICULO, VUELVA A INTENTARLO'); </script>";
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);
        //            }
        //        }

        protected void btnAgregarDroga_Click(object sender, EventArgs e)
        {
            try
            {

                PGJ.InsertarDroga(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), txtTipoDroga.Text, txtUnidadDeMedida.Text, txtCantidad.Text, txtObservacionesD.Text);

                consultaIDDroga();
                PGJ.InsertarDetencionDroga(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ID_DROGA.Text), int.Parse(ddlImputado.SelectedValue.ToString()));

                limpiarValoresDroga();

                string script3 = @"<script type='text/javascript'>
                            alert('DROGA AGREGADA CORRECTAMENTE');
                                   </script>";
                //script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script3, false);


            }

            catch (Exception exc)
            {

                //Colocar Alerta 
                string script1 = @"<script type='text/javascript'>
                            alert('NO ES POSIBLE REGISTAR LA DROGA, VUELVA A INTENTARLO'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);

            }

        }

        protected void ddlTipoArma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_TIPO_ARMA"] = ddlTipoArma.SelectedValue.ToString();
            PGJ.CargarArma(ddlArma, Session["ID_TIPO_ARMA"].ToString());
        }

        protected void btnAgregarArma_Click(object sender, EventArgs e)
        {
            try
            {
                // insertamos el ARMA
                PGJ.InsertarArma(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlTipoArma.SelectedValue), short.Parse(ddlArma.SelectedValue), short.Parse(ddlTamañoArma.SelectedValue), short.Parse(ddlMarcaArma.SelectedValue), short.Parse(ddlCalibreArma.SelectedValue), short.Parse(ddlEstadoArma.SelectedValue), txtDescripcionArma.Text, txtMatricula.Text, txtSerieArma.Text);

                consultaIDArma();
                PGJ.InsertarDetencionArma(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ID_ARMA.Text), int.Parse(ddlImputado.SelectedValue.ToString()));

                limpiarValoresArma();

                string script3 = @"<script type='text/javascript'>
                            alert('ARMA AGREGADA CORRECTAMENTE');
                                   </script>";
                //script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script3, false);


                //Consultamo el ID del ARMA


                //Mostramos el Arma en el Grid
                // gvArmas.DataSourceID = "dsVerArmas";
                // gvArmas.DataBind();


            }

            catch (Exception exc)
            {

                //Colocar Alerta 
                string script1 = @"<script type='text/javascript'>
                            alert('NO ES POSIBLE REGISTAR EL ARMA, VUELVA A INTENTARLO'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);

            }
        }

        //protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ID_MARCA"] = ddlMarca.SelectedValue.ToString();
        //    consultaMarcaSubMarca();

        //    //PGJ.CargaComboFiltrado(ddlSubMarca, "CAT_SUBMARCA", "id_submarca", "submarca", "id_marca=" + ddlMarca.SelectedValue.ToString());
        //}

        //void consultaMarcaSubMarca()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var estado = from c in dc.consultaMarcaSubMarca(short.Parse(Session["ID_MARCA"].ToString()))
        //                 select new { c.id_submarca, c.submarca };
        //    ddlSubMarca.DataSource = estado;
        //    ddlSubMarca.DataValueField = "id_submarca";
        //    ddlSubMarca.DataTextField = "submarca";
        //    ddlSubMarca.DataBind();
        //}


        void limpiarValoresDroga()
        {
            txtTipoDroga.Text = "";
            txtUnidadDeMedida.Text = "";
            txtCantidad.Text = "";
            txtObservacionesD.Text = "";

        }

        void limpiarValoresArma()
        {
            ddlTipoArma.SelectedValue = "0";
            //ddlArma.SelectedValue = "0";
            ddlTamañoArma.SelectedValue = "0";
            ddlMarcaArma.SelectedValue = "0";
            ddlCalibreArma.SelectedValue = "0";
            ddlEstadoArma.SelectedValue = "0";
            txtDescripcionArma.Text = "";
            txtMatricula.Text = "";
            txtSerieArma.Text = "";


        }



        //void limpiarValoresVehiculo() 
        //{
        //    ddlMarca.SelectedValue = "0";
        //    ddlSubMarca.SelectedValue = "0";
        //    ddlModelo.SelectedValue = "0";
        //    ddlColor.SelectedValue = "0";
        //    txtSerie.Text = "";
        //    txtPlaca.Text = "";
        //    ddlPlacasEstado.SelectedValue  = "0";
        //    ddlProcedencia.SelectedValue  = "0";
        //    ddlTipoVehiculo.SelectedValue  = "0";
        //    ddlDisposicion.SelectedValue  = "0";
        //    ddlAsegurado.SelectedValue = "0";
        //    txtObservaciones.Text = "";
        //    txtNumMotor.Text  = "";
        //    txtRegNiv.Text  = "";
        //    txtEmpresa.Text = "";
        //    txtTipoCarga.Text = "";
        //    txtOrigen.Text  = "";
        //    txtDestino.Text = "";
        //}




        void limpiarValoresObjeto()
        {
            txtObj.Text = "";
            txtDescObj.Text = "";
            txtCantidadObjeto.Text = "";
        }

    }
}