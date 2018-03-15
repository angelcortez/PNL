<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NucJudOrdenDelito.aspx.cs" Inherits="AtencionTemprana.NucJudOrdenDelito" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
        #Radio1
    {
        width: 131px;
    }
        .style6
    {
        width: 230px;
        text-align: left;
        height: 19px;
    }
        .style7
    {
        text-align: center;
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
   <%-- <asp:PostBackTrigger ControlID="cmdElaborarInforme" />
    <asp:PostBackTrigger ControlID="cmdGuardar" />--%>
    </Triggers>
    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;<asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
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
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                </td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblArbol" runat="server" Visible="False">4</asp:Label>
            </td>
            <td>
                  </td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="PUESTO" runat="server" Font-Bold="True" 
                    ForeColor="#666666" style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        </table>
        </tr>
        </table>
        <p>
            &nbsp;</p>
      <table style="width: 100%;" runat="server" id="tbl_informe">
      <tr>
            <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
            <td>
                    &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        </table>

          <br />
        <table style="width:100%;">
            <tr>
                <td class="style7" colspan="3">
                    <strong><span class="style15" style="font-size: medium">Delitos de la Orden</span></strong></td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>

                <td colspan="3">
                    <asp:GridView ID="GridDelitos" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" 
                        GridLines="None" ShowHeaderWhenEmpty="True" Width="1075px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Selecciona">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" DataField="Selecciona" 
                                        Checked='<%# Eval("Selecciona") %>'/>
                                </ItemTemplate>
                                <ControlStyle Width="75px" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID_DELITO" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblIdDelito" runat="server" DataField="ID_DELITO" 
                                        Text='<%# Eval("ID_DELITO") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DELITO" HeaderText="DELITO" SortExpression="DELITO">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="800px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ID_MODALIDAD" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblIdModalidad" runat="server" DataField="ID_MODALIDAD" 
                                        Text='<%# Eval("ID_MODALIDAD") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MODALIDAD" HeaderText="MODALIDAD" 
                                SortExpression="MODALIDAD">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="200px" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" 
                        SelectCommand="ConsultaDelitosInicioCarpeta" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="IdCarpeta" 
                                SessionField="ID_CARPETA" Type="Int32" />
                            <asp:SessionParameter DefaultValue="0" Name="IdOrden" SessionField="ID_ORDEN" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </td>

            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red" style="text-align: center"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="CmdAgregarDelito" runat="server" CssClass="button" 
                        OnClick="CmdAgregarDelito_Click" Text="Registrar Delito(s)" 
                        Width="194px" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

        <br />
    
  </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>
