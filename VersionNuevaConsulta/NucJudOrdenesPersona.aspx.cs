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
using System.IO;
using System.Text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;


namespace AtencionTemprana
{
    public partial class NucJudOrdenesPersona : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {



                Session["op"] = Request.QueryString["op"];
                Session["IdOrden"] = Request.QueryString["IdOrden"];

                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();

                string Sql = "SELECT p.ID_PERSONA , IMPUTADO=p.NOMBRE+' '+p.PATERNO+' '+p.MATERNO ";
                Sql = Sql + "FROM PGJ_PERSONA p ";
                Sql = Sql + "inner join PGJ_CARPETA_PERSONA  pc on pc.ID_PERSONA= p.ID_PERSONA ";
                Sql = Sql + "where pc.ID_TIPO_ACTOR=3 and pc.ID_CARPETA=" + IdCarpeta.Text;
                SqlCommand CmdImputado = new SqlCommand(Sql, Data.CnnCentral);
                SqlDataReader DR = CmdImputado.ExecuteReader();
                if (DR.HasRows)
                {
                    CboImputado.DataSource = DR;
                    CboImputado.DataValueField = "ID_PERSONA";
                    CboImputado.DataTextField = "IMPUTADO";
                    CboImputado.DataBind();
                }
                DR.Close();

                //PGJ.CargaCombo(CboEtapaOrden, "CAT_ETAPA_ORDEN", "ID_ETAPA_ORDEN", "ETAPA_ORDEN");
                //PGJ.CargaCombo(CboJuzgadoAmparo, "CAT_DISTRITO_JUDICIAL", "ID_DISTRITO", "DISTRITO");
                PGJ.CargaCombo(CboJuzgadoAmparo, "CAT_JUZGADO", "IDJUZGADO", "JUZGADO");
                PGJ.CargaCombo(CboAutoridadOrden, "CAT_AUTORIDAD_ORDEN", "ID_AUTORIDAD_ORDEN", "AUTORIDAD_ORDEN");
                //CboAutoridadOrden.Items.Insert(0, "SELECCIONA");

                lblEstatus.Text = "";

                //PGJ.CargaCombo(CboDelito, "CAT_DELITO", "ID_DLTO", "DLTO");
                //PGJ.CargaCombo(CboModalidad, "CAT_MODALIDAD", "ID_MDLDD", "MDLDD");
                //PGJ.CargaCombo(CboJuzgado, "CAT_JUZGADO", "IDJUZGADO", "JUZGADO");

                //RanvalTxtFechaAmparo.MaximumValue = lblFecha.Text;
                //RanValTxtFechaAutoSuspension.MaximumValue = lblFecha.Text;
                //RanValTxtFechaCancelacion.MaximumValue = lblFecha.Text;
                //RanValTxtFechaDisposicion.MaximumValue = lblFecha.Text;
                //RanValTxtFechaEjecucion.MaximumValue = lblFecha.Text;
                //RanValTxtFechaResolucionAmparo.MaximumValue = lblFecha.Text;
                //RanValTxtFechaResolucionIncidente.MaximumValue = lblFecha.Text;
                ////RanValTxtFechaImputacion.MaximumValue = lblFecha.Text;
                ////RanValTxtFechaSobreseimiento.MaximumValue = lblFecha.Text;

                if (!PGJ.TieneImputados(Session["ID_CARPETA"].ToString()))
                {
                    lblEstatus.Text = "No se puede Judicializar la carpeta, no hay imputados registrados, registre al menos uno";
                    CmdOrdenPersona.Visible = false;
                    CmdDelito.Visible = false;
                }
                else if (PGJ.TieneQRR(Session["ID_CARPETA"].ToString()))
                {
                    lblEstatus.Text = "No se puede Judicializar la carpeta, modifique el imputado Quien Resulte Responsable";
                    CmdOrdenPersona.Visible = false;
                    CmdDelito.Visible = false;
                }

                if (Session["op"].ToString() == "Modificar")
                {
                    //FileUploadOrden.Visible = false;
                    //CmdOficioOrden.Text = "Consultar Oficio";
                    //ConsultaOrdenOficio();
                    CmdOrdenPersona.Text = "Modificar Orden";
                    ConsultaOrden();
                    CboImputado.Enabled = false;
                    CmdDelito.Visible = true;

                    if (GridDelitos.Rows.Count > 0)
                    {
                        CmdDelito.Visible = false;
                    }

                }

                if (OptEstadoOrden.SelectedValue.ToString() == "1")
                {
                    PanelAmparo.Visible = true;
                    PanelCumplimentada.Visible = false;
                    PanelCancelada.Visible = false;
                }
                if (OptEstadoOrden.SelectedValue.ToString() == "2")
                {
                    PanelAmparo.Visible = false;
                    PanelCumplimentada.Visible = true;
                    PanelCancelada.Visible = false;

                    OptEstadoOrden.Enabled = false;
                    CmdOrdenPersona.Visible = false;
                    CmdDelito.Visible = false;
                }
                if (OptEstadoOrden.SelectedValue.ToString() == "3")
                {
                    PanelAmparo.Visible = false;
                    PanelCumplimentada.Visible = false;
                    PanelCancelada.Visible = true;

                    OptEstadoOrden.Enabled = false;
                    CmdOrdenPersona.Visible = false;
                    CmdDelito.Visible = false;
                }

                if (CboAutoridadOrden.SelectedItem.Text == "OTRO")
                {
                    LblAutoridad.Visible = true;
                    TxtAutoridadOtro.Visible = true;
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

        protected void ValidaFechas(int Valor)
        {

            if (CboAutoridadOrden.SelectedValue == "SELECCIONA")
            {
                //CboAutoridadOrden.SelectedItem.Text = "";
                CboAutoridadOrden.SelectedValue = "0"; // MODIFICAR A -1
            }
            
            if (Valor == 0)
            {
                if (TxtFechaEjecucion.Text.Trim() == "")
                {
                    TxtFechaEjecucion.Text = "01/01/1900 00:00";
                }
                if (TxtFechaCancelacion.Text.Trim() == "")
                {
                    TxtFechaCancelacion.Text = "01/01/1900 00:00";
                }
                if (TxtFechaDisposicion.Text.Trim() == "")
                {
                    TxtFechaDisposicion.Text = "01/01/1900 00:00";
                }
                if (TxtFechaAmparo.Text.Trim() == "")
                {
                    TxtFechaAmparo.Text = "01/01/1900 00:00";
                }
                if (TxtFechaAutoSuspension.Text.Trim() == "")
                {
                    TxtFechaAutoSuspension.Text = "01/01/1900 00:00";
                }
                if (TxtFechaResolucionIncidente.Text.Trim() == "")
                {
                    TxtFechaResolucionIncidente.Text = "01/01/1900 00:00";
                }
                if (TxtFechaResolucionAmparo.Text.Trim() == "")
                {
                    TxtFechaResolucionAmparo.Text = "01/01/1900 00:00";
                }
            }
            else
            {
                if (TxtFechaEjecucion.Text.Trim() == "01/01/1900 00:00")
                {
                    TxtFechaEjecucion.Text = "";
                }
                if (TxtFechaCancelacion.Text.Trim() == "01/01/1900 00:00")
                {
                    TxtFechaCancelacion.Text = "";
                }
                if (TxtFechaDisposicion.Text.Trim() == "01/01/1900 00:00")
                {
                    TxtFechaDisposicion.Text = "";
                }
                if (TxtFechaAmparo.Text.Trim() == "01/01/1900 00:00")
                {
                    TxtFechaAmparo.Text = "";
                }
                if (TxtFechaAutoSuspension.Text.Trim() == "01/01/1900 00:00")
                {
                    TxtFechaAutoSuspension.Text = "";
                }
                if (TxtFechaResolucionIncidente.Text.Trim() == "01/01/1900 00:00")
                {
                    TxtFechaResolucionIncidente.Text = "";
                }
                if (TxtFechaResolucionAmparo.Text.Trim() == "01/01/1900 00:00")
                {
                    TxtFechaResolucionAmparo.Text = "";
                }
            }
        }

        public int ValidaDatos()
        {
            lblEstatus.Text = "";

            if (OptEstadoOrden.SelectedValue == "")
            {
                lblEstatus.Text = "No ha seleccionado estado de la Orden. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && TxtFechaAmparo.Text.Trim() != "" && DateTime.Parse(TxtFechaAmparo.Text) > System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha de notificación de Amparo NO Válida. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && TxtFechaAmparo.Text.Trim() != "" && TxtNumeroAmparo.Text.Trim()=="")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado el número de Amparo. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && TxtFechaAmparo.Text.Trim() != "" && CboJuzgadoAmparo.SelectedItem.Text == "-- SELECCIONA --")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha seleccionado el Juzgado del Amparo. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && OptSuspensionProvisional.SelectedValue == "1" && TxtFechaAutoSuspension.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado la Fecha Auto Suspensión. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && OptSuspensionProvisional.SelectedValue == "1" && DateTime.Parse(TxtFechaAutoSuspension.Text) > System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha de Auto Suspensión NO Válida. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && OptSuspensionDefinitiva.SelectedValue == "1" && TxtFechaResolucionIncidente.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado la Fecha notificación resolucion Incidente. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && OptSuspensionDefinitiva.SelectedValue == "1" && DateTime.Parse(TxtFechaResolucionIncidente.Text) > System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha de notificación resolucion Incidente NO Válida. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && OptAmparoConcedido.SelectedValue == "1" && TxtFechaResolucionAmparo.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado la Fecha resolucion del Amparo. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "1" && OptAmparoConcedido.SelectedValue == "1" && DateTime.Parse(TxtFechaResolucionAmparo.Text) > System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha de resolucion del Amparo NO Válida. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "2" && TxtFechaEjecucion.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado la fecha de Ejecución. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "2" && DateTime.Parse(TxtFechaEjecucion.Text) > System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha de Ejecución de la Orden NO Válida. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "2" && CboAutoridadOrden.SelectedItem.Text == "-- SELECCIONA --")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha seleccionado la autoridad que ejecutó la orden. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "2" && TxtFechaDisposicion.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha seleccionado la fecha en que se puso a disposición de Juez. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "2" && DateTime.Parse(TxtFechaDisposicion.Text) > System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha en que se puso a disposición de Juez NO Válida. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "3" && TxtFechaCancelacion.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha ingresado la fecha de Cancelacion. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "3" && DateTime.Parse(TxtFechaCancelacion.Text) > System.DateTime.Now)
            {
                lblEstatus.Text = lblEstatus.Text + "Fecha de Cancelación de la Orden NO Válida. ";
                return 0;
            }
            else if (OptEstadoOrden.SelectedValue == "3" && OptMotivoCancelacion.SelectedValue == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha seleccionado motivo de la cancelación. ";
                return 0;
            }
            else
            {
                lblEstatus.Text = "";
                return 1;
            }
        }

        protected void CmdOrdenPersona_Click(object sender, EventArgs e)
        {

            if (ValidaDatos()== 1)
            {

                ValidaFechas(0);

                if (Session["op"].ToString() == "Modificar")
                {
                    //string fecha = DateTime.ParseExact("2012/09/14 10:22:37", "yyyy/MM/dd HH:mm:ss", null).ToString("dd/MM/yyyy HH:mm:ss");


                    Archivos.ModificaPGJNucJudOrdenPersona(int.Parse(Session["IdOrden"].ToString()), int.Parse(OptEstadoOrden.SelectedValue), OptMotivoCancelacion.SelectedValue=="" ? -1 : int.Parse(OptMotivoCancelacion.SelectedValue), 
                        DateTime.Parse(TxtFechaEjecucion.Text), DateTime.Parse(TxtFechaCancelacion.Text), DateTime.Parse(TxtFechaDisposicion.Text), int.Parse(CboAutoridadOrden.SelectedValue), TxtAutoridadOtro.Text.ToUpper(), DateTime.Parse(TxtFechaAmparo.Text),
                        TxtNumeroAmparo.Text, short.Parse(CboJuzgadoAmparo.SelectedValue), TxtJuezNombreAmparo.Text.ToUpper(), TxtJuezPaternoAmparo.Text.ToUpper(), TxtJuezMaternoAmparo.Text.ToUpper(),
                        OptSuspensionProvisional.SelectedValue == "" ? -1 : int.Parse(OptSuspensionProvisional.SelectedValue), DateTime.Parse(TxtFechaAutoSuspension.Text),
                        OptSuspensionDefinitiva.SelectedValue == "" ? -1 : int.Parse(OptSuspensionDefinitiva.SelectedValue), DateTime.Parse(TxtFechaResolucionIncidente.Text),
                        OptAmparoConcedido.SelectedValue == "" ? -1 : int.Parse(OptAmparoConcedido.SelectedValue), DateTime.Parse(TxtFechaResolucionAmparo.Text),
                        TxtEfectosAmparo.Text, TxtObservaciones.Text.ToUpper(), int.Parse(Session["IdUsuario"].ToString()));

                    lblEstatus.Text = "Los datos de la Orden han sido Modificados";

                    //SqlCommand sqlModificaOrden = new SqlCommand("update PGJ_NUC_JUD_ORDEN_PERSONA set ID_ESTADO_ORDEN=" + OptEstadoOrden.SelectedValue + " , ID_MOTIVO_CANCELACION=" + (OptEstadoOrden.SelectedValue.ToString() == "3" ? OptMotivoCancelacion.SelectedValue : "NULL") + " , ID_ETAPA_ORDEN=" + CboEtapaOrden.SelectedValue + " , FECHA_EJECUCION=" + (TxtFechaEjecucion.Text.Trim() == "" ? "NULL" : "'" + TxtFechaEjecucion.Text + "'") + ", FECHA_CANCELACION=" + (TxtFechaCancelacion.Text.Trim() == "" ? "NULL" : "'" + TxtFechaCancelacion.Text + "'") + ", FECHA_PRESCRIPCION=" + (TxtFechaDisposicion.Text.Trim() == "" ? "NULL" : "'" + TxtFechaDisposicion.Text + "'") + ", FECHA_AMPARO=" + (TxtFechaAmparo.Text.Trim() == "" ? "NULL" : "'" + TxtFechaAmparo.Text + "'") + ", FECHA_APELACION=" + (TxtFechaApelacion.Text.Trim() == "" ? "NULL" : "'" + TxtFechaApelacion.Text + "'") + ", FECHA_SOLICITUD_APELACION=" + (TxtFechaSolicitudApelacion.Text.Trim() == "" ? "NULL" : "'" + TxtFechaSolicitudApelacion.Text + "'") + " , OBSERVACIONES='" + TxtObservaciones.Text + "' where ID_ORDEN=" + Session["IdOrden"].ToString(), Data.CnnCentral);
                    //SqlDataReader rdC = sqlModificaOrden.ExecuteReader();
                    //rdC.Close();

                }
                else
                {
                    //string Sql = "Set DateFormat dmy exec InsertaPGJ_NUC_JUD_ORDEN_PERSONA " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + ", " + int.Parse(Session["IdOrdenOficio"].ToString()) + ", " + OptEstadoOrden.SelectedValue + ", " + OptMotivoCancelacion.SelectedValue + "," + CboEtapaOrden.SelectedValue + ",'" + TxtFechaEjecucion.Text + "','" + TxtFechaCancelacion.Text + "','" + TxtFechaDisposicion.Text + "','" + TxtFechaAmparo.Text + "','" + TxtFechaApelacion.Text + "','" + TxtFechaSolicitudApelacion.Text + "','" + TxtObservaciones.Text + "'," + Session["IdUsuario"].ToString();                

                    //SqlCommand SqlOrdenPersona = new SqlCommand(Sql, Data.CnnCentral);
                    ////SqlOrdenPersona.ExecuteReader();
                    //SqlDataReader drOrdenPersona = SqlOrdenPersona.ExecuteReader();

                    //if (drOrdenPersona.HasRows)
                    //{
                    //    drOrdenPersona.Read();
                    //    Session["IdOrden"] = drOrdenPersona["IdOrden"].ToString();
                    //}

                    //drOrdenPersona.Close();

                                            //DateTime.Parse(TxtFechaEjecucion.Text), DateTime.Parse(TxtFechaCancelacion.Text), DateTime.Parse(TxtFechaDisposicion.Text), int.Parse(CboAutoridadOrden.SelectedValue), TxtAutoridadOtro.Text, DateTime.Parse(TxtFechaAmparo.Text),
                    Session["IdOrden"] = Convert.ToString(Archivos.InsertaPGJNucJudOrdenPersona(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()), int.Parse(CboImputado.SelectedValue),
                        int.Parse(Session["IdOrdenOficio"].ToString()), int.Parse(OptEstadoOrden.SelectedValue), OptMotivoCancelacion.SelectedValue=="" ? -1 : int.Parse(OptMotivoCancelacion.SelectedValue), 
                        DateTime.Parse(TxtFechaEjecucion.Text), DateTime.Parse(TxtFechaCancelacion.Text), DateTime.Parse(TxtFechaDisposicion.Text), int.Parse(CboAutoridadOrden.SelectedValue), TxtAutoridadOtro.Text.ToUpper(), DateTime.Parse(TxtFechaAmparo.Text),
                        TxtNumeroAmparo.Text, short.Parse(CboJuzgadoAmparo.SelectedValue), TxtJuezNombreAmparo.Text.ToUpper(), TxtJuezPaternoAmparo.Text.ToUpper(), TxtJuezMaternoAmparo.Text.ToUpper(),
                        OptSuspensionProvisional.SelectedValue == "" ? -1 : int.Parse(OptSuspensionProvisional.SelectedValue), DateTime.Parse(TxtFechaAutoSuspension.Text),
                        OptSuspensionDefinitiva.SelectedValue == "" ? -1 : int.Parse(OptSuspensionDefinitiva.SelectedValue), DateTime.Parse(TxtFechaResolucionIncidente.Text),
                        OptAmparoConcedido.SelectedValue == "" ? -1 : int.Parse(OptAmparoConcedido.SelectedValue), DateTime.Parse(TxtFechaResolucionAmparo.Text),
                        TxtEfectosAmparo.Text, TxtObservaciones.Text.ToUpper(), int.Parse(Session["IdUsuario"].ToString())));

                    lblEstatus.Text = "La Orden por este imputado ha sido registrada. Agregue los delitos de la Orden";

                    CmdOrdenPersona.Text = "Modificar Orden";
                    CmdOrdenPersona.Visible = false;
                    CboImputado.Enabled = false;
                    CmdDelito.Visible = true;

                }

                if (OptEstadoOrden.SelectedValue == "2")
                {
                    /////////////////////////////// orden ejecutada
                    Session["ID_ESTADO_NUC"] = 123;
                    SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=123 , FECHA_ESTADO_NUC='" + string.Format("{0:dd/MM/yyyy HH:mm}", TxtFechaEjecucion.Text) + "' where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                    SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
                    rdC.Close();
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=123 FechaEstadoNuc= " + string.Format("{0:dd/MM/yyyy HH:mm}", TxtFechaEjecucion.Text), int.Parse(Session["IdModuloBitacora"].ToString()));
                    ///////////////////////////////////////////////
                }

                ValidaFechas(1);

            }

            //Response.Redirect("NucJudordenes.aspx?IdOrdenOficio=" + Session["IdOrdenOficio"].ToString() + "&op=Modificar");
        }

        private void ConsultaOrden()
        {

            lblEstatus.Text = "";

            string Sql = "SELECT * FROM PGJ_NUC_JUD_ORDEN_PERSONA  WHERE ID_ORDEN=" + Session["IdOrden"].ToString();
            SqlCommand CmdOrden = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader DR = CmdOrden.ExecuteReader();
            if (DR.HasRows)
            {
                DR.Read();

                CboImputado.SelectedValue = DR["ID_PERSONA"].ToString();
                OptEstadoOrden.SelectedValue = DR["ID_ESTADO_ORDEN"].ToString();

                if (DR["ID_MOTIVO_CANCELACION"] != null)
                {
                    OptMotivoCancelacion.SelectedValue = DR["ID_MOTIVO_CANCELACION"].ToString();
                }

                TxtFechaEjecucion.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA_EJECUCION"]);
                //TxtFechaCancelacion.Text = DR["FECHA_CANCELACION"].ToString();
                ////////////////TxtFechaCancelacion.Text = string.Format("{0:d}", DR["FECHA_CANCELACION"]);
                TxtFechaCancelacion.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA_CANCELACION"]);

                TxtFechaDisposicion.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA_DISPOSICION"]);
                CboAutoridadOrden.SelectedValue = DR["ID_AUTORIDAD_ORDEN"].ToString();
                TxtAutoridadOtro.Text = DR["OTRA_AUTORIDAD"].ToString();
                TxtFechaAmparo.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA_AMPARO"]);

                TxtObservaciones.Text = DR["OBSERVACIONES"].ToString();

                TxtNumeroAmparo.Text = DR["NUMERO_AMPARO"].ToString();
                CboJuzgadoAmparo.SelectedValue=DR["ID_JUZGADO_AMPARO"].ToString();
                TxtJuezNombreAmparo.Text=DR["JUEZNOMBRE_AMPARO"].ToString();
                TxtJuezPaternoAmparo.Text = DR["JUEZPATERNO_AMPARO"].ToString();
                TxtJuezMaternoAmparo.Text = DR["JUEZMATERNO_AMPARO"].ToString();
                //OptSuspensionProvisional.SelectedValue=DR["SUSPENSION_PROVISIONAL"].ToString();
                //lblEstatus.Text = DR["SUSPENSION_PROVISIONAL"].ToString();
                //if (DR["SUSPENSION_PROVISIONAL"].ToString() == "True")
                //{
                //    OptSuspensionProvisional.SelectedValue = "1";
                //}
                //else
                //{
                //    OptSuspensionProvisional.SelectedValue = "0";
                //}
                OptSuspensionProvisional.SelectedValue = (DR["SUSPENSION_PROVISIONAL"].ToString() == "True" ? "1" : "0");
                TxtFechaAutoSuspension.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA_AUTO_SUSPENSION"]);
                OptSuspensionDefinitiva.SelectedValue = (DR["SUSPENSION_DEFINITIVA"].ToString() == "True" ? "1" : "0");
                TxtFechaResolucionIncidente.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA_RESOLUCION_INCIDENTE"]);
                OptAmparoConcedido.SelectedValue = (DR["AMPARO_CONCEDIDO"].ToString() == "True" ? "1" : "0");
                TxtFechaResolucionAmparo.Text = string.Format("{0:dd/MM/yyyy HH:mm}", DR["FECHA_RESOLUCION_AMPARO"]);

                TxtEfectosAmparo.Text = DR["EFECTOS_AMPARO"].ToString();

                //CboImputado.DataSource = DR;
                //CboImputado.DataValueField = "ID_PERSONA";
                //CboImputado.DataTextField = "IMPUTADO";
                //CboImputado.DataBind();
            }
            DR.Close();
        }

        protected void CmdDelito_Click(object sender, EventArgs e)
        {
            Response.Redirect("NucJudOrdenDelito.aspx?IdOrden=" + Session["IdOrden"].ToString() + "&op=Agregar");
        }

        protected void CmdRegresar_Click(object sender, EventArgs e)
        {

            //if (GridDelitos.Rows.Count == 0)
            //{
            //    if (CmdOrdenPersona.Text=="Registrar Orden")
            //    {
            //        Response.Redirect("NucJudordenes.aspx?IdOrdenOficio=" + Session["IdOrdenOficio"].ToString() + "&op=Modificar");
            //    }
            //        else
            //    {
            //        lblEstatus.Text = "No ha registrado los Delitos de la Orden";
            //    }
            //}
            //else
            //{
            //    Response.Redirect("NucJudordenes.aspx?IdOrdenOficio=" + Session["IdOrdenOficio"].ToString() + "&op=Modificar");
            //}

            if (!PGJ.TieneDelitoOrden(Session["IdOrden"].ToString()))
            {
                lblEstatus.Text = "No ha registrado los Delitos de la Orden";
            }
            else
            {
                Session["IdOrden"] = "0";
                Response.Redirect("NucJudordenes.aspx?IdOrdenOficio=" + Session["IdOrdenOficio"].ToString() + "&op=Modificar");
            }

            
        }

        protected void ActivarMotivoCancelacion(object sender, EventArgs e)
        {
            if (OptEstadoOrden.SelectedValue.ToString() == "1")
            {
                PanelAmparo.Visible = true;
                PanelCumplimentada.Visible = false;
                PanelCancelada.Visible = false;
            }
            if (OptEstadoOrden.SelectedValue.ToString() == "2")
            {
                PanelAmparo.Visible = false;
                PanelCumplimentada.Visible = true;
                PanelCancelada.Visible = false;
            }
            if (OptEstadoOrden.SelectedValue.ToString() == "3")
            {
                PanelAmparo.Visible = false;
                PanelCumplimentada.Visible = false;
                PanelCancelada.Visible = true;
            }
        }

        protected void ActivarAutoridadOtra(object sender, EventArgs e)
        {
            if (CboAutoridadOrden.SelectedItem.Text== "OTRO")
            {
                LblAutoridad.Visible = true;
                TxtAutoridadOtro.Visible = true;
            }
            else
            {
                LblAutoridad.Visible = false;
                TxtAutoridadOtro.Visible = false;
            }
        }

    }
}