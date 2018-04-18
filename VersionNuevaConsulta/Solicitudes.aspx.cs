using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.IO;
namespace AtencionTemprana
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack)
            {
                Session["ID_SOLICITUD"] = Request.QueryString["ID_SOLICITUD"];
                Session["tab"] = Request.QueryString["tab"];
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
              //  lblNuc.Text = Session["NUC"].ToString();
                lblArbol.Text = Session["lblArbol"].ToString();
               
               
 
                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR SOLICITUD DE AUDIENCIA";
                    //consultaIdLugarHechos();
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();
                    SolicitarNUC();
                }
                //else if (Session["op"].ToString() == "Modificar")
                //{
                //    lblOperacion.Text = "MODIFICAR LUGAR DE LOS HECHOS";
                //    cmdDel.Enabled = true;
                //    cargarLugarHechos();
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
      void SolicitarNUC()
      {
          dcOrientacionDataContext dc = new dcOrientacionDataContext();
          var nuc = from c in dc.SolicitarNuc(int.Parse(IdCarpeta.Text))
                    select c;
          foreach (var propiedad in nuc)
          {
              lblNuc.Text = propiedad.NUC.ToString();
          }

      }
      protected void brnRegresar_Click(object sender, EventArgs e)
      {
          
      }

      protected void btnGuardar_Click(object sender, EventArgs e)
      {
          try
          {
              if (FileUpload1.HasFile)
              {
                  using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                  {
                      byte[] imagen = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                      Archivos.Guardar(int.Parse(IdCarpeta.Text),Session["IdUsuario"].ToString(), Session["IdMunicipio"].ToString(), Session["IdUnidad"].ToString(), ddlTipoSolicitud.SelectedValue, 
                                        ddlTipoAudiencia.SelectedValue,lblNuc.Text, imagen);
                  }
              }
              lblEstatus.Text = "SOLICITUD GUARDADA";
              PGJ.ConnectServer();
              SqlCommand cmd = new SqlCommand("SELECT MAX(Id_Solicitud) as Id_Solicitud FROM PGJ_Solicitud_Audiencia", Data.CnnCentral);
              SqlDataReader rd = cmd.ExecuteReader();
              if (rd.HasRows)
              {
                  rd.Read();
                  Response.Redirect("AudienciasSolicitadas.aspx?Id_Solicitud=" + rd["Id_Solicitud"].ToString());
                  rd.Close();
              }
          }
          catch (Exception ex)
          {
              lblEstatus.Text = ex.Message;
          }
      }

      protected void cmdReg_Click1(object sender, EventArgs e)
      {
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
      }
      
    }
}