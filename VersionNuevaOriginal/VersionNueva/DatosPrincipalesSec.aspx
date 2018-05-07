<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DatosPrincipalesSec.aspx.cs" Inherits="AtencionTemprana.DatosPrincipalesSec" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script type="text/javascript" language="JavaScript">
        //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 13; /*BLOQUEAR ENTER*/ }
        document.onkeydown = function (evt1) { return (evt1 ? evt1.which : event.keyCode) != 13; } /*BLOQUEAR BACKSPACE*/
        //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 32; } /*BLOQUEAR BARRA ESPACIDORA*/
    </script>
    <div id="main-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
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
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style7">
                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black"
                                        Text="PERSONA"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_PRINC_SEC" runat="server" Visible="false" Text=""></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7" colspan="2">
                    <asp:DropDownList ID="ddlOfendido" runat="server" Width="400px">
                    </asp:DropDownList>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel3" runat="server" GroupingText="DATOS PRINCIPALES DEL CASO" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ETAPA DE ATENCIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ESTATUS DEL SECUESTRO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TIPO DE SECUESTRO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlEtapaAtencion" runat="server" TabIndex="1" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstatusSecuestro" runat="server" TabIndex="2" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoSecuestro" runat="server" TabIndex="3" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="FECHA DE PRIVACIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="HORA DE PRIVACIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="¿LA PERSONA RECIBÓ AMENAZAS DE MUERTE?"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" MaxLength="30" TabIndex="4" Width="200px" ID="txtFechaPrivacion"
                                        Style="text-transform: uppercase"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaPrivacion"
                                        Display="Dynamic" ErrorMessage="INGRESA FECHA" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ErrorTooltipEnabled="True"
                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFechaPrivacion" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" MaxLength="30" TabIndex="5" Width="200px" ID="txtHoraPrivacion"
                                        Style="text-transform: uppercase"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                                        CultureName="es-ES" ErrorTooltipEnabled="true" InputDirection="RightToLeft" Mask="99:99:99"
                                        MaskType="Time" MessageValidatorTip="true" TargetControlID="txtHoraPrivacion">
                                    </asp:MaskedEditExtender>
                                </td>
                                <td>
                                    
                                    <asp:DropDownList ID="ddlAmenazaMuerte" runat="server" TabIndex="6" 
                                        Width="200px">
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
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
                <td colspan="4">
                    &nbsp;
                    <asp:Panel runat="server" GroupingText="SELECCIONE " 
                        Font-Bold="True" Font-Size="Small" ForeColor="Black" ID="Panel9">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style27">
                                    <asp:CheckBox runat="server" Text="ALTO IMPACTO" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" ID="chbAltoImpacto"></asp:CheckBox>

                                </td>
                                <td class="style30">
                                    <asp:CheckBox runat="server" Text="DELINCUENCIA ORGANIZADA" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" ID="chbDelincuenciaOrganizada"></asp:CheckBox>

                                </td>
                                <td class="style33">
                                    <asp:CheckBox runat="server" Text="HECHOS DE AÑOS ANTERIORES" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" ID="chbAniosAnteriores"></asp:CheckBox>

                                </td>
                                <td>
                                    <asp:CheckBox runat="server" Text="HECHOS DE OTROS ESTADOS" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" ID="chbOtrosEstados"></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="style39">
                                    <asp:CheckBox runat="server" Text="HECHOS DE MIGRANTES" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" ID="chbMigrantes"></asp:CheckBox>

                                </td>
                                <td class="style40">
                                    <asp:CheckBox runat="server" Text="AUTO SECUESTRO" 
                                        Font-Bold="True" Font-Size="Small" ForeColor="Black" ID="chbAutoSecuestro"></asp:CheckBox>

                                </td>
                                <td class="style41">
                                    <asp:CheckBox runat="server" Text="ROBO DE VEHÍCULO" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" ID="chbRoboVehiculo"></asp:CheckBox>

                                </td>
                                <td class="style38">
                                    <asp:CheckBox runat="server" Text="PRIVACIÓN DE LIBERTAD" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" ID="chbPrivacionLibertad"></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="style34">
                                    <asp:CheckBox runat="server" Text="SECUESTRO (TENTATIVA)" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" ID="chbTentativa"></asp:CheckBox>

                                </td>
                                <td class="style35">
                                    <asp:CheckBox runat="server" Text="SUBSTRACCIÓN DE MENORES" 
                                        Font-Bold="True" Font-Size="Small" ForeColor="Black" ID="chbSubstraccionMenores"></asp:CheckBox>

                                </td>
                                <td class="style36">
                                    &nbsp;</td>
                                <td class="style37">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    &nbsp;</td>
                                <td class="style30">
                                    &nbsp;</td>
                                <td class="style33">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>

                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdGu" runat="server" OnClick="cmdGu_Click" Text="GUARDAR" Width="156px"
                        TabIndex="31" Font-Bold="True" Height="40px" />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" OnClick="cmdReg_Click" Text="REGRESAR" Width="156px"
                        TabIndex="32" Font-Bold="True" Height="40px" />
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
        </table>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </div>
</asp:Content>
