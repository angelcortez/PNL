<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebEstadisticaIniciadas.aspx.cs" Inherits="AtencionTemprana.WebEstadisticaIniciadas" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
        }
        .style3
        {
            width: 250px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main-wrapper">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table style="width: 100%;">
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                     class="color-fuente" 
                    Text="Estadística de Carpetas Iniciadas por Unidad, por Año"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Black" Text="AÑO"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:TextBox ID="txtAño" runat="server" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="INGRESA AÑO" 
                    Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                &nbsp;<asp:Button ID="cmdGenerar" runat="server" onclick="cmdGenerar_Click" 
                    Text="&gt;&gt;" />
                </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                    ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MUNICIPIO"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                    <asp:DropDownList ID="ddlMunicipio" runat="server" Width="300px" 
                        Enabled="False">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="cmdMunicipio" runat="server" Text="&gt;&gt;" 
                        onclick="cmdMunicipio_Click" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                    <asp:Label ID="lblNuc0" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="UNIDAD"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                    <asp:DropDownList ID="ddlUnidad" runat="server" Width="300px" 
                    Enabled="False">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="cmdUnidad" runat="server" Text="&gt;&gt;" Enabled="False" 
                        onclick="cmdUnidad_Click" />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
    <asp:GridView ID="gvIniciada" runat="server" Height="118px" Width="1100px" 
        AutoGenerateColumns="False" DataSourceID="dsIniciadasAñoGV" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
             <asp:BoundField DataField="ALIAS" HeaderText="UNIDAD" ReadOnly="True" 
                SortExpression="ALIAS" />
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
            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" ReadOnly="True" 
                SortExpression="TOTAL" />
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
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Chart ID="chIniciada" runat="server" DataSourceID="dsIniciadasAñoGrafica" 
                    Height="400px" Palette="EarthTones" Width="1100px" Visible="False">
                    <Series>
                        <asp:Series IsValueShownAsLabel="True" Name="Series1" XValueMember="UNIDAD" Font="Arial, 8.25pt, style=Bold" Palette="Pastel" 
                            YValueMembers="TOTAL">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Name="Title1" Text="Gráfica de Carpetas Iniciadas por mes" Font="Arial, 10pt, style=Bold" ForeColor="#006600">
                        </asp:Title>
                    </Titles>

                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" colspan="3">
                <asp:SqlDataSource ID="dsIniciadasAñoGV" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                    SelectCommand="ESTADISTICA_INICIADAS_AÑO" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" 
                            PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsIniciadasAñoGrafica" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                    SelectCommand="ESTADISTICA_INICIADAS_AÑO_GRAFICA" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" 
                            PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsIniciadasAñoMunicipioGV" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                    SelectCommand="ESTADISTICA_INICIADAS_AÑO_MUNICIPIO" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" PropertyName="Text" 
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlMunicipio" Name="IdMunicipio" 
                            PropertyName="SelectedValue" Type="Int16" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsIniciadasAñoMunicipioGrafica" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                    SelectCommand="ESTADISTICA_INICIADAS_AÑO_MUNICIPIO_GRAFICA" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" PropertyName="Text" 
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlMunicipio" Name="IdMunicipio" 
                            PropertyName="SelectedValue" Type="Int16" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsIniciadasAñoMunicipioUnidadGV" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                    SelectCommand="ESTADISTICA_INICIADAS_AÑO_MUNICIPIO_UNIDAD" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" PropertyName="Text" 
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlMunicipio" Name="IdMunicipio" 
                            PropertyName="SelectedValue" Type="Int16" />
                        <asp:ControlParameter ControlID="ddlUnidad" Name="IdUnidad" 
                            PropertyName="SelectedValue" Type="Int16" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="dsIniciadasAñoMunicipioUnidadGrafica" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                    SelectCommand="ESTADISTICA_INICIADAS_AÑO_MUNICIPIO_UNIDAD_GRAFICA" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" PropertyName="Text" 
                            Type="Int32" />
                        <asp:ControlParameter ControlID="ddlMunicipio" Name="IdMunicipio" 
                            PropertyName="SelectedValue" Type="Int16" />
                        <asp:ControlParameter ControlID="ddlUnidad" Name="IdUnidad" 
                            PropertyName="SelectedValue" Type="Int16" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

   </div>
</asp:Content>
