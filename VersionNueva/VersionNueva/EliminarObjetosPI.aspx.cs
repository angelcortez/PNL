using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class EliminarObjetosPI : System.Web.UI.Page
    {

        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                IdOrden.Text = Session["ID_ORDEN"].ToString();
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

        protected void IBOrden_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ObjetosAseguradosPI.aspx");
        }

        public void IBImageOBJ_Command(object sender, CommandEventArgs e)
        {
            PGJ.EliminarObjetoAseguradoPI(Convert.ToInt32(e.CommandArgument.ToString()));

            //INSERTAMOS LA BITACORA DEL SISTEMA
            PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Se elimino un Objeto de la Carpeta" + IdCarpeta.Text);

            //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
            PGJ.ModificarFechaProceso_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

            //Colocar Alerta 
            string script = @"<script type='text/javascript'>
                            alert('OBJETO ELIMINADO');
                                   </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvObj.DataSourceID = "dsCargarObjetos";
            gvObj.DataBind();
        }


        


    }
}