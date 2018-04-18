using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class PruebaPantallas : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_CARPETA"] = 1;
            Session["ID_PERSONA"] = 1;
            Session["ID_MUNICIPIO_CARPETA"] = 1;
            Session["ID_DATOS_GENERALES"] = 1;
            Session["ID_PERTENENCIA_SOCIAL"] = 1;
            Session["ID_INFO_FINANCIERA"] = 1;
            Session["ID_OTRA_INFO"] = 1;
            Session["ID_DISCAPACIDADES"] = 1;
            Session["ID_INFO_ODONTOLOGICA"] = 1;
            Session["ID_CAUSALES"] = 1;
                       
        }

        protected void cmdGu_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatosPrincipalesSec.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatosPrincipalesSec.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Modificar" + "&ID_PRINC_SEC=1");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProfugoSec.aspx?ID_CARPETA=1"+ "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProfugoSec.aspx?ID_CARPETA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Modificar" + "&ID_PROFUGO_SEC=1");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarNegociacionSec.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarNegociacionSec.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Modificar" + "&ID_NEGOC_SEC=1");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("LiberacionSec.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("LiberacionSec.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&ID_LIB_SEC=1" + "&op=Modificar");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarBandaDesartSec.aspx?ID_CARPETA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarBandaDesartSec.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&ID_BANDA_DES=1" + "&op=Modificar");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatosDetenidoPI.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("PNLDatosPrincipales.aspx?ID_CARPETA=1" + "&ID_PERSONA=1" + "&ID_MUNICIPIO_CARPETA=1" + "&op=Agregar");
        }

        protected void modifica_Click(object sender, EventArgs e)
        {
            Response.Redirect("PNLDatosPrincipales.aspx?op=Modificar");
               
            


        }
    }
}