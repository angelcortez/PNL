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
    public partial class NucJudOrdenDelito : System.Web.UI.Page
    {
        Data PGJ = new Data();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {

                Session["op"] = Request.QueryString["op"];
                Session["IdOrden"] = Request.QueryString["IdOrden"];

                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();


                //PGJ.CargaCombo(CboDelito, "CAT_DELITO", "ID_DLTO", "DLTO");
                //CargaComboDelito();

            }

        }

        //void CargaComboDelito()
        //{
        //    SqlCommand cmd = new SqlCommand("ConsultaDelitosInicioCarpeta " + Session["ID_CARPETA"].ToString(), Data.CnnCentral);
        //    SqlDataReader rd = cmd.ExecuteReader();
        //    if (rd.HasRows)
        //    {
        //        CboDelito.DataSource = rd;
        //        CboDelito.DataValueField = "ID_DELITO";
        //        CboDelito.DataTextField = "DELITO";
        //        CboDelito.DataBind();
        //    }
        //    rd.Close();
        //}

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

        int DelitosMarcados()
        {
            int C = 0;

            foreach (GridViewRow row in GridDelitos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        C = C + 1;
                    }
                }
            }

            return C;
        }

        protected void CmdAgregarDelito_Click(object sender, EventArgs e)
        {
            //string Sql = "exec InsertaPGJ_NUC_JUD_ORDEN_DELITO " + int.Parse(Session["IdMunicipio"].ToString()) + "," + int.Parse(Session["IdOrden"].ToString()) + "," + CboDelito.SelectedValue + "," + CboModalidad.SelectedValue + "," + Session["IdUsuario"].ToString();
            //SqlCommand SqlOrdenDelito = new SqlCommand(Sql, Data.CnnCentral);
            //SqlOrdenDelito.ExecuteReader();

            if (DelitosMarcados() == 0)
            {
                lblEstatus.Text = "No ha seleccionado Delitos para la Orden. Seleccione al menos uno";
            }
            else
            {
                foreach (GridViewRow row in GridDelitos.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            //string IdDelito = row.Cells[1].Text.ToString();

                            string IdDelito = (row.Cells[1].FindControl("lblIdDelito") as Label).Text;

                            string IdModalidad = (row.Cells[1].FindControl("lblIdModalidad") as Label).Text;

                            string Sql = "exec InsertaPGJ_NUC_JUD_ORDEN_DELITO " + int.Parse(Session["IdMunicipio"].ToString()) + "," + int.Parse(Session["IdOrden"].ToString()) + "," + IdDelito + "," + IdModalidad + "," + Session["IdUsuario"].ToString();
                            SqlCommand SqlOrdenDelito = new SqlCommand(Sql, Data.CnnCentral);
                            SqlOrdenDelito.ExecuteReader();

                        }
                    }
                }

                Response.Redirect("NucJudordenesPersona.aspx?IdOrden=" + Session["IdOrden"].ToString() + "&op=Modificar");
            }
        }
    }
}