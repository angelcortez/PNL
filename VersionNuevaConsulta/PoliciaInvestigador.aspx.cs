using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace AtencionTemprana
{
    public partial class PoliciaInvestigador : System.Web.UI.Page
    {

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();

                Session["ID_ORDEN"] = Request.QueryString["ID_ORDEN"];
                Session["ID_UNIDAD"] = Request.QueryString["ID_UNIDAD"];

                PGJ.CargaCombo(ddlTipoOrden, "CAT_TIPO_ORDEN", "IdTipoOrden", "TipoOrden");

                //Obtenemos la URL de la pagina aspx
                string path = HttpContext.Current.Request.Url.AbsolutePath;
                Session["PAGINA"] = path;

                // tenemos el nombre del equipo cliente
                string name = System.Net.Dns.GetHostName();
                Session["NOM_MAQUINA"] = name;

                IPAddress hostIPAddress1 = (Dns.Resolve(name)).AddressList[0];

                //string ip = System.Net.Dns.GetHostAddresses(name)[0].ToString();

                //Obtenemos la IP del CLIENTE 
                Session["IP_SERVER"] = hostIPAddress1.ToString();  //Request.ServerVariables["LOCAL_ADDR"];


                //Label2.Text = Session["USUARIO"].ToString() + "  " + Session["IP_SERVER"].ToString() + "  " + Session["NOM_MAQUINA"].ToString() + "  " + Session["PAGINA"].ToString() + "  " + "INICIO DE SESIÓN";

                PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), Session["PAGINA"].ToString(), "INICIO DE SESIÓN");


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

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvNuc.DataSourceID = "dsConsultaOrden";
                gvNuc.DataBind();
                gvNuc.Visible = true;

                lblNuc.Visible = false;
                txtNuc.Visible = false;

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                cmdAceptar.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                lblNuc.Visible = true;
                txtNuc.Visible = true;

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                cmdAceptar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                lblNuc.Visible = false;
                txtNuc.Visible = false;

                lblTipo.Visible = true;
                ddlTipoOrden.Visible = true;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

                cmdAceptar.Visible = true;
            }

            if (ddlBuscar.SelectedValue == "3")
            {
                lblNuc.Visible = false;
                txtNuc.Visible = false;

                lblTipo.Visible = false;
                ddlTipoOrden.Visible = false;

                lblFechaInicioOrden.Visible = true;
                txtFechaInicioOrden.Visible = true;
                lblFechaFinOrden.Visible = true;
                txtFechaFinOrden.Visible = true;

                cmdAceptar.Visible = true;
            }
        }


        protected void gvNuc_RowDataBound(object sender, GridViewRowEventArgs e)
        {




        }


        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvNuc.DataSourceID = "dsBusNuc";
                gvNuc.DataBind();
                btnMostrar.Visible = true;

            }
            if (ddlBuscar.SelectedValue == "2")
            {
                gvNuc.DataSourceID = "dsBuscarTipoOrdenPI";
                gvNuc.DataBind();
                btnMostrar.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                gvNuc.DataSourceID = "dsBuscarFechaInicioOrdenPI";
                gvNuc.DataBind();
                btnMostrar.Visible = true;
            }

        }


        protected void btnEnviada_Click(object sender, EventArgs e)
        {

            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Enviada";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;

        }

        protected void btnAsignada_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Asignada";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnProceso_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Proceso";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnCumplida_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Cumplida";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnConcluida_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsBuscarEstadoOrdenPI_Concluida";
            gvNuc.DataBind();

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsConsultaOrden";
            gvNuc.DataBind();

            lblBuscar.Visible = true;
            ddlBuscar.Visible = true;
            btnMostrar.Visible = false;

        }

        protected void ImageB_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DatosDetenidoPI.aspx?op=Agregar");
        }


    }
}