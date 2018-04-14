using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;

namespace AtencionTemprana
{
    public partial class Alias : System.Web.UI.Page
    {
        Data PGJ = new Data();
        public static string tipoActor = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tipoActor = Request.QueryString["tipoActor"];
                Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                Session["op"] = Request.QueryString["op"];
               
                
                Session["ID_ALIAS"] = Request.QueryString["ID_ALIAS"];
                
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                cargarFecha();



                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR ALIAS";
                    ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    //consultaIdAlias();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR ALIAS";
                    ID_PERSONA.Text = Session["ID_PERSONA"].ToString();


                    cargarAlias();
                }
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

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
             try
            {

                if (Session["op"].ToString() == "Agregar")
                {
                    PGJ.InsertaAlias(int.Parse(Session["ID_PERSONA"].ToString()), txtAlias.Text, short.Parse(Session["IdMunicipio"].ToString()));
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    PGJ.ActualizarAlias(int.Parse(ID_ALIAS.Text), txtAlias.Text);
                }

                lblEstatus.Text = "DATOS GUARDADOS";
                cmdGuardar.Enabled = false;
            }
             catch (Exception ex)
             {
                 lblEstatus.Text = ex.Message;
                 lblEstatus1.Text = "INTENTELO NUEVAMENTE";
             }
        }

        protected void cmdReg_Click1(object sender, EventArgs e)
        {
            try
            {
                //policia investigador 
                if (Session["ID_PUESTO"].ToString() == "17")
                {
                    Response.Redirect("DatosDetenidoPI.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=Modificar");
                }
                else if (Session["ID_PUESTO"].ToString() == "8")
                {
                    Response.Redirect("DatosDetenidoPI.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=Modificar");
                }

                Session["op"] = " ";

                if (tipoActor == "ofendido")
                {
                    Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=ModificarOf");
                }
                else if (tipoActor == "testigo")
                {
                    Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=ModificarTes");
                }
                else if (tipoActor == "denunciante")
                {
                    Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=Modificar");
                }
                else if (tipoActor == "imputado")
                {
                    Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=ModificarPre");
                }
                //Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=Modificar");
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

        //void consultaIdAlias()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdAlias", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_ALIAS.Text = dr["ID_ALIAS"].ToString();
        //    //}
        //    dr.Close();
        //}


        void cargarAlias()
        {
            SqlCommand sql = new SqlCommand("cargarAlias " + int.Parse(Session["ID_ALIAS"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_PERSONA.Text = dr["ID_PERSONA"].ToString();
                ID_ALIAS.Text = dr["ID_ALIAS"].ToString();
                txtAlias.Text = dr["ALIAS"].ToString();            
            }
            dr.Close();
        }

    }
}