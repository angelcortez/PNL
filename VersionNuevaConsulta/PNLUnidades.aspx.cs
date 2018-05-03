using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;

namespace AtencionTemprana
{
    public partial class PNLUnidades : System.Web.UI.Page
    {
        string unidad;
        string catalogo;
        string usuario;
        string password;

        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        public string Catalogo
        {
            get { return catalogo; }
            set { catalogo = value; }
        }        

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }        

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {

            GridUnidades.Visible = false;
            GridUnidades.Visible = true;
            GridUnidades.DataSourceID = "dsCargarUnidades";
            GridUnidades.DataBind();
        }

        protected void GridUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridUnidades.SelectedRow;

            int id = Convert.ToInt32(GridUnidades.DataKeys[row.RowIndex].Values["idUnidad"]);
            
            switch (id)
            {         
                case 73://TAMPICO                  
                    //var configuration = WebConfigurationManager.OpenWebConfiguration("~");
                    //var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
                    //section.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.167.20;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
                    //configuration.Save();

                    Session["UNIDAD"] = id.ToString();
                    Response.Redirect("Default.aspx");
                break;
                case 75:// MATAMOROS                                        
                    var configuration = WebConfigurationManager.OpenWebConfiguration("~");
                    var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
                    section.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
                    configuration.Save();
                    Response.Redirect("UnidadRAC.aspx");
                break;

                case 76:// NUEVOLAREDO
                    
                break;

                case 78:// REYNOSA
                   
                break;

                case 80:// VICTORIA
                    
                break;
            }
        }
    }
}