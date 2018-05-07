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
    public partial class Usuarios : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Session["ID_USUARIO"] = Request.QueryString["ID_USUARIO"];
                Session["op"] = Request.QueryString["op"];

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                cargarFecha();
                PGJ.CargaCombo(ddlUnidad, "CAT_UNIDAD", "ID_UNDD", "ALIAS");
                PGJ.CargaCombo(ddlModulo, "CAT_MODULO", "ID_MODULO", "MODULO");
                PGJ.CargaCombo(ddlPuesto, "CAT_PUESTO_USUARIOS", "ID_PUESTO", "PUESTO");


                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR USUARIO";
                    // ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    //consultaIdAlias();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR USUARIO";
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();


                    cargarUsuario();
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
            if (Session["op"].ToString() == "Agregar")
            {
                PGJ.InsertaUsuario(txtUsuario.Text, txtContraseña.Text, short.Parse(ddlUnidad.SelectedValue.ToString()), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtFechaBaja.Text, short.Parse(rbActivo.SelectedValue.ToString()), short.Parse(ddlPuesto.SelectedValue.ToString()), short.Parse(ddlModulo.SelectedValue.ToString()));
            }
            else if (Session["op"].ToString() == "Modificar")
            {
                PGJ.ActualizaUsuario(txtUsuario.Text, txtContraseña.Text, short.Parse(ddlUnidad.SelectedValue.ToString()), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtFechaBaja.Text, short.Parse(rbActivo.SelectedValue.ToString()), short.Parse(ddlPuesto.SelectedValue.ToString()), short.Parse(ddlModulo.SelectedValue.ToString()), int.Parse(Session["ID_USUARIO"].ToString()));
            }

            lblEstatus.Text = "DATOS GUARDADOS";
            cmdGuardar.Enabled = false;

        }

        protected void cmdReg_Click1(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Administrar.aspx");
        }

        void cargarUsuario()
        {
            SqlCommand sql = new SqlCommand("cargarUsuario " + int.Parse(Session["ID_USUARIO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_USUARIO.Text = dr["ID_USUARIO"].ToString();
                txtNombre.Text = dr["NMBRE"].ToString();
                txtPaterno.Text = dr["PTRNO"].ToString();
                txtMaterno.Text = dr["MTRNO"].ToString();
                txtUsuario.Text = dr["USUARIO"].ToString();
                txtContraseña.Text = dr["CNTRSNA"].ToString();
                ddlUnidad.SelectedValue = dr["ID_UNDD"].ToString();
                ddlModulo.SelectedValue = dr["ID_MODULO"].ToString();
                ddlPuesto.SelectedValue = dr["ID_PUESTO"].ToString();
                rbActivo.SelectedValue = dr["ACTVO"].ToString();
                txtFechaBaja.Text = dr["FCHA_BJA"].ToString();

            }
            dr.Close();
        }
    }
}