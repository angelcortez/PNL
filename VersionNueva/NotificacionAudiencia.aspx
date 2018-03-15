<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotificacionAudiencia.aspx.cs" Inherits="AtencionTemprana.NotificacionAudiencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
         <script type="text/javascript">
             function mostrarFichero(destino) {
                 window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
                 document.forms(0).submit();
             }
    
    </script>
        
<div id="main-wrapper">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
    <asp:PostBackTrigger ControlID="gvNuc" />
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
             </td>
             <td>
                 <asp:Label ID="IdNotificacion" runat="server" Visible="False"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td align="right">
                 &nbsp;</td>
         </tr>
     
      
    </table>
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
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvNuc" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="1050px" 
                        AutoGenerateColumns="False" DataSourceID="dsConsultaNotificacion" 
                        AllowPaging="True" 
                    DataKeyNames="idNotificacionPDF" onrowdatabound="gvNuc_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="idNotificacionPDF" HeaderText="idNotificacionPDF" 
                                SortExpression="idNotificacionPDF" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="nuc" HeaderText="NUC" 
                                SortExpression="nuc" ReadOnly="True" />
                            <asp:BoundField DataField="IdUnidad" HeaderText="IdUnidad" 
                                ReadOnly="True" SortExpression="IdUnidad" Visible="False" />
                            <asp:BoundField DataField="idMunicipio" HeaderText="idMunicipio" 
                                SortExpression="idMunicipio" Visible="False" />
                            <asp:BoundField DataField="tipoAudiencia" HeaderText="TIPO AUDIENCIA" 
                                SortExpression="tipoAudiencia" />
                            <asp:BoundField DataField="fechaAudiencia" HeaderText="FECHA AUDIENCIA" ReadOnly="True" 
                                SortExpression="fechaAudiencia" />
                            <asp:BoundField DataField="HoraAudiencia" HeaderText="HORA AUDIENCIA" ReadOnly="True" 
                                SortExpression="HoraAudiencia" />

                          <asp:TemplateField HeaderText="DOCUMENTO">
                            <ItemTemplate>
                             <a href='NotificacionAudiencia.aspx?idNotificacionPDF=<%#Eval("idNotificacionPDF")%>'>
                                 <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/document.png" /></a>
                               <%--<a href='NUC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUC=<%#Eval("ID_ESTADO_NUC")%>'>
                                 <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" /></a>--%>
                            </ItemTemplate>
                          </asp:TemplateField>

                           
                                 

                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label2" runat="server" 
                                style="font-weight: 700; color: #FF3300; font-size: x-large;" 
                                Text="NO EXISTEN SOLICITUDES"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#CCCC99" />
                          <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                                                        HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#F7F7DE" 
                            ForeColor="Black" HorizontalAlign="Right" />
                                                        <RowStyle BackColor="#CCFFCC" 
                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" 
                            Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                &nbsp;
                &nbsp;
                <asp:SqlDataSource ID="dsConsultaNotificacion" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                    SelectCommand="ConsultaNotifiacionPersonalizada" 
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                            PropertyName="Text" Type="Int16" />
                        <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                            Type="Int16" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAcuse" runat="server" 
                    style="font-weight: 700; color: #FF3300; font-size: medium;" 
                    Visible="False">ACUSE DE RECIBIDO</asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSelecciona" runat="server" Font-Bold="True" Font-Size="Small" 
                    ForeColor="Black" Text="SELECCIONA DOCUMENTO FIRMADO DE RECIBIDO" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Visible="False" />
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="cmdGuardar" runat="server" Font-Bold="True" 
                    onclick="cmdGuardar_Click" Text="Gurardar" Visible="False" />
                <br />
                <asp:Label ID="lblError" runat="server" 
                    style="font-weight: 700; color: #FF3300; font-size: medium;"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>

