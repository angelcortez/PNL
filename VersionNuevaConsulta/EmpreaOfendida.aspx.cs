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
    public partial class EmpreaOfendida : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblArbol.Text = Session["lblArbol"].ToString();
                Session["CONSECUTIVO_EMPRESA"] = Request.QueryString["CONSECUTIVO_EMPRESA"];

                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
              
                Session["op"] = Request.QueryString["op"];

                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR EMPRESA OFENDIDA";
                  

                
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR EMPRESA OFENDIDA";

                    cargarEmpresa();
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

       


        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {
            if (Session["op"].ToString() == "Agregar")
            {
                PGJ.InsertaEmpresa(int.Parse(Session["ID_CARPETA"].ToString()), txtNombre.Text, txtDomicilio.Text, txtRFC.Text, txtEscritura.Text, txtNoEscritura.Text, txtOtro.Text, txtEspecificar.Text, short.Parse(Session["IdMunicipio"].ToString()));
            }
            else if (Session["op"].ToString() == "Modificar")
            {
                PGJ.AcutalizaEmpresa(int.Parse(CONSECUTIVO_EMPRESA.Text ), txtNombre.Text, txtDomicilio.Text, txtRFC.Text, txtEscritura.Text, txtNoEscritura.Text, txtOtro.Text, txtEspecificar.Text);
             
            }
            cmdGuardar.Enabled = false;
            lblEstatus.Text = "DATOS GUARDADOS";
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        protected void cmdReg_Click1(object sender, EventArgs e)
        {
            try 
            {
            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() );
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() );
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() );
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() );
            }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

        void cargarEmpresa()
        {
            SqlCommand sql = new SqlCommand("cargarEmpresaOfendida " + int.Parse(Session["CONSECUTIVO_EMPRESA"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                CONSECUTIVO_EMPRESA.Text = dr["CONSECUTIVO_EMPRESA"].ToString();
                txtNombre.Text = dr["NOMBRE"].ToString();
                txtRFC.Text = dr["RFC"].ToString();
                txtDomicilio.Text = dr["DOMICILIO"].ToString();
                txtEscritura.Text = dr["ESCRITURA_PRUBLICA"].ToString();
                txtNoEscritura.Text = dr["NO_ESCRITURA"].ToString();
                txtOtro.Text = dr["OTRO"].ToString();
                txtEspecificar.Text = dr["ESPECIFICAR"].ToString();

            }
            dr.Close();
        }

    }
}