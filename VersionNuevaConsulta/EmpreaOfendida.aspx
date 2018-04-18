<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpreaOfendida.aspx.cs" Inherits="AtencionTemprana.EmpreaOfendida" %>
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
                  <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
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
                <td class="style2">
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="CONSECUTIVO_EMPRESA" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE "></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" 
                        style="text-transform :uppercase" Width="400px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="RFC"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRFC" runat="server" MaxLength="50" 
                        style="text-transform :uppercase" Width="400px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="DOMICILIO"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDomicilio" runat="server" Height="58px" MaxLength="400" 
                        style="text-transform :uppercase" TextMode="MultiLine" Width="400px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="ESCRITURA PUBLICA"></asp:Label>
                    <asp:TextBox ID="txtEscritura" runat="server" Width="25px" MaxLength="2"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NO. ESCRITURA"></asp:Label>
                    <asp:TextBox ID="txtNoEscritura" runat="server" MaxLength="20"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="OTRO"></asp:Label>
                    <asp:TextBox ID="txtOtro" runat="server" Width="25px" MaxLength="2"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="ESPECIFICAR"></asp:Label>
                    <asp:TextBox ID="txtEspecificar" runat="server" MaxLength="20"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                        Text="GUARDAR" Width="156px" Font-Bold="True" Height="40px" />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" onclick="cmdReg_Click1" Text="REGRESAR" 
                        Width="156px" Font-Bold="True" Height="40px" />
                </td>
            </tr>
            <tr>
                <td class="style2">
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

