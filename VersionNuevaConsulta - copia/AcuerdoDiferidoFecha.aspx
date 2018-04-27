﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcuerdoDiferidoFecha.aspx.cs" Inherits="AtencionTemprana.AcuerdoDiferidoFecha" %>
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
                                                    <asp:Label ID="ID_ACUERDO_DIFERIDO" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="ID_NUM_CUM_DIFERIDO" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="Black" Text="FECHA CUMPLIMIENTO"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="Black" Text="IMPORTE"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblEstado" runat="server" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="Black" Text="ESTADO" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="txtFechaCumplimiento" runat="server" MaxLength="10" 
                                                        Width="200px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtFechaCumplimiento_CalendarExtender" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaCumplimiento">
                                                    </asp:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="txtFechaCumplimiento" Display="Dynamic" 
                                                        ErrorMessage="INGRESA FECHA CUMPLIMIENTO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtImporte" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlCumplido" runat="server" Visible="False" Width="200px">
                                                    </asp:DropDownList>
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
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="Black" Text="CONCEPTO"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="3">
                                                    <asp:TextBox ID="txtConcepto" runat="server" Height="127px" 
                                                        TextMode="MultiLine" Width="936px"></asp:TextBox>
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
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
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

