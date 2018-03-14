<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CargarVideosPeritos.aspx.cs" Inherits="AtencionTemprana.CargarVideosPeritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .margen
        {
            margin: 5px;    
        }
    .style2
    {
        height: 48px;
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
    </table>

   
    <table style="width: 100%;">
            <tr>
                <td>
                    <br />
                    <asp:ImageButton ID="IBOrden" runat="server" Height="18px" 
                        ImageUrl="img/ordenes.png" onclick="IBOrden_Click" Width="18px" />
                     <asp:Label ID="lblMisOrdenes" Text="ORDEN" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                    
                    <asp:ImageButton ID="IBEliminar" runat="server" Height="18px" 
                        ImageUrl="img/video.png" onclick="IBEliminar_Click" Width="18px" />
                     <asp:Label ID="Label5" Text="ELIMINAR VÍDEOS" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3" class="style2">
                    <br />
                    <h2> CARGAR VIDEO </h2>
                </td>
            </tr>  
            <tr>
                <td >
                    <asp:Label ID="Label1" runat="server" Text="TÍTULO" class="margen" Font-Size="14"></asp:Label>
                    <asp:TextBox ID="txtTitulo" runat="server" Width="250px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="DESCRIPCIÓN" class="margen" Font-Size="14"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="SELECCIONAR" class="margen" Font-Size="14"></asp:Label>
                    <asp:FileUpload ID="FileUpload" runat="server" />
                    <br />
                    <br />
                    <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                            Text="GUARDAR" Width="100px" />
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td> 
                    
                     <asp:GridView ID="gvVideosP" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" 
                        AutoGenerateColumns="False" DataSourceID="dsCargarVideoRecienteP" 
                        AllowPaging="True" 
                       >

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:BoundField DataField="ID_VIDEO" HeaderText="ID_VIDEO" 
                                SortExpression="ID_VIDEO" Visible="false" />
                            <asp:TemplateField HeaderText="VIDEO ">
                                 <ItemTemplate>
                                        <a href="VideosPericiales/<%# Eval("VIDEO") %>"
                                           style="display:block;width:425px;height:300px;"
                                           class="player">
                                        </a>
                                 </ItemTemplate>
                          </asp:TemplateField>
                            
                            
                            <asp:TemplateField HeaderText="ELIMINAR ">
                            <ItemTemplate>
                                     <asp:ImageButton ID="IBImage" runat="server" ImageUrl="img/eliminar.png" Height="28px" OnCommand="IBImage_Command"
                                          CommandArgument='<%# Eval("ID_VIDEO") %>' 
                                          OnClientClick = "return confirm('¿DESEA ELIMINAR EL VÍDEO?');"/>
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
                     <asp:SqlDataSource ID="dsCargarVideoRecienteP" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                         SelectCommand="CargarVideoUltimoPericiales" 
                         SelectCommandType="StoredProcedure">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="IdCarpeta" Name="ID_CARPETA" 
                                 PropertyName="Text" Type="Int32" />
                             <asp:ControlParameter ControlID="IdUsuario" Name="ID_USUARIO" 
                                 PropertyName="Text" Type="Int32" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                </td>
            </tr>    
            <tr>
                <td>
                   
                   <script src="FlowPlayer/flowplayer-3.2.12.min.js" type="text/javascript"></script>

                         <script type="text/javascript">
                             flowplayer("a.player", "FlowPlayer/flowplayer-3.2.16.swf", {
                                 clip: {
                                     autoPlay: false,
                                     autoBuffering: true
                                 }
                             });
                    </script>
        
                </td>
            </tr> 
                        
        </table>
                
    
   

       


              

    </ContentTemplate>
    </asp:UpdatePanel>

    
    
    
</div>

</asp:Content>
