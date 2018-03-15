<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PNLLocalizados.aspx.cs" Inherits="AtencionTemprana.PNLLocalizados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
                <asp:PostBackTrigger ControlID="cmdExportarExcel" />
            </Triggers>
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" class="color-fuente"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                            <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Button ID="BtnBuscar" runat="server" Text="GENERAR" OnClick="BtnBuscar_Click" class="button" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente">Total de personas ofendidas capturadas en el sistema:</asp:Label>
                            &nbsp;<asp:Label ID="LblResultadoOfendidos" runat="server" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido0" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente">Personas localizadas vivas:</asp:Label>
                            <asp:Label ID="LblResultadoVivos" runat="server" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido1" runat="server" Font-Bold="True" Font-Size="Small" class="color-fuente">Personas localizadas muertas:</asp:Label>
                            <asp:Label ID="LblResultadoMuertos" runat="server" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblTotalSinCapturar" runat="server" Font-Bold="True" Font-Size="Small"
                                class="color-fuente">Personas sin registro de localización:</asp:Label>
                            <asp:Label ID="LblTotalSinRegistro" runat="server" Font-Bold="True" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false"
                                class="color-fuente">Para una búsqueda específica ingrese cualquiera de los 3 datos del ofendido</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="lblNombre3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="NOMBRE" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtNombre3" runat="server" Style="text-transform: uppercase" Visible="False"
                                Width="150px"></asp:TextBox>
                            <asp:Label ID="lblPaterno3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="PATERNO" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtPaterno3" runat="server" Style="text-transform: uppercase" Visible="False"
                                Width="150px"></asp:TextBox>
                            <asp:Label ID="lblMaterno3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="MATERNO" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtMaterno3" runat="server" Style="text-transform: uppercase" Visible="False"
                                Width="150px"></asp:TextBox>
                            <asp:Button ID="BtnBuscar1" runat="server" OnClick="BtnBuscar1_Click" Text="OK" Visible="false" class="button"
 />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido2" runat="server" Font-Bold="True" Font-Size="Medium" Visible="false"
                                class="color-fuente">PERSONAS CAPTURADAS EN EL SISTEMA</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;&nbsp;
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Visible="False" CellPadding="4" DataSourceID="dsConsultaPersonasTotal" ForeColor="#333333"
                                GridLines="None" Style="text-transform: uppercase" Width="930px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <a href='NUC_PNL.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUC=<%#Eval("ID_ESTADO_NUC")%>'>
                                                <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/view-tree.png" /></a>
                                            <%--<a href='NUC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUC=<%#Eval("ID_ESTADO_NUC")%>'>
                                 <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" /></a>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" ReadOnly="True" SortExpression="NOMBRE" />
                                    <asp:BoundField DataField="NUC" HeaderText="NUC" SortExpression="NUC" />
                                    <asp:BoundField DataField="UNDD_DSCRPCION" HeaderText="UNIDAD" SortExpression="UNDD_DSCRPCION" />
                                    <asp:BoundField DataField="ESTATUS_PERSONA" HeaderText="REGISTRO LOCALIZACIÓN" ReadOnly="True"
                                        SortExpression="ESTATUS_PERSONA" />
                                    <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" SortExpression="ID_CARPETA"
                                        Visible="False" />
                                    <asp:BoundField DataField="ID_ESTADO_NUC" HeaderText="ID_ESTADO_NUC" SortExpression="ID_ESTADO_NUC"
                                        Visible="False" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;<asp:Button ID="cmdExportarExcel" runat="server" AutoPostBack="FALSE" 
                                OnClick="cmdExportarExcel_Click" Text="Exportar a Excel" Visible="false" class="button" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;<asp:Label ID="LblOfendido3" runat="server" Font-Bold="True" Font-Size="Medium"
                                class="color-fuente" Visible="false">CARPETAS GENERADAS</asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                            <asp:Button ID="BuscarSinDelito" Visible="false" runat="server" Text="BUSCAR" OnClick="BuscarSinDelito_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido4" runat="server" Font-Bold="True" Font-Size="Small" Visible="false"
                                class="color-fuente">Total de carpetas generadas:</asp:Label>
                            <asp:Label ID="LblTotalCarpetas" runat="server" Font-Bold="True" Visible="false"
                                Font-Size="Small" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido5" runat="server" Font-Bold="True" Font-Size="Small" Visible="false"
                                class="color-fuente">Persona no localizada:</asp:Label>
                            <asp:Label ID="LblPNL" runat="server" Font-Bold="True" Visible="false" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido6" runat="server" Font-Bold="True" Font-Size="Small" Visible="false"
                                class="color-fuente">Privación ilegal de la libertad y otras garantías:</asp:Label>
                            <asp:Label ID="LblPIL" runat="server" Font-Bold="True" Visible="false" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido7" runat="server" Font-Bold="True" Font-Size="Small" Visible="false"
                                class="color-fuente">Sustracción de menores:</asp:Label>
                            <asp:Label ID="LblSustraccion" runat="server" Font-Bold="True" Visible="false" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Visible="false"
                                class="color-fuente">Otros delitos:</asp:Label>
                            <asp:Label ID="LblOtrosDelitos" runat="server" Font-Bold="True" Visible="false" Font-Size="Small"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div id="container_1">
                                <asp:Panel ID="PanelHomicidios" runat="server" GroupingText="Reporte" Width="900px"
                                    Height="700px" ScrollBars="Both" Visible="false">
                                    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="dsConsultaHomicidios">
                                        <HeaderTemplate>
                                            <table style="width: 100%" border="1" cellpadding="2" cellspacing="0" bordercolor="#6D6D6D">
                                                <tr>
                                                    <!--
                                     <th>
                                        <asp:Label runat="server" ID="Label48" Font-Size="11px" ForeColor="Black" Font-Bold="true" Visible="false"
                                            Text="ID_CARPETA" />
                                    </th>
                                    -->
                                                    <th>
                                                        <asp:Label runat="server" ID="Label13" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="CARPETA PERTENECIENTE A" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label490" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="NOMBRE" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label440" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="NUC" />
                                                    </th>
                                                     <th>
                                                        <asp:Label runat="server" ID="Label16" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="FECHA INICIO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label430" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="UNIDAD" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label21" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="MUNICIPIO DE HECHO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label420" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="ESTATUS PERSONA" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label410" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="FECHA LOCALIZACIÓN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label400" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="LUGAR DE HALLAZGO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label39" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="PAÍS" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label38" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="ESTADO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label45" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="MUNICIPIO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label37" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="LOCALIDAD" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label36" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="CALLE" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label11" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="CAUSA DESAPARICIÓN" />
                                                    </th>
                                                     <th>
                                                        <asp:Label runat="server" ID="Label17" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="DENUNCIANTE" />
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label14" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CARPETA_PERTENECIENTE_A") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label500" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NOMBRE") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label1" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NUC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label15" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_NUC") %>' />
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label2" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("UNIDAD") %>' />
                                                </td>
                                               <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label20" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MunicipioHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label5" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTATUS_PERSONA") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label6" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_LOC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label7" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LUGAR_HALLAZGO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label18" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("PAIS") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label8" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTADO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label9" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MUNICIPIO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label46" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LOCALIDAD") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label10" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CALLE") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label12" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CAUSA_DESAPARICION") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label19" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Denunciante") %>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr>
                                                 <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label14" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CARPETA_PERTENECIENTE_A") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label509" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NOMBRE") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label1" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NUC") %>' />
                                               <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label15" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_NUC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label2" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("UNIDAD") %>' />
                                                </td>
                                               <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label20" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MunicipioHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label5" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTATUS_PERSONA") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label6" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_LOC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label7" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LUGAR_HALLAZGO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label18" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("PAIS") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label8" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTADO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label9" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MUNICIPIO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label46" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LOCALIDAD") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label10" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CALLE") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label12" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CAUSA_DESAPARICION") %>' />
                                                </td>
                                                 <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label19" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Denunciante") %>' />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                            </div>
                            <asp:SqlDataSource ID="dsConsultaHomicidios" runat="server" SelectCommandType="StoredProcedure"
                                SelectCommand="NombresPNL_VMSC_Repeater_Excel" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>">
                            </asp:SqlDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    &nbsp;
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:SqlDataSource ID="dsConsultaPersonasTotal" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>"
                                SelectCommand="NombresPNL_VMSC" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="dsConsultaPersonasUnidadNombreSolamenteDos" runat="server"
                                ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" SelectCommand="NombresPNLLocalizados_Nombre_Solamente_Dos"
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtNombre3" Name="Nombre" PropertyName="Text" Type="String"
                                        DefaultValue=" " />
                                    <asp:ControlParameter ControlID="txtPaterno3" Name="Paterno" PropertyName="Text"
                                        Type="String" DefaultValue=" " />
                                    <asp:ControlParameter ControlID="txtMaterno3" Name="Materno" PropertyName="Text"
                                        Type="String" DefaultValue=" " />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" Text="ESTADOS DE CARPETA NUC"></asp:Label>
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
                            <asp:Button ID="Button1" runat="server" BackColor="Red" />
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" Text="TRAMITE"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button5" runat="server" BackColor="Blue" />
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" Text="JUDICIALIZADA"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button3" runat="server" BackColor="Black" />
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" Text="ARCHIVO TEMPORAL"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" BackColor="#802A2A" />
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" Text="NO EJERCICIO"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button4" runat="server" BackColor="#00CC00" />
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" Text="CRITERIO DE OPORTUNIDAD"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
