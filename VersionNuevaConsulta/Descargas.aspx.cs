using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class Descargas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string script = "<script languaje='javascript'> ";
            script += "mostrarFichero('DocTmp/tmp.doc') ";
            script += "</script>" + Environment.NewLine;
            //Page.RegisterStartupScript("mostrarFichero", script);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GenerarDocs gd = new GenerarDocs();
            //gd.guardarDocumento();
            Response.Redirect("GenerarDocs.aspx");
        }
    }
}