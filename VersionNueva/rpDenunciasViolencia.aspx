<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rpDenunciasViolencia.aspx.cs" Inherits="AtencionTemprana.rpDenunciasViolencia" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <h2> 
        <asp:Label ID="lblOperacion" runat="server" 
            ForeColor="#006600">DELITOS CON VIOLENCIA Y SIN VIOLENCIA</asp:Label></h2>

    <table style="width: 100%;">
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
        <tr>
            <td align="center" colspan="3">
                &nbsp;
                &nbsp;
                &nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Black" Text="AÑO"></asp:Label>
&nbsp;
                <asp:TextBox ID="txtAño" runat="server" MaxLength="4"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="INGRESA AÑO" 
                    Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdGenerar" runat="server" onclick="cmdGenerar_Click" 
                    Text="GENERAR" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                    ForeColor="Red" />
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" Height="350px" InteractiveDeviceInfos="(Collection)" 
                    ShowBackButton="False" ShowFindControls="False" 
                    ShowPageNavigationControls="False" ShowZoomControl="False" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="900px">
                    <LocalReport ReportPath="rpViolencia.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="AtencionTemprana.dsReportesTableAdapters.REPORTE_DELITOS_VIOLENCIATableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAño" Name="Año" PropertyName="Text" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>


   
    
    
    
    </ContentTemplate>
    </asp:UpdatePanel>
    
</div>

</asp:Content>

