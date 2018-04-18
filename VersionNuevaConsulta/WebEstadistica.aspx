<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebEstadistica.aspx.cs" Inherits="AtencionTemprana.WebEstadistica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 296px;
            height: 19px;
        }
        .style7
        {
            width: 684px;
            height: 19px;
        }
        .style8
        {
            height: 19px;
        }
        .style11
        {
            width: 684px;
        }
        .style15
        {
            width: 414px;
        }
        .style17
        {
            width: 529px;
        }
        .style18
        {
            width: 296px;
        }
        .style19
        {
            width: 296px;
            height: 29px;
        }
        .style20
        {
            height: 29px;
        }
        .style21
        {
            height: 29px;
        }
        .style22
        {
            width: 296px;
            height: 47px;
        }
        .style23
        {
            width: 529px;
            height: 47px;
        }
        .style24
        {
            width: 414px;
            height: 47px;
        }
        .style25
        {
            height: 47px;
        }
        .style38
        {
            width: 250px;
        }
        .style39
        {
            width: 646px;
        }
        .style40
        {
            width: 85px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

        <table style="width: 100%;">
            <tr>
                <td class="style19">
                    &nbsp;
                </td>
                <td class="style20" colspan="3" align="center">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Large" ForeColor="#CC3300" style="text-align: center" 
                        Text="Módulo Estadístico" Width="668px"></asp:Label>
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
                    <asp:Button ID="CmdEstadisticaIniciadas" runat="server" 
                        Text="Carpetas Iniciadas" Width="189px" 
                        onclick="CmdEstadisticaIniciadas_Click" />
                </td>
                <td class="style24">
                    <asp:Button ID="CmdEstadisticaEstados" runat="server" 
                        Text="Estados de Carpetas" Width="189px" 
                        onclick="CmdEstadisticaEstados_Click" />
                </td>
                <td class="style25">
                    &nbsp;<asp:Button ID="CmdCulposos" runat="server" 
                         Text="Delitos Culposos Y Dolosos" 
                        Width="189px" onclick="CmdCulposos_Click" />
                </td>
            </tr>
            <tr>
                <td class="style18">
                    &nbsp;</td>
                <td class="style11" colspan="2">
                    <asp:Image ID="Image1" runat="server" Height="357px" 
                        ImageUrl="~/img/Estadistica.jpg" Width="687px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style22">
                    </td>
                <td class="style23">
                    <asp:Button ID="cmdViolencia" runat="server" 
                        Text="Delitos con violencia y sin violencia" Width="217px" onclick="cmdViolencia_Click" 
                        />
                </td>
                <td class="style24">
                    <asp:Button ID="CmdMapaDelincuencial" runat="server" 
                        onclick="CmdMapaDelincuencial_Click" Text="Mapa Delincuencial" Width="189px" />
                </td>
                <td class="style25">
                    <asp:Button ID="CmdEstadisticaDelitos" runat="server" 
                        onclick="CmdEstadisticaDelitos_Click" Text="Incidencia Delictiva" 
                        Width="189px" />
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
                    <asp:Label ID="LblMensaje" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="#FF9900" Text="¡ Módulo en Construccion !" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    </div>
</asp:Content>
