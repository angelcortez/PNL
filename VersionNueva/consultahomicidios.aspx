<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consultahomicidios.aspx.cs" Inherits="AtencionTemprana.consultahomicidios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">

       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <Triggers>
      <asp:PostBackTrigger ControlID="cmdExportarExcel" />
   </Triggers>
    <ContentTemplate>
      <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Font-Size="Medium"></asp:Label>
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
    
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblServidores" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SERVIDORES" Visible="false"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="ddlServidores" runat="server" Visible="false" Height="18px" Width="196px"> 
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="cmdConectar" runat="server"  Text="CONECTAR" 
                        Visible="false" Width="140px" onclick="cmdConectar_Click" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        <%--    <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="AGREGAR USUARIO"></asp:Label>
                    &nbsp;
                    <asp:Button ID="cmdUsuario" runat="server" Text="+" onclick="cmdUsuario_Click" 
                        Width="40px" />
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
                    &nbsp; &nbsp;
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="900px" AllowPaging="True" 
                        AutoGenerateColumns="False" DataSourceID="dsConsulrtaUsuario">
                        <Columns>
                        <asp:TemplateField HeaderText=" ">
                                                    <ItemTemplate>
                                                    <a href='Usuarios.aspx?ID_USUARIO=<%#Eval("ID_USUARIO")%>&amp;op=Modificar&amp;'>
                                                    
                                                    <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" /></a>
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField>
                            <asp:BoundField DataField="ID_USUARIO" HeaderText="ID_USUARIO" 
                                SortExpression="ID_USUARIO" Visible="False" />
                            <asp:BoundField DataField="PTRNO" HeaderText="PATERNO" SortExpression="PTRNO" />
                            <asp:BoundField DataField="MTRNO" HeaderText="MATERNO" SortExpression="MTRNO" />
                            <asp:BoundField DataField="NMBRE" HeaderText="NOMBRE" SortExpression="NMBRE" />
                            <asp:BoundField DataField="FCHA_ALTA" HeaderText="FECHA ALTA" 
                                SortExpression="FCHA_ALTA" />
                            <asp:CheckBoxField DataField="ACTVO" HeaderText="ACTIVO" 
                                SortExpression="ACTVO" />
                        </Columns>
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
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:SqlDataSource ID="dsConsulrtaUsuario" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaUsuario" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblip" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="0" Visible="false"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblMunicipio" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="0" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFechaInicio" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicio" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicioOrden_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                    </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ErrorTooltipEnabled="True"
                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFechaInicio" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td>
                    
                    <asp:Label ID="lblFechaFin" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFin" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFin">
                    </asp:CalendarExtender>
                     <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ErrorTooltipEnabled="True"
                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" TargetControlID="txtFechaFin" />
                    &nbsp;&nbsp;&nbsp;
                                        
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblModalidad" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="MODALIDAD" Visible="False"></asp:Label>
                </td>
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
                <td>
                    
                    <asp:Button ID="cmdAceptar" runat="server" onclick="cmdAceptar_Click" 
                        Text="BUSCAR" Visible="False" />
                    
                    </td>
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
                <td colspan="3">
                     <div id="container_1">

                 <asp:Panel ID="PanelHomicidios" runat="server" GroupingText="Reporte" Width="900px" Height="700px" ScrollBars="Both" Visible="false">

                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsConsultaHomicidios">
                        <HeaderTemplate>
                         
                            <table style="width: 100%" border="1" cellpadding=2 cellspacing="0"   bordercolor="#6D6D6D">
                            
                                <tr>
                                    <!--
                                     <th>
                                        <asp:Label runat="server" ID="Label48" Font-Size="11px" ForeColor="Black" Font-Bold="true" Visible="false"
                                            Text="ID_CARPETA" />
                                    </th>
                                    -->

                                     <th>
                                                <asp:Label runat="server" ID="Label490" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ID_CARPETA" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label440" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_REPORTE" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label430" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="HORA_REPORTE" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label420" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_EVENTO" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label410" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PAIS_EVN" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label400" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ESTADO_EVN" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label39" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="MUNICIPIO_EVN" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label38" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="LOCALIDAD_EVN" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label45" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="COLONIA_EVN" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label37" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NO_EXTERIOR" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label36" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="DESCRIPCION_HECHOS" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label35" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="APELLIDO_PATERNO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label34" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="APELLIDO_MATERNO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label33" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NOMBRE_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label32" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text=" NACIONALIDAD_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label31" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="SEXO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label480" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_NAC_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label51" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="EDAD_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label52" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="SEÑAS_PARTICULARES" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label53" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="MEDIA_FILIACION_NL" />
                                            </th>
                                            
                                            <th>
                                                <asp:Label runat="server" ID="Label54" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_ULTIMO_AVISTAMIENTO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label55" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PAIS_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label56" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ESTADO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label57" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="MUNICIPIO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label58" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="LOCALIDAD_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label59" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="COLONIA_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label60" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NUMERO_EXT_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label61" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NUM_INT_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label62" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="CP_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label63" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PROCEDENCIA_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label64" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PAIS_DE_ORIGEN" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label65" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ENTIDAD_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label66" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="COMPLEXION_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label67" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PESO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label68" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ESTATURA_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label69" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="TEZ_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label70" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NUMERO_NL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label71" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="APELLIDO_PATERNO_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label72" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="APELLIDO_MATERNO_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label73" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NOMBRE_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label74" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PARENTESCO_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label75" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PAIS_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label76" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ESTADO_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label77" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="MUNICIPIO_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label78" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="LOCALIDAD_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label79" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="COLONIA_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label80" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NUM_INT" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label81" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NUM_EXTERIOR" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label82" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="CP_D" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label83" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="AGENCIA_MP" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label84" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="AGENTE_MP" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label85" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="AVERIGUACION_PREVIA" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label86" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ACTA_CIRCUNSTANCIADA" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label87" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="CARPETA_INVESTIGACION" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label88" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_INICIO" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label89" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ESTADO_ACTUAL" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label90" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_CONLUYE" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label91" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_LOCALIZACION_LO" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label92" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="VIVO_MUERTO_LO" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label93" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="POSIBLE_CAUSA_DESAPARICION_LO" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label94" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="CONDICION_ENCONTRADO_LO" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label95" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PAIS_LUGAR_HALLAZGO_LO" />
                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label96" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="ESTADO_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label97" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="MUNICIPIO_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label98" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="LOCALIDAD_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label99" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="COLONIA_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label100" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NO_INTERIOR_LUGAR_HALLAZGO_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label101" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NO_EXTERIOR_LUGAR_HALLAZGO_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label102" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="CP_LUGAR_HALLAZGO_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="lblLugarHallazgo" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="LUGAR_HALLAZGO_LO" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label103" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="FECHA_INGRESO_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label104" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="CAUSAS_FALLECIMIENTO_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label105" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PATERNO_RECLAMA_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label106" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="MATERNO_RECLAMA_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label107" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NOMBRE_RECLAMA" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label108" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PARENTESCO_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label109" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="APELLIDO_PATERNO_VALIDACION_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label110" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="APELLIDO_MATERNO_VALIDACION_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label111" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="NOMBRE_VALIDACION_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label112" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="PARENTESCO_VALIDACION_DS" />

                                            </th>
                                            <th>
                                                <asp:Label runat="server" ID="Label3" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                    Text="DELITO" />

                                            </th>
                                    
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                         
                            <tr>
                            <!--
                            <td style="background-color: #D4D6D4" align="center">
                                    <asp:Label runat="server" ID="Label502" Font-Size="10px" ForeColor="Black" Font-Bold="true" Visible="false"
                                        Text='<%# Eval("ID_CARPETA") %>' />
                                </td>
                                -->
                                <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label500" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ID_CARPETA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label1" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_REPORTE") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label2" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("HORA_REPORTE") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label5" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_EVENTO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label6" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label7" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label18" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label8" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label9" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label46" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NO_EXTERIOR") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label10" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("DESCRIPCION_HECHOS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label11" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_PATERNO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label12" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_MATERNO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label13" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label14" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NACIONALIDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label15" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("SEXO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label16" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_NAC_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label17" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("EDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label113" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("SEÑAS_PARTICULARES") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label114" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MEDIA_FILIACION_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label115" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_ULTIMO_AVISTAMIENTO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label116" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label117" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label118" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label119" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label120" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label121" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUMERO_EXT_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label122" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUM_INT_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label123" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CP_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label124" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PROCEDENCIA_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label125" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_DE_ORIGEN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label126" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ENTIDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label127" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COMPLEXION_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label128" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PESO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label129" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTATURA_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label130" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("TEZ_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label131" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUMERO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label132" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_PATERNO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label133" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_MATERNO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label134" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label135" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PARENTESCO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label136" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label137" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label138" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label139" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label140" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label141" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUM_INT") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label142" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUM_EXTERIOR") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label143" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CP_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label144" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("AGENCIA_MP") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label145" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("AGENTE_MP") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label146" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("AVERIGUACION_PREVIA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label147" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ACTA_CIRCUNSTANCIADA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label148" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CARPETA_INVESTIGACION") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label149" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_INICIO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label150" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_ACTUAL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label151" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_CONLUYE") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label152" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_LOCALIZACION_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label153" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("VIVO_MUERTO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label154" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("POSIBLE_CAUSA_DESAPARICION_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label155" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CONDICION_ENCONTRADO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label156" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label157" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label158" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label159" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label160" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label161" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NO_INTERIOR_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label162" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NO_EXTERIOR_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label163" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CP_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label164" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label165" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_INGRESO_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label166" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CAUSAS_FALLECIMIENTO_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label167" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PATERNO_RECLAMA_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label168" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MATERNO_RECLAMA_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label169" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_RECLAMA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label170" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PARENTESCO_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label171" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_PATERNO_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label172" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_MATERNO_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label173" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label174" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PARENTESCO_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label4" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("DELITO") %>' />
                                        </td>
                              
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                        
                            <tr>
                            
                            <!--
                            <td align="center">
                                    <asp:Label runat="server" ID="Label508" Font-Size="10px" ForeColor="Black" Font-Bold="true" Visible="false"
                                        Text='<%# Eval("ID_CARPETA") %>' />
                                </td>
                                -->
                                <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label509" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ID_CARPETA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label1" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_REPORTE") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label2" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("HORA_REPORTE") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label5" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_EVENTO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label6" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label7" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label18" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label8" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label9" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_EVN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label46" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NO_EXTERIOR") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label10" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("DESCRIPCION_HECHOS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label11" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_PATERNO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label12" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_MATERNO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label13" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label14" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NACIONALIDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label15" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("SEXO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="center">
                                            <asp:Label runat="server" ID="Label16" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_NAC_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label17" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("EDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label113" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("SEÑAS_PARTICULARES") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label114" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MEDIA_FILIACION_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label115" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_ULTIMO_AVISTAMIENTO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label116" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label117" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label118" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label119" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label120" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label121" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUMERO_EXT_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label122" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUM_INT_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label123" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CP_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label124" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PROCEDENCIA_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label125" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_DE_ORIGEN") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label126" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ENTIDAD_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label127" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COMPLEXION_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label128" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PESO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label129" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTATURA_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label130" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("TEZ_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label131" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUMERO_NL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label132" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_PATERNO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label133" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_MATERNO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label134" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label135" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PARENTESCO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label136" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label137" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label138" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label139" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label140" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label141" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUM_INT") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label142" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NUM_EXTERIOR") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label143" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CP_D") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label144" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("AGENCIA_MP") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label145" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("AGENTE_MP") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label146" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("AVERIGUACION_PREVIA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label147" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ACTA_CIRCUNSTANCIADA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label148" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CARPETA_INVESTIGACION") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label149" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_INICIO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label150" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_ACTUAL") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label151" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_CONLUYE") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label152" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_LOCALIZACION_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label153" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("VIVO_MUERTO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label154" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("POSIBLE_CAUSA_DESAPARICION_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label155" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CONDICION_ENCONTRADO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label156" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PAIS_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label157" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("ESTADO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label158" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MUNICIPIO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label159" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LOCALIDAD_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label160" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("COLONIA_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label161" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NO_INTERIOR_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label162" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NO_EXTERIOR_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label163" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CP_LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label164" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("LUGAR_HALLAZGO_LO") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label165" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("FECHA_INGRESO_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label166" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("CAUSAS_FALLECIMIENTO_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label167" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PATERNO_RECLAMA_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label168" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("MATERNO_RECLAMA_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label169" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_RECLAMA") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label170" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PARENTESCO_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label171" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_PATERNO_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label172" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("APELLIDO_MATERNO_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label173" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("NOMBRE_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label174" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("PARENTESCO_VALIDACION_DS") %>' />
                                        </td>
                                        <td style="background-color: #D4D6D4" align="left">
                                            <asp:Label runat="server" ID="Label4" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                Text='<%# Eval("DELITO") %>' />
                                        </td>
                               
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                       </div>
                       <asp:SqlDataSource ID="dsConsultaHomicidios" runat="server" 
                        SelectCommandType="StoredProcedure" 
                       
                        SelectCommand="PNL_REPORTE_PRUEBA" 
                         ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" >
                       
                        
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtFechaInicio" Name="FechaUno" 
                                PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtFechaFin" Name="FechaDos" 
                                PropertyName="Text" Type="DateTime" />
                               
                        </SelectParameters>
                        
                    </asp:SqlDataSource>
                    </asp:Panel>
                
                  
                   
                    
                        
                </td>
            </tr>
             <tr>
                <td colspan="4">
                    
                    <asp:Button ID="cmdExportarExcel" runat="server"  AutoPostBack="FALSE"  
                        Text="Exportar a Excel" onclick="cmdExportarExcel_Click" Visible="false" />
                        
                </td>
            </tr>
            <tr>
                <td>
                    
                    
                </td>
           </tr>
            
            
            
           
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>  
    
</div>

</asp:Content>

