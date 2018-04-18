<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Delito.aspx.cs" Inherits="AtencionTemprana.Delito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
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
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="main-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="ddlDelito" />
                <asp:PostBackTrigger ControlID="ddlModalidad" />
                <asp:PostBackTrigger ControlID="ddlClasificacion" />
                <asp:PostBackTrigger ControlID="rbPrincipal" />
                <asp:PostBackTrigger ControlID="rbViolencia" />
                <asp:PostBackTrigger ControlID="rbGrave" />
                <asp:PostBackTrigger ControlID="cmdGu" />
                <asp:PostBackTrigger ControlID="cmdReg" />
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
                        <td>
                            <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
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
                            &nbsp;
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
                </table>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red" Visible=false></asp:Label>

                <h2>
                    <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Red" Visible=false></asp:Label>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Label ID="ID_CONSECUTIVO_DELITO" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            &nbsp;<asp:Label ID="ID_LUGAR_HECHOS" runat="server" Visible="False"></asp:Label>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            &nbsp;
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                Text="DELITO PRINCIPAL"></asp:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:RadioButtonList ID="rbPrincipal" runat="server" Font-Bold="True" 
                                Font-Size="X-Large" class="bordeCampoObligatorio"
                                ForeColor="Black" RepeatDirection="Horizontal" TabIndex="5" 
                                Enabled="False">
                                <asp:ListItem Value="1">SI</asp:ListItem>
                                <asp:ListItem Value="0">NO</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rbPrincipal"
                                Display="Dynamic" ErrorMessage="SELECCIONA PRINCIPAL" Font-Bold="True" Font-Size="Small"
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
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="DELITO"></asp:Label>
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
                            <asp:DropDownList ID="ddlDelito" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDelito_SelectedIndexChanged"
                                TabIndex="1" Width="1000px" class="bordeCampoObligatorio">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDelito"
                                Display="Dynamic" ErrorMessage="SELECCIONA DELITO" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblArticulo" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:Label>
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
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="MODALIDAD"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="CLASIFICACION DELITO"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="VIOLENCIA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="¿ES GRAVE?"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlModalidad" runat="server" Style="margin-top: 0px" TabIndex="2" 
                                Width="200px" class="bordeCampoObligatorio" Enabled="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlModalidad"
                                Display="Dynamic" ErrorMessage="SELECCIONA MODALIDAD" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClasificacion" runat="server" TabIndex="2" Width="250px"
                                class="bordeCampoObligatorio" Enabled="False">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlClasificacion"
                                Display="Dynamic" ErrorMessage="SELECCIONA CLASIFICACION" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbViolencia" runat="server" Font-Bold="True" 
                                Font-Size="Small" class="bordeCampoObligatorio"
                                ForeColor="Black" RepeatDirection="Horizontal" TabIndex="3" 
                                Enabled="False">
                                <asp:ListItem Value="1">SI</asp:ListItem>
                                <asp:ListItem Value="0">NO</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rbViolencia"
                                Display="Dynamic" ErrorMessage="SELECCIONA VIOLENCIA" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbGrave" runat="server" Font-Bold="True" 
                                Font-Size="Small" class="bordeCampoObligatorio"
                                ForeColor="Black" RepeatDirection="Horizontal" TabIndex="4" 
                                Enabled="False">
                                <asp:ListItem Value="1">SI</asp:ListItem>
                                <asp:ListItem Value="0">NO</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rbGrave"
                                Display="Dynamic" ErrorMessage="SELECCIONA GRAVE" Font-Bold="True" Font-Size="Small"
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
                             <asp:Label ID="lblSujetoInterviene" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="SUJETO QUE INTERVIENE" Visible=false></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="lblTipoSujetoInterviene" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="CORPORACIÓN" Visible=false></asp:Label>
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
                           <asp:DropDownList ID="dllSujetoInterviene" runat="server" 
                                Style="margin-top: 0px" TabIndex="2"
                                Width="200px" Visible=false AutoPostBack="True" 
                                onselectedindexchanged="dllSujetoInterviene_SelectedIndexChanged" 
                                Enabled="False">
                            </asp:DropDownList>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlCorporacion" runat="server" Style="margin-top: 0px" TabIndex="2"
                                Width="200px" Visible=false Enabled="False">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style3">
                            &nbsp;
                        </td>
                        <td class="style3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button ID="cmdGu" runat="server" Font-Bold="True" Height="40px" OnClick="cmdGu_Click"
                                TabIndex="6" Text="GUARDAR" Width="156px" class="button" style="display:none" />
                            <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" OnClick="cmdReg_Click"
                                TabIndex="7" Text="REGRESAR" Width="156px" class="button" />
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
