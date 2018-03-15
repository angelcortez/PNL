using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WTipoDQ : System.Web.UI.Page
    {
        Data PGJ = new Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            Session["op"] = Request.QueryString["op"];
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            Session["lblArbol"] = lblArbol.Text;
            cargarFecha();
            LBLUSUARIO.Text = Session["Us"].ToString();


            IdMunicipio.Text = Session["IdMunicipio"].ToString();
            IdUnidad.Text = Session["IdUnidad"].ToString();


                //INICIO-ocultando el menu cuando inicia carpeta

                HyperLink linkRac = this.Page.Master.FindControl("hRac") as HyperLink;
                linkRac.Text = "";
                linkRac.Visible = false;
                linkRac.Enabled = false;
                linkRac.NavigateUrl = "#";

                HyperLink linkDerivada = this.Page.Master.FindControl("hDerivada") as HyperLink;
                linkDerivada.Text = "";
                linkDerivada.Visible = false;
                linkDerivada.Enabled = false;
                linkDerivada.NavigateUrl = "#";

                HyperLink linkNuc = this.Page.Master.FindControl("hlSec") as HyperLink;
                linkNuc.Text = "";
                linkNuc.Visible = false;
                linkNuc.Enabled = false;
                linkNuc.NavigateUrl = "#";

                HyperLink linkEstadistica = this.Page.Master.FindControl("hEstadistica") as HyperLink;
                linkEstadistica.Text = "";
                linkEstadistica.Visible = false;
                linkEstadistica.Enabled = false;
                linkEstadistica.NavigateUrl = "#";

                HyperLink linkBusqueda = this.Page.Master.FindControl("hBusquedaPersonasNSJP") as HyperLink;
                linkBusqueda.Text = "";
                linkBusqueda.Visible = false;
                linkBusqueda.Enabled = false;
                linkBusqueda.NavigateUrl = "#";

                HyperLink linkBusquedaPNL = this.Page.Master.FindControl("hBusquedaPNL") as HyperLink;
                linkBusquedaPNL.Text = "";
                linkBusquedaPNL.Visible = false;
                linkBusquedaPNL.Enabled = false;
                linkBusquedaPNL.NavigateUrl = "#";

                HyperLink linkEstadisticaNUC = this.Page.Master.FindControl("hEstadisticaNUC") as HyperLink;
                linkEstadisticaNUC.Text = "";
                linkEstadisticaNUC.Visible = false;
                linkEstadisticaNUC.Enabled = false;
                linkEstadisticaNUC.NavigateUrl = "#";

                HyperLink linkReportes = this.Page.Master.FindControl("HyperLinkEsta") as HyperLink;
                linkReportes.Text = "";
                linkReportes.Visible = false;
                linkReportes.Enabled = false;
                linkReportes.NavigateUrl = "#";

                //HyperLink linkCS = this.Page.Master.FindControl("hCerrarSesion") as HyperLink;
                //linkCS.Text = "";
                //linkCS.Visible = false;
                //linkCS.Enabled = false;
                //linkCS.NavigateUrl = "#";

                //FIN-ocultando el menu cuando inicia carpeta
    
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
        protected void Denuncia_Click(object sender, EventArgs e)
        {
            Session["INICIAR_CARPETA"] = "1";
            Session["TipoDQ"] = "1";
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en el Boton DENUNCIA", int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("FormaInicioRac.aspx");
        }

        protected void Querella_Click(object sender, EventArgs e)
        {
            Session["INICIAR_CARPETA"] = "1";
            Session["TipoDQ"] = "2";
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en el Boton QUERELLA", int.Parse(Session["IdModuloBitacora"].ToString()));

            Response.Redirect("FormaInicioRac.aspx");
        }
    }
}