﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WReporte5.aspx.cs" Inherits="AtencionTemprana.WReporte5" %>
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
                <asp:Label ID="IdUn" runat="server" Visible="False"></asp:Label>
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
                        Text="Conteo de denuncias por delito." Width="1089px"></asp:Label>
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
            <asp:BoundField DataField="DELITO" HeaderText="DELITO" ReadOnly="True" 
                SortExpression="DELITO" />
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
     <asp:ObjectDataSource ID="ObjectTabla" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    
        
             TypeName="AtencionTemprana.dsReportesTableAdapters.SP_ConteoDelitosTablaTableAdapter">
                    <SelectParameters>
                        <asp:SessionParameter Name="IdUnidad" 
                            SessionField="Session[&quot;IdUnidad&quot;]" Type="Int32" />
                        <asp:ControlParameter ControlID="TxtFechaInicio" Name="Fecha1" PropertyName="Text" 
                            Type="String" />
                        <asp:ControlParameter ControlID="TxtFechaFin" Name="Fecha2" 
                            PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataGrafica" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
        SelectCommand="SP_ConteoDelitosGrafica" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="IdUn" Name="IdUnidad" PropertyName="Text" 
                Type="Int32" />
            <asp:ControlParameter ControlID="TxtFechaInicio" Name="Fecha1" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TxtFechaFin" Name="Fecha2" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
                <br />

    <asp:Chart ID="ChartEstados" runat="server" BorderlineWidth="100" 
        DataSourceID="SqlDataGrafica" Width="1024px" Visible="False" Height="500px">
        <Series>
                       <asp:Series IsValueShownAsLabel="True" Name="Series1" XValueMember="Delito" 
                            YValueMembers="TOTAL" Font="Arial, 8.25pt, style=Bold" 
                            ChartType="Pie" Legend="Legend1">
              
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
                   <Legends>
                        <asp:Legend LegendStyle="Column" Name="Legend1" Font="Arial, 7.25pt, style=Bold" ForeColor="#006600">
                        </asp:Legend>
                    </Legends>
                                     
                            <Titles>
                        <asp:Title Name="Title1" Text="Gráfica de Carpetas Iniciadas por Delitos" Font="Arial, 10pt, style=Bold" ForeColor="#0064A7" >
                        </asp:Title>
                    </Titles>
        <BorderSkin BorderWidth="5" />
    </asp:Chart>
    <br />
       <div align="left">
       <asp:LinkButton ID="LBVerDetalles" runat="server" Font-Bold="True" 
           Font-Size="X-Large"  Visible="False" onclick="LBVerDetalles_Click">Ver Detalles</asp:LinkButton>
   </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="981px">

    </rsweb:ReportViewer>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>
