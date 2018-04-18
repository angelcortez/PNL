using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AtencionTemprana
{
   
    public class Archivos
    {
        public static int IdPlantilla;

        public static int InsertaPGJNucJudOrdenPersona(int IdCarpeta, int IdMunicipioCarpeta, int IdPersona, int IdOficio, int IdEstadoOrden, int IdMotivoCancelacion, DateTime FechaEjecucion, DateTime FechaCancelacion, DateTime FechaDisposicion, int IdAutoridadOrden, String OtraAutoridad, DateTime FechaAmparo, String NumeroAmparo, short IdJuzgadoAmparo, String JuezNombreAmparo, String JuezPaternoAmparo, String JuezMaternoAmparo, int SuspensionProvisional, DateTime FechaAutoSuspension, int SuspensionDefinitiva, DateTime FechaResolucionIncidente, int AmparoConcedido, DateTime FechaResolucionAmparo, String EfectosAmparo, String Observaciones, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPGJ_NUC_JUD_ORDEN_PERSONA", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;

            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdOficio", SqlDbType.Int);
            Cmd.Parameters["@IdOficio"].Value = IdOficio;

            Cmd.Parameters.Add("@IdEstadoOrden", SqlDbType.Int);
            Cmd.Parameters["@IdEstadoOrden"].Value = IdEstadoOrden;

            Cmd.Parameters.Add("@IdMotivoCancelacion", SqlDbType.Int);
            Cmd.Parameters["@IdMotivoCancelacion"].Value = IdMotivoCancelacion;

            Cmd.Parameters.Add("@FechaEjecucion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEjecucion"].Value = FechaEjecucion;

            Cmd.Parameters.Add("@FechaCancelacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaCancelacion"].Value = FechaCancelacion;

            Cmd.Parameters.Add("@FechaDisposicion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaDisposicion"].Value = FechaDisposicion;

            Cmd.Parameters.Add("@IdAutoridadOrden", SqlDbType.Int);
            Cmd.Parameters["@IdAutoridadOrden"].Value = IdAutoridadOrden;

            Cmd.Parameters.Add("@OtraAutoridad", SqlDbType.VarChar, 100);
            Cmd.Parameters["@OtraAutoridad"].Value = OtraAutoridad;

            Cmd.Parameters.Add("@FechaAmparo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAmparo"].Value = FechaAmparo;

            Cmd.Parameters.Add("@NumeroAmparo", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAmparo"].Value = NumeroAmparo;

            Cmd.Parameters.Add("@IdJuzgadoAmparo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdJuzgadoAmparo"].Value = IdJuzgadoAmparo;

            Cmd.Parameters.Add("@JuezNombreAmparo", SqlDbType.VarChar, 100);
            Cmd.Parameters["@JuezNombreAmparo"].Value = JuezNombreAmparo;

            Cmd.Parameters.Add("@JuezPaternoAmparo", SqlDbType.VarChar, 100);
            Cmd.Parameters["@JuezPaternoAmparo"].Value = JuezPaternoAmparo;

            Cmd.Parameters.Add("@JuezMaternoAmparo", SqlDbType.VarChar, 100);
            Cmd.Parameters["@JuezMaternoAmparo"].Value = JuezMaternoAmparo;

            Cmd.Parameters.Add("@SuspensionProvisional", SqlDbType.Int);
            Cmd.Parameters["@SuspensionProvisional"].Value = SuspensionProvisional;

            Cmd.Parameters.Add("@FechaAutoSuspension", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAutoSuspension"].Value = FechaAutoSuspension;

            Cmd.Parameters.Add("@SuspensionDefinitiva", SqlDbType.Int);
            Cmd.Parameters["@SuspensionDefinitiva"].Value = SuspensionDefinitiva;

            Cmd.Parameters.Add("@FechaResolucionIncidente", SqlDbType.DateTime);
            Cmd.Parameters["@FechaResolucionIncidente"].Value = FechaResolucionIncidente;

            Cmd.Parameters.Add("@AmparoConcedido", SqlDbType.Int);
            Cmd.Parameters["@AmparoConcedido"].Value = AmparoConcedido;

            Cmd.Parameters.Add("@FechaResolucionAmparo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaResolucionAmparo"].Value = FechaResolucionAmparo;

            Cmd.Parameters.Add("@EfectosAmparo", SqlDbType.VarChar, 250);
            Cmd.Parameters["@EfectosAmparo"].Value = EfectosAmparo;

            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                DR.Read();
                return int.Parse(DR["IdOrden"].ToString());
            }
            else
            {
                return 0;
            }

            DR.Close();

        }

        public static void ModificaPGJNucJudOrdenPersona(int IdOrden, int IdEstadoOrden, int IdMotivoCancelacion, DateTime FechaEjecucion, DateTime FechaCancelacion, DateTime FechaDisposicion, int IdAutoridadOrden, String OtraAutoridad, DateTime FechaAmparo, String NumeroAmparo, short IdJuzgadoAmparo, String JuezNombreAmparo, String JuezPaternoAmparo, String JuezMaternoAmparo, int SuspensionProvisional, DateTime FechaAutoSuspension, int SuspensionDefinitiva, DateTime FechaResolucionIncidente, int AmparoConcedido, DateTime FechaResolucionAmparo, String EfectosAmparo, String Observaciones, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("ModificaPGJ_NUC_JUD_ORDEN_PERSONA", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdOrden", SqlDbType.Int);
            Cmd.Parameters["@IdOrden"].Value = IdOrden;

            Cmd.Parameters.Add("@IdEstadoOrden", SqlDbType.Int);
            Cmd.Parameters["@IdEstadoOrden"].Value = IdEstadoOrden;

            Cmd.Parameters.Add("@IdMotivoCancelacion", SqlDbType.Int);
            Cmd.Parameters["@IdMotivoCancelacion"].Value = IdMotivoCancelacion;

            Cmd.Parameters.Add("@FechaEjecucion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEjecucion"].Value = FechaEjecucion;

            Cmd.Parameters.Add("@FechaCancelacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaCancelacion"].Value = FechaCancelacion;

            Cmd.Parameters.Add("@FechaDisposicion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaDisposicion"].Value = FechaDisposicion;

            Cmd.Parameters.Add("@IdAutoridadOrden", SqlDbType.Int);
            Cmd.Parameters["@IdAutoridadOrden"].Value = IdAutoridadOrden;

            Cmd.Parameters.Add("@OtraAutoridad", SqlDbType.VarChar, 100);
            Cmd.Parameters["@OtraAutoridad"].Value = OtraAutoridad;

            Cmd.Parameters.Add("@FechaAmparo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAmparo"].Value = FechaAmparo;

            Cmd.Parameters.Add("@NumeroAmparo", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAmparo"].Value = NumeroAmparo;

            Cmd.Parameters.Add("@IdJuzgadoAmparo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdJuzgadoAmparo"].Value = IdJuzgadoAmparo;

            Cmd.Parameters.Add("@JuezNombreAmparo", SqlDbType.VarChar, 100);
            Cmd.Parameters["@JuezNombreAmparo"].Value = JuezNombreAmparo;

            Cmd.Parameters.Add("@JuezPaternoAmparo", SqlDbType.VarChar, 100);
            Cmd.Parameters["@JuezPaternoAmparo"].Value = JuezPaternoAmparo;

            Cmd.Parameters.Add("@JuezMaternoAmparo", SqlDbType.VarChar, 100);
            Cmd.Parameters["@JuezMaternoAmparo"].Value = JuezMaternoAmparo;

            Cmd.Parameters.Add("@SuspensionProvisional", SqlDbType.Int);
            Cmd.Parameters["@SuspensionProvisional"].Value = SuspensionProvisional;

            Cmd.Parameters.Add("@FechaAutoSuspension", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAutoSuspension"].Value = FechaAutoSuspension;

            Cmd.Parameters.Add("@SuspensionDefinitiva", SqlDbType.Int);
            Cmd.Parameters["@SuspensionDefinitiva"].Value = SuspensionDefinitiva;

            Cmd.Parameters.Add("@FechaResolucionIncidente", SqlDbType.DateTime);
            Cmd.Parameters["@FechaResolucionIncidente"].Value = FechaResolucionIncidente;

            Cmd.Parameters.Add("@AmparoConcedido", SqlDbType.Int);
            Cmd.Parameters["@AmparoConcedido"].Value = AmparoConcedido;

            Cmd.Parameters.Add("@FechaResolucionAmparo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaResolucionAmparo"].Value = FechaResolucionAmparo;

            Cmd.Parameters.Add("@EfectosAmparo", SqlDbType.VarChar, 250);
            Cmd.Parameters["@EfectosAmparo"].Value = EfectosAmparo;

            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }
       
        public static void Guardar(int ID_CARPETA,string IdUsuario, string IdMunicipio, string IdUnidad, string IdTipoSolicitud, string IdTipoAudiencia, string NUC, byte[] archivo)
        {
            SqlCommand Cmd = new SqlCommand("InsertaSolicitudAudiencia", Data.CnnCentral);
              Cmd.CommandType = CommandType.StoredProcedure;
              Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
              Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
              Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
              Cmd.Parameters["@IdUsuario"].Value =IdUsuario;
              Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.Int);
              Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
              Cmd.Parameters.Add("@Id_Unidad", SqlDbType.Int);
              Cmd.Parameters["@Id_Unidad"].Value = IdUnidad;
              Cmd.Parameters.Add("@IdTipoAudiencia", SqlDbType.Int);
              Cmd.Parameters["@IdTipoAudiencia"].Value = IdTipoSolicitud;
              Cmd.Parameters.Add("@idTipoSolicitud", SqlDbType.Int);
              Cmd.Parameters["@idTipoSolicitud"].Value = IdTipoAudiencia;
              Cmd.Parameters.Add("@NUC", SqlDbType.VarChar);
              Cmd.Parameters["@NUC"].Value = NUC;
              Cmd.Parameters.Add("@documento", SqlDbType.Image);
              Cmd.Parameters["@documento"].Value = archivo;
              SqlDataReader DR = Cmd.ExecuteReader();
              DR.Close();
              //Cmd.ExecuteNonQuery();

            }

        public static void InsertarNotifiacionPersonalizadaAcuse(int idNotificacionPDF, int idMunicipio, byte[] Acuse)
        {
            SqlCommand Cmd = new SqlCommand("InsertarNotifiacionPersonalizadaAcuse", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@idNotificacionPDF", SqlDbType.Int);
            Cmd.Parameters["@idNotificacionPDF"].Value = idNotificacionPDF;
            Cmd.Parameters.Add("@idMunicipio", SqlDbType.Int);
            Cmd.Parameters["@idMunicipio"].Value = idMunicipio;
            Cmd.Parameters.Add("@Acuse", SqlDbType.Image);
            Cmd.Parameters["@Acuse"].Value = Acuse;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public static void InsertaCarpetaDigital(int IdCarpeta, byte[] Digital, short IdUsuario, short IdMunicipio, short IdUnidad,short IdPlantilla)
        {
            SqlCommand Cmd = new SqlCommand("InsertaCarpetaDigital", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Digital", SqlDbType.Image);
            Cmd.Parameters["@Digital"].Value = Digital;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdPlantilla", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPlantilla"].Value = IdPlantilla;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }
         
        public static void InsertaCarpetaPDF(int IdCarpeta, byte[] Pdf,String DOCUMENTO, short ID_PLANTILLA,int ID_DENCINCIANTE ,int ID_OFENDIDO ,int ID_IMPUTADO , int ID_TESTIGO ,int ID_DEFENSOR ,short IdUsuario, short IdMunicipio, short IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaCarpetaPDF", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar,100);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLANTILLA"].Value = ID_PLANTILLA;
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = ID_DENCINCIANTE;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFENDIDO"].Value = ID_OFENDIDO;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = ID_IMPUTADO;
            Cmd.Parameters.Add("@ID_TESTIGO", SqlDbType.Int);
            Cmd.Parameters["@ID_TESTIGO"].Value = ID_TESTIGO;
            Cmd.Parameters.Add("@ID_DEFENSOR", SqlDbType.Int);
            Cmd.Parameters["@ID_DEFENSOR"].Value = ID_DEFENSOR;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public static void InsertaBoletinPDF(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte,  int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("InsertaBoletinPDF", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdTipoBoletin", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoBoletin"].Value = IdTipoBoletin;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@pdf", SqlDbType.Image);
            Cmd.Parameters["@pdf"].Value = Pdf;
            Cmd.Parameters.Add("@numeroreporte", SqlDbType.VarChar);
            Cmd.Parameters["@numeroreporte"].Value = numeroreporte;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;



            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }


        public static void ActualizaCarpetaPDF(int ID_PDF, byte[] Pdf,int ID_DENCINCIANTE ,int ID_OFENDIDO ,int ID_IMPUTADO , int ID_TESTIGO ,int ID_DEFENSOR )
        {
            SqlCommand Cmd = new SqlCommand("ActualizaCarpetaPDF", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@ID_PDF", SqlDbType.Int);
            Cmd.Parameters["@ID_PDF"].Value = ID_PDF;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;

           
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = ID_DENCINCIANTE;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFENDIDO"].Value = ID_OFENDIDO;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = ID_IMPUTADO;
            Cmd.Parameters.Add("@ID_TESTIGO", SqlDbType.Int);
            Cmd.Parameters["@ID_TESTIGO"].Value = ID_TESTIGO;
            Cmd.Parameters.Add("@ID_DEFENSOR", SqlDbType.Int);
            Cmd.Parameters["@ID_DEFENSOR"].Value = ID_DEFENSOR;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }
      
        public static void InsertaPdfMediacion(int IdCarpeta, byte[] Pdf, short IdPlantilla, int IdDenunciante, int IdOfendido, int IdImputado, String Documento, short IdMunicipio, short IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPdfMediacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = IdCarpeta;

            Cmd.Parameters.Add("@PDF", SqlDbType.Image);
            Cmd.Parameters["@PDF"].Value = Pdf;
            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt );
            Cmd.Parameters["@ID_PLANTILLA"].Value = IdPlantilla;
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = IdDenunciante;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFENDIDO"].Value = IdOfendido;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = IdImputado;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = IdUsuario;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar );
            Cmd.Parameters["@DOCUMENTO"].Value = Documento;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public static void ActualizaPdfMediacion(byte[] Pdf,  int IdPdf)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaPdfMediacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PDF", SqlDbType.Int);
            Cmd.Parameters["@ID_PDF"].Value = IdPdf;

            Cmd.Parameters.Add("@PDF", SqlDbType.Image);
            Cmd.Parameters["@PDF"].Value = Pdf;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public static void InsertaPdfAtencion(int IdCarpeta, byte[] Pdf, String Documento,short IdPlantilla,int IdDenunciante,int IdOfendido, short IdUsuario,short IdMunicipio,short IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPdfAtencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@PDF", SqlDbType.Image);
            Cmd.Parameters["@PDF"].Value = Pdf;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar);
            Cmd.Parameters["@DOCUMENTO"].Value = Documento;
            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLANTILLA"].Value = IdPlantilla;
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = IdDenunciante;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_OFENDIDO"].Value = IdOfendido;
            //Cmd.Parameters.Add("@DERECHO", SqlDbType.VarChar);
            //Cmd.Parameters["@DERECHO"].Value = Derecho;
            //Cmd.Parameters.Add("@PROTESTO", SqlDbType.VarChar);
            //Cmd.Parameters["@PROTESTO"].Value = Protesto;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = IdUsuario;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNIDAD"].Value = IdUnidad;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public static void ActualizaPdfAtencion(int IdPdf, byte[] Pdf,int IdDenunciante, int IdOfendido)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaPdfAtencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdPdf", SqlDbType.Int);
            Cmd.Parameters["@IdPdf"].Value = IdPdf;

            Cmd.Parameters.Add("@PDF", SqlDbType.Image);
            Cmd.Parameters["@PDF"].Value = Pdf;
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = IdDenunciante;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_OFENDIDO"].Value = IdOfendido;
            //Cmd.Parameters.Add("@DERECHO", SqlDbType.VarChar);
            //Cmd.Parameters["@DERECHO"].Value = Derecho;
            //Cmd.Parameters.Add("@PROTESTO", SqlDbType.VarChar);
            //Cmd.Parameters["@PROTESTO"].Value = Protesto;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }
        
        public static void InsertaPlantilla(short IdTipoPlantilla, String NombrePlantilla, Byte[] Plantilla, short RAC, short NUM, short NUC, short Comparecencia, short Escrito, short RazonAviso, short ConDetenido, short SinDetenido)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPlantilla", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdTipoPlantilla", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoPlantilla"].Value = IdTipoPlantilla;
            Cmd.Parameters.Add("@NombrePlantilla", SqlDbType.VarChar);
            Cmd.Parameters["@NombrePlantilla"].Value = NombrePlantilla;
            Cmd.Parameters.Add("@Plantilla", SqlDbType.Image);
            Cmd.Parameters["@Plantilla"].Value = Plantilla;
            Cmd.Parameters.Add("@RAC", SqlDbType.Bit);
            Cmd.Parameters["@RAC"].Value = RAC;
            Cmd.Parameters.Add("@NUM", SqlDbType.Bit);
            Cmd.Parameters["@NUM"].Value = NUM;
            Cmd.Parameters.Add("@NUC", SqlDbType.Bit);
            Cmd.Parameters["@NUC"].Value = NUC;
            Cmd.Parameters.Add("@Comparecencia", SqlDbType.Bit);
            Cmd.Parameters["@Comparecencia"].Value = Comparecencia;
            Cmd.Parameters.Add("@Escrito", SqlDbType.Bit);
            Cmd.Parameters["@Escrito"].Value = Escrito;
            Cmd.Parameters.Add("@RazonAviso", SqlDbType.Bit);
            Cmd.Parameters["@RazonAviso"].Value = RazonAviso;
            Cmd.Parameters.Add("@ConDetenido", SqlDbType.Bit);
            Cmd.Parameters["@ConDetenido"].Value = ConDetenido;
            Cmd.Parameters.Add("@SinDetenido", SqlDbType.Bit);
            Cmd.Parameters["@SinDetenido"].Value = SinDetenido;
            Cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int);
            Cmd.Parameters["@IdPlantilla"].Direction = ParameterDirection.Output;

            SqlDataReader DR = Cmd.ExecuteReader();
            IdPlantilla = Convert.ToInt32(Cmd.Parameters["@IdPlantilla"].Value);

            DR.Close();
        }

        public static void InsertaCarpetaPDFRemitir(int IdCarpeta, byte[] Pdf, String DOCUMENTO, short ID_PLANTILLA, int ID_DENCINCIANTE,
        int ID_OFENDIDO, int ID_IMPUTADO, int ID_TESTIGO, int ID_DEFENSOR, short IdUsuario, short IdMunicipio, short IdUnidad, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaCarpetaPDFRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar, 100);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLANTILLA"].Value = ID_PLANTILLA;
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = ID_DENCINCIANTE;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFENDIDO"].Value = ID_OFENDIDO;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = ID_IMPUTADO;
            Cmd.Parameters.Add("@ID_TESTIGO", SqlDbType.Int);
            Cmd.Parameters["@ID_TESTIGO"].Value = ID_TESTIGO;
            Cmd.Parameters.Add("@ID_DEFENSOR", SqlDbType.Int);
            Cmd.Parameters["@ID_DEFENSOR"].Value = ID_DEFENSOR;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public static List<Archivo> GetAll()
        {
            List<Archivo> lista = new List<Archivo>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                conn.Open();

                string query = @"SELECT Id, Nombre, Length  
                                    FROM Archivos";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Archivo img = new Archivo(
                                            Convert.ToInt32(reader["Id"]),
                                            Convert.ToString(reader["nombre"]),
                                            Convert.ToInt32(reader["length"]));
                    lista.Add(img);
                }

            }

            return lista;

        }

        public static Archivo GetById(int Id)
        {
            Archivo arch = null;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                conn.Open();

                string query = @"SELECT Id, Nombre, Length, archivo
                                FROM Archivos
                                WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    arch = new Archivo(
                                    Convert.ToInt32(reader["Id"]),
                                    Convert.ToString(reader["nombre"]),
                                    Convert.ToInt32(reader["length"]));

                    arch.ContenidoArchivo = (byte[])reader["archivo"];

                }

            }

            return arch;

        }

        public static void DeleteById(int Id)
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ToString()))
            {
                conn.Open();

                string query = @"DELETE FROM Archivos WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Id);

                cmd.ExecuteNonQuery();

            }
        }

        //*************************   POLICIAS INVESTIGADORES ***************************************

        #region

        public static void InsertaPoliciaPDF(int IdCarpeta, byte[] Pdf, String DOCUMENTO, short ID_PLANTILLA, int ID_DENCINCIANTE, int ID_OFENDIDO, int ID_IMPUTADO, int ID_TESTIGO, int ID_DEFENSOR, short IdUsuario, short IdMunicipio, short IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPoliciaPDF", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar, 100);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLANTILLA"].Value = ID_PLANTILLA;
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = ID_DENCINCIANTE;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFENDIDO"].Value = ID_OFENDIDO;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = ID_IMPUTADO;
            Cmd.Parameters.Add("@ID_TESTIGO", SqlDbType.Int);
            Cmd.Parameters["@ID_TESTIGO"].Value = ID_TESTIGO;
            Cmd.Parameters.Add("@ID_DEFENSOR", SqlDbType.Int);
            Cmd.Parameters["@ID_DEFENSOR"].Value = ID_DEFENSOR;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }


        public static void InsertarSolPeritoPDF(int IdCarpeta, byte[] Pdf, String DOCUMENTO, short ID_PLANTILLA, int ID_DENCINCIANTE, int ID_OFENDIDO, int ID_IMPUTADO, int ID_TESTIGO, int ID_DEFENSOR, short IdUsuario, short IdMunicipio, short IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertarSolPeritoPDF", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar, 100);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLANTILLA"].Value = ID_PLANTILLA;
            Cmd.Parameters.Add("@ID_DENCINCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENCINCIANTE"].Value = ID_DENCINCIANTE;
            Cmd.Parameters.Add("@ID_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFENDIDO"].Value = ID_OFENDIDO;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = ID_IMPUTADO;
            Cmd.Parameters.Add("@ID_TESTIGO", SqlDbType.Int);
            Cmd.Parameters["@ID_TESTIGO"].Value = ID_TESTIGO;
            Cmd.Parameters.Add("@ID_DEFENSOR", SqlDbType.Int);
            Cmd.Parameters["@ID_DEFENSOR"].Value = ID_DEFENSOR;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public static void InsertarDetencionPDF(int ID_CARPETA, byte[] PDF, int ID_PLANTILLA, string DOCUMENTO, int ID_MUNICIPIO, int ID_USUARIO, int ID_UNIDAD, int ID_DETENCION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencionPDF", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@PDF", SqlDbType.Image);
            Cmd.Parameters["@PDF"].Value = PDF;

            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.Int);
            Cmd.Parameters["@ID_PLANTILLA"].Value = ID_PLANTILLA;

            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.Int);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = ID_MUNICIPIO;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

            Cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.Int);
            Cmd.Parameters["@ID_UNIDAD"].Value = ID_UNIDAD;

            Cmd.Parameters.Add("@ID_DETENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_DETENCION"].Value = ID_DETENCION;



            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        #endregion
        //******************************   FIN POLICIA INVESTIGADOR 






        //Periciales

        #region
        public static void InsertaDocPeritosPDF(int IdSol, int IdCarpeta, byte[] Pdf, String DOCUMENTO, short ID_PLANTILLA, short IdMunicipio, short IdUsuario, short IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDocPeritosPDF", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@id_solicitud", SqlDbType.Int);
            Cmd.Parameters["@id_solicitud"].Value = IdSol;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar, 100);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLANTILLA"].Value = ID_PLANTILLA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }


        #endregion



    }
     public class Archivo
        {
            public Archivo(int id, string nombre, int length)
            {
                this.Id = id;
                this.Nombre = nombre;
                this.Length = length;
            }
            public int Id { get; set; }
            public int Length { get; set; }
            public string Nombre { get; set; }

            public byte[] ContenidoArchivo { get; set; }
        }


}
