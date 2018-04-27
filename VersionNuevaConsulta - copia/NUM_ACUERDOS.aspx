<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NUM_ACUERDOS.aspx.cs" Inherits="AtencionTemprana.NUM_ACUERDOS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
    <div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
      <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Font-Size="Medium"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
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
            <td class="style4">
                
                  <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                      style="text-transform :uppercase"></asp:Label>
            </td>
            <td class="style4">
                </td>
            <td class="style4">
                </td>
            <td align="right" class="style4">
                </td>
        </tr>
     
      
        <tr>
            <td>
                
                <asp:Label ID="lblArbol" runat="server" Visible="False">7</asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 
<%--<h2><asp:Label ID="Label1" runat="server" Text="NUMERO UNICO DE MEDIACION" ForeColor="#006600"></asp:Label></h2>--%>
   <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="ID_ESTADO_NUM" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    
                                    <asp:Button ID="Button1" runat="server" Text="SUSPENDIDO POR REVISION" 
                                        Width="205px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" Text="CUMPLIDO" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button3" runat="server" Text="INCUMPLIDO" />

                        
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    </td>
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
                <td colspan="4">

                                  &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    <asp:Panel ID="Panel5" runat="server" Height="758px" ScrollBars="Auto">
                        <asp:TreeView ID="TVCarpeta" runat="server" ImageSet="Simple" Width="927px" 
                            Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Underline="False">
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                                HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <RootNodeStyle Font-Bold="True" ForeColor="#CC0000" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                                HorizontalPadding="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </asp:Panel>
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                   
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
            </tr>
        </table>
    
</div>

</asp:Content>

