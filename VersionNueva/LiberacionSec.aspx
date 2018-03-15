<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LiberacionSec.aspx.cs" Inherits="AtencionTemprana.LiberacionSec" %>

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
                </td>
                <td class="style6">
                </td>
                <td align="right" class="style6">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
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
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
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
                   
                                    <asp:Label ID="Label38" runat="server" Font-Bold="True" 
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
                    <asp:Panel ID="Panel7" runat="server" GroupingText="DATOS DE LA LIBERACIÓN" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CORPORACIÓN QUE LIBERÓ A LA PERSONA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MÉTODO DE LIBERACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FECHA DE LIBERACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="HORA DE LIBERACIÓN"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCorporacionLib" runat="server" Width="200px" TabIndex="7">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMetodoLiberacion" runat="server" TabIndex="7" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFechaLiberacion" runat="server" Style="text-transform: uppercase"
                                                TabIndex="9" Width="190px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFechaLiberacion"
                                                Display="Dynamic" ErrorMessage="INGRESE FECHA" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ErrorTooltipEnabled="True"
                                                Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFechaLiberacion" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHoraLiberacion" runat="server" Style="text-transform: uppercase"
                                                TabIndex="10" Width="190px"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                                                CultureName="es-ES" ErrorTooltipEnabled="true" InputDirection="RightToLeft" Mask="99:99:99"
                                                MaskType="Time" MessageValidatorTip="true" TargetControlID="txtHoraLiberacion">
                                            </asp:MaskedEditExtender>
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
                                            <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="DURACIÓN DEL SECUESTRO (NÚMERO DE DÍAS)"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CONDICIONES DE LOCALIZACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVivo" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="VIVO" Visible="True"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDuracionSecuestro" runat="server" Style="text-transform: uppercase"
                                                TabIndex="11" Width="190px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RgularExpressionValidator1" runat="server" ControlToValidate="txtDuracionSecuestro"
                                                ErrorMessage="*" ForeColor="Red" ValidationExpression="^[0-9^]+$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCondicionesLocalizacion" runat="server" Width="200px" TabIndex="24">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlVM" runat="server" TabIndex="24" Width="200px">
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                                <asp:ListItem Value="1">SI</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlVM"
                                                Display="Dynamic" ErrorMessage="SELECCIONE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
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
                    <asp:Panel ID="Panel6" runat="server" GroupingText="DOMICILIO DONDE OCURRIÓ LA LIBERACIÓN"
                        Font-Bold="True" Font-Size="Medium" ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
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
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MUNICIPIO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LOCALIDAD"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPaisDom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaisDom_SelectedIndexChanged"
                                                TabIndex="8" Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPaisDom"
                                                Display="Dynamic" ErrorMessage="INGRESA PAÍS" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstadoDom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoDom_SelectedIndexChanged"
                                                TabIndex="14" Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlEstadoDom"
                                                ErrorMessage="INGRESA ESTADO" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipioDom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipioDom_SelectedIndexChanged"
                                                TabIndex="15" Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlMunicipioDom"
                                                Display="Dynamic" ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadDom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidadDom_SelectedIndexChanged"
                                                TabIndex="16" Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlLocalidadDom"
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
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="COLONIA"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlColonia" runat="server" Width="470px" AutoPostBack="True"
                                                TabIndex="17">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlColonia"
                                                Display="Dynamic" ErrorMessage="INGRESA COLONIA" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCalle" runat="server" Width="470px" TabIndex="18">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCalle"
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
                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="ENTRE CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="Y CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlEntreCalle" runat="server" Width="470px" TabIndex="19">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlEntreCalle"
                                                Display="Dynamic" ErrorMessage="INGRESA ENTRE CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlYcalle" runat="server" Width="470px" TabIndex="20">
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
                                                Text="NUMERO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MANZANA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LOTE"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LUGAR DE REFERENCIA"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNumero" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="21"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtManzana" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="22"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLote" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="23"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLugarReferencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidadDom_SelectedIndexChanged"
                                                TabIndex="24" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
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
