using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace AtencionTemprana
{
    public partial class Agenda : System.Web.UI.Page
    {
          Data PGJ = new Data();
        private Hashtable datosAudiencia;

        protected void Page_Load(object sender, EventArgs e)
        {
            datosAudiencia = GetAudiencia();

            //Label1.Text = DateTime.Now.; 
        }
        private Hashtable GetAudiencia()
        {
           
            Hashtable audiencia = new Hashtable();
            DataSet s = new DataSet(); 
            PGJ.ConnectServer();
            SqlCommand cmd = new SqlCommand("ConsultaNotificaciones ", Data.CnnCentral);
            SqlDataReader rd = cmd.ExecuteReader();
            //if (rd.HasRows)
            //{
            //    rd.Read();
            //    audiencia.Add(rd["FechaHoraAudiencia"], rd["TipoAudiencia"]);
            //    rd.Close();
            //}

            while (rd.Read())
            {
                audiencia.Add(rd[0], rd[1]);
            }

            //audiencia["28/06/2014"] = "AUDIENCIA :D";

            return audiencia;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (datosAudiencia[e.Day.Date.ToShortDateString()] != null)
            {
                Literal lit = new Literal();
                lit.Text = "<br/>";
                e.Cell.Controls.Add(lit);

                Label lbl = new Label();
                lbl.Text = (string)datosAudiencia[e.Day.Date];
                lbl.Font.Size = new FontUnit(FontSize.Small);
                lbl.ForeColor = System.Drawing.Color.Blue;
                e.Cell.Controls.Add(lbl);

            }
        }
    }
}