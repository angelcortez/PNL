<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarDetenidoPI.aspx.cs" Inherits="AtencionTemprana.AsignarDetenidoPI" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function mostrarFichero(destino) {
        window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
        document.forms(0).submit();
    }
</script>



        <style>
            .hidden
             {
                display:none;
             }
            .margen 
            {
                margin:5px
            }
            
            #myDIV {
                border: 1px solid black;
                margin-bottom: 10px;
            }

            #myDIVEHICULOS {
                border: 1px solid black;
                margin-bottom: 10px;
            }
            
            .style3
            {
                width: 457px;
            }
            
            .style4
            {
                width: 932px;
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
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Font-Size="Medium"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
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
                <asp:Label ID="lblArbol" runat="server" Visible="False">6</asp:Label>
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
                  
                    <asp:Label ID="ID_ESTADO_NUC" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                    
             </td>
        </tr>
        <tr>
             <td>
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#666666" 
                     style="text-transform :uppercase"></asp:Label>
                     <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="IdDetencion" runat="server" Visible="false" ></asp:Label>
                 
                   
                 
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="right">
                 &nbsp;</td>
         </tr>
             
        
        </table>
      <table style="width: 100%;" runat="server" id="tbl_informe">

            <tr>
                <td>
                     <h2>
                   <asp:Label ID="lblOperacion" runat="server" Text="ASIGNAR DETENIDO A CARPETA DE INVESTIGACIÓN"></asp:Label></h2>
               
                   
                     <p>
                         &nbsp;</p>
               
                   
                </td>
            </tr>

         </table>
            
      <table runat="server" id="tbl_elaborar">
         <tr>
             <td>
                        <asp:GridView ID="gvAsignarPI" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" DataKeyNames="ID_PERSONA"
                        AutoGenerateColumns="False" DataSourceID="dsDetenidos" 
                        AllowPaging="True" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        

                          <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                                <asp:CheckBox ID="ckboxPI"  runat="server" />
                            </ItemTemplate>
                          </asp:TemplateField>

                          <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" 
                                SortExpression="ID_PERSONA" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                            <asp:BoundField DataField="DETENIDO" HeaderText="NOMBRE DETENIDO" ReadOnly="True" 
                                SortExpression="DETENIDO" />
                           
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
               
                    <asp:SqlDataSource ID="dsDetenidos" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="SeleccionarDetenidosPI" SelectCommandType="StoredProcedure">
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
        
        
       
    </table>
    
  </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>

