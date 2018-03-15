using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class DireccionServiciosPericiales_Estadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Data PGJ = new Data();
            if (!Page.IsPostBack)
            {
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();

                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();

                //IDtIPOuNIDAD.Text = Session["ID_UNDD_TPO"].ToString();

                Session["ID_UNIDAD"] = Request.QueryString["ID_UNIDAD"];

                tbl_asignarPI.Visible = false;
                tbl_.Visible = false;
               
                TLB2.Visible = false;
                TL2.Visible = false;
                lblBuscar.Visible = false;
                ddlBuscar.Visible = false;
                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;
                LblMuni.Visible = false;
                ddlMuni.Visible = false;
                cmdAceptar.Visible = false;
                Table1.Visible = false;
                Table2.Visible = false;

                PGJ.CargaComboFiltrado(ddlMuni, "CAT_MUNICIPIO", "Id_MNCPIO", "MNCPIO", "ID_ESTDO = 28");
            }
           
        }


        public void EstadisticaPI_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        public void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tbl_asignarPI.Visible = true;
            tbl_.Visible = true;
          
            TLB2.Visible = false;
            TL2.Visible = false;

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            lblFechaInicioOrden.Visible = false;
            txtFechaInicioOrden.Visible = false;
            lblFechaFinOrden.Visible = false;
            txtFechaFinOrden.Visible = false;
            LblMuni.Visible = false;
            ddlMuni.Visible = false;
            cmdAceptar.Visible = false;
            Table1.Visible = false;
            Table2.Visible = false;
        }

   

        protected void Button3_Click(object sender, EventArgs e)
        {
            tbl_asignarPI.Visible = false;
            tbl_.Visible = false;
          
            TLB2.Visible = true;
            TL2.Visible = true;

            lblBuscar.Visible = false;
            ddlBuscar.Visible = false;
            lblFechaInicioOrden.Visible = false;
            txtFechaInicioOrden.Visible = false;
            lblFechaFinOrden.Visible = false;
            txtFechaFinOrden.Visible = false;
            LblMuni.Visible = false;
            ddlMuni.Visible = false;
            cmdAceptar.Visible = false;
            Table1.Visible = false;
            Table2.Visible = false;
        }

      

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvBusquedaP.DataSourceID = "dsCargaBusqueda";
                gvBusquedaP.DataBind();
                gvBusquedaP.Visible = true;
              
              
                gvBusquedaP0.Visible = false;


                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;
                LblMuni.Visible = false;
                ddlMuni.Visible = false;


                cmdAceptar.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {


                lblFechaInicioOrden.Visible = true;
                txtFechaInicioOrden.Visible = true;
                lblFechaFinOrden.Visible = true;
                txtFechaFinOrden.Visible = true;
                LblMuni.Visible = false;
                ddlMuni.Visible = false;

               
                cmdAceptar.Visible = true;
            }

            if (ddlBuscar.SelectedValue == "2")
            {


                lblFechaInicioOrden.Visible = false;
                txtFechaInicioOrden.Visible = false;
                lblFechaFinOrden.Visible = false;
                txtFechaFinOrden.Visible = false;
                LblMuni.Visible = true;
                ddlMuni.Visible = true;


               
                cmdAceptar.Visible = true;
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            lblBuscar.Visible = true;
            ddlBuscar.Visible = true;
            //lblFechaInicioOrden.Visible = true;
            //txtFechaInicioOrden.Visible = true;
            //lblFechaFinOrden.Visible = true;
            //txtFechaFinOrden.Visible = true;
            //LblMuni.Visible = true;
            //ddlMuni.Visible = true;
            //cmdAceptar.Visible = true;
            Table1.Visible = true;
            Table2.Visible = true;

            tbl_asignarPI.Visible = false;
            tbl_.Visible = false;

            TLB2.Visible = false;
            TL2.Visible = false;
           
        }

        protected void cmdAceptar_Click1(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvBusquedaP0.DataSourceID = "DSBUSQUEDA";
                gvBusquedaP0.DataBind();

                Chart3.DataSourceID = "DSBUSQUEDA";
                Chart3.DataBind();
                gvBusquedaP.Visible = false;
                
            }

            if (ddlBuscar.SelectedValue == "2")
            {
                gvBusquedaP0.DataSourceID = "DSBUSQUEDA1";
                gvBusquedaP0.DataBind();

                Chart3.DataSourceID = "DSBUSQUEDA1";
                Chart3.DataBind();
                gvBusquedaP.Visible = false;
            

            }
        }

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {
            
            Response.Redirect("DireccionServiciosPericiales.aspx");
        }


        protected void Image3_Click(object sender, ImageClickEventArgs e)
        {
            
            Response.Redirect("DireccionServiciosPericiales_Estadisticas.aspx");
        }
       

      

    }
}