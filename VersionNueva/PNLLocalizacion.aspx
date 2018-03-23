<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PNLLocalizacion.aspx.cs" Inherits="AtencionTemprana.PNLLocalizacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            height: 19px;
        }
        .style7
        {
            height: 15px;
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
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%-- <asp:ModalPopupExtender ID="Panel2_ModalPopupExtender" runat="server" PopupControlID="Panel2"
                        DynamicServicePath="" Enabled="True" TargetControlID="Label40" PopupDragHandleControlID="PoppupHeader" Drag="true" BackgroundCssClass="ModalPopupBG">
                    </asp:ModalPopupExtender>--%>
    <script type="text/javascript" language="JavaScript">
        //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 13; /*BLOQUEAR ENTER*/ }
        document.onkeydown = function (evt1) { return (evt1 ? evt1.which : event.keyCode) != 13; } /*BLOQUEAR BACKSPACE*/
        //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 32; } /*BLOQUEAR BARRA ESPACIDORA*/


        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }

        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " abcdefghijklmnñopqrstuvwxyz";

            if (letras.indexOf(tecla) == -1) {
                return false;
            }
        }


    </script>
    <div id="main-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" class="color-fuente"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                </td>
                <td class="style6">
                </td>
                <td class="style6">
                </td>
                <td align="right" class="style6">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td class="style6">
                </td>
                <td class="style6">
                </td>
                <td align="right" class="style6">
                    <asp:Label ID="ID_LOCALIZADO" runat="server" ForeColor="Red" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                
            </tr>
            <tr>
            <td colspan="4">
             <asp:Label ID="ID_OTRA_INFO" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                    <asp:Label ID="ID_PERTENENCIA_SOCIAL" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                    <asp:Label ID="ID_INFO_FINANCIERA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                    <asp:Label ID="ID_DISCAPACIDADES" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                    <asp:Label ID="ID_INFO_ODONTOLOGICA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                    <asp:Label ID="ID_DATOS_GENERALES" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
            </td>
            
            </tr>
            
        </table>

        <br />
        <br />

       <table style="width: 100%;">
                    <tr>
               <td colspan="4">
                   <asp:Label ID="Label60" runat="server" Font-Bold="True" Font-Italic="True" 
                       ForeColor="Black" Text="OFENDIDO"></asp:Label>
               </td>
               </tr>
                   <tr>
                       <td colspan="4">
                           <asp:DropDownList ID="ddlOfendido" runat="server" Width="400px" class="bordeCampoObligatorio">
                           <asp:ListItem>--SELECCIONE--</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="4">
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td colspan="4">
                           &nbsp;</td>
                   </tr>
                   <tr>
                       
                       <td>
                           <asp:Label ID="Label61" runat="server" Font-Bold="True" Font-Size="Small" 
                                               ForeColor="Black" Text="ESTATUS PERSONA"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label62" runat="server" Font-Bold="True" Font-Size="Small" 
                                               ForeColor="Black" Text="FECHA LOCALIZACION"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label63" runat="server" Font-Bold="True" Font-Size="Small" 
                                               ForeColor="Black" Text="HORA LOCALIZACION"></asp:Label>
                       </td>
                   </tr>
                   
                   <tr>
                       
                       <td>
                           <asp:RadioButtonList ID="rbEstatus" runat="server" RepeatDirection="Horizontal" Font-Bold="True" Font-Size="Small" ForeColor="Black" class="bordeCampoObligatorio"
                               AutoPostBack="True" onselectedindexchanged="rbEstatus_SelectedIndexChanged">
                               <asp:ListItem Value="1">VIVO</asp:ListItem>
                               <asp:ListItem Value="0">MUERTO</asp:ListItem>
                           </asp:RadioButtonList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                               ControlToValidate="rbEstatus" Display="Dynamic" 
                                               ErrorMessage="SELECCIONA ESTATUS PERSONA" ForeColor="Red">*</asp:RequiredFieldValidator>
                       </td>
                       <td>
                           <asp:TextBox ID="txtFechaLocalizacion" runat="server" MaxLength="10" class="bordeCampoObligatorio"
                                               Width="200px"></asp:TextBox>
                           <asp:CalendarExtender ID="txtFechaLocalizacion_CalendarExtender" runat="server" 
                                               Enabled="True" Format="dd/MM/yyyy"  
                                               TargetControlID="txtFechaLocalizacion">
                           </asp:CalendarExtender>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                               ControlToValidate="txtFechaLocalizacion" Display="Dynamic" 
                                               ErrorMessage="INGRESA FECHA LOCALIZACION" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ErrorTooltipEnabled="True"
                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFechaLocalizacion" />
                       </td>
                       <td>
                           <asp:TextBox ID="txtHoraLocalizacion" runat="server" MaxLength="10" class="bordeCampoObligatorio" Width="200px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptAMPM="True"
                                                BehaviorID="_content_MaskedEditExtender3" Century="2000" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="€" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="," CultureName="es-ES" CultureThousandsPlaceholder="."
                                                CultureTimePlaceholder=":" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time"
                                                TargetControlID="txtHoraLocalizacion" 
                            />
                            <asp:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                                ControlToValidate="txtHoraLocalizacion" ErrorMessage="*" InvalidValueMessage="REGISTRE HORA"
                                                ForeColor="Red" ToolTip="ERROR FORMATO HORA" TooltipMessage="Hora 00:00 am hasta 23:59 pm">
				            </asp:MaskedEditValidator>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtHoraLocalizacion" Display="Dynamic" ErrorMessage="INGRESA HORA LOCALIZACION" ForeColor="Red">*</asp:RequiredFieldValidator>
                       </td>
                   </tr>
                   
                   <tr>
                       <td colspan="2">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   
                   <tr>
                       <td colspan="2">
                           <asp:Label ID="Label64" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="POSIBLE CAUSA DE LA DESAPARICION"></asp:Label>
                       </td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   
                   <tr>
                       <td colspan="4">
                           <asp:TextBox ID="txtDesaparicion" runat="server" Height="69px" MaxLength="1000" 
                                               style="text-transform :uppercase" TextMode="MultiLine" 
                               Width="967px" class="bordeCampoObligatorio"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                               ControlToValidate="txtDesaparicion" Display="Dynamic" 
                                               ErrorMessage="INGRESA CAUSA DESAPARICION" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                           <asp:Label ID="Label65" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="CONDICIONES LOCALIZACION"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label66" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="LUGAR DE HALLAZGO"></asp:Label>
                       </td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   
                   <tr>
                       <td>
                           <asp:DropDownList ID="ddlCondiciones" runat="server" Width="200px" class="bordeCampoObligatorio">                            
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                               ControlToValidate="ddlCondiciones" Display="Dynamic" 
                                               ErrorMessage="SELECCIONA CONDICIONES LOCALIZACION" 
                               ForeColor="Red">*</asp:RequiredFieldValidator>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlLugarHallazgo" runat="server" Width="200px" class="bordeCampoObligatorio">                            
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                               ControlToValidate="ddlLugarHallazgo" Display="Dynamic" 
                                               ErrorMessage="SELECCIONA LUGAR DE HALLAZO" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           </asp:UpdatePanel>
                            
                       </td>
                   </tr>
                   <tr>
                       <td colspan="4">
                    <asp:Panel ID="Panel7" runat="server" GroupingText="DOMICILIO"
                        Font-Bold="True" Font-Size="Medium">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                        <Triggers>
        

        <asp:PostBackTrigger ControlID="ddlPais" />
        <asp:PostBackTrigger ControlID="ddlEntidad" />
        <asp:PostBackTrigger ControlID="ddlMunicipio" />
        <asp:PostBackTrigger ControlID="ddlLocalidadDom" />
        <asp:PostBackTrigger ControlID="ddlColonia" />

        
      

    </Triggers>
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="PAIS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="ESTADO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label82" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MUNICIPIO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label83" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LOCALIDAD"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaisDom_SelectedIndexChanged"
                                                TabIndex="8" Width="200px" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlPais"
                                                Display="Dynamic" ErrorMessage="INGRESA PAÍS" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEntidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoDom_SelectedIndexChanged"
                                                TabIndex="14" Width="200px" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlEntidad"
                                                ErrorMessage="INGRESA ESTADO" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipioDom_SelectedIndexChanged"
                                                TabIndex="15" Width="200px" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlMunicipio"
                                                Display="Dynamic" ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadDom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidadDom_SelectedIndexChanged"
                                                TabIndex="16" Width="200px" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="ddlLocalidadDom"
                                                Display="Dynamic" ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label84" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="COLONIA"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label85" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlColonia" runat="server" Width="470px" AutoPostBack="True"
                                                TabIndex="17" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddlColonia"
                                                Display="Dynamic" ErrorMessage="INGRESA COLONIA" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCalle" runat="server" Width="470px" TabIndex="18" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlCalle"
                                                Display="Dynamic" ErrorMessage="INGRESA CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label86" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="ENTRE CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label87" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="Y CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlEntreCalle" runat="server" Width="470px" TabIndex="19" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlEntreCalle"
                                                Display="Dynamic" ErrorMessage="INGRESA ENTRE CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlYcalle" runat="server" Width="470px" TabIndex="20" class="bordeCampoObligatorio">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlYcalle"
                                                Display="Dynamic" ErrorMessage="INGRESA Y CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="NUMERO EXTERIOR"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label92" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="NUMERO INTERIOR"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CP"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNumExt0" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="21"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNumInt0" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="22"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCP0" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="23"></asp:TextBox>
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
                       <td colspan="4">
                           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                           <ContentTemplate>
                           <asp:Panel ID="Panel2" runat="server" Font-Bold="True" Font-Size="Small" GroupingText="DATOS DEL SEMEFO">
                               <table style="width:100%;">
                                   <tr>
                                       <td>
                                           &nbsp;</td>
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
                                           <asp:Label ID="Label67" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="FECHA INGRESO"></asp:Label>
                                       </td>
                                       <td>
                                           <asp:Label ID="Label68" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="HORA INGRESO"></asp:Label>
                                       </td>
                                       <td>
                                           <asp:Label ID="Label69" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="CAUSA DE FALLECIMIENTO"></asp:Label>
                                       </td>
                                       <td>
                                           <asp:Label ID="Label70" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="IDENTIFICACION DEL CADAVER"></asp:Label>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           <asp:TextBox ID="txtFechaIngreso" runat="server" Width="200px" MaxLength="10" class="bordeCampoObligatorio"></asp:TextBox>
                                           <asp:CalendarExtender ID="txtFechaIngreso_CalendarExtender" runat="server"  Format="dd/MM/yyyy"  
                                               Enabled="True" TargetControlID="txtFechaIngreso">
                                           </asp:CalendarExtender>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                               ControlToValidate="txtFechaIngreso" Display="Dynamic" 
                                               ErrorMessage="INGRESA FECHA DE INGRESO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                       </td>
                                       <td>
                                           <asp:TextBox ID="txtHoraIngreso" runat="server" Width="200px" MaxLength="10" class="bordeCampoObligatorio"></asp:TextBox>
                                           
                                           <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="True"
                                                BehaviorID="_content_MaskedEditExtender2" Century="2000" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="€" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="," CultureName="es-ES" CultureThousandsPlaceholder="."
                                                CultureTimePlaceholder=":" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time"
                                                TargetControlID="txtHoraIngreso" 
                                            />
                                            <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender2"
                                                ControlToValidate="txtHoraIngreso" ErrorMessage="*" InvalidValueMessage="REGISTRE HORA"
                                                ForeColor="Red" ToolTip="ERROR FORMATO HORA" TooltipMessage="Hora 00:00 am hasta 23:59 pm">
				                            </asp:MaskedEditValidator>
                                           
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                               ControlToValidate="txtHoraIngreso" Display="Dynamic" 
                                               ErrorMessage="INGRESA HORA DE INGRESO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                       </td>
                                       <td>
                                           <asp:DropDownList ID="ddlCausaFallecimiento" runat="server" AutoPostBack="True"  Width="200px" class="bordeCampoObligatorio">
                                           </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                               ControlToValidate="ddlCausaFallecimiento" Display="Dynamic" 
                                               ErrorMessage="SELECCIONA CAUSA DE FALLECIMIENTO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                       </td>
                                       <td>
                                           <asp:TextBox ID="txtIdentificacion" runat="server" MaxLength="10" class="bordeCampoObligatorio" 
                                               style="text-transform :uppercase" Width="200px"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                               ControlToValidate="txtIdentificacion" Display="Dynamic" 
                                               ErrorMessage="SELECCIONA IDENTIFICACION DEL CADAVER" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           <asp:Label ID="Label71" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="FECHA ENTREGA DEL CUERPO"></asp:Label>
                                       </td>
                                       <td>
                                           <asp:Label ID="Label72" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="FECHA PROBALE FALLECIMIENTO"></asp:Label>
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
                                           <asp:TextBox ID="txtFechaEntrega" runat="server" Width="200px" MaxLength="10"></asp:TextBox>
                                           <asp:CalendarExtender ID="txtFechaEntrega_CalendarExtender" runat="server"  Format="dd/MM/yyyy"  
                                               Enabled="True" TargetControlID="txtFechaEntrega">
                                           </asp:CalendarExtender>
                                       </td>
                                       <td>
                                           <asp:TextBox ID="txtFechaProbable" runat="server" Width="200px" MaxLength="10"></asp:TextBox>
                                           <asp:CalendarExtender ID="txtFechaProbable_CalendarExtender" runat="server"  Format="dd/MM/yyyy" 
                                               Enabled="True" TargetControlID="txtFechaProbable">
                                           </asp:CalendarExtender>
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
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td colspan="4">
                                           <asp:Panel ID="Panel3" runat="server" Font-Bold="True" Font-Size="Small" 
                                               GroupingText="ENTE QUE LOCALIZA AL NO LOACALIZADO">
                                               <table style="width:100%;">
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
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
                                                       <td colspan="2">
                                                           <asp:RadioButtonList ID="rbLocaliza" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" 
                                                               RepeatDirection="Horizontal" AutoPostBack="True" 
                                                               onselectedindexchanged="rbLocaliza_SelectedIndexChanged">
                                                               <asp:ListItem Value="1">PERSONA</asp:ListItem>
                                                               <asp:ListItem Value="2">INSTITUCION</asp:ListItem>
                                                               <asp:ListItem Selected="True" Value="3">NO ESPECIFICADO</asp:ListItem>
                                                           </asp:RadioButtonList>
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
                                                           <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="NOMBRE"></asp:Label>
                                                           <asp:Label ID="lblInstitucion" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="INSTITUCION"></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="lblPaterno" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO PATERNO"></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="lblMaterno" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO MATERNO"></asp:Label>
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           <asp:TextBox ID="txtNombreLocalizado" runat="server" Width="200px"  style="text-transform :uppercase"
                                                               MaxLength="30"></asp:TextBox>
                                                           <asp:TextBox ID="txtInstitucion" runat="server" Width="200px" MaxLength="40"  style="text-transform :uppercase"></asp:TextBox>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtPaterno" runat="server" Width="200px" MaxLength="30"  style="text-transform :uppercase"></asp:TextBox>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtMaterno" runat="server" Width="200px" MaxLength="30"  style="text-transform :uppercase"></asp:TextBox>
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>
                                               <br />
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
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td colspan="4">
                                           <asp:Panel ID="Panel4" runat="server" Font-Bold="True" Font-Size="Small" 
                                               GroupingText="AUTORIDAD QUE CONOCE EL HECHO">
                                               <table style="width:100%;">
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
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
                                                           <asp:Label ID="Label77" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="AUTORIDAD"></asp:Label>
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
                                                           &nbsp;</td>
                                                       <td colspan="2">
                                                           <asp:TextBox ID="txtAutoridad" runat="server" Width="400px" MaxLength="50"  style="text-transform :uppercase" class="bordeCampoObligatorio"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                               ControlToValidate="txtAutoridad" Display="Dynamic" 
                                                               ErrorMessage="INGRESA AUTORIDAD" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           <asp:Label ID="Label81" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="NOMBRE"></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="Label79" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO PATERNO"></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="Label80" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO MATERNO"></asp:Label>
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           <asp:TextBox ID="txtNombreAutoridad" runat="server" Width="200px"  style="text-transform :uppercase" class="bordeCampoObligatorio" onKeyPress="return soloLetras(event)"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                               ControlToValidate="txtNombreAutoridad" Display="Dynamic" 
                                                               ErrorMessage="INGRESA NOMBRE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtPaternoAutoridad" runat="server" Width="200px"  style="text-transform :uppercase" class="bordeCampoObligatorio" onKeyPress="return soloLetras(event)"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                               ControlToValidate="txtPaternoAutoridad" Display="Dynamic" 
                                                               ErrorMessage="INGRESA PATERNO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtMaternoAutoridad" runat="server" Width="200px"  style="text-transform :uppercase" onKeyPress="return soloLetras(event)"></asp:TextBox>
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>
                                               <br />
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
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td colspan="4">
                                           <asp:Panel ID="Panel6" runat="server" Font-Bold="True" Font-Size="Small"
                                               GroupingText="PERSONA QUE RECLAMA EL CUERPO">
                                               <table style="width:100%;">
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
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
                                                           <asp:Label ID="Label88" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="NOMBRE"></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="Label89" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO PATERNO"></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="Label90" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO MATERNO"></asp:Label>
                                                       </td>
                                                       <td>
                                                           <asp:Label ID="Label91" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="PARENTESCO"></asp:Label>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td>
                                                           &nbsp;</td>
                                                       <td>
                                                           <asp:TextBox ID="txtNombreReclama" runat="server" Width="200px" MaxLength="30"  style="text-transform :uppercase" class="bordeCampoObligatorio" onKeyPress="return soloLetras(event)"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                               ControlToValidate="txtNombreReclama" Display="Dynamic" 
                                                               ErrorMessage="INGRESA NOMBRE" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtPaternoReclama" runat="server" Width="200px" MaxLength="30"  style="text-transform :uppercase" class="bordeCampoObligatorio"  onKeyPress="return soloLetras(event)"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                                               ControlToValidate="txtPaternoReclama" Display="Dynamic" 
                                                               ErrorMessage="INGRESA PATERNO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                       </td>
                                                       <td>
                                                           <asp:TextBox ID="txtMaternoReclama" runat="server" Width="200px" MaxLength="30"  style="text-transform :uppercase" onKeyPress="return soloLetras(event)"></asp:TextBox>
                                                       </td>
                                                       <td>
                                                           <asp:DropDownList ID="ddlParentesco0" runat="server" AutoPostBack="True"  Width="200px" class="bordeCampoObligatorio">
                                                           </asp:DropDownList>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                                               ControlToValidate="ddlParentesco0" Display="Dynamic" 
                                                               ErrorMessage="SELECCIONA PARENTESCO" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                       </td>
                                                   </tr>
                                               </table>
                                               <br />
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
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                               </table>
                               <br />
                           </asp:Panel>
                           </ContentTemplate>
                           </asp:UpdatePanel>
                             
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
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            <br />
                           <asp:Button ID="cmdGuardarCuerpo" runat="server" Height="40px" 
                              Text="GUARDAR" onclick="cmdGuardarCuerpo_Click" 
                                 Width="156px" class="button"  />
                            &nbsp;<asp:Button ID="cmdRegresar" runat="server"
                               Text="REGRESAR" Height="40px" onclick="cmdRegresar_Click" Width="156px" class="button"/>
                        </td>
                   </tr>
               </table>

        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </div>
</asp:Content>
