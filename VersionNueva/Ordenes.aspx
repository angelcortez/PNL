<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="AtencionTemprana.Ordenes" %>
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
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO"></asp:Label>
                    <asp:TextBox ID="txtPaterno" runat="server"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO"></asp:Label>
                    <asp:TextBox ID="txtMaterno" runat="server"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="cmdBuscar" runat="server" Text="BUSCAR" 
                        onclick="cmdBuscar_Click" />
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
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvOrden" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" DataKeyNames="IdJuzgado,IdTipoOrden" DataSourceID="dsOrden" 
                        ForeColor="Black" GridLines="Vertical" Width="900px" AllowPaging="True" 
                        AllowSorting="True" onrowdatabound="gvOrden_RowDataBound" 
                        EmptyDataText="NO SE ENCONTRO ORDEN">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="IdRadicacion" HeaderText="IdRadicacion" 
                                SortExpression="IdRadicacion" Visible="False" />
                            <asp:BoundField DataField="IdJuzgado" HeaderText="IdJuzgado" ReadOnly="True" 
                                SortExpression="IdJuzgado" Visible="False" />
                            <asp:BoundField DataField="Juzgado" HeaderText="JUZGADO" 
                                SortExpression="Juzgado" />
                            <asp:BoundField DataField="IdMunicipio" HeaderText="IdMunicipio" 
                                SortExpression="IdMunicipio" Visible="False" />
                            <asp:BoundField DataField="MUNICIPIO" HeaderText="MUNICIPIO" 
                                SortExpression="MUNICIPIO" />
                            <asp:BoundField DataField="ApellidoPat" HeaderText="PATERNO" 
                                SortExpression="ApellidoPat" />
                            <asp:BoundField DataField="ApellidoMat" HeaderText="MATERNO" 
                                SortExpression="ApellidoMat" />
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE" 
                                SortExpression="nombre" />
                            <asp:BoundField DataField="IdActor" HeaderText="IdActor" 
                                SortExpression="IdActor" Visible="False" />
                            <asp:BoundField DataField="IdTipoOrden" HeaderText="IdTipoOrden" 
                                ReadOnly="True" SortExpression="IdTipoOrden" Visible="False" />
                            <asp:BoundField DataField="TipoOrden" HeaderText="TIPO DE ORDEN" 
                                SortExpression="TipoOrden" />
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
                    <asp:SqlDataSource ID="dsOrden" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_PROCESOS_2003_ESTADISTICAConnectionString %>" 
                        SelectCommand="consultaOrdenes" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarApllido" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_PROCESOS_2003_ESTADISTICAConnectionString %>" 
                        SelectCommand="buscarOrdenesPersona" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtPaterno" Name="Paterno" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="txtMaterno" Name="Materno" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="txtNombre" Name="Nombre" PropertyName="Text" 
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
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

