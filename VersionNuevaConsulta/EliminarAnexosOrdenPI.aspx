<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarAnexosOrdenPI.aspx.cs" Inherits="AtencionTemprana.EliminarAnexos" %>
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
                        ImageUrl="img/document.png" onclick="IBOrden_Click" Width="18px" />
                     <asp:Label ID="lblMisOrdenes" Text="REDACTAR INFORME" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                </td>
            </tr>
            <tr>
                <td >
                    <br />
                    <br />
                    
                </td>
            </tr>  
            <tr>
                <td>
                     <asp:GridView ID="gvAnexos" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" DataKeyNames="ID_ANEXO"
                        AutoGenerateColumns="False" DataSourceID="dsCargarAnexos" 
                        AllowPaging="True" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        

                          
                          <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                             <a href='EliminarAnexosOrdenPI.aspx?ID_ANEXO=<%#Eval("ID_ANEXO")%>&op=Anexo' >
                                 <asp:Image ID="Image2" runat="server" Height="28px" ImageUrl="img/document.png" /></a>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="ID_ANEXO" HeaderText="ID_ANEXO" 
                                SortExpression="ID_ANEXO" Visible="FALSE" >
                                
                          </asp:BoundField>
                            <asp:BoundField DataField="NOMBRE" HeaderText="ANEXO" ReadOnly="True" 
                                SortExpression="NOMBRE" />
                            <asp:TemplateField HeaderText="ELIMINAR ">
                                 <ItemTemplate>
                                     <asp:ImageButton ID="IBImage" runat="server" ImageUrl="img/eliminar.png" Height="28px" OnCommand="IBImage_Command"
                                          CommandArgument='<%# Eval("ID_ANEXO") %>'
                                          OnClientClick = "return confirm('¿DESEA ELIMINAR EL ANEXO?');" />
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
                 <asp:SqlDataSource ID="dsCargarAnexos" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="CargarTodosAnexos" SelectCommandType="StoredProcedure">
                     <SelectParameters>
                         <asp:ControlParameter ControlID="IdCarpeta" Name="ID_CARPETA" 
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


