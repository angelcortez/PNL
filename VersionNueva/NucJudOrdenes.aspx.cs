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

namespace AtencionTemprana
{
    public partial class NucJudOrdenes : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {

                Session["op"] = Request.QueryString["op"];
                Session["IdOrdenOficio"] = Request.QueryString["IdOrdenOficio"];


                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                //PGJ.CargaCombo(CboDelito, "CAT_DELITO", "ID_DLTO", "DLTO");
                //PGJ.CargaCombo(CboModalidad, "CAT_MODALIDAD", "ID_MDLDD", "MDLDD");
                PGJ.CargaCombo(CboJuzgado, "CAT_JUZGADO", "IDJUZGADO", "JUZGADO");


                //RanValTxtFechaOrden.MaximumValue = lblFecha.Text;
                //RanValTxtFechaOrden.MinimumValue = "01/07/2013 00:00";
                //RanValTxtFechaOrden.MaximumValue = DateTime.Now.ToString();
                //RanValTxtFechaOrden.MaximumValu
                //RanValTxtFechaSobreseimiento.MaximumValue = lblFecha.Text;

                if (!PGJ.TieneImputados(Session["ID_CARPETA"].ToString()))
                {
                    lblEstatus.Text = "No se puede Judicializar la carpeta, no hay imputados registrados, registre al menos uno";
                    CmdOficioOrden.Visible = false;
                    CmdPersona.Visible = false;

                }
                else if (PGJ.TieneQRR(Session["ID_CARPETA"].ToString()))
                {
                    lblEstatus.Text = "No se puede Judicializar la carpeta, modifique el imputado Quien Resulte Responsable";
                    CmdOficioOrden.Visible = false;
                    CmdPersona.Visible = false;
                }

                if (Session["op"].ToString() == "Modificar")
                {
                    FileUploadOrden.Visible = false;
                    CmdOficioOrden.Text = "Consultar Oficio";
                    CmdPersona.Visible = true;
                    ConsultaOrdenOficio();
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

        public int ValidaDatosOrdenOficio()
        {
            lblEstatus.Text = "";

            if (TxtNumeroOficio.Text.Trim() == "")
            {
                lblEstatus.Text = "No ha seleccionado ingresado el número de Oficio de la Solicitud. ";
                return 0;
            }
            else if (TxtFechaOrden.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado la Fecha de Obsequio de la Orden. ";
                return 0;
            }
            else if ( DateTime.Parse(TxtFechaOrden.Text)>System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha de Obsequio de la Orden NO Válida. ";
                return 0;
            }
            else if (TxtNumCarpetaAdministrativa.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado el Número de Carpeta Administrativa. ";
                return 0;
            }
            else if (CboJuzgado.SelectedItem.Text == "-- SELECCIONA --")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha seleccionado el Juzgado. ";
                return 0;
            }
            else if (TxtJuezNombre.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado el nombre del Juez. ";
                return 0;
            }
            else if (TxtJuezPaterno.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado el apellido paterno del Juez. ";
                return 0;
            }
            //else if (TxtJuezMaterno.Text.Trim() == "")
            //{
            //    lblEstatus.Text = lblEstatus.Text + "No ha ingresado el apellido materno del Juez. ";
            //    return 0;
            //}
            else if (OptTipoOrden.SelectedValue == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha seleccionado el tipo de Orden. ";
                return 0;
            }
            else if (FileUploadOrden.HasFile == false )
            {
                lblEstatus.Text = lblEstatus.Text + "No ha seleccionado el PDF del Oficio de la Orden Obsequiada. ";
                return 0;
            }
            else
            {
                lblEstatus.Text = "";
                return 1;
            }
        }


        protected void CmdOficioOrden_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["op"].ToString() == "Modificar")
                {
                    CargarDocumento(Session["IdOrdenOficio"].ToString());
                }
                else
                {
                    if (ValidaDatosOrdenOficio() == 1)
                    {
                        if (FileUploadOrden.HasFile)
                        {
                            using (BinaryReader reader = new BinaryReader(FileUploadOrden.PostedFile.InputStream))
                            {
                                byte[] Pdf = reader.ReadBytes(FileUploadOrden.PostedFile.ContentLength);

                                Session["IdOrdenOficio"] = Convert.ToString(PGJ.InsertaPGJNucJudOrdenOficio(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), short.Parse(OptTipoOrden.SelectedValue), short.Parse(CboJuzgado.SelectedValue), TxtNumeroOficio.Text, DateTime.Parse(TxtFechaOrden.Text), TxtNumCarpetaAdministrativa.Text, TxtJuezNombre.Text, TxtJuezPaterno.Text, TxtJuezMaterno.Text, Pdf, short.Parse(Session["IdUsuario"].ToString())));
                                //PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Docuemto Pdf IdCarpeta=" + IdCarpeta.Text + " Docuemto: " + ddlPlantilla.SelectedItem + " Denunciante: " + ddlDenunciante.SelectedItem + " Ofendido: " + ddlOfendido.SelectedItem + " Imputado: " + ddlImputado.SelectedItem + " Testigo: " + ddlTestigo.SelectedItem + " Defensor: " + ddlDefensor.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));


                                ///////////////////////////////
                                Session["ID_ESTADO_NUC"] = 122;
                                SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=122 , FECHA_ESTADO_NUC='" + string.Format("{0:dd/MM/yyyy HH:mm}", TxtFechaOrden.Text) + "' where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                                SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
                                rdC.Close();
                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=122 FechaEstadoNuc= " + string.Format("{0:dd/MM/yyyy HH:mm}", TxtFechaOrden.Text), int.Parse(Session["IdModuloBitacora"].ToString()));
                                ///////////////////////////////////////////////

                                lblEstatus.Text = "Se registró Oficio de la Orden. Agregue los Imputados";
                                CmdPersona.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
            }
        }

        private void ConsultaOrdenOficio()
        {
            try
            {
                lblEstatus.Text = "";
                string Sql = "SELECT NUM_OFICIO,FECHA,NUM_CARPETA_ADMINISTRATIVA,ID_JUZGADO,JUEZNOMBRE,JUEZPATERNO,JUEZMATERNO,ID_TIPO_ORDEN FROM PGJ_NUC_JUD_ORDEN_OFICIO  WHERE ID_OFICIO=" + Session["IdOrdenOficio"].ToString();
                SqlCommand CmdOrdenOficio = new SqlCommand(Sql, Data.CnnCentral);
                SqlDataReader DR = CmdOrdenOficio.ExecuteReader();
                if (DR.HasRows)
                {
                    DR.Read();
                    TxtNumeroOficio.Text = DR["NUM_OFICIO"].ToString();
                    TxtFechaOrden.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA"]);
                    //TxtFechaOrden.Text=DR["FECHA"].ToString();
                    TxtNumCarpetaAdministrativa.Text = DR["NUM_CARPETA_ADMINISTRATIVA"].ToString();
                    CboJuzgado.SelectedValue = DR["ID_JUZGADO"].ToString();
                    TxtJuezNombre.Text = DR["JUEZNOMBRE"].ToString();
                    TxtJuezPaterno.Text = DR["JUEZPATERNO"].ToString();
                    TxtJuezMaterno.Text = DR["JUEZMATERNO"].ToString();
                    OptTipoOrden.SelectedValue = DR["ID_TIPO_ORDEN"].ToString();

                    //CboImputado.DataSource = DR;
                    //CboImputado.DataValueField = "ID_PERSONA";
                    //CboImputado.DataTextField = "IMPUTADO";
                    //CboImputado.DataBind();
                }
                DR.Close();
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
            }
        }

        private void CargarDocumento(string id_pdf)
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * from PGJ_NUC_JUD_ORDEN_OFICIO  WHERE ID_OFICIO = " + id_pdf, Data.CnnCentral);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            //Creamos un array de bytes que contiene los bytes almacenados
            //en el campo Documento de la tabla
            byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[11]));
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

        protected void CmdPersona_Click(object sender, EventArgs e)
        {
            //Response.Redirect("NucJudOrdenesPersona.aspx?IdOrdenOficio=" + Session["IdOrdenOficio"].ToString() + "&op=Agregar");
            Response.Redirect("NucJudOrdenesPersona.aspx?IdOrdenOficio=" + Session["IdOrdenOficio"].ToString() + "&op=Agregar" + "&IdOrden=0");
        }

        protected void CmdRegresar_Click(object sender, EventArgs e)
        {
             Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" +Session["ID_ESTADO_NUC"].ToString());
        }
       
    }
}