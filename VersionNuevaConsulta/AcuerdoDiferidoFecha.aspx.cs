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
    public partial class AcuerdoDiferidoFecha : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // lblArbol.Text = Session["lblArbol"].ToString();

                Session["ID_ACUERDO_DIFERIDO"] = Request.QueryString["ID_ACUERDO_DIFERIDO"];
                Session["ID_NUM_CUM_DIFERIDO"] = Request.QueryString["ID_NUM_CUM_DIFERIDO"];

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["op"] = Request.QueryString["op"];

                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR FECHA DE CUMPLIMIENTO";
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    ID_NUM_CUM_DIFERIDO.Text = Session["ID_NUM_CUM_DIFERIDO"].ToString();

                    PGJ.CargaCombo(ddlCumplido, "CAT_ACUERDO_CUMPLIDO", "ID_CUMPLIDO", "CUMPLIDO");
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR FECHA DE CUMPLIMIENTO DIFERIDO";
                    PGJ.CargaCombo(ddlCumplido, "CAT_ACUERDO_CUMPLIDO", "ID_CUMPLIDO", "CUMPLIDO");
                    cargarFechaAcuerdo();
                    lblEstado.Visible = true;
                    ddlCumplido.Visible = true;
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

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["op"].ToString() == "Agregar")
                {
                    PGJ.InsertaAcuerdoDiferidoFecha(int.Parse(IdCarpeta.Text),int.Parse(ID_NUM_CUM_DIFERIDO.Text ), DateTime.Parse(txtFechaCumplimiento.Text ),short.Parse(ddlCumplido.SelectedValue.ToString()),txtConcepto.Text ,txtImporte.Text ,short.Parse(Session["IdMunicipio"].ToString()),  short.Parse(Session["IdUsuario"].ToString()));
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    PGJ.ActualizaAcuerdoDiferidoFecha(int.Parse(ID_ACUERDO_DIFERIDO.Text), DateTime.Parse(txtFechaCumplimiento.Text), short.Parse(ddlCumplido.SelectedValue.ToString()), txtConcepto.Text, txtImporte.Text);
                }
                lblEstatus.Text = "DATOS GUARDADOS";
                cmdGu.Enabled = false;

                Response.Redirect("AcuerdoCumplimientoDiferido.aspx?ID_NUM_CUM_DIFERIDO=" + Session["ID_NUM_CUM_DIFERIDO"].ToString() + "&op=Modificar");
       

            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcuerdoCumplimientoDiferido.aspx?ID_NUM_CUM_DIFERIDO=" + Session["ID_NUM_CUM_DIFERIDO"].ToString() + "&op=Modificar");
        }

        void cargarFechaAcuerdo()
        {
            SqlCommand sql = new SqlCommand("cargarAcuerdoDiferidoFecha " + int.Parse(Session["ID_ACUERDO_DIFERIDO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ID_ACUERDO_DIFERIDO.Text = dr["ID_ACUERDO_DIFERIDO"].ToString();
                ID_NUM_CUM_DIFERIDO.Text = dr["ID_NUM_CUM_DIFERIDO"].ToString();
                // Data.IdPersona = Convert.ToInt32(ID_PERSONA.Text);
                IdCarpeta.Text = dr["ID_CARPETA"].ToString();
                txtConcepto.Text = dr["CONCEPTO"].ToString();
                txtImporte.Text = dr["IMPORTE"].ToString();
                txtFechaCumplimiento.Text = dr["FECHA_CUMPLIMIENTO"].ToString();
                ddlCumplido.SelectedValue = dr["ID_CUMPLIDO"].ToString();
            }
            dr.Close();
        }


    }
}