<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RAC.aspx.cs" Inherits="AtencionTemprana.RAC" %>
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
            height: 17px;
        }
        .style3
        {
            height: 20px;
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
          
    </Triggers>

    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
            </td>
            <%--<td>
                &nbsp;</td>
            <td>
                &nbsp;</td>--%>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
        <tr>
            <td>
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <%--<td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                &nbsp;</td>--%>
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
<h2><asp:Label ID="Label1" runat="server" Text="REGISTRO DE ATENCION CIUDADANA" 
        class="color-fuente"></asp:Label></h2>
         <table style="width: 100%; display:none">
            <tr style="display:none">
                <td>
                    <asp:ImageButton ID="Canalizar" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/CANALIZAR.png" onclick="Canalizar_Click" />
                    <br />
                    <asp:ImageButton ID="Iniciar" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/INICIAR.png" onclick="Iniciar_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="Suspender" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/MEDIOS ALTERNOS.png" onclick="Suspender_Click" 
                        ImageAlign="Middle" />
                </td>
                <td>
                    <asp:ImageButton ID="Incompetencia" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/icompetencia.png" onclick="Incompetencia_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="Remitir" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/DERIVAR-01.png" onclick="Remitir_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="Resolver" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/resolver-01.png" onclick="Resolver_Click" />
                </td>
            </tr>
            <tr style="display:none">
                <td>
                    <asp:ImageButton ID="Archivo" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/ARCHIVO TEMPORAL-01.png" onclick="Archivo_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="Ejercicio" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/NO EJERCICIO-01.png" onclick="Ejercicio_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="Acuerdo" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/abstenerse-01.png" onclick="Acuerdo_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="Acumular" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/ACUMULAR-01.png" 
                        Visible="false" onclick="Acumular_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="display:none">
                <td>
                    <asp:Button ID="cmdConvenio" runat="server" Height="38px" 
                        onclick="cmdConvenio_Click" Text="CONVENIO" Width="155px" />
                </td>
                <td>
                    <asp:Button ID="cmdNoConvenio" runat="server" Height="38px" 
                        onclick="cmdNoConvenio_Click" Text="NO CONVENIO" Width="155px" />
                </td>
                <td>
                    <asp:Button ID="cmdConvenioIncompleto" runat="server" Height="38px" 
                        onclick="cmdConvenioIncompleto_Click" Text="CONVENIO INCUMPLIDO" 
                        Width="177px" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Label ID="lblArbol" runat="server" Visible="False">2</asp:Label>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="ID_ESTADO_RAC" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
          <table style="width: 100%;">
            <tr>
                <td align="left" class="style2">
                   
                    &nbsp;<asp:Panel ID="Panel6" runat="server" BorderWidth="2"  
                        style="text-align: center">
                        <table style="width:100%;">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                                        ForeColor="#006600" Text="NUMERO DE RAC"></asp:Label>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="left">
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
                                    <br />
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <br />
                                    <asp:ImageButton ID="ImgSi6" runat="server" ImageUrl="~/img/si.png" 
                                        onclick="ImgSi5_Click" />
                                    &nbsp;<asp:ImageButton ID="ImgNo5" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo5_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" BorderWidth="2px" 
                        style="text-align: center">
                    <asp:Label ID="lblMsjCanalizar" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblCanalizar" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" Text="CANALIZAR"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblInstitucion" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="¿ A CUAL INSTITUCION ?"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlInstitucion" runat="server" Width="300px">
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
                                    <asp:Label ID="lblInstitucion0" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="FECHA CANALIZAR" Visible=false></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaCanalizar" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                     <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaCanalizar">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImgSi" runat="server" ImageUrl="~/img/si.png" 
                                        onclick="ImgSi_Click" />
                                    <asp:ImageButton ID="ImgNo" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" BorderWidth="2px"
                        style="text-align: center">
               <asp:Label ID="lblMsjMedios" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblSuspender" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" Text="MEDIOS ALTERNOS DE SOLICION DE CONFLICTOS"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblCentroMediacion" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="¿ A CUAL CENTRO DE MEDIACION ?"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlCentroMediacion" runat="server" Width="250px">
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
                                    <asp:Label ID="lblInstitucion1" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="FECHA SUSPENCION" Visible=false></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaSuspender" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaSuspender">
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
                                    <asp:ImageButton ID="ImgNo1" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo1_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" BorderWidth="2px" 
                        style="text-align: center">
          <asp:Label ID="lblMsjDerivar" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblRemitir" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" Text="DERIVAR"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblUnidadInvestigacion" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" 
                                        Text="¿ A CUAL UNIDAD DE INVESTIGACION ?" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlUnidadInvestigacion" runat="server" Width="250px" 
                                        Visible="False">
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
                                    <asp:Label ID="lblInstitucion2" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="FECHA DERIVAR" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaRemitir" runat="server" MaxLength="10" Width="200px" Visible="False"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaRemitir">
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
                                    <asp:ImageButton ID="ImgNo2" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo2_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" BorderWidth="2px" 
                        style="text-align: center">
                       <asp:Label ID="lblTituloResolver" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblResolver" runat="server" class="color-fuente" 
                                        style="font-weight: 700; font-size: large; text-align: left;" Text="RESOLVER"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblManeraResolvio" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="¿ DE QUE MANERA SE RESOLVIO?"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtResolvio" runat="server" Height="96px" TextMode="MultiLine" 
                                        Width="524px" MaxLength="5000"></asp:TextBox>
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
                                        Font-Size="Small" ForeColor="Black" Text="FECHA RESOLVIO" Visible=false></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaResolvio" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                      <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaResolvio">
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
                                    <asp:ImageButton ID="ImgNo3" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo3_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                       </asp:Panel>
                    <asp:Panel ID="Panel7" runat="server" BorderWidth="2px" 
                        style="text-align: center">
                          <asp:Label ID="lblMsjIncompetencia" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblRemitir0" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" 
                                        Text="INCOMPETENCIA"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" dir="ltr">
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="AGENCIA"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;</td>
                                <td align="center">
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
                                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FECHA DE INCOMPETENCIA" Visible=false></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaIncompetencia" runat="server" MaxLength="10" 
                                        Width="200px" Visible=false></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaIncompetencia">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ImageButton ID="ImgSi7" runat="server" ImageUrl="~/img/si.png" 
                                        onclick="ImgSi7_Click" />
                                    <asp:ImageButton ID="ImgNo7" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo7_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel8" runat="server" BorderWidth="2px" 
                        style="text-align: center">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblRemitir1" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" Text="CONVENIO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FECHA DE CONVENIO" Visible=false></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaConvenio" runat="server" MaxLength="10" Width="200px" Visible=false></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaConvenio">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImgSi8" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi8_Click" 
                                         />
                                    <asp:ImageButton ID="ImgNo8" runat="server" ImageUrl="~/img/no.png" onclick="ImgNo8_Click" 
                                        />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel9" runat="server" BorderWidth="2px" 
                        style="text-align: center">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblRemitir2" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" 
                                        Text="NO CONVENIO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FECHA DE NO CONVENIO" Visible=false></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaNoConvenio" runat="server" MaxLength="10" 
                                        Width="200px" Visible=false></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender8" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaNoConvenio">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImgSi9" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi9_Click" 
                                         />
                                    <asp:ImageButton ID="ImgNo9" runat="server" ImageUrl="~/img/no.png" onclick="ImgNo9_Click" 
                                         />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel10" runat="server" BorderWidth="2px" 
                        style="text-align: center">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblRemitir3" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" 
                                        Text="CONVENIO INCUMPLIDO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FECHA DE CONVENIO INCUMPLIDO" Visible=false></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaConvenioIncumplido" runat="server" MaxLength="10" 
                                        Width="200px" Visible=false></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaConvenioIncumplido">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImgSi10" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi10_Click" 
                                         />
                                    <asp:ImageButton ID="ImgNo10" runat="server" ImageUrl="~/img/no.png" onclick="ImgNo10_Click" 
                                         />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    
                     <asp:Panel ID="Panel11" runat="server" style="text-align: center"  BorderWidth="2">
                                                  <asp:Label ID="lblMsjArchivoTemporal" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" class="color-fuente"
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
                                    <td class="style3">
                                        </td>
                                    <td class="style3">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="True" 
                                            Font-Size="Small" ForeColor="Black" Text="FECHA ARCHIVO TEMPORAL" Visible=false></asp:Label>
                                    </td>
                                    <td class="style3">
                                        </td>
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
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/si.png" onclick="ImageButton1_Click" 
                                            />
                                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/no.png" onclick="ImageButton2_Click" 
                                            />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            
                        </asp:Panel>

                        <asp:Panel ID="Panel12" runat="server" style="text-align: center"  BorderWidth="2">
                               <asp:Label ID="lblMsjNoEjercicio" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" class="color-fuente" 
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
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" 
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
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/img/si.png" onclick="ImageButton3_Click" 
                                                />
                                            &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/img/no.png" onclick="ImageButton4_Click" 
                                                />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                
                            </asp:Panel>

                             <asp:Panel ID="Panel13" runat="server" BorderWidth="2" 
                    style="text-align: center">
                                         <asp:Label ID="lblMsjAbstenerse" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Text="¡SE TOMARA LA FECHA ACTUAL PARA EL CAMBIO DE ESTADO!" Visible=TRUE></asp:Label>
                    
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
                                <asp:ImageButton ID="ImgSi5" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi5_Click1" 
                                    />
                                &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/img/no.png" 
                                     />
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
                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"  Visible=false></asp:Label>
                    <table style="width:100%;">
                        <tr>
                            <td class="style4">
                                </td>
                            <td class="style4">
                                <asp:Label ID="Label10" runat="server"  class="color-fuente"
                                    style="font-weight: 700; font-size: large; text-align: left;" 
                                    Text="ACUMULAR"></asp:Label>
                            </td>
                            <td class="style4">
                                </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblIdCarpetaAcumular" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                                               <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Black" Text="NÚMERO"></asp:Label> &nbsp;
                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" 
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
                <td align="left" class="style2">
                </td>
            </tr>
            <tr>
                <td class="style2" align="left">
                    &nbsp;<asp:Panel ID="Panel5" runat="server" Height="842px" ScrollBars="Auto">
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
                </td>
            </tr>
            <tr>
                <td>
                       
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
  
    
    
</div>
</asp:Content>

