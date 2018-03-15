<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WReporte2.aspx.cs" Inherits="AtencionTemprana.WReporte2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
                        Text="Conteo de denuncias por estado de la carpeta." Width="1089px"></asp:Label>
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
                                               <asp:CalendarExtender ID="TxtFechaFinCalendarExtender" runat="server" Enabled="True"
                                                Format="dd/MM/yyyy" TargetControlID="TxtFechaFin">
                                            </asp:CalendarExtender>
                        </td>
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
            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" ReadOnly="True" 
                SortExpression="ESTADO" />
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
                    <asp:ObjectDataSource ID="ObjectTabla" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    
        TypeName="AtencionTemprana.dsReportesTableAdapters.ESTADISTICA_ESTADOSTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtFechaInicio" Name="fechainicio" PropertyName="Text" 
                            Type="String" />
                        <asp:ControlParameter ControlID="TxtFechaFin" Name="fechafin" 
                            PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="IdMunicipio" DefaultValue="" 
                            Name="IdMunicipio" PropertyName="Text" Type="Int16" />
                        <asp:ControlParameter ControlID="IdUnidad" DefaultValue="" Name="IdUnidad" 
                            PropertyName="Text" Type="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <asp:SqlDataSource ID="SqlDataGrafica" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
        SelectCommand="ESTADISTICA_ESTADOS_GRAFICA" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtFechaInicio" Name="fechainicio" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TxtFechaFin" Name="fechafin" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                PropertyName="Text" Type="Int16" />
            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
                <br />

    <asp:Chart ID="ChartEstados" runat="server" BorderlineWidth="100" 
        DataSourceID="SqlDataGrafica" Palette="None" Width="1024px" 
        PaletteCustomColors="Blue" Visible="False">
        <Series>
                       <asp:Series IsValueShownAsLabel="True" Name="Series1" XValueMember="ESTADO" 
                            YValueMembers="TOTAL" Font="Arial, 8.25pt, style=Bold" 
                            ChartType="Line" Legend="Legend1">
              
<%--            <asp:Series IsValueShownAsLabel="True" Name="Series1" ChartType="Line" XValueMember="ESTADO" 
                YValueMembers="TOTAL" Legend="Legend1">--%>
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
                            <Titles>
                        <asp:Title Name="Title1" Text="Gráfica de Carpetas Iniciadas por Estados" Font="Arial, 10pt, style=Bold" ForeColor="#0064A7" >
                        </asp:Title>
                    </Titles>
        <BorderSkin BorderWidth="5" />
    </asp:Chart>
       <div align="left">
       <asp:LinkButton ID="LBVerDetalles" runat="server" Font-Bold="True" 
           Font-Size="X-Large"  Visible="False" onclick="LBVerDetalles_Click">Ver Detalles</asp:LinkButton>
   </div>
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="981px">

    </rsweb:ReportViewer>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>
