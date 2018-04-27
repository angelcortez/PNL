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
using System.Text.RegularExpressions;

namespace AtencionTemprana
{
    public partial class WDatoIncompetencia : System.Web.UI.Page
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
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");


            if (!Page.IsPostBack)
            {
                //HookOnFocus(this.Page as Control);
                //ScriptManager.RegisterStartupScript(
                //this,
                //typeof(Delito),
                //"ScriptDoFocus",
                //SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                //true);

                //Session["ID_LUGAR_HECHOS"] = Request.QueryString["ID_LUGAR_HECHOS"];
                Session["ID_CONSECUTIVO_DELITO"] = Request.QueryString["ID_CONSECUTIVO_DELITO"];
                Session["ID_LUGAR_HECHOS"] = Request.QueryString["ID_LUGAR_HECHOS"];
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["op"] = Request.QueryString["op"];
                lblArbol.Text = Session["lblArbol"].ToString();

                IdCarpeta.Text=Session["ID_CARPETA"].ToString();
                IdMunicipio.Text = Session["IdMunicipio"].ToString();

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
                PGJ.CargaCombo(ddlArea, "CAT_ENTIDAD_INCOMPETENCIAS", "ID_ENTIDAD", "ENTIDAD");
                //PGJ.CargaCombo(ddlArea, "CAT_AGENCIA", "ID_AGENCIA", "AGENCIA");
                PGJ.CargaCombo(ddlDelito, "CAT_DELITO", "ID_DLTO", "DLTO");

                //CARGAR FECHA DE INICIO Y HORA DE INICIO
                SqlCommand sqlFechaInicio = new SqlCommand("CargarFechaInicioExpedienteRobo ", Data.CnnCentral);
                sqlFechaInicio.CommandType = CommandType.StoredProcedure;
                sqlFechaInicio.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                sqlFechaInicio.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.Int);

                sqlFechaInicio.Parameters["@IdCarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
                sqlFechaInicio.Parameters["@IdMunicipioCarpeta"].Value = int.Parse(Session["IdMunicipio"].ToString());

                SqlDataReader drFechaInicio = sqlFechaInicio.ExecuteReader();
                if (drFechaInicio.HasRows)
                {
                    drFechaInicio.Read();
                    txtFechaInicio1.Text = drFechaInicio["FechaInicio"].ToString();
                }
                drFechaInicio.Close();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR DATOS DE LA INCOMPETENCIA";
                    Button1.Visible = false;
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Datos de la informacion de la incompetencia IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));

                    lblOperacion.Text = "MODIFICAR DATOS DE LA INCOMPETENCIA";
                    cmdReg.Visible = true;
                    cargarDatosIncompetencia();
                    cmdGu.Visible = true;
                    Button1.Visible = false;
                    lblDelitos.Visible = true;
                    IBAgregarDelito.Visible = true;


                    GridDelito.DataSourceID = "dsBuscaDelitoIncompetencia";
                    GridDelito.DataBind();
                    GridDelito.Visible = true;
                }

                if (Session["op"].ToString() == "Agregar" && Session["INICIAR_CARPETA"].ToString() == "1")
                {
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

                    HyperLink linkCS = this.Page.Master.FindControl("hCerrarSesion") as HyperLink;
                    linkCS.Text = "";
                    linkCS.Visible = false;
                    linkCS.Enabled = false;
                    linkCS.NavigateUrl = "#";

                    //FIN-ocultando el menu cuando inicia carpeta
                }
            }
        }

        void cargarDatosIncompetencia()
        {
            SqlCommand sql = new SqlCommand("SP_BuscaIncompetenciaDatos " + int.Parse(IdCarpeta.Text) +","+ int.Parse(IdMunicipio.Text), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();


                ddlArea.SelectedValue = dr["IdArea"].ToString();
                txtExpediente.Text = dr["Expediente"].ToString();
                txtFechaInicio.Text = dr["FechaInicio"].ToString();


            }
            dr.Close();
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

        string Valor;
        protected void cmdGu_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            String cadenaCombo = "--SELECCIONA--";
            Regex rgx = new Regex("([0-9]){5}/[0-9]{4}");

            if (ddlArea.SelectedItem.ToString().Contains(cadenaCombo))
            {
                lblError.Text = "SELECCIONE AREA.";
            }
            if(string.IsNullOrEmpty(txtExpediente.Text))
            {
                lblError.Text = "EXPEDIENTE NO PUEDE ESTAR VACIO.";
            }
            if (string.IsNullOrEmpty(txtFechaInicio.Text))
            {
                lblError.Text = "FECHA DE INICIO NO PUEDE ESTAR VACIA.";
            }
            //1-6000
            if (int.Parse(ddlArea.SelectedValue.ToString()) >= 1 && int.Parse(ddlArea.SelectedValue.ToString()) <= 6000)
            {
                //int Tamanio = txtExpediente.Text.Length;
                //    if (Tamanio==9)
                //    {
                //        txtExpediente.Text = "0" + txtExpediente.Text;
                //    }
                //    if (Tamanio == 8)
                //    {
                //        txtExpediente.Text = "00" + txtExpediente.Text;
                //    }
                //    if (Tamanio == 7)
                //    {
                //        txtExpediente.Text = "000" + txtExpediente.Text;
                //    }
                //    if (Tamanio == 6)
                //    {
                //        txtExpediente.Text = "0000" + txtExpediente.Text;
                //    }

                if (rgx.Match(txtExpediente.Text).Success)
                {
                }
                else {
                    lblError.Text = "INGRESE 5 NÚMEROS PARA EXPEDIENTE Y 4 NÚMEROS PARA EL AÑO SIN DEJAR ESPACIOS EN BLANCO. EJEMPLO: 00001/2017";
                }
            }
            //valida fecha de inicio e incompetencia
            SqlCommand sqlValidar = new SqlCommand("ValidarFechaVehiculo ", Data.CnnCentral);
            sqlValidar.CommandType = CommandType.StoredProcedure;
            sqlValidar.Parameters.Add("@FechaInicio", SqlDbType.DateTime);
            sqlValidar.Parameters.Add("@FechaHecho", SqlDbType.DateTime);

            sqlValidar.Parameters["@FechaInicio"].Value = DateTime.Parse(txtFechaInicio1.Text);
            sqlValidar.Parameters["@FechaHecho"].Value = DateTime.Parse(txtFechaInicio.Text);

            SqlDataReader drValida = sqlValidar.ExecuteReader();
            if (drValida.HasRows)
            {
                drValida.Read();
                Valor = drValida["Valor"].ToString();

            }
            drValida.Close();

            if (Valor == "0")
            {
                lblError.Text = "1";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('FECHA DE INCOMPETENCIA NO PUEDE SER MAYOR A LA FECHA DE INICIO DE LA CARPETA.')", true);
            }

            if (lblError.Text == "")
            {
                try
                {
                
                PGJ.InsertaDatosIncompetencia(int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlArea.SelectedValue.ToString()), txtExpediente.Text, DateTime.Parse(txtFechaInicio.Text));


                lblEstatus.Text = "DATOS GUARDADOS";
                cmdGu.Visible = false;
                lblDelitos.Visible = true;
                IBAgregarDelito.Visible = true;
                    if (Session["op"].ToString() == "Agregar")
                    {
                        //cmdContinuar.Visible = true;
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2,
                        "Inserta Datos Incompetencia, Area: " + ddlArea.SelectedItem + " Expediente: " + txtExpediente.Text + " FechaInicio: " + txtFechaInicio.Text + " IdCarpeta: " + Session["ID_CARPETA"].ToString()
                        , int.Parse(Session["IdModuloBitacora"].ToString()));
                    }
                    else {
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3,
                        "Actualizo Datos Incompetencia, Area: " + ddlArea.SelectedItem + " Expediente: " + txtExpediente.Text + " FechaInicio: " + txtFechaInicio.Text + " IdCarpeta: " + Session["ID_CARPETA"].ToString()
                        , int.Parse(Session["IdModuloBitacora"].ToString()));
                    }
                }
                catch (Exception ex)
                {
                                    lblEstatus.Text = ex.Message;
                                    lblEstatus1.Text = "INTENTELO NUEVAMENTE";

                }

            }

        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            try
            {
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));

                if (lblArbol.Text == "2")
                {
                    Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString());
                }

                else if (lblArbol.Text == "3")
                {
                    Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
                }

                else if (lblArbol.Text == "8")
                {
                    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                }

                else if (lblArbol.Text == "5")
                {
                    Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
                }
                else if (lblArbol.Text == "6")
                {
                    if (Session["ID_PUESTO"].ToString() == "17")
                    {
                        Response.Redirect("OrdenCoordPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                    else if (Session["ID_PUESTO"].ToString() == "8")
                    {
                        Response.Redirect("OrdenPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                }
                else if (lblArbol.Text == "7")
                {
                    Response.Redirect("NUM_ACUERDOS.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

        protected void cmdContinuar_Click(object sender, EventArgs e)
        {
            
            //validar si es ID_ESTADO_NUC O ID_ESTADO_RAC
            Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);


            try
            {
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 9, "Click en Boton CONTINUAR, lugar de hechos", int.Parse(Session["IdModuloBitacora"].ToString()));
                if (lblArbol.Text == "2")
                {
                    Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_RAC=" + 10);
                }
                else if (lblArbol.Text == "4")
                {
                    Response.Redirect("LugarHechos.aspx?&op=Agregar" + "&ID_ESTADO_NUC=" + 10);
                }

            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
        }

        protected void IBAgregarDelito_Click(object sender, ImageClickEventArgs e)
        {
            lblDelitos.Visible = true;
            ddlDelito.Visible = true;
            Button1.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblErrorDelito.Text = "";
             String cadenaCombo = "--SELECCIONA--";
            if (ddlDelito.SelectedItem.ToString().Contains(cadenaCombo))
            {
                lblErrorDelito.Text = "SELECCIONE DELITO";
            }

            if (lblErrorDelito.Text == "")
            {

                try
                {
                    //InsertaDatosIncompetencia(int IdCarpeta, int IdMunicipio, int IdArea, string Expediente, DateTime FechaInicio)
                    PGJ.InsertaDatosIncompetenciaDelito(int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ddlDelito.SelectedValue.ToString()));
                    //PGJ.InsertarBitacora(int ID_USUARIO,  string IP, string URL, int ID_TIPO_MOVIMIENTO, string MOVIMIENTO, int ID_MODULO)

                    lblEstatusDelito.Text = "DATOS GUARDADOS";
                    lblDelitos.Visible = false;
                    ddlDelito.Visible = false;
                    //cmdGu.Visible = false;
                    //lblDelitos.Visible = true;
                    //IBAgregarDelito.Visible = true;
                    //cmdContinuar.Visible = true;
                    GridDelito.DataSourceID = "dsBuscaDelitoIncompetencia";
                    GridDelito.DataBind();
                    GridDelito.Visible = true;
                    Button1.Visible = false;
                    if (Session["op"].ToString() == "Agregar")
                    {
                        cmdContinuar.Visible = true;
                    }

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2,
                    "Inserta Datos delitos de la incompetencia, Delito: " + ddlDelito.SelectedItem + " IdCarpeta: " + Session["ID_CARPETA"].ToString()
                    , int.Parse(Session["IdModuloBitacora"].ToString()));

                }
                catch (Exception ex)
                {
                    lblEstatusDelito.Text = ex.Message;
                    lblEstatus1Delito.Text = "INTENTELO NUEVAMENTE";

                }
            }

        }

    }
}