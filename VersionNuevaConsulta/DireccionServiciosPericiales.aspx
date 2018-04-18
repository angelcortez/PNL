<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DireccionServiciosPericiales.aspx.cs" Inherits="AtencionTemprana.DireccionServiciosPericiales" %>
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
                     <asp:Label ID="IdUsuario" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdSP" runat="server" Visible="true" ></asp:Label>
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
                        ImageUrl="img/home.png" onclick="Image2_Click"/>
                            <asp:Label ID="lblInicio" Text="INICIO" runat="server" Font-Bold="True"  Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    

                    
                            <asp:ImageButton ID="Image3" runat="server" Height="18px" 
                            ImageUrl="img/graph.jpg" onclick="Image3_Click"  />
                            <asp:Label ID="Label1" Text="ESTADÍSTICAS" runat="server" Font-Bold="True" 
                               Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" 
                               class="margen"></asp:Label>    
                    
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
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
                        AutoGenerateColumns="False" DataSourceID="dsConsultaSolicitud" 
                        AllowPaging="True" onrowdatabound="gvNuc_RowDataBound" 
                       >

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                          <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                             <a href='OrdenDirServiciosPericales.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>' >
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
                                 <asp:BoundField DataField="FECHA_SOLICITUD" HeaderText="FECHA DE SOLICITUD" ReadOnly="True" 
                                SortExpression="FECHA_SOLICITUD" />
                                 <asp:BoundField DataField="DIAS" HeaderText="DÍAS" ReadOnly="True" 
                                SortExpression="DIAS" />
                                  <asp:BoundField DataField="ESTADO_SOLICITUD" HeaderText="ESTADO SOLICITUD" ReadOnly="True" 
                                SortExpression="ESTADO_SOLICITUD" />
                   
                           <asp:TemplateField HeaderText="ASIGNAR PERITO(S) "  SortExpression="ASIGNADA">
                            <ItemTemplate>                                     
                                        <a href='DireccionServiciosPericiales.aspx?ID_CARPETA=<%# Eval("ID_CARPETA") %>&amp;ID_SP=<%# Eval("SOL_SP") %>&amp;ASIGNADA=<%# Eval("ASIGNADA") %>&amp;btnAsignar=1&amp;NUC=<%#Eval("NUC")%>&amp;ID_DPTO=<%#Eval("ID_DEPTO_PRCIAL")%>'>
                                        <asp:Image ID="Image1" runat="server" Height="28px" ImageUrl="img/consultarPI.png" />
                                        </a>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PERITO(S) ASIGNADOS "  SortExpression="ASIGNADA">
                            <ItemTemplate>
                                       <a href='DireccionServiciosPericiales.aspx?ID_SP=<%# Eval("SOL_SP") %>&amp;ASIGNADA=<%# Eval("ASIGNADA") %>&amp;NUC=<%#Eval("NUC")%>&amp;btnVer=1'>
                                         <asp:Image ID="Image1" runat="server" Height="28px" ImageUrl="img/VPerito.jpg" />
                                        </a>
                            </ItemTemplate>
                          </asp:TemplateField>
                           <asp:TemplateField HeaderText="PERITAJE SOLICITADO POR"  SortExpression="ASIGNADA">
                            <ItemTemplate>
                                     <a href='DireccionServiciosPericiales.aspx?ID_SP=<%# Eval("SOL_SP") %>&amp;ASIGNADA=<%# Eval("ASIGNADA") %>'>
                                      <asp:Image ID="Image1" runat="server" Height="28px" ImageUrl="img/VPerito.jpg" />
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
                    
                    <asp:SqlDataSource ID="dsConsultaSolicitud" runat="server" 
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
                    
                    <asp:SqlDataSource ID="dsBuscarEstadoSolicitudP_Enviada" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarSolicitud_Por_EST" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUsuario" Name="IDUSUARIO" 
                                PropertyName="Text" Type="Int32" />
                            
                            <asp:Parameter DefaultValue="1" Name="ID_ESTADOSOL" Type="Int32" />
                      
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
                        onclick="btnEnviada_Click"  />
                        <asp:Label ID="LblEstadoENV" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="PENDIENTE"></asp:Label>&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnAsignada" runat="server" BackColor="ORANGE" 
                        onclick="btnAsignada_Click" />
                    <asp:Label ID="lblEstadoASI" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ASIGNADA"></asp:Label>&nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=""></asp:Label>
                </td>
                <td class="style2">
                    <asp:Button ID="btnProceso" runat="server" BackColor="Blue" 
                        onclick="btnProceso_Click" />
                    <asp:Label ID="lblEstadoPRO" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="EN PROCESO"></asp:Label>&nbsp;<asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnCumplida" runat="server" BackColor="#802A2A" 
                        onclick="btnCumplida_Click" />
                    <asp:Label ID="lblEstadoCUM" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="CUMPLIDA"></asp:Label>&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnConcluida" runat="server" BackColor="#00CC00" 
                        onclick="btnConcluida_Click"  />
                    <asp:Label ID="lblEstadoCON" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="CONCLUÍDA"></asp:Label>&nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" >
                    &nbsp;
                    <asp:DetailsView ID="vSolicitante" runat="server" AutoGenerateRows="False" 
                        DataSourceID="dsSolicitanteP" Height="50px" Width="513px" 
                        CellPadding="3"  BorderWidth="1px" 
                        CellSpacing="2">
                        <EditRowStyle  BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <Fields>
                            <asp:BoundField DataField="ID_SOLICTUD" HeaderText="ID_SOLICTUD" 
                                InsertVisible="False" ReadOnly="True" SortExpression="ID_SOLICTUD" Visible="false" />
                            <asp:BoundField DataField="SOLICITANTE" HeaderText="SOLICITANTE" 
                                ReadOnly="True" SortExpression="SOLICITANTE" />
                            <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD" ReadOnly="True" 
                                SortExpression="UNIDAD" />
                        </Fields>
                         
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                         
                        <RowStyle BackColor="#FFF7E7" ForeColor="black" />
                         
                    </asp:DetailsView>
                    <asp:SqlDataSource ID="dsSolicitanteP" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="VER_SOLICITANTE_PERITAJE" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID_SOL" QueryStringField="ID_SP" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
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
                        Text="ASIGNAR PERITO  A SOLICITUD  "></asp:Label>
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
                            <asp:BoundField DataField="PERITO_ASIGNADO" HeaderText="NOMBRE DEL PERITO" ReadOnly="True" 
                                SortExpression="PERITO_ASIGNADO" />
                            <asp:BoundField DataField="ASIGNADAS" HeaderText="SOLICITUDES ASIGNADA" ReadOnly="True" 
                                SortExpression="ASIGNADAS" />
                            <asp:BoundField DataField="EN_PROCESO" HeaderText="SOLICITUDES EN PROCESO" 
                                ReadOnly="True" SortExpression="EN_PROCESO" />
                            <asp:BoundField DataField="CUMPLIDAS" HeaderText="SOLICITUDES CUMPLIDAS" ReadOnly="True" 
                                SortExpression="CUMPLIDAS" />
                            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL DE SOLICITUDES" ReadOnly="True" 
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
                        SelectCommand="Carga_Peritos" SelectCommandType="StoredProcedure">
                       <SelectParameters>
                            <%-- <asp:ControlParameter ControlID="id_dept" Name="id_dept" PropertyName="Text" 
                                Type="Int32" />--%>
                           <asp:QueryStringParameter Name="id_sol" QueryStringField="ID_SP" Type="Int32" />
                           <asp:QueryStringParameter Name="id_dept" QueryStringField="ID_DPTO" 
                               Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:Button ID="cmdAsignar" runat="server" Text="ASIGNAR" 
                        onclick="cmdAsignar_Click"  />
                        <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
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
        
        </table>
       


        <table runat="server" id="tbl_verPI">
            <tr>
                <td>
                    &nbsp;
               
                   <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="PERITOS ASIGNADOS"></asp:Label>
                </td>
            </tr>
            <tr>
             <td>
                    <asp:GridView ID="gvConsultarPI" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px"
                        AutoGenerateColumns="False" DataSourceID="dsVerPERITOS" 
                        AllowPaging="True" onrowdatabound="gvConsultarPI_RowDataBound">

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>  

                        
                          
                          <asp:TemplateField HeaderText="SOLICITUD ASIGNACIÓN">
                            <ItemTemplate>
                             <a href='DireccionServiciosPericiales.aspx?ID_CARPETA=<%#Eval("ID_CARPETA") %>&op=Docs&IdDoc=<%#Eval("ID_ASIGNACION") %>'>
                                 <asp:Image ID="ImageAsignacion" runat="server" Height="28px" ImageUrl="img/document.png" /></a>
                            </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="INFORME DICTAMEN">
                            <ItemTemplate>
                             <a href='DireccionServiciosPericiales.aspx?ID_CARPETA=<%#Eval("ID_CARPETA") %>&op=Docs&IdDoc=<%#Eval("ID_DICTAMEN") %>'>
                                 <asp:Image ID="ImageInforme" runat="server" Height="28px" ImageUrl="img/document.png" /></a>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                           <asp:BoundField DataField="ID_PERITO_ASIGNADO" HeaderText="ID_USUARIO" 
                                SortExpression="ID_PERITO_ASIGNADO" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                          <asp:BoundField DataField="ID_ASIGNACION" HeaderText="ID_ASIGNACION" 
                                SortExpression="ID_ASIGNACION" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                          <asp:BoundField DataField="ID_DICTAMEN" HeaderText="ID_INFORME" 
                                SortExpression="ID_DICTAMEN" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                             <asp:BoundField DataField="NUC" HeaderText="NUC" ReadOnly="True" 
                                SortExpression="NUC" />
                            <%--<asp:BoundField DataField="TIPO_ORDEN" HeaderText="TIPO ORDEN" 
                                ReadOnly="True" SortExpression="TIPO_ORDEN" />--%>
                            <asp:BoundField DataField="ESTDO_PRCIAL" HeaderText="ESTADO SOLICITUD" ReadOnly="True" 
                                SortExpression="ESTDO_PRCIAL" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="PERITO ASIGNADO" ReadOnly="True" 
                                SortExpression="NOMBRE" />
                            

                              <asp:TemplateField HeaderText="ELIMINAR ASIGNACIÓN">
                                 <ItemTemplate>
                                     <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="img/delete_PI.png" Height="38px" OnCommand="ImageButton_Command"
                                          CommandArgument='<%# Eval("ID_PERITO_ASIGNADO") %>'
                                       OnClientClick = "return confirm('¿Desea eliminar al Policia de la orden?');" />
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
                    <asp:SqlDataSource ID="dsVerPERITOS" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="Ver_Peritos_solicitud" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ID_sol" QueryStringField="ID_SP" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                    <asp:Label ID="idPolicia" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
        </table>


        
        

 </ContentTemplate>
    </asp:UpdatePanel>
    

    
    
    
</div>

</asp:Content>

