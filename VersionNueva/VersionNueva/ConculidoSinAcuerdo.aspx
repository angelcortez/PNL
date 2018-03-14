<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConculidoSinAcuerdo.aspx.cs" Inherits="AtencionTemprana.ConculidoSinAcuerdo" %>
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
                                                    <asp:Label ID="ID_SIN_ACUERDO" runat="server" Visible="False"></asp:Label>
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
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
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
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblInstitucion10" runat="server" Font-Bold="True" 
                                                        Font-Size="Small" ForeColor="Black" Text="FECHA CONCLUIDO"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    &nbsp;</td>
                                                <td align="left">
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

