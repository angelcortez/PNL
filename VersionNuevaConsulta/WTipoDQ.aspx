<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WTipoDQ.aspx.cs" Inherits="AtencionTemprana.WTipoDQ" %>
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

 
 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
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
    <h2>
        &nbsp;</h2>
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel2" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label1" runat="server" class="color-fuente"
                                        Text="TIPO DE DENUNCIA" Font-Bold="True" Font-Size="Large"></asp:Label>
                                    <asp:Label ID="IdCarpetaInicio" runat="server" Visible="False"></asp:Label>
                                     <asp:Label ID="lblArbol" runat="server" Visible="False">2</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Denuncia" runat="server" Font-Bold="True" Font-Size="Small" 
                                         Height="61px"  Text="DENUNCIA" 
                                        Width="234px" CssClass ="button" onclick="Denuncia_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="Querella" runat="server" Font-Bold="True" Font-Size="Small" 
                                        Height="61px"  Text="QUERELLA" 
                                        Width="233px" CssClass ="button" onclick="Querella_Click" />
                                </td>
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
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOrientacion" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>

   
    
  
    
    
    
</div>

</asp:Content>

