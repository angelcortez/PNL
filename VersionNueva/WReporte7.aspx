<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WReporte7.aspx.cs" Inherits="AtencionTemprana.WReporte7" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main-wrapper">
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
            <td class="style2">
                <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
            <td align="right" class="style2">
                </td>
        </tr>
     
      
        <tr>
            <td class="style2">
                <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
            <td align="right" class="style2">
                </td>
        </tr>
    </table>

     <table >
     <tr>
        <td colspan="3">
                            <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Large" class="color-fuente" style="text-align: center" 
                        Text="Listado de Personas" Width="1089px"></asp:Label>
        </td>
     </tr>
     <tr>
         <td>                    
         <td>                    
         <td></td>
     </tr>
     <tr>
         <td>                   
                        </td>
         <td>                    </td>
         <td>                    <asp:Button ID="btnBuscar" runat="server" 
                        Text="BUSCAR" Width="149px" class="button" 
                 onclick="btnBuscar_Click" /></td>
     </tr>
    </table>
    <br />
      <asp:Button ID="btnExcel" runat="server"  Text="Exportar a Excel" Width="149px" 
            class="button" onclick="btnExcel_Click" Visible="False"  />
    <br />
    <div style="width:1000px; height:600px; overflow: scroll;">
                                        <asp:Repeater ID="Repeater1" runat="server" 
            DataSourceID="SqlDataSource1">
                                        <HeaderTemplate>
                                            <table style="width: 100%" border="1" cellpadding="2" cellspacing="0" bordercolor="#6D6D6D">
                                                <tr>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label13" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="NUC" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label490" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="UNIDAD" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label440" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="FECHA DE INICIO DE CARPETA" />
                                                    </th>
                                                     <th>
                                                        <asp:Label runat="server" ID="Label16" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="FECHA DE HECHOS" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label430" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="HORA DE HECHOS" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label21" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="DELITO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label420" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="VIOLENCIA" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label410" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="SUJETOS QUE INTERVIENEN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label400" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="CORPORACIÓN QUE INTERVINO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label39" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="TIPO DE LUGAR" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label38" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="ESTADO DE HECHOS" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label45" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="MUNICIPIO DE HECHOS" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label37" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="LOCALIDAD" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label3" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="COLONIA" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label36" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="CALLE" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label11" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="ENTRE CALLE" />
                                                    </th>
                                                     <th>
                                                        <asp:Label runat="server" ID="Label17" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="Y CALLE" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label4" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="N° EXTERIOR" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label22" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="DETENIDO" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label23" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="DENUNCIANTE" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label24" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="NOMBRE COMPLETO PNL" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label25" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="SEXO PNL" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label26" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="EDAD PNL" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label27" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="ESTATUS PERSONA" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label28" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="CONDICIONES LOCALIZACIÓN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label29" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="FECHA LOCALIZACIÓN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label30" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="PAÍS LOCALIZACIÓN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label31" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="ESTADO LOCALIZACIÓN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label32" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="MUNICIPIO LOCALIZACIÓN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label33" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="LOCALIDAD LOCALIZACIÓN" />
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" ID="Label34" Font-Size="11px" ForeColor="Black" Font-Bold="true"
                                                            Text="CALLES LOCALIZACIÓN" />
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label14" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NUC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label500" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("UNIDAD") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label1" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_NUC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label15" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_HECHOS") %>' />
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label2" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("HORA_HECHOS") %>' />
                                                </td>
                                               <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label20" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Delito") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label5" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("VIOLENCIA") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label6" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("SujetoInterviene") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label7" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Corporacion") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label18" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("TIPO_LUGAR") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label8" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("EstadoHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label9" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MunicipioHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label46" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LocalidadHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label10" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ColoniaHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label12" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CalleHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label19" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("EntreCalleHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label35" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("YEntreCalleHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label40" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NO_EXTERIOR") %>' />
                                                </td>
                                               <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label41" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Detenido") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label43" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Denunciante") %>' />
                                                </td>
                                                 <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label44" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NOMBRE") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label42" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("SEXO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label47" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("EDAD") %>' />
                                                </td>
                                                                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label48" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTATUS_PERSONA") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label49" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CondicionLocalizacion") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label50" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_LOC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label51" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("PAIS") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label52" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTADO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label53" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MUNICIPIO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label54" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LOCALIDAD") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label55" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CALLE") %>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr>
                                                                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label14" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NUC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label500" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("UNIDAD") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label1" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_NUC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label15" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_HECHOS") %>' />
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label2" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("HORA_HECHOS") %>' />
                                                </td>
                                               <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label20" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Delito") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label5" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("VIOLENCIA") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label6" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("SujetoInterviene") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label7" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Corporacion") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label18" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("TIPO_LUGAR") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label8" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("EstadoHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label9" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MunicipioHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label46" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LocalidadHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label10" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ColoniaHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label12" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CalleHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label19" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("EntreCalleHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label35" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("YEntreCalleHecho") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label40" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NO_EXTERIOR") %>' />
                                                </td>
                                               <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label41" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Detenido") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label43" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("Denunciante") %>' />
                                                </td>
                                                 <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label44" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("NOMBRE") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label42" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("SEXO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label47" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("EDAD") %>' />
                                                </td>
                                                                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label48" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTATUS_PERSONA") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label49" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CondicionLocalizacion") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label50" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("FECHA_LOC") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label51" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("PAIS") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label52" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("ESTADO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label53" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("MUNICIPIO") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label54" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("LOCALIDAD") %>' />
                                                </td>
                                                <td style="background-color: #D4D6D4" align="center">
                                                    <asp:Label runat="server" ID="Label55" Font-Size="10px" ForeColor="Black" Font-Bold="true"
                                                        Text='<%# Eval("CALLE") %>' />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
            SelectCommand="SP_ListadoPersonas" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
</div>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>


