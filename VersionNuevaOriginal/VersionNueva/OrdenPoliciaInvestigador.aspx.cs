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
    public partial class OrdenPoliciaInvestigador1 : System.Web.UI.Page
    {
        Data PGJ = new Data();
        DataSet ds = new DataSet();
        DataTable dtArbol = new DataTable();
        int Id = 20;
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
                //Session["Policia"] = Request.QueryString["Policia"];

                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                if (Request.QueryString["ID_CARPETA"] != null && Request.QueryString["REG"] == "1")
                {
                    Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                }
                else if (Request.QueryString["ID_CARPETA"] != null && Request.QueryString["ID_ORDEN"] != null)
                {
                    Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                    Session["ID_ORDEN"] = Request.QueryString["ID_ORDEN"];
                }

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

                if (Session["op"].ToString() == "Policia")
                {
                    CargarDocumentoPolicia(Session["IdDoc"].ToString());
                }


                if (Session["op"].ToString() == "Foto")
                {
                    CargarFoto(Session["IdDoc"].ToString());
                }

                if (Session["op"].ToString() == "Anexo")
                {
                    CargarAnexo(Session["IdDoc"].ToString());
                }

                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                IdOrden.Text = Session["ID_ORDEN"].ToString();

                CargarDatosCarpeta();

            }
        }

        private void CargarDocumentoPolicia(string ID_PDF)
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


        private void CargarAnexo(string ID_PDF)
        {
            byte[] bits;
            try
            {
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SELECT * from PGJ_ANEXOS_ORDEN_PI  WHERE ID_DOCUMENTO = " + ID_PDF, Data.CnnCentral);
                comm.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet("Binarios");
                da.Fill(ds);
                //Creamos un array de bytes que contiene los bytes almacenados
                //en el campo Documento de la tabla
                bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
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
   
                string script = @"<script type='text/javascript'>
                            alert('NO EXISTE DOCUMENTO');
                            location.href= 'CargarAnexo.aspx?ID_DOCUMENTO="+ID_PDF+"'</script>";
                

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    
            }
        }

        private void CargarFoto(string ID_PDF)
        {
            byte[] bits;
            try
            {

                
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SELECT * from PGJ_FOTO_ORDEN_PI  WHERE ID_FOTO_ORDEN_PI = " + ID_PDF, Data.CnnCentral);
                comm.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet("Binarios");
                da.Fill(ds);
                //Creamos un array de bytes que contiene los bytes almacenados
                //en el campo Documento de la tabla
                bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
                //Vamos a guardar ese array de bytes como un fichero en el
                //disco duro, un fichero temporal que después se podrá descartar.
                string sFile = "tmpImage.jpg";
                //Creamos un nuevo FileStream, que esta vez servirá para
                //crear un fichero con el nombre especificado
                fs = new FileStream(Server.MapPath(".") +
                @"\DocTmp\" + sFile, FileMode.Create);
                //Y escribimos en disco el array de bytes que conforman
                //el fichero Word 
                fs.Write(bits, 0, Convert.ToInt32(bits.Length));
                fs.Close();
                //Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
                //tecleo mi dominio o IP
                //String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
                //ruta_pdf = ruta_pdf.Replace("\\", "/");

                string script = "<script languaje='javascript'> ";
                script += "mostrarFichero('DocTmp/tmpImage.jpg') ";
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


        private void CargarDocumento(string ID_PDF)
        {
            byte[] bits;
            try
            {
                PGJ.ConnectServer();
                SqlCommand comm = new SqlCommand("SELECT * from PGJ_CARPETA_PDF  WHERE ID_PDF = " + ID_PDF, Data.CnnCentral);
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

        protected void CargarDatosCarpeta()
        {
            try
            {
                int IdUser;
                IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());

                PGJ.InsertaArbol(1, 0, "CARPETA", "", "", IdUser);
                PGJ.InsertaArbol(2, 1, "RAC", "", "", IdUser);
                PGJ.InsertaArbol(3, 1, "NUM", "", "", IdUser);
                PGJ.InsertaArbol(4, 1, "NUC", "", "", IdUser);

                PGJ.InsertaArbol(5, 1, "DENUNCIANTE", "", "", IdUser);
                PGJ.InsertaArbol(6, 1, "OFENDIDO", "", "", IdUser);
                PGJ.InsertaArbol(16, 1, "EMPRESA", "", "", IdUser);
                PGJ.InsertaArbol(7, 1, "IMPUTADO", "", "", IdUser);
                PGJ.InsertaArbol(8, 1, "TESTIGO", "Datos.aspx?&op=AgregarTes", "", IdUser);
                PGJ.InsertaArbol(14, 1, "DEFENSOR", "", "", IdUser);
                PGJ.InsertaArbol(9, 1, "LUGAR DE HECHOS", "", "", IdUser);
                PGJ.InsertaArbol(10, 1, "DELITO", "", "", IdUser);
                PGJ.InsertaArbol(15, 1, "VEHICULOS", "", "", IdUser);
                PGJ.InsertaArbol(11, 1, "DESCRIPCION HECHOS", "", "", IdUser);
               // PGJ.InsertaArbol(12, 1, "SOLICITUDES DE AUDIENCIA", "Solicitudes.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(13, 1, "ACTUACIONES", "", "", IdUser);
                PGJ.InsertaArbol(17, 1, "POLICIA INVESTIGADOR", "", "", IdUser);
                PGJ.InsertaArbol(18, 17, "FOTOGRAFIAS", "", "", IdUser);
                PGJ.InsertaArbol(19, 17, "ANEXOS", "", "", IdUser);
                //PGJ.InsertaArbol(19, 17, "VIDEOS", "", "", IdUser);

                CargarDatosArbol("RAC", 2);
                CargarDatosArbol("NUM", 3);
                CargarDatosArbol("NUC", 4);
                CargarDatosArbol("Persona 1, ", 5);
                CargarDatosArbol("Persona 2, ", 6);
                //CargarDatosArbol("Persona 8, ", 6);
                CargarDatosArbol("Persona 3, ", 7);
                CargarDatosArbol("Persona 4, ", 8);
                CargarDatosArbol("Descripcion", 11);
                CargarDatosArbol("LugarHechos", 9);
                CargarDatosArbol("Delito", 10);
                CargarDatosArbol("Audiencia", 12);
                CargarDatosArbol("DocumentosConsulta", 13);
                CargarDatosArbol("Defensor", 14);
                CargarDatosArbol("Vehiculo", 15);
                CargarDatosArbol("Empresa", 16);
                CargarDatosArbol("Policia", 17);
                CargarDatosArbol("DetencionPolicia", 17);
                CargarDatosArbol("FotoPI", 18);
                CargarDatosArbol("AnexoPI", 19);
                LLenarArbol(TVCarpeta.Nodes, 0);

                PGJ.EliminaArbol(IdUser);
            }
            catch (Exception ex)
            {
                Response.Redirect("OrdenPoliciaInvestigador.aspx");

                //lblEstatus.Text = ex.Message;

            }
        }

        protected void CargarDatosArbol(string Carpeta, int IdPadre)
        {
            SqlDataAdapter daArbol = new SqlDataAdapter("DatosArbol" + Carpeta + " " + Convert.ToString(IdCarpeta.Text) , Data.CnnCentral);
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

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["ID_PUESTO"].ToString() == "8")
            {
                Response.Redirect("PoliciaInvestigador.aspx");
            }

            else if (Session["ID_PUESTO"].ToString() == "16")
            {
                Response.Redirect("CoordPoliciaInvestigador_MisOrdenes.aspx");
            }    
        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ElaborarInformePolicial.aspx");
        }

        protected void Image4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CargarFotografiasPI.aspx");
        }

        protected void Image3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SolicitudPeritos.aspx");
        }

        protected void Image5_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CargarVideo.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ObjetosAseguradosPI.aspx");
        }

        

    }
}