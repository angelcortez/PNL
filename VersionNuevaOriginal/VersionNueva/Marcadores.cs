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
namespace AtencionTemprana
{
    public class Marcadores
    {
        public static void Marcador(int IdCarpeta, Label Label, String procedimiento)
        {
            SqlCommand cmd = new SqlCommand(procedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label.Text = dr["Marcador"].ToString();
            }
            dr.Close();
        }

        public static void MarcadorMP(int IdCarpeta,short IdUsuario, Label Label, String procedimiento)
        {
            SqlCommand cmd = new SqlCommand(procedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label.Text = dr["Marcador"].ToString();
            }
            dr.Close();
        }

        public static void MarcadorCombo(int IdCarpeta, Label Label, String procedimiento, int IdPersona)
        {
            SqlCommand cmd = new SqlCommand(procedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            cmd.Parameters["@IdPersona"].Value = IdPersona;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label.Text = dr["Marcador"].ToString();
            }
            dr.Close();
        }

        public static void MarcadorDomicilio(int IdCarpeta, TextBox  Label, String procedimiento)
        {
            SqlCommand cmd = new SqlCommand(procedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label.Text = dr["Marcador"].ToString();
            }
            dr.Close();
        }
        public static void MarcadorComboDefensor(int IdCarpeta, Label Label, String procedimiento, int IdDefensor)
        {
            SqlCommand cmd = new SqlCommand(procedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            cmd.Parameters.Add("@IdDefensor", SqlDbType.Int);
            cmd.Parameters["@IdDefensor"].Value = IdDefensor;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label.Text = dr["Marcador"].ToString();
            }
            dr.Close();
        }
        public static void MarcadorFechas(Label Label, String procedimiento)
        {
            SqlCommand cmd = new SqlCommand(procedimiento, Data.CnnCentral);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Label.Text = dr["Marcador"].ToString();
            }
            dr.Close();
        }

    }
}