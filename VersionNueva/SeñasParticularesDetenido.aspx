<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeñasParticularesDetenido.aspx.cs" Inherits="TarjetaInformativa.SeñasParticularesOfendido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hidden
     {
         display:none;
     }
        .style1
        {
        }
        .style2
        {
        }
        .style3
        {
            width: 734px;
            height: 887px;
        }
        .style9
        {
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
    <div id="main-wrapper">
    <asp:ScriptManager ID="sc" runat="server">
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

                </td>
            <td>
                </td>
            <td>
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
         <tr>
             <td>
                 <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
                 <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#666666" 
                     style="text-transform :uppercase"></asp:Label>
                     
             </td>
             <td>
                 <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
             </td>
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
                 <asp:Label ID="IdDetencion" runat="server" Visible="FALSE" ></asp:Label>
                 <asp:Label ID="IDtIPOuNIDAD" runat="server" Text=" " Visible="false"></asp:Label>
                  <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
             </td>
             <td>
                 <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td align="right">
                 &nbsp;</td>
         </tr>
     
      
    </table>

     
           <div class="welcome">
               <h1>
                   <asp:Label ID="lblOperacion" runat="server" Text="SEÑAS PARTICULARES"></asp:Label></h1>
               <p>
                   &nbsp;</p>
             <table style="width: 100%;">
                     <tr>
           <td>
           
               <asp:Panel ID="Panel1" runat="server" Font-Bold="True" Font-Size="Medium" 
                   ForeColor="#006600" GroupingText="" Visible="true">
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                       <ContentTemplate>
                   <table style="width: 100%;">
                       
                       <tr> 
                       <td colspan="4">
                       
                           <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="IMPUTADO"></asp:Label>
                       
                       </td>
                       </tr>



                       <tr>
                           <td colspan="4">
                               <asp:DropDownList ID="ddlImputado" runat="server" Width="400px">
                               </asp:DropDownList>
                           </td>
                       </tr>
                       <tr>
                           <td colspan="4">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td colspan="4">
                               &nbsp;</td>
                       </tr>



                       <tr>
                           <td>
                               &nbsp;
                           </td>
                           <td class="style9">
                               &nbsp;
                           </td>
                           <td>
                               &nbsp;
                           </td>
                           <td>
                               &nbsp;
                           </td>
                       </tr>
                       <tr>
                           <td>
                               <asp:Label ID="Label353" runat="server" Font-Bold="True" Font-Italic="False" 
                                   Font-Size="Small" ForeColor="Black" Text="TIPO DE SEÑA"></asp:Label>
                           </td>
                           <td class="style9">
                               <asp:Label ID="Label355" runat="server" Font-Bold="True" Font-Size="Small" 
                                   ForeColor="Black" Text="DESCRIPCION DE SEÑA"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="Label356" runat="server" Font-Bold="True" Font-Size="Small" 
                                   ForeColor="Black" Text="VISTA"></asp:Label>
                           </td>
                           <td>
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               <asp:DropDownList ID="ddlTipoSeña" runat="server" Width="200px">
                               </asp:DropDownList>
                           </td>
                           <td class="style9">
                               <asp:DropDownList ID="ddlDescripcionSeña" runat="server" Width="200px">
                               </asp:DropDownList>
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlVista" runat="server" Width="200px">
                               </asp:DropDownList>
                           </td>
                           <td>
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               &nbsp;
                           </td>
                           <td class="style9">
                               &nbsp;
                           </td>
                           <td>
                               &nbsp;
                           </td>
                           <td>
                               &nbsp;
                           </td>
                       </tr>
                       <tr>
                           <td>
                               <asp:Label ID="Label354" runat="server" Font-Bold="True" Font-Italic="False" 
                                   Font-Size="Small" ForeColor="Black" Text="LADO"></asp:Label>
                           </td>
                           <td class="style9">
                               <asp:Label ID="Label77" runat="server" Font-Bold="True" Font-Size="Small" 
                                   ForeColor="Black" Text="REGIÓN (número)"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="Label78" runat="server" Font-Bold="True" Font-Size="Small" 
                                   ForeColor="Black" Text="CANTIDAD"></asp:Label>
                           </td>
                           <td>
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               <asp:DropDownList ID="ddlLado" runat="server" Width="200px">
                               </asp:DropDownList>
                           </td>
                           <td class="style9">
                               <asp:DropDownList ID="ddlRegion" runat="server" Width="200px">
                               </asp:DropDownList>
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlCantidad" runat="server" Width="200px">
                               </asp:DropDownList>
                           </td>
                           <td>
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               &nbsp;
                           </td>
                           <td class="style9">
                               &nbsp;
                           </td>
                           <td>
                               &nbsp;
                           </td>
                           <td>
                               &nbsp;
                           </td>
                       </tr>
                         <tr>
                           <td>
                            
                               <asp:Label ID="Label357" runat="server" Font-Bold="True" Font-Italic="False" 
                                   Font-Size="Small" ForeColor="Black" Text="DESCRIPCIÓN"></asp:Label>
                             </td>
                           <td class="style9">
                           
                               &nbsp;</td>
                           <td>
                             
                               &nbsp;</td>
                           <td>
                           
                               &nbsp;</td>
                       </tr>
                         <tr>
                           <td colspan="4">
                             
                               <asp:TextBox ID="txtObservaciones" runat="server" Height="83px" 
                                   MaxLength="8000" style="text-transform :uppercase" TextMode="MultiLine" 
                                   Width="937px"></asp:TextBox>
                             </td>
                           
                       </tr>
                         <tr>
                           <td>
                              
                           </td>
                           <td class="style9">
                              
                           </td>
                           <td>
                              
                           </td>
                           <td>
                               
                           </td>
                       </tr>
                        
                      
                       
                     
                       
                          
                           <tr>
                               <td>
                                   &nbsp;
                                   <asp:Button ID="btnAgregarSeña" runat="server" Height="26px" 
                                       OnClick="btnAgregarSeña_Click1" Text="AGREGAR" Width="87px" />
                               </td>
                               <td class="style9">
                                   &nbsp;
                               </td>
                               <td>
                                   &nbsp;
                               </td>
                               <td>
                                   &nbsp;
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   &nbsp;
                               </td>
                               <td class="style9">
                                   &nbsp;
                               </td>
                               <td>
                                   &nbsp;
                               </td>
                               <td>
                                   &nbsp;
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   &nbsp;
                                   <asp:Label ID="Label352" runat="server" Font-Bold="True" Font-Size="Small" Visible="true" 
                                       ForeColor="Black" Text="SEÑAS PARTICUALARES:"></asp:Label>
                               </td>
                               <td class="style9">
                                   &nbsp;
                               </td>
                               <td>
                                   &nbsp;
                               </td>
                               <td>
                                   &nbsp;
                               </td>
                           </tr>
                           <tr>
                               <td colspan="4">
                                   <asp:GridView ID="gvSeñasParticulares" runat="server" AllowPaging="True" 
                                       AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                                       BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                       DataSourceID="dsVerSeñas" ForeColor="Black" GridLines="Vertical" 
                                       Width="900px">
                                       <AlternatingRowStyle BackColor="White" />
                                       <Columns>
                                           <asp:BoundField DataField="ID_SEÑA" HeaderText="ID_SEÑA" 
                                               SortExpression="ID_SEÑA" Visible="True">
                                           </asp:BoundField>
                                           <asp:BoundField DataField="TIPO_SEÑA" HeaderText="TIPO_SEÑA" 
                                               SortExpression="TIPO_SEÑA" />
                                           <asp:BoundField DataField="DES_SEÑA" HeaderText="DES_SEÑA" 
                                               SortExpression="DES_SEÑA" />
                                           <asp:BoundField DataField="VISTA" HeaderText="VISTA" 
                                               SortExpression="VISTA" />
                                           <asp:BoundField DataField="LADO" HeaderText="LADO" 
                                               SortExpression="LADO" />
                                           <asp:BoundField DataField="REGION" HeaderText="REGION" 
                                               SortExpression="REGION" />
                                           <asp:BoundField DataField="CANT_REGION" HeaderText="CANT_REGION" 
                                               SortExpression="CANT_REGION" />
                                             <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" 
                                               SortExpression="DESCRIPCION" />
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
                                   <br />
                               </td>
                           </tr>
                          
                           <tr>
                               <td>
                                   &nbsp;</td>
                               <td class="style9">
                                   <asp:Button ID="cmdGuardar" runat="server" Height="40px" 
                                       onclick="cmdGuardar_Click" Text="SIGUIENTE" Width="156px" />
                               </td>
                               <td>
                                   <asp:Button ID="cmdregresar" runat="server" Height="40px" 
                                       onclick="cmdregresar_Click" Text="REGRESAR" Width="156px" />
                               </td>
                               <td>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <asp:SqlDataSource ID="dsVerSeñas" runat="server" 
                                       ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                                       SelectCommand="SeleccionarSeñasParticularesDetSec" 
                                       SelectCommandType="StoredProcedure">
                                      
                                       <SelectParameters>
                                           <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" 
                                               PropertyName="Text" Type="Int32" />
                                       </SelectParameters>
                                      
                                   </asp:SqlDataSource>
                               </td>
                           </tr>
                       </tr>
                   </table>
               </ContentTemplate>
                   </asp:UpdatePanel>
               </asp:Panel></td>
           
           </tr>
                  
                  
                  
                  
                   
                    
                    
                      
                  
                   
                    <tr>
                       <td class="style2" colspan="4" align="center">
                           &nbsp;
                           <img alt="" class="style3" 
                               src="img/monitodoble.jpg" />
                       </td>
                   </tr>
               </table>
           </div>
    </ContentTemplate>
    </asp:UpdatePanel>

          
        </div>
</asp:Content>

