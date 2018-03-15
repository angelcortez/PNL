<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WEstadistica.aspx.cs" Inherits="AtencionTemprana.WEstadistica" %>
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
    <table style="width: 100%;">
            <tr>
                <td class="style19">
                    &nbsp;
                </td>
                <td class="style20" colspan="3" align="center">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Large" ForeColor="#0064A7" style="text-align: center" 
                        Text="Módulo de Reportes" Width="668px"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;
                </td>
                <td class="style7" colspan="2">
                    &nbsp;
                </td>
                <td class="style8">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style22">
                    &nbsp;
                </td>
                <td class="style23">
                    <asp:Button ID="CmdConteoPersona" runat="server" 
                        Text="Conteo de Personas" Width="190px" class="button" Height="50px" 
                        onclick="CmdConteoPersona_Click" />
                </td>
                <td class="style24">
                    <asp:Button ID="CmdEstadisticaEstados" runat="server" 
                        Text="Denuncias Por Estado" Width="190px" class="button" Height="50px" onclick="CmdEstadisticaEstados_Click" 
                        />
                </td>
                <td class="style25">
                    &nbsp;<asp:Button ID="CmdAAnterior" runat="server" 
                         Text="Conteo de Denuncias" Width="190px" class="button" 
                        Height="50px" onclick="CmdAAnterior_Click"  />
                </td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style11" colspan="2">
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style22">
                    </td>
                <td class="style23">
                    <asp:Button ID="cmdMunicipioHecho" runat="server" 
                        Text="Por Municipio de Hecho" Width="190px" class="button" Height="50px" onclick="cmdMunicipioHecho_Click"
                        />
                </td>
                <td class="style24">
                    <asp:Button ID="CmdPorDelito" runat="server" 
                        Text="Denuncias Por Delito" Width="190px" class="button" Height="50px" 
                        onclick="CmdPorDelito_Click"  />
                </td>
                <td class="style25">
                    <asp:Button ID="CmdListadoPersona" runat="server" 
                         Text="Listado de Personas" Width="190px" class="button" Height="50px" onclick="CmdListadoPersona_Click" 
                         />
                    </td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style17">
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td>
                    
                </td>
            </tr>
        </table>
     
    </div>

</asp:Content>
