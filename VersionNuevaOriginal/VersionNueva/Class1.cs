using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtencionTemprana
{
    public class Class1
    {

        //if (ddlFormatoBoletin.SelectedValue.ToString() == "1") //PDF
        //{

        //    if (ddlTipoBoletin.SelectedValue.ToString() == "2")
        //    {


        //        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Busqueda: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

        //        ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //        ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

        //        ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //        ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

        //        ReportViewer1.LocalReport.DataSources.Clear();
        //        ReportViewer1.LocalReport.DataSources.Add(rds);
        //        ReportViewer1.LocalReport.DataSources.Add(rds2);
        //        ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc";
        //        ReportViewer1.LocalReport.Refresh();

        //        CreatePDF(ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc");
        //        Label2.Text = "DATOS GUARDADOS";

        //    }

        //    if (ddlTipoBoletin.SelectedValue.ToString() == "3")
        //    {
        //        if (string.IsNullOrEmpty(txtNumero.Text))
        //        {
        //            lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
        //        }
        //        else
        //        {
        //            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
        //            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

        //            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

        //            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
        //            string leyenda = "";
        //            List<ReportParameter> parametros = new List<ReportParameter>();
        //            parametros.Add(new ReportParameter("numero", numero));
        //            parametros.Add(new ReportParameter("leyenda", leyenda));


        //            ReportViewer1.LocalReport.DataSources.Clear();
        //            ReportViewer1.LocalReport.DataSources.Add(rds);
        //            ReportViewer1.LocalReport.DataSources.Add(rds2);
        //            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
        //            ReportViewer1.LocalReport.SetParameters(parametros);
        //            ReportViewer1.LocalReport.Refresh();

        //            CreatePDFAmber(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
        //            Label2.Text = "DATOS GUARDADOS";
        //        }
        //    }


        //    if (ddlTipoBoletin.SelectedValue.ToString() == "4")
        //    {
        //        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Busqueda Localizado: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

        //        ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //        ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

        //        ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //        ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

        //        ReportViewer1.LocalReport.DataSources.Clear();
        //        ReportViewer1.LocalReport.DataSources.Add(rds);
        //        ReportViewer1.LocalReport.DataSources.Add(rds2);
        //        ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc";
        //        ReportViewer1.LocalReport.Refresh();

        //        CreatePDFLocalizado(ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc");
        //        Label2.Text = "DATOS GUARDADOS";
        //    }

        //    if (ddlTipoBoletin.SelectedValue.ToString() == "5")
        //    {
        //        if (string.IsNullOrEmpty(txtNumero.Text))
        //        {
        //            lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
        //        }
        //        else
        //        {
        //            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín PDF de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
        //            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

        //            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

        //            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
        //            string leyenda = "LOCALIZADO";
        //            List<ReportParameter> parametros = new List<ReportParameter>();
        //            parametros.Add(new ReportParameter("numero", numero));
        //            parametros.Add(new ReportParameter("leyenda", leyenda));


        //            ReportViewer1.LocalReport.DataSources.Clear();
        //            ReportViewer1.LocalReport.DataSources.Add(rds);
        //            ReportViewer1.LocalReport.DataSources.Add(rds2);
        //            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
        //            ReportViewer1.LocalReport.SetParameters(parametros);
        //            ReportViewer1.LocalReport.Refresh();

        //            CreatePDFAmberLocalizado(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
        //            Label2.Text = "DATOS GUARDADOS";
        //        }
        //    }




        //}//TERMINA PDF

        //if (ddlFormatoBoletin.SelectedValue.ToString() == "2") //IMAGEN
        //{

        //    if (ddlTipoBoletin.SelectedValue.ToString() == "2")
        //    {
        //        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Busqueda: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

        //        ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //        ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

        //        ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //        ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

        //        ReportViewer1.LocalReport.DataSources.Clear();
        //        ReportViewer1.LocalReport.DataSources.Add(rds);
        //        ReportViewer1.LocalReport.DataSources.Add(rds2);
        //        ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc";
        //        ReportViewer1.LocalReport.Refresh();

        //        CreatePDFImagen(ReportViewer1.LocalReport.ReportPath = "ReporteBoletin.rdlc");
        //        Label2.Text = "DATOS GUARDADOS";
        //    }

        //    if (ddlTipoBoletin.SelectedValue.ToString() == "3")
        //    {
        //        if (string.IsNullOrEmpty(txtNumero.Text))
        //        {
        //            lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
        //        }
        //        else
        //        {
        //            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
        //            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

        //            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

        //            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
        //            string leyenda = "";
        //            List<ReportParameter> parametros = new List<ReportParameter>();
        //            parametros.Add(new ReportParameter("numero", numero));
        //            parametros.Add(new ReportParameter("leyenda", leyenda));


        //            ReportViewer1.LocalReport.DataSources.Clear();
        //            ReportViewer1.LocalReport.DataSources.Add(rds);
        //            ReportViewer1.LocalReport.DataSources.Add(rds2);
        //            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
        //            ReportViewer1.LocalReport.SetParameters(parametros);
        //            ReportViewer1.LocalReport.Refresh();

        //            CreatePDFAmberImagen(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
        //            Label2.Text = "DATOS GUARDADOS";
        //        }
        //    }


        //    if (ddlTipoBoletin.SelectedValue.ToString() == "4")
        //    {
        //        PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Busqueda Localizado: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));

        //        ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //        ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource1);

        //        ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //        ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //        ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //        Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource2);

        //        ReportViewer1.LocalReport.DataSources.Clear();
        //        ReportViewer1.LocalReport.DataSources.Add(rds);
        //        ReportViewer1.LocalReport.DataSources.Add(rds2);
        //        ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc";
        //        ReportViewer1.LocalReport.Refresh();

        //        CreatePDFLocalizadoImagen(ReportViewer1.LocalReport.ReportPath = "ReporteBoletinLocalizado.rdlc");
        //        Label2.Text = "DATOS GUARDADOS";
        //    }

        //    if (ddlTipoBoletin.SelectedValue.ToString() == "5")
        //    {
        //        if (string.IsNullOrEmpty(txtNumero.Text))
        //        {
        //            lblError.Text = "INGRESE EL NÚMERO DE REPORTE.";
        //        }
        //        else
        //        {
        //            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 10, "Generación de Boletín IMAGEN de Alerta Amber: " + ddlOfendido.SelectedItem.ToString(), int.Parse(Session["IdModuloBitacora"].ToString()));
        //            ObjectDataSource ObjectDataSource1 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetTableAdapters.VER_FOTO_BOLETINTableAdapter", "GetData");
        //            ObjectDataSource1.SelectParameters.Add("ID", ddlFoto.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", ObjectDataSource1);

        //            ObjectDataSource ObjectDataSource2 = new ObjectDataSource("AtencionTemprana.PNL_NSJP2DataSetBOLETINTableAdapters.SP_BoletinTableAdapter", "GetData");
        //            ObjectDataSource2.SelectParameters.Add("idcarpeta", Session["ID_CARPETA"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("IdMunicipio", Session["IdMunicipio"].ToString());
        //            ObjectDataSource2.SelectParameters.Add("Idpersona", ddlOfendido.SelectedValue.ToString());
        //            Microsoft.Reporting.WebForms.ReportDataSource rds2 = new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ObjectDataSource2);

        //            string numero = HttpUtility.HtmlDecode(txtNumero.Text.ToUpper());
        //            string leyenda = "LOCALIZADO";
        //            List<ReportParameter> parametros = new List<ReportParameter>();
        //            parametros.Add(new ReportParameter("numero", numero));
        //            parametros.Add(new ReportParameter("leyenda", leyenda));


        //            ReportViewer1.LocalReport.DataSources.Clear();
        //            ReportViewer1.LocalReport.DataSources.Add(rds);
        //            ReportViewer1.LocalReport.DataSources.Add(rds2);
        //            ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc";
        //            ReportViewer1.LocalReport.SetParameters(parametros);
        //            ReportViewer1.LocalReport.Refresh();

        //            CreatePDFAmberLocalizadoImagen(ReportViewer1.LocalReport.ReportPath = "ReporteAmber.rdlc");
        //            Label2.Text = "DATOS GUARDADOS";
        //        }
        //    }
        //}//TERMINA IMAGEN

    }
}