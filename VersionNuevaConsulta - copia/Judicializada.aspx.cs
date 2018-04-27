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
    public partial class Judicializada : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");

            if (!Page.IsPostBack)
            {

                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                //Session["ID_CARPETA"] = Request.QueryString["ID_CARPETA"];
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
           
                string Sql= "SELECT p.ID_PERSONA , IMPUTADO=p.NOMBRE+' '+p.PATERNO+' '+p.MATERNO ";
                Sql=Sql+"FROM PGJ_PERSONA p ";
                Sql=Sql+"inner join PGJ_CARPETA_PERSONA  pc on pc.ID_PERSONA= p.ID_PERSONA ";
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

                PGJ.CargaCombo(CboDelito, "CAT_DELITO", "ID_DLTO", "DLTO");
                PGJ.CargaCombo(CboModalidad, "CAT_MODALIDAD", "ID_MDLDD", "MDLDD");
                PGJ.CargaCombo(CboCalificacion, "CAT_CALIFICACION", "ID_CALIFICACION", "CALIFICACION");

                PGJ.CargaCombo(CboMedidaCautelar, "CAT_MEDIDA_CAUTELAR", "ID_MEDIDA_CAUTELAR", "MEDIDA_CAUTELAR");
                PGJ.CargaCombo(CboMedidaProteccion, "CAT_MEDIDA_PROTECCION", "ID_MEDIDA_PROTECCION", "MEDIDA_PROTECCION");

                PGJ.CargaCombo(CboEstadoOrden, "CAT_ESTADO_ORDEN", "ID_ESTADO_ORDEN", "ESTADO_ORDEN");
                PGJ.CargaCombo(CboTipoOrden, "CAT_TIPO_ORDEN", "IdTipoOrden", "TipoOrden");
                //CboTipoOrden.Items.Add("APREHENSION");
                //CboTipoOrden.Items.Add("COMPARECENCIA");
                ////CboTipoOrden.Items.Insert(0, "APREHENSION");
                ////CboTipoOrden.Items.Insert(1, "COMPARECENCIA");

                //------ SENTENCIA

                PGJ.CargaCombo(CboDelitoSentencia, "CAT_DELITO", "ID_DLTO", "DLTO");
                PGJ.CargaCombo(CboTipoSentencia, "CAT_TIPO_SENTENCIA", "ID_TIPO_SENTENCIA", "TIPO_SENTENCIA");
                PGJ.CargaCombo(CboSancion, "CAT_TIPO_SANCION", "ID_TIPO_SANCION", "TIPO_SANCION");

                string SqlOfendido = "SELECT p.ID_PERSONA , OFENDIDO=p.NOMBRE+' '+p.PATERNO+' '+p.MATERNO ";
                SqlOfendido = SqlOfendido + "FROM PGJ_PERSONA p ";
                SqlOfendido = SqlOfendido + "inner join PGJ_CARPETA_PERSONA  pc on pc.ID_PERSONA= p.ID_PERSONA ";
                SqlOfendido = SqlOfendido + "where pc.ID_TIPO_ACTOR=2 and pc.ID_CARPETA=" + IdCarpeta.Text;
                SqlCommand CmdOfendido = new SqlCommand(SqlOfendido, Data.CnnCentral);
                SqlDataReader DROfendido = CmdOfendido.ExecuteReader();
                if (DROfendido.HasRows)
                {
                    CboOfendido.DataSource = DROfendido;
                    CboOfendido.DataValueField = "ID_PERSONA";
                    CboOfendido.DataTextField = "OFENDIDO";
                    CboOfendido.DataBind();
                }
                DROfendido.Close();

                //RanValTxtFechaImputacion.MaximumValue = lblFecha.Text;
                //RanValTxtFechaSobreseimiento.MaximumValue = lblFecha.Text;

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

        protected void CmdImputacion_Click(object sender, EventArgs e)
        {

            if (OptImputacion.SelectedValue == "1")
            {
                SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=112 , FECHA_ESTADO_NUC='" + TxtFechaImputacion.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
                rdC.Close();

                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=112 FechaEstadoNuc= " + TxtFechaImputacion.Text , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            }

            if (OptProceso.SelectedValue == "1")
            {
                SqlCommand sqlEstadoCarpeta2 = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=113 , FECHA_ESTADO_NUC='" + TxtFechaVinculacion.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC2 = sqlEstadoCarpeta2.ExecuteReader();
                rdC2.Close();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=113 FechaEstadoNuc= " + TxtFechaVinculacion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            }       

            string Sql = "Set DateFormat dmy exec InsertaImputacion " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + "," + OptImputacion.SelectedValue + ", '" + TxtFechaImputacion.Text + "','" + TxtObservacionesImputacion.Text.ToUpper() + "'," + OptProceso.SelectedValue + ",'" + TxtFechaVinculacion.Text + "',null," + Session["IdUsuario"].ToString() ;
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Imputacion IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Se realiza Imputacion: " +  OptImputacion.SelectedValue + " Fecha Impuacion: " + TxtFechaImputacion.Text  + " Observaciones: " + TxtObservacionesImputacion.Text.ToUpper() + " Se vinculo a proceso: " + OptProceso.SelectedItem + " Fecha Vinculacion: " + TxtFechaVinculacion.Text , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            //SqlCommand SqlImputacion = new SqlCommand(Sql, Data.CnnCentral);
            //SqlDataReader drImputacion = SqlImputacion.ExecuteReader();

            //if (drImputacion.HasRows)
            //{
            //    IdImputacion.Text = drImputacion["IdImputacion"].ToString();
            //}

            //drImputacion.Close();

            SqlDataAdapter daImputacion = new SqlDataAdapter(Sql, Data.CnnCentral);
            DataSet dsImputacion = new DataSet();
            daImputacion.Fill(dsImputacion, "Imputacion");
            foreach (DataRow drImputacion in dsImputacion.Tables["Imputacion"].Rows)
            {
                IdImputacion.Text = drImputacion["IdImputacion"].ToString();
            }
            daImputacion.Dispose();
            dsImputacion.Dispose();

            if (OptImputacion.SelectedValue == "1" && OptProceso.SelectedValue == "1")
            {
                LblMensaje.Visible = true;
                CmdAgregarDelito.Visible = true;
            }

            if (OptImputacion.SelectedValue == "1" && OptProceso.SelectedValue == "0")
            {
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 112);
            //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 18);
            }


        }

        protected void CmdAgregarDelito_Click(object sender, EventArgs e)
        {
            SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=113 , FECHA_ESTADO_NUC='" + TxtFechaVinculacion.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
            rdC.Close();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=113 FechaEstadoNuc= " + TxtFechaVinculacion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            //LstDelito.Items.Add(new ListItem(CboDelito.SelectedItem.Text, CboDelito.SelectedValue));

            string Sql = "exec InsertaVinculacionDelitos " + IdImputacion.Text + "," + CboDelito.SelectedValue + "," + CboModalidad.SelectedValue + ",1";
            //string Sql = "exec InsertaVinculacionDelitos " + IdImputacion.Text + "," + CboDelito.SelectedValue + "," + CboModalidad.SelectedValue + "," + CboCalificacion.SelectedValue;
            SqlCommand SqlVinculacionDelitos = new SqlCommand(Sql, Data.CnnCentral);
            SqlVinculacionDelitos.ExecuteReader();
            //SqlDataReader drVinculacionDelitos = SqlVinculacionDelitos.ExecuteReader();

            //drVinculacionDelitos.Close();
            //drVinculacionDelitos.Dispose();

            gridDelitos.DataBind();

            //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 113);
        }

        protected void CmdDetencion_Click(object sender, EventArgs e)
        {

            SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=111 , FECHA_ESTADO_NUC='" + TxtFechaDetencion.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
            rdC.Close();

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=111 FechaEstadoNuc= " + TxtFechaDetencion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            string Sql = "Set DateFormat ymd exec InsertaDetencion " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + ", '" + TxtFechaAudiencia.Text + "'," + OptCalificacionDetencion.SelectedValue +  ",'" + TxtObservacionesDetencion.Text.ToUpper() + "'," + OptProcedimientoDetencion.SelectedValue + ",'" + TxtFechaDetencion.Text + "'," + OptSupuestoFlagrancia.SelectedValue + "," + Session["IdUsuario"].ToString();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Detencion IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Fecha Audiencia: " + TxtFechaAudiencia.Text + " Calificacion Detencion: " + OptCalificacionDetencion.SelectedValue + " Observaciones: " + TxtObservacionesDetencion.Text.ToUpper() + " Procedimiento: " + OptProcedimientoDetencion.SelectedItem + " Fecha Detencion: " + TxtFechaDetencion.Text + " Suspuestos de flagrancia:" + OptSupuestoFlagrancia.SelectedItem , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            SqlCommand SqlDetencion = new SqlCommand(Sql, Data.CnnCentral);
            SqlDetencion.ExecuteReader();
            SqlDetencion.Dispose();
            //SqlDataReader drDetencion = SqlDetencion.ExecuteReader();

            //drDetencion.Close();

            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 111);

        }

        protected void CmdSuspencion_Click(object sender, EventArgs e)
        {

            SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=114 , FECHA_ESTADO_NUC='" + TxtFechaSuspencion.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
            rdC.Close();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=114 FechaEstadoNuc= " + TxtFechaSuspencion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            

            string Sql = "Set DateFormat dmy exec InsertaSuspencion " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + ", " + OptSuspencion.SelectedValue + "," + OptRevocaSuspencion.SelectedValue + ",'" + TxtFechaSuspencion.Text + "','" + TxtFechaDel.Text + "','" + TxtFechaAl.Text + "','" + TxtFechaReanudacion.Text + "'," + Session["IdUsuario"].ToString();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Suspencion IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Suspención condicional: " + OptSuspencion.SelectedItem + " Revoco la Suspención: " + OptRevocaSuspencion.SelectedValue + " Fecha Suspencion: " + TxtFechaSuspencion.Text + " Periodo de Suspencion Del: " + TxtFechaDel.Text + " Al: " + TxtFechaAl.Text + " Feha Reanudación:" + TxtFechaReanudacion.Text , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            SqlCommand SqlSuspencion = new SqlCommand(Sql, Data.CnnCentral);
            SqlSuspencion.ExecuteReader();
            //SqlDataReader drSuspencion = SqlSuspencion.ExecuteReader();

            //drSuspencion.Close();

            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 114);

        }

        protected void CmdMedidaCautelar_Click(object sender, EventArgs e)
        {

            SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=115 , FECHA_ESTADO_NUC='" + TxtFechaMedida.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
            rdC.Close();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=113 FechaEstadoNuc= " + TxtFechaMedida.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            

            string Sql = "Set DateFormat dmy exec InsertaMedidaCautelar " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + ", " + OptProcedente.SelectedValue + ",'" + TxtFechaMedida.Text + "'," + CboMedidaCautelar.SelectedValue + ",'" + TxtFechaMedidaDel.Text + "','" + TxtFechaMedidaAl.Text + "'," + Session["IdUsuario"].ToString();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Medida Cautelar IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Medida Cautelar Procedente: " + OptProcedente.SelectedItem + " Fecha Medida: " + TxtFechaMedida.Text + " Tipo de Medida: " + CboMedidaCautelar.SelectedItem + " Temporalidad de la Medida Del: " + TxtFechaMedidaDel.Text + " Al: " + TxtFechaMedidaAl.Text , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            SqlCommand SqlMedidaCautelar = new SqlCommand(Sql, Data.CnnCentral);
            SqlMedidaCautelar.ExecuteReader();
            //SqlDataReader drMedidaCautelar = SqlMedidaCautelar.ExecuteReader();

            //drMedidaCautelar.Close();

            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 115);

        }

        public int ValidaDatosOrdenes()
        {
            lblEstatusOrdenes.Text = "";

            if (OptSolicitaOrden.SelectedValue == "")
            {
                lblEstatusOrdenes.Text = "No ha seleccionado la forma de Solicitud. ";
                return 0;
            }
            else if (TxtFechaOrden.Text.Trim() == "")
            {
                lblEstatusOrdenes.Text = lblEstatusOrdenes.Text + "No ha ingresado la fecha de solicitud de la Orden. ";
                return 0;
            }
            else if (DateTime.Parse(TxtFechaOrden.Text.Trim()) > DateTime.Now)
            {
                lblEstatusOrdenes.Text = lblEstatusOrdenes.Text + "La fecha de la solicitud de la Orden debe ser menor";
                return 0;
            }
            else if (CboTipoOrden.SelectedItem.Text == "-- SELECCIONA --")
            {
                lblEstatusOrdenes.Text = lblEstatusOrdenes.Text + "No ha seleccionado el tipo de Orden. ";
                return 0;
            }
            else
            {
                lblEstatusOrdenes.Text = "";
                return 1;
            }
        }

        protected void CmdOrdenes_Click(object sender, EventArgs e)
        {
            if (ValidaDatosOrdenes() == 1)
            {
                SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=117 , FECHA_ESTADO_NUC='" + TxtFechaOrden.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
                rdC.Close();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=117 FechaEstadoNuc= " + TxtFechaOrden.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                string Sql = "Set DateFormat dmy exec InsertaOrdenes " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + "," + OptSolicitaOrden.SelectedValue + ",'" + TxtFechaOrden.Text + "',0," + CboTipoOrden.SelectedValue + ",'" + TxtObservacionesOrden.Text.ToUpper() + "'," + Session["IdUsuario"].ToString();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Ordenes IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Se solicito Orden: " + OptSolicitaOrden.SelectedItem + " Fecha Orden: " + TxtFechaOrden.Text + " Estado Orden: " + CboEstadoOrden.SelectedItem + " Tipo de Orden: " + CboTipoOrden.SelectedItem + " Observaciones: " + TxtObservacionesOrden.Text.ToUpper(), int.Parse(Session["IdModuloBitacora"].ToString()));

                SqlCommand SqlOrdenes = new SqlCommand(Sql, Data.CnnCentral);
                SqlOrdenes.ExecuteReader();
                //SqlDataReader drMedidaCautelar = SqlMedidaCautelar.ExecuteReader();

                //drMedidaCautelar.Close();

                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 117);
            }

        }

        protected void CmdAcuerdoReparatorio_Click(object sender, EventArgs e)
        {

            SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=118 , FECHA_ESTADO_NUC='" + TxtFechaAcuerdo.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
            rdC.Close();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=118 FechaEstadoNuc= " + TxtFechaAcuerdo.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            string Sql = "Set DateFormat dmy exec InsertaAcuerdoReparatorio " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + "," + OptMediosAlternos.SelectedValue + "," + OptAcuerdoReparatorio.SelectedValue + ",'" + TxtFechaAcuerdo.Text + "','" + TxtFechaAprobacion.Text + "'," + OptTipoAcuerdo.SelectedValue + ",'" + TxtObservacionesAcuerdo.Text.ToUpper() + "'," + Session["IdUsuario"].ToString();

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Acuerdo Reparatorio IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Medios Alternos de Solución en el PJE: " + OptMediosAlternos.SelectedItem + " Se llevo acabo un acuerdo reparatorio: " + OptAcuerdoReparatorio.SelectedItem + " Fecha Acuerdo: " + TxtFechaAcuerdo.Text + " Fecha Aprovacion: " + TxtFechaAprobacion.Text + " Tipo de Acuerdo: " + OptTipoAcuerdo.SelectedItem + " Observaciones: " + TxtObservacionesAcuerdo.Text.ToUpper() , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            SqlCommand SqlAcuerdo = new SqlCommand(Sql, Data.CnnCentral);
            SqlAcuerdo.ExecuteReader();
            //SqlDataReader drMedidaCautelar = SqlMedidaCautelar.ExecuteReader();

            //drMedidaCautelar.Close();

            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 118);

        }

        protected void CmdRegistrarPlazo_Click(object sender, EventArgs e)
        {
            string Sql = "Set DateFormat dmy exec InsertaPlazoInvestigacion " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + ",'" + TxtPlazo.Text + "'," + Session["IdUsuario"].ToString();

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Plazo Invertigacion IdCarpeta=" + IdCarpeta.Text + " Plazo: " + TxtPlazo.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            SqlCommand SqlPlazo = new SqlCommand(Sql, Data.CnnCentral);
            SqlPlazo.ExecuteReader();

        }

        protected void CmdRegistrarSobreseimiento_Click(object sender, EventArgs e)
        {

            SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=121 , FECHA_ESTADO_NUC='" + TxtFechaSobreseimiento.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
            rdC.Close();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=121 FechaEstadoNuc= " + TxtFechaSobreseimiento.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            string Sql = "exec InsertaSobreseimiento " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + "," + OptSobreseimiento.SelectedValue + ",'" + TxtFechaSobreseimiento.Text + "','" + TxtObservacionesSobreseimiento.Text.ToUpper() + "'," + Session["IdUsuario"].ToString();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Sobreseimiento IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Establecer Sobreseimiento: " + OptSobreseimiento.SelectedItem + " Fecha Sobreseimiento: " + TxtFechaSobreseimiento.Text + " Observaciones: " + TxtObservacionesSobreseimiento.Text.ToUpper() , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            SqlCommand SqlSobreseimiento = new SqlCommand(Sql, Data.CnnCentral);
            SqlSobreseimiento.ExecuteReader();

            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 121);
        }

        public int ValidaDatosProcedimientoAbreviado()
        {
            lblEstatus.Text = "";

            if (OptProcedimientoAbreviado.SelectedValue == "")
            {
                lblEstatus.Text = "No ha seleccionado el tipo de Procedimiento. ";
                return 0;
            }
            else if (TxtFechaProcedimiento.Text.Trim() == "")
            {
                lblEstatus.Text = lblEstatus.Text + "No ha la Fecha de Audiencia. ";
                return 0;
            }
            else
            {
                lblEstatus.Text = "";
                return 1;
            }
        }


        protected void CmdProcedimientoAbreviado_Click(object sender, EventArgs e)
        {
            if (ValidaDatosProcedimientoAbreviado() == 1)
            {

                SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=119 , FECHA_ESTADO_NUC='" + TxtFechaProcedimiento.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
                rdC.Close();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=119 FechaEstadoNuc= " + TxtFechaProcedimiento.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                string Sql = "Set DateFormat dmy exec InsertaProcedimientoAbreviado " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + "," + OptProcedimientoAbreviado.SelectedValue + ",'" + TxtFechaProcedimiento.Text + "'," + Session["IdUsuario"].ToString();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Procedimiento Abreviado IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Procedimiento Abreviado: " + OptProcedimientoAbreviado.SelectedItem + " Fecha Procedimiento: " + TxtFechaProcedimiento.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                SqlCommand SqlProcedimiento = new SqlCommand(Sql, Data.CnnCentral);
                SqlProcedimiento.ExecuteReader();

                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 119);
            }
        }

        protected void CmdMedidasProteccion_Click(object sender, EventArgs e)
        {

            SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=116 , FECHA_ESTADO_NUC='" + TxtFechaMedidaProteccion.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
            SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
            rdC.Close();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=116 FechaEstadoNuc= " + TxtFechaMedidaProteccion.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
            string Sql = "Set DateFormat dmy exec InsertaMedidaProteccion " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + ", " + OptMedidasProteccion.SelectedValue + ",'" + TxtFechaMedidaProteccion.Text + "'," + CboMedidaProteccion.SelectedValue + "," + TxtPlazoMedidaProteccion.Text + "," + Session["IdUsuario"].ToString();
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Medida Proteccion IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Medidas de Protección: " + OptMedidasProteccion.SelectedItem + " Fecha Medida Proteccion: " + TxtFechaMedidaProteccion.Text + " Medida: " + CboMedidaProteccion.SelectedItem + " Plazo: " + TxtPlazoMedidaProteccion.Text , int.Parse(Session["IdModuloBitacora"].ToString()));
            
            SqlCommand SqlMedidaProteccion = new SqlCommand(Sql, Data.CnnCentral);
            SqlMedidaProteccion.ExecuteReader();
            //SqlDataReader drMedidaProteccion = SqlMedidaProteccion.ExecuteReader();

            //drMedidaProteccion.Close();

            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 116);
        }

        public int ValidaDatosSentencia()
        {
            lblEstatus2.Text = "";
            if (CboTipoSentencia.SelectedItem.Text == "-- SELECCIONA --")
            {
                lblEstatus2.Text = "No ha seleccionado el tipo de Sentencia. ";
                return 0;
            }
            else if (CboSancion.SelectedItem.Text == "-- SELECCIONA --")
            {
                lblEstatus2.Text = lblEstatus2.Text + "No ha seleccionado la Sanción. ";
                return 0;
            }
            else
            {
                lblEstatus2.Text = "";
                return 1;
            }
        }

        protected void CmdSentencia_Click(object sender, EventArgs e)
        {

            if (ValidaDatosSentencia() == 1)
            {
                SqlCommand sqlEstadoCarpeta = new SqlCommand("update PGJ_CARPETA set ID_ESTADO_NUC=120 , FECHA_ESTADO_NUC='" + TxtFechaSentencia.Text + "'+' '+ RIGHT('00'+CONVERT(varchar(2), datepart(HOUR,GETDATE())),2) + ':' +  RIGHT('00'+CONVERT(varchar(2),datepart(MINUTE,GETDATE())),2) " + " where ID_CARPETA=" + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader rdC = sqlEstadoCarpeta.ExecuteReader();
                rdC.Close();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Pgj_carpeta IdCarpeta=" + IdCarpeta.Text + " IdEstadoNuc=120 FechaEstadoNuc= " + TxtFechaSentencia.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                string Sql = "Set DateFormat dmy exec InsertaSentencia " + IdCarpeta.Text + "," + short.Parse(Session["IdMunicipio"].ToString()) + "," + CboImputado.SelectedValue + "," + CboDelitoSentencia.SelectedValue + "," + CboTipoSentencia.SelectedValue + ",'" + TxtFechaSentencia.Text + "'," + CboSancion.SelectedValue + "," + CboOfendido.SelectedValue + ",'" + TxtObservaciones.Text.ToUpper() + "'," + Session["IdUsuario"].ToString();
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Sentencia IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Delito: " + CboDelitoSentencia.SelectedItem + " Tipo Sentencia: " + CboTipoSentencia.SelectedItem + " Fecha Sentencia: " + TxtFechaSentencia.Text + " Sanción: " + CboSancion.SelectedItem + " Ofendido: " + CboOfendido.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));

                SqlCommand SqlSentencia = new SqlCommand(Sql, Data.CnnCentral);
                SqlSentencia.ExecuteReader();

                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 120);
            }

        }

        protected void CmdRegresar_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            
            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
        }


        //protected void btnMedios_Click(object sender, EventArgs e)
        //{
        //    //PENDIENTE VALIDAR LO DEL IMPUTADO
        //    //lblErrorMediosSTJ.Text = "imputado="+CboImputado.SelectedValue;

        //    lblErrorMediosSTJ.Text = "";
        //    if (CboImputado.SelectedValue == "")
        //    { 
        //        lblErrorMediosSTJ.Text="SELECCIONAR UN IMPUTADO";
        //    }
        //    if (string.IsNullOrEmpty(txtFechaMediosSTJ.Text))
        //    {
        //        lblErrorMediosSTJ.Text = "FALTA FECHA";
        //    }

        //    if (lblErrorMediosSTJ.Text == "")
        //    {
        //        //InsertaNucJudicializadaMediosSTJ(int ID_CARPETA, short IdMunicipio, int IdPersona, DateTime Fecha, String Observaciones, int IdUsuario)
        //        PGJ.InsertaNucJudicializadaMediosSTJ(int.Parse(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()),
        //            int.Parse(CboImputado.SelectedValue), DateTime.Parse(txtFechaMediosSTJ.Text), txtObservacionsMediosSTJ.Text.ToUpper(), int.Parse(Session["IdUsuario"].ToString()));
        //        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Medios Alternativos STJ IdCarpeta=" + IdCarpeta.Text + " Imputado:" + CboImputado.SelectedItem + " Fecha : " + txtFechaMediosSTJ.Text + " Observaciones: " + txtObservacionsMediosSTJ.Text.ToUpper(), int.Parse(Session["IdModuloBitacora"].ToString()));
        //        Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + 124);

        //    }
        //}
      
        // void cargarImputado()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var im = from c in dc.MarcadorImputado(int.Parse(IdCarpeta.Text))
        //             select new { c.ID_PERSONA, c.IMPUTADO };
        //    ddlImputado.DataSource = im;
        //    ddlImputado.DataValueField = "ID_PERSONA";
        //    ddlImputado.DataTextField = "IMPUTADO";
        //    ddlImputado.DataBind();
        //} 

        //void cargarOfendido()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var im = from c in dc.MarcadorOfendido(int.Parse(IdCarpeta.Text))
        //             select new { c.ID_PERSONA, c.OFENDIDO };
        //    ddlOfendido.DataSource = im;
        //    ddlOfendido.DataValueField = "ID_PERSONA";
        //    ddlOfendido.DataTextField = "OFENDIDO";
        //    ddlOfendido.DataBind();
        //}
       
    }
}