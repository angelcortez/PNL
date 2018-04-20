using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 300;

            Session["IdUsuario"] = "510";
            Session["ID_PUESTO"] = "10";

            Session["IdUsuario"].ToString();



            if (Session["ID_PUESTO"].ToString() == "2")
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = true;
                hBusquedaPersonasNSJP.Visible=true;
                hBusquedaPNL.Visible=true;
                hlSec.Visible = true;
                //hEstadisticaNUC.Visible = true;
                hRac.Visible = true;
                hDerivada.Visible = true;
                

             
            }

            else if (Session["ID_PUESTO"].ToString() == "10")
            {


                hCerrarSesion.Visible = true;
                hEstadistica.Visible = true;
                hBusquedaPersonasNSJP.Visible = true;
                hBusquedaPNL.Visible = true;
                hlSec.Visible = true;
                //hEstadisticaNUC.Visible = true;
                hRac.Visible = true;
                hDerivada.Visible = true;


            }

            else if (Session["ID_PUESTO"].ToString() == "4")
            
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = false;
                hlSec.Visible = true;
                hBusquedaPersonasNSJP.Visible = false;
                hBusquedaPNL.Visible = false;
                //hEstadisticaNUC.Visible = false;
                hRac.Visible = true;
                hDerivada.Visible = true;
            
            }

            else if (Session["ID_PUESTO"].ToString() == "15")
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = false;
                hlSec.Visible = true;
                hBusquedaPersonasNSJP.Visible = false;
                hBusquedaPNL.Visible = false;
                //hEstadisticaNUC.Visible = false;
                hRac.Visible = true;
                hDerivada.Visible = true;

            }

            else if (Session["ID_PUESTO"].ToString() == "6")
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = false;
                hlSec.Visible = true;
                hBusquedaPersonasNSJP.Visible = false;
                hBusquedaPNL.Visible = false;
                //hEstadisticaNUC.Visible = false;
                hRac.Visible = true;
                hDerivada.Visible = true;

            }

            else if (Session["ID_PUESTO"].ToString() == "14")
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = false;
                hlSec.Visible = true;
                hBusquedaPersonasNSJP.Visible = false;
                hBusquedaPNL.Visible = false;
                //hEstadisticaNUC.Visible = false;
                hRac.Visible = true;
                hDerivada.Visible = true;

            }

            else if (Session["ID_PUESTO"].ToString() == "12")
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = false;
                hlSec.Visible = true;
                hBusquedaPersonasNSJP.Visible = false;
                hBusquedaPNL.Visible = false;
                //hEstadisticaNUC.Visible = false;
                hRac.Visible = true;
                hDerivada.Visible = true;

            }

            else if (Session["ID_PUESTO"].ToString() == "13")
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = false;
                hlSec.Visible = true;
                hBusquedaPersonasNSJP.Visible = false;
                hBusquedaPNL.Visible = false;
                //hEstadisticaNUC.Visible = false;
                hRac.Visible = false;
                hDerivada.Visible = false;

            }

            else if (Session["ID_PUESTO"].ToString() == "7")
            {
                hCerrarSesion.Visible = true;
                hEstadistica.Visible = false;
                hlSec.Visible = true;
                hBusquedaPersonasNSJP.Visible = false;
                hBusquedaPNL.Visible = false;
                //hEstadisticaNUC.Visible = false;
                hRac.Visible = false;
                hDerivada.Visible = false;

            }
            
            


            


        }
    }
}