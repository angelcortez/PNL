<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detenidos.aspx.cs" Inherits="AtencionTemprana.Detenidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="#006600" Text="DETENIDOS EN BARANDILLAS DE SEGURIDAD PUBLICA"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:GridView ID="gvDetenidos" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="900px" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Detencion_Id" 
                        DataSourceID="DetenidosActuales" onrowdatabound="gvDetenidos_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                         <asp:TemplateField HeaderText=" ">
                                                    <ItemTemplate>
                                                    <%--<a href='Pgr.aspx?Folio=<%#Eval("Folio")%>&amp;&amp;op=Modificar&amp;IdPgr=<%#Eval("IdPgr")%>&amp;'>--%>
                                                    <%--<a href='RAC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_RAC=<%#Eval("ID_ESTADO_RAC")%>'>
                                                    --%>
                                                    <asp:Image ID="Image1" runat="server" Height="18px" 
                                                                    ImageUrl="img/view-tree.png" /></a>
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField>

                            <asp:BoundField DataField="Persona_Id" HeaderText="Persona_Id" 
                                SortExpression="Persona_Id" Visible="False" />
                            <asp:BoundField DataField="Paterno" HeaderText="Paterno" 
                                SortExpression="Paterno" />
                            <asp:BoundField DataField="Materno" HeaderText="Materno" 
                                SortExpression="Materno" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                                SortExpression="Nombre" />
                            <asp:BoundField DataField="cNombreCompleto" HeaderText="cNombreCompleto" 
                                ReadOnly="True" SortExpression="cNombreCompleto" Visible="False" />
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" 
                                SortExpression="FechaNacimiento" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" />
                            <asp:BoundField DataField="CURP" HeaderText="CURP" SortExpression="CURP" />
                            <asp:BoundField DataField="RFC" HeaderText="RFC" SortExpression="RFC" />
                            <asp:BoundField DataField="Detencion_Id" HeaderText="Detencion_Id" 
                                InsertVisible="False" ReadOnly="True" SortExpression="Detencion_Id" 
                                Visible="False" />
                            <asp:BoundField DataField="Expediente_Id" HeaderText="Expediente_Id" 
                                SortExpression="Expediente_Id" Visible="False" />
                            <asp:BoundField DataField="FechaDetencion" HeaderText="FechaDetencion" 
                                SortExpression="FechaDetencion" />
                            <asp:BoundField DataField="MotivosDetencion" HeaderText="MotivosDetencion" 
                                ReadOnly="True" SortExpression="MotivosDetencion" Visible="False" />
                            <asp:BoundField DataField="Id_Revision_OrdenAprehension" 
                                HeaderText="Id_Revision_OrdenAprehension" 
                                SortExpression="Id_Revision_OrdenAprehension" />
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
                    &nbsp;<asp:SqlDataSource ID="DetenidosActuales" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PRUEBAConnectionString %>" 
                        SelectCommand="SP_DatosGenerales_DetenidosActuales" 
                        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
&nbsp;</td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>

