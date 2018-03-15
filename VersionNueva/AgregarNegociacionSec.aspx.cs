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
    public partial class AgregarNegociacionSec : System.Web.UI.Page
    {
        private const string SCRIPT_DOFOCUS =
          @"window.setTimeout('DoFocus()', 1);
                function DoFocus()
                {
                    try {
                        document.getElementById('REQUEST_LASTFOCUS').focus();
                    } catch (ex) {}
                }";
        Data PGJ = new Data();




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HookOnFocus(this.Page as Control);
                ScriptManager.RegisterStartupScript(
                this,
                typeof(Datos),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                //---


                ////TRAER LOS ID QUE SE NECESITAN PARA ALMACENAR LA INFO EN LA TABLA//
                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];

                //TRAE EL USUARIO, PUESTO, UNIDAD Y LA OPERACIÓN. ADEMÁS DE CARGAR LA FECHA ACTUAL// 
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                lblArbol.Text = Session["lblArbol"].ToString();
                ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                cargarFecha();


                if (Session["op"].ToString() == "Agregar")
                {

                    //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                    

                    ////Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();
                    
                    ////Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                    cargarOfendido();

                    lblOperacion.Text = "AGREGAR NEGOCIACIÓN";







                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DATOS DEL PRÓFUGO";


                    //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                    //ID_CARPETA.Text = Session["ID_CARPETA"].ToString();

                    //Session["ID_PERSONA"] = Request.QueryString["ID_PERSONA"];
                    //ID_PERSONA.Text = Session["ID_PERSONA"].ToString();

                    //Session["ID_MUNICIPIO_CARPETA"] = Request.QueryString["ID_MUNICIPIO_CARPETA"];
                    //ID_MUNICIPIO_CARPETA.Text = Session["ID_MUNICIPIO_CARPETA"].ToString();

                    Session["ID_NEGOC_SEC"] = Request.QueryString["ID_NEGOC_SEC"];
                    cargarOfendido();

                    lblOperacion.Text = "MODIFICAR NEGOCIACIÓN";


                    CargarNegociacion();





                }



            }
        }

        void cargarOfendido()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.MarcadorOfendido(int.Parse(ID_CARPETA.Text))
                     select new { c.ID_PERSONA, c.OFENDIDO };
            ddlOfendido.DataSource = im;
            ddlOfendido.DataValueField = "ID_PERSONA";
            ddlOfendido.DataTextField = "OFENDIDO";
            ddlOfendido.DataBind();
        }

        private void HookOnFocus(Control CurrentControl)
        {

            if ((CurrentControl is TextBox) ||
                (CurrentControl is DropDownList) ||
                (CurrentControl is CheckBox) ||
                (CurrentControl is ListBox) ||
                (CurrentControl is Button) ||
                (CurrentControl is RadioButton))

                (CurrentControl as WebControl).Attributes.Add("onfocus", "try{document.getElementById('__LASTFOCUS').value=this.id}catch(e) {}");

            if (CurrentControl.HasControls())

                foreach (Control CurrentChildControl in CurrentControl.Controls)
                    HookOnFocus(CurrentChildControl);
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

        void CargarNegociacion()
        {
            SqlCommand sql = new SqlCommand("CargarNegociacionSec " + int.Parse(Session["ID_NEGOC_SEC"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();



                ddlOfendido.SelectedValue = dr["ID_PERSONA"].ToString();
                txtFechaNegociacion.Text = dr["FECHA_NEGOC"].ToString();
                txtHoraNegociacion.Text = dr["HORA_NEGOC"].ToString();
                txtPesosExig.Text = dr["PESOS_EXIG"].ToString();
                txtDolaresExig.Text = dr["DOLARES_EXIG"].ToString();
                txtEspecieExig.Text = dr["ESPECIE_EXIG"].ToString();
                txtPesosPagados.Text = dr["PESOS_PAG"].ToString();
                txtDolaresPagados.Text = dr["DOLARES_PAG"].ToString();
                txtEspeciePagada.Text = dr["ESPECIE_PAG"].ToString();
                txtFechaDelPago.Text = dr["FECHA_PAGO"].ToString();
                txtHoraDelPago.Text = dr["HORA_PAGO"].ToString();



            }
            dr.Close();

        }



        protected void cmdGu_Click(object sender, EventArgs e)
        {
            if (Session["op"].ToString() == "Agregar")
            {
                try
                {
                    PGJ.InsertaNegocSec(int.Parse(ddlOfendido.SelectedValue.ToString()), int.Parse(ID_CARPETA.Text), int.Parse(Session["IdMunicipio"].ToString()), DateTime.Parse(txtFechaNegociacion.Text), txtHoraNegociacion.Text, int.Parse(txtPesosExig.Text), int.Parse(txtDolaresExig.Text), txtEspecieExig.Text, int.Parse(txtPesosPagados.Text), int.Parse(txtDolaresPagados.Text), txtEspeciePagada.Text, DateTime.Parse(txtFechaDelPago.Text), txtHoraDelPago.Text);
                    cmdGu.Visible = false;
                    lblEstatus1.Text = "DATOS GUARDADOS";
                    DesactivarControles();

                    


                }
                catch (Exception ex)
                {

                }


            }
            else if (Session["op"].ToString() == "Modificar")
            {
                try
                {
                    PGJ.ActualizaNegocSec(int.Parse(Session["ID_NEGOC_SEC"].ToString()), DateTime.Parse(txtFechaNegociacion.Text), txtHoraNegociacion.Text, int.Parse(txtPesosExig.Text), int.Parse(txtDolaresExig.Text), txtEspecieExig.Text, int.Parse(txtPesosPagados.Text), int.Parse(txtDolaresPagados.Text), txtEspeciePagada.Text, DateTime.Parse(txtFechaDelPago.Text), txtHoraDelPago.Text);
                    cmdGu.Visible = false;
                    lblEstatus1.Text = "DATOS GUARDADOS";
                    DesactivarControles();



                }
                catch (Exception ex)
                {

                }


            }
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            if (lblArbol.Text == "8")
            {
                Response.Redirect("NUC_SECUESTRO.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }
        }

        void DesactivarControles()
        {
            txtDolaresExig.Enabled = false;
            txtDolaresPagados.Enabled = false;
            txtEspecieExig.Enabled = false;
            txtEspeciePagada.Enabled = false;
            txtFechaDelPago.Enabled = false;
            txtFechaNegociacion.Enabled = false;
            txtHoraDelPago.Enabled = false;
            txtHoraNegociacion.Enabled = false;
            txtPesosExig.Enabled = false;
            txtPesosPagados.Enabled = false;
            
        }


    }
}