<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ModuloSecuestros.aspx.cs" Inherits="AtencionTemprana.ModuloSecuestros" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 537px;
        }
        .style4
        {
            width: 536px;
        }
        .style5
        {
            width: 179px;
        }
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
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_DOMICILIO" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="ID_TIPO_ACTOR" runat="server" Visible="False"></asp:Label>
                </td>
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
                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="txtFechaPrivacion"
                                        ErrorMessage="INGRESA FECHA" Display="Dynamic" Font-Bold="True" Font-Size="Small"
                                        ID="RequiredFieldValidator1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" MaxLength="30" TabIndex="5" Width="200px" ID="txtHoraPrivacion"
                                        Style="text-transform: uppercase"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="txtHoraPrivacion"
                                        ErrorMessage="INGRESA PATERNO" Display="Dynamic" Font-Bold="True" Font-Size="Small"
                                        ID="RequiredFieldValidator2">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRecibioAmenazas" runat="server" TabIndex="6" Width="200px">
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
                    <asp:Label ID="lblIdTipoActor" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
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
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHoraLiberacion" runat="server" Style="text-transform: uppercase"
                                                TabIndex="10" Width="190px"></asp:TextBox>
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
                                                Text="DURACIÓN DEL SECUESTRO (EN DÍAS)"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CONDICIONES DE LOCALIZACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVivo" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="VIVO" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDuracionSecuestro" runat="server" Style="text-transform: uppercase"
                                                TabIndex="11" Width="190px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCondicionesLocalizacion" runat="server" Width="200px" TabIndex="24">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbVivo" runat="server" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black" RepeatDirection="Horizontal" TabIndex="12" Visible="False">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
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
                                            <asp:DropDownList ID="ddlPaisDom" runat="server" Width="200px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlPaisDom_SelectedIndexChanged" TabIndex="13">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlPaisDom"
                                                Display="Dynamic" ErrorMessage="INGRESA PAIS" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstadoDom" runat="server" Width="200px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlEstadoDom_SelectedIndexChanged" TabIndex="14">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlEstadoDom"
                                                ErrorMessage="INGRESA ESTADO" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipioDom" runat="server" Width="200px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlMunicipioDom_SelectedIndexChanged" TabIndex="15">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlMunicipioDom"
                                                Display="Dynamic" ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadDom" runat="server" Width="200px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlLocalidadDom_SelectedIndexChanged" TabIndex="16">
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
                                            <asp:TextBox ID="txtNumero" runat="server" Width="190px" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="21"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtManzana" runat="server" Width="190px" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="22"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLote" runat="server" Width="190px" MaxLength="10" Style="text-transform: uppercase"
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
                    <asp:Panel ID="Panel1" runat="server" GroupingText="DATOS ADICIONALES DEL DETENIDO"
                        Font-Bold="True" Font-Size="Medium" ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="TIPO DE MANDAMIENTO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="INTERVENCION POLICIAL"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FECHA DE DETENCIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="SITUACIÓN JURÍDICA"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlMandamiento" runat="server" Width="200px" AutoPostBack="True"
                                                TabIndex="25">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIntervencionPolicial" runat="server" Width="200px" AutoPostBack="True"
                                                 TabIndex="26">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFechaDetencion" runat="server" MaxLength="10" Style="text-transform: uppercase"
                                                TabIndex="23" Width="190px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSituacionJuridica" runat="server" Width="200px" AutoPostBack="True"
                                                 TabIndex="28">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlLocalidadDom"
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
                                            <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="PARENTESCO CON LA VÍCTIMA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label39" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="¿SE DETUVO EN FLAGRANCIA?"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="¿EL DETENIDO SE ENCUENTRA VIVO?"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlParentesco" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidadDom_SelectedIndexChanged"
                                                TabIndex="28" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbFlagrancia" runat="server" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black" RepeatDirection="Horizontal" TabIndex="30" Visible="False">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbVivoDetenido" runat="server" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black" RepeatDirection="Horizontal" TabIndex="31" Visible="False">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
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
                <td align="center" colspan="2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel8" runat="server" GroupingText="PRÓFUGOS" Font-Bold="True" Font-Size="Medium"
                        ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style5">
                                            <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#006600"
                                                Text="AGREGAR"></asp:Label>
                                            <asp:Button ID="cmdMedio" runat="server" OnClick="cmdMedio_Click" Text=" + " Width="50px" />
                                        </td>
                                        <td class="style3">
                                            &nbsp;
                                        </td>
                                        <td class="style4">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvMedio" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                Width="472px" AutoGenerateColumns="False" DataSourceID="dsMedioContacto">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="EDITAR">
                                                        <ItemTemplate>
                                                            <a href='MedioContacto.aspx?ID_PERSONA=<%#Eval("ID_PERSONA")%>&amp;&amp;op=Modificar&amp;ID_MEDIO_CONTACTO=<%#Eval("ID_MEDIO_CONTACTO")%>&amp;'>
                                                                <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png"
                                                                    Width="18px" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_MEDIO_CONTACTO" HeaderText="ID_MEDIO_CONTACTO" SortExpression="ID_MEDIO_CONTACTO"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" SortExpression="ID_PERSONA"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="TIPO_MEDIO_CONTACTO" HeaderText="TIPO DE CONTACTO" SortExpression="TIPO_MEDIO_CONTACTO" />
                                                    <asp:BoundField DataField="MEDIO_CONTACTO" HeaderText="MEDIO DE CONTACTO" SortExpression="MEDIO_CONTACTO" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#CCFFCC" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            <asp:SqlDataSource ID="dsMedioContacto" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>"
                                                SelectCommand="consultaMedioContacto" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                        Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td class="style3">
                                            &nbsp;
                                        </td>
                                        <td class="style4">
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
                    <asp:Panel ID="Panel5" runat="server" GroupingText="BANDAS DESARTICULADAS" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style5">
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#006600"
                                                Text="AGREGAR"></asp:Label>
                                            <asp:Button ID="Button1" runat="server" OnClick="cmdMedio_Click" Text=" + " Width="50px" />
                                        </td>
                                        <td class="style3">
                                            &nbsp;
                                        </td>
                                        <td class="style4">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                Width="472px" AutoGenerateColumns="False" DataSourceID="dsMedioContacto">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="EDITAR">
                                                        <ItemTemplate>
                                                            <a href='MedioContacto.aspx?ID_PERSONA=<%#Eval("ID_PERSONA")%>&amp;&amp;op=Modificar&amp;ID_MEDIO_CONTACTO=<%#Eval("ID_MEDIO_CONTACTO")%>&amp;'>
                                                                <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png"
                                                                    Width="18px" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_MEDIO_CONTACTO" HeaderText="ID_MEDIO_CONTACTO" SortExpression="ID_MEDIO_CONTACTO"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" SortExpression="ID_PERSONA"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="TIPO_MEDIO_CONTACTO" HeaderText="TIPO DE CONTACTO" SortExpression="TIPO_MEDIO_CONTACTO" />
                                                    <asp:BoundField DataField="MEDIO_CONTACTO" HeaderText="MEDIO DE CONTACTO" SortExpression="MEDIO_CONTACTO" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#CCFFCC" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>"
                                                SelectCommand="consultaMedioContacto" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                        Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td class="style3">
                                            &nbsp;
                                        </td>
                                        <td class="style4">
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
                    <asp:Panel ID="Panel9" runat="server" GroupingText="NEGOCIACIONES" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style5">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#006600"
                                                Text="AGREGAR"></asp:Label>
                                            <asp:Button ID="Button2" runat="server" OnClick="cmdMedio_Click" Text=" + " Width="50px" />
                                        </td>
                                        <td class="style3">
                                            &nbsp;
                                        </td>
                                        <td class="style4">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                Width="472px" AutoGenerateColumns="False" DataSourceID="dsMedioContacto">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="EDITAR">
                                                        <ItemTemplate>
                                                            <a href='MedioContacto.aspx?ID_PERSONA=<%#Eval("ID_PERSONA")%>&amp;&amp;op=Modificar&amp;ID_MEDIO_CONTACTO=<%#Eval("ID_MEDIO_CONTACTO")%>&amp;'>
                                                                <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png"
                                                                    Width="18px" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_MEDIO_CONTACTO" HeaderText="ID_MEDIO_CONTACTO" SortExpression="ID_MEDIO_CONTACTO"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" SortExpression="ID_PERSONA"
                                                        Visible="False" />
                                                    <asp:BoundField DataField="TIPO_MEDIO_CONTACTO" HeaderText="TIPO DE CONTACTO" SortExpression="TIPO_MEDIO_CONTACTO" />
                                                    <asp:BoundField DataField="MEDIO_CONTACTO" HeaderText="MEDIO DE CONTACTO" SortExpression="MEDIO_CONTACTO" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#CCFFCC" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>"
                                                SelectCommand="consultaMedioContacto" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                        Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td class="style3">
                                            &nbsp;
                                        </td>
                                        <td class="style4">
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
