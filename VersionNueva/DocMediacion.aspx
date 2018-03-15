<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocMediacion.aspx.cs" Inherits="AtencionTemprana.DocMediacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript">
      function mostrarFichero(destino) {
          window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
          document.forms(0).submit();
      }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
        <asp:PostBackTrigger ControlID="cmdGuardar" />
        <asp:PostBackTrigger ControlID="cmdGeneraPdf" />
    </Triggers>
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
                  <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:Label ID="ID_CARPETA" runat="server" Visible="False"></asp:Label>
              </td>
              <td align="right">
                  <asp:Label ID="IdPdf" runat="server" Visible="False"></asp:Label>
              </td>
          </tr>
     
      
    </table>   
    <h2> 
        <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>
    
      <table style="width: 100%;">
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel34" runat="server" GroupingText="-">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label398" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="SOLICITANTE"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label399" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="OFENDIDO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label400" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="INVITADO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlDenunciante" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOfendido" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlImputado" runat="server" Width="300px">
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
                                <td>
                                    <asp:Label ID="Label560" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FACILITADOR"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label561" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="AGENTE DEL MINISTERIO PUBLICO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlFacilitador" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlMpPenal" runat="server" Width="300px">
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
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="DOCUMENTO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlPlantilla" runat="server" Width="700px" 
                                        onselectedindexchanged="ddlPlantilla_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                       
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
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel38" runat="server" GroupingText="OTRO FORMATO" 
                        Visible="False">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label559" runat="server" Font-Bold="True" 
                                        Text="NOMBRE DEL FORMATO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="txtOtroFormato" runat="server" MaxLength="200" 
                                        style="text-transform :uppercase" Width="800px"></asp:TextBox>
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
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="cmdGeneraPdf" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdGeneraPdf_Click" Text="GENERAR DOCUMENTO" Visible="False" 
                        Width="214px" />
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label332" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SELECCIONE DOCUMENTO PDF"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />
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
                    <br />
                    <asp:Button ID="cmdGuardar" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdGuardar_Click" TabIndex="32" Text="GUARDAR DATOS" Width="156px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdReg_Click" TabIndex="32" Text="REGRESAR" Width="156px" />
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

