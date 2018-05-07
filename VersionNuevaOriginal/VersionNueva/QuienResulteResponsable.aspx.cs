using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class QuienResulteResponsable : System.Web.UI.Page
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
                //consultaIdPersona();
                //consultaIdCarpetaPersona();
                //consultaIdPersonaDomicilio();
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
            var fecha = from c in dc.consultaIdPersonaMax(lblResulte.Text, lblResponsable.Text, lblQuien.Text)
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
            PGJ.InsertaQuienResulteResponsable(lblResulte.Text, lblResponsable.Text, lblQuien.Text, short.Parse(Session["IdMunicipio"].ToString()));
            consultaIdPersonaMax();
            PGJ.InsertaQuienResulteResponsablePersonaDomicilio(int.Parse(ID_PERSONA.Text), short.Parse(Session["IdMunicipio"].ToString()));
            PGJ.InsertaQuienResulteResponsableCarpetaPersona(int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(ID_PERSONA.Text), 3, short.Parse(Session["IdMunicipio"].ToString()));
            
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
            
            Response.Redirect("Datos.aspx?" + "&op=AgregarPre");
        }

        //void consultaIdPersona()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdPersona", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_PERSONA.Text = dr["ID_PERSONA"].ToString();
        //    //}
        //    dr.Close();
        //}

        //void consultaIdCarpetaPersona()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdCarpetaPersona", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_PERSONA_CARPETA.Text = dr["ID_PERSONA_CARPETA"].ToString();
        //    //}
        //    dr.Close();
        //}

        //void consultaIdPersonaDomicilio()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdPersonaDomicilio", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_DOMICILIO.Text = dr["ID_DOMICILIO"].ToString();
        //    //}
        //    dr.Close();
        //}

    }
}