<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarBandaDesartSec.aspx.cs" Inherits="AtencionTemprana.AgregarBandaDesartSec" %>
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
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="style6">
                </td>
                <td align="right" class="style6">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Label ID="ID_BANDA" runat="server" ForeColor="Red" 
                        Visible="False"></asp:Label>
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
                    &nbsp;</td>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel3" runat="server" GroupingText="DATOS DE LA BANDA DESARTICULADA" Font-Bold="True"
                        Font-Size="Medium" ForeColor="#006600">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="NOMBRE DE LA BANDA"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNombreBanda" runat="server" 
                                        Style="text-transform: uppercase" TabIndex="11" Width="190px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="BIENES ASEGURADOS"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtBienesAsegurados" runat="server" Height="250px" 
                                        TextMode="MultiLine" Width="1000px"></asp:TextBox>
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
                    &nbsp;</td>
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
                    &nbsp;</td>
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
