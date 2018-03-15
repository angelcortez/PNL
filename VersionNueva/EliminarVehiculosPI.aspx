<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarVehiculosPI.aspx.cs" Inherits="AtencionTemprana.EliminarVehiculosPI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function mostrarFichero(destino) {
            window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
            document.forms(0).submit();
        }
    
    </script>
    <style type="text/css">
        .margen
        {
            margin: 5px;    
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
                <table >                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           <table style="width: 100%;">
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
                             <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                             <asp:Label ID="IdUsuario" runat="server" Visible="false"></asp:Label>
                             <asp:Label ID="IdOrden" runat="server" Visible="false" ></asp:Label>
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
                                <br />
                                <asp:ImageButton ID="IBOrden" runat="server" Height="18px" 
                                    ImageUrl="img/object.png" onclick="IBOrden_Click" Width="18px" />
                                 <asp:Label ID="lblMisOrdenes" Text="REGISTRAR OBJETOS" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                            </td>
                        </tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 <table>    
                        <tr>
                        <td >
                            <br />
                            <h2> ELIMINAR&nbsp; VEHICULOS </h2>
                            <br />
                    
                        </td>
                    </tr>  
                        <tr>
                            <asp:GridView ID="gvVehiculos" runat="server" BackColor="White" 
                                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                    ForeColor="Black" GridLines="Vertical" Width="928px" 
                                    AutoGenerateColumns="False" DataSourceID="dsCargarVehiculos" 
                                    AllowPaging="True" 
                                   >

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                            
                                        <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                             <asp:Image ID="Image2" runat="server" Height="28px" ImageUrl="img/object.png" /></a>
                                        </ItemTemplate>
                                      </asp:TemplateField>

                                        <asp:BoundField DataField="ID_OBJETO" HeaderText="ID_OBJETO" 
                                            SortExpression="ID_OBJETO" Visible="false" />
                                            <asp:BoundField DataField="LINEA" HeaderText="LINEA" ReadOnly="True" 
                                            SortExpression="LINEA" />
                                        <asp:BoundField DataField="MARCA" HeaderText="MARCA" 
                                            SortExpression="MARCA" Visible="true" />
                                        <asp:BoundField DataField="MODELO" HeaderText="MODELO" 
                                            SortExpression="MODELO" Visible="true" />
                                        <asp:BoundField DataField="COLOR" HeaderText="COLOR" 
                                            SortExpression="COLOR" Visible="true" />
                                        <asp:BoundField DataField="PLACA" HeaderText="PLACA" 
                                            SortExpression="PLACA" Visible="true" />
                                        <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" 
                                            SortExpression="ESTADO" Visible="true" />
                                        <asp:BoundField DataField="TIPO" HeaderText="TIPO" 
                                            SortExpression="TIPO" Visible="true" />
                                        <asp:BoundField DataField="NUM_SERIE" HeaderText="NUMERO SERIE" 
                                            SortExpression="NUM_SERIE" Visible="true" />
                                        <asp:BoundField DataField="PROPIETARIO" HeaderText="PROPIETARIO" 
                                            SortExpression="PROPIETARIO" Visible="true" />
                            
                                        <asp:TemplateField HeaderText="ELIMINAR ">
                                        <ItemTemplate>
                                                 <asp:ImageButton ID="IBImageVeh" runat="server" ImageUrl="img/eliminar.png" Height="28px" OnCommand="EliminarVehiculo_Command"
                                                      CommandArgument='<%# Eval("ID_OBJETO") %>'
                                                      OnClientClick = "return confirm('¿DESEA ELIMINAR EL VEHICULO?');" />
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
                        </tr>
                        <tr>
                            <td>
                                 <asp:SqlDataSource ID="dsCargarVehiculos" runat="server" 
                                     ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                                     SelectCommand="SeleccionarVhehiculosAseguradosPI" 
                                     SelectCommandType="StoredProcedure">
                                     <SelectParameters>
                                         <asp:ControlParameter ControlID="IdCarpeta" Name="IdCarpeta" 
                                             PropertyName="Text" Type="Int32" />
                                     </SelectParameters>
                                 </asp:SqlDataSource>
                            </td>
                        </tr>   
        
                </table>
           </ContentTemplate>
        </asp:UpdatePanel>  
    </div>

</asp:Content>
