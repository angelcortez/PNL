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
using System.Configuration;

namespace AtencionTemprana
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ipAddress = string.Empty;
            if (!string.IsNullOrEmpty(Request.ServerVariables[""]))
            {
                ipAddress = Request.ServerVariables["HTTP_X_FORWARED_FOR"];
            }
            else
            {

                ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            IP_MAQUINA.Text = ipAddress;
        }

        protected void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Data PGJ = new Data();
                Data.ip = "10.8.32.21";
                PGJ.ConnectServer();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = Data.CnnCentral;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Cargar_Usuario_Login";

                SqlParameter p1 = new SqlParameter("USUARIO", txtUsuario.Text);
                SqlParameter p2 = new SqlParameter("PASSWORD", txtPass.Text);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                SqlDataReader rd = cmd.ExecuteReader();

                //SqlCommand cmd = new SqlCommand("sp_Cargar_Usuario_Login " + txtUsuario.Text + "," + txtPass.Text, Data.CnnCentral);
                //SqlDataReader rd = cmd.ExecuteReader();

                //Data PGJ = new Data();
                //PGJ.ConnectServer();

                //SqlCommand cmd = new SqlCommand("sp_Cargar_Usuario_Login " + txtUsuario.Text + "," + txtPass.Text, Data.CnnCentral);
                //SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();
                    Session["IdUsuarioRemitir"] = 0;
                    Session["SIGLA"] = rd["SIGLA"].ToString();
                    Session["IdUsuario"] = rd["id_usuario"].ToString();
                    Session["IdUnidad"] = rd["Id_Undd"].ToString();
                    Session["IdMunicipio"] = rd["ID_MNCPIO"].ToString();
                    Data.IdMunicipio = short.Parse(rd["ID_MNCPIO"].ToString());
                    Session["IdModulo"] = rd["ID_MODULO"].ToString();
                    Session["UNDD_DSCRPCION"] = rd["UNDD_DSCRPCION"].ToString();
                    Session["PUESTO"] = rd["PUESTO"].ToString();
                    Session["ID_PUESTO"] = rd["ID_PUESTO"].ToString();
                    Session["USUARIO"] = rd["USUARIO"].ToString();
                    Session["IP_MAQUINA"] = IP_MAQUINA.Text.ToString();
                    Session["IdModuloBitacora"] = "4";
                    Session["CNTRSNA_DEFAULT"] = rd["CNTRSNA_DEFAULT"].ToString();
                    Session.Timeout = 300;

                    Session["Us"] = rd["NMBRE"].ToString() + " " + rd["PTRNO"].ToString() + " " + rd["MTRNO"].ToString();
                    if (Session["IdUsuario"].ToString() == "4")
                    {
                        Response.Redirect("Plantillas.aspx");
                    }

                    rd.Dispose();

                    if (Session["CNTRSNA_DEFAULT"].ToString() == "True")
                    {
                        //PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()),"", IP_MAQUINA.Text,"", 1, "REALIZANDO SU CAMBIO DE CONTRASEÑA");
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Cambio de Contraseña", 0);

                        Response.Redirect("SP_Cambio_Contra.aspx");

                    }
                    if (Session["IdModulo"].ToString() == "1")
                    {
                        Response.Redirect("PruebaPantallas.aspx");
                    }
                    else if (Session["IdModulo"].ToString() == "2")
                    {
                        Response.Redirect("ConsultaRAC.aspx");
                    }
                    else if (Session["IdModulo"].ToString() == "3")
                    {

                        Response.Redirect("Mediacion.aspx");
                    }
                    else if (Session["IdModulo"].ToString() == "4")
                    {

                        Response.Redirect("AgenciaInvestigacion.aspx");
                    }
                    else if (Session["IdModulo"].ToString() == "5")
                    {

                        Response.Redirect("ConsultaAtencionComunidad.aspx");
                    }
                    else if (Session["IdModulo"].ToString() == "6")
                    {

                        Response.Redirect("Administrar.aspx");
                    }
                    else if (Session["IdModulo"].ToString() == "7")
                    {

                        Response.Redirect("WebEstadistica.aspx");
                    }
                    else if (Session["IdModulo"].ToString() == "8")
                    {

                        if (Session["ID_PUESTO"].ToString() == "8")
                        {

                            Response.Redirect("PoliciaInvestigador.aspx");
                        }

                        else if (Session["ID_PUESTO"].ToString() == "16")
                        {

                            Response.Redirect("CoordPoliciaInvestigador.aspx");
                        }
                    }
                    else if (Session["IdModulo"].ToString() == "9")
                    {
                        txtUsuario.Text = Session["IdModulo"].ToString();


                        if (Session["ID_PUESTO"].ToString() == "22")
                        {
                            txtUsuario.Text = Session["ID_PUESTO"].ToString();
                            Response.Redirect("Periciales.aspx");
                        }

                        else if (Session["ID_PUESTO"].ToString() == "21")
                        {
                            txtUsuario.Text = Session["ID_PUESTO"].ToString();
                            Response.Redirect("DireccionServiciosPericiales.aspx");
                        }
                    }
                    else if (Session["IdModulo"].ToString() == "10")
                    {

                        Response.Redirect("AcuerdosReparatorios.aspx");
                    }

                    else if (Session["IdModulo"].ToString() == "11")
                    {

                        Response.Redirect("UnidadSecuerstros.aspx");
                    }

                    else if (Session["IdModulo"].ToString() == "12")
                    {
                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 1, "Inicio de Sesion", int.Parse(Session["IdModuloBitacora"].ToString()));
                        //Response.Redirect("UnidadPNL.aspx");
                        Response.Redirect("PNLUnidades.aspx");                                                          
                    }
                }

                else
                {
                    lblError.Text = "USUARIO O CONTRASEÑA  INVÁLIDO";
                }
                //rd.Close();
                rd.Dispose();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}