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

namespace AtencionTemprana
{
    public partial class NAC : System.Web.UI.Page
    {
        Data PGJ = new Data();
        DataTable dtArbol = new DataTable();
        int Id = 14;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["lblArbol"] = lblArbol.Text;

                Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                Session["ID_ESTADO_NAC"] = Request.QueryString["ID_ESTADO_NAC"];
                ID_ESTADO_NAC.Text = Session["ID_ESTADO_NAC"].ToString();

                PUESTO.Text = Session["PUESTO"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();

               CargarDatosCarpeta();
                //LLenarArbol(TVCarpeta.Nodes, 0);

                cargarFecha();
                LBLUSUARIO.Text = Session["Us"].ToString();
                try
                {
                PGJ.CargaComboFiltrado(ddlOrientacion, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "ID_UNDD_TPO=2 and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                
                }
                catch (Exception ex)
                {
                    Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
                    //lblEstatus.Text = ex.Message;
                }

                if (Session["ID_ESTADO_NAC"].ToString() == "1")
                {
                    Remitir.Visible = true;
                    Panel1.Visible = false;
                }
                else if (Session["ID_ESTADO_NAC"].ToString() == "4")
                {
                    Remitir.Visible = false;
                    Panel1.Visible = false;
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

        protected void ImgSi2_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sqlCanalizada = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NAC=4, ACTIVO_RAC='TRUE', ID_ESTADO_RAC=0" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlCanalizada.ExecuteReader();
            rdC.Close();

           string CAD;
           CAD = "set dateformat dmy INSERT INTO PGJ_NAC_REMITIDA(ID_CARPETA,ID_MUNICIPIO_REMITIDA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlOrientacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemitir.Text + "'" + ")";

            SqlCommand sqlIniciada = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdIniciada = sqlIniciada.ExecuteReader();

            rdIniciada.Close();


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_RAC_INICIADA(ID_CARPETA,ID_MUNICIPIO_INICIADA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ddlOrientacion.SelectedValue.ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemitir.Text + "'" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Remitir.Visible = false;
            Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + 4);
        }

        protected void CargarDatosCarpeta()
        {try {
            int IdUser;
            IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());

            PGJ.InsertaArbol(1, 0, "CARPETA", "", "", IdUser);
            PGJ.InsertaArbol(2, 1, "NAC", "", "", IdUser);
            PGJ.InsertaArbol(3, 1, "RAC", "", "", IdUser);


            PGJ.InsertaArbol(4, 1, "DENUNCIANTE", "Datos.aspx?&op=Agregar", "", IdUser);
            PGJ.InsertaArbol(5, 1, "OFENDIDO", "QuienResulteOfendido.aspx", "", IdUser);
            PGJ.InsertaArbol(6, 1, "EMPRESA", "EmpreaOfendida.aspx?&op=Agregar", "", IdUser);
            PGJ.InsertaArbol(7, 1, "IMPUTADO", "QuienResulteResponsable.aspx", "", IdUser);
            //PGJ.InsertaArbol(7, 1, "TESTIGO", "Datos.aspx?&op=AgregarTes", "", IdUser);
            // PGJ.InsertaArbol(13, 1, "DEFENSOR", "DefensorPublico.aspx", "", IdUser);
            PGJ.InsertaArbol(8, 1, "LUGAR DE HECHOS", "LugarHechos.aspx?&op=Agregar", "", IdUser);
            PGJ.InsertaArbol(9, 1, "DELITO", "", "", IdUser);
            PGJ.InsertaArbol(10, 1, "VEHICULOS", "Vehiculo.aspx?&op=Agregar", "", IdUser);
            PGJ.InsertaArbol(11, 1, "DESCRIPCION HECHOS", "Hechos.aspx?&op=Agregar", "", IdUser);
            // PGJ.InsertaArbol(11, 1, "SOLICITUDES DE AUDIENCIA", "Solicitudes.aspx?&op=Agregar", "", IdUser);

            PGJ.InsertaArbol(12, 1, "ACTUACIONES", "DocCominidad.aspx?op=Agregar", "", IdUser);

            CargarDatosArbol("NAC", 2);
            CargarDatosArbol("RAC", 3);

            CargarDatosArbol("Persona 1, ", 4);
            CargarDatosArbol("Persona 2, ", 5);
            //CargarDatosArbol("Persona 8, ", 6);
            CargarDatosArbol("Persona 3, ", 7);


            CargarDatosArbol("LugarHechos", 8);
            CargarDatosArbol("Delito", 9);
            CargarDatosArbol("Descripcion", 11);
            CargarDatosArbol("Empresa", 7);
            CargarDatosArbol("DocumentosAtencion", 12);
            //  CargarDatosArbol("Defensor", 13);
            CargarDatosArbol("Vehiculo", 10);
            LLenarArbol(TVCarpeta.Nodes, 0);

            PGJ.EliminaArbol(IdUser);
        }
        catch (Exception ex)
        {
            Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
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

        protected void Remitir_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void ImgNo3_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
        }
    }
}