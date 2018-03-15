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
    public class Data
    {
        public static SqlConnection Connection;
        public static SqlConnection CnnCentral;
        public static SqlConnection CnnCatalogos;
        public static int IdCarpeta;
        public static String RAC;
        public static String NUC;
        public static String NUM;
        public static String NAC;
        public static int IdPlantilla;
        public static short IdMunicipio;
        public static int IdTurnoPersona;
        public static int IdTurnoPantalla;
        public static short IdUsuario;
        
        public void ConnectServer()
        {
            CnnCentral = new SqlConnection("Data Source=172.23.8.25;Initial Catalog=PNL_NSJP2;User ID=PGJNSJP;Password=Usuario.25;MultipleActiveResultSets=true");
            CnnCentral.Open();

            //SqlCommand Cmd = new SqlCommand("set dateformat dmy", Data.CnnCentral);
            //SqlDataReader DR = Cmd.ExecuteReader();
            //DR.Close();

        }

        
       public void ConnectCatalogosMediaFiliacion()
        {

            CnnCatalogos = new SqlConnection("Data Source=172.23.8.25;Initial Catalog=PGJ_MEDIA_FILIACION;User ID=PGJNSJP;Password=Usuario.25");
            CnnCatalogos.Open();

            //SqlCommand Cmd = new SqlCommand("set dateformat dmy", Data.CnnCentral);
            //SqlDataReader DR = Cmd.ExecuteReader();
            //DR.Close();

        }

        public void CargaComboCatalogosMediaFiliacion(DropDownList Combo, String Tabla, String Id, String Campo)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand cmd = new SqlCommand("Catalogo " + Tabla + ", " + Id + ", " + Campo, Data.CnnCatalogos);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                Combo.DataSource = rd;
                Combo.DataValueField = "ID";
                Combo.DataTextField = "CAMPO";
                Combo.DataBind();
            }
            rd.Close();
        }

        public void InsertarBitacora(int ID_USUARIO, string IP, string URL, int ID_TIPO_MOVIMIENTO, string MOVIMIENTO, int ID_MODULO)
        {
            SqlCommand Cmd = new SqlCommand("InsertarBitacora", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            Cmd.Parameters.Add("@IP", SqlDbType.VarChar);
            Cmd.Parameters["@IP"].Value = IP;
            Cmd.Parameters.Add("@URL", SqlDbType.VarChar);
            Cmd.Parameters["@URL"].Value = URL;
            Cmd.Parameters.Add("@ID_TIPO_MOV", SqlDbType.Int);
            Cmd.Parameters["@ID_TIPO_MOV"].Value = ID_TIPO_MOVIMIENTO;
            Cmd.Parameters.Add("@MOVIMIENTO", SqlDbType.VarChar);
            Cmd.Parameters["@MOVIMIENTO"].Value = MOVIMIENTO;
            Cmd.Parameters.Add("@ID_MODULO", SqlDbType.Int);
            Cmd.Parameters["@ID_MODULO"].Value = ID_MODULO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void sp_Actualiza_Clave_Sistema(int ID_USUARIO, string PASSWORD)
        {
            SqlCommand Cmd = new SqlCommand("sp_Actualiza_Contra_Usuario", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            Cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar);
            Cmd.Parameters["@PASSWORD"].Value = PASSWORD;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void InsertaNUC(String NUC, short IdEstadoNuc, short IdUsuarioNuc, int IdCarpeta)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNUC", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NUC", SqlDbType.VarChar);
            Cmd.Parameters["@NUC"].Value = NUC;
            //Cmd.Parameters.Add("@FechaNuc", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaNuc"].Value = FechaNuc;
            Cmd.Parameters.Add("@IdEstadoNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoNuc"].Value = IdEstadoNuc;
            //Cmd.Parameters.Add("@FechaEstadoNuc", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaEstadoNuc"].Value = FechaEstadoNuc;
            Cmd.Parameters.Add("@IdUsuarioNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNuc"].Value = IdUsuarioNuc;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            SqlDataReader DR = Cmd.ExecuteReader();
            // IdCarpeta = Convert.ToInt32(Cmd.Parameters["@IdCarpeta"].Value);
            DR.Close();
        }

        public void InsertaRacRemitida(int ID_CARPETA, short IdMunicipio, short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRacRemitida", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaArbol(int Id, int IdPadre, String Nodo, String URL, string Icon, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("InsertaArbol", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@Id", SqlDbType.Int);
            Cmd.Parameters["@Id"].Value = Id;
            Cmd.Parameters.Add("@IdPadre", SqlDbType.Int);
            Cmd.Parameters["@IdPadre"].Value = IdPadre;
            Cmd.Parameters.Add("@Nodo", SqlDbType.VarChar);
            Cmd.Parameters["@Nodo"].Value = Nodo;
            Cmd.Parameters.Add("@URL", SqlDbType.VarChar);
            Cmd.Parameters["@URL"].Value = URL;
            Cmd.Parameters.Add("@Icon", SqlDbType.VarChar);
            Cmd.Parameters["@Icon"].Value = Icon;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminaArbol(int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("Delete PGJ_Arbol Where IdUsuario=" + Convert.ToString(IdUsuario), Data.CnnCentral);
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaTurnoPersona(int NumeroTurno, String Nombre, String Paterno, String Materno, short IdUnidad, short IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("InsertaTurnoPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NumeroTurno", SqlDbType.Int);
            Cmd.Parameters["@NumeroTurno"].Value = NumeroTurno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdTurno", SqlDbType.Int);
            Cmd.Parameters["@IdTurno"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            IdTurnoPersona = Convert.ToInt32(Cmd.Parameters["@IdTurno"].Value);
            DR.Close();
        }

        public void InsertaTurnoPantalla(int NumeroTurno, String NombrePersona, String Unidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaTurnoPantalla", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NumeroTurno", SqlDbType.Int);
            Cmd.Parameters["@NumeroTurno"].Value = NumeroTurno;
            Cmd.Parameters.Add("@NombrePersona", SqlDbType.VarChar);
            Cmd.Parameters["@NombrePersona"].Value = NombrePersona;
            Cmd.Parameters.Add("@Unidad", SqlDbType.VarChar);
            Cmd.Parameters["@Unidad"].Value = Unidad;
            Cmd.Parameters.Add("@IdTurnoPantalla", SqlDbType.Int);
            Cmd.Parameters["@IdTurnoPantalla"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            IdTurnoPantalla = Convert.ToInt32(Cmd.Parameters["@IdTurnoPantalla"].Value);
            DR.Close();
        }

        public void CargaCombo(DropDownList Combo, String Tabla, String Id, String Campo)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand cmd = new SqlCommand("Catalogo " + Tabla + ", " + Id + ", " + Campo, Data.CnnCentral);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                Combo.DataSource = rd;
                Combo.DataValueField = "ID";
                Combo.DataTextField = "CAMPO";
                Combo.DataBind();
            }
            rd.Close();
        }

        public void CargaComboOrden(DropDownList Combo, String Tabla, String Id, String Campo, String Orden)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand cmd = new SqlCommand("CatalogoOrden '" + Tabla + "', '" + Id + "', '" + Campo + "', '" + Orden + "'", Data.CnnCentral);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                Combo.DataSource = rd;
                Combo.DataValueField = "ID";
                Combo.DataTextField = "CAMPO";
                Combo.DataBind();
            }
            rd.Close();
        }
     
        public void CargaComboFiltrado(DropDownList Combo, String Tabla, String Id, String Campo, String Filtro)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand Cmd = new SqlCommand("CatalogoFiltrado", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Tabla", SqlDbType.VarChar);
            Cmd.Parameters["@Tabla"].Value = Tabla;
            Cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            Cmd.Parameters["@Id"].Value = Id;
            Cmd.Parameters.Add("@Campo", SqlDbType.VarChar);
            Cmd.Parameters["@Campo"].Value = Campo;
            Cmd.Parameters.Add("@Filtro", SqlDbType.VarChar);
            Cmd.Parameters["@Filtro"].Value = Filtro;
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                Combo.DataSource = DR;
                Combo.DataValueField = "ID";
                Combo.DataTextField = "CAMPO";
                Combo.DataBind();
            }
            DR.Close();
        }

        public void CargaComboNAC(DropDownList Combo)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand Cmd = new SqlCommand("CatalogoNAC", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                Combo.DataSource = DR;
                Combo.DataValueField = "ID_PLANTILLA";
                Combo.DataTextField = "NOMBRE_PLANTILLA";
                Combo.DataBind();
            }
            DR.Close();
        }
        public void CargaComboNUC(DropDownList Combo)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand Cmd = new SqlCommand("CatalogoNUC", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                Combo.DataSource = DR;
                Combo.DataValueField = "ID_PLANTILLA";
                Combo.DataTextField = "NOMBRE_PLANTILLA";
                Combo.DataBind();
            }
            DR.Close();
        }
        public void CargaComboNUM(DropDownList Combo)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand Cmd = new SqlCommand("CatalogoNUM", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                Combo.DataSource = DR;
                Combo.DataValueField = "ID_PLANTILLA";
                Combo.DataTextField = "NOMBRE_PLANTILLA";
                Combo.DataBind();
            }
            DR.Close();
        }
        public void InsertaSinAcuerdo(int ID_CARPETA, short IdMunicipio, int ID_SOLICITANTE,int ID_INVITADO,short ID_UNDD,short  ID_UNDD_REMITE,DateTime FECHA_REMITE, short ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaSinAcuerdo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_SOLICITANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITANTE"].Value = ID_SOLICITANTE;
            Cmd.Parameters.Add("@ID_INVITADO", SqlDbType.Int);
            Cmd.Parameters["@ID_INVITADO"].Value = ID_INVITADO;
            Cmd.Parameters.Add("@ID_UNDD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNDD"].Value = ID_UNDD;
            Cmd.Parameters.Add("@ID_UNDD_REMITE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNDD_REMITE"].Value = ID_UNDD_REMITE;
            Cmd.Parameters.Add("@FECHA_REMITE", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_REMITE"].Value = FECHA_REMITE;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaAcuerdoDiferido(int ID_CARPETA, short IdMunicipio,int IdSolicitante,int IdInvitado, short ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaAcuerdoDiferido", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_SOLICITANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITANTE"].Value = IdSolicitante;
            Cmd.Parameters.Add("@ID_INVITADO", SqlDbType.Int);
            Cmd.Parameters["@ID_INVITADO"].Value = IdInvitado;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaAcuerdoDiferidoFecha(int ID_CARPETA, int ID_NUM_CUM_DIFERIDO, DateTime FECHA_CUMPLIMIENTO, short ID_CUMPLIDO, String CONCEPTO, String IMPORTE, short IdMunicipio,short ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaAcuerdoDiferidoFecha", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_NUM_CUM_DIFERIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_NUM_CUM_DIFERIDO"].Value = ID_NUM_CUM_DIFERIDO;

            Cmd.Parameters.Add("@FECHA_CUMPLIMIENTO", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_CUMPLIMIENTO"].Value = FECHA_CUMPLIMIENTO;
            Cmd.Parameters.Add("@ID_CUMPLIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CUMPLIDO"].Value = ID_CUMPLIDO;
            Cmd.Parameters.Add("@CONCEPTO", SqlDbType.VarChar);
            Cmd.Parameters["@CONCEPTO"].Value = CONCEPTO;
            Cmd.Parameters.Add("@IMPORTE", SqlDbType.VarChar);
            Cmd.Parameters["@IMPORTE"].Value = IMPORTE;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }


        public void ActualizaAcuerdoDiferidoFecha(int ID_ACUERDO_DIFERIDO,  DateTime FECHA_CUMPLIMIENTO, short ID_CUMPLIDO, String CONCEPTO, String IMPORTE)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaAcuerdoDiferidoFecha", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ACUERDO_DIFERIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_ACUERDO_DIFERIDO"].Value = ID_ACUERDO_DIFERIDO;

            Cmd.Parameters.Add("@FECHA_CUMPLIMIENTO", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_CUMPLIMIENTO"].Value = FECHA_CUMPLIMIENTO;
            Cmd.Parameters.Add("@ID_CUMPLIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CUMPLIDO"].Value = ID_CUMPLIDO;
            Cmd.Parameters.Add("@CONCEPTO", SqlDbType.VarChar);
            Cmd.Parameters["@CONCEPTO"].Value = CONCEPTO;
            Cmd.Parameters.Add("@IMPORTE", SqlDbType.VarChar);
            Cmd.Parameters["@IMPORTE"].Value = IMPORTE;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void ActualizaAcuerdoDiferido(int ID_NUM_CUM_DIFERIDO, int IdSolicitante, int IdInvitado)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaAcuerdoDiferido", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_NUM_CUM_DIFERIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_NUM_CUM_DIFERIDO"].Value = ID_NUM_CUM_DIFERIDO;

            Cmd.Parameters.Add("@ID_SOLICITANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITANTE"].Value = IdSolicitante;
            Cmd.Parameters.Add("@ID_INVITADO", SqlDbType.Int);
            Cmd.Parameters["@ID_INVITADO"].Value = IdInvitado;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void ActualizaSinAcuerdo(int ID_SIN_ACUERDO, int ID_SOLICITANTE, int ID_INVITADO,short ID_UNDD_REMITE, DateTime  FECHA_REMITE)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaSinAcuerdo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_SIN_ACUERDO", SqlDbType.Int);
            Cmd.Parameters["@ID_SIN_ACUERDO"].Value = ID_SIN_ACUERDO;

            Cmd.Parameters.Add("@ID_SOLICITANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITANTE"].Value = ID_SOLICITANTE;
            Cmd.Parameters.Add("@ID_INVITADO", SqlDbType.Int);
            Cmd.Parameters["@ID_INVITADO"].Value = ID_INVITADO;
            Cmd.Parameters.Add("@ID_UNDD_REMITE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNDD_REMITE"].Value = ID_UNDD_REMITE;

            Cmd.Parameters.Add("@FECHA_REMITE", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_REMITE"].Value = FECHA_REMITE;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }


        public void InsertaAcuerdoInmediato(int ID_CARPETA, short IdMunicipio,int IdSolicitante, int IdInvitado,short IdUnidadRemite,short IdEstadoCarpeta, DateTime FECHA_CUMPLIMIENTO, String CONCEPTO, String IMPORTE, short ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaAcuerdoInmediato", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_SOLICITANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITANTE"].Value = IdSolicitante;
            Cmd.Parameters.Add("@ID_INVITADO", SqlDbType.Int);
            Cmd.Parameters["@ID_INVITADO"].Value = IdInvitado;
            Cmd.Parameters.Add("@ID_UNIDAD_REMITE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNIDAD_REMITE"].Value = IdUnidadRemite;
            Cmd.Parameters.Add("@ID_ESTADO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_CARPETA"].Value = IdEstadoCarpeta;
            Cmd.Parameters.Add("@FECHA_CUMPLIMIENTO", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_CUMPLIMIENTO"].Value = FECHA_CUMPLIMIENTO;
            Cmd.Parameters.Add("@CONCEPTO", SqlDbType.VarChar);
            Cmd.Parameters["@CONCEPTO"].Value = CONCEPTO;
            Cmd.Parameters.Add("@IMPORTE", SqlDbType.VarChar);
            Cmd.Parameters["@IMPORTE"].Value = IMPORTE;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }
        public void ActualizaAcuerdoInmediato(int ID_ACUERDO_INMEDIATO,int IdSolicitante, int IdInvitado,short IdUnidadRemite, DateTime FECHA_CUMPLIMIENTO, String CONCEPTO, String IMPORTE)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaAcuerdoInmediato", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ACUERDO_INMEDIATO", SqlDbType.Int);
            Cmd.Parameters["@ID_ACUERDO_INMEDIATO"].Value = ID_ACUERDO_INMEDIATO;
            Cmd.Parameters.Add("@ID_SOLICITANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITANTE"].Value = IdSolicitante;
            Cmd.Parameters.Add("@ID_INVITADO", SqlDbType.Int);
            Cmd.Parameters["@ID_INVITADO"].Value = IdInvitado;
            Cmd.Parameters.Add("@ID_UNIDAD_REMITE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNIDAD_REMITE"].Value = IdUnidadRemite;
            Cmd.Parameters.Add("@FECHA_CUMPLIMIENTO", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_CUMPLIMIENTO"].Value = FECHA_CUMPLIMIENTO;
            Cmd.Parameters.Add("@CONCEPTO", SqlDbType.VarChar);
            Cmd.Parameters["@CONCEPTO"].Value = CONCEPTO;
            Cmd.Parameters.Add("@IMPORTE", SqlDbType.VarChar);
            Cmd.Parameters["@IMPORTE"].Value = IMPORTE;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaMediacionAudiencia(int ID_CARPETA, DateTime FECHA_AUDIENCIA, String HORA_AUDIENCIA, short ID_TIPO_AUDIENCIA,
          int ID_DENUNCIANTE, int ID_IMPUTADO, short ID_MEDIADOR, short ID_SALA, short ID_USUARIO, short ID_MUNICIPIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaMediacionAudiencia", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@FECHA_AUDIENCIA", SqlDbType.Date);
            Cmd.Parameters["@FECHA_AUDIENCIA"].Value = FECHA_AUDIENCIA;
            Cmd.Parameters.Add("@HORA_AUDIENCIA", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_AUDIENCIA"].Value = HORA_AUDIENCIA;
            Cmd.Parameters.Add("@ID_TIPO_AUDIENCIA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_AUDIENCIA"].Value = ID_TIPO_AUDIENCIA;
            Cmd.Parameters.Add("@ID_DENUNCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENUNCIANTE"].Value = ID_DENUNCIANTE;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = ID_IMPUTADO;
            Cmd.Parameters.Add("@ID_MEDIADOR", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MEDIADOR"].Value = ID_MEDIADOR;
            Cmd.Parameters.Add("@ID_SALA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SALA"].Value = ID_SALA;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = ID_MUNICIPIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }
        
        public void ActualizaMediacionAudiencia(int ID_AUDIENCIA, DateTime FECHA_AUDIENCIA, String HORA_AUDIENCIA, short ID_TIPO_AUDIENCIA,
            int ID_DENUNCIANTE, int ID_IMPUTADO, short ID_MEDIADOR, short ID_SALA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaMediacionAudiencia", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_AUDIENCIA", SqlDbType.Int);
            Cmd.Parameters["@ID_AUDIENCIA"].Value = ID_AUDIENCIA;
            Cmd.Parameters.Add("@FECHA_AUDIENCIA", SqlDbType.Date);
            Cmd.Parameters["@FECHA_AUDIENCIA"].Value = FECHA_AUDIENCIA;
            Cmd.Parameters.Add("@HORA_AUDIENCIA", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_AUDIENCIA"].Value = HORA_AUDIENCIA;
            Cmd.Parameters.Add("@ID_TIPO_AUDIENCIA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_AUDIENCIA"].Value = ID_TIPO_AUDIENCIA;
            Cmd.Parameters.Add("@ID_DENUNCIANTE", SqlDbType.Int);
            Cmd.Parameters["@ID_DENUNCIANTE"].Value = ID_DENUNCIANTE;
            Cmd.Parameters.Add("@ID_IMPUTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_IMPUTADO"].Value = ID_IMPUTADO;
            Cmd.Parameters.Add("@ID_MEDIADOR", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MEDIADOR"].Value = ID_MEDIADOR;
            Cmd.Parameters.Add("@ID_SALA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SALA"].Value = ID_SALA;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }
        public void InsertaMedioContacto(Int32 IdPersona, short IdTipoMedioContacto, String MedioContacto, short ID_MUNICIPIO_CONTACTO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaMedioContacto", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdTipoMedioContacto", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMedioContacto"].Value = IdTipoMedioContacto;
            Cmd.Parameters.Add("@MedioContacto", SqlDbType.VarChar);
            Cmd.Parameters["@MedioContacto"].Value = MedioContacto;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CONTACTO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CONTACTO"].Value = ID_MUNICIPIO_CONTACTO;
            //Cmd.Parameters.Add("@IdMedioContacto", SqlDbType.Int);
            //Cmd.Parameters["@IdMedioContacto"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaAlias(Int32 IdPersona, String Alias, short ID_MUNICIPIO_ALIAS)
        {
            SqlCommand Cmd = new SqlCommand("InsertaAlias", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Alias", SqlDbType.VarChar);
            Cmd.Parameters["@Alias"].Value = Alias;
            Cmd.Parameters.Add("@ID_MUNICIPIO_ALIAS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_ALIAS"].Value = ID_MUNICIPIO_ALIAS;
            //Cmd.Parameters.Add("@IdAlias", SqlDbType.Int );
            //Cmd.Parameters["@IdAlias"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdAlias = Convert.ToInt32(Cmd.Parameters["@IdAlias"].Value);
            DR.Close();
        }

        public void InsertaPersonaDomicilio(int IdPersona, short IdPais, short IdEstado, short IdMunicipio, int IdLocalidad, int IdColonia, int IdCalle, int IdEntreCalle, int IdYCalle, String Numero, String Manzana, String Lote, short ID_MUNICIPIO_DOMICILIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPersonaDomicilio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@Numero", SqlDbType.VarChar);
            Cmd.Parameters["@Numero"].Value = Numero;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@ID_MUNICIPIO_DOMICILIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_DOMICILIO"].Value = ID_MUNICIPIO_DOMICILIO;
            //Cmd.Parameters.Add("@IdDomicilio", SqlDbType.Int );
            //Cmd.Parameters["@IdDomicilio"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdDomicilio = Convert.ToInt32(Cmd.Parameters["@IdDomicilio"].Value);
            DR.Close();
        }

        //public void ConsultaIdPersonaMax(String Paterno, String Materno, String Nombre)
        //{
        //    SqlCommand Cmd = new SqlCommand("consultaIdPersonaMax", Data.CnnCentral);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
        //    Cmd.Parameters["@Paterno"].Value = Paterno;
        //    Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
        //    Cmd.Parameters["@Materno"].Value = Materno;
        //    Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
        //    Cmd.Parameters["@Nombre"].Value = Nombre;

        //    SqlDataReader DR = Cmd.ExecuteReader();

        //    DR.Close();
        //}


        public void InsertaPersona(String Paterno, String Materno, String Nombre, short IdSexo, String FechaNacimiento, short IdNacionalidad, short IdPais,
            short IdEstado, short IdMunicipio, String RFC, String CURP, String Declaracion, short ID_MUNICIPIO_PERSONA)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@IdSexo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSexo"].Value = IdSexo;
            Cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar,10);
            Cmd.Parameters["@FechaNacimiento"].Value = FechaNacimiento;
            Cmd.Parameters.Add("@IdNacionalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNacionalidad"].Value = IdNacionalidad;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@RFC", SqlDbType.VarChar);
            Cmd.Parameters["@RFC"].Value = RFC;
            Cmd.Parameters.Add("@CURP", SqlDbType.VarChar);
            Cmd.Parameters["@CURP"].Value = CURP;
            Cmd.Parameters.Add("@Declaracion", SqlDbType.VarChar);
            Cmd.Parameters["@Declaracion"].Value = Declaracion;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PERSONA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PERSONA"].Value = ID_MUNICIPIO_PERSONA;
            //Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            //Cmd.Parameters["@IdPersona"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void InsertaCarpetaPersona(int IdCarpeta, int IdPersona, short IdEstadoCivil, short IdEscolaridad, short IdOcupacion, 
            short IdIdentificacion, String Folio, short LeerEscribir, short Vivo, short Detenido, short IdTipoActor,short IdMunicipioPersona, short IdPusoDisposicion)
        {
            SqlCommand Cmd = new SqlCommand("InsertaCarpetaPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdEstadoCivil", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoCivil"].Value = IdEstadoCivil;
            Cmd.Parameters.Add("@IdEscolaridad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEscolaridad"].Value = IdEscolaridad;
            Cmd.Parameters.Add("@IdOcupacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOcupacion"].Value = IdOcupacion;
            Cmd.Parameters.Add("@IdIdentificacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacion"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@Folio", SqlDbType.VarChar);
            Cmd.Parameters["@Folio"].Value = Folio;
            Cmd.Parameters.Add("@LeerEscribir", SqlDbType.Bit);
            Cmd.Parameters["@LeerEscribir"].Value = LeerEscribir;
            Cmd.Parameters.Add("@Vivo", SqlDbType.Bit);
            Cmd.Parameters["@Vivo"].Value = Vivo;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@IdTipoActor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoActor"].Value = IdTipoActor;
            Cmd.Parameters.Add("@ID_PUSO_DISPOSICION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PUSO_DISPOSICION"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PEROSNA_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PEROSNA_CARPETA"].Value = IdMunicipioPersona;
            //Cmd.Parameters.Add("@IdPersonaCarpeta", SqlDbType.Int );
            //Cmd.Parameters["@IdPersonaCarpeta"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            // IdPersonaCarpeta = Convert.ToInt32(Cmd.Parameters["@IdPersonaCarpeta"].Value);
            DR.Close();
        }

        public void InsertaDelito(int IdCarpeta, short IdDelito, short IdModalidad, short IdViolencia, short IdGrave, short IdPrincipal,int IdLugarHechos,short  IdMunicipioDelito,short IdAccion,
             int IdSujetoInterviene, int IdTipoSujetoInterviene)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDelito", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdModalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModalidad"].Value = IdModalidad;
            Cmd.Parameters.Add("@IdViolencia", SqlDbType.Bit);
            Cmd.Parameters["@IdViolencia"].Value = IdViolencia;
            Cmd.Parameters.Add("@IdGrave", SqlDbType.Bit);
            Cmd.Parameters["@IdGrave"].Value = IdGrave;
            Cmd.Parameters.Add("@IdPrincipal", SqlDbType.Bit);
            Cmd.Parameters["@IdPrincipal"].Value = IdPrincipal;
            Cmd.Parameters.Add("@IdLugarHechos", SqlDbType.Int);
            Cmd.Parameters["@IdLugarHechos"].Value = IdLugarHechos;
            Cmd.Parameters.Add("@IdMunicipioDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioDelito"].Value = IdMunicipioDelito;
            Cmd.Parameters.Add("@ID_ACCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ACCION"].Value = IdAccion;

            Cmd.Parameters.Add("@IdSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdSujetoInterviene"].Value = IdSujetoInterviene;
            Cmd.Parameters.Add("@IdTipoSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujetoInterviene"].Value = IdTipoSujetoInterviene;

            //Cmd.Parameters.Add("@IdConsecutivoDelito", SqlDbType.Int);
            //Cmd.Parameters["@IdConsecutivoDelito"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdConsecutivoDelito = Convert.ToInt32(Cmd.Parameters["@IdConsecutivoDelito"].Value);
            DR.Close();
        }

        public void InsertaRAC(String RAC, DateTime FechaRac, short IdEstadoRac, DateTime FechaEstadoRac, short IdUsuarioRac, short IdFormaInicio, short Detenido, short ID_MUNICIPIO_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRAC", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@RAC", SqlDbType.VarChar);
            Cmd.Parameters["@RAC"].Value = RAC;
            Cmd.Parameters.Add("@FechaRac", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRac"].Value = FechaRac;
            Cmd.Parameters.Add("@IdEstadoRac", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoRac"].Value = IdEstadoRac;
            Cmd.Parameters.Add("@FechaEstadoRac", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEstadoRac"].Value = FechaEstadoRac;
            Cmd.Parameters.Add("@IdUsuarioRac", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioRac"].Value = IdUsuarioRac;
            Cmd.Parameters.Add("@IdFormaInicio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaInicio"].Value = IdFormaInicio;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;
            SqlDataReader DR = Cmd.ExecuteReader();          
            DR.Close();
        }

        public void InsertaNAC(String NAC, short IdEstadoNac,  short IdUsuarioNac, short IdFormaInicio, short Detenido, short ID_MUNICIPIO_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNAC", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NAC", SqlDbType.VarChar);
            Cmd.Parameters["@NAC"].Value = NAC;
            //Cmd.Parameters.Add("@FechaNac", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaNac"].Value = FechaNac;
            Cmd.Parameters.Add("@IdEstadoNac", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoNac"].Value = IdEstadoNac;
            //Cmd.Parameters.Add("@FechaEstadoNac", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaEstadoNac"].Value = FechaEstadoNac;
            Cmd.Parameters.Add("@IdUsuarioNac", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNac"].Value = IdUsuarioNac;
            Cmd.Parameters.Add("@IdFormaInicio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaInicio"].Value = IdFormaInicio;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNUC(String NUC, DateTime FechaNuc, short IdEstadoNuc, DateTime FechaEstadoNuc, short IdUsuarioNuc, int IdCarpeta)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNUC", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NUC", SqlDbType.VarChar);
            Cmd.Parameters["@NUC"].Value = NUC;
            Cmd.Parameters.Add("@FechaNuc", SqlDbType.DateTime);
            Cmd.Parameters["@FechaNuc"].Value = FechaNuc;
            Cmd.Parameters.Add("@IdEstadoNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoNuc"].Value = IdEstadoNuc;
            Cmd.Parameters.Add("@FechaEstadoNuc", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEstadoNuc"].Value = FechaEstadoNuc;
            Cmd.Parameters.Add("@IdUsuarioNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNuc"].Value = IdUsuarioNuc;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            SqlDataReader DR = Cmd.ExecuteReader();
            // IdCarpeta = Convert.ToInt32(Cmd.Parameters["@IdCarpeta"].Value);
            DR.Close();
        }

        public void InsertaNUCUnidad(String NUC, short IdEstadoNuc, short IdUsuarioNuc, short IdFormaInicio, short Detenido, short ID_MUNICIPIO_CARPETA, short IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNUCUnidad", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NUC", SqlDbType.VarChar);
            Cmd.Parameters["@NUC"].Value = NUC;
            //Cmd.Parameters.Add("@FechaNuc", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaNuc"].Value = FechaNuc;
            Cmd.Parameters.Add("@IdEstadoNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoNuc"].Value = IdEstadoNuc;
            //Cmd.Parameters.Add("@FechaEstadoNuc", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaEstadoNuc"].Value = FechaEstadoNuc;
            Cmd.Parameters.Add("@IdUsuarioNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNuc"].Value = IdUsuarioNuc;
            Cmd.Parameters.Add("@IdFormaInicio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaInicio"].Value = IdFormaInicio;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNUM_Mediacion(String NUM, DateTime FechaNum, short IdEstadoNum, DateTime FechaEstadoNum, short IdUsuarioNum, short IdFormaInicio, short Detenido, short ID_MUNICIPIO_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNUM_Mediacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NUM", SqlDbType.VarChar);
            Cmd.Parameters["@NUm"].Value = NUM;
            Cmd.Parameters.Add("@FechaNum", SqlDbType.DateTime);
            Cmd.Parameters["@FechaNum"].Value = FechaNum;
            Cmd.Parameters.Add("@IdEstadoNum", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoNum"].Value = IdEstadoNum;
            Cmd.Parameters.Add("@FechaEstadoNum", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEstadoNum"].Value = FechaEstadoNum;
            Cmd.Parameters.Add("@IdUsuarioNum", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNum"].Value = IdUsuarioNum;
            Cmd.Parameters.Add("@IdFormaInicio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaInicio"].Value = IdFormaInicio;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;        
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdCarpeta = Convert.ToInt32(Cmd.Parameters["@IdCarpeta"].Value);
            DR.Close();
        }

        public void GenerarNC(String ID_CARPETA, String IdTipoCarpeta, short IdMunicipio, String NumeroCarpeta, String Año, short IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("GenerarNC", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.VarChar, 20);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdTipoCarpeta", SqlDbType.VarChar, 3);
            Cmd.Parameters["@IdTipoCarpeta"].Value = IdTipoCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@NumeroCarpeta", SqlDbType.VarChar, 5);
            Cmd.Parameters["@NumeroCarpeta"].Value = NumeroCarpeta;
            Cmd.Parameters.Add("@Año", SqlDbType.VarChar, 4);
            Cmd.Parameters["@Año"].Value = Año;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@NC", SqlDbType.VarChar, 20);
            Cmd.Parameters["@NC"].Direction = ParameterDirection.Output;

            SqlDataReader DR = Cmd.ExecuteReader();
            if (IdTipoCarpeta == "RAC")
            {
                RAC = Convert.ToString(Cmd.Parameters["@NC"].Value);
            }
            if (IdTipoCarpeta == "NUM")
            {
                NUM = Convert.ToString(Cmd.Parameters["@NC"].Value);
            }
            if (IdTipoCarpeta == "NUC")
            {
                NUC = Convert.ToString(Cmd.Parameters["@NC"].Value);
            }
            if (IdTipoCarpeta == "NAC")
            {
                NAC = Convert.ToString(Cmd.Parameters["@NC"].Value);
            }

            DR.Close();

        }
        //public void GenerarNC_RAC(String IdTipoCarpeta, short IdMunicipio, String NumeroCarpeta, String Año, short IdUnidad)
        //{
        //    SqlCommand Cmd = new SqlCommand("GenerarNC_RAC", Data.CnnCentral);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Cmd.Parameters.Add("@IdTipoCarpeta", SqlDbType.VarChar, 3);
        //    Cmd.Parameters["@IdTipoCarpeta"].Value = IdTipoCarpeta;
        //    Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
        //    Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
        //    Cmd.Parameters.Add("@NumeroCarpeta", SqlDbType.VarChar, 5);
        //    Cmd.Parameters["@NumeroCarpeta"].Value = NumeroCarpeta;
        //    Cmd.Parameters.Add("@Año", SqlDbType.VarChar, 4);
        //    Cmd.Parameters["@Año"].Value = Año;

        //    Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
        //    Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
        //    Cmd.Parameters.Add("@NC", SqlDbType.VarChar, 20);
        //    Cmd.Parameters["@NC"].Direction = ParameterDirection.Output;

        //    SqlDataReader DR = Cmd.ExecuteReader();
        //    if (IdTipoCarpeta == "RAC")
        //    {
        //        RAC = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    }
        //    //if (IdTipoCarpeta == "NUM")
        //    //{
        //    //    NUM = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    //}
        //    //if (IdTipoCarpeta == "NUC")
        //    //{
        //    //    NUC = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    //}
        //    //if (IdTipoCarpeta == "NAC")
        //    //{
        //    //    NAC = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    //}

        //    DR.Close();

        //}

        //public void GenerarNC_NUC(String IdTipoCarpeta, short IdMunicipio, String NumeroCarpeta, String Año, short IdUnidad)
        //{
        //    SqlCommand Cmd = new SqlCommand("GenerarNC_NUC", Data.CnnCentral);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Cmd.Parameters.Add("@IdTipoCarpeta", SqlDbType.VarChar, 3);
        //    Cmd.Parameters["@IdTipoCarpeta"].Value = IdTipoCarpeta;
        //    Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
        //    Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
        //    Cmd.Parameters.Add("@NumeroCarpeta", SqlDbType.VarChar, 5);
        //    Cmd.Parameters["@NumeroCarpeta"].Value = NumeroCarpeta;
        //    Cmd.Parameters.Add("@Año", SqlDbType.VarChar, 4);
        //    Cmd.Parameters["@Año"].Value = Año;

        //    Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
        //    Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
        //    Cmd.Parameters.Add("@NC", SqlDbType.VarChar, 20);
        //    Cmd.Parameters["@NC"].Direction = ParameterDirection.Output;

        //    SqlDataReader DR = Cmd.ExecuteReader();
        //    //if (IdTipoCarpeta == "RAC")
        //    //{
        //    //    RAC = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    //}
        //    //if (IdTipoCarpeta == "NUM")
        //    //{
        //    //    NUM = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    //}
        //    if (IdTipoCarpeta == "NUC")
        //    {
        //        NUC = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    }
        //    //if (IdTipoCarpeta == "NAC")
        //    //{
        //    //    NAC = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    //}

        //    DR.Close();

        //}

        //public void GenerarNC_NUM(String IdTipoCarpeta, short IdMunicipio, String NumeroCarpeta, String Año, short IdUnidad)
        //{
        //    SqlCommand Cmd = new SqlCommand("GenerarNC_NUM", Data.CnnCentral);
        //    Cmd.CommandType = CommandType.StoredProcedure;
        //    Cmd.Parameters.Add("@IdTipoCarpeta", SqlDbType.VarChar, 3);
        //    Cmd.Parameters["@IdTipoCarpeta"].Value = IdTipoCarpeta;
        //    Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
        //    Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
        //    Cmd.Parameters.Add("@NumeroCarpeta", SqlDbType.VarChar, 5);
        //    Cmd.Parameters["@NumeroCarpeta"].Value = NumeroCarpeta;
        //    Cmd.Parameters.Add("@Año", SqlDbType.VarChar, 4);
        //    Cmd.Parameters["@Año"].Value = Año;
        //    Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
        //    Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
        //    Cmd.Parameters.Add("@NC", SqlDbType.VarChar, 20);
        //    Cmd.Parameters["@NC"].Direction = ParameterDirection.Output;
        //    SqlDataReader DR = Cmd.ExecuteReader();
        //    if (IdTipoCarpeta == "NUM")
        //    {
        //        NUM = Convert.ToString(Cmd.Parameters["@NC"].Value);
        //    }           

        //    DR.Close();

        //}

        public void InsertaNUM(String NUM,  short IdUsuarioNum,int IdCarpeta)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNUM", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NUM", SqlDbType.VarChar);
            Cmd.Parameters["@NUM"].Value = NUM;
            //Cmd.Parameters.Add("@FechaNum", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaNum"].Value = FechaNum;
            //Cmd.Parameters.Add("@IdEstadoNum", SqlDbType.SmallInt);
            //Cmd.Parameters["@IdEstadoNum"].Value = IdEstadoNum;
            //Cmd.Parameters.Add("@FechaEstadoNum", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaEstadoNum"].Value = FechaEstadoNum;
            Cmd.Parameters.Add("@IdUsuarioNum", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNum"].Value = IdUsuarioNum;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRAC_Orientacion(String RAC, DateTime FechaRac, short IdEstadoRac, DateTime FechaEstadoRac, short IdUsuarioRac, int IdCarpeta)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRAC_Orientacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@RAC", SqlDbType.VarChar);
            Cmd.Parameters["@RAC"].Value = RAC;
            Cmd.Parameters.Add("@FechaRac", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRac"].Value = FechaRac;
            Cmd.Parameters.Add("@IdEstadoRac", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoRac"].Value = IdEstadoRac;
            Cmd.Parameters.Add("@FechaEstadoRac", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEstadoRac"].Value = FechaEstadoRac;
            Cmd.Parameters.Add("@IdUsuarioRac", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioRac"].Value = IdUsuarioRac;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


 

        public void InsertaLugarhechos(int IdCarpeta, DateTime FechaHechos, String Hora, short IdTipoLugar, short IdMunicipio, Int32 IdLocalidad, Int32 IdColonia, Int32 IdCalle, Int32 IdEntreCalle, Int32 IdYCalle, String NoExterior, String Manzana, String Lote, String Latitud, String Longitud, String Referencias, short ID_MUNICIPIO_LUGAR_HECHOS)
        {
            SqlCommand Cmd = new SqlCommand("InsertaLugarHechos", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@FechaHechos", SqlDbType.DateTime);
            Cmd.Parameters["@FechaHechos"].Value = FechaHechos;
            Cmd.Parameters.Add("@Hora", SqlDbType.VarChar);
            Cmd.Parameters["@Hora"].Value = Hora;
            Cmd.Parameters.Add("@IdTipoLugar", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoLugar"].Value = IdTipoLugar;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@NoExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NoExterior"].Value = NoExterior;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@Latitud", SqlDbType.VarChar);
            Cmd.Parameters["@Latitud"].Value = Latitud;
            Cmd.Parameters.Add("@Longitud", SqlDbType.VarChar);
            Cmd.Parameters["@Longitud"].Value = Longitud;
            Cmd.Parameters.Add("@Referencias", SqlDbType.VarChar);
            Cmd.Parameters["@Referencias"].Value = Referencias;
            Cmd.Parameters.Add("@ID_MUNICIPIO_LUGAR_HECHOS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_LUGAR_HECHOS"].Value = ID_MUNICIPIO_LUGAR_HECHOS;
            // Cmd.Parameters.Add("@IdLugarHechos", SqlDbType.Int);
            // Cmd.Parameters["@IdLugarHechos"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdLugarHechos = Convert.ToInt32(Cmd.Parameters["@IdLugarHechos"].Value);
            DR.Close();
        }

        public void InsertaDescripcionHechos(int IdCarpeta, String Descripcion, short ID_MUNICIPIO_HECHOS, String PREGUNTAS_PNL)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDescripcionHechos", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;
            Cmd.Parameters.Add("@ID_MUNICIPIO_HECHOS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_HECHOS"].Value = ID_MUNICIPIO_HECHOS;
            Cmd.Parameters.Add("@PREGUNTAS_PNL", SqlDbType.VarChar);
            Cmd.Parameters["@PREGUNTAS_PNL"].Value = PREGUNTAS_PNL;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdHechos = Convert.ToInt32(Cmd.Parameters["@IdHechos"].Value);
            DR.Close();
        }

        public void InsertaRazonAvisoDetenido(int IdCarpeta, short IdClasificaCorporacion, short IdCorporacion, String NumeroOficio, String FolioIPH, String FechaOficio)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRazonAvisoDetenido", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdClasificaCorporacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdClasificaCorporacion"].Value = IdClasificaCorporacion;
            Cmd.Parameters.Add("@IdCorporacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCorporacion"].Value = IdCorporacion;
            Cmd.Parameters.Add("@NumeroOficio", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroOficio"].Value = NumeroOficio;
            Cmd.Parameters.Add("@FechaOficio", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaOficio"].Value = FechaOficio;
            Cmd.Parameters.Add("@FolioIPH", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIPH"].Value = FolioIPH;
            //Cmd.Parameters.Add("@IdRazonAvisoDetenido", SqlDbType.Int);
            //Cmd.Parameters["@IdRazonAvisoDetenido"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdRazonAvisoDetenido = Convert.ToInt32(Cmd.Parameters["@IdRazonAvisoDetenido"].Value);
            DR.Close();
        }

        public void InsertaRazonAviso(int IdCarpeta, short IdHospital, short IdCorporacion)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRazonAviso", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdHospital", SqlDbType.SmallInt);
            Cmd.Parameters["@IdHospital"].Value = IdHospital;
            Cmd.Parameters.Add("@IdCorporacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCorporacion"].Value = IdCorporacion;
            //Cmd.Parameters.Add("@IdRazonAviso", SqlDbType.Int);
            //Cmd.Parameters["@IdRazonAviso"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            // IdRazonAviso = Convert.ToInt32(Cmd.Parameters["@IdRazonAviso"].Value);
            DR.Close();
        }



        public void ActualizaCarpetaPersona(int IdPersona, short IdEstadoCivil, short IdEscolaridad, short IdOcupacion, short IdIdentificacion, String Folio, short LeerEscribir, short Vivo, short Detenido,short IdPusoDisposicion)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaCarpetaPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdEstadoCivil", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoCivil"].Value = IdEstadoCivil;
            Cmd.Parameters.Add("@IdEscolaridad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEscolaridad"].Value = IdEscolaridad;
            Cmd.Parameters.Add("@IdOcupacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOcupacion"].Value = IdOcupacion;
            Cmd.Parameters.Add("@IdIdentificacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacion"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@Folio", SqlDbType.VarChar);
            Cmd.Parameters["@Folio"].Value = Folio;
            Cmd.Parameters.Add("@LeerEscribir", SqlDbType.Bit);
            Cmd.Parameters["@LeerEscribir"].Value = LeerEscribir;
            Cmd.Parameters.Add("@Vivo", SqlDbType.Bit);
            Cmd.Parameters["@Vivo"].Value = Vivo;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@ID_PUSO_DISPOSICION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PUSO_DISPOSICION"].Value = IdPusoDisposicion ;          
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void ActualizaPersona(int IdPersona, String Paterno, String Materno, String Nombre, short IdSexo, String FechaNacimiento,
            short IdNacionalidad, short IdPais, short IdEstado, short IdMunicipio, String RFC, String CURP,String Declaracion)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@IdSexo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSexo"].Value = IdSexo;
            Cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaNacimiento"].Value = FechaNacimiento;
            Cmd.Parameters.Add("@IdNacionalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNacionalidad"].Value = IdNacionalidad;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@RFC", SqlDbType.VarChar);
            Cmd.Parameters["@RFC"].Value = RFC;
            Cmd.Parameters.Add("@CURP", SqlDbType.VarChar);
            Cmd.Parameters["@CURP"].Value = CURP;
            Cmd.Parameters.Add("@Declaracion", SqlDbType.VarChar);
            Cmd.Parameters["@Declaracion"].Value = Declaracion;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void ActualizaPersonaDomicilio(int IdPersona, short IdPais, short IdEstado, short IdMunicipio, Int32 IdLocalidad, Int32 IdColonia, Int32 IdCalle, Int32 IdEntreCalle, Int32 IdYCalle, String Numero, String Manzana, String Lote)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaPersonaDomicilio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@Numero", SqlDbType.VarChar);
            Cmd.Parameters["@Numero"].Value = Numero;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void ActualizaAvisoDetenido(short IdClasificaCorporacion, short IdCorporacion, String NumeroOficio, String FolioIPH, int IdRazonAvisoDetenido, String FechaOficio)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaRazonAvisoDetenido", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdClasificaCorporacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdClasificaCorporacion"].Value = IdClasificaCorporacion;
            Cmd.Parameters.Add("@IdCorporacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCorporacion"].Value = IdCorporacion;
            Cmd.Parameters.Add("@NumeroOficio", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroOficio"].Value = NumeroOficio;
            Cmd.Parameters.Add("@FechaOficio", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaOficio"].Value = FechaOficio;
            Cmd.Parameters.Add("@FolioIPH", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIPH"].Value = FolioIPH;
            Cmd.Parameters.Add("@IdRazonAvisoDetenido", SqlDbType.Int);
            Cmd.Parameters["@IdRazonAvisoDetenido"].Value = IdRazonAvisoDetenido;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdRazonAvisoDetenido = Convert.ToInt32(Cmd.Parameters["@IdRazonAvisoDetenido"].Value);
            DR.Close();
        }

        public void ActualizaLugarhechos(int IdLugarHechos, DateTime FechaHechos, String Hora, short IdTipoLugar, short IdMunicipio, Int32 IdLocalidad, Int32 IdColonia, Int32 IdCalle, Int32 IdEntreCalle, Int32 IdYCalle, String NoExterior, String Manzana, String Lote, String Latitud, String Longitud, String Referencias)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaLugarHechos", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@FechaHechos", SqlDbType.DateTime);
            Cmd.Parameters["@FechaHechos"].Value = FechaHechos;
            Cmd.Parameters.Add("@Hora", SqlDbType.VarChar);
            Cmd.Parameters["@Hora"].Value = Hora;
            Cmd.Parameters.Add("@IdTipoLugar", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoLugar"].Value = IdTipoLugar;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@NoExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NoExterior"].Value = NoExterior;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@Latitud", SqlDbType.VarChar);
            Cmd.Parameters["@Latitud"].Value = Latitud;
            Cmd.Parameters.Add("@Longitud", SqlDbType.VarChar);
            Cmd.Parameters["@Longitud"].Value = Longitud;
            Cmd.Parameters.Add("@Referencias", SqlDbType.VarChar);
            Cmd.Parameters["@Referencias"].Value = Referencias;
            Cmd.Parameters.Add("@IdLugarHechos", SqlDbType.Int);
            Cmd.Parameters["@IdLugarHechos"].Value = IdLugarHechos;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdLugarHechos = Convert.ToInt32(Cmd.Parameters["@IdLugarHechos"].Value);
            DR.Close();
        }

        public void ActualizaRazonAviso(int IdRazonAviso, short IdHospital, short IdCorporacion)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaRazonAviso", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdHospital", SqlDbType.SmallInt);
            Cmd.Parameters["@IdHospital"].Value = IdHospital;
            Cmd.Parameters.Add("@IdCorporacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCorporacion"].Value = IdCorporacion;
            Cmd.Parameters.Add("@IdRazonAviso", SqlDbType.Int);
            Cmd.Parameters["@IdRazonAviso"].Value = IdRazonAviso;
            SqlDataReader DR = Cmd.ExecuteReader();
            //  IdRazonAviso = Convert.ToInt32(Cmd.Parameters["@IdRazonAviso"].Value);
            DR.Close();
        }

        public void ActualizaDescripcionHechos(int IdHechos, String Descripcion, string PREGUNTAS_PNL)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaDescripcionHechos", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;
            Cmd.Parameters.Add("@IdHechos", SqlDbType.Int);
            Cmd.Parameters["@IdHechos"].Value = IdHechos;
            Cmd.Parameters.Add("@PREGUNTAS_PNL", SqlDbType.VarChar);
            Cmd.Parameters["@PREGUNTAS_PNL"].Value = PREGUNTAS_PNL;
            SqlDataReader DR = Cmd.ExecuteReader();
            //  IdHechos = Convert.ToInt32(Cmd.Parameters["@IdHechos"].Value);
            DR.Close();
        }

        public void ActualizarAlias(int IdAlias, String Alias)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaAlias", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Alias", SqlDbType.VarChar);
            Cmd.Parameters["@Alias"].Value = Alias;
            Cmd.Parameters.Add("@IdAlias", SqlDbType.Int);
            Cmd.Parameters["@IdAlias"].Value = IdAlias;
            SqlDataReader DR = Cmd.ExecuteReader();
            // IdAlias = Convert.ToInt32(Cmd.Parameters["@IdAlias"].Value);
            DR.Close();
        }

        public void ActualizarDelito(int IdConsecutivoDelito, short IdDelito, short IdModalidad, short IdViolencia, short IdGrave, short IdPrincipal,short IdAccion,
             int IdSujetoInterviene, int IdTipoSujetoInterviene)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaDelito", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdModalidad", SqlDbType.Bit);
            Cmd.Parameters["@IdModalidad"].Value = IdModalidad;
            Cmd.Parameters.Add("@IdViolencia", SqlDbType.Bit);
            Cmd.Parameters["@IdViolencia"].Value = IdViolencia;
            Cmd.Parameters.Add("@IdGrave", SqlDbType.Bit);
            Cmd.Parameters["@IdGrave"].Value = IdGrave;
            Cmd.Parameters.Add("@IdPrincipal", SqlDbType.Bit);
            Cmd.Parameters["@IdPrincipal"].Value = IdPrincipal;
            Cmd.Parameters.Add("@IdConsecutivoDelito", SqlDbType.Int);
            Cmd.Parameters["@IdConsecutivoDelito"].Value = IdConsecutivoDelito;
            Cmd.Parameters.Add("@ID_ACCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ACCION"].Value = IdAccion ;

            Cmd.Parameters.Add("@IdSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdSujetoInterviene"].Value = IdSujetoInterviene;
            Cmd.Parameters.Add("@IdTipoSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujetoInterviene"].Value = IdTipoSujetoInterviene;


            SqlDataReader DR = Cmd.ExecuteReader();
            // IdAlias = Convert.ToInt32(Cmd.Parameters["@IdAlias"].Value);
            DR.Close();
        }

        public void ActualizarMedioContacto(int IdMedioContacto, short IdTipoMedioContacto, String MedioContacto)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaMedioContacto", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdTipoMedioContacto", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMedioContacto"].Value = IdTipoMedioContacto;
            Cmd.Parameters.Add("@MedioContacto", SqlDbType.VarChar);
            Cmd.Parameters["@MedioContacto"].Value = MedioContacto;
            Cmd.Parameters.Add("@IdMedioContacto", SqlDbType.Int);
            Cmd.Parameters["@IdMedioContacto"].Value = IdMedioContacto;
            SqlDataReader DR = Cmd.ExecuteReader();
            // IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaPlantilla(short IdTipoPlantilla, String NombrePlantilla, Byte[] Plantilla, short RAC, short NUM, short NUC, short Comparecencia, short Escrito, short RazonAviso, short ConDetenido, short SinDetenido)
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

        public void InsertaPlantillasMarcadores(int IdPlantilla, String IdMarcador, String IdProcedimiento)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPlantillasMarcadores", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int);
            Cmd.Parameters["@IdPlantilla"].Value = IdPlantilla;
            Cmd.Parameters.Add("@IdMarcador", SqlDbType.VarChar);
            Cmd.Parameters["@IdMarcador"].Value = IdMarcador;
            Cmd.Parameters.Add("@IdProcedimiento", SqlDbType.VarChar);
            Cmd.Parameters["@IdProcedimiento"].Value = IdProcedimiento;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ModificaPlantillasMarcadores(int IdPlantilla, String IdMarcador, String IdProcedimiento)
        {
            SqlCommand Cmd = new SqlCommand("ModificaPlantillasMarcadores", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPlantilla", SqlDbType.Int);
            Cmd.Parameters["@IdPlantilla"].Value = IdPlantilla;
            Cmd.Parameters.Add("@IdMarcador", SqlDbType.VarChar);
            Cmd.Parameters["@IdMarcador"].Value = IdMarcador;
            Cmd.Parameters.Add("@IdProcedimiento", SqlDbType.VarChar);
            Cmd.Parameters["@IdProcedimiento"].Value = IdProcedimiento;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaQuienResulteResponsable(String Paterno, String Materno, String Nombre, short ID_MUNICIPIO_PERSONA)
        {
            SqlCommand Cmd = new SqlCommand("InsertaQuienResulteResponsable", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PERSONA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PERSONA"].Value = ID_MUNICIPIO_PERSONA;
            //Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            //Cmd.Parameters["@IdPersona"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void InsertaQuienResulteResponsableCarpetaPersona(int IdCarpeta, int IdPersona, short IdTipoActor, short ID_MUNICIPIO_PEROSNA_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("InsertaQuienResulteResponsableCarpetaPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdTipoActor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoActor"].Value = IdTipoActor;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PEROSNA_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PEROSNA_CARPETA"].Value = ID_MUNICIPIO_PEROSNA_CARPETA;
            //Cmd.Parameters.Add("@IdPersonaCarpeta", SqlDbType.Int);
            //Cmd.Parameters["@IdPersonaCarpeta"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //    IdPersonaCarpeta = Convert.ToInt32(Cmd.Parameters["@IdPersonaCarpeta"].Value);
            DR.Close();
        }

        public void InsertaQuienResulteResponsablePersonaDomicilio(int IdPersona, short ID_MUNICIPIO_DOMICILIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaQuienResulteResponsablePersonaDomicilio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@ID_MUNICIPIO_DOMICILIO", SqlDbType.Int);
            Cmd.Parameters["@ID_MUNICIPIO_DOMICILIO"].Value = ID_MUNICIPIO_DOMICILIO;         
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaUsuario(String Usuario, String Contraseña, short IdUnidad, String Nombre, String Paterno, String Materno, String FechaBaja, short Activo, short IdPuesto, short IdModulo)
        {
            SqlCommand Cmd = new SqlCommand("InsertaUsuario", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 10);
            Cmd.Parameters["@Usuario"].Value = Usuario;
            Cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 10);
            Cmd.Parameters["@Contraseña"].Value = Contraseña;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar, 30);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar, 30);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@FechaBaja", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaBaja"].Value = FechaBaja;
            Cmd.Parameters.Add("@Activo", SqlDbType.Bit);
            Cmd.Parameters["@Activo"].Value = Activo;
            Cmd.Parameters.Add("@IdPuesto", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPuesto"].Value = IdPuesto;
            Cmd.Parameters.Add("@IdModulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModulo"].Value = IdModulo;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ActualizaUsuario(String Usuario, String Contraseña, short IdUnidad, String Nombre, String Paterno, String Materno, String FechaBaja, short Activo, short IdPuesto, short IdModulo, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaUsuario", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 10);
            Cmd.Parameters["@Usuario"].Value = Usuario;
            Cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 10);
            Cmd.Parameters["@Contraseña"].Value = Contraseña;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar, 30);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar, 30);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@FechaBaja", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaBaja"].Value = FechaBaja;
            Cmd.Parameters.Add("@Activo", SqlDbType.Bit);
            Cmd.Parameters["@Activo"].Value = Activo;
            Cmd.Parameters.Add("@IdPuesto", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPuesto"].Value = IdPuesto;
            Cmd.Parameters.Add("@IdModulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModulo"].Value = IdModulo;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaLocalidad(short IdMunicipio, short IdEstado, short IdPais, String Localidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaLocalidad", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@Localidad", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Localidad"].Value = Localidad;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaColonia(short IdLocalidad, short IdMunicipio, short IdEstado, short IdPais, String Colonia)
        {
            SqlCommand Cmd = new SqlCommand("InsertaColonia", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@Colonia", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Colonia"].Value = Colonia;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaCalle(short IdLocalidad, short IdMunicipio, short IdEstado, short IdPais, String Calle)
        {
            SqlCommand Cmd = new SqlCommand("InsertaCalle", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@Calle", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Calle"].Value = Calle;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaVehiculo(int IdCarpeta, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, short ID_MUNICIPIO_VEHICULO, String Senas, short IdTipoUso, short IdAseguradora, String NumeroMotor, String RegistroNIV)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVehiculo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.Int);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = ID_MUNICIPIO_VEHICULO;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        //inserta vehiculo, inserta vehiculo robado recuperado
        public void InsertaVehiculoRobado(int IdCarpeta, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, short ID_MUNICIPIO_VEHICULO, String Senas, short IdTipoUso, short IdAseguradora, DateTime FechaRobo, String HoraRobo, short IdEstadoVehiculo, short IdPersonaPropietario, short IdConsecutivoDelito, int IdUsuario, short IdUnidad, String NumeroMotor, String RegistroNIV)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVehiculoRobadoRecuperado", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = ID_MUNICIPIO_VEHICULO;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            //
            Cmd.Parameters.Add("@FechaRobo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRobo"].Value = FechaRobo;
            Cmd.Parameters.Add("@HoraRobo", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRobo"].Value = HoraRobo;
            //Cmd.Parameters.Add("@FechaRecuperacion", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaRecuperacion"].Value = FechaRecuperacion;
            Cmd.Parameters.Add("@IdEstadoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoVehiculo"].Value = IdEstadoVehiculo;
            Cmd.Parameters.Add("@IdPersonaPropietario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPersonaPropietario"].Value = IdPersonaPropietario;
            Cmd.Parameters.Add("@IdConsecutivoDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdConsecutivoDelito"].Value = IdConsecutivoDelito;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;

            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        //inserta vehiculo, inserta vehiculo robado recuperado datos, fecha de recuperado, depositado
        public void InsertaVehiculoRobadoRecuperado(int IdCarpeta, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, short ID_MUNICIPIO_VEHICULO, String Senas, short IdTipoUso, short IdAseguradora, DateTime FechaRobo, String HoraRobo, short IdEstadoVehiculo, short IdPersonaPropietario, short IdConsecutivoDelito, int IdUsuario, short IdUnidad, String NumeroMotor, String RegistroNIV, DateTime FechaRecuperacion, String HoraRecuperacion, short IdDepositado, DateTime FechaDepositado, String HoraDepositado)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVehiculoRobadoRecuperadoDATOSRecuperado", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = ID_MUNICIPIO_VEHICULO;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            //
            Cmd.Parameters.Add("@FechaRobo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRobo"].Value = FechaRobo;
            Cmd.Parameters.Add("@HoraRobo", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRobo"].Value = HoraRobo;
            //Cmd.Parameters.Add("@FechaRecuperacion", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaRecuperacion"].Value = FechaRecuperacion;
            Cmd.Parameters.Add("@IdEstadoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoVehiculo"].Value = IdEstadoVehiculo;
            Cmd.Parameters.Add("@IdPersonaPropietario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPersonaPropietario"].Value = IdPersonaPropietario;
            Cmd.Parameters.Add("@IdConsecutivoDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdConsecutivoDelito"].Value = IdConsecutivoDelito;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;

            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;

            Cmd.Parameters.Add("@FechaRecuperacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRecuperacion"].Value = FechaRecuperacion;
            Cmd.Parameters.Add("@HoraRecuperacion", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRecuperacion"].Value = HoraDepositado;
            Cmd.Parameters.Add("@IdDepositado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDepositado"].Value = IdDepositado;
            Cmd.Parameters.Add("@FechaDepositado", SqlDbType.DateTime);
            Cmd.Parameters["@FechaDepositado"].Value = FechaDepositado;
            Cmd.Parameters.Add("@HoraDepositado", SqlDbType.VarChar);
            Cmd.Parameters["@HoraDepositado"].Value = HoraDepositado;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ActualizaVehiculo(int IdVehiculo, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, String Senas, short IdTipoUso, short IdAseguradora, String NumeroMotor, String RegistroNIV)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaVehiculo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@IdVehiculo", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculo"].Value = IdVehiculo;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        //actualiza vehiculo, vehiculo robado 
        public void ActualizaVehiculoRobado(int IdVehiculo, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, String Senas, short IdTipoUso, short IdAseguradora, DateTime FechaRobo, String HoraRobo, short IdEstadoVehiculo, short IdPersonaPropietario, short IdUnidad, String NumeroMotor, String RegistroNIV)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaVehiculoRobadoRecuperado", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@IdVehiculo", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculo"].Value = IdVehiculo;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            //nuevos
            Cmd.Parameters.Add("@FechaRobo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRobo"].Value = FechaRobo;
            Cmd.Parameters.Add("@HoraRobo", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRobo"].Value = HoraRobo;
            Cmd.Parameters.Add("@IdEstadoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoVehiculo"].Value = IdEstadoVehiculo;
            Cmd.Parameters.Add("@IdPersonaPropietario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPersonaPropietario"].Value = IdPersonaPropietario;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        //actualiza vehiculo, vehiculo robado y recuperado, DATOS del recuperado
        public void ActualizaVehiculoRobadoRecuperado(int IdVehiculo, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, String Senas, short IdTipoUso, short IdAseguradora, DateTime FechaRobo, String HoraRobo, short IdEstadoVehiculo, short IdPersonaPropietario, short IdUnidad, String NumeroMotor, String RegistroNIV, DateTime FechaRecuperacion, String HoraRecuperacion, short IdDepositado, DateTime FechaDepositado, String HoraDepositado, short IdMunicipioVehiculo, short IdCarpeta)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaVehiculoRobadoRecuperadoDATOS", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@IdVehiculo", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculo"].Value = IdVehiculo;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            //nuevos
            Cmd.Parameters.Add("@FechaRobo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRobo"].Value = FechaRobo;
            Cmd.Parameters.Add("@HoraRobo", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRobo"].Value = HoraRobo;
            Cmd.Parameters.Add("@IdEstadoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoVehiculo"].Value = IdEstadoVehiculo;
            Cmd.Parameters.Add("@IdPersonaPropietario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPersonaPropietario"].Value = IdPersonaPropietario;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;

            Cmd.Parameters.Add("@FechaRecuperacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRecuperacion"].Value = FechaRecuperacion;
            Cmd.Parameters.Add("@HoraRecuperacion", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRecuperacion"].Value = HoraRecuperacion;
            Cmd.Parameters.Add("@IdDepositado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDepositado"].Value = IdDepositado;
            Cmd.Parameters.Add("@FechaDepositado", SqlDbType.DateTime);
            Cmd.Parameters["@FechaDepositado"].Value = FechaDepositado;
            Cmd.Parameters.Add("@HoraDepositado", SqlDbType.VarChar);
            Cmd.Parameters["@HoraDepositado"].Value = HoraDepositado;
            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarDetencionDatos(int ID_PERSONA, int ID_USUARIO, int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_LUGAR_DETENCION, string FOLIO, string MOTIVO_DETENCION, string TIEMPO_TRANSLADO, string LUGAR_PUESTA_DISPOSICION, string AUTORIDAD_PUESTO_DISPOSICION, string NOMBRE_RECIBIO, string CARGO_RECIBIO, string CAUSA_NO_FIRMA, string HORA_DETENCION, DateTime FECHA_DETENCION, short ID_PREFERENCIA_SEXUAL, short ID_ESTADO_DETENIDO, Byte[] FOTO_DETENIDO,
                                     string ASUNTO, string DIRIGIDO_A, string AGENTES, short ID_PARTICIPACION, short OPERATIVO, string NOMBRE_COMANDANTE, string DESCRIPCION_HECHOS, string REFERENCIA_UBICACION, short DETENIDO_POR, short ID_PROCEDIMIENTO_DETENCION, short ID_SUPUESTO_FLAGRANCIA, short LIBERTAD_INVESTIGACION, short ID_MOTIVO_LIBERACION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_LUGAR_DETENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_LUGAR_DETENCION"].Value = ID_LUGAR_DETENCION;

            Cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar);
            Cmd.Parameters["@FOLIO"].Value = FOLIO;

            Cmd.Parameters.Add("@MOTIVO_DETENCION", SqlDbType.VarChar);
            Cmd.Parameters["@MOTIVO_DETENCION"].Value = MOTIVO_DETENCION;

            Cmd.Parameters.Add("@TIEMPO_TRANSLADO", SqlDbType.VarChar);
            Cmd.Parameters["@TIEMPO_TRANSLADO"].Value = TIEMPO_TRANSLADO;

            Cmd.Parameters.Add("@LUGAR_PUESTA_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@LUGAR_PUESTA_DISPOSICION"].Value = LUGAR_PUESTA_DISPOSICION;

            Cmd.Parameters.Add("@AUTORIDAD_PUESTO_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@AUTORIDAD_PUESTO_DISPOSICION"].Value = AUTORIDAD_PUESTO_DISPOSICION;

            Cmd.Parameters.Add("@NOMBRE_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_RECIBIO"].Value = NOMBRE_RECIBIO;

            Cmd.Parameters.Add("@CARGO_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@CARGO_RECIBIO"].Value = CARGO_RECIBIO;

            Cmd.Parameters.Add("@CAUSA_NO_FIRMA", SqlDbType.VarChar);
            Cmd.Parameters["@CAUSA_NO_FIRMA"].Value = CAUSA_NO_FIRMA;

            Cmd.Parameters.Add("@HORA_DETENCION", SqlDbType.VarChar, 8);
            Cmd.Parameters["@HORA_DETENCION"].Value = HORA_DETENCION;

            Cmd.Parameters.Add("@FECHA_DETENCION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_DETENCION"].Value = FECHA_DETENCION;

            Cmd.Parameters.Add("@ID_PREFERENCIA_SEXUAL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PREFERENCIA_SEXUAL"].Value = ID_PREFERENCIA_SEXUAL;

            Cmd.Parameters.Add("@ID_ESTADO_DETENIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_DETENIDO"].Value = ID_ESTADO_DETENIDO;

            Cmd.Parameters.Add("@FOTO_DETENIDO", SqlDbType.Image);
            Cmd.Parameters["@FOTO_DETENIDO"].Value = FOTO_DETENIDO;

            Cmd.Parameters.Add("@ASUNTO", SqlDbType.VarChar);
            Cmd.Parameters["@ASUNTO"].Value = ASUNTO;

            Cmd.Parameters.Add("@DIRIGIDO_A", SqlDbType.VarChar);
            Cmd.Parameters["@DIRIGIDO_A"].Value = DIRIGIDO_A;

            Cmd.Parameters.Add("@AGENTES", SqlDbType.VarChar);
            Cmd.Parameters["@AGENTES"].Value = AGENTES;

            Cmd.Parameters.Add("@ID_PARTICIPACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PARTICIPACION"].Value = ID_PARTICIPACION;

            Cmd.Parameters.Add("@OPERATIVO", SqlDbType.SmallInt);
            Cmd.Parameters["@OPERATIVO"].Value = OPERATIVO;

            Cmd.Parameters.Add("@NOMBRE_COMANDANTE", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_COMANDANTE"].Value = NOMBRE_COMANDANTE;

            Cmd.Parameters.Add("@DESCRIPCION_HECHOS", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_HECHOS"].Value = DESCRIPCION_HECHOS;

            Cmd.Parameters.Add("@REFERENCIA_UBICACION", SqlDbType.VarChar);
            Cmd.Parameters["@REFERENCIA_UBICACION"].Value = REFERENCIA_UBICACION;

            Cmd.Parameters.Add("@DETENIDO_POR", SqlDbType.SmallInt);
            Cmd.Parameters["@DETENIDO_POR"].Value = DETENIDO_POR;



            Cmd.Parameters.Add("@ID_PROCEDIMIENTO_DETENCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PROCEDIMIENTO_DETENCION"].Value = ID_PROCEDIMIENTO_DETENCION;

            Cmd.Parameters.Add("@ID_SUPUESTO_FLAGRANCIA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUPUESTO_FLAGRANCIA"].Value = ID_SUPUESTO_FLAGRANCIA;

            Cmd.Parameters.Add("@LIBERTAD_INVESTIGACION", SqlDbType.SmallInt);
            Cmd.Parameters["@LIBERTAD_INVESTIGACION"].Value = LIBERTAD_INVESTIGACION;

            Cmd.Parameters.Add("@ID_MOTIVO_LIBERACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOTIVO_LIBERACION"].Value = ID_MOTIVO_LIBERACION;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ModificarDetencionDatos(int ID_DETENCION, string MOTIVO_DETENCION, string TIEMPO_TRANSLADO, string LUGAR_PUESTA_DISPOSICION, string AUTORIDAD_PUESTO_DISPOSICION, string NOMBRE_RECIBIO, string CARGO_RECIBIO, string CAUSA_NO_FIRMA, string HORA_DETENCION, DateTime FECHA_DETENCION, short ID_PREFERENCIA_SEXUAL, short ID_ESTADO_DETENIDO,
                                     string ASUNTO, string DIRIGIDO_A, string AGENTES, short ID_PARTICIPACION, short OPERATIVO, string NOMBRE_COMANDANTE, string DESCRIPCION_HECHOS, string REFERENCIA_UBICACION, short DETENIDO_POR, short ID_PROCEDIMIENTO_DETENCION, short ID_SUPUESTO_FLAGRANCIA, short LIBERTAD_INVESTIGACION, short ID_MOTIVO_LIBERACION)
        {
            SqlCommand Cmd = new SqlCommand("ModificarDetencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_DETENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_DETENCION"].Value = ID_DETENCION;

            Cmd.Parameters.Add("@MOTIVO_DETENCION", SqlDbType.VarChar);
            Cmd.Parameters["@MOTIVO_DETENCION"].Value = MOTIVO_DETENCION;

            Cmd.Parameters.Add("@TIEMPO_TRANSLADO", SqlDbType.VarChar);
            Cmd.Parameters["@TIEMPO_TRANSLADO"].Value = TIEMPO_TRANSLADO;

            Cmd.Parameters.Add("@LUGAR_PUESTA_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@LUGAR_PUESTA_DISPOSICION"].Value = LUGAR_PUESTA_DISPOSICION;

            Cmd.Parameters.Add("@AUTORIDAD_PUESTO_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@AUTORIDAD_PUESTO_DISPOSICION"].Value = AUTORIDAD_PUESTO_DISPOSICION;

            Cmd.Parameters.Add("@NOMBRE_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_RECIBIO"].Value = NOMBRE_RECIBIO;

            Cmd.Parameters.Add("@CARGO_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@CARGO_RECIBIO"].Value = CARGO_RECIBIO;

            Cmd.Parameters.Add("@CAUSA_NO_FIRMA", SqlDbType.VarChar);
            Cmd.Parameters["@CAUSA_NO_FIRMA"].Value = CAUSA_NO_FIRMA;

            Cmd.Parameters.Add("@HORA_DETENCION", SqlDbType.VarChar, 8);
            Cmd.Parameters["@HORA_DETENCION"].Value = HORA_DETENCION;

            Cmd.Parameters.Add("@FECHA_DETENCION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_DETENCION"].Value = FECHA_DETENCION;

            Cmd.Parameters.Add("@ID_PREFERENCIA_SEXUAL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PREFERENCIA_SEXUAL"].Value = ID_PREFERENCIA_SEXUAL;

            Cmd.Parameters.Add("@ID_ESTADO_DETENIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_DETENIDO"].Value = ID_ESTADO_DETENIDO;

            Cmd.Parameters.Add("@ASUNTO", SqlDbType.VarChar);
            Cmd.Parameters["@ASUNTO"].Value = ASUNTO;

            Cmd.Parameters.Add("@DIRIGIDO_A", SqlDbType.VarChar);
            Cmd.Parameters["@DIRIGIDO_A"].Value = DIRIGIDO_A;

            Cmd.Parameters.Add("@AGENTES", SqlDbType.VarChar);
            Cmd.Parameters["@AGENTES"].Value = AGENTES;

            Cmd.Parameters.Add("@ID_PARTICIPACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PARTICIPACION"].Value = ID_PARTICIPACION;

            Cmd.Parameters.Add("@OPERATIVO", SqlDbType.SmallInt);
            Cmd.Parameters["@OPERATIVO"].Value = OPERATIVO;

            Cmd.Parameters.Add("@NOMBRE_COMANDANTE", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_COMANDANTE"].Value = NOMBRE_COMANDANTE;

            Cmd.Parameters.Add("@DESCRIPCION_HECHOS", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_HECHOS"].Value = DESCRIPCION_HECHOS;

            Cmd.Parameters.Add("@REFERENCIA_UBICACION", SqlDbType.VarChar);
            Cmd.Parameters["@REFERENCIA_UBICACION"].Value = REFERENCIA_UBICACION;

            Cmd.Parameters.Add("@DETENIDO_POR", SqlDbType.SmallInt);
            Cmd.Parameters["@DETENIDO_POR"].Value = DETENIDO_POR;

            Cmd.Parameters.Add("@ID_PROCEDIMIENTO_DETENCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PROCEDIMIENTO_DETENCION"].Value = ID_PROCEDIMIENTO_DETENCION;

            Cmd.Parameters.Add("@ID_SUPUESTO_FLAGRANCIA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUPUESTO_FLAGRANCIA"].Value = ID_SUPUESTO_FLAGRANCIA;

            Cmd.Parameters.Add("@LIBERTAD_INVESTIGACION", SqlDbType.SmallInt);
            Cmd.Parameters["@LIBERTAD_INVESTIGACION"].Value = LIBERTAD_INVESTIGACION;

            Cmd.Parameters.Add("@ID_MOTIVO_LIBERACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOTIVO_LIBERACION"].Value = ID_MOTIVO_LIBERACION;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void InsertaLugarDetencion(int IdCarpeta, DateTime FechaHechos, String Hora, short IdTipoLugar, short IdMunicipio, Int32 IdLocalidad, Int32 IdColonia, Int32 IdCalle, Int32 IdEntreCalle, Int32 IdYCalle, String NoExterior, String Manzana, String Lote, String Latitud, String Longitud, String Referencias, short ID_MUNICIPIO_LUGAR_DETENCION)
        {
            SqlCommand Cmd = new SqlCommand("InsertaLugarDetencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@FechaHechos", SqlDbType.DateTime);
            Cmd.Parameters["@FechaHechos"].Value = FechaHechos;
            Cmd.Parameters.Add("@Hora", SqlDbType.VarChar);
            Cmd.Parameters["@Hora"].Value = Hora;
            Cmd.Parameters.Add("@IdTipoLugar", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoLugar"].Value = IdTipoLugar;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@NoExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NoExterior"].Value = NoExterior;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@Latitud", SqlDbType.VarChar);
            Cmd.Parameters["@Latitud"].Value = Latitud;
            Cmd.Parameters.Add("@Longitud", SqlDbType.VarChar);
            Cmd.Parameters["@Longitud"].Value = Longitud;
            Cmd.Parameters.Add("@Referencias", SqlDbType.VarChar);
            Cmd.Parameters["@Referencias"].Value = Referencias;
            Cmd.Parameters.Add("@ID_MUNICIPIO_LUGAR_DETENCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_LUGAR_DETENCION"].Value = ID_MUNICIPIO_LUGAR_DETENCION;
            // Cmd.Parameters.Add("@IdLugarHechos", SqlDbType.Int);
            // Cmd.Parameters["@IdLugarHechos"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdLugarHechos = Convert.ToInt32(Cmd.Parameters["@IdLugarHechos"].Value);
            DR.Close();
        }

        public void ActualizaPusoDisposicionCarpetaPersona(short ID_PUSO_DISPOSICION, int ID_PERSONA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaPusoDisposicionCarpetaPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PUSO_DISPOSICION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PUSO_DISPOSICION"].Value = ID_PUSO_DISPOSICION;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ActualizaLugarDetencion(int IdLugarDetencion, DateTime FechaHechos, String Hora, short IdTipoLugar, short IdMunicipio, Int32 IdLocalidad, Int32 IdColonia, Int32 IdCalle, Int32 IdEntreCalle, Int32 IdYCalle, String NoExterior, String Manzana, String Lote, String Latitud, String Longitud, String Referencias)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaLugarDetencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@FechaHechos", SqlDbType.DateTime);
            Cmd.Parameters["@FechaHechos"].Value = FechaHechos;
            Cmd.Parameters.Add("@Hora", SqlDbType.VarChar);
            Cmd.Parameters["@Hora"].Value = Hora;
            Cmd.Parameters.Add("@IdTipoLugar", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoLugar"].Value = IdTipoLugar;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@NoExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NoExterior"].Value = NoExterior;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@Latitud", SqlDbType.VarChar);
            Cmd.Parameters["@Latitud"].Value = Latitud;
            Cmd.Parameters.Add("@Longitud", SqlDbType.VarChar);
            Cmd.Parameters["@Longitud"].Value = Longitud;
            Cmd.Parameters.Add("@Referencias", SqlDbType.VarChar);
            Cmd.Parameters["@Referencias"].Value = Referencias;
            Cmd.Parameters.Add("@IdLugarDetencion", SqlDbType.Int);
            Cmd.Parameters["@IdLugarDetencion"].Value = IdLugarDetencion;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdLugarHechos = Convert.ToInt32(Cmd.Parameters["@IdLugarHechos"].Value);
            DR.Close();
        }

        public void InsertarHomicidio(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_PERSONA_OFENDIDO, int ID_PERSONA_IMPUTADO, int ID_LUGAR_HECHOS, short ID_TIPO_PERSONA_OFENDIDO, short ID_TIPO_PERSONA_IMPUTADO, short ID_ORGANIZACION_IMPUTADO, short ID_MOVIL, short ID_SUB_DELITO, short ID_SITUACION, short ID_SUB_MODALIDAD)
        {
            SqlCommand Cmd = new SqlCommand("InsertarHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_OFENDIDO"].Value = ID_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_PERSONA_IMPUTADO ", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_IMPUTADO "].Value = ID_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_LUGAR_HECHOS", SqlDbType.Int);
            Cmd.Parameters["@ID_LUGAR_HECHOS"].Value = ID_LUGAR_HECHOS;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_OFENDIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_OFENDIDO"].Value = ID_TIPO_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_IMPUTADO"].Value = ID_TIPO_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_ORGANIZACION_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ORGANIZACION_IMPUTADO"].Value = ID_ORGANIZACION_IMPUTADO;

            Cmd.Parameters.Add("@ID_MOVIL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOVIL"].Value = ID_MOVIL;

            Cmd.Parameters.Add("@ID_SUB_DELITO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUB_DELITO"].Value = ID_SUB_DELITO;

            Cmd.Parameters.Add("@ID_SITUACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SITUACION"].Value = ID_SITUACION;

            Cmd.Parameters.Add("@ID_SUB_MODALIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUB_MODALIDAD"].Value = ID_SUB_MODALIDAD;



            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ModificarHomicidio(int ID_HOMICIDIO, int ID_CARPETA, short ID_TIPO_PERSONA_OFENDIDO, short ID_TIPO_PERSONA_IMPUTADO, short ID_ORGANIZACION_IMPUTADO, short ID_MOVIL, short ID_SUB_DELITO, short ID_SITUACION, short ID_SUB_MODALIDAD)
        {
            SqlCommand Cmd = new SqlCommand("ModificarHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;


            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_OFENDIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_OFENDIDO"].Value = ID_TIPO_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_IMPUTADO"].Value = ID_TIPO_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_ORGANIZACION_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ORGANIZACION_IMPUTADO"].Value = ID_ORGANIZACION_IMPUTADO;

            Cmd.Parameters.Add("@ID_MOVIL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOVIL"].Value = ID_MOVIL;

            Cmd.Parameters.Add("@ID_SUB_DELITO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUB_DELITO"].Value = ID_SUB_DELITO;

            Cmd.Parameters.Add("@ID_SITUACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SITUACION"].Value = ID_SITUACION;

            Cmd.Parameters.Add("@ID_SUB_MODALIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUB_MODALIDAD"].Value = ID_SUB_MODALIDAD;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarCadaverHomicidio(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_PERSONA, short ID_VIOLENCIA, short ID_CDVR_CAUSA, short ID_CDVR_CNSRVCION, short ID_CDVR_ORIENTACION, short ID_CDVR_PSCION, DateTime FECHA_MUERTE, string HORA_MUERTE, DateTime FECHA_IDENTIFICACION, string HORA_IDENTIFIACION, short CUERPO_ENTREGADO, string NOMBRE_ENTREGA_CUERPO, short PARENTESCO, short FOSA_COMUN, string DESCRIPCION_CADAVER, DateTime FECHA_ENTREGA, string DATOS_FOSA, string PARTES_CUERPO, Byte[] IDENTIFICACION, string RESGUARDO_CADAVER)
        {
            SqlCommand Cmd = new SqlCommand("InsertarCadaverHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_VIOLENCIA ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_VIOLENCIA "].Value = ID_VIOLENCIA;

            Cmd.Parameters.Add("@ID_CDVR_CAUSA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CAUSA"].Value = ID_CDVR_CAUSA;

            Cmd.Parameters.Add("@ID_CDVR_CNSRVCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CNSRVCION"].Value = ID_CDVR_CNSRVCION;

            Cmd.Parameters.Add("@ID_CDVR_ORIENTACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_ORIENTACION"].Value = ID_CDVR_ORIENTACION;

            Cmd.Parameters.Add("@ID_CDVR_PSCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_PSCION"].Value = ID_CDVR_PSCION;

            Cmd.Parameters.Add("@FECHA_MUERTE", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_MUERTE"].Value = FECHA_MUERTE;

            Cmd.Parameters.Add("@HORA_MUERTE", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_MUERTE"].Value = HORA_MUERTE;

            Cmd.Parameters.Add("@FECHA_IDENTIFICACION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_IDENTIFICACION"].Value = FECHA_IDENTIFICACION;

            Cmd.Parameters.Add("@HORA_IDENTIFIACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_IDENTIFIACION"].Value = HORA_IDENTIFIACION;

            Cmd.Parameters.Add("@CUERPO_ENTREGADO", SqlDbType.TinyInt);
            Cmd.Parameters["@CUERPO_ENTREGADO"].Value = CUERPO_ENTREGADO;

            Cmd.Parameters.Add("@NOMBRE_ENTREGA_CUERPO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_ENTREGA_CUERPO"].Value = NOMBRE_ENTREGA_CUERPO;

            Cmd.Parameters.Add("@PARENTESCO", SqlDbType.SmallInt);
            Cmd.Parameters["@PARENTESCO"].Value = PARENTESCO;

            Cmd.Parameters.Add("@FOSA_COMUN", SqlDbType.Bit);
            Cmd.Parameters["@FOSA_COMUN"].Value = FOSA_COMUN;

            Cmd.Parameters.Add("@DESCRIPCION_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_CADAVER"].Value = DESCRIPCION_CADAVER;

            Cmd.Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_ENTREGA"].Value = FECHA_ENTREGA;

            Cmd.Parameters.Add("@DATOS_FOSA", SqlDbType.VarChar);
            Cmd.Parameters["@DATOS_FOSA"].Value = DATOS_FOSA;

            Cmd.Parameters.Add("@PARTES_CUERPO", SqlDbType.VarChar);
            Cmd.Parameters["@PARTES_CUERPO"].Value = PARTES_CUERPO;

            Cmd.Parameters.Add("@IDENTIFICACION", SqlDbType.Image);
            Cmd.Parameters["@IDENTIFICACION"].Value = IDENTIFICACION;

            Cmd.Parameters.Add("@RESGUARDO_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@RESGUARDO_CADAVER"].Value = RESGUARDO_CADAVER;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ModificarCadaverHomicidio(int ID_CARPETA, int ID_PERSONA, short ID_VIOLENCIA, short ID_CDVR_CAUSA, short ID_CDVR_CNSRVCION, short ID_CDVR_ORIENTACION, short ID_CDVR_PSCION, DateTime FECHA_MUERTE, string HORA_MUERTE, DateTime FECHA_IDENTIFICACION, string HORA_IDENTIFIACION, short CUERPO_ENTREGADO, string NOMBRE_ENTREGA_CUERPO, short PARENTESCO, short FOSA_COMUN, string DESCRIPCION_CADAVER, DateTime FECHA_ENTREGA, string DATOS_FOSA, string PARTES_CUERPO, string RESGUARDO_CADAVER)
        {
            SqlCommand Cmd = new SqlCommand("ModificarCadaverHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;


            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_VIOLENCIA ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_VIOLENCIA "].Value = ID_VIOLENCIA;

            Cmd.Parameters.Add("@ID_CDVR_CAUSA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CAUSA"].Value = ID_CDVR_CAUSA;

            Cmd.Parameters.Add("@ID_CDVR_CNSRVCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CNSRVCION"].Value = ID_CDVR_CNSRVCION;

            Cmd.Parameters.Add("@ID_CDVR_ORIENTACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_ORIENTACION"].Value = ID_CDVR_ORIENTACION;

            Cmd.Parameters.Add("@ID_CDVR_PSCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_PSCION"].Value = ID_CDVR_PSCION;

            Cmd.Parameters.Add("@FECHA_MUERTE", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_MUERTE"].Value = FECHA_MUERTE;

            Cmd.Parameters.Add("@HORA_MUERTE", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_MUERTE"].Value = HORA_MUERTE;

            Cmd.Parameters.Add("@FECHA_IDENTIFICACION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_IDENTIFICACION"].Value = FECHA_IDENTIFICACION;

            Cmd.Parameters.Add("@HORA_IDENTIFIACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_IDENTIFIACION"].Value = HORA_IDENTIFIACION;

            Cmd.Parameters.Add("@CUERPO_ENTREGADO", SqlDbType.TinyInt);
            Cmd.Parameters["@CUERPO_ENTREGADO"].Value = CUERPO_ENTREGADO;

            Cmd.Parameters.Add("@NOMBRE_ENTREGA_CUERPO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_ENTREGA_CUERPO"].Value = NOMBRE_ENTREGA_CUERPO;

            Cmd.Parameters.Add("@PARENTESCO", SqlDbType.SmallInt);
            Cmd.Parameters["@PARENTESCO"].Value = PARENTESCO;

            Cmd.Parameters.Add("@FOSA_COMUN", SqlDbType.Bit);
            Cmd.Parameters["@FOSA_COMUN"].Value = FOSA_COMUN;

            Cmd.Parameters.Add("@DESCRIPCION_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_CADAVER"].Value = DESCRIPCION_CADAVER;

            Cmd.Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_ENTREGA"].Value = FECHA_ENTREGA;

            Cmd.Parameters.Add("@DATOS_FOSA", SqlDbType.VarChar);
            Cmd.Parameters["@DATOS_FOSA"].Value = DATOS_FOSA;

            Cmd.Parameters.Add("@PARTES_CUERPO", SqlDbType.Text);
            Cmd.Parameters["@PARTES_CUERPO"].Value = PARTES_CUERPO;

            Cmd.Parameters.Add("@RESGUARDO_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@RESGUARDO_CADAVER"].Value = RESGUARDO_CADAVER;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaAutorizacion(int IdCarpeta, int IdMunicipio, int IdVehiculo, int IdUsuario, string Autorizacion)
        {
            SqlCommand Cmd = new SqlCommand("insertaAutorizacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdVehiculo", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculo"].Value = IdVehiculo;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@Autorizacion", SqlDbType.VarChar);
            Cmd.Parameters["@Autorizacion"].Value = Autorizacion;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }
        public void InsertaEmpresa(int IdCarpeta, String Nombre,String Domicilio,String RFC, 
            String EscrituraPublica, String NoEscritura, String Otro, String Especificar, short IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("InsertaEmpresa", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar);
            Cmd.Parameters["@NOMBRE"].Value = Nombre;
            Cmd.Parameters.Add("@DOMICILIO", SqlDbType.NVarChar);
            Cmd.Parameters["@DOMICILIO"].Value = Domicilio;
            Cmd.Parameters.Add("@RFC", SqlDbType.VarChar);
            Cmd.Parameters["@RFC"].Value = RFC;
            Cmd.Parameters.Add("@ESCRITURA_PRUBLICA", SqlDbType.VarChar);
            Cmd.Parameters["@ESCRITURA_PRUBLICA"].Value = EscrituraPublica;
            Cmd.Parameters.Add("@NO_ESCRITURA", SqlDbType.VarChar);
            Cmd.Parameters["@NO_ESCRITURA"].Value = NoEscritura;
            Cmd.Parameters.Add("@OTRO", SqlDbType.VarChar);
            Cmd.Parameters["@OTRO"].Value = Otro;
            Cmd.Parameters.Add("@ESPECIFICAR", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFICAR"].Value = Especificar;
            Cmd.Parameters.Add("@ID_MUNICIPIO_EMPRESA", SqlDbType.SmallInt );
            Cmd.Parameters["@ID_MUNICIPIO_EMPRESA"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void AcutalizaEmpresa(int CONSECUTIVO_EMPRESA, String Nombre, String Domicilio, String RFC,
            String EscrituraPublica, String NoEscritura, String Otro, String Especificar)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaEmpresa", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@CONSECUTIVO_EMPRESA", SqlDbType.Int);
            Cmd.Parameters["@CONSECUTIVO_EMPRESA"].Value = CONSECUTIVO_EMPRESA;
            Cmd.Parameters.Add("@NOMBRE", SqlDbType.NVarChar);
            Cmd.Parameters["@NOMBRE"].Value = Nombre;
            Cmd.Parameters.Add("@DOMICILIO", SqlDbType.NVarChar);
            Cmd.Parameters["@DOMICILIO"].Value = Domicilio;
            Cmd.Parameters.Add("@RFC", SqlDbType.VarChar);
            Cmd.Parameters["@RFC"].Value = RFC;
            Cmd.Parameters.Add("@ESCRITURA_PRUBLICA", SqlDbType.VarChar);
            Cmd.Parameters["@ESCRITURA_PRUBLICA"].Value = EscrituraPublica;
            Cmd.Parameters.Add("@NO_ESCRITURA", SqlDbType.VarChar);
            Cmd.Parameters["@NO_ESCRITURA"].Value = NoEscritura;
            Cmd.Parameters.Add("@OTRO", SqlDbType.VarChar);
            Cmd.Parameters["@OTRO"].Value = Otro;
            Cmd.Parameters.Add("@ESPECIFICAR", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFICAR"].Value = Especificar;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }
       
        public void InsertaDefensor(int IdCarpeta, int IdPersona, String Paterno, String Materno, String Nombre, short DefensorPubPriv, short IdTipoActor, short IdIdentificacion, String Folio, String Telefono, short IdNacionalidad, short IdPaisOrigen, short IdEstadoOrigen, short IdMunicipioOrigen, short IdPais, short IdEstado, short IdMunicipio, int IdLocalidad, int IdColonia, int IdCalle, int IdEntreCalle, int IdYCalle, String Numero, String Manzana, String Lote, short ID_MUNICIPIO_DEFENSOR)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDefensor", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Defensor_Pub_Priv", SqlDbType.SmallInt);
            Cmd.Parameters["@Defensor_Pub_Priv"].Value = DefensorPubPriv;
            Cmd.Parameters.Add("@IdTipoActor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoActor"].Value = IdTipoActor;
            Cmd.Parameters.Add("@ID_IDENTIFICACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_IDENTIFICACION"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@FOLIO"].Value = Folio;
            Cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@TELEFONO"].Value = Telefono;
            Cmd.Parameters.Add("@ID_NACIONALIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_NACIONALIDAD"].Value = IdNacionalidad;
            Cmd.Parameters.Add("@ID_PAIS_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PAIS_ORIGEN"].Value = IdPaisOrigen;
            Cmd.Parameters.Add("@ID_ESTADO_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_ORIGEN"].Value = IdEstadoOrigen;
            Cmd.Parameters.Add("@ID_MUNICIPIO_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_ORIGEN"].Value = IdMunicipioOrigen;
            Cmd.Parameters.Add("@Id_Pais", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Pais"].Value = IdPais;
            Cmd.Parameters.Add("@Id_Estado", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Estado"].Value = IdEstado;
            Cmd.Parameters.Add("@Id_Municipio", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Municipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Id_Localidad", SqlDbType.Int);
            Cmd.Parameters["@Id_Localidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@Id_Colonia", SqlDbType.Int);
            Cmd.Parameters["@Id_Colonia"].Value = IdColonia;
            Cmd.Parameters.Add("@Id_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Calle"].Value = IdCalle;
            Cmd.Parameters.Add("@Id_Entre_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Entre_Calle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@Id_Y_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Y_Calle"].Value = IdYCalle;
            Cmd.Parameters.Add("@Numero", SqlDbType.VarChar);
            Cmd.Parameters["@Numero"].Value = Numero;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@ID_MUNICIPIO_DEFENSOR", SqlDbType.SmallInt );
            Cmd.Parameters["@ID_MUNICIPIO_DEFENSOR"].Value = ID_MUNICIPIO_DEFENSOR;           
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ActualizaDefensor(int IdDefensor, String Paterno, String Materno, String Nombre, short DefensorPubPriv,short IdIdentificacion,String Folio,String Telefono, short IdNacionalidad, short IdPaisOrigen, short IdEstadoOrigen, short IdMunicipioOrigen, short IdPais, short IdEstado, short IdMunicipio, int IdLocalidad, int IdColonia, int IdCalle, int IdEntreCalle, int IdYCalle, String Numero, String Manzana, String Lote)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaDefensor", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDefensor", SqlDbType.Int);
            Cmd.Parameters["@IdDefensor"].Value = IdDefensor;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Defensor_Pub_Priv", SqlDbType.SmallInt);
            Cmd.Parameters["@Defensor_Pub_Priv"].Value = DefensorPubPriv;
            Cmd.Parameters.Add("@ID_IDENTIFICACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_IDENTIFICACION"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@FOLIO"].Value = Folio;
            Cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@TELEFONO"].Value = Telefono;
            Cmd.Parameters.Add("@ID_NACIONALIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_NACIONALIDAD"].Value = IdNacionalidad;
            Cmd.Parameters.Add("@ID_PAIS_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PAIS_ORIGEN"].Value = IdPaisOrigen;
            Cmd.Parameters.Add("@ID_ESTADO_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_ORIGEN"].Value = IdEstadoOrigen;
            Cmd.Parameters.Add("@ID_MUNICIPIO_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_ORIGEN"].Value = IdMunicipioOrigen;
            Cmd.Parameters.Add("@Id_Pais", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Pais"].Value = IdPais;
            Cmd.Parameters.Add("@Id_Estado", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Estado"].Value = IdEstado;
            Cmd.Parameters.Add("@Id_Municipio", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Municipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Id_Localidad", SqlDbType.Int);
            Cmd.Parameters["@Id_Localidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@Id_Colonia", SqlDbType.Int);
            Cmd.Parameters["@Id_Colonia"].Value = IdColonia;
            Cmd.Parameters.Add("@Id_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Calle"].Value = IdCalle;
            Cmd.Parameters.Add("@Id_Entre_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Entre_Calle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@Id_Y_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Y_Calle"].Value = IdYCalle;
            Cmd.Parameters.Add("@Numero", SqlDbType.VarChar);
            Cmd.Parameters["@Numero"].Value = Numero;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDefensorTorre(int IdCarpeta, String Nuc, int IdPersona, int IdMunicipio, int IdUnidad)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDefensorTorre", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Id_Carpeta", SqlDbType.Int);
            Cmd.Parameters["@Id_Carpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NUC", SqlDbType.VarChar, 20);
            Cmd.Parameters["@NUC"].Value = Nuc;
            Cmd.Parameters.Add("@Id_persona", SqlDbType.Int);
            Cmd.Parameters["@Id_persona"].Value = IdPersona;
            Cmd.Parameters.Add("@Id_Municipio", SqlDbType.Int);
            Cmd.Parameters["@Id_Municipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Id_Unidad", SqlDbType.Int);
            Cmd.Parameters["@Id_Unidad"].Value = IdUnidad;
           SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

   

        public void InsertaIPH(String FolioIPH, String OficioIPH, DateTime FechaEventoIPH,   //  String HoraEventoIPH, 
            String AsuntoDTIPH, String DirigidoDTIPH,
            String AgentesDTIPH, short OperativoIPH, /*   chblParticipacionDT_IPH   */   String NomComanDTIPH, String TipoEvenMotIPH, short TipoArmaAAIPH,
            String DescAAIPH, short ArmasAAIPH, String MarcaAAIPH, String TipoAAIPH, String CalibreAAIPH, String MatriculaAAIPH, String SerieAAIPH,
            String TipoDAIPH, String UnidadMedidaDAIPH, String CantidadDAIPH, String ObservaDAIPH, String TipoObjetoOOAIPH, String CantidadOOAIPH, String DescOOAIPH,
            /* chblTipoInfoComple_IPH */ String DescICEIPH, String FechaDictamenICEIPH, /*Dictamen medico*/ String ObservaGeneraInfoIPH)
       //String Contraseña, short IdUnidad, String Nombre, String Paterno, String Materno, String FechaBaja, short Activo, short IdPuesto, short IdModulo)
        {
            SqlCommand Cmd = new SqlCommand("InsertaIPH", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FOLIO"].Value = FolioIPH;
            Cmd.Parameters.Add("@NOOFICIO", SqlDbType.VarChar, 10);
            Cmd.Parameters["@NOOFICIO"].Value = OficioIPH;
            Cmd.Parameters.Add("@FECHAEVENTO", SqlDbType.DateTime);
            Cmd.Parameters["@FECHAEVENTO"].Value = FechaEventoIPH;
            //Cmd.Parameters.Add("@HoraEventoIPH", SqlDbType.VarChar, 30);
            //Cmd.Parameters["@HoraEventoIPH"].Value = HoraEventoIPH;
            Cmd.Parameters.Add("@ASUNTO", SqlDbType.VarChar, 30);
            Cmd.Parameters["@ASUNTO"].Value = AsuntoDTIPH;
            Cmd.Parameters.Add("@DirigidoDTIPH", SqlDbType.VarChar, 30);
            Cmd.Parameters["@DirigidoDTIPH"].Value = DirigidoDTIPH;
            Cmd.Parameters.Add("@AgentesDTIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@AgentesDTIPH"].Value = AgentesDTIPH;
            Cmd.Parameters.Add("@OperativoIPH", SqlDbType.Bit);
            Cmd.Parameters["@OperativoIPH"].Value = OperativoIPH;
            Cmd.Parameters.Add("@NomComanDTIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@NomComanDTIPH"].Value = NomComanDTIPH;
            Cmd.Parameters.Add("@TipoEvenMotIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoEvenMotIPH"].Value = TipoEvenMotIPH;
            Cmd.Parameters.Add("@TipoArmaAAIPH", SqlDbType.Bit);
            Cmd.Parameters["@TipoArmaAAIPH"].Value = TipoArmaAAIPH;
            Cmd.Parameters.Add("@DescAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@DescAAIPH"].Value = DescAAIPH;
            Cmd.Parameters.Add("@ArmasAAIPH", SqlDbType.Bit);
            Cmd.Parameters["@ArmasAAIPH"].Value = ArmasAAIPH;
            Cmd.Parameters.Add("@MarcaAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@MarcaAAIPH"].Value = MarcaAAIPH;
            Cmd.Parameters.Add("@TipoAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoAAIPH"].Value = TipoAAIPH;
            Cmd.Parameters.Add("@CalibreAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@CalibreAAIPH"].Value = CalibreAAIPH;
            Cmd.Parameters.Add("@MatriculaAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@MatriculaAAIPH"].Value = MatriculaAAIPH;
            Cmd.Parameters.Add("@SerieAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@SerieAAIPH"].Value = SerieAAIPH;
            Cmd.Parameters.Add("@TipoDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoDAIPH"].Value = TipoDAIPH;
            Cmd.Parameters.Add("@UnidadMedidaDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@UnidadMedidaDAIPH"].Value = UnidadMedidaDAIPH;
            Cmd.Parameters.Add("@CantidadDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@CantidadDAIPH"].Value = CantidadDAIPH;
            Cmd.Parameters.Add("@ObservaDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@ObservaDAIPH"].Value = ObservaDAIPH;
            Cmd.Parameters.Add("@TipoObjetoOOAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoObjetoOOAIPH"].Value = TipoObjetoOOAIPH;
            Cmd.Parameters.Add("@CantidadOOAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@CantidadOOAIPH"].Value = CantidadOOAIPH;
            Cmd.Parameters.Add("@DescOOA_IPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@DescOOA_IPH"].Value = DescOOAIPH;
            Cmd.Parameters.Add("@DescICEIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@DescICEIPH"].Value = DescICEIPH;
            Cmd.Parameters.Add("@FechaDictamenICEIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaDictamenICEIPH"].Value = FechaDictamenICEIPH;
            Cmd.Parameters.Add("@ObservaGeneraInfoIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@ObservaGeneraInfoIPH"].Value = ObservaGeneraInfoIPH;
           SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ActualizaIPH(String FolioIPH, String OficioIPH, String FechaEventoIPH, String HoraEventoIPH, String AsuntoDTIPH, String DirigidoDTIPH,
            String AgentesDTIPH, short OperativoIPH, /*   chblParticipacionDT_IPH   */   String NomComanDTIPH, String TipoEvenMotIPH, short TipoArmaAAIPH,
            String DescAAIPH, short ArmasAAIPH, String MarcaAAIPH, String TipoAAIPH, String CalibreAAIPH, String MatriculaAAIPH, String SerieAAIPH,
            String TipoDAIPH, String UnidadMedidaDAIPH, String CantidadDAIPH, String ObservaDAIPH, String TipoObjetoOOAIPH, String CantidadOOAIPH, String DescOOAIPH,
            /* chblTipoInfoComple_IPH */ String DescICEIPH, String FechaDictamenICEIPH, /*Dictamen medico*/ String ObservaGeneraInfoIPH, int idIPH)
//        public void ActualizaIPH(String Usuario, String Contraseña, short IdUnidad, String Nombre, String Paterno, String Materno, String FechaBaja, short Activo, short IdPuesto, short IdModulo, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaIPH", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@FolioIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FolioIPH"].Value = FolioIPH;
            Cmd.Parameters.Add("@OficioIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@OficioIPH"].Value = OficioIPH;
            Cmd.Parameters.Add("@FechaEventoIPH", SqlDbType.SmallInt);
            Cmd.Parameters["@FechaEventoIPH"].Value = FechaEventoIPH;
            Cmd.Parameters.Add("@HoraEventoIPH", SqlDbType.VarChar, 30);
            Cmd.Parameters["@HoraEventoIPH"].Value = HoraEventoIPH;
            Cmd.Parameters.Add("@AsuntoDTIPH", SqlDbType.VarChar, 30);
            Cmd.Parameters["@AsuntoDTIPH"].Value = AsuntoDTIPH;
            Cmd.Parameters.Add("@DirigidoDTIPH", SqlDbType.VarChar, 30);
            Cmd.Parameters["@DirigidoDTIPH"].Value = DirigidoDTIPH;
            Cmd.Parameters.Add("@AgentesDTIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@AgentesDTIPH"].Value = AgentesDTIPH;
            Cmd.Parameters.Add("@OperativoIPH", SqlDbType.Bit);
            Cmd.Parameters["@OperativoIPH"].Value = OperativoIPH;
            Cmd.Parameters.Add("@NomComanDTIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@NomComanDTIPH"].Value = NomComanDTIPH;
            Cmd.Parameters.Add("@TipoEvenMotIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoEvenMotIPH"].Value = TipoEvenMotIPH;
            Cmd.Parameters.Add("@TipoArmaAAIPH", SqlDbType.Bit);
            Cmd.Parameters["@TipoArmaAAIPH"].Value = TipoArmaAAIPH;
            Cmd.Parameters.Add("@DescAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@DescAAIPH"].Value = DescAAIPH;
            Cmd.Parameters.Add("@ArmasAAIPH", SqlDbType.Bit);
            Cmd.Parameters["@ArmasAAIPH"].Value = ArmasAAIPH;
            Cmd.Parameters.Add("@MarcaAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@MarcaAAIPH"].Value = MarcaAAIPH;
            Cmd.Parameters.Add("@TipoAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoAAIPH"].Value = TipoAAIPH;
            Cmd.Parameters.Add("@CalibreAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@CalibreAAIPH"].Value = CalibreAAIPH;
            Cmd.Parameters.Add("@MatriculaAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@MatriculaAAIPH"].Value = MatriculaAAIPH;
            Cmd.Parameters.Add("@SerieAAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@SerieAAIPH"].Value = SerieAAIPH;
            Cmd.Parameters.Add("@TipoDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoDAIPH"].Value = TipoDAIPH;
            Cmd.Parameters.Add("@UnidadMedidaDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@UnidadMedidaDAIPH"].Value = UnidadMedidaDAIPH;
            Cmd.Parameters.Add("@CantidadDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@CantidadDAIPH"].Value = CantidadDAIPH;
            Cmd.Parameters.Add("@ObservaDAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@ObservaDAIPH"].Value = ObservaDAIPH;
            Cmd.Parameters.Add("@TipoObjetoOOAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@TipoObjetoOOAIPH"].Value = TipoObjetoOOAIPH;
            Cmd.Parameters.Add("@CantidadOOAIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@CantidadOOAIPH"].Value = CantidadOOAIPH;
            Cmd.Parameters.Add("@DescOOA_IPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@DescOOA_IPH"].Value = DescOOAIPH;
            Cmd.Parameters.Add("@DescICEIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@DescICEIPH"].Value = DescICEIPH;
            Cmd.Parameters.Add("@FechaDictamenICEIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaDictamenICEIPH"].Value = FechaDictamenICEIPH;
            Cmd.Parameters.Add("@ObservaGeneraInfoIPH", SqlDbType.VarChar, 10);
            Cmd.Parameters["@ObservaGeneraInfoIPH"].Value = ObservaGeneraInfoIPH;
            Cmd.Parameters.Add("@idIPH", SqlDbType.Int);
            Cmd.Parameters["@idIPH"].Value = idIPH;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDenuncianteAutoridad(int ID_CARPETA, short IdMunicipio, short ID_PUSO_DISPOSICION, String NUMERO_OFICIO, short ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDenuncianteAutoridad", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_PUSO_DISPOSICION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PUSO_DISPOSICION"].Value = ID_PUSO_DISPOSICION;
            Cmd.Parameters.Add("@NUMERO_OFICIO", SqlDbType.VarChar);
            Cmd.Parameters["@NUMERO_OFICIO"].Value = NUMERO_OFICIO;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void ActualizaDenuncianteAutoridad(int ID_DENUNCIANTE_AUTORIDAD, short ID_PUSO_DISPOSICION, String NUMERO_OFICIO, short ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("ModificarDenuncianteAutoridad", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_DENUNCIANTE_AUTORIDAD", SqlDbType.Int);
            Cmd.Parameters["@ID_DENUNCIANTE_AUTORIDAD"].Value = ID_DENUNCIANTE_AUTORIDAD;
            Cmd.Parameters.Add("@ID_PUSO_DISPOSICION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PUSO_DISPOSICION"].Value = ID_PUSO_DISPOSICION;
            Cmd.Parameters.Add("@NUMERO_OFICIO", SqlDbType.VarChar);
            Cmd.Parameters["@NUMERO_OFICIO"].Value = NUMERO_OFICIO;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }




        /********************************************************INICIO DE MÓDULO DE SECUESTROS************************************************** */

        #region

        public void InsertaDatosPrincSec(int ID_CARPETA, int ID_PERSONA, int ID_MUNICIPIO_CARPETA, int ID_ETAPA_ATENCION, int ID_ESTATUS_SECUESTRO, int ID_TIPO_SECUESTRO, DateTime FECHA_PRIVACION, string HORA_PRIVACION, short AMENAZA_MUERTE, bool ALTO_IMPACTO, bool DELINCUENCIA_ORG, bool ANIOS_ANTERIORES, bool OTROS_ESTADOS, bool MIGRANTES, bool AUTO_SECUESTRO, bool ROBO_VEHICULO, bool PNL, bool SECUESTRO_TENTATIVA, bool SUBSTRACCION_MENORES)
        {

            SqlCommand Cmd = new SqlCommand("InsertaDatosPrincSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_ETAPA_ATENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_ETAPA_ATENCION"].Value = ID_ETAPA_ATENCION;

            Cmd.Parameters.Add("@ID_ESTATUS_SECUESTRO", SqlDbType.Int);
            Cmd.Parameters["@ID_ESTATUS_SECUESTRO"].Value = ID_ESTATUS_SECUESTRO;

            Cmd.Parameters.Add("@ID_TIPO_SECUESTRO", SqlDbType.Int);
            Cmd.Parameters["@ID_TIPO_SECUESTRO"].Value = ID_TIPO_SECUESTRO;

            Cmd.Parameters.Add("@FECHA_PRIVACION", SqlDbType.Date);
            Cmd.Parameters["@FECHA_PRIVACION"].Value = FECHA_PRIVACION;

            Cmd.Parameters.Add("@HORA_PRIVACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_PRIVACION"].Value = HORA_PRIVACION;

            Cmd.Parameters.Add("@AMENAZA_MUERTE", SqlDbType.SmallInt);
            Cmd.Parameters["@AMENAZA_MUERTE"].Value = AMENAZA_MUERTE;

            Cmd.Parameters.Add("@ALTO_IMPACTO", SqlDbType.Bit);
            Cmd.Parameters["@ALTO_IMPACTO"].Value = ALTO_IMPACTO;

            Cmd.Parameters.Add("@DELINCUENCIA_ORG", SqlDbType.Bit);
            Cmd.Parameters["@DELINCUENCIA_ORG"].Value = DELINCUENCIA_ORG;

            Cmd.Parameters.Add("@ANIOS_ANTERIORES", SqlDbType.Bit);
            Cmd.Parameters["@ANIOS_ANTERIORES"].Value = ANIOS_ANTERIORES;

            Cmd.Parameters.Add("@OTROS_ESTADOS", SqlDbType.Bit);
            Cmd.Parameters["@OTROS_ESTADOS"].Value = OTROS_ESTADOS;

            Cmd.Parameters.Add("@MIGRANTES", SqlDbType.Bit);
            Cmd.Parameters["@MIGRANTES"].Value = MIGRANTES;

            Cmd.Parameters.Add("@AUTO_SECUESTRO", SqlDbType.Bit);
            Cmd.Parameters["@AUTO_SECUESTRO"].Value = AUTO_SECUESTRO;

            Cmd.Parameters.Add("@ROBO_VEHICULO", SqlDbType.Bit);
            Cmd.Parameters["@ROBO_VEHICULO"].Value = ROBO_VEHICULO;

            Cmd.Parameters.Add("@PNL", SqlDbType.Bit);
            Cmd.Parameters["@PNL"].Value = PNL;

            Cmd.Parameters.Add("@SECUESTRO_TENTATIVA", SqlDbType.Bit);
            Cmd.Parameters["@SECUESTRO_TENTATIVA"].Value = SECUESTRO_TENTATIVA;

            Cmd.Parameters.Add("@SUBSTRACCION_MENORES", SqlDbType.Bit);
            Cmd.Parameters["@SUBSTRACCION_MENORES"].Value = SUBSTRACCION_MENORES;
                                    
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        
        }

        public void ActualizaDatosPrincSec(int ID_PRINC_SEC, int ID_ETAPA_ATENCION, int ID_ESTATUS_SECUESTRO, int ID_TIPO_SECUESTRO, DateTime FECHA_PRIVACION, string HORA_PRIVACION, short AMENAZA_MUERTE, bool ALTO_IMPACTO, bool DELINCUENCIA_ORG, bool ANIOS_ANTERIORES, bool OTROS_ESTADOS, bool MIGRANTES, bool AUTO_SECUESTRO, bool ROBO_VEHICULO, bool PNL, bool SECUESTRO_TENTATIVA, bool SUBSTRACCION_MENORES)
        {

            SqlCommand Cmd = new SqlCommand("ActualizaDatosPrincSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PRINC_SEC", SqlDbType.Int);
            Cmd.Parameters["@ID_PRINC_SEC"].Value = ID_PRINC_SEC;
            
            Cmd.Parameters.Add("@ID_ETAPA_ATENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_ETAPA_ATENCION"].Value = ID_ETAPA_ATENCION;

            Cmd.Parameters.Add("@ID_ESTATUS_SECUESTRO", SqlDbType.Int);
            Cmd.Parameters["@ID_ESTATUS_SECUESTRO"].Value = ID_ESTATUS_SECUESTRO;

            Cmd.Parameters.Add("@ID_TIPO_SECUESTRO", SqlDbType.Int);
            Cmd.Parameters["@ID_TIPO_SECUESTRO"].Value = ID_TIPO_SECUESTRO;

            Cmd.Parameters.Add("@FECHA_PRIVACION", SqlDbType.Date);
            Cmd.Parameters["@FECHA_PRIVACION"].Value = FECHA_PRIVACION;

            Cmd.Parameters.Add("@HORA_PRIVACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_PRIVACION"].Value = HORA_PRIVACION;

            Cmd.Parameters.Add("@AMENAZA_MUERTE", SqlDbType.SmallInt);
            Cmd.Parameters["@AMENAZA_MUERTE"].Value = AMENAZA_MUERTE;

            Cmd.Parameters.Add("@ALTO_IMPACTO", SqlDbType.Bit);
            Cmd.Parameters["@ALTO_IMPACTO"].Value = ALTO_IMPACTO;

            Cmd.Parameters.Add("@DELINCUENCIA_ORG", SqlDbType.Bit);
            Cmd.Parameters["@DELINCUENCIA_ORG"].Value = DELINCUENCIA_ORG;

            Cmd.Parameters.Add("@ANIOS_ANTERIORES", SqlDbType.Bit);
            Cmd.Parameters["@ANIOS_ANTERIORES"].Value = ANIOS_ANTERIORES;

            Cmd.Parameters.Add("@OTROS_ESTADOS", SqlDbType.Bit);
            Cmd.Parameters["@OTROS_ESTADOS"].Value = OTROS_ESTADOS;

            Cmd.Parameters.Add("@MIGRANTES", SqlDbType.Bit);
            Cmd.Parameters["@MIGRANTES"].Value = MIGRANTES;

            Cmd.Parameters.Add("@AUTO_SECUESTRO", SqlDbType.Bit);
            Cmd.Parameters["@AUTO_SECUESTRO"].Value = AUTO_SECUESTRO;

            Cmd.Parameters.Add("@ROBO_VEHICULO", SqlDbType.Bit);
            Cmd.Parameters["@ROBO_VEHICULO"].Value = ROBO_VEHICULO;

            Cmd.Parameters.Add("@PNL", SqlDbType.Bit);
            Cmd.Parameters["@PNL"].Value = PNL;

            Cmd.Parameters.Add("@SECUESTRO_TENTATIVA", SqlDbType.Bit);
            Cmd.Parameters["@SECUESTRO_TENTATIVA"].Value = SECUESTRO_TENTATIVA;

            Cmd.Parameters.Add("@SUBSTRACCION_MENORES", SqlDbType.Bit);
            Cmd.Parameters["@SUBSTRACCION_MENORES"].Value = SUBSTRACCION_MENORES;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }


        public void InsertaProfugoSec(int ID_CARPETA, int ID_MUNICIPIO_CARPETA, string NOMBRE, string PATERNO, string MATERNO, string ALIAS)
        {


            SqlCommand Cmd = new SqlCommand("InsertaProfugoSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
                       
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;
                       
            Cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE"].Value = NOMBRE;

            Cmd.Parameters.Add("@MATERNO", SqlDbType.VarChar);
            Cmd.Parameters["@MATERNO"].Value = MATERNO;

            Cmd.Parameters.Add("@PATERNO", SqlDbType.VarChar);
            Cmd.Parameters["@PATERNO"].Value = PATERNO;

            Cmd.Parameters.Add("@ALIAS", SqlDbType.VarChar);
            Cmd.Parameters["@ALIAS"].Value = ALIAS;
            

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        
        }

        public void ActualizaProfugoSec(int ID_PROFUGO_SEC,string NOMBRE, string PATERNO, string MATERNO, string ALIAS)
        {

            SqlCommand Cmd = new SqlCommand("ActualizaProfugoSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PROFUGO_SEC", SqlDbType.Int);
            Cmd.Parameters["@ID_PROFUGO_SEC"].Value = ID_PROFUGO_SEC;
                      

            Cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE"].Value = NOMBRE;

            Cmd.Parameters.Add("@MATERNO", SqlDbType.VarChar);
            Cmd.Parameters["@MATERNO"].Value = MATERNO;

            Cmd.Parameters.Add("@PATERNO", SqlDbType.VarChar);
            Cmd.Parameters["@PATERNO"].Value = PATERNO;

            Cmd.Parameters.Add("@ALIAS", SqlDbType.VarChar);
            Cmd.Parameters["@ALIAS"].Value = ALIAS;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void InsertaNegocSec(int ID_PERSONA, int ID_CARPETA, int ID_MUNICIPIO_CARPETA, DateTime FECHA_NEGOC, string HORA_NEGOC, int PESOS_EXIG, int DOLARES_EXIG, string ESPECIE_EXIG, int PESOS_PAG, int DOLARES_PAG, string ESPECIE_PAG, DateTime FECHA_PAGO, string HORA_PAGO)
        {


            SqlCommand Cmd = new SqlCommand("InsertaNegocSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;


            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@FECHA_NEGOC", SqlDbType.Date);
            Cmd.Parameters["@FECHA_NEGOC"].Value = FECHA_NEGOC;

            Cmd.Parameters.Add("@HORA_NEGOC", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_NEGOC"].Value = HORA_NEGOC;

            Cmd.Parameters.Add("@PESOS_EXIG", SqlDbType.Int);
            Cmd.Parameters["@PESOS_EXIG"].Value = PESOS_EXIG;

            Cmd.Parameters.Add("@DOLARES_EXIG", SqlDbType.Int);
            Cmd.Parameters["@DOLARES_EXIG"].Value = DOLARES_EXIG;

            Cmd.Parameters.Add("@ESPECIE_EXIG", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIE_EXIG"].Value = ESPECIE_EXIG;

            Cmd.Parameters.Add("@PESOS_PAG", SqlDbType.Int);
            Cmd.Parameters["@PESOS_PAG"].Value = PESOS_PAG;

            Cmd.Parameters.Add("@DOLARES_PAG", SqlDbType.Int);
            Cmd.Parameters["@DOLARES_PAG"].Value = DOLARES_PAG;

            Cmd.Parameters.Add("@ESPECIE_PAG", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIE_PAG"].Value = ESPECIE_PAG;

            Cmd.Parameters.Add("@FECHA_PAGO", SqlDbType.Date);
            Cmd.Parameters["@FECHA_PAGO"].Value = FECHA_PAGO;

            Cmd.Parameters.Add("@HORA_PAGO", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_PAGO"].Value = HORA_PAGO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        
        }

        public void ActualizaNegocSec(int ID_NEGOC_SEC,DateTime FECHA_NEGOC, string HORA_NEGOC, int PESOS_EXIG, int DOLARES_EXIG, string ESPECIE_EXIG, int PESOS_PAG, int DOLARES_PAG, string ESPECIE_PAG, DateTime FECHA_PAGO, string HORA_PAGO)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaNegocSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

           
            Cmd.Parameters.Add("@ID_NEGOC_SEC", SqlDbType.Int);
            Cmd.Parameters["@ID_NEGOC_SEC"].Value = ID_NEGOC_SEC;

            Cmd.Parameters.Add("@FECHA_NEGOC", SqlDbType.Date);
            Cmd.Parameters["@FECHA_NEGOC"].Value = FECHA_NEGOC;

            Cmd.Parameters.Add("@HORA_NEGOC", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_NEGOC"].Value = HORA_NEGOC;

            Cmd.Parameters.Add("@PESOS_EXIG", SqlDbType.Int);
            Cmd.Parameters["@PESOS_EXIG"].Value = PESOS_EXIG;

            Cmd.Parameters.Add("@DOLARES_EXIG", SqlDbType.Int);
            Cmd.Parameters["@DOLARES_EXIG"].Value = DOLARES_EXIG;

            Cmd.Parameters.Add("@ESPECIE_EXIG", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIE_EXIG"].Value = ESPECIE_EXIG;

            Cmd.Parameters.Add("@PESOS_PAG", SqlDbType.Int);
            Cmd.Parameters["@PESOS_PAG"].Value = PESOS_PAG;

            Cmd.Parameters.Add("@DOLARES_PAG", SqlDbType.Int);
            Cmd.Parameters["@DOLARES_PAG"].Value = DOLARES_PAG;

            Cmd.Parameters.Add("@ESPECIE_PAG", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIE_PAG"].Value = ESPECIE_PAG;

            Cmd.Parameters.Add("@FECHA_PAGO", SqlDbType.Date);
            Cmd.Parameters["@FECHA_PAGO"].Value = FECHA_PAGO;

            Cmd.Parameters.Add("@HORA_PAGO", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_PAGO"].Value = HORA_PAGO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void InsertaLiberacionSec(int ID_CARPETA, int ID_PERSONA, short ID_MUNICIPIO_CARPETA, short ID_CORPORACION, int ID_METODO_LIBERACION,int DURACION_SEC, DateTime FECHA_LIBERACION, string HORA_LIBERACION,short ID_PAIS, short ID_ESTADO, short ID_MNCPIO, short ID_LCLDD, short ID_CLNIA, int ID_CALLE, int ID_ENTRE_CALLE, int ID_Y_CALLE, string NUMERO, string MANZANA, string LOTE, int ID_LGR_TPO, short VIVO_O_MUERTO, int ID_CONDICIONES_LOC)
        {

            SqlCommand Cmd = new SqlCommand("InsertaLiberacionSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_CORPORACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CORPORACION"].Value = ID_CORPORACION;

            Cmd.Parameters.Add("@ID_METODO_LIBERACION", SqlDbType.Int);
            Cmd.Parameters["@ID_METODO_LIBERACION"].Value = ID_METODO_LIBERACION;

            Cmd.Parameters.Add("@DURACION_SEC", SqlDbType.Int);
            Cmd.Parameters["@DURACION_SEC"].Value = DURACION_SEC;

            Cmd.Parameters.Add("@FECHA_LIBERACION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_LIBERACION"].Value = FECHA_LIBERACION;

            Cmd.Parameters.Add("@HORA_LIBERACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_LIBERACION"].Value = HORA_LIBERACION;

            Cmd.Parameters.Add("@ID_PAIS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PAIS"].Value = ID_PAIS;


            Cmd.Parameters.Add("@ID_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO"].Value = ID_ESTADO;

            Cmd.Parameters.Add("@ID_MNCPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MNCPIO"].Value = ID_MNCPIO;

            Cmd.Parameters.Add("@ID_LCLDD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_LCLDD"].Value = ID_LCLDD;

             Cmd.Parameters.Add("@ID_CLNIA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CLNIA"].Value = ID_CLNIA;

             Cmd.Parameters.Add("@ID_CLLE", SqlDbType.Int);
            Cmd.Parameters["@ID_CLLE"].Value = ID_CALLE;

             Cmd.Parameters.Add("@ID_ENTRE_CALLE", SqlDbType.Int);
            Cmd.Parameters["@ID_ENTRE_CALLE"].Value = ID_ENTRE_CALLE;

             Cmd.Parameters.Add("@ID_Y_CALLE", SqlDbType.Int);
            Cmd.Parameters["@ID_Y_CALLE"].Value = ID_Y_CALLE;

            Cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar);
            Cmd.Parameters["@NUMERO"].Value = NUMERO;

            Cmd.Parameters.Add("@MANZANA", SqlDbType.VarChar);
            Cmd.Parameters["@MANZANA"].Value = MANZANA;

            Cmd.Parameters.Add("@LOTE", SqlDbType.VarChar);
            Cmd.Parameters["@LOTE"].Value = LOTE;
                                    
            
                      

            Cmd.Parameters.Add("@ID_LGR_TPO", SqlDbType.Int);
            Cmd.Parameters["@ID_LGR_TPO"].Value = ID_LGR_TPO;

            Cmd.Parameters.Add("@VIVO_O_MUERTO", SqlDbType.SmallInt);
            Cmd.Parameters["@VIVO_O_MUERTO"].Value = VIVO_O_MUERTO;

            Cmd.Parameters.Add("@ID_CONDICIONES_LOC", SqlDbType.Int);
            Cmd.Parameters["@ID_CONDICIONES_LOC"].Value = ID_CONDICIONES_LOC;


          

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ActualizaLiberacionSec(int ID_LIB_SEC, short ID_CORPORACION, int ID_METODO_LIBERACION, int DURACION_SEC, DateTime FECHA_LIBERACION, string HORA_LIBERACION,short ID_PAIS, short ID_ESTADO, short ID_MNCPIO, short ID_LCLDD, short ID_CLNIA, int ID_CALLE, int ID_ENTRE_CALLE, int ID_Y_CALLE, string NUMERO, string MANZANA, string LOTE, int ID_LGR_TPO, short VIVO_O_MUERTO, int ID_CONDICIONES_LOC)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaLiberacionSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@ID_LIB_SEC", SqlDbType.Int);
            Cmd.Parameters["@ID_LIB_SEC"].Value = ID_LIB_SEC;

            Cmd.Parameters.Add("@ID_CORPORACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CORPORACION"].Value = ID_CORPORACION;

            Cmd.Parameters.Add("@ID_METODO_LIBERACION", SqlDbType.Int);
            Cmd.Parameters["@ID_METODO_LIBERACION"].Value = ID_METODO_LIBERACION;

            Cmd.Parameters.Add("@DURACION_SEC", SqlDbType.Int);
            Cmd.Parameters["@DURACION_SEC"].Value = DURACION_SEC;

            Cmd.Parameters.Add("@FECHA_LIBERACION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_LIBERACION"].Value = FECHA_LIBERACION;

            Cmd.Parameters.Add("@HORA_LIBERACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_LIBERACION"].Value = HORA_LIBERACION;

            Cmd.Parameters.Add("@ID_PAIS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PAIS"].Value = ID_PAIS;


            Cmd.Parameters.Add("@ID_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO"].Value = ID_ESTADO;

            Cmd.Parameters.Add("@ID_MNCPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MNCPIO"].Value = ID_MNCPIO;

            Cmd.Parameters.Add("@ID_LCLDD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_LCLDD"].Value = ID_LCLDD;

            Cmd.Parameters.Add("@ID_CLNIA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CLNIA"].Value = ID_CLNIA;

            Cmd.Parameters.Add("@ID_CLLE", SqlDbType.Int);
            Cmd.Parameters["@ID_CLLE"].Value = ID_CALLE;

            Cmd.Parameters.Add("@ID_ENTRE_CALLE", SqlDbType.Int);
            Cmd.Parameters["@ID_ENTRE_CALLE"].Value = ID_ENTRE_CALLE;

            Cmd.Parameters.Add("@ID_Y_CALLE", SqlDbType.Int);
            Cmd.Parameters["@ID_Y_CALLE"].Value = ID_Y_CALLE;

            Cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar);
            Cmd.Parameters["@NUMERO"].Value = NUMERO;

            Cmd.Parameters.Add("@MANZANA", SqlDbType.VarChar);
            Cmd.Parameters["@MANZANA"].Value = MANZANA;

            Cmd.Parameters.Add("@LOTE", SqlDbType.VarChar);
            Cmd.Parameters["@LOTE"].Value = LOTE;




            Cmd.Parameters.Add("@ID_LGR_TPO", SqlDbType.Int);
            Cmd.Parameters["@ID_LGR_TPO"].Value = ID_LGR_TPO;

            Cmd.Parameters.Add("@VIVO_O_MUERTO", SqlDbType.SmallInt);
            Cmd.Parameters["@VIVO_O_MUERTO"].Value = VIVO_O_MUERTO;

            Cmd.Parameters.Add("@ID_CONDICIONES_LOC", SqlDbType.Int);
            Cmd.Parameters["@ID_CONDICIONES_LOC"].Value = ID_CONDICIONES_LOC;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertaBandaSec(int ID_CARPETA, int ID_MUNICIPIO_CARPETA, string NOMBRE_BANDA, string BIENES_ASEGURADOS)
        {

            SqlCommand Cmd = new SqlCommand("InsertaBandaSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;
           
            Cmd.Parameters.Add("@NOMBRE_BANDA", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_BANDA"].Value = NOMBRE_BANDA;

            Cmd.Parameters.Add("@BIENES_ASEGURADOS", SqlDbType.VarChar);
            Cmd.Parameters["@BIENES_ASEGURADOS"].Value = BIENES_ASEGURADOS;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ActualizaBandaSec(int ID_BANDA_DES, string NOMBRE_BANDA, string BIENES_ASEGURADOS)
        {
            SqlCommand Cmd = new SqlCommand("ActualizaBandaSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_BANDA_DES", SqlDbType.Int);
            Cmd.Parameters["@ID_BANDA_DES"].Value = ID_BANDA_DES;

            Cmd.Parameters.Add("@NOMBRE_BANDA", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_BANDA"].Value = NOMBRE_BANDA;

            Cmd.Parameters.Add("@BIENES_ASEGURADOS", SqlDbType.VarChar);
            Cmd.Parameters["@BIENES_ASEGURADOS"].Value = BIENES_ASEGURADOS;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        #endregion
      /********************************************************FIN DE MÓDULO DE SECUESTROS************************************************** */






        /******************************************************** INICIO MÓDULO PNL ************************************************** */

        #region
        public void PNL_InsertaDatosGenerales(int IdDatosGenerales, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, int IdEtnia, DateTime FechaUltimoAvistamiento, short IdActividad)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaDatosGenerales", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDatosGenerales", SqlDbType.Int);
            Cmd.Parameters["@IdDatosGenerales"].Value = IdDatosGenerales;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdEtnia", SqlDbType.Int);
            Cmd.Parameters["@IdEtnia"].Value = IdEtnia;
            Cmd.Parameters.Add("@FechaUltimoAvistamiento", SqlDbType.Date);
            Cmd.Parameters["@FechaUltimoAvistamiento"].Value = FechaUltimoAvistamiento;
            Cmd.Parameters.Add("@IdActividad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdActividad"].Value = @IdActividad;
            
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void ActualizaDatosGenerales(int IdDatosGenerales, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, int IdEtnia, DateTime FechaUltimoAvistamiento, short IdActividad)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDatosGenerales", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDatosGenerales", SqlDbType.Int);
            Cmd.Parameters["@IdDatosGenerales"].Value = IdDatosGenerales;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdEtnia", SqlDbType.Int);
            Cmd.Parameters["@IdEtnia"].Value = IdEtnia;
            Cmd.Parameters.Add("@FechaUltimoAvistamiento", SqlDbType.Date);
            Cmd.Parameters["@FechaUltimoAvistamiento"].Value = FechaUltimoAvistamiento;
            Cmd.Parameters.Add("@IdActividad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdActividad"].Value = @IdActividad;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }


        public void PNL_InsertaPertenenciaSocial(int IdPertenenciaSocial, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, string MiembroONG, string Sindicalista, string Reinsertado, string GrupoReligioso, string OrganismoEstatal, string GrupoDH, string Otros)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaPertenenciaSocial", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPertenenciaSocial", SqlDbType.Int);
            Cmd.Parameters["@IdPertenenciaSocial"].Value = IdPertenenciaSocial;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@MiembroONG", SqlDbType.NVarChar);
            Cmd.Parameters["@MiembroONG"].Value = MiembroONG;
            Cmd.Parameters.Add("@Sindicalista", SqlDbType.NVarChar);
            Cmd.Parameters["@Sindicalista"].Value = Sindicalista;
            Cmd.Parameters.Add("@Reinsertado", SqlDbType.NVarChar);
            Cmd.Parameters["@Reinsertado"].Value = Reinsertado;
            Cmd.Parameters.Add("@GrupoReligioso", SqlDbType.NVarChar);
            Cmd.Parameters["@GrupoReligioso"].Value = GrupoReligioso;
            Cmd.Parameters.Add("@OrganismoEstatal", SqlDbType.NVarChar);
            Cmd.Parameters["@OrganismoEstatal"].Value = OrganismoEstatal;
            Cmd.Parameters.Add("@GrupoDH", SqlDbType.NVarChar);
            Cmd.Parameters["@GrupoDH"].Value = GrupoDH;
            Cmd.Parameters.Add("@Otros", SqlDbType.NVarChar);
            Cmd.Parameters["@Otros"].Value = Otros;
           

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void PNL_ActualizaPertenenciaSocial(int IdPertenenciaSocial, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, string MiembroONG, string Sindicalista, string Reinsertado, string GrupoReligioso, string OrganismoEstatal, string GrupoDH, string Otros)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaPertenenciaSocial", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPertenenciaSocial", SqlDbType.Int);
            Cmd.Parameters["@IdPertenenciaSocial"].Value = IdPertenenciaSocial;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@MiembroONG", SqlDbType.NVarChar);
            Cmd.Parameters["@MiembroONG"].Value = MiembroONG;
            Cmd.Parameters.Add("@Sindicalista", SqlDbType.NVarChar);
            Cmd.Parameters["@Sindicalista"].Value = Sindicalista;
            Cmd.Parameters.Add("@Reinsertado", SqlDbType.NVarChar);
            Cmd.Parameters["@Reinsertado"].Value = Reinsertado;
            Cmd.Parameters.Add("@GrupoReligioso", SqlDbType.NVarChar);
            Cmd.Parameters["@GrupoReligioso"].Value = GrupoReligioso;
            Cmd.Parameters.Add("@OrganismoEstatal", SqlDbType.NVarChar);
            Cmd.Parameters["@OrganismoEstatal"].Value = OrganismoEstatal;
            Cmd.Parameters.Add("@GrupoDH", SqlDbType.NVarChar);
            Cmd.Parameters["@GrupoDH"].Value = GrupoDH;
            Cmd.Parameters.Add("@Otros", SqlDbType.NVarChar);
            Cmd.Parameters["@Otros"].Value = Otros;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void PNL_InsertaInfoFinanciera(int IdInfoFinanciera, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdBanco, string NumCuenta, string TipoCuenta, short TarjetaCredito, string @NumTarjetaCredito, short TarjetaDebito, string NumTarjetaDebito, string TarjetaDepartamental, string NumTarjetaDepartamental)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaInfoFinanciera", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdInfoFinanciera", SqlDbType.Int);
            Cmd.Parameters["@IdInfoFinanciera"].Value = IdInfoFinanciera;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdBanco", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBanco"].Value = IdBanco;
            Cmd.Parameters.Add("@NumCuenta", SqlDbType.NVarChar);
            Cmd.Parameters["@NumCuenta"].Value = NumCuenta;
            Cmd.Parameters.Add("@TipoCuenta", SqlDbType.NVarChar);
            Cmd.Parameters["@TipoCuenta"].Value = TipoCuenta;
            Cmd.Parameters.Add("@TarjetaCredito", SqlDbType.SmallInt);
            Cmd.Parameters["@TarjetaCredito"].Value = TarjetaCredito;
            Cmd.Parameters.Add("@NumTarjetaCredito", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaCredito"].Value = NumTarjetaCredito;
            Cmd.Parameters.Add("@TarjetaDebito", SqlDbType.SmallInt);
            Cmd.Parameters["@TarjetaDebito"].Value = TarjetaDebito;
            Cmd.Parameters.Add("@NumTarjetaDebito", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaDebito"].Value = NumTarjetaDebito;
            Cmd.Parameters.Add("@TarjetaDepartamental", SqlDbType.NVarChar);
            Cmd.Parameters["@TarjetaDepartamental"].Value = TarjetaDepartamental;
            Cmd.Parameters.Add("@NumTarjetaDepartamental", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaDepartamental"].Value = NumTarjetaDepartamental;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void PNL_ActualizaInfoFinanciera(int IdInfoFinanciera, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdBanco, string NumCuenta, string TipoCuenta, short TarjetaCredito, string @NumTarjetaCredito, short TarjetaDebito, string NumTarjetaDebito, string TarjetaDepartamental, string NumTarjetaDepartamental)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaInfoFinanciera", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdInfoFinanciera", SqlDbType.Int);
            Cmd.Parameters["@IdInfoFinanciera"].Value = IdInfoFinanciera;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdBanco", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBanco"].Value = IdBanco;
            Cmd.Parameters.Add("@NumCuenta", SqlDbType.NVarChar);
            Cmd.Parameters["@NumCuenta"].Value = NumCuenta;
            Cmd.Parameters.Add("@TipoCuenta", SqlDbType.NVarChar);
            Cmd.Parameters["@TipoCuenta"].Value = TipoCuenta;
            Cmd.Parameters.Add("@TarjetaCredito", SqlDbType.SmallInt);
            Cmd.Parameters["@TarjetaCredito"].Value = TarjetaCredito;
            Cmd.Parameters.Add("@NumTarjetaCredito", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaCredito"].Value = NumTarjetaCredito;
            Cmd.Parameters.Add("@TarjetaDebito", SqlDbType.SmallInt);
            Cmd.Parameters["@TarjetaDebito"].Value = TarjetaDebito;
            Cmd.Parameters.Add("@NumTarjetaDebito", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaDebito"].Value = NumTarjetaDebito;
            Cmd.Parameters.Add("@TarjetaDepartamental", SqlDbType.NVarChar);
            Cmd.Parameters["@TarjetaDepartamental"].Value = TarjetaDepartamental;
            Cmd.Parameters.Add("@NumTarjetaDepartamental", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaDepartamental"].Value = NumTarjetaDepartamental;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }


        public void PNL_InsertaDiscapacidades(int IdDiscapacidades, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdDiscapacidadMental, string OtraDiscapacidadMental, short IdDiscapacidadFisica, string OtraDiscapacidadFisica, string Padecimientos, string EnfermedadSistematica, string EnfermedadMental, string EnfermedadPiel, string Adicciones, string Medicamentos, string Cirugias, short Embarazo, bool Cesarea, bool PartoNatural, bool Aborto, short ControlNatal, string OtroControlNatal)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDiscapacidades", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDiscapacidades", SqlDbType.Int);
            Cmd.Parameters["@IdDiscapacidades"].Value = IdDiscapacidades;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdDiscapacidadMental", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDiscapacidadMental"].Value = IdDiscapacidadMental;
            Cmd.Parameters.Add("@OtraDiscapacidadMental", SqlDbType.VarChar);
            Cmd.Parameters["@OtraDiscapacidadMental"].Value = OtraDiscapacidadMental;
            Cmd.Parameters.Add("@IdDiscapacidadFisica", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDiscapacidadFisica"].Value = IdDiscapacidadFisica;
            Cmd.Parameters.Add("@OtraDiscapacidadFisica", SqlDbType.VarChar);
            Cmd.Parameters["@OtraDiscapacidadFisica"].Value = OtraDiscapacidadFisica;
            Cmd.Parameters.Add("@Padecimientos", SqlDbType.VarChar);
            Cmd.Parameters["@Padecimientos"].Value = Padecimientos;
            Cmd.Parameters.Add("@EnfermedadSistematica", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadSistematica"].Value = EnfermedadSistematica;
            Cmd.Parameters.Add("@EnfermedadMental", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadMental"].Value = EnfermedadMental;
            Cmd.Parameters.Add("@EnfermedadPiel", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadPiel"].Value = EnfermedadPiel;
            Cmd.Parameters.Add("@Adicciones", SqlDbType.VarChar);
            Cmd.Parameters["@Adicciones"].Value = Adicciones;
            Cmd.Parameters.Add("@Medicamentos", SqlDbType.VarChar);
            Cmd.Parameters["@Medicamentos"].Value = Medicamentos;
            Cmd.Parameters.Add("@Cirugias", SqlDbType.VarChar);
            Cmd.Parameters["@Cirugias"].Value = Cirugias;
            Cmd.Parameters.Add("@Embarazo", SqlDbType.SmallInt);
            Cmd.Parameters["@Embarazo"].Value = Embarazo;
            Cmd.Parameters.Add("@Cesarea", SqlDbType.Bit);
            Cmd.Parameters["@Cesarea"].Value = Cesarea;
            Cmd.Parameters.Add("@PartoNatural", SqlDbType.Bit);
            Cmd.Parameters["@PartoNatural"].Value = PartoNatural;
            Cmd.Parameters.Add("@Aborto", SqlDbType.Bit);
            Cmd.Parameters["@Aborto"].Value = Aborto;
            Cmd.Parameters.Add("@ControlNatal", SqlDbType.SmallInt);
            Cmd.Parameters["@ControlNatal"].Value = ControlNatal;
            Cmd.Parameters.Add("@OtroControlNatal", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroControlNatal"].Value = OtroControlNatal;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        
        }

        public void PNL_ActualizaDiscapacidades(int IdDiscapacidades, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdDiscapacidadMental, string OtraDiscapacidadMental, short IdDiscapacidadFisica, string OtraDiscapacidadFisica, string Padecimientos, string EnfermedadSistematica, string EnfermedadMental, string EnfermedadPiel, string Adicciones, string Medicamentos, string Cirugias, short Embarazo, bool Cesarea, bool PartoNatural, bool Aborto, short ControlNatal, string OtroControlNatal)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDiscapacidades", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDiscapacidades", SqlDbType.Int);
            Cmd.Parameters["@IdDiscapacidades"].Value = IdDiscapacidades;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdDiscapacidadMental", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDiscapacidadMental"].Value = IdDiscapacidadMental;
            Cmd.Parameters.Add("@OtraDiscapacidadMental", SqlDbType.VarChar);
            Cmd.Parameters["@OtraDiscapacidadMental"].Value = OtraDiscapacidadMental;
            Cmd.Parameters.Add("@IdDiscapacidadFisica", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDiscapacidadFisica"].Value = IdDiscapacidadFisica;
            Cmd.Parameters.Add("@OtraDiscapacidadFisica", SqlDbType.VarChar);
            Cmd.Parameters["@OtraDiscapacidadFisica"].Value = OtraDiscapacidadFisica;
            Cmd.Parameters.Add("@Padecimientos", SqlDbType.VarChar);
            Cmd.Parameters["@Padecimientos"].Value = Padecimientos;
            Cmd.Parameters.Add("@EnfermedadSistematica", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadSistematica"].Value = EnfermedadSistematica;
            Cmd.Parameters.Add("@EnfermedadMental", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadMental"].Value = EnfermedadMental;
            Cmd.Parameters.Add("@EnfermedadPiel", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadPiel"].Value = EnfermedadPiel;
            Cmd.Parameters.Add("@Adicciones", SqlDbType.VarChar);
            Cmd.Parameters["@Adicciones"].Value = Adicciones;
            Cmd.Parameters.Add("@Medicamentos", SqlDbType.VarChar);
            Cmd.Parameters["@Medicamentos"].Value = Medicamentos;
            Cmd.Parameters.Add("@Cirugias", SqlDbType.VarChar);
            Cmd.Parameters["@Cirugias"].Value = Cirugias;
            Cmd.Parameters.Add("@Embarazo", SqlDbType.SmallInt);
            Cmd.Parameters["@Embarazo"].Value = Embarazo;
            Cmd.Parameters.Add("@Cesarea", SqlDbType.Bit);
            Cmd.Parameters["@Cesarea"].Value = Cesarea;
            Cmd.Parameters.Add("@PartoNatural", SqlDbType.Bit);
            Cmd.Parameters["@PartoNatural"].Value = PartoNatural;
            Cmd.Parameters.Add("@Aborto", SqlDbType.Bit);
            Cmd.Parameters["@Aborto"].Value = Aborto;
            Cmd.Parameters.Add("@ControlNatal", SqlDbType.SmallInt);
            Cmd.Parameters["@ControlNatal"].Value = ControlNatal;
            Cmd.Parameters.Add("@OtroControlNatal", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroControlNatal"].Value = OtroControlNatal;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public void PNL_InsertaInformacionOdontologica(int IdInfoOdontologica, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short ExpedienteDental, string Odontologo, short TamañoDientes, short DientesCompletos, short DientesSeparados, short DientesGirados, short DientesApiñonados, short DientesManchados, short DientesDesgaste, short Resinas, short Amalgamas, short CoronasMetalicas, short CoronasEsteticas, short Endodoncia, short Blanqueamiento, short Incrustacion, string OtroTratamiento, short IdProtesis, short Braquets, short Retenedores, short Implantes, string OtroAditamento, short AditamentoenDesaparicion, string AusenciaDental, string HabitosDentales)
        
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaInformacionOdontologica", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdInfoOdontologica", SqlDbType.Int);
            Cmd.Parameters["@IdInfoOdontologica"].Value = IdInfoOdontologica;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@ExpedienteDental", SqlDbType.SmallInt);
            Cmd.Parameters["@ExpedienteDental"].Value = ExpedienteDental;
            Cmd.Parameters.Add("@Odontologo", SqlDbType.NVarChar);
            Cmd.Parameters["@Odontologo"].Value = Odontologo;
            Cmd.Parameters.Add("@TamañoDientes", SqlDbType.SmallInt);
            Cmd.Parameters["@TamañoDientes"].Value = TamañoDientes;
            Cmd.Parameters.Add("@DientesCompletos", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesCompletos"].Value = DientesCompletos;
            Cmd.Parameters.Add("@DientesSeparados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesSeparados"].Value = DientesSeparados;
            Cmd.Parameters.Add("@DientesGirados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesGirados"].Value = DientesGirados;
            Cmd.Parameters.Add("@DientesApiñonados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesApiñonados"].Value = DientesApiñonados;
            Cmd.Parameters.Add("@DientesManchados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesManchados"].Value = DientesManchados;
            Cmd.Parameters.Add("@DientesDesgaste", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesDesgaste"].Value = DientesDesgaste;
            Cmd.Parameters.Add("@Resinas", SqlDbType.SmallInt);
            Cmd.Parameters["@Resinas"].Value = Resinas;
            Cmd.Parameters.Add("@Amalgamas", SqlDbType.SmallInt);
            Cmd.Parameters["@Amalgamas"].Value = Amalgamas;
            Cmd.Parameters.Add("@CoronasMetalicas", SqlDbType.SmallInt);
            Cmd.Parameters["@CoronasMetalicas"].Value = CoronasMetalicas;
            Cmd.Parameters.Add("@CoronasEsteticas", SqlDbType.SmallInt);
            Cmd.Parameters["@CoronasEsteticas"].Value = CoronasEsteticas;
            Cmd.Parameters.Add("@Endodoncia", SqlDbType.SmallInt);
            Cmd.Parameters["@Endodoncia"].Value = Endodoncia;
            Cmd.Parameters.Add("@Blanqueamiento", SqlDbType.SmallInt);
            Cmd.Parameters["@Blanqueamiento"].Value = Blanqueamiento;
            Cmd.Parameters.Add("@Incrustacion", SqlDbType.SmallInt);
            Cmd.Parameters["@Incrustacion"].Value = Incrustacion;
            Cmd.Parameters.Add("@OtroTratamiento", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroTratamiento"].Value = OtroTratamiento;
            Cmd.Parameters.Add("@IdProtesis", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProtesis"].Value = IdProtesis;
            Cmd.Parameters.Add("@Braquets", SqlDbType.SmallInt);
            Cmd.Parameters["@Braquets"].Value = Braquets;
            Cmd.Parameters.Add("@Retenedores", SqlDbType.SmallInt);
            Cmd.Parameters["@Retenedores"].Value = Retenedores;
            Cmd.Parameters.Add("@Implantes", SqlDbType.SmallInt);
            Cmd.Parameters["@Implantes"].Value = Implantes;
            Cmd.Parameters.Add("@OtroAditamento", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroAditamento"].Value = OtroAditamento;
            Cmd.Parameters.Add("@AditamentoenDesaparicion", SqlDbType.SmallInt);
            Cmd.Parameters["@AditamentoenDesaparicion"].Value = AditamentoenDesaparicion;
            Cmd.Parameters.Add("@AusenciaDental", SqlDbType.NVarChar);
            Cmd.Parameters["@AusenciaDental"].Value = AusenciaDental;
            Cmd.Parameters.Add("@HabitosDentales", SqlDbType.NVarChar);
            Cmd.Parameters["@HabitosDentales"].Value = HabitosDentales;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void PNL_ActualizaInformacionOdontologica(int IdInfoOdontologica, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short ExpedienteDental, string Odontologo, short TamañoDientes, short DientesCompletos, short DientesSeparados, short DientesGirados, short DientesApiñonados, short DientesManchados, short DientesDesgaste, short Resinas, short Amalgamas, short CoronasMetalicas, short CoronasEsteticas, short Endodoncia, short Blanqueamiento, short Incrustacion, string OtroTratamiento, short IdProtesis, short Braquets, short Retenedores, short Implantes, string OtroAditamento, short AditamentoenDesaparicion, string AusenciaDental, string HabitosDentales)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaInformacionOdontologica", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdInfoOdontologica", SqlDbType.Int);
            Cmd.Parameters["@IdInfoOdontologica"].Value = IdInfoOdontologica;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@ExpedienteDental", SqlDbType.SmallInt);
            Cmd.Parameters["@ExpedienteDental"].Value = ExpedienteDental;
            Cmd.Parameters.Add("@Odontologo", SqlDbType.NVarChar);
            Cmd.Parameters["@Odontologo"].Value = Odontologo;
            Cmd.Parameters.Add("@TamañoDientes", SqlDbType.SmallInt);
            Cmd.Parameters["@TamañoDientes"].Value = TamañoDientes;
            Cmd.Parameters.Add("@DientesCompletos", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesCompletos"].Value = DientesCompletos;
            Cmd.Parameters.Add("@DientesSeparados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesSeparados"].Value = DientesSeparados;
            Cmd.Parameters.Add("@DientesGirados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesGirados"].Value = DientesGirados;
            Cmd.Parameters.Add("@DientesApiñonados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesApiñonados"].Value = DientesApiñonados;
            Cmd.Parameters.Add("@DientesManchados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesManchados"].Value = DientesManchados;
            Cmd.Parameters.Add("@DientesDesgaste", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesDesgaste"].Value = DientesDesgaste;
            Cmd.Parameters.Add("@Resinas", SqlDbType.SmallInt);
            Cmd.Parameters["@Resinas"].Value = Resinas;
            Cmd.Parameters.Add("@Amalgamas", SqlDbType.SmallInt);
            Cmd.Parameters["@Amalgamas"].Value = Amalgamas;
            Cmd.Parameters.Add("@CoronasMetalicas", SqlDbType.SmallInt);
            Cmd.Parameters["@CoronasMetalicas"].Value = CoronasMetalicas;
            Cmd.Parameters.Add("@CoronasEsteticas", SqlDbType.SmallInt);
            Cmd.Parameters["@CoronasEsteticas"].Value = CoronasEsteticas;
            Cmd.Parameters.Add("@Endodoncia", SqlDbType.SmallInt);
            Cmd.Parameters["@Endodoncia"].Value = Endodoncia;
            Cmd.Parameters.Add("@Blanqueamiento", SqlDbType.SmallInt);
            Cmd.Parameters["@Blanqueamiento"].Value = Blanqueamiento;
            Cmd.Parameters.Add("@Incrustacion", SqlDbType.SmallInt);
            Cmd.Parameters["@Incrustacion"].Value = Incrustacion;
            Cmd.Parameters.Add("@OtroTratamiento", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroTratamiento"].Value = OtroTratamiento;
            Cmd.Parameters.Add("@IdProtesis", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProtesis"].Value = IdProtesis;
            Cmd.Parameters.Add("@Braquets", SqlDbType.SmallInt);
            Cmd.Parameters["@Braquets"].Value = Braquets;
            Cmd.Parameters.Add("@Retenedores", SqlDbType.SmallInt);
            Cmd.Parameters["@Retenedores"].Value = Retenedores;
            Cmd.Parameters.Add("@Implantes", SqlDbType.SmallInt);
            Cmd.Parameters["@Implantes"].Value = Implantes;
            Cmd.Parameters.Add("@OtroAditamento", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroAditamento"].Value = OtroAditamento;
            Cmd.Parameters.Add("@AditamentoenDesaparicion", SqlDbType.SmallInt);
            Cmd.Parameters["@AditamentoenDesaparicion"].Value = AditamentoenDesaparicion;
            Cmd.Parameters.Add("@AusenciaDental", SqlDbType.NVarChar);
            Cmd.Parameters["@AusenciaDental"].Value = AusenciaDental;
            Cmd.Parameters.Add("@HabitosDentales", SqlDbType.NVarChar);
            Cmd.Parameters["@HabitosDentales"].Value = HabitosDentales;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void PNL_InsertaOtraInformacion(int IdOtraInformacion, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, bool Detencion, bool Allanamiento, bool Hostigamiento, bool Amenazas, bool Lesiones, bool DisposicionDinero, bool ProblemasVecinales, bool ProblemasFamiliares, bool ActitudNerviosa, bool MovimientoCuentaBancaria, bool ComunicacionDesaparecido, bool ComunicacionCaptores, bool SolicitudParaDejarloLibre, bool ComInternetParadero, bool ComPersonasParadero)

        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaOtraInformacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdOtraInformacion", SqlDbType.Int);
            Cmd.Parameters["@IdOtraInformacion"].Value = IdOtraInformacion;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Detencion", SqlDbType.Bit);
            Cmd.Parameters["@Detencion"].Value = Detencion;
            Cmd.Parameters.Add("@Allanamiento", SqlDbType.Bit);
            Cmd.Parameters["@Allanamiento"].Value = Allanamiento;
            Cmd.Parameters.Add("@Hostigamiento", SqlDbType.Bit);
            Cmd.Parameters["@Hostigamiento"].Value = Hostigamiento;
            Cmd.Parameters.Add("@Amenazas", SqlDbType.Bit);
            Cmd.Parameters["@Amenazas"].Value = Amenazas;
            Cmd.Parameters.Add("@Lesiones", SqlDbType.Bit);
            Cmd.Parameters["@Lesiones"].Value = Lesiones;
            Cmd.Parameters.Add("@DisposicionDinero", SqlDbType.Bit);
            Cmd.Parameters["@DisposicionDinero"].Value = DisposicionDinero;
            Cmd.Parameters.Add("@ProblemasVecinales", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasVecinales"].Value = ProblemasVecinales;
            Cmd.Parameters.Add("@ProblemasFamiliares", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasFamiliares"].Value = ProblemasFamiliares;
            Cmd.Parameters.Add("@ActitudNerviosa", SqlDbType.Bit);
            Cmd.Parameters["@ActitudNerviosa"].Value = ActitudNerviosa;
            Cmd.Parameters.Add("@MovimientoCuentaBancaria", SqlDbType.Bit);
            Cmd.Parameters["@MovimientoCuentaBancaria"].Value = MovimientoCuentaBancaria;
            Cmd.Parameters.Add("@ComunicacionDesaparecido", SqlDbType.Bit);
            Cmd.Parameters["@ComunicacionDesaparecido"].Value = ComunicacionDesaparecido;
            Cmd.Parameters.Add("@ComunicacionCaptores", SqlDbType.Bit);
            Cmd.Parameters["@ComunicacionCaptores"].Value = ComunicacionCaptores;
            Cmd.Parameters.Add("@SolicitudParaDejarloLibre", SqlDbType.Bit);
            Cmd.Parameters["@SolicitudParaDejarloLibre"].Value = SolicitudParaDejarloLibre;
            Cmd.Parameters.Add("@ComInternetParadero", SqlDbType.Bit);
            Cmd.Parameters["@ComInternetParadero"].Value = ComInternetParadero;
            Cmd.Parameters.Add("@ComPersonasParadero", SqlDbType.Bit);
            Cmd.Parameters["@ComPersonasParadero"].Value = ComPersonasParadero;
            


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
            
        
        }

        public void PNL_ActualizaOtraInformacion(int IdOtraInformacion, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, bool Detencion, bool Allanamiento, bool Hostigamiento, bool Amenazas, bool Lesiones, bool DisposicionDinero, bool ProblemasVecinales, bool ProblemasFamiliares, bool ActitudNerviosa, bool MovimientoCuentaBancaria, bool ComunicacionDesaparecido, bool ComunicacionCaptores, bool SolicitudParaDejarloLibre, bool ComInternetParadero, bool ComPersonasParadero)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaOtraInformacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdOtraInformacion", SqlDbType.Int);
            Cmd.Parameters["@IdOtraInformacion"].Value = IdOtraInformacion;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Detencion", SqlDbType.Bit);
            Cmd.Parameters["@Detencion"].Value = Detencion;
            Cmd.Parameters.Add("@Allanamiento", SqlDbType.Bit);
            Cmd.Parameters["@Allanamiento"].Value = Allanamiento;
            Cmd.Parameters.Add("@Hostigamiento", SqlDbType.Bit);
            Cmd.Parameters["@Hostigamiento"].Value = Hostigamiento;
            Cmd.Parameters.Add("@Amenazas", SqlDbType.Bit);
            Cmd.Parameters["@Amenazas"].Value = Amenazas;
            Cmd.Parameters.Add("@Lesiones", SqlDbType.Bit);
            Cmd.Parameters["@Lesiones"].Value = Lesiones;
            Cmd.Parameters.Add("@DisposicionDinero", SqlDbType.Bit);
            Cmd.Parameters["@DisposicionDinero"].Value = DisposicionDinero;
            Cmd.Parameters.Add("@ProblemasVecinales", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasVecinales"].Value = ProblemasVecinales;
            Cmd.Parameters.Add("@ProblemasFamiliares", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasFamiliares"].Value = ProblemasFamiliares;
            Cmd.Parameters.Add("@ActitudNerviosa", SqlDbType.Bit);
            Cmd.Parameters["@ActitudNerviosa"].Value = ActitudNerviosa;
            Cmd.Parameters.Add("@MovimientoCuentaBancaria", SqlDbType.Bit);
            Cmd.Parameters["@MovimientoCuentaBancaria"].Value = MovimientoCuentaBancaria;
            Cmd.Parameters.Add("@ComunicacionDesaparecido", SqlDbType.Bit);
            Cmd.Parameters["@ComunicacionDesaparecido"].Value = ComunicacionDesaparecido;
            Cmd.Parameters.Add("@ComunicacionCaptores", SqlDbType.Bit);
            Cmd.Parameters["@ComunicacionCaptores"].Value = ComunicacionCaptores;
            Cmd.Parameters.Add("@SolicitudParaDejarloLibre", SqlDbType.Bit);
            Cmd.Parameters["@SolicitudParaDejarloLibre"].Value = SolicitudParaDejarloLibre;
            Cmd.Parameters.Add("@ComInternetParadero", SqlDbType.Bit);
            Cmd.Parameters["@ComInternetParadero"].Value = ComInternetParadero;
            Cmd.Parameters.Add("@ComPersonasParadero", SqlDbType.Bit);
            Cmd.Parameters["@ComPersonasParadero"].Value = ComPersonasParadero;
            


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public void PNL_InsertaCausalesDesaparicion(int ID_CAUSALES_DESAPARICION, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, bool PropiaVoluntad, bool SustraccionMenores, bool Salud, bool Adicciones, bool Migracion, bool ComisionDelito, bool Levanton, bool DetenidoCausales, bool VictimaDelito, bool Accidentes, bool ProblemasFamiliares, bool RelacionesPersonales, bool MotivosLaborales,
            bool DesaparicionForzada, int IdTipoSujeto, bool SeDesconoce)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaCausalesDesaparicion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CAUSALES_DESAPARICION", SqlDbType.Int);
            Cmd.Parameters["@ID_CAUSALES_DESAPARICION"].Value = ID_CAUSALES_DESAPARICION;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@PropiaVoluntad", SqlDbType.Bit);
            Cmd.Parameters["@PropiaVoluntad"].Value = PropiaVoluntad;
            Cmd.Parameters.Add("@SustraccionMenores", SqlDbType.Bit);
            Cmd.Parameters["@SustraccionMenores"].Value = SustraccionMenores;
            Cmd.Parameters.Add("@Salud", SqlDbType.Bit);
            Cmd.Parameters["@Salud"].Value = Salud;
            Cmd.Parameters.Add("@Adicciones", SqlDbType.Bit);
            Cmd.Parameters["@Adicciones"].Value = Adicciones;
            Cmd.Parameters.Add("@Migracion", SqlDbType.Bit);
            Cmd.Parameters["@Migracion"].Value = Migracion;
            Cmd.Parameters.Add("@ComisionDelito", SqlDbType.Bit);
            Cmd.Parameters["@ComisionDelito"].Value = ComisionDelito;
            Cmd.Parameters.Add("@Levanton", SqlDbType.Bit);
            Cmd.Parameters["@Levanton"].Value = Levanton;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = DetenidoCausales;
            Cmd.Parameters.Add("@VictimaDelito", SqlDbType.Bit);
            Cmd.Parameters["@VictimaDelito"].Value = VictimaDelito;
            Cmd.Parameters.Add("@Accidentes", SqlDbType.Bit);
            Cmd.Parameters["@Accidentes"].Value = Accidentes;
            Cmd.Parameters.Add("@ProblemasFamiliares", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasFamiliares"].Value = ProblemasFamiliares;
            Cmd.Parameters.Add("@RelacionesPersonales", SqlDbType.Bit);
            Cmd.Parameters["@RelacionesPersonales"].Value = RelacionesPersonales;
            Cmd.Parameters.Add("@MotivosLaborales", SqlDbType.Bit);
            Cmd.Parameters["@MotivosLaborales"].Value = MotivosLaborales;
            Cmd.Parameters.Add("@DesaparicionForzada", SqlDbType.Bit);
            Cmd.Parameters["@DesaparicionForzada"].Value = DesaparicionForzada;
            Cmd.Parameters.Add("@IdTipoSujeto", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujeto"].Value = IdTipoSujeto;
            Cmd.Parameters.Add("@SeDesconoce", SqlDbType.Bit);
            Cmd.Parameters["@SeDesconoce"].Value = SeDesconoce;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        
        }

        public void PNL_ActualizaCausalesDesaparicion(int ID_CAUSALES_DESAPARICION, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, bool PropiaVoluntad, bool SustraccionMenores, bool Salud, bool Adicciones, bool Migracion, bool ComisionDelito, bool Levanton, bool DetenidoCausales, bool VictimaDelito, bool Accidentes, bool ProblemasFamiliares, bool RelacionesPersonales, bool MotivosLaborales,
           bool DesaparicionForzada, int IdTipoSujeto, bool SeDesconoce)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaCausalesDesaparicion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CAUSALES_DESAPARICION", SqlDbType.Int);
            Cmd.Parameters["@ID_CAUSALES_DESAPARICION"].Value = ID_CAUSALES_DESAPARICION;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@PropiaVoluntad", SqlDbType.Bit);
            Cmd.Parameters["@PropiaVoluntad"].Value = PropiaVoluntad;
            Cmd.Parameters.Add("@SustraccionMenores", SqlDbType.Bit);
            Cmd.Parameters["@SustraccionMenores"].Value = SustraccionMenores;
            Cmd.Parameters.Add("@Salud", SqlDbType.Bit);
            Cmd.Parameters["@Salud"].Value = Salud;
            Cmd.Parameters.Add("@Adicciones", SqlDbType.Bit);
            Cmd.Parameters["@Adicciones"].Value = Adicciones;
            Cmd.Parameters.Add("@Migracion", SqlDbType.Bit);
            Cmd.Parameters["@Migracion"].Value = Migracion;
            Cmd.Parameters.Add("@ComisionDelito", SqlDbType.Bit);
            Cmd.Parameters["@ComisionDelito"].Value = ComisionDelito;
            Cmd.Parameters.Add("@Levanton", SqlDbType.Bit);
            Cmd.Parameters["@Levanton"].Value = Levanton;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = DetenidoCausales;
            Cmd.Parameters.Add("@VictimaDelito", SqlDbType.Bit);
            Cmd.Parameters["@VictimaDelito"].Value = VictimaDelito;
            Cmd.Parameters.Add("@Accidentes", SqlDbType.Bit);
            Cmd.Parameters["@Accidentes"].Value = Accidentes;
            Cmd.Parameters.Add("@ProblemasFamiliares", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasFamiliares"].Value = ProblemasFamiliares;
            Cmd.Parameters.Add("@RelacionesPersonales", SqlDbType.Bit);
            Cmd.Parameters["@RelacionesPersonales"].Value = RelacionesPersonales;
            Cmd.Parameters.Add("@MotivosLaborales", SqlDbType.Bit);
            Cmd.Parameters["@MotivosLaborales"].Value = MotivosLaborales;
            Cmd.Parameters.Add("@DesaparicionForzada", SqlDbType.Bit);
            Cmd.Parameters["@DesaparicionForzada"].Value = DesaparicionForzada;
            Cmd.Parameters.Add("@IdTipoSujeto", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujeto"].Value = IdTipoSujeto;
            Cmd.Parameters.Add("@SeDesconoce", SqlDbType.Bit);
            Cmd.Parameters["@SeDesconoce"].Value = SeDesconoce;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void PNL_InsertaVestimenta(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, int IdVestimenta, string DescripcionVestimenta)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaVestimenta", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

           
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdVestimenta", SqlDbType.Int);
            Cmd.Parameters["@IdVestimenta"].Value = @IdVestimenta;
            Cmd.Parameters.Add("@DescripcionVestimenta", SqlDbType.VarChar);
            Cmd.Parameters["@DescripcionVestimenta"].Value = DescripcionVestimenta;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }





        public void InsertaDonantes(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona,string Nombre, String Paterno, String Materno, short IdSexo, short IdIdentificacion,
           String FolioIdentificacion, short IdParentesco, short IdPais, short IdEntidad, short IdMunicipio, short Localidad,
           short Colonia, int Calle, int EntreCalle1, int EntreCalle2, String NumeroExterior, String NumeroInterior,
           String CP, String Telefono, String TipoMuestra, DateTime FechaMuestra, short MenorEdad, String NombreTutor, String PaternoTutor,
           String MaternoTutor, short IdParentescoTutor, short IdIdentificacionTutor, String FolioIdentificacionTutor, short Trasfusion,
           short Trasplante, short EnfermedadInfecciosa, String CantidadDeMuestra, String AutoridadQueSolicitaTomaMuestra, String LugarRecoleccionIndicios, String HoraRecoleccionMuestra)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDonante", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Nombre ", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre "].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@IdSexo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSexo"].Value = IdSexo;
            Cmd.Parameters.Add("@IdIdentificacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacion"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@FolioIdentificacion", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIdentificacion"].Value = FolioIdentificacion;
            Cmd.Parameters.Add("@IdParentesco", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentesco"].Value = IdParentesco;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEntidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEntidad"].Value = IdEntidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Localidad", SqlDbType.SmallInt);
            Cmd.Parameters["@Localidad"].Value = Localidad;
            Cmd.Parameters.Add("@Colonia", SqlDbType.SmallInt);
            Cmd.Parameters["@Colonia"].Value = Colonia;
            Cmd.Parameters.Add("@Calle", SqlDbType.Int);
            Cmd.Parameters["@Calle"].Value = Calle;
            Cmd.Parameters.Add("@EntreCalle1", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle1"].Value = EntreCalle1;
            Cmd.Parameters.Add("@EntreCalle2", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle2"].Value = EntreCalle2;
            Cmd.Parameters.Add("@NumeroExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroExterior"].Value = NumeroExterior;
            Cmd.Parameters.Add("@NumeroInterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroInterior"].Value = NumeroInterior;
            Cmd.Parameters.Add("@CP", SqlDbType.VarChar);
            Cmd.Parameters["@CP"].Value = CP;
            Cmd.Parameters.Add("@Telefono", SqlDbType.VarChar);
            Cmd.Parameters["@Telefono"].Value = Telefono;
            Cmd.Parameters.Add("@TipoMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@TipoMuestra"].Value = TipoMuestra;
            Cmd.Parameters.Add("@FechaMuestra", SqlDbType.Date);
            Cmd.Parameters["@FechaMuestra"].Value = FechaMuestra;
            Cmd.Parameters.Add("@MenorEdad", SqlDbType.Bit);
            Cmd.Parameters["@MenorEdad"].Value = MenorEdad;
            Cmd.Parameters.Add("@NombreTutor", SqlDbType.VarChar);
            Cmd.Parameters["@NombreTutor"].Value = NombreTutor;
            Cmd.Parameters.Add("@PaternoTutor", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoTutor"].Value = PaternoTutor;
            Cmd.Parameters.Add("@MaternoTutor", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoTutor"].Value = MaternoTutor;
            Cmd.Parameters.Add("@IdParentescoTutor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentescoTutor"].Value = IdParentescoTutor;
            Cmd.Parameters.Add("@IdIdentificacionTutor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacionTutor"].Value = IdIdentificacionTutor;
            Cmd.Parameters.Add("@FolioIdentificacionTutor", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIdentificacionTutor"].Value = FolioIdentificacionTutor;
            Cmd.Parameters.Add("@Trasfusion", SqlDbType.Bit);
            Cmd.Parameters["@Trasfusion"].Value = Trasfusion;
            Cmd.Parameters.Add("@Trasplante", SqlDbType.Bit);
            Cmd.Parameters["@Trasplante"].Value = Trasplante;
            Cmd.Parameters.Add("@EnfermedadInfecciosa", SqlDbType.Bit);
            Cmd.Parameters["@EnfermedadInfecciosa"].Value = EnfermedadInfecciosa;
            Cmd.Parameters.Add("@CantidadDeMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@CantidadDeMuestra"].Value = CantidadDeMuestra;
            Cmd.Parameters.Add("@AutoridadQueSolicitaTomaMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@AutoridadQueSolicitaTomaMuestra"].Value = AutoridadQueSolicitaTomaMuestra;

            Cmd.Parameters.Add("@LugarRecoleccionIndicios", SqlDbType.VarChar);
            Cmd.Parameters["@LugarRecoleccionIndicios"].Value = LugarRecoleccionIndicios;
            Cmd.Parameters.Add("@HoraRecoleccionMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRecoleccionMuestra"].Value = HoraRecoleccionMuestra;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }



        public void ActualizaDonantes(int IdDonante, String Nombre, String Paterno, String Materno, short IdSexo, short IdIdentificacion,
           String FolioIdentificacion, short IdParentesco, short IdPais, short IdEntidad, short IdMunicipio, short Localidad,
           short Colonia, int Calle, int EntreCalle1, int EntreCalle2, String NumeroExterior, String NumeroInterior,
           String CP, String Telefono, String TipoMuestra, DateTime FechaMuestra, short MenorEdad, String NombreTutor, String PaternoTutor,
           String MaternoTutor, short IdParentescoTutor, short IdIdentificacionTutor, String FolioIdentificacionTutor, short Trasfusion,
           short Trasplante, short EnfermedadInfecciosa, String CantidadDeMuestra, String AutoridadQueSolicitaTomaMuestra, String LugarRecoleccionIndicios, String HoraRecoleccionMuestra)
        {
            SqlCommand Cmd = new SqlCommand("PNL_ActualizaDonante", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdDonante", SqlDbType.Int);
            Cmd.Parameters["@IdDonante"].Value = IdDonante;
            Cmd.Parameters.Add("@Nombre ", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre "].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@IdSexo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSexo"].Value = IdSexo;
            Cmd.Parameters.Add("@IdIdentificacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacion"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@FolioIdentificacion", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIdentificacion"].Value = FolioIdentificacion;
            Cmd.Parameters.Add("@IdParentesco", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentesco"].Value = IdParentesco;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEntidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEntidad"].Value = IdEntidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Localidad", SqlDbType.SmallInt);
            Cmd.Parameters["@Localidad"].Value = Localidad;
            Cmd.Parameters.Add("@Colonia", SqlDbType.SmallInt);
            Cmd.Parameters["@Colonia"].Value = Colonia;
            Cmd.Parameters.Add("@Calle", SqlDbType.Int);
            Cmd.Parameters["@Calle"].Value = Calle;
            Cmd.Parameters.Add("@EntreCalle1", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle1"].Value = EntreCalle1;
            Cmd.Parameters.Add("@EntreCalle2", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle2"].Value = EntreCalle2;
            Cmd.Parameters.Add("@NumeroExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroExterior"].Value = NumeroExterior;
            Cmd.Parameters.Add("@NumeroInterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroInterior"].Value = NumeroInterior;
            Cmd.Parameters.Add("@CP", SqlDbType.VarChar);
            Cmd.Parameters["@CP"].Value = CP;
            Cmd.Parameters.Add("@Telefono", SqlDbType.VarChar);
            Cmd.Parameters["@Telefono"].Value = Telefono;
            Cmd.Parameters.Add("@TipoMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@TipoMuestra"].Value = TipoMuestra;
            Cmd.Parameters.Add("@FechaMuestra", SqlDbType.Date);
            Cmd.Parameters["@FechaMuestra"].Value = FechaMuestra;
            Cmd.Parameters.Add("@MenorEdad", SqlDbType.Bit);
            Cmd.Parameters["@MenorEdad"].Value = MenorEdad;
            Cmd.Parameters.Add("@NombreTutor", SqlDbType.VarChar);
            Cmd.Parameters["@NombreTutor"].Value = NombreTutor;
            Cmd.Parameters.Add("@PaternoTutor", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoTutor"].Value = PaternoTutor;
            Cmd.Parameters.Add("@MaternoTutor", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoTutor"].Value = MaternoTutor;
            Cmd.Parameters.Add("@IdParentescoTutor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentescoTutor"].Value = IdParentescoTutor;
            Cmd.Parameters.Add("@IdIdentificacionTutor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacionTutor"].Value = IdIdentificacionTutor;
            Cmd.Parameters.Add("@FolioIdentificacionTutor", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIdentificacionTutor"].Value = FolioIdentificacionTutor;
            Cmd.Parameters.Add("@Trasfusion", SqlDbType.Bit);
            Cmd.Parameters["@Trasfusion"].Value = Trasfusion;
            Cmd.Parameters.Add("@Trasplante", SqlDbType.Bit);
            Cmd.Parameters["@Trasplante"].Value = Trasplante;
            Cmd.Parameters.Add("@EnfermedadInfecciosa", SqlDbType.Bit);
            Cmd.Parameters["@EnfermedadInfecciosa"].Value = EnfermedadInfecciosa;
            Cmd.Parameters.Add("@CantidadDeMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@CantidadDeMuestra"].Value = CantidadDeMuestra;
            Cmd.Parameters.Add("@AutoridadQueSolicitaTomaMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@AutoridadQueSolicitaTomaMuestra"].Value = AutoridadQueSolicitaTomaMuestra;
            
            Cmd.Parameters.Add("@LugarRecoleccionIndicios", SqlDbType.VarChar);
            Cmd.Parameters["@LugarRecoleccionIndicios"].Value = LugarRecoleccionIndicios;
            Cmd.Parameters.Add("@HoraRecoleccionMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRecoleccionMuestra"].Value = HoraRecoleccionMuestra;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void InsertaColectorMuestra(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, 
            String Nombre, String Paterno, String Materno, String NumeroEmpleado,
           String Institucion, int IdMunicipio, String Puesto, int IdDonante, String DptoPericial)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaColectorMuestra", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
           
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@NumeroEmpleado", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroEmpleado"].Value = NumeroEmpleado;
            Cmd.Parameters.Add("@Institucion", SqlDbType.VarChar);
            Cmd.Parameters["@Institucion"].Value = Institucion;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Puesto", SqlDbType.VarChar);
            Cmd.Parameters["@Puesto"].Value = Puesto;
            Cmd.Parameters.Add("@IdDonante", SqlDbType.Int);
            Cmd.Parameters["@IdDonante"].Value = IdDonante;
            Cmd.Parameters.Add("@DptoPericial", SqlDbType.VarChar);
            Cmd.Parameters["@DptoPericial"].Value = DptoPericial;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }



        public void ActualizaColectorMuestra(int IdColectorMuestra, String Nombre, String Paterno, String Materno, String NumeroEmpleado,
             String Institucion, short IdMunicipio, String Puesto, String DptoPericial)
        {
            SqlCommand Cmd = new SqlCommand("PNL_ActualizaColectorMuestra", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            

            Cmd.Parameters.Add("@IdColectorMuestra", SqlDbType.Int);
            Cmd.Parameters["@IdColectorMuestra"].Value = IdColectorMuestra;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@NumeroEmpleado", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroEmpleado"].Value = NumeroEmpleado;
            Cmd.Parameters.Add("@Institucion", SqlDbType.VarChar);
            Cmd.Parameters["@Institucion"].Value = Institucion;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Puesto", SqlDbType.VarChar);
            Cmd.Parameters["@Puesto"].Value = Puesto;
            Cmd.Parameters.Add("@DptoPericial", SqlDbType.VarChar);
            Cmd.Parameters["@DptoPericial"].Value = DptoPericial;
            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void InsertaDatosLocalizacion(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short EstatusPersona, DateTime FechaLocalizacion, string HoraLocalizacion, string PosibleCausaDesaparicion, short IdCondicionLocalizacion, short IdLugarHallazgo, short IdPais, short IdEntidad, short IdMunicipio, short Localidad,
           short Colonia, int Calle, int EntreCalle1, int EntreCalle2, String NumeroExterior, String NumeroInterior,
           String CP, String FechaIngreso, String HoraIngreso, short IdCausasFallecimiento, String IdentificacionCadaver,
          String FechaEntregaCuerpo, String FechaProbableFallecimiento, short EnteLocaliza, String NombreEnte, String PaternoEnte, String MaternoEnte, String Institucion, String Autoridad, String NombreAutoridad, String PaternoAutoridad,
           String MaternoAutoridad, String NombreReclama, String PaternoReclama, String MaternoReclama, short IdParentescoReclama)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDatosLocalizacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@EstatusPersona", SqlDbType.SmallInt);
            Cmd.Parameters["@EstatusPersona"].Value = EstatusPersona;
            Cmd.Parameters.Add("@FechaLocalizacion", SqlDbType.Date);
            Cmd.Parameters["@FechaLocalizacion"].Value = FechaLocalizacion;
            Cmd.Parameters.Add("@HoraLocalizacion", SqlDbType.VarChar);
            Cmd.Parameters["@HoraLocalizacion"].Value = HoraLocalizacion;
            Cmd.Parameters.Add("@PosibleCausaDesaparicion", SqlDbType.VarChar);
            Cmd.Parameters["@PosibleCausaDesaparicion"].Value = PosibleCausaDesaparicion;
            Cmd.Parameters.Add("@IdCondicionLocalizacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCondicionLocalizacion"].Value = IdCondicionLocalizacion;
            Cmd.Parameters.Add("@IdLugarHallazgo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLugarHallazgo"].Value = IdLugarHallazgo;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEntidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEntidad"].Value = IdEntidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Localidad", SqlDbType.SmallInt);
            Cmd.Parameters["@Localidad"].Value = Localidad;
            Cmd.Parameters.Add("@Colonia", SqlDbType.SmallInt);
            Cmd.Parameters["@Colonia"].Value = Colonia;
            Cmd.Parameters.Add("@Calle", SqlDbType.Int);
            Cmd.Parameters["@Calle"].Value = Calle;
            Cmd.Parameters.Add("@EntreCalle1", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle1"].Value = EntreCalle1;
            Cmd.Parameters.Add("@EntreCalle2", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle2"].Value = EntreCalle2;
            Cmd.Parameters.Add("@NumeroExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroExterior"].Value = NumeroExterior;
            Cmd.Parameters.Add("@NumeroInterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroInterior"].Value = NumeroInterior;
            Cmd.Parameters.Add("@CP", SqlDbType.VarChar);
            Cmd.Parameters["@CP"].Value = CP;
            Cmd.Parameters.Add("@FechaIngreso", SqlDbType.VarChar);
            Cmd.Parameters["@FechaIngreso"].Value = FechaIngreso;
            Cmd.Parameters.Add("@HoraIngreso", SqlDbType.VarChar);
            Cmd.Parameters["@HoraIngreso"].Value = HoraIngreso;
            Cmd.Parameters.Add("@IdCausasFallecimiento", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCausasFallecimiento"].Value = IdCausasFallecimiento;
            Cmd.Parameters.Add("@IdentificacionCadaver", SqlDbType.VarChar);
            Cmd.Parameters["@IdentificacionCadaver"].Value = IdentificacionCadaver;
            Cmd.Parameters.Add("@FechaEntregaCuerpo", SqlDbType.VarChar);
            Cmd.Parameters["@FechaEntregaCuerpo"].Value = FechaEntregaCuerpo;
            Cmd.Parameters.Add("@FechaProbableFallecimiento", SqlDbType.VarChar);
            Cmd.Parameters["@FechaProbableFallecimiento"].Value = FechaProbableFallecimiento;
            Cmd.Parameters.Add("@EnteLocaliza", SqlDbType.SmallInt);
            Cmd.Parameters["@EnteLocaliza"].Value = EnteLocaliza;
            Cmd.Parameters.Add("@NombreEnte", SqlDbType.VarChar);
            Cmd.Parameters["@NombreEnte"].Value = NombreEnte;
            Cmd.Parameters.Add("@PaternoEnte", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoEnte"].Value = PaternoEnte;
            Cmd.Parameters.Add("@MaternoEnte", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoEnte"].Value = MaternoEnte;
            Cmd.Parameters.Add("@Institucion", SqlDbType.VarChar);
            Cmd.Parameters["@Institucion"].Value = Institucion;
            Cmd.Parameters.Add("@Autoridad", SqlDbType.VarChar);
            Cmd.Parameters["@Autoridad"].Value = Autoridad;
            Cmd.Parameters.Add("@NombreAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@NombreAutoridad"].Value = NombreAutoridad;
            Cmd.Parameters.Add("@PaternoAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoAutoridad"].Value = PaternoAutoridad;

            Cmd.Parameters.Add("@MaternoAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoAutoridad"].Value = MaternoAutoridad;

            Cmd.Parameters.Add("@NombreReclama", SqlDbType.VarChar);
            Cmd.Parameters["@NombreReclama"].Value = NombreReclama;

            Cmd.Parameters.Add("@PaternoReclama", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoReclama"].Value = PaternoReclama;

            Cmd.Parameters.Add("@MaternoReclama", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoReclama"].Value = MaternoReclama;

            Cmd.Parameters.Add("@IdParentescoReclama", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentescoReclama"].Value = IdParentescoReclama;


            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ActualizaDatosLocalizacion(int IdLocalizado, short EstatusPersona, DateTime FechaLocalizacion, String HoraLocalizacion, String PosibleCausaDesaparicion, short IdCondicionLocalizacion, short IdLugarHallazgo, short IdPais, short IdEntidad, short IdMunicipio, short Localidad,
           short Colonia, int Calle, int EntreCalle1, int EntreCalle2, String NumeroExterior, String NumeroInterior,
           String CP, String FechaIngreso, String HoraIngreso, short IdCausasFallecimiento, String IdentificacionCadaver,
          String FechaEntregaCuerpo, String FechaProbableFallecimiento, short EnteLocaliza, String NombreEnte, String PaternoEnte, String MaternoEnte, String Institucion, String Autoridad, String NombreAutoridad, String PaternoAutoridad,
           String MaternoAutoridad, String NombreReclama, String PaternoReclama, String MaternoReclama, short IdParentescoReclama)
        {
            SqlCommand Cmd = new SqlCommand("PNL_ActualizaDatosLocalizacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdLocalizado", SqlDbType.Int);
            Cmd.Parameters["@IdLocalizado"].Value = IdLocalizado;
            Cmd.Parameters.Add("@EstatusPersona", SqlDbType.SmallInt);
            Cmd.Parameters["@EstatusPersona"].Value = EstatusPersona;
            Cmd.Parameters.Add("@FechaLocalizacion", SqlDbType.Date);
            Cmd.Parameters["@FechaLocalizacion"].Value = FechaLocalizacion;
            Cmd.Parameters.Add("@HoraLocalizacion", SqlDbType.VarChar);
            Cmd.Parameters["@HoraLocalizacion"].Value = HoraLocalizacion;
            Cmd.Parameters.Add("@PosibleCausaDesaparicion", SqlDbType.VarChar);
            Cmd.Parameters["@PosibleCausaDesaparicion"].Value = PosibleCausaDesaparicion;
            Cmd.Parameters.Add("@IdCondicionLocalizacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCondicionLocalizacion"].Value = IdCondicionLocalizacion;
            Cmd.Parameters.Add("@IdLugarHallazgo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLugarHallazgo"].Value = IdLugarHallazgo;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEntidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEntidad"].Value = IdEntidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Localidad", SqlDbType.SmallInt);
            Cmd.Parameters["@Localidad"].Value = Localidad;
            Cmd.Parameters.Add("@Colonia", SqlDbType.SmallInt);
            Cmd.Parameters["@Colonia"].Value = Colonia;
            Cmd.Parameters.Add("@Calle", SqlDbType.Int);
            Cmd.Parameters["@Calle"].Value = Calle;
            Cmd.Parameters.Add("@EntreCalle1", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle1"].Value = EntreCalle1;
            Cmd.Parameters.Add("@EntreCalle2", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle2"].Value = EntreCalle2;
            Cmd.Parameters.Add("@NumeroExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroExterior"].Value = NumeroExterior;
            Cmd.Parameters.Add("@NumeroInterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroInterior"].Value = NumeroInterior;
            Cmd.Parameters.Add("@CP", SqlDbType.VarChar);
            Cmd.Parameters["@CP"].Value = CP;
            Cmd.Parameters.Add("@FechaIngreso", SqlDbType.VarChar);
            Cmd.Parameters["@FechaIngreso"].Value = FechaIngreso;
            Cmd.Parameters.Add("@HoraIngreso", SqlDbType.VarChar);
            Cmd.Parameters["@HoraIngreso"].Value = HoraIngreso;
            Cmd.Parameters.Add("@IdCausasFallecimiento", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCausasFallecimiento"].Value = IdCausasFallecimiento;
            Cmd.Parameters.Add("@IdentificacionCadaver", SqlDbType.VarChar);
            Cmd.Parameters["@IdentificacionCadaver"].Value = IdentificacionCadaver;
            Cmd.Parameters.Add("@FechaEntregaCuerpo", SqlDbType.VarChar);
            Cmd.Parameters["@FechaEntregaCuerpo"].Value = FechaEntregaCuerpo;
            Cmd.Parameters.Add("@FechaProbableFallecimiento", SqlDbType.VarChar);
            Cmd.Parameters["@FechaProbableFallecimiento"].Value = FechaProbableFallecimiento;
            Cmd.Parameters.Add("@EnteLocaliza", SqlDbType.SmallInt);
            Cmd.Parameters["@EnteLocaliza"].Value = EnteLocaliza;
            Cmd.Parameters.Add("@NombreEnte", SqlDbType.VarChar);
            Cmd.Parameters["@NombreEnte"].Value = NombreEnte;
            Cmd.Parameters.Add("@PaternoEnte", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoEnte"].Value = PaternoEnte;
            Cmd.Parameters.Add("@MaternoEnte", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoEnte"].Value = MaternoEnte;
            Cmd.Parameters.Add("@Institucion", SqlDbType.VarChar);
            Cmd.Parameters["@Institucion"].Value = Institucion;
            Cmd.Parameters.Add("@Autoridad", SqlDbType.VarChar);
            Cmd.Parameters["@Autoridad"].Value = Autoridad;
            Cmd.Parameters.Add("@NombreAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@NombreAutoridad"].Value = NombreAutoridad;
            Cmd.Parameters.Add("@PaternoAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoAutoridad"].Value = PaternoAutoridad;

            Cmd.Parameters.Add("@MaternoAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoAutoridad"].Value = MaternoAutoridad;

            Cmd.Parameters.Add("@NombreReclama", SqlDbType.VarChar);
            Cmd.Parameters["@NombreReclama"].Value = NombreReclama;

            Cmd.Parameters.Add("@PaternoReclama", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoReclama"].Value = PaternoReclama;

            Cmd.Parameters.Add("@MaternoReclama", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoReclama"].Value = MaternoReclama;

            Cmd.Parameters.Add("@IdParentescoReclama", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentescoReclama"].Value = IdParentescoReclama;


            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void agregarSeñasPNL(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdTipoSeña, short IdDescripcionSeña, short IdVista, short IdLado, short IdRegion, short IdCantidadRegion, string Descripcion, short ID_MUNICIPIO_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("PNL_AgregarSenas", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdTipoSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSeña"].Value = IdTipoSeña;

            Cmd.Parameters.Add("@IdDescripcionSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDescripcionSeña"].Value = IdDescripcionSeña;

            Cmd.Parameters.Add("@IdVista", SqlDbType.SmallInt);
            Cmd.Parameters["@IdVista"].Value = IdVista;

            Cmd.Parameters.Add("@IdLado ", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLado "].Value = IdLado;

            Cmd.Parameters.Add("@IdRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRegion"].Value = IdRegion;

            Cmd.Parameters.Add("@IdCantidadRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadRegion"].Value = IdCantidadRegion;

            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;

           

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void modificarSeñasPNL(int IdSeñaParticularPNL, short IdTipoSeña, short IdDescripcionSeña, short IdVista, short IdLado, short IdRegion, short IdCantidadRegion, string Descripcion)
        {
            SqlCommand Cmd = new SqlCommand("PNL_ActualizarSenas", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdSenaParticularPNL", SqlDbType.Int);
            Cmd.Parameters["@IdSenaParticularPNL"].Value = IdSeñaParticularPNL;

            Cmd.Parameters.Add("@IdTipoSena", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSena"].Value = IdTipoSeña;

            Cmd.Parameters.Add("@IdDescripcionSena", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDescripcionSena"].Value = IdDescripcionSeña;

            Cmd.Parameters.Add("@IdVista", SqlDbType.SmallInt);
            Cmd.Parameters["@IdVista"].Value = IdVista;

            Cmd.Parameters.Add("@IdLado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLado"].Value = IdLado;

            Cmd.Parameters.Add("@IdRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRegion"].Value = IdRegion;

            Cmd.Parameters.Add("@IdCantidadRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadRegion"].Value = IdCantidadRegion;

            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void agregarMediaFiliacionPNL(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdCompexion, short IdColorPiel, short IdCara, short IdCantidadCabello, short IdColorCabello, short IdFormaCabello,
                                                  short IdCalvicieCabello, short IdImplantacionCabello, short IdAlturaFrente, short IdIncilacionFrente, short IdAnchoFrente, short IdDireccionCeja,
                                                  short IdImplantacionCeja, short IdFormaCeja, short IdTamañoCeja, short IdColorOjos, short IdFormaOjos, short IdTamañoOjos,
                                                  short IdRaizNariz, short IdDorsoNariz, short IdAnchoNariz, short IdBaseNariz, short IdAlturaNariz, short IdTamañoBoca,
                                                  short IdComisurasBoca, short IdEspesorLabios, short IdNasoLabial, short IdProminenciaLabial, short IdTipoMenton, short IdFormaMenton,
                                                  short IdInclinacionMenton, short IdFormaOreja, short IdOriginalOreja, short IdSuperiorHelix, short IdPosteriorHelix, short IdAdherenciaHelix,
                                                  short IdContornoLobulo, short IdAdherenciaLobulo, short IdParticularidadLobulo, short IdDimensionLobulo, short IdTipoSangre, short IdFactorRH,
                                                  short IdAnteojos, string Estatura, string Peso,
                                                  int IdBigote, int IdColorBigote, int IdTipoBigote, int IdBarba, int IdColorBarba, int IdTipoBarba, int IdPomulos)
        {
            SqlCommand Cmd = new SqlCommand("PNL_AgregarMediaFiliacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdCompexion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCompexion"].Value = IdCompexion;

            Cmd.Parameters.Add("@IdColorPiel", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorPiel"].Value = IdColorPiel;

            Cmd.Parameters.Add("@IdCara", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCara"].Value = IdCara;

            Cmd.Parameters.Add("@IdCantidadCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadCabello"].Value = IdCantidadCabello;

            Cmd.Parameters.Add("@IdColorCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorCabello"].Value = IdColorCabello;

            Cmd.Parameters.Add("@IdFormaCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCabello"].Value = IdFormaCabello;

            Cmd.Parameters.Add("@IdCalvicieCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCalvicieCabello"].Value = IdCalvicieCabello;

            Cmd.Parameters.Add("@IdImplantacionCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCabello"].Value = IdImplantacionCabello;

            Cmd.Parameters.Add("@IdAlturaFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaFrente"].Value = IdAlturaFrente;

            Cmd.Parameters.Add("@IdIncilacionFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIncilacionFrente"].Value = IdIncilacionFrente;

            Cmd.Parameters.Add("@IdAnchoFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoFrente"].Value = IdAnchoFrente;

            Cmd.Parameters.Add("@IdDireccionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDireccionCeja"].Value = IdDireccionCeja;

            Cmd.Parameters.Add("@IdImplantacionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCeja"].Value = IdImplantacionCeja;

            Cmd.Parameters.Add("@IdFormaCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCeja"].Value = IdFormaCeja;

            Cmd.Parameters.Add("@IdTamañoCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoCeja"].Value = IdTamañoCeja;

            Cmd.Parameters.Add("@IdColorOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorOjos"].Value = IdColorOjos;

            Cmd.Parameters.Add("@IdFormaOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOjos"].Value = IdFormaOjos;

            Cmd.Parameters.Add("@IdTamañoOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoOjos"].Value = IdTamañoOjos;

            Cmd.Parameters.Add("@IdRaizNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRaizNariz"].Value = IdRaizNariz;

            Cmd.Parameters.Add("@IdDorsoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDorsoNariz"].Value = IdDorsoNariz;

            Cmd.Parameters.Add("@IdAnchoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoNariz"].Value = IdAnchoNariz;

            Cmd.Parameters.Add("@IdBaseNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBaseNariz"].Value = IdBaseNariz;

            Cmd.Parameters.Add("@IdAlturaNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaNariz"].Value = IdAlturaNariz;

            Cmd.Parameters.Add("@IdTamañoBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoBoca"].Value = IdTamañoBoca;

            Cmd.Parameters.Add("@IdComisurasBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdComisurasBoca"].Value = IdComisurasBoca;

            Cmd.Parameters.Add("@IdEspesorLabios", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEspesorLabios"].Value = IdEspesorLabios;

            Cmd.Parameters.Add("@IdNasoLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNasoLabial"].Value = IdNasoLabial;

            Cmd.Parameters.Add("@IdProminenciaLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProminenciaLabial"].Value = IdProminenciaLabial;

            Cmd.Parameters.Add("@IdTipoMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMenton"].Value = IdTipoMenton;

            Cmd.Parameters.Add("@IdFormaMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaMenton"].Value = IdFormaMenton;

            Cmd.Parameters.Add("@IdInclinacionMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdInclinacionMenton"].Value = IdInclinacionMenton;

            Cmd.Parameters.Add("@IdFormaOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOreja"].Value = IdFormaOreja;

            Cmd.Parameters.Add("@IdOriginalOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOriginalOreja"].Value = IdOriginalOreja;

            Cmd.Parameters.Add("@IdSuperiorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSuperiorHelix"].Value = IdSuperiorHelix;

            Cmd.Parameters.Add("@IdPosteriorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPosteriorHelix"].Value = IdPosteriorHelix;

            Cmd.Parameters.Add("@IdAdherenciaHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaHelix"].Value = IdAdherenciaHelix;

            Cmd.Parameters.Add("@IdContornoLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdContornoLobulo"].Value = IdContornoLobulo;

            Cmd.Parameters.Add("@IdAdherenciaLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaLobulo"].Value = IdAdherenciaLobulo;

            Cmd.Parameters.Add("@IdParticularidadLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParticularidadLobulo"].Value = IdParticularidadLobulo;

            Cmd.Parameters.Add("@IdDimensionLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDimensionLobulo"].Value = IdDimensionLobulo;

            Cmd.Parameters.Add("@IdTipoSangre", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSangre"].Value = IdTipoSangre;

            Cmd.Parameters.Add("@IdFactorRH", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFactorRH"].Value = IdFactorRH;

            Cmd.Parameters.Add("@IdAnteojos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnteojos"].Value = IdAnteojos;

            Cmd.Parameters.Add("@Estatura", SqlDbType.VarChar);
            Cmd.Parameters["@Estatura"].Value = Estatura;

            Cmd.Parameters.Add("@Peso", SqlDbType.VarChar);
            Cmd.Parameters["@Peso"].Value = Peso;

            Cmd.Parameters.Add("@IdBigote", SqlDbType.Int);
            Cmd.Parameters["@IdBigote"].Value = IdBigote;
            Cmd.Parameters.Add("@IdColorBigote", SqlDbType.Int);
            Cmd.Parameters["@IdColorBigote"].Value = IdColorBigote;
            Cmd.Parameters.Add("@IdTipoBigote", SqlDbType.Int);
            Cmd.Parameters["@IdTipoBigote"].Value = IdTipoBigote;
            Cmd.Parameters.Add("@IdBarba", SqlDbType.Int);
            Cmd.Parameters["@IdBarba"].Value = IdBarba;
            Cmd.Parameters.Add("@IdColorBarba", SqlDbType.Int);
            Cmd.Parameters["@IdColorBarba"].Value = IdColorBarba;
            Cmd.Parameters.Add("@IdTipoBarba", SqlDbType.Int);
            Cmd.Parameters["@IdTipoBarba"].Value = IdTipoBarba;
            Cmd.Parameters.Add("@IdPomulos", SqlDbType.Int);
            Cmd.Parameters["@IdPomulos"].Value = IdPomulos;

            

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void modificarMediaFiliacionPNL(int IdMediaFiliacionPNL, short IdCompexion, short IdColorPiel, short IdCara, short IdCantidadCabello, short IdColorCabello, short IdFormaCabello,
                                                  short IdCalvicieCabello, short IdImplantacionCabello, short IdAlturaFrente, short IdIncilacionFrente, short IdAnchoFrente, short IdDireccionCeja,
                                                  short IdImplantacionCeja, short IdFormaCeja, short IdTamañoCeja, short IdColorOjos, short IdFormaOjos, short IdTamañoOjos,
                                                  short IdRaizNariz, short IdDorsoNariz, short IdAnchoNariz, short IdBaseNariz, short IdAlturaNariz, short IdTamañoBoca,
                                                  short IdComisurasBoca, short IdEspesorLabios, short IdNasoLabial, short IdProminenciaLabial, short IdTipoMenton, short IdFormaMenton,
                                                  short IdInclinacionMenton, short IdFormaOreja, short IdOriginalOreja, short IdSuperiorHelix, short IdPosteriorHelix, short IdAdherenciaHelix,
                                                  short IdContornoLobulo, short IdAdherenciaLobulo, short IdParticularidadLobulo, short IdDimensionLobulo, short IdTipoSangre, short IdFactorRH,
                                                  short IdAnteojos, string Estatura, string Peso,
                                                   int IdBigote, int IdColorBigote, int IdTipoBigote, int IdBarba, int IdColorBarba, int IdTipoBarba, int IdPomulos)
        {
            SqlCommand Cmd = new SqlCommand("PNL_ActualizarMediaFiliacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdMediaFiliacionPNL", SqlDbType.Int);
            Cmd.Parameters["@IdMediaFiliacionPNL"].Value = IdMediaFiliacionPNL;

            Cmd.Parameters.Add("@IdCompexion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCompexion"].Value = IdCompexion;

            Cmd.Parameters.Add("@IdColorPiel", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorPiel"].Value = IdColorPiel;

            Cmd.Parameters.Add("@IdCara", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCara"].Value = IdCara;

            Cmd.Parameters.Add("@IdCantidadCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadCabello"].Value = IdCantidadCabello;

            Cmd.Parameters.Add("@IdColorCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorCabello"].Value = IdColorCabello;

            Cmd.Parameters.Add("@IdFormaCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCabello"].Value = IdFormaCabello;

            Cmd.Parameters.Add("@IdCalvicieCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCalvicieCabello"].Value = IdCalvicieCabello;

            Cmd.Parameters.Add("@IdImplantacionCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCabello"].Value = IdImplantacionCabello;

            Cmd.Parameters.Add("@IdAlturaFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaFrente"].Value = IdAlturaFrente;

            Cmd.Parameters.Add("@IdIncilacionFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIncilacionFrente"].Value = IdIncilacionFrente;

            Cmd.Parameters.Add("@IdAnchoFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoFrente"].Value = IdAnchoFrente;

            Cmd.Parameters.Add("@IdDireccionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDireccionCeja"].Value = IdDireccionCeja;

            Cmd.Parameters.Add("@IdImplantacionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCeja"].Value = IdImplantacionCeja;

            Cmd.Parameters.Add("@IdFormaCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCeja"].Value = IdFormaCeja;

            Cmd.Parameters.Add("@IdTamañoCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoCeja"].Value = IdTamañoCeja;

            Cmd.Parameters.Add("@IdColorOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorOjos"].Value = IdColorOjos;

            Cmd.Parameters.Add("@IdFormaOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOjos"].Value = IdFormaOjos;

            Cmd.Parameters.Add("@IdTamañoOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoOjos"].Value = IdTamañoOjos;

            Cmd.Parameters.Add("@IdRaizNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRaizNariz"].Value = IdRaizNariz;

            Cmd.Parameters.Add("@IdDorsoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDorsoNariz"].Value = IdDorsoNariz;

            Cmd.Parameters.Add("@IdAnchoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoNariz"].Value = IdAnchoNariz;

            Cmd.Parameters.Add("@IdBaseNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBaseNariz"].Value = IdBaseNariz;

            Cmd.Parameters.Add("@IdAlturaNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaNariz"].Value = IdAlturaNariz;

            Cmd.Parameters.Add("@IdTamañoBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoBoca"].Value = IdTamañoBoca;

            Cmd.Parameters.Add("@IdComisurasBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdComisurasBoca"].Value = IdComisurasBoca;

            Cmd.Parameters.Add("@IdEspesorLabios", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEspesorLabios"].Value = IdEspesorLabios;

            Cmd.Parameters.Add("@IdNasoLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNasoLabial"].Value = IdNasoLabial;

            Cmd.Parameters.Add("@IdProminenciaLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProminenciaLabial"].Value = IdProminenciaLabial;

            Cmd.Parameters.Add("@IdTipoMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMenton"].Value = IdTipoMenton;

            Cmd.Parameters.Add("@IdFormaMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaMenton"].Value = IdFormaMenton;

            Cmd.Parameters.Add("@IdInclinacionMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdInclinacionMenton"].Value = IdInclinacionMenton;

            Cmd.Parameters.Add("@IdFormaOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOreja"].Value = IdFormaOreja;

            Cmd.Parameters.Add("@IdOriginalOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOriginalOreja"].Value = IdOriginalOreja;

            Cmd.Parameters.Add("@IdSuperiorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSuperiorHelix"].Value = IdSuperiorHelix;

            Cmd.Parameters.Add("@IdPosteriorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPosteriorHelix"].Value = IdPosteriorHelix;

            Cmd.Parameters.Add("@IdAdherenciaHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaHelix"].Value = IdAdherenciaHelix;

            Cmd.Parameters.Add("@IdContornoLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdContornoLobulo"].Value = IdContornoLobulo;

            Cmd.Parameters.Add("@IdAdherenciaLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaLobulo"].Value = IdAdherenciaLobulo;

            Cmd.Parameters.Add("@IdParticularidadLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParticularidadLobulo"].Value = IdParticularidadLobulo;

            Cmd.Parameters.Add("@IdDimensionLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDimensionLobulo"].Value = IdDimensionLobulo;

            Cmd.Parameters.Add("@IdTipoSangre", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSangre"].Value = IdTipoSangre;

            Cmd.Parameters.Add("@IdFactorRH", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFactorRH"].Value = IdFactorRH;

            Cmd.Parameters.Add("@IdAnteojos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnteojos"].Value = IdAnteojos;

            Cmd.Parameters.Add("@Estatura", SqlDbType.VarChar);
            Cmd.Parameters["@Estatura"].Value = Estatura;

            Cmd.Parameters.Add("@Peso", SqlDbType.VarChar);
            Cmd.Parameters["@Peso"].Value = Peso;

            Cmd.Parameters.Add("@IdBigote", SqlDbType.Int);
            Cmd.Parameters["@IdBigote"].Value = IdBigote;
            Cmd.Parameters.Add("@IdColorBigote", SqlDbType.Int);
            Cmd.Parameters["@IdColorBigote"].Value = IdColorBigote;
            Cmd.Parameters.Add("@IdTipoBigote", SqlDbType.Int);
            Cmd.Parameters["@IdTipoBigote"].Value = IdTipoBigote;
            Cmd.Parameters.Add("@IdBarba", SqlDbType.Int);
            Cmd.Parameters["@IdBarba"].Value = IdBarba;
            Cmd.Parameters.Add("@IdColorBarba", SqlDbType.Int);
            Cmd.Parameters["@IdColorBarba"].Value = IdColorBarba;
            Cmd.Parameters.Add("@IdTipoBarba", SqlDbType.Int);
            Cmd.Parameters["@IdTipoBarba"].Value = IdTipoBarba;
            Cmd.Parameters.Add("@IdPomulos", SqlDbType.Int);
            Cmd.Parameters["@IdPomulos"].Value = IdPomulos;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void PNLInsertaFotografia(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, Byte[] Fotografia, string Descripcion)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaFotografiaPNL", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Fotografia", SqlDbType.Image);
            Cmd.Parameters["@Fotografia"].Value = Fotografia;
            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;
            
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void PNLActualizaFotografia(int IdFotografia, Byte[] Fotografia)
        {

            SqlCommand Cmd = new SqlCommand("PNL_ActualizaFotografiaPNL", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdFotografia", SqlDbType.Int);
            Cmd.Parameters["@IdFotografia"].Value = IdFotografia;
            Cmd.Parameters.Add("@Fotografia", SqlDbType.Image);
            Cmd.Parameters["@Fotografia"].Value = Fotografia;
            

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void PNLActualizaDescFoto(int IdFotografia, string Descripcion)
        {
            SqlCommand Cmd = new SqlCommand("PNL_ActualizaDescFoto", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdFotografia", SqlDbType.Int);
            Cmd.Parameters["@IdFotografia"].Value = IdFotografia;
            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        
        }

        public void PNLInsertaSujetoInteviene(int IdCarpeta, int IdMunicipio, int IdDelito, int IdSujetoInterviene, int IdTipoSujetoInterviene)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaSujetosInterviene", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.Int);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdSujetoInterviene"].Value = IdSujetoInterviene;
            Cmd.Parameters.Add("@IdTipoSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujetoInterviene"].Value = IdTipoSujetoInterviene;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void PNLActualizaSujetoInteviene(int Id, int IdDelito, int IdSujetoInterviene, int IdTipoSujetoInterviene)
        {
            SqlCommand Cmd = new SqlCommand("SP_ActualizaSujetosInterviene", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@Id", SqlDbType.Int);
            Cmd.Parameters["@Id"].Value = Id;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.Int);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdSujetoInterviene"].Value = IdSujetoInterviene;
            Cmd.Parameters.Add("@IdTipoSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujetoInterviene"].Value = IdTipoSujetoInterviene;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        #endregion

        /*------------------------FIN DEL MODULO DE PERSONAS NO LO CALIZADAS------------------------------------------*/



        internal void CargaComboDelito(DropDownList ddlDelito, string p, string p_2, Label txtArticulo, string p_3)
        {
            throw new NotImplementedException();
        }


        //*********************************   MODULO POLICIA INVESTIGADORA ******************************************** 
        #region

        public void SolicitarPeritoTemp(int ID_CARPETA, int ID_SRVCIO_PRCIAL, string ESPECIFICACIONES, int ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("Solicitar_Perito_Temp", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_SERVICIO", SqlDbType.Int);
            Cmd.Parameters["@ID_SERVICIO"].Value = ID_SRVCIO_PRCIAL;

            Cmd.Parameters.Add("@ESPECIFICACIONES", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFICACIONES"].Value = ESPECIFICACIONES;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void SolicitarPerito(int ID_CARPETA, int ID_UNIDAD, int ID_USUARIO, int ID_SRVCIO_PRCIAL, string ESPECIFICACIONES, int ID_OFICIO_SOLICITUD)
        {
            SqlCommand Cmd = new SqlCommand("Solicitar_Perito", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.Int);
            Cmd.Parameters["@ID_UNIDAD"].Value = ID_UNIDAD;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            Cmd.Parameters.Add("@ID_SERVICIO", SqlDbType.Int);
            Cmd.Parameters["@ID_SERVICIO"].Value = ID_SRVCIO_PRCIAL;
            Cmd.Parameters.Add("@ESPECIFICACIONES", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFICACIONES"].Value = ESPECIFICACIONES;
            Cmd.Parameters.Add("@ID_OFICIO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFICIO"].Value = ID_OFICIO_SOLICITUD;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void AsignarOrden_PI(int ID_ORDEN, int ID_USUARIO, int ID_OFICIO)
        {
            SqlCommand Cmd = new SqlCommand("AsignarOrden_PI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = @ID_USUARIO;
            Cmd.Parameters.Add("@ID_OFICIO", SqlDbType.Int);
            Cmd.Parameters["@ID_OFICIO"].Value = ID_OFICIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void AsignarOrden_PI_TEMP(int ID_ORDEN, int ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("AsignarOrden_PI_TEMP", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void AsignarOrden_MP_CoorPI(int ID_CARPETA, int ID_TIPO_ORDEN)
        {
            SqlCommand Cmd = new SqlCommand("AsignarOrden_MP_CoorPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_TIPO_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_TIPO_ORDEN"].Value = ID_TIPO_ORDEN;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarOrdenTemporal(int ID_ORDEN, int ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarOrdenTemporal", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = @ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void EliminarPI_OrdenAsignada(int ID_ORDEN, int ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarPI_OrdenAsignada", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = @ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarSolicitudTemporal(int ID_CARPETA, int ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarSolicitudTemporal", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ModificarEstadoOrden_PI(int ID_ORDEN, int ID_ESTADO)
        {
            SqlCommand Cmd = new SqlCommand("ModificarEstadoOrden_PI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;
            Cmd.Parameters.Add("@ID_ESTADO", SqlDbType.Int);
            Cmd.Parameters["@ID_ESTADO"].Value = ID_ESTADO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }




        public void ModificarFechaProceso_OrdenAsignacionPI(int ID_ORDEN)
        {
            SqlCommand Cmd = new SqlCommand("ModificarFechaProceso_OrdenAsignacionPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ModificarFechaCumplida_OrdenAsignacionPI(int ID_ORDEN)
        {
            SqlCommand Cmd = new SqlCommand("ModificarFechaCumplida_OrdenAsignacionPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }






        public void InsertarImagen_PI(int ID_CARPETA, int ID_USUARIO, byte[] FOTO, string TITULO, string DESCRIPCION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarImagen_PI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;


            Cmd.Parameters.Add("@FOTO", System.Data.SqlDbType.Image);
            Cmd.Parameters["@FOTO"].Value = FOTO; //byteImage;

            Cmd.Parameters.Add("@TITULO", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@TITULO"].Value = TITULO;

            Cmd.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarVideo_PI(int ID_CARPETA, int ID_USUARIO, string VIDEO, string TITULO, string DESCRIPCION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarVideo_PI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;


            Cmd.Parameters.Add("@VIDEO", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@VIDEO"].Value = VIDEO;

            Cmd.Parameters.Add("@TITULO", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@TITULO"].Value = TITULO;

            Cmd.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarInformeOrdenPI(int ID_ORDEN, int ID_USUARIO, string INFORME)
        {
            SqlCommand Cmd = new SqlCommand("InsertarInformeOrdenPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;


            Cmd.Parameters.Add("@INFORME", System.Data.SqlDbType.Text);
            Cmd.Parameters["@INFORME"].Value = INFORME;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ConsultaInformeOrdenPI(int ID_ORDEN, int ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("ConsultaInformeOrdenPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarAnexo(int ID_CARPETA, int ID_ANEXO)
        {
            SqlCommand Cmd = new SqlCommand("InsertarAnexo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_ANEXO", SqlDbType.Int);
            Cmd.Parameters["@ID_ANEXO"].Value = ID_ANEXO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarAnexosPI(int ID_CARPETA, int ID_DOCUMENTO, byte[] DOCUMENTO)
        {
            SqlCommand Cmd = new SqlCommand("InsertarAnexosPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_DOCUMENTO", SqlDbType.Int);
            Cmd.Parameters["@ID_DOCUMENTO"].Value = ID_DOCUMENTO;

            Cmd.Parameters.Add("@DOCUMENTO", SqlDbType.Image);
            Cmd.Parameters["@DOCUMENTO"].Value = DOCUMENTO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarDocumentoAsignacionPI(int ID_DOCUMENTO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarDocumentoAsignacionPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_DOCUMENTO", SqlDbType.Int);
            Cmd.Parameters["@ID_DOCUMENTO"].Value = ID_DOCUMENTO;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void EliminarAnexoOrdenPi(int ID_ANEXO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarAnexoOrdenPi", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_ANEXO", SqlDbType.Int);
            Cmd.Parameters["@ID_ANEXO"].Value = ID_ANEXO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void EliminarFotografiaPI(int ID_IMAGEN)
        {
            SqlCommand Cmd = new SqlCommand("EliminarFotografiaPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_IMAGEN", SqlDbType.Int);
            Cmd.Parameters["@ID_IMAGEN"].Value = ID_IMAGEN;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarVideoPI(int ID_VIDEO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarVideoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_VIDEO", SqlDbType.Int);
            Cmd.Parameters["@ID_VIDEO"].Value = ID_VIDEO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void Insertar_InfoAseguramientoPI(int ID_CARPETA, int ID_USUARIO, int ID_UNIDAD, string LUGAR)
        {
            SqlCommand Cmd = new SqlCommand("Insertar_InfoAseguramientoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

            Cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.Int);
            Cmd.Parameters["@ID_UNIDAD"].Value = ID_UNIDAD;

            Cmd.Parameters.Add("@LUGAR", SqlDbType.VarChar);
            Cmd.Parameters["@LUGAR"].Value = LUGAR;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void Insertar_CustodiaObjetoPI(string NOMBRE_CUSTODIO, string DOMICILIO_CUSTODIO, string NOMBRE_ASEGURARON, string DOMICILIO_ASEGURARON, string TELEFONO_ASEGURARON, string FECHA_ASEGURARON, string CARGO_CUSTODIO, string IDENTIFICACION_CUSTODIO, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("Insertar_CustodiaObjetoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@NOMBRE_CUSTODIO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_CUSTODIO"].Value = NOMBRE_CUSTODIO;

            Cmd.Parameters.Add("@DOMICILIO_CUSTODIO", SqlDbType.VarChar);
            Cmd.Parameters["@DOMICILIO_CUSTODIO"].Value = DOMICILIO_CUSTODIO;

            Cmd.Parameters.Add("@NOMBRE_ASEGURARON", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_ASEGURARON"].Value = NOMBRE_ASEGURARON;

            Cmd.Parameters.Add("@DOMICILIO_ASEGURARON", SqlDbType.VarChar);
            Cmd.Parameters["@DOMICILIO_ASEGURARON"].Value = DOMICILIO_ASEGURARON;

            Cmd.Parameters.Add("@TELEFONO_ASEGURARON", SqlDbType.VarChar);
            Cmd.Parameters["@TELEFONO_ASEGURARON"].Value = TELEFONO_ASEGURARON;

            Cmd.Parameters.Add("@FECHA_ASEGURARON", SqlDbType.VarChar);
            Cmd.Parameters["@FECHA_ASEGURARON"].Value = FECHA_ASEGURARON;

            Cmd.Parameters.Add("@CARGO_CUSTODIO", SqlDbType.VarChar);
            Cmd.Parameters["@CARGO_CUSTODIO"].Value = CARGO_CUSTODIO;

            Cmd.Parameters.Add("@IDENTIFICACION_CUSTODIO", SqlDbType.VarChar);
            Cmd.Parameters["@IDENTIFICACION_CUSTODIO"].Value = IDENTIFICACION_CUSTODIO;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarObjeto(int ID_CARPETA, int ID_MUNICIPIO_CARPETA, string TIPO_OBJETO, string DESCRIPCION, string CANTIDAD)
        {
            SqlCommand Cmd = new SqlCommand("InsertarObjeto", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

           


            Cmd.Parameters.Add("@TIPO_OBJETO", SqlDbType.VarChar);
            Cmd.Parameters["@TIPO_OBJETO"].Value = TIPO_OBJETO;
            Cmd.Parameters.Add("@CANTIDAD", SqlDbType.Int);
            Cmd.Parameters["@CANTIDAD"].Value = CANTIDAD;

            Cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

           

            

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarDetencionObjeto(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_OBJETO, int ID_PERSONA)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencionObjetoSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_OBJETO", SqlDbType.Int);
            Cmd.Parameters["@ID_OBJETO"].Value = ID_OBJETO;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarDetencionArma(int ID_CARPETA, int ID_MUNICIPIO_CARPETA, int ID_ARMA, int ID_PERSONA)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencionArmaSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_ARMA", SqlDbType.Int);
            Cmd.Parameters["@ID_ARMA"].Value = ID_ARMA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarDetencionDroga(int ID_CARPETA, int ID_MUNICIPIO_CARPETA, int ID_DROGA, int ID_PERSONA)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencionDrogaSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_DROGA", SqlDbType.Int);
            Cmd.Parameters["@ID_DROGA"].Value = ID_DROGA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarDetencionVehiculo(int ID_VEHICULO, int ID_DETENCION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencionVehiculo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_VEHICULO", SqlDbType.Int);
            Cmd.Parameters["@ID_VEHICULO"].Value = ID_VEHICULO;

            Cmd.Parameters.Add("@ID_DETENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_DETENCION"].Value = ID_DETENCION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void Insertar_ObjetoAseguradoPI(int ID_CAUSA, int ID_CARPETA, string ESPECIFIACION)
        {
            SqlCommand Cmd = new SqlCommand("Insertar_ObjetoAseguradoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;



            Cmd.Parameters.Add("@ID_CAUSA", SqlDbType.Int);
            Cmd.Parameters["@ID_CAUSA"].Value = ID_CAUSA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ESPECIFIACION", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFIACION"].Value = ESPECIFIACION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void Insertar_VehiculoAseguradoPI(int ID_CAUSA, int ID_CARPETA, string ESPECIFICACION)
        {
            SqlCommand Cmd = new SqlCommand("Insertar_VehiculoAseguradoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CAUSA", SqlDbType.Int);
            Cmd.Parameters["@ID_CAUSA"].Value = ID_CAUSA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ESPECIFICACION", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFICACION"].Value = ESPECIFICACION;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }



        public void Actualizar_EspecificacionObjetoPI(string ESPECIFICACION, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("Actualizar_EspecificacionObjetoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ESPECIFICACION", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFICACION"].Value = ESPECIFICACION;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void Actualizar_EspecificacionVehiculoPI(string ESPECIFICACION, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("Actualizar_EspecificacionVehiculoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ESPECIFICACION", SqlDbType.VarChar);
            Cmd.Parameters["@ESPECIFICACION"].Value = ESPECIFICACION;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarObjetoAseguradoPI(int ID_OBJETO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarObjetoAseguradoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;



            Cmd.Parameters.Add("@ID_OBJETO", SqlDbType.Int);
            Cmd.Parameters["@ID_OBJETO"].Value = ID_OBJETO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarVhehiculoAseguradoPI(int ID_OBJETO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarVhehiculoAseguradoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;



            Cmd.Parameters.Add("@ID_OBJETO", SqlDbType.Int);
            Cmd.Parameters["@ID_OBJETO"].Value = ID_OBJETO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarBitacora(string USUARIO, string IP_SERVIDOR, string ID_PC, string MODULO, string DESC_MOVIMIENTO)
        {
            SqlCommand Cmd = new SqlCommand("InsertarBitacora", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar);
            Cmd.Parameters["@USUARIO"].Value = USUARIO;

            Cmd.Parameters.Add("@IP_SERVIDOR", SqlDbType.VarChar);
            Cmd.Parameters["@IP_SERVIDOR"].Value = IP_SERVIDOR;

            Cmd.Parameters.Add("@ID_PC", SqlDbType.VarChar);
            Cmd.Parameters["@ID_PC"].Value = ID_PC;

            Cmd.Parameters.Add("@MODULO", SqlDbType.VarChar);
            Cmd.Parameters["@MODULO"].Value = MODULO;

            Cmd.Parameters.Add("@DESC_MOVIMIENTO", SqlDbType.VarChar);
            Cmd.Parameters["@DESC_MOVIMIENTO"].Value = DESC_MOVIMIENTO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void agregarPGJSeñas(int IdPersona, short IdTipoSeña, short IdDescripcionSeña, short IdVista, short IdLado, short IdRegion, short IdCantidadRegion, string Descripcion, short ID_MUNICIPIO_CARPETA, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("agregarPGJSeñasDetSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdTipoSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSeña"].Value = IdTipoSeña;

            Cmd.Parameters.Add("@IdDescripcionSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDescripcionSeña"].Value = IdDescripcionSeña;

            Cmd.Parameters.Add("@IdVista", SqlDbType.SmallInt);
            Cmd.Parameters["@IdVista"].Value = IdVista;

            Cmd.Parameters.Add("@IdLado ", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLado "].Value = IdLado;

            Cmd.Parameters.Add("@IdRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRegion"].Value = IdRegion;

            Cmd.Parameters.Add("@IdCantidadRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadRegion"].Value = IdCantidadRegion;

            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void modificarPGJSeñas(int IdPersona, short IdTipoSeña, short IdDescripcionSeña, short IdVista, short IdLado, short IdRegion, short IdCantidadRegion, string Descripcion)
        {
            SqlCommand Cmd = new SqlCommand("modificarPGJSeñas", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdTipoSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSeña"].Value = IdTipoSeña;

            Cmd.Parameters.Add("@IdDescripcionSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDescripcionSeña"].Value = IdDescripcionSeña;

            Cmd.Parameters.Add("@IdVista", SqlDbType.SmallInt);
            Cmd.Parameters["@IdVista"].Value = IdVista;

            Cmd.Parameters.Add("@IdLado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLado"].Value = IdLado;

            Cmd.Parameters.Add("@IdRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRegion"].Value = IdRegion;

            Cmd.Parameters.Add("@IdCantidadRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadRegion"].Value = IdCantidadRegion;

            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void agregarMediaFiliacion(int IdPersona, short IdCompexion, short IdColorPiel, short IdCara, short IdCantidadCabello, short IdColorCabello, short IdFormaCabello,
                                                  short IdCalvicieCabello, short IdImplantacionCabello, short IdAlturaFrente, short IdIncilacionFrente, short IdAnchoFrente, short IdDireccionCeja,
                                                  short IdImplantacionCeja, short IdFormaCeja, short IdTamañoCeja, short IdColorOjos, short IdFormaOjos, short IdTamañoOjos,
                                                  short IdRaizNariz, short IdDorsoNariz, short IdAnchoNariz, short IdBaseNariz, short IdAlturaNariz, short IdTamañoBoca,
                                                  short IdComisurasBoca, short IdEspesorLabios, short IdNasoLabial, short IdProminenciaLabial, short IdTipoMenton, short IdFormaMenton,
                                                  short IdInclinacionMenton, short IdFormaOreja, short IdOriginalOreja, short IdSuperiorHelix, short IdPosteriorHelix, short IdAdherenciaHelix,
                                                  short IdContornoLobulo, short IdAdherenciaLobulo, short IdParticularidadLobulo, short IdDimensionLobulo, short IdTipoSangre, short IdFactorRH,
                                                  short IdAnteojos, string Estatura, string Peso, short ID_MUNICIPIO_CARPETA, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("agregarMediaFiliacionDetSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdCompexion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCompexion"].Value = IdCompexion;

            Cmd.Parameters.Add("@IdColorPiel", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorPiel"].Value = IdColorPiel;

            Cmd.Parameters.Add("@IdCara", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCara"].Value = IdCara;

            Cmd.Parameters.Add("@IdCantidadCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadCabello"].Value = IdCantidadCabello;

            Cmd.Parameters.Add("@IdColorCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorCabello"].Value = IdColorCabello;

            Cmd.Parameters.Add("@IdFormaCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCabello"].Value = IdFormaCabello;

            Cmd.Parameters.Add("@IdCalvicieCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCalvicieCabello"].Value = IdCalvicieCabello;

            Cmd.Parameters.Add("@IdImplantacionCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCabello"].Value = IdImplantacionCabello;

            Cmd.Parameters.Add("@IdAlturaFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaFrente"].Value = IdAlturaFrente;

            Cmd.Parameters.Add("@IdIncilacionFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIncilacionFrente"].Value = IdIncilacionFrente;

            Cmd.Parameters.Add("@IdAnchoFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoFrente"].Value = IdAnchoFrente;

            Cmd.Parameters.Add("@IdDireccionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDireccionCeja"].Value = IdDireccionCeja;

            Cmd.Parameters.Add("@IdImplantacionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCeja"].Value = IdImplantacionCeja;

            Cmd.Parameters.Add("@IdFormaCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCeja"].Value = IdFormaCeja;

            Cmd.Parameters.Add("@IdTamañoCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoCeja"].Value = IdTamañoCeja;

            Cmd.Parameters.Add("@IdColorOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorOjos"].Value = IdColorOjos;

            Cmd.Parameters.Add("@IdFormaOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOjos"].Value = IdFormaOjos;

            Cmd.Parameters.Add("@IdTamañoOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoOjos"].Value = IdTamañoOjos;

            Cmd.Parameters.Add("@IdRaizNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRaizNariz"].Value = IdRaizNariz;

            Cmd.Parameters.Add("@IdDorsoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDorsoNariz"].Value = IdDorsoNariz;

            Cmd.Parameters.Add("@IdAnchoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoNariz"].Value = IdAnchoNariz;

            Cmd.Parameters.Add("@IdBaseNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBaseNariz"].Value = IdBaseNariz;

            Cmd.Parameters.Add("@IdAlturaNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaNariz"].Value = IdAlturaNariz;

            Cmd.Parameters.Add("@IdTamañoBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoBoca"].Value = IdTamañoBoca;

            Cmd.Parameters.Add("@IdComisurasBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdComisurasBoca"].Value = IdComisurasBoca;

            Cmd.Parameters.Add("@IdEspesorLabios", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEspesorLabios"].Value = IdEspesorLabios;

            Cmd.Parameters.Add("@IdNasoLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNasoLabial"].Value = IdNasoLabial;

            Cmd.Parameters.Add("@IdProminenciaLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProminenciaLabial"].Value = IdProminenciaLabial;

            Cmd.Parameters.Add("@IdTipoMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMenton"].Value = IdTipoMenton;

            Cmd.Parameters.Add("@IdFormaMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaMenton"].Value = IdFormaMenton;

            Cmd.Parameters.Add("@IdInclinacionMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdInclinacionMenton"].Value = IdInclinacionMenton;

            Cmd.Parameters.Add("@IdFormaOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOreja"].Value = IdFormaOreja;

            Cmd.Parameters.Add("@IdOriginalOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOriginalOreja"].Value = IdOriginalOreja;

            Cmd.Parameters.Add("@IdSuperiorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSuperiorHelix"].Value = IdSuperiorHelix;

            Cmd.Parameters.Add("@IdPosteriorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPosteriorHelix"].Value = IdPosteriorHelix;

            Cmd.Parameters.Add("@IdAdherenciaHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaHelix"].Value = IdAdherenciaHelix;

            Cmd.Parameters.Add("@IdContornoLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdContornoLobulo"].Value = IdContornoLobulo;

            Cmd.Parameters.Add("@IdAdherenciaLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaLobulo"].Value = IdAdherenciaLobulo;

            Cmd.Parameters.Add("@IdParticularidadLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParticularidadLobulo"].Value = IdParticularidadLobulo;

            Cmd.Parameters.Add("@IdDimensionLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDimensionLobulo"].Value = IdDimensionLobulo;

            Cmd.Parameters.Add("@IdTipoSangre", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSangre"].Value = IdTipoSangre;

            Cmd.Parameters.Add("@IdFactorRH", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFactorRH"].Value = IdFactorRH;

            Cmd.Parameters.Add("@IdAnteojos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnteojos"].Value = IdAnteojos;

            Cmd.Parameters.Add("@Estatura", SqlDbType.VarChar);
            Cmd.Parameters["@Estatura"].Value = Estatura;

            Cmd.Parameters.Add("@Peso", SqlDbType.VarChar);
            Cmd.Parameters["@Peso"].Value = Peso;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void modificarMediaFiliacion(int IdPersona, short IdCompexion, short IdColorPiel, short IdCara, short IdCantidadCabello, short IdColorCabello, short IdFormaCabello,
                                                  short IdCalvicieCabello, short IdImplantacionCabello, short IdAlturaFrente, short IdIncilacionFrente, short IdAnchoFrente, short IdDireccionCeja,
                                                  short IdImplantacionCeja, short IdFormaCeja, short IdTamañoCeja, short IdColorOjos, short IdFormaOjos, short IdTamañoOjos,
                                                  short IdRaizNariz, short IdDorsoNariz, short IdAnchoNariz, short IdBaseNariz, short IdAlturaNariz, short IdTamañoBoca,
                                                  short IdComisurasBoca, short IdEspesorLabios, short IdNasoLabial, short IdProminenciaLabial, short IdTipoMenton, short IdFormaMenton,
                                                  short IdInclinacionMenton, short IdFormaOreja, short IdOriginalOreja, short IdSuperiorHelix, short IdPosteriorHelix, short IdAdherenciaHelix,
                                                  short IdContornoLobulo, short IdAdherenciaLobulo, short IdParticularidadLobulo, short IdDimensionLobulo, short IdTipoSangre, short IdFactorRH,
                                                  short IdAnteojos, string Estatura, string Peso)
        {
            SqlCommand Cmd = new SqlCommand("modificarMediaFiliacionDetSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdMediaFiliacionDetSec", SqlDbType.Int);
            Cmd.Parameters["@IdMediaFiliacionDetSec"].Value = IdPersona;

            Cmd.Parameters.Add("@IdCompexion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCompexion"].Value = IdCompexion;

            Cmd.Parameters.Add("@IdColorPiel", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorPiel"].Value = IdColorPiel;

            Cmd.Parameters.Add("@IdCara", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCara"].Value = IdCara;

            Cmd.Parameters.Add("@IdCantidadCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadCabello"].Value = IdCantidadCabello;

            Cmd.Parameters.Add("@IdColorCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorCabello"].Value = IdColorCabello;

            Cmd.Parameters.Add("@IdFormaCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCabello"].Value = IdFormaCabello;

            Cmd.Parameters.Add("@IdCalvicieCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCalvicieCabello"].Value = IdCalvicieCabello;

            Cmd.Parameters.Add("@IdImplantacionCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCabello"].Value = IdImplantacionCabello;

            Cmd.Parameters.Add("@IdAlturaFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaFrente"].Value = IdAlturaFrente;

            Cmd.Parameters.Add("@IdIncilacionFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIncilacionFrente"].Value = IdIncilacionFrente;

            Cmd.Parameters.Add("@IdAnchoFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoFrente"].Value = IdAnchoFrente;

            Cmd.Parameters.Add("@IdDireccionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDireccionCeja"].Value = IdDireccionCeja;

            Cmd.Parameters.Add("@IdImplantacionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCeja"].Value = IdImplantacionCeja;

            Cmd.Parameters.Add("@IdFormaCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCeja"].Value = IdFormaCeja;

            Cmd.Parameters.Add("@IdTamañoCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoCeja"].Value = IdTamañoCeja;

            Cmd.Parameters.Add("@IdColorOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorOjos"].Value = IdColorOjos;

            Cmd.Parameters.Add("@IdFormaOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOjos"].Value = IdFormaOjos;

            Cmd.Parameters.Add("@IdTamañoOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoOjos"].Value = IdTamañoOjos;

            Cmd.Parameters.Add("@IdRaizNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRaizNariz"].Value = IdRaizNariz;

            Cmd.Parameters.Add("@IdDorsoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDorsoNariz"].Value = IdDorsoNariz;

            Cmd.Parameters.Add("@IdAnchoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoNariz"].Value = IdAnchoNariz;

            Cmd.Parameters.Add("@IdBaseNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBaseNariz"].Value = IdBaseNariz;

            Cmd.Parameters.Add("@IdAlturaNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaNariz"].Value = IdAlturaNariz;

            Cmd.Parameters.Add("@IdTamañoBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoBoca"].Value = IdTamañoBoca;

            Cmd.Parameters.Add("@IdComisurasBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdComisurasBoca"].Value = IdComisurasBoca;

            Cmd.Parameters.Add("@IdEspesorLabios", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEspesorLabios"].Value = IdEspesorLabios;

            Cmd.Parameters.Add("@IdNasoLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNasoLabial"].Value = IdNasoLabial;

            Cmd.Parameters.Add("@IdProminenciaLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProminenciaLabial"].Value = IdProminenciaLabial;

            Cmd.Parameters.Add("@IdTipoMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMenton"].Value = IdTipoMenton;

            Cmd.Parameters.Add("@IdFormaMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaMenton"].Value = IdFormaMenton;

            Cmd.Parameters.Add("@IdInclinacionMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdInclinacionMenton"].Value = IdInclinacionMenton;

            Cmd.Parameters.Add("@IdFormaOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOreja"].Value = IdFormaOreja;

            Cmd.Parameters.Add("@IdOriginalOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOriginalOreja"].Value = IdOriginalOreja;

            Cmd.Parameters.Add("@IdSuperiorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSuperiorHelix"].Value = IdSuperiorHelix;

            Cmd.Parameters.Add("@IdPosteriorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPosteriorHelix"].Value = IdPosteriorHelix;

            Cmd.Parameters.Add("@IdAdherenciaHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaHelix"].Value = IdAdherenciaHelix;

            Cmd.Parameters.Add("@IdContornoLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdContornoLobulo"].Value = IdContornoLobulo;

            Cmd.Parameters.Add("@IdAdherenciaLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaLobulo"].Value = IdAdherenciaLobulo;

            Cmd.Parameters.Add("@IdParticularidadLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParticularidadLobulo"].Value = IdParticularidadLobulo;

            Cmd.Parameters.Add("@IdDimensionLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDimensionLobulo"].Value = IdDimensionLobulo;

            Cmd.Parameters.Add("@IdTipoSangre", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSangre"].Value = IdTipoSangre;

            Cmd.Parameters.Add("@IdFactorRH", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFactorRH"].Value = IdFactorRH;

            Cmd.Parameters.Add("@IdAnteojos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnteojos"].Value = IdAnteojos;

            Cmd.Parameters.Add("@Estatura", SqlDbType.VarChar);
            Cmd.Parameters["@Estatura"].Value = Estatura;

            Cmd.Parameters.Add("@Peso", SqlDbType.VarChar);
            Cmd.Parameters["@Peso"].Value = Peso;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDetenidoPI(String Paterno, String Materno, String Nombre, short IdSexo, String FechaNacimiento, short IdNacionalidad, short IdPais, short IdEstado, short IdMunicipio, String RFC, String CURP, short ID_MUNICIPIO_PERSONA)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDetenidoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;

            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;

            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@IdSexo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSexo"].Value = IdSexo;
            Cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaNacimiento"].Value = FechaNacimiento;
            Cmd.Parameters.Add("@IdNacionalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNacionalidad"].Value = IdNacionalidad;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@RFC", SqlDbType.VarChar);
            Cmd.Parameters["@RFC"].Value = RFC;
            Cmd.Parameters.Add("@CURP", SqlDbType.VarChar);
            Cmd.Parameters["@CURP"].Value = CURP;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PERSONA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PERSONA"].Value = ID_MUNICIPIO_PERSONA;
            //Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            //Cmd.Parameters["@IdPersona"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void InsertarDetencion(int ID_PERSONA, int ID_USUARIO, int ID_CARPETA, short ID_MUNICIPIO_CARPETA, string MOTIVO_DETENCION, string TIEMPO_TRANSLADO, string LUGAR_PUESTA_DISPOSICION, string AUTORIDAD_PUESTO_DISPOSICION, string NOMBRE_RECIBIO, string CARGO_RECIBIO, string CAUSA_NO_FIRMA, string HORA_DETENCION, DateTime FECHA_DETENCION, short ID_ESTADO_DETENIDO, Byte[] FOTO_DETENIDO,
                                     string ASUNTO, string DIRIGIDO_A, string AGENTES, short ID_PARTICIPACION, short OPERATIVO, string NOMBRE_COMANDANTE, string DESCRIPCION_HECHOS, string REFERENCIA_UBICACION, string DETENIDO_POR)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencionSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

           

            

            Cmd.Parameters.Add("@MOTIVO_DETENCION", SqlDbType.VarChar);
            Cmd.Parameters["@MOTIVO_DETENCION"].Value = MOTIVO_DETENCION;

            Cmd.Parameters.Add("@TIEMPO_TRANSLADO", SqlDbType.VarChar);
            Cmd.Parameters["@TIEMPO_TRANSLADO"].Value = TIEMPO_TRANSLADO;

            Cmd.Parameters.Add("@LUGAR_PUESTA_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@LUGAR_PUESTA_DISPOSICION"].Value = LUGAR_PUESTA_DISPOSICION;

            Cmd.Parameters.Add("@AUTORIDAD_PUESTO_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@AUTORIDAD_PUESTO_DISPOSICION"].Value = AUTORIDAD_PUESTO_DISPOSICION;

            Cmd.Parameters.Add("@NOMBRE_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_RECIBIO"].Value = NOMBRE_RECIBIO;

            Cmd.Parameters.Add("@CARGO_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@CARGO_RECIBIO"].Value = CARGO_RECIBIO;

            Cmd.Parameters.Add("@CAUSA_NO_FIRMA", SqlDbType.VarChar);
            Cmd.Parameters["@CAUSA_NO_FIRMA"].Value = CAUSA_NO_FIRMA;

            Cmd.Parameters.Add("@HORA_DETENCION", SqlDbType.VarChar, 8);
            Cmd.Parameters["@HORA_DETENCION"].Value = HORA_DETENCION;

            Cmd.Parameters.Add("@FECHA_DETENCION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_DETENCION"].Value = FECHA_DETENCION;

           

            Cmd.Parameters.Add("@ID_ESTADO_DETENIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_DETENIDO"].Value = ID_ESTADO_DETENIDO;

            Cmd.Parameters.Add("@FOTO_DETENIDO", SqlDbType.Image);
            Cmd.Parameters["@FOTO_DETENIDO"].Value = FOTO_DETENIDO;

            Cmd.Parameters.Add("@ASUNTO", SqlDbType.VarChar);
            Cmd.Parameters["@ASUNTO"].Value = ASUNTO;

            Cmd.Parameters.Add("@DIRIGIDO_A", SqlDbType.VarChar);
            Cmd.Parameters["@DIRIGIDO_A"].Value = DIRIGIDO_A;

            Cmd.Parameters.Add("@AGENTES", SqlDbType.VarChar);
            Cmd.Parameters["@AGENTES"].Value = AGENTES;

            Cmd.Parameters.Add("@ID_PARTICIPACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PARTICIPACION"].Value = ID_PARTICIPACION;

            Cmd.Parameters.Add("@OPERATIVO", SqlDbType.SmallInt);
            Cmd.Parameters["@OPERATIVO"].Value = OPERATIVO;

            Cmd.Parameters.Add("@NOMBRE_COMANDANTE", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_COMANDANTE"].Value = NOMBRE_COMANDANTE;

            Cmd.Parameters.Add("@DESCRIPCION_HECHOS", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_HECHOS"].Value = DESCRIPCION_HECHOS;

            Cmd.Parameters.Add("@REFERENCIA_UBICACION", SqlDbType.VarChar);
            Cmd.Parameters["@REFERENCIA_UBICACION"].Value = REFERENCIA_UBICACION;

            Cmd.Parameters.Add("@DETENIDO_POR", SqlDbType.VarChar);
            Cmd.Parameters["@DETENIDO_POR"].Value = DETENIDO_POR;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ModificarDetencion(int ID_DETENCION, string MOTIVO_DETENCION, string TIEMPO_TRANSLADO, string LUGAR_PUESTA_DISPOSICION, string AUTORIDAD_PUESTO_DISPOSICION, string NOMBRE_RECIBIO, string CARGO_RECIBIO, string CAUSA_NO_FIRMA, string HORA_DETENCION, DateTime FECHA_DETENCION, short ID_ESTADO_DETENIDO,
                                     string ASUNTO, string DIRIGIDO_A, string AGENTES, short ID_PARTICIPACION, short OPERATIVO, string NOMBRE_COMANDANTE, string DESCRIPCION_HECHOS, string REFERENCIA_UBICACION, string DETENIDO_POR)
        {
            SqlCommand Cmd = new SqlCommand("ModificarDetencionSec", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_DETENCION_SEC", SqlDbType.Int);
            Cmd.Parameters["@ID_DETENCION_SEC"].Value = ID_DETENCION;

            Cmd.Parameters.Add("@MOTIVO_DETENCION", SqlDbType.VarChar);
            Cmd.Parameters["@MOTIVO_DETENCION"].Value = MOTIVO_DETENCION;

            Cmd.Parameters.Add("@TIEMPO_TRANSLADO", SqlDbType.VarChar);
            Cmd.Parameters["@TIEMPO_TRANSLADO"].Value = TIEMPO_TRANSLADO;

            Cmd.Parameters.Add("@LUGAR_PUESTA_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@LUGAR_PUESTA_DISPOSICION"].Value = LUGAR_PUESTA_DISPOSICION;

            Cmd.Parameters.Add("@AUTORIDAD_PUESTO_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@AUTORIDAD_PUESTO_DISPOSICION"].Value = AUTORIDAD_PUESTO_DISPOSICION;

            Cmd.Parameters.Add("@NOMBRE_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_RECIBIO"].Value = NOMBRE_RECIBIO;

            Cmd.Parameters.Add("@CARGO_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@CARGO_RECIBIO"].Value = CARGO_RECIBIO;

            Cmd.Parameters.Add("@CAUSA_NO_FIRMA", SqlDbType.VarChar);
            Cmd.Parameters["@CAUSA_NO_FIRMA"].Value = CAUSA_NO_FIRMA;

            Cmd.Parameters.Add("@HORA_DETENCION", SqlDbType.VarChar, 8);
            Cmd.Parameters["@HORA_DETENCION"].Value = HORA_DETENCION;

            Cmd.Parameters.Add("@FECHA_DETENCION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_DETENCION"].Value = FECHA_DETENCION;

            

            Cmd.Parameters.Add("@ID_ESTADO_DETENIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_DETENIDO"].Value = ID_ESTADO_DETENIDO;

            Cmd.Parameters.Add("@ASUNTO", SqlDbType.VarChar);
            Cmd.Parameters["@ASUNTO"].Value = ASUNTO;

            Cmd.Parameters.Add("@DIRIGIDO_A", SqlDbType.VarChar);
            Cmd.Parameters["@DIRIGIDO_A"].Value = DIRIGIDO_A;

            Cmd.Parameters.Add("@AGENTES", SqlDbType.VarChar);
            Cmd.Parameters["@AGENTES"].Value = AGENTES;

            Cmd.Parameters.Add("@ID_PARTICIPACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PARTICIPACION"].Value = ID_PARTICIPACION;

            Cmd.Parameters.Add("@OPERATIVO", SqlDbType.SmallInt);
            Cmd.Parameters["@OPERATIVO"].Value = OPERATIVO;

            Cmd.Parameters.Add("@NOMBRE_COMANDANTE", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_COMANDANTE"].Value = NOMBRE_COMANDANTE;

            Cmd.Parameters.Add("@DESCRIPCION_HECHOS", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_HECHOS"].Value = DESCRIPCION_HECHOS;

            Cmd.Parameters.Add("@REFERENCIA_UBICACION", SqlDbType.VarChar);
            Cmd.Parameters["@REFERENCIA_UBICACION"].Value = REFERENCIA_UBICACION;

            Cmd.Parameters.Add("@DETENIDO_POR", SqlDbType.VarChar);
            Cmd.Parameters["@DETENIDO_POR"].Value = DETENIDO_POR;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }


        public void InsertarObjetoDetenidoPI(int ID_OBJETO, int IdDetencion)
        {
            SqlCommand Cmd = new SqlCommand("InsertarObjetoDetenidoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_OBJETO", SqlDbType.Int);
            Cmd.Parameters["@ID_OBJETO"].Value = ID_OBJETO;

            Cmd.Parameters.Add("@IdDetencion", SqlDbType.Int);
            Cmd.Parameters["@IdDetencion"].Value = IdDetencion;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ActualizarDelitoPI(int ID_DETENCION, string MOTIVO_DETENCION, string TIEMPO_TRANSLADO, string LUGAR_PUESTA_DISPOSICION, string CAUSA_NO_FIRMA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarDelitoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_DETENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_DETENCION"].Value = ID_DETENCION;



            Cmd.Parameters.Add("@MOTIVO_DETENCION", SqlDbType.VarChar, 6500);
            Cmd.Parameters["@MOTIVO_DETENCION"].Value = MOTIVO_DETENCION;


            Cmd.Parameters.Add("@TIEMPO_TRANSLADO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@TIEMPO_TRANSLADO"].Value = TIEMPO_TRANSLADO;

            Cmd.Parameters.Add("@LUGAR_PUESTA_DISPOSICION", SqlDbType.VarChar, 350);
            Cmd.Parameters["@LUGAR_PUESTA_DISPOSICION"].Value = LUGAR_PUESTA_DISPOSICION;


            Cmd.Parameters.Add("@CAUSA_NO_FIRMA", SqlDbType.VarChar, 6500);
            Cmd.Parameters["@CAUSA_NO_FIRMA"].Value = CAUSA_NO_FIRMA;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void EliminarObjetosDetencionPI(int ID_OBJETO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarObjetosDetencionPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_OBJETO ", SqlDbType.Int);
            Cmd.Parameters["@ID_OBJETO "].Value = ID_OBJETO;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }


        public void ActualizarIdCarpetaPersona(int ID_PERSONA, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarIdCarpetaPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ActualizarIdCarpetaDetencionPI(int ID_PERSONA, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarIdCarpetaDetencionPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ActualizarIdCarpetaPDFDetencionPI(int ID_PERSONA, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarIdCarpetaPDFDetencionPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }


        public void ActualizarObjetoAseguradosPI(int ID_INFO, int ID_CUSTODIA, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarObjetoAseguradosPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_INFO", SqlDbType.Int);
            Cmd.Parameters["@ID_INFO"].Value = ID_INFO;

            Cmd.Parameters.Add("@ID_CUSTODIA", SqlDbType.Int);
            Cmd.Parameters["@ID_CUSTODIA"].Value = ID_CUSTODIA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void ActualizarVehiculosAseguradosPI(int ID_INFO, int ID_CUSTODIA, int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarVehiculosAseguradosPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_INFO", SqlDbType.Int);
            Cmd.Parameters["@ID_INFO"].Value = ID_INFO;

            Cmd.Parameters.Add("@ID_CUSTODIA", SqlDbType.Int);
            Cmd.Parameters["@ID_CUSTODIA"].Value = ID_CUSTODIA;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }


        public void ActualizarPreferenciaSexualPI(int ID_PERSONA, short ID_PREFERENCIA_SEXUAL)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarPreferenciaSexualPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_PREFERENCIA_SEXUAL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PREFERENCIA_SEXUAL"].Value = ID_PREFERENCIA_SEXUAL;


            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }


        public void ActualizarImagenDetenidoPI(int ID_PERSONA, Byte[] FOTO_DETENIDO)
        {
            SqlCommand Cmd = new SqlCommand("ActualizarImagenDetenidoPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@FOTO_DETENIDO", SqlDbType.Image);
            Cmd.Parameters["@FOTO_DETENIDO"].Value = FOTO_DETENIDO;


            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        //public void ActualizarImagenDetenidoPI(int ID_DETENIDO, Byte[] FOTO_DETENIDO)
        //{
        //    SqlCommand Cmd = new SqlCommand("ActualizarImagenDetenidoPI", Data.CnnCentral);
        //    Cmd.CommandType = CommandType.StoredProcedure;

        //    Cmd.Parameters.Add("@ID_DETENCION_SEC", SqlDbType.Int);
        //    Cmd.Parameters["@ID_DETENCION_SEC"].Value = ID_DETENIDO;

        //    Cmd.Parameters.Add("@FOTO_DETENIDO", SqlDbType.Image);
        //    Cmd.Parameters["@FOTO_DETENIDO"].Value = FOTO_DETENIDO;


        //    SqlDataReader DR = Cmd.ExecuteReader();

        //    DR.Close();
        //}


        public void CargaComboPOLICIA(DropDownList Combo)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand Cmd = new SqlCommand("CatalogoPOLICIA", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                Combo.DataSource = DR;
                Combo.DataValueField = "ID_PLANTILLA";
                Combo.DataTextField = "NOMBRE_PLANTILLA";
                Combo.DataBind();
            }
            DR.Close();
        }

        public void OrdenContinuacion_MP_CoorPI(int ID_CARPETA)
        {
            SqlCommand Cmd = new SqlCommand("OrdenContinuacion_MP_CoorPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarContinuacionInformeOrdenPI(int ID_ORDEN, int ID_USUARIO, string INFORME)
        {
            SqlCommand Cmd = new SqlCommand("InsertarContinuacionInformeOrdenPI", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_ORDEN", SqlDbType.Int);
            Cmd.Parameters["@ID_ORDEN"].Value = ID_ORDEN;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;


            Cmd.Parameters.Add("@INFORME", System.Data.SqlDbType.Text);
            Cmd.Parameters["@INFORME"].Value = INFORME;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertaVehiculoDetencion(short ID_MUNICIPIO_VEHICULO, int IdCarpeta, short Idmarca, short IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, string Observaciones, string NUMERO_MOTOR, string REGISTRO_NIV, string EMPRESA, string CAPACIDAD_CARGA, string ORIGEN, string DESTINO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVehiculoDetencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = ID_MUNICIPIO_VEHICULO;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;

            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;

            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;

            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;

            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;

            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;

            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;

            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;

            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;

            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;

            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;

            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;

            Cmd.Parameters.Add("@NUMERO_MOTOR", SqlDbType.VarChar);
            Cmd.Parameters["@NUMERO_MOTOR"].Value = NUMERO_MOTOR;

            Cmd.Parameters.Add("@REGISTRO_NIV", SqlDbType.VarChar);
            Cmd.Parameters["@REGISTRO_NIV"].Value = REGISTRO_NIV;

            Cmd.Parameters.Add("@EMPRESA", SqlDbType.VarChar);
            Cmd.Parameters["@EMPRESA"].Value = EMPRESA;

            Cmd.Parameters.Add("@CAPACIDAD_CARGA", SqlDbType.VarChar);
            Cmd.Parameters["@CAPACIDAD_CARGA"].Value = CAPACIDAD_CARGA;

            Cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar);
            Cmd.Parameters["@ORIGEN"].Value = ORIGEN;

            Cmd.Parameters.Add("@DESTINO", SqlDbType.VarChar);
            Cmd.Parameters["@DESTINO"].Value = DESTINO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarDroga(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, string TIPO, string UNIDAD_MEDIDA, string CANTIDAD, string OBSERVACIONES)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDroga", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@TIPO"].Value = TIPO;

            Cmd.Parameters.Add("@UNIDAD_MEDIDA", SqlDbType.VarChar, 50);
            Cmd.Parameters["@UNIDAD_MEDIDA"].Value = UNIDAD_MEDIDA;

            Cmd.Parameters.Add("@CANTIDAD", SqlDbType.VarChar, 50);
            Cmd.Parameters["@CANTIDAD"].Value = CANTIDAD;

            Cmd.Parameters.Add("@OBSERVACIONES", SqlDbType.VarChar, 50);
            Cmd.Parameters["@OBSERVACIONES"].Value = OBSERVACIONES;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }



        #endregion

        //***********************************************************  FIN MODULO POLICIA INVESTIGADORA


        //********************************************************** HOMICIDIOS *********************************************************
        #region

        public void CargaComboLugarHechos(DropDownList Combo, String IdCarpeta)
        {
            SqlCommand cmd = new SqlCommand("CargarLugarHechosHomicidios " + IdCarpeta, Data.CnnCentral);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                Combo.DataSource = rd;
                Combo.DataValueField = "ID_LUGAR_HECHOS";
                Combo.DataTextField = "LUGAR";
                Combo.DataBind();
            }
            rd.Close();
        }


        public void CargarArma(DropDownList Combo, String IdArma)
        {
            SqlCommand cmd = new SqlCommand("CargarArmaHomicidio " + IdArma, Data.CnnCentral);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                Combo.DataSource = rd;
                Combo.DataValueField = "ID_ARMA";
                Combo.DataTextField = "ARMA";
                Combo.DataBind();
            }
            rd.Close();

        }


        public void InsertarHomicidio(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_PERSONA_OFENDIDO, int ID_PERSONA_IMPUTADO, int ID_LUGAR_HECHOS, short ID_TIPO_PERSONA_OFENDIDO, short ID_TIPO_PERSONA_IMPUTADO, short ID_ORGANIZACION_IMPUTADO, short ID_MOVIL, string SUB_DELITO, string SITUACION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_OFENDIDO"].Value = ID_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_PERSONA_IMPUTADO ", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_IMPUTADO "].Value = ID_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_LUGAR_HECHOS", SqlDbType.Int);
            Cmd.Parameters["@ID_LUGAR_HECHOS"].Value = ID_LUGAR_HECHOS;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_OFENDIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_OFENDIDO"].Value = ID_TIPO_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_IMPUTADO"].Value = ID_TIPO_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_ORGANIZACION_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ORGANIZACION_IMPUTADO"].Value = ID_ORGANIZACION_IMPUTADO;

            Cmd.Parameters.Add("@ID_MOVIL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOVIL"].Value = ID_MOVIL;

            Cmd.Parameters.Add("@SUB_DELITO", SqlDbType.VarChar);
            Cmd.Parameters["@SUB_DELITO"].Value = SUB_DELITO;

            Cmd.Parameters.Add("@SITUACION", SqlDbType.VarChar);
            Cmd.Parameters["@SITUACION"].Value = SITUACION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ModificarHomicidio(int ID_HOMICIDIO, int ID_CARPETA, int ID_PERSONA_OFENDIDO, int ID_PERSONA_IMPUTADO, int ID_LUGAR_HECHOS, short ID_TIPO_PERSONA_OFENDIDO, short ID_TIPO_PERSONA_IMPUTADO, short ID_ORGANIZACION_IMPUTADO, short ID_MOVIL, string SUB_DELITO, string SITUACION)
        {
            SqlCommand Cmd = new SqlCommand("ModificarHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;


            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_OFENDIDO"].Value = ID_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_PERSONA_IMPUTADO ", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_IMPUTADO "].Value = ID_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_LUGAR_HECHOS", SqlDbType.Int);
            Cmd.Parameters["@ID_LUGAR_HECHOS"].Value = ID_LUGAR_HECHOS;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_OFENDIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_OFENDIDO"].Value = ID_TIPO_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_IMPUTADO"].Value = ID_TIPO_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_ORGANIZACION_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ORGANIZACION_IMPUTADO"].Value = ID_ORGANIZACION_IMPUTADO;

            Cmd.Parameters.Add("@ID_MOVIL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOVIL"].Value = ID_MOVIL;

            Cmd.Parameters.Add("@SUB_DELITO", SqlDbType.VarChar);
            Cmd.Parameters["@SUB_DELITO"].Value = SUB_DELITO;

            Cmd.Parameters.Add("@SITUACION", SqlDbType.VarChar);
            Cmd.Parameters["@SITUACION"].Value = SITUACION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarCadaverHomicidio(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_PERSONA, short ID_VIOLENCIA, short ID_CDVR_CAUSA, short ID_CDVR_CNSRVCION, short ID_CDVR_ORIENTACION, short ID_CDVR_PSCION, DateTime FECHA_MUERTE, string HORA_MUERTE, DateTime FECHA_IDENTIFICACION, string HORA_IDENTIFIACION, short CUERPO_ENTREGADO, string NOMBRE_ENTREGA_CUERPO, string PARENTESCO, short FOSA_COMUN, string DESCRIPCION_CADAVER, DateTime FECHA_ENTREGA, Byte[] IDENTIFICACION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarCadaverHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_VIOLENCIA ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_VIOLENCIA "].Value = ID_VIOLENCIA;

            Cmd.Parameters.Add("@ID_CDVR_CAUSA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CAUSA"].Value = ID_CDVR_CAUSA;

            Cmd.Parameters.Add("@ID_CDVR_CNSRVCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CNSRVCION"].Value = ID_CDVR_CNSRVCION;

            Cmd.Parameters.Add("@ID_CDVR_ORIENTACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_ORIENTACION"].Value = ID_CDVR_ORIENTACION;

            Cmd.Parameters.Add("@ID_CDVR_PSCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_PSCION"].Value = ID_CDVR_PSCION;

            Cmd.Parameters.Add("@FECHA_MUERTE", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_MUERTE"].Value = FECHA_MUERTE;

            Cmd.Parameters.Add("@HORA_MUERTE", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_MUERTE"].Value = HORA_MUERTE;

            Cmd.Parameters.Add("@FECHA_IDENTIFICACION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_IDENTIFICACION"].Value = FECHA_IDENTIFICACION;

            Cmd.Parameters.Add("@HORA_IDENTIFIACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_IDENTIFIACION"].Value = HORA_IDENTIFIACION;

            Cmd.Parameters.Add("@CUERPO_ENTREGADO", SqlDbType.Bit);
            Cmd.Parameters["@CUERPO_ENTREGADO"].Value = CUERPO_ENTREGADO;

            Cmd.Parameters.Add("@NOMBRE_ENTREGA_CUERPO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_ENTREGA_CUERPO"].Value = NOMBRE_ENTREGA_CUERPO;

            Cmd.Parameters.Add("@PARENTESCO", SqlDbType.VarChar);
            Cmd.Parameters["@PARENTESCO"].Value = PARENTESCO;

            Cmd.Parameters.Add("@FOSA_COMUN", SqlDbType.Bit);
            Cmd.Parameters["@FOSA_COMUN"].Value = FOSA_COMUN;

            Cmd.Parameters.Add("@DESCRIPCION_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_CADAVER"].Value = DESCRIPCION_CADAVER;

            Cmd.Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_ENTREGA"].Value = FECHA_ENTREGA;

            Cmd.Parameters.Add("@IDENTIFICACION", SqlDbType.Image);
            Cmd.Parameters["@IDENTIFICACION"].Value = IDENTIFICACION;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ModificarCadaverHomicidio(int ID_CARPETA, int ID_PERSONA, short ID_VIOLENCIA, short ID_CDVR_CAUSA, short ID_CDVR_CNSRVCION, short ID_CDVR_ORIENTACION, short ID_CDVR_PSCION, DateTime FECHA_MUERTE, string HORA_MUERTE, DateTime FECHA_IDENTIFICACION, string HORA_IDENTIFIACION, short CUERPO_ENTREGADO, string NOMBRE_ENTREGA_CUERPO, string PARENTESCO, short FOSA_COMUN, string DESCRIPCION_CADAVER, DateTime FECHA_ENTREGA)
        {
            SqlCommand Cmd = new SqlCommand("ModificarCadaverHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;


            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_VIOLENCIA ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_VIOLENCIA "].Value = ID_VIOLENCIA;

            Cmd.Parameters.Add("@ID_CDVR_CAUSA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CAUSA"].Value = ID_CDVR_CAUSA;

            Cmd.Parameters.Add("@ID_CDVR_CNSRVCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CNSRVCION"].Value = ID_CDVR_CNSRVCION;

            Cmd.Parameters.Add("@ID_CDVR_ORIENTACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_ORIENTACION"].Value = ID_CDVR_ORIENTACION;

            Cmd.Parameters.Add("@ID_CDVR_PSCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_PSCION"].Value = ID_CDVR_PSCION;

            Cmd.Parameters.Add("@FECHA_MUERTE", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_MUERTE"].Value = FECHA_MUERTE;

            Cmd.Parameters.Add("@HORA_MUERTE", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_MUERTE"].Value = HORA_MUERTE;

            Cmd.Parameters.Add("@FECHA_IDENTIFICACION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_IDENTIFICACION"].Value = FECHA_IDENTIFICACION;

            Cmd.Parameters.Add("@HORA_IDENTIFIACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_IDENTIFIACION"].Value = HORA_IDENTIFIACION;

            Cmd.Parameters.Add("@CUERPO_ENTREGADO", SqlDbType.TinyInt);
            Cmd.Parameters["@CUERPO_ENTREGADO"].Value = CUERPO_ENTREGADO;

            Cmd.Parameters.Add("@NOMBRE_ENTREGA_CUERPO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_ENTREGA_CUERPO"].Value = NOMBRE_ENTREGA_CUERPO;

            Cmd.Parameters.Add("@PARENTESCO", SqlDbType.VarChar);
            Cmd.Parameters["@PARENTESCO"].Value = PARENTESCO;

            Cmd.Parameters.Add("@FOSA_COMUN", SqlDbType.Bit);
            Cmd.Parameters["@FOSA_COMUN"].Value = FOSA_COMUN;

            Cmd.Parameters.Add("@DESCRIPCION_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_CADAVER"].Value = DESCRIPCION_CADAVER;

            Cmd.Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_ENTREGA"].Value = FECHA_ENTREGA;



            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ModificarFotoIdentificacionHomicidio(int ID_CARPETA, int ID_PERSONA, Byte[] IDENTIFICACION)
        {
            SqlCommand Cmd = new SqlCommand("ModificarFotoIdentificacionHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@IDENTIFICACION", SqlDbType.Image);
            Cmd.Parameters["@IDENTIFICACION"].Value = IDENTIFICACION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }



        public void InsertarMensajeHomicidio(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_HOMICIDIO, string MENSAJE, Byte[] FOTO1, Byte[] FOTO2, Byte[] FOTO3, Byte[] FOTO4)
        {
            SqlCommand Cmd = new SqlCommand("InsertarMensajeHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@MENSAJE ", SqlDbType.Text);
            Cmd.Parameters["@MENSAJE "].Value = MENSAJE;

            Cmd.Parameters.Add("@FOTO1", SqlDbType.Image);
            Cmd.Parameters["@FOTO1"].Value = FOTO1;

            Cmd.Parameters.Add("@FOTO2", SqlDbType.Image);
            Cmd.Parameters["@FOTO2"].Value = FOTO2;

            Cmd.Parameters.Add("@FOTO3", SqlDbType.Image);
            Cmd.Parameters["@FOTO3"].Value = FOTO3;

            Cmd.Parameters.Add("@FOTO4", SqlDbType.Image);
            Cmd.Parameters["@FOTO4"].Value = FOTO4;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void ModificarMensajeHomicidio(int ID_CARPETA, int ID_HOMICIDIO, string MENSAJE)
        {
            SqlCommand Cmd = new SqlCommand("ModificarMensajeHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@MENSAJE ", SqlDbType.Text);
            Cmd.Parameters["@MENSAJE "].Value = MENSAJE;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ModificarFoto1MensajeHomicidio(int ID_CARPETA, int ID_HOMICIDIO, Byte[] FOTO1)
        {
            SqlCommand Cmd = new SqlCommand("ModificarFoto1MensajeHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@FOTO1", SqlDbType.Image);
            Cmd.Parameters["@FOTO1"].Value = FOTO1;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ModificarFoto2MensajeHomicidio(int ID_CARPETA, int ID_HOMICIDIO, Byte[] FOTO2)
        {
            SqlCommand Cmd = new SqlCommand("ModificarFoto2MensajeHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@FOTO2", SqlDbType.Image);
            Cmd.Parameters["@FOTO2"].Value = FOTO2;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ModificarFoto3MensajeHomicidio(int ID_CARPETA, int ID_HOMICIDIO, Byte[] FOTO3)
        {
            SqlCommand Cmd = new SqlCommand("ModificarFoto3MensajeHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@FOTO3", SqlDbType.Image);
            Cmd.Parameters["@FOTO3"].Value = FOTO3;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ModificarFoto4MensajeHomicidio(int ID_CARPETA, int ID_HOMICIDIO, Byte[] FOTO4)
        {
            SqlCommand Cmd = new SqlCommand("ModificarFoto4MensajeHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@FOTO4", SqlDbType.Image);
            Cmd.Parameters["@FOTO4"].Value = FOTO4;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }



        public void InsertarArma(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, short ID_ARMA_TPO, short ID_ARMA_CAT, short ID_ARMAS_AA, short ID_MARCA, short ID_CALIBRE, short ID_ESTADO_ARMA, string DESCRIPCION, string MATRICULA, string SERIE)
        {
            SqlCommand Cmd = new SqlCommand("InsertarArma", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_ARMA_TPO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMA_TPO"].Value = ID_ARMA_TPO;

            Cmd.Parameters.Add("@ID_ARMA_CAT ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMA_CAT "].Value = ID_ARMA_CAT;

            Cmd.Parameters.Add("@ID_ARMAS_AA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMAS_AA"].Value = ID_ARMAS_AA;

            Cmd.Parameters.Add("@ID_MARCA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MARCA"].Value = ID_MARCA;

            Cmd.Parameters.Add("@ID_CALIBRE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CALIBRE"].Value = ID_CALIBRE;

            Cmd.Parameters.Add("@ID_ESTADO_ARMA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_ARMA"].Value = ID_ESTADO_ARMA;

            Cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

            Cmd.Parameters.Add("@MATRICULA", SqlDbType.VarChar);
            Cmd.Parameters["@MATRICULA"].Value = MATRICULA;

            Cmd.Parameters.Add("@SERIE", SqlDbType.VarChar);
            Cmd.Parameters["@SERIE"].Value = SERIE;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void ModificarArma(int ID_CARPETA, int ID_ARMA, short ID_ARMA_TPO, short ID_ARMA_CAT, short ID_ARMAS_AA, short ID_MARCA, short ID_CALIBRE, short ID_ESTADO_ARMA, string DESCRIPCION)
        {
            SqlCommand Cmd = new SqlCommand("ModificarArma", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_ARMA", SqlDbType.Int);
            Cmd.Parameters["@ID_ARMA"].Value = ID_ARMA;

            Cmd.Parameters.Add("@ID_ARMA_TPO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMA_TPO"].Value = ID_ARMA_TPO;

            Cmd.Parameters.Add("@ID_ARMA_CAT ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMA_CAT "].Value = ID_ARMA_CAT;

            Cmd.Parameters.Add("@ID_ARMAS_AA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMAS_AA"].Value = ID_ARMAS_AA;

            Cmd.Parameters.Add("@ID_MARCA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MARCA"].Value = ID_MARCA;

            Cmd.Parameters.Add("@ID_CALIBRE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CALIBRE"].Value = ID_CALIBRE;

            Cmd.Parameters.Add("@ID_ESTADO_ARMA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_ARMA"].Value = ID_ESTADO_ARMA;

            Cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarArmaHomicidio(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_ARMA, int ID_HOMICIDIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertarArmaHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_ARMA", SqlDbType.Int);
            Cmd.Parameters["@ID_ARMA"].Value = ID_ARMA;

            Cmd.Parameters.Add("@ID_HOMICIDIO ", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO "].Value = ID_HOMICIDIO;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }



        #endregion
        //********************************************************** FIN HOMICIDIOS *********************************************************

        // modulo Perciales
        #region

        public void CargaComboPe(DropDownList Combo, String Tabla, String Id, String Campo)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand cmd = new SqlCommand("Catalogo " + Tabla + ", " + Id + ", " + Campo, Data.CnnCentral);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                Combo.DataSource = rd;
                Combo.DataValueField = "ID";
                Combo.DataTextField = "CAMPO";
                Combo.DataBind();
            }
            rd.Close();
        }


        public void CargaComboFiltradoPe(DropDownList Combo, String Tabla, String Id, String Campo, String Filtro)
        {
            //CnnCentral.Close();
            //CnnCentral.Open();
            SqlCommand Cmd = new SqlCommand("CatalogoFiltrado", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Tabla", SqlDbType.VarChar);
            Cmd.Parameters["@Tabla"].Value = Tabla;
            Cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            Cmd.Parameters["@Id"].Value = Id;
            Cmd.Parameters.Add("@Campo", SqlDbType.VarChar);
            Cmd.Parameters["@Campo"].Value = Campo;
            Cmd.Parameters.Add("@Filtro", SqlDbType.VarChar);
            Cmd.Parameters["@Filtro"].Value = Filtro;
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                Combo.DataSource = DR;
                Combo.DataValueField = "ID";
                Combo.DataTextField = "CAMPO";
                Combo.DataBind();
            }
            DR.Close();
        }

        public void AsignarSolicitud_Perito_TEMP(int ID_SOLP, int ID_USUARIO)
        {
            SqlCommand Cmd = new SqlCommand("ASIGNAR_PERITO_PERITAJE_TEMP", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@id_sol", SqlDbType.Int);
            Cmd.Parameters["@id_sol"].Value = ID_SOLP;
            Cmd.Parameters.Add("@ID_PERITO", SqlDbType.Int);
            Cmd.Parameters["@ID_PERITO"].Value = ID_USUARIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void AsignarSolicitud_Perito(int ID_SOLP, int IDP, int ID_OFICIOD)
        {
            SqlCommand Cmd = new SqlCommand("asignar_perito_peritaje", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@id_sol", SqlDbType.Int);
            Cmd.Parameters["@id_sol"].Value = ID_SOLP;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = IDP;
            Cmd.Parameters.Add("@id_oficio_designacion", SqlDbType.Int);
            Cmd.Parameters["@id_oficio_designacion"].Value = ID_OFICIOD;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarSolicitudPTemporal(int ID_SP, int ID_USUARIOP)
        {
            SqlCommand Cmd = new SqlCommand("eliminar_pgj_perito_peritaje_temp", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_SOL", SqlDbType.Int);
            Cmd.Parameters["@ID_SOL"].Value = ID_SP;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = @ID_USUARIOP;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarP_SolicitudAsignada(int ID_SP, int ID_PERITO_ASIGNADO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarPeritajeAsignado", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_SOL", SqlDbType.Int);
            Cmd.Parameters["@ID_SOL"].Value = ID_SP;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = @ID_PERITO_ASIGNADO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarImagen_Perito(int ID_SOLP, int ID_CARPETA, int ID_USUARIO, byte[] FOTO, string TITULO, string DESCRIPCION)
        {
            SqlCommand Cmd = new SqlCommand("Inserta_Imagen_Periciales", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_SOLICITUD", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITUD"].Value = ID_SOLP;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;


            Cmd.Parameters.Add("@Imagen", System.Data.SqlDbType.Image);
            Cmd.Parameters["@Imagen"].Value = FOTO; //byteImage;

            Cmd.Parameters.Add("@TITULO", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@TITULO"].Value = TITULO;

            Cmd.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarFotografiaSolicitudPe(int ID_IMAGEN)
        {
            SqlCommand Cmd = new SqlCommand("EliminarFotografiaSolicitud", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@Id_foto", SqlDbType.Int);
            Cmd.Parameters["@Id_foto"].Value = ID_IMAGEN;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarDictamenPericiales(int ID_SP, int ID_USUARIO, string DICTAMEN)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDictamenPericial", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_SOLICITUD", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITUD"].Value = ID_SP;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;


            Cmd.Parameters.Add("@DICTAMEN ", System.Data.SqlDbType.Text);
            Cmd.Parameters["@DICTAMEN "].Value = DICTAMEN;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertarVideo_Perito(int SOLP, int ID_CARPETA, int ID_USUARIO, string VIDEO, string TITULO, string DESCRIPCION)
        {
            SqlCommand Cmd = new SqlCommand("InsertarVideo_Periciales", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_SOLICITUD", SqlDbType.Int);
            Cmd.Parameters["@ID_SOLICITUD"].Value = SOLP;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;


            Cmd.Parameters.Add("@VIDEO", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@VIDEO"].Value = VIDEO;

            Cmd.Parameters.Add("@TITULO", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@TITULO"].Value = TITULO;

            Cmd.Parameters.Add("@DESCRIPCION", System.Data.SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void EliminarVideoPericiales(int ID_VIDEO)
        {
            SqlCommand Cmd = new SqlCommand("EliminarVideoPericiales", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_VIDEO", SqlDbType.Int);
            Cmd.Parameters["@ID_VIDEO"].Value = ID_VIDEO;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }
        #endregion
        // fin modulo periciales


        //REMITIR
        public void insertaRemitidasOrdenOrden(int IdCarpetaNew, int IdCarpetaOld, int IdOrdenNew, int IdOrdenOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasOrdenOrden", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;

            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;

            Cmd.Parameters.Add("@IdOrdenNew", SqlDbType.Int);
            Cmd.Parameters["@IdOrdenNew"].Value = IdOrdenNew;

            Cmd.Parameters.Add("@IdOrdenOld", SqlDbType.Int);
            Cmd.Parameters["@IdOrdenOld"].Value = IdOrdenOld;

            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void insertaRemitidasOrdenOficio(int IdCarpetaNew, int IdCarpetaOld, int IdOficioNew, int IdOficioOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasOrdenOficio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;

            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;

            Cmd.Parameters.Add("@IdOficioNew", SqlDbType.Int);
            Cmd.Parameters["@IdOficioNew"].Value = IdOficioNew;

            Cmd.Parameters.Add("@IdOficioOld", SqlDbType.Int);
            Cmd.Parameters["@IdOficioOld"].Value = IdOficioOld;

            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaCarpetaRemitidas(int IdCarpeta, short IdMunicipio, int IdUnidadAnterior, int IdUnidadNueva , String NucNuevo,
            int IdUsuario, String RacNuevo)
        {
            SqlCommand Cmd = new SqlCommand("InsertaCarpetaRemitida", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidadAnterior", SqlDbType.Int);
            Cmd.Parameters["@IdUnidadAnterior"].Value = IdUnidadAnterior;
            Cmd.Parameters.Add("@IdUnidadNueva", SqlDbType.Int);
            Cmd.Parameters["@IdUnidadNueva"].Value = IdUnidadNueva;
            Cmd.Parameters.Add("@NucNuevo", SqlDbType.VarChar);
            Cmd.Parameters["@NucNuevo"].Value = NucNuevo;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.VarChar);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@RacNuevo", SqlDbType.VarChar);
            Cmd.Parameters["@RacNuevo"].Value = RacNuevo;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void insertaRemitidasHomicidio(int IdCarpetaNew, int IdCarpetaOld, int IdHomicidioNew, int IdHomicidioOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasHomicidio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdHomicidioNew", SqlDbType.Int);
            Cmd.Parameters["@IdHomicidioNew"].Value = IdHomicidioNew;
            Cmd.Parameters.Add("@IdHomicidioOld", SqlDbType.Int);
            Cmd.Parameters["@IdHomicidioOld"].Value = IdHomicidioOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasArma(int IdCarpetaNew, int IdCarpetaOld, int IdArmaNew, int IdArmaOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasArma", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdArmaNew", SqlDbType.Int);
            Cmd.Parameters["@IdArmaNew"].Value = IdArmaNew;
            Cmd.Parameters.Add("@IdArmaOld", SqlDbType.Int);
            Cmd.Parameters["@IdArmaOld"].Value = IdArmaOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasPdf(int IdCarpetaNew, int IdCarpetaOld, int IdPdfNew, int IdPdfOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasPdf", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdPdfNew", SqlDbType.Int);
            Cmd.Parameters["@IdPdfNew"].Value = IdPdfNew;
            Cmd.Parameters.Add("@IdPdfOld", SqlDbType.Int);
            Cmd.Parameters["@IdPdfOld"].Value = IdPdfOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdPdfOld;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasAutorizacion(int IdCarpetaNew, int IdCarpetaOld, int IdAutorizacionNew, int IdAutorizacionOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasAutorizacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdAutorizacionNew", SqlDbType.Int);
            Cmd.Parameters["@IdAutorizacionNew"].Value = IdAutorizacionNew;
            Cmd.Parameters.Add("@IdAutorizacionOld", SqlDbType.Int);
            Cmd.Parameters["@IdAutorizacionOld"].Value = IdAutorizacionOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasVehiculo(int IdCarpetaNew, int IdCarpetaOld, int IdVehiculoNew, int IdvehiculoOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasVehiculo", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdVehiculoNew", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculoNew"].Value = IdVehiculoNew;
            Cmd.Parameters.Add("@IdvehiculoOld", SqlDbType.Int);
            Cmd.Parameters["@IdvehiculoOld"].Value = IdvehiculoOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasImputacion(int IdCarpetaNew, int IdCarpetaOld, int IdImputacionNew, int IdImputacionOld,int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRemitidasImputacion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdImputacionNew", SqlDbType.Int);
            Cmd.Parameters["@IdImputacionNew"].Value = IdImputacionNew;
            Cmd.Parameters.Add("@IdImputacionOld", SqlDbType.Int);
            Cmd.Parameters["@IdImputacionOld"].Value = IdImputacionOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasDetencion(int IdCarpetaNew, int IdCarpetaOld, int IdDetencionNew, int IdDetencionOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasDetencion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdDetencionNew", SqlDbType.Int);
            Cmd.Parameters["@IdDetencionNew"].Value = IdDetencionNew;
            Cmd.Parameters.Add("@IdDetencionOld", SqlDbType.Int);
            Cmd.Parameters["@IdDetencionOld"].Value = IdDetencionOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasLH(int IdCarpetaNew, int IdCarpetaOld, int IdLugarHechosNew, int IdLugarHechosOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasLH", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdLugarHechosNew", SqlDbType.Int);
            Cmd.Parameters["@IdLugarHechosNew"].Value = IdLugarHechosNew;
            Cmd.Parameters.Add("@IdLugarHechosOld", SqlDbType.Int);
            Cmd.Parameters["@IdLugarHechosOld"].Value = IdLugarHechosOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasDelito(int IdCarpetaNew, int IdCarpetaOld, int IdDelitoNew, int IdDelitoOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasDelito", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdDelitoNew", SqlDbType.Int);
            Cmd.Parameters["@IdDelitoNew"].Value = IdDelitoNew;
            Cmd.Parameters.Add("@IdDelitoOld", SqlDbType.Int);
            Cmd.Parameters["@IdDelitoOld"].Value = IdDelitoOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void insertaRemitidasPersonas(int IdCarpetaNew, int IdCarpetaOld, int IdPersonaNew, int IdPersonaOld, int IdMunicipio)
        {
            SqlCommand Cmd = new SqlCommand("insertaRemitidasPersona", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpetaNew", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaNew"].Value = IdCarpetaNew;
            Cmd.Parameters.Add("@IdCarpetaOld", SqlDbType.Int);
            Cmd.Parameters["@IdCarpetaOld"].Value = IdCarpetaOld;
            Cmd.Parameters.Add("@IdPersonaNew", SqlDbType.Int);
            Cmd.Parameters["@IdPersonaNew"].Value = IdPersonaNew;
            Cmd.Parameters.Add("@IdPersonaOld", SqlDbType.Int);
            Cmd.Parameters["@IdPersonaOld"].Value = IdPersonaOld;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNUCUnidadRemitir(String NUC, DateTime FechaNuc,short IdEstadoNuc,DateTime FechaEstadoNuc, short IdUsuarioNuc, short IdFormaInicio, short Detenido, short ID_MUNICIPIO_CARPETA, short IdUnidad, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNUCUnidadRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NUC", SqlDbType.VarChar);
            Cmd.Parameters["@NUC"].Value = NUC;
            Cmd.Parameters.Add("@FechaNuc", SqlDbType.DateTime);
            Cmd.Parameters["@FechaNuc"].Value = FechaNuc;
            Cmd.Parameters.Add("@IdEstadoNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoNuc"].Value = IdEstadoNuc;
            Cmd.Parameters.Add("@FechaEstadoNuc", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEstadoNuc"].Value = FechaEstadoNuc;
            Cmd.Parameters.Add("@IdUsuarioNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNuc"].Value = IdUsuarioNuc;
            Cmd.Parameters.Add("@IdFormaInicio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaInicio"].Value = IdFormaInicio;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaEstadoNuc;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaLugarhechosRemitir(int IdCarpeta, DateTime FechaHechos, String Hora, short IdTipoLugar, short IdMunicipio, Int32 IdLocalidad, Int32 IdColonia, Int32 IdCalle, Int32 IdEntreCalle, Int32 IdYCalle, String NoExterior, String Manzana, String Lote, String Latitud, String Longitud, String Referencias, short ID_MUNICIPIO_LUGAR_HECHOS, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaLugarHechosRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@FechaHechos", SqlDbType.DateTime);
            Cmd.Parameters["@FechaHechos"].Value = FechaHechos;
            Cmd.Parameters.Add("@Hora", SqlDbType.VarChar);
            Cmd.Parameters["@Hora"].Value = Hora;
            Cmd.Parameters.Add("@IdTipoLugar", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoLugar"].Value = IdTipoLugar;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@NoExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NoExterior"].Value = NoExterior;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@Latitud", SqlDbType.VarChar);
            Cmd.Parameters["@Latitud"].Value = Latitud;
            Cmd.Parameters.Add("@Longitud", SqlDbType.VarChar);
            Cmd.Parameters["@Longitud"].Value = Longitud;
            Cmd.Parameters.Add("@Referencias", SqlDbType.VarChar);
            Cmd.Parameters["@Referencias"].Value = Referencias;
            Cmd.Parameters.Add("@ID_MUNICIPIO_LUGAR_HECHOS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_LUGAR_HECHOS"].Value = ID_MUNICIPIO_LUGAR_HECHOS;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            // Cmd.Parameters.Add("@IdLugarHechos", SqlDbType.Int);
            // Cmd.Parameters["@IdLugarHechos"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdLugarHechos = Convert.ToInt32(Cmd.Parameters["@IdLugarHechos"].Value);
            DR.Close();
        }

        public void InsertaDelitoRemitir(int IdCarpeta, short IdDelito, short IdModalidad, short IdViolencia, short IdGrave, short IdPrincipal, int IdLugarHechos, short IdMunicipioDelito, short IdAccion,
        DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDelitoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdModalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModalidad"].Value = IdModalidad;
            Cmd.Parameters.Add("@IdViolencia", SqlDbType.Bit);
            Cmd.Parameters["@IdViolencia"].Value = IdViolencia;
            Cmd.Parameters.Add("@IdGrave", SqlDbType.Bit);
            Cmd.Parameters["@IdGrave"].Value = IdGrave;
            Cmd.Parameters.Add("@IdPrincipal", SqlDbType.Bit);
            Cmd.Parameters["@IdPrincipal"].Value = IdPrincipal;
            Cmd.Parameters.Add("@IdLugarHechos", SqlDbType.Int);
            Cmd.Parameters["@IdLugarHechos"].Value = IdLugarHechos;
            Cmd.Parameters.Add("@IdMunicipioDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioDelito"].Value = IdMunicipioDelito;
            Cmd.Parameters.Add("@ID_ACCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ACCION"].Value = IdAccion;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            //Cmd.Parameters.Add("@IdSujetoInterviene", SqlDbType.Int);
            //Cmd.Parameters["@IdSujetoInterviene"].Value = IdSujetoInterviene;
            //Cmd.Parameters.Add("@IdTipoSujetoInterviene", SqlDbType.Int);
            //Cmd.Parameters["@IdTipoSujetoInterviene"].Value = IdTipoSujetoInterviene;
            //Cmd.Parameters.Add("@FechaRegistroSI", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaRegistroSI"].Value = FechaRegistroSI;
            //Cmd.Parameters.Add("@Activo", SqlDbType.Int);
            //Cmd.Parameters["@Activo"].Value = activo;

            //Cmd.Parameters.Add("@IdConsecutivoDelito", SqlDbType.Int);
            //Cmd.Parameters["@IdConsecutivoDelito"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdConsecutivoDelito = Convert.ToInt32(Cmd.Parameters["@IdConsecutivoDelito"].Value);
            DR.Close();
        }


        public void InsertaPersonaRemitir(String Paterno, String Materno, String Nombre, short IdSexo, String FechaNacimiento, short IdNacionalidad, short IdPais,
            short IdEstado, short IdMunicipio, String RFC, String CURP, String Declaracion, short ID_MUNICIPIO_PERSONA,DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPersonaRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@IdSexo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSexo"].Value = IdSexo;
            Cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar, 10);
            Cmd.Parameters["@FechaNacimiento"].Value = FechaNacimiento;
            Cmd.Parameters.Add("@IdNacionalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNacionalidad"].Value = IdNacionalidad;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@RFC", SqlDbType.VarChar);
            Cmd.Parameters["@RFC"].Value = RFC;
            Cmd.Parameters.Add("@CURP", SqlDbType.VarChar);
            Cmd.Parameters["@CURP"].Value = CURP;
            Cmd.Parameters.Add("@Declaracion", SqlDbType.VarChar);
            Cmd.Parameters["@Declaracion"].Value = Declaracion;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PERSONA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PERSONA"].Value = ID_MUNICIPIO_PERSONA;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            //Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            //Cmd.Parameters["@IdPersona"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void InsertaCarpetaPersonaRemitir(int IdCarpeta, int IdPersona, short IdEstadoCivil, short IdEscolaridad, short IdOcupacion,
           short IdIdentificacion, String Folio, short LeerEscribir, short Vivo, short Detenido, short IdTipoActor, short IdMunicipioPersona, short IdPusoDisposicion, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaCarpetaPersonaRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdEstadoCivil", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoCivil"].Value = IdEstadoCivil;
            Cmd.Parameters.Add("@IdEscolaridad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEscolaridad"].Value = IdEscolaridad;
            Cmd.Parameters.Add("@IdOcupacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOcupacion"].Value = IdOcupacion;
            Cmd.Parameters.Add("@IdIdentificacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacion"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@Folio", SqlDbType.VarChar);
            Cmd.Parameters["@Folio"].Value = Folio;
            Cmd.Parameters.Add("@LeerEscribir", SqlDbType.Bit);
            Cmd.Parameters["@LeerEscribir"].Value = LeerEscribir;
            Cmd.Parameters.Add("@Vivo", SqlDbType.Bit);
            Cmd.Parameters["@Vivo"].Value = Vivo;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@IdTipoActor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoActor"].Value = IdTipoActor;
            Cmd.Parameters.Add("@ID_PUSO_DISPOSICION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PUSO_DISPOSICION"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PEROSNA_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PEROSNA_CARPETA"].Value = IdMunicipioPersona;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            //Cmd.Parameters.Add("@IdPersonaCarpeta", SqlDbType.Int );
            //Cmd.Parameters["@IdPersonaCarpeta"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            // IdPersonaCarpeta = Convert.ToInt32(Cmd.Parameters["@IdPersonaCarpeta"].Value);
            DR.Close();
        }

        public void InsertaPersonaDomicilioRemitir(int IdPersona, short IdPais, short IdEstado, short IdMunicipio, int IdLocalidad, int IdColonia, int IdCalle, int IdEntreCalle, int IdYCalle, String Numero, String Manzana, String Lote, short ID_MUNICIPIO_DOMICILIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPersonaDomicilioRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEstado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstado"].Value = IdEstado;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@Numero", SqlDbType.VarChar);
            Cmd.Parameters["@Numero"].Value = Numero;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@ID_MUNICIPIO_DOMICILIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_DOMICILIO"].Value = ID_MUNICIPIO_DOMICILIO;
            //Cmd.Parameters.Add("@IdDomicilio", SqlDbType.Int );
            //Cmd.Parameters["@IdDomicilio"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdDomicilio = Convert.ToInt32(Cmd.Parameters["@IdDomicilio"].Value);
            DR.Close();
        }

        public void InsertaAliasRemitir(Int32 IdPersona, String Alias, short ID_MUNICIPIO_ALIAS, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaAliasRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Alias", SqlDbType.VarChar);
            Cmd.Parameters["@Alias"].Value = Alias;
            Cmd.Parameters.Add("@ID_MUNICIPIO_ALIAS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_ALIAS"].Value = ID_MUNICIPIO_ALIAS;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdAlias = Convert.ToInt32(Cmd.Parameters["@IdAlias"].Value);
            DR.Close();
        }

        public void InsertaMedioContactoRemitir(Int32 IdPersona, short IdTipoMedioContacto, String MedioContacto, short ID_MUNICIPIO_CONTACTO,short Activo,DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaMedioContactoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdTipoMedioContacto", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMedioContacto"].Value = IdTipoMedioContacto;
            Cmd.Parameters.Add("@MedioContacto", SqlDbType.VarChar);
            Cmd.Parameters["@MedioContacto"].Value = MedioContacto;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CONTACTO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CONTACTO"].Value = ID_MUNICIPIO_CONTACTO;
            Cmd.Parameters.Add("@Activo", SqlDbType.SmallInt);
            Cmd.Parameters["@Activo"].Value = Activo;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            //Cmd.Parameters.Add("@IdMedioContacto", SqlDbType.Int);
            //Cmd.Parameters["@IdMedioContacto"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaArchivoTemporalRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, short IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("InsertaArchivoTemporalRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaacuerdoAbsInvRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, short IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("InsertaAcuerdoAbsInv", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaCriterioOportunidadRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, short IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("InsertaCriterioOportunidad", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaIncompetenciaRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, short IdUsuario, DateTime FechaRegistro, short IdAgencia)
        {
            SqlCommand Cmd = new SqlCommand("InsertaIncompetencia", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            Cmd.Parameters.Add("@IdAgencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAgencia"].Value = IdAgencia;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaMediosAlternativosRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaMediosAlternativos", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNoEjercicioRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaNoEjercicio", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudAcuerdosReparatoriosRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short MediosAlternosPJE,
            short AcuerdoReparatorio, DateTime FechaAcuerdo, DateTime FechaAProbacion, short IdTipoAcuerdo, String ObservacionesAcuerdo,
            short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaAcuerdoReparatorioRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@MediosAlternosPJE", SqlDbType.Bit);
            Cmd.Parameters["@MediosAlternosPJE"].Value = MediosAlternosPJE;
            Cmd.Parameters.Add("@AcuerdoReparatorio", SqlDbType.Bit);
            Cmd.Parameters["@AcuerdoReparatorio"].Value = AcuerdoReparatorio;
            Cmd.Parameters.Add("@FechaAcuerdo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAcuerdo"].Value = FechaAcuerdo;
            Cmd.Parameters.Add("@FechaAProbacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAProbacion"].Value = FechaAProbacion;
            Cmd.Parameters.Add("@IdTipoAcuerdo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoAcuerdo"].Value = IdTipoAcuerdo;
            Cmd.Parameters.Add("@ObservacionesAcuerdo", SqlDbType.VarChar);
            Cmd.Parameters["@ObservacionesAcuerdo"].Value = ObservacionesAcuerdo;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudDetencionRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, DateTime FechaAudiencia, short Legal, String ObservacionesDetencion,short IdProcedimientoDetencion, DateTime FechaDetencion, short IdSupuestoFlagrancia, 
        short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDetencionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@FechaAudiencia", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAudiencia"].Value = FechaAudiencia;
            Cmd.Parameters.Add("@Legal", SqlDbType.Bit);
            Cmd.Parameters["@Legal"].Value = Legal;
            Cmd.Parameters.Add("@ObservacionesDetencion", SqlDbType.VarChar);
            Cmd.Parameters["@ObservacionesDetencion"].Value = ObservacionesDetencion;
            Cmd.Parameters.Add("@IdProcedimientoDetencion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedimientoDetencion"].Value = IdProcedimientoDetencion;
            Cmd.Parameters.Add("@FechaDetencion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaDetencion"].Value = FechaDetencion;
            Cmd.Parameters.Add("@IdSupuestoFlagrancia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSupuestoFlagrancia"].Value = IdSupuestoFlagrancia;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudImputacionRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short Imputacion, DateTime FechaImputacion,
            String ObservacionesImputacion,short Vinculacion, DateTime FechaVinculacion, short IdUsuario,
            DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaImputacionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Imputacion", SqlDbType.Bit);
            Cmd.Parameters["@Imputacion"].Value = Imputacion;
            Cmd.Parameters.Add("@FechaImputacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaImputacion"].Value = FechaImputacion;
            Cmd.Parameters.Add("@ObservacionesImputacion", SqlDbType.VarChar);
            Cmd.Parameters["@ObservacionesImputacion"].Value = ObservacionesImputacion;
            Cmd.Parameters.Add("@Vinculacion", SqlDbType.Bit);
            Cmd.Parameters["@Vinculacion"].Value = Vinculacion;
            Cmd.Parameters.Add("@FechaVinculacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaVinculacion"].Value = FechaVinculacion;
            //Cmd.Parameters.Add("@FechaNoVinculacion", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaNoVinculacion"].Value = FechaNoVinculacion;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudMedidaCautelarRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short Procedente, DateTime FechaMedida,
    short IdTipoMedida, DateTime FechaMedidaDel, DateTime FechaMedidaAl, short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaMedidaCautelarRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Procedente", SqlDbType.Bit);
            Cmd.Parameters["@Procedente"].Value = Procedente;
            Cmd.Parameters.Add("@FechaMedida", SqlDbType.DateTime);
            Cmd.Parameters["@FechaMedida"].Value = FechaMedida;
            Cmd.Parameters.Add("@IdTipoMedida", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMedida"].Value = IdTipoMedida;
            Cmd.Parameters.Add("@FechaMedidaDel", SqlDbType.DateTime);
            Cmd.Parameters["@FechaMedidaDel"].Value = FechaMedidaDel;
            Cmd.Parameters.Add("@FechaMedidaAl", SqlDbType.DateTime);
            Cmd.Parameters["@FechaMedidaAl"].Value = FechaMedidaAl;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudMedidaProteccionRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short Procedente, DateTime FechaMedida,
short IdTipoMedida, short PlazoMedida,  short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaMedidaProteccionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Procedente", SqlDbType.Bit);
            Cmd.Parameters["@Procedente"].Value = Procedente;
            Cmd.Parameters.Add("@FechaMedida", SqlDbType.DateTime);
            Cmd.Parameters["@FechaMedida"].Value = FechaMedida;
            Cmd.Parameters.Add("@IdTipoMedida", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMedida"].Value = IdTipoMedida;
            Cmd.Parameters.Add("@PlazoMedida", SqlDbType.SmallInt);
            Cmd.Parameters["@PlazoMedida"].Value = PlazoMedida;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudOrdenesRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short SolicitoOrden, DateTime FechaEstadoOrden,
short IdEstadoOrden, short IdTipoOrden, String ObservacionesOrden,short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaOrdenesRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@SolicitoOrden", SqlDbType.Bit);
            Cmd.Parameters["@SolicitoOrden"].Value = SolicitoOrden;
            Cmd.Parameters.Add("@FechaOrden", SqlDbType.DateTime);
            Cmd.Parameters["@FechaOrden"].Value = FechaEstadoOrden;
            Cmd.Parameters.Add("@IdEstadoOrden", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoOrden"].Value = IdEstadoOrden;
            Cmd.Parameters.Add("@IdTipoOrden", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoOrden"].Value = IdTipoOrden;
            Cmd.Parameters.Add("@ObservacionesOrden", SqlDbType.VarChar);
            Cmd.Parameters["@ObservacionesOrden"].Value = ObservacionesOrden;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudPlazoInvestigacionRemitir(int IdCarpeta, short IdMunicipio, short Plazo, short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPlazoInvestigacionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Plazo", SqlDbType.SmallInt);
            Cmd.Parameters["@Plazo"].Value = Plazo;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudProcedimientoAbreviadoRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short Procedimiento,
            DateTime FechaAudiencia,short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaProcedimientoAbreviadoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Procedimiento", SqlDbType.Bit);
            Cmd.Parameters["@Procedimiento"].Value = Procedimiento;
            Cmd.Parameters.Add("@FechaAudiencia", SqlDbType.DateTime);
            Cmd.Parameters["@FechaAudiencia"].Value = FechaAudiencia;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudSentenciaRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short IdDelito, short IdTipoSentencia,
    DateTime FechaSentencia, short IdTipoSancion,int Id_Persona_Ofendido, short IdUsuario, DateTime FechaRegistro,string Observaciones)
        {
            SqlCommand Cmd = new SqlCommand("InsertaSentenciaRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdTipoSentencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSentencia"].Value = IdTipoSentencia;
            Cmd.Parameters.Add("@FechaSentencia", SqlDbType.DateTime);
            Cmd.Parameters["@FechaSentencia"].Value = FechaSentencia;
            Cmd.Parameters.Add("@IdTipoSancion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSancion"].Value = IdTipoSancion;
            Cmd.Parameters.Add("@Id_Persona_Ofendido", SqlDbType.Int);
            Cmd.Parameters["@Id_Persona_Ofendido"].Value = Id_Persona_Ofendido;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudSobreseimientoRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short Sobreseimiento, 
DateTime FechaSobreseimiento, String ObservacionesSobreseimiento,  short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaSobreseimientoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Sobreseimiento", SqlDbType.Bit);
            Cmd.Parameters["@Sobreseimiento"].Value = Sobreseimiento;
            Cmd.Parameters.Add("@FechaSobreseimiento", SqlDbType.DateTime);
            Cmd.Parameters["@FechaSobreseimiento"].Value = FechaSobreseimiento;
            Cmd.Parameters.Add("@ObservacionesSobreseimiento", SqlDbType.VarChar);
            Cmd.Parameters["@ObservacionesSobreseimiento"].Value = ObservacionesSobreseimiento;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudSuspensionRemitir(int IdCarpeta, short IdMunicipio, int IdPersona, short Suspension,
            short RevocaSuspension, DateTime FechaSuspencion, DateTime FechaInicioSuspencion, DateTime FechaFinSupension,
            DateTime FechaReanudacion, short IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaSuspencionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Suspencion", SqlDbType.Bit);
            Cmd.Parameters["@Suspencion"].Value = Suspension;
            Cmd.Parameters.Add("@RevocaSuspencion", SqlDbType.Bit);
            Cmd.Parameters["@RevocaSuspencion"].Value = RevocaSuspension;
            Cmd.Parameters.Add("@FechaSuspencion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaSuspencion"].Value = FechaSuspencion;
            Cmd.Parameters.Add("@FechaInicioSuspencion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaInicioSuspencion"].Value = FechaInicioSuspencion;
            Cmd.Parameters.Add("@FechaFinSuspencion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaFinSuspencion"].Value = FechaFinSupension;
            Cmd.Parameters.Add("@FechaReanudacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaReanudacion"].Value = FechaReanudacion;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaJudVinculacionDelitosRemitir(int Imputacion, short IdDelito, short IdModalidad,short IdCalificacion)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVinculacionDelitosRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdImputacion", SqlDbType.Int);
            Cmd.Parameters["@IDImputacion"].Value = Imputacion;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdModalidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModalidad"].Value = IdModalidad;
            Cmd.Parameters.Add("@IdCalificacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCalificacion"].Value = IdCalificacion;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDefensorRemitir(int IdCarpeta, int IdPersona, String Paterno, String Materno, String Nombre, short DefensorPubPriv, short IdTipoActor, short IdIdentificacion, String Folio, String Telefono, short IdNacionalidad, short IdPaisOrigen, short IdEstadoOrigen, short IdMunicipioOrigen, short IdPais, short IdEstado, short IdMunicipio,
        int IdLocalidad, int IdColonia, int IdCalle, int IdEntreCalle, int IdYCalle, String Numero, String Manzana, String Lote, short ID_MUNICIPIO_DEFENSOR, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDefensorRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Defensor_Pub_Priv", SqlDbType.SmallInt);
            Cmd.Parameters["@Defensor_Pub_Priv"].Value = DefensorPubPriv;
            Cmd.Parameters.Add("@IdTipoActor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoActor"].Value = IdTipoActor;
            Cmd.Parameters.Add("@ID_IDENTIFICACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_IDENTIFICACION"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@FOLIO"].Value = Folio;
            Cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 50);
            Cmd.Parameters["@TELEFONO"].Value = Telefono;
            Cmd.Parameters.Add("@ID_NACIONALIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_NACIONALIDAD"].Value = IdNacionalidad;
            Cmd.Parameters.Add("@ID_PAIS_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PAIS_ORIGEN"].Value = IdPaisOrigen;
            Cmd.Parameters.Add("@ID_ESTADO_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_ORIGEN"].Value = IdEstadoOrigen;
            Cmd.Parameters.Add("@ID_MUNICIPIO_ORIGEN", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_ORIGEN"].Value = IdMunicipioOrigen;
            Cmd.Parameters.Add("@Id_Pais", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Pais"].Value = IdPais;
            Cmd.Parameters.Add("@Id_Estado", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Estado"].Value = IdEstado;
            Cmd.Parameters.Add("@Id_Municipio", SqlDbType.SmallInt);
            Cmd.Parameters["@Id_Municipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Id_Localidad", SqlDbType.Int);
            Cmd.Parameters["@Id_Localidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@Id_Colonia", SqlDbType.Int);
            Cmd.Parameters["@Id_Colonia"].Value = IdColonia;
            Cmd.Parameters.Add("@Id_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Calle"].Value = IdCalle;
            Cmd.Parameters.Add("@Id_Entre_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Entre_Calle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@Id_Y_Calle", SqlDbType.Int);
            Cmd.Parameters["@Id_Y_Calle"].Value = IdYCalle;
            Cmd.Parameters.Add("@Numero", SqlDbType.VarChar);
            Cmd.Parameters["@Numero"].Value = Numero;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@ID_MUNICIPIO_DEFENSOR", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_DEFENSOR"].Value = ID_MUNICIPIO_DEFENSOR;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDenuncianteRemitir(int ID_CARPETA, short IdMunicipio, short ID_PUSO_DISPOSICION, String NUMERO_OFICIO, short ID_USUARIO, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDenuncianteAutoridadRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_PUSO_DISPOSICION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PUSO_DISPOSICION"].Value = ID_PUSO_DISPOSICION;
            Cmd.Parameters.Add("@NUMERO_OFICIO", SqlDbType.VarChar);
            Cmd.Parameters["@NUMERO_OFICIO"].Value = NUMERO_OFICIO;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDescripcionHechosRemitir(int IdCarpeta, String Descripcion, short ID_MUNICIPIO_HECHOS, String PREGUNTAS_PNL, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaDescripcionHechosRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;
            Cmd.Parameters.Add("@ID_MUNICIPIO_HECHOS", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_HECHOS"].Value = ID_MUNICIPIO_HECHOS;
            Cmd.Parameters.Add("@PREGUNTAS_PNL", SqlDbType.VarChar);
            Cmd.Parameters["@PREGUNTAS_PNL"].Value = PREGUNTAS_PNL;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdHechos = Convert.ToInt32(Cmd.Parameters["@IdHechos"].Value);
            DR.Close();
        }

        public void InsertarDetencionDatosRemitir(int ID_PERSONA, int ID_USUARIO, int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_LUGAR_DETENCION, string FOLIO, string MOTIVO_DETENCION, string TIEMPO_TRANSLADO, string LUGAR_PUESTA_DISPOSICION, string AUTORIDAD_PUESTO_DISPOSICION, string NOMBRE_RECIBIO, string CARGO_RECIBIO, string CAUSA_NO_FIRMA, string HORA_DETENCION, DateTime FECHA_DETENCION, short ID_PREFERENCIA_SEXUAL, short ID_ESTADO_DETENIDO, Byte[] FOTO_DETENIDO,
                                    string ASUNTO, string DIRIGIDO_A, string AGENTES, short ID_PARTICIPACION, short OPERATIVO, string NOMBRE_COMANDANTE, string DESCRIPCION_HECHOS, string REFERENCIA_UBICACION, short DETENIDO_POR, short ID_PROCEDIMIENTO_DETENCION, short ID_SUPUESTO_FLAGRANCIA, short LIBERTAD_INVESTIGACION, short ID_MOTIVO_LIBERACION, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertarDetencionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = ID_USUARIO;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_LUGAR_DETENCION", SqlDbType.Int);
            Cmd.Parameters["@ID_LUGAR_DETENCION"].Value = ID_LUGAR_DETENCION;

            Cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar);
            Cmd.Parameters["@FOLIO"].Value = FOLIO;

            Cmd.Parameters.Add("@MOTIVO_DETENCION", SqlDbType.VarChar);
            Cmd.Parameters["@MOTIVO_DETENCION"].Value = MOTIVO_DETENCION;

            Cmd.Parameters.Add("@TIEMPO_TRANSLADO", SqlDbType.VarChar);
            Cmd.Parameters["@TIEMPO_TRANSLADO"].Value = TIEMPO_TRANSLADO;

            Cmd.Parameters.Add("@LUGAR_PUESTA_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@LUGAR_PUESTA_DISPOSICION"].Value = LUGAR_PUESTA_DISPOSICION;

            Cmd.Parameters.Add("@AUTORIDAD_PUESTO_DISPOSICION", SqlDbType.VarChar);
            Cmd.Parameters["@AUTORIDAD_PUESTO_DISPOSICION"].Value = AUTORIDAD_PUESTO_DISPOSICION;

            Cmd.Parameters.Add("@NOMBRE_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_RECIBIO"].Value = NOMBRE_RECIBIO;

            Cmd.Parameters.Add("@CARGO_RECIBIO", SqlDbType.VarChar);
            Cmd.Parameters["@CARGO_RECIBIO"].Value = CARGO_RECIBIO;

            Cmd.Parameters.Add("@CAUSA_NO_FIRMA", SqlDbType.VarChar);
            Cmd.Parameters["@CAUSA_NO_FIRMA"].Value = CAUSA_NO_FIRMA;

            Cmd.Parameters.Add("@HORA_DETENCION", SqlDbType.VarChar, 8);
            Cmd.Parameters["@HORA_DETENCION"].Value = HORA_DETENCION;

            Cmd.Parameters.Add("@FECHA_DETENCION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_DETENCION"].Value = FECHA_DETENCION;

            Cmd.Parameters.Add("@ID_PREFERENCIA_SEXUAL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PREFERENCIA_SEXUAL"].Value = ID_PREFERENCIA_SEXUAL;

            Cmd.Parameters.Add("@ID_ESTADO_DETENIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_DETENIDO"].Value = ID_ESTADO_DETENIDO;

            Cmd.Parameters.Add("@FOTO_DETENIDO", SqlDbType.Image);
            Cmd.Parameters["@FOTO_DETENIDO"].Value = FOTO_DETENIDO;

            Cmd.Parameters.Add("@ASUNTO", SqlDbType.VarChar);
            Cmd.Parameters["@ASUNTO"].Value = ASUNTO;

            Cmd.Parameters.Add("@DIRIGIDO_A", SqlDbType.VarChar);
            Cmd.Parameters["@DIRIGIDO_A"].Value = DIRIGIDO_A;

            Cmd.Parameters.Add("@AGENTES", SqlDbType.VarChar);
            Cmd.Parameters["@AGENTES"].Value = AGENTES;

            Cmd.Parameters.Add("@ID_PARTICIPACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PARTICIPACION"].Value = ID_PARTICIPACION;

            Cmd.Parameters.Add("@OPERATIVO", SqlDbType.SmallInt);
            Cmd.Parameters["@OPERATIVO"].Value = OPERATIVO;

            Cmd.Parameters.Add("@NOMBRE_COMANDANTE", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_COMANDANTE"].Value = NOMBRE_COMANDANTE;

            Cmd.Parameters.Add("@DESCRIPCION_HECHOS", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_HECHOS"].Value = DESCRIPCION_HECHOS;

            Cmd.Parameters.Add("@REFERENCIA_UBICACION", SqlDbType.VarChar);
            Cmd.Parameters["@REFERENCIA_UBICACION"].Value = REFERENCIA_UBICACION;

            Cmd.Parameters.Add("@DETENIDO_POR", SqlDbType.SmallInt);
            Cmd.Parameters["@DETENIDO_POR"].Value = DETENIDO_POR;

            Cmd.Parameters.Add("@ID_PROCEDIMIENTO_DETENCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PROCEDIMIENTO_DETENCION"].Value = ID_PROCEDIMIENTO_DETENCION;

            Cmd.Parameters.Add("@ID_SUPUESTO_FLAGRANCIA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUPUESTO_FLAGRANCIA"].Value = ID_SUPUESTO_FLAGRANCIA;

            Cmd.Parameters.Add("@LIBERTAD_INVESTIGACION", SqlDbType.SmallInt);
            Cmd.Parameters["@LIBERTAD_INVESTIGACION"].Value = LIBERTAD_INVESTIGACION;

            Cmd.Parameters.Add("@ID_MOTIVO_LIBERACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOTIVO_LIBERACION"].Value = ID_MOTIVO_LIBERACION;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void InsertaLugarDetencionRemitir(int IdCarpeta, DateTime FechaHechos, String Hora, short IdTipoLugar, short IdMunicipio, Int32 IdLocalidad, 
        Int32 IdColonia, Int32 IdCalle, Int32 IdEntreCalle, Int32 IdYCalle, String NoExterior, String Manzana, String Lote, String Latitud, String Longitud,
        String Referencias, short ID_MUNICIPIO_LUGAR_DETENCION, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaLugarDetencionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@FechaHechos", SqlDbType.DateTime);
            Cmd.Parameters["@FechaHechos"].Value = FechaHechos;
            Cmd.Parameters.Add("@Hora", SqlDbType.VarChar);
            Cmd.Parameters["@Hora"].Value = Hora;
            Cmd.Parameters.Add("@IdTipoLugar", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoLugar"].Value = IdTipoLugar;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdLocalidad", SqlDbType.Int);
            Cmd.Parameters["@IdLocalidad"].Value = IdLocalidad;
            Cmd.Parameters.Add("@IdColonia", SqlDbType.Int);
            Cmd.Parameters["@IdColonia"].Value = IdColonia;
            Cmd.Parameters.Add("@IdCalle", SqlDbType.Int);
            Cmd.Parameters["@IdCalle"].Value = IdCalle;
            Cmd.Parameters.Add("@IdEntreCalle", SqlDbType.Int);
            Cmd.Parameters["@IdEntreCalle"].Value = IdEntreCalle;
            Cmd.Parameters.Add("@IdYCalle", SqlDbType.Int);
            Cmd.Parameters["@IdYCalle"].Value = IdYCalle;
            Cmd.Parameters.Add("@NoExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NoExterior"].Value = NoExterior;
            Cmd.Parameters.Add("@Manzana", SqlDbType.VarChar);
            Cmd.Parameters["@Manzana"].Value = Manzana;
            Cmd.Parameters.Add("@Lote", SqlDbType.VarChar);
            Cmd.Parameters["@Lote"].Value = Lote;
            Cmd.Parameters.Add("@Latitud", SqlDbType.VarChar);
            Cmd.Parameters["@Latitud"].Value = Latitud;
            Cmd.Parameters.Add("@Longitud", SqlDbType.VarChar);
            Cmd.Parameters["@Longitud"].Value = Longitud;
            Cmd.Parameters.Add("@Referencias", SqlDbType.VarChar);
            Cmd.Parameters["@Referencias"].Value = Referencias;
            Cmd.Parameters.Add("@ID_MUNICIPIO_LUGAR_DETENCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_LUGAR_DETENCION"].Value = ID_MUNICIPIO_LUGAR_DETENCION;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            // Cmd.Parameters.Add("@IdLugarHechos", SqlDbType.Int);
            // Cmd.Parameters["@IdLugarHechos"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdLugarHechos = Convert.ToInt32(Cmd.Parameters["@IdLugarHechos"].Value);
            DR.Close();
        }

        public void PNLInsertaSujetoIntevieneRemitir(int IdCarpeta, int IdMunicipio, int IdDelito, int IdSujetoInterviene, int IdTipoSujetoInterviene, int Activo, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaSujetosIntervieneRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.Int);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;
            Cmd.Parameters.Add("@IdSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdSujetoInterviene"].Value = IdSujetoInterviene;
            Cmd.Parameters.Add("@IdTipoSujetoInterviene", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujetoInterviene"].Value = IdTipoSujetoInterviene;
            Cmd.Parameters.Add("@Activo", SqlDbType.Int);
            Cmd.Parameters["@Activo"].Value = Activo;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void InsertaBoletinPDFRemitir(int IdCarpeta, int IdMunicipio, int IdTipoBoletin, int IdPersona, byte[] Pdf, String numeroreporte, int IdUsuario, DateTime FechaRegistro, int Activo)
        {
            SqlCommand Cmd = new SqlCommand("InsertaBoletinPDFRemitir", NUC_PNL.CnnPNL);
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
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            Cmd.Parameters.Add("@Activo", SqlDbType.Int);
            Cmd.Parameters["@Activo"].Value = Activo;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void PNL_InsertaDatosGeneralesRemitir(int IdDatosGenerales, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, int IdEtnia, DateTime FechaUltimoAvistamiento, short IdActividad)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaDatosGenerales", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDatosGenerales", SqlDbType.Int);
            Cmd.Parameters["@IdDatosGenerales"].Value = IdDatosGenerales;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdEtnia", SqlDbType.Int);
            Cmd.Parameters["@IdEtnia"].Value = IdEtnia;
            Cmd.Parameters.Add("@FechaUltimoAvistamiento", SqlDbType.Date);
            Cmd.Parameters["@FechaUltimoAvistamiento"].Value = FechaUltimoAvistamiento;
            Cmd.Parameters.Add("@IdActividad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdActividad"].Value = @IdActividad;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void PNL_InsertaPertenenciaSocialRemitir(int IdPertenenciaSocial, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, string MiembroONG, string Sindicalista, string Reinsertado, string GrupoReligioso, string OrganismoEstatal, string GrupoDH, string Otros)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaPertenenciaSocial", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPertenenciaSocial", SqlDbType.Int);
            Cmd.Parameters["@IdPertenenciaSocial"].Value = IdPertenenciaSocial;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@MiembroONG", SqlDbType.NVarChar);
            Cmd.Parameters["@MiembroONG"].Value = MiembroONG;
            Cmd.Parameters.Add("@Sindicalista", SqlDbType.NVarChar);
            Cmd.Parameters["@Sindicalista"].Value = Sindicalista;
            Cmd.Parameters.Add("@Reinsertado", SqlDbType.NVarChar);
            Cmd.Parameters["@Reinsertado"].Value = Reinsertado;
            Cmd.Parameters.Add("@GrupoReligioso", SqlDbType.NVarChar);
            Cmd.Parameters["@GrupoReligioso"].Value = GrupoReligioso;
            Cmd.Parameters.Add("@OrganismoEstatal", SqlDbType.NVarChar);
            Cmd.Parameters["@OrganismoEstatal"].Value = OrganismoEstatal;
            Cmd.Parameters.Add("@GrupoDH", SqlDbType.NVarChar);
            Cmd.Parameters["@GrupoDH"].Value = GrupoDH;
            Cmd.Parameters.Add("@Otros", SqlDbType.NVarChar);
            Cmd.Parameters["@Otros"].Value = Otros;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void PNL_InsertaDiscapacidadesRemitir(int IdDiscapacidades, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdDiscapacidadMental, string OtraDiscapacidadMental, short IdDiscapacidadFisica, string OtraDiscapacidadFisica, string Padecimientos, string EnfermedadSistematica, string EnfermedadMental, string EnfermedadPiel, string Adicciones, string Medicamentos, string Cirugias, short Embarazo, bool Cesarea, bool PartoNatural, bool Aborto, short ControlNatal, string OtroControlNatal)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDiscapacidades", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdDiscapacidades", SqlDbType.Int);
            Cmd.Parameters["@IdDiscapacidades"].Value = IdDiscapacidades;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdDiscapacidadMental", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDiscapacidadMental"].Value = IdDiscapacidadMental;
            Cmd.Parameters.Add("@OtraDiscapacidadMental", SqlDbType.VarChar);
            Cmd.Parameters["@OtraDiscapacidadMental"].Value = OtraDiscapacidadMental;
            Cmd.Parameters.Add("@IdDiscapacidadFisica", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDiscapacidadFisica"].Value = IdDiscapacidadFisica;
            Cmd.Parameters.Add("@OtraDiscapacidadFisica", SqlDbType.VarChar);
            Cmd.Parameters["@OtraDiscapacidadFisica"].Value = OtraDiscapacidadFisica;
            Cmd.Parameters.Add("@Padecimientos", SqlDbType.VarChar);
            Cmd.Parameters["@Padecimientos"].Value = Padecimientos;
            Cmd.Parameters.Add("@EnfermedadSistematica", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadSistematica"].Value = EnfermedadSistematica;
            Cmd.Parameters.Add("@EnfermedadMental", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadMental"].Value = EnfermedadMental;
            Cmd.Parameters.Add("@EnfermedadPiel", SqlDbType.VarChar);
            Cmd.Parameters["@EnfermedadPiel"].Value = EnfermedadPiel;
            Cmd.Parameters.Add("@Adicciones", SqlDbType.VarChar);
            Cmd.Parameters["@Adicciones"].Value = Adicciones;
            Cmd.Parameters.Add("@Medicamentos", SqlDbType.VarChar);
            Cmd.Parameters["@Medicamentos"].Value = Medicamentos;
            Cmd.Parameters.Add("@Cirugias", SqlDbType.VarChar);
            Cmd.Parameters["@Cirugias"].Value = Cirugias;
            Cmd.Parameters.Add("@Embarazo", SqlDbType.SmallInt);
            Cmd.Parameters["@Embarazo"].Value = Embarazo;
            Cmd.Parameters.Add("@Cesarea", SqlDbType.Bit);
            Cmd.Parameters["@Cesarea"].Value = Cesarea;
            Cmd.Parameters.Add("@PartoNatural", SqlDbType.Bit);
            Cmd.Parameters["@PartoNatural"].Value = PartoNatural;
            Cmd.Parameters.Add("@Aborto", SqlDbType.Bit);
            Cmd.Parameters["@Aborto"].Value = Aborto;
            Cmd.Parameters.Add("@ControlNatal", SqlDbType.SmallInt);
            Cmd.Parameters["@ControlNatal"].Value = ControlNatal;
            Cmd.Parameters.Add("@OtroControlNatal", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroControlNatal"].Value = OtroControlNatal;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void PNL_InsertaInfoFinancieraRemitir(int IdInfoFinanciera, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdBanco, string NumCuenta, string TipoCuenta, short TarjetaCredito, string @NumTarjetaCredito, short TarjetaDebito, string NumTarjetaDebito, string TarjetaDepartamental, string NumTarjetaDepartamental)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaInfoFinanciera", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdInfoFinanciera", SqlDbType.Int);
            Cmd.Parameters["@IdInfoFinanciera"].Value = IdInfoFinanciera;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdBanco", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBanco"].Value = IdBanco;
            Cmd.Parameters.Add("@NumCuenta", SqlDbType.NVarChar);
            Cmd.Parameters["@NumCuenta"].Value = NumCuenta;
            Cmd.Parameters.Add("@TipoCuenta", SqlDbType.NVarChar);
            Cmd.Parameters["@TipoCuenta"].Value = TipoCuenta;
            Cmd.Parameters.Add("@TarjetaCredito", SqlDbType.SmallInt);
            Cmd.Parameters["@TarjetaCredito"].Value = TarjetaCredito;
            Cmd.Parameters.Add("@NumTarjetaCredito", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaCredito"].Value = NumTarjetaCredito;
            Cmd.Parameters.Add("@TarjetaDebito", SqlDbType.SmallInt);
            Cmd.Parameters["@TarjetaDebito"].Value = TarjetaDebito;
            Cmd.Parameters.Add("@NumTarjetaDebito", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaDebito"].Value = NumTarjetaDebito;
            Cmd.Parameters.Add("@TarjetaDepartamental", SqlDbType.NVarChar);
            Cmd.Parameters["@TarjetaDepartamental"].Value = TarjetaDepartamental;
            Cmd.Parameters.Add("@NumTarjetaDepartamental", SqlDbType.NVarChar);
            Cmd.Parameters["@NumTarjetaDepartamental"].Value = NumTarjetaDepartamental;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void PNL_InsertaInformacionOdontologicaRemitir(int IdInfoOdontologica, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short ExpedienteDental, string Odontologo, short TamañoDientes, short DientesCompletos, short DientesSeparados, short DientesGirados, short DientesApiñonados, short DientesManchados, short DientesDesgaste, short Resinas, short Amalgamas, short CoronasMetalicas, short CoronasEsteticas, short Endodoncia, short Blanqueamiento, short Incrustacion, string OtroTratamiento, short IdProtesis, short Braquets, short Retenedores, short Implantes, string OtroAditamento, short AditamentoenDesaparicion, string AusenciaDental, string HabitosDentales)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaInformacionOdontologica", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdInfoOdontologica", SqlDbType.Int);
            Cmd.Parameters["@IdInfoOdontologica"].Value = IdInfoOdontologica;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@ExpedienteDental", SqlDbType.SmallInt);
            Cmd.Parameters["@ExpedienteDental"].Value = ExpedienteDental;
            Cmd.Parameters.Add("@Odontologo", SqlDbType.NVarChar);
            Cmd.Parameters["@Odontologo"].Value = Odontologo;
            Cmd.Parameters.Add("@TamañoDientes", SqlDbType.SmallInt);
            Cmd.Parameters["@TamañoDientes"].Value = TamañoDientes;
            Cmd.Parameters.Add("@DientesCompletos", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesCompletos"].Value = DientesCompletos;
            Cmd.Parameters.Add("@DientesSeparados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesSeparados"].Value = DientesSeparados;
            Cmd.Parameters.Add("@DientesGirados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesGirados"].Value = DientesGirados;
            Cmd.Parameters.Add("@DientesApiñonados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesApiñonados"].Value = DientesApiñonados;
            Cmd.Parameters.Add("@DientesManchados", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesManchados"].Value = DientesManchados;
            Cmd.Parameters.Add("@DientesDesgaste", SqlDbType.SmallInt);
            Cmd.Parameters["@DientesDesgaste"].Value = DientesDesgaste;
            Cmd.Parameters.Add("@Resinas", SqlDbType.SmallInt);
            Cmd.Parameters["@Resinas"].Value = Resinas;
            Cmd.Parameters.Add("@Amalgamas", SqlDbType.SmallInt);
            Cmd.Parameters["@Amalgamas"].Value = Amalgamas;
            Cmd.Parameters.Add("@CoronasMetalicas", SqlDbType.SmallInt);
            Cmd.Parameters["@CoronasMetalicas"].Value = CoronasMetalicas;
            Cmd.Parameters.Add("@CoronasEsteticas", SqlDbType.SmallInt);
            Cmd.Parameters["@CoronasEsteticas"].Value = CoronasEsteticas;
            Cmd.Parameters.Add("@Endodoncia", SqlDbType.SmallInt);
            Cmd.Parameters["@Endodoncia"].Value = Endodoncia;
            Cmd.Parameters.Add("@Blanqueamiento", SqlDbType.SmallInt);
            Cmd.Parameters["@Blanqueamiento"].Value = Blanqueamiento;
            Cmd.Parameters.Add("@Incrustacion", SqlDbType.SmallInt);
            Cmd.Parameters["@Incrustacion"].Value = Incrustacion;
            Cmd.Parameters.Add("@OtroTratamiento", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroTratamiento"].Value = OtroTratamiento;
            Cmd.Parameters.Add("@IdProtesis", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProtesis"].Value = IdProtesis;
            Cmd.Parameters.Add("@Braquets", SqlDbType.SmallInt);
            Cmd.Parameters["@Braquets"].Value = Braquets;
            Cmd.Parameters.Add("@Retenedores", SqlDbType.SmallInt);
            Cmd.Parameters["@Retenedores"].Value = Retenedores;
            Cmd.Parameters.Add("@Implantes", SqlDbType.SmallInt);
            Cmd.Parameters["@Implantes"].Value = Implantes;
            Cmd.Parameters.Add("@OtroAditamento", SqlDbType.NVarChar);
            Cmd.Parameters["@OtroAditamento"].Value = OtroAditamento;
            Cmd.Parameters.Add("@AditamentoenDesaparicion", SqlDbType.SmallInt);
            Cmd.Parameters["@AditamentoenDesaparicion"].Value = AditamentoenDesaparicion;
            Cmd.Parameters.Add("@AusenciaDental", SqlDbType.NVarChar);
            Cmd.Parameters["@AusenciaDental"].Value = AusenciaDental;
            Cmd.Parameters.Add("@HabitosDentales", SqlDbType.NVarChar);
            Cmd.Parameters["@HabitosDentales"].Value = HabitosDentales;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void PNL_InsertaOtraInformacionRemitir(int IdOtraInformacion, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, bool Detencion, bool Allanamiento, bool Hostigamiento, bool Amenazas, bool Lesiones, bool DisposicionDinero, bool ProblemasVecinales, bool ProblemasFamiliares, bool ActitudNerviosa, bool MovimientoCuentaBancaria, bool ComunicacionDesaparecido, bool ComunicacionCaptores, bool SolicitudParaDejarloLibre, bool ComInternetParadero, bool ComPersonasParadero)
        {

            SqlCommand Cmd = new SqlCommand("PNL_InsertaOtraInformacion", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdOtraInformacion", SqlDbType.Int);
            Cmd.Parameters["@IdOtraInformacion"].Value = IdOtraInformacion;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Detencion", SqlDbType.Bit);
            Cmd.Parameters["@Detencion"].Value = Detencion;
            Cmd.Parameters.Add("@Allanamiento", SqlDbType.Bit);
            Cmd.Parameters["@Allanamiento"].Value = Allanamiento;
            Cmd.Parameters.Add("@Hostigamiento", SqlDbType.Bit);
            Cmd.Parameters["@Hostigamiento"].Value = Hostigamiento;
            Cmd.Parameters.Add("@Amenazas", SqlDbType.Bit);
            Cmd.Parameters["@Amenazas"].Value = Amenazas;
            Cmd.Parameters.Add("@Lesiones", SqlDbType.Bit);
            Cmd.Parameters["@Lesiones"].Value = Lesiones;
            Cmd.Parameters.Add("@DisposicionDinero", SqlDbType.Bit);
            Cmd.Parameters["@DisposicionDinero"].Value = DisposicionDinero;
            Cmd.Parameters.Add("@ProblemasVecinales", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasVecinales"].Value = ProblemasVecinales;
            Cmd.Parameters.Add("@ProblemasFamiliares", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasFamiliares"].Value = ProblemasFamiliares;
            Cmd.Parameters.Add("@ActitudNerviosa", SqlDbType.Bit);
            Cmd.Parameters["@ActitudNerviosa"].Value = ActitudNerviosa;
            Cmd.Parameters.Add("@MovimientoCuentaBancaria", SqlDbType.Bit);
            Cmd.Parameters["@MovimientoCuentaBancaria"].Value = MovimientoCuentaBancaria;
            Cmd.Parameters.Add("@ComunicacionDesaparecido", SqlDbType.Bit);
            Cmd.Parameters["@ComunicacionDesaparecido"].Value = ComunicacionDesaparecido;
            Cmd.Parameters.Add("@ComunicacionCaptores", SqlDbType.Bit);
            Cmd.Parameters["@ComunicacionCaptores"].Value = ComunicacionCaptores;
            Cmd.Parameters.Add("@SolicitudParaDejarloLibre", SqlDbType.Bit);
            Cmd.Parameters["@SolicitudParaDejarloLibre"].Value = SolicitudParaDejarloLibre;
            Cmd.Parameters.Add("@ComInternetParadero", SqlDbType.Bit);
            Cmd.Parameters["@ComInternetParadero"].Value = ComInternetParadero;
            Cmd.Parameters.Add("@ComPersonasParadero", SqlDbType.Bit);
            Cmd.Parameters["@ComPersonasParadero"].Value = ComPersonasParadero;



            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public void PNL_InsertaCausalesDesaparicionRemitir(int ID_CAUSALES_DESAPARICION, int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, bool PropiaVoluntad, bool SustraccionMenores, bool Salud, bool Adicciones, bool Migracion, bool ComisionDelito, bool Levanton, bool DetenidoCausales, bool VictimaDelito, bool Accidentes, bool ProblemasFamiliares, bool RelacionesPersonales, bool MotivosLaborales,
   bool DesaparicionForzada, int IdTipoSujeto, bool SeDesconoce)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaCausalesDesaparicion", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CAUSALES_DESAPARICION", SqlDbType.Int);
            Cmd.Parameters["@ID_CAUSALES_DESAPARICION"].Value = ID_CAUSALES_DESAPARICION;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@PropiaVoluntad", SqlDbType.Bit);
            Cmd.Parameters["@PropiaVoluntad"].Value = PropiaVoluntad;
            Cmd.Parameters.Add("@SustraccionMenores", SqlDbType.Bit);
            Cmd.Parameters["@SustraccionMenores"].Value = SustraccionMenores;
            Cmd.Parameters.Add("@Salud", SqlDbType.Bit);
            Cmd.Parameters["@Salud"].Value = Salud;
            Cmd.Parameters.Add("@Adicciones", SqlDbType.Bit);
            Cmd.Parameters["@Adicciones"].Value = Adicciones;
            Cmd.Parameters.Add("@Migracion", SqlDbType.Bit);
            Cmd.Parameters["@Migracion"].Value = Migracion;
            Cmd.Parameters.Add("@ComisionDelito", SqlDbType.Bit);
            Cmd.Parameters["@ComisionDelito"].Value = ComisionDelito;
            Cmd.Parameters.Add("@Levanton", SqlDbType.Bit);
            Cmd.Parameters["@Levanton"].Value = Levanton;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = DetenidoCausales;
            Cmd.Parameters.Add("@VictimaDelito", SqlDbType.Bit);
            Cmd.Parameters["@VictimaDelito"].Value = VictimaDelito;
            Cmd.Parameters.Add("@Accidentes", SqlDbType.Bit);
            Cmd.Parameters["@Accidentes"].Value = Accidentes;
            Cmd.Parameters.Add("@ProblemasFamiliares", SqlDbType.Bit);
            Cmd.Parameters["@ProblemasFamiliares"].Value = ProblemasFamiliares;
            Cmd.Parameters.Add("@RelacionesPersonales", SqlDbType.Bit);
            Cmd.Parameters["@RelacionesPersonales"].Value = RelacionesPersonales;
            Cmd.Parameters.Add("@MotivosLaborales", SqlDbType.Bit);
            Cmd.Parameters["@MotivosLaborales"].Value = MotivosLaborales;
            Cmd.Parameters.Add("@DesaparicionForzada", SqlDbType.Bit);
            Cmd.Parameters["@DesaparicionForzada"].Value = DesaparicionForzada;
            Cmd.Parameters.Add("@IdTipoSujeto", SqlDbType.Int);
            Cmd.Parameters["@IdTipoSujeto"].Value = IdTipoSujeto;
            Cmd.Parameters.Add("@SeDesconoce", SqlDbType.Bit);
            Cmd.Parameters["@SeDesconoce"].Value = SeDesconoce;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();


        }

        public void agregarMediaFiliacionPNLRemitir(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdCompexion, short IdColorPiel, short IdCara, short IdCantidadCabello, short IdColorCabello, short IdFormaCabello,
                                                 short IdCalvicieCabello, short IdImplantacionCabello, short IdAlturaFrente, short IdIncilacionFrente, short IdAnchoFrente, short IdDireccionCeja,
                                                 short IdImplantacionCeja, short IdFormaCeja, short IdTamañoCeja, short IdColorOjos, short IdFormaOjos, short IdTamañoOjos,
                                                 short IdRaizNariz, short IdDorsoNariz, short IdAnchoNariz, short IdBaseNariz, short IdAlturaNariz, short IdTamañoBoca,
                                                 short IdComisurasBoca, short IdEspesorLabios, short IdNasoLabial, short IdProminenciaLabial, short IdTipoMenton, short IdFormaMenton,
                                                 short IdInclinacionMenton, short IdFormaOreja, short IdOriginalOreja, short IdSuperiorHelix, short IdPosteriorHelix, short IdAdherenciaHelix,
                                                 short IdContornoLobulo, short IdAdherenciaLobulo, short IdParticularidadLobulo, short IdDimensionLobulo, short IdTipoSangre, short IdFactorRH,
                                                 short IdAnteojos, string Estatura, string Peso,
                                                 int IdBigote, int IdColorBigote, int IdTipoBigote, int IdBarba, int IdColorBarba, int IdTipoBarba, int IdPomulos)
        {
            SqlCommand Cmd = new SqlCommand("PNL_AgregarMediaFiliacion", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdCompexion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCompexion"].Value = IdCompexion;

            Cmd.Parameters.Add("@IdColorPiel", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorPiel"].Value = IdColorPiel;

            Cmd.Parameters.Add("@IdCara", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCara"].Value = IdCara;

            Cmd.Parameters.Add("@IdCantidadCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadCabello"].Value = IdCantidadCabello;

            Cmd.Parameters.Add("@IdColorCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorCabello"].Value = IdColorCabello;

            Cmd.Parameters.Add("@IdFormaCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCabello"].Value = IdFormaCabello;

            Cmd.Parameters.Add("@IdCalvicieCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCalvicieCabello"].Value = IdCalvicieCabello;

            Cmd.Parameters.Add("@IdImplantacionCabello", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCabello"].Value = IdImplantacionCabello;

            Cmd.Parameters.Add("@IdAlturaFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaFrente"].Value = IdAlturaFrente;

            Cmd.Parameters.Add("@IdIncilacionFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIncilacionFrente"].Value = IdIncilacionFrente;

            Cmd.Parameters.Add("@IdAnchoFrente", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoFrente"].Value = IdAnchoFrente;

            Cmd.Parameters.Add("@IdDireccionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDireccionCeja"].Value = IdDireccionCeja;

            Cmd.Parameters.Add("@IdImplantacionCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdImplantacionCeja"].Value = IdImplantacionCeja;

            Cmd.Parameters.Add("@IdFormaCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaCeja"].Value = IdFormaCeja;

            Cmd.Parameters.Add("@IdTamañoCeja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoCeja"].Value = IdTamañoCeja;

            Cmd.Parameters.Add("@IdColorOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColorOjos"].Value = IdColorOjos;

            Cmd.Parameters.Add("@IdFormaOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOjos"].Value = IdFormaOjos;

            Cmd.Parameters.Add("@IdTamañoOjos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoOjos"].Value = IdTamañoOjos;

            Cmd.Parameters.Add("@IdRaizNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRaizNariz"].Value = IdRaizNariz;

            Cmd.Parameters.Add("@IdDorsoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDorsoNariz"].Value = IdDorsoNariz;

            Cmd.Parameters.Add("@IdAnchoNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnchoNariz"].Value = IdAnchoNariz;

            Cmd.Parameters.Add("@IdBaseNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdBaseNariz"].Value = IdBaseNariz;

            Cmd.Parameters.Add("@IdAlturaNariz", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAlturaNariz"].Value = IdAlturaNariz;

            Cmd.Parameters.Add("@IdTamañoBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTamañoBoca"].Value = IdTamañoBoca;

            Cmd.Parameters.Add("@IdComisurasBoca", SqlDbType.SmallInt);
            Cmd.Parameters["@IdComisurasBoca"].Value = IdComisurasBoca;

            Cmd.Parameters.Add("@IdEspesorLabios", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEspesorLabios"].Value = IdEspesorLabios;

            Cmd.Parameters.Add("@IdNasoLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdNasoLabial"].Value = IdNasoLabial;

            Cmd.Parameters.Add("@IdProminenciaLabial", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProminenciaLabial"].Value = IdProminenciaLabial;

            Cmd.Parameters.Add("@IdTipoMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoMenton"].Value = IdTipoMenton;

            Cmd.Parameters.Add("@IdFormaMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaMenton"].Value = IdFormaMenton;

            Cmd.Parameters.Add("@IdInclinacionMenton", SqlDbType.SmallInt);
            Cmd.Parameters["@IdInclinacionMenton"].Value = IdInclinacionMenton;

            Cmd.Parameters.Add("@IdFormaOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaOreja"].Value = IdFormaOreja;

            Cmd.Parameters.Add("@IdOriginalOreja", SqlDbType.SmallInt);
            Cmd.Parameters["@IdOriginalOreja"].Value = IdOriginalOreja;

            Cmd.Parameters.Add("@IdSuperiorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSuperiorHelix"].Value = IdSuperiorHelix;

            Cmd.Parameters.Add("@IdPosteriorHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPosteriorHelix"].Value = IdPosteriorHelix;

            Cmd.Parameters.Add("@IdAdherenciaHelix", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaHelix"].Value = IdAdherenciaHelix;

            Cmd.Parameters.Add("@IdContornoLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdContornoLobulo"].Value = IdContornoLobulo;

            Cmd.Parameters.Add("@IdAdherenciaLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAdherenciaLobulo"].Value = IdAdherenciaLobulo;

            Cmd.Parameters.Add("@IdParticularidadLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParticularidadLobulo"].Value = IdParticularidadLobulo;

            Cmd.Parameters.Add("@IdDimensionLobulo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDimensionLobulo"].Value = IdDimensionLobulo;

            Cmd.Parameters.Add("@IdTipoSangre", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSangre"].Value = IdTipoSangre;

            Cmd.Parameters.Add("@IdFactorRH", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFactorRH"].Value = IdFactorRH;

            Cmd.Parameters.Add("@IdAnteojos", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAnteojos"].Value = IdAnteojos;

            Cmd.Parameters.Add("@Estatura", SqlDbType.VarChar);
            Cmd.Parameters["@Estatura"].Value = Estatura;

            Cmd.Parameters.Add("@Peso", SqlDbType.VarChar);
            Cmd.Parameters["@Peso"].Value = Peso;

            Cmd.Parameters.Add("@IdBigote", SqlDbType.Int);
            Cmd.Parameters["@IdBigote"].Value = IdBigote;
            Cmd.Parameters.Add("@IdColorBigote", SqlDbType.Int);
            Cmd.Parameters["@IdColorBigote"].Value = IdColorBigote;
            Cmd.Parameters.Add("@IdTipoBigote", SqlDbType.Int);
            Cmd.Parameters["@IdTipoBigote"].Value = IdTipoBigote;
            Cmd.Parameters.Add("@IdBarba", SqlDbType.Int);
            Cmd.Parameters["@IdBarba"].Value = IdBarba;
            Cmd.Parameters.Add("@IdColorBarba", SqlDbType.Int);
            Cmd.Parameters["@IdColorBarba"].Value = IdColorBarba;
            Cmd.Parameters.Add("@IdTipoBarba", SqlDbType.Int);
            Cmd.Parameters["@IdTipoBarba"].Value = IdTipoBarba;
            Cmd.Parameters.Add("@IdPomulos", SqlDbType.Int);
            Cmd.Parameters["@IdPomulos"].Value = IdPomulos;



            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void agregarSeñasPNLRemitir(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short IdTipoSeña, short IdDescripcionSeña, short IdVista, short IdLado, short IdRegion, short IdCantidadRegion, string Descripcion)
        {
            SqlCommand Cmd = new SqlCommand("PNL_AgregarSenas", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@IdTipoSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoSeña"].Value = IdTipoSeña;

            Cmd.Parameters.Add("@IdDescripcionSeña", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDescripcionSeña"].Value = IdDescripcionSeña;

            Cmd.Parameters.Add("@IdVista", SqlDbType.SmallInt);
            Cmd.Parameters["@IdVista"].Value = IdVista;

            Cmd.Parameters.Add("@IdLado ", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLado "].Value = IdLado;

            Cmd.Parameters.Add("@IdRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdRegion"].Value = IdRegion;

            Cmd.Parameters.Add("@IdCantidadRegion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCantidadRegion"].Value = IdCantidadRegion;

            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;



            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void PNL_InsertaVestimentaRemitir(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, int IdVestimenta, string DescripcionVestimenta)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaVestimenta", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdVestimenta", SqlDbType.Int);
            Cmd.Parameters["@IdVestimenta"].Value = @IdVestimenta;
            Cmd.Parameters.Add("@DescripcionVestimenta", SqlDbType.VarChar);
            Cmd.Parameters["@DescripcionVestimenta"].Value = DescripcionVestimenta;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void InsertaDonantesRemitir(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, string Nombre, String Paterno, String Materno, short IdSexo, short IdIdentificacion,
           String FolioIdentificacion, short IdParentesco, short IdPais, short IdEntidad, short IdMunicipio, short Localidad,
           short Colonia, int Calle, int EntreCalle1, int EntreCalle2, String NumeroExterior, String NumeroInterior,
           String CP, String Telefono, String TipoMuestra, DateTime FechaMuestra, short MenorEdad, String NombreTutor, String PaternoTutor,
           String MaternoTutor, short IdParentescoTutor, short IdIdentificacionTutor, String FolioIdentificacionTutor, short Trasfusion,
           short Trasplante, short EnfermedadInfecciosa, String CantidadDeMuestra, String AutoridadQueSolicitaTomaMuestra, String LugarRecoleccionIndicios, String HoraRecoleccionMuestra)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDonante", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Nombre ", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre "].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@IdSexo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdSexo"].Value = IdSexo;
            Cmd.Parameters.Add("@IdIdentificacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacion"].Value = IdIdentificacion;
            Cmd.Parameters.Add("@FolioIdentificacion", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIdentificacion"].Value = FolioIdentificacion;
            Cmd.Parameters.Add("@IdParentesco", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentesco"].Value = IdParentesco;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEntidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEntidad"].Value = IdEntidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Localidad", SqlDbType.SmallInt);
            Cmd.Parameters["@Localidad"].Value = Localidad;
            Cmd.Parameters.Add("@Colonia", SqlDbType.SmallInt);
            Cmd.Parameters["@Colonia"].Value = Colonia;
            Cmd.Parameters.Add("@Calle", SqlDbType.Int);
            Cmd.Parameters["@Calle"].Value = Calle;
            Cmd.Parameters.Add("@EntreCalle1", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle1"].Value = EntreCalle1;
            Cmd.Parameters.Add("@EntreCalle2", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle2"].Value = EntreCalle2;
            Cmd.Parameters.Add("@NumeroExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroExterior"].Value = NumeroExterior;
            Cmd.Parameters.Add("@NumeroInterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroInterior"].Value = NumeroInterior;
            Cmd.Parameters.Add("@CP", SqlDbType.VarChar);
            Cmd.Parameters["@CP"].Value = CP;
            Cmd.Parameters.Add("@Telefono", SqlDbType.VarChar);
            Cmd.Parameters["@Telefono"].Value = Telefono;
            Cmd.Parameters.Add("@TipoMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@TipoMuestra"].Value = TipoMuestra;
            Cmd.Parameters.Add("@FechaMuestra", SqlDbType.Date);
            Cmd.Parameters["@FechaMuestra"].Value = FechaMuestra;
            Cmd.Parameters.Add("@MenorEdad", SqlDbType.Bit);
            Cmd.Parameters["@MenorEdad"].Value = MenorEdad;
            Cmd.Parameters.Add("@NombreTutor", SqlDbType.VarChar);
            Cmd.Parameters["@NombreTutor"].Value = NombreTutor;
            Cmd.Parameters.Add("@PaternoTutor", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoTutor"].Value = PaternoTutor;
            Cmd.Parameters.Add("@MaternoTutor", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoTutor"].Value = MaternoTutor;
            Cmd.Parameters.Add("@IdParentescoTutor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentescoTutor"].Value = IdParentescoTutor;
            Cmd.Parameters.Add("@IdIdentificacionTutor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdIdentificacionTutor"].Value = IdIdentificacionTutor;
            Cmd.Parameters.Add("@FolioIdentificacionTutor", SqlDbType.VarChar);
            Cmd.Parameters["@FolioIdentificacionTutor"].Value = FolioIdentificacionTutor;
            Cmd.Parameters.Add("@Trasfusion", SqlDbType.Bit);
            Cmd.Parameters["@Trasfusion"].Value = Trasfusion;
            Cmd.Parameters.Add("@Trasplante", SqlDbType.Bit);
            Cmd.Parameters["@Trasplante"].Value = Trasplante;
            Cmd.Parameters.Add("@EnfermedadInfecciosa", SqlDbType.Bit);
            Cmd.Parameters["@EnfermedadInfecciosa"].Value = EnfermedadInfecciosa;
            Cmd.Parameters.Add("@CantidadDeMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@CantidadDeMuestra"].Value = CantidadDeMuestra;
            Cmd.Parameters.Add("@AutoridadQueSolicitaTomaMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@AutoridadQueSolicitaTomaMuestra"].Value = AutoridadQueSolicitaTomaMuestra;

            Cmd.Parameters.Add("@LugarRecoleccionIndicios", SqlDbType.VarChar);
            Cmd.Parameters["@LugarRecoleccionIndicios"].Value = LugarRecoleccionIndicios;
            Cmd.Parameters.Add("@HoraRecoleccionMuestra", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRecoleccionMuestra"].Value = HoraRecoleccionMuestra;

            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void InsertaColectorMuestraRemitir(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona,
   String Nombre, String Paterno, String Materno, String NumeroEmpleado,
  String Institucion, int IdMunicipio, String Puesto, int IdDonante, String DptoPericial)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaColectorMuestra", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;

            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@NumeroEmpleado", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroEmpleado"].Value = NumeroEmpleado;
            Cmd.Parameters.Add("@Institucion", SqlDbType.VarChar);
            Cmd.Parameters["@Institucion"].Value = Institucion;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Puesto", SqlDbType.VarChar);
            Cmd.Parameters["@Puesto"].Value = Puesto;
            Cmd.Parameters.Add("@IdDonante", SqlDbType.Int);
            Cmd.Parameters["@IdDonante"].Value = IdDonante;
            Cmd.Parameters.Add("@DptoPericial", SqlDbType.VarChar);
            Cmd.Parameters["@DptoPericial"].Value = DptoPericial;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDatosLocalizacionRemitir(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, short EstatusPersona, DateTime FechaLocalizacion, string HoraLocalizacion, string PosibleCausaDesaparicion, short IdCondicionLocalizacion, short IdLugarHallazgo, short IdPais, short IdEntidad, short IdMunicipio, short Localidad,
          short Colonia, int Calle, int EntreCalle1, int EntreCalle2, String NumeroExterior, String NumeroInterior,
          String CP, String FechaIngreso, String HoraIngreso, short IdCausasFallecimiento, String IdentificacionCadaver,
         String FechaEntregaCuerpo, String FechaProbableFallecimiento, short EnteLocaliza, String NombreEnte, String PaternoEnte, String MaternoEnte, String Institucion, String Autoridad, String NombreAutoridad, String PaternoAutoridad,
          String MaternoAutoridad, String NombreReclama, String PaternoReclama, String MaternoReclama, short IdParentescoReclama)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaDatosLocalizacion", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@EstatusPersona", SqlDbType.SmallInt);
            Cmd.Parameters["@EstatusPersona"].Value = EstatusPersona;
            Cmd.Parameters.Add("@FechaLocalizacion", SqlDbType.Date);
            Cmd.Parameters["@FechaLocalizacion"].Value = FechaLocalizacion;
            Cmd.Parameters.Add("@HoraLocalizacion", SqlDbType.VarChar);
            Cmd.Parameters["@HoraLocalizacion"].Value = HoraLocalizacion;
            Cmd.Parameters.Add("@PosibleCausaDesaparicion", SqlDbType.VarChar);
            Cmd.Parameters["@PosibleCausaDesaparicion"].Value = PosibleCausaDesaparicion;
            Cmd.Parameters.Add("@IdCondicionLocalizacion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCondicionLocalizacion"].Value = IdCondicionLocalizacion;
            Cmd.Parameters.Add("@IdLugarHallazgo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdLugarHallazgo"].Value = IdLugarHallazgo;
            Cmd.Parameters.Add("@IdPais", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPais"].Value = IdPais;
            Cmd.Parameters.Add("@IdEntidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEntidad"].Value = IdEntidad;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Localidad", SqlDbType.SmallInt);
            Cmd.Parameters["@Localidad"].Value = Localidad;
            Cmd.Parameters.Add("@Colonia", SqlDbType.SmallInt);
            Cmd.Parameters["@Colonia"].Value = Colonia;
            Cmd.Parameters.Add("@Calle", SqlDbType.Int);
            Cmd.Parameters["@Calle"].Value = Calle;
            Cmd.Parameters.Add("@EntreCalle1", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle1"].Value = EntreCalle1;
            Cmd.Parameters.Add("@EntreCalle2", SqlDbType.Int);
            Cmd.Parameters["@EntreCalle2"].Value = EntreCalle2;
            Cmd.Parameters.Add("@NumeroExterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroExterior"].Value = NumeroExterior;
            Cmd.Parameters.Add("@NumeroInterior", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroInterior"].Value = NumeroInterior;
            Cmd.Parameters.Add("@CP", SqlDbType.VarChar);
            Cmd.Parameters["@CP"].Value = CP;
            Cmd.Parameters.Add("@FechaIngreso", SqlDbType.VarChar);
            Cmd.Parameters["@FechaIngreso"].Value = FechaIngreso;
            Cmd.Parameters.Add("@HoraIngreso", SqlDbType.VarChar);
            Cmd.Parameters["@HoraIngreso"].Value = HoraIngreso;
            Cmd.Parameters.Add("@IdCausasFallecimiento", SqlDbType.SmallInt);
            Cmd.Parameters["@IdCausasFallecimiento"].Value = IdCausasFallecimiento;
            Cmd.Parameters.Add("@IdentificacionCadaver", SqlDbType.VarChar);
            Cmd.Parameters["@IdentificacionCadaver"].Value = IdentificacionCadaver;
            Cmd.Parameters.Add("@FechaEntregaCuerpo", SqlDbType.VarChar);
            Cmd.Parameters["@FechaEntregaCuerpo"].Value = FechaEntregaCuerpo;
            Cmd.Parameters.Add("@FechaProbableFallecimiento", SqlDbType.VarChar);
            Cmd.Parameters["@FechaProbableFallecimiento"].Value = FechaProbableFallecimiento;
            Cmd.Parameters.Add("@EnteLocaliza", SqlDbType.SmallInt);
            Cmd.Parameters["@EnteLocaliza"].Value = EnteLocaliza;
            Cmd.Parameters.Add("@NombreEnte", SqlDbType.VarChar);
            Cmd.Parameters["@NombreEnte"].Value = NombreEnte;
            Cmd.Parameters.Add("@PaternoEnte", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoEnte"].Value = PaternoEnte;
            Cmd.Parameters.Add("@MaternoEnte", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoEnte"].Value = MaternoEnte;
            Cmd.Parameters.Add("@Institucion", SqlDbType.VarChar);
            Cmd.Parameters["@Institucion"].Value = Institucion;
            Cmd.Parameters.Add("@Autoridad", SqlDbType.VarChar);
            Cmd.Parameters["@Autoridad"].Value = Autoridad;
            Cmd.Parameters.Add("@NombreAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@NombreAutoridad"].Value = NombreAutoridad;
            Cmd.Parameters.Add("@PaternoAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoAutoridad"].Value = PaternoAutoridad;

            Cmd.Parameters.Add("@MaternoAutoridad", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoAutoridad"].Value = MaternoAutoridad;

            Cmd.Parameters.Add("@NombreReclama", SqlDbType.VarChar);
            Cmd.Parameters["@NombreReclama"].Value = NombreReclama;

            Cmd.Parameters.Add("@PaternoReclama", SqlDbType.VarChar);
            Cmd.Parameters["@PaternoReclama"].Value = PaternoReclama;

            Cmd.Parameters.Add("@MaternoReclama", SqlDbType.VarChar);
            Cmd.Parameters["@MaternoReclama"].Value = MaternoReclama;

            Cmd.Parameters.Add("@IdParentescoReclama", SqlDbType.SmallInt);
            Cmd.Parameters["@IdParentescoReclama"].Value = IdParentescoReclama;


            SqlDataReader DR = Cmd.ExecuteReader();

            DR.Close();
        }

        public void PNLInsertaFotografiaRemitir(int IdCarpeta, short IdMunicipioCarpeta, int IdPersona, Byte[] Fotografia, string Descripcion)
        {
            SqlCommand Cmd = new SqlCommand("PNL_InsertaFotografiaPNL", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@Fotografia", SqlDbType.Image);
            Cmd.Parameters["@Fotografia"].Value = Fotografia;
            Cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            Cmd.Parameters["@Descripcion"].Value = Descripcion;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }


        public void InsertaQuienResulteResponsableRemitir(String Paterno, String Materno, String Nombre, short ID_MUNICIPIO_PERSONA, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaQuienResulteResponsableRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@Paterno", SqlDbType.VarChar);
            Cmd.Parameters["@Paterno"].Value = Paterno;
            Cmd.Parameters.Add("@Materno", SqlDbType.VarChar);
            Cmd.Parameters["@Materno"].Value = Materno;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
            Cmd.Parameters["@Nombre"].Value = Nombre;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PERSONA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PERSONA"].Value = ID_MUNICIPIO_PERSONA;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            //IdPersona = Convert.ToInt32(Cmd.Parameters["@IdPersona"].Value);
            DR.Close();
        }

        public void InsertaQuienResulteResponsableCarpetaPersonaRemitir(int IdCarpeta, int IdPersona, short IdTipoActor, short ID_MUNICIPIO_PEROSNA_CARPETA, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaQuienResulteResponsableCarpetaPersonaRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@IdTipoActor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoActor"].Value = IdTipoActor;
            Cmd.Parameters.Add("@ID_MUNICIPIO_PEROSNA_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_PEROSNA_CARPETA"].Value = ID_MUNICIPIO_PEROSNA_CARPETA;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            //Cmd.Parameters.Add("@IdPersonaCarpeta", SqlDbType.Int);
            //Cmd.Parameters["@IdPersonaCarpeta"].Direction = ParameterDirection.Output;
            SqlDataReader DR = Cmd.ExecuteReader();
            //    IdPersonaCarpeta = Convert.ToInt32(Cmd.Parameters["@IdPersonaCarpeta"].Value);
            DR.Close();
        }

        public void InsertaQuienResulteResponsablePersonaDomicilioRemitir(int IdPersona, short ID_MUNICIPIO_DOMICILIO)
        {
            SqlCommand Cmd = new SqlCommand("InsertaQuienResulteResponsablePersonaDomicilio", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdPersona", SqlDbType.Int);
            Cmd.Parameters["@IdPersona"].Value = IdPersona;
            Cmd.Parameters.Add("@ID_MUNICIPIO_DOMICILIO", SqlDbType.Int);
            Cmd.Parameters["@ID_MUNICIPIO_DOMICILIO"].Value = ID_MUNICIPIO_DOMICILIO;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACIniciadaRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACIniciada", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACRemitidaRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, String MP,int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACRemitidaRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@MP", SqlDbType.VarChar);
            Cmd.Parameters["@MP"].Value = MP;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACCanalizadaRemitir(int IdCarpeta, short IdMunicipio, short IdInstitucion, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACCanalizada", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdInstitucion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdInstitucion"].Value = IdInstitucion;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACConvenioRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACConvenio", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACConvenioIncumplidoRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACConvenioIncumplido", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACIncompetenciaRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, int IdUsuario, DateTime FechaRegistro, short IdAgencia)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACIncompetencia", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            Cmd.Parameters.Add("@IdAgencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAgencia"].Value = IdAgencia;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACNoConvenioRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACNoConvenio", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACResueltaRemitir(int IdCarpeta, short IdMunicipio, String Resolvio, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACResuelta", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Resolvio", SqlDbType.VarChar);
            Cmd.Parameters["@Resolvio"].Value = Resolvio;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACSuspendidaRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACSuspendida", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACAcuerdoAbsInvRemitir(int IdCarpeta, short IdMunicipio, short IdUnidad, int IdUsuario, DateTime FechaRegistro)
        {

            SqlCommand Cmd = new SqlCommand("insertaRACAcuerdoAbsInv", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaVehiculoRemitir(int IdCarpeta, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, short IdPlacaEstado,
        short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, short ID_MUNICIPIO_VEHICULO, String Senas, short IdTipoUso, short IdAseguradora,
        String NumeroMotor, String RegistroNIV, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVehiculoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.Int);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = ID_MUNICIPIO_VEHICULO;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaVehiculoRobadoRemitir(int IdCarpeta, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor, String Serie, String Placa, 
        short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, String Observaciones, short ID_MUNICIPIO_VEHICULO, String Senas,
        short IdTipoUso, short IdAseguradora, DateTime FechaRobo, String HoraRobo, short IdEstadoVehiculo, int IdPersonaPropietario, int IdConsecutivoDelito, int IdUsuario,
        short IdUnidad, String NumeroMotor, String RegistroNIV, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVehiculoRobadoRecuperadoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = ID_MUNICIPIO_VEHICULO;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            //
            Cmd.Parameters.Add("@FechaRobo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRobo"].Value = FechaRobo;
            Cmd.Parameters.Add("@HoraRobo", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRobo"].Value = HoraRobo;
            //Cmd.Parameters.Add("@FechaRecuperacion", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaRecuperacion"].Value = FechaRecuperacion;
            Cmd.Parameters.Add("@IdEstadoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoVehiculo"].Value = IdEstadoVehiculo;
            Cmd.Parameters.Add("@IdPersonaPropietario", SqlDbType.Int);
            Cmd.Parameters["@IdPersonaPropietario"].Value = IdPersonaPropietario;
            Cmd.Parameters.Add("@IdConsecutivoDelito", SqlDbType.Int);
            Cmd.Parameters["@IdConsecutivoDelito"].Value = IdConsecutivoDelito;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;

            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaVehiculoRecuperadoRemitir(int IdCarpeta, String NumeroAccidente, short Idmarca, int IdSubMarca, short IdModelo, short IdColor,
        String Serie, String Placa, short IdPlacaEstado, short IdProcedencia, short IdTipoVehiculo, short IdPusoDisposicion, short IdAsegurado, 
        String Observaciones, short ID_MUNICIPIO_VEHICULO, String Senas, short IdTipoUso, short IdAseguradora, DateTime FechaRobo, String HoraRobo,
        short IdEstadoVehiculo, int IdPersonaPropietario, int IdConsecutivoDelito, int IdUsuario, short IdUnidad, String NumeroMotor, String RegistroNIV, 
        DateTime FechaRecuperacion, String HoraRecuperacion, short IdDepositado, DateTime FechaDepositado, String HoraDepositado, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaVehiculoRecuperadoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@NumeroAccidente", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumeroAccidente"].Value = NumeroAccidente;
            Cmd.Parameters.Add("@Idmarca", SqlDbType.SmallInt);
            Cmd.Parameters["@Idmarca"].Value = Idmarca;
            Cmd.Parameters.Add("@IdSubMarca", SqlDbType.Int);
            Cmd.Parameters["@IdSubMarca"].Value = IdSubMarca;
            Cmd.Parameters.Add("@IdModelo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdModelo"].Value = IdModelo;
            Cmd.Parameters.Add("@IdColor", SqlDbType.SmallInt);
            Cmd.Parameters["@IdColor"].Value = IdColor;
            Cmd.Parameters.Add("@Serie", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Serie"].Value = Serie;
            Cmd.Parameters.Add("@Placa", SqlDbType.VarChar, 20);
            Cmd.Parameters["@Placa"].Value = Placa;
            Cmd.Parameters.Add("@ID_PLACA_ESTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_PLACA_ESTADO"].Value = IdPlacaEstado;
            Cmd.Parameters.Add("@IdProcedencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdProcedencia"].Value = IdProcedencia;
            Cmd.Parameters.Add("@IdTipoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoVehiculo"].Value = IdTipoVehiculo;
            Cmd.Parameters.Add("@IdPusoDisposicion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdPusoDisposicion"].Value = IdPusoDisposicion;
            Cmd.Parameters.Add("@IdAsegurado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAsegurado"].Value = IdAsegurado;
            Cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar);
            Cmd.Parameters["@Observaciones"].Value = Observaciones;
            Cmd.Parameters.Add("@ID_MUNICIPIO_VEHICULO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_VEHICULO"].Value = ID_MUNICIPIO_VEHICULO;
            //SE AGREGARON 3 PARAMETROS
            Cmd.Parameters.Add("@Senas", SqlDbType.VarChar);
            Cmd.Parameters["@Senas"].Value = Senas;
            Cmd.Parameters.Add("@IdTipoUso", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoUso"].Value = IdTipoUso;
            Cmd.Parameters.Add("@IdAseguradora", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAseguradora"].Value = IdAseguradora;
            //
            Cmd.Parameters.Add("@FechaRobo", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRobo"].Value = FechaRobo;
            Cmd.Parameters.Add("@HoraRobo", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRobo"].Value = HoraRobo;
            //Cmd.Parameters.Add("@FechaRecuperacion", SqlDbType.DateTime);
            //Cmd.Parameters["@FechaRecuperacion"].Value = FechaRecuperacion;
            Cmd.Parameters.Add("@IdEstadoVehiculo", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoVehiculo"].Value = IdEstadoVehiculo;
            Cmd.Parameters.Add("@IdPersonaPropietario", SqlDbType.Int);
            Cmd.Parameters["@IdPersonaPropietario"].Value = IdPersonaPropietario;
            Cmd.Parameters.Add("@IdConsecutivoDelito", SqlDbType.Int);
            Cmd.Parameters["@IdConsecutivoDelito"].Value = IdConsecutivoDelito;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;

            Cmd.Parameters.Add("@NumeroMotor", SqlDbType.VarChar);
            Cmd.Parameters["@NumeroMotor"].Value = NumeroMotor;
            Cmd.Parameters.Add("@RegistroNIV", SqlDbType.VarChar);
            Cmd.Parameters["@RegistroNIV"].Value = RegistroNIV;

            Cmd.Parameters.Add("@FechaRecuperacion", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRecuperacion"].Value = FechaRecuperacion;
            Cmd.Parameters.Add("@HoraRecuperacion", SqlDbType.VarChar);
            Cmd.Parameters["@HoraRecuperacion"].Value = HoraDepositado;
            Cmd.Parameters.Add("@IdDepositado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdDepositado"].Value = IdDepositado;
            Cmd.Parameters.Add("@FechaDepositado", SqlDbType.DateTime);
            Cmd.Parameters["@FechaDepositado"].Value = FechaDepositado;
            Cmd.Parameters.Add("@HoraDepositado", SqlDbType.VarChar);
            Cmd.Parameters["@HoraDepositado"].Value = HoraDepositado;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaAutorizacionRemitir(int IdCarpeta, int IdMunicipio, int IdVehiculo, int IdUsuario, string Autorizacion, DateTime FechaRegistro, int Activo)
        {
            SqlCommand Cmd = new SqlCommand("insertaAutorizacionRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdVehiculo", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculo"].Value = IdVehiculo;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@Autorizacion", SqlDbType.VarChar);
            Cmd.Parameters["@Autorizacion"].Value = Autorizacion;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;
            Cmd.Parameters.Add("@Activo", SqlDbType.Int);
            Cmd.Parameters["@Activo"].Value = Activo;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaPdfVehiculoRemitir(int IdCarpeta, int IdMunicipio, int IdVehiculo, int IdAutorizacion, int IdPdf)
        {
            SqlCommand Cmd = new SqlCommand("insertaPDFVehiculoRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdVehiculo", SqlDbType.Int);
            Cmd.Parameters["@IdVehiculo"].Value = IdVehiculo;
            Cmd.Parameters.Add("@IdAutorizacion", SqlDbType.Int);
            Cmd.Parameters["@IdAutorizacion"].Value = IdAutorizacion;
            Cmd.Parameters.Add("@IdPdf", SqlDbType.Int);
            Cmd.Parameters["@IdPdf"].Value = IdPdf;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarHomicidioRemitir(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_PERSONA_OFENDIDO, int ID_PERSONA_IMPUTADO, int ID_LUGAR_HECHOS,
        short ID_TIPO_PERSONA_OFENDIDO, short ID_TIPO_PERSONA_IMPUTADO, short ID_ORGANIZACION_IMPUTADO, short ID_MOVIL, short ID_SUB_DELITO, short ID_SITUACION,
        short ID_SUB_MODALIDAD, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertarHomicidioRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA_OFENDIDO", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_OFENDIDO"].Value = ID_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_PERSONA_IMPUTADO ", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA_IMPUTADO "].Value = ID_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_LUGAR_HECHOS", SqlDbType.Int);
            Cmd.Parameters["@ID_LUGAR_HECHOS"].Value = ID_LUGAR_HECHOS;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_OFENDIDO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_OFENDIDO"].Value = ID_TIPO_PERSONA_OFENDIDO;

            Cmd.Parameters.Add("@ID_TIPO_PERSONA_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_TIPO_PERSONA_IMPUTADO"].Value = ID_TIPO_PERSONA_IMPUTADO;

            Cmd.Parameters.Add("@ID_ORGANIZACION_IMPUTADO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ORGANIZACION_IMPUTADO"].Value = ID_ORGANIZACION_IMPUTADO;

            Cmd.Parameters.Add("@ID_MOVIL", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MOVIL"].Value = ID_MOVIL;

            Cmd.Parameters.Add("@ID_SUB_DELITO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUB_DELITO"].Value = ID_SUB_DELITO;

            Cmd.Parameters.Add("@ID_SITUACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SITUACION"].Value = ID_SITUACION;

            Cmd.Parameters.Add("@ID_SUB_MODALIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_SUB_MODALIDAD"].Value = ID_SUB_MODALIDAD;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarCadaverHomicidioRemitir(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_PERSONA, short ID_VIOLENCIA, short ID_CDVR_CAUSA, short ID_CDVR_CNSRVCION, 
        short ID_CDVR_ORIENTACION, short ID_CDVR_PSCION, DateTime FECHA_MUERTE, string HORA_MUERTE, DateTime FECHA_IDENTIFICACION, string HORA_IDENTIFIACION, short CUERPO_ENTREGADO,
        string NOMBRE_ENTREGA_CUERPO, short PARENTESCO, short FOSA_COMUN, string DESCRIPCION_CADAVER, DateTime FECHA_ENTREGA, string DATOS_FOSA, string PARTES_CUERPO, Byte[] IDENTIFICACION,
        string RESGUARDO_CADAVER, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertarCadaverHomicidioRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_PERSONA", SqlDbType.Int);
            Cmd.Parameters["@ID_PERSONA"].Value = ID_PERSONA;

            Cmd.Parameters.Add("@ID_VIOLENCIA ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_VIOLENCIA "].Value = ID_VIOLENCIA;

            Cmd.Parameters.Add("@ID_CDVR_CAUSA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CAUSA"].Value = ID_CDVR_CAUSA;

            Cmd.Parameters.Add("@ID_CDVR_CNSRVCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_CNSRVCION"].Value = ID_CDVR_CNSRVCION;

            Cmd.Parameters.Add("@ID_CDVR_ORIENTACION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_ORIENTACION"].Value = ID_CDVR_ORIENTACION;

            Cmd.Parameters.Add("@ID_CDVR_PSCION", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CDVR_PSCION"].Value = ID_CDVR_PSCION;

            Cmd.Parameters.Add("@FECHA_MUERTE", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_MUERTE"].Value = FECHA_MUERTE;

            Cmd.Parameters.Add("@HORA_MUERTE", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_MUERTE"].Value = HORA_MUERTE;

            Cmd.Parameters.Add("@FECHA_IDENTIFICACION", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_IDENTIFICACION"].Value = FECHA_IDENTIFICACION;

            Cmd.Parameters.Add("@HORA_IDENTIFIACION", SqlDbType.VarChar);
            Cmd.Parameters["@HORA_IDENTIFIACION"].Value = HORA_IDENTIFIACION;

            Cmd.Parameters.Add("@CUERPO_ENTREGADO", SqlDbType.TinyInt);
            Cmd.Parameters["@CUERPO_ENTREGADO"].Value = CUERPO_ENTREGADO;

            Cmd.Parameters.Add("@NOMBRE_ENTREGA_CUERPO", SqlDbType.VarChar);
            Cmd.Parameters["@NOMBRE_ENTREGA_CUERPO"].Value = NOMBRE_ENTREGA_CUERPO;

            Cmd.Parameters.Add("@PARENTESCO", SqlDbType.SmallInt);
            Cmd.Parameters["@PARENTESCO"].Value = PARENTESCO;

            Cmd.Parameters.Add("@FOSA_COMUN", SqlDbType.Bit);
            Cmd.Parameters["@FOSA_COMUN"].Value = FOSA_COMUN;

            Cmd.Parameters.Add("@DESCRIPCION_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION_CADAVER"].Value = DESCRIPCION_CADAVER;

            Cmd.Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime);
            Cmd.Parameters["@FECHA_ENTREGA"].Value = FECHA_ENTREGA;

            Cmd.Parameters.Add("@DATOS_FOSA", SqlDbType.VarChar);
            Cmd.Parameters["@DATOS_FOSA"].Value = DATOS_FOSA;

            Cmd.Parameters.Add("@PARTES_CUERPO", SqlDbType.VarChar);
            Cmd.Parameters["@PARTES_CUERPO"].Value = PARTES_CUERPO;

            Cmd.Parameters.Add("@IDENTIFICACION", SqlDbType.Image);
            Cmd.Parameters["@IDENTIFICACION"].Value = IDENTIFICACION;

            Cmd.Parameters.Add("@RESGUARDO_CADAVER", SqlDbType.VarChar);
            Cmd.Parameters["@RESGUARDO_CADAVER"].Value = RESGUARDO_CADAVER;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarMensajeHomicidioRemitir(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_HOMICIDIO, string MENSAJE, Byte[] FOTO1, Byte[] FOTO2, Byte[] FOTO3, Byte[] FOTO4,
            DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertarMensajeHomicidioRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_HOMICIDIO", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO"].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@MENSAJE ", SqlDbType.Text);
            Cmd.Parameters["@MENSAJE "].Value = MENSAJE;

            Cmd.Parameters.Add("@FOTO1", SqlDbType.Image);
            Cmd.Parameters["@FOTO1"].Value = FOTO1;

            Cmd.Parameters.Add("@FOTO2", SqlDbType.Image);
            Cmd.Parameters["@FOTO2"].Value = FOTO2;

            Cmd.Parameters.Add("@FOTO3", SqlDbType.Image);
            Cmd.Parameters["@FOTO3"].Value = FOTO3;

            Cmd.Parameters.Add("@FOTO4", SqlDbType.Image);
            Cmd.Parameters["@FOTO4"].Value = FOTO4;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarArmaRemitir(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, short ID_ARMA_TPO, short ID_ARMA_CAT, short ID_ARMAS_AA, short ID_MARCA, 
        short ID_CALIBRE, short ID_ESTADO_ARMA, string DESCRIPCION, string MATRICULA, string SERIE, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertarArmaRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_ARMA_TPO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMA_TPO"].Value = ID_ARMA_TPO;

            Cmd.Parameters.Add("@ID_ARMA_CAT ", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMA_CAT "].Value = ID_ARMA_CAT;

            Cmd.Parameters.Add("@ID_ARMAS_AA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ARMAS_AA"].Value = ID_ARMAS_AA;

            Cmd.Parameters.Add("@ID_MARCA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MARCA"].Value = ID_MARCA;

            Cmd.Parameters.Add("@ID_CALIBRE", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_CALIBRE"].Value = ID_CALIBRE;

            Cmd.Parameters.Add("@ID_ESTADO_ARMA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_ESTADO_ARMA"].Value = ID_ESTADO_ARMA;

            Cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
            Cmd.Parameters["@DESCRIPCION"].Value = DESCRIPCION;

            Cmd.Parameters.Add("@MATRICULA", SqlDbType.VarChar);
            Cmd.Parameters["@MATRICULA"].Value = MATRICULA;

            Cmd.Parameters.Add("@SERIE", SqlDbType.VarChar);
            Cmd.Parameters["@SERIE"].Value = SERIE;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertarArmaHomicidioRemitir(int ID_CARPETA, short ID_MUNICIPIO_CARPETA, int ID_ARMA, int ID_HOMICIDIO, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertarArmaHomicidioRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID_CARPETA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA"].Value = ID_CARPETA;

            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;

            Cmd.Parameters.Add("@ID_ARMA", SqlDbType.Int);
            Cmd.Parameters["@ID_ARMA"].Value = ID_ARMA;

            Cmd.Parameters.Add("@ID_HOMICIDIO ", SqlDbType.Int);
            Cmd.Parameters["@ID_HOMICIDIO "].Value = ID_HOMICIDIO;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;


            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRACNUCUnidadRemitir(String NUC, DateTime FechaNuc, short IdEstadoNuc, DateTime FechaEstadoNuc, short IdUsuarioNuc, short IdFormaInicio, short Detenido, short ID_MUNICIPIO_CARPETA, short IdUnidad, DateTime FechaRegistro,
            String RAC,DateTime FechaRac, short IdEstadoRac,DateTime FechaEstadoRac, short ActivoRac)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRACNUCUnidadRemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@NUC", SqlDbType.VarChar);
            Cmd.Parameters["@NUC"].Value = NUC;
            Cmd.Parameters.Add("@FechaNuc", SqlDbType.DateTime);
            Cmd.Parameters["@FechaNuc"].Value = FechaNuc;
            Cmd.Parameters.Add("@IdEstadoNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoNuc"].Value = IdEstadoNuc;
            Cmd.Parameters.Add("@FechaEstadoNuc", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEstadoNuc"].Value = FechaEstadoNuc;
            Cmd.Parameters.Add("@IdUsuarioNuc", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuarioNuc"].Value = IdUsuarioNuc;
            Cmd.Parameters.Add("@IdFormaInicio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdFormaInicio"].Value = IdFormaInicio;
            Cmd.Parameters.Add("@Detenido", SqlDbType.Bit);
            Cmd.Parameters["@Detenido"].Value = Detenido;
            Cmd.Parameters.Add("@ID_MUNICIPIO_CARPETA", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO_CARPETA"].Value = ID_MUNICIPIO_CARPETA;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaEstadoNuc;

            Cmd.Parameters.Add("@RAC", SqlDbType.VarChar);
            Cmd.Parameters["@RAC"].Value = RAC;
            Cmd.Parameters.Add("@FechaRac", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRac"].Value = FechaRac;
            Cmd.Parameters.Add("@IdEstadoRac", SqlDbType.SmallInt);
            Cmd.Parameters["@IdEstadoRac"].Value = IdEstadoRac;
            Cmd.Parameters.Add("@FechaEstadoRac", SqlDbType.DateTime);
            Cmd.Parameters["@FechaEstadoRac"].Value = FechaEstadoRac;
            Cmd.Parameters.Add("@ActivoRac", SqlDbType.SmallInt);
            Cmd.Parameters["@ActivoRac"].Value = ActivoRac;
            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public int InsertarOrdenOficioRemitir(int IdCarpeta, int IdMunicipioCarpeta, short IdTipoOrden, short IdJuzgado, String NumOficio, DateTime Fecha, String NumCarpetaAdministrativa, String JuezNombre, String JuezPaterno, String JuezMaterno, byte[] Pdf, int IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPGJ_NUC_JUD_ORDEN_OFICIORemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;

            Cmd.Parameters.Add("@IdTipoOrden", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoOrden"].Value = IdTipoOrden;

            Cmd.Parameters.Add("@IdJuzgado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdJuzgado"].Value = IdJuzgado;

            Cmd.Parameters.Add("@NumOficio", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumOficio"].Value = NumOficio;

            Cmd.Parameters.Add("@Fecha", SqlDbType.DateTime);
            Cmd.Parameters["@Fecha"].Value = Fecha;

            Cmd.Parameters.Add("@NumCarpetaAdministrativa", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumCarpetaAdministrativa"].Value = NumCarpetaAdministrativa;

            Cmd.Parameters.Add("@JuezNombre", SqlDbType.VarChar, 50);
            Cmd.Parameters["@JuezNombre"].Value = JuezNombre;

            Cmd.Parameters.Add("@JuezPaterno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@JuezPaterno"].Value = JuezPaterno;

            Cmd.Parameters.Add("@JuezMaterno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@JuezMaterno"].Value = JuezMaterno;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                DR.Read();
                return int.Parse(DR["IdOficio"].ToString());
            }
            else
            {
                return 0;
            }

            DR.Close();

        }

        public int InsertaPGJNucJudOrdenPersonaRemitir(int IdCarpeta, int IdMunicipioCarpeta, int IdPersona, int IdOficio, int IdEstadoOrden, int IdMotivoCancelacion, 
            DateTime FechaEjecucion, DateTime FechaCancelacion, DateTime FechaDisposicion, int IdAutoridadOrden, String OtraAutoridad, DateTime FechaAmparo, 
            String NumeroAmparo, short IdJuzgadoAmparo, String JuezNombreAmparo, String JuezPaternoAmparo, String JuezMaternoAmparo, int SuspensionProvisional, 
            DateTime FechaAutoSuspension, int SuspensionDefinitiva, DateTime FechaResolucionIncidente, int AmparoConcedido, DateTime FechaResolucionAmparo, 
            String EfectosAmparo, String Observaciones, int IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPGJ_NUC_JUD_ORDEN_PERSONARemitir", NUC_PNL.CnnPNL);
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

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

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

        public void InsertaPGJNucJudOrdenDelitoRemitir(int IdMunicipioOrdenDelito, int IdOrden, int IdDelito, int IdModalidad, int IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPGJ_NUC_JUD_ORDEN_DELITORemitir", NUC_PNL.CnnPNL);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdMunicipioOrdenDelito", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipioOrdenDelito"].Value = IdMunicipioOrdenDelito;

            Cmd.Parameters.Add("@IdOrden", SqlDbType.Int);
            Cmd.Parameters["@IdOrden"].Value = IdOrden;

            Cmd.Parameters.Add("@IdDelito", SqlDbType.Int);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;

            Cmd.Parameters.Add("@IdModalidad", SqlDbType.Int);
            Cmd.Parameters["@IdModalidad"].Value = IdModalidad;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;




            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        //REMITIR

        //****************************************** JUDICIALIZACION - ORDENES ***********************************************************************
        #region

        public bool TieneQRR(string IdCarpeta)
        {
            string Sql = "select * from PGJ_PERSONA P inner join PGJ_CARPETA_PERSONA CP on P.ID_PERSONA=CP.ID_PERSONA and CP.ID_CARPETA=" + IdCarpeta + " where P.NOMBRE='QUIEN' and P.PATERNO='RESULTE' and P.MATERNO='RESPONSABLE'" + " and CP.ID_TIPO_ACTOR=3";
            SqlCommand Cmd = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                return true;
            }
            DR.Close();
            return false;
        }

        public bool TieneImputados(string IdCarpeta)
        {
            string Sql = "select * from PGJ_PERSONA P inner join PGJ_CARPETA_PERSONA CP on P.ID_PERSONA=CP.ID_PERSONA and CP.ID_CARPETA=" + IdCarpeta + " and CP.ID_TIPO_ACTOR=3";
            SqlCommand Cmd = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                return true;
            }
            DR.Close();
            return false;
        }

        public bool TieneDelitoOrden(string IdOrden)
        {
            string Sql = "select * from PGJ_NUC_JUD_ORDEN_DELITO D where D.ID_ORDEN=" + IdOrden;
            SqlCommand Cmd = new SqlCommand(Sql, Data.CnnCentral);
            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                return true;
            }
            DR.Close();
            return false;
        }

        public int InsertaPGJNucJudOrdenOficio(int IdCarpeta, int IdMunicipioCarpeta, short IdTipoOrden, short IdJuzgado, String NumOficio, DateTime Fecha, String NumCarpetaAdministrativa, String JuezNombre, String JuezPaterno, String JuezMaterno, byte[] Pdf, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("InsertaPGJ_NUC_JUD_ORDEN_OFICIO", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;


            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;

            Cmd.Parameters.Add("@IdMunicipioCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipioCarpeta"].Value = IdMunicipioCarpeta;

            Cmd.Parameters.Add("@IdTipoOrden", SqlDbType.SmallInt);
            Cmd.Parameters["@IdTipoOrden"].Value = IdTipoOrden;

            Cmd.Parameters.Add("@IdJuzgado", SqlDbType.SmallInt);
            Cmd.Parameters["@IdJuzgado"].Value = IdJuzgado;

            Cmd.Parameters.Add("@NumOficio", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumOficio"].Value = NumOficio;

            Cmd.Parameters.Add("@Fecha", SqlDbType.DateTime);
            Cmd.Parameters["@Fecha"].Value = Fecha;

            Cmd.Parameters.Add("@NumCarpetaAdministrativa", SqlDbType.VarChar, 50);
            Cmd.Parameters["@NumCarpetaAdministrativa"].Value = NumCarpetaAdministrativa;

            Cmd.Parameters.Add("@JuezNombre", SqlDbType.VarChar, 50);
            Cmd.Parameters["@JuezNombre"].Value = JuezNombre;

            Cmd.Parameters.Add("@JuezPaterno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@JuezPaterno"].Value = JuezPaterno;

            Cmd.Parameters.Add("@JuezMaterno", SqlDbType.VarChar, 50);
            Cmd.Parameters["@JuezMaterno"].Value = JuezMaterno;

            Cmd.Parameters.Add("@Pdf", SqlDbType.Image);
            Cmd.Parameters["@Pdf"].Value = Pdf;

            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            if (DR.HasRows)
            {
                DR.Read();
                return int.Parse(DR["IdOficio"].ToString());
            }
            else
            {
                return 0;
            }

            DR.Close();

        }


        public int InsertaPGJNucJudOrdenPersona(int IdCarpeta, int IdMunicipioCarpeta, int IdPersona, int IdOficio, int IdEstadoOrden, int IdMotivoCancelacion, DateTime FechaEjecucion, DateTime FechaCancelacion, DateTime FechaDisposicion, int IdAutoridadOrden, String OtraAutoridad, DateTime FechaAmparo, String NumeroAmparo, short IdJuzgadoAmparo, String JuezNombreAmparo, String JuezPaternoAmparo, String JuezMaternoAmparo, int SuspensionProvisional, DateTime FechaAutoSuspension, int SuspensionDefinitiva, DateTime FechaResolucionIncidente, int AmparoConcedido, DateTime FechaResolucionAmparo, String EfectosAmparo, String Observaciones, int IdUsuario)
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


        public void ModificaPGJNucJudOrdenPersona(int IdOrden, int IdEstadoOrden, int IdMotivoCancelacion, DateTime FechaEjecucion, DateTime FechaCancelacion, DateTime FechaDisposicion, int IdAutoridadOrden, String OtraAutoridad, DateTime FechaAmparo, String NumeroAmparo, short IdJuzgadoAmparo, String JuezNombreAmparo, String JuezPaternoAmparo, String JuezMaternoAmparo, int SuspensionProvisional, DateTime FechaAutoSuspension, int SuspensionDefinitiva, DateTime FechaResolucionIncidente, int AmparoConcedido, DateTime FechaResolucionAmparo, String EfectosAmparo, String Observaciones, int IdUsuario)
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

        #endregion
        //******************************************** FIN DE JUDICIALIZACION - ORDENES *************************************************************



        public void InsertaRacAcumulada(int ID_CARPETA, int IdMunicipio, int IdUnidad, int ID_CARPETA_B, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("ACUMULAR_RAC_SISTEMA", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA_A_ACUMULAR", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA_A_ACUMULAR"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNIDAD"].Value = IdUnidad;
            Cmd.Parameters.Add("@ID_CARPETA_Q_CONTENDRA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA_Q_CONTENDRA"].Value = ID_CARPETA_B;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaNucAcumulada(int ID_CARPETA, int IdMunicipio, int IdUnidad, int ID_CARPETA_B, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("ACUMULAR_NUC_SISTEMA", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@ID_CARPETA_A_ACUMULAR", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA_A_ACUMULAR"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@ID_MUNICIPIO", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_MUNICIPIO"].Value = IdMunicipio;
            Cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.SmallInt);
            Cmd.Parameters["@ID_UNIDAD"].Value = IdUnidad;
            Cmd.Parameters.Add("@ID_CARPETA_Q_CONTENDRA", SqlDbType.Int);
            Cmd.Parameters["@ID_CARPETA_Q_CONTENDRA"].Value = ID_CARPETA_B;
            Cmd.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            Cmd.Parameters["@ID_USUARIO"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaRacCanalizada(int ID_CARPETA, short IdMunicipio, short IdInstitucion, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_Canalizada", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdInstitucion", SqlDbType.SmallInt);
            Cmd.Parameters["@IdInstitucion"].Value = IdInstitucion;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaRacIncompetencia(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario, short IdAgencia)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_Incompetencia", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdAgencia", SqlDbType.SmallInt);
            Cmd.Parameters["@IdAgencia"].Value = IdAgencia;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRacNoEjercicio(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_NoEjercicio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRacArchivoTemporal(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_ArchivoTemporal", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRacMedios(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_Medios", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRacMediosOpcion(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_MediosOpcion", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaRacAbstenerse(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_Abstenerse", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }


        public void InsertaRacRemitida(int ID_CARPETA, short IdMunicipio, int IdUsuario, DateTime FechaRegistro)
        {
            SqlCommand Cmd = new SqlCommand("InsertaRacRemitida", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime);
            Cmd.Parameters["@FechaRegistro"].Value = FechaRegistro;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaRacTramite(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_Tramite", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaRacConvenio(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_Convenio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaRacNoConvenio(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_NoConvenio", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaRacConvenioIncumplido(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_ConvenioIncumplido", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaRacResolvio(int ID_CARPETA, short IdMunicipio, string Resolvio, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("SP_InsertaRAC_Resuelto", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@Resolvio", SqlDbType.VarChar);
            Cmd.Parameters["@Resolvio"].Value = Resolvio;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            //IdMedioContacto = Convert.ToInt32(Cmd.Parameters["@IdMedioContacto"].Value);
            DR.Close();
        }

        public void InsertaNucArchivoTemporal(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("spIPGJ_NUC_ARCHIVO_TEMPORAL", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNucNoEjercicio(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("spIPGJ_NUC_NO_EJERCICIO", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNucCriterio(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("spIPGJ_NUC_CRITERIO_OPORTUNIDAD", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNucIncompetencia(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario, int IdAgencia)
        {
            SqlCommand Cmd = new SqlCommand("spIPGJ_NUC_INCOMPETENCIA", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdAgencia", SqlDbType.Int);
            Cmd.Parameters["@IdAgencia"].Value = IdAgencia;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNucAcuerdo(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("spIPGJ_NUC_ACUERDO_ABS_INV", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNucMedios(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario, int IdCentro)
        {
            SqlCommand Cmd = new SqlCommand("spIPGJ_NUC_MEDIOS_ALTERNATIVOS", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;
            Cmd.Parameters.Add("@IdCentro", SqlDbType.Int);
            Cmd.Parameters["@IdCentro"].Value = IdCentro;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaNucMediosElse(int ID_CARPETA, short IdMunicipio, short IdUnidad, int IdUsuario)
        {
            SqlCommand Cmd = new SqlCommand("spIPGJ_NUC_MEDIOS_ALTERNATIVOS_else", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = ID_CARPETA;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.SmallInt);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdUnidad", SqlDbType.SmallInt);
            Cmd.Parameters["@IdUnidad"].Value = IdUnidad;
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int);
            Cmd.Parameters["@IdUsuario"].Value = IdUsuario;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();
        }

        public void InsertaDatosIncompetencia(int IdCarpeta, int IdMunicipio, int IdArea, string Expediente, DateTime FechaInicio)
        {
            SqlCommand Cmd = new SqlCommand("spuiIncompetencia_datos", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdArea", SqlDbType.Int);
            Cmd.Parameters["@IdArea"].Value = IdArea;
            Cmd.Parameters.Add("@Expediente", SqlDbType.VarChar);
            Cmd.Parameters["@Expediente"].Value = Expediente;
            Cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime);
            Cmd.Parameters["@FechaInicio"].Value = FechaInicio;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }

        public void InsertaDatosIncompetenciaDelito(int IdCarpeta, int IdMunicipio, int IdDelito)
        {
            SqlCommand Cmd = new SqlCommand("spuiIncompetencia_delitos", Data.CnnCentral);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@IdCarpeta", SqlDbType.Int);
            Cmd.Parameters["@IdCarpeta"].Value = IdCarpeta;
            Cmd.Parameters.Add("@IdMunicipio", SqlDbType.Int);
            Cmd.Parameters["@IdMunicipio"].Value = IdMunicipio;
            Cmd.Parameters.Add("@IdDelito", SqlDbType.Int);
            Cmd.Parameters["@IdDelito"].Value = IdDelito;

            SqlDataReader DR = Cmd.ExecuteReader();
            DR.Close();

        }
    }
}