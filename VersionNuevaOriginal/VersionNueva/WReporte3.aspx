<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WReporte3.aspx.cs" Inherits="AtencionTemprana.WReporte3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="main-wrapper">
    <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#006600"></asp:Label>
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
            <td class="style2">
                <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
            <td align="right" class="style2">
                </td>
        </tr>
     
      
        <tr>
            <td class="style2">
                <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
            <td align="right" class="style2">
                </td>
        </tr>
    </table>

     <table >
     <tr>
        <td colspan="3">
                            <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Large" class="color-fuente" style="text-align: center" 
                        Text="Conteo de denuncias por fecha de hechos, organizada por fecha de inicio" Width="1089px"></asp:Label>
        </td>
     </tr>
     <tr>
         <td>                    <asp:Label ID="lblFechaInicio" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FECHA INICIAL"></asp:Label></td>
         <td>                    <asp:Label ID="lblFechaFin" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FECHA FINAL"></asp:Label></td>
         <td></td>
     </tr>
     <tr>
         <td>                    <asp:TextBox ID="TxtFechaInicio" runat="server" MaxLength="10" TabIndex="20" 
                        Width="190px"></asp:TextBox>
                                               <asp:CalendarExtender ID="TxtFechaInicio_CalendarExtender" runat="server" Enabled="True"
                                                Format="dd/MM/yyyy" TargetControlID="TxtFechaInicio">
                                            </asp:CalendarExtender>
                        </td>
         <td>                    <asp:TextBox ID="TxtFechaFin" runat="server" MaxLength="10" TabIndex="20" 
                        Width="190px"></asp:TextBox>
                                               <asp:CalendarExtender ID="TxtFechaFin_CalendarExtender" runat="server" Enabled="True"
                                                Format="dd/MM/yyyy" TargetControlID="TxtFechaFin">
                                            </asp:CalendarExtender></td>
         <td>                    <asp:Button ID="btnBuscar" runat="server" 
                        Text="BUSCAR" Width="149px" class="button" 
                 onclick="btnBuscar_Click" /></td>
     </tr>
    </table>
    <br />
                <asp:GridView ID="gvEstados" runat="server" Height="118px" Width="1024px" 
        AutoGenerateColumns="False" DataSourceID="ObjectTabla" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="AÑO" HeaderText="" ReadOnly="True" 
                SortExpression="AÑO" />
            <asp:BoundField DataField="ENERO" HeaderText="ENERO" ReadOnly="True" 
                SortExpression="ENERO" />
            <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" ReadOnly="True" 
                SortExpression="FEBRERO" />
            <asp:BoundField DataField="MARZO" HeaderText="MARZO" ReadOnly="True" 
                SortExpression="MARZO" />
            <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" ReadOnly="True" 
                SortExpression="ABRIL" />
            <asp:BoundField DataField="MAYO" HeaderText="MAYO" ReadOnly="True" 
                SortExpression="MAYO" />
            <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" ReadOnly="True" 
                SortExpression="JUNIO" />
            <asp:BoundField DataField="JULIO" HeaderText="JULIO" ReadOnly="True" 
                SortExpression="JULIO" />
            <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" ReadOnly="True" 
                SortExpression="AGOSTO" />
            <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" ReadOnly="True" 
                SortExpression="SEPTIEMBRE" />
            <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" ReadOnly="True" 
                SortExpression="OCTUBRE" />
            <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" ReadOnly="True" 
                SortExpression="NOVIEMBRE" />
            <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" ReadOnly="True" 
                SortExpression="DICIEMBRE" />
        </Columns>
            <EditRowStyle BackColor="#2461BF" />
   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                            Font-Size="Small" Font-Names="Arial" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" 
                HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Font-Size="Small" 
                            Font-Names="Arial" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" 
                ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1"  Width="1024px" Visible="False" Height="500px">
        <Series>
            <asp:Series Name="Series1" XValueMember="MES" YValueMembers="TOTAL" IsValueShownAsLabel="True">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX>
                    <LabelStyle Interval="1" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
       <div align="left">
       <asp:LinkButton ID="LBVerDetalles" runat="server" Font-Bold="True" 
           Font-Size="X-Large"  Visible="False" onclick="LBVerDetalles_Click">Ver Detalles</asp:LinkButton>
   </div>
   <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="981px">

    </rsweb:ReportViewer>

                    <asp:ObjectDataSource ID="ObjectTabla" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    
        
         
        TypeName="AtencionTemprana.dsReportesTableAdapters.SP_ConteoDenunciasMesesTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                            Type="Int32" />
                        <asp:ControlParameter ControlID="TxtFechaInicio" Name="Fecha1" 
                            PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TxtFechaFin" 
                            Name="Fecha2" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
        SelectCommand="SP_ConteoDenunciasMesesGrafica" 
        SelectCommandType="StoredProcedure">
             <SelectParameters>
                 <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                     Type="Int32" />
                 <asp:ControlParameter ControlID="TxtFechaInicio" Name="Fecha1" 
                     PropertyName="Text" Type="String" />
                 <asp:ControlParameter ControlID="TxtFechaFin" Name="Fecha2" PropertyName="Text" 
                     Type="String" />
             </SelectParameters>
    </asp:SqlDataSource>
         <br />
    </div>
        </asp:Content>