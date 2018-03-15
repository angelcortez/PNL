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
    public partial class consultahomicidios : System.Web.UI.Page
    {
        Data PGJ = new Data();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                cargarFecha();
                //PGJ.ConnectServidorCentral();

                //PGJ.CatalogoServidoresAdmin(ddlServidores, "CAT_SERVIDORES", "ID_SERVIDOR", "SERVIDOR");

                txtFechaFin.Text = DateTime.Today.ToString();

                lblFechaInicio.Visible = true;
                txtFechaInicio.Visible = true;

                lblFechaFin.Visible = true;
                txtFechaFin.Visible = true;

                //lblModalidad.Visible = true;


                cmdAceptar.Visible = true;

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

        protected void cmdUsuario_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Usuarios.aspx?op=Agregar");
        }

        protected void cmdLocalidad_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Domicilio.aspx?op=AgregarLocalidad");
        }

        protected void cmdColonia_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Domicilio.aspx?op=AgregarColonia");
        }

        protected void cmdCalle_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("Domicilio.aspx?op=AgregarCalle");
        }

        protected void cmdCarpeta_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("CarpetaAdmin.aspx");
        }

        protected void cmdUnidad_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("UnidadesAdmin.aspx");
        }

        protected void cmdUsuario_Click1(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("UsuariosAdmin.aspx");
        }

        protected void cmdModulos_Click(object sender, EventArgs e)
        {
            Session["op"] = " ";
            Response.Redirect("ModulosAdmin.aspx");
        }

        protected void cmdConectar_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    //PGJ.ConnectServer();
            //    PGJ.ConnectServidorCentral();
            //    SqlCommand conn = new SqlCommand("SELECT IP_SERVIDOR,ID_MNCPIO FROM CAT_SERVIDORES WHERE ID_SERVIDOR = " + ddlServidores.SelectedValue + " AND ACTIVO = 1", Data.CnnAdminCentral);
            //    SqlDataReader read = conn.ExecuteReader();

            //    if (read.HasRows)
            //    {
            //        read.Read();
            //        Session["IP_SERVIDOR"] = read["IP_SERVIDOR"].ToString();
            //        Session["ID_MNCPIO"] = read["ID_MNCPIO"].ToString();
            //    }

            //    read.Dispose();

            //    lblip.Text = Session["IP_SERVIDOR"].ToString();
            //    lblMunicipio.Text = Session["ID_MNCPIO"].ToString();


            //    PGJ.ConnectServidorAdmin(Session["IP_SERVIDOR"].ToString());

            //    lblFechaInicio.Visible = true;
            //    txtFechaInicio.Visible = true;

            //    lblFechaFin.Visible = true;
            //    txtFechaFin.Visible = true;

            //    lblModalidad.Visible = true;
              

            //    cmdAceptar.Visible = true;


                

//            }
//            catch (Exception ex)
//            {


//                lblFechaInicio.Visible = false;
//                txtFechaInicio.Visible = false;
//                lblFechaFin.Visible = false;
//                txtFechaFin.Visible = false;
//                lblModalidad.Visible = false;
              
//                cmdAceptar.Visible = false;
//                cmdExportarExcel.Visible = false;
//                PanelHomicidios.Visible = false;


//                //Colocar Alerta 
//                string script = @"<script type='text/javascript'>
//                            alert('NO ES POSIBLE CONECTARSE AL SERVIDOR. INTENTELO NUEVAMENTE');
//                                   </script>";
//                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//            }


        }

        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            //dsConsultaHomicidios.ConnectionString = "Data Source=" + Session["IP_SERVIDOR"].ToString() + ";Initial Catalog=PNL_NSJP2;User ID=PGJNSJP;Password=Usuario.25";

            Repeater1.DataSourceID = "dsConsultaHomicidios";
            Repeater1.DataBind();

            cmdExportarExcel.Visible = true;
            PanelHomicidios.Visible = true;
            
        
        }

        protected void cmdExportarExcel_Click(object sender, EventArgs e)
        {
            

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