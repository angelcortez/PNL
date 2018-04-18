<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EliminarVideosPeritos.aspx.cs" Inherits="AtencionTemprana.EliminarVideosPeritos" %>

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
                        ImageUrl="img/video.png" onclick="IBOrden_Click" Width="18px" />
                     <asp:Label ID="lblMisOrdenes" Text="CARGAR VÍDEO" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                </td>
            </tr>
            <tr>
                <td >
                    <br />
                    <h2> ELIMINAR&nbsp; VÍDEOS </h2>
                    <br />
                    
                </td>
            </tr>  
            <tr>
                <asp:GridView ID="gvVideos" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" 
                        AutoGenerateColumns="False" DataSourceID="dsCargarVideos" 
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
                            
                            <asp:BoundField DataField="TITULO" HeaderText="TITULO" 
                                SortExpression="TITULO" Visible="true" />
                            <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" 
                                SortExpression="DESCRIPCION" Visible="true" />
                            <asp:BoundField DataField="FECHA_REGISTRO" HeaderText="FECHA REGISTRO" ReadOnly="True" 
                                SortExpression="FECHA_REGISTRO" />
                            <asp:TemplateField HeaderText="ELIMINAR ">
                            <ItemTemplate>
                                     <asp:ImageButton ID="IBImage" runat="server" ImageUrl="img/eliminar.png" Height="28px" OnCommand="IBImage_Command"
                                          CommandArgument='<%# Eval("ID_VIDEO") %>'
                                          OnClientClick = "return confirm('¿DESEA ELIMINAR EL VÍDEO?');" />
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
                     <asp:SqlDataSource ID="dsCargarVideos" runat="server" 
                         ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                         SelectCommand="CargarVideosPericiales" SelectCommandType="StoredProcedure">
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
