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
using System.Reflection;
//using Microsoft.Office.Core;
//using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Word
using System.IO;
using System.Diagnostics;

namespace AtencionTemprana
{
    public partial class NUM_ACUERDOS : System.Web.UI.Page
    {
        Data PGJ = new Data();
        DataTable dtArbol = new DataTable();
        int Id = 19;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["lblArbol"] = lblArbol.Text;

                Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                Session["ID_ESTADO_NUM"] = Request.QueryString["ID_ESTADO_NUM"];
                ID_ESTADO_NUM.Text = Session["ID_ESTADO_NUM"].ToString();

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                CargarDatosCarpeta();
                LLenarArbol(TVCarpeta.Nodes, 0);
                cargarFecha();
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
                PGJ.InsertaArbol(15, 1, "SEGUIMIENTO", "", "", IdUser);
                PGJ.InsertaArbol(3, 1, "NUM", "", "", IdUser);
                PGJ.InsertaArbol(2, 1, "RAC", "", "", IdUser);
                PGJ.InsertaArbol(4, 1, "NUC", "", "", IdUser);

                PGJ.InsertaArbol(5, 1, "SOLICITANTE", "", "", IdUser);
                PGJ.InsertaArbol(6, 1, "OFENDIDO", "", "", IdUser);
                PGJ.InsertaArbol(13, 1, "EMPRESA", "", "", IdUser);
                PGJ.InsertaArbol(7, 1, "INVITADO", "", "", IdUser);
                PGJ.InsertaArbol(8, 1, "LUGAR DE HECHOS", "", "", IdUser);
                PGJ.InsertaArbol(9, 1, "DELITO", "", "", IdUser);
                PGJ.InsertaArbol(10, 1, "VEHICULOS", "", "", IdUser);
                PGJ.InsertaArbol(11, 1, "DESCRIPCION HECHOS", "", "", IdUser);

                if (Session["ID_ESTADO_NUM"].ToString() == "27" || Session["ID_ESTADO_NUM"].ToString() == "28")
                {
                    PGJ.InsertaArbol(12, 1, "ACUERDO DE CUMPLIMIENTO DIFERIDO", "AcuerdoCumplimientoDiferido.aspx?op=Agregar", "", IdUser);
                    CargarDatosArbol("AcuerdoDiferido", 12);
                }


                PGJ.InsertaArbol(14, 1, "ACTUACIONES", "DocMediacion.aspx?op=Agregar", "", IdUser);

                CargarDatosArbol("RAC", 2);
                CargarDatosArbol("NUM", 3);
                CargarDatosArbol("NUC", 4);
                CargarDatosArbol("Persona 1, ", 5);
                CargarDatosArbol("Persona 2, ", 6);
                CargarDatosArbol("Persona 3, ", 7);             
                CargarDatosArbol("LugarHechos", 8);
                CargarDatosArbol("Delito", 9);
                CargarDatosArbol("Vehiculo", 10);
                CargarDatosArbol("Descripcion", 11);                        
                CargarDatosArbol("Empresa", 13);
                CargarDatosArbol("DocumentosMediacion", 14);
                CargarDatosArbol("Seguimiento", 15);   
                


                LLenarArbol(TVCarpeta.Nodes, 0);

                PGJ.EliminaArbol(IdUser);
            }
            catch (Exception ex)
            {
                Response.Redirect("NUM_ACUERDOS.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());

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


    }
}