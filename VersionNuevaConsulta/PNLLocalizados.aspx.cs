using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;


namespace AtencionTemprana
{
    public partial class PNLLocalizados : System.Web.UI.Page
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

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

            ConteoOfendidosTotal();
            ConteoVivos();
            ConteoMuertos();
            GridView2.DataSourceID = "dsConsultaPersonasTotal";
            GridView2.DataBind();
            GridView2.Visible = true;


          
           
            LblOfendido2.Visible = true;
          
            LblTotalSinRegistro.Visible = true;
            LblTotalSinCapturar.Visible = true;
            TotalSinRegistro();


            lblNombre3.Visible = true;
            txtNombre3.Visible = true;
            lblPaterno3.Visible = true;
            txtPaterno3.Visible = true;
            lblMaterno3.Visible = true;
            txtMaterno3.Visible = true;
            BtnBuscar1.Visible = true;

            Repeater1.DataSourceID = "dsConsultaHomicidios";
            Repeater1.DataBind();

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consultó registros de personas localizadas", int.Parse(Session["IdModuloBitacora"].ToString()));


            cmdExportarExcel.Visible = true;
            PanelHomicidios.Visible = false;
        }



        void ConteoOfendidosTotal()
        {
            SqlCommand sql = new SqlCommand("ConteoOfendidosCapturados  ", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                LblResultadoOfendidos.Text = dr["CONTEOCAPTURADOS"].ToString();

            }
            dr.Close();

        }

        void ConteoVivos()
        {
            SqlCommand sql = new SqlCommand("ConteoOfendidosVivos  ", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                LblResultadoVivos.Text = dr["CONTEOVIVOS"].ToString();

            }
            dr.Close();

        }

        void ConteoMuertos()
        {
            SqlCommand sql = new SqlCommand("ConteoOfendidosMuertos  ", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                LblResultadoMuertos.Text = dr["CONTEOMUERTOS"].ToString();

            }
            dr.Close();

        }


        void ConteoCarpetasTotal()
        {


            SqlCommand sql = new SqlCommand("PNL_Conteo_Carpetas_TOTAL ", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                LblTotalCarpetas.Text = dr["TOTALCARPETAS"].ToString();

            }
            dr.Close();


        }

        void ConteoCarpetasPNL()
        {

            SqlCommand sql = new SqlCommand("PNL_Conteo_Carpetas_PNL ", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                LblPNL.Text = dr["TOTALCARPETASPNL"].ToString();

            }
            dr.Close();

        }

        void ConteoCarpetasPIL()
        {

            SqlCommand sql = new SqlCommand("PNL_Conteo_Carpetas_PIL ", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                LblPIL.Text = dr["TOTALCARPETASPIL"].ToString();

            }
            dr.Close();

        }

        void ConteoCarpetasSustraccion()
        {

            SqlCommand sql = new SqlCommand("PNL_Conteo_Carpetas_Sustraccion ", Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                LblSustraccion.Text = dr["CARPETASTOTALSUSTRACCION"].ToString();

            }
            dr.Close();

        }

       

        void ConteoCarpetasOtrosDelitos()
        {

            int TotalGeneral;
            int PNL;
            int PIL;
            int Sustraccion;
           
            int SumaTotales;

            int TotalOtrosDelitos;


            TotalGeneral = int.Parse(LblTotalCarpetas.Text);
            PNL = int.Parse(LblPNL.Text);
            PIL = int.Parse(LblPIL.Text);
            Sustraccion = int.Parse(LblSustraccion.Text);
          
            SumaTotales = PNL + PIL + Sustraccion;
            TotalOtrosDelitos = TotalGeneral - SumaTotales;


            LblOtrosDelitos.Text = TotalOtrosDelitos.ToString();




        }







        protected void BtnBuscar0_Click(object sender, EventArgs e)
        {
           

            LblOfendido2.Visible = true;
        }

        protected void BtnBuscar1_Click(object sender, EventArgs e)
        {


                GridView2.DataSourceID = "dsConsultaPersonasUnidadNombreSolamenteDos";
                GridView2.DataBind();


                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consultó registros de personas localizadas con los siguientes campos: Nombre= "+txtNombre3.Text+", Apellido paterno "+txtPaterno3.Text+", Apellido materno "+txtMaterno3.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

        }

        

        

        

        protected void BtnBuscar2_Click(object sender, EventArgs e)
        {
            GridView2.DataSourceID = "dsConsultaPersonasNucUnidadEstatus";
            GridView2.DataBind();
            GridView2.Visible = true;
        }


        public void TotalSinRegistro()
        {
            int Vivos;
            int Muertos;
            int Total1;
            int TotalGeneral;


            Vivos = int.Parse(LblResultadoVivos.Text);
            Muertos = int.Parse(LblResultadoMuertos.Text);
            Total1 = Vivos + Muertos;
            TotalGeneral = int.Parse(LblResultadoOfendidos.Text) - Total1;


            LblTotalSinRegistro.Text = TotalGeneral.ToString();

        }

        protected void BuscarSinDelito_Click(object sender, EventArgs e)
        {
           
            ConteoCarpetasTotal();
            ConteoCarpetasPNL();
            ConteoCarpetasPIL();
            ConteoCarpetasSustraccion();
          
            ConteoCarpetasOtrosDelitos();
           
            LblOtrosDelitos.Visible = true;
            Label1.Visible = true;
            LblSustraccion.Visible = true;
            LblOfendido7.Visible = true;
            LblPIL.Visible = true;
            LblOfendido6.Visible = true;
            LblPNL.Visible = true;
            LblOfendido5.Visible = true;
            LblTotalCarpetas.Visible = true;
            LblOfendido4.Visible = true;
        }

        protected void cmdExportarExcel_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "El usuario exportó el reporte generado a excel", int.Parse(Session["IdModuloBitacora"].ToString()));


            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            Repeater1.EnableViewState = false;
            
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(Repeater1);
            
            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            //Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment;filename=ReportePNL.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();


        }



    }
}