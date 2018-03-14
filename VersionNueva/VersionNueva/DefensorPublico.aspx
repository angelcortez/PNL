<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefensorPublico.aspx.cs" Inherits="AtencionTemprana.DefensorPublico" %>
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
                    Text="SOLICITAR DEFENSOR PUBLICO (IDPT)" Font-Bold="True" Font-Size="Medium" 
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
                                            &nbsp;</td>
            <td>
                &nbsp;
                               
                    <asp:Label ID="LBLNUC" runat="server" style="color: #000000"></asp:Label>
                   
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" 
                                                Text="IMPUTADO"></asp:Label>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                                            <asp:DropDownList ID="ddlImputado" runat="server" Width="400px">
                                            </asp:DropDownList>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ID_CARPETA" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="ID_DEFENSOR" runat="server" Visible="False"></asp:Label>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                                            <asp:Label runat="server" Text="SOLICITANDO" 
                    ID="lblAsignar" Visible="False"></asp:Label>

                                            <asp:Label runat="server" Text="DEFENSOR" 
                    ID="lblDefensor" Visible="False"></asp:Label>

                                            <asp:Label runat="server" Text="PUBLICO" 
                    ID="lblPublico" Visible="False"></asp:Label>

            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="cmdSi" runat="server" onclick="cmdSi_Click" Text="SI" 
                    Font-Bold="True" Height="30px" Width="30px" />
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

