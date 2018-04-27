<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NUC_PNL.aspx.cs" Inherits="AtencionTemprana.NUC_PNL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<script type="text/javascript">
    function deshabilita() {
        var btn = "<%= ImgSi8.ClientID %>";
        if (confirm("Confirme postback")) {
            document.getElementById(btn).disabled = true;
            return true;
        }
        return false;
    }
</script>--%>

    <script type="text/javascript">
        function mostrarFichero(destino) {
            window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
            document.forms(0).submit();
        }
    
    </script>

    <style type="text/css">
        .style5
        {
            height: 619px;
        }
        .style6
        {
            width: 195px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
    <asp:PostBackTrigger ControlID="GridResultado" />
    </Triggers>

    <ContentTemplate>
    
   

    <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" class="color-fuente"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
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
                <asp:Label ID="IdP" runat="server" Visible="False"></asp:Label>

                <asp:Label ID="lblArbol" runat="server" Visible="False">8</asp:Label>
                <asp:Label ID="Label14" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="TotalLH" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="lblIdCN" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="ID_LUGAR_HECHOS" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_CONSECUTIVO_DELITO" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_CONSECUTIVO_PERSONA" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_CONSECUTIVO_PERSONAQUIEN" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_LUGAR_DETENCION" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_IMPUTACION" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_VEHICULO" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_AUTORIZACION" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_PDF" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_HOMICIDIO" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="ID_ARMA" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 
    <h2><asp:Label ID="Label1" runat="server" Text="NÚMERO UNICO DE CARPETA" class="color-fuente"></asp:Label></h2>
    <table style="width: 100%;">
        <tr>
            <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                </td>
            <td>
                    <asp:Label ID="ID_ESTADO_NUC" runat="server" Visible="False"></asp:Label>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr style="display:none">
            <td>
                <asp:ImageButton ID="Iniciar" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/INICIAR.png" onclick="Iniciar_Click" />
                              
            </td>
            <td>
                <asp:ImageButton ID="Judicializar" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/JUDICIALIZAR-01.png" 
                    onclick="Judicializar_Click" />
                 
            </td>
            <td>
                <asp:ImageButton ID="Archivo" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/ARCHIVO TEMPORAL-01.png" onclick="Archivo_Click" />
                     

                  
            </td>
            <td>
                <asp:ImageButton ID="Ejercicio" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/NO EJERCICIO-01.png" onclick="Ejercicio_Click" />
                    
                     
            </td>
            <td class="style6">
                &nbsp;<asp:ImageButton ID="Criterio" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/CRITERIODEOPORTUNIDAD-01.png" 
                    onclick="Criterio_Click" />
                 

                    
            </td>
        </tr>
        <tr style="display:none">
            <td>
                <asp:ImageButton ID="Incompetencia" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/icompetencia.png" onclick="Incompetencia_Click" />
            </td>
            <td>
                <asp:ImageButton ID="Acuerdo" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/abstenerse-01.png" onclick="Acuerdo_Click" />
            </td>
            <td >
                <asp:ImageButton ID="Medios" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/MEDIOS ALTERNOS.png" onclick="Medios_Click" />
            </td>
            <td >
               <asp:ImageButton ID="Remitir" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/REMITIR-01.png" onclick="Remitir_Click" 
                    Visible=false/></td>
        <td>
            <asp:ImageButton ID="Acumular" runat="server" Height="63px" 
                ImageUrl="~/img/estados/ACUMULAR-01.png" 
                Visible="false" onclick="Acumular_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" style="text-align: center"  BorderWidth="2">
                    <table style="width:100%;">
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                                     class="color-fuente" Text="INICIAR NUMERO UNICO DE CARPETA"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="NUMERO" Visible="False"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="AÑO" Visible="False"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtNumero" runat="server" MaxLength="4" Width="200px" 
                                    Visible="False"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAño" runat="server" MaxLength="4" Width="200px" 
                                    Visible="False"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Width="200px" 
                                    Visible="False"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                                    ForeColor="Red" />
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                                        <br />
                                        <asp:ImageButton ID="ImgSi" runat="server" 
                        ImageUrl="~/img/si.png" onclick="ImgSi_Click" />
                    &nbsp;<asp:ImageButton ID="ImgNo" runat="server" ImageUrl="~/img/no.png" 
                        onclick="ImgNo_Click" />
                    
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" style="text-align: center"  BorderWidth="2">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblSuspender" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" 
                                        Text="JUDICIALIZAR"></asp:Label>
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
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblInstitucion0" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="FECHA JUDICIALIZAR"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaJuducualizar" runat="server" MaxLength="10" 
                                        Width="200px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                        Format="dd/MM/yyyy" TargetControlID="txtFechaJuducualizar">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImgSi1" runat="server" ImageUrl="~/img/si.png" 
                                        onclick="ImgSi1_Click" />
                                    &nbsp;<asp:ImageButton ID="ImgNo1" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo1_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                       
                    </asp:Panel> 
                    <asp:Panel ID="Panel3" runat="server" style="text-align: center"  BorderWidth="2">
                                                <asp:Label ID="lblMsjArchivoTemporal" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblRemitir" runat="server" class="color-fuente"
                                            style="font-weight: 700; font-size: large; text-align: left;" 
                                            Text="ARCHIVO TEMPORAL"></asp:Label>
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
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblInstitucion1" runat="server" Font-Bold="True" 
                                            Font-Size="Small" ForeColor="Black" Text="FECHA ARCHIVO TEMPORAL" Visible=false></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtFechaArchivo" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                        <asp:CalendarExtender ID="txtFechaArchivo_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaArchivo">
                                        </asp:CalendarExtender>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:ImageButton ID="ImgSi2" runat="server" ImageUrl="~/img/si.png" 
                                            onclick="ImgSi2_Click" />
                                        &nbsp;<asp:ImageButton ID="ImgNo2" runat="server" ImageUrl="~/img/no.png" 
                                            onclick="ImgNo2_Click" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            
                        </asp:Panel>
                        <asp:Panel ID="Panel4" runat="server" style="text-align: center"  BorderWidth="2">
                                                        <asp:Label ID="lblMsjNoEjercicio" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=True></asp:Label>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblResolver" runat="server" class="color-fuente"
                                                style="font-weight: 700; font-size: large; text-align: left;" 
                                                Text="NO EJERCICIO"></asp:Label>
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
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblInstitucion2" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="FECHA NO EJERCICIO" Visible=false></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtFechaEjercicio" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFechaEjercicio_CalendarExtender" runat="server" 
                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaEjercicio">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:ImageButton ID="ImgSi3" runat="server" ImageUrl="~/img/si.png" 
                                                onclick="ImgSi3_Click" />
                                            &nbsp;<asp:ImageButton ID="ImgNo3" runat="server" ImageUrl="~/img/no.png" 
                                                onclick="ImgNo3_Click" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                
                            </asp:Panel>
                            <asp:Panel ID="Panel5" runat="server" style="text-align: center"  BorderWidth="2">
                          <asp:Label ID="lblMsjCriterio" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Label ID="lblResolver0" runat="server" class="color-fuente" 
                                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                                    Text="CRITERO DE OPORTUNIDAD"></asp:Label>
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
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Label ID="lblInstitucion3" runat="server" Font-Bold="True" 
                                                    Font-Size="Small" ForeColor="Black" Text="FECHA CRITERIO" Visible=false></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtFechaCriterio" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                                <asp:CalendarExtender ID="txtFechaCriterio_CalendarExtender" runat="server" 
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaCriterio">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:ImageButton ID="ImgSi4" runat="server" ImageUrl="~/img/si.png" 
                                                    onclick="ImgSi4_Click" />
                                                <asp:ImageButton ID="ImgNo4" runat="server" ImageUrl="~/img/no.png" 
                                                    onclick="ImgNo4_Click" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                <asp:Panel ID="Panel7" runat="server" BorderWidth="2" 
                    style="text-align: center">
                   <asp:Label ID="lblMsjAcuerdo" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblResolver1" runat="server" class="color-fuente" 
                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                    Text="ACUERDO PARA ABSTENERSE DE INVESTIGAR"></asp:Label>
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
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblInstitucion4" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="FECHA ACUERDO" Visible=false></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtFechaAcuerdo" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaAcuerdo_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaAcuerdo">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:ImageButton ID="ImgSi5" runat="server" ImageUrl="~/img/si.png" 
                                    onclick="ImgSi5_Click" />
                                &nbsp;<asp:ImageButton ID="ImgNo5" runat="server" ImageUrl="~/img/no.png" 
                                    onclick="ImgNo5_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel8" runat="server" BorderWidth="2" 
                    style="text-align: center">
                    <asp:Label ID="lblMsjIncompetencia" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblResolver2" runat="server" class="color-fuente" 
                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                    Text="INCOMPETENCIA"></asp:Label>
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
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="AGENCIA"></asp:Label>
                                <asp:DropDownList ID="ddlAgencia" runat="server" Width="300px">
                                </asp:DropDownList>
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
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblInstitucion5" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="FECHA INCOMPETECIA" Visible=false></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtFechaIncompetancia" runat="server" MaxLength="10" 
                                    Width="200px" Visible=false></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaIncompetancia_CalendarExtender" 
                                    runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txtFechaIncompetancia">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:ImageButton ID="ImgSi6" runat="server" ImageUrl="~/img/si.png" 
                                    onclick="ImgSi6_Click" />
                                &nbsp;<asp:ImageButton ID="ImgNo6" runat="server" ImageUrl="~/img/no.png" 
                                    onclick="ImgNo6_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                  <asp:Panel ID="Panel9" runat="server" BorderWidth="2"  
                    style="text-align: center">
                    <asp:Label ID="lblMsjMedios" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblResolver3" runat="server" class="color-fuente" 
                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                    Text="MEDIOS ALTERNOS DE SOLUCION DE CONFLICTOS"></asp:Label>
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
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="CENTRO DE JUSTICIA ALTERNATIVA"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlCentroMediacion" runat="server" Width="300px">
                                </asp:DropDownList>
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
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblInstitucion6" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="FECHA " Visible=false></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtFechaIMediacion" runat="server" MaxLength="10" 
                                    Width="200px" Visible=false></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaIMediacion_CalendarExtender" 
                                    runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txtFechaIMediacion">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:ImageButton ID="ImgSi7" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi7_Click" 
                                     />
                                &nbsp;<asp:ImageButton ID="ImgNo7" runat="server" ImageUrl="~/img/no.png" onclick="ImgNo7_Click" 
                                    />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                  <asp:Panel ID="Panel10" runat="server" BorderWidth="2" 
                    style="text-align: center">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label2" runat="server" 
                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                    Text="REMITIR EXPEDIENTE A OTRA UNIDAD" class="color-fuente" ></asp:Label>
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
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="UNIDAD DE INVESTIGACION A REMITIR"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:DropDownList ID="DDUnidades" runat="server" Width="600px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                         <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                        AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <img src="img/loading.gif" align="top" width="100" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                            </td>

                        </tr>
                   <tr>
                            <td colspan="3" align="center">
                                <asp:SqlDataSource ID="SqlDataRemitidasExi" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                                    SelectCommand="buscarNucRemitidasId" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="IdCarpeta" Name="IdCarpeta" 
                                            PropertyName="Text" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            <asp:GridView ID="GridResultado" runat="server" Visible=False CellPadding="4" 
                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                        <Columns>
                         <asp:BoundField DataField="Resultado" HeaderText="" ReadOnly="True"  SortExpression="Resultado" />
                        </Columns>
                    </asp:GridView>
                            </td>

                        </tr>

                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td >
</td>
                            <td>
                                <asp:Label ID="LblMensajeRemitir" runat="server" Font-Bold="True" 
                                    Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    <br />
                             <asp:Label ID="lblConfirmacion" runat="server" Font-Bold="True"   Font-Size="Medium" ForeColor="Red"></asp:Label>
                
                                     
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnRemitir" runat="server" Text="REMITIR" class="button" 
                                    onclick="btnRemitir_Click"/>
                               <%-- <asp:ImageButton ID="ImgSi8" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi8_Click" />--%>
    <asp:Button ID="ImgSi8" runat="server" OnClientClick="this.disabled=true;this.value = 'Remitiendo Carpeta...'" 
      UseSubmitBehavior="false" onclick="ImgSi8_Click"  class="buttonSI" Height="40px" Width="40px" Visible=false/>
    &nbsp;
   <%-- <asp:ImageButton ID="ImgNo8" runat="server" ImageUrl="~/img/no.png" onclick="ImgNo8_Click"  />--%>
   <asp:Button ID="ImgNo8" runat="server" OnClientClick="this.disabled=true;this.value = '..'" 
      UseSubmitBehavior="false"  class="buttonNO" Height="40px" Width="40px" onclick="ImgNo8_Click" Visible=false/>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>

                 <asp:Panel ID="PanelAcumular" runat="server" BorderWidth="2"  Visible=false
                    style="text-align: center">
                     <asp:Label ID="lblMsjAcumular" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=false></asp:Label>
                    <br />
                    <asp:Label ID="lblMensajeE" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"  Visible=false></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"  Visible=false></asp:Label>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label8" runat="server"  class="color-fuente"
                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                    Text="ACUMULAR"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblIdCarpetaAcumular" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" ></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label91" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="NÚMERO"></asp:Label> &nbsp;
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="AÑO"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                             <asp:TextBox ID="txtNumeroAcumular" runat="server" MaxLength="5"  Width="50" onkeypress="return soloNumeros(event);"></asp:TextBox>
                             &nbsp;
                             <asp:TextBox ID="txtAnioAcumular" runat="server" MaxLength="4"  Width="50" onkeypress="return soloNumeros(event);"></asp:TextBox>
                             <br />

                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Text="<p>*Solo se admiten números" ControlToValidate="txtNumeroAcumular" Runat="server" Display="Dynamic" EnableClientScript="False" ValidationExpression="^[0-9]*$" ForeColor="Red"  Font-Bold="True"></asp:RegularExpressionValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Text="<p>*Solo se admiten números" ControlToValidate="txtAnioAcumular" Runat="server" Display="Dynamic" EnableClientScript="False" ValidationExpression="^[0-9]*$" ForeColor="Red"  Font-Bold="True" ></asp:RegularExpressionValidator>
<%--                                <asp:DropDownList ID="ddlAcumular" runat="server" Width="300px" class="chosen-select">
                                </asp:DropDownList>--%>
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
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:ImageButton ID="SiAcumular" runat="server" ImageUrl="~/img/si.png" onclick="SiAcumular_Click" 
                                     />
                                &nbsp;<asp:ImageButton ID="NoAcumular" runat="server" ImageUrl="~/img/no.png" onclick="NoAcumular_Click"
                                    />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>



            </td>
        </tr>
        <tr>
            <td colspan="5" class="style5">
                <asp:Panel ID="Panel6" runat="server" Height="758px" ScrollBars="Auto">
                    <br />
                    <asp:TreeView ID="TVCarpeta" runat="server" Height="151px" ImageSet="Simple" 
                        Width="927px" >
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                            HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <RootNodeStyle Font-Bold="True" ForeColor="#CC0000" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                            HorizontalPadding="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </asp:Panel>
                <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Red"></asp:Label>
                <br />
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
            <td class="style6">
                &nbsp;</td>
        </tr>
    </table>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    
</div>

</asp:Content>
