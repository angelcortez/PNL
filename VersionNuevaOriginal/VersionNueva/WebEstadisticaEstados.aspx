<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebEstadisticaEstados.aspx.cs" Inherits="AtencionTemprana.WebEstadisticaEstados" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    

    <table style="width:100%;">
        <tr>
            <td class="style4">
                </td>
            <td class="style5" valign="bottom">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#006600" 
                    Text="Estadística de Carpetas Iniciadas por Unidad, por Año"></asp:Label>
            </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style4">
                </td>
            <td class="style5" valign="bottom" align="center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Black" Text="AÑO"></asp:Label>
                <asp:TextBox ID="txtAño" runat="server" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="INGRESA AÑO" 
                    Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
&nbsp;<asp:Button ID="cmdGenerar" runat="server" onclick="cmdGenerar_Click" Text="GENERAR" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                    ForeColor="Red" />
            </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
    <asp:GridView ID="gvEstados" runat="server" Height="118px" Width="1024px" 
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ForeColor="Black" GridLines="Vertical" Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ALIAS" HeaderText="UNIDAD" ReadOnly="True" 
                SortExpression="ALIAS" />
            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" ReadOnly="True" 
                SortExpression="ESTADO" />
            <asp:BoundField DataField="ENERO" HeaderText="ENE" ReadOnly="True" 
                SortExpression="ENERO" />
            <asp:BoundField DataField="FEBRERO" HeaderText="FEB" ReadOnly="True" 
                SortExpression="FEBRERO" />
            <asp:BoundField DataField="MARZO" HeaderText="MAR" ReadOnly="True" 
                SortExpression="MARZO" />
            <asp:BoundField DataField="ABRIL" HeaderText="ABR" ReadOnly="True" 
                SortExpression="ABRIL" />
            <asp:BoundField DataField="MAYO" HeaderText="MAY" ReadOnly="True" 
                SortExpression="MAYO" />
            <asp:BoundField DataField="JUNIO" HeaderText="JUN" ReadOnly="True" 
                SortExpression="JUNIO" />
            <asp:BoundField DataField="JULIO" HeaderText="JUL" ReadOnly="True" 
                SortExpression="JULIO" />
            <asp:BoundField DataField="AGOSTO" HeaderText="AGO" ReadOnly="True" 
                SortExpression="AGOSTO" />
            <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEP" ReadOnly="True" 
                SortExpression="SEPTIEMBRE" />
            <asp:BoundField DataField="OCTUBRE" HeaderText="OCT" ReadOnly="True" 
                SortExpression="OCTUBRE" />
            <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOV" ReadOnly="True" 
                SortExpression="NOVIEMBRE" />
            <asp:BoundField DataField="DICIEMBRE" HeaderText="DIC" ReadOnly="True" 
                SortExpression="DICIEMBRE" />
        </Columns>
   <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                            Font-Size="Small" Font-Names="Arial" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#D8E2E2" HorizontalAlign="Center" Font-Size="Small" 
                            Font-Names="Arial" ForeColor="#006600" Font-Bold="True" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Chart ID="chEstados" runat="server" DataSourceID="SqlDataSource2" 
                    Height="600px" Palette="EarthTones" Width="1024px" onload="Chart1_Load" 
                    Visible="False">
                    <Series>
                        <asp:Series IsValueShownAsLabel="True" Name="Series1" XValueMember="ESTADO" 
                            YValueMembers="TOTAL" Font="Arial, 8.25pt, style=Bold" 
                            ChartType="Pie" Legend="Legend1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>

                    <Legends>
                        <asp:Legend LegendStyle="Column" Name="Legend1" Font="Arial, 7.25pt, style=Bold" ForeColor="#006600">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Name="Title1" Text="Gráfica de Carpetas Iniciadas por Estados" Font="Arial, 10pt, style=Bold" ForeColor="#006600">
                        </asp:Title>
                    </Titles>

                </asp:Chart>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ShowBackButton="False" 
                    ShowPageNavigationControls="False" ShowZoomControl="False" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1024px">
                    <LocalReport ReportPath="rpEstadoCarpeta.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="AtencionTemprana.dsReportesTableAdapters.ESTADISTICA_ESTADOS_AÑOTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" PropertyName="Text" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
        SelectCommand="ESTADISTICA_ESTADOS_AÑO" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAño" DefaultValue="" Name="Año" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
        SelectCommand="ESTADISTICA_ESTADOS_AÑO_GRAFICA" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAño" DefaultValue="" Name="Año" 
                PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

   
    </div>
</asp:Content>
