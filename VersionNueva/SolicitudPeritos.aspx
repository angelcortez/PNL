<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitudPeritos.aspx.cs" Inherits="AtencionTemprana.SolicitudPeritos" %>



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
</style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
         
        
<div id="main-wrapper">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="cmdAsignarPI" />
        <asp:PostBackTrigger ControlID="cmdGuardar" />
        <asp:PostBackTrigger ControlID="cmdBuscar" />
        <asp:PostBackTrigger ControlID="gvServicios" />

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
         </tr>
     
      
         <tr>
             <td>
                 <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                     style="text-transform :uppercase"></asp:Label>
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdOrden" runat="server" Visible="false"></asp:Label>
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
                     <asp:Label ID="lblMisOrdenes" Text="ORDEN" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                </td>
            </tr>
        <tr>
             <td colspan="2">
                 <br />
                 <br />
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" 
                     Text="SOLICITUD DE PERITOS" style="font-size:20px"></asp:Label>
                 &nbsp;
                 <asp:Label ID="lblIdUsuario" runat="server" Text="" Visible="False"></asp:Label>
                 <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                 <br />
                 <br />
             </td>
             <td>
                 &nbsp;
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <tr>
                 <td align="center" colspan="3">
                     &nbsp; &nbsp; &nbsp;
                     <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                         ForeColor="Black" Text="BUSCAR"></asp:Label>
                     <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                     <asp:Button ID="cmdBuscar" runat="server" onclick="cmdBuscar_Click" 
                         Text="ACEPTAR" />
                 </td>
             </tr>
             <tr>
                 <td colspan="3">
                     &nbsp;<asp:GridView ID="gvServicios" runat="server" AllowPaging="True" 
                         AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                         BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID_SERVICIO" 
                         DataSourceID="dsMostrarServicio" ForeColor="Black" GridLines="Vertical" 
                         onrowdatabound="gvServicios_RowDataBound" Width="928px">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:TemplateField HeaderText=" ">
                                 <ItemTemplate>
                                     <asp:CheckBox ID="cbxServicio" runat="server" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="DPTO" HeaderText="DEPARTAMENTO" ReadOnly="True" 
                                 SortExpression="DPTO" />
                             <asp:BoundField DataField="ID_SERVICIO" HeaderText="ID_SERVICIO" 
                                 SortExpression="ID_SERVICIO" Visible="True">
                             <ItemStyle CssClass="hidden" />
                             <HeaderStyle CssClass="hidden" />
                             </asp:BoundField>
                             <asp:BoundField DataField="SERVICIO" HeaderText="SERVICIO" ReadOnly="True" 
                                 SortExpression="SERVICIO" />
                             <asp:TemplateField HeaderText="DESCRIPCIÓN">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDescripcion" runat="server" Width="300px" MaxLength="480" style="text-transform :uppercase"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <FooterStyle BackColor="#CCCC99" />
                         <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                             HorizontalAlign="Center" />
                         <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                         <RowStyle BackColor="#CCFFCC" HorizontalAlign="Center" />
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
                     <br />
                     <asp:Button ID="cmdAsignarPI" runat="server" onclick="cmdAsignarPI_Click" 
                         Text="GNERAR SOLICITUD" />
                          <br />
                     <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                     <br />
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
            
                 <asp:FileUpload ID="FileUpload1" runat="server" />  <asp:Label ID="Label2" runat="server"></asp:Label>
                 <br />
                  <br />
                <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                         Text="GUARDAR DOCUMENTO" />
                     <asp:Label ID="Label4" runat="server" Text=" "></asp:Label>
            </td>
        </tr>
        </table>
                    <asp:SqlDataSource ID="dsMostrarServicio" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="Mostrar_Servicio" SelectCommandType="StoredProcedure">                
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarServicio" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="Buscar_Servicio" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBuscar" Name="filtro" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

    </ContentTemplate>
    </asp:UpdatePanel>

    
    
    
</div>

</asp:Content>
