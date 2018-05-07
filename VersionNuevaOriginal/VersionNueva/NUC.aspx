<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NUC.aspx.cs" Inherits="AtencionTemprana.NUC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    <Triggers><%--
                        <asp:PostBackTrigger ControlID="gvDigital" />
                          <asp:PostBackTrigger ControlID="gvPDF" />--%>
                         </Triggers>

    <ContentTemplate>
    
   

    <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
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
                
                <asp:Label ID="lblArbol" runat="server" Visible="False">4</asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 
    <h2><asp:Label ID="Label1" runat="server" Text="NUMERO UNICO DE CARPETA" ForeColor="#006600"></asp:Label></h2>
    <table style="width: 100%;">
        <tr>
            <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
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
        <tr>
            <td>
                <asp:ImageButton ID="Iniciar" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/INICIAR.png" onclick="Iniciar_Click" />
                              
            </td>
            <td>
                <asp:ImageButton ID="Judicializar" runat="server" Height="63px" 
                    ImageUrl="~/img/JUDICIALIZAR.png" onclick="Judicializar_Click" />
                 
            </td>
            <td>
                <asp:ImageButton ID="Archivo" runat="server" Height="63px" 
                    ImageUrl="~/img/ARCHIVO TEMPORAL.png" onclick="Archivo_Click" />
                     

                  
            </td>
            <td>
                <asp:ImageButton ID="Ejercicio" runat="server" Height="63px" 
                    ImageUrl="~/img/NOEJERCICIO.png" onclick="Ejercicio_Click" />
                    
                     
            </td>
            <td class="style6">
                &nbsp;<asp:ImageButton ID="Criterio" runat="server" Height="63px" 
                    ImageUrl="~/img/OPORTUNIDAD.png" onclick="Criterio_Click" />
                 

                    
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="Incompetencia" runat="server" Height="63px" 
                    ImageUrl="~/img/incom.png" onclick="Incompetencia_Click" />
            </td>
            <td>
                <asp:ImageButton ID="Acuerdo" runat="server" Height="63px" 
                    ImageUrl="~/img/ABSTENERSE.png" onclick="Acuerdo_Click" />
            </td>
            <td colspan="2">
                <asp:ImageButton ID="Medios" runat="server" Height="63px" 
                    ImageUrl="~/img/estados/MEDIOS ALTERNOS.png" onclick="Medios_Click" />
            </td>
            <td class="style6">
                <asp:Button ID="CmdRemitir" runat="server" Text="Remitir" Width="154px" 
                    onclick="CmdRemitir_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" style="text-align: center" ForeColor="green" BorderWidth="2">
                    <table style="width:100%;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                                    ForeColor="#006600" Text="NUMERO DE NUC"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="NUMERO"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="AÑO"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="FECHA INICIO"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtNumero" runat="server" MaxLength="4" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtNumero" Display="Dynamic" ErrorMessage="INGRESA NUMERO" 
                                    Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAño" runat="server" MaxLength="4" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="INGRESA AÑO" 
                                    Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtFechaInicio" Display="Dynamic" 
                                    ErrorMessage="INGRESA FECHA" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
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
                <asp:Panel ID="Panel2" runat="server" style="text-align: center" ForeColor="green" BorderWidth="2">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblSuspender" runat="server" ForeColor="#006600" 
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="txtFechaJuducualizar" Display="Dynamic" 
                                        ErrorMessage="INGRESA FECHA JUDICIALIZAR" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                    <asp:Panel ID="Panel3" runat="server" style="text-align: center" ForeColor="green" BorderWidth="2">
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblRemitir" runat="server" ForeColor="#006600" 
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
                                            Font-Size="Small" ForeColor="Black" Text="FECHA ARCHIVO TEMPORAL"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtFechaArchivo" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtFechaArchivo_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaArchivo">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ControlToValidate="txtFechaArchivo" Display="Dynamic" 
                                            ErrorMessage="INGRESA FECHA ARCHIVO TEMPORAL" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        <asp:Panel ID="Panel4" runat="server" style="text-align: center" ForeColor="green" BorderWidth="2">
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblResolver" runat="server" ForeColor="#006600" 
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
                                                Font-Size="Small" ForeColor="Black" Text="FECHA NO EJERCICIO"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtFechaEjercicio" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFechaEjercicio_CalendarExtender" runat="server" 
                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaEjercicio">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                ControlToValidate="txtFechaEjercicio" Display="Dynamic" 
                                                ErrorMessage="INGRESA FECHA NO EJERCICIO" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                            <asp:Panel ID="Panel5" runat="server" style="text-align: center" ForeColor="green" BorderWidth="2">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Label ID="lblResolver0" runat="server" ForeColor="#006600" 
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
                                                    Font-Size="Small" ForeColor="Black" Text="FECHA CRITERIO"></asp:Label>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtFechaCriterio" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                                <asp:CalendarExtender ID="txtFechaCriterio_CalendarExtender" runat="server" 
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaCriterio">
                                                </asp:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                    ControlToValidate="txtFechaCriterio" Display="Dynamic" 
                                                    ErrorMessage="INGRESA FECHA CRITERIO" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                <asp:Panel ID="Panel7" runat="server" BorderWidth="2" ForeColor="green" 
                    style="text-align: center">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblResolver1" runat="server" ForeColor="#006600" 
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
                                    Font-Size="Small" ForeColor="Black" Text="FECHA ACUERDO"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtFechaAcuerdo" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaAcuerdo_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaAcuerdo">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="txtFechaAcuerdo" Display="Dynamic" 
                                    ErrorMessage="INGRESA FECHA ACUERDO" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                <asp:Panel ID="Panel8" runat="server" BorderWidth="2" ForeColor="green" 
                    style="text-align: center">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblResolver2" runat="server" ForeColor="#006600" 
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
                                    Font-Size="Small" ForeColor="Black" Text="FECHA INCOMPETECIA"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtFechaIncompetancia" runat="server" MaxLength="10" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaIncompetancia_CalendarExtender" 
                                    runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txtFechaIncompetancia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="txtFechaIncompetancia" Display="Dynamic" 
                                    ErrorMessage="INGRESA FECHA INCOMPETECIA" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                  <asp:Panel ID="Panel9" runat="server" BorderWidth="2" ForeColor="green" 
                    style="text-align: center">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblResolver3" runat="server" ForeColor="#006600" 
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
                                    Font-Size="Small" ForeColor="Black" Text="FECHA "></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtFechaIMediacion" runat="server" MaxLength="10" 
                                    Width="200px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtFechaIMediacion_CalendarExtender" 
                                    runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                    TargetControlID="txtFechaIMediacion">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                    ControlToValidate="txtFechaIMediacion" Display="Dynamic" 
                                    ErrorMessage="INGRESA FECHA " Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                  <asp:Panel ID="Panel10" runat="server" BorderWidth="2" ForeColor="green" 
                    style="text-align: center">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label2" runat="server" ForeColor="#006600" 
                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                    Text="REMITIR EXPEDIENTE A OTRA UNIDAD"></asp:Label>
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
                                <asp:DropDownList ID="DDUnidades" runat="server" Width="800px">
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
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:ImageButton ID="ImgSi8" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi8_Click" 
                                     />
                                &nbsp;<asp:ImageButton ID="ImgNo8" runat="server" ImageUrl="~/img/no.png" onclick="ImgNo8_Click" 
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
                        Width="927px">
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

