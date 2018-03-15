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
using System.Reflection;
//using Microsoft.Office.Core;
//using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Word
using System.IO;
using System.Diagnostics;


namespace AtencionTemprana
{
    public partial class NUM : System.Web.UI.Page
    {
        Data PGJ = new Data();
        DataTable dtArbol = new DataTable();
        int Id = 24;
        //GenerarDocs gd = new GenerarDocs();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["lblArbol"] = lblArbol.Text;

                Session["op"] = Request.QueryString["op"];

                Session["IdPer"] = Request.QueryString["IdPer"];

                Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                Session["ID_ESTADO_NUM"] = Request.QueryString["ID_ESTADO_NUM"];
                ID_ESTADO_NUM.Text = Session["ID_ESTADO_NUM"].ToString();

                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                CargarDatosCarpeta();
                LLenarArbol(TVCarpeta.Nodes, 0);
                //try
                //{
                    PGJ.CargaComboFiltrado(ddlUnidad, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad1, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad2, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad3, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad4, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad5, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad6, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad7, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlUnidad8, "CAT_UNIDAD", "ID_UNDD", "ALIAS", "(ID_UNDD_TPO=1 or ID_UNDD_TPO=2) and ID_MNCPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaCombo(ddlCumplido, "CAT_ACUERDO_CUMPLIDO", "ID_CUMPLIDO", "CUMPLIDO");
                    PGJ.CargaCombo(ddlMasc, "CAT_MASC", "ID_MASC", "MASC");
                   // PGJ.CargaComboFiltrado(ddlFacilitador, "CAT_AGENTES_MP", "ID_AGENTE", "NOMBRE", "ID_TIPO_UNIDAD=3 and ID_MUNICIPIO=" + Session["IdMunicipio"].ToString());
                    PGJ.CargaComboFiltrado(ddlFacilitador, "CAT_USUARIO", "ID_USUARIO", " NMBRE + ' ' + PTRNO + ' ' + MTRNO ", "(ID_PUESTO=3 OR ID_PUESTO=17) and ID_UNDD=" + Session["IdUnidad"].ToString());

                    cargarInvitado();
                    cargarSolicitante();
                //}
                //catch (Exception ex)
                //{
                //    Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());

                //    //lblEstatus.Text = ex.Message;

                //}
                cargarFecha();

                if (Session["ID_ESTADO_NUM"].ToString() == "0")
                {
                    cmdInicioProceso.Visible = true;
                    cmdInvitacion.Visible = false;
                    cmdMediacion.Visible = false;
                    cmdConcluido.Visible = false;
                    cmdAceptacion.Visible = false;
                    cmdDesistimiento.Visible = false;
                    cmdDesistimientoInvitado.Visible = false;
                    cmdDesinteres.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel12.Visible = false;
                    Panel11.Visible = false;
                    Panel13.Visible = false;
                    Panel14.Visible = false;
                    Panel15.Visible = false;
                    Panel16.Visible = false;
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_NUM"].ToString() == "25")
                {

                    cmdConcluido.Visible = true;
                    cmdInicioProceso.Visible = false;
                    cmdInvitacion.Visible = false;
                    cmdMediacion.Visible = false;
                    cmdAceptacion.Visible = false;
                    cmdDesistimiento.Visible = false;
                    cmdDesistimientoInvitado.Visible = false;
                    cmdDesinteres.Visible = false;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel12.Visible = false;
                    Panel11.Visible = false;
                    Panel13.Visible = false;
                    Panel14.Visible = false;
                    Panel15.Visible = false;
                    Panel16.Visible = false;
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    TVCarpeta.Enabled = true;
                }
              
                else if (Session["ID_ESTADO_NUM"].ToString() == "26")
                {

                    cmdConcluido.Visible = true;
                    cmdInmediato.Visible = false;
                    cmdDiferido.Visible = false;
                    cmdSinAcuerdo.Visible = false;
                    cmdAceptacion.Visible = false;
                    cmdDesistimiento.Visible = false;
                    cmdDesistimientoInvitado.Visible = false;
                    cmdDesinteres.Visible = false;

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel12.Visible = false;
                    Panel11.Visible = false;
                    Panel13.Visible = false;
                    Panel14.Visible = false;
                    Panel15.Visible = false;
                    Panel16.Visible = false;
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_NUM"].ToString() == "27")
                {

                    cmdConcluido.Visible = false;
                    cmdInmediato.Visible = false;
                    cmdDiferido.Visible = false;
                    cmdSinAcuerdo.Visible = false;
                    cmdAceptacion.Visible = false;
                    cmdDesistimiento.Visible = false;
                    cmdDesistimientoInvitado.Visible = false;
                    cmdDesinteres.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel12.Visible = false;
                    Panel11.Visible = false;
                    Panel13.Visible = true;
                    Panel14.Visible = false;
                    Panel15.Visible = false;
                    Panel16.Visible = false;
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_NUM"].ToString() == "28")
                {

                    cmdConcluido.Visible = false;
                    cmdInmediato.Visible = false;
                    cmdDiferido.Visible = false;
                    cmdSinAcuerdo.Visible = false;
                    cmdAceptacion.Visible = false;
                    cmdDesistimiento.Visible = false;
                    cmdDesistimientoInvitado.Visible = false;
                    cmdDesinteres.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel12.Visible = false;
                    Panel11.Visible = false;
                    Panel13.Visible = false;
                    Panel14.Visible = false;
                    Panel15.Visible = false;
                    Panel16.Visible = false;
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_NUM"].ToString() == "29")
                {

                    cmdConcluido.Visible = false;
                    cmdInmediato.Visible = false;
                    cmdDiferido.Visible = false;
                    cmdSinAcuerdo.Visible = false;
                    cmdAceptacion.Visible = false;
                    cmdDesistimiento.Visible = false;
                    cmdDesistimientoInvitado.Visible = false;
                    cmdDesinteres.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel12.Visible = false;
                    Panel11.Visible = false;
                    Panel13.Visible = false;
                    Panel14.Visible = false;
                    Panel15.Visible = false;
                    Panel16.Visible = false;
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                else if (Session["ID_ESTADO_NUM"].ToString() == "30")
                {

                    cmdConcluido.Visible = false;
                    cmdInmediato.Visible = false;
                    cmdDiferido.Visible = false;
                    cmdSinAcuerdo.Visible = false;
                    cmdAceptacion.Visible = false;
                    cmdDesistimiento.Visible = false;
                    cmdDesistimientoInvitado.Visible = false;
                    cmdDesinteres.Visible = false;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel12.Visible = false;
                    Panel11.Visible = false;
                    Panel13.Visible = false;
                    Panel14.Visible = false;
                    Panel15.Visible = false;
                    Panel16.Visible = false;
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    TVCarpeta.Enabled = true;
                }
                //else if (Session["ID_ESTADO_NUM"].ToString() == "31")
                //{

                //    //cmdConcluido.Visible = false;
                //    //cmdInicioProceso.Visible = false;
                //    //cmdInvitacion.Visible = false;
                //    //cmdMediacion.Visible = false;
                //    //cmdAceptacion.Visible = false;
                //    //cmdDesistimiento.Visible = false;
                //    //cmdDesistimientoInvitado.Visible = false;
                //    //cmdDesinteres.Visible = false;
                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    Panel16.Visible = false;
                //    Panel17.Visible = false;
                //    Panel18.Visible = true;
                //    TVCarpeta.Enabled = true;
                //}

                if (Session["IdPer"] == null)
                {
                    Session["IdPer"] = "0";
                }



                if (Session["op"] == null)
                {
                    Session["op"] = "0";
                }

                if (Session["op"].ToString() == "Masc")
                {
                    Panel18.Visible = true;
                }

                if (Session["op"].ToString() == "Solicitante")
                {
                  //  CargarDocumentoAudiencia(Session["IdDoc"].ToString());
                    ID_PER.Text = Session["IdPer"].ToString();
                   
                    if (Session["ID_ESTADO_NUM"].ToString() == "7")
                    {

                        cmdConcluido.Visible = false;
                        cmdInicioProceso.Visible = false;
                        cmdInvitacion.Visible = false;
                        cmdMediacion.Visible = false;
                        cmdAceptacion.Visible = true;
                        cmdDesistimiento.Visible = true;
                        cmdDesistimientoInvitado.Visible = false;
                        cmdDesinteres.Visible = false;
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                       // Panel4.Visible = true;
                        Panel4.Visible = false;
                        Panel12.Visible = false;
                        Panel11.Visible = false;
                        Panel13.Visible = false;
                        Panel14.Visible = false;
                        Panel15.Visible = false;
                        Panel16.Visible = false;
                        Panel17.Visible = false;
                        Panel18.Visible = false;
                        TVCarpeta.Enabled = true;
                    }
                    else if (Session["ID_ESTADO_NUM"].ToString() == "25")
                    {

                        cmdConcluido.Visible = false;
                        cmdInicioProceso.Visible = false;
                        cmdInvitacion.Visible = false;
                        cmdMediacion.Visible = false;
                        cmdAceptacion.Visible = false;
                        cmdDesistimiento.Visible = true;
                        cmdDesistimientoInvitado.Visible = false;
                        cmdDesinteres.Visible = true;

                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        Panel4.Visible = false;
                        Panel12.Visible = false;
                        Panel11.Visible = false;
                        Panel13.Visible = false;
                        Panel14.Visible = false;
                        //Panel15.Visible = true;
                        Panel15.Visible = false;
                        Panel16.Visible = false;
                        Panel17.Visible = false;
                        Panel18.Visible = false;
                        TVCarpeta.Enabled = true;
                    }
                    else if (Session["ID_ESTADO_NUM"].ToString() == "30")
                    {

                        cmdConcluido.Visible = false;
                        cmdInmediato.Visible = false;
                        cmdDiferido.Visible = false;
                        cmdSinAcuerdo.Visible = false;
                        cmdAceptacion.Visible = false;
                        cmdDesistimiento.Visible = false;
                        cmdDesistimientoInvitado.Visible = false;
                        cmdDesinteres.Visible = false;

                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        Panel4.Visible = false;
                        Panel12.Visible = false;
                        Panel11.Visible = false;
                        Panel13.Visible = false;
                        Panel14.Visible = false;
                        Panel15.Visible = false;
                        Panel16.Visible = false;
                        Panel17.Visible = false;
                        Panel18.Visible = false;
                        TVCarpeta.Enabled = true;
                    }
                   
                  
                }

                if (Session["op"].ToString() == "Invitado")
                {
                    ID_PER.Text = Session["IdPer"].ToString();

                    if (Session["ID_ESTADO_NUM"].ToString() == "7")
                    {

                        cmdConcluido.Visible = false;
                        cmdInicioProceso.Visible = false;
                        cmdInvitacion.Visible = true;
                        cmdMediacion.Visible = false;
                        cmdAceptacion.Visible = false;
                        cmdDesistimiento.Visible = false;
                        cmdDesistimientoInvitado.Visible = true;
                        cmdDesinteres.Visible = false;
                        Panel4.Visible = false;
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        Panel12.Visible = false;
                        Panel11.Visible = false;
                        Panel13.Visible = false;
                        Panel14.Visible = false;
                        Panel15.Visible = false;
                        Panel16.Visible = false;
                        Panel17.Visible = false;
                        Panel18.Visible = false;
                        TVCarpeta.Enabled = true;
                    }
                    else if (Session["ID_ESTADO_NUM"].ToString() == "8")
                    {

                        cmdConcluido.Visible = false;
                        cmdInicioProceso.Visible = false;
                        cmdInvitacion.Visible = false;
                        cmdMediacion.Visible = false;
                        cmdAceptacion.Visible = false;
                        cmdDesistimiento.Visible = false;
                        cmdDesistimientoInvitado.Visible = false;
                        cmdDesinteres.Visible = false;
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        Panel4.Visible = false;
                        Panel12.Visible = false;
                        Panel11.Visible = false;
                        Panel13.Visible = false;
                        Panel14.Visible = false;
                        Panel15.Visible = false;
                        Panel16.Visible = false;
                        Panel17.Visible = false;
                        Panel18.Visible = false;
                        TVCarpeta.Enabled = true;
                    }
                    else if (Session["ID_ESTADO_NUM"].ToString() == "30")
                    {

                        cmdConcluido.Visible = false;
                        cmdInicioProceso.Visible = false;
                        cmdInvitacion.Visible = false;
                        cmdMediacion.Visible = false;
                        cmdAceptacion.Visible = false;
                        cmdDesistimiento.Visible = false;
                        cmdDesistimientoInvitado.Visible = true;
                        cmdDesinteres.Visible = false;
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        Panel4.Visible = false;
                        Panel12.Visible = false;
                        Panel11.Visible = false;
                        Panel13.Visible = false;
                        Panel14.Visible = false;
                        Panel15.Visible = false;
                        Panel16.Visible = false;
                        Panel17.Visible = false;
                        Panel18.Visible = false;
                        TVCarpeta.Enabled = true;
                    }
                }


               
                //else if (Session["ID_ESTADO_NUM"].ToString() == "6")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInicioProceso.Visible = true;
                //    cmdInvitacion.Visible = false;
                //    cmdMediacion.Visible = false;
                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "7")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInicioProceso.Visible = false;
                //    cmdInvitacion.Visible = true;
                //    cmdMediacion.Visible = false;

                //    Panel4.Visible = false;
                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "8")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInicioProceso.Visible = false;
                //    cmdInvitacion.Visible = false;
                //    cmdMediacion.Visible = false;
                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "9")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInicioProceso.Visible = false;
                //    cmdInvitacion.Visible = false;
                //    cmdMediacion.Visible = true;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "23")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInicioProceso.Visible = false;
                //    cmdInvitacion.Visible = false;
                //    cmdMediacion.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "24")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInicioProceso.Visible = false;
                //    cmdInvitacion.Visible = false;
                //    cmdMediacion.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                // if (Session["ID_ESTADO_NUM"].ToString() == "25")
                //{

                //    cmdConcluido.Visible = true;
                //    cmdInicioProceso.Visible = false;
                //    cmdInvitacion.Visible = false;
                //    cmdMediacion.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
            
                //else if (Session["ID_ESTADO_NUM"].ToString() == "26")
                //{

                //    cmdConcluido.Visible = true;
                //    cmdInmediato.Visible = false;
                //    cmdDiferido.Visible = false;
                //    cmdSinAcuerdo.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "27")
                //{

                //    cmdConcluido.Visible = true;
                //    cmdInmediato.Visible = false;
                //    cmdDiferido.Visible = false;
                //    cmdSinAcuerdo.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = true;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "28")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInmediato.Visible = false;
                //    cmdDiferido.Visible = false;
                //    cmdSinAcuerdo.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "29")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInmediato.Visible = false;
                //    cmdDiferido.Visible = false;
                //    cmdSinAcuerdo.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "30")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInmediato.Visible = false;
                //    cmdDiferido.Visible = false;
                //    cmdSinAcuerdo.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
                //else if (Session["ID_ESTADO_NUM"].ToString() == "31")
                //{

                //    cmdConcluido.Visible = false;
                //    cmdInicioProceso.Visible = false;
                //    cmdInvitacion.Visible = false;
                //    cmdMediacion.Visible = false;

                //    Panel1.Visible = false;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    Panel4.Visible = false;
                //    Panel12.Visible = false;
                //    Panel11.Visible = false;
                //    Panel13.Visible = false;
                //    Panel14.Visible = false;
                //    Panel15.Visible = false;
                //    TVCarpeta.Enabled = true;
                //}
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


        void cargarInvitado()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.InvitadoNombreNUM(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.INVITADO };
            ddlInvitado.DataSource = im;
            ddlInvitado.DataValueField = "ID_PERSONA";
            ddlInvitado.DataTextField = "INVITADO";
            ddlInvitado.DataBind();
        }

        void cargarSolicitante()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var im = from c in dc.SolicitanteNombreNUM(int.Parse(IdCarpeta.Text))
                     select new { c.ID_PERSONA, c.SOLICITANTE };
            ddlSolicitante.DataSource = im;
            ddlSolicitante.DataValueField = "ID_PERSONA";
            ddlSolicitante.DataTextField = "SOLICITANTE";
            ddlSolicitante.DataBind();
        }

        protected void CargarDatosCarpeta()
        {
            //try
            //{
                int IdUser;
                IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());
                PGJ.EliminaArbol(IdUser);
                PGJ.InsertaArbol(1, 0, "MECANISMOS ALTERNATIVOS DE SOLUCIÓN DE CONFLICTOS", "", "", IdUser);
                PGJ.InsertaArbol(2, 1, "NUM", "", "", IdUser);
                PGJ.InsertaArbol(3, 1, "SOLICITANTES", "", "", IdUser);
                PGJ.InsertaArbol(4, 1, "INVITADOS", "", "", IdUser);
                PGJ.InsertaArbol(20, 1, "PROCESO DE MEDIACION", "", "", IdUser);
                PGJ.InsertaArbol(16, 20, "AUDIENCIAS", "JusticiaAlternativaAudiencia.aspx?op=Agregar", "", IdUser);
                PGJ.InsertaArbol(21, 20, "CONCLUSION", "NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 25, "", IdUser);
                PGJ.InsertaArbol(19, 1, "ACTUACIONES", "DocMediacion.aspx?op=Agregar", "", IdUser);
                PGJ.InsertaArbol(5, 0, "CARPETA", "", "", IdUser);
                PGJ.InsertaArbol(6, 5, "RAC", "", "", IdUser);
                PGJ.InsertaArbol(7, 5, "NUC", "", "", IdUser);
                PGJ.InsertaArbol(8, 5, "SOLICITANTE", "Datos.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(9, 5, "OFENDIDO", "QuienResulteOfendido.aspx", "", IdUser);
                PGJ.InsertaArbol(10, 5, "EMPRESA", "EmpreaOfendida.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(11, 5, "INVITADO", "QuienResulteResponsable.aspx", "", IdUser);
                //  PGJ.InsertaArbol(7, 1, "TESTIGO", "Datos.aspx?&op=AgregarTes", "", IdUser);
                // PGJ.InsertaArbol(13, 1, "DEFENSOR", "DefensorPublico.aspx", "", IdUser);
                PGJ.InsertaArbol(12, 5, "LUGAR DE HECHOS", "LugarHechos.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(13, 5, "DELITO", "", "", IdUser);
                PGJ.InsertaArbol(14, 5, "VEHICULOS", "Vehiculo.aspx?&op=Agregar", "", IdUser);
                PGJ.InsertaArbol(15, 5, "DESCRIPCION HECHOS", "Hechos.aspx?&op=Agregar", "", IdUser);
                //   PGJ.InsertaArbol(11, 1, "SOLICITUDES DE AUDIENCIA", "Solicitudes.aspx?&op=Agregar", "", IdUser);

                //if (Session["ID_ESTADO_NUM"].ToString() == "27" || Session["ID_ESTADO_NUM"].ToString() == "28")
                //{
                //    PGJ.InsertaArbol(17, 5, "ACUERDO DE CUMPLIMIENTO DIFERIDO", "AcuerdoCumplimientoDiferido.aspx?op=Agregar", "", IdUser);
                //    CargarDatosArbol("AcuerdoDiferido", 17);
                //}
                //if (Session["ID_ESTADO_NUM"].ToString() == "26")
                //{
                //    PGJ.InsertaArbol(18, 5, "ACUERDO DE CUMPLIMIENTO INMEDIATO", "AcuerdoCumplimientoInmediato.aspx?op=Agregar", "", IdUser);
                //    CargarDatosArbol("AcuerdoInmediato", 18);
                //}

                CargarDatosArbol("MediacionAudiencia", 16);
                CargarDatosArbol("RAC", 6);
                CargarDatosArbol("NUM", 2);
                CargarDatosArbol("NUC", 7);

                CargarDatosArbol("Persona 1, ", 8);
                CargarDatosArbol("Persona 2, ", 9);
                //CargarDatosArbol("Persona 8, ", 6);
                CargarDatosArbol("Persona 3, ", 11);
                //  CargarDatosArbol("Persona 4, ", 7);

                CargarDatosArbol("Descripcion", 15);
                CargarDatosArbol("LugarHechos", 12);
                CargarDatosArbol("Delito", 13);

                CargarDatosArbol("DocumentosMediacion", 19);
                // CargarDatosArbol("Defensor", 13);
                CargarDatosArbol("Vehiculo", 14);
                CargarDatosArbol("Empresa", 10);
                CargarDatosArbol("ProcesoSolicitante1", 3);
                CargarDatosArbol("ProcesoInvitado1", 4);
                CargarDatosArbol("ProcesoAcuerdoInmediato", 21);
                CargarDatosArbol("ProcesoAcuerdoDiferido", 21);
                CargarDatosArbol("ProcesoSinAcuerdo", 21);
            
                LLenarArbol(TVCarpeta.Nodes, 0);

                PGJ.EliminaArbol(IdUser);
            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());

            //    //lblEstatus.Text = ex.Message;

            //}
        }

        protected void CargarDatosArbol(string Carpeta, int IdPadre)
        {
            SqlDataAdapter daArbol = new SqlDataAdapter("DatosArbol" + Carpeta + " " + Convert.ToString(IdCarpeta.Text), Data.CnnCentral);
            DataSet dsArbol = new DataSet();
            daArbol.Fill(dsArbol, "Arbol");
            foreach (DataRow drArbol in dsArbol.Tables["Arbol"].Rows)
            {
                PGJ.InsertaArbol(Id++, IdPadre, drArbol["Nodo"].ToString(), drArbol["URL"].ToString(), drArbol["Icon"].ToString(), Convert.ToInt32(Session["IdUsuario"].ToString()));
            }
            daArbol.Dispose();
            dsArbol.Dispose();

        }

        protected void LLenarArbol(TreeNodeCollection Nodo, int IdPadre)
        {

            int IdUser;
            IdUser = Convert.ToInt32(Session["IdUsuario"].ToString());

            int EsteId;
            string EsteNombre;

            SqlDataAdapter daArbol = new SqlDataAdapter("select * from PGJ_ARBOL where IdUsuario=" + Convert.ToString(IdUser), Data.CnnCentral);
            DataSet dsArbol = new DataSet();

            daArbol.Fill(dsArbol, "Arbol");

            foreach (DataRow drArbol in dsArbol.Tables["Arbol"].Select("Idpadre=" + Convert.ToString(IdPadre)))
            {
                EsteId = Convert.ToInt32(drArbol["Id"].ToString());
                EsteNombre = drArbol["Nodo"].ToString();

                TreeNode NuevoNodo = new TreeNode(EsteNombre, EsteId.ToString(), drArbol["Icon"].ToString());
                NuevoNodo.NavigateUrl = drArbol["URL"].ToString();
                Nodo.Add(NuevoNodo);
                LLenarArbol(NuevoNodo.ChildNodes, EsteId);
            }
        }




        protected void cmdIniciar_Click(object sender, EventArgs e)
        {
            Data.IdCarpeta = Convert.ToInt32(IdCarpeta.Text);
        }


        protected void ImgSi_Click(object sender, ImageClickEventArgs e)
        {
            dcOrientacionDataContext validar = new dcOrientacionDataContext();
            int x = 0;

            x = validar.VALIDAR_PGJ_CARPETA_NUM("28", Session["IdMunicipio"].ToString(), Session["IdUnidad"].ToString(), txtNumero.Text, txtAño.Text, 2);
            if (x == 0)
            {
                SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=6 , FECHA_ESTADO_NUM=" + "GETDATE()" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rd = sql.ExecuteReader();
                rd.Close();


                //string CAD;
                //CAD = "set dateformat dmy INSERT INTO PGJ_NUM_INICIO_SI_ACEPTACION(ID_CARPETA,ID_MUNICIPIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
                //CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

                //SqlCommand sqlNum = new SqlCommand(CAD, Data.CnnCentral);
                //SqlDataReader rdNum = sqlNum.ExecuteReader();

                //rdNum.Close();



                PGJ.GenerarNC(IdCarpeta.Text,"NUM", short.Parse(Session["IdMunicipio"].ToString()), txtNumero.Text, txtAño.Text, short.Parse(Session["IdUnidad"].ToString()));
                PGJ.InsertaNUM(Data.NUM, short.Parse(ddlFacilitador.SelectedValue.ToString()), int.Parse(IdCarpeta.Text));

                SqlCommand sqlIniciar = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUM=6" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlIniciar.ExecuteReader();
                rdC.Close();


                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 6);
                TVCarpeta.Enabled = true;
            }

            else if (x == 1)
            {
                lblError.Text = "EL REGISTRO YA EXISTE";
            }


        }
        protected void ImgNo_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
            cmdInicioProceso.Visible = false;
        }
        protected void ImgSi1_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlSuspender = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUM=7" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlSuspender.ExecuteReader();
            //rdC.Close();

            //string CAD2;
            //CAD2 = "INSERT INTO PGJ_NUM_PROCESO(ID_CARPETA,ID_MUNICIPIO_PROCESO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaProceso.Text + "'" + ")";

            //SqlCommand sqlProceso = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdProceso = sqlProceso.ExecuteReader();

            //rdProceso.Close();
            //Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 7);

            ////Data.IdPlantilla = 1;
            ////PGJ.ConnectServer();
            ////SqlCommand cmd = new SqlCommand("SELECT ID_PERSONA FROM PGJ_CARPETA_PERSONA WHERE ID_TIPO_ACTOR = 1 AND  ID_CARPETA =" + Data.IdPlantilla, Data.CnnCentral);
            ////SqlDataReader rd = cmd.ExecuteReader();
            ////if (rd.HasRows)
            ////{
            ////    rd.Read();
            ////    Data.IdPersona = int.Parse(rd["ID_PERSONA"].ToString());
            ////    GenerarDocs gd = new GenerarDocs();
            ////    gd.LeerDeBD();
            ////    Response.Redirect("Descargas.aspx");
            ////    rd.Close();
            ////}
        }

        protected void ImgNo1_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;

        }
        protected void ImgSi2_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlSuspender = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUM=8" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlSuspender.ExecuteReader();
            //rdC.Close();

            //string CAD2;
            //CAD2 = "INSERT INTO PGJ_NUM_SUSPENDIDA(ID_CARPETA,ID_MUNICIPIO_SUSPENDIDA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaSuspender.Text + "'" + ")";

            //SqlCommand sqlSus = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdSus = sqlSus.ExecuteReader();

            //rdSus.Close();
            //Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 8);

            ////Data.IdPlantilla = 3;
            ////gd.LeerDeBD();
            ////Response.Redirect("Descargas.aspx");
        }
        protected void ImgNo2_Click(object sender, ImageClickEventArgs e)
        {
            Panel3.Visible = false;
        }

        protected void ImgSi3_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sqlSuspender = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUM=9" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlSuspender.ExecuteReader();
            //rdC.Close();

            //string CAD2;
            //CAD2 = "INSERT INTO PGJ_NUM_REMITIDA(ID_CARPETA,ID_MUNICIPIO_REMITIDA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemitir.Text + "'" + ")";

            //SqlCommand sqlSus = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdSus = sqlSus.ExecuteReader();

            //rdSus.Close();

            //Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 9);

            ////Data.IdPlantilla = 5;
            ////gd.LeerDeBD();
            ////Response.Redirect("Descargas.aspx");
        }

        protected void ImgNo3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Iniciar_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void Procesar_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel11.Visible = false;
        }




        protected void cmdSeguimiento_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }



        protected void rbAcude_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbAcude.SelectedValue == "1")
            {
                Panel6.Visible = true;
                Panel7.Visible = false;
                Panel14.Visible = false;
            }
            else if (rbAcude.SelectedValue == "2")
            {
                Panel6.Visible = false;
                Panel7.Visible = true;
                Panel14.Visible = false;
            }
        }







        protected void ImgSi4_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=7" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
            SqlDataReader rd1 = sql1.ExecuteReader();
            rd1.Close();


            string CAD;
            CAD = "set dateformat dmy INSERT INTO PGJ_NUM_INICIO_SI_ACEPTACION(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 7 + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

            SqlCommand sqlNum = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdNum = sqlNum.ExecuteReader();

            rdNum.Close();

            Panel4.Visible = false;
            Panel1.Visible = false;
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 7);

        }



        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = false;
            Panel12.Visible = true;
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = false;
            Panel12.Visible = false;
            cmdInicioProceso.Enabled = true;
        }

        protected void ImgNo4_Click(object sender, ImageClickEventArgs e)
        {
            Panel6.Visible = false;
            Panel14.Visible = true;
        }



        protected void ImgNo6_Click(object sender, ImageClickEventArgs e)
        {
            Panel7.Visible = false;
        }

        protected void ImgNo10_Click(object sender, ImageClickEventArgs e)
        {
            Panel11.Visible = false;
            Panel15.Visible = true;
        }

        protected void ImgNo7_Click(object sender, ImageClickEventArgs e)
        {
            Panel8.Visible = false;
        }

        protected void ImgNo9_Click(object sender, ImageClickEventArgs e)
        {
            Panel9.Visible = false;
        }

        protected void ImgNo8_Click(object sender, ImageClickEventArgs e)
        {
            Panel10.Visible = false;
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=8 , FECHA_ESTADO_NUM='" + txtFechaRemiteSolicitante.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();
            SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=8" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
            SqlDataReader rd1 = sql1.ExecuteReader();
            rd1.Close();


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_INICIO_NO_ACEPTACION(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 8 + "," + Session["IdUnidad"].ToString() + "," + ddlUnidad.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemiteSolicitante.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 8);
        }

        protected void ImgSi4_Click1(object sender, ImageClickEventArgs e)
        {
        //    SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=9 , FECHA_ESTADO_NUM=" + "GETDATE()" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
        //    SqlDataReader rd = sql.ExecuteReader();
        //    rd.Close();

            SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=7" +  " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text , Data.CnnCentral);
            SqlDataReader rd1 = sql1.ExecuteReader();
            rd1.Close();

            string CAD;
            CAD = "set dateformat dmy INSERT INTO PGJ_NUM_INVITACION_SI_ACEPTACION(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 7 + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

            SqlCommand sqlNum = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdNum = sqlNum.ExecuteReader();

            rdNum.Close();

            //PROCESO DE MEDIACION EN CARPETA

            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=25 , FECHA_ESTADO_NUM=" + "GETDATE()" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();

            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_MEDIACION(ID_CARPETA,ID_MUNICIPIO,ID_ESTADO_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + 25 + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();
            rdTramite.Close();

            Panel11.Visible = false;
            cmdMediacion.Visible = false;


            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 7);
        }

        protected void ImgSi5_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=23 , FECHA_ESTADO_NUM='" + txtFechaRemite.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();
            SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=8" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
            SqlDataReader rd1 = sql1.ExecuteReader();
            rd1.Close();


            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_INVITACION_NO_ACEPTACION(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 8  +"," + Session["IdUnidad"].ToString() + "," + ddlUnidad1.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemite.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 8);
        }

        protected void ImgSi6_Click(object sender, ImageClickEventArgs e)
        {
            if (rbNoAcude.SelectedValue == "1")
            {
                //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=30 , FECHA_ESTADO_NUM='" + txtFechaRemite2.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                //SqlDataReader rd = sql.ExecuteReader();
                //rd.Close();
                SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=29" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
                SqlDataReader rd1 = sql1.ExecuteReader();
                rd1.Close();


                string CAD2;
                CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_INVITACION_DESINTERES(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
                CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 29 + "," + Session["IdUnidad"].ToString() + "," + ddlUnidad2.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemite2.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

                SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
                SqlDataReader rdTramite = sqlTramite.ExecuteReader();

                rdTramite.Close();
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 29);
            }
            else if (rbNoAcude.SelectedValue == "2")
            {
                //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=31 , FECHA_ESTADO_NUM='" + txtFechaRemite2.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                //SqlDataReader rd = sql.ExecuteReader();
                //rd.Close();
                SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=31" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
                SqlDataReader rd1 = sql1.ExecuteReader();
                rd1.Close();


                string CAD2;
                CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_INVITACION_INASISTENCIA(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
                CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 31 +  "," + Session["IdUnidad"].ToString() + "," + ddlUnidad2.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemite2.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

                SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
                SqlDataReader rdTramite = sqlTramite.ExecuteReader();

                rdTramite.Close();
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 31);

            }

            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=24 , FECHA_ESTADO_NUM='" + txtFechaRemite2.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();

            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_INVITACION_NO_ASISTENCIA(ID_CARPETA,ID_MUNICIPIO,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + ddlUnidad2.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemite2.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();
            //Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 24);
        }

        protected void ImgSi10_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=25 , FECHA_ESTADO_NUM=" + "GETDATE()" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();

            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_MEDIACION(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 25 + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Panel11.Visible = false;
            cmdMediacion.Visible = false;

            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 25);
        }

        protected void ImgSi7_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=26 , FECHA_ESTADO_NUM='" + txtFechaInmediato.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rd = sql.ExecuteReader();
            rd.Close();

            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_CUM_INMEDIATO(ID_CARPETA,ID_MUNICIPIO,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_CUMPLIMIENTO,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + ddlUnidad3.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaInmediato.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 26);
        }

        protected void ImgSi9_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=27 , FECHA_ESTADO_NUM=" + "GETDATE()" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();

            //string CAD2;
            //CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_CUM_DIFERIDO(ID_CARPETA,ID_MUNICIPIO,ID_UNDD,ID_USUARIO,FECHA_REGISTRO)";
            //CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + Session["IdUnidad"].ToString() + "," + Session["IdUsuario"].ToString() + ", getdate()" + ")";

            //SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            //SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            //rdTramite.Close();


           // PGJ.InsertaAcuerdoDiferido(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlSolicitante.SelectedValue.ToString()), int.Parse(ddlInvitado.SelectedValue.ToString()), 27, short.Parse(Session["IdUsuario"].ToString())); 
          //  Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 27);
        }

        protected void ImgSi8_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=28 , FECHA_ESTADO_NUM='" + txtFechaSinAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();

            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_CON_SIN_ACUERDO(ID_CARPETA,ID_MUNICIPIO,ID_SOLICITANTE,ID_INVITADO,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + int.Parse(ddlSolicitante.SelectedValue.ToString()) + "," + int.Parse(ddlInvitado.SelectedValue.ToString()) + "," + Session["IdUnidad"].ToString() + "," + ddlUnidad4.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaSinAcuerdo.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 28);
        }

        protected void cmdInicioProceso_Click(object sender, ImageClickEventArgs e)
        {
            rbAcude.Visible = false;
            Panel11.Visible = false;
            //Panel4.Visible = true;
            Panel1.Visible = true;
            cmdInicioProceso.Enabled = false;
        }

        protected void cmdInvitacion_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = true;
            Panel17.Visible = false;
            rbAcude.Visible = true;

            Panel11.Visible = false;
            Panel4.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
        }

        protected void cmdMediacion_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel11.Visible = true;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel4.Visible = false;
            rbAcude.Visible = false;
        }

        protected void cmdInmediato_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AcuerdoCumplimientoInmediato.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Agregar" + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());

            //Panel8.Visible = true;
            //Panel9.Visible = false;
            //Panel10.Visible = false;
        }

        protected void cmdSinAcuerdo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ConculidoSinAcuerdo.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Agregar" + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
           
            //Panel8.Visible = false;
            //Panel9.Visible = false;
            //Panel10.Visible = true;
        }

        protected void cmdConcluido_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
        }

        protected void cmdDiferido_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AcuerdoCumplimientoDiferido.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&op=Agregar" + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
            //Panel8.Visible = false;
            //Panel9.Visible = true;
            //Panel10.Visible = false;
        }

        protected void ImgSi11_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                dcOrientacionDataContext validar = new dcOrientacionDataContext();
                int x = 0;

                x = validar.VALIDAR_NUM_CUM_DIFERIDO(int.Parse(Session["ID_CARPETA"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), 2);
                if (x == 0)
                {
                    lblEstatus1.Text = "NO SE PUEDE RETIMIR LA CARPETA POR QUE FALTA ACTUALIZAR EL ESTADO ACUERDO DE CUMPLIMIENTO DIFERIDO";
                }
                else if (x == 1)
                {
                    if (ddlCumplido.SelectedValue == "0")
                    {
                        lblEstatus.Text = "SELECCIONE EL ESTADO";
                    }
                    else
                    {


                        SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_NUM_CUM_DIFERIDO set FECHA_CUMPLIMIENTO ='" + txtFechaRemite3.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                        SqlDataReader rd = sql.ExecuteReader();
                        rd.Close();

                        SqlCommand sql2 = new SqlCommand("set dateformat dmy update PGJ_NUM_CUM_DIFERIDO set ID_UNDD_REMITE=" + ddlUnidad5.SelectedValue.ToString() + " , ID_CUMPLIDO=" + ddlCumplido.SelectedValue.ToString() + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                        SqlDataReader rd2 = sql2.ExecuteReader();
                        rd2.Close();

                        Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 27);
                    }
                }

            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        protected void ImgNo11_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void ImgSi12_Click(object sender, ImageClickEventArgs e)
        {
            //SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_ESTADO_NUM=29 , FECHA_ESTADO_NUM='" + txtFechaRemite4.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            //SqlDataReader rd = sql.ExecuteReader();
            //rd.Close();

            SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=29" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
            SqlDataReader rd1 = sql1.ExecuteReader();
            rd1.Close();

            string CAD2;
            CAD2 = "set dateformat dmy INSERT INTO PGJ_NUM_DESINTERES(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
            CAD2 = CAD2 + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 29  +"," + Session["IdUnidad"].ToString() + "," + ddlUnidad6.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemite4.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

            SqlCommand sqlTramite = new SqlCommand(CAD2, Data.CnnCentral);
            SqlDataReader rdTramite = sqlTramite.ExecuteReader();

            rdTramite.Close();
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 29);
        }

        protected void cmdAceptacion_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = true;
            Panel16.Visible = false;
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=30" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
            SqlDataReader rd1 = sql1.ExecuteReader();
            rd1.Close();

            string CAD;
            CAD = "set dateformat dmy INSERT INTO PGJ_NUM_DESISTIMIENTO_SOLICITANTE(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + ID_PER.Text + "," + 30 + "," + ddlUnidad3.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemiteDesInv.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";


            SqlCommand sqlNum = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdNum = sqlNum.ExecuteReader();

            rdNum.Close();

            Panel4.Visible = false;
            Panel1.Visible = false;
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 30);

        }

        protected void cmdDesistimiento_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = false;
            Panel16.Visible = true;
            Panel15.Visible = false;
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            Panel16.Visible = false;
        }

        protected void cmdDesinteres_Click(object sender, ImageClickEventArgs e)
        {
            Panel15.Visible = true;
            Panel16.Visible = false;
        }

        protected void cmdDesistimientoInvitado_Click(object sender, ImageClickEventArgs e)
        {
            Panel17.Visible = true;
            Panel2.Visible = false;
        }

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sql1 = new SqlCommand("set dateformat dmy update  PGJ_CARPETA_PERSONA set ID_ESTADO_CARPETA=30" + " where ID_CARPETA=" + IdCarpeta.Text + "AND ID_PERSONA=" + ID_PER.Text, Data.CnnCentral);
            SqlDataReader rd1 = sql1.ExecuteReader();
            rd1.Close();

            string CAD;

            CAD = "set dateformat dmy INSERT INTO PGJ_NUM_DESISTIMIENTO_INVITADO(ID_CARPETA,ID_MUNICIPIO,ID_PERSONA,ID_ESTADO_CARPETA,ID_UNDD_REMITE,ID_USUARIO,FECHA_REMITE,FECHA_REGISTRO)";
            CAD = CAD + "VALUES(" + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString())+ "," + ID_PER.Text + "," + 30  + "," + ddlUnidad3.SelectedValue + "," + Session["IdUsuario"].ToString() + ",'" + txtFechaRemiteDesInv.Text + "'+ + CONVERT (datetime, RIGHT ('00'+ CONVERT(varchar(2), datepart (HOUR  , GETDATE()) ), 2) + ':' +  RIGHT ('00'+CONVERT(varchar(2), datepart (MINUTE  , GETDATE()) ), 2))" + ", getdate()" + ")";

            SqlCommand sqlNum = new SqlCommand(CAD, Data.CnnCentral);
            SqlDataReader rdNum = sqlNum.ExecuteReader();

            rdNum.Close();

            Panel4.Visible = false;
            Panel1.Visible = false;
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + 30);

        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
        {
            Panel17.Visible = false;
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand sql = new SqlCommand("set dateformat dmy update PGJ_CARPETA set ID_MASC=" + ddlMasc.SelectedValue.ToString() + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rd = sql.ExecuteReader();
            rd.Close();
           
            Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
          //  Panel18.Visible = false;
        }

        protected void ImageButton14_Click(object sender, ImageClickEventArgs e)
        {
            Panel18.Visible = false;
        }

   
       




    }
}