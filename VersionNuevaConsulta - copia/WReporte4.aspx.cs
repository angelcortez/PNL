using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AtencionTemprana
{
    public partial class WReporte4 : System.Web.UI.Page
    {
        private const string SCRIPT_DOFOCUS =
@"window.setTimeout('DoFocus()', 1);
                function DoFocus()
                {
                    try {
                        document.getElementById('REQUEST_LASTFOCUS').focus();
                    } catch (ex) {}
                }";

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
            }
        }
        private DataSet GetODS_DS(ObjectDataSource ods)
        {
            dynamic ds = new DataSet();
            dynamic dv = (DataView)ods.Select();
            if (dv != null && dv.Count > 0)
            {
                dynamic dt = dv.ToTable();
                ds.Tables.Add(dt);
            }
            return ds;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (DateTime.Parse(TxtFechaInicio.Text) > DateTime.Parse(TxtFechaFin.Text))
                {
                    lblEstatus1.Text = "LA FECHA INICIAL NO PUEDE SER MAYOR A LA FINAL, INTENTE NUEVAMENTE PORFAVOR";
                }
                else
                {
                    lblEstatus1.Text = "";
                    gvEstados.Visible = true;
                    gvEstados.DataSourceID = "ObjectTabla";
                    gvEstados.DataBind();
                    

                    ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.dsReportesTableAdapters.SP_ConteoMunicipioHechosTablaTableAdapter", "GetData");
                    ObjectDataSource1.SelectParameters.Add("IdUnidad", Session["IdUnidad"].ToString());
                    ObjectDataSource1.SelectParameters.Add("Fecha1", TxtFechaInicio.Text);
                    ObjectDataSource1.SelectParameters.Add("Fecha2", TxtFechaFin.Text);

                    Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

                    DataSet ds2 = GetODS_DS(ObjectDataSource1);


                    if (ds2.Tables.Count == 0)
                    {
                        gvEstados.Visible = false;
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.Refresh();
                        lblEstatus1.Text = "NO SE ENCONTRARON REGISTROS PARA EL RANGO DE FECHAS ESPECÍFICADO, INTENTE NUEVAMENTE POR FAVOR";
                    }
                    else
                    {

                        lblEstatus1.Text = "";
                        gvEstados.Visible = true;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(rds);
                        ReportViewer1.LocalReport.ReportPath = "RptMunicipioHechos.rdlc";
                        ReportViewer1.LocalReport.Refresh();

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Conteo de denuncias por municipio de hechos, fecha de inicio: " + TxtFechaInicio.Text + " fecha fin: " + TxtFechaFin.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                    }
                    }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }
    }
}