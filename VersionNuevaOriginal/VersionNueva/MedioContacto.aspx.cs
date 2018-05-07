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
    public partial class MedioContacto : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];  
                Session["op"] = Request.QueryString["op"];
                Session["ID_MEDIO_CONTACTO"] = Request.QueryString["ID_MEDIO_CONTACTO"];

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                if (Session["ID_ESTADO_NUC"] == null)
                {
                    Session["ID_ESTADO_NUC"] = "";
                }
                if (Session["ID_ESTADO_RAC"] == null)
                {
                    Session["ID_ESTADO_RAC"] = "";
                }
                if (Session["ID_ESTADO_NAC"] == null)
                {
                    Session["ID_ESTADO_NAC"] = "";
                }
                if (Session["ID_ESTADO_NUM"] == null)
                {
                    Session["ID_ESTADO_NUM"] = "";
                }

                Session["ID_ESTADO_RAC"].ToString();
                Session["ID_ESTADO_NUC"].ToString();
                Session["ID_ESTADO_NAC"].ToString();
                Session["ID_ESTADO_NUM"].ToString();

                
                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR MEDIO DE CONTACTO";
                    ID_PERSONA.Text = Session["ID_PERSONA"].ToString();
                    try{
                    PGJ.CargaCombo(ddlTipoContacto, "CAT_TIPO_MEDIO_CONTACTO", "ID_TIPO_MEDIO_CONTACTO", "TIPO_MEDIO_CONTACTO");
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("MedioContacto.aspx?&op=Agregar");
                    }
                    //consultaIdMedioContacto();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR MEDIO DE CONTACTO";
                    try{
                    PGJ.CargaCombo(ddlTipoContacto, "CAT_TIPO_MEDIO_CONTACTO", "ID_TIPO_MEDIO_CONTACTO", "TIPO_MEDIO_CONTACTO");
                    cargarMedio();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("MedioContacto.ID_MEDIO_CONTACTO=" + Session["ID_MEDIO_CONTACTO"].ToString() + "&op=Modificar");
                    }
                   // ID_PERSONA.Text = Session["ID_PERSONA"].ToString();
                    
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

        protected void cmdReg_Click1(object sender, EventArgs e)
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

            Response.Redirect("Datos.aspx?ID_PERSONA=" + Session["ID_PERSONA"].ToString() + "&op=Modificar");
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
            if (Session["op"].ToString() == "Agregar")
            {
                PGJ.InsertaMedioContacto(int.Parse(Session["ID_PERSONA"].ToString()), short.Parse(ddlTipoContacto.SelectedValue.ToString()), txtDescripcion.Text, short.Parse(Session["IdMunicipio"].ToString()));
            }
            else if (Session["op"].ToString() == "Modificar")
            {
                PGJ.ActualizarMedioContacto(int.Parse(ID_MEDIO_CONTACTO.Text), short.Parse(ddlTipoContacto.SelectedValue.ToString()), txtDescripcion.Text); 
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

        //void consultaIdMedioContacto()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdMedioContacto", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_MEDIO_CONTACTO.Text = dr["ID_MEDIO_CONTACTO"].ToString();
        //    //}
        //    dr.Close();
        //}

        void cargarMedio()
        {
            SqlCommand sql = new SqlCommand("cargarMedioContacto " + int.Parse(Session["ID_MEDIO_CONTACTO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_PERSONA.Text = dr["ID_PERSONA"].ToString();
                ID_MEDIO_CONTACTO.Text = dr["ID_MEDIO_CONTACTO"].ToString();
                ddlTipoContacto.SelectedValue = dr["ID_TIPO_MEDIO_CONTACTO"].ToString();
                txtDescripcion.Text = dr["MEDIO_CONTACTO"].ToString();          
            }
            dr.Close();
        }

    }
}