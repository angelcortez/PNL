using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class DefensorPublico : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblArbol.Text = Session["lblArbol"].ToString();

                Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];

                Session["tab"] = Request.QueryString["tab"];
                Session["op"] = Request.QueryString["op"];
                

                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();

                
                // PGJ.CargaCombo(ddlPais, "Cat_Pais", "Id_Pais", "Pais");


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
                
                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();
                cargarImputado();
                SolicitarNUC();

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

        void cargarImputado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.ConsultaImputadoDefensor(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.IMPUTADO };
            ddlImputado.DataSource = im;
            ddlImputado.DataValueField = "ID_PERSONA";
            ddlImputado.DataTextField = "IMPUTADO";
            ddlImputado.DataBind();
        }
      
        void SolicitarNUC()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var nuc = from c in dc.SolicitarNuc(int.Parse(ID_CARPETA.Text))
                      select c;
            foreach (var propiedad in nuc)
            {
                LBLNUC.Text = propiedad.NUC.ToString();
            }

        }


        protected void cmdSi_Click(object sender, EventArgs e)
        {
            try
            {
            PGJ.InsertaDefensor(int.Parse(ID_CARPETA.Text), int.Parse(ddlImputado.SelectedValue.ToString()), lblDefensor.Text, lblPublico.Text, lblAsignar.Text, 1, 6, 0, "", "", 31, 1, 28, 41, 1, 28, 41, 388, 1042, 1454, 1454, 1454, "", "", "", short.Parse(Session["IdMunicipio"].ToString()));
           
            PGJ.InsertaDefensorTorre(int.Parse(ID_CARPETA.Text), LBLNUC.Text, int.Parse(ddlImputado.SelectedValue.ToString()), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(Session["IdUnidad"].ToString()));

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
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        protected void cmdNo_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Defensor.aspx?op=Agregar");
        }

    }
}