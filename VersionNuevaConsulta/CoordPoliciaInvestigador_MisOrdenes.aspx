<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordPoliciaInvestigador_MisOrdenes.aspx.cs" Inherits="AtencionTemprana.CoordPoliciaInvestigador_Ordenes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
     .hidden
     {
         display:none;
     }
     .margen 
     {
         margin:5px
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
                <td>
                <br />
                    <asp:ImageButton ID="Image2" runat="server" Height="18px" 
                        ImageUrl="img/home.png" onclick="Image2_Click" />
                            <asp:Label ID="lblInicio" Text="INICIO" runat="server" Font-Bold="True"  Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                    
            
                    <!--    
                    <a href='CoordPoliciaInvestigador_MisOrdenes.aspx' class="margen">
                            <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/ordenes.png" />
                            <asp:Label ID="lblMisOrdenes" Text="MIS ORDENES" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                    </a>

                    <a href='CoordPoliciaInvestigador_Estadistica.aspx' class="margen">
                            <asp:Image ID="Image3" runat="server" Height="18px" ImageUrl="img/graph.jpg" />
                            <asp:Label ID="Label1" Text="ESTADISTICAS" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                    </a>
                    -->
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblBuscar" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBuscar_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">POR:</asp:ListItem>
                        
                        <asp:ListItem Value="2">TIPO DE ORDEN</asp:ListItem>
                        <asp:ListItem Value="3">FECHA </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;

                    


                    <asp:Label ID="lblTipo" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="TIPO ORDEN" Visible="False"></asp:Label>
                    <asp:DropDownList ID="ddlTipoOrden" runat="server" Visible="False">
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
                             <a href='OrdenPoliciaInvestigador.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ORDEN=<%#Eval("ID_ORDEN")%> '>
                                 <asp:Image ID="Image1" runat="server" Height="28px" ImageUrl="img/carpetaPI.png" /></a>
                            </ItemTemplate>
                          </asp:TemplateField>


                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="ID_ORDEN" HeaderText="ORDEN" 
                                SortExpression="ID_ORDEN" Visible="False" />
                            <asp:BoundField DataField="ID_UNIDAD" HeaderText="UNIDAD" 
                                SortExpression="ID_UNIDAD" Visible="False" />
                            <asp:BoundField DataField="NUC" HeaderText="NUC" ReadOnly="True" 
                                SortExpression="NUC" />
                            <asp:BoundField DataField="TIPO_ORDEN" HeaderText="TIPO DE ORDEN" ReadOnly="True" 
                                SortExpression="TIPO_ORDEN" />
                            <asp:BoundField DataField="FECHA_ORDEN" HeaderText="FECHA ASIGNACION" 
                                ReadOnly="True" SortExpression="FECHA_ORDEN" />
                            <asp:BoundField DataField="ESTADO_ORDEN" HeaderText="ESTADO ORDEN" ReadOnly="True" 
                                SortExpression="ESTADO_ORDEN" />
                           

                           
                            
                            
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
                        SelectCommand="Ordenes_CoorPI" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                     <asp:SqlDataSource ID="dsBuscarTipoOrdenPI" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenCoorPI_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                            <asp:Parameter DefaultValue="0" Name="IDESTADO_ORDEN" Type="Int32" />
                            <asp:ControlParameter ControlID="ddlTipoOrden" Name="IDTIPOORDEN" PropertyName="SelectedValue" 
                                Type="Int32" DefaultValue="" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHAFINAL" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                    

                    <asp:SqlDataSource ID="dsBuscarEstadoOrdenPI_Enviada" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenCoorPI_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                            <asp:Parameter DefaultValue="1" Name="IDESTADO_ORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="IDTIPOORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHAFINAL" Type="String" />
                      
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoOrdenPI_Asignada" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenCoorPI_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                            <asp:Parameter DefaultValue="2" Name="IDESTADO_ORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="IDTIPOORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHAFINAL" Type="String" />
                      
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoOrdenPI_Proceso" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenCoorPI_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                            <asp:Parameter DefaultValue="3" Name="IDESTADO_ORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="IDTIPOORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHAFINAL" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoOrdenPI_Cumplida" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenCoorPI_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                            <asp:Parameter DefaultValue="4" Name="IDESTADO_ORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="IDTIPOORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHAFINAL" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarEstadoOrdenPI_Concluida" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenCoorPI_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                            <asp:Parameter DefaultValue="5" Name="IDESTADO_ORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="IDTIPOORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="FECHA_INICIAL" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="FECHAFINAL" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarFechaInicioOrdenPI" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenCoorPI_Por" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="NUC" Type="String" />
                            <asp:Parameter DefaultValue="0" Name="IDESTADO_ORDEN" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="IDTIPOORDEN" Type="Int32" />
                            <asp:ControlParameter ControlID="txtFechaInicioOrden" DefaultValue="" 
                                Name="FECHA_INICIAL" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFinOrden" Name="FECHAFINAL" 
                                PropertyName="Text" Type="String" />
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
                    <asp:Button ID="btnAsignada" runat="server" BackColor="ORANGE" 
                        onclick="btnAsignada_Click" />
                    <asp:Label ID="lblEstadoASI" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ASIGNADA"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnProceso" runat="server" BackColor="Blue" 
                        onclick="btnProceso_Click" />
                    <asp:Label ID="lblEstadoPRO" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="EN PROCESO"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnCumplida" runat="server" BackColor="#802A2A" 
                        onclick="btnCumplida_Click" />
                    <asp:Label ID="lblEstadoCUM" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="CUMPLIDA"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnConcluida" runat="server" BackColor="#00CC00" 
                        onclick="btnConcluida_Click" />
                    <asp:Label ID="lblEstadoCON" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="CONCLUIDA"></asp:Label>
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

