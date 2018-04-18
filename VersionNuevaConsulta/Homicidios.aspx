<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Homicidios.aspx.cs" Inherits="AtencionTemprana.Homicidios" %>

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
        .style10
        {
            height: 15px;
            width: 87px;
        }
        .style11
        {
            width: 87px;
        }
        .style12
        {
            height: 23px;
        }
        .style13
        {
            width: 378px;
        }
        .style14
        {
            width: 300px;
        }
        .style16
        {
            width: 258px;
        }
    </style>
    <style>
        .hidden
        {
            display: none;
        }
        .margen
        {
            margin: 5px;
        }
        
        #myDIV
        {
            border: 1px solid black;
            margin-bottom: 10px;
        }
        
        #myDIVEHICULOS
        {
            border: 1px solid black;
            margin-bottom: 10px;
        }
        
        .style17
        {
            width: 506px;
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
       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <Triggers>
                <asp:PostBackTrigger ControlID="cmdNuevoHomicidio" />
               
                <asp:PostBackTrigger ControlID="ddlCuerpoEntegado" />
                <asp:PostBackTrigger ControlID="cmdGuardar" />
                <asp:PostBackTrigger ControlID="ImgMsjSI" />
                <asp:PostBackTrigger ControlID="ImgMsjNO" />
                <asp:PostBackTrigger ControlID="CmdMensaje" />
                <asp:PostBackTrigger ControlID="ImgSi1" />
                <asp:PostBackTrigger ControlID="ImgNo1" />
                <asp:PostBackTrigger ControlID="ddlTipoArma" />
                <asp:PostBackTrigger ControlID="btnAgregarArma" />
                <asp:PostBackTrigger ControlID="cmdNuevoReg" />
                <asp:PostBackTrigger ControlID="cmdSiguiente" />

                

    </Triggers>
    <ContentTemplate>
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
                    <asp:Label ID="IdUsuario" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"
                        Visible="false"></asp:Label>
                    <asp:Label ID="IdDetencion" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"
                        Visible="true"></asp:Label>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                     <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
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
                </td>
                <td align="right" class="style6">
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" class="color-fuente" Text="HOMICIDIOS"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style10">
                    <asp:Label ID="ID_PERSONA_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_HOMICIDIO" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:Label ID="ID_ARMA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="ID_LUGAR_HECHOS" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="ID_LUGAR_FALLECIMIENTO" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;<asp:Panel ID="PanelModificarHomicidio" runat="server" Visible="false" GroupingText="MODIFICAR HOMICIDIO"
                        Font-Bold="True" Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    
                                   
                                    <tr>
                                        <td class="style17">
                                           
                                            &nbsp;</td>
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
                                        <td class="style17">
                                           
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                                                ID="cmdNuevoHomicidio" runat="server" Font-Bold="True" Height="40px" 
                                                 TabIndex="48" Text="NUEVO HOMICIDIO" 
                                                Width="156px" onclick="cmdNuevoHomicidio_Click" />
                                           
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
                                            <asp:GridView ID="gvModificarHomicidio" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                                                CellPadding="4" DataSourceID="dsModificarHomicidio" ForeColor="#333333" 
                                                GridLines="None" DataKeyNames="ID_HOMICIDIO"
                                                Width="928px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="ID_HOMICIDIO" HeaderText="ID_HOMICIDIO" SortExpression="ID_HOMICIDIO"
                                                        Visible="true" InsertVisible="False" ReadOnly="True">
                                                        <ItemStyle CssClass="hidden" />
                                                        <HeaderStyle CssClass="hidden" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OFENDIDO" HeaderText="OFENDIDO" SortExpression="OFENDIDO" />
                                                   
                                                   
                                                    <asp:TemplateField HeaderText="MODIFICAR">
                                                         <ItemTemplate>
                                                             <asp:Button ID="ModificareButton" runat="server" Text="Modificar"  OnCommand="ModificareButton_Command"
                                                                  CommandArgument='<%# Eval("ID_HOMICIDIO") %>' />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                    
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
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="style17">
                                            <asp:SqlDataSource ID="dsModificarHomicidio" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>"
                                                SelectCommand="Modificar_Homicidio" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="IdCarpeta" Name="ID_CARPETA" PropertyName="Text"
                                                        Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="style17">
                                           
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
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="DATOS DEL HOMICIDIO" Font-Bold="True"
                        Font-Size="Medium" >
                        <table style="width: 100%;">
                            <tr>
                               
                                <td class="style13">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="TIPO DELITO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label348" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="MODALIDAD"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;<asp:Label ID="Label347" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="SITUACIÓN"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    <asp:DropDownList ID="ddlSubDelito" runat="server" TabIndex="1" Width="200px" class="chosen-select"> 
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="ddlSubDelito" Display="Dynamic" 
                                ErrorMessage="SELECCIONE TIPO DELITO" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSubModalidad" runat="server" TabIndex="2" class="chosen-select"
                                        Width="200px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlSubModalidad" Display="Dynamic" 
                                ErrorMessage="SELECCIONE MODALIDAD" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlSituacion" runat="server" TabIndex="3" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="ddlSituacion" Display="Dynamic" 
                                ErrorMessage="SELECCIONE SITUACIÓN" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
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
                    </asp:Panel>
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
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel3" runat="server" GroupingText="DATOS DE LA VICTIMA" Font-Bold="True"
                        Font-Size="Medium" >
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
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="OFENDIDO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label53" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TIPO PERSONA OFENDIDO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlOfendido" runat="server" Width="300px" TabIndex="4" class="chosen-select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="ddlOfendido" Display="Dynamic" 
                                ErrorMessage="SELECCIONE OFENDIDO" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPersonaOfendido" runat="server" TabIndex="5" Width="200px" class="chosen-select">
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="ddlTipoPersonaOfendido" Display="Dynamic" 
                                ErrorMessage="SELECCIONE TIPO PERSONA OFENDIDO" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
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
                                    <asp:Label ID="Label42" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="LUGAR DEL FALLECIMIENTO"></asp:Label>
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
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlLugarHechos" runat="server" TabIndex="6" Width="825px" class="chosen-select">
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
                                    <asp:Label ID="Label52" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="IMPUTADO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label56" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="TIPO PERSONA IMPUTADO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label55" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="PERTENECE A UNA ORGANIZACIÓN DELICTIVA"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlImputado" runat="server" TabIndex="7" Width="300px" class="chosen-select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="ddlImputado" Display="Dynamic" 
                                ErrorMessage="SELECCIONE IMPUTADO" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPersonaImputado" runat="server" TabIndex="8" class="chosen-select"
                                        Width="200px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="ddlTipoPersonaImputado" Display="Dynamic" 
                                ErrorMessage="SELECCIONE TIPO PERSONA IMPUTADO" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrganizacionDelictiva" runat="server" TabIndex="9" class="chosen-select"
                                        Width="200px">
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
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel5" runat="server" GroupingText="DATOS DEL CADAVER" Font-Bold="True"
                        Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
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
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="VIOLENCIA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CAUSA MUERTE"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MOVIL"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlViolencia" runat="server" Width="200px" TabIndex="10" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCausaMuerte" runat="server" Width="200px" TabIndex="11" class="chosen-select">
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="ddlCausaMuerte" Display="Dynamic" 
                                ErrorMessage="SELECCIONE CAUSA MUERTE" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMovil" runat="server" TabIndex="12" Width="200px" class="chosen-select"> 
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ControlToValidate="ddlMovil" Display="Dynamic" 
                                ErrorMessage="SELECCIONE CAUSA MUERTE" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style12">
                                            <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="ESTADO DEL CUERPO"></asp:Label>
                                        </td>
                                        <td class="style12">
                                            <asp:Label ID="Label44" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="ORIENTACIÓN DEL CUERPO"></asp:Label>
                                        </td>
                                        <td class="style12">
                                            <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="POSICIÓN DEL CUERPO"></asp:Label>
                                        </td>
                                        <td class="style12">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style12">
                                            <asp:DropDownList ID="ddlCondicionCadaver" runat="server" TabIndex="13" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style12">
                                            <asp:DropDownList ID="ddlOrientacion" runat="server" TabIndex="14" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style12">
                                            <asp:DropDownList ID="ddlPosicion" runat="server" TabIndex="15" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style12">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style12">
                                            <asp:Label ID="Label349" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="PARTES DEL CUERPO ENCONTRADAS"></asp:Label>
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                    </tr>
                                    <tr>
                                         <td class="style14" colspan="4">
                                            <asp:TextBox ID="txtPartesCuerpo" runat="server" Height="120px" MaxLength="6000" Style="text-transform: uppercase" TabIndex="16"
                                                TextMode="MultiLine" Visible="true" Width="686px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                        <td class="style12">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FECHA MUERTE"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="HORA MUERTE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtFechaMuerte" runat="server" MaxLength="10" TabIndex="17" Width="190px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFechaMuerte_CalendarExtender" runat="server" Enabled="True"
                                                Format="dd/MM/yyyy" TargetControlID="txtFechaMuerte">
                                            </asp:CalendarExtender>
                                            
                                            
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHoraMuerte" runat="server" MaxLength="8" TabIndex="18" Width="190px">00:00</asp:TextBox>
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="HRS" Visible="false"></asp:Label>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="True"
                                                BehaviorID="_content_MaskedEditExtender1" Century="2000" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="€" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="," CultureName="es-ES" CultureThousandsPlaceholder="."
                                                CultureTimePlaceholder=":" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time"
                                                TargetControlID="txtHoraMuerte" />
                                        </td>
                                        <td>
                                            
                                        </td>
                                        <td>
                                          
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
                                            &nbsp;
                                            <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="FECHA IDENTIFICACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                            <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="HORA IDENTIFICACIÓN"></asp:Label>
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
                                            <asp:TextBox ID="txtFechaIdentificacion" runat="server" MaxLength="10" TabIndex="19"
                                                Width="190px"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtFechaIdentificacion">
                                            </asp:CalendarExtender>
                                            
                                            
                                        </td>
                                        <td>
                                            
                                            <asp:TextBox ID="txtHoraIdentificacion" runat="server" MaxLength="8" 
                                                TabIndex="20" Width="190px">00:00</asp:TextBox>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="HRS" Visible="false"></asp:Label>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" 
                                                runat="server" AcceptAMPM="True" BehaviorID="_content_MaskedEditExtender2" 
                                                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="€" 
                                                CultureDateFormat="DMY" CultureDatePlaceholder="/" 
                                                CultureDecimalPlaceholder="," CultureName="es-ES" 
                                                CultureThousandsPlaceholder="." CultureTimePlaceholder=":" 
                                                ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" 
                                                TargetControlID="txtHoraIdentificacion" />
                                            
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
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label54" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="SE ENTREGO EL CUERPO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblIdentificacion" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="FOTOGRAFÍA" Visible="TRUE"></asp:Label>
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
                                            <asp:DropDownList ID="ddlCuerpoEntegado" runat="server" TabIndex="22" Width="200px"
                                                AutoPostBack="true" 
                                                OnSelectedIndexChanged="ddlCuerpoEntegado_SelectedIndexChanged" ToolTip="0">
                                                <asp:ListItem Value="0"> -- SELECCIONE --</asp:ListItem>
                                                <asp:ListItem Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="2">NO</asp:ListItem>
                                                <asp:ListItem Value="3">FOSA COMÚN</asp:ListItem>
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="ddlCuerpoEntegado" Display="Dynamic" 
                                ErrorMessage="SELECCIONE CUERPO ENTREGADO" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="imageID" runat="server" class="margen" Height="23px" 
                                                TabIndex="21" Visible="true" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
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
                                            <asp:Label ID="lblResguardoCadaver" runat="server" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black" Text="RESGUARDO CADAVER (SEMEFO)" Visible="false"></asp:Label>
                                            <asp:Label ID="lblFechaEntrega" runat="server" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black" Text="FECHA ENTREGA" Visible="false"></asp:Label>
                                                <asp:Label ID="lblFechaNo" runat="server" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black" Text="FECHA SEPULTURA" Visible="false"></asp:Label>
                                            <br />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblParesntesco" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="PARENTESCO" Visible="false"></asp:Label>
                                            &nbsp;<asp:Label ID="lblDatosFosa" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="DATOS DE LA FOSA" Visible="false"></asp:Label>
                                            <br />
                                        </td>
                                        <td>
                                            &nbsp;<asp:Label ID="lblNombreEntregaCuerpo" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="NOMBRE A QUIEN ENTREGA CUERPO" 
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                                                                        
                                            <asp:TextBox ID="txtResguardoCadaver" runat="server" MaxLength="150" 
                                                TabIndex="23" Visible="false" Width="230" ></asp:TextBox>
                                        
                                            <br />
                                        
                                            <asp:TextBox ID="txtFechaEntrega" runat="server" MaxLength="10" Visible="false" TabIndex="23"
                                                Width="190px"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                TargetControlID="txtFechaEntrega">
                                            </asp:CalendarExtender>
                                           
                                           
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlParentesco" runat="server" TabIndex="24" Visible="false" class="chosen-select"
                                                Width="200px">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:TextBox ID="txtDatosFosa" runat="server" MaxLength="200" 
                                                TabIndex="24" Visible="false" Width="300px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            
                                            <asp:TextBox ID="txtNombreEntregaCuerpo" runat="server" MaxLength="100" 
                                                TabIndex="25" Visible="false" Width="300px"></asp:TextBox>
                                           
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
                                            &nbsp;
                                            <asp:Label ID="lblDescripcionVictima" runat="server" Font-Bold="True" 
                                                Font-Size="Small" ForeColor="Black" Text="DESCRIPCIÓN VICTIMA" Visible="false"></asp:Label>
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
                                            <asp:TextBox ID="txtDescripcionCadaver" runat="server" Height="120px" 
                                                MaxLength="500" Style="text-transform: uppercase" TabIndex="26" 
                                                TextMode="MultiLine" Visible="false" Width="686px"></asp:TextBox>
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
             <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
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
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdGuardar" runat="server" Font-Bold="True" Height="40px" TabIndex="27"
                        Text="GUARDAR" Width="156px" OnClick="cmdGuardar_Click" />
                &nbsp;&nbsp;
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
            <tr>
                <td colspan="4">
                    <asp:Panel ID="PanelMsj" runat="server" Style="text-align: center" 
                        BorderWidth="2" Visible="false">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server"  class="color-fuente" Style="font-weight: 700;
                                        font-size: large; text-align: left;" Text="EXISTE MENSAJE"></asp:Label>
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
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImgMsjSI" runat="server" ImageUrl="~/img/si.png"  TabIndex="28"
                                        onclick="ImgMsjSI_Click"  />
                                    &nbsp;<asp:ImageButton ID="ImgMsjNO" runat="server" ImageUrl="~/img/no.png" TabIndex="29"
                                        onclick="ImgMsjNO_Click"  />
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
                    <asp:Panel ID="PanelDatosMensaje" runat="server" GroupingText="DATOS DEL MENSAJE" Font-Bold="True" Font-Size="Medium" Visible="false"
                       >
                       
                                <table style="width: 100%;">
                                    
                                    
                                    
                                    <tr>
                                        <td class="style16">
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
                                        <td class="style14" colspan="4">
                                            <asp:TextBox ID="txtMensaje" runat="server" Height="120px" MaxLength="6000" Style="text-transform: uppercase" TabIndex="30"
                                                TextMode="MultiLine" Visible="true" Width="686px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
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
                                        <td colspan="2">
                                            <asp:Label ID="lblCaso" runat="server" Font-Bold="True" Font-Size="Small" Visible="true"
                                                ForeColor="Black" Text="EN CASO DE CONTAR CON FOTOGRAFIAS DEL MENSAJE ANEXAR:"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
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
                                        <td class="style16">
                                            <asp:Label ID="lblFoto1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FOTOGRAFIA 1" Visible="true"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFoto2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FOTOGRAFIA 2" Visible="true"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:FileUpload ID="ImagenFile1" runat="server" class="margen" Height="23px" Visible="true"
                                                TabIndex="31" />
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="ImagenFile2" runat="server" class="margen" Height="23px" Visible="true"
                                                TabIndex="32" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
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
                                        <td class="style16">
                                            <asp:Label ID="lblFoto3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FOTOGRAFIA 3" Visible="true"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFoto4" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FOTOGRAFIA 4" Visible="true"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:FileUpload ID="ImagenFile3" runat="server" class="margen" Height="23px" TabIndex="33"
                                                Visible="true" />
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="ImagenFile4" runat="server" class="margen" Height="23px" TabIndex="34"
                                                Visible="true" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
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
                                        <td class="style16">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblEstatusMensaje" runat="server" Font-Bold="True" 
                                                Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
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
                                        <td class="style16">
                                            &nbsp;
                                        </td>
                                        <td >
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="CmdMensaje" runat="server" Font-Bold="True" Height="40px" 
                                                onclick="CmdMensaje_Click" TabIndex="35" Text="GUARDAR MENSAJE" Visible="true" 
                                                Width="156px" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
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
                           
                    </asp:Panel>
                </td>
            </tr>
 
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
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
            <tr>
                <td colspan="4">
                    <asp:Panel ID="UsarArmas" runat="server" Style="text-align: center" 
                        BorderWidth="2" Visible="false">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblSuspender" runat="server"  class="color-fuente" Style="font-weight: 700;
                                        font-size: large; text-align: left;" Text="SE UTILIZARON ARMAS"></asp:Label>
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
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImgSi1" runat="server" ImageUrl="~/img/si.png" OnClick="ImgSi1_Click" TabIndex="36" />
                                    &nbsp;<asp:ImageButton ID="ImgNo1" runat="server" ImageUrl="~/img/no.png" OnClick="ImgNo1_Click" TabIndex="37" />
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
            <tr>
                <td colspan="4">
                    &nbsp;<asp:Panel ID="PanelArmas" runat="server" Visible="false" GroupingText="ARMAS UTILIZADAS"
                        Font-Bold="True" Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                            <ContentTemplate>
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
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="TIPO ARMA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="ARMA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="TAMAÑO DEL ARMA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MARCA"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlTipoArma" runat="server" TabIndex="38" Width="200px" AutoPostBack="True" class="chosen-select"
                                                OnSelectedIndexChanged="ddlTipoArma_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlArma" runat="server" TabIndex="39" Width="200px" AutoPostBack="True" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTamañoArma" runat="server" TabIndex="40" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMarcaArma" runat="server" TabIndex="41" Width="200px" class="chosen-select">
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
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" 
                                                Text="CALIBRE"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" 
                                                Text="ESTADO DEL ARMA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label41" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MATRICULA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label346" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="SERIE"></asp:Label>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCalibreArma" runat="server" TabIndex="42" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstadoArma" runat="server" TabIndex="43" Width="200px" class="chosen-select">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMatricula" runat="server" MaxLength="50" TabIndex="44" Width="190px" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSerie" runat="server" MaxLength="50" TabIndex="45" 
                                                Width="190px"></asp:TextBox>
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
                                            <asp:Label ID="Label345" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="DESCRIPCIÓN"></asp:Label>
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
                                        <td colspan="2">
                                            <asp:TextBox ID="txtDescripcionArma" runat="server" MaxLength="50" 
                                                TabIndex="46" Width="500px"></asp:TextBox>
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
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnAgregarArma" runat="server" Text="AGREGAR" Width="142px" TabIndex="47" OnClick="btnAgregarArma_Click" />
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
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label343" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LISTA DE ARMAS:"></asp:Label>
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
                                            <asp:GridView ID="gvArmas" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="4" DataSourceID="dsVerArmas" ForeColor="#333333" GridLines="None"
                                                Width="928px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="ID_ARMA" HeaderText="ID_ARMA" SortExpression="ID_ARMA"
                                                        Visible="true" InsertVisible="False" ReadOnly="True">
                                                        <ItemStyle CssClass="hidden" />
                                                        <HeaderStyle CssClass="hidden" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TIPO_ARMA" HeaderText="TIPO ARMA" SortExpression="TIPO_ARMA" />
                                                    <asp:BoundField DataField="ARMA" HeaderText="ARMA" SortExpression="ARMA" />
                                                    <asp:BoundField DataField="TAMANO_ARMA" HeaderText="TAMAÑO ARMA" SortExpression="TAMANO_ARMA" />
                                                    <asp:BoundField DataField="MARCA" HeaderText="MARCA" SortExpression="MARCA" />
                                                    <asp:BoundField DataField="CALIBRE" HeaderText="CALIBRE" SortExpression="CALIBRE" />
                                                    <asp:BoundField DataField="ESTADO_ARMA" HeaderText="ESTADO ARMA" SortExpression="ESTADO_ARMA" />
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
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:SqlDataSource ID="dsVerArmas" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>"
                                                SelectCommand="SeleccionarArmasHomicidio" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="IdCarpeta" Name="ID_CARPETA" PropertyName="Text"
                                                        Type="Int32" />
                                                    <asp:ControlParameter ControlID="ID_HOMICIDIO" Name="ID_HOMICIDIO" 
                                                        PropertyName="Text" Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
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
            
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdNuevoReg" runat="server" Font-Bold="True" Height="40px"
                        TabIndex="48" Text="NUEVO HOMICIDIO" Width="156px" 
                        onclick="cmdNuevoReg_Click" />
                &nbsp;
                    <asp:Button ID="cmdSiguiente" runat="server" Font-Bold="True" Height="40px" TabIndex="49"
                        Text="REGRESAR" Width="156px" OnClick="cmdSiguiente_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
       </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
