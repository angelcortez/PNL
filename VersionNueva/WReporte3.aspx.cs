using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WReporte3 : System.Web.UI.Page
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //gvEstados.Visible = true;
            //gvEstados.DataSourceID = "ObjectTabla";
            //gvEstados.DataBind();

            LBVerDetalles.Visible = true;

            Chart1.Visible = true;



            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.dsReportesTableAdapters.SP_ConteoDenunciasMesesTableAdapter", "GetData");
            ObjectDataSource1.SelectParameters.Add("IdUnidad", IdUnidad.Text);
            ObjectDataSource1.SelectParameters.Add("Fecha1", TxtFechaInicio.Text);
            ObjectDataSource1.SelectParameters.Add("Fecha2", TxtFechaFin.Text);
            

            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.dsReportesTableAdapters.SP_ConteoDenunciasMesesGraficaTableAdapter", "GetData");
            ObjectDataSource2.SelectParameters.Add("IdUnidad", IdUnidad.Text);
            ObjectDataSource2.SelectParameters.Add("Fecha1", TxtFechaInicio.Text);
            ObjectDataSource2.SelectParameters.Add("Fecha2", TxtFechaFin.Text);
   

            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.ReportPath = "ReporteDenuncias.rdlc";
            ReportViewer1.LocalReport.Refresh();

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Conteo de denuncinas por fecha de hechos organizado por fecha de denuncia, fecha de inicio: " + TxtFechaInicio.Text + " fecha fin: " + TxtFechaFin.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
        }

        protected void LBVerDetalles_Click(object sender, EventArgs e)
        {

            //Response.Write("<script>window.open('WDetailsPerson.aspx','Titulo','height=300', 'width=300')</script>");
            Response.Write("<script>window.open('WDetailsDenuncias.aspx?IdU=" + IdUnidad.Text + "&IdM=" + IdMunicipio.Text + "&FI=" + TxtFechaInicio.Text + "&FF=" + TxtFechaFin.Text + "' ,'Titulo','height=300', 'width=300','toolbar=yes','scrollbars=yes','resizable=yes')</script>");
            Chart1.Visible = true;
            //gvEstados.Visible = true;
            //gvEstados.DataSourceID = "ObjectTabla";
            //gvEstados.DataBind();
        }
    }
}