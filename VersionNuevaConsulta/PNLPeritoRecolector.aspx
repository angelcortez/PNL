<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PNLPeritoRecolector.aspx.cs" Inherits="AtencionTemprana.PNLPeritoRecolector" %>

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
                    <asp:Label ID="ID_DONANTE" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                </td>
                <td align="right" class="style6">
                    <asp:Label ID="ID_COLECTOR_MUESTRA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
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
            
            
                    <asp:Label ID="ID_OTRA_INFO" runat="server" ForeColor="Red" 
                        Visible="true"></asp:Label>
                    <asp:Label ID="ID_PERTENENCIA_SOCIAL" runat="server" ForeColor="Red" 
                        Visible="true"></asp:Label>
                    <asp:Label ID="ID_INFO_FINANCIERA" runat="server" ForeColor="Red" 
                        Visible="true"></asp:Label>
                    <asp:Label ID="ID_DISCAPACIDADES" runat="server" ForeColor="Red" 
                        Visible="true"></asp:Label>
                    <asp:Label ID="ID_INFO_ODONTOLOGICA" runat="server" ForeColor="Red" 
                        Visible="true"></asp:Label>
                    <asp:Label ID="ID_DATOS_GENERALES" runat="server" ForeColor="Red" 
                        Visible="true"></asp:Label>
            
            
            </td>
            </tr>
        </table>

        <br />
        <br />

        <table style="width: 100%;">
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                            &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                            &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                            &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="NOMBRE"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO PATERNO"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="APELLIDO MATERNO"></asp:Label>
                       </td>
                       <td>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="NÚMERO DE EMPLEADO"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
                       </td>
                       <td>
                           <asp:TextBox ID="txtPaterno" runat="server" Width="200px"></asp:TextBox>
                       </td>
                       <td>
                           <asp:TextBox ID="txtMaterno" runat="server" Width="200px"></asp:TextBox>
                       </td>
                       <td>
                           <asp:TextBox ID="txtNumeroEempleado" runat="server" Width="200px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="INSTITUCIÓN"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="PUESTO"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label61" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="DEPARTAMENTO PERICIAL"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtInstitucion" runat="server" Width="200px"></asp:TextBox>
                       </td>
                       <td>
                           <asp:TextBox ID="txtPuesto" runat="server" Width="200px"></asp:TextBox>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlMunicipio" runat="server" Width="200px" 
                               AutoPostBack="True" class="chosen-select">
                           </asp:DropDownList>
                       </td>
                       <td>
                            <asp:TextBox ID="txtDptoPericial" runat="server" Width="200px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td align="center" colspan="4">
                           <asp:Button ID="cmdGuardar" runat="server" 
                               Text="GUARDAR" onclick="cmdGuardar_Click" Height="40px" Width="156px" class="button"  />
                       &nbsp;<asp:Button ID="cmdRegresar" runat="server" 
                               Text="REGRESAR" onclick="cmdRegresar_Click" Height="40px" Width="156px" class="button"/>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
               </table>


        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </div>
</asp:Content>