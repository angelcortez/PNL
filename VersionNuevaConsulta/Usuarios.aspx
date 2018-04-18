<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="AtencionTemprana.Usuarios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Font-Size="Medium"></asp:Label>
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
                    <asp:Label ID="ID_USUARIO" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="200px" MaxLength="30" 
                        style="text-transform :uppercase" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="INGRESA NOMBRE" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPaterno" runat="server" Width="200px" TabIndex="2" 
                        style="text-transform :uppercase" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPaterno" Display="Dynamic" ErrorMessage="INGRESA PATERNO" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMaterno" runat="server" Width="200px" TabIndex="3" 
                        style="text-transform :uppercase" MaxLength="30"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="USUARIO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="CONTRASEÑA"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="ACTIVO"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" TabIndex="4" Width="200px" 
                        style="text-transform :uppercase" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="INGRESA USUARIO" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtContraseña" runat="server" TabIndex="5" Width="200px" 
                        style="text-transform :uppercase" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtContraseña" Display="Dynamic" 
                        ErrorMessage="INGRESA CONTRASEÑA" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="rbActivo" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="6">
                        <asp:ListItem Value="1">SI</asp:ListItem>
                        <asp:ListItem Value="0">NO</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="rbActivo" Display="Dynamic" ErrorMessage="SELECCIONA ACTIVO" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="UNIDAD"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MODULO"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="ddlUnidad" runat="server" TabIndex="7" Width="427px">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlModulo" runat="server" TabIndex="8" Width="400px">
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
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PUESTO"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FECHA DE BAJA"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="ddlPuesto" runat="server" TabIndex="9" Width="427px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaBaja" runat="server" TabIndex="10" Width="200px" 
                        MaxLength="10"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaBaja_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/mm/yyyy" TargetControlID="txtFechaBaja">
                    </asp:CalendarExtender>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtFechaBaja" Display="Dynamic" 
                        ErrorMessage="FECHA INVALIDA" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red" MaximumValue="31/12/9999" MinimumValue="01/01/1111">*</asp:RangeValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                        Text="GUARDAR" Width="156px" />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" onclick="cmdReg_Click1" Text="REGRESAR" 
                        Width="156px" />
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

