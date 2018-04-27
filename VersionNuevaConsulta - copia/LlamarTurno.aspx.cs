using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AtencionTemprana
{
    public partial class LlamarTurno : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            cmdAtender.Enabled = false;
            
            cmdTurno.Enabled = true;
            //validaTurno();
            //maxIdOrientacion();
            cargarFecha();
            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            LBLUSUARIO.Text = Session["Us"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();

            IdUnidad.Text = Session["IdUnidad"].ToString();

            Session["Nombre"] = lblNombre.Text;
            Session["Paterno"] = lblPaterno.Text;
            Session["Materno"] = lblMaterno.Text;


        }

        protected void cmdAtender_Click(object sender, EventArgs e)
        {
            //SqlCommand sqlTurno = new SqlCommand("update PGJ_TURNO_PERSONA set FECHA_ATENDIDO=GETDATE()" + " where ID_TURNO=" + IdTurno.Text, Data.CnnCentral);
            //SqlDataReader rdC = sqlTurno.ExecuteReader();
            //rdC.Close();
                
            Response.Redirect("FormaInicio.aspx");
        }

        protected void cmdTurno_Click(object sender, EventArgs e)
        {
           
            llamarTurno();
            cmdAtender.Enabled = true;
            cmdTurno.Enabled = false;

            PGJ.InsertaTurnoPantalla(int.Parse(lblOrientacion.Text), lblNombre.Text + " " + lblPaterno.Text + " " + lblMaterno.Text, "ORIENTACION Y DENUNCIA");

           if(lblOrientacion.Text=="")
           {
               lblMess.Text = "NO HAY TURNOS POR ATENDER";
               cmdAtender.Enabled = false;
               cmdTurno.Enabled = false;
           }
                

        }


        void llamarTurno()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var turno = from c in dc.llamarTurno(short.Parse(IdUnidad.Text))
                       select c;
            foreach (var propiedad in turno)
            {
                lblOrientacion.Text = propiedad.NUMERO_TURNO.ToString();
                IdTurno.Text = propiedad.ID_TURNO.ToString();
                lblNombre.Text = propiedad.NOMBRE.ToString();
                lblPaterno.Text = propiedad.PATERNO.ToString();
                lblMaterno.Text = propiedad.MATERNO.ToString();
            }

        }

        //void maxIdOrientacion()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var cMax = from c in dc.TurnoMaxOrientacion()
        //               select c;
        //    foreach (var propiedad in cMax)
        //    {
        //        lblIdMaxOrientacion.Text = propiedad.TURNO.ToString();
        //       // turno_id.Text = propiedad.ID_TURNO.ToString();
        //    }

        //}

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


        //void validaTurno()
        //{
        //    dcOrientacionDataContext dc = new dcOrientacionDataContext();
        //    var valida = from c in dc.ValidaTurnoOrientacio()
        //                 select c;
        //    foreach (var propiedad in valida)
        //    {
        //        lblIdMaxOrientacion.Text = propiedad.turno.ToString();
        //    }
        //}

       

        protected void cmdCancelar_Click(object sender, EventArgs e)
        {
            cmdTurno.Enabled = true;
            cmdAtender.Enabled = false;
            


        }
    }
}