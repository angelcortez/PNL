<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JusticiaAlternativaAudiencia.aspx.cs" Inherits="AtencionTemprana.JusticiaAlternativaAudiencia" %>
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

        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="ID_AUDIENCIA" runat="server" Visible="False"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FECHA AUDIENCIA"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="TIPO DE AUDIENCIA"></asp:Label>
                </td>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtFechaAudiencia" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaAudiencia_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaAudiencia">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtFechaAudiencia" Display="Dynamic" 
                        ErrorMessage="INGRESA FECHA" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td colspan="5">
                    <asp:RadioButtonList ID="rbTipo" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" 
                        
                        RepeatDirection="Horizontal" AutoPostBack="True" 
                        onselectedindexchanged="rbTipo_SelectedIndexChanged">
                        <asp:ListItem Value="1">CONJUNTA</asp:ListItem>
                        <asp:ListItem Value="2">INDIVIDUAL SOLICITANTE</asp:ListItem>
                        <asp:ListItem Value="3">INDIVIDUAL REQUERIDO</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="HORA AUDIENCIA"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblSolicitante" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SOLICITANTE" Visible="False"></asp:Label>
                    <asp:Label ID="lblRequerido" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="REQUERIDO" Visible="False"></asp:Label>
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtHora" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                    <asp:Label ID="Label25" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="HRS."></asp:Label>
                </td>
                <td colspan="5">
                    <asp:DropDownList ID="ddlSolicitante" runat="server" Width="300px" 
                        Visible="False">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlRequerido" runat="server" Visible="False" 
                        Width="300px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SALA"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MEDIADOR"></asp:Label>
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlSala" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlMediador" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;&nbsp;</td>
                <td colspan="2">
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                    </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center">
                    &nbsp;<asp:Button ID="cmdGu" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdGu_Click" TabIndex="6" Text="GUARDAR" Width="156px" />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdReg_Click" TabIndex="7" Text="REGRESAR" Width="156px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp; </td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp; </td>
            </tr>
        </table>

    </ContentTemplate>
    </asp:UpdatePanel>
    
    
</div>

</asp:Content>

