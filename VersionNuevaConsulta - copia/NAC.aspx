<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NAC.aspx.cs" Inherits="AtencionTemprana.NAC" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        <script type="text/javascript">
            function mostrarFichero(destino) {
                window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
                document.forms(0).submit();
            }
    
    </script>
<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate >
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
<h2><asp:Label ID="Label1" runat="server" Text="REGISTRO DE ATENCION A LA COMUNIDAD" 
        ForeColor="#006600"></asp:Label></h2>

        <table style="width: 100%;">
            <tr>
                <td>
                    &nbsp;
                    <asp:ImageButton ID="Remitir" runat="server" Height="63px" 
                        ImageUrl="~/img/estados/REMITIR.png" onclick="Remitir_Click" />

                       
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblArbol" runat="server" Visible="False">5</asp:Label>
                    <asp:Label ID="ID_ESTADO_NAC" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel1" runat="server" style="text-align: center" 
                        BorderWidth="2px" ForeColor="Green">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblRemitir0" runat="server" ForeColor="#006600" 
                                        style="font-weight: 700; font-size: large; text-align: left;" Text="REMITIR"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlOrientacion" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblInstitucion2" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="FECHA REMITIR"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFechaRemitir" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" 
                                        Format="dd/MM/yyyy" TargetControlID="txtFechaRemitir">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="ImgSi3" runat="server" ImageUrl="~/img/si.png" 
                                        onclick="ImgSi2_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="ImgNo3" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo3_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel6" runat="server" Height="922px" ScrollBars="Auto">
                        <asp:TreeView ID="TVCarpeta" runat="server" Height="151px" ImageSet="Simple" 
                            Width="927px">
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
                <td colspan="2">
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
            </tr>
        </table>

    </ContentTemplate>
    </asp:UpdatePanel>
    
    
    
</div>

</asp:Content>

