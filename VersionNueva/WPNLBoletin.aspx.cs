using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using System.Diagnostics;
using iTextSharp.text.html.simpleparser;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;



namespace AtencionTemprana
{
    public partial class WPNLBoletin : System.Web.UI.Page
    {
        private const string SCRIPT_DOFOCUS =
   @"window.setTimeout('DoFocus()', 1);
                function DoFocus()
                {
                    try {
                        document.getElementById('REQUEST_LASTFOCUS').focus();
                    } catch (ex) {}
                }";

        Data PGJ = new Data();
        FileStream fs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {

                Session["op"] = Request.QueryString["op"];
                if (Session["op"].ToString() == "Agregar")
                {
                    IdMunicipio.Text = Session["IdMunicipio"].ToString();
                    IdCarpeta.Text = Session["Id_Carpeta"].ToString();
                    lblArbol.Text = Session["lblArbol"].ToString();

                    UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                    LBLUSUARIO.Text = Session["Us"].ToString();
                    PUESTO.Text = Session["PUESTO"].ToString();
                    Session["tab"] = Request.QueryString["tab"];
                    Session["op"] = Request.QueryString["op"];



                    cargarFecha();
                    cargarOfendido();
                    PGJ.CargaCombo(ddlTipoBoletin, "CAT_TIPO_BOLETIN", "IdTipoBoletin", "TipoBoletin");
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    Session["ID_PDF"] = Request.QueryString["ID_PDF"];
                    ddlOfendido.Visible = false;
                    ddlTipoBoletin.Visible = false;
                    ddlFoto.Visible = false;
                    txtNumero.Visible = false;
                    btnGuardarDatos.Visible = false;
                    ImagePNL.Visible = false;
                    lblOfendido.Visible = false;
                    lblTipoBoletin.Visible = false;
                    lblFoto.Visible = false;
                    lblNumero.Visible = false;
                    Label1.Visible = false;
                    CargarDocumento(Session["ID_PDF"].ToString());
                }

            }
          
        }

        private void CargarDocumento(string id_pdf)
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * from PNL_BOLETIN_PDF  WHERE idpdf = " + id_pdf, Data.CnnCentral);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            //Creamos un array de bytes que contiene los bytes almacenados
            //en el campo Documento de la tabla
            byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[5]));
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

        void cargarOfendido()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorOfendido(int.Parse(Session["ID_CARPETA"].ToString()))
                     select new { c.ID_PERSONA, c.OFENDIDO };
            ddlOfendido.DataSource = im;
            ddlOfendido.DataValueField = "ID_PERSONA";
            ddlOfendido.DataTextField = "OFENDIDO";
            ddlOfendido.DataBind();
        }

        void cargarFotografia(int IdPer)
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.SP_ComboFoto(IdPer)
                     select new { c.IdFotografia, c.Descripcion };
            ddlFoto.DataSource = im;
            ddlFoto.DataValueField = "IdFotografia";
            ddlFoto.DataTextField = "Descripcion";
            ddlFoto.DataBind();
        }

        protected void ddlOfendido_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cargarFotografia(int.Parse(ddlOfendido.SelectedValue.ToString()));
        }

        protected void ddlFoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ifoto.Visible = true;
           
           ImagePNL.ImageUrl = "FotoPNL.ashx?Id=" + int.Parse(ddlFoto.SelectedValue.ToString());
          
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
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

                else if (lblArbol.Text == "8")
                {
                    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                }
                else if (lblArbol.Text == "5")
                {
                    Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
                }
                else if (lblArbol.Text == "6")
                {
                    if (Session["ID_PUESTO"].ToString() == "16")
                    {
                        Response.Redirect("OrdenCoordPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                    else if (Session["ID_PUESTO"].ToString() == "8")
                    {
                        Response.Redirect("OrdenPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
            
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR desde Boletín", int.Parse(Session["IdModuloBitacora"].ToString()));
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
        }

        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {
           

            lblError.Text = "";
            if (ddlOfendido.SelectedValue.ToString() == "0")
            {
                lblError.Text = "SELECCIONE UNA PERSONA.";
            }

            if (ddlTipoBoletin.SelectedValue.ToString() == "1")
            {
                lblError.Text = "SELECCIONE TIPO DE BOLETÍN.";
            }

            if (ddlFoto.SelectedValue.ToString() == "0")
            {
                lblError.Text = "SELECCIONE UNA FOTO.";
            }

            if (ddlFormatoBoletin.SelectedValue.ToString() == "0")
            {
                lblError.Text = "SELECCIONE FORMATO DEL BOLETIN: PDF O IMAGEN.";
            }


            if (lblError.Text == "")
            {
                //try
                //{
                    

                    if (ddlFormatoBoletin.SelectedValue.ToString() == "1") //PDF
                    {
                        if (ddlTipoBoletin.SelectedValue.ToString() == "2")//BOLETÍN DE BÚSQUEDA (NO LOCALIZADO)
                        {

                            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Busqueda No Localizado: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

                            // Variables
                            Microsoft.Reporting.WebForms.Warning[] warnings;
                            string[] streamIds;
                            string mimeType = string.Empty;
                            string encoding = string.Empty;
                            string extension = string.Empty;

                            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

                            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.DataSources.Add(rds);
                            ReportViewer1.LocalReport.DataSources.Add(rds2);
                            ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc";
                            ReportViewer1.LocalReport.Refresh();

                            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                            Response.Buffer = true;
                            Response.Clear();
                            Response.ContentType = mimeType;
                            Response.AddHeader("content-disposition", "attachment; filename=" + "BoletinNoLocalizado" + "." + extension);
                            Response.BinaryWrite(bytes); // create the file
                            Response.Flush(); // send it to the client to download

                            //GUARDA EN LA BASE DE DATOS
                            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
                            Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
                            Label2.Text = "DATOS GUARDADOS";

                        }
                        if (ddlTipoBoletin.SelectedValue.ToString() == "4")
                        {
                            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Busqueda Localizado: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

                            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

                            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.DataSources.Add(rds);
                            ReportViewer1.LocalReport.DataSources.Add(rds2);
                            ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc";
                            ReportViewer1.LocalReport.Refresh();

                            CreatePDFLocalizado(ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc");
                            Label2.Text = "DATOS GUARDADOS";
                        }

                        if (ddlTipoBoletin.SelectedValue.ToString() == "3")
                        {
                            if (string.IsNullOrEmpty(txtNumero.Text))
                            {
                                lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
                            }
                            else
                            {
                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
                                ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                                ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

                                ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                                ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                                ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                                ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

                                string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
                                string leyenda = "";
                                List<ReportParameter> parametros = new List<ReportParameter>();
                                parametros.Add(new ReportParameter("numero", numero));
                                parametros.Add(new ReportParameter("leyenda", leyenda));


                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.LocalReport.DataSources.Add(rds);
                                ReportViewer1.LocalReport.DataSources.Add(rds2);
                                ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
                                ReportViewer1.LocalReport.SetParameters(parametros);
                                ReportViewer1.LocalReport.Refresh();

                                CreatePDFAmber(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
                                //Label2.Text = "DATOS GUARDADOS";
                            }
                        }

                        if (ddlTipoBoletin.SelectedValue.ToString() == "5")
                        {
                            if (string.IsNullOrEmpty(txtNumero.Text))
                            {
                                lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
                            }
                            else
                            {
                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
                                ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                                ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

                                ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                                ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                                ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                                ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

                                string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
                                string leyenda = "LOCALIZADO";
                                List<ReportParameter> parametros = new List<ReportParameter>();
                                parametros.Add(new ReportParameter("numero", numero));
                                parametros.Add(new ReportParameter("leyenda", leyenda));


                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.LocalReport.DataSources.Add(rds);
                                ReportViewer1.LocalReport.DataSources.Add(rds2);
                                ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
                                ReportViewer1.LocalReport.SetParameters(parametros);
                                ReportViewer1.LocalReport.Refresh();

                                CreatePDFAmberLocalizado(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
                                //Label2.Text = "DATOS GUARDADOS";
                            }
                        }


                    }else if (ddlFormatoBoletin.SelectedValue.ToString() == "2") //IMAGEN
                    {
                        if (ddlTipoBoletin.SelectedValue.ToString() == "2")
                        {
                            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Busqueda No Localizado: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

                            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

                            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.DataSources.Add(rds);
                            ReportViewer1.LocalReport.DataSources.Add(rds2);
                            ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc";
                            ReportViewer1.LocalReport.Refresh();

                            CreatePDFImagen(ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc");
                            Label2.Text = "DATOS GUARDADOS";
                        }

                        if (ddlTipoBoletin.SelectedValue.ToString() == "4")
                        {
                            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Busqueda Localizado: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

                            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

                            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.DataSources.Add(rds);
                            ReportViewer1.LocalReport.DataSources.Add(rds2);
                            ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc";
                            ReportViewer1.LocalReport.Refresh();

                            CreatePDFLocalizadoImagen(ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc");
                            Label2.Text = "DATOS GUARDADOS";
                        }


                        if (ddlTipoBoletin.SelectedValue.ToString() == "3")
                        {
                            if (string.IsNullOrEmpty(txtNumero.Text))
                            {
                                lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
                            }
                            else
                            {
                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
                                ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                                ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

                                ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                                ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                                ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                                ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

                                string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
                                string leyenda = "";
                                List<ReportParameter> parametros = new List<ReportParameter>();
                                parametros.Add(new ReportParameter("numero", numero));
                                parametros.Add(new ReportParameter("leyenda", leyenda));


                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.LocalReport.DataSources.Add(rds);
                                ReportViewer1.LocalReport.DataSources.Add(rds2);
                                ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
                                ReportViewer1.LocalReport.SetParameters(parametros);
                                ReportViewer1.LocalReport.Refresh();

                                CreatePDFAmberImagen(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
                                //Label2.Text = "DATOS GUARDADOS";
                            }
                        }


                        if (ddlTipoBoletin.SelectedValue.ToString() == "5")
                        {
                            if (string.IsNullOrEmpty(txtNumero.Text))
                            {
                                lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
                            }
                            else
                            {
                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
                                ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
                                ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

                                ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
                                ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
                                ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
                                ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
                                Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

                                string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
                                string leyenda = "LOCALIZADO";
                                List<ReportParameter> parametros = new List<ReportParameter>();
                                parametros.Add(new ReportParameter("numero", numero));
                                parametros.Add(new ReportParameter("leyenda", leyenda));


                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.LocalReport.DataSources.Add(rds);
                                ReportViewer1.LocalReport.DataSources.Add(rds2);
                                ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
                                ReportViewer1.LocalReport.SetParameters(parametros);
                                ReportViewer1.LocalReport.Refresh();

                                CreatePDFAmberLocalizadoImagen(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
                                Label2.Text = "DATOS GUARDADOS";
                            }
                        }

                    }

                //    Label2.Visible = true;
                //    Label2.Text = "DATOS GUARDADOS";
                //    btnGuardarDatos.Enabled = false;

                //}
                //catch (Exception ex)
                //{
                //    lblEstatus.Text = ex.Message;
                //    lblEstatus1.Text = "INTENTELO NUEVAMENTE";

                //}



            }//SIN ERROR
            
        }



        private void CreatePDFAmber(string fileName)
        {

                     try
                {

            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;


            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);


            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
            string leyenda = "  ";
            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("numero", numero));
            parametros.Add(new ReportParameter("leyenda", leyenda));
            ReportViewer1.LocalReport.SetParameters(parametros);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download


           

             //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
            
            lblEstatus.Visible = true;
            Label2.Text = "DATOS GUARDADOS";
            btnGuardarDatos.Enabled = false;


           }
                 catch (Exception ex)
           {
                 lblEstatus.Text = ex.Message;
                 lblEstatus1.Text = "INTENTELO NUEVAMENTE";

            }

                     
        }

        private void CreatePDFAmberLocalizado(string fileName)
        {



            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;


            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);


            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
            string leyenda = "LOCALIZADA";
            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("numero", numero));
            parametros.Add(new ReportParameter("leyenda", leyenda));
            ReportViewer1.LocalReport.SetParameters(parametros);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download




            //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
            Label2.Text = "DATOS GUARDADOS";
        }

        private void CreatePDF(string fileName)
        {



            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;



            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download

            //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
            Label2.Text = "DATOS GUARDADOS";
        }

        private void CreatePDFLocalizado(string fileName)
        {
            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download

            //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
            Label2.Text = "DATOS GUARDADOS";
        }

        protected void ddlTipoBoletin_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlTipoBoletin.SelectedValue.ToString() == "3")
            {
                lblNumero.Visible = true;
                txtNumero.Visible = true;
            }
            if (ddlTipoBoletin.SelectedValue.ToString() == "2")
            {
                lblNumero.Visible = false;
                txtNumero.Visible = false;
            
            }
            if (ddlTipoBoletin.SelectedValue.ToString() == "4")
            {
                lblNumero.Visible = false;
                txtNumero.Visible = false;

            }
            if (ddlTipoBoletin.SelectedValue.ToString() == "5")
            {
                lblNumero.Visible = true;
                txtNumero.Visible = true;
            }
        }

       
        private void CreatePDFAmberImagen(string fileName)
        {



            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;


            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);


            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
            string leyenda = "  ";
            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("numero", numero));
            parametros.Add(new ReportParameter("leyenda", leyenda));
            ReportViewer1.LocalReport.SetParameters(parametros);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("Image", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download




            //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
            Label2.Text = "DATOS GUARDADOS";
        }

        private void CreatePDFAmberLocalizadoImagen(string fileName)
        {



            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;


            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);


            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
            string leyenda = "LOCALIZADA";
            List<ReportParameter> parametros = new List<ReportParameter>();
            parametros.Add(new ReportParameter("numero", numero));
            parametros.Add(new ReportParameter("leyenda", leyenda));
            ReportViewer1.LocalReport.SetParameters(parametros);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("Image", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download

            Label2.Text = "DATOS GUARDADOS";


            //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            //Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
        }

        private void CreatePDFImagen(string fileName)
        {



            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;



            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("Image", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download

            Label2.Text = "DATOS GUARDADOS";
            //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            //Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
        }

        private void CreatePDFLocalizadoImagen(string fileName)
        {



            // Variables
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;



            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc";
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render("Image", null, out mimeType, out encoding, out extension, out streamIds, out warnings);


            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download

            Label2.Text = "DATOS GUARDADOS";
            //GUARDA EN LA BASE DE DATOS
            //(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
            //Archivos.InsertaBoletinPDF(int.Parse(IdCarpeta.Text), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlTipoBoletin.SelectedValue.ToString()), int.Parse(ddlOfendido.SelectedValue.ToString()), bytes, txtNumero.Text, int.Parse(Session["IdUsuario"].ToString()));
        }
       
    }
    }
