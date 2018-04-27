<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NucJudOrdenesPersona.aspx.cs" Inherits="AtencionTemprana.NucJudOrdenesPersona" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function mostrarFichero(destino) {
            window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
            document.forms(0).submit();
        }
    
    </script>
<style>
        .hidden
         {
            display:none;
         }
        .margen 
        {
            margin:5px
        }
        #Radio1
    {
        width: 131px;
    }
        .style6
    {
        width: 230px;
        text-align: left;
        height: 19px;
    }
    .style9
    {
        text-align: left;
    }
        .style19
    {
        width: 1114px;
    }
    .style24
    {
        width: 278px;
        text-align: right;
    }
    .style27
    {
        text-align: left;
        }
        .style34
    {
    }
    .style35
    {
        width: 285px;
    }
        .style39
    {
        width: 246px;
    }
    .style40
    {
        width: 333px;
    }
        .style41
    {
        width: 256px;
    }
        .style42
    {
        width: 540px;
    }
    .style15
    {
        color: #669900;
        background-color: #FFFFFF;
        text-align: center;
    }
        .style44
    {
        width: 319px;
    }
        .style45
    {
        text-align: left;
        width: 148px;
    }
        .style48
    {
        text-align: left;
    }
    .style57
    {
        text-align: left;
        }
    .style58
    {
        text-align: left;
        height: 19px;
    }
        .style59
    {
        text-align: left;
    }
    .style61
    {
        text-align: left;
        width: 294px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">

<script type="text/javascript" >
    function txNombre() {
        if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
            event.returnValue = false;
    }

   </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
   <%-- <asp:PostBackTrigger ControlID="cmdElaborarInforme" />
    <asp:PostBackTrigger ControlID="cmdGuardar" />--%>
    </Triggers>
    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;<asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
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
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                </td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblArbol" runat="server" Visible="False">4</asp:Label>
            </td>
            <td>
                  </td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="PUESTO" runat="server" Font-Bold="True" 
                    ForeColor="#666666" style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        </table>
        </table>
      <table style="width: 100%;" runat="server" id="tbl_informe">
      <tr>
            <td class="style44">
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
            <td class="style42">
                    <asp:Label ID="ID_ESTADO_NUC" runat="server" Visible="False"></asp:Label>
                    <strong><span class="style15" style="font-size: medium">Datos de la Orden</span></strong></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
          <tr>
              <td class="style44">
                  &nbsp;</td>
              <td class="style42">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
          </tr>
        </table>
        <table class="style19">
            <tr>
                <td class="style45" colspan="3" bgcolor="#CCEEFF">
                    <asp:Label ID="Label2" runat="server" class="color-fuente" Text="Imputado" 
                        Font-Bold="True" ForeColor="Black"></asp:Label>
                    <br />
                    <asp:DropDownList ID="CboImputado" runat="server" Height="22px" Width="450px" 
                        TabIndex="1">
                    </asp:DropDownList>
                </td>
                <td bgcolor="#CCEEFF" class="style9" colspan="3">
                    <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Estado de la Orden"></asp:Label>
                    <asp:RadioButtonList ID="OptEstadoOrden" runat="server" AutoPostBack="True" 
                        Font-Bold="False" Font-Size="Small" ForeColor="Black" 
                        onselectedindexchanged="ActivarMotivoCancelacion" RepeatDirection="Horizontal" 
                        TabIndex="2" Width="417px">
                        <asp:ListItem Value="1">VIGENTE</asp:ListItem>
                        <asp:ListItem Value="2">CUMPLIMENTADA</asp:ListItem>
                        <asp:ListItem Value="3">CANCELADA</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style57" bgcolor="#CCEEFF" colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="#E8FFE8" class="style27" colspan="6">
                    <asp:Panel ID="PanelCumplimentada" runat="server" Visible="False">
                        <table style="width:100%;">
                            <tr>
                                <td class="style39" bgcolor="#EEFFCC">
                                    <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Fecha y hora de Ejecución"></asp:Label>
                                </td>
                                <td class="style40" bgcolor="#EEFFCC">
                                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Autoridad que ejecutó"></asp:Label>
                                </td>
                                <td class="style41" bgcolor="#EEFFCC">
                                    <asp:Label ID="LblAutoridad" runat="server" Font-Bold="False" Font-Italic="True" 
                                        Font-Size="Small" ForeColor="Black" Text="Especifique Autoridad" 
                                        Visible="False"></asp:Label>
                                </td>
                                <td bgcolor="#EEFFCC">
                                    <asp:Label ID="LblDisposicion" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" 
                                        Text="Fecha y hora en la que se puso a disposición del Juez de Control"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style39" bgcolor="#EEFFCC">
                                    <asp:TextBox ID="TxtFechaEjecucion" runat="server" MaxLength="16" 
                                        TabIndex="3" TextMode="DateTime" Width="190px"></asp:TextBox>
                                    <asp:CalendarExtender ID="TxtFechaEjecucion_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy hh:mm" TargetControlID="TxtFechaEjecucion">
                                    </asp:CalendarExtender>
                                </td>
                                <td class="style40" bgcolor="#EEFFCC">
                                    <asp:DropDownList ID="CboAutoridadOrden" runat="server" Height="22px" 
                                        Width="300px"  AutoPostBack="True" 
                                        onselectedindexchanged="ActivarAutoridadOtra" TabIndex="4">
                                    </asp:DropDownList>
                                </td>
                                <td class="style41" bgcolor="#EEFFCC">
                                    <asp:TextBox ID="TxtAutoridadOtro" runat="server" Height="22px" MaxLength="100" 
                                        Visible="False" Width="220px" TabIndex="5" style="text-transform :uppercase"></asp:TextBox>
                                </td>
                                <td bgcolor="#EEFFCC">
                                    <asp:TextBox ID="TxtFechaDisposicion" runat="server" MaxLength="16" 
                                        TabIndex="6" TextMode="DateTime" Width="190px"></asp:TextBox>
                                    <asp:CalendarExtender ID="TxtFechaDisposicion_CalendarExtender" 
                                        runat="server" Enabled="True" Format="dd/MM/yyyy hh:mm" 
                                        TargetControlID="TxtFechaDisposicion">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="style39" bgcolor="#EEFFCC">
                                    &nbsp;</td>
                                <td class="style40" bgcolor="#EEFFCC">
                                    &nbsp;</td>
                                <td colspan="2" bgcolor="#EEFFCC">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelCancelada" runat="server" Visible="False">
                        <table style="width:100%;">
                            <tr>
                                <td class="style34" bgcolor="#FFECCE">
                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Fecha y hora de Cancelación"></asp:Label>
                                </td>
                                <td class="style35" bgcolor="#FFECCE">
                                    <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Motivo de Cancelación"></asp:Label>
                                </td>
                                <td bgcolor="#FFECCE">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style34" bgcolor="#FFECCE">
                                    <asp:TextBox ID="TxtFechaCancelacion" runat="server" MaxLength="16" 
                                        TabIndex="7" TextMode="DateTime" Width="190px"></asp:TextBox>
                                    <asp:CalendarExtender ID="TxtFechaCancelacion_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy hh:mm" TargetControlID="TxtFechaCancelacion">
                                    </asp:CalendarExtender>
                                </td>
                                <td class="style35" bgcolor="#FFECCE">
                                    <asp:RadioButtonList ID="OptMotivoCancelacion" runat="server" 
                                        Font-Bold="False" Font-Size="Small" ForeColor="Black" 
                                        RepeatDirection="Horizontal" TabIndex="8" Width="500px">
                                        <asp:ListItem Value="1">Prescripción</asp:ListItem>
                                        <asp:ListItem Value="2">Muerte del Activo</asp:ListItem>
                                        <asp:ListItem Value="3">Autorización Judicial</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td bgcolor="#FFECCE">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style34" bgcolor="#FFECCE" colspan="2">
                                    &nbsp;</td>
                                <td bgcolor="#FFECCE">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAmparo" runat="server" Visible="False">
                        <table style="width:100%;">
                            <tr>
                                <td class="style34" bgcolor="#FFFFD5">
                                    <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Fecha y hora de la Notificación del Amparo" 
                                        Width="300px"></asp:Label>
                                </td>
                                <td class="style35" bgcolor="#FFFFD5">
                                    <asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Número de Amparo"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Juzgado que otorgó el Amparo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style34" bgcolor="#FFFFD5">
                                    <asp:TextBox ID="TxtFechaAmparo" runat="server" MaxLength="16" TabIndex="9" 
                                        TextMode="DateTime" Width="190px"></asp:TextBox>
                                    <asp:CalendarExtender ID="TxtFechaAmparo_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy hh:mm" TargetControlID="TxtFechaAmparo">
                                    </asp:CalendarExtender>
                                </td>
                                <td class="style35" bgcolor="#FFFFD5">
                                    <asp:TextBox ID="TxtNumeroAmparo" runat="server" Height="22px" MaxLength="100" 
                                        Width="200px" TabIndex="10"></asp:TextBox>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    <asp:DropDownList ID="CboJuzgadoAmparo" runat="server" Height="22px" 
                                        Width="300px" TabIndex="11">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" 
                                        Text="Juez de Distrito (Nombre, Apellido Paterno, Apellido Materno)"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34" colspan="3">
                                    <asp:TextBox ID="TxtJuezNombreAmparo" runat="server" Height="22px" 
                                        MaxLength="100" Width="200px" TabIndex="12" style="text-transform :uppercase" onkeypress="txNombre()"></asp:TextBox>
                                    <asp:TextBox ID="TxtJuezPaternoAmparo" runat="server" Height="22px" 
                                        MaxLength="100" Width="200px" TabIndex="13" style="text-transform :uppercase" onkeypress="txNombre()"></asp:TextBox>
                                    <asp:TextBox ID="TxtJuezMaternoAmparo" runat="server" Height="22px" 
                                        MaxLength="100" Width="200px" TabIndex="14" style="text-transform :uppercase" onkeypress="txNombre()"></asp:TextBox>
                               <br />
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtJuezNombreAmparo"
                ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-zA-Z ]*$" Font-Size="Small"  ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtJuezPaternoAmparo"
                ErrorMessage="SOLO LETRAS EN EL APELLIDO PATERNO" ValidationExpression="^[a-zA-Z ]*$" Font-Size="Small"  ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtJuezMaternoAmparo"
                ErrorMessage="SOLO LETRAS EN EL APELLIDO MATERNO" ValidationExpression="^[a-zA-Z ]*$" Font-Size="Small"  ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Suspensión Provisional"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Fecha del Auto de la Suspensión Provisional"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    <asp:RadioButtonList ID="OptSuspensionProvisional" runat="server" 
                                        Font-Bold="False" Font-Size="Small" ForeColor="Black" 
                                        RepeatDirection="Horizontal" TabIndex="15" Width="260px">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    <asp:TextBox ID="TxtFechaAutoSuspension" runat="server" MaxLength="16" 
                                        TabIndex="16" TextMode="DateTime" Width="190px"></asp:TextBox>
                                    <asp:CalendarExtender ID="TxtFechaAutoSuspension_CalendarExtender" 
                                        runat="server" Enabled="True" Format="dd/MM/yyyy hh:mm" 
                                        TargetControlID="TxtFechaAutoSuspension">
                                    </asp:CalendarExtender>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    <asp:Label ID="Label51" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Suspensión Definitiva"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    <asp:Label ID="Label52" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" 
                                        Text=" Fecha de la notificación de la resolución incidental"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    <asp:RadioButtonList ID="OptSuspensionDefinitiva" runat="server" 
                                        Font-Bold="False" Font-Size="Small" ForeColor="Black" 
                                        RepeatDirection="Horizontal" TabIndex="17" Width="260px">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    <asp:TextBox ID="TxtFechaResolucionIncidente" runat="server" MaxLength="16" 
                                        TabIndex="18" TextMode="DateTime" Width="190px"></asp:TextBox>
                                    <asp:CalendarExtender ID="TxtFechaResolucionIncidente_CalendarExtender" 
                                        runat="server" Enabled="True" Format="dd/MM/yyyy hh:mm" 
                                        TargetControlID="TxtFechaResolucionIncidente">
                                    </asp:CalendarExtender>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    &nbsp;</td>
                                <td bgcolor="#FFFFD5">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    <asp:Label ID="Label53" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Amparo Concedido"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    <asp:Label ID="Label54" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Fecha de resolución del Amparo"></asp:Label>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    <asp:Label ID="Label55" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="Efectos de la Resolución"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34">
                                    <asp:RadioButtonList ID="OptAmparoConcedido" runat="server" Font-Bold="False" 
                                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="19" 
                                        Width="260px">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td bgcolor="#FFFFD5" class="style35">
                                    <asp:TextBox ID="TxtFechaResolucionAmparo" runat="server" MaxLength="16" 
                                        TabIndex="20" TextMode="DateTime" Width="190px"></asp:TextBox>
                                    <asp:CalendarExtender ID="TxtFechaResolucionAmparo_CalendarExtender" 
                                        runat="server" Enabled="True" Format="dd/MM/yyyy hh:mm" 
                                        TargetControlID="TxtFechaResolucionAmparo">
                                    </asp:CalendarExtender>
                                </td>
                                <td bgcolor="#FFFFD5">
                                    <asp:TextBox ID="TxtEfectosAmparo" runat="server" Height="22px" MaxLength="250" 
                                        Width="291px" TabIndex="21"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFD5" class="style34" colspan="3">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style48" colspan="6">
                    <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Observaciones"></asp:Label>
                    <br />
                    <asp:TextBox ID="TxtObservaciones" runat="server" Height="66px" MaxLength="250" 
                        TextMode="MultiLine" Width="1076px" TabIndex="22" style="text-transform :uppercase"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style58" colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style27" colspan="6" align="center">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red" style="text-align: center"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="style61">
                    &nbsp;</td>
                <td class="style59">
                    <asp:Button ID="CmdOrdenPersona" runat="server" CssClass="button" 
                        Font-Bold="True" Height="26px" OnClick="CmdOrdenPersona_Click" 
                        Text="Registrar Orden" Width="212px" TabIndex="23" />
                </td>
                <td colspan="2">
                </td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style24">
                    <asp:Button ID="CmdRegresar" runat="server" CssClass="button" Height="26px" 
                        OnClick="CmdRegresar_Click" Text="&lt;&lt; Regresar" Width="212px" 
                        TabIndex="25" />
                </td>
            </tr>
            <tr>
                <td class="style59" colspan="6">
                    &nbsp;</td>
            </tr>
            </tr>
        </table>

        <asp:Panel ID="Panel1" runat="server" Height="187px">
            <asp:Button ID="CmdDelito" runat="server" CssClass="button" Height="26px" 
                OnClick="CmdDelito_Click" Text="Agregar Delitos a la Orden" Width="212px" 
                Visible="False" BackColor="#99CCFF" Font-Bold="True" TabIndex="24" />
            <br />
            <asp:GridView ID="GridDelitos" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                GridLines="None" Width="1075px" ShowHeaderWhenEmpty="True">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID_ORDEN_DELITO" HeaderText="ID_ORDEN_DELITO" 
                        SortExpression="ID_ORDEN_DELITO" Visible="False" />
                    <asp:BoundField DataField="DELITO" HeaderText="DELITO" SortExpression="DELITO">
                    <ItemStyle Width="800px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MODALIDAD" HeaderText="MODALIDAD" 
                        SortExpression="MODALIDAD">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                SelectCommand="ConsultaNucJudOrdenDelitos" 
                SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="IdOrden" SessionField="IdOrden" 
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </asp:Panel>

        <br />
    
  </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>
