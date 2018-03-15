<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="NucJudOrdenes.aspx.cs" Inherits="AtencionTemprana.NucJudOrdenes" %>
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
        width: 377px;
        height: 19px;
    }
    .style8
    {
        height: 19px;
    }
    .style9
    {
        text-align: left;
    }
    .style10
    {
        width: 264px;
        text-align: left;
        height: 19px;
    }
    .style11
    {
    }
        .style12
    {
        width: 264px;
        text-align: left;
        height: 78px;
    }
    .style13
    {
        height: 78px;
    }
        .style14
    {
        text-align: center;
        color: #66FF66;
        font-family: Arial, Helvetica, sans-serif;
        font-size: large;
        background-color: #FFFFFF;
    }
    .style15
    {
        color: #669900;
        background-color: #FFFFFF;
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
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="CmdOficioOrden"></asp:PostBackTrigger>
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
                <td class="style14" colspan="3">
                    <strong><span class="style15">Datos de la Orden</span></strong></td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Número de Oficio de la Solicitud de la Orden"></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Fecha y Hora de Obsequio"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:TextBox ID="TxtNumeroOficio" runat="server" Height="22px" MaxLength="20" 
                        Width="155px" TabIndex="1"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:TextBox ID="TxtFechaOrden" runat="server" MaxLength="16" TabIndex="2" 
                        TextMode="DateTime" Width="190px"></asp:TextBox>
                    <asp:CalendarExtender ID="TxtFechaOrden_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy hh:mm" TargetControlID="TxtFechaOrden">
                    </asp:CalendarExtender>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Número de Carpeta Administrativa"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Juzgado que Obsequió la Orden"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Juez (Nombre, Apellido Paterno, Apellido Materno)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:TextBox ID="TxtNumCarpetaAdministrativa" runat="server" Height="22px" 
                        MaxLength="20" Width="155px" TabIndex="3"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:DropDownList ID="CboJuzgado" runat="server" Height="22px" Width="350px" 
                        TabIndex="4">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="TxtJuezNombre" runat="server" Height="22px" MaxLength="100" 
                        Width="140px" TabIndex="5"></asp:TextBox>
                    <asp:TextBox ID="TxtJuezPaterno" runat="server" Height="22px" MaxLength="100" 
                        Width="140px" TabIndex="6"></asp:TextBox>
                    <asp:TextBox ID="TxtJuezMaterno" runat="server" Height="22px" MaxLength="100" 
                        Width="140px" TabIndex="7"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="Tipo de Orden"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PDF de la Orden Obsequiada"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:RadioButtonList ID="OptTipoOrden" runat="server" Font-Bold="False" 
                        Font-Size="Small" ForeColor="Black" TabIndex="8">
                        <asp:ListItem Value="1">APREHENSION</asp:ListItem>
                        <asp:ListItem Value="2">COMPARECENCIA</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style13" colspan="2">
                    <asp:FileUpload ID="FileUploadOrden" runat="server" Height="28px" 
                        Width="799px" TabIndex="9" />
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style11">
                    <asp:Button ID="CmdOficioOrden" runat="server" CssClass="button" Height="26px" 
                        OnClick="CmdOficioOrden_Click" Text="Registrar Oficio de la Orden" 
                        Width="212px" Font-Bold="True" TabIndex="10" />
                </td>
                <td style="text-align: right">
                    <asp:Button ID="CmdRegresar" runat="server" CssClass="button" Height="26px" 
                        OnClick="CmdRegresar_Click" Text="&lt;&lt; Regresar" Width="212px" 
                        TabIndex="12" />
                </td>
            </tr>
            <tr>
                <td class="style9" colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red" style="text-align: center"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server" Height="198px">
            <asp:Button ID="CmdPersona" runat="server" CssClass="button" Height="26px" 
                OnClick="CmdPersona_Click" Text="Agregar Imputado" Width="164px" 
                BackColor="#99CCFF" Font-Bold="True" TabIndex="11" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                GridLines="None" ShowHeaderWhenEmpty="True" Width="1100px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="EDITAR">
                        <ItemTemplate>
                            <a href='NucJudOrdenesPersona.aspx?IdOrden=<%#Eval("ID_ORDEN")%>&amp;&amp;op=Modificar&amp;IdPersona=<%#Eval("ID_PERSONA")%>&amp;'>
                            <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" Width="18px" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID_ORDEN" HeaderText="ID_ORDEN" 
                        SortExpression="ID_ORDEN" Visible="False" />
                    <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" 
                        SortExpression="ID_PERSONA" Visible="False" />
                    <asp:BoundField DataField="IMPUTADO" HeaderText="IMPUTADO" 
                        SortExpression="IMPUTADO" ReadOnly="True" >
                    <ItemStyle Width="380px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ESTADO_ORDEN" HeaderText="ESTADO_ORDEN" 
                        SortExpression="ESTADO_ORDEN" />
                    <asp:BoundField DataField="FECHA_EJECUCION" HeaderText="FECHA_EJECUCION" 
                        SortExpression="FECHA_EJECUCION" />
                    <asp:BoundField DataField="FECHA_CANCELACION" HeaderText="FECHA_CANCELACION" 
                        SortExpression="FECHA_CANCELACION" />
                    <asp:BoundField DataField="FECHA_AMPARO" HeaderText="FECHA_AMPARO" 
                        SortExpression="FECHA_AMPARO" />
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
                SelectCommand="ConsultaNucJudOrdenPersona" 
                SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="IdOrdenOficio" 
                        SessionField="IdOrdenOficio" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:Panel>
        <br />
    
  </ContentTemplate>
                <Triggers>
                  <asp:PostBackTrigger ControlID="CmdOficioOrden" />
              </Triggers>
    </asp:UpdatePanel>
</div>

</asp:Content>
