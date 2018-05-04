<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PNLUnidades.aspx.cs" Inherits="AtencionTemprana.PNLUnidades" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        .style3
        {
            width: 200px;
            height: 90px;
        }
        .style5
        {
            width: 130px;
        }
        .style6
        {
            width: 74px;
            height: 22px;
        }
        .style7
        {
            width: 200px;
            height: 22px;
        }
        .style8
        {
            height: 22px;
        }
        .style13
        {
            width: 200px;
            height: 56px;
        }
        .style19
        {
            width: 74px;
        }
        .style21
        {
            width: 446px;
            height: 46px;
        }
        .style23
        {
            width: 200px;
            height: 57px;
        }
        .style25
        {
            width: 74px;
            height: 46px;
        }
        .style26
        {
            height: 46px;
        }
        .style27
        {
            width: 74px;
            height: 57px;
        }
        .style28
        {
            height: 57px;
        }
        .style29
        {
            width: 74px;
            height: 56px;
        }
        .style30
        {
            height: 56px;
        }
        .style31
        {
            width: 74px;
            height: 59px;
        }
        .style32
        {
            width: 200px;
            height: 59px;
        }
        .style33
        {
            height: 59px;
        }
        .style35
        {
            width: 446px;
            height: 62px;
        }
        .style36
        {
            width: 74px;
            height: 62px;
        }
        .style37
        {
            height: 62px;
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
     
           <div style="background-color:#005CB9;" id="navigation">
           <ul style="list-style:none; background-color:#005CB9; "   >
                
                <li style="font-weight:bold;"> <asp:HyperLink ID="hCerrarSesion" runat="server" Font-Bold="True" ForeColor="White" 
                                NavigateUrl="~/Loguin.aspx">CERRAR SESIÓN</asp:HyperLink></li>
                
            </ul>
        </div>
    </div>
    </div>
    <!-- End Banner Navigation -->
</div>
<!-- End Header -->

<!-- Begin Main Wrapper -->      
        
        <div id="main-wrapper">
<table style="width: 100%;">
            <tr>
                <td colspan="2" class="style5">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" class="color-fuente" Text="Unidades PNL"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style6">
                    </td>
                    <td class="style7">
                        </td>
                    <td class="style8">
                        </td>
                </tr>
            </tr>
            <tr>
                <td align="center" class="style25"> 
                    &nbsp;<asp:ImageButton 
                        ID="ImageButton1" runat="server" Height="40px" Width="40px" ImageUrl="img/view-tree.png" 
                        OnClick="Button1_Click" Text="Button" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
               <td class="style21">
                    <asp:Label ID="Label7" runat="server"  Font-Size="Medium"  Text="VICTORIA"></asp:Label>
                    </td>
                <td class="style26">   
                    </td>
            </tr>
            <tr>
                <td align="center" class="style27">                
                    <asp:ImageButton ID="ImageButton2" runat="server" Width="40px" Height="40px" 
                        ImageUrl="img/view-tree.png" onclick="Button2_Click" Text="Button" />
                    </td>
                <td class="style23">
                    <asp:Label ID="Label8" runat="server"  Font-Size="Medium"  Text="TAMPICO"></asp:Label>
                    </td>
                <td class="style28">
                    </td>
            </tr>
            <tr>
                <td align="center" class="style29">                
                
                    <asp:ImageButton ID="ImageButton3" runat="server" Width="40px" Height="40px" 
                        ImageUrl="img/view-tree.png" onclick="Button3_Click" Text="Button" />
                
                    </td>
                <td class="style13">
                    <asp:Label ID="Label9"  runat="server"  Font-Size="Medium"  Text="REYNOSA"></asp:Label>
                    </td>
                <td class="style30">
                    </td>
            </tr>
            <tr>
                <td align="center" class="style31">
               
                    <asp:ImageButton ID="ImageButton4" runat="server" Height="40px" Width="40px"
                        ImageUrl="img/view-tree.png" onclick="Button4_Click" Text="Button" />
               
                    </td>
                <td class="style32">
                    <asp:Label ID="Label10" runat="server"  Font-Size="Medium"  Text="MATAMOROS"></asp:Label>
                    </td>
                <td class="style33">
                    </td>
            </tr>
            <tr>
                <td align="center" class="style36">
               
                    <asp:ImageButton ID="ImageButton5" runat="server" Height="40px" Width="40px"
                        ImageUrl="img/view-tree.png" onclick="Button5_Click" Text="Button" />
               
                    </td>
                <td class=style35>
                    <asp:Label ID="Label11" runat="server"  Font-Size="Medium"  Text="NUEVO LAREDO"></asp:Label>
                    </td>
                <td class="style37">
                    </td>
            </tr>
                <tr>
                <td align="right" class="style19">
                    <asp:Label ID="Label12" runat="server"  ForeColor="Black"></asp:Label>
                </td>
                    <td align="right" class="style3">
                        &nbsp;</td>
                    <td align="right">
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
                    </address>
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



