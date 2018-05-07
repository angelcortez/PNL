using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class QuienResulteOfendido : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                lblArbol.Text = Session["lblArbol"].ToString();
                Session["IdTipoActor"] = IdTipoActor.Text;

                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["tab"] = Request.QueryString["tab"];
                Session["op"] = Request.QueryString["op"];

                cargarFecha();

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

        void consultaIdPersonaMax()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var fecha = from c in dc.consultaIdPersonaMax(lblResulte.Text, lblOfendido.Text, lblQuien.Text)
                        select c;
            foreach (var propiedad in fecha)
            {
                ID_PERSONA.Text = propiedad.ID_PERSONA.ToString();
            }
        }

        protected void cmdSi_Click(object sender, EventArgs e)
        {
            try
              {
            PGJ.InsertaQuienResulteResponsable(lblResulte.Text, lblOfendido.Text, lblQuien.Text, short.Parse(Session["IdMunicipio"].ToString()));
            consultaIdPersonaMax();
            PGJ.InsertaQuienResulteResponsablePersonaDomicilio(int.Parse(ID_PERSONA.Text), short.Parse(Session["IdMunicipio"].ToString()));
            PGJ.InsertaQuienResulteResponsableCarpetaPersona(int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_PERSONA.Text), 2, short.Parse(Session["IdMunicipio"].ToString()));

            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() );
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() );
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() );
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() );
            }
            else if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }

              }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        protected void cmdNo_Click(object sender, EventArgs e)
        {
          Response.Redirect("Datos.aspx?" + "&op=AgregarOf");
        }

       
    }
}