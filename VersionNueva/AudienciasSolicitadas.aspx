<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AudienciasSolicitadas.aspx.cs" Inherits="AtencionTemprana.AudienciasSolicitadas" %>
<%@ Register assembly="EventCalendar" namespace="ExtendedControls" tagprefix="ECalendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function mostrarFichero(destino) {
        window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
        document.forms(0).submit();
    }
    
    </script>
    <div id="main-wrapper">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
    <asp:PostBackTrigger ControlID="gvNuc" />
    </Triggers>
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
                <td align="left" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp; &nbsp;</td>
            </tr>
            <tr>
                <td align="center" style="text-align: left" class="style2" >
                   
                    <asp:Button ID="btnNotificacion" runat="server" onclick="btnNotificacion_Click" 
                        Text="Notificacion de Audiencia" />
                    <asp:Label ID="Label1" runat="server" 
                        style="font-weight: 700; color: #FF3300; font-size: medium;"></asp:Label>
                   
                    </td>
                      <td align="center" >
                   
                          &nbsp;</td>
                      <td align="center" style="text-align: right" >
                   
                          <asp:ImageButton ID="ImageButton1" runat="server" Height="63px" 
                              ImageUrl="~/img/ICONO_Agenda.png" onclick="ImageButton1_Click" Width="79px" />
                   
                    </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    &nbsp;<asp:GridView ID="gvNuc" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="1050px" 
                        AutoGenerateColumns="False" DataSourceID="dsSolicitudesAudiencias" 
                        AllowPaging="True" onrowcommand="gvNuc_RowCommand" 
                        onrowdatabound="gvNuc_RowDataBound" 
                        onselectedindexchanged="gvNuc_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id_Solicitud" HeaderText="Id_Solicitud" 
                                SortExpression="Id_Solicitud" />
                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="CARPETA_INCIO" HeaderText="CARPETA_INCIO" 
                                ReadOnly="True" SortExpression="CARPETA_INCIO" Visible="False" />
                            <asp:BoundField DataField="ID_MUNICIPIO" HeaderText="ID_MUNICIPIO" 
                                SortExpression="ID_MUNICIPIO" Visible="False" />
                            <asp:BoundField DataField="ID_UNDD" HeaderText="ID_UNDD" 
                                SortExpression="ID_UNDD" Visible="False" />
                            <asp:BoundField DataField="NUC" HeaderText="NUC" ReadOnly="True" 
                                SortExpression="NUC" />
                            <asp:BoundField DataField="FECHA_NUC" HeaderText="FECHA_NUC" ReadOnly="True" 
                                SortExpression="FECHA_NUC" Visible="False" />
                            <asp:BoundField DataField="ID_ESTADO_NUC" HeaderText="ID_ESTADO_NUC" 
                                ReadOnly="True" SortExpression="ID_ESTADO_NUC" Visible="False" />
                            <asp:BoundField DataField="Fecha_Hora_Solicitud" HeaderText="Fecha Solicitud" 
                                ReadOnly="True" SortExpression="Fecha_Hora_Solicitud" />
                            <asp:BoundField DataField="Tipo_Solicitud_Audiencia" 
                                HeaderText="Solicitud de Audiencia" SortExpression="Tipo_Solicitud_Audiencia" />
                            <asp:TemplateField HeaderText="Notificacion Recibida">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chbNotificado" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ESTADO_CARPETA" HeaderText="ESTADO_CARPETA" 
                                ReadOnly="True" SortExpression="ESTADO_CARPETA" Visible="False" />
                            <asp:BoundField DataField="RECEPCION_TRIBUNAL" HeaderText="Fecha Recepcion STJ" 
                                ReadOnly="True" SortExpression="RECEPCION_TRIBUNAL" />
                            <asp:BoundField DataField="FechaHoraAudiencia" HeaderText="Fecha Audiencia" 
                                ReadOnly="True" SortExpression="FechaHoraAudiencia" />
                            <asp:BoundField DataField="FechaHoraNotificacionPGJ" 
                                HeaderText="Fecha NotificacionPGJ" ReadOnly="True" 
                                SortExpression="FechaHoraNotificacionPGJ" />
                            <asp:BoundField DataField="FechaHoraNotificacion" 
                                HeaderText="FechaHoraNotificacion" ReadOnly="True" 
                                SortExpression="FechaHoraNotificacion" Visible="False" />
                            <asp:CommandField ButtonType="Button" SelectText="Documento" 
                                ShowSelectButton="True" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label2" runat="server" 
                                style="font-weight: 700; color: #FF3300; font-size: x-large;" 
                                Text="NO EXISTEN SOLICITUDES"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#CCCC99" />
                          <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                                                        HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <RowStyle BackColor="#CCFFCC" 
                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="dsSolicitudesAudiencias" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaSolicitudesAudiencias" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                  
                    
                    <asp:SqlDataSource ID="dsSolicitudesAudiencias1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaSolicitudesAudienciasDESC" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                  
                    
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaSolicitudesAudienciasFECHA_AUDIENCIA" 
                        SelectCommandType="StoredProcedure" 
                        ProviderName="<%$ ConnectionStrings:PGJ_NSJPConnectionString2.ProviderName %>">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:SessionParameter DefaultValue="" Name="FechaAudiencia" SessionField="a" 
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                  
                    
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
              <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp; &nbsp;<ECalendar:EventCalendar ID="Calendar1" 
                        runat="server" BackColor="#CCCCCC" BorderColor="#FFCC66" BorderWidth="1px" 
                        EventDateColumnName="" EventDescriptionColumnName="" EventHeaderColumnName="" 
                        FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                        Height="457px" NextMonthText="Next &gt;" NextPrevFormat="FullMonth" 
                        OnSelectionChanged="Calendar1_SelectionChanged" PrevMonthText="&lt; Prev" 
                        SelectionMode="DayWeekMonth" ShowDescriptionAsToolTip="True" 
                        ShowGridLines="True" Width="1000px" Visible="False">
                        <SelectedDayStyle BackColor="#FF9933" Font-Bold="True" />
                        <TodayDayStyle BackColor="#FF6600" ForeColor="White" />
                        <SelectorStyle BackColor="#00CC66" BorderColor="#404040" BorderStyle="Solid" />
                        <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                        <DayHeaderStyle BackColor="#CCCCCC" BorderWidth="1px" Font-Bold="True" 
                            Height="1px" />
                        <TitleStyle BackColor="#006600" Font-Bold="True" Font-Size="9pt" 
                            ForeColor="#FFFFCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </ECalendar:EventCalendar>
                    &nbsp;</td>
            </tr>
        </table>
          
    </ContentTemplate>
    </asp:UpdatePanel>
    
</div>
</asp:Content>
