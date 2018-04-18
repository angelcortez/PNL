<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AtencionTemprana.Default" %>

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
<link href="personalizado.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 267px;
        }
        .style3
        {
            width: 200px;
            height: 90px;
        }
        .style4
        {
            width: 446px;
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
        <img alt="" class="style3" src="img/PGJ_INICIO.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </div>
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
<h2 align="Right">
        <asp:Label ID="Label4" runat="server" Text="VERSIÓN 5.02.18" ForeColor="#0064a7" style="font-size: large"></asp:Label>
</h2>

    <h2 align="center"><asp:Label ID="Label3" runat="server" Text="INICIAR SESIÓN" 
             ForeColor="#0064a7"></asp:Label>
    </h2>
   
    
    <table style="width: 100%;">
        <tr>
            <td class="style4" align="right">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" align="right">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="USUARIO:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="style2">
                <asp:TextBox ID="txtUsuario" runat="server" TabIndex="1"  style="text-transform :uppercase"></asp:TextBox>
&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4" align="right">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" Text="CONTRASEÑA:" BorderColor="#3333CC"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="style2">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" TabIndex="2" MaxLength="10" style="text-transform :uppercase"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;
            </td>
            <td class="style2">
                <asp:Button ID="cmdAceptar" runat="server" Text="ENTRAR" Font-Bold="true" 
                    onclick="cmdAceptar_Click" Width="156px" TabIndex="3" Height="30px" class="button" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="IP_MAQUINA" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IP_SERVER" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
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
                
               &nbsp;<span class="bold">Dirección de Informatica</span>
                <address>
                

                Av. José Sulaimán Chagnón, Libr. Naciones Unidas
                    Cd. Victoria, Tamaulipas, México  CP 87039 Tel. (834) 318.51.00
            </div>
        </div>
        <!-- End Left -->
    </div>
    <!-- End The Footer -->
</div>
<!-- End Footer -->

<!-- Begin DownMenu -->
    <%--<div id="downmenu">
    <!-- Begin Menu In Sixty -->
    <div class="menu-in-sixty">
        <a class="logo" href="#">Inicio</a>
        
        <!-- Menu -->
        <ul class="menu">
                <li><a href="#"><b>Item</b></a></li>
                
                <li><a href="#"><b>Item</b></a></li>
                <li><a href="#"><b>Item</b></a></li>
                <li><a href="#"><b>Item</b></a></li>
            </ul>
        <!-- Menu -->
        
        <!-- Being Orange Menu -->
        <ul class="important-three">
            <li class="item-1"><a href="#">Directorio</a></li>
            <li class="item-2"><a href="#">Sala de Prensa</a></li>
         
        </ul>
        <!-- End Orange Menu -->
    </div>
    <!-- End Menu In Sixty -->
</div>--%>
<!-- End DownMenu -->

<!-- Begin Script Zone -->
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
<script src="js/jquery.cycle.all.latest.js"></script>
<script src="js/fancy/jquery.fancybox.js?v=2.1.4"></script>
<script src="js/functions.js"></script>
<script src="js/bootstrap.min.js"></script>--%>


<!-- Bootstrap  -->
<!-- End Script Zone -->
    </form>
</body>
</html>
