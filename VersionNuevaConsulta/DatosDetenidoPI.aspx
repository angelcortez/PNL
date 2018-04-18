<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DatosDetenidoPI.aspx.cs" Inherits="AtencionTemprana.DatosDetenidoPI1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       
     
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
    </script>
    <div id="main-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#006600"></asp:Label>
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
                <td>
                    <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                    <asp:Label ID="IdUsuario" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"
                        Visible="false"></asp:Label>
                    <asp:Label ID="IdDetencion" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"
                        Visible="true"></asp:Label>
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
                </td>
                <td class="style6">
                </td>
                <td class="style6">
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td align="right" class="style6">
                    <asp:Label ID="ID_DETENCION" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="ID_PERSONA_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_DOMICILIO" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="ID_TIPO_ACTOR" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ID_MUNICIPIO" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="ID_UNDD" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:Label ID="ID_LUGAR_HECHOS" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                 <td>
                </td>
                 <td>
                </td>
                <td class="style11">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel3" runat="server" GroupingText="NOMBRE" Font-Bold="True" Font-Size="Medium"
                        ForeColor="#006600">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="IMPUTADO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlImputado" runat="server" Width="400px">
                                    </asp:DropDownList>
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
                <td>
                    &nbsp;
                </td>
                <td class="style11">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lblIdTipoActor" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel9" runat="server" GroupingText="DATOS DETENCIÓN" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEstadoDet2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ESTADO DEL DETENIDO" Visible="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label344" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="DETENIDO POR"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label349" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TIEMPO DE TRASLADO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlEstadoDetenido" runat="server" TabIndex="48" Visible="TRUE"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDetenidoPor" runat="server" TabIndex="49" Visible="TRUE"
                                        Width="200px">
                                        <asp:ListItem Value="0">-- SELECCIONE --</asp:ListItem>
                                        <asp:ListItem Value="POLICIA INVESTIGADORA">POLICIA INVESTIGADORA</asp:ListItem>
                                        <asp:ListItem Value="POLICIA ANTISECUESTROS">POLICIA ANTISECUESTROS</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTiempoTraslado" runat="server" MaxLength="5" Width="200px" TabIndex="50">00:00</asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="True"
                                        BehaviorID="_content_MaskedEditExtender2" Century="2000" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="€" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                        CultureDecimalPlaceholder="," CultureName="es-ES" CultureThousandsPlaceholder="."
                                        CultureTimePlaceholder=":" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time"
                                        TargetControlID="txtTiempoTraslado" />
                                    <asp:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                        ControlToValidate="txtTiempoTraslado" ErrorMessage="*" InvalidValueMessage="REGISTRE HORA"
                                        ForeColor="Red" ToolTip="ERROR FORMATO HORA" TooltipMessage="Hora 0:00 am hasta 12:59 pm">
                                    </asp:MaskedEditValidator>
                                </td>
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
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ASUNTO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="DIRIGIDO A"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label346" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="PARTICIPACIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label347" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="OPERATIVO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtAsunto" runat="server" Style="text-transform: uppercase" TabIndex="51"
                                        MaxLength="100" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDirigidoA" runat="server" Style="text-transform: uppercase" TabIndex="52"
                                        MaxLength="250" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlParticipacion" runat="server" TabIndex="53" Visible="TRUE"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOperativo" runat="server" TabIndex="54" Visible="TRUE" Width="200px">
                                        <asp:ListItem Value="3">-- SELECCIONE --</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:Label ID="Label348" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="AGENTES"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="Label357" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="COMANDANTE DEL OPERATIVO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtAgentes" runat="server" MaxLength="1000" Style="text-transform: uppercase"
                                        TabIndex="55" Width="500px"></asp:TextBox>
                                </td>
                               
                                <td colspan="2">
                                    <asp:TextBox ID="txtComandanteOperativo" runat="server" MaxLength="150" 
                                        Style="text-transform: uppercase" TabIndex="56" Width="350px"></asp:TextBox>
                                </td>
                               
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                           
                           
                           
                            <tr>
                                <td>
                                
                                    <asp:Label ID="Label354" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="AUTORIDAD PUSO A DISPOCICIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label353" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="NOMBRE DE QUIÉN LO RECIBÓ"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label352" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="CARGO DE QUIEN RECIBIÓ"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label351" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="LUGAR PUESTO A DISPOSICIÓN"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtAutoridadDisp" runat="server" MaxLength="100" Style="text-transform: uppercase"
                                        TabIndex="57" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombreRecibio" runat="server" MaxLength="150" Style="text-transform: uppercase"
                                        TabIndex="58" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCargoRecibio" runat="server" MaxLength="100" Style="text-transform: uppercase" TabIndex="59" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPuestaDisposicion" runat="server" Style="text-transform: uppercase" MaxLength="250" TabIndex="60"
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label350" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="MOTIVO DETENCIÓN"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label358" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FECHA DETENCIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label359" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="HORA DETENCIÓN"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtMotivoDetencion" runat="server" Style="text-transform: uppercase" MaxLength="300" TabIndex="61"
                                        Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    
                                    <asp:TextBox ID="txtFecha" runat="server" MaxLength="100" TabIndex="59"  
                                        Width="200px"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFecha"
                                                Display="Dynamic" ErrorMessage="INGRESE FECHA" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ErrorTooltipEnabled="True"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFecha" />
                                </td>

                                <td>
                                
                                    <asp:TextBox ID="txtHora" runat="server" MaxLength="100" TabIndex="59" 
                                        Width="200px"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptAMPM="true"
                                                CultureName="es-ES" ErrorTooltipEnabled="true" InputDirection="RightToLeft" Mask="99:99:99"
                                                MaskType="Time" MessageValidatorTip="true" TargetControlID="txtHora">
                                            </asp:MaskedEditExtender>
                                
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label338" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="EN CASO DE QUE EL DETENIDO SE NEGARA A FIRMAR, O QUE SEA IMPOSIBLE LA LECTURA DE DERECHOS,
                                                  ASENTAR LA CIRCUNSTANCIA:"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtCausaNofirma" runat="server" MaxLength="1000" Style="text-transform: uppercase" TabIndex="62" Width="832px"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label341" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="BREVE DESCRIPCIÓN DE LOS HECHOS"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" >
                                    <asp:TextBox ID="txtDescripcionHechos" TextMode="MultiLine" Style="text-transform: uppercase"  runat="server" Width="1051px"
                                        Height="96px" TabIndex="63"></asp:TextBox>
                                </td>
                              
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="FOTOGRAFÍA DEL DETENIDO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:FileUpload ID="ImagenFile" runat="server" class="margen" Height="23px" TabIndex="64"
                                        Width="293px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Image ID="Ifoto" runat="server" Height="218px" ImageAlign="Middle" Style="margin: 10px;"
                                        Visible="false" Width="270px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style11">
                </td>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" Font-Size="Small"
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br />
                    <asp:Button ID="cmdGu" runat="server" OnClick="cmdGu_Click" Text="GUARDAR DATOS"
                        Width="161px" TabIndex="65" Font-Bold="True" Height="40px" />
                    &nbsp;
                </td>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="center" colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdSiguiente" runat="server" Font-Bold="True" Height="40px" TabIndex="68" Visible="FALSE"
                        Text="GUARDAR" Width="156px" OnClick="cmdSiguiente_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" OnClick="cmdReg_Click"
                        TabIndex="69" Text="REGRESAR" Width="156px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style11">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
