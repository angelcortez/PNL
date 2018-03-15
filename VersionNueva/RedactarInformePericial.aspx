<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RedactarInformePericial.aspx.cs" Inherits="AtencionTemprana.RedactarInformePericial" %>
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
        .style2
    {
        height: 19px;
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
    <asp:PostBackTrigger ControlID="cmdElaborarInforme" />
    <asp:PostBackTrigger ControlID="cmdGuardar" />
    </Triggers>
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
                    <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="ID_ESTADO_NUC" runat="server"></asp:Label>
             </td>
        </tr>
        <tr>
             <td>
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#666666" 
                     style="text-transform :uppercase"></asp:Label>
                     <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="IdSP" runat="server" Visible="False" ></asp:Label>
                   
                 <asp:Label ID="IDtIPOuNIDAD" runat="server" Text=" " Visible="false"></asp:Label>
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
                            <asp:ImageButton ID="Image1" runat="server" Height="18px" 
                                ImageUrl="img/ordenes.png" onclick="Image1_Click" class="margen"/>
                            <asp:Label ID="lblMisOrdenes" Text="ORDEN" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>      
                    <br />
                    <br />
                </td>
            </tr>
        </table>
      <table style="width: 100%;" runat="server" id="tbl_informe">
      <tr>
      <td>
          <asp:Label ID="LBLPERITAJE" runat="server" Text="PERITAJE SOLICITADO"></asp:Label>
          </td>
      </tr>
      <tr>
      <td>
          <asp:TextBox ID="txtPeritajeSol" runat="server" Width="200px"></asp:TextBox>
          </td>
      </tr>
       <tr>
      <td>
          <asp:Label ID="lbldepto" runat="server" Text="DEPARTAMENTO"></asp:Label>
           </td>
      </tr>
      <tr>
      <td>
          <asp:TextBox ID="txtDpto" runat="server" Width="200px"></asp:TextBox>
          </td>
      </tr>
       <tr>
      <td>
          <asp:Label ID="lblespeSP" runat="server" Text="ESPECIFICACIONES"></asp:Label>
           </td>
      </tr>
      <tr>
      <td>
          <asp:TextBox ID="txtEspeSP" runat="server" Width="200px"></asp:TextBox>
          </td>
      </tr>
       <tr>
      <td class="style2">
          <asp:Label ID="lblasigSP" runat="server" Text="ASIGNADO A"></asp:Label>
           </td>
      </tr>
      <tr>
      <td>
          <asp:TextBox ID="txtAsigS" runat="server" Width="200px"></asp:TextBox>
          </td>
      </tr>
      </TABLE>
      <TABLE>
      <tr>
      <td colspan="2" >
          <asp:Label ID="LBLSOL" runat="server" Text="SOLICITADO EL"></asp:Label>
      </td>
      <td colspan="2">
          <asp:Label ID="LBLINI" runat="server" Text="INICIADO EL"></asp:Label>
      </td>
      </tr>
      <tr>
      <td colspan="2">
          <asp:TextBox ID="txtsolSP" runat="server"></asp:TextBox>
      </td>
      <td colspan="2">
          <asp:TextBox ID="txtiniSp" runat="server"></asp:TextBox>
      </td>
      </tr>
      <tr>
      <td  colspan="2" >
          <asp:Label ID="lblasignadoel" runat="server" Text="ASIGNADO EL"></asp:Label>
          </td >
      <td  colspan="2">
          <asp:Label ID="lblterel" runat="server" Text="TERMINADO EL"></asp:Label>
          </td>

      </tr>
      <tr>
      <td  colspan="2" >
          <asp:TextBox ID="txtasigEl" runat="server"></asp:TextBox>
          </td>
      <td  colspan="2">
          <asp:TextBox ID="txtterminadoel" runat="server"></asp:TextBox>
          </td>

      </tr>
      </TABLE>
      <TABLE>
            <tr>
                <td>
                    
                     <asp:Label ID="Label1" runat="server" Text="DICTAMEN" Font-Bold="True" ></asp:Label>
                     </td>
                     </tr>
                     <tr>
                     <td>
                     <asp:TextBox ID="txtDictamen" runat="server" Height="65px" TextMode="MultiLine" style="text-transform :uppercase"
                         Width="680px"></asp:TextBox>
                 
                     </td></tr>
                     <tr>
                     <td>
                    <asp:Button ID="cmdInforme" runat="server" Text="GUARDAR DICTAMEN" 
                        onclick="cmdInforme_Click" />
                </td>
            </tr>
            <tr>
                <%--<td >
                    <br />
                     <br />
                    <asp:GridView ID="gvAnexos" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="928px" DataKeyNames="ID_ANEXO"
                        AutoGenerateColumns="False" DataSourceID="dsCargarAnexos" 
                        AllowPaging="True" onrowdatabound="gvAnexos_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        

                          <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                                <asp:CheckBox ID="ckboxPI"  runat="server" />
                            </ItemTemplate>
                          </asp:TemplateField>

                          <asp:BoundField DataField="ID_ANEXO" HeaderText="ID_ANEXO" 
                                SortExpression="ID_ANEXO" Visible="True" >
                                <ItemStyle CssClass="hidden"/>
                                 <HeaderStyle CssClass="hidden"/>
                          </asp:BoundField>
                            <asp:BoundField DataField="NOMBRE" HeaderText="ANEXO" ReadOnly="True" 
                                SortExpression="NOMBRE" />
                            
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
                        SelectCommand="CargarAnexos" SelectCommandType="StoredProcedure">
                     <SelectParameters>
                         <asp:ControlParameter ControlID="IdCarpeta" Name="ID_CARPETA" 
                             PropertyName="Text" Type="Int32" />
                     </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                     <br />
                    <asp:Button ID="cmdAnexos" runat="server" Text="GUARDAR ANEXOS" 
                        onclick="cmdAnexos_Click" />
                     <br />
                     <br />
                </td>--%>
            </tr>
         </table>
            
      <table runat="server" id="tbl_elaborar">
        <tr>
            <td colspan="5" class="style5">
            <br />
               
            <br />
            <asp:Button ID="cmdElaborarInforme" runat="server" Text="ELABORAR INFORME" 
                    onclick="cmdElaborarInforme_Click" />
            <br />
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
            
                 <asp:FileUpload ID="FileUpload1" runat="server" />  <asp:Label ID="Label4" runat="server"></asp:Label>
                 <br />
                  <br />
                 <asp:Button ID="cmdGuardar" runat="server"  
                        onclick="cmdGuardar_Click" TabIndex="32" Text="GUARDAR DOCUMENTO" 
                        Width="256px" Font-Bold="True" />
                        <br />
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
            </td>
        </tr>
       
    </table>
    
  </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>
