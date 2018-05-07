<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuienResulteOfendido.aspx.cs" Inherits="AtencionTemprana.QuienResulteOfendido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
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
            <td class="style6">
                <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
            <td align="right" class="style6">
                </td>
        </tr>
     
      
        <tr>
            <td class="style6">
                <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
            <td align="right" class="style6">
                </td>
        </tr>
     
      
    </table>  
    <table style="width: 100%;">
        <tr>
            <td>
                                                        <asp:Label runat="server" 
                    Text="QUIEN RESULTE OFENDIDO" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Black" ID="lblElQueResulte"></asp:Label>

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
                                            <asp:Label runat="server" Text="QUIEN" 
                    ID="lblQuien" Visible="False"></asp:Label>

                                            <asp:Label runat="server" Text="RESULTE" 
                    ID="lblResulte" Visible="False"></asp:Label>

                                            <asp:Label runat="server" Text="OFENDIDO" 
                    ID="lblOfendido" Visible="False"></asp:Label>

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
                <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdTipoActor" runat="server" Text="2" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="ID_PERSONA" runat="server" Visible="False"></asp:Label>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ID_PERSONA_CARPETA" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="ID_DOMICILIO" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="cmdSi" runat="server" onclick="cmdSi_Click" Text="SI" 
                    Font-Bold="True" Height="30px" Width="30px" OnClientClick="this.disabled=true;this.value = 'SI...'" UseSubmitBehavior="false"/>
&nbsp;
                <asp:Button ID="cmdNo" runat="server" onclick="cmdNo_Click" Text="NO" 
                    Font-Bold="True" Height="30px" Width="30px" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    </td>
        </tr>
    </table>
    
</div>

</asp:Content>

