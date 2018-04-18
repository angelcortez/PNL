using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;

namespace AtencionTemprana
{
    public partial class ObjetosAseguradosPI : System.Web.UI.Page
    {

        Data PGJ = new Data();
        FileStream fs;
        private Word.Document Documento;
        object missing = Missing.Value;
        string textoMarcador;
        object FileName = "tmpMarcadores.docx";

        //int banInsertar;

        //Variables para los componentes de los objetos
        int numObj ;
        int numVeh ;


        /*
        //Objetos
       static TextBox[] txtCantidad;
       static TextBox[] txtObjeto;
       static TextBox[] txtDescripcion;
       static Label[] lblCantidad;
       static Label[] lblObjeto;
       static Label[] lblDescripcion;

        //Variables para los componentes de los Vehiculos

       static Label[] lblLinea;
       static Label[] lblMarca;
       static Label[] lblModelo;
       static Label[] lblColor;
       static Label[] lblPlaca;
       static Label[] lblEstado;
       static Label[] lblTipo;
       static Label[] lblNumSerie;
       static Label[] lblPropietario;

       static TextBox[] txtLinea;
       static TextBox[] txtMarca;
       static TextBox[] txtModelo;
       static TextBox[] txtColor;
       static TextBox[] txtPlaca;
       static TextBox[] txtEstado;
       static TextBox[] txtTipo;
       static TextBox[] txtNumSerie;
       static  TextBox[] txtPropietario;



        //TextBox[] arregloTextBoxsCantidad;
        //TextBox[] arregloTextBoxsDescripcion;
       //static int contadorControles;
        */

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack){


                //lblEstatus.Text = "";
                //arregloTextBoxsCantidad = new TextBox[20];
                //arregloTextBoxsDescripcion = new TextBox[20];
                //contadorControles = 0;

                txtEspecificarObj.Visible = false;
                txtEspecificarVeh.Visible = false;
                lblEspecificar1.Visible = false;
                lblEspecificar2.Visible = false;


                Label332.Visible = false;
                FileUpload1.Visible = false;
                cmdGuardar.Visible = false;

                IdMunicipio.Text = Session["IdMunicipio"].ToString();
                IdUnidad.Text = Session["IdUnidad"].ToString();
                PUESTO.Text = Session["PUESTO"].ToString();
                LBLUSUARIO.Text = Session["Us"].ToString();
                cargarFecha();
                UNDD.Text = Session["UNDD_DSCRPCION"].ToString();
                IdUsuario.Text = Session["IdUsuario"].ToString();
                IdCarpeta.Text = Session["ID_CARPETA"].ToString();
               
                IdOrden.Text = Session["ID_ORDEN"].ToString();


                Data PGJ = new Data();
                PGJ.CargaCombo(ddlCausaObj, "CAT_CAUSA_ASEGURAMIENTO_PI", "ID_CAUSA", "NOMBRE");
                PGJ.CargaCombo(ddlCausaVeh, "CAT_CAUSA_ASEGURAMIENTO_PI", "ID_CAUSA", "NOMBRE");

                PGJ.CargaCombo(ddlMarca, "CAT_MARCA", "id_marca", "marca");
                PGJ.CargaCombo(ddlModelo, "CAT_MODELO", "IdModelo", "Modelo");
                PGJ.CargaCombo(ddlColor, "CAT_VEHICULO_COLOR", "ID_CLR", "CLR");
                PGJ.CargaCombo(ddlProcedencia, "CAT_PROCEDENCIA", "IdProcedencia", "Procedencia");
                PGJ.CargaCombo(ddlTipoVehiculo, "CAT_TIPO_VEHICULO", "id_tipo_veh", "tipo_vehiculo");
                PGJ.CargaCombo(ddlDisposicion, "CAT_PUSO_DISPOSICION", "ID_PUSO_DISPOSICION", "PUSO_DISPOSICION");
                PGJ.CargaCombo(ddlAsegurado, "CAT_ASEGURADO", "IdAsegurado", "Asegurado");
                PGJ.CargaCombo(ddlPlacasEstado, "CAT_ESTADO", "ID_ESTDO", "ESTDO");

                /*
                //Objetos
                
                lblCantidad = new Label[100];
                lblObjeto = new Label[100];
                lblDescripcion = new Label[100];
                txtCantidad = new TextBox[100];
                txtObjeto = new TextBox[100];
                txtDescripcion = new TextBox[100];

                //Vehiculos
                lblLinea = new Label[100];
                lblMarca = new Label[100];
                lblModelo = new Label[100];
                lblColor = new Label[100];
                lblPlaca = new Label[100];
                lblEstado = new Label[100];
                lblTipo = new Label[100];
                lblNumSerie = new Label[100];
                lblPropietario = new Label[100];

                txtLinea = new TextBox[100];
                txtMarca = new TextBox[100];
                txtModelo = new TextBox[100];
                txtColor = new TextBox[100];
                txtPlaca = new TextBox[100];
                txtEstado = new TextBox[100];
                txtTipo = new TextBox[100];
                txtNumSerie = new TextBox[100] ;
                txtPropietario = new TextBox[100];
                */

                //numObj = 0;
                //numVeh = 0;
                Session["BAN_INSERTAR"] = 0;

                Session["OBJ"] = 0;
                Session["VEH"] = 0;

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


    
        /*

        protected void btnObj_Click(object sender, EventArgs e)
        {

            try
            {
                if(tObj.Text != ""){

                    Panel1.Controls.Clear();

                    Session["OBJ"] = Convert.ToInt32(tObj.Text);


                    numObj = Convert.ToInt32(Session["OBJ"].ToString());

                        for (int i = 0; i < numObj; i++)
                        {

                            Label lblC = new Label();
                            lblC.Text = "CANTIDAD";
                            lblCantidad[i] = lblC;

                            TextBox txtC = new TextBox();
                            txtC.ID = "Cantidad" + i;
                            txtC.MaxLength = 3;
                            txtCantidad[i] = txtC;

                            Label lblO = new Label();
                            lblO.Text = "OBJETO";
                            lblObjeto[i] = lblO;

                            TextBox txtO = new TextBox();
                            txtO.ID = "Objeto" + i;
                            txtO.MaxLength = 250;
                            txtObjeto[i] = txtO;

                            Label lblD = new Label();
                            lblD.Text = "DESCRIPCIÓN";
                            lblDescripcion[i] = lblD;

                            TextBox txtD = new TextBox();
                            txtD.ID = "Descripcion" + i;
                            txtD.MaxLength = 500;
                            txtDescripcion[i] = txtD;

                            AgregarControlesObj(lblC, txtC,lblO,txtO,lblD,txtD);
                        }
                }
            }
            catch (Exception ex)
            {

                lblEstatus.Text = ex.Message;
            }
            

        }


        protected void btnVeh_Click1(object sender, EventArgs e)
        {
           
            try
            {
                if (txtVeh.Text != "")
                {

                    Panel2.Controls.Clear();

                    Session["VEH"] = Convert.ToInt32(txtVeh.Text);


                    numVeh = Convert.ToInt32(Session["VEH"].ToString());

                    for (int i = 0; i < numVeh; i++)
                    {

                        Label lblL = new Label();
                        lblL.Text = "LINEA";
                        lblLinea[i] = lblL;

                        TextBox txtL= new TextBox();
                        txtL.ID = "Linea" + i;
                        txtL.Width = 100;
                        txtL.MaxLength = 50;
                        txtLinea[i] = txtL;

                        Label lblM = new Label();
                        lblM.Text = "MARCA";
                        lblMarca[i] = lblM;

                        TextBox txtM = new TextBox();
                        txtM.ID = "Marca" + i;
                        txtM.Width = 100;
                        txtM.MaxLength = 50;
                        txtMarca[i] = txtM;

                        Label lblMo = new Label();
                        lblMo.Text = "MODELO";
                        lblModelo[i] = lblMo;

                        TextBox txtMo = new TextBox();
                        txtMo.ID = "Modelo" + i;
                        txtMo.Width = 100;
                        txtMo.MaxLength = 50;
                        txtModelo[i] = txtMo;

                        Label lblCo = new Label();
                        lblCo.Text = "COLOR";
                        lblColor[i] = lblCo;

                        TextBox txtCo = new TextBox();
                        txtCo.ID = "Color" + i;
                        txtCo.Width = 100;
                        txtCo.MaxLength = 50;
                        txtColor[i] = txtCo;

                        Label lblPl = new Label();
                        lblPl.Text = "PLACA";
                        lblPlaca[i] = lblPl;

                        TextBox txtPla = new TextBox();
                        txtPla.ID = "Placa" + i;
                        txtPla.Width = 100;
                        txtPla.MaxLength = 50;
                        txtPlaca[i] = txtPla;

                        Label lblE = new Label();
                        lblE.Text = "ESTADO";
                        lblEstado[i] = lblE;

                        TextBox txtE = new TextBox();
                        txtE.ID = "Estado" + i;
                        txtE.Width = 100;
                        txtE.MaxLength = 80;
                        txtEstado[i] = txtE;

                        Label lblT = new Label();
                        lblT.Text = "TIPO";
                        lblTipo[i] = lblT;

                        TextBox txtT = new TextBox();
                        txtT.ID = "Tipo" + i;
                        txtT.Width = 100;
                        txtT.MaxLength = 50;
                        txtTipo[i] = txtT;

                        Label lblNum = new Label();
                        lblNum.Text = "NÚMERO SERIE";
                        lblNumSerie[i] = lblNum;

                        TextBox txtNum = new TextBox();
                        txtNum.ID = "NumSerie" + i;
                        txtNum.Width = 100;
                        txtNum.MaxLength = 20;
                        txtNumSerie[i] = txtNum;

                        Label lblProp = new Label();
                        lblProp.Text = "PROPIETARIO";
                        lblPropietario[i] = lblProp;

                        TextBox txtProp = new TextBox();
                        txtProp.ID = "Propietario" + i;
                        txtProp.Width = 100;
                        txtProp.MaxLength = 240;
                        txtPropietario[i] = txtProp;

                        AgregarControlesVehiculos(lblL, txtL, lblM, txtM, lblMo, txtMo, lblCo, txtCo, lblPl, txtPla, lblE, txtE, lblT, txtT, lblNum, txtNum, lblProp, txtProp);
                    }
                }
                
              
            }
            catch (Exception ex)
            {

                lblEstatus.Text = ex.Message;
            }
        }
        */
        /*
        public void AgregarCtrlObjetos(TextBox txtCantidad,TextBox txtDescripcion) 
        {
            try
            {
                Panel2.Controls.Add(txtCantidad);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtDescripcion);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
            }
            catch (Exception ex)
            {
                
                lblEstatus.Text = ex.Message;
            }
        
        
        }
       */

       

        /*
        public void AgregarControlesObj(Label lblCantidad,TextBox txtCantidad,Label lblObjeto,TextBox txtObjeto, Label lblDescripcion,TextBox txtDescripcion)
        {

            numObj = Convert.ToInt32(Session["OBJ"].ToString());


                if (numObj <= 5)
                    Panel1.Style.Add("height", "200");
                if (numObj > 5 && numObj <= 15)
                    Panel1.Style.Add("height", "400");
                if (numObj > 15 && numObj <= 25)
                    Panel1.Style.Add("height", "600");
                if (numObj > 25 && numObj <= 35)
                    Panel1.Style.Add("height", "800");
                if (numObj > 35 && numObj <= 45)
                    Panel1.Style.Add("height", "1000");
                if (numObj > 45 && numObj <= 55)
                    Panel1.Style.Add("height", "1200");
                if (numObj > 55 && numObj <= 65)
                    Panel1.Style.Add("height", "1400");
                if (numObj > 65 && numObj <= 75)
                    Panel1.Style.Add("height", "1600");


                Panel1.Controls.Add(lblCantidad);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel1.Controls.Add(txtCantidad);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));

                Panel1.Controls.Add(lblObjeto);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel1.Controls.Add(txtObjeto);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));

                Panel1.Controls.Add(lblDescripcion);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel1.Controls.Add(txtDescripcion);
                Panel1.Controls.Add(new LiteralControl("<BR/>"));
                Panel1.Controls.Add(new LiteralControl("<BR/>"));

        }

        
        public void AgregarControlesVehiculos(Label lblL, TextBox txtL, Label lblM, TextBox txtM, Label lblMo, TextBox txtMo, Label lblCo, TextBox txtCo, Label lblPl, TextBox txtPla, Label lblE, TextBox txtE, Label lblT, TextBox txtT, Label lblNum, TextBox txtNum, Label lblProp, TextBox txtProp)
        {

            numVeh = Convert.ToInt32(Session["VEH"].ToString());

                if (numVeh <= 5)
                    Panel2.Style.Add("height", "200");
                if (numVeh > 5 && numVeh <= 15)
                    Panel2.Style.Add("height", "400");
                if (numVeh > 15 && numVeh <= 25)
                    Panel2.Style.Add("height", "600");
                if (numVeh > 25 && numVeh <= 35)
                    Panel2.Style.Add("height", "800");
                if (numVeh > 35 && numVeh <= 45)
                    Panel2.Style.Add("height", "1000");
                if (numVeh > 45 && numVeh <= 55)
                    Panel2.Style.Add("height", "1200");
                if (numVeh > 55 && numVeh <= 65)
                    Panel2.Style.Add("height", "1400");
                if (numVeh > 65 && numVeh <= 75)
                    Panel2.Style.Add("height", "1600");


                Panel2.Controls.Add(lblL);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtL);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(lblM);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtM);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(lblMo);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtMo);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(lblCo);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtCo);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(lblPl);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtPla);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(new LiteralControl("<BR/>"));
                Panel2.Controls.Add(new LiteralControl("<BR/>"));

                Panel2.Controls.Add(lblE);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtE);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(lblT);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtT);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(lblNum);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtNum);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                

                Panel2.Controls.Add(lblProp);
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(txtProp);
                Panel1.Controls.Add(new LiteralControl("&nbsp;"));
                Panel2.Controls.Add(new LiteralControl("&nbsp;"));

                Panel2.Controls.Add(new LiteralControl("<BR/>"));
                Panel2.Controls.Add(new LiteralControl("<BR/>"));
            

        }
        */
        

       
        protected void ddlCausaObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCausaObj.SelectedValue == "4")
            {
                lblEspecificar1.Visible = true;
                txtEspecificarObj.Visible = true;
            }
            else {
                lblEspecificar1.Visible = false;
                txtEspecificarObj.Visible = false;
            }
        }

        protected void ddlCausaVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCausaVeh.SelectedValue == "4")
            {
                lblEspecificar2.Visible = true;
                txtEspecificarVeh.Visible = true;
            }
            else
            {
                lblEspecificar2.Visible = false;
                txtEspecificarVeh.Visible = false;
            } 
        }

        protected void cmdElaborarDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ID_PLANTILLA"] = 71;
                Archivos.IdPlantilla = int.Parse(Session["ID_PLANTILLA"].ToString());
                LeerDeBD();
            }
            catch (Exception ex)
            {
                lblEstatus.Text = ex.Message;
               
            }

            Label332.Visible = true;
            FileUpload1.Visible = true;
            cmdGuardar.Visible = true;
        }


        public void LeerDeBD()
        {
            PGJ.ConnectServer();
            SqlCommand comm = new SqlCommand("SELECT * FROM CAT_PLANTILLAS " + " WHERE ID_PLANTILLA = " + Archivos.IdPlantilla, Data.CnnCentral);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet("Binarios");
            da.Fill(ds);
            //Creamos un array de bytes que contiene los bytes almacenados
            //en el campo Documento de la tabla
            byte[] bits = ((byte[])(ds.Tables[0].Rows[0].ItemArray[3]));
            //Vamos a guardar ese array de bytes como un fichero en el
            //disco duro, un fichero temporal que después se podrá descartar.
            string sFile = "TMP" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".doc";
            //Creamos un nuevo FileStream, que esta vez servirá para
            //crear un fichero con el nombre especificado
            fs = new FileStream(Server.MapPath(".") +
            @"\DocTmp\" + sFile, FileMode.Create);
            //Y escribimos en disco el array de bytes que conforman
            //el fichero Word 
            fs.Write(bits, 0, Convert.ToInt32(bits.Length));
            if (File.Exists((string)fs.Name))
            {
                object readOnly = true;
                object isVisible = true;
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = true;
                Documento = wordApp.Documents.Open(fs.Name, ref missing,
                ref readOnly, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref isVisible, ref missing, ref missing,
                ref missing, ref missing);
                fs.Close();
                Documento.Activate();
                //object saveChanges = true;
                //object FormatOriginal = true;
                traerMarcadoresProcedimientos(Archivos.IdPlantilla);
                //traermarcadoresText(Archivos.IdPlantilla);
                Documento = wordApp.Documents[sFile] as Word.Document;
                Documento.Close(Word.WdSaveOptions.wdSaveChanges);
                //wordApp.Documents.Close();
                wordApp.Application.Quit();

                string script = "<script languaje='javascript'> ";
                script += "mostrarFichero('DocTmp/" + sFile + "') ";
                script += "</script>" + Environment.NewLine;
                Page.RegisterStartupScript("mostrarFichero", script);
            }
            //LeerPDF();
        }

        public void traerMarcadoresProcedimientos(int IDPLANTILLA)
        {
            SqlDataAdapter daPlantilla = new SqlDataAdapter("consultaCAT_PLANTILLAS_MARCADORES " + Convert.ToString(IDPLANTILLA), Data.CnnCentral);
            DataSet dsPlantilla = new DataSet();
            daPlantilla.Fill(dsPlantilla, "PLANTILLAS");
            foreach (DataRow drPlantilla in dsPlantilla.Tables["PLANTILLAS"].Rows)
            {
                object oBookMark = drPlantilla["ID_MARCADOR"].ToString();
                traerInformacionMarcador(drPlantilla["ID_PROCEDIMIENTO"].ToString());
                Documento.Bookmarks.get_Item(ref oBookMark).Range.Text = textoMarcador;
            }
            dsPlantilla.Dispose();
            daPlantilla.Dispose();
        }


        public void traerInformacionMarcador(string idProcedimiento)
        {
            //string cad = idProcedimiento;
            textoMarcador = "VACIO";
            SqlDataAdapter daParametros = new SqlDataAdapter("PARAMETROS_SP '" + idProcedimiento + "'", Data.CnnCentral);
            DataSet dsParametros = new DataSet();
            daParametros.Fill(dsParametros, "Parametros");
            SqlCommand cmd = new SqlCommand(idProcedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (DataRow drParametros in dsParametros.Tables["Parametros"].Rows)
            {
                if (drParametros["Parametro"].ToString() != "NULO")
                {

                    if (drParametros["Parametro"].ToString() == "@IdCarpeta")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdCarpeta.Text;
                    }

                    if (drParametros["Parametro"].ToString() == "@id_custodiaOBJ")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdCustodiaObj.Text;
                    }
                   
                    if (drParametros["Parametro"].ToString() == "@id_custodiaVEH")
                    {
                        cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                        cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdCustodiaVeh.Text;
                    }
                    
                     if (drParametros["Parametro"].ToString() == "@IdUsuario")
                     {
                         cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.Int);
                         cmd.Parameters[drParametros["Parametro"].ToString()].Value = IdUsuario.Text;
                     }
                    /*
                     if (drParametros["Parametro"].ToString() == "@Fecha")
                     {
                         cmd.Parameters.Add(drParametros["Parametro"].ToString(), SqlDbType.DateTime);
                         cmd.Parameters[drParametros["Parametro"].ToString()].Value = Convert.ToDateTime(lblFecha.Text);
                     }*/

                }

            }
            dsParametros.Dispose();
            daParametros.Dispose();
            SqlDataReader drTextoMarcador = cmd.ExecuteReader();
            if (drTextoMarcador.HasRows)
            {
                drTextoMarcador.Read();
                textoMarcador = drTextoMarcador["Marcador"].ToString();
            }
            cmd.Dispose();
            drTextoMarcador.Close();
            drTextoMarcador.Dispose();
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            //Subir Archivo
            if (FileUpload1.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] Pdf = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    Archivos.InsertaPoliciaPDF(int.Parse(IdCarpeta.Text), Pdf, "ACTA DE ASEGURAMIENTO DE OBJETOS", 71, 0, 0, 0, 0, 0, short.Parse(Session["IdUsuario"].ToString()), short.Parse(Session["IdMunicipio"].ToString()), short.Parse(Session["IdUnidad"].ToString()));

                    //INSERTAMOS LA BITACORA DEL SISTEMA
                    PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Se elaboro el Documento para el Aseguramiento de Objetos de la carpeta " + IdCarpeta.Text);


                    Label333.Visible = false;
                    FileUpload1.Visible = false;
                    cmdGuardar.Visible = false;

                    //tbl_informe.Visible = true;

                    //Colocar Alerta 
                    string script = @"<script type='text/javascript'>
                            alert('EL ARCHIVO HA SIDO GUARDADO CORRECTAMENTE');
                                   </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }

                //MODIFICAR EL ESTADO y la fecha DE LA ORDEN ASIGNADA
                PGJ.ModificarEstadoOrden_PI(Convert.ToInt32(IdOrden.Text), 4);
                PGJ.ModificarFechaCumplida_OrdenAsignacionPI(Convert.ToInt32(IdOrden.Text));

            }
            else
            {
                Label333.Text = " *SELECCIONE UN ARCHIVO PDF";
            }
        }

        


        protected void btnAgregarObj_Click1(object sender, EventArgs e)
        {

            try
            {

                PGJ.InsertarObjeto(txtNombre.Text, txtDescObj.Text, txtCantidad.Text, Convert.ToInt32(IdCarpeta.Text), short.Parse(Session["IdMunicipio"].ToString()));

                PGJ.Insertar_ObjetoAseguradoPI( Convert.ToInt32(ddlCausaObj.SelectedValue), Convert.ToInt32(IdCarpeta.Text));
                
                
                gvConsultarObjetos.DataSourceID = "dsVerObjetos";
                gvConsultarObjetos.DataBind();
            }
            catch (Exception)
            {

                //Colocar Alerta 
                string script1 = @"<script type='text/javascript'>
                            alert('NO ES POSIBLE REGISTAR EL OBJETO, VUELVA A INTENTARLO'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);
            }
        }

        public void DeleteButtonOBJ_Command(object sender, CommandEventArgs e)
        {

            PGJ.EliminarObjetoAseguradoPI(Convert.ToInt32(e.CommandArgument.ToString()));
            gvConsultarObjetos.DataSourceID = "dsVerObjetos";
            gvConsultarObjetos.DataBind();

        }

        

        protected void btnGuardarObj_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Session["BAN_INSERTAR"].ToString()) == 0)
                {
                    PGJ.Insertar_InfoAseguramientoPI(Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(IdUsuario.Text), Convert.ToInt32(IdUnidad.Text), txtLugarAseguramiento.Text.ToUpper());
                    //Seleccionamos el ultimo id Informacion incluido
                    PGJ.ConnectServer();
                    SqlCommand comm2 = new SqlCommand("SeleccionarIDInfo " + IdCarpeta.Text, Data.CnnCentral);
                    SqlDataReader dr2 = comm2.ExecuteReader();

                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            IdInfo.Text = dr2["ID_INFO"].ToString();
                        }
                        dr2.Close();
                    }
                    
                    Session["BAN_INSERTAR"] = 1;
                }
                
                PGJ.Insertar_CustodiaObjetoPI(txtNombreCustodioObj.Text.ToUpper(), txtLugarCustodiaObj.Text, txtNombreDueñoObj.Text.ToUpper(), txtDomicilioDueñoObj.Text, txtTelefonoDueñoObj.Text, txtFechaObj.Text, txtCargoObj.Text, txtIdentificacionObj.Text, Convert.ToInt32(IdCarpeta.Text));
                //Seleccionamos el ultimo id Custodia incluido
                PGJ.ConnectServer();
                SqlCommand comm1 = new SqlCommand("SeleccionarIDCustodiaObjID " + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader dr1 = comm1.ExecuteReader();

                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        IdCustodiaObj.Text = dr1["ID_CUSTODIA"].ToString();
                    }
                    dr1.Close();
                }


                //En caso de que exista una especificacion se inserta 
                if (ddlCausaObj.SelectedValue == "4" && txtEspecificarObj.Text != "")
                {
                    PGJ.Actualizar_EspecificacionObjetoPI(txtEspecificarObj.Text, Convert.ToInt32(IdCarpeta.Text));
                }

                //Actualizamos el ID INFO Y EL ID CUSTODIA DEL OBJETO 
                PGJ.ActualizarObjetoAseguradosPI(Convert.ToInt32(IdInfo.Text), Convert.ToInt32(IdCustodiaObj.Text), Convert.ToInt32(IdCarpeta.Text));

                //INSERTAMOS LA BITACORA DEL SISTEMA
                PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Se agregaron Objetos a la Carpeta" + IdCarpeta.Text);


                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                            alert('OBJETO(S) REGISTRADO(S) CORRECTAMENTE'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                
            }
            catch (Exception ex)
            {
                //Colocar Alerta 
                string script1 = @"<script type='text/javascript'>
                            alert('NO ES POSIBLE REGISTAR EL OBJETO, VUELVA A INTENTARLO'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);
            }
        }



//        protected void btnAgregarVeh_Click1(object sender, EventArgs e)
//        {
//            try
//            {
//                PGJ.InsertaVehiculo(int.Parse(IdCarpeta.Text), "", short.Parse(ddlMarca.SelectedValue.ToString()), short.Parse(ddlSubMarca.SelectedValue.ToString()), short.Parse(ddlModelo.SelectedValue.ToString()), short.Parse(ddlColor.SelectedValue.ToString()), txtSerie.Text, txtPlaca.Text, short.Parse(ddlPlacasEstado.SelectedValue.ToString()), short.Parse(ddlProcedencia.SelectedValue.ToString()), short.Parse(ddlTipoVehiculo.SelectedValue.ToString()), short.Parse(ddlDisposicion.SelectedValue.ToString()), short.Parse(ddlAsegurado.SelectedValue.ToString()), txtObservaciones.Text, short.Parse(Session["IdMunicipio"].ToString()));
                
//                Modificar Para que Inserte en la Nueva Tabla 
//                PGJ.Insertar_VehiculoAseguradoPI(Convert.ToInt32(ddlCausaVeh.SelectedValue), Convert.ToInt32(IdCarpeta.Text));
                
//                Modificar para que traiga la Info de PGJ_VEHICULOS
//                gvConsultarVehiculos.DataSourceID = "dsVerVehiculos";
//                gvConsultarVehiculos.DataBind();
//            }
//            catch (Exception ex)
//            {
//                Colocar Alerta 
//                string script1 = @"<script type='text/javascript'>
//                            alert('NO ES POSIBLE REGISTAR EL VEHICULO, VUELVA A INTENTARLO'); </script>";
//                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);
//            }
//        }

        //public void DeleteButtonVEH_Command(object sender, CommandEventArgs e)
        //{

        //    //PGJ.EliminarVhehiculoAseguradoPI(Convert.ToInt32(e.CommandArgument.ToString()));
        //    //gvConsultarVehiculos.DataSourceID = "dsVerVehiculos";
        //    //gvConsultarVehiculos.DataBind();
        //}
        
       

        protected void btnGuardarVeh_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Session["BAN_INSERTAR"].ToString()) == 0)
                {
                    PGJ.Insertar_InfoAseguramientoPI(Convert.ToInt32(IdCarpeta.Text), Convert.ToInt32(IdUsuario.Text), Convert.ToInt32(IdUnidad.Text), txtLugarAseguramiento.Text);
                    //Seleccionamos el ultimo id Informacion incluido
                    PGJ.ConnectServer();
                    SqlCommand comm2 = new SqlCommand("SeleccionarIDInfo " + IdCarpeta.Text, Data.CnnCentral);
                    SqlDataReader dr2 = comm2.ExecuteReader();

                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            IdInfo.Text = dr2["ID_INFO"].ToString();
                        }
                        dr2.Close();
                    }
                    
                    Session["BAN_INSERTAR"] = 1;
                }

                PGJ.Insertar_CustodiaObjetoPI(txtNombreCustodioVeh.Text.ToUpper(), txtLugarCustodiaVeh.Text, txtNombreDueñoVeh.Text.ToUpper(), txtDomicilioDueñoVeh.Text, txtTelefonoDueñoVeh.Text, txtFechaVeh.Text, txtCargoVeh.Text, txtIdentificacionVeh.Text, Convert.ToInt32(IdCarpeta.Text));


                //Seleccionamos el ultimo id Custodia incluido
                PGJ.ConnectServer();
                SqlCommand comm1 = new SqlCommand("SeleccionarIDCustodiaVehID " + IdCarpeta.Text, Data.CnnCentral);
                SqlDataReader dr1 = comm1.ExecuteReader();

                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        IdCustodiaVeh.Text = dr1["ID_CUSTODIA"].ToString();
                    }
                    dr1.Close();
                }

                //En caso de que exista una especificacion se inserta 
                if (ddlCausaVeh.SelectedValue == "4" && txtEspecificarVeh.Text != "")
                {
                    PGJ.Actualizar_EspecificacionVehiculoPI(txtEspecificarVeh.Text, Convert.ToInt32(IdCarpeta.Text));
                }

                //Actualizamos el ID INFO Y EL ID CUSTODIA DEL OBJETO 
                PGJ.ActualizarVehiculosAseguradosPI(Convert.ToInt32(IdInfo.Text), Convert.ToInt32(IdCustodiaVeh.Text), Convert.ToInt32(IdCarpeta.Text));


                //INSERTAMOS LA BITACORA DEL SISTEMA
                PGJ.InsertarBitacora(Session["USUARIO"].ToString(), Session["IP_SERVER"].ToString(), Session["NOM_MAQUINA"].ToString(), "" + Session["PAGINA"], "Se agregaron Vehiculos a la Carpeta" + IdCarpeta.Text);

                //Colocar Alerta 
                string script = @"<script type='text/javascript'>
                            alert('VEHICULO(S) REGISTRADO(S) CORRECTAMENTE'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                
            }
            catch (Exception EX)
            {
                //Colocar Alerta 
                string script1 = @"<script type='text/javascript'>
                            alert('NO ES POSIBLE REGISTAR EL VEHICULO, VUELVA A INTENTARLO'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script1, false);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EliminarObjetosPI.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EliminarVehiculosPI.aspx");
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdenPoliciaInvestigador.aspx?ID_CARPETA=" + Session["ID_CARPETA"].ToString());
        }


        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_MARCA"] = ddlMarca.SelectedValue.ToString();
            consultaMarcaSubMarca();

            //PGJ.CargaComboFiltrado(ddlSubMarca, "CAT_SUBMARCA", "id_submarca", "submarca", "id_marca=" + ddlMarca.SelectedValue.ToString());
        }

        void consultaMarcaSubMarca()
        {
            dcOrientacionDataContext dc = new dcOrientacionDataContext();
            var estado = from c in dc.consultaMarcaSubMarca(short.Parse(Session["ID_MARCA"].ToString()))
                         select new { c.id_submarca, c.submarca };
            ddlSubMarca.DataSource = estado;
            ddlSubMarca.DataValueField = "id_submarca";
            ddlSubMarca.DataTextField = "submarca";
            ddlSubMarca.DataBind();
        }
        


        
    }
}