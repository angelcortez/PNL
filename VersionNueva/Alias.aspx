<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alias.aspx.cs" Inherits="AtencionTemprana.Alias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style  type="text/css">
        .bordeCampoObligatorio
        {
            border-style: solid;
            border-color:#FF0000;
            border-bottom-width:1px;
            border-top-width:1px;
            border-left-width:1px;
            border-right-width:1px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">

<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
        <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="ID_ALIAS" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="ALIAS"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    <asp:TextBox ID="txtAlias" runat="server" Width="200px" MaxLength="30" style="text-transform :uppercase" class="bordeCampoObligatorio">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtAlias" Display="Dynamic" ErrorMessage="INGRESA ALIAS" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp;
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" Width="156px" 
                        onclick="cmdGuardar_Click" Font-Bold="True" Height="40px" class="button"  />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" Text="REGRESAR" Width="156px" 
                        onclick="cmdReg_Click1" Font-Bold="True" Font-Italic="False" 
                        Height="40px" class="button" />
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>  
    
   
    
    
    
</div>

</asp:Content>

