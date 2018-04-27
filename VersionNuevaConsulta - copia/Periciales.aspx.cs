using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Periciales : System.Web.UI.Page
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

                PGJ.CargaCombo(ddlSERP, "CAT_DEPARTAMENTO_PERICIAL", "Id_DEPTO_PRCIAL", "DEPTO_PRCIAL");
                PGJ.CargaComboFiltrado(ddlMuni, "CAT_MUNICIPIO", "Id_MNCPIO", "MNCPIO", "ID_ESTDO = 28");


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
                ddlSERP.Visible = false;

                lblmuni.Visible = false;
                ddlMuni.Visible = false;

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
                ddlSERP.Visible = false;

                lblmuni.Visible = false;
                ddlMuni.Visible = false;

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
                ddlSERP.Visible = true;

                lblmuni.Visible = false;
                ddlMuni.Visible = false;

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
                ddlSERP.Visible = false;

                lblmuni.Visible = true;
                ddlMuni.Visible = true;

                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;

               
                cmdAceptar.Visible = true;
            }

            if (ddlBuscar.SelectedValue == "4")
            {
                lblNuc.Visible = false;
                txtNuc.Visible = false;

                lblTipo.Visible = false;
                ddlSERP.Visible = false;

                lblmuni.Visible = false;
                ddlMuni.Visible = false;

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
                gvNuc.DataSourceID = "dsBuscarNuc";
                gvNuc.DataBind();

               
                btnMostrar.Visible = true;
               
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                gvNuc.DataSourceID = "dsBuscarDpto";
                gvNuc.DataBind();

               
                btnMostrar.Visible = true;
               
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                gvNuc.DataSourceID = "dsBuscarMuni";
                gvNuc.DataBind();

             
                btnMostrar.Visible = true;
               
            }
            if (ddlBuscar.SelectedValue == "4")
            {
                gvNuc.DataSourceID = "dsBuscarFechaInicioSolicitud";
                gvNuc.DataBind();

               
                btnMostrar.Visible = true;
                
            }

        }



        protected void btnAsignada_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            gvNuc.DataSourceID = "dsBuscarEstadoSolicitudP_Asignada";
            gvNuc.DataBind();
            Label1.Text = gvNuc.Rows.Count.ToString();
            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
        }

        protected void btnProceso_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
           
            gvNuc.DataSourceID = "dsBuscarEstadoSolicitudP_Proceso";
            gvNuc.DataBind();
            Label2.Text = gvNuc.Rows.Count.ToString();
            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
            Label1.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            
        }

        protected void btnCumplida_Click(object sender, EventArgs e)
        {
            Label3.Visible = true;
            gvNuc.DataSourceID = "dsBuscarEstadoSolicitudP_Cumplida";
            gvNuc.DataBind();
           Label3.Text = gvNuc.Rows.Count.ToString();
            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
            Label2.Visible = false;
            Label1.Visible = false;
            Label4.Visible = false;
           
        }

        protected void btnConcluida_Click(object sender, EventArgs e)
        {
            Label4.Visible = true;
            gvNuc.DataSourceID = "dsBuscarEstadoSolicitudP_Concluida";
            gvNuc.DataBind();
            Label4.Text = gvNuc.Rows.Count.ToString();
            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            btnMostrar.Visible = true;
            Label2.Visible = false;
            Label3.Visible = false;
            Label1.Visible = false;
           
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            gvNuc.DataSourceID = "dsConsultaOrden";
            gvNuc.DataBind();

            lblBuscar.Visible = true;
            ddlBuscar.Visible = true;
            btnMostrar.Visible = false;

        }

      

    }
}