<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculo.aspx.cs" Inherits="AtencionTemprana.Vehiculo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function mostrarFichero(destino) {
             window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
             document.forms(0).submit();
         }
    
    </script>
    <style type="text/css">
        .style2
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
      
        
<div id="main-wrapper">
 
    <script type="text/javascript" >
        $(function () {
            console.log("Hola");
            var campo = $(".txtSerie");
            campo.keypress(function (e) {
                key = e.keyCode || e.which;
                tecla = String.fromCharCode(key).toUpperCase();
                letras = "ABCDEFGHJKLMNPRSTUVWXYZ0123456789";
                especiales = "8-37-39-46";


                tecla_especial = false
                for (var i in especiales) {
                    if (key == especiales[i]) {
                        tecla_especial = true;
                        break;
                    }
                }

                if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                    return false;
                }
            });
            campo.keyup(function () {
                campo.val((campo.val()).toUpperCase());
            });
        });

        //PLACA
        $(function () {
            console.log("HolaP");
            var campo = $(".txtPlaca");
            campo.keypress(function (e) {
                key = e.keyCode || e.which;
                tecla = String.fromCharCode(key).toUpperCase();
                letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                especiales = "8-37-39-46";


                tecla_especial = false
                for (var i in especiales) {
                    if (key == especiales[i]) {
                        tecla_especial = true;
                        break;
                    }
                }

                if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                    return false;
                }
            });
            campo.keyup(function () {
                campo.val((campo.val()).toUpperCase());
            });
        });

        //        function validaPlaca(evt) 
        //        {
        //            var charCode = (evt.which) ? evt.which : event.keyCode
        //            var charCode = (evt.which) ? evt.which : event.keyCode
        //                        //                        if (((charCode == 8) || (charCode == 46) || (charCode >= 35 && charCode <= 40) || (charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105))) 
        //                        //Backspace                         numeros                                 numeros
        //                        if (((charCode == 8) || (charCode >= 48 && charCode <= 57) || (charCode >= 96 && charCode <= 105)
        //                        // A - H 
        //                                || (charCode >= 65 && charCode <= 90))) {
        //                            return true;
        //                        }
        //                        else {
        //                            return false;
        //                        }
        //         }
    </script> 
       <script type="text/javascript">

           function revisarFechaRecuperado(sender, args) {
               if (sender._selectedDate > new Date()) {
                   alert("¡No se puede seleccionar un día posterior a la fecha actual!");
                   sender._selectedDate = new Date();
                   sender._textbox.set_Value(sender._selectedDate.format(sender._format))
               }
           }

           function revisarFechaDepositado(sender, args) {
               if (sender._selectedDate > new Date()) {
                   alert("¡No se puede seleccionar un día posterior a la fecha actual!");
                   sender._selectedDate = new Date();
                   sender._textbox.set_Value(sender._selectedDate.format(sender._format))
               }
           }
    </script>


       <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>
      
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        
        <asp:PostBackTrigger ControlID="ddlDelito" />
        <asp:PostBackTrigger ControlID="ddlMarca" />
        <asp:PostBackTrigger ControlID="ddlProcedencia" />
        <asp:PostBackTrigger ControlID="ddlEstadoVehiculo" />
      

        <asp:PostBackTrigger ControlID="btnGuardarDocu" />
        <asp:PostBackTrigger ControlID="btnDescargarDocumento" />
        <asp:PostBackTrigger ControlID="btnGuardarAut" />
        <asp:PostBackTrigger ControlID="btnAutorizacion" />
        <asp:PostBackTrigger ControlID="cmdGuardar" />
        <asp:PostBackTrigger ControlID="cmdRegresar" />



    </Triggers>
    <ContentTemplate>


    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
        <tr>
            <td>
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
        <tr>
            <td>
                <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 

     <h2> 
        <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NUMERO DE ACCIDENTE VIAL"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ID_VEHICULO" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lblDelito" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="DELITO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtNumeroAccidente" runat="server" Height="22px" 
                        MaxLength="20" Width="420px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                    <asp:DropDownList ID="ddlDelito" runat="server" Width="200px" class="chosen-select"
                        AutoPostBack="True" onselectedindexchanged="ddlDelito_SelectedIndexChanged"> </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MARCA"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SUBMARCA"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MODELO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="COLOR"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlMarca" runat="server" Width="200px" class="chosen-select"
                        AutoPostBack="True" onselectedindexchanged="ddlMarca_SelectedIndexChanged" 
                        Enabled="False">
                    </asp:DropDownList>
                   <asp:RequiredFieldValidator id="RequiredFieldValidator1" ControlToValidate="ddlMarca" InitialValue="999" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE MARCA" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubMarca" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False" >
                    </asp:DropDownList>
<%--                   <asp:RequiredFieldValidator id="RequiredFieldValidator2" ControlToValidate="ddlSubMarca" InitialValue="0" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE SUBMARCA" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </td>
                <td>
                    <asp:DropDownList ID="ddlModelo" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator3" ControlToValidate="ddlModelo" InitialValue="0" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE MODELO" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlColor" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator4" ControlToValidate="ddlColor" InitialValue="999" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE COLOR" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
               <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PROCEDENCIA"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SERIE"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PLACA"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PLACA DEL ESTADO"></asp:Label>
                </td>

            </tr>
            <tr>
                <td>
                
                    <asp:DropDownList ID="ddlProcedencia" runat="server" AutoPostBack="True" class="chosen-select"
                        onselectedindexchanged="ddlProcedencia_SelectedIndexChanged" Width="200px" 
                        Enabled="False">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator5" ControlToValidate="ddlProcedencia" InitialValue="99" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE PROCEDENCIA" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtSerie" runat="server" MaxLength="17" Width="200px" 
                        name="txtSerie" class="txtSerie" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPlaca" runat="server" MaxLength="10" Width="200px" 
                        name="txtPlaca" class="txtPlaca" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlacasEstado" runat="server" class="chosen-select"
                        style="margin-bottom: 0px" Width="200px" Enabled="False">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator6" ControlToValidate="ddlPlacasEstado" InitialValue="0" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE UN ESTADO PARA LA PLACA" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
               <td>
                    <asp:Label ID="lblSenas" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="PLACA EXTRANJERA"></asp:Label>
               </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="TIPO DE VEHICULO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PUESTO A DISPOSICION"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="ASEGURADO POR"></asp:Label>
                </td>
            </tr>
            <tr>
               <td>
                    <asp:TextBox ID="txtSenas" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
               </td>
                <td>
                    <asp:DropDownList ID="ddlTipoVehiculo" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator7" ControlToValidate="ddlTipoVehiculo" InitialValue="999" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE TIPO DE VEHÍCULO" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDisposicion" runat="server" style="margin-bottom: 0px" class="chosen-select"
                        Width="200px" Enabled="False">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator8" ControlToValidate="ddlDisposicion" InitialValue="99" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE PUESTO A DISPOSICION" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAsegurado" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator9" ControlToValidate="ddlAsegurado" InitialValue="0" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE ASEGURADO POR" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAseguradora" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="ASEGURADORA"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTipo" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="TIPO DE USO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPropietario" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="PROPIETARIO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEstadoVehiculo" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="ESTADO DEL VEHICULO"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlAseguradora" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator10" ControlToValidate="ddlAseguradora" InitialValue="99" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE ASEGURADORA" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                   <asp:DropDownList ID="ddlTipoUso" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False"></asp:DropDownList>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator11" ControlToValidate="ddlTipoUso" InitialValue="99" runat="server" Display="Dynamic" 
                    ErrorMessage="SELECCIONE TIPO DE USO" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                   <asp:DropDownList ID="ddlPropietario" runat="server" Width="200px" 
                        class="chosen-select" Enabled="False"></asp:DropDownList>
                </td>
                <td>
                   <asp:DropDownList ID="ddlEstadoVehiculo" runat="server" Width="200px"
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlEstadoVehiculo_SelectedIndexChanged" 
                        Enabled="False"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                 </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            <tr>
                <td>
                    <asp:Label ID="lblMotor" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="NUMERO DE MOTOR"></asp:Label> 
                </td>
                <td>
                     <asp:Label ID="lblRegistroVehicular" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="REGISTRO VEHICULAR"></asp:Label> 
                </td>
                <td>
                   <asp:Label ID="lblFechaRobo" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="FECHA DE ROBO"></asp:Label> 
                </td>
                <td>
                    <asp:Label ID="lblHoraRobo" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="HORA DE ROBO"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                       <asp:TextBox ID="txtNumeroMotor" runat="server" MaxLength="50" Width="200px" ReadOnly="True"
                         ></asp:TextBox>
                </td>
                <td>
                      <asp:TextBox ID="txtRegistroVehicular" runat="server" MaxLength="50" 
                          Width="200px" ReadOnly="True" ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox ID="txtFechaRobo" runat="server" MaxLength="10" Width="200px" 
                         Enabled="False" ReadOnly="True" 
                         ></asp:TextBox>
                </td>
                <td>
                     <asp:TextBox ID="txtHoraRobo" runat="server" MaxLength="10" Width="200px"  
                         Enabled="False" ReadOnly="True" 
                       ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Width="200px"  
                        Visible=false ReadOnly="True" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtHoraInicio" runat="server" MaxLength="10" Width="200px"  
                        Visible=false ReadOnly="True"  ></asp:TextBox>   
                 </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtExpediente" runat="server" MaxLength="20" Width="200px" 
                        Visible=false ReadOnly="True"   ></asp:TextBox> 
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
           <tr>
                <td class="style2"><asp:Label ID="lblFechaRec" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="FECHA DE RECUPERADO" Visible=false></asp:Label> </td>
                <td class="style2"><asp:Label ID="lblHoraRec" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="HORA DE RECUPERADO ('HH:MM')" Visible=false></asp:Label> </td>
                <td class="style2"><asp:Label ID="lblDepositado" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="DEPOSITADO EN" Visible=false></asp:Label> </td>
                <td class="style2"><asp:Label ID="lblFechaDepositado" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="FECHA DE DEPOSITO" Visible=false></asp:Label> </td>
            </tr>
           <tr>
                <td><asp:TextBox ID="txtFechaRecuperado" runat="server" MaxLength="50" 
                        Width="200px" Visible=false ReadOnly="True"  ></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaRecuperadoCalendar" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaRecuperado" OnClientDateSelectionChanged="revisarFechaRecuperado">
                    </asp:CalendarExtender>
                </td>
                <td><asp:TextBox ID="txtHoraRecuperado" runat="server" MaxLength="5" Width="200px"  
                        Visible=false ReadOnly="True"></asp:TextBox>
                </td>
                <td><asp:DropDownList ID="ddlDepositado" runat="server" Width="200px" Visible=false class="chosen-select"
                        ></asp:DropDownList></td>
                <td><asp:TextBox ID="txtFechaDeposito" runat="server" MaxLength="50" Width="200px" 
                        Visible=false ReadOnly="True"  ></asp:TextBox>
                 <asp:CalendarExtender ID="txtFechaDepositoCalendar" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaDeposito" OnClientDateSelectionChanged="revisarFechaDepositado">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="lblHoraDepositado" runat="server" Font-Bold="True" Font-Size="Small"  ForeColor="Black" Text="HORA DE DEPOSITADO ('HH:MM')" Visible=false></asp:Label></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtHoraDeposito" runat="server" MaxLength="5" Width="200px" 
                        Visible=false ReadOnly="True"></asp:TextBox></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="OBSERVACIONES"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtObservaciones" runat="server" Height="139px" 
                        MaxLength="5000" TextMode="MultiLine" Width="903px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                <td colspan="4">
                  <asp:Label ID="lblAutorizacion" runat="server" Font-Bold="True" Font-Size="Small"   ForeColor="Black" Text="CODIGO DE AUTORIZACIÓN DE BAJA DE VEHÍCULO"></asp:Label>
                 <br />
                 <asp:TextBox ID="txtAutorizacion" runat="server" Width="343px" Visible="True" 
                        Enabled="False"></asp:TextBox>
                    <br />
                   <asp:Label ID="lblErrorAuto" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor=red></asp:Label>
                 <asp:Label ID="lblIdAutorizacion" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor=red Visible=false></asp:Label>
                </td>
            </tr>
            <tr style="display:none">
                <td colspan="4"> <asp:Label ID="Label332" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SELECCIONE DOCUMENTO PDF"></asp:Label>
               <br />
               <asp:FileUpload ID="fileUpload" runat="server" Height="28px" Width="353px" />        
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                        <br />
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                                <asp:Label ID="lblPregunta" runat="server" 
                        Text="LOS DATOS DEL VEHÍCULO ROBADO SE SUBIRAN AL REGISTRO PÚBLICO VEHICULAR" 
                        Visible=False Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
<%--                <asp:Label ID="lblRes" runat="server" Text="" Visible=false></asp:Label>

                <br />
                 <asp:Button ID="btnSi" runat="server"  Text="SI"  Font-Bold="True" Height="30px" 
                        Width="30px" onclick="btnSi_Click" Visible=false/>
                &nbsp;
                <asp:Button ID="btnNo" runat="server"  Text="NO"  Font-Bold="True" Height="30px" 
                        Width="30px" Visible=false onclick="btnNo_Click"/>--%>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                          <asp:Button ID="btnGuardarDocu" runat="server" Text="GUARDAR OFICIO" 
            Font-Bold="True" Height="40px" Width="185px"  
                              onclick="btnGuardarDocu_Click" class="button" Visible="False"  />
             &nbsp;
          <asp:Button ID="btnDescargarDocumento" runat="server" Text="GENERAR OFICIO" Visible="False" 
            Font-Bold="True" Height="40px" Width="185px"  
                        onclick="btnDescargarDocumento_Click" class="button"  />
                &nbsp;
               <asp:Button ID="btnGuardarAut" runat="server" Text="GUARDAR AUTORIZACION" 
                        Font-Bold="True" Height="40px" Width="185px" onclick="btnGuardarAut_Click" 
                        Visible="False" class="button"  />
                &nbsp;
                  <asp:Button ID="btnAutorizacion" runat="server" 
                        Text="GENERAR AUTORIZACION" Font-Bold="True" Height="40px" Width="185px"  
                        onclick="btnAutorizacion_Click" class="button" Visible="False"  />
                    &nbsp;
                    <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                        Text="GUARDAR" Font-Bold="True" Height="40px" Width="185px" class="button" OnClientClick="this.disabled=true;this.value = 'GUARDAR...'" 
      UseSubmitBehavior="false" Visible="False"/>
                    &nbsp;
                    <asp:Button ID="cmdRegresar" runat="server" onclick="cmdRegresar_Click" 
                        Text="REGRESAR" Font-Bold="True" Height="40px" Width="185px" class="button" />
                </td>
            </tr>
            <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>


    </ContentTemplate>
    </asp:UpdatePanel>
    
    
</div>

</asp:Content>



