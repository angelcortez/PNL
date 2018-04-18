using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class NucJudSentencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {

                Session["IdSentencia"] = Request.QueryString["IdSentencia"];


                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                string Sql = "exec ConsultaSentenciaDetalle " + Session["IdSentencia"].ToString();
                SqlCommand CmdSentencia = new SqlCommand(Sql, Data.CnnCentral);
                SqlDataReader DR = CmdSentencia.ExecuteReader();
                if (DR.HasRows)
                {
                    DR.Read();
                    TxtSentencia.Text = DR["SENTENCIA"].ToString();
                }
                DR.Close();

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

        protected void CmdRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
        }
    }
}