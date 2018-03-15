<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PNLDonante.aspx.cs" Inherits="AtencionTemprana.PNLDonante" %>

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
                    <asp:Label ID="ID_DONANTE" runat="server" Font-Bold="True" Font-Size="Small" Visible="FALSE"
                        ForeColor="Black"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;
                </td>
                <td align="right" class="style6">
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="FALSE"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;
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
                <td>
                    &nbsp;
                </td>
                <td class="style2">
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" GroupingText="DATOS DEL DONANTE" Font-Bold="True"
                                Font-Size="Medium">
                                <table style="width: 100%;">
                                <tr>
                        <td colspan="3">
                        
                        
                            <asp:Label ID="Label101" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Black" Text="OFENDIDO"></asp:Label>
                        
                        
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
                                    &nbsp;</td>
                            </tr>
                                    <tr>
                                        <td colspan="4">
                                            
                                            <asp:Label ID="Label102" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="DATOS DEL DONANTE"></asp:Label>
                                            
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="APELLIDO PATERNO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="APELLIDO MATERNO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="NOMBRE(S)"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="PARENTESCO"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaterno" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMaterno" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombre" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlParentesco" runat="server" Width="200px" class="chosen-select">
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
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="SEXO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="IDENTIFICACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FOLIO DE IDENTIFICACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="NÚMERO TELÉFONO"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSexo" runat="server" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIdentificacion" runat="server" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFolioIdentificacion" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTelefono" runat="server" Style="text-transform: uppercase" Width="200px"></asp:TextBox>
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
                                        <td>
                                            &nbsp;
                                        </td>
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
                    &nbsp;
                    <asp:Panel ID="Panel6" runat="server" GroupingText="DOMICILIO DEL DONANTE" Font-Bold="True" Font-Size="Medium"
                        >
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
                                                Text="PAÍS"></asp:Label>
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
                                                TabIndex="8" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPais"
                                                Display="Dynamic" ErrorMessage="INGRESA PAÍS" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEntidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoDom_SelectedIndexChanged"
                                                TabIndex="14" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlEntidad"
                                                ErrorMessage="INGRESA ESTADO" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipioDom_SelectedIndexChanged"
                                                TabIndex="15" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlMunicipio"
                                                Display="Dynamic" ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadDom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidadDom_SelectedIndexChanged"
                                                TabIndex="16" Width="200px" class="chosen-select">
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
                                                TabIndex="17" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlColonia"
                                                Display="Dynamic" ErrorMessage="INGRESA COLONIA" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCalle" runat="server" Width="470px" TabIndex="18" class="chosen-select">
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
                                            <asp:DropDownList ID="ddlEntreCalle" runat="server" Width="470px" TabIndex="19" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlEntreCalle"
                                                Display="Dynamic" ErrorMessage="INGRESA ENTRE CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlYcalle" runat="server" Width="470px" TabIndex="20" class="chosen-select">
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
                                                Text="NÚMERO EXTERIOR"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label88" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="NÚMERO INTERIOR"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CP"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNumExt" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="21"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNumInt" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="22"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCP" runat="server" Width="190px" MaxLength="50" Style="text-transform: uppercase"
                                                TabIndex="23"></asp:TextBox>
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
                <td class="style2">
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
                    <asp:Panel ID="Panel2" runat="server" GroupingText="PERSONA QUE ASISTE AL DONANTE"
                        Font-Bold="True" Font-Size="Medium">
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
                                <td>
                                    &nbsp;
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
                                    <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="MENOR DE EDAD"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label43" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="NOMBRE(S) "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label44" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="APELLIDO PATERNO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="APELLIDO MATERNO "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbMenor" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombreTutor" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaternoTutor" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaternoTutor" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="PARENTESCO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="IDENTIFICACIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="FOLIO DE IDENTIFICACIÓN "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TRANSFUSIÓN"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlParentescoTutor" runat="server" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIdentificacionTutor" runat="server" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFolioIdentificacionTutor" runat="server" Width="200px" Style="text-transform: uppercase"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbTransfusion" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rbTransfusion"
                                        Display="Dynamic" ErrorMessage="SELECCIONA TRANSFUSION " ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TRANSPLANTE"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label51" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ENFERMEDAD INFECCIOSA"></asp:Label>
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
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbTransplante" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbEnfermedad" runat="server" Font-Bold="True" Font-Size="Small"
                                        ForeColor="Black" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">SI</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <br />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style2">
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
                <td class="style1">
                    <asp:Panel ID="Panel4" runat="server" GroupingText="DATOS DE RECOLECCIÓN" Font-Bold="True"
                        Font-Size="Medium" Width="1070px">
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
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label62" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="AUTORIDAD QUE SOLICITA LA TOMA DE MUESTRA "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label72" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="FECHA DE RECOLECCIÓN"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label81" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="HORA DE RECOLECCIÓN "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label79" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="LUGAR DE RECOLECCIÓN DE LOS INDICIOS "></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtAutoridadQueSolicitaTomaMuestra" runat="server" Style="text-transform: uppercase"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaMuestra" runat="server" Width="200px" MaxLength="10"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFechaMuestra_CalendarExtender" runat="server" Enabled="True"
                                        Format="dd/MM/yyyy" PopupButtonID="imgCal" TargetControlID="txtFechaMuestra">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaMuestra"
                                        Display="Dynamic" ErrorMessage="INGRESA FECHA MUESTRA" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHoraRecoleccion" runat="server"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                                        CultureName="es-ES" ErrorTooltipEnabled="true" InputDirection="RightToLeft" Mask="99:99:99"
                                        MaskType="Time" MessageValidatorTip="true" TargetControlID="txtHoraRecoleccion">
                                    </asp:MaskedEditExtender>
                                    <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1"
                                        ControlToValidate="txtHoraRecoleccion" ErrorMessage="*" InvalidValueMessage="REGISTRE HORA"
                                        ToolTip="ERROR FORMATO HORA" TooltipMessage="Hora 0:00:00am hasta 12:59:59pm"
                                        ForeColor="Red"></asp:MaskedEditValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLugarRecoleccionIndicios" runat="server" Style="text-transform: uppercase"
                                        Width="232px"></asp:TextBox>
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TIPO DE MUESTRA"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="Label80" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="CANTIDAD DE LA MUESTRA"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtTipoMuestra" runat="server" Height="75px" Style="text-transform: uppercase"
                                        TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:TextBox ID="txtCantidadDeMuestra" runat="server" Style="text-transform: uppercase"
                                        Width="200px"></asp:TextBox>
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
                        <br />
                    </asp:Panel>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp; &nbsp;
                    <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" 
                        OnClick="cmdGuardar_Click" Height="40px" Width="156px" class="button"  />
                    &nbsp;<asp:Button ID="cmdRegresar" runat="server" Text="REGRESAR" 
                        OnClick="cmdRegresar_Click" Height="40px" Width="156px" class="button" />
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style2">
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
                    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="951px">
                        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                    Text="DATOS DEL PERITO"></asp:Label>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="cmdMuestra" runat="server" Text="Agregar perito recolector" OnClick="cmdMuestra_Click" class="button" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <tr>
                                            <td colspan="2" style="font-weight: 700">
                                                <asp:GridView ID="gvDonante" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="4" DataKeyNames="IdColectorMuestra" DataSourceID="dsConsultaColector"
                                                    ForeColor="#333333" GridLines="None" Style="text-transform: uppercase" 
                                                    Width="930px">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <a href='PNLPeritoRecolector.aspx?IDCOLECTORMUESTRA=<%#Eval("IDCOLECTORMUESTRA")%>&amp;IdDonante=<%#Eval("IdDonante")%>&amp;op=Modificar&amp;'>
                                                                    <asp:Image ID="Image1" runat="server" Height="23px" ImageUrl="~/img/editar.png" Width="21px" /></a></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IdColectorMuestra" HeaderText="IdColectorMuestra" ReadOnly="True"
                                                            SortExpression="IdColectorMuestra" Visible="False" />
                                                        <asp:BoundField DataField="IdCarpeta" HeaderText="IdCarpeta" 
                                                            SortExpression="IdCarpeta" Visible="False" />
                                                        <asp:BoundField DataField="IdMunicipioCarpeta" HeaderText="IdMunicipioCarpeta" 
                                                            SortExpression="IdMunicipioCarpeta" Visible="False" />
                                                        <asp:BoundField DataField="IdPersona" HeaderText="IdPersona" 
                                                            SortExpression="IdPersona" Visible="False" />
                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                                        <asp:BoundField DataField="Paterno" HeaderText="APELLIDO PATERNO" 
                                                            SortExpression="Paterno" />
                                                        <asp:BoundField DataField="Materno" HeaderText="APELLIDO MATERNO" 
                                                            SortExpression="Materno" />
                                                        <asp:BoundField DataField="NumeroEmpleado" HeaderText="N° EMPLEADO" 
                                                            SortExpression="NumeroEmpleado" />
                                                        <asp:BoundField DataField="Institucion" HeaderText="INSTITUCIÓN" 
                                                            SortExpression="Institucion" />
                                                        <asp:BoundField DataField="IdMunicipio" HeaderText="IdMunicipio" 
                                                            SortExpression="IdMunicipio" Visible="False" />
                                                        <asp:BoundField DataField="Puesto" HeaderText="Puesto" SortExpression="Puesto" />
                                                        <asp:BoundField DataField="IdDonante" HeaderText="IdDonante" 
                                                            SortExpression="IdDonante" Visible="False" />
                                                        <asp:BoundField DataField="DptoPericial" HeaderText="DptoPericial" SortExpression="DptoPericial" />
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
                                                <asp:SqlDataSource ID="dsConsultaColector" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>"
                                                    SelectCommand="PNL_ConsultaColector" SelectCommandType="StoredProcedure">
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
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style2">
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
