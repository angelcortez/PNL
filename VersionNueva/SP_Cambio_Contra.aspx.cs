using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AtencionTemprana
{
    public partial class SP_Cambio_Contra : System.Web.UI.Page
    {
        Data PGJ = new Data();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            PGJ.sp_Actualiza_Clave_Sistema(int.Parse(Session["IdUsuario"].ToString()), Server.HtmlEncode(txtPass.Text.Trim()));

            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 3, "Actualizo Contraseña", 0);                     
            lblError.Text = "CONTRASEÑA ACTUALIZADA CORRECTAMENTE";

            cmdGuardar.Visible = false;
            cmdIniciar.Visible = true;
            lblNueva.Visible = false;
            txtPass.Visible=false;
            lblNota.Visible = false;
            lblNuevaVer.Visible = false;
            txtPassVer.Visible = false;

        }

        protected void cmdIniciar_Click(object sender, EventArgs e)
        {
            PGJ.InsertarBitacora(int.Parse(Session["IdUsuario"].ToString()), Session["IP_MAQUINA"].ToString(), HttpContext.Current.Request.Url.AbsoluteUri, 7, "Regresar Iniciar Sesion", 0);
            
            Response.Redirect("Default.aspx");
        }


            //-------EJEMPLOS-----
            //Minimum 8 characters at least 1 Alphabet and 1 Number
            //<asp:TextBox ID="txtPolicy1" runat="server"></asp:TextBox><br />
            //<asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtPolicy1"
            //    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ForeColor="Red" />
            //----Valid Password Examples: pass1234 OR PaSs1234 OR PASS1234
 
            //Minimum 8 characters at least 1 Alphabet, 1 Number and 1 Special Character
            //<asp:TextBox ID="txtPolicy2" runat="server"></asp:TextBox><br />
            //<asp:RegularExpressionValidator ID="Regex2" runat="server" ControlToValidate="txtPolicy2"
            //    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"
            //    ErrorMessage="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character" ForeColor="Red" />
            //----Valid Password Examples: pass@123 OR PaSS#123 OR PASS@123
 
            //Minimum 8 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet and 1 Number
            //<asp:TextBox ID="txtPolicy3" runat="server"></asp:TextBox><br />
            //<asp:RegularExpressionValidator ID="Regex3" runat="server" ControlToValidate="txtPolicy3"
            //ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"
            //ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 Number" ForeColor="Red" />
            //-----Valid Password Examples: PaSs1234 OR pASS1234
 
 
            //Minimum 8 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet, 1 Number and 1 Special Character
            //<asp:TextBox ID="txtPolicy4" runat="server"></asp:TextBox><br />
            //<asp:RegularExpressionValidator ID="Regex4" runat="server" ControlToValidate="txtPolicy4"
            //    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
            //ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="Red" />
            //-----Valid Password Examples: PaSs@123 OR pAss@123
 
 
            //Minimum 8 and Maximum 10 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet, 1 Number and 1 Special Character
            //<asp:TextBox ID="txtPolicy5" runat="server"></asp:TextBox><br />
            //<asp:RegularExpressionValidator ID="Regex5" runat="server" ControlToValidate="txtPolicy5"
            //    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,10}"
            //    ErrorMessage="Password must contain: Minimum 8 and Maximum 10 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character"
            //ForeColor="Red" />
            //-----Valid Password Examples: PaSs@123
    }
}