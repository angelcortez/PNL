<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PNLFotografia.aspx.cs" Inherits="AtencionTemprana.PNLFotografia" %>
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
                </td>
                <td class="style6">
                </td>
                <td align="right" class="style6">
                    <asp:Label ID="ID_FOTOGRAFIA" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                </td>
            </tr>
        </table>
        <h2>
            <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
        <table style="width: 100%;">
            <tr>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            
        </table>

        <br />
        <br />

        <table style="width: 100%;">
                   <tr>
                        <td colspan="3">
                        
                        
                            <asp:Label ID="Label101" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Black" Text="PERSONA"></asp:Label>
                        
                        
                        </td>
                        </tr>

                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlOfendido" runat="server" Width="400px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                   
                   <tr>
                       <td>
                           <asp:Label ID="Label81" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="No. FOLIO"></asp:Label>
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
                           <asp:Label ID="lblFolio" runat="server" Font-Bold="True" Font-Size="Medium" 
                               ForeColor="Red"></asp:Label>
                       </td>
                       <td>
                           &nbsp;<asp:Label ID="Label59" runat="server" Font-Bold="True" Font-Italic="False" 
                               Font-Size="Small" ForeColor="Black" Text="SELECCIONAR FOTO"></asp:Label>
                       </td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtIdFotografia" runat="server" Width="60px" Visible="False"></asp:TextBox>
                       </td>
                       <td>
                                    <asp:FileUpload ID="ImagenFile" runat="server" class="margen" 
                               Height="23px" TabIndex="36"
                                        Width="293px" />
                       </td>
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
                   </tr>
                   <tr align="center">
                   <td colspan="4">
                   
                                    <asp:Image ID="Ifoto" runat="server" Height="218px" 
                           ImageAlign="Middle" Style="margin: 10px;"
                                        Visible="false" Width="270px" />
                   
                   </td>
                   
                   </tr>
                   <tr>
                   <td colspan="4">
                   
                   </td>
                   
                   </tr>
                   <tr>
                   <td colspan="4">
                   
                   </td>
                   
                   </tr>


                   <tr>
                       <td>
                           <asp:Label ID="Label82" runat="server" Font-Bold="True" Font-Italic="False" 
                               Font-Size="Small" ForeColor="Black" Text="DESCRIPCION"></asp:Label>
                       </td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td colspan="3">
                           <asp:TextBox ID="txtDescripcion" runat="server" Height="114px" MaxLength="1000" 
                               TextMode="MultiLine" Width="993px"></asp:TextBox>
                       </td>
                   </tr>
                  
                   <tr>
                       <td align="center" colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                           &nbsp;
                           &nbsp;
                           &nbsp;<br />
&nbsp;<asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                               Text="GUARDAR"  class="button"   Height="40px" Width="156px"  />
&nbsp;
                           <asp:Button ID="cmdRegresar" runat="server" 
                               Text="REGRESAR"  onclick="cmdRegresar_Click" 
                               class="button"  Height="40px" Width="156px"/>
                       &nbsp;&nbsp;
                           <br />
                           <asp:Label ID="LabelErrorFile" runat="server" Font-Bold="True"  Visible="false"
                               Font-Size="Medium" Font-Underline="True" ForeColor="#FF3300" Text="Label"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td align="left" colspan="3">
                           &nbsp;</td>
                   </tr>
               </table>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </div>
</asp:Content>

