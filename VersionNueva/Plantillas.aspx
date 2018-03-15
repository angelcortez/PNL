<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Plantillas.aspx.cs" Inherits="AtencionTemprana.Plantillas"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            height: 17px;
            font-weight: 700;
            color: #FF0000;
        }
        .style8
        {
            width: 1205px;
        }
        .style9
        {
            height: 24px;
            width: 330px;
        }
        .style10
        {
            width: 383px;
            height: 24px;
        }
        .style12
        {
            width: 1205px;
            height: 24px;
        }
        .style13
        {
            width: 629px;
        }
        .style14
        {
            width: 629px;
            height: 24px;
        }
        .style16
        {
            width: 723px;
        }
        .style17
        {
            width: 723px;
            height: 24px;
        }
        .style18
        {
            width: 283px;
        }
        .style19
        {
            width: 330px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
      <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
        <tr>
            <td>
                
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
        <tr>
            <td>
                
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 
<h2><asp:Label ID="Label1" runat="server" Text="PLANTILLAS" ForeColor="#006600"></asp:Label>
    
    </h2>
     <iframe id="descFrame" scrolling="auto" name="descFrame" src="C:\DocumentosGenerados\tmp.htm" width="100%" height="100%" frameborder="0"></iframe>
    <asp:UpdatePanel runat=server>
    <ContentTemplate> 
   
    <asp:Panel ID="Panel2" runat="server">
        <table style="width: 100%; margin-right: 0px;">
            <tr>
                <td class="style19">
                                    <asp:Label ID="lblPlantilla" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="NOMBRE DE LA PLANTILLA:"></asp:Label>
                </td>
                <td class="style18">
                                    <asp:Label ID="lblTipoPlantilla" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="TIPO DE PLANTILLA"></asp:Label>
                </td>
                <td class="style16">
                                    &nbsp;</td>
                <td class="style13">
                                   &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                   
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td class="style10">
                   
                    
                    <asp:DropDownList ID="ddlTipoPlantilla" runat="server" 
                        Width="100px">
                    </asp:DropDownList>
                </td>
                <td class="style17">
                   

                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                </td>
                <td class="style14">
                   
                    &nbsp;</td>
                <td class="style12">
                   
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="color: #FF0000; font-weight: 700" >
                    &nbsp;
                    </td>
                <td class="style18">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;
                </td>
                <td class="style13">
                    &nbsp;
                </td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19">
                                    <asp:Label runat="server" Text="APLICA PARA:" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" ID="lblAplica"></asp:Label>
                    </td>
                <td class="style18">
                                    <asp:Label runat="server" Text="FORMA DE INICIO:" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" ID="lblFormaInicio"></asp:Label>
                </td>
                <td class="style16">
                                    <asp:Label runat="server" Text="PROCESO:" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" ID="lblProceso"></asp:Label>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="style19">
                    <asp:CheckBox ID="chbRAC" runat="server" Text="RAC" />
                    <br />
                    <asp:CheckBox ID="chbNUC" runat="server" Text="NUC" />
                    <br />
                    <asp:CheckBox ID="chbNUM" runat="server" Text="NUM" />
                    </td>
                <td class="style18">
                   
                    <asp:CheckBox ID="chbComparecencia" runat="server" Text="COMPARECENCIA" />
                    <br />
                    <asp:CheckBox ID="chbEscrito" runat="server" Text="ESCRITO" />
                    <br />
                    <asp:CheckBox ID="chbRazon" runat="server" Text="RAZON DE AVISO" />
                    <br />
                    &nbsp;<br />
                 </td>
                <td class="style16">
                   
                    <asp:CheckBox ID="chbConDetenido" runat="server" Text="CON DETENIDO" />
                    <br />
                    <asp:CheckBox ID="chbSinDetenido" runat="server" Text="SIN DETENIDO" />
                </td>
                <td class="style13">
                    &nbsp;
                </td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="5">
                    <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                        Text="Guardar" Height="26px" />
                                   
                </td>
            </tr>
             </table>
             </asp:Panel>
           
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                         <asp:Button ID="btnNuevaPlantilla" runat="server" Font-Size="Medium" 
                             onclick="btnNuevaPlantilla_Click" 
        style="font-weight: 700" Text="+" Visible="False" />
                  <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>--%>
                     <asp:Label ID="Label2" runat="server"></asp:Label>
                         
                         <asp:Panel ID="Panel3" runat="server" Visible="False">
                        
                    <asp:GridView ID="gvPlantillas" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical"  Width="927px" 
                        DataSourceID="dsMarcadores" onrowcommand="gvPlantillas_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID_PLANTILLA" HeaderText="ID_PLANTILLA" 
                                SortExpression="ID_PLANTILLA" Visible="False" />
                            <asp:BoundField DataField="ID_MARCADOR" HeaderText="MARCADOR" 
                                SortExpression="MARCADOR" />
                            <asp:BoundField DataField="ID_PROCEDIMIENTO" HeaderText="PROCEDIMIENTO" 
                                SortExpression="ID_PROCEDIMIENTO" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnProcedimiento" runat="server" Height="18px" 
                                        ImageUrl="~/img/arrowBullet.png" 
                                        CommandArgument='<%#Eval("ID_MARCADOR")%>' onclick="ibtnProcedimiento_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Center" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#CCFFCC" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                   </asp:Panel>
                    <asp:SqlDataSource ID="dsMarcadores" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="consultaCAT_PLANTILLAS_MARCADORES" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter Name="ID_PLANTILLA" SessionField="ID_PLANTILLA" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:Panel ID="Panel1" runat="server" style="text-align: center" 
                        BorderColor="#009900">
                    <div class="HellowWorldPopup">
                            <div id="PopupHeader" class="PopupHeader" runat="server" >
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                <br />
                        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="dsProcedimientos" 
                            DataTextField="ID_PROCEDIMIENTO" DataValueField="DESCRIPCION" AutoPostBack="True" 
                                    onselectedindexchanged="ListBox1_SelectedIndexChanged" Height="166px" 
                                    Width="311px" >
                        </asp:ListBox>
                                &nbsp;<asp:TextBox ID="txtDescripcion" runat="server" Height="164px" 
                                    TextMode="MultiLine" style="margin-top: 7px" Width="301px"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnAgregarProcedimiento" runat="server" 
                                    Text="Agregar Procedimiento" onclick="btnAgregarProcedimiento_Click" 
                                    Width="181px" />
                                &nbsp;
                                <asp:Button ID="btnCerrar" runat="server" style="font-weight: 700" 
                                    Text="Cerrar" />
                                <br />
                        <asp:SqlDataSource ID="dsProcedimientos" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                            SelectCommand="consultaCAT_PROCEDIMIENTOS" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                        </div>
                    </div>
                    </asp:Panel>
                 
                    <asp:ModalPopupExtender ID="Panel1_ModalPopupExtender" runat="server" 
                        DynamicServicePath="" Enabled="True" TargetControlID="Label2" OnCancelScript="btnCerrar"
                        PopupControlID="Panel1" PopupDragHandleControlID="PoppupHeader" Drag="true" BackgroundCssClass="ModalPopupBG">
                    </asp:ModalPopupExtender>
                     
                
                  <%-- </ContentTemplate>
                     </asp:UpdatePanel>--%>
          
        
    </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="btnGuardar"  />
    </Triggers>
    </asp:UpdatePanel> 
    
    
    
</div>

</asp:Content>

