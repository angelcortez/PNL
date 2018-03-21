using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WebEstadisticaNUC : System.Web.UI.Page
    {

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                //ASPxPivotGrid1.Visible = false;
                //ReportViewer1.Visible = false;
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            //ReportViewer1.DataBind();
            }
            //seccionReporte.Visible = false;
            //seccionTabla.Visible = false;
                
           
        }

        protected void CmdFiltrar_Click(object sender, EventArgs e)
        {

            try
            {
                //ASPxPivotGrid1.Visible = true;
                //ReportViewer1.Visible = true;
                //ReportViewer1.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
                //seccionReporte.Visible = true;
                //seccionTabla.Visible = true;
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Se Realizo Una Busqueda de Carpetas Iniciadas NUC " + "con Fecha de Incio Del: " + TxtFecha1.Text + " Al: " + TxtFecha2.Text + " En:" + UNDD.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                SqlDataSource1.DataBind();
                ReportViewer1.LocalReport.Refresh();
               
                //document.getElementsByTagName("H1")[0].setAttribute("class", "democlass");
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
            
            
           
        }

    }
}