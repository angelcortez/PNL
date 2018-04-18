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
using Subgurim.Controles;

namespace AtencionTemprana
{
    public partial class RazonAvisoSinDetenido : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                lblArbol.Text = Session["lblArbol"].ToString();
                Session["op"] = Request.QueryString["op"];
                cargarFecha();
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                PGJ.CargaCombo(ddlCorporacion, "CAT_CORPORACION", "ID_CORPORACION", "CORPORACION");
                PGJ.CargaCombo(ddlHospital, "CAT_HOSPITAL", "ID_HOSPITAL", "HOSPITAL");

                Session["ID_RAZON_AVISO"] = Request.QueryString["ID_RAZON_AVISO"];

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

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR RAZON DE AVISO";
                    ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR RAZON DE AVISO";
                    cargarRazon();


                    if (ddlHospital.SelectedValue == "0")
                    {
                        rbAvisa.SelectedValue = "2";
                        ddlHospital.Enabled = false;
                        ddlCorporacion.Enabled = true;
                    }
                    else if (ddlCorporacion.SelectedValue == "0")
                    {
                        rbAvisa.SelectedValue = "1";
                        ddlCorporacion.Enabled = false;
                        ddlHospital.Enabled = true;
                    }

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

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() + "&tab=1");
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() + "&tab=1");
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() + "&tab=1");
            }
            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() + "&tab=1");
            }
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            
            if (Session["op"].ToString() == "Agregar")
            {
                

                if (rbAvisa.SelectedValue=="1")
                {
                    PGJ.InsertaRazonAviso(int.Parse(ID_CARPETA.Text), short.Parse(ddlHospital.SelectedValue.ToString()), 0);

                }
                else if (rbAvisa.SelectedValue == "2")
                {
                    PGJ.InsertaRazonAviso(int.Parse(ID_CARPETA.Text), 0, short.Parse(ddlCorporacion.SelectedValue.ToString()));
                }
              

            }
            else if (Session["op"].ToString() == "Modificar")
            {
                if (rbAvisa.SelectedValue == "1")
                {
                    PGJ.ActualizaRazonAviso(int.Parse(IdRazon.Text), short.Parse(ddlHospital.SelectedValue.ToString()), 0);

                }
                else if (rbAvisa.SelectedValue == "2")
                {
                    PGJ.ActualizaRazonAviso(int.Parse(IdRazon.Text), 0, short.Parse(ddlCorporacion.SelectedValue.ToString()));
                }
            }

            lblEstatus.Text = "DATOS GUARDADOS";
            cmdGuardar.Enabled = false;
        }

        protected void rbAvisa_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (rbAvisa.SelectedValue == "1")
            {
                ddlHospital.Enabled = true;
                ddlCorporacion.Enabled = false;
            }
            else if (rbAvisa.SelectedValue == "2")
            {
                ddlCorporacion.Enabled = true;
                ddlHospital.Enabled = false;
            }
        }

        void cargarRazon()
        {
            SqlCommand sql = new SqlCommand("cargarRazonAviso " + int.Parse(Session["ID_RAZON_AVISO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                IdRazon.Text = dr["ID_RAZON_AVISO"].ToString();



                ddlHospital.SelectedValue = dr["ID_HOSPITAL"].ToString();
                ddlCorporacion.SelectedValue = dr["ID_CORPORACION"].ToString();



            }
            dr.Close();
        }



    }
}