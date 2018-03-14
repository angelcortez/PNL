<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarpetaPDF.aspx.cs" Inherits="AtencionTemprana.CarpetaPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <%-- <Triggers>
    <asp:PostBackTrigger ControlID="cmdGuardar" />
    </Triggers>--%>

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
                  <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
              </td>
              <td>
                  <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
              </td>
              <td>
                  <asp:Label ID="IdPdf" runat="server" Visible="False"></asp:Label>
              </td>
              <td align="right">
                  &nbsp;</td>
          </tr>
     
      
    </table>  
    
     <h2> 
        <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>
          
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SELECCIONA DOCUMENTO"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlPlantilla" runat="server" Width="200px">
                        <asp:ListItem Value="0">SELECCIONA</asp:ListItem>
                        <asp:ListItem Value="1">OFICIO_PARA_SOLICITAR_PERITO QUMICO</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="cmdGeneraPdf" runat="server" onclick="cmdGeneraPdf_Click" 
                        Text="PDF" />
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
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="DOCUMENTO PDF"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="DESCRIPCION"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
               
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="28px" Width="353px" />
               
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="54px" MaxLength="50" 
                        TextMode="MultiLine" Width="515px" style="text-transform :uppercase"></asp:TextBox>
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
                    
                  
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp;<asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                        Text="GUARDAR" Width="156px" />
                    &nbsp;<asp:Button ID="cmdReg" runat="server" onclick="cmdReg_Click1" Text="REGRESAR" 
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
            </tr>
        </table>
     </ContentTemplate>
    </asp:UpdatePanel>
    
    
</div>

</asp:Content>

