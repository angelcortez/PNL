<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Defensor.aspx.cs" Inherits="AtencionTemprana.Defensor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
        
        <asp:PostBackTrigger ControlID="ddlPais" />
        <asp:PostBackTrigger ControlID="ddlEstado" />
        <asp:PostBackTrigger ControlID="ddlMunicipio" />

        <asp:PostBackTrigger ControlID="ddlPaisDom" />
        <asp:PostBackTrigger ControlID="ddlEstadoDom" />
        <asp:PostBackTrigger ControlID="ddlMunicipioDom" />
        <asp:PostBackTrigger ControlID="ddlLocalidadDom" />
        <asp:PostBackTrigger ControlID="ddlColonia" />

        
        <asp:PostBackTrigger ControlID="cmdGuardar" />
        <asp:PostBackTrigger ControlID="cmdReg" />
      

    </Triggers>
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
                  <asp:Label ID="ID_TIPO_ACTOR" runat="server" Visible="False"></asp:Label>
              </td>
              <td>
                  <asp:Label ID="ID_CARPETA" runat="server" Visible="False"></asp:Label>
              </td>
              <td align="right">
                  &nbsp;</td>
          </tr>
     
      
    </table>    
    <h2> 
        <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
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
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="IMPUTADO"></asp:Label>
                    <asp:Label ID="ID_DEFENSOR" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="ddlImputado" runat="server" Width="400px" class="chosen-select">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="LBLIMPUTADO" runat="server" Font-Bold="False" Font-Size="Small" 
                        ForeColor="Black"></asp:Label>
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
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="DEFENSOR"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="200px" MaxLength="30" 
                        style="text-transform :uppercase"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                        ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="INGRESA NOMBRE" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPaterno" runat="server" MaxLength="30" 
                        style="text-transform :uppercase" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPaterno" Display="Dynamic" ErrorMessage="INGRESA PATERNO" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMaterno" runat="server" MaxLength="30" 
                        style="text-transform :uppercase" Width="200px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    <asp:RadioButtonList ID="rbDefensor" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" 
                        TabIndex="30">
                        <asp:ListItem Value="1">PUBLICO</asp:ListItem>
                        <asp:ListItem Value="2">PRIVADO</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                        ControlToValidate="rbDefensor" Display="Dynamic" 
                        ErrorMessage="SELECCIONA DEFENSOR" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=" IDETIFICACIÓN CON LA QUE SE PRESENTA "></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="NÚMERO DE FOLIO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label23" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="NÚMERO DE TELEFONO"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlIdentificacion" runat="server" TabIndex="25" class="chosen-select"
                        Width="200px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtFolio" runat="server" MaxLength="30" 
                        style="text-transform :uppercase" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" MaxLength="30" 
                        style="text-transform :uppercase" Width="200px"></asp:TextBox>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel5" runat="server" GroupingText="ORIGINARIO">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="NACIONALIDAD"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="PAÍS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ESTADO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlNacionalidad" runat="server" TabIndex="4" class="chosen-select"
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="ddlNacionalidad" Display="Dynamic" 
                                                ErrorMessage="INGRESA NACIONALIDAD" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" class="chosen-select"
                                                onselectedindexchanged="ddlPais_SelectedIndexChanged" TabIndex="5" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ControlToValidate="ddlPais" Display="Dynamic" ErrorMessage="INGRESA PAIS" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" class="chosen-select"
                                                onselectedindexchanged="ddlEstado_SelectedIndexChanged" TabIndex="6" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                ControlToValidate="ddlEstado" Display="Dynamic" ErrorMessage="INGRESA ESTADO" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipio" runat="server" TabIndex="7" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                ControlToValidate="ddlMunicipio" Display="Dynamic" 
                                                ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
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
                    <asp:Panel ID="Panel6" runat="server" 
                        GroupingText="DOMICILIO PARTICULAR ACTUAL">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="PAÍS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ESTADO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LOCALIDAD"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPaisDom" runat="server" AutoPostBack="True" class="chosen-select"
                                                onselectedindexchanged="ddlPaisDom_SelectedIndexChanged" TabIndex="8" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                ControlToValidate="ddlPaisDom" Display="Dynamic" ErrorMessage="INGRESA PAIS" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstadoDom" runat="server" AutoPostBack="True" class="chosen-select"
                                                onselectedindexchanged="ddlEstadoDom_SelectedIndexChanged" TabIndex="9" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                ControlToValidate="ddlEstadoDom" ErrorMessage="INGRESA ESTADO" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipioDom" runat="server" AutoPostBack="True" class="chosen-select"
                                                onselectedindexchanged="ddlMunicipioDom_SelectedIndexChanged" TabIndex="10" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                ControlToValidate="ddlMunicipioDom" Display="Dynamic" 
                                                ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadDom" runat="server" AutoPostBack="True" class="chosen-select"
                                                onselectedindexchanged="ddlLocalidadDom_SelectedIndexChanged" TabIndex="11" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                ControlToValidate="ddlLocalidadDom" Display="Dynamic" 
                                                ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small" 
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
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="COLONIA"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlColonia" runat="server" AutoPostBack="True" class="chosen-select"
                                                TabIndex="12" Width="470px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                ControlToValidate="ddlColonia" Display="Dynamic" ErrorMessage="INGRESA COLONIA" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCalle" runat="server" TabIndex="13" Width="430px" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                ControlToValidate="ddlCalle" Display="Dynamic" ErrorMessage="INGRESA CALLE" 
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
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ENTRE CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="Y CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlEntreCalle" runat="server" TabIndex="14" Width="430px" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                ControlToValidate="ddlEntreCalle" Display="Dynamic" 
                                                ErrorMessage="INGRESA ENTRE CALLE" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlYcalle" runat="server" TabIndex="15" Width="430px" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                ControlToValidate="ddlYcalle" Display="Dynamic" ErrorMessage="INGRESA Y CALLE" 
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
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="NÚMERO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MANZANA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LOTE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNumero" runat="server" MaxLength="10" 
                                                style="text-transform :uppercase" TabIndex="16" Width="190px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtManzana" runat="server" MaxLength="10" 
                                                style="text-transform :uppercase" TabIndex="17" Width="190px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLote" runat="server" MaxLength="10" 
                                                style="text-transform :uppercase" TabIndex="18" Width="190px"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
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
                <td align="center" colspan="4">
                    <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" Width="156px" 
                        onclick="cmdGuardar_Click" Font-Bold="True" Height="40px" class="button"  />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" Text="REGRESAR" Width="156px" 
                        onclick="cmdReg_Click1" Font-Bold="True" Height="40px" class="button" />
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

