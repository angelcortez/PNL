using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AtencionTemprana
{
    public partial class FormaInicioNuc : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["op"] = Request.QueryString["op"];
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
            Session["lblArbol"] = lblArbol.Text;
            cargarFecha();
            LBLUSUARIO.Text = Session["Us"].ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;

            lblMensajeSession.Text = Session["IdTipoDQ"].ToString();


            //INICIO-ocultando el menu cuando inicia carpeta

            HyperLink linkRac = this.Page.Master.FindControl("hRac") as HyperLink;
            linkRac.Text = "";
            linkRac.Visible = false;
            linkRac.Enabled = false;
            linkRac.NavigateUrl = "#";

            HyperLink linkDerivada = this.Page.Master.FindControl("hDerivada") as HyperLink;
            linkDerivada.Text = "";
            linkDerivada.Visible = false;
            linkDerivada.Enabled = false;
            linkDerivada.NavigateUrl = "#";

            HyperLink linkNuc = this.Page.Master.FindControl("hlSec") as HyperLink;
            linkNuc.Text = "";
            linkNuc.Visible = false;
            linkNuc.Enabled = false;
            linkNuc.NavigateUrl = "#";

            HyperLink linkEstadistica = this.Page.Master.FindControl("hEstadistica") as HyperLink;
            linkEstadistica.Text = "";
            linkEstadistica.Visible = false;
            linkEstadistica.Enabled = false;
            linkEstadistica.NavigateUrl = "#";

            HyperLink linkBusqueda = this.Page.Master.FindControl("hBusquedaPersonasNSJP") as HyperLink;
            linkBusqueda.Text = "";
            linkBusqueda.Visible = false;
            linkBusqueda.Enabled = false;
            linkBusqueda.NavigateUrl = "#";

            HyperLink linkBusquedaPNL = this.Page.Master.FindControl("hBusquedaPNL") as HyperLink;
            linkBusquedaPNL.Text = "";
            linkBusquedaPNL.Visible = false;
            linkBusquedaPNL.Enabled = false;
            linkBusquedaPNL.NavigateUrl = "#";

            HyperLink linkEstadisticaNUC = this.Page.Master.FindControl("hEstadisticaNUC") as HyperLink;
            linkEstadisticaNUC.Text = "";
            linkEstadisticaNUC.Visible = false;
            linkEstadisticaNUC.Enabled = false;
            linkEstadisticaNUC.NavigateUrl = "#";

            HyperLink linkReportes = this.Page.Master.FindControl("HyperLinkEsta") as HyperLink;
            linkReportes.Text = "";
            linkReportes.Visible = false;
            linkReportes.Enabled = false;
            linkReportes.NavigateUrl = "#";

            //HyperLink linkCS = this.Page.Master.FindControl("hCerrarSesion") as HyperLink;
            //linkCS.Text = "";
            //linkCS.Visible = false;
            //linkCS.Enabled = false;
            //linkCS.NavigateUrl = "#";

            //FIN-ocultando el menu cuando inicia carpeta

        }

        protected void cmdCompa_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(1);
            Panel1.Visible = true;
            Panel2.Visible = false;
        }



        protected void cmdEscrito_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(2);
            Data.IdCarpeta = 0;
            Panel1.Visible = false;
            Panel2.Visible = false;


            string Sql = "Set DateFormat dmy exec InsertaNUCUnidad2 " + "''," + "10" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "0" + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + short.Parse(Session["IdUnidad"].ToString()) + "," + int.Parse(lblMensajeSession.Text);

            SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            DataSet dsCarpeta = new DataSet();
            daCarpeta.Fill(dsCarpeta, "Carpeta");
            foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            {
                Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
                Session["ID_ESTADO_NUC"] = 10;
            }
            daCarpeta.Dispose();
            dsCarpeta.Dispose();

            //Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);   
            Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);  
            if (IdCarpetaInicio.Text == "5")
            {
                Response.Redirect("WDatoIncompetencia.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }
            else
            {
                Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
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

        protected void ImgSi_Click(object sender, ImageClickEventArgs e)
        {
            string Sql = "Set DateFormat dmy exec InsertaNUCUnidad2 " + "''," + "10" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "1" + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + short.Parse(Session["IdUnidad"].ToString()) + "," + int.Parse(lblMensajeSession.Text);

            SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            DataSet dsCarpeta = new DataSet();
            daCarpeta.Fill(dsCarpeta, "Carpeta");
            foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            {
                Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
                Session["ID_ESTADO_NUC"] = 10;
            }
            daCarpeta.Dispose();
            dsCarpeta.Dispose();

            Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10); 
            if (IdCarpetaInicio.Text == "5")
            {
                Response.Redirect("WDatoIncompetencia.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }
            else
            {
                Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }

            //Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10); 

            //string Sql = "Set DateFormat dmy exec InsertaRAC " + "''," + "10" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "1" + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + short.Parse(Session["IdUnidad"].ToString());

            //SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            //DataSet dsCarpeta = new DataSet();
            //daCarpeta.Fill(dsCarpeta, "Carpeta");
            //foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            //{
            //    Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
            //    Session["ID_ESTADO_NUC"] = 10;
            //}
            //daCarpeta.Dispose();
            //dsCarpeta.Dispose();

            //Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);      
            
        }

        protected void ImgNo_Click(object sender, ImageClickEventArgs e)
        {

            string Sql = "Set DateFormat dmy exec InsertaNUCUnidad2 " + "''," + "10" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "0" + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + short.Parse(Session["IdUnidad"].ToString()) + "," + int.Parse(lblMensajeSession.Text);

            SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            DataSet dsCarpeta = new DataSet();
            daCarpeta.Fill(dsCarpeta, "Carpeta");
            foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            {
                Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
                Session["ID_ESTADO_NUC"] = 10;
            }
            daCarpeta.Dispose();
            dsCarpeta.Dispose();

            //Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);   
            Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);  
            if (IdCarpetaInicio.Text == "5")
            {
                Response.Redirect("WDatoIncompetencia.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }
            else
            {
                Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }


            //string Sql = "Set DateFormat dmy exec InsertaRAC " + "''," + "10" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "0" + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + short.Parse(Session["IdUnidad"].ToString());

            //SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            //DataSet dsCarpeta = new DataSet();
            //daCarpeta.Fill(dsCarpeta, "Carpeta");
            //foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            //{
            //    Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
            //    Session["ID_ESTADO_NUC"] = 10;
            //}
            //daCarpeta.Dispose();
            //dsCarpeta.Dispose();

            //Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);   
           
        }

        protected void cmdInforme_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(4);
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void cmdRazon_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(3);
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void cmdIncompetencia_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(5);
            Panel1.Visible = false;
            Panel2.Visible = false;


            string Sql = "Set DateFormat dmy exec InsertaNUCUnidad2 " + "''," + "10" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "0" + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + short.Parse(Session["IdUnidad"].ToString()) + "," + int.Parse(lblMensajeSession.Text);

            SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            DataSet dsCarpeta = new DataSet();
            daCarpeta.Fill(dsCarpeta, "Carpeta");
            foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            {
                Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
                Session["ID_ESTADO_NUC"] = 10;
            }
            daCarpeta.Dispose();
            dsCarpeta.Dispose();

            //Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);   
            Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);  
            if (IdCarpetaInicio.Text == "5")
            {
                Response.Redirect("WDatoIncompetencia.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }
            else
            {
                Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }
        }

        protected void cmdAccidenteVial_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(6);
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void btnDenunciaAnonima_Click(object sender, EventArgs e)
        {
            IdCarpetaInicio.Text = Convert.ToString(7);
            Panel1.Visible = false;
            Panel2.Visible = false;


            string Sql = "Set DateFormat dmy exec InsertaNUCUnidad2 " + "''," + "10" + "," + short.Parse(Session["IdUsuario"].ToString()) + "," + short.Parse(IdCarpetaInicio.Text) + "," + "0" + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + short.Parse(Session["IdUnidad"].ToString()) + "," + int.Parse(lblMensajeSession.Text);

            SqlDataAdapter daCarpeta = new SqlDataAdapter(Sql, Data.CnnCentral);
            DataSet dsCarpeta = new DataSet();
            daCarpeta.Fill(dsCarpeta, "Carpeta");
            foreach (DataRow drCarpeta in dsCarpeta.Tables["Carpeta"].Rows)
            {
                Session["ID_CARPETA"] = drCarpeta["IdCarpeta"].ToString();
                Session["ID_ESTADO_NUC"] = 10;
            }
            daCarpeta.Dispose();
            dsCarpeta.Dispose();

            //Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);   
            Session["op"] = " ";
            //Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);  
            if (IdCarpetaInicio.Text == "5")
            {
                Response.Redirect("WDatoIncompetencia.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }
            else
            {
                Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
            }
        }



    }
}