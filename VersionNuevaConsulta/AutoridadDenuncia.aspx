<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutoridadDenuncia.aspx.cs" Inherits="AtencionTemprana.AutoridadDenuncia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    
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
            <td align="center" colspan="3">
                                               

                                    <asp:Label ID="lblDenuncia" runat="server" class="color-fuente"
                                        style="font-weight: 700; font-size: large; text-align: left;" 
                                        Text="¿ QUIÉN DENUNCIA ?"></asp:Label>

                &nbsp;
                &nbsp;
            
            </td>
        </tr>
        <tr>
            <td>
                                            &nbsp;</td>
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
                <asp:Label ID="IdTipoActor" runat="server" Text="1" Visible="False"></asp:Label>
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
                <asp:Label ID="ID_DENUNCIANTE_AUTORIDAD" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="ID_DOMICILIO" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="cmdSi" runat="server" onclick="cmdSi_Click" Text="PERSONA" 
                    Font-Bold="True" Height="30px" Width="120px" class="button"
 />
&nbsp;
                <asp:Button ID="cmdNo" runat="server" onclick="cmdNo_Click" Text="AUTORIDAD" 
                    Font-Bold="True" Height="30px" Width="120px" class="button"
 />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Panel ID="Panel1" runat="server" GroupingText="AUTORIDAD CONOCE DEL HECHO" 
                    Visible="False" ForeColor="Black">
                    <table style="width:100%;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblDisposicion" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="PUESTO A DISPOSICIÓN POR"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDisposicion0" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="NÚMERO DE OFICIO O PARTE"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:DropDownList ID="ddlPusoDisposicion" runat="server" TabIndex="49" 
                                    Width="200px" class="chosen-select">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtOficio" runat="server" Width="300px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="cmdGu" runat="server" Font-Bold="True" Height="40px" 
                                    onclick="cmdGu_Click" TabIndex="31" Text="GUARDAR" Width="156px" class="button"
 />
                                <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" 
                                    onclick="cmdReg_Click" TabIndex="32" Text="REGRESAR" Width="156px" class="button"
 />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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

