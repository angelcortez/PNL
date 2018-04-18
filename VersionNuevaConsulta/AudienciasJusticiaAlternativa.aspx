<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AudienciasJusticiaAlternativa.aspx.cs" Inherits="AtencionTemprana.AudienciasJusticiaAlternativa" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="right">
                 &nbsp;</td>
         </tr>
     
      
    </table>

        <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="cmdAsistieron" runat="server" onclick="cmdAsistieron_Click" 
                        Text="ASISTIERON" Width="200px" />
                </td>
                <td>
                    <asp:Button ID="cmdRep" runat="server" onclick="cmdRep_Click" 
                        Text="REPROGRAMACION" Width="200px" />
                </td>
                <td>
                    <asp:Button ID="cmdAudiencia" runat="server" onclick="cmdAudiencia_Click" 
                        Text="OTRA AUDIENCIA" Width="200px" />
                </td>
                <td>
                    <asp:Button ID="cmdAcuerdo" runat="server" onclick="cmdAcuerdo_Click" 
                        Text="ACUERDO" Width="200px" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>

        <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    <asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBuscar_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">POR:</asp:ListItem>
                        <asp:ListItem Value="1">NUM</asp:ListItem>
                        <asp:ListItem Value="2">FECHA AUDIENCIA</asp:ListItem>
                        <asp:ListItem Value="3">FACILITADOR</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblNum" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NUM" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNum" runat="server" Visible="False"></asp:TextBox>
                    <asp:Label ID="lblFechaInicio" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicio" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblFechaFin" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFin" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFin">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblFacilitador" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FACILITADOR" Visible="False"></asp:Label>
                    <asp:DropDownList ID="ddlFacilitador" runat="server" Visible="False" 
                        Width="250px">
                    </asp:DropDownList>
                    <asp:Button ID="cmdAceptar" runat="server" onclick="cmdAceptar_Click" 
                        Text="ACEPTAR" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHoy" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Black" Text="Audiencias para el día de hoy:"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:GridView ID="gvNuc" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" DataKeyNames="ID_CARPETA" DataSourceID="dsConsultaNuc" 
                        ForeColor="Black" GridLines="Vertical" onrowdatabound="gvNuc_RowDataBound" 
                        Width="928px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" ReadOnly="True" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="ID_AUDIENCIA" ShowHeader="False" 
                                SortExpression="ID_AUDIENCIA">
                            <ControlStyle Width="0px" />
                            <FooterStyle Width="0px" />
                            <HeaderStyle Width="0px" />
                            <ItemStyle Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NUM" HeaderText="NUM" ReadOnly="True" 
                                SortExpression="NUM" />
                            <asp:BoundField DataField="FECHA_AUDIENCIA" HeaderText="FECHA_AUDIENCIA" 
                                ReadOnly="True" SortExpression="FECHA_AUDIENCIA" />
                            <asp:BoundField DataField="HORA_AUDIENCIA" HeaderText="HORA_AUDIENCIA" 
                                SortExpression="HORA_AUDIENCIA" />
                            <asp:BoundField DataField="AUDIENCIA" HeaderText="AUDIENCIA" ReadOnly="True" 
                                SortExpression="AUDIENCIA" />
                            <asp:BoundField DataField="FACILITADOR" HeaderText="FACILITADOR" 
                                ReadOnly="True" SortExpression="FACILITADOR" />
                            <asp:BoundField DataField="SALA" HeaderText="SALA" SortExpression="SALA" />
                            <asp:BoundField DataField="ESTATUS" HeaderText="ESTATUS" ReadOnly="True" 
                                SortExpression="ESTATUS" />
                            <asp:TemplateField HeaderText=" ">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chbSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
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
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMañana" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Black" Text="Audiencias para mañana:"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:GridView ID="gvNuc1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" DataSourceID="dsConsultaAudienciaMañana" 
                        ForeColor="Black" GridLines="Vertical" onrowdatabound="gvNuc_RowDataBound" 
                        Width="928px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="ID_AUDIENCIA" 
                                SortExpression="ID_AUDIENCIA" HeaderText="ID_AUDIENCIA" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="NUM" HeaderText="NUM" ReadOnly="True" 
                                SortExpression="NUM" />
                            <asp:BoundField DataField="FECHA_AUDIENCIA" HeaderText="FECHA_AUDIENCIA" 
                                ReadOnly="True" SortExpression="FECHA_AUDIENCIA" />
                            <asp:BoundField DataField="HORA_AUDIENCIA" HeaderText="HORA_AUDIENCIA" 
                                SortExpression="HORA_AUDIENCIA" />
                            <asp:BoundField DataField="AUDIENCIA" HeaderText="AUDIENCIA" ReadOnly="True" 
                                SortExpression="AUDIENCIA" />
                            <asp:BoundField DataField="FACILITADOR" HeaderText="FACILITADOR" 
                                SortExpression="FACILITADOR" />
                            <asp:BoundField DataField="SALA" HeaderText="SALA" SortExpression="SALA" />
                            <asp:BoundField DataField="ESTATUS" HeaderText="ESTATUS" ReadOnly="True" 
                                SortExpression="ESTATUS" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
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
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblProximas" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Black" Text="Audiencias próximas:"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:GridView ID="gvNuc2" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" DataSourceID="dsConsultaAudienciaSiguiente" ForeColor="Black" 
                        GridLines="Vertical" onrowdatabound="gvNuc_RowDataBound" Width="928px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="ID_AUDIENCIA" HeaderText="ID_AUDIENCIA" 
                                SortExpression="ID_AUDIENCIA" Visible="False" />
                            <asp:BoundField DataField="NUM" HeaderText="NUM" ReadOnly="True" 
                                SortExpression="NUM" />
                            <asp:BoundField DataField="FECHA_AUDIENCIA" HeaderText="FECHA_AUDIENCIA" 
                                ReadOnly="True" SortExpression="FECHA_AUDIENCIA" />
                            <asp:BoundField DataField="HORA_AUDIENCIA" HeaderText="HORA_AUDIENCIA" 
                                SortExpression="HORA_AUDIENCIA" />
                            <asp:BoundField DataField="AUDIENCIA" HeaderText="AUDIENCIA" ReadOnly="True" 
                                SortExpression="AUDIENCIA" />
                            <asp:BoundField DataField="FACILITADOR" HeaderText="FACILITADOR" 
                                SortExpression="FACILITADOR" />
                            <asp:BoundField DataField="SALA" HeaderText="SALA" SortExpression="SALA" />
                            <asp:BoundField DataField="ESTATUS" HeaderText="ESTATUS" ReadOnly="True" 
                                SortExpression="ESTATUS" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
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
        </table>
     
                <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" 
                        style="font-weight: 700; color: #FF3300; font-size: medium;"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="dsConsultaNuc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaAudienciaMediacion" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsConsultaAudienciaMañana" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaAudienciaMediacionMañana" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsConsultaAudienciaSiguiente" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaAudienciaMediacionSiguientes" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarNum" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionNUM" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNum" Name="NUM" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarNumMañana" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionNUMMañana" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNum" Name="NUM" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarNumSiguiente" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionNUMSiguientes" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNum" Name="NUM" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFechas" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionFechaAudiencia" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaInicio" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFin" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFechasMañana" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionFechaAudienciaMañana" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaInicio" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFin" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFechasSiguiente" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionFechaAudienciaSiguientes" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaInicio" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFin" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFacilitador" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionFacilitador" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="ddlFacilitador" Name="IdFacilitador" 
                                PropertyName="SelectedValue" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFacilitadorMañana" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionFacilitadorMañana" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="ddlFacilitador" Name="IdFacilitador" 
                                PropertyName="SelectedValue" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFacilitadorSiguiente" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarAudienciaMediacionFacilitadorSiguientes" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="ddlFacilitador" Name="IdFacilitador" 
                                PropertyName="SelectedValue" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>

    
    
    
</div>


</asp:Content>

