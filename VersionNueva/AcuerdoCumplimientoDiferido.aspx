<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcuerdoCumplimientoDiferido.aspx.cs" Inherits="AtencionTemprana.AcuerdoCumplimientoDiferido" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table>    
        
    <h2> 
        <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>

        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="ID_NUM_CUM_DIFERIDO" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblInstitucion13" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="SOLICITANTE"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblInstitucion14" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="INVITADO"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlSolicitante" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlInvitado" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
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
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="cmdGu" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdGu_Click" TabIndex="6" Text="GUARDAR" Width="156px" />
                    &nbsp;<asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdReg_Click" TabIndex="7" Text="REGRESAR" Width="156px" />
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
                    &nbsp;&nbsp;
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="FECHAS">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="AGREGAR"></asp:Label>
                                    <asp:Button ID="cmdAgregarFecha" runat="server" onclick="cmdAgregarFecha_Click" 
                                        Text="+" Width="29px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAlias" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="4" DataSourceID="dsFechas" ForeColor="Black" GridLines="Vertical" 
                                        Width="470px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                        <asp:TemplateField HeaderText="EDITAR">
                                                <ItemTemplate>
                                                    <a href='AcuerdoDiferidoFecha.aspx?ID_NUM_CUM_DIFERIDO=<%#Eval("ID_NUM_CUM_DIFERIDO")%>&amp;&amp;op=Modificar&amp;ID_ACUERDO_DIFERIDO=<%#Eval("ID_ACUERDO_DIFERIDO")%>&amp;'>
                                                    <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png"  Width="18px" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="ID_ACUERDO_DIFERIDO" 
                                                HeaderText="ID_ACUERDO_DIFERIDO" SortExpression="ID_ACUERDO_DIFERIDO" 
                                                Visible="False" />
                                            <asp:BoundField DataField="ID_NUM_CUM_DIFERIDO" 
                                                HeaderText="ID_NUM_CUM_DIFERIDO" SortExpression="ID_NUM_CUM_DIFERIDO" 
                                                Visible="False" />
                                            <asp:BoundField DataField="FECHA_CUMPLIMIENTO" HeaderText="FECHA CUMPLIMIENTO" 
                                                ReadOnly="True" SortExpression="FECHA_CUMPLIMIENTO" />
                                            <asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE" 
                                                SortExpression="IMPORTE" />
                                            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" ReadOnly="True" 
                                                SortExpression="ESTADO" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                                            HorizontalAlign="Left" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#CCFFCC" HorizontalAlign="Left" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="dsFechas" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                                        SelectCommand="ConsultaAcuerdoDiferidoFecha" 
                                        SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_NUM_CUM_DIFERIDO" 
                                                Name="ID_NUM_CUM_DIFERIDO" PropertyName="Text" Type="Int32" />
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
                    </asp:Panel>
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
                <td colspan="3">
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
            <tr>
                <td>
                    &nbsp; </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

    </ContentTemplate>
    </asp:UpdatePanel>
    
    
</div>

</asp:Content>

