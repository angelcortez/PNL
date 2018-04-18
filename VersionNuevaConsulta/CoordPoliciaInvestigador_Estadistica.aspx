<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoordPoliciaInvestigador_Estadistica.aspx.cs" Inherits="AtencionTemprana.CoordPoliciaInvestigador_Estadistica" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
     .hidden
     {
         display:none;
     }
    .style2
    {
        width: 111px;
    }
    .style3
    {
            width: 988px;
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
                 <asp:Label ID="IdOrden" runat="server" Visible="false" ></asp:Label>
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
                    
                </td>
            </tr>
            
             
            
        </table>

       
       

        <table runat="server" id="tbl_asignarPI">
            <tr>
                <td>
                     <br />
                     <br />
                     <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" 
                         Text="ESTADISTICA" style="font-size:20px"></asp:Label>
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
                        <asp:ListItem Value="1">FECHA </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;

                   
                    

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
                <td align="center">
                    <br />
                    
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="CARGA DE TRABAJO DE LOS POLICIAS INVESTIGADORES" style="font-size:14px"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
             <td>
                        <asp:GridView ID="EstadisticaPI" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" DataKeyNames="ID_USUARIO"
                        AutoGenerateColumns="False" DataSourceID="dsCargaTrabajo" 
                        AllowPaging="True" onrowdatabound="EstadisticaPI_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        

                          

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
                        SelectCommand="Carga_PI_Estadistica" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUnidad" Name="IDUNIDAD" PropertyName="Text" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                    <asp:SqlDataSource ID="dsBusquedaCargaTrabajo" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="Busqueda_Carga_PI_Estadistica" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdUnidad" Name="IDUNIDAD" PropertyName="Text" 
                                Type="Int32" />
                            <asp:ControlParameter ControlID="txtFechaInicioOrden" Name="fechainicial" 
                                PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtFechaFinOrden" Name="fechafinal" 
                                PropertyName="Text" Type="DateTime" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                </td>
            </tr>
        </table>



        <table runat="server" id="tbl_">
            <tr>
                <td  class="style3">
                  <asp:Chart ID="chIniciada" runat="server" DataSourceID="ds_Estadistica" 
                    Height="345px" Palette="EarthTones" Width="926px" >
                    <Series>
                        <asp:Series IsValueShownAsLabel="True" Name="Series1" XValueMember="NOMBRE" Font="Arial, 8.25pt, style=Bold" 
                            YValueMembers="TOTAL" ChartType="StackedColumn">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="True" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Name="Title1" Text="CARGA DE TRABAJO DE LOS POLICIAS INVESTIGADORES" Font="Arial, 10pt, style=Bold" ForeColor="#006600">
                        </asp:Title>
                    </Titles>

                </asp:Chart>
                </td>
            </tr>
            <tr>
                <td>
                <asp:SqlDataSource ID="ds_Estadistica" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="Carga_PI_Estadistica" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="IdUnidad" Name="IDUNIDAD" PropertyName="Text" 
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
