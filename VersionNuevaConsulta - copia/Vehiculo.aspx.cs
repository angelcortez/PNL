using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;






namespace AtencionTemprana
{
    public partial class Vehiculo : System.Web.UI.Page
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
        string tipoUnidad;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                HookOnFocus(this.Page as Control);
                ScriptManager.RegisterStartupScript(
                this,
                typeof(Vehiculo),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                //---------
                lblArbol.Text = Session["lblArbol"].ToString();

                Session["ID_VEHICULO"] = Request.QueryString["ID_VEHICULO"];
                Session["op"] = Request.QueryString["op"];

                int IdUGI = int.Parse(Session["IdUnidad"].ToString());

                SqlCommand sqlTipo = new SqlCommand("select * from CAT_UNIDAD where ID_UNDD= " + IdUGI, Data.CnnCentral);
                SqlDataReader drTipo = sqlTipo.ExecuteReader();
                if (drTipo.HasRows)
                {
                    drTipo.Read();
                    tipoUnidad = drTipo["ID_UNDD_TPO"].ToString();
                }
                drTipo.Close();
                //Label14.Text = "TIPO UNIDAD " + tipoUnidad;

                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();

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
                Session["ID_MARCA"] = "999";

                //lblValores.Text ="usuario: " +Session["IdUsuario"].ToString() +" unidad; "+ Session["IdUnidad"].ToString() + " puesto "+Session["ID_PUESTO"].ToString();
                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR VEHICULO";
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    try
                    {
                        PGJ.CargaCombo(ddlMarca, "CAT_MARCA", "id_marca", "marca");
                        PGJ.CargaCombo(ddlModelo, "CAT_MODELO", "IdModelo", "Modelo");
                        PGJ.CargaCombo(ddlColor, "CAT_color", "ID_CLR", "CLR");
                        PGJ.CargaCombo(ddlProcedencia, "CAT_PROCEDENCIA", "IdProcedencia", "Procedencia");
                        PGJ.CargaCombo(ddlTipoVehiculo, "CAT_TIPO_VEHICULO", "id_tipo_veh", "tipo_vehiculo");
                        PGJ.CargaCombo(ddlDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");
                        PGJ.CargaCombo(ddlAsegurado, "CAT_ASEGURADO", "IdAsegurado", "Asegurado");
                        PGJ.CargaComboFiltrado(ddlPlacasEstado, "CAT_ESTADO", "ID_ESTDO", "ESTDO", "ID_PAIS=" + 1);
                        //PGJ.CargaCombo(ddlPlacasEstado, "CAT_ESTADO", "ID_ESTDO", "ESTDO");
                        PGJ.CargaComboFiltrado(ddlSubMarca, "CAT_SUBMARCA", "id_submarca", "submarca", "id_marca=" + Session["ID_MARCA"]);
                        /*INICIA-NUEVO CAMPOS*/
                        txtSenas.Enabled = false;
                        PGJ.CargaCombo(ddlAseguradora, "CAT_ASEGURADORA_VEHICULO", "ID_ASEGURADORA", "ASEGURADORA");
                        PGJ.CargaCombo(ddlTipoUso, "CAT_TPO_USO_VEHICULO", "ID_TPO_USO_VEHICULO", "TPO_USO_VEHICULO");
                        PGJ.CargaCombo(ddlEstadoVehiculo, "CAT_ESTADO_VEHICULO", "ID_ESTDO_VEHICULO", "ESTDO_VEHICULO");
                        //COMBO DE PROPIETARIO
                        SqlDataAdapter PropietarioQuery = new SqlDataAdapter("SELECT PGJ_CARPETA_PERSONA.ID_PERSONA,NOMBRE+' '+PATERNO+' '+MATERNO AS Propietario FROM PGJ_CARPETA_PERSONA INNER JOIN PGJ_PERSONA ON (PGJ_PERSONA.ID_PERSONA=PGJ_CARPETA_PERSONA.ID_PERSONA)" +
                            " WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString() + " AND ID_MUNICIPIO_PEROSNA_CARPETA=" + Session["IdMunicipio"].ToString(), Data.CnnCentral);
                        DataTable PropietarioDt = new DataTable();
                        PropietarioQuery.Fill(PropietarioDt);
                        ddlPropietario.DataTextField = "Propietario";
                        ddlPropietario.DataValueField = "ID_PERSONA";
                        ddlPropietario.DataSource = PropietarioDt;
                        ddlPropietario.DataBind();
                        ddlPropietario.Items.Insert(0, "--SELECCIONA--");
                        //COMBO DE DELITO
                        SqlDataAdapter DelitoQuery = new SqlDataAdapter("SELECT ID_CONSECUTIVO_DELITO,DLTO FROM PGJ_DELITOS INNER JOIN CAT_DELITO ON (CAT_DELITO.ID_DLTO=PGJ_DELITOS.ID_DELITO) " +
                            " WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "AND ID_MUNICIPIO_DELITO=" + Session["IdMunicipio"].ToString() + " AND CAT_DELITO.OBJTS_VHCLO=1", Data.CnnCentral);
                        DataTable DelitoDt = new DataTable();
                        DelitoQuery.Fill(DelitoDt);
                        ddlDelito.DataTextField = "DLTO";
                        ddlDelito.DataValueField = "ID_CONSECUTIVO_DELITO";
                        ddlDelito.DataSource = DelitoDt;
                        ddlDelito.DataBind();
                        ddlDelito.Items.Insert(0, "--SELECCIONA--");
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
                            txtFechaInicio.Text = drFechaInicio["FechaInicio"].ToString();
                            txtHoraInicio.Text = drFechaInicio["HoraExpediente"].ToString();
                            txtExpediente.Text = drFechaInicio["NumeroExpediente"].ToString();
                        }
                        drFechaInicio.Close();

                        PGJ.CargaCombo(ddlDepositado, "CAT_DEPOSITADO_VEHICULO", "ID_DEPOSITADO", "DEPOSITADO");

                        if (ddlDelito.SelectedValue.ToString() == "--SELECCIONA--")
                        {
                            ddlEstadoVehiculo.Enabled = false;
                            ddlPropietario.Enabled = false;
                        }

                        /*FIN-NUEVOS CAMPOS*/
                        btnAutorizacion.Visible = false;
                        btnGuardarAut.Visible = false;
                        btnDescargarDocumento.Visible = false;
                        btnGuardarDocu.Visible = false;
                        lblAutorizacion.Visible = false;
                        txtAutorizacion.Visible = false;
                        Label332.Visible = false;
                        fileUpload.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Vehiculo.aspx?&op=Agregar");
                    }
                }
                else if (Session["op"].ToString() == "Modificar")
                {

                    lblOperacion.Text = "CONSULTAR VEHICULO";
                    try
                    {
                        PGJ.CargaCombo(ddlMarca, "CAT_MARCA", "id_marca", "marca");
                        PGJ.CargaCombo(ddlModelo, "CAT_MODELO", "IdModelo", "Modelo");
                        PGJ.CargaCombo(ddlColor, "CAT_color", "ID_CLR", "CLR");
                        PGJ.CargaCombo(ddlProcedencia, "CAT_PROCEDENCIA", "IdProcedencia", "Procedencia");
                        PGJ.CargaCombo(ddlTipoVehiculo, "CAT_TIPO_VEHICULO", "id_tipo_veh", "tipo_vehiculo");
                        PGJ.CargaCombo(ddlDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");
                        PGJ.CargaCombo(ddlAsegurado, "CAT_ASEGURADO", "IdAsegurado", "Asegurado");
                        PGJ.CargaComboFiltrado(ddlPlacasEstado, "CAT_ESTADO", "ID_ESTDO", "ESTDO", "ID_PAIS=" + 1);
                        //PGJ.CargaCombo(ddlPlacasEstado, "CAT_ESTADO", "ID_ESTDO", "ESTDO");
                        //cargarVehiculo();

                        //CAMPOS NUEVOS
                        PGJ.CargaCombo(ddlAseguradora, "CAT_ASEGURADORA_VEHICULO", "ID_ASEGURADORA", "ASEGURADORA");
                        PGJ.CargaCombo(ddlTipoUso, "CAT_TPO_USO_VEHICULO", "ID_TPO_USO_VEHICULO", "TPO_USO_VEHICULO");
                        PGJ.CargaCombo(ddlEstadoVehiculo, "CAT_ESTADO_VEHICULO", "ID_ESTDO_VEHICULO", "ESTDO_VEHICULO");
                        //COMBO DE DELITO
                        SqlDataAdapter DelitoQuery = new SqlDataAdapter("SELECT ID_CONSECUTIVO_DELITO,DLTO FROM PGJ_DELITOS INNER JOIN CAT_DELITO ON (CAT_DELITO.ID_DLTO=PGJ_DELITOS.ID_DELITO) " +
                            " WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "AND ID_MUNICIPIO_DELITO=" + Session["IdMunicipio"].ToString() + " AND CAT_DELITO.OBJTS_VHCLO=1", Data.CnnCentral);
                        DataTable DelitoDt = new DataTable();
                        DelitoQuery.Fill(DelitoDt);
                        ddlDelito.DataTextField = "DLTO";
                        ddlDelito.DataValueField = "ID_CONSECUTIVO_DELITO";
                        ddlDelito.DataSource = DelitoDt;
                        ddlDelito.DataBind();
                        ddlDelito.Items.Insert(0, "--SELECCIONA--");
                        ddlDelito.Enabled = false;
                        //COMBO DE PROPIETARIO
                        SqlDataAdapter PropietarioQuery = new SqlDataAdapter("SELECT PGJ_CARPETA_PERSONA.ID_PERSONA,NOMBRE+' '+PATERNO+' '+MATERNO AS Propietario FROM PGJ_CARPETA_PERSONA INNER JOIN PGJ_PERSONA ON (PGJ_PERSONA.ID_PERSONA=PGJ_CARPETA_PERSONA.ID_PERSONA)" +
                            " WHERE ID_CARPETA=" + Session["ID_CARPETA"].ToString() + " AND ID_MUNICIPIO_PEROSNA_CARPETA=" + Session["IdMunicipio"].ToString(), Data.CnnCentral);
                        DataTable PropietarioDt = new DataTable();
                        PropietarioQuery.Fill(PropietarioDt);
                        ddlPropietario.DataTextField = "Propietario";
                        ddlPropietario.DataValueField = "ID_PERSONA";
                        ddlPropietario.DataSource = PropietarioDt;
                        ddlPropietario.DataBind();
                        ddlPropietario.Items.Insert(0, "--SELECCIONA--");
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
                            txtFechaInicio.Text = drFechaInicio["FechaInicio"].ToString();
                            txtHoraInicio.Text = drFechaInicio["HoraExpediente"].ToString();
                            txtExpediente.Text = drFechaInicio["NumeroExpediente"].ToString();
                        }
                        drFechaInicio.Close();

                        //CARGAR LA FECHA DE ROBO
                        if (ddlDelito.SelectedValue.ToString() == "--SELECCIONA--")
                        {
                            txtFechaRobo.Text = "";
                            txtHoraRobo.Text = "";



                        }
                        else
                        {
                            SqlCommand sqlFechaRobo = new SqlCommand("CargarFechaRoboVehiculo ", Data.CnnCentral);
                            sqlFechaRobo.CommandType = CommandType.StoredProcedure;
                            sqlFechaRobo.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                            sqlFechaRobo.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.Int);
                            sqlFechaRobo.Parameters.Add("@IdConsecutivoDelito", SqlDbType.Int);

                            sqlFechaRobo.Parameters["@IdCarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
                            sqlFechaRobo.Parameters["@IdMunicipioCarpeta"].Value = int.Parse(Session["IdMunicipio"].ToString());
                            sqlFechaRobo.Parameters["@IdConsecutivoDelito"].Value = int.Parse(ddlDelito.SelectedValue.ToString());

                            SqlDataReader drFechaRobo = sqlFechaRobo.ExecuteReader();
                            if (drFechaRobo.HasRows)
                            {
                                drFechaRobo.Read();
                                txtFechaRobo.Text = drFechaRobo["FechaHechos"].ToString();
                                txtHoraRobo.Text = drFechaRobo["HORA_HECHOS"].ToString();
                            }
                            drFechaRobo.Close();


                        }




                        PGJ.CargaCombo(ddlDepositado, "CAT_DEPOSITADO_VEHICULO", "ID_DEPOSITADO", "DEPOSITADO");
                        cargarVehiculo();

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Vehiculo IdVehiculo=" + ID_VEHICULO.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            

                        PGJ.CargaComboFiltrado(ddlSubMarca, "CAT_SUBMARCA", "id_submarca", "submarca", "id_marca=" + ddlMarca.SelectedValue.ToString());
                        cargarVehiculoRobadoRecuperado();
                        if (ddlProcedencia.SelectedItem.ToString() == "EXTRANJERO")
                        {
                            txtSenas.Enabled = true;//desbloqueamos el campo de señas
                            txtPlaca.Enabled = false;//bloqueamos el campo de placa
                        }
                        else
                        {
                            txtSenas.Enabled = false;
                        }
                        if (ddlEstadoVehiculo.SelectedItem.ToString() == "RECUPERADO")
                        {
                            lblFechaRec.Visible = true;
                            txtFechaRecuperado.Visible = true;
                            lblHoraRec.Visible = true;
                            txtHoraRecuperado.Visible = true;
                            lblDepositado.Visible = true;
                            ddlDepositado.Visible = true;
                            lblFechaDepositado.Visible = true;
                            txtFechaDeposito.Visible = true;
                            lblHoraDepositado.Visible = true;
                            txtHoraDeposito.Visible = true;
                            //ddlEstadoVehiculo.Enabled = false; /*PENDIENTE ALEIDA*/
                            
                        }
                        else
                        {
                            lblFechaRec.Visible = false;
                            txtFechaRecuperado.Visible = false;
                            lblHoraRec.Visible = false;
                            txtHoraRecuperado.Visible = false;
                            lblDepositado.Visible = false;
                            ddlDepositado.Visible = false;
                            lblFechaDepositado.Visible = false;
                            txtFechaDeposito.Visible = false;
                            lblHoraDepositado.Visible = false;
                            txtHoraDeposito.Visible = false;
                        }


                        if (ddlDelito.SelectedValue.ToString() == "--SELECCIONA--")
                        {
                            ddlEstadoVehiculo.Enabled = false;
                            ddlPropietario.Enabled = false;
                        }
                        else
                        {
                            txtNumeroAccidente.Enabled = false;
                        }

                        cargarAutorizacion();
                        /*DELITO ROBO DE VEHICULO Y ESTATUS ROBADO, OFICIAL O MP, MOSTRAR EL BOTON DE AUTORIZACION*/
                        if (ddlEstadoVehiculo.SelectedItem.ToString() == "ROBADO" && ddlDelito.SelectedItem.ToString() == "ROBO DE VEHICULOS"
                            && (Session["ID_PUESTO"].ToString() == "4" || Session["ID_PUESTO"].ToString() == "2"))
                        {
                            btnAutorizacion.Visible = true;

                        }
                        else
                        {

                            btnAutorizacion.Visible = false;
                        }
                        existeDocumento();
                        if (txtAutorizacion.Text == "" && existeDo == "0")
                        {
                            btnGuardarDocu.Visible = false;
                            btnDescargarDocumento.Visible = false;
                            fileUpload.Visible = false;
                            Label332.Visible = false;
                        }

                        /*PERMITIR QUE LOS DATOS SOLO SEAN MODIFICADOS SOLO UNA VEZ POR CADA ESTATUS DEL VEHICULO*/
                        if (ddlEstadoVehiculo.SelectedItem.ToString() == "ROBADO" && ddlDelito.SelectedItem.ToString() == "ROBO DE VEHICULOS")
                        {
                            DesactivarControlesRobado();
                        }
                        if (ddlEstadoVehiculo.SelectedItem.ToString() == "RECUPERADO" && ddlDelito.SelectedValue.ToString() != "--SELECCIONA--")
                        {
                            DesactivarControlesRecuperado();
                        }
                      
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Vehiculo.aspx?ID_VEHICULO=" + Session["ID_VEHICULO"].ToString() + "&op=Modificar");
                        //lblEstatus.Text = ex.Message;

                    }

                }

            }

        }

        // Paso 2 para evitar que se pierda el valor del tabindex de los controles despues de un postback
        private void HookOnFocus(Control CurrentControl)
        {

            if ((CurrentControl is TextBox) ||
                (CurrentControl is DropDownList) ||
                (CurrentControl is CheckBox) ||
                (CurrentControl is ListBox) ||
                (CurrentControl is Button) ||
                (CurrentControl is RadioButton))

                (CurrentControl as WebControl).Attributes.Add("onfocus", "try{document.getElementById('__LASTFOCUS').value=this.id}catch(e) {}");

            if (CurrentControl.HasControls())

                foreach (Control CurrentChildControl in CurrentControl.Controls)
                    HookOnFocus(CurrentChildControl);
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



        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            
            lblPregunta.Visible = false;
            lblError.Text = "";
            //lblIdMarca.Text = "valor del modelo: "+ddlModelo.SelectedItem.ToString();
            String cadenaCombo = "SELECCIONA";
            /*COMBOS NO DEBEN TENER VALOR SELECCIONA*/
            if (ddlDelito.SelectedValue.ToString() != "--SELECCIONA--")
            {
                if (ddlPropietario.SelectedValue.ToString().Contains(cadenaCombo))
                {
                    lblError.Text = "SELECCIONE UN PROPIETARIO";
                }
            }
            /*PLACA Y SERIE NO VACIAS*/
            if (string.IsNullOrEmpty(txtSerie.Text) && string.IsNullOrEmpty(txtPlaca.Text))
            {
                lblError.Text = "NO SE PERMITE LA PLACA Y SERIE VACIA";
            }
            /*CARACTERES INVALIDOS EN LA SERIE*/
            string ValidosSERIE = "ABCDEFGHJKLMNPRSTUVWXYZ0123456789abcdefghjklmnprstuvwxyz";
            string serie = txtSerie.Text;
            if (txtSerie.Text.Length.ToString() != "0")
            {
                for (int i = 0; i <= serie.Length - 1; i++)
                {
                    //Console.WriteLine(i);
                    //lblMsj.Text = lblMsj.Text + "-" + nombre[i];
                    //Label1.Text = Label1.Text + "*" + Validos.Contains(nombre[i]);
                    if (!ValidosSERIE.Contains(serie[i].ToString()))
                    {
                        lblError.Text = "CARACTER INVALIDO EN LA SERIE: " + serie[i].ToString();
                    }
                }
            }
            /*CARACTERES INVALIDOS EN LA PLACA*/
            string ValidosPlaca = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            string placa = txtPlaca.Text;
            if (txtPlaca.Text.Length.ToString() != "0")
            {
                for (int i = 0; i <= placa.Length - 1; i++)
                {
                    //Console.WriteLine(i);
                    //lblMsj.Text = lblMsj.Text + "-" + nombre[i];
                    //Label1.Text = Label1.Text + "*" + Validos.Contains(nombre[i]);
                    if (!ValidosPlaca.Contains(placa[i].ToString()))
                    {
                        lblError.Text = "CARACTER INVALIDO EN LA PLACA: " + placa[i].ToString();
                    }
                }
            }
            /*VALIDAR LAS FECHAS*/
            if (ddlDelito.SelectedValue.ToString() != "--SELECCIONA--")
            {
                SqlCommand sqlValidar = new SqlCommand("ValidarFechaVehiculo ", Data.CnnCentral);
                sqlValidar.CommandType = CommandType.StoredProcedure;
                sqlValidar.Parameters.Add("@FechaInicio", SqlDbType.DateTime);
                sqlValidar.Parameters.Add("@FechaHecho", SqlDbType.DateTime);

                sqlValidar.Parameters["@FechaInicio"].Value = DateTime.Parse(txtFechaInicio.Text);
                sqlValidar.Parameters["@FechaHecho"].Value = DateTime.Parse(txtFechaRobo.Text);

                SqlDataReader drValida = sqlValidar.ExecuteReader();
                if (drValida.HasRows)
                {
                    drValida.Read();
                    //txtFechaRobo.Text = drValida["Valor"].ToString();
                    if (drValida["Valor"].ToString() == "0")
                    {
                        lblError.Text = "LA FECHA DE ROBO (FECHA DE HECHOS) NO PUEDE SER MAYOR A LA FECHA DE INICIO DE LA CARPETA";
                    }
                }
                drValida.Close();
            }

            /*VALIDAR LA SERIE O PLACA, CUANDO LA PLACA LA PLACA ES EXTRA*/
            if (txtPlaca.Text == "PLACAEXTRA" && string.IsNullOrEmpty(txtSerie.Text))
            {
                lblError.Text = "INGRESE LA SERIE";
            }

            /*VALIDAR EL TAMAÑO DE SERIE*/
            //if (!ddlModelo.SelectedItem.ToString().Contains("SELECCIONA"))
            //    //&& txtPlaca.Text=="PLACAEXTRA")
            //{
            //    if (int.Parse(ddlModelo.SelectedItem.ToString()) >= 1981)
            //    {
            //        if (int.Parse(txtSerie.Text.Length.ToString()) != 17)
            //        {
            //            lblError.Text = "EL NUMERO DE SERIE DEBE SER DE 17 CARACTERES";
            //        }
            //    }
            //}
            /*VALIDAR HORA DE RECUPERADO, FECHA DE RECUPERADO, FECHA DE ENTREGADO*/
            if (ddlDelito.SelectedValue.ToString() != "--SELECCIONA--" && ddlEstadoVehiculo.SelectedItem.ToString() == "RECUPERADO")
            {
                Regex rgx = new Regex("([0-1][0-9]|2[0-3]):[0-5][0-9]");
                //Label4.Text = rgx.Match(txtHoraRecuperado.Text).ToString();
                if (rgx.Match(txtHoraRecuperado.Text).Success)
                {
                    //lblError.Text = "FORMATO CORRECTO";
                }
                else
                {
                    lblError.Text = "FORMATO INCORRECTO DE LA HORA DE RECUPERADO";
                }

                if (rgx.Match(txtHoraDeposito.Text).Success)
                {
                    //lblError.Text = "FORMATO CORRECTO";
                }
                else
                {
                    lblError.Text = "FORMATO INCORRECTO DE LA HORA DE RECUPERADO";
                }

                if (string.IsNullOrEmpty(txtFechaRecuperado.Text))
                {
                    lblError.Text = "FORMATO INCORRECTO DE LA FECHA DE RECUPERADO";
                }
                if (string.IsNullOrEmpty(txtFechaDeposito.Text))
                {
                    lblError.Text = "FORMATO INCORRECTO DE LA FECHA DE DEPOSITO";
                }

                if (ddlDepositado.SelectedItem.ToString().Contains("SELECCIONA"))
                {
                    lblError.Text = "SELECCIONE DEPOSITADO EN";
                }
                //Regex rgxFecha = new Regex("^(0?[1-9]|1[0-9]|2|2[0-9]|3[0-1])/(0?[1-9]|1[0-2])/(d{2}|d{4})$");
                //if (rgxFecha.Match(txtFechaRecuperado.Text).Success)
                //{
                //    //lblError.Text = "FORMATO CORRECTO";
                //}
                //else
                //{
                //    lblError.Text = "FORMATO INCORRECTO DE LA FECHA DE RECUPERADO";
                //}
                //if (rgxFecha.Match(txtFechaDeposito.Text).Success)
                //{
                //    //lblError.Text = "FORMATO CORRECTO";
                //}
                //else
                //{
                //    lblError.Text = "FORMATO INCORRECTO DE LA FECHA DE DEPOSITADO";
                //}

            }
            //validar que el estatus no sea --SELECCIONA-- cuando se tenga seleccionado un delito
            if (ddlDelito.SelectedValue.ToString() != "--SELECCIONA--")
            {
                if (ddlEstadoVehiculo.SelectedItem.ToString().Contains("SELECCIONA"))
                {
                    lblError.Text = "SELECCIONE UN ESTADO DEL VEHICULO";
                }
            }
            //validar que el estatus ROBADO no se use con los delitos diferentes al ROBO DE VEHIULO
            if (ddlDelito.SelectedValue.ToString() != "--SELECCIONA--" &&  ddlDelito.SelectedItem.ToString() != "ROBO DE VEHICULOS")
            {
                if (ddlEstadoVehiculo.SelectedItem.ToString()=="ROBADO")
                {
                    lblError.Text = "EL ESTADO DEL VEHÍCULO NO PUEDE SER 'ROBADO' ";
                }
            }
            //validar que cuando sera ROBO DE VEHICULOS, y se este agreando por PRIMERA vez el vehiculo, el estatus NO puede ser RECUPERADO
            if (Session["op"].ToString() == "Agregar" && ddlEstadoVehiculo.SelectedItem.ToString() == "RECUPERADO" && ddlDelito.SelectedItem.ToString() == "ROBO DE VEHICULOS")
            {
                lblError.Text = "EL ESTADO DEL VEHÍCULO NO PUEDE SER 'RECUPERADO' ";
            }

            if (lblError.Text == "")
            {
                try
                {
                    if (Session["op"].ToString() == "Agregar")
                    {
                        if (ddlDelito.SelectedValue.ToString() == "--SELECCIONA--")
                        {
                            
                           PGJ.InsertaVehiculo(int.Parse(IdCarpeta.Text), txtNumeroAccidente.Text, short.Parse(ddlMarca.SelectedValue.ToString()), int.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text, short.Parse(Session["IdMunicipio"].ToString()), txtSenas.Text, short.Parse(ddlTipoUso.SelectedValue.ToString()), short.Parse(ddlAseguradora.SelectedValue.ToString()), txtNumeroMotor.Text, txtRegistroVehicular.Text);

                           PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Vehiculo IdCarpeta=" + IdCarpeta.Text + " Numero de Accidente: " + txtNumeroAccidente.Text + " Marca: " + ddlMarca.SelectedItem + " SubMarca: " + ddlSubMarca.SelectedItem + " Modelo: " + ddlModelo.SelectedItem + " Color: " + ddlColor.SelectedItem + " Serie: " + txtSerie.Text + " Placas: " + txtPlaca.Text + " Placas del Estado: " + ddlPlacasEstado.SelectedItem + " Procedencia: " + ddlProcedencia.SelectedItem + " Tipo de Vehiculo: " + ddlTipoVehiculo.SelectedItem + " Puesto a Dispocicion: " + ddlDisposicion.SelectedItem + " Asegurado: " + ddlAsegurado.SelectedItem + " Obervaciones: " + txtObservaciones.Text + " Señas: " + txtSenas.Text + " Tipo de Uso: " + ddlTipoUso.SelectedItem + " Aseguradora: " + ddlAseguradora.SelectedItem + " Numero de Motor: " + txtNumeroMotor.Text + " Registro Vehicular: " + txtRegistroVehicular.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
                        }
                        else
                        {
                            if (ddlEstadoVehiculo.SelectedItem.ToString() == "RECUPERADO")
                            {
                                PGJ.InsertaVehiculoRobadoRecuperado(int.Parse(IdCarpeta.Text), txtNumeroAccidente.Text, short.Parse(ddlMarca.SelectedValue.ToString()), int.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text, short.Parse(Session["IdMunicipio"].ToString()), txtSenas.Text, short.Parse(ddlTipoUso.SelectedValue.ToString()), short.Parse(ddlAseguradora.SelectedValue.ToString()), DateTime.Parse(txtFechaRobo.Text), txtHoraRobo.Text, short.Parse(ddlEstadoVehiculo.SelectedValue.ToString()), short.Parse(ddlPropietario.SelectedValue.ToString()), short.Parse(ddlDelito.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdUnidad"].ToString()), txtNumeroMotor.Text, txtRegistroVehicular.Text, DateTime.Parse(txtFechaRecuperado.Text), txtHoraRecuperado.Text, short.Parse(ddlDepositado.SelectedValue.ToString()), DateTime.Parse(txtFechaDeposito.Text), txtHoraDeposito.Text);

                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Vehiculo Recuperado IdCarpeta=" + IdCarpeta.Text + " Numero de Accidente: " + txtNumeroAccidente.Text + " Marca: " + ddlMarca.SelectedItem + " SubMarca: " + ddlSubMarca.SelectedItem + " Modelo: " + ddlModelo.SelectedItem + " Color: " + ddlColor.SelectedItem + " Serie: " + txtSerie.Text + " Placas: " + txtPlaca.Text + " Placas del Estado: " + ddlPlacasEstado.SelectedItem + " Procedencia: " + ddlProcedencia.SelectedItem + " Tipo de Vehiculo: " + ddlTipoVehiculo.SelectedItem + " Puesto a Dispocicion: " + ddlDisposicion.SelectedItem + " Asegurado: " + ddlAsegurado.SelectedItem + " Obervaciones: " + txtObservaciones.Text + " Señas: " + txtSenas.Text + " Tipo de Uso: " + ddlTipoUso.SelectedItem + " Aseguradora: " + ddlAseguradora.SelectedItem + " Fecha de Robo:" + txtFechaRobo.Text + " Hora de Robo: " + txtHoraRobo.Text + " Estado del Vehiculo: " + ddlEstadoVehiculo.SelectedItem + " Propietario: " + ddlPropietario.SelectedItem + " Delito: " + ddlDelito.SelectedItem + " Numero de Motor: " + txtNumeroMotor.Text + " Registro Vehicular: " + txtRegistroVehicular.Text + " Fecha Recuperado: " + txtFechaRecuperado.Text + " Hora Recuperado: " + txtHoraRecuperado.Text + " Depositado: " + ddlDepositado.SelectedItem + " Fecha Deposito: " + txtFechaDeposito.Text + " Hora Deposito: " + txtHoraDeposito.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
                            
                            }
                            else
                            {
                                PGJ.InsertaVehiculoRobado(int.Parse(IdCarpeta.Text), txtNumeroAccidente.Text, short.Parse(ddlMarca.SelectedValue.ToString()), int.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text, short.Parse(Session["IdMunicipio"].ToString()), txtSenas.Text, short.Parse(ddlTipoUso.SelectedValue.ToString()), short.Parse(ddlAseguradora.SelectedValue.ToString()), DateTime.Parse(txtFechaRobo.Text), txtHoraRobo.Text, short.Parse(ddlEstadoVehiculo.SelectedValue.ToString()), short.Parse(ddlPropietario.SelectedValue.ToString()), short.Parse(ddlDelito.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdUnidad"].ToString()), txtNumeroMotor.Text, txtRegistroVehicular.Text);

                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Vehiculo Robado IdCarpeta=" + IdCarpeta.Text + " Numero de Accidente: " + txtNumeroAccidente.Text + " Marca: " + ddlMarca.SelectedItem + " SubMarca: " + ddlSubMarca.SelectedItem + " Modelo: " + ddlModelo.SelectedItem + " Color: " + ddlColor.SelectedItem + " Serie: " + txtSerie.Text + " Placas: " + txtPlaca.Text + " Placas del Estado: " + ddlPlacasEstado.SelectedItem + " Procedencia: " + ddlProcedencia.SelectedItem + " Tipo de Vehiculo: " + ddlTipoVehiculo.SelectedItem + " Puesto a Dispocicion: " + ddlDisposicion.SelectedItem + " Asegurado: " + ddlAsegurado.SelectedItem + " Obervaciones: " + txtObservaciones.Text + " Señas: " + txtSenas.Text + " Tipo de Uso: " + ddlTipoUso.SelectedItem + " Aseguradora: " + ddlAseguradora.SelectedItem + " Fecha de Robo:" + txtFechaRobo.Text + " Hora de Robo: " + txtHoraRobo.Text + " Estado del Vehiculo: " + ddlEstadoVehiculo.SelectedItem + " Propietario: " + ddlPropietario.SelectedItem + " Delito: " + ddlDelito.SelectedItem + " Numero de Motor: " + txtNumeroMotor.Text + " Registro Vehicular: " + txtRegistroVehicular.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                            
                            
                            }
                        }
                    }
                    else if (Session["op"].ToString() == "Modificar")
                    {
                        if (ddlDelito.SelectedValue.ToString() == "--SELECCIONA--")
                        {
                            PGJ.ActualizaVehiculo(int.Parse(ID_VEHICULO.Text), txtNumeroAccidente.Text, short.Parse(ddlMarca.SelectedValue.ToString()), int.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text, txtSenas.Text, short.Parse(ddlTipoUso.SelectedValue.ToString()), short.Parse(ddlAseguradora.SelectedValue.ToString()), txtNumeroMotor.Text, txtRegistroVehicular.Text);

                            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()),  Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Vehiculo IdCarpeta=" + IdCarpeta.Text + " Numero de Accidente: " + txtNumeroAccidente.Text + " Marca: " + ddlMarca.SelectedItem + " SubMarca: " + ddlSubMarca.SelectedItem + " Modelo: " + ddlModelo.SelectedItem + " Color: " + ddlColor.SelectedItem + " Serie: " + txtSerie.Text + " Placas: " + txtPlaca.Text + " Placas del Estado: " + ddlPlacasEstado.SelectedItem + " Procedencia: " + ddlProcedencia.SelectedItem + " Tipo de Vehiculo: " + ddlTipoVehiculo.SelectedItem + " Puesto a Dispocicion: " + ddlDisposicion.SelectedItem + " Asegurado: " + ddlAsegurado.SelectedItem + " Obervaciones: " + txtObservaciones.Text + " Señas: " + txtSenas.Text + " Tipo de Uso: " + ddlTipoUso.SelectedItem + " Aseguradora: " + ddlAseguradora.SelectedItem + " Numero de Motor: " + txtNumeroMotor.Text + " Registro Vehicular: " + txtRegistroVehicular.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                        
                        }
                        else
                        {
                            if (ddlEstadoVehiculo.SelectedItem.ToString() == "RECUPERADO")
                            {
                                
                                PGJ.ActualizaVehiculoRobadoRecuperado(int.Parse(ID_VEHICULO.Text), txtNumeroAccidente.Text, short.Parse(ddlMarca.SelectedValue.ToString()), int.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text, txtSenas.Text, short.Parse(ddlTipoUso.SelectedValue.ToString()), short.Parse(ddlAseguradora.SelectedValue.ToString()), DateTime.Parse(txtFechaRobo.Text), txtHoraRobo.Text, short.Parse(ddlEstadoVehiculo.SelectedValue.ToString()), short.Parse(ddlPropietario.SelectedValue.ToString()), short.Parse(Session["IdUnidad"].ToString()), txtNumeroMotor.Text, txtRegistroVehicular.Text, DateTime.Parse(txtFechaRecuperado.Text), txtHoraRecuperado.Text, short.Parse(ddlDepositado.SelectedValue.ToString()), DateTime.Parse(txtFechaDeposito.Text), txtHoraDeposito.Text, short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["ID_CARPETA"].ToString()));

                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Vehiculo Recuperado IdCarpeta=" + IdCarpeta.Text + " Numero de Accidente: " + txtNumeroAccidente.Text + " Marca: " + ddlMarca.SelectedItem + " SubMarca: " + ddlSubMarca.SelectedItem + " Modelo: " + ddlModelo.SelectedItem + " Color: " + ddlColor.SelectedItem + " Serie: " + txtSerie.Text + " Placas: " + txtPlaca.Text + " Placas del Estado: " + ddlPlacasEstado.SelectedItem + " Procedencia: " + ddlProcedencia.SelectedItem + " Tipo de Vehiculo: " + ddlTipoVehiculo.SelectedItem + " Puesto a Dispocicion: " + ddlDisposicion.SelectedItem + " Asegurado: " + ddlAsegurado.SelectedItem + " Obervaciones: " + txtObservaciones.Text + " Señas: " + txtSenas.Text + " Tipo de Uso: " + ddlTipoUso.SelectedItem + " Aseguradora: " + ddlAseguradora.SelectedItem + " Fecha de Robo:" + txtFechaRobo.Text + " Hora de Robo: " + txtHoraRobo.Text + " Estado del Vehiculo: " + ddlEstadoVehiculo.SelectedItem + " Propietario: " + ddlPropietario.SelectedItem + " Delito: " + ddlDelito.SelectedItem + " Numero de Motor: " + txtNumeroMotor.Text + " Registro Vehicular: " + txtRegistroVehicular.Text + " Fecha Recuperado: " + txtFechaRecuperado.Text + " Hora Recuperado: " + txtHoraRecuperado.Text + " Depositado: " + ddlDepositado.SelectedItem + " Fecha Deposito: " + txtFechaDeposito.Text + " Hora Deposito: " + txtHoraDeposito.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
            
                            }
                            else
                            {
                                
                                PGJ.ActualizaVehiculoRobado(int.Parse(ID_VEHICULO.Text), txtNumeroAccidente.Text, short.Parse(ddlMarca.SelectedValue.ToString()), int.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text, txtSenas.Text, short.Parse(ddlTipoUso.SelectedValue.ToString()), short.Parse(ddlAseguradora.SelectedValue.ToString()), DateTime.Parse(txtFechaRobo.Text), txtHoraRobo.Text, short.Parse(ddlEstadoVehiculo.SelectedValue.ToString()), short.Parse(ddlPropietario.SelectedValue.ToString()), short.Parse(Session["IdUnidad"].ToString()), txtNumeroMotor.Text, txtRegistroVehicular.Text);

                                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()),  Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Vehiculo Robado IdCarpeta=" + IdCarpeta.Text + " Numero de Accidente: " + txtNumeroAccidente.Text + " Marca: " + ddlMarca.SelectedItem + " SubMarca: " + ddlSubMarca.SelectedItem + " Modelo: " + ddlModelo.SelectedItem + " Color: " + ddlColor.SelectedItem + " Serie: " + txtSerie.Text + " Placas: " + txtPlaca.Text + " Placas del Estado: " + ddlPlacasEstado.SelectedItem + " Procedencia: " + ddlProcedencia.SelectedItem + " Tipo de Vehiculo: " + ddlTipoVehiculo.SelectedItem + " Puesto a Dispocicion: " + ddlDisposicion.SelectedItem + " Asegurado: " + ddlAsegurado.SelectedItem + " Obervaciones: " + txtObservaciones.Text + " Señas: " + txtSenas.Text + " Tipo de Uso: " + ddlTipoUso.SelectedItem + " Aseguradora: " + ddlAseguradora.SelectedItem + " Fecha de Robo:" + txtFechaRobo.Text + " Hora de Robo: " + txtHoraRobo.Text + " Estado del Vehiculo: " + ddlEstadoVehiculo.SelectedItem + " Propietario: " + ddlPropietario.SelectedItem + " Delito: " + ddlDelito.SelectedItem + " Numero de Motor: " + txtNumeroMotor.Text + " Registro Vehicular: " + txtRegistroVehicular.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                            
                            }
                        }
                    }



                    lblEstatus.Text = "DATOS GUARDADOS";
                    cmdGuardar.Enabled = false;
                    /*MENSAJE LOS DATOS SE IRAN A REPUVE*/
                    if (Session["op"].ToString() == "Agregar" && ddlEstadoVehiculo.SelectedItem.ToString() == "ROBADO" && ddlDelito.SelectedItem.ToString() == "ROBO DE VEHICULOS")
                    {
                        lblPregunta.Visible = true;
                    }

                }
                catch (Exception ex)
                {
                    lblEstatus.Text = ex.Message;
                    lblEstatus1.Text = "INTENTELO NUEVAMENTE";

                }
            }
        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
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

                else if (lblArbol.Text == "4")
                {
                    Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                }

                else if (lblArbol.Text == "5")
                {
                    Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
                }
                else if (lblArbol.Text == "6")
                {
                    if (Session["ID_PUESTO"].ToString() == "16")
                    {
                        Response.Redirect("OrdenCoordPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                    else if (Session["ID_PUESTO"].ToString() == "8")
                    {
                        Response.Redirect("OrdenPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                }
                else if (lblArbol.Text == "8")
                {
                    Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                }

            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }

        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MARCA"] = ddlMarca.SelectedValue.ToString();

            PGJ.CargaComboFiltrado(ddlSubMarca, "CAT_SUBMARCA", "id_submarca", "submarca", "id_marca=" + Session["ID_MARCA"]);
        }



        void cargarVehiculo()
        {
            SqlCommand sql = new SqlCommand("cargarVehiculo " + int.Parse(Session["ID_VEHICULO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_VEHICULO.Text = dr["ID_VEHICULO"].ToString();

                Session["ID_MARCA"] = dr["ID_MARCA"].ToString();
                ddlMarca.SelectedValue = dr["ID_MARCA"].ToString();
                txtNumeroAccidente.Text = dr["NUMERO_ACCIDENTE"].ToString();
                ddlPlacasEstado.SelectedValue = dr["ID_PLACA_ESTADO"].ToString();
                ddlSubMarca.SelectedValue = dr["ID_SUBMARCA"].ToString();
                ddlModelo.SelectedValue = dr["ID_MODELO"].ToString();
                ddlColor.SelectedValue = dr["ID_COLOR"].ToString();
                txtSerie.Text = dr["SERIE"].ToString();
                txtPlaca.Text = dr["PLACA"].ToString();
                ddlProcedencia.SelectedValue = dr["ID_PROCEDENCIA"].ToString();
                ddlTipoVehiculo.SelectedValue = dr["ID_TIPO_VEHICULO"].ToString();
                ddlDisposicion.SelectedValue = dr["ID_PUSO_DISPOSICION"].ToString();
                ddlAsegurado.SelectedValue = dr["ID_ASEGURADO"].ToString();
                txtObservaciones.Text = dr["OBSERVACIONES"].ToString();
                //nuevos campos
                ddlAseguradora.SelectedValue = dr["ID_ASEGURADORA"].ToString();
                ddlTipoUso.SelectedValue = dr["ID_TPO_USO_VEHICULO"].ToString();
                txtSenas.Text = dr["SENAS"].ToString();
                txtNumeroMotor.Text = dr["NUMERO_MOTOR"].ToString();
                txtRegistroVehicular.Text = dr["REGISTRO_NIV"].ToString();
            }
            dr.Close();
        }

        //metodo para cargar los datos de la tabla PGJ_VEHICULO_ROBADO_RECUPERADO
        void cargarVehiculoRobadoRecuperado()
        {
            SqlCommand sqlVRR = new SqlCommand("CargarVehiculoRobadoRecuperado " + int.Parse(Session["ID_VEHICULO"].ToString()), Data.CnnCentral);
            SqlDataReader drVRR = sqlVRR.ExecuteReader();
            if (drVRR.HasRows)
            {
                drVRR.Read();
                txtFechaRobo.Text = drVRR["FCHA_ROBO"].ToString();
                txtHoraRobo.Text = drVRR["HRA_ROBO"].ToString();
                ddlEstadoVehiculo.SelectedValue = drVRR["ID_ESTDO_VEHICULO"].ToString();
                ddlPropietario.SelectedValue = drVRR["ID_PERSONA_PRPIETRIO"].ToString();
                ddlDelito.SelectedValue = drVRR["ID_CONSECUTIVO_DELITO"].ToString();
                //campos de recuperado
                txtFechaRecuperado.Text = drVRR["FCHA_RCPRCION"].ToString();
                txtHoraRecuperado.Text = drVRR["HRA_RCPRCION"].ToString();
                ddlDepositado.SelectedValue = drVRR["ID_DEPOSITADO"].ToString();
                txtFechaDeposito.Text = drVRR["FCHA_DEPOSITADO"].ToString();
                txtHoraDeposito.Text = drVRR["HRA_DEPOSITADO"].ToString();

            }
            drVRR.Close();
        }

        //metodo para cargar los datos de la tabla PGJ_AUTORIZACION, siempre y cuando este activa y exista
        void cargarAutorizacion()
        {
            SqlCommand sqlMostrarAuto = new SqlCommand("MostrarAutorizacionActiva " + int.Parse(Session["ID_VEHICULO"].ToString()), Data.CnnCentral);
            SqlDataReader drMostrarAuto = sqlMostrarAuto.ExecuteReader();
            if (drMostrarAuto.HasRows)
            {
                drMostrarAuto.Read();
                txtAutorizacion.Text = drMostrarAuto["Autorizacion"].ToString();
                lblIdAutorizacion.Text = drMostrarAuto["IdAutorizacion"].ToString();
            }
            drMostrarAuto.Close();
        }

        protected void ddlProcedencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblProcedencia.Text = ddlProcedencia.SelectedItem.ToString();
            if (ddlProcedencia.SelectedItem.ToString() == "EXTRANJERO")
            {
                txtSenas.Enabled = true;//desbloqueamos el campo de señas
                txtPlaca.Enabled = false;//bloqueamos el campo de placa
                txtSenas.Text = txtPlaca.Text;//lo que se encuentre en el campo placa pasa a señas
                txtPlaca.Text = "PLACAEXTRA";
            }
            else
            {
                if (string.IsNullOrEmpty(txtSenas.Text))
                {
                    txtSenas.Enabled = false;//bloqueamos el campo
                    txtPlaca.Enabled = true;//visible el campo de placa
                    txtSenas.Enabled = false;//bloqueamos el campo
                    txtSenas.Text = "";//el campo senas, lo ponemos vacio
                }
                else
                {
                    txtPlaca.Text = txtSenas.Text;//lo que se encuentre en el campo señas pasa a placa
                    txtPlaca.Enabled = true;//visible el campo de placa
                    txtSenas.Enabled = false;//bloqueamos el campo
                    txtSenas.Text = "";//el campo senas, lo ponemos vacio
                }
                //txtPlaca.Text = txtSenas.Text;//lo que se encuentre en el campo señas pasa a placa
                //txtSenas.Enabled = false;//bloqueamos el campo
                //txtSenas.Text = "";//el campo senas, lo ponemos vacio
                //txtPlaca.Enabled = true;//visible el campo de placa

            }

        }

        protected void ddlDelito_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label14.Text = ddlDelito.SelectedValue.ToString();
            //CARGAR LA FECHA DE ROBO
            if (ddlDelito.SelectedValue.ToString() == "--SELECCIONA--")
            {
                txtFechaRobo.Text = "";
                txtHoraRobo.Text = "";

                ddlEstadoVehiculo.Enabled = false;
                ddlPropietario.Enabled = false;
                txtNumeroAccidente.Enabled = true;

            }
            else
            {
                txtNumeroAccidente.Enabled = false;
                ddlEstadoVehiculo.Enabled = false;
                ddlPropietario.Enabled = true;

                SqlCommand sqlFechaRobo = new SqlCommand("CargarFechaRoboVehiculo ", Data.CnnCentral);
                sqlFechaRobo.CommandType = CommandType.StoredProcedure;
                sqlFechaRobo.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                sqlFechaRobo.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.Int);
                sqlFechaRobo.Parameters.Add("@IdConsecutivoDelito", SqlDbType.Int);

                sqlFechaRobo.Parameters["@IdCarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
                sqlFechaRobo.Parameters["@IdMunicipioCarpeta"].Value = int.Parse(Session["IdMunicipio"].ToString());
                sqlFechaRobo.Parameters["@IdConsecutivoDelito"].Value = int.Parse(ddlDelito.SelectedValue.ToString());

                SqlDataReader drFechaRobo = sqlFechaRobo.ExecuteReader();
                if (drFechaRobo.HasRows)
                {
                    drFechaRobo.Read();
                    txtFechaRobo.Text = drFechaRobo["FechaHechos"].ToString();
                    txtHoraRobo.Text = drFechaRobo["HORA_HECHOS"].ToString();
                }
                drFechaRobo.Close();
            }
        }

        protected void ddlEstadoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmdGuardar.Enabled = true;
            txtObservaciones.Enabled = true;

            if (ddlDelito.SelectedValue.ToString() != "--SELECCIONA--" && ddlEstadoVehiculo.SelectedItem.ToString() == "RECUPERADO")
            {

                
                    txtHoraRecuperado.Text = DateTime.Now.ToString("hh:mm");
                    //txtHoraDeposito.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                    txtHoraDeposito.Text = DateTime.Now.ToString("hh:mm");
                    lblFechaRec.Visible = true;
                    txtFechaRecuperado.Visible = true;
                    lblHoraRec.Visible = true;
                    txtHoraRecuperado.Visible = true;
                    lblDepositado.Visible = true;
                    ddlDepositado.Visible = true;
                    lblFechaDepositado.Visible = true;
                    txtFechaDeposito.Visible = true;
                    lblHoraDepositado.Visible = true;
                    txtHoraDeposito.Visible = true;

                    if (txtAutorizacion.Text != "")
                    {
                        SqlCommand sqlFechaAutorizacion = new SqlCommand("MostrarFechaAutorizacion ", Data.CnnCentral);
                        sqlFechaAutorizacion.CommandType = CommandType.StoredProcedure;
                        sqlFechaAutorizacion.Parameters.Add("@IdCarpeta", SqlDbType.Int);
                        sqlFechaAutorizacion.Parameters.Add("@IdVehiculo", SqlDbType.Int);


                        sqlFechaAutorizacion.Parameters["@IdCarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
                        sqlFechaAutorizacion.Parameters["@IdVehiculo"].Value = int.Parse(Session["ID_VEHICULO"].ToString());

                        SqlDataReader drFechaAutorizacion = sqlFechaAutorizacion.ExecuteReader();
                        if (drFechaAutorizacion.HasRows)
                        {
                            drFechaAutorizacion.Read();
                            txtFechaRecuperado.Text = drFechaAutorizacion["FechaAutorizacion"].ToString();
                            txtHoraRecuperado.Text = drFechaAutorizacion["HoraAutorizacion"].ToString();
                        }
                        drFechaAutorizacion.Close();
                        txtFechaRecuperado.Enabled = false;
                    }
                
            }
            else
            {
                lblFechaRec.Visible = false;
                txtFechaRecuperado.Visible = false;
                lblHoraRec.Visible = false;
                txtHoraRecuperado.Visible = false;
                lblDepositado.Visible = false;
                ddlDepositado.Visible = false;
                lblFechaDepositado.Visible = false;
                txtFechaDeposito.Visible = false;
                lblHoraDepositado.Visible = false;
                txtHoraDeposito.Visible = false;

            }


            // if (ddlDelito.SelectedValue.ToString()=="--SELECCIONA--")
        }

        DateTime fecha;
        string ExisteAutorizacion;
        protected void btnAutorizacion_Click(object sender, EventArgs e)
        {
            lblErrorAuto.Text = "";




            //VERIFICAR SI EXISTE UNA AUTORIZACION ACTIVA
            SqlCommand sqlAutorizacion = new SqlCommand("ExisteAutorizacionActiva ", Data.CnnCentral);
            sqlAutorizacion.CommandType = CommandType.StoredProcedure;
            sqlAutorizacion.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            sqlAutorizacion.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            sqlAutorizacion.Parameters.Add("@IdVehiculo", SqlDbType.Int);

            sqlAutorizacion.Parameters["@IdCarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
            sqlAutorizacion.Parameters["@IdMunicipio"].Value = int.Parse(Session["IdMunicipio"].ToString());
            sqlAutorizacion.Parameters["@IdVehiculo"].Value = int.Parse(ID_VEHICULO.Text);

            SqlDataReader drAutorizacion = sqlAutorizacion.ExecuteReader();
            if (drAutorizacion.HasRows)
            {
                drAutorizacion.Read();
                ExisteAutorizacion=drAutorizacion["Existe"].ToString();
            }
            drAutorizacion.Close();
            
            //FIN VERIFICAR SI EXISTE UNA AUTORIZACION ACTIVA

            if (ExisteAutorizacion == "0")//no existe registro de autorizacion ACTIVA, se genera una nueva
            {
                Random aleatorio = new Random();
                int numero = aleatorio.Next(10000, (90000));
                //txtNumero.Text = numero.ToString();
                fecha = DateTime.Now;
                string fechaA = fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yy");
                string horaA = fecha.ToString("hh") + fecha.ToString("mm") + fecha.ToString("ss");

                string autorizacion = numero.ToString() + fechaA + horaA + Session["USUARIO"].ToString();

                using (MD5 md5Hash = MD5.Create())
                {
                    string autorizacionHash = GetMd5Hash(md5Hash, autorizacion);
                    txtAutorizacion.Text = autorizacionHash;

                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Genero Codigo de Autorizacion: " + txtAutorizacion.Text + " IdVehiculo=" + ID_VEHICULO.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                }
                btnGuardarAut.Visible = true;
                btnAutorizacion.Visible = false;
            }
            else {
                lblErrorAuto.Text = "YA EXISTE UN CODIGO DE AUTORIZACIÓN";
            }


        }


        static string GetMd5Hash(MD5 md5Hash, string autorizacion)
        {
            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(autorizacion));


            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        protected void btnGuardarAut_Click(object sender, EventArgs e)
        {
           



            try
            {
                PGJ.InsertaAutorizacion(int.Parse(Session["ID_CARPETA"].ToString()), int.Parse(Session["IdMunicipio"].ToString()), int.Parse(ID_VEHICULO.Text), int.Parse(Session["IdUsuario"].ToString()), txtAutorizacion.Text);

                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserto Codigo de Autorizacion: " + txtAutorizacion.Text + " IdVehiculo=" + ID_VEHICULO.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                //btnAutorizacion.Visible = true;
                lblErrorAuto.Text = "CODIGO DE AUTORIZACIÓN GUARDADA";
                btnDescargarDocumento.Visible = false;
                cargarAutorizacion();
                DesactivarControlesRobado();
            }
            catch (Exception ex)
            {
                lblErrorAuto.Text = ex.Message;
            }

            btnAutorizacion.Visible = true;
            btnGuardarAut.Visible = false;
        }

       
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.pdf";
        protected void btnDescargarDocumento_Click(object sender, EventArgs e)
        {

            btnGuardarAut.Visible = false;
            try
            {

                //Session["ID_PLANTILLA"] = "OFICIODEVOLUCIONVEHICULO.doc";
                //DocumentoVehiculo.NombrePlantilla = "OFICIODEVOLUCIONVEHICULO";
                LeerDeBD();
                btnGuardarDocu.Visible = false;
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
                cerrarWord();
            }
        }

        public void LeerDeBD()
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("select * from CAT_PLANTILLAS where NOMBRE_PLANTILLA='OFICIODEVOLUCIONVEHICULO'" , Data.CnnCentral);
            //SqlCommand comm = new SqlCommand("SELECT * FROM CAT_PLANTILLAS " + " WHERE ID_PLANTILLA = " + Archivos.IdPlantilla, Data.CnnCentral);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            //Creamos un array de bytes que contiene los bytes almacenados
            //en el campo Documento de la tabla
            byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
            //Vamos a guardar ese array de bytes como un fichero en el
            //disco duro, un fichero temporal que después se podrá descartar.
            string sFile = "TMP" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".doc";
            //Creamos un nuevo FileStream, que esta vez servirá para
            //crear un fichero con el nombre especificado
            fs = new FileStream(Server.MapPath(".") +
            @"\DocTmp\" + sFile, FileMode.Create);
            //Y escribimos en disco el array de bytes que conforman
            //el fichero Word 
            fs.Write(bits, 0, Convert.ToInt32(bits.Length));
            if (File.Exists((string)fs.Name))
            {
                object readOnly = true;
                object isVisible = true;
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = true;
                Documento = wordApp.Documents.Open(fs.Name, ref missing,
                ref readOnly, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref isVisible, ref missing, ref missing,
                ref missing, ref missing);
                fs.Close();
                Documento.Activate();
                //object saveChanges = true;
                //object FormatOriginal = true;
                traerMarcadoresProcedimientos();
                //traermarcadoresText(Archivos.IdPlantilla);
                Documento = wordApp.Documents[sFile] as Word.Document;
                Documento.Close(Word.WdSaveOptions.wdSaveChanges);
                //wordApp.Documents.Close();
                wordApp.Application.Quit();

                string script = "<script languaje='javascript'> ";
                script += "mostrarFichero('DocTmp/" + sFile + "') ";
                script += "</script>" + Environment.NewLine;
                Page.RegisterStartupScript("mostrarFichero", script);
            }
            //LeerPDF();
        }

        public void traerMarcadoresProcedimientos()
        {
            SqlDataAdapter daPlantilla = new SqlDataAdapter("consultaCAT_PLANTILLAS_MARCADORES_OficioVehiculos ", Data.CnnCentral);
            DataSet dsPlantilla = new DataSet();
            daPlantilla.Fill(dsPlantilla, "PLANTILLAS");
            foreach (DataRow drPlantilla in dsPlantilla.Tables["PLANTILLAS"].Rows)
            {
                object oBookMark = drPlantilla["ID_MARCADOR"].ToString();
                traerInformacionMarcador(drPlantilla["ID_PROCEDIMIENTO"].ToString());
                Documento.Bookmarks.get_Item(ref oBookMark).Range.Text = textoMarcador;

            }
            dsPlantilla.Dispose();
            daPlantilla.Dispose();
        }

        public void traerInformacionMarcador(string idProcedimiento)
        {
            //string cad = idProcedimiento;
            textoMarcador = "VACIO";
            SqlDataAdapter daParametros = new SqlDataAdapter("PARAMETROS_SP '" + idProcedimiento + "'", Data.CnnCentral);
            DataSet dsParametros = new DataSet();
            daParametros.Fill(dsParametros, "Parametros");
            SqlCommand cmd = new SqlCommand(idProcedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;
            //if (dsParametros.Tables["Parametros"].Rows.Count != null )
            //{
            foreach (DataRow drParametros in dsParametros.Tables["Parametros"].Rows)
            {
                if (drParametros["Parametro"].ToString() != "NULO")
                {
                    if (drParametros["Parametro"].ToString() == "@IdCarpeta")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = int.Parse(Session["ID_CARPETA"].ToString());
                    }
                    if (drParametros["Parametro"].ToString() == "@IdUsuario")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = int.Parse(Session["IdUsuario"].ToString());
                    }
                    if (drParametros["Parametro"].ToString() == "@IdMunicipio")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = int.Parse(Session["IdMunicipio"].ToString());
                    }
                    if (drParametros["Parametro"].ToString() == "@IdVehiculo")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = int.Parse(ID_VEHICULO.Text);
                    }
                    if (drParametros["Parametro"].ToString() == "@IdPersona")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = int.Parse(ddlPropietario.SelectedValue.ToString());
                    }

                }
                //}
            }
            dsParametros.Dispose();
            daParametros.Dispose();
            SqlDataReader drTextoMarcador = cmd.ExecuteReader();
            if (drTextoMarcador.HasRows)
            {
                drTextoMarcador.Read();
                textoMarcador = drTextoMarcador["Marcador"].ToString();
            }
            cmd.Dispose();
            drTextoMarcador.Close();
            drTextoMarcador.Dispose();
        }

        public void cerrarWord()
        {
            foreach (Process p in System.Diagnostics.Process.GetProcessesByName("winword"))
            {
                try
                {
                    p.Kill();
                    p.WaitForExit(); // possibly with a timeout
                }
                catch (Win32Exception winException)
                {
                    // process was terminating or can't be terminated - deal with it
                }
                catch (InvalidOperationException invalidException)
                {
                    // process has already exited - might be able to let this one go
                }
            }
        }

        short IdPlantillaBD;
        protected void btnGuardarDocu_Click(object sender, EventArgs e)
        {
            
            SqlCommand sqlIdPlantilla = new SqlCommand("mostrarIdPlantilla ", Data.CnnCentral);
            sqlIdPlantilla.CommandType = CommandType.StoredProcedure;

            SqlDataReader drIdPlantilla = sqlIdPlantilla.ExecuteReader();
            if (drIdPlantilla.HasRows)
            {
                drIdPlantilla.Read();
                IdPlantillaBD = short.Parse(drIdPlantilla["ID_PLANTILLA"].ToString());
            }
            drIdPlantilla.Close();


            try
            {
                if (fileUpload.HasFile)
                {

                    using (BinaryReader reader = new BinaryReader(fileUpload.PostedFile.InputStream))
                    {

                        byte[] Pdf = reader.ReadBytes(fileUpload.PostedFile.ContentLength);
                        DocumentoVehiculo.InsertaPDFVehiculo(int.Parse(Session["ID_CARPETA"].ToString()), Pdf, "OFICIO DE DEVOLUCION DE VEHICULO", IdPlantillaBD, short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), int.Parse(ID_VEHICULO.Text), int.Parse(lblIdAutorizacion.Text));
                    }
                }
                lblEstatus.Text = "DOCUMENTO GUARDADO";
               
                fileUpload.Enabled = false;
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }


            existeDocumento();
        }

        public void DesactivarControlesRobado()
        {
            txtNumeroAccidente.Enabled = false;
            ddlDelito.Enabled = false;
            ddlMarca.Enabled = false;
            ddlSubMarca.Enabled = false;
            ddlModelo.Enabled = false;
            ddlColor.Enabled = false;
            ddlProcedencia.Enabled = false;
            txtSerie.Enabled = false;
            txtPlaca.Enabled = false;
            ddlPlacasEstado.Enabled = false;
            txtSenas.Enabled = false;
            ddlTipoVehiculo.Enabled = false;
            ddlDisposicion.Enabled = false;
            ddlAsegurado.Enabled = false;
            ddlAseguradora.Enabled = false;
            ddlTipoUso.Enabled = false;
            ddlPropietario.Enabled = false;

            if (txtAutorizacion.Text != "")
            {
                ddlEstadoVehiculo.Enabled = false;
            }
            else {
                ddlEstadoVehiculo.Enabled = false;
            }

            txtNumeroMotor.Enabled = false;
            txtRegistroVehicular.Enabled = false;
            txtFechaRobo.Enabled = false;
            txtHoraRobo.Enabled = false;
            txtObservaciones.Enabled = false;
            cmdGuardar.Enabled = false;
        }

        public void DesactivarControlesRecuperado()
        {
            txtNumeroAccidente.Enabled = false;
            ddlDelito.Enabled = false;
            ddlMarca.Enabled = false;
            ddlSubMarca.Enabled = false;
            ddlModelo.Enabled = false;
            ddlColor.Enabled = false;
            ddlProcedencia.Enabled = false;
            txtSerie.Enabled = false;
            txtPlaca.Enabled = false;
            ddlPlacasEstado.Enabled = false;
            txtSenas.Enabled = false;
            ddlTipoVehiculo.Enabled = false;
            ddlDisposicion.Enabled = false;
            ddlAsegurado.Enabled = false;
            ddlAseguradora.Enabled = false;
            ddlTipoUso.Enabled = false;
            ddlPropietario.Enabled = false;
            ddlEstadoVehiculo.Enabled = false;
            txtNumeroMotor.Enabled = false;
            txtRegistroVehicular.Enabled = false;
            txtFechaRobo.Enabled = false;
            txtHoraRobo.Enabled = false;
            txtObservaciones.Enabled = false;
            txtFechaRecuperado.Enabled = false;
            txtHoraRecuperado.Enabled = false;
            ddlDepositado.Enabled = false;
            txtFechaDeposito.Enabled = false;
            txtHoraDeposito.Enabled = false;
            cmdGuardar.Enabled = false;
        }

        string existeDo;
        void existeDocumento()
        {
            /*SI EXISTE DOCUMENTO*/

            SqlCommand sqlDoc = new SqlCommand("existeDocumentoPDFVehiculo", Data.CnnCentral);
            sqlDoc.CommandType = CommandType.StoredProcedure;
            sqlDoc.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            sqlDoc.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            sqlDoc.Parameters.Add("@IdVehiculo", SqlDbType.Int);

            sqlDoc.Parameters["@IdCarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
            sqlDoc.Parameters["@IdMunicipio"].Value = int.Parse(Session["IdMunicipio"].ToString());
            sqlDoc.Parameters["@IdVehiculo"].Value = int.Parse(ID_VEHICULO.Text);

            SqlDataReader drDoc = sqlDoc.ExecuteReader();
            if (drDoc.HasRows)
            {
                drDoc.Read();
                existeDo = drDoc["Existe"].ToString();
            }
            drDoc.Close();
            if (existeDo != "0")
            {
                btnGuardarDocu.Visible = false;
                btnDescargarDocumento.Visible = false;
                fileUpload.Visible = false;
                Label332.Visible = false;
            }
            else {
                btnGuardarDocu.Visible = false;
                btnDescargarDocumento.Visible = false;
                fileUpload.Visible = true;
                Label332.Visible = true;
            }

            /*EXISTE DOCUMENTO*/
        }







    }
}