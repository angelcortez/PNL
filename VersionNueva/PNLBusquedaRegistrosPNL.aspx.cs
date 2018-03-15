using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class PNLBusquedaRegistrosPNL : System.Web.UI.Page
    {
        Data PGJ = new Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
             if (!Page.IsPostBack)
            {
            Session["op"] = Request.QueryString["op"];
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            }
        }

        protected void BtnBuscar1_Click(object sender, EventArgs e)
        {
            GridView2.DataSourceID = "dsConsultaPersonasTotal";
            GridView2.DataBind();
            GridView2.Visible = true;

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consultó registros de personas no localizadas de años anteriores con los siguientes campos: Nombre = " + txtNombre3.Text + ", Apellido Paterno= " + txtPaterno3.Text + ", Apellido Paterno= "+txtMaterno3.Text, int.Parse(Session["IdModuloBitacora"].ToString()));


        }
    }
}