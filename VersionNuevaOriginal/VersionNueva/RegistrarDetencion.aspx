<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarDetencion.aspx.cs" Inherits="AtencionTemprana.Registrardetenido" %>
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
            
            .style7
            {
                width: 470px;
            }
            
            .style8
            {
                width: 236px;
            }
            .style9
            {
                width: 172px;
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
            <asp:PostBackTrigger ControlID="cmdElaborarDocumento" />
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
                <asp:Label ID="IdCarpeta" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </td>
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
                <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
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
                 <asp:Label ID="IdDetencion" runat="server" Visible="false" ></asp:Label>
                 <asp:Label ID="ID_OBJETO" runat="server" Visible="false" ></asp:Label>
                 <asp:Label ID="ID_ARMA" runat="server" Visible="false" ></asp:Label>
                 <asp:Label ID="ID_DROGA" runat="server" Visible="false" ></asp:Label>
                 <asp:Label ID="ID_VEHICULO" runat="server" Visible="false" ></asp:Label>
                 
                   
                 
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
                                ImageUrl="img/ordenes.png" onclick="Image1_Click" />
                            <asp:Label ID="lblMisOrdenes" Text="ORDEN" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>      
                            
            </td>
         </tr>    
        
        </table>
      <table style="width: 100%;" runat="server" id="tbl_informe">

            <tr>
                <td>
                     <h1>
                   <asp:Label ID="lblOperacion" runat="server" Text="REGISTRO DE DETENCIÓN"></asp:Label></h1>
              
                </td>
            </tr>
            <tr>
                <td colspan="4">
                        &nbsp;</td>
            </tr>
            <tr>
                <td>
                
                    <br />
                
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel2" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="#006600" GroupingText="REGISTRAR OBJETO">
                        <table style="width: 100%;">
                        <tr>
                        <td colspan="3">
                        
                            <asp:Label ID="Label60" runat="server" Font-Bold="True" Font-Italic="True" 
                                ForeColor="Black" Text="IMPUTADO"></asp:Label>
                        
                        </td>
                        
                        </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlImputado" runat="server" Width="400px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                
                                <td class="style8">
                                    <br />
                                    <asp:Label ID="Label337" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="TIPO DE OBJETO:"></asp:Label>
                                </td>
                                <td class="style9">
                                    <br />
                                    &nbsp;<asp:Label ID="Label338" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="CANTIDAD:"></asp:Label>
                                </td>
                                <td>
                                    <br />
                                    <asp:Label ID="Label339" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="DESCRIPCIÓN:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                                <td class="style8">
                                    <asp:TextBox ID="txtObj" runat="server" MaxLength="150" Width="181px"></asp:TextBox>
                                </td>
                                <td class="style9">
                                    <asp:TextBox ID="txtCantidadObjeto" runat="server" MaxLength="3" Width="89px"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RgularExpressionValidator1" runat="server" ControlToValidate="txtCantidadObjeto"
                                                ErrorMessage="*" ForeColor="Red" ValidationExpression="^[0-9^]+$"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescObj" runat="server" MaxLength="2000" Width="306px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <br />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAgregarObj" runat="server" onclick="btnAgregarObj_Click1" 
                            Text="AGREGAR" />
                        <br />
                        <br />
                        &nbsp;
                        <asp:Label ID="Label335" runat="server" Font-Bold="True" Visible="false" 
                            Text="LISTADO DE OBJETOS:"></asp:Label>
                        <br />
                        <br />
                        <asp:GridView ID="gvConsultarObjetos" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                            DataSourceID="dsObjetosDetSec" ForeColor="Black" GridLines="Vertical" 
                            Width="928px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" 
                                    SortExpression="CANTIDAD" Visible="True">
                                </asp:BoundField>
                                <asp:BoundField DataField="TIPO_OBJETO" HeaderText="TIPO_OBJETO" 
                                    SortExpression="TIPO_OBJETO" />
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
                        <asp:SqlDataSource ID="dsObjetosDetSec" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>" 
                            SelectCommand="CargarGridObjetosDetSec" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ID_PERSONA" Name="ID_PERSONA" 
                                    PropertyName="Text" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                        <asp:SqlDataSource ID="dsVerObjetos" runat="server" 
                           >
                            
                        </asp:SqlDataSource>
                </td>
                
            </tr>
            <tr>
            <td>
            
            </td>
            </tr>
            <tr>
            <td>
            
            </td>
            </tr>
            <tr>
            <td>
            
            </td>
            </tr>
           <tr>
           <td>
           
               &nbsp;</td>
           
           </tr>
            <tr>
           <td>
           
           </td>
           
           </tr>
            <tr>
           <td>
           
               <asp:Panel ID="PanelArmas" runat="server" Font-Bold="True" Font-Size="Medium" 
                   ForeColor="#006600" GroupingText="ARMAS" Visible="true">
                   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                       <ContentTemplate>
                           <table style="width: 100%;">
                               <tr>
                                   <td>
                                       &nbsp;
                                   </td>
                                   <td>
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
                                       <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="TIPO ARMA"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="ARMA"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="TAMAÑO DEL ARMA"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="MARCA"></asp:Label>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:DropDownList ID="ddlTipoArma" runat="server" AutoPostBack="True" 
                                           OnSelectedIndexChanged="ddlTipoArma_SelectedIndexChanged" TabIndex="35" 
                                           Width="200px">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:DropDownList ID="ddlArma" runat="server" AutoPostBack="True" TabIndex="36" 
                                           Width="200px">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:DropDownList ID="ddlTamañoArma" runat="server" TabIndex="37" Width="200px">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:DropDownList ID="ddlMarcaArma" runat="server" TabIndex="38" Width="200px">
                                       </asp:DropDownList>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       &nbsp;
                                   </td>
                                   <td>
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
                                       <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="CALIBRE"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label40" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="ESTADO DEL ARMA"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label41" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="MATRICULA"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label346" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="SERIE"></asp:Label>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:DropDownList ID="ddlCalibreArma" runat="server" TabIndex="39" 
                                           Width="200px">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:DropDownList ID="ddlEstadoArma" runat="server" TabIndex="40" Width="200px">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtMatricula" runat="server" MaxLength="50" TabIndex="41" 
                                           Width="190px"></asp:TextBox>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtSerieArma" runat="server" MaxLength="50" TabIndex="41" 
                                           Width="190px"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       &nbsp;
                                   </td>
                                   <td>
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
                                       <asp:Label ID="Label345" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="DESCRIPCIÓN"></asp:Label>
                                   </td>
                                   <td>
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
                                       <asp:TextBox ID="txtDescripcionArma" runat="server" MaxLength="50" 
                                           TabIndex="41" Width="190px"></asp:TextBox>
                                   </td>
                                   <td>
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
                                   <td>
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
                                       &nbsp;&nbsp;
                                       <asp:Button ID="btnAgregarArma" runat="server" OnClick="btnAgregarArma_Click" 
                                           TabIndex="42" Text="AGREGAR" Width="142px" />
                                   </td>
                                   <td>
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
                                   <td>
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
                                       <asp:Label ID="Label343" runat="server" Font-Bold="True" Font-Size="Small" Visible="false" 
                                           ForeColor="Black" Text="LISTA DE ARMAS:"></asp:Label>
                                   </td>
                                   <td>
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
                                       <asp:GridView ID="gvArmas" runat="server" AllowPaging="True" 
                                           AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                                           BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="dsVerArmas" 
                                           ForeColor="Black" GridLines="Vertical" Width="928px">
                                           <AlternatingRowStyle BackColor="White" />
                                           <Columns>
                                               <asp:BoundField DataField="ARMA_TPO" HeaderText="ARMA_TPO" 
                                                   SortExpression="ARMA_TPO" Visible="true">
                                               </asp:BoundField>
                                               <asp:BoundField DataField="ARMA" HeaderText="ARMA" 
                                                   SortExpression="ARMA" />
                                               <asp:BoundField DataField="ARMAS_AA" HeaderText="ARMAS_AA" 
                                                   SortExpression="ARMAS_AA" />
                                               <asp:BoundField DataField="MARCA" HeaderText="MARCA" 
                                                   SortExpression="MARCA" />
                                               <asp:BoundField DataField="CALIBRE" HeaderText="CALIBRE" 
                                                   SortExpression="CALIBRE" />
                                               <asp:BoundField DataField="ESTADO_ARMA" HeaderText="ESTADO_ARMA" 
                                                   SortExpression="ESTADO_ARMA" />
                                               <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" 
                                                   SortExpression="DESCRIPCION" />
                                               <asp:BoundField DataField="MATRICULA" HeaderText="MATRICULA" 
                                                   SortExpression="MATRICULA" />
                                               <asp:BoundField DataField="SERIE" HeaderText="SERIE" SortExpression="SERIE" />
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
                                       <asp:SqlDataSource ID="dsVerArmas" runat="server" 
                                           ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>" 
                                           SelectCommand="CargarGridArmasDetSec" SelectCommandType="StoredProcedure" 
                                         >
                                          
                                           <SelectParameters>
                                               <asp:ControlParameter ControlID="ID_PERSONA" Name="ID_PERSONA" 
                                                   PropertyName="Text" Type="Int32" />
                                           </SelectParameters>
                                          
                                       </asp:SqlDataSource>
                                   </td>
                               </tr>
                           </table>
                       </ContentTemplate>
                   </asp:UpdatePanel>
               </asp:Panel>
           
           </td>
           
           </tr>
            <tr>
           <td>
           
           </td>
           
           </tr>

            <tr>
           <td>
           
               <asp:Panel ID="PanelDrogas" runat="server" Font-Bold="True" Font-Size="Medium" 
                   ForeColor="#006600" GroupingText="DROGAS ASEGURADAS" Visible="true">
                   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                       <ContentTemplate>
                           <table style="width: 100%;">
                               <tr>
                                   <td>
                                       &nbsp;
                                   </td>
                                   <td>
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
                                       <asp:Label ID="Label359" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="TIPO DE DROGA"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label360" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="UNIDAD DE MEDIDA"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label361" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="CANTIDAD"></asp:Label>
                                   </td>
                                   <td>
                                       <asp:Label ID="Label362" runat="server" Font-Bold="True" Font-Size="Small" 
                                           ForeColor="Black" Text="OBSERVACIONES"></asp:Label>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:TextBox ID="txtTipoDroga" runat="server" MaxLength="50" TabIndex="41" 
                                           Width="190px"></asp:TextBox>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtUnidadDeMedida" runat="server" MaxLength="50" TabIndex="41" 
                                           Width="190px"></asp:TextBox>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtCantidad" runat="server" MaxLength="50" TabIndex="41" 
                                           Width="190px"></asp:TextBox>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtObservacionesD" runat="server" MaxLength="50" TabIndex="41" 
                                           Width="190px"></asp:TextBox>
                                   </td>
                               </tr>
                               
                               
                               <tr>
                                   <td>
                                       &nbsp;
                                   </td>
                                   <td>
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
                                      
                                       <asp:Button ID="btnAgregarDroga" runat="server" 
                                           TabIndex="42" Text="AGREGAR" Width="142px" 
                                           onclick="btnAgregarDroga_Click" />
                                   </td>
                                   <td>
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
                                   <td>
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
                                       <asp:Label ID="Label368" runat="server" Font-Bold="True" Font-Size="Small" Visible="false"
                                           ForeColor="Black" Text="LISTA DE DROGAS:"></asp:Label>
                                   </td>
                                   <td>
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
                                       <asp:GridView ID="gvDroga" runat="server" AllowPaging="True" 
                                           AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                                           BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="dsVerDroga" 
                                           ForeColor="Black" GridLines="Vertical" Width="928px">
                                           <AlternatingRowStyle BackColor="White" />
                                           <Columns>
                                               <asp:BoundField DataField="TIPO" HeaderText="TIPO" SortExpression="TIPO" 
                                                   Visible="true">
                                               </asp:BoundField>
                                               <asp:BoundField DataField="UNIDAD_MEDIDA" HeaderText="UNIDAD_MEDIDA" 
                                                   SortExpression="UNIDAD_MEDIDA" />
                                               <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" 
                                                   SortExpression="CANTIDAD" />
                                               <asp:BoundField DataField="OBSERVACIONES" HeaderText="OBSERVACIONES" 
                                                   SortExpression="OBSERVACIONES" />
                                              
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
                                       <asp:SqlDataSource ID="dsVerDroga" runat="server" 
                                           ConnectionString="<%$ ConnectionStrings:PGJ_CURSO_NSJPConnectionString %>" 
                                           SelectCommand="CargarGridDrogaDetSec" SelectCommandType="StoredProcedure" 
                                           >
                                           
                                           <SelectParameters>
                                               <asp:ControlParameter ControlID="ID_PERSONA" Name="ID_PERSONA" 
                                                   PropertyName="Text" Type="Int32" />
                                           </SelectParameters>
                                           
                                       </asp:SqlDataSource>
                                   </td>
                               </tr>
                           </table>
                       </ContentTemplate>
                   </asp:UpdatePanel>
               </asp:Panel>
           
           </td>
           
           </tr>

         </table>
            
      <table runat="server" id="tbl_elaborar">
        <tr>
            <td class="style7">
               
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cmdElaborarDocumento" runat="server" Text="ELABORAR DOCUMENTO" Visible="false" 
                    onclick="cmdElaborarDocumento_Click" Width="201px"/>
                &nbsp;&nbsp;&nbsp;
                <br />
            <br />
                
            </td>
        </tr>
        <tr>
            <td class="style7"  >
            
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
                 <asp:Label ID="Label332" runat="server" Font-Bold="True" Font-Size="Small" 
                     ForeColor="Black" Text="SELECCIONE DOCUMENTO PDF"></asp:Label>
            
                 <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:FileUpload ID="FileUpload1" runat="server" />
                 <asp:Label ID="Label333" runat="server"></asp:Label>
            
                 <br />
                  <br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="cmdGuardar" runat="server"  
                         TabIndex="32" Text="GUARDAR DOCUMENTO" 
                        Width="256px" Font-Bold="True" onclick="cmdGuardar_Click" />
                        <br />
                    <br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
            </td>
            <td>
            
            </td>
             <td>
            
            </td>
            
        </tr>
        <tr>
             <td class="style7">
            
            </td>
             <td>
            
                 <asp:Button ID="cmdRegresar" runat="server" onclick="cmdRegresar_Click" 
                     Text="REGRESAR" Height="37px" Width="165px" />
            
            </td>
            <td>
            
            </td>
        </tr>
       
    </table>
    
  </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>
