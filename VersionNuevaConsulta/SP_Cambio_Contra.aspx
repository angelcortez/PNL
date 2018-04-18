<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SP_Cambio_Contra.aspx.cs" Inherits="AtencionTemprana.SP_Cambio_Contra" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title> Gobierno del Estado de Tamaulipas </title>
<link href="style.css" rel="stylesheet" type="text/css" media="screen"/>
<link href="js/fancy/jquery.fancybox.css?v=2.1.4" rel="stylesheet" type="text/css" media="screen" />
<link href="css/bootstrap.min.css" rel="stylesheet" media="screen"/>
<link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
<link href="favicon.ico" rel="icon" type="image/x-icon" />
<link href="ios.png" rel="apple-touch-icon" />
 <style type="text/css">
        .style1
        {
     }
        .style2
        {
     }
        


.button {
  border: 1px solid #DBE1EB;
    font-family: Arial, Verdana;
    padding-left: 7px;
    padding-right: 7px;
    padding-top: 5px;
    padding-bottom: 5px;
    border-radius: 4px;
    -moz-border-radius: 10px;
    -webkit-border-radius: 10px;
    -o-border-radius: 10px;
    background: #97C93D;
    background: linear-gradient(left, #97C93D, #97C93D);
    background: -moz-linear-gradient(left, #97C93D, #97C93D);
    background: -webkit-linear-gradient(left, #97C93D, #97C93D);
    background: -o-linear-gradient(left, #97C93D, #97C93D);
    color: #FFFFFF;
   
}


        </style>
        <script type="text/javascript"  language="JavaScript">
            function Desabilitar() {
                document.getElementById("Vinculo").disabled = true;

            }


            function Logout() {

                Session.Abandon();
                Session.Contents.RemoveAll();

                System.Web.Security.FormsAuthentication.SignOut();
                Response.Redirect("Default.aspx");

            }

 </script>


 <script type="text/javascript"  language="JavaScript">

     if (history.forward(0)) {
         location.replace(history.forward(0))
     }

</script>

</head>
<body>
      <form id="form1" runat="server">
   
   
    <!-- Begin Header -->
<div id="header">
  
    
    <!-- Begin Logo Search -->
    <div class="nine-sixty" id="logo-search">
               <asp:Image ID="Image1" runat="server" Height="93px" 
    ImageUrl="~/img/PGJ_INICIO.jpg" Width="274px" />    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </div>
    <!-- End Logo Search -->
    
    <!-- Begin Banner Navigation -->
    <div id="fix-full">
    <div class="nine-sixty" id="banner-navigation">
        <%--   <div id="navigation">
            <ul class="menu">
                <li><a href="#"><b>Item</b></a></li>
               
                <li><a href="#"><b>Item</b></a></li>
                <li><a href="#"><b>Item</b></a></li>
                <li><a href="#"><b>Item</b></a></li>
                <li><a href="#"><b>Item</b></a></li>
            </ul>
        </div>--%>
    </div>
    </div>
    <!-- End Banner Navigation -->
</div>
<!-- End Header -->

<!-- Begin Main Wrapper -->

       
        
<div id="main-wrapper">
    
    <h2 align="center"><asp:Label ID="Label3" runat="server" Text="CAMBIO DE CONTRASEÑA" 
            ForeColor="#0064a7"></asp:Label>
    </h2>
   
    
    <table style="width: 100%;">
        <tr>
            <td class="style1" align="center" colspan="4">
                <asp:Label ID="lblNota" runat="server" Font-Bold="True" Font-Size="Small" 
                    Font-Underline="False" ForeColor="Red" 
                    
                    Text="NOTA: POR SEGURIDAD ES NECESARIO ACTUALIZAR SU CONTRASEÑA. LA CUAL, DEBE TENER UN RANGO ENTRE 8 Y 10 CARACTERES ACEPTANDO ÚNICAMENTE NÚMEROS Y LETRAS DISTINGUIENDO MAYÚSCULAS Y MINÚSCULAS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="style2">
&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lblNueva" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="NUEVA CONTRASEÑA:" BorderColor="#3333CC"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="style2">
                <asp:TextBox ID="txtPass" runat="server" TabIndex="2"  
                  MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                    ControlToValidate="txtPass" Display="Dynamic" ErrorMessage="Ingresa Contraseña" 
                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
               <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Rango de 8 - 10 caracteres (Nueva Contraseña)" ValidationExpression="^.{8,10}$" 
                    ControlToValidate="txtPass" Font-Size="Small" ForeColor="Red">*</asp:RegularExpressionValidator>
                    
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtPass" ErrorMessage="Nueva Contraseña no tiene el formato correcto. Nota: Solo Numeros y Letras" 
                    ValidationExpression="^[A-Z0-9a-z]*$" Font-Size="Small" ForeColor="Red">*</asp:RegularExpressionValidator>
                    --%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="txtPass" 
                    ErrorMessage="La contraseña debe contener: Un Rango de 8-10 caracteres, al menos una letra mayúscula, una letra minúscula y 1 número" 
                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,10}$" 
                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RegularExpressionValidator>
                    
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                <asp:Label ID="lblNuevaVer" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="VERIFICAR CONTRASEÑA:" BorderColor="#3333CC"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="style2">
                <asp:TextBox ID="txtPassVer" runat="server" TabIndex="2"  
                   MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                    ControlToValidate="txtPassVer" Display="Dynamic" ErrorMessage="Ingresa Verificar Contraseña" 
                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassVer" ControlToValidate="txtPass" 
                    ErrorMessage="Ambas contraseñas deben coincidir" ForeColor="Red" 
                    Font-Size="Small">*</asp:CompareValidator>
                    
               <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="Rango de 8 - 10 caracteres (Verificar Contraseña)" ValidationExpression="^.{8,10}$" 
                    ControlToValidate="txtPassVer" Font-Size="Small" ForeColor="Red">*</asp:RegularExpressionValidator>
                    
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="txtPassVer" ErrorMessage="Verficar Contraseña no tiene el formato correcto. Nota: Solo Numeros y Letras" 
                    ValidationExpression="^[A-Z0-9a-z]*$" Font-Size="Small" ForeColor="Red">*</asp:RegularExpressionValidator>
                    --%>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td class="style2" colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                    ForeColor="Red" />
                <br />
                <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" 
                   Width="156px" TabIndex="3" Height="30px"   CssClass="button" 
                    onclick="cmdGuardar_Click"/>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1" align="center" colspan="4">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Button ID="cmdIniciar" runat="server" Text="INICIAR SESION" 
                   Width="156px" TabIndex="3" Height="30px"   
                    CssClass="button" onclick="cmdIniciar_Click" Visible="False"/>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    
</div>


<!-- End Main Wrapper -->

<!-- Begin Footer -->
<div id="footer">
    <!-- Begin The Footer -->
    <div class="nine-sixty" id="the-footer">
        <!-- Begin Left -->
        <div class="left">
            <div class="address">
               <span class="bold">Procuraduría General de Justicia</span>
                
               &nbsp;<span class="bold">Direccion de Informatica</span>
                <address>
                

                Av. José Sulaimán Chagnón, Libto. Naciones Unidas
                    Cd. Victoria, Tamaulipas, México  CP 87039 Tel. (834) 318.51.00
            </div>
        </div>
        <!-- End Left -->
    </div>
    <!-- End The Footer -->
</div>

    </form>
</body>
</html>
