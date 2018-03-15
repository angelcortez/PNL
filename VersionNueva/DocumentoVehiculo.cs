using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AtencionTemprana
{
    public class DocumentoVehiculo
    {
        public static string NombrePlantilla;

        public static void InsertaPDFVehiculo(int IdCarpeta, byte[] Pdf, String DOCUMENTO, short ID_PLANTILLA, short IdUsuario, short IdMunicipio, short IdUnidad, int IdVehiculo, int IdAutorizacion)
        {
            SqlCommand Cmd = new SqlCommand("insertaPDF_Vehiculo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;
            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar, 100);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            Cmd.Parameters.Add("@ID_PLANTILLA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLANTILLA"].Value = ID_PLANTILLA;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdVehiculo", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculo"].Value = IdVehiculo;
            Cmd.Parameters.Add("@IdAutorizacion", SqlDbType.Int);
            Cmd.Parameters["@IdAutorizacion"].Value = IdAutorizacion;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }
    }
}