using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;

namespace AtencionTemprana
{
    public partial class NUC_PNL : System.Web.UI.Page
    {
        Data PGJ = new Data();
        DataTable dtArbol = new DataTable();
        int Id = 25;
        FileStream fs;
        FileStream fsB;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.pdf";

        int ContadorBoton = 0;
        public static SqlConnection CnnPNL;

        string NUC;
        string RAC;
        string NUCSIN;
        string RACSIN;

        string TotalLH1;
        string TotalD;
        string IdLugarHecho;
        string TotalIdLH;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {

                IdP.Text =Session["ID_PUESTO"].ToString();

                if (IdP.Text == "1" || IdP.Text == "2") 
                {
                    Remitir.Visible = true;
                }


                Session["lblArbol"] = lblArbol.Text;
           
                Session["op"] = Request.QueryString["op"];

                Session["IdDoc"] = Request.QueryString["IdDoc"];
                Session["IdDo"] = Request.QueryString["IdDo"];

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

                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto el NUC IdCarpeta=" + IdCarpeta.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            

                CargarDatosCarpeta();
                try
                {
                    PGJ.CargaCombo(ddlAgencia, "CAT_AGENCIA", "ID_AGENCIA", "AGENCIA");
                    PGJ.CargaComboFiltrado(ddlCentroMediacion, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "ID_UNDD_TPO=3 and ID_MNCPIO=" + Session["IdMunicipio"].ToString());

                    PGJ.CargaComboFiltrado(DDUnidades, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO = 1) AND (ALIAS LIKE '%PNL%') AND ID_UNDD!=" + Session["IdUnidad"].ToString());
                    // PGJ.CargaComboFiltrado(DDUnidades, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO = 1) AND (ALIAS LIKE '%PNL%')");
                }
                catch (Exception ex)
                {
                    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                    //lblEstatus.Text = ex.Message;

                }

                //LLenarArbol(TVCarpeta.Nodes, 0);

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
                    CargarDocumentoAudiencia(Session["IdDoc"].ToString());
                }

                if (Session["op"].ToString() == "Doc")
                {
                    CargarBoletinPDF(Session["IdDo"].ToString());
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "10")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = true;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "11")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "12")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "13")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "14")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "17")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "18")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "22")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if ((Convert.ToInt16(Session["ID_ESTADO_NUC"].ToString()) >= 111) & (Convert.ToInt16(Session["ID_ESTADO_NUC"].ToString()) <= 124))
                //else if (Session["ID_ESTADO_NUC"].ToString() == "111")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "112")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "113")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "114")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "115")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "116")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "117")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "118")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "119")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "120")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }

                else if (Session["ID_ESTADO_NUC"].ToString() == "121")
                {
                    Iniciar.Visible = false;
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
                    Panel10.Visible = false;
                    PanelAcumular.Visible = false;
                    Acumular.Visible = false;
                }
                else if (Session["ID_ESTADO_NUC"].ToString() == "32")
                {
                    Iniciar.Visible = false;
                    Judicializar.Enabled = false;
                    Archivo.Enabled = false;
                    Ejercicio.Enabled = false;
                    Criterio.Enabled = false;
                    Incompetencia.Enabled = false;
                    Acuerdo.Enabled = false;
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
                    Panel10.Visible = false;
                }


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

                //if (TotalLH1 == "0")
                //{
                //    Response.Redirect("LugarHechos.aspx?&op=Agregar");
                //}

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


                //if (TotalD == "0")
                //{
                //    //obtener el IdLugarHechos
                //    SqlCommand sqlIdLH = new SqlCommand("SPLugarHechoId", Data.CnnCentral);
                //    sqlIdLH.CommandType = CommandType.StoredProcedure;
                //    sqlIdLH.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                //    sqlIdLH.Parameters.Add("@IdMunicipio", SqlDbType.Int);

                //    sqlIdLH.Parameters["@IdCarpeta"].Value = int.Parse(IdCarpeta.Text);
                //    sqlIdLH.Parameters["@IdMunicipio"].Value = int.Parse(Session["IdMunicipio"].ToString());

                //    SqlDataReader drIdLG = sqlIdLH.ExecuteReader();
                //    if (drIdLG.HasRows)
                //    {
                //        drIdLG.Read();
                //        TotalIdLH = drIdLG["ID_LUGAR_HECHOS"].ToString();

                //    }
                //    drIdLG.Close();


                //    Response.Redirect("LugarHechos.aspx?ID_LUGAR_HECHOS=" + TotalIdLH + "&op=Modificar");
                //}

                if (TotalLH1 == "0" && TotalD == "0")
                {

                    Response.Redirect("UnidadPNL.aspx");
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

        bool TieneRegistros(string Tabla)
        {
            string Sql = "select * from " + Tabla + " where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand Cmd = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                return true;
            }
            DR.Close();
            return false;
        }

        protected void CargarDatosCarpeta()
        {
            //try
            //{
                int IdUser;
                IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());

                //Para cargar orden y/o sentencias 
                bool TieneOrdenes = TieneRegistros("PGJ_NUC_JUD_ORDENES");
                bool TieneSentencia = TieneRegistros("PGJ_NUC_JUD_SENTENCIA");

                PGJ.InsertaArbol(1, 0, "CARPETA", "", "", IdUser);
                PGJ.InsertaArbol(2, 1, "RAC", "", "", IdUser);
                // PGJ.InsertaArbol(3, 1, "NUM", "", "", IdUser);
                PGJ.InsertaArbol(4, 1, "NUC", "WebHojadeAtencion.aspx", "", IdUser);


                //if ((Session["ID_ESTADO_NUC"].ToString() == "117") || (Session["ID_ESTADO_NUC"].ToString() == "122") || (Session["ID_ESTADO_NUC"].ToString() == "123")) //11
                if (TieneOrdenes)
                {
                    //PGJ.InsertaArbol(18, 1, "JUDICIALIZACION", "", "", IdUser);
                    PGJ.InsertaArbol(18, 1, "ORDENES", "NucJudOrdenes.aspx?&op=Agregar", "", IdUser);
                }

                //if (Session["ID_ESTADO_NUC"].ToString() == "120")
                if (TieneSentencia)
                {
                    //PGJ.InsertaArbol(18, 1, "JUDICIALIZACION", "", "", IdUser);
                    PGJ.InsertaArbol(19, 1, "SENTENCIAS", "", "", IdUser);
                }

                PGJ.InsertaArbol(5, 1, "DENUNCIANTE", "", "", IdUser);
                PGJ.InsertaArbol(6, 1, "OFENDIDO", "", "", IdUser);
                //   PGJ.InsertaArbol(16, 1, "EMPRESA", "EmpreaOfendida.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(7, 1, "IMPUTADO", "", "", IdUser);
                //PGJ.InsertaArbol(19, 1, "DATOS DE LA DETENCIÓN", "DatosDetenidoPI.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(20, 1, "MEDIA FILIACIÓN DETENIDO", "MediaFiliacionDetenido.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(21, 1, "SEÑAS PARTICULARES DETENIDO", "SeñasParticularesDetenido.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(22, 1, "OBJETOS, ARMAS Y DROGAS", "RegistrarDetencion.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(8, 1, "TESTIGO", "", "", IdUser);
                PGJ.InsertaArbol(14, 1, "DEFENSOR", "", "", IdUser);
                PGJ.InsertaArbol(9, 1, "LUGAR DE HECHOS", "", "", IdUser);
                PGJ.InsertaArbol(10, 1, "DELITO", "", "", IdUser);
                PGJ.InsertaArbol(15, 1, "VEHÍCULOS", "", "", IdUser);
                PGJ.InsertaArbol(11, 1, "DESCRIPCION HECHOS", "", "", IdUser);

                PGJ.InsertaArbol(12, 1, "PERSONAS NO LOCALIZADAS", "", "", IdUser);

                // PGJ.InsertaArbol(12, 1, "SOLICITUDES DE AUDIENCIA", "Solicitudes.aspx?&op=Agregar", "", IdUser);

                //PGJ.InsertaArbol(12, 1, "DATOS COMPLEMENTARIOS DEL SECUESTRO", "DatosPrincipalesSec.aspx?&op=Agregar", "", IdUser);

                //PGJ.InsertaArbol(13, 1, "NEGOCIACIÓN", "AgregarNegociacionSec.aspx?&op=Agregar", "", IdUser);
                ////PGJ.InsertaArbol(14, 1, "DETENIDOS", "DatosPrincipalesSec.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(16, 1, "PRÓFUGOS", "AgregarProfugoSec.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(17, 1, "BANDAS DESARTICULADAS", "AgregarBandaDesartSec.aspx?&op=Agregar", "", IdUser);
                //PGJ.InsertaArbol(18, 1, "LIBERACIÓN", "LiberacionSec.aspx?&op=Agregar", "", IdUser);


                PGJ.InsertaArbol(13, 1, "ACTUACIONES", "", "", IdUser);
                PGJ.InsertaArbol(16, 1, "BOLETÍN", "", "", IdUser);

                PGJ.InsertaArbol(20, 1, "HISTORIAL RAC", "", "", IdUser);
                PGJ.InsertaArbol(21, 1, "HISTORIAL NUC", "", "", IdUser);


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


                //if ((Session["ID_ESTADO_NUC"].ToString() == "117") || (Session["ID_ESTADO_NUC"].ToString() == "122") || (Session["ID_ESTADO_NUC"].ToString() == "123"))
                if (TieneOrdenes)
                {
                    CargarDatosArbol("OrdenOficio", 18);
                }

                //if (Session["ID_ESTADO_NUC"].ToString() == "120")
                if (TieneSentencia)
                {
                    CargarDatosArbol("Sentencia", 19);
                }

                CargarDatosArbol("Boletin", 16);

                CargarDatosArbol("HistorialRac", 20);
                CargarDatosArbol("HistorialNuc", 21);
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

            //dcOrientacionDataContext validar = new dcOrientacionDataContext();
            //int x = 0;

            //x = validar.VALIDAR_PGJ_CARPETA_NUC("28", Session["IdMunicipio"].ToString(), Session["IdUnidad"].ToString(), txtNumero.Text, txtAño.Text, 2);
            //if (x == 0)
            //{
            //    // PGJ.GenerarNC("NUC", short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));

            PGJ.GenerarNC(IdCarpeta.Text, "NUC", short.Parse(Session["IdMunicipio"].ToString()), "", "", short.Parse(Session["IdUnidad"].ToString()));
            //PGJ.InsertaNUC(Data.NUC, DateTime.Parse(txtFechaInicio.Text), 10, DateTime.Parse(txtFechaInicio.Text), short.Parse(Session["IdUsuario"].ToString()), int.Parse(IdCarpeta.Text));
            PGJ.InsertaNUC(Data.NUC, 10, short.Parse(Session["IdUsuario"].ToString()), int.Parse(IdCarpeta.Text));


            SqlCommand sqlIniciar = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=10" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlIniciar.ExecuteReader();
            rdC.Close();

            //string CAD2;
            //CAD2 = "INSERT INTO PGJ_NUC_TRAMITE(ID_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 10);
            //}

            //else if (x == 1)
            //{
            //    lblError.Text = "EL REGISTRO YA EXISTE";
            //}
            //dcOrientacionDataContext validar = new dcOrientacionDataContext();
            //int x = 0;

            //x = validar.VALIDAR_PGJ_CARPETA_NUC("28", Session["IdMunicipio"].ToString(), Session["IdUnidad"].ToString(), txtNumero.Text, txtAño.Text, 2);
            //if (x == 0)
            //{
            //    // PGJ.GenerarNC("NUC", short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));

            //    PGJ.GenerarNC(IdCarpeta.Text,"NUC", short.Parse(Session["IdMunicipio"].ToString()), txtNumero.Text, txtAño.Text, short.Parse(Session["IdUnidad"].ToString()));
            //    PGJ.InsertaNUC(Data.NUC, DateTime.Parse(txtFechaInicio.Text), 10, DateTime.Parse(txtFechaInicio.Text), short.Parse(Session["IdUsuario"].ToString()), int.Parse(IdCarpeta.Text));


            //    SqlCommand sqlIniciar = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=10" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //    SqlDataReader rdC = sqlIniciar.ExecuteReader();
            //    rdC.Close();

            //    //string CAD2;
            //    //CAD2 = "INSERT INTO PGJ_NUC_TRAMITE(ID_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //    //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

            //    //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //    //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //    //rdTramite.Close();
            //    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 10);
            //}

            //else if (x == 1)
            //{
            //    lblError.Text = "EL REGISTRO YA EXISTE";
            //}

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
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()),  Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton JUDICIALIZAR Fecha:" + txtFechaJuducualizar.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
           
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 11);

            Iniciar.Enabled = false;
            Judicializar.Enabled = false;
            Archivo.Enabled = false;
            Ejercicio.Enabled = false;
            Criterio.Enabled = false;
        }

        protected void ImgSi2_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlArchivo = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=12  , FECHA_ESTADO_NUC='" + txtFechaArchivo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlArchivo.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            ////Judicializar.Enabled = true;
            ////Archivo.Enabled = false;
            ////Ejercicio.Enabled = true;
            ////Criterio.Enabled = true;



            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_ARCHIVO_TEMPORAL(ID_CARPETA,ID_MUNICIPIO_ARCHIVO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaArchivo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();

            PGJ.InsertaNucArchivoTemporal(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton ARCHIVO TEMPORAL Fecha:" + txtFechaArchivo.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 12);
        }

        protected void ImgSi3_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlNoEjercicio = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=13  , FECHA_ESTADO_NUC='" + txtFechaEjercicio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlNoEjercicio.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            ////Judicializar.Enabled = false;
            ////Archivo.Enabled = false;
            ////Ejercicio.Enabled = false;
            ////Criterio.Enabled = false;


            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_NO_EJERCICIO(ID_CARPETA,ID_MUNICIPIO_EJERCICIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaEjercicio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();

            PGJ.InsertaNucNoEjercicio(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton NO EJERCICIO Fecha:" + txtFechaEjercicio.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 13);

        }

        protected void ImgSi4_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=14 , FECHA_ESTADO_NUC='" + txtFechaCriterio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlOportunidad.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            ////Judicializar.Enabled = true;
            ////Archivo.Enabled = true;
            ////Ejercicio.Enabled = true;
            ////Criterio.Enabled = false;


            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_CRITERIO_OPORTUNIDAD(ID_CARPETA,ID_MUNICIPIO_CRITERIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaCriterio.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();

            PGJ.InsertaNucCriterio(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton CRITERIO DE OPORTUNIDAD Fecha:" + txtFechaCriterio.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 14);

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
            Panel10.Visible = false;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton Iniciar:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
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
                Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
                /*tecleo mi dominio o IP*/
                String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
                ruta_pdf = ruta_pdf.Replace("\\", "/");
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
                script = string.Format(script, ex.Message);

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
            //SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=17 , FECHA_ESTADO_NUC='" + txtFechaAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlOportunidad.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            ////Judicializar.Enabled = false;
            ////Archivo.Enabled = false;
            ////Ejercicio.Enabled = false;
            ////Criterio.Enabled = false;
            ////Acuerdo.Enabled = false;
            ////Incompetencia.Enabled = false;


            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_ACUERDO_ABS_INV(ID_CARPETA,ID_MUNICIPIO_ACUERDO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();
            PGJ.InsertaNucAcuerdo(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton ACUERDO PARA ABSTENERSE DE INVESTIGAR Fecha:" + txtFechaAcuerdo.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 17);
        }

        protected void ImgSi6_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=18 , FECHA_ESTADO_NUC='" + txtFechaIncompetancia.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlOportunidad.ExecuteReader();
            //rdC.Close();

            //Iniciar.Enabled = false;
            ////Judicializar.Enabled = false;
            ////Archivo.Enabled = false;
            ////Ejercicio.Enabled = false;
            ////Criterio.Enabled = false;
            ////Acuerdo.Enabled = false;
            ////Incompetencia.Enabled = false;


            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_INCOMPETENCIA(ID_CARPETA,ID_MUNICIPIO_INCOMPETENCIA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO,ID_AGENCIA)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIncompetancia.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + "," + ddlAgencia.SelectedValue + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();

            PGJ.InsertaNucIncompetencia(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()), int.Parse(ddlAgencia.SelectedValue));
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton INCOMPETENCIA Fecha:" + txtFechaIncompetancia.Text + " Agencia: " + ddlAgencia.SelectedItem + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 18);
        }

        protected void Judicializar_Click(object sender, ImageClickEventArgs e)
        {
            if (!PGJ.TieneImputados(Session["ID_CARPETA"].ToString()))
            {
                string script = @"<script type='text/javascript'>
                             alert('No se puede Judicializar la carpeta, no hay imputados registrados, registre al menos uno'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                //lblEstatus.Text = "No se puede Judicializar la carpeta, no hay imputados registrados, registre al menos uno";
            }

            else if (PGJ.TieneQRR(Session["ID_CARPETA"].ToString()))
            {

                string script = @"<script type='text/javascript'>
                             alert('No se puede Judicializar la carpeta, modifique el imputado Quien Resulte Responsable'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                //lblEstatus.Text="No se puede Judicializar la carpeta, modifique el imputado Quien Resulte Responsable";
            }

            else
            {
                Panel2.Visible = false; //JUDICIALIZACION PONER EN TRUE
                Panel1.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
                Panel7.Visible = false;
                Panel8.Visible = false;
                Panel9.Visible = false;
                Response.Redirect("Judicializada.aspx");
            }

            //Panel2.Visible = true;
            //Panel1.Visible = false;
            //Panel3.Visible = false;
            //Panel4.Visible = false;
            //Panel5.Visible = false;
            //Panel7.Visible = false;
            //Panel8.Visible = false;
            //Panel9.Visible = false;
            //PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton JUDICIALIZAR:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            //Response.Redirect("Judicializada.aspx");
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
            Panel10.Visible = false;
            PanelAcumular.Visible = false;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton ARCHIVO TEMPORAL:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
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
            Panel10.Visible = false;
            PanelAcumular.Visible = false;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton NO EJERCICIO:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
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
            Panel10.Visible = false;
            PanelAcumular.Visible = false;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton ACUERDO PARA ABSTENERCE DE INVESTIGAR:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
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
            Panel10.Visible = false;
            PanelAcumular.Visible = false;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton CRITERIO DE OPORTUNIDAD:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
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
            Panel10.Visible = false;
            PanelAcumular.Visible = false;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton INCOMPENTENCIA:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
        }

        protected void ImgSi7_Click(object sender, ImageClickEventArgs e)
        {



            dcOrientacionDataContext validar = new dcOrientacionDataContext();
            int x = 0;

            x = validar.VALIDAR_NUM_INICIADA(int.Parse(Session["ID_CARPETA"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), 2);
            if (x == 0)
            {

                //SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=22 , FECHA_ESTADO_NUC='" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                //SqlDataReader rdC = sqlOportunidad.ExecuteReader();
                //rdC.Close();

                //Iniciar.Enabled = false;

                //string CAD2;
                //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_MEDIOS_ALTERNATIVOS(ID_CARPETA,ID_MUNICIPIO_MEDIOS,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
                //SqlDataReader rdTramite = sqlTramite.ExecuteReader();
                //rdTramite.Close();

                //string CAD3;
                //CAD3 = "set dateformat dmy INSERT INTO PGJ_NUM_INICIADA(ID_CARPETA,ID_MUNICIPIO_INICIADA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD3 = CAD3 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlCentroMediacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                //SqlCommand sqlIniciada = new SqlCommand(CAD3, Data.CnnCentral);
                //SqlDataReader rdIniciada = sqlIniciada.ExecuteReader();

                //rdIniciada.Close();
                PGJ.InsertaNucMedios(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()), int.Parse(ddlCentroMediacion.SelectedValue.ToString()));
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton MEDIOS DE SOLUCION DE CONFLICTOS Fecha:" + txtFechaIMediacion.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            

                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 22);

            }

            else if (x == 1)
            {
                //SqlCommand sqlOportunidad = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUC=22 , ACTIVO_NUM='TRUE', FECHA_ESTADO_NUC='" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                //SqlDataReader rdC = sqlOportunidad.ExecuteReader();
                //rdC.Close();

                //Iniciar.Enabled = false;

                //string CAD2;
                //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUC_MEDIOS_ALTERNATIVOS(ID_CARPETA,ID_MUNICIPIO_MEDIOS,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaIMediacion.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ")";

                //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
                //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

                ////se quita pgj_num _iniciada para que no se duplique
                //rdTramite.Close();
                PGJ.InsertaNucMediosElse(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(Session["IdUsuario"].ToString()));
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton MEDIOS DE SOLUCION DE CONFLICTOS Fecha:" + txtFechaIMediacion.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 22);

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
            Panel10.Visible = false;
            PanelAcumular.Visible = false;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton MEDIOS ALTERNOS:" + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
        }


        // remitir expediente a otra unidad

        //protected void ImgSi8_Click(object sender, ImageClickEventArgs e)
        //{

        //    ConectarPNL();
        //    if (CnnPNL.State == 0)
        //    {
        //        LblMensajeRemitir.Text = "No hay Conexión con la Unidad Seleccionada. Intente más tarde";
        //    }
        //    else
        //    {
        //        LblMensajeRemitir.Text = "Conexion Exitosa";
        //        //INSERTAR CARPETA
        //        InsertarCarpeta();
        //        TraerIdCarpeta();
        //        InsertarLugarHechos();
        //        InsertarDelitos();
        //        InsertarPersona();
        //        InsertarCarpetaPersona();
        //        InsertarPersonaDomicilio();
        //        InsertarAlias();
        //        InsertarMedioContacto();
        //        InsertarArchivoTemporal();
        //        InsertaacuerdoAbsInv();
        //        InsertaCriterioOportunidad();
        //        InsertaIncompetencia();
        //        InsertaMediosAlternativos();
        //        InsertaNoEjercicio();
        //        InsertaJudAcuerdosReparatorios();
        //        InsertaJudDetencion();
        //        InsertaJudMedidaCautelar();
        //        InsertaJudMedidaProteccion();
        //        InsertaJudOrdenes();
        //        InsertaJudPlazoInvestigacion();
        //        InsertaJudProcedimientoAbreviado();
        //        InsertaJudSentencia();
        //        InsertaJudSobreseimiento();
        //        InsertaJudSuspencion();
        //        InsertarDefensor();
        //        InsertarAutoridad();
        //        InsertarDescripcionHechos();
        //        InsertarLugarDetencion();
        //        InsertarDetencion();
        //        InsertaJudImputacion();
        //        InsertaJudVinculacionDelito();
        //        InsertarSujetoInterviene();
        //        InsertarBoletin();
        //        InsertarDatosGenerales();
        //        InsertarPertenenciaSocial();
        //        InsertarDiscapacidades();
        //        InsertarInformacionFinanciera();
        //        InsertarInformacionOdontologica();
        //        InsertarOtraInformacion();
        //        InsertarCausalesDesaparicion();
        //        InsertarMediaFiliacion();
        //        InsertarSenasParticulares();
        //        InsertarVestimenta();
        //        InsertarColectorMuestra();
        //        InsertarDonantes();
        //        InsertarDatosLocalizacion();
        //        InsertarPersonaQuien();
        //        InsertarCarpetaPersonaQuien();
        //        InsertarPersonaDomicilioQuien();
        //        InsertarFotografia();
        //        InsertaRACIniciada();
        //        InsertaRACRemitida();
        //        InsertaRACCanalizada();
        //        InsertaRACConvenio();
        //        InsertaRACConvenioIncumplido();
        //        InsertaRACIncompetencia();
        //        InsertaRACNoConvenio();
        //        InsertaRACResuelta();
        //        InsertaRACSuspendida();
        //        InsertaRACAcuerdoAbsInv();
        //        InsertarVehiculo();
        //        InsertarVehiculoRobado();
        //        InsertarVehiculoRecuperado();
        //        InsertarAutorizacion();
        //        InsertaCarpetaPDF();
        //        InsertarVehiculoPDF();
        //        InsertarHomicidio();
        //        InsertarCadaverHomicidio();
        //        InsertarHomicidioMensaje();
        //        InsertarHomicidioArma();
        //        InsertarArmaHomicidio();
        //        InsertaCarpetaRemitidas();
        //        //*** INSERTAR UN HISTORIAL
        //        Mostrar();

        //    }
        //}

        //protected void ImgNo8_Click(object sender, ImageClickEventArgs e)
        //{
        //    Panel10.Visible = false;
        //}

        private void ConectarPNL()
        {
            string Sql = "select ip_servidor, id_municipio from cat_unidad_servidor where id_undd=" + DDUnidades.SelectedValue;
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["ID_MUNICIPIO_REMITIR"] = dr["ID_MUNICIPIO"].ToString();
                Session["ID_UNIDAD_REMITIR"] = DDUnidades.SelectedValue;
                CnnPNL = new SqlConnection("Data Source=" + dr["ip_servidor"].ToString() + ";Initial Catalog=PNL_NSJP2;User ID=PGJNSJP;Password=Usuario.25;MultipleActiveResultSets=true");
                NUC = "28/";
                RAC = "28/";

                NUCSIN = "28/";
                RACSIN = "28/";
                if (dr["Id_municipio"].ToString().Length == 1)
                { 
                    NUC = NUC + "0" + dr["Id_municipio"].ToString() + "/";
                    RAC = RAC + "0" + dr["Id_municipio"].ToString() + "/";

                    NUCSIN = NUCSIN + "0" + dr["Id_municipio"].ToString() + "/";
                    RACSIN = RACSIN + "0" + dr["Id_municipio"].ToString() + "/";
                }
                else
                { 
                    NUC = NUC + dr["Id_municipio"].ToString() + "/";
                    RAC = RAC + dr["Id_municipio"].ToString() + "/";

                    NUCSIN = NUCSIN + dr["Id_municipio"].ToString() + "/";
                    RACSIN = RACSIN + dr["Id_municipio"].ToString() + "/";
                }
                if (DDUnidades.SelectedValue.Length == 2)
                { 
                    NUC = NUC + "0" + DDUnidades.SelectedValue + "/";
                    RAC = RAC + "0" + DDUnidades.SelectedValue + "/";

                    NUCSIN = NUCSIN + "0" + DDUnidades.SelectedValue + "/";
                    RACSIN = RACSIN + "0" + DDUnidades.SelectedValue + "/";
                }
                else if (DDUnidades.SelectedValue.Length == 3)
                { 
                    NUC = NUC + DDUnidades.SelectedValue + "/";
                    RAC = RAC + DDUnidades.SelectedValue + "/";

                    NUCSIN = NUCSIN + DDUnidades.SelectedValue + "/";
                    RACSIN = RACSIN + DDUnidades.SelectedValue + "/"; 
                }
                NUC = NUC + Session["SIGLA"].ToString();
                RAC = RAC + Session["SIGLA"].ToString();

                try
                {
                    CnnPNL.Open();
                }
                catch (Exception ex)
                {
                    //lblEstatus.Text = ex.Message;
                }               

            }
            dr.Close();
        }

        string nucnew;
        string racnew;
        string ContieneRac;
        private void InsertarCarpeta()
        {
            //INSERTAR CARPETA

            string Sql = "select ID_CARPETA,ID_MUNICIPIO_CARPETA,ISNUMERIC(SUBSTRING(NUC,11,5))AS isnuc,ISNUMERIC(SUBSTRING(RAC,11,5))AS israc, " +
            "case when ISNUMERIC(SUBSTRING(NUC,11,5))=1 then SUBSTRING(NUC,12,9) when ISNUMERIC(SUBSTRING(NUC,11,5))=0 then SUBSTRING(NUC,11,10) end as NUC, "+
            "case when ISNUMERIC(SUBSTRING(RAC,11,5))=1 then SUBSTRING(RAC,12,9) when ISNUMERIC(SUBSTRING(RAC,11,5))=0 then SUBSTRING(RAC,11,10) end as RAC, "+
            "NUM,NAC,CASE WHEN DETENIDO='True' then 1 WHEN DETENIDO='False' then 0 end DETENIDO,FECHA_NUC,FECHA_RAC,FECHA_NUM,FECHA_NAC,ID_ESTADO_NUC,ID_ESTADO_RAC,ID_ESTADO_NUM " +
            ",ID_ESTADO_NAC,FECHA_ESTADO_NUC ,FECHA_ESTADO_RAC,FECHA_ESTADO_NUM " +
            " ,FECHA_ESTADO_NAC,ID_USUARIO_NUC,ID_USUARIO_RAC,ID_USUARIO_NUM,ID_USUARIO_NAC , "+
            " ACTIVO_NUC ,CASE WHEN ACTIVO_RAC='True' then 1 WHEN ACTIVO_RAC='False' then 0 end ACTIVO_RAC,ACTIVO_NUM,ACTIVO_NAC ,ID_FORMA_INICIO,FECHA_REGISTRO "+
            "from pgj_carpeta where id_carpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                //NUC = NUC + dr["NUC"].ToString().Substring(11, 9);
                if (dr["isnuc"].ToString() == "1")
                {
                    nucnew = NUC + dr["NUC"].ToString();
                }
                else {
                    nucnew = NUCSIN + dr["NUC"].ToString();
                }

                //NUC = NUC + dr["NUC"].ToString();
                //NUCSIN = NUCSIN + dr["NUC"].ToString();

                ContieneRac = dr["ACTIVO_RAC"].ToString();


                //nucnew = NUC;
                

                if (ContieneRac == "1")
                {
                    //RAC = RAC + dr["RAC"].ToString().Substring(11, 9);
                    if (dr["israc"].ToString() == "1")
                    {
                        racnew = RAC + dr["RAC"].ToString();
                    }
                    else
                    {
                        racnew = RACSIN + dr["RAC"].ToString();
                    }

                    //racnew = RAC;

                    PGJ.InsertaRACNUCUnidadRemitir(nucnew, DateTime.Parse(dr["FECHA_NUC"].ToString()), short.Parse(dr["ID_ESTADO_NUC"].ToString()), DateTime.Parse(dr["FECHA_ESTADO_NUC"].ToString()), short.Parse(Session["IdUsuarioRemitir"].ToString()), short.Parse(dr["ID_FORMA_INICIO"].ToString()), short.Parse(dr["DETENIDO"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    short.Parse(DDUnidades.SelectedValue), DateTime.Parse(dr["FECHA_REGISTRO"].ToString()),
                    racnew, DateTime.Parse(dr["FECHA_RAC"].ToString()), short.Parse(dr["ID_ESTADO_RAC"].ToString()), DateTime.Parse(dr["FECHA_ESTADO_RAC"].ToString()), short.Parse(dr["ACTIVO_RAC"].ToString()));
                }
                else
                {
                    PGJ.InsertaNUCUnidadRemitir(nucnew, DateTime.Parse(dr["FECHA_NUC"].ToString()), short.Parse(dr["ID_ESTADO_NUC"].ToString()), DateTime.Parse(dr["FECHA_ESTADO_NUC"].ToString()), short.Parse(Session["IdUsuarioRemitir"].ToString()), short.Parse(dr["ID_FORMA_INICIO"].ToString()), short.Parse(dr["DETENIDO"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                        short.Parse(DDUnidades.SelectedValue), DateTime.Parse(dr["FECHA_REGISTRO"].ToString()));
                }


                //RAC = RAC + dr["RAC"].ToString().Substring(11, 9);
                if (dr["israc"].ToString() == "1")
                {
                    racnew = RAC + dr["RAC"].ToString();
                }
                else
                {
                    racnew = RACSIN + dr["RAC"].ToString();
                }


               // racnew = RAC;
            }
            dr.Close();
        }

        private void TraerIdCarpeta()
        {
            string Sql = "select * from pgj_carpeta where nuc='" + nucnew + "'";
            SqlCommand SqlComando = new SqlCommand(Sql, NUC_PNL.CnnPNL);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                lblIdCN.Text = dr["ID_CARPETA"].ToString();
            }
            dr.Close();
        }


        //INSERTA LUGAR DE HECHOS
        private void InsertarLugarHechos()
        {
            string Sql = "select count(*) as Total from pgj_lugar_hechos where id_carpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TotalLH.Text = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select * from pgj_lugar_hechos where id_carpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                
                while (int.Parse(TotalLH.Text) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaLugarhechosRemitir(int.Parse(lblIdCN.Text), DateTime.Parse(dr1["FECHA_HECHOS"].ToString()), dr1["HORA_HECHOS"].ToString(), short.Parse(dr1["ID_TIPO_LUGAR"].ToString()), short.Parse(dr1["ID_MUNICIPIO"].ToString()), int.Parse(dr1["ID_LOCALIDAD"].ToString()), int.Parse(dr1["ID_COLONIA"].ToString()), int.Parse(dr1["ID_CALLE"].ToString()), int.Parse(dr1["ID_ENTRE_CALLE"].ToString()), int.Parse(dr1["ID_Y_CALLE"].ToString()), dr1["NO_EXTERIOR"].ToString(), dr1["MANZANA"].ToString(), dr1["LOTE"].ToString(), dr1["LATITUD"].ToString(), dr1["LONGITUD"].ToString(), dr1["REFERENCIAS"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                    consultaIdLugarHechos();

                    PGJ.insertaRemitidasLH(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_LUGAR_HECHOS.Text), int.Parse(dr1["ID_LUGAR_HECHOS"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                }
            }
            dr1.Close();
        }

        void consultaIdLugarHechos()
        {
            //SqlCommand sql = new SqlCommand("consultaIdLugarHechos", NUC_PNL.CnnPNL);
            //SqlDataReader dr = sql.ExecuteReader();
            ////if (dr.HasRows)
            ////{
            //dr.Read();
            //ID_LUGAR_HECHOS.Text = dr["ID_LUGAR_HECHOS"].ToString();
            ////}
            //dr.Close();

            SqlCommand comm = new SqlCommand("SELECT MAX(ID_LUGAR_HECHOS) as ID_LUGAR_HECHOS  FROM PGJ_LUGAR_HECHOS WHERE ID_CARPETA = " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ID_LUGAR_HECHOS.Text = dr["ID_LUGAR_HECHOS"].ToString();
                }
                dr.Close();
            }
        }

        //INSERTA DELITOS 
        string TotalDe;
        private void InsertarDelitos()
        {
            string Sql = "select count(*) as Total from pgj_delitos where id_carpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TotalDe = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select IdCarpetaNew,ID_DELITO,ID_MODALIDAD,CASE WHEN ID_VIOLENCIA='True' then 1 WHEN ID_VIOLENCIA='False' then 0 end as ID_VIOLENCIA, "+
            "CASE WHEN ID_GRAVE='True' then 1 WHEN ID_GRAVE='False' then 0 end as ID_GRAVE,CASE WHEN ID_PRINCIPAL='True' then 1 WHEN ID_PRINCIPAL='False' then 0 end as ID_PRINCIPAL,ID_ACCION,FECHA_REGISTRO,IdLugarHechosNew,ID_CONSECUTIVO_DELITO " +
	        "from PGJ_DELITOS "+
	        "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_DELITOS.ID_CARPETA AND REMITIDAS_RELACION_ID.IdLugarHechosOld=PGJ_DELITOS.ID_LUGAR_HECHOS "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdPersonaNew IS NULL AND IdPersonaOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
	        "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(TotalDe) != contador)
                {
                    dr1.Read();


                    PGJ.InsertaDelitoRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(dr1["ID_DELITO"].ToString()), short.Parse(dr1["ID_MODALIDAD"].ToString()), short.Parse(dr1["ID_VIOLENCIA"].ToString()),
                    short.Parse(dr1["ID_GRAVE"].ToString()), short.Parse(dr1["ID_PRINCIPAL"].ToString()),
                    int.Parse(dr1["IdLugarHechosNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(dr1["ID_ACCION"].ToString()),
                    DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                          
                    contador = contador + 1;
                    consultaIdDelito();
                    PGJ.insertaRemitidasDelito(int.Parse(dr1["IdCarpetaNew"].ToString()), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_CONSECUTIVO_DELITO.Text), int.Parse(dr1["ID_CONSECUTIVO_DELITO"].ToString()),int.Parse(Session["IdMunicipio"].ToString()));
                }
            }
            dr1.Close();
        }

        void consultaIdDelito()
        {
            //SqlCommand sql = new SqlCommand("consultaIdDelito", NUC_PNL.CnnPNL);
            //SqlDataReader dr = sql.ExecuteReader();
            ////if (dr.HasRows)
            ////{
            //dr.Read();
            //ID_CONSECUTIVO_DELITO.Text = dr["ID_CONSECUTIVO_DELITO"].ToString();
            ////}
            //dr.Close();


            SqlCommand comm = new SqlCommand("SELECT MAX(ID_CONSECUTIVO_DELITO) as ID_CONSECUTIVO_DELITO  FROM PGJ_DELITOS WHERE ID_CARPETA = " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ID_CONSECUTIVO_DELITO.Text = dr["ID_CONSECUTIVO_DELITO"].ToString();
                }
                dr.Close();
            }
        }



        //PERSONAS
        string TotalPersona;
        private void InsertarPersona()
        {
            string Sql = "select COUNT(*) AS Total from PGJ_PERSONA JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) WHERE NOMBRE!=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TotalPersona = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select ID_CARPETA,PGJ_PERSONA.ID_PERSONA,PATERNO,MATERNO ,NOMBRE ,ID_SEXO,FECHA_NACIMIENTO,EDAD,ID_NACIONALIDAD,ID_PAIS ,ID_ESTADO ,ID_MUNICIPIO ,RFC " +
            ",CURP,DECLARACION,PGJ_PERSONA.FECHA_REGISTRO "+
            "from PGJ_PERSONA "+
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "WHERE NOMBRE!="+"'QUIEN'"+" AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            //"WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(TotalPersona) != contador)
                {
                    dr1.Read();
                    Session["PaternoMax"] = dr1["PATERNO"].ToString();
                    Session["MaternoMax"] = dr1["MATERNO"].ToString();
                    Session["NombreMax"] = dr1["NOMBRE"].ToString();

                    PGJ.InsertaPersonaRemitir(dr1["PATERNO"].ToString(), dr1["MATERNO"].ToString(), dr1["NOMBRE"].ToString(), short.Parse(dr1["ID_SEXO"].ToString()), dr1["FECHA_NACIMIENTO"].ToString(), short.Parse(dr1["ID_NACIONALIDAD"].ToString()),
                    short.Parse(dr1["ID_PAIS"].ToString()), short.Parse(dr1["ID_ESTADO"].ToString()), short.Parse(dr1["ID_MUNICIPIO"].ToString()), dr1["RFC"].ToString(), dr1["CURP"].ToString(), dr1["DECLARACION"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                    consultaIdPersona();
                    PGJ.insertaRemitidasPersonas(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_CONSECUTIVO_PERSONA.Text), int.Parse(dr1["ID_PERSONA"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                }
            }
            dr1.Close();
        }

        void consultaIdPersona()
        {
            SqlCommand sql = new SqlCommand("consultaIdPersonaMax", NUC_PNL.CnnPNL);
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@Paterno", SqlDbType.VarChar);
            sql.Parameters.Add("@Materno", SqlDbType.VarChar);
            sql.Parameters.Add("@Nombre", SqlDbType.VarChar);

            sql.Parameters["@Paterno"].Value = Session["PaternoMax"].ToString();
            sql.Parameters["@Materno"].Value = Session["MaternoMax"].ToString();
            sql.Parameters["@Nombre"].Value = Session["NombreMax"].ToString();

            SqlDataReader dr = sql.ExecuteReader();
            dr.Read();
            ID_CONSECUTIVO_PERSONA.Text = dr["ID_PERSONA"].ToString();

            dr.Close();
        }

        private void InsertarCarpetaPersona()
        {
            
            int contador = 0;
            string Sql1 = "	select IdCarpetaNew,IdPersonaNew,ID_ESTADO_CIVIL,ID_ESCOLARIDAD,ID_OCUPACION,ID_IDENTIFICACION, "+
	         "FOLIO,case when LEER_ESCRIBIR='true' then 1  when LEER_ESCRIBIR='false' then 0 end as LEER_ESCRIBIR, "+
	         "case when VIVO='true' then 1  when VIVO='false' then 0 end as VIVO, "+
	         "case when DETENIDO='true' then 1  when DETENIDO='false' then 0 end as DETENIDO, "+
             "ID_PUSO_DISPOSICION,PGJ_CARPETA_PERSONA.FECHA_REGISTRO AS FR,ID_TIPO_ACTOR " +
             "from PGJ_PERSONA "+
             "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
             "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA "+
             "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
             "WHERE NOMBRE!=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(TotalPersona) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaCarpetaPersonaRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()), short.Parse(dr1["ID_ESTADO_CIVIL"].ToString()),
                    short.Parse(dr1["ID_ESCOLARIDAD"].ToString()), short.Parse(dr1["ID_OCUPACION"].ToString()), short.Parse(dr1["ID_IDENTIFICACION"].ToString()),
                    dr1["FOLIO"].ToString(), short.Parse(dr1["LEER_ESCRIBIR"].ToString()), short.Parse(dr1["VIVO"].ToString()), short.Parse(dr1["DETENIDO"].ToString()),
                    short.Parse(dr1["ID_TIPO_ACTOR"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(dr1["ID_PUSO_DISPOSICION"].ToString()), DateTime.Parse(dr1["FR"].ToString()));

                    contador = contador + 1;
                    //PGJ.insertaRemitidasPersonas(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_CONSECUTIVO_PERSONA.Text), int.Parse(dr1["ID_PERSONA"].ToString()));
                }
            }
            dr1.Close();
        }

        public void InsertarPersonaDomicilio()
        {
            int contador = 0;
            string Sql1 = "	select IdCarpetaNew,IdPersonaNew, " +
	        "PGJ_PERSONA_DOMICILIO.ID_PAIS as IdPD,PGJ_PERSONA_DOMICILIO.ID_ESTADO as IdED,PGJ_PERSONA_DOMICILIO.ID_MUNICIPIO as IdMD, "+
	        "ID_LOCALIDAD,ID_COLONIA,ID_CALLE,ID_ENTRE_CALLE,ID_Y_CALLE,NUMERO,MANZANA,LOTE "+
            "from PGJ_PERSONA "+
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+ 
            "JOIN PGJ_PERSONA_DOMICILIO ON (PGJ_PERSONA_DOMICILIO.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE NOMBRE!='QUIEN' AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(TotalPersona) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaPersonaDomicilioRemitir(int.Parse(dr1["IdPersonaNew"].ToString()), short.Parse(dr1["IdPD"].ToString()), short.Parse(dr1["IdED"].ToString()),
                    short.Parse(dr1["IdMD"].ToString()), int.Parse(dr1["ID_LOCALIDAD"].ToString()), int.Parse(dr1["ID_COLONIA"].ToString()),
                    int.Parse(dr1["ID_CALLE"].ToString()), int.Parse(dr1["ID_ENTRE_CALLE"].ToString()), int.Parse(dr1["ID_Y_CALLE"].ToString()),
                    dr1["NUMERO"].ToString(), dr1["MANZANA"].ToString(), dr1["LOTE"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()));

                    contador = contador + 1;
                    //PGJ.insertaRemitidasPersonas(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_CONSECUTIVO_PERSONA.Text), int.Parse(dr1["ID_PERSONA"].ToString()));
                }
            }
            dr1.Close();
        }

        string alias;
        private void InsertarAlias()
        {
            string Sql = " select COUNT(*) as Total "+
            "from PGJ_PERSONA "+
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "JOIN PGJ_ALIAS ON (PGJ_ALIAS.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE NOMBRE!=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                alias = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select ALIAS,PGJ_ALIAS.FECHA_REGISTRO AS FR,IdPersonaNew  "+
            "from PGJ_PERSONA  "+
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA)  "+
            "JOIN PGJ_ALIAS ON (PGJ_ALIAS.ID_PERSONA=PGJ_PERSONA.ID_PERSONA)  "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ")  " +
            "WHERE NOMBRE!=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(alias) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaAliasRemitir(int.Parse(dr1["IdPersonaNew"].ToString()), dr1["ALIAS"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    DateTime.Parse(dr1["FR"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        string contacto;
        private void InsertarMedioContacto()
        {
            string Sql = "select "+
            "COUNT(*) as Total "+
            "from PGJ_PERSONA "+
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "JOIN PGJ_MEDIO_CONTACTO ON (PGJ_MEDIO_CONTACTO.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE NOMBRE!=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                contacto = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select "+
            "IdPersonaNew,ID_TIPO_MEDIO_CONTACTO,MEDIO_CONTACTO,CASE WHEN ACTIVO='true' then 1 WHEN ACTIVO='false' then 2 end as ACTIVO,PGJ_MEDIO_CONTACTO.FECHA_REGISTRO as FR " +
            "from PGJ_PERSONA "+
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "JOIN PGJ_MEDIO_CONTACTO ON (PGJ_MEDIO_CONTACTO.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE NOMBRE!=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(contacto) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaMedioContactoRemitir(int.Parse(dr1["IdPersonaNew"].ToString()), short.Parse(dr1["ID_TIPO_MEDIO_CONTACTO"].ToString()), dr1["MEDIO_CONTACTO"].ToString(),
                        short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(dr1["ACTIVO"].ToString()), DateTime.Parse(dr1["FR"].ToString()));
            
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }


        //QUIEN
        string TotalPersonaQuien;
        private void InsertarPersonaQuien()
        {
       
            string Sql = "select COUNT(*) AS Total from PGJ_PERSONA JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) WHERE NOMBRE=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                TotalPersonaQuien = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select ID_CARPETA,PGJ_PERSONA.ID_PERSONA,PATERNO,MATERNO ,NOMBRE,PGJ_PERSONA.FECHA_REGISTRO  " +
            "from PGJ_PERSONA " +
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) " +
            "WHERE NOMBRE=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            //"WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(TotalPersonaQuien) != contador)
                {
                    dr1.Read();
                    Session["PaternoMaxQuien"] = dr1["PATERNO"].ToString();
                    Session["MaternoMaxQuien"] = dr1["MATERNO"].ToString();
                    Session["NombreMaxQuien"] = dr1["NOMBRE"].ToString();

                    PGJ.InsertaQuienResulteResponsableRemitir(dr1["PATERNO"].ToString(), dr1["MATERNO"].ToString(), dr1["NOMBRE"].ToString(), 
                    short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                    consultaIdPersonaQuien();
                    PGJ.insertaRemitidasPersonas(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_CONSECUTIVO_PERSONAQUIEN.Text), int.Parse(dr1["ID_PERSONA"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                }
            }
            dr1.Close();
        }

        void consultaIdPersonaQuien()
        {
            SqlCommand sql = new SqlCommand("consultaIdPersonaMax", NUC_PNL.CnnPNL);
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@Paterno", SqlDbType.VarChar);
            sql.Parameters.Add("@Materno", SqlDbType.VarChar);
            sql.Parameters.Add("@Nombre", SqlDbType.VarChar);

            sql.Parameters["@Paterno"].Value = Session["PaternoMaxQuien"].ToString();
            sql.Parameters["@Materno"].Value = Session["MaternoMaxQuien"].ToString();
            sql.Parameters["@Nombre"].Value = Session["NombreMaxQuien"].ToString();

            SqlDataReader dr = sql.ExecuteReader();
            dr.Read();
            ID_CONSECUTIVO_PERSONAQUIEN.Text = dr["ID_PERSONA"].ToString();

            dr.Close();
        }

        public void InsertarPersonaDomicilioQuien()
        {
            int contador = 0;
            string Sql1 = "	select IdCarpetaNew,IdPersonaNew, " +
            "PGJ_PERSONA_DOMICILIO.ID_PAIS as IdPD,PGJ_PERSONA_DOMICILIO.ID_ESTADO as IdED,PGJ_PERSONA_DOMICILIO.ID_MUNICIPIO as IdMD, " +
            "ID_LOCALIDAD,ID_COLONIA,ID_CALLE,ID_ENTRE_CALLE,ID_Y_CALLE,NUMERO,MANZANA,LOTE " +
            "from PGJ_PERSONA " +
            "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) " +
            "JOIN PGJ_PERSONA_DOMICILIO ON (PGJ_PERSONA_DOMICILIO.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) " +
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA " +
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE NOMBRE='QUIEN' AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(TotalPersonaQuien) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaQuienResulteResponsablePersonaDomicilioRemitir(int.Parse(dr1["IdPersonaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarCarpetaPersonaQuien()
        {

            int contador = 0;
            string Sql1 = "	select IdCarpetaNew,IdPersonaNew,ID_ESTADO_CIVIL,ID_ESCOLARIDAD,ID_OCUPACION,ID_IDENTIFICACION, " +
             "FOLIO,case when LEER_ESCRIBIR='true' then 1  when LEER_ESCRIBIR='false' then 0 end as LEER_ESCRIBIR, " +
             "case when VIVO='true' then 1  when VIVO='false' then 0 end as VIVO, " +
             "case when DETENIDO='true' then 1  when DETENIDO='false' then 0 end as DETENIDO, " +
             "ID_PUSO_DISPOSICION,PGJ_CARPETA_PERSONA.FECHA_REGISTRO AS FR,ID_TIPO_ACTOR " +
             "from PGJ_PERSONA " +
             "JOIN PGJ_CARPETA_PERSONA ON (PGJ_CARPETA_PERSONA.ID_PERSONA=PGJ_PERSONA.ID_PERSONA) " +
             "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_CARPETA_PERSONA.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_CARPETA_PERSONA.ID_PERSONA " +
             "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
             "WHERE NOMBRE=" + "'QUIEN'" + " AND ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(TotalPersonaQuien) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaQuienResulteResponsableCarpetaPersonaRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["ID_TIPO_ACTOR"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), DateTime.Parse(dr1["FR"].ToString()));

                    contador = contador + 1;
                    //PGJ.insertaRemitidasPersonas(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_CONSECUTIVO_PERSONA.Text), int.Parse(dr1["ID_PERSONA"].ToString()));
                }
            }
            dr1.Close();
        }



        //DEFENSOR
        private void InsertarDefensor()
        {
            string defensor="";

            string Sql = "select count(*) as Total from PGJ_DEFENSOR "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_DEFENSOR.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_DEFENSOR.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                defensor = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select IdPersonaNew,PATERNO,MATERNO,NOMBRE,ID_IDENTIFICACION,FOLIO,TELEFONO,ID_NACIONALIDAD,ID_PAIS_ORIGEN,ID_ESTADO_ORIGEN,ID_MUNICIPIO_ORIGEN, "+
            "ID_PAIS,ID_ESTADO,ID_MUNICIPIO,ID_LOCALIDAD,ID_COLONIA,ID_CALLE,ID_ENTRE_CALLE,ID_Y_CALLE,NUMERO,MANZANA,LOTE,FECHA_REGISTRO,DEFENSOR_PUB_PRIV,ID_TIPO_ACTOR "+
            "from PGJ_DEFENSOR "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_DEFENSOR.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_DEFENSOR.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(defensor) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaDefensorRemitir(int.Parse(lblIdCN.Text), int.Parse(dr1["IdPersonaNew"].ToString()), dr1["PATERNO"].ToString(),  dr1["MATERNO"].ToString(),
                    dr1["NOMBRE"].ToString(), short.Parse(dr1["DEFENSOR_PUB_PRIV"].ToString()), short.Parse(dr1["ID_TIPO_ACTOR"].ToString()), short.Parse(dr1["ID_IDENTIFICACION"].ToString()),
                    dr1["FOLIO"].ToString(), dr1["TELEFONO"].ToString(), short.Parse(dr1["ID_NACIONALIDAD"].ToString()), short.Parse(dr1["ID_PAIS_ORIGEN"].ToString()),
                    short.Parse(dr1["ID_ESTADO_ORIGEN"].ToString()), short.Parse(dr1["ID_MUNICIPIO_ORIGEN"].ToString()), short.Parse(dr1["ID_PAIS"].ToString()),
                    short.Parse(dr1["ID_ESTADO"].ToString()), short.Parse(dr1["ID_MUNICIPIO"].ToString()), int.Parse(dr1["ID_LOCALIDAD"].ToString()),
                    int.Parse(dr1["ID_COLONIA"].ToString()),int.Parse(dr1["ID_CALLE"].ToString()),int.Parse(dr1["ID_ENTRE_CALLE"].ToString()),int.Parse(dr1["ID_Y_CALLE"].ToString()),
                    dr1["NUMERO"].ToString(), dr1["MANZANA"].ToString(), dr1["LOTE"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString())
                    );
                       
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        //AUTORIDAD
        private void InsertarAutoridad()
        {
            string autoridad = "";

            string Sql = "select "+
            "COUNT(*) as Total "+
            "from PGJ_DENUNCIANTE_AUTORIDAD "+
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                autoridad = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select "+
            "ID_PUSO_DISPOSICION,NUMERO_OFICIO,ID_USUARIO,FECHA_REGISTRO "+
            "from PGJ_DENUNCIANTE_AUTORIDAD "+
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(autoridad) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaDenuncianteRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(dr1["ID_PUSO_DISPOSICION"].ToString()),
                        dr1["NUMERO_OFICIO"].ToString(), short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));


                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        //DESCRIPCION DE HECHOS
        private void InsertarDescripcionHechos()
        {
            string DescripcionHechos = "";

            string Sql = "select " +
            "COUNT(*) as Total " +
            "from PGJ_DESCRIPCION_HECHOS " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                DescripcionHechos = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select " +
            "DESCRIPCION,FECHA_REGISTRO,PREGUNTAS_PNL,FECHA_REGISTRO " +
            "from PGJ_DESCRIPCION_HECHOS " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(DescripcionHechos) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaDescripcionHechosRemitir(int.Parse(lblIdCN.Text), dr1["DESCRIPCION"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                     dr1["PREGUNTAS_PNL"].ToString(), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        //DATOS DE LA DETENCION
        private void InsertarLugarDetencion()
        {
            string detencion = "";

            string Sql = "select " +
            "COUNT(*) as Total " +
            "from PGJ_LUGAR_DETENCION " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                detencion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select " +
            "ID_LUGAR_DETENCION,FECHA_HECHOS,HORA_HECHOS,ID_TIPO_LUGAR,ID_PAIS,ID_ESTADO,ID_MUNICIPIO, " +
            "ID_LOCALIDAD,ID_COLONIA,ID_CALLE,ID_ENTRE_CALLE,ID_Y_CALLE,NO_EXTERIOR, " +
            "MANZANA,LOTE,LATITUD,LONGITUD,REFERENCIAS,FECHA_REGISTRO " +
            "from PGJ_LUGAR_DETENCION " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(detencion) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaLugarDetencionRemitir(int.Parse(lblIdCN.Text), DateTime.Parse(dr1["FECHA_HECHOS"].ToString()), dr1["HORA_HECHOS"].ToString(), short.Parse(dr1["ID_TIPO_LUGAR"].ToString()),
                    short.Parse(dr1["ID_MUNICIPIO"].ToString()), int.Parse(dr1["ID_LOCALIDAD"].ToString()), int.Parse(dr1["ID_COLONIA"].ToString()), int.Parse(dr1["ID_CALLE"].ToString()), int.Parse(dr1["ID_ENTRE_CALLE"].ToString()),
                    int.Parse(dr1["ID_Y_CALLE"].ToString()),dr1["NO_EXTERIOR"].ToString(), dr1["MANZANA"].ToString(), dr1["LOTE"].ToString(), dr1["LATITUD"].ToString(),dr1["LONGITUD"].ToString(),dr1["REFERENCIAS"].ToString(),
                    short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    consultaIdLugarDetencion();
                    PGJ.insertaRemitidasDetencion(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_LUGAR_DETENCION.Text), int.Parse(dr1["ID_LUGAR_DETENCION"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        void consultaIdLugarDetencion()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(ID_LUGAR_DETENCION),1) as ID_LUGAR_DETENCION  From PGJ_LUGAR_DETENCION WHERE ID_CARPETA = " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_LUGAR_DETENCION.Text = dr["ID_LUGAR_DETENCION"].ToString();
            Session["ID_LUGAR_DETENCION"] = ID_LUGAR_DETENCION.Text;

            //}
            dr.Close();
        }

        private void InsertarDetencion()
        {
            string detencion = "";

            string Sql = "select " +
            "COUNT(*) as Total " +
            "from PGJ_DETENCION AS d " +
            "JOIN PGJ_LUGAR_DETENCION as lg ON (lg.ID_CARPETA=d.ID_CARPETA and lg.ID_MUNICIPIO_LUGAR_DETENCION=d.ID_MUNICIPIO_CARPETA and lg.ID_LUGAR_DETENCION=d.ID_LUGAR_DETENCION) " +
            "JOIN REMITIDAS_RELACION_DETENCION AS r on (r.IdCarpetaOld=d.ID_CARPETA and r.iddetencionold=d.ID_LUGAR_DETENCION AND r.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=d.ID_PERSONA  " +
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE d.ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                detencion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	select " +
            "r.idcarpetanew,IdPersonaNew,iddetencionnew, " +
            "d.ID_USUARIO AS IdUsuario,FOLIO,MOTIVO_DETENCION,TIEMPO_TRANSLADO,LUGAR_PUESTA_DISPOSICION,AUTORIDAD_PUESTO_DISPOSICION, " +
            "NOMBRE_RECIBIO,CARGO_RECIBIO,CAUSA_NO_FIRMA,HORA_DETENCION,FECHA_DETENCION,ID_PREFERENCIA_SEXUAL,ID_ESTADO_DETENIDO, " +
            "FOTO_DETENIDO,ASUNTO,DIRIGIDO_A,AGENTES,ID_PARTICIPACION,OPERATIVO,NOMBRE_COMANDANTE,DESCRIPCION_HECHOS, " +
            "REFERENCIA_UBICACION,DETENIDO_POR,ID_PROCEDIMIENTO_DETENCION,ID_SUPUESTO_FLAGRANCIA,LIBERTAD_INVESTIGACION,ID_MOTIVO_LIBERACION,D.FECHA_REGISTRO " +
            "from PGJ_DETENCION AS d " +
            "JOIN PGJ_LUGAR_DETENCION as lg ON (lg.ID_CARPETA=d.ID_CARPETA and lg.ID_MUNICIPIO_LUGAR_DETENCION=d.ID_MUNICIPIO_CARPETA and lg.ID_LUGAR_DETENCION=d.ID_LUGAR_DETENCION) " +
            "JOIN REMITIDAS_RELACION_DETENCION AS r on (r.IdCarpetaOld=d.ID_CARPETA and r.iddetencionold=d.ID_LUGAR_DETENCION AND r.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=d.ID_PERSONA  " +
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE d.ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(detencion) != contador)
                {
                    dr1.Read();

                    byte[] bits = ((byte[])(dr1["FOTO_DETENIDO"]));

                    PGJ.InsertarDetencionDatosRemitir(int.Parse(dr1["IdPersonaNew"].ToString()), short.Parse(dr1["IdUsuario"].ToString()), int.Parse(dr1["idcarpetanew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    int.Parse(dr1["iddetencionnew"].ToString()), dr1["FOLIO"].ToString(), dr1["MOTIVO_DETENCION"].ToString(), dr1["TIEMPO_TRANSLADO"].ToString(), dr1["LUGAR_PUESTA_DISPOSICION"].ToString(),
                    dr1["AUTORIDAD_PUESTO_DISPOSICION"].ToString(), dr1["NOMBRE_RECIBIO"].ToString(), dr1["CARGO_RECIBIO"].ToString(), dr1["CAUSA_NO_FIRMA"].ToString(), dr1["HORA_DETENCION"].ToString(), DateTime.Parse(dr1["FECHA_DETENCION"].ToString()),
                    short.Parse(dr1["ID_PREFERENCIA_SEXUAL"].ToString()), short.Parse(dr1["ID_ESTADO_DETENIDO"].ToString()), bits, dr1["ASUNTO"].ToString(), dr1["DIRIGIDO_A"].ToString(),
                    dr1["AGENTES"].ToString(), short.Parse(dr1["ID_PARTICIPACION"].ToString()), short.Parse(dr1["OPERATIVO"].ToString()), dr1["NOMBRE_COMANDANTE"].ToString(), dr1["DESCRIPCION_HECHOS"].ToString(),
                    dr1["REFERENCIA_UBICACION"].ToString(), short.Parse(dr1["DETENIDO_POR"].ToString()), short.Parse(dr1["ID_PROCEDIMIENTO_DETENCION"].ToString()), short.Parse(dr1["ID_SUPUESTO_FLAGRANCIA"].ToString()),
                    short.Parse(dr1["LIBERTAD_INVESTIGACION"].ToString()), short.Parse(dr1["ID_MOTIVO_LIBERACION"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));



                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        //ESTADOS DE CARPETAS
        string archivoTemporal;
        private void InsertarArchivoTemporal()
        {
            string Sql = " select COUNT(*) as Total from PGJ_NUC_ARCHIVO_TEMPORAL WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                archivoTemporal = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_UNDD,FECHA_REGISTRO,ID_USUARIO FROM PGJ_NUC_ARCHIVO_TEMPORAL WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(archivoTemporal) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaArchivoTemporalRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                         short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        string acuerdoAbsInv;
        private void InsertaacuerdoAbsInv()
        {
            string Sql = " select COUNT(*) as Total from PGJ_NUC_ACUERDO_ABS_INV WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                acuerdoAbsInv = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_UNDD,FECHA_REGISTRO,ID_USUARIO FROM PGJ_NUC_ACUERDO_ABS_INV WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(acuerdoAbsInv) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaacuerdoAbsInvRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                         short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        string criterioOportunidad;
        private void InsertaCriterioOportunidad()
        {
            string Sql = " select COUNT(*) as Total from PGJ_NUC_CRITERIO_OPORTUNIDAD WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                criterioOportunidad = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_UNDD,FECHA_REGISTRO,ID_USUARIO FROM PGJ_NUC_CRITERIO_OPORTUNIDAD WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(criterioOportunidad) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaCriterioOportunidadRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                         short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }


        
        private void InsertaIncompetencia()
        {
            string incompetencia="";
            string Sql = " select COUNT(*) as Total from PGJ_NUC_INCOMPETENCIA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                incompetencia = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_UNDD,FECHA_REGISTRO,ID_USUARIO,ID_AGENCIA FROM PGJ_NUC_INCOMPETENCIA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(incompetencia) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaIncompetenciaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                         short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()), short.Parse(dr1["ID_AGENCIA"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }


        string mediosAlternativos;
        private void InsertaMediosAlternativos()
        {
            string Sql = " select COUNT(*) as Total from PGJ_NUC_MEDIOS_ALTERNATIVOS WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                mediosAlternativos = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_UNDD,FECHA_REGISTRO,ID_USUARIO FROM PGJ_NUC_MEDIOS_ALTERNATIVOS WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(mediosAlternativos) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaMediosAlternativosRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                         short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        string noEjercicio;
        private void InsertaNoEjercicio()
        {
            string Sql = " select COUNT(*) as Total from PGJ_NUC_NO_EJERCICIO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                noEjercicio = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_UNDD,FECHA_REGISTRO,ID_USUARIO FROM PGJ_NUC_NO_EJERCICIO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(noEjercicio) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaNoEjercicioRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                         short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudAcuerdosReparatorios()
        {
            string JudAcuerdosReparatorios="";

            string Sql = " select COUNT(*) as Total from PGJ_NUC_JUD_ACUERDOS_REPARATORIOS "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_ACUERDOS_REPARATORIOS.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_ACUERDOS_REPARATORIOS.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudAcuerdosReparatorios = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select ID_ACUERDO_REPARATORIO,IdPersonaNew,case when MEDIOS_ALTERNOS_PJE='True' then 1 when MEDIOS_ALTERNOS_PJE='False' then 0 end as MEDIOS_ALTERNOS_PJE, " +
            "case when ACUERDO_REPARATORIO='True' then 1 when ACUERDO_REPARATORIO='False' then 0 end as ACUERDO_REPARATORIO,FECHA_ACUERDO,FECHA_APROBACION,ID_TIPO_ACUERDO, " +
            "OBSERVACIONES_ACUERDO,ID_USUARIO,FECHA_REGISTRO from PGJ_NUC_JUD_ACUERDOS_REPARATORIOS " +
            "JOIN REMITIDAS_RELACION_ID ON " +
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_ACUERDOS_REPARATORIOS.ID_CARPETA " +
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_ACUERDOS_REPARATORIOS.ID_PERSONA " +
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudAcuerdosReparatorios) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudAcuerdosReparatoriosRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                         short.Parse(dr1["MEDIOS_ALTERNOS_PJE"].ToString()), short.Parse(dr1["ACUERDO_REPARATORIO"].ToString()), DateTime.Parse(dr1["FECHA_ACUERDO"].ToString()),
                          DateTime.Parse(dr1["FECHA_APROBACION"].ToString()), short.Parse(dr1["ID_TIPO_ACUERDO"].ToString()), dr1["OBSERVACIONES_ACUERDO"].ToString(),
                          short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudDetencion()
        {
            string JudDetencion = "";

            string Sql = " select COUNT(*) as Total from PGJ_NUC_JUD_DETENCION "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_DETENCION.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_DETENCION.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudDetencion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select IdPersonaNew,FECHA_AUDIENCIA,CASE WHEN LEGAL='True' then 1 when LEGAL='False' then 0 end as LEGAL, "+
            "OBSERVACIONES_DETENCION,ID_PROCEDIMIENTO_DETENCION,FECHA_DETENCION,ID_SUPUESTO_FLAGRANCIA,ID_USUARIO,FECHA_REGISTRO "+
            "from PGJ_NUC_JUD_DETENCION "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_DETENCION.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_DETENCION.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudDetencion) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudDetencionRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                         DateTime.Parse(dr1["FECHA_AUDIENCIA"].ToString()), short.Parse(dr1["LEGAL"].ToString()), dr1["OBSERVACIONES_DETENCION"].ToString(), short.Parse(dr1["ID_PROCEDIMIENTO_DETENCION"].ToString()),
                         DateTime.Parse(dr1["FECHA_DETENCION"].ToString()), short.Parse(dr1["ID_SUPUESTO_FLAGRANCIA"].ToString()),
                          short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudMedidaCautelar()
        {
            string JudMedidaCautelar = "";

            string Sql = " select COUNT(*) as Total "+
            "from PGJ_NUC_JUD_MEDIDAS_CAUTELARES "+
            "JOIN REMITIDAS_RELACION_ID ON  "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_MEDIDAS_CAUTELARES.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_MEDIDAS_CAUTELARES.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudMedidaCautelar = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select IdPersonaNew,CASE WHEN PROCEDENTE='True' then 1 when PROCEDENTE='False' then 0 end as PROCEDENTE,FECHA_MEDIDA,ID_TIPO_MEDIDA,FECHA_MEDIDA_DEL,FECHA_MEDIDA_AL,ID_USUARIO,FECHA_REGISTRO " +
            "from PGJ_NUC_JUD_MEDIDAS_CAUTELARES "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_MEDIDAS_CAUTELARES.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_MEDIDAS_CAUTELARES.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudMedidaCautelar) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudMedidaCautelarRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["PROCEDENTE"].ToString()), DateTime.Parse(dr1["FECHA_MEDIDA"].ToString()), short.Parse(dr1["ID_TIPO_MEDIDA"].ToString()),
                    DateTime.Parse(dr1["FECHA_MEDIDA_DEL"].ToString()), DateTime.Parse(dr1["FECHA_MEDIDA_AL"].ToString()),
                          short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

   

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudMedidaProteccion()
        {
            string JudMedidaProteccion = "";

            string Sql = " select COUNT(*) as Total "+
            "from PGJ_NUC_JUD_MEDIDAS_PROTECCION "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_MEDIDAS_PROTECCION.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_MEDIDAS_PROTECCION.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudMedidaProteccion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select IdPersonaNew,CASE WHEN PROCEDENTE='True' then 1 WHEN PROCEDENTE='False' then 2 end as PROCEDENTE,FECHA_MEDIDA,ID_TIPO_MEDIDA,PLAZO_MEDIDA,ID_USUARIO,FECHA_REGISTRO "+
            "from PGJ_NUC_JUD_MEDIDAS_PROTECCION "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_MEDIDAS_PROTECCION.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_MEDIDAS_PROTECCION.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudMedidaProteccion) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudMedidaProteccionRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["PROCEDENTE"].ToString()), DateTime.Parse(dr1["FECHA_MEDIDA"].ToString()), short.Parse(dr1["ID_TIPO_MEDIDA"].ToString()),
                    short.Parse(dr1["PLAZO_MEDIDA"].ToString()), short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudOrdenes()
        {
            string JudOrdenes = "";

            string Sql = " select COUNT(*) as Total "+
            "from PGJ_NUC_JUD_ORDENES "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_ORDENES.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_ORDENES.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudOrdenes = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select IdPersonaNew,case when SOLICITO_ORDEN='True' then 1 when SOLICITO_ORDEN='False' then 0 end as SOLICITO_ORDEN, "+
            "FECHA_ORDEN,ID_ESTADO_ORDEN,ID_TIPO_ORDEN,OBSERVACIONES_ORDEN,ID_USUARIO,FECHA_REGISTRO "+
            "from PGJ_NUC_JUD_ORDENES "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_ORDENES.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_ORDENES.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudOrdenes) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudOrdenesRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["SOLICITO_ORDEN"].ToString()), DateTime.Parse(dr1["FECHA_ORDEN"].ToString()), short.Parse(dr1["ID_ESTADO_ORDEN"].ToString()),
                    short.Parse(dr1["ID_TIPO_ORDEN"].ToString()), dr1["OBSERVACIONES_ORDEN"].ToString(), short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudPlazoInvestigacion()
        {
            string JudPlazoInvestigacion = "";

            string Sql = " select COUNT(*) as Total from PGJ_NUC_JUD_PLAZO_INVESTIGACION WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudPlazoInvestigacion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select PLAZO,ID_USUARIO,FECHA_REGISTRO from PGJ_NUC_JUD_PLAZO_INVESTIGACION WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudPlazoInvestigacion) != contador)
                {
                    dr1.Read();
                    PGJ. InsertaJudPlazoInvestigacionRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(dr1["PLAZO"].ToString())
                        , short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudProcedimientoAbreviado()
        {
            string JudProcedimientoAbreviado = "";

            string Sql = " select COUNT(*) as Total "+
            "from PGJ_NUC_JUD_PROCEDIMIENTO_ABREVIADO "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_PROCEDIMIENTO_ABREVIADO.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_PROCEDIMIENTO_ABREVIADO.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudProcedimientoAbreviado = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select IdPersonaNew,case when PROCEDIMIENTO='True' then 1 when PROCEDIMIENTO='False' then 0 end as PROCEDIMIENTO,FECHA_AUDIENCIA,ID_USUARIO,FECHA_REGISTRO "+
            "from PGJ_NUC_JUD_PROCEDIMIENTO_ABREVIADO "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_PROCEDIMIENTO_ABREVIADO.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_PROCEDIMIENTO_ABREVIADO.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudProcedimientoAbreviado) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudProcedimientoAbreviadoRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),int.Parse(dr1["IdPersonaNew"].ToString()),
                       short.Parse(dr1["PROCEDIMIENTO"].ToString()), DateTime.Parse(dr1["FECHA_AUDIENCIA"].ToString()), short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
               
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudSentencia()
        {
            string JudSentencia = "";

            string Sql = " select count(*) as Total "+
            "from PGJ_NUC_JUD_SENTENCIA "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_SENTENCIA.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_SENTENCIA.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "JOIN REMITIDAS_RELACION_ID AS Ofendido ON (Ofendido.IdCarpetaOld=PGJ_NUC_JUD_SENTENCIA.ID_CARPETA "+
            "AND Ofendido.IdPersonaOld=PGJ_NUC_JUD_SENTENCIA.ID_PERSONA_OFENDIDO "+
            "AND Ofendido.IdConsecutivoDelitoNew IS NULL AND Ofendido.IdConsecutivoDelitoOld IS NULL AND Ofendido.IdLugarHechosNew IS NULL AND Ofendido.IdLugarHechosOld IS NULL AND Ofendido.IdVehiculoNew IS NULL AND Ofendido.IdVehiculoOld IS NULL AND Ofendido.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudSentencia = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select  " +
            "REMITIDAS_RELACION_ID.IdPersonaNew as IdPersona,ID_DELITO,ID_TIPO_SENTENCIA,FECHA_SENTENCIA, "+
            "ID_TIPO_SANCION,Ofendido.IdPersonaNew as IdOfendido,ID_USUARIO,FECHA_REGISTRO, OBSERVACIONES " +
            "from PGJ_NUC_JUD_SENTENCIA "+
            "JOIN REMITIDAS_RELACION_ID ON  "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_SENTENCIA.ID_CARPETA  "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_SENTENCIA.ID_PERSONA  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ")  " +
            "JOIN REMITIDAS_RELACION_ID AS Ofendido ON (Ofendido.IdCarpetaOld=PGJ_NUC_JUD_SENTENCIA.ID_CARPETA  "+
            "AND Ofendido.IdPersonaOld=PGJ_NUC_JUD_SENTENCIA.ID_PERSONA_OFENDIDO  "+
            "AND Ofendido.IdConsecutivoDelitoNew IS NULL AND Ofendido.IdConsecutivoDelitoOld IS NULL AND Ofendido.IdLugarHechosNew IS NULL AND Ofendido.IdLugarHechosOld IS NULL AND Ofendido.IdVehiculoNew IS NULL AND Ofendido.IdVehiculoOld IS NULL AND Ofendido.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudSentencia) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudSentenciaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),  int.Parse(dr1["IdPersona"].ToString()), 
                    short.Parse(dr1["ID_DELITO"].ToString()), short.Parse(dr1["ID_TIPO_SENTENCIA"].ToString()), DateTime.Parse(dr1["FECHA_SENTENCIA"].ToString()),
                    short.Parse(dr1["ID_TIPO_SANCION"].ToString()), int.Parse(dr1["IdOfendido"].ToString()), short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()), dr1["OBSERVACIONES"].ToString());
                
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudSobreseimiento()
        {
            string JudSobreseimiento = "";

            string Sql = " select count(*) as Total from PGJ_NUC_JUD_SOBRESEIMIENTO "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_SOBRESEIMIENTO.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_SOBRESEIMIENTO.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudSobreseimiento = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select "+
            "IdPersonaNew,case when SOBRESEIMIENTO='True' then 1 when SOBRESEIMIENTO='False' then 0 end as SOBRESEIMIENTO,FECHA_SOBRESEIMIENTO,OBSERVACIONES_SOBRESEIMIENTO,ID_USUARIO,FECHA_REGISTRO "+
            "from PGJ_NUC_JUD_SOBRESEIMIENTO "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_SOBRESEIMIENTO.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_SOBRESEIMIENTO.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudSobreseimiento) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudSobreseimientoRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()), 
                    short.Parse(dr1["SOBRESEIMIENTO"].ToString()), DateTime.Parse(dr1["FECHA_SOBRESEIMIENTO"].ToString()),dr1["OBSERVACIONES_SOBRESEIMIENTO"].ToString(),
                    short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudSuspencion()
        {
            string JudSuspencion = "";

            string Sql = " select "+
            "count(*) as Total from PGJ_NUC_JUD_SUSPENCION "+
            "JOIN REMITIDAS_RELACION_ID ON "+
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_SUSPENCION.ID_CARPETA "+
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_SUSPENCION.ID_PERSONA "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudSuspencion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = " select " +
            "IdPersonaNew,case when SUSPENCION='True' then 1 when SUSPENCION='False' then 0 end as SUSPENCION, " +
            "case when REVOCA_SUSPENCION='True' then 1 when REVOCA_SUSPENCION='False' then 0 end as REVOCA_SUSPENCION, " +
            "FECHA_SUSPENCION,FECHA_INICIO_SUSPENCION,FECHA_FIN_SUSPENCION,FECHA_REANUDACION,ID_USUARIO,FECHA_REGISTRO " +
            "from PGJ_NUC_JUD_SUSPENCION "+
            "JOIN REMITIDAS_RELACION_ID ON " +
            "(REMITIDAS_RELACION_ID.IdCarpetaOld=PGJ_NUC_JUD_SUSPENCION.ID_CARPETA " +
            "AND REMITIDAS_RELACION_ID.IdPersonaOld=PGJ_NUC_JUD_SUSPENCION.ID_PERSONA " +
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudSuspencion) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudSuspensionRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()), short.Parse(dr1["SUSPENCION"].ToString()),
            short.Parse(dr1["REVOCA_SUSPENCION"].ToString()), DateTime.Parse(dr1["FECHA_SUSPENCION"].ToString()),DateTime.Parse(dr1["FECHA_INICIO_SUSPENCION"].ToString()), DateTime.Parse(dr1["FECHA_FIN_SUSPENCION"].ToString()),
            DateTime.Parse(dr1["FECHA_REANUDACION"].ToString()), short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudImputacion()
        {
            string JudImputacion = "";

            string Sql = "  select "+
            "COUNT(*) as Total "+
            "from PGJ_NUC_JUD_IMPUTACION as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=d.ID_PERSONA  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") where ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudImputacion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select ID_IMPUTACION,ID_CARPETA,ID_PERSONA, " + 
            "IdCarpetaNew,IdPersonaNew,case when IMPUTACION='True' then 1 when IMPUTACION='False' then 0 end as IMPUTACION, "+
            "FECHA_IMPUTACION,OBSERVACIONES_IMPUTACION,case when VINCULACION='True' then 1 when VINCULACION='False' then 0 end as VINCULACION, "+
            "FECHA_VINCULACION,FECHA_NO_VINCULACION,ID_USUARIO,FECHA_REGISTRO "+
            "from PGJ_NUC_JUD_IMPUTACION as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.ID_CARPETA AND REMITIDAS_RELACION_ID.IdPersonaOld=d.ID_PERSONA  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudImputacion) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudImputacionRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()), short.Parse(dr1["IMPUTACION"].ToString()),
                    DateTime.Parse(dr1["FECHA_IMPUTACION"].ToString()), dr1["OBSERVACIONES_IMPUTACION"].ToString(), short.Parse(dr1["VINCULACION"].ToString()), DateTime.Parse(dr1["FECHA_VINCULACION"].ToString()),
                    short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    consultaIdImputacion();
                    PGJ.insertaRemitidasImputacion(int.Parse(dr1["IdCarpetaNew"].ToString()), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_IMPUTACION.Text), int.Parse(dr1["ID_IMPUTACION"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaJudVinculacionDelito()
        {
            string JudVinculacionDelito = "";

            string Sql = "SELECT "+
            "COUNT(*) as Total "+
            "FROM PGJ_NUC_JUD_VINCULACION_DELITOS "+
            "JOIN REMITIDAS_RELACION_IMPUTACION ON (REMITIDAS_RELACION_IMPUTACION.Idimputacionold=ID_IMPUTACION AND REMITIDAS_RELACION_IMPUTACION.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdcarpetaOld=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                JudVinculacionDelito = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT  "+
            "Idimputacionnew,ID_DELITO,ID_MODALIDAD,ID_CALIFICACION "+
            "FROM PGJ_NUC_JUD_VINCULACION_DELITOS "+
            "JOIN REMITIDAS_RELACION_IMPUTACION ON (REMITIDAS_RELACION_IMPUTACION.Idimputacionold=ID_IMPUTACION AND REMITIDAS_RELACION_IMPUTACION.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdcarpetaOld=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(JudVinculacionDelito) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaJudVinculacionDelitosRemitir(int.Parse(dr1["Idimputacionnew"].ToString()), short.Parse(dr1["ID_DELITO"].ToString()),
                        short.Parse(dr1["ID_MODALIDAD"].ToString()),short.Parse(dr1["ID_CALIFICACION"].ToString()) );
                   
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        void consultaIdImputacion()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(ID_IMPUTACION),1) as ID_IMPUTACION  From PGJ_NUC_JUD_IMPUTACION WHERE ID_CARPETA = " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_IMPUTACION.Text = dr["ID_IMPUTACION"].ToString();

            //}
            dr.Close();
        }

        private void InsertaRACIniciada()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from PGJ_RAC_INICIADA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_USUARIO,FECHA_REGISTRO FROM PGJ_RAC_INICIADA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACIniciadaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                        int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACRemitida()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from PGJ_RAC_REMITIDA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT MP,ID_USUARIO,FECHA_REGISTRO FROM PGJ_RAC_REMITIDA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACRemitidaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                    dr1["MP"].ToString(), int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACCanalizada()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from PGJ_RAC_CANALIZADA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_INSTITUCION,ID_USUARIO,FECHA_REGISTRO FROM PGJ_RAC_CANALIZADA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACCanalizadaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(dr1["ID_INSTITUCION"].ToString()),
                        int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACConvenio()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from  PGJ_RAC_CONVENIO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_UNDD,ID_USUARIO,FECHA_REGISTRO FROM  PGJ_RAC_CONVENIO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACConvenioRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                    int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACConvenioIncumplido()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from   PGJ_RAC_CONVENIO_INCUMPLIDO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_USUARIO,FECHA_REGISTRO FROM PGJ_RAC_CONVENIO_INCUMPLIDO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACConvenioIncumplidoRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                    int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACIncompetencia()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from PGJ_RAC_INCOMPETENCIA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_USUARIO,FECHA_REGISTRO,ID_AGENCIA FROM  PGJ_RAC_INCOMPETENCIA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACIncompetenciaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                    int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()), short.Parse(dr1["ID_AGENCIA"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACNoConvenio()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from PGJ_RAC_NO_CONVENIO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_USUARIO,FECHA_REGISTRO FROM  PGJ_RAC_NO_CONVENIO WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACNoConvenioRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                    int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                        
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACResuelta()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from  PGJ_RAC_RESUELTA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT RESOLVIO,ID_USUARIO,FECHA_REGISTRO FROM   PGJ_RAC_RESUELTA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACResueltaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), dr1["RESOLVIO"].ToString(),
                    int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACSuspendida()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from PGJ_RAC_SUSPENDIDA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_USUARIO,FECHA_REGISTRO FROM PGJ_RAC_SUSPENDIDA WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACSuspendidaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                    int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertaRACAcuerdoAbsInv()
        {
            string RacIniciada = "";
            string Sql = " select COUNT(*) as Total from PGJ_RAC_ACUERDO_ABS_INV WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                RacIniciada = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT ID_USUARIO,FECHA_REGISTRO FROM PGJ_RAC_ACUERDO_ABS_INV WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(RacIniciada) != contador)
                {
                    dr1.Read();
                    PGJ.InsertaRACAcuerdoAbsInvRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),
                    int.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }


        //VEHICULOS
        private void InsertarVehiculo()
        {
            string vehiculo = "";
            string Sql = "SELECT COUNT(*) as Total FROM PGJ_VEHICULO where ID_VEHICULO not in (select ID_VEHICULO from PGJ_VEHICULO_ROBADO_RECUPERADO) and ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                vehiculo = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT NUMERO_ACCIDENTE,ID_MARCA,ID_SUBMARCA,ID_MODELO,ID_COLOR,SERIE,PLACA,ID_PLACA_ESTADO,ID_PROCEDENCIA,ID_TIPO_VEHICULO,ID_PUSO_DISPOSICION, "+
            "ID_ASEGURADO,OBSERVACIONES,SENAS,ID_TPO_USO_VEHICULO,ID_ASEGURADORA,NUMERO_MOTOR,REGISTRO_NIV,FECHA_REGISTRO "+
            "FROM PGJ_VEHICULO " +
            "where ID_VEHICULO not in (select ID_VEHICULO from PGJ_VEHICULO_ROBADO_RECUPERADO) and ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(vehiculo) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaVehiculoRemitir(int.Parse(lblIdCN.Text), dr1["NUMERO_ACCIDENTE"].ToString(), short.Parse(dr1["ID_MARCA"].ToString()), int.Parse(dr1["ID_SUBMARCA"].ToString()),
                    short.Parse(dr1["ID_MODELO"].ToString()),short.Parse(dr1["ID_COLOR"].ToString()),dr1["SERIE"].ToString(),dr1["PLACA"].ToString(),short.Parse(dr1["ID_PLACA_ESTADO"].ToString()),
                    short.Parse(dr1["ID_PROCEDENCIA"].ToString()),short.Parse(dr1["ID_TIPO_VEHICULO"].ToString()),short.Parse(dr1["ID_PUSO_DISPOSICION"].ToString()),short.Parse(dr1["ID_ASEGURADO"].ToString()),
                    dr1["OBSERVACIONES"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), dr1["SENAS"].ToString(), short.Parse(dr1["ID_TPO_USO_VEHICULO"].ToString()),
                    short.Parse(dr1["ID_ASEGURADORA"].ToString()), dr1["NUMERO_MOTOR"].ToString(), dr1["REGISTRO_NIV"].ToString(), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    //GUARDAR EL ID DEL VEHICULO

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarVehiculoRobado()
        {
            string vehiculo = "";
            string Sql = "SELECT COUNT(*) as Total "+
            "FROM PGJ_VEHICULO as Veh "+
            "JOIN PGJ_VEHICULO_ROBADO_RECUPERADO as RobRec on (RobRec.ID_VEHICULO=Veh.ID_VEHICULO and RobRec.ID_CARPETA=Veh.ID_CARPETA and RobRec.ID_MUNICIPIO_VEHICULO=Veh.ID_MUNICIPIO_VEHICULO) "+
            "JOIN REMITIDAS_RELACION_ID  as R on (R.IdCarpetaOld=Veh.ID_CARPETA and R.IdPersonaOld=RobRec.ID_PERSONA_PRPIETRIO and IdConsecutivoDelitoNew is null and IdConsecutivoDelitoOld is null "+
            "and IdLugarHechosNew is null and IdLugarHechosOld is null and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "JOIN REMITIDAS_RELACION_ID  as RD on (RD.IdCarpetaOld=Veh.ID_CARPETA and RD.IdPersonaOld is null and RD.IdConsecutivoDelitoOld=RobRec.ID_CONSECUTIVO_DELITO "+
            "and RD.IdLugarHechosNew is null and RD.IdLugarHechosOld is null and RD.IdVehiculoNew is null and RD.IdVehiculoOld is null AND RD.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_ESTDO_VEHICULO=1 AND veh.ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                vehiculo = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT Veh.ID_VEHICULO as Id,NUMERO_ACCIDENTE,ID_MARCA,ID_SUBMARCA,ID_MODELO,ID_COLOR,SERIE,PLACA,ID_PLACA_ESTADO,ID_PROCEDENCIA,ID_TIPO_VEHICULO,ID_PUSO_DISPOSICION, " +
            "ID_ASEGURADO,OBSERVACIONES,SENAS,ID_TPO_USO_VEHICULO,ID_ASEGURADORA,FCHA_ROBO,HRA_ROBO,ID_ESTDO_VEHICULO, " +
            "R.IdPersonaNew,ID_PERSONA_PRPIETRIO,ID_CONSECUTIVO_DELITO,RD.IdConsecutivoDelitoNew,ID_USUARIO,NUMERO_MOTOR,REGISTRO_NIV,veh.FECHA_REGISTRO as FR " +
            "FROM PGJ_VEHICULO as Veh " +
            "JOIN PGJ_VEHICULO_ROBADO_RECUPERADO as RobRec on (RobRec.ID_VEHICULO=Veh.ID_VEHICULO and RobRec.ID_CARPETA=Veh.ID_CARPETA and RobRec.ID_MUNICIPIO_VEHICULO=Veh.ID_MUNICIPIO_VEHICULO) " +
            "JOIN REMITIDAS_RELACION_ID  as R on (R.IdCarpetaOld=Veh.ID_CARPETA and R.IdPersonaOld=RobRec.ID_PERSONA_PRPIETRIO and IdConsecutivoDelitoNew is null and IdConsecutivoDelitoOld is null " +
            "and IdLugarHechosNew is null and IdLugarHechosOld is null and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "JOIN REMITIDAS_RELACION_ID  as RD on (RD.IdCarpetaOld=Veh.ID_CARPETA and RD.IdPersonaOld is null and RD.IdConsecutivoDelitoOld=RobRec.ID_CONSECUTIVO_DELITO " +
            "and RD.IdLugarHechosNew is null and RD.IdLugarHechosOld is null and RD.IdVehiculoNew is null and RD.IdVehiculoOld is null AND RD.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_ESTDO_VEHICULO=1 AND veh.ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(vehiculo) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaVehiculoRobadoRemitir(int.Parse(lblIdCN.Text), dr1["NUMERO_ACCIDENTE"].ToString(), short.Parse(dr1["ID_MARCA"].ToString()), int.Parse(dr1["ID_SUBMARCA"].ToString()),
                    short.Parse(dr1["ID_MODELO"].ToString()), short.Parse(dr1["ID_COLOR"].ToString()), dr1["SERIE"].ToString(), dr1["PLACA"].ToString(),short.Parse(dr1["ID_PLACA_ESTADO"].ToString()),
                    short.Parse(dr1["ID_PROCEDENCIA"].ToString()), short.Parse(dr1["ID_TIPO_VEHICULO"].ToString()), short.Parse(dr1["ID_PUSO_DISPOSICION"].ToString()), short.Parse(dr1["ID_ASEGURADO"].ToString()),
                    dr1["OBSERVACIONES"].ToString(),short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),dr1["SENAS"].ToString(), short.Parse(dr1["ID_TPO_USO_VEHICULO"].ToString()),
                    short.Parse(dr1["ID_ASEGURADORA"].ToString()),DateTime.Parse(dr1["FCHA_ROBO"].ToString()), dr1["HRA_ROBO"].ToString(),
                    short.Parse(dr1["ID_ESTDO_VEHICULO"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()), int.Parse(dr1["IdConsecutivoDelitoNew"].ToString()), int.Parse(Session["IdUsuarioRemitir"].ToString()),
                    short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()), dr1["NUMERO_MOTOR"].ToString(), dr1["REGISTRO_NIV"].ToString(), DateTime.Parse(dr1["FR"].ToString()));
                    consultaIdVehiculo();
                    //GUARDAR EL ID DEL VEHICULO
                    PGJ.insertaRemitidasVehiculo(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_VEHICULO.Text), int.Parse(dr1["Id"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        void consultaIdVehiculo()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(ID_VEHICULO),1) as ID_VEHICULO  From PGJ_VEHICULO WHERE ID_CARPETA = " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_VEHICULO.Text = dr["ID_VEHICULO"].ToString();

            //}
            dr.Close();
        }

        private void InsertarVehiculoRecuperado()
        {
            string vehiculo = "";
            string Sql = "SELECT COUNT(*) as Total " +
            "FROM PGJ_VEHICULO as Veh " +
            "JOIN PGJ_VEHICULO_ROBADO_RECUPERADO as RobRec on (RobRec.ID_VEHICULO=Veh.ID_VEHICULO and RobRec.ID_CARPETA=Veh.ID_CARPETA and RobRec.ID_MUNICIPIO_VEHICULO=Veh.ID_MUNICIPIO_VEHICULO) " +
            "JOIN REMITIDAS_RELACION_ID  as R on (R.IdCarpetaOld=Veh.ID_CARPETA and R.IdPersonaOld=RobRec.ID_PERSONA_PRPIETRIO and IdConsecutivoDelitoNew is null and IdConsecutivoDelitoOld is null " +
            "and IdLugarHechosNew is null and IdLugarHechosOld is null and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "JOIN REMITIDAS_RELACION_ID  as RD on (RD.IdCarpetaOld=Veh.ID_CARPETA and RD.IdPersonaOld is null and RD.IdConsecutivoDelitoOld=RobRec.ID_CONSECUTIVO_DELITO " +
            "and RD.IdLugarHechosNew is null and RD.IdLugarHechosOld is null and RD.IdVehiculoNew is null and RD.IdVehiculoOld is null AND RD.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_ESTDO_VEHICULO=2 AND veh.ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                vehiculo = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT Veh.ID_VEHICULO as Id,NUMERO_ACCIDENTE,ID_MARCA,ID_SUBMARCA,ID_MODELO,ID_COLOR,SERIE,PLACA,ID_PLACA_ESTADO,ID_PROCEDENCIA,ID_TIPO_VEHICULO,ID_PUSO_DISPOSICION, " +
            "ID_ASEGURADO,OBSERVACIONES,SENAS,ID_TPO_USO_VEHICULO,ID_ASEGURADORA,FCHA_ROBO,HRA_ROBO,ID_ESTDO_VEHICULO, " +
            "R.IdPersonaNew,ID_PERSONA_PRPIETRIO,ID_CONSECUTIVO_DELITO,RD.IdConsecutivoDelitoNew,ID_USUARIO,NUMERO_MOTOR,REGISTRO_NIV,veh.FECHA_REGISTRO as FR, " +
            "FCHA_RCPRCION,HRA_RCPRCION,ID_DEPOSITADO,FCHA_DEPOSITADO,HRA_DEPOSITADO "+
            "FROM PGJ_VEHICULO as Veh " +
            "JOIN PGJ_VEHICULO_ROBADO_RECUPERADO as RobRec on (RobRec.ID_VEHICULO=Veh.ID_VEHICULO and RobRec.ID_CARPETA=Veh.ID_CARPETA and RobRec.ID_MUNICIPIO_VEHICULO=Veh.ID_MUNICIPIO_VEHICULO) " +
            "JOIN REMITIDAS_RELACION_ID  as R on (R.IdCarpetaOld=Veh.ID_CARPETA and R.IdPersonaOld=RobRec.ID_PERSONA_PRPIETRIO and IdConsecutivoDelitoNew is null and IdConsecutivoDelitoOld is null " +
            "and IdLugarHechosNew is null and IdLugarHechosOld is null and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "JOIN REMITIDAS_RELACION_ID  as RD on (RD.IdCarpetaOld=Veh.ID_CARPETA and RD.IdPersonaOld is null and RD.IdConsecutivoDelitoOld=RobRec.ID_CONSECUTIVO_DELITO " +
            "and RD.IdLugarHechosNew is null and RD.IdLugarHechosOld is null and RD.IdVehiculoNew is null and RD.IdVehiculoOld is null AND RD.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_ESTDO_VEHICULO=2 AND veh.ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(vehiculo) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaVehiculoRecuperadoRemitir(int.Parse(lblIdCN.Text), dr1["NUMERO_ACCIDENTE"].ToString(), short.Parse(dr1["ID_MARCA"].ToString()), int.Parse(dr1["ID_SUBMARCA"].ToString()),
                    short.Parse(dr1["ID_MODELO"].ToString()), short.Parse(dr1["ID_COLOR"].ToString()), dr1["SERIE"].ToString(), dr1["PLACA"].ToString(), short.Parse(dr1["ID_PLACA_ESTADO"].ToString()),
                    short.Parse(dr1["ID_PROCEDENCIA"].ToString()), short.Parse(dr1["ID_TIPO_VEHICULO"].ToString()), short.Parse(dr1["ID_PUSO_DISPOSICION"].ToString()), short.Parse(dr1["ID_ASEGURADO"].ToString()),
                    dr1["OBSERVACIONES"].ToString(), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), dr1["SENAS"].ToString(), short.Parse(dr1["ID_TPO_USO_VEHICULO"].ToString()),
                    short.Parse(dr1["ID_ASEGURADORA"].ToString()), DateTime.Parse(dr1["FCHA_ROBO"].ToString()), dr1["HRA_ROBO"].ToString(),
                    short.Parse(dr1["ID_ESTDO_VEHICULO"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()), int.Parse(dr1["IdConsecutivoDelitoNew"].ToString()), int.Parse(Session["IdUsuarioRemitir"].ToString()),
                    short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()), dr1["NUMERO_MOTOR"].ToString(), dr1["REGISTRO_NIV"].ToString(),DateTime.Parse(dr1["FCHA_RCPRCION"].ToString()),
                    dr1["HRA_RCPRCION"].ToString(), short.Parse(dr1["ID_DEPOSITADO"].ToString()), DateTime.Parse(dr1["FCHA_DEPOSITADO"].ToString()), dr1["HRA_DEPOSITADO"].ToString(), DateTime.Parse(dr1["FR"].ToString()));
                        
                    consultaIdVehiculo();
                    //GUARDAR EL ID DEL VEHICULO
                    PGJ.insertaRemitidasVehiculo(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_VEHICULO.Text), int.Parse(dr1["Id"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarAutorizacion()
        {
            string vehiculo = "";
            string Sql = "SELECT COUNT(*) as Total FROM PGJ_AUTORIZACION as Autorizacion "+
            "JOIN REMITIDAS_RELACION_ID  as R on (R.IdCarpetaOld=IdCarpeta and R.IdVehiculoOld=Autorizacion.IdVehiculo AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                vehiculo = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT IdCarpetaNew,IdAutorizacion,IdVehiculoNew,IdUsuario,Autorizacion,Autorizacion.FechaRegistro as FR,Activo "+
            "FROM PGJ_AUTORIZACION as Autorizacion "+
            "JOIN REMITIDAS_RELACION_ID  as R on (R.IdCarpetaOld=IdCarpeta and R.IdVehiculoOld=Autorizacion.IdVehiculo AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(vehiculo) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaAutorizacionRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdVehiculoNew"].ToString()),
                    int.Parse(dr1["IdUsuario"].ToString()), dr1["Autorizacion"].ToString(), DateTime.Parse(dr1["FR"].ToString()), int.Parse(dr1["Activo"].ToString()));

                    consultaIdAutorizacion();
                    //GUARDAR EL ID DE LA AUTORIZACION
                    PGJ.insertaRemitidasAutorizacion(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_AUTORIZACION.Text), int.Parse(dr1["IdAutorizacion"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));
                        
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }


        void consultaIdAutorizacion()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(IdAutorizacion),1) as IdAutorizacion  From PGJ_AUTORIZACION WHERE IdCarpeta= " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_AUTORIZACION.Text = dr["IdAutorizacion"].ToString();

            //}
            dr.Close();
        }

        private void InsertarVehiculoPDF()
        {
            string vehiculo = "";
            string Sql = "SELECT COUNT(*) as Total "+
            "FROM PGJ_VEHICULO_PDF "+
            "left outer join REMITIDAS_RELACION_ID as Vehiculo on (Vehiculo.IdCarpetaOld=IdCarpeta and Vehiculo.IdVehiculoOld=IdVehiculo AND Vehiculo.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "left outer join REMITIDAS_RELACION_VEHICULO AS Pdf on (Pdf.IdCarpetaOld=IdCarpeta and pdf.idpdfold=IdPDF AND Pdf.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "left outer join REMITIDAS_RELACION_VEHICULO AS Autorizacion on (Autorizacion.IdCarpetaOld=IdCarpeta and Autorizacion.idautorizacionold=IdAutorizacion AND Autorizacion.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                vehiculo = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT  "+
            "Vehiculo.IdVehiculoNew,pdf.idpdfnew,Autorizacion.idautorizacionnew "+
            "FROM PGJ_VEHICULO_PDF "+
            "left outer join REMITIDAS_RELACION_ID as Vehiculo on (Vehiculo.IdCarpetaOld=IdCarpeta and Vehiculo.IdVehiculoOld=IdVehiculo AND Vehiculo.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "left outer join REMITIDAS_RELACION_VEHICULO AS Pdf on (Pdf.IdCarpetaOld=IdCarpeta and pdf.idpdfold=IdPDF AND Pdf.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "left outer join REMITIDAS_RELACION_VEHICULO AS Autorizacion on (Autorizacion.IdCarpetaOld=IdCarpeta and Autorizacion.idautorizacionold=IdAutorizacion AND Autorizacion.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(vehiculo) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaPdfVehiculoRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdVehiculoNew"].ToString()),
                        int.Parse(dr1["idautorizacionnew"].ToString()), int.Parse(dr1["idpdfnew"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        //DOCUMENTOS
        private void InsertaCarpetaPDF()
        {
            string carpetapdf = "";

            string Sql = "SELECT COUNT(*) as Total "+
            "FROM PGJ_CARPETA_PDF as Pdf "+
            "left outer JOIN REMITIDAS_RELACION_ID as Denunciante on (Denunciante.IdPersonaOld=ID_DENCINCIANTE and Denunciante.IdCarpetaOld=ID_CARPETA AND Denunciante.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "left outer JOIN REMITIDAS_RELACION_ID as Ofendido on (Ofendido.IdPersonaOld=ID_OFENDIDO and Ofendido.IdCarpetaOld=ID_CARPETA AND Ofendido.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "left outer JOIN REMITIDAS_RELACION_ID as Imputado on (Imputado.IdPersonaOld=ID_IMPUTADO and Imputado.IdCarpetaOld=ID_CARPETA AND Imputado.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "left outer JOIN REMITIDAS_RELACION_ID as Testigo on (Testigo.IdPersonaOld=ID_TESTIGO and Testigo.IdCarpetaOld=ID_CARPETA AND Testigo.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "left outer JOIN REMITIDAS_RELACION_ID as Defensor on (Defensor.IdPersonaOld=ID_DEFENSOR and Defensor.IdCarpetaOld=ID_CARPETA AND Defensor.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                carpetapdf = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT ID_PDF,PDF,DOCUMENTO,ID_PLANTILLA,ID_DENCINCIANTE, "+
            "case when Denunciante.IdPersonaNew is null then 0 else Denunciante.IdPersonaNew end as IdDenunciante, "+
            "ID_OFENDIDO,case when Ofendido.IdPersonaNew is null then 0 else Ofendido.IdPersonaNew end as IdOfendido, "+
            "ID_IMPUTADO,case when Imputado.IdPersonaNew is null then 0 else Imputado.IdPersonaNew end as IdImputado, "+
            "ID_TESTIGO,case when Testigo.IdPersonaNew is null then 0 else Testigo.IdPersonaNew end as IdTestigo, "+
            "ID_DEFENSOR,case when Defensor.IdPersonaNew is null then 0 else Defensor.IdPersonaNew end as IdDefensor, "+
            "ID_USUARIO,FECHA_REGISTRO  "+
            "FROM PGJ_CARPETA_PDF as Pdf "+
            "left outer JOIN REMITIDAS_RELACION_ID as Denunciante on (Denunciante.IdPersonaOld=ID_DENCINCIANTE and Denunciante.IdCarpetaOld=ID_CARPETA AND Denunciante.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " )" +
            "left outer JOIN REMITIDAS_RELACION_ID as Ofendido on (Ofendido.IdPersonaOld=ID_OFENDIDO and Ofendido.IdCarpetaOld=ID_CARPETA AND Ofendido.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "left outer JOIN REMITIDAS_RELACION_ID as Imputado on (Imputado.IdPersonaOld=ID_IMPUTADO and Imputado.IdCarpetaOld=ID_CARPETA AND Imputado.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "left outer JOIN REMITIDAS_RELACION_ID as Testigo on (Testigo.IdPersonaOld=ID_TESTIGO and Testigo.IdCarpetaOld=ID_CARPETA AND Testigo.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "left outer JOIN REMITIDAS_RELACION_ID as Defensor on (Defensor.IdPersonaOld=ID_DEFENSOR and Defensor.IdCarpetaOld=ID_CARPETA AND Defensor.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();

            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(carpetapdf) != contador)
                {
                    dr1.Read();
                    byte[] bits = ((byte[])(dr1["PDF"]));

                    Archivos.InsertaCarpetaPDFRemitir(int.Parse(lblIdCN.Text), bits, dr1["DOCUMENTO"].ToString(), short.Parse(dr1["ID_PLANTILLA"].ToString()), 
                    int.Parse(dr1["IdDenunciante"].ToString()),int.Parse(dr1["IdOfendido"].ToString()),int.Parse(dr1["IdImputado"].ToString()),int.Parse(dr1["IdTestigo"].ToString()),
                    int.Parse(dr1["IdDefensor"].ToString()), short.Parse(Session["IdUsuarioRemitir"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    short.Parse(Session["ID_UNIDAD_REMITIR"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    
                    consultaIdPdf();

                    PGJ.insertaRemitidasPdf(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_PDF.Text), int.Parse(dr1["ID_PDF"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        void consultaIdPdf()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(ID_PDF),1) as ID_PDF  From PGJ_CARPETA_PDF WHERE ID_CARPETA= " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_PDF.Text = dr["ID_PDF"].ToString();

            //}
            dr.Close();
        }

        //PNL
        private void InsertarSujetoInterviene()
        {
            string SujetoInterviene = "";
            string Sql = " SELECT "+
            "COUNT(*) as Total "+
            "FROM PNL_SUJETOS_INTERVIENE "+
            "JOIN REMITIDAS_RELACION_ID as R on (R.IdCarpetaOld=PNL_SUJETOS_INTERVIENE.IdCarpeta and PNL_SUJETOS_INTERVIENE.IdConsecutivo=R.IdConsecutivoDelitoOld "+
            "and IdLugarHechosNew is null and IdLugarHechosOld is null and IdPersonaNew is null and IdPersonaOld is null and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                SujetoInterviene = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT  "+
            "IdCarpetaNew,IdDelito,IdSujetoInterviene,IdTipoSujetoInterviene,PNL_SUJETOS_INTERVIENE.FechaRegistro as FR,Activo,IdConsecutivoDelitoNew " +
            "FROM PNL_SUJETOS_INTERVIENE "+
            "JOIN REMITIDAS_RELACION_ID as R on (R.IdCarpetaOld=PNL_SUJETOS_INTERVIENE.IdCarpeta and PNL_SUJETOS_INTERVIENE.IdConsecutivo=R.IdConsecutivoDelitoOld "+
            "and IdLugarHechosNew is null and IdLugarHechosOld is null and IdPersonaNew is null and IdPersonaOld is null and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(SujetoInterviene) != contador)
                {
                    dr1.Read();

                    PGJ.PNLInsertaSujetoIntevieneRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                        int.Parse(dr1["IdDelito"].ToString()), int.Parse(dr1["IdSujetoInterviene"].ToString()), int.Parse(dr1["IdTipoSujetoInterviene"].ToString()), int.Parse(dr1["Activo"].ToString()),
                        DateTime.Parse(dr1["FR"].ToString()) );

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarBoletin()
        {
            string Boletin = "";
            string Sql = " SELECT "+
            "COUNT(*) as Total "+
            "FROM PNL_BOLETIN_PDF "+
            "JOIN REMITIDAS_RELACION_ID as R on (R.IdCarpetaOld=PNL_BOLETIN_PDF.IdCarpeta and PNL_BOLETIN_PDF.IdPersona=IdPersonaOld "+
            "and IdConsecutivoDelitoNew is null and IdConsecutivoDelitoOld is null and IdLugarHechosNew is null and IdLugarHechosOld is null "+
            "and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Boletin = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT  "+
            "IdCarpetaNew,IdTipoBoletin,IdPersonaNew,PDF,NumeroReporte,Activo,IdUsuario,PNL_BOLETIN_PDF.FechaRegistro as FR "+
            "FROM PNL_BOLETIN_PDF "+
            "JOIN REMITIDAS_RELACION_ID as R on (R.IdCarpetaOld=PNL_BOLETIN_PDF.IdCarpeta and PNL_BOLETIN_PDF.IdPersona=IdPersonaOld "+
            "and IdConsecutivoDelitoNew is null and IdConsecutivoDelitoOld is null and IdLugarHechosNew is null and IdLugarHechosOld is null "+
            "and IdVehiculoNew is null and IdVehiculoOld is null AND R.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(Boletin) != contador)
                {
                    dr1.Read();

                    byte[] bits = ((byte[])(dr1["PDF"]));

                    PGJ.InsertaBoletinPDFRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), int.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdTipoBoletin"].ToString()),
                    int.Parse(dr1["IdPersonaNew"].ToString()), bits, dr1["NumeroReporte"].ToString(), int.Parse(dr1["IdUsuario"].ToString()), 
                    DateTime.Parse(dr1["FR"].ToString()),int.Parse(dr1["Activo"].ToString()) );

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarDatosGenerales()
        {
            string datosGenerales = "";
            string Sql = " SELECT "+ 
            "COUNT(*) as Total "+
            "FROM PNL_DATOS_GENERALES as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                datosGenerales = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT  "+ 
            "IdCarpetaNew,IdPersonaNew,IdEtnia,FechaUltimoAvistamiento,IdActividad "+ 
            "FROM PNL_DATOS_GENERALES as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(datosGenerales) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaDatosGeneralesRemitir(0, int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),  int.Parse(dr1["IdPersonaNew"].ToString()),
                    int.Parse(dr1["IdEtnia"].ToString()), DateTime.Parse(dr1["FechaUltimoAvistamiento"].ToString()), short.Parse(dr1["IdActividad"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarPertenenciaSocial()
        {
            string pertenenciaSocial = "";
            string Sql = " SELECT "+
            "COUNT(*) as Total "+
            "FROM PNL_PERTENENCIA_SOCIAL as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                pertenenciaSocial = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT  "+
            "IdCarpetaNew,IdPersonaNew,MiembroONG,Sindicalista,Reinsertado,GrupoReligioso,OrganismoEstatal,GrupoDH,Otros "+
            "FROM PNL_PERTENENCIA_SOCIAL as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL AND REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + " ) " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(pertenenciaSocial) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaPertenenciaSocialRemitir(0, int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    int.Parse(dr1["IdPersonaNew"].ToString()), dr1["MiembroONG"].ToString(), dr1["Sindicalista"].ToString(), dr1["Reinsertado"].ToString(), dr1["GrupoReligioso"].ToString(),
                    dr1["OrganismoEstatal"].ToString(), dr1["GrupoDH"].ToString(), dr1["Otros"].ToString());

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarDiscapacidades()
        {
            string discapacidad = "";
            string Sql = " SELECT "+ 
            "COUNT(*) as Total "+
            "FROM PNL_DISCAPACIDADES as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                discapacidad = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT "+  
            "IdCarpetaNew,IdPersonaNew,IdDiscapacidadMental,OtraDiscapacidadMental,IdDiscapacidadFisica,OtraDiscapacidadFisica, "+ 
            "Padecimientos,EnfermedadSistematica,EnfermedadMental,EnfermedadPiel,Adicciones,Medicamentos,Cirugias,Embarazo, "+ 
            "Cesarea, PartoNatural, Aborto,  "+ 
            "ControlNatal,OtroControlNatal "+ 
            "FROM PNL_DISCAPACIDADES as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+  
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(discapacidad) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaDiscapacidadesRemitir(0, int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["IdDiscapacidadMental"].ToString()),dr1["OtraDiscapacidadMental"].ToString(),short.Parse(dr1["IdDiscapacidadFisica"].ToString()),dr1["OtraDiscapacidadFisica"].ToString(),
                    dr1["Padecimientos"].ToString(),dr1["EnfermedadSistematica"].ToString(), dr1["EnfermedadMental"].ToString(),dr1["EnfermedadPiel"].ToString(),dr1["Adicciones"].ToString(),
                    dr1["Medicamentos"].ToString(), dr1["Cirugias"].ToString(), short.Parse(dr1["Embarazo"].ToString()), bool.Parse(dr1["Cesarea"].ToString()), bool.Parse(dr1["PartoNatural"].ToString()),
                    bool.Parse(dr1["Aborto"].ToString()), short.Parse(dr1["ControlNatal"].ToString()), dr1["OtroControlNatal"].ToString());
                        
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarInformacionFinanciera()
        {
            string informacionFinanciera = "";
            string Sql = " SELECT "+
            "COUNT(*) as Total "+
            "FROM PNL_INFORMACION_FINANCIERA as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL  and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ")" +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                informacionFinanciera = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "	SELECT "+
            "IdCarpetaNew,IdPersonaNew,IdBanco,NumCuenta,TipoCuenta,TarjetaCredito,NumTarjetaCredito,TarjetaDebito,TarjetaDepartamental,NumTarjetaDepartamental "+
            "FROM PNL_INFORMACION_FINANCIERA as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(informacionFinanciera) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaInfoFinancieraRemitir(0,int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["IdBanco"].ToString()),dr1["NumCuenta"].ToString(),dr1["TipoCuenta"].ToString(),short.Parse(dr1["TarjetaCredito"].ToString()),dr1["NumTarjetaCredito"].ToString(),
                    short.Parse(dr1["TarjetaDebito"].ToString()) ,dr1["NumTarjetaCredito"].ToString(),dr1["TarjetaDepartamental"].ToString(),dr1["NumTarjetaDepartamental"].ToString() ); 

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarInformacionOdontologica()
        {
            string informacionFinanciera = "";
            string Sql = "SELECT "+
            "COUNT(*) as Total "+
            "FROM PNL_INFORMACION_ODONTOLOGICA as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                informacionFinanciera = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT "+ 
            "IdCarpetaNew,IdPersonaNew,ExpedienteDental,Odontologo,TamañoDientes,DientesCompletos,DientesSeparados,DientesGirados,DientesApiñonados,DientesManchados, "+
            "DientesDesgaste,Resinas,Amalgamas,CoronasMetalicas,CoronasEsteticas,Endodoncia,Blanqueamiento,Incrustacion,OtroTratamiento,IdProtesis,Braquets,Braquets, "+
            "Implantes,OtroAditamento,AditamentoEnDesaparicion,AusenciaDental,HabitosDentales "+
            "FROM PNL_INFORMACION_ODONTOLOGICA as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(informacionFinanciera) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaInformacionOdontologicaRemitir(0, int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["ExpedienteDental"].ToString()), dr1["Odontologo"].ToString(),short.Parse(dr1["TamañoDientes"].ToString()),short.Parse(dr1["DientesCompletos"].ToString()),
                    short.Parse(dr1["DientesSeparados"].ToString()),short.Parse(dr1["DientesGirados"].ToString()),short.Parse(dr1["DientesApiñonados"].ToString()),short.Parse(dr1["DientesManchados"].ToString()),
                    short.Parse(dr1["DientesDesgaste"].ToString()),short.Parse(dr1["Resinas"].ToString()),short.Parse(dr1["Amalgamas"].ToString()),short.Parse(dr1["CoronasMetalicas"].ToString()),
                    short.Parse(dr1["CoronasEsteticas"].ToString()),short.Parse(dr1["Endodoncia"].ToString()),short.Parse(dr1["Blanqueamiento"].ToString()),short.Parse(dr1["Incrustacion"].ToString()), 
                    dr1["OtroTratamiento"].ToString(),short.Parse(dr1["IdProtesis"].ToString()),short.Parse(dr1["Braquets"].ToString()),short.Parse(dr1["Braquets"].ToString()),
                    short.Parse(dr1["Implantes"].ToString()),dr1["OtroAditamento"].ToString(),short.Parse(dr1["AditamentoEnDesaparicion"].ToString()),
                    dr1["AusenciaDental"].ToString(),dr1["HabitosDentales"].ToString() );

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarOtraInformacion()
        {
            string otraInformacion = "";
            string Sql = "SELECT "+ 
            "COUNT(*) as Total "+ 
            "FROM PNL_OTRA_INFORMACION as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+  
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                otraInformacion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT "+  
            "IdCarpetaNew,IdPersonaNew,Detencion,Allanamiento,Hostigamiento,Amenazas,Lesiones,DisposicionDinero,ProblemasVecinales,ProblemasFamiliares, "+ 
            "ActitudNerviosa,MovimientoCuentaBancaria,ComunicacionDesaparecido,ComunicacionCaptores,SolicitudParaDejarloLibre,ComInternetParadero,ComPersonasParadero "+ 
            "FROM PNL_OTRA_INFORMACION as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+  
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(otraInformacion) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaOtraInformacionRemitir(0, int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    bool.Parse(dr1["Detencion"].ToString()),bool.Parse(dr1["Allanamiento"].ToString()),bool.Parse(dr1["Hostigamiento"].ToString()),bool.Parse(dr1["Amenazas"].ToString()),
                    bool.Parse(dr1["Lesiones"].ToString()),bool.Parse(dr1["DisposicionDinero"].ToString()),bool.Parse(dr1["ProblemasVecinales"].ToString()),bool.Parse(dr1["ProblemasFamiliares"].ToString()),
                    bool.Parse(dr1["ActitudNerviosa"].ToString()),bool.Parse(dr1["MovimientoCuentaBancaria"].ToString()),bool.Parse(dr1["ComunicacionDesaparecido"].ToString()),bool.Parse(dr1["ComunicacionCaptores"].ToString()),
                    bool.Parse(dr1["SolicitudParaDejarloLibre"].ToString()),bool.Parse(dr1["ComInternetParadero"].ToString()),bool.Parse(dr1["ComPersonasParadero"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarCausalesDesaparicion()
        {
            string causalesDesaparicion = "";
            string Sql = "SELECT "+
            "COUNT(*) as Total "+
            "FROM PNL_CAUSALES_DESAPARICION as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                causalesDesaparicion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT  "+
            "IdCarpetaNew,IdPersonaNew,PropiaVoluntad,SustraccionMenores,Salud,Adicciones,Migracion,ComisionDelito,Levanton,Detenido,VictimaDelito, "+
            "Accidentes,ProblemasFamiliares,RelacionesPersonales,MotivosLaborales,DesaparicionForzada,DesaparicionForzada,IdTipoSujeto,SeDesconoce " +
            "FROM PNL_CAUSALES_DESAPARICION as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {

                while (int.Parse(causalesDesaparicion) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaCausalesDesaparicionRemitir(0, int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    bool.Parse(dr1["PropiaVoluntad"].ToString()),bool.Parse(dr1["SustraccionMenores"].ToString()),bool.Parse(dr1["Salud"].ToString()),bool.Parse(dr1["Adicciones"].ToString()),
                    bool.Parse(dr1["Migracion"].ToString()),bool.Parse(dr1["ComisionDelito"].ToString()),bool.Parse(dr1["Levanton"].ToString()),bool.Parse(dr1["Detenido"].ToString()),
                    bool.Parse(dr1["VictimaDelito"].ToString()),bool.Parse(dr1["Accidentes"].ToString()),bool.Parse(dr1["ProblemasFamiliares"].ToString()),bool.Parse(dr1["RelacionesPersonales"].ToString()),
                    bool.Parse(dr1["MotivosLaborales"].ToString()), bool.Parse(dr1["DesaparicionForzada"].ToString()), int.Parse(dr1["IdTipoSujeto"].ToString()), bool.Parse(dr1["SeDesconoce"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarMediaFiliacion()
        {
            string mediaFiliacion = "";
            string Sql = "SELECT " +
            "COUNT(*) as Total " +
            "FROM  PNL_MEDIA_FILIACION as d " +
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  " +
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld " +
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                mediaFiliacion = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select IdCarpetaNew,IdPersonanew,IdCompexion,IdColorPiel,IdCara,IdCantidadCabello,IdColorCabello " +
            ",IdFormaCabello,IdCalvicieCabello,IdImplantacionCabello,IdAlturaFrente,IdIncilacionFrente,IdAnchoFrente,IdDireccionCeja " +
            ",IdImplantacionCeja,IdFormaCeja,IdTamañoCeja,IdColorOjos,IdFormaOjos,IdTamañoOjos,IdRaizNariz,IdDorsoNariz,IdAnchoNariz " +
            ",IdBaseNariz,IdAlturaNariz,IdTamañoBoca,IdComisurasBoca ,IdEspesorLabios,IdNasoLabial,IdProminenciaLabial ,IdTipoMenton " +
            ",IdFormaMenton,IdInclinacionMenton,IdFormaOreja,IdOriginalOreja,IdSuperiorHelix,IdPosteriorHelix,IdAdherenciaHelix,IdContornoLobulo " +
            ",IdAdherenciaLobulo,IdParticularidadLobulo,IdDimensionLobulo,IdTipoSangre,IdFactorRH,IdAnteojos,Estatura,Peso,Activo,IdBigote " +
            ",IdColorBigote,IdTipoBigote,IdBarba,IdColorBarba,IdTipoBarba,IdPomulos " +
            "FROM  PNL_MEDIA_FILIACION as d " +
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona " +
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld " +
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(mediaFiliacion) != contador)
                {
                    dr1.Read();

                    PGJ.agregarMediaFiliacionPNLRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["IdCompexion"].ToString()), short.Parse(dr1["IdColorPiel"].ToString()), short.Parse(dr1["IdCara"].ToString()), short.Parse(dr1["IdCantidadCabello"].ToString()),
                    short.Parse(dr1["IdColorCabello"].ToString()), short.Parse(dr1["IdFormaCabello"].ToString()), short.Parse(dr1["IdCalvicieCabello"].ToString()), short.Parse(dr1["IdImplantacionCabello"].ToString()),
                    short.Parse(dr1["IdAlturaFrente"].ToString()), short.Parse(dr1["IdIncilacionFrente"].ToString()), short.Parse(dr1["IdAnchoFrente"].ToString()), short.Parse(dr1["IdDireccionCeja"].ToString()),
                    short.Parse(dr1["IdImplantacionCeja"].ToString()), short.Parse(dr1["IdFormaCeja"].ToString()), short.Parse(dr1["IdTamañoCeja"].ToString()), short.Parse(dr1["IdColorOjos"].ToString()),
                    short.Parse(dr1["IdFormaOjos"].ToString()), short.Parse(dr1["IdTamañoOjos"].ToString()), short.Parse(dr1["IdRaizNariz"].ToString()), short.Parse(dr1["IdDorsoNariz"].ToString()),
                    short.Parse(dr1["IdAnchoNariz"].ToString()), short.Parse(dr1["IdBaseNariz"].ToString()), short.Parse(dr1["IdAlturaNariz"].ToString()), short.Parse(dr1["IdTamañoBoca"].ToString()),
                    short.Parse(dr1["IdComisurasBoca"].ToString()), short.Parse(dr1["IdEspesorLabios"].ToString()), short.Parse(dr1["IdNasoLabial"].ToString()), short.Parse(dr1["IdProminenciaLabial"].ToString()),
                    short.Parse(dr1["IdTipoMenton"].ToString()), short.Parse(dr1["IdFormaMenton"].ToString()), short.Parse(dr1["IdInclinacionMenton"].ToString()), short.Parse(dr1["IdFormaOreja"].ToString()),
                    short.Parse(dr1["IdOriginalOreja"].ToString()), short.Parse(dr1["IdSuperiorHelix"].ToString()), short.Parse(dr1["IdPosteriorHelix"].ToString()), short.Parse(dr1["IdAdherenciaHelix"].ToString()),
                    short.Parse(dr1["IdContornoLobulo"].ToString()), short.Parse(dr1["IdAdherenciaLobulo"].ToString()), short.Parse(dr1["IdParticularidadLobulo"].ToString()), short.Parse(dr1["IdDimensionLobulo"].ToString()),
                    short.Parse(dr1["IdTipoSangre"].ToString()), short.Parse(dr1["IdFactorRH"].ToString()), short.Parse(dr1["IdAnteojos"].ToString()), dr1["Estatura"].ToString(),
                    dr1["Peso"].ToString(), int.Parse(dr1["IdBigote"].ToString()), int.Parse(dr1["IdColorBigote"].ToString()), int.Parse(dr1["IdTipoBigote"].ToString()),
                    int.Parse(dr1["IdBarba"].ToString()), int.Parse(dr1["IdColorBarba"].ToString()), int.Parse(dr1["IdTipoBarba"].ToString()), int.Parse(dr1["IdPomulos"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarSenasParticulares()
        {
            string senasParticulares = "";
            string Sql = "SELECT "+
            "COUNT(*) as Total "+
            "FROM  PNL_SENAS_PARTICULARES as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                senasParticulares = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select IdCarpetaNew,IdPersonanew,IdTipoSena,IdDescripcionSena,IdVista,IdLado,IdRegion,IdCantidadRegion,Descripcion,Activo "+
            "FROM  PNL_SENAS_PARTICULARES as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(senasParticulares) != contador)
                {
                    dr1.Read();

                    PGJ.agregarSeñasPNLRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["IdTipoSena"].ToString()), short.Parse(dr1["IdDescripcionSena"].ToString()), short.Parse(dr1["IdVista"].ToString()),
                    short.Parse(dr1["IdLado"].ToString()), short.Parse(dr1["IdRegion"].ToString()), short.Parse(dr1["IdCantidadRegion"].ToString()), dr1["Descripcion"].ToString());

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }


        private void InsertarVestimenta()
        {
            string vestimenta = "";
            string Sql = "SELECT "+ 
            "COUNT(*) as Total "+ 
            "FROM  PNL_VESTIMENTA as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                vestimenta = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select "+
            "IdCarpetaNew,IdPersonaNew,IdVestimenta,DescripcionVestimenta "+
            "FROM  PNL_VESTIMENTA as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(vestimenta) != contador)
                {
                    dr1.Read();

                    PGJ.PNL_InsertaVestimentaRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    int.Parse(dr1["IdVestimenta"].ToString()), dr1["DescripcionVestimenta"].ToString());

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarColectorMuestra()
        {
            string colectorMuestra = "";
            string Sql = "SELECT "+ 
            "COUNT(*) as Total "+ 
            "FROM  PNL_COLECTOR_MUESTRA as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                colectorMuestra = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select "+  
            "IdCarpetaNew,IdPersonaNew,Nombre,Paterno,Materno,NumeroEmpleado,Institucion,d.IdMunicipio,Puesto,IdDonante,DptoPericial "+ 
            "FROM  PNL_COLECTOR_MUESTRA as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(colectorMuestra) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaColectorMuestraRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    dr1["Nombre"].ToString(),dr1["Paterno"].ToString(),dr1["Materno"].ToString(),dr1["NumeroEmpleado"].ToString(),dr1["Institucion"].ToString(),int.Parse(dr1["IdMunicipio"].ToString()),
                    dr1["Puesto"].ToString(),int.Parse(dr1["IdDonante"].ToString()),  dr1["DptoPericial"].ToString());

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarDonantes()
        {
            string donante = "";
            string Sql = "SELECT "+
            "COUNT(*) as Total "+
            "FROM  PNL_DONANTES as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                donante = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select  "+
            "IdCarpetaNew,IdPersonaNew,Nombre,Paterno,Materno,IdSexo,IdIdentificacion,FolioIdentificacion,IdParentesco,IdPais,IdEntidad,d.IdMunicipio,Localidad, "+
            "Colonia,Calle,EntreCalle1,EntreCalle2,NumeroExterior,NumeroInterior,CP,Telefono,TipoMuestra,FechaMuestra,case when MenorEdad='True' then 1  when MenorEdad='False' then 0 end as MenorEdad, "+
            "NombreTutor,PaternoTutor, " +
            "MaternoTutor,IdParentescoTutor,IdIdentificacionTutor,FolioIdentificacionTutor,case when Trasfusion='True' then 1  when Trasfusion='False' then 0 end as Trasfusion, "+
            "case when Trasplante='True' then 1  when Trasplante='False' then 0 end as Trasplante,case when EnfermedadInfecciosa='True' then 1  when EnfermedadInfecciosa='False' then 0 end as EnfermedadInfecciosa,CantidadDeMuestra, " +
            "AutoridadQueSolicitaTomaMuestra,LugarRecoleccionIndicios,HoraRecoleccionMuestra "+
            "FROM  PNL_DONANTES as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(donante) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaDonantesRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    dr1["Nombre"].ToString(),dr1["Paterno"].ToString(),dr1["Materno"].ToString(),short.Parse(dr1["IdSexo"].ToString()),short.Parse(dr1["IdIdentificacion"].ToString()),
                    dr1["FolioIdentificacion"].ToString(),short.Parse(dr1["IdParentesco"].ToString()),short.Parse(dr1["IdPais"].ToString()),short.Parse(dr1["IdEntidad"].ToString()),
                    short.Parse(dr1["IdMunicipio"].ToString()),short.Parse(dr1["Localidad"].ToString()),short.Parse(dr1["Colonia"].ToString()),int.Parse(dr1["Calle"].ToString()),
                    int.Parse(dr1["EntreCalle1"].ToString()),int.Parse(dr1["EntreCalle2"].ToString()),dr1["NumeroExterior"].ToString(),dr1["NumeroInterior"].ToString(),dr1["CP"].ToString(),
                    dr1["Telefono"].ToString(),dr1["TipoMuestra"].ToString(),DateTime.Parse(dr1["FechaMuestra"].ToString()),short.Parse(dr1["MenorEdad"].ToString()),dr1["NombreTutor"].ToString(),
                    dr1["PaternoTutor"].ToString(),dr1["MaternoTutor"].ToString(),short.Parse(dr1["IdParentescoTutor"].ToString()),short.Parse(dr1["IdIdentificacionTutor"].ToString()),
                    dr1["FolioIdentificacionTutor"].ToString(),short.Parse(dr1["Trasfusion"].ToString()),short.Parse(dr1["Trasplante"].ToString()),short.Parse(dr1["EnfermedadInfecciosa"].ToString()),
                    dr1["CantidadDeMuestra"].ToString(), dr1["AutoridadQueSolicitaTomaMuestra"].ToString(), dr1["LugarRecoleccionIndicios"].ToString(), dr1["HoraRecoleccionMuestra"].ToString());

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarDatosLocalizacion()
        {
            string localizado = "";
            string Sql = "SELECT "+
            "COUNT(*) as Total "+
            "FROM  PNL_DATOS_LOCALIZACION as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                localizado = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select "+ 
            "IdCarpetaNew,IdPersonaNew,case when EstatusPersona='True' then 1 when EstatusPersona='False' then 0 end as EstatusPersona, "+ 
            "FechaLocalizacion,HoraLocalizacion,PosibleCausaDesaparicion,IdCondicionLocalizacion,IdLugarHallazgo,IdPais, "+ 
            "IdEntidad,d.IdMunicipio,Localidad,Colonia,Calle,EntreCalle1,EntreCalle2,NumeroExterior,NumeroInterior,CP,FechaIngreso,HoraIngreso,IdCausasFallecimiento, "+ 
            "IdentificacionCadaver,FechaEntregaCuerpo,FechaProbableFallecimiento,EnteLocaliza,NombreEnte,PaternoEnte,MaternoEnte,Institucion,Autoridad,NombreAutoridad, "+ 
            "PaternoAutoridad,MaternoAutoridad,NombreReclama,PaternoReclama,MaternoReclama,IdParentescoReclama "+ 
            "FROM  PNL_DATOS_LOCALIZACION as d "+ 
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(localizado) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaDatosLocalizacionRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["EstatusPersona"].ToString()),DateTime.Parse(dr1["FechaLocalizacion"].ToString()),dr1["HoraLocalizacion"].ToString(),dr1["PosibleCausaDesaparicion"].ToString(),
                    short.Parse(dr1["IdCondicionLocalizacion"].ToString()),short.Parse(dr1["IdLugarHallazgo"].ToString()),short.Parse(dr1["IdPais"].ToString()),short.Parse(dr1["IdEntidad"].ToString()),
                    short.Parse(dr1["IdMunicipio"].ToString()),short.Parse(dr1["Localidad"].ToString()),short.Parse(dr1["Colonia"].ToString()),int.Parse(dr1["Calle"].ToString()),int.Parse(dr1["EntreCalle1"].ToString()),
                    int.Parse(dr1["EntreCalle2"].ToString()),dr1["NumeroExterior"].ToString(),dr1["NumeroInterior"].ToString(),dr1["CP"].ToString(),dr1["FechaIngreso"].ToString(),dr1["HoraIngreso"].ToString(),
                    short.Parse(dr1["IdCausasFallecimiento"].ToString()),dr1["IdentificacionCadaver"].ToString(),dr1["FechaEntregaCuerpo"].ToString(),dr1["FechaProbableFallecimiento"].ToString(),
                    short.Parse(dr1["EnteLocaliza"].ToString()), dr1["NombreEnte"].ToString(), dr1["PaternoEnte"].ToString(), dr1["MaternoEnte"].ToString(), dr1["Institucion"].ToString(), dr1["Autoridad"].ToString(),
                    dr1["NombreAutoridad"].ToString(),dr1["PaternoAutoridad"].ToString(),dr1["MaternoAutoridad"].ToString(),dr1["NombreReclama"].ToString(),dr1["PaternoReclama"].ToString(),dr1["MaternoReclama"].ToString(),
                    short.Parse(dr1["IdParentescoReclama"].ToString()));   

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarFotografia()
        {
            string foto = "";
            string Sql = "SELECT "+
            "COUNT(*) as Total "+
            "FROM  PNL_FOTOGRAFIA_PNL as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona  "+
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                foto = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "select "+ 
            "IdCarpetaNew,IdPersonaNew,Fotografia,Descripcion "+
            "FROM  PNL_FOTOGRAFIA_PNL as d "+
            "JOIN REMITIDAS_RELACION_ID ON (REMITIDAS_RELACION_ID.IdCarpetaOld=d.IdCarpeta AND REMITIDAS_RELACION_ID.IdPersonaOld=d.IdPersona "+ 
            "AND IdConsecutivoDelitoNew IS NULL AND IdConsecutivoDelitoOld IS NULL AND IdLugarHechosNew IS NULL AND IdLugarHechosOld "+
            "IS NULL AND IdVehiculoNew IS NULL AND IdVehiculoOld IS NULL and REMITIDAS_RELACION_ID.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where IdCarpeta=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(foto) != contador)
                {
                    dr1.Read();

                     byte[] bits = ((byte[])(dr1["Fotografia"]));

                    PGJ.PNLInsertaFotografiaRemitir(int.Parse(dr1["IdCarpetaNew"].ToString()), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    bits, dr1["Descripcion"].ToString());

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        //HOMICIDIOS
        private void InsertarHomicidio()
        {
            string homicidio = "";
            string Sql = "SELECT COUNT(*) as Total "+
            "FROM PGJ_HOMICIDIO "+
            "left outer JOIN REMITIDAS_RELACION_ID as Ofendido on (Ofendido.IdPersonaOld=ID_PERSONA_OFENDIDO and Ofendido.IdCarpetaOld=ID_CARPETA and Ofendido.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "left outer JOIN REMITIDAS_RELACION_ID as Imputado on (Imputado.IdPersonaOld=ID_PERSONA_IMPUTADO and Imputado.IdCarpetaOld=ID_CARPETA and Imputado.IdMunicipio="+ int.Parse(Session["IdMunicipio"].ToString()) +") "+
            "left outer JOIN REMITIDAS_RELACION_ID as Hecho on (Hecho.IdLugarHechosOld=ID_LUGAR_HECHOS and Hecho.IdCarpetaOld=ID_CARPETA and Hecho.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                homicidio = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT id_homicidio,"+
            "Ofendido.IdPersonaNew as IdOfendido,Imputado.IdPersonaNew as IdImputado,Hecho.IdLugarHechosNew,ID_TIPO_PERSONA_OFENDIDO, "+
            "ID_TIPO_PERSONA_IMPUTADO,ID_ORGANIZACION_IMPUTADO,ID_MOVIL,ID_SUB_DELITO,ID_SITUACION,ID_SUB_MODALIDAD,FECHA_REGISTRO "+
            "FROM PGJ_HOMICIDIO "+
            "left outer JOIN REMITIDAS_RELACION_ID as Ofendido on (Ofendido.IdPersonaOld=ID_PERSONA_OFENDIDO and Ofendido.IdCarpetaOld=ID_CARPETA and Ofendido.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "left outer JOIN REMITIDAS_RELACION_ID as Imputado on (Imputado.IdPersonaOld=ID_PERSONA_IMPUTADO and Imputado.IdCarpetaOld=ID_CARPETA and Imputado.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "left outer JOIN REMITIDAS_RELACION_ID as Hecho on (Hecho.IdLugarHechosOld=ID_LUGAR_HECHOS and Hecho.IdCarpetaOld=ID_CARPETA and Hecho.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(homicidio) != contador)
                {
                    dr1.Read();

                    PGJ.InsertarHomicidioRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdOfendido"].ToString()), 
                    int.Parse(dr1["IdImputado"].ToString()),int.Parse(dr1["IdLugarHechosNew"].ToString()),short.Parse(dr1["ID_TIPO_PERSONA_OFENDIDO"].ToString()),
                    short.Parse(dr1["ID_TIPO_PERSONA_IMPUTADO"].ToString()),short.Parse(dr1["ID_ORGANIZACION_IMPUTADO"].ToString()),short.Parse(dr1["ID_MOVIL"].ToString()),
                    short.Parse(dr1["ID_SUB_DELITO"].ToString()),short.Parse(dr1["ID_SITUACION"].ToString()),short.Parse(dr1["ID_SUB_MODALIDAD"].ToString()),
                    DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()) );

      
        consultarIdHomicidio();
        PGJ.insertaRemitidasHomicidio(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_HOMICIDIO.Text), int.Parse(dr1["id_homicidio"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        void consultarIdHomicidio()
        {
            SqlCommand sql = new SqlCommand("Select  ISNULL(MAX(ID_HOMICIDIO),1) as ID_HOMICIDIO  From PGJ_HOMICIDIO WHERE ID_CARPETA= " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = sql.ExecuteReader();
            //if (dr.HasRows)
            //{
            dr.Read();
            ID_HOMICIDIO.Text = dr["ID_HOMICIDIO"].ToString();

            //}
            dr.Close();
        }

        private void InsertarCadaverHomicidio()
        {
            string homicidio = "";
            string Sql = "SELECT COUNT(*) as Total FROM PGJ_CADAVER_HOMICIDIO "+
            "left outer JOIN REMITIDAS_RELACION_ID as Ofendido on (Ofendido.IdPersonaOld=ID_PERSONA and Ofendido.IdCarpetaOld=ID_CARPETA and Ofendido.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                homicidio = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT "+
            "IdPersonaNew,ID_VIOLENCIA,ID_CDVR_CAUSA,ID_CDVR_CNSRVCION,ID_CDVR_ORIENTACION,ID_CDVR_PSCION, "+
            "FECHA_MUERTE,HORA_MUERTE,FECHA_IDENTIFICACION,HORA_IDENTIFIACION,CUERPO_ENTREGADO,NOMBRE_ENTREGA_CUERPO,PARENTESCO, "+
            "CASE WHEN FOSA_COMUN='True' then 1 WHEN FOSA_COMUN='False' then 0 end as FOSA_COMUN,DESCRIPCION_CADAVER,FECHA_ENTREGA,DATOS_FOSA,PARTES_CUERPO,IDENTIFICACION,RESGUARDO_CADAVER,FECHA_REGISTRO AS FR " +
            "FROM PGJ_CADAVER_HOMICIDIO "+
            "left outer JOIN REMITIDAS_RELACION_ID as Ofendido on (Ofendido.IdPersonaOld=ID_PERSONA and Ofendido.IdCarpetaOld=ID_CARPETA and Ofendido.IdMunicipio="+ int.Parse(Session["IdMunicipio"].ToString()) +") "+
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(homicidio) != contador)
                {
                    dr1.Read();

                    byte[] bits = ((byte[])(dr1["IDENTIFICACION"]));

                    PGJ.InsertarCadaverHomicidioRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdPersonaNew"].ToString()),
                    short.Parse(dr1["ID_VIOLENCIA"].ToString()), short.Parse(dr1["ID_CDVR_CAUSA"].ToString()), short.Parse(dr1["ID_CDVR_CNSRVCION"].ToString()), short.Parse(dr1["ID_CDVR_ORIENTACION"].ToString()),
                    short.Parse(dr1["ID_CDVR_PSCION"].ToString()), DateTime.Parse(dr1["FECHA_MUERTE"].ToString()), dr1["HORA_MUERTE"].ToString(), DateTime.Parse(dr1["FECHA_IDENTIFICACION"].ToString()),
                    dr1["HORA_IDENTIFIACION"].ToString(), short.Parse(dr1["CUERPO_ENTREGADO"].ToString()), dr1["NOMBRE_ENTREGA_CUERPO"].ToString(), short.Parse(dr1["PARENTESCO"].ToString()),
                    short.Parse(dr1["FOSA_COMUN"].ToString()), dr1["DESCRIPCION_CADAVER"].ToString(), DateTime.Parse(dr1["FECHA_ENTREGA"].ToString()), dr1["DATOS_FOSA"].ToString(),
                    dr1["PARTES_CUERPO"].ToString(), bits, dr1["RESGUARDO_CADAVER"].ToString(), DateTime.Parse(dr1["FR"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarHomicidioMensaje()
        {
            string homicidio = "";
            string Sql = "SELECT COUNT(*) as Total FROM PGJ_MENSAJE_HOMICIDIO "+
            "left outer JOIN REMITIDAS_RELACION_HOMICIDIO as Homicidio on (Homicidio.IdCarpetaOld=ID_CARPETA AND Homicidio.IdHomicidioOld=ID_HOMICIDIO and Homicidio.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                homicidio = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT "+ 
            "IdCarpetaNew,IdHomicidioNew,MENSAJE,FOTO1,FOTO2,FOTO3,FOTO4,FECHA_REGISTRO "+ 
            "FROM PGJ_MENSAJE_HOMICIDIO "+
            "left outer JOIN REMITIDAS_RELACION_HOMICIDIO as Homicidio on (Homicidio.IdCarpetaOld=ID_CARPETA AND Homicidio.IdHomicidioOld=ID_HOMICIDIO and Homicidio.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " + 
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(homicidio) != contador)
                {
                    dr1.Read();

                    byte[] foto1 = ((byte[])(dr1["FOTO1"]));
                    byte[] foto2 = ((byte[])(dr1["FOTO2"]));
                    byte[] foto3 = ((byte[])(dr1["FOTO3"]));
                    byte[] foto4 = ((byte[])(dr1["FOTO4"]));

                    PGJ.InsertarMensajeHomicidioRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdHomicidioNew"].ToString()),
                    dr1["MENSAJE"].ToString(),foto1,foto2,foto3,foto4,DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarHomicidioArma()
        {
            string homicidio = "";
            string Sql = "SELECT COUNT(*) as Total FROM PGJ_ARMA where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                homicidio = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT ID_ARMA,ID_ARMA_TPO,ID_ARMA_CAT,ID_ARMAS_AA,ID_MARCA,ID_CALIBRE,ID_ESTADO_ARMA,DESCRIPCION,MATRICULA,SERIE,FECHA_REGISTRO FROM PGJ_ARMA where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(homicidio) != contador)
                {
                    dr1.Read();

                    PGJ.InsertarArmaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), short.Parse(dr1["ID_ARMA_TPO"].ToString()),
                    short.Parse(dr1["ID_ARMA_CAT"].ToString()),short.Parse(dr1["ID_ARMAS_AA"].ToString()),short.Parse(dr1["ID_MARCA"].ToString()),
                    short.Parse(dr1["ID_CALIBRE"].ToString()),short.Parse(dr1["ID_ESTADO_ARMA"].ToString()), dr1["DESCRIPCION"].ToString(), dr1["MATRICULA"].ToString(),
                    dr1["SERIE"].ToString(), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                       
                    ConsultarIDArma();
                    PGJ.insertaRemitidasArma(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_ARMA.Text), int.Parse(dr1["ID_ARMA"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        public void ConsultarIDArma()
        {
            SqlCommand comm = new SqlCommand("SELECT MAX(ID_ARMA) as ID_ARMA  FROM PGJ_ARMA WHERE ID_CARPETA = " + lblIdCN.Text, NUC_PNL.CnnPNL);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ID_ARMA.Text = dr["ID_ARMA"].ToString();
                }
                dr.Close();
            }

        }

        private void InsertarArmaHomicidio()
        {
            string homicidio = "";
            string Sql = "SELECT COUNT(*) as Total FROM PGJ_ARMA_HOMICIDIO "+
            "LEFT OUTER JOIN REMITIDAS_RELACION_HOMICIDIO as Homicidio on (Homicidio.idHomicidioOld=ID_HOMICIDIO and Homicidio.IdCarpetaold=ID_CARPETA and Homicidio.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "LEFT OUTER JOIN REMITIDAS_RELACION_HOMICIDIO as Arma on (Arma.idarmaOld=ID_ARMA and Arma.IdCarpetaold=ID_CARPETA and Arma.IdMunicipio="+ int.Parse(Session["IdMunicipio"].ToString()) +") " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                homicidio = dr["Total"].ToString();
            }
            dr.Close();

            int contador = 0;
            string Sql1 = "SELECT Arma.idarmanew as IdArma,Homicidio.idhomicidionew as IdHomicidio,FECHA_REGISTRO "+
            "FROM PGJ_ARMA_HOMICIDIO "+
            "LEFT OUTER JOIN REMITIDAS_RELACION_HOMICIDIO as Homicidio on (Homicidio.idHomicidioOld=ID_HOMICIDIO and Homicidio.IdCarpetaold=ID_CARPETA and Homicidio.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "LEFT OUTER JOIN REMITIDAS_RELACION_HOMICIDIO as Arma on (Arma.idarmaOld=ID_ARMA and Arma.IdCarpetaold=ID_CARPETA and Arma.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(homicidio) != contador)
                {
                    dr1.Read();

                    PGJ.InsertarArmaHomicidioRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    int.Parse(dr1["IdArma"].ToString()),int.Parse(dr1["IdHomicidio"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));
                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        //JUDUCIALIZAR ordenes
        private void InsertarOrdenOficio()
        {
            string oficio = "";
            string IdOficioR = "";
            string Sql = "SELECT COUNT(*) as Total FROM PGJ_NUC_JUD_ORDEN_OFICIO " +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                oficio = dr["Total"].ToString();
            }
            dr.Close();


            int contador = 0;
            string Sql1 = "SELECT ID_OFICIO,ID_CARPETA,ID_MUNICIPIO_CARPETA,ID_TIPO_ORDEN,ID_JUZGADO,NUM_OFICIO,FECHA,NUM_CARPETA_ADMINISTRATIVA,JUEZNOMBRE,JUEZPATERNO,JUEZMATERNO,PDF, "+
             "ID_USUARIO,FECHA_REGISTRO FROM PGJ_NUC_JUD_ORDEN_OFICIO where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(oficio) != contador)
                {
                    dr1.Read();

                    byte[] oficioPdf = ((byte[])(dr1["PDF"]));

                    IdOficioR = Convert.ToString(
                    PGJ.InsertarOrdenOficioRemitir(int.Parse(lblIdCN.Text), int.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()),
                    short.Parse(dr1["ID_TIPO_ORDEN"].ToString()), short.Parse(dr1["ID_JUZGADO"].ToString()), dr1["NUM_OFICIO"].ToString(), DateTime.Parse(dr1["FECHA"].ToString()),
                    dr1["NUM_CARPETA_ADMINISTRATIVA"].ToString(), dr1["JUEZNOMBRE"].ToString(), dr1["JUEZPATERNO"].ToString(), dr1["JUEZMATERNO"].ToString(), oficioPdf,
                    short.Parse(Session["IdUsuarioRemitir"].ToString()), DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()))
                    );

                    PGJ.insertaRemitidasOrdenOficio(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(IdOficioR), int.Parse(dr1["ID_OFICIO"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarOrdenPersona()
        {
            string persona = "";
            string IdOrdenR = "";

            string Sql = "SELECT COUNT(*) as Total FROM PGJ_NUC_JUD_ORDEN_PERSONA " +
            "join REMITIDAS_RELACION_ORDENES on (REMITIDAS_RELACION_ORDENES.IdCarpetaOld=ID_CARPETA AND REMITIDAS_RELACION_ORDENES.IdOficioOld=ID_OFICIO AND REMITIDAS_RELACION_ORDENES.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString())+ ")" +
            "join REMITIDAS_RELACION_ID as Persona on (Persona.IdPersonaOld=ID_PERSONA and Persona.IdCarpetaOld=ID_CARPETA and Persona.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ")" +
            "where ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                persona = dr["Total"].ToString();
            }
            dr.Close();


            int contador = 0;
            string Sql1 = "SELECT ID_ORDEN,ID_CARPETA,ID_PERSONA,ID_OFICIO,ID_ESTADO_ORDEN,isnull(cast(ID_MOTIVO_CANCELACION as varchar),'') as ID_MOTIVO_CANCELACION,isnull(cast(FECHA_EJECUCION as varchar),'01/01/1900') as FECHA_EJECUCION,isnull(cast(FECHA_CANCELACION as varchar),'01/01/1900') as FECHA_CANCELACION,isnull(cast(FECHA_DISPOSICION as varchar),'01/01/1900') as FECHA_DISPOSICION,ID_AUTORIDAD_ORDEN, " +
            "OTRA_AUTORIDAD,isnull(cast(FECHA_AMPARO as varchar),'01/01/1900') as FECHA_AMPARO,OBSERVACIONES,ID_USUARIO,FECHA_REGISTRO,NUMERO_AMPARO,ID_JUZGADO_AMPARO,JUEZNOMBRE_AMPARO,JUEZPATERNO_AMPARO," +
            "JUEZMATERNO_AMPARO,isnull(cast(SUSPENSION_PROVISIONAL as varchar),'') as SUSPENSION_PROVISIONAL,isnull(cast(FECHA_AUTO_SUSPENSION as varchar),'01/01/1900') as FECHA_AUTO_SUSPENSION,isnull(cast(SUSPENSION_DEFINITIVA as varchar),'') as SUSPENSION_DEFINITIVA,isnull(cast(FECHA_RESOLUCION_INCIDENTE as varchar),'01/01/1900') as FECHA_RESOLUCION_INCIDENTE,isnull(cast(AMPARO_CONCEDIDO as varchar),'') as AMPARO_CONCEDIDO, " +
            "isnull(cast(FECHA_RESOLUCION_AMPARO as varchar),'01/01/1900') as FECHA_RESOLUCION_AMPARO,EFECTOS_AMPARO,REMITIDAS_RELACION_ORDENES.IdOficioNew,Persona.idPersonaNew " +
            "FROM PGJ_NUC_JUD_ORDEN_PERSONA "+
            "join REMITIDAS_RELACION_ORDENES on (REMITIDAS_RELACION_ORDENES.IdCarpetaOld=ID_CARPETA AND REMITIDAS_RELACION_ORDENES.IdOficioOld=ID_OFICIO AND REMITIDAS_RELACION_ORDENES.IdMunicipio="+int.Parse(Session["IdMunicipio"].ToString())+") "+
            "join REMITIDAS_RELACION_ID as Persona on (Persona.IdPersonaOld=ID_PERSONA and Persona.IdCarpetaOld=ID_CARPETA and Persona.IdMunicipio="+int.Parse(Session["IdMunicipio"].ToString())+") "+
            "WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(persona) != contador)
                {
                    dr1.Read();
                  
                    IdOrdenR = Convert.ToString(PGJ.InsertaPGJNucJudOrdenPersonaRemitir(int.Parse(lblIdCN.Text), short.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["idPersonaNew"].ToString()),
                        int.Parse(dr1["IdOficioNew"].ToString()), int.Parse(dr1["ID_ESTADO_ORDEN"].ToString()), dr1["ID_MOTIVO_CANCELACION"].ToString() == "" ? -1 : int.Parse(dr1["ID_MOTIVO_CANCELACION"].ToString()),
                        DateTime.Parse(dr1["FECHA_EJECUCION"].ToString()), DateTime.Parse(dr1["FECHA_CANCELACION"].ToString()), DateTime.Parse(dr1["FECHA_DISPOSICION"].ToString()),
                        int.Parse(dr1["ID_AUTORIDAD_ORDEN"].ToString()), dr1["OTRA_AUTORIDAD"].ToString(), DateTime.Parse(dr1["FECHA_AMPARO"].ToString()),
                        dr1["NUMERO_AMPARO"].ToString(), short.Parse(dr1["ID_JUZGADO_AMPARO"].ToString()), dr1["JUEZNOMBRE_AMPARO"].ToString(), dr1["JUEZPATERNO_AMPARO"].ToString(),
                        dr1["JUEZMATERNO_AMPARO"].ToString(),
                        dr1["SUSPENSION_PROVISIONAL"].ToString() == "" ? -1 : int.Parse(dr1["SUSPENSION_PROVISIONAL"].ToString()), DateTime.Parse(dr1["FECHA_AUTO_SUSPENSION"].ToString()),
                        dr1["SUSPENSION_DEFINITIVA"].ToString() == "" ? -1 : int.Parse(dr1["SUSPENSION_DEFINITIVA"].ToString()), DateTime.Parse(dr1["FECHA_RESOLUCION_INCIDENTE"].ToString()),
                        dr1["AMPARO_CONCEDIDO"].ToString() == "" ? -1 : int.Parse(dr1["AMPARO_CONCEDIDO"].ToString()), DateTime.Parse(dr1["FECHA_RESOLUCION_AMPARO"].ToString()),
                        dr1["EFECTOS_AMPARO"].ToString(), dr1["OBSERVACIONES"].ToString(), int.Parse(Session["IdUsuarioRemitir"].ToString()),
                        DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()))
                        );



                    PGJ.insertaRemitidasOrdenOrden(int.Parse(lblIdCN.Text), int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(IdOrdenR), int.Parse(dr1["ID_ORDEN"].ToString()), int.Parse(Session["IdMunicipio"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }

        private void InsertarOrdenDelito()
        {
            string delito = "";

            string Sql = "SELECT COUNT(*) as Total FROM PGJ_NUC_JUD_ORDEN_DELITO " +
            "join REMITIDAS_RELACION_ORDENES on (REMITIDAS_RELACION_ORDENES.IdOrdenOld=ID_ORDEN AND REMITIDAS_RELACION_ORDENES.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ")" +
            "where IdCarpetaOld=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader dr = SqlComando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                delito = dr["Total"].ToString();
            }
            dr.Close();


            int contador = 0;
            string Sql1 = "SELECT ID_ORDEN_DELITO,ID_ORDEN,IdOrdenNew,ID_DELITO,ID_MODALIDAD,ID_USUARIO,FECHA_REGISTRO " +
            "FROM PGJ_NUC_JUD_ORDEN_DELITO " +
            "join REMITIDAS_RELACION_ORDENES on (REMITIDAS_RELACION_ORDENES.IdOrdenOld=ID_ORDEN AND REMITIDAS_RELACION_ORDENES.IdMunicipio=" + int.Parse(Session["IdMunicipio"].ToString()) + ") " +
            "WHERE IdCarpetaOld=" + Session["ID_CARPETA"].ToString();
            SqlCommand SqlComando1 = new SqlCommand(Sql1, Data.CnnCentral);
            SqlDataReader dr1 = SqlComando1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (int.Parse(delito) != contador)
                {
                    dr1.Read();

                    PGJ.InsertaPGJNucJudOrdenDelitoRemitir(int.Parse(Session["ID_MUNICIPIO_REMITIR"].ToString()), int.Parse(dr1["IdOrdenNew"].ToString()),
                        int.Parse(dr1["ID_DELITO"].ToString()),int.Parse(dr1["ID_MODALIDAD"].ToString()), int.Parse(Session["IdUsuarioRemitir"].ToString()),
                        DateTime.Parse(dr1["FECHA_REGISTRO"].ToString()));

                    contador = contador + 1;
                }
            }
            dr1.Close();
        }


        //HISTORIAL, ELIMINAR LOGICAMENTE
        private void InsertaCarpetaRemitidas()
        {
            string rac2 = "";
            if (ContieneRac == "1")
            {
                rac2 = racnew;
            }
            if (ContieneRac == "0")
            {
                rac2 = "NULL";
            }

            PGJ.insertaCarpetaRemitidas(int.Parse(Session["ID_CARPETA"].ToString()), short.Parse(Session["IdMunicipio"].ToString()),
                int.Parse(Session["IdUnidad"].ToString()),int.Parse(Session["ID_UNIDAD_REMITIR"].ToString()),nucnew,
                int.Parse(Session["IdUsuarioRemitir"].ToString()), rac2);
        }


        private void Mostrar()
        {
            GridResultado.Visible = true;
            GridResultado.DataSourceID = "SqlDataRemitidasExi";
            GridResultado.DataBind();

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 12, "Remision de Expediente, IdCarpetaOrigen: " + Session["ID_CARPETA"].ToString() + " NUC nuevo: " + nucnew, int.Parse(Session["IdModuloBitacora"].ToString()));
        }
        protected void Remitir_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = true;
            PanelAcumular.Visible = false;
        }

        protected void ImgSi8_Click(object sender, EventArgs e)
        {
            lblConfirmacion.Text = "";

            ImgSi8.Visible = false;
            ImgNo8.Visible = false;
            ConectarPNL();
            if (CnnPNL.State == 0)
            {
                LblMensajeRemitir.Text = "No hay Conexión con la Unidad Seleccionada. Intente más tarde";
                ImgSi8.Visible = true;
                ImgNo8.Visible = true;
            }
            else
            {
                ImgSi8.Visible = false;
                ImgNo8.Visible = false;
                LblMensajeRemitir.Text = "Remisión Exitosa";
                //INSERTAR CARPETA
                InsertarCarpeta();
                TraerIdCarpeta();
                InsertarLugarHechos();
                InsertarDelitos();
                InsertarPersona();
                InsertarCarpetaPersona();
                InsertarPersonaDomicilio();
                InsertarAlias();
                InsertarMedioContacto();
                InsertarArchivoTemporal();
                InsertaacuerdoAbsInv();
                InsertaCriterioOportunidad();
                InsertaIncompetencia();
                InsertaMediosAlternativos();
                InsertaNoEjercicio();
                InsertaJudAcuerdosReparatorios();
                InsertaJudDetencion();
                InsertaJudMedidaCautelar();
                InsertaJudMedidaProteccion();
                InsertaJudOrdenes();
                InsertaJudPlazoInvestigacion();
                InsertaJudProcedimientoAbreviado();
                InsertaJudSentencia();
                InsertaJudSobreseimiento();
                InsertaJudSuspencion();
                InsertarDefensor();
                InsertarAutoridad();
                InsertarDescripcionHechos();
                InsertarLugarDetencion();
                InsertarDetencion();
                InsertaJudImputacion();
                InsertaJudVinculacionDelito();
                InsertarSujetoInterviene();
                InsertarBoletin();
                InsertarDatosGenerales();
                InsertarPertenenciaSocial();
                InsertarDiscapacidades();
                InsertarInformacionFinanciera();
                InsertarInformacionOdontologica();
                InsertarOtraInformacion();
                InsertarCausalesDesaparicion();
                InsertarMediaFiliacion();
                InsertarSenasParticulares();
                InsertarVestimenta();
                InsertarColectorMuestra();
                InsertarDonantes();
                InsertarDatosLocalizacion();
                InsertarPersonaQuien();
                InsertarCarpetaPersonaQuien();
                InsertarPersonaDomicilioQuien();
                InsertarFotografia();
                InsertaRACIniciada();
                InsertaRACRemitida();
                InsertaRACCanalizada();
                InsertaRACConvenio();
                InsertaRACConvenioIncumplido();
                InsertaRACIncompetencia();
                InsertaRACNoConvenio();
                InsertaRACResuelta();
                InsertaRACSuspendida();
                InsertaRACAcuerdoAbsInv();
                InsertarVehiculo();
                InsertarVehiculoRobado();
                InsertarVehiculoRecuperado();
                InsertarAutorizacion();
                InsertaCarpetaPDF();
                InsertarVehiculoPDF();
                InsertarHomicidio();
                InsertarCadaverHomicidio();
                InsertarHomicidioMensaje();
                InsertarHomicidioArma();
                InsertarArmaHomicidio();
                InsertarOrdenOficio();
                InsertarOrdenPersona();
                InsertarOrdenDelito();

                InsertaCarpetaRemitidas();
                //*** INSERTAR UN HISTORIAL
                Mostrar();

            }
        }

        protected void ImgNo8_Click(object sender, EventArgs e)
        {
            Panel10.Visible = false;
        }

        protected void btnRemitir_Click(object sender, EventArgs e)
        {
            lblConfirmacion.Text = "FAVOR DE CONFIRMAR LA REMISION DEL NUC: " + " DE LA : " + UNDD.Text + " A LA : " + DDUnidades.SelectedItem;
            ImgSi8.Visible = true;
            ImgNo8.Visible = true;
            btnRemitir.Visible = false;
        }

        protected void SiAcumular_Click(object sender, ImageClickEventArgs e)
        {
            Label91.Text = "";
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
                SqlCommand sqlAcumular = new SqlCommand("COMBO_NUC_PARA_ACUMULAR_POR_FECHA_NUC1 " + int.Parse(Session["ID_CARPETA"].ToString()) + "," + int.Parse(Session["IdUnidad"].ToString())
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
                    Label9.Visible = true;
                    Label9.Text = "NO SE PUEDE ACUMULAR AL EXPEDIENTE: " + txtNumeroAcumular.Text + "/" + txtAnioAcumular.Text;
                }
                else
                {
                    PGJ.InsertaNucAcumulada(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(lblIdCarpetaAcumular.Text), int.Parse(Session["IdUsuario"].ToString()));
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton ACUMULAR NUC Fecha: IdCarpeta=" + Session["ID_CARPETA"] + " IdCarpetaContendra= " + lblIdCarpetaAcumular.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 32);
                }

            }
        }

        protected void NoAcumular_Click(object sender, ImageClickEventArgs e)
        {
            PanelAcumular.Visible = false;
        }

        protected void Acumular_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = false;
            Panel5.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;

            lblMsjAcumular.Visible = true;
            PanelAcumular.Visible = true;
        }






    }
}