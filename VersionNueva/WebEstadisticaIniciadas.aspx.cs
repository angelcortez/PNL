using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





namespace AtencionTemprana
{
    public partial class WebEstadisticaIniciadas : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }

        }

        protected void cmdGenerar_Click(object sender, EventArgs e)
        {
            gvIniciada.Visible = true;
            chIniciada.Visible = true;
          //  ReportViewer1.LocalReport.Refresh();
            ddlMunicipio.Enabled = true;
            cmdMunicipio.Enabled = true;
            ddlUnidad.Enabled = false;
            cmdUnidad.Enabled = false;
            PGJ.CargaComboFiltrado(ddlMunicipio, "CAT_MUNICIPIO", "ID_MNCPIO", "MNCPIO", "ID_ESTDO=28 and ID_PAIS=1");
            gvIniciada.DataSourceID = "dsIniciadasAñoGV";
            gvIniciada.DataBind();
            chIniciada.DataSourceID = "dsIniciadasAñoGrafica";
            chIniciada.DataBind();

            

            
           
          

            
        }

        protected void cmdMunicipio_Click(object sender, EventArgs e)
        {
            gvIniciada.Visible = true;
            chIniciada.Visible = true;
            ddlMunicipio.Enabled = true;
            cmdMunicipio.Enabled = true;
            ddlUnidad.Enabled = true;
            cmdUnidad.Enabled = true;
            PGJ.CargaComboFiltrado(ddlUnidad, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1  or ID_UNDD_TPO=2) and UNDD_ACTVO='true' and ID_MNCPIO=" + ddlMunicipio.SelectedValue);
            gvIniciada.DataSourceID = "dsIniciadasAñoMunicipioGV";
            gvIniciada.DataBind();
            chIniciada.DataSourceID = "dsIniciadasAñoMunicipioGrafica";
            chIniciada.DataBind();
        }

        protected void cmdUnidad_Click(object sender, EventArgs e)
        {
            gvIniciada.Visible = true;
            chIniciada.Visible = true;
            ddlMunicipio.Enabled = true;
            cmdMunicipio.Enabled = true;
            ddlUnidad.Enabled = true;
            cmdUnidad.Enabled = true;
            gvIniciada.DataSourceID = "dsIniciadasAñoMunicipioUnidadGV";
            gvIniciada.DataBind();
            chIniciada.DataSourceID = "dsIniciadasAñoMunicipioUnidadGrafica";
            chIniciada.DataBind();
        }
    }
}