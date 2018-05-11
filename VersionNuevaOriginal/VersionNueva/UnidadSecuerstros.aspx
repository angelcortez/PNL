﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnidadSecuerstros.aspx.cs" Inherits="AtencionTemprana.UnidadSecuerstros" %>
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
                <td align="left" colspan="3">
                    <asp:Button ID="cmdNuc" runat="server" onclick="cmdNuc_Click" 
                        Text="GENERAR NUC" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlBuscar" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBuscar_SelectedIndexChanged" Width="200px">
                        <asp:ListItem Value="0">POR:</asp:ListItem>
                        <asp:ListItem Value="1">RAC</asp:ListItem>
                        <asp:ListItem Value="2">FECHA INICIO RAC</asp:ListItem>
                        <asp:ListItem Value="3">NUC</asp:ListItem>
                        <asp:ListItem Value="4">FECHA INICIO NUC</asp:ListItem>
                        <asp:ListItem Value="5">DENUNCIANTE</asp:ListItem>
                        <asp:ListItem Value="6">IMPUTADO</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblRac" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="RAC" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtRac" runat="server" Visible="False"></asp:TextBox>
                    <asp:Label ID="lblFechaInicioRac" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicioRac" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicioRac_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicioRac">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblFechaFinRac" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFinRac" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaFinRac_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFinRac">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblNuc" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NUC" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNuc" runat="server" Visible="False"></asp:TextBox>
                    <asp:Label ID="lblFechaInicioNuc" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaInicioNuc" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaInicioNuc_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicioNuc">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblFechaFinNuc" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Black" Text="FECHA FIN" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtFechaFinNuc" runat="server" Visible="False"></asp:TextBox>
                    <asp:CalendarExtender ID="txtFechaFinNuc_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaFinNuc">
                    </asp:CalendarExtender>
                    <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Visible="False" Width="150px" style="text-transform :uppercase"></asp:TextBox>
                    <asp:Label ID="lblPaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPaterno" runat="server" Visible="False" Width="150px" style="text-transform :uppercase"></asp:TextBox>
                    <asp:Label ID="lblMaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMaterno" runat="server" Visible="False" Width="150px" style="text-transform :uppercase"></asp:TextBox>
                    <asp:Label ID="lblNombreIm" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNombreIm" runat="server" Visible="False"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblPaternoIm" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPaternoIm" runat="server" Visible="False"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblMaternoIm" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMaternoIm" runat="server" Visible="False"></asp:TextBox>
                    <asp:Button ID="cmdAceptar" runat="server" onclick="cmdAceptar_Click" 
                        Text="ACEPTAR" Visible="False" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    &nbsp;<asp:GridView ID="gvNuc" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="1050px" 
                        AutoGenerateColumns="False" DataSourceID="dsConsultaNuc" 
                        AllowPaging="True" onrowdatabound="gvNuc_RowDataBound" 
                        DataKeyNames="ID_CARPETA">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                        
                         <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                             <a href='NUC_SECUESTRO.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUC=<%#Eval("ID_ESTADO_NUC")%>'>
                                 <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/view-tree.png" /></a>
                               <%--<a href='NUC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUC=<%#Eval("ID_ESTADO_NUC")%>'>
                                 <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" /></a>--%>
                            </ItemTemplate>
                          </asp:TemplateField>


                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" Visible="False" />
                            <asp:BoundField DataField="NUC" HeaderText="NUC" ReadOnly="True" 
                                SortExpression="NUC" />
                            <asp:BoundField DataField="FECHA_NUC" HeaderText="INICIO NUC" ReadOnly="True" 
                                SortExpression="FECHA_NUC" />
                            <asp:BoundField DataField="ESTADO_CARPETA" HeaderText="ESTADO NUC" 
                                ReadOnly="True" SortExpression="ESTADO_CARPETA" />
                            <asp:BoundField DataField="RAC" HeaderText="RAC" ReadOnly="True" 
                                SortExpression="RAC" Visible="False" />
                            <asp:BoundField DataField="FECHA_RAC" HeaderText="INICIO RAC" ReadOnly="True" 
                                SortExpression="FECHA_RAC" Visible="False" />
                            <asp:BoundField DataField="CARPETA_INCIO" HeaderText="FORMA DE INCIO" 
                                SortExpression="CARPETA_INCIO" />
                            <asp:BoundField DataField="ID_MUNICIPIO" HeaderText="ID_MUNICIPIO" 
                                ReadOnly="True" SortExpression="ID_MUNICIPIO" Visible="False" />
                            <asp:BoundField DataField="ID_UNDD" HeaderText="ID_UNDD" 
                                SortExpression="ID_UNDD" Visible="False" />
                            <asp:BoundField DataField="ID_ESTADO_NUC" HeaderText="ID_ESTADO_NUC" 
                                ReadOnly="True" SortExpression="ID_ESTADO_NUC" Visible="False" />
                            <asp:BoundField DataField="DENUNCIANTE" HeaderText="DENUNCIANTE" 
                                ReadOnly="True" SortExpression="DENUNCIANTE" />
                        
                        
                            <asp:BoundField DataField="IMPUTADO" HeaderText="IMPUTADO" ReadOnly="True" 
                                SortExpression="IMPUTADO" />
                        
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
                    <asp:SqlDataSource ID="dsConsultaNuc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaNUC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:SqlDataSource ID="dsBuscarRac" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarUnidadRAC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtRac" Name="RAC" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:SqlDataSource ID="dsBuscarFechaInicioRac" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarUnidadFechaInicioRAC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaInicioRac" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFinRac" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarNuc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="BuscarUnidadNUC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNuc" Name="NUC" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarFechaInicioNuc" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarUnidadFechaInicioNUC" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtFechaInicioNuc" Name="FechaInicio" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtFechaFinNuc" Name="FechaFin" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarDenunciante" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarUnidadDenunciante" SelectCommandType="StoredProcedure">
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
                    <asp:SqlDataSource ID="dsBuscarImputado" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarUnidadImputado" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="IdUnidad" Name="IdUnidad" PropertyName="Text" 
                                Type="Int16" />
                            <asp:ControlParameter ControlID="txtNombreIm" DefaultValue=" " Name="Nombre" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtPaternoIm" DefaultValue=" " Name="Paterno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtMaternoIm" DefaultValue=" " Name="Materno" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
                <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ESTADOS DE CARPETA NUC"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
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
                    <asp:Button ID="Button5" runat="server" BackColor="Blue" />
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="JUDICIALIZADA"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" BackColor="Black" />
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="ARCHIVO TEMPORAL"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" BackColor="#802A2A" />
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="NO EJERCICIO"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" BackColor="#00CC00" />
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="CRITERIO DE OPORTUNIDAD"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
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
