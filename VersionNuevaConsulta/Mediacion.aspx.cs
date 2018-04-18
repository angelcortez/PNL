using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;
//using Microsoft.Office.Core;
//using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Word;

namespace AtencionTemprana
{
    public partial class Mediacion : System.Web.UI.Page
    {

        Data PGJ = new Data();
        //FileStream fs;
        //Word.Application wordApp = new Word.Application();
        //private object filename;
        //private Word.Document Docuemnto;
        //object missing = Missing.Value;

        protected void Page_Load(object sender, EventArgs e)
        {
            PGJ.ConnectServer();
            //SqlCommand cmd = new SqlCommand("SELECT  GETDATE()  as FechaActual", Data.CnnCentral);
            //SqlDataReader rd = cmd.ExecuteReader();
            //if (rd.HasRows)
            //{
            //    rd.Read();
            //    lblFecha.Text = rd["FechaActual"].ToString();
            //    rd.Close();
            //}

            cargarFecha();
            LBLUSUARIO.Text = Session["Us"].ToString();
            IdMunicipio.Text = Session["IdMunicipio"].ToString();
            lblIdUnidad.Text = Session["IdUnidad"].ToString();

            UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
            PUESTO.Text = Session["PUESTO"].ToString();
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

        protected void ddlBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "0")
            {
                gvMediacion.DataSourceID = "dsConsultaSoliciudMediacion";
                gvMediacion.DataBind();
                gvMediacion.Visible = true;

                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = false;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;

                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "1")
            {
                txtRac.Visible = true;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = true;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "2")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = true;
                txtFechaFinRac.Visible = true;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = true;
                lblFechaFinRac.Visible = true;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "3")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                lblNUM.Visible = true;
                txtNUM.Visible = true;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }

            if (ddlBuscar.SelectedValue == "4")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = true;
                txtFechaInicioNum.Visible = true;
                lblFechaFinNum.Visible = true;
                txtFechaFinNum.Visible = true;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "5")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = true;
                txtNombre.Visible = true;
                lblPaterno.Visible = true;
                txtPaterno.Visible = true;
                lblMaterno.Visible = true;
                txtMaterno.Visible = true;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }
            if (ddlBuscar.SelectedValue == "6")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = false;
                txtNombreR.Visible = false;
                lblPaternoR.Visible = false;
                txtPaternoR.Visible = false;
                lblMaternoR.Visible = false;
                txtMaternoR.Visible = false;
                lblNuc.Visible = true;
                txtNuc.Visible = true;
            }
            if (ddlBuscar.SelectedValue == "7")
            {
                txtRac.Visible = false;
                txtFechaInicioRac.Visible = false;
                txtFechaFinRac.Visible = false;
                cmdAc.Visible = true;

                lblRac.Visible = false;
                lblFechaInicioRac.Visible = false;
                lblFechaFinRac.Visible = false;
                lblNUM.Visible = false;
                txtNUM.Visible = false;
                lblFechaInicioNum.Visible = false;
                txtFechaInicioNum.Visible = false;
                lblFechaFinNum.Visible = false;
                txtFechaFinNum.Visible = false;
                lblNombre.Visible = false;
                txtNombre.Visible = false;
                lblPaterno.Visible = false;
                txtPaterno.Visible = false;
                lblMaterno.Visible = false;
                txtMaterno.Visible = false;
                lblNombreR.Visible = true;
                txtNombreR.Visible = true;
                lblPaternoR.Visible = true;
                txtPaternoR.Visible = true;
                lblMaternoR.Visible = true;
                txtMaternoR.Visible = true;
                lblNuc.Visible = false;
                txtNuc.Visible = false;
            }

        }

        protected void cmdAc_Click(object sender, EventArgs e)
        {
            if (ddlBuscar.SelectedValue == "1")
            {
                gvMediacion.DataSourceID = "dsBuscarRAC";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "2")
            {
                gvMediacion.DataSourceID = "dsBuscarFechaInicioRAC";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "3")
            {
                gvMediacion.DataSourceID = "dsBuscarNUM";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "4")
            {
                gvMediacion.DataSourceID = "dsBuscarFechaInicioNUM";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "5")
            {
                gvMediacion.DataSourceID = "dsBuscarDenunciante";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "6")
            {
                gvMediacion.DataSourceID = "dsBuscarNuc";
                gvMediacion.DataBind();
            }
            else if (ddlBuscar.SelectedValue == "7")
            {
                gvMediacion.DataSourceID = "dsBuscarRequerido";
                gvMediacion.DataBind();
            }
        }


        //private void GuardarFicheroBDD(string sRuta, string sFichero)
        //{
        //    //Creamos un nuevo objeto de tipo FileStream para leer el fichero
        //    //Word en modo binario
        //    fs = new FileStream(sRuta + sFichero, System.IO.FileMode.Open);
        //    //Creamos un array de bytes para almacenar los datos leídos por fs.
        //    Byte[] data = new byte[fs.Length];
        //    //Y guardamos los datos en el array data
        //    fs.Read(data, 0, Convert.ToInt32(fs.Length));
        //    //Abrimos una conexion. En este caso los datos de la cadena de
        //    //conexion a la base de datos se recuperan de una sección del
        //    //fichero web.config mediante ConfigurationSettings
        //    PGJ.ConnectServer();
        //    SqlCommand cmd = new SqlCommand("UploadDoc", Data.CnnCentral);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //Añadimos los parametros esperados y los valores de los mismos
        //    cmd.Parameters.AddWithValue("@doc", data); //los datos del fichero Word
        //    cmd.Parameters.AddWithValue("@nombre", sFichero); //y su nombre
        //    //Ejecutamos el procedimiento almacenado, que inserta un nuevo
        //    //registro en DocsBinarios con los datos que queremos introducir
        //    cmd.ExecuteNonQuery();
        //    //Cerramos la conexión y el fichero
        //    fs.Close();
        //}
        //public void LeerDeBD(string docId)
        //{
        //    PGJ.ConnectServer();
        //    SqlCommand comm = new SqlCommand("SELECT * FROM DocsBinarios " + " WHERE docId = " + docId, Data.CnnCentral);
        //    comm.CommandType = CommandType.Text;
        //    SqlDataAdapter da = new SqlDataAdapter(comm);
        //    DataSet ds = new DataSet("Binarios");
        //    da.Fill(ds);
        //    //Creamos un array de bytes que contiene los bytes almacenados
        //    //en el campo Documento de la tabla
        //    byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[1]));
        //    //Vamos a guardar ese array de bytes como un fichero en el
        //    //disco duro, un fichero temporal que después se podrá descartar.
        //    string sFile = "tmp.docx";
        //    //Creamos un nuevo FileStream, que esta vez servirá para
        //    //crear un fichero con el nombre especificado
        //    fs = new FileStream(Server.MapPath(".") +
        //    @"\" + sFile, FileMode.Create);
        //    //Y escribimos en disco el array de bytes que conforman
        //    //el fichero Word <a
        //    fs.Write(bits, 0, Convert.ToInt32(bits.Length));
        //    if (File.Exists((string)fs.Name))
        //    {
        //        object readOnly = true;
        //        object isVisible = true;
        //        wordApp.Visible = true;
        //        Docuemnto = wordApp.Documents.Open(fs.Name, ref missing,
        //        ref readOnly, ref missing, ref missing, ref missing,
        //        ref missing, ref missing, ref missing, ref missing,
        //        ref missing, ref isVisible, ref missing, ref missing,
        //        ref missing, ref missing);
        //        Docuemnto.Activate();
        //    }
        //    fs.Close();
        //}

        //protected void btnSI_Click(object sender, EventArgs e)
        //{
        //    string solicitante = "SELECT (SELECT  CONVERT(VARCHAR,GETDATE(),103)) FECHA,(SELECT SUBSTRING(CONVERT(VARCHAR,GETDATE()),12,8)) HORA,P.NOMBRE+' '+P.PATERNO+' '+P.MATERNO +' \nFecha de Nacimiento: '+" +
        //            "CONVERT(VARCHAR,P.FECHA_NACIMIENTO,103) +' Edad: '+CONVERT(VARCHAR,P.EDAD)+' Sexo: '+S.SEXO+' Estado Civil: '+EC.ESTDO_CVL+" +
        //            "' \nDomicilio: Calle: '+C.CLLE+' Numero: '+PD.NUMERO+" +
        //            "' \nColonia/Fraccionamiento: '+COL.CLNIA+' Municipio: '+ M.MNCPIO  +" +
        //            "' \nTeléfono Particular: '+ isnull(MC.MEDIO_CONTACTO,' ') +' Tel. Oficina: '+isnull(MC1.MEDIO_CONTACTO,' ') +' Celular: '+isnull(MC2.MEDIO_CONTACTO,' ') + " +
        //            "' \nEscolaridad: '+ES.ESCLRDD+' Ocupación: '+O.OCPCION SOLICITANTE" +
        //            " FROM PGJ_CARPETA_PERSONA CP" +
        //            " INNER JOIN PGJ_CARPETA CA ON CA.ID_CARPETA = CP.ID_CARPETA" +
        //            " INNER JOIN PGJ_PERSONA P ON P.ID_PERSONA = CP.ID_PERSONA " +
        //            " INNER JOIN PGJ_PERSONA_DOMICILIO PD ON PD.ID_PERSONA = CP.ID_PERSONA AND PD.ID_DOMICILIO = CP.ID_DOMICILIO" +
        //            " LEFT OUTER JOIN PGJ_MEDIO_CONTACTO MC ON MC.ID_PERSONA = CP.ID_PERSONA AND MC.ID_TIPO_MEDIO_CONTACTO = 2 AND MC.ACTIVO = 1" +
        //            " LEFT OUTER JOIN PGJ_MEDIO_CONTACTO MC1 ON MC1.ID_PERSONA = CP.ID_PERSONA AND MC1.ID_TIPO_MEDIO_CONTACTO = 3 AND MC1.ACTIVO = 1" +
        //            " LEFT OUTER JOIN PGJ_MEDIO_CONTACTO MC2 ON MC2.ID_PERSONA = CP.ID_PERSONA AND MC2.ID_TIPO_MEDIO_CONTACTO = 1 AND MC2.ACTIVO = 1" +
        //            " INNER JOIN CAT_SEXO S ON S.ID_SEXO = P.ID_SEXO" +
        //            " INNER JOIN CAT_ESTADO_CIVIL EC ON EC.ID_ESTDO_CVL = CP.ID_ESTADO_CIVIL" +
        //            " INNER JOIN CAT_ESTADO E ON E.ID_ESTDO = PD.ID_ESTADO" +
        //            " INNER JOIN CAT_MUNICIPIO M ON M.ID_ESTDO = E.ID_ESTDO AND M.ID_MNCPIO = PD.ID_MUNICIPIO" +
        //            " INNER JOIN CAT_LOCALIDAD L ON L.ID_ESTDO = E.ID_ESTDO AND L.ID_MNCPIO = M.ID_MNCPIO AND L.ID_LCLDD = PD.ID_LOCALIDAD" +
        //            " INNER JOIN CAT_CALLE C ON C.ID_ESTDO = PD.ID_ESTADO AND C.ID_MNCPIO = PD.ID_MUNICIPIO AND C.ID_LCLDD = L.ID_LCLDD AND C.ID_CLLE = PD.ID_CALLE " +
        //            " INNER JOIN CAT_COLONIA COL ON COL.ID_ESTDO = PD.ID_ESTADO AND COL.ID_MNCPIO = PD.ID_MUNICIPIO AND COL.ID_LCLDD = PD.ID_LOCALIDAD" +
        //            " INNER JOIN CAT_ESCOLARIDAD ES ON ES.ID_ESCLRDD = CP.ID_ESCOLARIDAD" +
        //            " INNER JOIN CAT_OCUPACION O ON O.ID_OCPCION = CP.ID_OCUPACION" +
        //            " WHERE CA.ID_CARPETA = " + Session["ID_CARPETA"].ToString();

        //    string docId = "6";
        //    LeerDeBD(docId);
        //    if (Docuemnto.Bookmarks.Exists("solicitante"))
        //    {

        //        PGJ.ConnectServer();
        //        SqlCommand cmd = new SqlCommand(solicitante, Data.CnnCentral);
        //        SqlDataReader rd = cmd.ExecuteReader();
        //        if (rd.HasRows)
        //        {
        //            rd.Read();
        //            object oBookMark = "fecha";
        //            Docuemnto.Bookmarks.get_Item(ref oBookMark).Range.Text = rd["FECHA"].ToString();
        //            oBookMark = "hora";
        //            Docuemnto.Bookmarks.get_Item(ref oBookMark).Range.Text = rd["HORA"].ToString();
        //            oBookMark = "solicitante";
        //            Docuemnto.Bookmarks.get_Item(ref oBookMark).Range.Text = rd["SOLICITANTE"].ToString();
        //            rd.Close();
        //        }


        //    }

        //}

        //public void gvMediacion_RowCommand(object sender, GridViewCommandEventArgs ee)
        //{
        //    foreach (object row in gvMediacion.Rows) {
        //        Session["ID_CARPETA"] = ee.CommandArgument;
        //        Label5.Text = Session["ID_CARPETA"].ToString();
        //        Panel1_ModalPopupExtender.Show();
        //    }
        //}

        //protected void btnNO_Click(object sender, EventArgs e)
        //{
        //    string docId = "7";
        //    LeerDeBD(docId);
        //}

        protected void gvMediacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[10].Text == "INICIADA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[10].Text == "PROCESO")
                {
                    e.Row.ForeColor = System.Drawing.Color.Orange;
                }
                if (e.Row.Cells[10].Text == "SUSPENDIDA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
                if (e.Row.Cells[10].Text == "REMITIDA")
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }

            }
        }

        protected void cmdNum_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormaInicioNum.aspx");
        }
    }
}