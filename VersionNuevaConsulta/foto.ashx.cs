using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AtencionTemprana
{
    /// <summary>
    /// Descripción breve de foto
    /// </summary>
    public class foto : IHttpHandler
    {
        Data PGJ = new Data();
        public void ProcessRequest(HttpContext context)
        {
            PGJ.ConnectServer();
            string sql = "Select FOTO From PGJ_FOTO_ORDEN_PI Where ID_FOTO_ORDEN_PI = " + context.Request.QueryString["Id"];
            Data.CnnCentral.Close();

            SqlCommand SqlCom = new SqlCommand(sql, Data.CnnCentral);

            Data.CnnCentral.Open();
            byte[] byteImage = ((byte[])SqlCom.ExecuteScalar());


            if (byteImage != null)
            {
                context.Response.ContentType = "image/jpeg";
                context.Response.Expires = 0;
                context.Response.Buffer = true;
                context.Response.Clear();
                context.Response.BinaryWrite(byteImage);
                context.Response.End();
            }
            Data.CnnCentral.Close();
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}