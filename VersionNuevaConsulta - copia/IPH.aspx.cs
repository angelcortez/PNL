using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class IPH : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            PGJ.ConnectServer();
            cargarFecha();
            LBLUSUARIO.Text = Session["Us"].ToString();
            IdMunicipio.Text = Session["IdMunicipio"].ToString();
            lblIdUnidad.Text = Session["IdUnidad"].ToString();
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();

            desactivaControles();

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




        protected void btnAceptarIPH_Click(object sender, EventArgs e)
        {
            
            if (ddlBuscarIPH.SelectedValue == "1")
            {
                gvIPH.DataSourceID = "dsbuscarIPHiph";
                gvIPH.DataBind();


            }
            else if (ddlBuscarIPH.SelectedValue == "2")
            {
                gvIPH.DataSourceID = "dsbuscarIPHFolio";
                gvIPH.DataBind();

            }
            else if (ddlBuscarIPH.SelectedValue == "3")
            {
                gvIPH.DataSourceID = "dsbuscarIPHDetenido";
                gvIPH.DataBind();

            }
            else if (ddlBuscarIPH.SelectedValue == "4")
            {
                gvIPH.DataSourceID = "dsbuscarIPHHuella";
                gvIPH.DataBind();

            }
            else if (ddlBuscarIPH.SelectedValue == "5")
            {
                gvIPH.DataSourceID = "dsbuscarIPHImagen";
                gvIPH.DataBind();

            }

                       

        }


        protected void ddlBuscarIPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscarIPH.SelectedValue == "0")
            {

                gvIPH.DataSourceID = "dsconsultaIPH";
                gvIPH.DataBind();
                gvIPH.Visible = true;



                lblIPH.Visible = false;
                lblFolio.Visible = false;
                lblNombre.Visible = false;
                lblPaterno.Visible = false;
                lblMaterno.Visible = false;
                lblHuellaIPH.Visible = false;
                lblImagenIPH.Visible = false;

                txtIPHBusqIPH.Visible = false;
                txtFolioBusqIPH.Visible = false;
                txtNombreBusqIPH.Visible = false;
                txtPaternoBusqIPH.Visible = false;
                txtMaternoBusqIPH.Visible = false;
                imgBtnHuella.Visible = false;
                fuImagenIPH.Visible = false;
                btnAceptarIPH.Visible = false;


            }


            if(ddlBuscarIPH.SelectedValue == "1" ){

                lblIPH.Visible = true;
                lblFolio.Visible = false;
                lblNombre.Visible = false;
                lblPaterno.Visible = false;
                lblMaterno.Visible = false;
                lblHuellaIPH.Visible = false;
                lblImagenIPH.Visible = false;

                txtIPHBusqIPH.Visible = true;
                txtFolioBusqIPH.Visible = false;
                txtNombreBusqIPH.Visible = false;
                txtPaternoBusqIPH.Visible = false;
                txtMaternoBusqIPH.Visible = false;
                imgBtnHuella.Visible = false;
                fuImagenIPH.Visible = false;
                btnAceptarIPH.Visible = true;


            }


            if (ddlBuscarIPH.SelectedValue == "2")
            {

                lblIPH.Visible = false;
                lblFolio.Visible = true;
                lblNombre.Visible = false;
                lblPaterno.Visible = false;
                lblMaterno.Visible = false;
                lblHuellaIPH.Visible = false;
                lblImagenIPH.Visible = false;

                txtIPHBusqIPH.Visible = false;
                txtFolioBusqIPH.Visible = true;
                txtNombreBusqIPH.Visible = false;
                txtPaternoBusqIPH.Visible = false;
                txtMaternoBusqIPH.Visible = false;
                imgBtnHuella.Visible = false;
                fuImagenIPH.Visible = false;
                btnAceptarIPH.Visible = true;


            }

            if (ddlBuscarIPH.SelectedValue == "3")
            {

                lblIPH.Visible = false;
                lblFolio.Visible = false;
                lblNombre.Visible = true;
                lblPaterno.Visible = true;
                lblMaterno.Visible = true;
                lblHuellaIPH.Visible = false;
                lblImagenIPH.Visible = false;

                txtIPHBusqIPH.Visible = false;
                txtFolioBusqIPH.Visible = false;
                txtNombreBusqIPH.Visible = true;
                txtPaternoBusqIPH.Visible = true;
                txtMaternoBusqIPH.Visible = true;
                imgBtnHuella.Visible = false;
                fuImagenIPH.Visible = false;
                btnAceptarIPH.Visible = true;


            }


            if (ddlBuscarIPH.SelectedValue == "4")
            {

                lblIPH.Visible = false;
                lblFolio.Visible = false;
                lblNombre.Visible = false;
                lblPaterno.Visible = false;
                lblMaterno.Visible = false;
                lblHuellaIPH.Visible = true;
                lblImagenIPH.Visible = false;

                txtIPHBusqIPH.Visible = false;
                txtFolioBusqIPH.Visible = false;
                txtNombreBusqIPH.Visible = false;
                txtPaternoBusqIPH.Visible = false;
                txtMaternoBusqIPH.Visible = false;
                imgBtnHuella.Visible = true;
                fuImagenIPH.Visible = false;
                btnAceptarIPH.Visible = true;


            }


            if (ddlBuscarIPH.SelectedValue == "5")
            {

                lblIPH.Visible = false;
                lblFolio.Visible = false;
                lblNombre.Visible = false;
                lblPaterno.Visible = false;
                lblMaterno.Visible = false;
                lblHuellaIPH.Visible = false;
                lblImagenIPH.Visible = true;

                txtIPHBusqIPH.Visible = false;
                txtFolioBusqIPH.Visible = false;
                txtNombreBusqIPH.Visible = false;
                txtPaternoBusqIPH.Visible = false;
                txtMaternoBusqIPH.Visible = false;
                imgBtnHuella.Visible = false;
                fuImagenIPH.Visible = true;

                btnAceptarIPH.Visible = true;

            }
                        
        }


        public void desactivaControles() {

            lblIPH.Visible = false;
            lblFolio.Visible = false;
            lblNombre.Visible = false;
            lblPaterno.Visible = false;
            lblMaterno.Visible = false;
            lblHuellaIPH.Visible = false;
            lblImagenIPH.Visible = false;

            txtIPHBusqIPH.Visible = false;
            txtFolioBusqIPH.Visible = false;
            txtNombreBusqIPH.Visible = false;
            txtPaternoBusqIPH.Visible = false;
            txtMaternoBusqIPH.Visible = false;
            imgBtnHuella.Visible = false;
            fuImagenIPH.Visible = false;

            btnAceptarIPH.Visible = false;

        }

      
    }
}