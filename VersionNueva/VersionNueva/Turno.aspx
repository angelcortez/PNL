<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turno.aspx.cs" Inherits="AtencionTemprana.Turno" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 546px;
        }
        .style8
        {
        }
        .style9
        {
            height: 61px;
        }
    </style>

 
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
   


       
<div id="main-wrapper">



    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
  <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Font-Size="Medium"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
        <tr>
            <td>
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
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
                <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 

  
     <p>
         &nbsp;</p>

        <table style="width: 100%;">
            <tr>
                <td class="style9" align="center">
                    &nbsp;</td>
                <td align="center" class="style9" colspan="4">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Width="150px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="INGRESE NOMBRE" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO"></asp:Label>
                    <asp:TextBox ID="txtPaterno" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPaterno" Display="Dynamic" ErrorMessage="INGRESE PATERNO" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                    &nbsp; <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO"></asp:Label>
                    <asp:TextBox ID="txtMaterno" runat="server" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblUnidadTurno" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="style8" valign="top">
                    &nbsp;</td>
                <td align="left" class="style8" colspan="2" valign="baseline">
                    <asp:RadioButtonList ID="rb" runat="server" AutoPostBack="True" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Black" 
                        onselectedindexchanged="rb_SelectedIndexChanged" Width="327px">
                        <asp:ListItem Selected="True" Value="2">ATENCION INMEDIATA</asp:ListItem>
                        <asp:ListItem Value="4">ATENCION A LA COMUNIDAD</asp:ListItem>
                        <asp:ListItem Value="5">OFICIALIA DE PARTES</asp:ListItem>
                        <asp:ListItem Value="3">JUSTICIA ALTERNATIVA</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Button ID="cmdGenerarTurno" runat="server" onclick="cmdGenerarTurno_Click" 
                        Text="GENERAR TURNO" Width="156px" />
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        ForeColor="Red" />
                </td>
                <td align="center" class="style8" colspan="2">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NUMERO DE TURNO:" Visible="False"></asp:Label>
                    <asp:Label ID="lblTurnoAtencion" runat="server" Font-Bold="True" 
                        Font-Size="XX-Large" ForeColor="Black" Visible="False"></asp:Label>
                    <asp:Label ID="lblTurnoOrientacion" runat="server" Font-Bold="True" 
                        Font-Overline="False" Font-Size="XX-Large" Font-Strikeout="False" 
                        Font-Underline="False" ForeColor="Black" Visible="False"></asp:Label>
                    <asp:Label ID="lblTurnoOficialiaPartes" runat="server" Font-Bold="True" 
                        Font-Overline="False" Font-Size="XX-Large" Font-Strikeout="False" 
                        Font-Underline="False" ForeColor="Black" Visible="False"></asp:Label>
                    <asp:Label ID="lblTurnoCentroMediacion" runat="server" Font-Bold="True" 
                        Font-Overline="False" Font-Size="XX-Large" Font-Strikeout="False" 
                        Font-Underline="False" ForeColor="Black" Visible="False"></asp:Label>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                        Font-Size="8pt" Height="330px" InteractiveDeviceInfos="(Collection)" 
                        ShowBackButton="False" ShowFindControls="False" 
                        ShowPageNavigationControls="False" ShowZoomControl="False" 
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="220px">
                        <LocalReport ReportPath="rpTurnos.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                        TypeName="AtencionTemprana.PGJ_NSJPDataSetTableAdapters.imprimirTurnoPersonaTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="turno_id" Name="ID_TURNO" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:Label ID="turno_id" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" class="style8" valign="top">
                    &nbsp;</td>
                <td align="left" class="style8" colspan="2" valign="baseline">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="#339933" Text="REGISTRO DE TURNOS"></asp:Label>
                </td>
                <td align="center" class="style8" colspan="2">
                    &nbsp;</td>
            </tr>
              <tr>
                <td class="style8">
                    &nbsp;</td>
                  <td class="style8" colspan="4">
                      &nbsp;<asp:GridView ID="gvOrientacion" runat="server" AllowPaging="True" 
                          AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                          BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="dsTurnos" 
                          ForeColor="Black" GridLines="Vertical" Width="917px">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:BoundField DataField="ID_TURNO" HeaderText="ID_TURNO" 
                                  SortExpression="ID_TURNO" Visible="False" />
                              <asp:BoundField DataField="NUMERO_TURNO" HeaderText="NUMERO DE TURNO" 
                                  SortExpression="NUMERO_TURNO" />
                              <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" 
                                  SortExpression="NOMBRE" />
                              <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" 
                                  SortExpression="PATERNO" />
                              <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" 
                                  SortExpression="MATERNO" />
                              <asp:BoundField DataField="UNIDAD_TIPO" HeaderText="UNIDAD" ReadOnly="True" 
                                  SortExpression="UNIDAD_TIPO" />
                              <asp:BoundField DataField="ID_UNIDAD_TURNO" HeaderText="ID_UNIDAD_TURNO" 
                                  SortExpression="ID_UNIDAD_TURNO" Visible="False" />
                              <asp:BoundField DataField="FECHA_ATENCION" HeaderText="FECHA DE TURNO" 
                                  SortExpression="FECHA_ATENCION" />
                              <asp:BoundField DataField="FECHA_SALIDA" HeaderText="FECHA_SALIDA" 
                                  SortExpression="FECHA_SALIDA" Visible="False" />
                              <asp:BoundField DataField="FECHA_ATENDIDO" HeaderText="FECHA DE ATENCION" 
                                  SortExpression="FECHA_ATENDIDO" />
                          </Columns>
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
                  </td>
            </tr>
              <tr>
                <td class="style8">
                    &nbsp;</td>
                  <td class="style8">
                      &nbsp;
                  </td>
                <td class="style6" colspan="2">
                    &nbsp;
                    <asp:SqlDataSource ID="dsTurnos" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="cargarTurnos" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblUnidadTurno" Name="IdUnidadTurno" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
              <tr>
                <td class="style8">
                    &nbsp;</td>
                  <td class="style8">
                      &nbsp;
                  </td>
                <td class="style6" colspan="2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
              <tr>
                <td class="style8">
                    &nbsp;</td>
                  <td class="style8">
                      &nbsp;
                  </td>
                <td class="style6" colspan="2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
              <tr>
                <td class="style8">
                    &nbsp;</td>
                  <td class="style8">
                      &nbsp;
                  </td>
                <td class="style6" colspan="2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
              <tr>
                <td class="style8">
                    &nbsp;</td>
                  <td class="style8">
                      &nbsp;
                  </td>
                <td class="style6" colspan="2">
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

