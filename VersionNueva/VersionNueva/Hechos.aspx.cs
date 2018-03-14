using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class Hechos : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
                Response.Redirect("Default.aspx");
            if (!Page.IsPostBack)
            {
                Session["ID_HECHOS"] = Request.QueryString["ID_HECHOS"];
                
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                cargarFecha();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                lblArbol.Text = Session["lblArbol"].ToString();
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

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR HECHOS";
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    //consultaIdLugarHechos();
                }
                else if (Session["op"].ToString() == "Modificar")
                {
                    lblOperacion.Text = "MODIFICAR HECHOS";
                   // ID_HECHOS.Text = Session["ID_HECHOS"].ToString();
                    try
                    {
                        //El Policia Investigador no puede modificar
                        if (Session["ID_PUESTO"].ToString() == "16" || Session["ID_PUESTO"].ToString() == "8")
                        {
                            cmdGuardar.Visible = false;
                        }
                        cargarHechos();

                        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 5, "Consulto Hechos IdHechos=" + ID_HECHOS.Text + " IdCarpeta=" + Session["ID_CARPETA"], int.Parse(Session["IdModuloBitacora"].ToString()));
            
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Hechos.aspx?ID_HECHOS=" + Session["ID_HECHOS"].ToString() + "&op=Modificar");
                        // Datos.aspx?ID_PERSONA=' + CAST(CP.ID_PERSONA AS VARCHAR)  + '&op=Modificar'
                        //lblEstatus.Text = ex.Message;

                    }
                    
                }
            }
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try {
            if (Session["op"].ToString() == "Agregar")
            {
                PGJ.InsertaDescripcionHechos(int.Parse(IdCarpeta.Text), txtDes.Text, short.Parse(Session["IdMunicipio"].ToString()),PreguntasPNL.Text);
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Inserta Descripcion de Hechos IdCarpeta=" + IdCarpeta.Text + " Hechos: " + txtDes.Text, int.Parse(Session["IdModuloBitacora"].ToString()));

                try
                {
                    PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));


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
                        Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
                    }

                    else if (lblArbol.Text == "5")
                    {
                        Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString());
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

            else if (Session["op"].ToString() == "Modificar")
            {
                PGJ.ActualizaDescripcionHechos(int.Parse(ID_HECHOS.Text), txtDes.Text, PreguntasPNL.Text);
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualiza Descripcion de Hechos IdCarpeta=" + Session["ID_CARPETA"] + " Hechos: " + txtDes.Text, int.Parse(Session["IdModuloBitacora"].ToString()));
                
            }
            lblEstatus.Text = "DATOS GUARDADOS";
            cmdGuardar.Enabled = false;
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
                lblEstatus1.Text = "INTENTELO NUEVAMENTE";
            }
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            try {
                PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 2, "Click en Boton REGRESAR", int.Parse(Session["IdModuloBitacora"].ToString()));
            

             if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() );
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() );
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC_PNL.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString());
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() );
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

        void cargarHechos()
        {
            SqlCommand sql = new SqlCommand("cargarDesHechos " + int.Parse(Session["ID_HECHOS"].ToString()), Data.CnnCentral);
            SqlDataReader dr = sql.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ID_HECHOS.Text = dr["ID_HECHOS"].ToString();
                txtDes.Text = dr["DESCRIPCION"].ToString();
                PreguntasPNL.Text = dr["PREGUNTAS_PNL"].ToString();
            }
            dr.Close();
        }

        //void consultaIdLugarHechos()
        //{
        //    SqlCommand sql = new SqlCommand("consultaIdHechos", Data.CnnCentral);
        //    SqlDataReader dr = sql.ExecuteReader();
        //    //if (dr.HasRows)
        //    //{
        //    dr.Read();
        //    ID_HECHOS.Text = dr["ID_HECHOS"].ToString();
        //    //}
        //    dr.Close();
        //}


    }
}