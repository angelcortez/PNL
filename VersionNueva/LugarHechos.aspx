<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LugarHechos.aspx.cs" Inherits="AtencionTemprana.LugarHechos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
        }
        .style12
        {
            width: 240px;
        }
        .style14
        {
            height: 17px;
        }
        .style15
        {
            height: 19px;
        }
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
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
             <script type="text/javascript">

                 function revisarFechaRecuperado(sender, args) {
                     if (sender._selectedDate > new Date()) {
                         alert("¡No se puede seleccionar un día posterior a la fecha actual!");
                         sender._selectedDate = new Date();
                         sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                     }
                 }

                 function revisarFechaDepositado(sender, args) {
                     if (sender._selectedDate > new Date()) {
                         alert("¡No se puede seleccionar un día posterior a la fecha actual!");
                         sender._selectedDate = new Date();
                         sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                     }
                 }

                 function soloNumeros(e) {
                     var key = window.Event ? e.which : e.keyCode
                     return (key >= 48 && key <= 57)
                 }

                 function soloLetras(e) {
                     key = e.keyCode || e.which;
                     tecla = String.fromCharCode(key).toLowerCase();
                     letras = " abcdefghijklmnñopqrstuvwxyz";
                     //especiales = "";

                     //                     tecla_especial = false
                     //                     for (var i in especiales) {
                     //                         if (key == especiales[i]) {
                     //                             tecla_especial = true;
                     //                             break;
                     //                         }
                     //                     }

                     //                     if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                     //                         return false;
                     //                     }

                     if (letras.indexOf(tecla) == -1) {
                         return false;
                     }
                 }
            </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
        <asp:PostBackTrigger ControlID="ddlMunicipio" />
        <asp:PostBackTrigger ControlID="ddlLocalidad" />
        <asp:PostBackTrigger ControlID="cmdMapa" />
        <asp:PostBackTrigger ControlID="cmdDelito" />

        <asp:PostBackTrigger ControlID="cmdGuardar" />
        <asp:PostBackTrigger ControlID="cmdReg" />
      

    </Triggers>
    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                     class="color-fuente"></asp:Label>
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
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="Black" 
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
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Visible=FALSE ></asp:Label>
            <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Width="200px"  Visible=FALSE ></asp:TextBox>

    <h2> 
        <asp:Label ID="lblOperacion" runat="server" 
             class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
        <tr>
                <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ID_LUGAR_HECHOS" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" 
                        GroupingText="¿CUANDO OCURRIERON LOS HECHOS?" Font-Bold="True" 
                        Font-Size="Medium" >
                        <table style="width:100%;">
                            <tr>
                                <td class="style12">
                                    <asp:Label runat="server" Text="DIA/MES/A&#209;O" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" ID="Label2"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="HORA:MIN" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" ID="Label3"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style12">
                                    <asp:TextBox class="bordeCampoObligatorio" runat="server" MaxLength="10" TabIndex="1" Width="170px" 
                                        ID="txtFecha"></asp:TextBox>
                                    <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" Enabled="True" 
                                        TargetControlID="txtFecha" ID="txtFecha_CalendarExtender" OnClientDateSelectionChanged="revisarFechaDepositado">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" 
                                        ControlToValidate="txtFecha" ErrorMessage="INGRESA FECHA" Display="Dynamic" 
                                        ID="RequiredFieldValidator1">*</asp:RequiredFieldValidator>
                                    <asp:RangeValidator runat="server" MaximumValue="31/12/9999" 
                                        MinimumValue="01/01/1111" ForeColor="Red" ControlToValidate="txtFecha" 
                                        ErrorMessage="FECHA INVALIDA" Display="Dynamic" Font-Bold="True" 
                                        Font-Size="Medium" ID="RangeValidator1">*</asp:RangeValidator>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" MaxLength="5" TabIndex="2" Width="170px"  class="bordeCampoObligatorio"
                                        ID="txtHora"></asp:TextBox>
                                     <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptAMPM="True"
                                                BehaviorID="_content_MaskedEditExtender3" Century="2000" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="€" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="," CultureName="es-ES" CultureThousandsPlaceholder="."
                                                CultureTimePlaceholder=":" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time"
                                                TargetControlID="txtHora" />
                                            <asp:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                                ControlToValidate="txtHora" ErrorMessage="*" InvalidValueMessage="REGISTRE HORA"
                                                ForeColor="Red" ToolTip="ERROR FORMATO HORA" TooltipMessage="Hora 0:00 am hasta 12:59 pm"></asp:MaskedEditValidator>
                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" 
                                        ControlToValidate="txtHora" ErrorMessage="INGRESA HORA" Display="Dynamic" 
                                        Font-Bold="True" Font-Size="Small" ID="RequiredFieldValidator2">*</asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:Label runat="server" Text="HRS." Font-Bold="True" ForeColor="Black" 
                                        ID="Label25"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style12">
                                    &nbsp;</td>
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
                    <asp:Panel ID="Panel2" runat="server" 
                        GroupingText="¿DONDE OCURRIERON LOS HECHOS?" Font-Bold="True" 
                        Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Label4" runat="server" Text="TIPO DE LUGAR" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LOCALIDAD"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="2">
                                            <asp:DropDownList ID="ddlTipoLugar" runat="server" Width="470px" TabIndex="3" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="ddlTipoLugar" Display="Dynamic" 
                                                ErrorMessage="INGRESA TIPO DE LUGAR" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipio" runat="server" Width="200px" class="bordeCampoObligatorio"
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddlMunicipio_SelectedIndexChanged" TabIndex="4">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="ddlMunicipio" Display="Dynamic" 
                                                ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="200px" class="bordeCampoObligatorio"
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddlLocalidad_SelectedIndexChanged" TabIndex="5">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ControlToValidate="ddlLocalidad" Display="Dynamic" 
                                                ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="COLONIA O FRACCIONAMIENTO"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="CALLE "></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="2">
                                            <asp:DropDownList ID="ddlColonia" runat="server" Width="470px" TabIndex="6" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                ControlToValidate="ddlColonia" Display="Dynamic" ErrorMessage="INGRESA COLONIA" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCalle" runat="server" Width="470px" TabIndex="7" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                ControlToValidate="ddlCalle" Display="Dynamic" ErrorMessage="INGRESA CALLE" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ENTRE CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="Y CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="2">
                                            <asp:DropDownList ID="ddlEntreCalle" runat="server" Width="470px" TabIndex="8" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                ControlToValidate="ddlEntreCalle" Display="Dynamic" 
                                                ErrorMessage="INGRESA ENTRE CALLE" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlYcalle" runat="server" Width="470px" TabIndex="9" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                ControlToValidate="ddlYcalle" Display="Dynamic" ErrorMessage="INGRESA Y CALLE" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="No. EXTERIOR"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MANZANA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LOTE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:TextBox ID="txtNumero" runat="server" Width="170px" MaxLength="10" 
                                                TabIndex="10" style="text-transform :uppercase"></asp:TextBox>
                                        </td>
                                        <td class="style2">
                                            <asp:TextBox ID="txtManzana" runat="server" Width="170px" MaxLength="10" 
                                                TabIndex="11" style="text-transform :uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLote" runat="server" Width="200px" MaxLength="10" 
                                                TabIndex="12" style="text-transform :uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LATITUD"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LONGITUD"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="REFERENCIAS"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:TextBox ID="txtLatitud" runat="server" Width="170px" MaxLength="20" 
                                                TabIndex="13" style="text-transform :uppercase" Enabled="False">0</asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                ControlToValidate="txtLatitud" Display="Dynamic" ErrorMessage="INGRESA LATITUD" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLongitud" runat="server" Width="170px" MaxLength="20" 
                                                TabIndex="14" style="text-transform :uppercase" Enabled="False">0</asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                ControlToValidate="txtLongitud" Display="Dynamic" 
                                                ErrorMessage="INGRESA LONGITUD" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td colspan="2" rowspan="5">
                                            <asp:TextBox ID="txtReferencias" runat="server" Height="85px" 
                                                TextMode="MultiLine" Width="470px" MaxLength="250" TabIndex="15" 
                                                style="text-transform :uppercase"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style14">
                                        </td>
                                        <td class="style14">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Button ID="cmdMapa" runat="server" onclick="cmdMapa_Click" 
                                                Text="ACTUALIZAR MAPA" class="button" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style15">
                                            <asp:Label ID="lblMapa" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MAPA"></asp:Label>
                                        </td>
                                        <td class="style15">
                                        </td>
                                        <td colspan="2" class="style15">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="4">
                                            <cc1:GMap ID="GMap1" enableServerEvents ="True" 
                                                serverEventsType="AspNetPostBack"  runat="server" Width="1050px" Height="600px" 
                                                onclick="GMap1_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="2">
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
                   
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">

                                                            <asp:Panel ID="Panel3" runat="server" GroupingText="DELITOS" Font-Bold="True" 
                                                                Font-Size="Medium" >
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="AGREGAR"></asp:Label>
                                                                            <asp:Button ID="cmdDelito" runat="server" onclick="cmdDelito_Click" 
                                                                                Text=" + " Width="39px" class="button" />
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <asp:GridView ID="gvAlias" runat="server" AutoGenerateColumns="False" 
                                                                                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                                                                                GridLines="None" Width="470px">
                                                                                <AlternatingRowStyle BackColor="White" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ID_LUGAR_HECHOS" HeaderText="ID_LUGAR_HECHOS" 
                                                                                        SortExpression="ID_LUGAR_HECHOS" Visible="False" />
                                                                                    <asp:BoundField DataField="ID_CONSECUTIVO_DELITO" 
                                                                                        HeaderText="ID_CONSECUTIVO_DELITO" SortExpression="ID_CONSECUTIVO_DELITO" 
                                                                                        Visible="False" />
                                                                                    <asp:BoundField DataField="DLTO" HeaderText="DELITO" SortExpression="DLTO" />
                                                                                    <asp:BoundField DataField="MDLDD" HeaderText="MODALIDAD" 
                                                                                        SortExpression="MDLDD" />
                                                                                    <asp:CheckBoxField DataField="ID_VIOLENCIA" HeaderText="VIOLENCIA" 
                                                                                        SortExpression="ID_VIOLENCIA" />
                                                                                    <asp:CheckBoxField DataField="ID_GRAVE" HeaderText="GRAVE" 
                                                                                        SortExpression="ID_GRAVE" />
                                                                                    <asp:CheckBoxField DataField="ID_PRINCIPAL" HeaderText="PRINCIPAL" 
                                                                                        SortExpression="ID_PRINCIPAL" />
                                                                                </Columns>
                                                                                <EditRowStyle BackColor="#2461BF" />
                                                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                                                                    HorizontalAlign="Left" />
                                                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                                ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" 
                                                                                SelectCommand="consultaDelito" SelectCommandType="StoredProcedure">
                                                                                <SelectParameters>
                                                                                    <asp:ControlParameter ControlID="ID_LUGAR_HECHOS" Name="IdLugarHechos" 
                                                                                        PropertyName="Text" Type="Int32" />
                                                                                </SelectParameters>
                                                                            </asp:SqlDataSource>
                                                                        </td>
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
                <td align="center" colspan="4">
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
                <td align="center" colspan="4">

                    
                    
                       <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" Width="156px" 
                        onclick="cmdGuardar_Click" TabIndex="16" Font-Bold="True" Height="40px" class="button"  />
                    <asp:Button ID="cmdReg" runat="server" onclick="cmdReg_Click" Text="REGRESAR" 
                        Width="156px" TabIndex="17" Font-Bold="True" Height="40px" class="button" />
                   
                 


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
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
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
  </asp:UpdatePanel>
   
    
    
    
</div>

</asp:Content>

