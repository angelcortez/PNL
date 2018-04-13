﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WReporte5 : System.Web.UI.Page
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
                IdUn.Text = Session["IdUnidad"].ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //gvEstados.Visible = true;
                //gvEstados.DataSourceID = "ObjectTabla";
                //gvEstados.DataBind();
                LBVerDetalles.Visible = true;

                ChartEstados.Visible = true;

                if (DateTime.Parse(TxtFechaInicio.Text) > DateTime.Parse(TxtFechaFin.Text))
                {
                    lblEstatus1.Text = "LA FECHA INICIAL NO PUEDE SER MAYOR A LA FINAL, INTENTE NUEVAMENTE PORFAVOR";
                }
                else
                {
                    lblEstatus1.Text = "";

                    ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.dsReportesTableAdapters.SP_ConteoDelitosTablaTableAdapter", "GetData");
                    ObjectDataSource1.SelectParameters.Add("IdUnidad", IdUn.Text);
                    ObjectDataSource1.SelectParameters.Add("Fecha1", TxtFechaInicio.Text);
                    ObjectDataSource1.SelectParameters.Add("Fecha2", TxtFechaFin.Text);

                    Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

                    ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.dsReportesTableAdapters.SP_ConteoDelitosGraficaTableAdapter", "GetData");
                    ObjectDataSource2.SelectParameters.Add("IdUnidad", IdUn.Text);
                    ObjectDataSource2.SelectParameters.Add("Fecha1", TxtFechaInicio.Text);
                    ObjectDataSource2.SelectParameters.Add("Fecha2", TxtFechaFin.Text);

                    Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportViewer1.LocalReport.DataSources.Add(rds2);
                    ReportViewer1.LocalReport.ReportPath = "RptDelitos.rdlc";
                    ReportViewer1.LocalReport.Refresh();

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Conteo de denuncias por delito, fecha de inicio: " + TxtFechaInicio.Text + " fecha fin: " + TxtFechaFin.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }
        protected void LBVerDetalles_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.open('WDetailsPerson.aspx','Titulo','height=300', 'width=300')</script>");
            Response.Write("<script>window.open('WDetailsDelit.aspx?IdU=" + IdUn.Text + "&IdM=" + IdMunicipio.Text + "&FI=" + TxtFechaInicio.Text + "&FF=" + TxtFechaFin.Text + "' ,'Titulo','height=300', 'width=300','toolbar=yes','scrollbars=yes','resizable=yes')</script>");
            ChartEstados.Visible = true;
            //gvEstados.Visible = true;
            //gvEstados.DataSourceID = "ObjectTabla";
            //gvEstados.DataBind();
        }
    }
}