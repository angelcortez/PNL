<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Periciales.aspx.cs" Inherits="AtencionTemprana.Periciales" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
     .hidden
     {
         display:none;
     }
</style>
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
                     <asp:Label ID="IdUsuario" runat="server" Visible="False"></asp:Label>
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

        <table style="width: 100%;" >
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblBuscar" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBuscar_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">POR:</asp:ListItem>
                        <asp:ListItem Value="1">NUC</asp:ListItem>
                      <asp:ListItem Value="2">DEPARTAMENTO </asp:ListItem>
                        <asp:ListItem Value="3">MUNICIPIO </asp:ListItem>
                        <asp:ListItem Value="4">FECHA </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;

                  <asp:Label ID="lblNuc" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NUC" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNuc" runat="server" Visible="False"></asp:TextBox>


                      <asp:Label ID="lblTipo" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="DEPARTAMENTO" Visible="False"></asp:Label>
                    <asp:DropDownList ID="ddlSERP" runat="server" Visible="False">
                    </asp:DropDownList>

                    <asp:Label ID="lblmuni" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MUNICIPIO" Visible="False"></asp:Label>
                    <asp:DropDownList ID="ddlMuni" runat="server" Visible="False">
                    </asp:DropDownList>
                    

                    <asp:Label ID="lblFechaInicioOrden" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicioOrden" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicioOrden_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicioOrden">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblFechaFinOrden" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFinOrden" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaFinOrden_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFinOrden">
                    </asp:CalendarExtender>
                    <asp:Button ID="cmdAceptar" runat="server" onclick="cmdAceptar_Click" 
                        Text="ACEPTAR" Visible="False" />
                </td>
            </tr>

            <tr>
                <td colspan="3">
                    &nbsp;
                    
                        <asp:GridView ID="gvNuc" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" 
                        AutoGenerateColumns="False" DataSourceID="dsConsultaOrden" 
                        AllowPaging="True" onrowdatabound="gvNuc_RowDataBound" 
                       >

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                          <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                             <a href='OrdenPerito.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_SP=<%# Eval("SOL_SP") %> '>
                                 <asp:Image ID="Image1" runat="server" Height="28px" ImageUrl="img/carpetaPI.png" /></a>
                            </ItemTemplate>
                          </asp:TemplateField>

                             <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="NUC" HeaderText="NUC" ReadOnly="True" 
                                SortExpression="NUC" />
                            <asp:BoundField DataField="SERVICIO_PERICIAL" HeaderText="SERVICIO PERICIAL" ReadOnly="True" 
                                SortExpression="SERVICIO_PERICIAL" />
                         <asp:BoundField DataField="UNDD_DSCRPCION" HeaderText="UNIDAD" 
                                SortExpression="UNDD_DSCRPCION" Visible="False" />

                            <asp:BoundField DataField="DEPTO_PRCIAL" HeaderText="DEPARTEMENTO" ReadOnly="True" 
                                SortExpression="DEPTO_PRCIAL" />
                          <%-- <asp:BoundField DataField="ESPECIFICACIONES" HeaderText="ESPECIFICACIONES" ReadOnly="True" 
                                SortExpression="ESPECIFICACIONES" />--%>
                                 <asp:BoundField DataField="FECHA_ASIGNA" HeaderText="FECHA DE ASIGNACION" ReadOnly="True" 
                                SortExpression="FECHA_ASIGNA" />
                                 <asp:BoundField DataField="DIAS" HeaderText="DÍAS" ReadOnly="True" 
                                SortExpression="DIAS" />
                                  <asp:BoundField DataField="ESTADO_SOLICITUD" HeaderText="ESTADO SOLICITUD" ReadOnly="True" 
                                SortExpression="ESTADO_SOLICITUD" />
                         
                              
                            
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
                <td>
                    
                    <asp:SqlDataSource ID="dsConsultaOrden" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ver_sol_peritajes" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

 <asp:SqlDataSource ID="dsBuscarNuc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por" SelectCommandType="StoredProcedure">
                             <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32"  />
                            <asp:ControlParameter ControlID="txtNuc" Name="NUC" PropertyName="Text" 
                                Type="String" />                             
                                <asp:Parameter DefaultValue="0" Name="ID_ESTADOSOL" Type="Int32" />

                            <asp:Parameter DefaultValue="0" Name="DEPTO" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="MUNICIPIO" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" 
                                Type="String"  />
                            <asp:Parameter DefaultValue=" " Name="FECHA_FINAL"  Type="String"  />
                        </SelectParameters>
                    </asp:SqlDataSource>


                     <asp:SqlDataSource ID="dsBuscarDpto" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                                                         <asp:Parameter DefaultValue="0" Name="ID_ESTADOSOL" Type="Int32" />
                             <asp:ControlParameter ControlID="ddlSERP" Name="DEPTO" PropertyName="SelectedValue" 
                                Type="Int32" DefaultValue="" />
                            <asp:Parameter DefaultValue="0" Name="MUNICIPIO" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_FINAL" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                       <asp:SqlDataSource ID="dsBuscarMuni" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                                                         <asp:Parameter DefaultValue="0" Name="ID_ESTADOSOL" Type="Int32" />
                             <asp:ControlParameter ControlID="ddlMuni" Name="MUNICIPIO" PropertyName="SelectedValue" 
                                Type="Int32" DefaultValue="" />
                            <asp:Parameter DefaultValue="0" Name="DEPTO" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_FINAL" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                 <asp:SqlDataSource ID="dsBuscarFechaInicioSolicitud" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                                                         <asp:Parameter DefaultValue="0" Name="ID_ESTADOSOL" Type="Int32" />
                  <asp:Parameter DefaultValue="0" Name="DEPTO" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="MUNICIPIO" Type="Int32" />
                            <asp:ControlParameter ControlID="txtFechaInicioOrden"
                                Name="FECHA_INICIAL" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFinOrden" Name="FECHA_FINAL"
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoSolicitudP_Asignada" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por_EST" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                    
                       <asp:Parameter DefaultValue="2" Name="ID_ESTADOSOL" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoSolicitudP_Proceso" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por_EST" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                         
                            <asp:Parameter DefaultValue="3" Name="ID_ESTADOSOL" Type="Int32" />
                           
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoSolicitudP_Cumplida" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por_EST" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                           
                            <asp:Parameter DefaultValue="5" Name="ID_ESTADOSOL" Type="Int32" />
                           
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoSolicitudP_Concluida" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por_EST" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                       
                            <asp:Parameter DefaultValue="4" Name="ID_ESTADOSOL" Type="Int32" />
                        
                        </SelectParameters>
                    </asp:SqlDataSource>
                   
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

        <table style="width: 100%;" >
         <tr align="center">
               
                <td></td>
                <td></td>
                <td align="center" class="style2">
                    <asp:Button ID="btnMostrar" runat="server" Text="MOSTRAR  ORDENES" 
                        onclick="btnMostrar_Click" Visible="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ESTADOS DE LAS ORDENES"></asp:Label>
                    &nbsp;
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
                     &nbsp;</td>
                <td>
                    <asp:Button ID="btnAsignada" runat="server" BackColor="Orange" 
                        onclick="btnAsignada_Click" />
                    <asp:Label ID="lblEstadoASI" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ASIGNADA"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                 <td>
                     <asp:Button ID="btnProceso" runat="server" BackColor="Blue" 
                         onclick="btnProceso_Click" />
                     <asp:Label ID="lblEstadoPRO" runat="server" Font-Bold="True" ForeColor="Black" 
                         Text="EN PROCESO"></asp:Label>
                     <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                 </td>
                 <td>
                     <asp:Button ID="btnCumplida" runat="server" BackColor="#802A2A" 
                         onclick="btnCumplida_Click" />
                     <asp:Label ID="lblEstadoCUM" runat="server" Font-Bold="True" ForeColor="Black" 
                         Text="CUMPLIDA"></asp:Label> <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=""></asp:Label>
                 </td>
                 <td>
                     <asp:Button ID="btnConcluida" runat="server" BackColor="#00CC00" 
                         onclick="btnConcluida_Click" />
                     <asp:Label ID="lblEstadoCON" runat="server" Font-Bold="True" ForeColor="Black" 
                         Text="CONCLUÍDA"></asp:Label> <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=""></asp:Label>
                 </td>
            </tr>
            <tr>
                <td colspan="2">
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

