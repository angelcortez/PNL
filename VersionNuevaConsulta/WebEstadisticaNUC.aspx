<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebEstadisticaNUC.aspx.cs" Inherits="AtencionTemprana.WebEstadisticaNUC" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="DevExpress.XtraReports.v10.1.Web, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 296px;
            height: 19px;
        }
        .style7
        {
            width: 684px;
            height: 19px;
        }
        .style8
        {
            height: 19px;
        }
        .style11
        {
            width: 684px;
        }
        .style15
        {
            width: 414px;
        }
        .style17
        {
            width: 336px;
        }
        .style18
        {
        }
        .style22
        {
            height: 47px;
        }
        .style25
        {
            height: 47px;
        }
        .style27
        {
            width: 336px;
            height: 19px;
        }
        .style28
        {
            height: 58px;
        }
        .bordeCampoObligatorio
        {
            border-style: solid;
            border-color:#FF0000;
            border-bottom-width:1px;
            border-top-width:1px;
            border-left-width:1px;
            border-right-width:1px;
        }
        #seccionTabla
        { 
            visibility: hidden;
        }
        #seccionReporte
        {
            visibility:hidden;
        }
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
       <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
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

        <table style="width: 109%;">
            <tr>
                <td class="style28" colspan="4">
                    &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Large" class="color-fuente" style="text-align: center" 
                        Text="Carpetas Iniciadas" Width="1089px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        class="color-fuente" Text="Fecha Inicial" Width="200px"></asp:Label>

                </td>
                <td class="style27">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        class="color-fuente" Text="Fecha Final" Width="200px"></asp:Label>

                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                    <asp:TextBox ID="TxtFecha1" runat="server" MaxLength="10" TabIndex="20" class="bordeCampoObligatorio"
                        Width="190px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFecha1_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFecha1">
                    </asp:CalendarExtender>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="TxtFecha1" Display="Dynamic" ErrorMessage="FECHA INVALIDA" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/9999" 
                        MinimumValue="01/01/2013">*</asp:RangeValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TxtFecha1" Display="Dynamic" ErrorMessage="SELECCIONA FECHA INICIAL" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td class="style27">
                    &nbsp;
                    <asp:TextBox ID="TxtFecha2" runat="server" MaxLength="10" TabIndex="20" class="bordeCampoObligatorio"
                        Width="190px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFecha2_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="TxtFecha2">
                    </asp:CalendarExtender>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                        ControlToValidate="TxtFecha2" Display="Dynamic" ErrorMessage="FECHA INVALIDA" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/9999" 
                        MinimumValue="01/01/2013">*</asp:RangeValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TxtFecha2" Display="Dynamic" ErrorMessage="SELECCIONA FECHA FINAL" 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td class="style7">
                    <asp:Button ID="CmdFiltrar" runat="server" onclick="CmdFiltrar_Click" 
                        Text="Seleccionar Rango" Width="149px" class="button" />
                </td>
                <td class="style8">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp;
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style22" colspan="3" id="seccionTabla" runat="server">
                    &nbsp;
                    <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" 
                        DataSourceID="SqlDataSource1" Width="1100px">
                        <Fields>
                            <dx:PivotGridField ID="fieldUNIDAD" AreaIndex="0" 
                                FieldName="UNIDAD">
                            </dx:PivotGridField>
                            <dx:PivotGridField ID="fieldDELITO" Area="RowArea" AreaIndex="0" 
                                FieldName="DELITO">
                            </dx:PivotGridField>
                            <dx:PivotGridField ID="fieldTOTAL" Area="DataArea" AreaIndex="0" 
                                FieldName="TOTAL">
                            </dx:PivotGridField>
                            <dx:PivotGridField ID="fieldESTADO" AreaIndex="0" FieldName="ESTADO" 
                                Area="ColumnArea">
                            </dx:PivotGridField>
                        </Fields>
                        <OptionsView ShowHorizontalScrollBar="True" />
                        <OptionsLoadingPanel>
                            <Image Url="~/App_Themes/Aqua/PivotGrid/Loading.gif">
                            </Image>
                        </OptionsLoadingPanel>
                        <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                            <CustomizationFieldsBackground Url="~/App_Themes/Aqua/PivotGrid/pcHeaderBack.gif">
                            </CustomizationFieldsBackground>
                            <LoadingPanel Url="~/App_Themes/Aqua/PivotGrid/Loading.gif">
                            </LoadingPanel>
                        </Images>
                        <ImagesEditors>
                            <DropDownEditDropDown>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                                    PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                            </DropDownEditDropDown>
                            <SpinEditIncrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua" 
                                    PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua" />
                            </SpinEditIncrement>
                            <SpinEditDecrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua" 
                                    PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua" />
                            </SpinEditDecrement>
                            <SpinEditLargeIncrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua" 
                                    PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua" />
                            </SpinEditLargeIncrement>
                            <SpinEditLargeDecrement>
                                <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua" 
                                    PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua" />
                            </SpinEditLargeDecrement>
                            <LoadingPanel Url="~/App_Themes/Aqua/Editors/Loading.gif">
                            </LoadingPanel>
                        </ImagesEditors>
                        <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                            CssPostfix="Aqua">
                            <MenuStyle GutterWidth="0px" />
                        </Styles>
                    </dx:ASPxPivotGrid>
                </td>
                <td class="style25">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" 
                        SelectCommand="Reporte_Carpetas_Iniciadas_Unidad" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="" Name="IdUnidad" SessionField="IdUnidad" 
                                Type="Int32" />
                            <asp:ControlParameter ControlID="TxtFecha1" DefaultValue="" Name="Fecha1" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TxtFecha2" Name="Fecha2" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td class="style11" colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style17">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18" colspan="3" id="seccionReporte" runat="server">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ShowBackButton="False" 
                        ShowZoomControl="False" style="margin-right: 0px" 
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1100px">
                        <LocalReport ReportPath="ReporteCarpetasIniciadas.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                        
                        TypeName="AtencionTemprana.DSRepIniciadasNUCTableAdapters.Reporte_Carpetas_Iniciadas_UnidadTableAdapter">
                        <SelectParameters>
                            <asp:SessionParameter Name="IdUnidad" SessionField="IdUnidad" Type="Int32" />
                            <asp:ControlParameter ControlID="TxtFecha1" Name="Fecha1" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="TxtFecha2" Name="Fecha2" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
            
            <tr>


                <td class="style18" colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    </div>
</asp:Content>
