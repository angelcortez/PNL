<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Judicializada.aspx.cs" Inherits="AtencionTemprana.Judicializada" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function mostrarFichero(destino) {
        window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
        document.forms(0).submit();
    }
    
    </script>
<style>
        .hidden
         {
            display:none;
         }
        .margen 
        {
            margin:5px
        }
        .style7
        {
            width: 1178px;
        height: 468px;
    }
        .style9
    {
        height: 19px;
        width: 230px;
    }
        .style11
    {
        width: 162px;
    }
        .style16
    {
        height: 33px;
    }
    .style17
    {
        width: 691px;
    }
        .style18
    {
        width: 14px;
    }
        .style21
    {
    }
        .style26
    {
        width: 234px;
    }
        .style28
    {
        width: 500px;
    }
    .style29
    {
    }
    .style30
    {
    }
    .style34
    {
        width: 444px;
    }
    .style35
    {
        height: 19px;
    }
        .style39
    {
        width: 493px;
    }
        .style40
    {
        width: 179px;
    }
        .style43
    {
        width: 715px;
    }
    .style44
    {
        width: 272px;
    }
    .style48
    {
        width: 250px;
    }
    .style53
    {
        width: 197px;
    }
    .style54
    {
        width: 145px;
    }
        .style56
    {
        width: 519px;
    }
        .style57
    {
        width: 133px;
    }
    .style58
    {
        width: 150px;
        text-align: left;
    }
    .style59
    {
        width: 147px;
    }
        .style61
    {
    }
    .style62
    {
        width: 173px;
    }
    .style63
    {
        width: 264px;
    }
    .style64
    {
        width: 196px;
    }
        .style65
    {
        height: 33px;
        width: 121px;
    }
    .style66
    {
        width: 121px;
    }
        .style67
    {
    }
    .style69
    {
        width: 126px;
    }
    .style70
    {
        width: 135px;
    }
    .style71
    {
        width: 713px;
    }
        .style76
    {
        width: 219px;
        height: 32px;
    }
    .style77
    {
        height: 32px;
    }
    .style79
    {
        height: 19px;
        width: 219px;
    }
        .style81
    {
        width: 221px;
        text-align: right;
    }
        .style82
    {
    }
    .style83
    {
    }
    .style86
    {
        width: 73px;
    }
        .style87
    {
        width: 176px;
    }
        </style>

               <script type="text/javascript">

                   function revisarFechaMedios(sender, args) {
                       if (sender._selectedDate > new Date()) {
                           alert("¡No se puede seleccionar un día posterior a la fecha actual!");
                           sender._selectedDate = new Date();
                           sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                       }
                   }

                   
    </script>

</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
   <%-- <asp:PostBackTrigger ControlID="cmdElaborarInforme" />
    <asp:PostBackTrigger ControlID="cmdGuardar" />--%>
    </Triggers>
    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;<asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                </td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblArbol" runat="server" Visible="False">4</asp:Label>
            </td>
            <td>
                  </td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="PUESTO" runat="server" Font-Bold="True" 
                    ForeColor="#666666" style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        </table>
        </tr>
        </table>
         <h2><asp:Label ID="Label2" runat="server" Text="IMPUTADO" class="color-fuente"></asp:Label></h2>
        <p>
            <asp:DropDownList ID="CboImputado" runat="server" Height="22px" Width="435px">
            </asp:DropDownList>
        </p>
      <table style="width: 100%;" runat="server" id="tbl_informe">
      <tr>
            <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
            <td>
                    <asp:Label ID="ID_ESTADO_NUC" runat="server" Visible="False"></asp:Label>
                </td>
            <td>
                <asp:Label ID="IdImputacion" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        </table>

          <table style="width: 100%; height: 586px;">
        <tr>
         <td class="style7">
             <asp:TabContainer ID="TabContainer1" BackColor="White"  runat="server" 
                    ActiveTabIndex="0" Width="936px" BorderColor="White" BorderStyle="Solid" 
                    UseVerticalStripPlacement="FALSE" 
                Height="602px">
             <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel7">
             <HeaderTemplate>
                         <asp:Label ID="Label7" runat="server" ForeColor="Black" 
                     Text="Control de Detención" class="color-fuente"></asp:Label>

                           </HeaderTemplate>
                            <ContentTemplate>
                           <br />
                                <asp:Panel ID="Panel1" runat="server">
                              <table>
                              <tr>
                              <td>
                                  &#160;</td>
                              <td class="style61">
                                  &#160;</td>
                              <td class="style62" style="text-align: right">
                                  &#160;</td>
                              <td class="style64">
                                  &#160;</td>
                              </tr>
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label18" runat="server" Text="Fecha de la Audiencia"></asp:Label>
                                      </td>
                                      <td class="style61">
                                            <asp:TextBox ID="TxtFechaAudiencia" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                                            <asp:CalendarExtender ID="TxtFechaAudiencia_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaAudiencia"></asp:CalendarExtender>
                                            <asp:RangeValidator ID="RanValTxtFechaAudiencia" runat="server" ControlToValidate="TxtFechaAudiencia" ErrorMessage="Fecha de Audiencia NO Válida" Font-Bold="True" 
                                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                                      </td>
                                      <td class="style62" style="text-align: right">
                                          <asp:Label ID="Label19" runat="server" Text="Calificación de la Detención"></asp:Label>
                                      </td>
                                      <td class="style64">
                                          <asp:RadioButtonList ID="OptCalificacionDetencion" runat="server" 
                                              Font-Bold="False" Font-Size="Small" ForeColor="Black" 
                                              RepeatDirection="Horizontal" TabIndex="22">
                                              <asp:ListItem Selected="True" Value="1">Legal</asp:ListItem>
                                              <asp:ListItem Value="0">No Legal</asp:ListItem>
                                          </asp:RadioButtonList>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          &#160;</td>
                                      <td class="style61">
                                          &#160;</td>
                                      <td class="style62" style="text-align: right">
                                          &#160;</td>
                                      <td class="style64">
                                          &#160;</td>
                                  </tr>
                              </table>
                              <table>
                              <tr>
                              <td colspan="2">
                                  <asp:Label ID="Label20" runat="server" Text="Observaciones"></asp:Label>
                              </td>
                              </tr>
                              <tr>
                              <td colspan="2">
                                  <asp:TextBox ID="TxtObservacionesDetencion" runat="server" Height="50px" 
                                      TextMode="MultiLine" Width="664px" style="text-transform :uppercase"></asp:TextBox>
                                  </td>
                              </tr>
                                  <tr>
                                      <td>
                                          &#160;</td>
                                      <td class="style43">
                                          &#160;</td>
                                  </tr>
                              </table>
                              <table>
                              <tr>
                              <td class="style54">
                                  <asp:Label ID="Label17" runat="server" Text="Procedimiento"></asp:Label>
                              </td>
                              <td class="style53">
                                  <asp:RadioButtonList ID="OptProcedimientoDetencion" runat="server" 
                                      Font-Bold="False" Font-Size="Small" ForeColor="Black" TabIndex="22">
                                      <asp:ListItem Selected="True" Value="1">Flagrancia</asp:ListItem>
                                      <asp:ListItem Value="2">Flagrancia Equiparada</asp:ListItem>
                                      <asp:ListItem Value="3">Caso Urgente</asp:ListItem>
                                  </asp:RadioButtonList>
                              </td>
                              <td>
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                              <td>
                                  <asp:Label ID="Label21" runat="server" Text="Fecha"></asp:Label>
                              </td>
                              <td class="style63">
                                            <asp:TextBox ID="TxtFechaDetencion" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                                            <asp:CalendarExtender ID="TxtFechaDetencion_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaDetencion"></asp:CalendarExtender>
                                            <asp:RangeValidator ID="RanValTxtFechaDetencion" runat="server" ControlToValidate="TxtFechaDetencion" ErrorMessage="Fecha de Detención NO Válida" Font-Bold="True" 
                                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>

                                 </td>
                              </tr>
                              </table>
                              <br />
                                       <asp:Panel ID="Panel12" runat="server">
                                           <table>
                                               <tr>
                                                   <td>
                                                       <asp:Label ID="Label65" runat="server" Text="Suspuestos de flagrancia:"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <asp:RadioButtonList ID="OptSupuestoFlagrancia" runat="server" 
                                                           Font-Bold="False" Font-Size="Small" ForeColor="Black" TabIndex="22">
                                                           <asp:ListItem Selected="True" Value="1">La persona es detenida después de cometer el delito (Código 146 Fracción I)</asp:ListItem>
                                                           <asp:ListItem Value="2">La persona es sorprendida cometiendo el delito y es persiguida (Código 145 fracción II a))</asp:ListItem>
                                                           <asp:ListItem Value="3">La persona es señalada por la victima u ofendido y tiene pruebas de ello (Código 146 Fracción II b))</asp:ListItem>
                                                       </asp:RadioButtonList>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td>
                                                       &nbsp;</td>
                                                   <td>

                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td>
                                                   </td>
                                                   <td>

                                                       <asp:Button ID="CmdDetencion" runat="server" Text="Registrar Detención" 
                                                           Width="182px" onclick="CmdDetencion_Click" CssClass ="button" />

                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td colspan="2">
                                                       <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" />
                                                   </td>
                                               </tr>
                                           </table>
                                    </asp:Panel>
                                   
            
                                   
                                </asp:Panel>
                                <br />
                                <br />
                                <br />
                            <br />
                            <br />
                        </ContentTemplate>
             </asp:TabPanel>
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Formulación de Imputación"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                <br />
                <table>
                <tr>
                <td class="style58">
                    <asp:Label ID="Label3" runat="server" Text="Se realizo imputación"></asp:Label>
                </td>
                <td class="style57">
                                            <asp:RadioButtonList ID="OptImputacion" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" 
                                        TabIndex="22">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                </td>
                <td class="style59">
                    <asp:Label ID="Label22" runat="server" Text="Fecha de imputación"></asp:Label>
                </td>
                <td class="style56">
                    <asp:TextBox ID="TxtFechaImputacion" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaImputacion_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaImputacion"></asp:CalendarExtender>
                    <asp:RangeValidator ID="RanValTxtFechaImputacion" runat="server" ControlToValidate="TxtFechaImputacion" ErrorMessage="Fecha de Imputación NO Válida" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                </td>
                </tr>
                <tr>
                <td colspan="4">
                    <asp:Label ID="Label24" runat="server" Text="Observaciones"></asp:Label>
                </td>
                </tr>
                <tr>
                <td colspan="4">
                    <asp:TextBox ID="TxtObservacionesImputacion" runat="server" Height="43px" 
                        TextMode="MultiLine" Width="621px" style="text-transform :uppercase"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td class="style58">
                    <asp:Label ID="Label23" runat="server" Text="Se vinculo a Proceso"></asp:Label>
                </td>
                <td class="style57">
                                            <asp:RadioButtonList ID="OptProceso" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" 
                                        TabIndex="22">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                </td>
                <td class="style59">
                    <asp:Label ID="Label25" runat="server" Text="Fecha de la Vinculacion"></asp:Label>
                </td>
                <td class="style56">
                    <asp:TextBox ID="TxtFechaVinculacion" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaVinculacion_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaVinculacion"></asp:CalendarExtender>
                    <asp:RangeValidator ID="RanValTxtFechaVinculacion" runat="server" ControlToValidate="TxtFechaVinculacion" ErrorMessage="Fecha de Vinculación a Proceso NO Válida" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>

                </td>
                </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="CmdImputacion" runat="server" OnClick="CmdImputacion_Click" CssClass ="button" 
                                Text="Registrar Imputación" Width="194px" />
                            &nbsp;&nbsp;
                            <asp:Label ID="LblMensaje" runat="server" Font-Bold="True" ForeColor="Green" 
                                Text="Se registró Vinculación a Proceso. Agregue los Delitos." Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                <tr>
                <td colspan="4">
                    <asp:Label ID="Label26" runat="server" 
                        Text="Delito por el cual se vinculo a Proceso "></asp:Label>
                </td>
                </tr>
                    <tr>
                        <td colspan="4">
                            <asp:DropDownList ID="CboDelito" runat="server" AppendDataBoundItems="True" 
                                AutoPostBack="True" Height="27px" style="margin-bottom: 0px" Width="508px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label63" runat="server" Text="Modalidad"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label64" runat="server" Text="Calificación" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style9" colspan="2">
                            <asp:DropDownList ID="CboModalidad" runat="server" AppendDataBoundItems="True" 
                                AutoPostBack="True" Height="26px" style="margin-bottom: 0px" Width="206px">
                            </asp:DropDownList>
                        </td>
                        <td class="style9" colspan="2">
                            <asp:Button ID="CmdAgregarDelito" runat="server" OnClick="CmdAgregarDelito_Click" CssClass ="button" 
                                Text="Registrar Delito" Width="194px" Visible="False" />
                            <asp:DropDownList ID="CboCalificacion" runat="server" 
                                AppendDataBoundItems="True" AutoPostBack="True" Height="16px" 
                                style="margin-bottom: 0px" Visible="False" Width="51px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:GridView ID="gridDelitos" runat="server" 
                        AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
                        ForeColor="#333333" GridLines="None" Height="16px" Width="508px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID_VINCULACION_DELITO" 
                                HeaderText="ID_VINCULACION_DELITO" SortExpression="ID_VINCULACION_DELITO" />
                            <asp:BoundField DataField="DELITO" HeaderText="DELITO" 
                                SortExpression="DELITO" />
                            <asp:BoundField DataField="MODALIDAD" HeaderText="MODALIDAD" 
                                SortExpression="MODALIDAD" />
                            <asp:BoundField DataField="CALIFICACION" HeaderText="CALIFICACION" 
                                SortExpression="CALIFICACION" />
                            <asp:BoundField DataField="ID_VINCULACION_DELITO" 
                                HeaderText="ID_VINCULACION_DELITO" SortExpression="ID_VINCULACION_DELITO" 
                                Visible="False" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" 
                        SelectCommand="ConsultaDelitosVinculadosProceso" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdImputacion" DefaultValue="0" 
                                Name="IdImputacion" PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <br />
                    <br />
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label6" runat="server"  Text="Suspención condicional del Proceso "></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                    <br />
              <table>
              <tr>
              <td class="style65">
              </td>
              <td class="style16">
              </td>
              </tr>
                  <tr>
                      <td class="style66">
                          <asp:Label ID="Label27" runat="server" 
                              Text="Suspención condicional del Proceso "></asp:Label>
                      </td>
                      <td>
                          <asp:RadioButtonList ID="OptSuspencion" runat="server" Font-Bold="False" 
                              Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="22">
                              <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                              <asp:ListItem Value="0">NO</asp:ListItem>
                          </asp:RadioButtonList>
                      </td>
                  </tr>
                  <tr>
                      <td class="style66">
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style66">
                          <asp:Label ID="Label31" runat="server" Text="Revoco la Suspención del Proceso"></asp:Label>
                      </td>
                      <td>
                          <asp:RadioButtonList ID="OptRevocaSuspencion" runat="server" Font-Bold="False" 
                              Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="22">
                              <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                              <asp:ListItem Value="0">NO</asp:ListItem>
                          </asp:RadioButtonList>
                      </td>
                  </tr>
                  <tr>
                      <td class="style66">
                          &nbsp;</td>
                      <td>
                          &nbsp;</td>
                  </tr>
              <tr>
              <td class="style66">
                  <asp:Label ID="Label28" runat="server" Text="Fecha de suspención"></asp:Label>
              </td>
              <td>
                    <asp:TextBox ID="TxtFechaSuspencion" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaSuspencion_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaSuspencion"></asp:CalendarExtender>
                    <asp:RangeValidator ID="RanValTxtFechaSuspencion" runat="server" ControlToValidate="TxtFechaSuspencion" ErrorMessage="Fecha de Suspención NO Válida" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>

              </td>
              <td class="style18">
                  &nbsp;</td>
                  <td>
                      <asp:Label ID="Label29" runat="server" Text="Periodo de Suspención"></asp:Label>
                      &nbsp;
                        <asp:TextBox ID="TxtFechaDel" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                        <asp:CalendarExtender ID="TxtFechaDel_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaDel"></asp:CalendarExtender>
                        <asp:RangeValidator ID="RanValTxtFechaDel" runat="server" ControlToValidate="TxtFechaDel" ErrorMessage="Fecha de Inicio de Suspención NO Válida" Font-Bold="True" 
                            Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                      &nbsp;
                      <asp:Label ID="Label30" runat="server" Text="al"></asp:Label>
                      &nbsp;
                        <asp:TextBox ID="TxtFechaAl" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                        <asp:CalendarExtender ID="TxtFechaAl_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaAl"></asp:CalendarExtender>
                        <asp:RangeValidator ID="RanValTxtFechaAl" runat="server" ControlToValidate="TxtFechaAl" ErrorMessage="Fecha de Fin de Suspención NO Válida" Font-Bold="True" 
                            Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>

                  </td>
              </tr>
              <tr>
              <td class="style66">
                  &nbsp;</td>
              <td class="style9">
                                            &nbsp;</td>
              <td class="style17" colspan="2">
                  &nbsp;</td>
              </tr>
                  <tr>
                      <td class="style66">
                          <asp:Label ID="Label32" runat="server" 
                              Text="Fecha de la Reanudación del Proceso"></asp:Label>
                      </td>
                      <td class="style9">
                            <asp:TextBox ID="TxtFechaReanudacion" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtFechaReanudacion_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaReanudacion"></asp:CalendarExtender>
                            <asp:RangeValidator ID="RaneValTxtFechaReanudacion" runat="server" ControlToValidate="TxtFechaReanudacion" ErrorMessage="Fecha de Reanudación NO Válida" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>

                      </td>
                      <td class="style17" colspan="2">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style66">
                          &nbsp;</td>
                      <td class="style9">
                          &nbsp;</td>
                      <td class="style17" colspan="2">
                          &nbsp;</td>
                  </tr>
                  <tr>
                      <td class="style66">
                          &nbsp;</td>
                      <td class="style9">
                          &nbsp;</td>
                      <td class="style17" colspan="2">
                          <asp:Button ID="CmdSuspencion" runat="server" onclick="CmdSuspencion_Click" CssClass ="button" 
                              Text="RegistraSuspención" Width="182px" />
                      </td>
                  </tr>
                  <tr>
                      <td colspan="4">
                          <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" />
                      </td>
                  </tr>
              </table>
                    &nbsp;
                    <br />
                    &nbsp;
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </ContentTemplate>
                </asp:TabPanel>
                 <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label4" runat="server" Text="Medidas Cautelares"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                <br />
                <table>
                <tr>
                <td>
                    &nbsp;</td>
                <td class="style43">
                    &nbsp;</td>
                </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Medida Cautelar Procedente"></asp:Label>
                        </td>
                        <td class="style43">
                                            <asp:RadioButtonList ID="OptProcedente" runat="server" Font-Bold="False" 
                                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" 
                                        TabIndex="22">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style43">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label33" runat="server" Text="Fecha"></asp:Label>
                            &nbsp;de la Medida</td>
                        <td class="style43">
                            <asp:TextBox ID="TxtFechaMedida" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtFechaMedida_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaMedida"></asp:CalendarExtender>
                            <asp:RangeValidator ID="RanValTxtFechaMedida" runat="server" ControlToValidate="TxtFechaMedida" ErrorMessage="Fecha de la Medida NO Válida" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style43">
                            &nbsp;</td>
                    </tr>
                <tr>
                <td>
                    <asp:Label ID="Label34" runat="server" Text="Tipo de Medida Cautelar"></asp:Label>
                </td>
                <td class="style43">
                    <asp:DropDownList ID="CboMedidaCautelar" runat="server" Width="634px" 
                        Height="23px">
                    </asp:DropDownList>
                </td>
                </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style43">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label69" runat="server" Text="Temporalidad de la Medida"></asp:Label>
                        </td>
                        <td class="style43">
                            <asp:TextBox ID="TxtFechaMedidaDel" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtFechaMedidaDel_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaMedidaDel"></asp:CalendarExtender>
                            <asp:RangeValidator ID="RanValTxtFechaMedidaDel" runat="server" ControlToValidate="TxtFechaMedidaDel" ErrorMessage="Fecha de Inicio de la Medida NO Válida" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                            &nbsp;
                            <asp:Label ID="Label70" runat="server" Text="al"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="TxtFechaMedidaAl" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtFechaMedidaAl_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaMedidaAl"></asp:CalendarExtender>
                            <asp:RangeValidator ID="RanValTxtFechaMedidaAl" runat="server" ControlToValidate="TxtFechaMedidaAl" ErrorMessage="Fecha de Fin de la Medida NO Válida" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style43">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style43">
                            <asp:Button ID="CmdMedidaCautelar" runat="server" Height="26px" CssClass ="button" 
                                OnClick="CmdMedidaCautelar_Click" Text="Registrar Medida Cautelar" 
                                Width="214px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style43">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style43">
                            <asp:ValidationSummary ID="ValidationSummary5" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                    &nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;
                </ContentTemplate>
                </asp:TabPanel>
                 <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label5" runat="server" Text="Solicitud de Ordenes"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                <br />
                <table>
                <tr>
                <td class="style70">
                    &nbsp;</td>
                <td class="style48">
                    &nbsp;</td>
                <td class="style69">
                    &nbsp;</td>
                <td class="style44">
                    &nbsp;</td>
                </tr>
                    <tr>
                        <td class="style70">
                            <asp:Label ID="Label15" runat="server" Text="Forma de Solicitud"></asp:Label>
                        </td>
                        <td class="style48">
                          <asp:RadioButtonList ID="OptSolicitaOrden" runat="server" Font-Bold="False" 
                              Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="22">
                              <asp:ListItem Value="1">Escrito</asp:ListItem>
                              <asp:ListItem Value="0">Privada</asp:ListItem>
                          </asp:RadioButtonList>
                        </td>
                        <td align="right" class="style69">
                            <asp:Label ID="Label41" runat="server" Text="Fecha de Solicitud"></asp:Label>
                        </td>
                        <td class="style44">
                            <asp:TextBox ID="TxtFechaOrden" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtFechaOrden_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaOrden"></asp:CalendarExtender>
                            <asp:RangeValidator ID="RanValTxtFechaOrden" runat="server" ControlToValidate="TxtFechaOrden" ErrorMessage="Fecha de Orden NO Válida" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style70">
                            &nbsp;</td>
                        <td class="style48">
                            &nbsp;</td>
                        <td class="style69">
                            &nbsp;</td>
                        <td class="style44">
                            &nbsp;</td>
                    </tr>
                <tr>
              <td class="style70">
                    <asp:Label ID="Label42" runat="server" Text="Estado de la orden" 
                        Visible="False"></asp:Label>
                </td>
                <td class="style48">
                    <asp:DropDownList ID="CboEstadoOrden" runat="server" Width="212px" 
                        Height="22px" Visible="False">
                    </asp:DropDownList>
                </td>
                <td align="right" class="style69">
                    <asp:Label ID="Label43" runat="server" Text="Tipo de Orden" 
                        style="text-align: left"></asp:Label>
                </td>
                <td class="style44">
                    <asp:DropDownList ID="CboTipoOrden" runat="server" Width="231px" Height="22px">
                    </asp:DropDownList>
                </td>
                </tr>
                    <tr>
                        <td class="style70">
                            &nbsp;</td>
                        <td class="style48">
                            &nbsp;</td>
                        <td class="style69">
                            &nbsp;</td>
                        <td class="style44">
                            &nbsp;</td>
                    </tr>
                    </tr>
                 </table>
                <table>
               
                <tr>
                 <td class="style21" colspan="2">
                    <asp:Label ID="Label44" runat="server" Text="Observaciones"></asp:Label>
                </td>
                </tr>
                <tr>
                 <td class="style86">
                </td>
               <td class="style71">
                    <asp:TextBox ID="TxtObservacionesOrden" runat="server" TextMode="MultiLine" Height="85px" 
                        Width="673px" style="text-transform :uppercase"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td class="style67" colspan="2">
                            <asp:Label ID="lblEstatusOrdenes" runat="server" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" style="text-align: center"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style86">
                            &nbsp;</td>
                        <td class="style71">
                            <asp:Button ID="CmdOrdenes" runat="server" Height="26px" CssClass ="button" 
                                Text="Registrar Órden" Width="212px" onclick="CmdOrdenes_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style86">
                            &nbsp;</td>
                        <td class="style71">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style86">
                            &nbsp;</td>
                        <td class="style71">
                            <asp:ValidationSummary ID="ValidationSummary6" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                    &nbsp;&nbsp; &nbsp;<br /> &nbsp;&nbsp;<br />&nbsp;<br />&nbsp;
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label8" runat="server" Text="Acuerdos Reparatorios"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                <br />
                <table>
                <tr>
                <td class="style26">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                </tr>
                    <tr>
                        <td class="style26">
                            <asp:Label ID="Label16" runat="server" 
                                Text="Medios Alternos de Solución en el PJE"></asp:Label>
                        </td>
                        <td>
                          <asp:RadioButtonList ID="OptMediosAlternos" runat="server" Font-Bold="False" 
                              Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="22">
                              <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                              <asp:ListItem Value="0">NO</asp:ListItem>
                          </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style26">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                <tr>
                  <td class="style26">
                    <asp:Label ID="Label45" runat="server" 
                        Text="Se llevo acabo un acuerdo reparatorio"></asp:Label>
                </td>
                <td>
                          <asp:RadioButtonList ID="OptAcuerdoReparatorio" runat="server" Font-Bold="False" 
                              Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="22">
                              <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                              <asp:ListItem Value="0">NO</asp:ListItem>
                          </asp:RadioButtonList>
                </td>
                    <tr>
                        <td class="style26">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                 </table>
                <table>

                </tr>
                <tr>
                <td class="style77">
                    <asp:Label ID="Label46" runat="server" Text="Fecha del Acuerdo"></asp:Label>
                </td>
                <td class="style76">
                    <asp:TextBox ID="TxtFechaAcuerdo" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaAcuerdo_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaAcuerdo"></asp:CalendarExtender>
                    <asp:RangeValidator ID="RanValTxtFechaAcuerdo" runat="server" ControlToValidate="TxtFechaAcuerdo" ErrorMessage="Fecha de Acuerdo NO Válida" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                </td>
                <td class="style77">
                    <asp:Label ID="Label47" runat="server" Text="Fecha de la Aprobación"></asp:Label>
                </td>
                <td class="style77">
                    <asp:TextBox ID="TxtFechaAprobacion" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaAprobacion_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaAprobacion"></asp:CalendarExtender>
                    <asp:RangeValidator ID="RanValTxtFechaAprobacion" runat="server" ControlToValidate="TxtFechaAprobacion" ErrorMessage="Fecha de Aprobación NO Válida" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                </td>
                </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                <tr>
                <td class="style9">
                    <asp:Label ID="Label66" runat="server" Text="Tipo de Acuerdo"></asp:Label>
                </td>
                <td class="style79">
                          <asp:RadioButtonList ID="OptTipoAcuerdo" runat="server" Font-Bold="False" 
                              Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="22">
                              <asp:ListItem Selected="True" Value="1">Inmediato</asp:ListItem>
                              <asp:ListItem Value="2">Diferido</asp:ListItem>
                          </asp:RadioButtonList>
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                </tr>
                    <tr>
                        <td class="style9" colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style9" colspan="4">
                            <asp:Label ID="Label48" runat="server" Text="Observaciones"></asp:Label>
                        </td>
                    </tr>
                <tr>
                <td>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="TxtObservacionesAcuerdo" runat="server" TextMode="MultiLine" Height="97px" 
                        Width="604px" style="text-transform :uppercase"></asp:TextBox>
                </td>
                </tr>
                 <tr>
                <td colspan="4">
                    &nbsp;</td>
                </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style61" colspan="3">
                            <asp:Button ID="CmdAcuerdoReparatorio" runat="server" Height="26px" CssClass ="button" 
                                onclick="CmdAcuerdoReparatorio_Click" Text="Registrar Acuerdo Reparatorio" 
                                Width="194px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style61" colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style61" colspan="3">
                            <asp:ValidationSummary ID="ValidationSummary7" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                    <br />
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label9" runat="server" Text="Sentencia"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                 <br />
                 <table>
                 <tr>
                 <td class="style40">
                     &nbsp;</td>
                 <td class="style28" colspan="2">
                     &nbsp;</td>
                 </tr>
                     <tr>
                         <td class="style40">
                             <asp:Label ID="Label37" runat="server" Text="Procedimiento" 
                                 style="text-align: right"></asp:Label>
                         </td>
                         <td class="style11">
                          <asp:RadioButtonList ID="OptProcedimientoAbreviado" runat="server" Font-Bold="False" 
                              Font-Size="Small" ForeColor="Black" TabIndex="22" Width="283px">
                              <asp:ListItem Value="1">Procedimiento Abreviado</asp:ListItem>
                              <asp:ListItem Value="0">Juicio</asp:ListItem>
                          </asp:RadioButtonList>
                         </td>
                         <td class="style34">
                             <asp:Label ID="Label50" runat="server" Text="Fecha de audiencia"></asp:Label>
                            <asp:TextBox ID="TxtFechaProcedimiento" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtFechaProcedimiento_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaProcedimiento"></asp:CalendarExtender>
                            <asp:RangeValidator ID="RanValTxtFechaProcedimiento" runat="server" ControlToValidate="TxtFechaProcedimiento" ErrorMessage="Fecha de Procedimiento NO Válida" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                         </td>
                     </tr>
                 <tr>
                 <td class="style35" colspan="3">
                     <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                         ForeColor="Red" style="text-align: center"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                 <td class="style40">
                     &nbsp;</td>
                 <td class="style28" colspan="2">
                     <asp:Button ID="CmdProcedimientoAbreviado" runat="server" Height="26px" CssClass ="button" 
                         Text="Registrar Procedimiento" Width="235px" 
                         onclick="CmdProcedimientoAbreviado_Click" />
                     </td>
                 </tr>
                     <tr>
                         <td class="style40">
                             &nbsp;</td>
                         <td class="style28" colspan="2">
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td class="style40">
                             <asp:Label ID="Label51" runat="server" 
                                 Text="Delito por el cual se dicto la Sentencia"></asp:Label>
                         </td>
                         <td class="style28" colspan="2">
                             <asp:DropDownList ID="CboDelitoSentencia" runat="server" Height="20px" 
                                 Width="514px">
                             </asp:DropDownList>
                         </td>
                     </tr>
                     </tr>
                 </table>
                 <table>
                 <tr>
                 <td class="style87">
                     <asp:Label ID="Label52" runat="server" Text="Tipo de Sentencia"></asp:Label>
                     </td>
                 <td class="style30">
                     <asp:DropDownList ID="CboTipoSentencia" runat="server" Width="243px">
                     </asp:DropDownList>
                     </td>
                 <td class="style81">
                     <asp:Label ID="Label68" runat="server" Text="Fecha de Sentencia" 
                         style="text-align: right"></asp:Label>
                     </td>
                 <td class="style48">
                            <asp:TextBox ID="TxtFechaSentencia" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                            <asp:CalendarExtender ID="TxtFechaSentencia_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaSentencia"></asp:CalendarExtender>
                            <asp:RangeValidator ID="RanValTxtFechaSentencia" runat="server" ControlToValidate="TxtFechaSentencia" ErrorMessage="Fecha de Sentencia NO Válida" Font-Bold="True" 
                                Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                     </td>
                 </tr>
                 <tr>
                 <td class="style87">
                     <asp:Label ID="Label53" runat="server" Text="Sanción"></asp:Label>
                     </td>
                 <td class="style30">
                     <asp:DropDownList ID="CboSancion" runat="server" Width="242px">
                     </asp:DropDownList>
                     </td>
                 <td class="style81">
                     &nbsp;</td>
                 <td class="style48">
                     &nbsp;</td>
                 </tr>
                 <tr>
                 <td class="style87"></td>
                 <td class="style30"></td>
                 <td class="style81"></td>
                 <td class="style48"></td>
                 </tr>
                 <tr>
                 <td class="style87">
                     <asp:Label ID="Label67" runat="server" Text="Ofendido"></asp:Label>
                     </td>
                 <td class="style29" colspan="3">
                     <asp:DropDownList ID="CboOfendido" runat="server" Width="390px" Height="16px">
                     </asp:DropDownList>
                     </td>
                 </tr>
                     <tr>
                         <td class="style87">
                             &nbsp;</td>
                         <td class="style29" colspan="3">
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td class="style87">
                             <asp:Label ID="Label71" runat="server" Text="Observaciones"></asp:Label>
                         </td>
                         <td class="style29" colspan="3">
                             <asp:TextBox ID="TxtObservaciones" runat="server" Height="36px" MaxLength="250" 
                                 TextMode="MultiLine" Width="680px" style="text-transform :uppercase"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td class="style82" colspan="4">
                             <asp:Label ID="lblEstatus2" runat="server" Font-Bold="True" Font-Size="Medium" 
                                 ForeColor="Red" style="text-align: center"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="style87">
                             &nbsp;</td>
                         <td class="style29" colspan="3">
                             <asp:Button ID="CmdSentencia" runat="server" Height="26px" CssClass ="button" 
                                 OnClick="CmdSentencia_Click" Text="Registrar Sentencia" Width="235px" />
                         </td>
                     </tr>
                     <tr>
                         <td class="style87">
                             &nbsp;</td>
                         <td class="style29" colspan="3">
                             <asp:ValidationSummary ID="ValidationSummary8" runat="server" ForeColor="Red" />
                         </td>
                     </tr>
                     <tr>
                         <td class="style87">
                             &nbsp;</td>
                         <td class="style29" colspan="3">
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td class="style83" colspan="4">
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                 CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" 
                                 GridLines="None" Height="16px" Width="880px">
                                 <AlternatingRowStyle BackColor="White" />
                                 <Columns>
                                     <asp:BoundField DataField="FECHA" HeaderText="FECHA" SortExpression="FECHA">
                                     <ItemStyle Width="140px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="IMPUTADO" HeaderText="IMPUTADO" ReadOnly="True" 
                                         SortExpression="IMPUTADO">
                                     <ItemStyle Width="260px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="DELITO" HeaderText="DELITO" SortExpression="DELITO">
                                     <ItemStyle Width="300px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="TIPO_SENTENCIA" HeaderText="TIPO_SENTENCIA" 
                                         SortExpression="TIPO_SENTENCIA" />
                                 </Columns>
                                 <EditRowStyle BackColor="#2461BF" />
                                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                 <RowStyle BackColor="#EFF3FB" />
                                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
                             </asp:GridView>
                             <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                 ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" 
                                 SelectCommand="ConsultaSentencia" SelectCommandType="StoredProcedure">
                                 <SelectParameters>
                                     <asp:SessionParameter DefaultValue="0" Name="IdCarpeta" 
                                         SessionField="ID_CARPETA" Type="Int32" />
                                 </SelectParameters>
                             </asp:SqlDataSource>
                             <br />
                         </td>
                     </tr>
                 </table>
                    <br />
                 <br />
                    <br />
                    &nbsp;
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel8" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label10" runat="server" Text="Sobreseimiento"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                <br />
                    <br />
                <asp:Label ID="Label38" runat="server" Text="Establecer Sobreseimiento"></asp:Label>
                    &nbsp;<asp:RadioButtonList ID="OptSobreseimiento" runat="server" Font-Bold="False" 
                        Font-Size="Small" ForeColor="Black" 
                        RepeatDirection="Horizontal" TabIndex="22">
                        <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                        <asp:ListItem Value="0">NO</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Label ID="Label56" runat="server" Text="Fecha de Sobreseimiento"></asp:Label>
                    <br />
                    <asp:TextBox ID="TxtFechaSobreseimiento" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaSobreseimiento_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaSobreseimiento"></asp:CalendarExtender>
                    <asp:RangeValidator ID="RanValTxtFechaSobreseimiento" runat="server" ControlToValidate="TxtFechaSobreseimiento" ErrorMessage="Fecha de Sobreseimiento NO Válida" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                    <br />
                    <br />
                    <asp:Label ID="Label57" runat="server" Text="Observaciones"></asp:Label>
                    <br />
                    <asp:TextBox ID="TxtObservacionesSobreseimiento" runat="server" 
                        TextMode="MultiLine" Height="95px" 
                        Width="609px" style="text-transform :uppercase"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="CmdRegistrarSobreseimiento" runat="server" CssClass ="button" 
                        Text="Registrar Sobreseimiento" Width="194px" 
                        onclick="CmdRegistrarSobreseimiento_Click" />
                    <br />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" />
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label11" runat="server"  Text="Plazo de cierre de investigación"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                <br />
                    <br />
                 <br />
                    <asp:TextBox ID="TxtPlazo" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="Label58" runat="server" 
                        Text="días (10 días antes del delito)"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="CmdRegistrarPlazo" runat="server" CssClass ="button" 
                        onclick="CmdRegistrarPlazo_Click" Text="Registrar Plazo" Width="186px" />
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel10" runat="server" HeaderText="TabPanel1">
                <HeaderTemplate>
                <asp:Label ID="Label12" runat="server" Text="Medidas de Protección"></asp:Label>
                </HeaderTemplate>
                <ContentTemplate>
                <br />
                <table>
                <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style39">
                          &nbsp;</td>
                </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label40" runat="server" Text="Medidas de Protección"></asp:Label>
                        </td>
                        <td class="style39">
                            <asp:RadioButtonList ID="OptMedidasProteccion" runat="server" Font-Bold="False" 
                                Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="22">
                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                <asp:ListItem Value="0">NO</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                        <td class="style39">
                            &nbsp;</td>
                    </tr>
                 <tr>
                <td>
                    <asp:Label ID="Label59" runat="server" Text="Medida"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="CboMedidaProteccion" runat="server" Width="639px" 
                        Height="19px">
                    </asp:DropDownList>
                </td>
                </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                 <tr>
                <td>
                    <asp:Label ID="Label60" runat="server" Text="Fecha"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtFechaMedidaProteccion" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaMedidaProteccion_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFechaMedidaProteccion"></asp:CalendarExtender>
                    <asp:RangeValidator ID="RanValTxtFechaMedidaProteccion" runat="server" ControlToValidate="TxtFechaMedidaProteccion" ErrorMessage="Fecha de Medida NO Válida" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/07/2013" Display="Dynamic">*</asp:RangeValidator>
                </td>
                <td class="style39">
                </td>
                </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style39">
                            &nbsp;</td>
                    </tr>
                 <tr>
                <td>
                    <asp:Label ID="Label61" runat="server" Text="Plazo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPlazoMedidaProteccion" runat="server" Width="150px" 
                        TextMode="Number"></asp:TextBox>
                </td>
                <td class="style39">
                    <asp:Label ID="Label62" runat="server" Text="dias"></asp:Label>
                </td>
                </tr>
                 <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style39">
                    &nbsp;</td>
                </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:Button ID="CmdMedidasProteccion" runat="server" Height="26px" CssClass ="button" 
                                Text="Registrar Medidas de Protección" Width="229px" 
                                onclick="CmdMedidasProteccion_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary9" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </table>


                 <br />
                </ContentTemplate>
                </asp:TabPanel>


               <%-- <asp:TabPanel ID="PanelMediosSTJ" runat="server" HeaderText="TabPanel1">
                    <HeaderTemplate>
                    <asp:Label ID="Label14" runat="server" Text="Medios Alternativos STJ"></asp:Label>
                    </HeaderTemplate>
                    <ContentTemplate>
                    <br />
                            <asp:Label ID="lblErrorMediosSTJ" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red" Visible=true></asp:Label>
                        <br />
                    <table>
                            <tr>
                                <td><asp:Label ID="lblFechaMediosSTJ" runat="server" Text="Fecha"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="txtFechaMediosSTJ" runat="server" Width="190px" MaxLength="10" TabIndex="20"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaMediosSTJ" OnClientDateSelectionChanged="revisarFechaMedios"></asp:CalendarExtender></td>
                            </tr>

                      <tr>
                                <td><asp:Label ID="lblObservacionMediosSTJ" runat="server" Text="Observaciones"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="txtObservacionsMediosSTJ" runat="server" Height="50px" 
                                      TextMode="MultiLine" Width="664px" style="text-transform :uppercase"></asp:TextBox>
                   
                            </tr>
                    
                    </table>
                    
                    <asp:Button ID="btnMedios" runat="server" Text="GUARDAR" 
                                                           Width="182px" onclick="btnMedios_Click" CssClass ="button" />
                
                    </ContentTemplate>
               </asp:TabPanel>--%>

             </asp:TabContainer>



             <br />
             <asp:Button ID="CmdRegresar" runat="server" OnClick="CmdRegresar_Click" CssClass ="button" 
                 Text="&lt;&lt;&lt; Regresar" Width="182px" />

        </td>
        
            </table>
        <br />
    
  </ContentTemplate>
    </asp:UpdatePanel>


</div>

</asp:Content>
