<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NUM.aspx.cs" Inherits="AtencionTemprana.NUM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            height: 17px;
        }
        .style4
        {
            height: 19px;
        }
        .style5
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1"> 
    <div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
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
            <td class="style4">
                
                  <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                      style="text-transform :uppercase"></asp:Label>
            </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
            <td align="right" class="style4">
                </td>
        </tr>
     
      
        <tr>
            <td>
                
                <asp:Label ID="lblArbol" runat="server" Visible="False">3</asp:Label>
            </td>
            <td>
                <asp:Label ID="ID_PER" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 
<%--<h2><asp:Label ID="Label1" runat="server" Text="NUMERO UNICO DE MEDIACION" ForeColor="#006600"></asp:Label></h2>--%>
   <table style="width: 100%;">
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
                <td align="center" colspan="4">
                    
                                    <asp:ImageButton ID="cmdInicioProceso" runat="server" Height="70px" 
                                        ImageUrl="~/img/inicio proceso.png" 
                        onclick="cmdInicioProceso_Click" Visible="False"  />

                      
                                    <asp:ImageButton ID="cmdInvitacion" runat="server" Height="70px" 
                                        ImageUrl="~/img/PROCESOINVITACION.png" 
                        onclick="cmdInvitacion_Click" Visible="False" />

                    
                                    <asp:ImageButton ID="cmdAceptacion" runat="server" Height="70px" 
                                        ImageUrl="~/img/PROCESO SOLICITANTE.png" 
                        Visible="False" onclick="cmdAceptacion_Click" />

                    
                                    <asp:ImageButton ID="cmdDesinteres" runat="server" Height="70px" 
                                        ImageUrl="~/img/DESINTERES.png" 
                        Visible="False" onclick="cmdDesinteres_Click"  />

                    
                                    <asp:ImageButton ID="cmdDesistimiento" runat="server" Height="70px" 
                                        ImageUrl="~/img/DESISTIMIENTO.jpg" 
                        Visible="False" onclick="cmdDesistimiento_Click"  />

                    
                                    <asp:ImageButton ID="cmdDesistimientoInvitado" runat="server" Height="70px" 
                                        ImageUrl="~/img/DESISTIMIENTO.jpg" 
                        Visible="False" onclick="cmdDesistimientoInvitado_Click"   />

                    
                                    <asp:ImageButton ID="cmdMediacion" runat="server" Height="70px" 
                                        ImageUrl="~/img/PROCESO MEDIACION.png" 
                        onclick="cmdMediacion_Click" Visible="False" />

                        
                    <asp:ImageButton ID="cmdConcluido" runat="server" Height="70px" 
                        ImageUrl="~/img/CONCLUIDO.png" onclick="cmdConcluido_Click" Visible="False" />

                        
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ID_ESTADO_NUM" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">

                                  <asp:Panel ID="Panel4" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" 
                        BorderWidth="2px" ForeColor="Green" Visible="False">
                                        <table style="width:100%;">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label2" runat="server" Text="ACEPTA SOLICITANTE" 
                                                        Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/si.png" 
                                                        onclick="ImgSi4_Click" 
                                                         />
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/no.png" 
                                                        onclick="ImageButton2_Click" 
                                                        />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                  <asp:Panel ID="Panel16" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" 
                        BorderWidth="2px" ForeColor="Green" Visible="False">
                                        <table style="width:100%;">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label27" runat="server" Text="DESISTIMIENTO" 
                                                        Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlUnidad7" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="Black" Text="FECHA REMITE"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtFechaRemiteDesSol" runat="server" MaxLength="10" 
                                                        Width="200px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaRemiteDesSol_CalendarExtender" 
                                                        runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                        TargetControlID="txtFechaRemiteDesSol">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                        ControlToValidate="txtFechaRemiteDesSol" Display="Dynamic" 
                                                        ErrorMessage="INGRESAR FECHA REMITE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidationSummary10" runat="server" Font-Bold="True" 
                                                        ForeColor="Red" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/img/si.png" onclick="ImageButton9_Click" 
                                                        
                                                         />
                                                    <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/img/no.png" onclick="ImageButton10_Click" 
                                                        
                                                        />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                  <asp:Panel ID="Panel18" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" 
                        BorderWidth="2px" ForeColor="Green" Visible="False">
                                        <table style="width:100%;">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label29" runat="server" Text="M.A.S.C." 
                                                        Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlMasc" runat="server" Width="250px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/img/si.png" onclick="ImageButton13_Click"
                                                       />
                                                    <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="~/img/no.png" onclick="ImageButton14_Click"
                                                      />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                     <asp:Panel ID="Panel12" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" 
                        BorderWidth="2px" ForeColor="Green" Visible="False">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="center">
                                                    <asp:Label ID="Label13" runat="server" Text="NO ACEPTA SOLICITANTE" 
                                                        Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlUnidad" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA REMITE"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaRemiteSolicitante" runat="server" MaxLength="10" 
                                                        Width="200px"></asp:TextBox>
                                                  
                                                    <asp:CalendarExtender ID="txtFechaRemiteSolicitante_CalendarExtender" 
                                                        runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                        TargetControlID="txtFechaRemiteSolicitante">
                                                    </asp:CalendarExtender>
                                                  
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtFechaRemiteSolicitante" Display="Dynamic" 
                                                        ErrorMessage="INGRESAR FECHA REMITE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                  
                                                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" Font-Bold="True" 
                                                        ForeColor="Red" />
                                                  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/img/si.png" 
                                                        onclick="ImageButton3_Click" 
                                                        />
                                                    <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/img/no.png" 
                                                        onclick="ImageButton4_Click" 
                                                        />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                    <asp:Panel ID="Panel1" runat="server" BorderWidth="2px" ForeColor="Green" Visible="False">
                        <table style="width: 100%;">
                            <tr>
                                <td align="center" colspan="3">
                                    &nbsp; &nbsp;
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                                        ForeColor="#006600" Text="INICIAR NUMERO DE JUSTICIA ALTERNATIVA"></asp:Label>
                                    &nbsp;
                                </td>
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
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="NUMERO"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="AÑO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FACILITADOR"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNumero" runat="server" MaxLength="4" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtNumero" Display="Dynamic" ErrorMessage="INGRESA NUMERO" 
                                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAño" runat="server" MaxLength="4" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="INGRESA AÑO" 
                                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFacilitador" runat="server" Width="340px">
                                    </asp:DropDownList>
                                </td>
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
                                <td align="center" colspan="3">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                                        ForeColor="Red" />
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:ImageButton ID="ImgSi" runat="server" ImageUrl="~/img/si.png" 
                                        onclick="ImgSi_Click" />
                                    <asp:ImageButton ID="ImgNo" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo_Click" />
                                </td>
                            </tr>
                        </table>
                      
                    </asp:Panel>
                    
                                    <asp:Panel ID="Panel11" runat="server" 
                                        Font-Bold="True" Font-Size="Small" 
                        HorizontalAlign="Center" BorderWidth="2px" ForeColor="Green" Visible="False">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        ForeColor="Green" Text="PROCESO DE MEDIACION"></asp:Label>
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
                                                    <asp:ImageButton ID="ImgSi10" runat="server" ImageUrl="~/img/si.png" 
                                                        onclick="ImgSi10_Click" 
                                                       />
                                                    <asp:ImageButton ID="ImgNo10" runat="server" ImageUrl="~/img/no.png" 
                                                        onclick="ImgNo10_Click" 
                                                       />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                    
                                        <asp:Panel ID="Panel15" runat="server" BorderWidth="2px" Font-Bold="True" 
                                            Font-Size="Small" ForeColor="Green" HorizontalAlign="Center" 
                                      Visible="False">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="Label24" runat="server" Font-Bold="True" 
                                                            Font-Size="Medium" Text="DESINTERES"></asp:Label>
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
                                                        <asp:Label ID="lblInstitucion13" runat="server" Font-Bold="True" 
                                                            Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlUnidad6" runat="server" Width="300px">
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
                                                        <asp:Label ID="lblInstitucion14" runat="server" Font-Bold="True" 
                                                            Font-Size="Small" ForeColor="Black" Text="FECHA REMITE"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtFechaRemite4" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="txtFechaRemite4_CalendarExtender0" runat="server" 
                                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaRemite4">
                                                        </asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                            ControlToValidate="txtFechaRemite4" Display="Dynamic" 
                                                            ErrorMessage="INGRESAR FECHA REMITE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <asp:ValidationSummary ID="ValidationSummary9" runat="server" Font-Bold="True" 
                                                            ForeColor="Red" />
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:ImageButton ID="ImgSi12" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi12_Click" 
                                                           />
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                    
                    <asp:Panel ID="Panel2" runat="server" style="text-align: center">
                        <table style="width: 100%;">
                            <tr>
                                <td align="center" colspan="4" dir="ltr" class="style5">
                                    <asp:RadioButtonList ID="rbAcude" runat="server" Font-Bold="True" 
                                        Font-Size="Medium" RepeatDirection="Horizontal" 
                                        onselectedindexchanged="rbAcude_SelectedIndexChanged" Visible="False" 
                                        AutoPostBack="True" ForeColor="Black">
                                        <asp:ListItem Value="1">ACUDE</asp:ListItem>
                                        <asp:ListItem Value="2">NO ACUDE</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Panel ID="Panel6" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" BorderWidth="2px" 
                                        ForeColor="Green" Visible="False">
                                       
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        Text="ACEPTA INVITADO"></asp:Label>
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
                                                    <asp:ImageButton ID="ImgSi4" runat="server" ImageUrl="~/img/si.png" 
                                                        onclick="ImgSi4_Click1" />
                                                    &nbsp;<asp:ImageButton ID="ImgNo4" runat="server" ImageUrl="~/img/no.png" 
                                                        onclick="ImgNo4_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                       
                                    </asp:Panel>
                                    <asp:Panel ID="Panel14" runat="server" Font-Bold="True" Font-Size="Small" 
                                        HorizontalAlign="Center" BorderWidth="2px" ForeColor="Green" 
                                        Visible="False">
                                        
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        Text="NO ACEPTA EL INVITADO"></asp:Label>
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
                                                        Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUnidad1" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="lblInstitucion7" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA REMITE"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaRemite" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaRemite_CalendarExtender" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaRemite">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                        ControlToValidate="txtFechaRemite" Display="Dynamic" 
                                                        ErrorMessage="INGRESAR FECHA REMITE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidationSummary8" runat="server" Font-Bold="True" 
                                                        ForeColor="Red" />
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
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        
                                    </asp:Panel>
                                    <asp:Panel ID="Panel7" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" BorderWidth="2px" 
                                        ForeColor="Green" Visible="False">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="center">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="center">
                                                    <asp:RadioButtonList ID="rbNoAcude" runat="server" AutoPostBack="True" 
                                                        Font-Bold="True" Font-Size="Medium" ForeColor="Black" 
                                                       
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1" Selected="True">DESINTERES</asp:ListItem>
                                                        <asp:ListItem Value="2">INASISTENCIA</asp:ListItem>
                                                    </asp:RadioButtonList>
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
                                                        Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUnidad2" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="lblInstitucion8" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA REMITE"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaRemite2" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaRemite2_CalendarExtender" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaRemite2">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                        ControlToValidate="txtFechaRemite2" Display="Dynamic" 
                                                        ErrorMessage="INGRESAR FECHA REMITE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" Font-Bold="True" 
                                                        ForeColor="Red" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:ImageButton ID="ImgSi6" runat="server" ImageUrl="~/img/si.png" onclick="ImgSi6_Click" 
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
                                <td>
                                    &nbsp;
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
                            
                    </asp:Panel>
                     <asp:Panel ID="Panel17" runat="server" BorderWidth="2px" Font-Bold="True" 
                                            Font-Size="Small" ForeColor="Green" HorizontalAlign="Center" Visible="False">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                            Text="DESISTIMIENTO"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Small" 
                                                            ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlUnidad8" runat="server" Width="300px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Small" 
                                                            ForeColor="Black" Text="FECHA REMITE"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFechaRemiteDesInv" runat="server" MaxLength="10" 
                                                            Width="200px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="txtFechaRemiteDesInv_CalendarExtender" 
                                                            runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                                            TargetControlID="txtFechaRemiteDesInv">
                                                        </asp:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="txtFechaRemiteDesInv" Display="Dynamic" 
                                                            ErrorMessage="INGRESAR FECHA REMITE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ValidationSummary ID="ValidationSummary11" runat="server" Font-Bold="True" 
                                                            ForeColor="Red" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/img/si.png" onclick="ImageButton11_Click" 
                                                            />
                                                        <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/img/no.png" onclick="ImageButton12_Click"  
                                                            />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" style="text-align: center" Visible="False">
                        <table style="width: 100%;">
                            <tr>
                                <td align="center">
                                    &nbsp;</td>
                                <td align="center">
                                    &nbsp;</td>
                                <td align="center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="cmdInmediato" runat="server" Height="70px" 
                                        ImageUrl="~/img/CUMPLIMIENTO.png" onclick="cmdInmediato_Click" />
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="cmdDiferido" runat="server" Height="70px" 
                                        ImageUrl="~/img/estados/DIFERIDO.png" onclick="cmdDiferido_Click" />
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="cmdSinAcuerdo" runat="server" Height="70px" 
                                        ImageUrl="~/img/CONCLUIDO SIN ACUERDO.png" onclick="cmdSinAcuerdo_Click" />
                                </td>
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
                                <td colspan="3">
                                    <asp:Panel ID="Panel8" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" BorderWidth="2px" 
                                        ForeColor="Green">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        Text="ACUERDO DE CUMPLIMIENTO INMEDIATO"></asp:Label>
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
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInstitucion4" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:DropDownList ID="ddlUnidad3" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
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
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA CUMPLIMIENTO"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaInmediato" runat="server" MaxLength="10" Width="300px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaInmediato_CalendarExtender" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInmediato">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="txtFechaInmediato" Display="Dynamic" 
                                                        ErrorMessage="INGRESA FECHA CUMPLIMIENTO" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" Font-Bold="True" 
                                                        ForeColor="Red" />
                                                    <asp:ImageButton ID="ImgSi7" runat="server" ImageUrl="~/img/si.png" 
                                                        onclick="ImgSi7_Click" />
                                                    <asp:ImageButton ID="ImgNo7" runat="server" ImageUrl="~/img/no.png" 
                                                        onclick="ImgNo7_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
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
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel9" runat="server" Font-Bold="True" 
                                        Font-Size="Small" HorizontalAlign="Center" BorderWidth="2px" 
                                        ForeColor="Green">
                                        <table style="width:100%;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        Text="ACUERDO DE CUMPLIMIENTO DIFERIDO"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
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
                                            </tr>
                                            <tr>
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
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:ImageButton ID="ImgSi9" runat="server" ImageUrl="~/img/si.png" 
                                                        onclick="ImgSi9_Click" />
                                                    <asp:ImageButton ID="ImgNo9" runat="server" ImageUrl="~/img/no.png" 
                                                        onclick="ImgNo9_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel10" runat="server" 
                                        Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" 
                                        BorderWidth="2px" ForeColor="Green">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        Text="CONCLUIDO SIN ACUERDO"></asp:Label>
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
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion15" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="SOLICITANTE"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion16" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="INVITADO"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion9" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlSolicitante" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlInvitado" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlUnidad4" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
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
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion10" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA CONCLUIDO"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtFechaSinAcuerdo" runat="server" MaxLength="10" 
                                                        Width="200px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaSinAcuerdo_CalendarExtender" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaSinAcuerdo">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                        ControlToValidate="txtFechaSinAcuerdo" Display="Dynamic" 
                                                        ErrorMessage="INGRESA FECHA CONCLUIDO SIN ACUERDO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:ValidationSummary ID="ValidationSummary5" runat="server" Font-Bold="True" 
                                                        ForeColor="Red" />
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
                                    <asp:Panel ID="Panel13" runat="server" Font-Bold="True" Font-Size="Small" 
                                        HorizontalAlign="Center" Visible="False" BorderWidth="2px" ForeColor="Green">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        Text="CONCLUIDO CON ACUERDO DIFERIDO "></asp:Label>
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
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion11" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion12" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA REMITE"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="Black" Text="ESTADO"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlUnidad5" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtFechaRemite3" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaRemite3_CalendarExtender0" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaRemite3">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                        ControlToValidate="txtFechaRemite3" Display="Dynamic" 
                                                        ErrorMessage="INGRESA FECHA CONCLUIDO SIN ACUERDO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlCumplido" runat="server" 
                                                         Width="200px">
                                                    </asp:DropDownList>
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
                                                    &nbsp;</td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        ForeColor="Red"></asp:Label>
                                                    <asp:ValidationSummary ID="ValidationSummary7" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Red" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td colspan="3">
                                                    <asp:ImageButton ID="ImgSi11" runat="server" ImageUrl="~/img/si.png" 
                                                        onclick="ImgSi11_Click" />
                                                    <asp:ImageButton ID="ImgNo11" runat="server" ImageUrl="~/img/no.png" 
                                                        onclick="ImgNo11_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                </td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    <asp:Panel ID="Panel5" runat="server" Height="758px" ScrollBars="Auto">
                        <asp:TreeView ID="TVCarpeta" runat="server" ImageSet="Simple" Width="927px" 
                            Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Underline="False">
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
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                   
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
        </table>
    
</div>

</asp:Content>

