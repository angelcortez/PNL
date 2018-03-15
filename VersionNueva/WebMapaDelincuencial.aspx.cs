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
using Subgurim.Controles;

namespace AtencionTemprana
{
    public partial class WebMapaDelincuencial : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GMap1.Add(new GMapUI());
                PGJ.ConnectServer();
                PGJ.CargaCombo(ddlDelito, "CAT_DELITO", "ID_DLTO", "DLTO");
                GMapUIOptions options = new GMapUIOptions();
                options.maptypes_hybrid = false;
                options.keyboard = false;
                options.maptypes_physical = false;
                options.zoom_scrollwheel = false;

                GMap1.Add(new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl, new GControlPosition(GControlPosition.position.Top_Right)));
                GMap1.setCenter(new GLatLng(23.736819471992295, -99.14335536956787), 13);
                GMap1.enableGKeyboardHandler = true;
            }

        }

        protected void cmdMapa_Click(object sender, EventArgs e)
        {
            
           // GMap1.resetMarkers();
            //string fulladdress = string.Format("{0}.{1}.{2}.{3}", ddlCalle.SelectedItem.Text, ddlMunicipio.SelectedItem.Text, "TAMAULIPAS", "MEXICO");
            ////string skey = ConfigurationManager.AppSettings["googlemaps.subgurim.net"];
            //GeoCode geocode;
            //geocode = GMap1.getGeoCodeRequest(fulladdress);
            //var glatlng = new Subgurim.Controles.GLatLng(geocode.Placemark.coordinates.lat, geocode.Placemark.coordinates.lng);
            //GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
            //var oMarker = new Subgurim.Controles.GMarker(glatlng);
            //GMap1.Add(oMarker);

           // SqlDataAdapter daHechos = new SqlDataAdapter("select ID_CARPETA, LATITUD, LONGITUD from PGJ_LUGAR_HECHOS where year(FECHA_HECHOS)=2014", Data.CnnCentral);
            SqlDataAdapter daHechos = new SqlDataAdapter("select p.ID_CARPETA,SUBSTRING(pc.NUC,11,10) as NUC,SUBSTRING(pc.RAC,11,10) AS RAC,cu.UNDD_DSCRPCION, p.LATITUD as LATITUD, p.LONGITUD as LONGITUD from PGJ_LUGAR_HECHOS p inner join PGJ_DELITOS pd on pd.ID_LUGAR_HECHOS=p.ID_LUGAR_HECHOS INNER JOIN PGJ_CARPETA pc on pc.ID_CARPETA=p.ID_CARPETA INNER JOIN CAT_UNIDAD cu on cu.ID_UNDD=SUBSTRING(pc.rac,7,3) or cu.ID_UNDD=SUBSTRING(pc.nuc,7,3) where year(FECHA_HECHOS)=" + txtAño.Text + "and pd.id_delito=" + short.Parse(ddlDelito.SelectedValue.ToString()), Data.CnnCentral);
            
            DataSet dsHechos = new DataSet();
            daHechos.Fill(dsHechos, "Hechos");
            foreach (DataRow drHechos in dsHechos.Tables["Hechos"].Rows)
            {
                if ((drHechos["LATITUD"].ToString() != "") && (drHechos["LONGITUD"].ToString() != "") && (drHechos["ID_CARPETA"].ToString() != ""))
                {
                    double Longitud;
                    Longitud = double.Parse(drHechos["LONGITUD"].ToString());

                    if (Longitud > 0)
                    {
                        Longitud = Longitud * -1;
                    }
              

                    ////var glatlng = new Subgurim.Controles.GLatLng(Convert.ToDouble(drHechos["LATITUD"].ToString()), Convert.ToDouble(drHechos["LONGITUD"].ToString()));
                    //var glatlng = new Subgurim.Controles.GLatLng(double.Parse(drHechos["LATITUD"].ToString()), double.Parse(drHechos["LONGITUD"].ToString()));
                    var glatlng = new Subgurim.Controles.GLatLng(double.Parse(drHechos["LATITUD"].ToString()), Longitud);
                    GMap1.setCenter(glatlng, 16, Subgurim.Controles.GMapType.GTypes.Normal);
                    var oMarker = new Subgurim.Controles.GMarker(glatlng);

                  
                   //  GInfoWindow window = new GInfoWindow(oMarker, drHechos["ID_CARPETA"].ToString(), false, GListener.Event.mouseover);
                    GInfoWindow window = new GInfoWindow(oMarker,  ("NUC=( " + drHechos["NUC"].ToString() + " )") + " ," + ("RAC=(" + drHechos["RAC"].ToString() + " )") + " " + (drHechos["UNDD_DSCRPCION"].ToString()), false, GListener.Event.mouseover);

                    GMap1.Add(window);

                    //GInfoWindowOptions options = new GInfoWindowOptions("Max Title", "Max Content");
                    //GInfoWindow window2 = new GInfoWindow(oMarker, ("NUC=( " + drHechos["NUC"].ToString() + " )") + " ," + ("RAC=(" + drHechos["RAC"].ToString() + " )") + " " + (drHechos["UNDD_DSCRPCION"].ToString()), options);
                   // GMap1.Add(window2);

                    GMap1.Add(oMarker);

              
                }
            }
            daHechos.Dispose();
            dsHechos.Dispose();
            GMap1.setCenter(new GLatLng(23.736819471992295, -99.14335536956787), 13);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GMap1.reset();

            GMap1.Add(new GMapUI());

            GMapUIOptions options = new GMapUIOptions();
            options.maptypes_hybrid = false;
            options.keyboard = false;
            options.maptypes_physical = false;
            options.zoom_scrollwheel = false;

            GMap1.Add(new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl, new GControlPosition(GControlPosition.position.Top_Right)));
            GMap1.setCenter(new GLatLng(23.736819471992295, -99.14335536956787), 13);
            GMap1.enableGKeyboardHandler = true;
        }

    }
}