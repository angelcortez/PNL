using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WebEstadisticaEstados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }

        protected void cmdGenerar_Click(object sender, EventArgs e)
        {
            gvEstados.Visible = true;
            chEstados.Visible = true;
            ReportViewer1.LocalReport.Refresh();
        }
    }
}