<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcuerdoCumplimientoInmediato.aspx.cs" Inherits="AtencionTemprana.AcuerdoCumplimientoInmediato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#006600"></asp:Label>
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
        <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>
          <table style="width:100%;">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="ID_ACUERDO_INMEDIATO" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion13" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="SOLICITANTE"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion14" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="INVITADO"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion1" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA CUMPLIMIENTO"></asp:Label>
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
                                                    <asp:TextBox ID="txtFechaInmediato" runat="server" MaxLength="10" Width="300px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaInmediato_CalendarExtender" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInmediato">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="txtFechaInmediato" Display="Dynamic" 
                                                        ErrorMessage="INGRESA FECHA CUMPLIMIENTO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </td>
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
                                                    <asp:Label ID="lblInstitucion11" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="CONCEPTO"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="txtConcepto" runat="server" Height="135px" 
                                                        TextMode="MultiLine" Width="1056px"></asp:TextBox>
                                                </td>
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
                                                    <asp:Label ID="lblInstitucion12" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="IMPORTE"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion4" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="REMITIR A:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtImporte" runat="server" MaxLength="20" Width="300px"></asp:TextBox>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlUnidad3" runat="server" Width="300px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" Font-Bold="True" 
                                                        ForeColor="Red" />
                                                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        ForeColor="Red"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="cmdGu" runat="server" Font-Bold="True" Height="40px" 
                                                        onclick="cmdGu_Click" TabIndex="6" Text="GUARDAR" Width="156px" />
                                                    &nbsp;<asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" 
                                                        onclick="cmdReg_Click" TabIndex="7" Text="REGRESAR" Width="156px" />
                                                </td>
                                            </tr>
                                        </table>
  
    </ContentTemplate>
    </asp:UpdatePanel>
    
    
</div>

</asp:Content>

