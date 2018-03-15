using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AtencionTemprana
{
    public partial class FormaInicioNac : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["op"] = Request.QueryString["op"];
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            Session["lblArbol"] = lblArbol.Text;
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

        protected void ImgSi_Click(object sender, ImageClickEventArgs e)
        {
            string Sql = "Set DateFormat dmy exec InsertaNAC " + Session["IdUnidad"].ToString() + ",''," + "1" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "0" + "," + short.Parse(Session["IdMunicipio"].ToString());

            SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            DataSet dsCarpeta = new DataSet();
            daCarpeta.Fill(dsCarpeta, "Carpeta");
            foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            {
                Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
                Session["ID_ESTADO_NAC"] = 1;
            }
            daCarpeta.Dispose();
            dsCarpeta.Dispose();

            Session["op"] = " ";
            Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NAC=" + 1);  
        }
    }
}