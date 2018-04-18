<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mediacion.aspx.cs" Inherits="AtencionTemprana.Mediacion" %>

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
                  <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="Black" 
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
    </table>  
<h2>&nbsp;</h2>

      <table style="width: 100%;">
            <tr>
                <td colspan="3" align="left">
                    <asp:Button ID="cmdNum" runat="server" onclick="cmdNum_Click" 
                        Text="GENERAR NUM" Visible="False" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblIdUnidad" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblIdCarpeta" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    <asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBuscar_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">POR</asp:ListItem>
                        <asp:ListItem Value="3">NUM</asp:ListItem>
                        <asp:ListItem Value="4">FECHA INICIO NUM</asp:ListItem>
                        <asp:ListItem Value="1">RAC</asp:ListItem>
                        <asp:ListItem Value="2">FECHA INICIO RAC</asp:ListItem>
                        <asp:ListItem Value="6">NUC</asp:ListItem>
                        <asp:ListItem Value="5">SOLICITANTE</asp:ListItem>
                        <asp:ListItem Value="7">REQUERIDO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblRac" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="RAC" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtRac" runat="server" MaxLength="10" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:Label ID="lblFechaInicioRac" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicioRac" runat="server" MaxLength="10" 
                        Visible="False" Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicioRac_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicioRac">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblFechaFinRac" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFinRac" runat="server" MaxLength="10" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaFinRac_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFinRac">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblNUM" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NUM" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNUM" runat="server" MaxLength="10" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:Label ID="lblFechaInicioNum" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicioNum" runat="server" MaxLength="10" 
                        Visible="False" Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicioNum_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicioNum">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblFechaFinNum" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFinNum" runat="server" MaxLength="10" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaFinNum_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFinNum">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Visible="False" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblPaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPaterno" runat="server" Visible="False" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblMaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMaterno" runat="server" Visible="False" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblNuc" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NUC" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtNuc" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblNombreR" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNombreR" runat="server" Visible="False" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblPaternoR" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPaternoR" runat="server" Visible="False" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblMaternoR" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMaternoR" runat="server" Visible="False" Width="150px"></asp:TextBox>
                    &nbsp;&nbsp;<asp:Button ID="cmdAc" runat="server" onclick="cmdAc_Click" Text="ACEPTAR" 
                        Visible="False" Width="156px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvMediacion" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="1100px" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False"
                        DataSourceID="dsConsultaSoliciudMediacion" 
                        
                        onrowdatabound="gvMediacion_RowDataBound" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        
                               <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                            <%--<a href='Pgr.aspx?Folio=<%#Eval("Folio")%>&amp;&amp;op=Modificar&amp;IdPgr=<%#Eval("IdPgr")%>&amp;'>--%>
                            <a href='NUM.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUM=<%#Eval("ID_ESTADO_NUM")%>'>
                                                    
                      <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/view-tree.png" />
                      </a>
                                            </ItemTemplate>
                        </asp:TemplateField>
                        
                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="NUM" HeaderText="NUM" 
                                SortExpression="NUM" ReadOnly="True" />
                            <asp:BoundField DataField="FECHA_NUM" HeaderText="FECHA NUM" 
                                SortExpression="FECHA_NUM" ReadOnly="True" />
                            <asp:BoundField DataField="ESTADO_CARPETA" HeaderText="ESTADO_CARPETA" 
                                SortExpression="ESTADO_CARPETA" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="CARPETA_INCIO" HeaderText="CARPETA_INCIO" 
                                SortExpression="CARPETA_INCIO" Visible="False" />
                            <asp:BoundField DataField="NUC" HeaderText="NUC" 
                                SortExpression="NUC" ReadOnly="True" />
                            <asp:BoundField DataField="UNIDAD" HeaderText="UNIDAD" 
                                SortExpression="UNIDAD" ReadOnly="True" />
                            <asp:BoundField DataField="RAC" HeaderText="RAC" 
                                SortExpression="RAC" ReadOnly="True" />
                            <asp:BoundField DataField="ID_MUNICIPIO" HeaderText="ID_MUNICIPIO" 
                                SortExpression="ID_MUNICIPIO" Visible="False" />
                            <asp:BoundField DataField="ID_UNDD" HeaderText="ID_UNDD" 
                                SortExpression="ID_UNDD" Visible="False" />
                                 <asp:BoundField DataField="ID_ESTADO_NUM" HeaderText="ID_ESTADO_NUM" 
                                ReadOnly="True" SortExpression="ID_ESTADO_NUM" Visible="False" />
                              
                             <asp:BoundField DataField="PERSONA" HeaderText="PERSONA" 
                                 ReadOnly="True" SortExpression="PERSONA" />
                              
                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" ReadOnly="True" 
                                SortExpression="TIPO" />
                              
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
                    <asp:SqlDataSource ID="dsConsultaSoliciudMediacion" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="consultaSolicitudesMediacion" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" DefaultValue="" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarRAC" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarSolicitudesMediacion" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtRac" Name="RAC" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarFechaInicioRAC" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarSolicitudesMediacionFechaInicioRac" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                            <asp:ControlParameter ControlID="txtFechaInicioRac" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaFinRac" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarNUM" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarSolicitudesMediacionNUM" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNUM" Name="NUM" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFechaInicioNUM" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarSolicitudesMediacionFechaInicioNum" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                            <asp:ControlParameter ControlID="txtFechaInicioNum" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaFinNum" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarDenunciante" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarSolicitudesMediacionDenunciante" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNombre" DefaultValue=" " Name="Nombre" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtPaterno" DefaultValue=" " Name="Paterno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtMaterno" DefaultValue=" " Name="Materno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarNuc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarSolicitudesMediacionNUC" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNuc" Name="NUC" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarRequerido" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarSolicitudesMediacionRequerido" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNombreR" DefaultValue=" " Name="Nombre" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtPaternoR" DefaultValue=" " Name="Paterno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtMaternoR" DefaultValue=" " Name="Materno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" DefaultValue="" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                 <asp:ModalPopupExtender ID="Panel1_ModalPopupExtender" runat="server"  
                        DynamicServicePath="" Enabled="True" TargetControlID="lblIdCarpeta" PopupControlID="Panel1" CancelControlID="btnCancelar"
                         PopupDragHandleControlID="PoppupHeader" Drag="true" BackgroundCssClass="ModalPopupBG" >
                    </asp:ModalPopupExtender>
                   
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
        </table>

    </ContentTemplate>
    </asp:UpdatePanel>
    
   
</div>

</asp:Content>

