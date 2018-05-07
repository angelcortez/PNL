using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class IPHRegistro : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Session["ID_USUARIO"] = Request.QueryString["ID_USUARIO"];
                Session["ID_IPH"] = Request.QueryString["ID_IPH"];
                Session["op"] = Request.QueryString["op"];


   
                PGJ.ConnectServer();
                SqlCommand cmd = new SqlCommand("SELECT  GETDATE()  as FechaActual", Data.CnnCentral);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    lblFecha.Text = rd["FechaActual"].ToString();
                    rd.Close();
                }
               
                
                LBLUSUARIO.Text = Session["Us"].ToString();


               // if (Session["op"].ToString() == "Agregar")
                //{
                    lblOperacionIPH.Text = "AGREGAR IPH";
                    Session["ID_USUARIO"] = Request.QueryString["ID_USUARIO"];
                    Session["ID_IPH"] = Request.QueryString["ID_IPH"];


                /*
                }

                else if (Session["op"].ToString() == "Modificar")
                {

                    lblOperacionIPH.Text = "MODIFICAR IPH";
                    Session["ID_USUARIO"] = Request.QueryString["ID_USUARIO"];
                    Session["ID_IPH"] = Request.QueryString["ID_IPH"];



                    cargarIPH();
                }
                 */



            }


        }



        protected void btnGuardarInformePH_Click(object sender, EventArgs e)
        {

            //if (Session["op"].ToString() == "Agregar")
            //{
                PGJ.InsertaIPH(
                    txtFolioIPH.Text, txtOficioIPH.Text, DateTime.Parse(txtFechaEventoIPH.Text.ToString()),    // txtHoraEventoIPH.Text,
                    txtAsuntoDT_IPH.Text, txtDirigidoDT_IPH.Text,


                        txtAgentesDT_IPH.Text, short.Parse(rblOperativo_IPH.SelectedValue.ToString()),
                        /*   chblParticipacionDT_IPH   */  
                        txtNomComanDT_IPH.Text, 
                        txtTipoEvenMot_IPH.Text,  short.Parse(ddlTipoArmaAA_IPH.SelectedValue.ToString()), txtDescAA_IPH.Text,
                        short.Parse(ddlArmasAA_IPH.SelectedValue.ToString()), txtMarcaAA_IPH.Text, txtTipoAA_IPH.Text, txtCalibreAA_IPH.Text, txtMatriculaAA_IPH.Text,
                        txtSerieAA_IPH.Text, txtTipoDA_IPH.Text, txtUnidadMedidaDA_IPH.Text, txtCantidadDA_IPH.Text, txtObservaDA_IPH.Text, txtTipoObjetoOOA_IPH.Text,
                        txtCantidadOOA_IPH.Text, txtDescOOA_IPH.Text, txtDescICE_IPH.Text, txtFechaDictamenICE_IPH.Text, txtObservaGeneraInfo_IPH.Text
                        );           
                   
           
            
            //}
            
            //else if (Session["op"].ToString() == "Modificar")
            //{
              //  PGJ.ActualizaIPH(
                //     txtFolioIPH.Text, txtOficioIPH.Text, txtFechaEventoIPH.Text, txtHoraEventoIPH.Text, txtAsuntoDT_IPH.Text, txtDirigidoDT_IPH.Text,
                  //      txtAgentesDT_IPH.Text, short.Parse(rblOperativo_IPH.SelectedValue.ToString()),   /*   chblParticipacionDT_IPH  */
                    //    txtNomComanDT_IPH.Text,
                      //  txtTipoEvenMot_IPH.Text, short.Parse(ddlTipoArmaAA_IPH.SelectedValue.ToString()), txtDescAA_IPH.Text,
                        //short.Parse(ddlArmasAA_IPH.SelectedValue.ToString()), txtMarcaAA_IPH.Text, txtTipoAA_IPH.Text, txtCalibreAA_IPH.Text, txtMatriculaAA_IPH.Text,
                    //    txtSerieAA_IPH.Text, txtTipoDA_IPH.Text, txtUnidadMedidaDA_IPH.Text, txtCantidadDA_IPH.Text, txtObservaDA_IPH.Text, txtTipoObjetoOOA_IPH.Text,
                    //    txtCantidadOOA_IPH.Text, txtDescOOA_IPH.Text, txtDescICE_IPH.Text, txtFechaDictamenICE_IPH.Text, txtObservaGeneraInfo_IPH.Text,
                      //  int.Parse(Session["ID_IPH"].ToString())     
               
                   // );

           // }

            


            lblEstatusIPH.Text = "DATOS GUARDADOS";
            btnGuardarInformePH.Enabled = false;



       }

        protected void btnCancelarInformePH_Click(object sender, EventArgs e)
        {

            Session["op"] = " ";

            Page.MaintainScrollPositionOnPostBack = false;

            Response.Redirect("IPH.aspx");

           
            

        }


        void cargarIPH()
        {
            SqlCommand sql = new SqlCommand("cargarIPH " + int.Parse(Session["ID_IPH"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                /*
                ID_PERSONA.Text = dr["ID_PERSONA"].ToString();
                
                txtAlias.Text = dr["ALIAS"].ToString();
                */

                ID_IPH.Text = dr["ID_IPH"].ToString();
                txtFolioIPH.Text = dr["FOLIO"].ToString();
                txtOficioIPH.Text = dr["NO_OFICIO"].ToString();
                txtFechaEventoIPH.Text = dr["FECHAEVENTO"].ToString();
                txtHoraEventoIPH.Text = dr["HORAEVENTO"].ToString();
                txtAsuntoDT_IPH.Text = dr["ASUNTO"].ToString();
                txtDirigidoDT_IPH.Text = dr["DIRIGIDOA"].ToString();
                txtFechaInformeIPH.Text = dr["FECHAINFORME"].ToString();
                ddlParticipacionDT_IPH.Text = dr["ID_PARTICIPACION"].ToString();
                rblOperativo_IPH.SelectedValue = dr["OPERATIVO"].ToString();
                txtNomComanDT_IPH.Text = dr["ID_COMANDANTE"].ToString();
                //FALTA AGREGAR CAMPO EN LA BD txtTipoEvenMot_IPH.Text = dr["TIPO_EVENTO_MOTIVO"].ToString();
                //CHECAR CARGA chblTipoInfoComple_IPH.SelectedValue.ToString = dr["INFO_COMPLE_EVENTO"].ToString();
                txtDescICE_IPH.Text = dr["INFO_COMPLE_EVENTO_DESC"].ToString();
                rblDictamenMeidocIPH.SelectedValue = dr["DICTAMEN_MEDICO"].ToString();
                txtFechaDictamenICE_IPH.Text = dr["FECHA_DICTAMEN_MEDICO"].ToString();
                txtObservaGeneraInfo_IPH.Text = dr["OBSERVACIONES_GENERALES_IPH"].ToString();
                imgBtnHuellaRegistroIPH.ID = dr["HUELLA"].ToString();

                


               

            }
            dr.Close();
        }




    }
}