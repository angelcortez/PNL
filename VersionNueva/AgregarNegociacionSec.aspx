<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgregarNegociacionSec.aspx.cs" Inherits="AtencionTemprana.AgregarNegociacionSec" %>

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
        .style8
        {
            width: 310px;
        }
        .style9
        {
            width: 323px;
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
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;
                </td>
                <td align="right" class="style6">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td class="style6">
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td align="right" class="style6">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                </td>
                <td class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black"
                                        Text="PERSONA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:DropDownList ID="ddlOfendido" runat="server" Width="400px">
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
                <td colspan="4">
                    <asp:Panel ID="Panel6" runat="server" GroupingText="DATOS DE LA NEGOCIACIÓN" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style8">
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FECHA DE NEGOCIACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="HORA DE NEGOCIACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                            <asp:TextBox ID="txtFechaNegociacion" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaNegociacion"
                                                Display="Dynamic" ErrorMessage="INGRESA FECHA" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ErrorTooltipEnabled="True"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFechaNegociacion" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHoraNegociacion" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                                                CultureName="es-ES" ErrorTooltipEnabled="true" InputDirection="RightToLeft" Mask="99:99:99"
                                                MaskType="Time" MessageValidatorTip="true" TargetControlID="txtHoraNegociacion">
                                            </asp:MaskedEditExtender>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                            <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CANTIDAD EXIGIDA EN PESOS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label39" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CANTIDAD EXIGIDA EN DÓLARES"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style8">
                                            <asp:TextBox ID="txtPesosExig" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RgularExpressionValidator1" runat="server" ControlToValidate="txtPesosExig"
                                                ErrorMessage="*" ForeColor="Red" ValidationExpression="^[0-9^]+$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDolaresExig" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDolaresExig"
                                                ErrorMessage="*" ForeColor="Red" ValidationExpression="^[0-9^]+$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
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
                    <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                        Text="ESPECIE EXIGIDA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtEspecieExig" runat="server" Height="250px" TextMode="MultiLine"
                        Width="1000px"></asp:TextBox>
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
                    <asp:Panel ID="Panel1" runat="server" GroupingText="DATOS DEL PAGO" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style9">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FECHA DE PAGO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="HORA DE PAGO"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9">
                                            <asp:TextBox ID="txtFechaDelPago" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaDelPago"
                                                Display="Dynamic" ErrorMessage="INGRESA FECHA" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" ErrorTooltipEnabled="True"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFechaDelPago" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHoraDelPago" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptAMPM="true"
                                                CultureName="es-ES" ErrorTooltipEnabled="true" InputDirection="RightToLeft" Mask="99:99:99"
                                                MaskType="Time" MessageValidatorTip="true" TargetControlID="txtHoraDelPago">
                                            </asp:MaskedEditExtender>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9">
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
                                        <td class="style9">
                                            <asp:Label ID="Label41" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="PESOS PAGADOS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="DÓLARES PAGADOS"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style9">
                                            <asp:TextBox ID="txtPesosPagados" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPesosPagados"
                                                ErrorMessage="*" ForeColor="Red" ValidationExpression="^[0-9^]+$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDolaresPagados" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21" Width="190px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDolaresPagados"
                                                ErrorMessage="*" ForeColor="Red" ValidationExpression="^[0-9^]+$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td align="center" colspan="2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                        Text="ESPECIE EXIGIDA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtEspeciePagada" runat="server" Height="250px" TextMode="MultiLine"
                        Width="1000px"></asp:TextBox>
                </td>
                <td align="center" colspan="2">
                    &nbsp;
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
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
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
            <tr>
                <td align="center" colspan="4">
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;
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
