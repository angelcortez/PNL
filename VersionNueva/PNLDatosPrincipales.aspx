<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PNLDatosPrincipales.aspx.cs" Inherits="AtencionTemprana.PNLDatosPrincipales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<%--<script type="text/javascript" src="/Scripts/jquery-1.8.2.min.js"></script>
<script type="text/javascript" src="/Scripts/jquery-ui.js"></script>
<script type="text/javascript" language="javascript" src="/Scripts/JQuery_Chosen/chosen.jquery.min.js"></script>
<script type="text/javascript" language="javascript" src="/Scripts/JQuery_TinyBox/tinybox.js"></script>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <script type="text/javascript">

        $(function () {
            PageInit_AlertOrNotification();
        });

        function PageInit_AlertOrNotification() {


            $(".chosen-select").chosen({
                allow_single_deselect: true,
                no_results_text: "No existe: ",
                width: "95%",
                placeholder_text_multiple: "Selecciona el elemento a agregar",
                multiple: true
            });


        }
             
    </script>--%>

    <%--class="chosen-select" pegado al ddl para que funcione--%>
    <style type="text/css">
        .style6
        {
            height: 19px;
        }
        .style7
        {
            height: 15px;
        }
        .style9
        {
            width: 344px;
        }
        .style11
        {
            width: 237px;
        }
        .style12
        {
            width: 266px;
        }
        .style14
        {
            width: 546px;
        }
        .style15
        {
            width: 541px;
        }
        .style16
        {
            width: 437px;
        }
        .style17
        {
            width: 325px;
        }
        .style21
        {
            width: 335px;
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
                    <asp:Label ID="ID_OTRA_INFO" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="ID_CAUSALES" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td align="right" class="style6">
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                    <asp:Label ID="ID_PERTENENCIA_SOCIAL" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                    <asp:Label ID="ID_INFO_FINANCIERA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="ID_DISCAPACIDADES" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="ID_INFO_ODONTOLOGICA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td align="right" class="style6">
                    <asp:Label ID="ID_DATOS_GENERALES" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel3" runat="server" GroupingText="DATOS COMPLEMENTARIOS DE LA PERSONA NO LOCALIZADA"
                        Font-Bold="True" Font-Size="Medium">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label101" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="PERSONA"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlOfendido" runat="server" Width="400px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label100" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="¿PERTENECE A ALGUNA ETNIA?"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="FECHA DE ULTIMO AVISTAMIENTO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ÚLTIMA ACTIVIDAD REGISTRADA"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlEtnia" runat="server" TabIndex="1" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUltimoAvistamiento" runat="server" MaxLength="30" Style="text-transform: uppercase"
                                        TabIndex="4" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUltimoAvistamiento"
                                        Display="Dynamic" ErrorMessage="INGRESA FECHA" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUltimaActividad" runat="server" TabIndex="3" Width="200px" class="chosen-select">
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
                            </tr>
                            <tr>
                                <td>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ErrorTooltipEnabled="True"
                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtUltimoAvistamiento" />
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
                <td colspan="4" align="center">
                    <asp:Label ID="lblTitulo" runat="server" Text="INFORMACIÓN PERSONAL DEL DESAPARECIDO"
                        Font-Size="Medium" Font-Bold="true" class="color-fuente"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1100px"
            UseVerticalStripPlacement="False" VerticalStripWidth="200px">
            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente"
                        Text="PERTENENCIA SOCIAL"></asp:Label></HeaderTemplate>
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td class="style27">
                                &nbsp;&nbsp;
                            </td>
                            <td class="style30">
                                &nbsp;&nbsp;
                            </td>
                            <td class="style33">
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style26">
                                <asp:Label ID="Label74" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="MIEMBRO DE ALGUNA ONG:"></asp:Label>
                            </td>
                            <td class="style29">
                                <asp:Label ID="Label76" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="SINDICALISTA:"></asp:Label>
                            </td>
                            <td class="style32">
                                <asp:Label ID="Label75" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="REINSERTADO:"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label77" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="GRUPO RELIGISOSO:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style34">
                                <asp:TextBox ID="txtONG" runat="server"></asp:TextBox>
                            </td>
                            <td class="style35">
                                <asp:TextBox ID="txtSindicalista" runat="server"></asp:TextBox>
                            </td>
                            <td class="style36">
                                <asp:TextBox ID="txtReinsertado" runat="server"></asp:TextBox>
                            </td>
                            <td class="style37">
                                <asp:TextBox ID="txtGrupoReligioso" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style27">
                                &nbsp;&nbsp;
                            </td>
                            <td class="style30">
                                &nbsp;&nbsp;
                            </td>
                            <td class="style33">
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style27">
                                <asp:Label ID="Label78" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="ORGANISMOS ESTATALES:"></asp:Label>
                            </td>
                            <td class="style30">
                                <asp:Label ID="Label79" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="GRUPO DERECHOS HUMANOS:"></asp:Label>
                            </td>
                            <td class="style33">
                                <asp:Label ID="Label80" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="OTROS:"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style27">
                                <asp:TextBox ID="txtOrgEstatal" runat="server"></asp:TextBox>
                            </td>
                            <td class="style30">
                                <asp:TextBox ID="txtDH" runat="server"></asp:TextBox>
                            </td>
                            <td class="style33">
                                <asp:TextBox ID="txtOtros" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="INFORMACION FINANCIERA">
                <HeaderTemplate>
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente"
                        Text="INFORMACIÓN FINANCIERA"></asp:Label></HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel7" runat="server" GroupingText="CUENTA BANCARIA" Font-Bold="True"
                        Font-Size="Small" ForeColor="Black">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style27">
                                    &#160;&#160;
                                </td>
                                <td class="style30">
                                    &#160;&nbsp;
                                </td>
                                <td class="style33">
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style39">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="BANCO:"></asp:Label>
                                </td>
                                <td class="style40">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="NÚMERO DE CUENTA"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TIPO DE CUENTA"></asp:Label>
                                </td>
                                <td class="style38">
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style34">
                                    <asp:DropDownList ID="ddlBanco" runat="server" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td class="style35">
                                    <asp:TextBox ID="txtNumCuenta" runat="server"></asp:TextBox><asp:FilteredTextBoxExtender
                                        ID="txtNumCuenta_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"
                                        TargetControlID="txtNumCuenta">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td class="style36">
                                    <asp:TextBox ID="txtTipoCuenta" runat="server"></asp:TextBox>
                                </td>
                                <td class="style37">
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    &#160;&nbsp;
                                </td>
                                <td class="style30">
                                    &#160;&nbsp;
                                </td>
                                <td class="style33">
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel8" runat="server" GroupingText="TARJETAS BANCARIAS" Font-Bold="True"
                        Font-Size="Small" ForeColor="Black">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style27">
                                    &#160;&#160;
                                </td>
                                <td class="style30">
                                    &#160;&nbsp;
                                </td>
                                <td class="style33">
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style26">
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TARJETA DE CREDITO (BANCO):"></asp:Label>
                                </td>
                                <td class="style29">
                                    <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="NÚMERO DE TARJETA DE CREDITO:"></asp:Label>
                                </td>
                                <td class="style32">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TARJETA DE DÉBITO (BANCO):"></asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="NÚMERO TARJETA DE DÉBITO:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style34">
                                    <asp:DropDownList ID="ddlBanco0" runat="server" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td class="style35">
                                    <asp:TextBox ID="txtNumTarjetaCredito" runat="server"></asp:TextBox><asp:FilteredTextBoxExtender
                                        ID="txtNumTarjetaCredito_FilteredTextBoxExtender" runat="server" Enabled="True"
                                        FilterType="Numbers" TargetControlID="txtNumTarjetaCredito">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td class="style36">
                                    <asp:DropDownList ID="ddlBanco1" runat="server" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td class="style37">
                                    <asp:TextBox ID="txtNumTarjetaDebito" runat="server"></asp:TextBox><asp:FilteredTextBoxExtender
                                        ID="txtNumTarjetaDebito_FilteredTextBoxExtender" runat="server" Enabled="True"
                                        FilterType="Numbers" TargetControlID="txtNumTarjetaDebito">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    &#160;&nbsp;
                                </td>
                                <td class="style30">
                                    &#160;&nbsp;
                                </td>
                                <td class="style33">
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    <asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TARJETA DEPARTAMENTAL:"></asp:Label>
                                </td>
                                <td class="style30">
                                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="NÚMERO DE TARJETA DEPARTMANETAL"></asp:Label>
                                </td>
                                <td class="style33">
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    <asp:TextBox ID="txtTarjetaDepartamental" runat="server"></asp:TextBox>
                                </td>
                                <td class="style30">
                                    <asp:TextBox ID="txtNumTarjetaDepartamental" runat="server"></asp:TextBox><asp:FilteredTextBoxExtender
                                        ID="txtNumTarjetaDepartamental_FilteredTextBoxExtender" runat="server" Enabled="True"
                                        FilterType="Numbers" TargetControlID="txtNumTarjetaDepartamental">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                                <td class="style33">
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    &#160;&nbsp;
                                </td>
                                <td class="style30">
                                    <br />
                                </td>
                                <td class="style33">
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <br />
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente"
                        Text="DISCAPACIDADES/PADECIMIENTOS"></asp:Label></HeaderTemplate>
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="DISCAPACIDAD MENTAL"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="OTRA DISCAPACIDAD MENTAL"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="DISCAPACIDAD FISICA"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="OTRA DISCAPACIDAD FISICA"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlDiscapacidadMental" runat="server" Width="200px" class="chosen-select">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDiscapacidadMental" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDiscapacidadFisica" runat="server" Width="200px" class="chosen-select">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDiscapacidadFisica" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style38">
                                <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="PADECIMIENTOS"></asp:Label>
                            </td>
                            <td class="style38">
                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="ENFERMEDADES SISTEMATICAS"></asp:Label>
                            </td>
                            <td class="style38">
                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="ENFERMEDADES MENTALES"></asp:Label>
                            </td>
                            <td class="style38">
                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="ENFERMEDADES DE LA PIEL"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style37">
                                <asp:TextBox ID="txtPadecimientos" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style37">
                                <asp:TextBox ID="txtSistematicas" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style37">
                                <asp:TextBox ID="txtEnfermedadMental" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="style37">
                                <asp:TextBox ID="txtEnfermedadPiel" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="ADICCIONES"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="MEDICAMENTOS HABITUALES"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="CIRUGIAS"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtAdicciones" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMedicamentos" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCirugias" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="EMBARAZO"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="CESÁREA"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="PARTO NATURAL"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="ABORTO"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rbEmbarazo" runat="server" Font-Bold="True" Font-Size="Small"
                                    ForeColor="Black" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">SI</asp:ListItem>
                                    <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:CheckBox ID="chCesarea" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chPartoNatural" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chAborto" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="CONTROL NATAL"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="OTRO CONTROL NATAL" Visible="False"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rbControlNatal" runat="server" Font-Bold="True" Font-Size="Small"
                                    ForeColor="Black" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbControlNatal_SelectedIndexChanged">
                                    <asp:ListItem Value="1">DIU</asp:ListItem>
                                    <asp:ListItem Value="2">VASECTOMÍA</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">NINGUNO</asp:ListItem>
                                    <asp:ListItem Value="4">OTRO</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOtroControlNatal" runat="server" Width="200px" Visible="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente"
                        Text="INFO. ODONTOLÓGICA"></asp:Label></HeaderTemplate>
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td class="style15">
                                <asp:Label ID="Label32" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="CUENTA CON EXPEDIENTE DENTAL?"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="ODONTOLOGO"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <asp:RadioButtonList ID="rbExpedienteDental" runat="server" Font-Bold="True" Font-Size="Small"
                                    ForeColor="Black" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">SI</asp:ListItem>
                                    <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOdontologo" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel4" runat="server" GroupingText="DIENTES" Font-Bold="True" Font-Size="Small"
                        ForeColor="Black">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style17">
                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TAMAÑO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="COMPLETOS"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="SEPARADOS"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="GIRADOS"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    <asp:DropDownList ID="ddlTamDientes" runat="server" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbCompletos" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbSeparados" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbGirados" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    <asp:Label ID="Label41" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="APIÑONADOS"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="MANCHADOS"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="CON DESGASTE"></asp:Label>
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    <asp:RadioButtonList ID="rbApinonados" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbManchados" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbDesgaste" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel11" runat="server" GroupingText="TRATAMIENTOS DENTALES" Font-Bold="True"
                        Font-Size="Small" ForeColor="Black">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label44" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="RESINAS"></asp:Label>
                                </td>
                                <td class="style11">
                                    <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="AMALGAMAS"></asp:Label>
                                </td>
                                <td class="style12">
                                    <asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="CORONAS METÁLICAS"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="CORONAS ESTÉTICAS"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:RadioButtonList ID="rbResinas" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="style11">
                                    <asp:RadioButtonList ID="rbAmalgamas" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="style12">
                                    <asp:RadioButtonList ID="rbCoronasMetalicas" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbCoronasEsteticas" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ENDODONCIA"></asp:Label>
                                </td>
                                <td class="style11">
                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="BLANQUEAMIENTO"></asp:Label>
                                </td>
                                <td class="style12">
                                    <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="INCRUSTACIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label51" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="OTRO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:RadioButtonList ID="rbEndodoncia" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="style11">
                                    <asp:RadioButtonList ID="rbBlanqueamiento" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="style12">
                                    <asp:RadioButtonList ID="rbIncrustacion" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOtro" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    <asp:Panel ID="Panel12" runat="server" GroupingText="PRÓTESIS O ADITAMENTOS" Font-Bold="True"
                        Font-Size="Small" ForeColor="Black">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style21">
                                    <asp:Label ID="Label52" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="PRÓTESIS"></asp:Label>
                                </td>
                                <td class="style16">
                                    <asp:Label ID="Label53" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="BRAQUETS"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label54" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="RETENEDORES"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label55" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="IMPLANTES"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style21">
                                    <asp:DropDownList ID="ddlProtesis" runat="server" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td class="style16">
                                    <asp:RadioButtonList ID="rbBraquets" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbRetenedores" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbImplantes" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style21">
                                    <asp:Label ID="Label56" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="Otro Aditamento"></asp:Label>
                                </td>
                                <td class="style16">
                                    <asp:Label ID="Label57" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="¿LO LLEVABA PUESTO AL MOMENTO DE LA DESAPARICIÓN?"></asp:Label>
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style21">
                                    <asp:TextBox ID="txtAditamento" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td class="style16">
                                    <asp:RadioButtonList ID="rbPuesto" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%;">
                            <tr>
                                <td class="style14">
                                    <asp:Label ID="Label58" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="AUSENCIAS DENTALES"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label59" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="HÁBITOS DENTALES"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    <asp:TextBox ID="txtAusenciasDentales" runat="server" Width="300px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHabitosDentales" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel10">
                <HeaderTemplate>
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente"
                        Text="OTROS"></asp:Label></HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel9" runat="server" GroupingText="ANTES DE LA DESAPARICION EXISTIO"
                        Font-Bold="True" Font-Size="Small" ForeColor="Black">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style27">
                                    <asp:CheckBox ID="chbDetencion" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="DETENCIÓN" />
                                </td>
                                <td class="style30">
                                    <asp:CheckBox ID="chbAllamiento" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="ALLANAMIENTO" />
                                </td>
                                <td class="style33">
                                    <asp:CheckBox ID="chbHostigamiento" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="HOSTIGAMIENTO" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chbAmenazas" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="AMENAZAS" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style39">
                                    <asp:CheckBox ID="chbLesiones" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="LESIONES" />
                                </td>
                                <td class="style40">
                                    <asp:CheckBox ID="chbDisposicionDinero" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="DISPOSICIÓN DE DINERO EN EFECTIVO" />
                                </td>
                                <td class="style41">
                                    <asp:CheckBox ID="chbProblemasVecinales" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="PROBLEMAS VECINALES" />
                                </td>
                                <td class="style38">
                                    <asp:CheckBox ID="chbProblemasFamiliares" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="PROBLEMAS FAMILIARES" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style34">
                                    <asp:CheckBox ID="chbActitudNerviosa" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="ACTITUD NERVIOSA" />
                                </td>
                                <td class="style35">
                                    <asp:CheckBox ID="chbMovimientosCB" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="MOVIMIENTOS EN CUENTAS BANCARIAS" />
                                </td>
                                <td class="style36">
                                    <asp:CheckBox ID="chbDesaparecido" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="COMUNICACIÓN CON EL DESAPARECIDO" />
                                </td>
                                <td class="style37">
                                    <asp:CheckBox ID="chbCaptores" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="COMUNICACIÓN CON SUS CAPTORES" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    <asp:CheckBox ID="chbSolicitud" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="SOLCICITUD PARA DEJARLO EN LIBERTAD" />
                                </td>
                                <td class="style30">
                                    <asp:CheckBox ID="chbInternet" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="COMUNICACIÓN POR INTERNET" />
                                </td>
                                <td class="style33">
                                    <asp:CheckBox ID="chbParadero" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" Text="INFORMACIÓN DE SU PARADERO" />
                                </td>
                                <td>
                                    &#160;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
                    &nbsp;</ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
        <table style="width: 100%;">
            <tr>
                <td colspan="4" align="center">
                   <asp:Label ID="lbltrue" Visible="false" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Label ID="Label102" runat="server" Text="Label" Visible="false"></asp:Label>
                    <asp:Label ID="lblTitulo0" runat="server" Text="CAUSALES DE DESAPARICIÓN" Font-Size="Medium"
                        Font-Bold="true" class="color-fuente"></asp:Label>
                </td>
            </tr>
            <tr align="left">
                <td colspan="4">
                    <asp:Panel runat="server" GroupingText="SELECCIONE LOS CAMPOS CORRESPONDIENTES" Font-Bold="True"
                        Font-Size="Small" ID="Panel17">
                        <table style="width: 100%;">
                            <!--<tr>
                                <td class="style27">
                                    <asp:CheckBox runat="server" Text="POR SU PROPIA VOLUNTAD" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" ID="chbPropiaVoluntad"></asp:CheckBox>
                                </td>
                                <td class="style30">
                                    <asp:CheckBox runat="server" Text="SUSTRACCIÓN DE MENORES" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" ID="chbSustraccionMenores"></asp:CheckBox>
                                </td>
                                <td class="style33">
                                    <asp:CheckBox runat="server" Text="SALUD" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        ID="chbSalud"></asp:CheckBox>
                                </td>
                                <td>

                                    <asp:CheckBox ID="chbProblemasFamiliaresCausales" runat="server" 
                                        Font-Bold="True" Font-Size="Small" ForeColor="Black" 
                                        Text="PROBLEMAS FAMILIARES" />

                                </td>
                            </tr>
                            <tr>
                                <td class="style39">
                                    <asp:CheckBox runat="server" Text="MIGRACIÓN" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" ID="chbMigracion"></asp:CheckBox>
                                </td>
                                <td class="style40">
                                    <asp:CheckBox runat="server" Text="POR LA COMISION DE UN DELITO" Font-Bold="True"
                                        Font-Size="Small" ForeColor="Black" ID="chbComisionDelito"></asp:CheckBox>
                                </td>
                                <td class="style41">
                                    <asp:CheckBox runat="server" Text="PRIVACIÓN ILEGAL DE LA LIBERTAD (LEVANTÓN)" Font-Bold="True"
                                        Font-Size="Small" ForeColor="Black" ID="chbLevantons" 
                                        AutoPostBack="True" oncheckedchanged="chbLevantons_CheckedChanged"></asp:CheckBox>
                                </td>
                                <td class="style38">

                                    <asp:CheckBox ID="chbAdicciones" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="ADICCIONES" />

                                </td>
                            </tr>
                            <tr>
                                <td class="style34">
                                    <asp:CheckBox runat="server" Text="VÍCTIMA DE DELITO" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" ID="chbVictimaDelito"></asp:CheckBox>
                                </td>
                                <td class="style35">
                                    <asp:CheckBox runat="server" Text="ACCIDENTES" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" ID="chbAccidentes"></asp:CheckBox>
                                </td>
                                <td class="style36">
                                <asp:Label ID="lblTipo" runat="server" Font-Bold="True"
                                 Font-Size="Small" ForeColor="Black"
                                   Text="PRIVACIÓN POR:" Visible=false>
                                   </asp:Label>                           
                                    <asp:DropDownList ID="ddlTipo" runat="server"  Width="300px" Visible=false>
                                    </asp:DropDownList>

                                </td>
                                <td class="style37">

                                    <asp:CheckBox ID="chbDetenido" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" 
                                        Text="DETENIDO (PERSONAS NO LOCALIZADAS RELACIONADAS CON ALGÚN ACTO ILÍCITO)" />

                                </td>
                            </tr>
                            <tr>
                                <td class="style27">
                                    <asp:CheckBox runat="server" Text="MOTIVOS LABORALES" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" ID="chbMotivosLaborales"></asp:CheckBox>
                                </td>
                                <td class="style30">
                                    &nbsp;
                                    <asp:CheckBox ID="chbDesparicion" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="DESAPARICIÓN FORZADA" />
                                </td>
                                <td class="style33">
                                    &nbsp; &nbsp;
                                    <asp:CheckBox ID="chbSeDesconoce" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="SE DESCONOCE" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chbRelacionesPersonales" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="RELACIONES PERSONALES" />
                                </td>
                            </tr>-->
                            <tr>
                            <td class="style27">
                                <asp:RadioButton GroupName="causalesGroup" ID="rbPropiaVoluntad" runat="server" 
                                Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                Text="POR SU PRPIA VOLUNTAD" />                                
                            </td>
                            <td class="style30"> 
                                <asp:RadioButton  GroupName="causalesGroup" ID="rbSustraccionMenores" runat="server"
                                Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                Text="SUSTRACION DE MENORES" />
                            </td>
                            <td class="style33">
                                <asp:RadioButton GroupName="causalesGroup"  ID="rbSalud" runat="server" 
                                Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                Text="SALUD" />
                            </td>
                            <td>
                                <asp:RadioButton GroupName="causalesGroup" ID="rbProblemasFamiliares" runat="server" 
                                Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                Text="PROBLEMAS FAMILIARES" />
                            </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbMigracion" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="MIGRACION" />
                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbComisionDelito" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="POR LA COMISION DE UN DELITO" />
                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbLevanton" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"     
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"                                                                
                                    Text="PRIVACION ILEGAL DE LA LIBERTAD (LEVANTON)" />
                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbAddicciones" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="ADICCIONES" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbVictimaDelito" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="VICTIMA DE DELITO" />
                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbAccidentes" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="ACCIDENTES" />
                                </td>
                                <td class="style36">

                                    <asp:Label ID="rb_lblTipo" runat="server"
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"                                    
                                    Text="PRIVACIÓN POR:" Visible="false">
                                    </asp:Label>
                           
                                    <asp:DropDownList ID="rb_ddlTipo" runat="server"  Width="300px" Visible="false">
                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbDetenido" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="DETENIDO (PERSONAS NO LOCALIZADAS RELACIONADAS CON ALGUN ACTO ILICITO)" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbMotivosLaborales" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="MOTIVOS LABORALES" />
                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbDesaparicionForzada" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="DESAPARICION FORZADA" />
                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbSeDesconoce" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="SE DESCONOCE" />
                                </td>
                                <td>
                                    <asp:RadioButton GroupName="causalesGroup" ID="rbRelacionesPersonales" runat="server" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    AutoPostBack="True" oncheckedchanged="_CheckedChanged"
                                    Text="RELACIONES PERSONALES" />
                                </td>
                            </tr>



                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr align="center">
                <td colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <td colspan="4">
                    <asp:Button ID="btnGuardarDatos"  runat="server" Text="GUARDAR DATOS" OnClick= "btnGuardarDatos_Click" 
                        Height="40px" Width="156px" class="button" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel16" runat="server" GroupingText="MEDIA FILIACIÓN" Font-Bold="True"
                        Font-Size="Medium">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btnMediaFiliacion" runat="server" Text="AGREGAR MEDIA FILIACIÓN"
                                        Visible="false" OnClick="btnMediaFiliacion_Click" class="button" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataSourceID="dsMediaF" ForeColor="#333333" GridLines="None"
                                        Style="text-transform: uppercase" Width="930px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href='PNLMediaFiliacion.aspx?IDMEDIAFILIACION=<%#Eval("IDMEDIAFILIACIONPNL")%>&amp;op=Modificar&amp;'>
                                                        <asp:Image ID="Image1" runat="server" Height="23px" ImageUrl="~/img/editar.png" Width="21px" /></a></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdMediaFiliacionPNL" HeaderText="IdMediaFiliacionPNL"
                                                ReadOnly="True" SortExpression="IdMediaFiliacionPNL" InsertVisible="False" Visible="False" />
                                            <asp:BoundField DataField="COMPLEXION" HeaderText="COMPLEXIÓN" SortExpression="COMPLEXION" />
                                            <asp:BoundField DataField="CARA" HeaderText="CARA" SortExpression="CARA" />
                                            <asp:BoundField DataField="ColorPiel" HeaderText="COLOR DE PIEL" SortExpression="ColorPiel" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsMediaF" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>"
                                        SelectCommand="PNL_MediaFiliacionGrid" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_CARPETA" Name="IdCarpeta" PropertyName="Text"
                                                Type="Int32" />
                                            <asp:ControlParameter ControlID="ID_MUNICIPIO_CARPETA" Name="IdMunicipioCarpeta"
                                                PropertyName="Text" Type="Int16" />
                                            <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="SEÑAS PARTICULARES" Font-Bold="True"
                        Font-Size="Medium">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btnSeniasParticulares" runat="server" Text="AGREGAR SEÑAS PARTICULARES"
                                        Visible="false" OnClick="btnSeniasParticulares_Click" class="button" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataSourceID="dsSenias" ForeColor="#333333" GridLines="None"
                                        Style="text-transform: uppercase" Width="930px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href='PNLSeniasParticulares.aspx?ID_SENIA=<%#Eval("IDSENAPARTICULARPNL")%>&amp;op=Modificar&amp;'>
                                                        <asp:Image ID="Image1" runat="server" Height="23px" ImageUrl="~/img/editar.png" Width="21px" /></a></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdSenaParticularPNL" HeaderText="IdSenaParticularPNL"
                                                ReadOnly="True" SortExpression="IdSenaParticularPNL" InsertVisible="False" Visible="False" />
                                            <asp:BoundField DataField="TIPO_SEÑA" HeaderText="TIPO DE SEÑA" SortExpression="TIPO_SEÑA" />
                                            <asp:BoundField DataField="DES_SEÑA" HeaderText="SEÑA" SortExpression="DES_SEÑA" />
                                            <asp:BoundField DataField="VISTA" HeaderText="VISTA" SortExpression="VISTA" />
                                            <asp:BoundField DataField="LADO" HeaderText="LADO" SortExpression="LADO" />
                                            <asp:BoundField DataField="REGION" HeaderText="REGION" SortExpression="REGION" />
                                            <asp:BoundField DataField="CANT_REGION" HeaderText="CANT_REGION" SortExpression="CANT_REGION"
                                                Visible="False" />
                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCIÓN" SortExpression="DESCRIPCION" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsSenias" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>"
                                        SelectCommand="PNL_SeñasParticularesGrid" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_CARPETA" Name="IdCarpeta" PropertyName="Text"
                                                Type="Int32" />
                                            <asp:ControlParameter ControlID="ID_MUNICIPIO_CARPETA" Name="IdMunicipioCarpeta"
                                                PropertyName="Text" Type="Int16" />
                                            <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel13" runat="server" GroupingText="DONANTE Y PERITO RECOLECTOR"
                        Font-Bold="True" Font-Size="Medium">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btnAgregarDonante" runat="server" Visible="false" Text="AGREGAR DONANTE"
                                        OnClick="btnAgregarDonante_Click" class="button" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gvDonante" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="IdDonante" DataSourceID="dsDonantes" ForeColor="#333333"
                                        GridLines="None" Style="text-transform: uppercase" Width="930px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href='PNLDonante.aspx?ID_DONANTE=<%#Eval("IDDONANTE")%>&amp;op=Modificar&amp;'>
                                                        <asp:Image ID="Image1" runat="server" Height="23px" ImageUrl="~/img/editar.png" Width="21px" /></a></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdDonante" HeaderText="IdDonante" ReadOnly="True" SortExpression="IdDonante"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdCarpeta" HeaderText="IdCarpeta" SortExpression="IdCarpeta"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdMunicipioCarpeta" HeaderText="IdMunicipioCarpeta" SortExpression="IdMunicipioCarpeta"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" SortExpression="IdPersona"
                                                Visible="False" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                            <asp:BoundField DataField="Paterno" HeaderText="APELLIDO PATERNO" SortExpression="Paterno" />
                                            <asp:BoundField DataField="Materno" HeaderText="APELLIDO MATERNO" SortExpression="Materno" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsDonantes" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>"
                                        SelectCommand="PNL_ConsultaDonante" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_CARPETA" Name="IdCarpeta" PropertyName="Text"
                                                Type="Int32" />
                                            <asp:ControlParameter ControlID="ID_MUNICIPIO_CARPETA" DefaultValue="" Name="IdMunicipioCarpeta"
                                                PropertyName="Text" Type="Int16" />
                                            <asp:ControlParameter ControlID="ID_PERSONA" DefaultValue="" Name="IdPersona" PropertyName="Text"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel14" runat="server" GroupingText="FOTOGRAFÍA" Font-Bold="True"
                        Font-Size="Medium">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btnAgregarFotografia" runat="server" Visible="false" Text="AGREGAR FOTOGRAFÍA"
                                        OnClick="btnAgregarFotografia_Click" class="button" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gridFoto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="IdFotografia" DataSourceID="dsFoto" ForeColor="#333333"
                                        GridLines="None" Style="text-transform: uppercase" Width="930px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href='PNLFotografia.aspx?IDFOTOGRAFIA=<%#Eval("IDFOTOGRAFIA")%>&amp;op=Modificar&amp&IdP=<%#Eval("IdPersona")%>;'>
                                                        <asp:Image ID="Image1" runat="server" Height="23px" ImageUrl="~/img/editar.png" Width="21px" /></a></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdFotografia" HeaderText="IdFotografia" ReadOnly="True"
                                                SortExpression="IdFotografia" Visible="False" />
                                            <asp:BoundField DataField="IdCarpeta" HeaderText="IdCarpeta" SortExpression="IdCarpeta"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdMunicipioCarpeta" HeaderText="IdMunicipioCarpeta" SortExpression="IdMunicipioCarpeta"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" SortExpression="IdPersona"
                                                Visible="False" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN" SortExpression="Descripcion" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsFoto" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>"
                                        SelectCommand="PNL_ConsultaFotoGrid" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_CARPETA" Name="IdCarpeta" PropertyName="Text"
                                                Type="Int32" />
                                            <asp:ControlParameter ControlID="ID_MUNICIPIO_CARPETA" Name="IdMunicipioCarpeta"
                                                PropertyName="Text" Type="Int16" />
                                            <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel18" runat="server" GroupingText="VESTIMENTA" Font-Bold="True"
                        Font-Size="Medium">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:DropDownList ID="ddlVestimenta" runat="server" TabIndex="3" Width="200px">
                                    </asp:DropDownList>
                                    &nbsp;<asp:TextBox ID="txtDescVestimenta" runat="server" Width="400"></asp:TextBox>
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnagregarVestimenta" runat="server" Visible="false" Text="AGREGAR"
                                        OnClick="btnagregarVestimenta_Click" class="button" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gvVestimenta" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataSourceID="dsConsultaVestimenta" ForeColor="#333333" GridLines="None"
                                        Style="text-transform: uppercase" Width="930px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="VSTUARIO" HeaderText="VESTIMENTA" SortExpression="VSTUARIO" />
                                            <asp:BoundField DataField="DescripcionVestimenta" HeaderText="DESCRIPCIÓN" SortExpression="DescripcionVestimenta" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsConsultaVestimenta" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>"
                                        SelectCommand="PNL_ConsultaVestimentaGrid" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_CARPETA" Name="IdCarpeta" PropertyName="Text"
                                                Type="Int32" />
                                            <asp:ControlParameter ControlID="ID_MUNICIPIO_CARPETA" Name="IdMunicipioCarpeta"
                                                PropertyName="Text" Type="Int16" />
                                            <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel15" runat="server" GroupingText="DATOS DE LOCALIZACIÓN" Font-Bold="True"
                        Font-Size="Medium">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btnLocalizacion" runat="server" Visible="false" Text="AGREGAR DATOS"
                                        OnClick="btnLocalizacion_Click" class="button" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="gvDonante0" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="IdLocalizado" DataSourceID="dsLocalizacion" ForeColor="#333333"
                                        GridLines="None" Style="text-transform: uppercase" Width="930px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href='PNLLocalizacion.aspx?IDLOCALIZADO=<%#Eval("IDLOCALIZADO")%>&amp;op=Modificar&amp;'>
                                                        <asp:Image ID="Image1" runat="server" Height="23px" ImageUrl="~/img/editar.png" Width="21px" /></a></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdLocalizado" HeaderText="IdLocalizado" ReadOnly="True"
                                                SortExpression="IdLocalizado" Visible="False" />
                                            <asp:BoundField DataField="IdCarpeta" HeaderText="IdCarpeta" SortExpression="IdCarpeta"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdMunicipioCarpeta" HeaderText="IdMunicipioCarpeta" SortExpression="IdMunicipioCarpeta"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" SortExpression="IdPersona"
                                                Visible="False" />
                                            <asp:CheckBoxField DataField="EstatusPersona" HeaderText="EstatusPersona" SortExpression="EstatusPersona"
                                                Visible="False" />
                                            <asp:BoundField DataField="FechaLocalizacion" HeaderText="Fecha Localización" 
                                                SortExpression="FechaLocalizacion" />
                                            <asp:BoundField DataField="HoraLocalizacion" HeaderText="Hora Localización" 
                                                SortExpression="HoraLocalizacion" />
                                            <asp:BoundField DataField="PosibleCausaDesaparicion" HeaderText="Posible Causa Desaparición"
                                                SortExpression="PosibleCausaDesaparicion" />
                                            <asp:BoundField DataField="IdCondicionLocalizacion" HeaderText="IdCondicionLocalizacion"
                                                SortExpression="IdCondicionLocalizacion" Visible="False" />
                                            <asp:BoundField DataField="IdLugarHallazgo" HeaderText="IdLugarHallazgo" SortExpression="IdLugarHallazgo"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdPais" HeaderText="IdPais" SortExpression="IdPais" Visible="False" />
                                            <asp:BoundField DataField="IdEntidad" HeaderText="IdEntidad" SortExpression="IdEntidad"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdMunicipio" HeaderText="IdMunicipio" SortExpression="IdMunicipio"
                                                Visible="False" />
                                            <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad"
                                                Visible="False" />
                                            <asp:BoundField DataField="Colonia" HeaderText="Colonia" SortExpression="Colonia"
                                                Visible="False" />
                                            <asp:BoundField DataField="Calle" HeaderText="Calle" SortExpression="Calle" Visible="False" />
                                            <asp:BoundField DataField="EntreCalle1" HeaderText="EntreCalle1" SortExpression="EntreCalle1"
                                                Visible="False" />
                                            <asp:BoundField DataField="EntreCalle2" HeaderText="EntreCalle2" SortExpression="EntreCalle2"
                                                Visible="False" />
                                            <asp:BoundField DataField="NumeroExterior" HeaderText="NumeroExterior" SortExpression="NumeroExterior"
                                                Visible="False" />
                                            <asp:BoundField DataField="NumeroInterior" HeaderText="NumeroInterior" SortExpression="NumeroInterior"
                                                Visible="False" />
                                            <asp:BoundField DataField="CP" HeaderText="CP" SortExpression="CP" Visible="False" />
                                            <asp:BoundField DataField="FechaIngreso" HeaderText="FechaIngreso" SortExpression="FechaIngreso"
                                                Visible="False" />
                                            <asp:BoundField DataField="HoraIngreso" HeaderText="HoraIngreso" SortExpression="HoraIngreso"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdCausasFallecimiento" HeaderText="IdCausasFallecimiento"
                                                SortExpression="IdCausasFallecimiento" Visible="False" />
                                            <asp:BoundField DataField="IdentificacionCadaver" HeaderText="IdentificacionCadaver"
                                                SortExpression="IdentificacionCadaver" Visible="False" />
                                            <asp:BoundField DataField="FechaEntregaCuerpo" HeaderText="FechaEntregaCuerpo" SortExpression="FechaEntregaCuerpo"
                                                Visible="False" />
                                            <asp:BoundField DataField="FechaProbableFallecimiento" HeaderText="FechaProbableFallecimiento"
                                                SortExpression="FechaProbableFallecimiento" Visible="False" />
                                            <asp:BoundField DataField="EnteLocaliza" HeaderText="EnteLocaliza" SortExpression="EnteLocaliza"
                                                Visible="False" />
                                            <asp:BoundField DataField="NombreEnte" HeaderText="NombreEnte" SortExpression="NombreEnte"
                                                Visible="False" />
                                            <asp:BoundField DataField="PaternoEnte" HeaderText="PaternoEnte" SortExpression="PaternoEnte"
                                                Visible="False" />
                                            <asp:BoundField DataField="MaternoEnte" HeaderText="MaternoEnte" SortExpression="MaternoEnte"
                                                Visible="False" />
                                            <asp:BoundField DataField="Institucion" HeaderText="Institucion" SortExpression="Institucion"
                                                Visible="False" />
                                            <asp:BoundField DataField="Autoridad" HeaderText="Autoridad" SortExpression="Autoridad"
                                                Visible="False" />
                                            <asp:BoundField DataField="NombreAutoridad" HeaderText="NombreAutoridad" SortExpression="NombreAutoridad"
                                                Visible="False" />
                                            <asp:BoundField DataField="PaternoAutoridad" HeaderText="PaternoAutoridad" SortExpression="PaternoAutoridad"
                                                Visible="False" />
                                            <asp:BoundField DataField="MaternoAutoridad" HeaderText="MaternoAutoridad" SortExpression="MaternoAutoridad"
                                                Visible="False" />
                                            <asp:BoundField DataField="NombreReclama" HeaderText="NombreReclama" SortExpression="NombreReclama"
                                                Visible="False" />
                                            <asp:BoundField DataField="PaternoReclama" HeaderText="PaternoReclama" SortExpression="PaternoReclama"
                                                Visible="False" />
                                            <asp:BoundField DataField="MaternoReclama" HeaderText="MaternoReclama" SortExpression="MaternoReclama"
                                                Visible="False" />
                                            <asp:BoundField DataField="IdParentescoReclama" HeaderText="IdParentescoReclama"
                                                SortExpression="IdParentescoReclama" Visible="False" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                            HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsLocalizacion" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>"
                                        SelectCommand="PNL_ConsultaLocalizacionGrid" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_CARPETA" Name="IdCarpeta" PropertyName="Text"
                                                Type="Int32" />
                                            <asp:ControlParameter ControlID="ID_MUNICIPIO_CARPETA" Name="IdMunicipioCarpeta"
                                                PropertyName="Text" Type="Int16" />
                                            <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" PropertyName="Text"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
            <td>
            
            </td>
            </tr>
            <tr>
            <td>
            </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="btnRegresar" runat="server" Text="REGRESAR" Visible="TRUE" OnClick="btnRegresar_Click" class="button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
