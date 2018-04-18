using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Turno : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Session["turno_id"] = Request.QueryString["turno_id"];
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                cargarFecha();
                lblTurnoOrientacion.Visible = false;
                lblTurnoAtencion.Visible = false;
                Session["turno_id"] = turno_id.Text;

                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                
                lblUnidadTurno.Text = "2";

            }

        }

        protected void cmdGenerarTurno_Click(object sender, EventArgs e)
        {
            if (rb.SelectedValue.ToString() == "2") //ORIENTACION
            {
                cargarMaxIdOrientacion();
                lblTurnoOrientacion.Visible = false;
                lblTurnoAtencion.Visible = false;
                lblTurnoOficialiaPartes.Visible = false;
                lblTurnoCentroMediacion.Visible = false;

                //dcOrientacionDataContext dc = new dcOrientacionDataContext();
                //dc.agregarTurno(int.Parse(lblTurnoOrientacion.Text), rb.SelectedValue.ToString(), txtNombre.Text, txtPaterno.Text, txtMaterno.Text);

                PGJ.InsertaTurnoPersona(int.Parse(lblTurnoOrientacion.Text), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, short.Parse(rb.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()));
 
             ReportViewer1.LocalReport.Refresh();

             
          
            }

            else if (rb.SelectedValue.ToString() == "4") //ATENCION A LA COMUNIDAD
            {
                cargarMaxIdAtencion();
                lblTurnoOrientacion.Visible = false;
                lblTurnoAtencion.Visible = false;
                lblTurnoOficialiaPartes.Visible = false;
                lblTurnoCentroMediacion.Visible = false;

                //dcOrientacionDataContext dc = new dcOrientacionDataContext();
                //dc.agregarTurno(int.Parse(lblTurnoAtencion.Text), rb.SelectedValue.ToString(), txtNombre.Text, txtPaterno.Text, txtMaterno.Text);

                PGJ.InsertaTurnoPersona(int.Parse(lblTurnoAtencion.Text), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, short.Parse(rb.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()));
 
                ReportViewer1.LocalReport.Refresh();

                

            }

            else if (rb.SelectedValue.ToString() == "5") //OFICIALIA
            {
                cargarMaxIdOficialia();
                lblTurnoOrientacion.Visible = false;
                lblTurnoAtencion.Visible = false;
                lblTurnoOficialiaPartes.Visible = false;
                lblTurnoCentroMediacion.Visible = false;

                //dcOrientacionDataContext dc = new dcOrientacionDataContext();
                //dc.agregarTurno(int.Parse(lblTurnoOficialiaPartes.Text), rb.SelectedValue.ToString(), txtNombre.Text, txtPaterno.Text, txtMaterno.Text);

                PGJ.InsertaTurnoPersona(int.Parse(lblTurnoOficialiaPartes.Text), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, short.Parse(rb.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()));

                ReportViewer1.LocalReport.Refresh();

              

            }
            else if (rb.SelectedValue.ToString() == "3") //MEDIACION 
            {
                cargarMaxIdMediacion();
                lblTurnoOrientacion.Visible = false;
                lblTurnoAtencion.Visible = false;
                lblTurnoOficialiaPartes.Visible = false;
                lblTurnoCentroMediacion.Visible = false;

                //dcOrientacionDataContext dc = new dcOrientacionDataContext();
                //dc.agregarTurno(int.Parse(lblTurnoCentroMediacion.Text), rb.SelectedValue.ToString(), txtNombre.Text, txtPaterno.Text, txtMaterno.Text);

                PGJ.InsertaTurnoPersona(int.Parse(lblTurnoCentroMediacion.Text), txtNombre.Text, txtPaterno.Text, txtMaterno.Text, short.Parse(rb.SelectedValue.ToString()), short.Parse(Session["IdUsuario"].ToString()));

                ReportViewer1.LocalReport.Refresh();

               

            }

            limpiarText();

          
             //Response.Redirect("ImprimirTurno.aspx?turno_id=" + turno_id.Text);
            gvOrientacion.DataBind();
        }

        void cargarMaxIdOrientacion()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var cMax = from c in dc.TurnoMaxOrientacion ()
                       select c;
            foreach (var propiedad in cMax)
            {
                lblTurnoOrientacion.Text = propiedad.TURNO.ToString();
                turno_id.Text = propiedad.ID_TURNO.ToString();
            }

        }

        void cargarMaxIdAtencion()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var cMax = from c in dc.TurnoMaxAtencion ()
                       select c;
            foreach (var propiedad in cMax)
            {
                lblTurnoAtencion.Text = propiedad.TURNO.ToString();
                turno_id.Text = propiedad.ID_TURNO.ToString();
            }

        }

        void cargarMaxIdMediacion()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var cMax = from c in dc.TurnoMaxMediacion()
                       select c;
            foreach (var propiedad in cMax)
            {
                lblTurnoCentroMediacion.Text = propiedad.TURNO.ToString();
                turno_id.Text = propiedad.ID_TURNO.ToString();
            }

        }

        void cargarMaxIdOficialia()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var cMax = from c in dc.TurnoMaxOficialia()
                       select c;
            foreach (var propiedad in cMax)
            {
                lblTurnoOficialiaPartes.Text = propiedad.TURNO.ToString();
                turno_id.Text = propiedad.ID_TURNO.ToString();
            }

        }

        void cargarFecha()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var fecha = from c in dc.fechaServidor ()
                        select c;
            foreach (var propiedad in fecha)
            {
                lblFecha.Text = propiedad.FechaActual.ToString();
            }

        }

        void limpiarText()
        {
            txtNombre.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
        }

        protected void rb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUnidadTurno.Text = rb.SelectedValue.ToString();
            gvOrientacion.DataBind();
        }

    }
}