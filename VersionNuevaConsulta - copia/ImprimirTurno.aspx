<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImprimirTurno.aspx.cs" Inherits="AtencionTemprana.ImprimirTurno" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
       <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="Black" style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
    </table>    
     

      
<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <h2>IMPRIMIR TURNO</h2>

        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="turno_id" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                        Font-Size="8pt" Height="300px" InteractiveDeviceInfos="(Collection)" 
                        ShowBackButton="False" ShowFindControls="False" 
                        ShowPageNavigationControls="False" ShowRefreshButton="False" 
                        ShowZoomControl="False" WaitMessageFont-Names="Verdana" 
                        WaitMessageFont-Size="14pt" Width="300px" DocumentMapCollapsed="True" 
                        DocumentMapWidth="10px">
                        <LocalReport ReportPath="rpTurno.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                        TypeName="AtencionTemprana._nsjp_pgDataSetTableAdapters.imprimirTurnoTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="turno_id" Name="Turno_id" PropertyName="Text" 
                                Type="Decimal" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    &nbsp; &nbsp; &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
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

