using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class FormaInicioNum : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["op"] = Request.QueryString["op"];
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            cargarFecha();
            LBLUSUARIO.Text = Session["Us"].ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;

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
        protected void cmdCompa_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(1);
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void cmdEscrito_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(2);
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void ImgSi_Click(object sender, ImageClickEventArgs e)
        {
           try {
            dcOrientacionDataContext validar = new dcOrientacionDataContext();
            int x = 0;

            x = validar.VALIDAR_PGJ_CARPETA_NUM("28", Session["IdMunicipio"].ToString(), Session["IdUnidad"].ToString(), txtNumero.Text, txtAño.Text, 2);
            if (x == 0)
            {
                PGJ.GenerarNC(Session["ID_CARPETA"].ToString(), "NUM", short.Parse(Session["IdMunicipio"].ToString()), txtNumero.Text, txtAño.Text, short.Parse(Session["IdUnidad"].ToString()));
                PGJ.InsertaNUM_Mediacion(Data.NUM, DateTime.Parse(txtFechaInicio.Text), 6, DateTime.Parse(txtFechaInicio.Text), short.Parse(Session["IdUsuario"].ToString()), short.Parse(IdCarpetaInicio.Text), 0, short.Parse(Session["IdMunicipio"].ToString()));
               
                Response.Redirect("Mediacion.aspx");
            }

            else if (x == 1)
            {
                lblError.Text = "EL REGISTRO YA EXISTE";
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
           }
           catch (Exception ex)
           {
               lblError.Text = ex.Message;

           }
        }

        protected void ImgNo_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
        }

       
    }
}