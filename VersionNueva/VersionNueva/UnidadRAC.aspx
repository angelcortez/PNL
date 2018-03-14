<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnidadRAC.aspx.cs" Inherits="AtencionTemprana.UnidadRAC" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
           <script type="text/javascript" language="JavaScript">
               //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 13; /*BLOQUEAR ENTER*/ }
               document.onkeydown = function (evt1) { return (evt1 ? evt1.which : event.keyCode) != 13; } /*BLOQUEAR BACKSPACE*/
               //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 32; } /*BLOQUEAR BARRA ESPACIDORA*/
   </script>
   
        
<div id="main-wrapper">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

     <Triggers>
    <asp:PostBackTrigger ControlID="gvRAC" />
    </Triggers>

     <Triggers>
    <asp:PostBackTrigger ControlID="GridPersona" />
    </Triggers>

    <ContentTemplate>
      <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
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
        <div align="center">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                        AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <img src="img/loading.gif" align="top" width="100" />
                            <br />
                            <asp:Label ID="Label9" runat="server" Text="BUSCANDO..." Font-Bold="True" 
                                Font-Size="Small" ForeColor="Black"></asp:Label>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
</div>

        <table style="width: 100%;">
            <tr>
                <td align="left" colspan="3">
                    <asp:Button ID="cmdNuc" runat="server" 
                        Text="GENERAR RAC" Font-Bold="True" class="button" 
                        onclick="cmdNuc_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" 
                         Width="200px" onselectedindexchanged="ddlBuscar_SelectedIndexChanged">
                        <asp:ListItem Value="0">POR:</asp:ListItem>
                        <asp:ListItem Value="1">RAC</asp:ListItem>
                        <asp:ListItem Value="2">FECHA RAC</asp:ListItem>
<%--                        <asp:ListItem Value="3">DENUNCIANTE</asp:ListItem>
                        <asp:ListItem Value="4">IMPUTADO</asp:ListItem>--%>
                        <asp:ListItem Value="5">PERSONA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="style2" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblRac" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="RAC" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtRAC" runat="server" MaxLength="8" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:Label ID="lblFechaInicio" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                    </asp:CalendarExtender>
                    &nbsp;
                    <asp:Label ID="lblFechaFin" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFin" runat="server" MaxLength="10" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFin">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Visible="False"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblPaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPaterno" runat="server" Visible="False"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblMaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMaterno" runat="server" Visible="False"></asp:TextBox>
                   
                    <asp:Label ID="lblNombreIm" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNombreIm" runat="server" Visible="False"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblPaternoIm" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPaternoIm" runat="server" Visible="False"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblMaternoIm" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMaternoIm" runat="server" Visible="False"></asp:TextBox>
                    &nbsp;<asp:Button ID="cmdAc" runat="server" onclick="cmdAc_Click" Text="ACEPTAR" 
                        Visible="False" Width="140px" CssClass ="button" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    &nbsp;
                    <asp:GridView ID="GridPersona" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" Width="1050px" 
                        AutoGenerateColumns="False" Visible=false
                        AllowPaging="True" AllowSorting="True" 
                        onrowdatabound="GridPersona_RowDataBound" DataKeyNames="ID_CARPETA" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                           <asp:TemplateField HeaderText=" ">
                                                    <ItemTemplate>
                                                    <a href='RAC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_RAC=<%#Eval("ID_ESTADO_RAC")%>'>
                                                    
                                                    <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/view-tree.png" />
                                                    </a>
                                                    
                                                                    </ItemTemplate>
                                                                     
                                                                    </asp:TemplateField>

                           <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="RAC" HeaderText="RAC" ReadOnly="True" 
                                SortExpression="RAC" />
                            <asp:BoundField DataField="FECHA_RAC" HeaderText="FECHA RAC" 
                                SortExpression="FECHA_RAC" ReadOnly="True" />
                            <asp:BoundField DataField="ESTADO_CARPETA" HeaderText="ESTADO CARPETA" 
                                SortExpression="ESTADO_CARPETA" />
                            <asp:BoundField DataField="ID_ESTADO_RAC" HeaderText="ID_ESTADO_RAC" 
                                SortExpression="ID_ESTADO_RAC" Visible="False" />
                            <asp:BoundField DataField="FECHA_ESTADO_RAC" HeaderText="FECHA ESTADO RAC" 
                                SortExpression="FECHA_ESTADO_RAC" ReadOnly="True" />
                            <asp:BoundField DataField="CARPETA_INCIO" HeaderText="CARPETA INCIO" 
                                SortExpression="CARPETA_INCIO" />
                            <asp:BoundField DataField="ID_MUNICIPIO" HeaderText="ID_MUNICIPIO" ReadOnly="True" 
                                SortExpression="ID_MUNICIPIO" Visible="False" />
                            <asp:BoundField DataField="ID_UNDD" HeaderText="ID_UNDD" ReadOnly="True" 
                                SortExpression="ID_UNDD" Visible="False" />
                                <asp:BoundField DataField="PERSONA" HeaderText="NOMBRE" 
                                ReadOnly="True" SortExpression="PERSONA" />
                          <asp:BoundField DataField="ACTR_TPO" HeaderText="TIPO PERSONA" 
                                ReadOnly="True" SortExpression="ACTR_TPO" />
<%--                            <asp:BoundField DataField="DENUNCIANTE" HeaderText="DENUNCIANTE" 
                                ReadOnly="True" SortExpression="DENUNCIANTE" />
                                <asp:BoundField DataField="IMPUTADO" HeaderText="IMPUTADO" ReadOnly="True" 
                                SortExpression="IMPUTADO" />
                           <asp:BoundField DataField="OFENDIDO" HeaderText="OFENDIDO" ReadOnly="True" 
                                SortExpression="OFENDIDO" />--%>
                            <asp:BoundField DataField="CANALIZADA" HeaderText="CANALIZADA" ReadOnly="True" 
                                SortExpression="CANALIZADA" />
                            <asp:BoundField DataField="REMITIDA" HeaderText="REMITIDA" ReadOnly="True" 
                                SortExpression="REMITIDA" />
                            <asp:BoundField DataField="INCOMPTENCIA" HeaderText="INCOMPTENCIA" 
                                ReadOnly="True" SortExpression="INCOMPTENCIA" />

                            
                            
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#507CD1" 
                            Font-Bold="True" ForeColor="White" 
                                                        HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#2461BF" 
                            ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#EFF3FB" 
                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" 
                            Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>

                <br />
                    
                    <asp:GridView ID="gvRAC" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" Width="1050px" 
                        AutoGenerateColumns="False" DataSourceID="dsConsultaRAC" 
                        AllowPaging="True" AllowSorting="True" 
                        onrowdatabound="gvRAC_RowDataBound" DataKeyNames="ID_CARPETA" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                           <asp:TemplateField HeaderText=" ">
                                                    <ItemTemplate>
                                                    <a href='RAC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_RAC=<%#Eval("ID_ESTADO_RAC")%>'>
                                                    
                                                    <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/view-tree.png" /></a>
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField>

                           <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="RAC" HeaderText="RAC" ReadOnly="True" 
                                SortExpression="RAC" />
                            <asp:BoundField DataField="FECHA_RAC" HeaderText="FECHA RAC" 
                                SortExpression="FECHA_RAC" ReadOnly="True" />
                            <asp:BoundField DataField="ESTADO_CARPETA" HeaderText="ESTADO CARPETA" 
                                SortExpression="ESTADO_CARPETA" />
                            <asp:BoundField DataField="ID_ESTADO_RAC" HeaderText="ID_ESTADO_RAC" 
                                SortExpression="ID_ESTADO_RAC" Visible="False" />
                            <asp:BoundField DataField="FECHA_ESTADO_RAC" HeaderText="FECHA ESTADO RAC" 
                                SortExpression="FECHA_ESTADO_RAC" ReadOnly="True" />
                            <asp:BoundField DataField="CARPETA_INCIO" HeaderText="CARPETA INCIO" 
                                SortExpression="CARPETA_INCIO" />
                            <asp:BoundField DataField="ID_MUNICIPIO" HeaderText="ID_MUNICIPIO" ReadOnly="True" 
                                SortExpression="ID_MUNICIPIO" Visible="False" />
                            <asp:BoundField DataField="ID_UNDD" HeaderText="ID_UNDD" ReadOnly="True" 
                                SortExpression="ID_UNDD" Visible="False" />
                            <asp:BoundField DataField="DENUNCIANTE" HeaderText="DENUNCIANTE" 
                                ReadOnly="True" SortExpression="DENUNCIANTE" />
                                <asp:BoundField DataField="IMPUTADO" HeaderText="IMPUTADO" ReadOnly="True" 
                                SortExpression="IMPUTADO" />
<%--                            <asp:BoundField DataField="CANALIZADA" HeaderText="CANALIZADA" ReadOnly="True" 
                                SortExpression="CANALIZADA" />--%>
                            <asp:BoundField DataField="REMITIDA" HeaderText="DERIVADA" ReadOnly="True" 
                                SortExpression="REMITIDA" />
                           <%-- <asp:BoundField DataField="INCOMPTENCIA" HeaderText="INCOMPTENCIA" 
                                ReadOnly="True" SortExpression="INCOMPTENCIA" />--%>

                            
                            
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#507CD1" 
                            Font-Bold="True" ForeColor="White" 
                                                        HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#2461BF" 
                            ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#EFF3FB" 
                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" 
                            Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                      <asp:SqlDataSource ID="dsBuscarRAc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarRAC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtRAC" Name="RAC" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsConsultaRAC0" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaRAC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsFechaInicio" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarRACFecha" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaInicio" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFin" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsDenunciante" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarRACDenunciante" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtNombre" DefaultValue=" " Name="Nombre" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtPaterno" DefaultValue=" " Name="Paterno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtMaterno" DefaultValue=" " Name="Materno" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsImputado" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarRACImputado" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" DefaultValue="" Name="IdUnidad" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="txtNombreIm" DefaultValue=" " Name="Nombre" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtPaternoIm" DefaultValue=" " Name="Paterno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtMaternoIm" DefaultValue=" " Name="Materno" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsConsultaRAC" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaRAC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                                                            <asp:SqlDataSource ID="dsPersona" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="spSBuscarRACPersona" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtNombreIm" Name="Nombre" PropertyName="Text" 
                                Type="String" DefaultValue=" " />
                            <asp:ControlParameter ControlID="txtPaternoIm" Name="Paterno" PropertyName="Text" 
                                Type="String" DefaultValue=" " />
                            <asp:ControlParameter ControlID="txtMaternoIm" Name="Materno" PropertyName="Text" 
                                Type="String" DefaultValue=" " />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </table>
               <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ESTADOS DE CARPETA RAC"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" BackColor="Red" />
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="TRAMITE"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" BackColor="#802A2A" />
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="CANALIZADA"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" BackColor="Black" />
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="M. A. S. C."></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" BackColor="Blue" />
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="DERIVADA"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" BackColor="#00CC00" />
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="RESUELTA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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

