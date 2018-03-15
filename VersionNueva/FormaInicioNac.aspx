<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormaInicioNac.aspx.cs" Inherits="AtencionTemprana.FormaInicioNac" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <h2>
        &nbsp;</h2>
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel2" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#006600" 
                                        Text="FORMA DE INICIO" Font-Bold="True" Font-Size="Large"></asp:Label>
                                    <asp:Label ID="IdCarpetaInicio" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblArbol" runat="server" Visible="False">5</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="cmdCompa" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="#006600" Height="61px" onclick="cmdCompa_Click" Text="COMPARECENCIA" 
                                        Width="234px" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="61px" 
                                        ImageAlign="Middle" ImageUrl="~/img/Persona comparecencia.png" Width="71px" />
                                </td>
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
                    <asp:Panel ID="Panel1" runat="server" style="text-align: center" >
                       
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                                                ForeColor="#006600" Text="INICIAR NUMERO DE ATENCION A LA COMUNIDAD"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                        </td>
                                        <td class="style2">
                                        </td>
                                        <td class="style2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <br />
                                            <asp:ImageButton ID="ImgSi" runat="server" ImageUrl="~/img/si.png" 
                                                onclick="ImgSi_Click" TabIndex="4" />
                                        </td>
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
                                <br />
                                &nbsp;<br />
                                &nbsp;</asp:Panel>
                   
                </td>
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

