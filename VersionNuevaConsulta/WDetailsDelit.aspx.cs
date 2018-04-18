using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class WDetailsDelit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                IdUnidad.Text = Session["IdUnidad"].ToString();
                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                FF.Text = Request.QueryString["FF"];
                FI.Text = Request.QueryString["FI"];

                gvEstados.Visible = true;
                gvEstados.DataSourceID = "ObjectTabla";
                gvEstados.DataBind();
            }

        }
    }
}