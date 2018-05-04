using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Reflection;

namespace AtencionTemprana
{
    public partial class PNLUnidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration("C:/Users/A/Documents/GitHub/PNL/VersionNuevaConsulta - copia/OutApp.config");
            //////var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //System.Configuration.ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings("PGJ_NSJPConnectionString2", "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218"));
            //////connectionStringsSection.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.ConnectionStrings.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");

            
            try
            {
                var settings = ConfigurationManager.ConnectionStrings[0];
                if (!settings.Equals(null))
                {
                    var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    fi.SetValue(settings, false);
                    settings.ConnectionString = "Data Source=172.23.8.22;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
                }
            }catch(Exception ex)
            {
                Label12.Text =  ex.Message.ToString();
            }           

            Response.Redirect("Default.aspx?unidad=victoria");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration("C:/Users/A/Documents/GitHub/PNL/VersionNuevaConsulta - copia/OutApp.config");
            //////var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //System.Configuration.ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings("PGJ_NSJPConnectionString2", "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218"));
            //////connectionStringsSection.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.ConnectionStrings.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");

            try
            {
                var settings = ConfigurationManager.ConnectionStrings[0];
                if (!settings.Equals(null))
                {
                    var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    fi.SetValue(settings, false);
                    settings.ConnectionString = "Data Source=10.8.167.20;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
                }
            }catch (Exception ex)
            {
                Label12.Text = ex.Message.ToString();
            }

            Response.Redirect("Default.aspx?unidad=tampico");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration("C:/Users/A/Documents/GitHub/PNL/VersionNuevaConsulta - copia/OutApp.config");
            //////var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //System.Configuration.ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings("PGJ_NSJPConnectionString2", "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218"));
            //////connectionStringsSection.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.ConnectionStrings.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");

            try
            {
                var settings = ConfigurationManager.ConnectionStrings[0];
                if (!settings.Equals(null))
                {
                    var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    fi.SetValue(settings, false);
                    settings.ConnectionString = "Data Source=10.8.42.14;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
                }
            }catch(Exception ex)
            {
                Label12.Text = ex.Message.ToString();
            }
            Response.Redirect("Default.aspx?unidad=reynosa");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration("C:/Users/A/Documents/GitHub/PNL/VersionNuevaConsulta - copia/OutApp.config");
            //////var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //System.Configuration.ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings("PGJ_NSJPConnectionString2", "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218"));
            //////connectionStringsSection.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.ConnectionStrings.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");

            try
            {
                var settings = ConfigurationManager.ConnectionStrings[0];
                if (!settings.Equals(null))
                {
                    var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    fi.SetValue(settings, false);
                    settings.ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
                }
            }catch(Exception ex)
            {
                Label12.Text = ex.Message.ToString();
            }
            Response.Redirect("Default.aspx?unidad=matamoros");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            //var config = ConfigurationManager.OpenExeConfiguration("C:/Users/A/Documents/GitHub/PNL/VersionNuevaConsulta - copia/OutApp.config");
            //////var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            //System.Configuration.ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings("PGJ_NSJPConnectionString2", "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218"));
            //////connectionStringsSection.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.ConnectionStrings.ConnectionStrings["PGJ_NSJPConnectionString2"].ConnectionString = "Data Source=10.8.32.21;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
            //config.Save();
            //ConfigurationManager.RefreshSection("connectionStrings");

            try
            {
                var settings = ConfigurationManager.ConnectionStrings[0];
                if (!settings.Equals(null))
                {
                    var fi = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    fi.SetValue(settings, false);
                    settings.ConnectionString = "Data Source=10.8.77.22;Initial Catalog=PNL_NSJP;User ID=JESUS;Password=PNL_JG0218";
                }
            }catch(Exception ex)
            {
                Label12.Text = ex.Message.ToString();
            }

            Response.Redirect("Default.aspx?unidad=laredo");
        }
    }
}