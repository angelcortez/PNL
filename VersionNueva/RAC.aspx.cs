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

namespace AtencionTemprana
{
    public partial class RAC : System.Web.UI.Page
    {
        Data PGJ = new Data();
        DataTable dtArbol = new DataTable();
        int Id = 20;
        FileStream fs;
        FileStream fsB;

        string TotalLH1;
        string TotalD;
        string IdLugarHecho;
        string TotalIdLH;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["lblArbol"] = lblArbol.Text;
                Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                Session["op"] = Request.QueryString["op"];
                Session["IdDoc"] = Request.QueryString["IdDoc"];
                Session["IdDo"] = Request.QueryString["IdDo"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                Session["ID_ESTADO_RAC"] = Request.QueryString["ID_ESTADO_RAC"];
                ID_ESTADO_RAC.Text = Session["ID_ESTADO_RAC"].ToString();

                PUESTO.Text = Session["PUESTO"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                // Data.IdCarpeta = Convert.ToInt32(Session["ID_CARPETA"].ToString());
                //   Session.Add("NUC", Request.QueryString["NUC"]);

                //Data.IdCarpeta = IdCarpeta.Text;

                //LLenarArbol(TVCarpeta.Nodes, 0);

                cargarFecha();
                try
                {
                    LBLUSUARIO.Text = Session["Us"].ToString();
                    PGJ.CargaComboFiltrado(ddlCentroMediacion, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "ID_UNDD_TPO=3 and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    //PGJ.CargaComboFiltrado(ddlUnidadInvestigacion, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "ID_UNDD_TPO=1 and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaCombo(ddlInstitucion, "CAT_INSTITUCIONES", "ID_INSTITUCION", "INSTITUCION");
                    PGJ.CargaCombo(ddlAgencia, "CAT_AGENCIA", "ID_AGENCIA", "AGENCIA");
                    CargarDatosCarpeta();
                }
                catch (Exception ex)
                {
                    Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString());

                    //lblEstatus.Text = ex.Message;

                }

                if (Session["IdDoc"] == null)
                {
                    Session["IdDoc"] = "0";
                }


                if (Session["IdDo"] == null)
                {
                    Session["IdDo"] = "0";
                }

                if (Session["op"] == null)
                {
                    Session["op"] = "0";
                }

                if (Session["op"].ToString() == "Docs")
                {
                    CargarDocumentoAatencion(Session["IdDoc"].ToString());
                }

                if (Session["op"].ToString() == "Doc")
                {
                    CargarBoletinPDF(Session["IdDo"].ToString());
                }


                if (Session["ID_ESTADO_RAC"].ToString() == "0")
                {
                    Iniciar.Visible = true;
                    Canalizar.Visible = false;
                    Suspender.Visible = false;
                    Remitir.Visible = false;
                    Resolver.Visible = false;
                    Incompetencia.Visible = false;
                    cmdConvenio.Visible = false;
                    cmdNoConvenio.Visible = false;
                    cmdConvenioIncompleto.Visible = false;
                    Archivo.Visible = false;
                    Ejercicio.Visible = false;
                    Acuerdo.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = false;
                    

                }

                if (Session["ID_ESTADO_RAC"].ToString() == "10")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = true;
                    Suspender.Enabled = true;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Visible = false;
                    cmdNoConvenio.Visible = false;
                    cmdConvenioIncompleto.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                    Acumular.Visible = true;

                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "2")
                {
                    Iniciar.Visible = false;
                    Canalizar.Visible = false;
                    Suspender.Visible = false;
                    Remitir.Visible = false;
                    Resolver.Visible = false;
                    Incompetencia.Visible = false;
                    cmdConvenio.Visible = false;
                    cmdNoConvenio.Visible = false;
                    cmdConvenioIncompleto.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "3")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = true;
                    cmdNoConvenio.Enabled = true;
                    cmdConvenioIncompleto.Visible = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "4")
                {
                    Iniciar.Visible = false;
                    Canalizar.Visible = false;
                    Suspender.Visible = false;
                    Remitir.Visible = false;
                    Resolver.Visible = false;
                    Incompetencia.Visible = false;
                    cmdConvenio.Visible = false;
                    cmdNoConvenio.Visible = false;
                    cmdConvenioIncompleto.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "5")
                {
                    Iniciar.Visible = false;
                    Canalizar.Visible = false;
                    Suspender.Visible = false;
                    Remitir.Visible = false;
                    Resolver.Visible = false;
                    Incompetencia.Visible = false;
                    cmdConvenio.Visible = false;
                    cmdNoConvenio.Visible = false;
                    cmdConvenioIncompleto.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }

                else if (Session["ID_ESTADO_RAC"].ToString() == "18")
                {
                    Iniciar.Visible = false;
                    Canalizar.Visible = false;
                    Suspender.Visible = false;
                    Remitir.Visible = false;
                    Resolver.Visible = false;
                    Incompetencia.Visible = false;
                    cmdConvenio.Visible = false;
                    cmdNoConvenio.Visible = false;
                    cmdConvenioIncompleto.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "19")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = true;
                    cmdNoConvenio.Enabled = true;
                    cmdConvenioIncompleto.Enabled = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "20")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = true;
                    cmdNoConvenio.Enabled = true;
                    cmdConvenioIncompleto.Enabled = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "21")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = true;
                    cmdNoConvenio.Enabled = true;
                    cmdConvenioIncompleto.Enabled = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }

                else if (Session["ID_ESTADO_RAC"].ToString() == "12")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = false;
                    cmdNoConvenio.Enabled = false;
                    cmdConvenioIncompleto.Enabled = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "13")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = false;
                    cmdNoConvenio.Enabled = false;
                    cmdConvenioIncompleto.Enabled = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "17")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;
                    Resolver.Enabled = true;
                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = false;
                    cmdNoConvenio.Enabled = false;
                    cmdConvenioIncompleto.Enabled = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "32")
                {


                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = false;
                    Resolver.Enabled = false;
                    Incompetencia.Enabled = false;
                    cmdConvenio.Visible = false;
                    cmdNoConvenio.Visible = false;
                    cmdConvenioIncompleto.Visible = false;
                    Archivo.Enabled = false;
                    Ejercicio.Enabled = false;
                    Acuerdo.Enabled = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_RAC"].ToString() == "22")
                {
                    Iniciar.Visible = false;
                    Canalizar.Enabled = false;
                    Suspender.Enabled = false;
                    Remitir.Enabled = true;

                    Incompetencia.Enabled = true;
                    cmdConvenio.Enabled = true;
                    cmdNoConvenio.Enabled = true;
                    cmdConvenioIncompleto.Visible = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel6.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    Panel11.Visible = false;
                    Panel12.Visible = false;
                    Panel13.Visible = false;
                    TVCarpeta.Enabled = true;
                }

                cmdConvenio.Visible = false;
                cmdNoConvenio.Visible = false;
                cmdConvenioIncompleto.Visible = false;


                //SI NO TIENE LUGAR DE HECHOS, OBLIGARLO A QUE LO CAPTURE
                SqlCommand sqlTotal = new SqlCommand("SPValidaLH ", Data.CnnCentral);
                sqlTotal.CommandType = CommandType.StoredProcedure;
                sqlTotal.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                sqlTotal.Parameters.Add("@IdMunicipio", SqlDbType.Int);

                sqlTotal.Parameters["@IdCarpeta"].Value = int.Parse(IdCarpeta.Text);
                sqlTotal.Parameters["@IdMunicipio"].Value = int.Parse(Session["IdMunicipio"].ToString());

                SqlDataReader drTotal = sqlTotal.ExecuteReader();
                if (drTotal.HasRows)
                {
                    drTotal.Read();
                    TotalLH1 = drTotal["Existe"].ToString();

                }
                drTotal.Close();

                if (TotalLH1 == "0")
                {
                    Response.Redirect("LugarHechos.aspx?&op=Agregar");
                }

                //SI NO TIENE DELITO, OBLIGARLO A QUE LO CAPTURE
                SqlCommand sqlDelito = new SqlCommand("SPValidaD ", Data.CnnCentral);
                sqlDelito.CommandType = CommandType.StoredProcedure;
                sqlDelito.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                sqlDelito.Parameters.Add("@IdMunicipio", SqlDbType.Int);

                sqlDelito.Parameters["@IdCarpeta"].Value = int.Parse(IdCarpeta.Text);
                sqlDelito.Parameters["@IdMunicipio"].Value = int.Parse(Session["IdMunicipio"].ToString());

                SqlDataReader drDelito = sqlDelito.ExecuteReader();
                if (drDelito.HasRows)
                {
                    drDelito.Read();
                    TotalD = drDelito["Existe"].ToString();

                }
                drDelito.Close();


                if (TotalD == "0")
                {
                    //obtener el IdLugarHechos
                    SqlCommand sqlIdLH = new SqlCommand("SPLugarHechoId", Data.CnnCentral);
                    sqlIdLH.CommandType = CommandType.StoredProcedure;
                    sqlIdLH.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                    sqlIdLH.Parameters.Add("@IdMunicipio", SqlDbType.Int);

                    sqlIdLH.Parameters["@IdCarpeta"].Value = int.Parse(IdCarpeta.Text);
                    sqlIdLH.Parameters["@IdMunicipio"].Value = int.Parse(Session["IdMunicipio"].ToString());

                    SqlDataReader drIdLG = sqlIdLH.ExecuteReader();
                    if (drIdLG.HasRows)
                    {
                        drIdLG.Read();
                        TotalIdLH = drIdLG["ID_LUGAR_HECHOS"].ToString();

                    }
                    drIdLG.Close();


                    Response.Redirect("LugarHechos.aspx?ID_LUGAR_HECHOS=" + TotalIdLH + "&op=Modificar");
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

        private void CargarDocumentoAatencion(string idPdf)
        {
             PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * from PGJ_PDF_ATENCION_COMUNIDAD  WHERE id_pdf = " + idPdf, Data.CnnCentral);
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



              protected void CargarDatosCarpeta()
        {
            //try
            //{
                int IdUser;
                IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());

                PGJ.InsertaArbol(1, 0, "CARPETA", "", "", IdUser);
                PGJ.InsertaArbol(2, 1, "RAC", "WebHojadeAtencion.aspx", "", IdUser);
                //PGJ.InsertaArbol(2, 1, "RAC", "", "", IdUser);
                // PGJ.InsertaArbol(3, 1, "NUM", "", "", IdUser);
                //PGJ.InsertaArbol(4, 1, "NUC", "WebHojadeAtencion.aspx", "", IdUser);

                PGJ.InsertaArbol(5, 1, "DENUNCIANTE", "AutoridadDenuncia.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(6, 1, "OFENDIDO", "QuienResulteOfendido.aspx", "", IdUser);
                //   PGJ.InsertaArbol(16, 1, "EMPRESA", "EmpreaOfendida.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(7, 1, "IMPUTADO", "QuienResulteResponsable.aspx", "", IdUser);
                //PGJ.InsertaArbol(19, 1, "DATOS DE LA DETENCIÓN", "DatosDetenidoPI.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(20, 1, "MEDIA FILIACIÓN DETENIDO", "MediaFiliacionDetenido.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(21, 1, "SEÑAS PARTICULARES DETENIDO", "SeñasParticularesDetenido.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(22, 1, "OBJETOS, ARMAS Y DROGAS", "RegistrarDetencion.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(8, 1, "TESTIGO", "Datos.aspx?&op=AgregarTes", "", IdUser);
                PGJ.InsertaArbol(14, 1, "DEFENSOR", "Defensor.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(9, 1, "LUGAR DE HECHOS", "LugarHechos.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(10, 1, "DELITO", "", "", IdUser);
                PGJ.InsertaArbol(15, 1, "VEHÍCULOS", "Vehiculo.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(11, 1, "DESCRIPCION HECHOS", "Hechos.aspx?&op=Agregar", "", IdUser);

                PGJ.InsertaArbol(12, 1, "PERSONAS NO LOCALIZADAS", "PNLDatosPrincipales.aspx?&op=Agregar", "", IdUser);

                // PGJ.InsertaArbol(12, 1, "SOLICITUDES DE AUDIENCIA", "Solicitudes.aspx?&op=Agregar", "", IdUser);

                //PGJ.InsertaArbol(12, 1, "DATOS COMPLEMENTARIOS DEL SECUESTRO", "DatosPrincipalesSec.aspx?&op=Agregar", "", IdUser);

                //PGJ.InsertaArbol(13, 1, "NEGOCIACIÓN", "AgregarNegociacionSec.aspx?&op=Agregar", "", IdUser);
                ////PGJ.InsertaArbol(14, 1, "DETENIDOS", "DatosPrincipalesSec.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(16, 1, "PRÓFUGOS", "AgregarProfugoSec.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(17, 1, "BANDAS DESARTICULADAS", "AgregarBandaDesartSec.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(18, 1, "LIBERACIÓN", "LiberacionSec.aspx?&op=Agregar", "", IdUser);


                PGJ.InsertaArbol(13, 1, "ACTUACIONES", "DocPdf.aspx?op=Agregar", "", IdUser);
                PGJ.InsertaArbol(16, 1, "BOLETÍN", "WPNLBoletin.aspx?op=Agregar", "", IdUser);

                PGJ.InsertaArbol(17, 1, "HISTORIAL RAC", "", "", IdUser);

                CargarDatosArbol("RAC", 2);
                //  CargarDatosArbol("NUM", 3);
                CargarDatosArbol("NUC", 4);

                CargarDatosArbol("Persona 1, ", 5);
                CargarDatosArbol("Persona 2, ", 6);
                //CargarDatosArbol("Persona 8, ", 6);
                CargarDatosArbol("Persona 3, ", 7);
                CargarDatosArbol("Persona 4, ", 8);

                CargarDatosArbol("Descripcion", 11);
                CargarDatosArbol("LugarHechos", 9);
                CargarDatosArbol("Delito", 10);

                CargarDatosArbol("PNL", 12);

                //CargarDatosArbol("NegociacionSec", 13);
                CargarDatosArbol("Defensor", 14);
                //CargarDatosArbol("Profugos", 16);
                //CargarDatosArbol("BandaDes", 17);
                //CargarDatosArbol("LiberacionSec", 18);
                //CargarDatosArbol("DetencionSec", 19);
                //CargarDatosArbol("MediaFiliacionDet", 20);
                //CargarDatosArbol("SeniasParticulares", 21);
                //CargarDatosArbol("ArmasDrogaDetSec", 22);



                // CargarDatosArbol("Audiencia", 12);
                // CargarDatosArbol("Defensor", 14);

                CargarDatosArbol("Documentos", 13);

                CargarDatosArbol("Vehiculo", 15);
                // CargarDatosArbol("Empresa", 16);
                CargarDatosArbol("BoletinRAC", 16);
                CargarDatosArbol("HistorialRac", 17);
                LLenarArbol(TVCarpeta.Nodes, 0);

                PGJ.EliminaArbol(IdUser);
            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());

            //    //lblEstatus.Text = ex.Message;

            //}
        }

        protected void CargarDatosArbol(string Carpeta, int IdPadre)
        {
            SqlDataAdapter daArbol = new SqlDataAdapter("DatosArbol" + Carpeta + " " + Convert.ToString(IdCarpeta.Text), Data.CnnCentral);
            DataSet dsArbol = new DataSet();
            daArbol.Fill(dsArbol, "Arbol");
            foreach (DataRow drArbol in dsArbol.Tables["Arbol"].Rows)
            {
                PGJ.InsertaArbol(Id++, IdPadre, drArbol["Nodo"].ToString(), drArbol["URL"].ToString(), drArbol["Icon"].ToString(), Convert.ToInt32(Session["IdUsuario"].ToString()));
            }
            daArbol.Dispose();
            dsArbol.Dispose();

        }

        protected void LLenarArbol(TreeNodeCollection Nodo, int IdPadre)
        {

            int IdUser;
            IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());

            int EsteId;
            string EsteNombre;

            SqlDataAdapter daArbol = new SqlDataAdapter("select * from PGJ_ARBOL where IdUsuario=" + Convert.ToString(IdUser), Data.CnnCentral);
            DataSet dsArbol = new DataSet();

            daArbol.Fill(dsArbol, "Arbol");

            foreach (DataRow drArbol in dsArbol.Tables["Arbol"].Select("Idpadre=" + Convert.ToString(IdPadre)))
            {
                EsteId = Convert.ToInt32(drArbol["Id"].ToString());
                EsteNombre = drArbol["Nodo"].ToString();

                TreeNode NuevoNodo = new TreeNode(EsteNombre, EsteId.ToString(), drArbol["Icon"].ToString());
                NuevoNodo.NavigateUrl = drArbol["URL"].ToString();
                Nodo.Add(NuevoNodo);
                LLenarArbol(NuevoNodo.ChildNodes, EsteId);
            }
        }


        protected void ImgSi_Click(object sender, ImageClickEventArgs e)
        {
            lblMsjCanalizar.Visible = true;
            //SqlCommand sqlCanalizada = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_RAC=2" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlCanalizada.ExecuteReader();
            //rdC.Close();

            //string CAD;
            //CAD = "set dateformat dmy INSERT INTO PGJ_RAC_CANALIZADA(ID_CARPETA,ID_MUNICIPIO_CANALIZADA,ID_INSTITUCION,ID_USUARIO,FECHA_REGISTRO)";
            //CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlInstitucion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaCanalizar.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlGuardarCanalizada = new SqlCommand(CAD, Data.CnnCentral);
            //SqlDataReader rdGuardaCanalizada = sqlGuardarCanalizada.ExecuteReader();

            //rdGuardaCanalizada.Close();
            PGJ.InsertaRacCanalizada(int.Parse(Session["ID_CARPETA"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlInstitucion.SelectedValue.ToString()), int.Parse(Session["IdUsuario"].ToString()));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton CANALIZAR Institucion:" + ddlInstitucion.SelectedItem + " Fecha Canalizar: " + txtFechaCanalizar.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 2);
        }

        protected void ImgSi1_Click(object sender, ImageClickEventArgs e)
        {
            dcOrientacionDataContext validar = new dcOrientacionDataContext();
            int x = 0;

            x = validar.VALIDAR_NUM_INICIADA(int.Parse(Session["ID_CARPETA"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), 2);
            if (x == 0)
            {
                //SqlCommand sqlSuspender = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=3 , ACTIVO_NUM='TRUE' , FECHA_ESTADO_RAC='" + txtFechaSuspender.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                //SqlDataReader rdC = sqlSuspender.ExecuteReader();
                //rdC.Close();

                //string CAD;
                //CAD = "set dateformat dmy INSERT INTO PGJ_RAC_SUSPENDIDA(ID_CARPETA,ID_MUNICIPIO_SUSPENDIDA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlCentroMediacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaSuspender.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                //SqlCommand sqlGuardarSuspendida = new SqlCommand(CAD, Data.CnnCentral);
                //SqlDataReader rdGuardaSusupendida = sqlGuardarSuspendida.ExecuteReader();

                //rdGuardaSusupendida.Close();

                //string CAD2;
                //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_INICIADA(ID_CARPETA,ID_MUNICIPIO_INICIADA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlCentroMediacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaSuspender.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                //SqlCommand sqlIniciada = new SqlCommand(CAD2, Data.CnnCentral);
                //SqlDataReader rdIniciada = sqlIniciada.ExecuteReader();

                //rdIniciada.Close();

                PGJ.InsertaRacMedios(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlCentroMediacion.SelectedValue.ToString()), int.Parse(Session["IdUsuario"].ToString()));
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton MEDIOS ALTERNATIVOS Centro de Justicia:" + ddlCentroMediacion.SelectedItem + " Fecha Medios: " + txtFechaSuspender.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 22);
            }

            else if (x == 1)
            {
                //SqlCommand sqlSuspender = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=3 , ACTIVO_NUM='TRUE' , FECHA_ESTADO_RAC='" + txtFechaSuspender.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                //SqlDataReader rdC = sqlSuspender.ExecuteReader();
                //rdC.Close();

                //string CAD;
                //CAD = "set dateformat dmy INSERT INTO PGJ_RAC_SUSPENDIDA(ID_CARPETA,ID_MUNICIPIO_SUSPENDIDA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlCentroMediacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaSuspender.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                //SqlCommand sqlGuardarSuspendida = new SqlCommand(CAD, Data.CnnCentral);
                //SqlDataReader rdGuardaSusupendida = sqlGuardarSuspendida.ExecuteReader();

                //rdGuardaSusupendida.Close();

                PGJ.InsertaRacMediosOpcion(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlCentroMediacion.SelectedValue.ToString()), int.Parse(Session["IdUsuario"].ToString()));
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton MEDIOS ALTERNATIVOS Centro de Justicia:" + ddlCentroMediacion.SelectedItem + " Fecha Medios: " + txtFechaSuspender.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                //Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 3);
            }
        }

        protected void ImgSi2_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlRemitir = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=4 , ACTIVO_NUC='TRUE'  , FECHA_ESTADO_RAC='" + txtFechaRemitir.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlRemitir.ExecuteReader();
            //rdC.Close();

            //PGJ.InsertaRacRemitida(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUsuario"].ToString()), DateTime.Parse(txtFechaRemitir.Text));

            //string CAD;
            //CAD = "set dateformat dmy INSERT INTO PGJ_RAC_REMITIDA(ID_CARPETA,ID_MUNICIPIO_REMITIDA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlUnidadInvestigacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemitir.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlGuardarRemitida = new SqlCommand(CAD, Data.CnnCentral);
            //SqlDataReader rdGuardaRemitida = sqlGuardarRemitida.ExecuteReader();

            //rdGuardaRemitida.Close();

            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_TRAMITE(ID_CARPETA,ID_MUNICIPIO_TRAMITE,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlUnidadInvestigacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemitir.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();

            PGJ.InsertaRacRemitida(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUsuario"].ToString()), DateTime.Parse("01/01/1900 00:00"));

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton DERIVADA", int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 4);
        }

        protected void ImgSi3_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlResolver = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=5 , FECHA_ESTADO_RAC='" + txtFechaResolvio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlResolver.ExecuteReader();
            //rdC.Close();

            //string CAD;
            //CAD = "set dateformat dmy INSERT INTO PGJ_RAC_RESUELTA(ID_CARPETA,ID_MUNICIPIO_RESUELTA,RESOLVIO,ID_USUARIO,FECHA_REGISTRO)";
            //CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + ",'" + txtResolvio.Text + "'," + Session["IdUsuario"].ToString() + ",'" + txtFechaResolvio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlGuardarResuelta = new SqlCommand(CAD, Data.CnnCentral);
            //SqlDataReader rdGuardaResuelta = sqlGuardarResuelta.ExecuteReader();

            //rdGuardaResuelta.Close();

            PGJ.InsertaRacResolvio(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()),txtResolvio.Text,short.Parse(Session["IdUsuario"].ToString()));

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton DERIVADA", int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 5);
        }

        protected void ImgSi5_Click(object sender, ImageClickEventArgs e)
        {
            dcOrientacionDataContext validar = new dcOrientacionDataContext();
            int x = 0;

            x = validar.VALIDAR_PGJ_CARPETA_RAC(txtNumero.Text, txtAño.Text, 2);
            if (x == 0)
            {


                PGJ.GenerarNC(IdCarpeta.Text,"RAC", short.Parse(Session["IdMunicipio"].ToString()), txtNumero.Text, txtAño.Text, short.Parse(Session["IdUnidad"].ToString()));
                PGJ.InsertaRAC_Orientacion(Data.RAC, DateTime.Parse(txtFechaInicio.Text), 1, DateTime.Parse(txtFechaInicio.Text), short.Parse(Session["IdUsuario"].ToString()), int.Parse(IdCarpeta.Text));

                SqlCommand sqlResolver = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_RAC=1" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlResolver.ExecuteReader();
                rdC.Close();

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 1);
            }

            else if (x == 1)
            {
                lblError.Text = "EL REGISTRO YA EXISTE";
            }

        }

        protected void ImgNo5_Click(object sender, ImageClickEventArgs e)
        {
            Panel6.Visible = false;
        }

        protected void Iniciar_Click(object sender, ImageClickEventArgs e)
        {
            Panel6.Visible = true;
        }

        protected void ImgSi7_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlIncompetencia = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=18 , FECHA_ESTADO_RAC='" + txtFechaIncompetencia.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlIncompetencia.ExecuteReader();
            //rdC.Close();

            //string CAD;
            //CAD = "set dateformat dmy INSERT INTO PGJ_RAC_INCOMPETENCIA(ID_CARPETA,ID_MUNICIPIO_INCOMPETENCIA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO,ID_AGENCIA)";
            //CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIncompetencia.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))," + ddlAgencia.SelectedValue + ")";

            //SqlCommand sqlGuardarIncompetencia = new SqlCommand(CAD, Data.CnnCentral);
            //SqlDataReader rdGuardaIncompetencia = sqlGuardarIncompetencia.ExecuteReader();

            //rdGuardaIncompetencia.Close();

            PGJ.InsertaRacIncompetencia(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()), short.Parse(ddlAgencia.SelectedValue));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton INCOMPETENCIA Unidad:" + ddlAgencia.SelectedItem + " Fecha Incompetencia: " + txtFechaIncompetencia.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 18);
        }

        protected void Canalizar_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = true;
            Panel6.Visible = false;
            Panel2.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void Suspender_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void Incompetencia_Click(object sender, ImageClickEventArgs e)
        {
            Panel7.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void Remitir_Click(object sender, ImageClickEventArgs e)
        {

            Panel7.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel3.Visible = true;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void Resolver_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = true;
            Panel3.Visible = false;
            Panel7.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void ImgNo_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void ImgNo1_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void ImgNo2_Click(object sender, ImageClickEventArgs e)
        {
            Panel3.Visible = false;
        }

        protected void ImgNo3_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = false;
        }

        protected void ImgNo7_Click(object sender, ImageClickEventArgs e)
        {
            Panel7.Visible = false;
        }

        protected void ImgNo8_Click(object sender, ImageClickEventArgs e)
        {
            Panel8.Visible = false;
        }

        protected void ImgNo9_Click(object sender, ImageClickEventArgs e)
        {
            Panel9.Visible = false;
        }

        protected void ImgNo10_Click(object sender, ImageClickEventArgs e)
        {
            Panel10.Visible = false;
        }

        protected void cmdConvenio_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel2.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = true;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void cmdNoConvenio_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel2.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = true;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void cmdConvenioIncompleto_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel2.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = true;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void ImgSi8_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlConvenio = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_RAC=19 , FECHA_ESTADO_RAC='" + txtFechaConvenio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlConvenio.ExecuteReader();
            rdC.Close();

            string CAD;
            CAD = "INSERT INTO PGJ_RAC_CONVENIO(ID_CARPETA,ID_MUNICIPIO_CONVENIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaConvenio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlGuardarConvenio = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdGuardaConvenio = sqlGuardarConvenio.ExecuteReader();

            rdGuardaConvenio.Close();
            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 19);
        }

        protected void ImgSi9_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlNoConvenio = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_RAC=20 , FECHA_ESTADO_RAC='" + txtFechaNoConvenio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlNoConvenio.ExecuteReader();
            rdC.Close();

            string CAD;
            CAD = "INSERT INTO PGJ_RAC_NO_CONVENIO(ID_CARPETA,ID_MUNICIPIO_NO_CONVENIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaNoConvenio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlGuardarNoConvenio = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdGuardaNoConvenio = sqlGuardarNoConvenio.ExecuteReader();

            rdGuardaNoConvenio.Close();
            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 20);
        }

        protected void ImgSi10_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlConvenioIncumplido = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_RAC=21 , FECHA_ESTADO_RAC='" + txtFechaConvenioIncumplido.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlConvenioIncumplido.ExecuteReader();
            rdC.Close();

            string CAD;
            CAD = "INSERT INTO PGJ_RAC_CONVENIO_INCUMPLIDO(ID_CARPETA,ID_MUNICIPIO_CONVENIO_INCUMPLIDO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaConvenioIncumplido.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlGuardarConvenioIncumplido = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdGuardaConvenioIncumplido = sqlGuardarConvenioIncumplido.ExecuteReader();

            rdGuardaConvenioIncumplido.Close();
            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 21);
        }

        protected void Archivo_Click(object sender, ImageClickEventArgs e)
        {
            Panel11.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void Ejercicio_Click(object sender, ImageClickEventArgs e)
        {
            Panel12.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel13.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void Acuerdo_Click(object sender, ImageClickEventArgs e)
        {
            Panel13.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            PanelAcumular.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlArchivo = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=12  , FECHA_ESTADO_RAC='" + txtFechaArchivo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlArchivo.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            //Judicializar.Enabled = true;
            //Archivo.Enabled = false;
            //Ejercicio.Enabled = true;
            //Criterio.Enabled = true;



            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_RAC_ARCHIVO_TEMPORAL(ID_CARPETA,ID_MUNICIPIO_ARCHIVO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaArchivo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();

            PGJ.InsertaRacArchivoTemporal(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton ARCHIVO TEMPORAL " + " Fecha Archivo: " + txtFechaArchivo.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 12);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Panel11.Visible = false;
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlNoEjercicio = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=13  , FECHA_ESTADO_RAC='" + txtFechaEjercicio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlNoEjercicio.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            //Judicializar.Enabled = false;
            //Archivo.Enabled = false;
            //Ejercicio.Enabled = false;
            //Criterio.Enabled = false;


            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_RAC_NO_EJERCICIO(ID_CARPETA,ID_MUNICIPIO_EJERCICIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaEjercicio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();

            PGJ.InsertaRacNoEjercicio(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton NO EJERCICIO " + " Fecha NO Ejercicio: " + txtFechaEjercicio.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 13);

        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Panel12.Visible = false;
        }

        protected void ImgSi5_Click1(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_RAC=17 , FECHA_ESTADO_RAC='" + txtFechaAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlOportunidad.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            //Judicializar.Enabled = false;
            //Archivo.Enabled = false;
            //Ejercicio.Enabled = false;
            //Criterio.Enabled = false;
            //Acuerdo.Enabled = false;
            //Incompetencia.Enabled = false;


            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_RAC_ACUERDO_ABS_INV(ID_CARPETA,ID_MUNICIPIO_ACUERDO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();
            PGJ.InsertaRacAbstenerse(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton ACUERDO PARA ABSTENERSE " + " Fecha Acuerdo: " + txtFechaAcuerdo.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 17);
        }

        private void CargarBoletinPDF(string id_pdf)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Boletín IdPdf=" + id_pdf + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
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
            fsB = new FileStream(Server.MapPath(".") +
            @"\DocTmp\" + sFile, FileMode.Create);
            //Y escribimos en disco el array de bytes que conforman
            //el fichero Word 
            fsB.Write(bits, 0, Convert.ToInt32(bits.Length));
            fsB.Close();
            //Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
            ///*tecleo mi dominio o IP*/
            //String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
            //ruta_pdf = ruta_pdf.Replace("\\", "/");
            string script = "<script languaje='javascript'> ";
            script += "mostrarFichero('DocTmp/tmp.pdf') ";
            script += "</script>" + Environment.NewLine;
            Page.RegisterStartupScript("mostrarFichero", script);

        }

        protected void Acumular_Click(object sender, ImageClickEventArgs e)
        {

            Panel1.Visible = false;
            Panel6.Visible = false;
            Panel2.Visible = false;
            Panel7.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Panel13.Visible = false;

            lblMsjAcumular.Visible = true;
            PanelAcumular.Visible = true;
        }

        protected void SiAcumular_Click(object sender, ImageClickEventArgs e)
        {
            Label20.Text = "";
            lblMensajeE.Visible = true;
            lblMensajeE.Text = "";
            if (string.IsNullOrEmpty(txtNumeroAcumular.Text))
            {
                lblMensajeE.Text = "NÚMERO NO PUEDE ESTAR VACIO.";
            }
            if (string.IsNullOrEmpty(txtAnioAcumular.Text))
            {
                lblMensajeE.Text = "AÑO NO PUEDE ESTAR VACIO.";
            }

            if (lblMensajeE.Text == "")
            {
                //saber si existe el expediente a acumular
                SqlCommand sqlAcumular = new SqlCommand("COMBO_RAC_PARA_ACUMULAR_POR_FECHA_RAC1 " + int.Parse(Session["ID_CARPETA"].ToString()) + "," + int.Parse(Session["IdUnidad"].ToString())
                    + "," + txtNumeroAcumular.Text + "," + txtAnioAcumular.Text, Data.CnnCentral);
                SqlDataReader drAcumular = sqlAcumular.ExecuteReader();
                if (drAcumular.HasRows)
                {
                    drAcumular.Read();

                    lblIdCarpetaAcumular.Text = drAcumular["ID_CARPETA"].ToString();
                }
                drAcumular.Close();

                if (string.IsNullOrEmpty(lblIdCarpetaAcumular.Text))
                {
                    Label20.Visible = true;
                    Label20.Text = "NO SE PUEDE ACUMULAR AL EXPEDIENTE: " + txtNumeroAcumular.Text + "/" + txtAnioAcumular.Text;
                }
                else
                {
                    PGJ.InsertaRacAcumulada(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(lblIdCarpetaAcumular.Text), int.Parse(Session["IdUsuario"].ToString()));
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton ACUMULAR RAC Fecha: IdCarpeta=" + Session["ID_CARPETA"] + " IdCarpetaContendra= " + lblIdCarpetaAcumular.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                    Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + 32);
                }

            }
        }

        protected void NoAcumular_Click(object sender, ImageClickEventArgs e)
        {
            PanelAcumular.Visible = false;
        }

    }
}