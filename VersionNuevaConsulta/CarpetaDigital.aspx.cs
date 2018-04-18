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
    public partial class CarpetaDigital : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

            
                Session["tab"] = Request.QueryString["tab"];
                Session["op"] = Request.QueryString["op"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();

                lblArbol.Text = Session["lblArbol"].ToString();
                PGJ.CargaCombo(ddlPlantilla, "CAT_PLANTILLAS", "ID_PLANTILLA", "NOMBRE_PLANTILLA");

               // ID_PLANTILLA.Text = Session["ID_PLANTILLA"].ToString();

                cargarFecha();

                if (Session["op"].ToString() == "Agregar")
                {
                    lblOperacion.Text = "AGREGAR CARPETA DIGITAL";
                    //consultaIdLugarHechos();
                    IdCarpeta.Text = Session["ID_CARPETA"].ToString();

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

       

        protected void cmdReg_Click1(object sender, EventArgs e)
        {
            if (lblArbol.Text == "2")
            {

                Response.Redirect("RAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_RAC=" + Session["ID_ESTADO_RAC"].ToString() + "&tab=0");
            }

            else if (lblArbol.Text == "3")
            {
                Response.Redirect("NUM.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUM=" + Session["ID_ESTADO_NUM"].ToString() + "&tab=0");
            }

            else if (lblArbol.Text == "4")
            {
                Response.Redirect("NUC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NUC=" + Session["ID_ESTADO_NUC"].ToString() + "&tab=0");
            }

            else if (lblArbol.Text == "5")
            {
                Response.Redirect("NAC.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString() + "&ID_ESTADO_NAC=" + Session["ID_ESTADO_NAC"].ToString() + "&tab=0");
            }
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
             if (FileUpload1.HasFile)
                {
                    using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                    {
                        byte[] Digital = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                      Archivos.InsertaCarpetaDigital(int.Parse(IdCarpeta.Text), Digital, short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()), short.Parse(ddlPlantilla.SelectedValue));
                    }
                }

                lblEstatus.Text = "DATOS GUARDADOS";
                cmdGuardar.Enabled = false;
                    
          
        }
    }
}