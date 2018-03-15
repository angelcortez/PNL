<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Domicilio.aspx.cs" Inherits="AtencionTemprana.Domicilio" %>
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
        <asp:Panel ID="Panel1" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="PAIS"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="ESTADO"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlPais" runat="server" Width="250px" AutoPostBack="True" 
                            onselectedindexchanged="ddlPais_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="ddlPais" Display="Dynamic" ErrorMessage="INGRESA PAIS" 
                            Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server" Width="250px" 
                            AutoPostBack="True" onselectedindexchanged="ddlEstado_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="ddlEstado" Display="Dynamic" ErrorMessage="INGRESA ESTADO" 
                            Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMunicipio" runat="server" Width="250px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="ddlMunicipio" Display="Dynamic" 
                            ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="LOCALIDAD"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtLocalidad" runat="server" MaxLength="50" Width="400px" style="text-transform :uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                            ControlToValidate="txtLocalidad" Display="Dynamic" 
                            ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server">
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="PAIS"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="ESTADO"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlPaisCol" runat="server" Width="250px" 
                            AutoPostBack="True" onselectedindexchanged="ddlPaisCol_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="ddlPaisCol" Display="Dynamic" ErrorMessage="INGRESA PAIS" 
                            Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstadoCol" runat="server" Width="250px" 
                            AutoPostBack="True" onselectedindexchanged="ddlEstadoCol_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="ddlEstadoCol" Display="Dynamic" 
                            ErrorMessage="INGRESA ESTADO" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMunicipioCol" runat="server" Width="250px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlMunicipioCol_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="ddlMunicipioCol" Display="Dynamic" 
                            ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="LOCALIDAD"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="COLONIA"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlLocalidadCol" runat="server" Width="250px" 
                            AutoPostBack="True" 
                            >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ControlToValidate="ddlLocalidadCol" Display="Dynamic" 
                            ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtColonia" runat="server" MaxLength="50" Width="400px" style="text-transform :uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                            ControlToValidate="txtColonia" Display="Dynamic" ErrorMessage="INGRESA COLONIA" 
                            Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
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

        <asp:Panel ID="Panel3" runat="server">
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="PAIS"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="ESTADO"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlPaisCalle" runat="server" Width="250px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlPaisCalle_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                            ControlToValidate="ddlPaisCalle" Display="Dynamic" ErrorMessage="INGRESA PAIS" 
                            Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstadoCalle" runat="server" Width="250px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlEstadoCalle_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                            ControlToValidate="ddlEstadoCalle" Display="Dynamic" 
                            ErrorMessage="INGRESA ESTADO" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMunicipioCalle" runat="server" Width="250px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlMunicipioCalle_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                            ControlToValidate="ddlMunicipioCalle" Display="Dynamic" 
                            ErrorMessage="INGRESA MUNCIPIO" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="LOCALIDAD"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="CALLE"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlLocalidadCalle" runat="server" Width="250px" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                            ControlToValidate="ddlLocalidadCalle" Display="Dynamic" 
                            ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCalle" runat="server" MaxLength="50" Width="400px" style="text-transform :uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                            ControlToValidate="ddlPaisCalle" Display="Dynamic" ErrorMessage="INGRESA CALLE" 
                            Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                    <td colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <table style="width: 100%;">
            <tr>
                <td>
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
                <td align="center" colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                    &nbsp; &nbsp; &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                        Text="GUARDAR" Width="156px" />
                    <asp:Button ID="cmdReg" runat="server" onclick="cmdReg_Click1" Text="REGRESAR" 
                        Width="156px" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp;</td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>  
    
    
    
    
</div>

</asp:Content>

