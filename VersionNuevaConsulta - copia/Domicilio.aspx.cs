using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Domicilio : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //Session["ID_USUARIO"] = Request.QueryString["ID_USUARIO"];
                Session["op"] = Request.QueryString["op"];

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                cargarFecha();
                PGJ.CargaCombo(ddlPais, "Cat_Pais", "Id_Pais", "Pais");
                PGJ.CargaCombo(ddlPaisCol, "Cat_Pais", "Id_Pais", "Pais");
                PGJ.CargaCombo(ddlPaisCalle, "Cat_Pais", "Id_Pais", "Pais");


                if (Session["op"].ToString() == "AgregarLocalidad")
                {
                    lblOperacion.Text = "AGREGAR LOCALIDAD";
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;


                }
                else if (Session["op"].ToString() == "AgregarColonia")
                {
                    lblOperacion.Text = "AGREGAR COLONIA";
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;

                }
                else if (Session["op"].ToString() == "AgregarCalle")
                {
                    lblOperacion.Text = "AGREGAR CALLE";
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
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
            if (Session["op"].ToString() == "AgregarLocalidad")
            {
                PGJ.InsertaLocalidad(short.Parse(ddlMunicipio.SelectedValue.ToString()), short.Parse(ddlEstado.SelectedValue.ToString()), short.Parse(ddlPais.SelectedValue.ToString()), txtLocalidad.Text);

            }

            else if (Session["op"].ToString() == "AgregarColonia")
            {
                PGJ.InsertaColonia(short.Parse(ddlLocalidadCol.SelectedValue.ToString()), short.Parse(ddlMunicipioCol.SelectedValue.ToString()), short.Parse(ddlEstadoCol.SelectedValue.ToString()), short.Parse(ddlPaisCol.SelectedValue.ToString()), txtColonia.Text);


            }
            else if (Session["op"].ToString() == "AgregarCalle")
            {
                PGJ.InsertaCalle(short.Parse(ddlLocalidadCalle.SelectedValue.ToString()), short.Parse(ddlMunicipioCalle.SelectedValue.ToString()), short.Parse(ddlEstadoCalle.SelectedValue.ToString()), short.Parse(ddlPaisCalle.SelectedValue.ToString()), txtCalle.Text);

            }

            lblEstatus.Text = "DATOS GUARDADOS";
            cmdGuardar.Enabled = false;


        }

        void consultaPaisEstado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEstado.DataSource = estado;
            ddlEstado.DataValueField = "ID_ESTDO";
            ddlEstado.DataTextField = "ESTDO";
            ddlEstado.DataBind();
        }

        void consultaPaisEstadoCol()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS_COL"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEstadoCol.DataSource = estado;
            ddlEstadoCol.DataValueField = "ID_ESTDO";
            ddlEstadoCol.DataTextField = "ESTDO";
            ddlEstadoCol.DataBind();
        }

        void consultaPaisEstadoCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaPaisEstado(short.Parse(Session["ID_PAIS_CALLE"].ToString()))
                         select new { c.ID_ESTDO, c.ESTDO };
            ddlEstadoCalle.DataSource = estado;
            ddlEstadoCalle.DataValueField = "ID_ESTDO";
            ddlEstadoCalle.DataTextField = "ESTDO";
            ddlEstadoCalle.DataBind();
        }

        void consultaEstadoMunicipio()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS"].ToString()), short.Parse(Session["ID_ESTADO"].ToString()))
                            select new { c.ID_MNCPIO, c.MNCPIO };
            ddlMunicipio.DataSource = municipio;
            ddlMunicipio.DataValueField = "ID_MNCPIO";
            ddlMunicipio.DataTextField = "MNCPIO";
            ddlMunicipio.DataBind();
        }
        void consultaEstadoMunicipioCol()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS_COL"].ToString()), short.Parse(Session["ID_ESTADO_COL"].ToString()))
                            select new { c.ID_MNCPIO, c.MNCPIO };
            ddlMunicipioCol.DataSource = municipio;
            ddlMunicipioCol.DataValueField = "ID_MNCPIO";
            ddlMunicipioCol.DataTextField = "MNCPIO";
            ddlMunicipioCol.DataBind();
        }

        void consultaEstadoMunicipioCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var municipio = from c in dc.consultaEstadoMunicipio(short.Parse(Session["ID_PAIS_CALLE"].ToString()), short.Parse(Session["ID_ESTADO_CALLE"].ToString()))
                            select new { c.ID_MNCPIO, c.MNCPIO };
            ddlMunicipioCalle.DataSource = municipio;
            ddlMunicipioCalle.DataValueField = "ID_MNCPIO";
            ddlMunicipioCalle.DataTextField = "MNCPIO";
            ddlMunicipioCalle.DataBind();
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_PAIS"] = ddlPais.SelectedValue.ToString();
            consultaPaisEstado();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO"] = ddlEstado.SelectedValue.ToString();
            consultaEstadoMunicipio();
        }

        protected void cmdReg_Click1(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Administrar.aspx");
        }

        protected void ddlPaisCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_PAIS_COL"] = ddlPaisCol.SelectedValue.ToString();
            consultaPaisEstadoCol();
        }

        protected void ddlEstadoCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO_COL"] = ddlEstadoCol.SelectedValue.ToString();
            consultaEstadoMunicipioCol();
        }



        protected void ddlMunicipioCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MUNICIPIO_COL"] = ddlMunicipioCol.SelectedValue.ToString();
            consultaMunicipioLocalidad();
        }

        void consultaMunicipioLocalidad()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var localidad = from c in dc.consultaMunicipioLocalidad(short.Parse(Session["ID_PAIS_COL"].ToString()), short.Parse(Session["ID_ESTADO_COL"].ToString()), short.Parse(Session["ID_MUNICIPIO_COL"].ToString()))
                            select new { c.ID_LCLDD, c.LCLDD };
            ddlLocalidadCol.DataSource = localidad;
            ddlLocalidadCol.DataValueField = "ID_LCLDD";
            ddlLocalidadCol.DataTextField = "LCLDD";
            ddlLocalidadCol.DataBind();
        }

        void consultaMunicipioLocalidadCalle()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var localidad = from c in dc.consultaMunicipioLocalidad(short.Parse(Session["ID_PAIS_CALLE"].ToString()), short.Parse(Session["ID_ESTADO_CALLE"].ToString()), short.Parse(Session["ID_MUNICIPIO_CALLE"].ToString()))
                            select new { c.ID_LCLDD, c.LCLDD };
            ddlLocalidadCalle.DataSource = localidad;
            ddlLocalidadCalle.DataValueField = "ID_LCLDD";
            ddlLocalidadCalle.DataTextField = "LCLDD";
            ddlLocalidadCalle.DataBind();
        }

        protected void ddlPaisCalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_PAIS_CALLE"] = ddlPaisCalle.SelectedValue.ToString();
            consultaPaisEstadoCalle();
        }

        protected void ddlEstadoCalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_ESTADO_CALLE"] = ddlEstadoCalle.SelectedValue.ToString();
            consultaEstadoMunicipioCalle();
        }

        protected void ddlMunicipioCalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MUNICIPIO_CALLE"] = ddlMunicipioCalle.SelectedValue.ToString();
            consultaMunicipioLocalidadCalle();
        }
    }
}