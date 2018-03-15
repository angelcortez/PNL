using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace AtencionTemprana
{
    public partial class AudienciasSolicitadas : System.Web.UI.Page
    {
        Data PGJ = new Data();
        FileStream fs,fs1;
        protected void Page_Load(object sender, EventArgs e)
        {

          
            if (!Page.IsPostBack)
            {
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                Calendar1.EventDateColumnName = "FECHA";
                Calendar1.EventDescriptionColumnName = "DESCRIPCION";
                Calendar1.EventHeaderColumnName = "AUDIENCIA";
                Calendar1.EventSource = GetEvents();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                if (Request.QueryString["Id_Solicitud"] != null) {
                    gvNuc.DataSourceID = "dsSolicitudesAudiencias1";
                    gvNuc.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void gvNuc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            byte[] bits;
            try
            {
                if (e.CommandName == "Select")
                {
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridViewRow row = gvNuc.Rows[index];
                    String idSolicitud = row.Cells[0].Text;
                    PGJ.ConnectServer();
                    SqlCommand comm = new SqlCommand("SELECT * FROM TORRE.NSJP.STJ.Solicitud_Audiencia   WHERE Id_Solicitud = " + idSolicitud, Data.CnnCentral);
                    comm.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet("Binarios");
                    da.Fill(ds);

                    if (ds.Tables[0].Rows[0].ItemArray[17].ToString() == "")
                    {
                         bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[15]));
                    }
                    else
                    {
                         bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[17]));
                    }
                    //Vamos a guardar ese array de bytes como un fichero en el
                    //disco duro, un fichero temporal que después se podrá descartar.
                    string sFile = "tmp.pdf";
                    //Creamos un nuevo FileStream, que esta vez servirá para
                    //crear un fichero con el nombre especificado
                    fs = new FileStream(Server.MapPath(".") +
                    @"\DocTmp\" + sFile, FileMode.Create);
                    //Y escribimos en disco el array de bytes que conforman
                    //el fichero Word 
                    fs.Write(bits, 0, Convert.ToInt32(bits.Length));
                    fs.Close();
                    //Session["mi_ruta_pdf"] = "\\DocTmp\\tmp.pdf";
                    ///*tecleo mi dominio o IP*/
                    //String ruta_pdf = "http://10.8.19.17/NSJP_PDF/" + Session["mi_ruta_pdf"];
                    //ruta_pdf = ruta_pdf.Replace("\\", "/");
                    string script = "<script languaje='javascript'> ";
                    script += "mostrarFichero('DocTmp/tmp.pdf') ";
                    script += "</script>" + Environment.NewLine;
                    Page.RegisterStartupScript("mostrarFichero", script);
                   
                    //Response.Write("<script>");
                    //Response.Write("window.open('" + ruta_pdf + "','_blank')");
                    //Response.Write("</script>");
                    

                }
            }
            catch (Exception ex) {
                //Mensajes mje = new Mensajes();
                //mje.alert(ex.Message);
                string script = @"<script type='text/javascript'>
                            alert('NO EXISTE DOCUMENTO');
                                   </script>";
                //script = string.Format(script, ex.Message);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
             
            }
        }

        protected void btnNotificacion_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvNuc.Rows)
                {

                    String idSolicitud = row.Cells[0].Text;
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("chbNotificado");
                    if (cb.Checked == true)
                    {
                        SqlCommand Cmd = new SqlCommand("ActualizaNotificacion", Data.CnnCentral);
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.Add("@Id_Solicitud", SqlDbType.Int);
                        Cmd.Parameters["@Id_Solicitud"].Value = idSolicitud;
                        SqlDataReader DR = Cmd.ExecuteReader();
                        DR.Close();
                        string script = @"<script type='text/javascript'>
                            alert('Notificacion Registrada');
                                   </script>";
                        //script = string.Format(script, ex.Message);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        gvNuc.DataBind();
                    }

                }
            }
            catch (Exception es) {
                Label1.Text = es.Message;
            }
            //bool atLeastOneRowDeleted = false;
            //// Iterate through the Products.Rows property
            //foreach (GridViewRow row in gvNuc.Rows)
            //{
            //    // Access the CheckBox
            //    CheckBox cb = (CheckBox)row.FindControl("chbNotificado");
            //    if (cb != null && cb.Checked)
            //    {
                    
            //        //// Delete row! (Well, not really...)
            //        atLeastOneRowDeleted = true;
            //        btnNotificacion.Text = ":D";
            //        //// First, get the ProductID for the selected row
            //        //int productID =
            //        //    Convert.ToInt32(gvNuc.DataKeys[row.RowIndex].Value);
            //        //// "Delete" the row
            //        //DeleteResults.Text += string.Format(
            //        //    "This would have deleted ProductID {0}<br />", productID);
            //    }
            //}
            //// Show the Label if at least one row was deleted...
            ////DeleteResults.Visible = atLeastOneRowDeleted;
        }

        protected void gvNuc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == Request.QueryString["Id_Solicitud"])
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private DataTable GetEvents()
        {
            Data PGJ = new Data();
            PGJ.ConnectServer();

            DataTable dt = new DataTable();
            dt.Columns.Add("FECHA", Type.GetType("System.DateTime"));
            dt.Columns.Add("AUDIENCIA", Type.GetType("System.String"));
            dt.Columns.Add("DESCRIPCION", Type.GetType("System.String"));

            DataRow dr;
            DataSet s = new DataSet();
            PGJ.ConnectServer();
            SqlCommand cmd = new SqlCommand("ConsultaNotificaciones "+IdMunicipio.Text+","+IdUnidad.Text, Data.CnnCentral);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                dr = dt.NewRow();
                dr["FECHA"] = rd[0];
                dr["AUDIENCIA"] = rd[1] + "<br/>";
                dr["DESCRIPCION"] = rd[1];
                dt.Rows.Add(dr);
            }
            rd.Close();
            return dt;

            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
            SelectedDatesCollection theDates = Calendar1.SelectedDates;
           
            DataTable dtEvents = Calendar1.EventSource;
           
            DataTable dtSelectedDateEvents = dtEvents.Clone();
           DataRow dr;

            foreach (DataRow drEvent in dtEvents.Rows)
                foreach (DateTime selectedDate in theDates)
                    if ((Convert.ToDateTime(drEvent[Calendar1.EventDateColumnName])).ToShortDateString() == selectedDate.ToShortDateString())
                    {
                        Session.Add("a", selectedDate.ToShortDateString());
                        gvNuc.DataSourceID = "SqlDataSource1";
                        gvNuc.DataBind();
                        //dr = dtSelectedDateEvents.NewRow();
                        //dr[Calendar1.EventDateColumnName] = drEvent[Calendar1.EventDateColumnName];
                        //dr[Calendar1.EventHeaderColumnName] = drEvent[Calendar1.EventHeaderColumnName];
                        //dr[Calendar1.EventDescriptionColumnName] = drEvent[Calendar1.EventDescriptionColumnName];
                        //dtSelectedDateEvents.Rows.Add(dr);
                    }

            //gvSelectedDateEvents.DataSource = dtSelectedDateEvents;
            //gvSelectedDateEvents.DataBind();
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible == false) {
                Calendar1.Visible = true;
            }
            else if (Calendar1.Visible == true) {
                Calendar1.Visible = false;
                gvNuc.DataSourceID = "dsSolicitudesAudiencias";
                gvNuc.DataBind();
            }

        }

        protected void gvNuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
    }
