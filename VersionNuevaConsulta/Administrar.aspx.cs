using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Administrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_USUARIO"] = Request.QueryString["ID_USUARIO"];
            Session["op"] = Request.QueryString["op"];

            LBLUSUARIO.Text = Session["Us"].ToString();
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            cargarFecha();
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

        protected void cmdUsuario_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Usuarios.aspx?op=Agregar");
        }

        protected void cmdLocalidad_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Domicilio.aspx?op=AgregarLocalidad");
        }

        protected void cmdColonia_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Domicilio.aspx?op=AgregarColonia");
        }

        protected void cmdCalle_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Domicilio.aspx?op=AgregarCalle");
        }
    }
}