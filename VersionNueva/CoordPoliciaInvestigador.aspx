<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordPoliciaInvestigador.aspx.cs" Inherits="AtencionTemprana.OrdenInvestigacion" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function mostrarFichero(destino) {
        window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
        document.forms(0).submit();
    }
    
 </script>
<style type="text/css">
     .hidden
     {
         display:none;
     }
    .style2
    {
        width: 111px;
    }
    
     .margen 
     {
         margin:5px
     }
    .style3
    {
        height: 23px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
        
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
    <asp:PostBackTrigger ControlID="cmdGuardar" />
    <asp:PostBackTrigger ControlID="cmdAceptar" />
    
    <asp:PostBackTrigger ControlID="cmdAsignar" />
    <asp:PostBackTrigger ControlID="btnMostrar" />
     <asp:PostBackTrigger ControlID="gvNuc" />
      <asp:PostBackTrigger ControlID="gvAsignarPI" />
       <asp:PostBackTrigger ControlID="gvConsultarPI" />
         <asp:PostBackTrigger ControlID="ddlBuscar" />
       
    </Triggers>
    <ContentTemplate>


      <table style="width: 100%;">
        <tr>
            <td class="style3">
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#006600"></asp:Label>
            </td>
            <td class="style3">
                </td>
            <td class="style3">
                </td>
            <td align="right" class="style3">
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
                 <asp:Label ID="IdOrden" runat="server" Visible="FALSE" ></asp:Label>
                 <asp:Label ID="IDtIPOuNIDAD" runat="server" Text=" " Visible="false"></asp:Label>
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
                    <label> </label>
                </td>
            </tr>
            <tr>
                <td>
                   
                        <asp:ImageButton ID="Image2" runat="server" Height="18px" 
                        ImageUrl="img/home.png" onclick="Image2_Click" />
                            <asp:Label ID="lblInicio" Text="INICIO" runat="server" Font-Bold="True"  Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                    
            
                    
                            <asp:ImageButton ID="ImageMisOrdenes" runat="server" Height="18px" 
                            ImageUrl="img/ordenes.png" onclick="ImageMisOrdenes_Click" />
                            <asp:Label ID="lblMisOrdenes" Text="MIS ORDENES" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                   
                    
                            <asp:ImageButton ID="Image3" runat="server" Height="18px" 
                            ImageUrl="img/graph.jpg" onclick="Image3_Click" />
                            <asp:Label ID="Label1" Text="ESTADISTICAS" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                        
                         <asp:ImageButton ID="ImageB" runat="server" Height="18px" 
                            ImageUrl="img/IMPUTADO.png" onclick="ImageB_Click"  />
                            <asp:Label ID="Label5" Text="REGISTRAR DETENIDO" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                            
                </td>
            </tr>
            <tr>
                <td>
                     <br />
                 <br />
                 <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" 
                     Text="ORDENES POLICIALES" style="font-size:20px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                <br />
              
                    <asp:Label ID="lblBuscar" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBuscar_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">POR:</asp:ListItem>
                       <asp:ListItem Value="1">NUC</asp:ListItem>
                        <asp:ListItem Value="2">TIPO DE ORDEN</asp:ListItem>
                        <asp:ListItem Value="3">FECHA </asp:ListItem>
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
                             <a href='OrdenCoordPoliciaInvestigador.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>' >
                                 <asp:Image ID="Image2" runat="server" Height="28px" ImageUrl="img/carpetaPI.png" /></a>
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
                            <asp:BoundField DataField="FECHA_ORDEN" HeaderText="FECHA ORDEN" 
                                ReadOnly="True" SortExpression="FECHA_ORDEN" />
                            <asp:BoundField DataField="DIAS" HeaderText="DIAS DE RETRASO" 
                                ReadOnly="True" SortExpression="DIAS" />
                            <asp:BoundField DataField="ESTADO_ORDEN" HeaderText="ESTADO ORDEN" ReadOnly="True" 
                                SortExpression="ESTADO_ORDEN" />
                           

                           
                            <asp:TemplateField HeaderText="ASIGNAR POLICIA(S) "  SortExpression="ASIGNADA">
                            <ItemTemplate>                                     
                                        <a href='CoordPoliciaInvestigador.aspx?ID_CARPETA=<%# Eval("ID_CARPETA") %>&amp;ID_ORDEN=<%# Eval("ID_ORDEN") %>&amp;ASIGNADA=<%# Eval("ASIGNADA") %>&amp;ID_UNIDAD=<%#Eval("ID_UNIDAD")%>&amp;btnAsignar=1&amp;NUC=<%#Eval("NUC")%>'>
                                        <asp:Image ID="Image3" runat="server" Height="28px" ImageUrl="img/consultarPI.png" />
                                        </a>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VER POLICIA(S) ASIGNADOS "  SortExpression="ASIGNADA">
                            <ItemTemplate>
                                        <a href='CoordPoliciaInvestigador.aspx?ID_ORDEN=<%# Eval("ID_ORDEN") %>&amp;ASIGNADA=<%# Eval("ASIGNADA") %>&amp;ID_UNIDAD=<%#Eval("ID_UNIDAD")%>&amp;btnVer=1'>
                                        <asp:Image ID="Image4" runat="server" Height="28px" ImageUrl="img/verPI.png" />
                                        </a>
                            </ItemTemplate>
                          </asp:TemplateField>
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
                        SelectCommand="Lista_Orden_CoorPI" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>


                     <asp:SqlDataSource ID="dsBuscarTipoOrdenPI" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenPI_Por" SelectCommandType="StoredProcedure">
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
                        SelectCommand="BuscarOrdenPI_Por" SelectCommandType="StoredProcedure">
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
                        SelectCommand="BuscarOrdenPI_Por" SelectCommandType="StoredProcedure">
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
                        SelectCommand="BuscarOrdenPI_Por" SelectCommandType="StoredProcedure">
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
                        SelectCommand="BuscarOrdenPI_Por" SelectCommandType="StoredProcedure">
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
                        SelectCommand="BuscarOrdenPI_Por" SelectCommandType="StoredProcedure">
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


                    <asp:SqlDataSource ID="dsBusNuc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenPI_PorNuc" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            <asp:ControlParameter ControlID="txtNuc"  Name="NUC" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarFechaInicioOrdenPI" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarOrdenPI_Por" SelectCommandType="StoredProcedure">
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
            <tr >
               
                <td></td>
                <td></td>
                <td  class="style2">
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
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnEnviada" runat="server" BackColor="Red" 
                        onclick="btnEnviada_Click" />
                        <asp:Label ID="LblEstadoENV" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="PENDIENTE"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnAsignada" runat="server" BackColor="ORANGE" 
                        onclick="btnAsignada_Click" />
                    <asp:Label ID="lblEstadoASI" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ASIGNADA"></asp:Label>
                </td>
                <td class="style2">
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
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

        <table runat="server" id="tbl_asignarPI">
            <tr>
                <td>
                    &nbsp;
               
                   <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ASIGNAR POLICIA INVESTIGADOR A ORDEN  "></asp:Label>
                        <asp:Label ID="lblNucPI" Font-Bold="True" runat="server" Text=" " ></asp:Label>

                        <asp:Label ID="lblIdCarpeta" Font-Bold="True" runat="server" Text=" " Visible="false" ></asp:Label>
                </td>
            </tr>
            <tr>
             <td>
                        <asp:GridView ID="gvAsignarPI" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" DataKeyNames="ID_USUARIO"
                        AutoGenerateColumns="False" DataSourceID="dsCargaTrabajo" 
                        AllowPaging="True" onrowdatabound="gvAsignarPI_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        

                          <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                                <asp:CheckBox ID="ckboxPI"  runat="server" />
                            </ItemTemplate>
                          </asp:TemplateField>

                          <asp:BoundField DataField="ID_USUARIO" HeaderText="ID_USUARIO" 
                                SortExpression="ID_USUARIO" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE POLICIA INVESTIGADOR" ReadOnly="True" 
                                SortExpression="NOMBRE" />
                            <asp:BoundField DataField="ASIGNADAS" HeaderText="ORDENES ASIGNADA" ReadOnly="True" 
                                SortExpression="ASIGNADAS" />
                            <asp:BoundField DataField="EN_PROCESO" HeaderText="ORDENES EN PROCESO" 
                                ReadOnly="True" SortExpression="EN_PROCESO" />
                            <asp:BoundField DataField="CUMPLIDAS" HeaderText="ORDENES CUMPLIDAS" ReadOnly="True" 
                                SortExpression="CUMPLIDAS" />
                            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL DE ORDENES" ReadOnly="True" 
                                SortExpression="TOTAL" />
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
                    &nbsp;
               
                    <asp:SqlDataSource ID="dsCargaTrabajo" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="Carga_Trabajo_PI" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUnidad" Name="IDUNIDAD" PropertyName="Text" 
                                Type="Int32" />
                            <asp:ControlParameter ControlID="IdOrden" Name="id_orden" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:Button ID="cmdAsignar" runat="server" Text="ASIGNAR" 
                        onclick="cmdAsignar_Click"  />
                        <br />
                     <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                        <br />
                        <asp:Label ID="lbl_id_checkbox" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=" "></asp:Label>
                    <asp:Label ID="IdCbx" runat="server" Text=" "></asp:Label>
                </td>
         </tr>
         <tr>
            <td colspan="3">
            <br />
                    <asp:Label ID="Label332" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SELECCIONE DOCUMENTO PDF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            
                 <asp:FileUpload ID="FileUpload1" runat="server" />  <asp:Label ID="Label3" runat="server"></asp:Label>
                 <br />
                  <br />
                 <asp:Button ID="cmdGuardar" runat="server"  
                        onclick="cmdGuardar_Click" TabIndex="32" Text="GUARDAR DOCUMENTO" 
                        Width="256px" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td>
            <br />
            
            </td>      
        </tr>
        </table>
       


        <table runat="server" id="tbl_verPI">
            <tr>
                <td>
                    &nbsp;
               
                   <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="POLICIA INVESTIGADOR ASIGNADO"></asp:Label>
                </td>
            </tr>
            <tr>
             <td>
                    <asp:GridView ID="gvConsultarPI" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" DataKeyNames="ID_USUARIO"
                        AutoGenerateColumns="False" DataSourceID="dsVerPolicia" 
                        AllowPaging="True" onrowdatabound="gvConsultarPI_RowDataBound">

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>  

                          

                          <asp:TemplateField HeaderText="ORDEN ASIGNACIÓN">
                            <ItemTemplate>
                             <a href='CoordPoliciaInvestigador.aspx?ID_CARPETA=<%#Eval("ID_CARPETA") %>&op=Docs&IdDoc=<%#Eval("ID_ASIGNACION") %>'>
                                 <asp:Image ID="ImageAsignacion" runat="server" Height="28px" ImageUrl="img/document.png" /></a>
                            </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="INFORME POLICIAL">
                            <ItemTemplate>
                             <a href='CoordPoliciaInvestigador.aspx?ID_CARPETA=<%#Eval("ID_CARPETA") %>&op=Docs&IdDoc=<%#Eval("ID_INFORME") %>'>
                                 <asp:Image ID="ImageInforme" runat="server" Height="28px" ImageUrl="img/document.png" /></a>
                            </ItemTemplate>
                          </asp:TemplateField>
                            

                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="ID_USUARIO" HeaderText="ID_USUARIO" 
                                SortExpression="ID_USUARIO" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                          <asp:BoundField DataField="ID_ASIGNACION" HeaderText="ID_ASIGNACION" 
                                SortExpression="ID_ASIGNACION" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                          <asp:BoundField DataField="ID_INFORME" HeaderText="ID_INFORME" 
                                SortExpression="ID_INFORME" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                          
                             <asp:BoundField DataField="NUC" HeaderText="NUC" ReadOnly="True" 
                                SortExpression="NUC" />
                            <asp:BoundField DataField="TIPO_ORDEN" HeaderText="TIPO ORDEN" 
                                ReadOnly="True" SortExpression="TIPO_ORDEN" />
                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO ORDEN" ReadOnly="True" 
                                SortExpression="ESTADO" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="POLICIA ASIGNADO" ReadOnly="True" 
                                SortExpression="NOMBRE" />
                            
                            
                             <asp:TemplateField HeaderText="ELIMINAR ASIGNACIÓN">
                                 <ItemTemplate>
                                     <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="img/delete_PI.png" Height="38px" OnCommand="ImageButton_Command"
                                          CommandArgument='<%# Eval("ID_USUARIO") %>'
                                       OnClientClick = "return confirm('¿DESEA ELIMINAR LA ORDEN DE ASIGNACIÓN?');" />
                                 </ItemTemplate>
                             </asp:TemplateField>

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

                    
                    <asp:SqlDataSource ID="dsVerPolicia" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="Ver_Policias_OrdenPI" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdOrden" Name="IDORDEN" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                    
                </td>
            </tr>
        </table>

 </ContentTemplate>
    </asp:UpdatePanel>
    

    
    
    
</div>

</asp:Content>

