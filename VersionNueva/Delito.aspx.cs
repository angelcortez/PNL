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

namespace AtencionTemprana
{
    public partial class Delito : System.Web.UI.Page
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
                HookOnFocus(this.Page as Control);
                ScriptManager.RegisterStartupScript(
                this,
                typeof(Delito),
                "ScriptDoFocus",
                SCRIPT_DOFOCUS.Replace("REQUEST_LASTFOCUS", Request["__LASTFOCUS"]),
                true);
                //----

                lblArbol.Text = Session["lblArbol"].ToString();

                //Session["ID_LUGAR_HECHOS"] = Request.QueryString["ID_LUGAR_HECHOS"];
                Session["ID_CONSECUTIVO_DELITO"] = Request.QueryString["ID_CONSECUTIVO_DELITO"];
                Session["ID_LUGAR_HECHOS"] = Request.QueryString["ID_LUGAR_HECHOS"];
                LBLUSUARIO.Text = Session["Us"].ToString();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                Session["op"] = Request.QueryString["op"];

                
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
                if (Session["INICIAR_CARPETA"] == null)
                {
                    Session["INICIAR_CARPETA"] = "";
                }

         

                Session["ID_ESTADO_RAC"].ToString();
                Session["ID_ESTADO_NUC"].ToString();
                Session["ID_ESTADO_NAC"].ToString();
                Session["ID_ESTADO_NUM"].ToString();
                

                cargarFecha();
               
                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR DELITO";
                    ID_LUGAR_HECHOS.Text = Session["ID_LUGAR_HECHOS"].ToString();
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    try{
                    PGJ.CargaCombo(ddlDelito, "CAT_DELITO", "ID_DLTO", "DLTO");
                    PGJ.CargaCombo(ddlModalidad, "CAT_MODALIDAD", "ID_MDLDD", "MDLDD");
                    ddlModalidad.Items.Insert(0, "--SELECCIONE--");
                    ddlClasificacion.Items.Insert(0, "--SELECCIONE--");
                    ddlCorporacion.Items.Insert(0, "--SELECCIONE--");
                    dllSujetoInterviene.Items.Insert(0, "--SELECCIONE--");

                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Delito.aspx?&op=Agregar");
                    }
                   // articuloDelito();
                    //consultaIdDelito();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR DELITO";
                    try
                    {
                        PGJ.CargaCombo(ddlDelito, "CAT_DELITO", "ID_DLTO", "DLTO");
                        PGJ.CargaCombo(ddlModalidad, "CAT_MODALIDAD", "ID_MDLDD", "MDLDD");
                        cargarDelito();
                        PGJ.CargaComboFiltrado(dllSujetoInterviene, "PNL_CAT_SUJETOS_INTERVIENE", "IdSujetoInterviene", "SujetoInterviene", "IdDelito=" + Session["ID_DELITO"]);
                        PGJ.CargaCombo(ddlCorporacion, "PNL_CAT_TIPO_SUJETO_INTERVIENE", "IdCorporacion", "Corporacion");
                        dllSujetoInterviene.Items.Insert(0, "--SELECCIONE--");
                        ddlCorporacion.Items.Insert(0, "--SELECCIONE--");
                        cargarSujetos();
                       
           

                        ////
                        SqlCommand sqlDelitoSujeto = new SqlCommand("SP_ExisteDelitoSujetos ", Data.CnnCentral);
                        sqlDelitoSujeto.CommandType = CommandType.StoredProcedure;
                        sqlDelitoSujeto.Parameters.Add("@IdDelito", SqlDbType.Int);
                        sqlDelitoSujeto.Parameters["@IdDelito"].Value = int.Parse(Session["ID_DELITO"].ToString());

                        SqlDataReader drAutorizacion = sqlDelitoSujeto.ExecuteReader();
                        if (drAutorizacion.HasRows)
                        {
                            drAutorizacion.Read();
                            ExisteDelito = drAutorizacion["Existe"].ToString();
                        }
                        drAutorizacion.Close();

                        if (ExisteDelito != "0")
                        {
                            dllSujetoInterviene.Visible = true;
                            lblSujetoInterviene.Visible = true;

                            PGJ.CargaComboFiltrado(dllSujetoInterviene, "PNL_CAT_SUJETOS_INTERVIENE", "IdSujetoInterviene", "SujetoInterviene", "IdDelito=" + Session["ID_DELITO"]);
                        }
                        else
                        {
                            dllSujetoInterviene.Visible = false;
                            lblSujetoInterviene.Visible = false;
                        }
                        //

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Delito IdConsecutivoDelio=" + ID_CONSECUTIVO_DELITO.Text + " IdLugarHechos=" + ID_LUGAR_HECHOS.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                        rbPrincipal.Enabled = false;
                        //El Policia Investigador no puede modificar
                        if (Session["ID_PUESTO"].ToString() == "16" || Session["ID_PUESTO"].ToString() == "8")
                        {
                            cmdGu.Visible = false;
                        }
                        if (ddlDelito.SelectedValue == "33")
                        {
                            cmdGu.Text = "MODIFICAR INFORMACIÓN DEL HOMICIDIO";
                            cmdGu.Width = 300;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Delito.aspx?ID_CONSECUTIVO_DELITO=" + Session["ID_CONSECUTIVO_DELITO"].ToString() + "&op=Modificar");
                    }
                    
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

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            try
            {

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
                    if (Session["ID_PUESTO"].ToString() == "16")
                    {
                        Response.Redirect("OrdenCoordPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                    else if (Session["ID_PUESTO"].ToString() == "8")
                    {
                        Response.Redirect("OrdenPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;

            }
            
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            
            //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
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
        string corporacion;
        string sujeto;
        string existeDe;
        protected void cmdGu_Click(object sender, EventArgs e)
        {

            lblError.Text = "";



            if (Session["op"].ToString() == "Agregar")
            {
                SqlCommand sqlDoc = new SqlCommand("SP_ExisteDP", Data.CnnCentral);
                sqlDoc.CommandType = CommandType.StoredProcedure;
                sqlDoc.Parameters.Add("@idcarpeta", SqlDbType.Int);
                sqlDoc.Parameters.Add("@idmunicipio", SqlDbType.Int);

                sqlDoc.Parameters["@idcarpeta"].Value = int.Parse(Session["ID_CARPETA"].ToString());
                sqlDoc.Parameters["@idmunicipio"].Value = int.Parse(Session["IdMunicipio"].ToString());

                SqlDataReader drDoc = sqlDoc.ExecuteReader();
                if (drDoc.HasRows)
                {
                    drDoc.Read();
                    existeDe = drDoc["Existe"].ToString();
                }
                drDoc.Close();


                if (rbPrincipal.SelectedValue == "1" && existeDe == "1")
                {
                    lblError.Text = "1";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('YA EXISTE UN DELITO COMO PRINCIPAL.')", true);
                }
                if (rbPrincipal.SelectedValue == "0" && existeDe == "0")
                {
                    lblError.Text = "1";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DELITO DEBERIA SER MARCADO COMO PRINCIPAL DEBIDO A QUE LA CARPETA NO CUENTA CON DELITO PRINCIPAL.')", true);
                }

                if (ddlCorporacion.Visible==true && ddlCorporacion.SelectedValue.ToString() == "--SELECCIONE--") //Corporación
                {
                    lblError.Text = "1";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA CORPORACIÓN OBLIGATORIO.')", true);
                }
                if (dllSujetoInterviene.Visible == true && dllSujetoInterviene.SelectedValue.ToString() == "--SELECCIONE--") //Sujeto interviene
                {
                    lblError.Text = "1";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('CAMPO DE CAPTURA SUJETO INTERVIENE OBLIGATORIO.')", true);
                }
            }


            if (lblError.Text == "")
            {

                if (Session["op"].ToString() == "Agregar")
                {
                    lblEstatus.Text = "";
                    if (ddlCorporacion.SelectedValue.ToString() == "")
                    {
                        corporacion = "0";
                    }
                    else
                    {
                        corporacion = ddlCorporacion.SelectedValue.ToString();

                    }
                    if (dllSujetoInterviene.SelectedValue.ToString() == "")
                    {
                        sujeto = "0";
                    }
                    else
                    {
                        sujeto = dllSujetoInterviene.SelectedValue.ToString();

                    }
                    PGJ.InsertaDelito(int.Parse(IdCarpeta.Text), short.Parse(ddlDelito.SelectedValue.ToString()), short.Parse(ddlModalidad.SelectedValue.ToString()), short.Parse(rbViolencia.SelectedValue.ToString()), short.Parse(rbGrave.SelectedValue.ToString()), short.Parse(rbPrincipal.SelectedValue.ToString()), int.Parse(ID_LUGAR_HECHOS.Text), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(ddlClasificacion.SelectedValue.ToString()),
                    int.Parse(sujeto), int.Parse(corporacion));
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Delito " + "IdCarpeta=" + IdCarpeta.Text + " Delito Principal: " + rbPrincipal.SelectedItem + " Delito: " + ddlDelito.SelectedItem + " Modalidad: " + ddlModalidad.SelectedItem + " Clasificacion:" + ddlClasificacion.SelectedItem + " Violencia: " + rbViolencia.SelectedItem + " Grave: " + rbGrave.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));

                    lblEstatus.Text = "DATOS GUARDADOS";
                    cmdGu.Enabled = false;
                }

                else if (Session["op"].ToString() == "Modificar")
                {
                    lblEstatus.Text = "";
                    if (ddlCorporacion.SelectedValue.ToString() == "")
                    {
                        corporacion = "0";
                    }
                    else
                    {
                        corporacion = ddlCorporacion.SelectedValue.ToString();
                    }
                    if (dllSujetoInterviene.SelectedValue.ToString() == "")
                    {
                        sujeto = "0";
                    }
                    else
                    {
                        sujeto = dllSujetoInterviene.SelectedValue.ToString();
                    }
                    PGJ.ActualizarDelito(int.Parse(ID_CONSECUTIVO_DELITO.Text), short.Parse(ddlDelito.SelectedValue.ToString()), short.Parse(ddlModalidad.SelectedValue.ToString()), short.Parse(rbViolencia.SelectedValue.ToString()), short.Parse(rbGrave.SelectedValue.ToString()), short.Parse(rbPrincipal.SelectedValue.ToString()), short.Parse(ddlClasificacion.SelectedValue.ToString()),
                        int.Parse(sujeto), int.Parse(corporacion));
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Delito " + "IdCarpeta=" + Session["ID_CARPETA"] + " Delito Principal: " + rbPrincipal.SelectedItem + " Delito: " + ddlDelito.SelectedItem + " Modalidad: " + ddlModalidad.SelectedItem + " Clasificacion:" + ddlClasificacion.SelectedItem + " Violencia: " + rbViolencia.SelectedItem + " Grave: " + rbGrave.SelectedItem, int.Parse(Session["IdModuloBitacora"].ToString()));

                    if (ddlDelito.SelectedValue == "33")
                    {
                        ConsultarIDHechos();
                        Session["ID_MODALIDAD"] = ddlModalidad.SelectedValue;
                        Response.Redirect("Homicidios.aspx");
                    }

                    lblEstatus.Text = "DATOS GUARDADOS";
                    cmdGu.Enabled = false;
                }

                try
                {
                    if (lblArbol.Text == "2")
                    {

                        if (Session["op"].ToString() == "Agregar" && Session["INICIAR_CARPETA"].ToString() == "1")
                        {
                            Response.Redirect("Hechos.aspx?&op=Agregar");
                        }
                        else
                        {
                            Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString());
                        }
                        //Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString());
                    }

                    else if (lblArbol.Text == "3")
                    {
                        Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString());
                    }

                    else if (lblArbol.Text == "4")
                    {
                        if (Session["op"].ToString() == "Agregar" && Session["INICIAR_CARPETA"].ToString() == "1")
                        {
                            Response.Redirect("Hechos.aspx?&op=Agregar");

                        }
                        else
                        {
                            Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                        }

                        //Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
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
                    Session["INICIAR_CARPETA"] = "0";
                }
                catch (Exception ex)
                {
                    lblEstatus.Text = ex.Message;

                }

            }

        }



        public void ConsultarIDHechos()
        {
            SqlCommand comm = new SqlCommand("SELECT ID_LUGAR_HECHOS  FROM PGJ_DELITOS WHERE ID_CARPETA = " + Session["ID_CARPETA"].ToString() + " AND ID_CONSECUTIVO_DELITO=" + Session["ID_CONSECUTIVO_DELITO"].ToString(), Data.CnnCentral);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["ID_LUGAR_HECHOS"] = dr["ID_LUGAR_HECHOS"].ToString();
                }
                dr.Close();
            }

        }




        //void consultaIdDelito()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdDelito", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_CONSECUTIVO_DELITO.Text = dr["ID_CONSECUTIVO_DELITO"].ToString();
        //    //}
        //    dr.Close();
        //}

        void cargarDelito()
        {
            SqlCommand sql = new SqlCommand("cargarDelito " + int.Parse(Session["ID_CONSECUTIVO_DELITO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ID_CONSECUTIVO_DELITO.Text = dr["ID_CONSECUTIVO_DELITO"].ToString();
                ID_LUGAR_HECHOS.Text = dr["ID_LUGAR_HECHOS"].ToString();
                Session["ID_DELITO"] = dr["ID_DELITO"].ToString();
                consultaDelitoAccion();
                ddlDelito.SelectedValue = dr["ID_DELITO"].ToString();
                lblArticulo.Text = dr["FUNDAMENTO"].ToString();
                ddlClasificacion.SelectedValue = dr["ID_ACCION"].ToString();
                ddlModalidad.SelectedValue = dr["ID_MODALIDAD"].ToString();
                                                      
                rbViolencia.SelectedValue = dr["ID_VIOLENCIA"].ToString();
                rbGrave.SelectedValue = dr["ID_GRAVE"].ToString();
                rbPrincipal.SelectedValue = dr["ID_PRINCIPAL"].ToString();
            }
            dr.Close();
        }

        void cargarSujetos()
        {
            SqlCommand sql = new SqlCommand("SP_CargarSujetos " + int.Parse(Session["ID_CONSECUTIVO_DELITO"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();


                dllSujetoInterviene.SelectedValue = dr["IdSujetoInterviene"].ToString();
                ddlCorporacion.SelectedValue = dr["IdTipoSujetoInterviene"].ToString();

                //Label1.Text ="VALOR"+ dr["IdSujetoInterviene"].ToString();
                if (dr["IdSujetoInterviene"].ToString() == "1")

                {
                    ddlCorporacion.Visible = true;
                    lblTipoSujetoInterviene.Visible = true;
                    lblSujetoInterviene.Visible = true;
                    dllSujetoInterviene.Visible = true;
                }
            }
            dr.Close();
        }



        void articuloDelito()
        {
            SqlCommand sql = new SqlCommand("ArticuloDelito " + int.Parse(ddlDelito.SelectedValue.ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                lblArticulo.Text = dr["FUNDAMENTO"].ToString();
                
            }
            dr.Close();
        }

        string ExisteDelito;
        protected void ddlDelito_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            Session["ID_DELITO"] = ddlDelito.SelectedValue.ToString();
            consultaDelitoAccion();
            articuloDelito();

            SqlCommand sqlDelitoSujeto = new SqlCommand("SP_ExisteDelitoSujetos ", Data.CnnCentral);
            sqlDelitoSujeto.CommandType = CommandType.StoredProcedure;
            sqlDelitoSujeto.Parameters.Add("@IdDelito", SqlDbType.Int);
            sqlDelitoSujeto.Parameters["@IdDelito"].Value = int.Parse(Session["ID_DELITO"].ToString());

            SqlDataReader drAutorizacion = sqlDelitoSujeto.ExecuteReader();
            if (drAutorizacion.HasRows)
            {
                drAutorizacion.Read();
                ExisteDelito = drAutorizacion["Existe"].ToString();
            }
            drAutorizacion.Close();

            if (ExisteDelito != "0")
            {
                dllSujetoInterviene.Visible = true;
                lblSujetoInterviene.Visible = true;
                ddlCorporacion.Visible = false;
                lblTipoSujetoInterviene.Visible = false;
                PGJ.CargaComboFiltrado(dllSujetoInterviene, "PNL_CAT_SUJETOS_INTERVIENE", "IdSujetoInterviene", "SujetoInterviene", "IdDelito=" + Session["ID_DELITO"]);
            }
            else {
                dllSujetoInterviene.Visible = false;
                lblSujetoInterviene.Visible = false;
            }

            Label1.Text = ExisteDelito;

        }

        void consultaDelitoAccion()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaAccionDelito(short.Parse(Session["ID_DELITO"].ToString()))
                         select new { c.ID_ACCION, c.ACCION };
            ddlClasificacion.DataSource = estado;
            ddlClasificacion.DataValueField = "ID_ACCION";
            ddlClasificacion.DataTextField  = "ACCION";
            ddlClasificacion.DataBind();
        }

        protected void dllSujetoInterviene_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            if (dllSujetoInterviene.SelectedItem.ToString() == "SERVIDORES PÚBLICOS")
            {
                ddlCorporacion.Visible = true;
                lblTipoSujetoInterviene.Visible = true;
                PGJ.CargaCombo(ddlCorporacion, "PNL_CAT_TIPO_SUJETO_INTERVIENE", "IdCorporacion", "Corporacion");
            }
        }

        
    }
}