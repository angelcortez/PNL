<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RazonAvisoConDetenido.aspx.cs" Inherits="AtencionTemprana.RazonAvisoConDetenido" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style16
        {
            width: 264px;
        }
        .style17
        {
            width: 72px;
        }
        .style18
        {
            width: 292px;
        }
        </style>
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
                <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table>  

     <h2><asp:Label ID="lblOperacion" runat="server" 
             ForeColor="#006600"></asp:Label></h2>
        <table style="width: 100%;">
        <tr>
                <td>
                    <asp:Label ID="ID_CARPETA" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="IdRazonAviso" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TabContainer ID="TabContainer6" runat="server" ActiveTabIndex="0" 
                        Width="914px">
                        <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel1">
                            <HeaderTemplate>
                                ¿QUE CORPORACION POLICIACA AVISA?
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style18">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="CLASIFICACION DE LA CORPORACION"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="CORPORACION"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style18">
                                            <asp:DropDownList ID="ddlClasificacion" runat="server" Width="350px" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddlClasificacion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="ddlClasificacion" Display="Dynamic" 
                                                ErrorMessage="INGRESA CLASIFICAION CORPORACION" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="style17">
                                            &nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddlCoorporacion" runat="server" Width="350px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="ddlCoorporacion" Display="Dynamic" 
                                                ErrorMessage="INGRESA CORPORACION" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
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
                    <asp:TabContainer ID="TabContainer5" runat="server" ActiveTabIndex="0" 
                        Width="914px">
                        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel1">
                            <HeaderTemplate>
                                DATOS DEL PARTE INFORMATIVO
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="NUMERO DE PARTE"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="FECHA DEL OFICIO"></asp:Label>
&nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="FOLIO IPH"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:TextBox ID="txtNumeroOf" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFechaOf" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFechaOf_CalendarExtender" runat="server" 
                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaOf">
                                            </asp:CalendarExtender>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                ControlToValidate="txtFechaOf" Display="Dynamic" ErrorMessage="FECHA INVALIDA" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red" MaximumValue="31/12/9999" 
                                                MinimumValue="01/01/1111">*</asp:RangeValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFolioIPH" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
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
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" Width="156px" 
                        onclick="cmdGuardar_Click" />
                    <asp:Button ID="cmdReg" runat="server" Text="REGRESAR" Width="156px" 
                        onclick="cmdReg_Click" />
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
    </ContentTemplate>
    </asp:UpdatePanel>
   
 
    
    
    
</div>

</asp:Content>

