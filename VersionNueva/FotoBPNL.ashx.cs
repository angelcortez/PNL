using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AtencionTemprana
{
    public partial class FotoBPNL : System.Web.UI.Page
    {


        public void ProcessRequest(HttpContext context)
        {
            int empno = int.Parse(context.Request.QueryString["Id"]);

            context.Response.ContentType = "image/jpeg";

            SqlConnection cnx = new SqlConnection("Data Source=" + "172.23.8.25" + ";Initial Catalog=PNL_NSJP2;User ID=SA;Password=ADMIN_1");
            SqlCommand cmd = new SqlCommand("VER_FOTO_PERSONA", cnx);
            cmd.Parameters.Add("@ID", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = empno;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cnx.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    byte[] imgBytes = (byte[])cmd.ExecuteScalar();

                    context.Response.BinaryWrite(imgBytes);
                }
                else
                {
                    //context.Response.BinaryWrite(FileToByteArray(Server.MapPath(".") + @"\Imagenes\orde.png"));
                }

            }
            catch (Exception ex)
            {

            }
            //*  finally
            //  {
            //      if (cnx != null)
            //      {
            //          cnx.Close();
            //      }
            //  }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public static byte[] FileToByteArray(string fileName)
        {
            byte[] fileContent = null;

            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
            long byteLength = new System.IO.FileInfo(fileName).Length;
            fileContent = binaryReader.ReadBytes((Int32)byteLength);
            fs.Close();
            fs.Dispose();
            binaryReader.Close();
            return fileContent;
        }
    }
}
//            string sql = "Select Fotografia From PNL_FOTOGRAFIA_PNL Where IdFotografia = " + context.Request.QueryString["Id"];
//            Data.CnnCentral.Close();

//            SqlCommand SqlCom = new SqlCommand(sql, Data.CnnCentral);

//            Data.CnnCentral.Open();
//            byte[] byteImage = ((byte[])SqlCom.ExecuteScalar());


//            if (byteImage != null)
//            {
//                context.Response.ContentType = "image/png";
//                context.Response.Expires = 0;
//                context.Response.Buffer = true;
//                context.Response.Clear();
//                context.Response.BinaryWrite(byteImage);
//                context.Response.End();
//            }
//            Data.CnnCentral.Close();
//        }



//        public bool IsReusable
//        {
//            get
//            {
//                return false;
//            }
//        }


//    }
//}