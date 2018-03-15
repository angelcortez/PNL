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
    public partial class NUC_SECUESTRO : System.Web.UI.Page
    {
        Data PGJ = new Data();
        DataTable dtArbol = new DataTable();
        int Id = 25;
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.pdf";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["lblArbol"] = lblArbol.Text;
                Session["op"] = Request.QueryString["op"];

                Session["IdDoc"] = Request.QueryString["IdDoc"];

                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                //Session.Add("NUC", Request.QueryString["NUC"]);

                Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                Session["ID_ESTADO_NUC"] = Request.QueryString["ID_ESTADO_NUC"];
                ID_ESTADO_NUC.Text = Session["ID_ESTADO_NUC"].ToString();
                //Data.IdCarpeta = Convert.ToInt32(Session["ID_CARPETA"].ToString());
                CargarDatosCarpeta();
                try
                {
                    PGJ.CargaCombo(ddlAgencia, "CAT_AGENCIA", "ID_AGENCIA", "AGENCIA");
                    PGJ.CargaComboFiltrado(ddlCentroMediacion, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "ID_UNDD_TPO=3 and ID_MNCPIO=" + Session["IdMunicipio"].ToString());

                }
                catch (Exception ex)
                {
                    Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                    //lblEstatus.Text = ex.Message;

                }

                //LLenarArbol(TVCarpeta.Nodes, 0);

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
                    CargarDocumentoAudiencia(Session["IdDoc"].ToString());
                }

                if (Session["ID_ESTADO_NUC"].ToString() == "0")
                {
                    Iniciar.Enabled = true;
                    Judicializar.Enabled = false;
                    Archivo.Enabled = false;
                    Ejercicio.Enabled = false;
                    Medios.Enabled = false;
                    Criterio.Enabled = false;
                    TVCarpeta.Enabled = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;

                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "10")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = true;
                    Archivo.Enabled = true;
                    Ejercicio.Enabled = true;
                    Criterio.Enabled = true;
                    Medios.Enabled = true;
                    TVCarpeta.Enabled = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "11")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = false;
                    Archivo.Enabled = false;
                    Ejercicio.Enabled = false;
                    Criterio.Enabled = false;
                    Medios.Enabled = false;
                    TVCarpeta.Enabled = true;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "12")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = true;
                    Archivo.Enabled = true;
                    Ejercicio.Enabled = true;
                    Criterio.Enabled = true;
                    Medios.Enabled = true;
                    TVCarpeta.Enabled = true;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "13")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = true;
                    Archivo.Enabled = true;
                    Ejercicio.Enabled = false;
                    Criterio.Enabled = true;
                    Medios.Enabled = true;
                    TVCarpeta.Enabled = true;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "14")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = true;
                    Archivo.Enabled = true;
                    Ejercicio.Enabled = true;
                    Criterio.Enabled = false;
                    Medios.Enabled = true;
                    TVCarpeta.Enabled = true;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "17")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = true;
                    Archivo.Enabled = true;
                    Ejercicio.Enabled = true;
                    Criterio.Enabled = true;
                    Incompetencia.Enabled = true;
                    Acuerdo.Enabled = false;
                    Medios.Enabled = true;
                    TVCarpeta.Enabled = true;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "18")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = true;
                    Archivo.Enabled = true;
                    Ejercicio.Enabled = true;
                    Criterio.Enabled = true;
                    Incompetencia.Enabled = false;
                    Acuerdo.Enabled = true;
                    Medios.Enabled = true;
                    TVCarpeta.Enabled = true;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "22")
                {
                    Iniciar.Enabled = false;
                    Judicializar.Enabled = true;
                    Archivo.Enabled = true;
                    Ejercicio.Enabled = true;
                    Criterio.Enabled = true;
                    Incompetencia.Enabled = false;
                    Acuerdo.Enabled = true;
                    Medios.Enabled = true;
                    TVCarpeta.Enabled = true;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    Panel7.Visible = false;
                    Panel8.Visible = false;
                    Panel9.Visible = false;
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

        //protected void CargarDatosCarpeta()
        //{
        //    dtArbol.Columns.Add("Id");
        //    dtArbol.Columns.Add("IdPadre");
        //    dtArbol.Columns.Add("Nodo");
        //    dtArbol.Columns.Add("URL");
        //    dtArbol.Columns.Add("Icon");
        //    dtArbol.Rows.Add(1, 0, "CARPETA", "", "");
        //    dtArbol.Rows.Add(2, 1, "RAC", "", "");
        //    dtArbol.Rows.Add(3, 1, "NUM", "", "");
        //    dtArbol.Rows.Add(4, 1, "NUC", "", "");
        //    //dtArbol.Rows.Add(4, 0, "NAC","", "");
        //    dtArbol.Rows.Add(5, 1, "DENUNCIANTE", "Datos.aspx?&op=Agregar", "");
        //    dtArbol.Rows.Add(6, 1, "OFENDIDO", "QuienResulteOfendido.aspx", "");
        //    dtArbol.Rows.Add(7, 1, "IMPUTADO", "QuienResulteResponsable.aspx", "");

        //    dtArbol.Rows.Add(9, 1, "LUGAR DE HECHOS", "LugarHechos.aspx?&op=Agregar", "");
        //    dtArbol.Rows.Add(8, 1, "DELITO", "", "");
        //    dtArbol.Rows.Add(10, 1, "AGREGAR DESCRIPCION DE HECHOS", "Hechos.aspx?&op=Agregar", "");
        //    dtArbol.Rows.Add(11, 1, "AGREGAR SOLICITUD DE AUDIENCIA", "Solicitudes.aspx?&op=Agregar", "");
        //    CargarDatosArbol("RAC", 2);
        //    CargarDatosArbol("NUM", 3);
        //    CargarDatosArbol("NUC", 4);
        //    CargarDatosArbol("Persona 1, ", 5);
        //    CargarDatosArbol("Persona 2, ", 6);
        //    CargarDatosArbol("Persona 8, ", 6);
        //    CargarDatosArbol("Persona 3, ", 7);
        //    CargarDatosArbol("Delito", 8);
        //    CargarDatosArbol("LugarHechos", 9);
        //}

        //protected void CargarDatosArbol(string Carpeta, int IdPadre)
        //{
        //    SqlDataAdapter daArbol = new SqlDataAdapter("DatosArbol" + Carpeta + " " + Convert.ToString(IdCarpeta.Text ), Data.CnnCentral);
        //    DataSet dsArbol = new DataSet();
        //    daArbol.Fill(dsArbol, "Arbol");
        //    foreach (DataRow drArbol in dsArbol.Tables["Arbol"].Rows)
        //    {
        //        dtArbol.Rows.Add(Id++, IdPadre, drArbol["Nodo"].ToString(), drArbol["URL"].ToString(), drArbol["Icon"].ToString());
        //    }
        //    daArbol.Dispose();
        //    dsArbol.Dispose();

        //}

        //protected void LLenarArbol(TreeNodeCollection Nodo, int IdPadre)
        //{
        //    int EsteId;
        //    string EsteNombre;

        //    foreach (DataRow drArbol in dtArbol.Select("Idpadre=" + Convert.ToString(IdPadre)))
        //    {
        //        EsteId = Convert.ToInt32(drArbol["Id"].ToString());
        //        EsteNombre = drArbol["Nodo"].ToString();

        //        TreeNode NuevoNodo = new TreeNode(EsteNombre, EsteId.ToString(), drArbol["Icon"].ToString());
        //        NuevoNodo.NavigateUrl = drArbol["URL"].ToString();
        //        Nodo.Add(NuevoNodo);
        //        LLenarArbol(NuevoNodo.ChildNodes, EsteId);
        //    }
        //}

        protected void CargarDatosCarpeta()
        {
            try
            {
                int IdUser;
                IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());

                PGJ.InsertaArbol(1, 0, "CARPETA", "", "", IdUser);
               // PGJ.InsertaArbol(2, 1, "RAC", "", "", IdUser);
               // PGJ.InsertaArbol(3, 1, "NUM", "", "", IdUser);
                PGJ.InsertaArbol(4, 1, "NUC", "", "", IdUser);

                PGJ.InsertaArbol(5, 1, "DENUNCIANTE", "Datos.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(6, 1, "OFENDIDO", "QuienResulteOfendido.aspx", "", IdUser);
             //   PGJ.InsertaArbol(16, 1, "EMPRESA", "EmpreaOfendida.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(7, 1, "IMPUTADO", "QuienResulteResponsable.aspx", "", IdUser);
                PGJ.InsertaArbol(19, 1, "DATOS DE LA DETENCIÓN", "DatosDetenidoPI.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(20, 1, "MEDIA FILIACIÓN DETENIDO", "MediaFiliacionDetenido.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(21, 1, "SEÑAS PARTICULARES DETENIDO", "SeñasParticularesDetenido.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(22, 1, "OBJETOS, ARMAS Y DROGAS", "RegistrarDetencion.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(8, 1, "TESTIGO", "Datos.aspx?&op=AgregarTes", "", IdUser);
               // PGJ.InsertaArbol(14, 1, "DEFENSOR", "DefensorPublico.aspx", "", IdUser);
                PGJ.InsertaArbol(9, 1, "LUGAR DE HECHOS", "LugarHechos.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(10, 1, "DELITO", "", "", IdUser);
                PGJ.InsertaArbol(15, 1, "VEHICULOS", "Vehiculo.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(11, 1, "DESCRIPCION HECHOS", "Hechos.aspx?&op=Agregar", "", IdUser);
               // PGJ.InsertaArbol(12, 1, "SOLICITUDES DE AUDIENCIA", "Solicitudes.aspx?&op=Agregar", "", IdUser);

                PGJ.InsertaArbol(12, 1, "DATOS COMPLEMENTARIOS DEL SECUESTRO", "DatosPrincipalesSec.aspx?&op=Agregar", "", IdUser);

                PGJ.InsertaArbol(13, 1, "NEGOCIACIÓN", "AgregarNegociacionSec.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(14, 1, "DETENIDOS", "DatosPrincipalesSec.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(16, 1, "PRÓFUGOS", "AgregarProfugoSec.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(17, 1, "BANDAS DESARTICULADAS", "AgregarBandaDesartSec.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(18, 1, "LIBERACIÓN", "LiberacionSec.aspx?&op=Agregar", "", IdUser);
               

               // PGJ.InsertaArbol(13, 1, "ACTUACIONES", "DocPdf.aspx?op=Agregar", "", IdUser);


               // CargarDatosArbol("RAC", 2);
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
                
                CargarDatosArbol("Secuestro", 12);
                CargarDatosArbol("NegociacionSec", 13);
                //CargarDatosArbol("Detenidos", 14);
                CargarDatosArbol("Profugos", 16);
                CargarDatosArbol("BandaDes", 17);
                CargarDatosArbol("LiberacionSec", 18);
                CargarDatosArbol("DetencionSec", 19);
                CargarDatosArbol("MediaFiliacionDet", 20);
                CargarDatosArbol("SeniasParticulares", 21);
                CargarDatosArbol("ArmasDrogaDetSec", 22);


                
                   // CargarDatosArbol("Audiencia", 12);
                   // CargarDatosArbol("Defensor", 14);
                
               // CargarDatosArbol("Documentos", 13);

                CargarDatosArbol("Vehiculo", 15);
               // CargarDatosArbol("Empresa", 16);
                LLenarArbol(TVCarpeta.Nodes, 0);

                PGJ.EliminaArbol(IdUser);
            }
            catch (Exception ex)
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());

                //lblEstatus.Text = ex.Message;

            }
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
            dcOrientacionDataContext validar = new dcOrientacionDataContext();
            int x = 0;

            x = validar.VALIDAR_PGJ_CARPETA_NUC("28", Session["IdMunicipio"].ToString(), Session["IdUnidad"].ToString(), txtNumero.Text, txtAño.Text, 2);
            if (x == 0)
            {
                // PGJ.GenerarNC("NUC", short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));

                PGJ.GenerarNC(IdCarpeta.Text,"NUC", short.Parse(Session["IdMunicipio"].ToString()), txtNumero.Text, txtAño.Text, short.Parse(Session["IdUnidad"].ToString()));
                PGJ.InsertaNUC(Data.NUC, DateTime.Parse(txtFechaInicio.Text), 10, DateTime.Parse(txtFechaInicio.Text), short.Parse(Session["IdUsuario"].ToString()), int.Parse(IdCarpeta.Text));


                SqlCommand sqlIniciar = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=10" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlIniciar.ExecuteReader();
                rdC.Close();

                //string CAD2;
                //CAD2 = "INSERT INTO PGJ_NUC_TRAMITE(ID_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

                //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
                //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

                //rdTramite.Close();
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 10);
            }

            else if (x == 1)
            {
                lblError.Text = "EL REGISTRO YA EXISTE";
            }

        }

        protected void ImgSi1_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlConsignar = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=11 , FECHA_ESTADO_NUC='" + txtFechaJuducualizar.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlConsignar.ExecuteReader();
            rdC.Close();


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_CONSIGNADA(ID_CARPETA,ID_MUNICIPIO_CONSIGNADA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaJuducualizar.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();

            Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 11);

            Iniciar.Enabled = false;
            Judicializar.Enabled = false;
            Archivo.Enabled = false;
            Ejercicio.Enabled = false;
            Criterio.Enabled = false;
        }

        protected void ImgSi2_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlArchivo = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=12  , FECHA_ESTADO_NUC='" + txtFechaArchivo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlArchivo.ExecuteReader();
            rdC.Close();

            Iniciar.Enabled = false;
            //Judicializar.Enabled = true;
            //Archivo.Enabled = false;
            //Ejercicio.Enabled = true;
            //Criterio.Enabled = true;



            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_ARCHIVO_TEMPORAL(ID_CARPETA,ID_MUNICIPIO_ARCHIVO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaArchivo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();

            Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 12);
        }

        protected void ImgSi3_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlNoEjercicio = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=13  , FECHA_ESTADO_NUC='" + txtFechaEjercicio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlNoEjercicio.ExecuteReader();
            rdC.Close();

            Iniciar.Enabled = false;
            //Judicializar.Enabled = false;
            //Archivo.Enabled = false;
            //Ejercicio.Enabled = false;
            //Criterio.Enabled = false;


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_NO_EJERCICIO(ID_CARPETA,ID_MUNICIPIO_EJERCICIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaEjercicio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();

            Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 13);

        }

        protected void ImgSi4_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=14 , FECHA_ESTADO_NUC='" + txtFechaCriterio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlOportunidad.ExecuteReader();
            rdC.Close();

            Iniciar.Enabled = false;
            //Judicializar.Enabled = true;
            //Archivo.Enabled = true;
            //Ejercicio.Enabled = true;
            //Criterio.Enabled = false;


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_CRITERIO_OPORTUNIDAD(ID_CARPETA,ID_MUNICIPIO_CRITERIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaCriterio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 14);

        }



        protected void ImgNo_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void Iniciar_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
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



        protected void ImgNo4_Click(object sender, ImageClickEventArgs e)
        {
            Panel5.Visible = false;
        }



        //protected void cmdDigital_Click(object sender, EventArgs e)
        //{
        //    Session["op"] = " ";
        //    Response.Redirect("CarpetaDigital.aspx?op=Agregar");
        //}


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

        //        protected void gvDigital_RowCommand(object sender, GridViewCommandEventArgs e)
        //        {
        //            try
        //            {
        //                if (e.CommandName == "Select")
        //                {
        //                    int index = int.Parse(e.CommandArgument.ToString());
        //                    GridViewRow row = gvDigital.Rows[index];
        //                    String id_digital = row.Cells[0].Text;
        //                    PGJ.ConnectServer();
        //                    SqlCommand comm = new SqlCommand("SELECT * from pgj_carpeta_digital  WHERE id_digital = " + id_digital, Data.CnnCentral);
        //                    comm.CommandType = CommandType.Text;
        //                    SqlDataAdapter da = new SqlDataAdapter(comm);
        //                    DataSet ds = new DataSet("Binarios");
        //                    da.Fill(ds);
        //                    //Creamos un array de bytes que contiene los bytes almacenados
        //                    //en el campo Documento de la tabla
        //                    byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[2]));
        //                    //Vamos a guardar ese array de bytes como un fichero en el
        //                    //disco duro, un fichero temporal que después se podrá descartar.
        //                    string sFile = "tmp.doc";
        //                    //Creamos un nuevo FileStream, que esta vez servirá para
        //                    //crear un fichero con el nombre especificado
        //                    fs = new FileStream(Server.MapPath(".") +
        //                    @"\DocTmp\" + sFile, FileMode.Create);
        //                    //Y escribimos en disco el array de bytes que conforman
        //                    //el fichero Word 
        //                    fs.Write(bits, 0, Convert.ToInt32(bits.Length));
        //                    fs.Close();
        //                    //Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
        //                    ///*tecleo mi dominio o IP*/
        //                    //String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
        //                    //ruta_pdf = ruta_pdf.Replace("\\", "/");
        //                    string script = "<script languaje='javascript'> ";
        //                    script += "mostrarFichero('DocTmp/tmp.doc') ";
        //                    script += "</script>" + Environment.NewLine;
        //                    Page.RegisterStartupScript("mostrarFichero", script);

        //                    //Response.Write("<script>");
        //                    //Response.Write("window.open('" + ruta_pdf + "','_blank')");
        //                    //Response.Write("</script>");


        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                //Mensajes mje = new Mensajes();
        //                //mje.alert(ex.Message);
        //                string script = @"<script type='text/javascript'>
        //                            alert('NO EXISTE DOCUMENTO');
        //                                   </script>";
        //                //script = string.Format(script, ex.Message);

        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        //            }
        //        }       



        private void CargarDocumentoAudiencia(string idSolicitud)
        {
            byte[] bits;
            try
            {
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SELECT * FROM TORRE.NSJP.STJ.Solicitud_Audiencia   WHERE Id_Solicitud = " + idSolicitud, Data.CnnCentral);
                comm.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet("Binarios");
                da.Fill(ds);
                //Creamos un array de bytes que contiene los bytes almacenados
                //en el campo Documento de la tabla
                if (ds.Tables[0].Rows[0].ItemArray[17].ToString() == "")
                {
                    bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[15]));
                }
                else
                {
                    bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[17]));
                }
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

        //        protected void gvPDF_RowCommand(object sender, GridViewCommandEventArgs e)
        //        {
        //            try
        //            {
        //                if (e.CommandName == "Select")
        //                {
        //                    int index = int.Parse(e.CommandArgument.ToString());
        //                    GridViewRow row = gvPDF.Rows[index];
        //                    String id_pdf = row.Cells[0].Text;
        //                    PGJ.ConnectServer();
        //                    SqlCommand comm = new SqlCommand("SELECT * from PGJ_CARPETA_PDF  WHERE id_pdf = " + id_pdf, Data.CnnCentral);
        //                    comm.CommandType = CommandType.Text;
        //                    SqlDataAdapter da = new SqlDataAdapter(comm);
        //                    DataSet ds = new DataSet("Binarios");
        //                    da.Fill(ds);
        //                    //Creamos un array de bytes que contiene los bytes almacenados
        //                    //en el campo Documento de la tabla
        //                    byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
        //                    //Vamos a guardar ese array de bytes como un fichero en el
        //                    //disco duro, un fichero temporal que después se podrá descartar.
        //                    string sFile = "tmp.pdf";
        //                    //Creamos un nuevo FileStream, que esta vez servirá para
        //                    //crear un fichero con el nombre especificado
        //                    fs = new FileStream(Server.MapPath(".") +
        //                    @"\DocTmp\" + sFile, FileMode.Create);
        //                    //Y escribimos en disco el array de bytes que conforman
        //                    //el fichero Word 
        //                    fs.Write(bits, 0, Convert.ToInt32(bits.Length));
        //                    fs.Close();
        //                    //Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
        //                    ///*tecleo mi dominio o IP*/
        //                    //String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
        //                    //ruta_pdf = ruta_pdf.Replace("\\", "/");
        //                    string script = "<script languaje='javascript'> ";
        //                    script += "mostrarFichero('DocTmp/tmp.pdf') ";
        //                    script += "</script>" + Environment.NewLine;
        //                    Page.RegisterStartupScript("mostrarFichero", script);

        //                    //Response.Write("<script>");
        //                    //Response.Write("window.open('" + ruta_pdf + "','_blank')");
        //                    //Response.Write("</script>");


        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                //Mensajes mje = new Mensajes();
        //                //mje.alert(ex.Message);
        //                string script = @"<script type='text/javascript'>
        //                            alert('NO EXISTE DOCUMENTO');
        //                                   </script>";
        //                //script = string.Format(script, ex.Message);

        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        //            }
        //        }





        protected void ImgNo5_Click(object sender, ImageClickEventArgs e)
        {
            Panel7.Visible = false;
        }

        protected void ImgNo6_Click(object sender, ImageClickEventArgs e)
        {
            Panel8.Visible = false;
        }

        protected void ImgSi5_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=17 , FECHA_ESTADO_NUC='" + txtFechaAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlOportunidad.ExecuteReader();
            rdC.Close();

            Iniciar.Enabled = false;
            //Judicializar.Enabled = false;
            //Archivo.Enabled = false;
            //Ejercicio.Enabled = false;
            //Criterio.Enabled = false;
            //Acuerdo.Enabled = false;
            //Incompetencia.Enabled = false;


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_ACUERDO_ABS_INV(ID_CARPETA,ID_MUNICIPIO_ACUERDO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 17);
        }

        protected void ImgSi6_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=18 , FECHA_ESTADO_NUC='" + txtFechaIncompetancia.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlOportunidad.ExecuteReader();
            rdC.Close();

            Iniciar.Enabled = false;
            //Judicializar.Enabled = false;
            //Archivo.Enabled = false;
            //Ejercicio.Enabled = false;
            //Criterio.Enabled = false;
            //Acuerdo.Enabled = false;
            //Incompetencia.Enabled = false;


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_INCOMPETENCIA(ID_CARPETA,ID_MUNICIPIO_INCOMPETENCIA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO,ID_AGENCIA)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIncompetancia.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + "," + ddlAgencia.SelectedValue + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 18);
        }

        protected void Judicializar_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
        }

        protected void Archivo_Click(object sender, ImageClickEventArgs e)
        {
            Panel3.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
        }

        protected void Ejercicio_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
        }

        protected void Acuerdo_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = true;
            Panel8.Visible = false;
            Panel9.Visible = false;
        }

        protected void Criterio_Click(object sender, ImageClickEventArgs e)
        {
            Panel5.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel1.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
        }

        protected void Incompetencia_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = true;
            Panel9.Visible = false;
        }

        protected void ImgSi7_Click(object sender, ImageClickEventArgs e)
        {



            dcOrientacionDataContext validar = new dcOrientacionDataContext();
            int x = 0;

            x = validar.VALIDAR_NUM_INICIADA(int.Parse(Session["ID_CARPETA"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), 2);
            if (x == 0)
            {

                SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=22 , FECHA_ESTADO_NUC='" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlOportunidad.ExecuteReader();
                rdC.Close();

                Iniciar.Enabled = false;

                string CAD2;
                CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_MEDIOS_ALTERNATIVOS(ID_CARPETA,ID_MUNICIPIO_MEDIOS,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
                SqlDataReader rdTramite = sqlTramite.ExecuteReader();
                rdTramite.Close();

                string CAD3;
                CAD3 = "set dateformat dmy INSERT INTO PGJ_NUM_INICIADA(ID_CARPETA,ID_MUNICIPIO_INICIADA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                CAD3 = CAD3 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlCentroMediacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                SqlCommand sqlIniciada = new SqlCommand(CAD3, Data.CnnCentral);
                SqlDataReader rdIniciada = sqlIniciada.ExecuteReader();

                rdIniciada.Close();


                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 22);

            }

            else if (x == 1)
            {
                SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=22 , ACTIVO_NUM='TRUE', FECHA_ESTADO_NUC='" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlOportunidad.ExecuteReader();
                rdC.Close();

                Iniciar.Enabled = false;

                string CAD2;
                CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_MEDIOS_ALTERNATIVOS(ID_CARPETA,ID_MUNICIPIO_MEDIOS,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
                SqlDataReader rdTramite = sqlTramite.ExecuteReader();

                //se quita pgj_num _iniciada para que no se duplique
                rdTramite.Close();

                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 22);

            }

        }

        protected void ImgNo7_Click(object sender, ImageClickEventArgs e)
        {
            Panel9.Visible = false;
        }



        protected void Medios_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = true;
        }



    }
}