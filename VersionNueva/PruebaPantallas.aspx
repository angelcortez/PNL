<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PruebaPantallas.aspx.cs" Inherits="AtencionTemprana.PruebaPantallas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            height: 19px;
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
                <td align="center" colspan="4">
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" Text="DATOS PRINCIPALES" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdGu" runat="server"  Text="AGREGAR" Width="156px"
                        TabIndex="31" Font-Bold="True" Height="40px" onclick="cmdGu_Click" />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server"  Text="MODIFICAR" Width="156px"
                        TabIndex="32" Font-Bold="True" Height="40px" onclick="cmdReg_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="PROFUGOS"
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Button1" runat="server"  Text="AGREGAR" Width="156px"
                        TabIndex="31" Font-Bold="True" Height="40px" onclick="Button1_Click" />
                    &nbsp;
                    <asp:Button ID="Button2" runat="server"  Text="MODIFICAR" Width="156px"
                        TabIndex="32" Font-Bold="True" Height="40px" onclick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="DETENIDOS" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Button3" runat="server"  Text="AGREGAR" Width="156px"
                        TabIndex="31" Font-Bold="True" Height="40px" onclick="Button3_Click" />
                    &nbsp;
                    <asp:Button ID="Button4" runat="server"  Text="MODIFICAR" Width="156px"
                        TabIndex="32" Font-Bold="True" Height="40px" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="NEGOCIACIÓN" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Button5" runat="server"  Text="AGREGAR" Width="156px"
                        TabIndex="31" Font-Bold="True" Height="40px" onclick="Button5_Click" />
                    &nbsp;
                    <asp:Button ID="Button6" runat="server"  Text="MODIFICAR" Width="156px"
                        TabIndex="32" Font-Bold="True" Height="40px" onclick="Button6_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text="LIBERACIÓN" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Button7" runat="server"  Text="AGREGAR" Width="156px"
                        TabIndex="31" Font-Bold="True" Height="40px" onclick="Button7_Click" />
                    &nbsp;
                    <asp:Button ID="Button8" runat="server"  Text="MODIFICAR" Width="156px"
                        TabIndex="32" Font-Bold="True" Height="40px" onclick="Button8_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" Text="BANDAS DESARTICULADAS" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Button9" runat="server"  Text="AGREGAR" Width="156px"
                        TabIndex="31" Font-Bold="True" Height="40px" onclick="Button9_Click" />
                    &nbsp;
                    <asp:Button ID="Button10" runat="server"  Text="MODIFICAR" Width="156px"
                        TabIndex="32" Font-Bold="True" Height="40px" onclick="Button10_Click" />
                </td>
            </tr>
            <tr align="center">
            <td colspan="4">
            
            
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" Text="PERSONAS NO LOCALIZADAS" 
                        ForeColor="Green"></asp:Label>
            
            
            </td>
            
            </tr>
            <tr align="center">
                <td colspan="4">
                    &nbsp;
                    <asp:Button ID="AGREGAR" runat="server" Visible="false" onclick="Button11_Click" 
                        Text="Agrega" />
                    <asp:Button ID="MODIFICAR" runat="server" Text="Modifica" 
                        onclick="modifica_Click" />
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
